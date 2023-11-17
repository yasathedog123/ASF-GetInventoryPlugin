# SteamTokenDumperPlugin

`SteamTokenDumperPlugin` es un **[plugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins-es-ES)** oficial para ASF, disponible a partir de ASF V4.2.2, desarrollado por nosotros, el cual te permite contribuir al proyecto **[SteamDB](https://steamdb.info)** compartiendo tokens de paquetes, tokens de aplicaciones y claves de depósito a los que tiene acceso tu cuenta de Steam. La información extendida de los datos recolectados y por qué SteamDB los necesita se puede encontrar en la página **[Token Dumper](https://steamdb.info/tokendumper)** de SteamDB. Los datos enviados no incluyen ninguna información potencialmente sensible, y no presenta riesgo de seguridad/privacidad, como se indica en la descripción previa.

---

## Habilitando el plugin

ASF viene con `SteamTokenDumperPlugin` incluido, pero el plugin en sí está deshabilitado por defecto. Puedes habilitar el plugin estableciendo la propiedad de configuración global de ASF `SteamTokenDumperPluginEnabled` al valor `true`, en sintaxis JSON:

```json
{
  "SteamTokenDumperPluginEnabled": true
}
```

Al ejecutarse ASF, el plugin te hará saber si fue habilitado exitosamente a través del mecanismo estándar de registro de ASF. También puedes habilitar el plugin a través de nuestro generador de configuración web.

---

## Detalles técnicos

Después de habilitarlo, el plugin usará los bots que estés ejecutando en ASF para recolectar datos en forma de tokens de paquetes, tokens de aplicaciones y claves de depósito a los que tienen acceso tus bots. El módulo de recolección de datos incluye rutinas pasivas y activas que deben minimizar la sobrecarga adicional causada por la recolección de datos.

Para lograr el caso de uso previsto, además de la rutina de recolección de datos explicada anteriormente, la rutina de envío es inicializada como responsable de determinar qué datos necesitan ser enviados a SteamDB de forma periódica. Esta rutina se iniciará hasta `1` hora después de la ejecución de ASF, y se repetirá cada `24` horas. El plugin hará todo lo posible para minimizar la cantidad de datos que necesitan ser enviados, por lo que es posible que alguna información recolectada por el plugin sea marcada como no necesaria para enviar, y por lo tanto será omitida (por ejemplo, actualizaciones de la aplicación que no cambian el token de acceso).

El plugin utiliza una base de datos de caché persistente guardada en la ubicación `config/SteamTokenDumper.cache`, que tiene un propósito similar a `config/ASF.db` para ASF. El archivo se utiliza para registrar los datos recolectados y enviados, y minimizar la cantidad de trabajo necesario entre diferentes ejecuciones de ASF. Eliminar el archivo hace que el proceso se reinicie desde cero, lo que debe evitarse si es posible.

---

## Datos

ASF incluye el `steamID` del colaborador en la solicitud, el cual se determina con el `SteamOwnerID` que estableces en ASF, o en caso de que no lo hayas hecho, el Steam ID del bot que tenga más licencias. El colaborador podría recibir algunos beneficios adicionales de SteamDB por la ayuda continua (por ejemplo, el rango de donador en el sitio web), pero eso es totalmente a discreción de SteamDB.

En cualquier caso, el personal de SteamDB te agradece de antemano por tu ayuda. Los datos enviados permiten que SteamDB funcione, en particular para rastrear información de paquetes, aplicaciones y depósitos, lo que ya no sería posible sin tu ayuda.

---

## Configuración avanzada

A partir de ASF V5.1.0.0, nuestro plugin soporta una configuración avanzada que puede resultar útil para las personas que deseen ajustar la configuración interna del plugin a su preferencia.

La configuración avanzada tiene la siguiente estructura en el archivo `ASF.json`:

```json
{
  "SteamTokenDumperPlugin": {
    "Enabled": false,
    "SecretAppIDs": [],
    "SecretDepotIDs": [],
    "SecretPackageIDs": [],
    "SkipAutoGrantPackages": true
  }
}
```

Todas las opciones se explican a continuación:

### `Enabled`

Tipo `bool` con valor predeterminado de `false`. Esta propiedad actúa igual que `SteamTokenDumperPluginEnabled` explicada anteriormente, y puede ser usada en su lugar, está dirigida a las personas que prefieren tener toda la configuración del plugin en su propia estructura (así que probablemente ya estén usando las demás opciones avanzadas explicadas a continuación).

---

### `SecretAppIDs`

Tipo `ImmutableHashSet<uint>` con valor predeterminado estando vacío. Esta propiedad especifica las `appIDs` que el plugin no analizará, y si ya han sido analizadas, no enviará el token. Esta propiedad puede ser útil para personas con acceso a información potencialmente confidencial acerca de artículos no publicados, especialmente desarrolladores, editores o probadores de betas cerradas.

---

### `SecretDepotIDs`

Tipo `ImmutableHashSet<uint>` con valor predeterminado estando vacío. Esta propiedad especifica los `depotIDs` que el plugin no analizará, y si ya han sido analizados, no enviará la clave. Esta propiedad puede ser útil para personas con acceso a información potencialmente confidencial acerca de artículos no publicados, especialmente desarrolladores, editores o probadores de betas cerradas.

---

### `SecretPackageIDs`

Tipo `ImmutableHashSet<uint>` con valor predeterminado estando vacío. Esta propiedad especifica los `packageIDs` (también conocidos como `subIDs`) que el plugin no analizará, y si ya han sido analizados, no enviará el token. Esta propiedad puede ser útil para personas con acceso a información potencialmente confidencial acerca de artículos no publicados, especialmente desarrolladores, editores o probadores de betas cerradas.

---

### `SkipAutoGrantPackages`

Tipo `bool` con valor predeterminado de `true`. Esta propiedad actúa muy similar a `SecretPackageIDs` y cuando está habilitada, causará que los paquetes con `EPaymentMethod` de `AutoGrant` sean omitidos durante la rutina de análisis explicada abajo. El método de pago `AutoGrant` es usado por **[Steamworks](https://partner.steamgames.com)** para otorgar automáticamente paquetes a cuentas de desarrolladores. Aunque esto no es tan explícito como otras opciones `Secret`, y por lo tanto no garantiza nada (ya que podrías tener otros paquetes que no sean `AutoGrant` que no deseas enviar), debería ser suficiente para omitir la mayoría, si no todos, los paquetes secretos. Esta opción está habilitada por defecto, ya que las personas que tienen acceso a paquetes `AutoGrant` casi nunca querrán filtrarlos al público general, y por lo tanto usar el valor `false` es para situaciones muy específicas.

---

## Explicación adicional

En términos generales, cada cuenta de Steam posee un conjunto de paquetes (licencias, suscripciones), que se clasifican por su `packageID` (también conocido como `subID`). Cada paquete puede contener varias aplicaciones clasificadas por su `appID`. Cada aplicación puede incluir varios depósitos clasificados por su `depotID`.

```text
├── sub/124923
│     ├── app/292030
│     │     ├── depot/292031
│     │     ├── depot/378648
│     │     └── ...
│     ├── app/378649
│     └── ...
└── ...
```

Nuestro plugin incluye dos rutinas que toman en cuenta artículos omitidos - la rutina de análisis y la de envío.

La rutina de análisis es responsable de determinar la estructura de árbol que puedes ver arriba. Al bloquear los paquetes/aplicaciones/depósitos de antemano, cortarás efectivamente el árbol en el lugar de la rama/hoja bloqueada sin necesidad de especificar las partes restantes. En nuestro ejemplo anterior, si el paquete `124923` es ignorado, ya sea por `SecretPackageIDs` o `SkipAutoGrantPackages`, y es el único paquete que posees que vincula a la appID `292030`, entonces la appID `292030` tampoco sería analizada, y por definición, si no hubiera otras aplicaciones analizadas que vinculen a los depósitos `292031` y `378648`, entonces estos tampoco serían analizados. Sin embargo, ten en cuenta que si el plugin ya ha analizado la estructura de árbol, esto solo evitará que un artículo determinado sea actualizado (por ejemplo, nuevas aplicaciones añadidas), no hará que el plugin "olvide" artículos existentes que ya fueron analizados (por ejemplo, aplicaciones encontradas en el paquete antes de que decidieras incluirlo en la lista negra). Si acabas de habilitar algunas opciones de omisión, y quieres asegurarte de que ASF no analice el árbol ya resuelto, considera eliminar por única vez el archivo `config/SteamTokenDumper.cache` donde el plugin almacena su caché.

La rutina de envío es responsable de enviar los tokens de paquete, tokens de aplicaciones y claves de depósito de los artículos ya analizados (por la rutina de análisis explicada anteriormente). Aquí tu lista negra tiene efecto inmediato, ya que incluso si el plugin ha analizado la información, la rutina de envío no la enviará a SteamDB si la añadiste a la lista negra, independientemente de si ha sido analizada o no. Sin embargo, ten en cuenta que en este momento no estamos hablando de la estructura de árbol, la rutina de envío no sabe si la información de la aplicación viene de un paquete u otro, así que solo omite la información de artículos particulares incluidos en la lista negra, independientemente de la relación que tienen con otros.

Para la mayoría de los desarrolladores y editores, debería ser suficiente con habilitar `SkipAutoGrantPackages`, y potencialmente apoyarse solo con `SecretPackageIDs`, ya que esto corta efectivamente el árbol en la rama inicial y garantiza que las aplicaciones y depósitos incluidos no se enviarán mientras no haya otro paquete vinculando a la misma aplicación. Si quieres estar doblemente seguro, además puedes usar `SecretAppIDs`, lo que omitirá el análisis de la aplicación incluso si hay otras licencias vinculando a ella que no hayas incluido en la lista negra. No debería ser necesario usar `SecretDepotIDs`, a menos que tengas una necesidad particular y específica (tal como omitir solo un depósito en particular y seguir enviando información de paquetes y aplicaciones), o si deseas añadir otra capa para estar triplemente seguro.