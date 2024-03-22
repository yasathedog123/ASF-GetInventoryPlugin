# Low-memory setup

This is exact opposite of **[high-performance setup](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/High-performance-setup)** and typically you want to follow those tips if you want to decrease ASF's memory usage, for cost of lowering overall performance.

---

ASF is extremely lightweight on resources by definition, depending on your usage even 128 MB VPS with Linux is capable of running it, although going that low is not recommended and can lead to various issues. While being light, ASF is not afraid of asking OS for more memory, if such memory is needed for ASF to operate with optimal speed.

ASF as an application tries to be as much optimized and efficient as possible, which also takes in mind resources being used during execution. When it comes to memory, ASF prefers performance over memory consumption, which can result in temporary memory "spikes", that can be noticed e.g. with accounts having 3+ badge pages, as ASF will fetch and parse first page, read from it total number of pages, then launch fetch task for every extra page, which results in concurrent fetching and parsing of remaining pages. That "extra" memory usage (compared to bare minimum for operation) can dramatically speed up execution and overall performance, for the cost of increased memory usage that is needed to do all of those things in parallel. Similar thing is happening to all other general ASF tasks that can be run in parallel, e.g. with parsing active trade offers, ASF can parse all of them at once, as they're all independent of each other. On top of that, ASF (C# runtime) will **not** return unused memory back to OS immediately afterwards, which you can quickly notice in form of ASF process only taking more and more memory, but (almost) never giving that memory back to the OS. Some people may already find it questionable, maybe even suspect a memory leak, but don't worry, all of this is to be expected.

ASF is extremely well optimized, and makes use of available resources as much as possible. High memory usage of ASF doesn't mean that ASF actively **uses** that memory and **needs it**. Very often ASF will keep allocated memory as "room" for future actions, because we can drastically improve performance if we don't need to ask OS for every memory chunk that we're about to use. The runtime should automatically release unused ASF memory back to OS when OS will **truly** need it. **[Unused memory is wasted memory](https://www.howtogeek.com/128130/htg-explains-why-its-good-that-your-computers-ram-is-full)**. You run into issues when the memory you **need** is higher than the memory that is available for you, not when ASF keeps some extra allocated with purpose of speeding up functions that will execute in a moment. You run into problems when your Linux kernel is killing ASF process due to OOM (out of memory), not when you see ASF process as top memory consumer in `htop`.

**[Garbage collection](https://en.wikipedia.org/wiki/Garbage_collection_(computer_science))** process used in ASF is a very complex mechanism, smart enough to take into account not only ASF itself, but also your OS and other processes. When you have a lot of free memory, ASF will ask for whatever is needed to improve the performance. This can be even as much as 1 GB (with server GC). When your OS memory is close to being full, ASF will automatically release some of it back to the OS to help things settle down, which can result in overall ASF memory usage as low as 50 MB. The difference between 50 MB and 1 GB is huge, but so is the difference between small 512 MB VPS and huge dedicated server with 32 GB. If ASF can guarantee that this memory will come useful, and at the same time nothing else requires it right now, it'll prefer to keep it and automatically optimize itself based on routines that were executed in the past. The GC used in ASF is self-tuning and will achieve better results the longer the process is running.

This is also why ASF process memory varies from setup to setup, as ASF will do its best to use available resources in **as efficient way as possible**, and not in a fixed way like it was done during Windows XP times. The actual (real) memory usage that ASF is using can be verified with `stats` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**, and is usually around 4 MB for just a few bots, up to 30 MB if you use stuff like **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)** and other advanced features. Keep in mind that memory returned by `stats` command also includes free memory that hasn't been reclaimed by garbage collector yet. Everything else is shared runtime memory (around 40-50 MB) and room for execution (vary). This is also why the same ASF can use as little as 50 MB in low-memory VPS environment, while using even up to 1 GB on your desktop. ASF is actively adapting to your environment and will try to find optimal balance in order to neither put your OS under pressure, nor limit its own performance when you have a lot of unused memory that could be put in use.

---

Of course, there are a lot of ways how you can help point ASF at the right direction in terms of the memory you expect to use. In general if you don't need to do it, it's best to let garbage collector work in peace and do whatever it considers is best. But this is not always possible, for example if your Linux server is also hosting several websites, MySQL database and PHP workers, then you can't really afford ASF shrinking itself when you run close to OOM, as it's usually too late and performance degradation comes sooner. This is usually when you could be interested in further tuning, and therefore reading this page.

