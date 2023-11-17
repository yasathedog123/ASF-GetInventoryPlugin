# Docker

從3.0.3.2版本開始，ASF現在也可用於&#8203;**[Docker容器](https://www.docker.com/what-container)**&#8203;中。 我們的Docker倉庫同時部署於&#8203;**[ghcr.io](https://github.com/orgs/JustArchiNET/packages/container/archisteamfarm/versions)**&#8203;及&#8203;**[Docker Hub](https://hub.docker.com/r/justarchi/archisteamfarm)**&#8203;。

特別注意，在Docker容器中執行ASF被視為一種&#8203;**進階設定**&#8203;，對於絕大多數使用者來說是&#8203;**不需要的**&#8203;，且通常與非容器設定相比&#8203;**並無優勢**&#8203;。 若您考慮將Docker作為把ASF當作服務執行的一種解決方案，例如使它隨著您的作業系統自動啟動，那麼您應考慮閱讀&#8203;**[管理](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management-zh-TW#linux-的-systemd-服務)**&#8203;章節，並適當設定&#8203;`systemd`&#8203;服務，這&#8203;**幾乎總比**&#8203;在Docker容器中執行ASF還要更好。

在Docker容器中執行ASF通常會涉及&#8203;**一些新問題及狀況**&#8203;，您必須自行面對並解決這些問題。 這就是為什麼我們&#8203;**強烈**&#8203;建議您避免使用Docker，除非您已經具備相關知識，且不需要其他人幫助您了解其內部結構。此外，我們也不會在ASF Wiki詳細說明這些。 本章節主要提供了非常複雜設定的有效使用範例，例如關於進階網路的設定，或安全性超過ASF在&#8203;`systemd`&#8203;服務中所附帶的標準沙盒（它已經透過非常先進的安全機制來確保卓越的程序隔離）。 對於那些少數人，在這裡我們著重解釋了關於ASF與Docker相容性的概念，僅此而已。若您決定將ASF與Docker一起使用，我們會假定您已擁有足夠的Docker知識。

---

## 標籤

ASF有4種主要類型的&#8203;**[標籤](https://hub.docker.com/r/justarchi/archisteamfarm/tags)**&#8203;：


### `main`

本標籤始終指向在&#8203;`main`&#8203;分支中ASF所提交的最新組建版本，運作原理與直接從我們的&#8203;**[CI](https://github.com/JustArchiNET/ArchiSteamFarm/actions/workflows/publish.yml?query=branch%3Amain)**&#8203;管線中抓取最新產生的版本相同。 通常您應避免使用此標籤，因為它是以開發為目的，專為開發人員及進階使用者的軟體，含有大量的錯誤。 該映像檔會隨著GitHub的&#8203;`main`&#8203;分支每次提交而更新，因此您可以預期它會頻繁更新（且經常損壞）。 這是我們用來標示ASF專案的當前狀態，不一定能保證穩定或經過測試，就像在我們的發布週期中所說明的那樣。 此標籤不應在任何生產環境中使用。


### `released`

與上述標籤非常相似，本標籤始終指向ASF&#8203;**[最新發布](https://github.com/JustArchiNET/ArchiSteamFarm/releases)**&#8203;的版本，包含預覽版本。 與&#8203;`main`&#8203;標籤不同，此映像檔會在每次推播新的GitHub標籤時更新。 為喜歡冒險、敢於嘗試新事物但又可能考慮相對穩定的進階使用者所準備。 若您不想使用&#8203;`latest`&#8203;標籤，我們建議您使用此標籤。 實際上，它的運作方式與滾動標籤在拉取時指向最新&#8203;`A.B.C.D`&#8203;版本的方式相同。 請注意，使用此標籤與使用我們的&#8203;**[預覽版本](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Release-cycle-zh-TW)**&#8203;是相同的。


### `latest`

與其他標籤相比，只有本標籤包含了ASF的自動更新功能，且指向ASF最新的&#8203;**[穩定版本](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)**&#8203;。 此標籤的目的是提供一個預設的合理Docker容器，能執行適用於特定作業系統的ASF組建版本的自動更新。 因此，此映像檔不需要經常更新，因為所包含的ASF版本將會在需要時進行自動更新。 當然，可以安全關閉&#8203;`UpdatePeriod`&#8203;（設定成&#8203;`0`&#8203;），但在這種情形下，您可能更應使用固定的&#8203;`A.B.C.D`&#8203;版本。 同理，您也可以修改預設的&#8203;`UpdateChannel`&#8203;，以改為自動更新&#8203;`released`&#8203;標籤。

