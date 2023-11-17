# 背景序號啟動器

背景序號啟動器是ASF內建的特殊功能，可以讓您匯入一批Steam序號（包含遊戲名稱），以便在背景啟用。 若您需要一次啟動大量序號，在全數啟動前，必定會觸發&#8203;`RateLimited`&#8203;**[狀態](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ-zh-TW#啟用序號時的狀態是什麼意思)**&#8203;，此時，背景啟動功能將會非常有用。

背景序號啟動器只對單個Bot有效，也就是說，它不會採用&#8203;`RedeemingPreferences`&#8203;中的設定。 若有需要，本功能可以和&#8203;`redeem`&#8203;**[指令](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-zh-TW)**&#8203;一起使用（或者代替它）。

---

## 匯入

匯入可以透過兩種方式進行：使用文字檔或IPC。

### 文字檔

ASF會辨識&#8203;`config`&#8203;資料夾下名為&#8203;`BotName.keys`&#8203;的檔案，其中&#8203;`BotName`&#8203;是你的Bot的名稱。 該檔案具有固定格式，每行由遊戲名稱及遊戲序號所組成，兩者之間需以Tab分隔，並以換行結束，用來表示開始下一組項目。 若一行中使用多個Tab，則該行第一項會被視為遊戲名稱，最後一項會被視為遊戲序號，而中間的所有內容都將被忽略。 舉例來說：

```text
POSTAL 2    ABCDE-EFGHJ-IJKLM
Domino Craft VR 12345-67890-ZXCVB
A Week of Circus Terror POIUY-KJHGD-QWERT
Terraria    這裡會被忽略   這裡也會被忽略    ZXCVB-ASDFG-QWERT
```

此外，您也可以只輸入遊戲序號（但序號之間仍需使用換行作為分隔）。 若是這種情形，如果能夠，ASF將會向Steam詢問正確的遊戲名稱。 我們建議您自行標記所有序號的名稱，因為在Steam上啟動的遊戲組合包的名稱邏輯，不一定會與組合包中的遊戲名稱一致。依開發人員填寫的內容，您可能會看到正確的遊戲名稱、自訂名稱（例如Humble Indie Bundle 18），或完全錯誤、甚至是惡意的名稱（例如Half-Life 4）。

```text
ABCDE-EFGHJ-IJKLM
12345-67890-ZXCVB
POIUY-KJHGD-QWERT
ZXCVB-ASDFG-QWERT
```

不論您選擇使用哪種格式，ASF都會在Bot啟動或執行時匯入您的&#8203;`keys`&#8203;檔案。 在成功剖析並忽略無效的序號後，所有正確偵測到的遊戲都會被加入背景佇列，而&#8203;`BotName.keys`&#8203;檔案也將會自動從&#8203;`config`&#8203;資料夾中移除。

### IPC

除了使用上述提到的遊戲序號文字檔外，ASF也開放了可供任意IPC工具（包含我們的ASF-ui）使用的&#8203;`GamesToRedeemInBackground`&#8203;**[ASF API端點](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-zh-TW#asf-api)**&#8203;。 IPC將能提供更完善的功能，因為您可以使用自己覺得適合的方式進行剖析。例如使用自訂定界符，而非強制使用Tab，甚至，您也可以完全自訂序號的格式。

---

## 佇列

在成功匯入遊戲後，它們會被加入至佇列中。 只要Bot與Steam網路保持連線，且佇列中仍有遊戲，ASF就會自動處理背景佇列。 嘗試啟動序號且沒有觸發&#8203;`RateLimited`&#8203;後，該序號將會被移出佇列，其啟動結果亦會寫入位於&#8203;`config`&#8203;資料夾中的檔案。當序號被程序使用掉（例如結果為&#8203;`NoDetail`&#8203;、&#8203;`BadActivationCode`&#8203;、&#8203;`DuplicateActivationCode`&#8203;），會寫入&#8203;`BotName.keys.used`&#8203;，否則會寫入&#8203;`BotName.keys.unused`&#8203;。 由於Steam網路不一定會回傳序號所屬遊戲的正確名稱，所以ASF會使用您提供的遊戲名稱。這樣您就可以依據需要，使用自訂名稱來標記您的序號。

