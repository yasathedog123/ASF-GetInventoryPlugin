# 安装指南

如果您是第一次访问这里，欢迎！ 我们很高兴看到又一名旅客对我们的项目感兴趣，但能力越大，责任越大——只要您**愿意学习如何使用**，ASF 就有能力做很多与 Steam 有关的事情。 这里的学习曲线很陡峭，我们希望您阅读相关内容的 Wiki，其中解释了这一切究竟是如何运作的。

如果您还没有关闭这个页面，那就意味着您愿意继续学习，非常好。 除非您打算跳过这个过程，那样您将会很快遇到一段&#8203;**[痛苦的经历](https://www.youtube.com/watch?v=WJgt6m6njVw)**…… 无论如何，ASF 是一个控制台应用程序，这意味着，至少在一开始，它没有提供一个您熟悉的友好 GUI 界面。 ASF 主要应该在服务器上运行，所以它更像是一个服务（守护进程）而不是一个桌面应用。

但这并不意味着您不能在自己的 PC 上运行它，或者这会比通常的使用方式更复杂。 ASF 是一个独立的程序，无需安装过程，开箱即用，但在它可用之前需要有一个配置的过程。 配置是指在运行 ASF 之前告诉它之后应该怎样做。 如果您没有配置就运行 ASF，它就会什么也不做。

---

## 安装操作系统包

