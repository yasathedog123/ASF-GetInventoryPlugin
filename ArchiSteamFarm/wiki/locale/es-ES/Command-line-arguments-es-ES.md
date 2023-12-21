# Argumentos de la línea de comandos

ASF incluye soporte para varios argumentos de la línea de comandos que pueden afectar al tiempo de ejecución del programa. Estos argumentos pueden ser usados por usuarios avanzados para especificar cómo debe ejecutarse el programa. En comparación con la forma normal a través del archivo de configuración `ASF.json`, los argumentos de la línea de comandos son usados para la inicialización del núcleo (por ejemplo, `--path`), opciones específicas de una plataforma (por ejemplo, `--system-required`) o información sensible (por ejemplo, `--cryptkey`).

---

## Uso

El uso depende de tu sistema operativo y la variante de ASF.

Genérico:

```shell
dotnet ArchiSteamFarm.dll --argumento --otroArgumento
```

Windows:

```powershell
.\ArchiSteamFarm.exe --argumento --otroArgumento
```

Linux/macOS:

```shell
./ArchiSteamFarm --argumento --otroArgumento
```

Los argumentos de la línea de comandos también están soportados en scripts auxiliares genéricos tal como `ArchiSteamFarm.cmd` o `ArchiSteamFarm.sh`. Además de eso, también puedes usar la propiedad de entorno `ASF_ARGS`, como se indica en las secciones de **[gestión](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management-es-ES#variables-de-entorno)** y **[docker](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Docker-es-ES#argumentos-de-la-l%C3%ADnea-de-comandos)**.

Si tu argumento incluye espacios, no olvides ponerlo entre comillas. Estos dos son incorrectos:

```shell
./ArchiSteamFarm --path /home/archi/Mis Descargas/ASF # ¡Mal!
./ArchiSteamFarm --path=/home/archi/Mis Descargas/ASF # ¡Mal!
```

Sin embargo, estos dos están completamente bien:

```shell
./ArchiSteamFarm --path "/home/archi/Mis Descargas/ASF" # OK
./ArchiSteamFarm "--path=/home/archi/Mis Descargas/ASF" # OK
```

## Argumentos

`--cryptkey <key>` o `--cryptkey=<key>` - lanzará ASF con una clave criptográfica personalizada de valor `<key>`. Esta opción afecta a la **[seguridad](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security-es-ES)** y hará que ASF use la clave personalizada `<key>` que hayas proporcionado, en lugar de la que está establecida por defecto en el ejecutable. Dado que esta propiedad afecta la clave de cifrado predeterminada (para propósitos de cifrado) así como la sal (para propósitos de hashing), ten en cuenta que todo lo cifrado/hasheado con esta clave requerirá ser pasado en cada ejecución de ASF.

No hay requisito de longitud o caracteres para `<key>`, pero por razones de seguridad recomendamos elegir una contraseña suficientemente larga compuesta, por ejemplo, de 32 caracteres aleatorios, una opción sería usar el comando `tr -dc A-Za-z0-9 < /dev/urandom | head -c 32; echo` en Linux.

Es bueno mencionar que hay otras dos formas de proporcionar este detalle: `--cryptkey-file` y `--input-cryptkey`.

Debido a la naturaleza de esta propiedad, también es posible establecer la clave de cifrado declarando la variable de entorno `ASF_CRYPTKEY`, que podría ser más apropiada para quienes deseen evitar información sensible en los argumentos del proceso.

---

`--cryptkey-file <path>` o `--cryptkey-file=<path>` - lanzará ASF con una clave criptográfica personalizada leída desde el archivo `<path>`. Esto tiene el mismo propósito que `--cryptkey <key>` el cual se explicó anteriormente, solo el mecanismo difiere, ya que en cambio esta propiedad leerá `<key>` del `<path>` proporcionado. Si usas esto junto con `--path`, considera declarar primero `--path` para que las rutas relativas puedan funcionar correctamente.

Debido a la naturaleza de esta propiedad, también es posible establecer el archivo de la clave de cifrado declarando la variable de entorno `ASF_CRYPTKEY_FILE`, lo que podría ser más apropiado para quienes deseen evitar información sensible en los argumentos del proceso.

---

`--ignore-unsupported-environment` - causará que ASF ignore problemas relacionados con ejecutarse en un entorno no soportado, lo que normalmente se indica con un error y un cierre forzado. Un entorno no soportado incluye, por ejemplo, ejecutar la compilación de sistema operativo específico `win-x64` en `linux-x64`. Aunque esta opción permitirá que ASF intente ejecutarse en tales escenarios, ten en cuenta que no los soportamos oficialmente y estás forzando a ASF a hacerlo completamente **bajo tu propio riesgo**. Al día de hoy, **todos** los escenarios de entorno no soportado pueden ser corregidos. Recomendamos encarecidamente solucionar los problemas relevantes en lugar de usar este argumento.

---

`--input-cryptkey` - hará que ASF solicite `--cryptkey` durante el inicio. Esta opción puede ser útil si en lugar de proporcionar la clave de cifrado, ya sea en variables de entorno o en un archivo, prefieres introducirla manualmente en cada ejecución de ASF y que no se guarde en ninguna parte.

---

`--minimized` - causará que la ventana de la consola de ASF se minimice poco después de iniciar. Útil principalmente en escenarios de autoinicio, pero también puede ser usado fuera de ellos. Actualmente esta opción solo tiene efecto en máquinas con Windows.

---

`--network-group <group>` o `--network-group=<group>` - causará que ASF inicialice sus limitadores con un grupo de red personalizado con el valor `<group>`. Esta opción afecta a ASF ejecutándose en **[múltiples instancias](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management-es-ES#m%C3%BAltiples-instancias)** señalizando que una instancia determinada es dependiente solo de instancias que compartan el mismo grupo de red, e independiente del resto. Normalmente quieres usar esta propiedad solo si estás enrutando solicitudes de ASF a través de un mecanismo personalizado (por ejemplo, diferentes direcciones IP) y quieres establecer grupos de red, sin depender de ASF para hacerlo automáticamente (lo que actualmente incluye tomar en cuenta solo `WebProxy`). Ten en cuenta que al usar un grupo de red personalizado, este es un identificador único dentro de la misma máquina, y ASF no tendrá en cuenta ningún otro detalle, tal como el valor `WebProxy`, permitiéndote, por ejemplo, iniciar dos instancias con diferentes valores `WebProxy` que siguen siendo dependientes entre sí.

Debido a la naturaleza de esta propiedad, también es posible establecer el valor declarando la variable de entorno `ASF_NETWORK_GROUP`, lo que podría ser más apropiado para las personas que quieran evitar información confidencial en los argumentos del proceso.

---

`--no-config-migrate` - por defecto ASF migrará automáticamente tus archivos de configuración a la sintaxis más reciente. La migración incluye la conversión de propiedades obsoletas a las más recientes, eliminar propiedades con valores predeterminados (ya que no tienen efecto), así como limpiar el archivo en general (corregir las sangrías y demás). Esto casi siempre es buena idea, pero puede que tengas una situación particular en la que preferirías que ASF nunca sobrescriba los archivos de configuración automáticamente. Por ejemplo, tal vez quieras usar `chmod 400` en tus archivos de configuración (permisos de lectura solo para el propietario) o ponerles `chattr +i`, teniendo como resultado denegar el acceso de escritura para todos, por ejemplo, como una medida de seguridad. Normalmente recomendamos mantener la migración de la configuración habilitada, pero si tienes una razón particular para deshabilitarla y prefieres que ASF no haga eso, puedes usar este modificador para lograr ese propósito.

---

`--no-config-watch` - por defecto ASF configura un `FileSystemWatcher` en tu directorio `config` para escuchar eventos relacionados con la modificación de archivos, y así poder adaptarse de forma interactiva a ellos. Por ejemplo, esto incluye detener bots al borrar su configuración, reiniciar bots al modificar su configuración, o cargar claves de producto (keys) en el **[activador de juegos en segundo plano](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer-es-ES)** una vez que las pongas en el directorio `config`. Este modificador te permite deshabilitar dicho comportamiento, lo que hará que ASF ignore completamente todos los cambios en el directorio `config`, requiriendo que realices dichas acciones manualmente, si lo consideras apropiado (lo que normalmente significa reiniciar el proceso). Recomendamos mantener los eventos de configuración activados, pero si tienes una razón en particular para desactivarlos y prefieres que ASF no los detecte, puedes usar este modificador para lograr ese propósito.

---

`--no-restart` - esta opción se usa principlamente para nuestros contenedores **[docker](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Docker-es-ES)** y fuerza `AutoRestart` al valor `false`. A menos que tengas una necesidad particular, en lugar de usar esta opción deberías configurar la propiedad `AutoRestart` directamente en tu configuración. Esta opción existe para que nuestro script docker no necesite modificar tu configuración global para adaptarla a su propio entorno. Por supuesto, si estás ejecutando ASF a través de un script, también puedes utilizar esta opción (si no, es preferible usar la propiedad de configuración global).

---

`--no-steam-parental-generation` - por defecto ASF intentará generar automáticamente el código parental de Steam, como se describe en la propiedad de configuración **[`SteamParentalCode`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-es-ES#steamparentalcode)**. Sin embargo, ya que esto podría requerir una cantidad excesiva de recursos del sistema operativo, esta opción te permite deshabilitar ese comportamiento, lo que resultará en que ASF omita la generación automática y directamente solicite el código al usuario, que es lo que normalmente pasaría solo si la generación automática ha fallado. Normalmente recomendamos mantener la generación habilitada, pero si tienes una razón particular para deshabilitarla y prefieres que ASF no haga eso, puedes usar este modificador para lograr ese propósito.

---

`--path <path>` o `--path=<path>` - ASF siempre navega a su propio directorio al iniciarse. Al especificar este argumento, ASF navegará al directorio especificado tras la inicialización, lo que te permite usar una ruta personalizada para diversas partes de la aplicación (incluyendo los directorios `config`, `plugins` y `www`, además del archivo `NLog.config`), sin la necesidad de duplicar el ejecutable en el mismo lugar. Puede resultar especialmente útil si quieres separar el ejecutable de la configuración, como se hace en el paquete Linux - de esta forma puedes usar un ejecutable (actualizado) con diferentes configuraciones. La ruta puede ser relativa según la ubicación actual del ejecutable de ASF, o absoluta. Ten en cuenta que este comando apunta a una nueva "carpeta de inicio de ASF" - el directorio que tiene la misma estructura que el ASF original, con el directorio `config` dentro, ve el ejemplo de abajo para la explicación.

Debido a la naturaleza de esta propiedad, también es posible establecer una ruta esperada declarando la variable de entorno `ASF_PATH`, que puede ser más apropiado para las personas que quieran evitar detalles sensibles en los argumentos del proceso.

Si estás considerando usar este argumento de la línea de comandos para ejecutar múltiples instancias de ASF, recomendamos leer nuestra **[página de compatibilidad](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management-es-ES#m%C3%BAltiples-instancias)**.

Ejemplos:

```shell
dotnet /opt/ASF/ArchiSteamFarm.dll --path /opt/TargetDirectory # Ruta absoluta
dotnet /opt/ASF/ArchiSteamFarm.dll --path ../TargetDirectory # La ruta relativa también funciona
ASF_PATH=/opt/TargetDirectory dotnet /opt/ASF/ArchiSteamFarm.dll # Igual que la variable de entorno
```

```text
├── /opt
│     ├── ASF
│     │     ├── ArchiSteamFarm.dll
│     │     └── ...
│     └── TargetDirectory
│           ├── config
│           ├── logs (generado)
│           ├── plugins (opcional)
│           ├── www (opcional)
│           ├── log.txt (generado)
│           └── NLog.config (opcional)
└── ...
```

---

`--process-required` - declarar esto desactivará el comportamiento predeterminado de ASF de cerrarse cuando no hay bots en ejecución. El comportamiento de no cerrarse automáticamente es especialmente útil en combinación con **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-es-ES)** donde la mayoría de usuarios esperarían que su servicio web se ejecute independientemente de la cantidad de bots activos. Si estás usando la opción IPC o necesitas que el proceso de ASF se ejecute todo el tiempo hasta que lo cierres, esta es la opción correcta.

Si no pretendes usar IPC, esta opción será inútil para ti, ya que puedes solamente iniciar el proceso de nuevo cuando lo necesites (contrario al servidor web de ASF donde requieres que esté escuchando todo el tiempo para enviar comandos).

---

`--service` - esta opción es usada principalmente por nuestro servicio `systemd` y fuerza la configuración `Headless` al valor `true`. A menos que tengas una necesidad particular, deberías establecer la propiedad `Headless` directamente en tu configuración. Esta opción está disponible para que nuestro servicio `systemd` no necesite tocar tu configuración global para adaptarla a su propio entorno. Por supuesto, si tienes una necesidad similar también puedes usar esta opción (de lo contrario es mejor con la propiedad de configuración global).

---

`--system-required` - declarar esto causará que ASF intente indicar al sistema operativo que el proceso requiere que el sistema esté activo y ejecutándose durante todo su tiempo de vida. Actualmente esto solo tiene efecto en máquinas con Windows donde este impedirá que tu sistema entre en modo de suspensión mientras el proceso se esté ejecutando. Esto puede ser especialmente útil cuando estás recolectando cromos en tu PC o laptop durante la noche, ya que ASF podrá mantener tu sistema activo mientras está recolectando, luego, una vez que ASF termine, se cerrará como de costumbre, permitiendo a tu sistema entrar en modo de suspensión nuevamente, y por lo tanto ahorrando energía inmediatamente una vez que la recolección haya terminado.

Ten cuenta que para un adecuado cierre automático de ASF necesitas otros ajustes - especialmente evitar `--process-required` y asegurarte de que todos tus bots tienen habilitada la propiedad `ShutdownOnFarmingFinished`. Por supuesto, el cierre automático solo es una posibilidad para esta característica, no un requisito, ya que también puedes usar esta opción junto con, por ejemplo `--process-required`, haciendo que tu sistema se mantenga activo infinitamente después de iniciar ASF.