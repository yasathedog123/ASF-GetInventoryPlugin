# Compilazione

La compilazione è il processo di creazione del file eseguibile. Questo è quanto vuoi fare se vuoi aggiungere le tue modifiche ad ASF, o se per qualche motivo non ti fidi dei file eseguibili forniti nelle **[versioni](https://github.com/JustArchiNET/ArchiSteamFarm/releases)** ufficiali. Se sei un utente e non uno sviluppatore, molto probabilmente vorrai usare i binari già precompilati, ma se vuoi usare i tuoi, o vuoi imparare qualcosa di nuovo, continua a leggere.

ASF è compilabile su ogni piattaforma correntemente supportata, finché hai tutti gli strumenti per farlo.

---

## .NET SDK

Regardless of platform, you need full .NET SDK (not just runtime) in order to compile ASF. Installation instructions can be found on **[.NET download page](https://dotnet.microsoft.com/download)**. You need to install appropriate .NET SDK version for your OS. Dopo l'installazione riuscita, il comando `dotnet` dovrebbe esser funzionante e operativo. Puoi verificare che funzioni con `dotnet --info`. Also ensure that your .NET SDK matches ASF **[runtime requirements](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility#runtime-requirements)**.

---

## Compilazione

Assuming you have .NET SDK operative and in appropriate version, simply navigate to source ASF directory (cloned or downloaded and unpacked ASF repo) and execute:

```shell
dotnet publish ArchiSteamFarm -c "Release" -o "out/generic"
```

If you're using Linux/macOS, you can instead use `cc.sh` script which will do the same, in a bit more complex manner.

Se la compilazione è terminata correttamente, puoi trovare il tuo ASF in forma di `sorgente` nella cartella `out/generic`. Ha pari valore alla build ufficiale `generica` di ASF, ma ha `UpdateChannel` e `UpdatePeriod` di `0` forzati, il che è appropriato per le build personali.

### Specifico all'OS

You can also generate OS-specific .NET package if you have a specific need. In general you shouldn't do that because you've just compiled `generic` flavour that you can run with your already-installed .NET runtime that you've used for the compilation in the first place, but just in case you want to:

```shell
dotnet publish ArchiSteamFarm -c "Release" -o "out/linux-x64" -r "linux-x64"
```

Ovviamente, sostituisci `linux-64` con l'architettura OS a cui vuoi destinarlo, come `win-x64`. Questa build avrà inoltre gli aggiornamenti disabilitati.

### ASF-ui

While the above steps are everything that is required to have a fully working build of ASF, you may *also* be interested in building **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)**, our graphical web interface. From ASF side, all you need to do is dropping ASF-ui build output in standard `ASF-ui/dist` location, then building ASF with it (again, if needed).

ASF-ui is part of ASF's source tree as a **[git submodule](https://git-scm.com/book/en/v2/Git-Tools-Submodules)**, ensure that you've cloned the repo with `git clone --recursive`, as otherwise you'll not have the required files. You'll also need a working NPM, **[Node.js](https://nodejs.org)** comes with it. If you're using Linux/macOS, we recommend our `cc.sh` script, which will automatically cover building and shipping ASF-ui (if possible, that is, if you're meeting the requirements we've just mentioned).

In addition to the `cc.sh` script, we also attach the simplified build instructions below, refer to **[ASF-ui repo](https://github.com/JustArchiNET/ASF-ui)** for additional documentation. From ASF's source tree location, so as above, execute the following commands:

```shell
rm -rf "ASF-ui/dist" # ASF-ui doesn't clean itself after old build

npm ci --prefix ASF-ui
npm run-script deploy --prefix ASF-ui

rm -rf "out/generic/www" # Ensure that our build output is clean of the old files
dotnet publish ArchiSteamFarm -c "Release" -o "out/generic" # Or accordingly to what you need as per the above
```

You should now be able to find the ASF-ui files in your `out/generic/www` folder. ASF will be able to serve those files to your browser.

Alternatively, you can simply build ASF-ui, whether manually or with the help of our repo, then copy the build output over to `${OUT}/www` folder manually, where `${OUT}` is the output folder of ASF that you've specified with `-o` parameter. This is exactly what ASF is doing as part of the build process, it copies `ASF-ui/dist` (if exists) over to `${OUT}/www`, nothing fancy.

---

## Sviluppo

If you'd like to edit ASF code, you can use any .NET compatible IDE for that purpose, although even that is optional, since you can as well edit with a notepad and compile with `dotnet` command described above. Tuttavia, per Windows consigliamo l'**[ultimo Visual Studio](https://visualstudio.microsoft.com/downloads)** (la versione gratuita della community è più che sufficiente).

If you'd like to work with ASF code on Linux/macOS instead, we recommend **[latest Visual Studio Code](https://code.visualstudio.com/download)**. Non è ricca come il classico Visual Studio, ma va abbastanza bene.

Ovviamente tutti i suggerimenti sopra sono solo consigli, puoi usare ciò che vuoi, si riduce comunque al comando `dotnet build`. Usiamo **[JetBrains Rider](https://www.jetbrains.com/rider)** per lo sviluppo di ASF, sebbene non sia una soluzione gratuita.

---

## Tag

Il ramo `main` non è garantito in uno stato che consenta una compilazione di successo o un'esecuzione impeccabile di ASF in primo luogo, poiché è il suo ramo di sviluppo, proprio come dichiarato nel nostro **[ciclo di rilascio](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Release-cycle)**. Se vuoi compilare o riferirti ad ASF dalla sorgente, allora dovresti usare il **[tag](https://github.com/JustArchiNET/ArchiSteamFarm/tags)** appropriato per tale scopo, garantendo almeno una compilazione di successo, e molto probabilmente anche l'esecuzione impeccabile (se la build era segnata come versione stabile). In order to check the current "health" of the tree, you can use our CI - **[GitHub](https://github.com/JustArchiNET/ArchiSteamFarm/actions/workflows/ci.yml?query=branch%3Amain)**.

---

## Versioni ufficiali

Official ASF releases are compiled by **[GitHub](https://github.com/JustArchiNET/ArchiSteamFarm/actions)**, with latest .NET SDK that matches ASF **[runtime requirements](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility#runtime-requirements)**. Dopo aver superato i testi, tutti i pacchetti sono distribuiti come versione, anche su GitHub. Questo garantisce anche la trasparenza, dato che GitHub usa sempre sorgenti pubbliche ufficiali per tutte le build e poiché puoi comparare le somme di controllo degli artefatti di GitHub con le risorse di rilascio di GitHub. Gli sviluppatori di ASF non compilano o pubblicano loro stessi le build, eccetto per il processo di sviluppo privato e il debug.

In addition to the above, ASF maintainers manually validate and publish build checksums on independent from GitHub, remote ASF server, as additional security measure. This step is mandatory for existing ASFs to consider the release as a valid candidate for auto-update functionality.