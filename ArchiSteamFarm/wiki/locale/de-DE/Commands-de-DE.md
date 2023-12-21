# Kommandos

ASF unterstützt eine Vielzahl von Befehlen, mit denen das Verhalten der Prozess- und Bot-Instanzen gesteuert werden kann.

Die folgenden Befehle können auf verschiedene Weise an den Bot gesendet werden:
- Durch die interaktive ASF-Konsole
- Durch den privaten Steam-Chat / Gruppen-Chat
- Durch unsere **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-de-DE)** Schnittstelle

Bedenken Sie, dass die ASF-Interaktion von Ihnen verlangt, dass Sie für den Befehl gemäß den ASF-Berechtigungen berechtigt sind. Weitere Informationen finden Sie in den Konfigurationseigenschaften `SteamUserPermissions` und `SteamOwnerID`.

Befehle die über den Steam-Chat ausgeführt werden, sind von der **[globalen Konfigurationseigenschaft](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-de-DE#commandprefix)** `CommandPrefix` betroffen, welche standardmäßig `!` ist. Das bedeutet, dass Sie beispielsweise für die Ausführung von dem Befehl `status` tatsächlich `!status` (oder einen benutzerdefinierten `CommandPrefix` Ihrer Wahl) verwenden müssen. `CommandPrefix` ist bei Verwendung von IPC oder der Konsole nicht zwingend erforderlich und kann weggelassen werden.

---

### Interaktive Konsole

ASF unterstützt die interaktive Konsole, solange Sie nicht ASF im [**`Headless`**](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-de-DE#headless)-Modus ausführen. Drücken Sie einfach `c` um den Befehlsmodus zu aktivieren; geben Sie Ihren Befehl ein und bestätigen Sie mit dem Eintrag.

![Screenshot](https://i.imgur.com/bH5Gtjq.png)

---

### Steam-Chat

Sie können den Befehl zum angegebenen ASF-Bot auch über den Steam-Chat ausführen. Natürlich können Sie nicht direkt mit sich selbst sprechen, deshalb brauchen Sie mindestens ein weiteres Bot-Konto, wenn Sie Befehle ausführen möchten, die auf Ihr Haupt-Konto abzielen.

![Screenshot](https://i.imgur.com/IvFRJ5S.png)

In ähnlicher Weise können Sie auch den Gruppen-Chat einer bestimmten Steam-Gruppe verwenden. Beachte, dass diese Option die korrekt eingestellte Variable `SteamMasterClanID` erfordert. In diesem Fall wird der Bot auch im Gruppen-Chat auf Befehle warten (und sich bei Bedarf diesem anschließen). Dies kann auch für "Selbstgespräche" genutzt werden, da diese Variante kein dediziertes Bot-Konto erfordert, im Gegensatz zum privaten Chat. Sie können einfach die `SteamMasterClanID`-Variable auf die neu erstellte Gruppe setzen und sich dann entweder über `SteamOwnerID` oder `SteamUserPermissions` Zugriff auf Ihren eigenen Bot gewähren. Auf diese Weise tritt der ASF-Bot (Sie) der Gruppe bei und chattet mit der ausgewählten Gruppe und hört auf die Befehle von Ihrem eigenen Konto. Sie können dem gleichen Gruppen-Chatroom beitreten, um sich selbst Befehle zu erteilen (Achtung: Wenn eine ASF-Instanz diesem Chatroom beigetreten ist, wird diese ebenfalls sämtliche Befehle empfangen, die an diesen Chat gesendet werden, selbst wenn dieser anzeigt, dass nur Ihr Konto im Chat ist).

Bitte bedenken Sie, dass das Senden eines Befehls an den Gruppen-Chat wie ein Relais funktioniert. Wenn Sie `redeem X` zu drei Ihrer Bots senden, die zusammen mit Ihnen im Gruppen-Chat sind, wird es das gleiche Ergebnis haben, wie wenn Sie `redeem X` an jeden einzelnen von Ihnen privat senden würden. In den meisten Fällen ist **dies nicht das, was Sie möchten**, und stattdessen sollten Sie den Befehl `given bot` verwenden, der an **einen einzelnen Bot im privaten Fenster** gesendet wird. ASF unterstützt den Gruppen-Chat, da es in vielen Fällen eine nützliche Quelle für die Kommunikation mit einem einzigen Bot sein kann, aber Sie sollten fast nie einen Befehl im Gruppen-Chat ausführen, wenn dort zwei oder mehr ASF-Bots sitzen, es sei denn, Sie verstehen das hier erläuterte ASF-Verhalten vollständig und Sie möchten tatsächlich den gleichen Befehl an jeden einzelnen Bot weitergeben, der auf Sie hört.

*Sogar in diesem Fall sollten Sie stattdessen den privaten Chat mit der Syntax `[Bots]` benutzen.*

---

### IPC

Die fortschrittlichste und flexibelste Art der Befehlsausführung. Perfekt geeignet für die Benutzerinteraktion (ASF-UI), für Drittanbieter-Programme oder Skripte (ASF-API). Diese Variante erfordert, dass ASF im `IPC` Modus ausgeführt wird und einen Client der Befehle über die **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-de-DE)** Schnittstelle ausführt.

![Screenshot](https://raw.githubusercontent.com/JustArchiNET/ASF-ui/main/.github/previews/commands.png)

---

## Kommandos

| Befehl                                                               | Zugang          | Beschreibung                                                                                                                                                                                                                                                                                                                                                                |
| -------------------------------------------------------------------- | --------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `2fa [Bots]`                                                         | `Master`        | Generiert temporäre **[2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication-de-DE)**-Codes der angegebenen Bot-Instanzen.                                                                                                                                                                                                                     |
| `2fafinalize [Bots] <ActivationCode>`                          | `Master`        | Beendet den Zuweisungsvorgang neuer **[2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication-de-DE#erstellung)**-Anmeldedaten für angegebene Bot-Instanzen (mit einem SMS-/E-Mail- Aktivierungscode).                                                                                                                                          |
| `2fafinalized [Bots] <ActivationCode>`                         | `Master`        | Importiert bereits fertige **[2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication-de-DE#creation)**-Anmeldeinformationen für angegebene Bot-Instanzen, mit 2FA Token zur Überprüfung.                                                                                                                                                        |
| `2fafinalizedforce [Bots]`                                           | `Master`        | Importiert bereits fertige **[2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication-de-DE#creation)**-Anmeldeinformationen für angegebene Bot-Instanzen, überspringt 2FA Token zur Überprüfung.                                                                                                                                                |
| `2fainit [Bots]`                                                     | `Master`        | Startet die Zuweisung neuer **[2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication-de-DE#creation)**-Anmeldedaten für angegebene Bot-Instanzen.                                                                                                                                                                                              |
| `2fano [Bots]`                                                       | `Master`        | Lehnt alle ausstehenden **[2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication-de-DE)**-Bestätigungen der angegebenen Bot-Instanzen ab.                                                                                                                                                                                                      |
| `2faok [Bots]`                                                       | `Master`        | Akzeptiert alle ausstehenden **[2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication-de-DE)**-Bestätigungen der angegebenen Bot-Instanzen.                                                                                                                                                                                                    |
| `addlicense [Bots] <Licenses>`                                 | `Operator`      | Aktiviert angegebene `licenses` (Produktschlüssel), wie **[unten](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-de-DE#addlicense-lizenzen)** erklärt, in den angegebenen Bot-Instanzen (nur kostenlose Spiele).                                                                                                                                              |
| `balance [Bots]`                                                     | `Master`        | Zeigt das Guthaben der angegebenen Bot-Instanzen an.                                                                                                                                                                                                                                                                                                                        |
| `bgr [Bots]`                                                         | `Master`        | Zeigt Informationen über die **[BGR](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer-de-DE)** -Warteschlange der angegebenen Bot-Instanzen an.                                                                                                                                                                                                |
| `encrypt <encryptionMethod> <stringToEncrypt>`           | `Owner`         | Verschlüsselt die Zeichenkette mit der bereitgestellten kryptografiischen Methode - ausführlicher erklärt weiter **[unten](#encrypt-Befehl)**.                                                                                                                                                                                                                              |
| `exit`                                                               | `Owner`         | Stoppt den kompletten ASF-Prozess.                                                                                                                                                                                                                                                                                                                                          |
| `farm [Bots]`                                                        | `Master`        | Startet das Karten-Sammel-Modul für gegebene Bot-Instanzen neu.                                                                                                                                                                                                                                                                                                             |
| `fb [Bots]`                                                          | `Master`        | Listet Anwendungen auf, die vom automatischen Sammeln von gegebenen Bot-Instanzen ausgeschlossen sind.                                                                                                                                                                                                                                                                      |
| `fbadd [Bots] <AppIDs>`                                        | `Master`        | Fügt gegebene `AppIDs` zur schwarzen Liste der gegebenen Bot-Instanzen hinzu, die vom automatischen Sammeln ausgeschlossen sind.                                                                                                                                                                                                                                            |
| `fbrm [Bots] <AppIDs>`                                         | `Master`        | Entfernt gegebene `AppIDs` von der schwarzen Liste der gegebenen Bot-Instanzen, die vom automatischen Sammeln ausgeschlossen sind.                                                                                                                                                                                                                                          |
| `fq [Bots]`                                                          | `Master`        | Listet die Priorität der Sammelwarteschlange für die gegebenen Bot-Instanzen auf.                                                                                                                                                                                                                                                                                           |
| `fqadd [Bots] <AppIDs>`                                        | `Master`        | `AppIDs` erhalten Priorität in der Sammelwarteschlange für gegebenen Bot-Instanzen.                                                                                                                                                                                                                                                                                         |
| `fqrm [Bots] <AppIDs>`                                         | `Master`        | Entfernt gegebene `AppIDs` aus der Prioritäts-Sammelwarteschlange der gegebenen Bot-Instanzen.                                                                                                                                                                                                                                                                              |
| `hash <hashingMethod> <stringToHash>`                    | `Owner`         | Erzeugt ein Hash der Zeichenkette mit der bereitgestellten kryptografischen Methode - ausführlicher erklärt weiter **[unten](#hash-Befehl)**.                                                                                                                                                                                                                               |
| `help`                                                               | `FamilySharing` | Zeigt Hilfe an (Link zu dieser Seite).                                                                                                                                                                                                                                                                                                                                      |
| `input [Bots] <Type> <Value>`                            | `Master`        | Setzt den gegebenen Eingabetyp auf den gegebenen Wert für gegebene Bot-Instanzen. Funktioniert nur im `Headless`-Modus, genauer erklärt **[unten](#input-befehl)**.                                                                                                                                                                                                         |
| `level [Bots]`                                                       | `Master`        | Zeigt das Steam-Level der angegebenen Bot-Instanzen an.                                                                                                                                                                                                                                                                                                                     |
| `loot [Bots]`                                                        | `Master`        | Sendet alle `LootableTypes` Steam Community-Gegenstände gegebener Bot-Instanzen an `Master`, welcher in den `SteamUserPermissions` (mit niedrigster steamID, wenn mehr als eine) definiert ist.                                                                                                                                                                             |
| `loot@ [Bots] <AppIDs>`                                        | `Master`        | Sendet alle `LootableTypes` Steam Community-Gegenstände, die mit den angegebenen `AppIDs` der angegebenen Bot-Instanzen übereinstimmen an `Master`, welcher in den `SteamUserPermissions` (mit der niedrigsten SteamID, wenn mehr als eine) definiert ist. Dies ist das Gegenteil von `loot%`.                                                                              |
| `loot% [Bots] <AppIDs>`                                        | `Master`        | Sendet alle `LootableTypes` Steam Community-Gegenstände, abgesehen von den angegebenen `AppIDs` der bestimmten Bot-Instanzen, an dem vom Nutzer definiertem `Master` in den `SteamUserPermissions` (der mit der niedrigsten SteamID, falls mehrere definiert sind). Dies ist das Gegenteil von `loot@`.                                                                     |
| `loot^ [Bots] <AppID> <ContextID>`                       | `Master`        | Sendet alle Steam-Gegenstände der angegebenen `AppID` in `ContextID` der gegebenen Bot-Instanzen an `Master`, welcher in den `SteamUserPermissions` (mit niedrigster SteamID wenn mehr als eine) definiert ist.                                                                                                                                                             |
| `mab [Bots]`                                                         | `Master`        | Listet Apps auf, die vom automatischen Handel durch **[`MatchActively`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin-de-DE#matchactively)** gesperrt sind.                                                                                                                                                                                        |
| `mabadd [Bots] <AppIDs>`                                       | `Master`        | Fügt gegebene `AppIDs` zur App-Sperrliste hinzu, die vom automatischen Handeln durch **[`MatchActively`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin-de-De#matchactively)** gesperrt sind.                                                                                                                                                       |
| `mabrm [Bots] <AppIDs>`                                        | `Master`        | Entfernt gegebene `AppIDs` von der App-Sperrliste, die vom automatischen Handeln durch **[`MatchActively`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin-de-De#matchactively)** gesperrt sind.                                                                                                                                                     |
| `match [Bots]`                                                       | `Master`        | Spezielles Kommando für **[`ItemsMatcherPlugin`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin-de-DE#matchactively)**, welches die `MatchActively` Routine sofort auslöst.                                                                                                                                                                         |
| `nickname [Bots] <Nickname>`                                   | `Master`        | Ändert den Steam-Namen gegebener Bot-Instanzen auf gewünschten `nickname`.                                                                                                                                                                                                                                                                                                  |
| `owns [Bots] <Games>`                                          | `Operator`      | Prüft, ob die Bot-Instanzen bereits im Besitz von `games` sind, wie **[unten](#owns-spiele)** erklärt.                                                                                                                                                                                                                                                                      |
| `pause [Bots]`                                                       | `Operator`      | Pausiert permanent das automatische Karten-Sammel-Modul der gegebenen Bot-Instanzen. ASF wird nicht versuchen, das aktuelle Konto in dieser Sitzung zu verwalten, es sei denn, Sie setzten `resume` manuell ein oder starten den Prozess neu.                                                                                                                               |
| `pause~ [Bots]`                                                      | `FamilySharing` | Pausiert vorübergehend das automatische Karten-Sammel-Modul der gegebenen Bot-Instanzen. Das Sammeln wird beim nächsten Wiedergabe-Ereignis oder beim Trennen der Bot-Verbindung automatisch wieder fortgesetzt. Sie können `resume` eingeben, um es zu deaktivieren.                                                                                                       |
| `pause& [Bots] <Seconds>`                                  | `Operator`      | Pausiert vorübergehend das automatische Karten-Sammel-Modul gegebener Bot-Instanzen für eine bestimmte Anzahl von `seconds` (Sekunden). Nach einer Verzögerung wird das Karten-Sammel-Modul automatisch wieder aktiviert.                                                                                                                                                   |
| `play [Bots] <AppIDs,GameName>`                                | `Master`        | Wechselt zu manuellem Sammeln - startet gegebene `AppIDs` auf gegebenen Bot-Instanzen, optional auch mit benutzerdefiniertem `GameName`. Damit diese Funktion richtig funktioniert, **muss** das Steam-Konto eine gültige Lizenz für alle `AppIDs` besitzen, die Sie hier angeben; dies schließt auch F2P-Spiele ein. Benutzen Sie `reset` oder `resume` um zurückzukehren. |
| `points [Bots]`                                                      | `Master`        | Zeigt die Anzahl der Punkte im **[Steam Punkteshop](https://store.steampowered.com/points/shop)** an.                                                                                                                                                                                                                                                                       |
| `privacy [Bots] <Settings>`                                    | `Master`        | Ändert die **[Steam Privatsphäre-Einstellungen](https://steamcommunity.com/my/edit/settings)** der gegebenen Bot-Instanzen, zu entsprechend ausgewählten Optionen erklärt **[unten](#privacy-einstellungen)**.                                                                                                                                                              |
| `redeem [Bots] <Keys>`                                         | `Operator`      | Löst die angegebenen Produktschlüssel oder Guthaben-Codes auf den angegebenen Bot-Instanzen ein.                                                                                                                                                                                                                                                                            |
| `redeem^ [Bots] <Modes> <Keys>`                          | `Operator`      | Löst gegebene Produktschlüssel oder Guthaben-Codes auf gegebenen Bot-Instanzen ein, indem er gegebene `Modes` verwendet, die **[unten](#redeem-modi)** erklärt werden.                                                                                                                                                                                                      |
| `reset [Bots]`                                                       | `Master`        | Setzt den Spielstatus auf normal zurück, wird original (vorheriger) Status; der Befehl wird beim manuellen Sammeln via `play` Befehl verwendet.                                                                                                                                                                                                                             |
| `restart`                                                            | `Owner`         | Startet den ASF-Prozess neu.                                                                                                                                                                                                                                                                                                                                                |
| `resume [Bots]`                                                      | `FamilySharing` | Setzt das automatische Sammeln der gegebenen Bot-Instanzen fort.                                                                                                                                                                                                                                                                                                            |
| `start [Bots]`                                                       | `Master`        | Startet gegebene Bot-Instanzen.                                                                                                                                                                                                                                                                                                                                             |
| `stats`                                                              | `Owner`         | Gibt Prozessstatistiken an, wie z. B. die Nutzung des verwalteten Speichers.                                                                                                                                                                                                                                                                                                |
| `status [Bots]`                                                      | `FamilySharing` | Zeigt den Status der gegebenen Bot-Instanzen an.                                                                                                                                                                                                                                                                                                                            |
| `std [Bots]`                                                         | `Master`        | Spezieller Befehl für **[`SteamTokenDumperPlugin`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/SteamTokenDumperPlugin-de-De)**, welcher die Aktualisierung der ausgewählten Bots und die Datenübermittlung sofort auslöst.                                                                                                                                          |
| `stop [Bots]`                                                        | `Master`        | Stoppt gegebene Bot-Instanzen.                                                                                                                                                                                                                                                                                                                                              |
| `tb [Bots]`                                                          | `Master`        | Listet Benutzer aus dem Handelsmodul der gegebenen Bot-Instanzen auf, die auf der schwarzen Liste stehen.                                                                                                                                                                                                                                                                   |
| `tbadd [Bots] <SteamIDs64>`                                    | `Master`        | Setzt gegebene `steamIDs` auf die Schwarze Liste des Handelsmoduls der gegebenen Bot-Instanzen.                                                                                                                                                                                                                                                                             |
| `tbrm [Bots] <SteamIDs64>`                                     | `Master`        | Entfernt gegebene `steamIDs` von der schwarzen Liste des Handelsmoduls für gegebene Bot-Instanzen.                                                                                                                                                                                                                                                                          |
| `transfer [Bots] <TargetBot>`                                  | `Master`        | Sendet alle `TransferableTypes` Steam Community-Gegenstände von gegebenen Bot-Instanzen an die Ziel-Bot-Instanz.                                                                                                                                                                                                                                                            |
| `transfer@ [Bots] <AppIDs> <TargetBot>`                  | `Master`        | Sendet alle `TransferableTypes` Steam Community-Gegenstände, die mit den gegebenen `AppIDs` übereinstimmen, von gegebenen Bot-Instanzen an die Ziel-Bot-Instanz. Dies ist das Gegenteil von `transfer%`.                                                                                                                                                                    |
| `transfer% [Bots] <AppIDs> <TargetBot>`                  | `Master`        | Sendet alle `TransferableTypes` Steam Community-Gegenstände, abgesehen von den angegebenen `AppIDs` von bestimmten Bot-Instanzen an die Ziel-Bot-Instanz. Dies ist das Gegenteil von `transfer@`.                                                                                                                                                                           |
| `transfer^ [Bots] <AppID> <ContextID> <TargetBot>` | `Master`        | Sendet alle Steam-Gegenstände von gegebener `AppID` in `ContextID` der gegebenen Bot-Instanzen an die Ziel-Bot-Instanz.                                                                                                                                                                                                                                                     |
| `unpack [Bots]`                                                      | `Master`        | Entpackt alle Booster Packs, die im Inventar der gegebenen Bot-Instanzen gespeichert sind.                                                                                                                                                                                                                                                                                  |
| `update [Channel]`                                                   | `Owner`         | Prüft GitHub auf neue ASF-Versionen und aktualisiert diese, falls verfügbar. Normalerweise geschieht dies automatisch jede `UpdatePeriod`. Als optionales `Channel` Argument wird `UpdateChannel` spezifiziert, falls keine Standardeinstellung in der globalen Konfiguration angegeben ist.                                                                                |
| `version`                                                            | `FamilySharing` | Gibt die ASF-Version an.                                                                                                                                                                                                                                                                                                                                                    |

---

### Anmerkungen

Bei Befehlen selbst ist die Groß- und Kleinschreibung egal, aber bei deren Argumenten (wie zum Beispiel Bot-Namen) muss die Groß- und Kleinschreibung beachtet werden.

Argumente folgen der UNIX-Philosophie; eckige Klammern `[Optional]` zeigen an, dass das angegebene Argument optional ist, während der Winkel-Klammern `<Mandatory>` zeigt an, dass das angegebene Argument erforderlich ist. Sie sollten die Argumente, die Sie deklarieren möchten, ersetzen. Zum Beispiel `[Bots]` oder `<Nickname>` mit den tatsächlichen Werten, mit denen Sie den Befehl ausgeben möchten (weglassen der Klammern).

Das `[Bots]` Argument, wie von den Klammern angegeben, ist in allen Befehlen optional. Wenn verwendet, wird der Befehl auf den angegebenen Bots ausgeführt. Ohne diese Angabe wird der Befehl auf dem Bot ausgeführt, der den Befehl erhält. Mit anderen Worten: Wenn `status A` an Bot `B` gesendet wird ist es dasselbe wie wenn `status` an Bot `A` gesendet wird. Bot `B` dient in diesem Fall nur als Proxy. Dies kann auch zum Senden von Befehlen an Bots verwendet werden, die andernfalls nicht verfügbar sind. Zum Beispiel das Starten angehaltener Bots oder die Ausführung von Aktionen auf Ihrem Hauptkonto (welches Sie für die Ausführung der Befehle verwenden).

Der **Zugriff** eines Befehls definiert die **minimale** `EPermission` von `SteamUserPermissions`, die für die Verwendung des Befehls erforderlich ist - mit Ausnahme von `Owner` der als `SteamOwnerID` in der globalen Konfigurationsdatei (und damit höchste verfügbare Berechtigung) eingestellt ist.

Mehrere Argumente, wie `[Bots]`, `<Keys>` oder `<AppIDs>` bedeuten, dass der Befehl mehrere, mit Komma getrennte, Argumente eines gegebenen Typs unterstützt. `status [Bots]` kann zum Beispiel als `status MyBot,MyOtherBot,Primär` verwendet werden. Dies führt dazu, dass der angegebene Befehl auf **alle Ziel-Bots** auf die gleiche Weise ausgeführt wird, wie wenn Sie `status` an jeden Bot in einem separaten Chat-Fenster senden würden. Bitte beachten Sie, dass nach `,` kein Leerzeichen steht.

ASF verwendet alle Whitespace-Zeichen als mögliche Trennzeichen für einen Befehl, wie Leerzeichen und Zeilenumbrüche. Das bedeutet, dass Sie zur Begrenzung der Argumente keine Leerzeichen verwenden müssen. Sie können auch jedes andere Whitespace-Zeichen (z. B. Tabulator oder Zeilenumbruch) verwenden.

ASF wird zusätzliche "Out of Range"-Argumente mit dem Plural-Typ des letzten "In Range"-Arguments "verbinden". Dies bedeutet, dass `redeem bot key1 key2 key3` für `redeem [Bots] <Keys>` genauso funktionieren wird, wie `redeem bot key1,key2,key3`. Da ein Zeilenumbruch als Trennzeichen verwendet werden kann ermöglicht Ihnen dies, `redeem bot` zu schreiben und dann eine Liste von Produktschlüsseln einzufügen, die durch ein beliebiges zulässiges Trennzeichen (z. B. Zeilenumbruch) oder dem Standard `,` ASF-Trennzeichen getrennt sind. Bedenken Sie, dass dieser Trick nur für eine Befehlsvariante verwendet werden kann, die die meiste Anzahl von Argumenten verwendet (daher ist die Angabe von `[Bots]` in diesem Fall notwendig).

Wie Sie oben gelesen haben, wird ein Leerzeichen als Trennzeichen für einen Befehl verwendet, daher kann es nicht in Argumenten verwendet werden. Allerdings kann ASF auch, wie oben erwähnt, "Out-of-Range"-Argumente verbinden, was bedeutet, dass Sie tatsächlich ein Leerzeichen in Argumenten verwenden könnten, das als Letztes für den angegebenen Befehl definiert ist. Zum Beispiel: `nickname bob Great Bob` wird den Benutzernamen des Bots `bob` richtig auf "Great Bob" setzen. Auf die gleiche Weise können Sie Namen, die Leerzeichen enthalten, im Befehl `owns` überprüfen.

---

Einige Befehle sind auch mit Ihrem jeweiligen Alias verfügbar, hauptsächlich um Sie beim Tippen oder Konto für verschiedene Dialekte zu unterstützen:

| Befehl       | Alias        |
| ------------ | ------------ |
| `addlicense` | `addlicence` |
| `owns ASF`   | `oa`         |
| `status ASF` | `sa`         |
| `redeem`     | `r`          |
| `redeem^`    | `r^`         |

---

### `[Bots]` Argument

`[Bots]` Argument ist eine spezielle Variante des Plural Arguments, da es neben der Annahme mehrerer Werte auch zusätzliche Funktionalität bietet.

Es gibt zunächst ein spezielles Schlüsselwort `ASF`, das als "alle Bots im Prozess" fungiert, sodass der Befehl `status ASF` gleich `status all,your,bots,listed,here` ist. Dies kann auch verwendet werden, um die Bots zu identifizieren, auf die Sie Zugriff haben, da das `ASF`-Schlüsselwort, trotz der Ausrichtung auf alle Bots, nur von den Bots eine Antwort generiert, an die Sie den Befehl tatsächlich senden können.

Das Argument `[Bots]` unterstützt eine speziellen "range"-Syntax, der es Ihnen ermöglicht, eine Reihe von Bots einfacher auszuwählen. Die allgemeine Syntax für `[Bots]` in diesem Fall ist `[FirstBot]..[LastBot]`. Mindestens eines der Argumente muss definiert werden. Mit `<FirstBot>..`sind alle Bots beginnend von `FirstBot` betroffen. Bei der Verwendung von `..<LastBot>`sind alle Bots bis `LastBot` betroffen. Nutzen Sie stattdessen `<FirstBot>..<LastBot>`, sind alle Bots im Bereich von `FirstBot` bis `LastBot` betroffen. Wenn Sie zum Beispiel Bots mit den Namen `A, B, C, D, E, F` haben, können Sie `status B..E` ausführen, was in diesem Fall gleich `status B,C,D,E` bedeutet. Bei Verwendung dieser Syntax verwendet ASF die alphabetische Sortierung, um festzustellen, welche Bots sich in dem von Ihnen angegebenen Bereich befinden. Argumente müssen gültige Bot-Namen sein, die von ASF erkannt werden, sonst wird die Bereichssyntax komplett übersprungen.

Zusätzlich zum obigen range-syntax unterstützt das `[Bots]` Argument auch **[regex](https://de.wikipedia.org/wiki/Regul%C3%A4rer_Ausdruck)** Übereinstimmung. Sie können Regex Muster aktivieren, indem Sie `r!<Pattern>` als Bot-Namen verwenden, wobei `r!` der ASF-Aktivator für den Regex Abgleich ist, und `<Pattern>` Ihr Regex-Muster darstellt. Ein Beispiel für einen regex-basierten Bot-Befehl wäre `Status r! \d{3}`, der den `Status` an Bots sendet, die einen Namen bestehend aus 3 Ziffern (z. B. `123` und `981`) haben. Zögern Sie nicht einen Blick auf die **[Dokumentation](https://docs.microsoft.com/de-de/dotnet/standard/base-types/regular-expression-language-quick-reference)** zu werfen, um weitere Erklärungen und Beispiele für verfügbare Regex-Muster zu erhalten.

---

## `privacy` Einstellungen

`<Settings>` Argument akzeptiert **bis zu 7** verschiedene Optionen, getrennt wie üblich durch das standardmäßige ASF-Trennzeichen, das Komma. Diese sind, in folgender Reihenfolge:

| Argument | Name           | Untergeordnet von |
| -------- | -------------- | ----------------- |
| 1        | Profile        |                   |
| 2        | OwnedGames     | Profile           |
| 3        | Playtime       | OwnedGames        |
| 4        | FriendsList    | Profile           |
| 5        | Inventory      | Profile           |
| 6        | InventoryGifts | Inventory         |
| 7        | Comments       | Profile           |

Für eine Beschreibung der oben genannten Felder besuche bitte die **[Steam Privatsphäre-Einstellungen](https://steamcommunity.com/my/edit/settings)**.

Für alle Argumente sind folgende Werte gültig:

| Wert | Name          |
| ---- | ------------- |
| 1    | `Private`     |
| 2    | `FriendsOnly` |
| 3    | `Public`      |

Sie können entweder den Namen (unabhängig der Groß-/Kleinschreibung) oder den numerischen Wert verwenden. Argumente, die weggelassen wurden, werden standardmäßig auf `Private` gesetzt. Es ist wichtig, die Beziehung zwischen Untergruppe (Kind) und Hauptgruppe (Eltern) von oben genannten Argumenten zu beachten, da das Kind nie mehr Berechtigung haben kann als sein Elternteil. Zum Beispiel können Sie die Einstellung `Public` Spiele im Besitz **nicht** verwenden, während Ihr Profil auf `Private` steht.

### Beispiel

Wenn Sie **alle** Privatsphäre-Einstellungen Ihres Bots namens `Main` auf `Private` setzen möchten, können Sie jede der folgenden Optionen verwenden:

```text
privacy Main 1
privacy Main Private
```

Dies liegt daran, dass ASF automatisch alle anderen Einstellungen als `Private` ansieht, sodass es nicht notwendig ist, diese zu spezifizieren. Wenn Sie stattdessen alle Privatsphäre-Einstellungen auf `Public` setzen möchten, dann muss eine der folgenden Optionen verwendet werden:

```text
privacy Main 3,3,3,3,3,3,3
privacy Main Public,Public,Public,Public,Public,Public,Public
```

Auf diese Weise können Sie auch einzelne Einstellungen so vornehmen, wie Sie möchten:

```text
privacy Main Public,FriendsOnly,Private,Public,Public,Private,Public
```

Das oben genannte wird das Profil auf öffentlich setzen, eigene Spiele auf nur für Freunde, Spielzeit auf privat, Freundesliste auf öffentlich, Inventar auf öffentlich, Inventar Geschenke auf privat und Profil-Kommentare auf öffentlich. Das Gleiche kann man mit numerischen Werten erreichen, wenn man dies möchte.

---

## `addlicense` Lizenzen

`addlicense` Befehl unterstützt zwei verschiedene Lizenztypen, diese sind:

| Typ   | Alias | Beispiel     | Beschreibung                                                                      |
| ----- | ----- | ------------ | --------------------------------------------------------------------------------- |
| `app` | `a`   | `app/292030` | Spiel bestimmt durch seine einzigartige `AppID`.                                  |
| `sub` | `s`   | `sub/47807`  | Paket mit einem oder mehreren Spielen, bestimmt durch seine einzigartige `subID`. |

Die Differenzierung ist wichtig, da ASF die Aktivierung übers Steam Netzwerk (für Apps) und über den Steam Shop (für Pakete) verwenden wird. Diese beiden sind nicht miteinander kompatibel, normalerweise werden Apps für Spiele mit kostenlosen Wochenenden und dauerhaft kostenlose Spiele verwendet, und Packages für alles andere.

Wir empfehlen, die Art jedes Eintrags explizit zu definieren, um zweideutige Ergebnisse zu vermeiden, aber für die Abwärtskompatibilität, wird ASF, wenn Sie einen ungültigen Typ angeben oder ihn ganz weglassen, davon ausgehen, dassSie `sub` anfordern. Sie können auch eine oder mehrere Lizenzen gleichzeitig abfragen, indem Sie das standarmäßige ASF-Trennzeichen (`,`) verwenden.

Beispiel für einen vollständigen Befehl:

```text
addlicense ASF app/292030,sub/47807
```

---

## `owns` Spiele

Der `owns` Befehl unterstützt verschiedene Spielarten die für das `<games>` Argument genutzt werden können, diese sind:

| Typ     | Alias | Beispiel         | Beschreibung                                                                                                                                                                                                                                                                                                                         |
| ------- | ----- | ---------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| `app`   | `a`   | `app/292030`     | Spiel bestimmt durch seine einzigartige `AppID`.                                                                                                                                                                                                                                                                                     |
| `sub`   | `s`   | `sub/47807`      | Paket mit einem oder mehreren Spielen, bestimmt durch seine einzigartige `subID`.                                                                                                                                                                                                                                                    |
| `regex` | `r`   | `regex/^\d{4}:` | **[Regex](https://de.wikipedia.org/wiki/Regulärer_Ausdruck)** der sich auf den Namen des Spiels bezieht, Groß- und Kleinschreibung wird berücksichtigt. Siehe **[docs](https://docs.microsoft.com/de-de/dotnet/standard/base-types/regular-expression-language-quick-reference)** für den vollständige Syntax und weitere Beispiele. |
| `name`  | `n`   | `name/Witcher`   | Teil des Namens des Spiels, Groß- und Kleinschreibung wird nicht berücksichtigt.                                                                                                                                                                                                                                                     |

Wir empfehlen, die Art jedes Eintrags explizit zu definieren, um zweideutige Ergebnisse zu vermeiden, aber für die Abwärtskompatibilität, wird ASF wenn Sie einen ungültigen Typ angeben oder ihn komplett weglassen, davon ausgehen, dass Sie `app` verlangen, wenn Ihre Eingabe eine Nummer ist, und `name` falls nicht. Sie können auch eine oder mehrere Lizenzen gleichzeitig abfragen, indem Sie die Standard ASF-Trennzeichen (`,`) verwenden.

Beispiel für einen vollständigen Befehl:

```text
owns ASF app/292030,name/Witcher
```

---

## `redeem^` Modi

Der Befehl `redeem^` ermöglicht es Ihnen, die Modi zu optimieren, die für ein einzelnes Einlöse-Szenario verwendet werden. Dazu wird temporär die `RedeemingPreferences` **[Bot-Konfigurationseigenschaft](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-de-DE#redeemingpreferences)** überschrieben.

`<Modes>` Argument akzeptiert mehrere Modus-Werte, die, wie üblich, durch ein Komma getrennt werden. Die verfügbaren Modus-Werte sind im Folgenden aufgeführt:

| Wert | Name                  | Beschreibung                                                                                                  |
| ---- | --------------------- | ------------------------------------------------------------------------------------------------------------- |
| FAWK | ForceAssumeWalletKey  | Erzwingt `AssumeWalletKeyOnBadActivationCode` Einlöseeinstellungen zu aktivieren                              |
| FD   | ForceDistributing     | Erzwingt die Aktivierung der `Distributing` Einlöse-Präferenz                                                 |
| FF   | ForceForwarding       | Erzwingt die Aktivierung der `Forwarding` Einlöse-Präferenz                                                   |
| FKMG | ForceKeepMissingGames | Erzwingt die Aktivierung der `KeepMissingGames` Einlöse-Präferenz                                             |
| SAWK | SkipAssumeWalletKey   | Erzwingt `AssumeWalletKeyOnBadActivationCode` Einlöseeinstellungen zu deaktivieren                            |
| SD   | SkipDistributing      | Erzwingt die Deaktivierung der `Distributing` Einlöse-Präferenz                                               |
| SF   | SkipForwarding        | Erzwingt die Deaktivierung der `Forwarding` Einlöse-Präferenz                                                 |
| SI   | SkipInitial           | Überspringt die Produktschlüssel-Aktivierung beim ersten Bot                                                  |
| SKMG | SkipKeepMissingGames  | Erzwingt die Deaktivierung der `KeepMissingGames` Einlöse-Präferenz                                           |
| V    | Validate              | Überprüft die Produktschlüssel auf das richtige Format und überspringt automatisch ungültige Produktschlüssel |

Zum Beispiel möchten wir drei Produktschlüssel auf einem unserer Bots einlösen, der noch keine Spiele besitzt, aber nicht auf unserem `primary` Bot. Um das zu erreichen, können wir Folgendes nutzen:

`redeem^ primary FF,SI key1,key2,key3`

Es ist wichtig zu beachten, dass fortgeschrittenes Einlösen nur die `RedeemingPreferences` überschreibt, die Sie **im Befehl angegeben haben**. Wenn Sie zum Beispiel `Distributing` in Ihren `RedeemingPreferences` aktiviert haben, dann macht es keinen Unterschied, ob der `FD` Modus genutzt wird oder nicht, weil die Verteilung trotzdem bereits aktiv ist, aufgrund der `RedeemingPreferences` die Sie verwenden. Deshalb hat jede zwangsweise aktivierte Überschreibung auch zwangsläufig eine deaktivierte. Sie können selbst entscheiden, ob die deaktivierte mit der aktivierten überschrieben werden soll oder umgekehrt.

---

## `encrypt` Befehl

`encrypt` erlaubt es Ihnen beliebige Strings mit ASF-Verschlüsselungsmethoden zu verschlüsseln. `<encryptionMethod>` muss eine der Verschlüsselungsmethoden sein, welche im Abschnitt **[Sicherheit](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security-de-DE#Sicherheit)** angegeben und erklärt ist. Wir empfehlen, diesen Befehl über sichere Kanäle zu verwenden (ASF-Konsole oder IPC-Schnittstelle, für die es auch einen dedizierten API-Endpunkt gibt), da sonst sensible Details von verschiedenen Dritten protokolliert werden könnten (z. B. Chat-Nachrichten, die von Steam-Servern protokolliert werden).

---

## `hash` Befehl

Der Befehl `hash` erlaubt Ihnen Hashes beliebiger Zeichenketten mit ASF's hash-Methoden zu generieren. `<hashingMethod>` muss eine der Hash-Methoden sein, welche im Abschnitt **[Sicherheit](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security-de-DE)** angegeben und erklärt ist. Wir empfehlen, diesen Befehl über sichere Kanäle zu verwenden (ASF-Konsole oder IPC-Schnittstelle, für die es auch einen dedizierten API-Endpunkt gibt), da sonst sensible Details von verschiedenen Dritten protokolliert werden könnten (z. B. Chat-Nachrichten, die von Steam-Servern protokolliert werden).

---

## `input` Befehl

Der Befehl `input` kann nur im `headless` Modus verwendet werden, für die Eingabe von Daten über **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-de-DE)** oder Steam Chat, wenn ASF ohne Unterstützung für Benutzerinteraktion läuft.

Die allgemeine Syntax ist `input [Bots] <Type> <Value>`.

`<Type>` ist Groß-/Kleinschreibung unabhängig und definiert einen von ASF unterstützten Eingabetyp. Derzeit unterstützt ASF folgende Typen:

| Typ                             | Beschreibung                                                                                            |
| ------------------------------- | ------------------------------------------------------------------------------------------------------- |
| Login                           | `SteamLogin` Bot-Konfigurationseigenschaft, falls diese in der Konfiguration fehlt.                     |
| Password                        | `SteamPassword` Bot-Konfigurationseigenschaft, falls diese in der Konfiguration fehlt.                  |
| SteamGuard                      | Auth-Code, der an Ihre E-Mail gesendet wird, falls Sie 2FA nicht nutzen.                                |
| SteamParentalCode               | ` SteamParentalCode ` Bot-Konfigurationseigenschaft, falls diese in der Konfiguration fehlt.            |
| Two-factor Authentication (2FA) | 2FA-Code, der von Ihrem Handy generiert wurde, sofern Sie den Standard-2FA benutzt, aber nicht ASF-2FA. |
| DeviceConfirmation              | Legt fest, ob das Pop-up zur Bestätigung für die Anmeldung akzeptiert wurde                             |

`<Value>` ist der Wert, der für einen angegebenen Typ gesetzt werden soll. Derzeit sind alle Werte Zeichenketten.

### Beispiel

Lass uns annehmen, dass wir einen Bot haben, der durch SteamGuard (nicht im Zwei-Faktor-Modus) geschützt wird. Wir möchten diesen Bot starten während das Konfigurationsfeld `Headless` auf `true` gesetzt ist.

Um das zu tun, müssen wir folgende Befehle ausführen:

`start MySteamGuardBot` -> Bot wird versuchen sich anzumelden; dies schlägt jedoch fehl, da AuthCode benötigt; schließlich wird der Vorgang gestoppt, da dieser im `Headless`-Modus ausgeführt wird. Wir brauchen dies, damit das Steam-Netzwerk uns den Auth-Code an unsere E-Mail sendet - falls das nicht nötig wäre, würden wir diesen Schritt komplett überspringen.

`input MySteamGuardBot SteamGuard ABCDE` -> Wir setzen die `SteamGuard` Eingabe vom `MySteamGuardBot` Bot auf `ABCDE`. Natürlich sollte `ABCDE` der Code sein, den Sie in der E-Mail erhalten haben.

`start MySteamGuardBot` -> Wir starten erneut unseren (gestoppten) Bot dieses Mal verwendet es automatisch den Auth-Code, den wir im vorherigen Befehl gesetzt haben, ordnungsgemäß einloggen und dann löschen.

Auf demselben Weg können wir auf Bots, die durch Zwei-Faktor-Authentifizierung geschützt sind (und nicht die 2FA von ASF verwenden), zugreifen und andere Dinge während der Laufzeit tun.