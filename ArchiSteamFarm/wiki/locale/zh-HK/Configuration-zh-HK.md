# 配置

此頁面專門用於 ASF 配置。 提供關於 `config` 目錄的完整文件，允許您依照您的需求調整 ASF。

* **[介紹](#introduction)**
* **[網頁設定檔產生器](#web-based-configgenerator)**
* **[ASF-ui configuration](#asf-ui-configuration)**
* **[手動配置](#manual-configuration)**
* **[全域配置](#global-config)**
* **[機械人配置](#bot-config)**
* **[檔案結構](#file-structure)**
* **[JSON 映射](#json-mapping)**
* **[兼容性映射](#compatibility-mapping)**
* **[配置兼容性](#configs-compatibility)**
* **[自動重載](#auto-reload)**

---

## 介紹

ASF配置分為兩個主要部分──全域（流程）配置和每個機械人的配置。 每個機械人都有自己的機械人設定檔，名為 `BotName.json`（其中 `BotName` 是機械人的名稱），而全域 ASF（進程）配置是一個名為 `ASF.json` 的檔。

每個機械人都是一個在 ASF 進程中運行的獨立的 Steam 帳戶。 為了能夠正常工作，ASF 需要定義**至少一個**機械人實例。 機械人實例沒有過程強制限制，因此您可以根據需要使用任意數量的機械人(Steam帳戶)。

ASF使用 **[JSON](https://en.wikipedia.org/wiki/JSON)** 格式來存儲其設定檔。 它是人性化的、可讀的、廣泛適用的格式，您可以在其中對程式進行配置。 不過不用擔心，您不需要為了配置 ASF 去專門了解 JSON。 我提到它只是考慮到您可能會想要使用某種 Bash 腳本批量創建大量 ASF 配置檔案。

Configuration can be done in several ways. You can use our **[Web-based ConfigGenerator](https://justarchinet.github.io/ASF-WebConfigGenerator)**, which is a local app independent of ASF. You can use our **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)** IPC frontend for configuration done directly in ASF. Lastly, you can always generate config files manually, as they follow fixed JSON structure specified below. We'll explain shortly the available options.

---

## 網頁設定檔產生器

The purpose of our **[Web-based ConfigGenerator](https://justarchinet.github.io/ASF-WebConfigGenerator)** is to provide you with a friendly frontend that is used for generating ASF configuration files. 網頁設定檔產生器是100% 基於用戶端的，這意味著您輸入的詳細資訊都不會被上傳，而只在本地處理。 這保證了安全性和可靠性，因為如果您願意下載所有相關檔案，併在您喜愛的瀏覽器中打開其中的 `index.html`，它甚至可以​**[離線](https://github.com/JustArchiNET/ASF-WebConfigGenerator/tree/main/docs)**​工作。

網頁設定檔產生器已經在 Chrome 和 Firefox 上經過驗證可以正常運行，但它也應該可以在所有流行的支援 JavaScript 的瀏覽器中正常工作。

它的用法非常簡單──切換到正確的標簽來選擇要生成 `ASF` 設定檔還是 `Bot（機械人）`設定檔，確保所選設定檔的版本與您的 ASF 版本相匹配，然後輸入所有詳細信息並點擊「下載」按鈕。 將此檔移動到 ASF `config` 目錄，如果需要，將覆蓋現有檔。 如果要繼續配置，則重覆以上操作，並參考本頁的其他部分以了解所有可用的選項。

---

## ASF-ui configuration

Our **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)** IPC interface allows you to configure ASF as well, and is superior solution for reconfiguring ASF after generating the initial configs due to the fact that it can edit the configs in-place, as opposed to Web-based ConfigGenerator which generates them statically.

In order to use ASF-ui, you must have our **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)** interface enabled itself. `IPC` is enabled by default, therefore you can access it right away, as long as you didn't disable it yourself.

After launching the program, simply navigate to ASF's **[IPC address](http://localhost:1242)**. If everything worked properly, you can change ASF configuration from there as well.

---

## 手動配置

In general we strongly recommend using either our ConfigGenerator or ASF-ui, as it's much easier and ensures you won't make a mistake in the JSON structure, but if for some reason you don't want to, then you can also create proper configs manually. Check JSON examples below for a good start in proper structure, you can copy the content into a file and use it as a base for your config. Since you're not using any of our frontends, ensure that your config is **[valid](https://jsonlint.com)**, as ASF will refuse to load it if it can't be parsed. Even if it's a valid JSON, you also have to ensure that all the properties have the proper type, as required by ASF. For proper JSON structure of all available fields, refer to **[JSON mapping](#json-mapping)** section and our documentation below.

---

## 全域配置

全域配置位於 `ASF.json` 檔中，具有以下結構：

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

以下是對所有選項的解釋：

### `AutoRestart`

預設值為 `true` 的 `bool` 類型。 此屬性定義是否允許 ASF 在需要時自行重啟。 有一些事件需要 ASF 自行重啟，例如 ASF 更新（通過 `UpdatePeriod` 或 `update` 命令完成），以及 `ASF.json` 配置的編輯、`restart` 命令等。 通常情況下，重啟包括兩個部分──創建新流程和完成當前流程。 但是，大多數使用者應該可以使用它並保留屬性預設值為 `true`──如果您正在通過自己的腳本運行 ASF，或者使用 `dotnet` 運行 ASF，則可能希望完全控制進程的啟動，並避免以下情況：使新的（重啟）ASF進程在後台靜默運行，而不是在腳本的前景中運行，這些進程與舊的ASF進程一起退出。 考慮到新的流程將不再是您原有流程的直接分支，這一點尤其重要，這將使您無法使用標準的主控台輸入。

在此屬性僅為您服務的情況下，您可以將其設置為 `false`。 但是，請記住，在這種情況下 **您** 負責重啟進程。 這在某種程度上很重要，因為ASF將僅退出，而非生成新的進程（例如更新後），因此，如果您沒有添加邏輯，它將停止工作，直到您再次啟動它。 ASF總是使用指示成功（零）或非成功（非零）的錯誤代碼退出，這樣您就可以在腳本中添加合適的邏輯，從而避免在出現故障時自動重啟ASF，或者至少製作 `log.txt` 的本機複本以獲得進一步的應用分析。 還要記住，無論此屬性設置的方式如何，`restart` 命令都將始終重啟 ASF，因為此屬性定義預設行為，而 `restart` 命令始終會重新啟動進程。 除非您有理由禁用此功能，否則應保持啟用它。

---

### `Blacklist`

預設值為空的 `ImmutableHashSet<uint>` 類型。 As the name suggests, this global config property defines appIDs (games) that will be entirely ignored by automatic ASF farming process. 不幸的是，Steam喜歡將夏季/冬季銷售徽章標記為「有卡掉落」，這欺騙了ASF進程，使其相信這是一個可以掛卡的遊戲。 如果沒有任何黑名單，ASF最終會「掛」一個并不存在的遊戲，並無限等待𣎴存在的卡牌掉落。 ASF黑名單的目的是將這些徽章標記為不可掛卡，因此，我們在掛卡時可以忽視這些徽章，而避免落入陷阱。

ASF includes two blacklists by default - `SalesBlacklist`, which is hardcoded into the ASF code and not possible to edit, and normal `Blacklist`, which is defined here. `SalesBlacklist` is updated together with ASF version and typically includes all "bad" appIDs at the time of release, so if you're using up-to-date ASF then you do not need to maintain your own `Blacklist` defined here. 此屬性的主要目的是允許您將在ASF發佈時未知的新appIDs設置為黑名單，不予掛卡。 Hardcoded `SalesBlacklist` is being updated as fast as possible, therefore you're not required to update your own `Blacklist` if you're using latest ASF version, but without `Blacklist` you'd be forced to update ASF in order to "keep running" when Valve releases new sale badge - I don't want to force you to use latest ASF code, therefore this property is here to allow you "fixing" ASF yourself if you for some reason don't want to, or can't, update to new hardcoded `SalesBlacklist` in new ASF release, yet you want to keep your old ASF running. 除非您有**強烈**的修改意願，否則應保持它為预設值。

If you're looking for bot-based blacklist instead, take a look at `fb`, `fbadd` and `fbrm` **[commands](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**.

---

### `CommandPrefix`

預設值為 `！` 的 `string` 類型。 此屬性指定用於ASF**[命令](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** 的**大小寫敏感** 首碼。 換句話說，這是您需要在每個 ASF 命令之前加上的內容，以使ASF偵聽命令。 可以將此值設置為 `null` 或空，以讓 ASF 不使用命令首碼，在這種情況下，您可以使用其普通識別碼輸入命令。 但是，這樣做可能會降低ASF的性能，因為ASF 經過優化，如果不從 `CommandPrefix` 開始，就不會進一步分析消息──如果您有意決定不使用它，ASF將被迫讀取所有消息並對其做出回應，即使它們不是ASF 命令。 因此，如果您不想使用預設值 `! `，建議您繼續使用某些 `CommandPrefix`，如 `/`。 為了保持一致， `CommandPrefix` 會影響整個 ASF 進程。 除非您有充分的修改理由，否則應保持它為預設值。

---

### `ConfirmationsLimiterDelay`

這是一個預設值為`10`的`byte`類型屬性。 ASF將確保兩次2FA確認請求之間至少有`ConfirmationsLimiterDelay`秒的時延，以免觸發速率限制──這將用於**[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)**執行`2faok`命令或其他交易相關操作。 預設值基於我們的測試設定, 如果您不想遇到問題, 則不應降低預設值。 除非您有**強烈**的修改意願，否則應保持它為预設值。

---

### `ConnectionTimeout`

這是一個預設值為`90` 的 `byte flags` 類型屬性。 此屬性定義 ASF執行的各種網路操作的超時 (以秒為單位)。 簡而言之, `ConnectionTimeout` 定義了 HTTP 和 IPC 請求的超時(秒數）, `ConnectionTimeout ` 定義了失敗活動訊號的最大數量, 而 `ConnectionTimeout/30 ` 定義了我們允許初始 Steam 網路連接請求的分鐘數。 ` 90 ` 的預設值對大多數人來說應該是合適的，但是，如果您的網路連接或PC速度相當慢，您可能希望稍微增大此值（如 ` 120 `）。 請記住, 即使是更大的值亦無法神奇地修復緩慢甚至無法訪問的 Steam 伺服器, 因此我們不應該無限等待不會發生的事情, 只需稍後再試。 如果將此值設置得過高, 將導致捕獲網路問題的過度延遲, 並降低整體性能。 將此值設置得過低也會降低整體穩定性和性能, 因為ASF將中止仍在分析的有效請求。 因此，將此值設置為低於預設值通常沒有優勢，因為 Steam伺服器往往有時會非常慢，並且可能需要更多的時間來分析ASF請求。 預設值是在相信我們的網路連接是穩定的和懷疑蒸汽網路在給定的超時下處理我們的請求之間的平衡。 如果您想更早地發現問題並使ASF的重新連接/回應速度更快, 預設值應該設為 (或略低於, 如 ` 60 `, 從而減少ASF 的等待時間)。 如果您注意到 ASF 遇到了網絡問題，例如失敗的請求、失去心跳或與 Steam 的連接中斷，那麼如果您確定此問題是由您的網絡，而**非**Steam本身造成，則增加此值可能是有意義的，因為增加超時使ASF 更“有耐心”，而不是決定立即重新連接。

一個可能需要增加此屬性的示例情況是讓ASF處理一個非常巨大的交易提案，可能需要大于2分鐘的時間才能被Steam完全接受並處理。 通過增加超時的預設值, 在決定放棄交易之前，ASF 將更有耐心, 等待更長的時間。

另一種情況可能是由於機器或互聯網連接非常慢, 需要更多的時間來處理正在傳輸的資料。 這是非常罕見的情況, 因為CPU\ 網路頻寬幾乎從來都不是瓶頸, 但這仍然是一個值得提及的可能性。

簡而言之, 預設值在大多數情況下應該是合適的, 但若需要，您可能要增加預設值。 不過，遠遠高於預設值也沒有多大意義，因為更大的超時亦無修復無法訪問的Steam 伺服器的魔法。 除非您有充分的修改理由，否則應保持它為預設值。

---

### `CurrentCulture`

預設值為 `null` 的 `string` 類型。 預設情況下，ASF將嘗試使用您的操作系統語言，並且更願意使用該語言中的翻譯字串（如果可用）。 這應感謝我們的社區成員，他們致力於推動ASF在各種主流語言中的**[本土化](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Localization)**進程。 如果由於某種原因您不想使用本機語言，則可以使用此配置屬性選擇要使用的任何有效語言。 有關所有可用語系的清單，請訪問 **[MSDN](https://msdn.microsoft.com/en-us/library/cc233982.aspx)**並查找`語言標籤`。 It's nice to note that ASF accepts both specific cultures, such as `"en-GB"`, but also neutral ones, such as `"en"`. 指定當前語系還可能會影響其他依賴於語系的行為，如貨幣/日期格式等。 請注意，如果您選擇非本機語言，則可能需要額外的字體/語言包來正確顯示所選語言的字元。 通常，如果您更喜歡讓ASF使用英語而不是您的母語，則需使用此配置屬性。

---

### `Debug`

預設值為 `false` 的 `bool` 類型。 此屬性定義進程是否應在偵錯模式下運行。 在偵錯模式下，ASF會在 `config` 旁邊創建一個特殊的 `debug` 目錄，用於跟蹤ASF和 Steam 伺服器之間的整體通信。 調試資訊有助於發現與網絡和一般ASF工作流相關的棘手問題。 除此之外，某些程式常式將更加詳細，例如 `WebBrowser` 將會說明請求失敗的確切原因──這些條目將被寫入正常的ASF日誌中。 **除非開發人員提出要求，否則您不應在偵錯模式下運行ASF。** 在偵錯模式 **下運行ASF會降低性能**，**不利於穩定性**，並且是 **生成過多訊息**，因此建議 **僅需要時**使用，以用於調試特定問題、重現錯誤或獲取有關失敗請求的更多資訊，但 **不應**在正常情況下運行此模式。 您將看到**一堆**新的錯誤、問題和異常──如果您決定自己分析所有這些內容，請確保您對ASF及Steam有充分的瞭解，因為並非所有內容都與問題相關。

**警告：** 啟用此模式將記錄 **潜在的敏感**資訊，如登錄名和用於登錄到Steam的密碼（以作網絡日誌記錄）。 這些資料既寫入 `debug` 目錄，也寫入標準 `log.txt` (此資訊將被詳細地記錄)。 您不應該在任何公共位置發佈 ASF生成的調試內容，ASF 開發人員始終提醒您應將其發送到他的電子郵件或其他安全位置。 我們不會儲存或利用這些敏感資訊，他們只是作為可能的錯誤因素被記錄於調試內容中。 我們更希望您不以任何方式改變ASF日誌記錄，但如果您擔心，您可以編輯這些敏感的細節。

> 您可以用特殊符號替換敏感的細節，例如**。 你應該避免完全刪除敏感的數據，因為它們的存在可能與問題相關，應該予以保留。

---

### `DefaultBot`

預設值為 `null` 的 `string` 類型。 In some scenarios ASF functions with a concept of a default bot responsible for handling something - for example IPC commands or interactive console when you don't specify target bot. This property allows you to choose default bot responsible for handling such scenarios, by putting its `BotName` here. If given bot doesn't exist, or you use a default value of `null`, ASF will pick first registered bot sorted alphabetically instead. Typically you want to make use of this config property if you want to omit `[Bots]` argument in IPC and interactive console commands, and always pick the same bot as the default one for such calls.

---

### `FarmingDelay`

這是一個預設值為`15` 的 `byte flags` 類型屬性。 ASF會在工作時每`FarmingDelay`分鐘檢查當前掛卡的遊戲是否已經掉落了所有的卡片。 將此屬性設置得過低可能會導致發送過多的Steam請求，而設置過高可能會導致ASF在掛卡完成之後仍然「工作」達`farmingdelay` 分鐘。 預設值應該是適合大多數用戶的，如果您有許多機械人在運行，則可以考慮將其增加至類似 `30` 分鐘，以限制發送Steam請求。 值得一提的是，ASF使用基於事件的機制，會在收到每個掉落的Steam物品時檢查遊戲徽章頁面，所以通常**我們甚至不需要每隔一定時間檢查**，但由於我們不能完全信任Steam網絡──我們仍然需要手動檢查遊戲徽章頁面，如果我們未能在`FarmingDelay` 分鐘內檢查卡片掉落事件（萬一Steam網路沒有通知我們有關物品掉落或類似的資訊）。 假設Steam網絡工作正常，降低此值 **不會以任何方式提高掛卡效率**，而 **只會顯著增加網絡開銷**──建議保持`15`分鐘的預設值（並僅在需要時才增加它）。 除非您有**強烈**的修改意願，否則應保持它為预設值。

---

### `FilterBadBots`

預設值為 `true` 的 `bool` 類型。 This property defines whether ASF will automatically decline trade offers that are received from known and marked bad actors. In order to do that, ASF will communicate with our server on as-needed basis to fetch a list of blacklisted Steam identificators. The bots listed are operated by people that are classified as harmful towards ASF initiative by us, such as those that violate our **[code of conduct](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/.github/CODE_OF_CONDUCT.md)**, use provided functionality and resources by us such as **[`PublicListing`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#publiclisting)** in order to abuse and exploit other people, or are doing outright criminal activity such as launching DDoS attacks on the server. Since ASF has strong stance on overall fairness, honesty and cooperation between its users in order to make the whole community thrive, this property is enabled by default, and therefore ASF filters bots that we've classified as harmful from services offered. Unless you have a **strong** reason to edit this property, such as disagreeing with our statement and intentionally allowing those bots to operate (including exploiting your accounts), you should keep it at default.

---

### `GiftsLimiterDelay`

這是一個預設值為`1` 的 `byte flags` 類型屬性。 ASF將確保每兩個連續的對遊戲/序號/許可證的處理（兌換）請求之間至少間隔`GiftsLimiterDelay`秒，以避免觸發速率限制。 In addition to that it'll also be used as global limiter for game list requests, such as the one issued by `owns` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Unless you have a **strong** reason to edit this property, you should keep it at default.

---

### `Headless`

預設值為 `false` 的 `bool` 類型。 此屬性定義進程是否應在Headless模式下運行。 在 Headless 模式下，ASF 假定它在服務器或其他非交互式環境中運行，因此它不會嘗試通過控制台輸入讀取任何信息。 這包括需要的詳細信息（帳戶憑據，如 2FA 代碼，SteamGuard 代碼，密碼或 ASF 運行所需的任何其他變數）以及所有其他控制台輸入（如交互式命令控制台）。 換句話說，` Headless `模式等同於將 ASF 控制台設置為唯讀。 此設置主要用於在其服務器上運行 ASF 的用戶，當 ASF 需要與用戶交互，例如詢問 2FA 代碼時，ASF將通過停止帳戶以中止操作。 除非您在伺服器上運行ASF，並且您以前已確認ASF能夠在non-headless模式下運行，否則應禁用此屬性。 Any user interaction will be denied when in headless mode, and your accounts will not run if they require **any** console input during starting. 這對伺服器很有用，因為ASF可以在要求提供憑據時中止登錄帳戶的嘗試，而不是（無限）地等待用戶提供這些憑據。 Enabling this mode will also allow you to use `input` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** which acts as a replacement for standard console input. 如果您不確定該如何設置此屬性，請將其保留為預設值`false`。

If you're running ASF on the server, you probably want to use this option together with `--process-required` **[command-line argument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments)**.

---

### `IdleFarmingPeriod`

這是一個預設值為`8`的`byte flags`類型屬性。 當ASF沒有任何可掛卡的遊戲時，它將每`IdleFarmingPeriod`小時定期檢查帳戶內是否有一些新的遊戲可供掛卡。 當我們獲得新遊戲時，並不需要此功能，因為ASF足夠智能，可以在這種情況下自動檢查徽章頁。 `IdleFarmingPeriod`主要用於帳戶中已有的遊戲新增卡片的情況。 在這種情況下沒有事件被觸發，因此ASF必須定期檢查徽章頁。 將此值設置為`0`可禁用此功能。 Also check: `ShutdownOnFarmingFinished` preference in `FarmingPreferences`.

---

### `InventoryLimiterDelay`

`byte` type with default value of `4`. ASF will ensure that there will be at least `InventoryLimiterDelay` seconds in between of two consecutive inventory requests to avoid triggering rate-limit - those are being used for fetching Steam inventories, especially during your own commands such as `loot` or `transfer`. Default value of `4` was set based on fetching inventories of over 100 consecutive bot instances, and should satisfy most (if not all) of the users. 但是，如果您的機械人很少，可能希望減少此值，甚至將其更改為`0`，以讓ASF忽略延遲並加快拾取Steam庫存。 不過要注意的是，將此值設置得太低**將會**導致Steam暫時封禁您的IP以徹底防止您獲取您的庫存。 如果您運行大量的的機械人並有大量庫存請求，則可能還需要增加此值，不過在這種情況下，您可能更應該嘗試限制這些請求的數量。 除非您有**強烈**的修改意願，否則應保持它為预設值。

---

### `IPC`

預設值為 `true` 的 `bool` 類型。 此屬性定義了ASF的**[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)**伺服器是否應與主進程一同啟動。 IPC allows for inter-process communication, including usage of **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)**, by booting a local HTTP server. If you do not intend to use any third-party IPC integration with ASF, including our ASF-ui, you can safely disable this option. Otherwise, it's a good idea to keep it enabled (default option).

---

### `IPCPassword`

預設值為 `null` 的 `string` 類型。 此屬性為通過IPC執行的每個API定義強制性密碼，作為額外的安全措施。 當此值非空時，所有IPC請求都需要將額外的`password`屬性設置為此處指定的密碼。 預設值為`null`將使ASF跳過密碼驗證而接受所有請求。 除此之外，啟用此選項還啟用了內置的IPC反暴力破解機制，該機制將在偵聽到某`IPAddress`在短時間內發送過多未經授權的請求後，暫時封禁它。 除非您有充分的修改理由，否則應保持它為預設值。

---

### `IPCPasswordFormat`

這是一個預設值為`0` 的 `byte flags` 類型。 This property defines the format of `IPCPassword` property and uses `EHashingMethod` as underlying type. Please refer to **[Security](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security)** section if you want to learn more, as you'll need to ensure that `IPCPassword` property indeed includes password in matching `IPCPasswordFormat`. In other words, when you change `IPCPasswordFormat` then your `IPCPassword` should be **already** in that format, not just aiming to be. 除非你知道自己在做什麼，否則你應該保留預設值` 0 `。

---

### `LicenseID`

`Guid?` type with default value of `null`. This property allows our **[sponsors](https://github.com/sponsors/JustArchi)** to enhance ASF with optional features that require paid resources to work. For now, this allows you to make use of **[`MatchActively`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#matchactively)** feature in `ItemsMatcher` plugin.

While we recommend you to utilize GitHub since it offers monthly and one-time tiers, as well as allows full automation and gives you immediate access, we **also** support all other currently-available **[donation options](https://github.com/JustArchiNET/ArchiSteamFarm#archisteamfarm)**. See **[this post](https://github.com/JustArchiNET/ArchiSteamFarm/discussions/2780#discussioncomment-4486091)** for instructions on how to donate using other methods in order to get a manual license valid for given period.

Regardless of the method used, if you're ASF sponsor, you can obtain your license **[here](https://asf.justarchi.net/User/Status)**. You'll need to sign in with GitHub for confirming your identity, we ask only for read-only public information, which is your username. `LicenseID` is made out of 32 hexadecimal characters, such as `f6a0529813f74d119982eb4fe43a9a24`.

**Ensure that you do not share your `LicenseID` with other people**. Since it's issued on personal basis, it might get revoked if it's leaked. If by any chance this happened to you accidentally, you can generate a new one from the same place.

Unless you want to enable extra ASF functionalities, there is no need for you to provide the license.

---

### `LoginLimiterDelay`

這是一個預設值為`10`的`byte`類型屬性。 ASF 將確保每兩次連接請求之間至少間隔`LoginLimiterDelay`秒以避免觸發速率限制。 預設值 `10` 是基於連接100多個機械人實例的情況設置的，應該適用於大多數（如果不是全部）用戶。 但是，您可能希望增加/減少它，如果您的機械人數量非常少，您可能甚至想將其更改為 `0 0`，這樣 ASF 將忽略延遲並更快地連接到 Steam。 不過，請注意，若是在大量機械人同時工作時，將此值設置得太低**會**導致Steam暫時封禁您的 IP，這將觸發`InvalidPassword/RateLimitExceeded` 錯誤，**徹底**阻止您的登錄──不僅是 ASF，還包括您的 Steam 客戶端。 同樣，如果您需要運行大量機械人，特別是與使用相同 IP 位址的其他 Steam 用戶端/工具一起運行，則很可能需要增加此值，以將登錄請求分散到更長的時間段。

附註，此值還用於所有 ASF-計畫操作的負載平衡緩衝區，例如交易模塊中的 `SendTradePeriod`。 除非您有**強烈**的修改意願，否則應保持它為预設值。

---

### `MaxFarmingTime`

這是一個預設值為`10`的`byte`類型屬性。 As you should know, Steam is not always working properly, sometimes weird situations can happen such as our playtime not being recorded, despite of, in fact, playing a game. ASF 將在 solo 模式下最多對一個遊戲掛卡`MaxFarmingTime`小時，並認為它在該時間後完成所有掛卡進程。 為了避免掛卡過程停滯不前，這是必需的，但如果由於某種原因 Steam 發佈了一個新的徽章，此徽章可能將阻撓 ASF 的掛卡進展（見：`黑名單`）。 預設值 `10` 小時應該足以從一個遊戲中獲取所有Steam卡。 將此屬性設置得過低可能會導致跳過有效的遊戲（是的，有些遊戲甚至需要長達9個小時才能完全完成掛卡），而設置得過高可能會導致掛卡過程停滯不前。 請注意，此屬性僅影響單個掛卡進程中的單個遊戲（因此在完成整個隊列後 ASF 將返回該標題），它也不是基於遊戲總時間而是基於 ASF 內部掛卡時間，因此 ASF 也將在重啟後返回到該標題。 除非您有**強烈**的修改意願，否則應保持它為预設值。

---

### `MaxTradeHoldDuration`

這是一個預設值為`15` 的 `byte flags` 類型屬性。 此屬性定義了我們願意接受多長時間的交易暫掛——如**[交易](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading)**一節中所述， ASF 將拒絕暫掛期超過`MaxTradeHoldDuration`天的交易提案。 此選項僅用於在`TradingPreferences`中啟用`SteamTradeMatcher`的機械人，因為它不影響來自`Master`/`SteamOwnerID`的交易，或是捐贈。 交易暫掛是很煩人的，沒人會想被它困擾。 ASF 應該在自由規則下工作，並幫助每個人，無論是否存在交易暫掛——這就是為什麼此選項的預設值為` 15 `。 不過，如果您更希望拒絕所有會被暫掛的交易提案，您可以將此值設置為`0`。 請考慮這樣一個事實：短期內會失效的卡不受此選項的影響，並且 ASF 會自動拒絕存在暫掛的交易，如**<a href =“https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading“>交易</a>**部分中所述，所以沒有必要因為這個原因而拒絕所有的人。 除非您有充分的修改理由，否則應保持它為預設值。


---

### `MinFarmingDelayAfterBlock`

這是一個預設值為`60`的`byte`類型屬性。 This property defines minimum amount of time, in seconds, which ASF will wait before resuming cards farming if it got previously disconnected with `LoggedInElsewhere`, which happens when you decide to forcefully disconnect currently-farming ASF by launching a game. This delay exists mainly for convenience and overhead reasons, for example it allows you to restart the game without having to fight with ASF occupying your account again only because playing lock was available for a split second. Due to the fact that reclaiming the session causes `LoggedInElsewhere` disconnect, ASF has to go through whole reconnect procedure, which puts additional pressure on the machine and Steam network, therefore avoiding additional disconnects, if possible, is preferable. By default, this is configured at `60` seconds, which should be enough to allow you restart the game without much hassle. However, there are scenarios when you could be interested in increasing it, for example if your network disconnects often and ASF is taking over too soon, which causes being forced to go through the reconnect process yourself. We allow a maximum value of `255` for this property, which should be enough for all common scenarios. In addition to the above, it's also possible to decrease the delay, or even remove it entirely with a value of `0`, although that is usually not recommended due to reasons stated above. 除非您有充分的修改理由，否則應保持它為預設值。

---

### `OptimizationMode`

這是一個預設值為`0` 的 `byte flags` 類型。 此屬性定義 ASF 在運行時偏好的優化模式。 當前 ASF 支援兩種模式——`0`，即`MaxPerformance`；`1`，即`MinMemoryUsage`。 預設情況下，ASF希望盡可能多地並行（同時）運行，這通過跨所有 CPU 內核、多個 CPU 執行緒、多個通訊端和多個執行緒池任務的負載平衡工作來提高性能。 For example, ASF will ask for your first badge page when checking for games to farm, and then once request arrived, ASF will read from it how many badge pages you actually have, then request each other one concurrently. 這**應該總是**您想想要的，因為它在大多數情況下能使開銷最小化，甚至在單個 CPu 內核和功耗極大的最舊硬體上也能看到異步 ASF 代碼的好處。 但是，由於許多任務是並行處理的，因此 ASF 運行時負責維護它們，例如， 保持套接字打開，線程處於活動狀態並處理正在處理的任務，這可能會不時增加記憶體使用量，如果您受可用記憶體的限制，可能需要將此屬性切換為` 1 ` （` MinMemoryUsage `）以強制 ASF 盡可能少地使用任務，並且通常以同步方式運行可能的並行異步代碼。 You should consider switching this property only if you previously read **[low-memory setup](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup)** and you intentionally want to sacrifice gigantic performance boost, for a very small memory overhead decrease. Usually this option is **much worse** than what you can achieve with other possible ways, such as by limiting your ASF usage or tuning runtime's garbage collector, as explained in **[low-memory setup](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup)**. Therefore, you should use `MinMemoryUsage` as a **last resort**, right before runtime recompilation, if you couldn't achieve satisfying results with other (much better) options. Unless you have a **strong** reason to edit this property, you should keep it at default.

---

### `SteamMessagePrefix`

預設值為 `"/me "` 的 `string` 類型。 此屬性定義了一個首碼, 該首碼將作為ASF發送的所有 Steam 消息的首碼。 預設情況下, ASF使用`"/me "` 首碼, 以便通過在 Steam 聊天中以不同的顏色顯示機械人消息來更輕鬆地區分機械人消息。 另一個值得提及的地方是 `"/pre "` 首碼, 它實現了類似的結果, 但使用了不同的格式。 您還可以將此屬性設置為空字串或 `null`, 以便完全禁用首碼, 並以傳統方式輸出所有ASF消息。 好消息是, 此屬性僅影響 Steam 消息-通過其他通道 (如 IPC) 返回的回應不受影響。 除非您要自訂標準 ASF 行為, 否則最好將其保留為預設值。

---

### `SteamOwnerID`

預設值 為`0` 的 `ulong` 類型。 此屬性以64位形式的Steam ID定義 ASF 進程擁有者，類似于給定機械人實例的 `master` 許可權（但作用於全域）。 通常您應該會希望將屬性設置為您的Steam主帳戶ID。 `Master` 許可權包括對其機器人實例的完全控制， 僅`SteamOwnerID`中指定的用戶才能發佈全域命令，如 `exit``restart` 或 `update`。 這很方便，因為你可能想為你的朋友運行機械人，同時不允許他們通過 `exit` 之類的命令控制 ASF 進程。 預設值 `0` 表示當前ASF進程無擁有者，這意味著沒有人能夠發出全域 ASF 命令。 Keep in mind that this property applies to Steam chat exclusively. **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)**, as well as interactive console, will still allow you to execute `Owner` commands even if this property is not set.

---

### `SteamProtocols`

這是一個預設值為`7` 的 `byte flags` 類型屬性。 此屬性定義了 ASF 在連接 Steam 伺服器時使用的網絡協議，其定義如下：

| 值 | 名稱         | 描述                                                                        |
| - | ---------- | ------------------------------------------------------------------------- |
| 0 | None       | 無協議                                                                       |
| 1 | TCP        | **[傳輸控制協議](https://en.wikipedia.org/wiki/Transmission_Control_Protocol)** |
| 2 | UDP        | **[用戶數據報協議](https://en.wikipedia.org/wiki/User_Datagram_Protocol)**       |
| 4 | WebSockets | **[WebSockets](https://en.wikipedia.org/wiki/WebSocket)**                 |

Please notice that this property is `flags` field, therefore it's possible to choose any combination of available values. Check out **[json mapping](#json-mapping)** if you'd like to learn more. 不啟用任何標誌會導致` None `選項被啟用，並且該選項本身未曾指定有效值。

By default ASF will use all available Steam protocols as a measure for fighting with downtimes and other similar Steam issues. Typically you want to change this property if you want to limit ASF into using only one or two specific protocols. 如果您只在防火牆上啟用 TCP 流量，並且不希望 ASF 嘗試通過 UDP 進行連接，則可能需要這樣的措施。 但是，除非您正在調試特定問題或漏洞，否則您幾乎總是希望確保 ASF 可以自由使用當前支持的任何協議，而不僅僅是一個或兩個。 除非您有**強烈**的修改意願，否則應保持它為预設值。

---

### `UpdateChannel`

這是一個預設值為`1` 的 `byte flags` 類型屬性。 此屬性定義正在使用的更新通道，用於自動更新（如果` UpdatePeriod `大於` 0 `），或收到更新通知時（其他情況）。 當前 ASF 支援三個更新通道──`0`，`無更新`；`1`，`穩定版`；`2`，`探索版`。 `穩定版`通道是預設值，適用於大多數用戶。 `探索版`通道除了`穩定版`，還包括**預發行版本**， 專用於高級用戶和其他開發人員，以測試新功能、確認錯誤修復或提出增強功能。 **探索版通常包含未修補的漏洞、正在測試的工作功能或某些重寫的實現**。 If you don't consider yourself advanced user, please stay with default `1` (`Stable`) update channel. `Experimental` 通道專門針對知道如何報告錯誤、處理問題和提供回饋的用戶——不會提供任何技術支援。 如果您想了解更多資訊，請查看 ASF **[發布周期](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Release-cycle)**。 如果要完全禁用所有版本更新，還可以將` UpdateChannel `設置為` 0 `（` None `）。 將 `UpdateChannel` 設置為 ` 0 ` 將完全禁用與更新相關的整個功能, 包括 `update` 命令。 **強烈建議不要**使用`None`通道，因為您會遇到各種問題（在下面的` UpdatePeriod `說明中提到）。

**除非您知道您在做什麼**，否則我們 **強烈** 建議保持它為預設值。

---

### `UpdatePeriod`

這是一個預設值為`24` 的 `byte flags` 屬性。 此屬性定義 ASF 檢查自動更新的頻率。 更新不僅對於接收新功能和關鍵安全修補程式至關重要, 而且對於接收錯誤修復、性能增強、穩定性改進等也至關重要。 當設置大於` 0 `的值時，ASF 將在新版本可用時自動下載，替換並重新啟動（如果` AutoRestart `被啟用）。 為了實現這一目標, ASF將每 `UpdatePeriod` 小時檢查一次我們的GitHub 存儲庫上是否有新的更新。 此值為 `0` 時禁用自動更新，但您仍可手動執行 `update` 命令。 您可能還有興趣了解設置 `UpdatePeriod` 應遵循的適當 `UpdateChannel`。

ASF 的更新過程涉及 ASF 正在使用的整個資料夾結構的更新，但不涉及位於` config `目錄中您自己的配置或數據庫——意味著在其目錄中與 ASF 無關的任何額外檔可能會在更新期間丟失。 ` 24 `的默認值是不必要的檢查和維持 ASF 更新之間的良好平衡。

除非您有**強烈的**理由要禁用此功能，否則您應該在合理的` UpdatePeriod ` **中啟用自動更新，這是出於為您自己利益的考慮**。 這不僅是因為我們不支援最新的穩定 ASF 版本範圍之外的事情，還因為**我們僅為最新版本提供安全保障**。 如果您使用的是過時的ASF版本，那麼您可能將自己暴露於各種問題，從小錯誤到功能損壞，以**[Steam 帳戶永久封鎖](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#did-somebody-get-banned-for-it)**告終，所以為了您自己的利益，我們**強烈推薦**確保您的 ASF 版本是最新的。 自動更新允許我們能夠在升級之前禁用或修補有問題的代碼，從而快速應對所有類型的問題——如果您選擇退出它，您將失去我們的所有安全保障，並且需要自行承擔運行可能有害的代碼所帶來的風險後果， 不僅是來自 Steam 網絡的威脅，還（顧名思義）您自己的 Steam 帳戶。

---

### `WebLimiterDelay`

預設值為 `300` 的 `ushort` 類型。 此屬性定義向同一 Steam Web 服務發送兩個連續請求之間的最小延遲（以毫秒為單位）。 此類延遲是必要的，因為 Steam 內部使用**[ AkamaiGhost ](https://www.akamai.com)**服務在給定的時間段限制基於全域請求數量的速率。 在正常情況下，akamai 限制很難觸發，但是如果我們在太短的時間內不斷發送過多請求，導致非常繁重的工作負載和大量正在進行的請求隊列，則可能觸發它。

預設值是基於 ASF 是訪問各種 Steam Web 服務的唯一工具來設定的，特別是 `steamcommunity.com`，`api.steampowered.com` 和`store.steampowered.com`。 如果您正在使用其他工具向同一 Web 服務發送請求，那麼您應該確保您的工具包含類似` WebLimiterDelay `的功能，並將兩者都設置為預設值的兩倍，即`600`。 這保證了在任何情況下，您都不會每 `300` 毫秒發送超過1個的請求。

通常，我們**強烈反對**降低` WebLimiterDelay `的預設值，因為它可能會導致各種與 IP 相關的封鎖，其中一些封鎖可能是永久性的。 預設值足以在伺服器上運行單個 ASF 實例，以及在正常情況下與原始 Steam 用戶端一起使用 ASF。 It should be correct for majority of usages, and you should only increase it (never lower it). 簡而言之，從單個 IP 發送到單個 Steam 域的所有全域請求的數量不應超過每 `300` 毫秒1個。

除非您有充分的修改理由，否則應保持它為預設值。

---

### `WebProxy`

預設值為 `null` 的 `string` 類型。 此屬性定義了一個 Web 代理地址，該地址將用於 ASF 的` HttpClient `發送的所有內部http和https請求，尤其是對於` github.com `，` steamcommunity.com `和` store.steampowered.com `。 一般來說，ASF 使用代理請求沒有任何優勢，但它對於繞過各種防火牆特別有用，尤其是中國的防火牆。

此屬性定義為 URI 字串：

> A URI string is composed of a scheme (supported: http/https/socks4/socks4a/socks5), a host, and an optional port. 完整 URI 字串的一個示例是 `"HTTP://contoso.com:8080"`。

如果您的代理需要用戶身份驗證，則還需要設置` WebProxyUsername `和/或` WebProxyPassword `。 如果無此需求，僅設置此屬性就足夠了。

現在，ASF僅對` http `和` https `請求使用Web代理，**不**包括在 ASF 內部 Steam 客戶端內的內部 Steam 網絡通信。 當前沒有支援這一點的計畫，主要原因是缺少 **[SK2](https://github.com/SteamRE/SteamKit/issues/587#issuecomment-413271550)** 功能。 如果你想實現它，我建議從此處開始。

除非您有充分的修改理由，否則應保持它為預設值。

---

### `WebProxyPassword`

預設值為 `null` 的 `string` 類型。 此屬性定義在提供代理功能的目標` WebProxy `電腦支援的基本、摘要、NTLM和Kerberos 身份驗證中使用的密碼字段。 如果您的代理不需要用戶憑據，則無需在此處輸入任何內容。 只有在啟用 `WebProxy` 時，使用此選項才有意義，否則它沒有任何效果。

除非您有充分的修改理由，否則應保持它為預設值。

---

### `WebProxyUsername`

預設值為 `null` 的 `string` 類型。 此屬性定義在提供代理功能的目標` WebProxy `電腦中使用的基本、摘要、NTLM 和 Kerberos 身份驗證中使用的密碼字段。 如果您的代理不需要用戶憑據，則無需在此處輸入任何內容。 只有在啟用 `WebProxy` 時，使用此選項才有意義，否則它沒有任何效果。

除非您有充分的修改理由，否則應保持它為預設值。

---

## 機械人配置

正如您應該知道的，每個機械人都應該有基於下面的示例JSON結構的獨立配置。 從決定如何命名機械人開始（例如` 1.json `，` main.json `，` primary.json `或` AnythingElse.json `）並轉向配置。

**請謹記：**機械人不能被能命名為` ASF `（因為該關鍵字是為全域配置保留的），ASF 也會忽略以點開頭的所有配置檔。

機械人配置具有以下結構：

```json
{
    "AcceptGifts": false,
    "BotBehaviour": 0,
    "CompleteTypesToSend": [],
    "CustomGamePlayedWhileFarming": null,
    "CustomGamePlayedWhileIdle": null,
    "Enabled": false,
    "FarmingOrders": [],
    "FarmingPreferences": 0,
    "GamesPlayedWhileIdle": [],
    "HoursUntilCardDrops": 3,
    "LootableTypes": [1, 3, 5],
    "MatchableTypes": [5],
    "OnlineFlags": 0,
    "OnlineStatus": 1,
    "PasswordFormat": 0,
    "RedeemingPreferences": 0,
    "RemoteCommunication": 3,
    "SendTradePeriod": 0,
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

以下是對所有選項的解釋：

### `AcceptGifts`

預設值為 `false` 的 `bool` 類型。 啟用後，ASF 將自動接受並兌換發送給機械人的所有 Steam 禮品（包括錢包禮品卡）。 這還包括來自` SteamUserPermissions `中定義的用戶以外的用戶的禮物。 請記住，發送到電子郵件地址的禮物不會直接轉發給客戶端，因此 ASF 不能在沒有您幫助的情況下接受這些禮物。

建議僅對備用帳戶使用此選項，因為您很可能不希望自動兌換發送到主帳戶的所有禮品。 如果您不確定是否要啟用此功能，請將其保留為預設值` false `。

---

### `BotBehaviour`

這是一個預設值為`0` 的 `byte flags` 屬性。 此屬性定義各種事件中的 ASF 機械人行為，定義如下：

| 值  | 名稱                            | 描述                                                                                                       |
| -- | ----------------------------- | -------------------------------------------------------------------------------------------------------- |
| 0  | None                          | 沒有特殊的機械人行為，最少侵入模式，預設值                                                                                    |
| 1  | RejectInvalidFriendInvites    | 將導致 ASF 拒絕（而不是忽略）無效的好友邀請                                                                                 |
| 2  | RejectInvalidTrades           | 將導致 ASF 拒絕（而不是忽略）無效的交易報價                                                                                 |
| 4  | RejectInvalidGroupInvites     | 將導致 ASF 拒絕（而不是忽略）無效的群組邀請                                                                                 |
| 8  | DismissInventoryNotifications | 將導致 ASF 自動關閉所有庫存通知                                                                                       |
| 16 | MarkReceivedMessagesAsRead    | 將導致 ASF 自動標記所有消息為已讀                                                                                      |
| 32 | MarkBotMessagesAsRead         | Will cause ASF to automatically mark messages from other ASF bots (running in the same instance) as read |

Please notice that this property is `flags` field, therefore it's possible to choose any combination of available values. Check out **[json mapping](#json-mapping)** if you'd like to learn more. 不啟用任何標誌會導致` None `選項。

一般情況下，如果您希望ASF執行與其活動相關的一定數量的自動化，則需要修改此屬性，因為它可能來自機械人帳戶，而不是ASF中使用的主要帳戶。 因此，更改此屬性主要適用於備用帳戶，儘管您也可以自由使用主帳戶的選定選項。

Normal (`None`) ASF behaviour is to only automate things that user wants (e.g. cards farming or `SteamTradeMatcher` offers processing, if set in `TradingPreferences`). 這是最少侵入性的模式，它對大多數用戶都有好處，因為您可以完全控制您的帳戶，並且您可以決定是否允許某些超出範圍的交互。

無效好友邀請是來自對當前帳戶不具有` FamilySharing `權限（在` SteamUserPermissions `中定義）或更高權限的用戶的好友邀請。 正常模式下的 ASF 會忽略這些邀請，正如您所期望的那樣，讓您可以自由選擇是否接受這些邀請。 啟用` RejectInvalidFriendInvites `會導致這些邀請被自動拒絕，這實際上會禁用其他人將您添加到他們的朋友列表（因為ASF將拒絕所有此類請求，除了` SteamUserPermissions中指定的人員`）。 除非您想徹底拒絕所有好友邀請，否則您不應啟用此選項。

無效交易提案是不被ASF內置模組所接受的提案。 有關此問題的更多信息可以在** [交易](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading) **部分找到，該部分明確定義了ASF願意自動接受哪些類型的交易。 有效交易還由其他設置定義，尤其是 `TradingPreferences`。 `RejectInvalidTrades` 將導致所有無效交易提案被拒絕，而不是被忽略。 除非您想直接拒絕ASF未自動接受的所有交易提案，否則您不應啟用此選項。

無效群組邀請是來自` SteamMasterClanID `之外群組的邀請。 正常模式下的ASF會忽略那些群組邀請，正如您所期望的那樣，允許您自行決定是否要加入特定的Steam群組。 啟用` RejectInvalidGroupInvites `將導致所有這些群組邀請被自動拒絕，實際上您無法被邀請加入` SteamMasterClanID `之外的任何其他群組。 除非您想徹底拒絕所有群組邀請，否則您不應啟用此選項。

`DismissInventoryNotifications` is extremely useful when you start getting annoyed by constant Steam notification about receiving new items. ASF無法消除通知本身，因為它來自您的Steam客戶端，但它能夠在收到通知後自動清除通知，這將不再留下“庫存中的新項目”通知。 If you expect to evaluate yourself all received items (especially cards farmed with ASF), then naturally you shouldn't enable this option. 如果您已經開始抓狂了，請記住這僅僅是一個選項。

`MarkReceivedMessagesAsRead` will automatically mark **all** messages being received by the account on which ASF is running, both private and group, as read. 這通常僅應由備用帳戶使用，以便清除“新消息”通知，例如： 在執行ASF命令時從您那裡收到的消息。 我們不建議將此選項用於主要帳戶，除非您希望自己避免收到任何類型的新郵件通知，**包括**您在離線時，ASF仍處於開放狀態而不予理會的通知。

`MarkBotMessagesAsRead` works in a similar manner by marking only bot messages as read. However, keep in mind that when using that option on group chats with your bots and other people, Steam implementation of acknowledging chat message **also** acknowledges all messages that happened **before** the one you decided to mark, so if by any chance you don't want to miss unrelated message that happened in-between, you typically want to avoid using this feature. Obviously, it's also risky when you have multiple primary accounts (e.g. from different users) running in the same ASF instance, as you can also miss their normal out-of-ASF messages.

如果您不確定如何配置此選項，最好將其保留為預設值。

---

### `CompleteTypesToSend`

預設值為空的 `ImmutableHashSet<byte>` 類型。 When ASF is done with completing a given set of item types specified here, it can automatically send steam trade with all finished sets to the user with `Master` permission, which is very convenient if you'd like to utilize given bot account for e.g. STM matching, while moving finished sets to some other account. 此選項與` loot `命令的作用相同，因此請謹記，首先您需要有效的` SteamTradeToken `， 並使用實際有資格進行交易的帳戶，且只有` Master `權限集的用戶才能執行。

As of today, the following item types are supported in this setting:

| 值 | 名稱              | 描述                      |
| - | --------------- | ----------------------- |
| 3 | FoilTradingCard | 閃亮類型的`TradingCard`      |
| 5 | TradingCard     | Steam交易卡片，可用於合成徽章 (非閃卡） |

Please note that regardless of the settings above, ASF will only ask for **[Steam community items](https://steamcommunity.com/my/inventory/#753_6)** (`appID` of 753, `contextID` of 6), so all game items, gifts and likewise, are excluded from the trade offer by definition.

Due to additional overhead of using this option, it's recommended to use it only on bot accounts that have a realistic chance of finishing sets on their own - for example, it makes no sense to activate if you're already using `SendOnFarmingFinished` preference in `FarmingPreferences`, `SendTradePeriod` or `loot` command on usual basis.

如果您不確定如何配置此選項，最好將其保留為預設值。

---

### `CustomGamePlayedWhileFarming`

預設值為 `null` 的 `string` 類型。 當ASF掛卡時，它可以顯示狀態為“玩非Steam遊戲：` CustomGamePlayedWhileFarming `”而不是當前掛卡的遊戲。 如果您想讓您的朋友知道您正在掛卡，但您不想使用` Offline `的` OnlineStatus `，這將非常有用。 請注意，ASF無法干預Steam網絡的實際顯示順序，因此這只是一種建議，可能會正確顯示，也可能不會。 In particular, custom name will not display in `Complex` farming algorithm if ASF fills all `32` slots with games requiring hours to be bumped. ` null `的預設值禁用此功能。

ASF provides a few special variables that you can optionally use in your text. `{0}` will be replaced by ASF with `AppID` of currently farmed game(s), while `{1}` will be replaced by ASF with `GameName` of currently farmed game(s).

---

### `CustomGamePlayedWhileIdle`

預設值為 `null` 的 `string` 類型。 類似於` CustomGamePlayedWhileFarming `，但是用於ASF無卡可掛的情況（因為帳戶已經獲得了所有的可掉落卡片）。 請注意，ASF無法干預Steam網絡的實際顯示順序，因此這只是一種建議，可能會正確顯示，也可能不會。 If you're using `GamesPlayedWhileIdle` together with this option, then keep in mind that `GamesPlayedWhileIdle` get priority, therefore you can't declare more than `31` of them, as otherwise `CustomGamePlayedWhileIdle` will not be able to occupy the slot for custom name. ` null `的預設值禁用此功能。

---

### `Enabled`

預設值為 `false` 的 `bool` 類型。 此屬性定義機械人是否啟用。 啟用的機械人實例（` true `）將在ASF運行時自動啟動，而禁用的機械人實例（` false `）將需要手動啟動。 默認情況下，每個機械人都被禁用，因此您可能希望將應自動啟動的所有機械人的此屬性切換為` true `。

---

### `FarmingOrders`

`ImmutableList<byte>` type with default value of being empty. 此屬性定義ASF用於給定機械人帳戶的**首選**掛卡順序。 當前可選的掛卡佇列如下：

| 值  | 名稱                        | 描述                       |
| -- | ------------------------- | ------------------------ |
| 0  | Unordered                 | 無序，略微提高CPU性能             |
| 1  | AppIDsAscending           | 嘗試優先對 `appIDs` 最小的遊戲進行掛卡 |
| 2  | AppIDsDescending          | 嘗試優先對 `appIDs` 最大的遊戲進行掛卡 |
| 3  | CardDropsAscending        | 嘗試優先對剩餘掉落卡片數目最少的遊戲進行掛卡   |
| 4  | CardDropsDescending       | 嘗試優先對剩餘掉落卡片數目最多的遊戲進行掛卡   |
| 5  | HoursAscending            | 嘗試優先對已遊玩時間最短的遊戲進行掛卡      |
| 6  | HoursDescending           | 嘗試優先對已遊玩時間最長的遊戲進行掛卡      |
| 7  | NamesAscending            | 嘗試按字母升序掛卡，從 A 開始         |
| 8  | NamesDescending           | 嘗試按字母降序掛卡，從 Z 開始         |
| 9  | Random                    | 嘗試完全隨機掛卡（每次進程的掛卡佇列不同）    |
| 10 | BadgeLevelsAscending      | 嘗試優先對徽章等級最低的遊戲進行掛卡       |
| 11 | BadgeLevelsDescending     | 嘗試優先對徽章等級最高的遊戲進行掛卡       |
| 12 | RedeemDateTimesAscending  | 嘗試先對我們的帳戶裏最舊的遊戲進行掛卡      |
| 13 | RedeemDateTimesDescending | 嘗試先對我們的帳戶裏最新的遊戲進行掛卡      |
| 14 | MarketableAscending       | 嘗試先對掉落不可售卡片的遊戲進行掛卡       |
| 15 | MarketableDescending      | 嘗試先對掉落可售卡片的遊戲進行掛卡        |

由於此屬性是一個數組，因此它允許您按固定順序使用多個不同的設置。 例如，您可以設置` 15 `，` 11 `和` 7 `的值，以便先按會掉落可交易卡的遊戲進行排序，然後按徽章級別最高的遊戲進行排序 ，最後按遊戲名稱字母順序排列。 As you can guess, the order actually matters, as reverse one (`7`, `11` and `15`) achieves something entirely different (sorts games alphabetically first, and due to game names being unique, the other two are effectively useless). 大多數人可能只使用其中一個順序，但如果您願意，您還可以通過額外的參數進一步排序。

另請注意以上所有描述中的“嘗試”一詞——實際的ASF順序受所選** [掛卡算法](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)**的影響，並且排序將僅影響ASF認為性能相同的結果。 例如，在` Simple `算法中，在當前的掛卡會話中應該完全遵循所選的` FarmingOrders `（因為每個遊戲具有相同的性能值），而在` Complex `算法中，實際順序首先受遊戲時間影響，然後根據所選` FarmingOrders `進行排序。 這將導致不同的結果，因為具有遊戲時間的遊戲將優先於其他遊戲，因此ASF將首先優先選擇遊戲時間滿足所需的` HoursUntilCardDrops `的遊戲，然後僅通過您選擇的 `FarmingOrders`進一步對這些遊戲進行排序。 同樣，一旦ASF完成對置頂遊戲的掛卡，它將首先按遊戲時間對剩餘隊列排序（因為這將減少將任何剩餘遊戲掛卡以達` HoursUntilCardDrops `所需的時間）。 Therefore, this config property is only a **suggestion** that ASF will try to respect, as long as it doesn't affect performance negatively (in this case, ASF will always prefer farming performance over `FarmingOrders`).

There is also farming priority queue that is accessible through `fq` **[commands](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. If it's used, actual farming order is sorted firstly by performance, then by farming queue, and finally by your `FarmingOrders`.

---

### `FarmingPreferences`

這是一個預設值為`0` 的 `byte flags` 屬性。 This property defines ASF behaviour related to farming, and is defined as below:

| 值   | 名稱                        |
| --- | ------------------------- |
| 0   | None                      |
| 1   | FarmingPausedByDefault    |
| 2   | ShutdownOnFarmingFinished |
| 4   | SendOnFarmingFinished     |
| 8   | FarmPriorityQueueOnly     |
| 16  | SkipRefundableGames       |
| 32  | SkipUnplayedGames         |
| 64  | EnableRiskyCardsDiscovery |
| 128 | AutoSteamSaleEvent        |

Please notice that this property is `flags` field, therefore it's possible to choose any combination of available values. Check out **[json mapping](#json-mapping)** if you'd like to learn more. 不啟用任何標誌會導致` None `選項。

All of the options are described below.

`FarmingPausedByDefault` defines initial state of `CardsFarmer` module. Normally bot will automatically start farming when it's started, either because of `Enabled` or `start` command. Using `FarmingPausedByDefault` can be used if you want to manually `resume` automatic farming process, for example because you want to use `play` all the time and never use automatic `CardsFarmer` module - this works exactly the same as `pause` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**.

`ShutdownOnFarmingFinished` allows you to shutdown bot once it's done farming. Normally ASF is "occupying" an account for the whole time of process being active. 當給定帳戶完成掛卡之後，ASF 會定期（每個` IdleFarmingPeriod `小時）檢查帳戶狀態，如果在此期間新增了一些帶有 Steam 卡的新遊戲，那麼它可以在無需重啓的情況下恢復該帳戶的掛卡進程。 這對大多數人都很有用，因為 ASF 可以在需要時自動復原掛卡。 However, you may actually want to stop the process when given account is fully farmed, you can achieve that by using this flag. 啟用後，ASF 將在帳戶完全結束掛卡後登出，這意味著 ASF 不會對此帳戶進行定期檢查或佔用。 您應該自己決定是否更喜歡ASF在整個時間內使用給定的機械人實例，或者ASF是否應該在掛卡過程完成時停止它。 當所有帳戶都停止並且進程未在 `--process-required` **[模式](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-Line-Arguments)**下運行時，ASF 也將關閉，讓您的機器處於休眠狀態，並允許您安排其他操作，例如在獲得最後一張掉落卡片之後進入睡眠或關機狀態。

`SendOnFarmingFinished` allows you to automatically send steam trade containing everything farmed up to this point to user with `Master` permission, which is very convenient if you don't want to bother with trades yourself. 此選項與` loot `命令的作用相同，因此請謹記，首先您需要有效的` SteamTradeToken `， 並使用實際有資格進行交易的帳戶，且只有` Master `權限集的用戶才能執行。 此選項處於活動狀態時，ASF除了在完成掛卡後執行` loot `之外，還（ 總是）會在收到每個新物品通知（不掛卡時）或完成每次交易之後執行` loot `。 這對於將從別處收到的物品「轉發」到我們的帳戶特別有用。 Typically you'll want to use **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)** together with this feature, although it's not a requirement if you intend to handle 2FA confirmations manually in timely fashion.

`FarmPriorityQueueOnly` defines if ASF should consider for automatic farming only apps that you added yourself to priority farming queue available with `fq` **[commands](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. When this option is enabled, ASF will skip all `appIDs` that are missing on the list, effectively allowing you to cherry-pick games for automatic ASF farming. Keep in mind that if you didn't add any games to the queue then ASF will act as if there is nothing to farm on your account.

`SkipRefundableGames` defines if ASF should skip games that are still refundable from automatic farming. 所謂可退款的遊戲，是你在過去2周內通過 Steam 商店購買但遊戲時間不超過2小時的遊戲，如 **[Steam 退款](https://store.steampowered.com/steam_refunds)**頁面所述。 By default, ASF ignores Steam refunds policy entirely and farms everything, as most people would expect. However, you can use this flag if you want to ensure that ASF won't farm any of your refundable games too soon, allowing you to evaluate those games yourself and refund if needed without worrying about ASF affecting playtime negatively. Please note that if you enable this option then games you purchased from Steam Store won't be farmed by ASF for up to 14 days since redeem date, which will show as nothing to farm if your account doesn't own anything else.

`SkipUnplayedGames` defines if ASF should skip games that you didn't launch yet. Unplayed game in this context means that you have exactly no playtime recorded for it on Steam. If you use this flag, then such games will be skipped until Steam registers any playtime for them. This allows you to control better which games ASF is eligible to farm, skipping those that you didn't have a chance of trying out yet, keeping selected Steam features more useful - such as suggesting unplayed games to play.

`EnableRiskyCardsDiscovery` enables additional fallback which triggers when ASF is unable to load one or more of badge pages and is therefore unable to find games available for farming. In particular, some accounts with massive amount of card drops might cause a situation where loading badge pages is no longer possible (due to overhead), and those accounts are impossible for farming purely because we can't load the information based on which we can start the process. For those handful cases, this option allows alternative algorithm to be used, which uses a combination of boosters possible to craft and booster packs the account is eligible for, in order to find potentially available games to idle, then spending excessive amount of resources for verifying and fetching required information, and attempting to start the process of farming on limited amount of data and information in order to eventually reach a situation when badge page loads and we'll be able to use normal approach. Please note that when this fallback is used, ASF operates only with limited data, therefore it's completely normal for ASF to find much less drops than in reality - other drops will be found at later stage of farming process.

This option is called "risky" for a very good reason - it's extremely slow and requires significant amount of resources (including network requests) for operation, therefore it's **not recommended** to be enabled, and especially in long-term. You should use this option only if you previously determined that your account suffers from being unable to load badge pages and ASF can't operate on it, always failing to load necessary information to start the process. Even if we made our best to optimize the process as much as possible, it's still possible for this option to backfire, and it might cause unwanted outcomes, such as temporary and maybe even permanent bans from Steam side for sending too many requests and otherwise causing overhead on Steam servers. Therefore, we warn you in advance and we're offering this option with absolutely no guarantees, you're using it at your own risk.

`AutoSteamSaleEvent` allows you to claim additional cards during Steam summer/winter sale events from browsing discovery queue each day. 啟用此選項後, ASF 將每 ` 8` 小時 (從程式開始後1小時內開始)自動檢查Steam發現佇列，並在需要時進行清除。 如果您想自己執行此操作，則不建議使用此選項，通常此選項僅在機械人帳戶上才有意義。 請注意，由於持續性的Valve漏洞，變更和問題，**我們無法保證此功能是否能正常運行**，因此完全有可能此選項**根本不起作用**。 我們不接受 **任何** 漏洞報告，也不支援關於此選項的請求。 它是在絕對沒有保證的情況下提供的, 一切風險將由您自行承擔。

---

### `GamesPlayedWhileIdle`

預設值為空的 `ImmutableHashSet<uint>` 類型。 如果 ASF 沒有任何遊戲可供掛卡，它可以遊玩指定的 Steam 遊戲 (`appIDs`)。 以這樣的方式玩遊戲會增加那些遊戲的「遊玩時長」，但除此之外，別無他用。 In order for this feature to work properly, your Steam account **must** own a valid license to all the `appIDs` that you specify here, this includes F2P games as well. 此功能可以與` CustomGamePlayedWhileIdle `同時啟用，以便在Steam網絡中顯示自訂遊戲狀態，但在` CustomGamePlayedWhileFarming `這類情況中， 實際的顯示順序無法保證。 請注意，Steam 允許 ASF 最多同時遊玩 `32` 個 `appIDs`，因此您設置該屬性時應參考此值。

---

### `HoursUntilCardDrops`

這是一個預設值為`3`的`byte`類型屬性。 此屬性定義帳戶是否有卡片掉落限制，若有，則定義初始小時數。 受限制的卡掉落意味著帳戶在給定的遊戲玩了至少 `hoursuntilcards`小時前不會獲得任何掉落的卡片。 不幸的是，沒有神奇的方法來檢測它，所以ASF依賴於你。 此屬性影響將使用的**[掛卡算法](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)**。 正確設置此屬性將最大限度地提高效率，並最大限度地減少掛卡所需的時間。 請記住，您是否應該使用何值，這沒有明顯的答案，因為它完全取決於您的帳戶。 從來沒有要求退款的老用戶似乎在卡片掉落上不受限制，所以他們應該使用` 0 `的值，而新帳戶和那些要求退款的人在卡片掉落上有`3`小時的限制。 然而，這只是理論，不應作為一條定理。 此屬性的默認值是基於“兩害相權取其輕”和大多數用例設置的。

---

### `LootableTypes`

預設值為 `1，3，5` 的 `ImmutableHashSet<byte>` 類型。 This property defines ASF behaviour when looting - both manual, using a **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**, as well as automatic one, through one or more configuration properties. ASF將確保交易提案中只包含符合` LootableTypes `的物品，因此，此屬性允許您選擇要在發送給您的交易提案中收到的內容。

| 值  | 名稱                    | 描述                                           |
| -- | --------------------- | -------------------------------------------- |
| 0  | Unknown               | 不屬於以下任何類型的類型                                 |
| 1  | BoosterPack           | 包含3張來自同一遊戲的卡片的擴充包                            |
| 2  | Emoticon              | 在Steam聊天中使用的表情符號                             |
| 3  | FoilTradingCard       | 閃亮類型的`TradingCard`                           |
| 4  | ProfileBackground     | 可在您的Steam個人資料頁中使用的背景                         |
| 5  | TradingCard           | Steam交易卡片，可用於合成徽章 (非閃卡）                      |
| 6  | SteamGems             | 用於製作擴充包的 Steam 寶石，包括寶石袋                      |
| 7  | SaleItem              | Steam特賣期間獲得的特殊物品                             |
| 8  | Consumable            | 使用後消失的特殊小玩意兒                                 |
| 9  | 個人檔案修改器               | 可以修改Steam設定檔外觀的特殊物品                          |
| 10 | Sticker               | Special items that can be used on Steam chat |
| 11 | ChatEffect            | Special items that can be used on Steam chat |
| 12 | MiniProfileBackground | Special background for Steam profile         |
| 13 | AvatarProfileFrame    | Special avatar frame for Steam profile       |
| 14 | AnimatedAvatar        | Special animated avatar for Steam profile    |
| 15 | KeyboardSkin          | Special keyboard skin for Steam deck         |
| 16 | StartupVideo          | Special startup video for Steam deck         |

Please note that regardless of the settings above, ASF will only ask for **[Steam community items](https://steamcommunity.com/my/inventory/#753_6)** (`appID` of 753, `contextID` of 6), so all game items, gifts and likewise, are excluded from the trade offer by definition.

ASF 預設基於機器人的最常見用法，僅拾取擴充包和交易卡片（包括閃亮卡片）。 這裏定義的屬性允許你以任何令你滿意的方式改變這種行為。 請記住，上面未定義的所有類型都將顯示為` Unknown `類型，這在Valve發布一些新的Steam項目時尤為重要，該項目將被ASF標記為` Unknown `，直到它被添加到這裡（在將來的版本中）。 這就是為什麼一般不建議在` LootableTypes `中選擇` Unknown `類型，除非您知道自己在做什麼，並且還瞭解萬一Steam 網絡崩潰並將您的所有商品標記為` Unknown `，ASF會在交易提案中發送您的整個庫存。 My strong suggestion is to not include `Unknown` type in the `LootableTypes`, even if you expect to loot everything (else).

---

### `MatchableTypes`

預設值為 `5` 的 `ImmutableHashSet<byte>` 類型。 此屬性定義在啟用` TradingPreferences `中的` SteamTradeMatcher `選項時允許匹配的Steam物品類型。 類型的定義如下：

| 值  | 名稱                    | 描述                                           |
| -- | --------------------- | -------------------------------------------- |
| 0  | Unknown               | 不屬於以下任何類型的類型                                 |
| 1  | BoosterPack           | 包含3張來自同一遊戲的卡片的擴充包                            |
| 2  | Emoticon              | 在Steam聊天中使用的表情符號                             |
| 3  | FoilTradingCard       | 閃亮類型的`TradingCard`                           |
| 4  | ProfileBackground     | 可在您的Steam個人資料頁中使用的背景                         |
| 5  | TradingCard           | Steam交易卡片，可用於合成徽章 (非閃卡）                      |
| 6  | SteamGems             | 用於製作擴充包的 Steam 寶石，包括寶石袋                      |
| 7  | SaleItem              | Steam特賣期間獲得的特殊物品                             |
| 8  | Consumable            | 使用後消失的特殊小玩意兒                                 |
| 9  | 個人檔案修改器               | 可以修改Steam設定檔外觀的特殊物品                          |
| 10 | Sticker               | Special items that can be used on Steam chat |
| 11 | ChatEffect            | Special items that can be used on Steam chat |
| 12 | MiniProfileBackground | Special background for Steam profile         |
| 13 | AvatarProfileFrame    | Special avatar frame for Steam profile       |
| 14 | AnimatedAvatar        | Special animated avatar for Steam profile    |
| 15 | KeyboardSkin          | Special keyboard skin for Steam deck         |
| 16 | StartupVideo          | Special startup video for Steam deck         |

當然，通常您應該僅在此屬性中選擇` 2 `，` 3 `，` 4 `和` 5 `， 因為STM只支持這些類型。 ASF包含用於判斷物品稀有度的正確邏輯，因此匹配表情符號或背景也是安全的，因為ASF將認為來自相同遊戲和類型的物品具有相同的稀有性。

請注意，**ASF 並非交易機械人**，**並不關心市場價格**。 如果您不認為同一集合中稀有度相同的物品是等價的，那麼這個選項不適合您。 如果您決定更改此設置，請在此之前評估兩次以理解並同意此聲明。

除非你知道自己在做什麼，否則你應該保留預設值` 5 `。

---

### `OnlineFlags`

`ushort flags` type with default value of `0`. This property works as supplement to **[`OnlineStatus`](#onlinestatus)** and specifies additional online presence features announced to Steam network. Requires **[`OnlineStatus`](#onlinestatus)** other than `Offline`, and is defined as below:

| 值    | 名稱                | 描述                                        |
| ---- | ----------------- | ----------------------------------------- |
| 0    | None              | No special online presence flags, default |
| 256  | ClientTypeWeb     | Client is using web interface             |
| 512  | ClientTypeMobile  | Client is using mobile app                |
| 1024 | ClientTypeTenfoot | Client is using big picture               |
| 2048 | ClientTypeVR      | Client is using VR headset                |

Please notice that this property is `flags` field, therefore it's possible to choose any combination of available values. Check out **[json mapping](#json-mapping)** if you'd like to learn more. 不啟用任何標誌會導致` None `選項。

The underlying `EPersonaStateFlag` type that this property is based on includes more available flags, however, to the best of our knowledge they have absolutely no effect as of today, therefore they were cut for visibility.

如果您不確定該如何設置此屬性，請將其保留為預設值`0`。

---

### `OnlineStatus`

這是一個預設值為`1` 的 `byte flags` 類型屬性。 此屬性定義機械人在登錄Steam網絡後將顯示的Steam社區狀態。 當前您可以選擇以下狀態之一：

| 值 | 名稱    |
| - | ----- |
| 0 | 離線    |
| 1 | 線上    |
| 2 | 忙碌    |
| 3 | 離開    |
| 4 | 打瞌睡   |
| 5 | 期待交易  |
| 6 | 期待玩遊戲 |
| 7 | 隐身    |

`Offline` 狀態主要適用於主帳號。 正如您應該知道的，掛卡時實際上顯示您的Steam狀態為 "在玩遊戲：XXX"，這可能會誤導您的朋友以為你在玩遊戲，而實際上您只是在掛卡。 ` Offline `狀態解決了這個問題 - 當您使用ASF掛卡時，您的帳戶永遠不會顯示為“遊戲中”。 這是可能的，因為ASF不必登錄Steam社區，即可正常工作，因此我們實際上正在玩遊戲，連接到Steam網絡，但根本沒有宣布我們的在線狀態。 請注意，離線狀態下玩的遊戲仍將計入您的遊戲時間，並在您的個人資料中顯示為“最近玩的遊戲”。

除此之外，如果您希望在ASF運行時接收通知和未讀消息，同時不打開Steam客戶端，此功能也很重要。 這是因為ASF本身充當Steam客戶端，無論ASF是否願意，Steam都會向其廣播所有這些消息和其他事件。 如果您同時運行ASF和您自己的Steam客戶端，則這不是問題，因為兩個客戶端都收到完全相同的事件。 但是，如果只有ASF正在運行，Steam網絡可能會將某些事件和消息標記為“已發送”，儘管您的傳統Steam客戶端由於不存在而未收到它。 Offline 狀態也解決了這個問題，因為在這種情況下，ASF從未被考慮參與任何社區事件，因此當您返回時，所有未讀消息和其他事件將被正確標記為未讀。

重要的是要注意，在`Offline`模式下運行的ASF將**不能**以常規的Steam聊天方式接收命令，因為聊天以及整個社區的存在實際上是完全離線的。 解決此問題的方法是使用 `invisible` 模式，它以類似的方式工作（不公開狀態），但保持接收和回應訊息的能力（因此也可關閉通知和未讀消息，如上文所述）。 ` Invisible `模式對您不希望公開（狀態方面）但仍能發送命令的備用帳戶最有意義。

但是，` Invisible `模式有一個問題——它不適用於主帳戶。 這是因為當前在線的**任何** Steam會話都將**公開**狀態，即使ASF並無此意。 這是當前在ASF端無法修復的Steam網絡限制/錯誤造成的，因此如果您想使用` Invisible `模式，您還需要確保** 所有**同一帳戶的其他會話也使用` Invisible `模式。 這种情況適用於ASF為唯一活動會話的備用帳戶，但在主帳戶上，您大概會希望將` Online `狀態顯示給您的朋友，僅隱藏ASF活動，在這種情況下` Invisible `模式對你來說毫無幫助（我們建議使用` Offline `模式）。 希望Valve將在未來解決這個限制/錯誤，但我覺得這是有生之年系列……

如果您不確定如何設置此屬性，建議對主帳戶使用 `0` (`Offline`)，並為其他帳戶使用預設值 `1` (`Online`)。

---

### `PasswordFormat`

`byte` type with default value of `0` (`PlainText`). This property defines the format of `SteamPassword` property, and currently supports values specified in the **[security](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security)** section. You should follow the instructions specified there, as you'll need to ensure that `SteamPassword` property indeed includes password in matching `PasswordFormat`. 換句話說，當您更改` PasswordFormat `后，您的` SteamPassword `格式**已經變更**。 除非你知道自己在做什麼，否則你應該保留預設值` 0 `。

If you decide to change `PasswordFormat` of a bot that has already logged in to Steam network at least once, it's possible that you'll get one-time decrypt error on the next bot's start - this is caused by the fact that `PasswordFormat` is also used in regards to automatic encryption/decryption of sensitive properties in `Bot.db` database file. You can safely ignore that error, as ASF will be able to recover from this situation on its own. If it's happening on constant basis though, e.g. each restart, it should be investigated.

---

### `RedeemingPreferences`

這是一個預設值為`0` 的 `byte flags` 屬性。 此屬性定義ASF在兌換cd-keys時的行為，定義如下：

| 值 | 名稱                                 | 描述                                                                                                                              |
| - | ---------------------------------- | ------------------------------------------------------------------------------------------------------------------------------- |
| 0 | None                               | 預設值，無特殊激活偏好                                                                                                                     |
| 1 | Forwarding                         | 將無法兌換的金鑰转發給其他機械人                                                                                                                |
| 2 | Distributing                       | 在自己和其他機械人之間分配所有密鑰                                                                                                               |
| 4 | KeepMissingGames                   | 轉發時保留（可能）缺少游戲的密鑰，不去激活它                                                                                                          |
| 8 | AssumeWalletKeyOnBadActivationCode | Assume that `BadActivationCode` keys are equal to `CannotRedeemCodeFromClient`, and therefore try to redeem them as wallet keys |

Please notice that this property is `flags` field, therefore it's possible to choose any combination of available values. Check out **[json mapping](#json-mapping)** if you'd like to learn more. 不啟用任何標誌會導致` None `選項。

` Forwarding `將導致當某機械人（如果檢查到其）缺少該特定遊戲時，將此無法兌換的密鑰轉發給另一個連接並登錄的機械人。 最常見的情況是將` AlreadyPurchased `的遊戲轉發給另一個尚未擁有該特定遊戲的機械人，但此選項還涵蓋其他場景，例如` DoesNotOwnRequiredApp `（尚未擁有遊戲本體），` RateLimited `或` RestrictedCountry `（遊戲鎖區）。

`Distributing` 命令將導致機械人在自身和其他機械人之間分發所有接收到的金鑰。 這意味著每個機械人都會從批處理中獲得一個密鑰。 通常，只有當您為同一遊戲兌換多個金鑰時，才會使用此功能，並且您希望將它們均勻地分佈在您的機械人中，而不是為各種不同的遊戲兌換金鑰。 如果您只兌換單個 `兌換` 操作中的一個金鑰，則此功能毫無意義（因為沒有要分發的額外金鑰）。

當我們無法確定被兌換的密鑰是否實際上由我們的機械人擁有時，` KeepMissingGames `將導致機械人跳過` Forwarding `。 這意味著` Forwarding `將**僅**應用於` AlreadyPurchased `遊戲密鑰，而不覆蓋其他情況，例如` DoesNotOwnRequiredApp `， ` RateLimited `或` RestrictedCountry `。 通常，您可能希望在主帳戶上使用此選項，以確保當您的機械人狀態暫時為` RateLimited `時，不會進一步轉發在其上兌換的密鑰。 正如您從描述中猜測的那樣，如果未啟用` Forwarding `，則此字段絕無效果。

`AssumeWalletKeyOnBadActivationCode` will cause `BadActivationCode` keys to be treated as `CannotRedeemCodeFromClient`, and therefore result in ASF trying to redeem them as wallet keys. This is needed because Steam might announce wallet keys as `BadActivationCode` (and not `CannotRedeemCodeFromClient` as it used to), resulting in ASF never attempting to redeem them. However, we recommend **against** using this preference, as it'll result in ASF trying to redeem every invalid key as a wallet code, resulting in excessive amount of (potentially invalid) requests sent to the Steam service, with all the potential consequences. Instead, we recommend to use `ForceAssumeWalletKey` **[`redeem^`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands#redeem-modes)** mode while knowingly redeeming wallet keys, which will enable the needed workaround only when it's required, on as-needed basis.

同時啟用` Forwarding `和` Distributing `將在轉發功能之上添加分發功能，這使得ASF首先嘗試在所有機械人上兌換一個密鑰（轉發），然後再轉移到下一個（分發）。 通常，您只希望在需要` Forwarding `時使用此選項，它改變了使用密鑰的機器人的行為，而不是始終按順序使用每個密鑰（這將是` Forwarding（僅轉發）`）。 如果您知道大多數甚至所有密鑰都綁定到同一個遊戲，這種行為會很有用，因為在這種情況下，` Forwarding `會首先嘗試在一個機械人上兌換所有密鑰（如果每個密鑰用於不同的遊戲），` Forwarding ` + ` Distributing `將在下一個密鑰上切換機械人，將新密鑰的兌換任務“分發”到另一個機械人上（如果鍵是針對同一個遊戲，那麼這是有意義的，每個密鑰將跳過一次毫無意義的嘗試）。

所有兌換方案的實際順序是按機械人名稱字母順序排列的，不包括不可用的機械人 （未連接，停止或類似情況）。 請記住，每個IP和每個帳戶在一小時内存在兌換次數的限制，並且每次以` OK `結尾的兌換嘗試都會導致失敗。 ASF將盡最大努力減少` AlreadyPurchased `失敗的次數，例如通過嘗試避免將密鑰轉發給已經擁有該特定遊戲的另一個機械人，但由於Steam處理許可證的方式，它並不總能保證工作。 使用兌換標誌（例如` Forwarding `或` Distributing `）將始終增加您觸發` RateLimited `的可能性。

還要記住，您不能將金鑰轉發或分發給您無權訪問的機械人。 這應該是顯而易見的，但請確保您至少要對兌換過程中包含所有的機器人擁有` Operator `訪問權限，例如可以執行` status ASF ` ** <a href =“https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands”>命令</a> **。

---

### `RemoteCommunication`

這是一個預設值為`3` 的 `byte flags` 屬性。 This property defines per-bot ASF behaviour when it comes to communication with remote, third-party services, and is defined as below:

| 值 | 名稱            | 描述                                                                                                                                                                                                                                                                |
| - | ------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| 0 | None          | No allowed third-party communication, rendering selected ASF features unusable                                                                                                                                                                                    |
| 1 | SteamGroup    | Allows communication with **[ASF's Steam group](https://steamcommunity.com/groups/archiasf)**                                                                                                                                                                     |
| 2 | PublicListing | Allows communication with **[ASF's STM listing](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#publiclisting)** in order to being listed, if user has also enabled `SteamTradeMatcher` in **[`TradingPreferences`](#tradingpreferences)** |

Please notice that this property is `flags` field, therefore it's possible to choose any combination of available values. Check out **[json mapping](#json-mapping)** if you'd like to learn more. 不啟用任何標誌會導致` None `選項。

This option doesn't include every third-party communication offered by ASF, only those that are not implied by other settings. For example, if you've enabled ASF's auto-updates, ASF will communicate with both GitHub (for downloads) and our server (for checksum verification), as per your configuration. Likewise, enabling `MatchActively` in **[`TradingPreferences`](#tradingpreferences)** implies communication with our server to fetch listed bots, which is required for that functionality.

Further explanation on this subject is available in **[remote communication](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Remote-communication)** section. 除非您有充分的修改理由，否則應保持它為預設值。

---

### `SendTradePeriod`

這是一個預設值為`0` 的 `byte flags` 類型。 This property works very similar to `SendOnFarmingFinished` preference in `FarmingPreferences`, with one difference - instead of sending trade when farming is done, we can also send it every `SendTradePeriod` hours, regardless of how much we have to farm left. 如果您想隨時從您的小號處 `拾取` 掛卡所得，而不必等待它完成掛卡，這將會很有幫助。 預設值 `0` 將禁用此功能，如果您想讓您的機器人向您發送交易，例如每天，您應該將此值設置為` 24 `。

Typically you'll want to use **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)** together with this feature, although it's not a requirement if you intend to handle 2FA confirmations manually in timely fashion. 如果您不確定該如何設置此屬性，請將其保留為預設值`0`。

---

### `SteamLogin`

預設值為 `null` 的 `string` 類型。 此屬性定義您的 Steam 帳號——用於登錄 Steam 的帳號。 In addition to defining steam login here, you may also keep default value of `null` if you want to enter your steam login on each ASF startup instead of putting it in the config. This may be useful for you if you don't want to save sensitive data in config file.

---

### `SteamMasterClanID`

預設值 為`0` 的 `ulong` 類型。 此屬性定義機械人應自動加入的Steam群組（包括其聊天室）的steamID。 若是要獲取群組SteamID，您可以導航到您的群組**[頁面](https://steamcommunity.com/groups/archiasf)**，然後在連結末尾加上 `/memberslistxml?xml=1` 讓它看上去像 **[t這樣](https://steamcommunity.com/groups/archiasf/memberslistxml?xml=1)**. 然後，您可以從 `<groupID64>` 標籤處獲取您群組的 SteamID。 在上面的例子中，它將是 `103581414460998`。 除了嘗試在啟動時加入給定的組，機械人還會自動接受該組的組邀請，這使您可以在您的組啟用私人會員資格時手動邀請您的機械人 。 如果您沒有專門用於您的機器人的任何群組，則應保留此屬性預設值為 `0`。

---

### `SteamParentalCode`

預設值為 `null` 的 `string` 類型。 此屬性定義您的 Steam 家庭監護 PIN 碼。 ASF requires an access to resources protected by steam parental, therefore if you use that feature, you should provide ASF with parental unlock PIN, so it can operate normally. 預設值 `null` 意味著無需 Steam 家庭監護 PIN 碼即可解鎖此帳戶，如果您不使用Steam 家庭監護功能，這可能就是您想要的。

In limited circumstances, ASF is also able to generate a valid Steam parental code itself, although that requires excessive amount of OS resources and additional time to complete, not to mention that it's not guaranteed to succeed, therefore we recommend to not rely on that feature and instead put valid `SteamParentalCode` in the config for ASF to use. If ASF determines that PIN is required, and it'll be unable to generate one on its own, it'll ask you for input.

---

### `SteamPassword`

預設值為 `null` 的 `string` 類型。 此屬性定義您的 Steam 密碼——用於登錄 Steam 的密碼。 In addition to defining steam password here, you may also keep default value of `null` if you want to enter your steam password on each ASF startup instead of putting it in the config. This may be useful for you if you don't want to save sensitive data in config file.

---

### `SteamTradeToken`

預設值為 `null` 的 `string` 類型。 當您的機械人在您的好友列表中時，機械人無需代碼即可以立即向您發送交易，因此您可以將此屬性保留為預設值 ` null `。 但是，如果您決定不將您的機械人放在您的朋友列表中，而您又期望此機械人向您發送交易，那麼您將需要生成並填充交易代碼。 換句話說，此屬性應填充**此** 機械人實例的` SteamUserPermissions `中設置的` Master `權限的帳戶的交易代碼。

為了找到您的代碼，若使用` Master `權限用戶登錄，請導航至** [此處](https://steamcommunity.com/my/tradeoffers/privacy) **並查看您的交易網址。 我們要尋找的代碼是位於您的交易連結中 `&token=` 部分之後的 8 個字元。 您應該複製並粘貼這 8 個字元於`steamtradetoken`處。 並不包含整個交易連接，亦無需 `&token=` 部分，僅僅需要代碼本身（8個字元）。

---

### `SteamUserPermissions`

預設值為空的`ImmutableDictionary<ulong, byte>` 類型。 此屬性是一個字典屬性，它將由64位SteamID標識的給定Steam用戶映射到` byte `編號，該編號定義此用戶在ASF實例中的權限。 ASF中當前可用的機械人權限定義為：

| 值 | 名稱            | 描述                                                              |
| - | ------------- | --------------------------------------------------------------- |
| 0 | None          | 無特殊權限，這主要是分配給SteamID不在設置中的用戶——無需定義具有此權限的任何人                     |
| 1 | FamilySharing | 提供親友同享用戶的最低訪問權限。 再一次，這主要是一個參考值，因為ASF能夠自動發現我們允許使用我們的庫的用户的SteamID |
| 2 | Operator      | 提供對給定機械人實例的基本訪問權限，主要是添加許可證和兌換密鑰                                 |
| 3 | Master        | 提供對給定機械人實例的完全訪問權限                                               |

簡而言之，此屬性允許您自訂給定使用者的許可權。 權限主要用於訪問ASF ** [命令](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands) **，但也用於啟用許多ASF功能 ，如接受交易。 例如，您可能希望將自己的帳戶設置為` Master `，並為您的2-3位朋友提供` Operator `訪問權限，以便他們可以使用ASF輕鬆為您的機械人兌換密鑰， 但卻**不能**停止它。 因此，您可以輕鬆地將許可權分配給給定的用戶，並讓他們在您指定的範圍內使用您的機械人。

我們建議您只設置一位 `master` 用戶，至於權限為 `Operators` 及以下的用戶，您可以儘管設置您希望的任意數量。 While it's technically possible to set multiple `Masters` and ASF will work correctly with them, for example by accepting all of their trades sent to the bot, ASF will use only one of them (with lowest steam ID) for every action that requires a single target, for example a `loot` request, so also properties like `SendOnFarmingFinished` preference in `FarmingPreferences` or `SendTradePeriod`. If you perfectly understand those limitations, especially the fact that `loot` request will always send items to the `Master` with lowest steam ID, regardless of the `Master` that actually executed the command, then you can define multiple users with `Master` permission here, but we still recommend a single master scheme.

值得注意的是，還有一個額外的` Owner `權限，它被定義於` SteamOwnerID `全域配置屬性。 您不能為這裡的任何人分配 `Owner` 許可權，因為 `SteamUserPermissions` 屬性僅定義與機械人實例相關的許可權，而不是定義整個 ASF 進程。 對於與機械人相關的任務，` SteamOwnerID `與` Master `的處理方式相同，因此不需要在此處定義` SteamOwnerID `。

---

### `TradeCheckPeriod`

這是一個預設值為`60`的`byte`類型屬性。 Normally ASF handles incoming trade offers right after receiving notification about one, but sometimes because of Steam glitches it can't do it at that time, and such trade offers remain ignored until next trade notification or bot restart occurs, which may lead to trades being cancelled or items not available at that later time. If this parameter is set to a non-zero value, ASF will additionally check for such outstanding trades every `TradeCheckPeriod` minutes. Default value is selected with balance between additional requests to steam servers and losing incoming trades in mind. However, if you are just using ASF to farm cards, and don't plan to automatically process any incoming trades, you may set it to `0` to disable this feature completely. On the other hand, if your bot participates in public [ASF's STM listing](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#publiclisting) or provides other automated services as a trade bot, you may want to decrease this parameter to `15` minutes or so, to process all trades in a timely manner.

---

### `TradingPreferences`

這是一個預設值為`0` 的 `byte flags` 屬性。 此屬性定義ASF在交易中的行為，定義如下：

| 值  | 名稱                  | 描述                                                                                                                                                                                      |
| -- | ------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| 0  | None                | 預設值，無特殊交易偏好                                                                                                                                                                             |
| 1  | AcceptDonations     | 接受對我們無任何損失的交易                                                                                                                                                                           |
| 2  | SteamTradeMatcher   | 被動參與 **[STM](https://www.steamtradematcher.com)**交易。 訪問 **[交易](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading#steamtradematcher)** 了解更多資訊                                  |
| 4  | 匹配所有物品              | 需要設置 `SteamTradeMatcher`, 並與其同時使用--除了對我們有利的和無損的交易外, 還接受不利交易                                                                                                                             |
| 8  | DontAcceptBotTrades | 不自動接受來自其他機械人實例的 `loot` 交易                                                                                                                                                               |
| 16 | MatchActively       | 主動參與 **[STM](https://www.steamtradematcher.com)**交易。 Visit **[ItemsMatcherPlugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#matchactively)** for more info |

Please notice that this property is `flags` field, therefore it's possible to choose any combination of available values. Check out **[json mapping](#json-mapping)** if you'd like to learn more. 不啟用任何標誌會導致` None `選項。

有關ASF交易邏輯的進一步說明以及每個可用標誌的說明，請訪問** [交易](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading) **部分。

---

### `TransferableTypes`

預設值為 `1，3，5` 的 `ImmutableHashSet<byte>` 類型。 This property defines which Steam item types will be considered for transfering between bots, during `transfer` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. ASF將確保交易提案中僅會包含符合` TransferableTypes `的物品，因此該屬性允許您選擇要在發送給您的某個機械人的交易提案中收到的物品。

| 值  | 名稱                    | 描述                                           |
| -- | --------------------- | -------------------------------------------- |
| 0  | Unknown               | 不屬於以下任何類型的類型                                 |
| 1  | BoosterPack           | 包含3張來自同一遊戲的卡片的擴充包                            |
| 2  | Emoticon              | 在Steam聊天中使用的表情符號                             |
| 3  | FoilTradingCard       | 閃亮類型的`TradingCard`                           |
| 4  | ProfileBackground     | 可在您的Steam個人資料頁中使用的背景                         |
| 5  | TradingCard           | Steam交易卡片，可用於合成徽章 (非閃卡）                      |
| 6  | SteamGems             | 用於製作擴充包的 Steam 寶石，包括寶石袋                      |
| 7  | SaleItem              | Steam特賣期間獲得的特殊物品                             |
| 8  | Consumable            | 使用後消失的特殊小玩意兒                                 |
| 9  | 個人檔案修改器               | 可以修改Steam設定檔外觀的特殊物品                          |
| 10 | Sticker               | Special items that can be used on Steam chat |
| 11 | ChatEffect            | Special items that can be used on Steam chat |
| 12 | MiniProfileBackground | Special background for Steam profile         |
| 13 | AvatarProfileFrame    | Special avatar frame for Steam profile       |
| 14 | AnimatedAvatar        | Special animated avatar for Steam profile    |
| 15 | KeyboardSkin          | Special keyboard skin for Steam deck         |
| 16 | StartupVideo          | Special startup video for Steam deck         |

Please note that regardless of the settings above, ASF will only ask for **[Steam community items](https://steamcommunity.com/my/inventory/#753_6)** (`appID` of 753, `contextID` of 6), so all game items, gifts and likewise, are excluded from the trade offer by definition.

ASF 預設基於機器人的最常見用法，僅交易擴充包和交易卡片（包括閃亮卡片）。 這裏定義的屬性允許你以任何令你滿意的方式改變這種行為。 請記住，上面未定義的所有類型都將顯示為` Unknown `類型，這在Valve發布一些新的Steam項目時尤為重要，該項目將被ASF標記為` Unknown `，直到它被添加到這裡（在將來的版本中）。 這就是為什麼一般不建議在` TransferableTypes `中選擇` Unknown `類型，除非您知道自己在做什麼，並且還瞭解萬一Steam 網絡崩潰並將您的所有商品標記為` Unknown `，ASF會在交易提案中發送您的整個庫存。 在此我強烈建議不要在`TransferableTypes` 中選擇 `Unknown` 類型，即使您真的希望交易任何類型的物品。

---

### `UseLoginKeys`

預設值為 `true` 的 `bool` 類型。 此屬性定義ASF是否應使用此Steam帳戶的登錄密鑰機制。 登錄密鑰機制與官方Steam客戶端的“記住我”選項非常相似，這使得ASF可以存儲和使用臨時一次性登錄密鑰進行下一次登錄嘗試，只要我們的登錄密鑰有效，這就可以避免提供密碼、Steam Guard 或 2FA 代碼的需求。 登錄密鑰存儲在` BotName.db `文件中並會自動更新。 因此在使用ASF成功登錄一次後不需要再提供密碼/ SteamGuard / 2FA代碼。

為方便起見，預設情況下使用已保存的登錄密鑰，因此您無需在每次登錄時輸入` SteamPassword `，SteamGuard或2FA代碼（未啓用**[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)**的話）。 這也是優越的替代方法，因為登錄金鑰只能使用一次，故您的原始密碼不會以任何方式顯示。 它與您的Steam客戶端完全相同的方法，會保存您的帳戶名和登錄密鑰以用於下次登錄嘗試，與使用` UseLoginKeys `和` SteamLogin `並在ASF中清空` SteamPassword `的方式別無二致。

但是，有些人可能在意這個細節，因此如果您想確保ASF不會存儲任何類型的代碼以允許其在關閉後恢復上一個會話，這裡可以啓用此選項，這將導致每次登錄嘗試都必須進行完全身份驗證。 禁用此選項的工作原理與在官方 Steam 用戶端不勾選「記住我」完全相同。 除非您知道自己在做什麼，否則應將其保留為預設值 `true`。

---

### `UserInterfaceMode`

這是一個預設值為`0` 的 `byte flags` 類型。 This property specifies user interface mode that the bot will be announced with after logging in to Steam network. Currently you can choose one of below modes:

| 值   | 名稱         |
| --- | ---------- |
| `0` | Default    |
| `1` | BigPicture |
| `2` | Mobile     |

如果您不確定該如何設置此屬性，請將其保留為預設值`0`。

---

## 檔案結構

ASF 使用的檔結構相當簡單。

```text
├── config
│     ├── ASF.json
│     ├── ASF.db
│     ├── Bot1.json
│     ├── Bot1.db
│     ├── Bot2.json
│     ├── Bot2.db
│     └── ...
├── ArchiSteamFarm.dll
├── log.txt
└── ...
```

為了將ASF移動到新位置，例如另一台PC，只需移動/複製` config `目錄就足夠了，這是執行任何形式的“ASF備份”的推薦方式，因為您始終可以從GitHub下載剩餘的（程序）部分，同時不存在破壞內部ASF檔案的風險，例如錯誤備份。

`logt 123. txt` 檔保存您上一次運行 ASF 生成的日誌。 此檔案不包含任何敏感信息，在涉及問題、崩潰或僅作為上次 ASF 運行中的信息日誌時非常有用。 如果您遇到問題或錯誤，我們會經常詢問此檔案。 ASF會自動為您管理此檔案，但如果您是進堦用戶，您可以進一步調整ASF ** [記錄](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Logging) **模組。

ASF及其所有機械人配置保存於` config `目錄中。

`ASF.json` 是 ASF 全域配置檔。 此配置用於定義ASF如何作為進程運行，這會影響程序本身和所有機械人。 您可以在那裡找到全域屬性，例如ASF進程所有者，自動更新或調試。

` BotName.json `是給定機械人實例的配置。 此配置用於指定給定機械人實例的行為方式，因此這些設置僅適用於該機械人，而不是與其他機械人共享。 這允許您配置具有各種不同設置的機械人，而無需要求所有機械人都以完全相同的方式工作。 每個機器人都由您在` BotName `中選擇的唯一標識符命名。

除了設定檔外，ASF還使用 `config` 目錄來存儲數據庫。

`ASF.db` 是一個全域ASF數據庫檔。 它充當全域持久存儲，用於保存與 ASF 進程相關的各種信息，例如本地 Steam 伺服器的IP地址。 **您不應對此檔進行任何改變**。

` BotName.db `是給定機械人實例的數據庫。 此檔用於在持久存儲有關給定機械人實例的關鍵數據，如登錄金鑰或 ASF 2FA 代碼。 **您不應對此檔進行任何改變**。

`BotName.keys` 是一個用於將序號導入 **[後台序號啟動器](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer)**的特殊檔。 It's not mandatory and not generated, but recognized by ASF. 成功導入金鑰後，此檔將自動被刪除。

`BotName.maFile` 是一個用於導入 **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)**的特殊檔。 It's not mandatory and not generated, but recognized by ASF if your `BotName` does not use ASF 2FA yet. 成功導入 ASF 2FA 後，此檔將自動被刪除。

---

## JSON 映射

每個配置屬性都有相應的類型。 屬性的類型定義了有效值。 只能使用對給定類型有效的值——如果使用無效值，ASF 將無法分析您的配置。

**我們強烈建議您使用ConfigGenerator生成配置檔** ——它會為您處理大多數初級內容（例如類型驗證），因此您只需要輸入正確的值，而不需要了解下面指定的變量類型。 本節主要用於手動生成/編輯配置的用戶，使得他們知道可以使用哪些值。

ASF 使用的類型是本機 C＃類型，如下所示：

---

`bool`——布林類型，僅接受 `true` 和 `false` 值。

範例：`"Enabled": true`

---

`byte`——無符號字節類型，取值範圍為從` 0 `到` 255 `（包括）的整數。

範例：`"ConnectionTimeout": 90`

---

`ushort`——無符號短整數類型，取值範圍為從` 0 `到` 65535 `（包括）的整數。

範例：`"WebLimiterDelay": 300`

---

`uint`——無符號整數類型，取值範圍為從 `0` 到 `4294967295`（包括）的整數。

---

`ulong`——無符號長整數類型，僅接受從取值範圍為從 `0` 到 `184674407791615` （包括）的整數。

範例：`"SteamMasterClanID": 103582791440160998`

---

`string`——字串類型，接受任何字元序列，包括空值 `""` 和 `null`。 ASF將空序列和` null `值視為相同，因此您可以根據自己的喜好選擇使用哪一個（我們推薦使用` null `）。

範例：`"SteamLogin": null`, `"SteamLogin": ""`, `"SteamLogin": "MyAccountName"`

---

`Guid?` - Nullable UUID type, in JSON encoded as string. UUID is made out of 32 hexadecimal characters, in range from `0` to `9` and `a` to `f`. ASF accepts variety of valid formats - lowercase, uppercase, with and without dashes. In addition to valid UUID, since this property is nullable, a special value of `null` is accepted to indicate lack of UUID to provide.

Examples: `"LicenseID": null`, `"LicenseID": "f6a0529813f74d119982eb4fe43a9a24"`

---

`ImmutableList<valueType>` - Immutable collection (list) of values in given `valueType`. 在 JSON 中, 它被定義為給定 `valueType` 中的元素陣列。 ASF uses `List` to indicate that given property supports multiple values and that their order might be relevant.

Example for `ImmutableList<byte>`: `"FarmingOrders": [15, 11, 7]`

---

`ImmutableHashSet<valueType>` —— 給定 `valueType`中唯一值的集合。 在 JSON 中, 它被定義為給定 `valueType` 中的元素陣列。 ASF uses `HashSet` to indicate that given property makes sense only for unique values and that their order doesn't matter, therefore it'll intentionally ignore any potential duplicates during parsing (if you happened to supply them anyway).

`ImmutableHashSet<uint>`的範例：`"Blacklist": [267420, 303700, 335590]`

---

`ImmutableDictionary<keyType, valueType>` - Immutable dictionary (map) that maps a unique key specified in its `keyType`, to value specified in its `valueType`. 在JSON中，它被定義為具有鍵值對的對象。 請記住，在這種情況下始終引用` keyType `，即使它是例如` ulong `的值類型。 There is also a strict requirement of the key being unique across the map, this time enforced by JSON as well.

`ImmutableDictionary<ulong, byte>`的範例： `"SteamUserPermissions": { "76561198174813138": 3, "76561198174813137": 1 }`

---

` flags `——Flags屬性通過應用按位運算將幾個不同的屬性組合成一個最終值。 這允許您同時選擇各種不同允許值的任何可能組合。 最終值為所有已啟用選項的值的總和。

舉例來說，給出以下的值：

| 值 | 名稱 |
| - | -- |
| 0 | 無  |
| 1 | A  |
| 2 | B  |
| 4 | C  |

使用` B + C `會得到` 6 `的值，使用` A + C `會得到` 5 `的值， 使用` C `會得到` 4 `的值，依此類推。 這允許您創建任何可能的啟用值組合——如果您決定啟用所有這些值，` None + A + B + C `，您將獲得` 7 `。 另請注意，按定義，值為` 0 `的標誌在所有其他可用組合中都啟用，因此通常它是一個不能啟用任何內容的標誌（例如` None `）。

如您所見，在上面的示例中，我們有3個可用的標誌來啓用/停用（` A `，` B `，` C `），以及< code> 8 </code>种整體可能的值：
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

## 兼容性映射

Due to JavaScript limitations of being unable to properly serialize simple `ulong` fields in JSON when using web-based ConfigGenerator, `ulong` fields will be rendered as strings with `s_` prefix in the resulting config. This includes for example `"SteamOwnerID": 76561198006963719` that will be written by our ConfigGenerator as `"s_SteamOwnerID": "76561198006963719"`. ASF 包含自動處理此字符串映射的正確邏輯，因此配置中的` s _ `條目實際上是正確生成且有效的。 如果您打算自己生成配置，我們建議盡可能堅持使用原始` ulong `字段，但如果您不能這樣做，您也可以遵循此規則並使用將它們編碼為以`s_`為前綴的字符串 。 我們希望這個JavaScript限制能最終被解決。

---

## 配置兼容性

It's top priority for ASF to remain compatible with older configs. As you should already know, missing config properties are treated the same as they would be defined with their **default values**. Therefore, if new config property gets introduced in new version of ASF, all your configs will remain **compatible** with new version, and ASF will treat that new config property as it'd be defined with its **default value**. 您可以隨時根據需要添加，刪除或編輯配置屬性。

We recommend to limit defined config properties only to those that you want to change, since this way you automatically inherit default values for all other ones, not only keeping your config clean but also increasing compatibility in case we decide to change a default value for property that you don't want to explicitly set yourself (e.g. `WebLimiterDelay`).

Due to above, ASF will automatically migrate/optimize your configs by reformatting them and removing fields that hold default value. You can disable this behaviour with `--no-config-migrate` **[command-line argument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments#arguments)** if you have a specific reason, for example you're providing read-only config files and you don't want ASF to modify them.

---

## 自動重載

ASF is aware of configs being modified "on-the-fly" - thanks to that, ASF will automatically:
- 創建配置時，新增（並在需要時啟動）新的機械人實例
- 刪除其配置時停止（如果需要）並刪除舊的機械人實例
- 編輯其配置時，停止（並在需要時啟動）任何機械人實例
- 重命名機械人的配置時，以新名稱重新啟動（如果需要的話）該機械人

以上所有內容都是透明的，無需重新啟動程序或殺死其他（未受影響的）機械人程序實例即可自動完成。

In addition to that, ASF will also restart itself (if `AutoRestart` permits) if you modify core ASF `ASF.json` config. Likewise, program will quit if you delete or rename it.

You can disable this behaviour with `--no-config-watch` **[command-line argument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments#arguments)** if you have a specific reason, for example you don't want from ASF to react to file changes in `config` folder.