# 交易

ASF 支持 Steam 非交互式（离线）的交易。 收取（接受/拒绝）以及发送交易都可以立即使用，不需要特殊配置，但显然需要有不受限制的 Steam 帐户（已在商店中花费至少 5 美元）。 受限帐户只能使用有限的交易功能。

---

## 逻辑

ASF 将始终接受来自机器人 `Master`（或更高权限）帐户的交易，无论交易物品是什么。 这样可以很方便地拾取由机器人实例挂到的卡牌，也可以轻松管理机器人库存内存储的物品——包括其他游戏（例如 CS:GO）的物品。

ASF 将会驳回来自于交易模块黑名单中的用户的交易报价，无论交易物品是什么。 黑名单被存放在标准的 `BotName.db` 数据库，可以通过 `tb`、`tbadd` 和 `tbrm` **[命令](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-zh-CN)**&#8203;管理。 这应该可以代替 Steam 提供的标准用户屏蔽——谨慎使用。

ASF 将会接受机器人之间发送的 `loot`（拾取）交易，除非 `TradingPreferences` 中设置了 `DontAcceptBotTrades`。 简单来说，将 `TradingPreferences` 设置为 `None` 会使 ASF 自动接受来自机器人 `Master` 用户（上文所述）的交易，和来自同一 ASF 进程的其他机器人的赠送交易。 如果您想禁用来自其他机器人的赠送交易，就应该在 `TradingPreferences` 中设置 `DontAcceptBotTrades`。

当您在 `TradingPreferences` 中设置 `AcceptDonations` 时，ASF 也会接受一切赠送交易（机器人帐户不损失任何物品的交易）。 这一属性仅仅影响非机器人帐户，因为机器人帐户受 `DontAcceptBotTrades` 属性影响。 `AcceptDonations` 属性允许您轻松接受来自于其他人（以及其他 ASF 进程中的机器人）的赠送。

值得注意的是，`AcceptDonations` 不需要 **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication-zh-CN)**，因为在不损失物品的情况下不需要进行交易确认。

您还可以通过修改 `TradingPreferences` 属性进一步自定义 ASF 交易行为。 `TradingPreferences` 的一个主要功能是 `SteamTradeMatcher` 选项，使 ASF 使用内置逻辑接受能够帮助您收集合成徽章所需卡牌的交易，这一功能在结合 **[SteamTradeMatcher](https://www.steamtradematcher.com)** 公开列表时特别有用，但是也可以单独使用。 下面将进一步介绍此功能。

---

## `SteamTradeMatcher`

当 `SteamTradeMatcher` 启用时，ASF 将会使用一套复杂的算法检查交易是否符合 STM 规则，以及交易对我们来说是否至少公平。 具体的逻辑是：

- 如果我们损失 `MatchableTypes` 以外的物品，则驳回交易。
- 对于每款游戏、每种物品类型、每种稀有程度，如果我们收到的物品少于发出的物品，则驳回交易。
- 如果交易者想要特殊 Steam 夏季/冬季特卖卡牌，但是有交易暂挂，则驳回交易。
- 如果交易暂挂时间达到 `MaxTradeHoldDuration` 全局配置属性的值，则驳回交易。
- 如果我们没有设置 `MatchEverything`（接受所有匹配交易），而交易内容对我们不利，则驳回交易。
- 如果交易不符合上述任何情况，则接受交易。

值得注意的是，ASF 还支持 Overpay（超额付款，或溢价）——只要满足上述条件，交易者在提供更多物品时，此逻辑也会正常工作。

前 4 种驳回条件应该是显而易见的。 最后一种条件则包含重复检查逻辑：检查我们当前的库存状态来决定交易的状态。

- 如果交易倾向于增加您的卡牌套组收集进度，则视为**有利**。 示例：A A（交易前）-> A B（交易后）
- 如果交易不会影响您的卡牌套组收集进度，则视为**平衡**。 示例：A B（交易前）-> A C（交易后）
- 如果交易倾向于减少您的卡牌套组收集进度，则视为**不利**。 示例：A C（交易前）-> A A（交易后）

STM 仅会处理有利的交易，这意味着使用 STM 进行重复卡牌匹配的用户只能向我们推荐对我们有利的交易。 然而，ASF 更加宽松，它也接受平衡交易，因为在这种交易中我们实际上并没有任何损失，所以没有理由拒绝它们。 这对朋友之间的交易特别有用，因为他们可以在不使用 STM 的情况下与您交换多余的卡牌，只要这不会导致您损失卡牌收集进度。

默认情况下，ASF 会驳回不利的交易——对于普通用户来说，这正是我们想要的。 然而，您可以在 `TradingPreferences` 中启用 `MatchEverything`，使 ASF 接受所有重复物品交易，即使是**不利的**。 只有您想要在您的帐户下运行 1:1 交易机器人时，此功能才有用，因为您了解 **ASF 将不再帮助您完成徽章收集进度，并且您可能会因为 N 张相同的卡牌失去进度**。 如果您有意运行一个**永远**不打算收集完整徽章的交易机器人，并且愿意与任何有兴趣的买家进行任意物品的交易，则可以启用此选项。

无论您的 `TradingPreferences` 如何设置，ASF 驳回交易不意味着您不能自己接受它。 如果您保留了 `BotBehaviour` 的默认值，不含 `RejectInvalidTrades`，ASF 仅会忽略这些交易——使您可以自行决定是否接受交易。 同样的情况适用于 `MatchableTypes` 以外的物品——这个模块仅仅用于自动化 STM 交易，而不是代替您判断交易的优劣。 此规则的唯一例外是通过 `tbadd` 命令添加进交易黑名单的用户——无论您的 `BotBehaviour` 如何设置，来自这些用户的交易都会被立即驳回。

启用此选项时，强烈建议您使用 **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication-zh-CN)**，因为如果您还需要手动确认每次交易，这一功能也就失去了它的潜力。 即使没有确认交易的能力，`SteamTradeMatcher` 也可以正常工作，但是如果您没有及时手动确认，就会留下积压的确认请求。