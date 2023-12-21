# Kompilierung

Kompilierung ist der Prozess zur Erstellung von ausführbaren Dateien. Dies ist ratsam, wenn Sie Ihre eigenen Änderungen zu ASF hinzufügen möchten, oder wenn Sie aus irgendeinem Grund den ausführbaren Dateien der offiziell bereitgestellten **[Versionen](https://github.com/JustArchiNET/ArchiSteamFarm/releases)** nicht vertrauen. Wenn Sie ein einfacher Benutzer und kein Entwickler sind, möchten Sie höchstwahrscheinlich bereits vorkompilierte Binärdateien verwenden. Wenn Sie aber eigenen Dateien verwenden oder etwas Neues lernen möchten, lesen Sie bitte hier weiter.

ASF kann auf allen momentan unterstützten Plattformen kompiliert werden, solange Sie Zugriff auf die benötigten Programme haben.

---

## .NET SDK

Unabhängig von der Plattform benötigen Sie die vollständige .NET SDK (nicht nur Runtime), um ASF zu kompilieren. Eine Installationsanleitung finden Sie auf der **[.NET Installationsseite](https://dotnet.microsoft.com/download)**. Es muss die passende .NET SDK-Version für Ihr Betriebssystem installiert sein. Nach erfolgreicher Installation sollte der Befehl `dotnet` funktionieren und betriebsbereit sein. Sie können mit `dotnet --info` überprüfen ob es funktioniert. Stellen Sie sicher, dass Ihr .NET SDK mit den ASF-**[Runtime-Anforderungen](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility-de-DE#runtime-anforderungen)** übereinstimmt.

---

## Kompilierung

Sofern Ihr .NET Core SDK funktionsfähig und in der entsprechenden Version vorliegt, navigieren Sie einfach zum Quell-ASF-Verzeichnis (geklont oder heruntergeladen und entpacktes ASF-Repository) und führen Sie Folgendes aus:

```shell
dotnet publish ArchiSteamFarm -c "Release" -o "out/generic"
```

Für Linux/macOS als Zielplattform können Sie stattdessen das Skript `cc.sh` verwenden, womit dasselbe in komplexerer Weise ausgeführt wird.

Wenn die Kompilierung erfolgreich beendet wurde, finden Sie Ihr ASF in der `source` Version im `ArchiSteamFarm/out/generic` Verzeichnis. Dies gleicht sich mit dem offiziellen `generic` ASF-Build, nur ist hier der `UpdateChannel` und `UpdatePeriod` auf `0` gesetzt, womit ein überschreiben des Ihres eigenen Builds bis zur nächsten Kompilierung vermieden wird.

### Betriebssystemspezifisch

Sie können auch das betriebssystemspezifische .NET Paket erstellen, falls es einen bestimmten Grund dazu gibt. Im Allgemeinen sollten Sie das nicht tun, weil Sie gerade die `generic` Version kompiliert haben, welche Sie mit Ihrer bereits installierten .NET Runtime ausführen können. Aber nur für den Fall, dass Sie es dennoch möchten:

```shell
dotnet publish ArchiSteamFarm -c "Release" -o "out/linux-x64" -r "linux-x64"
```

Natürlich sollten Sie `linux-x64` durch eine Betriebssystemarchitektur ersetzen, die Sie anvisieren, wie etwa `win-x64`. Auch in diesem Build werden Aktualisierungen deaktiviert sein.

### ASF-UI

Während die oben genannten Schritte alles sind, was für ein vollständig funktionales ASF Build benötigt wird, könnten Sie eventuell *auch* für die Kompilierung der **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)**, unserer grafischen Web-Oberfläche, interessieren. Seitens ASF müssen Sie lediglich die ASF-ui Build-Ausgabe im Verzeichnis `ASF-ui/dist` fallen lassen, anschließend ASF mit ihm (falls nötig erneut) kompilieren.

ASF-ui ist Teil des ASF-Quellbaums des **[Git Submoduls](https://git-scm.com/book/en/v2/Git-Tools-Submodules)**; stellen Sie sicher, dass Sie das Repository mit `git clone --recursive`geklont haben, da Sie sonst nicht die erforderlichen Dateien haben. Sie benötigen außerdem einen funktionierendes NPM, **[Node.js](https://nodejs.org)** beinhaltet dies. Wenn Sie Linux/macOS verwenden, empfehlen wir unser `cc.sh` Skript, das automatisch die Erstellung und den Übermittlung von ASF-UI abdeckt (falls möglich, das heißt, wenn Sie die Anforderungen erfüllen, die wir gerade erwähnt haben).

Zusätzlich zur `cc.sh` Skript, fügen wir auch die vereinfachten Build-Anweisungen unten hinzu, und verweisen Sie auf das**[ASF-ui Repository](https://github.com/JustArchiNET/ASF-ui)** für zusätzliche Dokumentation. Führen Sie im ASF-Quellverzeichnis aus (siehe oben die folgenden Befehle aus:

```shell
rm -rf "ASF-ui/dist" # ASF-ui bereinigt sich nach dem alten Build nicht von selbst

npm ci --prefix ASF-ui
npm run-script deploy --prefix ASF-ui

rm -rf "out/generic/www" # stellt sicher das unser Build-Ausgabe frei von alten Dateien ist
dotnet publish ArchiSteamFarm -c "Release" -o "out/generic" # oder was Sie wie oben erklärt entsprechend benötigen
```

Sie sollten jetzt in der Lage sein, die ASF-ui Dateien in Ihrem `out/generic/www` Ordner zu finden. ASF wird in der Lage sein, diese Dateien Ihrem Browser zu senden.

Alternativ können Sie ASF-ui einfach erstellen (entweder manuell oder mit Hilfe unseres Repositories), dann kopieren Sie die Build-Ausgabe manuell in den `${OUT}/www` Ordner wobei `${OUT}` der Ausgabeordner von ASF ist, den Sie mit dem Parameter `-o` angegeben haben. Das ist genau das, was ASF als Teil des Kompilerungsprozesses macht. Es kopiert `ASF-ui/dist` (falls vorhanden) über `${OUT}/www`, nichts Besonderes.

---

## Entwicklung

Wenn Sie ASF-Quelltext bearbeiten möchten, können Sie zu diesem Zweck jede .NET kompatible IDE verwenden, obwohl selbst das optional ist. Sie können auch mit einem Notepad arbeiten und mit dem oben beschriebenen `dotnet` Befehl kompilieren. Dennoch empfehlen wir für Windows das **[aktuelle Visual Studio](https://visualstudio.microsoft.com/downloads)** (die kostenlose Community-Version reicht vollkommen).

Falls Sie stattdessen den ASF-Quelltext unter Linux/macOS arbeiten möchten, empfehlen wir die **[aktuellste Visual Studio Code Version](https://code.visualstudio.com/download)**. Diese Version ist nicht so umfangreich wie das klassische Visual Studio, aber reicht vollkommen aus.

Natürlich sind alle obigen Vorschläge nur Empfehlungen, Sie können verwenden, was immer Sie möchten. Am Ende wird sowieso immer der Befehl `dotnet build` ausgeführt. Wir verwenden **[JetBrains Rider](https://www.jetbrains.com/rider)** für die ASF-Entwicklung, obwohl es keine freie Lösung ist.

---

## Tags

Der Zweig `main` ist nicht unbedingt in einem Zustand, der eine erfolgreiche Kompilierung oder eine fehlerfreie ASF-Ausführung überhaupt erst ermöglicht, da es sich um einen Entwicklungszweig handelt, wie in unserem **[Veröffentlichungszyklus](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Release-cycle-de-DE)** erläutert. Für die Kompilierung oder Referenz von ASF aus dem Quelltext, sollten Sie ein angemessenes **[Tag](https://github.com/JustArchiNET/ArchiSteamFarm/tags)** verwenden, welches zumindest eine erfolgreiche Kompilierung, und höchstwahrscheinlich problemlose Ausführung (falls das Build als stable release markiert wurde), garantiert. Um die aktuelle "Gesundheit" des Verzeichnisbaumes zu überprüfen, können Sie unser **[GitHub](https://github.com/JustArchiNET/ArchiSteamFarm/actions/workflows/ci.yml?query=branch%3Amain)**-CI verwenden.

---

## Offizielle Veröffentlichungen

Offizielle ASF-Versionen werden von **[GitHub](https://github.com/JustArchiNET/ArchiSteamFarm/actions)** mit der neuesten .NET Core SDK kompiliert, welche mit den ASF **[Runtime-Anforderungen](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility-de-DE#runtime-anforderungen)** übereinstimmt. Nach dem Bestehen von Tests werden alle Pakete auf GitHub als Release bereitgestellt. Dies garantiert auch Transparenz, da GitHub immer offizielle öffentliche Quellen für alle Builds verwendet und Sie können die Prüfsummen der GitHub Artefakte mit GitHub Release-Assets abgleichen. Die ASF-Entwickler kompilieren oder veröffentlichen selbst keine Builds, außer für den privaten Entwicklungsprozess und Debugging.

Zusätzlich zu den obigen Funktionen validieren und veröffentlichen ASF-Betreuer manuell Build-Prüfsummen unabhängig von GitHub, auf einem entfernten ASF-Server (als zusätzliche Sicherheitsmaßnahme). Dieser Schritt ist für bestehende ASFs zwingend erforderlich, um die Veröffentlichung als einen gültigen Kandidaten für die Auto-Update-Funktionalität zu betrachten.