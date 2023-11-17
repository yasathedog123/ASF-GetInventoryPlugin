# Speichereffizientes Setup

Dies ist genau das Gegenteil von **[Hochleistungssetup](https://github. com/JustArchiNET/ArchiSteamFarm/wiki/High-performance-setup-de-DE)** und normalerweise möchten Sie diesen Tipps folgen, wenn Sie den Speicherverbrauch von ASF verringern wollen, um die Gesamtbelastung zu senken.

---

ASF ist per Definition extrem ressourcenschonend und je nach Nutzung ist sogar ein 128 MB VPS mit Linux in der Lage, es auszuführen, obwohl es nicht empfohlen wird so niedrig zu gehen da dies zu verschiedenen Problemen führen kann. Obwohl ASF leicht ist, hat es keine Angst davor, das Betriebssystem nach mehr Speicher zu fragen, wenn Speicher benötigt wird, damit ASF mit optimaler Geschwindigkeit arbeiten kann.

ASF als Anwendung versucht, so optimiert und effizient wie möglich zu sein, wobei auch die während der Ausführung verwendeten Ressourcen berücksichtigt werden. Wenn es um Speicher geht, zieht ASF die Leistung dem Speicherverbrauch vor, was zu temporären Speicherspitzen führen kann, was z. B. bei Konten mit mehr als 3 Abzeichen-Seiten auffällt, da ASF die erste Seite abruft und analysiert, daraus die Gesamtzahl der Seiten liest und dann für jede zusätzliche Seite die Abrufaufgabe startet, was zum gleichzeitigen Abrufen und Parsen der verbleibenden Seiten führt. Dieser "zusätzliche" Speicherverbrauch (im Vergleich zu einem absoluten Minimum für den Betrieb) kann die Ausführung und die Gesamtleistung drastisch beschleunigen, und zwar auf Kosten des erhöhten Speicherverbrauchs, der erforderlich ist um all diese Dinge parallel auszuführen. Ähnliches geschieht mit allen anderen allgemeinen ASF-Aufgaben, die parallel ausgeführt werden können, z. B. mit dem Parsen aktiver Handelsangebote, ASF kann sie alle auf einmal analysieren, da sie alle unabhängig voneinander agieren. On top of that, ASF (C# runtime) will **not** return unused memory back to OS immediately afterwards, which you can quickly notice in form of ASF process only taking more and more memory, but (almost) never giving that memory back to the OS. Einige Leute mögen es bereits fragwürdig finden, vielleicht sogar ein Memory-Leak vermuten, aber keine Sorge, all das ist zu erwarten.

ASF ist extrem gut optimiert und nutzt die vorhandenen Ressourcen so gut wie möglich. Eine hohe Speicherauslastung von ASF bedeutet nicht, dass ASF aktiv diesen Speicher **verwendet** und ** ihn benötigt**. Sehr oft behält ASF zugewiesenen Speicher als "Raum" für zukünftige Aktionen, da wir die Leistung drastisch verbessern können, wenn wir nicht für jeden Speicherabschnitt, den wir verwenden wollen, das Betriebssystem fragen müssen. Die Runtime sollte automatisch ungenutzten ASF-Speicher an das Betriebssystem zurückgeben, wenn das Betriebssystem ihn **wirklich** benötigt. **[Ungenutzter Speicher ist verschwendeter Speicher](https://www.howtogeek.com/128130/htg-explains-why-its-good-that-your-computers-ram-is-full)**. Du stößt auf Probleme, wenn der Speicher, den Du **benötigst** höher ist als der Speicher, der für dich verfügbar ist, nicht wenn ASF einige zusätzliche zugewiesene Ressourcen behält, mit dem Ziel, Funktionen zu beschleunigen, die in einem Moment ausgeführt werden. Du stößt auf Probleme, wenn dein Linux-Kernel den ASF-Prozess aufgrund von OOM (out of memory) beendet, nicht wenn Du den ASF-Prozess als Top-Speicherverbraucher in `htop` siehst.

**[Garbage collection](https://en.wikipedia.org/wiki/Garbage_collection_(computer_science))** process used in ASF is a very complex mechanism, smart enough to take into account not only ASF itself, but also your OS and other processes. Wenn Sie viel freien Speicher haben, wird ASF um alles bitten, was nötig ist, um die Leistung zu verbessern. Dies kann sogar bis zu 1 GB (mit Server GC) betragen. Wenn der Arbeitsspeicher ihres Betriebssystems fast erschöpft ist, gibt ASF automatisch einen Teil davon an das Betriebssystem zurück, um die Dinge zu erleichtern, was dazu führen kann, dass der Gesamtverbrauch an ASF-Speicher nur noch 50 MB beträgt. Der Unterschied zwischen 50 MB und 1 GB ist enorm, aber das gilt auch für den Unterschied zwischen einem kleinen 512 MB VPS und einem großen dedizierten Server mit 32 GB. Wenn ASF garantieren kann, dass dieser Speicher sinnvoll ist und gleichzeitig nichts anderes ihn gerade jetzt benötigt, zieht er es vor, ihn zu behalten und sich automatisch auf der Grundlage von Routinen zu optimieren, die in der Vergangenheit ausgeführt wurden. Der in ASF verwendete GC ist selbstanpassend und erzielt umso bessere Ergebnisse, je länger der Prozess läuft.

Dies ist auch der Grund, warum der ASF-Prozessspeicher von Setup zu Setup variiert, da ASF sein Bestes tut, um die verfügbaren Ressourcen **so effizient wie möglich** zu nutzen und nicht auf eine feste Art und Weise, wie es zu Windows XP-Zeiten der Fall war. Der tatsächliche (reale) Speicherverbrauch, den ASF verwendet, kann mit dem `stats` **[Befehl](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-de-DE)** überprüft werden und liegt normalerweise bei etwa 4 MB für nur wenige Bots, bis zu 30 MB, wenn Du Dinge wie **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-de-DE)** und andere erweiterte Features verwendest. Bedenke, dass der von dem Befehl `stats` zurückgegebene Speicher auch freien Speicher beinhaltet, der noch nicht vom Garbage Collector zurückgefordert wurde. Alles andere ist gemeinsamer Laufzeitspeicher (ca. 40-50 MB) und Ausführungsspielraum (variiert). Aus diesem Grund kann der gleiche ASF auch nur 50 MB in einer speicherarmen VPS-Umgebung verwenden, während er sogar bis zu 1 GB auf ihrem Desktop verwendet. ASF passt sich aktiv an die jeweilige Umgebung an und wird versuchen, ein optimales Gleichgewicht zu finden, um das Betriebssystem weder unter Druck zu setzen noch seine eigene Leistung einzuschränken, wenn Sie viel ungenutzten Speicher haben, der in Gebrauch genommen werden könnte.

---

Natürlich gibt es viele Möglichkeiten, wie Du ASF helfen kannst die richtige Richtung in Bezug auf den Speicher den Du verwenden möchtest zu lenken. Im Allgemeinen ist es am besten, den Garbage-Collector in Ruhe arbeiten zu lassen und das zu tun, was er für das Beste hält. Aber das ist nicht immer möglich, zum Beispiel, wenn ihr Linux-Server auch mehrere Websites, MySQL-Datenbank und PHP-Worker hostet, dann können Sie es sich nicht wirklich leisten, dass ASF sich selbst reduziert, wenn Sie in der Nähe von OOM (Out of Memory) liegen, da es normalerweise zu spät ist und der Leistungsabfall früher kommt. Dies ist in der Regel der Fall, wenn Du an einer weiteren Optimierung interessiert bist und deshalb diese Seite liest.

Die folgenden Vorschläge sind in einige Kategorien unterteilt, mit unterschiedlichem Schwierigkeitsgrad.

---

## ASF-Setup (Einfach)

Die folgenden Tricks **beeinträchtigen die Leistung nicht negativ** und können sicher auf allen Setups angewendet werden.

- Run **[generic version](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up#generic-setup)** of ASF if possible. Generic version of ASF uses less memory since it doesn't include runtime inside, doesn't come as single file, doesn't need to unpack itself on run, and is therefore smaller and has less memory footprint. OS-specific packages are handy and convenient, but they're also bundled with everything needed to launch ASF, which is something you can take care of yourself and use generic ASF variant instead.
- Führe niemals mehr als eine ASF-Instanz aus. ASF ist dazu gedacht, eine unbegrenzte Anzahl von Bots auf einmal zu verarbeiten, und wenn Du nicht jede ASF-Instanz an eine andere Interface/IP-Adresse bindest, solltest Du genau **einen** ASF-Prozess haben, mit mehreren Bots (falls erforderlich).
- Nutze `ShutdownOnFarmingFinished`. Ein aktiver Bot benötigt mehr Ressourcen als ein deaktivierter. Es ist keine nennenswerte Einsparung, da der Zustand des Bot noch beibehalten werden muss, aber Du sparst eine gewisse Menge an Ressourcen, insbesondere alle mit dem Netzwerk verbundenen Ressourcen, wie TCP-Sockets. You can always bring up other bots if needed.
- Halte die Anzahl ihrer Bots niedrig. Nicht `Enabled` Bot-Instanz benötigen weniger Ressourcen, da ASF sich nicht die Mühe macht, sie zu starten. Bedenke auch, dass ASF für jede ihrer Konfigurationen einen Bot erstellen muss. Wenn Du also den gegebenen Bot nicht `start` musst und Du etwas mehr Speicherplatz sparen willst, kannst Du `Bot.json` vorübergehend umbenennen, z. B. in `Bot.json.bak`, um zu vermeiden, dass der Status für ihre deaktivierte Bot-Instanz in ASF erzeugt wird. Auf diese Weise kannst Du es nicht `start`, ohne es umzubenennen, aber ASF wird sich auch nicht die Mühe machen, den Zustand dieses Bot im Speicher zu halten und Platz für andere Dinge zu lassen (sehr kleine Ersparnis, in 99,9% der Fälle solltest Du dich nicht damit beschäftigen, behalte einfach ihre Bots mit `Enabled` von `false`).
- Fine-tune your configs. Especially global ASF config has many variables to adjust, for example by increasing `LoginLimiterDelay` you'll bring up your bots slower, which will allow already started instance to fetch badges in the meantime, as opposed to bringing up your bots faster, which will take more resources as more bots will do major work (such as parsing badges) at the same time. Je weniger Arbeit zur gleichen Zeit erledigt werden muss - desto weniger Speicherplatz wird verbraucht.

Das sind einige Dinge, die Du im Hinterkopf behalten kannst, wenn es um die Speichernutzung geht. Diese Dinge haben jedoch keine "entscheidende" Bedeutung für die Speichernutzung, da die Speichernutzung hauptsächlich von Dingen kommt, mit denen ASF es zu tun hat, und nicht von internen Strukturen, die für das Sammeln von Karten verwendet werden.

Die ressourcenintensivsten Funktionen sind:
- Das Parsen der Abzeichen-Seite
- Das Parsen des Inventars

Das bedeutet, dass der Speicher am meisten ansteigt, wenn es sich bei ASF um das Lesen von Abzeichen-Seiten handelt, und wenn es sich um sein Inventar handelt (z. B. das Senden von Handelsangeboten oder das Arbeiten mit STM). Denn ASF hat es mit einer wirklich großen Datenmenge zu tun - der Speicherverbrauch ihres Lieblingsbrowsers, der diese beiden Seiten startet, wird nicht niedriger sein. Tut mir leid, so funktioniert es - verringere die Anzahl ihrer Abzeichen-Seiten und halte die Anzahl ihrer Inventar-Gegenstände niedrig, das kann sicher helfen.

---

## Laufzeitoptimierung (Erweitert)

Die folgenden Tricks **führen auch zur Leistungsminderung** und sollten mit Vorsicht angewendet werden.

The recommended way of applying those settings is through `DOTNET_` environment properties. Of course, you could also use other methods, e.g. `runtimeconfig.json`, but some settings are impossible to be set this way, and on top of that ASF will replace your custom `runtimeconfig.json` with its own on the next update, therefore we recommend environment properties that you can set easily prior to launching the process.

.NET runtime allows you to **[tweak garbage collector](https://docs.microsoft.com/dotnet/core/run-time-config/garbage-collector)** in a lot of ways, effectively fine-tuning the GC process according to your needs. We've documented below properties that are especially important in our opinion.

### [`GCHeapHardLimitPercent`](https://docs.microsoft.com/dotnet/core/run-time-config/garbage-collector#heap-limit-percent)

> Specifies the allowable GC heap usage as a percentage of the total physical memory.

The "hard" memory limit for ASF process, this setting tunes GC to use only a subset of total memory and not all of it. It may become especially useful in various server-like situations where you can dedicate a fixed percentage of your server's memory for ASF, but never more than that. Be advised that limiting memory for ASF to use will not magically make all of those required memory allocations go away, therefore setting this value too low might result in running into out of memory scenarios, where ASF process will be forced to terminate.

On the other hand, setting this value high enough is a perfect way to ensure that ASF will never use more memory than you can realistically afford, giving your machine some breathing room even under heavy load, while still allowing the program to do its job as efficiently as possible.

### [`GCHighMemPercent`](https://docs.microsoft.com/dotnet/core/run-time-config/garbage-collector#high-memory-percent)

> Specifies the amount of memory used after which GC becomes more aggressive.

This setting configures the memory threshold of your whole OS, which once passed, causes GC to become more aggressive and attempt to help the OS lower the memory load by running more intensive GC process and in result releasing more free memory back to the OS. It's a good idea to set this property to maximum amount of memory (as percentage) which you consider "critical" for your whole OS performance. Default is 90%, and usually you want to keep it in 80-97% range, as too low value will cause unnecessary aggression from the GC and performance degradation for no reason, while too high value will put unnecessary load on your OS, considering ASF could release some of its memory to help.

### **[`GCLatencyLevel`](https://github.com/dotnet/runtime/blob/4b90e803262cb5a045205d946d800f9b55f88571/src/coreclr/gc/gcpriv.h#L375-L398)**

> Gibt die GC-Latenzstufe an, für die Du optimieren möchtest.

This is undocumented property that turned out to work exceptionally well for ASF, by limiting size of GC generations and in result make GC purge them more frequently and more aggressively. Default (balanced) latency level is `1`, but you can use `0`, which will tune for memory usage.

### [`gcTrimCommitOnLowMemory`](https://docs.microsoft.com/dotnet/standard/garbage-collection/optimization-for-shared-web-hosting)

> Wenn wir die Einstellung vorgenommen haben, trimmen wir den engagierten Raum aggressiver für das ephemere Segment. Dies wird verwendet, um viele Instanzen von Serverprozessen auszuführen, bei denen sie so wenig Speicher wie möglich gebunden halten wollen.

This offers little improvement, but may make GC even more aggressive when system will be low on memory, especially for ASF which makes use of threadpool tasks heavily.

---

You can enable selected properties by setting appropriate environment variables. Zum Beispiel unter Linux (Shell):

```shell
# Don't forget to tune those if you're planning to make use of them
export DOTNET_GCHeapHardLimitPercent=0x4B # 75% as hex
export DOTNET_GCHighMemPercent=0x50 # 80% as hex

export DOTNET_GCLatencyLevel=0
export DOTNET_gcTrimCommitOnLowMemory=1

./ArchiSteamFarm # For OS-specific build
./ArchiSteamFarm.sh # For generic build
```

Oder unter Windows (Powershell):

```powershell
# Don't forget to tune those if you're planning to make use of them
$Env:DOTNET_GCHeapHardLimitPercent=0x4B # 75% as hex
$Env:DOTNET_GCHighMemPercent=0x50 # 80% as hex

$Env:DOTNET_GCLatencyLevel=0
$Env:DOTNET_gcTrimCommitOnLowMemory=1

.\ArchiSteamFarm.exe # For OS-specific build
.\ArchiSteamFarm.cmd # For generic build
```

Insbesondere `GCLatencyLevel` wird sehr nützlich sein, da wir überprüft haben, dass die Laufzeit tatsächlich Programmcode für den Speicher optimiert und somit den durchschnittlichen Speicherverbrauch signifikant reduziert, selbst bei Server-GC. Es ist einer der besten Tricks, die Du anwenden kannst, wenn Du den ASF-Speicherverbrauch deutlich senken und gleichzeitig die Leistung mit `OptimizationMode` nicht zu stark beeinträchtigen willst.

---

## ASF-Abstimmung (Mittelmäßig)

Die folgenden Tricks **führen zu einer ernsthaften Leistungsabnahme** und sollten mit Vorsicht angewendet werden.

- Als letzten Ausweg kannst Du ASF für `MinMemoryUsage` durch `OptimizationMode` in der **[globalen KonfigurationsEigenschaft (Property)](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-de-DE#global-config)** einstellen. Lesen Sie sorgfältig seinen Zweck, da dies eine ernsthafte Leistungseinbuße ist und fast keine Vorteile für den Speicher hat. Dies ist normalerweise **das Letzte, was Du tun willst**, lange nachdem Du die **[Laufzeitoptimierung](#runtime-tuning-advanced)** durchgeführt hast, um sicherzustellen, dass Du keine andere Wahl hast. Unless absolutely critical for your setup, we discourage using `MinMemoryUsage`, even in memory-constrained environments.

---

## Empfohlene Optimierung

- Start from simple ASF setup tricks, use **[generic ASF variant](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up#generic-setup)** and check if perhaps you're just using your ASF in a wrong way such as starting the process several times for all of your bots, or keeping all of them active if you need just one or two to autostart.
- If it's still not enough, enable all configuration properties listed above by setting appropriate `DOTNET_` environment variables. Insbesondere `GCLatencyLevel` bietet signifikante Laufzeitverbesserungen bei geringen Leistungskosten.
- Wenn auch das nicht geholfen hat, aktiviere als letztes Mittel `MinMemoryUsage` `OptimizationMode`. Dies zwingt ASF, fast alles in synchroner Angelegenheit auszuführen, was es viel langsamer macht, aber auch nicht auf Thread-Pool angewiesen ist, um die Dinge auszugleichen, wenn es um die parallele Ausführung geht.

Es ist physisch unmöglich, den Speicher noch weiter zu verringern, dein ASF ist bereits in Bezug auf die Leistung stark beeinträchtigt und Du hast alle deine Möglichkeiten ausgeschöpft, sowohl code- als auch laufzeitbezogen. Überlege dir, etwas zusätzlichen Speicher für ASF hinzuzufügen, selbst 128 MB würden einen großen Unterschied machen.