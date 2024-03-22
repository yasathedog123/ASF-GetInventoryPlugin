# 管理

本章節涵蓋的相關主題是以最佳方式管理ASF程序。 雖然這並不是強制性的，但它包含了我們想分享的大量提示、技巧與良好實作，特別是對於系統管理員、打包ASF以便於在第三方儲存庫中使用的人、與進階使用者等人而言。

---

## Linux 的 `systemd` 服務

在&#8203;`generic`&#8203;及`linux`&#8203;變體版本中，ASF自帶&#8203;`ArchiSteamFarm@.service`&#8203;檔案，這是&#8203;**[`systemd`](https://systemd.io)**&#8203;的服務設定檔。 若您想以服務來執行ASF，例如能在您的設備啟動時自動執行，那麼正確的&#8203;`systemd`&#8203;服務無疑是最好的方法，因此我們強烈建議經由服務，而不是使用&#8203;`nohup`&#8203;、&#8203;`screen`&#8203;或其他方式來管理。

首先，若您還尚未建立用來執行ASF的使用者，請先建立它。 我們在此以&#8203;`asf`&#8203;使用者作為範例，若您想使用其他的使用者，您就必須將下列範例中的&#8203;`asf`&#8203;使用者取代成您想使用的使用者名稱。 我們的服務不允許您使用&#8203;`root`&#8203;來執行ASF，因為這被認為是&#8203;**[糟糕的方法](#永遠不要以系統管理員身分執行-asf)**&#8203;。

```sh
su # 或是 sudo -i，用來進入 Root Shell
useradd -m asf # 建立您用來執行 ASF 的使用者
```

下一步，將ASF解壓縮至&#8203;`/home/asf/ArchiSteamFarm`&#8203;資料夾中。 資料夾的結構對我們的服務單元來說非常重要，它應在您的&#8203;`$HOME`&#8203;裡面，也就是說&#8203;`ArchiSteamFarm`&#8203;資料夾需要放在&#8203;`/home/<使用者名稱>`&#8203;中。 若您的操作完全正確，則現在應存在&#8203;`/home/asf/ArchiSteamFarm/ArchiSteamFarm@.service`&#8203;檔案。 若您使用&#8203;`linux`變體版本，且檔案不在Linux中解壓縮，而是例如從Windows傳輸過來，那麼您需額外執行&#8203;`chmod +x /home/asf/ArchiSteamFarm/ArchiSteamFarm`&#8203;。

我們將使用&#8203;`root`&#8203;的身分執行下列操作，所以需使用&#8203;`su`&#8203;或&#8203;`sudo -i`&#8203;以獲得Shell。

我們最好先確認資料夾仍屬於&#8203;`asf`&#8203;使用者，執行一次&#8203;`chown -hR asf:asf /home/asf/ArchiSteamFarm`&#8203;即可。 因為如果您使用&#8203;`root`&#8203;來下載並／或解壓縮.zip檔，權限很可能會不正確。

其次，若您使用的是ASF的Generic變體版本，您需要確保&#8203;`dotnet`&#8203;命令能被辨識，且位於標準位置之一：&#8203;`/usr/local/bin`&#8203;、&#8203;`/usr/bin`&#8203;或&#8203;`/bin`&#8203;。 這是執行&#8203;`dotnet /路徑/至/ArchiSteamFarm.dll`&#8203;命令的systemd服務所必需的。 檢查&#8203;`dotnet --info`&#8203;是否運作，若是，輸入&#8203;`command -v dotnet`&#8203;以找出它的所在位置。 若您使用官方安裝程式，它應位於&#8203;`/usr/bin/dotnet`&#8203;或其餘兩個位置之一，這樣是沒問題的。 若它位於自訂位置，例如&#8203;`/usr/share/dotnet/dotnet`&#8203;，使用&#8203;`ln -s "$(command -v dotnet)" /usr/bin/dotnet`&#8203;來建立一個&#8203;**[符號連結](https://zh.wikipedia.org/zh-tw/%E7%AC%A6%E5%8F%B7%E9%93%BE%E6%8E%A5)**&#8203;。 現在&#8203;`command -v dotnet`&#8203;應該會回報&#8203;`/usr/bin/dotnet`&#8203;，而這也使我們的systemd單元運作。 若您使用適用於特定作業系統的變體版本，則不需在這方面做任何事情。

