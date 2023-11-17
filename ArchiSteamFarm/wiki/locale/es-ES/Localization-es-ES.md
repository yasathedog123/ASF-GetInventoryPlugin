# Localización

ASF es apoyado por el servicio Crowdin, lo que permite a cualquiera ayudar a traducir ASF a todos los idiomas hablados en el mundo. Para más información sobre cómo funciona Crowdin, por favor, revisa la **[introducción a Crowdin](https://support.crowdin.com/crowdin-intro)**.

Si te interesa lo que está ocurriendo actualmente, puedes revisar la **[actividad de ASF en Crowdin](https://crowdin.com/project/archisteamfarm/activity_stream)**.

---

## Alcance

Nuestra plataforma soporta la localización de nuestro programa principal ASF, así como el contenido localizable que ofrecemos junto con él. Esto incluye especialmente nuestro ASF-WebConfigGenerator, ASF-ui, así como nuestra wiki. Todo eso es posible traducirlo a través de la conveniente interfaz de Crowdin.

---

## Registrarse

Si quieres ayudar con ASF, ya sea traduciendo, revisando o aprobando traducciones, por favor, regístrate en nuestra **[página de proyecto en Crowdin](https://crowdin.com/project/archisteamfarm)**. ¡El registro es fácil y totalmente gratuito! ¡Después de iniciar sesión puedes elegir los idiomas que te gustaría tener asignados, luego proceder a las cadenas de ASF y ayudar al resto de la comunidad con la traducción de ASF a los idiomas más populares!

---

### Traducción

Si el idioma de tu elección todavía tiene algunas cadenas faltantes, puedes seleccionarlas y empezar a trabajar en la traducción. Hemos intentado hacer lo mejor en términos de flexibilidad de las traducciones, por lo tanto muchas cadenas incluyen variables adicionales que ASF proporcionará durante el tiempo de ejecución - esas están encerradas en corchetes con un número, tal como `{0}`. Esto permite que modifiques el formato predeterminado de la cadena, por ejemplo, moviendo una variable proporcionada por ASF a un lugar que satisfaga tu idioma y tu traducción, en lugar de estar obligado a un contexto y formato estrictos. Esto es especialmente importante en idiomas con escritura de derecha a izquierda, como el hebreo.

Por ejemplo, podrías tener una cadena como:

> We have {0} games to farm.

Pero según tu idioma, la siguiente frase podría tener más sentido:

> El número de juegos para recolectar es {0}.

O:

> {0} es el número de juegos para recolectar.

La flexibilidad se proporciona especialmente para ti, para que puedas expresar en otras palabras una frase de ASF para que se adapte mejor a tu idioma y mover el número proporcionado por ASF u otra información a un lugar que se ajuste a tu traducción (en lugar de traducir cada parte de forma independiente). Esto mejora la calidad general de la traducción.

---

### Revisión

Si tu cadena ya fue traducida por alguien más, puedes votar por ella. Votar hace posible elegir la mejor variante de la traducción, en lugar de apegarse a la sugerencia inicial - esto mejora aún más la calidad general de la traducción. Puedes votar por sugerencias ya disponibles, o sugerir tu propia traducción, que pasará por el mismo proceso. Al final, la cadena definitiva será elegida con base en la sugerencia con más votos, o como una elección del proofreader seleccionado para ese idioma quien personalmente apruebe una traducción dada (también basado en tus votos).

**No necesitas aprobación para ver tus cadenas traducidas en ASF**. La aprobación simplemente significa que alguien de confianza para nosotros ha revisado el contenido, o sea que - seleccionó la versión final de la traducción. Está totalmente bien tener traducciones apoyadas por la comunidad no aprobadas, donde tú votas por la mejor. ¡Mientras esté traducido, todo está bien! Y si crees que la traducción actual es mala, siempre puedes votar por la mejor, o sugerir una tú mismo.

---

### Proof-reading

Es buena idea tener una traducción consistente, incluso si esto puede tomar la libertad del proceso de revisión/votación de la comunidad explicado anteriormente. Esto se debe principalmente a que traducciones incorrectas que no necesariamente son malas pueden obtener tantos votos positivos que ya no es posible sugerir una traducción mejor, incluso si alguien la tiene.

Si tienes un historial de contribuciones en Crowdin o alguna otra plataforma/servicio de localización que podamos verificar y asumir que es confiable, con gusto te daremos acceso de proofreader para el idioma al que estás contribuyendo, así serás capaz de aprobar una traducción dada y hacerla consistente. El proofreading no es una tarea fácil, especialmente porque ASF puede ser muy "técnico" de vez en cuando y realmente difícil de traducir, pero entendemos que a menudo es necesario para una traducción perfecta. Por lo tanto, si puedes ayudar haciendo proofreading de un lenguaje dado, **[háznoslo saber](https://crowdin.com/messages/create/13177432/240376)**, pero ten en cuenta que necesitarás respaldar tu solicitud con contribuciones de localización anteriores que podamos verificar (por ejemplo, trabajando con la localización de ASF en Crowdin, o con cualquier otro proyecto). También es posible que permitamos que usuarios más avanzados elijan el proofreading inicial, si los conocemos personalmente y son capaces de cooperar con el resto de la comunidad para localizar mejor ASF en ese idioma.

Las reglas generales aplican para el proofreading - no te apresures, trabaja como administrador de proyecto, resuelve problemas, asegúrate de que estás haciendo las cosas mejor y no peor.

---

### Problemas

Si tienes un problema con una traducción en particular, por ejemplo, si no sabes cómo traducirla, la traducción aprobada es incorrecta, necesitas contexto más específico, y demás, por favor, publica un comentario en la cadena específica, y marca la casilla de problema [X].

**Por favor, evita usar la marca de problema si no necesitas una explicación técnica/de desarrollo o la acción del administrador**. Eres libre de usar los comentarios para discutir la traducción de una cadena determinada, pero la marca de problema solo debe ser usada cuando necesites una mayor explicación técnica o una corrección del administrador, y normalmente involucrará a alguien que no habla el idioma al que estás traduciendo, así que por favor, apégate al inglés cuando escribas un comentario de problema (para que podamos entender cuál es el problema).

Actualmente hay 4 tipos de problemas soportados:
- Pregunta general - para todo aquello que no encaje en ninguno de los siguientes problemas. En general, este tipo **debe ser evitado**, si tu problema no encaja, probablemente **no** es un problema de traducción. Sin embargo, esta opción está disponible para todos los demás casos.
- La traducción actual es incorrecta - este debe ser usado **solo** si la traducción ya fue preaprobada por un proofreader, y crees que es incorrecta, por ejemplo, si tiene un error tipográfico o tienes una sugerencia válida de cómo mejorarla. Este tipo nunca debe utilizarse en traducciones apoyadas por la comunidad (votación), ya que en este caso debes contactar con el usuario de dicha traducción y pedirle que la corrija, o simplemente vota por una traducción mejor, como se indica en la sección de revisión. Eliminaremos la aprobación de la traducción y notificaremos al proofreader correspondiente a cargo del idioma para que tome en cuenta tu comentario y verifique de nuevo.
- Falta de información contextual - este es el que debes usar si no estás seguro de qué parte de ASF estás traduciendo, cuál es el contexto de una cadena dada, o su propósito. Este tipo debe ser usado solo para el desarrollo de ASF, significa que necesitas asistencia técnica ya que no estás seguro de cómo debes traducir una determinada cadena.
- Error en la cadena original - este solo debe ser usado si crees que la cadena original (inglés) es incorrecta. Muy raro, pero no todos hablamos inglés nativamente, así que siéntete libre de usarlo si tienes una idea general de cómo podría mejorarse. Alternativamente, ya que esto se relaciona estrictamente con el desarrollo, puedes usar **[GitHub issues](https://github.com/JustArchiNET/ArchiSteamFarm/issues/new/choose)** para ese propósito, si lo deseas.

---

### Progreso de la traducción

Cada idioma tiene dos estados de completación - traducción, y proofreading.

El idioma se considera **traducido** cuando su progreso de traducción alcanza el 100%. En este punto cada cadena localizable usada por ASF tiene un significado adecuado, lo cual es genial. Sin embargo, eso no significa que no haya lugar para mejorar - la votación de la comunidad está habilitada todo el tiempo y aún puedes sugerir una mejor traducción para las partes ya traducidas, así como votar por las existentes. Por favor, ten en cuenta que los idiomas traducidos por completo pueden caer por debajo del 100% cuando cambiamos las cadenas existentes o añadimos nuevas durante el desarrollo. Puedes configurar las notificaciones de Crowdin si quieres recibir un correo electrónico cuando esto suceda.

Algunos idiomas seleccionados pueden tener proofreaders que validen las traducciones y aprueben las versiones finales. Este es el paso final después de la traducción y permite mejorar aún más la localización.

ASF incluirá un idioma determinado **tan pronto como sea posible**, esto significa que no necesita estar aprobado o traducido al 100%. Las cadenas que serán usadas siempre son las más populares en términos de votos, a menos que el proofreader elegido decida lo contrario (rara vez). Por lo tanto, puedes ver tus esfuerzos incluidos en la próxima versión de ASF - nuestros sistemas de automatización aplican las traducciones de Crowdin al repositorio de ASF diariamente.

---

## Idiomas faltantes

Por defecto el proyecto de ASF tiene la traducción abierta solo para los 30 idiomas más hablados en el mundo. Si quieres añadir otro (o el dialecto local de alguno ya disponible), por favor, **[háznoslo saber](https://crowdin.com/messages/create/13177432/240376)** y lo añadiremos tan pronto como sea posible. No queremos abrir varios cientos de idiomas si nadie va a traducirlos, por eso lo limitamos a un número justo. Por favor, no dudes en contactarnos si quieres traducir un idioma no listado, es muy fácil para nosotros añadir otro. Solo asegúrate de tener la voluntad y determinación para traducir ASF a tu idioma, antes de contactar con nosotros.

Para una lista completa de todos los idiomas disponibles a los que ASF puede ser traducido, haz **[clic aquí](https://developer.crowdin.com/language-codes)**.

---

## Pluralización

Cada idioma tiene sus propias reglas en lo que se refiere a la pluralización. Esas reglas se pueden encontrar en **[CLDR](https://unicode-org.github.io/cldr-staging/charts/latest/supplemental/language_plural_rules.html)** donde se especifica su número y condiciones exactas del idioma.

Hacemos todo lo posible para ofrecerte una localización flexible, y siempre que sea posible, esto también incluirá las reglas del plural. Por ejemplo, traduciremos la siguiente cadena al polaco:

> Released {PLURAL:n|{n} month|{n} months} ago

La palabra clave `PLURAL` aquí es tratada de forma especial ya que permite incluir todas las formas del plural que acepte tu idioma. Si echas un vistazo a CLDR, verás que en inglés solo hay 2 formas cardinales - "one" y "other". Y como puedes ver arriba, tenemos ambos definidos - `{n} month` y `{n} months`.

Sin embargo, el idioma polaco en realidad incluye 4 formas - "one", "few", "many" y "other". Esto significa que debemos definir todas ellas para su completación. Nuestras herramientas de localización ya son lo bastante inteligentes para elegir la forma correcta del plural basado en las reglas del idioma, por lo tanto solo tienes que definir todas en la traducción:

> Wydany {PLURAL:n|{n} miesiąc|{n} miesiące|{n} miesięcy|{n} miesiąca} temu

De esta manera hemos definido las 4 formas del plural para el idioma polaco, y ya que nuestra biblioteca de localización ya conoce las reglas exactas, usará la forma correcta para el número `{n}` proporcionado.

No es obligatorio definir todas las formas de plural de tu idioma. Si falta alguna, nuestra biblioteca de localización usará en su lugar la última forma definida. Es buena idea definir todas las formas del plural usadas por tu idioma, pero en algunos casos las formas de plural restantes podrían ser iguales a la última, en cuyo caso no es necesario repetirlas. En nuestro ejemplo anterior era obligatorio, ya que en polaco la forma "other" para meses es "miesiąca", y no "miesięcy" como en "many".

---

## Wiki

Nuestra plataforma crowdin también te permite localizar la propia wiki. Esta es una herramienta muy potente, ya que permite crear una documentación completa de ASF en tu idioma nativo, resolviendo eficazmente hasta el último problema en lo que respecta a la localización de ASF. Junto con la traducción del programa y todas sus partes, esto hace que la localización sea completa.

La wiki es un poco especial en este sentido, ya que es una ayuda en línea donde no necesitas apegarte demasiado a la frase original. Esto significa que quieres ser tan natural con tu idioma como sea posible, y ofrecer significado y ayuda originales - no necesariamente apegándote a la cadena original, a las palabras usadas y a la puntuación real. No tengas miedo de reescribir la cadena en algo mucho más natural para tu idioma, siempre que mantengas el sentido general y la ayuda incluida en la frase.

---

### Enlaces globales

Nuestra plataforma Crowdin también permite adaptar el texto original para que dirija a nuevas ubicaciones (localizadas).

ASF incluye enlaces en casi todas las páginas para una navegación más fácil, así como la barra lateral del lado derecho. El hecho increíble es que puedes editar todo eso, "arreglando" enlaces para dirigir a páginas localizadas en tu idioma. Requiere ser un poco más cuidadoso al hacerlo, pero es posible.

Por ejemplo, la **[página de inicio](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Home)** de ASF incluye un texto como:

> If you're a new user, we recommend starting with **[setting up](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up)** guide.

Que originalmente está escrito como:

```markdown
If you're a new user, we recommend starting with **[setting up](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up)** guide.
```

En Crowdin, lo primero que debes hacer es ir a los ajustes de editor y asegurarte de que las etiquetas HTML estén configuradas en "Mostrar". Esto es muy importante si decides localizar la wiki.

---

![Crowdin](https://i.imgur.com/YqAxiZ4.png)

---

Ahora, durante la traducción en Crowdin, dependiendo del formato, verás los enlaces de ASF en el texto ya sea como:

* Cadena para traducir junto con etiquetas HTML (la mayoría de las cadenas, donde solo una parte de la frase es un enlace)
* Cadena para traducir, con un enlace incluido en `Hidden texts` -> `Link addresses` (raras, donde la cadena completa es un enlace, más común en la barra lateral - desafortunadamente, esas requieren acceso de proofreader para traducirlas)

En nuestro ejemplo anterior, es el primer caso (ya que solo "setting up" es un enlace), así que en Crowdin lo veremos como:

---

![Crowdin 2](https://i.imgur.com/Li5RzS3.png)

---

Independientemente del caso, primero debes copiar la cadena original y traducirla como de costumbre, dejando intacto el HTML (si está presente). Este sería un ejemplo de traducción para el idioma polaco:

---

![Crowdin 3](https://i.imgur.com/NpKwfka.png)

---

Ahora, si el enlace es uno genérico que dirige fuera de la wiki (por ejemplo, a la última versión de ASF), puedes dejarlo como está ya que no quieres editar eso. Puedes guardarlo y seguir adelante.

Sin embargo, si el enlace **sí** dirige hacia la propia wiki, como el de arriba, puedes corregirlo para que dirija a una nueva ubicación (localizada). Esto se hace añadiendo cuidadosamente `-locale` a la URL destino en la etiqueta `<a>`, como a continuación:

---

![Crowdin 4](https://i.imgur.com/TL8uwmb.png)

---

Ten mucho cuidado con esto, y asegúrate de que tu URL realmente existe, ya que si cometes un error, ese enlace dejará de funcionar. Si lo haces bien, ahora tendrás una traducción totalmente funcional con un enlace dirigiendo a una página traducida (en nuestro caso `Setting-up-pl-PL`).

Llevar a cabo los pasos anteriores traducirá correctamente nuestro HTML de nuevo a markdown:

```markdown
Jeśli jesteś nowym użytkownikiem, zalecamy rozpoczęcie od korzystania z **[przewodnika po konfiguracji](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up-pl-PL)**.
```

Y finalmente al texto en la wiki:

> Jeśli jesteś nowym użytkownikiem, zalecamy rozpoczęcie od korzystania z **[przewodnika po konfiguracji](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up-pl-PL)**.

Cuando no hay HTML presente (segundo caso), es incluso más fácil ya que puedes simplemente ir a `Hidden texts` -> `Link addresses`.

---

![Crowdin 5](https://i.imgur.com/ZmgavCM.png)

---

Desde ahí puedes corregir fácilmente el enlace para que dirija a una nueva ubicación, sin siquiera molestarte con HTML:

---

![Crowdin 6](https://i.imgur.com/maG7kSm.png)

---

### Enlaces locales

A través de la wiki también encontrarás enlaces locales que dirigen a una sección particular del documento. Esos enlaces incluyen el carácter `#`, indicando al navegador web que debe moverse hacia esa sección del documento.

Esos son casos especiales, ya que esos enlaces están basados en los nombres de las secciones del documento actual. Mientras que para las URL tenemos la convención general de añadir `-locale` a la URL, y funciona en todas partes, los nombres de sección serán traducidos por ti y otras personas, por lo que necesitas asegurarte que dirijan a la ubicación correcta.

Por ejemplo, puedes encontrar el enlace `#introduction` en nuestra sección de **[configuración](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#introduction)**:

---

![Crowdin 7](https://i.imgur.com/EEHSPtK.png)

---

Como vamos a traducir la palabra "Introduction" a "Wprowadzenie" para el idioma polaco, necesitaremos corregir este enlace ya que dejará de funcionar el momento en que hagamos esto.

---

![Crowdin 8](https://i.imgur.com/JMJegO7.png)

---

De esta manera nuestro enlace local seguirá funcionando, ya que ahora dirigirá al nombre de la sección que estamos usando. Puedes corregir enlaces dentro de etiquetas HTML de la misma forma.

---

### Bloques de código

Ten mucho cuidado cuando traduzcas frases que contengan los bloques `<code></code>`. Un bloque de código indica nombres o términos fijos del código de ASF que no deben ser traducidos. Por ejemplo:

> This is especially useful if you have a lot of keys to redeem and you're guaranteed to hit <code>RateLimited</code> status before you're done with your entire batch.

Como puedes ver, la palabra `RateLimited` está dentro de un bloque de código e indica un código de estado interno de ASF que no debe ser traducido. De la misma manera, no deberías traducir otros bloques de código, tal como nombres de propiedades de configuración (por ejemplo, `TradingPreferences`), miembros de enumeración (por ejemplo, las opciones `Stable` y `Experimental` de `UpdateChannel`) y demás.

Sin embargo, solo porque esas palabras no deban traducirse, no significa que no puedas añadir la traducción adecuada junto a ellas, por ejemplo entre corchetes.

> Ta funkcja jest wyjątkowo użyteczna w przypadku aktywacji dużej ilości kluczy i gwarancji napotkania statusu <code>RateLimited</code> (zbyt częstej aktywacji) przed ukończeniem całej partii.

Como puedes ver arriba, hemos añadido "zbyt częstej aktywacji", literalmente "activación muy frecuente" junto a `RateLimited` para traducir ese estado de manera amigable, mientras al mismo tiempo mantenemos el significado original que los usuarios pueden ver durante el uso del programa. De la misma manera, puedes traducir/explicar otros casos similares de varias palabras y frases.

Si crees que algo inapropiado está incluido en un bloque de código, o que hay un texto que no está en un bloque de código pero debería estarlo, siéntete libre de preguntar en nuestro Crowdin creando el reporte de **[problema](#problemas)** correspondiente. Esto también sirve como un ejemplo práctico de cómo usar un enlace local.

---

## Salón de la Fama

Nos gustaría mostrar nuestra eterna gratitud a las personas que han dedicado una cantidad significativa de su tiempo y voluntad para mejorar la localización de ASF. Su esfuerzo es increíble, y puedes disfrutar de traducciones completas, incluyendo la wiki, principalmente gracias a ellos. Como muestra de agradecimiento, a todas las personas mencionadas aquí se les ofrece acceso gratuito a la función **[`MatchActively`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin-es-ES#matchactively)** previa **[solicitud](https://crowdin.com/messages/create/13177432/240376)**.

| Colaborador                                                | Idiomas         |
| ---------------------------------------------------------- | --------------- |
| **[Astaroth](https://crowdin.com/profile/astaroth2012)**   | LOLCAT, Español |
| **[Dead_Sam](https://crowdin.com/profile/Dead_Sam)**       | Portugués (BR)  |
| **[deluxghost](https://crowdin.com/profile/deluxghost)**   | Chino (CN)      |
| **[DragonTaki](https://crowdin.com/profile/dragontaki)**   | Chino (TW)      |
| **[LittleFreak](https://crowdin.com/profile/littlefreak)** | Alemán          |
| **[Ryzhehvost](https://crowdin.com/profile/Ryzhehvost)**   | Ruso, Ucraniano |
| **[MrBurrBurr](https://crowdin.com/profile/MrBurrBurr)**   | LOLCAT, Alemán  |
| **[XinxingChen](https://crowdin.com/profile/XinxingChen)** | Chino (HK)      |

¡Gracias a todos por mejorar la calidad de la localización de ASF!