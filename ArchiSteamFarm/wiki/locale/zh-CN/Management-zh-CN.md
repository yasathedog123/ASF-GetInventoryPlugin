# 管理

本章节涵盖的主题是以最佳方式管理 ASF 进程。 尽管不是强制性的，这里还是包括了我们想要分享的提示、技巧和最佳实践，本章节主要面向系统管理员、第三方源的 ASF 打包者以及高级用户等。

---

## Linux 的 `systemd` 服务

在 `generic` 和 `linux` 两种包中，ASF 自带 `ArchiSteamFarm@.service` 文件，这是一份 **[`systemd`](https://systemd.io)** 的服务配置文件。 如果您要以服务形式运行 ASF，例如为了在系统启动时自动运行，那么正确的 `systemd` 服务就是最合适的实现方式，因此我们强烈推荐使用服务而不是通过 `nohup`、`screen` 等方式手动管理。

首先，创建用来运行 ASF 的用户，假设它还不存在。 我们在此以 `asf` 用户为例，如果您决定用另一个用户，就需要在下面所有示例中把 `asf` 替换为您选择的用户名。 我们的服务不允许 ASF 以 `root` 用户运行，因为这被认为是&#8203;**[错误实践](#不要以管理员身份运行-ASF)**。

```sh
su # 或 sudo -i，用来进入 root shell
useradd -m asf # 创建您要用来运行 ASF 的用户
```

接下来，解压 ASF 到 `/home/asf/ArchiSteamFarm` 目录。 目录结构对于我们的服务单元非常重要，它应该是您 `$HOME` 目录，也就是 `/home/<user>` 下的 `ArchiSteamFarm` 目录。 如果您的操作完全正确，则现在应该存在 `/home/asf/ArchiSteamFarm/ArchiSteamFarm@.service` 文件。 如果您正在使用 `linux` 版本，但文件不是在 Linux 环境中解压的，而是传输自 Windows 系统等情况，则您也需要执行 `chmod +x /home/asf/ArchiSteamFarm/ArchiSteamFarm` 设置权限。

我们接下来会用 `root` 用户操作，所以首先要通过 `su` 或 `sudo -i` 命令获取 Shell。

我们最好先确认一下我们的目录仍然属于 `asf` 用户，也就是执行一次 `chown -hR asf:asf /home/asf/ArchiSteamFarm` 命令。 因为如果您是以 `root` 用户下载或解压 zip 文件，权限可能是错误的。

然后，如果您正在使用 ASF 的 Generic 版本，您还需要确认 `dotnet` 命令可以被识别到，并且在下列标准路径之一：`/usr/local/bin`、`/usr/bin` 或 `/bin`。 这是我们执行 `dotnet /path/to/ArchiSteamFarm.dll` 命令的 systemd 服务所必需的条件。 您需要检查 `dotnet --info` 是否正常，如果正常，则输入 `command -v dotnet` 命令获取它的位置。 如果您使用的是官方安装器，它应该在 `/usr/bin/dotnet` 或者另外两个位置，这不会有问题。 如果它在自定义位置，例如 `/usr/share/dotnet/dotnet`，则需要使用 `ln -s "$(command -v dotnet)" /usr/bin/dotnet` 命令创建一个符号链接。 现在 `command -v dotnet` 命令应该也输出 `/usr/bin/dotnet` 了，这能让我们的 systemd 单元正常工作。 如果您使用的是特定操作系统的版本，则不需要进行本段落的任何操作。

接下来，`cd /etc/systemd/system` 并执行 `ln -s /home/asf/ArchiSteamFarm/ArchiSteamFarm\@.service .`，这会为服务定义文件创建一个符号链接，并将它注册给 `systemd`。 使用符号链接是为了让 ASF 能在更新时自动更新您的 `systemd` 单元——取决于您的情况，您可能希望这样做，如果不希望，也可以直接使用 `cp` 命令复制文件并自行管理。

然后，确保 `systemd` 能够识别我们的服务：

```
systemctl status ArchiSteamFarm@asf

○ ArchiSteamFarm@asf.service - ArchiSteamFarm Service (on asf)
     Loaded: loaded (/etc/systemd/system/ArchiSteamFarm@.service; disabled; vendor preset: enabled)
     Active: inactive (dead)
       Docs: https://github.com/JustArchiNET/ArchiSteamFarm/wiki
```

请特别注意我们在 `@` 后面声明的用户，在我们的示例中是 `asf`。 我们的 systemd 服务单元期望您声明用户，因为这会影响 `/home/<user>/ArchiSteamFarm` 二进制文件的实际位置，以及 systemd 用于生成进程的实际用户。

如果 systemd 返回的输出与上面的情况类似，那么一切正常，我们马上就完成了。 现在剩下的操作就是以我们选择的用户实际启动服务：`systemctl start ArchiSteamFarm@asf`。 等待一两秒钟，您就可以再次检查状态：

```
systemctl status ArchiSteamFarm@asf

● ArchiSteamFarm@asf.service - ArchiSteamFarm Service (on asf)
     Loaded: loaded (/etc/systemd/system/ArchiSteamFarm@.service; disabled; vendor preset: enabled)
     Active: active (running) since (...)
       Docs: https://github.com/JustArchiNET/ArchiSteamFarm/wiki
   Main PID: (...)
(...)
```

如果 `systemd` 的状态是 `active (running)`，意味着一切正常，并且您可以通过执行命令 `journalctl -r` 等方式来验证 ASF 已经启动并运行，因为 ASF 默认会输出到控制台，并被 `systemd` 记录下来。 如果您满意现在的设置，就可以执行 `systemctl enable ArchiSteamFarm@asf` 命令，告诉 `systemd` 在系统启动时自动启动服务。 一切完成。

如果您想停止进程，只需要执行 `systemctl stop ArchiSteamFarm@asf`。 类似地，如果您想要禁止 ASF 在系统启动时运行，就执行 `systemctl disable ArchiSteamFarm@asf`，非常简单。

请注意，由于我们的 `systemd` 服务没有启用标准输入，您无法以常规方式通过控制台输入信息。 通过 `systemd` 运行与指定 **[`Headless: true`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-zh-CN#headless)** 设置运行是等效的。 如果您需要在登录时输入详细信息，或者需要更好地管理 ASF 进程，我们推荐您使用 **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-zh-CN#asf-ui)**，可以方便地管理您的 ASF。

### 环境变量

`systemd` 服务允许提供额外的环境变量，例如您希望使用自定义的 `--cryptkey` **[命令行参数](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments-zh-CN#参数)**，就需要指定 `ASF_CRYPTKEY` 环境变量。

若要提供自定义环境变量，则运行命令 `mkdir -p /etc/asf` 创建 `/etc/asf` 目录（如果不存在）。 我们建议运行 `chown -hR root:root /etc/asf && chmod 700 /etc/asf`，确保只有 `root` 用户有权限读取这些文件，因为其中可能包含 `ASF_CRYPTKEY` 等敏感属性。 然后，您可以编辑 `/etc/asf/<user>` 文件，其中 `<user>` 表示您运行服务的用户（在本例中是 `asf`，即编辑 `/etc/asf/asf`）。

此文件应该包含所有您要提供给进程的环境变量。 一些参数没有专门的环境变量，但可以通过 `ASF_ARGS` 来声明：

```sh
# 仅声明您实际需要的变量
ASF_ARGS="--no-config-migrate --no-config-watch"
ASF_CRYPTKEY="my_super_important_secret_cryptkey"
ASF_NETWORK_GROUP="my_network_group"

# 以及任何其他您要使用的变量
```

### 覆盖服务单元的部分配置

得益于 `systemd` 的灵活性，我们可以覆盖 ASF 单元的一部分，同时仍然保留原始单元文件，允许 ASF 在自动更新时将其一并更新。

在本示例中，我们要修改默认的 ASF `systemd` 单元的行为，将“仅在成功退出时重启服务”修改为“致命崩溃时也重启服务”。 要做到这一点，我们会覆盖 `[Service]` 下的 `Restart` 属性，将 `on-success` 改为 `always`。 只需执行 `systemctl edit ArchiSteamFarm@asf`，注意将 `asf` 替换为您服务实际使用的目标用户。 然后在正确的 `systemd` 分段中添加您的修改：

```sh
### 编辑 /etc/systemd/system/ArchiSteamFarm@asf.service.d/override.conf
### 此处与下面注释之间的所有内容都会被添加到文件中

[Service]
Restart=always

### 此行注释后的内容会被丢弃

### /etc/systemd/system/ArchiSteamFarm@asf.service
# [Install]
# WantedBy=multi-user.target
# 
# [Service]
# EnvironmentFile=-/etc/asf/%i
# ExecStart=dotnet /home/%i/ArchiSteamFarm/ArchiSteamFarm.dll --no-restart --process-required --service --system-required
# Restart=on-success
# RestartSec=1s
# SyslogIdentifier=asf-%i
# User=%i
# (...)
```

这就完成了，现在您的单元行为等同于只在 `[Service]` 下修改了 `Restart=always`。

当然，您也可以 `cp` 单元文件并自己手动管理，但覆盖的方法让您能做到更灵活的修改，同时仍然保留原始的或符号链接过的 ASF 单元文件。

---

## 不要以管理员身份运行 ASF！

ASF 有自己的逻辑，验证自身是否以管理员用户（`root`）运行。 只要环境配置正确，ASF 进程的任何操作都**不**需要 root 权限，因此以 root 用户运行算是一种**错误实践**。 这意味着在 Windows 上，ASF 永远不应该“以管理员身份运行”，而在 Unix 上，ASF 应该以专门的用户帐户运行，或者在桌面环境下使用您自己的帐户。

若要进一步了解我们*为什么*不鼓励以 root 权限运行 ASF，请阅读 **[SuperUser](https://superuser.com/questions/218379/why-is-it-bad-to-run-as-root)** 或其他资料。 如果您仍然不相信，请想象一下，如果 ASF 在启动后自动执行 `rm -rf /*` 命令会发生什么。

### 我用 `root` 运行是因为 ASF 无法写入自己的文件

这意味着您为 ASF 需要访问的文件配置了错误的权限。 您应该以 `root` 帐户登录（通过 `su` 或 `sudo -i` 命令），然后执行 `chown -hR asf:asf /path/to/ASF` 命令来**修正**权限，您需要将命令中的 `asf:asf` 替换为实际运行 ASF 的用户，并且将 `/path/to/ASF` 替换为 ASF 的实际路径。 如果您正在使用自定义的 `--path` 参数让 ASF 用户使用不同的目录，您还应该为这个路径再执行一次上述命令。

这样做之后，您应该不会再遇到任何类似“ASF 无法写入自己的文件”的问题，因为您刚刚将 ASF 所需文件的所有者修改为实际运行 ASF 的用户。

### 我用 `root` 运行是因为我不知道应该怎样做

```sh
su # 或 sudo -i，用来进入 root shell
useradd -m asf # 创建您要用来运行 ASF 的用户
chown -hR asf:asf /path/to/ASF # 确保新用户有权访问 ASF 目录
su asf -c /path/to/ASF/ArchiSteamFarm # 或 sudo -u asf /path/to/ASF/ArchiSteamFarm，用来在指定用户下启动程序
```

这些步骤会手动启动 ASF，但使用我们上述的 [**`systemd` 服务**](#linux-的-systemd-服务)会更容易。

### 我比你们更明白，我仍然想要以 `root` 用户运行

ASF 不会强行阻止您这样做，而是仅仅显示一条简短的警告。 但是，如果有一天本程序的漏洞导致您的整个操作系统崩溃掉，并且丢失所有数据——不要说我们没有警告过您。

---

## 多实例

ASF 兼容在同一台机器上运行多个进程实例。 实例可以是完全独立的，或是派生于同一个二进制文件（如果您需要它们在不同路径下运行，可以使用 `--path` **[命令行参数](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments)**）。

请注意，在通常情况下，当使用同一份二进制文件运行不同实例时应该在所有实例的配置文件内禁用自动更新，因为它们之间不会同步与自动更新有关的信息。 如果您仍希望启用自动更新，我们建议您使用独立的实例，但只要您能确保所有其他 ASF 实例已关闭，自动更新就仍然可以正常工作。

ASF 会尽全力减少操作系统层面的与其他 ASF 实例的跨进程通信。 这包括 ASF 会读取其他实例的配置文件目录，并且共享由 `*LimiterDelay` [**全局配置属性**](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#global-config)配置的进程级限制，确保运行多个 ASF 实例不会导致频率限制问题。 在技术方面，所有平台都使用我们专门的 ASF 自定义机制，在临时目录内创建基于文件的锁，Windows 上的临时目录为 `C:\Users\<您的用户名>\AppData\Local\Temp\ASF`，在 Unix 上则是 `/tmp/ASF`。

运行多个 ASF 实例不需要它们共享相同的 `*LimiterDelay` 属性，它们可以设置不同的值，因为每个 ASF 都会在获得锁之后将自己配置的延迟添加到释放时间。 如果配置的 `*LimiterDelay` 设置为 `0`，ASF 实例将完全跳过等待其他实例释放资源的锁（它们之间可能仍然会维护一个共享锁）。 当设置为其他任何值时，ASF 将会与其他实例同步此值，并等待自己获得锁，然后会在预先配置的延迟时间之后释放锁，使其他实例继续工作。

ASF 在决定共享范围时会考虑到 `WebProxy` 设置，即使用不同 `WebProxy` 的 ASF 实例之间不会采用同一个限制。 实现此功能是为了让 `WebProxy` 设置不会导致过大的操作延迟，符合使用不同网络接口的预期。 对于大多数情况，这应该足够了，然而，如果您的方案使用自定义的机制，例如使用其他方式手动路由请求，您可以通过 `--network-group` [**命令行参数**](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments-zh-CN)指定网络组，使您指定 ASF 需要与同一个组内的实例同步。 请注意，设置自定义网络组选项后，ASF 就不再根据 `WebProxy` 判断所需的组，因为此时由您自己管理分组。

如果您希望利用上文所述的 [**`systemd 服务`**](#linux-的-systemd-服务) 实现 ASF 多实例，也非常简单，只需要在我们声明 `ArchiSteamFarm@` 服务时使用另一个用户，随后的步骤都完全相同。 这与分别运行多个不同 ASF 二进制文件是等价的，所以它们也可以正常自动更新，而操作互不干扰。