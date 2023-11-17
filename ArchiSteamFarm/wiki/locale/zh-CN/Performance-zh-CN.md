# 性能

ASF 的主要目标是尽可能高效地挂卡，这基于两种可操作的数据——小部分由用户提供的 ASF 无法猜测的数据，和大部分可以由 ASF 自动获取的数据。

在自动挂卡模式下，ASF 不允许您选择要挂的游戏，也不允许您更改挂卡算法。 **ASF 比您更清楚它应该做什么以尽快获取卡牌**。 您的目标是正确设置配置属性，因为 ASF 无法猜测这些内容，而其他事情应该交给 ASF 来做。

---

此前，Valve 更改了卡牌掉落算法。 从那时起，我们可以将 Steam 帐户分为两类：卡牌掉落**受限**和**不受限**。 两类帐户之间的唯一区别是，卡牌掉落受限的帐户在玩给定游戏 `X` 小时之前，无法从中获得任何卡牌。 看起来从未退款的较早帐户**不会受限**，而曾经退款的新帐户**会受限**。 然而这只是一种理论，不应该将其当作规则。 这就是为何 ASF 需要**您**告诉它哪种情况符合您的帐户，因为 ASF **无法自动判断**。

---

目前 ASF 有两种挂卡算法：

**简单**（Simple）算法最适合不受限的帐户。 这是 ASF 主要采用的算法。 机器人检查需要挂卡的游戏，然后按顺序一个个地挂卡直到所有卡牌都掉落。 这是因为同时挂多个游戏时，卡牌掉落速率接近零，挂卡效率很低。

**复杂**（Complex）算法是新算法，帮助卡牌掉落受限帐户最大化收益。 ASF 将会首先为所有游戏时间已超过 `HoursUntilCardDrops` 的游戏应用标准的**简单**算法，然后，如果没有游戏时间达到 `HoursUntilCardDrops` 的游戏剩余，它将会同时挂所有游戏时间不足 `HoursUntilCardDrops` 的游戏（最多同时挂 `32` 个），直到其中的所有游戏的游戏时间达到 `HoursUntilCardDrops`，此时 ASF 将会重复上述的过程（对游戏使用**简单**算法，同时运行游戏时间不足 `HoursUntilCardDrops` 的游戏等等）。 在这种情况下，我们会同时挂多个游戏，使它们的游戏时间先达到掉卡时长。 请注意，在挂游戏时间时，ASF **不会**挂卡牌，因此它也不会检查这段时间内是否有卡牌掉落（原因如上所述）。

目前，ASF 完全根据 `HoursUntilCardDrops` 配置文件属性（由**您**设置）来选择挂卡算法。 如果 `HoursUntilCardDrops` 被设置为 `0`，就会采用**简单**算法，否则会采用**复杂**算法——也就是配置为先把所有游戏的游戏时长挂到指定的小时数，然后再挂机获得卡牌。

---

### **哪种算法更适合您并没有一个明确的答案**。

这也是为何您不需要选择挂卡算法，而是告诉 ASF 您的帐户是否卡牌掉落受限。 如果帐户掉卡不受限，**简单**算法的效果**更好**，因为我们不需要浪费时间将游戏时长挂到 `X` 小时——在同时挂多个游戏时，卡牌掉落率接近 0%。 另一方面，如果您的帐户有卡牌掉落限制，**复杂**算法更合适，因为在游戏时间未达到 `HoursUntilCardDrops` 的情况下，挂单个游戏是没有意义的——所以我们将首先挂**游戏时间**，**然后**再挂单个游戏。

不要按照其他人的说法盲目设置 `HoursUntilCardDrops`，您需要测试、比较结果并基于您获得的数据来决定这个选项的值。 鉴于您正在阅读此 Wiki 页面，您应该很关心 ASF 的效率，只要您为此付出一些努力，就可以确保您的帐户达到您需要的最高掉卡效率。 如果存在一种适合所有人的解决方案，ASF 就不需要您来选择，而是自动决定了。

---

### 检查您的帐户是否被限制的最好方法是什么？

确保您有**未记录游戏时长的**游戏来挂卡，最好至少有 5 款，然后以 `HoursUntilCardDrops` 为 `0` 值运行 ASF。 如果您在挂卡期间没有玩游戏，结果会更准确（最好在夜间进行此测试）。 让 ASF 自动挂这 5 款游戏，之后查询日志获取结果。

ASF 清楚地说明指定游戏的卡牌在何时掉落。 您需要关注 ASF 最早掉落的卡牌。 例如，如果您的帐户不受限，则第一张卡牌应该在挂卡开始后大约 30 分钟时掉落。 如果您注意到**至少一款**游戏在起始 30 分钟内掉卡，就表明您的帐户**不受限**，并且应该将 `HoursUntilCardDrops` 设置为 `0`。

但是，如果您注意到**每款**游戏都需要至少 `X` 小时才掉落第一张卡牌，就表明您应该将 `HoursUntilCardDrops` 设置为这个小时数。 大多数（不是全部）受限用户需要至少 `3` 小时游戏时间才会掉卡，并且这也是 `HoursUntilCardDrops` 的默认值。

请记住，游戏有不同的掉卡速率，这也是为何您应该以**至少** 3 款，最好是 5 款以上游戏来测试，确保其结果不是巧合。 只要有一款游戏在一小时内掉卡，就可以确定您的帐户**不受限**，并且可以将 `HoursUntilCardDrops` 设置为 `0`，但要确定您的帐户**受限**，至少需要有几款游戏在达到一个固定时间后才掉卡。

