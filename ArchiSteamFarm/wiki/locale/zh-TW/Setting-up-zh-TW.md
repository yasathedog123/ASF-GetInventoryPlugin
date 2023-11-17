# 新手上路

如果您是第一次來到這裡，歡迎！ 我們很高興又看到一位對我們的專案感興趣的旅客，但請記住：能力越強，責任越大⸺只要您&#8203;**足夠認真學習如何使用它**&#8203;，ASF就能完成相當多的Steam相關事務。 學習的過程將充滿艱辛與坎坷，我們希望您閱讀與之相關的Wiki，並詳細了解這一切是如何運作的。

如果您還在這裡，那就代表您堅持看完了上面的文字，做得不錯。 除非您跳過了它，那樣的話，您很快就會經歷一段&#8203;**[不好的時光](https://www.youtube.com/watch?v=WJgt6m6njVw)**&#8203;…… 總的來說，ASF是一個控制台應用程式，也就是說程式本身沒有您習慣的GUI介面。 ASF主要是設計執行於伺服器中，所以它更偏向為一個服務（常駐程式），而非桌面應用程式。

但是，這並不代表您無法在電腦上使用ASF，或是使用起來會比一般的程式更為複雜。 ASF是一個獨立的免安裝應用程式，可以直接使用。但在此之前，需要先進行組態設定。 設定檔會告訴ASF啟動之後應該做什麼。 若您在沒有設定檔的情形下啟動它，那麼，ASF將不會做任何事情，就是如此簡單。

---

## 適用於您的作業系統的設定

在一般情形下，這是我們在接下來的幾分鐘內要做的事情：
- 安裝&#8203;**[.NET需求套件](#net-需求套件)**&#8203;。
- 在&#8203;**[ASF發布頁面](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)**&#8203;下載適用於您的作業系統的版本變體。
- 將壓縮檔解壓縮至一個新資料夾中。
- **[設定ASF](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-zh-TW)**&#8203;。
- 執行ASF，並見證奇蹟！

聽起來十分簡單，對吧？ 那就讓我們繼續吧。

---

### .NET 需求套件

首要步驟，是確保您的作業系統可以正確地啟動ASF。 ASF是用C#語言編寫的，基於.NET平台，並可能需要您平台上尚未擁有的原生函式庫。 取決您使用的是Windows、Linux還是macOS，您將有不同的系統需求，所有要求都列在您應遵循的&#8203;**[.NET需求套件](https://docs.microsoft.com/dotnet/core/install)**&#8203;文件中。 這是我們應當使用的參考資料，但為了簡單起見，我們在下面額外列出需要的所有軟體套件。因此您無需閱讀完整的文件。

若您已安裝並使用了其他第三方軟體，一些（甚至全部）相依性套件已存在於您的作業系統上，是很正常的。 不過您仍應在作業系統上執行適合的安裝程式，來確保這些軟體確實已被安裝⸺缺少這些相依套件，ASF將完全無法啟動。

請注意，您不需要特地為特定作業系統的組建版本做其他任何事情，特別是.NET SDK的安裝或執行環境，因為它們已包含於作業系統套件中。 您只需要安裝必要的.NET相依需求套件，即可執行ASF裡面自帶的.NET執行環境。

