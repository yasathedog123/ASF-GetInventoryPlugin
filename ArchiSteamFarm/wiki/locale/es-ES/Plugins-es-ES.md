# Plugins

ASF incluye soporte para plugins personalizados que pueden ser cargados durante el tiempo de ejecución. Los plugins permiten personalizar el comportamiento de ASF, por ejemplo añadiendo comandos personalizados, lógica de intercambio personalizada o integración con servicios de terceros y APIs.

---

## Para usuarios

ASF carga los plugins desde el directorio `plugins` ubicado en tu carpeta de ASF. Es una práctica recomendada mantener un directorio dedicado para cada plugin que quieras usar, que se puede basar en su nombre, tal como `MyPlugin`. Hacerlo de este modo resultará en la estructura final de `plugins/MyPlugin`. Finalmente, todos los archivos binarios deben ser colocados dentro de esa carpeta dedicada, y ASF descubrirá y utilizará tu plugin después de reiniciar.

Generalmente los desarrolladores de plugins los publicarán en forma de archivo `zip` con una estructura ya preparada, por lo que basta con desempaquetar el archivo zip en el directorio `plugins`, lo que creará la carpeta apropiada automáticamente.

Si el plugin se cargó con éxito, verás su nombre y versión en el registro. Debes consultar al desarrollador de tu plugin en caso de preguntas, problemas o uso relacionados con los plugins que hayas decidido usar.

