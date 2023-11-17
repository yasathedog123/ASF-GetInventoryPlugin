# 常见问题

“常见问题”涵盖了一些常见问题以及它们的答案。 对于不太常见的问题，请访问我们的&#8203;**[补充常见问题](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Extended-FAQ-zh-CN)**。

# 目录

* [基本问题](#基本问题)
* [与类似工具的对比](#与类似工具的对比)
* [安全/隐私/VAC/封禁/订户协议](#安全隐私vac封禁订户协议)
* [杂项](#杂项)
* [异常情况](#异常情况)

---

## 基本问题

### 什么是 ASF？
### 为什么程序提示该帐户已经无卡可挂？
### 为什么 ASF 没有检测到我的所有游戏？
### 为什么我的帐户受到限制？

在尝试了解 ASF 是什么之前，您应该首先了解什么是 Steam 集换式卡牌，以及如何获取它们，这在官方的&#8203;**[常见问题](https://steamcommunity.com/tradingcards/faq)**&#8203;中已有很好的解释。

简而言之，Steam 集换式卡牌是一种可收集的物品，您在拥有特定的游戏后即可自己获取它们，您可以用它们合成徽章、在 Steam 社区市场上出售或者做其他任何您想对它们做的事。

我需要在这里再次强调卡牌机制的核心要点，因为人们通常会反对并且无视这些事实：

- **您需要在自己的 Steam 帐户上拥有相应游戏，才有资格获得此游戏掉落的卡牌。 家庭共享的游戏不算在内。**
- **您不能无限挂卡，每款游戏只会掉落固定数量的卡牌。 一旦您挂完了所有可掉落的卡牌（整套卡牌的一半），这款游戏就无法再挂卡。 无论您是否出售、交易、合成或对您已获得的卡牌进行任何操作，一旦卡牌掉落完毕，这款游戏就算挂完了。**
- **如果您不在免费游戏中消费，就无法从中获得卡牌掉落。 这一点涉及到永久免费的游戏，例如 Team Fortress 2 或 Dota 2。 拥有免费游戏不会给您带来卡牌掉落。**
- **[受限帐户](https://support.steampowered.com/kb_article.php?ref=3330-iagk-7663)&#8203;无法掉落卡牌，无论其是否拥有游戏。 在过去不是这样，但是现在情况发生了变化。**
- **您在促销活动期间获得的付费游戏无法掉落卡牌，无论其商店页面显示为何。 在过去不是这样，但是现在情况发生了变化。**

如您所见，Steam 卡牌是对您玩游戏或者在免费游戏中消费的奖励。 如果您花足够长时间玩一款游戏，所有的可掉落卡牌都会掉落到您的库存中，使您有机会合成一个徽章（在获取另外半套卡牌之后）、卖掉卡牌或者随便您如何处理它们。

现在我们已经解释了 Steam 的基本知识，接下来解释 ASF。 这个程序本身非常复杂而且难以理解，所以我们只打算简单介绍，不会深入解释完整的技术细节。

ASF 通过我们内置的自定义 Steam 客户端实现，使用您提供的登录凭据登录到您的 Steam 帐户。 登录成功后，它将会解析您的&#8203;**[徽章页面](https://steamcommunity.com/my/badges)**，以寻找可挂卡的游戏（`X` 张剩余卡牌掉落）。 所有页面解析完成，最终的挂卡游戏列表构建成功后，ASF 会选择最优的挂卡算法开始挂卡。 这个过程取决于&#8203;**[挂卡算法](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance-zh-CN)**，但通常由两部分组成，一部分是运行合适的游戏，另一部分是定期（以及有物品掉落时）检查该游戏是否已经掉落所有卡牌——如果已完成，ASF 将会继续到下一款游戏，重复这一过程，直到所有游戏都挂卡完成。

请注意，上述解释是经过简化的，也没有描述 ASF 提供的其他额外功能。 如果您希望了解 ASF 的细节，请访问 **[Wiki](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Home-zh-CN)** 的其他页面。 我试图尽量简化它，让每个人都能理解，无需了解技术细节——并且鼓励高级用户深入研究。

作为一个应用程序——ASF 提供了一些“魔法”。 首先，它不需要下载任何游戏文件，就可以立刻“玩”游戏。 其次，它完全独立于您的普通 Steam 客户端——您完全不需要运行甚至安装 Steam 客户端。 然后，它是自动化的解决方案——这意味着 ASF 会自动为您处理一切，而不需要您告诉它怎么做——这免去了您的麻烦，节省了时间。 最后，它不需要进程模拟来欺骗 Steam 网络（Idle Master 就是这样做的），因为 ASF 可以与 Steam 网络直接通信。 它很快很轻量，对于想要轻松获得卡牌的用户来说是一个超赞的解决方案——特别是您可以在忙其他事的时候让它在后台运行，甚至在离线模式挂卡。

除了上述优点，ASF 也有一些技术上的限制，是由 Steam 造成的——我们无法挂您尚未拥有的游戏，无法永远继续挂卡过程使您获得超出限制的卡牌，也无法在您玩游戏时挂卡。 考虑到 ASF 的工作方式，这些限制应该是很合理的，但值得注意的是，ASF 没有超能力，也无法超越物理限制，所以请记住——这与告诉另一个人从另一台 PC 登录您的 Steam 帐户进行挂卡是相同的。

总结一下——ASF 是一个帮助您轻松获得卡牌掉落的程序。 它还提供了一些其他功能，但目前我们只关注核心的挂卡功能。

---

### 我必须输入我的帐户凭据吗？

**是的**。 ASF 与官方客户端一样需要您输入帐户凭据，因为它使用相同的方式与 Steam 网络交互。 但这不代表您需要在 ASF 配置文件中输入帐户凭据，您可以保持 `SteamLogin` 和/或 `SteamPassword` 属性为 `null` 或空值，然后在每次运行 ASF 时输入这些信息（以及其他相关的登录凭据，详见配置章节）。 这样，您的信息就不会被保存在任何地方，但您必须帮助 ASF 才能使它运行。 ASF 还提供了其他几种方法来增强&#8203;**[安全性](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security-zh-CN)**，所以如果您是高级用户，可以阅读这部分 Wiki。 如果您不是，并且不希望在 ASF 配置中留下帐户凭据，可以直接忽略这一步，然后在 ASF 需要这些信息时手动输入。

请记住，ASF 工具仅供您私人使用，您的帐户凭据永远不会离开您的计算机。 您也不应该将这些信息与任何人共享，因为这违反 **[Steam 订户协议](https://store.steampowered.com/subscriber_agreement)**——这是一份非常重要但是没人关心的法律文件。 您的信息不会被发送到我们的服务器或者第三方，而是直接发给由 Valve 控制的 Steam 服务器。 无论您是否写入配置文件，我们都无法获得您的帐户凭据，也无法为您恢复它们。

---

### 我需要花多少时间等待卡牌掉落？

**挂卡需要花多长时间，您就需要等多久**——这并非玩笑。 每款游戏的挂卡难度是由其开发商或发行商设定的，只有他们才能决定卡牌掉落的速度。 大多数游戏是每隔大约 30 分钟掉落 1 张卡牌，但也有些游戏需要您玩上几个小时才会掉落卡牌。 此外，对于您没有玩足够时长的游戏，您的帐户可能被限制无法获得卡牌掉落，如&#8203;**[性能](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance-zh-CN)**&#8203;章节所述。 请不要试图猜测 ASF 挂某个游戏所需的时间——您无法决定，ASF 也无法决定这一点。 您无法加快挂卡的速度，也没有卡牌“卡住”无法掉落的漏洞——您和 ASF 都无法控制卡牌掉落的过程。 在最好的情况下，您可以每隔平均 30 分钟获得 1 张卡牌。 在最差的情况下，您可能在启动 ASF 后的 4 小时内都没有获得任何卡牌。 这些情况都是正常的，并且已经在&#8203;**[性能](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance-zh-CN)**&#8203;章节中解释。

---

### 挂卡时间太长了，怎样加快速度？

能够严重影响挂卡速度的唯一因素是为机器人实例选择的&#8203;**[挂卡算法](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance-zh-CN)**。 其他因素的影响都是微不足道的，无法加快挂卡速度，而一些操作，例如多次重启 ASF 进程，甚至会**使情况更糟糕**。 如果您真的想要充分利用挂卡过程的每一秒钟，ASF 也允许您细致调整一些与挂卡有关的核心变量，例如 `FarmingDelay`——这些选项在&#8203;**[配置](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-zh-CN)**&#8203;中都已作出解释。 但如我所述，这些效果是微不足道的，是否为您的帐户选择正确的挂卡算法是唯一能够严重影响挂卡速度的关键因素，其他因素都只是锦上添花。 您不需要过于担心挂卡速度，只需要运行 ASF 让它做好自己的工作——我保证这是我能想到的最有效率的挂卡方式。 您越不在乎，就越满意其结果。

---

### 但是 ASF 告诉我挂卡只需要用 X 这么长时间！

ASF 根据您可掉落的卡牌数和您选择的挂卡算法给您一个粗略的近似时间——这与挂卡实际花费的时间无关，通常实际需要花费更长的时间，因为 ASF 会假设情况是最理想的，忽略所有 Steam 网络异常、互联网断开连接、Steam 服务器宕机等问题。 这可以作为一个指标，作为您期望的、理想情况下的 ASF 挂卡时间，因为实际情况会有所不同，甚至差别会非常大。 如上所述，不要试图猜测给定游戏的挂卡时间，您无法决定，ASF 也无法决定。

---

### ASF 可以在我的 Android/智能手机上运行吗？

ASF 是一个 C# 程序，需要安装正常工作的 .NET 环境实现。 自 .NET 6.0 开始，Android 已成为受支持的平台，然而，目前仍有问题阻止 ASF 在 Android 上运行，也就是&#8203;**[缺少可用的 ASP.NET 运行时环境](https://github.com/dotnet/aspnetcore/issues/35077)**。 即使目前无法原生支持，目前仍然有针对 ARM 架构 GNU/Linux 的可用构建，所以您完全可以使用 **[Linux Deploy](https://play.google.com/store/apps/details?id=ru.meefik.linuxdeploy)** 等方式在手机上安装 Linux，然后通过 chroot 在 Linux 上运行 ASF。

当所有 ASF 的需求都满足时，我们将会考虑发布官方的 Android 构建。

---

### ASF 可以挂游戏内物品吗，例如 CS:GO 或者 Unturned 的？

**不**，这违反了 **[Steam 订户协议](https://store.steampowered.com/subscriber_agreement)**，Valve 曾经对挂机获得 TF2 物品的行为实施大规模社区封禁，因而明确指出了这一点。 ASF 是一个 Steam 挂卡程序，而非游戏物品挂机工具——它没有任何挂游戏物品的能力，也不计划在未来添加这一功能，主要原因是这种行为违反 Steam 的使用条款。 请不要问这个问题——您能获得的最好结果就是其他用户的举报，而您会陷入更大的麻烦。 所有其他类型的挂机也是如此，例如在 CS:GO 的直播中挂机获取物品。 ASF 仅仅关注 Steam 集换式卡牌。

---

### 我可以选择挂哪些游戏吗？

**是的**，有几种方式可以做到。 如果您想调整挂卡队列的默认顺序，可以调整 `FarmingOrders` **[机器人配置属性](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-zh-CN#机器人配置)**。 如果您希望手动禁用一些游戏的自动挂卡，可以使用 `fb` **[命令](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-zh-CN)**&#8203;管理挂卡黑名单。 如果挂所有游戏对您来说没问题，但是需要优先挂一部分，可以使用 `fq` **[命令](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-zh-CN)**&#8203;管理优先挂卡队列。 最后，如果只需要挂您指定的游戏，可以设定 `FarmPriorityQueueOnly` **[机器人配置属性](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-zh-CN#机器人配置)**，并且将指定的游戏加入优先挂卡队列。

除了管理上述的自动挂卡模块之外，您也可以使用 ASF 手动模式，即 `play` **[命令](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-zh-CN)**，或者使用一些杂项设置，例如 `GamesPlayedWhileIdle` **[机器人配置属性](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-zh-CN#机器人配置)**。

---

### 我对挂卡不感兴趣，但我需要挂游戏时长，有办法做到吗？

是的，ASF 有几种方式可以为您做到这一点。

最佳方式是设置 **[`GamesPlayedWhileIdle`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-zh-CN#gamesplayedwhileidle)** 配置属性，ASF 就会在无卡可挂时挂您选择的 appID。 如果您希望即使仍有游戏未挂完卡，也始终挂这些游戏，那么您可以进一步设置 **[`FarmPriorityQueueOnly`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-zh-CN#farmpriorityqueueonly)** 属性，这样 ASF 就仅会为您明确指定的游戏挂卡，或者设置 **[`Paused`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-zh-CN#paused)** 属性，使挂卡模块完全暂停工作，直到您手动恢复。

另外一种方式是使用 **[`play`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-zh-CN#命令-1)** 命令，使 ASF 开始挂您选择的游戏。 然而，请注意 `play` 命令仅应该在您需要临时挂游戏的时候使用，因为它的状态不会长久保持，ASF 如果遇到从 Steam 断开连接等情况，就会恢复到它默认的状态。 因此，我们建议您使用 `GamesPlayedWhileIdle`，除非您确实只需要短时间运行所选游戏，然后恢复到正常的挂卡流程。

---

### 我是 Linux / macOS 用户，ASF 可以挂我的操作系统不支持的游戏吗？ 我可以在 32 位系统上挂 64 位游戏吗？

是的，ASF 甚至不需要下载实际的游戏文件，因此无论游戏的系统或技术需求如何，它对您 Steam 帐户内的所有游戏许可都有效。 它甚至可以在您不处于指定区域的情况下运行区域限制（锁区）的游戏，但是我们无法保证这一点（我们上次尝试时仍然可以）。

---

## 与类似工具的对比

---

### ASF 类似于 Idle Master 吗？

二者之间的唯一相似之处就是它们的目标，即挂机 Steam 游戏以获取掉落的卡牌。 任何其他方面，包括实际的挂机方法、使用的算法、程序的结构、功能、兼容性以及源代码本身都完全不同，二者之间毫无共同之处，甚至连程序的核心也是如此——IM 运行于 .NET 框架，而 ASF 运行于 .NET（Core）。 ASF 是为了解决 IM 的问题而编写的，这些问题无法通过简单地给 IM 代码打补丁来解决——这也是为何 ASF 完全从零开始，没有使用一行 IM 的代码，也没有借鉴它的程序逻辑，因为 IM 的代码与逻辑在一开始就存在缺陷。 IM 和 ASF 就好像 Windows 与 Linux——两者都是可以安装在您的 PC 上的操作系统，但除了这一目标之外，二者之间几乎毫无相似之处。

这也是为何您不应该根据对 IM 的期望比较 ASF 与 IM。 您应该将 ASF 与 IM 视为各有独特功能的完全独立的程序。 您可以在二者中找到一些重叠的功能，但很少，因为 ASF 使用与 IM 完全不同的方法来实现目标。

---

### 我现在正在使用 Idle Master，并且它很好用，我有必要换成 ASF 吗？

**是的**。 ASF 更可靠，包含许多内置功能，无论您以何种方式挂卡，这些功能都非常**关键**，而 IM 完全没有提供这些。

ASF 的逻辑能够正确处理**尚未发布的游戏**——而 IM 会尝试挂尚未发布的有卡游戏。 当然，在游戏发行之前是无法挂卡的，所以您的挂卡进程会被卡住。 此时您只能将此游戏添加到黑名单并等待游戏发布，或者手动跳过这款游戏。 这两种解决方案都不完善，都需要您的干预——ASF 会自动（暂时）跳过尚未发布游戏的挂卡流程，然后在游戏发布之后恢复挂卡，完美地避免了上述的问题。

ASF 的逻辑还能够正确处理**系列**视频。 Steam 上有许多视频也含有卡牌，但在徽章页面上标记了错误的 `appID`，例如 **[Double Fine Adventure](https://store.steampowered.com/app/402590)**——IM 将会以错误的 `appID` 挂卡，导致挂卡过程卡住，无法获得任何卡牌。 同样地，您需要将其列入黑名单或者手动跳过，仍然都需要您的干预。 而 ASF 会自动找到正确的、可以正常掉卡的 `appID`。

除此之外，ASF 在遇到网络问题或者 Steam 方面的问题时**更加稳定可靠**——ASF 在绝大多数时间都能够正常工作，只要您正确配置一次，就几乎不再需要您操心，而 IM 经常会发生各种错误，需要额外的修复工作，甚至完全不能用。 它还完全依赖于您的 Steam 客户端，这意味着如果您的 Steam 客户端遇到了问题，它也无法正常工作。 ASF 只要能够连接到 Steam 网络，就可以正常工作，并且完全不需要运行甚至安装 Steam 客户端。

这是 3 点使用 ASF 的**重要**理由，因为它们直接影响到每个人的挂卡过程，谁也无法肯定“这与我无关”，因为 Steam 的维护和故障会影响到所有人。 在下文中，您可以了解到一些或重要或不重要的额外理由。 因此，一句话来说，**是的**，即使您不需要 ASF 比 IM 多的额外功能，也应该考虑使用 ASF。

除此之外，IM 项目已经正式停止，在将来会完全失效，因为现在已有更强大的解决方案（不仅仅有 ASF），没有人愿意继续修复 IM。 无法使用 IM 的用户已经有很多，这个数字只会上升而不会下降。 您应该始终避免使用过时的软件，不仅仅有 IM，也包括任何其他已被废弃的程序。 无人维护意味着没有人在乎它还是否有效，没有人验证，也**没有人对其功能负责**，这在安全性方面是一个至关重要的问题。 其中可能存在对 Steam 基础设施有害的致命错误——没有人修复，如果 Steam 进行另一波封禁，使用者就会受到影响，而完全不知道原因是什么，猜猜谁曾经经历过这样的事情？正是使用过时版本 ASF 的用户。

---

### ASF 提供了什么 Idle Master 没有的好玩功能？

这要取决于您认为怎样才算是“好玩”。 如果您计划为多个帐户挂卡，则答案已经很明显了，因为 ASF 允许您用一套优秀的解决方案为所有帐户挂卡，避免浪费资源、遇到麻烦以及兼容性问题。 但如果您能问出这个问题，很可能您还没有这种特殊需求，所以我们来看看 ASF 能够为单帐户挂卡的用户带来什么其他好处。

首先，如果您的目标仅仅是挂卡，**[上述](#我现在正在使用-idle-master并且它很好用我有必要换成-asf-吗)**&#8203;的内置挂卡核心功能通常已经可以满足需求。 但您已经知道这一点了，我们需要看看更有趣的功能：

- **您可以离线挂卡**（设置 `OnlineStatus` 为 `Offline`）。 离线挂卡使您可以完全隐藏 Steam 的“游戏中”状态，在 Steam 显示您“在线”的同时，ASF 仍可以继续挂卡，您的朋友不会发现 ASF 正在代替您玩游戏。 这是一个超赞的功能，您可以保持 Steam 客户端为在线状态，不再有经常变化的游戏提醒来烦扰您的朋友，或者使您的朋友误认为您正在玩游戏。 如果您尊重您的朋友，仅凭这一点，就应该使用 ASF，但这仅仅是个开始。 值得注意的是，这个特性与您的 Steam 隐私设置无关——如果您自己运行游戏，仍然会向您的朋友展示正确的游戏状态，只有 ASF 部分是隐藏的，不会影响您的帐户。

- **您可以跳过仍可退款的游戏**（`SkipRefundableGames` 功能）。 ASF 的内部逻辑能够正确处理可退款的游戏，您可以设置 ASF 不自动开始挂仍可以退款的游戏。 这样您就可以自己检查从 Steam 商店购买的游戏是否值得您花的钱，而不是让 ASF 尽快挂完游戏的卡牌。 如果您玩了 2 小时以上，或者已经购买超过 2 周，那么 ASF 将继续挂此游戏，因为此时它不再可以无条件退款。 在此之前，您对此游戏有完全的控制权，如果您不喜欢，可以直接退款，整个过程都不需要您将该游戏加入挂卡黑名单，也不需要避免在此期间打开 ASF。

- **您可以自动将新物品通知标记为已读**（设置 `BotBehaviour` 为 `DismissInventoryNotifications`）。 用 ASF 挂卡会使您的帐户收到新的卡牌掉落。 既然您已经知道会发生这种情况，就可以让 ASF 为您清除这些无用的通知，确保您只需要注意重要的通知。 当然，这取决于您自己。

- **您可以在 Steam 特卖期间自动获得卡牌**（`AutoSteamSaleEvent`）。 如果您愿意，可以使用 ASF 在 Steam 特卖期间自动浏览探索队列。 这可以在特卖期间为您节省大量的时间，并且确保您永远不会错过每日获得卡牌的机会。

- **您可以使用丰富的选项自定义挂卡顺序**（`FarmingOrders`）。 也许您希望先挂新买的游戏？ 或者最早购买的？ 按照游戏掉卡数量的顺序？ 您已合成的徽章等级顺序？ 游戏时间顺序？ 字母顺序？ AppID 顺序？ 或者完全随机？ 这完全取决于您自己。

- **ASF 可以帮助您收集卡牌套组**（设置 `TradingPreferences` 为 `SteamTradeMatcher`）。 通过更高级的调整，您可以将 ASF 转换为全功能的用户机器人，能够自动接受 **[STM](https://www.steamtradematcher.com)** 交易报价，每天帮助您匹配物品交易，而无需您的干预。 ASF 还包括内置的 ASF 2FA 模块，您可以导入自己的 Steam 手机验证器，这样您就不再需要进行手机交易确认，完全自动化整个过程。 或者，也许您只需要 ASF 为您提供交易报价，但仍然自己手动接受交易？ 再次说明，这完全取决于您自己。

- **ASF 可以在后台帮您激活序列号**（**[后台游戏激活器](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer-zh-CN)**&#8203;功能）。 也许您有来自于各种游戏包的上百个游戏序列号，懒得手动一次次打开激活窗口、同意 Steam 的条款并输入序列号。 为什么不将一个序列号列表复制粘贴给 ASF，将其他事情交给它来做？ ASF 会自动在后台激活这些序列号，为您输出适当的信息，使您知道每次激活的结果。 此外，如果您有上百个序列号，很快就会触发 Steam 的激活频率限制，ASF 也知道这一点，它将耐心等待频率限制失效，然后从上次停止的地方恢复。

虽然我们可以在这里列出所有 **[ASF Wiki](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Home-zh-CN)** 上所述的每个功能，但是没有必要这样做。 作为 ASF 用户，您可以体验以上所有功能，其中每一个都可能使您再也离不开 ASF，实际上我们还提供了**很多**功能，您可以继续阅读 Wiki 的其他章节来逐渐了解。 啊，是的，为了保持答案的简洁，我们甚至还没有详细介绍 ASF 的 API，您可以通过它来编写自己的命令脚本或者进行炫酷的机器人管理工作。

---

### ASF 的速度比 Idle Master 快吗？

**是的**，但解释起来有些复杂。

每当您的系统生成新进程或中止进程，Steam 客户端都会自动发送一条包含所有您当前运行游戏的请求——这使 Steam 网络可以计算您的游戏时间并以此掉落卡牌。 但是，Steam 网络的游戏时间最小单位是 1 秒，发送新请求会重置当前状态。 换句话说，如果您每隔 0.5 秒就生成/停止一个新进程，就永远不会掉落卡牌，因为每隔 0.5 秒 Steam 客户端就会发送一个新请求，但每次请求的游戏时间都不足 1 秒，Steam 网络也就不会记录任何游戏时间。 此外，由于操作系统的工作原理，即使您什么也不做，生成/中止新进程的过程也始终在发生——有许多进程仍在后台运行，随时生成/中止新进程。 Idle Master 是基于 Steam 客户端的，因此也会受此机制的影响。

ASF 不基于 Steam 客户端，而是使用自己的 Steam 客户端实现。 正因为如此，ASF 不需要生成任何进程，而是向 Steam 网络发送了一个真正的请求，表示我们已开始玩游戏。 这与 Steam 客户端发送的请求相同，但由于我们能够实际控制自己的 Steam 客户端，因此我们不需要生成新进程，也不需要在每次进程发生变动时模拟 Steam 客户端发送请求，因此上述的机制对我们毫无影响。 因此，我们永远不会使 Steam Web 发生 1 秒的中断，也就提高了挂卡速度。

---

### 但这种差距真的很明显吗？

不。 正常 Steam 客户端与 Idle Master 发生的中断对卡牌掉落的影响可以忽略不计，因此这一点并非是让 ASF 优秀的明显差异。

但这仍然**是**差异，如果您的操作系统非常繁忙，在极端情况下，您可能注意到卡牌掉落**会加快**几秒甚至几分钟。 我不会仅仅因为 ASF 挂卡更快而选择它，因为 ASF 和 Idle Master 都受到 Steam Web 服务的影响，但是 ASF 与 Steam 服务的交互方式更高效，而 Idle Master 没有能力控制 Steam 客户端做什么（当然这是 Steam 客户端本身而非 Idle Master 的问题）。

---

### ASF 可以同时挂多个游戏吗？

**是的**，基于选择的&#8203;**[挂卡算法](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance-zh-CN)**，ASF 知道自己应该在什么时候启用这一功能。 同时挂多款游戏时，卡牌掉落率几乎接近零，因此 ASF 只会在批量挂游戏时间到 `HoursUntilCardDrops` 时才会同时挂多款游戏，每次最多挂 `32` 款游戏。 这也是为何您只应该专注于 ASF 配置，让挂卡算法决定达成目标的最优方式——您认为正确的方法，在现实中不一定正确，同时挂多款游戏并不会加快您的卡牌掉落。

---

### ASF 可以快速切换游戏吗？

**不**，ASF 既不支持，也不鼓励使用 **[Steam 漏洞](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance-zh-CN#steam-漏洞)**。

---

### ASF 可以自动为每个尚未加入卡牌的游戏挂 X 小时吗？

**不**，Steam 卡牌系统的变更旨在对抗错误的统计与虚假玩家。 ASF 不会为这种现象贡献更多力量，将来也不会添加这样的功能。 如果您的游戏像平常一样能够掉落卡牌，ASF 仍然会尽快开始挂它们。

---

### 我可以在 ASF 挂卡时玩游戏吗？

**不**。 ASF 与 IM 的不同之处是有独立的 Steam 客户端，而 Steam 网络一次只允许**一个 Steam 客户端**玩游戏。 但您可以随时启动游戏（如果 Steam 询问您是否要断开其他会话，选择“继续启动”），这会断开 ASF 的连接——ASF 将耐心等待您退出游戏，并在此之后继续挂卡。 或者，如果您愿意的话，可以随时在离线模式下玩游戏。

请记住，同时运行多款游戏时，掉卡速率总会降到 0，因此 IM 在这一点上也没有明显的优势，但使用 ASF 不会干扰您运行其他游戏，这一点在 VAC 等方面至关重要。

---

## 安全/隐私/VAC/封禁/订户协议

---

### 我会因使用 ASF 受到 VAC 封禁吗？

不，这是不可能的，因为 ASF（与 Idle Master 和 SAM 不同）不会以任何手段干预 Steam 客户端及其进程。 使用 ASF 不可能受到 VAC 封禁，即使您在运行 ASF 的同时进入安全服务器游玩也不会——因为 **ASF 甚至不需要您安装 Steam 客户端**也可以正常工作。 ASF 是目前唯一能够保证 VAC 安全的挂卡程序。

---

### ASF 会像[**这里**](https://support.steampowered.com/kb_article.php?ref=2117-ilzv-2837)所提到的那样，导致我无法加入 VAC 安全服务器吗？

ASF 根本不需要您运行，甚至都不需要安装 Steam 客户端。 根据这一概念，它应该**无法**造成任何 VAC 相关的问题，因为 ASF 保证不干扰 Steam 客户端及其所有进程——这是讨论 ASF 的 VAC 安全保证的要点。

据用户与我所知，目前的情况就是这样，因为没有人报告在使用 ASF 时遇到上述链接中所述的任何问题。 我们也无法使用 ASF 重现上述问题，但可以用 Idle Master 清楚地重现问题。

但是，请记住，Valve 仍可能在未来将 ASF 添加到黑名单中，但这样做没有意义，即使他们这样做，您仍然可以在 PC 上玩受 VAC 保护的游戏，同时在服务器上使用 ASF，所以我很确定他们非常清楚 ASF 没有 VAC 嫌疑，他们也不会无缘无故地将 ASF 列入黑名单而给我们带来麻烦。 尽管如此，在最糟糕的情况下，您将无法进行游戏，因为无论 Steam 是否屏蔽 ASF 程序，ASF 的 VAC 安全保证仍然有效（您仍然可以在另一台未安装 Steam 客户端的设备上运行 ASF）。 目前您没有必要这样做，我们都希望保持现状。

---

### 它安全吗？

如果您询问 ASF 作为软件是否安全，或者说它是否对您的计算机有害、是否窃取您的私人数据、是否为您安装病毒等恶意程序，则这个问题的答案是——它很安全。 ASF 没有恶意软件、数据挖掘、加密货币挖矿，以及任何（所有）其他可能被用户视为有危害或者不希望的可疑行为。 除此之外，我们有一个专门的[**远程通信**](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Remote-communication-zh-CN)章节，涵盖了我们的隐私政策，以及超出了您自己为程序配置的功能的 ASF 行为。

我们的代码是开源的，并且分发的二进制文件总是由&#8203;**[来源公开](https://en.wikipedia.org/wiki/Open-source_software)**&#8203;的&#8203;**[自动化并且可信的 CI 系统](https://en.wikipedia.org/wiki/Build_automation)**&#8203;而不是开发者编译。 每个构建都可以由我们的构建脚本重现，并产生完全相同、**[确定](https://en.wikipedia.org/wiki/Deterministic_system)**&#8203;的 IL（二进制）代码。 如果您出于任何原因不信任我们的构建，您随时可以从源代码以及 ASF 使用的所有依赖库（例如 SteamKit2）编译 ASF，这些库也同样是开源的。

但最终，是否信任应用程序的开发者始终是一个问题，因此您应该自己决定是否视 ASF 为安全，并可能需要通过上述的技术论证支持您的决定。 不要盲目信任我说的话——相信自己，因为这是唯一的办法。

---

### 我会因此受到封禁吗？

要回答这个问题，我们首先应该仔细阅读 **[Steam 订户协议](https://store.steampowered.com/subscriber_agreement)**。 Steam 不禁止用户使用多个帐户，事实上，Steam **[允许](https://support.steampowered.com/kb_article.php?ref=8625-WRAH-9030#share)**&#8203;您为多个帐户使用同一个手机验证器。 但他们不允许与其他人共享帐户，而我们并没有这样做。

ASF 真正需要关注的重点是：
> You may not use Cheats, automation software (bots), mods, hacks, or any other unauthorized third-party software, to modify or automate any Subscription Marketplace process.（参考译文：您不得使用作弊软件、自动化软件、机器人、模组、破解或任何其他未经授权的第三方软件来修改或自动执行任何订购市场流程。）

问题是，Subscription Marketplace（参考译文：订购市场）究竟是什么。 我们可以读到：

> An example of a Subscription Marketplace is the Steam Community Market（参考译文：订购市场的一个示例是 Steam 社区市场）

如果订购市场指的就是 Steam 社区市场或 Steam 商店，则我们不会修改或自动化订购市场流程。 然而……

> Valve may cancel your Account or any particular Subscription(s) at any time in the event that (a) Valve ceases providing such Subscriptions to similarly situated Subscribers generally, or (b) you breach any terms of this Agreement (including any Subscription Terms or Rules of Use).（参考译文：Valve 随时可以在以下情况停止您的帐户或者中止订阅：(a) Valve 不再向此类订阅者提供订阅服务，或 (b) 您违反了本协议中的条款，包括任何订阅条款和使用规则。）

因此，与每款 Steam 软件一样，ASF 未经 Valve 授权，如果 Valve 突然决定封禁使用 ASF 的用户，我无法保证您不会被中止服务。 考虑到目前已有上百万个 Steam 帐户正在使用 ASF，这是极不可能的，但无论其概率多低，都仍有此可能。

特别是因为：
> In regard to all Subscriptions, Content and Services that are not authored by Valve, Valve does not screen such third-party content available on Steam or through other sources.（参考译文：对于不是由 Valve 创作的订阅、内容和服务，Valve 不会在 Steam 或其他来源上屏蔽此类第三方内容。） Valve assumes no responsibility or liability for such third party content.（参考译文：Valve 对此类第三方内容不承担任何责任。） Some third-party application software is capable of being used by businesses for business purposes - however, you may only acquire such software via Steam for private personal use.（参考译文：某些第三方应用软件能够被企业用于商业目的——但是，您通过 Steam 购买的此类软件仅供私人个人使用。）

然而，如&#8203;**[此文章](https://support.steampowered.com/kb_article.php?ref=2117-ilzv-2837)**&#8203;所述，Valve 明确知晓“Steam 挂机工具”的存在，因此，如果您问我，我很确定如果他们认为这种行为不妥，就早已采取措施来阻止，而不是指出这种行为会造成 VAC 的故障了。 这里的关键词是 **Steam** 挂机工具，例如 ASF，而不是**游戏**挂机工具。

请注意，上文只是我们对 **[Steam 订户协议](https://store.steampowered.com/subscriber_agreement)**&#8203;及其各条目的解释——ASF 本身依据 Apache 2.0 许可证授权，其中明确规定：

> Unless required by applicable law or agreed to in writing, ASF is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.（参考译文：除非适用法律要求或书面同意，否则 ASF 将按“原样”分发，不附带任何明示或暗示的担保或条件。）

您使用此软件的风险由您自己承担。 您不可能因此受到封禁，但如果您被封禁了，原因只能是您自己。

---

### 曾经有人因此被封禁吗？

**是的**，到目前为止，发生过几起导致 Steam 封禁的事件。 这几起事件的根本原因是否是 ASF，已经不得而知。

第一起事件是一名拥有超过 1000 个机器人的用户（包括他的所有机器人）受到交易封禁，原因很可能是使用 `loot ASF` 命令对所有机器人进行操作，或者是其他能够在短时间发送大量交易的操作。

> Hello XXX, Thank you for contacting Steam Support.（译文：感谢您联系 Steam 客服。） It looks like this account was used to manage a network of bot accounts.（译文：看起来您的帐户被用于管理一个机器人帐户网络。） Botting is a violation of the Steam Subscriber Agreement.（译文：使用机器人违反了 Steam 订户协议。）

请您了解一些常识，不要因为 ASF 允许您做，就做这种疯狂的事情。 对超过 1000 个机器人发起 `loot ASF` 请求完全可以视为一次 **[DDoS](https://en.wikipedia.org/wiki/DDoS)** 攻击，就我个人而言，我并不惊讶有人因为这种事情被封禁。 请了解有关 Steam 服务的一些基本常识，只要您不滥用 Steam 服务，就**几乎不可能**遇到问题。

第二起事件是一名拥有超过 170 个机器人的用户在 2017 年 Steam 冬季特卖期间被封禁。

> Your account was blocked for violation of the agreement of the subscriber Steam.（译文：您的帐户因为违反 Steam 订户协议而被封禁。） Judging by the exchanges and other factors, this account was used to illegally collect collectible cards on Steam, as well as related and not only commercial activities.（译文：从交易和其他因素来看，这个帐户被用来非法收集 Steam 集换式卡牌，以及相关的商业以外的活动。） The account has been permanently blocked and Steam Support can not provide additional support on this issue.（译文：此帐户已被永久封禁，Steam 客服无法在此问题上为您提供进一步帮助。）

这起事件同样难以分析，因为 Steam 客服的回应非常模糊，几乎没有提供任何细节。 根据我个人的想法，这名用户可能用 Steam 卡牌兑换了某种金钱（等级机器人？）或者以其他方式进行了 Steam 套现。 您也许不了解，但这种行为同样违反 **[Steam 订户协议](https://store.steampowered.com/subscriber_agreement)**。

第三起事件涉及一名拥有超过 120 个机器人的用户，因违反 **[Steam 在线行为准则](https://store.steampowered.com/online_conduct?l=english)**&#8203;而被封禁。

> Hello XXX, Thank you for contacting Steam Support.（译文：感谢您联系 Steam 客服。） This and other accounts were used for flooding our network infrastructure, which is a violation of Steam online conduct.（译文：此帐户和其他帐户被用于攻击我们的网络设备，违反了 Steam 在线行为准则。） The account has been permanently blocked and Steam Support can not provide additional support on this issue.（译文：此帐户已被永久封禁，Steam 客服无法在此问题上为您提供进一步帮助。）

这起事件比较容易分析，因为这名用户提供了额外的细节。 显然这名用户在使用一个**过期已久的 ASF 版本**，其中有一个向 Steam 服务器发送过多请求的漏洞。 这个漏洞并非一开始就存在，但是 Steam 之后的一些变化导致了这个漏洞，此时 ASF 的新版本早已修复这个问题。 **只有在 GitHub 上发布的&#8203;[最新稳定版本](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest) ASF 才受我们支持**。 软件是由人类编写的，而人类往往会犯错误。 如果错误会影响所有人，就会被快速修复并作为补丁发布给所有用户。 显然，Valve 不会因为我犯的错误而突然封禁上百万 ASF 用户。 但如果您故意放弃使用最新版本的 ASF，则您就将自己归类于极少数用户，因为**没有技术支持**，您将会**暴露于类似的问题下**，因为没有人会关注您的过期版本 ASF，没有人会为它修复漏洞，没有人可以保证您在启动程序时不会被封禁。 **请使用最新版本的软件**，不仅是 ASF，也包括其他所有应用程序。

最近一起事件发生在 2021 年 6 月左右，据此用户称：

> 我一直在使用你的程序，在过去 3 年里为 28 个帐户制作补充包，并且在最近 6 个月提高到 128 个帐户。 制作补充包时，我会让最多 15 个帐户同时在线，制作完成后再发送到主帐户上。 上个月，我将同时在线帐户数提升到 20，一周之后，我的所有帐户都已被封禁。 这封邮件并非责怪你，相反，我自始至终都清楚这种后果。 我希望你们能借此了解什么样的行为会导致永久封禁。

我们很难下结论说提升同时在线帐户数是封禁的直接原因，至少我不这么认为，相反，我相信拥有大量帐户本身才是罪魁祸首，提升同时在线数可能仅仅导致这名用户违反规定的行为被人发现，显然他拥有的帐户数量远远超过我们的建议。

---

以上所有事件都有一个共同点——ASF 只是一个工具，如何利用它完全取决于**您自己**。 您不会直接因为使用 ASF 被封禁，但您的**使用方式**可能会导致封禁。 ASF 可以是一个单帐户的挂卡助手，也可以用于管理含有成千上万机器人的挂卡网络。 在任何情况下，我都不提供法律咨询，您应该一开始就决定好自己如何使用 ASF。 我没有隐瞒任何对您有帮助的信息，例如 ASF 导致用户被封禁的事件等，因为我没有理由隐瞒这些——您可以自由选择您想用这些信息做什么。 如果您问我有什么建议——那么请您了解一些常识、避免持有超过我们推荐数量的机器人、不要同时发送上百个交易、始终使用最新版 ASF，这样您就_应该_不会有任何问题。 出于**某种原因**，每起类似事件的当事人都选择无视我们的建议，并认为自己比我们更清楚他们能运行多少个机器人。 不管这是因为巧合还是有实际的原因，这都由您自己决定。 我不会提供任何法律建议，仅仅是将我的想法告诉您，您可能在其中找到有用的内容，或者完全无视，只根据上文所述的事实操作。

---

### ASF 会收集哪些隐私信息？

您可以在[**远程通信**](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Remote-communication-zh-CN)章节详细了解。 如果您关心您的隐私，例如，您想知道为何使用 ASF 的帐户需要加入我们的 Steam 群组，就需要审查我们的隐私策略。 ASF 不会收集任何敏感信息，也不会将统计信息分享给第三方。

---

## 杂项

---

### 我正在用不受支持的操作系统，例如 32 位 Windows，我仍然可以使用最新版的 ASF 吗？

是的，这个版本并非不受支持，只不过我们没有提供官方包。 您可以在&#8203;**[兼容性](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility-zh-CN)**&#8203;章节了解 Generic 包。 ASF 没有任何对于操作系统的强制依赖，您可以在任何含有 .NET 运行时环境的地方运行 ASF，其中就包括 32 位 Windows，即使我们没有提供针对 `win-x86` 平台的包。

---

### ASF 很赞！ 我可以捐助吗？

是的，我们很高兴听到您喜欢我们的项目！ 您可以在&#8203;**[项目主页](https://github.com/JustArchiNET/ArchiSteamFarm)**&#8203;和每个&#8203;**[版本发布页](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)**&#8203;下方找到各种捐赠渠道。 值得注意的是，除了常规的现金捐赠，我们也接受 Steam 物品，只要您愿意，您可以向我们捐赠游戏皮肤、钥匙或者您的一部分挂卡所得。 提前感谢您的慷慨！

---

### 我启用了 Steam 家庭监护 PIN 代码来保护我的帐户，我需要将它填写在什么地方吗？

是的，您必须将它填入 `SteamParentalCode` 机器人配置属性。 这主要是因为 ASF 需要访问帐户内许多受保护的部分，如果没有解锁代码，ASF 就无法正常运行。

---

### 我希望 ASF 默认不挂任何游戏，只使用 ASF 的附加功能。 可以做到吗？

是的，如果您希望 ASF 在启动时暂停挂卡模块，可以将机器人的 `Paused` 配置属性设置为 `true` 来实现这一点。 您可以在运行时执行 `resume` 命令来恢复挂卡。

如果您希望完全禁用挂卡模块，并确保它永远不会在您没有明确指定时运行，那么，我们建议您设置 `FarmPriorityQueueOnly` 为 `true`，而不是仅仅暂停模块，这将会完全禁用自动挂卡，直到您自己向挂卡优先队列内添加游戏。

通过暂停/禁用挂卡模块，您可以仅使用 ASF 的额外功能，例如 `GamesPlayedWhileIdle`。

---

### ASF 能最小化到托盘吗？

ASF 是一个控制台应用程序，没有可以最小化的图形窗口，因为控制台窗口是由您的操作系统创建的。 但您可以使用任何第三方工具做到这一点，例如 Windows 的 **[RBTray](https://github.com/benbuck/rbtray)** 或者 Linux/macOS 的 **[screen](https://linux.die.net/man/1/screen)**。 这些只是例子，还有许多具有类似功能的应用程序。

---

### 使用 ASF 能否保持获得补充包的资格？

**是的**。 ASF 使用与官方 Steam 客户端相同的方式登录到 Steam 网络，因此它也有能力使 ASF 使用的帐户保持获得补充包的资格。 另外，保持这种资格甚至不需要登录到 Steam 社区，所以如果您愿意，您可以安全地设置 `OnlineStatus` 为 `Offline`。

---

### 有办法在外部与 ASF 通信吗？

是的，有几种方式可以做到。 请阅读&#8203;**[命令](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-zh-CN)**&#8203;章节了解详情。

---

### 我想要帮助翻译 ASF，需要做什么？

感谢您愿意提供帮助！ 您可以在&#8203;**[本地化](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Localization-zh-CN)**&#8203;章节了解详情。

---

### 我在 ASF 中只设置了一个帐户，还能够通过 Steam 聊天发送命令吗？

**是的**，**[命令](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-zh-CN#备注)**&#8203;章节中详细介绍了这一点。 您可以使用 Steam 群组聊天，但 **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-zh-CN#asf-ui)** 可能是个更简单的方法。

---

### ASF 已运行，但我没获得任何卡牌掉落！

不同游戏的卡牌掉落速率有所区别，您可以阅读&#8203;**[性能](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance-zh-CN)**&#8203;详细了解。 这需要花费一定时间，通常**每款游戏几小时**，您不应该期望运行程序几分钟就可以获得卡牌。 如果您看见 ASF 主动检查卡牌状态，并在一款游戏挂卡完成后切换到另一款游戏，则说明一切正常。 也有可能您为 `BotBehaviour` 属性设置了 `DismissInventoryNotifications` 选项，使您无法收到获得新物品的通知。 详见&#8203;**[配置](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-zh-CN)**。

---

### 如何让 ASF 完全断开我的帐户？

在 Windows 上，您可以直接点击 [X] 关闭 ASF 进程。 如果您只想停止一个机器人，但是保持其他机器人运行，可以了解 `Enabled` **[机器人配置属性](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-zh-CN#机器人配置)**，或者 `stop` **[命令](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-zh-CN)**。 如果您只想停止自动挂卡，但是保持帐户运行，可以使用 `Paused` **[机器人配置属性](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-zh-CN#机器人配置)**&#8203;和 `pause` **[命令](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-zh-CN)**。

---

### ASF 可以运行多少个机器人？

ASF 程序本身没有硬性限制机器人实例数量，所以只要您的机器有足够的内存，就可以运行任意数量的机器人，但您还会受到 Steam 网络和其他 Steam 服务的限制。 目前，您可以在单 IP 单 ASF 实例中运行至多 100-200 个机器人。 通过解决 IP 限制，您可以使用更多 IP 和更多 ASF 实例来运行更多的机器人。 请记住，如果您使用的机器人过多，则应该自行控制它们的数量，确保它们能够同时正常登录和运行。 ASF 没有优化有大量机器人的情况，一条一般规则是**您的机器人越多，您就会遇到越多的问题**。 还要注意的是，上述限制取决于许多内部因素，因此是一个近似值，而不是准确的限制——您遇到的机器人数量限制可能更多也可能更少。

ASF 团队建议您运行（包括**拥有**）**最多 10 个机器人**，如果您的机器人数量超过此数字，就需要自行承担风险，我们不建议也不支持这样做。 这项建议来自于 Valve 内部的指南，以及我们自己的建议。 您有权决定是否遵守此规则，即使您的操作会导致 Steam 帐户被停用，ASF 也不会阻止您，因为它只是一个工具。 因此，如果您忽略了我们的建议，ASF 将会向您显示警告，但您仍然可以进行任何操作，并且自行承担风险，我们不会对这些行为提供任何支持。

---

### 我可以同时运行多个 ASF 实例吗？

您可以在一台计算机上运行任意数量的 ASF 实例，前提是每个实例都有独立的文件夹和配置，并且在一个实例中使用的帐户没有在另一个实例中使用。 但是，您应该想想为什么要这样做。 ASF 已被优化至可以同时处理数百个帐户，运行独立的 ASF 实例会降低性能、占用更多系统资源（例如 CPU 和内存）、造成不同实例之间潜在的同步问题，因为 ASF 会被强制与其他实例共享限制。

因此，我**强烈建议**在每个 IP/接口上最多只运行一个 ASF 实例。 如果您有多个 IP/接口，这意味着您可以运行多个 ASF 实例，每个实例都使用自己独立的 IP/接口，或者使用唯一的 `WebProxy` 设置。 否则，开启多个 ASF 实例就是完全无意义的，因为在单个 IP/接口上启动多个实例没有任何好处。 ASF 本身并没有对此进行任何限制，但 Steam 不会仅仅因为您启用多个 ASF 实例就神奇地允许您运行更多机器人。

当然，仍有在同一个网络接口上运行多个 ASF 实例的合理场景，例如分别为您的朋友托管独立的 ASF 实例，以保证机器人之间，甚至 ASF 进程本身的隔离，然而，在这种情况下，您没有绕过任何 Steam 的限制，这是完全不同的目的。

---

### 激活游戏序列号时的状态是什么意思？

状态表示指定序列号的激活结果。 可能的状态有很多，其中最常见的有：

| 状态                      | 描述                                                                                             |
| ----------------------- | ---------------------------------------------------------------------------------------------- |
| NoDetail                | “OK”状态，表示成功——序列号已被成功激活。                                                                        |
| Timeout                 | Steam 网络没有在给定时间内响应，我们不知道序列号是否被激活（很可能已激活，但您可以重试一下）。                                             |
| BadActivationCode       | 提供的序列号无效（Steam 网络无法将其识别为有效的序列号）。                                                               |
| DuplicateActivationCode | 提供的序列号已经被其他帐户激活，或者已被开发商/发行商召回。                                                                 |
| AlreadyPurchased        | 您的帐户已经拥有此序列号绑定的 `packageID`。 请注意，此状态不能验证序列号是否为 `DuplicateActivationCode`，它仅仅表示这个序列号有效，但没有尝试激活。 |
| RestrictedCountry       | 此序列号有区域限制，不允许在您的帐户区域内激活。                                                                       |
| DoesNotOwnRequiredApp   | 您缺少激活此序列号所需的其他 App——通常表示您缺少激活 DLC 所需的游戏本体。                                                     |
| RateLimited             | 您在短时间内尝试激活的次数过多，您的帐户将被临时限制激活。 请等待一小时再尝试。                                                       |

---

### 你与任何挂卡服务有关联吗？

**不**。 ASF 不属于任何服务，一切类似的声明都是虚假的。 您的 Steam 帐户是您的财产，您可以通过任何方式使用您的帐户，但 Valve 在&#8203;**[官方订户协议](https://store.steampowered.com/subscriber_agreement)**&#8203;中明确指出：

> You are responsible for the confidentiality of your login and password and for the security of your computer system.（参考译文：您有责任保护您的用户名和密码以及保证计算机系统的安全性。） Valve is not responsible for the use of your password and Account or for all of the communication and activity on Steam that results from use of your login name and password by you, or by any person to whom you may have intentionally or by negligence disclosed your login and/or password in violation of this confidentiality provision.（参考译文：Valve 不负责您的密码和帐户的使用，也不对因您、您可能有意或因疏忽而泄露您的用户名和/或密码而导致的 Steam 上的任何通信和活动违反本保密条款负责。）

ASF 基于宽松的 Apache 2.0 许可证授权，允许其他开发者合法地将 ASF 与自己的项目或服务进一步集成。 但是，此类使用 ASF 的第三方项目无法保证是安全的、经过审查的、适当的或者遵守 **[Steam 订户协议](https://store.steampowered.com/subscriber_agreement)**&#8203;的。 如果您想了解我们的意见，**我们强烈建议您不要与第三方服务分享任何帐户详细信息**。 如果这样的服务是**典型的骗局**，您的 Steam 帐户很可能会被盗，而 ASF 不会对任何第三方服务的安全声明负责，因为 ASF 团队从未授权或审查这些服务。 换句话说，**如果您选择忽略我们的建议，就需要在使用这些服务时自行承担风险**。

此外，官方 **[Steam 订户协议](https://store.steampowered.com/subscriber_agreement)**&#8203;明确指出：

> You may not reveal, share or otherwise allow others to use your password or Account except as otherwise specifically authorized by Valve.（参考译文：除非 Valve 特别授权，否则您不得透露、分享或以其他方式允许他人使用您的密码或帐户。）

这是您的帐户与您的选择。 但不要说没人警告过您。 ASF 是一个遵守上述所有规则的程序，因为您没有与任何人分享您的帐户详细信息，您以个人用途使用此程序，但任何其他的“挂卡服务”都需要您提供帐户凭据，所以它们违反了上述规则（实际上是其中数条规则）。 就像之前的 **[Steam 订户协议](https://store.steampowered.com/subscriber_agreement)**&#8203;分析一样，我们不提供任何法律建议，您应该自己决定是否使用这些服务——我们的说法是，这种行为&#8203;**直接违反 [Steam 订户协议](https://store.steampowered.com/subscriber_agreement)**，如果 Valve 发现，您的 Steam 帐户就可能被停用。 如上文所述，**我们强烈建议不使用任何此类服务**。

---

## 异常情况

---

### 我的一款游戏已经挂卡超过 10 小时了，但仍然一张卡牌都没掉落！

此问题的原因可能是 Steam 的一个已知问题，即您拥有同一款游戏的两份许可，其中一份许可含有卡牌掉落限制。 通常这是因为您在 Steam 上领取了限时免费的游戏，同时又为同一款游戏激活了没有限制的序列号（例如来自付费捆绑包）。 如果出现这种情况，Steam 会在徽章页面上显示此游戏仍然有卡牌未掉落，但由于您的帐户拥有免费版本许可，无论您玩多久，都不会有卡牌掉落。 因为这不是 ASF 而是 Steam 的问题，我们无法在 ASF 一方绕过此问题，您必须自己解决。

有两种方式解决此问题。 第一种，您可以在 ASF 内使用 `fbadd` **[命令](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-zh-CN)**&#8203;或者 `Blacklist` **[配置属性](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-zh-CN)**&#8203;将此游戏加入黑名单。 这将阻止 ASF 为此游戏挂卡，但这种方法治标不治本，并未能真正解决阻止您从此游戏中获得卡牌的根本问题。 第二种，您可以使用 Steam 客服的自助服务工具移除帐户内的免费许可，仅保留能够掉落卡牌的完整版许可。 要做到这一点，首先您需要访问&#8203;**[查看许可和产品序列号激活](https://store.steampowered.com/account/licenses)**&#8203;页面，然后分别找到受影响游戏的免费与付费许可。 通常这非常简单——两者的名字相似，但免费版本的名字会包含“Limited Free Promotional Package”（限时免费促销包）或者类似“Promo”的单词，并且“获取方式”一列应显示为“免费赠送”。 但有时也会比较麻烦，例如免费许可也许在捆绑包中或者名称不同。 如果您找到了如上所述的两份许可——那么问题的根源就确实在此，您可以安全地移除免费许可，并且仍然保留游戏。

要从帐户内移除免费许可证，您需要访问 **[Steam 客服页面](https://help.steampowered.com/wizard/HelpWithGame)**，并在搜索框内输入受影响的游戏，这款游戏应该会出现在“产品”一栏中，点击此游戏。 或者，您也可以访问 `https://help.steampowered.com/wizard/HelpWithGame?appid=<appID>` 链接，但要把其中的 `<appID>` 替换为受影响游戏的实际 AppID。 然后，点击“我想从帐户中移除这款游戏”，再选择您之前找到的免费版本许可，即通常在名字中包含“Limited Free Promotional Package”（或类似内容）的那一个。 在移除免费许可之后，ASF 应该已经能够从受影响的游戏中正常获得卡牌，您需要在移除许可之后重新启动挂卡操作，确保 Steam 这次提供了正确的许可。

---

### ASF 无法检测到 `X` 游戏可以挂卡，但我知道这款游戏包含 Steam 卡牌！

这里有两个主要原因。 第一个也是最明显的原因是，您指的是这款游戏的 **Steam 商店页面**说明该游戏包含集换式卡牌。 这是**错误的**假设，因为它只是说明该游戏**支持**集换式卡牌，但不一定表示现在已经**启用**卡牌功能。 您可以阅读这篇&#8203;**[官方新闻](https://steamcommunity.com/games/593110/announcements/detail/1954971077935370845)**&#8203;了解更多。

简而言之，Steam 商店页面的集换式卡牌图标并不能代表什么，请检查您的&#8203;**[徽章页面](https://steamcommunity.com/my/badges)**，确认该游戏是否启用了卡牌掉落——这也是 ASF 采用的方式。 如果您的游戏没有出现在可掉落卡牌列表中，那么无论因为什么原因，这款游戏都**无法**挂卡。

第二个原因不是很明显，有时您的徽章页面确实说明该游戏可以掉落卡牌，但是 ASF 没有马上为它挂卡。 除非您遇到了其他漏洞，例如 ASF 无法检查徽章页面（如下所述），否则这只是一种缓存效果，即 ASF 访问的 Steam 徽章页面是过时的版本。 等缓存过期后，此问题很快就会自行解决。 我们也没有办法解决这个问题。

当然，上述说明都假设您以默认的配置运行 ASF，因为您可以通过配置来调整 ASF 的挂卡行为，包括将游戏加入挂卡黑名单，或设置 `FarmPriorityQueueOnly` 与 `SkipRefundableGames` 等等。

---

### 为什么通过 ASF 挂的游戏没有增加游戏时间？

游戏时间会增加，但**并非实时**。 Steam 会以固定的时间间隔记录游戏时间，然后设定更新计划，但这甚至无法保证您在退出游戏时立即更新，更不用说在游戏中了。 游戏时间没有实时更新并不意味着没有记录，通常这个数据会每大约 30 分钟更新一次。

---

### 日志中的错误（Error）与警告（Warning）有什么区别？

ASF 以不同的日志级别向日志中写入大量信息。 我们的目标是**准确地**解释 ASF 正在做什么，包括它必须处理的 Steam 的或者其他方面的问题。 大多数时候，不是所有的东西都是相关的，这也是为何我们在 ASF 中主要使用两个问题级别——警告与错误。

ASF 的一般规则是，警告**不是**错误，因此您**不**需要报告警告。 警告的意思是向您表明可能发生了一些预料之外的情况。 无论是 Steam 无响应、API 抛出错误还是您的网络连接出现问题——都会发生警告，这意味着我们已经预期到会发生这种情况，您不需要为此打扰 ASF 开发者。 当然，您可以通过我们的技术支持渠道向他们询问或者请求帮助，但不代表它们是值得报告的错误（除非我们另有确认）。

另一方面，错误表示不应该发生的情况，因此，只要您确定错误不是因您造成，就应该报告它们。 如果这是我们可预期发生的情况，它们将会被转换为警告。 否则，如果错误不是因为您的技术问题导致，它就可能是一个需要修复而不能忽略的漏洞。 例如，在 `ASF.json` 文件中写入无效的内容会抛出一个 ASF 无法解析的错误，但这些内容是您自己写入的，所以您不应该向我们报告这个错误（除非您确定您写入的结构是完全正确的，是 ASF 自己发生了错误）。

一言而蔽之——报告错误，而非警告。 但您仍然可以在我们的支持渠道询问有关警告的问题并获取帮助。

---

### ASF 无法启动，程序窗口立刻就退出了！

在正常条件下，任何 ASF 的崩溃或退出都会在程序目录内生成一份 `log.txt` 供您查看，这可能会对排查错误有帮助。 此外，一些较早的日志会被归档在 `logs` 文件夹下，因为每次运行时，ASF 都会生成新的 `log.txt` 覆盖原来的日志文件。

然而，如果连 .NET 运行时环境都无法在您的机器上启动，就无法生成 `log.txt`。 如果发生这种情况，很可能您忘了安装我们在&#8203;**[安装指南](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up-zh-CN#安装操作系统包)**&#8203;中提到的 .NET 依赖项。 其他的常见问题包括您启动了错误的操作系统版本，或者您缺少了本机 .NET 运行时环境依赖项。 如果控制台窗口关闭得太快，您就无法看到错误消息，您可以打开一个独立的控制台窗口，然后从中启动 ASF 二进制文件。 例如，在 Windows 上，打开 ASF 文件夹，按住 `Shift` 键，右键单击文件夹空白处，选择“*在此处打开命令窗口*”（或 *Powershell*），然后在控制台中输入 `.\ArchiSteamFarm.exe`，按回车键确认。 这样，您就可以获得 ASF 无法正常启动的原因说明。

---

### 在我玩游戏的时候，ASF 将我的 Steam 客户端踢掉线！ / *This account is logged on another PC*（这个帐户在另一台电脑登录）

您在游戏中时，Steam 界面会显示这条消息，表示该帐户正在其他地方使用。 此问题可能有两个不同的原因。

一个原因是游戏包本身有问题，有些游戏没有正确为游戏状态上锁，但却期望客户端持有此锁。 Skyrim SE 就是这类游戏的例子之一。 您的 Steam 客户端正确启动了游戏，但该游戏没有将自身注册为正在使用。 因此，ASF 认为挂卡过程可以安全恢复，并也这样做了，将您踢出了 Steam 网络，因为 Steam 突然检测到您的帐户正在另一个地方使用。

如果您在 ASF 等待期间（特别是在另一台机器上时）在 PC 上玩游戏时意外断开了网络连接，就会出现第二个原因。 在这种情况下，Steam 网络会将您标记为离线，并释放游戏锁（如上文所述），这将导致 ASF（在另一台机器上）恢复挂卡。 您的 PC 恢复连接后，Steam 已无法再获得此游戏锁（此时由 ASF 持有，类似上文的情况），并将显示该错误消息。

以上两种情况都非常难以由 ASF 解决，因为一旦 Steam 网络发出帐户不再被占用的消息，ASF 就会简单地恢复挂卡。 这也会发生在您关闭游戏的时候，但如果游戏本身有问题，即使您的游戏仍在运行，也可能立刻发生这种情况。 ASF 无法确定您的情况是网络连接断开、退出游戏还是游戏本身没有正常持有锁。

解决这个问题唯一正确的方法是在您玩游戏之前，通过 `pause` 命令手动暂停机器人，然后在退出之后通过 `resume` 命令恢复挂卡。 或者您也可以忽略此问题，选择以离线模式运行 Steam。

---

### `Disconnected from Steam!`（已从 Steam 断开连接）——我无法连接到 Steam 服务器。

ASF 只能**尝试**与 Steam 服务器建立连接，这可能会失败，其原因有很多，包括互联网连接有问题、Steam 宕机、防火墙阻断了连接、第三方工具、路由配置无效或者仅仅是临时故障。 您可以启用 `Debug` 模式以查看更详细的日志，其中会说明失败的具体原因，但通常这只是您自己的操作造成的，例如使用了“CS:GO MM Server Picker（匹配服务器选择器）”，该工具会屏蔽很多 Steam 的 IP 地址，使您难以连接 Steam 网络。

ASF 将尽最大努力建立连接，不仅包括拉取最新的服务器列表，还包括在连接服务器失败时尝试另一个 IP，因此，如果您遇到的仅仅是某个特定服务器或者路由的临时问题，ASF 最终总能建立连接。 但是，如果您处于防火墙后面，或者因为其他愿原因无法连接 Steam 服务器，那么显然您需要自己修复问题，此时 `Debug` 模式能够为您提供帮助。

也可能您的计算机无法使用 ASF 采用的默认协议与 Steam 服务器建立连接。 您可以修改 `SteamProtocols` 全局配置属性，更改 ASF 使用的网络协议。 例如，如果您无法通过 `UDP` 协议连接到 Steam（因防火墙等原因），也许将这个属性改为 `TCP` 或 `WebSocket` 就可以解决问题。

还有一种极为罕见的情况，即服务器缓存不正确，例如，将 ASF 的 `config` 文件夹移动到另一台位于其他国家的设备上，此时删除 `ASF.db` 文件即可在下一次启动时刷新 Steam 服务器列表。 通常情况下，您不需要这样做，因为该列表在首次启动以及建立连接时都会自动刷新——我们只是在此说明，您可以用这种方式强制清除 ASF 缓存的服务器列表。

---

### `无法获取徽章信息，将稍后再试 ！`

通常情况下，这意味着您需要通过 Steam 家庭监护 PIN 码来访问帐户，但您忘了将其写在 ASF 配置中。 您必须把正确的 PIN 码写在 `SteamParentalCode` 机器人配置属性中，否则 ASF 就无法访问大多数 Web 内容，因而无法正常工作。 您可以阅读&#8203;**[配置](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-zh-CN)**&#8203;进一步了解 `SteamParentalCode`。

其他原因包括暂时的 Steam 问题、网络问题等。 如果几个小时后，问题仍然没有恢复，并且您确认您的 ASF 配置是正确的，请向我们反馈。

---

### ASF 发生 `Request failed after 5 tries`（该请求在 5 次尝试后失败）错误！

通常情况下，这意味着您需要通过 Steam 家庭监护 PIN 码来访问帐户，但您忘了将其写在 ASF 配置中。 您必须把正确的 PIN 码写在 `SteamParentalCode` 机器人配置属性中，否则 ASF 就无法访问大多数 Web 内容，因而无法正常工作。 您可以阅读&#8203;**[配置](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-zh-CN)**&#8203;进一步了解 `SteamParentalCode`。

如果不是因为家庭监护 PIN，那么这是一个最常见的错误，您应该习惯这一点，它只是意味着 ASF 向 Steam 网络连续发送了 5 次请求，但没有得到有效的响应。 通常情况下，这意味着 Steam 宕机了、出现问题或者正在维护——ASF 能够发现这样的问题，您不应该为此担心，除非这种情况连续发生了几个小时，并且其他用户没有发生同样的问题。

如何检查 Steam 是否宕机？ **[Steam Status](https://steamstat.us)** 是一个检查 Steam 服务器是否**应该**正常的网站，如果您发现了错误，特别是社区或 Web API 的错误，则表明 Steam 遇到了问题。 您可以把 ASF 丢在一边让它稍后自行恢复，或者退出程序自己掌握等待的时间。

然而，情况并非总是如此，因为在某些情况下 Steam Status 无法检测到 Steam 的问题，例如，2016 年 6 月 7 日，Valve 破坏了 HTTPS 支持，导致通过 HTTPS 访问 **[Steam 社区](https://steamcommunity.com)**&#8203;会发生错误。 因此，也不要盲目地相信 Steam Status，您最好自己检查是否一切正常。

此外，Steam 还包括各种访问频率限制措施，如果您一次发送了大量请求，Steam 就会临时封禁您的 IP。 ASF 了解这种情况，已经在配置文件内为您提供了各种不同的限速属性。 默认设置已经过优化，能够管理**合理**数量的机器人，如果您的机器人数量过大导致 Steam 对您说不，您就需要调整这些属性避免发生这种事，或者忽略此事，继续面对错误。 我想没人会选择第二个选项，所以请阅读相关主题，并特别注意 `WebLimiterDelay` 属性，这是适用于所有 Web 请求的一个通用限制。

没有适合任何人的“金科玉律”，因为封禁受到多种第三方因素的影响，这也是为何您需要自己实验，找到适合您的值。 您也可以忽略这一点，使用类似 `10000` 等一定能正常工作的值，但请不要抱怨 ASF 无论做什么操作都要花 10 秒时间，仅仅解析徽章页面就要花费 5 分钟。 除此之外，以上限制可能没有发挥作用，因为如果您的机器人数量很多，还有可能触及上文所述的&#8203;**[硬性限制](#asf-可以运行多少个机器人)**。 没错，您完全有可能登录 Steam 网络（客户端）没有任何问题，但是 Steam Web（网站）会在您一次建立 100 个会话之后开始拒绝您的连接。 ASF 需要 Steam 网络和 Steam Web 共同运行，其中每一个出现问题都会导致您遇到问题。

如果以上解释都不能解决问题，并且您仍然不知道哪里发生了故障，可以随时启用 `Debug` 模式，自己检查 ASF 的日志了解请求失败的具体原因。 例如：

```text
InternalRequest() HEAD https://steamcommunity.com/my/edit/settings
InternalRequest() Forbidden <- HEAD https://steamcommunity.com/my/edit/settings
```

您看见 `Forbidden` 代码了吗？ 这意味着您因为请求数量过多而被暂时封禁，其原因是您没有正确调整 `WebLimiterDelay` 属性（假如您的所有其他请求也有同样的错误）。 这里还可能有其他的错误代码，例如 `InternalServerError`、`ServiceUnavailable`，还有表示 Steam 正在维护或出现问题的超时错误。 您可以随时尝试访问 ASF 提到的链接，检查它们能否正常打开——如果不能，您就明白 ASF 同样无法打开这些链接。 如果一切正常，并且该错误持续了一两天之久，您就需要调查并反馈此问题了。

在这样做之前，您首先要**确认该错误值得反馈**。 如果这个问题已经出现在本常见问题中，例如交易相关的问题，就不应该反馈。 如果这是一个仅发生一两次的临时问题，特别是您的网络不稳定或者 Steam 宕机的情况——也不值得反馈。 但如果您能够在 2 天内连续几次重现您的问题，重新启动 ASF 和计算机都无法解决问题，并且确定常见问题中没有相关内容，那么这就是值得一问的好问题。

---

### ASF 看起来卡住了，我如果不按下一个键，控制台就没有任何输出！

很可能您正在使用 Windows，并且您的控制台启用了快速编辑模式。 请参考 **[StackOverflow 上的问题](https://stackoverflow.com/questions/30418886/how-and-why-does-quickedit-mode-in-command-prompt-freeze-applications)**，获得技术方面的解释。 您应该右键单击 ASF 控制台窗口，打开属性，然后取消勾选快速编辑模式的复选框。

---

### ASF 无法接受或者发送交易报价！

首先是最明显的事实——新帐户受到交易限制。 ASF 无法使用新帐户接受或者发送交易，直到您在商店中充值或者花费 5 美元来解锁此帐户的限制。 在这种情况下，ASF 会认为库存是空的，因为其中每一张卡牌都不可交易。 接受交易也是不可能的，因为这需要 ASF 有能力获取 API 密钥，但受限用户的 API 功能是禁用的。 简而言之——所有受限用户都无法交易，没有例外。

接下来，如果您没有使用 **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication-zh-CN)** ，可能 ASF 实际上已经接受/发送了交易报价，但是您还需要通过电子邮件确认交易。 同样地，如果您使用经典 2FA，就需要在手机验证器中确认交易。 目前，交易确认是一项**强制**措施，所以如果您不想手动接受它们，就需要将您的验证器导入为 ASF 2FA。

还需注意，您只能与好友或者公开交易链接的人交易。 如果您尝试使用 `loot` 等命令发起*机器人发给 Master 用户*的交易，就需要保证机器人在您的好友列表中，或者在机器人的配置中设定您的 `SteamTradeToken`。 请保证此令牌是有效的，否则您将无法发送交易。

然后，请记住，新设备有 7 天的交易锁定，所以如果您刚刚将您的帐户添加到 ASF，就需要等待 7 天，之后一切都可以正常工作。 这项限制**同时**适用于接受**和**发送交易。 该限制并非一定会触发，有的人立刻就可以发送和接受交易。 但大多数人**会**受影响，遇到交易锁定，即使您可以通过同一台机器上的 Steam 客户端发送和接受交易。 耐心等待，您无法加速这个过程。 同样，如果您删除或更改各种 Steam 安全相关的设置，例如两步验证、Steam 令牌、密码、电子邮件地址等，很可能会遇到类似的交易锁定。 通常，您需要检查能否手动使用此帐户发送交易，如果可以，这很可能就是经典的 7 天新设备交易锁定。

最后，请记住，一个帐户最多只能向另一个帐户发送 5 个处理中的交易，所以如果您有来自某个机器人的 5 个（或更多）处理中的交易报价，ASF 就无法再发送新的交易。 这个问题很罕见，但仍然值得一提，特别是如果您在没有使用 ASF 2FA 的情况下设置自动发送交易报价，您可能会忘记确认之前的交易。

如果仍然无法解决问题，您可以随时启用 `Debug` 模式，自己检查请求失败的原因。 请注意，Steam 在大多数情况下都无法提供有意义的错误原因，甚至可能是完全错误的——如果您决定解释原因，一定要对 Steam 及其奇怪特性有相当的了解。 问题完全没有符合逻辑的解释也很常见，此时唯一推荐的方法就是重新将此帐户添加到 ASF（并且再次等待 7 天）。 有时这些问题也会*神奇地*自己消失，就像它们出现时一样。 但最常见的情况还是 7 天的交易锁定与暂时的 Steam 问题，或者两者兼而有之。 最好等待几天再开始手动检查错误，除非您真的希望立刻开始调试错误的真正原因（通常您还是要等待，因为错误消息可能没有意义，也没有任何帮助）。

无论如何，ASF 只能**尝试**向 Steam 发送一个接受/发送交易报价的正确请求。 无论 Steam 是否接受该请求，ASF 都无法控制，也无法神奇地让请求变正常。 这并非是该功能的漏洞，也没有进一步改进的可能，因为问题发生在 ASF 之外。 因此，不要请我们修复没有损坏的东西，也不要询问为什么 ASF 不能接受或发送交易——**我不知道，ASF 也不知道**。 您可以绕过它，或者如果您有更好的办法，请自己修复它。

---

### 为什我每次登录都需要输入两步验证/Steam 令牌？ / *Removed expired login key*（已删除过期的登录密钥！）

ASF 使用登录密钥使凭据长期有效（如果 `UseLoginKeys` 为启用状态），这与 Steam 本身使用的机制相同——您只需要输入一次两步验证/Steam 令牌代码。 然而，由于 Steam 网络本身的问题，有可能登录密钥没有被保存，不仅 ASF 有这样的问题， Steam 官方客户端也有（即使勾选了“记住我的密码”，每次登录仍要输入用户名和密码）。

您可以删除受影响机器人的 `BotName.db` 和 `BotName.bin` 文件（如果存在的话），然后尝试再次将 ASF 链接到您的帐户，但该方法通常不会有任何作用。 一些用户报告说在 Steam 网站上[**取消对其他所有设备的授权**](https://store.steampowered.com/twofactor/manage)或者修改密码会有帮助。 但这些仅仅是一些小窍门，不一定总是有效，ASF 的真正解决方案是将您的验证器导入为 **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication-zh-CN)**——当需要时，ASF 可以自动生成令牌代码，而不需要您手动输入。 通常，一段时间后，该问题就会自动消失，所以您也可以耐心等待。 当然，您也可以向 Valve 询问解决方案，因为我无法强制要求 Steam 网络认可我们的登录密钥。

作为一个旁注，您也可以将 `UseLoginKeys` 配置属性设置为 `false`，来禁用登录密钥功能，但这无法解决问题，仅仅能跳过登录密钥的报错。 ASF 已经了解此问题，如果它可以自己获取所有需要的登录凭据，就会尽量避免使用登录密钥，如果您可以提供所有登录细节，并且使用 ASF 2FA，就不需要手动调整 `UseLoginKeys` 属性。

---

### 我遇到错误：*无法登录到 Steam：`InvalidPassword` 或 `RateLimitExceeded`*

该错误可能指很多种情况，例如：

- 用户名/密码错误（很显然）
- ASF 的登录密钥已过期
- 短时间内多次登录失败（防暴力破解策略）
- 短时间内登录次数过多（频率限制）
- 需要输入验证码以登录（很可能由上面两个原因导致）
- Steam 网络阻止您登录的任何其他原因

如果符合防暴力破解或者频率限制的情况，问题会在一段时间后自行消失，所以您只需要等待，并且在此期间不要尝试登录。 如果您经常遇到该问题，也许增大 `LoginLimiterDelay` 配置属性的值是更明智的选择。 多次重新启动程序与发送更多有意或无意的登录请求显然对解决问题没有任何帮助，因此请尽量避免这样做。

如果符合登录密钥过期的情况——ASF 将删除旧密钥，并在下次登录时请求新的（如果您的帐户受 2FA 保护，就需要您提供 2FA 令牌。 如果您的帐户使用了 ASF 2FA，就可以自动生成并使用令牌）。 随着时间的流逝，发生这种情况很正常，但如果您每次登录都遇到该问题，则可能 Steam 出于某种原因决定忽略我们保存的登录密钥，如&#8203;**[此问题](#为什我每次登录都需要输入两步验证steam-令牌--removed-expired-login-key已删除过期的登录密钥)**&#8203;所述。 您当然可以完全禁用 `UseLoginKeys`，但这并没有解决问题，只会避免每次都提示移除过期的登录密钥。 按上文所述，真正的解决方案是使用 ASF 2FA。

最后，如果您使用了错误的用户名 + 密码组合，显然您需要纠正此问题，或者禁用受影响的机器人。 ASF 无法自行猜测 `InvalidPassword` 是否意味着凭据无效或任何上述原因，因此它只能继续尝试，直到成功。

请记住，ASF 有内置的系统，可以对 Steam 的奇怪问题作出相应的反应，最终可以恢复连接并正常工作，因此，如果问题是暂时的，就不需要您进行任何操作。 寄希望于重新启动 ASF 能够修复问题不仅无效，还会使情况更糟糕（因为新 ASF 进程不知道前一个 ASF 的状态是无法登录，就会立即开始尝试登录而不是先等待一段时间），所以请不要这样做，除非您明白自己在干什么。

最终，与每个 Steam 请求一样——ASF 只能使用您提供的凭据**尝试**登录。 请求是否成功已经超出了 ASF 的范围和逻辑——这并非 ASF 的漏洞，也没有任何问题可以修复。

---

### `System.IO.IOException: 发生了 I/O 错误。`

如果此错误发生在 ASF 等待输入的过程中（例如，您在堆栈跟踪信息中看到了 `Console.ReadLine()`），则它是由您的环境导致的，您的环境禁止 ASF 读取控制台标准输入。 这可能由多种原因造成，但最常见的原因是您在错误的环境中运行 ASF（例如，在 Linux 上使用 `nohup` 或 `&` 符号使其在后台运行，而没有使用 `screen`）。 如果 ASF 无法访问标准输入，您就会看到此错误日志，并且 ASF 无法在运行时向您询问信息。

如果您**期望**发生这种情况，即您**有意**使 ASF 在无输入环境下运行，那么您就应该正确设置 **[`Headless`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-zh-CN#headless)** 模式，明确地告诉 ASF 这一点。 这将会使 ASF 在任何情况下都不会要求用户进行输入，允许您在无输入环境中安全运行 ASF。

---

### `System.Net.Http.WinHttpException: 发生了安全错误`

当 ASF 无法与给定服务器建立安全连接时，就会发生此错误，这通常都是因为 SSL 证书不受信任造成的。

在绝大多数情况下，该错误的原因是您的**设备日期/时间错误**。 每个 SSL 证书都有颁发时间和过期时间。 如果您的日期无效，并且超出这个范围，则该证书就会因为潜在的 **[MITM](https://en.wikipedia.org/wiki/Man-in-the-middle_attack)**（中间人）攻击风险而不受信任，而 ASF 就会拒绝建立连接。

显而易见的解决方案是为您的机器设置正确的日期。 强烈建议您启用自动日期同步功能，例如 Windows 内置的日期同步，或者 Linux 上的 `ntpd`。

如果您确定机器上的日期是正确的，但错误仍在，那么您系统信任的 SSL 证书可能无效或已过期。 此时您应该确保您的机器可以建立安全连接，例如，您可以用任意浏览器或者 `curl` 等命令行工具访问 `https://github.com`。 如果您确认其他连接没有问题，可以在我们的 Steam 群组反馈。

---

### `System.Threading.Tasks.TaskCanceledException: A task was canceled`

此警告意味着 Steam 没有在给定时间内对 ASF 的请求作出响应。 通常这是由 Steam 网络波动引起的，不会影响 ASF。 如果是其他情况，则该问题与“请求在 5 次尝试后失败”错误相同。 大多数情况下，报告此问题是无意义的，因为我们无法强制 Steam 对我们的请求作出响应。

---

### `The type initializer for 'System.Security.Cryptography.CngKeyLite' threw an exception`

这个问题几乎只由 Windows 服务 `CNG Key Isolation` 被禁用/未运行导致，这个服务为 ASF 提供了核心的加密功能，如果此服务未运行，ASF 也无法运行。 要修复此问题，您可以运行 `services.msc`，确认 `CNG Key Isolation` 服务没有被禁用，并且正在运行。

---

### 我的反病毒软件认为 ASF 是恶意软件！ 发生了什么？

**确保您在可信来源下载 ASF**。 唯一官方的可信来源是 GitHub 上的 **[ASF 发布页面](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)**（这也是 ASF 的自动更新来源）——**任何其他来源都是不可信的，并且可能会被其他人添加恶意软件**——您不应该信任任何其他的下载来源，确保您的 ASF 来自于我们。

如果您确信您的 ASF 来自于可信来源，那么很可能这是一条误报。 在**过去**、**现在**和**未来**，一直都会发生这样的事。 如果您担心使用 ASF 的安全性，按么我建议您使用多个不同的反病毒软件扫描 ASF，以获得实际的检测率，例如，您可以通过 **[VirusTotal](https://www.virustotal.com)**（或任何类似的在线服务）来检测。

如果您使用的反病毒软件错将 ASF 识别为恶意软件，那么**您应该将此文件样本发送给您使用的反病毒软件的开发者，使他们进行分析并改进扫描引擎**，因为显然他们的引擎并不完美。 ASF 的代码没有问题，也没有什么需要我们修复，因为我们不是在分发恶意软件，向我们反馈这些误报是没有意义的。 我们强烈建议您如上文所述，发送 ASF 样本进行进一步分析，但如果您不想费力这样做，也可以随时将 ASF 加入反病毒软件的例外列表中，或者禁用反病毒软件，或者换用另一款。 遗憾的是，我们已经习惯了反病毒软件的愚蠢，因为每隔一段时间，就会有一些反病毒软件将 ASF 检测为病毒，虽然持续时间都很短，并被其开发者快速修复，但正如我上文指出的——在**过去**、**现在**和**未来**，一直都会发生这样的事。 ASF 不包含任何恶意代码，您可以审查 ASF 的代码，甚至自己从源代码编译。 我们不是黑客，不会混淆 ASF 代码将自己隐藏在反病毒软件的扫描和误报中，所以不要期望我们修复不存在的问题——我们没有什么“病毒”可以修复。