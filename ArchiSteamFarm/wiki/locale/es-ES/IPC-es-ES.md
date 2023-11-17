# IPC

ASF incluye su propia interfaz IPC que puede usarse para mayor interacción con el proceso. IPC significa **[comunicación entre procesos](https://es.wikipedia.org/wiki/Comunicaci%C3%B3n_entre_procesos)** (por sus siglas en inglés) y en la definición más simple esto es "interfaz web de ASF" basada en **[Kestrel HTTP server](https://github.com/aspnet/KestrelHttpServer)** que puede usarse para mayor integración con el proceso, tanto como un frontend para el usuario final (ASF-ui), como un backend para integración con aplicaciones de terceros.

La IPC puede ser usada para diferentes cosas, dependiendo de tus necesidades y habilidades. Por ejemplo, puedes usarlo para obtener el estatus de ASF y de todos los bots, enviar comandos de ASF, obtener y editar configuraciones globales/de bot, añadir nuevos bots, eliminar bots existentes, enviar claves para el **[activador de juegos en segundo plano](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer-es-ES)** o acceder al archivo de registro de ASF. Todas esas acciones están expuestas por nuestra API, lo que significa que puedes codificar tus propias herramientas y scripts que sean capaces de comunicarse con ASF e influenciarlo durante el tiempo de ejecución. Además, algunas acciones selectas (como enviar comandos) también son implementadas por nuestro ASF-ui que te permite acceder a ellas fácilmente a través de una interfaz web amigable.

---

# Uso

A menos que hayas deshabilitado manualmente la IPC a través de la **[propiedad de configuración global](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-es-ES#configuraci%C3%B3n-global)** `IPC`, esta ya se encuentra habilitada por defecto. ASF declarará la ejecución de IPC en su registro, lo que puedes usar para verificar que la interfaz IPC inició correctamente:

```text
INFO|ASF|Start() Iniciando servidor IPC...
INFO|ASF|Start() ¡Servidor IPC listo!
```

El servidor http de ASF ahora está escuchando en endpoints seleccionados. Si no proporcionaste un archivo de configuración personalizada para IPC, estos serán **[127.0.0.1](http://127.0.0.1:1242)** basado en IPv4 y el basado en IPv6 **[[::1]](http://[::1]:1242)** en el puerto por defecto `1242`. Puedes acceder a nuestra interfaz IPC mediante los enlaces anteriores, desde la misma máquina en que se ejecuta el proceso ASF.

La interfaz IPC de ASF ofrece tres formas diferentes de acceder a ella, dependiendo del uso previsto.

En el nivel inferior está **[ASF API](#asf-api)** que es el núcleo de nuestra interfaz IPC y permite que todo lo demás opere. Esto es lo que debes usar en tus herramientas, utilidades y proyectos para comunicarte directamente con ASF.

En el terreno medio está nuestra **[documentación Swagger](#documentación-swagger)** que actúa como un frontend para la API de ASF. Contiene documentación completa de la API de ASF y también te permite acceder a ella más fácilmente. Esto es lo que quieres revisar si planeas escribir una herramienta, utilidad u otro proyecto que deba comunicarse con ASF a través de su API.

En el nivel más alto está **[ASF-ui](#asf-ui)** que se basa en nuestra ASF API y proporciona una forma amigable de ejecutar varias acciones en ASF. Esta es nuestra interfaz IPC predeterminada diseñada para los usuarios finales, y es un perfecto ejemplo de lo que puedes construir con la API de ASF. Si lo deseas, puedes usar tu propia interfaz web con ASF, especificando el **[argumento de la línea de comandos](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments-es-ES#argumentos)** `--path` y usando el directorio personalizado `www` ubicado allí.

---

# ASF-ui

ASF-ui es un proyecto de la comunidad que pretende crear una interfaz gráfica amigable para los usuarios finales. Para lograrlo, actúa como un frontend de nuestra **[ASF API](#asf-api)**, permitiéndote realizar varias acciones con facilidad. Esta es la interfaz por defecto con la que viene ASF.

Como se dijo antes, ASF-ui es un proyecto comunitario que no es mantenido por los desarrolladores de ASF. Sigue su propio curso de desarrollo en el **[repositorio de ASF-ui](https://github.com/JustArchiNET/ASF-ui)** el cual debe ser usado para todas las preguntas relacionadas, problemas, reporte de bugs y sugerencias.

Puedes usar ASF-ui para la gestión general del proceso de ASF. Permite por ejemplo, administrar bots, modificar ajustes, enviar comandos y lograr otras funcionalidades normalmente disponibles a través de ASF.

![ASF-ui](https://raw.githubusercontent.com/JustArchiNET/ASF-ui/main/.github/previews/bots.png)

---

# ASF API

Nuestra ASF API es una típica API web **[RESTful](https://es.wikipedia.org/wiki/Transferencia_de_Estado_Representacional)** que se basa en JSON como su formato de datos principal. Hacemos todo lo posible para describir la respuesta con precisión, usando tanto códigos de estatus HTTP (donde sea apropiado), así como una respuesta que tú mismo puedas analizar para saber si la solicitud tuvo éxito, y si no, por qué.

Nuestra ASF API puede ser accedida enviando las solicitudes correctas a los endpoints `/Api` apropiados. Puedes usar esos endpoints API para crear tus propios scripts auxiliares, herramientas, interfaces gráficas y demás. Esto es exactamente lo que logra nuestra ASF-ui bajo el capó, y cualquier otra herramienta puede lograr lo mismo. ASF API es soportada oficialmente y mantenida por el equipo de ASF.

Para una documentación completa de endpoints disponibles, descripciones, solicitudes, respuestas, códigos de estatus http y todo lo demás relacionado con la API de ASF, por favor, consulta nuestra **[documentación Swagger](#documentación-swagger)**.

![ASF API](https://i.imgur.com/yggjf5v.png)

---

# Configuración personalizada

Nuestra interfaz IPC admite un archivo de configuración adicional, `IPC.config` que debe ser colocado en el directorio `config` de ASF.

Cuando está disponible, este archivo especifica la configuración avanzada del servidor Kestrel http de ASF, junto con otros ajustes relacionados con IPC. A menos que tengas una necesidad particular, no hay razón para que uses este archivo, dado que ASF por defecto ya usa valores razonables en este caso.

El archivo de configuración se basa en la siguiente estructura JSON:

```json
{
    "Kestrel": {
        "Endpoints": {
            "example-http4": {
                "Url": "http://127.0.0.1:1242"
            },
            "example-http6": {
                "Url": "http://[::1]:1242"
            },
            "example-https4": {
                "Url": "https://127.0.0.1:1242",
                "Certificate": {
                    "Path": "/path/to/certificate.pfx",
                    "Password": "passwordToPfxFileAbove"
                }
            },
            "example-https6": {
                "Url": "https://[::1]:1242",
                "Certificate": {
                    "Path": "/path/to/certificate.pfx",
                    "Password": "passwordToPfxFileAbove"
                }
            }
        },
        "KnownNetworks": [
            "10.0.0.0/8",
            "172.16.0.0/12",
            "192.168.0.0/16"
        ],
        "PathBase": "/"
    }
}
```

`Endpoints` - Esta es una colección de endpoints, con cada endpoint con su propio nombre único (como `ejemplo-http4`) y la propiedad `Url` que especifica la dirección de escucha `Protocol://Host:Port`. Por defecto, ASF escucha en las direcciones http IPv4 y IPv6, pero hemos añadido ejemplos https para que uses, si es necesario. Solo debes declarar aquellos endpoints que necesitas, hemos incluido 4 ejemplos arriba para que puedas editarlos más fácilmente.

`Host` acepta tanto `localhost`, una dirección IP fija de la interfaz en la que debería escuchar (IPv4/IPv6), o el valor `*` que vincula el servidor http de ASF a todas las interfaces disponibles. Usar otros valores como `mydomain.com` o `192.168.0.*` actúa igual que `*`, no hay ningún filtro IP implementado, por lo tanto debes ser extremadamente cuidadoso al usar valores `Host` que permitan el acceso remoto. Si lo haces se habilitará el acceso a la interfaz IPC de ASF desde otras máquinas, lo que puede suponer un riesgo de seguridad. Recomendamos fuertemente usar `IPCPassword` (y de preferencia también tu propio cortafuegos) **como mínimo** en este caso.

`KnownNetworks` - Esta variable **opcional** especifica las direcciones de red que consideramos confiables. Por defecto, ASF está configurado para confiar **solamente** en la interfaz loopback (`localhost`, misma máquina) Esta propiedad se utiliza de dos maneras. Primero, si omites `IPCPassword`, entonces solo permitiremos máquinas de redes conocidas para acceder a la IPC de ASF, y como medida de seguridad negaremos todo lo demás. En segundo lugar, esta propiedad es crucial en lo que se refiere a proxies inversos accediendo a ASF, ya que ASF respetará sus cabeceras solo si el servidor de proxy inverso está dentro de las redes conocidas. Respetar las cabeceras es crucial para el mecanismo anti fuerza bruta de ASF, ya que en lugar de prohibir el proxy inverso en caso de un problema, bloqueará la IP especificada por el proxy inverso como la fuente del mensaje original. Ten mucho cuidado con las redes que especificas aquí, ya que permite un posible ataque de falsificación de IP y acceso no autorizado en caso de que la máquina de confianza se vea comprometida o esté mal configurada.

`PathBase` - Esta es la ruta base **opcional** que será usada por la interfaz IPC. Por defecto es `/` y no debería ser necesario modificarlo para la mayoría de los casos. Al cambiar esta propiedad alojarás toda la interfaz IPC en un prefijo personalizado, por ejemplo, `http://localhost:1242/MyPrefix` en lugar de solo `http://localhost:1242`. Usar un `PathBase` personalizado puede ser deseable en combinación con la configuración específica de un proxy inverso donde quieres hacer proxy solo a una URL específica, por ejemplo, `midominio.com/ASF` en lugar de todo el dominio `midominio.com`. Normalmente eso requeriría que escribas una regla de reescritura para tu servidor web que mapee `mydomain.com/ASF/Api/X` -> `localhost:1242/Api/X`, pero en su lugar puedes definir un `PathBase` personalizado de `/ASF` y lograr más fácilmente la configuración de `mydomain.com/ASF/Api/X` -> `localhost:1242/ASF/Api/X`.

A menos que realmente necesites especificar una ruta base personalizada, es mejor dejarlo en sus valores por defecto.

## Configuraciones de ejemplo

### Cambiar el puerto predeterminado

La siguiente configuración simplemente cambia el puerto de escucha de ASF de `1242` a `1337`. Puedes elegir el puerto que desees, pero recomendamos el rango `1024-32767`, ya que normalmente otros puertos están **[registrados](https://en.wikipedia.org/wiki/Registered_port)**, y podrían, por ejemplo, requerir acceso `root` en Linux.

```json
{
    "Kestrel": {
        "Endpoints": {
            "HTTP4": {
                "Url": "http://127.0.0.1:1337"
            },
            "HTTP6": {
                "Url": "http://[::1]:1337"
            }
        }
    }
}
```

---

### Habilitar el acceso desde todas las IP

La siguiente configuración permitirá el acceso remoto desde todas las fuentes, por lo tanto debes **asegurarte de leer y entender nuestro aviso de seguridad al respecto**, disponible arriba.

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

Si no requieres acceso desde todas las fuentes, sino solamente de tu LAN por ejemplo, entonces es mejor idea comprobar las direcciones IP de la máquina alojando ASF, por ejemplo `192.168.0.10` y usarlo en lugar de `*` mencionado en el ejemplo de configuración anterior.

---

# Autenticación

La interfaz IPC de ASF por defecto no requiere ningún tipo de autenticación, ya que `IPCPassword` está configurado en `null`. Sin embargo, si `IPCPassword` está habilitado al tener cualquier valor no vacío, cada llamada a la API de ASF requiere la contraseña que coincida con la establecida en `IPCPassword`. Si omites la autenticación o introduces una contraseña incorrecta, obtendrás el error `401 - Unauthorized`. Después de 5 intentos de autenticación fallidos (contraseña incorrecta), se bloqueará temporalmente con el error `403 - Forbidden`.

La autenticación puede hacerse a través de dos formas diferentes.

## Cabecera `Authentication`

En general debes usar cabeceras de solicitud HTTP, estableciendo el campo `Authentication` con tu contraseña como valor. La forma de hacerlo depende de la herramienta que estés usando para acceder a la interfaz IPC de ASF, por ejemplo, si usas `curl` entonces debes añadir `-H 'Authentication: MyPassword'` como parámetro. De esta manera la autenticación es pasada en las cabeceras de la solicitud, donde de hecho debe ocurrir.

## Parámetro `password` en una cadena de consulta

Alternativamente puedes añadir el parámetro `password` al final de la URL que estás a punto de llamar, por ejemplo, llamando `/Api/ASF?password=MyPassword` en lugar de solamente `/Api/ASF`. Este enfoque es suficiente, pero obviamente expone la contraseña, lo que no siempre es apropiado. Además de eso está el argumento adicional en la cadena de consulta, lo que complica el aspecto de la URL y hace que parezca que es específico de la URL, mientras que la contraseña se aplica a toda la comunicación de la API de ASF.

---

Ambas formas son soportadas y depende totalmente de ti cuál quieres elegir. Recomendamos usar cabeceras HTTP siempre que sea posible, ya que es más apropiado que la cadena de consulta. Sin embargo, también se soporta la cadena de consulta, principalmente por las varias limitaciones relacionadas con las cabeceras de solicitud. Un buen ejemplo incluye la falta de cabeceras personalizadas al iniciar una conexión websocket en javascript (aunque sea completamente válida de acuerdo al RFC). En esta situación una cadena de consulta es la única forma de autenticar.

---

# Documentación Swagger

Nuestra interfaz IPC, además de la ASF API y ASF-ui también incluye documentación Swagger, la cual está disponible en la **[URL](http://localhost:1242/swagger)** `/swagger`. La documentación Swagger sirve como intermediario entre nuestra implementación API y otras herramientas que la utilicen (por ejemplo ASF-ui). Proporciona una documentación completa y disponibilidad de todos los endpoints API en la especificación **[OpenAPI](https://swagger.io/resources/open-api)** que puede ser integrada fácilmente por otros proyectos, permitiéndote escribir y probar la API de ASF con facilidad.

Además de usar nuestra documentación Swagger como una especificación completa de la API de ASF, también puedes usarla como una forma amigable de ejecutar varios endpoints API, principalmente aquellos que no están implementados por ASF-ui. Dado que nuestra documentación Swagger es generada automáticamente a partir del código de ASF, tienes la garantía de que la documentación siempre estará actualizada con los endpoints API que incluye tu versión de ASF.

![Documentación Swagger](https://i.imgur.com/mLpd5e4.png)

---

# Preguntas frecuentes

### ¿Es seguro usar la interfaz IPC de ASF?

ASF por defecto solo escucha en direcciones `localhost`, lo que significa que acceder a la IPC de ASF desde otra máquina que no sea la tuya **es imposible**. A menos que modifiques los endpoints predeterminados, el atacante necesitaría acceso directo a tu máquina para acceder a la IPC de ASF, por lo tanto es tan seguro como puede ser y no hay posibilidad de que alguien más acceda a ella, incluso desde tu propia LAN.

Sin embargo, si decides modificar las direcciones `localhost` predeterminadas, entonces **tú mismo** debes establecer las reglas adecuadas de cortafuegos para permitir que solo las IP autorizadas accedan a la interfaz IPC de ASF. Además de eso, necesitarás configurar `IPCPassword`, ya que sin esto ASF no permitirá que otras máquinas accedan a la API de ASF, lo que añade una capa de seguridad adicional. En este caso también es posible que quieras ejecutar la interfaz IPC de ASF tras un proxy inverso, lo que se explica más abajo.

### ¿Puedo acceder a la API de ASF a través de mis propias herramientas o scripts de usuario?

Sí, para eso fue diseñada la API de ASF y puedes usar cualquier cosa capaz de enviar solicitudes HTTP para acceder. Los scripts de usuario locales siguen la lógica **[CORS](https://es.wikipedia.org/wiki/Intercambio_de_recursos_de_origen_cruzado)**, y permitimos el acceso de todos los orígenes para estos (`*`), siempre y cuando `IPCPassword` esté configurado, como una medida de seguridad adicional. Esto te permite ejecutar varias solicitudes ASF API autenticadas, sin permitir que scripts maliciosos lo hagan automáticamente (ya que necesitarían saber tu `IPCPassword` para lograrlo).

### ¿Puedo acceder remotamente a la IPC de ASF, por ejemplo, desde otra máquina?

Sí, recomendamos usar un proxy inverso para eso. De esta manera puedes acceder a tu servidor web de forma usual, que luego accederá a la IPC de ASF en la misma máquina. Alternativamente, si no quieres ejecutar un proxy inverso, puedes usar una **[configuración personalizada](#configuración-personalizada)** con la URL apropiada para ello. Por ejemplo, si tu máquina está en una VPN con la dirección `10.8.0.1`, puedes establecer la URL `http://10.8.0.1:1242` en la configuración IPC, lo que permitiría el acceso IPC desde tu VPN privada, pero no desde cualquier otro lugar.

### ¿Puedo usar la IPC de ASF tras un proxy inverso como Apache o Nginx?

**Sí**, nuestra IPC es totalmente compatible con tal configuración, por lo que eres libre de alojarlo frente a tus propias herramientas para seguridad y compatibilidad adicionales, si es lo que deseas. En general, el servidor http Kestrel de ASF es muy seguro y no presenta ningún riesgo cuando se conecta directamente a internet, pero ponerlo tras un proxy inverso como Apache o Nginx podría proporcionar funcionalidad adicional que no se podría lograr de otra forma, como asegurar la interfaz de ASF con **[autenticación básica](https://es.wikipedia.org/wiki/Autenticación_de_acceso_básica)**.

A continuación puedes encontrar un ejemplo de configuración Nginx. Incluimos el bloque `server` completo, aunque te interesan principalmente los bloques `location`. Por favor, consulta la **[documentación nginx](https://nginx.org/en/docs)** si necesitas más detalles.

```nginx
server {
    listen *:443 ssl;
    server_name asf.mydomain.com;
    ssl_certificate /path/to/your/certificate.crt;
    ssl_certificate_key /path/to/your/certificate.key;

    location ~* /Api/NLog {
        proxy_pass http://127.0.0.1:1242;

        # Solo si necesitas reemplazar el host predeterminado
#       proxy_set_header Host 127.0.0.1;

        # Los X-headers siempre deben ser especificados al hacer proxy de solicitudes a ASF
        # Son cruciales para la identificación correcta de la IP original, permitiendo a ASF, por ejemplo, bloquear a los atacantes y no tu servidor nginx
        # Especificarlos permite a ASF resolver correctamente las direcciones IP de los usuarios haciendo solicitudes - haciendo que nginx funcione como un proxy inverso
        # No especificarlos causará que ASF trate tu ngnix como un cliente - ngnix actuará como un proxy tradicional en este caso
        # Si no puedes alojar el servicio ngnix en la misma máquina que ASF, probablemente quieras configurar KnownNetworks correctamente además de estos
        proxy_set_header X-Forwarded-For $proxy_add_x_forwarded_for;
        proxy_set_header X-Forwarded-Host $host:$server_port;
        proxy_set_header X-Forwarded-Proto $scheme;
        proxy_set_header X-Forwarded-Server $host;
        proxy_set_header X-Real-IP $remote_addr;

        # Añadimos estas 3 opciones adicionales para proxy de websockets, véase https://nginx.org/en/docs/http/websocket.html
        proxy_http_version 1.1;
        proxy_set_header Connection "Upgrade";
        proxy_set_header Upgrade $http_upgrade;
    }

    location / {
        proxy_pass http://127.0.0.1:1242;

        # Solo si necesitas reemplazar el host predeterminado
#       proxy_set_header Host 127.0.0.1;

        # Los X-headers siempre deben ser especificados al hacer proxy de solicitudes a ASF
        # Son cruciales para la identificación correcta de la IP original, permitiendo a ASF, por ejemplo, bloquear a los atacantes y no tu servidor nginx
        # Especificarlos permite a ASF resolver correctamente las direcciones IP de los usuarios haciendo solicitudes - haciendo que nginx funcione como un proxy inverso
        # No especificarlos causará que ASF trate tu ngnix como un cliente - ngnix actuará como un proxy tradicional en este caso
        # Si no puedes alojar el servicio ngnix en la misma máquina que ASF, probablemente quieras configurar KnownNetworks correctamente además de estos
        proxy_set_header X-Forwarded-For $proxy_add_x_forwarded_for;
        proxy_set_header X-Forwarded-Host $host:$server_port;
        proxy_set_header X-Forwarded-Proto $scheme;
        proxy_set_header X-Forwarded-Server $host;
        proxy_set_header X-Real-IP $remote_addr;
    }
}
```

A continuación puedes encontrar un ejemplo de configuración Apache. Por favor, consulta la **[documentación de apache](https://httpd.apache.org/docs)** si necesitas más detalles.

```apache
<IfModule mod_ssl.c>
    <VirtualHost *:443>
        ServerName asf.mydomain.com

        SSLEngine On
        SSLCertificateFile /path/to/your/fullchain.pem
        SSLCertificateKeyFile /path/to/your/privkey.pem

        # TODO: Apache no puede hacer correctamente el emparejamiento que no distinga mayúsculas y minúsculas, por lo tanto codificamos los dos casos de uso más comunes
        ProxyPass "/api/nlog" "ws://127.0.0.1:1242/api/nlog"
        ProxyPass "/Api/NLog" "ws://127.0.0.1:1242/Api/NLog"

        ProxyPass "/" "http://127.0.0.1:1242/"
    </VirtualHost>
</IfModule>
```

### ¿Puedo acceder a la interfaz IPC a través del protocolo HTTPS?

**Sí**, puedes conseguirlo a través de dos formas diferentes. Una forma recomendada sería usar un proxy inverso, donde puedes acceder a tu servidor web a través de https como normalmente, y conectarte a través de este con la interfaz IPC de ASF en la misma máquina. De esta manera tu tráfico está totalmente cifrado y no necesitas modificar IPC de ninguna manera para soportar dicha configuración.

La segunda forma incluye especificar una **[configuración personalizada](#configuración-personalizada)** para la interfaz IPC de ASF donde puedas habilitar un endpoint https y proporcionar un certificado apropiado directamente a nuestro servidor Kestrel http. Esta forma se recomienda si no estás ejecutando ningún otro servidor web y no quieres ejecutar uno exclusivamente para ASF. De otro modo, es mucho más fácil lograr una configuración satisfactoria usando un mecanismo de proxy inverso.

---

### Durante el inicio de IPC recibo un error: `System.IO.IOException: Failed to bind to address, An attempt was made to access a socket in a way forbidden by its access permissions`

Este error indica que algo más en tu máquina ya está usando ese puerto, o lo tiene reservado para su futuro uso. Tú lo podrías estar causando si intentas ejecutar una segunda instancia de ASF en la misma máquina, pero lo más frecuente es que sea Windows excluyendo el puerto `1242` de tu uso, por lo tanto tendrás que mover ASF a otro puerto. Para ello, sigue la **[configuración de ejemplo](#cambiar-el-puerto-predeterminado)** de arriba, y simplemente intenta elegir otro puerto, tal como `12420`.

Por supuesto, también podrías intentar averiguar qué está bloqueando el puerto  `1242` del uso de ASF, y remover eso, pero normalmente es más problemático que simplemente indicarle a ASF que use otro puerto, así que omitiremos entrar en más detalles al respecto.

---

### ¿Por qué estoy recibiendo el error `403 Forbidden` cuando no uso `IPCPassword`?

A partir de ASF V5.1.2.1, hemos añadido una medida de seguridad adicional que, por defecto, solo permite a la interfaz loopback (`localhost`, tu propia máquina) acceder a la API de ASF sin establecer `IPCPassword` en la configuración. Esto se debe a que usar `IPCPassword` debe ser una medida de seguridad **mínima** establecida por todo aquel que decida exponer aún más la interfaz de ASF.

El cambio fue impuesto por el hecho de que una gran cantidad de instancias de ASF alojadas globalmente por usuarios incautos fueron tomadas por malhechores, normalmente dejando a la gente sin cuentas y sin los artículos en ellas. Podríamos decir que "podían leer esta página antes de abrir ASF a todo el mundo", pero tiene más sentido no permitir configuraciones inseguras de forma predeterminada, y requerir a los usuarios una acción si explícitamente quieren permitirlo, sobre lo cual elaboraremos a continuación.

En particular, puedes anular nuestra decisión especificando las redes en las que confías para contactar con ASF sin especificar `IPCPassword`, puedes establecerlas en la propiedad `KnownNetworks` en la configuración personalizada. Sin embargo, a menos que **realmente** sepas lo que haces y entiendes completamente los riesgos, en su lugar deberías usar `IPCPassword` puesto que declarar `KnownNetworks` permitirá incondicionalmente que todos los de esas redes accedan a la API de ASF. Hablamos en serio, la gente ya se estaba disparando en el pie creyendo que sus proxies inversos y sus reglas iptables eran seguras, pero no lo eran, `IPCPassword` es el primero y a veces el último guardián, si decides omitir este mecanismo simple, pero muy eficaz y seguro, será tu propia culpa.