通常，我们只需要花费几分钟进行下列操作：
- 安装 **[.NET 依赖项](#net-依赖)**。
- 在 &#8203;**[ASF 发布页面](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)**&#8203;下载适合您操作系统的包。
- 将压缩包解压到一个新文件夹。
- **[配置 ASF](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-zh-CN)**。
- 运行并开始使用 ASF。

看起来很简单吧？ 现在我们开始逐项进行。

---

### .NET 依赖

第一步是确保您的操作系统至少能够正常运行 ASF。 ASF 是以 C# 编写的，基于 .NET 框架，并且可能依赖于一些您的平台尚未支持的本机库。 取决于您使用 Windows、Linux 还是 macOS，您将需要满足不同的要求，但所有要求都写在了您需要阅读的 [**.NET 依赖**](https://docs.microsoft.com/dotnet/core/install)文档中。 这是我们应该使用的参考材料，但为了简单起见，我们也在下文列出了所需的一切，这样您就不需要去阅读完整的文档。

由于您安装的第三方软件，有可能您的操作系统已经满足了一部分（甚至所有）依赖项，这是很正常的。 不过，您还是应该在操作系统上运行这些依赖项的安装程序来确保它们确实被安装了——如果缺少这些依赖项，ASF 将完全无法启动。

请注意，您不需要为特定操作系统包进行其他准备工作，特别是安装 .NET SDK 或者运行时环境，因为操作系统包中已包含了它们。 您只需要安装 .NET 依赖项，使 ASF 自带的 .NET 运行时环境能够运行。

#### **[Windows](https://docs.microsoft.com/dotnet/core/install/windows)**：
- **[Microsoft Visual C++ Redistributable Update](https://docs.microsoft.com/cpp/windows/latest-supported-vc-redist?view=msvc-170#visual-studio-2015-2017-2019-and-2022)**（64 位 Windows 为 **[x64](https://aka.ms/vs/17/release/vc_redist.x64.exe)**，32 位 Windows 为 **[x86](https://aka.ms/vs/17/release/vc_redist.x86.exe)**）。
- 强烈建议您确保已安装所有 Windows 更新。 您至少需要 **[KB2533623](https://support.microsoft.com/zh-cn/help/2533623/microsoft-security-advisory-insecure-library-loading-could-allow-remot)** 和 **[KB2999226](https://support.microsoft.com/zh-cn/help/2999226/update-for-universal-c-runtime-in-windows)**，但有可能还需要更多。 如果您的 Windows 已更新到最新，这些更新应该都已安装。 确保您在安装 Visual C++ 包之前满足这些要求。

#### **[Linux](https://docs.microsoft.com/dotnet/core/install/linux)**：
根据您所使用的 Linux 发行版的不同，包名可能有所区别，我们会列出最常见的包名。 您可以使用系统自带的包管理器（例如 Debian 的 `apt` 或 CentOS 的 `yum`）来安装这些包。

- `ca-certificates`（标准可信 SSL 证书，用于 HTTPS 连接）
- `libc6`（`libc`）
- `libgcc1`（`libgcc`）
- `libicu`（`icu-libs`，您的发行版上的最新版，例如 `libicu67`）
- `libgssapi-krb5-2`（`libkrb5-3`、`krb5-libs`）
- `libssl1.1`（`libssl`、`openssl-libs`，或您的发行版上的最新版本，并且至少应为 `1.1.X`，因为 `1.0.X` 版本可能无法工作）
- `libstdc++6`（`libstdc++`，`5.0` 或更高版本）
- `zlib1g`（`zlib`）

其中的大多数项目应该已经安装在您的系统中了。 Debian 稳定版的最小化安装流程仅需要您再手动安装 `libicu67`。

#### **[macOS](https://docs.microsoft.com/dotnet/core/install/macos)**：
- 目前没有，但您应该安装最新版本的 macOS，至少应为 10.15+

---

### 下载

我们已经满足了所有需要的依赖项，下一步就是在 **[ASF 发布页面](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)**&#8203;下载最新版本。 ASF 提供多种不同版本的包，但您需要找到符合您的操作系统和架构的版本。 例如，假如您正在使用 `64` 位的 `Win`dows，就需要下载 `ASF-win-x64` 包。 请阅读&#8203;**[兼容性](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility-zh-CN)**&#8203;章节了解关于不同操作系统版本的详情。 ASF 也可以运行在我们尚未提供官方版本的操作系统上，例如 **32 位 Windows**，请参考&#8203;**[安装 Generic 包](#安装-generic-包)**。

![Assets](https://i.imgur.com/Ym2xPE5.png)

下载之后，首先将 zip 文件解压到一个文件夹中。 如果您不知道该用什么工具，可以使用 **[7-zip](https://www.7-zip.org)**，但 Linux/macOS 提供的 `unzip` 等标准工具也应该没有任何问题。

您应该将 ASF 解压到一个**独立的文件夹**中，而不是已有文件的文件夹——ASF 会在自动更新时删除文件夹中任何过时或无关的文件，您在 ASF 文件夹中存放的其他文件可能会因此丢失。 如果您需要一些与 ASF 相关的额外脚本或文件，请将它们放到上层文件夹。

这是一个文件夹结构的示例：

```text
C:\ASF (放置您自己与 ASF 相关的东西)
    ├── ASF shortcut.lnk (可选)
    ├── Config shortcut.lnk (可选)
    ├── Commands.txt (可选)
    ├── MyExtraScript.bat (可选)
    ├── (...) (任何您选择放在这里的其他文件，可选)
    └── Core (ASF 自身专用文件夹，也就是您解压压缩包的地方)
         ├── ArchiSteamFarm(.exe)
         ├── config
         ├── logs
         ├── plugins
         └── (...)
```

---

### 配置

现在我们只剩下最后一步，也就是配置。 这是到目前为止最复杂的一步，因为这涉及到很多您尚不了解的新信息，所以我们会尝试在这里提供一些容易理解的示例和简化的解释。

首先，**[配置](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-zh-CN)**&#8203;页面解释了关于配置 ASF 的**一切**，但是其中的选项太多了，我们现在不需要马上全部理解。 但我们会告诉您如何找到您想要了解的信息。

您可以通过至少三种方式配置 ASF——通过在线配置文件生成器、ASF-ui 或者手动配置。 这已经在&#8203;**[配置](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-zh-CN)**&#8203;章节中进行了深入解释，所以如果您想了解详情可以前往阅读。 我们此处会以在线配置文件生成器为例。

使用您常用的浏览器访问我们的&#8203;**[在线配置文件生成器](https://justarchinet.github.io/ASF-WebConfigGenerator)**&#8203;页面，如果您禁用了浏览器的 Javascript 功能，则需要启用它。 我们建议您使用 Chrome 或者 Firefox，但大多数现代浏览器应该都没有问题。

打开这个页面后，切换到“机器人”标签。 您应该会看到类似下图的界面：

![Bot tab](https://i.imgur.com/aF3k8Rg.png)

如果您刚刚下载的 ASF 版本早于配置文件生成器的默认版本，只需要在下拉菜单中选择您的 ASF 版本。 发生这种情况的原因是，配置文件生成器会支持尚未成为稳定版本的预览版 ASF。 您下载的最新稳定版 ASF 已经过验证，可以正常工作。

第一步是在红色高亮的文本框内填写机器人的名称。 您可以随意指定机器人的名字，例如您的昵称、用户名、一个数字或者任何其他内容。 只有一个词是您不能用的，`ASF`，这是为全局配置文件保留的关键字。 除此之外，您的机器人名称不能以一个点号开头（ASF 会忽略这些文件）。 我们还建议您避免使用空格，如果需要，可以使用下划线 `_` 作为单词之间的分隔符。

在填好名称之后，启用 `Enabled` 开关，这个选项定义了您的机器人是否会在 ASF 程序启动之后自动运行。

现在，您需要作出一个选择：
- 您可以在 `SteamLogin` 文本框中填写帐户的用户名，并在 `SteamPassword` 文本框中填写密码
- 或者将这两个值留空

如果选择第一项，ASF 将会在启动时自动使用您的帐户凭据，这样您就不需要每次都手动输入。 但如果您选择留空，这两项就不会被保存，ASF 就无法在启动时自动登录，您必须在运行时输入凭据。

ASF 需要您的帐户凭据，因为它包含自己的 Steam 客户端实现，需要与官方客户端相同的信息来登录。 您的登录凭据只会被保存在 ASF 的 `config` 文件夹中，我们的在线配置文件生成器是基于客户端的程序，这意味着生成 ASF 配置文件的代码在您的浏览器中本地运行，您输入的信息不会被发送到任何其他设备，因此您无需担心会发生敏感数据泄露。 不过，如果您出于任何原因，不希望在此处填写帐户凭据，我们很理解，您可以手动将它们填入生成好的配置文件中，或者完全省略这些属性，仅在 ASF 命令提示符中输入它们。 更多相关的安全性问题可以在&#8203;**[配置](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-zh-CN)**&#8203;章节中找到。

您也可以将其中一项留空，例如 `SteamPassword`，ASF 仍然会尝试自动登录，但会向您询问密码（与官方客户端类似）。 如果您启用了 Steam 家庭监护，则需要将解锁代码填入 `SteamParentalCode`。

在上述操作都完成后，您的网页页面看起来会类似于下图：

![Bot tab 2](https://i.imgur.com/yf54Ouc.png)

现在您可以点击“下载”按钮，配置文件生成器将会根据您输入的名称生成新的 `json` 文件。 将该文件保存到 `config` 文件夹，该文件夹位于您在上一步中解压 zip 文件得到的文件夹中。

您的 `config` 文件夹现在看起来类似：

![Structure 2](https://i.imgur.com/crWdjcp.png)

恭喜您！ 您刚刚完成了最基本的 ASF 机器人配置。 我们会在之后对此进行扩展，但现在这就是您需要的一切。

---

### 运行 ASF

现在您已准备好首次运行 ASF。 只需要双击 ASF 文件夹内的 `ArchiSteamFarm` 可执行文件。 您也可以在控制台中启动。

之后，假设您已经在一开始安装了所有必须的依赖项，ASF 将会正常启动，如果您没有忘记将生成的配置文件放入 `config` 文件夹，就可以看到 ASF 正在尝试登录您的第一个机器人：

![ASF](https://i.imgur.com/u5hrSFz.png)

如果您之前已经填好了 `SteamLogin` 和 `SteamPassword`，ASF 就只会向您询问 Steam 令牌代码（电子邮件、手机验证器或者无令牌，取决于您的 Steam 设置）。 如果没有填写，ASF 就会向您询问 Steam 用户名和密码。

如果担心 ASF 接下来的行为，包括以您的身份执行哪些操作，例如加入我们的 Steam 组，现在您可以审查我们的[**远程通信**](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Remote-communication-zh-CN)章节。

假设填写的信息全部正确无误，您将会成功登录，ASF 将会以默认设置开始挂卡：

![ASF 2](https://i.imgur.com/Cb7DBl4.png)

这意味着 ASF 此时已经在您的帐户上正常运作，您可以将这个窗口最小化去做其他事。 经过足够的时间之后（取决于&#8203;**[性能](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance-zh-CN)**），您将会看到 Steam 卡牌逐渐掉落。 当然，要做到这一点，您必须有可以挂卡的游戏，您可以在您的&#8203;**[徽章页面](https://steamcommunity.com/my/badges)**&#8203;上看到这些游戏会标注“X 张剩余卡牌掉落”——如果没有可挂卡的游戏，ASF 就会无事可做，如&#8203;**[常见问题](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ-zh-CN#什么是-asf)**&#8203;中所述。

这就是我们最基本的安装指南。 现在您可以决定是进一步配置 ASF，还是让它以默认设置运行。 我们将会介绍另一些基本配置，但要了解完整的配置选项，您需要继续阅读 Wiki 的其他页面。

---

### 进一步配置

#### 同时挂多个帐户

ASF 支持同时挂多个帐户，这也是它的主要功能之一。 您可以通过生成更多机器人配置文件来向 ASF 添加更多帐户，其方法与您之前生成第一个机器人配置完全相同。 您只需要确保两件事：

- 机器人的名称是唯一的，如果您将第一个机器人命名为“MainAccount”，其他的机器人就不能再叫这个名字。
- 登录信息正确，包括 `SteamLogin`、 `SteamPassword` 和 `SteamParentalCode`（如果您启用了 Steam 家庭监护）。

换句话说，要添加其他帐户，只需要配置部分从头开始，进行同样的操作。 并且不能忘记每个机器人的名称应该是唯一的。

---

#### 更改设置

更改已有设置的方法是完全一样的——生成一个新的配置文件。 如果您尚未关闭配置文件生成器，您可以点击“切换高级设置”按钮，查看其他的配置选项。 在本教程中，我们会更改 `CustomGamePlayedWhileFarming` 选项，这个选项可以设置 ASF 挂卡时显示的自定义名称，而不是显示实际的游戏名。

我们现在开始，如果您运行了 ASF 并且开始挂卡，在默认情况下您将会看到您的 Steam 帐户正在游戏中：

![Steam](https://i.imgur.com/1VCDrGC.png)

我们可以改变它。 在配置文件生成器中启用高级设置，找到 `CustomGamePlayedWhileFarming`。 找到之后，在这里填写您想要显示的文本，例如“Idling cards”（挂卡中）。

![Bot tab 3](https://i.imgur.com/gHqdEqb.png)

现在，像之前一样下载新的配置文件，然后**覆盖**旧的配置文件。 当然，您也可以先删除旧配置文件，再将新配置文件放到原来的地方。

完成之后，重新启动 ASF，您会看到 ASF 将会在之前的地方显示您的自定义文本：

![Steam 2](https://i.imgur.com/vZg0G8P.png)

这证明您已经成功更改了配置文件。 您也可以用同样的方式更改全局 ASF 属性，只需要切换到“ASF”标签，下载生成的 `ASF.json` 配置文件，将其放到 `config` 文件夹内。

通过我们的 ASF-ui 前端，编辑 ASF 配置文件会更容易，我们将随后解释。

---

#### 使用 ASF-ui

ASF 是一个控制台应用程序，没有图形用户界面。 然而，我们正在积极开发 IPC 接口的前端 **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-zh-CN#asf-ui)**，它是访问各种 ASF 功能的一种非常简便的、适合用户的方式。

要使用 ASF-ui，您需要启用 `IPC`，自 V5.1.0.0 版本开始，ASF 已经默认启用。 运行 ASF 后，您应该能看到表明 IPC 接口成功启动的确认消息：

![IPC](https://i.imgur.com/ZmkO8pk.png)

只要 ASF 还在运行，您就可以在同一台机器上，通过&#8203;**[这个链接](http://localhost:1242)**&#8203;访问 ASF 的 IPC 接口。 您可以使用 ASF-ui 进行各种操作，例如直接编辑配置文件或发送&#8203;**[命令](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-zh-CN)**。 您可以随意浏览一下，了解 ASF-ui 的所有功能。

![ASF-ui](https://raw.githubusercontent.com/JustArchiNET/ASF-ui/main/.github/previews/bots.png)

---

### 总结

您已经成功设置好了 ASF，让它管理您的 Steam 帐户，并且您也根据个人喜好对其进行了一定程度的定制。 如果您完整阅读了我们的指南，就应该已经成功通过 ASF-ui 接口调整 ASF 的设置，并且发现 ASF 实际上拥有某种 GUI 界面。 现在您可以阅读完整的&#8203;**[配置](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-zh-CN)**&#8203;章节，了解您之前所见的不同选项究竟有何作用，以及 ASF 有哪些功能。 如果您遇到了问题，或者有任何疑问，可以阅读&#8203;**[常见问题](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ-zh-CN)**，其中涵盖了所有，或至少是绝大多数您想要问的问题。 如果您希望了解 ASF 的一切以及 ASF 如何为您提供帮助，请继续阅读我们的 **[Wiki](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Home-zh-CN)**。 如果您认为我们的程序很有用，并且您愿意慷慨解囊，也可以考虑捐赠此项目。 无论如何，祝您愉快！

---

## 安装 Generic 包

这一节是为想要使用 ASF **[Generic](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility-zh-CN#generic)** 包的高级用户准备的。 虽然使用起来比[**操作系统包**](#安装操作系统包)更麻烦，但这也有额外的好处

您可能会在以下几种情况选择使用 `generic` 包（当然，没有理由也可以）：
- 我们没有为您所使用的操作系统（例如 32 位 Windows）提供操作系统包
- 您已经安装了 .NET 运行时环境/SDK，或者打算安装
- 您希望自行管理运行时需求来最小化 ASF 的结构和内存占用
- 您想要使用的自定义&#8203;**[插件](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins-zh-CN)**&#8203;需要 `generic` 版本的 ASF 才能正常工作（因为缺少本机依赖项）

但是，请注意，此时您需要负责安装管理 .NET 运行时环境。 这意味着，如果您的 .NET SDK（运行时环境）不可用、已过期或者已损坏，ASF 就无法工作。 这就是我们不建议普通用户安装此包的原因，因为现在您需要确保 .NET SDK（运行时环境）符合 ASF 的要求，能够用于运行 ASF，而不是使用**我们**验证过的 ASF 自带的 .NET 运行时环境。

对于 `generic` 包，您需要参考上述的操作系统包的安装指南，但有两点小小的区别。 除了要安装 .NET 依赖项之外，您还需要安装 .NET SDK，并且 `ArchiSteamFarm.dll` 二进制文件将会取代操作系统特定的 `ArchiSteamFarm(.exe)` 可执行文件， 其他的步骤都是相同的。

添加额外的步骤之后：
- 安装 **[.NET 依赖项](#net-依赖)**。
- 安装适合您操作系统的 **[.NET SDK](https://www.microsoft.com/net/download)**（或至少安装 ASP.NET Core 运行时环境）。 您可能需要使用一个安装器。 如果您不确定应该安装哪个版本，请参考&#8203;**[运行时环境需求](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility-zh-CN#运行时环境需求)**。
- 在 **[ASF 发布页面](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)**&#8203;下载 `generic` 包。
- 将压缩包解压到一个新文件夹。
- **[配置 ASF](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-zh-CN)**。
- 使用助手脚本或者在 shell 中执行 `dotnet /path/to/ArchiSteamFarm.dll` 启动 ASF。

助手脚本（用于 Windows 的 `ArchiSteamFarm.cmd` 和用于 Linux/macOS 的 `ArchiSteamFarm.sh`）与 `ArchiSteamFarm.dll` 二进制文件处于同一个位置——这些文件都是 `generic` 包特有的。 如果您不想手动执行 `dotnet` 命令，就可以使用这些助手脚本。 显然，如果您没有安装 .NET SDK，或者 `dotnet` 可执行文件不在系统的 `PATH` 环境变量中，助手脚本也无法运行。 助手脚本是完全可选的，您随时可以手动执行 `dotnet /path/to/ArchiSteamFarm.dll` 命令来启动 ASF。