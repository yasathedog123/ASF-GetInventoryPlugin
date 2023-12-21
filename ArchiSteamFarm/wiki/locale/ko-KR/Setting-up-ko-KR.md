# 설치하기

여기 오신게 처음인가요? 환영합니다! 우리 프로젝트에 관심을 가진 분이 또 있다니 정말 행복합니다. 다만 큰 힘에는 큰 책임이 따른다는 것을 기억하세요. ASF는 Steam에 관련된 다양한 많은 것을 할 수 있지만 당신이 **어떻게 사용한하는지 충분히 아는 만큼**만 쓸 수 있습니다. 이에 대한 학습 곡선은 가파르고, 이 관점에서 우리는 모든것이 어떻게 동작하는지 세부적으로 설명하는 위키를 당신이 읽어주시길 바랍니다.

위의 텍스트를 견뎌내고 여전히 여기 있네요? 좋아요. 막 넘기지 않았다면 이제 곧 **[끔찍한 시간](https://www.youtube.com/watch?v=WJgt6m6njVw)**이 될겁니다... Anyway, ASF is a console app, which means that the program itself doesn't have a friendly GUI that you're in general used to, at least out of the box. ASF는 주로 서버에서 돌아가도록 되어있고, 데스크탑 프로그램이 아닌 서비스(대몬)으로 동작합니다.

하지만 PC에서 사용할 수 없다거나 사용법이 뭔가 더 복잡하다거나 뭐 그런 뜻은 아닙니다. ASF는 설치가 필요없는 독립실행 프로그램으로, 상자에서 꺼내면 바로 작동합니다. 하지만 쓸만해지려면 설정이 필요합니다. 설정은 ASF가 실행된 후에 실제로 뭘 해야하는지를 알려주는 일입니다. 설정하지 않고 실행하면 ASF는 아무 것도 하지 않습니다. 간단하죠.

---

## 특정 OS에 설치하기

일반적으로 다음 몇분동안 할 일의 목록입니다:
- Install **[.NET prerequisites](#net-prerequisites)**.
- 특정 OS에 맞는 **[최신 버전 ASF](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** 다운로드
- Extract the archive into new location.
- **[ASF 환경설정](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-ko-KR)**
- ASF를 실행하고 마법을 경험하세요

꽤 간단한 것 같죠? 자 이제 해봅시다.

---

### .NET prerequisites

첫 번째 단계는 당신의 OS가 ASF를 제대로 실해할 수 있는지를 확인하는 것입니다. ASF is written in C#, based on .NET platform and may require native libraries that are not available on your platform yet. Depending on whether you use Windows, Linux or macOS, you will have different requirements, although all of them are listed in **[.NET prerequisites](https://docs.microsoft.com/dotnet/core/install)** document that you should follow. 이 참조자료를 사용해야 하지만, 편의를 위해 아래에 필요한 모든 패키지를 설명했으므로 문서 전체를 읽을 필요는 없습니다.

당신의 시스템에 일부(혹은 전체) 종속성이 이미 존재하는 것은 사용하고 있는 제3자 소프트웨어가 설치했을 수 있으므로 완벽하게 정상입니다. 하지만 당신의 OS에 맞는 설치관리자가 실행중인지를 확인해야 합니다. 이 종속성 없이는 ASF가 전혀 실해되지 않습니다.

Keep in mind that you don't need to do anything else for OS-specific builds, especially installing .NET SDK or even runtime, since OS-specific package includes all of that already. You need only .NET prerequisites (dependencies) to run .NET runtime included in ASF.

#### **[Windows](https://docs.microsoft.com/dotnet/core/install/windows)**:
- **[Microsoft Visual C++ Redistributable Update](https://docs.microsoft.com/cpp/windows/latest-supported-vc-redist?view=msvc-170#visual-studio-2015-2017-2019-and-2022)** (**[x64](https://aka.ms/vs/17/release/vc_redist.x64.exe)** for 64-bit Windows, **[x86](https://aka.ms/vs/17/release/vc_redist.x86.exe)** for 32-bit Windows)
- 모든 윈도우 업데이트를 미리 설치해 놓는 것을 매우 권장합니다. At the very least you need **[KB2533623](https://support.microsoft.com/en-us/help/2533623/microsoft-security-advisory-insecure-library-loading-could-allow-remot)**, **[KB2999226](https://support.microsoft.com/en-us/help/2999226/update-for-universal-c-runtime-in-windows)**, but more updates may be needed. 윈도우가 최신 상태라면 모든 것이 설치되어 있을 것입니다. Visual C++ 패키지를 설치하기 전에 요구사항을 충족하는지 확인하십시오.

#### **[Linux](https://docs.microsoft.com/dotnet/core/install/linux)**:
리눅스 배포판에 따라 패키지 이름이 다릅니다. 아래에 공통적인 것들을 나열했습니다. 데비안에서는 `apt`, CentOS에서는 `yum` 등 OS에서 사용하는 자체 패키지 관리자를 통해 전부를 설치할 수 있습니다.

- `ca-certificates` (standard trusted SSL certificates to make HTTPS connections)
- `libc6` (`libc`)
- `libgcc-s1` (`libgcc1`, `libgcc`)
- `libicu` (`icu-libs`, latest version for your distribution, for example `libicu72`)
- `libgssapi-krb5-2` (`libkrb5-3`, `krb5-libs`)
- `libssl1.1` (`libssl`, `openssl-libs`, latest version for your distribution, at least `1.1.X`)
- `libstdc++6` (`libstdc++`, in version `5.0` or higher)
- `zlib1g` (`zlib`)

At least a majority of those should be already natively available on your system. The minimal installation of Debian stable required only `libicu72`.

#### **[macOS](https://docs.microsoft.com/dotnet/core/install/macos)**:
- None for now, but you should have latest version of macOS installed, at least 10.15+

---

### 다운로드

모든 필요한 종속 프로그램을 다 가지고 있으므로, 다음 단계는 **[최신 ASF 릴리즈](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)**를 다운로드 받는 것입니다. ASF는 다양한 변종이 있지만 당신은 OS와 아키텍쳐에 맞는 패키지를 원할 것입니다. 예를들어 `64`-비트 `윈도우`를 사용한다면, `ASF-win-x64` 패키지를 사용하면 됩니다. 사용가능한 변종에 대한 더 많은 정보를 원하시면 **[호환성](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility-ko-KR)** 항목을 참고하십시오. ASF는 **32비트 윈도우**같은 특정OS용 패키지가 없는 다른 OS에서도 실행이 가능합니다. **[일반 설치](#일반 설치)**항목을 참고하시기 바랍니다.

![Assets](https://i.imgur.com/Ym2xPE5.png)

다운로드 후에 zip 파일의 압축을 폴더에 푸는 것부터 시작하십시오. If you require specific tool for that, **[7-zip](https://www.7-zip.org)** will do it, but all standard utilities like `unzip` from Linux/macOS should work without problems as well.

ASF를 기존에 다른 무언가로 쓰고있던 디렉토리가 아닌 **새 디렉토리**에 압축을 푸는 것을 권장합니다. ASF의 자동업데이트 기능은 업그레이드할때 모든 오래되고 관련이 없는 파일들을 삭제합니다. 만약 ASF디렉토리에 관련이 없는 뭔가가 있다면 없어질 것입니다. ASF와 함께 사용하고 싶은 추가 스크립트나 파일이 있다면 한단계 상위 폴더에 넣으십시오.

다음은 구조도 예시입니다:

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

### 환경설정

마지막 단계인 환경설정을 할 준비가 되었습니다. 아직 익숙하지 않은 많은 새로운 정보가 잔뜩 생기므로 지금까지 중에서 가장 복잡한 단계입니다. 그래서 이해하기 쉬운 예제와 간략한 설명을 여기에서 제공하려고 합니다.

가장 먼저, 환경설정과 관련된 **모든 것** 을 설명하는 **[환경설정](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-ko-KR)** 페이지가 있지만 엄청난 양의 새로운 정보이고, 상당량은 당장 알 필요는 없습니다. 그 대신, 실제로 찾는 정보를 얻는 방법을 알려드리겠습니다.

ASF configuration can be done in at least three ways - through our web config generator, ASF-ui or manually. 이에 대해 **[환경설정](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-ko-KR)** 항목에서 깊게 설명하고 있으므로 더 자세한 정보를 원한다면 참고하십시오. We'll use web config generator as a starting point.

사용하는 웹 브라우저로 **[웹 환경설정 생성기](https://justarchinet.github.io/ASF-WebConfigGenerator)** 페이지에 갑니다. 자바스크립트를 수동으로 비활성화 했다면 활성화 해두어야 합니다. 크롬이나 파이어폭스를 권장하지만, 거의 대부분의 유명한 브라우저에서 작동합니다.

페이지를 연 후 "Bot" 탭으로 전환합니다. 아래와 비슷한 페이지를 볼 수 있습니다.

![Bot tab](https://i.imgur.com/aF3k8Rg.png)

혹시라도 방금 다운로드한 ASF의 버전이 환경설정 생성기가 기본으로 사용하도록 설정된 버전보다 오래되었다면, 드롭다운 메뉴에서 사용중인 ASF 버전을 선택합니다. 환경설정 생성기는 사전릴리스 등 아직 안정버전이 아닌 새로운 ASF 버전용으로도 사용할 수 있어서 이런 일이 발생합니다. ASF의 최신 안정 릴리스를 다운로드했다면 안정적으로 동작할 것입니다.

빨간색으로 강조된 필드에 봇 이름을 넣는 것부터 시작하십시오. 이것은 별명, 계정명, 숫자 등등 당신이 사용하고 싶은 어떤 이름이라도 가능합니다. 사용할 수 없는 단 하나의 단어가 있습니다. `ASF` 는 일반 환경설정 파일로 예약된 키워드입니다. 추가로, 봇 이름은 마침표로 시작할 수 없습니다.(ASF는 이 파일을 내부적으로 무시합니다.) 공백문자를 사용하지 않는 것을 추천하므로 단어 구분자가 필요하면 `_`를 사용할 수 있습니다.

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

`config` 디렉토리는 다음과 같은 모습이 됩니다.

![Structure 2](https://i.imgur.com/crWdjcp.png)

축하합니다! 기본적인 ASF 봇 환경설정을 끝마쳤습니다. 잠시 후에 추가적으로 더 하겠지만, 지금으로선 여기까지만 있으면 됩니다.

---

### ASF 실행

이제 프로그램을 처음 실행할 준비가 되었습니다. Simply double-click `ArchiSteamFarm` binary in ASF directory. You can also start it from the console.

After doing so, assuming you installed all required dependencies in the first step, ASF should launch properly, notice your first bot (if you didn't forget to put generated config in `config` directory), and attempt to log in:

![ASF](https://i.imgur.com/u5hrSFz.png)

If you supplied `SteamLogin` and `SteamPassword` for ASF to use, you'll be asked for your SteamGuard token only (e-mail, 2FA or none, depending on your Steam settings). If you didn't, you'll also be asked for your Steam login and password.

Now would be a good time to review our **[remote communication](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Remote-communication)** section if you're concerned about stuff ASF is programmed to do, including actions it'll take in your name, such as joining our Steam group.

After passing through initial login gate, assuming your details are correct, you'll successfully log in, and ASF will start farming using default settings that you didn't change as of now:

![ASF 2](https://i.imgur.com/Cb7DBl4.png)

This proves that ASF is now successfully doing its job on your account, so you can now minimize the program and do something else. After enough of time (depending on **[performance](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)**), you'll see Steam trading cards slowly being dropped. Of course, for that to happen you must have valid games to farm, showing as "you can get X more card drops from playing this game" on your **[badges page](https://steamcommunity.com/my/badges)** - if there are no games to farm, then ASF will state that there is nothing to do, as stated in our **[FAQ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#what-is-asf)**.

This concludes our very basic setting up guide. You can now decide whether you want to configure ASF further, or let it do its job in default settings. We'll cover a few more basic details, then leave you entire wiki for discovery.

---

### 추가 환경설정

#### Farming several accounts at once

ASF supports farming more than one account at a time, which is its primary function. You can add more accounts to ASF by generating more bot config files, in exactly the same way as you've generated your first one just a few minutes ago. You need to ensure only two things:

- Unique bot name, if you already have your first bot named "MainAccount", you can't have another one with the same name.
- Valid login details, such as `SteamLogin`, `SteamPassword` and `SteamParentalCode` (if using Steam parental settings)

In other words, simply jump to configuration again and do exactly the same, just for your second or third account. Remember to use unique names for all of your bots.

---

#### 설정 변경

You change existing settings in exactly the same way - by generating a new config file. If you didn't close our web config generator yet, click on "toggle advanced settings" and see what is there for you to discover. For this tutorial we'll change `CustomGamePlayedWhileFarming` setting, which allows you to set custom name being displayed when ASF is farming, instead of showing actual game.

So let's do that, if you run ASF and start farming, in default settings you'll see that your Steam account is in-game now:

![Steam](https://i.imgur.com/1VCDrGC.png)

이제 이것을 변경해봅시다. Toggle advanced settings in web config generator and find `CustomGamePlayedWhileFarming`. Once you do that, put your own custom text there that you want to display, such as "Idling cards":

![Bot tab 3](https://i.imgur.com/gHqdEqb.png)

Now download the new config file in exactly the same way, then **overwrite** your old config file with new one. You can also delete your old config file and put new one in its place of course.

Once you do that and start ASF again, you'll notice that ASF now displays your custom text in previous place:

![Steam 2](https://i.imgur.com/vZg0G8P.png)

This confirms that you've successfully edited your config. In exactly the same way you can change global ASF properties, by switching from bot tab to "ASF" tab, downloading generated `ASF.json` config file and putting it in your `config` directory.

Editing your ASF configs can be done much easier by using our ASF-ui frontend, which will be explained further below.

---

#### Using ASF-ui

ASF is a console app and doesn't include a graphical user interface. However, we're actively working on **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)** frontend to our IPC interface, which can be a very decent and user-friendly way to access various ASF features.

In order to use ASF-ui, you need to have `IPC` enabled, which is the default option. Once you launch ASF, you should be able to confirm that it properly started the IPC interface automatically:

![IPC](https://i.imgur.com/ZmkO8pk.png)

You can access ASF's IPC interface under **[this](http://localhost:1242)** link, as long as ASF is running, from the same machine. You can use ASF-ui for various purposes, e.g. editing the config files in-place or sending **[commands](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Feel free to take a look around in order to find out all ASF-ui functionalities.

![ASF-ui](https://raw.githubusercontent.com/JustArchiNET/ASF-ui/main/.github/previews/bots.png)

---

### 요약

You've successfully set up ASF to use your Steam accounts and you've already customized it to your liking a little. If you followed our entire guide, then you also managed to tweak ASF through our ASF-ui interface and found out that ASF actually has a GUI of some sort. Now is a good time to read our entire **[configuration](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** section in order to learn what all those different settings you've seen actually do, and what ASF has to offer. If you've stumbled upon some issue or you have some generic question, read our **[FAQ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ)** instead which should cover all, or at least a vast majority of questions that you may have. If you want to learn everything about ASF and how it can make your life easier, head over to the rest of **[our wiki](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Home)**. If you found out our program to be useful for you and you're feeling generous, you can also consider donating to our project. In any case, have fun!

---

## 일반 설치

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
- **[ASF 환경설정](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-ko-KR)**
- Launch ASF by either using a helper script or executing `dotnet /path/to/ArchiSteamFarm.dll` manually from your favourite shell.

Helper scripts (such as `ArchiSteamFarm.cmd` for Windows and `ArchiSteamFarm.sh` for Linux/macOS) are located next to `ArchiSteamFarm.dll` binary - those are included in `generic` variant only. You can use them if you don't want to execute `dotnet` command manually. Obviously helper scripts won't work if you didn't install .NET SDK and you don't have `dotnet` executable available in your `PATH`. Helper scripts are entirely optional to use, you can always `dotnet /path/to/ArchiSteamFarm.dll` manually.