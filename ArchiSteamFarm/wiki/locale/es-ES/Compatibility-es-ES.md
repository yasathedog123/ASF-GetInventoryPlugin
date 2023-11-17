# Compatibilidad

ASF es una aplicación C# que se ejecuta en la plataforma .NET. Esto significa que ASF no se compila directamente en el **[código de máquina](https://es.wikipedia.org/wiki/Lenguaje_de_m%C3%A1quina)** que se ejecuta en tu PC, sino en **[CIL](https://es.wikipedia.org/wiki/Common_Intermediate_Language)** que requiere un tiempo de ejecución compatible con CIL para ejecutarse.

Este enfoque tiene una enorme cantidad de ventajass, ya que CIL es independiente de la plataforma, por lo que ASF puede ejecutarse nativamente muchos sistemas operativos disponibles, especialmente Windows, Linux y macOS. No solo no se necesita emulación, sino también soporte para todas las optimizaciones relacionadas con la plataforma y el hardware, tal como instrucciones SSE de CPU. Gracias a eso, ASF puede lograr rendimiento y optimización superiores, al mismo tiempo que ofrece compatibilidad y fiabilidad perfectas.

Esto también significa que ASF **no tiene requisitos específicos de sistema operativo**, porque requiere **runtime** funcionando en ese sistema operativo y no el sistema operativo en sí. Siempre que runtime ejecute correctamente el código de ASF, no importa si el sistema operativo subyacente es Windows, Linux, macOS, BSD, Sony Playstation 4, Nintendo Wii o tu tostadora - siempre que haya **[.NET para el dispositivo](https://dotnet.microsoft.com/download/dotnet)**, hay ASF para este (en la variante `generic`).

Sin embargo, independientemente de dónde ejecutes ASF, debes asegurarte de que tu plataforma objetivo tiene los **[prerrequisitos .NET](https://github.com/dotnet/core/blob/main/Documentation/prereqs.md)** instalados. Estos prerrequisitos son bibliotecas de bajo nivel requeridas para una correcta funcionalidad de runtime y primordiales para el funcionamiento de ASF. Es muy probable que tengas algunas (o incluso todas) ya instaladas.

---

## Paquetes de ASF

ASF viene en 2 variantes principales - paquete genérico y de sistema operativo específico. En cuanto a funcionalidad ambos paquetes son exactamente iguales, ambos son capaces de actualizarse automáticamente. La única diferencia entre ellos es si el paquete **genérico** de ASF viene o no con runtime **específico del sistema operativo**.

---

### Genérico

El paquete genérico es una compilación que no depende de plataformas y no incluye ningún código de máquina específico. Esta configuración requiere que ya tengas .NET runtime instalado en tu sistema operativo **en la versión apropiada**. Todos sabemos lo problemático que es mantener las dependencias actualizadas, por lo tanto este paquete está disponible principalmente para las personas que **ya usan** .Net y no quieren duplicar su runtime solo por ASF si pueden hacer uso de lo que ya tienen instalado. El paquete genérico también te permite ejecutar ASF **en cualquier lugar, siempre y cuando puedas obtener una implementación funcional de .NET runtime**, independientemente de si existe o no una compilación de ASF específica para el sistema operativo.

No se recomienda usar la variante genérica si eres un usuario casual o incluso avanzado que solo quiere hacer funcionar ASF y no entrar en detalles técnicos de .NET. En otras palabras - si sabes qué es esto, lo puedes usar, de lo contrario es mucho mejor usar un paquete de sistema operativo específico.

#### Paquete .NET Framework

Además del paquete genérico mencionado antes, también hay un paquete `generic-netf` compilado en .NET Framework y no en .NET (Core). Este paquete es una versión heredada que proporciona la compatibilidad faltante de los tiempos de ASF V2, y puede ejecutarse, por ejemplo, con **[Mono](https://www.mono-project.com)**, mientras que el paquete `generic` de .NET no puede hacer eso al día de hoy.

En general, deberías **evitar este paquete tanto como sea posible**, ya que la mayoría de los sistemas operativos y configuraciones están perfectamente (y mucho mejor) soportados con el paquete `generic` mencionado antes. De hecho, este paquete tiene sentido usarlo solo en plataformas que no tienen .NET runtime funcional, pero que tienen una implementación Mono funcional. Algunos ejemplos de tales plataformas incluyen `linux-x86` (32-bit i386/i686 linux), así como `linux-armel` (tarjetas ARMv6 encontradas, por ejemplo, en Raspberry Pi 0 & 1), de las cuales ninguna tiene .NET runtime que funcione oficialmente al día de hoy.

A medida que el tiempo pasa más plataformas son soportadas por .NET y hay menos compatibilidad entre .NET Framework y .NET, el paquete `generic-netf` será totalmente reemplazado por `generic` en el futuro. Por favor, evita usarlo si en su lugar puedes usar cualquier paquete .NET, ya que `generic-netf` carece de mucha funcionalidad y compatibilidad en comparación con las versiones .NET, y cada vez será menos funcional mientras pasa el tiempo. Ofrecemos soporte para este paquete **solo** en máquinas que no pueden usar la variante `generic` antes mencionada (por ejemplo, `linux-x86`), y solo con runtime actualizado (por ejemplo, el más reciente Mono).

---

### Sistema operativo específico

El paquete de sistema operativo específico, aparte del código incluido en el paquete genérico, también incluye código nativo para una plataforma determinada. En otras palabras, el paquete de sistema operativo específico **ya incluye el .NET runtime adecuado**, lo que permite omitir todo el lío de la instalación y en su lugar ejecutar ASF directamente. El paquete de sistema operativo específico, como puedes adivinar por el nombre, es específico del sistema operativo y cada uno requiere su propia versión - por ejemplo, Windows requiere el binario PE32+ `ArchiSteamFarm.exe` mientras que Linux funciona con el binario ELF `ArchiSteamFarm`. Como debes saber, esos dos tipos no son compatibles entre sí.

Actualmente ASF está disponible en las siguientes variantes de sistema operativo específico:

- `linux-arm` funciona en sistemas operativos GNU/Linux de 32 bits basados en ARM (ARMv7+) con glibc 2.27 en adelante. Esta variante cubre plataformas tales como Raspberry Pi 2 (y más recientes), **no** funcionará con arquitecturas ARM antiguas, tal como ARMv6  encontrado en Raspberry Pi 0 & 1, tampoco funcionará con sistemas operativos que no implementen el entorno GNU/Linux requerido (tal como Android).
- `linux-arm64` funciona en sistemas operativos GNU/Linux de 64 bits basados en ARM (ARMv8+) con glibc 2.23/musl 1.2.2 en adelante. Esta variante cubre plataformas tales como Raspberry Pi 3 (y más recientes), **no** funcionará con sistemas operativos de 32 bits que no tengan las bibliotecas de 64 bits requeidas (tal como Raspberry Pi OS de 32 bits), tampoco funcionará con sistemas operativos que no implementen el entorno GNU/Linux requerido (tal como Android).
- `linux-x64` funciona con sistemas operativos GNU/Linux de 64 bits con glibc 2.17/musl 1.2.2 en adelante.
- `osx-arm64` funciona en sistemas operativos macOS de 64 bits basados en ARM (Apple silicon) en versión 11 y más recientes.
- `osx-x64` funciona en sistemas operativos macOS de 64 bits en versión 10.15 en adelante.
- `win-arm64` funciona en sistemas operativos Windows de 64 bits basados en ARM (ARMv8+) en versión 10, 11 y más recientes.
- `win-x64` funciona en sistemas operativos Windows de 64 bits en versiones 10, 11, Server 2012+ y más recientes.

Por supuesto, incluso si no tienes un paquete de sistema operativo específico disponible para tu combinación de sistema operativo y arquitectura, siempre puedes instalar el .NET runtime adecuado y ejecutar la variante genérica de ASF, que también es la razón principal por la que existe en primer lugar. La compilación genérica de ASF no depende de la plataforma y se ejecutará en cualquier plataforma que tenga .NET runtime funcional. Es importante notar esto - ASF requiere .NET runtime, no un sistema operativo o arquitectura específicos. Por ejemplo, si estás ejecutando Windows de 32 bits a pesar de no haber una versión `win-x86` de ASF, simplemente puedes instalar .NET SDK en la versión `win-x86` y ejecutar ASF genérico sin problemas. Simplemente no podemos abordar cada combinación de sistema operativo y arquitectura que exista y sea usada por alguien, por lo que tenemos que trazar la línea en algún punto. x86 es un buen ejemplo de esa línea, ya que es una arquitectura obsoleta al menos desde 2004.

Para una lista completa de todas las plataformas y sistemas operativos soportados por .NET 7.0, visita las **[notas de lanzamiento](https://github.com/dotnet/core/blob/main/release-notes/7.0/supported-os.md)**.

---

## Requisitos de runtime

Si estás usando un paquete de sistema operativo específico entonces no necesitas preocuparte por los requisitos de runtime, porque ASF siempre se publica con el runtime requerido y actualizado que funcionará correctamente siempre que tengas los **[prerrequisitos de .NET](https://github.com/dotnet/core/blob/main/Documentation/prereqs.md)** instalados y actualizados. En otras palabras, **no necesitas instalar .NET runtime o SDK**, ya que las compilaciones de sistema operativo específico solo requieren las dependencias nativas del sistema operativo (prerrequisitos) y nada más.

Sin embargo, si estás intentando ejecutar un paquete **genérico** de ASF entonces debes asegurarte de que tu .NET runtime soporta la plataforma requerida por ASF.

ASF como programa actualmente se basa en **.NET 7.0** (`net7.0`), pero podría usar una plataforma más nueva en el futuro. `net7.0` es soportado desde 7.0.100 SDK (7.0.0 runtime), aunque ASF podría preferir el **último runtime al momento de la compilación**, así que debes asegurarte de que tienes el **[último SDK](https://dotnet.microsoft.com/download)** (o al menos runtime) disponible para tu máquina. La variante genérica de ASF podría negarse a iniciar si tu runtime es más antiguo que el mínimo soportado durante la compilación.

En caso de duda, revisa nuestros **[usos de integración continua](https://github.com/JustArchiNET/ArchiSteamFarm/actions/workflows/publish.yml?query=branch%3Amain)** para compilar y publicar versiones de ASF en GitHub. Puedes encontrar la salida `dotnet --info` en cada compilación como parte del paso de verificación de .NET.