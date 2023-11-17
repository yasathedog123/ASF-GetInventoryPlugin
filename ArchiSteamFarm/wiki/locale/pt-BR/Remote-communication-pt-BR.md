# Comunicação remota

This section elaborates on remote communication that ASF includes, including further explanation on how one can influence it. While we don't consider anything below as malicious or otherwise unwanted, and neither we're legally obliged to disclose it, we want you to better understand the program functionality especially in regards to your privacy and data being shared.

## Steam

ASF communicates with Steam network (**[CM servers](https://api.steampowered.com/ISteamDirectory/GetCMList/v1?cellid=0)**), as well as **[Steam API](https://steamcommunity.com/dev)**, **[Steam store](https://store.steampowered.com)** and **[Steam community](https://steamcommunity.com)**.

It's not possible to disable any of the above communication, as it's the core foundation ASF is based on in order to provide its basic functionality. You'll need to refrain from using ASF if you're not comfortable with the above.

## Grupo Steam

ASF communicates with our **[Steam group](https://steamcommunity.com/groups/archiasf)**. The group provides you with announcements, especially new versions, critical issues, Steam problems and other things that are important to keep community updated. It also allows you to use our technical support, by asking questions, resolving problems, reporting issues or suggesting improvements. By default, accounts used in ASF will automatically join the group upon login.

You can decide to opt-out of joining the group by disabling `SteamGroup` flag in bot's **[`RemoteCommunication`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#remotecommunication)** settings.

## GitHub

ASF communicates with **[GitHub's API](https://api.github.com)** in order to fetch **[ASF releases](https://github.com/JustArchiNET/ArchiSteamFarm/releases)** for the update functionality. This is done as part of auto-updates (if you've kept **[`UpdatePeriod`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#updateperiod)** enabled), as well as `update` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. You can influence ASF's communication with GitHub through **[`UpdateChannel`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#updatechannel)** property - setting it to `None` will result in disabling entire update functionality, including GitHub communication in this regard.

## ASF's server

ASF communicates with **[our own server](https://asf.justarchi.net)** for more advanced functionality. In particular, this includes:
- Verifying checksums of ASF builds downloaded from GitHub against our own independent database to ensure that all downloaded builds are legitimate (free of malware, MITM attacks or other tampering)
- Fetching list of bad bots for filtering if you've kept `FilterBadBots` global config setting enabled.
- Anunciando seu bot em **[nossa listagem](https://asf.justarchi.net/STM)** se você tiver habilitado `SteamTradeMatcher` em **[`TradingPreferences`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#tradingpreferences)** e que atenda aos outros critérios
- Baixando bots disponíveis para troca da **[nossa listagem](https://asf.justarchi.net/STM)** se você tiver habilitado `MatchActively` em **[`TradingPreferences`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#tradingpreferences)** e que atenda aos outros critérios

As a security measure, it's not possible to disable checksum verification for ASF builds. However, you can disable auto-updates entirely if you'd like to avoid this, as described above in the GitHub section.

You can disable `FilterBadBots` setting if you want to avoid fetching the list from the server.

You can decide to opt-out of being announced in the listing by disabling `PublicListing` flag in bot's **[`RemoteCommunication`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#remotecommunication)** settings. This might be useful if you'd like to run `SteamTradeMatcher` bot without being announced at the same time.

Downloading bots from our listing is mandatory for `MatchActively` setting, you'll need to disable that setting if you're unwilling to accept that.