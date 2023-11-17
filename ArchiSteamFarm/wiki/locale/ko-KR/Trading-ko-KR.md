# 거래

ASF는 Steam 비-대화형(오프라인) 거래를 지원합니다. 거래를 받는것(수락/거절)과 보내는 것이 즉시 가능하고, 특별한 설정이 필요하지 않지만 분명히 제한되지 않은 Steam 계정이 필요합니다.(상점에서 $5를 이미 사용한 계정) 거래 모듈은 제한된 계정에서는 사용할 수 없습니다.

---

## 논리구조

ASF는 `주인(Master)` 혹은 그 이상의 봇 접근권한을 가진 사용자가 보낸 모든 거래를 항목에 상관없이 수락합니다. This allows not only easily looting steam cards farmed by the bot instance, but also allows to easily manage Steam items that bot stashes in the inventory - including those from other games (such as CS:GO).

ASF는 거래 모듈의 블랙리스트에 오른 주인이 아닌 모든 사용자로부터의 거래 제안을 내용과 상관없이 거절합니다. Blacklist is stored in standard `BotName.db` database, and can be managed via `tb`, `tbadd` and `tbrm` **[commands](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. 이는 Steam이 제공하는 표준 사용자 차단의 대안으로써 작동하므로 사용에 주의하시기 바랍니다.

ASF는 `TradingPreferences`에 `봇거래수락안함(DontAcceptBotTrades)`이 명시되어있지 않는 한 봇 간의 모든 `loot` 같은 거래를 수락합니다. 즉, `TradingPreferences`의 기본값인 `없음(None)`은 위에서 설명한대로 봇의 `주인(Master)` 권한을 가진 사용자로부터의 거래를 자동으로 수락하도록 합니다. 또한 ASF 프로세스로 일어나는 다른 봇의 기부 거래도 자동으로 수락합니다. 다른 봇으로부터의 기부 거래를 비활성화 하려면 `TradingPreferences`의 `봇거래수락안함(DontAcceptBotTrades)`을 사용하십시오.

`TradingPreferences`에 `기부수락(AcceptDonations)`을 활성화하면 봇 계정이 어떤 항목도 잃지 않는 기부 거래를 수락할 것입니다. 이 속성값은 봇이 아닌 계정에만 영향을 주고, 봇 계정은 `봇거래수락안함(DontAcceptBotTrades)`의 영향을 받습니다. `기부수락(AcceptDonations)`은 다른 사람이나 ASF 프로세스에 참여하지 않은 봇으로부터의 기부를 쉽게 수락하게 해줍니다.

어떤 항목도 잃지 않는 경우 확인사항이 없으므로 `기부수락(AcceptDonations)`은 **[ASF 2단계 인증](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication-ko-KR)** 을 필요로 하지 않음을 알아두십시오.

`TradingPreferences`를 적절하게 수정하여 ASF의 거래 기능을 더 자세하게 지정할 수 있습니다. `TradingPreferences`의 주요 기능 중 하나는 `SteamTradeMatcher` 옵션으로, **[SteamTradeMatcher](https://www.steamtradematcher.com)** 의 공개 리스트와 협업할때 특히 유용한데, 배지를 완성할 수 있도록 거래를 받아들이는 ASF의 내장 논리구조를 사용하도록 합니다. 물론 SteamTradeMatcher 없이도 가능합니다. 아래에서 더 자세하게 설명하겠습니다.

---

## `SteamTradeMatcher`

`SteamTradeMatcher`가 활성화 되면, ASF는 거래가 STM의 규칙을 통과하고 우리에게 적어도 중립인지를 확인하는 꽤 복잡한 알고리즘을 사용합니다. 실제 논리구조는 다음과 같습니다.

- `MatchableTypes`에 특정된 항목타입이 아닌 것을 잃게 되면 거래를 거절합니다.
- Reject the trade if we're not receiving at least the same number of items on per-game, per-type and per-rarity basis.
- 사용자가 특별한 Steam 여름/겨울 세일 카드를 요청하고, 거래 지연의 영향을 받는다면 거래를 거절합니다.
- 거래 지연 기간이 일반 환경설정의 `MaxTradeHoldDuration` 속성값을 초과하는 경우 거래를 거절합니다.
- `MatchEverything` 설정이 아니라면 거래를 거절합니다. 이는 우리에게 중립보다 더 나쁩니다.
- 위의 내용으로 거절되지 않았다면 거래를 수락합니다.

ASF가 과지급을 지원함을 알아두십시오. 이 논리구조는 위의 모든 조건을 만족하면서 사용자가 뭔가를 추가로 거래에 추가할때 정확하게 동작합니다.

처음 4개의 거절 조건은 모두에게 명백해야 합니다. 마지막 거절 조건은 우리 보관함의 현재 상태를 확인하고 거래 상태를 결정하는 실제 중복 논리구조를 포함합니다.

- 세트 완성 진행도가 증가했다면 이 거래는 **좋음(good)** 입니다. Example: A A (before) -> A B (after)
- 세트 완성 진행도가 현상태 그대로라면 이 거래는 **중립(neutral)** 입니다. Example: A B (before) -> A C (after)
- 세트 완성 진행도가 감소했다면 이 거래는 **나쁨(bad)** 입니다. Example: A C (before) -> A A (after)

STM은 좋음 거래만 수행합니다. 즉, 중복 매칭을 위해 STM을 사용하는 사용자는 우리에게는 항상 좋음 거래만 제안할 것입니다. 하지만 ASF는 자유민주주의라서 중립 거래도 수락합니다. 중립 거래는 실제로 우리가 잃는것이 없기 때문에, 거절할 이유가 없습니다. 이는 당신의 친구들에게 특히 유용합니다. 그들은 STM을 전혀 사용하지 않고도 당신의 과도한 카드를 교환할 수 있습니다. 당신의 세트 완성 진행도도 떨어지지 않습니다.

기본적으로 ASF는 나쁨 거래를 거절합니다. 이는 사용자라면 거의 항상 원하는 것입니다. 하지만, ASF가 **나쁨 거래**를 포함한 모든 중복 거래를 받아들일 수 있도록 `TradingPreferences`의 `MatchEverything`를 활성화할 수도 있습니다. 이는 당신의 계정에서 1:1 거래 봇을 실행하고 싶은 경우 유용합니다. 물론 **ASF는 더이상 당신의 배지완성 진행도를 도와주지 않을것이고, 완성된 세트를 중복 카드 N장으로 바꿔버리기 쉽게 함을** 알고 계십시오. If you want to intentionally run a trade bot that is **never** supposed to finish any set, and should offer its whole inventory to every interested user, then you can enable that option.

Regardless of your chosen `TradingPreferences`, a trade being rejected by ASF doesn't mean that you can't accept it yourself. If you kept default value of `BotBehaviour`, which doesn't include `RejectInvalidTrades`, ASF will just ignore those trades - allowing you to decide yourself if you're interested in them or not. Same goes for trades with items outside of `MatchableTypes`, as well as everything else - the module is supposed to help you automate STM trades, not decide what is a good trade and what is not. The only exception from this rule is when talking about users that you blacklisted from trading module using `tbadd` command - trades from those users are immediately rejected regardless of `BotBehaviour` settings.

It's highly recommended to use **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)** when you enable this option, as this function loses its whole potential if you decide to manually confirm every trade. `SteamTradeMatcher` will work properly even without ability to confirm trades, but it can generate backlog of confirmations if you're not accepting them in time.