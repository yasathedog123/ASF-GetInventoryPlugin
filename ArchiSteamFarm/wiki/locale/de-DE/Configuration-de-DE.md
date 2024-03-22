# Konfiguration

Diese Seite widmet sich der Konfiguration von ASF. Es dient als eine lückenlose Dokumentation des `config` Verzeichnisses, sodass Sie ASF auf Ihre Bedürfnisse abstimmen können.

* **[Einleitung](#einleitung)**
* **[Web-basierter Konfigurationsgenerator](#web-basierter-konfigurationsgenerator)**
* **[ASF-UI-Einstellungen](#asf-ui-einstellungen)**
* **[Manuelle Konfiguration](#manuelle-konfiguration)**
* **[Globale Konfiguration](#globale-konfiguration)**
* **[Bot-Konfiguration](#bot-konfiguration)**
* **[Datei-Struktur](#dateistruktur)**
* **[JSON-Strukturierung](#json-strukturierung)**
* **[Kompatibilitätsstrukturierung](#kompatibilitätsstrukturierung)**
* **[Konfigurationskompatibilität](#konfigurationskompatibilität)**
* **[Automatisches Nachladen](#automatisches-nachladen)**

---

## Einleitung

Die ASF-Konfiguration gliedert sich in zwei Hauptteile – die globale (Prozess-) Konfiguration und die Konfiguration jedes einzelnen Bots. Jeder Bot hat seine eigene Bot-Konfigurationsdatei namens `BotName.json` (wobei `BotName` der Name des Bots ist), während die globale ASF (Prozess-)Konfiguration eine einzige Datei namens `ASF.json` ist.

Ein Bot ist ein einzelnes Steam-Konto welches am ASF-Prozess teilnimmt. Um ordnungsgemäß zu funktionieren, benötigt ASF mindestens **eine** definierte Bot-Instanz. Es gibt keine prozessbedingte Begrenzung der Bot-Instanzen, sodass Sie theoretisch unendlich viele Bots (Steam-Konten) verwenden können.

ASF verwendet das **[JSON](https://de.wikipedia.org/wiki/JSON)** Format zum Speichern seiner Konfigurationsdateien. Es ist ein benutzerfreundliches, lesbares und sehr universelles Format in dem man das Programm konfigurieren kann. Keine Sorge, Sie müssen sich nicht mit JSON auskennen, um ASF zu konfigurieren. Wir erwähnen es nur, falls Sie bereits daran denken ASF-Konfigurationen mit einer Art Bash-Skript stapelweise zu erstellen.

Die Konfiguration kann auf unterschiedliche Art und Weise erfolgen. Sie können unseren **[webbasierten Konfigurationsgenerator](https://justarchinet.github.io/ASF-WebConfigGenerator)** verwenden, der eine von ASF unabhängige lokale App ist. Sie können unsere **[ASF-UI](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-de-DE#asf-ui)** IPC-Benutzeroberfläche für die Konfiguration direkt in ASF verwenden. Schließlich können Sie die Konfigurationsdateien immer manuell erzeugen, da sie der unten angegebenen festen JSON-Struktur folgen. Wir werden in aller Kürze die verfügbaren Optionen erklären.

---

## Web-basierter Konfigurationsgenerator

Der Zweck des **[web-basierten Konfigurationsgenerators](https://justarchinet.github.io/ASF-WebConfigGenerator)** ist es, Ihnen ein benutzerfreundliches Frontend zur Verfügung zu stellen, das zum Erzeugen von ASF-Konfigurationsdateien verwendet wird. Der web-basierte Konfigurationsgenerator ist zu 100 % Client-basiert, was bedeutet, dass die von Ihnen eingegebenen Daten ausschließlich lokal verarbeitet werden, ohne diese woanders hin zu versenden. Dies garantiert Sicherheit und Zuverlässigkeit, da es sogar **[offline](https://github.com/JustArchiNET/ASF-WebConfigGenerator/tree/main/docs)** funktioniert, wenn zuvor alle Dateien heruntergeladen wurden. Sie müssen dann anschließend lediglich `index.html` im Browser öffnen.

Der web-basierte Konfigurationsgenerator wurde unter Chrome und Firefox getestet, sollte aber in allen gängigen JavaScript-fähigen Browsern ordnungsgemäß funktionieren.

Die Verwendung ist denkbar einfach – man wählt über die entsprechenden Registerkarten, ob man eine Konfiguration für `ASF` oder `Bot` erstellen möchte; überprüft ob die gewählte Version der Konfigurationsdatei zur verwendeten ASF-Version passt; füllt dann die entsprechenden Felder aus und klickt abschließend auf die Schaltfläche „Herunterladen“. Verschieben Sie diese Datei in das ASF-Verzeichnis `config` und überschreiben Sie diesen bei Bedarf vorhandene Dateien. Bei allen zukünftigen Anpassungen können diese Schritte jederzeit wiederholt werden. Der Rest dieses Abschnitts erklärt alle zur Verfügung stehenden Konfigurationsmöglichkeiten.

---

## ASF-UI-Einstellungen

Unsere **[ASF-UI](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-de-DE#asf-ui)** IPC-Schnittstelle erlaubt es Ihnen auch ASF zu konfigurieren und ist eine bessere Lösung für die Neukonfiguration von ASF nach der Generierung der ersten Konfigurationen aufgrund der Tatsache, dass es die Konfigurationen im direkt bearbeiten kann im Gegensatz zum webbasierten Konfigurationsgenerator, welcher sie statisch erzeugt.

Um ASF-ui verwenden zu können, müssen Sie unsere **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-de-DE)**-Schnittstelle selbst aktivieren. `IPC` ist standardmäßig aktiviert, sodass Sie sofort darauf zugreifen können, solange Sie es nicht selbst deaktiviert haben.

Nach dem Start des Programms navigieren Sie einfach zu ASFs **[IPC-Adresse](http://localhost:1242)**. Wenn alles richtig funktioniert hat, können Sie auch die ASF-Konfiguration von dort aus ändern.

---

## Manuelle Konfiguration

Im Allgemeinen empfehlen wir dringend entweder unseren Konfigurationsgenerator oder ASF-ui zu verwenden, da es viel einfacher ist und sicherstellt, dass Sie keinen Fehler in der JSON-Struktur machen; aber wenn Sie aus irgendeinem Grund nicht möchten, dann können Sie auch die richtigen Konfigurationen manuell erstellen. Für einen guten Start mit einer angemessenen JSON-Strukturierung, finden Sie die unten entsprechende JSON-Beispiele. Sie können den Inhalt in eine Datei kopieren und ihn als Basis für Ihre Konfiguration verwenden. Da Sie keine unserer Frontends verwenden, stellen Sie sicher, dass die Konfiguration **[valid (gültig)](https://jsonlint.com)** ist, da ASF diese nicht lädt, wenn es nicht geparst werden kann. Auch wenn es sich um ein gültiges JSON handelt, müssen Sie auch sicherstellen, dass alle Eigenschaften den korrekten Typ haben, wie von ASF verlangt. Mehr Informationen bezüglich der korrekten JSON-Strukturierung aller verfügbaren Felder erhalten Sie im diesbezüglichen Abschnitt **[JSON-Strukturierung](#json-strukturierung)** und unserer Dokumentation unten.

---

## Globale Konfiguration

Die globale Konfiguration befindet sich in der Datei `ASF.json` und hat folgende Struktur:

```json
{
  "AutoRestart": true,
  "Blacklist": [],
  "CommandPrefix": "!",
  "ConfirmationsLimiterDelay": 10,
  "ConnectionTimeout": 90,
  "CurrentCulture": null,
  "Debug": false,
  "DefaultBot": null,
  "FarmingDelay": 15,
  "FilterBadBots": true,
  "GiftsLimiterDelay": 1,
  "Headless": false,
  "IdleFarmingPeriod": 8,
  "InventoryLimiterDelay": 4,
  "IPC": true,
  "IPCPassword": null,
  "IPCPasswordFormat": 0,
  "LicenseID": null,
  "LoginLimiterDelay": 10,
  "MaxFarmingTime": 10,
  "MaxTradeHoldDuration": 15,
  "MinFarmingDelayAfterBlock": 60,
  "OptimizationMode": 0,
  "SteamMessagePrefix": "/me ",
  "SteamOwnerID": 0,
  "SteamProtocols": 7,
  "UpdateChannel": 1,
  "UpdatePeriod": 24,
  "WebLimiterDelay": 300,
  "WebProxy": null,
  "WebProxyPassword": null,
  "WebProxyUsername": null
}
```

---

Alle Optionen werden nachfolgend erklärt:

### `AutoRestart`

Typ `bool` mit dem Standardwert `true`. Diese Variable legt fest, ob ASF bei Bedarf einen Selbst-Neustart durchführen darf. Es gibt ein paar Fälle, die von ASF einen Neustart erfordern, z. B. die ASF-Aktualisierung (durchgeführt mit `UpdatePeriod` oder dem Befehl `update`), sowie das Verändern der `ASF.json` Konfiguration, dem `restart` Befehl und ähnlich. Normalerweise beinhaltet der Neustart zwei Teile – das Erstellen eines neuen Prozesses und das Beenden des aktuellen Prozesses. Die meisten Benutzer sollten damit einverstanden sein und diese Variable auf dem Standardwert `true` behalten – wenn Sie ASF durch ein eigenes Skript und/oder mit `dotnet` ausführen; sollten Sie vielleicht die volle Kontrolle über den Start des Prozesses haben und eine Situation vermeiden, in der ein neuer (neu gestarteter) ASF-Prozess irgendwo im Hintergrund und nicht im Vordergrund des Skripts läuft, der zusammen mit dem alten ASF-Prozess beendet wurde. Dies ist besonders wichtig, wenn man bedenkt, dass der neue Prozess nicht mehr ein direkter Unterprozess („Kind“)  ist, was Sie z. B. nicht in die Lage versetzen würde, die Standardkonsolen-Eingabe dafür zu verwenden.

Wenn das der Fall ist, ist diese Variable speziell für Sie, weshalb Sie diese auf `false` setzen können. Bedenken Sie jedoch, dass **Sie** in diesem Fall für den Neustart des Prozesses verantwortlich sind. Dies ist einigermaßen wichtig, da ASF sich nur beendet, anstatt einen neuen Prozess zu starten (z. B. nach der Aktualisierung), sodass, wenn Sie keine Logik hinzugefügt haben, ASF einfach stoppt, bis Sie es wieder starten. ASF beendet sich immer mit einem korrekten Fehlercode, der Erfolg (Null) oder Misserfolg (ungleich Null) anzeigt. Auf diese Weise können Sie in Ihrem Skript eine entsprechende Logik hinzufügen, die einen automatischen Neustart von ASF im Fehlerfall vermeiden sollte oder zumindest zur weiteren Analyse eine lokale Kopie von `log.txt` erstellt. Beachten Sie ebenfalls, dass der Befehl `restart` ASF immer neu startet, unabhängig davon, wie diese Variable eingestellt ist, da diese Variable das Standardverhalten definiert, während der Befehl `restart` den Prozess immer neu startet. Wenn Sie keinen Grund dafür haben, diese Funktion zu deaktivieren, sollte dies aktiviert bleiben.

---

### `Blacklist`

Typ `ImmutableHashSet<uint>` mit einem leeren Standardwert. Wie der Name schon verrät, definiert diese globale Konfigurationseigenschaft appIDs (Spiele), die vom automatischen Sammel-Prozesses durch ASF vollständig ignoriert werden. Leider liebt Steam es Sommer/Winter-Sale-Abzeichen als „verfügbar für Kartenabgabe“ zu kennzeichnen, was den ASF-Prozess verwirrt, da es den Eindruck erweckt, dass es sich um ein gültiges Spiel handelt das gesammelt werden sollte. Wenn es keine schwarze Liste gäbe, würde ASF irgendwann beim Sammeln eines Spieles (das eigentlich kein Spiel ist) „hängen“ bleiben und unendlich warten bis die Karten gesammelt wurden, was aber nie passieren wird. Die schwarze Liste von ASF makiert solche Abzeichen als ungeeignet bezüglich des Sammelprozesses, sodass wir diese bei der Entscheidung, was zu Sammeln ist, stillschweigend ignorieren und nicht in die Falle tappen können.

ASF enthält standardmäßig zwei schwarze Listen – `SalesBlacklist`, die fest im ASF-Quellcode programmiert und nicht bearbeitet werden kann, sowie die normale `Blacklist` die hier definiert ist. Die `SalesBlacklist` wird zusammen mit der ASF-Version aktualisiert und enthält typischerweise alle „schlechten“ AppIDs zum Zeitpunkt der Veröffentlichung, sodass Sie, wenn die aktuelle Version von ASF verwendet wird, nicht eine eigene `Blacklist` (wie hier erläutert) pflegen müssen. Der Hauptzweck dieser Variable ist es Ihnen die Möglichkeit zu geben, neue, zum Zeitpunkt der ASF-Veröffentlichung unbekannte AppIDs (die nicht gespielt werden sollten) auf die schwarze Liste zu setzen. Die fest definierte `SalesBlacklist` wird so schnell wie möglich aktualisiert, daher ist es nicht erforderlich, dass Sie Ihre eigene `Blacklist` aktualisieren, wenn Sie die neueste ASF-Version verwenden, aber ohne `Blacklist` wären Sie gezwungen, ASF zu aktualisieren, um „weiterzumachen“, wenn Valve ein neues Sale-Abzeichen veröffentlicht. Wir möchten unsere Nutzer nicht zwingen, den neuesten ASF-Code zu verwenden, daher ist diese Variable hier, damit Sie gegebenenfalls ASF selbst zu „reparieren“, wenn du aus irgenIhrem Grund nicht auf neue fest programmierte `SalesBlacklist` in der neuen ASF-Version aktualisieren möchten. Wenn Sie keinen **triftigen** Grund haben diese Variable zu bearbeiten, sollte der Standardwert belassen werden.

Wenn Sie stattdessen auf der Suche nach einer bot-basierten Sperrliste sind, werfen Sie einen Blick auf die **[Befehle](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-de-DE)** `fb`, `fbadd` und `fbrm`.

---

### `CommandPrefix`

Typ `string` mit einem Standardwert `!`. Diese Variable spezifiziert das **größensensitive** Präfix, das für **[Befehle](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-de-DE)** in ASF verwendet wird. Mit anderen Worten: Sie sollten es jedem ASF-Befehl voranstellen, damit ASF auch zuhört. Es ist möglich, diesen Wert auf `null` oder leer zu setzen, damit ASF kein Befehlspräfix verwendet, in diesem Fall geben Sie die Befehle jeweils mit Ihren einfachen Bezeichnern ein. Dies kann jedoch die Leistung von ASF beeinträchtigen, da ASF optimiert ist, um Nachrichten nicht weiter zu analysieren, sobald diese nicht mit `CommandPrefix` beginnen; wenn Sie sich absichtlich dazu entscheiden, sie nicht zu verwenden, wird ASF gezwungen sein, alle Nachrichten zu lesen und darauf zu reagieren, selbst wenn es sich nicht um ASF-Befehle handelt. Daher wird empfohlen, weiterhin irgenIhr `CommandPrefix` zu verwenden, z. B. `/`, wenn Sie den Standardwert `!` nicht mögen. Aus Konsistenzgründen betrifft `CommandPrefix` den gesamten ASF-Prozess. Wenn Sie keinen Grund haben diese Variable zu bearbeiten, sollte der Standardwert belassen werden.

---

### `ConfirmationsLimiterDelay`

Typ `byte` mit einem Standardwert `10`. ASF wird sicherstellen, dass mindestens `ConfirmationsLimiterDelay` Sekunden zwischen zwei aufeinanderfolgenden 2FA-Bestätigungen liegen, die Anfragen abrufen, um eine Auslösung des Anfragelimits zu vermeiden – diese werden von **[ASF-2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication-de-DE)** während z. B. des Befehls `2faok`, sowie bei verschiedenen handelsbezogenen Operationen nach Bedarf verwendet. Der Standardwert wurde auf Basis unserer Tests festgelegt und sollte nicht verringert werden, wenn Sie auf keine Probleme stoßen möchten. Sofern Sie keinen **triftigen** Grund haben diese Variable zu bearbeiten, sollte der Standardwert belassen werden.

---

### `ConnectionTimeout`

Typ `byte` mit einem Standardwert `90`. Diese Variable definiert die Auszeiten (timeouts) für verschiedene Netzwerkaktionen, die von ASF ausgeführt werden, in Sekunden. Im Einzelnen definiert `ConnectionTimeout` die Auszeit in Sekunden für HTTP- und IPC-Anfragen, `ConnectionTimeout / 10` definiert die maximale Anzahl der fehlgeschlagenen Heartbeats, während `ConnectionTimeout / 30` die Anzahl der Minuten definiert, die wir für die initiale Steam-Netzwerkverbindungsanforderung berücksichtigen. Der Standardwert `90` sollte für die Mehrheit der Benutzer in Ordnung sein, aber wenn Sie eine eher langsame Netzwerkverbindung oder einen PC haben, sollte diese Zahl vielleicht um etwas erhöhet werden (wie `120`). Beachten Sie, dass höhere Werte langsame oder sogar unzugängliche Steam-Server nicht auf magische Weise reparieren, also sollten wir nicht unendlich auf etwas warten, das nicht passieren wird, und es einfach später noch einmal versuchen. Eine zu hohe Einstellung dieses Wertes führt zu einer übermäßigen Verzögerung bei der Erfassung von Netzwerkproblemen und zu einer Verringerung der Gesamtleistung. Wenn Sie diesen Wert zu niedrig einstellen verringert sich auch die Gesamtstabilität und -leistung, da ASF eine gültige Anfrage abbricht, die noch verarbeitet wird. Daher hat das Setzen dieses Wertes unter dem Standardwert im Allgemeinen keinen Vorteil, da Steam-Server von Zeit zu Zeit sehr langsam sind und mehr Zeit für das Verarbeiten von ASF-Anfragen benötigen könnten. Der Standardwert ist eine ausgewogene Balance zwischen dem Vertrauen, dass unsere Netzwerkverbindung stabil ist, und dem Misstrauen des Steam-Netzwerks, unsere Anfrage innerhalb einer bestimmten Auszeit zu bearbeiten. Wenn Sie Probleme früher erkennen und die ASF-Wiederverbindung bzw. -Antwort beschleunigen möchten, sollte der Standardwert dies tun (oder ganz knapp darunter, z. B. `60`, wodurch ASF weniger geduldig wird). Sollten Sie stattdessen bemerken, dass ASF auf Netzwerkprobleme stößt (z. B. fehlgeschlagene Anfragen, Heartbeats, die verloren gehen oder die Verbindung zu Steam unterbrochen wird) könnte es sinnvoll sein, diesen Wert zu erhöhen, wenn Sie sicher sind, dass es sich um einen Problem mit Steam und **nicht** um einen Fehler in Ihrem Netzwerk; da zunehmende Auszeiten ASF mehr „geduldig“ machen und sich nicht entscheiden, die Verbindung sofort wieder herzustellen.

Eine Beispielsituation, die eine Erhöhung dieser Variable erfordern könnte, ist die Möglichkeit, ASF mit einem sehr großen Handelsangebot zu beauftragen, das gut 2+ Minuten dauern kann, um von Steam vollständig akzeptiert und bearbeitet zu werden. Durch die Erhöhung des Standard-Timeout wird ASF geduldiger und wartet länger, bevor es entscheidet, dass der Handelsversuch erfolglos und die ursprüngliche Anfrage aufgibt.

Eine weitere Situation könnte durch eine sehr langsame Maschine oder Internetverbindung verursacht werden, die mehr Zeit benötigt, um die zu übertragenden Daten zu verarbeiten. Dies ist eine ziemlich seltene Bedingung, da die CPU/Netzwerkbandbreite fast nie ein Engpass ist, aber dennoch eine erwähnenswerte Möglichkeit.

Kurz gesagt, der Standardwert sollte in den meisten Fällen angemessen sein, aber Sie können ihn bei Bedarf erhöhen. Trotzdem macht es keinen großen Sinn, weit über den Standardwert hinauszugehen, da größere Auszeiten unzugängliche Steam-Server nicht magisch beheben. Wenn Sie keinen Grund haben diese Variable zu bearbeiten, sollte der Standardwert belassen werden.

---

### `CurrentCulture`

Typ `string` mit einem Standardwert `null`. Standardmäßig versucht ASF, die Sprache des Betriebssystems zu verwenden, und wird es vorziehen, übersetzte Zeichenketten (falls verfügbar) in dieser Sprache zu verwenden. Dies ist möglich dank unserer Community, die versucht, ASF in allen gängigen Sprachen zu **[übersetzen](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Localization-de-DE)**. Wenn Sie aus irgendeinem Grund die Standardsprache des Betriebssystems nicht verwenden möchten, können Sie diese Konfigurationseigenschaft verwenden, um eine gültige Sprache auszuwählen, die Sie stattdessen verwenden möchten. Für eine Liste aller verfügbaren Sprachen besuche Sie bitte **[MSDN](https://msdn.microsoft.com/de-de/library/cc233982.aspx)** und suchen nach `Language tag`. Es ist erwähnenswert, dass ASF sowohl spezifische Sprachen wie `en-GB` , als auch neutrale Sprachen wie `en` akzeptiert. Die Angabe der aktuellen Sprache kann auch andere sprachspezifische Aspekte beeinflussen, z. B. das Währungs-/Datumsformat und ähnliches. Es muss beachtet werden, dass möglicherweise zusätzliche Schrift-/Sprachpakete erforderlich sind, um sprachspezifische Zeichen richtig darzustellen, wenn Sie eine nicht-native Sprache gewählt haben. Normalerweise möchten Sie diese Konfigurationseigenschaft verwenden, wenn Sie ASF auf Englisch anstelle Ihrer Muttersprache bevorzugen.

---

### `Debug`

Typ `bool` mit dem Standardwert `false`. Diese Variable legt fest, ob der Prozess im Debug-Modus laufen soll. Im Debug-Modus erstellt ASF ein spezielles Verzeichnis `debug` neben dem `config` Verzeichnis, das die gesamte Kommunikation zwischen ASF und den Steam-Servern verfolgt. Debug-Informationen können helfen, lästige Probleme im Zusammenhang mit der Vernetzung und dem allgemeinen ASF-Arbeitsablauf zu erkennen. Darüber hinaus werden einige Programmroutinen viel ausführlicher sein, z. B. `WebBrowser`, die den genauen Grund für das Scheitern einiger Anfragen angeben – diese Einträge werden in das normale ASF-Protokoll geschrieben. **Sie sollten ASF nicht im Debug-Modus ausführen, es sei denn, Sie werden von einem Entwickler dazu aufgefordert**. Das Ausführen von ASF im Debug-Modus **verringert die Leistung**, **beeinträchtigt die Stabilität negativ** und ist **weitaus ausführlicher an verschiedenen Stellen**, daher sollte es **nur** gewollt und kurzfristig, für das Debuggen bestimmter Probleme, die Reproduktion des Problems oder das Erhalten von mehr Informationen über eine fehlgeschlagene Anfrage und ähnliches verwendet werden, aber **nicht** für die normale Programmausführung. Sie werden **viele** neue Fehler, Probleme und Ausnahmen sehen – stellen Sie sicher, dass Sie ein gutes Wissen über ASF, Steam und seine Besonderheiten haben, wenn Sie alles selbst zu analysieren; da nicht alles relevant ist.

**WARNUNG:** Das Aktivieren dieses Moduses beinhaltet das Protokollieren von **potenziell sensiblen** Informationen wie Anmeldeinformationen und Passwörter, die Sie für die Anmeldung bei Steam verwenden (aufgrund der Netzwerkprotokollierung). Diese Daten werden sowohl in das Verzeichnis `debug`, als auch in die normale `log.txt` Datei geschrieben (diese ist nun absichtlich viel umfangreicher, um diese Information zu protokollieren). Sie sollten keine Debug-Inhalte, die von ASF generiert wurden, an einem öffentlichen Ort posten; der ASF-Entwickler sollte Sie immer daran erinnern, diese an seine E-Mail oder einen anderen sicheren Ort zu senden. Wir speichern diese sensiblen Details nicht und verwenden sie auch nicht, sie werden als Teil von Debug-Routinen geschrieben, da deren Anwesenheit für das Problem, welches Sie betrifft, relevant sein könnte. Wir würden es vorziehen, wenn Sie das ASF-Logging in keiner Weise ändern würden, aber wenn Sie besorgt sind, können Sie diese sensiblen Details entsprechend überarbeiten.

> Beim Editieren werden sensible Details, z. B. durch Sterne, ersetzt. Sie sollten darauf verzichten, sensible Zeilen ganz zu entfernen, da Ihre reine Existenz relevant sein könnte und erhalten werden sollte.

---

### `DefaultBot`

Typ `string` mit einem Standardwert `null`. In einigen Szenarien funktioniert ASF mit einem Konzept eines Standardbots, der für die Handhabung von Dingen verantwortlich ist (z. B. IPC-Befehle oder interaktive Konsole), wenn Sie keinen Zielbot angeben. Mit dieser Variable können Sie den Standardbot auswählen, der für den Umgang in solchen Szenarien verantwortlich ist, indem Sie seinen `BotName` hier setzen. Falls der angegebene Bot nicht existiert, oder Sie einen Standardwert `null`verwenden, wird ASF stattdessen den ersten registrierten Bot alphabetisch sortieren. Üblichlerweise möchten Sie diese Konfigurationseigenschaft verwenden, wenn Sie das Argument `[Bots]` in IPC- und interaktiven Konsolenbefehlen weglassen möchten, um immer den gleichen Bot für solche Anrufe als Standard zu verwenden.

---

### `FarmingDelay`

Typ `byte` mit einem Standardwert `15`. Damit ASF funktioniert, wird es alle `FarmingDelay` Minuten das aktuell gesammelte Spiel überprüfen, ob es vielleicht schon alle Karten erhalten hat. Wenn Sie diese Variable zu niedrig einstellen, kann dies dazu führen, dass eine übermäßige Anzahl von Steam-Anfragen gesendet wird, während eine zu hohe Einstellung dazu führen kann, dass ASF immer noch den vorgegebenen Titel für bis zu `FarmingDelay` Minuten, nachdem es vollständig gesammelt wurde, „sammelt“. Der Standardwert sollte für die meisten Benutzer hervorragend sein, aber wenn Sie viele Bots im Einsatz haben, können Sie ihn auf etwa `30` Minuten erhöhen, um das Senden von Steam-Anfragen zu begrenzen. Es ist gut zu wissen, dass ASF einen ereignisbasierten Mechanismus verwendet und die Spiel-Abzeichen-Seite für jeden gesammelten Steam-Gegenstand überprüft, sodass wir im Allgemeinen **nicht einmal in festen Zeitabständen überprüfen müssen**; aber da wir dem Steam-Netzwerk nicht voll vertrauen – überprüfen wir die Spiel-Abzeichen-Seite trotzdem, wenn wir es nicht überprüft haben, indem die Karte im letzten `FarmingDelay` Minuten gesammelt wurde (falls das Steam-Netzwerk uns nicht über den gesammelten Gegenstand oder dergleichen informiert hat). Angenommen, das Steam-Netzwerk funktioniert ordnungsgemäß, wird die Herabsetzung dieses Wertes **in keiner Weise die Effizienz des Sammelns verbessern**, während **die Erhöhung des Netzwerkaufwandes dies signifikant tut** – es wird empfohlen, es nur (falls erforderlich) vom Standardwert aus auf `15` Minuten zu erhöhen. Wenn Sie keinen **triftigen** Grund haben diese Variable zu bearbeiten, sollte der Standardwert belassen werden.

---

### `FilterBadBots`

Typ `bool` mit dem Standardwert `true`. Diese Variable legt fest, ob ASF automatisch Handelsangebote ablehnt, die von bekannten und markierten bösartigen Akteuren empfangen werden. Dazu wird ASF bei Bedarf mit unserem Server kommunizieren, um eine Liste von Steam-Identifikatoren zu erhalten, die auf der schwarzen Liste stehen. Die aufgeführten Bots werden von Personen betrieben, die von uns als schädlich für die ASF-Initiative eingestuft werden. Etwa diejenigen, die unseren **[Verhaltenskodex](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/.github/CODE_OF_CONDUCT.md)** verletzen; die von uns bereitgestellte Funktionalität und Ressourcen wie **[`PublicListing`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin-de-DE#publiclisting)** verwenden, um andere Personen zu schaden und auszunutzen; oder direkte kriminelle Aktivitäten wie das Starten von DDoS-Attacken auf dem Server ausführen. Da ASF eine starke Haltung zur allgemeinen Fairness, Ehrlichkeit und Zusammenarbeit zwischen seinen Nutzern einnimmt, um die gesamte Gemeinschaft zu unterstützen, ist diese Variable standardmäßig aktiviert und filtert Bots die wir von angebotenen Diensten als schädlich eingestuft haben. Sofern Sie keinen **triftigen** Grund haben, diese Variable zu bearbeiten, z. B. nicht mit unserer Erklärung einverstanden zu sein und diesen Bots absichtlich das Betreiben zu erlauben (einschließlich der Nutzung Ihrer Konten), sollten Sie diese standardmäßig beibehalten.

---

### `GiftsLimiterDelay`

Typ `byte` mit einem Standardwert `1`. ASF wird sicherstellen, dass mindestens `GiftsLimiterDelay` Sekunden zwischen zwei aufeinanderfolgenden Anfragen zur Handhabung (Einlösen) von Geschenken/Produktschlüsseln/Lizenzen liegen, um zu vermeiden, dass ein Anfragen-Limit ausgelöst wird. Darüber hinaus wird es auch als globale Beschränkung für Spiele-Listen-Anfragen verwendet, z. B. die vom `owns` **[Befehl](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-de-DE)**. Sofern Sie keinen **triftigen** Grund haben diese Variable zu bearbeiten, sollte der Standardwert belassen werden.

---

### `Headless`

Typ `bool` mit dem Standardwert `false`. Diese Variable legt fest, ob der Prozess im Headless-Modus laufen soll. Im Headless-Modus geht ASF davon aus, dass es auf einem Server oder in einer anderen nicht interaktiven Umgebung läuft, daher wird es nicht versuchen Informationen über die Konsolen-Eingabe zu lesen. Dazu gehören On-Demand-Details (Konto-Anmeldeinformationen wie 2FA-Code, SteamGuard-Code, Passwort oder jede andere Variable, die für den Betrieb von ASF erforderlich ist) sowie alle anderen Konsolen-Eingaben (z. B. interaktive Befehlskonsole). Mit anderen Worten: der `Headless` Modus ist gleichbedeutend mit der schreibgeschützten ASF-Konsole. Diese Einstellung ist vor allem für Benutzer nützlich die ASF auf Ihren Servern ausführen, da ASF, anstatt z. B. nach 2FA-Code zu fragen, den Vorgang stillschweigend abbricht, indem es ein Konto stoppt. Wenn Sie ASF nicht auf einem Server ausführen und vorher bestätigt haben, dass ASF im Nicht-Headless-Modus funktionieren kann, sollten Sie diese Variable deaktiviert lassen. Jegliche Benutzerinteraktion wird im Headless-Modus verweigert, und Ihre Konten werden nicht ausgeführt, sobald diese beim Start **irgendwelche** Konsolen-Eingaben erfordern. Dies ist für Server nützlich, da ASF den Versuch, sich am Konto anzumelden, wenn nach Anmeldeinformationen gefragt wird, abbrechen kann, anstatt (unendlich) darauf zu warten, dass der Benutzer diese bereitstellt. Wenn dieser Modus aktiviert ist, kann auch ein `input` **[Befehl](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-de-DE#kommandos)** verwendet werden, der als Ersatz für die standardmäßige Konsolen-Eingabe dient. Wenn Sie sich nicht sicher sind, wie Sie diese Variable einstellen sollen, belassen Sie diese bei dem Standardwert `false`.

Wenn Sie ASF auf dem Server verwenden, sollte diese Option zusammen mit dem `--process-required` **[Befehlszeilenargument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments-de-DE)** verwendet werden.

---

### `IdleFarmingPeriod`

Typ `byte` mit einem Standardwert `8`. Wenn ASF nichts zu sammeln hat, wird es regelmäßig alle `IdleFarmingPeriod` Stunden überprüfen, ob dem Konto vielleicht einige neue Spiele zum Sammeln zur Verfügung stehen. Dieses Feature ist nicht erforderlich, wenn es sich um neue Spiele handelt, die wir erhalten, da ASF intelligent genug ist, um in diesem Fall automatisch die Abzeichen-Seiten zu überprüfen. `IdleFarmingPeriod` ist hauptsächlich für Situationen wie alte Spiele gedacht, bei denen wir bereits Karten hinzugefügt haben. In diesem Fall gibt es kein Ereignis, weshalb ASF regelmäßig die Abzeichen-Seiten überprüfen muss, wenn wir dies berücksichtigen möchten. Der Wert von `0` deaktiviert dieses Feature. Überprüfen Sie auch die Einstellung `ShutdownOnFarmingFinished` in den `FarmingPreferences`.

---

### `InventoryLimiterDelay`

Typ `byte` mit einem Standardwert `4`. ASF wird sicherstellen, dass mindestens `InventoryLimiterDelay` Sekunden zwischen zwei aufeinanderfolgenden Inventar-Anfragen liegen, um ein Auslösen des Anfragelimits zu vermeiden – diese werden zum Abrufen von Steam-Inventaren verwendet, insbesondere während der von Ihnen selbst gewählten Befehle wie `loot`, oder `transfer`. Standardwert `4` wurde auf Basis des Abrufs von Inventare von über 100 aufeinanderfolgende Bot-Instanzen festgelegt, und sollte die meisten (wenn nicht alle) Benutzer zufrieden stellen. Sie können es aber auch verringern (oder gar auf `0` stellen), wenn Sie eine sehr geringe Anzahl von Bots haben; sodass ASF die Verzögerung ignoriert und die Steam-Inventare viel schneller plündert. Seien Sie jedoch gewarnt, dass das Setzen eines zu niedrigen Wertes **dazu führt**, dass Steam Ihre IP vorübergehend blockiert; und das wird Sie daran hindern, das Inventar überhaupt abzurufen. Sie müssen diesen Wert möglicherweise auch erhöhen, wenn Sie viele Bots mit vielen Inventar-Anfragen ausführen, obwohl Sie in diesem Fall wahrscheinlich versuchen sollten, die Anzahl dieser Anfragen zu begrenzen. Wenn Sie keinen **triftigen** Grund haben diese Variable zu bearbeiten, sollte der Standardwert belassen werden.

---

### `IPC`

Typ `bool` mit dem Standardwert `true`. Diese Variable definiert, ob der ASF-**[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-de-DE)**-Server zusammen mit dem Prozess gestartet werden soll. IPC ermöglicht die Kommunikation zwischen den Prozessen, einschließlich der Nutzung von **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-de-DE#asf-ui)** durch das Starten eines lokalen HTTP-Servers. Wenn Sie nicht beabsichtigen, eine externe IPC-Integration mit ASF zu verwenden, einschließlich unserer ASF-ui, können Sie diese Option problemlos deaktivieren. Ansonsten ist es eine gute Idee, diese Option aktiviert zu lassen (Standardoption).

---

### `IPCPassword`

Typ `string` mit einem Standardwert `null`. Diese Variable definiert das obligatorische Passwort für jeden API-Aufruf über die IPC-Schnittstelle und dient als zusätzliche Sicherheitsmaßnahme. Wenn auf einen nicht-leeren Wert gesetzt, benötigen alle IPC-Anfragen eine zusätzliche `password`-Variable, die auf das hier angegebene Passwort eingestellt ist. Der Standardwert `null` überspringt die Notwendigkeit des Passwortes, sodass ASF alle Anfragen akzeptiert. Darüber hinaus ermöglicht die Aktivierung dieser Option auch den eingebauten IPC-Anti-Bruteforce-Mechanismus, der die gegebene `IPAdress` vorübergehend blockiert, nachdem zu viele nicht autorisierte Anfragen in sehr kurzer Zeit gesendet wurden. Wenn Sie keinen Grund haben diese Variable zu bearbeiten, sollte der Standardwert belassen werden.

---

### `IPCPasswordFormat`

Typ `byte` mit einem Standardwert `0`. Diese Variable legt das Format der Variable `IPCPassword` fest und nutzt `EHashingMethod` als zugrunde liegenden Typ. Bitte lesen Sie den Abschnitt **[Sicherheit](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security-de-DE#sicherheit)**, für mehr Informationen, um sicherzustellen, dass die Variable `IPCPassword` tatsächlich ein Passwort im passenden `IPCPasswordFormat` enthält. Mit anderen Worten: wenn Sie `IPCPasswordFormat` ändern, dann sollte das `IPCPassword` **bereits** im richtigen Format sein und nicht nur darauf abzielen, lediglich zu existieren. Wenn Sie nicht wissen, was Sie tun, sollten der Standardwert bei `0` belassen werden.

---

### `LicenseID`

Typ `Guid?` mit dem Standardwert `null`. Diese Variable ermöglicht unseren **[Sponsoren](https://github.com/sponsors/JustArchi)** um ASF mit optionalen Funktionen zu verbessern, die bezahlte Ressourcen erfordern. Im Moment können Sie die Funktion **[`MatchActively`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin-de-DE#matchactively)** im `ItemsMatcher`-Plugin verwenden.

Während wir Ihnen empfehlen, GitHub zu verwenden, da es monatliche und einmalige Bezahloptionen bietet, sowie volle Automatisierung ermöglicht und Ihnen sofortigen Zugriff gewährt; unterstützen wir **auch** alle derzeit verfügbaren **[Spendenoptionen](https://github.com/JustArchiNET/ArchiSteamFarm#archisteamfarm)**. Weitere Informationen gibt es in **[in diesem Beitrag](https://github.com/JustArchiNET/ArchiSteamFarm/discussions/2780#discussioncomment-4486091)** (für Anweisungen, wie man mit anderen Methoden spenden kann, um eine manuelle Lizenz für einen bestimmten Zeitraum zu erhalten).

Unabhängig von der verwendeten Methode, können Sie als ASF Sponsor Ihre Lizenz **[hier](https://asf.justarchi.net/User/Status)** erwerben. Sie müssen sich bei GitHub anmelden, um Ihre Identität zu bestätigen. Wir fragen nur nach öffentlichen einsehbaren Informationen, also Ihrem Benutzernamen. `LicenseID` besteht aus 32 Hexadezimalzeichen, z. B. `f6a0529813f74d119982eb4fe43a9a24`.

**Stellen Sie sicher, dass Sie Ihre `LicenseID` nicht an andere Personen** teilen. Da es auf persönlicher Basis ausgegeben wird, könnte es widerrufen werden, wenn dieses durchgesickert. Wenn Ihnen dies zufällig passiert ist, können Sie eine neue von demselben Ort aus generieren.

Sofern Sie keine zusätzlichen ASF-Funktionen aktivieren möchten, ist es nicht erforderlich, dass Sie die Lizenz eingeben.

---

### `LoginLimiterDelay`

Typ `byte` mit einem Standardwert `10`. ASF stellt sicher, dass zwischen zwei aufeinanderfolgenden Verbindungsversuchen mindestens `LoginLimiterDelay` Sekunden liegen, um eine Auslösung des Anfrage-Limits zu vermeiden. Der Standardwert `10` wurde basierend auf der Verbindung von über 100 Bot-Instanzen festgelegt und sollte die meisten (wenn nicht alle) Benutzer zufrieden stellen. Sie können es aber auch verringern oder sogar zu `0` wechseln, wenn eine sehr geringe Anzahl von Bots eingerichtet sind, sodass ASF die Verzögerung ignoriert und sich viel schneller mit Steam verbindet. Aber seien Sie gewarnt, da das Setzen einer zu niedrigen Einstellung **garantiert** dazu führt, dass Steam Ihre IP vorübergehend sperrt, während zu viele Bots gleichzeitig benutzt werden. Das wird in einem `InvalidPassword/RateLimitExceeded`-Fehler resultieren und Sie **komplett** daran hindern, sich anzumelden. Das betrifft dann auch den normalen Steam-Client, nicht nur ASF. Gleichermaßen gilt, wenn Sie eine übermäßige Anzahl von Bots verwenden, insbesondere zusammen mit anderen Steam-Clients/Programmen, welche die gleiche IP-Adresse verwenden, muss dieser Wert höchstwahrscheinlich erhöht werden, um die Anmeldungen über einen längeren Zeitraum verteilen zu können.

Nebenbei bemerkt, wird dieser Wert auch als Load-Balancing-Puffer in allen ASF-geplanten Aktionen verwendet, z. B. Handelsangebote in `SendTradePeriod`. Wenn Sie keinen **triftigen** Grund haben diese Variable zu bearbeiten, sollte der Standardwert belassen werden.

---

### `MaxFarmingTime`

Typ `byte` mit einem Standardwert `10`. Wie Sie wissen sollten, funktioniert Steam nicht immer richtig. Manchmal können seltsame Situationen auftreten, z. B. dass unsere Spielzeit nicht aufzeichnet, obwohl tatsächlich ein Spiel gespielt wird. ASF erlaubt es, ein einzelnes Spiel im Einzelmodus für maximal `MaxFarmingTime` Stunden zu spielen und betrachtet es nach diesem Zeitraum als vollständig gesammelt. Dies ist erforderlich, um den Sammel-Prozess nicht einzufrieren, wenn es zu seltsamen Situationen kommt, aber auch, wenn Steam aus irgendeinem Grund ein neues Abzeichen veröffentlicht hat, das ASF daran hindern würde, weiter voranzukommen (siehe: `Blacklist`). Der Standardwert `10` Stunden sollte ausreichen, um alle Steam-Karten aus einem Spiel zu sammeln. Wenn Sie diese Variable zu niedrig einstellen, kann dies dazu führen, dass gültige Spiele übersprungen werden (und ja, es gibt gültige Spiele, die sogar bis zu 9 Stunden zum Sammeln benötigen), während eine zu hohe Einstellung dazu führen kann, dass der Sammel-Prozess eingefroren wird. Bitte beachten Sie, dass diese Variable nur ein einzelnes Spiel in einer einzigen Spiel-Sitzung betrifft (sodass ASF nach dem Durchlaufen der gesamten Warteschlange zu diesem Titel zurückkehrt), auch basiert sie nicht auf der Gesamtspielzeit, sondern auf der internen ASF-Sammel-Zeit, sodass ASF auch nach einem Neustart zu diesem Titel zurückkehrt. Wenn Sie keinen **triftigen** Grund haben diese Variable zu bearbeiten, sollte der Standardwert belassen werden.

---

### `MaxTradeHoldDuration`

Typ `byte` mit einem Standardwert `15`. Diese Variable definiert die maximale Dauer der Handelssperre in Tagen, die wir bereit sind zu akzeptieren – ASF lehnt Handelsangebote ab, die länger als `MaxTradeHoldDuration` Tage gehalten werden, wie im Abschnitt **[Handel](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading-de-DE#Handel)** definiert. Diese Option ist nur für Bots mit `TradingPreferences` von `SteamTradeMatcher` sinnvoll, da sie `Master` / `SteamOwnerID` Handelsangebote und keine Spenden betrifft. Handelssperren sind für alle ärgerlich, und niemand will sich wirklich mit Ihnen befassen. ASF soll nach liberalen Regeln arbeiten und jedem helfen, egal ob er sich in einer Handelssperre befindet oder nicht. Deshalb ist diese Option standardmäßig auf `15` gesetzt. Wenn Sie stattdessen lieber alle von Handelssperren betroffene Handelsangebote ablehnen möchten, können Sie hier `0` angeben. Bitte bedenken Sie, dass Karten mit kurzer Lebensdauer von dieser Option nicht betroffen sind und für Personen mit Handelssperren automatisch abgelehnt werden, wie im Abschnitt **[Handel](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading-de-DE#Handel)** erläutert, sodass es nicht notwendig ist, jeden nur deshalb global abzulehnen. Wenn Sie keinen Grund haben diese Variable zu bearbeiten, sollte der Standardwert belassen werden.


---

### `MinFarmingDelayAfterBlock`

Typ `byte` mit dem Standardwert `60`. Diese Variable bestimmt (die minimale Zeit in Sekunden), wie lange ASF mit dem Sammeln wartet, bis sollten Sie zuvor die Verbindung mit `LoggedInElsewhere` verliert; dies geschieht, sobald Sie sich dazu entscheiden ein Spiel zu starten und somit den Sammelprozess von ASF zwangsweise zu unterbrechen. Diese Verzögerung dient hauptsächlich der Bequemlichkeit und der Überlastungsprävention; etwa um das Spiel neu zu starten, ohne dass ASF (wegen einer kurzen Spielsperre) Ihr Konto blockiert. Aufgrund der Tatsache, dass das Zurückfordern der Sitzung `LoggedInElsewhere` die Verbindung unterbrochen hat, muss ASF das ganze Prozedere zur Verbindungswiederherstellung durchlaufen. Dies führt zu einer zusätzlichen Belastung des Geräts und des Steam-Netzwerks. Deshalb sollten weitere Trennungen möglichst vermieden werden. Standardmäßig ist dies bei `60` Sekunden konfiguriert, was ausreichen sollte, um das Spiel ohne große Schwierigkeiten neu zu starten. Es gibt jedoch Szenarien, bei denen Sie daran interessiert sein könnten, diesen Wert zu vergrößern (z. B. wenn Ihr Netzwerk oft trennt und ASF zu früh das Konto übernimmt, was dazu führt, dass Sie selbst den Wiederherstellungsprozess durchlaufen müssen). Wir erlauben einen maximalen Wert von `255` für diese Variable, was für alle gängigen Szenarien genügen sollte. Zusätzlich zu den oben genannten ist es auch möglich, die Verzögerung zu verringern, oder sogar komplett mit einem Wert `0`entfernen, obwohl dies in der Regel aus den oben genannten Gründen nicht empfohlen wird. Wenn Sie keinen Grund haben diese Variable zu bearbeiten, sollte der Standardwert belassen werden.

---

### `OptimizationMode`

Typ `byte` mit einem Standardwert `0`. Diese Variable definiert den Optimierungsmodus, den ASF während der Ausführung bevorzugt. Derzeit unterstützt ASF zwei Modi – `0`, der so genannte `MaxPerformance`, und `1`, der so genannte `MinMemoryUsage`. Standardmäßig bevorzugt ASF es, möglichst viele Aufgaben parallel auszuführen, was die Leistung durch Load-Balancing-Arbeiten (über alle CPU-Kerne, mehrere CPU-Threads, mehrere Sockel und mehrere Thread-Pool-Aufgaben hinweg) erhöht. Zum Beispiel fragt ASF nach Ihrer ersten Abzeichen-Seite, um nach Spiele zum Sammeln zu suchen. Sobald die Anfrage eingetroffen ist, überprüft ASF, wie viele Abzeichen-Seiten Sie tatsächlich haben, und fordert schließlich nacheinander an. Das ist es, was Sie eigentlich **fast immer** möchten, da der Aufwand in den meisten Fällen minimal ist und die Vorteile des asynchronen ASF-Codes auch auf der ältesten Hardware mit einem einzigen CPU-Kern und stark eingeschränkter Leistung sichtbar sind. Da jedoch viele Aufgaben parallel verarbeitet werden, ist die ASF-Laufzeit für Ihre Wartung verantwortlich, z. B. Sockets offen zu halten, Threads am Leben zu erhalten und Aufgaben zu bearbeiten, was gelegentlich zu einer erhöhten Speicherauslastung führen kann. Wenn der verfügbare Speicher häufig extrem eingeschränkt ist, sollten Sie diese Variable auf `1` (`MinMemoryUsage`) umschalten, um ASF zu zwingen, so wenig Aufgaben wie möglich auszuführen und typischerweise asynchronen (possible-to-parallel/ parallel ausführbarer) Code synchron zu verwenden. Sie sollten erwägen, diese Variable nur zu ändern, wenn Sie vorher mehr über das **[speichereffizientes Setup](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup-de-DE#speichereffizientes-setup)** gelesen haben und absichtlich gigantische Leistungssteigerung (für eine sehr kleine Verringerung des Speicher-Aufwands) opfern möchten. Normalerweise ist diese Option **viel schlechter** als das, was mit anderen Methoden möglich wäre (z. B. indem Sie eine ASF-Nutzung einschränken oder die Ausführung des Garbage Collector einstellen), wie fürs **[speichereffiziente Setup](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup-de-DE#speichereffizientes-setup)** erklärt. Daher sollte `MinMemoryUsage` als **letztes Mittel** verwendet werden, kurz vor der Neukompilierung der Laufzeitumgebung, wenn Sie mit anderweitigen (viel besseren) Optionen keine zufriedenstellende Ergebnisse erzielen können. Sofern Sie keinen **triftigen** Grund haben diese Variable zu bearbeiten, sollte der Standardwert unangetastet bleiben.

---

### `SteamMessagePrefix`

Typ `string` mit einem Standardwert `"/me "`. Diese Variable definiert ein Präfix, das allen Steam-Nachrichten, die von ASF gesendet werden, vorangestellt wird. Standardmäßig verwendet ASF das Präfix `"/me "`, um Bot-Nachrichten leichter zu unterscheiden, da sie im Steam-Chat in verschiedenen Farben angezeigt werden. Eine weitere erwähnenswerte Variable ist das Präfix `"/pre "`, das ein ähnliches Ergebnis mit einer anderen Formatierung erzielt. Sie können diese Variable auch auf eine leere Zeichenkette oder `null` setzen, um die Verwendung des Präfixes vollständig zu deaktivieren und alle Nachrichten von ASF auf traditionelle Weise auszugeben. Es ist gut zu wissen, dass diese Variable nur Steam-Nachrichten betrifft – Antworten, die über andere Kanäle (z. B. IPC) zurückgegeben werden, sind nicht betroffen. Wenn Sie das normale ASF-Verhalten nicht anpassen möchten, ist es eine gute Idee, es bei den Standardeinstellungen zu belassen.

---

### `SteamOwnerID`

Typ `ulong` mit einem Standardwert `0`. Diese Variable bestimmt die Steam-ID in 64-Bit-Form des ASF-Prozessinhabers und ist sehr ähnlich der Berechtigung `Master` einer gegebenen Bot-Instanz (aber stattdessen global). Für gewöhnlich tragen Sie hier fast immer auf die ID des eigenen (Haupt-) Steamkontos ein. Die Berechtigung `Master` beinhaltet die volle Kontrolle über seine Bot-Instanz, aber globale Befehle (wie `exit`, `restart` oder `update`) sind nur für `SteamOwnerID` verfügbar. Dies ist praktisch, da Sie vielleicht Bots für Freunde ausführen möchten, ohne ihnen zu erlauben, den ASF-Prozess zu steuern, z. B. das Beenden über den Befehl `exit`. Der Standardwert `0` gibt an, dass es keinen Besitzer des ASF-Prozesses gibt, was bedeutet, dass niemand in der Lage sein wird, globale ASF-Befehle auszuführen. Beachten Sie, dass diese Variable ausschließlich für Steam-Chat gilt. **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-de-DE)**, sowie die interaktive Konsole erlauben es Ihnen trotzdem `Owner`-Befehle auszuführen, auch wenn diese Variable nicht gesetzt ist.

---

### `SteamProtocols`

Typ `byte flags` mit einem Standardwert `7`. Diese Variable definiert Steam-Protokolle, welche ASF beim Verbinden mit Steam-Servern verwendet und wird wie folgt definiert:

| Wert | Name      | Beschreibung                                                                                     |
| ---- | --------- | ------------------------------------------------------------------------------------------------ |
| 0    | None      | Kein Protokoll                                                                                   |
| 1    | TCP       | **[Transmission Control Protocol](https://de.wikipedia.org/wiki/Transmission_Control_Protocol)** |
| 2    | UDP       | **[User Datagram Protocol](https://de.wikipedia.org/wiki/User_Datagram_Protocol)**               |
| 4    | WebSocket | **[WebSocket](https://de.wikipedia.org/wiki/WebSocket)**                                         |

Bitte bedenken Sie, dass diese Variable das Feld `flags` ist, daher ist es möglich, eine beliebige Kombination von verfügbaren Werten auszuwählen. Schlagen Sie gerne **[JSON-Strukturierung](#json-strukturierung)** nach, wenn Sie mehr erfahren möchten. Sofern keine der „Flags“ führt zur Option `None`, welche an sich bereits ungültig ist.

Standardmäßig verwendet ASF alle verfügbaren Steam-Protokolle als Maßnahme um Ausfälle und ähnliche Steam-Probleme möglichst zu vermeiden. Normalerweise möchten Sie diese Variable ändern, wenn Sie ASF darauf beschränken möchten, nur ein oder zwei bestimmte Protokolle zu verwenden. Eine solche Maßnahme könnte erforderlich sein, wenn Sie z. B. nur TCP-Datenverkehr auf einer Firewall erlauben, und verhindern möchten, dass ASF versucht, eine Verbindung über UDP herzustellen. Wenn Sie jedoch kein bestimmtes Problem debuggen, ist es aber immer in Ihrem Sinne, ASF die Nutzung aller Protokoll zu gestatten, die derzeit unterstützt werden, anstelle von nur ein oder zwei. Wenn Sie keinen **triftigen** Grund haben diese Variable zu bearbeiten, sollte der Standardwert belassen werden.

---

### `UpdateChannel`

Typ `byte` mit einem Standardwert `1`. Diese Variable definiert den Aktualisierungskanal, der entweder für automatische Aktualisierungen (wenn `UpdatePeriod` größer als `0` ist) oder (Alternativ) Aktualisierungsbenachrichtigungen verwendet wird. Derzeit unterstützt ASF drei Aktualisierungskanäle – diese werden als `None` (`0`), `Stable` (`1`), und `Experimental` (`2`) bezeichnet. Der Kanal `Stable` ist der standardmäßige Veröffentlichungskanal, der von der Mehrheit der Benutzer verwendet werden sollte. Der Kanal `experimental` beinhaltet zusätzlich zu `Stable` Veröffentlichungen, auch **Vorveröffentlichungen** für fortgeschrittene Benutzer/ andere Entwickler, um neue Funktionen zu testen, fehlerbehebungen zu bestätigen oder Rückmeldungen über geplante Verbesserungen abzugeben. **Experimentelle Versionen enthalten oft unbehobene Programmfehler, unfertige Funktionen oder neu geschriebene Implementierungen**. Wenn Sie sich nicht als fortgeschrittener Benutzer betrachten, bleiben Sie bitte beim Standard-Aktualisierungskanal `1` (`Stable`). Der Kanal `experimental` ist für Nutzer gedacht, die wissen, wie man Fehler meldet, Probleme löst und Rückmeldung gibt – es wird keine technische Unterstützung geboten. Sehen Sie sich den **[Veröffentlichungszyklus](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Release-cycle-de-DE#veröffentlichungszyklus)** von ASF an, um mehr darüber zu erfahren. Sie können auch den`UpdateChannel` auf `0` (`None`) setzen, wenn alle Versionsüberprüfungen vollständig deaktivieren werden sollen. Falls `UpdateChannel` auf `0` gesetzt ist, wird die gesamte Funktionalität im Zusammenhang mit Aktualisierungen vollständig deaktiviert, einschließlich des Befehls `update`. Es wird **ausdrücklich** von der Verwendung des `None`-Kanals **abgeraten**, weil Sie sich dadurch allen möglichen Probleme aussetzten (erwähnt in [`UpdatePeriod`](#UpdatePeriod) Beschreibung unten).

**Wenn Sie nicht wissen, was Sie tun**, empfehlen wir **ausdrücklich** es bei den Standardeinstellungen zu belassen.

---

### `UpdatePeriod`

Typ `byte` mit einem Standardwert `24`. Diese Variable legt fest, wie oft ASF nach automatischen Aktualisierungen suchen soll. Aktualisierungen sind nicht nur für den Erhalt neuer Funktionen und kritischer Sicherheitspatches entscheidend, sondern enthalten zudem Fehlerbehebungen, Leistungssteigerungen, Stabilitätsverbesserungen und mehr. Wenn ein Wert größer als `0` eingestellt ist, lädt ASF sich automatisch herunter, ersetzt und startet sich neu (wenn `AutoRestart` es erlaubt), sobald eine neue Aktualisierung verfügbar ist. Um dies zu erreichen, wird ASF alle `UpdatePeriod` Stunden überprüfen, ob eine neue Aktualisierung in unserem GitHub Repository verfügbar ist. Ein Wert von `0` deaktiviert automatische Aktualisierungen, ermöglicht es aber dennoch, den Befehl `update` manuell auszuführen. Sie könnten auch daran interessiert sein, den entsprechenden `UpdateChannel` einzustellen, dem `UpdatePeriod` folgen sollte.

Der Aktualisierungsprozess von ASF beinhaltet die Aktualisierung der gesamten Ordnerstruktur, die ASF verwendet, mit Aunsnahme der eigenen Konfigurationen (bzw. Datenbanken) im Verzeichnis `config` – das bedeutet, dass alle zusätzlichen Dateien, die nicht mit ASF in seinem Verzeichnis zusammenhängen, während des Aktualisierungsvorgangs verloren gehen können. Der Standardwert `24` ist ein guter Kompromiss zwischen unnötigen Prüfungen und einem aktuellen ASF.

Wenn Sie keinen **triftigen** Grund haben, diese Funktion zu deaktivieren, sollten Sie die automatischen Aktualisierungen innerhalb einer angemessenen Zeitspanne von `UpdatePeriod` **aus eigenem Sie Interesse aktiviert lassen**. Dies liegt nicht nur daran, dass wir ausschließlich die neueste stabile ASF-Version unterstützen, sondern auch, weil **wir unsere Sicherheitsgarantie nur für die neueste Version** geben. Wenn Sie eine veraltete ASF-Version verwenden, dann setzten Sie sich absichtlich allen möglichen Problemen aus- von kleinen Fehlern, über defekte Funktionen bis hin zu **[permanenten Steam-Kontosperren](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ-de-DE#wurde-jemand-daf%C3%BCr-gesperrt)**; also empfehlen wir **dringend**, um Ihren eigenen Vorteil immer sicherzustellen, dass die ASF-Version auf dem neuesten Stand ist. Automatische Aktualisierungen ermöglichen es uns, schnell auf alle möglichen Probleme zu reagieren, indem wir problematischen Quelltext deaktivieren oder beheben, bevor er eskalieren kann. Wenn Sie sich dagegen entscheiden, verlieren Sie sämtliche Sicherheitsgarantien und riskieren Konsequenzen durch das Ausführen von Code, der möglicherweise schädlich sein könnte (nicht nur für das Steam-Netzwerk, sondern auch -per Definition- für das eigene Steam-Konto).

---

### `WebLimiterDelay`

Typ `ushort` mit einem Standardwert `300`. Diese Variable definiert die minimale Verzögerung (in Millisekunden) zwischen dem Senden von zwei aufeinanderfolgenden Anfragen an denselben Steam-Webservice. Eine solche Verzögerung ist erforderlich, da der Dienst **[AkamaiGhost](https://www.akamai.com/de/de)**, den Steam intern nutzt, eine Geschwindigkeitsbegrenzung basierend auf der globalen Anzahl der über einen bestimmten Zeitraum gesendeten Anfragen beinhaltet. Unter normalen Umständen ist eine Blockierung des Akamai-Services ziemlich schwer zu erreichen, aber unter sehr hohen Arbeitslasten mit einer riesigen anhaltenden Warteschlange von Anfragen ist es möglich, diese auszulösen, wenn wir immer wieder zu viele Anfragen über einen zu kurzen Zeitraum senden.

Der Standardwert wurde unter der Annahme festgelegt, dass ASF das einzige Programm ist, das auf die Steam-Webdienste zugreift, insbesondere `steamcommunity.com`, `api.steampowered.com` und `store.steampowered.com`. Wenn Sie andere Programme verwenden, die Anfragen an dieselben Webservices senden, dann sollten Sie sicherstellen, dass das Programm ähnliche Funktionen wie `WebLimiterDelay` enthält und beide auf das Doppelte des Standardwerts setzen, was `600` wäre. Dies garantiert, dass unter keinen Umstand mehr als 1 Anfrage pro `300` ms gesendet wird.

Im Allgemeinen wird vom Herabsetzen des `WebLimiterDelay` unter den Standardwert **stark abgeraten**, da es zu verschiedenen IP-bezogenen Sperren führen kann, von denen einige dauerhaft sein können. Der Standardwert ist gut genug, um eine einzelne ASF-Instanz auf dem Server auszuführen und ASF im Normalfall zusammen mit dem ursprünglichen Steam-Client zu verwenden. Es sollte für die Mehrzahl an Verwendungen korrekt sein, und Sie sollten es nur erhöhen (nie senken). Kurz gesagt, die globale Anzahl aller Anfragen, die von einer einzelnen IP an eine einzelne Steam-Domäne gesendet werden, sollte nie 1 Anfrage pro `300` ms überschreiten.

Wenn Sie keinen Grund haben diese Variable zu bearbeiten, sollte der Standardwert belassen werden.

---

### `WebProxy`

Typ `string` mit einem Standardwert `null`. Diese Variable definiert eine Web-Proxy-Adresse, die für alle internen http/ https-Anfragen verwendet wird, die von ASFs `HttpClient` gesendet werden, insbesondere für Dienste wie `github.com`, `steamcommunity.com` und `store.steampowered.com`. Das Umleiten (über Proxy) von ASF-Anfragen im Allgemeinen hat keine Vorteile, aber es ist äußerst nützlich, um unterschiedlicher Weise von Firewalls zu umgehen, insbesondere die große Firewall von China.

Diese Variable ist als uri-Zeichenfolge definiert:

> Ein URI-String besteht aus einem Schema (unterstützt: http/https/socks4/socks4a/socks5), einem Host und einem optionalen Port. Ein Beispiel für eine komplette uri-Zeichenkette wäre `"http://contoso.com:8080"`.

Wenn ein Proxy eine Benutzer-Authentifizierung erfordert, müssen auch `WebProxyUsername` und/oder `WebProxyPassword` eingerichtet sein. Besteht dafür jedoch kein Bedarf, so genügt die alleinige Einrichtung dieser Variable.

Im Moment verwendet ASF den Web-Proxy nur für `http` und `https` Anfragen, was **nicht** die interne Steam-Netzwerk-Kommunikation innerhalb des internen Steam-Clients von ASF beinhaltet. Es gibt derzeit keine Pläne dies zu unterstützen, hauptsächlich wegen der fehlenden **[SK2](https://github.com/SteamRE/SteamKit/issues/587#issuecomment-413271550)**-Funktionalität. Wenn Sie es benötigen/ möchten, würde ich vorschlagen, von dort aus anzufangen.

Wenn Sie keinen Grund haben diese Variable zu bearbeiten, sollte der Standardwert belassen werden.

---

### `WebProxyPassword`

Typ `string` mit einem Standardwert `null`. Diese Variable definiert das Passwortfeld, das bei der Basis-, Digest-, NTLM- und Kerberos-Authentifizierung verwendet wird und von einem Ziel `WebProxy`-Rechner mit Proxy-Funktionalität unterstützt wird. Wenn der Proxy keine Benutzer-Anmeldeinformationen benötigt, ist es nicht notwendig, hier etwas einzutragen. Die Verwendung dieser Option ist nur sinnvoll, wenn auch `WebProxy` verwendet wird, da sie sonst keine Wirkung hat.

Wenn Sie keinen Grund haben diese Variable zu bearbeiten, sollte der Standardwert belassen werden.

---

### `WebProxyUsername`

Typ `string` mit einem Standardwert `null`. Diese Variable definiert das Feld (für den Benutzernamen), das bei der Basis-, Digest-, NTLM- und Kerberos-Authentifizierung verwendet wird und von einem `WebProxy`-Rechner (Ziel) mit Proxy-Funktionalität unterstützt wird. Wenn der Proxy keine Benutzer-Anmeldeinformationen benötigt, ist es nicht notwendig, hier etwas einzutragen. Die Verwendung dieser Option ist nur sinnvoll, wenn auch `WebProxy` verwendet wird, da sie sonst keine Wirkung hat.

Wenn Sie keinen Grund haben diese Variable zu bearbeiten, sollte der Standardwert belassen werden.

---

## Bot Konfiguration

Wie Sie bereits wissen, sollte jeder Bot eine eigene Konfiguration haben, die auf der folgenden beispielhaften JSON-Struktur basiert. Fangen wir damit an den Bot zu benennen (z. B. `1.json`, `main.json`, `haupt.json` oder `IrgendwasAnderes.json`), und beginnen Sie mit der Konfiguration.

**Hinweis:** Der Bot kann den Namen `ASF` nicht haben (da dieses Schlüsselwort für die globale Konfiguration reserviert ist), ASF ignoriert auch alle Konfigurationsdateien, die mit einem Punkt beginnen.

Die Bot-Konfiguration hat folgende Struktur:

```json
{
    "AcceptGifts": false,
    "BotBehaviour": 0,
    "CompleteTypesToSend": [],
    "CustomGamePlayedWhileFarming": null,
    "CustomGamePlayedWhileIdle": null,
    "Enabled": false,
    "FarmingOrders": [],
    "FarmingPreferences": 0,
    "GamesPlayedWhileIdle": [],
    "HoursUntilCardDrops": 3,
    "LootableTypes": [1, 3, 5],
    "MatchableTypes": [5],
    "OnlineFlags": 0,
    "OnlineStatus": 1,
    "PasswordFormat": 0,
    "RedeemingPreferences": 0,
    "RemoteCommunication": 3,
    "SendTradePeriod": 0,
    "SteamLogin": null,
    "SteamMasterClanID": 0,
    "SteamParentalCode": null,
    "SteamPassword": null,
    "SteamTradeToken": null,
    "SteamUserPermissions": {},
    "TradeCheckPeriod": 60,
    "TradingPreferences": 0,
    "TransferableTypes": [1, 3, 5],
    "UseLoginKeys": true,
    "UserInterfaceMode": 0
}
```

---

Alle Optionen werden nachfolgend erklärt:

### `AcceptGifts`

Typ `bool` mit dem Standardwert `false`. Wenn aktiviert, akzeptiert und löst ASF automatisch alle Steam-Geschenke (einschließlich Guthaben-Geschenkgutscheine), die an den Bot geschickt werden. Dazu gehören auch Geschenke, die von anderen Benutzern gesendet werden, die nicht in `SteamUserPermissions` definiert sind. Bedenken Sie, dass Geschenke, die an die E-Mail-Adresse geschickt werden, nicht direkt an den Client weitergeleitet werden, sodass ASF diese ohne Ihre Hilfe nicht annehmen wird.

Diese Option wird nur für Alternativkonten empfohlen, da es sehr wahrscheinlich ist, dass Sie nicht automatisch alle Geschenke einlösen möchten, die an das Hauptkonto gesendet werden. Wenn Sie sich nicht sicher sind, ob Sie diese Funktion aktivieren möchten oder nicht, belassen Sie bitte den Standardwert `false`.

---

### `BotBehaviour`

Typ `byte flags` mit dem Standardwert `0`. Diese Variable definiert das ASF-Bot-ähnliche Verhalten bei verschiedenen Ereignissen und ist wie folgt definiert:

| Wert | Name                          | Beschreibung                                                                                                          |
| ---- | ----------------------------- | --------------------------------------------------------------------------------------------------------------------- |
| 0    | None                          | Kein spezielles Bot-Verhalten, der am wenigsten invasive Modus (Standard)                                             |
| 1    | RejectInvalidFriendInvites    | Führt dazu, dass ASF ungültige Freundschaftseinladungen ablehnt (anstatt sie zu ignorieren)                           |
| 2    | RejectInvalidTrades           | Wird ASF dazu veranlassen, ungültige Handelsangebote abzulehnen (anstatt sie zu ignorieren)                           |
| 4    | RejectInvalidGroupInvites     | Führt dazu, dass ASF ungültige Gruppeneinladungen ablehnt (anstatt sie zu ignorieren)                                 |
| 8    | DismissInventoryNotifications | Veranlasst ASF dazu, alle Inventar-Benachrichtigungen automatisch zu entfernen                                        |
| 16   | MarkReceivedMessagesAsRead    | Führt dazu, dass ASF automatisch alle empfangenen Nachrichten als gelesen markiert                                    |
| 32   | MarkBotMessagesAsRead         | Bewirkt, dass ASF Nachrichten von anderen ASF-Bots automatisch als gelesen markiert (ausgeführt in derselben Instanz) |

Bitte bedenken Sie, dass diese Variable das Feld `flags` ist, daher ist es möglich, eine beliebige Kombination von verfügbaren Werten auszuwählen. Schlagen Sie gerne **[JSON-Strukturierung](#json-strukturierung)** nach, wenn Sie mehr erfahren möchten. Wenn keines der Flags aktiviert wird, wird die Option `None` verwendet.

Im Allgemeinen möchten Sie diese Eigenschaft ändern, wenn Sie von ASF erwarten, dass ein bestimmter Grad an Automatisierung im Zusammenhang mit dessen Aktivität durchführt, wie es von einem Bot-Konto erwartet (aber nicht von einem primären Konto) wird, wenn ASF auf diesen zugreift. Daher ist die Änderung dieser Variable vor allem für Alternativ-Konten sinnvoll, obwohl Sie ausgewählte Optionen auch für Hauptkonten verwenden können.

Das normale (`None`) ASF-Verhalten ist es, nur Dinge zu automatisieren, die der Benutzer wünscht (z. B. Karten sammeln oder `SteamTradeMatcher` Angebote bearbeiten, sofern in `TradingPreferences` eingestellt). Dies ist der am wenigsten eingreifende Modus, und es ist für die Mehrheit der Benutzer von Vorteil, da Sie damit die volle Kontrolle über Ihr Konto haben und selbst entscheiden, ob bestimmte Interaktionen außerhalb des Anwendungsbereichs zulässig sind oder nicht.

Eine ungültige Freundschaftseinladung ist eine Einladung, die nicht vom Benutzer mit `FamilySharing` Berechtigung (definiert in `SteamUserPermissions`) oder höher kommt. ASF ignoriert diese Einladungen im normalen Modus, wie Sie es erwarten würden, und gibt Ihnen die freie Wahl, ob Sie diese annehmen möchten. `RejectInvalidFriendInvites` führt dazu, dass diese Einladungen automatisch abgelehnt werden, was die Option für andere Personen, Sie zu Ihrer Freundesliste hinzuzufügen, praktisch deaktiviert (da ASF alle diese Anfragen ablehnt, mit Ausnahme der in `SteamUserPermissions` definierten Personen). Wenn Sie nicht alle Freundeseinladungen direkt ablehnen möchten, sollten Sie diese Option nicht aktivieren.

Ein ungültiges Handelsangebot ist ein Angebot, das nicht durch das eingebaute ASF-Modul angenommen wird. Mehr zu diesem Thema finden Sie im Abschnitt **[Handel](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading-de-DE)**, der explizit definiert, welche Arten von Handelsangeboten ASF bereit ist, automatisch zu akzeptieren. Gültige Handelsangebote werden auch durch andere Einstellungen definiert, insbesondere `TradingPreferences`. `RejectInvalidTrades` bewirkt, dass alle ungültigen Handelsangebote abgelehnt, anstatt ignoriert zu werden. Wenn Sie nicht alle Handelsangebote, die nicht automatisch von ASF angenommen werden, endgültig ablehnen möchten, sollten Sie diese Option nicht aktivieren.

Eine ungültige Gruppeneinladung ist eine Einladung, die nicht aus der Gruppe `SteamMasterClanID` stammt. ASF ignoriert im normalen Modus diese Gruppeneinladungen, wie Sie es erwarten würden, und erlaubt es Ihnen selbst zu entscheiden, ob Sie einer bestimmten Steam-Gruppe beitreten möchten. `RejectInvalidGroupInvites` führt dazu, dass alle diese Gruppeneinladungen automatisch abgelehnt werden, was es praktisch unmöglich macht, sich in irgendeine andere Gruppe als `SteamMasterClanID` einzuladen. Wenn Sie nicht alle Gruppeneinladungen direkt ablehnen möchten, sollten Sie diese Option nicht aktivieren.

`DismissInventoryNotifications` ist äußerst nützlich, wenn Sie sich an den Steam-Benachrichtigung über den Erhalt neuer Gegenstände stören. ASF kann die Benachrichtigung an sich nicht selbst löschen, da diese im Steam-Client integriert ist, aber es ist in der Lage, die Benachrichtigung nach Erhalt automatisch zu entfernen, was dazu führt, dass keine Benachrichtigung über „neue Gegenstände im Inventar“ mehr auftritt. Wenn Sie es bevorzugen alle erhaltenen Gegenstände selbst zu überprüfen (insbesondere Karten, die mit ASF gesammelt wurden), dann sollten Sie diese Option natürlich nicht aktivieren. Sollten Sie durch diese Einstellung unsicher sein – die Aktivierung ist optional.

`MarkReceivedMessagesAsRead` markiert automatisch **alle** Nachrichten, die von dem Konto empfangen werden (egal ob von Gruppen oder Privat), auf dem ASF läuft. Dies sollte typischerweise nur von alternativen Konten verwendet werden, um Benachrichtigungen über „neue Nachrichten“ zu löschen, die z. B. von Ihnen während der Ausführung von ASF-Befehlen erscheinen. Wir empfehlen diese Option nicht für Hauptkonten, es sei denn, Sie möchten sich von jeder Art von Benachrichtigungen über neue Nachrichten befreien, **einschließlich** derjenigen, die während des Offline-Betriebs erschienen sind, vorausgesetzt, dass ASF immer noch offen gelassen wurde, als es sie ablehnte.

`MarkBotMessagesAsRead` funktioniert in ähnlicher Weise, nur werden hier lediglich Bot-Nachrichten als gelesen markiert. Beachten Sie jedoch, dass die Steam-Implementierung **beim verwenden dieser Option** sowohl Gruppen-Chats mit den Bots und anderen Leuten bestätigt, **als auch alle vorherigen Nachrichten**. Wenn Sie also aus irgendeinem Grund keine unzusammenhängende Nachricht verpassen möchten, sollten Sie diese Funktion in der Regel vermeiden. Natürlich ist es ebenfalls riskant, wenn mehrere Primärkonten (z. B. von unterschiedlichen Nutzern) in derselben ASF-Instanz ausgeführt werden, besonders weil Sie die normalen Nachrichten (Steam-Benachrichtigungen abseits ASF) verpassen könnten.

Wenn Sie sich nicht sicher sind, wie Sie diese Option konfigurieren, können Sie den Standardwert belassen.

---

### `CompleteTypesToSend`

Typ `ImmutableHashSet<byte>` mit einem leeren Standardwert. Wenn ASF mit dem vervollständigen eines (hier zuvor) bestimmten Sets von Gegenstandstypen fertig ist, kann es automatisch mit allen fertigen Sets an den Benutzer mit Berechtigung `Master` senden. Das ist sehr praktisch, wenn Sie das angegebene Bot-Konto beispielsweise für einen STM-Abgleich verwenden möchten, während fertige Sets auf ein anderes Konto verschoben werden. Diese Option funktioniert genauso wie der `loot`-Befehl. Beachten Sie deshalb, dass Sie einen Benutzer mit der Berechtigung `Master` benötigen; vielleicht benötigen Sie außerdem einen gültigen `SteamTradeToken`, sowie ein Konto, das überhaupt zum Handel zugelassen ist.

Momentan werden folgende Gegenstandsarten in dieser Einstellung unterstützt:

| Wert | Name            | Beschreibung                                                                           |
| ---- | --------------- | -------------------------------------------------------------------------------------- |
| 3    | FoilTradingCard | Glanz-Variante von `TradingCard`                                                       |
| 5    | TradingCard     | Steam-Sammelkarte, die für die Herstellung von Abzeichen (ohne Glanz) verwendet werden |

Bitte bedenken Sie, dass ASF unabhängig von den obigen Einstellungen nur nach Steam **Community-Gegenständen[](https://steamcommunity.com/my/inventory/#753_6)** (`appID` von 753, `contextID` von 6)-Gegenständen fragt, sodass alle Spiel-Gegenstände /-Geschenke und dergleichen per Definition aus dem Handelsangebot ausgeschlossen sind.

Aufgrund der zusätzlichen Mehrbelastung durch Verwendung dieser Option wird es empfohlen, diese Einstellung nur auf Bot-Konten zu verwenden, die eine realistische Chance haben, Sets selbst zu beenden. Es ergibt beispielsweise keinen Sinn, diese Variable zu aktivieren, wenn bereits `SendOnFarmingFinished` in den `FarmingPreferences`, `SendTradePeriod` oder `loot` auf üblicher Basis verwendet wird.

Wenn Sie sich nicht sicher sind, wie Sie diese Option konfigurieren, können Sie den Standardwert belassen.

---

### `CustomGamePlayedWhileFarming`

Typ `string` mit einem Standardwert `null`. Wenn ASF sammelt, kann es sich als „Spielt ein Steam fremdes Spiel anzeigen: `CustomGamePlayedWhileFarming`“, anstatt des aktuellen Spiels welches gesammelt wird. Dies kann nützlich sein, wenn Sie Ihre Freunde darüber informieren möchten, dass Sie am Sammeln sind, aber den `OnlineStatus` nicht auf `Offline` ändern möchten. Bitte bedenken Sie, dass ASF die tatsächliche Anzeige-Reihenfolge des Steam-Netzwerks nicht garantieren kann, daher ist dies nur ein Vorschlag, der richtig angezeigt werden kann oder auch nicht. Insbesondere der benutzerdefinierte Name wird im `komplexen` Sammelalgorithmus nicht angezeigt, wenn ASF alle `32` Slots mit Spielen ausfüllt, die stundenlang bummeln müssen. Der Standardwert `null` deaktiviert dieses Feature.

ASF bietet einige spezielle Variablen, die Sie optional in Ihrem Text verwenden können. `{0}` wird durch die `AppID` des derzeit gesammelten Spiele(s) von ASF ersetzt, während `{1}` stattdessen den `GameName` verwendet.

---

### `CustomGamePlayedWhileIdle`

Typ `string` mit einem Standardwert `null`. Ähnlich wie `CustomGamePlayedWhileFarming`, aber für die Situation, in der ASF nichts zu tun hat (da das Konto vollständig gesammelt wurde). Bitte bedenken Sie, dass ASF die tatsächliche Anzeige-Reihenfolge des Steam-Netzwerks nicht garantieren kann, daher ist dies nur ein Vorschlag, der richtig angezeigt werden kann oder auch nicht. Wenn Sie `GamesPlayWhileIdle` zusammen mit dieser Option verwenden, bedenken Sie, dass `GamesPlayWhileIdle` Priorität erhält, daher können Sie nicht mehr als `31` von ihnen angeben, da sonst `CustomGamePlayedWhileIdle` nicht in der Lage sein wird, den Slot für den benutzerdefinierten Namen zu besetzen. Der Standardwert `null` deaktiviert dieses Feature.

---

### `Enabled`

Typ `bool` mit dem Standardwert `false`. Diese Variable definiert, ob der Bot aktiviert ist. Eine aktivierte Bot-Instanz (`true`) wird automatisch zusammen mit ASF gestartet, während eine deaktivierte Bot-Instanz (`false`) manuell gestartet werden muss. Standardmäßig ist jeder Bot deaktiviert, sodass Sie diese Variable wahrscheinlich auf `true` für alle Bots umschalten möchten, die automatisch gestartet werden sollen.

---

### `FarmingOrders`

Typ `ImmutableList<byte>` mit einem leeren Standardwert. Diese Eigenschaft definiert die **bevorzugte** Sammelreihenfolge für ein gegebenes Bot-Konto, welche ASF verwendet. Derzeit sind folgende Sammelreihenfolgen verfügbar:

| Wert | Name                      | Beschreibung                                                                                                            |
| ---- | ------------------------- | ----------------------------------------------------------------------------------------------------------------------- |
| 0    | Unordered                 | Keine Sortierung, leichte Verbesserung der CPU-Leistung                                                                 |
| 1    | AppIDsAscending           | Versuche Spiele mit den niedrigsten `AppIDs` zuerst zu sammeln                                                          |
| 2    | AppIDsDescending          | Versuche Spiele mit den höchsten `AppIDs` zuerst zu sammeln                                                             |
| 3    | CardDropsAscending        | Versuchen Sie Spiele mit der niedrigsten Anzahl an verbleibenden Karten zuerst zu sammeln                               |
| 4    | CardDropsDescending       | Versuchen Sie Spiele mit der höchsten Anzahl an verbleibenden Karten zuerst zu sammeln                                  |
| 5    | HoursAscending            | Versuche Spiele mit der niedrigsten Anzahl an gespielten Stunden zuerst zu sammeln                                      |
| 6    | HoursDescending           | Versuche Spiele mit der höchsten Anzahl an gespielten Stunden zuerst zu sammeln                                         |
| 7    | NamesAscending            | Versuche Spiele in alphabetischer Reihenfolge zu sammeln, beginnend mit A                                               |
| 8    | NamesDescending           | Versuche Spiele in umgekehrter alphabetischer Reihenfolge zu sammeln, beginnend mit Z                                   |
| 9    | Random                    | Versuche Spiele in einer komplett zufälligen Reihenfolge zu sammeln (unterschiedlich bei jedem ausführen des Programms) |
| 10   | BadgeLevelsAscending      | Versuche Spiele mit dem niedrigsten Abzeichen-Level zuerst zu sammeln                                                   |
| 11   | BadgeLevelsDescending     | Versuche Spiele mit dem höchsten Abzeichen-Level zuerst zu sammeln                                                      |
| 12   | RedeemDateTimesAscending  | Versuche die ältenen Spiele auf unserem Konto zuerst zu sammeln                                                         |
| 13   | RedeemDateTimesDescending | Versuche die neuesten Spiele auf unserem Konto zuerst zu sammeln                                                        |
| 14   | MarketableAscending       | Versuche Spiele mit nicht marktfähigen Karten zuerst zu sammeln                                                         |
| 15   | MarketableDescending      | Versuche Spiele mit marktfähigen Karten zuerst zu sammeln                                                               |

Da es sich bei dieser Variable um ein Array (Anordnung) (Anordnung) handelt, können mehrere verschiedene Einstellungen in einer festen Reihenfolge kombiniert werden. Beispielsweise indem Sie Werte von `15`, `11` und `7` einbeziehen; um zuerst nach marktfähigen Spielen, dann nach denen mit dem höchsten Abzeichen-Level, und schließlich alphabetisch zu sortieren. Wie Sie erraten können, dass Ihr die Reihenfolge ist tatsächlich entscheidend; umgekehrt (`7`, `11` und `15`) erzielt ein komplett anderes Ergebnis. Wenn zuerst Spiele alphabetisch sortiert werden, dann macht dies die anderen beiden praktisch nutzlos (Spielnamen sind einzigartig). Die Mehrheit der Benutzer wird wahrscheinlich nur eine Reihenfolge aus den Möglichen wählen, aber falls gewünscht, können Sie auch weiter nach zusätzlichen Parametern sortieren.

Beachten Sie, dass das Wort „versuchen“ in allen obigen Beschreibungen vorkommt – die tatsächliche ASF-Reihenfolge wird stark vom ausgewählten **[Sammelkarten-Algorithmus](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance-de-DE)** beeinflusst und die Sortierung wirkt sich nur auf Ergebnisse aus, die ASF leistungsmäßig als gleichrangig betrachtet. Beispielsweise ist beim Algorithmus `Simple` die ausgewählte `FarmingOrders` in der aktuellen Sammel-Sitzung vollständig zu berücksichtigen, da jedes Spiel den gleichen Leistungswert hat; während der Algorythmus `Complex` die tatsächliche Reihenfolge zuerst nach Stunden beeinflusst und erst dann nach der gewählten `FarmingOrders` sortiert. Dies führt zu unterschiedlichen Ergebnissen, da Spiele mit vorhandener Spielzeit eine Priorität gegenüber anderen haben, sodass ASF effektiv Spiele bevorzugt, die bereits die erforderlichen `HoursUntilCardDrops` durchlaufen haben. Erst dann werden diese Spiele nach der gewählten `FarmingOrders` weiter sortiert. Genauso wenn ASF keine bereits angestoßenen Spiele mehr hat, wird die verbleibende Warteschlange zuerst nach Stunden sortiert (da dies die Zeit, die für das Anstoßen eines der verbleibenden Titel benötigt wird, auf `HoursUntilCardDrops` verringert). Daher ist diese Konfigurationseigenschaft nur eine **Empfehlung**, die ASF zu respektieren versucht, solange dies die Leistung nicht negativ beeinflusst (in diesem Fall wird ASF immer die Sammel-Leistung gegenüber `FarmingOrders` bevorzugen).

Es gibt auch eine priorisierte Sammel-Warteschlange, die über die `iq` **[Befehle](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-de-De)** erreichbar ist. Wenn es verwendet wird, wird die tatsächliche Sammel-Reihenfolge zuerst nach Leistung, dann nach Sammel-Warteschlange und schließlich nach der eingestellten `FarmingOrders` sortiert.

---

### `FarmingPreferences`

Typ `byte flags` mit dem Standardwert `0`. Diese Variable definiert das ASF-Sammelverhalten und ist wie folgt definiert:

| Wert | Name                      |
| ---- | ------------------------- |
| 0    | None                      |
| 1    | FarmingPausedByDefault    |
| 2    | ShutdownOnFarmingFinished |
| 4    | SendOnFarmingFinished     |
| 8    | FarmPriorityQueueOnly     |
| 16   | SkipRefundableGames       |
| 32   | SkipUnplayedGames         |
| 64   | EnableRiskyCardsDiscovery |
| 128  | AutoSteamSaleEvent        |

Bitte bedenken Sie, dass diese Variable ein Feld `flags` ist, daher ist es möglich, eine beliebige Kombination von verfügbaren Werten auszuwählen. Schlagen Sie gerne **[JSON-Strukturierung](#json-strukturierung)** nach, wenn Sie mehr erfahren möchten. Wenn keines der Flags aktiviert wird, wird die Option `None` verwendet.

Alle Optionen sind unten beschrieben.

`FarmingPausedByDefault` definiert den Ausgangszustand des Moduls `CardsFarmer`. Normalerweise startet der Bot automatisch das Sammeln, sobald er (entweder wegen `Enabled` oder dem Befehl `start`) gestartet wird. Die Anwendung von `FarmingPausedByDefault` sollte nur dann erfolgen, wenn Sie manuell den `resume`-Befehl verwenden möchten, um den automatischen Sammel-Prozess fortzusetzen, z. B. weil Sie häufig `play` nutzen und niemals automatisch das Modul `CardsFarmer` verwenden möchten. Das funktioniert genau wie der `pause` **[Befehl](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-de-DE)**.

`ShutdownOnFarmingFinished` ermöglicht es Ihnen, den Bot herunterzufahren, sobald der Sammelprozess abgeschlossen ist. Normalerweise ASF „belegt“ ein Konto für die gesamte Zeit des aktiven Prozesses. Wenn ein Konto mit dem Sammeln fertig ist, überprüft ASF regelmäßig (jede `IdleFarmingPeriode` Stunden), ob in der Zwischenzeit vielleicht einige neue Spiele mit Steam-Karten hinzugefügt wurden, damit es das Sammeln dieses Kontos fortsetzen kann, ohne den Prozess neu starten zu müssen. Dies ist für die Mehrheit der Menschen nützlich, da ASF bei Bedarf automatisch das Sammeln wieder aufnehmen kann. Jedoch könnten Sie den Prozess tatsächlich stoppen wollen, wenn das angegebene Konto vollständig gesammelt wurde. Sie können das erreichen, indem Sie diese Variable verwenden. Wenn aktiviert, fährt ASF mit der Abmeldung fort, wenn das Konto vollständig gesammelt ist, was bedeutet, dass es nicht mehr regelmäßig überprüft oder belegt wird. Sie sollten selbst entscheiden, ob ASF die ganze Zeit an einer bestimmten Bot-Instanz arbeitet, oder sogar stoppen sollte, wenn der Sammelprozess abgeschlossen ist. Wenn alle Konten gestoppt sind und der Prozess nicht im **[Modus](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-Line-Arguments-de-DE)** `--process-required` läuft, wird ASF auch heruntergefahren, wodurch Ihre Maschine in den Ruhemodus geht und Sie andere Aktionen planen können (etwa ein Standby-Modus oder Herunterfahren), sobald die letzte Karte gesammelt wurde.

`SendOnFarmingFinished ` erlaubt es Ihnen, automatisch ein Steam-Handelsangebot mit allem, was bis zu diesem Punkt gesammelt wurde, an den Benutzer mit der Berechtigung `Master` zu senden. Dies ist sehr praktisch, falls Sie sich nicht selbst mit den Handelsangeboten beschäftigen möchten. Diese Option funktioniert genauso wie der `loot`-Befehl. Beachten Sie deshalb, dass Sie einen Benutzer mit der Berechtigung `Master` benötigen; möglicherweise benötigen Sie zusätzlich einen gültigen `SteamTradeToken`, sowie ein Konto, das überhaupt zum Handel zugelassen ist. Zusätzlich zum Einleiten von `loot` nach Beendigung des Sammelns initiiert ASF auch `loot` bei jeder Benachrichtigung über neue Gegenstände (wenn nicht am Sammeln) und nach Abschluss jedes Handelsangebotes, der zu neuen Gegenständen führt (immer), wenn diese Option aktiv ist. Dies ist besonders nützlich, um erhaltene Gegenstände von anderen Personen an unser Konto „weiterzuleiten“. Normalerweise sollten Sie **[ASF-2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication-de-DE)** zusammen mit dieser Funktion verwenden; obwohl es keine Voraussetzung ist, wenn Sie beabsichtigen, die 2FA Bestätigung manuell und rechtzeitig durchzuführen.

`FarmPriorityQueueOnly` legt fest, ob ASF für das automatische Sammeln nur Anwendungen berücksichtigen soll, die Sie selbst mit `iq`-**[Befehlen](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-de-DE)** zur priorisierten Sammel-Warteschlange hinzugefügt haben. Wenn diese Option aktiviert ist, überspringt ASF alle `appIDs`, die auf der Liste fehlen, was es effektiv ermöglicht, Spiele für das automatische ASF-Sammeln gezielt auszuwählen. Bedenken Sie, dass ASF für das Konto untätig bleibt, solange Sie keine Spiele zur Warteschlange hinzugefügen.

`SkipRefundableGames` legt fest, ob ASF Spiele überspringen soll, die ohne den Sammelprozess noch erstattet werden können. Rückerstattungsfähige Spiele sind jene, die Sie gemäß den **[Steam-Rückerstattungsrichtlinien](https://store.steampowered.com/steam_refunds)** in den vergangenen 2 Wochen über den Steam-Shop gekauft und welches Sie (bzw.ASF) bislang nicht länger als 2 Stunden gespielt haben. Standardmäßig ignoriert ASF die Steam-Erstattungsrichtlinie vollständig und sammelt alles, was die meisten Anwender erwarten. Sie können diese Option jedoch verwenden, wenn Sie sicherstellen möchten, dass ASF keines Ihrer erstattungsfähigen Spiele zu früh sammelt, sodass Sie diese Spiele selbst bewerten und bei Bedarf zurückerstatten können, ohne Sorge, dass ASF die Spielzeit negativ beeinflusst. Wenn Sie diese Option aktivieren, werden Spiele, welche Sie im Steam-Shop gekauft haben, bis zu 14 Tage nach dem Einlösedatum von ASF ignoriert, da diese als nicht sammelbar angezeigt werden, wenn das Konto nichts anderes besitzt.

`SkipUnplayedGames` legt fest, ob ASF Spiele überspringen soll, die Sie bislang nicht gestartet haben. »Ungespieltes Spiel« bedeutet in diesem Kontext, dass keine Spielzeit für dieses Spiel auf Steam aufgezeichnet wurde. Wenn Sie diesen Schalter verwenden, werden diese Spiele übersprungen, bis Steam eine beliebige Spielzeit registriert. Dies gibt Ihnen eine bessere Kontrolle darüber, welche Spiele ASF sammeln darf, und überspringt jene, die Sie bislang nicht ausprobieren konnten, womit ausgewählte Steam-Funktionen nützlicher bleiben – etwa ungespielte Spiele zum Spielen vorzuschlagen.

`EnableRiskyCardsDiscovery` aktiviert ein zusätzliches Reservesystem, das auslöst, sobald ASF nicht in der Lage ist, eine oder mehrere Abzeichenseiten zu laden und daher keine für das Sammeln verfügbare Spiele zu findet. Insbesondere Konten mit einer gewaltigen Anzahl an Kartenfunden führen mitunter dazu, dass das Laden von Abzeichenseiten (aufgrund der Überlastung) nicht mehr möglich ist, und diese Konten unmöglich Sammeln können, einfach weil es uns nicht möglich ist auf die Informationen (auf deren Grundlage wir den Prozess beginnen) zuzugreifen. In solchen Situationen erlaubt diese Option die Verwendung eines alternativen Algorithmus; es wird (in Kombination mit herstellbaren Booster-Packs, und dem Konto zur Verfügung stehenden Booster-Packs) nach potenziell verfügbaren Spielen zum Sammeln gesucht. Anschließend eine übermäßige Menge an Ressourcen für die Überprüfung und das Abrufen der benötigten Informationen aufgewendet; schließlich versucht der oben genannte Algorythmus, den Sammelprozess auf Basis der begrenzten Datenmenge und Informationen zu starten, um schließlich einen Zustand zu erreichen, an dem die Abzeichenseite lädt und wir in der Lage sind, den normalen Ansatz zu verwenden. Bitte beachten Sie, dass ASF bei Verwendung dieses Reservesystems nur mit beschränkten Daten arbeitet. Daher ist es völlig normal, dass ASF viel weniger Erträge findet als in der Realität – andere Funde werden zu einem späteren Zeitpunkt während des Sammelprozesses gefunden werden.

Diese Option wird aus einem sehr guten Grund als „riskant“ bezeichnet – sie ist extrem langsam und erfordert eine beträchtliche Menge an Ressourcen (einschließlich Netzwerkanfragen) für den Betrieb. Es ist daher **nicht empfohlen** dies zu aktivieren, und besonders langfristig. Sie sollten diese Option nur verwenden, wenn Sie zuvor festgestellt haben, dass Ihr Konto nicht in der Lage ist, Abzeichen-Seiten zu laden, sodass es ASF nie gelingt (notwendige Informationen zu laden) den Prozess zu starten. Auch wenn wir unser Bestes gegeben haben, um den Prozess so weit wie möglich zu optimieren; es ist immer noch möglich, dass diese Option nach zurückschlägt. Es kann zu unerwünschten Ergebnissen führen, wie temporäre oder vielleicht sogar permanente Sperren seitens Steam; aufgrund zu vieler Anfragen und einer möglichen Überlastung der Steam-Server. Deshalb warnen wir Sie im Voraus und bieten diese Option ohne jegliche Garantie. Die Nutzung erfolgt auf eigene Gefahr.

`AutoSteamSaleEvent` erlaubt Ihnen während des Steam-Sommer/Winter-Sale-Events täglich zusätzliche Karten aus der Entdeckungsliste zu beziehen. Wenn diese Option aktiviert ist, überprüft ASF automatisch die Steam Entdeckungsliste alle `8` Stunden (beginnend bei einer Stunde seit Programmstart) und durchläuft sie bei Bedarf. Diese Option wird nicht empfohlen, wenn Sie diese Aktion selbst durchführen möchten, und normalerweise ist dies nur bei Bot-Konten sinnvoll. Bitte bedenken Sie, dass wir aufgrund von ständigen Problemen, Änderungen und Fehler durch Valve **keine Garantie geben, ob diese Funktion ordnungsgemäß funktioniert**. Daher ist es durchaus möglich, dass diese Option **überhaupt nicht funktioniert**. Wir akzeptieren **keine** Fehlermeldungen, geschweige denn Unterstützungsanfragen für diese Option. Es wird ohne jegliche Garantie angeboten, die Nutzung erfolgt auf eigene Gefahr.

---

### `GamesPlayedWhileIdle`

Typ `ImmutableHashSet<uint>` mit einem leeren Standardwert. Wenn ASF nichts zu sammeln hat, kann es stattdessen Ihre angegebenen Steam-Spiele (`AppIDs`) spielen. Das Spielen von Spielen auf diese Weise erhöht lediglich die „gesamte Spielzeit“ dieser Spiele. Damit diese Funktion richtig funktioniert, **muss** das Steam-Konto eine gültige Lizenz für alle `AppIDs` besitzen, die Sie angegeben haben; dies schließt auch F2P-Spiele mit ein. Dieses Feature kann gleichzeitig mit `CustomGamePlayedWhileIdle` aktiviert werden, um die ausgewählten Spiele zu spielen, während der benutzerdefinierte Status im Steam-Netzwerk angezeigt wird. In diesem Fall, wie in `CustomGamePlayedWhileFarming`, ist die tatsächliche Anzeige-Reihenfolge jedoch nicht garantiert. Bitte beachten Sie, dass Steam insgesamt ASF nur bis zu `32` `AppIDs` insgesamt spielen lässt, daher können nur so viele Spiele in diese Variable eingetragen werden.

---

### `HoursUntilCardDrops`

Typ `byte` mit einem Standardwert `3`. Diese Eigenschaft legt fest, ob das Konto eingeschränkt ist (und falls ja, für wie viele Anfangsstunden). Eingeschränkte Kartefunde bedeuten, dass das Konto keine Karten von einem bestimmten Spiel erhält, bis das Spiel mindestens `HoursUntilCardDrops` Stunden lang gespielt wurde. Leider gibt es keinen magischen Weg, das zu erkennen, also verlässt sich ASF auf Sie. Diese Variable wirkt sich auf den **[Karten-Sammel-Algorithmus](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance-de-DE)** aus, der verwendet wird. Wenn diese Variable richtig eingestellt ist, wird der Gewinn maximiert und die benötigte Zeit für die Abarbeitung der Karten minimiert. Bedenken Sie, dass es keine offensichtliche Antwort gibt, welchen Wert Sie verwenden sollten, da es völlig vom entsprechenden Konto abhängt. Es scheint, dass ältere Konten, die nie um Rückerstattung gebeten haben, unbeschränkte Kartenfunde haben. Folglich sollten Sie einen Wert von `0` verwenden; während neue Konten und diejenigen, die um Rückerstattung gebeten haben, beschränkte Kartenfunde mit einem Wert von `3` haben. Dies ist jedoch nur eine Theorie und sollte nicht als Tatsache betrachtet werden. Der Standardwert für diese Variable wurde basierend auf dem „kleineren Übel“ und der Mehrheit der Anwendungsfälle festgelegt.

---

### `LootableTypes`

Typ `ImmutableHashSet<byte>` mit dem Standardwert `1, 3, 5` als Steam-Gegenstandstyp. Diese Eigenschaft definiert das ASF-Verhalten beim Plündern – sowohl manuell, durch Verwendung eines **[Befehls](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-de-DE#kommandos)**, als auch automatisch über eine oder mehrere Konfigurationseigenschaften. ASF wird sicherstellen, dass nur Gegenstände von `LootableTypes` in ein Handelsangebot aufgenommen werden, daher können Sie mit dieser Variable wählen, was Sie in einem Handelsangebot erhalten möchten, das an Sie gesendet wird.

| Wert | Name                  | Beschreibung                                                                                  |
| ---- | --------------------- | --------------------------------------------------------------------------------------------- |
| 0    | Unknown               | Jeder Typ, der nicht in eine der folgenden Kategorien passt                                   |
| 1    | BoosterPack           | Booster Pack mit 3 zufälligen Karten aus einem Spiel                                          |
| 2    | Emoticon              | Emoticon zur Verwendung im Steam-Chat                                                         |
| 3    | FoilTradingCard       | Folienvariante von `TradingCard`                                                              |
| 4    | ProfileBackground     | Profilhintergrund zur Verwendung im Steam-Profil                                              |
| 5    | TradingCard           | Steam-Karte, die für die Herstellung von Abzeichen (Nicht-Folie) verwendet werden             |
| 6    | SteamGems             | Steam-Edelsteine, die für die Herstellung von Booster Packs verwendet werden, inklusive Säcke |
| 7    | SaleItem              | Spezialgegenstände, die während des Steam-Sales vergeben werden                               |
| 8    | Consumable            | Spezielle Verbrauchsgegenstände, die nach dem Gebrauch wieder verschwinden                    |
| 9    | ProfileModifier       | Spezialgegenstände, welche das Aussehen des Steam-Profils verändern können                    |
| 10   | Sticker               | Spezialgegenstände, welche im Steam-Chat verwendet werden                                     |
| 11   | ChatEffect            | Spezialgegenstände, welche im Steam-Chat verwendet werden                                     |
| 12   | MiniProfilhintergrund | Besonderer Hintergrund für das Steam-Profil                                                   |
| 13   | AvatarProfileFrame    | Besonderer Avatarrahmen für das Steam-Profil                                                  |
| 14   | AnimatedAvatar        | Besonders animierter Avatar für das Steam-Profil                                              |
| 15   | KeyboardSkin          | Spezieller Tastatur-Skin für das Steam Deck                                                   |
| 16   | StartupVideo          | Spezielles Start-Video für das Steam Deck                                                     |

Bitte bedenken Sie, dass ASF unabhängig von den obigen Einstellungen nur nach Steam **Community-Gegenständen[](https://steamcommunity.com/my/inventory/#753_6)** (`appID` von 753, `contextID` von 6)-Gegenständen fragt, sodass alle Spiel-Gegenstände /-Geschenke und dergleichen per Definition aus dem Handelsangebot ausgeschlossen sind.

Die Standard-ASF-Einstellung basiert auf der gebräuchlichsten Verwendung des Bots, wobei nur Boosterpacks und handelbare Sammelkarten (einschließlich Glanzkarten) geöffnet werden. Die hier definierte Variable ermöglicht es Ihnen, dieses Verhalten so zu verändern, dass es Sie zufrieden stellt. Bitte bedenken Sie, dass alle nicht oben definierten Typen als `Unknown` angezeigt werden, was besonders wichtig ist, wenn Valve einen neuen Steam-Gegenstand veröffentlicht, der ebenfalls von ASF als `Unknown` markiert wird, bis er hier (in einer zukünftigen Version) hinzugefügt wird. Deshalb ist es im Allgemeinen nicht empfehlenswert, `Unknown` in Ihren `LootableTypes` einzugeben, es sei denn, Sie wissen genau, was Sie tun und verstehen auch, dass ASF das gesamtes Inventar in einem Handelsangebot versenden wird, wenn das Steam-Netzwerk wieder unterbrochen wird und alle Ihre Gegenstände als `Unknown` meldet. Mein nachdrücklicher Vorschlag ist, `Unknown` nicht in das Feld `LootableTypes` einzutragen, selbst wenn Sie alles übertragen möchten.

---

### `MatchableTypes`

Typ `ImmutableHashSet<byte>` mit dem Standardwert `5` als Steam-Gegenstandstyp. Diese Variable definiert, welche Steam Gegenstandstypen zusammengestellt werden dürfen, wenn die Option `SteamTradeMatcher` in `TradingPreferences` aktiviert ist. Die Arten sind wie folgt definiert:

| Wert | Name                  | Beschreibung                                                                                           |
| ---- | --------------------- | ------------------------------------------------------------------------------------------------------ |
| 0    | Unknown               | Jeder Typ, der nicht in eine der folgenden Kategorien passt                                            |
| 1    | BoosterPack           | Booster Pack mit 3 zufälligen Karten aus einem Spiel                                                   |
| 2    | Emoticon              | Emoticon zur Verwendung im Steam-Chat                                                                  |
| 3    | FoilTradingCard       | Glanz-Variante von `TradingCard`                                                                       |
| 4    | ProfileBackground     | Profilhintergrund zur Verwendung im Steam-Profil                                                       |
| 5    | TradingCard           | Steam-Sammel-Karte, die für die Herstellung von Abzeichen (Nicht-Glanz) verwendet werden               |
| 6    | SteamGems             | Steam-Edelsteine, die für die Herstellung von Booster Packs verwendet werden, inklusive Edelsteinsäcke |
| 7    | SaleItem              | Spezialgegenstände, die während des Steam-Sales vergeben werden                                        |
| 8    | Consumable            | Spezielle Verbrauchsgegenstände, die nach dem Gebrauch wieder verschwinden                             |
| 9    | ProfileModifier       | Spezialgegenstände, welche das Aussehen des Steam-Profils verändern können                             |
| 10   | Aufkleber             | Spezialgegenstände, welche im Steam-Chat verwendet werden können                                       |
| 11   | ChatEffect            | Spezialgegenstände, welche im Steam-Chat verwendet werden können                                       |
| 12   | MiniProfilhintergrund | Besonderer Hintergrund für Steam Profile                                                               |
| 13   | AvatarProfileFrame    | Besonderer Avatarrahmen für das Steam-Profil                                                           |
| 14   | AnimatedAvatar        | Besonders animierter Avatar für das Steam-Profil                                                       |
| 15   | KeyboardSkin          | Spezieller Tastatur-Skin für das Steam Deck                                                            |
| 16   | StartupVideo          | Spezielle Start-Animation für das Steam Deck                                                           |

Natürlich beinhalten die Typen, die Sie für diese Variable verwenden sollten, typischerweise nur `2`, `3`, `4` und `5`, da nur diese Typen von STM unterstützt werden. ASF beinhaltet die passende Logik, um die Seltenheit der Gegenstände zu ermitteln, daher ist es auch sicher, Emoticons oder Hintergründe zu vergleichen, da ASF nur die Gegenstände aus dem gleichen Spiel und Typ, die auch die gleiche Seltenheit aufweisen, als fair erachten wird.

Bitte bedenken Sie, dass **ASF kein Handelsbot** ist und **sich NICHT um den Marktpreis schert.**. Wenn Sie Gegenstände der gleichen Seltenheit aus dem gleichen Set nicht als preislich gleichwertig betrachten, dann ist diese Option NICHT in Ihrem Sinne. Bitte überlegen Sie sich zweimal, ob Sie diese Erklärung verstehen und damit einverstanden sind, bevor Sie diese Einstellung ändern.

Wenn Sie nicht wissen, was Sie tun, sollten Sie den Standardwert bei `5` belassen.

---

### `OnlineFlags`

Typ `ushort flags` mit dem Standardwert `0`. Diese Eigenschaft funktioniert als Ergänzung zu **[`OnlineStatus`](#onlinestatus)** und gibt zusätzliche Online-Präsenzfunktionen an, die im Steam Netzwerk angekündigt wurden. Erfordert, dass **[`OnlineStatus`](#onlinestatus)** nicht `Offline` ist und ist wie unten definiert:

| Wert | Name              | Beschreibung                                    |
| ---- | ----------------- | ----------------------------------------------- |
| 0    | None              | Keine speziellen Online-Präsenz-Flags, Standard |
| 256  | ClientTypeWeb     | Client verwendet Webschnittstelle               |
| 512  | ClientTypeMobile  | Client verwendet mobile App                     |
| 1024 | ClientTypeTenfoot | Der Kunde benutzt den BigPicture-Modus          |
| 2048 | ClientTypeVR      | Client verwendet ein VR-Headset                 |

Bitte bedenken Sie, dass diese Variable das Feld `flags` ist, daher ist es möglich, eine beliebige Kombination von verfügbaren Werten auszuwählen. Schlagen Sie gerne **[JSON-Strukturierung](#json-strukturierung)** nach, wenn Sie mehr erfahren möchten. Wenn keines der Flags aktiviert ist, wird die Option `None` verwendet.

Das zugrunde liegende `EPersonaStateFlag` Typ, auf dem diese Eigenschaft basiert, enthält mehr verfügbare Flags. Doch nach bestem Wissen haben sie ab heute überhaupt keine Wirkung; deshalb wurden sie wegen Ihrer Sichtbarkeit abgeschnitten.

Belassen Sie den Standardwert `0`, wenn Sie sich nicht sicher sind, wie Sie diese Eigenschaft einstellen sollen.

---

### `OnlineStatus`

Typ `byte` mit einem Standardwert `1`. Diese Variable gibt den Status der Steam-Community an, mit dem der Bot nach der Anmeldung im Steam-Netzwerk angekündigt wird. Derzeit können Sie einen der folgenden Status wählen:

| Wert | Name           |
| ---- | -------------- |
| 0    | Offline        |
| 1    | Online         |
| 2    | Busy           |
| 3    | Away           |
| 4    | Snooze         |
| 5    | LookingToTrade |
| 6    | LookingToPlay  |
| 7    | Invisible      |

`Offline` Status ist extrem nützlich für primäre Konten. Wie Sie wissen sollten, zeigt das Sammeln eines Spiels tatsächlich den Steam-Status als „Spielt: XXX“ an, was für Freunde irreführend sein kann und sie verwirrt, dass Sie ein Spiel spielen, während eigentlich nur gesammelt wird. Die Verwendung des `Offline`-Status löst dieses Problem. Das Konto wird nie als „im Spiel“ angezeigt, wenn Sie Steam-Karten mit ASF sammeln. Dies ist dank der Tatsache möglich, dass sich ASF nicht in die Steam-Community anmelden muss, um richtig zu funktionieren. Also spielen wir tatsächlich diese Spiele, sind mit dem Steam-Netzwerk verbunden, aber ohne unsere Online-Präsenz überhaupt bekannt zu geben. Bedenken Sie, dass gespielte Spiele im Offline-Status immer noch auf die gesamte Spielzeit zählen und in dem Profil als „kürzlich gespielt“ angezeigt werden.

Darüber hinaus ist diese Funktion auch wichtig, wenn Sie Benachrichtigungen und ungelesene Nachrichten erhalten möchten, während ASF läuft, ohne den Steam-Client gleichzeitig geöffnet zu lassen. Dies liegt daran, dass ASF selbst als Steam-Client fungiert, und ob ASF es möchte oder nicht, Steam sendet all diese Nachrichten (und andere Ereignisse) an ihn. Dies ist kein Problem, wenn Sie sowohl ASF , als auch den eigenen Steam-Client ausführen, da beide Clients genau die gleichen Ereignisse empfangen. Wenn jedoch nur ASF läuft, könnte das Steam-Netzwerk bestimmte Ereignisse und Nachrichten als „zugestellt“ markieren, obwohl der herkömmliche Steam-Client diese nicht erhält, weil er nicht anwesend ist. Der Offline-Status löst auch dieses Problem, da ASF in diesem Fall nie für Community-Events in Betracht gezogen wird, sodass alle ungelesenen Nachrichten und andere Ereignisse bei Ihrer Rückkehr ordnungsgemäß als ungelesen markiert werden.

Es ist wichtig zu beachten, dass ASF, welches im `Offline` Modus läuft, **nicht** in der Lage sein wird, Befehle auf herkömmliche Weise im Steam-Chat zu empfangen, da der Chat sowie die gesamte Community-Präsenz in der Tat völlig offline ist. Eine Lösung für dieses Problem ist die Verwendung des Modus `Invisible`, der auf ähnliche Weise funktioniert (den Status verbergen), aber dennoch die Fähigkeit behält, Nachrichten zu empfangen und zu beantworten (also auch das Potenzial, Benachrichtigungen und ungelesene Nachrichten wie oben erläutert zu verwerfen). Der Modus `Invisible` ist am sinnvollsten bei Alternativ-Konten, die statusmäßig unsichtbar bleiben sollen, aber trotzdem in der Lage sind, Befehle zu senden.

Es gibt jedoch einen Haken beim `Invisible` Modus – er funktioniert nicht gut mit primären Konten. Dies liegt daran, dass **jede** Steam-Sitzung, die derzeit online ist, den Status **anzeigt**, auch wenn ASF selbst es nicht tut. Dies wird durch Begrenzung/Fehler des Steam-Netzwerks verursacht, die seitens ASF-Seite nicht behoben werden können, sodass Sie, wenn Sie den `Invisible`-Modus verwenden möchten, auch sicherstellen müssen, dass **alle** andere Sitzungen zum gleichen Konto auch den `Invisible`-Modus verwenden. Dies trifft auf Alternativ-Konten zu, bei denen ASF hoffentlich die einzige aktive Sitzung ist, aber bei primären Konten werden Sie es fast immer vorziehen, sich Ihren Freunden als `Online` anzuzeigen, indem nur die Aktivität von ASF versteckt wird, und in diesem Fall wird der `Invisible`-Modus für Sie völlig nutzlos sein (wir empfehlen, stattdessen den `Offline`-Modus zu verwenden). Hoffentlich wird diese Beschränkung/Fehler in Zukunft von Valve behoben, aber ich würde nicht erwarten, dass dies zeitnah passieren wird...

Wenn Sie sich nicht sicher sind, wie Sie diese Variable einrichten sollen, wird empfohlen, einen Wert von `0` (`Offline`) für primäre Konten und den Standard `1` (`Online`) anderweitig zu verwenden.

---

### `PasswordFormat`

Typ `byte` mit dem Standardwert `0` (`PlainText`). Diese Eigenschaft definiert das Format der Variable `SteamPassword` und unterstützt derzeit die im Abschnitt **[Sicherheit](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security-de-DE)** angegebenen Werte. Sie sollten den dort angegebenen Anweisungen folgen, da Sie sicherstellen müssen, dass die Eigenschaft `SteamPassword` tatsächlich das Passwort im übereinstimmenden `PasswordFormat` enthält. Mit anderen Worten: wenn Sie `PasswordFormat` ändern, dann sollte das `SteamPassword` **bereits** in diesem Format sein, und nicht nur darauf abzielen, zu existieren. Wenn Sie nicht wissen, was Sie tun, sollten der Standardwert bei `0` belassen werden.

Wenn Sie das `PasswordFormat` eines Bots ändern, der sich mindestens einmal im Steam Netzwerk eingeloggt hat, ist es möglich, dass Sie beim nächsten Start des Bots einen einmaligen Entschlüsselungsfehler erhalten; dies ist darauf zurückzuführen, dass `PasswordFormat` auch für die automatische Verschlüsselung/Entschlüsselung sensibler Eigenschaften in der Datenbankdatei `Bot.db` verwendet wird. Sie können diesen Fehler gefahrlos ignorieren, da ASF sich allein von dieser Situation erholen kann. Wenn dies jedoch konstant erfolgt, z. B. bei jedem Neustart, sollte es untersucht werden.

---

### `RedeemingPreferences`

Typ `byte flags` mit dem Standardwert `0`. Diese Variable definiert das ASF-Verhalten beim aktivieren von Produktschlüsseln und ist wie folgt definiert:

| Wert | Name                               | Beschreibung                                                                                                                                         |
| ---- | ---------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------- |
| 0    | None                               | Keine speziellen Einlöse-Einstellungen, Standard                                                                                                     |
| 1    | Forwarding                         | Leite Produktschlüssel, die nicht zum Einlösen verfügbar sind, zu anderen Bots weiter                                                                |
| 2    | Distributing                       | Verteile alle Produktschlüssel auf sich und andere Bots                                                                                              |
| 4    | KeepMissingGames                   | Bewahre Produktschlüssel für (potenziell) fehlende Spiele beim Weiterleiten auf und lassen Sie ungenutzt                                             |
| 8    | AssumeWalletKeyOnBadActivationCode | Versucht Keys als Guthaben-Codes einzulösen, da angenommen wird, dass `BadActivationCode`-Schlüssel mit `CannotRedeemCodeFromClient` identisch sind. |

Bitte bedenken Sie, dass diese Variable das Feld `flags` ist; daher ist es möglich, eine beliebige Kombination von verfügbaren Werten auszuwählen. Schlagen Sie gerne **[JSON-Strukturierung](#json-strukturierung)** nach, wenn Sie mehr erfahren möchten. Wenn keines der Flags aktiviert wird, wird die Option `None` verwendet.

`Forwarding` veranlasst den Bot, einen Produktschlüssel, der nicht eingelöst werden konnte, an einen anderen verbundenen und angemeldeten Bot weiterzuleiten, dem dieses bestimmte Spiel fehlt (wenn es möglich ist, dies zu überprüfen). Die häufigste Situation ist die Weiterleitung von `AlreadyPurchased` Spiel an einen anderen Bot, dem dieses Spiel fehlt, aber diese Option deckt auch andere Szenarien ab, etwa `DoesNotOwnRequiredApp`, `RateLimited` oder `RestrictedCountry`.

`Distributing` veranlasst den Bot, alle empfangenen Produktschlüssel unter sich und anderen Bots zu verteilen. Das bedeutet, dass jeder Bot einen einzigen Produktschlüssel aus der Charge erhält. Normalerweise wird dies nur verwendet, wenn Sie viele Produktschlüssel für das gleiche Spiel einlösen und diese gleichmäßig auf Ihre Bots verteilen möchten; im Gegensatz zum Einlösen von Produktschlüsseln für verschiedene Spiele. Diese Funktion ist nicht sinnvoll, wenn Sie nur einen Produktschlüssel in einer einzigen `redeem` Aktion einlösen (da es keine zusätzlichen Produktschlüssel gibt, die verteilt werden müssen).

`KeepMissingGames` veranlasst den Bot, `Forwarding` zu überspringen, wenn wir nicht sicher sein können, ob der Produktschlüssel, der eingelöst wird, tatsächlich unserem Bot gehört oder nicht. Dies bedeutet im Grunde, dass `Forwarding` **nur** für `AlreadyPurchased` Produktschlüssel gilt, anstatt auch andere Fälle wie `DoesNotOwnRequiredApp`, `RateLimited` oder `RestrictedCountry` zu behandeln. Normalerweise sollten Sie diese Option für das primäre Konto verwenden, um sicherzustellen, dass Produktschlüssel, die auf dem primären Konto eingelöst werden, nicht weitergereicht werden, wenn ein Bot beispielsweise vorübergehend `RateLimited` ist. Wie Sie der Beschreibung entnehmen können, hat dieses Feld absolut keine Wirkung, wenn `Forwarding` nicht aktiviert ist.

`AssumeWalletKeyOnBadActivationCode` wird `BadActivationCode` Schlüssel als `CannotRedeemCodeFromClient`behandeln, und führt somit dazu, dass ASF versucht, diese als Guthaben-Schlüssel einzulösen. Dies ist notwendig, da Steam möglicherweise Guthaben-Codes als `BadActivationCode` ankündigen könnte (und nicht `CannotRedeemCodeFromClient`, wie es zuvor war). Dies führt dazu, dass ASF nie versucht, diese einzulösen. Allerdings raten wir von **gegen** dieser Präferenz ab, da es dazu führen wird, dass ASF versucht, jeden ungültigen Schlüssel als Guthaben-Code einzulösen, was widerum zu einer übermäßigen Anzahl (potenziell ungültiger) Anfragen an den Steam-Service (mit allen möglichen Folgen) führt. Stattdessen empfehlen wir den Modus `ForceAssumeWalletKey` **[`redeem^`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-de-DE#kommandos)**, während bewusst Wallet-Schlüssel eingelöst werden, die die benötigte Problemumgehung nur dann aktiviert, wenn sie je nach Bedarf erforderlich ist.

Wenn Sie sowohl `Forwarding` , als auch `Distributing` aktivieren, wird zusätzlich zur Weiterleitung eine Verteilungsfunktion hinzugefügt, wodurch ASF versucht, einen Produktschlüssel auf allen Bots zuerst einzulösen (Weiterleitung), bevor es zum nächsten geht (Verteilung). Normalerweise möchten Sie diese Option nur verwenden, wenn Sie `Forwarding` möchten, aber mit geändertem Verhalten beim Einschalten des verwendeten Bots für Produktschlüssel, anstatt immer mit jedem Produktschlüssel in Reihenfolge zu gehen (das wäre `Forwarding` allein). Dieses Verhalten kann von Vorteil sein, wenn Sie wissen, dass die Mehrheit oder sogar alle Produktschlüssel an das gleiche Spiel gebunden sind. In dieser Situation würde `Forwarding` allein versuchen, alles auf einem Bot einzulösen (was Sinn macht, wenn die Produktschlüssel für einzigartige Spiele wären); und `Forwarding` + `Distributing` schaltet den Bot auf den nächsten Produktschlüssel um, „verteilt“ die Aufgabe, einen neuen Produktschlüssel auf einen anderen – als den ursprünglichen – einzulösen (was sinnvoll ist, wenn die Produktschlüssel für das gleiche Spiel sind, überspringt einen sinnlosen Versuch pro Produktschlüssel).

Die tatsächliche Reihenfolge der Bots für alle Einlöseszenarien ist alphabetisch, mit Ausnahme von Bots, die nicht verfügbar sind (nicht verbunden, gestoppt oder ähnliches). Bitte bedenken Sie, dass es ein stündliches Limit für Einlösungsversuche pro IP und pro Konto gibt, und jeder Einlösungsversuch, der nicht mit `OK` endete, trägt zu den fehlgeschlagenen Versuchen bei. ASF wird sein Bestes tun, um die Anzahl der `AlreadyPurchased` Fehler zu minimieren, z. B. indem es versucht zu vermeiden, einen Produktschlüssel an einen anderen Bot weiterzuleiten, der bereits dieses bestimmte Spiel besitzt; aber es ist nicht immer garantiert, dass es funktioniert, aufgrund dessen wie Steam mit Lizenzen umgeht. Die Verwendung von Einlöse-Flags wie `Forwarding` oder `Distributing` erhöht immer die Wahrscheinlichkeit, dass Sie ein `RateLimited` (Anfragelimit) erreichen.

Außerdem ist zu beachten, dass Sie keine Produktschlüssel an Bots weiterleiten oder verteilen können, auf die Sie keinen Zugriff haben. Dies sollte offensichtlich sein, aber stellen Sie sicher, dass Sie mindestens `Operator` aller Bots sind, die Sie beim Einlösungsprozess einbeziehen möchten, z.B. mit dem **[Befehl](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-de-DE)** `status ASF`.

---

### `RemoteCommunication`

Typ `byte flags` mit einem Standardwert `3`. Diese Eigenschaft definiert das ASF-Verhalten pro Bot, wenn es um die Kommunikation mit Remote – (fremden) Diensten geht, und ist wie folgt definiert:

| Wert | Name          | Beschreibung                                                                                                                                                                                                                                                                               |
| ---- | ------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| 0    | None          | Keine Kommunikation mit Drittanbietern erlaubt, wodurch die ausgewählten ASF-Funktionen unbrauchbar werden                                                                                                                                                                                 |
| 1    | SteamGroup    | Ermöglicht die Kommunikation mit **[ASFs Steam-Gruppe](https://steamcommunity.com/groups/archiasf)**                                                                                                                                                                                       |
| 2    | PublicListing | Ermöglicht die Kommunikation mit **[ASFs STM Auflistung](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin-de-#publiclisting)**, um aufgelistet zu werden wenn der Benutzer auch `SteamTradeMatcher` in **[`TradingPreferences`](#tradingpreferences)** aktiviert hat |

Bitte bedenken Sie, dass diese Variable das Feld `flags` ist, daher ist es möglich, eine beliebige Kombination von verfügbaren Werten auszuwählen. Schlagen Sie gerne **[JSON-Strukturierung](#json-strukturierung)** nach, wenn Sie mehr erfahren möchten. Wenn keines der Flags aktiviert wird, wird die Option `None` verwendet.

Diese Option beinhaltet keine Kommunikation von Drittanbietern, die von ASF angeboten wird, sondern nur solche, die nicht von anderen Einstellungen impliziert werden. Wenn Sie zum Beispiel die automatischen Updates von ASF aktiviert haben, kommuniziert ASF gemäß Ihrer Konfiguration sowohl mit GitHub (für Downloads) , als auch mit unserem Server (zur Prüfsummenüberprüfung). Gleichermaßen die Aktivierung von `MatchActively` in den **[`Handelseinstellungen`](#tradingpreferences)** impliziert Kommunikation mit unserem Server, um gelistete Bots abzurufen, die für diese Funktionalität benötigt wird.

Weitere Erläuterungen zu diesem Thema finden Sie im Abschnitt **[Telekommunikation](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Remote-communication-de-DE)**. Wenn Sie keinen Grund haben diese Variable zu bearbeiten, sollte der Standardwert belassen werden.

---

### `SendTradePeriod`

Typ `byte` mit einem Standardwert `0`. Diese Eigenschaft funktioniert fast identisch wie die Einstellung `SendOnFarmingFinished` in den `FarmingPreferences`, mit einem Unterschied. Anstatt Handelsangebote zu senden, wenn das Sammeln abgeschlossen ist, können wir sie auch alle `SendTradePeriod` Stunden senden, unabhängig davon, wie viel wir noch zu sammeln haben. Dies ist nützlich, wenn Sie den normalen `loot` Befehl auf Alternativ-Konten ausführen möchten, anstatt darauf zu warten, dass das Sammeln beenden wird. Der Standardwert von `0` deaktiviert diese Funktion. Wenn Sie möchten, dass ein Bot Ihnen z. B. jeden Tag Handelsangebote sendet, sollten Sie hier `24` eintragen.

Normalerweise sollten Sie **[ASF-2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication-de-DE)** zusammen mit dieser Funktion verwenden; obwohl es keine Voraussetzung ist, wenn Sie beabsichtigen, die 2FA Bestätigung manuell und rechtzeitig durchzuführen. Belassen Sie den Standardwert `0`, wenn Sie sich nicht sicher sind, wie Sie diese Eigenschaft einstellen sollen.

---

### `SteamLogin`

Typ `string` mit einem Standardwert `null`. Diese Variable definiert den Steam-Login – mit welchem Sie sich bei Steam anmelden. Zusätzlich zur Definition des Steam-Logins können Sie hier auch den Standardwert `null` beibehalten, wenn Sie den Steam-Login bei jedem ASF-Start eingeben möchten, anstatt es in die Konfiguration einzutragen. Dies kann für Sie nützlich sein, wenn Sie sensible Daten nicht in der Konfigurationsdatei speichern möchten.

---

### `SteamMasterClanID`

Typ `ulong` mit einem Standardwert `0`. Diese Variable definiert die steamID der Steam-Gruppe, der der Bot automatisch beitreten soll, einschließlich des Gruppen-Chats. Sie können die steamID der Gruppe überprüfen, indem Sie zu Ihrer **[Seite](https://steamcommunity.com/groups/archiasf)** navigieren und dann `/memberslistxml?xml=1` am Ende des Links hinzufügen, sodass der Link wie **[dieser](https://steamcommunity.com/groups/archiasf/memberslistxml?xml=1)** aussieht. Dann können Sie die steamID Ihrer Gruppe aus dem Ergebnis erhalten, welche sich im `<groupID64>`-Tag befndet. Im obigen Beispiel wäre es `103582791440160998`. Zusätzlich zu dem Versuch, einer bestimmten Gruppe beim Start beizutreten, akzeptiert der Bot auch automatisch Gruppeneinladungen zu dieser Gruppe, sodass Sie Ihren Bot manuell einladen können, wenn Ihre Gruppe ein privates Mitglied ist. Wenn Sie keine Gruppe für Ihre Bots haben, sollten Sie diese Eigenschaft mit dem Standardwert `0` behalten.

---

### `SteamParentalCode`

Typ `string` mit einem Standardwert `null`. Diese Eigenschaft definiert den Steam-Familienansicht-Code. ASF erfordert Zugriff auf Familienansicht-Ressourcen. Wenn Sie diese Funktion verwenden, sollten Sie ASF für eine problemlose Ausführung die PIN zum entsperren verraten. Der Standardwert `null` bedeutet, dass für die Freischaltung dieses Kontos kein Steam-Familienansicht-Code erforderlich ist, und das ist wahrscheinlich das, was Sie wollen, wenn Sie nicht die Steam-Elternfunktionalität verwenden.

Unter bestimmten Umständen kann ASF auch selbst einen gültigen Steam-Elterncode generieren, obwohl dies eine übermäßige Menge an Betriebssystem-Ressourcen und zusätzliche Zeit zum Fertigstellen erfordert, ganz zu schweigen davon, dass es nicht immer erfolgreich ist. Daher empfehlen wir, sich nicht auf diese Funktion zu verlassen und stattdessen einen gültigen `SteamParentalCode` in der Konfiguration für ASF einzutragen. Wenn ASF feststellt, dass eine PIN erforderlich ist und keine eigene generieren kann, wird es Sie um Eingabe bitten.

---

### `SteamPassword`

Typ `string` mit dem Standardwert `null`. Diese Eigenschaft definiert das Steam-Passwort – das, mit dem Sie sich bei Steam anmelden. Zusätzlich zur Definition des Steam-Passworts können Sie hier auch den Standardwert `null` beibehalten, wenn Sie ein Steam-Passwort bei jedem ASF-Start eingeben möchten, anstatt es in die Konfiguration einzutragen. Dies kann nützlich sein, wenn Sie keine sensiblen Daten in der Konfigurationsdatei speichern möchten.

---

### `SteamTradeToken`

Typ `string` mit dem Standardwert `null`. Wenn Sie einen Bot in einer Freundesliste haben, dann kann der Bot Ihnen sofort ein Handelsangebot schicken, ohne sich um den Handelscode zu kümmern. Deshalb können Sie diese Eigenschaft auf dem Standardwert von `null` belassen. Wenn Sie sich jedoch dazu entscheiden, den Bot NICHT auf Ihrer Freundesliste zu haben, dann müssen Sie einen Handelscode des Benutzers generieren und eintragen, an den dieser der Bot Handelsangebote senden möchte. Mit anderen Worten: diese Variable sollte mit dem Handelscode des Kontos gefüllt werden, das mit `Master` Berechtigung in `SteamUserPermissions` von **dieser** Bot-Instanz definiert ist.

Um Ihren Code zu finden, navigieren Sie als angemeldeter Benutzer mit der Berechtigung `Master` **[hierher](https://steamcommunity.com/my/tradeoffers/privacy)** und schauen sich die Handels-URL an. Der Code, nach dem wir suchen, besteht aus 8 Zeichen nach Teil `&token=` in Ihrer Handels-URL. Sie sollten diese 8 Zeichen kopieren und hier einfügen, als `SteamTradeToken`. Ungültig sind hingegen die Handels-URL als gesammtes, sowie der `&token=` Teil. Nur der Code selbst (8 Zeichen) ist hier erforderlich.

---

### `SteamUserPermissions`

Typ `ImmutableDictionary<ulong, byte>` mit einem leeren Standardwert. Diese Variable ist eine Dictionary-Variable, die den Steam-Benutzer, der durch seine 64-Bit-Steam-ID identifiziert wurde, auf die Nummer `byte` umbildet, die seine Berechtigung in ASF-Instanz angibt. Die derzeit verfügbaren Bot-Berechtigungen in ASF sind definiert als:

| Wert | Name          | Beschreibung                                                                                                                                                                                                                              |
| ---- | ------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| 0    | None          | Keine spezielle Berechtigung, dies ist hauptsächlich ein Referenzwert, der den in diesem Wörterbuch fehlenden Steam-IDs zugeordnet wird – es ist nicht notwendig, irgendjemanden mit dieser Berechtigung zu definieren                    |
| 1    | FamilySharing | Bietet einen minimalen Zugriff für Familienmitglieder. Auch hier handelt es sich vor allem um einen Referenzwert, da ASF in der Lage ist, automatisch Steam-IDs zu entdecken, die wir für die Nutzung unserer Bibliothek zugelassen haben |
| 2    | Operator      | Bietet Basiszugriff auf bestimmte Bot-Instanzen, hauptsächlich das Hinzufügen von Lizenzen und das Einlösen von Schlüsseln                                                                                                                |
| 3    | Master        | Gewährt vollen Zugriff auf die angegebene Bot-Instanz                                                                                                                                                                                     |

Kurz gesagt, diese Variable ermöglicht es Ihnen, Berechtigungen für bestimmte Benutzer zu verwalten. Berechtigungen sind vor allem für den Zugriff auf ASF **[Befehle](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-de-DE)** wichtig, aber auch für die Aktivierung vieler ASF-Funktionen, z. B. die Annahme von Handelsangeboten. Zum Beispiel könnten Sie Ihr eigenes Konto als `Master` einrichten und `Operator`-Zugang zu 2-3 Freunden geben, damit diese leicht Produktschlüssel für Ihren Bot mit ASF einlösen können, während Freunde **nicht** berechtigt sind, z. B. den Bot zu stoppen. Dank dessen können Sie bestimmten Benutzern einfach Berechtigungen zuweisen und sie den Bot verwenden lassen.

Wir empfehlen, genau einen Benutzer als `Master` und eine beliebige Anzahl von `Operators` und darunter einzutragen. Während es technisch möglich ist, mehrere `Masters` einzustellen und ASF korrekt mit Ihnen arbeiten wird, z. B. indem es alle an den Bot gesendeten Handelsangebote akzeptiert. Allerdings wird ASF nur einen von Ihnen (mit der niedrigsten Steam-ID) für jede Aktion verwenden, die ein einzelnes Ziel erfordert (z. B. eine `loot` Anfrage), als auch Eigenschaften (wie die Einstellung `SendOnFarmingFinished` in den `FarmingPreferences` oder `SendTradePeriod`). Wenn Sie diese Einschränkungen perfekt verstehen, insbesondere die Tatsache, dass die `loot` Anfrage immer Elemente an den `Master` mit der niedrigsten Steam-ID sendet, unabhängig von dem `Master`, der den Befehl tatsächlich ausgeführt hat, dann können Sie hier mehrere Benutzer mit der Berechtigung `Master` definieren. Aber wir empfehlen trotzdem ein einfaches Master-Schema.

Es ist gut zu wissen, dass es noch eine weitere zusätzliche `Owner` Berechtigung gibt, die als globale Konfigurationseigenschaft `SteamOwnerID` deklariert ist. Hier können Sie niemandem die Berechtigung `Owner` zuweisen, da die Eigenschaft `SteamUserPermissions` nur Berechtigungen definiert, die sich auf die Bot-Instanz beziehen, und nicht ASF als Prozess. Für Bot-bezogene Aufgaben wird die `SteamOwnerID` genauso behandelt wie `Master`, sodass die Angabe einer `SteamOwnerID` hier nicht erforderlich ist.

---

### `TradeCheckPeriod`

Typ `byte` mit dem Standardwert `60`. Normalerweise verarbeitet ASF eingehende Handelsangebote direkt nach Erhalt von Benachrichtigungen über eines, aber manchmal kann es aufgrund von Steam-Problemen zeitweise fehlschlagen, und solche Handelsangebote bleiben solange ignoriert, bis die nächste Handelsbenachrichtigung oder ein Neustart des Bots eintritt, was dazu führen kann, dass Handel storniert werden oder Gegenstände zu diesem Zeitpunkt nicht verfügbar sind. Wenn der Wert dieses Parameters größer als `0` ist, prüft ASF zusätzlich alle `TradeCheckPeriode` Minuten auf solche ausstehenden Transaktionen. Der Standardwert wird mit dem Kompromiss zwischen zusätzlichen Anfragen an die Steam-Server und dem Verlust eingehender Handel ausgewählt. Wenn Sie jedoch nur ASF verwenden, um Karten zu sammeln, und nicht planen, eingehende Handelsangebote automatisch zu verarbeiten, kann dieser Wert auf `0` gesetzt werden, um diese Funktion komplett zu deaktivieren. Wenn Ihr Bot andererseits an der öffentlichen [ASF’s STM Auflistung ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#publiclisting) teilnimmt oder andere automatisierte Dienste als Handelsbot anbietet, möchten Sie diesen Parameter vielleicht auf `15` Minuten reduzieren, um alle Angebote rechtzeitig zu bearbeiten.

---

### `TradingPreferences`

Typ `byte flags` mit dem Standardwert `0`. Diese Variable definiert das ASF-Verhalten beim Handeln und ist wie folgt definiert:

| Wert | Name                | Beschreibung                                                                                                                                                                                                                                     |
| ---- | ------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| 0    | None                | Keine besonderen Handelspräferenzen, Standard                                                                                                                                                                                                    |
| 1    | AcceptDonations     | Akzeptiert Handelsangebote, bei denen wir nichts verlieren                                                                                                                                                                                       |
| 2    | SteamTradeMatcher   | Nimmt passiv an **[STM](https://www.steamtradematcher.com)**-artigen Handelsangeboten teil. Besuchen Sie **[Handeln](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading-de-DE#steamtradematcher)** für weitere Informationen            |
| 4    | MatchEverything     | Erfordert das Setzen von `SteamTradeMatcher` und akzeptiert dabei neben guten und neutralen auch schlechte Handelsangebote                                                                                                                       |
| 8    | DontAcceptBotTrades | Akzeptiert keine automatischen `loot` Handelsangebote von anderen Bot-Instanzen                                                                                                                                                                  |
| 16   | MatchActively       | Nimmt aktiv an **[STM](https://www.steamtradematcher.com)**-artigen Handelsangeboten teil. Besuchen Sie **[ItemsMatcherPlugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#matchactively)** für weitere Informationen |

Bitte bedenken Sie, dass diese Variable ein Feld (`flags`) ist, daher ist es möglich, eine beliebige Kombination von verfügbaren Werten auszuwählen. Schlagen Sie gerne **[JSON-Strukturierung](#json-strukturierung)** nach, wenn Sie mehr erfahren möchten. Wenn keines der Flags aktiviert wird, greift die Option `None`.

Für weitere Erläuterungen zur ASF-Handelslogik und zur Beschreibung jedes verfügbaren Flags besuchen Sie bitte den Abschnitt **[Handeln](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading-de-DE)**.

---

### `TransferableTypes`

Typ `ImmutableHashSet<byte>` mit dem Standardwert `1, 3, 5` als Steam-Gegenstandstyp. Diese Eigenschaft definiert, welche Steam-Gegenstandstypen für die Übertragung zwischen Bots beim `transfer` **[Befehl](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-de-DE)** berücksichtigt werden. ASF wird sicherstellen, dass nur Gegenstände von `TransferableTypes` in ein Handelsangebot aufgenommen werden, daher können Sie mit dieser Variable wählen, was in einem Handelsangebot erhalten sein darf, das an einen Ihrer Bots gesendet wird.

| Wert | Name                  | Beschreibung                                                                                           |
| ---- | --------------------- | ------------------------------------------------------------------------------------------------------ |
| 0    | Unknown               | Jeder Typ, der nicht in eine der folgenden Kategorien passt                                            |
| 1    | BoosterPack           | Booster Pack mit 3 zufälligen Karten aus einem Spiel                                                   |
| 2    | Emoticon              | Emoticon zur Verwendung im Steam-Chat                                                                  |
| 3    | FoilTradingCard       | Glanz-Variante von `TradingCard`                                                                       |
| 4    | ProfileBackground     | Profilhintergrund zur Verwendung in Ihrem Steam-Profil                                                 |
| 5    | TradingCard           | Steam-Sammel-Karte, die für die Herstellung von Abzeichen (Nicht-Glanz) verwendet werden               |
| 6    | SteamGems             | Steam-Edelsteine, die für die Herstellung von Booster Packs verwendet werden, inklusive Edelsteinsäcke |
| 7    | SaleItem              | Spezialgegenstände, die während des Steam-Sales vergeben werden                                        |
| 8    | Consumable            | Spezielle Verbrauchsgegenstände, die nach dem Gebrauch wieder verschwinden                             |
| 9    | ProfileModifier       | Spezialgegenstände, welche das Aussehen des Steam-Profils verändern können                             |
| 10   | Sticker               | Spezialgegenstände, welche im Steam-Chat verwendet werden können                                       |
| 11   | ChatEffect            | Spezialgegenstände, welche im Steam-Chat verwendet werden                                              |
| 12   | MiniProfileBackground | Besonderer Hintergrund für Steam-Profile                                                               |
| 13   | AvatarProfileFrame    | Besonderer Avatarrahmen für das Steam-Profil                                                           |
| 14   | AnimatedAvatar        | Besonders animierter Avatar für das Steam-Profil                                                       |
| 15   | KeyboardSkin          | Spezieller Tastatur-Skin für das Steam Deck                                                            |
| 16   | StartupVideo          | Spezielle Start-Animation für das Steam Deck                                                           |

Bitte bedenken Sie, dass ASF unabhängig von den obigen Einstellungen nur nach Steam **Community-Gegenständen[](https://steamcommunity.com/my/inventory/#753_6)** (`appID` von 753, `contextID` von 6)-Gegenständen fragt, sodass alle Spiel-Gegenstände /-Geschenke und dergleichen definitionsgemäß aus dem Handelsangebot ausgeschlossen sind.

Die Standard-ASF-Einstellung basiert auf der gebräuchlichsten Verwendung des Bots, wobei nur Booster Packs und Sammelkarten (einschließlich Folienkarten) gehandelt werden. Die hier definierte Variable ermöglicht es Ihnen, dieses Verhalten so zu verändern, dass es Sie zufrieden stellt. Bitte bedenken Sie, dass alle nicht oben definierten Typen als `Unknown` angezeigt werden, was besonders wichtig ist, wenn Valve einen neuen Steam-Gegenstand veröffentlicht, der ebenfalls von ASF als `Unknown` markiert wird, bis er hier (in einer zukünftigen Version) hinzugefügt wird. Deshalb ist es im Allgemeinen nicht empfehlenswert, `Unknown` in einen `TransferableTypes` einzugeben, es sei denn, Sie wissen, was Sie tun und verstehen auch, dass ASF Ihr gesamtes Inventar in einem Handelsangebot versenden wird, wenn das Steam-Netzwerk wieder fehleraft wird und alle Gegenstände als `Unknown` meldet. Mein nachdrücklicher Vorschlag ist, `Unknown` nicht in das Feld `TransferableTypes` einzutragen, selbst wenn Sie alles übertragen möchten.

---

### `UseLoginKeys`

Typ `bool` mit dem Standardwert `true`. Diese Variable legt fest, ob ASF den Anmeldeschlüssel-Mechanismus für dieses Steam-Konto verwenden soll. Der Anmeldeschlüssel-Mechanismus funktioniert sehr ähnlich wie die „Angemeldet bleiben“-Option des offiziellen Steam-Clients, die es ASF ermöglicht, einen temporären, einmaligen Anmeldeschlüssel für den nächsten Anmeldeversuch zu speichern und zu verwenden, wodurch die Angabe von Passwort, Steam Guard oder 2FA-Code übergangen wird, solange unser Anmeldeschlüssel gültig ist. Der Anmeldeschlüssel wird in der Datei `BotName.db` gespeichert und automatisch aktualisiert. Aus diesem Grund müssen Sie kein Passwort/SteamGuard/2FA-Code angeben, nachdem Sie sich nur einmal erfolgreich mit ASF angemeldet haben.

Die Anmelde-Schlüssel werden standardmäßig für Ihre Bequemlichkeit verwendet, sodass Sie nicht bei jedem Anmeldevorgang `SteamPassword`, SteamGuard oder 2FA-Code eingeben müssen, sofern Sie nicht **[ASF-2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication-de-DE)** verwenden. Es ist auch eine überlegene Alternative, da der Anmeldeschlüssel nur einmalig verwendet werden kann und das ursprüngliche Passwort in keiner Weise offenbart. Genau die gleiche Methode wird vom ursprünglichen Steam-Client verwendet, der den Konto-Namen und Anmeldeschlüssel für Ihren nächsten Anmeldeversuch speichert, was praktisch die gleiche ist, wie die Verwendung von `SteamLogin` mit `UseLoginKeys` und leerem `SteamPassword` in ASF.

Einige Leute sind jedoch vielleicht sogar über dieses kleine Detail besorgt, deshalb steht diese Option hier zur Verfügung, wenn Sie sicherstellen möchten, dass ASF keine Art von Daten speichert, die es ermöglichen würden, die vorherige Sitzung nach dem Schließen wieder aufzunehmen, was dazu führt, dass eine vollständige Authentifizierung bei jedem Anmeldeversuch obligatorisch ist. Das Deaktivieren dieser Option funktioniert genau so, wie wenn Sie „Angemeldet bleiben“ im offiziellen Steam-Client deaktiviert lassen. Wenn Sie nicht wissen, was Sie tun, sollten Sie den Standardwert `true` belassen.

---

### `UserInterfaceMode`

Typ `byte` mit einem Standardwert `0`. Diese Variable spezifiziert die Bedienoberfläche, mit dem der Bot nach der Anmeldung im Steam-Netzwerk angekündigt wird. Derzeit können Sie einen der folgenden Optionen wählen:

| Wert | Name       |
| ---- | ---------- |
| `0`  | Default    |
| `1`  | BigPicture |
| `2`  | Mobile     |

Wenn Sie sich nicht sicher sind, wie Sie diese Variable einstellen sollen, belassen Sie diese bei dem Standardwert `0`.

---

## Dateistruktur

ASF benutzt eine einfache Dateistruktur.

```text
├── config
│   ├── ASF.json
│   ├── ASF.db
│   ├── Bot1.json
│   ├── Bot1.db
│   ├── Bot2.json
│   ├── Bot2.db
│   └── ...
├── ArchiSteamFarm.dll
├── log.txt
└── ...
```

Um ASF an einen neuen Ort zu verschieben, z. B. auf einen anderen PC, genügt es, das Verzeichnis `config` allein zu verschieben/kopieren, und das ist die empfohlene Art und Weise, jede Form von „ASF-Backups“ durchzuführen, da man immer den verbleibenden (Programm-)Teil von GitHub herunterladen kann, ohne zu riskieren, interne ASF-Dateien zu beschädigen, z. B. durch ein fehlerhaftes Backup.

Die `log.txt` Datei enthält das Protokoll, das durch Ihre letzte ASF-Ausführung erzeugt wurde. Diese Datei enthält keine sensiblen Informationen und ist äußerst nützlich, wenn es um Probleme, Abstürze oder einfach nur als Information an Sie geht, was während der letzten Ausführung von ASF passiert ist. Wir werden sehr oft nach dieser Datei fragen, wenn Sie auf Probleme oder Fehler stoßen. ASF verwaltet diese Datei automatisch für Sie, aber Sie können das **[Protokollierungsmodul](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Logging-de-DE#Protokollierung)** weiter optimieren, wenn Sie ein fortgeschrittener Benutzer sind.

`config` Verzeichnis ist der Ort, der die Konfiguration für ASF enthält, einschließlich aller seiner Bots.

`ASF.json` ist eine globale ASF-Konfigurationsdatei. Diese Konfiguration wird verwendet, um anzugeben, wie sich ASF als Prozess verhält, was alle Bots und das Programm selbst betrifft. Dort finden Sie globale Eigenschaften, wie ASF-Prozesseigentümer, automatische Aktualisierungen oder Debugging.

`BotName.json` ist eine Konfiguration der gegebenen Bot-Instanz. Diese Konfiguration wird verwendet, um das Verhalten einer gegebenen Bot-Instanz festzulegen, daher sind diese Einstellungen nur für diesen Bot spezifisch und nicht für andere bestimmt. Dies ermöglicht es Ihnen, Bots mit verschiedenen Einstellungen zu konfigurieren, und nicht unbedingt alle funktionieren auf die gleiche Weise. Jeder Bot wird mit einer eindeutigen Kennzeichnung benannt, die Sie anstelle von `BotName` auswählen.

Neben den Konfigurationsdateien verwendet ASF auch das Verzeichnis `config` zum Speichern von Datenbanken.

`ASF.db` ist eine globale ASF-Datenbankdatei. Es fungiert als globaler dauerhafter Speicher und wird zum Speichern verschiedener Informationen im Zusammenhang mit dem ASF-Prozess verwendet, wie z.B. IPs von lokalen Steam-Servern. **Sie sollten diese Datei nicht bearbeiten**.

`BotName.db` ist eine Datenbank der jeweiligen Bot-Instanz. Diese Datei wird verwendet, um wichtige Daten der jeweiligen Bot-Instanz im dauerhaften Speicher zu speichern, wie z.B. Anmeldeschlüssel oder ASF-2FA. **Sie sollten diese Datei nicht bearbeiten**.

`BotName.keys` ist eine spezielle Datei, die zum Importieren von Produkt-Schlüsseln in den **[Hintergrundproduktschlüsselaktivierer ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer-de-DE)** verwendet werden kann. Es ist nicht zwingend erforderlich und wird nicht generiert, aber von ASF anerkannt. Diese Datei wird nach dem erfolgreichen Import der Produkt-Schlüssel automatisch gelöscht.

`BotName.maFile` ist eine spezielle Datei, die für den Import von **[ASF-2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication-de-DE)** verwendet werden kann. Es ist nicht zwingend erforderlich und wird nicht generiert, aber von ASF erkannt, wenn Ihr `BotName` ASF-2FA bislang nicht verwendet. Diese Datei wird nach erfolgreichem Import von ASF-2FA automatisch gelöscht.

---

## JSON-Strukturierung

Jede Konfigurationseigenschaft hat Ihren Typ. Der Typ der Variable definiert Werte, die für sie gültig sind. Sie können nur Werte verwenden, die für einen bestimmten Typ gültig sind – wenn Sie einen ungültigen Wert verwenden, dann kann ASF die Konfiguration nicht auslesen.

**Wir empfehlen dringend, den ConfigGenerator für die Generierung von Konfigurationen** zu verwenden. Dieser handhabt den größten Teil der Low-Level-Aufgaben (z. B. die Typ-Validierung) für Sie, sodass Sie nur die richtigen Werte eingeben und auch die unten angegebenen Variablentypen nicht verstehen müssen. Dieser Abschnitt ist hauptsächlich für Personen gedacht, die Konfigurationen manuell erstellen/bearbeiten, damit sie wissen, welche Werte sie verwenden können.

Die von ASF verwendeten Typen sind native C#-Typen, die im Folgenden aufgeführt werden:

---

`bool` – Boolean-Typ der nur die Werte `true` und `false` akzeptiert.

Beispiel: `"Enabled": true`

---

`byte` – Unsignierter Byte-Typ der nur ganze Zahlen von `0` bis `255` (einschließlich) akzeptiert.

Beispiel: `"ConnectionTimeout": 90`

---

`ushort` – Unsignierter Short-Typ der nur ganze Zahlen von `0` bis (einschließlich) `65535` akzeptiert.

Beispiel: `"WebLimiterDelay": 300`

---

`uint` – Unsignierter Ganzzahl-Typ (integer), der nur ganze Zahlen von `0` bis (einschließlich) `4294967295` akzeptiert.

---

`ulong` – Unsignierter long integer Typ, der nur ganze Zahlen von `0` bis (einschließlich) `18446744073709551615` akzeptiert.

Beispiel: `"SteamMasterClanID": 103582791440160998`

---

`string` – Zeichenketten-Typ, der jede beliebige Zeichenfolge akzeptiert, einschließlich der leeren Folge `""` und `null`. Leere Sequenz und `null` Wert werden von ASF gleich behandelt, sodass Sie es sich aussuchen können, welche Sie verwenden möchten (wir bleiben bei `null`).

Beispiele: `"SteamLogin": null`, `"SteamLogin": ""`, `"SteamLogin": "MeinLogin"`

---

`Guid?` – Nullwerte zulassender UUID-Typ, in JSON-kodiert als Zeichenkette. UUID besteht aus 32 Hexadezimalzeichen, im Bereich von `0` bis `9` und `` bis `f`. ASF akzeptiert verschiedene gültige Formate – Kleinbuchstaben, Großbuchstaben, mit und ohne Bindestriche. Zusätzlich zu gültiger UUID, da diese Eigenschaft nullable ist (ein spezieller Wert von `Null` wird akzeptiert), um einen Mangel an UUID anzugeben.

Beispiele: `"LicenseID": null`, `"LicenseID": "f6a0529813f74d119982eb4fe43a9a24"`

---

`ImmutableList<valueType>` – Unveränderliche Sammlung (set) von eindeutigen Werten im gegebenen `valueType`. In JSON ist es definiert als Array (Anordnung) von Elementen im gegebene `valueType`. ASF verwendet `list` um anzugeben, dass die angegebene Variable mehrere Werte unterstützt und deren Reihenfolge relevant sein kann.

Beispiel für `ImmutableList<byte>`: `"FarmingOrders": [15, 11, 7]`

---

`ImmutableHashSet<valueType>` – Unveränderliche Sammlung (Satz) von eindeutigen Werten in gegebenen `valueType`. In JSON ist es definiert als Array (Anordnung) von Elementen des gegebenen `valueType`. ASF verwendet `HashSet`, um anzugeben, dass eine angegebene Variable nur für eindeutige Werte Sinn ergibt (und deren Reihenfolge unwichtig ist). Daher ignoriert es bewusst alle potenziellen Duplikate während des Parsen (falls sie trotzdem angegeben wurden).

Beispiel für `ImmutableHashSet<uint>`: `"Blacklist": [267420, 303700, 335590]`

---

`ImmutableDictionary<keyType, valueType>` – Unveränderliches Wörterbuch (Map) das einen in seinem `keyType` angegebenen einzigartigen Schlüssel auf den in seinem `valueType` angegebenen Wert abbildet. In JSON wird es als Objekt mit Schlüssel-Wert-Paaren definiert. Bedenken Sie, dass `keyType` in diesem Fall immer angegeben wird, auch wenn es sich um einen Wert-Typ wie `ulong` handelt. Es gibt auch eine strenge Anforderung, dass der Schlüssel auf der gesamten map (Zuordnung) eindeutig ist, diesmal ebenfalls von JSON erzwungen.

Beispiel für `ImmutableDictionary<ulong, byte>`: `"SteamUserPermissions": { "76561198174813138": 3, "76561198174813137": 1 }`

---

`flags` - Das Attribut Flags kombiniert mehrere verschiedene Eigenschaften zu einem Endwert, indem es bitweise Operationen anwendet. Auf diese Weise können Sie jede mögliche Kombination aus verschiedenen zulässigen Werten gleichzeitig wählen. Der Endwert wird als Summe aller Werte der aktivierten Optionen berechnet.

Zum Beispiel, wenn folgende Werte angegeben werden:

| Wert | Name |
| ---- | ---- |
| 0    | None |
| 1    | A    |
| 2    | B    |
| 4    | C    |

Die Verwendung von `B + C` würde zu einem Wert von `6` führen, die Verwendung von `A + C` würde einem Wert von `5` ergeben, die Verwendung von `C` würde zu einem Wert von `4` führen und so weiter. Dies ermöglicht es Ihnen, jede mögliche Kombination von aktivierten Werten zu erstellen – wenn Sie sich dazu entschieden haben, alle zu aktivieren, indem Sie `None + A + B + C` wählen, erhalten Sie den Wert von `7`. Außerdem ist zu beachten, dass das Flag mit dem Wert `0` per Definition in allen anderen verfügbaren Kombinationen aktiviert ist, daher ist es sehr oft ein Flag, das nichts Bestimmtes aktiviert (wie `None`).

Wie Sie sehen können, haben wir im obigen Beispiel 3 verfügbare Flags zum Ein- und Ausschalten (`A`, `B`, `C`), und `8` mögliche Werte insgesamt:
- `None -> 0`
- `A -> 1`
- `B -> 2`
- `A + B -> 3`
- `C -> 4`
- `A + C -> 5`
- `B + C -> 6`
- `A + B + C -> 7`

Zum Beispiel: `"SteamProtocols": 7`

---

## Kompatibilitätsstrukturierung

Aufgrund von JavaScript-Einschränkungen können Eigenschaften (Property) mit einfachen `ulong` Felder in JSON nicht korrekt serialisiert werden, wenn der webbasierte ConfigGenerator verwendet wird. Daher werden `ulong` Felder als Strings mit `s_` Präfix in der resultierenden Konfiguration dargestellt. Dazu gehört zum Beispiel `"SteamOwnerID": 76561198006963719`, die von unserem Konfigurationsgenerator als `"s_SteamOwnerID" geschrieben wird: "76561198006963719"`. ASF enthält die richtige Logik für die automatische Verarbeitung dieses Zeichenketten-Mappings, sodass `s_` Einträge in Ihren Konfigurationen tatsächlich gültig und korrekt generiert sind. Wenn Sie selbst Konfigurationen generieren, empfehlen wir, nach Möglichkeit an den ursprünglichen `ulong` Feldern festzuhalten, aber wenn Sie dazu nicht in der Lage sind, können Sie auch diesem Schema folgen und sie als Zeichenketten mit dem `s_` Präfix an Ihren Namen kodieren. Wir hoffen, diese JavaScript-Einschränkung irgendwann aufheben zu können.

---

## Konfigurationskompatibilität

Es ist für ASF oberste Priorität, mit älteren Konfigurationen kompatibel zu bleiben. Wie Sie bereits wissen sollten, werden fehlende Konfigurationseigenschaften mit den jeweiligen **Standardwerten** ausgeführt. Wenn also eine neue Konfigurationseigenschaft in einer neuen Version von ASF eingeführt wird, bleiben all Ihre Konfigurationen **kompatibel** mit der neuen Version, und ASF wird diese neue Konfigurationseigenschaft so behandeln, wie sie mit Ihrem **Standardwert** definiert wäre. Sie können jederzeit Konfigurationseigenschaften nach Ihren Wünschen hinzufügen, entfernen oder bearbeiten.

Wir empfehlen, definierte Konfigurationseigenschaften nur auf die zu ändernden Eigenschaften zu beschränken, da Sie auf diese Weise automatisch Standardwerte für alle anderen vererben; nicht nur Ihre Konfiguration sauber halten, sondern auch die Kompatibilität erhöhen, falls wir beschließen, einen Standardwert für Eigenschaften zu ändern, die Sie nicht explizit selbst festlegen möchten (z. B. `WebLimiterDelay`).

Aufgrund der oben genannten Umstände wird ASF Ihre Konfigurationen automatisch migrieren/optimieren, indem sie sie neu formatieren und Felder mit Standardwert entfernen. Sie können dieses Verhalten mit `--no-config-migrate` **[Befehlszeilenargument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments-de-DE#arguments)** deaktivieren, wenn Sie einen bestimmten Grund haben. Zum Beispiel stellen Sie schreibgeschützte Konfigurationsdateien zur Verfügung und Sie möchten nicht, dass ASF diese modifiziert.

---

## Automatisches Nachladen

ASF bemerkt Änderungen an den Konfigurationen „on-the-fly“ – dank dem ASF automatisch:
- Eine neue Bot-Instanz erstellen (und startet diese bei Bedarf), wenn Sie die Konfiguration erstellen
- Stoppt (falls erforderlich) und entfernt alte Bot-Instanz, wenn Sie Ihre Konfiguration löschen
- Stoppt (und startet bei Bedarf) eine beliebige Bot-Instanz, wenn Sie Ihre Konfiguration bearbeiteen
- Startet den Bot (falls erforderlich) unter neuem Namen neu, wenn Sie seine Konfiguration umbenennen

All dies ist transparent und wird automatisch durchgeführt, ohne dass das Programm neu gestartet oder andere (nicht betroffene) Bot-Instanzen beendet werden müssen.

Darüber hinaus wird sich ASF auch selbst neu starten (wenn `AutoRestart` es erlaubt), wenn Sie die ASF-Kern-Konfiguration `ASF.json` ändern. Ebenso wird das Programm beendet, wenn Sie es löschen oder umbenennen.

Sie können dieses Verhalten mit `--no-config-watch` **[Befehlszeilenargument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments-de-DE#arguments)** deaktivieren, wenn Sie einen bestimmten Grund haben. Zum Beispiel möchten Sie von ASF nicht auf Dateiänderungen im Ordner `config` reagieren.