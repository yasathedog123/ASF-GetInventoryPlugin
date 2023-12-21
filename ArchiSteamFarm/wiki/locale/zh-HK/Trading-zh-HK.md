# 交易

ASF支援Steam非互動式（離線）交易。 您可以即刻收到（接受/拒絕）以及發送交易提案，並且不需要特殊配置，但顯然需要不受限制的 Steam 帳戶（已經在商店中花費了5$ 的帳戶）。 Only limited trading functionality is available for restricted accounts.

---

## 邏輯

ASF 將始終接受所有來自對機械人有`Master`（或更高）訪問權限的用户的交易項目。 This allows not only easily looting steam cards farmed by the bot instance, but also allows to easily manage Steam items that bot stashes in the inventory - including those from other games (such as CS:GO).

ASF將拒絕任何來自交易模組黑名單中的用戶（對master無效）的交易報價，無論其內容如何。 Blacklist is stored in standard `BotName.db` database, and can be managed via `tb`, `tbadd` and `tbrm` **[commands](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. 這應該可以替代Steam 提供的標準用戶屏蔽模塊，請謹慎使用。

除非在 `TradingPreferences` 中指定 `DontAcceptBotTrades`，否則 ASF 將接受跨機械人發送的所有 `loot`類型交易。 簡而言之，預設 `TradingPreferences`為 `None` 將導致 ASF 自動接受對機械人具有 `Master` 訪問許可權的用戶的交易（如上文所述），以及參與 ASF 流程的其他機械人的所有捐贈交易。 如果您想禁用來自其他機械人的捐贈交易，那麼應當在 `TradingPreferences` 中啟用 `DontAcceptBotTrades` 。

當您在 `TradingPreferences` 中啟用 `AcceptDonations` 時，ASF將接受任何捐贈交易，在這種交易中，機械人帳戶不會損失任何物品。 此屬性僅影響非機械人帳戶，因為機械人帳戶受 `DontAcceptBotTrades` 的影響。 `AcceptDonations` 可以讓你輕鬆接受來自其他用戶（包括不在同一ASF進程中的機械人）的捐贈。

值得一提的是，`AcceptDonations` 不需要 **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)**，因為如果我們不會損失任何物品，則不需要確認交易。

您還可以通過修改相應的 `TradingPreferences` 來進一步自訂 ASF 交易功能。 其中一個主要的 `TradingPreferences` 功能是 `SteamTradeMatcher` 選項，這將允許 ASF 使用內置邏輯來接受交易，以幫助您収集合成徽章所需的卡片，這在與**[SteamTradeMatcher](https://www.steamtradematcher.com)**公開清單的配合使用中特別有用，但也可以單獨使用。 下面將進一步介紹此功能。

---

## `SteamTradeMatcher`

當啟用`steamtrademcher`時，ASF將使用複雜算法來檢查交易是否遵循 STM規則，並且結果至少對我們保持中立。 當前邏輯如下：

- 如果我們失去任何`MatchableTypes`類型之外的物品，則拒絕交易。
- Reject the trade if we're not receiving at least the same number of items on per-game, per-type and per-rarity basis.
- 如果用戶要求交易特殊的Steam夏季/冬季特賣卡片，並有交易暫掛，則拒絕交易。
- 如果交易暫掛時間超過全域配置中`MaxTradeHoldDuration` 屬性的值，則拒絕交易。
- 如果我們沒有啟用`MatchEverything`，則拒絕一切對我們不利的交易。
- 如果交易未被以上所有規則拒絕，則接受交易。

值得一提的是，ASF 還支援超額支付——只要滿足上述所有條件，邏輯就會正常工作，接受用戶向交易添加的額外物品。

前4個拒絕相關的判斷條件是有目共見的。 最後一個包括實際上重覆的邏輯，用於檢查我們的庫存狀態，並決定交易狀態。

- 如果我們的收集度取得進展，交易**有利**。 Example: A A (before) -> A B (after)
- 如果我們的收集度維持現狀，交易**中立**。 Example: A B (before) -> A C (after)
- 如果我們的收集度出現倒退，交易**不利**。 Example: A C (before) -> A A (after)

STM 的運行規則僅會匹配對我們有利的交易，這意味著將 STM 用於匹配冗餘卡片的用戶總會發起對我們有利的交易。 然而，ASF 更加包容，它也接受中立的交易 ，因為在這些交易中，我們實際上並沒有任何損失，所以沒有必要拒絕它們。 這對朋友間的交易特別有用，因為他們可以在不使用 STM 的情況下交換您的冗餘卡片，而不會影響您的卡牌收集進度。

預設情況下，ASF 將拒絕不利交易——作為一個用戶，這恰恰正是您想要的。 但是，您也可以選擇在`TradingPreferences`中啟用 `MatchEverything`，以讓ASF接受所有的冗餘物品交易，包括**不利交易**。 只有當您想要在您的帳戶下運行 1:1 交易機械人時，這一特性才有用，因為您瞭解 **ASF 將不再帮您完成徽章進度，反而可能會使您因 N 張相同卡片而損失收集進度**。 If you want to intentionally run a trade bot that is **never** supposed to finish any set, and should offer its whole inventory to every interested user, then you can enable that option.

無論您選擇哪種 `TradingPreferences`，交易被 ASF 拒絕並不意味著您自己無法手動接受它。 如果您保留 `BotBehaviour` 的預設值（並未啟用 `RejectInvalidTrades`），ASF 將忽略這些交易，允許您自行決定。 同樣適用于一切 `MatchableTypes` 之外的物品交易，該模組僅幫助您自動化 STM 交易，而不會決定什麼是好的交易，什麼不是。 The only exception from this rule is when talking about users that you blacklisted from trading module using `tbadd` command - trades from those users are immediately rejected regardless of `BotBehaviour` settings.

強烈建議在啟用此選項時使用 **ASF 2FA</0 >, 因為如果您決定手動確認每個交易, 則此功能將失去其全部潛力。 `SteamTradeMatcher` will work properly even without ability to confirm trades, but it can generate backlog of confirmations if you're not accepting them in time.</p>