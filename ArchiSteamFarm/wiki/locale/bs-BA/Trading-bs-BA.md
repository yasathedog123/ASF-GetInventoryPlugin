# Razmjena

ASF includes support for Steam non-interactive (offline) trades. Both receiving (accepting/declining) as well as sending trades is available right away and doesn't require special configuration, but obviously requires unrestricted Steam account (the one that spent 5$ in the store already). Trading module is unavailable for restricted accounts.

---

## Logika

ASF will always accept all trades, regardless of items, sent from user with `Master` (or higher) access to the bot. This allows not only easily looting steam cards farmed by the bot instance, but also allows to easily manage Steam items that bot stashes in the inventory - including those from other games (such as CS:GO).

ASF will reject trade offer, regardless of content, from any (non-master) user that is blacklisted from trading module. Blacklist is stored in standard `BotName.db` database, and can be managed via `tb`, `tbadd` and `tbrm` **[commands](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. This should work as an alternative to standard user block offered by Steam - use with caution.

ASF will accept all `loot`-like trades being sent across bots, unless `DontAcceptBotTrades` is specified in `TradingPreferences`. In short, default `TradingPreferences` of `None` will cause ASF to automatically accept trades from user with `Master` access to the bot (explained above), as well as all donation trades from other bots that are taking part in ASF process. If you want to disable donation trades from other bots, then that's what `DontAcceptBotTrades` in your `TradingPreferences` is for.

When you enable `AcceptDonations` in your `TradingPreferences`, ASF will also accept any donation trade - a trade in which bot account is not losing any items. This property affects only non-bot accounts, as bot accounts are affected by `DontAcceptBotTrades`. `AcceptDonations` allows you to easily accept donations from other people, and also bots that are not taking part in ASF process.

It's nice to note that `AcceptDonations` doesn't require **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)**, as there is no confirmation needed if we're not losing any items.

You can also further customize ASF trading capabilities by modifying `TradingPreferences` accordingly. One of the main `TradingPreferences` features is `SteamTradeMatcher` option which will cause ASF to use built-in logic for accepting trades that help you complete missing badges, which is especially useful in cooperation with public listing of **[SteamTradeMatcher](https://www.steamtradematcher.com)**, but can also work without it. It's further described below.

---

## `SteamTradeMatcher`

When `SteamTradeMatcher` is active, ASF will use quite complex algorithm of checking if trade passes STM rules and is at least neutral towards us. The actual logic is following:

- Reject the trade if we're losing anything but item types specified in our `MatchableTypes`.
- Reject the trade if we're not receiving at least the same number of items on per-game, per-type and per-rarity basis.
- Reject the trade if user asks for special Steam summer/winter sale cards, and has a trade hold.
- Reject the trade if trade hold duration exceeds `MaxTradeHoldDuration` global config property.
- Reject the trade if we don't have `MatchEverything` set, and it's worse than neutral for us.
- Accept the trade if we didn't reject it through any of the points above.

It's nice to note that ASF also supports overpaying - the logic will work properly when user is adding something extra to the trade, as long as all above conditions are met.

First 4 reject predicates should be obvious for everyone. The final one includes actual dupes logic which checks current state of our inventory and decides what is the status of the trade.

- Trade is **good** if our progress towards set completion advances. Example: A A (before) -> A B (after)
- Trade is **neutral** if our progress towards set completion stays in-tact. Example: A B (before) -> A C (after)
- Trade is **bad** if our progress towards set completion declines. Example: A C (before) -> A A (after)

STM operates only on good trades, which means that user using STM for dupes matching should always suggest only good trades for us. However, ASF is liberal, and it also accepts neutral trades, because in those trades we're not actually losing anything, so there is no real reason to decline them. This is especially useful for your friends, since they can swap your excessive cards without using STM at all, as long as you're not losing any set progress.

By default ASF will reject bad trades - this is almost always what you want as an user. However, you can optionally enable `MatchEverything` in your `TradingPreferences` in order to make ASF accept all dupe trades, including **bad ones**. This is useful only if you want to run a 1:1 trade bot under your account, as you understand that **ASF will no longer help you progress towards badge completion, and make you prone to losing entire finished set for N dupes of the same card**. If you want to intentionally run a trade bot that is **never** supposed to finish any set, and should offer its whole inventory to every interested user, then you can enable that option.

Regardless of your chosen `TradingPreferences`, a trade being rejected by ASF doesn't mean that you can't accept it yourself. If you kept default value of `BotBehaviour`, which doesn't include `RejectInvalidTrades`, ASF will just ignore those trades - allowing you to decide yourself if you're interested in them or not. Same goes for trades with items outside of `MatchableTypes`, as well as everything else - the module is supposed to help you automate STM trades, not decide what is a good trade and what is not. The only exception from this rule is when talking about users that you blacklisted from trading module using `tbadd` command - trades from those users are immediately rejected regardless of `BotBehaviour` settings.

It's highly recommended to use **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)** when you enable this option, as this function loses its whole potential if you decide to manually confirm every trade. `SteamTradeMatcher` will work properly even without ability to confirm trades, but it can generate backlog of confirmations if you're not accepting them in time.