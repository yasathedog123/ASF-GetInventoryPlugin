# ItemsMatcherPlugin

`ItemsMatcherPlugin` é um **[plugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins-pt-BR)** oficial que estende o ASF com recursos de listagem do ASF STM. Em particular, isso inclui `PublicListing` em **[`RemoteCommunication`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-pt-BR#remotecommunication)** e `MatchActively` em **[`TradingPreferences`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-pt-BR#tradingpreferences)**. O ASF vem com o `ItemsMatcherPlugin` incluído junto com o lançamento, portanto está pronto para uso imediato.

---

## `PublicListing`

A listagem pública, como o nome indica, é a listagem dos bots ASF STM atualmente disponíveis. It's located on **[our website](https://asf.justarchi.net/STM)**, managed automatically and used as a public service for both ASF users that make use of `MatchActively`, as well as ASF and non-ASF users for manual matching.

In order to be listed, you have a set of requirements to meet. At the minimum, you must have allowed `PublicListing` in `RemoteCommunication` (default setting), `SteamTradeMatcher` enabled in `TradingPreferences`, **[public inventory](https://steamcommunity.com/my/edit/settings)** privacy settings, an **[unrestricted](https://help.steampowered.com/faqs/view/71D3-35C2-AD96-AA3A)** account and **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication#asf-2fa)** active. Additional requirements include 2FA active since at least 15 days, last password change more than 5 days ago, lack of any account limitations like lockdowns, economical bans and trade bans. Naturally, you must also have at least one item from your specified `MatchableTypes`, such as trading cards. In addition to that, bots with more than `500000` items are not accepted due to excessive overhead, we recommend to split your inventory across several accounts in this case.

While `PublicListing` is enabled by default, please note that you will **not** be displayed on the website if you do not meet all of the requirements, especially `SteamTradeMatcher`, which isn't enabled by default. For people that do not meet the criteria, even if they kept `PublicListing` enabled, ASF doesn't communicate with the server in any way. Public listing is also compatible only with latest stable version of ASF and may refuse to display outdated bots, especially if they're missing core functionality that can be found only in newer versions.

### Como exatamente isso funciona

O ASF envia os dados iniciais uma vez após o login, que contém todas as propriedades que a listagem pública utiliza. Em seguida, a cada 10 minutos o ASF envia uma solicitação muito pequena de "pulso" que notifica o nosso servidor de que o bot ainda está sendo executado. Se por algum motivo o pulso não chegar, por exemplo devido a problemas de rede, então o ASF vai tentar reenviá-lo a cada minuto, até o servidor registrá-lo. This way our server knows precisely which bots are still running and ready to accept trade offers. ASF will also send initial announcement on as-needed basis, for example if it detects that our inventory has changed since the previous one.

We display all ASF 2FA+STM accounts that were active in the **last 15 minutes**. Users are sorted according to their relative usefulness - `MatchEverything` bots which are shown with `Any` banner that accept all 1:1 trades, then unique games count, and finally items count.

### API

A listagem API do STM só aceita bots ASF no momento. There is no way to list third-party bots on our listing for now, as we can't review their code easily and ensure they meet our entire trading logic. Participation in the listing therefore requires latest stable ASF version, although it can run with custom **[plugins](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)**.

For consumers of the listing, we have a very simple **[`/Api/Listing/Bots`](https://asf.justarchi.net/Api/Listing/Bots)** endpoint that you can use. It includes all the data we have, apart from inventories of users which are part of `MatchActively` feature exclusively.

### Privacy policy

If you agree to being listed in our listing, by enabling `SteamTradeMatcher` and not refusing `PublicListing`, as specified above, we'll temporarily store some of your Steam account details on our server in order to provide the expected functionality.

Public info (exposed by Steam to every interested party) includes:
- Seu identificador Steam (na forma de 64-bit, para gerar ligações)
- Seu apelido (para fins de exibição)
- Seu avatar (hash, para fins de exibição)

Conditionally public info (exposed by Steam to every interested party if you meet listing requirements) includes:
- Your **[inventory](https://steamcommunity.com/my/inventory/#753_6)** (so people can use `MatchActively` against your items).

Private info (selected data required for providing the functionality) includes:
- Seu **[token de trocas](https://steamcommunity.com/my/tradeoffers/privacy)** (para que pessoas fora da sua lista de amigos possam te enviar propostas de trocas)
- Your `MatchableTypes` setting (for display purposes and matching)
- Your `MatchEverything` setting (for display purposes and matching)
- Your `MaxTradeHoldDuration` setting (so other people know whether you're willing to accept their trades)

Your data is stored for a maximum of two weeks since you stop using (announcing on) our listing, and automatically deleted after that period.

---

## `MatchActively`

`MatchActively` setting is active version of **[`SteamTradeMatcher`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading#steamtradematcher)** including interactive matching in which the bot will send trades to other people. Isso pode funcionar em espera sozinho, ou junto com a configuração `SteamTradeMatcher`. This feature requires `LicenseID` to be set, as it uses third-party server and paid resources to operate.

Para usar essa opção há uma série de requisitos para serem atendidas. At the minimum, you must have an **[unrestricted](https://help.steampowered.com/faqs/view/71D3-35C2-AD96-AA3A)** account, **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication#asf-2fa)** active and at least one valid type in `MatchableTypes`, such as trading cards. Additional requirements include 2FA active since at least 15 days, last password change more than 5 days ago, lack of any account limitations like lockdowns, economical bans and trade bans.

If you meet all of the requirements above, ASF will periodically communicate with our **[public ASF STM listing](#publiclisting)** in order to actively match bots that are currently available.

During matching, ASF bot will fetch its own inventory, then communicate with our server with it to find all possible `MatchableTypes` matches from other, currently available bots. Thanks to communicating directly with our server, this process requires a single request and we have immediate information whether any available bot offers something interesting for us - if match is found, ASF will send and confirm trade offer automatically.

Esse módulo deve ser transparente. As correspondências devem começar em aproximadamente `1` hora desde a ativação do ASF, e repetirá automaticamente a cada `6` horas (caso necessário). `MatchActively` feature is aimed to be used as a long-run, periodical measure to ensure that we're actively heading towards sets completion, however, people that are not running ASF 24/7 may also consider using a `match` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Os usuários alvos desse módulo são principalmente contas principais e contas alternativas "ocultas", embora ele possa ser usado em qualquer bot que não foi configurado para `MatchEverything`. In addition to that, bots with more than `500000` items are not accepted for matching due to excessive overhead, we recommend to split your inventory across several accounts in this case.

O ASF faz o seu melhor para minimizar a quantidade de solicitações e a pressão gerada por usar esta opção, enquanto maximiza a eficiência das correspondências até o limite possível. O algoritmo exato de escolha dos bots para combinar e organizar todo o processo é um detalhe de implementação do ASF e pode mudar de acordo com os feedbacks, situações e possíveis ideias futuras.

A versão atual do algoritmo faz com que o ASF priorize os bots `Any`, especialmente aqueles que têm uma maior diversidade de jogos dos quais seus itens provêm. When running out of `Any` bots, ASF will move on to the `Fair` ones upon same diversity rule. ASF will try to match every available bot at least once, to ensure that we're not missing on a possible set progress.

O `MatchActively` leva em conta os bots que você pôs na lista negra de trocas através do **[comando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-pt-BR)** `tbadd` e não vai tentar trocas com eles. Pode ser usado para dizer ao ASF quais bots nunca devem ser combinados, mesmo se eles tiverem potenciais duplicatas que poderíamos usar.

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

The license allows you to send limited amount of requests to the server. O nível $5 permite usar o `MatchActively` para uma conta bot (4 solicitações diárias), e cada $5 adicional adiciona mais duas contas bot (8 solicitações diariamente). For example, if you want to run it on three accounts, that'll be covered by $10 tier and higher.