然後，執行&#8203;`ln -s /home/asf/ArchiSteamFarm/ArchiSteamFarm\@.service /etc/systemd/system/ArchiSteamFarm\@.service`&#8203;，這會建立符號連結至我們的服務宣告，並在&#8203;`systemd`&#8203;中登錄它。 符號連結可以使ASF在更新時，自動更新您的&#8203;`systemd`&#8203;單元⸺依據您的情形，您可能想要使用上述方式，或使用&#8203;`cp`&#8203;複製檔案並自行管理。

然後，確保&#8203;`systemd`&#8203;能夠辨識我們的服務：

```
systemctl status ArchiSteamFarm@asf

○ ArchiSteamFarm@asf.service - ArchiSteamFarm Service (on asf)
     Loaded: loaded (/etc/systemd/system/ArchiSteamFarm@.service; disabled; vendor preset: enabled)
     Active: inactive (dead)
       Docs: https://github.com/JustArchiNET/ArchiSteamFarm/wiki
```

請特別注意我們在&#8203;`@`&#8203;後宣告的使用者，在範例中是&#8203;`asf`&#8203;。 我們的systemd服務單元要求您宣告使用者，因為這會影響&#8203;`/home/<使用者名稱>/ArchiSteamFarm`&#8203;二進制檔案的實際位置，以及systemd生成的程序實際使用者。

若systemd回傳的輸出與上述相似，則一切正常，我們就快完成了。 現在，剩下的步驟就是以我們選擇的使用者實際啟動服務：&#8203;`systemctl start ArchiSteamFarm@asf`&#8203;。 稍待片刻，您就可以再次檢查狀態：

```
systemctl status ArchiSteamFarm@asf

● ArchiSteamFarm@asf.service - ArchiSteamFarm Service (on asf)
     Loaded: loaded (/etc/systemd/system/ArchiSteamFarm@.service; disabled; vendor preset: enabled)
     Active: active (running) since (...)
       Docs: https://github.com/JustArchiNET/ArchiSteamFarm/wiki
   Main PID: (...)
(...)
```

若&#8203;`systemd`&#8203;的狀態為&#8203;`active (running)`&#8203;，代表一切正常。您可以透過例如&#8203;`journalctl -r`&#8203;來驗證ASF程序已啟動並在執行中，因為ASF預設輸出至控制台，會被&#8203;`systemd`&#8203;所記錄。 若您滿意現在的設定，就能執行&#8203;`systemctl enable ArchiSteamFarm@asf`&#8203;命令，告訴&#8203;`systemd`&#8203;在啟動期間自動啟動您的服務。 這樣就完成了。

若您想停止程序，只需執行&#8203;`systemctl stop ArchiSteamFarm@asf`&#8203;。 同樣地，若您想要停用ASF自啟動，就執行&#8203;`systemctl disable ArchiSteamFarm@asf`&#8203;，非常簡單。

請注意，由於我們的&#8203;`systemd`&#8203;服務沒有啟用標準輸入，故您無法使用一般經由控制台的方式輸入資訊。 透過&#8203;`systemd`執行，等同於指定&#8203;**[`Headless: true`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-zh-TW#headless無頭模式)**&#8203;設定。 若您需要在登入期間提供額外資訊，或更好地管理您的ASF程序，幸運的是，我們能夠建議您使用&#8203;**[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)**&#8203;，可以輕鬆管理您的ASF。

### 環境變數

可以為我們的&#8203;`systemd`&#8203;服務提供額外的環境變數，例如您想要使用自訂的&#8203;`--cryptkey`&#8203;**[命令列引數](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments-zh-TW#引數)**&#8203;，就要指定&#8203;`ASF_CRYPTKEY`&#8203;環境變數。

若要提供自訂環境變數，使用&#8203;`mkdir -p /etc/asf`&#8203;來建立&#8203;`/etc/asf`資料夾（如果不存在）。 我們建議使用&#8203;`chown -hR root:root /etc/asf && chmod 700 /etc/asf`&#8203;，來確保只有&#8203;`root`&#8203;使用者能夠存取這些檔案，因為它們可能含有機密屬性，例如&#8203;`ASF_CRYPTKEY`&#8203;。 然後，編輯&#8203;`/etc/asf/<使用者名稱>`&#8203;檔案，其中&#8203;`<使用者名稱>`&#8203;代表您要執行服務的使用者（在上述範例中是&#8203;`asf`&#8203;，因此是&#8203;`/etc/asf/asf`&#8203;）。

