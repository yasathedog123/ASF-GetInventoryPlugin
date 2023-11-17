# 指令

ASF支援各種指令，以此來控制程序及Bot實例的行為。

您可以透過這些方式來傳送指令：
- 透過互動式ASF控制台
- 透過Steam私人／群組聊天
- 透過&#8203;**[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-zh-TW)**&#8203;介面

請注意，與ASF互動需要您擁有執行相關指令的權限。 查看&#8203;`SteamUserPermissions`&#8203;與&#8203;`SteamOwnerID`&#8203;設定屬性以了解更多。

透過Steam聊天執行的指令都受&#8203;**[全域設定屬性](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-zh-TW#commandprefix指令前綴#CommandPrefix)**&#8203;的&#8203;`CommandPrefix`&#8203;影響，而該屬性的預設值為&#8203;`!`&#8203;。 這代表當您要執行&#8203;`status`&#8203;指令時，實際應該要傳送&#8203;`!status`&#8203;（或使用您自訂的&#8203;`CommandPrefix`&#8203;）。 而當您使用控制台或IPC時，不強制使用&#8203;`CommandPrefix`&#8203;，可以省略它。

---

### 互動式控制台

從V4.0.0.9版本開始，ASF支援互動式控制台。只要您沒有讓ASF在&#8203;[**`Headless`**](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-zh-TW#headless無頭模式)&#8203;模式下執行， 按下&#8203;`C`&#8203;鍵，就可以啟用指令模式。輸入您的指令，並按下確認鍵確認。

