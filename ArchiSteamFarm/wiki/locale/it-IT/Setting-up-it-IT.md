# Primi passi

Se sei qui per la prima volta, benvenuto! Siamo felici di vedere un altro viaggiatore interessato nel nostro progetto, ma tieni a mente che da un grande potere derivano grandi responsabilità - ASF è in grado di fare innumerevoli cose con Steam, ma soltanto finché **hai la volontà di imparare ad utilizzarlo**. C'è da considerare una ripida curva d'apprendimento e per questo ci aspettiamo che tu legga a dovere questo wiki, dove viene spiegato nel dettaglio il funzionamento di ogni cosa.

Se sei ancora qui vuol dire che hai già letto l'introduzione, il che è positivo. A meno che non ci sei passato sopra, e in tal caso sappi che presto **[avrai il tuo bel da fare](https://www.youtube.com/watch?v=WJgt6m6njVw)**... Anyway, ASF is a console app, which means that the program itself doesn't have a friendly GUI that you're in general used to, at least out of the box. ASF è stato principalmente pensato per essere eseguito su server, quindi si comporta più come un servizio (o daemon) che come un'applicazione classica.

Tuttavia ciò non significa che tu non possa usarlo sul tuo PC o che farlo funzionare sia più complicato del solito, per niente. ASF è un programma standalone che non necessita di installazione, subito pronto per essere utilizzato, ma che necessita d'essere configurato per poter essere di qualche uso. È infatti la sua configurazione che dirà ad ASF quello che deve fare una volta avviato. Se lo avvii senza averlo configurato, ASF semplicemente non farà nulla.

---

## Installazione per ogni OS

