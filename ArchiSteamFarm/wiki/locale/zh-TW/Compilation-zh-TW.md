# 編譯

編譯是生成執行檔的過程。 若您想將自己的修改加入至ASF中，或出於任何原因不信任官方在&#8203;**[發布頁面](https://github.com/JustArchiNET/ArchiSteamFarm/releases)**&#8203;中提供的執行檔，就需要做這件事。 若您是一般的使用者而不是開發人員，則您很有可能需要使用已預編譯的二進制檔案，但如果您希望使用自己的二進制檔案或學習新內容，請繼續閱讀。

只要您擁有所有需要的工具，就可以在任何當前受支援的平台上編譯ASF。

---

## .NET SDK

不論使用何種平台，您都需要完整的.NET SDK（不只是執行環境）才能編譯ASF。 您可以在&#8203;**[.NET下載頁面](https://dotnet.microsoft.com/download)**&#8203;上找到安裝說明。 您需要安裝適合您作業系統的.NET SDK版本。 成功安裝後，&#8203;`dotnet`&#8203;命令應可正常執行。 您可以使用&#8203;`dotnet --info`&#8203;來驗證。 也要確保您的.NET SDK符合ASF的&#8203;**[執行環境需求](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility-zh-TW#執行環境需求)**&#8203;。

---

## 編譯

假設您已擁有適合的.NET SDK版本，只需前往ASF原始碼資料夾（Clone或下載並解壓縮後的ASF儲存庫）並執行：

```shell
dotnet publish ArchiSteamFarm -c "Release" -o "out/generic"
```

若您使用Linux/macOS，則可以改用&#8203;`cc.sh`&#8203;腳本，以稍複雜的方法執行相同的操作。

若編譯成功完成，您可以在&#8203;`out/generic`&#8203;資料夾中找到您的ASF &#8203;`source`&#8203;套件。 這與ASF官方的&#8203;`Generic`&#8203;組建版本相同，但因為這是您自己組建的，所以它會強制設定&#8203;`UpdateChannel`&#8203;和&#8203;`UpdatePeriod`&#8203;為&#8203;`0`&#8203;。

### 適用於特定作業系統

若您有需要，也可以生成適用於特定作業系統的.NET套件。 在一般情形下，不需要這樣做，因為您剛剛編譯了&#8203;`generic`&#8203;版本，您可以使用已安裝用於編譯的.NET執行環境來執行，但以防萬一您想要：

```shell
dotnet publish ArchiSteamFarm -c "Release" -o "out/generic"
```

當然，您需要將&#8203;`linux-x64`&#8203;取代成您所需目標的作業系統架構，例如&#8203;`win-x64`&#8203;。 這個組建版本也將停用自動更新。

### ASF-ui

雖然上述是組建完整的ASF需要的所有步驟，但您可能&#8203;*也*&#8203;有興趣了解如何組建我們的Web使用者介面：&#8203;**[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-zh-TW#asf-ui)**&#8203;。 從ASF的角度來說，您需要做的是將ASF-ui組建版本輸出放到標準&#8203;`ASF-ui/dist`&#8203;位置，然後讓它與ASF一起組建（如果需要）。

ASF-ui作為&#8203;**[Git Submodule](https://git-scm.com/book/en/v2/Git-Tools-Submodules)**&#8203;，是ASF Source Tree的一部份，請確保您已使用&#8203;`git clone --recursive`&#8203;來複製儲存庫，否則您會缺失必要檔案。 您還必須擁有可用的NPM，&#8203;**[Node.js](https://nodejs.org)**&#8203;有自帶它。 若您使用Linux/macOS，我們建議使用我們的&#8203;`cc.sh`&#8203;腳本，它將自動組建並搭載ASF-ui（如果可能，也就是說，若您滿足我們剛剛提到的需求）。

