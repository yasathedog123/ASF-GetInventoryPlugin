# Zwei-Faktor-Authentifizierung (2FA)

Steam beinhaltet das Zwei-Faktor-Authentifizierungssystem, bekannt als „Escrow“, das zusätzliche Details für verschiedene kontenbezogene Aktivitäten erfordert. Sie können **[hier](https://help.steampowered.com/faqs/view/2E6E-A02C-5581-8904)** und **[hier](https://help.steampowered.com/faqs/view/34A1-EA3F-83ED-54AB)** mehr darüber lesen. Diese Seite befasst sich mit dem 2FA-System sowie unserer Lösung, die mit ihm integriert wird (ASF-2FA).

---

# ASF-Logik

Unabhängig davon, ob Sie ASF-2FA verwenden oder nicht, enthält ASF die passende Logik und ist sich bewusst, dass die Konten durch die Standard-2FA geschützt sind. Es fragt Sie nach den erforderlichen Details, sobald diese benötigt werden (z. B. beim Anmelden). Es ist jedoch möglich, diese Anfragen durch ASF-2FA zu automatisieren, wodurch automatisch Token generiert, Ihnen lästige Aufgaben abgenommen und zusätzliche Funktionen hinzugefügt werden (Erläuterungen siehe unten).

---

# ASF-2FA

ASF-2FA ist ein eingebautes Modul, das für die Bereitstellung von 2FA-Funktionen für den ASF-Prozess verantwortlich ist, wie dem Erzeugen von Codes und das Annehmen von Bestätigungen. Es funktioniert durch das Duplizieren Ihres bestehenden Authentifikators, sodass Sie Ihren aktuellen Steam Guard und ASF-2FA gleichzeitig verwenden können.

Sie können überprüfen, ob Ihr Bot-Konto bereits ASF-2FA verwendet, indem Sie den **[Befehl](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-de-DE)** `2fa` ausführen. Sofern Sie Ihren Authentifikator nicht bereits als ASF-2FA importiert haben, ist keiner der standardmäßigen `2fa`-Befehle funktionsfähig, was bedeutet, dass Ihr Konto ASF-2FA nicht verwendet und es deshalb nicht für erweiterte ASF-Funktionen verfügbar ist, die den Betrieb des Moduls erfordern.

---

# Empfehlungen

Wir bieten Ihnen eine Vielzahl an Möglichkeiten, ASF 2FA operativ zu behandeln. Unsere Empfehlungen basieren auf Ihrer aktuellen Situation:

- Falls Sie bereits SteamDesktopAuthenticator, WinAuth oder eine andere Drittanbieter-App verwenden, mit der Sie 2FA-Details problemlos extrahieren können, nur **[importieren Sie](#import)** diese zu ASF.
- Wenn Sie die offizielle App verwenden und Sie nichts dagegen haben, Ihre 2FA-Anmeldeinformationen zurückzusetzen; dann ist der beste Weg, 2FA zu deaktivieren, dann **[](#erstellung)** neue 2FA-Anmeldedaten unter Verwendung des **[gemeinsamen Authentifikators](#gemeinsamer-authentifikator)**, mit der Sie die offizielle App und ASF-2FA verwenden können. Diese Methode erfordert kein *root*, oder fortgeschrittenes Wissen, geschweige denn eine Fülle an Anweisungen.
- Wenn Sie die offizielle App verwenden und Ihre 2FA-Anmeldeinformationen nicht neu erstellen möchten, sind Ihre Optionen sehr begrenzt; typischerweise benötigen Sie *root* und zusätzliches Experimentieren, um diese Details **[zu importieren](#importieren)**, und sogar mit diesem könnte es unmöglich sein.
- Wenn Sie noch keine 2FA verwenden und es Ihnen egal ist, kommen als ASF-2FA die Nutzung des **[eigenständigen Authentifikators](#eigenst%C3%A4ndiger-authentifikator)**, die **[Duplizierung](#importieren)** der Drittanbieter-App nach ASF (Empfehlung #1), oder der **[gemeinsamer Authentifikator](#gemeinsamer-authentifikator)** mit offizieller App (Empfehlung #2) für Sie infrage.

Im Folgenden diskutieren wir alle möglichen Optionen und bekannte Methoden.

---

## Erstellung

Im Allgemeinen empfehlen wir dringend **[Ihren bestehenden Authentifikator zu duplizieren](#import)**, da dies der Hauptzweck der ASF-2FA ist. ASF verfügt jedoch über eine offizielle `MobileAuthenticator`-**[Erweiterung](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)**, welche ASF-2FA dahin gehend ergänzt, sodass Sie auch einen komplett neuen Authentifikator verknüpfen können. Dies kann hilfreich sein, wenn Sie nicht bereit oder in der Lage sind, andere Tools zu verwenden und es keine Einwände gibt, dass ASF-2FA Ihr (möglicherweise einziger) Hauptauthentifikator sein wird.

Es gibt zwei mögliche Szenarien für das Hinzufügen eines Zwei-Faktor-Authentifikators mit dem `MobileAuthenticator`-**[Erweiterung](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)**: Alleinstehend oder gemeinsam mit der offiziellen Steam Mobile App. Im zweiten Szenario werden Sie einen identischen Authentifikator sowohl für mit ASF, als auch in der mobilen App teilen; beide generieren dieselben Codes, und beide werden imstande sein, Handelsangebote, Steam „Communitymarkt“-Transaktionen usw. zu bestätigen.

### Gemeinsame Schritte für beide Szenarien

Egal, ob Sie vorhaben ASF als alleinstehenden Authentifikator verwenden oder die gleiche 2FA in der offiziellen Steam App zu nutzen, – Sie müssen diese Initialisierungsschritte machen:

1. Erstellen Sie einen ASF-Bot für das Zielkonto, starten Sie ihn und melden Sie sich an (was Sie wahrscheinlich bereits getan haben).
2. Optional weisen Sie dem Konto **[hier](https://store.steampowered.com/phone/manage)** eine funktionierende und operative Telefonnummer zu, die vom Bot verwendet werden soll. Dies erlaubt Ihnen den Empfang von SMS-Code, sowie bei Bedarf die Wiederherstellung, aber es ist nicht erforderlich.
3. Stellen Sie sicher, dass Sie 2FA bisher nicht für Ihr Konto verwenden; deaktivieren Sie es zuerst, falls doch.
4. Führen Sie den Befehl `2fainit [Bot]` aus, indem Sie `[Bot]` durch den Namen Ihres Bots ersetzen.

Angenommenen, Sie haben eine erfolgreiche Antwort erhalten; dann sind die folgenden zwei Dinge passiert:

- Eine neue Datei `<Bot>.maFile.PENDING` wurde von ASF in Ihrem `Konfigurations`-Verzeichnis generiert.
- SMS wurde von Steam an die Telefonnummer gesendet, die Sie für das oben genannte Konto zugewiesen haben. Wenn Sie keine Telefonnummer angegeben haben, wurde stattdessen eine E-Mail an die E-Mail-Adresse des Kontos gesendet.

Die Authentifizierungsdetails sind noch nicht funktionsfähig, aber Sie können die generierte Datei überprüfen, wenn Sie es wünschen. Für den Fall, dass Sie doppelte Sicherheit wünschen, können Sie den Widerrufscode bereits notieren. Die nächsten Schritte hängen von Ihrem gewählten Szenario ab.

### Eigenständiger Authentifikator

Falls Sie ASF als (möglicherweise einzigen) Hauptauthentifikator verwenden möchten, müssen Sie jetzt den Finalisierungsschritt durchführen:

5. Führt den Befehl `2fafinalize [Bot] <ActivationCode>` aus; ersetzt `[Bot]` mit dem Namen Ihres Bots und `<ActivationCode>` mit dem Code, den Sie im vorherigen Schritt per SMS oder E-Mail erhalten haben.

### Gemeinsamer Authentifikator

Wenn Sie den identischen Authentifikator sowohl in der ASF, als auch in der offiziellen Steam Mobile App haben möchten, dann sind jetzt die nachfolgenden Schritte erforderlich:

5. Ignoriere die SMS oder den E-Mail-Code, den Sie nach dem vorherigen Schritt erhalten haben.
6. Installieren Sie die mobilen Steam App, falls sie bisher nicht installiert ist, und öffnen Sie diese. Navigieren Sie zur Registerkarte „Steam Guard“ und fügen Sie einen neuen Authentifikator hinzu, indem Sie den Anweisungen der App folgen.
7. Nachdem Ihr Authentifikator in der mobilen App hinzugefügt wurde und funktioniert, kehren Sie zu ASF zurück. Es ist notwendig, ASF zu informieren, dass die Fertigstellung mittels der folgenden Befehle erfolgt:
 - Warten Sie, bis der nächste 2FA-Code in der Steam Mobile App angezeigt wird, und verwenden Sie den Befehl `2fafinalized [Bot] <2fa_code_from_app>` (`[Bot]` mit dem Namen Ihres Bots ersetzen) und `<2fa_code_from_app>` mit dem Code, den Sie derzeit in der Steam Mobile App sehen. Falls der von ASF generierte Code und der von Ihnen angegebene Code übereinstimmt, ASF geht davon aus, dass ein Authentifikator korrekt hinzugefügt wurde und setzt den Import Ihres neu erstellten Authentifikators fort.
 - Wir empfehlen dringend, die vorherige Schritte zu befolgen, um sicherzustellen, dass Ihre Anmeldedaten gültig sind. Wenn Sie jedoch nicht überprüfen möchten (oder können), ob Codes identisch sind und Sie wissen, was Sie tun; dann können Sie stattdessen den Befehl `2fafinalizedforce [Bot]` verwenden (`[Bot]` mit dem Namen Ihres Bots ersetzen). ASF geht davon aus, dass der Authentifikator korrekt eingefügt und Sie nun mit dem Import Ihres neuen Authentifikators beginnen werden.

### Nach Abschluss

Angenommen, alles funktionierte richtig, wurde die zuvor generierte Datei `<Bot>.maFile.PENDING` in `<Bot>.maFile.NEW` umbenannt. Dies belegt, dass Ihre 2FA-Anmeldedaten nun gültig und aktiv sind. Wir empfehlen Ihnen, eine Kopie dieser Datei zu erstellen und sie in **an einem geschützten und sicheren Ort** aufzubewahren. Ferner empfehlen wir Ihnen, die Datei in Ihrem bevorzugten Editor zu öffnen und den `revocation_code` aufzuschreiben. Das erlaubt es Ihnen erlauben, den Authentifikator zu widerrufen, falls Sie (den Zugriff auf) ihn verlieren.

Im Hinblick auf technische Details umfasst die generierte `maFile` sämtliche Informationen, die wir vom Steam-Server erhalten haben, sowie das Feld `device_id`, welches für andere Authentifikatoren von Bedeutung ist. Die Datei ist vollständig kompatibel mit **[SDA](#steamdesktopauthenticator)** für den Import.

ASF importiert automatisch Ihren Authentifikator. Sobald die Prozedur abgeschlossen ist, sollten `2fa` und andere verwandte Befehle nun für das Bot-Konto funktionieren, mit dem Sie den Authentifikator verbunden haben.

---

## Importieren

Der Import erfordert bereits einen verknüpften und funktionsfähigen Authentifikator, der von ASF unterstüzt wird. ASF unterstützt derzeit diverse offizielle und inoffiziell 2FA-Quellen – Android, SteamDesktopAuthenticator und WinAuth, zusätzlich zur manuellen Methode, die es Ihnen erlaubt, die benötigten Anmeldedaten selbst zur Verfügung zu stellen. Sofern Sie noch keinen Authentifikator haben, müssen Sie einen davon auswählen und ihn zuerst einrichten. Wenn Sie nicht genau wissen, welchen Sie auswählen sollten, empfehlen wir WinAuth, aber alle der oben genannten Möglichkeiten funktionieren zuverlässig, sofern Sie die Anweisungen befolgen.

Alle folgenden Anleitungen erfordern von Ihnen, dass Sie bereits einen **funktionierenden und betriebsbereiten** Authentifikator haben, der mit dem gegebenen Programm/Werkzeug verwendet wird. ASF-2FA funktioniert nicht ordnungsgemäß, wenn Sie ungültige Daten importieren. Stelle daher sicher, dass Ihr Authentifikator ordnungsgemäß funktioniert, bevor Sie versuchen ihn zu importieren. Dies beinhaltet das Testen und Überprüfen, ob die folgenden Authentifikator-Funktionen ordnungsgemäß funktionieren:
- Sie können Codes generieren und diese Codes werden vom Steam-Netzwerk akzeptiert
- Sie können Bestätigungen abrufen und diese kommen auf Ihrem mobilen Authentifikator an
- Sie können diese Bestätigungen akzeptieren und sie werden vom Steam-Netzwerk ordnungsgemäß als bestätigt/abgelehnt erkannt

Vergewissern Sie sich, dass Ihr Authentifikator funktioniert, indem Sie überprüfen, ob die obigen Aktionen funktionieren – wenn nicht, dann werden sie auch nicht in ASF funktionieren und Sie verschwenden nur Zeit und erzeugen Ihren selbst zusätzliche Probleme.

---

### Android-Handy

Im Allgemeinen benötigen Sie für den Import des Authentifikators von Ihrem Android-Handy **[root](https://de.wikipedia.org/wiki/Rooting_(Android_OS))**-Zugriff. Die folgenden Anweisungen erfordern von Ihnen gewisse Kenntnisse aus der „Android Modding-Welt“; wir werden definitiv nicht jeden Schritt hier erklären. Besuchen Sie **[XDA](https://xdaforums.com)** und andere Ressourcen für zusätzliche Informationen/Hilfe zum unten stehenden.

Voraussetzungen:
- Installieren Sie die offizielle **[Steam App](https://play.google.com/store/apps/details?id=com.valvesoftware.android.steam.community)** aus dem PlayStore, falls Sie dies bisher nicht getan haben.
- Weisen Sie Ihrem Konto den Authentifikator zu und stellen Sie sicher, dass dieser funktioniert (generiert gültige Token und kann Bestätigungen akzeptieren).

Extrahierung (Ihr Geräte muss gerootet sein):
- Installieren Sie **[Magisk](https://topjohnwu.github.io/Magisk/install.html)** und aktivieren Sie Zygisk in den Einstellungen.
- Installieren Sie **[LSPosed](https://github.com/LSPosed/LSPosed?tab=readme-ov-file#install)** (für Zygisk) und stellen Sie sicher, dass es funktioniert.
- Installieren Sie das LPosed-Modul **[SteamGuardExtractor](https://github.com/hax0r31337/SteamGuardExtractor?tab=readme-ov-file#usage)** und aktivieren Sie es in den LSPosed-Einstellungen.
- Erzwingen Sie das Beenden der Steam-App, und öffnen Sie diesen (den Extraktor). Ein **[Fenster mit extrahierten Details](https://github.com/JustArchiNET/ArchiSteamFarm/assets/1069029/ab5ab71e-d664-4e49-9eb4-9f4d9ba32aa2)** sollte erscheinen. Klicken Sie auf *Copy* (kopieren).

Nachdem Sie die benötigten Details erfolgreich extrahiert haben, deaktivieren Sie das Modul, um zu verhindern, dass das Fenster jedes Mal angezeigt wird; kopieren Sie dann den Wert von `shared_secret` und `identity_secret` des Kontos, das Sie zu ASF-2FA hinzufügen möchten, in eine neue Textdatei mit folgender Struktur:

```json
{
  "shared_secret": "STRING",
  "identity_secret": "STRING"
}
```

Ersetzen Sie jeden `STRING` Wert durch einen passenden privaten Schlüssel aus den extrahierten Details. Benennen Sie die Datei in `BotName.maFile` um, wobei `BotName` der Name Ihres Bots ist, zu dem Sie ASF-2FA hinzufügen und legen Sie es in ASF’s Verzeichnis `config` ab, wenn Sie es bislang nicht getan haben. Starten Sie anschließend ASF – es sollte die `.maFile` erkennen und importieren.

```text
[*] INFO: ImportAuthenticator() <1> Konvertiere .maFile in ASF-Format...
[*] INFO: ImportAuthenticator() <1> Import vom mobilen Authentifikator erfolgreich abgeschlossen!
```

Vorausgesetzt, Sie haben die richtige Datei mit gültigen Geheimnissen importiert, sollte alles, was Sie mit den `2fa`-Befehlen überprüfen können, einwandfrei funktionieren. Falls Sie einen Fehler gemacht haben, können Sie `Bot.db` jederzeit entfernen und bei Bedarf neu beginnen.

---

### SteamDesktopAuthenticator (SDA)

Wenn Sie Ihren Authentifikator bereits in SDA nutzen, dann sollten Sie die Datei `steamID.maFile` im Ordner `maFiles` beachten. Vergewissern Sie sich, dass `maFile` in unverschlüsselter Form vorliegt, da ASF diese SDA-Dateien nicht entschlüsseln kann – unverschlüsselte Dateiinhalte sollten mit dem Zeichen `{` beginnen und endet mit `}`. Falls notwendig, können Sie die Verschlüsselung zuerst aus den SDA-Einstellungen entfernen und im Anschluss erneut aktivieren, sobald Sie fertig sind. Sobald die Datei in unverschlüsselter Form vorliegt, kopieren Sie sie in das ASF-Verzeichnis `config`.

Sie sollten nun `steamID.maFile` in `BotName.maFile` im ASF-Konfigurationsverzeichnis umbenennen, wobei `BotName` der Name Ihres Bots darstellt, den Sie ASF-2FA hinzufügen. Alternativ können Sie es so lassen wie es ist; ASF wird es dann nach dem Einloggen automatisch auswählen. Die Umbenennung der Datei erlaubt ASF die Verwendung der ASF-2FA vor dem Einloggen. Falls Sie dies unterlassen, dann kann die Datei erst ausgewählt werden, sobald ASF sich erfolgreich einloggt hat (da ASF `steamID` Ihres Kontos nicht kennt, bevor Sie sich tatsächlich anmelden).

Wenn Sie alles richtig gemacht haben, starten Sie ASF und Sie sollten Folgendes bemerken:

```text
[*] INFO: ImportAuthenticator() <1> Konvertiere .maFile in ASF-Format...
[*] INFO: ImportAuthenticator() <1> Import vom mobilen Authentifikator erfolgreich abgeschlossen!
```

Fortan sollte Ihr ASF-2FA für dieses Konto einsatzbereit sein.

---

### WinAuth

Erstellen Sie zunächst eine neue, leere `BotName.maFile`-Datei im ASF-Konfigurationsverzeichnis, wobei `BotName` der Name Ihres Bot darstellt, dem Sie ASF-2FA hinzufügen. Beachten Sie, dass es `BotName.maFile`, und NICHT `BotName.maFile.txt` sein sollte, Windows versteckt gerne standardmäßig bekannte Erweiterungen. Falls Sie einen falschen Namen angeben, wird dieser nicht von ASF ausgewählt.

Nun starten Sie WinAuth wie gewohnt. Nach einem Rechtsklick auf das Steam-Symbol wählen Sie *»Show SteamGuard and Recovery Code«*. Dann setzen Sie einen Haken bei *»Allow copy«*. Ihnen sollte die JSON-Struktur am unteren Rand des Fensters vertraut vorkommen – beginnend mit `{`. Kopieren Sie den gesamten Text in die Datei `BotName.maFile`, die Sie im vorherigen Schritt erstellt haben.

Wenn Sie alles richtig gemacht haben, dann sollten Sie beim ASF-Start Folgendes sehen:

```text
[*] INFO: ImportAuthenticator() <1> Konvertiere .maFile in ASF-Format...
[*] INFO: ImportAuthenticator() <1> Import vom mobilen Authentifikator erfolgreich abgeschlossen!
```

Fortan sollte Ihr ASF-2FA für dieses Konto einsatzbereit sein.

---

## Fertig

Von diesem Moment an funktionieren alle `2fa` Befehle so, wie sie auf Ihrem herkömmlichen 2FA-Gerät ausgeführt werden. Sie können sowohl ASF-2FA, als auch den Authentifikator Ihrer Wahl (Android, SDA oder WinAuth) verwenden, um Codes zu generieren und Bestätigungen zu akzeptieren.

Wenn Sie einen Authenticator auf Ihrem Mobiltelefon haben, können Sie optional SteamDesktopAuthenticator und/oder WinAuth entfernen, da dieser nicht länger benötigt wird. Allerdings schlage ich vor, es für alle Fälle aufzubewahren, ganz zu schweigen davon, dass es praktischer ist als ein normaler Steam-Authentifikator. Bitte beachten Sie, dass ASF-2FA **KEINEN** allgemeinen Zweck-Authentifikationsmechanismus besitzt. Es enthält nicht alle Daten, die der Authentifikator haben sollte, sondern einen kleinen Teil der ursprünglichen `maFile`. Es ist nicht möglich ASF-2FA wieder in den Original-Authentifikator umzuwandeln, deshalb ist es wichtig, dass Sie den Universal-Authentifikator oder `maFile` an anderer Stelle (z. B. in WinAuth/SDA oder auf dem Handy sichern).

---

## FAQ (häufig gestellte Fragen)

### Wie nutzt ASF das 2FA-Modul?

Wenn ASF-2FA verfügbar ist, wird ASF es für die automatische Bestätigung von Handelsangeboten verwenden, die von ASF gesendet oder akzeptiert werden. Es wird auch in der Lage sein, automatisch 2FA-Codes zu generieren, z. B. um sich anzumelden. Überdies ermöglicht ASF-2FA auch die Verwendung von `2fa`-Befehlen. Das sollte vorerst alles sein, falls ich nichts vergessen habe – prinzipiell verwendet ASF das 2FA-Modul bei Bedarf.

---

### Was ist, wenn ich einen 2FA-Code benötige?

Sie benötigen einen 2FA-Code, um auf das 2FA-geschützte Konto zuzugreifen, das auch jedes Konto mit ASF-2FA einbezieht. Sie sollten Codes im Authentifikator generieren, den Sie für den Import benutzt haben, aber Sie können auch temporäre Codes über den Befehl `2fa` erzeugen, der via Chat an den angegebenen Bot gesendet wird. Sie können auch den Befehl `2fa <BotNames>` verwenden, um temporäre Codes für bestimmte Bot-Instanzen zu erzeugen. Das sollte ausreichen, damit Sie z. B. über den Browser auf Bot-Konten zugreifen können, aber wie oben erwähnt, sollten Sie stattdessen Ihren benutzerfreundlichen Authentifikator (Android, SDA oder WinAuth) verwenden.

---

### Kann ich nach dem Import zu ASF-2FA meinen Original-Authentifikator verwenden?

Ja, Ihr Original-Authentifikator bleibt funktionsfähig und Sie können ihn zusammen mit ASF-2FA verwenden. Das ist der entscheidende Vorteil des Verfahrens – wir importieren Ihre Authentifikationsinformationen in ASF, damit ASF sie nutzt und ausgewählte Bestätigungen in Ihrem Namen akzeptieren kann.

---

### Wo wird der ASF Mobile Authenticator gespeichert?

ASF Mobile Authenticator wird in der Datei `BotName.db` in Ihrem Konfigurationsverzeichnis abgelegt, zusammen mit einigen anderen wichtigen Daten, die sich auf das angegebene Konto beziehen. Wenn Sie ASF-2FA entfernen möchten, lesen Sie das unten stehende.

---

### Wie entferne ich ASF-2FA?

Stoppen Sie einfach ASF und entfernen Sie die zugehörige Datei `BotName.db` des Bots mit der verlinkten ASF-2FA, die Sie entfernen möchten. Diese Option löscht die zugehörige importierte 2FA mit ASF, entfernt aber NICHT Ihren Authentifikator. Wenn Sie stattdessen Ihren Authentifikator entfernen möchten, sollten Sie ihn nicht (zuerst) nur von ASF entfernen, sondern auch in einem Authentifikator Ihrer Wahl (Android, SDA oder WinAuth); oder – wenn Ihnen dies aus einem Grund möglich ist, einen Widerrufscode verwenden, den Sie während der Verknüpfung dieses Authentifikators auf der Steam-Webseite erhalten haben. Es ist nicht möglich, Ihren Authentifikator über ASF zu entfernen, dafür sollte der bereits vorhandene Standard-Authentifikator verwendet werden.

---

### Ich habe den Authentifikator in SDA/WinAuth verlinkt und dann in ASF importiert. Kann ich ihn jetzt entfernen und auf meinem Handy erneut verknüpfen?

**Nein**. ASF **importiert** Ihre Authentifikatordaten um sie zu verwenden. Wenn Sie Ihren Authentifikator entfernen, dann bewirken Sie damit auch, dass ASF-2FA nicht mehr funktioniert, egal ob Sie ihn zuerst entfernen, wie in der obigen Frage angegeben oder nicht. Wenn Sie Ihren Authentifikator sowohl auf Ihrem Handy, als auch auf ASF (plus optional in SDA/WinAuth) verwenden möchten, dann müssen Sie Ihren Authentifikator von Ihrem Handy **importieren** und keinen neuen in SDA/WinAuth erstellen. Sie können nur **einen** verknüpften Authentifikator haben, deshalb **importiert** ASF den Authentifikator und seine Daten, um ihn als ASF-2FA zu verwenden – es ist **derselbe** Authentifikator der nur an zwei Stellen existiert. Wenn Sie sich dazu entscheiden, Ihre mobilen Authentifizierungsdaten zu entfernen – unabhängig davon, in welcher Weise – wird ASF-2FA die Funktionalität einstellen, da die zuvor kopierten mobilen Authentifizierungsdaten nicht mehr gültig sind. Um ASF-2FA zusammen mit dem Authentifikator auf Ihrem Handy verwenden zu können, müssen Sie es – wie oben erläutert – aus Android importieren.

---

### Ist die Anwendung von ASF-2FA besser als die Verwendung von WinAuth/SDA/Anderer Authentifikator, um alle Bestätigungen zu akzeptieren?

**Ja**, auf unterschiedlicher Weise. Die erste und wichtigste – die Verwendung von ASF-2FA erhöht **erheblich** Ihre Sicherheit, da das ASF-2FA-Modul sicherstellt, dass ASF nur automatisch seine eigenen Bestätigungen akzeptiert; sodass, wenngleich der Angreifer ein schädliches Handelsangebot sendet, ASF-2FA dieses Handelsangebot **nicht** akzeptiert, da er nicht von ASF generiert wurde. Zusätzlich zur Sicherheit birgt die Verwendung von ASF-2FA auch Performance-/Optimierungsvorteile, da ASF-2FA Bestätigungen unmittelbar nach der Generierung abruft und akzeptiert und nur dann; im Gegensatz zur ineffizienten Abfrage der Bestätigungen alle X Minuten, die z. B. von SDA oder WinAuth durchgeführt wird. Kurz gesagt, es gibt keinen Grund den Authentifikator eines Drittanbieters dem von ASF-2FA vorzuziehen, wenn Sie vorhaben von ASF generierte Bestätigungen zu automatisieren – genau dafür ist ASF-2FA gedacht und die Verwendung steht nicht im Konflikt mit der Bestätigung von allem anderen in einem Authentifikator Ihrer Wahl. Wir empfehlen nachdrücklich ASF-2FA für die gesamte ASF-Aktivität zu verwenden – dies ist viel sicherer als jede andere Lösung.

---

## Erweiterte Einstellungen

Wenn Sie ein fortgeschrittener Benutzer sind, können Sie die maFile-Datei auch manuell generieren. Dies kann in solchen Fällen verwendet werden, wenn Sie den Authentifikator aus anderen, als den oben erläuterten Quellen, importieren möchten. Es sollte eine **[gültige JSON-Struktur](https://jsonlint.com)** aufweisen:

```json
{
  "shared_secret": "STRING",
  "identity_secret": "STRING"
}
```

Standard-Authentifikatordaten beinhalten mehr Felder – sie werden von ASF beim Import völlig ignoriert, da sie nicht benötigt werden. Sie müssen diese nicht entfernen – ASF benötigt nur gültiges JSON mit den 2 oben erläuterten Pflichtfeldern und wird zusätzliche Felder (falls vorhanden) ignorieren. Natürlich müssen Sie im obigen Beispiel `STRING` Platzhalter durch gültige Werte für Ihr Konto ersetzen. Jede `STRING` sollte eine base64 kodierte Darstellung von Bytes sein, aus denen der entsprechende private Schlüssel besteht.
