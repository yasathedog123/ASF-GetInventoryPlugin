# Rendimiento

El objetivo principal de ASF es recolectar cromos tan eficazmente como sea posible, basado en dos tipos de información sobre la que puede operar - un pequeño conjunto de información proporcionada por el usuario que es imposible para ASF adivinar/comprobar por sí mismo, y un conjunto mayor de datos que pueden ser comprobados automáticamente por ASF.

En modo automático, ASF no te permite elegir los juegos que deben ser recolectados, tampoco te permite cambiar el algoritmo de recolección de cromos. **ASF sabe mejor que tú lo que debe hacer y qué decisiones debe tomar para recolectar lo más rápido posible**. Tu objetivo es establecer correctamente las propiedades de configuración, ya que ASF no puede adivinarlas por sí mismo, todo lo demás está cubierto.

---

Hace algún tiempo Valve cambió el algoritmo para obtener cromos. A partir de entonces, podemos categorizar las cuentas de Steam en dos categorías: aquellas **con** obtención de cromos restringida, y aquellas **sin**. La única diferencia entre esos dos tipos es el hecho de que las cuentas con obtención de cromos restringida no pueden recibir ningún cromo de un determinado juego hasta que se haya jugado por al menos `X` horas. Parece que las cuentas más antiguas que nunca solicitaron un reembolso tienen la **obtención de cromos sin restringir**, mientras que las cuentas nuevas y aquellas que solicitaron un reembolso tienen la **obtención de cromos restringida**. Sin embargo, esto solo es una teoría, y no debe ser tomado como una regla. Por eso **no hay una respuesta obvia**, y ASF confía en **ti** para decirle qué caso es apropiado para tu cuenta.

---

ASF actualmente incluye dos algoritmos de recolección:

El algoritmo **Simple** funciona mejor para cuentas que tienen la obtención de cromos sin restricción. Es el algoritmo primario utilizado por ASF. El bot encuentra juegos para recolectar, y los recolecta uno por uno hasta que todos los cromos se hayan obtenido. Esto es porque la tasa de obtención de cromos cuando se recolecta más de un juego a la vez es casi cero y totalmente ineficaz.

El algoritmo **Complejo** es uno nuevo que fue implementado para ayudar a las cuentas con restricción a maximizar sus beneficios. ASF primero usará el algoritmo **Simple** estándar en todos los juegos que superen las horas de tiempo jugado definido en `HoursUntilCardDrops`, luego, si no quedan juegos con >= `HoursUntilCardDrops` horas jugadas, recolectará simultáneamente todos los juegos (hasta un límite de `32`) con < `HoursUntilCardDrops` horas, hasta que cualquiera de ellos alcance la marca de `HoursUntilCardDrops` horas, entonces ASF continuará el ciclo desde el principio (usará el algoritmo **Simple** en ese juego, regresará a la recolección simultánea en los que tengan < `HoursUntilCardDrops` horas y así sucesivamente). Podemos usar la recolección de múltiples juegos en este caso para aumentar a un valor apropiado las horas de los juegos que necesitamos recolectar. Ten en cuenta que durante la recolección de horas, ASF **no** recolecta cromos, por lo que tampoco comprobará la obtención de cromos durante ese período (por las razones señaladas arriba).

Actualmente, ASF elige el algoritmo de recolección de cromos basado exclusivamente en la propiedad de configuración `HoursUntilCardDrops` (que es establecida por **ti**). Si `HoursUntilCardDrops` se establece a `0`, se usará el algoritmo **Simple**, de lo contrario, se usará el algoritmo **Complejo** - configurado para aumentar el tiempo de juego en todos los juegos hasta una determinada cantidad de horas antes de recolectarlos por cromos obtenibles.

---

### **No hay una respuesta obvia sobre cuál algoritmo es mejor para ti**.

Esta es una de las razones por la que no eliges el algoritmo de recolección de cromos, en cambio, le dices a ASF si la cuenta tiene la obtención de cromos restringida o no. Si la cuenta tiene la obtención de cromos sin restringir, el algoritmo **Simple** **funcionará mejor** en esa cuenta, ya que no desperdiciaremos tiempo en llevar todos los juegos a `X` horas - la tasa de obtención de cromos es cercana a 0% cuando se recolectan múltiples juegos. Por otra parte, si tu cuenta tiene restringida la obtención de cromos, el algoritmo **Complejo** será mejor para ti, ya que no tiene sentido recolectar en solitario si el juego aún no ha alcanzado `HoursUntilCardDrops` horas - por lo que primero acumularemos **tiempo de juego**, y **luego** cromos en modo individual.

