# 命令

ASF支援各種命令，這些命令可用於控制進程和機械人實例的行為。

以下命令可以通過各種不同的方式發送到機械人：
- 通過互動式 ASF 主控台
- 通過 Steam 私人聊天/群組聊天
- 通過我們的 **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)** 介面

請注意，與 ASF 交互需要您擁有相關命令的許可權。 查看 `SteamUserPermissions` 和 `SteamOwnerID` 配置屬性了解更多。

所有通過 Steam 聊天發送的命令都受 `CommandPrefix`**[ 全域配置屬性​影響](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#commandprefix)**，該屬性的預設值為`!`。 這意味著，當您要執行 `status` 命令時，實際應該發送 `!status`（或者使用您自訂的 `CommandPrefix`）。 `CommandPrefix` 不是強制性的，當您使用主控台或 IPC 時可以省略。

---

### 互動式主控台

ASF has support for interactive console, as long as you're not running ASF in [**`Headless`**](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#headless) mode. Simply press `c` button in order to enable command mode, type your command and confirm with enter.

![截圖](https://i.imgur.com/bH5Gtjq.png)

---

### Steam 聊天

您也可以通過 Steam 聊天向給定的 ASF 機械人發送命令。 顯然，您不能自言自語，因此，如果您想執行針對自己的命令，您至少需要另一個機械人帳戶。

![截圖](https://i.imgur.com/IvFRJ5S.png)

同樣，您也可以使用給定Steam組的群聊。 請注意，此選項需要您正確設置 `SteamMasterClanID` 屬性，使機械人同樣監聽（並加入）指定的群組聊天。 這也可以用於「與自己交談」，因為它與私人聊天相反，不需要專用的機械人帳戶。 您只需將` SteamMasterClanID `屬性設置為新創建的群組，然後通過機械人的` SteamOwnerID `或` SteamUserPermissions `為您自己授予訪問權限。 這樣，ASF 機械人（即您自己的帳戶）將會加入這個群組和群組聊天室，並且開始監聽您發送的命令。 您可以加入同一個群組聊天室，以便向自己發送命令（因為在您向聊天室發送命令時，同樣在聊天室內的 ASF 實例將會收到命令，即使界面上顯示只有您自己在聊天室內）。

請注意，向群聊發送命令的行為類似于中繼。 如果您向一個含有 3 個機械人的群組聊天發送 `redeem X` ，其效果等同於分別在私人聊天中向每個機械人發送 `redeem X`。 在大多數情況下，**這不是您想要的效果**，您應該像之前與**單個機械人交談**時一樣，向`特定機械人`發送命令。 ASF 支持群組聊天，當且僅當您有唯一的機械人時，它是一種有效的通信方式，但如果您的群組中有多個 ASF 機械人，就最好不要在這裏執行命令，除非您完全理解 ASF 的相關行為，並且您確實想要讓所有的機械人執行相同的命令。

*And even in this case you should use private chat with `[Bots]` syntax instead.*

---

### IPC

這是最先進、靈活的執行命令方式，非常適合用戶集成（ASF-ui）或者第三方工具腳本（ASF API）。這種方式需要 ASF 運行在 `IPC` 模式下，並且客戶端需要通過 **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)** 介面來執行命令。

![截圖](https://raw.githubusercontent.com/JustArchiNET/ASF-ui/main/.github/previews/commands.png)

---

## 命令

| 命令                                                                   | 權限              | 描述                                                                                                                                                                                                                                                                       |
| -------------------------------------------------------------------- | --------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| `2fa [Bots]`                                                         | `Master`        | 為指定機械人實例生成臨時​**[雙重驗證](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)**​代碼。                                                                                                                                                               |
| `2fafinalize [Bots] <ActivationCode>`                          | `Master`        | Finalizes process of assigning new **[2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication#creation)** credentials for given bot instances, using SMS/e-mail activation code.                                                              |
| `2fafinalized [Bots] <ActivationCode>`                         | `Master`        | Imports already-finalized **[2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication#creation)** credentials for given bot instances, using 2FA token for verification.                                                                       |
| `2fafinalizedforce [Bots]`                                           | `Master`        | Imports already-finalized **[2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication#creation)** credentials for given bot instances, skipping 2FA token verification.                                                                        |
| `2fainit [Bots]`                                                     | `Master`        | Starts process of assigning new **[2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication#creation)** credentials for given bot instances.                                                                                                   |
| `2fano [Bots]`                                                       | `Master`        | 為指定機械人拒絕所有待處理的​**[​雙重驗證](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)**​交易確認。                                                                                                                                                          |
| `2faok [Bots]`                                                       | `Master`        | 為指定機械人接受所有待處理的​**[雙重驗證](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)**​交易確認。                                                                                                                                                           |
| `addlicense [Bots] <Licenses>`                                 | `Operator`      | Activates given `licenses`, explained **[below](#addlicense-licenses)**, on given bot instances (free games only).                                                                                                                                                       |
| `balance [Bots]`                                                     | `Master`        | 顯示指定機械人的 Steam 錢包餘額。                                                                                                                                                                                                                                                     |
| `bgr [Bots]`                                                         | `Master`        | 列印有關 **[BGR](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer)** 佇列給定機械人實例的資訊。                                                                                                                                                              |
| `encrypt <encryptionMethod> <stringToEncrypt>`           | `Owner`         | Encrypts the string using provided cryptographic method - further explained **[below](#encrypt-command)**.                                                                                                                                                               |
| `exit`                                                               | `Owner`         | 完全終止ASF進程。                                                                                                                                                                                                                                                               |
| `farm [Bots]`                                                        | `Master`        | 重啟指定機械人實例的掛卡模組。                                                                                                                                                                                                                                                          |
| `fb [Bots]`                                                          | `Master`        | Lists apps blacklisted from automatic farming of given bot instances.                                                                                                                                                                                                    |
| `fbadd [Bots] <AppIDs>`                                        | `Master`        | Adds given `appIDs` to apps blacklisted from automatic farming of given bot instances.                                                                                                                                                                                   |
| `fbrm [Bots] <AppIDs>`                                         | `Master`        | Removes given `appIDs` from apps blacklisted from automatic farming of given bot instances.                                                                                                                                                                              |
| `fq [Bots]`                                                          | `Master`        | Lists priority farming queue of given bot instances.                                                                                                                                                                                                                     |
| `fqadd [Bots] <AppIDs>`                                        | `Master`        | Adds given `appIDs` to priority farming queue of given bot instances.                                                                                                                                                                                                    |
| `fqrm [Bots] <AppIDs>`                                         | `Master`        | Removes given `appIDs` from farming queue of given bot instances.                                                                                                                                                                                                        |
| `hash <hashingMethod> <stringToHash>`                    | `Owner`         | Generated a hash of the string using provided cryptographic method - further explained **[below](#hash-command)**.                                                                                                                                                       |
| `help`                                                               | `FamilySharing` | 顯示幫助（指向此頁面的連結）。                                                                                                                                                                                                                                                          |
| `input [Bots] <Type> <Value>`                            | `Master`        | 為指定機械人輸入特定字段的值，僅在 `Headless` 模式中可用──詳見​**[下文](#input-command)**的解釋。                                                                                                                                                                                                      |
| `level [Bots]`                                                       | `Master`        | 顯示指定機械人實例的 Steam 等級。                                                                                                                                                                                                                                                     |
| `loot [Bots]`                                                        | `Master`        | 將指定機械人實例的所有 `LootableTypes` 社區物品發送給其 `SteamUserPermissions` 屬性中設置的 `Master` 用戶（如有多個則取 steamID 最小的）。                                                                                                                                                                      |
| `loot@ [Bots] <AppIDs>`                                        | `Master`        | Sends all `LootableTypes` Steam community items matching given `AppIDs` of given bot instances to `Master` user defined in their `SteamUserPermissions` (with lowest steamID if more than one). This is the opposite of `loot%`.                                         |
| `loot% [Bots] <AppIDs>`                                        | `Master`        | Sends all `LootableTypes` Steam community items apart from given `AppIDs` of given bot instances to `Master` user defined in their `SteamUserPermissions` (with lowest steamID if more than one). This is the opposite of `loot@`.                                       |
| `loot^ [Bots] <AppID> <ContextID>`                       | `Master`        | 將指定機械人實例的`ContextID` 庫存分類中符合特定 `AppID` 的物品發送給其 `SteamUserPermissions` 屬性中設置的 `Master` 用戶（如果有多個則取 steamID 最小的）。                                                                                                                                                           |
| `mab [Bots]`                                                         | `Master`        | Lists apps blacklisted from automatic trading in **[`MatchActively`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#matchactively)**.                                                                                                            |
| `mabadd [Bots] <AppIDs>`                                       | `Master`        | Adds given `appIDs` to apps blacklisted from automatic trading in **[`MatchActively`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#matchactively)**.                                                                                           |
| `mabrm [Bots] <AppIDs>`                                        | `Master`        | Removes given `appIDs` from apps blacklisted from automatic trading in **[`MatchActively`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#matchactively)**.                                                                                      |
| `match [Bots]`                                                       | `Master`        | Special command for **[`ItemsMatcherPlugin`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#matchactively)** which triggers `MatchActively` routine immediately.                                                                                 |
| `nickname [Bots] <Nickname>`                                   | `Master`        | 將指定機械人的Steam`nickname`更改為自訂昵稱。                                                                                                                                                                                                                                           |
| `owns [Bots] <Games>`                                          | `Operator`      | Checks if given bot instances already own given `games`, explained **[below](#owns-games)**.                                                                                                                                                                             |
| `暫停 [Bots]`                                                          | `Operator`      | 停止指定機械人的自動掛卡模組。 ASF 在本次會話中將不會再嘗試對當前帳戶進行掛卡，除非您手動 `resume`或者重啟 ASF。                                                                                                                                                                                                        |
| `pause~ [Bots]`                                                      | `FamilySharing` | 暫停指定機械人的自動掛卡模組。 掛卡進程將會在下次遊戲事件被觸發時或機械人斷開連接時自動恢復。 您可以使用`resume`命令以恢復掛卡。                                                                                                                                                                                                    |
| `pause& [Bots] <Seconds>`                                  | `Operator`      | 暂停指定機械人的自动挂卡模块 `seconds` 秒。 之後，掛卡模組將自動恢復。                                                                                                                                                                                                                                |
| `play [Bots] <AppIDs,GameName>`                                | `Master`        | 切換至手動掛卡模式──使指定機械人運行特定的`AppIDs`，並且可選自訂 `GameName` 為當前遊戲名稱。 In order for this feature to work properly, your Steam account **must** own a valid license to all the `AppIDs` that you specify here, this includes F2P games as well. Use `reset` or `resume` for returning. |
| `points [Bots]`                                                      | `Master`        | Displays number of points in **[Steam points shop](https://store.steampowered.com/points/shop)**.                                                                                                                                                                        |
| `privacy [Bots] <Settings>`                                    | `Master`        | 更改指定機械人的 **[Steam 隱私設置](https://steamcommunity.com/my/edit/settings)**，可用選項將於**[​下文](#privacy-settings)**詳述。                                                                                                                                                             |
| `redeem [Bots] <Keys>`                                         | `Operator`      | 為指定機械人實例兌換給定的CD金鑰或錢包充值碼。                                                                                                                                                                                                                                                 |
| `redeem^ [Bots] <Modes> <Keys>`                          | `Operator`      | 以`Modes`模式為指定機械人實例兌換給定的CD金鑰或錢包充值碼，模式將於**[​下文](#redeem-modes)**詳述。                                                                                                                                                                                                        |
| `reset [Bots]`                                                       | `Master`        | Resets the playing status back to original (previous) state, the command is used during manual farming with `play` command.                                                                                                                                              |
| `restart`                                                            | `Owner`         | 重啟 ASF 進程。                                                                                                                                                                                                                                                               |
| `繼續 [Bots]`                                                          | `FamilySharing` | 恢復指定機械人的自動掛卡進程。                                                                                                                                                                                                                                                          |
| `start [Bots]`                                                       | `Master`        | 啟動指定機械人實例。                                                                                                                                                                                                                                                               |
| `stats`                                                              | `Owner`         | 顯示進程統計信息，例如託管記憶體用量。                                                                                                                                                                                                                                                      |
| `status [Bots]`                                                      | `FamilySharing` | 顯示指定機械人的狀態。                                                                                                                                                                                                                                                              |
| `std [Bots]`                                                         | `Master`        | Special command for **[`SteamTokenDumperPlugin`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/SteamTokenDumperPlugin)** which triggers refresh of selected bots and submission of data immediately.                                                               |
| `stop [Bots]`                                                        | `Master`        | 停止指定機械人的進程。                                                                                                                                                                                                                                                              |
| `tb [Bots]`                                                          | `Master`        | 列出指定機械人實例交易模組中的用戶黑名單。                                                                                                                                                                                                                                                    |
| `tbadd [Bots] <SteamIDs64>`                                    | `Master`        | 將特定的 `steamIDs` 加入指定機械人實例交易模組的用戶黑名單。                                                                                                                                                                                                                                     |
| `tbrm [Bots] <SteamIDs64>`                                     | `Master`        | 將特定的 `steamIDs `移出指定機械人實例交易模組的用戶黑名單。                                                                                                                                                                                                                                     |
| `transfer [Bots] <TargetBot>`                                  | `Master`        | Sends all `TransferableTypes` Steam community items from given bot instances to target bot instance.                                                                                                                                                                     |
| `transfer@ [Bots] <AppIDs> <TargetBot>`                  | `Master`        | Sends all `TransferableTypes` Steam community items matching given `AppIDs` from given bot instances to target bot instance. This is the opposite of `transfer%`.                                                                                                        |
| `transfer% [Bots] <AppIDs> <TargetBot>`                  | `Master`        | Sends all `TransferableTypes` Steam community items apart from given `AppIDs` from given bot instances to target bot instance. This is the opposite of `transfer@`.                                                                                                      |
| `transfer^ [Bots] <AppID> <ContextID> <TargetBot>` | `Master`        | Sends all Steam items from given `AppID` in `ContextID` of given bot instances to target bot instance.                                                                                                                                                                   |
| `unpack [Bots]`                                                      | `Master`        | 拆開指定機械人物品庫中的所有擴充包。                                                                                                                                                                                                                                                       |
| `update [Channel]`                                                   | `Owner`         | Checks GitHub for new ASF release and updates to it if available. This is normally done automatically every `UpdatePeriod`. Optional `Channel` argument specifies the `UpdateChannel`, if not provided defaults to the one set in global config.                         |
| `version`                                                            | `FamilySharing` | 列印當前 ASF 的版本號。                                                                                                                                                                                                                                                           |

---

### 備註

所有的命令都不區分大小寫，但它們的參數（例如機械人名稱）通常是區分大小寫的。

Arguments follow UNIX philosophy, square brackets `[Optional]` indicate that given argument is optional, while angle brackets `<Mandatory>` indicate that given argument is mandatory. You should replace the arguments that you want to declare, such as `[Bots]` or `<Nickname>` with actual values that you want to issue the command with, omitting the braces.

`[Bots]` argument, as indicated by the brackets, is optional in all commands. 當指定該參數時，指令會在指定的機械人上執行。 但省略時，指令會在當前接收指令的機械人上執行。 換句話說，發送到機械人 ` B `的` status A `，其結果與將` status `發送到機械人 ` A `相同，在這種情況下，機械人` B `僅作為代理。 This can also be used for sending commands to bots that are unavailable otherwise, for example starting stopped bots, or executing actions on your main account (that you're using for executing the commands).

命令的**Access**定義了需要執行此命令所需的**最低**許可權，即 `SteamUserPermissions `中定義的 `EPermission`，例外情況是 `Owner` 指全域配置檔案中的 `SteamOwnerID` 用戶（擁有最高許可權）。

Plural arguments, such as `[Bots]`, `<Keys>` or `<AppIDs>` mean that command supports multiple arguments of given type, separated by a comma. For example, `status [Bots]` can be used as `status MyBot,MyOtherBot,Primary`. 這樣，該命令會在**所有目標機械人**上執行，效果等同分別向所有機械人單獨發送 `status`命令。 需要注意的是`，`後面不能有空格。

ASF 使用所有空白字元作為命令的分隔符號，例如空格和換行符。 這意味著您不僅可以使用空格來分隔參數，還可以使用任何其他空白字元（如選項卡或換行符號）。

ASF 會將命令末尾超出規定範圍的多餘參數「聯接」到符合語法規定的最後一個參數上。 This means that `redeem bot key1 key2 key3` for `redeem [Bots] <Keys>` will work exactly the same as `redeem bot key1,key2,key3`. 當您同時使用換行作為命令分隔符號，就可編寫`redeem bot`，然後粘貼由任何可接受的分隔符號 (如分行符號) 或標準 `，` ASF分隔符號分隔的序號清單。 Keep in mind that this trick can be used only for command variant that uses the most amount of arguments (so specifying `[Bots]` is mandatory in this case).

如上所述，空白字元被用作命令的分隔符號，因此它不能在參數中使用。 但是，如上所述，ASF可以聯接超出範圍的參數, 這意味著您實際上能夠在參數中使用空白字元，該字元被定義為給定命令的最後一個字元。 例如，`nickname bob Great Bob` 將正確地將機械人 `bob` 的昵稱設置為「Great Bob」。 與此類似，您可以使用`owns` 命令檢查含有空格的名稱。

---

Some commands are also available with their aliases, mostly to save you on typing or account for different dialects:

| 命令           | 別名           |
| ------------ | ------------ |
| `addlicense` | `addlicence` |
| `owns ASF`   | `oa`         |
| `status ASF` | `sa`         |
| `redeem`     | `r`          |
| `redeem^`    | `r^`         |

---

### `[Bots]` argument

`[Bots]` argument is a special variant of plural argument, as in addition to accepting multiple values it also offers extra functionality.

首要的是，您可以使用特殊的關鍵字 `ASF` 來表示「所有機械人」，因此 `status ASF` 命令等同與`status all,your,bots,listed,here` 。 這也可用於輕鬆識別您有權訪問的機械人，因為儘管 `ASF` 關鍵字的目標是所有機械人，但只有您能夠實際發送指令的機械人才會作出響應。

`[Bots]` argument supports special "range" syntax, which allows you to choose a range of bots more easily. The general syntax for `[Bots]` in this case is `[FirstBot]..[LastBot]`. At least one of the arguments must be defined. When using `<FirstBot>..`, all bots starting from `FirstBot` are affected. When using `..<LastBot>`, all bots until `LastBot` are affected. When using `<FirstBot>..<LastBot>`, all bots within range from `FirstBot` until `LastBot` are affected. 例如，如果您有名為 `A, B, C, D, E, F`的機械人，在這種情況下，执行 `status B..E`的效果等於执行 `status B,C,D,E` 。 使用此語法時，ASF將使用字母排序，以决定哪些機械人在指定的範圍內。 Arguments must be valid bot names recognized by ASF, otherwise range syntax is entirely skipped.

In addition to range syntax above, `[Bots]` argument also supports **[regex](https://en.wikipedia.org/wiki/Regular_expression)** matching. 您可以使用 `r!<Pattern>` 作為機械人名稱來激活正則運算式模式，其中 `r!` 是用於正則運算式匹配的ASF啟動命令，而 `<Pattern>` 是您的正則運算式。 An example of a regex-based bot command would be `status r!^\d{3}` which will send `status` command to bots that have a name made out of 3 digits (e.g. `123` and `981`). 您可以隨時閱讀這份**[​文檔](https://docs.microsoft.com/dotnet/standard/base-types/regular-expression-language-quick-reference)**，以進一步了解更多可用正則運算式的解釋和示例。

---

## `privacy` 設置

`<Settings>`參數擁有**多至 7 個**不同的選項，使用逗號分隔。 這些選項，按順序分別是：

| 參數 | 名稱             | 從屬於        |
| -- | -------------- | ---------- |
| 1  | Profile        |            |
| 2  | OwnedGames     | Profile    |
| 3  | Playtime       | OwnedGames |
| 4  | FriendsList    | Profile    |
| 5  | Inventory      | Profile    |
| 6  | InventoryGifts | Inventory  |
| 7  | Comments       | Profile    |

有關上述字段的說明，請訪問 **[Steam 隱私設置](https://steamcommunity.com/my/edit/settings)**。

每個選項的有效值可以是：

| 值 | 名稱            |
| - | ------------- |
| 1 | `Private`     |
| 2 | `FriendsOnly` |
| 3 | `Public`      |

您可以使用它們的名稱（不區分大小寫）或者數值。 省略的參數將會被設置為預設值 `Private`。 請謹記上述參數的從屬關係非常重要，因為子選項無法擁有比父選項更高的許可權。 For example, you **can't** have `Public` games owned setting while having `Private` profile setting.

### 範例

如果您希望將機械人 `Main` 的**所有**隱私設置都設置為 `Private`，可以使用以下任一命令：

```text
privacy Main 1
privacy Main Private
```

這是因為 ASF 會預設所有未賦值選項為 `Private`，所以您不需要全部寫出它們。 另一方面，如果您希望設置所有選項為 `Public`，可以使用以下任一命令：

```text
privacy Main 3,3,3,3,3,3,3
privacy Main Public,Public,Public,Public,Public,Public,Public
```

也可以為每個選項設置不同的值：

```text
privacy Main Public,FriendsOnly,Private,Public,Public,Private,Public
```

上述命令將會設置個人資料為公開、遊戲詳情為僅限好友、遊戲時間為私密、好友列表為公開、物品庫為公開、物品庫禮物為私密、留言為公開。 若有需要，您也可以使用數字值來實現相同效果。

---

## `addlicense` licenses

`addlicense` command supports two different license types, those are:

| 類型    | 別名  | 範例           | 描述                                                                      |
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

| 類型      | 別名  | 範例               | 描述                                                                                                                                                                                                                                                                      |
| ------- | --- | ---------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `app`   | `a` | `app/292030`     | Game determined by its unique `appID`.                                                                                                                                                                                                                                  |
| `sub`   | `s` | `sub/47807`      | Package containing one or more games, determined by its unique `subID`.                                                                                                                                                                                                 |
| `regex` | `r` | `regex/^\d{4}:` | **[Regex](https://en.wikipedia.org/wiki/Regular_expression)** applying to the game's name, case-sensitive. See the **[docs](https://docs.microsoft.com/dotnet/standard/base-types/regular-expression-language-quick-reference)** for complete syntax and more examples. |
| `名稱`    | `n` | `name/Witcher`   | Part of the game's name, case-insensitive.                                                                                                                                                                                                                              |

We recommend to explicitly define the type of each entry in order to avoid ambiguous results, but for the backwards compatibility, if you supply invalid type or omit it entirely, ASF will assume that you ask for `app` if your input is a number, and `name` otherwise. You can also query one or more of the games at the same time, using standard ASF `,` delimiter.

Complete command example:

```text
owns ASF app/292030,name/Witcher
```

---

## `redeem^`模式

`redeem^` 命令允許您微調用於單個兌換場景的模式。 此命令會臨時覆蓋 `RedeemingPreferences`**[ 機械人配置屬性](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#bot-config)**。

`<Modes>` 參數接受多個模式值，通常用逗號分隔。 可用的模式值如下所示：

| 值    | 名稱                    | 描述                                                                              |
| ---- | --------------------- | ------------------------------------------------------------------------------- |
| FAWK | ForceAssumeWalletKey  | Forces `AssumeWalletKeyOnBadActivationCode` redeeming preference to be enabled  |
| FD   | ForceDistributing     | 強制啟用 `Distributing` 激活偏好設置                                                      |
| FF   | ForceForwarding       | 強制啟用 `Forwarding` 激活偏好設置                                                        |
| FKMG | ForceKeepMissingGames | 強制啟用 `KeepMissingGames`激活偏好設置                                                   |
| SAWK | SkipAssumeWalletKey   | Forces `AssumeWalletKeyOnBadActivationCode` redeeming preference to be disabled |
| SD   | SkipDistributing      | 強制禁用 `Distributing` 激活偏好設置                                                      |
| SF   | SkipForwarding        | 強制禁用 `Forwarding` 激活偏好設置                                                        |
| SI   | SkipInitial           | 跳過初始機械人的金鑰兌換過程                                                                  |
| SKMG | SkipKeepMissingGames  | 強制禁用 `KeepMissingGames` 激活偏好設置                                                  |
| V    | Validate              | 檢查金鑰格式是否正確，並自動跳過無效金鑰                                                            |

例如，我們打算為尚未擁有遊戲的機械人兌換 3 個金鑰，但不包括 `primary` 機械人。 為此我們需要執行命令：

`redeem^ primary FF,SI key1,key2,key3`

需要注意的是，進階激活模式只會覆蓋您**在命令中使用**的`RedeemingPreferences`選項。 舉例來說，如果您在 `RedeemingPreferences` 中啟用了 `Distributing`，則無論是否使用 `FD` 模式，都不會有任何區別，因為您已激活了`RedeemingPreferences`。 這就是為什麼每個可強制啟用的重寫也有一個可強制禁用的選項，若有需要，您可以決定在啟用的情況下強制覆蓋，反之亦然。

---

## `encrypt` command

`encrypt` command allows you to encrypt arbitrary strings using ASF's encryption methods. `<encryptionMethod>` must be one of the encryption methods specified and explained in **[security](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security)** section. We recommend to use this command through secure channels (ASF console or IPC interface, which also has a dedicated API endpoint for it), as otherwise sensitive details might get logged by various third-parties (such as chat messages being logged by Steam servers).

---

## `hash` command

`hash` command allows you to generate hashes of arbitrary strings using ASF's hashing methods. `<hashingMethod>` must be one of the hashing methods specified and explained in **[security](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security)** section. We recommend to use this command through secure channels (ASF console or IPC interface, which also has a dedicated API endpoint for it), as otherwise sensitive details might get logged by various third-parties (such as chat messages being logged by Steam servers).

---

## `input` 命令

`input` command can be used only in `Headless` mode, for inputting given data via **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)** or Steam chat when ASF is running without support for user interaction.

General syntax is `input [Bots] <Type> <Value>`.

`<Type>` 不區分大小寫，並定義由ASF識別的輸入類型。 當前，ASF可識別以下類型：

| 類型                      | 描述                                                           |
| ----------------------- | ------------------------------------------------------------ |
| Login                   | `SteamLogin`機械人配置屬性，在設定檔缺失這個值時使用。                            |
| Password                | `SteamPassword` 機械人配置屬性，在設定檔缺失這個值時使用。                        |
| SteamGuard              | 如果您未啟用2FA，驗證代碼將以電子郵件的方式發送。                                   |
| SteamParentalCode       | `SteamParentalCode` 機械人配置屬性，在設定檔缺失這個值時使用。                    |
| TwoFactorAuthentication | 如果您使用的是2FA, 但未使用 ASF 2FA, 則從您的手機生成2FA代碼 。                    |
| DeviceConfirmation      | Determines whether confirmation popup for login was accepted |

`<Value>` 是為給定類型設置的值。 當前，所有值都是字串。

### 範例

假設我們有一個未啟用2FA，僅由 SteamGuard保護的機械人。 We want to launch that bot with `Headless` set to `true`.

為此，我們需要執行以下命令：

`start MySteamGuardBot` -> Bot will attempt to log in, fail due to AuthCode needed, then stop due to running in `Headless` mode. 我們需要這樣做的目的是使Steam網絡通過電子郵件向我們發送驗證代碼──如果不需要這樣做，我們將完全跳過這一步。

`input MySteamGuardBot SteamGuard ABCDE` -> We set `SteamGuard` input of `MySteamGuardBot` bot to `ABCDE`. 當然，在這種情況下，`ABCDE`是我們在電子郵件中獲得的驗證代碼。

`start MySteamGuardBot` -> We start our (stopped) bot again, this time it automatically uses auth code that we set in previous command, properly logging in, then clearing it.

同樣，我們可以訪問受2FA 保護的機械人 (如果它們不使用 ASF 2FA)，只需在運行時設置其他必需的屬性。