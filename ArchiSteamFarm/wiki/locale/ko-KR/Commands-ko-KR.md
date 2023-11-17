# 명령어

ASF는 프로세스와 봇 인스턴스의 행동을 제어하는데 사용되는 다양한 명령어를 지원합니다.

아래의 명령어들은 다양한 방법으로 봇에게 보내질 수 있습니다.
- 대화형 ASF 콘솔을 통해
- Steam 개인/그룹 채팅을 통해
- **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-ko-KR)** 인터페이스를 통해

ASF와의 상호 작용은 당신으로부터 ASF의 권한에 따라서 명령을 내릴 자격을 요구한다는 점을 명심하시기 바랍니다. 자세한 내용은 `SteamUserPermissions`과 `SteamOwnerID` 설정 속성들을 확인하시기 바랍니다.

Steam 채팅으로 실행된 명령어들은 기본값으로 `!`으로 지정된 `CommandPrefix` **[일반 환경설정 속성값](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-ko-KR#commandprefix)** 의 영향을 받습니다. 이것은 예를 들어 `status` 명령어를 실행하는 경우에, 실제로 `!status` (또는 선택에 따라서 대신 지정된 `CommandPrefix`)를 입력해야 한다는 것을 의미합니다. `CommandPrefix`는 콘솔이나 IPC를 사용할 때는 필수가 아니며 생략가능합니다.

---

### 대화형 콘솔

Starting with V4.0.0.9, ASF has support for interactive console, as long as you're not running ASF in [**`Headless`**](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#headless) mode. Simply press `c` button in order to enable command mode, type your command and confirm with enter.

![스크린샷](https://i.imgur.com/bH5Gtjq.png)

---

### 스팀 채팅

Steam 채팅을 통해서도 해당 ASF 봇에 명령을 실행할 수 있습니다. 당연히 자기 자신에게 직접 이야기할수는 없으므로 주계정을 대상으로 명령을 실행하려면 적어도 하나 이상의 다른 봇계정이 필요합니다.

![스크린샷](https://i.imgur.com/IvFRJ5S.png)

비슷한 방식으로 스팀 그룹의 그룹 채팅을 사용할 수도 있습니다. 이 옵션은 `SteamMasterClanID` 속성이 적절하게 설정되어야 한다는 점을 명심하시기 바랍니다. 이 경우에 봇은 그룹 채팅에서도 명령어들을 기다릴 것입니다. (그리고 필요한 경우에 그룹 채팅에 합류합니다.) 이것은 개인 채팅과는 반대로 전용 봇 계정을 필요로 하지 않기 때문에, "자기 자신에게 말하기"로도 사용될 수 있습니다. You can simply set `SteamMasterClanID` property to your newly-created group, then give yourself access either through `SteamOwnerID` or `SteamUserPermissions` of your own bot. This way ASF bot (you) will join group and chat of your selected group, and listen to commands from your own account. You can join the same group chatroom in order to issue commands to yourself (as you'll be sending command to chatroom, and ASF instance sitting on the same chatroom will receive them, even if it shows only as your account being there).

Please note that sending a command to the group chat acts like a relay. If you're saying `redeem X` to 3 of your bots sitting together with you on the group chat, it'll result in the same as you'd say `redeem X` to every single one of them privately. In most cases **this is not what you want**, and instead you should use `given bot` command that is being sent to **a single bot in private window**. ASF supports group chat, as in many cases it can be useful source for communication with your only bot, but you should almost never execute any command on the group chat if there are 2 or more ASF bots sitting there, unless you fully understand ASF behaviour written here and you in fact want to relay the same command to every single bot that is listening to you.

*And even in this case you should use private chat with `[Bots]` syntax instead.*

---

### IPC

사용자 상호 작용(ASF-ui) 및 서드-파티 도구 또는 스크립팅(ASF API) 에 대해서 가장 적합한 명령어들을 실행하는 가장 진보적이고 유연한 방법은 ASF가 `IPC` 모드로 실행하는 것을 요구하고 클라이언트는 **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-ko-KR)** 인터페이스를 통해서 명령을 실행합니다.

![스크린샷](https://raw.githubusercontent.com/JustArchiNET/ASF-ui/main/.github/previews/commands.png)

---

## 명령어

| 명령어                                                                  | 접근권한                   | 설명                                                                                                                                                                                                                                                                                                                                  |
| -------------------------------------------------------------------- | ---------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `2fa [Bots]`                                                         | `주인(Master)`           | 해당 봇 인스턴스에 대한 임시 **[2단계 인증](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication-ko-KR)** 토큰을 생성합니다.                                                                                                                                                                                                       |
| `2fafinalize [Bots] <ActivationCode>`                          | `주인(Master)`           | Finalizes process of assigning new **[2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication#creation)** credentials for given bot instances, using SMS activation code.                                                                                                                                |
| `2fafinalized [Bots] <ActivationCode>`                         | `주인(Master)`           | Imports already-finalized **[2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication#creation)** credentials for given bot instances, using 2FA token for verification.                                                                                                                                  |
| `2fafinalizedforce [Bots]`                                           | `주인(Master)`           | Imports already-finalized **[2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication#creation)** credentials for given bot instances, skipping 2FA token verification.                                                                                                                                   |
| `2fainit [Bots]`                                                     | `주인(Master)`           | Starts process of assigning new **[2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication#creation)** credentials for given bot instances.                                                                                                                                                              |
| `2fano [Bots]`                                                       | `주인(Master)`           | 해당 봇 인스턴스에 대해 대기중인 모든 **[2단계 인증](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication-ko-KR)** 확인을 거부합니다.                                                                                                                                                                                                  |
| `2faok [Bots]`                                                       | `주인(Master)`           | 해당 봇 인스턴스에 대해 대기중인 모든 **[2단계 인증](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication-ko-KR)** 확인을 승인합니다.                                                                                                                                                                                                  |
| `addlicense [Bots] <Licenses>`                                 | `운영자(Operator)`        | Activates given `licenses`, explained **[below](#addlicense-licenses)**, on given bot instances (free games only).                                                                                                                                                                                                                  |
| `balance [Bots]`                                                     | `주인(Master)`           | 해당 봇 인스턴스의 지갑 잔고를 보여줍니다.                                                                                                                                                                                                                                                                                                            |
| `bgr [Bots]`                                                         | `마스터`                  | 해당 봇 인스턴스의 **[백그라운드 게임 등록기](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer-ko-KR)** 큐 정보를 표시합니다.                                                                                                                                                                                                     |
| `encrypt <encryptionMethod> <stringToEncrypt>`           | `소유자(Owner)`           | Encrypts the string using provided cryptographic method - further explained **[below](#encrypt-command)**.                                                                                                                                                                                                                          |
| `exit`                                                               | `소유자(Owner)`           | 모든 ASF 프로세스를 중지합니다.                                                                                                                                                                                                                                                                                                                 |
| `farm [Bots]`                                                        | `마스터`                  | 해당 봇 인스턴스들의 카드 농사 모듈을 재시작합니다.                                                                                                                                                                                                                                                                                                       |
| `fb [Bots]`                                                          | `마스터`                  | Lists apps blacklisted from automatic farming of given bot instances.                                                                                                                                                                                                                                                               |
| `fbadd [Bots] <AppIDs>`                                        | `마스터`                  | Adds given `appIDs` to apps blacklisted from automatic farming of given bot instances.                                                                                                                                                                                                                                              |
| `fbrm [Bots] <AppIDs>`                                         | `마스터`                  | Removes given `appIDs` from apps blacklisted from automatic farming of given bot instances.                                                                                                                                                                                                                                         |
| `fq [Bots]`                                                          | `마스터`                  | Lists priority farming queue of given bot instances.                                                                                                                                                                                                                                                                                |
| `fqadd [Bots] <AppIDs>`                                        | `마스터`                  | Adds given `appIDs` to priority farming queue of given bot instances.                                                                                                                                                                                                                                                               |
| `fqrm [Bots] <AppIDs>`                                         | `마스터`                  | Removes given `appIDs` from farming queue of given bot instances.                                                                                                                                                                                                                                                                   |
| `hash <hashingMethod> <stringToHash>`                    | `소유자(Owner)`           | Generated a hash of the string using provided cryptographic method - further explained **[below](#hash-command)**.                                                                                                                                                                                                                  |
| `help`                                                               | `가족 공유(FamilySharing)` | 도움말을 보여줍니다 (이 페이지로 연결).                                                                                                                                                                                                                                                                                                             |
| `input [Bots] <Type> <Value>`                            | `마스터`                  | 해당 봇 인스턴스들의 지정된 입력 형식을 주어진 값으로 설정하며, `Headless` 모드에서만 동작합니다 - 추가 설명은 **[아래](#input-command)**.                                                                                                                                                                                                                                      |
| `level [Bots]`                                                       | `마스터`                  | 봇 인스턴스들의 스팀 계정 레벨을 보여줍니다.                                                                                                                                                                                                                                                                                                           |
| `loot [Bots]`                                                        | `주인(Master)`           | 해당 봇 인스턴스들의 모든 `LootableTypes`의 스팀 커뮤니티 아이템들을 `SteamUserPermissions`에서 사용자 설정한 `Master` (하나보다 많은 경우에는 가장 낮은 steamID) 에게 모두 전달합니다.                                                                                                                                                                                                   |
| `loot@ [Bots] <AppIDs>`                                        | `마스터`                  | Sends all `LootableTypes` Steam community items matching given `AppIDs` of given bot instances to `Master` user defined in their `SteamUserPermissions` (with lowest steamID if more than one). This is the opposite of `loot%`.                                                                                                    |
| `loot% [Bots] <AppIDs>`                                        | `주인(Master)`           | Sends all `LootableTypes` Steam community items apart from given `AppIDs` of given bot instances to `Master` user defined in their `SteamUserPermissions` (with lowest steamID if more than one). This is the opposite of `loot@`.                                                                                                  |
| `loot^ [Bots] <AppID> <ContextID>`                       | `주인(Master)`           | 해당 봇 인스턴스들의 지정된 `ContextID` 에 있는 주어진 `AppID`의 스팀 아이템들을 `SteamUserPermissions`에서 사용자 설정한 `Master` (하나보다 많은 경우에는 가장 낮은 steamID) 에게 모두 전달합니다.                                                                                                                                                                                          |
| `mab [Bots]`                                                         | `주인(Master)`           | Lists apps blacklisted from automatic trading in **[`MatchActively`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#matchactively)**.                                                                                                                                                                       |
| `mabadd [Bots] <AppIDs>`                                       | `마스터`                  | Adds given `appIDs` to apps blacklisted from automatic trading in **[`MatchActively`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#matchactively)**.                                                                                                                                                      |
| `mabrm [Bots] <AppIDs>`                                        | `마스터`                  | Removes given `appIDs` from apps blacklisted from automatic trading in **[`MatchActively`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#matchactively)**.                                                                                                                                                 |
| `match [Bots]`                                                       | `주인(Master)`           | Special command for **[`ItemsMatcherPlugin`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#matchactively)** which triggers `MatchActively` routine immediately.                                                                                                                                            |
| `nickname [Bots] <Nickname>`                                   | `주인(Master)`           | 해당 봇 인스턴스들의 스팀 닉네임을 주어진 `nickname`으로 변경합니다.                                                                                                                                                                                                                                                                                         |
| `owns [Bots] <Games>`                                          | `운영자`                  | Checks if given bot instances already own given `games`, explained **[below](#owns-games)**.                                                                                                                                                                                                                                        |
| `pause [Bots]`                                                       | `운영자(Operator)`        | 해당 봇 인스턴스들의 자동 카드 농사 모듈을 영구적으로 정지합니다. 수동으로 `resume` 하거나 프로세스를 재시작하기 전까지 ASF는 이 세션에서 해당 계정의 농사를 시도하지 않을 것입니다.                                                                                                                                                                                                                        |
| `pause~ [Bots]`                                                      | `가족 공유`                | 해당 봇 인스턴스들의 자동 카드 농사 모듈을 일시 정지합니다. 농사는 다음 실행 이벤트 또는 봇 연결 해제시에 자동으로 재개됩니다. 일시 정지를 해제하기 위해서 `resume` 할 수 있습니다.                                                                                                                                                                                                                        |
| `pause& [Bots] <Seconds>`                                  | `운영자(Operator)`        | 당 봇 인스턴스들의 자동 카드 농사 모듈을 주어진 `seconds`의 기간 동안 일시 정지합니다. 지연 시간이 지나고, 카드 농사 모듈이 자동으로 재개됩니다.                                                                                                                                                                                                                                            |
| `play [Bots] <AppIDs,GameName>`                                | `주인(Master)`           | Switches to manual farming - launches given `AppIDs` on given bot instances, optionally also with custom `GameName`. In order for this feature to work properly, your Steam account **must** own a valid license to all the `AppIDs` that you specify here, this includes F2P games as well. Use `reset` or `resume` for returning. |
| `points [Bots]`                                                      | `주인(Master)`           | Displays number of points in **[Steam points shop](https://store.steampowered.com/points/shop)**.                                                                                                                                                                                                                                   |
| `privacy [Bots] <Settings>`                                    | `주인(Master)`           | Changes **[Steam privacy settings](https://steamcommunity.com/my/edit/settings)** of given bot instances, to appropriately selected options explained **[below](#privacy-settings)**.                                                                                                                                               |
| `redeem [Bots] <Keys>`                                         | `운영자(Operator)`        | Redeems given cd-keys or wallet codes on given bot instances.                                                                                                                                                                                                                                                                       |
| `redeem^ [Bots] <Modes> <Keys>`                          | `운영자(Operator)`        | Redeems given cd-keys or wallet codes on given bot instances, using given `modes` explained **[below](#redeem-modes)**.                                                                                                                                                                                                             |
| `reset [Bots]`                                                       | `주인(Master)`           | Resets the playing status back to original (previous) state, the command is used during manual farming with `play` command.                                                                                                                                                                                                         |
| `restart`                                                            | `소유자(Owner)`           | ASF 프로세스를 재시작합니다.                                                                                                                                                                                                                                                                                                                   |
| `resume [Bots]`                                                      | `가족 공유(FamilySharing)` | 해당 봇 인스턴스들의 자동 농사를 재개합니다.                                                                                                                                                                                                                                                                                                           |
| `start [Bots]`                                                       | `주인(Master)`           | 해당 봇 인스턴스들을 시작합니다.                                                                                                                                                                                                                                                                                                                  |
| `stats`                                                              | `소유자(Owner)`           | 관리되는 메모리 사용량과 같은 프로세스 통계를 출력합니다.                                                                                                                                                                                                                                                                                                    |
| `status [Bots]`                                                      | `가족 공유(FamilySharing)` | 해당 봇 인스턴스들의 상태를 출력합니다.                                                                                                                                                                                                                                                                                                              |
| `std`                                                                | `소유자(Owner)`           | Special command for **[`SteamTokenDumperPlugin`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/SteamTokenDumperPlugin)** which triggers submission of data immediately.                                                                                                                                                       |
| `stop [Bots]`                                                        | `주인(Master)`           | 해당 봇 인스턴스들을 중지합니다.                                                                                                                                                                                                                                                                                                                  |
| `tb [Bots]`                                                          | `주인(Master)`           | 해당 봇 인스턴스들의 거래 모듈에서 블랙리스트에 등록된 유저 목록을 보여줍니다.                                                                                                                                                                                                                                                                                        |
| `tbadd [Bots] <SteamIDs64>`                                    | `주인(Master)`           | 해당 봇 인스턴스들의 거래 모듈에서 해당 `steamIDs`를 블랙리스트에 등록합니다.                                                                                                                                                                                                                                                                                    |
| `tbrm [Bots] <SteamIDs64>`                                     | `주인(Master)`           | 헤당 봇 인스턴스들의 거래 모듈에서 주어진 `steamIDs`를 블랙리스트에서 제거합니다.                                                                                                                                                                                                                                                                                  |
| `transfer [Bots] <TargetBot>`                                  | `주인(Master)`           | Sends all `TransferableTypes` Steam community items from given bot instances to target bot instance.                                                                                                                                                                                                                                |
| `transfer@ [Bots] <AppIDs> <TargetBot>`                  | `주인(Master)`           | Sends all `TransferableTypes` Steam community items matching given `AppIDs` from given bot instances to target bot instance. This is the opposite of `transfer%`.                                                                                                                                                                   |
| `transfer% [Bots] <AppIDs> <TargetBot>`                  | `주인(Master)`           | Sends all `TransferableTypes` Steam community items apart from given `AppIDs` from given bot instances to target bot instance. This is the opposite of `transfer@`.                                                                                                                                                                 |
| `transfer^ [Bots] <AppID> <ContextID> <TargetBot>` | `주인(Master)`           | Sends all Steam items from given `AppID` in `ContextID` of given bot instances to target bot instance.                                                                                                                                                                                                                              |
| `unpack [Bots]`                                                      | `주인(Master)`           | 해당 봇 인스턴스들의 보관함에 있는 모든 부스터팩을 뜯습니다.                                                                                                                                                                                                                                                                                                  |
| `update [Channel]`                                                   | `소유자(Owner)`           | Checks GitHub for new ASF release and updates to it if available. This is normally done automatically every `UpdatePeriod`. Optional `Channel` argument specifies the `UpdateChannel`, if not provided defaults to the one set in global config.                                                                                    |
| `version`                                                            | `가족 공유(FamilySharing)` | ASF의 버전을 출력합니다.                                                                                                                                                                                                                                                                                                                     |

---

### 주의

모든 명령어들은 대소문자 구별이 없지만, 그것들의 요소들(예를 들어 봇 이름들) 은 일반적으로 대소분자를 구별합니다.

Arguments follow UNIX philosophy, square brackets `[Optional]` indicate that given argument is optional, while angle brackets `<Mandatory>` indicate that given argument is mandatory. You should replace the arguments that you want to declare, such as `[Bots]` or `<Nickname>` with actual values that you want to issue the command with, omitting the braces.

`[Bots]` argument, as indicated by the brackets, is optional in all commands. 지정된 경우, 명령어는 주어진 봇들에게서 실행됩니다. 지정되지 않은 경우, 명령어는 명령어를 받는 현재 봇에서 실행됩니다. 다시 말해서, 봇 `B`에게 전송된 `status A`는 봇 `A`에게 `status`를 보내는 것과 동일합니다. 여기에서 봇 `B`는 대리인 역할만 합니다. This can also be used for sending commands to bots that are unavailable otherwise, for example starting stopped bots, or executing actions on your main account (that you're using for executing the commands).

**Access** of the command defines **minimum** `EPermission` of `SteamUserPermissions` that is required to use the command, with an exception of `Owner` which is `SteamOwnerID` defined in global configuration file (and highest permission available).

Plural arguments, such as `[Bots]`, `<Keys>` or `<AppIDs>` mean that command supports multiple arguments of given type, separated by a comma. For example, `status [Bots]` can be used as `status MyBot,MyOtherBot,Primary`. This will cause given command to be executed on **all target bots** in the same way as you'd send `status` to each bot in a separate chat window. Please note that there is no space after `,`.

ASF uses all whitespace characters as possible delimiters for a command, such as space and newline characters. This means that you don't have to use space for delimiting your arguments, you can as well use any other whitespace character (such as tab or new line).

ASF will "join" extra out-of-range arguments to plural type of the last in-range argument. This means that `redeem bot key1 key2 key3` for `redeem [Bots] <Keys>` will work exactly the same as `redeem bot key1,key2,key3`. Together with accepting newline as command delimiter, this makes it possible for you to write `redeem bot` then paste a list of keys separated by any acceptable delimiter character (such as newline), or standard `,` ASF delimiter. Keep in mind that this trick can be used only for command variant that uses the most amount of arguments (so specifying `[Bots]` is mandatory in this case).

As you've read above, a space character is being used as a delimiter for a command, therefore it can't be used in arguments. However, also as stated above, ASF can join out-of-range arguments, which means that you're actually able to use a space character in argument that is defined as a last one for given command. For example, `nickname bob Great Bob` will properly set nickname of `bob` bot to "Great Bob". In the similar way you can check names containing spaces in `owns` command.

---

Some commands are also available with their aliases, mostly to save you on typing or account for different dialects:

| 명령어          | 별칭           |
| ------------ | ------------ |
| `addlicense` | `addlicence` |
| `owns ASF`   | `oa`         |
| `status ASF` | `sa`         |
| `redeem`     | `r`          |
| `redeem^`    | `r^`         |

---

### `[Bots]` argument

`[Bots]` argument is a special variant of plural argument, as in addition to accepting multiple values it also offers extra functionality.

First and foremost, there is a special `ASF` keyword which acts as "all bots in the process", so `status ASF` command is equal to `status all,your,bots,listed,here`. This can also be used to easily identify the bots that you have access to, as `ASF` keyword, despite of targeting all bots, will result in response only from those bots that you can actually send the command to.

`[Bots]` argument supports special "range" syntax, which allows you to choose a range of bots more easily. The general syntax for `[Bots]` in this case is `[FirstBot]..[LastBot]`. At least one of the arguments must be defined. When using `<FirstBot>..`, all bots starting from `FirstBot` are affected. When using `..<LastBot>`, all bots until `LastBot` are affected. When using `<FirstBot>..<LastBot>`, all bots within range from `FirstBot` until `LastBot` are affected. For example, if you have bots named `A, B, C, D, E, F`, you can execute `status B..E`, which is equal to `status B,C,D,E` in this case. When using this syntax, ASF will use alphabetical sorting in order to determine which bots are in your specified range. Arguments must be valid bot names recognized by ASF, otherwise range syntax is entirely skipped.

In addition to range syntax above, `[Bots]` argument also supports **[regex](https://en.wikipedia.org/wiki/Regular_expression)** matching. You can activate regex pattern by using `r!<Pattern>` as a bot name, where `r!` is ASF activator for regex matching, and `<Pattern>` is your regex pattern. An example of a regex-based bot command would be `status r!^\d{3}` which will send `status` command to bots that have a name made out of 3 digits (e.g. `123` and `981`). Feel free to take a look at the **[docs](https://docs.microsoft.com/dotnet/standard/base-types/regular-expression-language-quick-reference)** for further explanation and more examples of available regex patterns.

---

## `privacy` 설정

`<Settings>` argument accepts **up to 7** different options, separated as usual with standard comma ASF delimiter. Those are, in order:

| 인자 | 이름             | Child of   |
| -- | -------------- | ---------- |
| 1  | Profile        |            |
| 2  | OwnedGames     | Profile    |
| 3  | Playtime       | OwnedGames |
| 4  | FriendsList    | Profile    |
| 5  | Inventory      | Profile    |
| 6  | InventoryGifts | Inventory  |
| 7  | Comments       | Profile    |

For description of above fields, please visit **[Steam privacy settings](https://steamcommunity.com/my/edit/settings)**.

While valid values for all of them are:

| 값 | 이름            |
| - | ------------- |
| 1 | `Private`     |
| 2 | `FriendsOnly` |
| 3 | `Public`      |

You can use either a case-insensitive name, or a numeric value. Arguments that were omitted will default to being set to `Private`. It's important to note relation between child and parent of arguments specified above, as child can never have more open permission than its parent. For example, you **can't** have `Public` games owned while having `Private` profile.

### 예시

If you want to set **all** privacy settings of your bot named `Main` to `Private`, you can use either of below:

```text
privacy Main 1
privacy Main Private
```

This is because ASF will automatically assume all other settings to be `Private`, so there is no need to input them. On the other hand, if you'd like to set all privacy settings to `Public`, then you should use any of below:

```text
privacy Main 3,3,3,3,3,3,3
privacy Main Public,Public,Public,Public,Public,Public,Public
```

This way you can also set independent options however you like:

```text
privacy Main Public,FriendsOnly,Private,Public,Public,Private,Public
```

The above will set profile to public, owned games to friends only, playtime to private, friends list to public, inventory to public, inventory gifts to private and profile comments to public. You can achieve the same with numeric values if you want to.

---

## `addlicense` licenses

`addlicense` command supports two different license types, those are:

| Type  | 별칭  | 예시           | 설명                                                                      |
| ----- | --- | ------------ | ----------------------------------------------------------------------- |
| `app` | `a` | `app/292030` | Game determined by its unique `appID`.                                  |
| `sub` | `s` | `sub/47807`  | Package containing one or more games, determined by its unique `subID`. |

The distinction is important, as ASF will use Steam network activation for apps, and Steam store activation for packages. Those two are not compatible with each other, typically you'll use apps for free weekends and permanently F2P games, and packages otherwise.

We recommend to explicitly define the type of each entry in order to avoid ambiguous results, but for the backwards compatibility, if you supply invalid type or omit it entirely, ASF will assume that you ask for `sub` in this case. You can also query one or more of the licenses at the same time, using standard ASF `,` delimiter.

Complete command example:

```text
addlicense ASF app/292030,sub/47807
```

---

## `owns` games

`owns` command supports several different game types for `<games>` argument that can be used, those are:

| Type    | 별칭  | 예시               | 설명                                                                                                                                                                                                                                                                      |
| ------- | --- | ---------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `app`   | `a` | `app/292030`     | Game determined by its unique `appID`.                                                                                                                                                                                                                                  |
| `sub`   | `s` | `sub/47807`      | Package containing one or more games, determined by its unique `subID`.                                                                                                                                                                                                 |
| `regex` | `r` | `regex/^\d{4}:` | **[Regex](https://en.wikipedia.org/wiki/Regular_expression)** applying to the game's name, case-sensitive. See the **[docs](https://docs.microsoft.com/dotnet/standard/base-types/regular-expression-language-quick-reference)** for complete syntax and more examples. |
| `이름`    | `n` | `name/Witcher`   | Part of the game's name, case-insensitive.                                                                                                                                                                                                                              |

We recommend to explicitly define the type of each entry in order to avoid ambiguous results, but for the backwards compatibility, if you supply invalid type or omit it entirely, ASF will assume that you ask for `app` if your input is a number, and `name` otherwise. You can also query one or more of the games at the same time, using standard ASF `,` delimiter.

Complete command example:

```text
owns ASF app/292030,name/Witcher
```

---

## `redeem^` modes

`redeem^` command allows you to fine-tune modes that will be used for one single redeem scenario. This works as temporary override of `RedeemingPreferences` **[bot config property](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#bot-config)**.

`<Modes>` argument accepts multiple mode values, separated as usual by a comma. Available mode values are specified below:

| 값    | 이름                    | 설명                                                                              |
| ---- | --------------------- | ------------------------------------------------------------------------------- |
| FAWK | ForceAssumeWalletKey  | Forces `AssumeWalletKeyOnBadActivationCode` redeeming preference to be enabled  |
| FD   | ForceDistributing     | Forces `Distributing` redeeming preference to be enabled                        |
| FF   | ForceForwarding       | Forces `Forwarding` redeeming preference to be enabled                          |
| FKMG | ForceKeepMissingGames | Forces `KeepMissingGames` redeeming preference to be enabled                    |
| SAWK | SkipAssumeWalletKey   | Forces `AssumeWalletKeyOnBadActivationCode` redeeming preference to be disabled |
| SD   | SkipDistributing      | Forces `Distributing` redeeming preference to be disabled                       |
| SF   | SkipForwarding        | Forces `Forwarding` redeeming preference to be disabled                         |
| SI   | SkipInitial           | Skips key redemption on initial bot                                             |
| SKMG | SkipKeepMissingGames  | Forces `KeepMissingGames` redeeming preference to be disabled                   |
| V    | Validate              | Validates keys for proper format and automatically skips invalid ones           |

For example, we'd like to redeem 3 keys on any of our bots that don't own games yet, but not our `primary` bot. For achieving that we can use:

`redeem^ primary FF,SI key1,key2,key3`

It's important to note that advanced redeem overrides only those `RedeemingPreferences` that you **specify in the command**. For example, if you've enabled `Distributing` in your `RedeemingPreferences` then there will be no difference whether you use `FD` mode or not, because distributing will be already active regardless, due to `RedeemingPreferences` that you use. This is why each forcibly enabled override also has a forcibly disabled one, you can decide yourself if you prefer to override disabled with enabled, or vice versa.

---

## `encrypt` command

`encrypt` command allows you to encrypt arbitrary strings using ASF's encryption methods. `<encryptionMethod>` must be one of the encryption methods specified and explained in **[security](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security)** section. We recommend to use this command through secure channels (ASF console or IPC interface, which also has a dedicated API endpoint for it), as otherwise sensitive details might get logged by various third-parties (such as chat messages being logged by Steam servers).

---

## `hash` command

`hash` command allows you to generate hashes of arbitrary strings using ASF's hashing methods. `<hashingMethod>` must be one of the hashing methods specified and explained in **[security](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security)** section. We recommend to use this command through secure channels (ASF console or IPC interface, which also has a dedicated API endpoint for it), as otherwise sensitive details might get logged by various third-parties (such as chat messages being logged by Steam servers).

---

## `input` command

`input` command can be used only in `Headless` mode, for inputting given data via **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)** or Steam chat when ASF is running without support for user interaction.

General syntax is `input [Bots] <Type> <Value>`.

`<Type>` is case-insensitive and defines input type recognized by ASF. Currently ASF recognizes following types:

| Type                    | 설명                                                                         |
| ----------------------- | -------------------------------------------------------------------------- |
| Login                   | `SteamLogin` bot config property, if missing from config.                  |
| 비밀번호                    | `SteamPassword` bot config property, if missing from config.               |
| SteamGuard              | Auth code sent on your e-mail if you're not using 2FA.                     |
| SteamParentalCode       | `SteamParentalCode` bot config property, if missing from config.           |
| TwoFactorAuthentication | 2FA token generated from your mobile, if you're using 2FA but not ASF 2FA. |
| DeviceConfirmation      | Determines whether confirmation popup for login was accepted               |

`<Value>` is value set for given type. Currently all values are strings.

### 예시

Let's say that we have a bot that is protected by SteamGuard in non-2FA mode. We want to launch that bot with `Headless` set to `true`.

In order to do that, we need to execute following commands:

`start MySteamGuardBot` -> Bot will attempt to log in, fail due to AuthCode needed, then stop due to running in `Headless` mode. We need this in order to make Steam network send us auth code on our e-mail - if there was no need for that, we'd skip this step entirely.

`input MySteamGuardBot SteamGuard ABCDE` -> We set `SteamGuard` input of `MySteamGuardBot` bot to `ABCDE`. Of course, `ABCDE` in this case is auth code that we got on our e-mail.

`start MySteamGuardBot` -> We start our (stopped) bot again, this time it automatically uses auth code that we set in previous command, properly logging in, then clearing it.

In the same way we can access 2FA-protected bots (if they're not using ASF 2FA), as well as setting other required properties during runtime.