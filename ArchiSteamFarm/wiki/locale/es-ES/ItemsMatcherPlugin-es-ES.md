# ItemsMatcherPlugin

`ItemsMatcherPlugin` es un **[plugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins-es-ES)** oficial de ASF que lo amplía con las funciones del listado ASF STM. En particular, esto incluye `PublicListing` en **[`RemoteCommunication`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-es-ES#remotecommunication)** y `MatchActively` en **[`TradingPreferences`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-es-ES#tradingpreferences)**. ASF viene con `ItemsMatcherPlugin` integrado, por lo tanto está listo para usarlo inmediatamente.

---

## `PublicListing`

La lista pública, como su nombre implica , es un listado de los bots ASF STM disponibles actualmente. Se ubica en **[nuestro sitio web](https://asf.justarchi.net/STM)**, es administrada automáticamente y usada como un servicio público tanto para usuarios de ASF que hacen uso de `MatchActively`, así como para usuarios y no usuarios de ASF para emparejamiento manual.

Para ser listado, tienes que cumplir algunos requisitos. At the minimum you must have allowed `PublicListing` in `RemoteCommunication` (default setting), `SteamTradeMatcher` enabled in `TradingPreferences`, **[public inventory](https://steamcommunity.com/my/edit/settings)** privacy settings, **[unrestricted](https://help.steampowered.com/faqs/view/71D3-35C2-AD96-AA3A)** account and **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication#asf-2fa)** active. Requisitos adicionales incluyen 2FA activo por lo menos 15 días, último cambio de contraseña superior a 5 días, no tener limitaciones de cuenta como bloqueos, baneos del mercado y de intercambio. Naturalmente, también debes tener al menos un artículo de los especificados en `MatchableTypes`, tal como los cromos. Adicionalmente, los bots con más de `500000` artículos no son aceptados debido a que implica una sobrecarga excesiva, recomendamos dividir tu inventario entre varias cuentas en este caso.

Mientras que `PublicListing` está habilitado por defecto, ten en cuenta que **no** serás mostrado en el sitio web si no cumples todos los requisitos, especialmente `SteamTradeMatcher`, el cual no está habilitado por defecto. Para las personas que no cumplen los criterios, incluso si mantienen `PublicListing`  habilitado, ASF no se comunica con el servidor de ninguna manera. Además, la lista pública solo es compatible con la última versión estable de ASF y podría negarse a mostrar bots desactualizados, especialmente si carecen de alguna funcionalidad crucial que solo se encuentra en las versiones más recientes.

### Cómo funciona exactamente

ASF envía información inicial después de iniciar sesión, que contiene todas las propiedades de las que hace uso la lista pública. Luego, cada 10 minutos ASF envía una pequeña solicitud "latido" que notifica a nuestro servidor que el bot todavía está funcionando. Si por alguna razón el latido no llega, por ejemplo debido a problemas de red, entonces ASF intentará enviarlo cada minuto, hasta que el servidor lo registre. De esta manera nuestro servidor sabe con precisión qué bots se están ejecutando todavía y están listos para aceptar ofertas de intercambio. ASF también enviará un anuncio inicial según sea necesario, por ejemplo, si detecta que nuestro inventario ha cambiado desde la vez anterior.

Mostramos todas las cuentas ASF 2FA+STM que estaban activas en los **últimos 15 minutos**. Los usuarios se ordenan de acuerdo a su utilidad relativa - los bots con `MatchEverything` que se muestran con la etiqueta `Any` que aceptan todos los intercambios 1:1, luego por cantidad de juegos únicos, y finalmente por cantidad de artículos.

### API

La lista ASF STM solo acepta bots de ASF por el momento. No hay forma de listar bots de terceros por ahora, ya que no podemos revisar fácilmente su código y asegurar que cumplen con nuestra lógica de intercambio. Por lo tanto, participar en la lista requiere la última versión estable de ASF, aunque puede ejecutarse con **[plugins](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins-es-ES)**. personalizados.

Para los consumidores de la lista, tenemos un endpoint **[`/Api/Listing/Bots`](https://asf.justarchi.net/Api/Listing/Bots)** bastante sencillo que pueden usar. Incluye toda la información que tenemos, excepto los inventarios de los usuarios que son parte de la función `MatchActively` exclusivamente.

### Política de privacidad

Si aceptas aparecer en nuestro listado, habilitando `SteamTradeMatcher` y no rechazando `PublicListing`, como se especificó anteriormente, almacenaremos temporalmente en nuestro servidor algunos detalles de tu cuenta de Steam para proporcionar la funcionalidad esperada.

La información pública (expuesta por Steam a todas las partes interesadas) incluye:
- Tu identificador de Steam (en forma de 64 bits, para generar enlaces)
- Tu nickname (para fines de visualización)
- Tu avatar (para fines de visualización)

La información pública condicional (expuesta por Steam a todos los interesados si cumples los requisitos para ser listado) incluye:
- Tu **[inventario](https://steamcommunity.com/my/inventory/#753_6)** (para que otros puedan usar `MatchActively` con tus artículos).

La información privada (datos seleccionados necesarios para proporcionar la funcionalidad) incluye:
- Tu **[token de intercambio](https://steamcommunity.com/my/tradeoffers/privacy)** (para que las personas fuera de tu lista de amigos puedan enviarte intercambios)
- Tu configuración de `MatchableTypes` (para fines de visualización y emparejamiento)
- Tu configuración de `MatchEverything` (para fines de visualización y emparejamiento)
- Tu configuración de `MaxTradeHoldDuration` (para que otros sepan si estás dispuesto a aceptar sus intercambios)

Tus datos se almacenan durante un máximo de dos semanas desde que dejas de usar (anunciarte) nuestro listado, y se borra automáticamente después de ese tiempo.

---

## `MatchActively`

La configuración `MatchActively` es la versión activa de **[`SteamTradeMatcher`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading-es-ES#steamtradematcher)** la cual incluye emparejamiento interactivo donde el bot enviará intercambios a otras personas. Puede funcionar solo, o junto con el ajuste `SteamTradeMatcher`. Esta función requiere que se configure `LicenseID`, ya que utiliza servidores de terceros y recursos de pago para funcionar.

Para usar esa opción, tienes que cumplir ciertos requisitos. At the minimum you must have **[unrestricted](https://help.steampowered.com/faqs/view/71D3-35C2-AD96-AA3A)** account, **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication#asf-2fa)** active and at least one valid type in `MatchableTypes`, such as trading cards. Requisitos adicionales incluyen 2FA activo por lo menos 15 días, último cambio de contraseña superior a 5 días, no tener limitaciones de cuenta como bloqueos, baneos del mercado y de intercambio.

Si cumples todos los requisitios mencionados anteriormente, ASF se comunicará periódicamente con nuestra **[lista pública ASF STM](#publiclisting)** para emparejar activamente con los bots que estén disponibles actualmente.

Durante el emparejamiento, el bot de ASF obtendrá su propio inventario, luego se comunicará con nuestro servidor para encontrar todas las coincidencias posibles de los `MatchableTypes`, con otros bots disponibles actualmente. Gracias a la comunicación directa con nuestro servidor, este proceso requiere una sola solicitud e inmediatamente tenemos información sobre si hay algún bot disponible que pueda proporcionar algo que nos interese - si se encuentra una coincidencia, ASF enviará y confirmará la oferta de intercambio automáticamente.

Este módulo debe ser transparente. El emparejamiento comenzará en aproximadamente `1` hora desde el inicio de ASF, y se repetirá cada `6` horas (si es necesario). `MatchActively` está diseñado para usarse como una medida periódica y a largo plazo para asegurar que estamos avanzando activamente hacia completar sets, sin embargo, las personas que no ejecuten ASF 24/7 pueden considerar el uso del **[comando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-es-ES)** `match`. Los usuarios objetivo de este módulo son cuentas principales y cuentas alternas usadas para "almacenar", aunque puede ser usado por cualquier bot que no esté configurado a `MatchEverything`. Adicionalmente, los bots con más de `500000` artículos no son aceptados para emparejamiento debido a que implica una sobrecarga excesiva, recomendamos dividir tu inventario entre varias cuentas en este caso.

ASF hace todo lo posible para minimizar la cantidad de solicitudes y presión generada por usar esta opción, al mismo tiempo que maximiza la eficiencia del emparejamiento. El algoritmo exacto para elegir los bots a emparejar y organizar todo el proceso, es un detalle de implementación de ASF y puede cambiar por la retroalimentación, la situación y posibles futuras ideas.

La versión actual del algoritmo hace que ASF dé prioridad a bots `Any`, especialmente aquellos con mejor diversidad de juegos de los que provienen sus artículos. Si se agotan los bots `Any`, ASF pasará a los `Fair` bajo la misma regla de diversidad. ASF intentará emparejar con todos los bots disponibles al menos una vez, para asegurar que no perdemos un posible progreso en algún set de cromos, emoticons, etc.

`MatchActively` toma en cuenta los bots que bloqueaste del intercambio a través del **[comando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-es-ES)** `tbadd` y no intentará emparejar activamente con ellos. Esto puede ser usado para decirle a ASF con qué bots nunca debería emparejar, incluso si tienen posibles duplicados que nos pudieran servir.

ASF también hará lo posible para asegurar que las ofertas de intercambio sean exitosas. En la siguiente ejecución, lo que normalmente ocurre en 6 horas, ASF cancelará cualquiera oferta de intercambio pendiente que todavía no haya sido aceptada, y le quitará prioridad a los steamIDs que participen en ellas para preferir bots más activos. Aún así, si los bots despriorizados son los últimos que tienen el artículo que necesitamos, intentaremos emparejar con ellos (nuevamente).

---

### ¿Por qué necesito un `LicenseID` para usar `MatchActively`? ¿Antes no era gratis?

ASF es, y sigue siendo gratuito y de código abierto, tal como se estableció al inicio del proyecto en octubre de 2015. El código fuente del plugin `ItemsMatcher` y por lo tanto de la función `MatchActively` está disponible en nuestro repositorio, mientras que ASF es completamente no comercial, no ganamos nada de las contribuciones a este, su compilación o publicación. En los últimos 7 años ASF ha recibido una increíble cantidad de desarrollo, y todavía sigue siendo mejorado con cada versión estable mensual mayormente por una sola persona, **[JustArchi](https://github.com/JustArchi)** - sin ningún tipo de compromiso. La única financiación que recibimos proviene de donaciones no obligatorias de nuestros usuarios.

Durante mucho tiempo, hasta octubre de 2022, la función `MatchActively` era parte del núcleo de ASF y estaba disponible para todos. En octubre de 2022, Valve, la compañía detrás de Steam, estableció un límite de solicitudes muy estricto para analizar el inventario de otros bots - lo que causó que la funcionalidad anterior se rompiera por completo, sin posibilidad de una solución para este problema. Por lo tanto, debido a que la función se volvió extinta y sin ninguna posibilidad de ser reparada, tuvo que ser eliminada de ASF por resultar obsoleta.

`MatchActively` fue resucitado como parte del plugin oficial `ItemsMatcher` que mejora ASF aún más con la funcionalidad de emparejamiento activo de cromos. Traer de vuelta la función `MatchActively` requirió una **extraordinaria cantidad de trabajo** para crear el backend de ASF, un servicio completamente nuevo hospedado en un servidor, con más de cien proxies de pago para analizar los inventarios, todo ello exclusivamente para permitir que los clientes de ASF puedan usar `MatchActively` como antes. Debido a la cantidad de trabajo involucrado, así como al uso de recursos que no son gratuitos y requieren ser pagados mensualmente (dominio, servidor, proxies), hemos decidido ofrecer esta funcionalidad a nuestros patrocinadores, es decir, las personas que ya apoyan el proyecto ASF de forma mensual, gracias a quienes podemos hacer que esos recursos estén disponibles.

Nuestro objetivo no es beneficiarnos de ello, sino cubrir los **costos mensuales** vinculados exclusivamente con ofrecer esta opción - por eso la ofrecemos por básicamente nada, pero tenemos que cobrar un poco ya que no podemos pagar cientos de dólares de nuestros propios bolsillos cada mes, solo para que la tengas disponible. Tampoco estamos en posición de discutir el precio, fue Valve quien nos forzó a cubrir esos costos, y la alternativa es no tener dicha característica disponible, lo que aplica si decides, por cualquier razón, que no puedes justificar usar nuestro plugin en esos términos.

En cualquier caso, entendemos que `MatchActively` no es para todos, y esperamos que también entiendas por qué no podemos ofrecerla gratuitamente

---

### ¿Cómo puedo obtener acceso?

`ItemsMatcher` se ofrece como parte del nivel de patrocinio mensual de $5+ en el **[GitHub de JustArchi](https://github.com/sponsors/JustArchi)**. También es posible ser patrocinador por una ocasión, aunque en este caso la licencia solo será válida durante un mes (con posibilidad de ampliación de la misma manera). Una vez que seas patrocinador de nivel $5 (o superior), lee la sección de **[configuración](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-es-ES#licenseid)** para obtener y establecer `LicenseID`. Posteriormente, solo necesitas habilitar `MatchActively` en `TradingPreferences` de tu bot elegido.

La licencia te permite enviar una cantidad limitada de solicitudes al servidor. El nivel de $5 te permite usar `MatchActively` para una cuenta boy (4 solicitudes diarias), y cada $5 adicionales añaden dos cuentas más (8 solicitudes diarias). Por ejemplo, si quieres ejecutarlo en tres cuentas, eso lo cubrirá el nivel de $10 y superiores.