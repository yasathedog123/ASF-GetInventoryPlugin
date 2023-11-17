# Yüksek performans kurulum

This is exact opposite of **[low-memory setup](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup)** and typically you want to follow those tips if you want to further increase ASF performance (in terms of CPU speed), for potential cost of increased memory usage.

---

ASF already tries to prefer performance when it comes to general balanced tuning, therefore there is not a lot you can do to further increase its performance, although you're not completely out of options either. However, keep in mind that those options are not enabled by default, which means that they're not good enough to consider them balanced for majority of usages, therefore you should decide yourself if memory increase brought by them is acceptable for you.

---

## Çalışma zaman ayarı (gelişmiş)

Below tricks **involve serious memory and startup time increase** and should therefore be used with caution.

The recommended way of applying those settings is through `DOTNET_` environment properties. Of course, you could also use other methods, e.g. `runtimeconfig.json`, but some settings are impossible to be set this way, and on top of that ASF will replace your custom `runtimeconfig.json` with its own on the next update, therefore we recommend environment properties that you can set easily prior to launching the process.

.NET runtime allows you to **[tweak garbage collector](https://docs.microsoft.com/dotnet/core/run-time-config/garbage-collector)** in a lot of ways, effectively fine-tuning the GC process according to your needs. We've documented below properties that are especially important in our opinion.

### [`gcServer`](https://docs.microsoft.com/dotnet/core/run-time-config/garbage-collector#flavors-of-garbage-collection)

> Configures whether the application uses workstation garbage collection or server garbage collection.

You can read the exact specific of the server GC at **[fundamentals of garbage collection](https://docs.microsoft.com/dotnet/standard/garbage-collection/fundamentals)**.

ASF is using workstation garbage collection by default. This is mainly because of a good balance between memory usage and performance, which is more than enough for just a few bots, as usually a single concurrent background GC thread is fast enough to handle entire memory allocated by ASF.

However, today we have a lot of CPU cores that ASF can greatly benefit from, by having a dedicated GC thread per each CPU vCore that is available. This can greatly improve the performance during heavy ASF tasks such as parsing badge pages or the inventory, since every CPU vCore can help, as opposed to just 2 (main and GC). Server GC is recommended for machines with 3 CPU vCores and more, workstation GC is automatically forced if your machine has just 1 CPU vCore, and if you have exactly 2 then you can consider trying both (results may vary).

Server GC itself does not result in a very huge memory increase by just being active, but it has much bigger generation sizes, and therefore is far more lazy when it comes to giving memory back to OS. You may find yourself in a sweet spot where server GC increases performance significantly and you'd like to keep using it, but at the same time you can't afford that huge memory increase that comes out of using it. Luckily for you, there is a "best of both worlds" setting, by using server GC with **[`GCLatencyLevel`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup#gclatencylevel)** configuration property set to `0`, which will still enable server GC, but limit generation sizes and focus more on memory. Alternatively, you might also experiment with another property, **[`GCHeapHardLimitPercent`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup#gcheaphardlimitpercent)**, or even both of them at the same time.

However, if memory is not a problem for you (as GC still takes into account your available memory and tweaks itself), it's a much better idea to not change those properties at all, achieving superior performance in result.

### **[`DOTNET_TieredPGO`](https://docs.microsoft.com/dotnet/core/run-time-config/compilation#profile-guided-optimization)**

> This setting enables dynamic or tiered profile-guided optimization (PGO) in .NET 6 and later versions.

Varsayılan olarak devre dışı. In a nutshell, this will cause JIT to spend more time analyzing ASF's code and its patterns in order to generate superior code optimized for your typical usage. If you want to learn more about this setting, visit **[performance improvements in .NET 6](https://devblogs.microsoft.com/dotnet/performance-improvements-in-net-6)**.

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
- Sunucu GC'sini etkinleştirin. Server GC can be immediately seen as being active by significant memory increase compared to workstation GC. This will spawn a GC thread for every CPU thread your machine has in order to perform GC operations in parallel with maximum speed.
- If you can't afford memory increase due to server GC, consider tweaking **[`GCLatencyLevel`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup#gclatencylevel)** and/or **[`GCHeapHardLimitPercent`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup#gcheaphardlimitpercent)** to achieve "the best of both worlds". However, if your memory can afford it, then it's better to keep it at default - server GC already tweaks itself during runtime and is smart enough to use less memory when your OS will truly need it.
- You can also consider increased optimization for longer startup time with additional tweaking through other `DOTNET_` properties explained above.

Applying recommendations above allows you to have superior ASF performance that should be blazing fast even with hundreds or thousands of enabled bots. CPU should not be a bottleneck anymore, as ASF is able to use your entire CPU power when needed, cutting required time to bare minimum. The next step would be CPU and RAM upgrades.