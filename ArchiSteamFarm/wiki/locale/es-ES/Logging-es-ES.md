# Registro

ASF te permite configurar tu propio módulo de registro que será usado durante el tiempo de ejecución. Lo puedes hacer colocando un archivo especial llamado `NLog.config` en el directorio de la aplicación. Puedes leer toda la documentación de NLog en **[NLog wiki](https://github.com/NLog/NLog/wiki/Configuration-file)**, donde también encontrarás algunos ejemplos útiles.

---

## Registro por defecto

Por defecto, ASF registra a `ColoredConsole` (salida estándar) y a `File`. El registro en `File` incluye el archivo `log.txt` en el directorio del programa, y el directorio `logs` con el propósito de archivar.

Usar una configuración NLog personalizada automáticamente desactiva el registro por defecto de ASF, tu configuración anula **por completo** el registro predeterminado de ASF, lo que significa que si quieres mantener, por ejemplo, el objetivo `ColoredConsole`, entonces debes definirlo **tú mismo**. Esto te permite no solo añadir objetivos de registro **adicionales**, sino también desactivar o modificar los **predeterminados**.

Si quieres usar el registro por defecto de ASF sin modificaciones, no necesitas hacer nada - tampoco necesitas definirlo en `NLog.config`. No uses un `NLog.config` personalizado si no quieres modificar el registro predeterminado de ASF. Para referencia, el equivalente del registro predeterminado de ASF sería:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" layout="${date:format=yyyy-MM-dd HH\:mm\:ss}|${processname}-${processid}|${level:uppercase=true}|${logger}|${message}${onexception:inner= ${exception:format=toString,Data}}" />
    <target xsi:type="File" name="File" archiveFileName="${currentdir}/logs/log.{#}.txt" archiveNumbering="Rolling" archiveOldFileOnStartup="true" cleanupFileName="false" concurrentWrites="false" deleteOldFileOnStartup="true" fileName="${currentdir}/log.txt" layout="${date:format=yyyy-MM-dd HH\:mm\:ss}|${processname}-${processid}|${level:uppercase=true}|${logger}|${message}${onexception:inner= ${exception:format=toString,Data}}" maxArchiveFiles="10" />

    <!-- Lo siguiente se activa cuando inicia la interfaz IPC de ASF -->
    <target type="History" name="History" layout="${date:format=yyyy-MM-dd HH\:mm\:ss}|${processname}-${processid}|${level:uppercase=true}|${logger}|${message}${onexception:inner= ${exception:format=toString,Data}}" maxCount="20" />
  </targets>

  <rules>
    <!-- Las siguientes entradas especifican el registro de eventos ASP.NET (IPC), las declaramos para que nuestro Debug no incluya los registros ASP.NET por defecto -->
    <logger name="Microsoft.*" finalMinLevel="Warn" writeTo="ColoredConsole" />
    <logger name="Microsoft.Hosting.Lifetime" finalMinLevel="Info" writeTo="ColoredConsole" />
    <logger name="System.*" finalMinLevel="Warn" writeTo="ColoredConsole" />

    <logger name="*" minlevel="Debug" writeTo="ColoredConsole" />

    <!-- Las siguientes entradas especifican el registro de eventos ASP.NET (IPC), las declaramos para que nuestro Debug no incluya los registros ASP.NET por defecto -->
    <logger name="Microsoft.*" finalMinLevel="Warn" writeTo="File" />
    <logger name="Microsoft.Hosting.Lifetime" finalMinLevel="Info" writeTo="File" />
    <logger name="System.*" finalMinLevel="Warn" writeTo="File" />

    <logger name="*" minlevel="Debug" writeTo="File" />

    <!-- Lo siguiente se activa cuando la interfaz IPC de ASF está habilitada -->
    <!-- Las siguientes entradas especifican el registro de eventos ASP.NET (IPC), las declaramos para que nuestro Debug no incluya los registros ASP.NET por defecto -->
    <logger name="Microsoft.*" finalMinLevel="Warn" writeTo="History" />
    <logger name="Microsoft.Hosting.Lifetime" finalMinLevel="Info" writeTo="History" />
    <logger name="System.*" finalMinLevel="Warn" writeTo="History" />

    <logger name="*" minlevel="Debug" writeTo="History" />
  </rules>
</nlog>
```

---

## Integración de ASF

ASF incluye algunos trucos de código que mejoran su integración con NLog, permitiéndote captar mensaje específicos con más facilidad.

La variable `${logger}` específica de NLog siempre distinguirá el origen del mensaje - será `BotName` de uno de tus bots, o `ASF` si el mensaje viene directamente del proceso de ASF. Así puedes captar mensajes fácilmente considerando bots específicos, o el proceso de ASF (solo), en lugar de todos ellos, basado en el nombre del logger.

ASF intenta marcar los mensaje de forma adecuada basándose en los niveles de registro proporcionados por NLog, lo que hace posible captar solo mensajes específicos de niveles de registro específicos en lugar de todos ellos. Por supuesto, el nivel de registro para un mensaje específico no puede ser personalizado, ya que es decisión de ASF qué tan importante es un mensaje determinado, pero definitivamente puedes hacer a ASF menos/más silencioso, como te parezca oportuno.

ASF registra información adicional, tal como mensajes de usuario/chat en el nivel de registro `Trace`. El registro por defecto de ASF solo registra el nivel `Debug` y superior, el cual oculta esa información adicional, ya que no es necesaria para la mayoría de los usuarios, además de que se opacan mensajes potencialmente más importantes. Sin embargo puedes usar esa información reactivando el nivel de registro `Trace`, especialmente en combinación con registrar solo un bot específico de tu elección, con el evento particular en el que estás interesado.

En general, ASF intenta hacerlo tan fácil y conveniente como sea posible, registrar solo los mensajes que quieres en lugar de obligarte a filtrarlos manualmente mediante herramientas de terceros como `grep` y similares. Simplemente configura NLog correctamente como se describe a continuación, y deberías poder especificar incluso reglas de registro muy complejas con objetivos personalizados tal como bases de datos enteras.

En cuanto a la versión - ASF siempre intenta contar con la versión más actualizada de NLog que esté disponible en **[NuGet](https://www.nuget.org/packages/NLog)** al momento de la publicación de ASF. No debería haber problema por usar en ASF cualquier característica que puedas encontrar en la wiki de NLog - solo asegúrate de que también estás usando ASF actualizado.

Como parte de la integración, ASF también incluye soporte para objetivos de registro ASF NLog adicionales, lo que se explica abajo.

---

## Ejemplos

Empecemos con algo sencillo. Solo usaremos el objetivo **[ColoredConsole](https://github.com/nlog/nlog/wiki/ColoredConsole-target)**. Nuestro `NLog.config` inicial se verá así:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" />
  </targets>

  <rules>
    <logger name="*" minlevel="Debug" writeTo="ColoredConsole" />
  </rules>
</nlog>
```

La explicación de la configuración de arriba es bastante sencilla - definimos un **objetivo de registro**, que es `ColoredConsole`, luego redirigimos **todos los loggers** (`*`) de nivel `Debug` y superior al objetivo `ColoredConsole` que definimos previamente. Eso es todo.

Si inicias ASF con el `NLog.config` de arriba, solo el objetivo `ColoredConsole` estará activo, y ASF no escribirá a `File`, independientemente de la configuración de NLog codificada dentro de ASF.

Ahora digamos que no nos gusta el formato de `${longdate}|${level:uppercase=true}|${logger}|${message}` y solo queremos registrar el mensaje. Lo podemos hacer modificando el **[Layout](https://github.com/nlog/nlog/wiki/Layouts)** de nuestro objetivo.

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" layout="${message}" />
  </targets>

  <rules>
    <logger name="*" minlevel="Debug" writeTo="ColoredConsole" />
  </rules>
</nlog>
```

Si inicias ASF ahora, notarás que desapareció la fecha, el nivel y nombre del logger - dejando solo mensajes de ASF en formato `Function() Message`.

También podemos modificar la configuración para registrar a más de un objetivo. Vamos a registrar a `ColoredConsole` y **[`File`](https://github.com/nlog/nlog/wiki/File-target)** al mismo tiempo.

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" />
    <target xsi:type="File" name="File" fileName="${currentdir}/NLog.txt" deleteOldFileOnStartup="true" />
  </targets>

  <rules>
    <logger name="*" minlevel="Debug" writeTo="ColoredConsole" />
    <logger name="*" minlevel="Debug" writeTo="File" />
  </rules>
</nlog>
```

Y listo, ahora registraremos todo a `ColoredConsole` y `File`. ¿Notaste que también puedes especificar un `fileName` personalizado y opciones adicionales?

Por último, ASF usa varios niveles de registro, para facilitar que entiendas lo que está sucediendo. Podemos usar esa información para modificar la severidad del registro. Digamos que queremos registrar todo (`Trace`) a `File`, pero solo el **[nivel de registro](https://github.com/NLog/NLog/wiki/Configuration-file#log-levels)** `Warning` y superior a `ColoredConsole`. Podemos lograrlo modificando nuestras `rules` reglas:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" />
    <target xsi:type="File" name="File" fileName="${currentdir}/NLog.txt" deleteOldFileOnStartup="true" />
  </targets>

  <rules>
    <logger name="*" minlevel="Warn" writeTo="ColoredConsole" />
    <logger name="*" minlevel="Trace" writeTo="File" />
  </rules>
</nlog>
```

Eso es todo, ahora `ColoredConsole` solo mostrará advertencias y superior, mientras que todavía registra todo a `File`. Puedes modificarlo aún más para registrar, por ejemplo solo `Info` e inferior, y así por el estilo.

Finalmente, hagamos algo un poco más avanzado y vamos a registrar todos los mensajes al archivo, pero solo del bot llamado `LogBot`.

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" />
    <target xsi:type="File" name="LogBotFile" fileName="${currentdir}/LogBot.txt" deleteOldFileOnStartup="true" />
  </targets>

  <rules>
    <logger name="*" minlevel="Debug" writeTo="ColoredConsole" />
    <logger name="LogBot" minlevel="Trace" writeTo="LogBotFile" />
  </rules>
</nlog>
```

Puedes ver cómo usamos la integración de ASF y fácilmente distinguimos la fuente del mensaje con base en la propiedad `${logger}`.

---

## Uso avanzado

Los ejemplos anteriores son bastante sencillos y hechos para mostrarte lo fácil que es definir tus propias reglas de registro que pueden ser usadas con ASF. Puedes usar NLog para diferentes cosas, incluyendo objetivos complejos (tal como mantener los registros en `Database`), rotación de registros (tal como eliminar registros `File` viejos), usar `Layout` personalizados, declarar tus propios filtros de registro `<when>` y mucho más. Te animo a leer toda la **[documentación de NLog](https://github.com/nlog/nlog/wiki/Configuration-file)** para aprender sobre cada opción disponible, permitiéndote modificar el módulo de registro de ASF de la forma que quieras. Es una herramienta muy potente y personalizar el registro de ASF nunca fue tan fácil.

---

## Limitaciones

ASF desactivará temporalmente **todas** las reglas que incluyan los objetivos `ColoredConsole` o `Console` cuando esté esperando interacción del usuario. Por lo tanto, si quieres seguir registrando para otros objetivos incluso cuando ASF espera interacción del usuario, debes definir esos objetivos con sus propias reglas, como se mostró en los ejemplos anteriores, en lugar de poner muchos objetivos en `writeTo` de la misma regla (a menos que este sea el comportamiento deseado). La desactivación temporal de los objetivos de la consola se hace para mantenerla limpia cuando se está esperando interacción del usuario.

---

## Registro de chat

ASF incluye soporte extendido para registro de chat no solo registrando todos los mensajes recibidos/enviados en el nivel de registro `Trace`, sino también exponiendo información adicional relacionada con ellos en las **[propiedades de evento](https://github.com/NLog/NLog/wiki/EventProperties-Layout-Renderer)**. Esto es porque de todos modos necesitamos manejar los mensajes de chat como comandos, así que no nos cuesta nada registrar esos eventos para hacer posible que añadas una lógica adicional (tal como hacer ASF tu archivo personal de conversaciones de Steam).

### Propiedades de evento

| Nombre      | Descripción                                                                                                                                                                                                                                                      |
| ----------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Echo        | Tipo `bool`. Se establece a `true` cuando el mensaje se envía desde nosotros al destinatario, y `false` de lo contrario.                                                                                                                                         |
| Message     | Tipo `string`. Este es el mensaje enviado/recibido.                                                                                                                                                                                                              |
| ChatGroupID | Tipo `ulong`. Este es el ID del chat de grupo para mensajes enviados/recibidos. Será `0` cuando no se use ningún chat de grupo para transmitir este mensaje.                                                                                                     |
| ChatID      | Tipo `ulong`. Este es el ID del canal `ChatGroupID` para mensajes enviados/recibidos. Será `0` cuando no se use ningún chat de grupo para transmitir este mensaje.                                                                                               |
| SteamID     | Tipo `ulong`. Este es el ID del usuario de Steam para mensajes enviados/recibidos. Puede ser `0` cuando ningún usuario en particular está involucrado en la transmisión del mensaje (por ejemplo, cuando somos nosotros enviando un mensaje a un chat de grupo). |

### Ejemplo

Este ejemplo se basa en nuestro ejemplo básico de `ColoredConsole` que se mostró antes. Antes de intentar entenderlo, te recomiendo echar un vistazo **[arriba](#ejemplos)** para aprender primero los fundamentos del registro NLog.

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" />
    <target xsi:type="File" name="ChatLogFile" fileName="${currentdir}/${event-properties:item=ChatGroupID}-${event-properties:item=ChatID}${when:when='${event-properties:item=ChatGroupID}' == 0:inner=-${event-properties:item=SteamID}}.txt" layout="${date:format=yyyy-MM-dd HH\:mm\:ss} ${event-properties:item=Message} ${when:when='${event-properties:item=Echo}' == true:inner=-&gt;:else=&lt;-} ${event-properties:item=SteamID}" />
  </targets>

  <rules>
    <logger name="*" minlevel="Debug" writeTo="ColoredConsole" />
    <logger name="MainAccount" level="Trace" writeTo="ChatLogFile">
      <filters defaultAction="Log">
        <when condition="not starts-with('${message}','OnIncoming') and not starts-with('${message}','SendMessage')" action="Ignore" />
      </filters>
    </logger>
  </rules>
</nlog>
```

Hemos empezado desde nuestro ejemplo básico de `ColoredConsole` y lo hemos extendido. En primer lugar, hemos preparado un archivo de registro de chat permanente por cada canal de grupo y usuario de Steam - esto es posible gracias a las propiedades adicionales que ASF nos expone de manera elegante. También nos hemos decidido por un layout personalizado que solo escribe la fecha actual, el mensaje, información enviada/recibida y el usuario de Steam. Por último, hemos habilitado nuestra regla de registro de chat para el nivel `Trace`, solo para nuestro bot `MainAccount` y solo para funciones relacionadas con el registro de chat (`OnIncoming*` que es usado para recibir mensajes y ecos, y `SendMessage*` para enviar mensajes de ASF).

El ejemplo anterior generará el archivo `0-0-76561198069026042.txt` al hablar con **[ArchiBot](https://steamcommunity.com/profiles/76561198069026042)**:

```text
2018-07-26 01:38:38 ¿cómo te va? -> 76561198069026042
2018-07-26 01:38:38 me va genial, ¿qué hay de ti? <- 76561198069026042
```

Claro que este solo es un ejemplo funcional con algunos trucos de layout mostrado de forma práctica. Puedes ampliar esta idea a tus propias necesidades, tal como filtrado extra, orden personalizado, un layout personal, grabar solo mensajes recibidos, etcétera.

---

## Objetivos de ASF

Además de los objetivos estándar de registro de NLog (tal como `ColoredConsole` y `File` explicados arriba), también puedes usar objetivos de registro de ASF personalizados.

Para máxima consistencia, la definición de los objetivos de ASF seguirá la convención de la documentación de NLog.

---

### SteamTarget

Como puedes adivinar, este objetivo utiliza mensajes de chat de Steam para registrar mensajes de ASF. Puedes configurarlo para usar un chat de grupo, o un chat privado. Además de especificar un objetivo de Steam para tus mensajes, también puedes especificar el `botName` nombre del bot que debe enviarlos.

Soportado en todos los entornos utilizados por ASF.

---

#### Sintaxis de configuración
```xml
<targets>
  <target type="Steam"
          name="String"
          layout="Layout"
          chatGroupID="Ulong"
          steamID="Ulong"
          botName="Layout" />
</targets>
```

Lee más sobre cómo usar el [archivo de configuración](https://github.com/NLog/NLog/wiki/Configuration-file).

---

#### Parámetros

##### Opciones Generales
_name_ - Nombre del objetivo.

---

##### Opciones de Layout
_layout_ - Texto a ser procesado. [Layout](https://github.com/NLog/NLog/wiki/Layouts) requerido. Por defecto: `${level:uppercase=true}|${logger}|${message}`

---

##### Opciones de SteamTarget

_chatGroupID_ - ID del chat de grupo declarado como entero largo sin firmar de 64 bits. No requerido. Por defecto en `0` lo que deshabilitará la funcionalidad de chat de grupo y en su lugar usará el chat privado. Cuando está habilitado (establecido en valor diferente a cero), la propiedad `steamID` actúa como `chatID` y especifica el ID del canal en este `chatGroupID` al que el bot debe enviar mensajes.

_steamID_ - SteamID declarado como entero largo sin firmar de 64 bits del usuario de Steam objetivo (como `SteamOwnerID`), o `chatID` objetivo (cuando `chatGroupID` está definido). Requerido. Por defecto en `0` lo que deshabilita completamente el objetivo de registro.

_botName_ - Nombre del bot (como es reconocido por ASF, distingue mayúsculas y minúsculas) que enviará los mensajes al `steamID` declarado arriba. No requerido. Por defecto en `null` lo que seleccionará automáticamente **cualquier** bot conectado actualmente. Se recomienda establecer este valor adecuadamente, ya que `SteamTarget` no toma en cuenta muchas limitaciones de Steam, como el hecho de que debes tener el `steamID` del objetivo en tu lista de amigos. Esta variable se define como de tipo [layout](https://github.com/NLog/NLog/wiki/Layouts), por lo tanto puedes usar una sintaxis especial, tal como `${logger}` para usar el bot que generó el mensaje.

---

#### Ejemplos de SteamTarget

Para escribir todos los mensajes del nivel `Debug` y superior, desde el bot llamado `MyBot` con steamID de `76561198006963719`, debes usar un `NLog.config` similar al siguiente:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target type="Steam" name="Steam" steamID="76561198006963719" botName="MyBot" />
  </targets>

  <rules>
    <logger name="*" minlevel="Debug" writeTo="Steam" />
  </rules>
</nlog>
```

**Aviso:** Nuestro `SteamTarget` es un objetivo personalizado, así que debes asegurarte de que lo declaras como `type="Steam"`, NO `xsi:type="Steam"`, ya que xsi está reservado para objetivos oficiales soportados por NLog.

Cuando ejecutes ASF con un `NLog.config` similar al anterior, `MyBot` comenzará a enviar mensajes al usuario de Steam `76561198006963719` con todos los mensajes de registro habituales de ASF. Ten en cuenta que `MyBot` debe estar conectado para enviar mensajes, por lo que todos los mensajes de ASF iniciales que ocurrieron antes de que nuestro bot pudiera conectarse a la red de Steam, no serán reenviados.

Por supuesto, `SteamTarget` tiene todas las funciones típicas que podrías esperar de `TargetWithLayout` genérico, así que puedes usarlo junto con, por ejemplo, layouts personalizados, nombres o reglas de registro avanzadas. El ejemplo anterior solo es el más básico.

---

#### Capturas de pantalla

![Captura de pantalla](https://i.imgur.com/5juKHMt.png)

---

### HistoryTarget

Este objetivo es usado internamente por ASF para proporcionar un historial de registro de tamaño fijo en el endpoint `/Api/NLog` de **[ASF API](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-es-ES#asf-api)** que posteriormente puede ser usado por ASF-ui y otras herramientas. En general, debes definir este objetivo solo si ya estás usando una configuración personalizada de NLog para otras personalizaciones y también quieres que el registro se exponga en la API de ASF, por ejemplo, para ASF-ui. También puede ser declarado cuando quieres modificar el layout predeterminado o `maxCount` la cantidad máxima de mensajes guardados.

Soportado en todos los entornos utilizados por ASF.

---

#### Sintaxis de configuración
```xml
<targets>
  <target type="History"
          name="String"
          layout="Layout"
          maxCount="Byte" />
</targets>
```

Lee más sobre cómo usar el [archivo de configuración](https://github.com/NLog/NLog/wiki/Configuration-file).

---

#### Parámetros

##### Opciones Generales
_name_ - Nombre del objetivo.

---

##### Opciones de Layout
_layout_ - Texto a ser procesado. [Layout](https://github.com/NLog/NLog/wiki/Layouts) requerido. Por defecto: `${date:format=yyyy-MM-dd HH\:mm\:ss}|${processname}-${processid}|${level:uppercase=true}|${logger}|${message}${onexception:inner= ${exception:format=toString,Data}}`

---

##### Opciones de HistoryTarget

_maxCount_ - Cantidad máxima de registros almacenados para historial bajo demanda. No requerido. Por defecto en `20` lo que es un buen balance para proporcionar el historial inicial, mientras se sigue teniendo en cuenta el uso de memoria que viene de los requisitos de almacenamiento. Debe ser mayor que `0`.

---

## Advertencias

Ten cuidado cuando decidas combinar el nivel de registro `Debug` o inferior en tu `SteamTarget` con un `steamID` que participe en el proceso de ASF. Esto puede derivar potencialmente en `StackOverflowException` porque crearás un bucle infinito de ASF recibiendo un mensaje dado, luego registrándolo a través de Steam, resultando en otro mensaje que necesita ser registrado. Actualmente la única posibilidad de que ocurra es registrar el nivel `Trace` (donde ASF registra sus propios mensajes de chat), o el nivel `Debug` mientras también se ejecuta ASF en modo `Debug` (donde ASF registra todos los paquetes de Steam).

En resumen, si tu `steamID` participa en el mismo proceso de ASF, entonces el `minlevel` nivel mínimo de registro de tu `SteamTarget` debe ser `Info` (o `Debug` si no estás ejecutando ASF en modo `Debug`) y superior. Alternativamente puedes definir tu propio filtro de registro `<when>` para evitar un bucle de registro infinito, si modificar el nivel no es apropiado para tu caso. Esta advertencia también aplica para los chats de grupo.