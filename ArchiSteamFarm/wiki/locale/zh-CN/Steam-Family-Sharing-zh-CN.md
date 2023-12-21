# Steam 家庭库共享

ASF 支持 Steam 家庭库共享——想要理解 ASF 这一功能的原理，您应该先阅读 Steam 商店提供的 **[Steam 家庭共享](https://store.steampowered.com/promotion/familysharing)**&#8203;介绍。

---

## ASF

ASF 对 Steam 家庭共享功能的支持是透明的，这意味着它不会引入任何新的机器人/全局配置属性——这是一个额外的内置功能，开箱即用。

ASF 包括适当的逻辑，以便知道游戏库被家庭共享用户锁定，因此它不会因为启动游戏而将他们踢出游戏会话。 ASF 的行为与持有锁的主帐户完全相同，因此，如果您的 Steam 客户端或您的一个家庭共享用户持有该锁，ASF 将不会尝试挂卡，而是等待锁被释放。

此外，ASF 将会从您的&#8203;**[家庭库共享设置](https://store.steampowered.com/account/managedevices)**&#8203;中提取最多 5 名被允许使用您游戏库的用户的 `steamID`。 这些用户将会以 `FamilySharing` 权限执行&#8203;**[命令](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-zh-CN)**，特别是允许他们对提供家庭库共享的机器人使用 `pause~` 命令，使他们可以暂停自动挂卡模块并且运行家庭共享的游戏。

综合以上功能，您的朋友可以执行 `pause~` 暂停您的挂卡过程、启动游戏、玩一段时间游戏，然后在他们退出游戏后，ASF 将会自动恢复挂卡过程。 当然，如果 ASF 目前没有处于挂卡状态，则不需要执行 `pause~` 命令，因为您的朋友可以立即启动游戏，并且上述逻辑确保他们不会被踢出会话。

---

## 限制

Steam 网络经常广播错误的状态更新误导 ASF，这可能导致 ASF 认为可以恢复挂卡过程，结果导致踢出您的朋友。 这与我们在&#8203;**[此条常见问题](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ-zh-CN#在我玩游戏的时候asf-将我的-steam-客户端踢掉线--this-account-is-logged-on-another-pc这个帐户在另一台电脑登录)**&#8203;中解释的情况完全相同。 我们建议的解决方案也完全相同，主要是为您的好友授予 `Operator` 或更高权限，并告诉他们使用 `pause` 和 `resume` 命令。