No establezcas ciegamente `HoursUntilCardDrops` solo porque alguien te lo dijo - haz pruebas, compara resultados, y basado en los datos que obtengas, decide qué opción debe ser la mejor para ti. Si pones un esfuerzo mínimo en eso, te asegurarás de que ASF está trabajando con la máxima eficiencia posible para tu cuenta, que es probablemente lo que quieres, considerando que estás leyendo esta página de la wiki justo ahora. Si hubiera una solución que funcione para todos, no se daría esta opción - ASF decidiría por sí mismo.

---

### ¿Cuál es la mejor manera de averiguar si tu cuenta está restringida?

Asegúrate de tener algunos juegos para recolectar **sin tiempo de juego registrado**, de preferencia 5 o más, y ejecuta ASF con `HoursUntilCardDrops` de `0`. Sería buena idea que no juegues nada durante el período de recolección para mayor precisión en los resultados (mejor ejecutar ASF durante la noche). Deja que ASF recolecte esos 5 juegos, y después de eso comprueba el registro para los resultados.

ASF indica claramente cuando se ha obtenido un cromo para un juego determinado. Te interesa encontrar la obtención de cromos más rápida lograda por ASF. Por ejemplo, si tu cuenta no tiene restricción entonces la primera obtención de cromos debería producirse aproximadamente 30 minutos desde que iniciaste la recolección. Si notas **al menos un** juego que soltó un cromo en esos 30 minutos iniciales, este es un indicador de que tu cuenta **no** está restringida y debería usar `HoursUntilCardDrops` de `0`.

Por otra parte, si notas que **cada** juego está tomando al menos `X` cantidad de horas antes de soltar su primer cromo, entonces este es un indicador del valor al que deberías establecer `HoursUntilCardDrops`. La mayoría (si no todos) de los usuarios restringidos requieren al menos `3` horas de juego para obtener cromos, y este también es el valor por defecto para el ajuste `HoursUntilCardDrops`.

Recuerda que los juegos pueden tener diferente tasa de obtención, esto es por lo que debes probar si tu teoría es correcta con **al menos** 3 juegos, de preferencia más de 5 para asegurarte de que no estás teniendo resultados falsos por una coincidencia. La obtención de un cromo de un juego en menos de una hora es una confirmación de que tu cuenta **no está** restringida y puede usar `HoursUntilCardDrops` de `0`, pero para confirmar que tu cuenta **está** restringida, necesitas al menos varios juegos que no suelten cromos hasta que alcances una marca de tiempo fija.

Es importante notar que en el pasado `HoursUntilCardDrops` era solamente `0` o `2`, y por eso ASF tenía una sola propiedad `CardDropsRestricted` que permitía cambiar entre esos dos valores. Con cambios recientes notamos no solo que ahora la mayoría de usuarios requiere `3` horas en lugar de las anteriores `2`, sino también que `HoursUntilCardDrops` ahora es dinámico y puede tener cualquier valor dependiendo de la cuenta.

Al final, claro está, la decisión es tuya.

Y para hacerlo peor - he visto casos en los que personas cambiaban de estado restringido a no restringido y viceversa - ya sea por un bug de Steam (oh sí, tenemos muchos de esos), o por algunos ajustes a la lógica hechos por Valve. Así que incluso si confirmas que tu cuenta está restringida (o no), no creas que se mantendrá así - para cambiar de no restringido a restringido basta con solicitar un reembolso. Si sientes que el valor establecido anteriormente ya no es apropiado, siempre puedes hacer nuevas pruebas y actualizarlo en concordancia.

---

Por defecto, ASF asume que `HoursUntilCardDrops` es `3`, ya que el efecto negativo de establecerlo a `3` cuando debería ser menor es más reducido que hacerlo al contrario. Esto se debe al hecho de que en el peor de los casos desperdiciaremos `3` horas de recolección por cada `32` juegos, comparado con desperdiciar `3` horas por cada juego si `HoursUntilCardDrops` se estableciera a `0` por defecto. Sin embargo, aún deberías ajustar esta variable para que coincida con tu cuenta para máxima eficiencia, ya que esta es una suposición a ciegas basada en posibles inconvenientes y la mayoría de los usuarios (así que intentamos elegir el "menor de los males" por defecto).

En este momento los dos algoritmos mencionados son suficientes para todos los escenarios de cuenta actualmente posibles, para recolectar lo más eficazmente posible, por lo tanto no se planea añadir otros.

Es bueno notar que ASF también incluye un modo de recolección manual que puede activarse con el comando `play`. Puedes leer más al respecto en **[comandos](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-es-ES)**.

