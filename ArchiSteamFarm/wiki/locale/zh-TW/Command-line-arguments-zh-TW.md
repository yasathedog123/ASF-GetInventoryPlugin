# 命令列引數

ASF支援一些能夠影響程式執行的命令列引數。 進階使用者可以使用這些引數，來定義程式的執行方式。 相較於使用&#8203;`ASF.json`&#8203;設定檔的預設方式，命令列引數可用於核心初始化（例如&#8203;`--path`&#8203;）、平台特定設定（例如&#8203;`--system-required`&#8203;）或敏感性資料（例如&#8203;`--cryptkey`&#8203;）。

---

## 使用方法

使用方法取決於您的作業系統以及ASF的版本。

Generic版本：

```shell
dotnet ArchiSteamFarm.dll --引數 --另一個引數
```

Windows：

```powershell
.\ArchiSteamFarm.exe --引數 --另一個引數
```

Linux/macOS：

```shell
./ArchiSteamFarm --引數 --另一個引數
```

命令列引數也可用於通用輔助腳本中，例如&#8203;`ArchiSteamFarm.cmd`&#8203;或&#8203;`ArchiSteamFarm.sh`&#8203;。 除此之外，如我們的&#8203;**[管理](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management-zh-TW#環境變數)**&#8203;及&#8203;**[Docker](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Docker-zh-TW#命令列引數)**&#8203;章節中所述，您也可使用&#8203;`ASF_ARGS`&#8203;環境屬性。

若您的引數中存在空格，別忘了使用引號將其括住。 兩個錯誤的範例：

```shell
./ArchiSteamFarm --path /home/archi/My Downloads/ASF # 這是錯的！
./ArchiSteamFarm --path=/home/archi/My Downloads/ASF # 這是錯的！
```

下面兩個才是正確的：

```shell
./ArchiSteamFarm --path "/home/archi/My Downloads/ASF" # 這樣才正確
./ArchiSteamFarm "--path=/home/archi/My Downloads/ASF" # 這樣才正確
```

## 引數

`--cryptkey<key>`&#8203;或&#8203;`--cryptkey=<key>`&#8203;⸺將以自訂金鑰&#8203;`<key>`&#8203;啟動ASF。 此選項將會影響&#8203;**[安全性](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security-zh-TW)**&#8203;，並使ASF使用您的自訂金鑰&#8203;`<key>`&#8203;，而不是程式中硬編碼的預設值。 因為此屬性會影響預設加密鍵（用於加密）及&#8203;**[鹽](https://zh.wikipedia.org/zh-tw/%E7%9B%90_(%E5%AF%86%E7%A0%81%E5%AD%A6))**&#8203;（用於雜湊），請注意使用此金鑰加密／雜湊出的一切，ASF在每次執行時都需要給入相同的值。

`<key>`&#8203;不要求長度或字元，但出於安全原因，我們建議選擇足夠長的通行片語，例如隨機的32個字元，在Linux上使用&#8203;`tr -dc A-Za-z0-9 < /dev/urandom | head -c 32; echo`&#8203;命令可以獲得。

需要再提一點，還有另外兩種方法可以提供此詳細資料：&#8203;`--cryptkey-file`&#8203;與&#8203;`--input-cryptkey`&#8203;。

由於此屬性的性質，它還能透過宣告&#8203;`ASF_CRYPTKEY`&#8203;環境變數來設定cryptkey，這更適合希望在程序引數中，不包含敏感資訊的使用者。

---

`--cryptkey-file<path>`&#8203;或&#8203;`--cryptkey-file=<path>`&#8203;⸺將使用從&#8203;`<path>`&#8203;檔案中讀取的自訂加密金鑰&#8203;`<path>`&#8203;啟動ASF。 這與上述說明的&#8203;`--cryptkey<key>`&#8203;的目的相同。但機制不同，因為此屬性是從&#8203;`<path>`&#8203;讀取&#8203;`<key>`&#8203;。 若您將本引數與&#8203;`--path`&#8203;一同使用，請先宣告&#8203;`--path`&#8203;以使相對路徑能夠正常運作。

由於此屬性的性質，它還能透過宣告&#8203;`ASF_CRYPTKEY_FILE`&#8203;環境變數來設定cryptkey檔案，這更適合希望在程序引數中，不包含敏感資訊的使用者。

---

`--ignore-unsupported-environment`&#8203;⸺使ASF忽略在不支援環境中執行的各種問題。而在原本的情形下，會顯示程式出錯並強制退出。 不支援包含例如在&#8203;`linux-x64`&#8203;上執行適用於&#8203;`win-x64`&#8203;版本的組建等的情形。 雖然此旗標使ASF能夠嘗試在這些情境中執行，但請注意，我們不正式支援此行為。若您強制ASF這樣做，&#8203;**後果自負**&#8203;。 請格外注意，&#8203;**所有**&#8203;不受支援的環境&#8203;**皆能被修正**&#8203;。 我們強烈建議從根本上修正問題，而非去使用這個引數。

