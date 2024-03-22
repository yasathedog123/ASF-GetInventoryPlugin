# Installation

Falls Sie hier zum ersten Mal angekommen sind – herzlich willkommen! Wir freuen uns sehr, einen weiteren Reisenden zu sehen, der sich für unser Projekt interessiert, obwohl wir berücksichtigen müssen, dass mit großer Macht eine große Verantwortung einhergeht – ASF ist in der Lage, viele verschiedene Dinge rund um Steam zu erledigen; aber nur, solange man sich **genug kümmert, um zu lernen, wie man ihn benutzt**. Es gibt hier eine steile Lernkurve, und wir erwarten von Ihnen, dass Sie das Wiki in dieser Hinsicht lesen, das im Detail erklärt, wie alles funktioniert.

Wenn Sie immer noch hier sind, heißt das, dass Sie den Text oben überstanden haben, was toll ist. Außer Sie haben ihn übersprungen, was heißt, dass Ihnen bald **[schlechte Zeiten](https://www.youtube.com/watch?v=WJgt6m6njVw)** bevorstehen … Wie auch immer. ASF ist eine Konsolenanwendung, was bedeutet, dass das Programm standardmäßig selbst keine Benutzeroberfläche hat, wie Sie es eventuell gewohnt sind. ASF sollte hauptsächlich auf Servern ausgeführt werden, sodass es als Dienst (Daemon) und nicht als Desktop-App fungiert.

Das bedeutet jedoch nicht, dass Sie es nicht auf Ihrem PC verwenden können oder die Benutzung etwas komplizierter ist als sonst, nichts dergleichen. ASF ist ein eigenständiges Programm, das keine Installation benötigt und sofort einsatzbereit ist. Allerdings wird eine Konfiguration erfordert, bevor es nützlich ist. Die Konfiguration teilt ASF mit, was es nach dem Start tun soll. Wenn Sie ASF ohne Konfiguration starten, dann wird es nichts tun. Ganz einfach.

---

## Betriebssystemspezifisches Einrichtung

Folgendes werden wir in den nächsten paar Minuten durchführen:
- **[.NET Abhängigkeiten](#net-prerequisites)** installieren.
- Laden Sie **[neueste ASF-Version](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** in geeigneter OS-spezifischer Variante herunter.
- Das Archiv an einem neuen Ort entpacken.
- **[ASF konfigurieren](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-de-DE)**.
- ASF starten und der „Magie Ihren Lauf“ lassen.

Hört sich einfach an, richtig? Dann lassen Sie uns beginnen.

---

### .NET Abhängigkeiten

Der erste Schritt ist stellt sicher, dass Ihr Betriebssystem ASF überhaupt richtig ausführen kann. ASF ist in C# basierend auf der .NET Plattform programmiert und benötigt eventuell native Bibliotheken, die auf Ihrem System bislang nicht verfügbar sind. Abhängig davon, ob Sie Windows, Linux oder macOS verwenden, haben Sie unterschiedliche Anforderungen, wenngleich alle davon in der **[.NET Voraussetzungsdokumentaion](https://docs.microsoft.com/dotnet/core/install)** aufgelistet sind, der Sie folgen sollten. Dieses ist unser Referenzmaterial, das verwendet werden sollte, allerdings haben wir im Sinne der Einfachheit auch alle benötigten Pakete unten aufgelistet, damit Sie nicht das gesamte Dokument lesen müssen.

Es ist vollkommen normal, dass manche (oder sogar alle) Abhängigkeiten bereits in Ihrem System existieren, weil sie mit der Software Dritter, welche Sie verwenden, mitinstalliert wurden. Trotzdem sollten Sie sicherstellen, dass dies wirklich der Fall ist, indem Sie das entsprechende Installationsprogramm für Ihr Betriebssystem ausführen – ohne diese Abhängigkeiten wird ASF nicht einmal starten.

Denken Sie daran, dass Sie für betriebssystemspezifische ASF-Versionen nichts Weiteres machen müssen. Insbesondere betrifft dies die Installation des .NET SDK oder der Runtime, da die betriebssystemspezifische Versionen das alles bereits beinhalten. Sie benötigen lediglich die .NET Core Prerequisites (Abhängigkeiten), um die .NET Runtime, die bereits in ASF enthalten sind, auszuführen.

#### **[Windows](https://docs.microsoft.com/de-de/dotnet/core/install/windows)**:
- **[Microsoft Visual C++ Redistributable Update](https://docs.microsoft.com/cpp/windows/latest-supported-vc-redist?view=msvc-170#visual-studio-2015-2017-2019-and-2022)** (**[x64](https://aka.ms/vs/17/release/vc_redist.x64.exe)** für 64-Bit Windows, **[x86](https://aka.ms/vs/17/release/vc_redist.x86.exe)** für 32-Bit Windows)
- Es wird dringend empfohlen sicherzustellen, dass alle Windows-Updates bereits installiert sind. Sie benötigen mindestens **[KB2533623](https://support.microsoft.com/en-us/help/2533623/microsoft-security-advisory-insecure-library-loading-could-allow-remot)** und **[KB2999226](https://support.microsoft.com/en-us/help/2999226/update-for-universal-c-runtime-in-windows)**, aber evtl. benötigen Sie mehr Updates. Wenn Ihr Windows aktuell ist, sind diese bereits alle installiert. Versichern Sie sich, dass Sie diese Voraussetzungen erfüllen, bevor Sie das Visual C++ Paket installieren.

#### **[Linux](https://docs.microsoft.com/de-de/dotnet/core/install/linux)**:
Paketnamen hängen von der Linux-Distribution, die Sie verwenden, ab. Wir listen nur die Gebräuchlichsten auf. Sie können alle über den nativen Paketmanager für Ihr Betriebssystem (wie zum Beispiel `apt` unter Debian oder `yum` unter CentOS) installieren.

- `ca-certificates` (Standard SSL Zertifikate für HTTPS Verbindungen)
- `libc6` (`libc`)
- `libgcc-s1` (`libgcc1`, `libgcc`)
- `libicu` (`icu-libs`, neueste Version für ihre Distribution – z. B. `libicu72`)
- `libgssapi-krb5-2` (`libkrb5-3`, `krb5-libs`)
- `libssl1.1` (`libssl`, `openssl-libs`, neueste Version für Ihre Distribution, mindestens `1.1.X`)
- `libstdc++6` (`libstdc++`, Version `5.0` oder höher)
- `zlib1g` (`zlib`)

Zumindest ein Großteil davon sollte bereits nativ auf Ihrem System verfügbar sein. Die minimale Installation von Debian stable erforderte nur `libicu72`.

#### **[macOS](https://docs.microsoft.com/de-de/dotnet/core/install/macos)**:
- Keine Version von macOS, aber Sie sollten die neueste Version von macOS installiert haben; mindestens 10.15+

---

### Herunterladen

Da wir nun alle benötigten Abhängigkeiten installiert haben, ist der nächste Schritt das Herunterladen der **[neuesten ASF-Version](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)**. ASF ist in mehreren Varianten verfügbar, aber Sie sind nur am Paket interessiert, das Ihrem Betriebssystem und der Architektur Ihres PCs entspricht. Zum Beispiel, wenn Sie 64-Bit Windows verwenden, dann wollen Sie die `ASF-win-x64`-Variante. Für mehr Information über die verfügbaren Varianten, besuche bitte den Abschnitt **[ Kompatibilität](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility-de-DE)**. ASF kann auch unter Betriebssystemen ausgeführt werden, für die wir kein betriebssystemspezifisches Paket zur Verfügung stellen. Ein Beispiel hierfür ist **32-bit Windows**. Dafür gehen Sie bitte zur **[generischen Installation](#generic-setup)**.

![Assets](https://i.imgur.com/Ym2xPE5.png)

Beginnen Sie nach dem Download damit, die Zip-Datei in einen eigenen Ordner zu entpacken. Wenn Sie dafür ein spezielles Programm benötigen, wird **[7-Zip](https://www.7-Zip.org)** diesen Zweck erfüllen, aber alle Standardwerkzeuge wie `unzip` von Linux/macOS sollten ebenfalls problemlos funktionieren.

Stellen Sie bitte sicher, dass Sie ASF in **einen eigenen Ordner**, anstelle eines bereits anderweitig genutzten verwendet wird, entpacken. ASFs automatische Aktualisierungen werden alle alten Dateien in diesem Ordner löschen, was möglicherweise dazu führen könnte, dass Sie Dateien verlieren, die nichts mit ASF zu tun haben, aber im selben Ordner sind. Sollten Sie zusätzliche Skripte oder Dateien haben, die Sie mit ASF verwenden wollen, sollten Sie sie in den überlegenen Ordner ablegen.

Eine Beispiel-Struktur würde wie folgt aussehen:

```text
C:\ASF (wo Sie Ihre eigenen Dateien speichern)
  ├── ASF Verknüpfung.lnk (optional)
  ├── Config Verknüpfung.lnk (optional)
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

Wir sind nun bereit, den allerletzten Schritt, die Konfiguration, durchzuführen. Dies ist bei Weitem der komplizierteste Schritt, da es sich um eine Menge neuer Informationen handelt, die Sie bislang nicht kennen, also werden wir versuchen, hier einige leicht verständliche Beispiele und vereinfachte Erklärungen zu geben.

In erster Linie gibt es die Seite **[Installation](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-de-DE)**, die **alles** erklärt, was sich auf die Konfiguration bezieht, aber es ist eine riesige Menge an neuen Informationen, von denen wir im Moment nicht alle benötigen werden. Stattdessen zeigen wir Ihnen, wie Sie die Informationen bekommen, die Sie tatsächlich suchen.

Die Konfiguration von ASF kann auf mindestens drei Arten erfolgen – durch unseren Web-Konfigurationseditor, über das ASF-UI oder manuell. Dies wird ausführlich auf der Seite **[Installation](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-de-DE)** erläutert, also beziehen Sie sich darauf, wenn Sie detailliertere Informationen benötigen. Wir werden den Web-Konfigurationseditor als Ausgangspunkt verwenden.

Besuche unseren **[Web-Konfigurationsgenerator](https://justarchinet.github.io/ASF-WebConfigGenerator)** mit Ihrem Lieblingsbrowser (Sie müssen JavaScript aktivieren, falls Sie es manuell deaktiviert haben). Wir empfehlen Chrome oder Firefox, aber es sollte mit allen gängigen Browsern funktionieren.

Klicken Sie nach dem Öffnen der Seite auf „Bot“. Sie sollten nun eine ähnliche Seite wie die unten sehen:

![Bot tab](https://i.imgur.com/aF3k8Rg.png)

Wenn die Version von ASF, die Sie gerade heruntergeladen haben, älter ist als der Konfigurationsgenerator, der standardmäßig verwendet wird, dann wählen Sie einfach Ihre ASF-Version aus dem Dropdown-Menü. Dies kann passieren, da der Konfigurationsgenerator zum Erzeugen von Konfigurationen für neuere (Vorabversionen) ASF-Versionen verwendet werden kann, die bislang nicht als stabil markiert wurden. Sie haben die neueste stabile Version von ASF heruntergeladen, die auf Ihre zuverlässige Funktion überprüft wurde.

Beginnen Sie damit, den Namen Ihres Bot in das rot markierte Feld zu schreiben. Dies kann jeder beliebige Name sein, den Sie verwenden möchten, z. B. Ihr Spitzname, Kontoname, eine Nummer oder etwas anderes. Es gibt nur ein Wort, das Sie nicht verwenden können, nämlich `ASF`, da dieses Schlüsselwort für die globale Konfigurationsdatei reserviert ist. Außerdem kann Ihr Bot-Name nicht mit einem Punkt beginnen (ASF ignoriert diese Dateien absichtlich). Wir empfehlen Ihnen, auf Leerzeichen zu verzichten. Sie sollten bei Bedarf `_` als Trennzeichen verwenden.

Nachdem Sie sich für einen Namen entschieden haben, aktivieren Sie den `Enabled` Schalter. Hiermit wird festgelegt, ob Ihr Bot von ASF automatisch nach dem Start (des Programms) gestartet werden soll.

Jetzt können Sie sich für zwei Dinge entscheiden:
- Sie können Ihren Benutzernamen in das Feld `SteamLogin` und Ihr Passwort in das `SteamPassword`-Feld eintragen
- Oder Sie können sie leer lassen

Wenn Sie das erste tun, kann ASF Ihre Konto-Anmeldeinformationen während des Startvorgangs automatisch verwenden, sodass Sie sie nicht jedes Mal manuell eingeben müssen, wenn ASF sie benötigt. Sie können sie jedoch auch weglassen. In diesem Fall werden sie nicht gespeichert, sodass ASF nicht ohne Ihre Hilfe automatisch starten kann und Sie sie während der Ausführung eingeben müssen.

ASF benötigt Ihre Anmeldeinformationen, da es seine eigene Implementierung des Steam-Clients beinhaltet und die gleichen Details benötigt, die Sie selbst benutzten, um sich anzumelden. Ihre Anmeldeinformationen werden nirgends außer auf Ihrem PC im `config` ASF-Verzeichnis gespeichert. Unser Web-Konfigurationsgenerator ist client-basiert, was bedeutet, dass der Programmcode lokal in Ihrem Browser ausgeführt wird, um gültige ASF-Konfigurationen zu generieren, ohne dass Sie Details eingibst, die Ihren PC überhaupt erst verlassen, sodass Sie sich keine Sorgen über einen möglichen Verlust vertraulicher Daten machen müssen. Dennoch, wenn Sie aus einem Grund Ihre Zugangsdaten dort nicht eingeben möchten, verstehen wir das, und Sie können sie später manuell in generierte Dateien einfügen, oder sie ganz weglassen und sie nur in die ASF-Befehlszeile eingeben. Mehr zu Sicherheitsfragen finden Sie im Abschnitt **[Konfiguration](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-de-DE)**.

Sie können auch nur ein Feld leer lassen, z. B. `SteamPassword`. ASF kann dann Ihr Login automatisch verwenden, fragt aber trotzdem nach dem Passwort (ähnlich wie beim Steam Client). Wenn Sie die Steam-Familienansicht benutzten, um das Konto freizuschalten, müssen Sie es in das Feld `SteamParentalCode` eingeben.

Nach der Entscheidung und den optionalen Details wird Ihre Webseite nun ähnlich wie die untenstehende aussehen:

![Bot tab 2](https://i.imgur.com/yf54Ouc.png)

Sie können jetzt auf den „Download“-Button klicken und unser Web-Konfigurationsgenerator erzeugt eine neue `json`-Datei basierend auf Ihrem gewählten Namen. Speichern Sie diese Datei im Verzeichnis `config`, welches sich in dem Ordner befindet, in dem Sie unsere Zip-Datei aus dem vorherigen Schritt extrahiert haben.

Ihr `config`-Verzeichnis sieht nun wie folgt aus:

![Structure 2](https://i.imgur.com/crWdjcp.png)

Glückwunsch! Sie haben gerade die sehr einfache ASF-Bot-Konfiguration abgeschlossen. Wir werden dies in Kürze erweitern, denn jetzt ist dies alles, was Sie benötigen.

---

### Ausführen von ASF

Sie sind nun bereit, das Programm zum ersten Mal zu starten. Führen Sie einfach einen Doppelklick auf die `ArchiSteamFarm`-Binärdatei im ASF-Verzeichnis aus. Alternativ können Sie diese auch von der Konsole aus starten.

Nach diesem Schritt, vorausgesetzt, Sie haben alle erforderlichen Abhängigkeiten im ersten Schritt installiert, sollte ASF richtig starten, Ihren ersten Bot bemerken (wenn Sie nicht vergessen haben, die generierte Konfiguration in das Verzeichnis `config` zu legen) und versuchen, sich anzumelden:

![ASF](https://i.imgur.com/u5hrSFz.png)

Wenn Sie `SteamLogin` und `SteamPassword` für ASF angegeben, werden Sie nur nach Ihrem SteamGuard-Code gefragt (E-Mail, 2FA oder keine, abhängig von Ihren Steam-Einstellungen). Andernfalls werden Sie auch nach Ihrem Steam-Login und Passwort gefragt.

Jetzt wäre ein guter Zeitpunkt, um unseren Abschnitt **[Telekommunikation](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Remote-communication-de-DE)** zu überprüfen, wenn Sie sich Sorgen darüber machen, dass ASF programmiert ist, inklusive Aktionen, die es in Ihrem Namen erledigen wird, wie in unserer Steam-Gruppe.

Nachdem Sie das anfängliche Anmeldeportal passiert haben, (davon ausgegangen, dass Ihre Daten korrekt sind) werden Sie erfolgreich angemeldet und ASF beginnt mit den Standardeinstellungen, die Sie bisher nicht geändert haben, zu sammeln:

![ASF 2](https://i.imgur.com/Cb7DBl4.png)

Dies beweist, dass ASF nun erfolgreich seine Arbeit auf Ihrem Konto erledigt, sodass Sie nun das Programm minimieren und etwas anderes tun können. Nach einiger Zeit (je nach **[Performance](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance-de-DE)**) werden Sie sehen, wie Steam-Karten langsam gesammelt werden. Natürlich müssen Sie dafür zulässige Spiele zum Sammeln besitzen, die auf Ihrer **[Abzeichen-Seite](https://steamcommunity.com/my/badges)** Folgendes zeigen: „Sie können noch X weitere Kartenfunde vom Spielen dieses Spiels bekommen“. Wenn es keine Spiele zum Sammeln gibt, dann wird ASF feststellen, dass es nichts zu tun gibt, wie in unserem **[FAQ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ-de-DE#was-ist-asf)** beschrieben.

Dies schließt unseren sehr einfachen Einrichtungsleitfaden ab. Sie können nun entscheiden, ob Sie ASF weiter konfigurieren möchten, oder ob Sie es in den Standardeinstellungen seine Arbeit tun lassen möchten. Wir werden noch ein paar grundlegende Details besprechen und Ihnen dann das gesamte Wiki zur Verfügung stellen.

---

### Erweiterte Konfiguration

#### Auf mehreren Konten gleichzeitig sammeln

ASF ermöglicht das Sammeln von Karten auf mehreren Konten gleichzeitig. Dies ist seine Hauptfunktion. Sie können weitere Konten zu ASF hinzufügen, indem Sie mehr Bot-Konfigurationsdateien erzeugen, genau so, wie Sie Ihre erste vor wenigen Minuten generiert haben. Sie müssen nur zwei Dinge sicherstellen:

- Eindeutiger Bot-Name, wenn Sie bereits Ihren ersten Bot „Hauptkonto“ genannt haben, können Sie keinen weiteren so nennen.
- Gültige Anmeldedaten, z. B. `SteamLogin`, `SteamPassword` und `SteamParentalCode` (bei Verwendung der Steam Parental Einstellungen)

Mit anderen Worten – gehen Sie einfach erneut zur Konfiguration und machen genau das Gleiche, nur für Ihr zweites oder drittes Konto. Vergessen Sie nicht, für sämtliche Ihrer Bots eindeutige Namen zu verwenden.

---

#### Einstellungen ändern

Sie können bestehende Einstellungen auf die gleiche Weise ändern, indem Sie eine neue Konfigurationsdatei erzeugen. Wenn Sie unseren Web-Konfigurationsgenerator bislang nicht geschlossen haben, klicken Sie auf „Zu den erweiterten Einstellungen umschalten“ und entdecken Sie Ihre Möglichkeiten. Für diese Anleitung werden wir die Einstellung `CustomGamePlayedWhileFarming` ändern, mit der Sie einstellen können, dass der benutzerdefinierte Name angezeigt wird, während ASF sammelt, anstatt das aktuelle Spiel anzuzeigen.

Also lassen Sie uns das tun, wenn Sie ASF ausführen und das Sammeln beginnt, werden Sie standardmäßig sehen, dass Ihr Steam-Konto sich jetzt im Spiel befindet:

![Steam](https://i.imgur.com/1VCDrGC.png)

Lassen Sie uns das jetzt ändern. Aktivieren Sie die erweiterten Einstellungen im Webkonfigurationsgenerator und suchen Sie `CustomGamePlayedWhileFarming`. Sobald Sie das getan haben, fügen Sie dort Ihren eigenen benutzerdefinierten Text ein, den Sie anzeigen möchten, wie „Idling cards“:

![Bot tab 3](https://i.imgur.com/gHqdEqb.png)

Nun können Sie die neue Konfigurationsdatei auf genau die gleiche Weise herunterladen, dann **überschreiben** Sie Ihre alte Konfigurationsdatei mit der neuen. Sie können natürlich auch Ihre alte Konfigurationsdatei löschen und an dessen Stelle die neue einfügen.

Sobald Sie das getan haben und ASF erneut starten, werden Sie feststellen, dass ASF nun Ihren benutzerdefinierten Text an der vorherigen Stelle anzeigt:

![Steam 2](https://i.imgur.com/vZg0G8P.png)

Dies bestätigt, dass Sie Ihre Konfiguration erfolgreich bearbeitet haben. Auf genau die gleiche Weise können Sie globale ASF-Eigenschaften ändern, indem Sie vom Bot-Tab zum »ASF«-Tab wechseln, die generierte Konfigurationsdatei `ASF.json` herunterladen und sie in das `config`-Verzeichnis legen.

Das Bearbeiten Ihrer ASF-Konfigurationen kann durch die Verwendung unserer ASF-ui Frontend, die weiter unten erläutert wird, wesentlich vereinfacht werden.

---

#### Verwendung von ASF-UI

ASF ist eine Konsolenanwendung und beinhaltet keine grafische Benutzeroberfläche. Wir arbeiten jedoch aktiv an unserer IPC-Schnittstellen Frontend **[ASF-UI](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-de-DE#asf-ui)**, was eine hervorragende und benutzerfreundliche Möglichkeit sein kann, auf verschiedene ASF-Funktionen zuzugreifen.

Um ASF-ui verwenden zu können, muss `IPC` aktiviert sein, was die Standardoption darstellt. Beim Start von ASF, sollten Sie in der Lage sein zu bestätigen, dass die IPC-Schnittstelle ebenfalls automatisch gestartet wurde:

![IPC](https://i.imgur.com/ZmkO8pk.png)

Sie können auf die IPC-Schnittstelle von ASF unter **[diesen](http://localhost:1242)** Link zugreifen, solange ASF ausgeführt wird. Sie können ASF-ui für verschiedene Zwecke verwenden, z. B. das Bearbeiten der Konfigurationsdateien vor Ort oder das Senden von **[Befehlen](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-de-DE)**. Schon Sie einfach einen Blick darauf, um alle Funktionalitäten von ASF-UI kennenzulernen.

![ASF-UI](https://raw.githubusercontent.com/JustArchiNET/ASF-ui/main/.github/previews/bots.png)

---

### Zusammenfassung

Sie haben ASF bereits erfolgreich so eingerichtet, dass es Ihre Steam-Konten nutzt, und haben es ein wenig nach Ihren Wünschen angepasst. Wenn Sie unserer gesamten Anleitung gefolgt sind, dann ist es Ihnen auch gelungen, ASF über unsere ASF-ui-Schnittstelle zu optimieren und herauszufinden, dass ASF tatsächlich eine Art GUI besitzt. Jetzt ist ein guter Zeitpunkt, unseren gesamten Abschnitt **[Konfiguration](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-de-DE)** zu lesen, um zu erfahren, was jene die Einstellungen, die Sie auf der Registerkarte »Erweitert« sahen, tatsächlich bewirken können und was ASF bietet. Falls Sie über ein Problem stolpern oder eine allgemeine Frage haben, lesen Sie stattdessen das **[FAQ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ-de-DE)**, wo zumindest die meisten Ihrer möglichen Fragen erklärt werden. Wenn Sie alles über ASF erfahren möchten und wie es Ihr Leben vereinfachen kann, dann schauen Sie sich den Rest von **[unserem Wiki](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Home-de-DE)** an. Wenn Sie herausgefunden haben, dass unser Programm für Sie nützlich ist und Sie sich großzügig fühlen, können Sie auch in Erwägung ziehen, an unser Projekt zu spenden. Viel Spaß!

---

## Generisches Setup

Diese Installation richtet sich an fortgeschrittene Benutzer, die ASF so einrichten möchten, dass es in der Variante **[generic](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility-de-DE#generic)** ausgeführt wird. Während die Verwendung schwieriger ist als **[OS-spezifische Varianten](#betriebssystemspezifische-einrichtung)**, bieten diese hier auch zusätzliche Vorteile.

Sie wollen die `generic` Variante hauptsächlich in drei Situationen verwenden (kann aber natürlich trotzdem anderweitig verwendet werden):
- Wenn Sie ein Betriebssystem verwenden, für das wir kein betriebssystemspezifisches Paket erstellen (z. B. 32-Bit Windows)
- Wenn Sie bereits .NET Runtime/SDK haben, oder eines installieren und verwenden möchten
- Wenn Sie die ASF-Strukturgröße und den Speicherbedarf selbst minimieren möchten, indem Sie die Laufzeitanforderungen selbst handhaben
- Wenn Sie eine benutzerdefinierte **[Erweiterung](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins-de-DE)** verwenden möchten, das eine `generic` Installation von ASF (aufgrund fehlender nativer Abhängigkeiten) benötigt

Bedenken Sie jedoch, dass Sie in diesem Fall für die .NET Runtime verantwortlich sind. Das bedeutet, dass ASF nicht funktioniert, wenn Ihre .NET SDK (Runtime) nicht verfügbar, veraltet oder defekt ist. Ebendarum empfehlen wir diese Einrichtung nicht für Gelegenheitsanwender, da Sie nun sicherstellen müssen, dass Ihr .NET SDK (Runtime) den ASF-Anforderungen entspricht und ASF ausführen kann; anstatt dass **wir** sicherstellen, dass unsere mit ASF gebündelte .NET Runtime dies ermöglicht.

Für das `generic` Paket können Sie dem gesamten betriebssystemspezifischen Leitfaden oben folgen, mit zwei kleinen Abweichungen. Zusätzlich zur Installation der .NET Prerequisites möchten Sie auch das .NET SDK installieren, und anstatt eine betriebssystemspezifische `ArchiSteamFarm(.exe)` ausführbare Datei zu haben, nutzen Sie nun eine generische Binärdatei `ArchiSteamFarm.dll`. Alles andere ist identisch.

Mit zusätzlichen Schritten:
- **[.NET Abhängigkeiten](#net-prerequisites)** installieren.
- Installieren Sie **[.NET SDK](https://www.microsoft.com/net/download)** (oder mindestens ASP.NET Core Laufzeit) passend für Ihr Betriebssystem. Sie möchten höchstwahrscheinlich ein Installationsprogramm verwenden. Lesen Sie die **[Runtime-Anforderungen](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility-de-DE#runtime-requirements)**, wenn Sie sich nicht sicher sind, welche Version installiert werden muss.
- Laden Sie die **[neueste ASF-Version](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** (latest) der `generic` Variante herunter.
- Das Archiv an einen neuen Ort entpacken.
- **[ASF konfigurieren](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-de-DE)**.
- Starten Sie ASF entweder mit einem Hilfsskript oder führen Sie `dotnet /pfad/zu/ArchiSteamFarm.dll` aus Ihrer Lieblingsshell heraus manuell aus.

Hilfsskripte (z. B. `ArchiSteamFarm.cmd` für Windows und `ArchiSteamFarm.sh` Linux/macOS) befinden sich neben der `ArchiSteamFarm.dll` Binärdatei – diese sind lediglich in der `generic` Variante enthalten. Sie können diese verwenden, wenn Sie den Befehl `dotnet` nicht manuell ausführen möchten. Offensichtlich funktionieren Hilfsskripte nicht, wenn Sie .NET SDK nicht installieren und sich keine `dotnet` ausführbare Datei in Ihrem `PATH` befindet. Hilfsskripte sind gänzlich optional verwendbar, Sie können jederzeit `dotnet /pfad/zu/ArchiSteamFarm.dll` manuell eingeben.