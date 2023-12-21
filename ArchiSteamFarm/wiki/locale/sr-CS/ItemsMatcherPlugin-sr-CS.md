# ItemsMatcherPlugin

`ItemsMatcherPlugin` is official ASF **[plugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)** that extends ASF with ASF STM listing features. In particular, this includes `PublicListing` in **[`RemoteCommunication`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#remotecommunication)** and `MatchActively` in **[`TradingPreferences`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#tradingpreferences)**. ASF comes with `ItemsMatcherPlugin` bundled together with the release, therefore it's ready for usage right away.

---

## `PublicListing`

Public listing, as the name implies, is listing of currently available ASF STM bots. It's located on **[our website](https://asf.justarchi.net/STM)**, managed automatically and used as a public service for both ASF users that make use of `MatchActively`, as well as ASF and non-ASF users for manual matching.

In order to be listed, you have a set of requirements to meet. At the minimum you must have allowed `PublicListing` in `RemoteCommunication` (default setting), `SteamTradeMatcher` enabled in `TradingPreferences`, **[public inventory](https://steamcommunity.com/my/edit/settings)** privacy settings, **[unrestricted](https://help.steampowered.com/faqs/view/71D3-35C2-AD96-AA3A)** account and **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication#asf-2fa)** active. Additional requirements include 2FA active since at least 15 days, last password change more than 5 days ago, lack of any account limitations like lockdowns, economical bans and trade bans. Naturally, you must also have at least one item from your specified `MatchableTypes`, such as trading cards. In addition to that, bots with more than `500000` items are not accepted due to excessive overhead, we recommend to split your inventory across several accounts in this case.

While `PublicListing` is enabled by default, please note that you will **not** be displayed on the website if you do not meet all of the requirements, especially `SteamTradeMatcher`, which isn't enabled by default. For people that do not meet the criteria, even if they kept `PublicListing` enabled, ASF doesn't communicate with the server in any way. Public listing is also compatible only with latest stable version of ASF and may refuse to display outdated bots, especially if they're missing core functionality that can be found only in newer versions.

### Kako to tačno radi

ASF šalje podatke jednom kada se prijavi, a to sadrži sva podešavanja koja javna lista može da iskoristi. Onda, svakih 10 minuta ASF šalje jedan, veoma mali zahtjev koji obavještava server da je bot još aktivan i radi. Ako zbog nekog razloga taj zahtjev ne stige, npr. ako image probleme sa mrežom, onda će ASF ponavljati taj zahtjev svakog minuta, sve dok on ne stigne. This way our server knows precisely which bots are still running and ready to accept trade offers. ASF will also send initial announcement on as-needed basis, for example if it detects that our inventory has changed since the previous one.

We display all ASF 2FA+STM accounts that were active in the **last 15 minutes**. Users are sorted according to their relative usefulness - `MatchEverything` bots which are shown with `Any` banner that accept all 1:1 trades, then unique games count, and finally items count.

### API

ASF STM lista trenutno sam prihvata ASF botove. There is no way to list third-party bots on our listing for now, as we can't review their code easily and ensure they meet our entire trading logic. Participation in the listing therefore requires latest stable ASF version, although it can run with custom **[plugins](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)**.

For consumers of the listing, we have a very simple **[`/Api/Listing/Bots`](https://asf.justarchi.net/Api/Listing/Bots)** endpoint that you can use. It includes all the data we have, apart from inventories of users which are part of `MatchActively` feature exclusively.

### Privacy policy

If you agree to being listed in our listing, by enabling `SteamTradeMatcher` and not refusing `PublicListing`, as specified above, we'll temporarily store some of your Steam account details on our server in order to provide the expected functionality.

Public info (exposed by Steam to every interested party) includes:
- Vašeg Steam identifikatora (u 64-bitnoj formi, za generisanje linkova)
- Vašeg nadimka (za svrhe prikazivanja)
- Vašeg avatara (heš, za svrhe prikazivanja)

Conditionally public info (exposed by Steam to every interested party if you meet listing requirements) includes:
- Your **[inventory](https://steamcommunity.com/my/inventory/#753_6)** (so people can use `MatchActively` against your items).

Private info (selected data required for providing the functionality) includes:
- Vaš **[token za razmenu](https://steamcommunity.com/my/tradeoffers/privacy)** (da bi ljudi van vaše liste prijatelja mogli da vrše razmenu sa vama)
- Your `MatchableTypes` setting (for display purposes and matching)
- Your `MatchEverything` setting (for display purposes and matching)
- Your `MaxTradeHoldDuration` setting (so other people know whether you're willing to accept their trades)

Your data is stored for maximum of two weeks since you stop using (announcing on) our listing, and automatically deleted after that period.

---

## `MatchActively`

`MatchActively` setting is active version of **[`SteamTradeMatcher`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading#steamtradematcher)** including interactive matching in which the bot will send trades to other people. It can work standalone, or together with `SteamTradeMatcher` setting. This feature requires `LicenseID` to be set, as it uses third-party server and paid resources to operate.

In order to make use of that option, you have a set of requirements to meet. At the minimum you must have **[unrestricted](https://help.steampowered.com/faqs/view/71D3-35C2-AD96-AA3A)** account, **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication#asf-2fa)** active and at least one valid type in `MatchableTypes`, such as trading cards. Additional requirements include 2FA active since at least 15 days, last password change more than 5 days ago, lack of any account limitations like lockdowns, economical bans and trade bans.

If you meet all of the requirements above, ASF will periodically communicate with our **[public ASF STM listing](#publiclisting)** in order to actively match bots that are currently available.

During matching, ASF bot will fetch its own inventory, then communicate with our server with it to find all possible `MatchableTypes` matches from other, currently available bots. Thanks to communicating directly with our server, this process requires a single request and we have immediate information whether any available bot offers something interesting for us - if match is found, ASF will send and confirm trade offer automatically.

This module is supposed to be transparent. Matching will start in approximately `1` hour since ASF start, and will repeat itself each `6` hours (if needed). `MatchActively` feature is aimed to be used as a long-run, periodical measure to ensure that we're actively heading towards sets completion, however, people that are not running ASF 24/7 may also consider using a `match` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. The target users of this module are primary accounts and "stash" alt accounts, although it can be used by any bot that is not set to `MatchEverything`. In addition to that, bots with more than `500000` items are not accepted for matching due to excessive overhead, we recommend to split your inventory across several accounts in this case.

ASF does its best to minimize the amount of requests and pressure generated by using this option, while at the same time maximizing efficiency of matching to the upper limit. The exact algorithm of choosing the bots to match and otherwise organize the whole process, is ASF's implementation detail and can change in regards to feedback, situation and possible future ideas.

The current version of the algorithm makes ASF prioritize `Any` bots first, especially those with better diversity of games that their items are from. When running out of `Any` bots, ASF will move on to the `Fair` ones upon same diversity rule. ASF will try to match every available bot at least once, to ensure that we're not missing on a possible set progress.

`MatchActively` takes into account bots that you blacklisted from trading through `tbadd` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** and will not attempt to actively match them. This can be used for telling ASF which bots it should never match, even if they'd have potential dupes for us to use.

ASF will also do its best to ensure that the trade offers are going through. On the next run, which normally happens in 6 hours, ASF will cancel any pending trade offers that still weren't accepted, and deprioritize steamIDs taking part in them to hopefully prefer more active bots first. Still, if deprioritized bots are the last ones that have the match we need, we'll still attempt to match them (again).

---

### Why do I need a `LicenseID` to use `MatchActively`? Wasn't it free before?

ASF is, and remains, free and open-source, as it was established at the start of the project back in October 2015. Source code of `ItemsMatcher` plugin and therefore `MatchActively` feature is available in our repository, while ASF program is entirely non-commercial, we do not earn anything from contributions to it, building or publishing. Over those past 7+ years ASF has received tremendous amount of development, and it's still being improved and enhanced with every monthly stable release mostly by a single person, **[JustArchi](https://github.com/JustArchi)** - with no strings attached. The only funding we receive is from non-obligatory donations that come from our users.

For a very long time, until October 2022, `MatchActively` feature was part of ASF core and available for everyone to use. In October 2022, Valve, the company behind Steam, has put very severe rate limits on fetching inventories of other bots - which rendered previous functionality entirely broken, with no possibility of a solution to resolve this problem. Therefore, due to the fact that the feature has became entirely defunct with no chance of being fixed, it had to be removed from ASF core as obsolete.

`MatchActively` was resurrected as part of official `ItemsMatcher` plugin that further enhances ASF with active cards matching functionality. Resurrecting `MatchActively` feature required from us **extraordinary amount of work** to create ASF backend, entirely new service hosted on a server, with more than a hundred of paid proxies attached for resolving inventories, all exclusively to allow ASF clients to make use of `MatchActively` like before. Due to the amount of work involved, as well as resources that are not free and require to be paid on monthly basis by us (domain, server, proxies), we've decided to offer this functionality to our sponsors, that is, people that already support ASF project on monthly basis, thanks to whom we can make those paid resources available.

Our goal isn't to profit from it, but rather, cover the **monthly costs** that are exclusively linked with offering this option - that's why we offer it basically for nothing, but we do have to charge a little for it as we can't pay hundreds of dollars from our own pockets each month, just to make it available for you. We're not really in a position to discuss the price either, it's Valve that forced those costs upon us, and the alternative is to not have such feature available at all, which of course applies if you decide, for whatever reason, that you can't justify using our plugin on those terms.

In any case, we understand that `MatchActively` is not for everybody, and we hope that you also understand why we can't offer it for free.

---

### How can I get an access?

`ItemsMatcher` is offered as part of monthly $5+ sponsor tier on **[JustArchi's GitHub](https://github.com/sponsors/JustArchi)**. It's also possible to become one-time sponsor, although in this case the license will be valid only for a month (with possibility of extension in the same way). Once you become a sponsor of $5 tier (or higher), read **[configuration](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#licenseid)** section to obtain and fill `LicenseID`. Afterwards, you only need to enable `MatchActively` in `TradingPreferences` of your chosen bot.

The license allows you to send limited amount of requests to the server. $5 tier allows you to use `MatchActively` for one bot account (4 requests daily), and every additional $5 adds two more bot accounts (8 requests daily). For example, if you want to run it on three accounts, that'll be covered by $10 tier and higher.