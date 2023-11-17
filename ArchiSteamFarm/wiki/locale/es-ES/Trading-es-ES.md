# Intercambios

ASF incluye soporte para intercambios no interactivos (offline) de Steam. Tanto la recepción (aceptar/rechazar) como el envío de intercambios está disponible inmediatamente y no requiere una configuración especial, pero obviamente se requiere una cuenta de Steam sin restricciones (aquella que ya ha gastado 5$ en la tienda). El módulo de intercambios no está disponible para cuentas limitadas.

---

## Lógica

ASF siempre aceptará todos los intercambios, independientemente de los artículos, enviados por el usuario con acceso `Master` (o superior) al bot. Esto permite no solo recoger (loot) fácilmente los cromos recolectados por el bot, sino también administrar fácilmente los artículos que el bot almacena en el inventario - incluyendo los de otros juegos (como CS:GO).

ASF rechazará las ofertas de intercambio, independientemente del contenido, de cualquier usuario (no master) que esté bloqueado del módulo de intercambios. La lista negra se almacena en la base de datos estándar `BotName.db`, y puede ser administrada a través de los **[comandos](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commandses-ES)** `tb`, `tbadd` y `tbrm`. Esto debe servir como una alternativa al bloqueo de usuarios que ofrece Steam - usar con precaución.

ASF aceptará todos los intercambios de `loot` enviados entre bots, a menos que `DontAcceptBotTrades` se especifique en `TradingPreferences`. En resumen, `TradingPreferences` por defecto en `None` hará que ASF acepte automáticamente intercambios del usuario con acceso `Master` al bot (explicado arriba), así como todos los intercambios de donación de otros bots que formen parte del proceso de ASF. Si quieres deshabilitar los intercambios de donación de otros bots, entonces para eso es `DontAcceptBotTrades` en la propiedad `TradingPreferences`.

Cuando habilitas `AcceptDonations` en `TradingPreferences`, ASF también aceptará cualquier intercambio de donación - un intercambio en el que la cuenta bot no pierde ningún artículo. Esta propiedad solo afecta cuentas no bot, ya que las cuentas bot son afectadas por `DontAcceptBotTrades`. `AcceptDonations` te permite aceptar fácilmente donaciones de otras personas, y también de bots que no formen parte del proceso de ASF.

Es bueno notar que `AcceptDonations` no requiere **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authenticationes-ES)**, ya que no se necesita una confirmación si no estamos perdiendo ningún artículo.

También puedes personalizar aún más las capacidades de intercambio de ASF modificando `TradingPreferences` según lo deseado. Una de las características principales de `TradingPreferences` es la opción `SteamTradeMatcher` que hará que ASF use su lógica integrada para aceptar intercambios que te ayuden a completar insignias faltantes, lo que es especialmente útil en cooperación con la lista pública de **[SteamTradeMatcher](https://www.steamtradematcher.com)**, pero también puede funcionar sin ella. Se describe con detalle abajo.

---

## `SteamTradeMatcher`

Cuando `SteamTradeMatcher` está activo, ASF usará un algoritmo bastante complejo para comprobar si el intercambio pasa las reglas de STM y que al menos sea neutral para nosotros. La lógica es la siguiente:

- Rechaza el intercambio si estamos perdiendo algún tipo de artículo que no esté especificado en la propiedad `MatchableTypes`.
- Rechaza el intercambio si no estamos recibiendo al menos el mismo número de artículos por juego, por tipo y por rareza.
- Rechaza el intercambio si el usuario solicita cromos especiales de las ofertas de verano/invierno, y tiene una retención de intercambio.
- Rechaza el intercambio si la duración de la retención de intercambio excede lo establecido en la propiedad de configuración global `MaxTradeHoldDuration`.
- Rechaza el intercambio si no tenemos establecido `MatchEverything`, y es peor que neutral para nosotros.
- Acepta el intercambio si no lo rechazamos por alguno de los puntos anteriores.

Es agradable notar que ASF también soporta pagos en exceso - la lógica funcionará correctamente cuando el usuario añada algo adicional al intercambio, siempre y cuando se cumplan todas las condiciones anteriores.

Las primeras 4 condiciones de rechazo deberían ser obvias para todos. La última incluye una lógica para cromos duplicados que comprueba el estado actual de nuestro inventario y decide cuál es el estatus del intercambio.

- Un intercambio es **bueno** si nuestro progreso para completar el set avanza. Ejemplo: A A (antes) -> A B (después)
- Un intercambio es **neutral** si nuestro progreso para completar el set se mantiene intacto. Ejemplo: A B (antes) -> A C (después)
- Un intercambio es **malo** si nuestro progreso para completar el set retrocede. Ejemplo: A C (antes) -> A A (después)

STM solo opera con intercambios buenos, lo que significa que un usuario utilizando STM para emparejar duplicados siempre debería sugerirnos intercambios buenos. Sin embargo, ASF es liberal, y también acepta intercambios neutrales, porque en esos intercambios realmente no estamos perdiendo nada, así que no hay ninguna razón para rechazarlos. Esto es especialmente útil para tus amigos, ya que pueden cambiar tus cromos adicionales sin usar STM en absoluto, siempre y cuando no pierdas el progreso del set.

Por defecto ASF rechazará intercambios malos - como usuario, esto es lo que querrás casi siempre. Sin embargo, opcionalmente puedes habilitar `MatchEverything` en `TradingPreferences` para hacer que ASF acepte todos los intercambios de duplicados, incluyendo los **malos**. Esto es útil si deseas ejecutar un bot de intercambio 1:1 en tu cuenta, y por lo tanto debes entender que **ASF ya no te ayudará en el progreso para completar las insignias, y que podrías perder sets completos por N cantidad de duplicados del mismo cromo**. Si intencionalmente deseas ejecutar un bot de intercambio que **nunca** se supone que complete ningún set, y ofrezca su inventario a cualquier usuario interesado, puedes habilitar esa opción.

Independientemente de las `TradingPreferences` que hayas seleccionado, que un intercambio sea rechazado por ASF no significa que tú no puedas aceptarlo. Si dejaste el valor predeterminado de `BotBehaviour`, el cual no incluye `RejectInvalidTrades`, ASF simplemente ignorará esos intercambios - permitiéndote decidir si estás interesado en ellos o no. Lo mismo ocurre con los intercambios con artículos fuera de los incluidos en `MatchableTypes`, así como con todo lo demás - se supone que el módulo te ayude a automatizar los intercambios de STM, no decidir cuál es un intercambio bueno y cuál no. La única excepción a esta regla es cuando se trata de usuarios que pusiste en la lista negra del módulo de intercambios usando el comando `tbadd` - los intercambios de esos usuarios son rechazados inmediatamente, independientemente de la configuración de `BotBehaviour`.

Es altamente recomendable usar **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authenticationes-ES)** cuando habilitas esta opción, ya que esta función pierde todo su potencial si decides confirmar manualmente cada intercambio. `SteamTradeMatcher` funcionará correctamente incluso sin la capacidad de confirmar intercambios, pero puede generar un atraso en las confirmaciones si no las aceptas a tiempo.