Puedes encontrar algunos plugins destacados en nuestra sección **[aplicaciones de terceros](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Third-party-es-ES#plugins-de-asf)**.

**Por favor, ten en cuenta que los plugins de ASF podrían ser maliciosos**. Siempre debes asegurarte de que estás usando plugins hechos por desarrolladores en los que puedes confiar. Los desarrolladores de ASF ya no pueden garantizar los beneficios usuales de ASF (como ausencia de malware y ser libre de VAC) si decides usar cualquier plugin personalizado. Debes entender que una vez cargados, los plugins tienen control total sobre el proceso de ASF, por ello tampoco podemos ofrecer soporte a configuraciones que utilicen plugins personalizados, ya que no estás ejecutando una versión "vainilla" del código de ASF.

---

## Para desarrolladores

Los plugins son bibliotecas .NET estándar que heredan la interfaz común `IPlugin` con ASF. Puedes desarrollar plugins de forma totalmente independiente de la línea principal de ASF y reutilizarlos en la versión actual y futuras de ASF, siempre que la API siga siendo compatible. El sistema de plugins usado en ASF se basa en `System.Composition`, anteriormente conocido como **[Managed Extensibility Framework](https://docs.microsoft.com/es-es/dotnet/framework/mef/)** que permite a ASF descubrir y cargar tus bibliotecas durante el tiempo de ejecución.

---

### Comenzando

Hemos preparado **[ASF-PluginTemplate](https://github.com/JustArchiNET/ASF-PluginTemplate)** para ti, el cual puedes usar como base para tu proyecto de plugin. Usar la plantilla no es un requisito (ya que puedes hacer todo desde cero), pero recomendamos encarecidamente elegirlo ya que puede poner en marcha significativamente tu desarrollo y reducir el tiempo requerido para hacer todo bien. Simplemente echa un vistazo all **[README](https://github.com/JustArchiNET/ASF-PluginTemplate/blob/main/README.md)** de la plantilla y te dará más indicaciones. Sin embargo, cubriremos los conceptos básicos abajo en caso de que quieras empezar desde cero, o entender mejor los conceptos usados en la plantilla de plugin.

Tu proyecto debe ser una biblioteca .NET estándar que tenga como objetivo el entorno de trabajo apropiado para tu versión de ASF, como se especifica en la **[compilación](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compilation-es-ES)**.

El proyecto debe hacer referencia al ensamblado principal `ArchiSteamFarm`, ya sea una biblioteca `ArchiSteamFarm.dll` precompilada que hayas descargado como parte de la versión, o el proyecto fuente (por ejemplo, si decides añadir el árbol de ASF como submódulo). Esto te permitirá acceder y descubrir estructuras, métodos y propiedades de ASF, especialmente la interfaz `IPlugin` la que necesitarás para heredar en el siguiente paso. El proyecto también debe referenciar `System.Composition.AttributedModel` como mínimo, lo que te permite exportar `[Export]` tu `IPlugin` para que lo use ASF. Además, tal vez quieras/necesites referenciar otras bibliotecas comunes para interpretar las estructuras de datos que se te presentan en algunas interfaces, pero a menos que las necesites explícitamente, eso sería suficiente por ahora.

Si hiciste todo correctamente, tu `csproj` será similar al siguiente:

```csproj
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="System.Composition.AttributedModel" IncludeAssets="compile" Version="8.0.0" />
  </ItemGroup>

  <ItemGroup>
    <ProjectReference Include="C:\\Path\To\ArchiSteamFarm\ArchiSteamFarm.csproj" ExcludeAssets="all" Private="false" />

    <!-- Si se compila con el DLL descargado, usa esto en lugar de <ProjectReference> -->
    <!-- <Reference Include="ArchiSteamFarm" HintPath="C:\\Path\To\Downloaded\ArchiSteamFarm.dll" /> -->
  </ItemGroup>
</Project>
```

Por el lado del código, la clase de tu plugin debe heredar de la interfaz `IPlugin` (ya sea explícitamente, o implícitamente heredando desde una interfaz más especializada, como `IASF`) y `[Export(typeof(IPlugin))]` para ser reconocido por ASF durante el tiempo de ejecución. El ejemplo más sencillo que consigue eso sería el siguiente:

```csharp
using System;
using System.Composition;
using System.Threading.Tasks;
using ArchiSteamFarm;
using ArchiSteamFarm.Plugins;

namespace YourNamespace.YourPluginName;

[Export(typeof(IPlugin))]
public sealed class YourPluginName : IPlugin {
    public string Name => nameof(YourPluginName);
    public Version Version => typeof(YourPluginName).Assembly.GetName().Version;

    public Task OnLoaded() {
        ASF.ArchiLogger.LogGenericInfo("Meow");

        return Task.CompletedTask;
    }
}
```

Para usar tu plugin, primero debes compilarlo. Puedes hacerlo ya sea desde tu IDE (Entorno de Desarrollo Integrado), o desde el directorio raíz de tu proyecto mediante un comando:

```shell
# Si tu proyecto es individual (no hay necesidad de definir su nombre ya que es el único)
dotnet publish -c "Release" -o "out"

# Si tu proyecto es parte del árbol fuente de ASF (para evitar la compilación de partes innecesarias)
dotnet publish YourPluginName -c "Release" -o "out"
```

Después, tu plugin está listo para usarse. Depende de ti cómo quieres distribuir y publicar tu plugin, pero recomendamos crear un archivo zip con una sola carpeta llamada `YourNamespace.YourPluginName`, dentro de la cual pondrás tu plugin compilado junto con sus **[dependencias](#dependencias-de-plugin)**. De esta manera el usuario simplemente necesitará desempaquetar tu archivo zip en su directorio `plugins` y nada más.

Este solo es el escenario más básico para empezar. Tenemos el proyecto **[`ExamplePlugin`](https://github.com/JustArchiNET/ArchiSteamFarm/tree/main/ArchiSteamFarm.CustomPlugins.ExamplePlugin)** que muestra ejemplos de interfaces y acciones que puedes realizar dentro de tu propio plugin, con comentarios útiles incluidos. Siéntete libre de echar un vistazo si quieres aprender de un código funcional, o descubrir el namespace (espacio de nombres) `ArchiSteamFarm.Plugins` y dirígete a la documentación incluida para todas las opciones disponibles.

Si en lugar de un plugin de ejemplo deseas aprender de proyectos reales, está el plugin **[`SteamTokenDumper`](https://github.com/JustArchiNET/ArchiSteamFarm/tree/main/ArchiSteamFarm.OfficialPlugins.SteamTokenDumper)** desarrollado por nosotros, y que viene junto con ASF. Además, también hay plugins hechos por otros desarrolladores, en nuestra sección **[aplicaciones de terceros](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Third-party-es-ES#plugins-de-asf)**.

---

### Disponibilidad de API

ASF, además de a lo que tienes acceso en las interfaces, te expone un montón de APIs internas de las que puedes hacer uso, para ampliar la funcionalidad. Por ejemplo, si quisieras enviar algún tipo de nueva solicitud a la web de Steam, entonces no necesitas implementar todo desde cero, especialmente al tratar con todos los problemas con los que hemos tenido que tratar antes que tú. Simplemente usa nuestro `Bot.ArchiWebHandler` el cual ya expone un montón de métodos `UrlWithSession()` para que utilices, manejando por ti todas las cosas de bajo nivel, como autenticación, actualización de sesión o limitación web. Del mismo modo, para enviar solicitudes web fuera de la plataforma Steam, podrías usar la clase estándar .NET `HttpClient`, pero es mucho mejor idea usar `Bot.ArchiWebHandler.WebBrowser` que está disponible, lo que una vez más ofrece ayuda, por ejemplo en lo que respecta a reintentar solicitudes fallidas.

Tenemos una política muy abierta en términos de nuestra disponibilidad de API, si quieres usar algo de lo que ya incluye el código de ASF, simplemente **[abre un issue](https://github.com/JustArchiNET/ArchiSteamFarm/issues)** y explica el uso que planeas darle a nuestra API interna de ASF. Seguramente no tendremos nada en contra, siempre que tu uso previsto tenga sentido. Es simplemente imposible que abramos todo lo que alguien podría querer usar, así que hemos abierto lo que tiene más sentido para nosotros, y esperamos tu solicitud en caso de que quieras tener acceso a algo que todavía no es `public` público. Esto también incluye todas las sugerencias respecto a nuevas interfaces `IPlugin` que podría tener sentido añadirlas para ampliar la funcionalidad existente.

De hecho, la API interna de ASF es la única limitación real en términos de lo que puede hacer tu plugin. Nada te impide, por ejemplo, incluir la biblioteca `Discord.Net` en tu aplicación y crear un puente entre tu bot de Discord y los comandos de ASF, ya que tu plugin también puede tener dependencias propias. Las posibilidades son infinitas, e hicimos lo mejor para darte tanta libertad y flexibilidad como sea posible dentro de tu plugin, así que no hay límites artificiales, pero no estamos seguros de qué partes de ASF son cruciales para el desarrollo de tu plugin (lo que puedes solucionar haciéndonos saberlo, e incluso sin eso siempre puedes reimplementar la funcionalidad que necesites).

---

### Compatibilidad de API

Es importante destacar que ASF es una aplicación de consumo y no una biblioteca típica con una superficie de API fija de la que puedes depender incondicionalmente. Esto significa que no puedes suponer que tu plugin una vez compilado seguirá funcionando con todas las futuras versiones de ASF, es imposible si queremos seguir desarrollando el programa, y ser incapaz de adaptarse a los constantes cambios de Steam por el bien de la retrocompatibilidad simplemente no es adecuado para nuestro caso. Esto debería ser lógico para ti, pero es importante destacar ese hecho.

Haremos lo posible para mantener las partes públicas de ASF funcionando y estables, pero no dudaremos en romper la compatibilidad si surgen buenas razones, siguiendo nuestra política de **[obsolescencia](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Deprecation-es-ES)** en el proceso. Esto es especialmente importante en lo que se refiere a las estructuras internas de ASF que están expuestas como parte de la infraestructura de ASF, explicadas arriba (por ejemplo, `ArchiWebHandler`) que podría ser mejorada (y por lo tanto reescrita) como parte de las mejoras de ASF en una de las versiones futuras. Haremos todo lo posible para informarte adecuadamente en los registros de cambio, e incluir las advertencias apropiadas durante el tiempo de ejecución sobre las características obsoletas. No pretendemos reescribir todo solo por reescribirlo, así que puedes estar bastante seguro de que la siguiente versión menor de ASF simplemente no destruirá tu plugin solo porque tiene un número de versión superior, pero es buena idea estar pendiente de los registros de cambio y verificar ocasionalmente que todo funciona bien.

---

### Dependencias de plugin

Tu plugin incluirá al menos dos dependencias por defecto, referencia para API interna `ArchiSteamFarm`, y `PackageReference` de `System.Composition.AttributedModel` que se requiere para ser reconocida como un plugin de ASF. Además, podría incluir más dependencias de acuerdo a lo que hayas decidido hacer en tu plugin (por ejemplo, la biblioteca `Discord.Net` si decidiste integrar con Discord).

La salida de tu compilación incluirá tu biblioteca `YourPluginName.dll`, así como todas las dependencias que hayas referenciado. Como estás desarrollando un plugin para un programa ya funcional, no tienes que, e incluso **no deberías** incluir dependencias que ASF ya incluye, por ejemplo `ArchiSteamFarm`, `SteamKit2` o `AngleSharp`. Reducir las dependencias de tu compilación compartidas con ASF no es un requisito absoluto para que funcione tu plugin, pero hacerlo reducirá drásticamente la huella de memoria y el tamaño de tu plugin, además de aumentar el rendimiento, debido al hecho de que ASF compartirá sus propias dependencias, y cargará solo aquellas bibliotecas que no conozca.

En general, es una práctica recomendada incluir solo las bibliotecas que ASF no incluye, o las incluye en la versión incorrecta/incompatible. Ejemplos de esto sería obviamente `YourPluginName.dll`, pero como ejemplo también está `Discord.Net.dll` si decidiste depender de ella, ya que ASF no la incluye. Agrupar bibliotecas que se comparten con ASF aún puede tener sentido si quieres asegurar la compatibilidad de API (por ejemplo, asegurar que `AngleSharp` del que dependes en tu plugin siempre estará en la versión `X` y no aquella con la que se publica ASF), obviamente hacer eso viene con un precio de memoria/tamaño mayor y peor rendimiento, y por lo tanto debe ser evaluado cuidadosamente.

Si sabes que la dependencia que necesitas está incluida en ASF, puedes marcarla con `IncludeAssets="compile"` como mostramos en el ejemplo `csproj` anterior. Esto le indicará al compilador que evite publicar la biblioteca referenciada, ya que ASF la incluye. Del mismo modo, ten en cuenta que referenciamos el proyecto ASF con `ExcludeAssets="all" Private="false"` lo que funciona de una forma muy similar - indicándole al compilador que no produzca ningún archivo de ASF (puesto que el usuario ya los tiene). Esto solo aplica al hacer referencia al proyecto ASF, ya que si referencias una biblioteca `dll`, entonces no estás produciendo archivos de ASF como parte de tu plugin.

Si estás confundido por la declaración anterior y no tienes una mejor idea, comprueba qué bibliotecas `dll` están incluidas en el paquete `ASF-generic.zip` y asegúrate de que tu plugin incluye solo las que todavía no son parte de él. Esto solo será `YourPluginName.dll` para los plugins más simples. Si tienes algún problema durante el tiempo de ejecución en relación a algunas bibliotecas, incluye también esas bibliotecas afectadas. Si todo lo demás falla, siempre puedes decidir agrupar todo.

---

### Dependencias nativas

Las dependencias nativas se generan como parte de las compilaciones de sistema operativo específico, ya que no hay .NET runtime disponible en el host y ASF se ejecuta a través de su propio .NET runtime el cual está incluido como parte de la compilación de sistema operativo específico. Para minimizar el tamaño de la compilación, ASF recorta sus dependencias nativas para incluir solo el código accesible dentro del programa, lo que reduce efectivamente las partes no usadas del tiempo de ejecución. Esto puede crear un problema en lo que respecta a tu plugin, si de repente te encuentras en una situación en la que tu plugin depende de alguna característica de .NET que no está siendo usada en ASF, y por lo tanto las compilaciones de sistema operativo específico no pueden ejecutarla correctamente, normalmente arrojando `System.MissingMethodException` o `System.Reflection.ReflectionTypeLoadException` en el proceso.

Esto nunca es un problema con las compilaciones genéricas, porque estas nunca tratan con dependencias nativas en primer lugar (ya que tienen un tiempo de ejecución completamente funcional en el host, ejecutando ASF). También es una solución al problema, **usar tu plugin exclusivamente en compilaciones genéricas**, pero eso tiene el inconveniente de excluir de tu plugin a los usuarios que ejecutan ASF en una compilación de sistema operativo específico. Si te estás preguntando si tu problema está relacionado con dependencias nativas, también puedes usar este método como verificación, carga tu plugin en una compilación genérica de ASF y ve si funciona. Si funciona, tienes cubiertas las dependencias de tu plugin, y son las dependencias nativas las que causan problemas.

Desafortunadamente, tuvimos que elegir entre publicar todo runtime como parte de nuestras compilaciones para sistemas operativos específicos, y eliminar características no utilizadas, haciendo que la compilación sea cerca de 50 MB más pequeña en comparación con la completa. Elegimos la segunda opción, y por desgracia es imposible incluir las características faltantes de runtime junto con tu plugin. Si tu proyecto requiere acceso a características de runtime que no están disponibles, tienes que incluir todo el .NET runtime del que dependes, y eso significa ejecutar tu plugin junto con la variante `generic` de ASF. No puedes ejecutar tu plugin en compilaciones para sistemas operativos específicos, ya que esas compilaciones carecen de una característica de runtime que necesitas, y .NET runtime no puede "fusionar" la dependencia nativa que podrías haber proporcionado con la nuestra. Tal vez mejore en un futuro, pero por ahora simplemente no es posible.

Las compilaciones de ASF para sistemas operativos específicos incluyen el mínimo de funcionalidad adicional requerida para ejecutar nuestros plugins oficiales. Además de hacer eso posible, también amplía ligeramente la superficie a dependencias adicionales requeridas para los plugins más básicos. Por lo tanto, no todos los plugins necesitarán preocuparse por las dependencias nativas - solo aquellos que vayan más allá de lo que ASF y nuestros plugins oficiales necesitan directamente. Esto se hace de forma adicional, ya que si de todos modos necesitamos incluir dependencias nativas adicionales para nuestro uso, también podemos publicarlas directamente con ASF, haciéndolas disponibles, y por lo tanto más fáciles de cubrir para ti. Desafortunadamnete, estoy no siempre es suficience, y a medida que tu plugin se hace más grande y complejo, aumenta la probabilidad de encontrar funcionalidades recortadas. Por lo tanto, recomendamos que ejecutes tus plugins personalizados exclusivamente en la variante `generic` de ASF. Todavía puedes verificar manualmente que la compilación de sistema operativo específico tiene todo lo que tu plugin requiere para su funcionalidad - pero ya que esto cambia tanto en tus actualizaciones como en las nuestras, podría ser complicado de mantener.