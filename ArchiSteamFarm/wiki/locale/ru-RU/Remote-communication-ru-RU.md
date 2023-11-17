# Удаленная связь

Этот раздел посвящен удалённой связи (remote communication), которую включает в себя ASF, включая более подробное объяснение того, как это влияет на ASF. Хотя мы не считаем что-либо из приведенного ниже вредоносным или иным образом нежелательным, и мы не обязаны по закону раскрывать это, мы хотим, чтобы вы лучше понимали функциональные возможности программы, особенно в отношении вашей конфиденциальности и обмена данными.

## Steam

ASF взаимодействует с сетью Steam (**[CM серверов](https://api.steampowered.com/ISteamDirectory/GetCMList/v1?cellid=0)**), а также **[Steam API](https://steamcommunity.com/dev)**, **[Магазином Steam](https://store.steampowered.com)** и **[Steam Community](https://steamcommunity.com)**.

Невозможно отключить любое из перечисленных выше сообщений, так как это ядро ASF базируется на обеспечении его базовой функциональности. Вам нужно воздерживаться от использования ASF, если вы не довольны вышеуказанными условиями.

## Группа Steam

ASF связывается с нашей **[группой Steam](https://steamcommunity.com/groups/archiasf)**. Группа предоставляет вам объявления, в частности о новых версиях, критических проблемах, проблемах Steam и других вещах, которые важны участникам сообщества. Это также позволяет вам использовать нашу техническую поддержку, задавая вопросы, решая проблемы, сообщая о проблемах или предлагая улучшения. По умолчанию учетные записи, используемые в ASF, автоматически присоединяются к группе при входе в систему.

Вы можете отказаться от вступления в группу, отключив флаг `SteamGroup` в настройке **[`RemoteCommunication`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#remotecommunication)** бота.

## GitHub

ASF взаимодействует с **[GitHub API](https://api.github.com)**, чтобы получить **[новые релизы ASF](https://github.com/JustArchiNET/ArchiSteamFarm/releases)** для обновления функциональности. Это делается как при автообновлении (если вы оставляете **[`UpdatePeriod`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#updateperiod)** включеным), так и при использовании **[команды](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** `update`. Вы можете влиять на связь ASF с GitHub через свойство **[`UpdateChannel`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#updatechannel)** - установка на `None` приведет к полному отключению функций обновления, включая связь с GitHub в этом отношении.

## ASF сервер

ASF взаимодействует с **[нашим собственным сервером](https://asf.justarchi.net)** для более продвинутой функциональности. В частности, это включает:
- Проверка контрольных сумм сборок ASF, загруженных из GitHub, по нашей собственной независимой базе данных, чтобы убедиться, что все загруженные сборки являются оригинальными и легитимными(без вредоносного ПО, атаки MITM или других подделок).
- Получение списка "плохих ботов" для фильтрации, если настройка `FilterBadBots` в глобальной конфигурации осталась включена.
- Размещение вашего бота в **[наш список](https://asf.justarchi.net/STM)** если вы включили `SteamTradeMatcher` в **[`TradingPreferences`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#tradingpreferences)** и удовлетворяете другим критериям.
- Запрос доступных на данный момент ботов для торговли с **[нашего листинга](https://asf.justarchi.net/STM)** если вы включили `MatchActively` в **[`TradingPreferences`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#tradingpreferences)** и удовлетворяете другим критериям.

В качестве меры безопасности, отключить проверку контрольных сумм для сборок ASF невозможно. Тем не менее, вы можете полностью отключить автообновления, если вы хотите избежать этого, как описано выше в разделе GitHub.

Вы можете отключить настройку `FilterBadBots`, если вы хотите не получить список "плохих ботов" с сервера.

Вы можете отказаться от вступления в группу, отключив флаг `PublicListing` в настройке **[`RemoteCommunication`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#remotecommunication)** бота. Это может быть полезно, если вы хотите запустить `SteamTradeMatcher` бота без объявления.

Загрузка ботов из нашего списка является обязательным для настройки `MatchActively`, вам нужно отключить эту настройку, если вы не хотите с этим соглашаться.