# Autenticación de dos factores

Steam incluye un sistema de autenticación de dos factores conocido como "Escrow", el cual requiere detalles adicionales para varias actividades relacionadas con la cuenta. Puedes leer más al respecto **[aquí](https://help.steampowered.com/es/faqs/view/2E6E-A02C-5581-8904)** y **[aquí](https://help.steampowered.com/es/faqs/view/34A1-EA3F-83ED-54AB)**. Esta página considera ese sistema 2FA así como nuestra solución que se integra a él, llamada ASF 2FA.

---

# Lógica de ASF

Independientemente de si usas ASF 2FA o no, ASF incluye la lógica apropiada y es plenamente consciente de las cuentas protegidas por 2FA estándar. Te pedirá la información requerida cuando se necesite (como durante el inicio de sesión). Sin embargo, esas solicitudes pueden ser automatizadas usando ASF 2FA, que automáticamente generará los códigos requeridos, ahorrándote la molestia y habilitando funcionalidades adicionales (descritas abajo).

---

# ASF 2FA

ASF 2FA es un módulo integrado responsable de proveer características 2FA al proceso de ASF, tal como generar códigos y aceptar confirmaciones. Funciona duplicando los detalles de tu autenticador existente, para que puedas usar tu autenticador actual y ASF 2FA al mismo tiempo.

Puedes verificar si tu cuenta bot ya está usando ASF 2FA ejecutando **[comandos](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-es-ES)** `2fa`. A menos que ya hayas importado tu autenticador como ASF 2FA, todos los comandos `2fa` estándar no serán funcionales, lo que significa que tu cuenta no está usando ASF 2FA, por lo tanto tampoco está disponible para las características avanzadas de ASF que requieren que el módulo esté operativo.

---

# Recomendaciones

Hay varias maneras de hacer ASF 2FA sea operativo, aquí incluimos nuestras recomendaciones dependiendo de tu situación:

- Si ya estás usando SteamDesktopAuthenticator, WinAuth o cualquier otra aplicación de terceros que te permita extraer los detalles 2FA con facilidad, solo **[importa](#importar)** esos a ASF.
- Si estás usando la aplicación oficial y no te importa restablecer tus credenciales 2FA, la mejor manera es desactivar 2FA, luego **[crear](#creación)** nuevas credenciales 2FA usando **[autenticador conjunto](#autenticador-conjunto)**, lo que te permitirá usar la aplicación oficial y ASF 2FA. Este método no requiere hacer root o conocimientos avanzados, solo seguir las instrucciones.
- Si estás usando la aplicación oficial y no quieres restablecer tus credenciales 2FA, tus opciones son muy limitadas, normalmente necesitarías hacer root y pasos adicionales para **[importar](#importar)** esos detalles, e incluso con eso podría ser imposible.
- Si todavía no estás usando 2FA y no tienes inconveniente, puedes usar ASF 2FA con **[autenticador independiente](#autenticador-independiente)**, una aplicación de terceros **[duplicada](#importar)** en ASF (recomendación #1), o **[autenticador conjunto](#autenticador-conjunto)** con la aplicación oficial (recomendación #2).

A continuación discutimos todas las opciones posibles y los métodos que conocemos.

---

## Creación

En general, recomendamos **[duplicar](#importar)** tu autenticador existente, ya que ese es el propósito principal para el que ASF 2FA fue diseñado. Sin embargo, ASF viene con el **[plugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins-es-ES)** oficial `MobileAuthenticator` que amplía ASF 2FA permitiéndote también vincular un autenticador completamente nuevo. Esto puede ser útil en caso de que no puedas o no quieras usar otras herramientas y no te importe que ASF 2FA se convierta en tu principal (y tal vez único) autenticador.

Hay dos escenarios posibles para añadir un autenticador de dos factores con el **[plugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins-es-ES)** `MobileAuthenticator`: independiente o conjunto con la aplicación oficial de Steam. En el segundo escenario, terminarás con el mismo autenticador tanto en ASF como en la aplicación móvil; ambos generarán los mismos códigos, y ambos podrán confirmar ofertas de intercambio, transacciones del Mercado de la Comunidad de Steam, etc.

### Pasos comunes para ambos escenarios

No importa si planeas usar ASF como autenticador independiente o quieres el mismo autenticador en la aplicación oficial de Steam, necesitas seguir estos pasos de inicialización:

1. Crea un bot de ASF para la cuenta objetivo, inicia el bot e inicia sesión, lo que probablemente ya hayas hecho.
2. Opcionalmente, asigna un número de teléfono funcional a la cuenta desde **[aquí](https://store.steampowered.com/phone/manage)** para ser usado por el bot. Esto te permitirá recibir un código SMS y permite la recuperación de ser necesario, pero no es obligatorio.
3. Asegúrate de que no estás usando 2FA para tu cuenta, si lo haces, primero deshabilítalo.
4. Ejecuta el comando `2fainit [Bot]`, reemplazando `[Bot]` con el nombre de tu bot.

Suponiendo que tengas una respuesta exitosa, las siguientes dos cosas deben haber ocurrido:

- Un nuevo archivo `<Bot>.maFile.PENDING` fue generado por ASF en tu directorio `config`.
- Un SMS fue enviado por Steam al número de teléfono que asignaste para la cuenta. Si no estableciste un número de teléfono, entonces se envió un correo a la dirección de correo electrónico de la cuenta.

Los detalles del autenticador todavía no son funcionales, sin embargo, puedes revisar el archivo generado si lo deseas. Si quieres estar doblemente seguro, puedes anotar el código de revocación. Los siguientes pasos dependerán de tu escenario seleccionado.

### Autenticador independiente

Si quieres usar ASF como tu principal (o incluso único) autenticador, ahora necesitas hacer el paso de finalización:

5. Ejecuta el comando `2fafinalize [Bot] <ActivationCode>`, reemplazando `[Bot]` con el nombre de tu bot y `<ActivationCode>` con el código que recibiste por SMS o correo electrónico en el paso anterior.

### Autenticador conjunto

Si quieres tener el mismo autenticador tanto en ASF como en la aplicación oficial de Steam, ahora necesitas hacer los siguientes pasos:

5. Ignora el código por SMS o correo electrónico que recibiste después del paso previo.
6. Instala la aplicación de Steam si aún no lo has hecho, y ábrela. Dirígete a la pestaña de Steam Guard y añade un nuevo autenticador siguiente las instrucciones de la aplicación.
7. Después de añadir tu autenticador en la aplicación y que esté funcionando, regresa a ASF. Ahora necesitas decirle a ASF que la finalización está lista con uno de los dos comandos siguientes:
 - Espera hasta que se muestre el siguiente código 2fa en la aplicación de Steam, y usa el comando `2fafinalized [Bot] <2fa_code_from_app>`, reemplazando `[Bot]` con el nombre de tu bot y `<2fa_code_from_app>` con el código que veas en la aplicación de Steam. Si el código generado por ASF y el código que proporcionaste son el mismo, ASF asume que un autenticador fue añadido correctamente y procederá a importar tu autenticador recién creado.
 - Recomendamos hacer lo anterior para asegurar que las credenciales son válidas. Sin embargo, si no quieres (o no puedes) comprobar si los códigos son el mismo y sabes lo que estás haciendo, en su lugar puedes usar el comando `2fafinalizedforce [Bot]`, reemplazando `[Bot]` con el nombre de tu bot. ASF asumirá que el autenticador fue añadido correctamente y procederá a importar tu autenticador recién creado.

### Después de la finalización

Suponiendo que todo funcionó correctamente, el archivo `<Bot>.maFile.PENDING` previamente generado fue renombrado a `<Bot>.maFile.NEW`. Esto indica que tus credenciales 2FA ahora son válidas y están activas. Recomendamos crear una copia de ese archivo y guardarlo en **un lugar seguro**. Además, recomendamos que abras el archivo en el editor de tu elección y apuntes el `revocation_code` (código de revocación), que te permitirá, como su nombre lo indica, revocar el autenticador en caso de que lo pierdas.

En cuanto a detalles técnicos, el archivo `maFile` generado incluye todos los detalles recibidos del servidor de Steam durante la vinculación del autenticador, además del campo `device_id`, que podría ser necesario para otros autenticadores. El archivo es totalmente compatible con **[SDA](#steamdesktopauthenticator)** para su importación.

ASF importa automáticamente tu autenticador una vez terminado el procedimiento, por lo tanto `2fa` y otros comandos relacionados ahora deberían ser operativos para la cuenta bot a la que vinculaste el autenticador.

---

## Importar

El proceso de importación requiere que ya tengas un autenticador vinculado y funcional que sea soportado por ASF. Actualmente ASF soporta varias fuentes oficiales y no oficiales de 2FA - Android, SteamDesktopAuthenticator y WinAuth, además del método manual que te permite proporcionar las credenciales requeridas. Si aún no tienes ningún autenticador, primero necesitas elegir una de las aplicaciones disponibles y configurarlo. Si no sabes cuál elegir, recomendamos WinAuth, pero cualquiera de los anteriores funcionará bien suponiendo que sigas las instrucciones.

Las siguientes guías requieren que ya estés usando un autenticador **funcional y operativo** con una herramienta/aplicación determinada. ASF 2FA no funcionará correctamente si importas datos inválidos, por lo tanto asegúrate de que tu autenticador funciona correctamente antes de intentar importarlo. Esto incluye probar y verificar que las siguientes funciones del autenticador trabajan correctamente:
- Puedes generar códigos y esos códigos son aceptados por la red de Steam
- Puedes obtener confirmaciones, y están llegando a tu autenticador móvil
- Puedes aceptar esas confirmaciones, y son reconocidas apropiadamente por la red de Steam como confirmadas/rechazadas

Asegúrate de que tu autenticador funciona comprobando si las acciones anteriores funcionan - si no lo hacen, entonces tampoco funcionarán en ASF, solo perderás tiempo y te causarás problemas adicionales.

---

### Teléfono Android

En general, para importar el autenticador desde tu teléfono Android necesitarás acceso **[root](https://es.wikipedia.org/wiki/Android_rooting)**. Las instrucciones siguientes requieren que tengas un conocimiento decente en el mundo de "modding" de Android, definitivamente no vamos a explicar todos los pasos, visita **[XDA](https://xdaforums.com)** y otras fuentes para información adicional o ayuda con lo siguiente.

Requisitos previos:
- Instala la **[aplicación de Steam](https://play.google.com/store/apps/details?id=com.valvesoftware.android.steam.community)** oficial desde la tienda, si aún no lo has hecho.
- Asigna el autenticador a tu cuenta y comprueba que funciona - genera códigos válidos y puede aceptar confirmaciones.

Extracción (requiere rootear tu dispositivo):
- Instala **[Magisk](https://topjohnwu.github.io/Magisk/install.html)** y habilita Zygisk en los ajustes.
- Instala **[LSPosed](https://github.com/LSPosed/LSPosed?tab=readme-ov-file#install)** (para Zygisk) y comprueba que funciona.
- Instala el módulo de LSPosed **[SteamGuardExtractor](https://github.com/hax0r31337/SteamGuardExtractor?tab=readme-ov-file#usage)** y habilítalo en la configuración de SLPosed.
- Fuerza el cierre de la aplicación de Steam, luego ábrela, una **[ventana con los detalles extraídos](https://github.com/JustArchiNET/ArchiSteamFarm/assets/1069029/ab5ab71e-d664-4e49-9eb4-9f4d9ba32aa2)** debería aparecer, haz clic en copiar.

Ahora que has extraído exitosamente los detalles necesarios, deshabilita el módulo para prevenir que la ventana aparezca cada vez, luego copia el valor de `shared_secret` e `identity_secret` de la cuenta que quieres añadir a ASF 2FA, en un nuevo archivo de texto con la siguiente estructura:

```json
{
  "shared_secret": "STRING",
  "identity_secret": "STRING"
}
```

Reemplaza cada valor `STRING` con la clave privada de los detalles extraídos. Ahora, renombra el archivo a `BotName.maFile`, donde `BotName` es el nombre del bot que estás añadiendo a ASF 2FA, y colócalo en el directorio `config` de ASF si aún no lo has hecho. Después, ejecuta ASF - debería reconocer el `.maFile` e importarlo.

```text
[*] INFO: ImportAuthenticator() <1> Convirtiendo .maFile al formato ASF...
[*] INFO: ImportAuthenticator() <1> ¡Autenticador móvil importado exitosamente!
```

Eso es todo, asumiendo que has importado el archivo correcto con secretos válidos, todo debería funcionar correctamente, lo cual puedes verificar usando los comandos `2fa`. Si cometiste algún error, puedes eliminar `Bot.db` y empezar de cero si es necesario.

---

### SteamDesktopAuthenticator

Si ya tienes tu autenticador en SDA, deberías notar que el archivo `steamID.maFile` está disponible en la carpeta `maFiles`. Asegúrate de que el archivo `maFile` está en formato no cifrado, ya que ASF no puede descifrar los archivos de SDA - el contenido de un archivo no cifrado debería comenzar con el carácter `{` y terminar con `}`. Si es necesario, primero puedes eliminar el cifrado desde las opciones de SDA, y habilitarlo de nuevo cuando hayas terminado. Una vez que el archivo esté en formato no cifrado, cópialo al directorio `config` de ASF.

Ahora puedes renombrar el archivo `steamID.maFile` a `BotName.maFile` en el directorio de configuraciones de ASF, donde `BotName` es el nombre del bot al que estás añadiendo ASF 2FA. Alternativamente, puedes dejarlo como está, ASF lo seleccionará automáticamente después de iniciar sesión. Renombrar el archivo ayuda a ASF haciendo posible usar ASF 2FA antes de iniciar sesión, si no lo haces, entonces el archivo solo puede ser seleccionado después de que ASF haya iniciado sesión exitosamente (ya que ASF no sabe el `steamID` de tu cuenta antes de iniciar sesión).

Si hiciste todo correctamente, ejecuta ASF, y deberías ver:

```text
[*] INFO: ImportAuthenticator() <1> Convirtiendo .maFile al formato ASF...
[*] INFO: ImportAuthenticator() <1> ¡Autenticador móvil importado exitosamente!
```

A partir de ahora, tu ASF 2FA debería estar operativo para esta cuenta.

---

### WinAuth

Primero crea un nuevo archivo `BotName.maFile` vacío en el directorio config de ASF, donde `BotName` es el nombre del bot al que le estás añadiendo ASF 2FA. Recuerda que debe ser `BotName.maFile` y NO `BotName.maFile.txt`, Windows oculta las extensiones conocidas por defecto. Si proporcionas un nombre incorrecto, no será seleccionado por ASF.

Ahora ejecuta WinAuth normalmente. Haz clic derecho en el ícono de Steam y selecciona "Show SteamGuard and Recovery Code". Luego marca la casilla "Allow copy". Deberías notar una estructura JSON familiar al fondo de la ventana, que empieza con `{`. Copia todo el texto al archivo `BotName.maFile` que creaste en el paso anterior.

Si hiciste todo correctamente, ejecuta ASF, y deberías ver:

```text
[*] INFO: ImportAuthenticator() <1> Convirtiendo .maFile al formato ASF...
[*] INFO: ImportAuthenticator() <1> ¡Autenticador móvil importado exitosamente!
```

A partir de ahora, tu ASF 2FA debería estar operativo para esta cuenta.

---

## Listo

Desde este momento, todos los comandos `2fa` funcionarán como si fueran generados en tu dispositivo 2FA normal. Puedes usar ambos, ASF 2FA y el autenticador de tu elección (Android, SDA o WinAuth) para generar códigos y aceptar confirmaciones.

Si tienes un autenticador en tu teléfono, opcionalmente puedes eliminar SteamDesktopAuthenticator y/o WinAuth, ya que no los necesitaremos más. Sin embargo, sugiero conservarlo por si acaso, sin mencionar que es más práctico que el autenticador normal de Steam. Solo ten en cuenta que ASF 2FA **NO** es un autenticador para uso general, no incluye toda la información que un autenticador debería tener, sino solamente un subconjunto del `maFile` original. No es posible convertir ASF 2FA de vuelta al autenticador original, por lo tanto siempre asegúrate de tener un autenticador o un `maFile` en otra parte, como en WinAuth/SDA, o en tu teléfono.

---

## Preguntas frecuentes

### ¿Cómo hace uso ASF del módulo 2FA?

Si ASF 2FA está disponible, ASF lo usará para la confirmación automática de intercambios que sean enviados/aceptados por ASF. También será capaz de generar automáticamente códigos 2FA cuando sea necesario, por ejemplo para iniciar sesión. Además, tener ASF 2FA también habilita para su uso los comandos `2fa`. Eso sería todo por ahora, si no me olvidé de nada - básicamente ASF usa el módulo 2FA cuando lo necesita.

---

### ¿Qué pasa si necesito un código 2FA?

Necesitarás códigos 2FA para acceder a cuentas protegidas por 2FA, eso también incluye todas las cuentas con ASF 2FA. Debes generar los códigos en el autenticador que usaste para importar, pero también puedes generar códigos temporales a través del comando `2fa` enviado mediante el chat a un bot determinado. También puedes usar el comando `2fa <BotNames>` para generar códigos temporales para instancias de bot determinadas. Esto debería ser suficiente para que accedas a las cuentas bot a través de, por ejemplo un navegador, pero como se mencionó antes - en su lugar deberías usar tu autenticador normal (Android, SDA o WinAuth).

---

### ¿Puedo usar mi autenticador original después de importarlo como ASF 2FA?

Sí, tu autenticador original sigue siendo funcional y lo puedes usar junto con ASF 2FA. Ese es todo el punto del proceso - importamos a ASF las credenciales de tu autenticador, para que ASF pueda hacer uso de ellas y aceptar por ti las confirmaciones seleccionadas.

---

### ¿Dónde se guarda el autenticador móvil de ASF?

El autenticador móvil de ASF se guarda en el archivo `BotName.db` en tu directorio config, junto con otra información crucial relacionada con una cuenta determinada. Si quieres eliminar ASF 2FA, lee cómo a continuación.

---

### ¿Cómo puedo eliminar ASF 2FA?

Simplemente cierra ASF y elimina el archivo `BotName.db` del bot con ASF 2FA que quieras eliminar. Esta opción eliminará el 2FA asociado con ASF, pero NO desvinculará tu autenticador. Si en cambio quieres desvincular tu autenticador, además de eliminarlo de ASF (primero), debes desvincularlo en el autenticador de tu elección (Android, SDA or WinAuth), o - si por alguna razón no puedes, usa el código de revocación que recibiste durante la vinculación del autenticador, en la página de Steam. No es posible desvincular tu autenticador a través de ASF, para eso debes usar el autenticador que ya tienes.

---

### Vinculé mi autenticador en SDA/WinAuth, luego lo importé a ASF. ¿Puedo desvincularlo y vincularlo de nuevo en mi teléfono?

**No**. ASF **importa** los datos de tu autenticador para usarlo. Si desvinculas tu autenticador también causarás que ASF 2FA deje de funcionar, independientemente de si lo eliminas primero como se indica en la pregunta anterior. Si quieres usar tu autenticador tanto en tu teléfono como en ASF (opcionalmente también en SDA/WinAuth), necesitarás **importar** tu autenticador desde tu teléfono, y no crear uno nuevo en SDA/WinAuth. Solo puedes tener **un** autenticador vinculado, por eso ASF **importa** ese autenticador y sus datos para usarlo como ASF 2FA - es **el mismo** autenticador, pero existiendo en dos lugares. Si decides desvincular las credenciales de tu autenticador móvil - independientemente de la forma, ASF 2FA dejará de funcionar, ya que las credenciales del autenticador móvil previamente copiadas ya no serán válidas. Para usar ASF 2FA junto con el autenticador en tu teléfono, debes importarlo desde Android, como se describe arriba.

---

### ¿Usar ASF 2FA es mejor que WinAuth/SDA/Otro autenticador configurado para aceptar todas las confirmaciones?

**Sí**, de varias maneras. Primero y más importante - usar ASF 2FA aumenta tu seguridad **significativamente**, ya que el módulo ASF 2FA asegura que ASF solo aceptará automáticamente sus propias confirmaciones, por lo que incluso si un atacante solicita un intercambio perjudicial, ASF 2FA **no** aceptará dicho intercambio, ya que no fue generado por ASF. Además de la seguridad, usar ASF 2FA también trae beneficios de rendimiento/optimización, ya que ASF 2FA obtiene y acepta confirmaciones inmediatamente después de que son generadas, contrario a la ineficiente comprobación cada X minutos hecha, por ejemplo, por SDA o WinAuth. En resumen, no hay razón para usar un autenticador de terceros sobre ASF 2FA, si planeas automatizar las confirmaciones generadas por ASF - exactamente para eso es ASF 2FA, y usarlo no causa conflicto con que confirmes todo lo demás en el autenticador de tu elección. Recomendamos usar ASF 2FA para toda la actividad de ASF - esto es mucho más seguro que cualquier otra solución.

---

## Avanzado

Si eres un usuario avanzado, también puedes generar los archivos maFile manualmente. Esto puede ser usado en caso de que quieras importar el autenticador desde fuentes distintas a las descritas anteriormente. Debe tener una **[estructura JSON válida](https://jsonlint.com)** de:

```json
{
  "shared_secret": "STRING",
  "identity_secret": "STRING"
}
```

Los datos de un autenticador estándar tienen más campos - son ignorados completamente por ASF durante la importación, ya que no son necesarios. No tienes que eliminarlos - ASF solo requiere un JSON válido con los 2 campos obligatorios descritos arriba, e ignorará campos adicionales (si los hay). Por supuesto, necesitas reemplazar el `STRING` del ejemplo anterior con los valores válidos para tu cuenta. Cada `STRING` debería ser una representación codificada de bytes en base 64 que componen la clave privada.
