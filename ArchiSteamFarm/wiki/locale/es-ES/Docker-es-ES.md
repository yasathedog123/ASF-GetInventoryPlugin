# Docker

ASF está disponible como **[contenedor docker](https://www.docker.com/what-container)**. Nuestros paquetes docker están disponibles en **[ghcr.io](https://github.com/JustArchiNET/ArchiSteamFarm/pkgs/container/archisteamfarm)** así como en **[Docker Hub](https://hub.docker.com/r/justarchi/archisteamfarm)**.

Es importante tener en cuenta que ejecutar ASF en un contenedor Docker se considera una **configuración avanzada**, la cual **no es necesaria** para la gran mayoría de los usuarios, y normalmente **no proporciona ninguna ventaja** sobre configuraciones sin contenedor. Si estás considerando Docker como una solución para ejecutar ASF como un servicio, por ejemplo, que se inicie automáticamente con tu sistema operativo, entonces en su lugar deberías considerar leer la sección de **[gestión](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management-es-ES#servicio-systemd-para-linux)** y configurar un servicio `systemd` apropiado lo que **casi siempre** será una mejor idea que ejecutar ASF en un contenedor Docker.

Ejecutar ASF en un contenedor Docker normalmente involucra **varios nuevos problemas** que tendrás que atender y resolver tú mismo. Por eso te recomendamos **encarecidamente** que lo evites a menos que ya tengas conocimiento en Docker y no necesites ayuda para entender su funcionamiento, sobre el cual no nos extenderemos aquí en la wiki de ASF. Esta sección es principalmente para casos de uso de configuraciones muy complejas, por ejemplo, en lo que respecta a redes avanzadas y seguridad más allá del "sandboxing" estándar con el que viene ASF en el servicio  `systemd` (el cual ya garantiza un proceso de aislamiento superior a través de mecanismos de seguridad muy avanzados). Para esas pocas personas, aquí explicamos mejor conceptos de ASF en cuanto a su compatibilidad con Docker, y solo eso, se asume que tienes un conocimiento adecuado de Docker si decides usarlo junto con ASF.

---

## Etiquetas

ASF está disponible a través de 4 tipos principales de **[etiquetas](https://hub.docker.com/r/justarchi/archisteamfarm/tags)**:


### `main`

Esta etiqueta siempre apunta al ASF compilado a partir del último commit en la rama `main`, que funciona igual que tomar el último artefacto directamente de nuestro canal de **[integración continua](https://github.com/JustArchiNET/ArchiSteamFarm/actions/workflows/publish.yml?query=branch%3Amain)**. Normalmente debes evitar esta etiqueta, ya que es el nivel más alto de software con bugs dedicado a desarrolladores y usuarios avanzados para fines de desarrollo. La imagen se actualiza con cada commit en la rama `main` de GitHub, por lo tanto puedes esperar actualizaciones muy frecuentes (y cosas con fallos). Esta etiqueta está aquí para que marquemos el estado actual del proyecto ASF, que no necesariamente se garantiza que sea estable o probado, tal como se indica en nuestro ciclo de lanzamiento. Esta etiqueta no debe ser usada en ningún entorno de producción.


### `released`

Muy similar a la anterior, esta etiqueta siempre apunta a la última versión **[publicada](https://github.com/JustArchiNET/ArchiSteamFarm/releases)** de ASF, incluyendo prelanzamientos. Comparado con la etiqueta `main`, esta imagen se actualiza cada vez que se envía una nueva etiqueta de GitHub. Dedicado a usuarios avanzados que les encanta vivir al límite de lo que se puede considerar estable y fresco al mismo tiempo. Esta es la que recomendamos si no quieres usar la etiqueta `latest`. En la práctica funciona igual que usar la etiqueta apuntando a la versión `A.B.C.D` más reciente al momento de la solicitud. Por favor, ten en cuenta que usar esta etiqueta es igual a usar nuestros **[prelanzamientos](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Release-cycle-es-ES)**.


### `latest`

Esta etiqueta en comparación con otras, es la única que incluye la característica de actualizaciones automáticas y apunta a la última versión **[estable](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** de ASF. El objetivo de esta etiqueta es proporcionar un contenedor Docker por defecto que sea capaz de ejecutar una compilación autoactualizable de ASF para sistema operativo específico. Debido a eso, la imagen no tiene que actualizarse con tanta frecuencia, ya que la versión incluida de ASF siempre será capaz de actualizarse si es necesario. Por supuesto, `UpdatePeriod` puede desactivarse de forma segura (establecido a `0`), pero en este caso probablemente debas usar una versión congelada `A.B.C.D`. Del mismo modo, puedes modificar el `UpdateChannel` por defecto para hacer autoactualizable la etiqueta `released`.

Debido a que la imagen `latest` tiene la capacidad de actualizarse automáticamente, incluye un sistema operativo básico con la versión de sistema operativo específico `linux` de ASF , contrario a todas las demás etiquetas que incluyen sistema operativo con .NET runtime y la versión `generic` de ASF. Esto se debe a que la versión más reciente (actualizada) de ASF también podría requerir un runtime más reciente que el que posiblemente esté integrado en la imagen, que de otro modo requeriría que la imagen sea recompilada desde cero, anulando el caso de uso previsto.

### `A.B.C.D`

En comparación con las etiquetas anteriores, esta etiqueta está completamente congelada, lo que significa que la imagen no se actualizará una vez publicada. Esto funciona similar a nuestras publicaciones de GitHub que nunca se tocan después de la publicación inicial, lo que te garantiza un entorno estable y congelado. Normalmente deberías usar esta etiqueta cuando deseas usar una versión específica de ASF y no quieres usar ningún tipo de actualizaciones automáticas (por ejemplo, las ofrecidas en la etiqueta `latest`).

---

## ¿Qué etiqueta es mejor para mí?

Eso depende de lo que busques. Para la mayoría de los usuarios, la etiqueta `latest` debería ser la mejor ya que ofrece exactamente lo que hace ASF de escritorio, solo que en un contenedor Docker especial como servicio. Las personas que recompilan sus imágenes con frecuencia y en su lugar preferirían tener control total con la versión de ASF ligada a un lanzamiento determinado son bienvenidas a usar la etiqueta `released`. Si en cambio quieres usar alguna versión congelada de ASF que nunca cambiará sin tu clara intención, las versiones `A.B.C.D` están disponibles como marcas fijas a las que siempre puedes regresar.

Generalmente no recomendamos probar las compilaciones `main`, ya que estas son para marcar el estado actual del proyecto de ASF. Nada garantiza que dicho estado funcione correctamente, pero eres más que bienvenido a probarlas si estás interesado en el desarrollo de ASF.

---

## Arquitecturas

La imagen docker ASF se compila actualmente en la plataforma `linux` teniendo como objetivo tres arquitecturas - `x64`, `arm` y `arm64`. Puedes leer más acerca de ellas en la sección de **[compatibilidad](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility-es-ES)**.

Nuestras etiquetas usan un manifiesto multiplataforma, lo que significa que Docker instalado en tu máquina automáticamente seleccionará la imagen adecuada para tu plataforma al requerir la imagen. Si por algún motivo deseas extraer una imagen de plataforma específica que no coincida con la que estás ejecutando, puedes hacerlo mediante el modificador `--platform` con los comandos docker apropiados, tal como `docker run`. Para más información revisa la documentación docker en **[image manifest](https://docs.docker.com/registry/spec/manifest-v2-2)**.

---

## Uso

Para una referencia completa debes usar la **[documentación oficial de docker](https://docs.docker.com/engine/reference/commandline/docker)**, solo cubriremos el uso básico en esta guía, eres más que bienvenido a profundizar más.

### ¡Hola, ASF!

Primeramente debemos verificar si nuestro docker funciona correctamente, esto servirá como nuestro "hola, mundo" de ASF:

```shell
docker run -it --name asf --pull always --rm justarchi/archisteamfarm
```

`docker run` crea un nuevo contenedor docker ASF y lo ejecuta en primer plano (`-it`). `--pull always` asegura que una imagen actualizada sea extraída primero, y `--rm` asegura que nuestro contenedor sea purgado una vez que se detenga, ya que solo estamos probando si todo funciona bien por ahora.

Si todo termina exitosamente, después de quitar todas las capas e iniciar el contenedor, deberías notar que ASF inició correctamente e informó que no hay bots definidos, lo que es bueno - hemos verificado que ASF en docker funciona correctamente. Presiona `CTRL+C` para terminar el proceso de ASF y por lo tanto también el contenedor.

Si observas más de cerca el comando entonces notarás que no declaramos ninguna etiqueta, que automáticamente está predeterminada a `latest`. Si quieres usar otra etiqueta que no sea `latest`, por ejemplo `released`, entonces debes declararla explícitamente:

```shell
docker run -it --name asf --pull always --rm justarchi/archisteamfarm:released
```

---

## Usando un volumen

Si usas ASF en un contenedor docker obviamente necesitas configurar el programa. Puedes hacerlo de varias formas, pero la recomendada sería crear el directorio `config` de ASF en la máquina local, luego montarla como un volumen compartido en el contenedor docker de ASF.

Por ejemplo, supongamos que tu carpeta de configuraciones de ASF está en el directorio `/home/archi/ASF/config`. Este directorio contiene `ASF.json` así como los bots que queremos ejecutar. Ahora todo lo que tenemos que hacer es adjuntar ese directorio como volumen compartido en nuestro contenedor docker, donde ASF espera que esté su directorio de configuraciones (`/app/config`).

```shell
docker run -it -v /home/archi/ASF/config:/app/config --name asf --pull always justarchi/archisteamfarm
```

Y eso es todo, ahora el contenedor docker ASF usará el directorio compartido con tu máquina local en modo lectura-escritura, que es todo lo que necesitas para configurar ASF. De forma similar puedes montar otros volúmenes que te gustaría compartir con ASF, tal como `/app/logs` o `/app/plugins`.

Por supuesto, esta solo es una forma específica de lograr lo que queremos, nada te impide, por ejemplo, crear tu propio `Dockerfile` que copiará tus archivos de configuración en el directorio `/app/config` dentro del contenedor docker ASF. Solo estamos cubriendo el uso básico en esta guía.

### Permisos del volumen

El contenedor de ASF por defecto se inicia con el usuario `root` predeterminado,  lo que permite manejar los permisos internos y eventualmente cambiar al usuario `asf` (UID `1000`) para la parte restante del proceso principal. Aunque esto debería ser satisfactorio para la gran mayoría de usuarios, afecta al volumen compartido ya que los archivos recién generados normalmente serán propiedad del usuario `asf`, lo que puede no ser la situación deseada si quieres tener otro usuario para tu volumen compartido.

Hay dos maneras en las que puedes cambiar el usuario bajo el que se ejecuta ASF. La primera, recomendad, es declarar la variable de entorno `ASF_USER` con el UID objetico bajo el que quieres ejecutar. La segunda, como alternativa, es pasar el **[parámetro](https://docs.docker.com/engine/reference/run/#user)** `--user`. que está directamente soportado por docker.

Puedes comprobar tu `uid` con el comando `id -u`, y luego declararlo como se especificó arriba. Por ejemplo, si tu usuario objetivo tiene un `uid` de 1001:

```shell
docker run -it -e ASF_USER=1001 -v /home/archi/ASF/config:/app/config --name asf --pull always justarchi/archisteamfarm

# Alternativamente, si entiendes las limitaciones que se indican más adelante
docker run -it -u 1001 -v /home/archi/ASF/config:/app/config --name asf --pull always justarchi/archisteamfarm
```

La diferencia entre  `ASF_USER` y `--user` es sutil, pero importante. `ASF_USER` es un mecanismo personalizado soportado por ASF, en este escenario el contenedor docker aún inicia como `root`, y después el script de inicio de ASF comienza el ejecutable principal bajo `ASF_USER`. Al usar el parámetro `--user`, estás iniciando todo el proceso, incluyendo el script de inicio de ASF como un usuario determinado. La primera opción permite al script de inicio de ASF manejar permisos y otras cosas automáticamente, resolviendo algunos problemas comunes que podrías haber causado, por ejemplo, asegura que tus directorios `/app` y `/asf` realmente sean propiedad de `ASF_USER`. En el segundo escenario, ya que no estamos ejecutando como `root`, no podemos hacer eso, y se espera que tú mismo lo hagas con antelación.

Si decides usar el parámetro  `--user`, necesitas cambiar la propiedad de todos los archivos de ASF del predeterminado `asf` al tu nuevo usuario personalizado. Puedes hacerlo ejecutando el siguiente comando:

```shell
# Ejecutar solamente si no estás usando ASF_USER
docker exec -u root asf chown -hR 1001 /app /asf
```

Esto solo tiene que hacerse una vez después de crear el contenedor con `docker run`, y solo si decidiste usar usuario personalizado a través del parámetro de docker `--user`. Igualmente, no olvides cambiar el argumento `1001` en el comando anterior al `UID` bajo el que realmente quieres ejecutar ASF.

### Volumen con SELinux

Si estás usando SELinux en estado forzado en tu sistema operativo, que es lo predeterminado por ejemplo en distros basadas en RHEL, entonces deberías montar el volumen añadiendo la opción `:Z`, lo que establecerá el contexto SELinux correcto para ello.

```
docker run -it -v /home/archi/ASF/config:/app/config:Z --name asf --pull always justarchi/archisteamfarm
```

Esto permitirá a ASF crear archivos que tengan como objetivo el volumen dentro del contenedor docker.

---

## Sincronización de múltiples instancias

ASF incluye soporte para la sincronización de múltiples instancias, como se menciona en la sección de **[gestión](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management-es-ES#m%C3%BAltiples-instancias)**. Al ejecutar ASF en el contenedor docker, opcionalmente puedes "participar" en el proceso, en caso de que estés ejecutando múltiples contenedores con ASF y quieres que se sincronicen entre sí.

Por defecto, cada ASF ejecutándose dentro de un contenedor es independiente, lo que significa que no hay sincronización alguna. Para habilitar la sincronización entre ellos, debes enlazar la ruta `/tmp/ASF` en cada contenedor de ASF que quieras que se sincronice, a una ruta compartida en tu host docker, en modo lectura-escritura. Esto se logra exactamente igual que enlazar un volumen, lo que se describió anteriormente, solo que con diferentes rutas:

```shell
mkdir -p /tmp/ASF-g1
docker run -v /tmp/ASF-g1:/tmp/ASF -v /home/archi/ASF/config:/app/config --name asf1 --pull always justarchi/archisteamfarm
docker run -v /tmp/ASF-g1:/tmp/ASF -v /home/john/ASF/config:/app/config --name asf2 --pull always justarchi/archisteamfarm
# Y así sucesivamente, ahora todos los contenedores de ASF están sincronizados entre sí
```

Recomendamos enlazar el directorio de ASF `/tmp/ASF` también al directorio temporal `/tmp` en tu máquina, pero eres libre de elegir cualquier otro que se ajuste a tu uso. Cada contenedor de ASF que se espera que esté sincronizado debería tener su directorio `/tmp/ASF` compartido con otros contenedores que forman parte del mismo proceso de sincronización.

Como probablemente hayas notado del ejemplo anterior, también es posible crear dos o más "grupos de sincronización", vinculando diferentes rutas del host docker al directorio `/tmp/ASF` de ASF.

Montar `/tmp/ASF` es completamente opcional y no recomendable, a menos que explícitamente quieras sincronizar dos o más contenedores de ASF. No recomendamos montar `/tmp/ASF` para uso de un solo contenedor, ya que no aporta ningún beneficio si esperas ejecutar solo un contenedor de ASF, y en realidad podría causar problemas que de otro modo podrían evitarse.

---

## Argumentos de la línea de comandos

ASF permite pasar **[argumentos de la línea de comandos](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments-es-ES)** en el contenedor docker a través de variables de entorno. Debes usar variables de entorno específicas para los parámetros soportados, y `ASF_ARGS` para el resto. Esto se puede lograr con el parámetro `-e` añadido a `docker run`, por ejemplo:

```shell
docker run -it -e "ASF_CRYPTKEY=MyPassword" -e "ASF_ARGS=--no-config-migrate" --name asf --pull always justarchi/archisteamfarm
```

Esto pasará correctamente tu argumento `--cryptkey` al proceso de ASF que se ejecuta dentro del contenedor docker, así como otros argumentos. Por supuesto, si eres un usuario avanzado, también puedes modificar `ENTRYPOINT` o añadir `CMD` y pasar tus argumentos personalizados.

A menos que desees proporcionar una clave de cifrado personalizada u otras opciones avanzadas, normalmente no necesitas incluir ninguna variable de entorno especial, puesto que nuestros contenedores docker ya están configurados para ejecutarse con opciones predeterminadas de `--no-restart` `--process-required` `--system-required`, así que esas banderas no necesitan ser especificadas explícitamente en `ASF_ARGS`.

---

## IPC

Suponiendo que no cambiaste el valor predeterminado de la **[propiedad de configuración global](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-es-ES#configuraci%C3%B3n-global)** `IPC`, esta ya se encuentra habilitada. Sin embargo, debes hacer dos cosas adicionales para que la IPC funcione en el contenedor Docker. Primero, debes usar `IPCPassword` o modificar `KnownNetworks` predeterminado mediante una configuración personalizada en `IPC.config` para permitir que te conectes desde el exterior sin usar una contraseña. A menos que realmente sepas lo que estás haciendo, solo usa `IPCPassword`. Segundo, tienes que modificar la dirección de escucha predeterminada de `localhost`, ya que docker no puede enrutar el tráfico externo a la interfaz loopback. Un ejemplo de configuración que escuchará en todas las interfaces sería: `http://*:1242`. Claro, también puedes usar enlaces más restrictivos, como solo LAN local o red VPN, pero tiene que ser una ruta accesible desde el exterior - `localhost` no funcionará, ya que la ruta está enteramente en la máquina huésped.

Para hacer lo anterior debes usar una **[configuración IPC personalizada](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-es-ES#configuraci%C3%B3n-personalizada)** como la siguiente:

```json
{
    "Kestrel": {
        "Endpoints": {
            "HTTP": {
                "Url": "http://*:1242"
            }
        }
    }
}
```

Una vez que establezcamos IPC en una interfaz no-loopback, necesitamos decirle al docker que mapee el puerto `1242/tcp` de ASF con el parámetro `-P` o `-p`.

Por ejemplo, este comando expondría la interfaz IPC de ASF a la máquina anfitrión (solo):

```shell
docker run -it -p 127.0.0.1:1242:1242 -p [::1]:1242:1242 --name asf --pull always justarchi/archisteamfarm
```

Si estableciste todo correctamente, el comando `docker run` hará que la interfaz **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-es-ES)** funcione desde tu máquina anfitrión, en la ruta estándar `localhost:1242` que ahora está redirigida correctamente a tu máquina huésped. También es bueno notar que no exponemos de más esta ruta, así la conexión se puede hacer solo dentro del húesped docker, y por lo tanto mantenerla segura. Por supuesto, puedes exponer la ruta aún más si sabes lo que haces y aplicas las medidas de seguridad apropiadas.

---

### Ejemplo completo

Combinando todo el conocimiento anterior, un ejemplo de configuración completa se vería así:

```shell
docker run -p 127.0.0.1:1242:1242 -p [::1]:1242:1242 -v /home/archi/ASF/config:/app/config -v /home/archi/ASF/plugins:/app/plugins --name asf --pull always justarchi/archisteamfarm
```

Esto asume que usarás un solo contenedor de ASF, con todos los archivos de configuración de ASF en `/home/archi/ASF/config`. Debes modificar la ruta de configuración a la que coincide con tu máquina. También es posible proporcionar plugins personalizados para ASF, los cuales puedes colocar en `/home/archi/ASF/plugins`. Esta configuración también está lista para el uso opcional de IPC si decidiste incluir `IPC.config` en tu directorio de configuración con un contenido como el siguiente:

```json
{
    "Kestrel": {
        "Endpoints": {
            "HTTP": {
                "Url": "http://*:1242"
            }
        }
    }
}
```

---

## Consejos avanzados

Cuando ya tengas listo tu contenedor docker ASF, no tienes que usar `docker run` cada vez. Fácilmente puedes detener/iniciar el contenedor docker ASF con `docker stop asf` y `docker start asf`. Ten en cuenta que si no estás usando la etiqueta `latest` entonces usar ASF actualizado requerirá que ejecutes de nuevo los comandos `docker stop`, `docker rm` y `docker run`. Esto es porque debes recompilar tu contenedor a partir de una imagen docker ASF cada vez que quieras usar una versión de ASF incluida en esa imagen. En la etiqueta `latest`, ASF tiene la capacidad de actualizarse automáticamente, así que recompilar la imagen no es necesario para usar un ASF actualizado (pero sigue siendo buena idea hacer de vez en cuando para usar dependencias .NET runtime recientes y el sistema operativo subyacente, el cual podría ser requerido al saltar entre actualizaciones mayores de ASF).

Como se ha mencionado arriba, ASF en una etiqueta diferente de `latest` no se actualizará automáticamente, lo que significa que **tú** eres responsable de usar un repositorio `justarchi/archisteamfarm` actualizado. Esto tiene muchas ventajas, ya que normalmente la aplicación no debe tocar su propio código cuando se ejecuta, pero también entendemos la conveniencia que viene de no tener que preocuparse por la versión de ASF en tu contenedor docker. Si te importan las buenas prácticas y un uso adecuado del docker, sugerimos usar la etiqueta `released` en lugar de `latest`, pero si no quieres molestarte con eso y solo quieres hacer que ASF funcione y se actualice automáticamente, entonces la etiqueta `latest` servirá.

Normalmente deberías ejecutar ASF en el contenedor docker con la configuración global `Headless: true`. Esto claramente le dirá a ASF que no podrás proporcionar los datos faltantes y que no debe pedirlos. Por supuesto, para la configuración inicial debes considerar dejar esa opción en `false` para que puedas configurar las cosas fácilmente, pero a largo plazo normalmente no estás atado a la consola de ASF, por lo tanto tendría sentido informar a ASF sobre eso y usar el **[comando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-es-ES)** `input` si surge la necesidad. De esta forma ASF no tendrá que esperar infinitamente una interacción del usuario que nunca sucederá (y desperdiciar recursos mientras tanto). También permitirá que ASF se ejecute en modo no interactivo dentro del contenedor, lo que es crucial, por ejemplo, en lo que respecta al reenvío de señales, haciendo posible que ASF se cierre adecuadamente con la solicitud `docker stop asf`.