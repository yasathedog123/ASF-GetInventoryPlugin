# 命令行参数

ASF 支持一些能够影响程序运行时行为的命令行参数。 高级用户可使用这些参数以定义程序应以何种方式运行。 与使用 `ASF.json` 配置文件的默认方式对比，命令行参数可用于核心初始化（如 `--path`）、平台特定设置（如 `--system-required`）或敏感数据（如 `--cryptkey`）。

---

## 用法

用法受您的操作系统及 ASF 包版本的影响而有所变化。

Generic：

```shell
dotnet ArchiSteamFarm.dll --参数 --另一个参数
```

Windows：

```powershell
.\ArchiSteamFarm.exe --参数 --另一个参数
```

Linux/macOS：

```shell
./ArchiSteamFarm --参数 --另一个参数
```

`ArchiSteamFarm.cmd` 或 `ArchiSteamFarm.sh` 的这样的助手脚本也可使用命令行参数。 除此之外，您也可以使用 `ASF_ARGS` 环境变量，如[**管理**](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management-zh-CN#环境变量)和 **[Docker](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Docker-zh-CN#命令行参数)** 两节所示。

若您参数包括空格，请记得要使用引号将其括住。 下面是两个错误示例：

```shell
./ArchiSteamFarm --path /home/archi/My Downloads/ASF # 错！
./ArchiSteamFarm --path=/home/archi/My Downloads/ASF # 错！
```

而下面两个例子完全正确：

```shell
./ArchiSteamFarm --path "/home/archi/My Downloads/ASF" # 正确
./ArchiSteamFarm "--path=/home/archi/My Downloads/ASF" # 正确
```

## 参数

`--cryptkey <key>` 或 `--cryptkey=<key>`——将以值为 `<key>` 的自定义密钥启动 ASF。 此参数影响[**安全性**](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security-zh-CN)且将导致 ASF 使用您所提供的自定义密钥 `<key>` 而非硬编码在程序中的默认密钥。 因为此属性会影响默认加密密钥（用于加密目的）和盐（用于加密目的），请记住，使用此密钥加密/哈希的一切都要求 ASF 每次运行时传入相同的值。

`<key>` 对长度和字符没有要求，但出于安全原因，我们建议选择足够长的口令，例如 32 位随机字符，一种获取方式是在 Linux 上执行 `tr -dc A-Za-z0-9 < /dev/urandom | head -c 32; echo` 命令。

需要指出，还有其他两种方式提供此信息：`--cryptkey-file` 和 `--input-cryptkey`。

由于该属性本身的性质，您也可以设置 `ASF_CRYPTKEY` 环境变量来设置此密钥，这更适合想避免在进程参数中暴露敏感信息的用户。

---

`--cryptkey-file <path>` 或 `--cryptkey-file=<path>`——将从 `<path>` 文件中读取自定义密钥启动 ASF。 这与上文的 `--cryptkey <key>` 效果相同，仅有读取方式不同，此属性的 `<key>` 将会从 `<path>` 文件中读取 。 如果您要与 `--path` 一起使用，请考虑先声明 `--path`，这样相对路径就能正常工作。

由于该属性本身的性质，您也可以设置 `ASF_CRYPTKEY_FILE` 环境变量来设置此密钥文件，这更适合想避免在进程参数中暴露敏感信息的用户。

---

`--ignore-unsupported-environment`——使 ASF 忽略在不支持环境下运行的各种问题，这些环境在正常情况下会导致报错并强制退出。 不支持环境包括在 `linux-x64` 环境运行 `win-x64` 操作系统构建等情况。 此选项将允许 ASF 尝试在这些情况下运行，请注意我们并不支持这些操作，完全是您自己决定强制 ASF 这样运行，因而**风险由您自己承担**。 目前，**所有**在不受支持环境运行的情况都可以被改正。 我们强烈建议从根本上解决问题，而不是使用这参数。

---

`--input-cryptkey`——使 ASF 在启动时询问 `--cryptkey`。 如果您不希望在任何地方保存加密密钥，无论是通过环境变量还是文件，而更愿意每次启动 ASF 时手动输入，则可以使用此选项。

---

`--minimized`——使 ASF 在启动后马上最小化控制台窗口。 主要用于自动启动的场景，但也可能在其他场景下有用。 目前此开关仅对 Windows 设备有效。

---

`--network-group <group>` 或 `--network-group=<group>`——使 ASF 在自定义网络组 `<group>` 内初始化限制。 此选项影响[**多实例**](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management-zh-CN#多实例)运行的 ASF，指定此实例仅与相同网络组的实例共享，与其他实例独立。 通常，只有在您通过自定义机制（例如不同 IP 地址）路由 ASF 请求时才需要使用此选项手动设置网络组，不再依赖 ASF 自动处理（目前仅会考虑 `WebProxy`）。 请注意，在使用自定义网络组时，这是属于本机的唯一标识符，ASF 将不再考虑其他细节，例如 `WebProxy` 的值，这使您可以运行两个 `WebProxy` 不同的实例，但仍然互相影响。

由于该属性本身的性质，您也可以设置 ` ASF_NETWORK_GROUP` 环境变量来设置此值，这更适合想避免在进程参数中暴露敏感信息的用户。

---

`--no-config-migrate`——默认情况下，ASF 会自动将您的配置文件迁移到最新语法。 迁移过程包括将已废弃的属性转换成最新版、删除值为默认的属性（因为无需专门定义），以及清理文件格式（修正缩进等等）。 通常这总是最好的做法，但可能您有特殊的情况，需要 ASF 不自动覆盖配置文件。 例如，您可能希望对配置文件 `chmod 400`（仅所有者可读取）或者 `chattr +i`，禁止任何人写入，以此作为一项安全措施。 通常我们建议启用配置文件迁移，但如果您有特定的禁用理由，不希望 ASF 迁移配置，就可以用此开关达成目的。

---

`--no-config-watch`——默认情况下，ASF 会对您的 `config` 文件夹设置 `FileSystemWatcher` 以监视与文件变更有关的事件，因此才能动态适应这些变化。 例如，在配置文件被删除后停止机器人、配置文件被修改后重启机器人，或者在您向 `config` 文件夹添加游戏序列号之后自动加载到[**后台游戏激活器**](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer)中。 此开关允许您禁用这个行为，使 ASF 完全忽略 `config` 文件夹内的任何变化，您必须在需要时手动执行相关操作（通常意味着重启进程）。 我们建议启用配置文件监听，但如果您有特定的禁用理由，不希望 ASF 监视事件，就可以用此开关达成目的。

---

`--no-restart`——此开关主要用于 **[Docker](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Docker-zh-CN)** 容器并将 `AutoRestart` 强制设置为 `false`。 除非有特殊的需要，否则您应该直接在配置中配置 `AutoRestart` 属性。 这个开关作用是使 Docker 脚本不需要修改您的全局配置来适应它的环境。 当然，如果是在脚本中运行 ASF，您也可以使用此开关（否则您最好使用全局配置属性）。

---

`--no-steam-parental-generation`——ASF 默认会自动尝试生成 Steam 家庭监护 PIN 代码，如 **[`SteamParentalCode`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-zh-CN#steamparentalcode)** 配置属性所述。 然而，因为这可能会需要过多操作系统资源，此开关允许您禁用此行为，这会使 ASF 跳过自动生成，直接向用户询问 PIN 代码，就像正常情况下自动生成失败时一样。 通常我们建议启用自动生成，但如果您有特定的禁用理由，不希望 ASF 自动生成，就可以用此开关达成目的。

---

`--path <path>` 或 `--path=<path>`——ASF 在启动时始终会切换到自身所在的文件夹。 通过指定该参数，ASF 会在初始化完成后切换至给定文件夹，让您可以对应用的各个组件设置自定义路径（包括 `config`、`plugins` 和 `www` 文件夹，以及 `NLog.config` 文件），而无需复制一份相同的二进制文件。 如果您想将二进制文件和实际的配置文件分开，这会非常有用。就像 Linux 打包机制一样——这样您就可以使用一个（最新的）二进制文件搭配多个不同的配置。 此路径既可以是基于 ASF 二进制文件所在位置的相对路径，也可以是绝对路径。 请注意，该命令指向新的“ASF 主文件夹”——与原始的 ASF 具有相同结构的文件夹，其中包含 `config` 文件夹，请查看下文的示例了解详情。

由于该属性本身的性质，您也可以设置 `ASF_PATH` 环境变量来设置此路径，这更适合想避免在进程参数中暴露敏感信息的用户。

如果您考虑使用命令行参数以运行多个 ASF 实例，我们推荐您阅读本指南的[**管理**](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management-zh-CN#多实例)页面。

示例：

```shell
dotnet /opt/ASF/ArchiSteamFarm.dll --path /opt/TargetDirectory # 绝对路径
dotnet /opt/ASF/ArchiSteamFarm.dll --path ../TargetDirectory # 也可以使用相对路径
ASF_PATH=/opt/TargetDirectory dotnet /opt/ASF/ArchiSteamFarm.dll # 或者使用环境变量
```

```text
├── /opt
│     ├── ASF
│     │     ├── ArchiSteamFarm.dll
│     │     └── ...
│     └── TargetDirectory
│           ├── config
│           ├── logs（自动生成）
│           ├── plugins（可选）
│           ├── www（可选）
│           ├── log.txt（自动生成）
│           └── NLog.config（可选）
└── ...
```

---

`--process-required`——默认情况下，ASF 将会在没有机器人运行的情况下关闭，声明此开关将禁用这一行为。 当与 **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-zh-CN)** 配合使用时不自动关闭会非常有用。大部分用户希望在不论有多少机器人启用的情况下他们的网页服务都能够正常运行。 如果您在使用 IPC 或者需要 ASF 进程一直运行直至手动关闭它，这就是您应该使用的选项。

如果您不打算运行 IPC，那么该选项对您来说毫无用处，因为您可以在需要时重新启动进程（与需要始终监听以接受命令的 ASF 网页服务相反）。

---

`--service`——此开关主要用在我们的 `systemd` 服务上，它会强制设置 `Headless` 为 `true`。 除非有特殊的需要，否则您应该直接在配置中配置 `Headless` 属性。 这个开关作用是使 `systemd` 服务不需要修改您的全局配置来适应它的环境。 当然，如果您有类似的需要，也可以使用此开关（否则您最好使用全局配置属性）。

---

`--system-required`——声明这个开关将会导致 ASF 尝试通知操作系统“此进程需要在运行过程中保持系统处于启动状态并正常运行”。 目前，此选项仅对 Windows 设备有效，作用是在 ASF 运行期间阻止系统进入睡眠模式。 当您在夜间使用 PC 或者笔记本电脑挂卡时，这一功能是相当实用的，因为 ASF 将会在挂卡时保持计算机处于唤醒状态，然后，一旦挂卡完成，ASF 就会像平常一样自动退出，使您的操作系统可以随时进入睡眠模式，因此您可以保证挂卡完成时立刻节约电力消耗。

请注意，要正确地自动关闭 ASF，您还需要其他设置——特别是避免 `--process-required` 参数，并且确保所有机器人都已开启 `ShutdownOnFarmingFinished`。 当然，自动退出只是这个参数的用法之一，因为您还可以将此参数配合 `--process-required` 使用，使 ASF 在启动之后无限运行下去。