需要注意的是，在过去，`HoursUntilCardDrops` 只有 `0` 和 `2` 两种可能，所以 ASF 有一个 `CardDropsRestricted` 属性在这两个值之间切换。 但最近，我们注意到不仅大多数用户需要 `3` 小时而不是过去的 `2` 小时才掉卡，而且现在 `HoursUntilCardDrops` 是动态的，每个帐户可能有不同的值。

当然，这一切最终都由您来决定。

并且更糟糕的是——我遇到过一些人从受限变为不受限状态以及相反的情况——可能是因为 Steam 的漏洞（没错，Steam 有很多漏洞）或者因为 Valve 有一些相关的调整逻辑。 所以，即使您确认您的帐户是受限的（或者不受限），不要确信它总会如此——如果您进行了退款，帐户就很可能从不受限变为受限。 如果您认为以前的设置不再合适，您可以随时重新测试并更新这个值。

---

默认情况下，ASF 会假设 `HoursUntilCardDrops` 为 `3`，因为在它的值应该小于 `3` 的情况下，这样设置的副作用比相反情况要小。 这是因为在最坏的情况下，我们每挂 `32` 款游戏会浪费 `3` 小时，而如果将 `HoursUntilCardDrops` 默认设置为 `0`，则在最坏的情况下，每款游戏都会浪费 `3` 小时。 但是，您仍然应该调整这个变量来匹配您的帐户，以达到最大效率，因为这只是基于大多数用户情况的盲目猜测（我们尝试使默认情况下的副作用更小）。

目前，上述两种算法已经足以针对所有可能的帐户情况提高挂卡效率，因此不需要添加更多算法。

值得注意的是，ASF 也支持通过 `play` 命令启用手动挂卡模式。 您可以阅读&#8203;**[命令](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-zh-CN#备注)**&#8203;章节了解详情。

---

## Steam 漏洞

挂卡算法并不总是以它应该的方式工作，并且完全可能发生各种 Steam 故障，例如受限帐户掉卡、关闭/切换游戏时掉卡、玩游戏时完全不掉卡等等。

本节主要解释了为何 ASF 不支持**某些方法**，例如快速切换游戏加速掉卡。

什么是 **Steam 漏洞**——触发**未定义**行为的特定操作，这种操作**不可靠、无说明并且是一种逻辑缺陷**。 根据定义，它是**不可靠的**，这意味着它无法在干净的测试环境下可靠重现，因此，也无法写出可靠的代码来猜测漏洞会在何时出现，以及如何应对/滥用它。 通常漏洞是临时的，开发者会修复相应的逻辑缺陷，但有时一些杂项漏洞会长时间不被注意到。

一个很好的 **Steam 漏洞**的例子是一种不太罕见的情况，即在关闭游戏时掉卡，Idle Master 的跳过游戏功能可以在一定程度上滥用这一漏洞。

- **未定义行为**——您无法确定在触发这一漏洞时是否掉落卡牌。
- **不可靠**——基于过去的经验和 Steam 网络的行为，在发送单个请求时不会产生相同的结果。
- **未说明**——Steam 网站上明确说明了如何获得卡牌，**所有文档**都清楚地表明您需要通过**玩游戏**，而不是关闭游戏、获得成就、切换游戏或同时运行 32 款游戏来获得卡牌。
- **属于逻辑缺陷**——关闭或者切换游戏应该与卡牌掉落无关，因为这个操作不会**增加游戏时间**。
- **无法可靠重现**——这一方法并非对所有人都有效，即使您成功触发一次，也不能保证下一次仍然成功。

现在我们明白了什么是 Steam 漏洞，并且在关闭游戏时掉落卡牌**就是**其中之一，现在我们可以谈谈第二点——**根据定义，ASF 没有以任何方式滥用 Steam 网络，并且以最大努力遵守 Steam 订户协议、Steam 网络协议及其普遍接受的内容**。 持续向 Steam 网络发送大量启动/停止游戏的请求会被视为一种 **[DoS 攻击](https://en.wikipedia.org/wiki/Denial-of-service_attack)**&#8203;并且**直接违反 [Steam 在线行为准则](https://store.steampowered.com/online_conduct/)**。

> 作为一名 Steam 用户，您同意遵守以下行为准则。
> 
> 您将不会：
> 
> 对 Steam 服务器展开攻击或以其他方式破坏 Steam。

无论您是否能够用其他程序（例如 IM）触发 Steam 漏洞，无论您是否同意我们的观点，将这种行为视为 DoS 攻击——这是由 Valve 来决断的，但只要我们将其视为通过滥发 Steam 网络请求对不可靠行为进行滥用，那么您就可以确信 Valve 的看法会与我们相似。

ASF **永远不会**利用针对 Steam 的攻击、滥用、入侵或其他任何我们认为**违反** Steam 订户协议、Steam 在线行为准则的行为，以及任何其他可信来源表明的 Steam 网络未预期的行为，如&#8203;**[贡献指南](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/.github/CONTRIBUTING.md)**&#8203;所述。

如果您仍然愿意为了几分钱的卡牌冒险加快挂卡速度，ASF 永远不会支持自动执行这样的操作。但您仍然可以手动执行 `play` **[命令](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-zh-CN)**&#8203;进行您想要对 Steam 网络做的任何事情。 我们不建议利用 Steam 漏洞为自己获利——无论是通过 ASF 还是其他工具。 然而，这是您自己的帐户，您可以选择如何使用它——只是要注意，我们警告过您。