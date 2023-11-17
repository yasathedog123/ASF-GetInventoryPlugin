# Configuration à hautes performances

C’est exactement le contraire de  **[low-memory setup](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup)** et vous souhaitez généralement suivre ces conseils si vous souhaitez augmenter d'avantage les performances ASF (en termes de vitesse du processeur), pour un coût potentiel d’utilisation accrue de la mémoire.

---

ASF essaie déjà de privilégier les performances en matière de réglage équilibré général. Par conséquent, vous ne pouvez rien faire pour augmenter ses performances, même si vous n’êtes pas non plus complètement à court d’options. Cependant, gardez à l'esprit que ces options ne sont pas activées par défaut, ce qui signifie qu'elles ne sont pas suffisantes pour être considérées comme équilibrées pour la majorité des utilisations. Vous devez donc décider vous-même si l'augmentation de mémoire apportée par ses options est acceptable pour vous.

---

## Runtime tuning (avancé)

Below tricks **involve serious memory and startup time increase** and should therefore be used with caution.

The recommended way of applying those settings is through `DOTNET_` environment properties. Of course, you could also use other methods, e.g. `runtimeconfig.json`, but some settings are impossible to be set this way, and on top of that ASF will replace your custom `runtimeconfig.json` with its own on the next update, therefore we recommend environment properties that you can set easily prior to launching the process.

.NET runtime allows you to **[tweak garbage collector](https://docs.microsoft.com/dotnet/core/run-time-config/garbage-collector)** in a lot of ways, effectively fine-tuning the GC process according to your needs. We've documented below properties that are especially important in our opinion.

### [`gcServer`](https://docs.microsoft.com/dotnet/core/run-time-config/garbage-collector#flavors-of-garbage-collection)

> Configures whether the application uses workstation garbage collection or server garbage collection.

You can read the exact specific of the server GC at **[fundamentals of garbage collection](https://docs.microsoft.com/dotnet/standard/garbage-collection/fundamentals)**.

ASF utilise le garbage collection du poste de travail par défaut. Ceci est principalement dû au bon équilibre entre l'utilisation de la mémoire et les performances, ce qui est amplement suffisant pour seulement quelques robots, puisqu'un seul thread GC simultané en arrière-plan est suffisamment rapide pour gérer toute la mémoire allouée par ASF.

Cependant, nous disposons aujourd'hui de nombreux cœurs de processeur dont ASF peut grandement tirer parti, en disposant d'un thread GC dédié pour chaque vCore de processeur disponible. Cela peut considérablement améliorer les performances lors de tâches ASF lourdes telles que l'analyse des pages de badges ou de l'inventaire, car chaque processeur vCore peut aider, par opposition à 2 (principal et GC). Serveur GC est recommandé pour les machines avec 3 vCores de processeur et plus, workstation GC est automatiquement forcé si votre ordinateur ne dispose que d'un processeur vCore et si vous en avez exactement 2, vous pouvez envisager d'essayer les deux (les résultats peuvent varier).

Le serveur GC lui-même n'entraîne pas une très forte augmentation de la mémoire en étant simplement actif, mais il a des tailles de génération beaucoup plus grandes et est donc beaucoup plus paresseux lorsqu'il s'agit de restituer de la mémoire à un système d'exploitation. You may find yourself in a sweet spot where server GC increases performance significantly and you'd like to keep using it, but at the same time you can't afford that huge memory increase that comes out of using it. Luckily for you, there is a "best of both worlds" setting, by using server GC with **[`GCLatencyLevel`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup#gclatencylevel)** configuration property set to `0`, which will still enable server GC, but limit generation sizes and focus more on memory. Alternatively, you might also experiment with another property, **[`GCHeapHardLimitPercent`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup#gcheaphardlimitpercent)**, or even both of them at the same time.

However, if memory is not a problem for you (as GC still takes into account your available memory and tweaks itself), it's a much better idea to not change those properties at all, achieving superior performance in result.

### **[`DOTNET_TieredPGO`](https://docs.microsoft.com/dotnet/core/run-time-config/compilation#profile-guided-optimization)**

> This setting enables dynamic or tiered profile-guided optimization (PGO) in .NET 6 and later versions.

Disabled by default. In a nutshell, this will cause JIT to spend more time analyzing ASF's code and its patterns in order to generate superior code optimized for your typical usage. If you want to learn more about this setting, visit **[performance improvements in .NET 6](https://devblogs.microsoft.com/dotnet/performance-improvements-in-net-6)**.

### **[`DOTNET_ReadyToRun`](https://docs.microsoft.com/dotnet/core/run-time-config/compilation#readytorun)**

> Configures whether the .NET Core runtime uses pre-compiled code for images with available ReadyToRun data. Disabling this option forces the runtime to JIT-compile framework code.

Enabled by default. Disabling this in combination with enabling `DOTNET_TieredPGO` allows you to extend tiered profile-guided optimization to the whole .NET platform, and not just ASF code.

---

You can enable selected properties by setting appropriate environment variables. For example, on Linux (shell):

```shell
export DOTNET_gcServer=1

export DOTNET_TieredPGO=1
export DOTNET_ReadyToRun=0

./ArchiSteamFarm # For OS-specific build
./ArchiSteamFarm.sh # For generic build
```

Or on Windows (powershell):

```powershell
$Env:DOTNET_gcServer=1

$Env:DOTNET_TieredPGO=1
$Env:DOTNET_ReadyToRun=0

.\ArchiSteamFarm.exe # For OS-specific build
.\ArchiSteamFarm.cmd # For generic build
```

---

## Optimisation recommandée

- Assurez-vous que vous utilisez la valeur par défaut `OptimizationMode`, qui correspond à `MaxPerformance`. Il s'agit de loin du paramètre le plus important, car l'utilisation de la valeur `MinMemoryUsage` a des effets considérables sur les performances.
- Enable server GC. Server GC can be immediately seen as being active by significant memory increase compared to workstation GC. This will spawn a GC thread for every CPU thread your machine has in order to perform GC operations in parallel with maximum speed.
- If you can't afford memory increase due to server GC, consider tweaking **[`GCLatencyLevel`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup#gclatencylevel)** and/or **[`GCHeapHardLimitPercent`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup#gcheaphardlimitpercent)** to achieve "the best of both worlds". Toutefois, si votre mémoire le permet, il est préférable de la conserver par défaut. Le serveur GC se peaufine déjà pendant l'exécution et est suffisamment intelligent pour utiliser moins de mémoire lorsque votre système d'exploitation en a réellement besoin.
- You can also consider increased optimization for longer startup time with additional tweaking through other `DOTNET_` properties explained above.

Applying recommendations above allows you to have superior ASF performance that should be blazing fast even with hundreds or thousands of enabled bots. Le processeur ne devrait plus être un goulet d'étranglement, car ASF est en mesure d'utiliser toute la puissance de son processeur en cas de besoin, réduisant ainsi le temps requis au strict minimum. The next step would be CPU and RAM upgrades.