# Comunicación remota

Esta sección explica la comunicación remota que ASF incorpora, incluyendo más información sobre cómo uno puede influenciarla. Si bien no consideramos nada de lo siguiente como malicioso o no deseado, ni estamos legalmente obligados a revelarlo, queremos que entiendas mejor la funcionalidad del programa, especialmente en lo que respecta a tu privacidad y los datos que se comparten.

## Steam

ASF se comunica con la red de Steam (**[servidores CM](https://api.steampowered.com/ISteamDirectory/GetCMList/v1?cellid=0)**), así como **[Steam API](https://steamcommunity.com/dev)**, **[la tienda de Steam](https://store.steampowered.com)** y **[la comunidad de Steam](https://steamcommunity.com)**.

No es posible desactivar ninguna de las comunicaciones mencionadas, ya que es lo principal en que ASF se basa para proporcionar su funcionalidad básica. Deberás abstenerte de usar ASF si no estás de acuerdo con lo anterior.

## Grupo de Steam

ASF se comunica con nuestro **[grupo de Steam](https://steamcommunity.com/groups/archiasf)**. El grupo te proporciona anuncios, especialmente de versiones nuevas, problemas críticos, problemas de Steam y otras cosas que son importantes para mantener actualizada a la comunidad. También te permite usar nuestro soporte técnico, haciendo preguntas, resolviendo problemas, reportando problemas o sugiriendo mejoras. Por defecto, las cuentas usadas en ASF se unirán automáticamente al grupo al iniciar sesión.

Puedes optar por no unirte al grupo desactivando la bandera `SteamGroup` en las opciones **[`RemoteCommunication`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-es-ES#remotecommunication)** del bot.

## GitHub

ASF se comunica con la **[API de GitHub](https://api.github.com)** para obtener las **[versiones de ASF](https://github.com/JustArchiNET/ArchiSteamFarm/releases)** para la funcionalidad de actualización. Esto se hace como parte de las actualizaciones automáticas (si dejaste **[`UpdatePeriod`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-es-ES#updateperiod)** habilitado), así como con el **[comando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-es-ES)** `update`. Puedes influir la comunicación de ASF con GitHub a través de la propiedad **[`UpdateChannel`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-es-ES#updatechannel)** - estableciéndola a `None` resultará en deshabilitar por completo la funcionalidad de actualización, incluyendo la comunicación con GitHub en este sentido.

## Servidor de ASF

ASF se comunica con **[nuestro servidor](https://asf.justarchi.net)** para funcionalidades avanzadas. En particular, esto incluye:
- Verificar las sumas de comprobación de las compilaciones de ASF descargadas de GitHub contra nuestra base de datos independiente para asegurar que todas las compilaciones descargadas sean legítimas (libres de malware, ataques de intermediario u otro tipo de manipulación)
- Obtener la lista de bots malos para filtrado si mantienes habilitado `FilterBadBots` en la configuración global.
- Anunciar tu bot en **[nuestra lista](https://asf.justarchi.net/STM)** si habilitaste `SteamTradeMatcher` en **[`TradingPreferences`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-es-ES#tradingpreferences)** y cumples con otros criterios.
- Descargar los bots disponibles para intercambiar de **[nuestra lista](https://asf.justarchi.net/STM)** si habilitaste `MatchActively` en **[`TradingPreferences`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-es-ES#tradingpreferences)** y cumples con otros criterios.

Como medida de seguridad, no es posible desactivar la suma de verificación para las compilaciones de ASF. Sin embargo, puedes desactivar las actualizaciones automáticas si deseas evitar esto, como se describió anteriormente en la sección GitHub.

Puedes deshabilitar el ajuste `FilterBadBots` si quieres evitar obtener la lista del servidor.

Puedes optar por no ser anunciado en la lista desactivando la bandera `PublicListing` en las opciones **[`RemoteCommunication`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-es-ES#remotecommunication)** del bot. Esto puede ser útil si quieres ejecutar un bot con `SteamTradeMatcher` pero sin ser anunciado en la lista.

Descargar los bots de nuestro listado es obligatorio para la opción `MatchActively`, necesitarás deshabilitar dicha opción si no deseas aceptar eso.