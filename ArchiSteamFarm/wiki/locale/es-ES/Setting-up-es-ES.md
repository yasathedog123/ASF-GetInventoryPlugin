# Instalación

Si llegaste aquí por primera vez, ¡bienvenido! Estamos muy contentos de ver a otro viajero interesado en nuestro proyecto, aunque ten en cuenta que con un gran poder viene una gran responsabilidad - ASF es capaz de hacer muchas cosas relacionadas con Steam, siempre y cuando **te intereses lo suficiente para aprender cómo usarlo**. Hay una difícil curva de aprendizaje involucrada aquí, y esperamos que leas la wiki en este sentido, la cual explica en detalle cómo funciona todo.

Si todavía sigues aquí significa que soportaste nuestro texto de arriba, lo cual es bueno. A menos que te lo hayas saltado, entonces vas a tener un **[mal momento](https://www.youtube.com/watch?v=WJgt6m6njVw)** muy pronto... De cualquier modo, ASF es una aplicación de consola, lo que significa que el programa no tiene una interfaz gráfica como a las que estás acostumbrado, al menos de inicio. ASF estaba pensado principalmente para ser ejecutado en servidores, por lo que actúa como un servicio (daemon) y no como una aplicación de escritorio.

Sin embargo, esto no significa que no puedas usarlo en tu PC o que usarlo es de alguna manera más complicado de lo usual, nada de eso. ASF es un programa independiente que no necesita instalación, y funciona en seguida, pero requiere una configuración antes de ser útil. La configuración es decirle a ASF lo que en realidad debe hacer después de ejecutarlo. Si lo ejecutas sin configuración, entonces ASF no hará nada, simple.

---

## Configuración de sistema operativo específico

En general, aquí está lo que haremos los próximos minutos:
- Instalar los **[prerrequisitos .NET](#prerrequisitos-de-net)**.
- Descargar la **[última versión de ASF](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** en su apropiada variante de sistema operativo específico.
- Extraer el archivo en una nueva ubicación.
- **[Configurar ASF](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-es-ES)**.
- Ejecutar ASF y ver la magia.

Suena bastante simple, ¿cierto? Así que hagámoslo.

---

### Prerrequisitos de .NET

El primer paso es asegurarte de que tu sistema operativo puede siquiera ejecutar ASF correctamente. ASF está escrito en C#, basado en la plataforma .NET y podría requerir bibliotecas nativas que todavía no están disponibles en tu plataforma. Dependiendo de si usas Windows, Linux o macOS, tendrás diferentes requerimientos, aunque todos ellos están enlistados en el documento **[prerrequisitos de .NET](https://docs.microsoft.com/es-es/dotnet/core/install/)** que deberías seguir. Este es nuestro material de referencia que debe ser usado, pero por simplicidad también hemos detallado debajo todos los paquetes requeridos, para que no tengas que leer el documento completo.

Es perfectamente normal que algunas (o incluso todas) las dependencias ya existan en tu sistema por haber sido instaladas por software de terceros que utilices. Aún así, debes asegurarte de que verdaderamente ese es el caso ejecutando el instalador adecuado para tu sistema operativo - sin esas dependencias ASF no se ejecutará.

Ten en cuenta que no necesitas hacer nada más para la compilación de sistema operativo específico, especialmente instalar .NET SDK o incluso runtime, puesto que el paquete de sistema operativo específico ya incluye todo eso. Solo necesitas los prerrequisitos de .NET (dependencias) para ejecutar .NET runtime incluido en ASF.

#### **[Windows](https://docs.microsoft.com/es-es/dotnet/core/install/windows)**:
- **[Microsoft Visual C++ Redistributable Update](https://learn.microsoft.com/es-es/cpp/windows/latest-supported-vc-redist?view=msvc-170#visual-studio-2015-2017-2019-and-2022)** (**[x64](https://aka.ms/vs/17/release/vc_redist.x64.exe)** para Windows de 64 bits, **[x86](https://aka.ms/vs/17/release/vc_redist.x86.exe)** para Windows de 32 bits)
- Es altamente recomendado que te asegures de que todas las actualizaciones de Windows ya estén instaladas. Por lo menos necesitas **[KB2533623](https://support.microsoft.com/es-es/help/2533623/microsoft-security-advisory-insecure-library-loading-could-allow-remot)**, **[KB2999226](https://support.microsoft.com/es-es/help/2999226/update-for-universal-c-runtime-in-windows)**, pero podrían necesitarse más actualizaciones. Todas ellas ya están instaladas si tu Windows está actualizado. Asegúrate de cumplir esos requisitos antes de instalar el paquete Visual C++.

#### **[Linux](https://docs.microsoft.com/es-es/dotnet/core/install/linux)**:
Los nombres de los paquetes dependen de la distribución de Linux que estés usando, hemos listado las más comunes. Puedes obtener todas con el administrador de paquetes nativos para tu sistema operativo (tal como `apt` para Debian o `yum` para CentOS).

- `ca-certificates` (certificados estándar SSL confiables para hacer conexiones HTTPS)
- `libc6` (`libc`)
- `libgcc1` (`libgcc`)
- `libicu` (`icu-libs`, última versión para tu distribución, por ejemplo `libicu67`)
- `libgssapi-krb5-2` (`libkrb5-3`, `krb5-libs`)
- `libssl1.1` (`libssl`, `openssl-libs`, última versión para tu distribución, por lo menos `1.1.X` ya que `1.0.X` podría ya no funcionar)
- `libstdc++6` (`libstdc++`, en versión `5.0` o superior)
- `zlib1g` (`zlib`)

Al menos la mayoría de estas deberían estar disponibles nativamente en tu sistema. La instalación mínima de Debian estable requería solamente `libicu67`.

#### **[macOS](https://docs.microsoft.com/es-es/dotnet/core/install/macos)**:
- Ninguno por ahora, pero debes tener instalada la última versión de macOS, al menos 10.15+

---

### Descargando

Ya que tengamos todas las dependencias requeridas, el siguiente paso es descargar la **[última versión de ASF](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)**. ASF está disponible en diversas variantes, pero te interesa el paquete que concuerde con tu sistema operativo y arquitectura. Por ejemplo, si usas `Win`dows de `64`-bits, entonces necesitas el paquete `ASF-win-x64`. Para más información acerca de las variantes disponibles, visita la sección de **[compatibilidad](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility-es-ES)**. ASF también es capaz de ejecutarse en sistemas operativos para los que no compilamos un paquete de sistema operativo específico, tal como **Windows de 32-bits**, dirígete a la **[configuración genérica](#configuración-genérica)** para eso.

![Recursos](https://i.imgur.com/Ym2xPE5.png)

Después de la descarga, empieza extrayendo el archivo zip en su propia carpeta. Si necesitas una herramienta específica para eso, **[7-zip](https://www.7-zip.org)** funcionará, pero todas las utilidades estándar como `unzip` para Linux/macOS también deberían funcionar sin problemas.

Se recomienda desempaquetar ASF en **su propio directorio** y no en algún directorio existente que ya estés usando para algo más - la función de actualizaciones automáticas de ASF eliminará todos los archivos antiguos y no relacionados cuando se actualice, lo que podría resultar en la pérdida de cualquier cosa no relacionada que pongas en el directorio de ASF. Si tienes algún script o archivo adicional que quieras usar con ASF, colócalo en una carpeta superior.

Un ejemplo de la estructura se vería así:

```text
C:\ASF (donde pones tus propias cosas)
    ├── ASF shortcut.lnk (opcional)
    ├── Config shortcut.lnk (opcional)
    ├── Commands.txt (opcional)
    ├── MyExtraScript.bat (opcional)
    ├── (...) (cualquier otro archivo de tu elección, opcional)
    └── Core (dedicado únicamente a ASF, donde se extrae el archivo)
         ├── ArchiSteamFarm(.exe)
         ├── config
         ├── logs
         ├── plugins
         └── (...)
```

---

### Configuración

Ahora estamos listos para hacer el último paso, la configuración. Este es por mucho el paso más difícil, ya que involucra mucha información nueva con la que todavía no estás familiarizado, así que intentaremos proporcionar ejemplos fáciles de entender y una explicación simplificada.

Primero y más importante, hay una página de **[configuración](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-es-ES)** que explica **todo** lo que se relaciona con la configuración, pero es una enorme cantidad de información nueva, mucha de la cual no necesitamos saber ahora mismo. En cambio, te enseñaremos cómo obtener la información que realmente necesitas.

La configuración de ASF se puede hacer de al menos tres maneras - a través de nuestro generador de configuración web, ASF-ui o manualmente. Esto se explica a detalle en la sección de **[configuración](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-es-ES)**, así que consúltala si quieres información más detallada. Usaremos el generador de configuración web como punto de partida.

Dirígete a la página de nuestro **[generador de configuración web](https://justarchinet.github.io/ASF-WebConfigGenerator)** con tu navegador preferido, necesitas tener javascript activado en caso de que lo hayas desactivado manualmente. Recomendamos Chrome o Firefox, pero debería funcionar en todos los navegadores más populares.

Después de abrir la página, cambia a la pestaña "Bot". Ahora deberías ver una página similar a la siguiente:

![Pestaña de bot](https://i.imgur.com/aF3k8Rg.png)

Si por cualquier motivo la versión de ASF que hayas descargado es más antigua que la que el generador de configuración usa por defecto, simplemente elige tu versión de ASF del menú desplegable. Esto puede ocurrir ya que el generador de configuración puede ser usado para generar configuraciones para versiones más nuevas de ASF (prelanzamiento) que aún no han sido marcadas como estables. Has descargado la última versión estable de ASF que se ha verificado que funciona confiablemente.

Empieza por poner un nombre para tu bot en el campo resaltado en rojo. Este puede ser cualquier nombre que desees utilizar, tal como tu "nickname", nombre de la cuenta, un número, o cualquier otra cosa. Solo hay una palabra que no se puede utilizar, `ASF`, ya que esa palabra está reservada para el archivo de configuración global. Además de eso el nombre de tu bot no puede empezar con un punto (ASF intencionalmente ignora esos archivos). También recomendamos que evites usar espacios, puedes usar `_` como separador de palabras si es necesario.

Después de decidir tu nombre, cambia el interruptor de `Enabled` para que esté activo, esto determina si tu bot es iniciado automáticamente por ASF tras la ejecución (del programa).

Ahora puedes decidir entre dos cosas:
- Puedes poner tu nombre de usuario en el campo `SteamLogin` y tu contraseña en el campo `SteamPassword`
- O puedes dejarlos vacíos

Haciendo lo primero permitirá que ASF use automáticamente las credenciales de tu cuenta durante el inicio, por lo que no necesitarás ingresarlas manualmente cada vez que ASF las necesite. Sin embargo puedes decidir omitirlas, en cuyo caso no serán guardadas, por lo que ASF no será capaz de iniciar automáticamente sin tu ayuda y necesitarás ingresarlas durante el tiempo de ejecución (runtime).

ASF requiere tus credenciales de inicio de sesión porque incluye su propia implementación del cliente de Steam y necesita los mismos detalles para iniciar sesión. Tus credenciales de inicio de sesión no se guardan en ninguna parte más que en tu PC en el directorio `config` de ASF, nuestro generador de configuración web funciona del lado del cliente, lo que significa que el código es ejecutado localmente en tu navegador para generar configuraciones válidas de ASF, sin que los detalles que ingresas abandonen tu PC en ningún momento, por lo que no hay necesidad de preocuparse por alguna posible filtración de datos. Aún así, si por cualquier razón no deseas ingresar tus credenciales ahí, entendemos eso, y puedes ingresarlas manualmente luego en los archivos generados, u omitirlas completamente e ingresarlas solo en el símbolo del sistema de ASF. Puedes encontrar más información sobre el tema de seguridad en la sección de **[configuración](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-es-ES)**.

También puedes decidir dejar un campo vacío, tal como `SteamPassword`, entonces ASF será capaz de usar tu nombre de usuario automáticamente, pero todavía pedirá la contraseña (similar al cliente Steam). Si usas el control parental de Steam para desbloquear la cuenta, necesitarás colocarlo en el campo `SteamParentalCode`.

Después de la decisión y los detalles opcionales, ahora tu página web se verá similar a la siguiente:

![Pestaña de bot 2](https://i.imgur.com/yf54Ouc.png)

Ahora puedes presionar el botón "Descargar" y nuestro generador de configuración web creará un nuevo archivo `json` con el nombre que hayas elegido. Guarda ese archivo en el directorio `config` que se encuentra en la carpeta donde extrajiste el archivo zip en el paso anterior.

Tu directorio `config` ahora se verá así:

![Estructura 2](https://i.imgur.com/crWdjcp.png)

¡Felicidades! Acabas de terminar la configuración más básica de un bot en ASF. Explicaremos más en breve, por ahora esto es todo lo que necesitas.

---

### Ejecutando ASF

Ahora estás listo para ejecutar el programa por primera vez. Simplemente haz doble clic en el ejecutable `ArchiSteamFarm` ubicado en el directorio de ASF. También puedes iniciarlo desde la consola.

Posteriormente, asumiendo que instalaste todas las dependencias necesarias en el primer paso, ASF debería ejecutarse correctamente, detectar tu primer bot (si no olvidaste poner el archivo generado en el directorio `config`), e intentar iniciar sesión:

![ASF](https://i.imgur.com/u5hrSFz.png)

Si proporcionaste `SteamLogin` y `SteamPassword` para que utilice ASF, se te pedirá solamente tu código de SteamGuard (correo electrónico, 2FA o ninguno, dependiendo de los ajustes de tu cuenta de Steam). Si no lo hiciste, también se te pedirá tu nombre de usuario y contraseña.

Ahora sería un buen momento para revisar nuestra sección de **[comunicación remota](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Remote-communication-es-ES)** si te preocupa lo que ASF está programado para hacer, incluyendo acciones que realizará por ti, tal como unirse a nuestro grupo de Steam.

Después de la etapa de conexión, asumiendo que tus datos son correctos, iniciarás sesión con éxito, y ASF comenzará a recolectar cromos usando la configuración predeterminada:

![ASF 2](https://i.imgur.com/Cb7DBl4.png)

Esto prueba que ASF está haciendo su trabajo con éxito en tu cuenta, ahora puedes minimizar el programa y hacer algo más. Después del suficiente tiempo (dependiendo del **[rendimiento](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance-es-ES)**) verás que poco a poco recibes cromos de Steam. Por supuesto, para que eso suceda debes tener juegos válidos para recolectar, mostrado como "puedes obtener X cromos más jugando este juego" en tu **[página de insignias](https://steamcommunity.com/my/badges)** - si no hay juegos para recolectar, entonces ASF indicará que no hay nada qué hacer, como se expresa en nuestras **[preguntas frecuentes](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ-es-ES#qu%C3%A9-es-asf)**.

Esto concluye nuestra guía de configuración básica. Ahora puedes decidir si quieres seguir configurando ASF, o dejarlo hacer su trabajo con la configuración predeterminada. Abarcaremos algunos detalles básicos más, y luego dejaremos toda la wiki para que descubras.

---

### Configuración extendida

#### Recolectar varias cuentas al mismo tiempo

ASF soporta la recolección de más de una cuenta a la vez, lo cual es su función principal. Puedes añadir más cuentas a ASF generando más archivos de configuración de bots, exactamente del mismo modo que generaste el primero hace algunos minutos. Solo debes de asegurarte de dos cosas:

- Usar un nombre de bot único, si ya nombraste tu primer bot como "MainAccount", no puedes tener otro con el mismo nombre.
- Detalles de inicio de sesión válidos, tales como `SteamLogin`, `SteamPassword` y `SteamParentalCode` (si usas la configuración parental de Steam)

En otras palabras, simplemente ve a configuración de nuevo y haz exactamente lo mismo, solo que para tu segunda o tercera cuenta. Recuerda usar nombres únicos para todos tus bots.

---

#### Cambiar la configuración

Puedes cambiar ajustes existentes de la misma forma - generando un nuevo archivo de configuración. Si aún no has cerrado nuestro generador de configuración web, haz clic en "Mostrar configuración avanzada" y ve lo que hay ahí para descubrir. Para este tutorial cambiaremos el ajuste `CustomGamePlayedWhileFarming`, que te permite establecer que se muestre un nombre personalizado cuando ASF está recolectando, en lugar de mostrar el nombre real del juego.

Empecemos, si ejecutas ASF y empieza a recolectar, en ajustes predeterminados verás que tu cuenta de Steam está jugando:

![Steam](https://i.imgur.com/1VCDrGC.png)

Cambiemos eso. Cambia a configuración avanzada en el generador de configuración web y busca `CustomGamePlayedWhileFarming`. Una vez que hagas eso, pon el texto personalizado que quieras que se muestre, tal como "Recolectando cromos":

![Pestaña de bot 3](https://i.imgur.com/gHqdEqb.png)

Ahora descarga el nuevo archivo de configuración exactamente de la misma manera, luego **sobrescribe** tu archivo de configuración previo con el nuevo. También puedes eliminar tu viejo archivo de configuración y poner el nuevo en su lugar.

Una vez que hagas eso y ejecutes ASF de nuevo, notarás que ASF ahora muestra tu texto personalizado:

![Steam 2](https://i.imgur.com/vZg0G8P.png)

Esto confirma que editaste exitosamente tu configuración. De la misma manera puedes cambiar las propiedades globales de ASF, cambiando de la pestaña de bot a la pestaña "ASF", y luego descargando el archivo de configuración `ASF.json` generado y poniéndolo en tu directorio `config`.

Editar tus configuraciones de ASF se puede hacer más fácilmente usando nuestro frontend ASF-ui, el cual será explicado más adelante.

---

#### Usando ASF-ui

ASF es una aplicación de consola y no incluye una interfaz gráfica de usuario. Sin embargo, estamos trabajando en el frontend **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-es-ES#asf-ui)** para nuestra interfaz IPC, la cual puede ser una manera muy decente y amigable para acceder a varias funciones de ASF.

Para poder usar ASF-ui, necesitas tener `IPC` habilitado, lo que es la opción predeterminada a partir de ASF V5.1.0.0. Una vez que inicies ASF, deberías poder comprobar que inició automáticamente de forma correcta la interfaz IPC:

![IPC](https://i.imgur.com/ZmkO8pk.png)

Puedes acceder a la interfaz IPC de ASF en **[este](http://localhost:1242)** enlace, siempre y cuando ASF se esté ejecutando, desde la misma máquina. Puedes usar ASF-ui para varios propósitos, por ejemplo, editar los archivos de configuración o enviar **[comandos](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-es-ES)**. No dudes en echar un vistazo para descubrir todas las funcionalidades de la interfaz de usuario de ASF.

![ASF-ui](https://raw.githubusercontent.com/JustArchiNET/ASF-ui/main/.github/previews/bots.png)

---

### Sumario

Has configurado ASF con éxito para usar tus cuentas de Steam y ya lo has personalizado un poco a tu gusto. Si seguiste nuestra guía, entonces también lograste modificar ASF a través de nuestra interfaz ASF-ui y descubriste que ASF en realidad tiene una interfaz gráfica de algún tipo. Ahora es un buen momento para leer toda nuestra sección de **[configuración](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-es-ES)** para aprender qué hacen los diferentes ajustes que viste, y lo que ASF tiene para ofrecer. Si te has encontrado con algún problema o tienes alguna pregunta genérica, lee nuestras **[preguntas frecuentes](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ-es-ES)**, lo que debería cubrir todo, o al menos la gran mayoría de las preguntas que puedas tener. Si quieres aprender todo acerca de ASF y de cómo puede hacer tu vida más fácil, dirígete al resto de **[nuestra wiki](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Home-es-ES)**. Si nuestro programa te resulta útil y te sientes generoso, también puedes considerar hacer una donación a nuestro proyecto. En cualquier caso, ¡diviértete!

---

## Configuración genérica

Esta configuración es para usuarios avanzados que quieren establecer ASF para ejecutarlo en su variante **[genérica](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility-es-ES#gen%C3%A9rico)**. Aunque es más problemático en el uso que las **[variantes de sistema operativo específico](#configuración-de-sistema-operativo-específico)**, también viene con beneficios adicionales.

Querrás usar la variante `generic` principalmente en esas situaciones (pero puedes usarla de todos modos):
- Cuando usas un sistema operativo para el cual no compilamos un paquete de sistema operativo específico (tal como Windows de 32-bits)
- Cuando ya tienes .NET Runtime/SDK, o quieres instalar y usar uno
- Cuando quieras miniminar el tamaño de la estructura y la huella de memoria al manejar tú mismo los requisitos de runtime.
- Cuando quieras usar un **[plugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins-es-ES)** personalizado que requiera una configuración `generic` de ASF para ejecutarse correctamente (debido a dependencias nativas faltantes)

Sin embargo, ten en cuenta que tú eres responsable del .NET runtime en este caso. Esto significa que si tu .NET SDK (runtime) no está disponible, está desactualizado o roto, ASF no funcionará. Es por eso que no recomendamos esta configuración para usuarios casuales, ya que ahora necesitas asegurarte de que tu .NET SDK (runtime) coincida con los requerimientos de ASF y puede ejecutarlo, en contraposición a que **nosotros** nos aseguremos de que nuestro .NET runtime en conjunto con ASF puede hacerlo.

Para el paquete `generic`, puedes seguir la guía de sistema operativo específico vista anteriormente, con dos pequeños cambios. Además de instalar los prerrequisitos de .NET, también querrás instalar .NET SDK, y en lugar de tener un archivo ejecutable `ArchiSteamFarm(.exe)` para sistema operativo específico, ahora solamente tienes un binario genérico `ArchiSteamFarm.dll` . Todo lo demás es exactamente igual.

Con pasos adicionales:
- Instalar los **[prerrequisitos .NET](#prerrequisitos-de-net)**.
- Instalar el **[.NET SDK](https://www.microsoft.com/net/download)** (o por lo menos ASP.NET Core runtime) apropiado para tu sistema operativo. Probablemente querrás usar un instalador. Dirígete a **[requisitos de runtime](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility-es-ES#requisitos-de-runtime)** si no estás seguro de qué versión instalar.
- Descarga la **[última versión de ASF](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** en su variante `generic`.
- Extraer el archivo en una nueva ubicación.
- **[Configurar ASF](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-es-ES)**.
- Ejecuta ASF ya sea usando un script auxiliar o ejecutando `dotnet /path/to/ArchiSteamFarm.dll` manualmente desde tu shell favorito.

Los scripts auxiliares (tal como `ArchiSteamFarm.cmd` para Windows y `ArchiSteamFarm.sh` para Linux/macOS) están ubicados junto al binario `ArchiSteamFarm.dll` - estos solo están incluidos en la variante `generic`. Puedes usarlos si no quieres ejecutar manualmente el comando `dotnet`. Obviamente los scripts auxiliares no funcionarán si no instalaste .NET SDK y no tienes el ejecutable `dotnet` disponible en tu `PATH`. Los scripts auxiliares son completamente opcionales, siempre puedes usar manualmente `dotnet /path/to/ArchiSteamFarm.dll`.