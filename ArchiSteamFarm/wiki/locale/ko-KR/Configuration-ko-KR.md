# 환경설정

이 페이지는 ASF 환경설정에 대한 내용입니다. 이는 `config` 디렉토리에 대한 완전한 설명이며, ASF를 당신의 입맛에 맞게 조정하게 해줍니다.

* **[소개](#introduction)**
* **[웹 기반 환경설정 생성기(ConfigGenerator)](#web-based-configgenerator)**
* **[ASF-ui configuration](#asf-ui-configuration)**
* **[수동 환경설정](#manual-configuration)**
* **[일반 환경설정](#global-config)**
* **[봇 환경설정](#bot-config)**
* **[파일 구조](#file-structure)**
* **[JSON 매핑](#json-mapping)**
* **[호환성 매핑](#compatibility-mapping)**
* **[환경설정 호환성](#configs-compatibility)**
* **[자동 재시작](#auto-reload)**

---

## 소개

ASF 환경설정은 두개의 주요 부분으로 나누어집니다. 일반(프로세스) 환경설정과 모든 봇의 환경설정입니다. 모든 봇은 각각 `봇이름.json`이라는 이름의 봇 환경설정 파일을 가집니다. `봇이름`은 봇의 이름입니다. ASF 일반(프로세스) 설정은 `ASF.json`이라는 단일 파일입니다.

봇은 ASF 프로세스에 참여하는 단일 스팀 계정입니다. 정상적으로 작동하기 위해서 ASF는 최소한 **하나** 이상의 정의된 봇 인스턴스가 필요합니다. 프로세스가 강제하는 봇 인스턴스의 개수제한은 없습니다. 원하는 만큼 봇(스팀 계정)을 사용할 수 있습니다.

ASF는 환경설정 파일을 저장하기 위하여 **[JSON](https://ko.wikipedia.org/wiki/JSON)** 형식을 사용합니다. 사람에게 친숙하고, 읽을 수 있으며 프로그램을 설정할 수 있는 가장 보편적인 형식입니다. 걱정하지 마십시오. ASF를 설정하기 위해 JSON을 알 필요는 없습니다. 어떤 종류의 bash 스크립트로 ASF 환경설정을 대량생성하길 원하는 경우가 있어서 언급했을 뿐입니다.

Configuration can be done in several ways. You can use our **[Web-based ConfigGenerator](https://justarchinet.github.io/ASF-WebConfigGenerator)**, which is a local app independent of ASF. You can use our **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)** IPC frontend for configuration done directly in ASF. Lastly, you can always generate config files manually, as they follow fixed JSON structure specified below. We'll explain shortly the available options.

---

## 웹 기반 환경설정 생성기(ConfigGenerator)

The purpose of our **[Web-based ConfigGenerator](https://justarchinet.github.io/ASF-WebConfigGenerator)** is to provide you with a friendly frontend that is used for generating ASF configuration files. 웹 기반 환경설정 생성기는 100% 클라이언트 기반입니다. 즉 입력한 세부내용은 다른 어디로도 보내지지 않고 로컬에서만 처리된다는 뜻입니다. 이렇게 해서 보안성과 신뢰성을 보장할 수 있습니다. 모든 파일을 다운로드 받고 `index.html` 파일을 당신의 웹 브라우저에서 실행하면 **[오프라인](https://github.com/JustArchiNET/ASF-WebConfigGenerator/tree/main/docs)** 으로 작동할 수도 있습니다.

웹 기반 환경설정 생성기는 크롬과 파이어폭스에서 정상작동됨을 검증하였습니다. 또한 자바스크립트가 가능한 대부분의 유명한 웹 브라우저에서도 정상적으로 작동할 것입니다.

사용법은 매우 간단합니다. 적절한 탭을 선택해서 생성을 원하는 `ASF` 또는 `봇` 환경설정을 선택합니다. ASF 버전과 환경설정 파일의 버전이 맞는지 다시한번 확인 후, 모든 세부내용을 입력하고 "다운로드" 버튼을 누릅니다. 이 파일을 ASF의 `config` 디렉토리로 옮깁니다. 필요하다면 기존의 파일에 덮어쓰기 합니다. 매 최종수정마다 이를 반복합니다. 환경설정에서 가능한 옵션에 대한 설명은 이 섹션의 나머지 부분을 참고하십시오.

---

## ASF-ui configuration

Our **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)** IPC interface allows you to configure ASF as well, and is superior solution for reconfiguring ASF after generating the initial configs due to the fact that it can edit the configs in-place, as opposed to Web-based ConfigGenerator which generates them statically.

In order to use ASF-ui, you must have our **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)** interface enabled itself. `IPC` is enabled by default starting with ASF V5.1.0.0, therefore you can access it right away, as long as you didn't disable it yourself.

After launching the program, simply navigate to ASF's **[IPC address](http://localhost:1242)**. If everything worked properly, you can change ASF configuration from there as well.

---

## 수동 환경설정

In general we strongly recommend using either our ConfigGenerator or ASF-ui, as it's much easier and ensures you won't make a mistake in the JSON structure, but if for some reason you don't want to, then you can also create proper configs manually. Check JSON examples below for a good start in proper structure, you can copy the content into a file and use it as a base for your config. Since you're not using any of our frontends, ensure that your config is **[valid](https://jsonlint.com)**, as ASF will refuse to load it if it can't be parsed. Even if it's a valid JSON, you also have to ensure that all the properties have the proper type, as required by ASF. For proper JSON structure of all available fields, refer to **[JSON mapping](#json-mapping)** section and our documentation below.

---

## 일반 환경설정

일반 환경설정은 `ASF.json` 파일에 들어있으며 다음과 같은 구조를 가집니다.

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

모든 옵션은 다음과 같습니다.

### `AutoRestart`

`bool` 타입으로 기본값은 `true`입니다. 이 속성값은 필요할때 ASF가 자동으로 재시작할지를 정의합니다. `UpdatePeriod` 혹은 `update` 명령으로 수행되는 ASF업데이트나, `ASF.json` 환경설정 변경, `restart` 명령 등 ASF가 재시작을 필요로 하는 몇가지 이벤트가 있습니다. 일반적으로, 재시작은 두 부분으로 이루어져 있습니다. 새로운 프로세스의 생성과 현재 프로세스의 종료입니다. Most users should be fine with it and keep this property with default value of `true`, however - if you're running ASF through your own script and/or with `dotnet`, you may want to have full control over starting the process, and avoid a situation such as having new (restarted) ASF process running somewhere silently in the background, and not in the foreground of the script, that exited together with old ASF process. 새 프로세스가 더이상 직계 차일드 프로세스가 아니라는 사실이 특히 중요합니다. 표준 콘솔 입력을 사용하지 못할수도 있습니다.

이 경우 이 속성값을 `false`로 설정할 수 있습니다. 하지만 이 경우 프로세스를 재시작하는 것은 **당신** 이라는 것을 명심하십시오. 업데이트 후 등 새 프로세스를 낳는 대신 종료만 하는 것은 꽤 중요합니다. 당신이 추가한 논리구조가 없다면 당신이 다시 시작하기 전까지 작동을 멈출것입니다. ASF는 항상 성공(0) 또는 성공아님(0이외의 값) 등의 적절한 오류 코드를 가지고 종료합니다. 이렇게 해서 실패하는 경우 ASF를 자동으로 재시작하는 것을 방지하는 적절한 논리구조를 추가할 수 있고, 적어도 향후의 분석을 위한 `log.txt`을 작성합니다. `restart` 명령은 이 속성값이 어떻게 설정되어있는지와 상관없이 항상 ASF를 재시작함을 명심하십시오. 이 속성값은 기본 행동을 정의하지만 `restart` 명령은 항상 프로세스를 재시작합니다. 이 속성값을 비활성화할 이유가 있지 않다면 활성화 상태로 유지해야 합니다.

---

### `Blacklist`

`ImmutableHashSet<uint>` 타입으로 기본값은 비어있습니다. As the name suggests, this global config property defines appIDs (games) that will be entirely ignored by automatic ASF farming process. 불행히도 Steam은 여름/겨울 할인 배지를 "카드 획득 가능"으로 분류하는 걸 좋아합니다. 이는 ASF 프로세스를 혼란시켜서 여름/겨울 할인 배지도 농사지어야 할 유효한 게임으로 믿게합니다. 어떠한 블랙리스트도 없다면 ASF는 실제로는 게임이 아닌 게임을 농사짓느라고 결국 매달려있을 것이고, 일어나지 않을 카드 획득을 무한히 기다릴 것입니다. ASF의 블랙리스트는 이러한 배지를 농사용이 아님으로 표시하여 어떤 것을 농사지을지 결정할때 이들을 조용히 무시하고 함정에 빠지지 않게 하려는 목적입니다.

ASF includes two blacklists by default - `SalesBlacklist`, which is hardcoded into the ASF code and not possible to edit, and normal `Blacklist`, which is defined here. `SalesBlacklist` is updated together with ASF version and typically includes all "bad" appIDs at the time of release, so if you're using up-to-date ASF then you do not need to maintain your own `Blacklist` defined here. 이 속성값의 주 목적은 ASF 릴리스 시점에 알려지지 않은 새로운 농사짓지 말아야 할 appID를 당신이 관리할 수 있게하는 것입니다. Hardcoded `SalesBlacklist` is being updated as fast as possible, therefore you're not required to update your own `Blacklist` if you're using latest ASF version, but without `Blacklist` you'd be forced to update ASF in order to "keep running" when Valve releases new sale badge - I don't want to force you to use latest ASF code, therefore this property is here to allow you "fixing" ASF yourself if you for some reason don't want to, or can't, update to new hardcoded `SalesBlacklist` in new ASF release, yet you want to keep your old ASF running. 이 속성값을 변경해야 할 **명확한** 이유가 있지 않다면 기본값을 그대로 유지해야 합니다.

If you're looking for bot-based blacklist instead, take a look at `fb`, `fbadd` and `fbrm` **[commands](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**.

---

### `CommandPrefix`

`string` 타입으로 기본값은 `!`입니다. 이 속성값은 ASF **[명령어](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-ko-KR)** 에 사용되는 **대소문자 구문이 필요한** 접두사를 정의합니다. 즉, ASF가 당신의 말을 듣게하려면 모든 ASF 명령어의 앞에 이것을 붙여야 합니다. ASF의 명령어 접두사를 없애려고 이 값을 `null` 혹은 빈 값으로 설정하는 것도 가능합니다. 이 경우 명령어를 일반 식별자와 함께 입력해야 합니다. 하지만 ASF는 `CommandPrefix` 없이 시작하는 메시지를 파싱하는데 최적화되어있지 않아서 그렇게 하는 것은 ASF의 성능을 잠재적으로 줄이게 됩니다. 만약 의도적으로 접두사를 사용하지 않으려면 ASF는 ASF 명령어가 아니더라도 모든 메시지를 읽어서 응답해야 합니다. 따라서 기본값인 `!`가 싫다면 `/` 같은 어떤 `명령어 접두사(CommandPrefix)`를 계속 사용하는 것을 권장합니다. 일관성을 위하여 `CommandPrefix`는 ASF 프로세스 전체에 영향을 줍니다. 이 속성값을 변경해야 할 이유가 있지 않다면 기본값을 그대로 유지해야 합니다.

---

### `ConfirmationsLimiterDelay`

`byte` 타입으로 기본값은 `10`입니다. ASF는 등록제한이 걸리는 것을 피하기 위해 요청을 가져오는 두개의 연속된 2단계 인증 확인 사이에 적어도 `ConfirmationsLimiterDelay`초의 간격을 둡니다. 이는 **[ASF 2단계 인증](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication-ko-KR)** 에서 `2faok` 명령어 등이나 다양한 거래관련 동작을 수행할 때 요청 기반으로 사용됩니다. 기본값은 테스트에 따라 설정되었으며 문제를 발생하려는 것이 아니면 이보다 낮춰서는 안됩니다. 이 속성값을 변경해야 할 **명확한** 이유가 있지 않다면 기본값을 그대로 유지해야 합니다.

---

### `ConnectionTimeout`

`byte` 타입으로 기본값은 `90`입니다. 이 속성값은 ASF가 수행하는 다양한 네트워크 활동의 타임아웃을 초단위로 정의합니다. 특히, `ConnectionTimeout`은 HTTP와 IPC 요청의 타임아웃을 정의하고, `ConnectionTimeout / 10`은 실패한 heartbeat 최대 숫자를, `ConnectionTimeout / 30`은 최초 Steam 네트워크 연결요청에 허용되는 분단위 숫자를 정의합니다. Default value of `90` should be fine for majority of people, however, if you have rather slow network connection or PC, you may want to increase this number to something higher (like `120`). 더 큰 값이 느리거나 혹은 접속이 불가능한 Steam 서버를 마술처럼 고치는 것은 아님을 명심하십시오. 일어나지 않을 일을 무한히 기다리지 않고 그냥 다음에 다시 시도할 것입니다. 이 값을 너무 높게 설정하면 네트워크 이슈를 탐지하는데 극도의 지연과 전체적인 성능 저하가 발생합니다. 이 값을 너무 낮게 설정하면 ASF가 파싱중인 유효한 요청도 취소하게되어 전체적인 안정성과 성능을 저하시킬 것입니다. Therefore setting this value lower than default has no advantage in general, as Steam servers tend to be super slow from time to time, and could require more time for parsing ASF requests. 기본값은 네트워크 연결이 안정적이라는 믿음과 Steam 네트워크가 우리의 요청을 주어진 타임아웃 내에 처리하지 못할 것이라는 의심 사이의 균형점입니다. 이슈를 더 빨리 탐지하고 ASF가 더 빨리 재연결/반응하길 원한다면 기본값이면 됩니다.(혹은 아주 살짝 낮은값, `60` 정도면 ASF가 참을성이 약간 없어집니다.) If you instead notice that ASF is running into network issues, such as failing requests, heartbeats being lost or connection to Steam interrupted, it probably makes sense to increase this value if you're sure that it's **not** caused by your network, but by Steam itself, as increasing timeouts makes ASF more "patient" and not deciding to reconnect right away.

An example situation that may require increase of this property is letting ASF to deal with a very huge trade offers that can take good 2+ minutes to be fully accepted and handled by Steam. 기본 타임아웃을 증가시키면 ASF는 더 참을성이 있게되고 거래가 성사되지 않아서 최초 요청을 중단하는 결정을 하기 전에 더 오래 기다릴 것입니다.

또 다른 상황은 전송된 데이터를 처리하는데 더 많은 시간이 필요한 매우 느린 기기나 인터넷 연결로 인해 발생할 수 있습니다. 이는 매우 드문 경우로 CPU/네트워크 대역폭은 거의 보틀넥을 겪지 않지만 언급해둘 가능성은 여전히 있습니다.

In short, default value should be decent for most cases, but you may want to increase it if needed. 하지만 타임아웃을 크게 잡는다고 해서 접속이 불가능한 Steam 서버를 마술처럼 고칠수는 없으므로 기본값보다 한참 크게하는 것은 의미가 없습니다. 이 속성값을 변경해야 할 이유가 있지 않다면 기본값을 그대로 유지해야 합니다.

---

### `CurrentCulture`

`string` 타입으로 기본값은 `null`입니다. ASF는 기본적으로 운영체제의 언어를 사용하려하고, 가능하다면 그 언어로 번역된 문자열을 사용합니다. 이는 ASF를 거의 모든 대중적 언어로 **[현지화](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Localization-ko-KR)** 하려고 노력중인 커뮤니티 덕분에 가능합니다. 어떤 이유로든 OS를 모국어로 사용하고 싶지 않다면, 이 환경설정 속성값으로 대신 사용하길 원하는 유효한 언어를 고를 수 있습니다. 모든 가능한 국가 및 언어 리스트는 **[MSDN](https://msdn.microsoft.com/ko-kr/library/cc233982.aspx)** 을 방문하여 `Language tag`를 찾아보시기 바랍니다. It's nice to note that ASF accepts both specific cultures, such as `"en-GB"`, but also neutral ones, such as `"en"`. Specifying current culture will also affect other culture-specific behaviour, such as currency/date format and alike. Please note that you may need additional font/language packs for displaying language-specific characters properly, if you picked non-native culture that makes use of them. 일반적으로 ASF를 모국어가 아니라 영어로 사용하려는 경우 이 속성값을 활용합니다.

---

### `Debug`

`bool` 타입으로 기본값은 `false`입니다. 이 속성값은 프로세스를 디버그 모드에서 실행해야 하는 지를 정의합니다. 디버그 모드에서 ASF는 `config` 디렉토리 옆에 특별한 `debug` 디렉토리를 생성하여 ASF와 Steam 서버간의 모든 통신을 기록합니다. 디버그 정보는 네트워킹과 일반적인 ASF 작업흐름과 관련된 불쾌한 문제를 찾아내는데 도움이 됩니다. 또한, 일부 프로그램 루틴은 훨씬 더 자세해집니다. 예를 들어 `WebBrowser`는 일부 요청이 왜 실패하는지 정확한 이유를 표시하는데, 이 항목이 일반 ASF 로그에 기록됩니다. **개발자가 요청하지 않는 한 ASF를 디버그 모드로 실행하지 마십시오**. ASF를 디버그 모드로 실행하면 **성능 감소** 및 **안정성에 부정적 영향**을 주고, **여러 곳에서 훨씬 더 자세해지므로** 특정 이슈를 디버그하기 위해서 문제를 재생산하거나 요청 실패에 대한 더 많은 정보를 얻으려는 등 **오직** 의도했을때만 짧게 사용해야 합니다. 일반적 실행을 위해서는 사용하지 **마십시오**. **많은** 새로운 오류, 이슈, 예외를 보게 될 것입니다. ASF, Steam과 이상행동을 모두 직접 분석하려면 이에 대한 충분한 지식이 있는지 확인하십시오.

**WARNING:** enabling this mode includes logging of **potentially sensitive** information such as logins and passwords that you're using for logging in to Steam (due to network logging). That data is written to both `debug` directory, as well as standard `log.txt` (that is now intentionally much more verbose to log this info). You should not post debug content generated by ASF in any public location, ASF developer should always remind you of sending it to his e-mail, or other secure location. We're not storing, neither making use of those sensitive details, they're written as part of debug routines since their presence could be relevant to the issue that is affecting you. We'd prefer if you didn't alter ASF logging in any way, but if you're worried, you're free to redact those sensitive details appropriately.

> Redacting involves replacing sensitive details, for example with stars. You should refrain from removing sensitive lines entirely, as their pure existence could be relevant and should be preserved.

---

### `DefaultBot`

`string` 타입으로 기본값은 `null`입니다. In some scenarios ASF functions with a concept of a default bot responsible for handling something - for example IPC commands or interactive console when you don't specify target bot. This property allows you to choose default bot responsible for handling such scenarios, by putting its `BotName` here. If given bot doesn't exist, or you use a default value of `null`, ASF will pick first registered bot sorted alphabetically instead. Typically you want to make use of this config property if you want to omit `[Bots]` argument in IPC and interactive console commands, and always pick the same bot as the default one for such calls.

---

### `FarmingDelay`

`byte` 타입으로 기본값은 `15`입니다. In order for ASF to work, it will check currently farmed game every `FarmingDelay` minutes, if it perhaps dropped all cards already. Setting this property too low can result in excessive amount of steam requests being sent, while setting it too high can result in ASF still "farming" given title for up to `FarmingDelay` minutes after it's fully farmed. Default value should be excellent for most users, but if you have many bots running, you may consider increasing it to something like `30` minutes in order to limit steam requests being sent. It's nice to note that ASF uses event-based mechanism and checks game badge page on each Steam item dropped, so in general **we don't even need to check it in fixed time intervals**, but as we don't fully trust Steam network - we check game badge page anyway, if we didn't check it through card being dropped event in last `FarmingDelay` minutes (in case Steam network didn't inform us about item dropped or stuff like that). Assuming that Steam network is working properly, decreasing this value **will not improve farming efficiency in any way**, while **increasing network overhead significantly** - it's recommended only to increase it (if needed) from default of `15` minutes. 이 속성값을 변경해야 할 **명확한** 이유가 있지 않다면 기본값을 그대로 유지해야 합니다.

---

### `FilterBadBots`

`bool` 타입으로 기본값은 `true`입니다. This property defines whether ASF will automatically decline trade offers that are received from known and marked bad actors. In order to do that, ASF will communicate with our server on as-needed basis to fetch a list of blacklisted Steam identificators. The bots listed are operated by people that are classified as harmful towards ASF initiative by us, such as those that violate our **[code of conduct](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/.github/CODE_OF_CONDUCT.md)**, use provided functionality and resources by us such as **[`PublicListing`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#publiclisting)** in order to abuse and exploit other people, or are doing outright criminal activity such as launching DDoS attacks on the server. Since ASF has strong stance on overall fairness, honesty and cooperation between its users in order to make the whole community thrive, this property is enabled by default, and therefore ASF filters bots that we've classified as harmful from services offered. Unless you have a **strong** reason to edit this property, such as disagreeing with our statement and intentionally allowing those bots to operate (including exploiting your accounts), you should keep it at default.

---

### `GiftsLimiterDelay`

`byte` 타입으로 기본값은 `1`입니다. ASF는 등록제한이 걸리는 것을 피하기 위해 두개의 연속된 선물/키/라이센스 처리(등록) 요청 사이에 적어도 `GiftsLimiterDelay`초의 간격을 둡니다. In addition to that it'll also be used as global limiter for game list requests, such as the one issued by `owns` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Unless you have a **strong** reason to edit this property, you should keep it at default.

---

### `Headless`

`bool` 타입으로 기본값은 `false`입니다. 이 속성값은 프로세스를 headless 모드에서 실행해야 하는 지를 정의합니다. When in headless mode, ASF assumes that it's running on a server or in other non-interactive environment, therefore it will not attempt to read any information through console input. This includes on-demand details (account credentials such as 2FA code, SteamGuard code, password or any other variable required for ASF to operate) as well as all other console inputs (such as interactive command console). In other words, `Headless` mode is equal to making ASF console read-only. This setting is useful mainly for users running ASF on their servers, as instead of asking e.g. for 2FA code, ASF will silently abort the operation by stopping an account. Unless you're running ASF on a server, and you previously confirmed that ASF is able to operate in non-headless mode, you should keep this property disabled. Any user interaction will be denied when in headless mode, and your accounts will not run if they require **any** console input during starting. This is useful for servers, as ASF can abort trying to log onto the account when asked for credentials, instead of waiting (infinitely) for user to provide those. Enabling this mode will also allow you to use `input` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** which acts as a replacement for standard console input. 이 속성값을 어떻게 설정해야 할지 모르겠다면, 기본값인 `false`로 두십시오.

If you're running ASF on the server, you probably want to use this option together with `--process-required` **[command-line argument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments)**.

---

### `IdleFarmingPeriod`

`byte` 타입으로 기본값은 `8`입니다. ASF가 농사지을 것이 없다면 주기적으로 `IdleFarmingPeriod` 시간마다 계정에 새로운 농사지을 게임이 있는지 확인합니다. 이 기능은 우리가 갖게될 새 게임에 대해 이야기 할때는 필요없습니다. ASF는 배지 페이지를 자동으로 확인할 만큼 똑똑합니다. `IdleFarmingPeriod`는 주로 이미 갖고 있는 오래된 게임에 트레이딩 카드가 추가되는 경우를 위한 것입니다. 이경우 아무런 알림도 없어서 이것을 알기 위해서는 ASF가 주기적으로 배지 페이지를 확인해야 합니다. `0`값은 이 기능을 비활성화 합니다. `ShutdownOnFarmingFinished`도 함께 확인하십시오.

---

### `InventoryLimiterDelay`

`byte` type with default value of `4`. ASF will ensure that there will be at least `InventoryLimiterDelay` seconds in between of two consecutive inventory requests to avoid triggering rate-limit - those are being used for fetching Steam inventories, especially during your own commands such as `loot` or `transfer`. Default value of `4` was set based on fetching inventories of over 100 consecutive bot instances, and should satisfy most (if not all) of the users. You may however want to decrease it, or even change to `0` if you have very low amount of bots, so ASF will ignore the delay and loot steam inventories much faster. Be warned though, as setting it too low **will** result in Steam temporarily banning your IP, and that will prevent you from fetching your inventory at all. You also may need to increase this value if you're running a lot of bots with a lot of inventory requests, although in this case you should probably try to limit number of those requests instead. 이 속성값을 변경해야 할 **명확한** 이유가 있지 않다면 기본값을 그대로 유지해야 합니다.

---

### `IPC`

`bool` 타입으로 기본값은 `true`입니다. 이 속성값은 ASF 프로세스와 함께 시작되는 **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-ko-KR)** 서버를 정의합니다. IPC allows for inter-process communication, including usage of **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)**, by booting a local HTTP server. If you do not intend to use any third-party IPC integration with ASF, including our ASF-ui, you can safely disable this option. Otherwise, it's a good idea to keep it enabled (default option).

---

### `IPCPassword`

`string` 타입으로 기본값은 `null`입니다. 이 속성값은 IPC를 통해 이루어지는 모든 API 호출에 대한 필수 암호를 정의하고, 추가 보안수단으로 제공합니다. 빈 값이 아닌것으로 설정되면 모든 IPC 요청은 여기에 명시된 암호로 설정된 추가적인 `password` 속성값을 요구할 것입니다. 기본값인 `null`은 암호요구를 건너뛰어서 ASF가 모든 쿼리를 수행하도록 합니다. 그리고, 이 옵션을 활성화하면 내장된 IPC 대-무작위공격 메커니즘을 활성화합니다. 이는 매우 짦은 시간동안 너무 많은 승인되지 않은 요청이 있는 경우 특정 `IP 주소`를 일시적으로 차단합니다. 이 속성값을 변경해야 할 이유가 있지 않다면 기본값을 그대로 유지해야 합니다.

---

### `IPCPasswordFormat`

`byte` 타입으로 기본값은 `0`입니다. This property defines the format of `IPCPassword` property and uses `EHashingMethod` as underlying type. Please refer to **[Security](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security)** section if you want to learn more, as you'll need to ensure that `IPCPassword` property indeed includes password in matching `IPCPasswordFormat`. In other words, when you change `IPCPasswordFormat` then your `IPCPassword` should be **already** in that format, not just aiming to be. 무슨 일을 하고 있는지 알지 못한다면 기본값인 `0`을 유지하십시오.

---

### `LicenseID`

`Guid?` type with default value of `null`. This property allows our **[sponsors](https://github.com/sponsors/JustArchi)** to enhance ASF with optional features that require paid resources to work. For now, this allows you to make use of **[`MatchActively`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#matchactively)** feature in `ItemsMatcher` plugin.

While we recommend you to utilize GitHub since it offers monthly and one-time tiers, as well as allows full automation and gives you immediate access, we **also** support all other currently-available **[donation options](https://github.com/JustArchiNET/ArchiSteamFarm#archisteamfarm)**. See **[this post](https://github.com/JustArchiNET/ArchiSteamFarm/discussions/2780#discussioncomment-4486091)** for instructions on how to donate using other methods in order to get a manual license valid for given period.

Regardless of the method used, if you're ASF sponsor, you can obtain your license **[here](https://asf.justarchi.net/User/Status)**. You'll need to sign in with GitHub for confirming your identity, we ask only for read-only public information, which is your username. `LicenseID` is made out of 32 hexadecimal characters, such as `f6a0529813f74d119982eb4fe43a9a24`.

**Ensure that you do not share your `LicenseID` with other people**. Since it's issued on personal basis, it might get revoked if it's leaked. If by any chance this happened to you accidentally, you can generate a new one from the same place.

Unless you want to enable extra ASF functionalities, there is no need for you to provide the license.

---

### `LoginLimiterDelay`

`byte` 타입으로 기본값은 `10`입니다. ASF는 등록제한이 걸리는 것을 피하기 위해 두개의 연속된 연결 시도 사이에 적어도 `LoginLimiterDelay`초의 간격을 둡니다. Default value of `10` was set based on connecting over 100 bot instances, and should satisfy most (if not all) of the users. You may however want to increase/decrease it, or even change to `0` if you have very low amount of bots, so ASF will ignore the delay and connect to Steam much faster. Be warned though, as setting it too low while having too many bots **will** result in Steam temporarily banning your IP, and that will prevent you from logging in **at all**, with `InvalidPassword/RateLimitExceeded` error - and that also includes your normal Steam client, not only ASF. Likewise, if you're running excessive number of bots, especially together with other Steam clients/tools using the same IP address, most likely you'll need to increase this value in order to spread logins across longer period of time.

As a side note, this value is also used as load-balancing buffer in all ASF-scheduled actions, such as trades in `SendTradePeriod`. 이 속성값을 변경해야 할 **명확한** 이유가 있지 않다면 기본값을 그대로 유지해야 합니다.

---

### `MaxFarmingTime`

`byte` 타입으로 기본값은 `10`입니다. As you should know, Steam is not always working properly, sometimes weird situations can happen such as our playtime not being recorded, despite of, in fact, playing a game. ASF는 한 게임을 솔로모드로 최대 `MaxFarmingTime` 시간동안 농사지을 것입니다. 그리고 그 후에는 완전히 농사를 지은것으로 간주합니다. This is required to not freeze farming process in case of weird situations happening, but also if for some reason Steam released a new badge that would stop ASF from progressing further (see: `Blacklist`). Default value of `10` hours should be enough for dropping all steam cards from one game. Setting this property too low can result in valid games being skipped (and yes, there are valid games taking even up to 9 hours to farm), while setting it too high can result in farming process being frozen. Please note that this property affects only a single game in a single farming session (so after going through entire queue ASF will return to that title), also it's not based on total playtime but internal ASF farming time, so ASF will also return to that title after a restart. 이 속성값을 변경해야 할 **명확한** 이유가 있지 않다면 기본값을 그대로 유지해야 합니다.

---

### `MaxTradeHoldDuration`

`byte` 타입으로 기본값은 `15`입니다. This property defines maximum duration of trade hold in days that we're willing to accept - ASF will reject trades that are being held for more than `MaxTradeHoldDuration` days, as defined in **[trading](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading)** section. This option makes sense only for bots with `TradingPreferences` of `SteamTradeMatcher`, as it doesn't affect `Master`/`SteamOwnerID` trades, neither donations. Trade holds are annoying for everyone, and nobody really wants to deal with them. ASF is supposed to work on liberal rules and help everyone, regardless if on trade hold or not - that's why this option is set to `15` by default. However, if you'd instead prefer to reject all trades affected by trade holds, you can specify `0` here. Please consider the fact that cards with short lifespan are not affected by this option and automatically rejected for people with trade holds, as described in **[trading](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading)** section, so there is no need to globally reject everybody only because of that. 이 속성값을 변경해야 할 이유가 있지 않다면 기본값을 그대로 유지해야 합니다.


---

### `MinFarmingDelayAfterBlock`

`byte` 타입으로 기본값은 `60`입니다. This property defines minimum amount of time, in seconds, which ASF will wait before resuming cards farming if it got previously disconnected with `LoggedInElsewhere`, which happens when you decide to forcefully disconnect currently-farming ASF by launching a game. This delay exists mainly for convenience and overhead reasons, for example it allows you to restart the game without having to fight with ASF occupying your account again only because playing lock was available for a split second. Due to the fact that reclaiming the session causes `LoggedInElsewhere` disconnect, ASF has to go through whole reconnect procedure, which puts additional pressure on the machine and Steam network, therefore avoiding additional disconnects, if possible, is preferable. By default, this is configured at `60` seconds, which should be enough to allow you restart the game without much hassle. However, there are scenarios when you could be interested in increasing it, for example if your network disconnects often and ASF is taking over too soon, which causes being forced to go through the reconnect process yourself. We allow a maximum value of `255` for this property, which should be enough for all common scenarios. In addition to the above, it's also possible to decrease the delay, or even remove it entirely with a value of `0`, although that is usually not recommended due to reasons stated above. 이 속성값을 변경해야 할 이유가 있지 않다면 기본값을 그대로 유지해야 합니다.

---

### `OptimizationMode`

`byte` 타입으로 기본값은 `0`입니다. This property defines optimization mode which ASF will prefer during runtime. Currently ASF supports two modes - `0` which is called `MaxPerformance`, and `1` which is called `MinMemoryUsage`. By default ASF prefers to run as many things in parallel (concurrently) as possible, which enhances performance by load-balancing work across all CPU cores, multiple CPU threads, multiple sockets and multiple threadpool tasks. For example, ASF will ask for your first badge page when checking for games to farm, and then once request arrived, ASF will read from it how many badge pages you actually have, then request each other one concurrently. This is what you should want **almost always**, as the overhead in most cases is minimal and benefits from asynchronous ASF code can be seen even on the oldest hardware with a single CPU core and heavily limited power. However, with many tasks being processed in parallel, ASF runtime is responsible for their maintenance, e.g. keeping sockets open, threads alive and tasks being processed, which can result in increased memory usage from time to time, and if you're extremely constrained by available memory, you may want to switch this property to `1` (`MinMemoryUsage`) in order to force ASF into using as little tasks as possible, and typically running possible-to-parallel asynchronous code in a synchronous manner. You should consider switching this property only if you previously read **[low-memory setup](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup)** and you intentionally want to sacrifice gigantic performance boost, for a very small memory overhead decrease. Usually this option is **much worse** than what you can achieve with other possible ways, such as by limiting your ASF usage or tuning runtime's garbage collector, as explained in **[low-memory setup](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup)**. Therefore, you should use `MinMemoryUsage` as a **last resort**, right before runtime recompilation, if you couldn't achieve satisfying results with other (much better) options. Unless you have a **strong** reason to edit this property, you should keep it at default.

---

### `SteamMessagePrefix`

`string` 타입으로 기본값은 `"/me "`입니다. 이 속성값은 ASF가 보내는 모든 Steam 메시지에 붙는 접두사를 정의합니다. ASF는 기본적으로 `"/me "` 접두사를 사용하여 Steam 대화에서 봇 메시지를 다른 색으로 표시하여 구별하기 쉽도록 합니다. `"/pre "` 접두사도 비슷한 효과를 내지만 다른 형식을 가지고 있습니다. 접두사를 완전히 사용하지 않고 모든 ASF 메시지를 전통적 방식으로 보내려면 이 속성값을 빈 문자열이나 `null`로 설정할 수도 있습니다. 이 속성값은 Steam 메시지에만 영향을 줍니다. IPC와 같은 다른 채널을 통해 돌아오는 응답은 영향을 받지 않습니다. 기본 ASF 행동을 변경하고 싶지 않다면 기본값 그대로 두는것도 좋은 생각입니다.

---

### `SteamOwnerID`

`ulong` 타입으로 기본값은 `0`입니다. 이 속성값은 ASF 프로세스 소유자의 64비트 형태로 된 Steam ID를 정의합니다. 봇 인스턴스(일반 환경설정이 아닙니다)의 `주인(Master)` 권한과 매유 유사합니다. 이 속성값은 당신 자신의 메인 Steam 계정의 ID로 설정합니다. `주인(Master)` 권한은 봇 인스턴스에 대한 전체 제어를 갖지만, `exit`, `restart` 또는 `update` 같은 일반 환경의 명령어는 `SteamOwnerID` 전용입니다. This is convenient, as you may want to run bots for your friends, while not allowing them to control ASF process, such as exiting it via `exit` command. 기본값인 `0`은 ASF 프로세스의 소유자가 없다는 것으로, 일반 ASF 명령을 누구도 실행할 수 없다는 뜻입니다. Keep in mind that this property applies to Steam chat exclusively. **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)**, as well as interactive console, will still allow you to execute `Owner` commands even if this property is not set.

---

### `SteamProtocols`

`byte flags` 타입으로 기본값은 `7`입니다. 이 속성값은 ASF가 Steam 서버에 접속할때 사용할 Steam 프로토콜을 정의합니다. 정의는 아래와 같습니다.

| 값 | 이름        | 설명                                                                                               |
| - | --------- | ------------------------------------------------------------------------------------------------ |
| 0 | 없음(None)  | 프로토콜 없음                                                                                          |
| 1 | TCP       | **[Transmission Control Protocol](https://en.wikipedia.org/wiki/Transmission_Control_Protocol)** |
| 2 | UDP       | **[User Datagram Protocol](https://en.wikipedia.org/wiki/User_Datagram_Protocol)**               |
| 4 | WebSocket | **[WebSocket](https://en.wikipedia.org/wiki/WebSocket)**                                         |

이 속성값은 `flags` 항목이므로, 가능한 여러 값을 조합할 수 있습니다. Check out **[json mapping](#json-mapping)** if you'd like to learn more. 어떤 플래그도 활성화하지 않으면 `없음(None)` 옵션과 동일하며, 이는 유효하지 않은 값입니다.

By default ASF will use all available Steam protocols as a measure for fighting with downtimes and other similar Steam issues. Typically you want to change this property if you want to limit ASF into using only one or two specific protocols. 예를들어 방화벽에서 TCP만 활성화하고 ASF가 UDP로 연결을 시도하지 않길 원한다면 이런 수단이 필요할 수 있습니다. 그러나, 특정 문제나 이슈를 디버깅하는 중이 아니라면 거의 항상 ASF가 한두개가 아닌 현재 지원되는 어느 프로토콜이든 자유롭게 사용하길 원할 것입니다. 이 속성값을 변경해야 할 **명확한** 이유가 있지 않다면 기본값을 그대로 유지해야 합니다.

---

### `UpdateChannel`

`byte` 타입으로 기본값은 `1`입니다. 이 속성값은 자동 업데이트(`UpdatePeriod` 가 `0`보다 큰 경우)나 업데이트 알림에서 사용할 업데이트 채널을 정의합니다. 현재 ASF는 3개의 업데이트 채널을 지원합니다. `0`은 `없음(None)`, `1`은 `안정(Stable)`, 그리고 `2`는 `실험(Experimental)`입니다. `안정(Stable)` 채널은 기본 릴리스 채널로, 대부분의 사용자가 사용해야 합니다. `실험(Experimental)` 채널은 `안정(Stable)` 릴리스에, 새로운 기능을 테스트하고 버그수정이나 계획된 개선사항에 대한 피드백을 주기 위한 고급 사용자와 개발자용인 **사전 릴리스(pre-releases)** 를 포함합니다. **실험(Experimental) 버전은 종종 수정되지 않은 버그나 작업중인 기능이 포함되어 있습니다.**. If you don't consider yourself advanced user, please stay with default `1` (`Stable`) update channel. `실험(Experimental)` 채널은 버그를 제보하고, 이슈를 다루며 피드백을 주는 방법을 아는 사용자 용입니다. 기술지원은 제공되지 않습니다. 더 알고 싶다면 ASF의 **[릴리스 주기](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Release-cycle-ko-KR)** 를 참고하십시오. 모든 버전확인을 완전히 제거하고 싶다면 `UpdateChannel`을 `0`(`없음(None)`)으로 설정할 수도 있습니다. `UpdateChannel`을 `0`으로 설정하면 `update` 명령을 포함한 업데이트와 관련된 모든 기능을 모두 비활성화합니다. 아래의 `UpdatePeriod` 설명에서 언급하는 모든 종류의 문제에 노출되므로 `없음(None)` 채널은 **하지 않기를 강력하게 권고합니다**.

**지금 하고 있는 것이 뭔지 알고 있지 않다면**, 기본값 그대로 두는 것을 **강력하게** 권장합니다.

---

### `UpdatePeriod`

`byte` 타입으로 기본값은 `24`입니다. 이 속성값은 자동 업데이트를 위해 ASF가 얼마나 자주 확인할지를 정의합니다. 업데이트는 새로운 기능과 심각한 보안 패치를 받기위해서 뿐 아니라 버그수정, 성능개선, 안정성 향상 등을 위해서도 중요합니다. `0`보다 큰 값이 설정되면 ASF는 새로운 업데이트가 나오면 자동으로 다운로드받아 교체하고 재시작(`AutoRestart`가 허용된 경우)합니다. 이렇게 하기 위해서 ASF는 매 `UpdatePeriod` 시간마다 새 업데이트가 GitHub repo에 있는지 확인합니다. `0` 값은 자동 업데이트를 비활성화 합니다. 하지만 수동으로 `update` 명령을 실행할 수는 있습니다. You may also be interested in setting appropriate `UpdateChannel` that `UpdatePeriod` should follow.

Update process of ASF involves update of entire folder structure that ASF is using, but without touching your own configs or databases located in `config` directory - this means that any extra files unrelated to ASF in its directory can be lost during update. 기본값인 `24`는 불필요한 확인과 충분히 새제품간의 적절한 균형점입니다.

이 속성값을 비활성화할 **명확한** 이유가 있지 않다면 **당신 자신을 위해서** 합리적인 `UpdatePeriod` 기간으로 자동 업데이트를 활성화상태로 유지해야 합니다. 우리는 최신의 안정 ASF 릴리스만 지원하며, **최신 버전에만 보안성을 보장하기** 때문입니다. 만약 오래된 ASF 버전을 사용한다면, 작은 버그부터 기능 깨짐, 종국에는 **[영구적인 Steam 계정 정지](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ-ko-KR#차단당한-사람이-있나요)** 까지 온갖 종류의 이슈에 일부러 노출하는 것입니다. 그러므로 자신을 위해서 항상 ASF를 최신버전으로 업데이트할 것을 **강력하게 권장합니다**. 자동 업데이트는 문제가 되는 코드를 일이 커지기 전에 비활성화 하거나 패치하여 모든 종류의 이슈에 빠르게 대응할 수 있게 합니다. 하지 않겠다면 모든 보안성 보장을 버리고 Steam 네트워크 뿐 아니라 자신의 Steam 계정에도 잠재적으로 해로울 수 있는 코드를 실행하는 위험을 감수하는 것입니다.

---

### `WebLimiterDelay`

`ushort` 타입으로 기본값은 `300`입니다. 이 속성값은 동일한 Steam 웹서비스에 전송한 두개의 연속한 요청간의 최소 지연시간을 밀리초 단위로 정의합니다. 이 지연은 주어진 시간에 보내진 요청의 전체 건 수에 따른 등록 활성화 제한을 포함해서 Steam이 내부적으로 사용하는 **[AkamaiGhost](https://www.akamai.com)** 서비스의 형태로 필요합니다. 보통 상황에서 akamai 차단은 잘 일어나지 않지만, 거대하고 지속적인 일련의 요청으로 매우 부하가 심하다면 매우 짧은 시간동안 매우 많은 요청을 보내는 경우 차단이 작동할 가능성이 있습니다.

기본값은 ASF가 `steamcommunity.com`, `api.steampowered.com` 그리고 `store.steampowered.com`와 같은 Steam 웹서비스에 접근하는 유일한 도구라고 가정하고 설정하였습니다. 동일한 웹서비스에 요청을 보내는 다른 도구를 사용중이라면 그 도구에 `WebLimiterDelay`와 유사한 기능이 있는지를 확인하고, 양 쪽 모두를 기본값의 두배인 `600` 정도로 설정하여야 합니다. 이렇게 하면 어떤 경우에서건 한개의 요청이 `300` ms을 넘지 않을 것입니다.

In general, lowering `WebLimiterDelay` under default value is **strongly discouraged** as it could lead to various IP-related blocks, some of which are possible to be permanent. 기본값은 서버에서 단일 ASF 인스턴스를 실행하는데도 충분하고, 원본 Steam 클라이언트와 함께 ASF를 정상적인 시나리오대로 사용하는데도 충분합니다. It should be correct for majority of usages, and you should only increase it (never lower it). 즉, 단일 IP에서 단일 Steam 도메인으로 보내지는 모든 요청의 전체 숫자는 절대 `300` ms 당 1개 요청을 초과해서는 안됩니다.

이 속성값을 변경해야 할 이유가 있지 않다면 기본값을 그대로 유지해야 합니다.

---

### `WebProxy`

`string` 타입으로 기본값은 `null`입니다. 이 속성값은 ASF의 `HttpClient`가 보내는, 특히 `github.com`, `steamcommunity.com` 그리고 `store.steampowered.com` 등의 서비스로 보내는 모든 내부 http와 https 요청에 사용될 웹 프록시 주소를 정의합니다. ASF 요청을 프록시하는 것은 일반적으로 이점이 없지만 특히 중국의 만리방화벽과 같은 다양한 종류의 방화벽을 넘어가는데 특히 유용합니다.

이 속성값은 아래와 같은 uri 문자열로 정의됩니다.

> A URI string is composed of a scheme (supported: http/https/socks4/socks4a/socks5), a host, and an optional port. 다음은 완전한 uri 문자열의 예시입니다. `"http://contoso.com:8080"`.

프록시가 인증을 필요로 하면, `WebProxyUsername`과 `WebProxyPassword`를 설정해야 합니다. 그럴 필요가 없다면 이 속성값을 설정하는 것만으로 충분합니다.

지금 ASF는 `http`와 `https` 요청만을 위해 웹 프록시를 사용합니다. 이는 ASF의 내부 Steam 클라이언트에서 이루어지는 내부 Steam 네트워크 통신을 **포함하지 않습니다**. **[SK2](https://github.com/SteamRE/SteamKit/issues/587#issuecomment-413271550)** 기능이 없으므로 이를 지원할 계획은 현재로써는 없습니다. 만약 당신이 이를 할 필요가 있거나 하기를 원한다면 거기서부터 시작하기를 권합니다.

이 속성값을 변경해야 할 이유가 있지 않다면 기본값을 그대로 유지해야 합니다.

---

### `WebProxyPassword`

`string` 타입으로 기본값은 `null`입니다. 이 속성값은 프록시 기능을 제공하는 대상 `WebProxy` 기기에서 지원하는 기본, digest, NTLM, Kerberos 인증에 사용되는 암호 필드를 정의합니다. 프록시가 사용자 자격증명을 필요로 하지 않는다면 여기에 아무것도 넣을 필요가 없습니다. `WebProxy`가 사용될 때 이 옵션의 사용도 의미가 있고, 그외에는 효과가 없습니다.

이 속성값을 변경해야 할 이유가 있지 않다면 기본값을 그대로 유지해야 합니다.

---

### `WebProxyUsername`

`string` 타입으로 기본값은 `null`입니다. 이 속성값은 프록시 기능을 제공하는 대상 `WebProxy` 기기에서 지원하는 기본, digest, NTLM, Kerberos 인증에 사용되는 사용자이름 필드를 정의합니다. 프록시가 사용자 자격증명을 필요로 하지 않는다면 여기에 아무것도 넣을 필요가 없습니다. `WebProxy`가 사용될 때 이 옵션의 사용도 의미가 있고, 그외에는 효과가 없습니다.

이 속성값을 변경해야 할 이유가 있지 않다면 기본값을 그대로 유지해야 합니다.

---

## 봇 환경설정

당신이 이미 알다시피, 모든 봇은 자신만의 설정을 가지고 있어야 합니다. 아래는 기본이 되는 JSON구조의 예시입니다. `1.json`, `main.json`, `primary.json` 또는 `AnythingElse.json` 등 봇의 이름을 짓는 것부터 시작해서 환경설정으로 넘어갑니다.

**주의:** 봇은 `ASF`로 명명할 수 없습니다. ASF는 일반 환경설정을 위한 예약키워드입니다. 또한 점(.)으로 시작하는 모든 환경설정 파일을 무시합니다.

봇 환경설정은 아래와 같은 구조를 갖습니다.

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

모든 옵션은 다음과 같습니다.

### `AcceptGifts`

`bool` 타입으로 기본값은 `false`입니다. 활성화 되어있으면 ASF는 자동으로 봇으로 보내지는 모든 Steam 선물(월렛 기프트카드 포함)을 수락하고 등록합니다. `SteamUserPermissions`에서 정의된 사용자 이외의 사용자가 보낸 선물도 포함됩니다. 이메일 주소로 보낸 선물은 클라이언트로 직접 전달되지 않음을 명심하십시오. ASF는 당신의 도움 없이는 그것을 받을 수 없습니다.

이 옵션은 부계정에 권장합니다. 주 계정에 모든 선물을 자동으로 등록하지는 않기 때문입니다. 이 기능을 사용할지 아닐지 불확실하다면 기본값인 `false`를 유지하십시오.

---

### `AutoSteamSaleEvent`

`bool` 타입으로 기본값은 `false`입니다. Steam의 여름/겨울 세일 이벤트 기간동안 Steam은 매일 맞춤 대기열을 확인하거나 특정 이벤트 행동을 하면 추가로 카드를 제공합니다. 이 옵션이 활성화되어 있으면 ASF는 자동으로 프로그램이 시작한지 한시간안에 시작하여 `8`시간마다 Steam 맞춤 대기열을 확인하고, 필요하다면 클리어합니다. 그 행동을 직접하기 원한다면 이 옵션은 권장하지 않습니다. 일반적으로 봇 계정에만 맞는 이야기입니다. 또한, 처음으로 이 카드를 받기 원한다면 계정이 적어도 `8` 레벨 이상인지 확인해야 합니다. 이는 Steam의 직접 요구사항입니다. 이 기능을 사용할지 아닐지 불확실하다면 기본값인 `false`를 유지하십시오.

Valve의 이슈, 변화, 문제에 따라 **이 기능이 정상작동할지 보증하지 않습니다**. 따라서 이 옵션이**전혀 작동하지 않을** 수도 있습니다. 이 옵션과 관련한 **어떠한** 버그 제보, 지원 요청도 받지 않습니다. 보증을 전혀 하지 않고 제공되는 기능이므로, 위험을 감수하고 사용하시기 바랍니다.

---

### `BotBehaviour`

`byte flags` 타입으로 기본값은 `0`입니다. 이 속성값은 다양한 이벤트 발생시 ASF 봇의 행동을 아래와 같이 정의합니다.

| 값  | 이름                                          | 설명                                                                                                       |
| -- | ------------------------------------------- | -------------------------------------------------------------------------------------------------------- |
| 0  | 없음(None)                                    | 특별한 행동 없음, 가장 덜 공격적인 모드, 기본값                                                                             |
| 1  | 유효하지 않은 친구초대 거절(RejectInvalidFriendInvites) | ASF는 유효하지 않은 친구 초대를 거절합니다.(무시 아님)                                                                        |
| 2  | 유효하지 않은 거래 거절(RejectInvalidTrades)          | ASF는 유효하지 않은 거래 제안을 거절합니다.(무시 아님)                                                                        |
| 4  | 유효하지 않은 그룹 초대 거절(RejectInvalidGroupInvites) | ASF는 유효하지 않은 그룹 초대를 거절합니다.(무시 아님)                                                                        |
| 8  | 보관함 알림 해제(DismissInventoryNotifications)    | ASF가 모든 보관함 알림을 자동으로 해제합니다.                                                                              |
| 16 | 받은 메시지 읽은상태로 표시(MarkReceivedMessagesAsRead) | ASF가 모든 도착한 메시지를 자동으로 읽은 상태로 표시합니다.                                                                      |
| 32 | MarkBotMessagesAsRead                       | Will cause ASF to automatically mark messages from other ASF bots (running in the same instance) as read |

이 속성값은 `flags` 항목이므로, 가능한 여러 값을 조합할 수 있습니다. Check out **[json mapping](#json-mapping)** if you'd like to learn more. 플래그를 활성화 하지 않으면 `없음(None)`과 같습니다.

일반적으로 ASF가 활동과 관련하여 일정량 만큼의 자동화를 해주기를 기대한다면 이 속성값을 변경하시기 바랍니다. 이는 주 계정이 아닌 봇 계정에 설정할 것을 권장합니다. 주로 부계정에서 이 속성값을 변경하겠지만 주 계정에서 이 옵션을 선택하는 것은 자유입니다.

Normal (`None`) ASF behaviour is to only automate things that user wants (e.g. cards farming or `SteamTradeMatcher` offers processing, if set in `TradingPreferences`). 이는 가장 덜 공격적인 모드이고 계정의 전체 권한을 그대로 가지고 있어 특정한 범위를 벗어난 상호작용을 허락하거나 허락하지 않을지를 스스로 결정할 수 있어서 대부분의 사용자에게 도움이 됩니다.

유효하지 않은 친구 초대는 `SteamUserPermissions`에 정의된 `가족 공유(FamilySharing)` 이상의 권한을 가진 사용자가 아닌 사람으로 부터 온 친구 초대입니다. 예상하시는 대로 보통 모드에서 ASF는 이 초대를 무시하고 이를 받아들일지 말지 선택권을 당신에게 줍니다. `유효하지 않은 친구초대 거절(RejectInvalidFriendInvites)`은 이러한 초대를 자동으로 거절합니다. 따라서 실제적으로 다른 사람들이 당신을 친구 리스트에 추가하는 옵션을 막습니다. 당신이 `SteamUserPermissions`에 정의한 사람들을 제외하고 그런 요청을 모두 거부합니다. 모든 친구 초대를 완전히 거부하려는 것이 아니라면 이 옵션을 활성화해서는 안됩니다.

유효하지 않은 거래 제안은 내장된 ASF 모듈에서 수락되지 않는 제안입니다. ASF가 자동으로 수락하려고 하는 거래 형식의 명시적 정의는 **[거래](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading-ko-KR)** 항목을 참고하시기 바랍니다. 유효한 거래는 다른 설정, 특히 `TradingPreferences`에도 정의되어 있습니다. `RejectInvalidTrades`는 모든 유효하지 않은 거래 제안을 무시하는 대신 거부합니다. ASF에서 자동으로 수락하지 않는 모든 거래 제안을 완전히 거부하려는 것이 아니라면 이 옵션을 활성화 해서는 안됩니다.

유효하지 않은 그룹 초대는 `SteamMasterClanID` 그룹이 아닌 그룹에서 온 초대입니다. 예상하시는대로 보통 모드에서 ASF는 이러한 그룹 초대를 무시하고, 특정 Steam 그룹에 가입할지 말지를 스스로 정하도록 합니다. `유효하지 않은 그룹초대 거절(RejectInvalidGroupInvites)`은 이러한 그룹 초대를 자동으로 거절하고, `SteamMasterClanID`가 아닌 다른 그룹이 당신을 초대할 수 없도록 합니다. 모든 그룹 초대를 완전히 거부하려는 것이 아니라면 이 옵션을 활성화해서는 안됩니다.

`DismissInventoryNotifications` is extremely useful when you start getting annoyed by constant Steam notification about receiving new items. 이 알림은 Steam 클라이언트에 내장되어있기 때문에 ASF가 이 알림을 없앨수는 없지만, 알림을 받은 후 이를 자동으로 클리어 할 수는 있으며, "새로운 보관함 항목" 알림을 놔두지 않아도 됩니다. If you expect to evaluate yourself all received items (especially cards farmed with ASF), then naturally you shouldn't enable this option. 미쳐가고 있다면 이 옵션이 있음을 기억하십시오.

`MarkReceivedMessagesAsRead` will automatically mark **all** messages being received by the account on which ASF is running, both private and group, as read. 이는 보통 부계정에서 ASF 명령어 수행중에 자신이 보낸 "새로운 메시지"를 클리어하기 위해서만 사용합니다. 당신은 오프라인이지만 ASF는 여전히 알림을 해제하고 있었던 메시지를 **포함한** 모든 종류의 새로운 메시지 알림을 잘라내버리고 싶지 않는 한, 이 옵션을 주 계정에서 사용하는 것을 권장하지 않습니다.

`MarkBotMessagesAsRead` works in a similar manner by marking only bot messages as read. However, keep in mind that when using that option on group chats with your bots and other people, Steam implementation of acknowledging chat message **also** acknowledges all messages that happened **before** the one you decided to mark, so if by any chance you don't want to miss unrelated message that happened in-between, you typically want to avoid using this feature. Obviously, it's also risky when you have multiple primary accounts (e.g. from different users) running in the same ASF instance, as you can also miss their normal out-of-ASF messages.

이 옵션을 어떻게 설정해야 할지 확실치 않다면 기본값으로 두는 것이 최선입니다.

---

### `CompleteTypesToSend`

`ImmutableHashSet<byte>` 타입으로 기본값은 비어있습니다. When ASF is done with completing a given set of item types specified here, it can automatically send steam trade with all finished sets to the user with `Master` permission, which is very convenient if you'd like to utilize given bot account for e.g. STM matching, while moving finished sets to some other account. This option works the same as `loot` command, therefore keep in mind that it requires user with `Master` permission set, you may also need a valid `SteamTradeToken`, as well as using an account that is eligible for trading in the first place.

As of today, the following item types are supported in this setting:

| 값 | 이름                          | 설명                              |
| - | --------------------------- | ------------------------------- |
| 3 | 은박 트레이딩 카드(FoilTradingCard) | `트레이딩 카드(TradingCard)`의 은박 버전   |
| 5 | 트레이딩 카드(TradingCard)        | Steam 트레이딩 카드. 배지 제작에 사용. 은박 아님 |

위의 설정과 상관없이 ASF는 Steam(`appID` 753) 커뮤니티(`contextID` 6) 아이템만을 요청할 것입니다. 모든 게임 아이템, 선물 등등은 정의에 따라 거래 제안에서 제외됩니다.

Due to additional overhead of using this option, it's recommended to use it only on bot accounts that have a realistic chance of finishing sets on their own - for example, it makes no sense to activate if you're already using `SendOnFarmingFinished`, `SendTradePeriod` or `loot` command on usual basis.

이 옵션을 어떻게 설정해야 할지 확실치 않다면 기본값으로 두는 것이 최선입니다.

---

### `CustomGamePlayedWhileFarming`

`string` 타입으로 기본값은 `null`입니다. ASF가 농사를 짓는 동안 현재 농사짓는 게임 대신 "`CustomGamePlayedWhileFarming`을 플레이중"으로 표시합니다. 이것은 친구들에게 자신이 농사를 짓는 중이라고 알려주고는 싶지만 기본 `OnlineStatus`를 `오프라인`으로 사용하고 싶지는 않을때 유용합니다. ASF는 Steam 네트워크의 실제 표시 순서를 보장하지 않습니다. 정확하게, 혹은 부정확하게 표시될 수 있는 제안일 뿐입니다. In particular, custom name will not display in `Complex` farming algorithm if ASF fills all `32` slots with games requiring hours to be bumped. 기본값 `null`은 이 기능을 비활성화 합니다.

ASF provides a few special variables that you can optionally use in your text. `{0}` will be replaced by ASF with `AppID` of currently farmed game(s), while `{1}` will be replaced by ASF with `GameName` of currently farmed game(s).

---

### `CustomGamePlayedWhileIdle`

`string` 타입으로 기본값은 `null`입니다. `CustomGamePlayedWhileFarming`와 비슷하지만 농사가 끝난 계정 등 ASF가 할 일이 없을 경에 사용합니다. ASF는 Steam 네트워크의 실제 표시 순서를 보장하지 않습니다. 정확하게, 혹은 부정확하게 표시될 수 있는 제안일 뿐입니다. If you're using `GamesPlayedWhileIdle` together with this option, then keep in mind that `GamesPlayedWhileIdle` get priority, therefore you can't declare more than `31` of them, as otherwise `CustomGamePlayedWhileIdle` will not be able to occupy the slot for custom name. 기본값 `null`은 이 기능을 비활성화 합니다.

---

### `Enabled`

`bool` 타입으로 기본값은 `false`입니다. 이 속성값은 이 봇의 활성화 여부를 정의합니다. 활성화된 봇 인스턴스(`true`)는 ASF 실행시에 자동으로 시작되고, 비활성된 봇 인스턴스(`false`)는 수동으로 시작해야 합니다. 기본값으로 모든 봇이 비활성화되어 있습니다. 따라서 자동으로 시작할 모든 봇의 이 속성값을 `true`로 바꾸어야 합니다.

---

### `EnableRiskyCardsDiscovery`

`bool` 타입으로 기본값은 `false`입니다. This property enables additional fallback which triggers when ASF is unable to load one or more of badge pages and is therefore unable to find games available for farming. In particular, some accounts with massive amount of card drops might cause a situation where loading badge pages is no longer possible (due to overhead), and those accounts are impossible for farming purely because we can't load the information based on which we can start the process. For those handful cases, this option allows alternative algorithm to be used, which uses a combination of boosters possible to craft and booster packs the account is eligible for, in order to find potentially available games to idle, then spends excessive amount of resources for verifying and fetching required information, and attempts to start the process of farming on limited amount of data and information in order to eventually reach a situation when badge page loads and we'll be able to use normal approach. Please note that when this fallback is used, ASF operates only with limited data, therefore it's completely normal for ASF to find much less drops than in reality - other drops will be found at later stage of farming process.

This option is called "risky" for a very good reason - it's extremely slow and requires significant amount of resources (including network requests) for operation, therefore it's **not recommended** to be enabled, and especially in long-term. You should use this option only if you previously determined that your account suffers from being unable to load badge pages and ASF can't operate on it, always failing to load necessary information to start the process. Even if we made our best to optimize the process as much as possible, it's still possible for this option to backfire, and it might cause unwanted outcomes, such as temporary and maybe even permanent bans from Steam side for sending too many requests and otherwise causing overhead on Steam servers. Therefore, we warn you in advance and we're offering this option with absolutely no guarantees, you're using it at your own risk.

Unless you know what you're doing, you should keep it with default value of `false`.

---

### `FarmingOrders`

`ImmutableList<byte>` type with default value of being empty. 이 속성값은 해당 봇 계정에서 ASF가 사용할 **선호하는** 농사 순서를 정의합니다. 현재 가능한 농사 순서는 다음과 같습니다.

| 값  | 이름                                       | 설명                               |
| -- | ---------------------------------------- | -------------------------------- |
| 0  | 순서 없음(Unordered)                         | 정렬하지 않음, CPU 성능 약간 개선            |
| 1  | App ID 오름차순(AppIDsAscending)             | `appID`가 작은 게임부터 먼저 농사 시도        |
| 2  | App ID 내림차순(AppIDsDescending)            | `appID`가 큰 게임부터 먼저 농사 시도         |
| 3  | 카드 드롭 오름차순(CardDropsAscending)           | 얻을 수 있는 카드의 수가 적은 게임부터 먼저 농사 시도  |
| 4  | 카드 드롭 내림차순(CardDropsDescending)          | 얻을 수 있는 카드의 수가 많은 게임부터 먼저 농사 시도  |
| 5  | 시간 오름차순(HoursAscending)                  | 플레이 시간이 적은 게임부터 먼저 농사 시도         |
| 6  | 시간 내림차순(HoursDescending)                 | 플레이 시간이 많은 게임부터 먼저 농사 시도         |
| 7  | 이름 오름차순(NamesAscending)                  | A부터 시작하는 알파벳 순으로 농사 시도           |
| 8  | 이름 내림차순(NamesDescending)                 | Z부터 시작하는 알파벳 역순으로 농사 시도          |
| 9  | 무작위(Random)                              | 완전히 무작위 순서로 농사 시도(프로그램 실행시마다 변경) |
| 10 | 배지 레벨 오름차순(BadgeLevelsAscending)         | 배지 레벨이 낮은 게임부터 먼저 농사 시도          |
| 11 | 배지 레벨 내림차순(BadgeLevelsDescending)        | 배지 레벨이 높은 게임부터 먼저 농사 시도          |
| 12 | 등록 날짜 시간 오름차순(RedeemDateTimesAscending)  | 계정 등록이 오래된 게임부터 먼저 농사 시도         |
| 13 | 등록 날짜 시간 내림차순(RedeemDateTimesDescending) | 계정 등록이 최근인 게임부터 먼저 농사 시도         |
| 14 | 장터화 오름차순(MarketableAscending)            | 카드 판매불가인 게임부터 먼저 농사 시도           |
| 15 | 장터화 내림차순(MarketableDescending)           | 카드 판매가능인 게임부터 먼저 농사 시도           |

이 속성값은 배열이므로 고정된 순서를 여러 다른 설정을 사용할 수 있게 해 줍니다. 예를 들어 카드 판매가능한 게임을 먼저, 배지 레벨이 높은 게임을 그 다음에, 마지막으로 알파벳순으로 정렬하려고 `15`, `11`, 그리고 `7` 값을 포함할 수 있습니다. As you can guess, the order actually matters, as reverse one (`7`, `11` and `15`) achieves something entirely different (sorts games alphabetically first, and due to game names being unique, the other two are effectively useless). 대부분의 사람들은 한 가지 순서만 사용하지만, 만약 원한다면 추가 매개 변수로 더 깊이있게 정렬할 수 있습니다.

위의 설명에 있는 "시도"라는 단어에 유의하십시오. 실제 ASF의 순서는 선택한 **[카드 농사 알고리즘](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance-ko-KR)**에 심하게 영향을 받고 정렬방식은 동일한 성능측면을 고려한 경우에만 영향을 줍니다. For example, in `Simple` algorithm, selected `FarmingOrders` should be entirely respected in current farming session (as every game has the same performance value), while in `Complex` algorithm actual order is affected by hours first, and then sorted according to chosen `FarmingOrders`. This will lead to different results, as games with existing playtime will have a priority over others, so effectively ASF will prefer games that already passed required `HoursUntilCardDrops` firstly, and only then sorting those games further by your chosen `FarmingOrders`. Likewise, once ASF runs out of already-bumped games, it'll sort remaining queue by hours first (as that will decrease time required for bumping any of remaining titles to `HoursUntilCardDrops`). Therefore, this config property is only a **suggestion** that ASF will try to respect, as long as it doesn't affect performance negatively (in this case, ASF will always prefer farming performance over `FarmingOrders`).

There is also farming priority queue that is accessible through `fq` **[commands](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. If it's used, actual farming order is sorted firstly by performance, then by farming queue, and finally by your `FarmingOrders`.

---

### `FarmPriorityQueueOnly`

`bool` 타입으로 기본값은 `false`입니다. This property defines if ASF should consider for automatic farming only apps that you added yourself to priority farming queue available with `fq` **[commands](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. When this option is enabled, ASF will skip all `appIDs` that are missing on the list, effectively allowing you to cherry-pick games for automatic ASF farming. Keep in mind that if you didn't add any games to the queue then ASF will act as if there is nothing to farm on your account. 이 기능을 사용할지 아닐지 불확실하다면 기본값인 `false`를 유지하십시오.

---

### `GamesPlayedWhileIdle`

`ImmutableHashSet<uint>` 타입으로 기본값은 비어있습니다. ASF가 농사지을 것이 없다면 대신 특정 게임(`appIDs`)을 플레이할 수 있습니다. 이 방법으로 플레이하면 "플레이한 시간"을 늘릴 수 있지만, 그게 끝입니다. In order for this feature to work properly, your Steam account **must** own a valid license to all the `appIDs` that you specify here, this includes F2P games as well. 이 기능은 Steam 네트워크에서 사용자정의 상태를 보여주면서 선택한 게임을 플레이하기 위해 `CustomGamePlayedWhileIdle`와 동시에 활성화 될 수 있습니다. 하지만 이 경우 `CustomGamePlayedWhileFarming`의 경우와 같이 실제 표시 순서는 보장하지 않습니다. Steam은 ASF가 총 `32`개의 `appIDs`를 플레이 할 수 있도록 허락하고 있으며, 따라서 이 속성값에 그만큼을 넣을 수 있습니다.

---

### `HoursUntilCardDrops`

`byte` 타입으로 기본값은 `3`입니다. 이 속성값은 이 계정에 카드 획득 제한이 있는지를 정의하고, 만약 제한이 있다면 최초 몇시간인지를 정의합니다. 카드 획득 제한이란, 그 계정에서 한 게임을 적어도 `HoursUntilCardDrops` 시간 동안 플레이하지 않으면 그 게임의 카드가 나오지 않는다는 의미입니다. 아쉽게도 이를 알아낼 수 있는 마법은 없으므로 ASF는 당신에게 의존합니다. 이 속성값은 사용할 **[카드 농사 알고리즘](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance-ko-KR)** 에 영향을 줍니다. 이 속성값을 설정하면 이득을 극대화하고 카드농사에 필요한 시간을 최소화합니다. 어떤 값을 사용할지에 대한 명확한 정답은 없고, 오로지 자신의 계정에 달려있음을 기억하십시오. 환불을 한번도 하지 않은 오래된 계정은 제한이 없는 것으로 보이므로 `0` 값을 사용하여야 하고, 새로운 계정과 환불을 받았던 계정은 획득 제한이 있으므로 `3` 값을 사용합니다. 하지만 이것은 단지 이론일 뿐이고 규칙으로 받아들여서는 안됩니다. 이 속성값의 기본값은 "소악(lesser evil)"과 대부분의 사용례에 근거해 설정되었습니다.

---

### `LootableTypes`

`ImmutableHashSet<byte>` 타입으로 기본값은 `1, 3, 5` Steam 아이템 타입입니다. This property defines ASF behaviour when looting - both manual, using a **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**, as well as automatic one, through one or more configuration properties. ASF는 `LootableTypes`에 있는 아이템만 거래 제안에 포함할 것이므로, 이 속성값은 당신에게 보내진 거래 제안에서 무엇을 받을지 결정할 수 있게 해줍니다.

| 값  | 이름                          | 설명                                           |
| -- | --------------------------- | -------------------------------------------- |
| 0  | 알 수 없음(Unknown)             | 아래의 어느것에도 해당하지 않는 모든 타입                      |
| 1  | 부스터 팩(BoosterPack)          | 한 게임의 무작위 카드 3장이 들어있는 부스터 팩                  |
| 2  | 이모티콘(Emoticon)              | Steam 대화에서 사용하는 이모티콘                         |
| 3  | 은박 트레이딩 카드(FoilTradingCard) | `트레이딩 카드(TradingCard)`의 은박 버전                |
| 4  | 프로필 배경(ProfileBackground)   | Steam 프로필에서 사용하는 프로필 배경                      |
| 5  | 트레이딩 카드(TradingCard)        | Steam 트레이딩 카드. 배지 제작에 사용. 은박 아님              |
| 6  | Steam 보석(SteamGems)         | 부스터 팩 제작에 사용되는 Steam 보석. 보석 더미 포함            |
| 7  | 판매 아이템(SaleItem)            | Steam 할인기간동안 획득하는 특별한 아이템                    |
| 8  | 소모품(Consumable)             | 사용하면 사라지는 특별한 소모 아이템                         |
| 9  | 프로필 수정(ProfileModifier)     | Steam 프로필 모양을 수정할 수 있는 특별한 아이템               |
| 10 | Sticker                     | Special items that can be used on Steam chat |
| 11 | ChatEffect                  | Special items that can be used on Steam chat |
| 12 | MiniProfileBackground       | Special background for Steam profile         |
| 13 | AvatarProfileFrame          | Special avatar frame for Steam profile       |
| 14 | AnimatedAvatar              | Special animated avatar for Steam profile    |
| 15 | KeyboardSkin                | Special keyboard skin for Steam deck         |
| 16 | StartupVideo                | Special startup video for Steam deck         |

위의 설정과 상관없이 ASF는 Steam(`appID` 753) 커뮤니티(`contextID` 6) 아이템만을 요청할 것입니다. 모든 게임 아이템, 선물 등등은 정의에 따라 거래 제안에서 제외됩니다.

Default ASF setting is based on the most common usage of the bot, with looting only booster packs, and trading cards (including foils). 여기 정의된 속성값은 당신을 만족시킬수 있도록 어떻게든 행동을 변경할 수 있게 합니다. 위에 정의되지 않은 모든 타입은 `알 수 없음(Unknown)` 타입으로 표시됨을 명심하십시오. Valve가 새로운 Steam 아이템을 내놓았을때 특히 중요한데, 향후 릴리스에서 여기에 추가되기 전까지는 ASF에서 `알 수 없음(Unknown)` 으로 표시될 것입니다. 이것이 당신이 무엇을 하고 있는지를 알고 있고, 만약 Steam 네트워크가 깨져서 모든 항목을 `알 수 없음(Unknown)`으로 표시한다면 ASF는 전체 보관함을 거래 제안으로 보낼것이라는 점도 이해하고 있지않는 한, 일반적으로 `알 수 없음(Unknown)` 타입을 `LootableTypes`에 포함시키는 것을 권장하지 않는 이유입니다. My strong suggestion is to not include `Unknown` type in the `LootableTypes`, even if you expect to loot everything (else).

---

### `MatchableTypes`

`ImmutableHashSet<byte>` 타입으로 기본값은 `5` Steam 아이템 타입입니다. 이 속성값은 `TradingPreferences`의 `SteamTradeMatcher` 옵션이 활성화 되었을 때 매칭을 허락할 Steam 아이템 타입을 정의합니다. 타입은 아래와 같이 정의됩니다.

| 값  | 이름                          | 설명                                           |
| -- | --------------------------- | -------------------------------------------- |
| 0  | 알 수 없음(Unknown)             | 아래의 어느것에도 해당하지 않는 모든 타입                      |
| 1  | 부스터 팩(BoosterPack)          | 한 게임의 무작위 카드 3장이 들어있는 부스터 팩                  |
| 2  | 이모티콘(Emoticon)              | Steam 대화에서 사용하는 이모티콘                         |
| 3  | 은박 트레이딩 카드(FoilTradingCard) | `트레이딩 카드(TradingCard)`의 은박 버전                |
| 4  | 프로필 배경(ProfileBackground)   | Steam 프로필에서 사용하는 프로필 배경                      |
| 5  | 트레이딩 카드(TradingCard)        | Steam 트레이딩 카드. 배지 제작에 사용. 은박 아님              |
| 6  | Steam 보석(SteamGems)         | 부스터 팩 제작에 사용되는 Steam 보석. 보석 더미 포함            |
| 7  | 판매 아이템(SaleItem)            | Steam 할인기간동안 획득하는 특별한 아이템                    |
| 8  | 소모품(Consumable)             | 사용하면 사라지는 특별한 소모 아이템                         |
| 9  | 프로필 수정(ProfileModifier)     | Steam 프로필 모양을 수정할 수 있는 특별한 아이템               |
| 10 | Sticker                     | Special items that can be used on Steam chat |
| 11 | ChatEffect                  | Special items that can be used on Steam chat |
| 12 | MiniProfileBackground       | Special background for Steam profile         |
| 13 | AvatarProfileFrame          | Special avatar frame for Steam profile       |
| 14 | AnimatedAvatar              | Special animated avatar for Steam profile    |
| 15 | KeyboardSkin                | Special keyboard skin for Steam deck         |
| 16 | StartupVideo                | Special startup video for Steam deck         |

물론, 이 속성값에 사용해야 할 타입은 보통 `2`, `3`, `4`, `5`만을 포함해야 하는데, 이 타입만 STM에서 지원하기 때문입니다. ASF는 아이템의 희귀도를 구별하는 적절한 논리구조를 가지고 있으며, 따라서 이모티콘이나 배경을 안전하게 매치할 수 있습니다. ASF는 같은 게임의 같은 타입의 이모티콘이나 배경을 공평하다고 판단하고 동일한 희귀도를 공유합니다.

**ASF는 거래 봇이 아니며**, **장터 가격을 신경쓰지 않음**을 명심하십시오. 한 세트 내의 동일한 희귀도를 가진 아이템이 같은 가격을 가져야 한다고 생각하지 않는다면, 이 옵션은 당신을 위한 것은 아닙니다. 이 설정을 변경하기 전에 위의 문장을 이해하고 동의하는지 두번 생각하십시오.

무슨 일을 하고 있는지 알지 못한다면 기본값인 `5`를 유지하십시오.

---

### `OnlineFlags`

`ushort flags` type with default value of `0`. This property works as supplement to **[`OnlineStatus`](#onlinestatus)** and specifies additional online presence features announced to Steam network. Requires **[`OnlineStatus`](#onlinestatus)** other than `Offline`, and is defined as below:

| 값    | 이름                | 설명                                        |
| ---- | ----------------- | ----------------------------------------- |
| 0    | 없음(None)          | No special online presence flags, default |
| 256  | ClientTypeWeb     | Client is using web interface             |
| 512  | ClientTypeMobile  | Client is using mobile app                |
| 1024 | ClientTypeTenfoot | Client is using big picture               |
| 2048 | ClientTypeVR      | Client is using VR headset                |

이 속성값은 `flags` 항목이므로, 가능한 여러 값을 조합할 수 있습니다. Check out **[json mapping](#json-mapping)** if you'd like to learn more. 플래그를 활성화 하지 않으면 `없음(None)`과 같습니다.

The underlying `EPersonaStateFlag` type that this property is based on includes more available flags, however, to the best of our knowledge they have absolutely no effect as of today, therefore they were cut for visibility.

이 속성값을 어떻게 설정해야 할지 모르겠다면, 기본값인 `0`으로 두십시오.

---

### `OnlineStatus`

`byte` 타입으로 기본값은 `1`입니다. 이 속성값은 스팀 네트워크에 로그인 후 스팀 네트워크에 알려줄 활동 상태를 지정합니다. 현재 선택할 수 있는 활동 상태는 다음과 같습니다.

| 값 | 이름             |
| - | -------------- |
| 0 | 오프라인           |
| 1 | 온라인            |
| 2 | 다른 용무 중        |
| 3 | 자리 비움          |
| 4 | 수면 중           |
| 5 | LookingToTrade |
| 6 | LookingToPlay  |
| 7 | Invisible      |

`오프라인` 상태는 주 계정에 극도로 유용합니다. 알다시피 게임을 농사지으면 스팀 상태가 "XXX를 플레이중"으로 나타나며, 실제로는 농사를 짓고 있는데 플레이를 하는것으로 혼동울 주어 당신의 친구들이 오해할 수 있습니다. `오프라인` 상태를 사용하면 ASF로 카드 농사중일때 "게임중"으로 표시하지 않아 이런 문제를 해결해줍니다. 이것은 ASF가 정상작동하기 위해서 스팀 커뮤니티에 로그인할 필요가 없기 때문에 가능합니다. 우리는 사실 스팀 네트워크에 접속해서, 게임을 플레이중이지만, 우리의 존재를 전혀 알리지 않습니다. 오프라인 상태에서 플레이했던 게임도 플레이 시간에 포함되며, 프로필의 "최근에 플레이한 게임"에 표시된 다는 것을 명심하십시오.

그 외에, 이 기능은 ASF는 실행중이지만 스팀 클라이언트는 동시에 열어놓지 않고도 알림과 읽지 않은 메시지를 수신하려는 경우에 중요합니다. 이것은 ASF가 스팀 클라이언트 그 자체인 것 처럼 행동하며, ASF가 그렇게 하던 아니던 스팀이 모든 메시지와 이벤트를 ASF로 보내주기 때문입니다. ASF와 스팀 클라이언트를 둘 다 실행하는 것은 문제가 없습니다. 두 클라이언트 모두 정확하게 동일한 이벤트를 수신합니다. 하지만 만약 ASF가 실행중이라면 스팀 클라이언트가 존재하지 않아 받을 수 없음에도 불구하고 특정 이벤트와 메시지를 "배달된" 것으로 표시할 수도 있습니다. 오프라인 상태는 이 문제도 해결합니다. ASF는 이 경우 어떤 커뮤니티 이벤트트로도 간주되지 않기때문에 모든 읽지 않은 메시지와 다른 이벤트가 당신이 돌아오면 읽지 않은 상태로 정상적으로 표시될 것입니다.

It's important to note that ASF running on `Offline` mode will **not** be able to receive commands in usual Steam chat way, as the chat, as well as entire community presence is in fact, entirely offline. A solution to this issue is using `Invisible` mode instead which works in a similar way (not exposing status), but keeps the ability to receive and respond to messages (so also a potential to dismiss notifications and unread messages as stated above). `Invisible` mode makes the most sense on alt accounts that you don't want to expose (status-wise), but still be able to send commands to.

However, there is one catch with `Invisible` mode - it doesn't go well with primary accounts. This is because **any** Steam session that is currently online **exposes** the status, even if ASF itself does not. This is caused by the current limitation/bug of the Steam network that isn't possible to be fixed on ASF side, so if you want to use `Invisible` mode you will also need to ensure that **all** other sessions to the same account use `Invisible` mode as well. This will be the case on alt accounts where ASF is hopefully the only active session, but on primary accounts you'll almost always prefer to show as `Online` to your friends, hiding only ASF activity, and in this case `Invisible` mode will be entirely useless for you (we recommend to use `Offline` mode instead). Hopefully this limitation/bug will be eventually solved in the future by Valve, but I wouldn't expect that to happen anytime soon...

이 속성값을 어떻게 설정할지 잘 모르겠다면, 주 계정은 `0` (`오프라인`)으로 놓고 다른 계정은 기본값인 `1` (`온라인`) 로 두는 것을 추천합니다.

---

### `PasswordFormat`

`byte` type with default value of `0` (`PlainText`). This property defines the format of `SteamPassword` property, and currently supports values specified in the **[security](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security)** section. You should follow the instructions specified there, as you'll need to ensure that `SteamPassword` property indeed includes password in matching `PasswordFormat`. 즉, `PasswordFormat`을 변경하면 `SteamPassword`는 그 후에 변경하는 것이 아니고 **이미** 그 형식으로 바뀌어있어야 합니다. 무슨 일을 하고 있는지 알지 못한다면 기본값인 `0`을 유지하십시오.

---

### `Paused`

`bool` 타입으로 기본값은 `false`입니다. 이 속성값은 `CardsFarmer` 모듈의 최초상태를 정의합니다. 기본값인 `false` 상태에서, 봇이 `Enabled` 또는 `start` 명령어로 시작되면 자동으로 농사를 시작합니다. 자동 농사 프로세스를 수동으로 `resume` 하려고 할때만 이 속성값을 `true`로 변경하십시오. 예를 들어 항상 `play`만 사용하고 절대로 자동 `CardsFarmer` 모듈을 사용하지 않는 경우입니다. 이 경우는 `pause` **[명령어](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-ko-KR)** 와 정확하게 동일하게 동작합니다. 이 기능을 사용할지 아닐지 불확실하다면 기본값인 `false`를 유지하십시오.

---

### `RedeemingPreferences`

`byte flags` 타입으로 기본값은 `0`입니다. 이 속성값은 cd키 등록에서 ASF 봇의 행동을 아래와 같이 정의합니다.

| 값 | 이름                                 | 설명                                                                                                                              |
| - | ---------------------------------- | ------------------------------------------------------------------------------------------------------------------------------- |
| 0 | 없음(None)                           | No special redeeming preferences, default                                                                                       |
| 1 | Forwarding                         | Forward keys unavailable to redeem to other bots                                                                                |
| 2 | Distributing                       | Distribute all keys among itself and other bots                                                                                 |
| 4 | KeepMissingGames                   | Keep keys for (potentially) missing games when forwarding, leaving them unused                                                  |
| 8 | AssumeWalletKeyOnBadActivationCode | Assume that `BadActivationCode` keys are equal to `CannotRedeemCodeFromClient`, and therefore try to redeem them as wallet keys |

이 속성값은 `flags` 항목이므로, 가능한 여러 값을 조합할 수 있습니다. Check out **[json mapping](#json-mapping)** if you'd like to learn more. 플래그를 활성화 하지 않으면 `없음(None)`과 같습니다.

`Forwarding` will cause bot to forward a key that is not possible to redeem, to another connected and logged on bot that is missing that particular game (if possible to check). The most common situation is forwarding `AlreadyPurchased` game to another bot that is missing that particular game, but this option also covers other scenarios, such as `DoesNotOwnRequiredApp`, `RateLimited` or `RestrictedCountry`.

`Distributing` will cause bot to distribute all received keys among itself and other bots. This means that every bot will get a single key from the batch. Typically this is used only when you're redeeming many keys for the same game, and you want to evenly distribute them among your bots, as opposed to redeeming keys for various different games. This feature makes no sense if you're redeeming only one key in a single `redeem` action (as there are no extra keys to be distributed).

`KeepMissingGames` will cause bot to skip `Forwarding` when we can't be sure if key being redeemed is in fact owned by our bot, or not. This basically means that `Forwarding` will apply **only** to `AlreadyPurchased` keys, instead of covering also other cases such as `DoesNotOwnRequiredApp`, `RateLimited` or `RestrictedCountry`. Typically you want to use this option on primary account, to ensure that keys being redeemed on it won't be forwarded further if your bot for example becomes temporarily `RateLimited`. As you can guess from the description, this field has absolutely no effect if `Forwarding` is not enabled.

`AssumeWalletKeyOnBadActivationCode` will cause `BadActivationCode` keys to be treated as `CannotRedeemCodeFromClient`, and therefore result in ASF trying to redeem them as wallet keys. This is needed because Steam might announce wallet keys as `BadActivationCode` (and not `CannotRedeemCodeFromClient` as it used to), resulting in ASF never attempting to redeem them. However, we recommend **against** using this preference, as it'll result in ASF trying to redeem every invalid key as a wallet code, resulting in excessive amount of (potentially invalid) requests sent to the Steam service, with all the potential consequences. Instead, we recommend to use `ForceAssumeWalletKey` **[`redeem^`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands#redeem-modes)** mode while knowingly redeeming wallet keys, which will enable the needed workaround only when it's required, on as-needed basis.

Enabling both `Forwarding` and `Distributing` will add distributing feature on top of forwarding one, which makes ASF trying to redeem one key on all bots firstly (forwarding) before moving to the next one (distributing). Typically you want to use this option only when you want `Forwarding`, but with altered behaviour of switching the bot on key being used, instead of always going in-order with every key (which would be `Forwarding` alone). This behaviour can be beneficial if you know that majority or even all of your keys are tied to the same game, because in this situation `Forwarding` alone would try to redeem everything on one bot firstly (which makes sense if your keys are for unique games), and `Forwarding` + `Distributing` will switch the bot on the next key, "distributing" the task of redeeming new key onto another bot than the initial one (which makes sense if keys are for the same game, skipping one pointless attempt per key).

The actual bots order for all of the redeeming scenarios is alphabetical, excluding bots that are unavailable (not connected, stopped or likewise). Please keep in mind that there is per-IP and per-account hourly limit of redeeming tries, and every redeem try that didn't end with `OK` contributes to failed tries. ASF will do its best to minimize number of `AlreadyPurchased` failures, e.g. by trying to avoid forwarding a key to another bot that already owns that particular game, but it's not always guaranteed to work due to how Steam is handling licenses. Using redeeming flags such as `Forwarding` or `Distributing` will always increase your likelyhood to hit `RateLimited`.

Also keep in mind that you can't forward or distribute keys to bots that you do not have access to. This should be obvious, but ensure that you're at least `Operator` of all the bots you want to include in your redeeming process, for example with `status ASF` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**.

---

### `RemoteCommunication`

`byte flags` 타입으로 기본값은 `3`입니다. This property defines per-bot ASF behaviour when it comes to communication with remote, third-party services, and is defined as below:

| 값 | 이름            | 설명                                                                                                                                                                                                                                                                |
| - | ------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| 0 | 없음(None)      | No allowed third-party communication, rendering selected ASF features unusable                                                                                                                                                                                    |
| 1 | SteamGroup    | Allows communication with **[ASF's Steam group](https://steamcommunity.com/groups/archiasf)**                                                                                                                                                                     |
| 2 | PublicListing | Allows communication with **[ASF's STM listing](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#publiclisting)** in order to being listed, if user has also enabled `SteamTradeMatcher` in **[`TradingPreferences`](#tradingpreferences)** |

이 속성값은 `flags` 항목이므로, 가능한 여러 값을 조합할 수 있습니다. Check out **[json mapping](#json-mapping)** if you'd like to learn more. 플래그를 활성화 하지 않으면 `없음(None)`과 같습니다.

This option doesn't include every third-party communication offered by ASF, only those that are not implied by other settings. For example, if you've enabled ASF's auto-updates, ASF will communicate with both GitHub (for downloads) and our server (for checksum verification), as per your configuration. Likewise, enabling `MatchActively` in **[`TradingPreferences`](#tradingpreferences)** implies communication with our server to fetch listed bots, which is required for that functionality.

Further explanation on this subject is available in **[remote communication](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Remote-communication)** section. 이 속성값을 변경해야 할 이유가 있지 않다면 기본값을 그대로 유지해야 합니다.

---

### `SendOnFarmingFinished`

`bool` 타입으로 기본값은 `false`입니다. ASF가 해당 계정의 농사를 끝내면 이 시점까지 농사지은 모든 것을 포함시킨 Steam 거래를 `주인(Master)` 권한을 가진 사용자에게 자동으로 보낼 수 있습니다. 이는 직접 거래하기 귀찮다면 매우 편리합니다. This option works the same as `loot` command, therefore keep in mind that it requires user with `Master` permission set, you may also need a valid `SteamTradeToken`, as well as using an account that is eligible for trading in the first place. 이 옵션이 켜져있다면 농사 후 `루팅`을 시작하는 것과 함께, ASF는 거래로 생기는 새로운 아이템의 알림도 `루팅`을 시작합니다. 이것은 다른 사람이 우리 계정에 보낸 아이템을 "전달"하는데 매우 유용합니다.

시간이 들어도 수동으로 확인하길 원한다면 필수사항은 아니지만, 보통 이 기능과 **[2단계 인증](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication-ko-KR)** 을 함께 사용하길 원합니다. 이 속성값을 어떻게 설정해야 할지 모르겠다면, 기본값인 `false`로 두십시오.

---

### `SendTradePeriod`

`byte` 타입으로 기본값은 `0`입니다. 이 속성값은 `SendOnFarmingFinished` 속성값과 매우 유사하게 동작하지만 차이가 하나 있습니다. 농사가 끝나면 거래를 보내는 대신 농사가 얼마나 남았는지와 상관없이 매 `SendTradePeriod` 시간마다 거래를 보냅니다. 부계정의 농사가 끝날때까지 기다리는 대신 평소에 `루팅` 하고 싶은 경우 유용합니다. 기본값인 `0`은 이 기능을 비활성화합니다. 예를 들어 봇이 매일 거래를 보내길 원한다면 여기에 `24`를 넣으십시오.

시간이 들어도 수동으로 확인하길 원한다면 필수사항은 아니지만, 보통 이 기능과 **[2단계 인증](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication-ko-KR)** 을 함께 사용하길 원합니다. 이 속성값을 어떻게 설정해야 할지 모르겠다면, 기본값인 `0`으로 두십시오.

---

### `ShutdownOnFarmingFinished`

`bool` 타입으로 기본값은 `false`입니다. ASF는 활성화된 모든 시간동안 계정을 "점유하고" 있습니다. 해당 계정의 농사가 끝났다면, ASF는 주기적으로 매 `IdleFarmingPeriod` 시간마다 Steam 카드가 있는 새로운 게임이 그 사이에 추가되었는지를 확인하여 프로세스를 재시작할 필요없이 농사를 계속할 수 있도록 합니다. 이는 대부분의 사람들에게 유용한데, ASF는 필요하면 자동으로 농사를 이어서할 수 있기 때문입니다. 하지만 해당 계정이 완전히 농사가 끝난 다음에 프로세스를 실제로 멈추고 싶다면, 이 속성값을 `true`로 설정함으로써 그렇게 할 수 있습니다. 활성화되면 ASF는 계정의 농사가 완전히 끝나면 로그오프하여 더이상 주기적으로 체크하거나 점유하지 않게 합니다. ASF가 모든 시간을 봇 인스턴스에 사용하도록 하거나, 혹은 농사 프로세스가 끝나면 멈추게 할지를 스스로 정해야 합니다. 모든 계정이 멈추고 프로세스가 `--process-required` **[모드](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-Line-Arguments-ko-KR)** 에서 실행중이 아니면, ASF 또한 종료되고 기기도 쉴 수 있게 되며, 마지막 카드 획득 순간에 대기모드나 종료 등 다른 작업을 할 수 있도록 합니다.

이 속성값을 어떻게 설정해야 할지 모르겠다면, 기본값인 `false`로 두십시오.

---

### `SkipRefundableGames`

`bool` 타입으로 기본값은 `false`입니다. This property defines if ASF is permitted to farm games that are still refundable. 환불 가능한 게임은 **[Steam 환불](https://store.steampowered.com/steam_refunds)** 페이지에 게시된 것 처럼 Steam 상점에서 구매한지 2주 이내이고 2시간을 넘지않게 플레이한 게임입니다. By default when this option is set to `false`, ASF ignores Steam refunds policy entirely and farms everything, as most people would expect. However, you can change this option to `true` if you want to ensure that ASF won't farm any of your refundable games too soon, allowing you to evaluate those games yourself and refund if needed without worrying about ASF affecting playtime negatively. Please note that if you enable this option then games you purchased from Steam Store won't be farmed by ASF for up to 14 days since redeem date, which will show as nothing to farm if your account doesn't own anything else. 이 기능을 사용할지 아닐지 불확실하다면 기본값인 `false`를 유지하십시오.

---

### `SteamLogin`

`string` 타입으로 기본값은 `null`입니다. 이 속성값은 당신이 Steam에 로그인할때 사용하는 Steam 로그인 아이디를 정의합니다. In addition to defining steam login here, you may also keep default value of `null` if you want to enter your steam login on each ASF startup instead of putting it in the config. This may be useful for you if you don't want to save sensitive data in config file.

---

### `SteamMasterClanID`

`ulong` 타입으로 기본값은 `0`입니다. 이 속성값은 봇이 자동으로 가입해야 하는 Steam 그룹 또는 그룹대화의 steamID를 정의합니다. 그룹의 SteamID는 **[여기](https://steamcommunity.com/groups/archiasf)** 로 이동해서 `/memberslistxml?xml=1` 을 링크의 마지막에 추가합니다. 그러면 **[이런](https://steamcommunity.com/groups/archiasf/memberslistxml?xml=1)** 모양이 됩니다. 그러면 결과의 `<groupID64>` 태그에서 그룹의 SteamID를 얻을 수 있습니다. 위의 예시에서는 `103582791440160998` 입니다. 봇은 시작시에 해당 그룹에 가입을 시도하고, 또한 이 그룹의 그룹 초대를 자동으로 수락하여 이 그룹이 비공개인 경우 수동으로 봇을 초대할 수 있게 합니다. 봇을 위한 그룹이 없다면 이 속성값을 기본값인 `0`으로 유지하십시오.

---

### `SteamParentalCode`

`string` 타입으로 기본값은 `null`입니다. This property defines your steam parental PIN. ASF requires an access to resources protected by steam parental, therefore if you use that feature, you should provide ASF with parental unlock PIN, so it can operate normally. Default value of `null` means that there is no steam parental PIN required to unlock this account, and this is probably what you want if you don't use steam parental functionality.

In limited circumstances, ASF is also able to generate a valid Steam parental code itself, although that requires excessive amount of OS resources and additional time to complete, not to mention that it's not guaranteed to succeed, therefore we recommend to not rely on that feature and instead put valid `SteamParentalCode` in the config for ASF to use. If ASF determines that PIN is required, and it'll be unable to generate one on its own, it'll ask you for input.

---

### `스팀 암호(SteamPassword)`

`string` 타입으로 기본값은 `null`입니다. 이 속성값은 당신이 Steam에 로그인할때 사용하는 Steam 암호를 정의합니다. In addition to defining steam password here, you may also keep default value of `null` if you want to enter your steam password on each ASF startup instead of putting it in the config. This may be useful for you if you don't want to save sensitive data in config file.

---

### `SteamTradeToken`

`string` 타입으로 기본값은 `null`입니다. 친구 목록에 당신의 봇이 있다면, 거래 토큰을 걱정하지 않고 당신에게 즉시 거래를 보낼 수 있습니다. 따라서 이 속성값을 기본값인 `null`로 유지할 수 있습니다. 하지만 친구 목록에 당신의 봇이 없다면 이 봇이 거래를 보낼 사용자의 거래 토큰을 생성하고 채워줘야 합니다. 즉, 이 속성값은 **이** 봇 인스턴스의 `SteamUserPermissions`이 `주인(Master)` 권한으로 정의된 계정의 거래 토큰으로 채워져야 합니다.

토큰을 채우기 위해서는 `주인(Master)` 권한을 가진 사용자로 로그인해서, **[여기](https://steamcommunity.com/my/tradeoffers/privacy)** 를 방문해서 거래 URL을 확인하십시오. 우리가 찾는 토큰은 당신의 거래 URL의 `&token=` 뒤의 8자리 문자입니다. 그 8자리 문자를 복사해서 여기 `SteamTradeToken`에 넣으십시오. 전체 거래 URL이나 `&token=` 부분을 포함하지 말고 오직 토큰(8자리)만 넣으십시오.

---

### `SteamUserPermissions`

`ImmutableDictionary<ulong, byte>` 타입으로 기본값은 비어있습니다. 이 속성값은 64비트 Steam ID로 인식되는 Steam 사용자와 ASF 인스턴스에서의 권한을 특정하는 `byte` 숫자로 매칭되는 사전 속성값입니다. ASF에서 현재 가능한 봇 권한은 다음과 같습니다.

| 값 | 이름                   | 설명                                                                                                                                                                         |
| - | -------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| 0 | 없음(None)             | No special permission, this is mainly a reference value that is assigned to steam IDs missing in this dictionary - there is no need to define anybody with this permission |
| 1 | 가족 공유(FamilySharing) | 가족 공유 사용자에 대한 최소한의 접근만 제공합니다. 이 또한 참조용 값입니다. ASF는 라이브러리를 허용한 Steam ID를 자동으로 발견할 수 있습니다.                                                                                    |
| 2 | 운영자(Operator)        | 주로 라이선스 추가와 키 등록과 같은 봇 인스턴스에 대한 기본적인 권한을 제공합니다.                                                                                                                            |
| 3 | 주인(Master)           | 봇 인스턴스에 대한 전체 권한을 제공합니다.                                                                                                                                                   |

간단하게 말하면 주어진 사용자에 대해 권한을 부여하는 속성값입니다. 권한은 ASF **[명령어](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-ko-KR)** 에 접근할 때 중요하지만, 거래를 수락하는 것 같은 많은 ASF 기능을 활성화하는데도 중요합니다. For example you may want to set your own account as `Master`, and give `Operator` access to 2-3 of your friends so they can easily redeem keys for your bot with ASF, while **not** being eligible e.g. for stopping it. 사용자에게 권한을 쉽게 줄수 있으므로 당신의 봇을 특정행동을 하도록 허용할 수 있습니다.

정확히 한 사용자만을 `주인(Master)`으로, 그리고 필요한 만큼을 `운영자(Operator)` 및 그 이하로 설정하기를 권장합니다. 기술적으로 여러명의 `주인(Master)` 을 설정해도 ASF는 봇에게 들어오는 모든 거래를 수락하는 등 정상적으로 동작합니다. `loot` 요청이나 `SendOnFarmingFinished`, `SendTradePeriod` 속성값처럼 단일 대상이 필요한 모든 행동의 경우 ASF는 Steam ID 숫자가 가장 작은 사용자를 그 대상으로 합니다. If you perfectly understand those limitations, especially the fact that `loot` request will always send items to the `Master` with lowest steam ID, regardless of the `Master` that actually executed the command, then you can define multiple users with `Master` permission here, but we still recommend a single master scheme.

`소유자(Owner)` 권한이 또 하나 있습니다. 일반 환경설정의 `SteamOwnerID` 속성값에 선언되어 있습니다. `SteamUserPermissions` 속성값은 ASF 프로세스가 아니라 봇 인스턴스와 관련된 권한만 정의하므로 `소유자(Owner)` 권한을 여기에서 할당할 수 없습니다. 봇과 관련된 작업에서 `SteamOwnerID`는 `주인(Master)`과 동일하게 취급되므로 여기에서 `SteamOwnerID`를 설정하는 것은 꼭 필요하지는 않습니다.

---

### `TradeCheckPeriod`

`byte` 타입으로 기본값은 `60`입니다. Normally ASF handles incoming trade offers right after receiving notification about one, but sometimes because of Steam glitches it can't do it at that time, and such trade offers remain ignored until next trade notification or bot restart occurs, which may lead to trades being cancelled or items not available at that later time. If this parameter is set to a non-zero value, ASF will additionally check for such outstanding trades every `TradeCheckPeriod` minutes. Default value is selected with balance between additional requests to steam servers and losing incoming trades in mind. However, if you are just using ASF to farm cards, and don't plan to automatically process any incoming trades, you may set it to `0` to disable this feature completely. On the other hand, if your bot participates in public [ASF's STM listing](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#publiclisting) or provides other automated services as a trade bot, you may want to decrease this parameter to `15` minutes or so, to process all trades in a timely manner.

---

### `TradingPreferences`

`byte flags` 타입으로 기본값은 `0`입니다. 이 속성값은 거래에서 ASF 봇의 행동을 아래와 같이 정의합니다.

| 값  | 이름                           | 설명                                                                                                                                                                                                    |
| -- | ---------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| 0  | 없음(None)                     | No special trading preferences, default                                                                                                                                                               |
| 1  | 기부 수락(AcceptDonations)       | 잃는 것이 없다면 거래를 수락합니다.                                                                                                                                                                                  |
| 2  | SteamTradeMatcher            | **[STM](https://www.steamtradematcher.com)** 과 같은 거래에 수동적으로 참여합니다. 자세한 사항은 **[거래](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading-ko-KR#steamtradematcher)** 를 참고하십시오.                    |
| 4  | 전부 매칭(MatchEverything)       | `SteamTradeMatcher` 가 설정되어 있어야 합니다. 좋음, 중립, 나쁨 거래를 수락합니다.                                                                                                                                             |
| 8  | 봇거래수락안함(DontAcceptBotTrades) | 다른 봇의 `loot` 거래를 자동으로 수락하지 않습니다.                                                                                                                                                                      |
| 16 | 능동적 매칭(MatchActively)        | **[STM](https://www.steamtradematcher.com)** 과 같은 거래에 능동적으로 참여합니다. Visit **[ItemsMatcherPlugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#matchactively)** for more info |

이 속성값은 `flags` 항목이므로, 가능한 여러 값을 조합할 수 있습니다. Check out **[json mapping](#json-mapping)** if you'd like to learn more. 플래그를 활성화 하지 않으면 `없음(None)`과 같습니다.

ASF의 거래 논리, 가능한 모든 플래그의 설명 등에 대한 자세한 내용은 **[거래](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading-ko-KR)** 항목에서 확인할 수 있습니다.

---

### `TransferableTypes`

`ImmutableHashSet<byte>` 타입으로 기본값은 `1, 3, 5` Steam 아이템 타입입니다. This property defines which Steam item types will be considered for transfering between bots, during `transfer` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. ASF는 `TransferableTypes`에 있는 아이템만 거래 제안에 포함할 것이므로, 이 속성값은 당신의 봇 중 하나에게 보내진 거래 제안에서 무엇을 받을지 결정할 수 있게 해줍니다.

| 값  | 이름                          | 설명                                           |
| -- | --------------------------- | -------------------------------------------- |
| 0  | 알 수 없음(Unknown)             | 아래의 어느것에도 해당하지 않는 모든 타입                      |
| 1  | 부스터 팩(BoosterPack)          | 한 게임의 무작위 카드 3장이 들어있는 부스터 팩                  |
| 2  | 이모티콘(Emoticon)              | Steam 대화에서 사용하는 이모티콘                         |
| 3  | 은박 트레이딩 카드(FoilTradingCard) | `트레이딩 카드(TradingCard)`의 은박 버전                |
| 4  | 프로필 배경(ProfileBackground)   | Steam 프로필에서 사용하는 프로필 배경                      |
| 5  | 트레이딩 카드(TradingCard)        | Steam 트레이딩 카드. 배지 제작에 사용. 은박 아님              |
| 6  | Steam 보석(SteamGems)         | 부스터 팩 제작에 사용되는 Steam 보석. 보석 더미 포함            |
| 7  | 판매 아이템(SaleItem)            | Steam 할인기간동안 획득하는 특별한 아이템                    |
| 8  | 소모품(Consumable)             | 사용하면 사라지는 특별한 소모 아이템                         |
| 9  | 프로필 수정(ProfileModifier)     | Steam 프로필 모양을 수정할 수 있는 특별한 아이템               |
| 10 | Sticker                     | Special items that can be used on Steam chat |
| 11 | ChatEffect                  | Special items that can be used on Steam chat |
| 12 | MiniProfileBackground       | Special background for Steam profile         |
| 13 | AvatarProfileFrame          | Special avatar frame for Steam profile       |
| 14 | AnimatedAvatar              | Special animated avatar for Steam profile    |
| 15 | KeyboardSkin                | Special keyboard skin for Steam deck         |
| 16 | StartupVideo                | Special startup video for Steam deck         |

위의 설정과 상관없이 ASF는 Steam(`appID` 753) 커뮤니티(`contextID` 6) 아이템만을 요청할 것입니다. 모든 게임 아이템, 선물 등등은 정의에 따라 거래 제안에서 제외됩니다.

Default ASF setting is based on the most common usage of the bot, with transfering only booster packs, and trading cards (including foils). 여기 정의된 속성값은 당신을 만족시킬수 있도록 어떻게든 행동을 변경할 수 있게 합니다. 위에 정의되지 않은 모든 타입은 `알 수 없음(Unknown)` 타입으로 표시됨을 명심하십시오. Valve가 새로운 Steam 아이템을 내놓았을때 특히 중요한데, 향후 릴리스에서 여기에 추가되기 전까지는 ASF에서 `알 수 없음(Unknown)` 으로 표시될 것입니다. 이것이 당신이 무엇을 하고 있는지를 알고 있고, 만약 Steam 네트워크가 깨져서 모든 아이템을 `알 수 없음(Unknown)`으로 표시한다면 ASF는 전체 보관함을 거래 제안으로 보낼것이라는 점도 이해하고 있지않는 한, 일반적으로 `알 수 없음(Unknown)` 타입을 `TransferableTypes`에 포함시키는 것을 권장하지 않는 이유입니다. 모든 것을 전송하고 싶더라도 `알 수 없음(Unknown)` 타입을 `TransferableTypes`에 포함하지 않는 것을 강력하게 권장합니다.

---

### `UseLoginKeys`

`bool` 타입으로 기본값은 `true`입니다. This property defines if ASF should use login keys mechanism for this Steam account. Login keys mechanism works very similar to official Steam client's "remember me" option, which makes it possible for ASF to store and use temporary one-time use login key for next logon attempt, effectively skipping a need of providing password, Steam Guard or 2FA code as long as our login key is valid. Login key is stored in `BotName.db` file and updated automatically. This is why you don't need to provide password/SteamGuard/2FA code after logging in successfully with ASF just once.

Login keys are used by default for your convenience, so you don't need to input `SteamPassword`, SteamGuard or 2FA code (when not using **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)**) on each login. It's also superior alternative since login key can be used only for a single time and does not reveal your original password in any way. Exactly the same method is being used by your original Steam client, which saves your account name and login key for your next logon attempt, effectively being the same as using `SteamLogin` with `UseLoginKeys` and empty `SteamPassword` in ASF.

However, some people could be concerned even about this little detail, therefore this option is available here for you if you'd like to ensure that ASF won't store any kind of token that would allow resuming previous session after being closed, which will result in full authentication being mandatory on each login attempt. Disabling this option will work exactly the same as not checking "remember me" in official Steam client. Unless you know what you're doing, you should keep it with default value of `true`.

---

### `UserInterfaceMode`

`byte` 타입으로 기본값은 `0`입니다. This property specifies user interface mode that the bot will be announced with after logging in to Steam network. Currently you can choose one of below modes:

| 값   | 이름         |
| --- | ---------- |
| `0` | Default    |
| `1` | BigPicture |
| `2` | Mobile     |

이 속성값을 어떻게 설정해야 할지 모르겠다면, 기본값인 `0`으로 두십시오.

---

## 파일 구조

ASF는 꽤 간단한 파일구조를 사용합니다.

```text
├── config
│     ├── ASF.json
│     ├── ASF.db
│     ├── Bot1.json
│     ├── Bot1.db
│     ├── Bot1.bin
│     ├── Bot2.json
│     ├── Bot2.db
│     ├── Bot2.bin
│     └── ...
├── ArchiSteamFarm.dll
├── log.txt
└── ...
```

ASF를 다른 PC 등 새로운 위치로 옮기려면 `config` 디렉토리 하나만을 이동/복사하는 것으로 충분합니다. 그리고 이것이 "ASF 백업"으로 권장되는 방법입니다. 잘못된 백업 등으로 ASF 내부파일을 오염시킬 위험을 감수하지 않고 프로그램 등 다른 부분은 GitHub에서 항상 다운받을 수 있기 때문입니다.

`log.txt` 파일은 마지막 ASF 실행으로 생성된 로그를 담고 있습니다. 이 파일은 어떠한 민감한 정보도 포함하고 있지 않으며, 이슈나 충돌, 혹은 지난번 ASF 실행에서 무슨일이 있었는지 정보로써도 굉장히 가치가 있습니다. 이슈나 버그가 발생하면 우리는 이 파일을 자주 요청하게 될 것입니다. ASF는 이 파일을 자동으로 관리하지만, 고급 사용자라면 ASF **[로그](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Logging-ko-KR)** 모듈을 더 깊이 조절할 수 있습니다.

`config` 디렉토리는 ASF와 모든 봇의 환경설정을 담고있는 곳입니다.

`ASF.json`은 ASF의 일반 환경설정 파일입니다. 이 환경설정은 모든 봇과 프로그램 자체에 영향을 주는 ASF 프로세스 행동을 특정하는데 사용됩니다. ASF 프로세스 소유자, 자동업데이트, 디버깅 등 일반 속성값이 있습니다.

`봇이름.json`은 봇 인스턴스의 환경설정입니다. 이 환경설정은 봇 인스턴스가 어떻게 행동할지를 특정하는데 사용됩니다. 따라서 설정은 그 봇에만 특정되고 다른 봇에 공유되지 않습니다. 이렇게 해서 여러 봇을 다양하고 다르게 설정할 수 있으며 정확하게 동일하게 동작하도록 할 필요가 없습니다. 모든 봇은 유일한 식별자를 이름으로 사용해야 합니다. 이는 `봇이름`에 들어갑니다.

환경설정 파일과 별도로 ASF는 `config` 디렉토리를 데이터베이스를 저장하는데도 사용합니다.

`ASF.db`는 일반 ASF 데이터베이스 파일입니다. 일반 영구 저장소 역할을 하며 Steam 서버의 IP 등 ASF 프로세스와 관련된 다양한 정보를 저장하는데 사용됩니다. **이 파일을 수정해서는 안됩니다**.

`봇이름.db`는 봇 인스턴스의 데이터베이스입니다. 이 파일은 봇 인스턴스와 관련된 로그인 키나 ASF 2단계 인증과 같은 영구 저장소의 중요한 데이터를 저장하는데 사용됩니다. **이 파일을 수정해서는 안됩니다**.

`봇이름.bin`은 Steam 센트리 해시 정보를 담고 있는 특별한 파일입니다. 센트리 해시는 Steam의 `ssfn`파일과 매우 유사하게 `SteamGuard` 메커니즘을 사용하여 인증하는데 사용됩니다. **이 파일을 수정해서는 안됩니다**.

`봇이름.keys`는 **[백그라운드 게임 등록기](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer-ko-KR)** 에서 불러올 키를 저장하는 특별한 파일입니다. 이 파일은 필수사항도 아니고 생성되지도 않지만 ASF가 인식은 합니다. 이 파일은 키를 성공적으로 불러온 다음 자동으로 삭제됩니다.

`봇이름.maFile`은 **[ASF 2단계 인증](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication-ko-KR)** 을 불러오는데 사용하는 특별한 파일입니다. 이 파일은 필수사항도 아니고 생성되지도 안지만 `봇이름`이 ASF 2단계 인증을 사용하지 않는경우 ASF가 인식합니다. 이 파일은 ASF 2단계 인증을 성공적으로 불러온 다음 자동으로 삭제됩니다.

---

## JSON 매핑

모든 환경설정 속성값은 타입이 있습니다. 속성값의 타입은 유효한 값을 정의합니다. 주어진 타입에 유효한 값만 사용할 수 있습니다. 유효하지 않은 값을 사용하면 ASF는 환경설정을 수행할 수 없습니다.

**환경설정을 생성하기 위해 ConfigGenerator를 사용하는 것을 강력하게 권장합니다**. 타입 유효성 검증 등의 로우 레벨 대부분을 다루므로 적절한 값을 넣기만 하면 되고, 아래에 명시된 변수 타입을 이해할 필요가 없습니다. 이 항목은 주로 수동으로 환경설정을 생성하거나 변경하는 사람을 위한 것으로, 이 사람들은 사용할 수 있는 값이 어떤 것인지 압니다.

ASF가 사용하는 타입은 네이티브 C# 타입으로, 아래에 설명되어 있습니다.

---

`bool` - `true`와 `false` 값만 받는 불린타입입니다.

예: `"Enabled": true`

---

`byte` - `0`부터 `255` 까지의 정수만 받는 Unsigned 바이트 타입입니다.

예: `"ConnectionTimeout": 90`

---

`ushort` - `0`부터 `65535` 까지의 정수만 받는 Unsigned short 타입입니다.

예: `"WebLimiterDelay": 300`

---

`uint` - `0`부터 `4294967295` 까지의 정수만 받는 Unsigned 정수 타입입니다.

---

`ulong` - `0`부터 `18446744073709551615` 까지의 정수만 받는 Unsigned long 정수 타입입니다.

예: `"SteamMasterClanID": 103582791440160998`

---

`string` - `""`의 빈 문자열과 `null` 값을 포함하는 어떠한 일련의 문자를 받는 문자열 타입입니다. Empty sequence and `null` value are treated the same by ASF, so it's up to your preference which one you want to use (we stick with `null`).

예: `"SteamLogin": null`, `"SteamLogin": ""`, `"SteamLogin": "MyAccountName"`

---

`Guid?` - Nullable UUID type, in JSON encoded as string. UUID is made out of 32 hexadecimal characters, in range from `0` to `9` and `a` to `f`. ASF accepts variety of valid formats - lowercase, uppercase, with and without dashes. In addition to valid UUID, since this property is nullable, a special value of `null` is accepted to indicate lack of UUID to provide.

Examples: `"LicenseID": null`, `"LicenseID": "f6a0529813f74d119982eb4fe43a9a24"`

---

`ImmutableList<valueType>` - Immutable collection (list) of values in given `valueType`. JSON에서는 주어진 `valueType`을 요소로 하는 배열의 형태로 정의됩니다. ASF uses `List` to indicate that given property supports multiple values and that their order might be relevant.

Example for `ImmutableList<byte>`: `"FarmingOrders": [15, 11, 7]`

---

`ImmutableHashSet<valueType>` - 주어진 `valueType`의 유일한 값의 불변 집합입니다. JSON에서는 주어진 `valueType`을 요소로 하는 배열의 형태로 정의됩니다. ASF uses `HashSet` to indicate that given property makes sense only for unique values and that their order doesn't matter, therefore it'll intentionally ignore any potential duplicates during parsing (if you happened to supply them anyway).

`ImmutableHashSet<uint>`의 예: `"Blacklist": [267420, 303700, 335590]`

---

`ImmutableDictionary<keyType, valueType>` - `keyType`에 특정된 유일한 키와 `valueType`에 특정된 값을 매핑하는 불변 사전입니다. JSON에서는 키-값 쌍으로 된 오브젝트로 정의됩니다. 이 경우 `keyType`는 심지어 `ulong`같은 타입이더라도 항상 따옴표로 표시함을 명심하십시오. There is also a strict requirement of the key being unique across the map, this time enforced by JSON as well.

`ImmutableDictionary<ulong, byte>`의 예: `"SteamUserPermissions": { "76561198174813138": 3, "76561198174813137": 1 }`

---

`flags` - 플래그는 여러 다른 속성값을 비트 연산을 통해 하나의 최종값으로 조합합니다. 이렇게 해서 동시에 허용된 여러 다른 값을 가능한 어느 조합이라도 선택할 수 있습니다. 최종값은 모든 활성화된 옵션 값의 합계로 만들어집니다.

예를 들어, 다음과 같은 값이 있습니다.

| 값 | 이름       |
| - | -------- |
| 0 | 없음(None) |
| 1 | A        |
| 2 | B        |
| 4 | C        |

`B + C`의 값은 `6`이 되고, `A + C`는 `5`, `C` 는 `4`가 됩니다. 이렇게 해서 활성화된 값의 가능한 어느 조합이라도 생성할 수 있습니다. 전부를 활성화하고 싶다면 `None + A + B + C`를 해서 `7`의 값을 얻습니다. `0`값을 갖는 플래그는 다른 모든 가능한 조합에서 활성화되므로, `None` 처럼 특별히 어떤것도 활성화되지 않는 플래그로 사용됩니다.

보다시피, 위의 예제에서 켜고 끌 수 있는 3개의 플래그 `A`, `B`, `C`가 있습니다. 가능한 값은 총 `8`개입니다.
- `None -> 0`
- `A -> 1`
- `B -> 2`
- `A + B -> 3`
- `C -> 4`
- `A + C -> 5`
- `B + C -> 6`
- `A + B + C -> 7`

Example: `"SteamProtocols": 7`

---

## 호환성 매핑

Due to JavaScript limitations of being unable to properly serialize simple `ulong` fields in JSON when using web-based ConfigGenerator, `ulong` fields will be rendered as strings with `s_` prefix in the resulting config. This includes for example `"SteamOwnerID": 76561198006963719` that will be written by our ConfigGenerator as `"s_SteamOwnerID": "76561198006963719"`. ASF는 이 문자열 매핑을 자동으로 처리할 수 있는 적절한 논리구조를 가지고 있으며, 환경설정의 `s_` 항목은 실제로 유효하고 정확하게 생성된 것입니다. 만약 환경설정을 스스로 생성한다면, 가능하면 원래의 `ulong` 항목을 사용하기를 권장하지만 그럴수 없다면 이름에 `s_` 접두사를 붙여서 문자열로 인코딩하는 방식을 사용할 수도 있습니다. 이 자바 스크립트 한계가 해결되기를 바랍니다.

---

## 환경설정 호환성

It's top priority for ASF to remain compatible with older configs. As you should already know, missing config properties are treated the same as they would be defined with their **default values**. 따라서 새 환경설정 속성값이 ASF 새버전에 도입되면, 당신의 모든 환경설정은 새 버전과 **호환됩니다**. ASF는 새로운 환경설정 속성값을 **기본값**으로 정의된 것으로 처리합니다. 언제나 필요에 따라 환경설정 속성값을 추가하고, 제거하고, 변경할 수 있습니다.

정의된 환경설정 속성값을 변경하기를 원하는 것으로만 제한하는 것을 권장합니다. 이렇게 해서 자동으로 다른 모든 속성값을 기본값으로 상속받을 수 있고, 환경설정을 깨끗하게 유지하고 당신이 스스로 명시적으로 설정하고 싶지 않은 속성값을 우리가 기본값으로 변경하길 원하는 경우에 호환성을 증가시킬 수 있습니다(예: `WebLimiterDelay`).

Due to above, ASF will automatically migrate/optimize your configs by reformatting them and removing fields that hold default value. You can disable this behaviour with `--no-config-migrate` **[command-line argument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments#arguments)** if you have a specific reason, for example you're providing read-only config files and you don't want ASF to modify them.

---

## 자동 재시작

ASF V2.1.6.2 이상 버전부터 실행중간의 환경설정 수정을 감지할 수 있습니다. 이에 따라 ASF는 자동적으로 아래와 같은 행동을 합니다.
- 새로운 봇 환경설정을 만드는 경우 그 봇 인스턴스의 생성 및 시작(필요한 경우)
- 예전 봇 환경설정을 삭제하는 경우 그 봇 인스턴스의 중지(필요한 경우) 및 제거
- 봇 환경설정을 수정하는 경우 그 봇 인스턴스의 중지 및 시작(필요한 경우)
- 봇 환경설정 이름을 변경하는 경우 새 이름으로 봇 재시작(필요한 경우)

위의 모든 것은 투명하고 프로그램의 재시작이나 다른 영향이 없는 봇 인스턴스의 중지 없이 자동으로 수행됩니다.

In addition to that, ASF will also restart itself (if `AutoRestart` permits) if you modify core ASF `ASF.json` config. Likewise, program will quit if you delete or rename it.

You can disable this behaviour with `--no-config-watch` **[command-line argument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments#arguments)** if you have a specific reason, for example you don't want from ASF to react to file changes in `config` folder.