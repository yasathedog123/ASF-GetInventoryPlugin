# Installation

Wenn Du hier zum ersten Mal angekommen bist, herzlich willkommen! Wir freuen uns sehr, einen weiteren Reisenden zu sehen, der sich für unser Projekt interessiert, obwohl wir berücksichtigen müssen, dass mit großer Macht eine große Verantwortung einhergeht - ASF ist in der Lage, viele verschiedene Dinge rund um Steam zu tun, aber nur, solange man sich **genug kümmert, um zu lernen, wie man ihn benutzt**. Es gibt hier eine steile Lernkurve, und wir erwarten von dir, dass Du das Wiki in dieser Hinsicht liest, das im Detail erklärt, wie alles funktioniert.

Wenn Du immer noch hier bist, heißt das, dass Du den Text oben überstanden hast, was toll ist. Außer Du hast ihn übersprungen, was heißt, dass Du bald **[schlechte Zeiten](https://www.youtube.com/watch?v=WJgt6m6njVw)** vor Ihren hast... Wie auch immer. ASF ist eine Konsolenanwendung, was bedeutet, dass das Programm standardmäßig selber keine Benutzeroberfläche hat, wie Du es eventuell gewohnt bist. ASF sollte hauptsächlich auf Servern laufen, sodass es als Dienst (Daemon) und nicht als Desktop-App fungiert.

Das bedeutet jedoch nicht, dass Du es nicht auf Ihrem PC benutzen kannst oder dass die Benutzung etwas komplizierter ist als sonst, nichts dergleichen. ASF ist ein eigenständiges Programm, das keine Installation benötigt und sofort einsatzbereit ist. Allerdings wird eine Konfiguration erfordert, bevor es nützlich wird. Die Konfiguration sagt ASF, was es nach dem Start tatsächlich tun soll. Wenn Du ASF ohne Konfiguration startest, dann wird es nichts tun. Ganz einfach.

---

## Betriebssystemspezifisches Setup

Folgendes werden wir in den nächsten paar Minuten machen:
- **[.NET Abhängigkeiten](#net-prerequisites)** installieren.
- Die **[neueste ASF-Version](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** in der entsprechenden betriebssystemspezifischen Variante herunterladen.
- Das Archiv an einen neuen Ort entpacken.
- **[ASF konfigurieren](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-de-DE)**.
- ASF starten und der Magie Ihren Lauf lassen.

Hört sich einfach an, richtig? Dann lassen Sie uns beginnen.

---

### .NET Abhängigkeiten

Der erste Schritt ist sicherzustellen, dass dein Betriebssystem ASF überhaupt richtig ausführen kann. ASF ist in C# basierend auf der .NET Plattform programmiert und benötigt eventuell native Bibliotheken, die auf deinem System noch nicht verfügbar sind. Abhängig davon, ob Sie Windows, Linux oder macOS verwenden, haben Sie unterschiedliche Anforderungen, wenngleich alle in **[aufgelistet sind. ET Voraussetzungen](https://docs.microsoft.com/dotnet/core/install)** Dokument, dem Sie folgen sollten. Dieses ist Referenzmaterial, das verwendet werden sollte, allerdings haben wir im Sinne der Einfachheit auch alle benötigten Pakete unten aufgelistet, damit Du nicht das gesamte Dokument lesen musst.

Es ist völlig normal, dass manche (oder sogar alle) Abhängigkeiten bereits in Ihrem System existieren, weil sie mit der Software Dritter, welche Du verwendest, mitinstalliert wurden. Trotzdem solltest Du sicherstellen, dass dies wirklich der Fall ist indem Du das entsprechende Installationsprogramm für dein Betriebssytem ausführst - Ohne diese Abhängigkeiten wird ASF nicht einmal starten.

Keep in mind that you don't need to do anything else for OS-specific builds, especially installing .NET SDK or even runtime, since OS-specific package includes all of that already. You need only .NET prerequisites (dependencies) to run .NET runtime included in ASF.

#### **[Windows](https://docs.microsoft.com/de-de/dotnet/core/install/windows)**:
- **[Microsoft Visual C++ Redistributable Update](https://docs.microsoft.com/cpp/windows/latest-supported-vc-redist?view=msvc-170#visual-studio-2015-2017-2019-and-2022)** (**[x64](https://aka.ms/vs/17/release/vc_redist.x64.exe)** für 64-Bit Windows, **[x86](https://aka.ms/vs/17/release/vc_redist.x86.exe)** für 32-Bit Windows)
- Es wird dringend empfohlen sicherzustellen, dass alle Windows-Updates bereits installiert sind. Du brauchst mindestens **[KB2533623](https://support.microsoft.com/en-us/help/2533623/microsoft-security-advisory-insecure-library-loading-could-allow-remot)** und **[KB2999226](https://support.microsoft.com/en-us/help/2999226/update-for-universal-c-runtime-in-windows)**, aber evtl. benötigst du mehr Updates. Wenn dein Windows aktuell ist, sind diese bereits alle installiert. Versichere dich, dass Du diese Voraussetzungen erfüllst, bevor Du das Visual C++ Paket installierst.

#### **[Linux](https://docs.microsoft.com/de-de/dotnet/core/install/linux)**:
Paketnamen hängen von der Linux-Distribution, die Du verwendest, ab. Wir listen nur die Gebräuchlichsten auf. Sie können alle über den nativen Paketmanager für dein Betriebssystem (wie zum Beispiel `apt` unter Debian oder `yum` unter CentOS) installieren.

- `ca-certificates` (Standard SSL Zertifikate für HTTPS Verbindungen)
- `libc6` (`libc`)
- `libgcc-s1` (`libgcc1`, `libgcc`)
- `libicu` (`icu-libs`, latest version for your distribution, for example `libicu72`)
- `libgssapi-krb5-2` (`libkrb5-3`, `krb5-libs`)
- `libssl1.1` (`libssl`, `openssl-libs`, latest version for your distribution, at least `1.1.X`)
- `libstdc++6` (`libstdc++`, Version `5.0` oder höher)
- `zlib1g` (`zlib`)

Zumindest ein Großteil davon sollte bereits nativ auf Ihrem System verfügbar sein. The minimal installation of Debian stable required only `libicu72`.

#### **[macOS](https://docs.microsoft.com/de-de/dotnet/core/install/macos)**:
- Keine Version von macOS, aber Sie sollten die neueste Version von macOS installiert haben; mindestens 10.15+

---

### Herunterladen

Da wir nun alle benötigten Abhängigkeiten installiert haben, ist der nächste Schritt das Herunterladen der **[neuesten ASF-Version](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)**. ASF ist in mehreren Varianten verfügbar, aber Du bist nur am Paket interessiert, das Ihrem Betriebssystem und der Architektur Ihres PCs entspricht. Zum Beispiel, wenn Du `64`-Bit `Win`dows verwendest, dann willst Du die `ASF-win-x64`-Variante. Für mehr Information über die verfügbaren Varianten, besuche bitte den Abschnitt **[ Kompatibilität](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility-de-DE)**. ASF kann auch unter Betriebssystemen ausgeführt werden, für die wir kein betriebssystemspezifisches Paket zur Verfügung stellen. Ein Beispiel hierfür ist **32-bit Windows**. Dafür gehe bitte zur **[generischen Installation](#generic-setup)**.

![Assets](https://i.imgur.com/Ym2xPE5.png)

Beginne nach dem Download damit, die Zip-Datei in einen eigenen Ordner zu entpacken. Wenn Sie dafür ein spezielles Programm benötigen, wird **[7-zip](https://www.7-zip.org)** dies tun aber alle Standardwerkzeuge wie `entpacken` von Linux/macOS sollten ebenfalls problemlos funktionieren.

Stelle bitte sicher, dass Du ASF in **einen eigenen Ordner** entpackst und nicht in einen bereits existenten, der für etwas anderes verwendet wird - ASFs automatische Aktualisierungen werden alle alten Dateien in diesem Ordner löschen, was möglicherweise dazu führen könnte, dass Du Dateien verlierst, die nichts mit ASF zu tun haben aber im selben Ordner sind. Solltest Du zusätzliche Skripte oder Dateien haben, die Du mit ASF verwenden willst, solltest Du sie in den Ordner darüber tun.

Eine Beispiel-Struktur würde wie folgt aussehen:

```text
C:\ASF (wo Sie Ihre eigenen Dateien speichern)
  ├── ASF shortcut.lnk (optional)
  ├── Config shortcut.lnk (optional)
  ├── Commands.txt (optional)
  ├── MyExtraScript.bat (optional)
  ├── (...) (alle anderen Dateien Ihrer Wahl, optional)
  └── Core (nur ASF gewidmet, wo Sie das Archiv extrahieren)
     ├── ArchiSteamFarm(.exe)
     ├── config
     ├── logs
     ├── plugins
     └── (...)
```

---

### Konfiguration

Wir sind nun bereit, den allerletzten Schritt, die Konfiguration, durchzuführen. Dies ist bei weitem der komplizierteste Schritt, da es sich um eine Menge neuer Informationen handelt, die Du noch nicht kennst, also werden wir versuchen, hier einige leicht verständliche Beispiele und vereinfachte Erklärungen zu geben.

In erster Linie gibt es die Seite **[Installation](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-de-DE)**, die **alles** erklärt, was sich auf die Konfiguration bezieht, aber es ist eine riesige Menge an neuen Informationen, von denen wir im Moment nicht alle benötigen werden. Stattdessen zeigen wir dir, wie Du die Informationen bekommst, die Du tatsächlich suchst.

Die Konfiguration von ASF kann auf mindestens drei Arten erfolgen - durch unseren Web-Konfigurationseditor, über das ASF-UI oder manuell. Dies wird ausführlich auf der Seite **[Installation](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-de-DE)** erläutert, also beziehe dich darauf, wenn Du detailliertere Informationen benötigst. Wir werden den Web-Konfigurationseditor als Ausgangspunkt verwenden.

Besuche unsere **[Web-Konfigurationsgenerator](https://justarchinet.github.io/ASF-WebConfigGenerator)** Seite mit deinem Lieblingsbrowser (Du musst JavaScript aktiviert haben, falls Du es manuell deaktiviert hast). Wir empfehlen Chrome oder Firefox, aber es sollte mit allen gängigen Browsern funktionieren.

Nach dem Öffnen der Seite klicke auf "Bot". Du solltest nun eine ähnliche Seite wie die unten sehen:

![Bot tab](https://i.imgur.com/aF3k8Rg.png)

Wenn die Version von ASF, die Du gerade heruntergeladen hast, älter ist als der Konfigurationsgenerator, der standardmäßig verwendet wird, wähle einfach deine ASF-Version aus dem Dropdown-Menü. Dies kann passieren, da der Konfigurationsgenerator zum Erzeugen von Konfigurationen für neuere (Vorabversionen) ASF-Versionen verwendet werden kann, die noch nicht als stabil markiert wurden. Du hast die neueste stabile Version von ASF heruntergeladen, die auf Ihre zuverlässige Funktion überprüft wurde.

Beginne damit, den Namen deines Bot in das rot markierte Feld zu schreiben. Dies kann jeder beliebige Name sein, den Du verwenden möchtest, wie z. B. dein Spitzname, Kontoname, eine Nummer oder etwas anderes. Es gibt nur ein Wort, das Du nicht verwenden kannst, nämlich `ASF`, da dieses Schlüsselwort für die globale Konfigurationsdatei reserviert ist. Außerdem kann dein Bot-Name nicht mit einem Punkt beginnen (ASF ignoriert diese Dateien absichtlich). Wir empfehlen dir auch keine Leerzeichen zu verwenden. Du solltest bei Bedarf `_` als Trennzeichen verwenden.

Nachdem Du dich für einen Namen entschieden hast, aktiviere den `Enabled` Schalter. Hiermit wird festgelegt, ob dein Bot von ASF automatisch nach dem Start (des Programms) gestartet werden soll.

Jetzt kannst Du dich für zwei Dinge entscheiden:
- Sie können Ihren Benutzernamen in das Feld `SteamLogin` und Ihr Passwort in das `SteamPassword` Feld eintragen
- Oder Du kannst sie leer lassen

Wenn Du das erste tust, kann ASF deine Konto-Anmeldeinformationen während des Startvorgangs automatisch verwenden, sodass Du sie nicht jedes Mal manuell eingeben musst, wenn ASF sie benötigt. Du kannst sie jedoch auch weglassen. In diesem Fall werden sie nicht gespeichert, sodass ASF nicht ohne deine Hilfe automatisch starten kann und Du sie während der Laufzeit eingeben musst.

ASF benötigt deine Anmeldeinformationen, da es seine eigene Implementierung des Steam-Clients beinhaltet und die gleichen Details benötigt, die Du selbst benutzt um dich anzumelden. Deine Anmeldeinformationen werden nirgends außer auf deinem PC im `config` ASF-Verzeichnis gespeichert. Unser Web-Konfigurationsgenerator ist client-basiert, was bedeutet, dass der Programmcode lokal in deinem Browser ausgeführt wird, um gültige ASF-Konfigurationen zu generieren, ohne dass Du Details eingibst, die deinen PC überhaupt erst verlassen, sodass Du dir keine Sorgen über einen möglichen Verlust vertraulicher Daten machen musst. Dennoch, wenn Du aus irgendeinem Grund deine Zugangsdaten dort nicht eingeben möchtest, verstehen wir das, und Du kannst sie später manuell in generierte Dateien einfügen, oder sie ganz weglassen und sie nur in die ASF-Befehlszeile eingeben. Mehr zu Sicherheitsfragen findest Du im Abschnitt **[Konfiguration](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-de-DE)**.

Du kannst auch nur ein Feld leer lassen, wie z. B. `SteamPassword`. ASF kann dann dein Login automatisch verwenden, fragt aber trotzdem nach dem Passwort (ähnlich wie beim Steam Client). Wenn Du die Steam-Familienansicht benutzt um das Konto freizuschalten musst Du es in das Feld `SteamParentalCode` eingeben.

Nach der Entscheidung und den optionalen Details wird deine Webseite nun ähnlich wie die untenstehende aussehen:

![Bot tab 2](https://i.imgur.com/yf54Ouc.png)

Du kannst jetzt auf den "Download"-Button klicken und unser Web-Konfigurationsgenerator erzeugt eine neue `json` Datei basierend auf deinem gewählten Namen. Speichern Sie diese Datei im `config` Verzeichnis, welches sich in dem Ordner befindet, in dem Sie unsere Zip-Datei aus dem vorherigen Schritt extrahiert haben.

Dein `config` Verzeichnis sieht nun wie folgt aus:

![Structure 2](https://i.imgur.com/crWdjcp.png)

Glückwunsch! Du hast gerade die sehr einfache ASF-Bot-Konfiguration abgeschlossen. Wir werden dies in Kürze erweitern, denn jetzt ist dies alles, was Du brauchst.

---

### Ausführen von ASF

Du bist nun bereit, das Programm zum ersten Mal zu starten. Führe einfach einen Doppelklick auf die `ArchiSteamFarm` Binärdatei im ASF-Verzeichnis aus. Alternativ kannst Du diese auch von der Konsole aus starten.

Nach diesem Schritt, vorausgesetzt, Du hast alle erforderlichen Abhängigkeiten im ersten Schritt installiert, sollte ASF richtig starten, deinen ersten Bot bemerken (wenn Du nicht vergessen hast, die generierte Konfiguration in das Verzeichnis `config` zu legen) und versuchen, dich anzumelden:

![ASF](https://i.imgur.com/u5hrSFz.png)

Wenn Du `SteamLogin` und `SteamPassword` für ASF angegeben hast, wirst Du nur nach deinem SteamGuard-Code gefragt (E-Mail, 2FA oder keine, abhängig von deinen Steam-Einstellungen). Wenn Du es nicht getan hast, wirst Du auch nach deinem Steam-Login und Passwort gefragt.

Now would be a good time to review our **[remote communication](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Remote-communication)** section if you're concerned about stuff ASF is programmed to do, including actions it'll take in your name, such as joining our Steam group.

After passing through initial login gate, assuming your details are correct, you'll successfully log in, and ASF will start farming using default settings that you didn't change as of now:

![ASF 2](https://i.imgur.com/Cb7DBl4.png)

Dies beweist, dass ASF nun erfolgreich seine Arbeit auf deinem Konto erledigt, sodass Du nun das Programm minimieren und etwas anderes tun kannst. Nach einiger Zeit (je nach **[Performance](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance-de-DE)**) wirst Du sehen, wie Steam-Karten langsam gesammelt werden. Of course, for that to happen you must have valid games to farm, showing as "you can get X more card drops from playing this game" on your **[badges page](https://steamcommunity.com/my/badges)** - if there are no games to farm, then ASF will state that there is nothing to do, as stated in our **[FAQ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#what-is-asf)**.

Dies schließt unseren sehr einfachen Einrichtungsleitfaden ab. Du kannst nun entscheiden, ob Du ASF weiter konfigurieren möchtest oder ob Du es in den Standardeinstellungen seine Arbeit tun lassen möchtest. Wir werden noch ein paar grundlegende Details besprechen und dir dann das gesamte Wiki zur Verfügung stellen.

---

### Erweiterte Konfiguration

#### Auf mehreren Konten gleichzeitig sammeln

ASF supports farming more than one account at a time, which is its primary function. Du kannst weitere Konten zu ASF hinzufügen, indem Du mehr Bot-Konfigurationsdateien erzeugst, genau so, wie Du deine erste vor wenigen Minuten generiert hast. Du musst nur zwei Dinge sicherstellen:

- Eindeutiger Bot-Name, wenn Du bereits Ihren ersten Bot "HauptKonto" genannt hast, kannst Du keinen weiteren so nennen.
- Gültige Anmeldedaten, wie z. B. `SteamLogin`, `SteamPassword` und `SteamParentalCode` (bei Verwendung der Steam Parental Einstellungen)

Mit anderen Worten, gehe einfach erneut zur Konfiguration und mache genau das Gleiche, nur für dein zweites oder drittes Konto. Vergiss nicht für alle deine Bots eindeutige Namen zu verwenden.

---

#### Einstellungen ändern

Du kannst bestehende Einstellungen auf die gleiche Weise ändern, indem Du eine neue Konfigurationsdatei erzeugst. Wenn Du unseren Web-Konfigurationsgenerator noch nicht geschlossen hast, klicke auf "Zu den erweiterten Einstellungen umschalten" und sieh dir an, was Du entdecken kannst. For this tutorial we'll change `CustomGamePlayedWhileFarming` setting, which allows you to set custom name being displayed when ASF is farming, instead of showing actual game.

So let's do that, if you run ASF and start farming, in default settings you'll see that your Steam account is in-game now:

![Steam](https://i.imgur.com/1VCDrGC.png)

Lass uns das jetzt ändern. Aktiviere die erweiterten Einstellungen im Webkonfigurationsgenerator und suche `CustomGamePlayedWhileFarming`. Sobald Du das getan hast, füge dort deinen eigenen benutzerdefinierten Text ein, den Du anzeigen möchtest, wie zum Beispiel "Idling cards":

![Bot tab 3](https://i.imgur.com/gHqdEqb.png)

Nun kannst Du die neue Konfigurationsdatei auf genau die gleiche Weise herunterladen, dann **überschreibe** deine alte Konfigurationsdatei mit der neuen. Du kannst natürlich auch deine alte Konfigurationsdatei löschen und an Ihre Stelle die neue einfügen.

Sobald Du das getan hast und ASF erneut startest, wirst Du feststellen, dass ASF nun deinen benutzerdefinierten Text an der vorherigen Stelle anzeigt:

![Steam 2](https://i.imgur.com/vZg0G8P.png)

This confirms that you've successfully edited your config. In exactly the same way you can change global ASF properties, by switching from bot tab to "ASF" tab, downloading generated `ASF.json` config file and putting it in your `config` directory.

Editing your ASF configs can be done much easier by using our ASF-ui frontend, which will be explained further below.

---

#### Verwendung von ASF-UI

ASF ist eine Konsolenanwendung und beinhaltet keine grafische Benutzeroberfläche. Wir arbeiten jedoch aktiv an unserem IPC-Schnittstellen Frontend **[ASF-UI](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-de-DE#asf-ui)**, was eine sehr gute und benutzerfreundliche Möglichkeit sein kann, auf verschiedene ASF-Funktionen zuzugreifen.

In order to use ASF-ui, you need to have `IPC` enabled, which is the default option. Once you launch ASF, you should be able to confirm that it properly started the IPC interface automatically:

![IPC](https://i.imgur.com/ZmkO8pk.png)

You can access ASF's IPC interface under **[this](http://localhost:1242)** link, as long as ASF is running, from the same machine. You can use ASF-ui for various purposes, e.g. editing the config files in-place or sending **[commands](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Wirf einfach einen Blick darauf, um alle Funktionalitäten von ASF-UI kennenzulernen.

![ASF-UI](https://raw.githubusercontent.com/JustArchiNET/ASF-ui/main/.github/previews/bots.png)

---

### Zusammenfassung

Du hast ASF bereits erfolgreich so eingestellt, dass es deine Steam-Konten nutzt, und Du hast es bereits ein wenig nach deinen Wünschen angepasst. If you followed our entire guide, then you also managed to tweak ASF through our ASF-ui interface and found out that ASF actually has a GUI of some sort. Now is a good time to read our entire **[configuration](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** section in order to learn what all those different settings you've seen actually do, and what ASF has to offer. If you've stumbled upon some issue or you have some generic question, read our **[FAQ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ)** instead which should cover all, or at least a vast majority of questions that you may have. Wenn Du alles über ASF erfahren möchtest und wie es dein Leben einfacher machen kann, dann schaue dir den Rest von **[unserem Wiki](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Home-de-DE)** an. If you found out our program to be useful for you and you're feeling generous, you can also consider donating to our project. In any case, have fun!

---

## Generisches Setup

Dieses Setup richtet sich an fortgeschrittene Benutzer, die ASF so einrichten möchten, dass es in der Variante **[generic](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility-de-DE#generic)** ausgeführt wird. While being more troublesome in usage than **[OS-specific variants](#os-specific-setup)**, they also come with additional benefits.

You want to use `generic` variant mainly in those situations (but of course you can use it regardless):
- Wenn Du ein Betriebssystem verwendest, für das wir kein betriebssystemspezifisches Paket erstellen (z. B. 32-Bit Windows)
- When you already have .NET Runtime/SDK, or want to install and use one
- When you want to minimize ASF structure size and memory footprint by handling runtime requirements yourself
- When you want to use a custom **[plugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)** which requires a `generic` setup of ASF to run properly (due to missing native dependencies)

However, keep in mind that you're in charge of .NET runtime in this case. This means that if your .NET SDK (runtime) is unavailable, outdated or broken, ASF won't work. This is why we don't recommend this setup for casual users, since you now need to ensure that your .NET SDK (runtime) matches ASF requirements and can run ASF, as opposed to **us** ensuring that our .NET runtime bundled with ASF can do so.

For `generic` package, you can follow entire OS-specific guide above, with two small changes. In addition to installing .NET prerequisites, you also want to install .NET SDK, and instead of having OS-specific `ArchiSteamFarm(.exe)` executable file, you now have a generic `ArchiSteamFarm.dll` binary only. Alles andere ist identisch.

Mit zusätzlichen Schritten:
- **[.NET Abhängigkeiten](#net-prerequisites)** installieren.
- Install **[.NET SDK](https://www.microsoft.com/net/download)** (or at least ASP.NET Core runtime) appropriate for your OS. Du möchtest höchstwahrscheinlich ein Installationsprogramm verwenden. Lesen Sie die **[Runtime-Anforderungen](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility-de-DE#runtime-requirements)**, wenn Sie sich nicht sicher sind, welche Version installiert werden muss.
- Download **[latest ASF release](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** in `generic` variant.
- Das Archiv an einen neuen Ort entpacken.
- **[ASF konfigurieren](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-de-DE)**.
- Starte ASF entweder mit einem Hilfsskript oder führe `dotnet /pfad/zu/ArchiSteamFarm.dll` aus Ihrer Lieblingsshell heraus manuell aus.

Hilfs-Skripte (z. B. `ArchiSteamFarm.cmd` für Windows und `ArchiSteamFarm.sh` Linux/macOS befinden sich neben der `ArchiSteamFarm.dll` Binärdatei - diese sind lediglich in der `generic` Variante enthalten. Sie können diese verwenden, wenn Sie den Befehl `dotnet` nicht manuell ausführen möchten. Obviously helper scripts won't work if you didn't install .NET SDK and you don't have `dotnet` executable available in your `PATH`. Hilfs-Skripte sind völlig optional verwendbar, Sie können jederzeit `dotnet /pfad/zu/ArchiSteamFarm.dll` manuell eingeben.