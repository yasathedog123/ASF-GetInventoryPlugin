# 後台序號啟動器

後台序號啟動器是一個特殊的 ASF 內置功能，允許您導入一組給定的Steam cd-keys（連同其名稱）以在後台兌換。 如果您想批次兌換多個產品序號，完成整個過程之前必將觸發`RateLimited` **[狀態](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#what-is-the-meaning-of-status-when-redeeming-a-key)**，此時這個功能將會非常有用。

後台序號啟動器僅對單個機械人有效，這意味著它不會採用 `RedeemingPreferences` 的設置。 若有需要，此功能可以與（或代替） `redeem` **[命令](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**一起使用。

---

## 導入

導入可以通過兩種方式進行──使用文字檔案或 IPC。

### 檔案：

ASF 會識別`config`目錄下名為 `BotName.keys`的檔案，其中 `BotName`是您的機械人名稱。 該檔案必須按固定格式編寫，每行由遊戲名稱和遊戲序號組成，兩者之間以 Tab 分隔，並以一個分行符號結束，表示開始下一項。 如果使用多個 Tab，則第一個條目會被視為遊戲名稱，最後一個會被視為遊戲序號，中間的所有內容都將被忽略。 範例：

```text
POSTAL 2	ABCDE-EFGHJ-IJKLM
Domino Craft VR	12345-67890-ZXCVB
A Week of Circus Terror	POIUY-KJHGD-QWERT
Terraria	忽略	忽略	ZXCVB-ASDFG-QWERT
```

或者，您還可以只使用遊戲序號格式（每個條目之間仍須有一個分行符號）。 在這種情況下，ASF 將使用 Steam 的應答（如果可能的話）來填充正確的遊戲名稱。 對於任何類型的金鑰標記，我們建議您使用自訂名稱，因為在 Steam 上兌換的包名稱不一定與包中的遊戲名稱一致，因此根據開發者填寫的內容，您可能會看到正確的遊戲名稱、自訂包名稱（例如 Humble Indie Bundle 18）或完全錯誤甚至是惡意的名稱（例如 Half-Life 4）。

```text
ABCDE-EFGHJ-IJKLM
12345-67890-ZXCVB
POIUY-KJHGD-QWERT
ZXCVB-ASDFG-QWERT
```

無論你決定使用哪種格式，ASF 都將在機械人啟動或執行時導入你的 `keys` 檔案。 成功解析檔案並跳過無效序號後，所有正確檢測到的遊戲都將被添加到后台佇列中，`BotName.keys` 檔案將自動從 `config` 目錄中刪除。

### IPC

除了使用上面提到的產品序號檔案外，ASF還開放了 `GamesToRedeemInBackground` **[ASF API 端點](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-api)**，它能以任何IPC 工具（包括我們的 ASF-ui）執行。 IPC 可提供更完善的功能，因為您可以使用您覺得合適的方式進行解析。例如使用自訂分隔符號，而非強制使用 Tab，甚至可以完全自訂序號格式。

---

## 佇列

成功導入遊戲後，它們將添加到佇列中。 只要機械人與 Steam 網絡保持連線，且佇列不為空，ASF 就會自動處理後台佇列。 如果ASF嘗試兌換一個序號卻沒有觸發 `RateLimited` ，該序號將會被移出佇列並根據其兌換結果寫入位於 `config` 資料夾中的檔案。當序號被使用時（例如結果為：`NoDetail`、`BadActivationCode`、`DuplicateActivationCode`），兌換將會被寫入 `BotName.keys.used`，否則就會被寫入 `BotName.keys.unused`。 由於 Steam 網絡不一定會回傳序號所屬遊戲的正確名稱，所以 ASF 會使用您提供的遊戲名稱。這樣您就可以根據需要使用自訂名稱標記你的序號。

如果在兌換過程中帳戶觸發 `RateLimited` 狀態，佇列將會暫停一小時以等待冷卻時間結束。 Afterwards, the process continues where it left, until the entire queue is empty or another `RateLimited` occurs.

---

## 範例

假設你有一個包含 100 個序號的清單。 首先，您應該在ASF `config` 目錄下創建一個名為 `BotName.keys.new` 的檔案。 我們加上 `.new` 後綴是為了防止 ASF 在建立檔案時立刻讀取該檔案（因為它是一個全新的檔案，尚未準備導入）。

現在您可以打開我們剛建立的檔案，貼上100 個序號，並視情況修正格式。 之後， `BotName.keys.new` 檔案中應該正好有 100 行（如果末尾有換行符的話就是 101 行），每一行的格式均為 `遊戲名稱\t遊戲序號\n`，其中 `\t` 是 Tab 符，`\n` 是換行符。

現在您已可將該檔案從 `BotName.keys.new` 重命名為 `BotName.keys`，以讓 ASF 知道該檔案已準備好被導入。 重命名後，ASF 會自動導入該檔案（無需重啟），並在確認所有遊戲皆解析成功且加入佇列後刪除該檔案。

除了 `BotName.keys` 檔案，您還可以使用 IPC API 端點，甚至也可以根據需要將兩種方式配合使用。

一段時間後，會生成 `BotName.keys.used` 和 `BotName.keys.unused` 等檔案。 這些檔案包含了我們兌換過程的結果。 例如，您可以將 `BotName.keys.unused` 重命名為 `BotName2.keys`，以便向其他機械人派發我們未使用的金鑰，因為前一個機械人並未使用這些金鑰。 或者您也可以簡單地將未使用的金鑰複製粘貼到其他檔案中，留作他用。 請謹記，當 ASF 處理佇列時，新的條目將被添加入 `used` 和 `unused` 等輸出檔，因此建議等待佇列完全清空後再使用這些檔。 如果在佇列完全清空之前需要訪問這些檔，應首先將欲訪問的檔 **移動** 至其他目錄，**之後** 再對其進行處理。 這是因為 ASF 可能會在你處理這些檔案的時候寫入新的結果而導致某些序號遺失。例如，你讀取了一個包含 3 個序號的檔案，然後將其刪除，這可能會導致 ASF 在此期間寫入的4 個新序號遺失。 如果要訪問這些檔，請確保在讀取這些檔之前將它們移出 ASF `config` 目錄，例如通過重命名方式。

您還可以通過重複上述所有步驟，在佇列中已有一些遊戲的情況下，添加額外的遊戲。 ASF 會正確地將我們的額外條目加入正在進行的佇列中並最終處理之。

---

## 備註

後台序號啟動器在底層使用了 `OrderedDictionary`，這意味着您的遊戲金鑰將會按照檔案中指定（或 IPC API 調用）的順序啟動。 這意味著如果某些金鑰需要先擁有另一個序號才能啟動，請您（務必）將該序號列於此金鑰之前。 例如，這意味著如果您有 DLC `D` ，它需要擁有遊戲本體 `G` 才可兌換，那麼您**應始終**將遊戲 `G` 的金鑰排在 DLC `D` 的金鑰前面。 同樣，如果 DLC `D`依賴于`A`、`B` 和 `C`，那麼A、B、C就應該排在D前面（任意順序均可，除非它們有自己的依賴關係）。

如果不遵循上述方案，即使您的帳戶在完成整個佇列後有資格兌換此DLC, 也會因`DoesNotOwnRequiredApp` 而無法兌換。 若想避免這種情況，請確保您佇列中的DLC始終位於遊戲本體之後。