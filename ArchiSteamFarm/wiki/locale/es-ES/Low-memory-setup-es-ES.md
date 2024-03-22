# Configuración de poca memoria

Esto es exactamente lo contrario a la **[configuración de alto rendimiento](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/High-performance-setup-es-ES)** y normalmente quieres seguir estos consejos si deseas reducir el uso de memoria de ASF, a expensas de reducir el rendimiento general.

---

ASF es extremadamente ligero en recursos por definición, dependiendo de tu uso incluso un VPS de 128 MB con Linux es capaz de ejecutarlo, aunque no se recomienda usar una configuración tan baja ya que puede resultar en varios problemas. A pesar de ser ligero, ASF no dudará en solicitar más memoria al sistema operativo, si es necesario para que funcione a una velocidad óptima.

ASF como aplicación intenta ser lo más optimizada y eficiente posible, lo que también toma en cuenta los recursos usados durante su ejecución. Cuando se trata de memoria, ASF prefiere el rendimiento sobre el consumo de memoria, lo que puede resultar en "picos" de memoria temporales, que puede notarse, por ejemplo con cuentas que tienen más de 3 páginas de insignias, ya que ASF buscará y analizará la primera página, de ahí leerá el número total de páginas, luego ejecutará la tarea de búsqueda por cada página adicional, lo que resulta en la búsqueda y análisis de forma concurrente de las páginas restantes. Ese uso de memoria "adicional" (comparado con el mínimo para la operación) puede acelerar drásticamente la ejecución y el rendimiento en general, por el costo de un aumento en el uso de memoria necesaria para hacer todas esas cosas en paralelo. Algo similar ocurre en todas las demás tareas generales de ASF que pueden ejecutarse en paralelo, por ejemplo al analizar ofertas de intercambio activas, ASF puede analizar todas al mismo tiempo, al ser independientes entre sí. Además, ASF (C# runtime) **no** devolverá la memoria sin usar al sistema operativo inmediatamente, lo que puedes notar en cómo el proceso de ASF está tomando más y más memoria, pero (casi) nunca devolviéndola al sistema operativo. Algunas personas pueden encontrarlo cuestionable, incluso sospechar una fuga de memoria, pero no te preocupes, este es el comportamiento esperado.

ASF está extremadamente bien optimizado, y hace uso de los recursos disponibles tanto como sea posible. El alto uso de memoria de ASF no significa que ASF activamente **usa** esa memoria y **la necesita**. Con frecuencia ASF mantendrá la memoria asignada como "espacio" para futuras acciones, porque podemos mejorar drásticamente el rendimiento si no necesitamos solicitar al sistema operativo cada sección de memoria que queremos usar. El runtime debe liberar automáticamente la memoria no usada por ASF de vuelta al sistema operativo cuando este **realmente** la necesite. **[La memoria no usada es memoria desperdiciada](https://www.howtogeek.com/128130/htg-explains-why-its-good-that-your-computers-ram-is-full)**. Tienes problemas cuando la memoria que **necesitas** es mayor que la memoria disponible, no cuando ASF mantiene alguna adicional asignada con el propósito de acelerar las funciones que está por ejecutar. Tienes problemas cuando tu kernel Linux está deteniendo el proceso de ASF debido a OOM (out of memory), no cuando ves el proceso de ASF como el consumidor de memoria más alto en `htop`.

El proceso de **[recolección de basura](https://es.wikipedia.org/wiki/Recolector_de_basura)** usado en ASF es un mecanismo muy complejo, lo suficientemente inteligente para tener en cuenta no solo el propio ASF, sino también tu sistema operativo y otros procesos. Cuando tienes mucha memoria libre, ASF pedirá la que sea necesaria para mejorar el rendimiento. Esto puede ser hasta 1 GB (con recolección de basura de servidor). Cuando la memoria de tu sistema operativo está por llenarse, ASF automáticamente liberará parte de ella de vuelta al sistema operativo para ayudar a resolver eso, lo que puede resultar en un uso general de memoria tan bajo como 50 MB. La diferencia entre 50 MB y 1 GB es enorme, pero también lo es la diferencia entre un pequeño VPS de 512 MB y un enorme servidor dedicado con 32 GB. Si ASF puede garantizar que esta memoria será útil, y al mismo tiempo que nada más la requiere, preferirá conservarla y optimizarse automáticamente basándose en rutinas que fueron ejecutadas anteriormente. El recolector de basura usado en ASF es autoajustable y logrará mejores resultados mientras más tiempo se ejecute el proceso.

Esta también es la razón por la que la memoria del proceso de ASF varía entre configuraciones, ya que ASF hará todo lo posible por utilizar los recursos disponibles de la **manera más eficiente posible**, y no de una manera fija como se hacía durante los tiempos de Windows XP. El uso de memoria real de ASF puede ser verificado con el **[comando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-es-ES) **`stats`, y normalmente es alrededor de 4 MB para unos cuantos bots, hasta 30 MB si usas cosas como **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-es-ES)** y otras características avanzadas. Ten en cuenta que la memoria mostrada por el comando `stats` también incluye la memoria libre que todavía no ha sido reclamada por el recolector de basura. Todo lo demás es memoria compartida de runtime (alrededor de 40-50 MB) y espacio para ejecución (varía). Por eso también el mismo ASF puede usar tan solo 50 MB en un ambiente VPS de poca memoria, mientras que puede usar incluso hasta 1 GB en tu máquina de escritorio. ASF se adapta activamente a tu entorno e intentará encontrar un equilibrio óptimo para no poner tu sistema operativo bajo presión, ni limitar su propio rendimiento cuando tengas mucha memoria sin usar que se podría utilizar.

---

Por supuesto, hay muchas formas de ayudar a ASF a apuntar en la dirección correcta en términos de la memoria que esperas utilizar. En general, si no necesitas hacerlo, es mejor dejar que el recolector de basura trabaje en paz y haga lo que considere mejor. Pero esto no siempre es posible, por ejemplo si tu servidor Linux también aloja varios sitios web, base de datos MySQL y PHP workers, entonces no puedes permitirte que ASF se reduzca cuando estás cerca de quedarte sin memoria (out of memory), ya que suele ser demasiado tarde y la degradación de rendimiento se produce antes. Normalmente este caso es cuando podría interesarte hacer más ajustes, y por lo tanto leer esta página.

Las siguientes sugerencias se dividen en algunas categorías, con dificultad variada.

---

## Configuración de ASF (fácil)

Los siguientes trucos **no afectan negativamente el rendimiento** y se pueden aplicar de forma segura a todas las configuraciones.

- Ejecuta la **[versión genérica](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up-es-ES#configuraci%C3%B3n-gen%C3%A9rica)** de ASF si es posible. La versión genérica usa menos memoria, ya que no incluye runtime, no viene como un solo archivo, no necesita extraerse en la ejecución, por lo tanto es más pequeña y tiene una menor huella de memoria. Los paquetes de sistema operativo específico son prácticos y convenientes, pero también están empaquetados con todo lo necesario para ejecutar ASF, de lo cual te puedes ocupar tú mismo y en su lugar usar la variante genérica de ASF.
- Nunca ejecutes más de una instancia de ASF. ASF está diseñado para manejar un número ilimitado de bots al mismo tiempo, y a menos que vincules cada instancia de ASF a diferentes interfaces/direcciones IP, debes tener exactamente **un** proceso de ASF, con múltiples bots (si es necesario).
- Haz uso de `ShutdownOnFarmingFinished` en la propiedad del bot `FarmingPreferences`. Un bot activo toma más recursos que uno desactivado. No es un ahorro significativo, ya que el estado del bot aún necesita ser conservado, pero estás ahorrando algunos recursos, especialmente todos los recursos relacionados con la red, tal como los sockets TCP. Siempre puedes añadir otros bots si es necesario.
- Mantén una cantidad baja de bots. Una instancia de bot no `Enabled` habilitada consume menos recursos, ya que ASF no se molesta en iniciarlo. También ten en cuenta que ASF tiene que crear un bot por cada una de tus configuraciones, por lo tanto si no necesitas `start` iniciar un bot dado y quieres ahorrar algo de memoria adicional, puedes renombrar temporalmente `Bot.json` a algo como `Bot.json.bak` para evitar que se cree un estado para tu instancia de bot deshabilitada en ASF. De esta manera no podrás `start` iniciarlo sin renombrarlo de nuevo, pero ASF tampoco se molestará en mantener el estado de este bot en la memoria, dejando espacio para otras cosas (muy bajo ahorro, en el 99.9% de los casos no deberías molestarte con esto, solo mantén tus bots con la propiedad `Enabled` en `false`).
- Ajusta tus configuraciones. Especialmente las configuraciones globales de ASF tienen muchas variables para ajustar, por ejemplo aumentando `LoginLimiterDelay` los bots se iniciarán más lento, lo que permitirá que la instancia ya iniciada obtenga las insignias mientras tanto, contrario a iniciar los bots más rápido, lo que tomará más recursos ya que más bots harán un trabajo pesado (como obtener las insignias) al mismo tiempo. Cuanto menos trabajo se tenga que hacer al mismo tiempo - menos memoria se utilizará.

Estas son algunas cosas que puedes tener en cuenta cuando tengas que lidiar con el uso de memoria. Sin embargo, estas cosas no tienen ninguna importancia "crucial" en el uso de memoria, porque este proviene principalmente de cosas con las que ASF tiene que tratar, y no de estructuras internas usadas para la recolección de cromos.

Las funciones más pesadas en cuanto a recursos son:
- Analizar la página de insignias
- Analizar el inventario

Lo que significa que la memoria se elevará más cuando ASF está leyendo las páginas de insignias, y cuando está tratando con su inventario (por ejemplo, enviar un intercambio o trabajar con STM). Esto es porque ASF tiene que tratar con una gran cantidad de datos - el uso de memoria de tu navegador ejecutando esas dos páginas no será menor que eso. Lo sentimos, así es como funciona - disminuye el número de tus páginas de insignias, y mantén baja la cantidad de artículos en tu inventario, eso seguro puede ayudar.

---

## Ajuste de runtime (avanzado)

Los siguientes trucos **involucran una reducción del rendimiento** y deben ser usados con precaución.

La forma recomendada de aplicar estas configuraciones es a través de las propiedades de entorno `DOTNET_`. Por supuesto, también podrías usar otros métodos, por ejemplo, `runtimeconfig.json`, pero algunas configuraciones son imposibles de establecer de esta manera, encima de eso ASF reemplazará tu `runtimeconfig.json` personalizado en la siguiente actualización, por lo tanto recomendamos propiedades de entorno que puedas establecer fácilmente antes de ejecutar el proceso.

.NET runtime te permite **[modificar el recolector de basura](https://docs.microsoft.com/es-es/dotnet/core/run-time-config/garbage-collector)** de muchas formas, ajustando eficazmente el proceso de recolección de basura de acuerdo a tus necesidades. A continuación documentamos las propiedades que son especialmente importantes en nuestra opinión.

### [`GCHeapHardLimitPercent`](https://docs.microsoft.com/es-es/dotnet/core/run-time-config/garbage-collector#heap-limit-percent)

> Especifica el uso de montículo (heap) permitido del recolector de basura como un porcentaje de la memoria física total.

El límite "duro" de memoria para el proceso de ASF, este parámetro ajusta el recolector de basura para usar solamente un subconjunto de la memoria total y no toda. Puede resultar especialmente útil en situaciones de servidor donde puedes dedicar un porcentaje fijo de la memoria de tu servidor para ASF, pero nunca más que eso. Ten en cuenta que limitar la memoria de ASF no hará que todas las asignaciones de memoria necesarias desaparezcan mágicamente, por lo tanto establecer este valor demasiado bajo podría resultar en situaciones de falta de memoria, donde el proceso de ASF se verá forzado a finalizar.

Por otro lado, establecer este valor lo suficientemente alto es una forma perfecta de asegurar que ASF nunca usará más memoria de la que puedes permitirte realmente, dando a tu máquina un respiro incluso bajo una carga pesada, y permitiendo al programa hacer su trabajo de manera tan eficiente como sea posible.

### [`Low-memory setup`](https://learn.microsoft.com/dotnet/core/runtime-config/garbage-collector#conserve-memory)

> Configura el recolector de elementos no utilizados para conservar memoria a costa de recolecciones más frecuentes y posiblemente tiempos de pausa más largos.

Se puede usar un valor entre 0-9. Cuanto más grande sea el valor, más el recolector de elementos no utilizados optimizará la memoria sobre el rendimiento.

### [`GCHighMemPercent`](https://docs.microsoft.com/es-es/dotnet/core/run-time-config/garbage-collector#high-memory-percent)

> Especifica la cantidad de memoria usada después de lo cual el recolector de basura se vuelve más agresivo.

Esta configuración ajusta el límite de memoria de todo tu sistema operativo, causando que el recolector de basura se vuelva más agresivo e intente ayudar al sistema operativo a reducir la carga de memoria al ejecutar un proceso de recolección de basura más intensivo y como resultado libera más memoria de vuelta al sistema operativo. Es una buena idea establecer esta propiedad a la cantidad máxima de memoria (como porcentaje) que consideres "crítica" para el rendimiento de tu sistema operativo. Por defecto es 90%, y normalmente quieres mantenerlo en un rango de 80-97%, ya que un valor demasiado bajo ocasionará una agresión innecesaria del recolector de basura y la degradación del rendimiento sin motivo alguno, mientras que un valor muy alto causará una carga innecesaria a tu sistema operativo, considerando que ASF podría liberar parte de su memoria para ayudar.

### **[`GCLatencyLevel`](https://github.com/dotnet/runtime/blob/a1d48d6c00b5aecc063d1a58b0d9281c611ada91/src/coreclr/gc/gcpriv.h#L445-L468)**

> Especifica el nivel de latencia del recolector de basura para el que deseas optimizar.

Esta es una propiedad no documentada que resultó funcionar excepcionalmente bien para ASF, limitando los tamaños de generación del recolector de basura y en consecuencia hace que este los purgue más frecuente y agresivamente. El nivel de latencia predeterminado (equilibrado) es `1`, pero puedes usar `0`, lo que ajustará el uso de memoria.

### [`gcTrimCommitOnLowMemory`](https://docs.microsoft.com/es-es/dotnet/standard/garbage-collection/optimization-for-shared-web-hosting)

> Cuando se establece esta opción recortamos el espacio asignado de forma más agresiva para los segmentos de corta duración. Esto se utiliza para ejecutar muchas instancias de procesos de servidor donde es necesario mantener tan poca memoria asignada como sea posible.

Esto ofrece pocos beneficios, pero puede hacer que el recolector de basura sea más agresivo cuando el sistema tiene poca memoria, especialmente para ASF, que hace bastante uso de las tareas del grupo de subprocesos.

---

Puedes habilitar las propiedades seleccionadas configurando las variables de entorno apropiadas. Por ejemplo, en Linux (shell):

```shell
# No olvides ajustar estas configuraciones si planeas usarlas
export DOTNET_GCHeapHardLimitPercent=0x4B # 75% as hex
export DOTNET_GCHighMemPercent=0x50 # 80% as hex

export DOTNET_GCConserveMemory=9
export DOTNET_GCLatencyLevel=0
export DOTNET_gcTrimCommitOnLowMemory=1

./ArchiSteamFarm # Para compilación de sistema operativo específico
./ArchiSteamFarm.sh # Para compilación genérica
```

O en Windows (powershell):

```powershell
# No olvides ajustar estas configuraciones si planeas usarlas
$Env:DOTNET_GCHeapHardLimitPercent=0x4B # 75% as hex
$Env:DOTNET_GCHighMemPercent=0x50 # 80% as hex

$Env:DOTNET_GCConserveMemory=9
$Env:DOTNET_GCLatencyLevel=0
$Env:DOTNET_gcTrimCommitOnLowMemory=1

.\ArchiSteamFarm.exe # Para compilación de sistema operativo específico
.\ArchiSteamFarm.cmd # Para compilación genérica
```

En particular, `GCLatencyLevel` será muy útil, ya que hemos verificado que runtime realmente optimiza el código para la memoria y por lo tanto reduce significativamente el uso de memoria promedio, incluso con el recolector de basura de servidor. Es uno de los mejores trucos que puedes aplicar si quieres reducir significativamente el uso de memoria de ASF sin degradar demasiado el rendimiento con `OptimizationMode`.

---

## Ajuste de ASF (intermedio)

Los siguientes trucos **involucran una reducción importante del rendimiento** y deben ser usados con precaución.

- Como último recurso, puedes ajustar ASF para `MinMemoryUsage` a través de la **[propiedad de configuración global](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-es-ES#configuración-global)** `OptimizationMode`. Lee cuidadosamente su propósito, ya que provoca una grave degradación del rendimiento por casi ningún beneficio de memoria. Normalmente esto es **lo último que quieres hacer**, mucho después de pasar por **[ajuste de runtime](#ajuste-de-runtime-avanzado)** para asegurarte de que estás obligado a hacer esto. A menos que sea absolutamente necesario para tu configuración, no recomendamos usar `MinMemoryUsage`, incluso en entornos con memoria muy limitada.

---

## Optimización recomendada

- Empieza por trucos de configuración sencillos, usa la **[variante genérica de ASF](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up-es-ES#configuraci%C3%B3n-gen%C3%A9rica)** y comprueba si estás usando ASF de manera incorrecta, tal como iniciar el proceso varias veces para todos tus bots, o mantenerlos todos activos si solo necesitas que uno o dos inicien automáticamente.
- Si aún no es suficiente, habilita todas las propiedades de configuración mencionadas arriba estableciendo las variables de entorno `DOTNET_` apropiadas. Especialmente `GCLatencyLevel`, que ofrece significativas mejoras en el tiempo de ejecución por poco costo en rendimiento.
- Si tampoco eso ayudó, como último recurso habilita `MinMemoryUsage` en `OptimizationMode`. Esto obliga a ASF a ejecutar casi todo de forma sincrónica, haciéndolo funcionar mucho más lento pero también lo hace no depender del grupo de subprocesos para equilibrar las cosas cuando se trata de la ejecución en paralelo.

Es físicamente imposible reducir aún más la memoria, ASF ya está muy degradado en términos de rendimiento y ya agotaste todas las posibilidades, tanto en términos de código como en tiempo de ejecución. Considera añadir algo de memoria adicional para que use ASF, incluso 128 MB harían una gran diferencia.