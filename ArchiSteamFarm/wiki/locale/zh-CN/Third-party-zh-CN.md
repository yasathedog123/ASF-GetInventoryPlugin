# 第三方项目

本章节包括专门或主要与 ASF 搭配使用的各种第三方项目。 其中有 ASF 插件、简单的 Web 应用程序、用于集成的内部库还有适用于各种平台的全功能机器人。 如果您希望向这个列表添加一些项目，请在 Discord 或 Steam 群组上联系我们。

请注意，这些程序**并非**由 ASF 开发者维护，因此**我们不会对此作出任何保证**，特别是在安全性和 Steam 服务条款方面。 此列表仅供参考。 您应始终确保您要使用的第三方工具对您来说足够安全与合法，因为您需要自行承担使用它们的风险。

---

## ASF 插件

### **[Rudokhvist](https://github.com/Rudokhvist)**

- **[ASF-Achievement-Manager](https://github.com/Rudokhvist/ASF-Achievement-Manager)**，使您可以通过 ASF 管理 Steam 成就的插件。
- **[BirthdayPlugin](https://github.com/Rudokhvist/BirthdayPlugin)**，通过 ASF 接收生日祝贺的插件。
- **[BoosterCreator](https://github.com/Rudokhvist/BoosterCreator)**，使 ASF 能够制作补充包的插件。
- **[Case-Insensitive-ASF](https://github.com/Rudokhvist/Case-Insensitive-ASF)**，使 ASF 机器人名称不区分大小写的插件。
- **[Commandless-Redeem](https://github.com/Rudokhvist/Commandless-Redeem)**，重新实现免命令序列号激活功能的 ASF 插件。
- **[ItemDispenser](https://github.com/Rudokhvist/ItemDispenser)**，使 ASF 自动接受特定类型物品的交易请求的插件。
- **[Selective-Loot-and-Transfer-Plugin](https://github.com/Rudokhvist/Selective-Loot-and-Transfer-Plugin)**，为 ASF 提供用于转移 Steam 物品的高级 `transfer` 命令。

### **[Vita](https://github.com/ezhevita)**

- **[FriendAccepter](https://github.com/ezhevita/FriendAccepter)**，使 ASF 自动接受所有好友请求的插件。
- **[GameRemover](https://github.com/ezhevita/GameRemover)**，为 ASF 添加一个命令，可以为指定的机器人移除 Steam 许可证。
- **[GetEmail](https://github.com/ezhevita/GetEmail)**，为 ASF 添加一个命令，直接从 Steam 获取指定机器人的 Email 地址。
- **[ResetAPIKey](https://github.com/ezhevita/ResetAPIKey)**，为 ASF 添加一个命令，重置指定机器人的 API 密钥。
- **[SteamKitProxyInjection](https://github.com/ezhevita/SteamKitProxyInjection)**，允许 ASF 代理 WebSocket 连接的插件。

### 其他

- **[ASFEnhance](https://github.com/chr233/ASFEnhance)**，ASF 增强插件，包含各种新功能和新命令。

---

## 集成

- **[ASFBot](https://github.com/dmcallejo/ASFBot)**，用 Python 编写的，集成 ASF 功能的 Telegram 机器人。
- **[ASF STM 用户脚本](https://greasyfork.org/zh-CN/scripts/404754-asf-stm)**，使您可以通过浏览器自动向我们的 [**ASF STM 列表**](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin-zh-CN#publiclisting公共列表)内的机器人发送交易报价，而无需使用 ASF 提供的 `MatchActively` 功能。
- **[telegram-asf](https://github.com/deluxghost/telegram-asf)**，另一个用 Python 编写的集成 ASF 最基本功能的 Telegram 机器人。

---

## 库

- **[ASF-IPC](https://github.com/deluxghost/ASF_IPC)**，进一步集成 ASF IPC 接口的 Python 库。

---

## 包管理

- **[AUR repo #1](https://aur.archlinux.org/packages/asf)**，使您在 Arch Linux 上安装 ASF 更容易。
- **[AUR repo #2](https://aur.archlinux.org/packages/archisteamfarm-bin)**，使您在 Arch Linux 上安装 ASF 更容易。
- **[Homebrew](https://formulae.brew.sh/formula/archi-steam-farm)**，使您能方便地在 macOS 上安装 ASF。
- **[Nix](https://search.nixos.org/packages?channel=unstable&show=ArchiSteamFarm&from=0&size=50&sort=relevance&type=packages&query=ArchiSteamFarm)**，使您在支持 Nix 的发行版上安装 ASF 更容易。
- **[NixOS](https://search.nixos.org/options?channel=unstable&from=0&size=50&sort=relevance&type=packages&query=ArchiSteamFarm)**，使您可以在 NixOS 上配置和安装 ASF。

---

## 工具

- **[Keys extractor](https://ske.xpixv.com)**，能够从您复制的带有游戏序列号的各种文本中提取序列号，并为您生成 ASF 的 `redeem` 命令。 前往 **[GitHub 仓库](https://github.com/PixvIO/SKE)**&#8203;了解更多。
- **[ASF Mass Config Editor](https://github.com/genesix-eu/ASF_MCE)**，使您能够方便地管理多份 ASF 配置文件。

---

## 了解更多?

我们建议您在 GitHub 上搜索 **[ArchiSteamFarm](https://github.com/topics/archisteamfarm)** 主题来寻找关于 ASF 的项目。