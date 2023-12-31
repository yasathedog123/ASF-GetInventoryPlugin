# Zwei-Faktor-Authentifizierung (2FA)

Steam includes two-factor authentication system known as "Escrow" that requires extra details for various account-related activity. Sie können **[hier](https://help.steampowered.com/faqs/view/2E6E-A02C-5581-8904)** und **[hier](https://help.steampowered.com/faqs/view/34A1-EA3F-83ED-54AB)** mehr darüber lesen. This page considers that 2FA system as well as our solution that integrates with it, called ASF 2FA.

---

# ASF-Logik

Regardless if you use ASF 2FA or not, ASF includes proper logic and is fully aware of accounts protected by standard 2FA. Es fragt Sie nach den erforderlichen Details, sobald diese benötigt werden (z. B. beim Anmelden). However, those requests can be automated by using ASF 2FA, which will automatically generate required tokens, saving you hassle and enabling extra functionality (described below).

---

# ASF-2FA

ASF 2FA is a built-in module responsible for providing 2FA features to the ASF process, such as generating tokens and accepting confirmations. It works by duplicating your existing authenticator details, so that you can use your current authenticator and ASF 2FA at the same time.

Sie können überprüfen, ob dein Bot-Konto bereits ASF-2FA verwendet, indem Sie den `2fa` **[Befehl](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-de-DE)** ausführen. Unless you've already imported your authenticator as ASF 2FA, all standard `2fa` commands will be non-operative, which means that your account is not using ASF 2FA, therefore it's also unavailable for advanced ASF features that require the module to be operative.

---

# Empfehlungen

There are a lot of ways to make ASF 2FA operative, here we include our recommendations based on your current situation:

- If you're already using SteamDesktopAuthenticator, WinAuth or any other third-party app that allows you to extract 2FA details with ease, just **[import](#import)** those to ASF.
- If you're using official app and you don't mind resetting your 2FA credentials, the best way is to disable 2FA, then **[create](#creation)** new 2FA credentials by using **[joint authenticator](#joint-authenticator)**, which will allow you to use official app and ASF 2FA. This method doesn't require root or advanced knowledge, barely following instructions.
- If you're using official app and don't want to recreate your 2FA credentials, your options are very limited, typically you'll need root and extra fiddling around to **[import](#import)** those details, and even with that it might be impossible.
- If you're not using 2FA yet and don't care, you can use ASF 2FA with **[standalone authenticator](#standalone-authenticator)**, third-party app **[duplicating](#import)** to ASF (recommendation #1), or **[joint authenticator](#joint-authenticator)** with official app (recommendation #2).

Below we discuss all possible options and known to us methods.

---

## Erstellung

In general, we strongly recommend **[duplicating](#import)** your existing authenticator, since that's the main purpose ASF 2FA was designed for. However, ASF comes with an official `MobileAuthenticator` **[plugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)** that further extends ASF 2FA, allowing you to link a completely new authenticator as well. This can be useful in case you're unable or unwilling to use other tools and do not mind ASF 2FA becoming your main (and maybe only) authenticator.

There are two possible scenarios for adding a two-factor authenticator with the `MobileAuthenticator` **[plugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)**: standalone or joint with the official Steam mobile app. In the second scenario, you will end up with the same authenticator on both the ASF and mobile app; both will generate the same codes, and both will be able to confirm trade offers, Steam Community Market transactions, etc.

### Common steps for both scenarios

No matter if you plan to use ASF as the standalone authenticator or want the same authenticator on the official Steam mobile app, you need to do those initialization steps:

1. Create an ASF bot for the target account, start it, and log in, which you probably already did.
2. Optional weisen Sie dem Konto **[hier](https://store.steampowered.com/phone/manage)** eine funktionierende und operative Telefonnummer zu, die vom Bot verwendet werden soll. Dies erlaubt Ihnen den Empfang von SMS-Code, sowie bei Bedarf die Wiederherstellung, aber es ist erforderlich.
3. Ensure you're not using 2FA yet for your account, if you do, disable it first.
4. Execute the `2fainit [Bot]` command, replacing `[Bot]` with your bot's name.

Assuming you got a successful reply, the following two things have happened:

- A new `<Bot>.maFile.PENDING` file was generated by ASF in your `config` directory.
- SMS wurde von Steam an die Telefonnummer gesendet, die Sie für das oben genannte Konto zugewiesen haben. Wenn Sie keine Telefonnummer angegeben haben, wurde stattdessen eine E-Mail an die E-Mail-Adresse des Kontos gesendet.

The authenticator details are not operational yet, however, you can review the generated file if you'd like to. If you want to be double safe, you can, for example, already write down the revocation code. The next steps will depend on your selected scenario.

### Eigenständiger Authentifikator

If you want to use ASF as your main (or even only) authenticator, now you need to do the finalization step:

5. Führt den Befehl `2fafinalize [Bot] <ActivationCode>` aus; ersetzt `[Bot]` mit dem Namen Ihres Bots und `<ActivationCode>` mit dem Code, den Sie im vorherigen Schritt per SMS oder E-Mail erhalten haben.

### Gemeinsamer Authentifikator

If you want to have the same authenticator in both ASF and the official Steam mobile app, now you need to do the next steps:

5. Ignoriere die SMS oder den E-Mail-Code, den Sie nach dem vorherigen Schritt erhalten haben.
6. Install the Steam mobile app if it's not installed yet, and open it. Navigate to the Steam Guard tab and add a new authenticator by following the app's instructions.
7. After your authenticator in the mobile app is added and working, return to ASF. You now need to tell ASF that finalization is done with the help of one of the two commands below:
 - Wait until the next 2fa code is shown in the Steam mobile app, and use the command `2fafinalized [Bot] <2fa_code_from_app>` replacing `[Bot]` with your bot's name and `<2fa_code_from_app>` with the code you currently see in the Steam mobile app. If the code generated by ASF and the code you provided are the same, ASF assumes that an authenticator was added correctly and proceeds with importing your newly created authenticator.
 - We strongly recommend to do the above in order to ensure that your credentials are valid. However, if you don't want to (or can't) check if codes are the same and you know what you're doing, you can instead use the command `2fafinalizedforce [Bot]`, replacing `[Bot]` with your bot's name. ASF will assume that the authenticator was added correctly and proceed with importing your newly created authenticator.

### After finalization

Assuming everything worked properly, the previously generated `<Bot>.maFile.PENDING` file was renamed to `<Bot>.maFile.NEW`. This indicates that your 2FA credentials are now valid and active. We recommend that you create a copy of that file and keep it in **a secure and safe location**. In addition to that, we recommend you open the file in your editor of choice and write down the `revocation_code`, which will allow you to, as the name implies, revoke the authenticator in case you lose it.

In regard to technical details, the generated `maFile` includes all details that we have received from the Steam server during linking the authenticator, and in addition to that, the `device_id` field, which may be needed for other authenticators. The file is fully compatible with **[SDA](#steamdesktopauthenticator)** for import.

ASF automatically imports your authenticator once the procedure is done, and therefore `2fa` and other related commands should now be operational for the bot account you linked the authenticator to.

---

## Importieren

Import process requires already linked and operational authenticator that is supported by ASF. ASF currently supports a few different official and unofficial sources of 2FA - Android, iOS, SteamDesktopAuthenticator and WinAuth, on top of manual method which allows you to provide required credentials yourself. If you don't have any authenticator yet, you need to choose one of available apps and set it up firstly. Wenn Du nicht genau weißt welchen Du auswählen sollst, empfehlen wir WinAuth, aber alle der oben genannten Möglichkeiten funktionieren gut, wenn Du die Anweisungen befolgst.

Alle folgenden Anleitungen erfordern von dir, dass Du bereits einen **funktionierenden und betriebsbereiten** Authentifikator hast, der mit dem gegebenen Programm/Anwendung verwendet wird. ASF-2FA funktioniert nicht ordnungsgemäß, wenn Du ungültige Daten importierst. Stelle daher sicher, dass dein Authentifikator ordnungsgemäß funktioniert bevor Du versuchst ihn zu importieren. Dies beinhaltet das Testen und Überprüfen, ob die folgenden Authentifikator-Funktionen ordnungsgemäß funktionieren:
- Du kannst Codes generieren und diese Codes werden vom Steam-Netzwerk akzeptiert
- Du kannst Bestätigungen abrufen und sie kommen auf deinem mobilen Authentifikator an
- Du kannst diese Bestätigungen akzeptieren und sie werden vom Steam-Netzwerk ordnungsgemäß als bestätigt/abgelehnt erkannt

Vergewissere dich, dass dein Authentifikator funktioniert, indem Du überprüfst, ob die obigen Aktionen funktionieren - wenn nicht, dann werden sie auch nicht in ASF funktionieren und Du verschwendest nur Zeit und erzeugst Ihren selbst zusätzliche Probleme.

---

### Android-Handy

**The below instructions apply to Steam app in version `2.X`, there are currently limited **[resources](https://github.com/JustArchiNET/ArchiSteamFarm/discussions/2786)** on extracting required details from version `3.0` onwards. We'll update this section once generally-available method is found. As of today, a workaround would be to intentionally install older version of Steam app, register 2FA and extract the required details first, after which it's possible to update the application to latest version - existing authenticator will continue to work.**

Im Allgemeinen benötigst Du für den Import des Authentifikators von Ihrem Android-Handy **[root](https://de.wikipedia.org/wiki/Rooting_(Android_OS))**-Zugriff. Das Rooting variiert von Gerät zu Gerät, daher werde ich dir nicht sagen wie Du dein Gerät rooten kannst. Auf der Webseite **[XDA](https://www.xda-developers.com/root)** findest Du exzellente Anleitungen, wie Du das machen kannst, sowie allgemeine Informationen zum Rooten im Allgemeinen. Wenn Du dein Gerät oder die Anleitung dazu nicht finden kannst, versuche es bei Google zu finden.

Zumindest ist es offiziell nicht möglich, auf geschützte Steam-Dateien ohne Root zuzugreifen. Die einzige offizielle nicht-root Methode zum Extrahieren von Steam-Dateien ist das Erstellen von unverschlüsselten `/data` Backups, auf die eine oder andere Weise und das manuelle Abrufen entsprechender Dateien auf dem PC. Aber da so etwas stark von Ihrem Handyhersteller abhängt und **nicht** in Android-Standard ist, werden wir es hier nicht weiter erörtern. Wenn Du das Glück hast eine solche Funktionalität zu haben, kannst Du sie nutzen, aber die Mehrheit der Benutzer hat so etwas nicht.

Unofficially, it is possible to extract the needed files without root access, by installing or downgrading your Steam app to version `2.1` (or earlier), setting up mobile authenticator and then creating a snapshot of the app (together with the `data` files that we need) through `adb backup`. Da es sich jedoch um eine schwerwiegende Sicherheitsverletzung und eine gänzlich nicht unterstützte Methode zum Extrahieren der Dateien handelt, werden wir nicht weiter darauf eingehen. Valve hat diese Sicherheitslücke in neueren Versionen aus einem bestimmten Grund deaktiviert und wir erwähnen sie nur als Möglichkeit. Still, it might be possible to do a clean install of that version, link new authenticator, extract the required files, and then upgrade the app, which should be just enough, but you're on your own with this method anyway.

Angenommen, Du hast dein Handy erfolgreich gerootet, solltest Du danach einen beliebigen auf dem Markt erhältlichen Root-Explorer herunterladen, wie z. B. **[dieser ](https://play.google.com/store/apps/details?id=com.jrummy.root.browserfree)** (oder einen anderen Ihrer Wahl). Sie können auch über ADB (Android Debug Bridge) oder jede andere Ihren zur Verfügung stehende Methode auf die geschützten Dateien zugreifen, wir machen es über den Explorer, da es definitiv der benutzerfreundlichste Weg ist.

Nachdem Du Ihren Root-Explorer geöffnet hast, navigiere zum Ordner `/data/data`. Beachte, dass das Verzeichnis `/data/data` geschützt ist und Du ohne Root-Zugriff nicht darauf zugreifen kannst. Dort angekommen, findest Du den Ordner `com.valvesoftware.android.steam.community` und kopierst ihn auf Ihre `/sdcard`, die auf Ihren internen Speicher verweist. Danach solltest Du dein Handy an Ihren PC anschließen und den Ordner wie gewohnt von Ihrem internen Speicher kopieren können. Wenn der Ordner zufällig nicht sichtbar ist, obwohl Du Ihren sicher bist, dass Du ihn an die richtige Stelle kopiert hast, versuche zuerst dein Handy neu zu starten.

Nun kannst Du wählen, ob Du Ihren Authentifikator zuerst in WinAuth und dann in ASF oder sofort in ASF importieren möchtest. Die erste Option ist benutzerfreundlicher und ermöglicht es dir deinen Authentifikator auch auf deinem PC zu duplizieren, sodass Du Bestätigungen vornehmen und Codes an 3 verschiedenen Stellen generieren kannst - deinem Handy, deinem PC und ASF. Wenn Du das tun möchtest, öffne einfach WinAuth, füge einen neuen Steam-Authentifikator hinzu und wähle die Option "Import aus Android". Anschließend folge den Anweisungen, indem Du auf die Dateien zugreifst, die Du oben erhalten hast. Danach kannst Du diesen Authentifikator von WinAuth nach ASF importieren, was im speziellen WinAuth-Abschnitt weiter unten erläutert wird.

If you don't want to or don't need to go through WinAuth, then simply copy `files/Steamguard-<SteamID>` file from our protected directory, where `SteamID` is your 64-bit Steam identificator of the account that you want to add (if more than one, because if you have only one account then this will be the only file). Du musst diese Datei in das ASF-Verzeichnis `config` kopieren. Sobald Du das getan hast, benenne die Datei um in `BotName.maFile`, wobei `BotName` der Name Ihres Bot ist, dem Du ASF-2FA hinzufügst. Nach diesem Schritt starte ASF - es sollte die `.maFile` erkennen und importieren.

```text
[*] INFO: ImportAuthenticator() <1> Konvertiere .maFile in ASF-Format...
[*] INFO: ImportAuthenticator() <1> Import vom mobilen Authentifikator erfolgreich abgeschlossen!
```

Vorrausgesezt Sie haben die richtige Datei mit gültigen Geheimnissen importiert, sollte alles, was Sie mit den `2fa`-Befehlen überprüfen können, einwandfrei funktionieren. Falls Du einen Fehler gemacht hast, kannst Du `Bot.db` jederzeit entfernen und bei Bedarf neu beginnen.

---

### iOS

Für iOS kannst Du **[ios-steamguard-extractor](https://github.com/CaitSith2/ios-steamguard-extractor)** verwenden. Dies ist möglich, da Du entschlüsselte Backups erstellen, auf deinem PC installieren und das Programm verwenden kannst, um Steam-Daten zu extrahieren, die sonst unmöglich zu bekommen sind (zumindest ohne Jailbreak, aufgrund der iOS-Verschlüsselung).

Gehe zu der **[neuesten Version](https://github.com/CaitSith2/ios-steamguard-extractor/releases/latest)** um das Programm herunterzuladen. Sobald Du die Daten extrahiert hast kannst Du sie z. B. in WinAuth, dann von WinAuth nach ASF kopieren (obwohl Du auch einfach generiertes json kopieren kannst, beginnend mit `{` endend mit `}` in `BotName.maFile` und wie üblich vorgehen). Wenn Du mich fragst, empfehle ich dir dringend zuerst nach WinAuth zu importieren und dann sicherzustellen, dass sowohl das Erzeugen von Codes, als auch das Akzeptieren von Bestätigungen richtig funktioniert, damit Du sicher sein kannst, dass alles in Ordnung ist. Wenn deine Anmeldeinformationen ungültig sind wird ASF-2FA nicht ordnungsgemäß funktionieren, daher ist es viel besser den ASF-Importschritt als letzten Schritt durchzuführen.

Für Fragen/Probleme besuche bitte **[issues](https://github.com/CaitSith2/ios-steamguard-extractor/issues)**.

*Beachte, dass das obige Programm inoffiziell ist - Du benutzt es auf eigene Gefahr. Wir bieten keine technische Unterstützung wenn es nicht ordnungsgemäß funktioniert - wir haben ein paar Hinweise erhalten, dass es sich um den Export ungültiger 2FA-Anmeldeinformationen handelt - überprüfe, ob Bestätigungen in einem Authentifikator wie WinAuth funktionieren, bevor Du diese Daten in ASF importierst!*

---

### SteamDesktopAuthenticator

Wenn Du deinen Authentifikator bereits in SDA laufen hast, solltest Du beachten, dass es eine `steamID.maFile` Datei im Ordner `maFiles` gibt. Make sure that `maFile` is in unencrypted form, as ASF can't decrypt SDA files - unencrypted file content should start with `{` and end with `}` character. If needed, you can remove the encryption from SDA settings first, and enable it again when you're done. Once the file is in unencrypted form, copy it to `config` directory of ASF.

You can now rename `steamID.maFile` to `BotName.maFile` in ASF config directory, where `BotName` is the name of your bot you're adding ASF 2FA to. Alternativ kannst Du es so lassen wie es ist, ASF wird es dann nach dem Einloggen automatisch auswählen. Renaming the file helps ASF by making it possible to use ASF 2FA before logging in, if you don't do that, then the file can be picked only after ASF successfully logs in (as ASF doesn't know `steamID` of your account before in fact logging in).

Wenn Du alles richtig gemacht hast, starte ASF und Du solltest es merken:

```text
[*] INFO: ImportAuthenticator() <1> Konvertiere .maFile in ASF-Format...
[*] INFO: ImportAuthenticator() <1> Import vom mobilen Authentifikator erfolgreich abgeschlossen!
```

Von nun an sollte dein ASF-2FA für dieses Konto einsatzbereit sein.

---

### WinAuth

Erstelle zunächst eine neue leere `BotName.maFile` Datei im ASF-Konfigurationsverzeichnis, wobei `BotName` der Name deines Bot ist, dem Du ASF-2FA hinzufügst. Bedenke, dass es `BotName.maFile` und NICHT `BotName.maFile.txt` sein sollte, Windows mag es bekannte Erweiterungen standardmäßig zu verstecken. Wenn Du einen falschen Namen angibst wird er nicht von ASF ausgewählt.

Nun starte WinAuth wie gewohnt. Nach einem Rechtsklick auf das Steam-Symbol wähle "Show SteamGuard and Recovery Code". Dann setze einen Haken bei "Allow copy". Du solltest bemerken, dass dir die JSON-Struktur am unteren Rand des Fensters vertraut ist, beginnend mit `{`. Kopiere den gesamten Text in die `BotName.maFile` Datei, die Du im vorherigen Schritt erstellt hast.

Wenn Du alles richtig gemacht hast, starte ASF und Du solltest es merken:

```text
[*] INFO: ImportAuthenticator() <1> Konvertiere .maFile in ASF-Format...
[*] INFO: ImportAuthenticator() <1> Import vom mobilen Authentifikator erfolgreich abgeschlossen!
```

Von nun an sollte dein ASF-2FA für dieses Konto einsatzbereit sein.

---

## Fertig

Von diesem Moment an funktionieren alle `2fa` Befehle so, wie sie auf Ihrem herkömmlichen 2FA-Gerät ausgeführt werden. Du kannst sowohl ASF-2FA, als auch den Authentifikator deiner Wahl (Android, iOS, SDA oder WinAuth) verwenden, um Codes zu generieren und Bestätigungen zu akzeptieren.

Wenn Du einen Authentifikator auf deinem Handy hast, kannst Du optional SteamDesktopAuthenticator und/oder WinAuth entfernen, da wir ihn nicht mehr benötigen. Allerdings schlage ich vor es für alle Fälle aufzubewahren, ganz zu schweigen davon, dass es praktischer ist als ein normaler Steam-Authentifikator. Just keep in mind that ASF 2FA is **NOT** a general purpose authenticator, it doesn't include all data that authenticator should have, but limited subset of original `maFile`. It's not possible to convert ASF 2FA back to original authenticator, therefore always make sure that you have general-purpose authenticator or `maFile` in other place, such as in WinAuth/SDA, or on your phone.

---

## FAQ (oft gestellte Fragen)

### Wie nutzt ASF das 2FA-Modul?

Wenn ASF-2FA verfügbar ist wird ASF es für die automatische Bestätigung von Handelsangeboten verwenden, die von ASF gesendet bzw. akzeptiert werden. Es wird auch in der Lage sein bei Bedarf automatisch 2FA-Codes zu generieren, z. B. um sich anzumelden. Darüber hinaus ermöglicht ASF-2FA auch die Verwendung von `2fa`-Befehlen. Das sollte vorerst alles sein, falls ich nichts vergessen habe - im Grunde genommen verwendet ASF das 2FA-Modul bei Bedarf.

---

### Was ist wenn ich einen 2FA-Code benötige?

Du benötigst einen 2FA-Code, um auf das 2FA-geschützte Konto zuzugreifen, das auch jedes Konto mit ASF-2FA einbezieht. Du solltest Codes im Authentifikator generieren, den Du für den Import benutzt hast, aber Du kannst auch temporäre Codes über den Befehl `2fa` erzeugen, der über den Chat an den angegebenen Bot gesendet wird. Du kannst auch den Befehl `2fa <BotNames>` verwenden, um temporäre Codes für bestimmte Bot-Instanzen zu erzeugen. Das sollte ausreichen, damit Du z. B. über den Browser auf Bot-Konten zugreifen kannst, aber wie oben erwähnt, solltest Du stattdessen deinen benutzerfreundlichen Authentifikator (Android, iOS, SDA oder WinAuth) verwenden.

---

### Kann ich nach dem Import zu ASF-2FA meinen Original-Authentifikator verwenden?

Ja, dein Original-Authentifikator bleibt funktionsfähig und Du kannst ihn zusammen mit ASF-2FA verwenden. Das ist der springende Punkt des Verfahrens - wir importieren deine Authentifikationsinformationen in ASF damit ASF sie nutzen und ausgewählte Bestätigungen in deinem Namen akzeptieren kann.

---

### Wo wird der ASF Mobile Authenticator gespeichert?

ASF Mobile Authenticator wird in der Datei `BotName.db` in deinem Konfigurationsverzeichnis gespeichert, zusammen mit einigen anderen wichtigen Daten, die sich auf das angegebene Konto beziehen. Wenn Du ASF-2FA entfernen möchtest, lies das untenstehende.

---

### Wie entferne ich ASF-2FA?

Stoppe einfach ASF und entferne die zugehörige `BotName.db` Datei des Bots mit der verlinkten ASF-2FA, die Du entfernen möchtest. Diese Option entfernt die zugehörige importierte 2FA mit ASF, entfernt aber NICHT deinen Authentifikator. Wenn Du stattdessen deinen Authentifikator entfernen möchtest, solltest Du ihn nicht nur von ASF entfernen (zuerst), sondern auch in einem Authentifikator deiner Wahl (Android, iOS, SDA oder WinAuth) entfernen, oder - wenn Du aus irgendeinem Grund nicht kannst, einen Widerrufscode verwenden, den Du während der Verknüpfung dieses Authentifikators auf der Steam-Webseite erhalten hast. Es ist nicht möglich, Ihren Authentifikator über ASF zu entfernen, dafür sollte der bereits vorhandene Standard-Authentifikator verwendet werden.

---

### Ich habe den Authentifikator in SDA/WinAuth verlinkt und dann in ASF importiert. Kann ich ihn jetzt entfernen und auf meinem Handy wieder verlinken?

**Nein**. ASF **importiert** deine Authentifikatordaten um sie zu verwenden. Wenn Du deinen Authentifikator entfernst, dann wirst Du damit auch bewirken, dass ASF-2FA nicht mehr funktioniert, egal ob Du ihn zuerst entfernst, wie in der obigen Frage angegeben ist oder nicht. Wenn Du deinen Authentifikator sowohl auf deinem Handy, als auch auf ASF (plus optional in SDA/WinAuth) verwenden möchtest, dann musst Du deinen Authentifikator von deinem Handy **importieren** und keinen neuen in SDA/WinAuth erstellen. Du kannst nur **einen** verknüpften Authentifikator haben, deshalb **importiert** ASF den Authentifikator und seine Daten, um ihn als ASF-2FA zu verwenden - es ist **derselbe** Authentifikator der nur an zwei Stellen existiert. Wenn Du dich dazu entscheidest deine mobilen Authentifizierungsdaten zu entfernen - unabhängig davon, in welcher Weise, wird ASF-2FA die Funktionalität einstellen, da die zuvor kopierten mobilen Authentifizierungsdaten nicht mehr gültig sind. Um ASF-2FA zusammen mit dem Authentifikator auf deinem Handy verwenden zu können musst Du es aus Android/iOS importieren, was oben erläutert ist.

---

### Ist die Verwendung von ASF-2FA besser als die Verwendung von WinAuth/SDA/Anderer Authentifikator um alle Bestätigungen zu akzeptieren?

**Ja**, auf unterschiedlicher Weise. Die erste und wichtigste - die Verwendung von ASF-2FA erhöht **erheblich** deine Sicherheit, da das ASF-2FA-Modul sicherstellt, dass ASF nur automatisch seine eigenen Bestätigungen akzeptiert, sodass selbst wenn der Angreifer ein schädliches Handelsangebot sendet, ASF-2FA dieses Handelsangebot **nicht** akzeptiert, da er nicht von ASF generiert wurde. Zusätzlich zum Sicherheitsteil bringt die Verwendung von ASF-2FA auch Performance-/Optimierungsvorteile, da ASF-2FA Bestätigungen unmittelbar nach der Generierung abruft und akzeptiert und nur dann, im Gegensatz zur ineffizienten Abfrage der Bestätigungen alle X Minuten, die z. B. von SDA oder WinAuth durchgeführt wird. Kurz gesagt, es gibt keinen Grund den Authentifikator eines Drittanbieters dem von ASF-2FA vorzuziehen, wenn Du vorhast von ASF generierte Bestätigungen zu automatisieren - genau dafür ist ASF-2FA gedacht und die Verwendung steht nicht im Konflikt mit der Bestätigung von allem anderen in einem Authentifikator deiner Wahl. Wir empfehlen nachdrücklich ASF-2FA für die gesamte ASF-Aktivität zu verwenden - dies ist viel sicherer als jede andere Lösung.

---

## Erweiterte Einstellungen

Wenn Du ein fortgeschrittener Benutzer bist, kannst Du die maFile-Datei auch manuell generieren. Dies kann in dem Fall verwendet werden, wenn Du den Authentifikator aus anderen, als den oben erläuterten Quellen, importieren möchtest. Es sollte eine **[gültige JSON-Struktur](https://jsonlint.com)** aufweisen:

```json
{
 "shared_secret": "STRING",
 "identity_secret": "STRING"
}
```

Standard-Authentifikatordaten haben mehr Felder - sie werden von ASF beim Import völlig ignoriert, da sie nicht benötigt werden. Du musst sie nicht entfernen - ASF benötigt nur gültiges JSON mit den 2 oben erläuterten Pflichtfeldern und wird zusätzliche Felder (falls vorhanden) ignorieren. Natürlich musst Du im obigen Beispiel `STRING` Platzhalter durch gültige Werte für dein Konto ersetzen. Each `STRING` should be base64-encoded representation of bytes the appropriate private key is made of.
