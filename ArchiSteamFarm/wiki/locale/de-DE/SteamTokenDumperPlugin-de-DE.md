# SteamTokenDumperPlugin

`SteamTokenDumperPlugin` ist eine offizielles ASF-**[Erweiterung](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins-de-DE)**, welches von uns entwickelt wird. Dies erlaubt es Ihnen, zum Projekt **[SteamDB](https://steamdb.info)** beizutragen, indem Sie Paket- und App-Tokens sowie Depot-Schlüssel, auf die Ihr Steam-Konto Zugriff hat, teilen. Informationen zu den gesammelten Daten und warum SteamDB diese benötigt, finden Sie auf der **[Token Dumper](https://steamdb.info/tokendumper)** Website von SteamDB. Die übermittelten Daten enthalten demnach keine potenziell sensiblen Informationen und bergen kein Sicherheits-/Datenschutzrisiko.

---

## Aktivierung der Erweiterung

Das `SteamTokenDumperPlugin` ist in der Releaseversion von ASF enthalten, jedoch ist die Erweiterung standardmäßig deaktiviert. Sie können die Erweiterung aktivieren, indem Sie die globale ASF Konfigurationseigenschaft `SteamTokenDumperPluginEnabled` auf `true` setzen. Im JSON-Syntax:

```json
{
 "SteamTokenDumperPluginEnabled": true
}
```

Beim Start von ASF teilt die Erweiterung über den Standard-Protokollierungsmechanismus mit, ob es erfolgreich aktiviert wurde. Sie können die Erweiterung auch über unseren webbasierten Konfigurationsgenerator aktivieren.

---

## Technische Details

Nach der Aktivierung verwendet die Erweiterung die Bots, die Sie in ASF betreiben, zur Datenerfassung in Form von Paket- und App-Tokens sowie Depot-Schlüsseln, auf die Ihre Bots Zugriff haben. Das Datenerfassungsmodul umfasst passive und aktive Routinen, die den durch die Datenerfassung verursachten zusätzlichen Aufwand minimieren sollen.

Um den geplanten Anwendungsfall zu erfüllen, wird zusätzlich zu der oben erläuterten Datenerfassungsroutine die Einreichungsroutine initialisiert, die dafür verantwortlich ist, zu bestimmen, welche Daten auf periodischer Basis an SteamDB übermittelt werden müssen. Diese Routine wird innerhalb von `1` Stunde nach dem Start von ASF ausgelöst und wiederholt sich alle `24` Stunden. Die Erweiterung wird sich bemühen, die Menge der zu sendenden Daten zu reduzieren. Daher ist es möglich, dass einige Daten, die die Erweiterung sammelt, als unbrauchbar zur Übermittlung eingestuft und daher übersprungen werden (z. B. ein App-Update, das das Zugriffstoken nicht ändert).

Die Erweiterung verwendet eine dauerhafte Cache-Datenbank, die in `config/SteamTokenDumper.cache` gespeichert ist, die einen ähnlichen Zweck wie `config/ASF.db` für ASF erfüllt. Die Datei wird verwendet, um die gesammelten und übermittelten Daten aufzuzeichnen und den Arbeitsaufwand, der bei verschiedenen ASF-Ausführungen anfällt, zu minimieren. Das Entfernen der Datei führt dazu, dass der Prozess von Grund auf neu gestartet wird, was nach Möglichkeit vermieden werden sollte.

---

## Daten

ASF schließt die `steamID` des Mitwirkenden in die Anfrage ein, die als `SteamOwnerID` bestimmt wird, die Sie in ASF festgelegt haben oder – falls nicht – die Steam-ID des Bots, der die meisten Lizenzen besitzt. Der angegebene Mitwirkende könnte einige zusätzliche Vorteile von SteamDB für kontinuierliche Hilfe erhalten (z. B. Spenderrang auf der Website), aber das liegt ganz im Ermessen von SteamDB.

SteamDB bedankt sich im Voraus für Ihre Unterstützung. Die übermittelten Daten ermöglichen den Betrieb von SteamDB, insbesondere die Verfolgung von Informationen über Pakete, Anwendungen und Depots, was ohne Ihre Hilfe nicht mehr möglich wäre.

---

## Befehl

Die STD-Erweiterung verfügt über einen zusätzlichen ASF-Befehl, `std [Bots]`, mit dem Sie bei Bedarf Aktualisierungen und Einreichungen für ausgewählte Bots auslösen können. Die Verwendung des Befehls erfordert keine aktivierte Konfiguration, was es Ihnen erlaubt, die automatische Sammlung und Einreichung zu überspringen und den Prozess selbst manuell zu steuern. Selbstverständlich kann es auch mit aktivierter Konfiguration ausgeführt werden, was einfach die üblichen Sammel- und Einreichungsverfahren früher als erwartet auslöst.

Wir empfehlen `!std ASF` um eine Aktualisierung für alle verfügbaren Bots auszulösen. Sie können es aber auch für selektiv auslösen, sollte dies Ihr Wunsch sein.

---

## Erweiterte Einstellungen

Unsere Erweiterung unterstützt fortgeschrittene Konfigurationen, die für Anwender nützlich sein könnten, die die interne Funktion nach ihren Wünschen anpassen möchten.

Die erweiterte Konfiguration hat folgende Struktur innerhalb von `ASF.json`:

```json
{
  "SteamTokenDumperPlugin": {
    "Enabled": false,
    "SecretAppIDs": [],
    "SecretDepotIDs": [],
    "SecretPackageIDs": [],
    "SkipAutoGrantPackages": true
  }
}
```

Alle Optionen werden nachfolgend erklärt:

### `Enabled`

Typ `bool` mit dem Standardwert `false`. Diese Eigenschaft identisch zur Root-Level-Variable `SteamTokenDumperPluginEnabled` (erklärt oben), und kann stattdessen verwendet werden, widmet sich an Leute, die lieber komplette erweiterungsbezogene Konfiguration in ihrer eigenen Struktur haben würden (sodass wahrscheinlich diejenigen, die bereits andere fortgeschrittene Eigenschaften verwenden werden, wie unten erläutert).

---

### `SecretAppIDs`

Typ `ImmutableHashSet<uint>` mit einem leeren Standardwert. Diese Variable legt `appIDs` fest, welche die Erweiterung nicht auflöst und falls sie bereits aufgelöst sind, wird das Token nicht übermittelt. Diese Variable kann für Personen mit Zugang zu potenziell sensiblen Informationen über unveröffentlichte Artikel nützlich sein, insbesondere für Entwickler, Herausgeber oder geschlossene Betatester.

---

### `SecretDepotIDs`

Typ `ImmutableHashSet<uint>` mit einem leeren Standardwert. Diese Variable legt `depotIDs` fest, welche die Erweiterung nicht auflöst, und falls sie bereits aufgelöst sind, wird deren Schlüssel nicht übermittelt. Diese Variable kann für Personen mit Zugang zu potenziell sensiblen Informationen über unveröffentlichte Artikel nützlich sein, insbesondere für Entwickler, Herausgeber oder geschlossene Betatester.

---

### `SecretPackageIDs`

Typ `ImmutableHashSet<uint>` mit einem leeren Standardwert. Diese Variable legt `packageIDs` (auch bekannt als `subIDs`) fest, welche die Erweiterung nicht auflöst, und falls sie bereits aufgelöst sind, wird das Token nicht übermittelt. Diese Variable kann für Personen mit Zugang zu potenziell sensiblen Informationen über unveröffentlichte Artikel nützlich sein, insbesondere für Entwickler, Herausgeber oder geschlossene Betatester.

---

### `SkipAutoGrantPackages`

Typ `bool` mit dem Standardwert `true`. Diese Variable wirkt ähnlich wie `SecretPackageIDs` und wenn aktiviert, werden Pakete mit `EPaymentMethod` von `AutoGrant` während der Auflösungsroutine übersprungen. Die Zahlungsmethode `AutoGrant` wird von **[Steamworks](https://partner.steamgames.com)** verwendet, um Pakete automatisch auf Entwicklerkonten zu gewähren. Während dies nicht so explizit ist wie andere `Secret` Optionen, und garantiert daher nichts (da Sie möglicherweise andere Pakete als `AutoGrant` haben, die Sie weiterhin nicht einreichen wollen), sollte es ausreichen, um die Mehrheit, wenn nicht sogar alle, der geheimen Pakete zu überspringen. Diese Option ist standardmäßig aktiviert, da Anwender, die tatsächlich Zugriff auf `AutoGrant`-Pakete haben, diese fast nie öffentlich ablegen wollen und daher ist der Wert `false` sehr situational.

---

## Weitere Erklärungen

Auf der Root-Ebene besitzt jedes Steam-Konto eine Reihe von Paketen (Lizenzen, Abonnements), die durch dessen `packageID` klassifiziert wird (auch `subID` genannt). Jedes Paket kann mehrere Apps enthalten, die durch deren `appID` klassifiziert sind. Jede App kann dann mehrere Depots enthalten, die durch ihre `DepotID` klassifiziert wird.

```text
├── sub/124923
│     ├── app/292030
│     │     ├── depot/292031
│     │     ├── depot/378648
│     │     └── ...
│     ├── app/378649
│     └── ...
└── ...
```

Unsere Erweiterung enthält zwei Routinen, die übersprungene Elemente berücksichtigen - die Auflösungsroutine und die Einreichungsroutine.

Die Auflösungsroutine ist verantwortlich für die Lösung des Baumes, den Sie oben sehen können. Durch eine Blockierung der Pakete/Apps/Depots im Voraus Sie können den Baum effektiv an der Stelle von Sperrlisten-Zweig kürzen, ohne die restlichen Teile anzugeben. In unserem Beispiel oben, wenn Paket `124923` ignoriert wurde (egal ob von `SecretPackageIDs` oder `SkipAutoGrantPackages`), und es das einzige Paket war, dass Sie besitzen, welches mit der `292030` appID verbunden ist, dann würde appID `292030` auch nicht gelöst werden; dementsprechend, sofern es keine anderen aufgelösten Apps gab, werden die mit den verbundenen Depots `292031` und `378648` ebenfalls ignoriert. Beachten Sie jedoch, dass, wenn die Erweiterung den Baum bereits aufgelöst hat, dies effektiv verhindert, dass ein bestimmtes Element aktualisiert wird (z. B. Neue Apps hinzugefügt), es lässt die Erweiterung nicht plötzlich bereits gelöste Elemente (z. B. Apps in diesem Paket gefunden, bevor Sie sich entschieden haben, es zu blockieren) „vergessen“. Wenn Sie gerade einige „Überspringungsoptionen“ aktiviert haben und sicherstellen möchten, dass ASF den bereits aufgelösten Baum nicht durchläuft, sollten Sie die einmalige Löschung der Datei `config/SteamTokenDumper.cache`, in der die Erweiterung den Cache hält, erwägen.

Die Einreichungsroutine ist für das Übermitteln von Paket-Token, App-Token und Depot-Schlüsseln bereits erledigter Elemente verantwortlich (durch die Auflösungsroutine oben). Hier hat Ihre Sperrliste sofortige Wirkung, auch wenn die Erweiterung die Informationen bereits gelöst hat, die Einreichungsroutine wird sie nicht tatsächlich an SteamDB übermitteln, wenn Sie diese gesperrt haben, unabhängig davon, ob sie gelöst wurde oder nicht. Denken Sie jedoch daran, dass wir an dieser Stelle nicht mehr über den Baum sprechen. Die Einreichungsroutine weiß nicht, ob die Informationen über die App von diesem oder jenem Paket stammen, so werden nur Informationen über bestimmte, auf der Sperrliste gespeicherte Elemente übersprungen, unabhängig davon, in welcher Beziehung sie sich zu anderen befinden.

Für die Mehrheit der Entwickler und Herausgeber sollte es genügen `SkipAutoGrantPackages` zu aktivieren; potenziell nur mit `SecretPackageIDs` versorgt, da er den Baum im Anfangszweig kürzt und garantiert, dass die enthaltenen Apps und Depots nicht eingereicht werden (solange es kein anderes Paket gibt, das mit der gleichen App verlinkt ist). Wenn Sie sich sicher sein wollen, können Sie zusätzlich `SecretAppIDs` verwenden, was die Auflösung der App überspringt, auch wenn es andere Lizenzen gibt, die Sie nicht auf die Sperrlisten-Verknüpfungen gesetzt haben. Die Verwendung von `SecretDepotIDs` sollten nicht notwendig sein, es sei denn, Sie haben ein spezielles Bedürfnis (wie das Überspringen eines bestimmten Depots, während Sie immer noch Informationen über Pakete und Apps übermitteln); oder wenn Sie eine weitere Ebene hinzufügen wollen, um dreifach abgesichert zu sein.