---

`--input-cryptkey`&#8203;⸺使ASF在啟動過程詢問&#8203;`--cryptkey`&#8203;。 若您不希望在任何地方儲存cryptkey，例如環境變數或檔案中，而要在每次ASF執行時手動輸入，則可以使用此選項。

---

`--minimized`&#8203;⸺使ASF在啟動後立刻最小化控制台視窗。 主要是在自動啟動的情境中非常好用，但仍可用於其他地方。 此開關目前只在Windows設備中有效。

---

`--network-group <group>`&#8203;或&#8203;`--network-group=<group>`&#8203;⸺使ASF使用&#8203;`<group>`&#8203;值的自訂網路群組來初始化其限制器。 這個選項會影響執行&#8203;**[多個實例](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management-zh-TW#多個實例)**&#8203;的ASF，使用此選項指定的實例只會與相同網路群組的實例相互分享資訊，而與其他實例獨立。 這個選項會影響執行&#8203;**[多個實例](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management-zh-TW#多個實例)**&#8203;的ASF，使用此選項指定的實例只會與相同網路群組的實例相互分享資訊，而與其他實例獨立。 請注意，在使用自訂網路群組時，這是本機電腦中的唯一識別碼，ASF將不考慮任何其他細節。例如&#8203;`WebProxy`&#8203;的值，您可以使用不同的&#8203;`WebProxy`&#8203;值來執行兩個實例，但它們仍會互相影響。

由於此屬性的性質，它還能透過宣告&#8203;`ASF_NETWORK_GROUP`&#8203;環境變數來設定其值，這更適合希望在程序引數中，不包含敏感資訊的使用者。

---

`--no-config-migrate`&#8203;⸺在預設情形下，ASF會自動將您的設定檔遷移成最新的語法。 遷移包含：將廢止的屬性轉換成最新的屬性，刪除值為預設的屬性（因為它們沒有意義），以及清理檔案內容（修正縮排等）。 這通常是個好方法，但您可能會遇到特殊情形，以至於希望ASF不會去自動覆蓋設定檔。 舉例來說，您可能想要對設定檔&#8203;`chmod 400`&#8203;（僅擁有者可讀取），或使用&#8203;`chattr +i`&#8203;禁止任何人寫入，來作為安全措施。 一般而言，我們建議保留啟用設定遷移，但如果您有特定的理由停用它，並希望ASF不遷移設定，您可以使用此開關來達成。 但請注意，為ASF提供正確的設定，現在已成為了您自己的新責任，特別是有關未來版本的功能棄用及重構。

---

`--no-config-watch`&#8203;⸺在預設情形下，ASF會在您的&#8203;`config`&#8203;資料夾中設定&#8203;`FileSystemWatcher`&#8203;，以監聽更動檔案的事件 ，因此才能夠動態適應這些改動。 舉例來說，在刪除設定檔後停止Bot，修改設定後重新啟動Bot，或在您將序號加入至config資料夾後，載入至&#8203;**[背景序號啟動器](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer-zh-TW)**&#8203;中。 這個開關允許您停用這個行為，使ASF完全忽略&#8203;`config`&#8203;資料夾中的任何更改，您需要在適合的時機手動執行相關操作（通常是重新啟動程序）。 我們建議保持啟用config事件監聽，但如果您有特殊原因停用它，並希望ASF不這樣做，就可以使用此開關來達成。

---

`--no-restart`&#8203;⸺這個開關主要由&#8203;**[Docker](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Docker-zh-TW)**&#8203;容器所使用，它會強制將&#8203;`AutoRestart`&#8203;設定成&#8203;`false`&#8203;。 除非您有特殊需求，否則您應該直接在設定中設定&#8203;`AutoRestart`&#8203;屬性。 這個開關使Docker腳本不需要修改您的全域設定，來適應它的環境。 當然，如果是在腳本中執行ASF，您也可以使用此開關（否則您最好使用全域設定屬性）。

---

`--no-steam-parental-generation`&#8203;⸺在預設情形下，ASF會自動嘗試生成Steam家長監護PIN碼，如&#8203;**[`SteamParentalCode`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-zh-TW#steamparentalcode家庭監護-pin-碼)**&#8203;設定屬性中所述。 但由於這可能需要過多的作業系統資源，因此這個開關使您能夠停用此行為，這將使ASF跳過自動生成，並直接向使用者詢問PIN碼，與一般情形下的自動生成失敗時相同。 一般而言，我們建議保留啟用生成，除非您有特定的理由停用它，並希望ASF不生成代碼，您可以使用此開關來達成。

