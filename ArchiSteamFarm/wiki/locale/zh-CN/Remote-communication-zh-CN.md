# 远程通信

本章节描述 ASF 所包含的远程通信，以及进一步解释您如何改变其行为。 虽然我们不认为下文所述是恶意或者不需要的，我们在法律上也没有义务予以披露，但我们希望您能更好地理解程序功能，特别是在您的隐私和数据共享方面。

## Steam

ASF 会与 Steam 网络（**[CM 服务器](https://api.steampowered.com/ISteamDirectory/GetCMList/v1?cellid=0)**）、**[Steam API](https://steamcommunity.com/dev)**、[**Steam 商店**](https://store.steampowered.com)和 [**Steam 社区**](https://steamcommunity.com)通信。

禁用上述任何通信是不可能的，因为它是 ASF 提供一切基本功能的基础。 如果您不喜欢上述通信，则应该选择不使用 ASF。

## Steam 组

ASF 与我们的 [**Steam 组**](https://steamcommunity.com/groups/archiasf)通信。 群组可以为您发布公告，特别是新版本、紧急状况、Steam 问题以及其他对于保持社区更新非常重要的事项。 它还使您可以使用我们的技术支持，即提出问题、解决问题、报告问题或建议改进。 默认情况下，使用 ASF 的帐户会在登录时自动加入到群组。

您可以选择不加入群组，只需要在机器人的 **[`RemoteCommunication`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-zh-CN#remotecommunication)** 设置中关闭 `SteamGroup` flag。

## GitHub

ASF 与 **[GitHub 的 API](https://api.github.com)** 通信来获取 **[ASF Release](https://github.com/JustArchiNET/ArchiSteamFarm/releases)** 用于更新功能。 需要此通信的包括自动更新（如果您启用了 **[`UpdatePeriod`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-zh-CN#updateperiod)**），也包括 `update` **[命令](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-zh-CN)**。 您可以设置 **[`UpdateChannel`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-zh-CN#updatechannel)** 属性影响 ASF 与 GitHub 的通信——设置为 `None` 会完全禁用更新功能，因此也就禁用了与 GitHub 的通信。

## ASF 服务器

ASF 与[**我们的服务器**](https://asf.justarchi.net)通信提供进阶功能。 特别包括：
- 验证从 GitHub 下载的 ASF 构建符合我们独立数据库中的校验和，以确保所有下载的构建是安全的（不含恶意软件、中间人攻击或其他篡改）
- 如果您启用了 `FilterBadBots` 全局配置，则拉取恶意机器人列表用于过滤。
- 如果您在 **[`TradingPreferences`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-zh-CN#tradingpreferences)** 中启用了 `SteamTradeMatcher`，并满足我们的要求，则会在[**我们的列表**](https://asf.justarchi.net/STM)中展示您的机器人
- 如果您在 **[`TradingPreferences`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-zh-CN#tradingpreferences)** 中启用了 `MatchActively`，并满足我们的其他要求，则会从[**我们的列表**](https://asf.justarchi.net/STM)中下载当前可以交易的机器人

作为安全措施，您无法禁用 ASF 构建的校验和验证。  但是，如上文 GitHub 小节所述，如果您想避免此类通信，可以完全禁用自动更新。

如果您想避免从服务器获取列表，则可以禁用 `FilterBadBots` 设置。

您可以选择不在列表中展示，只需要在机器人的 **[`RemoteCommunication`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-zh-CN#remotecommunication)** 设置中关闭 `PublicListing` flag。 如果您想要运行 `SteamTradeMatcher` 机器人但不展示，就可以这样设置。

从我们的列表中下载机器人对于 `MatchActively` 是强制要求，您如果不愿意接受，就必须禁用其设置。