由於&#8203;`latest`&#8203;映像檔具有自動更新功能，它具有&#8203;`linux`&#8203;作業系統特定的裸作業系統ASF版本，與所有其他標籤相反，包含含有.NET作業系統執行環境及&#8203;`generic`&#8203;的ASF版本。 這是因為較新（更新後）的ASF版本可能會需要比映像檔內建還要新的執行環境，這將需要從頭開始重新組建映像檔，並使使用計畫無效。

### `A.B.C.D`

與上述的標籤相比，本標籤是固定的，這代表映像檔一經發布就不再會更新。 這個運作方式與我們GitHub發布版本相似，在最初的版本發布後就不會變動，這將保證您的環境穩定。 通常，當您想使用特定的ASF版本，且不想使用任何類型的自動更新（例如&#8203;`latest`&#8203;標籤所提供的）時，您就應該使用此標籤。

---

## 哪個標籤最適合我？

這取決於您的需求。 對於大多數使用者來說，&#8203;`latest`&#8203;標籤應該是最好的，因為它提供了桌面執行ASF時所有的一切，區別只是作為服務執行在特殊的Docker容器中。 而那些經常重新建立映像檔，或想要自己完全控制ASF版本的人來說，可能會更喜歡&#8203;`released`&#8203;標籤。 若您想要使用某個固定的ASF版本，或在您沒有打算時永遠不會變更版本，&#8203;`A.B.C.D`&#8203;版本可供您使用，作為ASF固定的里程碑，隨時都可以回溯至此。

一般來說我們不建議使用&#8203;`main`&#8203;組建版本，因為這只是用來標示ASF專案當前狀態的。 這種狀態無法保證能正常運作，但是如果您對ASF的開發感興趣，非常歡迎您去嘗試。

---

## 架構

ASF Docker映像檔目前建立於&#8203;`linux`&#8203;平台上，針對3種架構：&#8203;`x64`&#8203;、&#8203;`arm`&#8203;及&#8203;`arm64`&#8203;。 您可以在&#8203;**[相容性](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility-zh-TW)**&#8203;章節中，有著更深入的了解。

從ASF V5.0.2.2版本開始，我們的標籤使用多平台清單，這代表安裝在您設備上的Docker會在拉取時自動選擇適合的映像檔。 若您需要拉取不符合您當前執行平台的特定映像檔，您可以透過適當的Docker命令&#8203;`--platform`&#8203;來切換，例如&#8203;`docker run`&#8203;。 查看關於&#8203;**[映像檔清單](https://docs.docker.com/registry/spec/manifest-v2-2)**&#8203;的Docker文件來深入了解。

---

## 使用方法

若需完整資料，請使用&#8203;**[Docker官方文件](https://docs.docker.com/engine/reference/commandline/docker)**&#8203;，我們在本指南中只會介紹基礎用法，歡迎您去更深入的挖掘。

### 你好，ASF！

首先，我們應該驗證Docker是否運作正常，以這來作為我們ASF的「Hello World」：

```shell
docker run -it --name asf --pull always --rm justarchi/archisteamfarm
```

`docker run`&#8203;會為您建立一個新的ASF Docker容器，並在前景中執行（&#8203;`-it`&#8203;）。 `--pull always`&#8203;確保會最先拉取最新的映像檔，而&#8203;`--rm`&#8203;確保我們的容器在停止之後會被清除，因為我們現在只是測試一切是否運作正常。

若一切運作正常，在拉取所有層並啟動容器後，您應該會注意到ASF已正確啟動，並通知我們目前沒有定義任何Bot，這很好⸺我們驗證了ASF在Docker中運作正常。 先按&#8203;`CTRL+P`&#8203;，再按&#8203;`CTRL+Q`&#8203;來退出Docker容器前景，然後使用&#8203;`docker stop asf`&#8203;停止ASF容器。

若仔細查看該命令，您會注意到我們沒有宣告任何標籤，而它會自動預設成&#8203;`latest`&#8203;。 如果您想要使用與&#8203;`latest`&#8203;不同的標籤，例如&#8203;`released`&#8203;，那麼您應該顯性宣告：

