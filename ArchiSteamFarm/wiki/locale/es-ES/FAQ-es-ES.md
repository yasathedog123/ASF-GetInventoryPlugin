# Preguntas frecuentes

Nuestras preguntas frecuentes básicas cubren preguntas estándar y sus posibles respuestas. Para asuntos menos comunes, por favor visita nuestras **[preguntas frecuentes adicionales](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Extended-FAQ-es-ES)**.

# Tabla de contenido

* [General](#general)
* [Comparación con herramientas similares](#comparación-con-herramientas-similares)
* [Seguridad / Privacidad / VAC / Bans / Términos de Servicio](#seguridad--privacidad--vac--bans--términos-de-servicio)
* [Otros](#otros)
* [Problemas](#problemas)

---

## General

### ¿Qué es ASF?
### ¿Por qué el programa indica que no hay nada para recolectar en mi cuenta?
### ¿Por qué ASF no detecta todos mis juegos?
### ¿Por qué mi cuenta está limitada?

Antes de intentar entender lo que es ASF, debes asegurarte de que entiendes lo que son los cromos de Steam, y cómo obtenerlos, lo que se describe bastante bien en las preguntas frecuentes oficiales **[aquí](https://steamcommunity.com/tradingcards/faq)**.

En resumen, los cromos de Steam son artículos coleccionables para los que eres elegible cuando tienes un juego en particular, y pueden ser usados para fabricar insignias, venderlos en el mercado de Steam o cualquier otro propósito de tu elección.

Los puntos principales se repiten aquí, porque las personas generalmente no quieren aceptarlos y prefieren pretender que no existen:

- **Necesitas poseer el juego en tu cuenta de Steam para poder obtener cromos de él. El préstamo familiar no cuenta.**
- **No puedes recolectar el juego infinitamente, cada juego tiene un número fijo de cromos a obtener. Una vez que obtienes todos (alrededor de la mitad del set completo), el juego ya no es candidato para recolección. No importa si has vendido, intercambiado, fabricado u olvidado lo que ocurrió con los cromos que obtuviste, una vez que te quedas sin cromos obtenibles, el juego se acabó.**
- **No puedes obtener cromos de juegos F2P sin gastar dinero en ellos. Esto significa juegos permanentemente F2P como Team Fortress 2 o Dota 2. Poseer juegos F2P no te otorga cromos obtenibles.**
- **No puedes obtener cromos en [cuentas limitadas](https://help.steampowered.com/es/faqs/view/71D3-35C2-AD96-AA3A), independientemente de los juegos poseídos. Antes era posible, para ya no es el caso.**
- **Los juegos de paga que obtengas gratis durante una promoción no pueden ser recolectados para obtener cromos, independientemente de lo que se muestre en la página de la tienda. Antes era posible, para ya no es el caso.**

Como puedes ver, los cromos de Steam te son otorgados por jugar un juego que compraste, o un juego F2P en el que has gastado dinero. Si juegas dicho juego lo suficiente, todos los cromos terminarán apareciendo en tu inventario, haciendo posible que completes una insignia (después de obtener la mitad restante del set), los vendas, o hagas lo que quieras.

Ahora que hemos explicado los fundamentos de Steam, podemos explicar ASF. El programa en sí es bastante complejo para entenderlo completamente, así que en lugar de explicar todos los detalles técnicos, a continuación te ofrecemos una explicación simplificada.

ASF inicia sesión en tu cuenta de Steam a través de nuestro cliente de Steam integrado usando las credenciales que proporciones. Después de iniciar sesión con éxito, analiza tus **[insignias](https://steamcommunity.com/my/badges)** para encontrar juegos que estén disponibles para recolección (`X` cromos obtenibles restantes). Después de analizar todas las páginas y construir una lista final de todos los juegos disponibles, ASF elige el algoritmo de recolección más eficiente y empieza el proceso. El proceso depende del **[algoritmo de recolección de cromos](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance-es-ES)** seleccionado pero normalmente consiste en jugar un juego elegible y comprobar periódicamente (además de en cada obtención de artículos) si el juego ya fue completamente recolectado - si es así, ASF puede proceder con el siguiente título, usando el mismo procedimiento, hasta que todos los juegos hayan sido recolectados.

Ten en cuenta que la explicación anterior está simplificada y no describe una docena de características adicionales y funciones que ASF ofrece. Visita el resto de **[nuestra wiki](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Home-es-ES)** si quieres conocer cada detalle de ASF. Intenté hacerla lo más sencillo posible de entender para todos, sin incluir detalles técnicos - animamos a los usuarios avanzados a profundizar.

Ahora como programa - ASF ofrece algo de magia. Primero, no tiene que descargar ninguno de los archivos de tus juegos, puede jugarlos inmediatamente. Segundo, es totalmente independiente de tu cliente de Steam normal - no necesitas ejecutar el cliente de Steam o siquiera instalarlo. Tercero, es una solución automatizada - lo que significa que ASF automáticamente hace todo por ti, sin necesidad de decirle qué hacer - lo que te ahorra problemas y tiempo. Por último, no tiene que engañar a la red de Steam con un proceso de emulación (como el que usa Idle Master), ya que puede comunicarse directamente con ella. Además es superrápido y ligero, siendo una increíble solución para todos los que deseen obtener cromos fácilmente sin mucha molestia - es especialmente útil al dejarlo abierto en segundo plano mientras hacemos algo más, o incluso jugando en modo desconectado.

Todo lo anterior es bueno, pero ASF también tiene limitaciones técnicas que son impuestas por Steam - no podemos recolectar juegos que no poseas, no podemos recolectar juegos por siempre para obtener cromos adicionales una vez alcanzado el límite impuesto, y no podemos recolectar juegos mientras estás jugando. Todo eso debería ser "lógico", considerando la forma en que funciona ASF, pero es bueno notar que ASF no tiene superpoderes y no hará algo que es físicamente imposible, así que ten eso en cuenta - es básicamente lo mismo que si le dijeras a alguien más que inicie sesión en tu cuenta desde otra PC y recolecte juegos por ti.

Para resumir - ASF es un programa que te ayuda a obtener aquellos cromos para los que eres elegible, sin mucho problema. También ofrece varias funciones más, pero nos quedaremos con esta por ahora.

---

### ¿Tengo de introducir las credenciales de mi cuenta?

**Sí**. ASF requiere las credenciales de tu cuenta del mismo modo que el cliente oficial de Steam, ya que usa el mismo método para interactuar con la red de Steam. Sin embargo, esto no significa que tengas que introducir las credenciales de tu cuenta en las configuraciones de ASF, puedes seguir usando ASF con `SteamLogin` y/o `SteamPassword` en `null`/vacío, e introducir esos datos cada vez que ejecutes ASF, cuando sea requerido (así como otras credenciales de inicio de sesión, consulta la configuración). De esta manera tus datos no se guardan en ningún lugar, pero obviamente ASF no puede iniciar automáticamente sin tu ayuda. ASF también ofrece otras formas de aumentar tu **[seguridad](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security-es-ES)**, así que siéntete libre de leer esa parte de la wiki si eres un usuario avanzado. Si no lo eres, y no quieres poner las credenciales de tu cuenta en la configuración de ASF, entonces simplemente no lo hagas, en cambio introdúcelas cuando ASF lo solicite.

Ten en cuenta que la herramienta ASF es para tu uso personal y las credenciales nunca salen de tu computadora. Tampoco las estás compartiendo con nadie, lo que cumple con los **[Términos de Servicio de Steam](https://store.steampowered.com/subscriber_agreement/spanish/)** - algo muy importante que mucha gente olvida. No estás enviando tus datos a nuestros servidores o a terceros, solo directamente a los servidores de Steam operados por Valve. No conocemos tus credenciales y tampoco podemos recuperarlas por ti, independientemente de si las pones en tus configuraciones o no.

---

### ¿Cuánto tiempo tengo que esperar para recibir cromos?

**El tiempo que sea necesario** - en serio. Cada juego tiene una dificultad de recolección diferente establecida por el desarrollador/editor, y depende completamente de ellos qué tan rápido se obtienen los cromos. La mayoría de los juegos sueltan 1 cromo por cada 30 minutos de juego, pero también hay juegos que requieren que juegues incluso varias horas antes de soltar un cromo. Además, tu cuenta podría estar restringida para recibir cromos de juegos que aún no has jugado el tiempo suficiente, como se indica en la sección de **[rendimiento](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance-es-ES)**. No intentes adivinar por cuánto tiempo ASF debe recolectar un juego determinado - no depende de ti, ni de ASF decidirlo. No puedes hacer nada para volverlo más rápido, y no hay ningún "bug" relacionado con que los cromos no sean obtenidos de manera oportuna - no controlas el proceso de obtención de cromos, ni tampoco ASF. En el mejor de los casos, recibirás un promedio de 1 cromo por cada 30 minutos. En el peor caso, no recibirás ningún cromo incluso por 4 horas desde que inicie ASF. Ambas situaciones son normales y están cubiertas en nuestra sección de **[rendimiento](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance-es-ES)**.

---

### La recolección tarda demasiado, ¿puedo acelerarla de alguna manera?

Lo único que afecta fuertemente la velocidad de recolección es el **[algoritmo de recolección de cromos](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance-es-ES)** seleccionado para tu instancia de bot. Todo lo demás tiene un efecto insignificante y no hará la recolección más rápida, mientras que algunas acciones tal como iniciar el proceso de ASF varias veces incluso **lo hará peor**. Si realmente necesitas aprovechar cada segundo del proceso de recolección, entonces ASF te permite ajustar algunas variables de recolección tal como `FarmingDelay` - todas se explican en la **[configuración](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-es-ES)**. Sin embargo, como dije, el efecto es insignificante, y elegir el algoritmo de recolección de cromos adecuado para una cuenta determinada es la única decisión crucial que puede afectar fuertemente la velocidad de recolección, todo lo demás es puramente cosmético. En lugar de preocuparte por la velocidad de recolección, solo ejecuta ASF y déjalo hacer su trabajo - puedo asegurarte que lo está haciendo de la manera más eficiente posible. Cuanto menos te preocupes, más satisfecho estarás.

---

### ¡Pero ASF dijo que la recolección tomaría aproximadamente X tiempo!

ASF te da una aproximación basado en el número de cromos que necesitas obtener, y tu algoritmo seleccionado - esto no está nada cerca del tiempo real que pasarás recolectando, que usualmente es más que esto, ya que ASF solo asume el mejor de los casos, e ignora todos los caprichos de la Red de Steam, desconexiones de Internet, sobrecarga de los servidores de Steam y demás. Debe ser visto solo como un indicador general de cuánto puedes esperar que ASF esté recolectando, a menudo en el mejor casos, ya que el tiempo real difiere, de manera significativa en algunos casos. Como se dijo anteriormente, no intentes adivinar por cuánto tiempo un juego determinado será recolectado, no depende de ti, ni de ASF decidirlo.

---

### ¿ASF puede funcionar en mi android/smartphone?

ASF es un programa C# que requiere la implementación de .NET. Android se convirtió en una plataforma válida a partir de .NET 6.0, sin embargo, actualmente hay un gran obstáculo para que ASF llegue a Android debido a la **[falta de ASP.NET runtime disponible en este](https://github.com/dotnet/aspnetcore/issues/35077)**. Aunque no hay una opción nativa disponible, hay compilaciones funcionales para GNU/Linux en arquitectura ARM, así que es totalmente posible usar algo como **[Linux Deploy](https://play.google.com/store/apps/details?id=ru.meefik.linuxdeploy)** para instalar Linux, y luego usar  ASF en dicho chroot Linux.

Cuando/Si todos los requisitos de ASF se cumplan, consideraremos publicar una compilación oficial para Android.

---

### ¿ASF puede recolectar artículos de juegos de Steam, como CS:GO o Unturned?

**No**, esto va en contra de los **[Términos de Servicio de Steam](https://store.steampowered.com/subscriber_agreement/spanish/)** y Valve expresó eso claramente con la última ola de bans por recolectar artículos de TF2. ASF es un programa de recolección de cromos, no un recolector de artículos de juegos - no tiene ninguna capacidad para recolectar artículos de juegos, y no se planea añadir tal característica en el futuro, nunca, principalmente porque viola los términos de servicio de Steam. Por favor, no preguntes al respecto - lo mejor que obtendrás es un reporte de algún usuario ofendido y tú teniendo problemas. Lo mismo sucede para todos lo demás tipos de recolección, como la recolección de las transmisiones de CS:GO. ASF se enfoca exclusivamente en los cromos de Steam.

---

### ¿Puedo elegir qué juegos deben ser recolectados?

**Sí**, a través de diferentes formas. Si quieres modificar el orden por defecto de la cola de recolección, para eso se puede usar la **[propiedad de configuración del bot](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-es-ES#configuraci%C3%B3n-de-bot)** `FarmingOrders`. Si quieres bloquear manualmente ciertos juegos de ser recolectados automáticamente, puedes usar la lista negra de recolección que está disponible con el **[comando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-es-ES)** `fb`. Si quieres recolectar todo pero darle prioridad a algunos juegos, para eso se puede usar la cola de prioridad de recolección, disponible con el **[comando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-es-ES)** `fq`. Y finalmente, si solo quieres recolectar juegos de tu elección, para lograrlo puedes usar la **[propiedad de configuración del bot](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-es-ES#configuraci%C3%B3n-de-bot)** `FarmPriorityQueueOnly`, juntamente con añadir tus juegos seleccionados a la cola de prioridad de recolección.

Además de administrar el módulo automático de recolección de cromos, que fue descrito arriba, también puedes cambiar ASF al modo de recolección manual con el **[comando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-es-ES)** `play`, o usar algún otro ajuste externo como la **[propiedad de configuración del bot](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-es-ES#configuraci%C3%B3n-de-bot)** `GamesPlayedWhileIdle`.

---

### No me interesa obtener cromos, en su lugar me gustaría aumentar mis horas de juego, ¿es posible?

Sí, ASF te permite hacerlo de varias maneras.

La mejor forma de lograrlo es usando la propiedad de configuración **[`GamesPlayedWhileIdle`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-es-ES#gamesplayedwhileidle)**, lo que hará que se jueguen las appIDs seleccionadas cuando ASF no tenga cromos para recolectar. Si quieres jugar tus juegos todo el tiempo, incluso si tienes cromos para obtener de otros juegos, entonces puedes combinarlo con **[`FarmPriorityQueueOnly`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-es-ES#farmpriorityqueueonly)**, así ASF solo recolectará cromos de aquellos juegos que establezcas explícitamente, o **[`Paused`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-es-ES#paused)**, lo que causará que el módulo de recolección de cromos esté pausado hasta que le quites la pausa.

Alternativamente, puedes usar el comando **[`play`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-es-ES#comandos-1)**, lo que causará que ASF juegue los juegos seleccionados. Sin embargo, ten en cuenta que `play` solo debe utilizarse para juegos que quieras jugar temporalmente, ya que no es un estado persistente, causando que ASF regrese al estado predeterminado, por ejemplo, tras una desconexión de la red de Steam. Por lo tanto, recomendamos que uses `GamesPlayedWhileIdle`, a menos que realmente quieras iniciar tus juegos seleccionados por un corto período de tiempo, y luego volver al flujo normal.

---

### Soy usuario de Linux / macOS  ¿ASF recolectará juegos que no están disponibles para mi sistema operativo? ¿ASF recolectará juegos de 64 bits cuanto lo estoy ejecutando en un sistema operativo de 32 bits?

Sí, ASF ni siquiera se molesta en descargar archivos de los juegos, así que funcionará con todas las licencias vinculadas a tu cuenta de Steam, independientemente de la plataforma o los requerimientos técnicos. También debería funcionar con juegos vinculados a una región específica (juegos con bloqueo regional) incluso si no estás en la región correspondiente, aunque no garantizamos eso (funcionó la última vez que lo intentamos).

---

## Comparación con herramientas similares

---

### ¿ASF es similar a Idle Master?

La única similitud es el propósito general de ambos programas, el cual es recolectar juegos de Steam para obtener cromos. Todo lo demás, incluyendo el método de recolección, la estructura del programa, funcionalidad, compatibilidad, algoritmos usados, especialmente el código fuente en sí mismo, es totalmente diferente y esos dos programas no tienen nada en común entre sí, ni siquiera la base fundamental - IM se ejecuta en .NET Framework, ASF en .NET (Core). ASF fue creado para resolver problemas de IM que no era posible solucionar con una simple edición de código - por eso ASF fue escrito desde cero, sin usar una sola línea de código o incluso la idea general de IM, porque ese código y esas ideas eran totalmente erróneas para empezar. IM y ASF son como Windows y Linux - ambos son sistemas operativos y ambos pueden ser instalados en tu PC, pero no comparten casi nada entre sí, además de tener un propósito similar.

Por eso no deberías comparar ASF con IM basado en las expectativas de IM. Debes tratar ASF e IM como programas totalmente independientes con su propio conjunto de características. Algunas de esas características se sobreponen y puedes encontrar una característica particular en ambos, pero muy raramente, puesto que ASF cumple su propósito con un enfoque totalmente diferente en comparación con IM.

---

### ¿Vale la pena usar ASF, si actualmente estoy usando Idle Master y funciona bien para mí?

**Sí**. ASF es mucho más confiable e incluye funciones integradas que son **cruciales** independientemente de la forma en que recolectes, que IM simplemente no ofrece.

ASF tiene la lógica adecuada para **juegos no lanzados** - IM intentará recolectar juegos que tienen cromos, incluso si todavía no han sido lanzados. Por supuesto, no es posible recolectar esos juegos hasta la fecha de salida, así que tu proceso de recolección estará atascado. Esto requerirá que lo añadas a la lista negra, esperes su salida, o lo omitas manualmente. Ninguna de esas soluciones es buena, y todas ellas requieren tu atención - ASF omite automáticamente la recolección de juegos que no han sido lanzados (temporalmente), y regresa a ellos posteriormente cuando son lanzados, evitando completamente el problema y tratando con ello de manera eficiente.

ASF también tiene la lógica adecuada para **series** de video. Hay varios videos en Steam que tienen cromos, pero se anuncian con una `appID` errónea en la página de insignias, tal como **[Double Fine Adventure](https://store.steampowered.com/app/402590)** - IM falsamente recolectará la `appID` equivocada, lo que no otorgará ningún cromo y el proceso estará atascado. Una vez más, necesitarás añadirlo a la lista negra u omitirlo manualmente, y ambas requieren tu atención. ASF descubre automáticamente la `appID` correcta, lo que sí resulta en la obtención de cromos.

Además de eso, ASF **es mucho más estable y confiable** cuando se trata de problemas de red y las peculiaridades de Steam - funciona la mayoría del tiempo y no requiere tu atención una vez configurado, mientras que IM a menudo falla para muchas personas, requiere soluciones adicionales o simplemente no funciona. También es totalmente dependiente de tu cliente de Steam, lo que significa que no puede funcionar cuando tu cliente de Steam está teniendo problemas. ASF funciona correctamente mientras se pueda conectar a la red de Steam, y no quiere que el cliente de Steam esté en ejecución o siquiera que esté instalado.

Esos son 3 puntos **muy importantes** por los que deberías considerar usar ASF, ya que afectan directamente a todos los que recolectan cromos de Steam y no hay forma de que digan "esto no aplica para mí", ya que los mantenimientos de Steam y sus peculiaridades son cosas que les pasan a todos. Hay una docena de razones menos y más importantes de las que puedes aprender en el resto de preguntas frecuentes. Dicho brevemente, **sí**, deberías usar ASF incluso si no necesitas ninguna característica adicional que esté disponible en comparación con IM.

Además, IM está oficialmente descontinuado y puede dejar de funcionar completamente en el futuro, sin nadie que se preocupe por arreglarlo, considerando que existen soluciones mucho más potentes (no solo ASF). IM ya no funciona para muchas personas, y ese número solo está subiendo, no bajando. Debes evitar el uso de software obsoleto en primer lugar, no solo IM sino también todos los programas descontinuados. Ningún mantenedor activo significa que a nadie le importa si funciona o no, y **nadie es responsable por su funcionalidad**, lo que es un asunto crucial en términos de seguridad. Es suficiente con que haya un error crítico que cause problemas en la infraestructura de Steam - sin nadie que lo corrija, Steam puede emitir otra ola de baneos que te afectará sin siquiera ser consciente de que esto sea un problema, como ya le ha ocurrido a personas usando, adivina qué, una versión obsoleta de ASF.

---

### ¿Qué características interesantes ofrece ASF que Idle Master no tenga?

Depende de lo que consideres "interesante" para ti. Si planeas recolectar más de una cuenta entonces la respuesta ya es obvia, ya que ASF te permite recolectar todas ellas con una solución superior, ahorrando recursos, molestias, y problemas de compatibilidad. Sin embargo, si estás haciendo esa pregunta lo más probable es que no tengas esta necesidad particular, así que vamos a evaluar otros beneficios que aplican a una sola cuenta usada en ASF.

Primero y más importante, tienes algunas características integradas mencionadas **[arriba](#vale-la-pena-usar-asf-si-actualmente-estoy-usando-idle-master-y-funciona-bien-para-mí)** que son fundamentales para la recolección independientemente de tu objetivo final, y muy a menudo solo eso ya es suficiente para que consideres usar ASF. Pero ya sabes eso, así que vamos a pasar a algunas características más interesantes:

- **Puedes recolectar desconectado** (`OnlineStatus` establecido en `Offline`). Recolectar desconectado hace posible omitir completamente el estatus de juego, lo que permite recolectar con ASF mientras se muestra "En Línea" en Steam al mismo tiempo, sin que tus amigos noten siquiera que ASF está jugando por ti. Esta es una característica superior, ya que te permite permanecer en línea en tu cliente de Steam, sin molestar a tus amigos con cambios constantes de juego, o confundirlos haciéndoles creer que estás jugando cuando en realidad no es así. Este punto por sí solo hace que valga la pena usar ASF si respetas a tus amigos, pero solo es el principio. También es agradable notar que esta característica no tiene nada que ver con la configuración de privacidad de Steam - si ejecutas el juego tú mismo, entonces te mostrarás correctamente como jugando para tus amigos, haciendo invisible la parte de ASF y sin afectar tu cuenta en absoluto.

- **Puedes omitir juegos reembolsables** (función `SkipRefundableGames`). ASF tiene una lógica integrada para juegos reembolsables y puedes configurar ASF para no recolectarlos automáticamente. Esto te permite evaluar por ti mismo si tu juego recién comprado en la tienda de Steam valía tu dinero, sin que ASF trate de recolectar cromos de él lo antes posible. Si juegas por más de dos horas, o pasan 2 semanas desde la compra, entonces ASF procederá a recolectar ese juego dado que ya no es reembolsable. Hasta entonces tienes control total si lo disfrutas o no y lo puedes reembolsar fácilmente si es necesario, sin tener que añadirlo manualmente a la lista negra o no usar ASF durante ese tiempo.

- **Puedes marcar automáticamente nuevos artículos como recibidos** (función `BotBehaviour` de `DismissInventoryNotifications`). Recolectar con ASF tendrá como resultado que recibas nuevos cromos. Ya sabes que esto va a suceder, así que deja que ASF descarte esa notificación inútil por ti, asegurando que solo cosas importantes llamen tu atención. Por supuesto, solo si quieres.

- **Puedes obtener cromos de los eventos de Steam automáticamente ** (función `AutoSteamSaleEvent`). ASF te permite automatizar la lista de descubrimiento durante las rebajas de Steam, por supuesto solo si quieres hacer uso de eso. Esto ahorra mucho tiempo cada día mientras duran las ofertas de Steam, y asegura que no volverás a perder tus cromos diarios.

- **Puedes personalizar el orden de recolección con más opciones disponibles** (función `FarmingOrders`). ¿Tal vez quieres recolectar primero tus juegos recién comprados? ¿O los más antiguos? ¿De acuerdo al número de cromos obtenibles? ¿Por el nivel de insignia que ya fabricaste? ¿Horas jugadas? ¿Alfabéticamente? ¿De acuerdo a las AppIDs? ¿O tal vez en orden completamente aleatorio? Eso es completamente tu decisión.

- **ASF puede ayudarte a completar tus sets** (función `TradingPreferences` con `SteamTradeMatcher`). Con un poco de configuración avanzada, puedes convertir ASF en un bot que automáticamente aceptará ofertas de **[STM](https://www.steamtradematcher.com)**, ayudándote cada día a emparejar tus sets sin ninguna interacción de usuario. ASF también incluye su propio módulo ASF 2FA que te permite importar tu autenticador móvil de Steam y te deja automatizar todo el proceso de aceptar confirmaciones. O, ¿tal vez quieras aceptar manualmente y dejar que ASF solo prepare esos intercambios por ti? Eso, una vez más, depende completamente de ti.

- **ASF puede activar claves en segundo plano** (función **[activador de juegos en segundo plano](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer-es-ES)**). Quizá tengas cientos de claves de varios bundles que no tienes ganas de activar tú mismo, pasar por un montón de ventanas y aceptar los términos y condiciones de Steam una y otra vez. ¿Por qué no copiar y pegar tu lista de claves en ASF y dejar que haga su trabajo? ASF automáticamente activará todas esas claves en segundo plano, proporcionando un informe para hacerte saber en qué resultó cada intento de activación. Además, si tienes cientos de claves, está garantizado que tarde o temprano excederás el límite de intentos permitidos, y ASF también toma en cuenta eso, esperará pacientemente a que el bloqueo termine, y reanudará donde se quedó.

Podríamos seguir y seguir con toda la **[wiki de ASF](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Home-es-ES)**, señalando cada característica del programa, pero tenemos que trazar una línea en alguna parte. Eso es todo, esta es una lista de características que puedes disfrutar como usuario de ASF, donde solo una de ellas fácilmente podría ser una gran razón para nunca mirar atrás, y mencionamos **muchas** de ellas, con aún más sobre las que puedes aprender en el resto de nuestra wiki. Ah, sí, y ni siquiera entramos en detalles con cosas como la API de ASF que te permite escribir tus propios comandos, o una impresionante gestión de bots, ya que lo queríamos mantener simple.

---

### ¿ASF es más rápido de Idle Master?

**Sí**, aunque la explicación es bastante complicada.

En cada nuevo proceso generado y finalizado en tu sistema, el cliente de Steam automáticamente envía una solicitud que contiene todos los juegos que estás jugando actualmente - así la red de Steam puede calcular las horas y soltar cromos. Sin embargo, la red de Steam cuenta tu tiempo de juego en intervalos de 1 segundo, y enviar una nueva solicitud restablece el estado actual. En otras palabras, si generas/finalizas un nuevo proceso cada 0.5 segundos, nunca obtendrás cromos porque cada 0.5 segundos el cliente de Steam enviaría una nueva solicitud y la red de Steam nunca contaría ni siquiera 1 segundo de tiempo jugado. Además, por cómo funciona el sistema operativo, es bastante común ver nuevos procesos generados/finalizados sin que hagas nada, así que incluso si no estás haciendo nada en tu PC - hay muchos procesos funcionando en segundo plano, generando/finalizando otros procesos todo el tiempo. Idle Master está basado en el cliente de Steam, por lo que este mecanismo te afecta si lo usas.

ASF no está basado en el cliente de Steam, tiene su propia implementación del cliente de Steam. Gracias a eso, lo que ASF hace, no es generar un proceso, sino enviar una solicitud real a la red de Steam de que hemos empezado a jugar un juego. Esta es la misma solicitud que sería enviada por el cliente de Steam, pero como tenemos el control sobre el cliente de Steam de ASF, no necesitamos crear nuevos procesos, y no estamos imitando al cliente de Steam en lo que se refiere al envío de solicitudes en cada cambio de proceso, por lo que el mecanismo explicado arriba no nos afecta. Gracias a eso, nunca interrumpimos ese intervalo de 1 segundo en el lado de la red de Steam, y eso mejora nuestra velocidad de recolección.

---

### ¿Pero la diferencia es realmente notable?

No. Las interrupciones que ocurren con el cliente normal de Steam e Idle Master tienen un efecto mínimo en la obtención de cromos, por lo que no es ninguna diferencia notable que haga superior a ASF.

Sin embargo, **sí hay** una diferencia, y puedes notar claramente que, dependiendo de qué tan ocupado esté tu sistema operativo, los cromos se **obtendrán** más rápido, desde unos segundos hasta incluso unos minutos, en el peor de los casos. Aunque yo no consideraría usar ASF solo porque obtiene cromos más rápido, ya que tanto ASF como Idle Master son afectados por cómo funciona la web de Steam, ASF solo interactúa con la web de Steam de forma más eficaz, mientras que Idle Master no puede controlar lo que hace el cliente de Steam (así que no es culpa de Idle Master, sino del cliente de Steam en sí).

---

### ¿ASF puede recolectar múltiples juegos a la vez?

**Sí**, aunque ASF sabe mejor cuándo usar esa función, basado en el **[algoritmo de recolección de cromos](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance-es-ES)** seleccionado. La tasa de obtención de cromos cuando se recolectan múltiples juegos es cercana a cero, por esto ASF solo recolecta múltiples juegos para aumentar el tiempo de juego hasta superar el valor de `HoursUntilCardDrops` más rápido, con un máximo de `32` juegos al mismo tiempo. Esta es otra razón por la que debes enfocarte en la configuración de ASF, y dejar que los algoritmos decidan cuál es la mejor forma de lograr el objetivo - lo que creas que es correcto, no lo es necesariamente en la realidad, recolectar múltiples juegos a la vez no dará ningún cromo.

---

### ¿ASF puede cambiar rápidamente entre juegos?

**No**, ASF no soporta, ni promueve el uso de los **[glitches de Steam](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance-es-ES#glitches-de-steam)**.

---

### ¿ASF puede recolectar cada juego por X horas antes de que los cromos sean añadidos?

**No**, el objetivo de los cambios en el sistema de cromos de Steam fue combatir las falsas estadísticas y los jugadores fantasma. ASF no contribuirá a eso más de lo necesario, añadir esta característica no está planeado y no sucederá. Si tu juego recibe cromos de la forma usual, ASF lo recolectará lo antes posible.

---

### ¿Puedo jugar mientras ASF está recolectando?

**No**. ASF a diferencia de IM tiene incluido un cliente de Steam independiente, y la red de Steam solo permite jugar en **un cliente de Steam a la vez**. Sin embargo, puedes desconectar ASF siempre que quieras iniciando un juego (y haciendo clic en "Aceptar" cuando se te pregunta si la red de Steam debe desconectar el otro cliente) - ASF esperará pacientemente hasta que termines de jugar, y reanudará el proceso posteriormente. Alternativamente, puedes jugar en modo desconectado siempre que quieras, si con eso estás satisfecho.

Ten en cuenta que la tasa de obtención de cromos al jugar múltiples juegos es cercana a 0, por lo tanto no hay beneficios directos al poder hacer eso con IM, mientras que hay grandes beneficios de no interferir con otros juegos ejecutados con ASF, lo que es crucial, por ejemplo, en relación al VAC.

---

## Seguridad / Privacidad / VAC / Bans / Términos de Servicio

---

### ¿Puedo obtener VAC ban por usar esto?

No, no es posible porque ASF (a diferencia de Idle Master o SAM) no interfiere de ninguna manera con el cliente de Steam ni sus procesos. Es físicamente imposible obtener ban VAC por usar ASF, incluso si juegas en servidores seguros mientras ASF se está ejecutando - esto es porque **ASF ni siquiera requiere que el Cliente de Steam esté instalado** para funcionar correctamente. ASF es el único programa de recolección que actualmente garantiza ser libre de VAC.

---

### ¿Usar ASF puede evitar que juegue en servidores asegurados por VAC, como se indica **[aquí](https://help.steampowered.com/faqs/view/22C0-03D0-AE4B-04E8)**?

ASF no requiere que el cliente de Steam esté en ejecución o siquiera que esté instalado. De acuerdo a este concepto, **no** debería causar ningún problema relacionado con VAC, porque ASF garantiza que no interfiere con el cliente de Steam y todos sus procesos - este es el punto principal cuando hablamos de que ASF garantiza ser libre de VAC.

De acuerdo a los usuarios y mi mejor opinión, este es el caso actualmente, ya que nadie ha reportado ningún problema como los mencionados en el enlace de arriba al usar ASF. Tampoco pudimos reproducir el problema descrito usando ASF, mientras que lo reprodujimos claramente con Idle Master.

Sin embargo, ten en cuenta que Valve podría añadir ASF a la lista negra en algún punto, pero es un completo sinsentido ya que incluso si lo hacen, aún podrías jugar juegos protegidos por VAC desde tu PC, y usar ASF al mismo tiempo, por ejemplo, en tu servidor, así que estoy bastante seguro de que saben muy bien que ASF no debería ser sospechoso en relación al VAC, y no harán nuestras vidas más difíciles al añadir ASF a la lista negra sin razón alguna. Sin embargo, en el peor de los casos no podrás jugar, como se mencionó anteriormente, ya que la garantía de ser libre de VAC de ASF permanece independientemente de si Steam bloquea el binario de ASF, o no (y todavía puedes ejecutar ASF en cualquier otra máquina sin que el cliente de Steam esté instalado). Ahora mismo no hay necesidad de hacer nada de eso, y esperemos que siga así.

---

### ¿Es seguro?

Si preguntas si ASF es seguro como software, lo que significa que no causará ningún daño a tu computadora, no robará tus datos privados, instalará virus o cosas como esas - sí es seguro. ASF está libre de malware, robo de datos, minería de criptomonedas y cualquier (y todos) otro comportamiento dudoso que pueda ser considerado malicioso o no deseado por el usuario. Además de eso tenemos una sección dedicada de **[comunicación remota](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Remote-communication-es-ES)**</strong> que cubre nuestra política de privacidad y el comportamiento de ASF que va más allá de aquello para lo que configuraste el programa.

Nuestro código es abierto, y los binarios distribuidos siempre son compilados desde **[fuentes disponibles públicamente](https://es.wikipedia.org/wiki/Software_de_c%C3%B3digo_abierto)** por **[sistemas de integración continua automatizados y confiables](https://en.wikipedia.org/wiki/Build_automation)**, y ni siquiera por los propios desarrolladores. Cada compilación es reproducible siguiendo nuestro script de compilación y resultará en exactamente el mismo código IL (binario) **[determinista](https://es.wikipedia.org/wiki/Sistema_determinista)**. Si por cualquier razón no confías en nuestras compilaciones, siempre puedes compilar y usar ASF desde la fuente, incluyendo todas las bibliotecas que usa ASF (como SteamKit2), que también son de código abierto.

Al final, sin embargo, siempre es una cuestión de confianza en el desarrollador de tu aplicación, tú mismo debes decidir si consideras seguro a ASF, potencialmente apoyando tu decisión con los argumentos técnicos especificados arriba. No creas ciegamente en algo solo porque yo lo dije - compruébalo tú mismo, ya que esa es la única forma de estar seguro.

---

### ¿Puedo ser baneado por esto?

Para responder esta pregunta, debemos examinar de cerca el **[acuerdo de suscriptor a Steam](https://store.steampowered.com/subscriber_agreement/spanish/)**. Steam no prohíbe el uso de múltiples cuentas, de hecho, **[lo permite](https://help.steampowered.com/faqs/view/7EFD-3CAE-64D3-1C31#share)** implicando que puedes usar el mismo autenticador móvil en más de una cuenta. Lo que no permite es compartir cuentas con otras personas, pero no estamos haciendo eso aquí.

El único punto real que considera a ASF es el siguiente:
> No está permitido utilizar Trampas, software automatizado (bots), mods, aplicaciones de trampas (hacks) ni cualquier otro software de terceros no autorizado para modificar o automatizar cualquier proceso del bazar de suscripciones.

La preguntas es, qué es en realidad un proceso del Bazar de Suscripciones. Como podemos leer:

> Un ejemplo de bazar de suscripciones es el Mercado de la comunidad Steam

No estamos modificando o automatizando un proceso del bazar de suscripciones, si por bazar de suscripciones entendemos el mercado de la comunidad o la tienda de Steam. Sin embargo...

> Valve puede cancelar su cuenta o cualquier suscripción en cualquier momento en caso de que (a) Valve deje de proporcionar ese tipo de suscripción en general a suscriptores en situaciones similares o (b) usted incumpla cualquiera de los términos del presente acuerdo (incluidos los términos de suscripción y las normas de uso).

Por lo tanto, como con cada software de Steam, ASF no está autorizado por Valve y no puedo garantizar que no serás suspendido si Valve de repente decide banear las cuentas que usen ASF. Esto es excepcionalmente improbable considerando el hecho de que ASF es usado en más de un millón de cuentas, pero sigue siendo una posibilidad, a pesar de la probabilidad real.

Especialmente porque:
> En cuanto a las suscripciones y los contenidos y servicios ajenos a Valve, Valve no filtra ese contenido de terceros disponible en Steam o a través de otras fuentes. Valve no acepta responsabilidad ni obligación alguna por el contenido de terceros. Algunas aplicaciones de software de terceros pueden utilizarse con fines comerciales; no obstante, si usted adquiere ese software a través de Steam, solo puede utilizarlo con fines privados.

Sin embargo, Valve claramente admite la existencia de los "recolectores de Steam", como se indica **[aquí](https://help.steampowered.com/faqs/view/22C0-03D0-AE4B-04E8)**, si me preguntas, estoy bastante seguro de que si no estuvieran de acuerdo con ellos, ya hubieran hecho algo en lugar de señalar que podrían causar problemas relacionados con VAC. La palabra clave aquí es recolectores de **Steam**, por ejemplo ASF, y no recolectores de **juegos**.

Ten en cuenta que lo anterior solo es nuestra interpretación de los **[Términos de Servicio de Steam](https://store.steampowered.com/subscriber_agreement/spanish)** y varios puntos - ASF está bajo la licencia Apache 2.0, que claramente establece:

```
Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
```

Usas este software bajo tu propio riesgo. Es muy improbable que puedas ser baneado por eso, pero si lo eres, solo puedes culparte a ti mismo.

---

### ¿Alguien ha sido baneado por esto?

**Sí**, hemos tenido al menos unos incidentes hasta ahora que resultaron en algún tipo de suspensión por parte de Steam. Ya sea que el propio ASF haya sido la causa principal o no, eso es otra historia que probablemente nunca llegaremos a saber.

El primer caso involucra a individuo con más de 1000 bots que recibió un bloqueo de intercambio (junto con todos los bots), muy probablemente debido al excesivo uso de `loot ASF` ejecutado en todos los bots al mismo tiempo, u otra cantidad sospechosa de intercambios en un corto periodo de tiempo.

> Hola XXX, Gracias por contactar con el Soporte de Steam. Parece que esta cuenta fue usada para administrar una red de bots. Usar bots es una violación al Acuerdo de Suscriptor a Steam.

Por favor, usa algo de sentido común y no asumas que puedes hacer tales locuras solo porque ASF te permite hacerlo. Ejecutar el comando `loot ASF` en más de 1000 bots fácilmente puede ser considerado como un ataque **[DDoS](https://es.wikipedia.org/wiki/Ataque_de_denegaci%C3%B3n_de_servicio)**, y personalmente no me sorprende que alguien haya sido baneado por ello. Mantén por lo menos un uso justo en lo que respecta al servicio de Steam, y **muy probablemente** estarás bien.

El segundo caso involucró a un sujeto con más de 170 bots que fue baneado durante las Rebajas de Invierno de Steam 2017.

> Tu cuenta fue bloqueada por violar el Acuerdo de Suscriptor a Steam. Juzgando por los intercambios y otros factores, esta cuenta fue usada para recolectar cromos ilegalmente en Steam, así como para actividades relacionadas no solo comerciales. Esta cuenta ha sido bloqueada permanentemente y el Soporte de Steam no puede proporcionar soporte adicional con este problema.

Este caso es, una vez más, muy difícil de analizar, por la respuesta vaga del soporte de Steam que apenas ofrece detalles. Basado en mi opinión personal, este usuario probablemente intercambió cromos de Steam por algún tipo de dinero (¿bot para subir de nivel?) o de alguna otra forma intentó retirar fondos de Steam. En caso de que no lo sepas, esto también es ilegal de acuerdo a los **[Términos de Servicio de Steam](https://store.steampowered.com/subscriber_agreement/spanish/)**.

El tercer caso implica a un usuario con más de 120 bots que fue baneado por incumplimiento de las **[normas de conducta online de Steam](https://store.steampowered.com/online_conduct?l=spanish)**.

> Hola XXX, Gracias por contactar con el Soporte de Steam. Esta y otras cuentas fueron usadas para hacer flooding en nuestra infraestructura de red, lo cual es una violación de las normas de conducta online de Steam. Esta cuenta ha sido bloqueada permanentemente y el Soporte de Steam no puede proporcionar soporte adicional con este problema.

Este caso es un poco más fácil de analizar por los detalles adicionales proporcionados por el usuario. Aparentemente el usuario estaba usando **una versión de ASF muy desactualizada** la cual incluía un bug causando que ASF envíe un número excesivo de solicitudes a los servidores de Steam. El bug no existía inicialmente pero fue activado debido a cambios importantes en Steam y fue corregido en futuras versiones. **ASF solo tiene soporte para la [última versión estable](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest) publicada en GitHub**. El software es escrito por humanos, y los humanos tienden a cometer errores. Si el error tiene un alcance global, es solucionado rápidamente y liberado a todos los usuarios como un bugfix. Valve no baneará repentinamente a más de un millón de usuarios de ASF debido a mi error, por obvias razones. Sin embargo, si intencionalmente te niegas a usar una versión actualizada de ASF, entonces por definición estás en una muy pequeña minoría de usuarios que están **expuestos a incidentes como estos** debido a **no tener soporte**, ya que nadie está vigilando tu versión desactualizada de ASF, nadie la está arreglando y nadie asegura que no serás baneado solo por ejecutarlo. **Por favor, usa software actualizado**, no solo ASF, sino también todas las demás aplicaciones.

El caso más reciente ocurrió alrededor de junio de 2021, de acuerdo al usuario:

> Uso tu programa, he estado creando packs de refuerzo con 28 cuentas durante 3 años y con 128 cuentas durante los últimos 6 meses. Estaba en línea con un máximo de 15 cuentas simultáneamente para crear packs de refuerzo y enviarlos a la cuenta principal. El mes pasado, aumenté el número de cuentas en línea simultáneamente a 20, y 1 semana después, todas mis cuentas fueron baneadas. Este correo no es para culparte, por el contrario, siempre estuve consciente de las consecuencias. Quería hacerte saber qué tipos de comportamiento resultan en un ban permanente.

Es difícil decir si el aumento de las cuentas en línea simultáneamente fue la razón directa del ban, no contaría con eso, en cambio creo que el número de cuentas fue el culpable principal, un número mayor de cuentas en línea simultáneamente probablemente solo llamó atención hacia el usuario en cuestión, ya que tenía muchos más bots que los que recomendamos.

---

Todos lo incidentes anteriores tienen algo en común - ASF solo es una herramienta y es **tu** decisión cómo vas a usarlo. No serás baneado solo por usar ASF, sino por **cómo** lo usas. Puede ser una herramienta útil para recolectar una sola cuenta, o una red masiva de recolección formada por miles de bots. En cualquiera caso, no estoy ofreciendo asesoría legal, y tú debes decidir cómo usar ASF. No estoy ocultando ninguna información que podría ayudarte, por ejemplo, el hecho de que ASF hizo que baneen a algunas personas, no tengo razón para hacerlo - es tu decisión lo que quieras hacer con esa información. Si me preguntas - usa un poco de sentido común, evita tener más bots de los que recomendamos, no envíes cientos de intercambios al mismo tiempo, siempre usa una versión actualizada de ASF y _deberías_ estar bien. Cada incidente de esta naturaleza por **alguna razón** siempre le ha ocurrido a personas que ignoraron nuestra recomendación y decidieron que saben mejor que nosotros cuántos bots pueden ejecutar. Ya sea solo una coincidencia o un factor real, depende de ti decidirlo. No estoy ofreciendo ningún consejo legal, solo manifiesto una opinión que te puede ser útil, o la puedes ignorar completamente y basarte solo en los hechos relacionados anteriormente.

---

### ¿Qué información de privacidad divulga ASF?

Puedes encontrar una expicación detallada en la sección de **[comunicación remota](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Remote-communication-es-ES)**. Deberías revisarla si te preocupa tu privacidad, por ejemplo, si te preguntas por qué las cuentas usadas en ASF se unen a nuestro grupo de Steam. ASF no recopila ninguna información confidencial, y no la comparte con terceros.

---

## Otros

---

### Estoy usando un sistema operativo no soportado, como Windows de 32 bits, ¿puedo usar la última versión de ASF?

Sí, y esa versión no está fuera de soporte, pero no la compilamos oficialmente. Revisa la sección de **[compatibilidad](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility-es-ES)** para la variante genérica. ASF no tiene ninguna dependencia del sistema operativo, y puede funcionar en donde quiera que puedas hacer funcionar .NET runtime, lo que incluye Windows de 32 bits, incluso si no hay un paquete `win-x86` de sistema operativo específico por nuestra parte.

---

### ¡ASF es genial! ¿Puedo hacer una donación?

¡Sí, y estamos muy contentos de escuchar que disfrutas nuestro proyecto! Puedes encontrar varias posibilidades de donación en cada **[lanzamiento](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** y también **[en la página principal](https://github.com/JustArchiNET/ArchiSteamFarm)**. Es bueno notar que además de donaciones de dinero también aceptamos artículos de Steam, así que nada te impide donar skins, llaves o una pequeña parte de los cromos que has recolectado con ASF si gustas. ¡Gracias de antemano por tu generosidad!

---

### Estoy usando un PIN del modo familiar de Steam para proteger mi cuenta, ¿necesito introducirlo en algún lugar?

Sí, debes establecerlo en la propiedad de configuración del bot `SteamParentalCode`. Esto se debe principalmente a que ASF accede a muchas partes protegidas de tu cuenta de Steam y le sería imposible funcionar sin ellas.

---

### No quiero que ASF recolecte ningún juego por defecto, pero quiero usar las características adicionales de ASF. ¿Es posible?

Sí, si solo quieres iniciar ASF con el módulo de recolección de cromos pausado, puedes establecer la propiedad de configuración del bot `Paused` a `true` para lograrlo. Esto te permitirá `resume` reanudarlo durante el tiempo de ejecución.

Si quieres desactivar completamente el módulo de recolección de cromos y asegurarte de que nunca se ejecute sin que explícitamente le indiques lo contrario, entonces recomendamos establecer `FarmPriorityQueueOnly` a `true`, lo que en lugar de pausarlo, desactivará la recolección completamente hasta que añadas los juegos a la cola de prioridad de recolección.

Con el módulo de recolección de cromos pausado/deshabilitado, puedes utilizar las características adicionales de ASF, como `GamesPlayedWhileIdle`.

---

### ¿Se puede minimizar ASF a la bandeja del sistema?

ASF es una aplicación de consola, no hay ventana para ser minimizada, porque la ventana es creada para ti por tu sistema operativo. Sin embargo puedes usar cualquier herramienta de terceros capaz de hacerlo, tal como **[RBTray](https://github.com/benbuck/rbtray)** para Windows, o **[screen](https://linux.die.net/man/1/screen)** para Linux/macOS. Estos son solo ejemplos, hay muchas otras aplicaciones con funciones similares.

---

### ¿Usar ASF mantiene la elegibilidad para recibir packs de refuerzo?

**Sí**. ASF usa el mismo método para iniciar sesión en la red de Steam que el cliente oficial, por lo tanto también mantiene la habilidad de recibir packs de refuerzo para las cuentas usadas en ASF. Además, preservar esa habilidad no requiere iniciar sesión en la comunidad de Steam, así que puedes usar `OnlineStatus` en `Offline` si lo deseas.

---

### ¿Hay alguna forma de comunicarse con ASF?

Sí, a través de diferentes formas. Revisa la sección de **[comandos](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-es-ES)** para más información.

---

### Me gustaría ayudar con la traducción de ASF, ¿qué necesito hacer?

¡Gracias por tu interés! Puedes encontrar todos los detalles en nuestra sección de **[localización](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Localization-es-ES)**.

---

### Solo tengo una cuenta (principal) añadida a ASF, ¿puedo enviar comandos a través del chat de Steam?

**Sí**, se explica en la sección de **[comandos](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-es-ES#notas)**. Puedes hacerlo a través de un chat de grupo de Steam, aunque usar **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-es-ES#asf-ui)** podría ser más fácil para ti.

---

### ASF parece estar funcionando, ¡pero no estoy recibiendo ningún cromo!

La tasa de recolección de cromos difiere entre juegos, como puedes leer en la sección de **[rendimiento](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance-es-ES)**. Se tarda un tiempo, normalmente **varias horas por juego**, y no deberías esperar que los cromos caigan en unos minutos desde que inicias un programa. Si puedes ver que ASF activamente comprueba el estado de los cromos, y cambia el juego después de que el actual está completamente recolectado, entonces todo funciona bien. Es posible que hayas activado una opción tal como `DismissInventoryNotifications` en `BotBehaviour` la cual automáticamente descarta las notificaciones del inventario. Revisa la sección de **[configuración](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-es-ES)** para más detalles.

---

### ¿Cómo puedo detener completamente el proceso de ASF para mi cuenta?

Simplemente cierra el proceso de ASF, por ejemplo, haciendo clic en [X] en Windows. Si en cambio quieres detener un bot en particular pero mantener los demás en ejecución, entonces echa un vistazo a la **[propiedad de configuración del bot](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-es-ES#configuraci%C3%B3n-de-bot)** `Enabled`, o al **[comando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-es-ES)** `stop`. Si en cambio quieres detener el proceso de recolección automática, pero mantener ASF en ejecución para tu cuenta, entonces para eso es la **[propiedad de configuración del bot](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-es-ES#configuraci%C3%B3n-de-bot)** `Paused` y el **[comando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-es-ES)** `pause`.

---

### ¿Cuántos bots puedo ejecutar con ASF?

ASF como programa no tiene un limite de instancias de bot, así que puedes ejecutar tantas como lo permita la memoria de tu máquina, sin embargo, estás limitado por la red de Steam y otros servicios de Steam. Actualmente puedes ejecutar hasta 100-200 bots con una sola IP y una sola instancia de ASF. Es posible ejecutar más bots con más IPs y más instancias de ASF, sorteando las limitaciones de IP. Ten en cuenta que si usas esa gran cantidad de bots, debes controlar sus números tú mismo, asegurándote de que todos están, de hecho, iniciando sesión y funcionando al mismo tiempo. ASF no fue optimizado para ese gran número de bots, y aplica la regla general de que **mientras más bots tengas, más problemas experimentarás**. También ten en cuenta que el límite mencionado antes en general depende de muchos factores internos, es más una aproximación que un límite estricto - es probable que puedas ejecutar más/menos bots que los especificados arriba.

El equipo de ASF sugiere ejecutar (y **poseer**) hasta **10 bots en total**, cualquier cosa arriba de eso no tiene soporte y lo haces bajo tu propio riesgo, en contra de nuestra sugerencia. Esta recomendación está basada en directrices internas de Valve, así como en nuestras propias sugerencias. Ya sea que cumplas con esta regla o no, es tu decisión, ASF como herramienta no irá contra tu voluntad, incluso si resulta en la suspensión de tus cuentas de Steam. Por lo tanto, ASF mostrará una advertencia si superas la cantidad recomendada, pero aún te permitirá ejecutar lo que quieras bajo tu propio riesgo y con falta de soporte.

---

### ¿Entonces puedo ejecutar más instancias de ASF?

Puedes ejecutar tantas instancias de ASF como quieras en una máquina, suponiendo que cada instancia tiene su propio directorio y sus propias configuraciones, y que la cuenta usada en una instancia no es usada en otra. Sin embargo, pregúntate por qué querrías hacer eso. ASF está optimizado para manejar más de un centenar de cuentas al mismo tiempo, y ejecutar esa centena de bots en sus propias instancias de ASF reduce el rendimiento, requiere más recursos del sistema operativo (como CPU y memoria), y ocasiona posibles problemas de sincronización entre instancias independientes de ASF, ya que este se ve obligado a compartir sus limitadores con otras instancias.

Por lo tanto, mi **recomendación** es, siempre ejecuta un máximo de una instancia de ASF por IP/interfaz. Si tienes más IPs/interfaces, ciertamente puedes ejecutar más instancias de ASF, con cada instancia usando su propia IP/interfaz o a través de su configuración `WebProxy` individual. Si no lo haces, ejecutar más instancias de ASF es totalmente inútil, ya que no ganarás nada al ejecutar más de 1 instancia por cada IP/interfaz. Steam no te permitirá mágicamente ejecutar más bots solo porque los ejecutaste en otra instancia de ASF, y para empezar ASF no te limita.

Por supuesto, existen casos de uso válidos para múltiples instancias de ASF en la misma interfaz de red, tal como alojar el servicio de ASF para tus amigos con cada amigo teniendo su propia instancia de ASF para garantizar el aislamiento entre bots e incluso entre los mismos procesos de ASF, sin embargo, no estás eludiendo ninguna limitación de Steam de esta forma, ese es un propósito completamente diferente.

---

### ¿Cuál es el significado del estatus al activar una clave?

El estatus indica cómo resultó un intento de activación. Hay diferentes estatus posibles, los más comunes incluyen:

| Estatus                 | Descripción                                                                                                                                                                                                 |
| ----------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| NoDetail                | El estatus "OK" indica éxito - la clave fue activada exitosamente.                                                                                                                                          |
| Timeout                 | La red de Steam no respondió en un tiempo determinado, no sabemos si la clave fue activada o no (lo más probable es que sí, pero lo puedes intentar de nuevo).                                              |
| BadActivationCode       | La clave proporcionada no es válida (no se reconoce como una clave válida por la red de Steam).                                                                                                             |
| DuplicateActivationCode | La clave proporcionada ya fue activada por otra cuenta, o revocada por el desarrollador/editor.                                                                                                             |
| AlreadyPurchased        | Tu cuenta ya tiene el `packageID` asociado a esta clave. Ten en cuenta que esto no indica si la clave es un caso de `DuplicateActivationCode` o no - solo que es válida y que no fue usada en este intento. |
| RestrictedCountry       | Esta clave tiene bloqueo regional y tu cuenta no está en la región válida permitida para activarla.                                                                                                         |
| DoesNotOwnRequiredApp   | No puedes activar esta clave porque te falta alguna otra aplicación - principalmente el juego base cuando estás intentando activar un paquete DLC.                                                          |
| RateLimited             | Has hecho demasiados intentos de activación y tu cuenta fue bloqueada temporalmente. Intenta de nuevo en una hora.                                                                                          |

---

### ¿Están afiliados con algún servicio de recolección de cromos?

**No**. ASF no está afiliado con ningún servicio y cualquier afirmación al respecto es falsa. Tu cuenta de Steam es de tu propiedad y la puedes usar del modo que quieras, pero Valve claramente indica en los **[Términos de Servicio oficiales](https://store.steampowered.com/subscriber_agreement/spanish/)** que:

> El usuario es el responsable de la confidencialidad de su información de inicio de sesión y contraseña y de la seguridad de su equipo de cómputo. Valve no es responsable del uso que le dé a su contraseña y cuenta, así como de todas las comunicaciones y actividades realizadas en Steam que resulten del uso que le dé a su nombre de inicio de sesión y contraseña ni las que resulten del uso que les dé otra persona a la que se le hayan revelado de forma deliberada o por negligencia infringiendo esta disposición sobre la confidencialidad.

ASF usa la licencia liberal Apache 2.0, lo que permite a otros desarrolladores integrar legalmente ASF con sus propios proyectos y servicios. Sin embargo, no se garantiza que dichos proyectos de terceros que utilicen ASF sean seguros, revisados, apropiados o legales de acuerdo a los **[Términos de Servicio de Steam](https://store.steampowered.com/subscriber_agreement/spanish/)**. Si quieres saber nuestra opinión, **te recomendamos encarecidamente que NO compartas NINGÚN detalle de tu cuenta con servicios de terceros**. Si dicho servicio resulta ser una **típica estafa**, te quedarás solo con el problema, muy probablemente sin tu cuenta de Steam y ASF no asumirá ninguna responsabilidad por los servicios de terceros que afirmen ser seguros, porque el equipo de ASF no autorizó ni revisó ninguno de ellos. En otras palabras, **los usas bajo tu propio riesgo, en contra de nuestra sugerencia hecha arriba**.

Además de eso, los **[Términos de Servicio de Steam](https://store.steampowered.com/subscriber_agreement/spanish/)** claramente expresan que:

> No debe revelar, compartir ni permitir de ningún otro modo que otros usuarios utilicen su contraseña o cuenta, excepto si Valve lo autoriza expresamente.

Es tu cuenta y tu decisión. No digas que nadie te advirtió. ASF como programa cumple con todas las reglas mencionadas anteriormente, ya que no estás compartiendo los detalles de tu cuenta con nadie, y estás usando el programa de forma personal, pero cualquier otro "servicio de recolección de cromos" requerirá las credenciales de tu cuenta, así que también viola la regla anterior (de hecho, varias de ellas). Igual que con la evaluación de los **[Términos de Servicio de Steam](https://store.steampowered.com/subscriber_agreement/spanish/)**, no estamos ofreciendo ningún consejo legal, y tú debes decidir si quieres usar esos servicios o no - según nosotros **viola directamente los [Términos de Servicio de Steam](https://store.steampowered.com/subscriber_agreement/spanish/)** y podría resultar en la suspensión si Valve se entera. Como se señaló anteriormente, **recomendamos fuertemente NO usar ninguno de dichos servicios**.

---

## Problemas

---

### Uno de mis juegos ha sido recolectado por más de 10 horas, ¡pero todavía no he obtenido ningún cromo!

La razón de ello podría estar relacionada con un conocido problema de Steam, el cual ocurre cuando tienes dos licencias para el mismo juego, una de las cuales tiene limitada la obtención de cromos. Esto normalmente ocurre cuando activas un juego que es gratis por tiempo limitado en Steam, y luego activas una clave para el mismo juego (pero sin limitaciones), por ejemplo, de un paquete pagado. Si esta situación ocurre, Steam reporta en la página de insignias que el juego todavía tiene cromos obtenibles, pero no importa cuánto juegues el juego - nunca obtendrás cromos debido a la licencia gratuita en tu cuenta. Dado que no es un problema de ASF, sino de Steam, no podemos solucionarlo desde el lado de ASF, y necesitas resolverlo tú mismo.

Hay dos formas de solucionar el problema. Primero, puedes poner el juego en la lista negra de ASF, ya sea con el **[comando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-es-ES)** `fbadd` o con la **[propiedad de configuración](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-es-ES)** `Blacklist`. Esto evitará que ASF intente recolectar cromos de este juego, pero no resolverá el problema subyacente que te impide obtener cromos del juego afectado. En segundo lugar, puedes usar la herramienta del soporte de Steam para remover la licencia gratuita de tu cuenta, dejando solamente la licencia completa que incluye la obtención de cromos. Para ello, primero visita tu página de **[licencias y activaciones de claves de producto](https://store.steampowered.com/account/licenses)** y busca la licencia gratuita y la de pago para el juego afectado. Normalmente es bastante fácil - ambas tienen un nombre similar, pero la gratuita tiene "limited free promotional package" u otro tipo de "promo" en el nombre de la licencia, además de "gratuito" en el campo "método de adquisición". A veces puede ser más complicado, por ejemplo, si el juego gratuito estaba en un paquete y tiene un nombre diferente. Si has encontrado dos licencias así - entonces ciertamente se trata del problema descrito aquí, y puedes remover la licencia gratuita sin perder el juego.

Para remover la licencia gratuita de tu cuenta, visita la **[página de soporte de Steam](https://help.steampowered.com/wizard/HelpWithGame)** y pon el nombre del juego afectado en el campo de búsqueda, el juego debería aparecer en la sección "productos", haz clic en él. Alternativamente, puedes usar el enlace `https://help.steampowered.com/wizard/HelpWithGame?appid=<appID>` y reemplazar `<appID>` con la appID del juego que está causando problemas. Después, haz clic en "Quiero eliminar este juego permanentemente de mi cuenta" y selecciona la licencia defectuosa que encontraste anteriormente, normalmente la que tiene "limited free promotional package" en el nombre (o algo similar). Después de remover la licencia gratuita, ASF debería ser capaz de recolectar cromos del juego afectado sin problemas, deberías reiniciar la recolección después de remover el juego solo para asegurarse de que Steam seleccione la licencia correcta esta vez.

---

### ASF no detecta `X` juego como disponible para recolectar, ¡pero sé que incluye cromos de Steam!

Hay dos razones principales. La primera y más obvia es el hecho de que te estás refiriendo a la **tienda de Steam** donde cierto juego se anuncia con cromos. Esta es una suposición **errónea**, ya que eso simplemente indica que el juego **tiene** cromos, pero esta función no necesariamente está **habilitada** de forma inmediata para ese juego. Puedes leer más al respecto en este **[anuncio oficial](https://steamcommunity.com/games/593110/announcements/detail/1954971077935370845)**.

En resumen, el icono de cromos obtenibles en la tienda de Steam no significa nada, comprueba tu **[página de insignias](https://steamcommunity.com/my/badges)** para confirmar si un juego tiene cromos obtenibles o no - esto es lo que hace ASF. Si tu juego no aparece en la lista como un juego con cromos obtenibles, entonces este juego **no** es posible recolectarlo, independientemente de la razón.

La segunda razón es menos obvia, y es la situación cuando puedes ver que tu juego ciertamente tiene cromos obtenibles en tu página de insignias, pero no es recolectado inmediatamente por ASF. A menos que hayas encontrado algún otro bug, tal como que ASF no pueda comprobar la página de insignias (descrito abajo), es simplemente un efecto de caché y en el lado de ASF Steam aún está reportado una página desactualizada de insignias. Este problema se debería resolver por sí solo tarde o temprano, cuando la caché sea invalidada. Tampoco hay forma de resolver esto desde nuestro lado.

Por supuesto, esto asume que estás ejecutando ASF con los ajustes predeterminados, ya que también podrías haber añadido este juego a la lista negra de recolección, usando `FarmPriorityQueueOnly`, `SkipRefundableGames` y así por el estilo.

---

### ¿Por qué el tiempo de juego de los juegos recolectados con ASF no aumenta?

Lo hace, pero **no en tiempo real**. Steam registra tu tiempo de juego en intervalos fijos y agenda una actualización para ello, pero no está garantizado que se actualice inmediatamente al momento que abandones la sesión, mucho menos durante. Solo porque el tiempo de juego no se actualiza en tiempo real no significa que no se registre, normalmente se actualiza cada 30 minutos aproximadamente.

---

### ¿Cuál es la diferencia entre una advertencia y un error en el registro?

ASF escribe en su registro un montón de información en varios niveles de registro. Nuestro objetivo es explicar con **precisión** lo que está haciendo ASF, incluyendo los problemas de Steam con los que tiene que tratar, u otros problemas a resolver. La mayoría de las veces no todo es relevante, por eso tenemos dos niveles principales usados en ASF en términos de problemas - un nivel de advertencia, y un nivel de error.

La regla general de ASF es que las advertencias **no** son errores, por lo tanto **no** deben ser reportados. Una advertencia es un indicador de que ocurrió algo potencialmente no deseado. Ya sea que Steam no reaccione, la API esté teniendo errores o que tu conexión de red se haya caído - es una advertencia, y significa que esperamos que esto suceda, así que no es necesario importunar a los desarrolladores de ASF con eso. Claro que eres libre de preguntar sobre ellos u obtener ayuda usando nuestro soporte, pero no debes asumir que vale la pena reportar esos errores (a menos que confirmemos lo contrario).

Los errores, por otra parte, indican una situación que no debería ocurrir, por lo tanto vale la pena reportarlos siempre que te hayas asegurado de que no eres tú quien los está causando. Si es una situación común que esperamos que ocurra, entonces será convertido en una advertencia. De lo contrario, es posiblemente un bug que debe ser corregido, no ser ignorado, suponiendo que no es resultado de un problema técnico tuyo. Por ejemplo, introducir contenido inválido en el archivo `ASF.json` arrojará un error, ya que ASF no puede leerlo, pero eres tú quien lo puso ahí, así que no debes reportar esos errores (a menos que confirmes que ASF está equivocado y que tu estructura es absolutamente correcta).

En resumen - reporta los errores, no reportes las advertencias. Aún puedes preguntar sobre las advertencias y recibir ayuda en nuestras secciones de soporte.

---

### ASF no inicia, ¡la ventana del programa se cierra inmediatamente!

En condiciones normales, cualquier fallo o cierre de ASF generará un `log.txt` en el directorio del programa, que puede ser usado para encontrar la causa de ello. Además, los últimos archivos de registro también se archivan en el directorio `logs`, ya que el archivo principal `log.txt` se sobrescribe en cada ejecución de ASF.

Sin embargo, si .NET runtime no es capaz de arrancar en tu máquina, entonces `log.txt` no se generará. Si eso sucede, probablemente olvidaste instalar los prerrequisitos de .NET, como se indica en la guía de **[instalación](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up-es-ES#configuraci%C3%B3n-de-sistema-operativo-espec%C3%ADfico)**. Otros problemas comunes incluyen intentar ejecutar la variante incorrecta de ASF para tu sistema operativo, o la falta de dependencias nativas de .NET runtime. Si la ventana de consola se cierra muy rápido para que leas el mensaje, entonces abre una consola independiente y ejecuta el binario de ASF desde ahí. Por ejemplo en Windows, abre el directorio de ASF, mantén `Shift`, clic derecho dentro de la carpeta y selecciona "*abrir la ventana de comandos aquí*" (o *powershell*), luego escribe en la consola `.\ArchiSteamFarm.exe` y confirma con Enter. De esta manera obtendrás el mensaje preciso de por qué ASF no está iniciando correctamente.

---

### ¡ASF está expulsando mi sesión en el Cliente de Steam mientras estoy jugando! / *Esta cuenta tiene iniciada una sesión en otro equipo*

Esto se muestra como un mensaje en Steam de que la cuenta está siendo usada en otro lado mientras estás jugando. Este problema puede tener dos razones diferentes.

Una razón de esto es por paquetes (juegos) rotos que no mantienen bloqueado el estatus de juego, sin embargo esperan que ese bloqueo sea controlado por el cliente. Un ejemplo de estos paquetes sería Skyrim SE. Tu cliente de Steam ejecuta el juego correctamente, pero ese juego no se registra como que está siendo usado. Debido a eso, ASF ve que es libre de reanudar el proceso, y lo hace, y eso te expulsa de la red de Steam, ya que Steam repentinamente detecta que la cuenta está siendo usada en otro lado.

La segunda razón podría surgir mientras estás jugando en tu PC mientras ASF está esperando (especialmente en otra máquina) y pierdes tu conexión a la red. En este caso, la red de Steam te marca como desconectado y libera el bloqueo del estatus de juego (como arriba), lo que activa ASF (por ejemplo, en otra máquina) para que reanude la recolección. Cuando tu PC vuelve a estar en línea, Steam ya no puede adquirir el bloqueo (que ahora lo tiene ASF, también similar a lo de arriba) y muestra el mismo mensaje.

Ambas causas en el lado de ASF son muy difíciles de manejar, ya que ASF simplemente reanuda la recolección una vez que la red de Steam informa que la cuenta está libre para ser usada de nuevo. Esto es lo que pasa normalmente cuando cierras el juego, pero con paquetes rotos esto puede pasar inmediatamente, incluso si tu juego aún se está ejecutando. ASF no tiene forma de saber si te desconectaste, dejaste de jugar o si aún estás jugando a un juego que no bloquea el estado de juego correctamente.

La única solución adecuada a este problema es pausar manualmente tu bot con `pause` antes de que empezar a jugar, y reanudarlo con `resume` una vez que termines. Alternativamente, simplemente puedes ignorar el problema y actuar igual como si jugaras con el cliente de Steam desconectado.

---

### `¡Desconectado de Steam!` - No puedo conectarme a los servidores de Steam.

ASF solo puede **intentar** establecer conexión con los servidores de Steam, y puede fallar debido a muchas razones, incluyendo falta de conexión a internet, que Steam esté caído, que tu cortafuegos esté bloqueando la conexión, herramientas de terceros, rutas configuradas incorrectamente o fallas temporales. Puedes habilitar el modo `Debug` para comprobar registros con mayor verbosidad que indiquen las razones exactas del fallo, aunque normalmente es causado por tus propias acciones, tal como usar "CS:GO MM Server Picker" lo que bloquea un montón de IPs de Steam, haciendo muy difícil contactar con la red de Steam.

ASF hará todo lo posible para establecer la conexión, lo que incluye no solo solicitar una lista actualizada de servidores sino también intentar otra IP cuando la anterior falla, si realmente es un problema temporal con algún servidor o ruta específicos, ASF se conectará tarde o temprano. Sin embargo, si estás tras un cortafuegos o de otra forma impedido para contactar con los servidores de Steam, obviamente necesitas solucionarlo tú mismo, con ayuda potencial del modo `Debug`.

También es posible que tu máquina no sea capaz de establecer conexión con los servidores de Steam usando los protocolos por defecto de ASF. Puedes modificar los protocolos que ASF tiene permitido usar modificando la propiedad de configuración global `SteamProtocols`. Por ejemplo, si tienes problemas para conectarte a Steam con el protocolo `UDP` (por ejemplo, debido al cortafuegos), quizás tengas más suerte con `TCP` o `WebSocket`.

En una situación muy improbable de tener los servidores incorrectos en caché, por ejemplo al mover la carpeta `config` de una máquina o otra localizada en un país diferente, eliminar `ASF.db` para actualizar los servidores de Steam en la siguiente ejecución podría ayudar. Muy a menudo no es necesario y no tiene que hacerse, ya que esa lista se actualiza automáticamente en la primera ejecución, así como cuando se establece la conexión - solo lo mencionamos como una forma de purgar cualquier cosa relacionada con la lista de servidores de Steam almacenados en caché por ASF.

---

### `¡No se pudo obtener información de las insignias, volveremos a intentarlo más tarde!`

Generalmente significa que estás usando un PIN del modo familiar de Steam para acceder a tu cuenta, pero olvidaste ponerlo en tu configuración de ASF. Debes introducir un PIN válido en la propiedad de configuración del bot `SteamParentalCode`, de lo contrario ASF no será capaz de acceder a la mayoría del contenido web, por lo tanto no podrá funcionar correctamente. Dirígete a la **[configuración](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-es-ES)** para aprender más sobre `SteamParentalCode`.

Otras razones incluyen un problema temporal de Steam, problemas de red o similares. Si el problema no se resuelve solo después de varias horas y estás seguro que configuraste ASF correctamente, siéntete libre de hacérnoslo saber.

---

### ¡ASF está fallando con el error `La solicitud falló después de 5 intentos`!

Generalmente significa que estás usando un PIN del modo familiar de Steam para acceder a tu cuenta, pero olvidaste ponerlo en tu configuración de ASF. Debes introducir un PIN válido en la propiedad de configuración del bot `SteamParentalCode`, de lo contrario ASF no será capaz de acceder a la mayoría del contenido web, por lo tanto no podrá funcionar correctamente. Dirígete a la **[configuración](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-es-ES)** para aprender más sobre `SteamParentalCode`.

Si el PIN del modo familiar no es la razón, entonces este es un error más común, y debes acostumbrarte a eso, simplemente significa que ASF envió una solicitud a la red de Steam, y no obtuvo una respuesta válida, 5 veces consecutivas. Generalmente significa que Steam está caído o está teniendo dificultades o en mantenimiento - ASF está consciente de tales problemas y no debes preocuparte por ellos, a menos que sucedan constantemente por más de varias horas, y otros usuarios no tengan dichos problemas.

¿Cómo comprobar si Steam está caído? **[Steam Status](https://steamstat.us)** es una excelente fuente para comprobar si Steam **debería** estar en línea, si notas errores, especialmente relacionados con la Comunidad o la API Web, entonces Steam está teniendo dificultades. Tal vez quieras dejar a ASF y permitir que haga su trabajo después de un tiempo de inactividad, o puedes cerrarlo y esperar.

Sin embargo, ese no siempre es el caso, ya que en algunas situaciones los problemas de Steam pueden no ser detectados por Steam Status, por ejemplo, este caso sucedió cuando Valve rompió el soporte HTTPS para la Comunidad de Steam el 7 de junio de 2016 - acceder a la **[Comunidad de Steam](https://steamcommunity.com)** a través de HTTPS arrojaba un error. Por lo tanto, tampoco confíes ciegamente en Steam Status, es mejor comprobar por ti mismo si todo funciona como debería.

Además, Steam incluye varias medidas de límites de intentos que bloquearán temporalmente tu IP si realizas un número excesivo de solicitudes al mismo tiempo. ASF está consciente de eso y te ofrece varios limitadores en la configuración, de los que deberías hacer uso. Los ajustes por defecto fueron hechos basados en una cantidad **sana** de bots, si utilizas una cantidad enorme que incluso Steam te dice que te retires, los modificas hasta que no te diga eso, o haces lo que te dice. Supongo que la segunda manera no es una opción para ti, así que lee sobre este tema y presta especial atención a `WebLimiterDelay` el cual es un limitador general que aplica a todas las solicitudes web.

No hay una "regla de oro" que funcione para todos, porque los bloqueos son influenciados fuertemente por factores de terceros, por eso tienes que experimentar tú mismo y encontrar un valor que funcione para ti. También puedes ignorar lo que dije y usar algo como `10000` lo que está garantizado que funcionará correctamente, pero no te quejes de que tu ASF reacciona a todo en 10 segundos y de cómo la lectura de insignias toma 5 minutos. Además, es totalmente posible que no usar ningún limitador no haga nada porque tienes una cantidad tan grande bots que alcances el **[límite](#cuántos-bots-puedo-ejecutar-con-asf)** mencionado anteriormente. Sí, es totalmente posible que puedas iniciar sesión en la red de Steam (cliente) sin problemas, pero Steam web (sitio web) se negará a escuchar si tienes 100 sesiones establecidas a la vez. ASF requiere que tanto la red de Steam como Steam web sean cooperativos, solo se necesita uno caído para tener problemas de los que no te recuperarás.

Si nada ayuda y no tienes idea de qué está mal, siempre puedes activar el modo `Debug` y ver en el registro de ASF exactamente por qué las solicitudes están fallando. Por ejemplo:

```text
InternalRequest() HEAD https://steamcommunity.com/my/edit/settings
InternalRequest() Forbidden <- HEAD https://steamcommunity.com/my/edit/settings
```

¿Ves ese código `Forbidden`? Esto significa que fuiste temporalmente bloqueado por una excesiva cantidad de solicitudes, porque aún no modificaste correctamente `WebLimiterDelay` (suponiendo que también obtienes el mismo error en todas la demás solicitudes). Podría haber otras razones listadas ahí, tal como `InternalServerError`, `ServiceUnavailable` y tiempos de espera excedidos que indican mantenimiento/problemas de Steam. Siempre puedes intentar visitar el enlace mencionado por ASF y comprobar si funciona - si no lo hace, ya sabes por qué ASF tampoco puede acceder. Si lo hace, y el mismo error no desaparece después de un día o dos, puede ser útil investigar y reportar.

Antes de hacer eso debes **asegurarte de que vale la pena reportar el error en primer lugar**. Si se menciona en estas Preguntas Frecuentes, tal como problemas relacionados con el intercambio, entonces no debes informarlo. Si es un problema que ocurrió una o dos veces, especialmente cuando tu red estaba inestable o Steam estaba caído - tampoco es el caso. Sin embargo, si pudiste reproducir el problema varias veces consecutivas, en un lapso de 2 días, reiniciaste ASF así como tu máquina en el proceso y te aseguraste de que no haya una entrada en las preguntas frecuentas que ayudara a resolverlo, entonces puede valer la pena preguntar al respecto.

---

### ¡ASF parece congelarse y no muestra nada en la consola hasta que presiono una tecla!

Lo más probable es que utilices Windows y que tu consola tenga el modo de edición rápida habilitado. Consulta **[esta](https://stackoverflow.com/questions/30418886/how-and-why-does-quickedit-mode-in-command-prompt-freeze-applications)** pregunta en StackOverflow para la explicación técnica. Debes desactivar el modo de edición rápida haciendo clic derecho en la venta de consola de ASF, abrir propiedades, y desmarcando la casilla respectiva.

---

### ¡ASF no puede aceptar o enviar intercambios!

Primero lo obvio - las cuentas nuevas empiezan como limitadas. Hasta que desbloquees la cuenta añadiendo a la cartera o gastando en la tienda $5 dólares estadounidenses (o lo equivalente en tu moneda), ASF no puede aceptar ni enviar intercambios usando esta cuenta. En este caso, ASF declarará que el inventario está vacío, porque cada cromo en él es no intercambiable.

Además, si no usas **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication-es-ES)**, es posible que ASF de hecho acepte/envíe intercambios, pero necesitas confirmarlos a través de tu correo electrónico. Del mismo modo, si usas la autenticación de dos factores clásica, necesitas confirmar el intercambio a través de tu autenticador. Las confirmaciones son **obligatorias** ahora, si no las quieres aceptar por ti mismo, considera importar tu autenticador a ASF 2FA.

También ten en cuenta que solo puedes intercambiar con tus amigos, y personas con un enlace de intercambio conocido. Si estás intentando iniciar un intercambio *Bot -> Master*, tal como `loot`, necesitas tener el bot en tu lista de amigos, o tu `SteamTradeToken` definido en la configuración del bot. Asegúrate de que el token sea válido - de lo contrario, no podrás enviar un intercambio.

Por último, recuerda que los nuevos dispositivos tienen una restricción de intercambio de 7 días, si recién añadiste tu cuenta a ASF, espera al menos 7 días - todo debería funcionar después de ese período. Esta limitación incluye **ambos**, aceptar **y** enviar intercambios. No siempre se activa, y hay personas que pueden enviar y aceptar intercambios instantáneamente. La mayoría de las personas son afectadas, y la restricción **sucederá**, incluso si puedes enviar y aceptar intercambios a través de tu cliente de Steam en la misma máquina. Solo espera pacientemente, no hay nada que puedas hacer para apresurarlo. Asimismo, puedes obtener una restricción similar al eliminar/cambiar varios ajustes de Steam relacionados con la seguridad, como 2FA, SteamGuard, contraseña, correo electrónico y demás. En general, comprueba si puedes enviar un intercambio desde esa cuenta tú mismo, si es así, es muy probable que sea la clásica restricción de 7 días por nuevo dispositivo.

Y finalmente, no olvides que una cuenta solo puede tener 5 intercambios pendientes de otra cuenta, así que ASF no enviará intercambios si ya tienes 5 (o más) pendientes para aceptar de ese bot. Esto rara vez es un problema, pero también vale la pena mencionarlo, especialmente si configuras ASF para enviar intercambios automáticamente, pero no estás usando ASF 2FA y olvidaste confirmarlos.

Si nada funcionó, siempre puedes activar el modo `Debug` y comprobar por ti mismo por qué las solicitudes están fallando. Por favor, ten en cuenta que Steam dice sinsentidos la mayor parte del tiempo, y la razón dada puede no tener ningún sentido lógico, o puede incluso ser incorrecto - si decides interpretar esa razón, asegúrate de tener bastante conocimiento acerca de Steam y sus peculiaridades. También es bastante común ver ese problema sin una razón lógica, y la única solución sugerida en este caso es volver a añadir la cuenta a ASF (y esperar 7 días de nuevo). A veces este problema también se soluciona *mágicamente*, de la misma forma en que ocurre. Sin embargo, normalmente solo es la restricción de intercambio de 7 días, un problema temporal de Steam, o ambos. Es mejor darle algunos días antes de comprobar manualmente qué está mal, a menos que tengas necesidad de depurar la causa real (y normalmente serás forzado a esperar de todos modos, porque el mensaje de error no tendrá sentido, ni te ayudará en lo más mínimo).

En cualquier caso, ASF solo puede **intentar** enviar una solicitud a Steam para aceptar/enviar el intercambio. Si Steam acepta o no esa solicitud, está fuera del alcance de ASF, y ASF no lo hará funcionar mágicamente. No hay ningún bug relacionado con esa característica, y tampoco hay nada que probar, porque la lógica ocurre fuera de ASF. Por lo tanto, no pidas que se solucionen cosas que no están rotas, y tampoco preguntes por qué ASF no puede aceptar o enviar intercambios - **no lo sé, y tampoco lo sabe ASF**. Supéralo, o arréglalo tú mismo, si sabes cómo.

---

### ¿Por qué tengo que introducir el código 2FA/SteamGuard en cada inicio de sesión? / *Se eliminó la clave de sesión expirada*

ASF utiliza claves de acceso (si dejaste habilitado `UseLoginKeys`) para mantener credenciales válidas, el mismo mecanismo que utiliza Steam - el código 2FA/SteamGuard solo es requerido una vez. Sin embargo, debido a problemas en la red de Steam, es posible que la clave de acceso no se guarde en la red, ya hemos visto tales problemas no solo con ASF, sino también con el cliente regular de Steam (la necesidad de introducir nombre de usuario + contraseña en cada ejecución, a pesar de la opción "recordarme").

Podrías eliminar `BotName.db` y `BotName.bin` (si está disponible) de la cuenta afectada e intentar vincular ASF a tu cuenta de nuevo, pero es probable que eso no haga nada. Algunos usuarios han reportado que **[desautorizar todos los dispositivos](https://store.steampowered.com/twofactor/manage)** en Steam debería ayudar, cambiar la contraseña hará lo mismo. Sin embargo, esas solo son soluciones alternas que ni siquiera se garantiza que funcionen, la solución real basada en ASF es importar tu autenticador como **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication-es-ES)** - de esta forma ASF puede generar códigos automáticamente cuando sean requeridos, y no tendrás que ingresarlos manualmente. Usualmente el problema se soluciona mágicamente después de algún tiempo, así que simplemente puedes esperar a que eso suceda. Por supuesto, también puedes pedirle una solución a Valve, porque no puedo forzar a la red de Steam a aceptar nuestras claves de acceso.

Como nota aparte, también puedes desactivar las claves de acceso con la propiedad de configuración `UseLoginKeys` establecida a `false`, pero esto no resolverá el problema, solo omitirá el fallo inicial. ASF ya es consciente del problema descrito aquí y hará lo mejor posible para no usar claves de acceso si puede garantizar todas las credenciales de inicio de sesión, así que no hay necesidad de modificar manualmente `UseLoginKeys` si puedes proporcionar todos los detalles de inicio de sesión al usar ASF 2FA.

---

### Estoy teniendo el error: *No se puede iniciar sesión en Steam: `InvalidPassword` o `RateLimitExceeded`*

Esto error puede significar muchas cosas, algunas de ellas incluyen:

- Combinación inválida de usuario/contraseña (obviamente)
- Clave de sesión expirada usada por ASF para iniciar sesión
- Demasiados intentos de inicio de sesión fallidos en un corto período de tiempo (anti fuerza bruta)
- Demasiados intentos de inicio de sesión en un corto período de tiempo (límite de intentos excedido)
- Requerimiento de captcha para iniciar sesión (probablemente causado por las dos razones anteriores)
- Cualquier otra razón por la que la red de Steam te haya impedido iniciar sesión

En caso de anti fuerza bruta y límite de intentos excedido, el problema desaparecerá después de algún tiempo, solo espera y no intentes iniciar sesión mientras tanto. Si tienes ese problema con frecuencia, quizás sea aconsejable aumentar la propiedad de configuración de ASF `LoginLimiterDelay`. Reinicios excesivos del programa y otras solicitudes de inicio de sesión intencionales/no intencionales definitivamente no ayudarán con ese problema, así que intenta evitarlo si es posible.

En caso de claves de acceso expiradas - ASF eliminará la antigua y solicitará una nueva en el siguiente inicio de sesión (lo que requerirá introducir el código 2FA si tu cuenta está protegida por 2FA. Si tu cuenta utiliza ASF 2FA, el código será generado y usado automáticamente). Esto puede suceder naturalmente con el tiempo, pero si tienes este problema en cada inicio de sesión es posible que Steam, por alguna razón, haya decidido ignorar nuestras solicitudes de recordar la clave de acceso, como se menciona en el problema de **[arriba](#por-qué-tengo-que-introducir-el-código-2fasteamguard-en-cada-inicio-de-sesión--se-eliminó-la-clave-de-sesión-expirada)**. Por supuesto, puedes desactivar `UseLoginKeys` completamente, pero eso no solucionará el problema, solo evitará la necesidad de eliminar las claves de acceso expiradas cada vez. La solución real, igual que en el problema anterior, es usar ASF 2FA.

Y por último, si usaste una combinación incorrecta de nombre de usuario + contraseña, obviamente necesitas corregir eso, o desactivar el bot que intenta conectarse usando esas credenciales. ASF no puede adivinar si `InvalidPassword` significa credenciales inválidas, o cualquiera de las razones enumeradas anteriormente, por lo tanto seguirá intentando hasta que tenga éxito.

Ten en cuenta que ASF tiene su propio sistema integrado para reaccionar adecuadamente a las peculiaridades de Steam, al final se conectará y reanudará su trabajo, por lo tanto no es necesario hacer nada si el problema es temporal. Reiniciar ASF para solucionar problemas mágicamente solo empeorará las cosas (ya que el nuevo ASF no sabrá el estado del anterior de no poder iniciar sesión, e intentará conectarse en lugar de esperar), así que evita hacer eso a menos que sepas lo que haces.

Finalmente, como con cada solicitud de Steam - ASF solo puede **intentar** iniciar sesión, usando tus credenciales proporcionadas. Si esa solicitud tiene éxito o no está fuera del alcance y la lógica de ASF - no hay bug, y nada puede ser solucionado ni mejorado en este sentido.

---

### `System.IO.IOException: Input/output error`

Si este error ocurrió durante la entrada de ASF (por ejemplo, puedes ver `Console.ReadLine()` en el stacktrace) entonces es causado por tu entorno el cual impide que ASF lea la entrada estándar de tu consola. Esto puede ocurrir debido a muchas razones, pero la más común es que ejecutes ASF en el entorno incorrecto (por ejemplo, en `nohup` o `&` en segundo plano en lugar de `screen` en Linux). Si ASF no puede acceder a su entrada estándar, entonces verás este error registrado y la incapacidad de ASF de usar tus datos durante el tiempo de ejecución.

Si **esperas** que esto suceda, quiere decir que **pretendes** ejecutar ASF en un entorno sin entrada, entonces debes indicarle explícitamente a ASF que ese es el caso, estableciendo correctamente el modo **[`Headless`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-es-ES#headless)**. Esto le indicará a ASF que nunca solicite interacción del usuario bajo ninguna circunstancia, permitiéndote ejecutar ASF en entornos sin entrada de forma segura.

---

### `System.Net.Http.WinHttpException: A security error occurred`

Este error ocurre cuando ASF no puede establecer una conexión segura con un servidor dado, casi siempre debido a problemas con los certificados SSL.

En casi todos los casos este error es causado por **fecha/hora incorrecta en tu máquina**. Cada certificado SSL tiene un fecha de emisión y de caducidad. Si tu fecha no es válida y está fuera de esos dos límites entonces no se puede confiar en el certificado debido a un potencial ataque **[MITM](https://es.wikipedia.org/wiki/Ataque_de_intermediario)** y ASF se niega a establecer una conexión.

La solución obvia es establecer correctamente la fecha en tu máquina. Es altamente recomendable usar la sincronización de fecha automática, como la sincronización nativa disponible en Windows, o `ntpd` en Linux.

Si te aseguraste de que la fecha en tu máquina es correcta y el error no desaparece, los certificados SSL en los que confía tu sistema podrían estar desactualizados o ser no válidos. En este caso debes asegurarte de que tu máquina puede establecer conexiones seguras, por ejemplo, comprobando si puedes acceder a `https://github.com` con cualquier explorador, o con una herramienta CLI como `curl`. Si confirmas que esto funciona correctamente, siéntete libre de publicar el problema en nuestro grupo de Steam.

---

### `System.Threading.Tasks.TaskCanceledException: A task was canceled`

Esta advertencia significa que Steam no respondió a la solicitud de ASF en un tiempo determinado. Generalmente es causado por errores en la red de Steam y no afecta a ASF de ninguna manera. En otros casos es lo mismo que la solicitud fallando después de 5 intentos. Reportar este error no tienen sentido la mayoría del tiempo, ya que no podemos forzar a Steam a responder a nuestras solicitudes.

---

### `The type initializer for 'System.Security.Cryptography.CngKeyLite' threw an exception`

Este problema es casi exclusivamente causado porque el servicio de Windows `CNG Key Isolation` se ha desactivado/detenido, este proporciona la funcionalidad de criptografía para ASF, y sin el cual el programa no puede ejecutarse. Puedes solucionar este problema ejecutando `services.msc` y asegurarte de que el servicio de Windows `CNG Key Isolation` no tiene el inicio deshabilitado y que se encuentra en ejecución.

---

### ¡ASF está siendo detectado como malware por mi AntiVirus! ¿Qué está pasando?

**Asegúrate de que descargaste ASF de una fuente confiable**. La única fuente oficial y de confianza es la página de **[lanzamientos de ASF](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** en GitHub (esta también es la fuente para las actualizaciones automáticas de ASF) - **cualquier otra fuente no es de confianza por definición y puede contener malware agregado por otras personas** - no debes confiar en ninguna otra ubicación de descarga por definición, y asegúrate de que tu ASF siempre viene de nosotros.

Si confirmas que ASF fue descargado de una fuente confiable, entonces muy probablemente solo se trate de un falso positivo. Esto **ha pasado antes**, **ocurre actualmente**, **y seguirá pasando en el futuro**. Si te preocupa la seguridad real al usar ASF, sugiero escanear ASF con varios antivirus diferentes para un ratio de detección real, por ejemplo con **[VirusTotal](https://www.virustotal.com)** (o cualquier otro servicio web de tu elección).

Si el antivirus que usas falsamente detecta ASF como malware, entonces **es buena idea enviar una muestra del archivo a los desarrolladores de tu antivirus, para que puedan analizarla y mejorar su motor de detección**, ya que claramente no está funcionando tan bien como crees. No hay ningún problema en el código de ASF, y tampoco hay nada para que arreglemos, ya que no estamos distribuyendo malware en primer lugar, por lo tanto no tiene sentido reportar esos falsos positivos. Recomendamos enviar una muestra de ASF para mayor análisis como se mencionó antes, pero si no quieres tomarte la molestia, puedes añadir ASF a las excepciones del antivirus, desactivar tu antivirus o simplemente usar otro. Lamentablemente, estamos acostumbrados a que los antivirus sean estúpidos, ya que de vez en cuando algún antivirus detecta ASF como virus, lo que normalmente dura muy poco y es solucionado pronto por los desarrolladores, pero como mencionamos anteriormente - **ha sucedido**, **sucede** y **sucederá** todo el tiempo. ASF no incluye ningún código malicioso, puedes revisar el código de ASF e incluso compilarlo desde la fuente. No somos hackers para oscurecer el código de ASF para ocultarlo del análisis de los antivirus o de los falsos positivos, así que no esperes que arreglemos lo que no está roto - no hay ningún "virus" que podamos solucionar.