---

## Glitches de Steam

El algoritmo de obtención de cromos no siempre funciona como debería, y es completamente posible que ocurran varios glitches de Steam, tal como obtener cromos en cuentas limitadas, obtener cromos al cerrar/cambiar el juego, no obtener cromos cuando se está jugando el juego, y así por el estilo.

Esta sección es principalmente para las personas que se preguntan por qué ASF no hace **X**, tal como cambiar rápidamente entre juegos para obtener cromos más rápido.

Qué es un **glitch de Steam** - una acción específica que activa un comportamiento **indefinido**, que es **no intencional, no documentado, y considerado un error lógico**. Es **no confiable por definición**, lo que significa que no puede ser reproducido de forma confiable en un ambiente de pruebas limpio, y por lo tanto, codificado sin recurrir a hacks que se supone adivinen cuándo sucederá un glitch y cómo combatirlo / abusar de él. Normalmente es temporal hasta que los desarrolladores corrigen el error lógico, aunque algunos glitches pueden pasar desapercibidos por un largo período de tiempo.

Un buen ejemplo de qué se considera un **glitch de Steam** es esa situación no tan rara cuando se obtienen cromos al cerrar el juego, que puede ser abusado hasta cierto punto con la función de saltar juegos de idle master.

- **Comportamiento indefinido** - no puedes decir si habrá 0 o 1 cromo obtenido cuando se activa el glitch.
- **No intencional** - basado en experiencia pasada y comportamiento de la red de Steam que no resulta en el mismo comportamiento al enviar una solicitud.
- **No documentado** - está claramente documentado en el sitio web de Steam cómo se obtienen los cromos, y **en cada lugar** está claramente indicado que se obtienen **jugando**, NO cerrando juegos, obteniendo logros, cambiando entre juegos o ejecutando 32 juegos simultáneamente.
- **Considerado un error lógico** - cerrar juegos o cambiar entre ellos no debería tener ninguna relación con obtener cromos, que como se indica claramente se obtienen **acumulando tiempo de juego**.
- **No confiable por definición, no puede ser reproducido de forma confiable** - no funciona para todos, e incluso si funcionó para ti una vez, podría no funcionar una segunda vez.

Una vez que sepamos lo que es un glitch de Steam, y el hecho de que se obtengan cromos cuando se cierra el juego **es** uno, podemos pasar al segundo punto - **por definición ASF no abusa de la red de Steam de ninguna forma, y hace lo mejor posible para cumplir con los Términos de Servicio de Steam, sus protocolos y lo que es generalmente aceptado**. Hacer spam a la red de Steam con constantes solicitudes de abrir/cerrar juegos puede considerarse un **[ataque DoS](https://es.wikipedia.org/wiki/Ataque_de_denegaci%C3%B3n_de_servicio)** y **viola directamente las [Normas de Conducta Online de Steam](https://store.steampowered.com/online_conduct/?l=spanish)**.

> Como suscriptor de Steam aceptas cumplir las siguientes reglas de conducta.
> 
> No harás:
> 
> Realizar ataques a un servidor de Steam o de otro modo interrumpir el funcionamiento normal de Steam.

No importa si puedes activar el glitch con otros programas (como IM), y tampoco importa si estás de acuerdo con nosotros y consideras dicho comportamiento como un ataque DoS, o no - depende de Valve juzgarlo, pero si nosotros lo consideramos como explotación/abuso a un comportamiento no intencional a través de excesivas solicitudes a la red de Steam, puedes estar seguro que Valve tendrá una visión similar al respecto.

ASF **nunca** tomará ventaja de los exploits, abusos, hacks o cualquier otra actividad que consideremos **ilegal o no deseada** de acuerdo a los Términos de Servicio de Steam, las Normas de Conducta Online de Steam o cualquier fuente de confianza que pueda indicar que la actividad de ASF es no deseada por la red de Steam, como se indica en la sección **[pautas de contribución](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/.github/CONTRIBUTING.md)**.

Si quieres arriesgar tu cuenta de Steam por obtener cromos de unos cuantos centavos más rápido de lo normal, entonces ASF nunca ofrecerá algo así en modo automático, aunque aún tienes el **[comando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-es-ES)** `play` que puede usarse como una herramienta para hacer lo que quieras en términos de interacción con la red de Steam. No recomendamos aprovechar los glitches de Steam y explotarlos para tu propio beneficio - no solo con ASF, sino también con cualquier otra herramienta. Sin embargo, al final es tu cuenta, y tu decisión lo que quieras hacer con ella - solo ten en cuenta que te avisamos.