```shell
docker run -it --name asf --pull always --rm justarchi/archisteamfarm:released
```

---

## 使用卷

若您在Docker容器中使用ASF，那麼很明顯您需要設定程式自身。 您可以透過不同方式做到，但建議是在本機電腦中建立&#8203;`config`&#8203;資料夾，然後在ASF Docker容器中掛載它作為共用卷。

舉例來說，我們假設您的ASF設定資料夾位於&#8203;`/home/archi/ASF/config`&#8203;資料夾中。 這個資料夾包含&#8203;`ASF.json`&#8203;核心與我們想要執行的Bot。 現在我們只需要將這個資料夾當作共用卷附加至Docker容器中，也就是ASF的設定資料夾（&#8203;`/app/config`&#8203;）。

```shell
docker run -it -v /home/archi/ASF/config:/app/config --name asf --pull always justarchi/archisteamfarm
```

就是這樣，現在您的ASF Docker容器將會以讀寫模式使用您本機電腦的共用資料夾，這是設定ASF的一切。 您可以使用相同的方式掛載您想要與ASF共用的其他卷，例如&#8203;`/app/logs`&#8203;或&#8203;`/app/plugins/MyCustomPluginDirectory`&#8203;。

當然，這只是達成我們目標的一種特定方式，沒有什麼阻止您使用其他方法，例如建立您自己的&#8203;`Dockerfile`&#8203;將您的設定檔複製至ASF Docker容器中的&#8203;`/app/config`&#8203;資料夾中。 本指南只會涵蓋基礎用法。

### 卷的權限

ASF容器預設是以預設的&#8203;`root`&#8203;使用者初始化，這使容器能夠處理內部權限問題，然後再切換成&#8203;`asf`&#8203;（UID &#8203;`1000`&#8203;）使用者來處理主程序的剩餘部分。 雖然這對絕大多數使用者來說應該能夠接受，但它確實會影響共用卷，因為新建立的檔案擁有者會是&#8203;`asf`&#8203;使用者，如果您想讓其他使用者使用您的共用卷，這可能就不是很理想了。

Docker允許您向&#8203;`docker run`&#8203;命令傳遞&#8203;`--user`&#8203;**[旗標](https://docs.docker.com/engine/reference/run/#user)**&#8203;，定義執行ASF的預設使用者。 您可以透過例如&#8203;`id`&#8203;之類的命令來查詢您的&#8203;`uid`&#8203;及&#8203;`gid`&#8203;，然後把它傳遞給剩餘的命令。 舉例來說，假設您的目標使用者的&#8203;`uid`&#8203;及&#8203;`gid`&#8203;皆為1001：

```shell
docker run -it -u 1001:1001 -v /home/archi/ASF/config:/app/config --name asf --pull always justarchi/archisteamfarm
```

記住，預設情形下，ASF使用的&#8203;`/app`&#8203;資料夾仍為&#8203;`asf`&#8203;所擁有。 若您使用自訂使用者執行ASF，那麼您的ASF程序不會擁有寫入自身檔案的權限。 這個權限並非操作所必需的，但對於某些功能來說相當重要，例如自動更新功能。 若要解決此問題，只需將ASF的所有檔案擁有者從預設的&#8203;`asf`&#8203;改成您新增的使用者即可。

```shell
docker exec -u root asf chown -hR 1001:1001 /app
```

在您使用&#8203;`docker run`&#8203;建立您的容器以後，只需執行一次，且只有在您決定為ASF程序使用自訂使用者時才需執行。 也不要忘記將上述命令中的&#8203;`1001:1001`&#8203;引數更改成您實際想要執行ASF的&#8203;`uid`&#8203;及&#8203;`gid`&#8203;。

### 在 SELinux 使用卷

若您在作業系統上以強制狀態使用SELinux，這是基於例如RHEL發行版的預設設定，那麼您應該在掛載卷時附加&#8203;`:Z`&#8203;選項，才能正確設定SELinux的上下文。

```
docker run -it -v /home/archi/ASF/config:/app/config:Z --name asf --pull always justarchi/archisteamfarm
```

這會使ASF能夠在Docker容器中建立以卷為目標的檔案。

---

## 多個實例同步

ASF也包含了支援多個實例的同步，正如&#8203;**[管理](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management-zh-TW#多個實例)**&#8203;章節所述。 當在Docker容器中執行ASF時，若您使用多個容器且希望它們同步，可以手動選擇「加入程序」。

