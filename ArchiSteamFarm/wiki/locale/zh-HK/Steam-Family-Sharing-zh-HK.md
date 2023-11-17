# Steam 親友同享

ASF自 2.1.5.5 + 版開始支援Steam親友同享。 為了了解 ASF 是如何工作的，您應該首先閱讀 Steam 商店中提供的**[Steam Family Sharing works](https://store.steampowered.com/promotion/familysharing)**。

---

## ASF

ASF中對 Steam 親友同享功能的支援是透明的, 這意味著它不會引入任何新的 bot/process 配置屬性。它作為一個額外的內置功能, 開箱即用。

ASF中包括適當的邏輯, 當它監測到庫被親友同享用戶鎖定時，不會因為啟動遊戲而將他們 "踢" 出遊戲會話。 ASF的行為與持有鎖的主帳戶完全相同，因此，如果您的Steam用戶端或您的親友同享用戶持有該鎖，ASF將不會嘗試進行掛卡，而是等待帳戶解鎖。

除上述內容外, 登錄後, ASF 還將訪問您的 **

games sharing settings </0 >, 它將從中提取多達 5個被允許使用您的庫的用戶的`steamID` 。 這些用戶被授予使用 **[commands](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**的 `FamilySharing` 許可權，特別是允許他們對與他們共用遊戲的機械人帳戶使用 `pause~` 命令，這讓機械人暫停自動掛卡模組，以使他們可以啟動一個親友共享的遊戲。</p> 

上述兩個功能配合使用，可以讓您的朋友執行 `pause~` 暂停您的掛卡過程, 開始遊戲, 玩到天昏地暗, 他們退出遊戲後, ASF將自動復原掛卡過程。 當然, 如果ASF目前沒有積極地進行任何掛卡活動, 則不需要發佈 `pause~`, 因為您的朋友可以立即啟動遊戲, 並且上述邏輯可確保他們不會被踢出會話。



---



## 限制

Steam network loves to mislead ASF by broadcasting false status updates, which may lead to ASF believing it's fine to resume process, and in result kick your friend too soon. This is exactly the same issue as the one already explained by us in **[this FAQ entry](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#asf-is-kicking-my-steam-client-session-while-im-playing--this-account-is-logged-on-another-pc)**. We recommend exactly the same solutions, mainly promoting your friends to `Operator` permission (or above) and telling them to make use of `pause` and `resume` commands.