這個檔案應該含有所有您要提供給程序的環境變數。 對於那些沒有專屬環境變數的，可以在&#8203;`ASF_ARGS`&#8203;中宣告：

```sh
# 只宣告您實際所需的變數
ASF_ARGS="--no-config-migrate --no-config-watch"
ASF_CRYPTKEY="my_super_important_secret_cryptkey"
ASF_NETWORK_GROUP="my_network_group"

# 及其他任何您想要使用的變數
```

### 複寫部分服務單元

由於&#8203;`systemd`&#8203;的靈活性，我們可以複寫部分的ASF單元，同時仍然保留原始單元檔案，並允許ASF對其進行更新，例如作為自動更新的一部分。

在本範例中，我們要修改ASF預設的&#8203;`systemd`&#8203;單元的行為，從只在成功退出時重新啟動，改成在致命崩潰時也重新啟動。 為此，我們將會複寫&#8203;`[Service]`&#8203;下的&#8203;`Restart`&#8203;屬性，從預設的&#8203;`on-success`&#8203;改成&#8203;`always`&#8203;。 只需執行&#8203;`systemctl edit ArchiSteamFarm@asf`&#8203;，將&#8203;`asf`&#8203;取代成您服務實際使用的目標使用者即可。 然後依&#8203;`systemd`&#8203;中的指示，在正確的段落中加入您的改動：

```sh
### 編輯 /etc/systemd/system/ArchiSteamFarm@asf.service.d/override.conf
### 本處至下方註解間的所有內容，都會加入至檔案中

[Service]
Restart=always

### 本條註解下方的內容將被捨棄

### /etc/systemd/system/ArchiSteamFarm@asf.service
# [Install]
# WantedBy=multi-user.target
# 
# [Service]
# EnvironmentFile=-/etc/asf/%i
# ExecStart=dotnet /home/%i/ArchiSteamFarm/ArchiSteamFarm.dll --no-restart --process-required --service --system-required
# Restart=on-success
# RestartSec=1s
# SyslogIdentifier=asf-%i
# User=%i
# (...)
```

這樣就完成了，現在您單元的行為就等同於&#8203;`[Service]`&#8203;下只有&#8203;`Restart=always`&#8203;。

當然，另一種方式是&#8203;`cp`&#8203;檔案並自行管理，但上述方式允許您進行靈活的改動，不論您決定保留原始ASF單元，例如使用&#8203;**[符號連結](https://zh.wikipedia.org/zh-tw/%E7%AC%A6%E5%8F%B7%E9%93%BE%E6%8E%A5)**&#8203;。

---

## 永遠不要以系統管理員身分執行 ASF！

ASF含有邏輯以驗證自身是否以系統管理員（&#8203;`root`&#8203;）身分執行。 若環境設定正確，ASF程序的任何操作都&#8203;**不需要**&#8203;執行於&#8203;`root`&#8203;，因此使用Root執行都被視為&#8203;**糟糕的方法**&#8203;。 這代表在Windows上，ASF&#8203;**永遠都不**&#8203;應該使用「以系統管理員身分執行」設定來執行；而在Unix上，ASF應要擁有&#8203;**專用的使用者帳號**&#8203;，或在桌面環境中使用您自己的帳號。

若要了解&#8203;*為什麼*&#8203;我們不鼓勵以&#8203;`root`&#8203;執行ASF，請參閱&#8203;**[Superuser](https://superuser.com/questions/218379/why-is-it-bad-to-run-as-root)**&#8203;及其他資料。 若您仍不信邪，請自行想像，如果ASF程序在啟動後立刻執行&#8203;`rm -rf /*`&#8203;命令，您的設備會怎樣。

### 我使用 `root` 執行，因為 ASF 無法寫入它自己的檔案

這代表您錯誤設定了ASF試圖存取的檔案的權限。 您應使用&#8203;`root`&#8203;帳號（使用&#8203;`su`&#8203;或&#8203;`sudo -i`），然後執行&#8203;`chown -hR asf:asf /路徑/至/ASF`&#8203;命令來&#8203;**更正**&#8203;權限。其中，您需將&#8203;`asf:asf`&#8203;取代成實際執行ASF的使用者，&#8203;`/路徑/至/ASF`&#8203;取代成ASF的實際路徑。 若您使用自訂&#8203;`--path`&#8203;，讓ASF使用者使用不同的資料夾，您還需為此路徑執行一次上述命令。

