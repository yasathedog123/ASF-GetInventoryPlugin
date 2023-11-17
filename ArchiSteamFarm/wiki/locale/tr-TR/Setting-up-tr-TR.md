# Kurulum

Buraya ilk kez geldiyseniz, hoş geldiniz! Projemizle ilgilenen başka bir yolcuyu görmekten çok mutluyuz, bununla birlikte büyük bir güçle büyük sorumluluk alındığını aklınızda bulundurun - ASF Steam birçok farklı şey yapabilir, ancak siz sadece **nasıl kullanılacağını öğrenme konusunda dikkatli olun **. Burada yer alan dik bir öğrenme eğrisi var ve sizden bu konuda wiki'yi okumanızı bekliyoruz; bu, her şeyin nasıl işlediğini ayrıntılı olarak açıklar.

Eğer hala buradaysanız, yukarıdaki yazımıza katlandığınız anlamına gelir, bu güzel. Eğer onu atladıysan, o zaman yakında **[kötü bir zaman](https://www.youtube.com/watch?v=WJgt6m6njVw)** geçireceksin... Her neyse, ASF bir konsol uygulamasıdır, yani programın kendisinde genel olarak alıştığınız dost bir GUI (Grafiksel Kullanıcı Arayüzü) yoktur. ASF'nin esas olarak sunucularda çalıştırılması gerekiyordu, bu yüzden bir masaüstü uygulaması değil, bir hizmet (daemon) görevi görüyordu.

Ancak bu, PC'nizde kullanamayacağınız veya kullanmanın normalden daha karmaşık olduğu anlamına gelmez, öyle bir şey değil. ASF, kurulum gerektirmeyen ve tıklandığı anda çalışan, ancak kullanışlı hale gelmeden önce yapılandırma gerektiren bağımsız bir programdır. Yapılandırma, ASF'ı başlattıktan sonra yapılması gerekenleri söylüyor. Yapılandırma olmadan başlatırsanız, ASF hiçbir şey yapmaz, durum bu.

---

## İşletim sistemine özgü kurulum

Genel olarak, işte önümüzdeki birkaç dakika içinde yapacağımız şey:
- **[.NET ön gereksinimlerini](#net-prerequisites)** yükleyin.
- İşletim Sistemi'ne uygun değişkene göre **[en son ASF sürümünü](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** indirin.
- Arşivi yeni bir lokasyon içerisine çıkartın.
- **[ASF'yi yapılandırın](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)**.
- ASF'yi başlatın ve büyüyü görün.

Yeterince basit görünüyor, değil mi? Öyleyse hadi başlayalım.

---

### .NET ön gereksinimleri

İlk adım, işletim sisteminizin ASF'yi düzgün şekilde başlatabilmesini sağlamaktır. ASF is written in C#, based on .NET platform and may require native libraries that are not available on your platform yet. Depending on whether you use Windows, Linux or macOS, you will have different requirements, although all of them are listed in **[.NET prerequisites](https://docs.microsoft.com/dotnet/core/install)** document that you should follow. Bu, kullanılması gereken referans materyalimizdir, ancak basitlik adına, gerekli tüm paketleri aşağıda ayrıntılı olarak açıkladık, bu nedenle belgenin tamamını okumanıza gerek yok.

Kullanmakta olduğunuz üçüncü taraf yazılımlar tarafından yüklendiği için bazı (hatta tüm) bağımlılıkların sisteminizde zaten mevcut olması tamamen normaldir. Yine de, işletim sisteminiz için uygun yükleyiciyi çalıştırarak durumun gerçekten böyle olduğundan emin olmalısınız - bu bağımlılıklar olmadan ASF hiç başlamaz.

Keep in mind that you don't need to do anything else for OS-specific builds, especially installing .NET SDK or even runtime, since OS-specific package includes all of that already. You need only .NET prerequisites (dependencies) to run .NET runtime included in ASF.

#### **[Windows](https://docs.microsoft.com/dotnet/core/install/windows)**:
- **[Microsoft Visual C++ Redistributable Update](https://docs.microsoft.com/cpp/windows/latest-supported-vc-redist?view=msvc-170#visual-studio-2015-2017-2019-and-2022)** (**[x64](https://aka.ms/vs/17/release/vc_redist.x64.exe)** for 64-bit Windows, **[x86](https://aka.ms/vs/17/release/vc_redist.x86.exe)** for 32-bit Windows)
- Tüm Windows güncellemelerinin zaten yüklü olduğundan emin olmanız şiddetle önerilir. At the very least you need **[KB2533623](https://support.microsoft.com/en-us/help/2533623/microsoft-security-advisory-insecure-library-loading-could-allow-remot)**, **[KB2999226](https://support.microsoft.com/en-us/help/2999226/update-for-universal-c-runtime-in-windows)**, but more updates may be needed. Windows'unuz güncelse, hepsi zaten yüklenmiştir. Visual C++ paketini yüklemeden önce bu gereksinimleri karşıladığınızdan emin olun.

#### **[Linux](https://docs.microsoft.com/dotnet/core/install/linux)**:
Paket adları, kullandığınız Linux dağıtımına bağlıdır, en yaygın olanları listeledik. Hepsini işletim sisteminiz için yerel paket yöneticisi ile edinebilirsiniz (Debian için `apt` veya CentOS için `yum` gibi).

- `ca-certificates` (standard trusted SSL certificates to make HTTPS connections)
- `libc6` (`libc`)
- `libgcc1` (`libgcc`)
- `libicu` (`icu-libs`, dağıtımınız için en son sürüm, örneğin `libicu67`)
- `libgssapi-krb5-2` (`libkrb5-3`, `krb5-libs`)
- `libssl1.1` (`libssl`, `openssl-libs`, latest version for your distribution, at least `1.1.X` as `1.0.X` may no longer work)
- `libstdc++6` (`libstdc++`, `5.0` veya daha yüksek bir versiyon)
- `zlib1g` (`zlib`)

Bunların en azından çoğunluğu sisteminizde yerel olarak mevcut olmalıdır. The minimal installation of Debian stable required only `libicu67`.

#### **[macOS](https://docs.microsoft.com/dotnet/core/install/macos)**:
- None for now, but you should have latest version of macOS installed, at least 10.15+

---

### İndirme

Gerekli tüm bağımlılıklara zaten sahip olduğumuzdan, bir sonraki adım **[ASF'nin son sürümü](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)**'nü indirme işlemidir. ASF'nin birçok çeşidi mevcuttur, ancak işletim sisteminize ve mimarinize uygun paketle ilgileniyorsunuz. Örneğin, `64`-bit `Win`dows kullanıyorsanız, `ASF-win-x64` paketini istiyorsunuz. Mevcut varyantlar hakkında daha fazla bilgi için, **[Erişilebilirlik](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility)** adresini ziyaret edin. ASF ayrıca **32-bit Windows** gibi işletim sistemine özel paket oluşturmadığımız işletim sistemlerinde de çalışabilir, <strong x-id= Bunun için "1">[genel kurulum](#generic-setup)</strong> kısmına ilerleyin.

![Assets](https://i.imgur.com/Ym2xPE5.png)

İndirdikten sonra, zip dosyasını kendi klasörüne çıkarmaya başlayın. If you require specific tool for that, **[7-zip](https://www.7-zip.org)** will do it, but all standard utilities like `unzip` from Linux/macOS should work without problems as well.

ASF'yi başka bir şey için kullanmakta olduğunuz mevcut herhangi bir dizine değil, **kendi dizinine** açmanız tavsiye edilir - ASF'nin otomatik güncelleme özelliği tüm eski ve alakasız dosyaları siler yükseltme yaparken, ASF dizinine koyduğunuz ilgisiz herhangi bir şeyi kaybetmenize neden olabilir. ASF ile kullanmak istediğiniz fazladan komut dosyalarınız veya dosyalarınız varsa, bunları yukarıdaki bir klasöre koyun.

Örnek bir yapı şöyle görünecektir:

```text
C:\ASF (kendi dosyalarınızı koyduğunuz yer)
    ├── ASF Kısayolu.lnk (isteğe bağlı)
    ├── Ayar Kısayolu.lnk (isteğe bağlı)
    ├── Komutlar.txt (isteğe bağlı)
    ├── BenimEkstraKomutDosyam.bat (isteğe bağlı)
    ├── (...) (isteğinize bağlı herhangi bir dosya)
    └── Core (yalnızca ASF'ye ayrılmış, arşivi çıkardığınız yer)
         ├── ArchiSteamFarm(.exe)
         ├── config
         ├── logs
         ├── plugins
         └── (...)
```

---

### Yapılandırma

We're now ready to do the very last step, the configuration. This is by far the most complicated step, since it involves a lot of new information you're not familiar with yet, so we'll try to provide some easy to understand examples and simplified explanation here.

First and foremost, there is **[configuration](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** page that explains **everything** that relates to configuration, but it's a massive amount of new information, a lot of which we don't need to know right away. Instead, we'll teach you how to get the information you're actually looking for.

ASF configuration can be done in at least three ways - through our web config generator, ASF-ui or manually. This is explained in-depth in **[configuration](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** section, so refer to that if you want more detailed information. We'll use web config generator as a starting point.

Navigate to our **[web config generator](https://justarchinet.github.io/ASF-WebConfigGenerator)** page with your favourite browser, you'll need to have javascript enabled in case you manually disabled it. We recommend Chrome or Firefox, but it should work on all most popular browsers.

After opening the page, switch to "Bot" tab. You should now see a page similar to the one below:

![Bot tab](https://i.imgur.com/aF3k8Rg.png)

If by any chance the version of ASF that you've just downloaded is older than what config generator is set to use by default, simply choose your ASF version from the dropdown menu. This can happen as the config generator can be used for generating configs to newer (pre-release) ASF versions that weren't marked as stable yet. You've downloaded latest stable release of ASF that is verified to work reliably.

Start from putting name for your bot into the field highlighted as red. This can be any name you'd like to use, such as your nickname, account name, a number, or anything else. There is only one word that you can't use, `ASF`, as that keyword is reserved for global config file. In addition to that your bot name can't start with a dot (ASF intentionally ignores those files). We also recommend that you avoid using spaces, you can use `_` as a word separator if needed.

After you decided about your name, change `Enabled` switch to be on, this defines whether your bot is supposed to be started by ASF automatically after launch (of the program).

Now you can decide upon two things:
- You can put your login in `SteamLogin` field and your password in `SteamPassword` field
- Or you can leave them empty

Doing the first thing will allow ASF to automatically use your account credentials during startup, so you won't need to input them manually each time ASF needs them. You can however decide to omit them, in which case they're not being saved, so ASF won't be able to automatically start without your help and you'll need to input them during runtime.

ASF requires your login credentials because it includes its own implementation of Steam client and needs the same details to log in as the one that you use yourself. Your login credentials are not saved anywhere but on your PC in ASF `config` directory only, our web config generator is client-based which means that the code is run locally in your browser to generate valid ASF configs, without details you're inputting ever leaving your PC in the first place, so there is no need to worry about any possible sensitive data leak. Still, if you for whatever reason don't want to put your credentials there, we understand that, and you can put them manually later in generated files, or omit them entirely and put them only in ASF command prompt. More on security matter can be found in **[configuration](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** section.

You can also decide to leave just one field empty, such as `SteamPassword`, ASF will then be able to use your login automatically, but will still ask for password (similar to Steam Client). If you're using Steam parental to unlock the account, you'll need to put it into `SteamParentalCode` field.

After the decision and optional details, your web page will now look similar to the one below:

![Bot tab 2](https://i.imgur.com/yf54Ouc.png)

You can now hit "download" button and our web config generator will generate new `json` file based on your chosen name. Save that file into `config` directory which is located in the folder where you've extracted our zip file in the previous step.

Your `config` directory will now look like this:

![Structure 2](https://i.imgur.com/crWdjcp.png)

Congratulations! You've just finished the very basic ASF bot configuration. We'll extend this shortly, for now this is everything that you need.

---

### Running ASF

You're now ready to launch the program for the first time. Simply double-click `ArchiSteamFarm` binary in ASF directory. You can also start it from the console.

After doing so, assuming you installed all required dependencies in the first step, ASF should launch properly, notice your first bot (if you didn't forget to put generated config in `config` directory), and attempt to log in:

![ASF](https://i.imgur.com/u5hrSFz.png)

If you supplied `SteamLogin` and `SteamPassword` for ASF to use, you'll be asked for your SteamGuard token only (e-mail, 2FA or none, depending on your Steam settings). If you didn't, you'll also be asked for your Steam login and password.

Now would be a good time to review our **[remote communication](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Remote-communication)** section if you're concerned about stuff ASF is programmed to do, including actions it'll take in your name, such as joining our Steam group.

After passing through initial login gate, assuming your details are correct, you'll successfully log in, and ASF will start farming using default settings that you didn't change as of now:

![ASF 2](https://i.imgur.com/Cb7DBl4.png)

This proves that ASF is now successfully doing its job on your account, so you can now minimize the program and do something else. After enough of time (depending on **[performance](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)**), you'll see Steam trading cards slowly being dropped. Of course, for that to happen you must have valid games to farm, showing as "you can get X more card drops from playing this game" on your **[badges page](https://steamcommunity.com/my/badges)** - if there are no games to farm, then ASF will state that there is nothing to do, as stated in our **[FAQ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#what-is-asf)**.

This concludes our very basic setting up guide. You can now decide whether you want to configure ASF further, or let it do its job in default settings. We'll cover a few more basic details, then leave you entire wiki for discovery.

---

### Extended configuration

#### Farming several accounts at once

ASF supports farming more than one account at a time, which is its primary function. You can add more accounts to ASF by generating more bot config files, in exactly the same way as you've generated your first one just a few minutes ago. You need to ensure only two things:

- Unique bot name, if you already have your first bot named "MainAccount", you can't have another one with the same name.
- Valid login details, such as `SteamLogin`, `SteamPassword` and `SteamParentalCode` (if using Steam parental settings)

In other words, simply jump to configuration again and do exactly the same, just for your second or third account. Remember to use unique names for all of your bots.

---

#### Changing settings

You change existing settings in exactly the same way - by generating a new config file. If you didn't close our web config generator yet, click on "toggle advanced settings" and see what is there for you to discover. For this tutorial we'll change `CustomGamePlayedWhileFarming` setting, which allows you to set custom name being displayed when ASF is farming, instead of showing actual game.

So let's do that, if you run ASF and start farming, in default settings you'll see that your Steam account is in-game now:

![Steam](https://i.imgur.com/1VCDrGC.png)

Let's change that then. Toggle advanced settings in web config generator and find `CustomGamePlayedWhileFarming`. Once you do that, put your own custom text there that you want to display, such as "Idling cards":

![Bot tab 3](https://i.imgur.com/gHqdEqb.png)

Now download the new config file in exactly the same way, then **overwrite** your old config file with new one. You can also delete your old config file and put new one in its place of course.

Once you do that and start ASF again, you'll notice that ASF now displays your custom text in previous place:

![Steam 2](https://i.imgur.com/vZg0G8P.png)

This confirms that you've successfully edited your config. In exactly the same way you can change global ASF properties, by switching from bot tab to "ASF" tab, downloading generated `ASF.json` config file and putting it in your `config` directory.

Editing your ASF configs can be done much easier by using our ASF-ui frontend, which will be explained further below.

---

#### Using ASF-ui

ASF is a console app and doesn't include a graphical user interface. However, we're actively working on **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)** frontend to our IPC interface, which can be a very decent and user-friendly way to access various ASF features.

In order to use ASF-ui, you need to have `IPC` enabled, which is the default option starting with ASF V5.1.0.0. Once you launch ASF, you should be able to confirm that it properly started the IPC interface automatically:

![IPC](https://i.imgur.com/ZmkO8pk.png)

You can access ASF's IPC interface under **[this](http://localhost:1242)** link, as long as ASF is running, from the same machine. You can use ASF-ui for various purposes, e.g. editing the config files in-place or sending **[commands](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Feel free to take a look around in order to find out all ASF-ui functionalities.

![ASF-ui](https://raw.githubusercontent.com/JustArchiNET/ASF-ui/main/.github/previews/bots.png)

---

### Özet

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
- Arşivi yeni bir lokasyon içerisine çıkartın.
- **[ASF'yi yapılandırın](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)**.
- Launch ASF by either using a helper script or executing `dotnet /path/to/ArchiSteamFarm.dll` manually from your favourite shell.

Helper scripts (such as `ArchiSteamFarm.cmd` for Windows and `ArchiSteamFarm.sh` for Linux/macOS) are located next to `ArchiSteamFarm.dll` binary - those are included in `generic` variant only. You can use them if you don't want to execute `dotnet` command manually. Obviously helper scripts won't work if you didn't install .NET SDK and you don't have `dotnet` executable available in your `PATH`. Helper scripts are entirely optional to use, you can always `dotnet /path/to/ArchiSteamFarm.dll` manually.