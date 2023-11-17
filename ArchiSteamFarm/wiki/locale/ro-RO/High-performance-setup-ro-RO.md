# Configurare de înaltă performanță

Acest lucru este exact opusul **[setării cu memorie mică](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup)** și de obicei doriți să urmați aceste sfaturi dacă doriți să creșteți în continuare performanța ASF (în termeni de viteză CPU), cu potențialul cost de utilizare crescută a memoriei.

---

ASF încearcă deja să prefere performanța în ceea ce privește reglarea generală echilibrată; prin urmare nu puteţi face multe pentru a-i creşte performanţa, deși aveţi anumite opţiuni care pot fi configurate. Cu toate acestea, aveți în vedere faptul că aceste opțiuni nu sunt activate în mod implicit, ceea ce înseamnă că nu sunt suficient de bune pentru a le considera echilibrate pentru majoritatea utilizărilor; de aceea trebuie să vă decideţi dacă creşterea memoriei indusă de acestea este acceptabilă pentru dumneavoastră.

---

## Reglaj Runtime (avansat)

Below tricks **involve serious memory and startup time increase** and should therefore be used with caution.

The recommended way of applying those settings is through `DOTNET_` environment properties. Bineînțeles, ați putea folosi și alte metode, de ex. `runtimeconfig.json`, dar unele setări sunt imposibil de stabilit în acest fel, și pe deasupra ASF va înlocui fișierul personalizat `runtimeconfig.json` cu cel propriu la următoarea actualizare, de aceea recomandăm proprietățile de mediu pe care le puteți seta cu ușurință înainte de a lansa procesul.

.NET runtime allows you to **[tweak garbage collector](https://docs.microsoft.com/dotnet/core/run-time-config/garbage-collector)** in a lot of ways, effectively fine-tuning the GC process according to your needs. We've documented below properties that are especially important in our opinion.

### [`gcServer`](https://docs.microsoft.com/dotnet/core/run-time-config/garbage-collector#flavors-of-garbage-collection)

> Configurează dacă aplicaţia se foloseşte de colectarea gunoiului de la staţia de lucru sau de colectarea gunoiului de pe server.

Puteti citi specificul serverului GC la **[fundamentale pentru colectarea de gunoi](https://docs.microsoft.com/dotnet/standard/garbage-collection/fundamentals)**.

ASF is using workstation garbage collection by default. This is mainly because of a good balance between memory usage and performance, which is more than enough for just a few bots, as usually a single concurrent background GC thread is fast enough to handle entire memory allocated by ASF.

However, today we have a lot of CPU cores that ASF can greatly benefit from, by having a dedicated GC thread per each CPU vCore that is available. This can greatly improve the performance during heavy ASF tasks such as parsing badge pages or the inventory, since every CPU vCore can help, as opposed to just 2 (main and GC). Server GC is recommended for machines with 3 CPU vCores and more, workstation GC is automatically forced if your machine has just 1 CPU vCore, and if you have exactly 2 then you can consider trying both (results may vary).

Server GC itself does not result in a very huge memory increase by just being active, but it has much bigger generation sizes, and therefore is far more lazy when it comes to giving memory back to OS. You may find yourself in a sweet spot where server GC increases performance significantly and you'd like to keep using it, but at the same time you can't afford that huge memory increase that comes out of using it. Luckily for you, there is a "best of both worlds" setting, by using server GC with **[`GCLatencyLevel`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup#gclatencylevel)** configuration property set to `0`, which will still enable server GC, but limit generation sizes and focus more on memory. Alternatively, you might also experiment with another property, **[`GCHeapHardLimitPercent`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup#gcheaphardlimitpercent)**, or even both of them at the same time.

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

## Recommended optimization

- Ensure that you're using default value of `OptimizationMode` which is `MaxPerformance`. This is by far the most important setting, as using `MinMemoryUsage` value has dramatic effects on performance.
- Enable server GC. Server GC can be immediately seen as being active by significant memory increase compared to workstation GC. This will spawn a GC thread for every CPU thread your machine has in order to perform GC operations in parallel with maximum speed.
- If you can't afford memory increase due to server GC, consider tweaking **[`GCLatencyLevel`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup#gclatencylevel)** and/or **[`GCHeapHardLimitPercent`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup#gcheaphardlimitpercent)** to achieve "the best of both worlds". However, if your memory can afford it, then it's better to keep it at default - server GC already tweaks itself during runtime and is smart enough to use less memory when your OS will truly need it.
- You can also consider increased optimization for longer startup time with additional tweaking through other `DOTNET_` properties explained above.

Applying recommendations above allows you to have superior ASF performance that should be blazing fast even with hundreds or thousands of enabled bots. CPU should not be a bottleneck anymore, as ASF is able to use your entire CPU power when needed, cutting required time to bare minimum. The next step would be CPU and RAM upgrades.