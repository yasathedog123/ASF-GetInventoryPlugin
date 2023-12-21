# 命令

ASF 支持各种命令，用来控制程序和机器人实例的行为。

您可以通过不同的方式发送命令：
- 通过 ASF 交互式控制台
- 通过 Steam 私人/群组聊天
- 通过 **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-zh-CN)** 接口

请注意，与 ASF 交互需要您拥有执行相关命令的权限。 查看 `SteamUserPermissions` 和 `SteamOwnerID` 配置文件属性了解更多。

通过 Steam 聊天发送的命令都受 `CommandPrefix` **[全局配置属性](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-zh-CN#commandprefix)**&#8203;影响，该属性的默认值为 `!`。 这意味着，当您要执行 `status` 命令时，实际应该发送 `!status`（或者使用您自定义的 `CommandPrefix`）。 而通过控制台或 IPC 发送的命令则无需加上 `CommandPrefix`，可以省略。

---

### 交互式控制台

ASF 支持交互式控制台，只要您没有让 ASF 在 [**`Headless`**](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-zh-CN#headless) 模式下运行。 只需要按下 `c` 键就可以启用命令模式，此时您可以输入命令，并按回车键确认。

![屏幕截图](https://i.imgur.com/bH5Gtjq.png)

---

### Steam 聊天

您也可以通过 Steam 聊天对给定的 ASF 机器人执行命令。 显然，您无法直接与自己聊天，因此如果您希望为您的主帐户执行命令，就至少还需要另一个机器人帐户。

![屏幕截图](https://i.imgur.com/IvFRJ5S.png)

类似地，您也可以使用指定 Steam 群组的群组聊天。 请注意，此选项需要您正确设置 `SteamMasterClanID` 属性，使机器人同样监听（并加入）指定的群组聊天。 与私人聊天不同，因为这种方法不需要额外的帐户，所以可以用来“与自己交谈”。 您可以直接将 `SteamMasterClanID` 属性设置为您新创建的群组，然后通过 `SteamOwnerID` 属性或者机器人的 `SteamUserPermissions` 属性为您自己的帐户授予足够的权限。 这样，ASF 机器人（即您自己的帐户）将会加入这个群组和群组聊天室，并且开始监听您发送的命令。 您可以加入同一个群组聊天室，以便向自己发送命令（因为在您向聊天室发送命令时，同样在聊天室内的 ASF 实例将会收到命令，即使界面上显示只有您自己在聊天室内）。

请注意，向群组聊天发送命令类似于接力赛跑。 如果您向一个含有 3 个机器人的群组聊天室发送 `redeem X` 命令，其效果等价于分别在私聊中向每个机器人发送 `redeem X`。 在大多数情况下，**这不是您想要的效果**，您应该像之前**与单个机器人私聊时**一样，使用指定机器人名称的命令形式。 ASF 支持群组聊天，是因为在很多情况下它是一种有用的、与您自己的机器人通信的方式，但如果您的群组中有多个 ASF 机器人，就最好不要在这里执行命令，除非您完全理解 ASF 的相关行为，并且您确实想要让所有的机器人转发执行相同的命令。

*但即使是在这种情况下，您也应该采用私人聊天，并使用指定机器人名称的 `[Bots]` 语法。*

---

### IPC

这是执行命令最先进、灵活的方式，非常适合用户集成（ASF-ui）或者第三方工具脚本（ASF API）。这种方式需要 ASF 运行在 `IPC` 模式下，并且客户端需要通过 **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-zh-CN)** 接口来执行命令。

![屏幕截图](https://raw.githubusercontent.com/JustArchiNET/ASF-ui/main/.github/previews/commands.png)

---

## 命令

| 命令                                                                   | 权限              | 描述                                                                                                                                                             |
| -------------------------------------------------------------------- | --------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `2fa [Bots]`                                                         | `Master`        | 为指定机器人生成临时的&#8203;**[两步验证](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication-zh-CN)**&#8203;令牌。                                    |
| `2fafinalize [Bots] <ActivationCode>`                          | `Master`        | 使用短信或邮件验证码，完成为指定机器人绑定新[**两步验证**](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication-zh-CN#创建)凭据的流程。                                 |
| `2fafinalized [Bots] <ActivationCode>`                         | `Master`        | 为指定机器人导入已创建完成的[**两步验证**](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication-zh-CN#创建)凭据，并用两步验证令牌代码验证。                               |
| `2fafinalizedforce [Bots]`                                           | `Master`        | 为指定机器人导入已创建完成的[**两步验证**](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication-zh-CN#创建)凭据，并跳过两步验证令牌代码验证。                              |
| `2fainit [Bots]`                                                     | `Master`        | 开始为指定机器人绑定新[**两步验证**](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication-zh-CN#创建)凭据的流程。                                            |
| `2fano [Bots]`                                                       | `Master`        | 为指定机器人拒绝所有等待操作的[**两步验证**](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication-zh-CN)交易确认。                                            |
| `2faok [Bots]`                                                       | `Master`        | 为指定机器人接受所有等待操作的[**两步验证**](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication-zh-CN)交易确认。                                            |
| `addlicense [Bots] <Licenses>`                                 | `Operator`      | 为指定机器人激活给定的 `Licenses `（许可），该参数解释详见[**下文**](#addlicense-命令的-licenses-参数)。                                                                                      |
| `balance [Bots]`                                                     | `Master`        | 显示指定机器人的 Steam 钱包余额。                                                                                                                                           |
| `bgr [Bots]`                                                         | `Master`        | 显示指定机器人的 **[BGR](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer-zh-CN)**（后台游戏激活器）队列信息。                                          |
| `encrypt <encryptionMethod> <stringToEncrypt>`           | `Owner`         | 以给定的加密方式加密字符串——详见[**下文的解释**](#encrypt-命令)。                                                                                                                     |
| `exit`                                                               | `Owner`         | 完全停止 ASF 进程。                                                                                                                                                   |
| `farm [Bots]`                                                        | `Master`        | 重新启动指定机器人的挂卡模块。                                                                                                                                                |
| `fb [Bots]`                                                          | `Master`        | 列出指定机器人的自动挂卡黑名单。                                                                                                                                               |
| `fbadd [Bots] <AppIDs>`                                        | `Master`        | 将给定的 `AppIDs` 加入指定机器人的自动挂卡黑名单。                                                                                                                                 |
| `fbrm [Bots] <AppIDs>`                                         | `Master`        | 将给定的 `AppIDs` 从指定机器人的自动挂卡黑名单中移除。                                                                                                                               |
| `fq [Bots]`                                                          | `Master`        | 列出指定机器人的优先挂卡队列。                                                                                                                                                |
| `fqadd [Bots] <AppIDs>`                                        | `Master`        | 将给定的 `AppIDs` 加入指定机器人的优先挂卡队列。                                                                                                                                  |
| `fqrm [Bots] <AppIDs>`                                         | `Master`        | 将给定的 `AppIDs` 从指定机器人的优先挂卡队列中移除。                                                                                                                                |
| `hash <hashingMethod> <stringToHash>`                    | `Owner`         | 以指定的加密方式生成给定字符串的哈希值——详见[**下文的解释**](#hash-命令)。                                                                                                                  |
| `help`                                                               | `FamilySharing` | 显示帮助（指向此页面的链接）。                                                                                                                                                |
| `input [Bots] <Type> <Value>`                            | `Master`        | 为指定机器人填写给定的输入值，仅在 `Headless` 模式中可用——详见[**下文的解释**](#input-命令)。                                                                                                  |
| `level [Bots]`                                                       | `Master`        | 显示指定机器人的 Steam 帐户等级。                                                                                                                                           |
| `loot [Bots]`                                                        | `Master`        | 将指定机器人的所有 `LootableTypes` 社区物品拾取到其 `SteamUserPermissions` 属性中设置的 `Master` 用户（如果有多个则取 steamID 最小的）。                                                             |
| `loot@ [Bots] <AppIDs>`                                        | `Master`        | 将指定机器人的所有符合给定 `AppIDs` 的 `LootableTypes` 社区物品拾取到其 `SteamUserPermissions` 属性中设置的 `Master` 用户（如果有多个则取 steamID 最小的）。 此命令与 `loot%` 相反。                             |
| `loot% [Bots] <AppIDs>`                                        | `Master`        | 将指定机器人的所有不符合给定 `AppIDs` 的 `LootableTypes` 社区物品拾取到其 `SteamUserPermissions` 属性中设置的 `Master` 用户（如果有多个则取 steamID 最小的）。 此命令与 `loot@` 相反。                            |
| `loot^ [Bots] <AppID> <ContextID>`                       | `Master`        | 将指定机器人的 `ContextID` 库存分类中符合给定 `AppID` 的物品拾取到其 `SteamUserPermissions` 属性中设置的 `Master` 用户（如果有多个则取 steamID 最小的）。                                                  |
| `mab [Bots]`                                                         | `Master`        | 列出 **[`MatchActively`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin-zh-CN#matchactively主动匹配)** 自动交易的 App 黑名单。                        |
| `mabadd [Bots] <AppIDs>`                                       | `Master`        | 将给定的 `AppIDs` 加入到 **[`MatchActively`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin-zh-CN#matchactively主动匹配)** 自动交易的 App 黑名单。         |
| `mabrm [Bots] <AppIDs>`                                        | `Master`        | 将给定的 `AppIDs` 从 **[`MatchActively`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin-zh-CN#matchactively主动匹配)** 自动交易的 App 黑名单中移除。        |
| `match [Bots]`                                                       | `Master`        | 控制 **[`ItemsMatcherPlugin`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin-zh-CN#matchactively主动匹配)** 的特殊命令，用于立即触发 `MatchActively` 流程。 |
| `nickname [Bots] <Nickname>`                                   | `Master`        | 将指定机器人的昵称更改为 `Nickname`。                                                                                                                                       |
| `owns [Bots] <Games>`                                          | `Operator`      | 检查指定机器人是否已拥有 `Games`，该参数解释详见[**下文**](#owns-命令的-games-参数)。                                                                                                      |
| `pause [Bots]`                                                       | `Operator`      | 永久暂停指定机器人的自动挂卡模块。 ASF 在本次会话中将不会再尝试对此帐户进行挂卡，除非您手动 `resume` 或者重启 ASF。                                                                                            |
| `pause~ [Bots]`                                                      | `FamilySharing` | 临时暂停指定机器人的自动挂卡模块。 挂卡进程将会在下次游戏事件或者机器人断开连接时自动恢复。 您可以 `resume` 以恢复挂卡。                                                                                             |
| `pause& [Bots] <Seconds>`                                  | `Operator`      | 临时暂停指定机器人的自动挂卡模块 `Seconds` 秒。 之后，挂卡模块会自动恢复。                                                                                                                    |
| `play [Bots] <AppIDs,GameName>`                                | `Master`        | 切换到手动挂卡——使指定机器人运行给定的 `AppIDs`，并且可选自定义 `GameName` 为游戏名称。 若要此功能正常工作，您的 Steam 帐户**必须**拥有所有您指定的 `AppIDs` 的有效许可，包括免费游戏。 使用 `reset` 或 `resume` 命令恢复。                 |
| `points [Bots]`                                                      | `Master`        | 显示指定机器人的 [**Steam 点数商店**](https://store.steampowered.com/points/shop)点数余额。                                                                                     |
| `privacy [Bots] <Settings>`                                    | `Master`        | 更改指定机器人的 **[Steam 隐私设置](https://steamcommunity.com/my/edit/settings)**，可用选项见[**下文**](#privacy-设置)。                                                             |
| `redeem [Bots] <Keys>`                                         | `Operator`      | 为指定机器人激活给定的游戏序列号或钱包充值码。                                                                                                                                        |
| `redeem^ [Bots] <Modes> <Keys>`                          | `Operator`      | 以 `Modes` 模式为指定机器人激活给定的游戏序列号或钱包充值码，模式详见下文的[**解释**](#redeem-模式)。                                                                                                |
| `reset [Bots]`                                                       | `Master`        | 重置为原始（之前的）游玩状态，用来配合 `play` 命令的手动挂卡模式使用。                                                                                                                        |
| `restart`                                                            | `Owner`         | 重新启动 ASF 进程。                                                                                                                                                   |
| `resume [Bots]`                                                      | `FamilySharing` | 恢复指定机器人的自动挂卡进程。                                                                                                                                                |
| `start [Bots]`                                                       | `Master`        | 启动指定机器人。                                                                                                                                                       |
| `stats`                                                              | `Owner`         | 显示进程统计信息，例如托管内存用量。                                                                                                                                             |
| `status [Bots]`                                                      | `FamilySharing` | 显示指定机器人的状态。                                                                                                                                                    |
| `std [Bots]`                                                         | `Master`        | 控制 **[`SteamTokenDumperPlugin`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/SteamTokenDumperPlugin-zh-CN)** 的特殊命令，用于触发刷新指定的机器人并立即提交数据。                 |
| `stop [Bots]`                                                        | `Master`        | 停止指定机器人。                                                                                                                                                       |
| `tb [Bots]`                                                          | `Master`        | 列出指定机器人的交易黑名单用户。                                                                                                                                               |
| `tbadd [Bots] <SteamIDs64>`                                    | `Master`        | 将给定的 `SteamIDs` 加入指定机器人的交易黑名单。                                                                                                                                 |
| `tbrm [Bots] <SteamIDs64>`                                     | `Master`        | 将给定的 `SteamIDs` 从指定机器人的交易黑名单中移除。                                                                                                                               |
| `transfer [Bots] <TargetBot>`                                  | `Master`        | 将指定机器人的所有 `TransferableTypes` 社区物品转移到一个目标机器人。                                                                                                                  |
| `transfer@ [Bots] <AppIDs> <TargetBot>`                  | `Master`        | 将指定机器人的所有符合给定 `AppIDs` 的 `TransferableTypes` 社区物品转移到一个目标机器人。 此命令与 `transfer%` 相反。                                                                              |
| `transfer% [Bots] <AppIDs> <TargetBot>`                  | `Master`        | 将指定机器人的所有不符合给定 `AppIDs` 的 `TransferableTypes` 社区物品转移到一个目标机器人。 此命令与 `transfer@` 相反。                                                                             |
| `transfer^ [Bots] <AppID> <ContextID> <TargetBot>` | `Master`        | 将指定机器人的 `ContextID` 库存分类中符合给定 `AppID` 的物品转移到一个目标机器人。                                                                                                           |
| `unpack [Bots]`                                                      | `Master`        | 拆开指定机器人库存中的所有补充包。                                                                                                                                              |
| `update [Channel]`                                                   | `Owner`         | 在 GitHub 上检查 ASF 新版本，如果可用则更新。 通常这会每隔 `UpdatePeriod` 自动执行一次。 可选的 `Channel` 参数指定 `UpdateChannel`，如果未提供，则默认使用全局设置中的值。                                             |
| `version`                                                            | `FamilySharing` | 显示 ASF 的版本号。                                                                                                                                                   |

---

### 备注

所有的命令都不区分大小写，但它们的参数（例如机器人名称）通常是区分大小写的。

参数遵循 UNIX 哲学，方括号包围的选项 `[Optional]` 表示这个参数是可选的，尖括号包围的选项 `<Mandatory>` 表示这个参数是必须的。 执行命令时，您应该用实际要操作的值替换所需的参数，例如 `[Bots]` 或 `<Nickname>`，同时省略括号。

在所有命令中，由其方括号可知，`[Bots]` 参数都是可选的。 当指定该参数时，命令会在指定的机器人上执行。 但省略时，命令会在接收命令的机器人上执行。 换句话说，向机器人 `B` 发送 `status A` 命令等价于向机器人 `A` 发送 `status` 命令，此时机器人 `B` 仅仅充当一个代理人的角色。 这也可以用于向无法使用的机器人发送命令，例如启动已停止的机器人，或者在主帐户（您发送命令的帐户）上执行操作。

命令的**权限**定义了需要执行此命令所需的**最低**权限，即 `SteamUserPermissions` 中定义的 `EPermission`，例外情况是 `Owner` 指全局配置文件中定义的 `SteamOwnerID` 用户（拥有最高权限）。

复数参数，例如 `[Bots]`、`<Keys>` 或 `<AppIDs>`，意味着该参数支持接受多个由逗号分隔的值。 例如，`status [Bots]` 命令支持 `status MyBot,MyOtherBot,Primary` 形式的用法。 这样，该命令会在**所有目标机器人**上执行，效果与分别向所有机器人发送 `status` 命令是相同的。 需要注意的是逗号 `,` 后面不能有空格。

ASF 使用所有空白字符作为命令的分隔符，例如空格和换行符。 这意味着您不仅可以使用空格来分隔参数，还可以使用任何其他空白字符（如制表符和换行符）。

ASF 会将命令末尾超出规定范围的多余参数连接到符合语法规定的最后一个复数参数上。 这意味着，对于 `redeem [Bots] <Keys>` 命令，`redeem bot key1 key2 key3` 与 `redeem bot key1,key2,key3` 的作用是相同的。 再加上您可以使用换行符作为命令分隔符，这样您就可以先写 `redeem bot`，然后在其后粘贴一个游戏序列号列表，其中每一项可以由任意空白字符（例如换行符）或者 ASF 标准的逗号 `,` 分隔。 请注意，要使用这一技巧，您必须采用该命令参数数量最多的形式（所以在这种情况下，您必须指定 `[Bots]` 参数）。

如上所述，空白字符被用于分隔命令参数，所以参数内部无法再使用空白字符。 但同样如上所述，ASF 可以连接超出范围的参数，这意味着您可以在命令的最后一个参数中使用空白字符。 例如，`nickname bob Great Bob` 命令能够正确地将机器人 `bob` 的昵称更改为“Great Bob”。 类似地，您也可以使用 `owns` 命令检查含有空格的名称。

---

一些命令有较短的别名可用，主要用来减少键入的次数或者兼容不同方言的拼写：

| 命令           | 别名           |
| ------------ | ------------ |
| `addlicense` | `addlicence` |
| `owns ASF`   | `oa`         |
| `status ASF` | `sa`         |
| `redeem`     | `r`          |
| `redeem^`    | `r^`         |

---

### `[Bots]` 参数

`[Bots]` 是复数参数的一个特殊变体，它除了接受多个值以外，还有额外的功能。

首先，您可以使用特殊的关键字 `ASF` 来表示“所有机器人”，所以 `status ASF` 命令与列出所有机器人的命令 `status all,your,bots,listed,here` 是相同的。 这也可以方便地识别您有权操作哪些机器人，因为尽管 `ASF` 关键字的目标是所有机器人，但只有您能够实际发送命令的机器人才会作出响应。

`[Bots]` 参数支持范围语法，您可以很容易地选择一定范围的机器人。 这种情况下，`[Bots]` 的一般语法为 `[FirstBot]..[LastBot]`。 必须至少定义一个参数。 当使用 `<FirstBot>..` 时，自 `FirstBot` 起的所有机器人都会受影响。 当使用 `..<LastBot>` 时，到 `LastBot` 为止的所有机器人都会受影响。 当使用 `<FirstBot>..<LastBot>` 时，在范围从 `FirstBot` 到 `LastBot` 之内的所有机器人都会受影响。 例如，假设您有机器人 `A, B, C, D, E, F`，如果您执行 `status B..E`，效果与执行 `status B,C,D,E` 是相同的。 在使用此语法时，ASF 将会以字母顺序为机器人排序，以决定哪些机器人在指定范围内。 参数必须是 ASF 能够识别的有效机器人名称，否则范围语法将不会生效。

除了上述的范围语法，`[Bots]` 参数还支持[**正则表达式**](https://en.wikipedia.org/wiki/Regular_expression)匹配。 您可以使用 `r!<Pattern>` 作为机器人名称，其中 `r!` 告诉 ASF 使用正则表达式匹配，而 `<Pattern>` 则是正则表达式。 一个使用正则表达式的例子为 `status r!^\d{3}` 命令，它会向所有名称为 3 个数字的机器人（例如 `123` 和 `981`）发送 `status` 命令。 您可以阅读这份[**文档**](https://docs.microsoft.com/zh-cn/dotnet/standard/base-types/regular-expression-language-quick-reference)，进一步了解正则表达式的解释和示例。

---

## `privacy` 设置

`<Settings>` 参数接受**最多 7 个**不同的选项，像平常一样使用 ASF 标准的逗号分隔。 这些选项分别是：

| 参数 | 名称                   | 从属于        |
| -- | -------------------- | ---------- |
| 1  | Profile（个人资料）        |            |
| 2  | OwnedGames（游戏详情）     | Profile    |
| 3  | Playtime（游戏时间）       | OwnedGames |
| 4  | FriendsList（好友列表）    | Profile    |
| 5  | Inventory（库存）        | Profile    |
| 6  | InventoryGifts（库存礼物） | Inventory  |
| 7  | Comments（留言）         | Profile    |

关于上述选项的说明，请访问 **[Steam 隐私设置](https://steamcommunity.com/my/edit/settings)**。

每个选项的有效值可以是：

| 值 | 名称                  |
| - | ------------------- |
| 1 | `Private（私密）`       |
| 2 | `FriendsOnly（仅限好友）` |
| 3 | `Public（公开）`        |

您可以使用它们的名称（不区分大小写）或者数字值。 被省略的参数将会被设置为默认值 `Private`。 上述参数的从属关系是非常重要的，因为子选项无法拥有比父选项更高的权限。 例如，如果您将个人资料设置为 `Private`，就**无法**再将游戏详情设置为 `Public`。

### 范例

如果您希望将机器人 `Main` 的**所有**隐私设置都设置为 `Private`，可以使用以下任一命令：

```text
privacy Main 1
privacy Main Private
```

这是因为 ASF 会默认所有选项为 `Private`，所以您不需要全部写出它们。 另一方面，如果您希望设置所有选项为 `Public`，可以使用以下任一命令：

```text
privacy Main 3,3,3,3,3,3,3
privacy Main Public,Public,Public,Public,Public,Public,Public
```

也可以为每个选项设置不同的值：

```text
privacy Main Public,FriendsOnly,Private,Public,Public,Private,Public
```

该命令将会设置个人资料为公开、游戏详情为仅限好友、游戏时间为私密、好友列表为公开、库存为公开、库存礼物为私密、留言为公开。 如果您改用数字值，效果是一样的。

---

## `addlicense` 命令的 Licenses 参数

`addlicense` 命令支持两种不同的许可类型，包括：

| 类型    | 别名  | 示例           | 描述                        |
| ----- | --- | ------------ | ------------------------- |
| `app` | `a` | `app/292030` | 游戏的唯一 `appID`。            |
| `sub` | `s` | `sub/47807`  | 包含一款或多款游戏的包，有唯一的 `subID`。 |

二者的区别很重要，因为 ASF 需要向 Steam 网络激活 App，向 Steam 商店激活 Sub。 二者互不兼容，通常您会为周末免费或永久免费游戏使用 App，为其他情况使用 Sub。

我们建议您明确指定每一项的类型，以避免模糊不清的结果，但为了与之前的行为兼容，如果您提供的类型无效或者完全没有提供类型，ASF 会将您输入的数字视为 sub 类型。 您也可以同时激活多条许可，即使用标准的 ASF 逗号分隔符（`,`）。

一个完整命令的示例：

```text
addlicense ASF app/292030,sub/47807
```

---

## `owns` 命令的 Games 参数

`owns` 命令支持几种不同的 `<games>` 参数类型，包括：

| 类型      | 别名  | 示例               | 描述                                                                                                                                                                                                                        |
| ------- | --- | ---------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `app`   | `a` | `app/292030`     | 游戏的唯一 `appID`。                                                                                                                                                                                                            |
| `sub`   | `s` | `sub/47807`      | 包含一款或多款游戏的包，有唯一的 `subID`。                                                                                                                                                                                                 |
| `regex` | `r` | `regex/^\d{4}:` | 用于模式匹配游戏名称的&#8203;**[正则表达式](https://en.wikipedia.org/wiki/Regular_expression)**，区分大小写。 完整的语法与示例见&#8203;**[文档](https://docs.microsoft.com/zh-cn/dotnet/standard/base-types/regular-expression-language-quick-reference)**。 |
| `name`  | `n` | `name/Witcher`   | 游戏名称的一部分，不区分大小写。                                                                                                                                                                                                          |

我们建议您明确指定每一项的类型，以避免模糊不清的结果，但为了与之前的行为兼容，如果您提供的类型无效或者完全没有提供类型，ASF 会将您输入的数字视为 `app` 类型，将其他内容视为 `name` 类型。 您也可以同时查询多款游戏，即使用标准的 ASF 逗号分隔符（`,`）。

一个完整命令的示例：

```text
owns ASF app/292030,name/Witcher
```

---

## `redeem^` 模式

`redeem^` 命令使您能够单独调整某个激活场景下采取的激活模式。 此命令会临时覆盖 `RedeemingPreferences` **[机器人配置属性](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-zh-CN#机器人配置)**。

`<Modes>` 接受由逗号分隔的多个模式代码。 可用的模式代码有：

| 值    | 名称                    | 描述                                               |
| ---- | --------------------- | ------------------------------------------------ |
| FAWK | ForceAssumeWalletKey  | 强制启用 `AssumeWalletKeyOnBadActivationCode` 激活偏好设置 |
| FD   | ForceDistributing     | 强制启用 `Distributing` 激活偏好设置                       |
| FF   | ForceForwarding       | 强制启用 `Forwarding` 激活偏好设置                         |
| FKMG | ForceKeepMissingGames | 强制启用 `KeepMissingGames` 激活偏好设置                   |
| SAWK | SkipAssumeWalletKey   | 强制禁用 `AssumeWalletKeyOnBadActivationCode` 激活偏好设置 |
| SD   | SkipDistributing      | 强制禁用 `Distributing` 激活偏好设置                       |
| SF   | SkipForwarding        | 强制禁用 `Forwarding` 激活偏好设置                         |
| SI   | SkipInitial           | 跳过首个机器人的激活过程                                     |
| SKMG | SkipKeepMissingGames  | 强制禁用 `KeepMissingGames` 激活偏好设置                   |
| V    | Validate              | 检查序列号的格式，自动跳过其中无效的                               |

例如，我么打算为尚未拥有游戏的机器人激活 3 个序列号，但不包括 `primary` 机器人。 为此我们需要执行命令：

`redeem^ primary FF,SI key1,key2,key3`

需要注意的是，只有您**在命令中指定的**模式才会替换 `RedeemingPreferences` 中的选项。 例如，如果您在 `RedeemingPreferences` 中启用了 `Distributing`，那么无论您是否指定 `FD` 模式，Distributing 都会生效，因为您已经在 `RedeemingPreferences` 中启用了它。 这也是为何我们针对同一种模式有启用和禁用两种选项，您可以用强制启用代码来覆盖已禁用的模式，反之亦然。

---

## `encrypt` 命令

`encrypt` 命令使您能够使用 ASF 的加密方式加密任意字符串。 加密方式 `<encryptionMethod>` 必须是[**安全性**](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security-zh-CN)章节所述方式之一。 我们建议通过安全的渠道（ASF 控制台、ASF-ui 或 IPC 提供的专用 API 端点）使用此命令，否则可能有敏感信息被第三方记录（例如 Steam 服务器的聊天记录）。

---

## `hash` 命令

`hash` 命令使您能够使用 ASF 的哈希方式生成任意字符串的哈希值。 哈希方式 `<hashingMethod>` 必须是[**安全性**](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security-zh-CN)章节所述方式之一。 我们建议通过安全的渠道（ASF 控制台、ASF-ui 或 IPC 提供的专用 API 端点）使用此命令，否则可能有敏感信息被第三方记录（例如 Steam 服务器的聊天记录）。

---

## `input` 命令

`input` 命令仅可用于 `Headless` 模式，用来在 ASF 无法接受用户输入的情况下，通过 **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-zh-CN)** 或者 Steam 聊天输入一些数据。

基本的语法是 `input [Bots] <Type> <Value>`。

`<Type>` 不区分大小写，定义 ASF 接受的输入类型。 目前 ASF 支持以下类型：

| 类型                      | 描述                                         |
| ----------------------- | ------------------------------------------ |
| Login                   | `SteamLogin` 机器人配置属性，在配置文件缺少这个值时使用。        |
| Password                | `SteamPassword` 机器人配置属性，在配置文件缺少这个值时使用。     |
| SteamGuard              | 通过电子邮件发送的验证码，在您未启用 2FA 时使用。                |
| SteamParentalCode       | `SteamParentalCode` 机器人配置属性，在配置文件缺少这个值时使用。 |
| TwoFactorAuthentication | 手机生成的 2FA 令牌，在您启用 2FA 但未启用 ASF 2FA 时使用。    |
| DeviceConfirmation      | 确定登录确认请求是否已被批准                             |

`<Value>` 是要为指定类型设置的值。 目前所有的值都是字符串。

### 示例

假设我们有一个机器人，未启用 2FA，仅由 Steam 电子邮件令牌保护。 我们希望在 `Headless` 为 `true` 的情况下启动这个机器人。

为此，我们需要执行以下命令：

`start MySteamGuardBot` -> 机器人会尝试登录，但因为缺少验证码而登录失败，然后因为 ASF 处于 `Headless` 模式，机器人会停止运行。 我们做这一步的目的是让 Steam 网络向我们发送验证码电子邮件——否则我们就可以跳过这一步了。

`input MySteamGuardBot SteamGuard ABCDE` -> 我们将 `MySteamGuardBot` 机器人的 `SteamGuard` 输入设置为 `ABCDE`。 当然，这里的 `ABCDE` 需要换成我们在电子邮件中找到的验证码。

`start MySteamGuardBot` -> 我们重新启动已停止的机器人，这一次会自动使用我们在上一步中设置的验证码，登录将会成功，并且之前的验证码输入会被清除。

如果您的机器人启用了 2FA，但是没有导入 ASF 2FA，您可以用相同的方式操作这种机器人，只需要在运行时设置其他所需的属性即可。