預設情形下，每個在Docker容器執行的ASF都是獨立的，這代表同步不會發生。 為了在它們之間啟用同步，您必須將每個ASF容器中的&#8203;`/tmp/ASF`&#8203;路徑以讀寫模式連結至您想要同步的代管Docker的共用路徑上。 這與上述連結卷的方式完全相同，只是路徑不同：

```shell
mkdir -p /tmp/ASF-g1
docker run -v /tmp/ASF-g1:/tmp/ASF -v /home/archi/ASF/config:/app/config --name asf1 --pull always justarchi/archisteamfarm
docker run -v /tmp/ASF-g1:/tmp/ASF -v /home/john/ASF/config:/app/config --name asf2 --pull always justarchi/archisteamfarm
# 以此類推，所有 ASF 容器現在相互同步
```

我們建議將ASF的&#8203;`/tmp/ASF`&#8203;資料夾也連結至您設備上的&#8203;`/tmp`&#8203;暫存檔資料夾，當然，您也可以自由選擇連結至需要的其他路徑。 每個預期同步的ASF容器都應有與其他容器共用的&#8203;`/tmp/ASF`&#8203;資料夾，會參與同一個同步程序。

可能您已經從上述猜出，您也可以透過連結不同的Docker代管路徑至ASF的&#8203;`/tmp/ASF`&#8203;，來建立兩個或多個「同步群組」。

掛載&#8203;`/tmp/ASF`&#8203;完全屬於選擇性功能，且實際上並不建議使用，除非您明確需要同步兩個或多個ASF容器。 我們不建議在使用單個容器時掛載&#8203;`/tmp/ASF`&#8203;，因為如果您只執行單一的ASF容器，這個操作不會有任何正面作用，反而可能會帶來本應能避免的其他問題。

---

## 命令列引數

ASF允許您透過環境變數向Docker容器傳遞&#8203;**[命令列引數](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments-zh-TW)**&#8203;。 對於受支援的開關，您應使用特定的環境變數；其餘開關則使用&#8203;`ASF_ARGS`&#8203;。 這可以向&#8203;`docker run`&#8203;加入&#8203;`-e`&#8203;開關來達成，例如：

```shell
docker run -it -e "ASF_CRYPTKEY=MyPassword" -e "ASF_ARGS=--no-config-migrate" --name asf --pull always justarchi/archisteamfarm
```

這會正確把您的&#8203;`--cryptkey`&#8203;及其他引數傳遞給Docker容器中執行的ASF程序。 當然，如果您是進階使用者，那麼您也可以修改&#8203;`ENTRYPOINT`&#8203;，或是加入&#8203;`CMD`&#8203;來手動傳遞自訂引數。

除非您想要提供自訂加密鍵或其他進階選項，否則通常您不需要任何特殊的環境變數，因為我們的Docker容器已經設定成使用&#8203;`--no-restart`&#8203; &#8203;`--process-required`&#8203; &#8203;`--system-required`&#8203;合理的預設選項執行，因此就不需要在&#8203;`ASF_ARGS`&#8203;中指定這些旗標。

---

## IPC

假設您並未修改&#8203;`IPC`&#8203;**[全域設定屬性](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-zh-TW#全域設定檔)**&#8203;的預設值，那麼它已是啟用的。 但是，您必須額外做兩件事情，才能使IPC在Docker容器中正常運作。 首先，您必須使用&#8203;`IPCPassword`&#8203;，或在自訂的`IPC.config`&#8203;中更改預設的&#8203;`KnownNetworks`&#8203;，使您能夠在不使用的情形下連線。 除非您真的知道您在做什麼，否則請直接使用&#8203;`IPCPassword`&#8203;。 其次，您還需要更改&#8203;`localhost`&#8203;預設的監聽位址，因為Docker無法將外部流量路由至回送介面。 `http://*:1242`&#8203;是一個監聽所有介面的設定範例。 當然，您也可以使用更加嚴格的連結，例如只使用區域網路LAN或VPN網路，但它必須是可從外部存取的路由⸺而&#8203;`localhost`&#8203;就不是，因為該路由完全在客戶機內部。

為了執行上述操作，您需要使用&#8203;**[自訂IPC組態](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-zh-TW#自訂組態)**&#8203;如下列所示：

