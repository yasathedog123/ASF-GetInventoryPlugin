# 配置

此页面专门用于说明 ASF 的相关配置。 它是一份关于 `config` 文件夹的完整文档，让您能够根据自己的需求调整 ASF。

* **[简介](#简介)**
* **[在线配置文件生成器](#在线配置文件生成器)**
* **[ASF-ui 配置](#asf-ui-配置)**
* **[手动配置](#手动配置)**
* **[全局配置](#全局配置)**
* **[机器人配置](#机器人配置)**
* **[文件结构](#文件结构)**
* **[JSON 映射](#json-映射)**
* **[兼容性映射](#兼容性映射)**
* **[配置兼容性](#配置兼容性)**
* **[自动重载](#自动重载)**

---

## 简介

ASF 的配置分为两个主要的部分——全局（进程）配置和每个机器人的配置。 每个机器人都有自己的名为 `BotName.json` 的机器人配置文件（其中 `BotName` 是机器人的名称），而 ASF 的全局（进程）配置是一个单独的名叫 `ASF.json` 的文件。

每个机器人都是一个在 ASF 进程中运行的单独的 Steam 帐户。 为了能够正常工作，ASF 需要至少定义**一个**机器人实例。 进程不会为机器人实例设定强制的数量限制，所以您可以运行任意数量的机器人（Steam 帐户）。

ASF 采用 **[JSON](https://en.wikipedia.org/wiki/JSON)** 格式存储其配置文件。 这是人性化、可读性高且非常通用的格式，您可以在其中对程序进行配置。 不过不用担心，您不需要为了配置 ASF 去专门了解 JSON。 我提到它只是考虑到您可能会想要使用一些 Bash 脚本批量创建大量 ASF 配置文件。

您可以通过几种方式完成配置。 您可以使用独立于 ASF 的本地应用&#8203;**[在线配置文件生成器](https://justarchinet.github.io/ASF-WebConfigGenerator)**。 还可以使用我们的 IPC 前端 **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-zh-CN#asf-ui)** 直接配置 ASF。 最后，您也可以随时按照下文所述的 JSON 结构，手动编写配置文件。 我们将快速解释一下这些方式。

---

## 在线配置文件生成器

**[在线配置文件生成器](https://justarchinet.github.io/ASF-WebConfigGenerator)**&#8203;的目标是给您提供一个用于生成 ASF 配置文件的友好前端。 它是 100% 基于客户端的，这意味着您输入的任何信息都不会被上传，而仅在本地进行处理。 这保证了安全性和可靠性，因为假设您愿意下载所有相关文件，并在您喜爱的浏览器中打开其中的 `index.html`，它甚至可以&#8203;**[离线](https://github.com/JustArchiNET/ASF-WebConfigGenerator/tree/main/docs)**&#8203;运行。

在线配置文件生成器已经在 Chrome 和 Firefox 上经过验证可以正常运行，但它也应该可以在所有流行的的支持 JavaScript 的浏览器中正常运行。

它的用法非常简单——切换到正确的标签来选择要生成 `ASF` 配置还是 `Bot`（机器人）配置，确保所选配置文件的版本与您的 ASF 版本相匹配，然后输入所有详细信息并点击“下载”按钮。 将此文件移动到 ASF 的 `config` 文件夹，如果需要的话，覆盖掉已经存在的文件。 如果要继续配置，则重复以上操作，并参考本页的其他部分以了解所有可配置的选项。

---

## ASF-ui 配置

我们的 **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)** IPC 接口同样支持配置 ASF，并且特别适合在第一次配置之后修改配置内容，因为与在线配置文件生成器总是生成新文件不同，ASF-ui 可以在原地直接编辑配置文件。

要使用 ASF-ui，首先您需要启用 **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)** 接口本身。 `IPC` 默认启用，因此只要您没有手动禁用它，就可以直接开始访问。

程序启动后，直接访问 ASF 的 **[IPC 地址](http://localhost:1242)**。 如果一切都正常工作，您也可以在这里更改 ASF 配置。

---

## 手动配置

我们通常强烈建议使用在线配置文件生成器或 ASF-ui，因为这些方式更简单，还可以确保您不会不小心造成 JSON 结构错误，但如果出于某种原因，您不想使用它们，那么您也可以手动创建正确的配置文件。 参考下面的 JSON 示例来保证结构正确，您可以将内容复制到文件中并在此基础上作修改。 由于您没有使用我们的前端，请确保您的配置&#8203;**[有效](https://jsonlint.com)**，因为如果 ASF 无法解析它，将拒绝加载。 即使它是有效的 JSON，您也必须确保所有属性都有正确的类型，正如 ASF 所要求的那样。 关于各字段的正确 JSON 结构，请阅读本文中的 **[JSON 映射](#json-映射)**&#8203;一节。

---

## 全局配置

全局配置存放于 `ASF.json` 文件中，其结构如下：

```json
{
    "AutoRestart": true,
    "Blacklist": [],
    "CommandPrefix": "!",
    "ConfirmationsLimiterDelay": 10,
    "ConnectionTimeout": 90,
    "CurrentCulture": null,
    "Debug": false,
    "DefaultBot": null,
    "FarmingDelay": 15,
    "FilterBadBots": true,
    "GiftsLimiterDelay": 1,
    "Headless": false,
    "IdleFarmingPeriod": 8,
    "InventoryLimiterDelay": 4,
    "IPC": true,
    "IPCPassword": null,
    "IPCPasswordFormat": 0,
    "LicenseID": null,
    "LoginLimiterDelay": 10,
    "MaxFarmingTime": 10,
    "MaxTradeHoldDuration": 15,
    "MinFarmingDelayAfterBlock": 60,
    "OptimizationMode": 0,
    "SteamMessagePrefix": "/me ",
    "SteamOwnerID": 0,
    "SteamProtocols": 7,
    "UpdateChannel": 1,
    "UpdatePeriod": 24,
    "WebLimiterDelay": 300,
    "WebProxy": null,
    "WebProxyPassword": null,
    "WebProxyUsername": null
}
```

---

下面是对所有选项的解释：

### `AutoRestart`

这是一个默认值为 `true` 的 `bool` 类型属性。 该属性定义了是否允许 ASF 程序在需要时自动重启。 有一些情况需要 ASF 自动重启，例如 ASF 更新（通过 `UpdatePeriod` 属性或 `update` 命令实现）、`ASF.json` 文件有修改、执行 `restart` 命令等。 通常情况下，重启包括两个部分——创建新进程和结束当前进程。 对于大多数用户来说，这个属性应保留为默认值 `true`。除非您正在通过自己的脚本或者 `dotnet` 运行 ASF，这种情况下，您可能更希望能够完全控制进程的启动，同时避免新的（自动重启产生的）ASF 程序在后台而不是在脚本控制下运行，并且脚本随着旧的 ASF 进程一起退出的情况。 同时考虑到新的进程不再是原先进程的直接子进程，这可能会导致您无法使用标准控制台输入。

如果是这样的情况，这个属性就是专门为您设置的，您可以将其设置为 `false`。 但是，请记住，在这种情况下，**您**需要自行重启进程。 这在某种程度上很重要，因为 ASF 将只退出，而不会生成新进程（例如在更新后），所以如果您没有为其添加重启逻辑，它就会停止运行，直到您重新启动它。 ASF 总会在退出时返回正确的错误代码，0 表示成功，非 0 表示出错，这样您就可以在脚本中添加错误处理的正确逻辑，在出错时不自动重启，或者至少复制一份 `log.txt` 供后续分析。 还需注意，无论如何设置此属性，`restart` 命令都会重新启动 ASF，因为此属性仅仅定义默认行为，而 `restart` 会覆盖此行为。 除非您有理由禁用此功能，否则应将其保持为启用。

---

### `Blacklist`

这是一个默认值为空的 `ImmutableHashSet<uint>` 类型属性。 顾名思义，这个全局配置属性定义了 ASF 自动挂卡过程完全忽略的 AppID（游戏）。 不幸的是，Steam 喜欢将夏季/冬季特卖徽章标记为“可掉落卡牌”，使 ASF 认为这是一个可挂卡的游戏。 如果没有这种黑名单，ASF 的挂卡进程将会卡在这里挂一个不是游戏的“游戏”，并且无限期地等待不存在的卡牌掉落。 ASF 黑名单的目的是将这些徽章标记为无法挂卡，这样我们就可以在挂卡时直接忽略它们，不落入 Steam 的陷阱。

ASF 默认有两个黑名单——`SalesBlacklist` 是内置黑名单，无法修改，而 `Blacklist` 则是由此属性定义的普通黑名单。 `SalesBlacklist` 随 ASF 一起更新，通常包括 ASF 发布时的所有无效 AppID，所以如果您始终使用最新版 ASF，就不需要在这里手动管理 `Blacklist`。 此属性的主要目的是允许您将新的、ASF 发布时未知的不可挂卡 AppID 添加到黑名单。 内置的 `SalesBlacklist` 黑名单总是会尽快更新，因此如果您使用最新版 ASF 就不需要自己设置 `Blacklist`，但如果没有 `Blacklist` 属性，您就必须在出现新的特卖徽章时更新 ASF 以保证它能够正常运行——我不想强制您使用最新版 ASF，因此如果您不想或不能更新 ASF 的 `SalesBlacklist`，可以设置这个属性临时修复 ASF。 除非您有**充分的**理由编辑此属性，否则应将其保留为默认值。

如果您需要基于机器人设置的黑名单，请查看 `fb`、`fbadd` 和 `fbrm` **[命令](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-zh-CN)**。

---

### `CommandPrefix`

这是一个默认值为 `!` 的 `string` 类型属性。 这个属性为 ASF **[命令](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-zh-CN)**&#8203;指定一个**大小写敏感**的命令前缀。 换句话说，您需要在每条 ASF 命令前面加上这个前缀，ASF 才会执行命令。 您也可以将这个值设置为 `null` 或者空字符串，使 ASF 不使用命令前缀，在这种情况下，您可以直接向 ASF 发送不带前缀的命令。 然而，这样做会显著降低 ASF 的性能，因为 ASF 的优化策略是只解析有命令前缀 `CommandPrefix` 的消息——如果您决定去掉命令前缀，ASF 就只能读取并回应所有消息，即使这些消息不是 ASF 命令。 因此，您应该保留 `CommandPrefix`，如果您不喜欢默认的 `!`，可以将它更改为 `/` 等其他字符。 为了保证一致性，`CommandPrefix` 将会影响整个 ASF 进程。 除非您有理由编辑此属性，否则应将其保留为默认值。

---

### `ConfirmationsLimiterDelay`

这是一个默认值为 `10` 的 `byte` 类型属性。 ASF 保证至少间隔 `ConfirmationsLimiterDelay` 秒才会重新抓取两步验证确认列表，以避免触发频率限制——这一特性会应用在 **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication-zh-CN)** 操作中，例如 `2faok` 命令。在执行一些交易相关的操作时，如有需要，也会应用这一特性。 默认值基于我们的测试结果选择，如果您不想遇到问题，请不要减小这个值。 除非您有**充分的**理由编辑此属性，否则应将其保留为默认值。

---

### `ConnectionTimeout`

这是一个默认值为 `90` 的 `byte` 类型属性。 此属性定义 ASF 执行的各种网络操作的超时时间，以秒为单位。 具体来说，`ConnectionTimeout` 定义了 HTTP 与 IPC 请求的超时秒数，`ConnectionTimeout / 10` 定义了最大的心跳失败次数，而 `ConnectionTimeout / 30` 定义了初始 Steam 网络连接请求的分钟数。 对于大多数人来说，默认的 `90` 应该是合适的，但如果您的网络连接或者 PC 的速度较慢，您可能需要稍微增加这个值（例如 `120`）。 请注意，增大这个值也不能修复网络缓慢或者无法访问 Steam 服务器的问题，所以我们不应该在连接不畅的时候无限地等待下去，而是应该稍后重试。 如果将此值设置得过高，将导致网络有问题时出现严重延迟，并且降低整体性能。 将此值设置得过低也会降低整体的稳定性和性能，因为这会导致 ASF 中断尚未解析完成的有效请求。 因此，设置低于默认的值通常没有好处，因为 Steam 服务器偶尔会变得非常缓慢，需要 ASF 花费更多时间来解析请求。 我们相信网络连接是稳定的，但是不确定 Steam 是否能够在给定时间内处理完成我们的请求，此属性的默认值试图在二者之间找到平衡。 如果您希望快速发现问题，并使 ASF 更快重新连接或做出响应，就应该保留其默认值（或者稍微低于默认值，例如 `60`，降低 ASF 的等待时间）。 相反，如果您发现 ASF 遇到了网络问题，例如请求失败、心跳包丢失或者与 Steam 的连接中断，那么如果您确信其原因是 Steam 本身**而非**您的网络，则可以增大这个值，使 ASF 在重新连接之前等待更久的时间。

需要增大此属性的一种情况是让 ASF 处理超大量的交易报价，Steam 可能需要至少 2 分钟才能完全接受并处理这些报价。 增加默认的超时时间会使 ASF 更有耐心，会在决定放弃初始交易请求之前等待更长的时间。

另一种情况可能是机器或者互联网连接非常缓慢，需要更多时间来处理传输的数据。 这种情况非常罕见，因为 CPU/网络带宽几乎从来都不是瓶颈，但仍是值得一提的一种可能性。

简而言之，默认值适用于大多数情况，但如果您需要，可以增大它。 尽管如此，将这个值增大到远大于默认值也没有意义，因为增加超时也无法修复 Steam 服务器的网络问题。 除非您有理由编辑此属性，否则应将其保留为默认值。

---

### `CurrentCulture`

这是一个默认值为 `null` 的 `string` 类型属性。 默认情况下，ASF 会尝试使用您的操作系统语言，并且优先使用该语言中已翻译的字符串。 感谢我们的社区将 ASF **[本地化](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Localization-zh-CN)**&#8203;为各门主流语言。 如果处于某种原因，您不想使用操作系统的本地语言，则可以使用此属性选择另一门语言。 您可以在 **[MSDN](https://msdn.microsoft.com/en-us/library/cc233982.aspx)** 页面的 `Language tag` 标签查找所有可用的区域代码。 值得注意的是，ASF 接受包含地区的区域代码，例如 `"en-GB"`，也接受通用的区域代码，例如 `"en"`。 指定当前的区域还会影响其他与区域有关的行为，例如货币/日期格式等。 请注意，如果您选择了非本机的区域，则可能需要额外的字体/语言包才能显示该语言中的字符。 通常，如果您更喜欢以英语而不是您的母语使用 ASF，则需要更改这个属性。

---

### `Debug`

这是一个默认值为 `false` 的 `bool` 类型属性。 该属性定义是否要在调试模式下运行进程。 当启用调试模式时，ASF 会在 `config` 所在的目录创建一个特殊的 `debug` 目录，用于跟踪 ASF 与 Steam 服务器之间的所有通信。 调试信息可以帮助找出与网络相关的或者 ASF 的一般问题。 此外，这还会增加程序中某些协程的显示细节，例如 `WebBrowser` 将会显示请求失败的具体原因——这些条目将会被写入 ASF 的日志。 **您应该只在开发者告知您启用调试模式时启用它**。 以调试模式启用 ASF 将会**降低性能**、**降低稳定性**并且**输出过多信息**，所以**仅**应该在需要时才临时启用，以调试并重现特定问题，或者获取请求失败的详情等，**不应该**在正常情况下启用。 您将会看到**很多**新的错误、问题和异常——如果您决定自己分析这些信息，请确保您对 ASF、Steam 及其特点非常了解，因为不是所有信息都会与问题有关。

**警告：**&#8203;启用此模式会在日志中记录**可能敏感**的信息，例如您登录到 Steam 的用户名或密码（为了调试网络问题）。 这些数据会被写入 `debug` 目录和标准的 `log.txt` 文件（此时该文件中的日志会比平时多很多）。 您不应该公开发布 ASF 生成的调试内容，ASF 的开发者始终会提醒您通过电子邮件或者其他安全的方式发送它们。 我们既不会存储。也不会利用这些敏感信息，它们只是调试协程的一部分，并且会与您遇到的问题有关。 我们希望您提供的 ASF 日志未经任何修改，但如果您担心，可以将这些敏感信息编辑掉。

> 您可以使用星号等标记替换掉敏感的细节。 但您需要避免完全删除包含敏感信息的行，因为“它们存在”这一情况本身也可能与问题有关，应该予以保留。

---

### `DefaultBot`

这是一个默认值为 `null` 的 `string` 类型属性。 在某些场景下，如果您没有指定目标机器人，ASF 会以默认机器人的概念处理一些事情——例如 IPC 命令或交互式控制台。 此属性允许您选择默认机器人来负责处理这些场景，只需要将 `BotName` 放到这里。 如果指定的机器人不存在，或者您正常使用默认值 `null`，ASF 将选择按字母顺序排列的第一个已注册的机器人。 通常情况下，如果您希望在 IPC 或者交互式控制台命令中省略 `[Bots]` 参数，并默认总是选择同一个机器人，则会想要配置此属性。

---

### `FarmingDelay`

这是一个默认值为 `15` 的 `byte` 类型属性。 ASF 会在运行过程中，每隔 `FarmingDelay` 分钟检查当前挂卡的游戏是否已经掉落了所有的卡牌。 将此属性设置得过低将会导致发送大量的 Steam 请求，而设置得过高将会使 ASF 在挂卡完成之后仍然挂满 `FarmingDelay` 分钟。 默认值应该适合大多数用户，但如果您有很多个机器人，就可能需要考虑将其增大到类似 `30` 分钟的值，以限制发送的 Steam 请求数。 值得注意的是，ASF 使用事件驱动机制，会在掉落每个 Steam 物品时检查游戏的徽章页面，所以通常**我们甚至不需要每隔固定时间进行检查**，但我们无法完全信任 Steam 网络——如果我们在 `FarmingDelay` 分钟内没有通过卡牌掉落事件进行检查（Steam 网络没有通知我们物品掉落的消息的情况），就仍然需要主动检查游戏的徽章页面。 假设 Steam 网络工作正常，减小这个值不仅**无法增加挂卡效率**，还会**显著增加网络开销**——建议保留默认值 `15` 分钟，并仅在需要的时候增大这个值。 除非您有**充分的**理由编辑此属性，否则应将其保留为默认值。

---

### `FilterBadBots`

这是一个默认值为 `true` 的 `bool` 类型属性。 该属性定义 ASF 是否会自动拒绝已知及已被标记的不良行为者的交易报价。 为此，ASF 会在需要时与我们的服务器通信，以拉取 Steam ID 黑名单列表。 列表内的机器人由我们认为对 ASF 积极性有害的人所运行，这些行为包括违反我们的[**行为守则**](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/.github/CODE_OF_CONDUCT.md)、滥用我们提供的资源例如 [**`PublicListing`**](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin-zh-CN#publiclisting公共列表) 从他人处获利、或者进行对服务器发起 DDoS 攻击等直接的犯罪活动。 因为 ASF 对用户整体的公平、诚信与合作有坚定的立场，以使整个社区健康发展，此属性默认为启用，因此 ASF 将会过滤掉我们认为对服务有害的机器人。 除非您有**充分的**理由编辑此属性，例如不同意我们的声明并有意允许这些机器人操作（包括利用您的帐户），否则应将其保留为默认值。

---

### `GiftsLimiterDelay`

这是一个默认值为 `1` 的 `byte` 类型属性。 处理（激活）礼物/序列号/许可时，ASF 会确保两个连续的请求之间至少间隔 `GiftsLimiterDelay` 秒，以免触发频率限制。 此外，在请求游戏列表时（例如执行 `owns` [**命令**](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-zh-CN)时），也会以这个值作为全局限制。 除非您有**充分的**理由编辑此属性，否则应将其保留为默认值。

---

### `Headless`

这是一个默认值为 `false` 的 `bool` 类型属性。 该属性定义是否要在 Headless 模式下运行进程。 在 Headless 模式下，ASF 会假定自己运行于服务器或者其他非交互式环境，因此它将不会尝试在控制台输入中读取任何信息。 这包括程序请求的细节（帐户的关键凭据，如两步验证代码、Steam 令牌验证码、密码或者其他 ASF 操作所需的任何变量），以及所有其他控制台输入（例如交互式命令控制台）。 换句话说，`Headless` 模式意味着 ASF 的控制台是只读的。 此设置主要面向在服务器上运行 ASF 的用户，因为在需要向用户询问信息（例如两步验证代码）时，ASF 将会直接停用相关的帐户以中止操作。 除非您在服务器上运行 ASF，并且您已经确认 ASF 能够在非 Headless 模式下正常运行，否则应该禁用此属性。 在 Headless 模式下，任何用户交互都将被拒绝，如果您的帐户需要在启动时输入**任何**信息，则它们将不会启动。 这对于服务器来说很有用，因为 ASF 可以在要求提供凭据时中止帐户登录的尝试，而不是无限地等待用户提供凭据。 启用这一模式将允许您使用 `input` [**命令**](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-zh-CN)作为标准控制台输入的替代。 如果您不确定应该如何设置这个属性，请保留默认值 `false`。

如果您在服务器上运行 ASF，您可能需要将这个属性与 `--process-required` [**命令行参数**](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments-zh-CN)配合使用。

---

### `IdleFarmingPeriod`

这是一个默认值为 `8` 的 `byte` 类型属性。 当 ASF 没有游戏可挂卡时，它将每隔 `IdleFarmingPeriod` 小时检查帐户内是否有新游戏可以挂卡。 ASF 足够智能，能够在我们获得新游戏时自动开始检查徽章页面，此时并不需要定期检查功能。 `IdleFarmingPeriod` 主要针对帐户中已有的游戏添加了新卡牌的情况。 这种情况不会产生事件，因此这时 ASF 只能定期检查徽章页面。 将值设置为 `0` 可以禁用此功能。 还需注意属性：`ShutdownOnFarmingFinished`。

---

### `InventoryLimiterDelay`

这是一个默认值为 `4` 的 `byte` 类型属性。 ASF 会确保连续两个库存请求之间至少间隔 `InventoryLimiterDelay` 秒，以避免触发频率限制——这主要发生在获取 Steam 库存时，特别是在您执行 `loot` 或 `transfer` 等命令时。 我们基于连续获取上百个机器人库存的数据设定了默认值 `4`，这个值应该满足绝大多数用户的需求。 如果您的机器人数量很少，可能希望减小这个值甚至更改为 `0`，使 ASF 忽略延迟，更快地获取库存物品。 但请注意，设置过低的值**将会**导致 Steam 临时封禁您的 IP，彻底阻止您在这段时间内继续获取库存。 如果您有大量机器人，并且发送大量请求，则可能还需要增大此值，不过在这种情况下您可能需要考虑设法限制请求的数量。 除非您有**充分的**理由编辑此属性，否则应将其保留为默认值。

---

### `IPC`

这是一个默认值为 `true` 的 `bool` 类型属性。 这个属性定义了 ASF 的 **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-zh-CN)** 服务器是否需要随进程一同启动。 IPC 功能通过启动一个本地的 HTTP 服务器来支持不同进程间通信，包括 **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-zh-CN#asf-ui)**。 如果您不打算使用任何与 ASF 集成的第三方 IPC 程序，包括 ASF-ui，就可以安全地禁用此选项。 否则，就最好保持它默认的开启状态。

---

### `IPCPassword`

这是一个默认值为 `null` 的 `string` 类型属性。 该属性定义了每条 IPC 请求都必须附加的密码，作为一层额外的安全措施。 当此值非空时，所有的 IPC 请求都需要提供额外的 `password` 属性，其值为在此处设置的密码。 默认值 `null` 表示不需要密码，ASF 将会接受所有请求。 除此之外，启用此选项还会启用 IPC 内置的反暴力破解机制，如果某个给定的地址 `IPAddress` 在短时间内发送大量未经身份验证的请求，ASF 将会临时封禁该地址。 除非您有理由编辑此属性，否则应将其保留为默认值。

---

### `IPCPasswordFormat`

这是一个默认值为 `0` 的 `byte` 类型属性。 该属性用于定义 `IPCPassword` 属性的格式，其底层类型为 `EHashingMethod`。 如果您需要了解更多，请参考[**安全性**](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security-zh-CN)章节，确保 `IPCPassword` 属性的值确实符合 `IPCPasswordFormat` 定义的格式。 换句话说，在您更改 `IPCPasswordFormat` 时，必须确保您的 `IPCPassword` **已经**是您所选择的格式。 除非您明确了解自己在做什么，否则请将其保留为默认值 `0`。

---

### `LicenseID`

这是一个默认值为 `null` 的 `Guid?` 类型属性。 该属性允许我们的[**赞助者**](https://github.com/sponsors/JustArchi)启用需要付费资源的 ASF 可选功能，来增强其能力。 目前，您可以启用 `ItemsMatcher` 插件中的 **[`MatchActively`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin-zh-CN#matchactively主动匹配)** 特性。

我们推荐您通过 GitHub 捐赠，因为它提供了月度和一次性等级，并且支持自动即时解锁访问权限，但我们**也同样**支持所有其他可用的[**捐赠方式**](https://github.com/JustArchiNET/ArchiSteamFarm#archisteamfarm)。 阅读[**这篇帖子**](https://github.com/JustArchiNET/ArchiSteamFarm/discussions/2780#discussioncomment-4486091)，了解如何通过其他方式捐赠并获得一定时长的手动许可。

无论通过哪种渠道，只要您是 ASF 赞助者，就可以在[**这里**](https://asf.justarchi.net/User/Status)获取许可证。 您需要以 GitHub 登录来确认身份，我们只请求只读的公开信息，也就是您的用户名。 `LicenseID` 是 32 位的十六进制字符串，形如 `f6a0529813f74d119982eb4fe43a9a24`。

**请确保您不会与其他人分享您的 `LicenseID`**。 因为它是针对个人发放的，如果泄露，就可能会被撤销。 如果您意外泄露了许可证，可以在相同的位置生成一个新的。

除非您想要启用 ASF 的额外功能，否则您无需提供许可证。

---

### `LoginLimiterDelay`

这是一个默认值为 `10` 的 `byte` 类型属性。 ASF 会确保两个连续的连接尝试之间至少间隔 `LoginLimiterDelay` 秒，以免触发频率限制。 我们基于连接上百个机器人的数据设定了默认值 `10`，这个值应该满足绝大多数用户的需求。 如果您的机器人数量很少，可能希望增大或减小这个值甚至更改为 `0`，使 ASF 忽略延迟，更快地连接到 Steam。 但请注意，在有很多机器人的情况下，设置过低的值**将会**导致 Steam 临时封禁您的 IP，返回 `InvalidPassword/RateLimitExceeded` 错误，并且**彻底**阻止您继续登录——不仅 ASF，还包括您的 Steam 客户端。 同样，如果您运行大量机器人，特别是在同一 IP 内还有其他 Steam 客户端/工具运行的情况下，则很可能需要增大此值，将登录过程分配到更长的时间段内。

此外，这个值还会作为所有 ASF 计划任务的负载平衡缓冲，包括 `SendTradePeriod` 中的交易等。 除非您有**充分的**理由编辑此属性，否则应将其保留为默认值。

---

### `MaxFarmingTime`

这是一个默认值为 `10` 的 `byte` 类型属性。 正如您所应该了解的，Steam 并不总能正常工作，有时会发生一些奇怪的情况，例如在我们确实玩了游戏的情况下没有记录游戏时间。 ASF 允许在单游戏模式下将一个游戏挂到最多 `MaxFarmingTime` 小时，并在此之后认为该游戏已经挂卡完成。 如果发生了各种奇怪的情况，或者 Steam 发布了能阻止 ASF 继续挂卡的特殊徽章（见 `Blacklist`），这个属性将会防止挂卡进程彻底卡住。 对于一款游戏来说，默认值 `10` 小时应该足以获得全部卡牌。 设置过低的值可能会导致 ASF 跳过仍可掉卡的游戏（确实有需要 9 小时才能掉落全部卡牌的游戏），设置过高的值可能会导致挂卡过程卡住。 请注意，这个属性仅会影响单次挂卡过程中的单个游戏（ASF 完成一个挂卡队列之后，计时会重新开始），此外这个属性并非基于游戏时间，而是基于 ASF 自身的挂卡时间，所以 ASF 会在每次重启之后重新开始计时。 除非您有**充分的**理由编辑此属性，否则应将其保留为默认值。

---

### `MaxTradeHoldDuration`

这是一个默认值为 `15` 的 `byte` 类型属性。 该属性定义我们能够接受的最长交易暂挂时间——ASF 将会拒绝暂挂时间超过 `MaxTradeHoldDuration` 天的交易，详见[**交易**](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading-zh-CN)章节。 这个选项只对在 `TradingPreferences` 中开启了 `SteamTradeMatcher` 的机器人生效，并且不会影响来自 `Master`/`SteamOwnerID` 的交易，也不影响捐赠交易。 没有人真正愿意等待烦人的交易暂挂。 ASF 本着自由、平等交易的原则，无论对方是否有交易暂挂，都会处理交易——默认值也因此被设置为 `15`。 但是，如果您更愿意拒绝所有受交易暂挂影响的交易，可以将其设置为 `0`。 请注意，有时间限制的卡牌（例如特卖活动卡牌）不会受这一选项影响，ASF 会驳回任何有交易暂挂的交易者，如[**交易**](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading-zh-CN)章节所述，所以您不需要仅仅因为这种情况驳回所有人。 除非您有理由编辑此属性，否则应将其保留为默认值。


---

### `MinFarmingDelayAfterBlock`

这是一个默认值为 `60` 的 `byte` 类型属性。 该属性以秒为单位定义了一个最小的时间，如果 ASF 因为 `LoggedInElsewhere`（在其他设备登录）断开了连接，则会等待这么长时间再恢复挂卡，如果您决定通过运行游戏来强制使 ASF 停止挂卡，就会发生这种情况。 设置这个延迟主要是为了更方便并且节省开销，例如，您现在可以重启游戏，而不需要因为游戏状态仅仅释放了一秒钟就要重新与 ASF 争夺帐户控制权。 由于重新获取登录会话会导致 `LoggedInElsewhere` 断开连接，ASF 必须执行整个重新连接流程，这会对设备和 Steam 网络造成额外的压力，因此应该尽可能避免不必要的断开连接。 默认情况下，该属性配置为 `60` 秒，通常这么长时间应该足够您重启游戏而不遇到什么问题了。 然而，在某些场景下，您可能希望增大这个时间，例如您的网络经常断开连接，并且 ASF 接管帐户太快，就会导致您自己必须重新连接。 我们允许该属性的最大值为 `255`，这对于所有常见的情况应该都足够了。 除此之外，也可以减少甚至完全取消这个延迟，也就是设置为 `0`，但因为上文所述的原因，通常我们不建议这样做。 除非您有理由编辑此属性，否则应将其保留为默认值。

---

### `OptimizationMode`

这是一个默认值为 `0` 的 `byte` 类型属性。 该属性定义 ASF 在运行时偏好的优化模式。 目前 ASF 支持两种模式——`0` 表示 `MaxPerformance`（最优性能），`1` 表示 `MinMemoryUsage`（最小内存占用）。 默认情况下，ASF 会尝试并行（同时）运行尽可能多的任务，并通过跨 CPU 内核、多 CPU 线程、多套接字以及多线程池之间的负载均衡来优化性能。 例如，ASF 在检查需挂卡游戏时将会查询您的徽章页面第一页，在该请求完成后， ASF 将会从中读取您实际的徽章页数，然后同时向所有徽章页面发送请求。 **在绝大多数情况下**，这正是您所期待的行为，因为这样做的开销通常是最小的，即使在单核 CPU 和功率严重受限的古老硬件上，ASF 的异步代码也有明显的优势。 但是，由于许多任务是并行处理的，ASF 运行时需要维护所有任务，例如保持套接字打开、保持线程处于活动状态以及保证任务被处理，这可能会经常导致内存开销增大，如果您的可用内存受到极端的限制，就可能需要将这个属性切换为 `1`（`MinMemoryUsage`），强制 ASF 减少任务数，并尽可能以同步方式运行原本的异步代码。 只有在您已阅读[**低内存方案**](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup-zh-CN)，并且决定大量牺牲性能换取少量的内存节省的情况下，才应该考虑修改这一属性。 通常，与[**低内存方案**](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup-zh-CN)中所述的其他方式，例如限制 ASF 使用或者调优运行时环境的垃圾回收机制相比，这一选项的效果会**差得多**。 因此，如果您仍然不满意通过其他（更好的）选项进行调整的效果，则应该将 ` MinMemoryUsage` 作为重编译运行时环境之前的**最后手段**。 除非您有**充分的**理由编辑此属性，否则应将其保留为默认值。

---

### `SteamMessagePrefix`

这是一个默认值为 `"/me "` 的 `string` 类型属性。 该属性定义消息前缀，ASF 会在所有向外发出的消息前面加上这个前缀。 ASF 默认使用 `"/me "` 前缀，使机器人发出的消息在聊天中以不同颜色显示，更容易区分。 另一个不错的前缀 `"/pre "` 有着类似的效果，但是格式略有不同。 您也可以将这个属性设置为空字符串或者 `null` 完全禁用前缀，以传统的方式输出所有 ASF 消息。 值得注意的是，这个属性仅影响 Steam 消息——通过其他渠道（例如 IPC）返回的消息不受影响。 除非您希望更改 ASF 的标准行为，否则最好将其保留为默认值。

---

### `SteamOwnerID`

这是一个默认值为 `0` 的 `ulong` 类型属性。 该属性定义 ASF 进程所有者的 64 位 Steam ID，所有者（Owner）权限类似于机器人实例的 `Master` 权限，但所有者是全局的。 通常，您总是应该将这个属性设置为您的 Steam 主帐户 ID。 `Master` 权限可以完全控制给定的机器人实例，但是 `exit`、`restart` 或 `update` 等全局命令只能由 `SteamOwnerID` 用户执行。 这很方便，因为您可能需要为您的朋友运行机器人，但不允许他们控制 ASF 进程，例如发送 `exit` 退出命令。 默认值 `0` 表示 ASF 进程没有所有者，这意味着没有任何人可以发出全局 ASF 命令。 请注意此属性仅适用于 Steam 聊天。 即使没有设置此属性，您仍然可以使用 **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-zh-CN)** 和交互式控制台执行 `Owner` 权限的命令。

---

### `SteamProtocols`

这是一个默认值为 `7` 的 `byte flags` 类型属性。 此属性定义了 ASF 在连接 Steam 服务器时使用的网络协议，其定义如下：

| 值 | 名称        | 描述                                                                        |
| - | --------- | ------------------------------------------------------------------------- |
| 0 | None      | 无协议                                                                       |
| 1 | TCP       | **[传输控制协议](https://en.wikipedia.org/wiki/Transmission_Control_Protocol)** |
| 2 | UDP       | **[用户数据报协议](https://en.wikipedia.org/wiki/User_Datagram_Protocol)**       |
| 4 | WebSocket | **[WebSocket](https://en.wikipedia.org/wiki/WebSocket)**                  |

请注意，该属性是 `flags` 字段，因此可以设置为可用选项的任意组合。 如果您想了解更多，请阅读 **[JSON 映射](#json-映射)**。 不启用任何 Flag 即为 `None` 选项，并且该选项本身是无效的。

默认情况下，ASF 会使用所有可用的 Steam 协议，作为应对 Steam 服务器宕机以及其他类似问题的手段。 如果您需要将 ASF 限制为只使用其中一个或两个特定的协议，则需要更改此属性。 如果您的防火墙仅开放 TCP 流量，就可能出现这样的情况，您需要让 ASF 不再通过 UDP 进行连接。 但是，除非您正在调试特定问题，否则您通常总是希望 ASF 可以自由使用当前受支持的任何协议，而不仅仅使用其中的一两个。 除非您有**充分的**理由编辑此属性，否则应将其保留为默认值。

---

### `UpdateChannel`

这是一个默认值为 `1` 的 `byte` 类型属性。 该属性定义了 ASF 使用的更新通道，自动更新（`UpdatePeriod` 大于 `0` 时）和更新提醒（反之）功能都会用到这个属性。 目前 ASF 支持三个更新通道——`0` 表示 `None`（不更新），`1` 表示 `Stable`（稳定通道），`2` 表示 `Experimental`（实验通道）。 `Stable` 是默认的发布通道，适合大多数用户。 `Experimental` 不仅包含 `Stable`（稳定版）更新，还包括 **pre-releases**（预览版），供高级用户和其他开发者测试新特性、验证修复补丁或者对计划中的功能改进进行反馈。 **实验通道的版本通常包含未修复的漏洞、未完成的特性或者功能重写**。 如果您认为自己不属于高级用户，请保留该属性的默认值 `1`（稳定更新通道 `Stable`）。 `Experimental` 通道专门针对了解如何报告漏洞、处理问题、提交反馈的用户——我们不对此提供技术支持。 如果您想了解更多，请阅读[**发布周期**](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Release-cycle-zh-CN)。 如果您希望完全禁用版本检查，也可以将 `UpdateChannel` 设置为 `0`（`None`）。 设置 `UpdateChannel` 为 `0` 将会禁用一切与更新有关的功能，包括 `update` 命令。 **强烈不建议**您使用 `None` 通道，因为这会将您自己暴露在各种类型的问题下（见下文 `UpdatePeriod` 的说明）。

**除非您明确知道自己在做什么**，否则我们**强烈**建议您将其保留为默认值。

---

### `UpdatePeriod`

这是一个默认值为 `24` 的 `byte` 类型属性。 该属性定义了 ASF 每隔多久自动检查一次更新。 保持更新是非常重要的，更新不仅包括新特性和关键的安全补丁，还有漏洞修复、性能提升、稳定性增强等等。 当该属性的值大于 `0` 时，ASF 将会在新版本可用时自动下载、替换并重新启动自身（如果 `AutoRestart` 属性允许）。 为了实现这一目标，ASF 将会每隔 `UpdatePeriod` 小时检查 GitHub 仓库上是否有新版本。 该值为 `0` 则表示禁用自动更新，但您仍然可以手动执行 `update` 命令。 您可能还需要为 `UpdatePeriod` 设置合适的 `UpdateChannel` 属性。

ASF 的更新过程会完全更新 ASF 使用的目录结构，但不包括您存放在 `config` 文件夹中的配置文件和数据库——这意味着在 ASF 文件夹中的任何无关文件都会在更新过程中丢失。 默认值 `24` 足以保证 ASF 始终是新版本，但又不会进行过多不必要的更新检查。

除非您有**充分的**理由禁用该功能，否则应该保持自动更新功能启用，并且 `UpdatePeriod` 的值**符合您的需求**。 这不仅因为我们只会对最新稳定版 ASF 提供支持，还因为我们也**只保证最新版本是安全的**。 如果您使用过时版本的 ASF，就会将自己暴露在各种问题下，例如小漏洞、功能失效，甚至 **[Steam 帐户永久停用](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ-zh-CN#曾经有人因此被封禁吗)**，所以我们**强烈建议**，为了您自己的利益，始终确保使用 ASF 的最新版本。 自动更新使我们能够快速反应，在造成严重后果之前禁用或修复有问题的代码——如果您禁用了自动更新，将会失去我们的一切安全保证，并且需要自己承担可能运行有害代码的风险，这些有害代码既有可能对 Steam 网络有害，也可能对您的 Steam 帐户有害。

---

### `WebLimiterDelay`

这是一个默认值为 `300` 的 `ushort` 类型属性。 该属性定义了连续向同一个 Steam Web 服务发送两个请求之间的最小延迟，单位为毫秒。 需要延迟的原因是，Steam 使用的 **[AkamaiGhost](https://www.akamai.com)** 服务内部限制了给定时间内总请求的数量。 通常情况下，很难触发 Akamai 的封禁，但在请求队列中挤压了大量请求导致负载繁重的的情况下，如果我们在短时间内发送了大量的请求，就可能触发封禁。

我们假定 ASF 是唯一访问 Steam Web 服务的工具，并以此设置了此属性的默认值，其中 Steam 服务主要包括 `steamcommunity.com`、`api.steampowered.com` 和 `store.steampowered.com`。 如果您同时使用了也向这些 Web 服务发送请求的其他工具，就应该确保这些工具也含有类似 `WebLimiterDelay` 的功能，并分别将两者设置为双倍默认值，即 `600`。 这保证了在任何情况下，您都不会在 `300` 毫秒内发送超过 1 个请求。

通常，**强烈不建议**您将 `WebLimiterDelay` 减小到默认值以下，因为这可能会导致您的 IP 被封禁，在严重的情况下，该封禁甚至是永久的。 默认值已经足以在服务器上运行单个 ASF 实例，或者在正常情景下同时使用 ASF 与原版 Steam 客户端。 这个值应该在绝大多数情况下都是正确的，您只应该在此基础上继续增大（永远不要减小）。 简而言之，从单个 IP 向单个 Steam 域名发送的总请求永远不要超过每 `300` 毫秒 1 个请求。

除非您有理由编辑此属性，否则应将其保留为默认值。

---

### `WebProxy`

这是一个默认值为 `null` 的 `string` 类型属性。 该属性定义了一个 Web 代理地址，ASF 的 `HttpClient` 发送的所有 HTTP 和 HTTPS 请求都会经过此代理，特别是其中的 `github.com`、`steamcommunity.com` 和 `store.steampowered.com` 服务。 为 ASF 请求设置代理通常没有额外的好处，但对于绕过各种形式的防火墙（特别是中国的网络防火墙）非常有用。

此属性定义为一个 URI 字符串：

> URI 字符串由协议（支持 http/https/socks4/socks4a/socks5）、主机和可省略的端口组成。 一个完整 URI 字符串的示例是 `"http://contoso.com:8080"`。

如果您的代理服务器需要身份验证，您还需要设置 `WebProxyUsername` 和/或 `WebProxyPassword` 属性。 如果不需要验证，就只需要设置此属性。

目前，ASF 仅对 `HTTP` 和 `HTTPS` 请求使用代理，**不包括** ASF 内置 Steam 客户端进行的内部 Steam 网络通信。 目前我们没有计划支持这类通信，其主要原因是 **[SK2](https://github.com/SteamRE/SteamKit/issues/587#issuecomment-413271550)** 缺少相关的功能。 如果您需要/希望 ASF 支持代理这部分通信，可以从了解 SK2 开始。

除非您有理由编辑此属性，否则应将其保留为默认值。

---

### `WebProxyPassword`

这是一个默认值为 `null` 的 `string` 类型属性。 该属性定义了提供代理功能的目标计算机 `WebProxy` 所支持的 Basic、Digest、NTLM 或 Kerberos 身份验证方式使用的密码。 如果您的代理不需要用户提供凭据，就不需要在这里输入任何内容。 该属性只有在您设置了 `WebProxy` 属性的情况下才会生效。

除非您有理由编辑此属性，否则应将其保留为默认值。

---

### `WebProxyUsername`

这是一个默认值为 `null` 的 `string` 类型属性。 该属性定义了提供代理功能的目标计算机 `WebProxy` 所支持的 Basic、Digest、NTLM 或 Kerberos 身份验证方式使用的用户名。 如果您的代理不需要用户提供凭据，就不需要在这里输入任何内容。 该属性只有在您设置了 `WebProxy` 属性的情况下才会生效。

除非您有理由编辑此属性，否则应将其保留为默认值。

---

## 机器人配置

您应该已经了解，每个机器人都有自己的配置文件，其 JSON 结构如下文的示例。 首先，您需要决定机器人的名称（例如 `1.json`、`main.json`、`primary.json` 或者随便什么名字 `AnythingElse.json`，然后再开始配置。

**注意：** 机器人不能被命名为 `ASF`（因为该关键字是留给全局配置文件的），ASF 也会忽略所有以点号开头的配置文件。

机器人配置文件有如下的结构：

```json
{
    "AcceptGifts": false,
    "AutoSteamSaleEvent": false,
    "BotBehaviour": 0,
    "CompleteTypesToSend": [],
    "CustomGamePlayedWhileFarming": null,
    "CustomGamePlayedWhileIdle": null,
    "Enabled": false,
    "EnableRiskyCardsDiscovery": false,
    "FarmingOrders": [],
    "FarmPriorityQueueOnly": false,
    "GamesPlayedWhileIdle": [],
    "HoursUntilCardDrops": 3,
    "LootableTypes": [1, 3, 5],
    "MatchableTypes": [5],
    "OnlineFlags": 0,
    "OnlineStatus": 1,
    "PasswordFormat": 0,
    "Paused": false,
    "RedeemingPreferences": 0,
    "RemoteCommunication": 3,
    "SendOnFarmingFinished": false,
    "SendTradePeriod": 0,
    "ShutdownOnFarmingFinished": false,
    "SkipRefundableGames": false,
    "SteamLogin": null,
    "SteamMasterClanID": 0,
    "SteamParentalCode": null,
    "SteamPassword": null,
    "SteamTradeToken": null,
    "SteamUserPermissions": {},
    "TradeCheckPeriod": 60,
    "TradingPreferences": 0,
    "TransferableTypes": [1, 3, 5],
    "UseLoginKeys": true,
    "UserInterfaceMode": 0
}
```

---

下面是对所有选项的解释：

### `AcceptGifts`

这是一个默认值为 `false` 的 `bool` 类型属性。 当启用时，ASF 会自动接受并激活所有发送给此机器人的 Steam 礼物（包括钱包礼物卡）。 不在 `SteamUserPermissions` 中的用户发来的礼物也算在内。 请注意，发送到电子邮箱的礼物不会直接转发给客户端，所以 ASF 无法自动接受这种礼物，除非您提供帮助。

仅建议您在子帐户上启用此选项，因为有可能您不希望在主帐户上自动激活所有礼物。 如果您不确定是否要启用此功能，请保留默认值 `false`。

---

### `AutoSteamSaleEvent`

这是一个默认值为 `false` 的 `bool` 类型属性。 在 Steam 夏季/冬季特卖活动期间，您每天可以通过浏览探索队列或者其他活动事件获得额外的集换式卡牌。 启用此选项时，ASF 将会每隔 `8` 小时自动检查 Steam 探索队列（从程序启动一小时后开始），并且在需要时浏览完成这些探索队列。 如果您希望自己手动执行这些操作，则不建议使用此选项，通常情况下，该功能仅对纯机器人帐户有意义。 此外，如果您希望收到这些卡牌，首先要确保您的帐户至少达到 `8` 级，这是 Steam 本身的限制。 如果您不确定是否要启用此功能，请保留默认值 `false`。

请注意，由于 Valve 经常造成问题或变更，**我们无法保证此功能正常工作**，因此该选项是有可能**完全无效**的。 我们不接受**任何**与此有关的漏洞报告，也不支持关于此选项的请求。 该属性是在完全无保证的情况下提供的，您需要自行承担风险。

---

### `BotBehaviour`

这是一个默认值为 `0` 的 `byte flags` 类型属性。 该属性定义 ASF 机器人在各种事件中的自动化行为，可选项如下：

| 值  | 名称                            | 描述                                    |
| -- | ----------------------------- | ------------------------------------- |
| 0  | None                          | 无特殊行为，对帐户的控制最少，默认选项                   |
| 1  | RejectInvalidFriendInvites    | 使 ASF 拒绝（而不是忽略）无效的好友邀请                |
| 2  | RejectInvalidTrades           | 使 ASF 拒绝（而不是忽略）无效的交易报价                |
| 4  | RejectInvalidGroupInvites     | 使 ASF 拒绝（而不是忽略）无效的组邀请                 |
| 8  | DismissInventoryNotifications | 使 ASF 自动去除所有库存通知                      |
| 16 | MarkReceivedMessagesAsRead    | 使 ASF 自动将所有消息标记为已读                    |
| 32 | MarkBotMessagesAsRead         | 使 ASF 自动将来自其他 ASF 机器人（同一个实例下）的消息标记为已读 |

请注意，该属性是 `flags` 字段，因此可以设置为可用选项的任意组合。 如果您想了解更多，请阅读 **[JSON 映射](#json-映射)**。 不启用任何 Flag 即为 `None` 选项。

通常，如果您希望一个 ASF 机器人帐户（而非主帐户）根据情况进行一些自动化操作，则需要修改此属性。 因此，该选项主要用于子帐户，但您也可以为主帐户设定这些属性。

标准（`None`）ASF 行为表示仅仅自动化用户所需的操作（例如自动挂卡或者处理 `TradingPreferences` 属性中设定的 `SteamTradeMatcher` 交易报价）。 这是对帐户行为影响最小的模式，适用于大多数用户，因为您可以完全控制帐户，自己决定是否允许帐户执行一些超出范围的操作。

无效的好友邀请指的是来自于没有 `FamilySharing` 或更高权限（在 `SteamUserPermissions` 中定义）的用户发来的好友邀请。 在标准模式下，ASF 会如您所期望的那样忽略这些邀请，您可以自行选择是否接受这些邀请。 `RejectInvalidFriendInvites` 会导致这些邀请被自动拒绝，这实际上阻止了其他人将您添加到好友列表（因为 ASF 会拒绝这些邀请，除非对方在您定义的 `SteamUserPermissions` 列表中）。 除非您想要完全拒绝所有好友邀请，否则不应该启用此选项。

无效的交易报价指的是不被 ASF 内置交易模块接受的报价。 关于这一情况的更多信息，可以在[**交易**](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading-zh-CN)章节中找到，这一章节明确定义了 ASF 将会自动接受何种类型的交易报价。 有效的交易报价也由其他属性定义，特别是 `TradingPreferences`。 `RejectInvalidTrades` 会导致所有无效的交易报价被拒绝而不是仅仅忽略。 除非您想要完全拒绝所有 ASF 未自动接受的交易报价，否则不应该启用此选项。

无效的群组邀请指的是来自 `SteamMasterClanID` 以外群组的邀请。 在标准模式下，ASF 会如您所期望的那样忽略这些群组邀请，您可以自行选择是否加入这些群组。 `RejectInvalidGroupInvites` 会导致这些群组邀请被自动拒绝，使 `SteamMasterClanID` 以外的任何群组都无法邀请您加入。 除非您想要完全拒绝所有群组邀请，否则不应该启用此选项。

如果您开始厌烦获得新物品的 Steam 通知，`DismissInventoryNotifications` 则是一个相当有用的选项。 ASF 无法禁用通知本身，因为该功能是 Steam 客户端的内置功能，但它能够在收到通知后自动清除通知，使您不再看到烦人的“库存中的新物品”消息。 如果您希望自己检查所有收到的物品（特别是 ASF 挂到的卡牌），那么显然您不应该启用此选项。 但如果您因太多通知而疯狂，请记住您随时可以启用这个选项。

`MarkReceivedMessagesAsRead` 会自动将 ASF 运行的帐户收到的**所有**消息标记为已读，包括私人和群组聊天。 此功能通常用来清除子帐户的“新聊天消息”通知，这些消息可能来自于您向机器人发送的命令。 我们不建议为主帐户启用此选项，除非您希望完全无视任何新消息通知，**包括**在您离线时收到的消息，因为 ASF 仍然会在后台为您消除这些通知。

`MarkBotMessagesAsRead` 的运作方式很相似，但只会将机器人的消息标记为已读。 但要注意的是，如果您的机器人和其他人都在群组聊天中，Steam 在将一条消息标记为已读时，**同样**会标记此消息**之前**的所有消息，所以如果您不希望错过这之间的其他消息，就不应该启用此功能。 显然，如果您在同一个 ASF 实例上运行了多个主帐户（例如，属于其他人的帐户），也可能会出现问题，因为您有可能错过正常的、与 ASF 无关的消息。

如果您不确定如何配置此选项，最好将其保留为默认值。

---

### `CompleteTypesToSend`

这是一个默认值为空的 `ImmutableHashSet<byte>` 类型属性。 当 ASF 完成收集符合此处设置类型的一组物品时，它可以通过 Steam 交易自动将所有已经完成的物品套组发送给拥有 `Master` 权限的用户，如果您将机器人帐户用于 STM 匹配等需求，此功能可以非常方便地将已收集全的套组发送到另一个帐户。 此选项的运作方式与 `loot` 命令相同，因此请注意，您需要先正确为用户设置 `Master` 权限，并且设置有效的 `SteamTradeToken`，并且还要保证此帐户原本就能够进行交易。

目前，此设置支持以下物品类型：

| 值 | 名称              | 描述                       |
| - | --------------- | ------------------------ |
| 3 | FoilTradingCard | 闪亮集换式卡牌（`TradingCard`）   |
| 5 | TradingCard     | 用来合成徽章的 Steam 集换式卡牌（非闪亮） |

请注意，无论如何设置上述选项，ASF 都只会处理 [**Steam 社区物品**](https://steamcommunity.com/my/inventory/#753_6)（`appID` 为 753，`contextID` 为 6），所以所有的游戏物品、礼物等都会被排除在交易报价之外。

由于启用此选项会带来额外开销，我们建议您只在确实有机会自行集齐物品的机器人上启用——例如，如果您平时已经使用 `SendOnFarmingFinished`、`SendTradePeriod` 或 `loot` 命令来收集物品，就没有必要使用此选项。

如果您不确定如何配置此选项，最好将其保留为默认值。

---

### `CustomGamePlayedWhileFarming`

这是一个默认值为 `null` 的 `string` 类型属性。 ASF 可以在挂卡时显示“非 Steam 游戏中：`CustomGamePlayedWhileFarming`“，而不是正在挂卡的游戏名。 如果您希望好友们明白您正在挂卡，但是又不想将 `OnlineStatus` 设置为 `Offline`，则可以设置这个属性。 请注意，ASF 不能保证 Steam 网络的实际显示顺序，因此这只是一个建议值，或许能正常显示，或许不能。 特别是，如果 ASF 已经在 `Complex` 算法下填满 `32` 游戏数来挂游戏时长，就无法显示自定义游戏名。 默认值 `null` 将会禁用此功能。

ASF 提供了一些您可以在文本中使用的特殊变量。 `{0}` 会被 ASF 替换为当前挂卡游戏的 `AppID`， `{1}` 会被 ASF 替换为当前挂卡游戏的名称。

---

### `CustomGamePlayedWhileIdle`

这是一个默认值为 `null` 的 `string` 类型属性。 类似于 `CustomGamePlayedWhileFarming`，但该属性设置的是 ASF 闲置时（挂卡完成后）显示的内容。 请注意，ASF 不能保证 Steam 网络的实际显示顺序，因此这只是一个建议值，或许能正常显示，或许不能。 如果您同时使用 `GamesPlayedWhileIdle` 选项，那么请注意 `GamesPlayedWhileIdle` 会更优先，因此您不可以设置超过 `31` 款游戏，否则 `CustomGamePlayedWhileIdle` 选项就无法占用游戏数来显示自定义游戏名。 默认值 `null` 将会禁用此功能。

---

### `Enabled`

这是一个默认值为 `false` 的 `bool` 类型属性。 该属性定义了是否启用此机器人。 已启用（`true`）的机器人实例将会在 ASF 启动后自动开始运行，而已禁用（`false`）的机器人就必须由您手动启动。 默认情况下，所有机器人都是被禁用的，所以需要为每个需要自动运行的机器人设置该属性为 `true`。

---

### `EnableRiskyCardsDiscovery`

这是一个默认值为 `false` 的 `bool` 类型属性。 该属性启用额外的回退机制，在 ASF 因为无法加载一个或多个徽章页面而无法找到可以挂卡的游戏时激活。 特别是，一些掉落卡片数量极大的帐户可能会遇到根本无法加载徽章页面的情况（由于服务端性能），这些帐户也无法专门用于挂卡，因为我们无法获取要启动挂卡流程所需的信息。 对于这些少数情况，此选项允许使用替代算法，即将可合成的补充包与当前帐户可用的补充包结合起来，以找出潜在的可挂卡游戏，然后消耗大量资源来验证和获取所需信息，并尝试在数据和信息有限的情况下开始挂卡过程，以便最终使徽章页面能够加载，我们也可以回归到正常的算法。 请注意，激活此回退方法时，ASF 只能基于有限数据操作，因此，如果 ASF 找到的掉落数量比实际低，是完全正常的——其他的掉落数量会在挂卡的后续阶段逐渐被发现。

此选项被认为“有风险”是有原因的——它的过程非常缓慢，还需要消耗大量的资源（包括网络请求）才能运作，因此**不推荐**启用，更不推荐长期启用。 您只应该在认为当前的帐户正因为无法加载徽章页面导致 ASF 失效，无法加载挂卡流程所需必要信息的情况下使用此选项。 即使我们尽最大努力优化这一流程，此选项仍然可能会造成预料之外的结果，例如因为发送过多请求、对 Steam 服务器造成性能压力而导致临时甚至永久 Steam 封禁。 因此，我们提前警告过您，并在完全无保证的情况下提供此选项，您需要自行承担风险。

除非您明确了解自己在做什么，否则请将其保留为默认值 `false`。

---

### `FarmingOrders`

这是一个默认值为空的 `ImmutableList<byte>` 类型属性。 该属性定义了 ASF 为此机器人帐户设定的**首选**挂卡顺序。 目前支持以下挂卡顺序：

| 值  | 名称                        | 描述                      |
| -- | ------------------------- | ----------------------- |
| 0  | Unordered                 | 不排序，略微提升 CPU 性能         |
| 1  | AppIDsAscending           | 尝试先挂 `appID` 最低的游戏      |
| 2  | AppIDsDescending          | 尝试先挂 `appID` 最高的游戏      |
| 3  | CardDropsAscending        | 尝试先挂剩余掉落卡牌最少的游戏         |
| 4  | CardDropsDescending       | 尝试先挂剩余掉落卡牌最多的游戏         |
| 5  | HoursAscending            | 尝试先挂游戏时间最短的游戏           |
| 6  | HoursDescending           | 尝试先挂游戏时间最长的游戏           |
| 7  | NamesAscending            | 尝试以字母顺序挂游戏，从 A 开始       |
| 8  | NamesDescending           | 尝试以字母逆序挂游戏，从 Z 开始       |
| 9  | Random                    | 尝试以完全随机顺序挂游戏（每次运行程序都不同） |
| 10 | BadgeLevelsAscending      | 尝试先挂徽章等级最低的游戏           |
| 11 | BadgeLevelsDescending     | 尝试先挂徽章等级最高的游戏           |
| 12 | RedeemDateTimesAscending  | 尝试先挂帐户内最早的游戏            |
| 13 | RedeemDateTimesDescending | 尝试先挂帐户内最新的游戏            |
| 14 | MarketableAscending       | 尝试先挂掉落卡牌无法出售的游戏         |
| 15 | MarketableDescending      | 尝试先挂掉落卡牌可以出售的游戏         |

由于此属性是一个数组，因此您可以按不同优先级使用多种排序方式。 例如，您可以按顺序选择方式 `15`、`11` 和 `7`，首先按照卡牌能否出售排序，然后按照徽章等级排序，最后按照字母顺序排序。 您可能已经猜到，选项的顺序很重要，如果您反转该属性的选项（`7`、`11` 和 `15`），则结果会完全不同（先按字母顺序排序，由于游戏名称非常独特，此时其他两个选项几乎不会起作用）。 大多数用户可能只需要从中选择一种排序方式，但如果您想进一步调整挂卡顺序，也可以添加多种排序方式。

需要注意的是上表中所有描述都含有词汇“尝试”——ASF 实际采用的顺序非常受所选的[**挂卡算法**](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance-zh-CN)影响，并且 ASF 只会在不影响性能的情况下尝试进行排序。 例如，在使用 `Simple` 算法时，当前挂卡会话将会严格按照您设置的 `FarmingOrders` 排序（因为每款游戏的性能值都相同），而在使用 `Complex` 算法时，实际的挂卡顺序首先受游戏小时数影响，然后才按照 `FarmingOrders` 排序。 这会导致不同的结果，因为已有游戏时间的游戏将会优于其他游戏，因此 ASF 会首先挂游戏时长已满足 `HoursUntilCardDrops` 要求的游戏，然后才按照您设置的 `FarmingOrders` 顺序挂其他游戏。 同样地，ASF 在挂完了所有时长达标的游戏之后，会将剩余的游戏按照游戏小时数排序（因为这能够减少将游戏时长挂到 `HoursUntilCardDrops` 所需的时间）。 因此，这个配置属性仅仅是为 ASF 提供的一个**建议**，ASF 会在不降低挂卡性能的情况下尽量遵守（在二者有冲突时，ASF 会优先考虑性能而不是 `FarmingOrders`）。

此外，您可以通过 `fq` [**命令**](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-zh-CN)访问“优先挂卡队列”。 如果使用这个队列，则实际的挂卡顺序首先由性能决定，其次受优先挂卡队列影响，最后才是 `FarmingOrders`。

---

### `FarmPriorityQueueOnly`

这是一个默认值为 `false` 的 `bool` 类型属性。 这个属性定义 ASF 是否应该仅自动挂您通过 `fq` [**命令**](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-zh-CN)添加到优先挂卡队列内的应用。 在启用此选项时，ASF 将会跳过所有不在队列中的 `appIDs`，使您可以选择性地忽略 ASF 自动挂卡的游戏。 请记住，如果您没有向队列中添加任何游戏，ASF 就会表现得像您的帐户中没有游戏可以挂卡。 如果您不确定是否要启用此功能，请保留默认值 `false`。

---

### `GamesPlayedWhileIdle`

这是一个默认值为空的 `ImmutableHashSet<uint>` 类型属性。 如果 ASF 没有游戏可以挂卡，您可以让它运行指定的 Steam 游戏（`appIDs`）。 以这种方式玩游戏会增加您的游戏时间，但这也是唯一的作用。 若要此功能正常工作，您的 Steam 帐户**必须**拥有所有您指定的 `appIDs` 的有效许可，包括免费游戏。 此功能可以与 `CustomGamePlayedWhileIdle` 一同启用，在运行指定游戏的同时，使 Steam 网络显示自定义的状态信息，但在这种情况下，与 `CustomGamePlayedWhileFarming` 的情况类似，我们无法保证实际的显示顺序。 请注意，Steam 只允许 ASF 同时运行最多 `32` 款游戏（`appIDs`），因此您也只能在该属性中设置这么多游戏。

---

### `HoursUntilCardDrops`

这是一个默认值为 `3` 的 `byte` 类型属性。 该属性定义帐户是否卡牌掉落受限，并且如果受限，其初始掉卡时长是多少小时。 卡牌掉落受限意味着此帐户在运行指定游戏时，游戏时长必须达到 `HoursUntilCardDrops` 小时才会开始掉落卡牌。 但 ASF 没有自动检测该属性的魔法，所以只能由您来手动设置。 这个属性会影响对[**挂卡算法**](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance-zh-CN)的选择。 正确设置此属性将会最大化您的收益，并且节约挂卡所需的时间。 请记住，您应该选择某个值还是另一个值，并没有明显的答案，因为这完全取决于您的帐户。 看起来从未退款的较早帐户不会受限，应该将值设置为 `0`，而曾经退款的新帐户会受限，通常应该设置为 `3`。 然而这只是一种理论，不应该将其当作规则。 该默认值是两害相权取其轻的结果，可以适用于大多数情况。

---

### `LootableTypes`

这是一个默认值为 Steam 物品类型 `1, 3, 5` 的 `ImmutableHashSet<byte>` 类型属性。 这个属性定义 ASF 拾取操作的行为——这既包括通过[**命令**](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-zh-CN)触发的手动拾取，也包括通过各种配置属性设置的自动拾取。 ASF 会确保交易报价内只包含 `LootableTypes` 类型的物品，因此，这个属性使您可以选择您希望从交易报价中获得何种物品。

| 值  | 名称                    | 描述                        |
| -- | --------------------- | ------------------------- |
| 0  | Unknown               | 不符合以下情况的任何类型              |
| 1  | BoosterPack           | 包含某游戏随机 3 张卡牌的补充包         |
| 2  | Emoticon              | Steam 聊天中使用的表情            |
| 3  | FoilTradingCard       | 闪亮集换式卡牌（`TradingCard`）    |
| 4  | ProfileBackground     | 在 Steam 个人资料上使用的个人资料背景    |
| 5  | TradingCard           | 用来合成徽章的 Steam 集换式卡牌（非闪亮）  |
| 6  | SteamGems             | 用来制作补充包的 Steam 宝石，包括成袋的宝石 |
| 7  | SaleItem              | Steam 特卖期间的特殊奖励物品         |
| 8  | Consumable            | 使用后消失的特殊消耗品               |
| 9  | ProfileModifier       | 修改 Steam 个人资料外观的特殊物品      |
| 10 | Sticker               | Steam 聊天中使用的特殊物品（聊天贴纸）    |
| 11 | ChatEffect            | Steam 聊天中使用的特殊物品（聊天室效果）   |
| 12 | MiniProfileBackground | Steam 个人资料迷你背景            |
| 13 | AvatarProfileFrame    | Steam 个人资料头像边框            |
| 14 | AnimatedAvatar        | Steam 个人资料动画头像            |
| 15 | KeyboardSkin          | Steam Deck 的特殊键盘皮肤        |
| 16 | StartupVideo          | Steam Deck 的特殊启动影片        |

请注意，无论如何设置上述选项，ASF 都只会处理 [**Steam 社区物品**](https://steamcommunity.com/my/inventory/#753_6)（`appID` 为 753，`contextID` 为 6），所以所有的游戏物品、礼物等都会被排除在交易报价之外。

默认值的设定基于机器人的最常见用法，即仅仅拾取补充包和集换式卡牌（包括闪亮卡牌）。 您可以更改此属性，将机器人的行为调整至令您满意。 请记住，上表未定义的所有类型都会显示为 `Unknown`，特别是在 Valve 发布一些新 Steam 物品时，ASF 也会将它们标记为 `Unknown`，直到它们（在未来版本中）被添加到这个表格中。 这也是为何一般不建议在 `LootableTypes` 中包含 `Unknown` 类型，除非您了解您正在做什么，并且明白如果 Steam 网络出现故障，将所有物品当作 `Unknown`，ASF 将会在交易报价中发送整个库存内的物品。 我强烈建议，即使您希望拾取所有（其他）类型的物品，也不要在 `LootableTypes` 中包含 `Unknown`。

---

### `MatchableTypes`

这是一个默认值为 Steam 物品类型 `5` 的 `ImmutableHashSet<byte>` 类型属性。 此属性定义了当您启用 `TradingPreferences` 中的 `SteamTradeMatcher` 选项时，允许用于匹配的 Steam 物品类型。 可用类型如下：

| 值  | 名称                    | 描述                        |
| -- | --------------------- | ------------------------- |
| 0  | Unknown               | 不符合以下情况的任何类型              |
| 1  | BoosterPack           | 包含某游戏随机 3 张卡牌的补充包         |
| 2  | Emoticon              | Steam 聊天中使用的表情            |
| 3  | FoilTradingCard       | 闪亮集换式卡牌（`TradingCard`）    |
| 4  | ProfileBackground     | 在 Steam 个人资料上使用的个人资料背景    |
| 5  | TradingCard           | 用来合成徽章的 Steam 集换式卡牌（非闪亮）  |
| 6  | SteamGems             | 用来制作补充包的 Steam 宝石，包括成袋的宝石 |
| 7  | SaleItem              | Steam 特卖期间的特殊奖励物品         |
| 8  | Consumable            | 使用后消失的特殊消耗品               |
| 9  | ProfileModifier       | 修改 Steam 个人资料外观的特殊物品      |
| 10 | Sticker               | Steam 聊天中使用的特殊物品（聊天贴纸）    |
| 11 | ChatEffect            | Steam 聊天中使用的特殊物品（聊天室效果）   |
| 12 | MiniProfileBackground | Steam 个人资料迷你背景            |
| 13 | AvatarProfileFrame    | Steam 个人资料头像边框            |
| 14 | AnimatedAvatar        | Steam 个人资料动画头像            |
| 15 | KeyboardSkin          | Steam Deck 的特殊键盘皮肤        |
| 16 | StartupVideo          | Steam Deck 的特殊启动影片        |

当然，您应该设置的类型通常只有 `2`、`3`、`4` 和 `5`，因为 STM 只支持这些类型。 ASF 的逻辑能够正确地获取物品的稀有程度，因此匹配表情或背景也是安全的，因为 ASF 只会将来自同一游戏、同一物品类型以及稀有程度相同的物品视为相等。

请注意，**ASF 不是交易机器人**，并且**不会考虑物品在社区市场上的价格**。 如果您认为同一组中稀有度相同的物品价值不同，则此选项不适合您。 如果您决定更改此设置，请再次确认您理解并同意以上声明。

除非您明确了解自己在做什么，否则请将其保留为默认值 `5`。

---

### `OnlineFlags`

这是一个默认值为 `0` 的 `ushort flags` 类型属性。 此属性可以作为 **[`OnlineStatus`](#onlinestatus)** 的补充功能，向 Steam 网络公布额外的在线状态信息。 此选项需要 **[`OnlineStatus`](#onlinestatus)** 不为 `Offline`，可选值如下：

| 值    | 名称                | 描述             |
| ---- | ----------------- | -------------- |
| 0    | None              | 无特殊在线状态，默认值    |
| 256  | ClientTypeWeb     | 客户端正在使用 Web 界面 |
| 512  | ClientTypeMobile  | 客户端正在使用移动平台应用  |
| 1024 | ClientTypeTenfoot | 客户端正在使用大屏幕模式   |
| 2048 | ClientTypeVR      | 客户端正在使用 VR 头显  |

请注意，该属性是 `flags` 字段，因此可以设置为可用选项的任意组合。 如果您想了解更多，请阅读 **[JSON 映射](#json-映射)**。 不启用任何 Flag 即为 `None` 选项。

此属性底层的 `EPersonaStateFlag` 类型包括更多可用 Flag，但据我们所知，它们目前并不会有实际效果，因而没有在此包含。

如果您不确定应该如何设置这个属性，请保留默认值 `0`。

---

### `OnlineStatus`

这是一个默认值为 `1` 的 `byte` 类型属性。 该属性指定机器人登录 Steam 网络之后显示的 Steam 状态。 目前您可以选择下列状态之一：

| 值 | 名称                  |
| - | ------------------- |
| 0 | Offline（离线）         |
| 1 | Online（在线）          |
| 2 | Busy（忙碌）            |
| 3 | Away（离开）            |
| 4 | Snooze（打盹）          |
| 5 | LookingToTrade（想交易） |
| 6 | LookingToPlay（想玩游戏） |
| 7 | Invisible（隐身）       |

`Offline` 状态比较适合主帐户。 您应该知道，挂卡会使您的帐户状态显示为“游戏中：XXX”，这可能会误导您的朋友，使他们认为您真的在玩游戏。 使用 `Offline` 状态可以解决这个问题——您的帐户将不会在 ASF 挂卡时显示您在“游戏中”。 能够这样做的原因是 ASF 不需要登录到 Steam 社区就可以正常工作，所以我们实际运行了这些游戏、连接到了 Steam 网络，但是没有向其他人告知我们在线。 请注意，在离线状态下进行游戏仍然会增加您的游戏时间，您个人资料页面的“最新动态”栏也会显示这些游戏。

此外，如果您在不同时启动 Steam 客户端的情况下运行 ASF，但仍然希望收到通知和未读消息，也应该设置这个选项。 这是因为 ASF 本身就是一个 Steam 客户端，无论 ASF 是否愿意，Steam 都会向它广播这些消息和事件。 如果您同时运行 ASF 和 Steam 客户端，这就不是什么问题，因为每个客户端都会收到完全相同的事件广播。 但如果只有 ASF 在运行，Steam 就会将某些事件与消息标记为“已送达”，但您的原版 Steam 客户端因为不在线而无法收到这些消息。 离线状态可以解决这个问题，因为在这种情况下，ASF 将不再接收任何社区事件，因此所有未读消息和其他事件都会在您返回时保持未读状态。

需要特别注意的是，在 `Offline` 模式下运行的 ASF 将**无法**通过 Steam 聊天接收命令，因为此时 ASF 与聊天服务器甚至整个 Steam 社区都是未连接的。 解决此问题的方法是使用 `Invisible` 隐身模式，它类似于离线模式（不暴露您的状态），但是仍然可以接收与响应消息（所以仍然有上述的消除您的未读消息的问题）。 `Invisible` 模式主要适用于您不想暴露状态，但是仍需要发送命令的子帐户。

但是，`Invisible` 模式的问题在于，它并不适合主帐户。 这是因为**任何**在线的 Steam 会话都会**公开**其在线状态，即使 ASF 不希望这样做。 这是由目前的 Steam 网络的限制/漏洞导致的，无法由 ASF 修复，所以如果您希望使用 `Invisible` 模式，就需要确保登录同一帐户的其他**所有**会话也都设置为 `Invisible` 隐身状态。 对于子帐户，ASF 通常就是其唯一的活动会话，但对于主帐户来说，通常您需要向您的朋友们显示 `Online` 状态，仅仅隐藏 ASF 的活动，此时 `Invisible` 模式就会完全失效（建议您在此时以 `Offline` 模式代替）。 希望 Valve 能够在将来解决这个限制/漏洞，但我不认为这能在短期内实现……

如果您不确定如何设置这个属性，建议您为主帐户设置 `0`（`Offline`），为其他帐户保留默认值 `1`（`Online`）。

---

### `PasswordFormat`

这是一个默认值为 `0`（`PlainText`）的 `byte` 类型属性。 该属性定义了 `SteamPassword` 的格式，目前支持的选项值详见[**安全性**](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security-zh-CN)章节。 您应该跟随那里的步骤，因为您需要确保 `SteamPassword` 属性的确按照 `PasswordFormat` 指定的格式存储了密码。 换句话说，在您更改 `PasswordFormat` 时，必须确保您的 `SteamPassword` **已经**是您所选择的格式。 除非您明确了解自己在做什么，否则请将其保留为默认值 `0`。

---

### `Paused`

这是一个默认值为 `false` 的 `bool` 类型属性。 这个属性定义了机器人 `CardsFarmer` 模块的初始状态。 在使用默认值 `false` 时，机器人会在通过 `Enabled` 或 `start` 命令启动时自动开始挂卡。 只有您希望手动 `resume`（恢复）自动挂卡进程时，才应该将这个属性设置为 `true`。例如，您可能只使用 `play` 命令，从来都不用 `CardFarmer`（挂卡）模块——这一属性与发送 `pause` [**命令**](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-zh-CN)的效果完全相同。 如果您不确定是否要启用此功能，请保留默认值 `false`。

---

### `RedeemingPreferences`

这是一个默认值为 `0` 的 `byte flags` 类型属性。 该属性定义 ASF 在激活游戏序列号时的行为，可选项如下：

| 值 | 名称                                 | 描述                                                                                  |
| - | ---------------------------------- | ----------------------------------------------------------------------------------- |
| 0 | None                               | 无特殊激活偏好，默认值                                                                         |
| 1 | Forwarding                         | 将无法激活的序列号转发给其他机器人                                                                   |
| 2 | Distributing                       | 将序列号分配给自身和其他机器人                                                                     |
| 4 | KeepMissingGames                   | 在转发时保留（可能）未拥有的游戏，使这些序列号不被使用                                                         |
| 8 | AssumeWalletKeyOnBadActivationCode | 假定 `BadActivationCode` 状态的序列号等同于 `CannotRedeemCodeFromClient` 状态，并因此尝试将其作为钱包礼物卡代码激活 |

请注意，该属性是 `flags` 字段，因此可以设置为可用选项的任意组合。 如果您想了解更多，请阅读 **[JSON 映射](#json-映射)**。 不启用任何 Flag 即为 `None` 选项。

`Forwarding` 会使机器人将无法激活的序列号转发给另一个尚未拥有此游戏的（尽可能事先检查）、已连接并且已登录的机器人。 最常见的情况是将 `AlreadyPurchased`（已拥有）的游戏转发给另一个尚未拥有游戏的机器人，但该选项也同样会转发其他情况下的序列号，例如 `DoesNotOwnRequiredApp`（缺少游戏本体）、`RateLimited`（激活频率限制）或者 `RestrictedCountry`（激活地区限制）。

`Distributing` 会使机器人在自己和其他机器人之间分配所有序列号。 这意味着每个机器人都会从一批序列号中获得一个。 通常，这个功能仅适用于激活大量同一个游戏的序列号。并且您希望在所有机器人中均匀分配，而激活各种不同游戏的情况则不适合该选项。 如果您仅在 `redeem` 命令中提供一个序列号，则此功能就没有意义，因为没有可供分配的额外序列号。

`KeepMissingGames` 会使机器人在无法确定自己是否拥有序列号所激活的游戏时，跳过 `Forwarding` 操作。 这基本上意味着 `Forwarding` 操作将**只会**针对 `AlreadyPurchased` 的序列号生效，而不再转发 `DoesNotOwnRequiredApp`、`RateLimited` 或 `RestrictedCountry` 状态的序列号。 通常情况下，您会希望为主帐户设置这一选项，以确保在临时触发频率限制 `RateLimited` 等情况下，不再继续转发为此帐户激活的序列号。 从描述中可以猜到，如果未启用 `Forwarding`，则此字段就完全没有任何效果。

`AssumeWalletKeyOnBadActivationCode` 会使 `BadActivationCode` 状态的序列号被当作 `CannotRedeemCodeFromClient` 状态，ASF 会尝试将其作为钱包礼物卡代码激活。 加入此选项的原因是，Steam 可能会将钱包礼物卡代码当作 `BadActivationCode`（而非正确的 `CannotRedeemCodeFromClient`），导致 ASF 永远不会尝试激活它们。 然而，我们建议**避免**使用此选项，因为这会使 ASF 尝试将所有无效序列号当作钱包代码激活，因而向 Steam 服务发送大量（可能无效）的请求，造成意料之外的后果。 相反，我们建议您在明确激活钱包礼物卡代码时，使用 **[`redeem^`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-zh-CN#redeem-模式)** 命令的 `ForceAssumeWalletKey` 模式，这样仅在启用此模式时进行所需的额外尝试。

同时启用 `Forwarding` 和 `Distributing` 将会在转发的基础上增加分配的功能，即 ASF 会首先尝试在所有机器人上激活一个序列号（转发），然后再切换到下一个（分配）。 通常，如果您这样设置，就表示您希望启用 `Forwarding` 功能，同时在序列号被使用时切换机器人，而不是始终按机器人顺序激活每个序列号（仅启用 `Forwarding` 的行为）。 这种行为在您知道大多数甚至全部序列号都被绑定到同一款游戏的情况下非常有用，因为这种情况下仅启用 `Forwarding` 将会使机器人首先尝试在一个机器人上激活所有序列号（适合序列号属于不同游戏的情况），而启用 `Forwarding` + `Distributing` 将会在激活下一个序列号时切换机器人，将激活新序列号的任务“分配”到另一个机器人上，不再由初始机器人负责（适合所有序列号都是同一款游戏的情况，每次激活都会跳过一次无意义的尝试）。

激活时，机器人的顺序都是按照字母排列的，除了不可用的机器人（未连接、已停用或者其他情况）。 请记住，每个 IP 和每个帐户都有每小时激活次数的限制，并且每次激活结果不为 `OK` 都意味着激活失败。 ASF 会尽力减少 `AlreadyPurchased` 错误的次数，例如，避免向已拥有游戏的机器人转发序列号，但由于 Steam 处理游戏许可的方式，我们无法保证这种措施一定有效。 使用 `Forwarding` 或 `Distributing` 等激活选项，一定会增加您触发 `RateLimited` 的可能性。

还需注意，您无法向您没有权限的机器人转发或分配序列号。 这应该是很显然的，但是您需要确保您至少对激活过程中的机器人拥有 `Operator` 权限，例如使用 `status ASF` [**命令**](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-zh-CN)检查。

---

### `RemoteCommunication`

这是一个默认值为 `3` 的 `byte flags` 类型属性。 该属性为每个机器人定义 ASF 与以下第三方服务进行远程通信的行为：

| 值 | 名称            | 描述                                                                                                                                                                                                             |
| - | ------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| 0 | None          | 不允许与第三方通信，指定的 ASF 功能将不可用                                                                                                                                                                                       |
| 1 | SteamGroup    | 允许与 [**ASF 的 Steam 组**](https://steamcommunity.com/groups/archiasf)通信                                                                                                                                          |
| 2 | PublicListing | 如果用户还启用了 **[`TradingPreferences`](#tradingpreferences)** 中的 `SteamTradeMatcher`，则允许与 [**ASF STM 列表**](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin-zh-CN#publiclisting公共列表)通信以展示在列表上 |

请注意，该属性是 `flags` 字段，因此可以设置为可用选项的任意组合。 如果您想了解更多，请阅读 **[JSON 映射](#json-映射)**。 不启用任何 Flag 即为 `None` 选项。

此选项不包含所有 ASF 提供的第三方通信，仅包含其他设置没有隐含的通信。 例如，如果您启用 ASF 自动更新，ASF 就会按照您的设置，与 GitHub（用于下载）和我们的服务器（用于完整性校验）通信。 同样地，在 **[`TradingPreferences`](#tradingpreferences)** 中启用 `MatchActively` 隐含了与我们服务器的通信，即获取列表中的机器人，这也是启用此功能所必需的。

关于此主题的详细解释，您可以阅读[**远程通信**](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Remote-communication-zh-CN)章节了解。 除非您有理由编辑此属性，否则应将其保留为默认值。

---

### `SendOnFarmingFinished`

这是一个默认值为 `false` 的 `bool` 类型属性。 当 ASF 完成给定帐户的挂卡任务时，它可以通过交易报价将全部挂卡所得发送给拥有 `Master` 权限的用户，免去您手动发送交易报价的麻烦。 此选项的运作方式与 `loot` 命令相同，因此请注意，您需要先正确为用户设置 `Master` 权限，并且设置有效的 `SteamTradeToken`，并且还要保证此帐户原本就能够进行交易。 启用此选项时，除了在挂卡完成之后激发 `loot` 命令，ASF 也会在每次获得新物品时（未挂卡时）以及每次在交易中获得新物品时激发 `loot` 命令。 这可以方便地将来自其他人的物品“转发”到我们的帐户中。

通常您需要同时启用 **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication-zh-CN)** 以更好地使用此功能，但如果您愿意及时手动处理 2FA 交易确认，也可以跳过这一步。 如果您不确定应该如何设置这个属性，请保留默认值 `false`。

---

### `SendTradePeriod`

这是一个默认值为 `0` 的 `byte` 类型属性。 该属性的工作方式非常类似于 `SendOnFarmingFinished` 属性，只有一点区别——不是在挂卡完成时发送交易报价，而是每隔 `SendTradePeriod` 小时发送一次，无论是否挂卡完成。 如果您希望定期对子帐户发送 `loot` 命令而不是等到挂卡结束，则应该设置此属性。 默认值 `0` 会禁用此功能，如果您希望您的机器人每天发送一次交易报价，就可以设置为 `24`。

通常您需要同时启用 **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication-zh-CN)** 以更好地使用此功能，但如果您愿意及时手动处理 2FA 交易确认，也可以跳过这一步。 如果您不确定应该如何设置这个属性，请保留默认值 `0`。

---

### `ShutdownOnFarmingFinished`

这是一个默认值为 `false` 的 `bool` 类型属性。 ASF 会在机器人激活期间始终“占用”帐户。 在指定帐户挂卡完成后，ASF 会定期（每隔 `IdleFarmingPeriod` 小时）检查帐户内是否有新游戏含有 Steam 卡牌，以便于在不重启进程的情况下恢复此帐户的挂卡过程。 这应该适合大多数人，因为 ASF 可以在需要时自动恢复挂卡。 但是，您可能希望在指定帐户挂卡完成后停止进程，这就需要将这个属性设置为 `true`。 在启用时，ASF 将会在挂卡完成之后注销帐户，这意味着此帐户将不再被定期检查或占用。 您应该自己决定，更希望 ASF 始终处理指定的机器人实例，还是在挂卡结束后停止。 如果所有帐户都停止运行，并且程序没有以 `--process-required` [**模式**](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-Line-Arguments-zh-CN)运行，则 ASF 本身也会关闭，让您的机器休息，您可以在获得最后一张卡牌之后为计算机安排睡眠或者关机等其他操作。

如果您不确定应该如何设置这个属性，请保留默认值 `false`。

---

### `SkipRefundableGames`

这是一个默认值为 `false` 的 `bool` 类型属性。 该属性定义了 ASF 是否应该挂仍可以退款的游戏。 可退款游戏指的是您在 2 周内通过 Steam 商店购买的、游戏时间不超过 2 小时的游戏，详见 **[Steam 退款](https://store.steampowered.com/steam_refunds)**。 该选项的默认值为 `false`，ASF 将会完全忽略 Steam 的退款策略，挂一切可以挂的游戏，这也是大多数用户所需要的。 然而，如果您不希望 ASF 马上开始挂您的可退款游戏，就可以将该选项改为 `true`，这样您就可以自己体验游戏，并在需要时退款，避免 ASF 影响您的游戏时间。 请注意，如果您启用此选项，自您在 Steam 商店购买游戏起的 14 天内，ASF 将不会挂这款游戏，如果在此期间，您没有其他可挂卡游戏，ASF 就会表现为闲置。 如果您不确定是否要启用此功能，请保留默认值 `false`。

---

### `SteamLogin`

这是一个默认值为 `null` 的 `string` 类型属性。 该属性定义您的 Steam 用户名——在登录 Steam 时使用。 除了在配置文件内输入 Steam 用户名，您还可以保留其默认值 `null`，并在 ASF 每次启动时手动输入用户名。 如果您不希望在文件中保存敏感信息，这是更好的方法。

---

### `SteamMasterClanID`

这是一个默认值为 `0` 的 `ulong` 类型属性。 该属性定义一个 Steam 群组 ID，机器人应该自动加入此群组及其聊天室。 要获取您的群组 ID，您可以访问群组的[**主页**](https://steamcommunity.com/groups/archiasf)，然后在该页面的网址后面加上 `/memberslistxml?xml=1`，使网址看起来类似[**这样**](https://steamcommunity.com/groups/archiasf/memberslistxml?xml=1)。 此时您可以在结果的 `<groupID64>` 标签内找到群组的 ID。 在本例中即为 `103582791440160998`。 机器人不仅会尝试主动加入指定的群组，还会自动接受来自此群组的邀请，使您可以手动邀请机器人加入私密群组。 如果您没有专门用于管理机器人的群组，就应该保留默认值 `0`。

---

### `SteamParentalCode`

这是一个默认值为 `null` 的 `string` 类型属性。 该属性定义您的 Steam 家庭监护 PIN 代码。 ASF 需要有权限访问由 Steam 家庭监护保护的资源，因此如果您的帐户启用了家庭监护，就需要将家庭监护解锁 PIN 提供给 ASF，使它能够正常运行。 默认值 `null` 表示无需 Steam 家庭监护 PIN 解锁此帐户，如果您没有启用家庭监护功能，就不需要更改。

在有限的情况下，ASF 也能够自动生成有效的家庭监护代码，但这需要消耗大量的系统资源和时间来完成，并且也不能保证一定成功，因此我们不建议您依赖此功能，而是在配置文件内手动指定有效的 `SteamParentalCode` 值。 如果 ASF 认为需要 PIN，又无法自己生成，就会要求您输入。

---

### `SteamPassword`

这是一个默认值为 `null` 的 `string` 类型属性。 该属性定义您的 Steam 密码——在登录 Steam 时使用。 除了在配置文件内输入 Steam 密码，您还可以保留其默认值 `null`，并在 ASF 每次启动时手动输入密码。 如果您不希望在文件中保存敏感信息，这是更好的方法。

---

### `SteamTradeToken`

这是一个默认值为 `null` 的 `string` 类型属性。 如果您的机器人在您的好友列表内，机器人就无需交易令牌，直接向您发起交易，因此您可以保留其默认值 `null`。 但如果机器人不在您的好友列表内，就需要为接收交易报价的用户生成交易令牌并填写至此。 换句话说，此属性应该填写**此**机器人实例在 `SteamUserPermissions` 中定义的 `Master` 权限用户的交易令牌。

要找到交易令牌，您需要以 `Master` 权限用户登录，访问[**此页面**](https://steamcommunity.com/my/tradeoffers/privacy)，找到您的交易 URL。 我们寻找的交易令牌有 8 个字符，就在您的交易 URL 中 `&token=` 的后面。 您应该复制这 8 个字符，粘贴到这里作为 `SteamTradeToken`。 请不要填写完整的交易 URL，也不要包含 `&token=` 文本，您仅需要填写 8 个字符的令牌本身。

---

### `SteamUserPermissions`

这是一个默认值为空的 `ImmutableDictionary<ulong, byte>` 类型属性。 该属性是一个字典属性，将 Steam 用户的 64 位 ID 映射到一个表示此用户在 ASF 实例内权限的 `byte` 类型的数字。 目前 ASF 支持的机器人权限有：

| 值 | 名称            | 描述                                                                 |
| - | ------------- | ------------------------------------------------------------------ |
| 0 | None          | 无特殊权限，这是分配给不在字典内的 SteamID 的参考值——您不需要为任何人定义此权限                      |
| 1 | FamilySharing | 为家庭共享用户提供的最低权限。 同样，这也是一个参考值，因为 ASF 能够自动发现有权使用我们游戏库的家庭共享帐户的 SteamID |
| 2 | Operator      | 提供操作指定机器人的基本权限，主要包括添加游戏许可与激活序列号                                    |
| 3 | Master        | 提供操作指定机器人的完整权限                                                     |

简而言之，此属性允许您设定指定用户操作此机器人的权限。 权限主要用于访问 ASF **[命令](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-zh-CN)**，但也用于启用很多其他 ASF 功能，例如接受交易报价。 例如，您可能希望将自己的帐户设置为 `Master`，然后为您的两三位朋友设置 `Operator` 权限，使他们可以简单地通过 ASF 为您的机器人激活游戏序列号，但又**无法**执行停止机器人等操作。 因此，您可以轻松将权限分配给指定的用户，使他们能够在您设定的限制下操作您的机器人。

我们建议您只设置一名用户为 `Master`，然后设定其他用户为较低权限的 `Operators`。 但从技术上来讲，您可以为机器人设定多名 `Master` 用户，并且 ASF 仍然可以正常工作，接受来自其中每名用户的交易报价，如果操作的目标用户只能有一名，例如 `loot` 请求、`SendOnFarmingFinished` 属性或 `SendTradePeriod` 属性，ASF 就会选择这些用户中 Steam ID 数字最小的一个。 如果您完全理解这些限制，特别是无论实际执行命令的 `Master` 用户是谁，`loot` 请求总是会将物品发送给 Steam ID 数字最小的那名 `Master` 用户，那么您就可以在这里设置多名 `Master` 权限用户，但仍然建议您选择单 Master 方案。

值得注意的是，还有一个额外的 `Owner` 权限，此权限由全局配置属性 `SteamOwnerID` 设置。 您无法在这里将 `Owner` 权限授予任何人，因为 `SteamUserPermissions` 属性仅能定义与此机器人实例相关，而非 ASF 进程相关的权限。 对于机器人相关的任务，`SteamOwnerID` 被视为与 `Master` 相同，因此也没有必要在此设置 `SteamOwnerID`。

---

### `TradeCheckPeriod`

这是一个默认值为 `60` 的 `byte` 类型属性。 通常情况下，ASF 会在收到通知后处理收到的交易报价，但有时因为 Steam 的错误无法做到，此时交易报价会被忽略，直到下一条交易通知或机器人重启，这可能会导致交易被取消或者物品不可用。 如果此参数设置为非零值，ASF 将会额外每隔 `TradeCheckPeriod` 分钟检查此类交易。 我们选择的默认值考虑了对 Steam 发送额外请求和丢失交易报价二者之间的平衡。 但是，如果您只是用 ASF 挂卡，不打算自动处理任何交易，则可以设置为 `0` 完全禁用此功能。 另一方面，如果您的机器人加入了公开的 [ASF STM 列表](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin-zh-CN#publiclisting公共列表)，或者通过其他方式提供自动交易服务，则可能会希望将此参数降到 `15` 之类的值，以便及时处理交易。

---

### `TradingPreferences`

这是一个默认值为 `0` 的 `byte flags` 类型属性。 该属性定义 ASF 在交易时的行为，可选项如下：

| 值  | 名称                  | 描述                                                                                                                                                                            |
| -- | ------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| 0  | None                | 无特殊交易偏好，默认值                                                                                                                                                                   |
| 1  | AcceptDonations     | 接受我们不付出任何物品的交易                                                                                                                                                                |
| 2  | SteamTradeMatcher   | 以被动方式参与 **[STM](https://www.steamtradematcher.com)** 交易。 访问&#8203;**[交易](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading-zh-CN#steamtradematcher)**&#8203;获得更多信息  |
| 4  | MatchEverything     | 需要先设置 `SteamTradeMatcher`，将二者结合使用——除了有利交易和平衡交易，还接受不利交易                                                                                                                        |
| 8  | DontAcceptBotTrades | 不自动接受来自其他机器人的 `loot` 交易                                                                                                                                                       |
| 16 | MatchActively       | 以主动方式参与 **[STM](https://www.steamtradematcher.com)** 交易。 访问[**物品匹配插件**](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin-zh-CN#matchactively主动匹配)了解更多信息 |

请注意，该属性是 `flags` 字段，因此可以设置为可用选项的任意组合。 如果您想了解更多，请阅读 **[JSON 映射](#json-映射)**。 不启用任何 Flag 即为 `None` 选项。

若要了解 ASF 的交易逻辑，以及对于每个 flag 的详细说明，请阅读[**交易**](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading-zh-CN)章节。

---

### `TransferableTypes`

这是一个默认值为 Steam 物品类型 `1, 3, 5` 的 `ImmutableHashSet<byte>` 类型属性。 这个属性定义了在使用 `transfer` [**命令**](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-zh-CN)时，机器人之间可转移 Steam 物品的类型。 ASF 会确保交易报价内只包含 `TransferableTypes` 类型的物品，因此，这个属性使您可以选择您希望从发往其他机器人的交易报价中获得何种物品。

| 值  | 名称                    | 描述                        |
| -- | --------------------- | ------------------------- |
| 0  | Unknown               | 不符合以下情况的任何类型              |
| 1  | BoosterPack           | 包含某游戏随机 3 张卡牌的补充包         |
| 2  | Emoticon              | Steam 聊天中使用的表情            |
| 3  | FoilTradingCard       | 闪亮集换式卡牌（`TradingCard`）    |
| 4  | ProfileBackground     | 在 Steam 个人资料上使用的个人资料背景    |
| 5  | TradingCard           | 用来合成徽章的 Steam 集换式卡牌（非闪亮）  |
| 6  | SteamGems             | 用来制作补充包的 Steam 宝石，包括成袋的宝石 |
| 7  | SaleItem              | Steam 特卖期间的特殊奖励物品         |
| 8  | Consumable            | 使用后消失的特殊消耗品               |
| 9  | ProfileModifier       | 修改 Steam 个人资料外观的特殊物品      |
| 10 | Sticker               | Steam 聊天中使用的特殊物品（聊天贴纸）    |
| 11 | ChatEffect            | Steam 聊天中使用的特殊物品（聊天贴纸）    |
| 12 | MiniProfileBackground | Steam 个人资料迷你背景            |
| 13 | AvatarProfileFrame    | Steam 个人资料头像边框            |
| 14 | AnimatedAvatar        | Steam 个人资料动画头像            |
| 15 | KeyboardSkin          | Steam Deck 的特殊键盘皮肤        |
| 16 | StartupVideo          | Steam Deck 的特殊启动影片        |

请注意，无论如何设置上述选项，ASF 都只会处理 [**Steam 社区物品**](https://steamcommunity.com/my/inventory/#753_6)（`appID` 为 753，`contextID` 为 6），所以所有的游戏物品、礼物等都会被排除在交易报价之外。

默认值的设定基于机器人的最常见用法，即仅仅转移补充包和集换式卡牌（包括闪亮卡牌）。 您可以更改此属性，将机器人的行为调整至令您满意。 请记住，上表未定义的所有类型都会显示为 `Unknown`，特别是在 Valve 发布一些新 Steam 物品时，ASF 也会将它们标记为 `Unknown`，直到它们（在未来版本中）被添加到这个表格中。 这也是为何一般不建议在 `TransferableTypes` 中包含 `Unknown` 类型，除非您了解您正在做什么，并且明白如果 Steam 网络出现故障，将所有物品当作 `Unknown`，ASF 将会在交易报价中发送整个库存内的物品。 我强烈建议您即使希望转移所有类型的物品，也不要在 `TransferableTypes` 中包含 `Unknown`。

---

### `UseLoginKeys`

这是一个默认值为 `true` 的 `bool` 类型属性。 该属性定义 ASF 是否应该为此 Steam 帐户启用登录密钥机制。 登录密钥机制的工作原理类似于 Steam 客户端的“记住我的密码”选项，使 ASF 可以保留临时的一次性登录密钥，并在下一次登录时使用，只要这个登录密钥没有失效，登录时就可以跳过输入密码、Steam 令牌或者两步验证代码的步骤。 登录密钥存储在 `BotName.db` 文件中，并且自动更新。 这就是您不需要在成功登录一次以后再输入密码、Steam 令牌或者两步验证代码的原因。

登录密钥主要用来为您提供方便，使您无需每次登录都要输入 `SteamPassword`、Steam 令牌或者两步验证代码（当没有启用 **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication-zh-CN)** 时）。 这也是一种先进的替代方法，因为登录密钥是一次性的，并且无法从中获得您的密码原文。 您的原版 Steam 客户端也在使用完全相同的方法，即为您的下一次登录保留用户名和登录密钥，效果等同于在 ASF 中设置 `SteamLogin` 和 `UseLoginKeys` 两个属性，并留空 `SteamPassword`。

但是，仍然有人会担心这个小细节，因此，如果您希望确保 ASF 不存储任何形式的、用于在关闭程序后恢复上次会话的令牌，每次登录时都进行身份验证，那么您可以修改此属性。 禁用此选项与在官方 Steam 客户端中不勾选“记住我的密码”的效果是完全相同的。 除非您明确了解自己在做什么，否则请将其保留为默认值 `true`。

---

### `UserInterfaceMode`

这是一个默认值为 `0` 的 `byte` 类型属性。 该属性指定机器人在登录到 Steam 网络后将自己广播为哪种用户界面模式。 目前您可以选择下列模式之一：

| 值   | 名称                |
| --- | ----------------- |
| `0` | Default（默认）       |
| `1` | BigPicture（大屏幕模式） |
| `2` | Mobile（移动端）       |

如果您不确定应该如何设置这个属性，请保留默认值 `0`。

---

## 文件结构

ASF 采用这种很简单的文件结构：

```text
├── config
│     ├── ASF.json
│     ├── ASF.db
│     ├── Bot1.json
│     ├── Bot1.db
│     ├── Bot2.json
│     ├── Bot2.db
│     └── ...
├── ArchiSteamFarm.dll
├── log.txt
└── ...
```

如果您需要将 ASF 迁移到其他位置，例如另一台 PC，则仅移动/复制 `config` 文件夹就足够了，并且这也是备份 ASF 数据的推荐方式，因为您随时可以从 GitHub 下载其余的（程序）文件，而无需承担因备份失败导致 ASF 内部文件损坏的风险。

`log.txt` 文件保存您上次运行 ASF 时生成的日志。 此文件不包含任何敏感信息，并且在涉及问题、崩溃或仅提供上次运行 ASF 的信息时非常有用。 如果您遇到了问题或漏洞，我们会经常需要您提供此文件。 ASF 会自动管理这些文件，但如果您是一名高级用户，您可以进一步调整 ASF 的[**日志**](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Logging-zh-CN)模块。

`config` 文件夹是保存 ASF 及其所有机器人的配置文件的地方。

`ASF.json` 是 ASF 全局配置文件。 此配置文件用于设置 ASF 进程的行为，这会影响所有机器人和程序本身。 您可以在此文件中找到全局属性，例如 ASF 进程所有者、自动更新设定或者调试设定。

`BotName.json` 是每个机器人实例的配置文件。 此配置文件用于设置给定机器人实例的行为，因此这些设置仅对此机器人生效，不会与其他任何机器人共享配置。 您可以通过各种不同的设置调整机器人，每个机器人可以有不同的运作方式。 每个机器人的名称都是唯一的，由您选择并写在 `BotName` 的位置。

除了配置文件外，ASF 还使用 `config` 文件夹来存储数据库。

`ASF.db` 是 ASF 的全局数据库。 它是一个全局的持久存储数据库，其中包含各种与 ASF 进程相关的信息，例如当地 Steam 服务器的 IP 地址。 **您不应该编辑这个文件**。

`BotName.db` 是给定机器人实例的数据库。 此文件将给定机器人实例的关键数据，例如登录密钥或者 ASF 2FA，存储在持久存储数据库内。 **您不应该编辑这个文件**。

`BotName.keys` 是一个特殊文件，用于向[**后台游戏激活器**](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer-zh-CN)中导入序列号。 此文件既非必须也非由 ASF 生成，ASF 会读取此文件。 此文件将会在序列号导入成功后被自动删除。

`BotName.maFile` 是一个特殊文件，用于导入 **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication-zh-CN)**。 此文件既非必须也非由 ASF 生成，如果您的 `BotName` 机器人尚未启用 ASF 2FA，ASF 会读取此文件。 此文件将会在 ASF 2FA 导入成功后被自动删除。

---

## JSON 映射

每个配置文件属性都有其类型。 属性的类型定义了该属性的有效值。 您仅能使用由指定类型规定的有效值——如果您使用了无效的值，ASF 就无法解析您的配置文件。

**我们强烈建议您使用配置文件生成器来生成配置文件**——它可以帮助您处理大多数底层工作（例如类型验证），这样您就只需要输入正确的值，无需理解下文所述的变量类型。 本节主要面向手动生成/编辑配置文件的人群，使他们了解可以使用哪些值。

ASF 使用原生的 C# 类型系统，包括：

---

`bool`——布尔类型，只接受 `true` 和 `false`。

示例：`"Enabled": true`

---

`byte` ——无符号字节类型，只接受从 `0` 到 `255` 之间（含边界值）的整数。

示例：`"ConnectionTimeout": 90`

---

`ushort`——无符号短整数类型，只接受从 `0` 到 `65535` 之间（含边界值）的整数。

示例：`"WebLimiterDelay": 300`

---

`uint`——无符号整数类型，只接受从 `0` 到 `4294967295` 之间（含边界值）的整数。

---

`ulong`——无符号长整数类型，只接受从 `0` 到 `18446744073709551615` 之间（含边界值）的整数。

示例：`"SteamMasterClanID": 103582791440160998`

---

`string`——字符串类型，接受任何字符序列，包括空序列 `""` 和 `null`。 ASF 对空序列和 `null` 的处理方式是相同的，所以您可以在二者之间任意选择（我们始终使用 `null`）。

示例：`"SteamLogin": null`、`"SteamLogin": ""`、`"SteamLogin": "MyAccountName"`

---

`Guid?`——可为 Null 的 UUID 类型，在 JSON 中被编码为字符串。 UUID 由 32 位十六进制字符组成，范围包括 `0` 到 `9` 与 `a` 到 `f`。 ASF 接受各种有效的格式——小写、大写、有无连字符皆可。 除了有效的 UUID 以外，因为此属性可为 Null，特殊值 `null` 也被接受，表示未提供 UUID。

示例：`"LicenseID": null`、`"LicenseID": "f6a0529813f74d119982eb4fe43a9a24"`

---

`ImmutableList<valueType>`——给定 `valueType` 类型值的不可变容器（列表）。 在 JSON 中，这被定义为给定 `valueType` 类型元素的数组。 ASF 使用 `List` 来表示给定属性支持多个值，并且其顺序有意义。

`ImmutableList<byte>` 的示例：`"FarmingOrders": [15, 11, 7]`

---

`ImmutableHashSet<valueType>`——给定 `valueType` 类型唯一值的不可变容器（集合）。 在 JSON 中，这被定义为给定 `valueType` 类型元素的数组。 ASF 使用 `HashSet` 来表示给定属性的值必须唯一才有意义，并且其顺序不重要，因此它会在解析过程中忽略任何重复的值（假如您不小心提供了重复的值）。

`ImmutableHashSet<uint>` 的示例：`"Blacklist": [267420, 303700, 335590]`

---

`ImmutableDictionary<keyType, valueType>`——从给定 `keyType` 类型唯一键指向给定 `valueType` 类型值的不可变映射（字典）。 在 JSON 中，这被定义为一个包含键-值对的对象。 请注意，在这种情况下，`keyType` 总需要写在引号里，即使它的类型是 `ulong` 等非字符串。 还有一个严格的要求，映射中的键必须是唯一的，这也是由 JSON 强制规定的。

`ImmutableDictionary<ulong, byte>` 的示例：`"SteamUserPermissions": { "76561198174813138": 3, "76561198174813137": 1 }`

---

`flags`——Flags 属性值通过位运算将多个不同的属性组合为一个最终值。 这使您可以同时设置多个可能值的任意组合。 最终值由所有已启用选项的值求和构造而成。

例如，给定下列值：

| 值 | 名称   |
| - | ---- |
| 0 | None |
| 1 | A    |
| 2 | B    |
| 4 | C    |

则选项 `B + C` 的结果是 `6`，选项 `A + C` 的结果是 `5`，选项 `C` 的结果是 `4`， 等等。 您可以启用不同的选项，创造任意可能的选项组合——如果您决定启用其中所有选项，就只需要对 `None + A + B + C` 求和，得到结果值 `7`。 还需要注意，根据定义，值为 `0` 的 Flag 会在所有组合中启用，因此这个 Flag 通常表示什么也不启用（例如 `None`）。

正如您所见，在此例中，我们可以任意开关 3 个可用的 Flag（`A`、`B`、`C`），共有 `8` 种可能的组合：
- `None -> 0`
- `A -> 1`
- `B -> 2`
- `A + B -> 3`
- `C -> 4`
- `A + C -> 5`
- `B + C -> 6`
- `A + B + C -> 7`

示例：`"SteamProtocols": 7`

---

## 兼容性映射

由于 Javascript 的限制，在线配置文件生成器无法将简单的 `ulong` 字段正确序列化为 JSON，`ulong` 字段将会在配置文件内呈现为带有 `s_` 前缀的字符串。 例如，`"SteamOwnerID": 76561198006963719` 会由配置文件生成器写作 `"s_SteamOwnerID": "76561198006963719"`。 ASF 有自动处理此类字符串映射的正确逻辑，所以您的配置文件中的 `s_` 条目是完全有效的。 如果您自己生成配置文件，我们建议您仍然尽可能使用原始的 `ulong` 字段，但如果您无法做到这一点，也可以参考此方案，将它们编码为字符串，并加上 `s_` 前缀。 我们希望将来可以解决这个 Javascript 的限制。

---

## 配置兼容性

兼容旧配置文件是 ASF 的首要任务。 您应该已经知道，缺失的配置文件属性相当于使用其**默认值**。 因此，如果新版本 ASF 带来了新的配置文件属性，您的配置文件仍然**兼容**新版本，ASF 将会把这些新属性的值视为**默认值**。 您可以随时按需增加、删除或者编辑配置文件属性。

我们建议您仅指定需要修改的配置文件属性，使其他属性自动继承其默认值，这不仅保持您的配置文件足够简洁，还可以在我们决定修改属性默认值的时候增强它的兼容性，您就无需手动进行更新（例如，我们曾经修改过 `WebLimiterDelay` 的默认值）。

由于上述情况，ASF 会自动迁移/优化您的配置，将其重新格式化并删除具有默认值的字段。 如果您有特定的理由，例如您可能提供不希望 ASF 修改的只读配置文件，则可以通过 `--no-config-migrate` [**命令行参数**](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments-zh-CN#参数)禁用此行为。

---

## 自动重载

ASF 会在配置文件被修改时进行动态操作——即 ASF 会自动：
- 在您新建机器人配置文件时，创建（并在需要时启动）新机器人实例
- 在您删除机器人配置文件时，停止（如果需要）并删除旧机器人实例
- 在您编辑机器人配置文件时，停止（并在需要时启动）机器人实例
- 在您重命名机器人配置文件时，（如果需要）以新名称重新启动机器人

以上操作都是透明的，您无需重新启动程序或者停止无关机器人实例，就可以由 ASF 自动完成。

此外，如果您修改了核心的 `ASF.json` 配置文件，ASF 也会重新启动自身（如果 `AutoRestart` 属性允许）。 同样地，如果您重命名或者删除这个文件，程序就会退出。

如果您有特定的理由，例如您不希望 ASF 检测 `config` 目录内的文件变化，则可以通过 `--no-config-watch` [**命令行参数**](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments-zh-CN#参数)禁用此行为。