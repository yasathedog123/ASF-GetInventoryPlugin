# 遠端通訊

本章節會詳細說明ASF所包含的遠端通訊，並進一步解釋您如何改變它。 雖然我們不認為以下任何內容是惡意或無用的，同時我們也沒有公開它的法律義務，但我們希望您能更好理解本程式功能，特別是在您的隱私及共用資料的方面。

## Steam

ASF與Steam網路（&#8203;**[CM伺服器](https://api.steampowered.com/ISteamDirectory/GetCMList/v1?cellid=0)**&#8203;）、 &#8203;**[Steam API](https://steamcommunity.com/dev)**&#8203;、&#8203;**[Steam商店](https://store.steampowered.com)**&#8203;及&#8203;**[Steam社群](https://steamcommunity.com)**&#8203;通訊。

停用上述通訊是不可能的，因為它是ASF提供基本功能的核心基礎。 如果您不滿意上述的任何內容，請勿使用ASF。

## Steam 群組

ASF與我們的&#8203;**[Steam群組](https://steamcommunity.com/groups/archiasf)**&#8203;通訊。 群組能為您發布公告，特別是新版本、緊急狀況、Steam問題，以及其他對於保持社群更新的重要事情。 它還使您能夠經由提出問題、解決問題、報告問題或提出改進建議，來獲得我們的技術支援。 預設情形下，使用ASF的帳號會在登入時自動加入群組。

您可以透過在Bot的&#8203;**[`RemoteCommunication`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-zh-TW#remotecommunication遠端通訊)**&#8203;設定中停用&#8203;`SteamGroup`&#8203;旗標，來決定退出群組。

## GitHub

ASF與&#8203;**[GitHub的API](https://api.github.com)**&#8203;通訊，獲取&#8203;**[ASF Release](https://github.com/JustArchiNET/ArchiSteamFarm/releases)**&#8203;以用於更新功能。 這是自動更新（若您保持啟用&#8203;**[`UpdatePeriod`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#updateperiod)**&#8203;），及&#8203;`update`&#8203;**[指令](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-zh-TW)**&#8203;的一部分。 您可以透過設定&#8203;**[`UpdateChannel`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#updatechannel)**&#8203;屬性，來影響ASF與GitHub的通訊：設定成&#8203;`None`&#8203;將停用整個更新功能，包含此方面的GitHub通訊。

## ASF 伺服器

ASF與&#8203;**[我們自己的伺服器](https://asf.justarchi.net)**&#8203;通訊，以提供進階功能。 特別包含了：
- 依據我們自己的獨立資料庫，驗證從GitHub下載的ASF組建的核對和，以確保所有下載的組建檔案都是正規的（不含惡意程式、MITM攻擊或其他篡改破壞）
- 如果您啟用了&#8203;`FilterBadBots`&#8203;全域設定，則會提取用於過濾不良Bot的清單。
- 如果您在&#8203;**[`TradingPreferences`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-zh-TW#tradingpreferences交易偏好)**&#8203;中啟用&#8203;`SteamTradeMatcher`&#8203;並滿足其他準則，則會在&#8203;**[我們的名單](https://asf.justarchi.net/STM)**&#8203;中顯示您的Bot
- 如果您在&#8203;**[`TradingPreferences`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-zh-TW#tradingpreferences交易偏好)**&#8203;中啟用&#8203;`MatchActively`&#8203;並滿足其他準則，則會從&#8203;**[我們的名單](https://asf.justarchi.net/STM)**&#8203;中下載當前可交易的Bot來進行交易

作為一項安全措施，您無法停用ASF組建檔案核對和的驗證。 但如果您不想發生這種情形，如上文的GitHub章節中所述，您可以完全停用自動更新。

如果您不想從伺服器提取清單，您可以停用&#8203;`FilterBadBots`&#8203;設定。

您可以透過在Bot的&#8203;**[`RemoteCommunication`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-zh-TW#remotecommunication遠端通訊)**&#8203;設定中停用&#8203;`PublicListing`&#8203;旗標，來決定不被顯示在名單中。 如果您想執行&#8203;`SteamTradeMatcher`&#8203; Bot且不被顯示，這可能會有幫助。

`MatchActively`&#8203;設定必定會從我們的名單中下載Bot，如果您不願下載，請停用該設定。