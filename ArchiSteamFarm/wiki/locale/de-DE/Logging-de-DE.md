# Protokollierung

ASF ermöglicht es dir, dein eigenes benutzerdefiniertes Protokollierungsmodul zu konfigurieren, das während der Laufzeit verwendet wird. Dies funktioniert, indem Du eine spezielle Datei mit dem Namen `NLog.config` in dem Programmverzeichnis ablegst. Sie können die gesamte Dokumentation über NLog im **[NLog Wiki](https://github.com/NLog/NLog/wiki/Configuration-file)** nachlesen, zusätzlich wirst Du auch hier nützliche Beispiele dazu finden.

---

## Standard Protokollierung

Standardmäßig protokolliert ASF in `ColoredConsole` (Standardausgabe) und `File`. `File` Protokollierung beinhaltetet die `log.txt` Datei im Programmverzeichnis und das `logs` Verzeichnis für Archivierungszwecke.

Die Verwendung einer benutzerdefinierten NLog Konfiguration deaktiviert automatisch die standard ASF Konfiguration, welche damit durch ihre Konfiguration **komplett** überschrieben wird. Das bedeutet, dass, falls Sie z. B. unsere `ColoredConsole` Ausgabe verwenden wollen, Sie diese **selber** definieren müssen. Dies erlaubt dir nicht nur **extra** Protokollierungsziele zu erstellen, sondern auch die **Standardziele** zu verändern oder deaktivieren.

Wenn Du die standard ASF-Protokollierung ohne irgendwelche Veränderung verwenden möchtest, musst Du nichts tun - auch brauchst Du dies nicht in der `NLog.config` definieren. Verwende die `NLog.config` nicht, wenn Du die standard ASF-Protokollierung nicht verändern möchtest. Zum Vergleich: Das Äquivalent zur fest definierten standard ASF-Protokollierung wäre:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" layout="${date:format=yyyy-MM-dd HH\:mm\:ss}|${processname}-${processid}|${level:uppercase=true}|${logger}|${message}${onexception:inner= ${exception:format=toString,Data}}" />
    <target xsi:type="File" name="File" archiveFileName="${currentdir}/logs/log.{#}.txt" archiveNumbering="Rolling" archiveOldFileOnStartup="true" cleanupFileName="false" concurrentWrites="false" deleteOldFileOnStartup="true" fileName="${currentdir}/log.txt" layout="${date:format=yyyy-MM-dd HH\:mm\:ss}|${processname}-${processid}|${level:uppercase=true}|${logger}|${message}${onexception:inner= ${exception:format=toString,Data}}" maxArchiveFiles="10" />

    <!-- Below becomes active when ASF's IPC interface is started -->
    <target type="History" name="History" layout="${date:format=yyyy-MM-dd HH\:mm\:ss}|${processname}-${processid}|${level:uppercase=true}|${logger}|${message}${onexception:inner= ${exception:format=toString,Data}}" maxCount="20" />
  </targets>

  <rules>
    <!-- The following entries specify ASP.NET (IPC) logging, we declare those so our last Debug catch-all doesn't include ASP.NET logs by default -->
    <logger name="Microsoft*" finalMinLevel="Warn" writeTo="ColoredConsole" />
    <logger name="Microsoft.Hosting.Lifetime*" finalMinLevel="Info" writeTo="ColoredConsole" />
    <logger name="System*" finalMinLevel="Warn" writeTo="ColoredConsole" />

    <logger name="*" minlevel="Debug" writeTo="ColoredConsole" />

    <!-- The following entries specify ASP.NET (IPC) logging, we declare those so our last Debug catch-all doesn't include ASP.NET logs by default -->
    <logger name="Microsoft*" finalMinLevel="Warn" writeTo="File" />
    <logger name="Microsoft.Hosting.Lifetime*" finalMinLevel="Info" writeTo="File" />
    <logger name="System*" finalMinLevel="Warn" writeTo="File" />

    <logger name="*" minlevel="Debug" writeTo="File" />

    <!-- Below becomes active when ASF's IPC interface is enabled -->
    <!-- The following entries specify ASP.NET (IPC) logging, we declare those so our last Debug catch-all doesn't include ASP.NET logs by default -->
    <logger name="Microsoft*" finalMinLevel="Warn" writeTo="History" />
    <logger name="Microsoft.Hosting.Lifetime*" finalMinLevel="Info" writeTo="History" />
    <logger name="System*" finalMinLevel="Warn" writeTo="History" />

    <logger name="*" minlevel="Debug" writeTo="History" />
  </rules>
</nlog>
```

---

## ASF Integration

ASF enthält einige nette Quellcode-Tricks, die die Integration mit NLog verbessern und es ihren ermöglichen bestimmte Nachrichten leichter zu erfassen.

Die NLog-spezifische `${logger}` Variable wird immer die Quelle der Nachricht anzeigen - es wird entweder `BotName` von einem ihrer Bots sein, oder `ASF` wenn die Nachricht direkt vom ASF-Prozess kommt. Auf diese Weise kannst Du Nachrichten leicht abfangen, die bestimmte Bot(s) oder ASF-Prozesse (nur) berücksichtigen, anstatt sie alle, basierend auf dem Namen des Loggers.

ASF versucht, Meldungen entsprechend den von NLog bereitgestellten logging Warnstufen zu kennzeichnen, was es Ihnen ermöglicht, nur bestimmte Meldungen von bestimmten Protokollebenen, statt von allen zu erhalten. Natürlich kann die Protokollierungsstufe für eine bestimmte Nachricht nicht angepasst werden, da es sich um eine ASF-Festlegung handelt, wie ernst die gegebene Nachricht ist, aber Du kannst ASF definitiv weniger/mehr leise machen, wie Du es für richtig hältst.

ASF protokolliert zusätzliche Informationen, wie z. B. Benutzer-/Chat-Nachrichten auf der `Trace` Protokollierungsebene. Die standardmäßige ASF-Protokollierung protokolliert nur die `Debug` Ebene und darüber, was diese zusätzlichen Informationen verbirgt, da sie für die Mehrheit der Benutzer nicht benötigt werden, sowie die Ausgabe mit potenziell wichtigeren Nachrichten zu mült. Sie können diese Informationen jedoch nutzen, indem Du `Trace` Logging-Ebene wieder aktivierst, insbesondere in Kombination mit dem Logging nur eines bestimmten Bots ihrer Wahl, mit einem bestimmten Event, an dem Du interessiert bist.

Im Allgemeinen versucht ASF, es ihren so einfach und bequem wie möglich zu machen, nur die Nachrichten zu protokollieren, die Du willst, anstatt dich zu zwingen, sie manuell durch Drittanbieterprogramme wie `grep` und ähnliche zu filtern. Konfiguriere NLog einfach wie unten beschrieben und Du solltest in der Lage sein, auch sehr komplexe Protokollierungsregeln mit benutzerdefinierten Zielen, wie beispielsweise ganze Datenbanken, zu spezifizieren.

In Bezug auf die Versionierung - ASF versucht immer die aktuellste Version von NLog zu liefern, die zum Zeitpunkt der ASF-Version unter **[NuGet](https://www.nuget.org/packages/NLog)** verfügbar ist. Es sollte kein Problem sein, alle Funktionen zu verwenden, die Sie im NLog-Wiki in ASF finden - stellen Sie sicher, dass Sie auch die neueste ASF verwenden.

Im Rahmen der ASF-Integration bietet ASF auch Unterstützung für zusätzliche ASF NLog-Protokollierungsziele, die im Folgenden erläutert werden.

---

## Beispiele

Lass uns mit etwas einfachem anfangen. Wir werden nur **[ColoredConsole](https://github.com/nlog/nlog/wiki/ColoredConsole-target)** target verwenden. Unsere initiale `NLog.config` wird so aussehen:

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

Die Erklärung der obigen Konfiguration ist ziemlich einfach - wir definieren ein **logging target**, das `ColoredConsole` ist, dann leiten wir **all loggers** (`*`) der Ebene `Debug` und höher zu `ColoredConsole` target um, das wir zuvor definiert haben. Das ist alles.

Wenn Du ASF jetzt mit obiger `NLog.config` startest, wird nur `ColoredConsole` target aktiv sein, und ASF wird nicht in `File` schreiben, unabhängig von der fest programmierten ASF NLog Konfiguration.

Nehmen wir an, wir mögen das Standardformat `${longdate}|${level:uppercase=true}|${logger}|${message}` nicht und wir wollen nur die Meldung protokollieren. Wir können dies tun, indem wir **[Layout](https://github.com/nlog/nlog/wiki/Layouts)** unseres targets ändern.

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

Wenn Du ASF jetzt startest, wirst Du feststellen, dass Datum, Level und Logger-Name verschwunden sind - und Du nur noch ASF-Nachrichten im Format `Function() Message` hast.

Wir können die Konfiguration auch so ändern, dass sie bei mehr als einem Ziel protokolliert. Lasst uns gleichzeitig `ColoredConsole` und **[File](https://github.com/nlog/nlog/wiki/File-target)** protokollieren.

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

Und fertig, wir werden jetzt alles über `ColoredConsole` und `File` protokollieren. Hast Du bemerkt, dass Du auch benutzerdefinierte `fileName` und zusätzliche Optionen angeben kannst?

Schließlich verwendet ASF verschiedene Protokollebenen, um es ihren leichter zu machen, zu verstehen, was vor sich geht. Wir können diese Informationen verwenden, um die Schweregrad-Protokollierung zu ändern. Let's say that we want to log everything (`Trace`) to `File`, but only `Warning` and above **[log level](https://github.com/NLog/NLog/wiki/Configuration-file#log-levels)** to the `ColoredConsole`. Wir können das erreichen, indem wir unsere `rules` modifizieren:

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

Das war's, jetzt zeigt unsere `ColoredConsole` nur noch Warnungen und darüber, während sie immer noch alles in `File` protokolliert. Sie können es weiter optimieren, um z. B. nur `Info` und darunter zu protokollieren, und so weiter.

Zuletzt, lasst uns etwas weiter fortgeschrittenes tun und alle Nachrichten in einer Datei protokollieren, aber nur von einem Bot namens `LogBot`.

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

Sie können sehen, wie wir die ASF-Integration oben verwendet haben und leicht zu unterscheidende Quelle der Nachricht basierend auf der `${logger}` Eigenschaft (Property).

---

## Erweiterte Nutzung

Die obigen Beispiele sind ziemlich einfach und sollen ihren zeigen, wie einfach es ist, eigene Protokollierungsregeln zu definieren, die mit ASF verwendet werden können. Sie können NLog für verschiedene Dinge verwenden, einschließlich komplexer Ziele (wie das Führen von Protokollen in `Datenbank`), Protokollrotation (wie das Entfernen alter `File` Protokolle), Verwendung benutzerdefinierter `Layout`s, Deklaration eigener `<when>` Protokollierungsfilter und vieles mehr. Ich empfehle dir, die gesamte **[NLog-Dokumentation](https://github.com/nlog/nlog/wiki/Configuration-file)** durchzulesen, um mehr über jede Option zu erfahren, die dir zur Verfügung steht, damit Du das ASF-Logging-Modul so anpassen kannst, wie Du willst. Es ist ein wirklich leistungsstarkes Programm und die Anpassung der ASF-Protokollierung war nie einfacher.

---

## Einschränkungen

ASF deaktiviert vorübergehend **alle** Regeln, die `ColoredConsole` oder `Console` Targets beinhalten, wenn Benutzereingaben erwartet werden. Wenn Du also die Protokollierung für andere Ziele beibehalten möchtest, auch wenn ASF Benutzereingaben erwartet werden, solltest Du diese Ziele mit ihren  eigenen Regeln definieren, wie in den obigen Beispielen gezeigt, anstatt viele Ziele in `writeTo` der gleichen Regel zu setzen (es sei denn, dies ist dein gewünschtes Verhalten). Die vorübergehende Deaktivierung von Konsole-Zielen wird durchgeführt, um die Konsole sauber zu halten, wenn auf Benutzereingaben gewartet wird.

---

## Chat-Protokollierung

ASF bietet erweiterte Unterstützung für das Chat-Logging, indem es nicht nur alle empfangene/gesendete Nachrichten auf `Trace` Logging-Ebene aufzeichnet, sondern auch zusätzliche Informationen zu Ihnen in **[Ereigniss-Eigenschaft (Property)en](https://github.com/NLog/NLog/wiki/EventProperties-Layout-Renderer)** anzeigt. Dies liegt daran, dass wir Chat-Nachrichten ohnehin als Befehle behandeln müssen, sodass es uns nichts kostet, diese Ereignisse zu protokollieren, um es Ihnen zu ermöglichen, zusätzliche Logik hinzuzufügen (z. B. ASF zu einem persönlichen Steam-Chat-Archiv zu machen).

### Ereigniseigenschaften

| Name        | Beschreibung                                                                                                                                                                                                                                  |
| ----------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Echo        | Typ `bool`. Dies wird auf `true` gesetzt, wenn die Nachricht von uns an den Empfänger gesendet wird, und andernfalls auf `false`.                                                                                                             |
| Message     | Typ `string`. Dies ist die eigentliche gesendete/empfangene Nachricht.                                                                                                                                                                        |
| ChatGroupID | Typ `ulong`. Dies ist die ID des Gruppen-Chats für gesendete/empfangene Nachrichten. Wird `0` sein, wenn kein Gruppen-Chat für die Übertragung dieser Nachricht verwendet wird.                                                               |
| ChatID      | Typ `ulong`. Dies ist die ID des `ChatGroupID` Kanals für gesendete/empfangene Nachrichten. Wird `0` sein, wenn kein Gruppen-Chat für die Übertragung dieser Nachricht verwendet wird.                                                        |
| SteamID     | Typ `ulong`. Dies ist die ID des Steam-Benutzers für gesendete/empfangene Nachrichten. Kann `0` sein, wenn kein bestimmter Benutzer an der Nachrichtenübertragung beteiligt ist (z. B. wenn wir eine Nachricht an einen Gruppen-Chat senden). |

### Beispiel

Dieses Beispiel basiert auf unserem `ColoredConsole` Basisbeispiel oben. Bevor Du versuchst, es zu verstehen, empfehle ich dir dringend, einen Blick auf **[oben](#beispiele)** zu werfen, um zunächst die Grundlagen der NLog-Protokollierung zu erfahren.

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

Wir haben mit unserem einfachen Beispiel `ColoredConsole` begonnen und es weiter ausgebaut. In erster Linie haben wir eine permanente Chat-Logdatei für jeden Gruppenkanal und Steam-Benutzer erstellt - dies ist möglich dank zusätzlicher Eigenschaften, die ASF uns auf ausgefallene Weise zur Verfügung stellt. Wir haben uns auch für ein benutzerdefiniertes Layout entschieden, das nur das aktuelle Datum, die Nachricht, die gesendete/empfangene Info und den Steam-Benutzer selbst schreibt. Schließlich haben wir unsere Chat-Protokollierungsregel nur für `Trace` Ebene aktiviert, nur für unseren `MainAccount` Bot und nur für Funktionen im Zusammenhang mit der Chat-Protokollierung (`OnIncoming*`, der für den Empfang von Nachrichten und Echos verwendet wird, und `SendMessage*` für das Senden von ASF-Nachrichten).

The example above will generate `0-0-76561198069026042.txt` file when talking with **[ArchiBot](https://steamcommunity.com/profiles/76561198069026042)**:

```text
2018-07-26 01:38:38 how are you doing? -> 76561198069026042
2018-07-26 01:38:38 /me I'm doing great, how about you? <- 76561198069026042
```

Natürlich ist dies nur ein funktionierendes Beispiel mit ein paar schönen Layout-Tricks, die in praktischer Hinsicht gezeigt werden. Sie können diese Idee weiter auf ihre eigenen Bedürfnisse ausdehnen, wie z. B. zusätzliche Filterung, benutzerdefinierte Reihenfolge, persönliches Layout, Aufnahme nur empfangener Nachrichten und so weiter.

---

## ASF-Ziele

Zusätzlich zu den standardmäßigen NLog-Protokollierungszielen (wie z. B. `ColoredConsole` und `File` siehe oben) kannst Du auch benutzerdefinierte ASF-Protokollierungsziele verwenden.

Um eine maximale Vollständigkeit zu gewährleisten, erfolgt die Definition der ASF-Ziele nach der NLog-Dokumentationskonvention.

---

### SteamTarget

Wie Du erraten kannst, verwendet dieses Ziel Steam-Chat-Nachrichten zum Protokollieren von ASF-Nachrichten. Sie können es so konfigurieren, dass es entweder einen Gruppen-Chat oder einen privaten Chat verwendet. Zusätzlich zur Angabe eines Steam-Ziels für ihre Nachrichten kannst Du auch `botName` des Bots angeben, der diese senden soll.

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

Lies mehr über die Verwendung der [Konfigurationsdatei](https://github.com/NLog/NLog/wiki/Configuration-file).

---

#### Parameter

##### Allgemeine Optionen
_name_ - Name des Ziels.

---

##### Layout Optionen
_layout_ - Der zu rendernde Text. [Layout](https://github.com/NLog/NLog/wiki/Layouts) Erforderlich. Standard: `${level:uppercase=true}|${logger}|${message}`

---

##### SteamTarget Optionen

_chatGroupID_ - ID des Gruppen-Chats, der als 64-Bit lange unsignierte Ganzzahl deklariert wurde. Nicht erforderlich. Standardmäßig ist `0` voreingestellt, was die Gruppen-Chat-Funktion deaktiviert und stattdessen privaten Chat verwendet. Wenn aktiviert (auf einen Nicht-Nullwert gesetzt), fungiert die folgende Eigenschaft (Property) `steamID` als `chatID` und gibt die ID des Kanals in diesem `chatGroupID` an, an den der Bot Nachrichten senden soll.

_steamID_ - SteamID deklariert als 64-Bit lange unsignierte ganze Zahl des Ziel-Steam-Benutzers (wie `SteamOwnerID`), oder Ziel `chatID` (wenn `chatGroupID` eingestellt ist). Erforderlich. Defaults to `0` which disables logging target entirely.

_botName_ - Name of the bot (as it's recognized by ASF, case-sensitive) that will be sending messages to `steamID` declared above. Nicht erforderlich. Standardmäßig ist `null` voreingestellt, was automatisch **jeden** aktuell verbundenen Bot auswählt. Es wird empfohlen, diesen Wert entsprechend einzustellen, da `SteamTarget` nicht viele Steam-Einschränkungen berücksichtigt, wie z. B. die Tatsache, dass Du `steamID` des Ziels auf ihrer Freundeliste haben musst. This variable is defined as [layout](https://github.com/NLog/NLog/wiki/Layouts) type, therefore you can use special syntax in it, such as `${logger}` in order to use the bot that generated the message.

---

#### SteamTarget Beispiele

Um alle Nachrichten von `Debug` Ebene und darüber, von dem Bot namens `MyBot` zu steamID von `76561198006963719` zu schreiben, solltest Du `NLog.config` ähnlich wie unten verwenden:

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

**Hinweis:** Unser `SteamTarget` ist ein benutzerdefiniertes Target, also solltest Du sicherstellen, dass Du es als `type="Steam"`, NICHT `xsi:type="Steam"` deklarierst, da xsi für offizielle, von NLog unterstützte Ziele reserviert ist.

Wenn Du ASF mit `NLog.config` ähnlich wie oben gestartet hast, beginnt `MyBot` dem Steam-Benutzer `76561198006963719` alle üblichen ASF-Protokollmeldungen zu senden. Bedenke, dass `MyBot` verbunden sein muss, um Nachrichten zu senden, damit alle anfänglichen ASF-Nachrichten, die stattfanden, bevor unser Bot sich mit dem Steam-Netzwerk verbinden konnte, nicht weitergeleitet werden.

Natürlich verfügt `SteamTarget` über alle typischen Funktionen, die von generischem `TargetWithLayout` erwarten werden. So können Sie es in Verbindung mit z. B. benutzerdefinierten Layouts, Namen oder erweiterten Protokollierungsregeln verwenden. Das obige Beispiel ist lediglich ein grundlegendes Beispiel.

---

#### Screenshots

![Screenshot](https://i.imgur.com/5juKHMt.png)

---

### HistoryTarget

Dieses Target wird intern von ASF verwendet, um eine Protokollhistorie mit fester Größe in `/Api/NLog` Endpunkt von **[ASF-API](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-de-DE#asf-api)** bereitzustellen, die anschließend von ASF-UI und anderen Programmen verwendet werden kann. Im Allgemeinen solltest Du dieses Target nur dann definieren, wenn Du bereits eine benutzerdefinierte NLog-Konfiguration für andere Anpassungen verwendest und das Protokoll auch in der ASF-API angezeigt werden soll, z. B. für ASF-UI. Es kann auch angegeben werden, wenn Du das Standardlayout oder `maxCount` der gespeicherten Nachrichten ändern möchtest.

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

Lies mehr über die Verwendung der [Konfigurationsdatei](https://github.com/NLog/NLog/wiki/Configuration-file).

---

#### Parameter

##### Allgemeine Optionen
_name_ - Name des Ziels.

---

##### Layout Optionen
_layout_ - Der zu rendernde Text. [Layout](https://github.com/NLog/NLog/wiki/Layouts) Erforderlich. Standard: `${date:format=yyyy-MM-dd HH\:mm\:ss}|${processname}-${processid}|${level:uppercase=true}|${logger}|${message}${onexception:inner= ${exception:format=toString,Data}}`

---

##### HistoryTarget Optionen

_maxCount_ - Maximale Anzahl der gespeicherten Protokolle für die Abrufhistorie. Nicht erforderlich. Die Standardeinstellung ist `20`, was eine gute Balance für die Bereitstellung der Anfangshistorie ist, während die Speichernutzung, die sich aus den Speicheranforderungen ergibt, immer noch im Auge behalten wird. Muss größer als `0` sein.

---

## Vorbehalt

Achte darauf, wenn Du dich entscheidest, `Debug` Logging-Ebene oder darunter in ihrem `SteamTarget` mit `steamID` zu kombinieren, das am ASF-Prozess teilnimmt. Dies kann zu einer möglichen `StackOverflowException` führen, da Du eine Endlosschleife erzeugst, in der ASF eine gegebene Nachricht empfängt, sie dann durch Steam protokolliert, was zu einer weiteren Nachricht führt, die protokolliert werden muss. Derzeit ist die einzige Möglichkeit dafür, `Trace` Ebene (wo ASF seine eigenen Chat-Nachrichten aufzeichnet), oder `Debug` Ebene zu protokollieren, während ASF auch im `Debug` Modus ausgeführt wird (wo ASF alle Steam-Pakete aufzeichnet).

Kurz gesagt, wenn ihre `steamID` am gleichen ASF-Prozess teilnimmt, dann sollte die `minlevel` Logging-Ebene ihres `SteamTarget` `Info` (oder `Debug` sein, wenn Du auch nicht ASF im `Debug` Modus) und darüber. Alternativ kannst Du ihre eigenen `<when>` Logging-Filter definieren, um eine unendliche Logging-Schleife zu vermeiden, wenn die Änderung des Levels nicht für ihren Fall geeignet ist. Dies gilt auch für Gruppen-Chats.