Below suggestions are divided into a few categories, with varied difficulty.

---

## ASF setup (easy)

Below tricks **do not affect performance negatively** and can be safely applied to all setups.

- Run **[generic version](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up#generic-setup)** of ASF if possible. Generic version of ASF uses less memory since it doesn't include runtime inside, doesn't come as single file, doesn't need to unpack itself on run, and is therefore smaller and has less memory footprint. OS-specific packages are handy and convenient, but they're also bundled with everything needed to launch ASF, which is something you can take care of yourself and use generic ASF variant instead.
- Never run more than one ASF instance. ASF is meant to handle unlimited number of bots all at once, and unless you're binding every ASF instance to different interface/IP address, you should have exactly **one** ASF process, with multiple bots (if needed).
- Make use of `ShutdownOnFarmingFinished` in bot's `FarmingPreferences`. Active bot takes more resources than deactivated one. It's not a significant save, as the state of bot still needs to be kept, but you're saving some amount of resources, especially all resources related to networking, such as TCP sockets. You can always bring up other bots if needed.
- Keep your bots number low. Not `Enabled` bot instance takes less resources, as ASF doesn't bother starting it. Also keep in mind that ASF has to create a bot for each of your configs, therefore if you don't need to `start` given bot and you want to save some extra memory, you can temporarily rename `Bot.json` to e.g. `Bot.json.bak` in order to avoid creating state for your disabled bot instance in ASF. This way you won't be able to `start` it without renaming it back, but ASF also won't bother keeping state of this bot in memory, leaving room for other things (very small save, in 99.9% cases you shouldn't bother with it, just keep your bots with `Enabled` of `false`).
- Fine-tune your configs. Especially global ASF config has many variables to adjust, for example by increasing `LoginLimiterDelay` you'll bring up your bots slower, which will allow already started instance to fetch badges in the meantime, as opposed to bringing up your bots faster, which will take more resources as more bots will do major work (such as parsing badges) at the same time. The less work that has to be done at the same time - the less memory used.

Those are a few things you can keep in mind when dealing with memory usage. However, those things don't have any "crucial" matter on memory usage, because memory usage comes mostly from things ASF has to deal with, and not from internal structures used for cards farming.

The most resources-heavy functions are:
- Badge page parsing
- Inventory parsing

Which means that memory will spike the most when ASF is dealing with reading badge pages, and when it's dealing with its inventory (e.g. sending trade or working with STM). This is because ASF has to deal with really huge amount of data - the memory usage of your favourite browser launching those two pages will not be any lower than that. Sorry, that's how it works - decrease number of your badge pages, and keep number of your inventory items low, that can for sure help.

---

## Runtime tuning (advanced)

Below tricks **involve performance degradation** and should be used with caution.

The recommended way of applying those settings is through `DOTNET_` environment properties. Of course, you could also use other methods, e.g. `runtimeconfig.json`, but some settings are impossible to be set this way, and on top of that ASF will replace your custom `runtimeconfig.json` with its own on the next update, therefore we recommend environment properties that you can set easily prior to launching the process.

.NET runtime allows you to **[tweak garbage collector](https://docs.microsoft.com/dotnet/core/run-time-config/garbage-collector)** in a lot of ways, effectively fine-tuning the GC process according to your needs. We've documented below properties that are especially important in our opinion.

### [`GCHeapHardLimitPercent`](https://docs.microsoft.com/dotnet/core/run-time-config/garbage-collector#heap-limit-percent)

> Specifies the allowable GC heap usage as a percentage of the total physical memory.

The "hard" memory limit for ASF process, this setting tunes GC to use only a subset of total memory and not all of it. It may become especially useful in various server-like situations where you can dedicate a fixed percentage of your server's memory for ASF, but never more than that. Be advised that limiting memory for ASF to use will not magically make all of those required memory allocations go away, therefore setting this value too low might result in running into out of memory scenarios, where ASF process will be forced to terminate.

On the other hand, setting this value high enough is a perfect way to ensure that ASF will never use more memory than you can realistically afford, giving your machine some breathing room even under heavy load, while still allowing the program to do its job as efficiently as possible.

### [`GCConserveMemory`](https://learn.microsoft.com/dotnet/core/runtime-config/garbage-collector#conserve-memory)

> Configures the garbage collector to conserve memory at the expense of more frequent garbage collections and possibly longer pause times.

A value between 0-9 can be used. The bigger the value, the more GC will optimize memory over performance.

### [`GCHighMemPercent`](https://docs.microsoft.com/dotnet/core/run-time-config/garbage-collector#high-memory-percent)

> Specifies the amount of memory used after which GC becomes more aggressive.

This setting configures the memory threshold of your whole OS, which once passed, causes GC to become more aggressive and attempt to help the OS lower the memory load by running more intensive GC process and in result releasing more free memory back to the OS. It's a good idea to set this property to maximum amount of memory (as percentage) which you consider "critical" for your whole OS performance. Default is 90%, and usually you want to keep it in 80-97% range, as too low value will cause unnecessary aggression from the GC and performance degradation for no reason, while too high value will put unnecessary load on your OS, considering ASF could release some of its memory to help.

### **[`GCLatencyLevel`](https://github.com/dotnet/runtime/blob/a1d48d6c00b5aecc063d1a58b0d9281c611ada91/src/coreclr/gc/gcpriv.h#L445-L468)**

> Specifies the GC latency level that you want to optimize for.

This is undocumented property that turned out to work exceptionally well for ASF, by limiting size of GC generations and in result make GC purge them more frequently and more aggressively. Default (balanced) latency level is `1`, but you can use `0`, which will tune for memory usage.

### [`gcTrimCommitOnLowMemory`](https://docs.microsoft.com/dotnet/standard/garbage-collection/optimization-for-shared-web-hosting)

> When set we trim the committed space more aggressively for the ephemeral seg. This is used for running many instances of server processes where they want to keep as little memory committed as possible.

This offers little improvement, but may make GC even more aggressive when system will be low on memory, especially for ASF which makes use of threadpool tasks heavily.

---

You can enable selected properties by setting appropriate environment variables. For example, on Linux (shell):

```shell
# Don't forget to tune those if you're planning to make use of them
export DOTNET_GCHeapHardLimitPercent=0x4B # 75% as hex
export DOTNET_GCHighMemPercent=0x50 # 80% as hex

export DOTNET_GCConserveMemory=9
export DOTNET_GCLatencyLevel=0
export DOTNET_gcTrimCommitOnLowMemory=1

./ArchiSteamFarm # For OS-specific build
./ArchiSteamFarm.sh # For generic build
```

Or on Windows (powershell):

```powershell
# Don't forget to tune those if you're planning to make use of them
$Env:DOTNET_GCHeapHardLimitPercent=0x4B # 75% as hex
$Env:DOTNET_GCHighMemPercent=0x50 # 80% as hex

$Env:DOTNET_GCConserveMemory=9
$Env:DOTNET_GCLatencyLevel=0
$Env:DOTNET_gcTrimCommitOnLowMemory=1

.\ArchiSteamFarm.exe # For OS-specific build
.\ArchiSteamFarm.cmd # For generic build
```

Especially `GCLatencyLevel` will come very useful as we verified that the runtime indeed optimizes code for memory and therefore drops average memory usage significantly, even with server GC. It's one of the best tricks that you can apply if you want to significantly lower ASF memory usage while not degrading performance too much with `OptimizationMode`.

---

## ASF tuning (intermediate)

Below tricks **involve serious performance degradation** and should be used with caution.

- As a last resort, you can tune ASF for `MinMemoryUsage` through `OptimizationMode` **[global config property](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#global-config)**. Read carefully its purpose, as this is serious performance degradation for nearly no memory benefits. This is typically **the last thing you want to do**, long after you go through **[runtime tuning](#runtime-tuning-advanced)** to ensure that you're forced to do this. Unless absolutely critical for your setup, we discourage using `MinMemoryUsage`, even in memory-constrained environments.

---

## Recommended optimization

- Start from simple ASF setup tricks, use **[generic ASF variant](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up#generic-setup)** and check if perhaps you're just using your ASF in a wrong way such as starting the process several times for all of your bots, or keeping all of them active if you need just one or two to autostart.
- If it's still not enough, enable all configuration properties listed above by setting appropriate `DOTNET_` environment variables. Especially `GCLatencyLevel` offers significant runtime improvements for little cost on performance.
- If even that didn't help, as a last resort enable `MinMemoryUsage` `OptimizationMode`. This forces ASF to execute almost everything in synchronous matter, making it work much slower but also not relying on thread pool to balance things out when it comes to parallel execution.

It's physically impossible to decrease memory even further, your ASF is already heavily degraded in terms of performance and you depleted all your possibilities, both code-wise and runtime-wise. Consider adding some extra memory for ASF to use, even 128 MB would make a great difference.