![擷圖](https://i.imgur.com/bH5Gtjq.png)

---

### Steam 聊天

您也可以透過Steam聊天使指定的ASF Bot執行指令。 但很明顯，您無法直接跟自己聊天。因此，如果您想在自己的主帳號中執行指令，您至少還需要另一個Bot帳號。

![擷圖](https://i.imgur.com/IvFRJ5S.png)

同樣您也可以使用指定的Steam群組聊天。 請注意，使用這個方法需要您正確設定&#8203;`SteamMasterClanID`&#8203;屬性，使Bot也會同時監聽（並加入）指定群組聊天中的指令。 這與私人聊天不同，因為這個方式不需要專用的Bot帳號，所以可以「和自己交談」。 您只需將&#8203;`SteamMasterClanID`&#8203;屬性設成您新建立的群組，然後透過設定Bot的&#8203;`SteamOwnerID`&#8203;或&#8203;`SteamUserPermissions`&#8203;來給您自己存取權限。 這樣，ASF Bot（即您自己的帳號）就會加入這個群組及它的群組聊天室，並開始監聽您傳送的指令。 您可以進入同一個群組聊天室，以便向自己傳送指令（因為即使介面上顯示只有您自己在聊天室，在您向聊天室傳送指令時，同樣在聊天室內的ASF實例也會收到指令）。

請注意，傳送指令到群組聊天就像是一個中繼。 如果您向一個含有3個Bot的群組聊天傳送&#8203;`redeem X`&#8203;指令，這個效果與分別向每個Bot私人聊天發送&#8203;`redeem X`&#8203;指令是相同的。 在大多數情形下，&#8203;**這並非是您想要的效果**&#8203;。您應該像之前&#8203;**與單個Bot交談時**&#8203;一樣，使用&#8203;`特定Bot名稱`&#8203;的指令形式。 ASF支援群組聊天，是因為在多數情形下，它是一種與您唯一的Bot通訊的有效方式。但若您的群組中有多個ASF Bot，就最好不要在這裡執行指令，除非您完全理解ASF的相關行為，並且確實想讓所有Bot都執行相同的指令。

*但即使是這種情形，您也應該使用帶有&#8203;`[Bots]`&#8203;語法的私人聊天，來向Bot傳送指令。*

---

### IPC

這是最先進且最靈活執行指令的方式，非常適合使用者交互（ASF-ui）及第三方工具或腳本（ASF API）。這種方式需要ASF執行於&#8203;`IPC`&#8203;模式，且用戶端需要透過&#8203;**[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)**&#8203;介面來執行指令。

![擷圖](https://raw.githubusercontent.com/JustArchiNET/ASF-ui/main/.github/previews/commands.png)

---

## 指令

| 指令                                                                   | 存取權限            | 描述                                                                                                                                                                                                                                   |
| -------------------------------------------------------------------- | --------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| `2fa [Bots]`                                                         | `Master`        | 使指定的Bot實例生成臨時的&#8203;**[雙重驗證](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication-zh-TW)**&#8203;權杖。                                                                                                       |
| `2fafinalize [Bots] <ActivationCode>`                          | `Master`        | 使指定Bot實例使用簡訊啟用碼，完成綁定新&#8203;**[雙重驗證](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication-zh-TW#建立)**&#8203;憑證的流程。                                                                                          |
| `2fafinalized [Bots] <ActivationCode>`                         | `Master`        | 為指定Bot實例使用雙重驗證權杖驗證，匯入已最終化的&#8203;**[雙重驗證](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication-zh-TW#建立)**&#8203;憑證。                                                                                        |
| `2fafinalizedforce [Bots]`                                           | `Master`        | 為指定Bot實例匯入已最終化的&#8203;**[雙重驗證](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication-zh-TW#建立)**&#8203;憑證，並跳過雙重驗證權杖驗證。                                                                                       |
| `2fainit [Bots]`                                                     | `Master`        | 使指定Bot實例開始綁定新&#8203;**[雙重驗證](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication-zh-TW#建立)**&#8203;憑證的流程。                                                                                                  |
| `2fano [Bots]`                                                       | `Master`        | 使指定的Bot實例拒絕所有待處理的&#8203;**[雙重驗證](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication-zh-TW)**&#8203;交易確認。                                                                                                  |
| `2faok [Bots]`                                                       | `Master`        | 使指定的Bot實例接受所有待處理的&#8203;**[雙重驗證](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication-zh-TW)**&#8203;交易確認。                                                                                                  |
| `addlicense [Bots] <Licenses>`                                 | `Operator`      | 在指定的Bot實例上啟用給定的&#8203;`licenses`&#8203;，請參閱&#8203;**[下文](#addlicense-指令中的-licenses-引數)**&#8203;的說明（僅適用於免費遊戲）。                                                                                                                        |
| `balance [Bots]`                                                     | `Master`        | 顯示指定Bot實例的Steam錢包餘額。                                                                                                                                                                                                                 |
| `bgr [Bots]`                                                         | `Master`        | 顯示關於指定Bot實例的&#8203;**[背景序號啟動器](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer-zh-TW)**&#8203;佇列的資訊。                                                                                                   |
| `encrypt <encryptionMethod> <stringToEncrypt>`           | `Owner`         | 以指定的加密方式加密字串⸺請參閱&#8203;**[下文](#encrypt-指令)**&#8203;的說明。                                                                                                                                                                              |
| `exit`                                                               | `Owner`         | 完全終止ASF程序。                                                                                                                                                                                                                           |
| `farm [Bots]`                                                        | `Master`        | 重新啟動指定Bot實例的掛卡模組。                                                                                                                                                                                                                    |
| `fb [Bots]`                                                          | `Master`        | 列出指定Bot實例的應用程式自動掛卡黑名單。                                                                                                                                                                                                               |
| `fbadd [Bots] <AppIDs>`                                        | `Master`        | 將給定的&#8203;`AppIDs`&#8203;新增至指定Bot實例的應用程式自動掛卡黑名單中。                                                                                                                                                                                   |
| `fbrm [Bots] <AppIDs>`                                         | `Master`        | 將給定的&#8203;`AppIDs`&#8203;從指定Bot實例的應用程式自動掛卡黑名單中移除。                                                                                                                                                                                   |
| `fq [Bots]`                                                          | `Master`        | 列出指定Bot實例的優先掛卡佇列。                                                                                                                                                                                                                    |
| `fqadd [Bots] <AppIDs>`                                        | `Master`        | 將給定的&#8203;`AppIDs`&#8203;新增至指定Bot實例的優先掛卡佇列中。                                                                                                                                                                                        |
| `fqrm [Bots] <AppIDs>`                                         | `Master`        | 將給定的&#8203;`AppIDs`&#8203;從指定Bot實例的優先掛卡佇列中移除。                                                                                                                                                                                        |
| `hash <hashingMethod> <stringToHash>`                    | `Owner`         | 以指定的加密方式產生給定字串的雜湊值⸺請參閱&#8203;**[下文](#hash-指令)**&#8203;的說明。                                                                                                                                                                           |
| `help`                                                               | `FamilySharing` | 顯示幫助（指向本頁面的連結）。                                                                                                                                                                                                                      |
| `input [Bots] <Type> <Value>`                            | `Master`        | 為指定Bot實例輸入指定類型的輸入值，只在&#8203;`Headless`&#8203;模式下運作⸺請參閱&#8203;**[下文](#input-指令)**&#8203;的說明。                                                                                                                                          |
| `level [Bots]`                                                       | `Master`        | 顯示指定Bot實例的Steam帳號等級。                                                                                                                                                                                                                 |
| `loot [Bots]`                                                        | `Master`        | 將指定Bot實例中所有符合&#8203;`LootableTypes`&#8203;類型的Steam社群物品，交易給其&#8203;`SteamUserPermissions`&#8203;屬性中設定的&#8203;`Master`&#8203;使用者（如有多個，則取steamID最小者）。                                                                                   |
| `loot@ [Bots] <AppIDs>`                                        | `Master`        | 將指定Bot實例中，所有符合&#8203;`AppIDs`&#8203;及&#8203;`LootableTypes`&#8203;類型的Steam社群物品，交易給其&#8203;`SteamUserPermissions`&#8203;屬性中設定的&#8203;`Master`&#8203;使用者（如有多個，則取steamID最小者）。 這是與&#8203;`loot%`&#8203;相反的指令。                            |
| `loot% [Bots] <AppIDs>`                                        | `Master`        | 將指定Bot實例中，除符合&#8203;`AppIDs`&#8203;以外的所有&#8203;`LootableTypes`&#8203;類型的Steam社群物品，交易給其&#8203;`SteamUserPermissions`&#8203;屬性中設定的&#8203;`Master`&#8203;使用者（如有多個，則取steamID最小者）。 這是與&#8203;`loot@`&#8203;相反的指令。                         |
| `loot^ [Bots] <AppID> <ContextID>`                       | `Master`        | 將指定Bot實例的&#8203;`ContextID`&#8203;物品庫分類中，所有符合給定&#8203;`AppID`&#8203;及&#8203;`LootableTypes`&#8203;類型的Steam社群物品，交易給其&#8203;`SteamUserPermissions`&#8203;屬性中設定的&#8203;`Master`&#8203;使用者（如有多個，則取steamID最小者）。                           |
| `mab [Bots]`                                                         | `Master`        | 列出&#8203;**[`MatchActively`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin-zh-TW#matchactively)**&#8203;中的應用程式自動交易黑名單。                                                                                      |
| `mabadd [Bots] <AppIDs>`                                       | `Master`        | 將給定的&#8203;`AppIDs`&#8203;加入至&#8203;**[`MatchActively`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin-zh-TW#matchactively)**&#8203;的應用程式自動交易黑名單中。                                                           |
| `mabrm [Bots] <AppIDs>`                                        | `Master`        | 將給定的&#8203;`AppIDs`&#8203;從&#8203;**[`MatchActively`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin-zh-TW#matchactively)**&#8203;的應用程式自動交易黑名單中移除。                                                           |
| `match [Bots]`                                                       | `Master`        | 控制&#8203;**[`ItemsMatcherPlugin`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin-zh-TW)**&#8203;的特殊指令，用於立即觸發&#8203;`MatchActively`&#8203;常式。                                                                 |
| `nickname [Bots] <Nickname>`                                   | `Master`        | 將指定Bot實例的Steam暱稱，更改為給定的&#8203;`Nickname`&#8203;。                                                                                                                                                                                     |
| `owns [Bots] <Games>`                                          | `Operator`      | 檢查指定的Bot實例是否已擁有給定的&#8203;`Games`&#8203;，請參閱&#8203;**[下文](#owns-指令中的-games-引數)**&#8203;的說明。                                                                                                                                           |
| `pause [Bots]`                                                       | `Operator`      | 停止指定Bot實例的自動掛卡模組。 ASF在本次執行階段中，將不會再次嘗試對此帳號進行掛卡，除非您手動&#8203;`resume`&#8203;，或者重新啟動ASF程序。                                                                                                                                               |
| `pause~ [Bots]`                                                      | `FamilySharing` | 暫停指定Bot實例的自動掛卡模組。 掛卡程序將會在下次遊戲事件被觸發時，或在Bot斷線時自動恢復。 您可以使用&#8203;`resume`&#8203;以恢復掛卡。                                                                                                                                                  |
| `pause& [Bots] <Seconds>`                                  | `Operator`      | 暫停指定Bot實例的自動掛卡模組&#8203;`Seconds`&#8203;秒。 在此之後，掛卡模組將會自動恢復。                                                                                                                                                                           |
| `play [Bots] <AppIDs,GameName>`                                | `Master`        | 切換至手動掛卡模式⸺使指定的Bot實例為給定的&#8203;`AppIDs`&#8203;執行掛卡，自訂的&#8203;`GameName`&#8203;為選擇性的遊戲名稱。 若要使此功能正常運作，您的Steam帳號&#8203;**必須**&#8203;擁有您指定的所有&#8203;`AppIDs`&#8203;的有效許可，包含免費遊戲。 使用&#8203;`reset`&#8203;或&#8203;`resume`&#8203;指令來恢復自動掛卡。 |
| `points [Bots]`                                                      | `Master`        | 顯示指定Bot實例的&#8203;**[Steam點數商店](https://store.steampowered.com/points/shop)**&#8203;中的點數餘額。                                                                                                                                           |
| `privacy [Bots] <Settings>`                                    | `Master`        | 更改指定Bot實例的&#8203;**[Steam隱私設定](https://steamcommunity.com/my/edit/settings)**&#8203;，可用的選項請參閱&#8203;**[​下文](#privacy-指令中的-setting-引數)**&#8203;的說明。                                                                                   |
| `redeem [Bots] <Keys>`                                         | `Operator`      | 使指定的Bot實例啟用給定的產品序號或錢包儲值碼。                                                                                                                                                                                                            |
| `redeem^ [Bots] <Modes> <Keys>`                          | `Operator`      | 使指定的Bot實例啟用給定的產品序號或錢包儲值碼，並以&#8203;**[​下文](#redeem-指令中的-modes-引數)**&#8203;說明的&#8203;`Modes`&#8203;模式使用。                                                                                                                               |
| `reset [Bots]`                                                       | `Master`        | 將遊戲狀態重設為初始（先前的）狀態。本指令用於配合&#8203;`play`&#8203;指令的手動掛卡模式。                                                                                                                                                                              |
| `restart`                                                            | `Owner`         | 重新啟動ASF程序。                                                                                                                                                                                                                           |
| `resume [Bots]`                                                      | `FamilySharing` | 恢復指定Bot實例的自動掛卡程序。                                                                                                                                                                                                                    |
| `start [Bots]`                                                       | `Master`        | 啟動指定的Bot實例。                                                                                                                                                                                                                          |
| `stats`                                                              | `Owner`         | 顯示程序的統計資料，例如託管記憶體的使用量。                                                                                                                                                                                                               |
| `status [Bots]`                                                      | `FamilySharing` | 顯示指定Bot實例的狀態。                                                                                                                                                                                                                        |
| `std`                                                                | `Owner`         | 控制&#8203;**[`SteamTokenDumperPlugin`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/SteamTokenDumperPlugin-zh-TW)**&#8203;的特殊指令，用於立即提交資料。                                                                                      |
| `stop [Bots]`                                                        | `Master`        | 停止指定的Bot實例。                                                                                                                                                                                                                          |
| `tb [Bots]`                                                          | `Master`        | 列出指定Bot實例交易模組黑名單中的使用者。                                                                                                                                                                                                               |
| `tbadd [Bots] <SteamIDs64>`                                    | `Master`        | 將給定的&#8203;`SteamIDs64`&#8203;加入至指定Bot的實例交易模組黑名單中。                                                                                                                                                                                   |
| `tbrm [Bots] <SteamIDs64>`                                     | `Master`        | 將給定的&#8203;`SteamIDs64`&#8203;從指定Bot的實例交易模組黑名單中移除。                                                                                                                                                                                   |
| `transfer [Bots] <TargetBot>`                                  | `Master`        | 將指定Bot實例所有符合&#8203;`TransferableTypes`&#8203;類型的Steam社群物品交易給目標Bot實例。                                                                                                                                                                 |
| `transfer@ [Bots] <AppIDs> <TargetBot>`                  | `Master`        | 將指定Bot實例中，所有符合&#8203;`AppIDs`&#8203;及&#8203;`TransferableTypes`&#8203;類型的Steam社群物品，交易給目標Bot實例。 這是與&#8203;`transfer%`&#8203;相反的指令。                                                                                                    |
| `transfer% [Bots] <AppIDs> <TargetBot>`                  | `Master`        | 將指定Bot實例中，除符合&#8203;`AppIDs`&#8203;以外的所有&#8203;`TransferableTypes`&#8203;類型的Steam社群物品，交易給目標Bot實例。 這是與&#8203;`transfer@`&#8203;相反的指令。                                                                                                 |
| `transfer^ [Bots] <AppID> <ContextID> <TargetBot>` | `Master`        | 將指定Bot實例的&#8203;`ContextID`&#8203;中，符合&#8203;`AppID`&#8203;的Steam物品交易給目標Bot實例。                                                                                                                                                       |
| `unpack [Bots]`                                                      | `Master`        | 拆開指定Bot實例物品庫中的所有擴充包。                                                                                                                                                                                                                 |
| `update [Channel]`                                                   | `Owner`         | 檢查GitHub上是否有新的ASF版本，如果有則更新。 這通常每隔&#8203;`UpdatePeriod`&#8203;便會自動執行一次。 選擇性的&#8203;`Channel`&#8203;引數指定&#8203;`UpdateChannel`&#8203;，如未提供，預設使用全域設定中的值。                                                                                |
| `version`                                                            | `FamilySharing` | 顯示ASF的版本號碼。                                                                                                                                                                                                                          |

---

### 備註

所有的指令都不區分大小寫，但它們的引數（例如Bot的名稱）通常需要區分大小寫。

引數遵循著Unix哲學，方括號&#8203;`[Optional]`&#8203;代表給定的引數是選擇性的；而角括號&#8203;`<Mandatory>`&#8203;代表給定的引數是強制性的。 您應將要宣告的引數取代成您執行指令所需的實際值，例如&#8203;`[Bots]`&#8203;或&#8203;`<Nickname>`&#8203;，並一併省略括號。

`[Bots]`&#8203;引數，如括號所代表的，在所有指令中皆為選擇性的引數。 當指定該引數時，指令會在指定的Bot上執行。 但省略時，指令會在當前接收到指令的所有Bot上執行。 也就是說，向Bot &#8203;`B`&#8203;傳送&#8203;`status A`&#8203;，等於直接向Bot &#8203;`A`&#8203;傳送&#8203;`status`&#8203;指令。在這種情形下，Bot &#8203;`B`&#8203;只被作為一個代理Bot。 這也可用於向無法使用的Bot傳送指令，例如啟動已終止的Bot，或者在（您用於執行指令的）主要帳號上執行動作。

指令的&#8203;**存取權限**&#8203;定義了執行此指令所需的&#8203;**最低**&#8203;權限，即&#8203;`SteamUserPermissions`&#8203;中定義的&#8203;`EPermission`&#8203;。但有個例外，&#8203;`Owner`&#8203;是指全域設定檔中定義的&#8203;`SteamOwnerID`&#8203;使用者（擁有最高權限）。

複數引數，例如&#8203;`[Bots]`&#8203;、&#8203;`<Keys>`&#8203;或&#8203;`<AppIDs>`&#8203;，代表該引數支援多個由逗號分隔的相同類型數值。 舉例來說，&#8203;`status [Bots]`&#8203;可以輸入成&#8203;`status MyBot,MyOtherBot,Primary`&#8203;。 這樣，該指令會在&#8203;**所有的目標Bot**&#8203;上執行，效果等同於向所有的Bot分別傳送&#8203;`status`&#8203;指令。 需要注意的是，「&#8203;`,`&#8203;」後面不能有空格。

ASF使用所有的空白字元作為指令的定界符，例如空格和換行字元。 這代表您不僅可以使用空格來分隔引數，還可以使用任何其他空白字元（例如Tab及換行）。

ASF會將超出指令範圍的多餘引數「連接」至符合語法的最後一個複數引數上。 這代表對於&#8203;`redeem [Bots] <Keys>`&#8203;指令而言，&#8203;`redeem bot key1 key2 key3`&#8203;與&#8203;`redeem bot key1,key2,key3`&#8203;的作用完全相同。 再加上您可以使用換行作為指令定界符，這樣您就可以先輸入&#8203;`redeem bot`&#8203;，然後再貼上產品序號清單，其中的每一項可以由任意空白字元（例如換行字元）或者ASF的標準&#8203;`,`&#8203;作為定界。 請注意，若要使用這一技巧，您必須採用該指令引數數量最多的形式（因此在這種情形下，您就必須指定&#8203;`[Bots]`&#8203;引數）。

如上所述，空白字元被用於分隔指令參數，所以參數內部無法再使用空白字元。 但同樣如上所述，ASF可以連接超出範圍的引數。這代表您可以在指令的最後一個引數中，使用空白字元。 舉例來說，&#8203;`nickname bob Great Bob`&#8203;指令能夠將Bot &#8203;`bob`&#8203;的暱稱正確設定成「Great Bob」。 同理，您也可以使用&#8203;`owns`&#8203;指令來檢查帶有空格的名稱。

---

部分指令亦有別名可供使用，主要用於節省您輸入的時間，同時也與不同的指令語言相容。

| 指令           | 指令別名         |
| ------------ | ------------ |
| `addlicense` | `addlicence` |
| `owns ASF`   | `oa`         |
| `status ASF` | `sa`         |
| `redeem`     | `r`          |
| `redeem^`    | `r^`         |

---

### `[Bots]` 引數

`[Bots]`&#8203;是複數引數的一個特殊變體，除了能夠接收多個值以外，它還具有額外的功能。

首先，您可以使用特殊關鍵字&#8203;`ASF`&#8203;來表示「程序中的所有Bot」。因此&#8203;`status ASF`&#8203;指令等同於&#8203;`status 您,在此,列出的,所有,Bot`&#8203;。 這也可以方便地辨識您有權操作哪些Bot，因為儘管關鍵字&#8203;`ASF`&#8203;的目標是所有Bot，但只有您實際能夠傳送指令到的Bot才會作出回應。

`[Bots]`&#8203;引數支援特殊的「範圍」語法，這可以讓您更容易選擇特定範圍的Bot。 在這種情形下，&#8203;`[Bots]`&#8203;的一般語法是&#8203;`[FirstBot]..[LastBot]`&#8203;。 須至少定義一個引數。 使用&#8203;`<FirstBot>..`&#8203;時，從&#8203;`FirstBot`&#8203;開始，直到最後一個的所有Bot都會受到影響。 使用&#8203;`..<LastBot>`&#8203;時，從第一個開始，直到&#8203;`LastBot`&#8203;的所有Bot都會受到影響。 使用&#8203;`<FirstBot>..<LastBot>`&#8203;時，所有在&#8203;`FirstBot`&#8203;與&#8203;`LastBot`&#8203;間的Bot會受影響。 舉例來說，假設您有名為&#8203;`A, B, C, D, E, F`&#8203;的Bot，若您執行&#8203;`status B..E`&#8203;，等同於執行&#8203;`status B,C,D,E`&#8203;。 在使用此語法時，ASF將會以字母排序來決定哪些Bot在指定範圍內。 引數必須是ASF能夠辨識的有效Bot名稱，否則範圍與法將被不會生效。

除了上述的範圍語法，&#8203;`[Bots]`&#8203;引數還支援&#8203;**[正規表示式](https://zh.wikipedia.org/wiki/正则表达式)**&#8203;的檢索符合規則。 您可以使用&#8203;`r!<Pattern>`&#8203;作為Bot的名稱，來使用正規表示式。其中&#8203;`r!`&#8203;是ASF用於進入正規表示式檢索行為的啟動指令，而&#8203;`<Pattern>`&#8203;是您的正規表示式。 一個正規表示式的Bot指令範例：&#8203;`status r!^\d{3}`&#8203;，它會向所有名稱為3位數字的Bot（例如&#8203;`123`&#8203;及&#8203;`981`&#8203;）傳送&#8203;`status`&#8203;指令。 您可以閱讀這份&#8203;**[檔案說明](https://docs.microsoft.com/zh-tw/dotnet/standard/base-types/regular-expression-language-quick-reference)**&#8203;，來深入了解更多說明及範例。

---

## `privacy` 指令中的 Setting 引數

`<Settings>`&#8203;引數接受&#8203;**最多7個**&#8203;不同的選項，它使用了ASF的標準逗號定界格式。 這些選項分別是：

| 引數 | 名稱                      | 為…的子選項     |
| -- | ----------------------- | ---------- |
| 1  | Profile（我的個人檔案）         |            |
| 2  | OwnedGames（遊戲資料）        | Profile    |
| 3  | Playtime（遊玩時數）          | OwnedGames |
| 4  | FriendsList（好友名單）       | Profile    |
| 5  | Inventory（物品庫）          | Profile    |
| 6  | InventoryGifts（Steam禮物） | Inventory  |
| 7  | Comments（能在我的個人檔案發表留言）  | Profile    |

關於上述選項的說明，請造訪&#8203;**[Steam隱私設定](https://steamcommunity.com/my/edit/settings)**&#8203;。

每個選項的有效值可以是：

| 值 | 名稱                  |
| - | ------------------- |
| 1 | `Private（私人）`       |
| 2 | `FriendsOnly（僅限好友）` |
| 3 | `Public（公開）`        |

您可以使用它們的名稱（不區分大小寫）或數值。 未賦值的引數將會被設為預設值&#8203;`Private`&#8203;。 特別注意，上述引數的從屬關係非常重要，因為子選項無法擁有比父選項還高的權限。 舉例來說，若您將個人檔案設為&#8203;`Private`&#8203;，就&#8203;**無法**&#8203;再將遊戲資料設定成&#8203;`Public`&#8203;。

### 範例

如果希望將名為&#8203;`Main`&#8203;的Bot的&#8203;**所有**&#8203;隱私設定都設為`Private`&#8203;，您可以使用以下任一指令：

```text
privacy Main 1
privacy Main Private
```

這是因為ASF會將所有未賦值的選項設為&#8203;`Private`&#8203;，所以您無需將它們全部列出來。 反之，若您希望將所有選項設為&#8203;`Public`&#8203;，則可以使用以下任一指令：

```text
privacy Main 3,3,3,3,3,3,3
privacy Main Public,Public,Public,Public,Public,Public,Public
```

使用這種方式，您也可以為每個選項設定不同的值：

```text
privacy Main Public,FriendsOnly,Private,Public,Public,Private,Public
```

上述指令會將個人檔案設為公開、遊戲資料設為僅限好友、總遊玩時數為私人、好友名單為公開、物品庫為公開、物品庫禮物為私密、個人檔案留言為私人。 若有需要，您也可以使用數值來實現相同效果。

---

## `addlicense` 指令中的 Licenses 引數

`addlicense`&#8203;指令支援兩種不同的授權類型：

| 類型    | 別名  | 範例           | 描述                                            |
| ----- | --- | ------------ | --------------------------------------------- |
| `app` | `a` | `app/292030` | 透過遊戲的唯一&#8203;`appID`&#8203;授權。               |
| `sub` | `s` | `sub/47807`  | 透過遊戲組合包的唯一&#8203;`subID`&#8203;授權，包含一款或以上的遊戲。 |

需要注意這兩者的區別，因為以ASF來說，對於應用程式將會使用Steam網路來啟動，而對遊戲組合包則使用Steam商店來啟動。 這兩者互不相容。一般而言，您會對免費週末及永久免費遊玩的遊戲使用app類型，而對遊戲組合包使用sub。

我們建議您明確定義每一個項目的類型，以避免歧義。但為了反向相容性，在您提供了無效或省略的類型的情形下，ASF將會預設您想要使用&#8203;`sub`&#8203;類型。 您也可以使用ASF的標準定界符「&#8203;`,`&#8203;」來同時啟用多個授權。

完整的指令範例：

```text
addlicense ASF app/292030,sub/47807
```

---

## `owns` 指令中的 Games 引數

`owns`&#8203;指令支援數種不同的&#8203;`<games>`&#8203;引數類型：

| 類型      | 別名  | 範例               | 描述                                                                                                                                                                                                                                   |
| ------- | --- | ---------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| `app`   | `a` | `app/292030`     | 遊戲的唯一&#8203;`appID`&#8203;。                                                                                                                                                                                                          |
| `sub`   | `s` | `sub/47807`      | 遊戲組合包的唯一&#8203;`subID`&#8203;，包含一款或以上的遊戲。                                                                                                                                                                                            |
| `regex` | `r` | `regex/^\d{4}:` | 使用&#8203;**[正規表示式](https://zh.wikipedia.org/zh-tw/正则表达式)**&#8203;來表示遊戲名稱，區分大小寫。 請參閱&#8203;**[檔案說明](https://learn.microsoft.com/zh-tw/dotnet/standard/base-types/regular-expression-language-quick-reference)**&#8203;，來進一步了解完整語法及範例。 |
| `name`  | `n` | `name/Witcher`   | 遊戲的部分名稱，不區分大小寫。                                                                                                                                                                                                                      |

我們建議您明確定義每一個項目的類型，以避免歧義。但為了反向相容性，在您提供了無效或省略的類型的情形下，若您填入了數字，ASF將會預設您想要使用&#8203;`app`&#8203;類型，若為其他值則為&#8203;`name`&#8203;類型。 您也可以使用ASF的標準定界符「&#8203;`,`&#8203;」來同時查詢多個遊戲。

完整的指令範例：

```text
owns ASF app/292030,name/Witcher
```

---

## `redeem^` 指令中的 Modes 引數

`redeem^`&#8203;指令使您能夠微調使用於兌換單個產品序號情境的模式。 此指令會臨時覆蓋&#8203;`RedeemingPreferences`&#8203; &#8203;**[Bot設定屬性](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-zh-TW#Bot-設定檔)**&#8203;。

`<Modes>`&#8203;引數接受多個模式值，通常使用逗號分隔。 可用的模式值如下：

| 值    | 名稱                    | 描述                                                            |
| ---- | --------------------- | ------------------------------------------------------------- |
| FAWK | ForceAssumeWalletKey  | 強制啟用&#8203;`AssumeWalletKeyOnBadActivationCode`&#8203;兌換偏好設定。 |
| FD   | ForceDistributing     | 強制啟用&#8203;`Distributing`&#8203;兌換偏好設定。                       |
| FF   | ForceForwarding       | 強制啟用&#8203;`Forwarding`&#8203;兌換偏好設定。                         |
| FKMG | ForceKeepMissingGames | 強制啟用&#8203;`KeepMissingGames`&#8203;兌換偏好設定。                   |
| SAWK | SkipAssumeWalletKey   | 強制停用&#8203;`AssumeWalletKeyOnBadActivationCode`&#8203;兌換偏好設定。 |
| SD   | SkipDistributing      | 強制停用&#8203;`Distributing`&#8203;兌換偏好設定。                       |
| SF   | SkipForwarding        | 強制停用&#8203;`Forwarding`&#8203;兌換偏好設定。                         |
| SI   | SkipInitial           | 產品序號兌換過程跳過第一個Bot。                                             |
| SKMG | SkipKeepMissingGames  | 強制停用&#8203;`KeepMissingGames`&#8203;兌換偏好設定。                   |
| V    | Validate              | 檢查序號格式，自動跳過無效的產品序號。                                           |

舉例來說，我們打算為任何尚未擁有遊戲的Bot兌換3個產品序號，但不包含&#8203;`primary`&#8203; Bot。 為此，我們需要執行指令：

`redeem^ primary FF,SI key1,key2,key3`

需要注意的是，進階兌換模式只會替換您&#8203;**在指令中指定**&#8203;的&#8203;`RedeemingPreferences`&#8203;選項。 舉例來說，若您在&#8203;`RedeemingPreferences`&#8203;中啟用了&#8203;`Distributing`&#8203;，那麼無論是否使用&#8203;`FD`&#8203;模式，都不會有任何區別，因為您已經在&#8203;`RedeemingPreferences`&#8203;中啟用了它。 這就是為什麼每個可強制啟用的模式，也會有一個可強制停用的選項。您可以將被停用的選項強制覆蓋成啟用，相反的狀況亦可。

---

## `encrypt` 指令

`encrypt`&#8203;指令使您能夠使用ASF的加密方式加密任意字串。 加密方式&#8203;`<encryptionMethod>`&#8203;必須是&#8203;**[安全性](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security-zh-TW)**&#8203;章節所述方式之一。 我們建議透過安全的通道（ASF控制台、ASF-ui或IPC提供的專用API端點）使用本指令，否則敏感性資訊可能會被第三方記錄（例如聊天訊息會被Steam伺服器記錄）。

---

## `hash` 指令

`hash`&#8203;指令使您能夠使用ASF的雜湊方式，產生任意字串的雜湊值。 雜湊方式&#8203;`<hashingMethod>`&#8203;必須是&#8203;**[安全性](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security-zh-TW)**&#8203;章節所述方式之一。 我們建議透過安全的通道（ASF控制台、ASF-ui或IPC提供的專用API端點）使用此指令，否則敏感資訊可能會被第三方記錄（例如聊天訊息會被Steam伺服器記錄）。

---

## `input` 指令

`input`&#8203;指令僅可在&#8203;`Headless`&#8203;模式下使用。在ASF無法接受使用者輸入的情形下，透過&#8203;**[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-zh-TW)**&#8203;或Steam聊天來輸入資料。

基本語法為&#8203;`input [Bots] <Type> <Value>`&#8203;。

`<Type>`&#8203;不區分大小寫，定義ASF可識別的輸入類型。 目前ASF可識別以下類型：

| 類型                      | 描述                                             |
| ----------------------- | ---------------------------------------------- |
| Login                   | `SteamLogin`&#8203; Bot設定屬性，設定檔遺失時使用此值。        |
| Password                | `SteamPassword`&#8203; Bot設定屬性，設定檔遺失時使用此值。     |
| SteamGuard              | 如果您未啟用雙重驗證，驗證碼將以電子郵件的方式發送。                     |
| SteamParentalCode       | `SteamParentalCode`&#8203; Bot設定屬性，設定檔遺失時使用此值。 |
| TwoFactorAuthentication | 如果您啟用雙重驗證但並非ASF雙重驗證，雙重驗證權杖將由您的手機生成。            |
| DeviceConfirmation      | 決定登入確認請求是否已被接受                                 |

`<Value>`&#8203;是要為指定類型設定的值。 目前所有的值都屬於字串。

### 範例

假設我們有一個未啟用雙重驗證，僅由Steam Guard保護的Bot。 我們希望在&#8203;`Headless`&#8203;為&#8203;`true`&#8203;的情形下啟動這個Bot。

為此，我們需要執行以下指令：

`start MySteamGuardBot`&#8203; -> Bot將嘗試登入，但會因為缺少驗證碼而登入失敗，然後因為ASF處於&#8203;`Headless`&#8203;模式，Bot會停止執行。 我們做這一步的目的，是讓Steam網路透過電子郵件向我們傳送驗證碼⸺若不需要，我們可以直接跳過此步驟。

`input MySteamGuardBot SteamGuard ABCDE`&#8203; -> 我們將&#8203;`MySteamGuardBot`&#8203; Bot的&#8203;`SteamGuard`&#8203;輸入設定成&#8203;`ABCDE`&#8203;。 當然在這種情形下，&#8203;`ABCDE`&#8203;就是我們從電子郵件中獲得的驗證碼。

`start MySteamGuardBot`&#8203; -> 我們重新啟動已停止的Bot。這一次，會自動使用我們在上個步驟中設定的驗證碼，登入將會成功，且之前輸入的驗證碼會被清除。

以同樣的方式，我們可以存取受雙重驗證保護的Bot（如果它們不使用ASF雙重驗證），只需在執行時設定其他必需屬性即可。