Il linea generale, ecco cosa faremo nei prossimi minuti:
- Install **[.NET prerequisites](#net-prerequisites)**.
- Scaricare **[l'ultima versione di ASF](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** specifica per il tuo sistema operativo.
- Extract the archive into new location.
- **[Configurare ASF](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)**.
- Avviare ASF e vederlo all'opera.

Suona piuttosto semplice, vero? Allora iniziamo.

---

### .NET prerequisites

Il primo passo consiste nell'assicurarsi che il proprio OS possa eseguire ASF correttamente. ASF is written in C#, based on .NET platform and may require native libraries that are not available on your platform yet. Depending on whether you use Windows, Linux or macOS, you will have different requirements, although all of them are listed in **[.NET prerequisites](https://docs.microsoft.com/dotnet/core/install)** document that you should follow. È la guida di riferimento che dovresti usare, ma per rendere le cose più semplici ed evitare di farti leggere troppo, sono anche riassunte in dettaglio qui sotto.

È perfettamente normale che alcuni, o anche tutti i prerequisiti siano già presenti nel tuo sistema, magari perché installati da applicazioni di terze parti che stai usando. Nonostante ciò, devi assicurarti che sia davvero questo il caso eseguendo l'installazione di ogni requisito per il tuo OS - senza di essi, ASF non funzionerà.

Keep in mind that you don't need to do anything else for OS-specific builds, especially installing .NET SDK or even runtime, since OS-specific package includes all of that already. You need only .NET prerequisites (dependencies) to run .NET runtime included in ASF.

#### **[Windows](https://docs.microsoft.com/dotnet/core/install/windows)**:
- **[Microsoft Visual C++ Redistributable Update](https://docs.microsoft.com/cpp/windows/latest-supported-vc-redist?view=msvc-170#visual-studio-2015-2017-2019-and-2022)** (**[x64](https://aka.ms/vs/17/release/vc_redist.x64.exe)** for 64-bit Windows, **[x86](https://aka.ms/vs/17/release/vc_redist.x86.exe)** for 32-bit Windows)
- È fortemente consigliato assicurarsi gli aggiornamenti di Windows siano tutti installati. At the very least you need **[KB2533623](https://support.microsoft.com/en-us/help/2533623/microsoft-security-advisory-insecure-library-loading-could-allow-remot)**, **[KB2999226](https://support.microsoft.com/en-us/help/2999226/update-for-universal-c-runtime-in-windows)**, but more updates may be needed. Se mantieni il tuo Windows aggiornato, saranno già installati. Assicurati di soddisfare tali requisiti prima di installare il pacchetto Visual C++.

#### **[Linux](https://docs.microsoft.com/dotnet/core/install/linux)**:
Il nome del pacchetto varia in base alla distribuzione di Linux che stai usando, ma elencheremo quelli che sono i più comuni. Li puoi ottenere dal tuo gestore di pacchetti nativo in base all'OS che usi (come `apt` per Debian, o `yum` per CentOS).

- `ca-certificates` (standard trusted SSL certificates to make HTTPS connections)
- `libc6` (`libc`)
- `libgcc1` (`libgcc`)
- `libicu` (`icu-libs`, latest version for your distribution, for example `libicu67`)
- `libgssapi-krb5-2` (`libkrb5-3`, `krb5-libs`)
- `libssl1.1` (`libssl`, `openssl-libs`, latest version for your distribution, at least `1.1.X` as `1.0.X` may no longer work)
- `libstdc++6` (`libstdc++`, in version `5.0` or higher)
- `zlib1g` (`zlib`)

At least a majority of those should be already natively available on your system. The minimal installation of Debian stable required only `libicu67`.

#### **[macOS](https://docs.microsoft.com/dotnet/core/install/macos)**:
- None for now, but you should have latest version of macOS installed, at least 10.15+

---

### Download

Ora che abbiamo i requisiti necessari, il prossimo passo sarà scaricare **[l'ultima versione di ASF](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)**. ASF è disponibile in molte varianti, ma tu sei interessato al pacchetto corrispondente al tuo sistema sperativo ed architettura. Ad esempio, se stai usando `Win`dows a `64` bit, allora ti servirà il pacchetto `ASF-win-x64`. Per maggiori informazioni sulle versioni disponibili, consulta la sezione **[compatibilità](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility)**. ASF è anche in grado di funzionare su sistemi operativi per i quali non è disponibile un pacchetto specifico, come **Windows a 32 bit**; se questo è il tuo caso, vai direttamente alla sezione **[setup generico](#generic-setup)**.

![Assets](https://i.imgur.com/Ym2xPE5.png)

Dopo il download, inizia estraendo i file dell'archivio in cartella dedicata. If you require specific tool for that, **[7-zip](https://www.7-zip.org)** will do it, but all standard utilities like `unzip` from Linux/macOS should work without problems as well.

Assicurati di estrarre ASF **in una cartella ad esso destinata** e non in una che stai già usando per qualcos'altro - gli aggiornamenti automatici di ASF elimineranno ogni altro file già presente e non necessario al programma, il che significa perdere qualsiasi file non associato ad ASF. Se hai script aggiuntivi o file che vuoi usare con ASF, mettili in una cartella superiore.

Una struttura ideale è simile a questa:

```text
C:\ASF (where you put your own things)
    ├── ASF shortcut.lnk (optional)
    ├── Config shortcut.lnk (optional)
    ├── Commands.txt (optional)
    ├── MyExtraScript.bat (optional)
    ├── (...) (any other files of your choice, optional)
    └── Core (dedicated to ASF only, where you extract the archive)
         ├── ArchiSteamFarm(.exe)
         ├── config
         ├── logs
         ├── plugins
         └── (...)
```

---

### Configurazione

Siamo ora pronti per affrontare l'ultima tappa, la configurazione. È di gran lunga la fase più complessa, poiché involve un gran numero di informazioni con le quali non hai ancora familiarità. Per questo ti forniremo diversi esempi e spiegazioni semplici da seguire.

Innanzitutto, è presente la pagina **[configurazione](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** che spiega **tutto quel che c'è da sapere** sul processo di configurazione; tuttavia offre molte più informazioni di cui al momento abbiamo bisogno. Perciò, ti spiegheremo come ottenere le informazioni che stai cercando.

ASF configuration can be done in at least three ways - through our web config generator, ASF-ui or manually. Ciò è spiegato nel dettaglio nella sezione **[configurazione](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)**, quindi fai riferimento ad essa se vuoi informazioni più dettagliate. We'll use web config generator as a starting point.

Apri la pagina del nostro **[generatore di configurazioni web](https://justarchinet.github.io/ASF-WebConfigGenerator)** con il browser che preferisci, avrai bisogno di abilitare javascript in caso tu lo abbia disabilitato manualmente. Raccomandiamo Chrome o Firefox, ma dovrebbe funzionare con i browser più usati.

Una volta caricata la pagina, clicca su "Bot". Dovresti avere davanti una pagina simile a questa:

![Bot tab](https://i.imgur.com/aF3k8Rg.png)

Se per qualche motivo la versione di ASF che hai appena scaricato è più vecchia di quella preselezionata dal generatore di configurazioni, seleziona la versione corretta dal menu a discesa. Ciò può accadere dacché il configuratore può essere usato anche per versioni più recenti di ASF, le "pre-release", che però non sono ancora ritenute stabili. Tu hai invece scaricato la più recente versione stabile di ASF, la cui affidabilità è stata comprovata.

Inizia dall'inserire il nome del tuo bot nel campo evidenziato in rosso. Può essere qualsiasi nome che tu desideri utilizzare, come il tuo nickname, nome dell'account, un numero o altro. C'è solo una parola che non puoi utilizzare, ed è `ASF`, poichè è riservata al file di configurazione generale. Inoltre, il nome del tuo bot non può iniziare con un punto (ASF ignora intenzionalmente questi file). Raccomandiamo inoltre di evitare l'uso degli spazi, ma puoi usare `_` come un separatore tra le parole se necessario.

Dopo aver deciso il nome del bot, clicca il bottone con il tick nella sezione `Enabled</0. Questo dichiara ad ASF se il bot deve essere avviato automaticamente dopo il lancio del programma.</p>

<p spaces-before="0">Ora puoi scegliere tra due cose:</p>

<ul>
<li>Puoi inserire i tuoi dati nel campo <code>SteamLogin` e la tua password in `SteamPassword`</li>
- O puoi lasciarli vuoti</ul>

Facendo la prima cosa, autorizzi ASF ad utilizzare automaticamente le credenziali del tuo account durante il lancio del programma, evitando così di inserirle manualmente ogni volta che ASF ne ha bisogno. Puoi tuttavia decidere di ometterle: in questo caso non vengono salvate, perciò ASF non potrà iniziare automaticamente il suo lavoro senza il tuo aiuto e dovrai inserirli mentre il programma è in esecuzione.

ASF richiede le tue credenziali di accesso perchè include la propria implementazione del client di Steam, e per accedere ha bisogno degli stessi dettagli che utilizzi tu. Le tue credenziali di login non sono salvate da nessuna parte, ma solo sul tuo PC nella cartella `config` di ASF. Il nostro generazione di configurazioni web è basato sul client, e ciò significa che il codice viene eseguito solo in locale nel tuo browser per generare configurazioni valide di ASF. Non c'è quindi bisogno di preoccuparsi di eventuali fughe di dati sensibili. Nel caso non volessi inserire le tue credenziali lì, lo capiamo, e puoi inserirle manualmente più tardi in file generati, od ometterle interamente ed inserirle solamente nel prompt dei comandi di ASF. Per saperne di più sulla sicurezza, visita la sezione **[configuration](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)**.

Puoi anche scegliere di lasciare un solo campo vuoto, come la `Password di Steam`, ed ASF utilizzerà automaticamente le tue credenziali, ma chiederà comunque l'inserimento di una password (simile al Client di Steam). Se utilizzi il sistema di controllo parentale di Steam per sbloccare l'account, dovrai inserirlo nel campo `SteamParentalCode`.

Dopo le tue decisioni e i dettagli facoltativi, la pagina web apparirà simile a quella qui sotto:

![Bot tab 2](https://i.imgur.com/yf54Ouc.png)

Ora puoi premere il tasto "download" ed il nostro generatore di configurazioni web genererà un file `json` basato sul nome scelto. Save that file into `config` directory which is located in the folder where you've extracted our zip file in the previous step.

La cartella `config` ora sarà simile a questa:

![Structure 2](https://i.imgur.com/crWdjcp.png)

Congratulazioni! Hai appena completato la configurazione fondamentale del bot ASF. La estenderemo a breve, ma per ora questo è tutto quello di cui hai bisogno.

---

### Eseguire ASF

Ora sei pronto per avviare il programma per la prima volta. Simply double-click `ArchiSteamFarm` binary in ASF directory. You can also start it from the console.

Dopo aver fatto tutto ciò, se hai installato tutte le dipendenze richieste nella prima parte, ASF si avvierà correttamente, noterà il tuo bot (se non hai dimenticato di inserire la configurazione generata nella cartella `config`), e proverà ad accedere:

![ASF](https://i.imgur.com/u5hrSFz.png)

Se hai fornito `SteamLogin` e `SteamPassword` ad ASF, ti sarà solamente chiesto il token per SteamGuard (e-mail, 2FA o nessuno, a seconda delle tue impostazioni di Steam). Se non lo hai fatto, ti sarà chiesto anche di inserire il nome utente e la password di Steam.

Now would be a good time to review our **[remote communication](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Remote-communication)** section if you're concerned about stuff ASF is programmed to do, including actions it'll take in your name, such as joining our Steam group.

After passing through initial login gate, assuming your details are correct, you'll successfully log in, and ASF will start farming using default settings that you didn't change as of now:

![ASF 2](https://i.imgur.com/Cb7DBl4.png)

Questo prova che ASF sta facendo un ottimo lavoro sul tuo account, ed ora puoi minimizzare il programma e fare qualcos'altro. Dopo un po'di tempo (a seconda della **[performance](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)**), vedrai le carte di Steam arrivare lentamente nel tuo inventario. Of course, for that to happen you must have valid games to farm, showing as "you can get X more card drops from playing this game" on your **[badges page](https://steamcommunity.com/my/badges)** - if there are no games to farm, then ASF will state that there is nothing to do, as stated in our **[FAQ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#what-is-asf)**.

Con questo si conclude la nostra guida fondamentale sull'impostare ASF. Ora puoi decidere se vuoi configurare ancora di più ASF, oppure lasciare che faccia il suo lavoro con le impostazioni predefinite. Ora ci occuperemo di altri dettagli base, per poi lasciarti l'intera wiki per scoprire cose nuove.

---

### Configurazione avanzata

#### Farming several accounts at once

ASF supports farming more than one account at a time, which is its primary function. Puoi aggiungere altri account ad ASF generando più file di configurazione dei bot, esattamente come hai generato il primo qualche minuto fa. Devi solo assicurarti di due cose:

- Nome del bot unico, se hai già il tuo primo bot chiamato "MainAccount", non potrai averne un altro con lo stesso nome.
- Dettagli di accesso validi, come `SteamLogin`, `SteamPassword` e `SteamParentalCode` (se usi le impostazioni di controllo parentale di Steam)

In altre parole, ritorna nuovamente alla configurazione ed esegui esattamente gli stessi passaggi per il tuo secondo o terzo account. Ricorda di usare nomi unici per tutti i tuoi bot.

---

#### Modifica delle impostazioni

Puoi cambiare le impostazioni esistenti creando un nuovo file di configurazione. Se non hai chiuso il nostro generatore di configurazioni web, clicca su "toggle advanced settings" e vedi cosa c'è da scoprire. For this tutorial we'll change `CustomGamePlayedWhileFarming` setting, which allows you to set custom name being displayed when ASF is farming, instead of showing actual game.

So let's do that, if you run ASF and start farming, in default settings you'll see that your Steam account is in-game now:

![Steam](https://i.imgur.com/1VCDrGC.png)

Cambiamo il nome del gioco. Attiva le impostazioni avanzate nel generatore di configurazioni web, e trova `CustomGamePlayedWhileFarming`. Una volta fatto questo, metti il tuo testo personalizzato che vuoi far mostrare, come "Farmando carte":

![Bot tab 3](https://i.imgur.com/gHqdEqb.png)

Ora scarica il nuovo file di configurazione e **sovrascrivi** quello esistente. Puoi anche eliminare il file vecchio ed inserire quello nuovo, ovviamente.

Una volta fatto questo, fai ripartire ASF e noterai che il programma mostra il tuo testo personalizzato su Steam:

![Steam 2](https://i.imgur.com/vZg0G8P.png)

This confirms that you've successfully edited your config. In exactly the same way you can change global ASF properties, by switching from bot tab to "ASF" tab, downloading generated `ASF.json` config file and putting it in your `config` directory.

Editing your ASF configs can be done much easier by using our ASF-ui frontend, which will be explained further below.

---

#### Utilizzo di ASF-ui

ASF è un'applicazione via terminale che non include un'interfaccia grafica. However, we're actively working on **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)** frontend to our IPC interface, which can be a very decent and user-friendly way to access various ASF features.

In order to use ASF-ui, you need to have `IPC` enabled, which is the default option starting with ASF V5.1.0.0. Once you launch ASF, you should be able to confirm that it properly started the IPC interface automatically:

![IPC](https://i.imgur.com/ZmkO8pk.png)

You can access ASF's IPC interface under **[this](http://localhost:1242)** link, as long as ASF is running, from the same machine. You can use ASF-ui for various purposes, e.g. editing the config files in-place or sending **[commands](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Sentiti libero di dare un'occhiata in giro per scoprire tutte le funzionalità di ASF-ui.

![ASF-ui](https://raw.githubusercontent.com/JustArchiNET/ASF-ui/main/.github/previews/bots.png)

---

### Sommario

You've successfully set up ASF to use your Steam accounts and you've already customized it to your liking a little. If you followed our entire guide, then you also managed to tweak ASF through our ASF-ui interface and found out that ASF actually has a GUI of some sort. Now is a good time to read our entire **[configuration](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** section in order to learn what all those different settings you've seen actually do, and what ASF has to offer. If you've stumbled upon some issue or you have some generic question, read our **[FAQ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ)** instead which should cover all, or at least a vast majority of questions that you may have. If you want to learn everything about ASF and how it can make your life easier, head over to the rest of **[our wiki](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Home)**. If you found out our program to be useful for you and you're feeling generous, you can also consider donating to our project. In any case, have fun!

---

## Generic setup

This setup is for advanced users that want to set up ASF to run in **[generic](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility#generic)** variant. While being more troublesome in usage than **[OS-specific variants](#os-specific-setup)**, they also come with additional benefits.

You want to use `generic` variant mainly in those situations (but of course you can use it regardless):
- When you're using OS that we don't build OS-specific package for (such as 32-bit Windows)
- When you already have .NET Runtime/SDK, or want to install and use one
- When you want to minimize ASF structure size and memory footprint by handling runtime requirements yourself
- When you want to use a custom **[plugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)** which requires a `generic` setup of ASF to run properly (due to missing native dependencies)

However, keep in mind that you're in charge of .NET runtime in this case. This means that if your .NET SDK (runtime) is unavailable, outdated or broken, ASF won't work. This is why we don't recommend this setup for casual users, since you now need to ensure that your .NET SDK (runtime) matches ASF requirements and can run ASF, as opposed to **us** ensuring that our .NET runtime bundled with ASF can do so.

For `generic` package, you can follow entire OS-specific guide above, with two small changes. In addition to installing .NET prerequisites, you also want to install .NET SDK, and instead of having OS-specific `ArchiSteamFarm(.exe)` executable file, you now have a generic `ArchiSteamFarm.dll` binary only. Everything else is exactly the same.

With extra steps:
- Install **[.NET prerequisites](#net-prerequisites)**.
- Install **[.NET SDK](https://www.microsoft.com/net/download)** (or at least ASP.NET Core runtime) appropriate for your OS. You most likely want to use an installer. Refer to **[runtime requirements](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility#runtime-requirements)** if you're not sure which version to install.
- Download **[latest ASF release](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** in `generic` variant.
- Extract the archive into new location.
- **[Configurare ASF](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)**.
- Launch ASF by either using a helper script or executing `dotnet /path/to/ArchiSteamFarm.dll` manually from your favourite shell.

Helper scripts (such as `ArchiSteamFarm.cmd` for Windows and `ArchiSteamFarm.sh` for Linux/macOS) are located next to `ArchiSteamFarm.dll` binary - those are included in `generic` variant only. You can use them if you don't want to execute `dotnet` command manually. Obviously helper scripts won't work if you didn't install .NET SDK and you don't have `dotnet` executable available in your `PATH`. Helper scripts are entirely optional to use, you can always `dotnet /path/to/ArchiSteamFarm.dll` manually.