# hochperformantes Setup

Dies ist genau das Gegenteil von **[Speichereffizientes Setup](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup-de-DE#speichereffizientes-setup)** und normalerweise möchten Sie diesen Tipps folgen, wenn Sie die ASF-Leistung (in Bezug auf die CPU-Geschwindigkeit) weiter steigern wollen, auf potenzielle Kosten einer erhöhten Speichernutzung.

---

ASF versucht bereits die Leistung zu bevorzugen, wenn es um die allgemeine ausgewogene Abstimmung geht. Daher gibt es zwar nicht viele, aber zumindest einige Möglichkeiten um die Leistung weiter zu steigern. Beachten Sie jedoch, dass diese Optionen standardmäßig nicht aktiviert sind, was bedeutet, dass sie nicht gut genug sind, um sie für die Mehrheit der Anwendungen als ausgewogen zu gelten. Deshalb sollten Sie selbst entscheiden, ob diese Optionen zur Speichererweiterung für Sie akzeptabel sind.

---

## Laufzeitoptimierung (Erweitert)

Die folgenden Tricks **beanspruchen eine ernsthafte Steigerung der benötigten Speicherzunahme und Startdauer**, weshalb diese mit Vorsicht verwendet werden sollten.

The recommended way of applying those settings is through `DOTNET_` environment properties. Of course, you could also use other methods, e.g. `runtimeconfig.json`, but some settings are impossible to be set this way, and on top of that ASF will replace your custom `runtimeconfig.json` with its own on the next update, therefore we recommend environment properties that you can set easily prior to launching the process.

.NET runtime allows you to **[tweak garbage collector](https://docs.microsoft.com/dotnet/core/run-time-config/garbage-collector)** in a lot of ways, effectively fine-tuning the GC process according to your needs. We've documented below properties that are especially important in our opinion.

### [`gcServer`](https://docs.microsoft.com/dotnet/core/run-time-config/garbage-collector#flavors-of-garbage-collection)

> Configures whether the application uses workstation garbage collection or server garbage collection.

You can read the exact specific of the server GC at **[fundamentals of garbage collection](https://docs.microsoft.com/dotnet/standard/garbage-collection/fundamentals)**.

ASF verwendet standardmäßig die Garbage Collection der Workstation. Dies liegt vor allem an einem ausgewogenen Verhältnis zwischen Speichernutzung und Performance, das für wenige Bots mehr als ausreichend ist, da normalerweise ein einzelner gleichzeitiger Hintergrund-GC-Thread schnell genug ist um den gesamten von ASF zugewiesenen Speicher zu bewältigen.

Heutzutage haben wir jedoch eine Menge an CPU-Kernen, von denen ASF sehr profitieren kann, indem wir für jede verfügbare CPU vCore einen eigenen GC-Thread bereitstellen. Dies kann die Leistung bei komplexen ASF-Aufgaben wie dem Parsen von Abzeichen-Seiten oder dem Inventar erheblich verbessern, da jede CPU vCore helfen kann, im Gegensatz zu nur 2 (Haupt und GC). Server GC wird für Maschinen mit 3 CPU vCores und mehr empfohlen, Workstation GC wird automatisch erzwungen, wenn deine Maschine nur 1 CPU vCore hat, und wenn Du genau 2 hast, dann kannst Du beide ausprobieren (die Ergebnisse können variieren).

Server GC selbst führt nicht zu einer sehr großen Speicherzunahme, wenn er einfach nur aktiv ist, aber er hat viel größere Generierungsgrößen und ist daher viel fauler, wenn es darum geht, dem Betriebssystem Speicher zurückzugeben. Du befindest dich möglicherweise an einem Sweet Spot, an dem Server GC die Leistung signifikant erhöht und Du sie weiterhin nutzen möchtest, aber gleichzeitig kannst Du dir nicht leisten, dass der enorme Speicherzuwachs, der durch die Verwendung entsteht, zunimmt. Luckily for you, there is a "best of both worlds" setting, by using server GC with **[`GCLatencyLevel`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup#gclatencylevel)** configuration property set to `0`, which will still enable server GC, but limit generation sizes and focus more on memory. Alternatively, you might also experiment with another property, **[`GCHeapHardLimitPercent`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup#gcheaphardlimitpercent)**, or even both of them at the same time.

However, if memory is not a problem for you (as GC still takes into account your available memory and tweaks itself), it's a much better idea to not change those properties at all, achieving superior performance in result.

### **[`DOTNET_TieredPGO`](https://docs.microsoft.com/dotnet/core/run-time-config/compilation#profile-guided-optimization)**

> This setting enables dynamic or tiered profile-guided optimization (PGO) in .NET 6 and later versions.

Standardmäßig deaktiviert. In a nutshell, this will cause JIT to spend more time analyzing ASF's code and its patterns in order to generate superior code optimized for your typical usage. If you want to learn more about this setting, visit **[performance improvements in .NET 6](https://devblogs.microsoft.com/dotnet/performance-improvements-in-net-6)**.

### **[`DOTNET_ReadyToRun`](https://docs.microsoft.com/dotnet/core/run-time-config/compilation#readytorun)**

> Configures whether the .NET Core runtime uses pre-compiled code for images with available ReadyToRun data. Disabling this option forces the runtime to JIT-compile framework code.

Standardmäßig aktiviert. Disabling this in combination with enabling `DOTNET_TieredPGO` allows you to extend tiered profile-guided optimization to the whole .NET platform, and not just ASF code.

---

You can enable selected properties by setting appropriate environment variables. Zum Beispiel unter Linux (Shell):

```shell
export DOTNET_gcServer=1

export DOTNET_TieredPGO=1
export DOTNET_ReadyToRun=0

./ArchiSteamFarm # For OS-specific build
./ArchiSteamFarm.sh # For generic build
```

Oder unter Windows (Powershell):

```powershell
$Env:DOTNET_gcServer=1

$Env:DOTNET_TieredPGO=1
$Env:DOTNET_ReadyToRun=0

.\ArchiSteamFarm.exe # For OS-specific build
.\ArchiSteamFarm.cmd # For generic build
```

---

## Empfohlene Optimierung

- Vergewissern Sie sich, dass Sie den Standardwert `MaxPerformance` für `OptimizationMode` verwenden. Dies ist bei weitem die wichtigste Einstellung, da die Verwendung des Wertes `MinMemoryUsage` dramatische Auswirkungen auf die Leistung hat.
- Enable server GC. Server GC can be immediately seen as being active by significant memory increase compared to workstation GC. This will spawn a GC thread for every CPU thread your machine has in order to perform GC operations in parallel with maximum speed.
- If you can't afford memory increase due to server GC, consider tweaking **[`GCLatencyLevel`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup#gclatencylevel)** and/or **[`GCHeapHardLimitPercent`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup#gcheaphardlimitpercent)** to achieve "the best of both worlds". Wenn dein Speicher es sich jedoch leisten kann, dann ist es besser, es bei der Standardeinstellung zu belassen - Server GC optimiert sich bereits während der Laufzeit und ist intelligent genug um weniger Speicher zu verbrauchen, wenn dein Betriebssystem es wirklich benötigt.
- You can also consider increased optimization for longer startup time with additional tweaking through other `DOTNET_` properties explained above.

Applying recommendations above allows you to have superior ASF performance that should be blazing fast even with hundreds or thousands of enabled bots. Die CPU sollte kein Engpass mehr sein, da ASF in der Lage ist, bei Bedarf die gesamte CPU-Leistung zu nutzen, was die benötigte Zeit auf ein Minimum reduziert. Der nächste Schritt wäre CPU und RAM Upgrades.