如果在這個過程中，帳號觸發了&#8203;`RateLimited`&#8203;狀態，佇列將會暫停一小時，以等待冷卻時間結束。 在這之後，程序將繼續進行，直到清空整個佇列或又再次遇到&#8203;`RateLimited`&#8203;。

---

## 範例

假設您有一個包含100個序號的清單。 首先，您應該在ASF的&#8203;`config`&#8203;資料夾中，建立一個名為&#8203;`BotName.keys.new`&#8203;的檔案。 我們加上了&#8203;`.new`&#8203;副檔名，是為了防止ASF在我們建立檔案時，立刻讀取該檔案（因為它是一個空白檔案，還尚未準備匯入）。

現在您可以開啟剛才建立的檔案，將100個序號貼上，並視情形修正格式。 格式修正後，&#8203;`BotName.keys.new`&#8203;檔案中應該正好有100行（如果末端有空行的話就是101行），每一行的格式均為&#8203;`遊戲名稱\t遊戲序號\n`&#8203;，其中的&#8203;`\t`&#8203;是Tab字元，&#8203;`\n`&#8203;是換行。

在儲存並關閉檔案後，您現在可以將該檔案由&#8203;`BotName.keys.new`&#8203;重新命名成&#8203;`BotName.keys`&#8203;，以便讓ASF知道該檔案已準備好匯入。 重新命名後，ASF會自動匯入該檔案（不需要重新啟動），並在確認所有遊戲皆剖析成功並加入佇列後，刪除該檔案。

除了&#8203;`BotName.keys`&#8203;檔案，您也可以使用IPC API端點，甚至也可以依據您的需求，配合使用兩種方式。

經過一段時間後，會產生&#8203;`BotName.keys.used`&#8203;及&#8203;`BotName.keys.unused`&#8203;兩個檔案。 這兩個檔案含有啟動過程的結果。 舉例來說，您可以將&#8203;`BotName.keys.unused`&#8203;重新命名成&#8203;`BotName2.keys`&#8203;，來將未使用的序號交給其他的Bot，因為前一個Bot未使用到這些序號。 或者，您也可以將未使用的序號複製貼上到其他檔案中留作他用。 請注意，在ASF處理佇列時，新的項目是逐一寫入至&#8203;`used`&#8203;和&#8203;`unused`&#8203;兩個輸出檔案中的，因此建議等待佇列完全清空後，再使用這兩個檔案。 若您無論如何都要在佇列完全清空之前，存取這些檔案的話，您應&#8203;**先將**&#8203;欲存取的檔案移動至別的資料夾中，&#8203;**然後**&#8203;再對其做進一步處理。 這是因為ASF可能會在您處理這些檔案的時候寫入新的結果，這有可能會導致某些序號遺失。例如：您讀取了一個包含3個序號的檔案，然後將其刪除，但ASF在此期間又寫入了4個新序號，這樣那些新寫入的序號便會遺失。 若您想存取這些檔案，請務必先將它們從ASF的&#8203;`config`&#8203;資料夾中移出，例如重新命名檔案。

您也可以在佇列已有遊戲的情形下匯入更多遊戲，只需要重覆上述步驟就行了。 ASF會將它們正確加入正在處理的佇列中，並最終處理它們。

---

## 備註

背景序號啟動器在底層使用了&#8203;`OrderedDictionary`&#8203;，這代表遊戲序號將會依照檔案中（或IPC API呼叫中）的順序啟動。 這代表如果某些序號需要先擁有另一個序號才能啟動，請將其列於該序號後方。 舉例來說，如果您有DLC &#8203;`D`&#8203;，且需要先啟動遊戲&#8203;`G`&#8203;才能啟動，那麼您&#8203;**必須**&#8203;將遊戲&#8203;`G`&#8203;的序號排在DLC &#8203;`D`的前面。 同樣地，如果啟動DLC &#8203;`D`&#8203;之前，需先啟動&#8203;`A`&#8203;、&#8203;`B`&#8203;及&#8203;`C`&#8203;，那麼這三個序號就應該被放在前面（可以是任意順序，除非它們各自也有相依關係）。

若未依上方所述的方式啟動，會導致DLC啟動失敗，並回傳&#8203;`DoesNotOwnRequiredApp`&#8203;結果。即使您的帳號在完成整個佇列後，得以啟動該DLC，它也不會在此時被啟動。 如果要避免這種錯誤，請務必確保佇列中的DLC被放在遊戲本體之後。