# Préstamo familiar de Steam

ASF soporta el Préstamo Familiar de Steam - para entender cómo funciona ASF en este caso, primero debes leer cómo **[funciona el Préstamo Familiar de Steam](https://store.steampowered.com/promotion/familysharing)**, que está disponible en la tienda de Steam.

---

## ASF

El soporte para el Préstamo Familiar de Steam en ASF es transparente, esto significa que no introduce ninguna propiedad de configuración nueva para el bot/proceso - funciona inmediatamente como una funcionalidad integrada adicional.

ASF incluye la lógica apropiada para saber si la biblioteca está bloqueada por usuarios del préstamo familiar, por lo tanto no los "expulsará" de su sesión al ejecutar un juego. ASF actuará exactamente igual como si la cuenta principal estuviese jugando, por lo tanto si ese estado es mantenido por tu cliente de Steam, o por uno de los usuarios del préstamo familiar, ASF no intentará recolectar, en su lugar, esperará que se libere.

In addition to above, after logging in, ASF will access your **[family sharing settings](https://store.steampowered.com/account/managedevices)**, from which it'll extract up to 5 `steamIDs` allowed to use your library. A esos usuarios se les asignan permisos `FamilySharing` para usar **[comandos](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-es-ES)**, especialmente permitiéndoles usar el comando `pause~` en la cuenta bot que les está compartiendo juegos, lo que permite pausar el módulo de recolección automática de cromos para ejecutar un juego que puede ser compartido.

Connecting both functionalities described above allows your friends to `pause~` your cards farming process, start a game, play as long as they wish, and then after they're done playing, cards farming process will be automatically resumed by ASF. Por supuesto, enviar el comando `pause~` no es necesario si ASF no está recolectando nada, porque tus amigos pueden ejecutar el juego directamente, y la lógica descrita antes asegura que no serán expulsados de la sesión.

---

## Limitaciones

A la red de Steam le gusta engañar a ASF transmitiendo actualizaciones de estado falsas, lo que puede conducir a que ASF crea que está bien reanudar el proceso, y en consecuencia expulsar a tu amigo antes de tiempo. Este es exactamente el mismo problema que el ya explicado en **[esta entrada de las preguntas frecuentes](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ-es-ES#asf-est%C3%A1-expulsando-mi-sesi%C3%B3n-en-el-cliente-de-steam-mientras-estoy-jugando--esta-cuenta-tiene-iniciada-una-sesi%C3%B3n-en-otro-equipo)**. Recomendamos exactamente las mismas soluciones, principalmente otorgar a tus amigos el permiso `Operator` (o superior) y pedirles que usen los comandos `pause` y `resume`.