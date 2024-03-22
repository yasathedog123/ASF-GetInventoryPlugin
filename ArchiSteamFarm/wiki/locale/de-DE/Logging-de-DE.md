# Protokollierung

ASF ermöglicht es Ihnen, Ihr eigenes benutzerdefiniertes Protokollierungsmodul zu konfigurieren, das während der Ausführung verwendet wird. Dies funktioniert, indem Sie eine spezielle Datei mit dem Namen `NLog.config` in dem Programmverzeichnis ablegen. Sie können die gesamte Dokumentation über NLog im **[NLog Wiki](https://github.com/NLog/NLog/wiki/Configuration-file)** nachlesen, zusätzlich werden Sie auch hier nützliche Beispiele dazu finden.

---

## Standard-Protokollierung

Standardmäßig protokolliert ASF in `ColoredConsole` (Standardausgabe) und `File`. `File` Protokollierung beinhaltetet die Datei `log.txt` im Programmverzeichnis und das `logs` Verzeichnis für Archivierungszwecke.

Die Verwendung einer benutzerdefinierten NLog Konfiguration deaktiviert automatisch die standard ASF Konfiguration, welche dami **komplett** durch Ihre Konfiguration überschrieben wird. Das bedeutet, dass, falls Sie z. B. unsere `ColoredConsole` Ausgabe verwenden möchten, Sie diese **selber** definieren müssen. Dies erlaubt es Ihnen nicht nur **extra** Protokollierungsziele hinzuzufügen, sondern auch die **Standardziele** zu verändern oder deaktivieren.

Wenn Sie die standardmäßige ASF-Protokollierung ohne irgendwelche Veränderung verwenden möchten, müssen Sie nichts tun – auch brauchen Sie dies nicht in der `NLog.config` zu definieren. Verwenden Sie die `NLog.config` nicht, wenn Sie die standardmäßige ASF-Protokollierung nicht verändern möchten. Zum Vergleich: Das Äquivalent zur fest definierten ASF-Protokollierung (Standard) wäre:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" layout="${date:format=yyyy-MM-dd HH\:mm\:ss}|${processname}-${processid}|${level:uppercase=true}|${logger}|${message}${onexception:inner= ${exception:format=toString,Data}}" />
    <target xsi:type="File" name="File" archiveFileName="${currentdir}/logs/log.{#}.txt" archiveNumbering="Rolling" archiveOldFileOnStartup="true" cleanupFileName="false" concurrentWrites="false" deleteOldFileOnStartup="true" fileName="${currentdir}/log.txt" layout="${date:format=yyyy-MM-dd HH\:mm\:ss}|${processname}-${processid}|${level:uppercase=true}|${logger}|${message}${onexception:inner= ${exception:format=toString,Data}}" maxArchiveFiles="10" />

    <!-- Unteres wird aktiv, sobald die IPC-Schnittstelle von ASF gestartet wird -->
    <target type="History" name="History" layout="${date:format=yyyy-MM-dd HH\:mm\:ss}|${processname}-${processid}|${level:uppercase=true}|${logger}|${message}${onexception:inner= ${exception:format=toString,Data}}" maxCount="20" />
  </targets>

  <rules>
    <!-- Die folgenden Einträge geben die ASP.NET (IPC)-Protokollierung an, wir deklarieren diese, damit unser letzter Debug-Catch-All standardmäßig keine ASP.NET Protokolle enthält -->
    <logger name="Microsoft.*" finalMinLevel="Warn" writeTo="ColoredConsole" />
    <logger name="Microsoft.Hosting.Lifetime" finalMinLevel="Info" writeTo="ColoredConsole" />
    <logger name="System.*" finalMinLevel="Warn" writeTo="ColoredConsole" />

    <logger name="*" minlevel="Debug" writeTo="ColoredConsole" />

    <!-- Die folgenden Einträge geben die ASP.NET (IPC)-Protokollierung an, wir deklarieren diese, damit unser letzter Debug-Catch-All standardmäßig keine ASP.NET Protokolle enthält -->
    <logger name="Microsoft.*" finalMinLevel="Warn" writeTo="File" />
    <logger name="Microsoft.Hosting.Lifetime" finalMinLevel="Info" writeTo="File" />
    <logger name="System.*" finalMinLevel="Warn" writeTo="File" />

    <logger name="*" minlevel="Debug" writeTo="File" />

    <!-- Unteres wird aktiv, wenn die IPC-Schnittstelle von ASF aktiviert ist -->
    <!-- Die folgenden Einträge geben die ASP.NET (IPC)-Protokollierung an, wir deklarieren diese, damit unser letzter Debug-Catch-All standardmäßig keine ASP.NET Protokolle enthält -->
    <logger name="Microsoft.*" finalMinLevel="Warn" writeTo="History" />
    <logger name="Microsoft.Hosting.Lifetime" finalMinLevel="Info" writeTo="History" />
    <logger name="System.*" finalMinLevel="Warn" writeTo="History" />

    <logger name="*" minlevel="Debug" writeTo="History" />
  </rules>
</nlog>
```

---

## ASF Integration

ASF enthält einige nette Quellcode-Tricks, die die Integration mit NLog verbessern und es Ihnen ermöglichen bestimmte Nachrichten leichter zu erfassen.

Die NLog-spezifische Variable `${logger}` wird immer die Quelle der Nachricht anzeigen – es wird entweder `BotName` von einem Ihrer Bots sein, oder `ASF` wenn die Nachricht direkt vom ASF-Prozess kommt. Auf diese Weise können Sie Nachrichten leicht abfangen, die bestimmte Bot(s) oder ASF-Prozesse (nur) berücksichtigen, anstatt sie alle, basierend auf dem Namen des Loggers.

ASF versucht, Meldungen entsprechend den von NLog bereitgestellten logging (Protokoll) Warnstufen zu kennzeichnen, was es Ihnen ermöglicht, nur bestimmte Meldungen von bestimmten Protokollebenen, statt von allen zu erhalten. Selbstverständlich ist es unmöglich, die Protokollierungsstufe für eine bestimmte Nachricht anzupassen, da sie auf die Dringlichkeit der Nachricht ausgerichtet ist, aber Sie können ASF definitiv die Häufigkeit erhöhen oder verringern, wie Sie es für richtig halten.

ASF protokolliert zusätzliche Informationen, z. B. Benutzer-/Chat-Nachrichten auf der `Trace` Protokollierungsebene. Die standardmäßige ASF-Protokollierung schreibt nur die Ebene `Debug` und darüber; weshalb diese Informationen verborgen werden, da sie für die Mehrheit der Benutzer nicht benötigt werden, sowie die Ausgabe mit potenziell wichtigeren Nachrichten „zumüllt“. Sie können diese Informationen jedoch verwenden, indem Sie Logging-Ebene `Trace` wieder aktivieren, insbesondere in Kombination mit dem Protokollierung eines einzigen bestimmten Bots Ihrer Wahl, mit einem bestimmten Event, an dem Sie interessiert sind.

Im Allgemeinen versucht ASF, es Ihnen so einfach und bequem wie möglich zu machen, nur die Nachrichten zu protokollieren, die Sie wünschen, anstatt Sie zu zwingen, diese manuell durch Drittanbieterprogramme wie `grep` (oder ähnliche) zu filtern. Konfigurieren Sie NLog einfach wie unten erläutert und Sie sollten in der Lage sein, auch sehr komplexe Protokollierungsregeln mit benutzerdefinierten Zielen, wie beispielsweise ganze Datenbanken, zu spezifizieren.

In Bezug auf die Versionierung versucht ASF immer die aktuellste Version von NLog zu liefern, die zum Zeitpunkt der ASF-Version unter **[NuGet](https://www.nuget.org/packages/NLog)** verfügbar ist. Es sollte kein Problem sein, alle Funktionen in ASF zu verwenden, die Sie im NLog-Wiki finden – stellen Sie sicher, dass Sie auch die neueste ASF verwenden.

Im Rahmen der ASF-Integration bietet ASF auch Unterstützung für zusätzliche ASF-NLog-Protokollierungsziele, die im Folgenden erläutert werden.

---

## Beispiele

Lassen Sie uns mit etwas Einfachem anfangen. Wir werden nur das Ziel **[`ColoredConsole`](https://github.com/nlog/nlog/wiki/ColoredConsole-target)** verwenden. Unsere initiale `NLog.config` wird wie folgt aussehen:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" />
  </targets>

  <rules>
    <logger name="*" minlevel="Debug" writeTo="ColoredConsole" />
  </rules>
</nlog>
```

Die Erklärung der obigen Konfiguration ist ziemlich einfach – wir definieren ein **Protokollziel**, das `ColoredConsole` ist, dann leiten wir **alle „Schreiber“** (`*`) der Ebene `Debug` und höher zum Ziel `ColoredConsole` um, das wir zuvor definiert haben. Das ist alles.

Wenn Sie ASF jetzt mit obiger `NLog.config` starten, wird nur `ColoredConsole` target aktiv sein, und ASF wird nicht in `File` schreiben, unabhängig von der fest programmierten ASF NLog-Konfiguration.

Nehmen wir an, wir mögen das Standardformat `${longdate}|${level:uppercase=true}|${logger}|${message}` nicht und wir möchten nur die Meldung protokollieren. Wir können dies erreichen, indem wir **[Layout](https://github.com/nlog/nlog/wiki/Layouts)** unseres Ziels ändern.

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" layout="${message}" />
  </targets>

  <rules>
    <logger name="*" minlevel="Debug" writeTo="ColoredConsole" />
  </rules>
</nlog>
```

Wenn Sie ASF jetzt starten, werden Sie feststellen, dass Datum, Level und Logger-Name verschwunden sind – und nur noch ASF-Nachrichten im Format `Function() Message` übrigbleiben.

Wir können die Konfiguration auch so ändern, dass sie mehr als ein Ziel protokolliert. Lasst uns gleichzeitig [`ColoredConsole`](https://github.com/NLog/NLog/wiki/ColoredConsole-target) und **[`File`](https://github.com/nlog/nlog/wiki/File-target)** protokollieren.

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" />
    <target xsi:type="File" name="File" fileName="${currentdir}/NLog.txt" deleteOldFileOnStartup="true" />
  </targets>

  <rules>
    <logger name="*" minlevel="Debug" writeTo="ColoredConsole" />
    <logger name="*" minlevel="Debug" writeTo="File" />
  </rules>
</nlog>
```

Fertig! Wir werden jetzt alles in die `ColoredConsole` und `File` protokollieren. Haben Sie bemerkt, dass Sie auch benutzerdefinierte Dateiname(n) (`fileName`) und zusätzliche Optionen angeben können?

Schließlich verwendet ASF verschiedene Protokollebenen, um es Ihnen leichter zu machen, zu verstehen, was vor sich geht. Wir können diese Informationen verwenden, um den Schweregrad des Protokolls zu ändern. Nehmen wir an, wir wollen alles (`Trace`) zur Datei (`File`) protokollieren, aber nur `Warning` und darüberliegende **[Protokollierungssufen](https://github.com/NLog/NLog/wiki/Configuration-file#log-levels)** zur `ColoredConsole`. Wir können das erreichen, indem wir unsere `rules` modifizieren:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" />
    <target xsi:type="File" name="File" fileName="${currentdir}/NLog.txt" deleteOldFileOnStartup="true" />
  </targets>

  <rules>
    <logger name="*" minlevel="Warn" writeTo="ColoredConsole" />
    <logger name="*" minlevel="Trace" writeTo="File" />
  </rules>
</nlog>
```

Das war’s, jetzt zeigt unsere `ColoredConsole` nur noch Warnungen und darüber an, während sie immer noch alles in `File` protokolliert. Sie können es weiter optimieren, um z. B. nur `Info` und darunter zu protokollieren, und so weiter.

Lassen Sie uns zuletzt etwas weiter fortgeschrittenes tun und alle Nachrichten in einer Datei protokollieren, aber nur von einem Bot namens `LogBot`.

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" />
    <target xsi:type="File" name="LogBotFile" fileName="${currentdir}/LogBot.txt" deleteOldFileOnStartup="true" />
  </targets>

  <rules>
    <logger name="*" minlevel="Debug" writeTo="ColoredConsole" />
    <logger name="LogBot" minlevel="Trace" writeTo="LogBotFile" />
  </rules>
</nlog>
```

Sie können sehen, wie wir die ASF-Integration oben verwendet haben und leicht zu unterscheidende Quelle der Nachricht basierend auf der `${logger}` Variable.

---

## Erweiterte Nutzung

Die obigen Beispiele sind ziemlich einfach und sollen Ihnen zeigen, wie einfach es ist, eigene Protokollierungsregeln zu definieren, die mit ASF verwendet werden können. Sie können NLog für verschiedene Dinge verwenden, einschließlich komplexer Ziele (wie das Führen von Protokollen in `Database`), Protokollrotation (wie das Entfernen alter `File`-Protokolle), die Verwendung benutzerdefinierter `Layout`s, Deklaration eigener `<when>` Protokollierungsfilter und vieles mehr. Ich empfehle Ihnen, die gesamte **[NLog-Dokumentation](https://github.com/nlog/nlog/wiki/Configuration-file)** durchzulesen, um mehr über jede verfügbare Option zu erfahren, damit Sie das ASF-Protokoll-Modul so anpassen können, wie Sie möchten. Es ist ein wirklich leistungsstarkes Programm und die Anpassung der ASF-Protokollierung war nie einfacher.

---

## Einschränkungen

ASF deaktiviert vorübergehend **alle** Regeln, die `ColoredConsole` oder `Console`-Ziele beinhalten, wenn Benutzereingaben erwartet werden. Wenn Sie also die Protokollierung für andere Ziele beibehalten möchten, auch wenn ASF Benutzereingaben erwartet werden, sollten Sie diese Ziele mit Ihren eigenen Regeln definieren, wie in den obigen Beispielen gezeigt, anstatt die gleiche Regel für viele Ziele in `writeTo` anzuwenden (es sei denn, dies ist Ihr gewünschtes Verhalten). Die vorübergehende Deaktivierung von Konsole-Zielen wird durchgeführt, um die Konsole sauber zu halten, wenn auf Benutzereingaben gewartet wird.

---

## Chat-Protokollierung

ASF bietet erweiterte Unterstützung für das Chatprotokolle, indem es nicht nur alle empfangene/gesendete Nachrichten auf `Trace` Logging-Ebene aufzeichnet, sondern auch zusätzliche Informationen zu Ihnen in **[Ereignisvariablen](https://github.com/NLog/NLog/wiki/EventProperties-Layout-Renderer)** anzeigt. Dies liegt daran, dass wir Chat-Nachrichten ohnehin als Befehle behandeln müssen, sodass es uns nichts kostet, diese Ereignisse zu protokollieren, um es Ihnen zu ermöglichen, zusätzliche Logik hinzuzufügen (um z. B. ASF zu einem persönlichen Steam-Chat-Archiv zu machen).

### Ereigniseigenschaften

| Name        | Beschreibung                                                                                                                                                                                                                                    |
| ----------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Echo        | Typ `bool`. Dies wird auf `true` gesetzt, wenn die Nachricht von uns an den Empfänger gesendet wird, und andernfalls auf `false`.                                                                                                               |
| Message     | Typ `string`. Dies ist die eigentliche gesendete/empfangene Nachricht.                                                                                                                                                                          |
| ChatGroupID | Typ `ulong`. Dies ist die ID des Gruppen-Chats für gesendete/empfangene Nachrichten. Standardwert von `0`, wenn kein Gruppen-Chat für die Übertragung dieser Nachricht verwendet wird.                                                          |
| ChatID      | Typ `ulong`. Dies ist die ID des `ChatGroupID` Kanals für gesendete/empfangene Nachrichten. Wird `0` sein, wenn kein Gruppen-Chat für die Übertragung dieser Nachricht verwendet wird.                                                          |
| SteamID     | Typ `ulong`. Dies ist die ID des Steam-Benutzers für gesendete/empfangene Nachrichten. Kann `0` sein, sofern kein bestimmter Benutzer an der Nachrichtenübertragung beteiligt ist (z. B. wenn wir eine Nachricht an einen Gruppen-Chat senden). |

### Beispiel

Dieses Beispiel basiert auf unserem `ColoredConsole` Basisbeispiel oben. Bevor Sie versuchen, es zu verstehen, empfehle ich Ihnen dringend, einen Blick **[hierrauf](#beispiele)** zu werfen, um zunächst die Grundlagen der NLog-Protokollierung zu erfahren.

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" />
    <target xsi:type="File" name="ChatLogFile" fileName="${currentdir}/${event-properties:item=ChatGroupID}-${event-properties:item=ChatID}${when:when='${event-properties:item=ChatGroupID}' == 0:inner=-${event-properties:item=SteamID}}.txt" layout="${date:format=yyyy-MM-dd HH\:mm\:ss} ${event-properties:item=Message} ${when:when='${event-properties:item=Echo}' == true:inner=-&gt;:else=&lt;-} ${event-properties:item=SteamID}" />
  </targets>

  <rules>
    <logger name="*" minlevel="Debug" writeTo="ColoredConsole" />
    <logger name="MainAccount" level="Trace" writeTo="ChatLogFile">
      <filters defaultAction="Log">
        <when condition="not starts-with('${message}','OnIncoming') and not starts-with('${message}','SendMessage')" action="Ignore" />
      </filters>
    </logger>
  </rules>
</nlog>
```

Wir haben mit unserem einfachen Beispiel `ColoredConsole` begonnen und es weiter ausgebaut. In erster Linie haben wir eine permanente Chat-Logdatei für jeden Gruppenkanal und Steam-Benutzer erstellt – dies ist möglich dank zusätzlicher Eigenschaften, die ASF uns auf ausgefallene Weise zur Verfügung stellt. Wir haben uns auch für ein benutzerdefiniertes Layout entschieden, das nur das aktuelle Datum, die Nachricht, die gesendet/empfangen Information und den Steam-Benutzer selbst schreibt. Schließlich haben wir unsere Chat-Protokollierungsregel nur für die Ebene `Trace` aktiviert, nur für unseren `MainAccount` Bot und nur für Funktionen im Zusammenhang mit der Chat-Protokollierung (`OnIncoming*`, der für den Empfang von Nachrichten und Echos verwendet wird, und `SendMessage*` für das Senden von ASF-Nachrichten).

Das obige Beispiel erzeugt die Datei `0-0-76561198069026042.txt`, wenn man mit **[ArchiBot](https://steamcommunity.com/profiles/76561198069026042)** spricht:

```text
2018-07-26 01:38:38 Wie geht es dir? -> 76561198069026042
2018-07-26 01:38:38 /me Mir geht es gut, und dir? <- 76561198069026042
```

Natürlich ist dies nur ein funktionierendes Beispiel mit ein paar schönen Layout-Tricks, die in praktischer Hinsicht gezeigt werden. Sie können diese Idee weiter auf Ihre eigenen Bedürfnisse ausdehnen, z. B. zusätzliche Filterung, benutzerdefinierte Reihenfolge, persönliches Layout, Aufnahme nur empfangener Nachrichten, etc.

---

## ASF-Ziele

Zusätzlich zu den standardmäßigen NLog-Protokollierungszielen (z. B. `ColoredConsole` und `File` siehe oben) können Sie auch benutzerdefinierte ASF-Protokollierungsziele verwenden.

Um die maximale Vollständigkeit zu gewährleisten, erfolgt die Definition der ASF-Ziele nach der NLog-Dokumentationskonvention.

---

### SteamTarget

Wie Sie erraten können, verwendet dieses Ziel Steam-Chatnachrichten zum Protokollieren von ASF-Nachrichten. Sie können es so konfigurieren, dass es entweder einen privaten oder Gruppen-Chat oder einen verwendet. Zusätzlich zur Angabe eines Steam-Ziels für Ihre Nachrichten können Sie den Namen `botName` des Bots angeben, der diese senden soll.

Wird in allen von ASF verwendeten Umgebungen unterstützt.

---

#### Konfigurationssyntax
```xml
<targets>
  <target type="Steam"
          name="String"
          layout="Layout"
          chatGroupID="Ulong"
          steamID="Ulong"
          botName="Layout" />
</targets>
```

Lesen Sie  mehr über die Verwendung der [Konfigurationsdatei](https://github.com/NLog/NLog/wiki/Configuration-file).

---

#### Parameter

##### Allgemeine Optionen
_name_ – Name des Ziels.

---

##### Layout Optionen
_layout_ – Der zu rendernde Text. [Layout](https://github.com/NLog/NLog/wiki/Layouts) Erforderlich. Standard: `${level:uppercase=true}|${logger}|${message}`

---

##### SteamTarget Optionen

_chatGroupID_ – ID des Gruppen-Chats, der als 64-Bit lange, unsignierte Ganzzahl deklariert wurde. Nicht erforderlich. Standardmäßig ist `0` voreingestellt, was die Gruppen-Chat-Funktion deaktiviert und stattdessen einen privaten Chat verwendet. Wenn aktiviert (auf einen Nicht-Nullwert gesetzt), fungiert die folgende Variable `steamID` als `chatID` und gibt die ID des Kanals in diesem `chatGroupID` an, an den der Bot Nachrichten senden soll.

_steamID_ – SteamID deklariert als 64-Bit lange unsignierte ganze Zahl des Ziel-Steam-Benutzers (wie `SteamOwnerID`), oder Ziel `chatID` (wenn `chatGroupID` eingestellt ist). Erforderlich. Standardwert von `0`, wodurch das Protokollierungsziel vollständig deaktiviert wird.

_botName_ – Name des Bots (wie er von ASF erkannt wird, Groß-/Kleinschreibung beachten), der Nachrichten an `steamID` senden wird; oben erklärt. Nicht erforderlich. Standardmäßig ist `null` voreingestellt, was automatisch **jeden** aktuell verbundenen Bot auswählt. Es wird empfohlen, diesen Wert entsprechend einzustellen, da `SteamTarget` nicht viele Steam-Einschränkungen berücksichtigt, z. B. die Tatsache, dass Sie `steamID` des Ziels auf Ihrer Freundeliste haben müssen. Diese Variable ist als [Layout](https://github.com/NLog/NLog/wiki/Layouts) Typ definiert, daher können Sie in ihr eine spezielle Syntax verwenden, zum Beispiel `${logger}` um den Bot zu verwenden, der die Nachricht generiert hat.

---

#### SteamTarget Beispiele

Um alle Nachrichten aus `Debug` Ebene(n und darüber), von dem Bot namens `MyBot` zu steamID von `76561198006963719` zu schreiben, sollten Sie `NLog.config` ähnlich wie unten verwenden:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target type="Steam" name="Steam" steamID="76561198006963719" botName="MyBot" />
  </targets>

  <rules>
    <logger name="*" minlevel="Debug" writeTo="Steam" />
  </rules>
</nlog>
```

**Hinweis:** Unser `SteamTarget` ist ein benutzerdefiniertes Ziel, also sollten Sie sicherstellen, dass Sie es als `type="Steam"`, NICHT `xsi:type="Steam"` deklarieren, da „xsi“ für offizielle, von NLog unterstützte Ziele reserviert ist.

Wenn Sie ASF mit `NLog.config` ähnlich wie oben gestartet haben, beginnt `MyBot` damit, dem Steam-Benutzer `76561198006963719` alle üblichen ASF-Protokollmeldungen zu senden. Bedenken Sie, dass `MyBot` verbunden sein muss, um Nachrichten zu senden. Somit werden alle anfänglichen ASF-Nachrichten, die stattfanden, bevor unser Bot sich mit dem Steam-Netzwerk verbinden konnte, nicht weitergeleitet.

Natürlich verfügt `SteamTarget` über alle typischen Funktionen, die von generischem `TargetWithLayout` erwarten werden. So können Sie es in Verbindung mit z. B. benutzerdefinierten Layouts, Namen oder erweiterten Protokollierungsregeln verwenden. Das obige Beispiel ist lediglich ein grundlegendes Beispiel.

---

#### Screenshots

![Screenshot](https://i.imgur.com/5juKHMt.png)

---

### HistoryTarget

Dieses Ziel wird intern von ASF verwendet, um eine Protokollhistorie mit fester Größe im `/Api/NLog` Endpunkt der **[ASF-API](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-de-DE#asf-api)** bereitzustellen, die anschließend von ASF-UI und anderen Programmen verwendet werden kann. Im Allgemeinen sollten Sie dieses Ziel nur dann definieren, wenn Sie bereits eine benutzerdefinierte NLog-Konfiguration für andere Anpassungen verwenden und das Protokoll auch in der ASF-API angezeigt werden soll, z. B. für ASF-UI. Es kann auch angegeben werden, wenn Sie das Standardlayout oder `maxCount` (die maximale Anzahl) der gespeicherten Nachrichten ändern möchten.

Wird in allen von ASF verwendeten Umgebungen unterstützt.

---

#### Konfigurationssyntax
```xml
<targets>
 <target type="History"
     name="String"
     layout="Layout"
     maxCount="Byte" />
</targets>
```

Lesen Sie  mehr über die Verwendung der [Konfigurationsdatei](https://github.com/NLog/NLog/wiki/Configuration-file).

---

#### Parameter

##### Allgemeine Optionen
_name_ – Name des Ziels.

---

##### Layout Optionen
_layout_ – Der zu rendernde Text. [Layout](https://github.com/NLog/NLog/wiki/Layouts) Erforderlich. Standard: `${date:format=yyyy-MM-dd HH\:mm\:ss}|${processname}-${processid}|${level:uppercase=true}|${logger}|${message}${onexception:inner= ${exception:format=toString,Data}}`

---

##### HistoryTarget Optionen

_maxCount_ – Maximale Anzahl der gespeicherten Protokolle für die Abrufhistorie. Nicht erforderlich. Der Standardwert `20` ist eine gute Balance für die Bereitstellung der Anfangshistorie, während die Speichernutzung, die sich aus den Speicheranforderungen ergibt, weiterhin überwacht wird. Muss größer als `0` sein.

---

## Vorbehalt

Achten Sie darauf, wenn Sie sich entscheiden, die Protokoll-Ebene(n) `Debug` (oder darunter) in Ihrem `SteamTarget` mit `steamID` zu kombinieren, das am ASF-Prozess teilnimmt. Dies kann zu einer möglichen `StackOverflowException` (Ausnahme) führen, da Sie eine Endlosschleife erzeugen, in der ASF eine gegebene Nachricht empfängt, sie dann durch Steam protokolliert, was zu einer weiteren Nachricht führt, die protokolliert werden muss. Derzeit sind die einzigen Möglichkeiten dafür die Protokollierung der Ebenen `Trace` (wo ASF seine eigenen Chat-Nachrichten aufzeichnet), oder `Debug` (im `Debug` Modus ausgeführt, wo ASF alle Steam-Pakete aufzeichnet).

Kurz gesagt – wenn Ihre `steamID` am gleichen ASF-Prozess teilnimmt, dann sollte die `minlevel` Protokoll-Ebene Ihres `SteamTarget` – `Info` (oder im `Debug`, falls Sie ASF nicht im `Debug` Modus ausführen) sein, oder darüber. Alternativ können Sie Ihre eigenen `<when>` Protokoll-Filter definieren, um eine unendliche Schleife beim Protokollieren zu vermeiden, wenn die Änderung der Ebene nicht für Ihren Fall geeignet ist. Dies gilt auch für Gruppen-Chats.