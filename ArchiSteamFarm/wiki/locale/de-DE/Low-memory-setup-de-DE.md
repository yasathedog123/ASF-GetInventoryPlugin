# Speichereffiziente Einrichtung

Dies ist genau das Gegenteil der **[hochperformanten Einrichtung](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/High-performance-setup-de-DE)** und normalerweise möchten Sie diesen Tipps folgen, wenn Sie den Speicherverbrauch von ASF verringern möchten, um die Gesamtbelastung zu senken.

---

ASF ist definitionsgemäß extrem ressourcenschonend und je nach Nutzung ist sogar ein 128 MB VPS mit Linux in der Lage, es auszuführen, obwohl es nicht empfohlen wird, so niedrig zu gehen, da dies zu verschiedenen Problemen führen kann. Obwohl ASF leicht ist, hat es keine Angst davor, das Betriebssystem nach mehr Speicher zu fragen, wenn Speicher benötigt wird, damit ASF mit optimaler Geschwindigkeit arbeiten kann.

ASF als Anwendung versucht, so optimiert und effizient wie möglich zu sein, wobei auch die während der Ausführung verwendeten Ressourcen berücksichtigt werden. Wenn es um Speicher geht, zieht ASF die Leistung dem Speicherverbrauch vor, was zu temporären Speicherspitzen führen kann. Bei Konten mit mehr als drei Abzeichen-Seiten ist das auffällig, weil ASF die erste Seite abruft und analysiert, anschließend die Gesamtanzahl der Seiten auswertet und anschließend die Abrufaufgabe durchführt, um die verbleibenden Seiten zu synchronisieren und zu sortieren. Dieser „zusätzliche“ Speicherverbrauch (im Vergleich zu einem absoluten Minimum für den Betrieb) kann die Ausführung und die Gesamtleistung drastisch beschleunigen, und zwar auf Kosten des erhöhten Speicherverbrauchs, der erforderlich ist, um all diese Dinge parallel auszuführen. Ähnliches geschieht mit allen anderen allgemeinen ASF-Aufgaben, die parallel ausgeführt werden können, z. B. mit dem Parsen aktiver Handelsangebote. ASF kann diese alle auf einmal analysieren, da sie alle unabhängig voneinander agieren. Darüber hinaus wird ASF (C# Runtime) ungenutzten Speicher **nicht** sofort danach an das Betriebssystem zurückgeben, was man in Form eines ASF-Prozesses schnell bemerken kann, der nur mehr und mehr Speicher benötigt, aber diesen Speicher (fast) nie an das Betriebssystem zurückgibt. Einige Leute mögen dies bereits für fragwürdig halten und vielleicht sogar ein Memory-Leak vermuten, aber keine Sorge, all das ist zu erwarten.

ASF ist extrem gut optimiert und nutzt die vorhandenen Ressourcen so gut wie möglich. Eine hohe Speicherauslastung von ASF bedeutet nicht, dass ASF aktiv diesen Speicher **verwendet** und **ihn benötigt**. Sehr oft behält ASF zugewiesenen Speicher als „Raum“ für zukünftige Aktionen, da wir die Leistung drastisch verbessern können, wenn wir nicht für jeden Speicherabschnitt, den wir verwenden möchten, das Betriebssystem fragen müssen. Die Runtime (Laufzeitumgebung) sollte automatisch ungenutzten ASF-Speicher an das Betriebssystem zurückgeben, wenn das Betriebssystem ihn **wirklich** benötigt. **[Ungenutzter Speicher ist verschwendeter Speicher](https://www.howtogeek.com/128130/htg-explains-why-its-good-that-your-computers-ram-is-full)** (englisch). Sie stoßen auf Probleme, wenn der Speicher, den Sie ⁣**benötigen⁣**, höher ist als der Speicher, der für Sie verfügbar ist; nicht, wenn ASF einige zusätzliche zugewiesene Ressourcen behält, mit dem Ziel, Funktionen zu beschleunigen, die in einem Moment ausgeführt werden. Sie stoßen auf Probleme, wenn Ihr Linux-Kernel den ASF-Prozess aufgrund von OOM (out of memory) beendet; nicht wenn Sie den ASF-Prozess als Top-Speicherverbraucher in `htop` sehen.

Der in ASF verwendete **[Garbage collection](https://de.wikipedia.org/wiki/Garbage_Collection)**-Prozess (GC) ist ein sehr komplexer Mechanismus, intelligent genug, um nicht nur ASF selbst, sondern auch Ihr Betriebssystem und andere Prozesse zu berücksichtigen. ASF wird alle notwendigen Maßnahmen ergreifen, um die Leistung zu verbessern, wenn Sie viel freien Speicher haben. Dies kann sogar bis zu 1 GB (mit Server GC) betragen. Wenn der Arbeitsspeicher Ihres Betriebssystems fast erschöpft ist, gibt ASF automatisch einen Teil davon an das Betriebssystem zurück, um die Dinge zu erleichtern, was dazu führen kann, dass der Gesamtverbrauch an ASF-Speicher nur noch 50 MB beträgt. Der Unterschied zwischen 50 MB und 1 GB ist enorm, aber das gilt auch für den Unterschied zwischen einem kleinen 512 MB VPS und einem großen dedizierten Server mit 32 GB. Wenn ASF garantieren kann, dass dieser Speicher sinnvoll ist und gleichzeitig nichts anderes ihn derzeit benötigt, zieht ASF es vor, ihn zu behalten und sich automatisch auf der Grundlage von Routinen zu optimieren, die in der Vergangenheit ausgeführt wurden. Der in ASF verwendete GC passt sich eigenständig und erzielt umso bessere Ergebnisse, je länger der Prozess läuft.

Dies ist auch der Grund, warum der ASF-Prozessspeicher von Setup zu Setup variiert, da ASF sein Bestes tut, um die verfügbaren Ressourcen **so effizient wie möglich** zu verwenden und nicht auf eine feste Art und Weise, wie es zu Windows XP-Zeiten der Fall war. Der tatsächliche (reale) Speicherverbrauch, den ASF verwendet, kann mit dem `stats` **[Befehl](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-de-DE)** überprüft werden und liegt normalerweise bei ungefähr 4 MB für nur wenige Bots, bis zu 30 MB, wenn Sie Dinge wie **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-de-DE)** und andere erweiterte Features verwenden. Bedenken Sie, dass der von dem Befehl `stats` zurückgegebene Speicher auch freien Speicher beinhaltet, der bislang nicht vom Garbage Collector zurückgefordert wurde. Alles andere ist gemeinsamer Laufzeitspeicher (ca. 40-50 MB) und Ausführungsspielraum (variiert). Aus diesem Grund kann die gleiche ASF auch nur 50 MB in einer speicherarmen VPS-Umgebung verwenden, während er sogar bis zu 1 GB auf Ihrem Desktop verwendet. ASF passt sich aktiv an die jeweilige Umgebung an und wird versuchen, ein optimales Gleichgewicht zu finden, um das Betriebssystem weder unter Druck zu setzen noch seine eigene Leistung einzuschränken, wenn Sie viel ungenutzten Speicher haben, der in Gebrauch genommen werden könnte.

---

Natürlich gibt es viele Möglichkeiten, wie Sie ASF helfen können, die richtige Richtung in Bezug auf den Speicher, den Sie verwenden möchten, zu lenken. Im Allgemeinen ist es am besten, den Garbage-Collector in Ruhe arbeiten zu lassen und das zu tun, was er für das Beste hält. Aber das ist nicht immer möglich, zum Beispiel, wenn Ihr Linux-Server auch mehrere Websites, MySQL-Datenbank und PHP-Worker hostet, dann können Sie es sich nicht wirklich leisten, dass ASF sich selbst reduziert, wenn Sie in der Nähe von OOM (Out of Memory) liegen, da es normalerweise zu spät ist und der Leistungsabfall früher kommt. Dies ist in der Regel der Fall, wenn Sie an einer weiteren Optimierung interessiert sind und deshalb diese Seite lesen.

Die folgenden Vorschläge sind in einige Kategorien unterteilt, mit unterschiedlichem Schwierigkeitsgrad.

---

## ASF-Einrichtung (Einfach)

Die folgenden Tricks **beeinträchtigen die Leistung nicht negativ** und können sicher auf allen Setups angewendet werden.

- Führen Sie (falls möglich) die **[ASF-Version `generic`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up-de-DE#generic-setup)** aus. Die generische Version von ASF verbraucht weniger Speicher, da sie keine Runtime (Laufzeitumgebung) im Inneren enthält, nicht als einzelne Datei kommt, sich nicht beim Start selbst entpacken muss, und ist daher kleiner und hat einen geringeren Speicher-Fußabdruck. OS-spezifische Pakete sind praktisch und komfortabel, aber sie sind auch mit allem gebündelt, dass zum Start von ASF benötigt wird; das ist etwas, um das Sie sich selbst kümmern und stattdessen die generische ASF-Variante verwenden können.
- Führen Sie niemals mehr als eine ASF-Instanz aus. ASF ist dazu gedacht, eine unbegrenzte Anzahl von Bots auf einmal zu verarbeiten, und wenn Sie nicht jede ASF-Instanz an eine andere Interface/IP-Adresse binden, sollten Sie genau **einen** ASF-Prozess haben, mit mehreren Bots (falls erforderlich).
- Nutzen Sie `ShutdownOnFarmingFinished` in den Bot-Einstellungen (`FarmingPreferences`). Ein aktiver Bot benötigt mehr Ressourcen als ein deaktivierter. Es ist keine nennenswerte Einsparung, da der Zustand des Bots noch beibehalten werden muss, aber Sie sparen eine gewisse Menge an Ressourcen, insbesondere alle mit dem Netzwerk verbundenen Ressourcen (z. B. TCP-Sockets). Falls es erforderlich ist, steht es Ihnen frei, jederzeit weitere Bots zu integrieren.
- Halten Sie die Anzahl Ihrer Bots niedrig. Nicht `Enabled` (aktivierte) Bot-Instanz benötigen weniger Ressourcen, da ASF sich nicht die Mühe macht, diese zu starten. Bedenken Sie auch, dass ASF für jede Ihrer Konfigurationen einen Bot erstellen muss. Wenn Sie also den gegebenen Bot nicht `start`en müssen und Sie etwas mehr Speicherplatz sparen wollen, können Sie `Bot.json` vorübergehend umbenennen, z. B. in `Bot.json.bak`, um zu vermeiden, dass der Status für Ihre deaktivierte Bot-Instanz in ASF erzeugt wird. Auf diese Weise können Sie es nicht `start`en, ohne es umzubenennen, aber ASF wird sich auch nicht die Mühe machen, den Zustand dieses Bot im Speicher zu halten und Platz für andere Dinge zu lassen (sehr kleine Ersparnis, in 99,9% der Fälle sollten Sie sich nicht damit beschäftigen, behalte einfach Ihre Bots mit `Enabled` von `false`).
- Passen Sie Ihre Einstellungen genau an. Insbesondere die globale ASF-Konfiguration hat viele Variablen, die angepasst werden müssen, z. B. durch die Erhöhung von `LoginLimiterDelay` werden Ihre Bots langsamer, was es bereits gestarteten Instanzen ermöglicht, Abzeichen in der Zwischenzeit zu holen, anstatt Ihre Bots schneller aufzurufen. Dies beansprucht mehr Ressourcen, da mehr Bots gleichzeitig größere Aufgaben erledigen (z. B. Parsen von Abzeichen). Je weniger Arbeit zur gleichen Zeit erledigt werden muss, desto weniger Speicherplatz wird verbraucht.

Das sind einige Dinge, die Sie im Hinterkopf behalten können, wenn es um die Speichernutzung geht. Jedoch sind diese Aspekte nicht „ausschlaggebend“ für die Nutzung des Speichers, da ASF nicht auf interne Strukturen abzielt, die für die Sammlung von Karten genutzt werden.

Die ressourcenintensivsten Funktionen sind:
- Parsen der Abzeichen-Seite
- Parsen des Inventars

Das bedeutet, dass der Speicher am meisten ansteigt, wenn es sich ASF mit dem Verarbeiten von Abzeichen-Seiten und dessen Inventar handelt (z. B. das Senden von Handelsangeboten oder das Arbeiten mit STM). Denn ASF hat es mit einer wirklich großen Datenmenge zu tun – der Speicherverbrauch Ihres Lieblingsbrowsers, der diese beiden Seiten startet, wird nicht niedriger sein. Tut mir leid, so funktioniert es – verringern Sie die Anzahl Ihrer Abzeichen-Seiten und halten Sie die Anzahl Ihrer Inventar-Gegenstände niedrig; das kann sicher helfen.

---

## Laufzeitoptimierung (Erweitert)

Die folgenden Tricks **führen auch zur Leistungsminderung** und sollten mit Vorsicht angewendet werden.

Die empfohlene Methode, diese Einstellungen anzuwenden, ist über `DOTNET_` Umgebungsvariablen. Natürlich können Sie auch andere Methoden verwenden, z.B. `runtimeconfig.json`, aber einige Einstellungen können auf diese Weise nicht gesetzt werden, und darüber hinaus ersetzt ASF Ihre benutzerdefinierte `runtimeconfig.json` mit der Eigenen beim nächsten Update; daher empfehlen wir Umgebungsvariablen, die Sie leicht einstellen können, bevor Sie den Prozess starten.

.NET Runtime ermöglicht Ihnen den **[Garbage Collector](https://learn.microsoft.com/de-de/dotnet/core/runtime-config/garbage-collector)** auf viele Arten zu optimieren – stellen Sie den GC-Prozess effizient nach Ihren Bedürfnissen ein. Wir haben nachfolgend Variablen dokumentiert, die unserer Meinung nach besonders wichtig sind.

### [`GCHeapHardLimitPercent`](https://learn.microsoft.com/de-de/dotnet/core/runtime-config/garbage-collector#heap-limit-percent)

> Legt die zulässige GC-Heap-Nutzung als Prozentsatz des gesamten physikalischen Speichers fest.

Das „harte“ Speicherlimit für den ASF-Prozess, diese Einstellung passt GC so an, dass nur eine Teilmenge des gesamten Speichers verwendet wird und nicht alles. Es kann in verschiedenen serverähnlichen Situationen besonders nützlich sein, in denen Sie einen festen Prozentsatz des Arbeitsspeichers Ihres Servers für ASF verwenden können, aber nie mehr als diesen. Bitte beachten Sie, dass die Begrenzung des Arbeitsspeichers für ASF nicht magisch dazu führt, dass alle benötigten Speicherzuweisungen verschwinden. Aus diesem Grund kann es passieren, dass unzureichend RAM verfügbar sein kann und der ASF-Prozess beendet werden muss, wenn der Wert zu niedrig eingestellt wird.

Diesen Wert hoch genug zu setzen ist andererseits ein perfekter Weg, um sicherzustellen, dass ASF nie mehr Speicher verbraucht als realistischerweise zur Verfügung stünde; womit Ihr Gerät auch unter schwerer Last einen Spielraum hat, während das Programm seine Arbeit so effizient wie möglich erledigen kann.

### [`GCConserveMemory`](https://learn.microsoft.com/de-de/dotnet/core/runtime-config/garbage-collector#conserve-memory)

> Konfiguriert den Garbage Collector auf Kosten häufigerer Müllsammlungen und möglicherweise längerer Pausenzeiten.

Ein Wert zwischen 0-9 kann verwendet werden. Je größer der Wert, desto mehr optimiert GC den Speicher über die Performance.

### [`GCHighMemPercent`](https://learn.microsoft.com/de-de/dotnet/core/runtime-config/garbage-collector#high-memory-percent)

> Gibt die Menge des verwendeten Arbeitsspeichers an, nach der GC aggressiver wird.

Diese Einstellung konfiguriert den Speicherschwellenwert für Ihr gesamtes Betriebssystem, welcher während des Überschreitens dazu führt, dass GC aggressiver wird und versucht, dem Betriebssystem beim Senken der Speicherlast zu helfen, indem ein intensiverer GC-Prozess ausgeführt und dadurch mehr freier Speicher zurück an das Betriebssystem freigegeben wird. Es ist eine gute Idee, diese Variable auf einen maximalen Wert des Arbeitsspeichers (in Prozent) zu setzen, den Sie als „kritisch“ für Ihre gesamte Betriebssystem-Leistung betrachten. Der Standardwert liegt bei 90 % und normalerweise möchten Sie diesen im Bereich 80-97 % behalten, da ein zu niedriger Wert unnötige Aggression aus dem GC und unnötige Leistungseinbußen verursachen wird; während ein zu hoher Wert eine unnötige Belastung auf Ihrem Betriebssystem verursacht – in Anbetracht dessen, könnte ASF einen Teil seines Arbeitsspeichers freigeben, um zu helfen.

### **[`GCLatencyLevel`](https://github.com/dotnet/runtime/blob/a1d48d6c00b5aecc063d1a58b0d9281c611ada91/src/coreclr/gc/gcpriv.h#L445-L468)**

> Gibt die GC-Latenzstufe an, für die Sie optimieren möchten.

Diese undokumentierte Eigenschaft ist für ASF von großer Bedeutung, da sie die Größe der GC-Generationen begrenzt und zu einer häufigeren und aggressiveren Reinigung führt. Die standardmäßige (symmetrische) Latenzstufe ist `1`, aber Sie können `0` verwenden, wodurch die Speichernutzung angepasst wird.

### [`gcTrimCommitOnLowMemory`](https://learn.microsoft.com/de-de/dotnet/standard/garbage-collection/optimization-for-shared-web-hosting)

> Wenn wir die Einstellung vorgenommen haben, trimmen wir den verpflichteten „Raum“ aggressiver für das flüchtige Segment. Dies wird verwendet, um viele Instanzen von Serverprozessen auszuführen, bei denen sie so wenig Speicher wie möglich gebunden halten möchten.

Dies bietet kleine Verbesserung(en), kann aber GC noch aggressiver machen, wenn das System wenig Speicher hat, insbesondere für ASF, welche Threadpool-Aufgaben stark nutzt.

---

Sie können die ausgewählten Eigenschaften aktivieren, indem Sie entsprechende Umgebungsvariablen setzen. Zum Beispiel unter Linux (Shell):

```shell
# Vergessen Sie nicht dies anzupassen wenn Sie es verwenden möchten
export DOTNET_GCHeapHardLimitPercent=0x4B # 75% as hex
export DOTNET_GCHighMemPercent=0x50 # 80% as hex

export DOTNET_GCConserveMemory=9
export DOTNET_GCLatencyLevel=0
export DOTNET_gcTrimCommitOnLowMemory=1

./ArchiSteamFarm # For OS-specific build
./ArchiSteamFarm.sh # For generic build
```

Oder unter Windows (Powershell):

```powershell
# Vergessen Sie nicht dies anzupassen wenn Sie es verwenden möchten
$Env:DOTNET_GCHeapHardLimitPercent=0x4B # 75% as hex
$Env:DOTNET_GCHighMemPercent=0x50 # 80% as hex

$Env:DOTNET_GCConserveMemory=9
$Env:DOTNET_GCLatencyLevel=0
$Env:DOTNET_gcTrimCommitOnLowMemory=1

.\ArchiSteamFarm.exe # For OS-specific build
.\ArchiSteamFarm.cmd # For generic build
```

Insbesondere `GCLatencyLevel` wird sehr nützlich sein, da wir überprüft haben, dass die Runtime (Laufzeitumgebung) tatsächlich Programmcode für den Speicher optimiert und somit den durchschnittlichen Speicherverbrauch signifikant reduziert, selbst bei Server-GC. Es ist einer der besten Tricks, die Sie anwenden können, wenn Sie den ASF-Speicherverbrauch deutlich senken und gleichzeitig die Leistung mit `OptimizationMode` nicht zu stark beeinträchtigen möchten.

---

## ASF-Abstimmung (Mittelmäßig)

Die folgenden Tricks **führen zu einer ernsthaften Leistungsabnahme** und sollten mit Vorsicht angewendet werden.

- Als letzten Ausweg können Sie ASF für `MinMemoryUsage` durch `OptimizationMode` in der **[globalen Konfigurationsvariable](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-de-DE#global-config)** einstellen. Lesen Sie sorgfältig seinen Zweck, da dies eine ernsthafte Leistungseinbuße ist und fast keine Vorteile für den Speicher hat. Dies ist normalerweise **das Letzte, was Sie tun wollen**, nachdem Sie die **[Laufzeitoptimierung](#runtime-tuning-advanced)** durchgeführt haben, um sicherzustellen, dass Sie keine andere Wahl haben. Sofern nicht unbedingt für Ihr Setup absolut notwendig, raten wir von der Nutzung der `MinMemoryUsage` ab, auch in eingeschränkten Speicherumgebungen.

---

## Empfohlene Optimierung

- Beginnen Sie mit einfachen ASF Einrichtungstricks, verwenden Sie die **[`generic` ASF-Variante](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up-de-DE#generic-setup)** und überprüfen Sie, ob Sie vielleicht einfach nur Ihre ASF auf eine falsche Weise verwenden; z. B. durch mehrmaliges Starten des Prozesses für alle Bots, oder dem Weiterbetrieb aller unnötigen Bots, wenn Sie nur ein oder zwei im Autostart benötigen.
- Wenn es immer noch nicht ausreicht, aktivieren Sie alle oben aufgeführten Konfigurationseigenschaften, indem Sie die entsprechenden `DOTNET` Umgebungsvariablen einstellen. Insbesondere `GCLatencyLevel` bietet signifikante Laufzeitverbesserungen bei geringen Leistungskosten.
- Wenn auch das nicht geholfen hat, aktiviere Sie als letztes Mittel `MinMemoryUsage` `OptimizationMode`. Dies zwingt ASF, fast alles in synchroner Angelegenheit auszuführen, was es viel langsamer macht, aber auch nicht auf Thread-Pool angewiesen ist, um die Dinge auszugleichen, wenn es um die parallele Ausführung geht.

Es ist physisch unmöglich, den Speicher noch weiter zu verringern, Ihr ASF ist bereits in Bezug auf die Leistung stark beeinträchtigt und Sie haben alle Ihre Möglichkeiten ausgeschöpft (sowohl code- als auch laufzeitbezogen). Überlegen Sie sich, etwas zusätzlichen Speicher für ASF hinzuzufügen; selbst 128 MB würden einen großen Unterschied machen.