#### **[Windows](https://docs.microsoft.com/dotnet/core/install/windows)**&#8203;：
- **[Microsoft Visual C++可轉散發套件更新](https://docs.microsoft.com/cpp/windows/latest-supported-vc-redist?view=msvc-170#visual-studio-2015-2017-2019-and-2022)**&#8203;（&#8203;**[x64](https://aka.ms/vs/17/release/vc_redist.x64.exe)**&#8203;適用於64位元Windows；&#8203;**[x86](https://aka.ms/vs/17/release/vc_redist.x86.exe)**&#8203;適用於32位元Windows）
- 強烈建議您，務必確保已安裝所有的Windows更新。 您至少需要安裝&#8203;**[KB2533623](https://support.microsoft.com/en-us/help/2533623/microsoft-security-advisory-insecure-library-loading-could-allow-remot)**&#8203;、&#8203;**[KB2999226](https://support.microsoft.com/en-us/help/2999226/update-for-universal-c-runtime-in-windows)**&#8203;，但仍可能需要更多的更新。 如果您的Windows已更新至最新版，則上述更新補丁皆已安裝。 在安裝Visual C++套件前，請確保滿足上述需求。

#### **[Linux](https://docs.microsoft.com/dotnet/core/install/linux)**&#8203;：
套件名稱取決於您使用的Linux發行版本，我們列出了最常見的套件名稱。 您可以使用本機中的套件管理系統，為您的作業系統取得全部套件（例如適用於Debian的&#8203;`apt`&#8203;，或適用於CentOS的&#8203;`yum`&#8203;）。

- `ca-certificates`&#8203;（用於建立HTTPS連線的標準可信賴的SSL憑證）
- `libc6`&#8203;（&#8203;`libc`&#8203;）
- `libgcc1`&#8203;（&#8203;`libgcc`&#8203;）
- `libicu`&#8203;（&#8203;`icu-libs`&#8203;，您的發行版本的最新版，例如&#8203;`libicu67`&#8203;）
- `libgssapi-krb5-2`&#8203;（&#8203;`libkrb5-3`&#8203;、&#8203;`krb5-libs`&#8203;）
- `libssl1.1`&#8203;（&#8203;`libssl`&#8203;、&#8203;`openssl-libs`&#8203;，您的發行版本的最新版，且至少為&#8203;`1.1.X`&#8203;版本，因為&#8203;`1.0.X`&#8203;版本可能無法運作）
- `libstdc++6`&#8203;（&#8203;`libstdc++`&#8203;，&#8203;`5.0`&#8203;版本或更高）
- `zlib1g`&#8203;（&#8203;`zlib`&#8203;）

上述大多數套件應早已安裝於您的系統中。 Debian穩定版的最小安裝也只需再安裝&#8203;`libicu67`&#8203;即可。

#### **[macOS](https://docs.microsoft.com/dotnet/core/install/macos)**&#8203;：
- 暫時沒有需求，但您仍應安裝最新版本的macOS，至少為10.15+版本

---

### 下載

既然我們有了所有的相依性套件，那麼接下來就是下載&#8203;**[ASF最新版本](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)**&#8203;。 ASF有許多變體版本可供使用，但您應使用符合您作業系統及其架構的版本套件。 舉例來說，假設您使用&#8203;`64`&#8203;位元&#8203;`Win`&#8203;dows，那麼您需使用&#8203;`ASF-win-x64`&#8203;版本的套件。 欲取得關於可用變體的更多資訊，請參閱&#8203;**[相容性](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility-zh-TW)**&#8203;章節。 ASF也可以執行於沒有提供組建版本的作業系統上，例如&#8203;**32位元Windows**&#8203;，請前往&#8203;**[安裝Generic版本套件](#安裝-generic-版本套件)**&#8203;繼續閱讀。

![資源檔案](https://i.imgur.com/Ym2xPE5.png)

下載完成後，請先解壓縮.zip檔至一個資料夾中。 若您需要特定的工具，&#8203;**[7-zip](https://www.7-zip.org)**&#8203;即可做到，不過使用任何標準工具（例如Linux/macOS中的&#8203;`unzip`&#8203;工具）應該也沒有問題。

我們也建議將ASF解壓縮到&#8203;**獨立資料夾**&#8203;中，而不是包含其他檔案的資料夾中：ASF的自動更新功能會在升級時刪除所有舊的或無關的檔案，並可能導致您遺失儲存於ASF資料夾中的其餘檔案。 若您有任何額外用於ASF的腳本或檔案，請將它們存放於ASF的上層資料夾。

一個檔案結構範例，看起來會像是這樣：

```text
C:\ASF（可存放您自己的東西）
    ├── ASF shortcut.lnk（選擇性）
    ├── Config shortcut.lnk（選擇性）
    ├── Commands.txt（選擇性）
    ├── MyExtraScript.bat（選擇性）
    ├── (...)（其餘您想存放的檔案，選擇性）
    └── Core（ASF專用資料夾，也就是您解壓縮壓縮檔的地方）
         ├── ArchiSteamFarm(.exe)
         ├── config
         ├── logs
         ├── plugins
         └── (...)
```

---

### 組態設定

現在只剩最後一步：組態設定。 這是迄今為止最複雜的步驟，因為它包含了許多您還不熟悉的新資訊，所以我們在此會嘗試提供一些讓您便於理解的範例及簡明扼要的解釋。

首先，&#8203;**[組態設定](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-zh-TW)**&#8203;頁面解釋了與設定檔相關的&#8203;**一切事物**&#8203;，但它包含了數量龐大的新資訊，其中有很大一部分是我們不需要立即了解的。 但我們會教您如何取得您真正需要查找的資訊。

您可以透過至少三種方式來設定ASF：設定檔生成器網頁工具、ASF-ui或是手動設定。 這在&#8203;**[組態設定](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-zh-TW)**&#8203;章節中有深入的解釋，若您想要取得更多詳細資訊，請參閱此部分。 我們先以設定檔生成器網頁工具為例。

使用您常用的瀏覽器造訪我們的&#8203;**[設定檔生成器](https://justarchinet.github.io/ASF-WebConfigGenerator)**&#8203;網頁工具，若您手動停用了JavaScript，您需要重新啟用它。 我們建議使用Chrome或Firefox，但本工具應該也能在大部分的主流瀏覽器上運作。

開啟頁面後，切換到「Bot」分頁。 您應該會看見類似於下圖的頁面：

![Bot 分頁](https://i.imgur.com/aF3k8Rg.png)

如果您剛剛下載的ASF版本低於設定檔生成器的預設值，只需在下拉式選單中選擇您的ASF版本。 這種情形會在設定檔生成器用於尚未標示為穩定版的更新版本（預覽版）ASF時發生。 您下載的最新穩定版本的ASF，是證實能穩定運作的版本。

首先將您的Bot名稱輸入至紅色醒目的欄位中。 您可以使用任何名稱，例如您的暱稱、帳號名稱、一串數字或是任何其他文字。 其中只有一個您無法使用的名稱，&#8203;`ASF`&#8203;，因為這個關鍵字是為全域設定檔保留的。 除此之外，Bot的名稱不能以一個點作為開頭（ASF會略過那些檔案）。 並建議您避免使用空格，如有需要，請使用「&#8203;`_`&#8203;」作為分隔符號。

在您決定好名稱後，將「Enabled」選項開啟，這個選項會決定您的Bot是否會在ASF開啟後自動啟用。

您接下來會面臨一項選擇：
- 您可以將帳號名稱及密碼分別填入&#8203;`SteamLogin`&#8203;與&#8203;`SteamPassword`&#8203;欄位中
- 或是將兩個欄位留空

如果填入，可以使ASF在開啟時自動使用您的帳號憑證，這樣您就無需在每次ASF需要這些資訊時，都手動輸入它們。 不過，您也可以選擇不填入帳號密碼，這樣它們就不會被儲存。但缺少這些資訊，ASF會無法自動登入，您需要在執行期間手動輸入。

ASF需要您的登入憑證，因為它是透過內建的Steam用戶端來實現的，且需要跟您自己使用的用戶端相同的登入資訊。 您的登入憑證只會儲存在您電腦上ASF的&#8203;`config`&#8203;資料夾中，我們的設定檔生成器也是基於用戶端的網頁工具，也就是說，程式碼是在您本機的瀏覽器中執行，以此來生成ASF設定檔。您輸入的資訊永遠不會從您的電腦傳送出去，所以您不必擔心任何可能的敏感性資料洩漏。 儘管如此，我們能理解您仍可能出於某些原因不想輸入登入資訊。您可以稍後再手動輸入到產生的檔案中，或者徹底略過，並只在ASF的命令提示字元中輸入。 更多安全性問題，請參閱&#8203;**[組態設定](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-zh-TW)**&#8203;章節。

您也可以省略其中一個欄位，例如&#8203;`SteamPassword`&#8203;，這樣ASF仍能自動登入，但會向您詢問密碼（類似Steam用戶端）。 若您使用Steam家庭監護帳號，您會需要將PIN碼填入&#8203;`SteamParentalCode`&#8203;欄位來解鎖。

在這些操作完成後，您的網頁現在看起來會像是下圖：

![Bot 分頁 2](https://i.imgur.com/yf54Ouc.png)

現在您可以點擊「下載」按鈕，設定檔生成器會生成一個名為您剛才輸入的名稱的&#8203;`.json`&#8203;檔。 將這個檔案儲存至&#8203;`config`&#8203;資料夾中，該資料夾位於您在上個步驟解壓縮.zip檔後，得到的資料夾中。

現在，您的&#8203;`config`&#8203;資料夾看起來會像這樣：

![結構 2](https://i.imgur.com/crWdjcp.png)

恭喜！ 您剛剛完成了最基本的ASF Bot組態設定。 我們之後會擴充設定檔，而現在您暫時只需要這些。

---

### 執行 ASF

現在您已經準備好第一次啟動程式了。 只需雙擊ASF資料夾中的&#8203;`ArchiSteamFarm`&#8203;二進制執行檔即可。 您也可以使用控制台來開啟它。

開啟後，若您在第一步正確安裝了所有需要的相依性套件，ASF應該會正常啟動。如果您沒忘記把生成的設定檔存放至&#8203;`config`&#8203;資料夾中，就可以看到ASF正嘗試登入您的第一個Bot：

![ASF](https://i.imgur.com/u5hrSFz.png)

若您在設定檔中提供了&#8203;`SteamLogin`&#8203;和&#8203;`SteamPassword`&#8203;給ASF使用，ASF就只會詢問您的Steam Guard權杖（電子郵件、雙重驗證驗證器或沒有額外權杖，取決於您的Steam設定）。 若您並未提供您的Steam帳號名稱及密碼，ASF也會同時詢問它們。

如果您對ASF有任何的擔心，例如以您的身分進行操作，或是被加入我們的Steam群組，現在可以到&#8203;[**遠端通訊**](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Remote-communication-zh-TW)&#8203;章節閱讀。

在輸入資訊後，假設您填寫的資訊無誤，您會成功地登入，而ASF將會使用您現階段還未修改的預設設定來開始掛卡：

![ASF 2](https://i.imgur.com/Cb7DBl4.png)

這代表ASF現在已成功地在您的帳號上運作，您可以將程式最小化，然後去做其他事情。 在經過足夠的時間後（取決於&#8203;**[效能](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance-zh-TW)**&#8203;），您將會看到Steam交換卡片慢慢掉落。 當然，要做到這一點，您必須先擁有可以掛卡的遊戲，它會在您的&#8203;**[徽章頁面](https://steamcommunity.com/my/badges)**&#8203;中顯示「還有X張卡片會掉落」；如果沒有可供掛卡的遊戲，ASF將不做任何事情，如&#8203;**[常見問題](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ-zh-TW#什麼是-asf)**&#8203;中所述。

我們最基本的新手上路指南到此結束。 您現在可以決定要進一步設定ASF，或是讓ASF以預設設定運作。 我們將會介紹更多基本細節，然後您可以自己探索整個Wiki。

---

### 延伸設定

#### 同時掛卡多個帳號

ASF支援一個帳號以上的同時掛卡，這也是它的主要功能。 您可以透過生成更多Bot設定檔來增加更多帳號，方法跟您幾分鐘前產生的第一個設定檔完全相同。 您只需要確保兩件事：

- 唯一的Bot名稱，假如您的第一個Bot叫做「MainAccount」，您就不能擁有另一個跟它名稱一樣的Bot。
- 正確的登入資訊，例如&#8203;`SteamLogin`&#8203;、&#8203;`SteamPassword`&#8203;和&#8203;`SteamParentalCode`&#8203;（如果使用Steam家庭監護功能）

也就是說，就是再次回到組態設定的部分，然後做完全一樣的事情，只不過這次要填入您第二或是第三個帳號的資訊。 記住，您所有的Bot名稱都是唯一的。

---

#### 修改設定

您可以透過相同的方式來修改現有的設定：產生一個新的設定檔。 若您還沒有關閉設定檔生成器網頁工具，按一下「開啟／關閉進階設定」然後看看裡面有些什麼。 在本篇教學中，我們會修改&#8203;`CustomGamePlayedWhileFarming`&#8203;選項，這個選項可以使ASF在掛卡時顯示自訂名稱，而不是實際上的遊戲名稱。

讓我們現在開始教學。如果您執行了ASF並開始掛卡，在預設情形下，您會看到您的Steam帳號正在遊戲中：

![Steam](https://i.imgur.com/1VCDrGC.png)

我們來修改它。 在設定檔生成器網頁工具上按一下「開啟／關閉進階設定」，然後找到&#8203;`CustomGamePlayedWhileFarming`&#8203;。 找到後，輸入您想要顯示的的自訂文字，例如「正在掛卡」：

![Bot 分頁 3](https://i.imgur.com/gHqdEqb.png)

現在跟之前一樣下載新的設定檔，然後用新的設定檔&#8203;**取代**&#8203;舊的。 當然，您也可以先刪除舊的設定檔，然後再放置新的。

完成並重新啟動ASF後，您將會看到ASF在原先顯示遊戲的位置顯示您的自訂文字：

![Steam 2](https://i.imgur.com/vZg0G8P.png)

這證明了您已成功修改您的設定。 您也可以使用相同的方式來修改ASF全域屬性，切換至「ASF」分頁，下載生成出來的&#8203;`ASF.json`&#8203;設定檔，並放到&#8203;`config`&#8203;資料夾中。

使用我們的ASF-ui前端，可以更輕鬆地編輯您的ASF設定，我們在接下來會有更深入的說明。

---

#### 使用 ASF-ui

ASF是一個沒有圖形使用者介面的控制台應用程式。 但是，我們也積極開發使用IPC介面的&#8203;**[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-zh-TW#ASF-ui)**&#8203;前端，它能夠存取各種ASF功能，是個非常方便的使用者友好方式。

要使用ASF-ui，您需要啟用&#8203;`IPC`&#8203;，它在ASF V5.1.0.0版本開始已預設成啟用。 啟動ASF之後，您應該能夠看到它自動成功開啟IPC介面的訊息：

![IPC](https://i.imgur.com/ZmkO8pk.png)

只要ASF在執行中，您就可以在同一台設備上透過&#8203;**[這個連結](http://localhost:1242)**&#8203;來存取ASF的IPC介面。 您可以使用ASF-ui來進行各種操作，例如直接編輯設定檔，或是傳送&#8203;**[指令](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-zh-TW)**&#8203;。 您可以隨意瀏覽它，來發現ASF-ui的全部功能。

![ASF-ui](https://raw.githubusercontent.com/JustArchiNET/ASF-ui/main/.github/previews/bots.png)

---

### 總結

您已成功設定了ASF，讓它使用您的Steam帳號，並依據您的喜好進行了客製化。 若您按照我們的整個指南進行操作，那麼您應已成功透過ASF-ui介面來調整ASF，並發現ASF實際上也具有某種GUI。 您現在可以閱讀完整的&#8203;**[組態設定](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-zh-TW)**&#8203;章節，來了解您之前看到的不同選項有何用途，以及ASF都有哪些功能。 如果您遇到問題或有疑問，請閱讀我們的&#8203;**[常見問題](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ-zh-TW)**&#8203;，它應該涵蓋了所有，或至少絕大多數您可能會遇到的問題。 如果您想了解關於ASF的一切資訊，及它如何讓您的掛卡事半功倍，請閱讀&#8203;**[ASF Wiki](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Home-zh-TW)**&#8203;的剩餘部分。 若您認為我們的程式很有用，並且您願意慷慨解囊，您也可以考慮捐款幫助我們的專案。 無論如何，祝您使用愉快！

---

## 安裝 Generic 版本套件

這部分是為想要安裝ASF &#8203;**[Generic](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility-zh-TW#Generic)**&#8203;變體版本的進階使用者所準備的。 雖然比起&#8203;**[適用於特定作業系統的版本](#適用於您的作業系統的設定)**&#8203;使用起來更加麻煩，但這也讓它擁有了其他的優點。

您可能會在這些情形下選擇使用&#8203;`Generic`&#8203;變體版本（當然也可以沒有任何原因）：
- 當套件的組建版本沒有能適用於您的作業系統時（例如32位元Windows）
- 當您已安裝.NET執行環境／SDK，或打算安裝時
- 當您想自行管理執行環境需求，來最小化ASF的結構大小及記憶體使用量時
- 當您想要使用自訂&#8203;**[外掛程式](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins-zh-TW)**&#8203;，且它需要Generic版本的ASF才能正常運作時（因為缺少原生相依套件）

但是，請注意，在這種情形下您需要自行負責.NET執行環境。 這代表如果您的.NET SDK（執行環境）無法使用、過舊或損毀，ASF就會無法運作。 這就是為什麼我們不建議普通使用者使用這個版本的原因，因為現在您需要確保您的.NET SDK（執行環境）與ASF的要求相符，並能執行ASF，而不是使用&#8203;**我們**&#8203;驗證過的ASF自帶的.NET執行環境。

對於&#8203;`Generic`&#8203;套件，您需要參考上述適用於您的作業系統的安裝指南，但有兩處微小的差別。 除了安裝.NET需求套件外，您還需要安裝.NET SDK，且&#8203;`ArchiSteamFarm.dll`&#8203;二進制檔案會取代適用於您的作業系統的&#8203;`ArchiSteamFarm(.exe)`&#8203;執行檔。 而其他步驟都是完全相同的。

增加了額外步驟之後：
- 安裝&#8203;**[.NET需求套件](#net-需求套件)**&#8203;。
- 安裝適合您的作業系統的&#8203;**[.NET SDK](https://www.microsoft.com/net/download)**&#8203;（或至少安裝ASP.NET Core執行環境）。 大部分情形下您會需要一個安裝程式。 如果您不知道要安裝.NET Core的哪一個版本，請參閱&#8203;**[執行環境需求](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility-zh-TW#執行環境需求)**&#8203;。
- 在&#8203;**[ASF發布頁面](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)**&#8203;下載&#8203;`Generic`&#8203;版本變體。
- 將壓縮檔解壓縮至一個新資料夾中。
- **[設定ASF](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-zh-TW)**&#8203;。
- 透過輔助腳本或是手動在Shell中執行&#8203;`dotnet /路徑/至/ArchiSteamFarm.dll`&#8203;指令來啟動ASF。

輔助腳本（例如用於Windows的&#8203;`ArchiSteamFarm.cmd`&#8203;及用於Linux/macOS的&#8203;`ArchiSteamFarm.sh`&#8203;）與&#8203;`ArchiSteamFarm.dll`&#8203;二進制檔案都是&#8203;`Generic`&#8203;變體版本獨有的。 若您不想手動執行&#8203;`dotnet`&#8203;指令，您可以使用輔助腳本。 當然，如果您沒有安裝.NET SDK，或您的&#8203;`PATH`&#8203;中沒有可用的&#8203;`dotnet`&#8203;執行檔，則輔助腳本會無法運作。 輔助腳本並不是必要的，您一直都能透過手動執行&#8203;`dotnet /路徑/至/ArchiSteamFarm.dll`&#8203;指令來開啟ASF。