除了&#8203;`cc.sh`&#8203;腳本，我們也在下文附上簡明組建說明，請參閱&#8203;**[ASF-ui儲存庫](https://github.com/JustArchiNET/ASF-ui)**&#8203;以獲得更多說明文件。 從ASF的Source Tree位置，同上所述，執行以下命令：

```shell
rm -rf "ASF-ui/dist" # ASF-ui 不會自行清除舊組建版本

npm ci --prefix ASF-ui
npm run-script deploy --prefix ASF-ui

rm -rf "out/generic/www" # 確保我們的組建輸出不會含有舊檔案
dotnet publish ArchiSteamFarm -c "Release" -o "out/generic" # 或依據上文選擇您所需的
```

您現在應該可以在&#8203;`out/generic/www`&#8203;資料夾中找到ASF-ui檔案了。 ASF能向您的瀏覽器伺服這些檔案。

或者，您也可以直接組建ASF-ui，不論是手動或是透過我們的儲存庫的幫助下，再手動複製組建輸出至&#8203;`${OUT}/www`&#8203;資料夾中，其中&#8203;`${OUT}`&#8203;是您使用&#8203;`-o`&#8203;參數指定的ASF輸出資料夾。 這正是ASF在組建過程中所做的，它將&#8203;`ASF-ui/dist`&#8203;（如果存在）複製到&#8203;`${OUT}/www`&#8203;，沒什麼特別的。

---

## 開發

若您想編輯ASF程式碼，您可以使用任何與.NET相容的IDE，但也可以選擇不要用，因為您也可以使用記事本來編輯，並使用上述的&#8203;`dotnet`&#8203;命令來編譯。 不過，對於Windows系統，我們建議使用&#8203;**[最新版本的Visual Studio](https://visualstudio.microsoft.com/downloads)**&#8203;（免費的社群版本即可）。

若您想要在Linux/macOS上使用ASF程式碼，我們建議使用&#8203;**[最新版本的Visual Studio Code](https://code.visualstudio.com/download)**&#8203;。 它沒有經典版Visual Studio那麼豐富的功能，但也已足夠了。

當然，以上都只是建議，您可以使用您想用的任何工具，但最後您都會需要使用&#8203;`dotnet build`&#8203;命令來組建。 我們使用了&#8203;**[JetBrains Rider](https://www.jetbrains.com/rider)**&#8203;來開發ASF，但它並不是免費的。

---

## 標籤

`main`&#8203;分支無法保證可以編譯成功或讓ASF正常執行，如我們在&#8203;**[發布週期](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Release-cycle-zh-TW)**&#8203;中所述，因為它是開發分支。 若您希望從原始碼編譯或參照ASF，就應該為此選擇適當的&#8203;**[標籤](https://github.com/JustArchiNET/ArchiSteamFarm/tags)**&#8203;，這樣能夠保證編譯成功，且很有可能還能完美執行（如果組建被標示成穩定版本）。 若要檢查Tree的當前「健康狀態」，您可以使用我們的CI：&#8203;**[GitHub](https://github.com/JustArchiNET/ArchiSteamFarm/actions/workflows/ci.yml?query=branch%3Amain)**&#8203;。

---

## 官方發布版本

官方ASF發布版本由&#8203;**[GitHub](https://github.com/JustArchiNET/ArchiSteamFarm/actions)**&#8203;編譯，並帶有符合ASF&#8203;**[執行環境](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility-zh-TW#執行環境需求)**&#8203;的最新.NET SDK。 通過測試後，所有套件會都作為發布版本部署，並放置在GitHub上。 這也保證了透明度，因為GitHub都會使用官方開源來進行所有的組建，並且您也可以檢查GitHub部件的核對和及GitHub的發布資源。 除了私人的開發過程及除錯外，ASF開發人員不會自行編譯或發布組建版本。

除了上述情形外，ASF維護人員會在獨立於GitHub的遠端ASF伺服器上手動驗證並發布組建核對和，作為額外的安全措施。 現有的ASF必須執行此步驟，才能將該版本視為自動更新功能的有效候選版本。