完成本操作後，您應該不會再遇到任何與ASF無法寫入自己的檔案類似的問題，因為您剛才已將ASF所需檔案的擁有者改成實際執行ASF的使用者了。

### 我使用 `root` 執行，因為我不知道該怎麼做

```sh
su # 或是 sudo -i，用來進入 Root Shell
useradd -m asf # 建立您用來執行 ASF 的使用者
chown -hR asf:asf /path/to/ASF # 確保您的新使用者擁有存取 ASF 資料夾的權限
su asf -c /path/to/ASF/ArchiSteamFarm # 或是 sudo -u asf /path/to/ASF/ArchiSteamFarm，在您的使用者下實際啟動程式
```

這些是手動啟動，但使用我們上述說明的&#8203;**[`systemd`&#8203;服務](#linux-的-systemd-服務)**&#8203;會更加輕鬆。

### 我十分清楚，且依然想要使用 `root` 執行

ASF不會阻止您這樣做，而是只顯示一條警告短訊。 但如果有一天由於程式錯誤，使它炸毀了您的整個作業系統，並導致資料完全遺失，那就不要感到驚訝⸺您已被警告過了。

---

## 多個實例

ASF相容於在同一台設備上執行多個程序實例。 實例可以完全獨立，或從同一個二進制檔案衍生（若您需以不同&#8203;`--path`&#8203;執行，可以使用&#8203;**[命令列引數](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments-zh-TW)**&#8203;）。

在使用同一個二進制檔案執行多個實例時，請注意，您應該在所有設定裡面停用自動更新，因為它們並沒有同步自動更新相關的資訊。 若您想繼續啟用自動更新，我們建議您使用獨立的實例。但只要您能確保其他所有ASF實例皆已關閉，自動更新仍能正常運作。

ASF會盡量減少與其他ASF實例產生作業系統層面的跨程序通訊。 這包含ASF檢查其他實例的組態設定資料夾，及共用&#8203;`*LimiterDelay`&#8203;**[全域設定屬性](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-zh-TW#全域設定檔)**&#8203;，來確保執行多個ASF實例不會造成速率限制的問題。 在技術方面，所有平台皆使用我們專屬的ASF自訂機制，在臨時資料夾中建立基於檔案的鎖，在Windows上為&#8203;`C:\Users\<您的使用者名稱>\AppData\Local\Temp\ASF`&#8203;，而在Unix上為&#8203;`/tmp/ASF`&#8203;。

執行ASF實例不需要共用相同的&#8203;`*LimiterDelay`&#8203;屬性，它們可為不同值，因為每個ASF會在獲得鎖後，將自身的設定延遲加入至釋放時間中。 若設定中的&#8203;`*LimiterDelay`&#8203;設定成&#8203;`0`&#8203;，ASF實例會完全跳過等待其他實例釋放共用資源的鎖（但仍可能會保有一個共用鎖）。 當設定成其他任意值時，ASF會與其他ASF實例同步並等候輪到自身，然後在達到延遲設定後釋放鎖，使其他實例能夠繼續運作。

ASF在決定共用範圍時會考慮&#8203;`WebProxy`&#8203;設定，這代表使用不同&#8203;`WebProxy`&#8203;設定的兩個ASF實例，不會互相共用它們的限制器。 這是為了使&#8203;`WebProxy`&#8203;設定可以在沒有過多延遲的情形下運作，就像使用不同網路介面所期望的那樣。 對於大多數情形來說這就應該夠了，但是，若您有特殊的自訂設定，例如經由其他方式的路由請求，您可以使用&#8203;`--network-group`&#8203;**[命令列引數](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments-zh-TW)**&#8203;指定網路群組，使您能夠宣告要與此實例同步的ASF群組。 請注意，自訂網路群組是專用的，也就是說ASF不再依據&#8203;`WebProxy`&#8203;來判斷群組，因為此時已經是由您自己所管理。

若您想使用我們上述的&#8203;**[`systemd`&#8203;服務](#linux-的-systemd-服務)**&#8203;使用多個實例，這也非常簡單，只需在服務聲明&#8203;`ArchiSteamFarm@`&#8203;裡面使用另外一個使用者，然後再次進行其餘步驟即可。 這等同於使用不同的二進制檔案執行多個ASF實例，因此它們也能夠自動更新，並彼此獨立運作。