# Kompilierung

Kompilierung ist der Prozess zur Erstellung von ausführbaren Dateien. Dies ist ratsam, wenn Sie ihre eigenen Änderungen zu ASF hinzufügen wollen, oder wenn Sie aus irgendeinem Grund den ausführbaren Dateien der offiziell bereitgestellten **[Versionen](https://github.com/JustArchiNET/ArchiSteamFarm/releases)** nicht vertrauen. Wenn Sie ein einfacher Benutzer und kein Entwickler sind, möchten Sie höchstwahrscheinlich bereits vorkompilierte Binärdateien verwenden. Wenn Sie aber eigenen Dateien verwenden oder etwas Neues lernen möchten, lesen Sie bitte hier weiter.

ASF kann auf allen momentan unterstützten Plattformen kompiliert werden, solange Sie Zugriff auf die benötigten Programme haben.

---

## .NET SDK

Regardless of platform, you need full .NET SDK (not just runtime) in order to compile ASF. Installation instructions can be found on **[.NET download page](https://dotnet.microsoft.com/download)**. You need to install appropriate .NET SDK version for your OS. Nach erfolgreicher Installation sollte der Befehl `dotnet` funktionieren und betriebsbereit sein. Sie können mit `dotnet --info` überprüfen ob es funktioniert. Also ensure that your .NET SDK matches ASF **[runtime requirements](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility#runtime-requirements)**.

---

## Kompilierung

Assuming you have .NET SDK operative and in appropriate version, simply navigate to source ASF directory (cloned or downloaded and unpacked ASF repo) and execute:

```shell
dotnet publish ArchiSteamFarm -c "Release" -f "net7.0" -o "out/generic"
```

Für Linux/macOS als Zielplattform können Sie stattdessen das Skript `cc.sh` verwenden, womit dasselbe in komplexerer Weise ausgeführt wird.

Wenn die Kompilierung erfolgreich beendet wurde, finden Sie ihr ASF in der `source` Version im `ArchiSteamFarm/out/generic` Verzeichnis. Dies gleicht sich mit dem offiziellen `generic` ASF-Build, nur ist hier der `UpdateChannel` und `UpdatePeriod` auf `0` gesetzt, womit ein überschreiben des Selbst-Builds bis zur nächsten Kompilierung vermieden wird.

### Betriebssystemspezifisch

You can also generate OS-specific .NET package if you have a specific need. In general you shouldn't do that because you've just compiled `generic` flavour that you can run with your already-installed .NET runtime that you've used for the compilation in the first place, but just in case you want to:

```shell
dotnet publish ArchiSteamFarm -c "Release" -f "net7.0" -o "out/linux-x64" -r "linux-x64"
```

Natürlich sollten Sie `linux-x64` durch eine Betriebssystemarchitektur ersetzen die Sie anpeilen möchten, wie beispielsweise `win-x64`. Auch in diesem Build werden Aktualisierungen deaktiviert sein.

### .NET Framework

In a very rare case when you'd want to build `generic-netf` package, you can change target framework from `net7.0` to `net481`. Keep in mind that you'll need appropriate **[.NET Framework](https://dotnet.microsoft.com/download/visual-studio-sdks)** developer pack for compiling `netf` variant, in addition to .NET SDK, so the below will work only on Windows:

```shell
dotnet publish ArchiSteamFarm -c "Release" -f "net481" -o "out/generic-netf"
```

In case of being unable to install .NET Framework or even .NET SDK itself (e.g. because of building on `linux-x86` with `mono`), you can call `msbuild` directly. Sie müssen auch `ASFNetFramework` manuell angeben, da ASF standardmäßig `netf` build auf Nicht-Windows-Plattformen deaktiviert:

```shell
msbuild /m /r /t:Publish /p:Configuration=Release /p:TargetFramework=net481 /p:PublishDir=out/generic-netf /p:ASFNetFramework=true ArchiSteamFarm
```

### ASF-UI

While the above steps are everything that is required to have a fully working build of ASF, you may *also* be interested in building **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)**, our graphical web interface. From ASF side, all you need to do is dropping ASF-ui build output in standard `ASF-ui/dist` location, then building ASF with it (again, if needed).

ASF-ui is part of ASF's source tree as a **[git submodule](https://git-scm.com/book/en/v2/Git-Tools-Submodules)**, ensure that you've cloned the repo with `git clone --recursive`, as otherwise you'll not have the required files. You'll also need a working NPM, **[Node.js](https://nodejs.org)** comes with it. Wenn Sie Linux/macOS verwenden, empfehlen wir unser `cc. h` Skript, das automatisch den Bau und Versand von ASF-UI abdeckt (falls möglich, das heißt, wenn Sie die Anforderungen erfüllen, die wir gerade erwähnt haben).

In addition to the `cc.sh` script, we also attach the simplified build instructions below, refer to **[ASF-ui repo](https://github.com/JustArchiNET/ASF-ui)** for additional documentation. From ASF's source tree location, so as above, execute the following commands:

```shell
rm -rf "ASF-ui/dist" # ASF-ui doesn't clean itself after old build

npm ci --prefix ASF-ui
npm run-script deploy --prefix ASF-ui

rm -rf "out/generic/www" # Ensure that our build output is clean of the old files
dotnet publish ArchiSteamFarm -c "Release" -f "net7.0" -o "out/generic" # Or accordingly to what you need as per the above
```

You should now be able to find the ASF-ui files in your `out/generic/www` folder. ASF will be able to serve those files to your browser.

Alternatively, you can simply build ASF-ui, whether manually or with the help of our repo, then copy the build output over to `${OUT}/www` folder manually, where `${OUT}` is the output folder of ASF that you've specified with `-o` parameter. This is exactly what ASF is doing as part of the build process, it copies `ASF-ui/dist` (if exists) over to `${OUT}/www`, nothing fancy.

---

## Entwicklung

If you'd like to edit ASF code, you can use any .NET compatible IDE for that purpose, although even that is optional, since you can as well edit with a notepad and compile with `dotnet` command described above. Dennoch empfehlen wir für Windows ein **[aktuelles Visual Studio](https://visualstudio.microsoft.com/downloads)** (kostenlose Community-Version reicht vollkommen).

Falls Sie stattdessen den ASF-Quelltext unter Linux/macOS möchten, empfehlen wir die **[aktuellste Visual Studio Code Version](https://code.visualstudio.com/download)**. Diese Version ist nicht so umfangreich wie das klassische Visual Studio, aber reicht vollkommen aus.

Natürlich sind alle obigen Vorschläge nur Empfehlungen, Du kannst verwenden was immer Du willst. Am Ende wird sowieso immer `dotnet build` ausgeführt. Wir verwenden **[JetBrains Rider](https://www.jetbrains.com/rider)** für die ASF-Entwicklung, obwohl es keine freie Lösung ist.

---

## Tags

Der `main` Zweig ist nicht unbedingt in einem Zustand, der eine erfolgreiche Kompilierung oder eine fehlerfreie ASF-Ausführung überhaupt erst ermöglicht, da es sich um einen Entwicklungszweig handelt, wie in unserem **[Veröffentlichungszyklus](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Release-cycle-de-DE)** beschrieben. Für die Kompilierung oder Referenz von ASF aus dem Quelltext, die wird ein angemessenes **[Tag](https://github.com/JustArchiNET/ArchiSteamFarm/tags)** benötigt, welches zumindest eine erfolgreiche kompilation, und problemlose Ausführung (falls das Build als stable release markiert wurde), zu garantieren. In order to check the current "health" of the tree, you can use our CI - **[GitHub](https://github.com/JustArchiNET/ArchiSteamFarm/actions/workflows/ci.yml?query=branch%3Amain)**.

---

## Offizielle Veröffentlichungen

Official ASF releases are compiled by **[GitHub](https://github.com/JustArchiNET/ArchiSteamFarm/actions)** on Windows, with latest .NET SDK that matches ASF **[runtime requirements](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility#runtime-requirements)**. Nach dem Bestehen von Tests werden alle Pakete auf GitHub als Release bereitgestellt. Dies garantiert auch Transparenz, da GitHub immer offizielle öffentliche Quellen für alle Builds verwendet und Sie können die Prüfsummen der GitHub Artefakte mit GitHub Release-Assets abgleichen. Die ASF-Entwickler kompilieren oder veröffentlichen selbst keine Builds, außer für den privaten Entwicklungsprozess und Debugging.

Starting from ASF V5.2.0.5, in addition to the above, ASF maintainers manually validate and publish build checksums on independent from GitHub, remote server, as additional security measure. This step is mandatory for existing ASFs to consider the release as a valid candidate for auto-update functionality.