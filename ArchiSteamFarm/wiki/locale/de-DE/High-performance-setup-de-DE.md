# Hochperformantes Einrichtung

Dies ist genau das Gegenteil des **[speichereffizienten Setups](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup-de-DE#speichereffizientes-setup)** und normalerweise möchten Sie diesen Tipps folgen, wenn Sie die ASF-Leistung (in Bezug auf die CPU-Geschwindigkeit) weiter steigern möchten - meist auf Kosten einer erhöhten Speichernutzung.

---

ASF versucht bereits die Leistung zu bevorzugen, wenn es um die allgemeine ausgewogene Abstimmung geht. Daher gibt es zwar nicht viele, aber zumindest einige Möglichkeiten um die Leistung weiter zu steigern. Beachten Sie jedoch, dass diese Optionen standardmäßig nicht aktiviert sind, was bedeutet, dass sie nicht gut genug sind, um sie für die Mehrheit der Anwendungen als ausgewogen zu gelten. Deshalb sollten Sie selbst entscheiden, ob diese Optionen zur Speichererweiterung für Sie akzeptabel sind.

---

## Laufzeitoptimierung (Erweitert)

Die folgenden Tricks **beanspruchen eine ernsthafte Steigerung der benötigten Speicherzunahme und Startdauer**, weshalb diese mit Vorsicht verwendet werden sollten.

Die empfohlene Methode, diese Einstellungen anzuwenden, ist über `DOTNET_` Umgebungsvariablen. Natürlich können Sie auch andere Methoden verwenden (z.B. `runtimeconfig.json`), aber einige Einstellungen können auf diese Weise nicht gesetzt werden, und darüber hinaus ersetzt ASF Ihre benutzerdefinierte `runtimeconfig.json` mit der Eigenen beim nächsten Update; daher empfehlen wir Umgebungsvariablen, die Sie leicht einstellen können, bevor Sie den Prozess starten.

.NET Runtime ermöglicht Ihnen den **[Garbage Collector](https://learn.microsoft.com/de-de/dotnet/core/runtime-config/garbage-collector)** auf viele Arten zu optimieren - stellen Sie den GC-Prozess effizient nach Ihren Bedürfnissen ein. Wir haben nachfolgend Variablen dokumentiert, die unserer Meinung nach besonders wichtig sind.

### [`gcServer`](https://learn.microsoft.com/de-de/dotnet/core/runtime-config/garbage-collector#flavors-of-garbage-collection)

> Legt fest, ob die Garbage Collection am Arbeitsstation oder Server verwendet.

Sie können die genaue Spezifikation des Servers GC unter **[Grundlagen des Garbage Collectors](https://learn.microsoft.com/de-de/dotnet/standard/garbage-collection/fundamentals)** lesen.

ASF verwendet standardmäßig die Garbage Collection der Arbeitsstation. Dies liegt vor allem an einem ausgewogenen Verhältnis zwischen Speichernutzung und Leistung, das für wenige Bots mehr als ausreichend ist, da normalerweise ein einzelner gleichzeitiger Hintergrund-GC-Thread schnell genug ist um den gesamten von ASF zugewiesenen Speicher zu bewältigen.

Heutzutage haben wir jedoch eine Menge an CPU-Kernen, von denen ASF sehr profitieren kann, indem wir für jeden verfügbaren CPU vCore einen eigenen GC-Thread bereitstellen. Dies kann die Leistung bei komplexen ASF-Aufgaben (etwa beim Verarbeiten von Abzeichen-Seiten oder dem Inventar) erheblich verbessern, da jede CPU vCore helfen kann, im Gegensatz zu nur 2 (Haupt und GC). Server GC wird für Geräte mit 3 CPU vCores und mehr empfohlen, Arbeitsstation-GC wird automatisch erzwungen, wenn Ihr Gerät nur 1 CPU vCore hat, und wenn Sie genau 2 haben, dann können Sie beide ausprobieren (die Ergebnisse können variieren).

Server GC selbst führt nicht zu einer sehr großen Speicherzunahme, wenn er einfach nur aktiv ist, aber er hat viel größere Generierungsgrößen und ist daher viel fauler, wenn es darum geht, dem Betriebssystem Speicher zurückzugeben. Sie befinden sich möglicherweise an einem Sweet Spot, an dem Server GC die Leistung signifikant erhöht und Sie sie weiterhin nutzen möchten, aber gleichzeitig können Sie sich nicht leisten, dass der enorme Speicherzuwachs, der durch die Verwendung entsteht, zunimmt. Zum Glück gibt es für Sie eine "Das Beste aus beiden Welten"-Einstellung, indem Sie den Server GC mit **[GC latency level](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup-de-DE#gclatencylevel)** auf `0` setzten, was immerhin Server GC aktiviert, aber die Größe der Generierung einschränkt und mehr auf den Speicher fokussiert. Alternativ können Sie auch mit einer anderen Variable experimentieren, **[`GCHeapHardLimitPercent`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup#gcheaphardlimitpercent)**, oder sogar beides zur gleichen Zeit.

Wenn jedoch der Speicher kein Problem für Sie ist (da GC immer noch Ihren verfügbaren Speicher berücksichtigt und sich selbst optimiert), dann ist es jedoch eine viel bessere Idee, diese Variablen überhaupt nicht zu ändern, um eine überlegene Leistung im Ergebnis zu erzielen.

### **[`DOTNET_TieredPGO`](https://docs.microsoft.com/dotnet/core/run-time-config/compilation#profile-guided-optimization)**

> Diese Einstellung ermöglicht eine dynamische oder gestaffelt profilorientierte Optimierung (PGO) in .NET 6 und höher Versionen.

Standardmäßig deaktiviert. Kurz gesagt - dies wird dazu führen, dass JIT mehr Zeit mit der Analyse des ASF-Codes und dessen Muster verbringt, um überlegenen Code zu generieren, der für Ihre typische Verwendung optimiert wurde. Wenn Sie mehr über diese Einstellung erfahren möchten, besuchen Sie **[Leistungsverbesserungen in .NET 6](https://devblogs.microsoft.com/dotnet/performance-improvements-in-net-6)**.

### **[`DOTNET_ReadyToRun`](https://docs.microsoft.com/dotnet/core/run-time-config/compilation#readytorun)**

> Legt fest, ob die .NET Core Laufzeit vorkompilierten Code für Abbilder (Images) mit verfügbaren ReadyToRun-Daten verwendet. Deaktivieren dieser Option erzwingt die Laufzeit von JIT-Framework-Code.

Standardmäßig aktiviert. Beim Deaktivieren in Kombination mit dem Aktivieren von `DOTNET_TieredPGO`, können Sie die gestaffelte Profil-gesteuerte Optimierung auf das Ganze ausweiten .NET-Plattform, und nicht nur ASF-Code.

---

Sie können die ausgewählten Eigenschaften aktivieren, indem Sie entsprechende Umgebungsvariablen setzen. Zum Beispiel unter Linux (Shell):

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
- Aktiviert den Server GC. Server GC kann sofort als aktiv angesehen werden - durch eine signifikante Speichererhöhung im Vergleich zum Arbeitsstation-GC. Dies erstellt einen GC-Thread für jeden CPU-Thread, den Ihr Gerät besitzt, um GC-Operationen parallel mit maximaler Geschwindigkeit durchzuführen.
- Wenn Sie sich aufgrund von Server GC keine Speichererhöhung leisten können, könnten Sie die Änderung von **[`GCLatencyLevel`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup-de-DE#gclatencylevel)** und/oder **[`GCHeapHardLimitPercent`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup-de-DE#gcheaphardlimitpercent)** erwägen, um das Beste beider Welten zu erreichen. Wenn Ihr Speicher es sich jedoch leisten kann, dann ist es besser, es bei der Standardeinstellung zu belassen - Server GC optimiert sich bereits während der Laufzeit und ist intelligent genug um weniger Speicher zu verbrauchen, wenn das Betriebssystem es wirklich benötigt.
- Sie können auch eine erhöhte Optimierung für längere Startzeiten in Betracht ziehen, indem Sie durch weitere `DOTNET_` Variablen (oben erklärt) zusätzlich einstellen.

Die oben genannten Empfehlungen ermöglichen Ihnen eine überlegene ASF-Leistung, die auch mit Hunderten oder Tausenden von aktivierten Bots schnell sein sollte. Die CPU sollte kein Engpass mehr sein, da ASF in der Lage ist, bei Bedarf die gesamte CPU-Leistung zu nutzen, was die benötigte Zeit auf ein Minimum reduziert. Der nächste Schritt wären CPU und RAM Upgrades.