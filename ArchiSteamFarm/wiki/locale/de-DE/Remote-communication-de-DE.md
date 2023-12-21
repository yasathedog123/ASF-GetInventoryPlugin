# Telekommunikation

Dieser Abschnitt befasst sich mit der Drittanbieterkommunikation (die ASF beinhaltet), einschließlich weiterer Erklärungen, wie man sie beeinflussen kann. Während wir weiter unten nichts als böswillig oder anderweitig unerwünscht betrachten, sind wir auch nicht gesetzlich dazu verpflichtet, es offen zu legen. Wir möchten, dass Sie die Funktionalität des Programms besser verstehen, insbesondere in Bezug auf Ihre Privatsphäre und Daten, die weitergegeben werden.

## Steam

ASF kommuniziert mit dem Steam Netzwerk (**[CM Server](https://api.steampowered.com/ISteamDirectory/GetCMList/v1?cellid=0)**), sowie **[Steam API](https://steamcommunity.com/dev)**, **[Steam Store](https://store.steampowered.com)** und **[Steam Community](https://steamcommunity.com)**.

Es ist nicht möglich die oben genannte Kommunikation zu deaktivieren, da es das Grundgerüst ist, auf der ASF basiert, um seine grundlegende Funktionalität bereitzustellen. Sie müssen ASF nicht verwenden, wenn Sie mit dem oben genannten nicht zufrieden sind.

## Steam-Gruppe

ASF kommuniziert mit unserer **[Steam-Gruppe](https://steamcommunity.com/groups/archiasf)**. Die Gruppe bietet Ihnen Ankündigungen, insbesondere über neue Versionen, kritische Probleme, Steam-Probleme und andere Dinge, die wichtig sind, um die Community zu informieren. Es ermöglicht Ihnen zudem, unsere technische Unterstützung in Anspruch zu nehmen, indem Sie Fragen stellen, Probleme lösen, Probleme melden oder Verbesserungsvorschläge einbringen. Standardmäßig werden Konten, die in ASF verwendet werden, bei der Anmeldung automatisch der Gruppe hinzugefügt.

Sie können sich entscheiden, dem Gruppenbeitritt zu widerrufen, indem Sie die `SteamGroup`-Flag in der Bot-Einstellung **[`RemoteCommunication`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-de-DE#remotecommunication)** deaktivieren.

## GitHub

ASF kommuniziert mit **[GitHubs API](https://api.github.com)** um die **[ASF Veröffentlichungen](https://github.com/JustArchiNET/ArchiSteamFarm/releases)** für die Update-Funktionalität abzurufen. Dies geschieht als Teil des Auto-Updates (falls Sie **[`UpdatePeriod`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-de-DE#updateperiod)** aktiviert haben), sowie beim ****[Befehl](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-de-DE)** `update`. Sie können die Kommunikation von ASF mit GitHub durch die Variable **[`UpdateChannel`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#updatechannel)** beeinflussen - setzen Sie es auf `None` wird die gesamte Update-Funktionalität deaktivieren, einschließlich der Kommunikation mit GitHub in dieser Hinsicht.</p>

## ASFs Server

ASF kommuniziert mit **[unserem eigenen Server](https://asf.justarchi.net)** für eine erweiterte Funktionalität. Dies beinhaltet insbesondere:
- Überprüfen der Prüfsummen von ASF-Builds, die von GitHub heruntergeladen wurden, gegen unsere eigene unabhängige Datenbank, um sicherzustellen, dass alle heruntergeladenen Builds legitim sind (frei von Malware, MITM-Angriffe oder andere Manipulationen)
- Abrufen der Filterliste von schlechten Bots, wenn Sie die globale Konfigurationseinstellung `FilterBadBots` aktiviert haben.
- Ankündigung Ihres Bots in **[unserer Auflistung](https://asf.justarchi.net/STM)**, wenn Sie `SteamTradeMatcher` in den **[`TradingPreferences`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-de-DE#tradingpreferences)** (Handelseinstellungen) aktiviert haben und andere Kriterien erfüllen
- Aktuell verfügbare Bots zum Handel von **[unserer Auflistung](https://asf.justarchi.net/STM)** herunterladen, sofern Sie `MatchActively` in **[`TradingPreferences`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-de-DE#tradingpreferences)** aktiviert haben und andere Kriterien erfüllen

Als Sicherheitsmaßnahme ist es nicht möglich, die Überprüfung der Prüfsumme für ASF-Builds zu deaktivieren. Allerdings können Sie automatische Updates komplett deaktivieren, falls Sie dies vermeiden möchten, wie oben im GitHub Abschnitt beschrieben.

Sie können die Einstellung `FilterBadBots` deaktivieren, wenn Sie die Liste nicht vom Server abrufen wollen.

Sie können sich dagegen entscheiden, dass Sie in der Auflistung angekündigt werden, indem Sie `PublicListing` in der Bot-Einstellung **[`RemoteCommunication`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-de-DE#remotecommunication)** deaktivieren. Dies kann nützlich sein, wenn Sie einen `SteamTradeMatcher`-Bot ausführen möchten, ohne gleichzeitig angekündigt zu werden.

Das Herunterladen von Bots aus unserer Auflistung ist obligatorisch für die Einstellung `MatchActively`. Sie müssen diese Einstellung deaktivieren, wenn Sie damit nicht einverstanden sind.