---

`--path <path>`&#8203;或&#8203;`--path=<path>`&#8203;⸺在預設情形下，ASF總是會在啟動後，使用程式本身所在的資料夾。 透過指定此引數，ASF會在初始化後使用指定的資料夾，讓您能為不同的設定（包含&#8203;`config`&#8203;、&#8203;`logs`&#8203;、&#8203;`plugins`&#8203;及&#8203;`www`&#8203;資料夾，與&#8203;`NLog.config`&#8203;檔案）使用不同的應用程式檔案，而不用複製ASF至不同檔案的資料夾中。 若您想將二進制檔案和實際使用的設定檔分開，這可能會非常有用。就像是Linux的封裝機制一樣：這樣您就可以在多個設定檔間，共用一個（最新的）二進制檔案。 這個路徑既可以是依據ASF二進制檔案所在位置的相對路徑，亦可以是絕對路徑。 請注意，這個指令會指向新的「ASF主資料夾」：與原本的ASF具有相同的資料夾結構，其中包含&#8203;`config`&#8203;資料夾，請參閱下面的說明範例。

由於此屬性的性質，它還能透過宣告&#8203;`ASF_PATH`&#8203;環境變數來設定路徑，這更適合希望在程序引數中，不包含敏感資訊的使用者。

如果您考慮使用此命令列引數來執行多個ASF實例，我們建議您閱讀我們的&#8203;**[相容性頁面](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management-zh-TW#多個實例)**&#8203;。

範例：

```shell
dotnet /opt/ASF/ArchiSteamFarm.dll --path /opt/TargetDirectory # 使用絕對路徑
dotnet /opt/ASF/ArchiSteamFarm.dll --path ../TargetDirectory # 或使用相對路徑
ASF_PATH=/opt/TargetDirectory dotnet /opt/ASF/ArchiSteamFarm.dll # 或使用環境變數
```

```text
├── /opt
│     ├── ASF
│     │     ├── ArchiSteamFarm.dll
│     │     └── ...
│     └── TargetDirectory
│           ├── config
│           ├── logs（自動產生）
│           ├── plugins（選擇性）
│           ├── www（選擇性）
│           ├── log.txt（自動產生）
│           └── NLog.config（選擇性）
└── ...
```

---

`--process-required`&#8203;⸺在預設情形下，ASF會在沒有Bot執行時關閉，使用這個開關會停用此行為。 這項功能與&#8203;**[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-zh-TW)**&#8203;一起使用時特別有用，大多數使用者都會希望他們的Web服務不管在多少個Bot啟用時，都能夠正常執行。 若您正在使用IPC，或需要ASF程序一直執行到您手動關閉它，那麼您就該使用此選項。

若您沒有打算執行IPC，則這個選項對您來說沒有用處，因為您可以在需要時重新啟動程序（與始終監聽來傳送指令的ASF Web伺服器相反）。

---

`--service`&#8203;⸺這個開關主要由&#8203;`systemd`&#8203;服務所使用，它會強制將&#8203;`Headless`&#8203;設定成&#8203;`true`&#8203;。 除非您有特殊需求，否則您應該直接在設定中設定&#8203;`Headless`&#8203;屬性。 這個開關使&#8203;`systemd`&#8203;服務不需要修改您的全域設定，來適應它的環境。 當然，如果您有類似需求，您也可以使用此開關（否則您最好使用全域設定屬性）。

---

`--system-required`&#8203;⸺使用這個開關，將使ASF嘗試通知作業系統，表明本程序需要在系統執行期間，保持啟動與正常執行狀態。 目前這個開關只對Windows設備有效，只要程序正在執行，它就會阻止您的系統進入睡眠模式。 當您在夜間使用桌機或筆電掛卡時，這個功能是相當實用的，因為ASF將會在掛卡期間讓您的系統保持喚醒狀態。一旦ASF完成掛卡，它會像平常一樣自動關閉，使您的系統可以再次進入睡眠模式，以此節省電力消耗。

請注意，要正確地使ASF自動關閉，您還需要其他設定：特別是避免使用&#8203;`--process-required`&#8203;，並確保您的所有Bot都在&#8203;`FarmingPreferences`&#8203;中設定了&#8203;`ShutdownOnFarmingFinished`&#8203;。 當然，自動關閉只是這個功能的其中一種用法，因為您還可以配合&#8203;`--process-required`&#8203;使用，讓您的系統在ASF啟動之後永遠地保持喚醒狀態。