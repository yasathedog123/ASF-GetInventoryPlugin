# Podešavanje

Ako ste ovdje prvi put, dobro došli! Srećni smo da vidimo još nekog ko je zainteresovan za naš projekat, ali zapamtite da sa velikom moći dolazi velika odgovornost - ASF ima mogućnost da kontroliše mnogo stvari na Steam-u, ali samo ako **pazite kako da ga naučite**. Strma je linija učenja, a mi očekujemo od vas da pročitate wiki-u zbog toga, koja objašnjava u detalju kako sve radi.

Ako ste još ovdje znači da ste izdržali tekst iznad, što je lijepo. Ako ste je preskočili, onda će vam uskoro biti **[loše](https://www.youtube.com/watch?v=WJgt6m6njVw)**... Anyway, ASF is a console app, which means that the program itself doesn't have a friendly GUI that you're in general used to, at least out of the box. ASF je najviše namijenjen da se koristi na serveru, pa zbog toga izgleda kao servis (daemon) a ne kao desktop aplikacija.

Ovo ipak ne znači da ga ne možete koristiti na vašem PC-u ili na nečem više komplikovanom nego obično. ASF je zaseban program koji ne zahtijeva instalaciju, i odmah radi ali zahtijeva konfiguraciju da bi vam bio od koristi. Konfiguracija kazuje ASF-u šta u stvari treba da radi nakon što ga pokrenete. Ako ga pokrenete bez konfiguracije, ASF onda neće raditi ništa, tako jednostavno.

---

## OS-specifično postavljanje

Opšte kazano, ovo ćete raditi u nekoliko sledećih minuta:
- Install **[.NET prerequisites](#net-prerequisites)**.
- Preuzmite **[poslednje ASF izdanje](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** u odgovarajućoj OS-specifičnoj varijanti.
- Extract the archive into new location.
- **[Konfigurišete ASF](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)**.
- pokrenite ASF i vidite magiju.

Zvuči jednostavno, zar ne? Pa počnimo.

---

### .NET prerequisites

Prvo morate biti sigurni da ASF može biti pokrenut na vašem OS-u. ASF is written in C#, based on .NET platform and may require native libraries that are not available on your platform yet. Depending on whether you use Windows, Linux or macOS, you will have different requirements, although all of them are listed in **[.NET prerequisites](https://docs.microsoft.com/dotnet/core/install)** document that you should follow. Ovo je naš materijal za podsjećanje koji treba biti korišćen, ali zbog jednostavnosti mi smo naveli sve pakete ispod, pa ne morate čitati čitav dokument.

Normalno je da neki (ili svi) zahtjevi već postoje na vašem sistemu zbog toga što ih je neki treći softver, koji već koristite, instalirao. Ipak, budite sigurni da stvarno imate potrebne zahtjeve na vašem OS-u - bez tih zahtjeva ASF se uopšte neće pokrenuti.

Keep in mind that you don't need to do anything else for OS-specific builds, especially installing .NET SDK or even runtime, since OS-specific package includes all of that already. You need only .NET prerequisites (dependencies) to run .NET runtime included in ASF.

#### **[Windows](https://docs.microsoft.com/dotnet/core/install/windows)**:
- **[Microsoft Visual C++ Redistributable Update](https://docs.microsoft.com/cpp/windows/latest-supported-vc-redist?view=msvc-170#visual-studio-2015-2017-2019-and-2022)** (**[x64](https://aka.ms/vs/17/release/vc_redist.x64.exe)** for 64-bit Windows, **[x86](https://aka.ms/vs/17/release/vc_redist.x86.exe)** for 32-bit Windows)
- Veoma je preporučljivo da budete sigurni da su sva postojeća Windows ažurirana instalirana. At the very least you need **[KB2533623](https://support.microsoft.com/en-us/help/2533623/microsoft-security-advisory-insecure-library-loading-could-allow-remot)**, **[KB2999226](https://support.microsoft.com/en-us/help/2999226/update-for-universal-c-runtime-in-windows)**, but more updates may be needed. Sve su već instalirane ako je Windows ažuriran do kraja. Budite sigurni da ste sve ovo uradili prije nego što instalirate Visual C++.

#### **[Linux](https://docs.microsoft.com/dotnet/core/install/linux)**:
Imena paketa zavise od Linux distribucije koju koristite, mi smo naveli najčešće varijacije. Možete ih instalirati sa nativnim paket menađerom na vašoj distribuciji (kao što je `apt` za Debian ili `yum` za CentOS).

- `ca-certificates` (standard trusted SSL certificates to make HTTPS connections)
- `libc6` (`libc`)
- `libgcc-s1` (`libgcc1`, `libgcc`)
- `libicu` (`icu-libs`, latest version for your distribution, for example `libicu72`)
- `libgssapi-krb5-2` (`libkrb5-3`, `krb5-libs`)
- `libssl1.1` (`libssl`, `openssl-libs`, latest version for your distribution, at least `1.1.X`)
- `libstdc++6` (`libstdc++`, u verziji `5.0` ili većoj)
- `zlib1g` (`zlib`)

Većina, ako ne i sve, bi trebalo da su već instalirane na vašem sistemi. The minimal installation of Debian stable required only `libicu72`.

#### **[macOS](https://docs.microsoft.com/dotnet/core/install/macos)**:
- None for now, but you should have latest version of macOS installed, at least 10.15+

---

### Preuzimanje

Sada kada imate sve zahtjeve ispunjene, sledeći korak je da preuzmete **[poslednje ASF izdanje](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)**. ASF je dostupan u raznim varijantama, ali vama je potreban paket koji je isti kao vaš operativni sistem i vaša arhitektura. Npr. ako koristite `64`-bit `Win`dows, onda izaberite `ASF-win-x64` paket. Za više informacija o dostupnim varijacijama, posjetite **[kompatabilnost](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility)** sekciju. ASF je moguće pokrenuti i na OS-ovima za koje ne pravimo OS namijenjeni paket, kao što je **32-bit Windows**, za njih izaberite **[opšta podešavanja](#generic-setup)**.

![Sredstva](https://i.imgur.com/Ym2xPE5.png)

Nakon preuzimanja, ekstraktujte zip fajl u novom folderu. If you require specific tool for that, **[7-zip](https://www.7-zip.org)** will do it, but all standard utilities like `unzip` from Linux/macOS should work without problems as well.

ASF je potrebno ekstraktovati u **svom novom direktorijumu** a ne u nekom postojećem direktorijumu koji koristite za nešto drugo - ASF će izbrisati sve fajlove koje ne prepoznaje ili mu nisu više potrebni nakon ažuriranja, što može dovesti do brisanja vaših fajlova ako ih smjestite u istom ASF folderu. Ako imate neki script ili fajl koji želite da koristite sa ASF-om, stavite ih u folder iznad.

Primjer ove strukture treba da izgleda ovako:

```text
C:\ASF (gdje stavljate vaše stvari)
    ├── ASF shortcut.lnk (opcionalno)
    ├── Config shortcut.lnk (opcionalno)
    ├── Commands.txt (opcionalno)
    ├── MyExtraScript.bat (opcionalno)
    ├── (...) (bilo koji fajl koji vi izaberete, opcionalno)
    └── Core (samo za ASF, ovdje ekstrakujete arhivu)
         ├── ArchiSteamFarm(.exe)
         ├── config
         ├── logs
         ├── plugins
         └── (...)
```

---

### Podešavanje

Sada smo na poslednjem koraku, konfiguraciji. Ovo je do sad najkomplikovaniji korak, pošto sadrži dosta novih informacija koje možda još ne poznajete, pa ćemo dati nekoliko lako-razumljivih primjera i jednostavnih objašnjenja ovdje.

Prvo i najvažnije, postoji stranica **[konfiguracija](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** koja objašnjava **sve** što je povezano sa konfiguracijom, ali sadrži veliku količinu informacija, od kojih je većinu ne morate odmah znati. Umjesto toga, naučićemo vas kako da nađete informacije koje su vam potrebne.

ASF configuration can be done in at least three ways - through our web config generator, ASF-ui or manually. Ovo je duboko objašnjena sekcija **[konfiguracije](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)**, pa se njom pozabavite ako želite detaljne informacije. We'll use web config generator as a starting point.

Pođite na našu stranicu **[web generator konfiguracije](https://justarchinet.github.io/ASF-WebConfigGenerator)** pomoću vašeg pretraživača. Ovdje morate imati JavaScript omogućen ako ste ga ručno onemogućili. Mi predlažemo Chrome ili Firefox, ali će vjerovatno raditi na svim poznatim pretraživačima.

Nakon otvaranja ove stranice, pođite na "Bot" tab. Kada ste tu, trebalo bi da vidite stranicu sličnu ovoj ispod:

![Bot tab](https://i.imgur.com/aF3k8Rg.png)

Ako je nikim slučajem vaša verzija ASF-a, koju ste preuzeli, starija od one kojom je web generator konfiguracije podešen, jednostavno izaberite vašu verziju ASF menia. Ovo se može desiti pošto generator konfiguracije može praviti konfiguracije za novije (pre-objavljene) ASF verzije koje još nisu stabilne za normalno izdanje. Vi ste preuzeli poslednju stabilnu verziju ASF-a koja je potvrđena da radi kako treba.

Počnite tako što ćete dati ime botu u predjelu označenom crvenom bojom. Ovo može biti bilo šta, kao što je nadimak, ime naloga, broj, ili bilo šta drugo. Postoji samo jedna riječ koju ne možete koristiti, a to je `ASF`, pošto je ova riječ rezervisana za fajl globalne konfiguracije. Pored toga imena botova ne mogu početi sa tačkom (ASF namjerno ignoriše ovakve fajlove). Mi takođe predlažemo da ne odvajate između riječi, umjesto odvajanja koristite `_`.

Kada ste odlučili koje ime ćete dati botu, stisnite `Omogućeno`, ovo kazuje ASF-u da li će vaš bot biti pokrenut ili ne nakon pokrenanja programa.

Sada možete odlučuti oko dvije stvari:
- Možete upisati vaše kredencijale za prijavu u `SteamLogin` polju i vašu lozinku u `SteamPassword` polju
- Ili ih možete ostaviti prazne

Ako unesete kredencijale to će omogućiti ASF-u da automatski koristi iste tokom pokretanju, i vi nećete morati da ih unosite svaki put kada želite da koristite ASF. Možete ih takođe izostaviti, a u tom slučaju oni neće biti sačuvani, i ASF će tražiti da ih unesete tokom svakog pokretanja.

ASF-u su potrebni kredencijali za prijavu zato što on posjeduje svoju inplementaciju Steam klienta i zato su mu potrebni iste stvari da bi se prijavio kao što vam i Steam klient traži kada se prijavljujete. Vaši kredencijali za prijavu su sačuvani samo na vašem PC-u u ASF `config` direktorijumu, naš web generator konfiguracije je klient-baziran što znači da je kod pokrenut lokalno u vašem pretraživaču, a detalji koje unesete ne šalju se nigdje van vašeg PC-a, pa se ne morate brinuti o curenju podataka negdje drugo. Ipak, ako zbog nekog razloga ne želite da unesete vaše podatke ovdje, mi to razumijemo, pa to možete uraditi u ručno napravljenim fajlovima, ili ih skroz maći pa ih svaki put unositi u ASF komandnoj liniji. Više o pitanjima sigurnosti možete pronaći u sekciji **[konfiguracija](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)**.

Takođe možete odlučiti da ostavite samo jedno polje prazno, kao što je `SteamPassword`, ASF će u tom slučaju automatski koristiti ime vašeg naloga, ali će tražiti vašu lozinku (slično kao što to radi Steam klient). Ako koristite roditeljska podešavanja na Steam-u da bi otključali vaš nalog, morate onda popuniti i polje `SteamParentalCode`.

Nakon vaših odluka i opcionih detalja, vaša web stranica bi trebala da izgleda slično ovoj ispod:

![Bot tab 2](https://i.imgur.com/yf54Ouc.png)

Sada možete pritisnuti "download" dugme i naš web generator konfiguracije će napraviti novi `json` fajl baziran na imenu vašeg bota. Sačuvajte taj fajl u `config` direktorijumu koji je lociran u folderu gdje ste ekstrakovali vaš zip fajl u prethodnom koraku.

Vaš `config` direktorijum bi trebao da izgleda slično ovom:

![Struktura 2](https://i.imgur.com/crWdjcp.png)

Čestitamo! Završili sve veoma jednostavnu konfiguraciju ASF bota. Ovo ćemo brzo dalje proširiti, ali za sad je to sve što vam je potrebno.

---

### Pokretanje ASF-a

Sada ste spremni da pokrenete program prvi put. Jednostavno dvokliknite `ArchiSteamFarm` fajl u ASF direktorijumu. You can also start it from the console.

Nakon toga, ako ste instalirali sve potrebno u prvom koraku, ASF bi trebao da se uspješno pokrene, zapamtite da će vaš prvi bot (ako niste zaboravili da stavite napravljenu konfiguraciju u `config` direktorijumu), pokušati da se prijavi:

![ASF](https://i.imgur.com/u5hrSFz.png)

Ako ste ispunili `SteamLogin` i `SteamPassword` polje koje ASF koristi, tražiće vam se SteamGuard token (e-mail, 2FA ili ništa, u zavisnosti od vaših Steam podešavanja). Ako niste dali Steam kredencijale, onda će vam se ovdje tražiti isti.

Now would be a good time to review our **[remote communication](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Remote-communication)** section if you're concerned about stuff ASF is programmed to do, including actions it'll take in your name, such as joining our Steam group.

After passing through initial login gate, assuming your details are correct, you'll successfully log in, and ASF will start farming using default settings that you didn't change as of now:

![ASF 2](https://i.imgur.com/Cb7DBl4.png)

Ovo pokazuje da ASF uspješno radi svoj posao na vašem nalogu, pa ga možete umanjiti i raditi nešto drugo. Nakon određenog vremena (u zavisnosti od **[performansi](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)**), polako ćete dobijati Steam kartice. Of course, for that to happen you must have valid games to farm, showing as "you can get X more card drops from playing this game" on your **[badges page](https://steamcommunity.com/my/badges)** - if there are no games to farm, then ASF will state that there is nothing to do, as stated in our **[FAQ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#what-is-asf)**.

Ovo je kraj našeg jednostavnog uputstva za podešavanje. Možete odlučiti da li želite da dalje konfigurišete ASF, ili da ga ostavite da radi pomoću opštih podešavanja. Proći ćemo kroz još nekoliko osnovnih stavki, a onda ćemo vam preputsiti da otkrijete ostatak wiki-e.

---

### Šira konfiguracija

#### Farming several accounts at once

ASF supports farming more than one account at a time, which is its primary function. Možete dodati više od jednog naloga u ASF pomoću generisanja više od jedne bot konfiguracije, na isti način na koji ste generisali prvu konfiguraciju prije nekoliko minuta. Morate biti sigururni o ove dvije stvari:

- Različita imena botova, ako je već ime prvog bota "GlavniNalog", ne možete napraviti drugog bota sa istim imenom.
- Pravilni detalji vašeg naloga, `SteamLogin`,<0 `SteamPassword` i `SteamParentalCode` (ako koristite Steam roditeljska podešavanja).

Drugim riječima, jednostavno ponovo idite na konfiguraciju i uradite istu stvar, za vaš drugi ili treći nalog. Zapamtite da morate koristiti različita imena za svakog bota.

---

#### Mijenjanje podešavanja

Možete promijeniti postojeća podešavanja na isti način - konfigurišući novi config fajl. Ako još niste zatvorili web generator konfiguracije, pritisnite "prikaži napredna podešavanja" da bi ste vidjeli šta je tu za vas da otkrijete. For this tutorial we'll change `CustomGamePlayedWhileFarming` setting, which allows you to set custom name being displayed when ASF is farming, instead of showing actual game.

So let's do that, if you run ASF and start farming, in default settings you'll see that your Steam account is in-game now:

![Steam](https://i.imgur.com/1VCDrGC.png)

Promijenimo to. Prikažite napredna podešavanja u vašem web generatoru konfiguracije i pronađite polje `CustomGamePlayedWhileFarming`. Kada to uradite, unesite tekst koji želite da bude prikazan, kao što je "Idlujem kartice":

![Bot tab 3](https://i.imgur.com/gHqdEqb.png)

Sada preuzmite novi konfiguracioni fajl na isti način, pa ga **zamijenite** sa vašim starim. Možete takođe izbrisati stari konfiguracioni fajl i dodati novi na njegovom mjesu.

Nakon što to uradite, pokrenite ASF ponovo, vidjećete da ASF sada prikazuje vaš uneseni tekst na prethodnom mjestu:

![Steam 2](https://i.imgur.com/vZg0G8P.png)

This confirms that you've successfully edited your config. In exactly the same way you can change global ASF properties, by switching from bot tab to "ASF" tab, downloading generated `ASF.json` config file and putting it in your `config` directory.

Editing your ASF configs can be done much easier by using our ASF-ui frontend, which will be explained further below.

---

#### Korišćenje ASF-ui

ASF je aplikacija u konsoli i ne sadrži grafički korisnički interfejs. Ipak, mi aktivno radimo na **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)** interfejsu za naš IPC, koji je veoma lak za korišćenje i pristup raznim ASF mogućnostima.

In order to use ASF-ui, you need to have `IPC` enabled, which is the default option. Once you launch ASF, you should be able to confirm that it properly started the IPC interface automatically:

![IPC](https://i.imgur.com/ZmkO8pk.png)

You can access ASF's IPC interface under **[this](http://localhost:1242)** link, as long as ASF is running, from the same machine. You can use ASF-ui for various purposes, e.g. editing the config files in-place or sending **[commands](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Slobodno razgledajte okolo da bi pronašli razne ASF-ui funkcije.

![ASF-ui](https://raw.githubusercontent.com/JustArchiNET/ASF-ui/main/.github/previews/bots.png)

---

### Zaključak

Uspješno ste podesili ASF da koristi vaš Steam nalog i uspješno ste ga uredili onako kako vam odgovara. If you followed our entire guide, then you also managed to tweak ASF through our ASF-ui interface and found out that ASF actually has a GUI of some sort. Now is a good time to read our entire **[configuration](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** section in order to learn what all those different settings you've seen actually do, and what ASF has to offer. If you've stumbled upon some issue or you have some generic question, read our **[FAQ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ)** instead which should cover all, or at least a vast majority of questions that you may have. Ako želite da naučite sve što postoji u ASF-u i kako vam to može pomoći, posjetite ostatak **[naše wiki-e](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Home)**. If you found out our program to be useful for you and you're feeling generous, you can also consider donating to our project. In any case, have fun!

---

## Opšta podešavanja

Ova podešavanja su za napredne korisnike koji žele da podese ASF za pokretanje na **[opštoj](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility#generic)** varijanti. While being more troublesome in usage than **[OS-specific variants](#os-specific-setup)**, they also come with additional benefits.

You want to use `generic` variant mainly in those situations (but of course you can use it regardless):
- Kada koristite OS za koji nema OS-specifičan paket (kao što je 32-bitni Windows)
- When you already have .NET Runtime/SDK, or want to install and use one
- When you want to minimize ASF structure size and memory footprint by handling runtime requirements yourself
- When you want to use a custom **[plugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)** which requires a `generic` setup of ASF to run properly (due to missing native dependencies)

However, keep in mind that you're in charge of .NET runtime in this case. This means that if your .NET SDK (runtime) is unavailable, outdated or broken, ASF won't work. This is why we don't recommend this setup for casual users, since you now need to ensure that your .NET SDK (runtime) matches ASF requirements and can run ASF, as opposed to **us** ensuring that our .NET runtime bundled with ASF can do so.

For `generic` package, you can follow entire OS-specific guide above, with two small changes. In addition to installing .NET prerequisites, you also want to install .NET SDK, and instead of having OS-specific `ArchiSteamFarm(.exe)` executable file, you now have a generic `ArchiSteamFarm.dll` binary only. Sve ostalo je isto.

Sa dodatnim koracima:
- Install **[.NET prerequisites](#net-prerequisites)**.
- Install **[.NET SDK](https://www.microsoft.com/net/download)** (or at least ASP.NET Core runtime) appropriate for your OS. Vjerovatno ćete željeti da koristite automatsku instalaciju. Pogledajte **[runtime zahtjeve](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility#runtime-requirements)** ako niste sigurni koju verziju da instalirate.
- Download **[latest ASF release](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** in `generic` variant.
- Extract the archive into new location.
- **[Konfigurišete ASF](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)**.
- Pokrenite ASF koristeći pomoćni skript ili ručnom ekekjucijom `dotnet /ruta/do/ArchiSteamFarm.dll` iz vaše omiljene ljuske.

Helper scripts (such as `ArchiSteamFarm.cmd` for Windows and `ArchiSteamFarm.sh` for Linux/macOS) are located next to `ArchiSteamFarm.dll` binary - those are included in `generic` variant only. Njih možete koristiti ako ne želite da ručno ekekjutujete `dotnet` komande. Obviously helper scripts won't work if you didn't install .NET SDK and you don't have `dotnet` executable available in your `PATH`. Pomoćni skriptovi su skroz opcionalni, uvijek možete ručno koristiti `dotnet /ruta/do/ArchiSteamFarm.dll`.