```json
{
    "Kestrel": {
        "Endpoints": {
            "HTTP": {
                "Url": "http://*:1242"
            }
        }
    }
}
```

在非回送介面上設定IPC後，我們需要使用&#8203;`-P`&#8203;或&#8203;`-p`&#8203;開關來告訴Docker映射至ASF的&#8203;`1242/tcp`&#8203;連接埠上。

舉例來說，本命令（只）會將ASF IPC介面公開給主機：

```shell
docker run -it -p 127.0.0.1:1242:1242 -p [::1]:1242:1242 --name asf --pull always justarchi/archisteamfarm
```

若您一切都設定正確，上述的&#8203;`docker run`&#8203;命令將會使&#8203;**[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-zh-TW)**&#8203;介面在您的主機運作，標準的&#8203;`localhost:1242`&#8203;路由現在已正確重定向至您的客戶機上。 值得注意的是，我們沒有進一步公開此路由，因此只能在Docker主機內完成連線，從而保持了安全。 當然，如果您知道您在做什麼，且確保擁有適合的安全措施，您也可以進一步公開此路由。

---

### 完整的範例

綜上所述，完整設定的範例如下所示：

```shell
docker run -p 127.0.0.1:1242:1242 -p [::1]:1242:1242 -v /home/archi/ASF/config:/app/config --name asf --pull always justarchi/archisteamfarm
```

這假定您將使用單一ASF容器，且所有ASF設定檔都位於&#8203;`/home/archi/ASF/config`&#8203;中。 您應該將設定的路徑更改成與您設備相符的路徑。 若您決定將&#8203;`IPC.config`&#8203;包含在您的設定資料夾中，此設定也可以用於IPC，內容如下所示：

```json
{
    "Kestrel": {
        "Endpoints": {
            "HTTP": {
                "Url": "http://*:1242"
            }
        }
    }
}
```

---

## 專業小技巧

當您準備好ASF的Docker容器後，您就不必每次都使用&#8203;`docker run`&#8203;了。 您可以透過&#8203;`docker stop asf`&#8203;及&#8203;`docker start asf`&#8203;簡單地停止／啟動ASF Docker容器。 請注意，如果您使用的不是&#8203;`latest`&#8203;標籤，那麼使用最新版本的ASF仍然需要您再次執行&#8203;`docker stop`&#8203;、&#8203;`docker rm`&#8203;及&#8203;`docker run`&#8203;。 這是因為每次您想要使用包含在映像檔中的ASF版本時，您都必須由新的ASF Docker映像檔重建您的容器。 在&#8203;`latest`&#8203;標籤中，ASF已包含自我更新的能力，因此使用最新版本的ASF不需要重建映像檔（但偶爾這樣做仍有好處，可以使用新的.NET相依執行環境及底層作業系統，這可能會在跨越ASF主要大版本時會需要）。

如上所述，&#8203;`latest`&#8203;以外標籤的ASF不會自動更新，這代表&#8203;**您**&#8203;必須負責使用最新的&#8203;`justarchi/archisteamfarm`&#8203;儲存庫。 這有很多優點，因為通常應用程式在執行時不應動到自身的程式碼，但我們也理解不必擔心Docker容器內ASF的版本所帶來的便利。 若您需要一個良好的實際範例且正確的Docker用法，我們建議使用&#8203;`released`&#8203;標籤，而不是&#8203;`latest`&#8203;。但如果您不介意，只想讓ASF正常運作並自動更新，那麼&#8203;`latest`&#8203;即可。

通常您應該要在具有&#8203;`Headless: true`&#8203;全域設定的Docker容器內執行ASF。 這會明確告訴ASF您不會提供缺少的資料，且它也不應詢問這些。 當然，對於初次設定，您應該讓這個選項維持在&#8203;`false`&#8203;，這樣您就可以方便設定；但對於長期來說，您通常不會需要連線至ASF控制台，因此這樣告知是合理的。如果需要，使用&#8203;`input`&#8203;**[指令](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-zh-TW)**&#8203;即可。 這樣ASF就不會無限期等待不存在的使用者輸入（不然這樣等待也只是在浪費資源）。 這也使ASF能夠在容器內以非互動模式執行，這非常重要，例如在轉送訊號時，可以使ASF在收到&#8203;`docker stop asf`&#8203;請求時正常關閉。