# Steam 親友同享

ASF supports Steam Family Sharing - in order to understand how ASF works with that, you should firstly read how **[Steam Family Sharing works](https://store.steampowered.com/promotion/familysharing)**, which is available on Steam store.

---

## ASF

ASF中對 Steam 親友同享功能的支援是透明的, 這意味著它不會引入任何新的 bot/process 配置屬性。它作為一個額外的內置功能, 開箱即用。

ASF中包括適當的邏輯, 當它監測到庫被親友同享用戶鎖定時，不會因為啟動遊戲而將他們 "踢" 出遊戲會話。 ASF的行為與持有鎖的主帳戶完全相同，因此，如果您的Steam用戶端或您的親友同享用戶持有該鎖，ASF將不會嘗試進行掛卡，而是等待帳戶解鎖。

In addition to above, after logging in, ASF will access your **[family sharing settings](https://store.steampowered.com/account/managedevices)**, from which it'll extract up to 5 `steamIDs` allowed to use your library. 這些用戶被授予使用 **[commands](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**的 `FamilySharing` 許可權，特別是允許他們對與他們共用遊戲的機械人帳戶使用 `pause~` 命令，這讓機械人暫停自動掛卡模組，以使他們可以啟動一個親友共享的遊戲。

Connecting both functionalities described above allows your friends to `pause~` your cards farming process, start a game, play as long as they wish, and then after they're done playing, cards farming process will be automatically resumed by ASF. 當然, 如果ASF目前沒有積極地進行任何掛卡活動, 則不需要發佈 `pause~`, 因為您的朋友可以立即啟動遊戲, 並且上述邏輯可確保他們不會被踢出會話。

---

## 限制

Steam network loves to mislead ASF by broadcasting false status updates, which may lead to ASF believing it's fine to resume process, and in result kick your friend too soon. This is exactly the same issue as the one already explained by us in **[this FAQ entry](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#asf-is-kicking-my-steam-client-session-while-im-playing--this-account-is-logged-on-another-pc)**. We recommend exactly the same solutions, mainly promoting your friends to `Operator` permission (or above) and telling them to make use of `pause` and `resume` commands.