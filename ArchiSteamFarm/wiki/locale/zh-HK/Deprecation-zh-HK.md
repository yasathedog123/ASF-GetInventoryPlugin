# 棄用

We're doing our best to follow consistent deprecation policy in order to make both development as well as usage far more consistent.

---

## 什麼是棄用？

Deprecation is the process of smaller or bigger breaking changes that render previously used options, arguments, functionalities or usage cases obsolete. 棄用通常意味著給定的內容被簡單地重寫為另一個（類似）表單, 您應該及時確保您對其進行適當的切換。 在這種情況下，它只是將給定的功能移動到更合適的位置。

ASF 版本迭代迅速，總是追求卓越。 This sadly means that we may change or move some existing functionality into another segment of the program in order for it to benefit from new features, compatibility or stability. 正因如此，我們不需要堅持我們多年前做出的過時或錯誤的發展決定。 我們一直在努力提供合理的替換方案，以兼容以前可用的功能，這就是為什麼棄用大多是無害的，僅需要對以前的邏輯進行小的修復。

---

## 棄用階段

ASF 的棄用分為兩個階段，使過渡更容易並減少麻煩。

### 第1階段

一旦給定的功能被棄用，就會進入第1階段，並立即對此功能提供另一個解決方案（如果沒有重新引入的計畫，則不提供）。

在此階段，ASF 將在不推薦使用的函數被調用時列印恰當的警告。 只要有可能，ASF 就會嘗試模仿之前的行為，並繼續與之相容。 至少在下一個穩定版本發佈之前，ASF 將繼續處於第1階段。 在這個時刻，希望您在不破壞兼容性的情況下，可以在所有的工具和模式中進行適當的切換，以滿足新的行為。 當您不再看到棄用警告，這表示您進行了所有適當的更改。

### 第2階段

第2階段安排在上面解釋的第1階段發生後，並在穩定的版本中發佈。 此階段將完全刪除之前不推薦使用的功能，這意味著 ASF 甚至不會承認您正在嘗試使用不推薦使用的功能，更不用說考慮它了，因為它根本不存在於當前代碼中。 ASF 將不再列印任何警告，因為它不再識別您嘗試執行的操作。

---

## 概要

您有至少**一個月** 來切換並適應，這對於一個普通的 ASF 用戶來說應足夠了。 在這段時間之後，ASF 不再保證舊設置將產生任何效果（第2階段），在您察覺不到的情況下使某些功能完全停止運行。 如果您在一個多月離線後啟動 ASF，建議您**[從頭來過](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up)**以啟動 ASF，或者再次閱讀您錯過的所有更改，並手動調整您的使用方式以適應當前的更改。

In most cases, disregarding deprecation warning will not render general ASF functionality unusable, but rather falling back to default behaviour (which may or may not match your personal preferences).

---

## 範例

我們將V3.1.2.2之前的 `--server` **[命令列參數](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments)**轉移到` IPC ` ** [全域配置屬性](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#global-config) **。

### 第1階段

第1階段發生在版本 V3.1.2.2 中，我們對 `--server` 的使用添加了適當的警告。 現在過時的`--server`參數自動映射到` IPC: true `全域配置屬性，實際上與舊的`--server`開關完全相同。 這使得每個人都可以在 ASF 停止使用舊的參數之前進行適當的切換。

### 第2階段

第2階段發生在版本V3.1.3.0中，緊接在V3.1.2.9穩定之後，第1階段已在上面解釋。 階段2導致 ASF 完全停止識別`--server `參數，將其視為所有其他無效參數，這對程序不再有任何影響。 對於仍未由`--server `改為使用` IPC: true `的人，由於 ASF 不再進行適當的映射，這將導致 IPC 完全停止運行。