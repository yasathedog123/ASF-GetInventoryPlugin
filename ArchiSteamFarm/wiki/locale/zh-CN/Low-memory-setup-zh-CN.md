# 低内存方案

这篇文档与&#8203;**[高性能方案](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/High-performance-setup-zh-CN)**&#8203;完全相反，如果您愿意牺牲一些性能换取较小的内存用量，请阅读以下内容。

---

ASF 在资源上是非常轻量级的，取决于您的使用情况，即使 128 MB 的 Linux VPS 也应该足以运行它，但我们并不建议使用这么差的设备，低配可能会导致各种问题。 在轻量的同时，如果 ASF 需要更多内存以保证运行速度，它并不吝啬于向操作系统申请这些内存。

ASF 作为一个应用程序，会尝试尽可能地优化和高效，这也需要考虑到在运行过程中使用的资源。 在内存方面，ASF 更倾向于性能而不是内存占用，这可能会导致内存占用临时达到高峰，例如，在帐户有 3 个以上的徽章页面时，ASF 会先读取并解析第一页，从中获得总页面数，然后为每个页面启动额外的读取任务，这将导致并发读取并解析剩余页面。 与使用最小内存相比，增加额外的内存用量可以显著加快执行速度和整体性能，以占用内存为代价并行执行所有操作。 其他的一般 ASF 任务也有类似的并行运行的情况，例如解析可用的交易报价，ASF 可以一次解析所有报价，因为它们是互相独立的。 最重要的是，ASF（C# 运行时环境）**不会**在之后立刻将不使用的内存返还给操作系统，您可以注意到 ASF 进程会占用越来越多的内存，但（几乎）从不会将这些内存返还给操作系统。 一些人可能会认为这样有问题，甚至怀疑发生了内存泄露，但不用担心，这一切都在意料之中。

ASF 已经过非常好的优化，会尽可能利用一切可用的资源。 ASF 的高内存占用不意味着 ASF 积极**使用**这些内存并且一定**需要它们**。 通常，ASF 将会保留这些已分配的内存作为“空间”供未来操作使用，因为如果我们不在每次需要使用内存块时都向操作系统申请，就可以大幅度提高性能。 运行时环境会在操作系统**真正**需要内存时将 ASF 未使用的内存返还给操作系统。 **[空闲内存是被浪费的资源](https://www.howtogeek.com/128130/htg-explains-why-its-good-that-your-computers-ram-is-full)**。 ASF 保留一些内存用来为稍后执行的功能加速并不会使您遇到问题，您**需要**的内存超过可用内存才会。 如果您的 Linux 内核因为 OOM（内存耗尽）而结束 ASF 进程，才会出问题，但是您在 `htop` 中看到 ASF 进程占用最多的内存是正常的。

ASF 中使用的&#8203;**[垃圾收集](https://en.wikipedia.org/wiki/Garbage_collection_(computer_science))**&#8203;过程是一种非常复杂的机制，它足够智能，不仅考虑 ASF 本身，还考虑到了操作系统和其他进程。 当您有足够多可用内存时，ASF 将会申请任何能够提高性能的资源。 这甚至能够达到 1 GB（采用服务器 GC 时）。 当您的操作系统接近占满时，ASF 会自动将一些内存释放给操作系统，以帮助操作系统渡过难关，此时 ASF 的总内存占用将可以低于 50 MB。 50 MB 与 1 GB 差异巨大，但 512 MB 的 VPS 与 32 GB 大型专用服务器的差异也是巨大的。 如果 ASF 可以保证内存发挥作用，同时没有其他进程需要这些内存，ASF 更愿意保留它们，并根据之前执行的过程进行自我优化。 ASF 使用的 GC 是自适应的，运行时间越长，效果就越好。

这也是 ASF 进程的内存用量因设置而异的原因，因为 ASF 将**尽可能高效地**使用一切可使用的资源，而不是像在 Windows XP 时代那样使用固定的资源。 ASF 实际的内存用量可以通过 `stats` **[命令](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-zh-CN)**&#8203;查看。如果您机器人的数量很少，通常它只会占用大约 4 MB 内存，但如果启用了 **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-zh-CN)** 和其他额外功能，ASF 将会占用多达 30 MB 内存。 请注意，`stats` 命令返回的内存值包括 GC 尚未回收的空闲内存。 剩余的都是共享运行时内存（大约 40-50 MB）以及用于执行操作的空间（可变）。 这也是同样的 ASF 在低内存的 VPS 上只使用 50 MB，而在桌面端能够占用达 1 GB 的原因。 ASF 会主动适应您的环境，并努力寻找最佳的平衡，使其在您有大量可用内存时，既不给您的操作系统带来压力，也不会限制其自身的性能。

---

当然，有很多方法可以帮助您在内存使用方面为 ASF 指向您期望的方向。 一般来说，如果您不需要这么做，最好让垃圾收集器按照它认为最好的方式工作。 但这并不总是可行的，例如，如果您的 Linux 服务器还托管了多个网站、MySQL 数据库和 PHP Worker，那么当您的内存濒临用尽时，ASF 的自我调整就无法满足您的需求，因为这种调整通常发生得太晚，并且性能很快就会下降。 此时您通常会对进一步的调整感兴趣，可以阅读本页来了解。

下面这些建议被分为了不同的类别，其难度各不相同。

---

## ASF 设置（简单）

以下技巧**不会对性能造成负面影响**，可以在所有情况下安全选用。

- 尽可能运行 [**Generic 版本**](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up-zh-CN#安装-generic-包)的 ASF。 Generic 版本 ASF 占用内存更少，因为它不内置运行时环境，不以单文件形式提供，也就不需要在运行时自解压，因此其文件较小，内存占用也较小。 针对操作系统的包则更方便简易，但它们也打包了运行 ASF 所需的一切资源，如果您使用 Generic 版本，就可以自行管理它们。
- 永远不要运行多个 ASF 实例。 ASF 可以同时处理无限个机器人，除非您需要将每个 ASF 实例绑定到不同的网络接口或 IP 地址，否则您只需要**一个**有多个机器人的 ASF 进程。
- 善用机器人配置 `FarmingPreferences` 中的 `ShutdownOnFarmingFinished`。 启用的机器人比未启用的消耗更多资源。 尽管效果不明显，因为仍然需要保留机器人的状态，但这仍然可以节约一些资源，尤其是 TCP 套接字等网络相关的资源。 如果需要，您随时可以启用其他机器人。
- 不要有太多机器人。 未 `Enabled`（启用）的机器人实例消耗较少的资源，因为 ASF 不需要启动它。 还需要注意，ASF 会为每份配置文件创建一个机器人，因此如果您不需要 `start`（运行）指定的机器人，并且希望节省一些内存，您可以临时将 `Bot.json` 重命名为 `Bot.json.bak` 等，以防止 ASF 创建被禁用的机器人。 如果您不将其重命名为原名，就无法 `start`（运行）这个机器人，但 ASF 也不会在内存中为这个机器人保存状态，为其他数据留出空间（非常小的空间，在 99.9% 的情况下您不需要这么做，将机器人的 `Enabled` 设置为 `false` 已经足够）。
- 妥善优化配置文件。 特别是全局 ASF 配置中有很多变量可以调整，例如增加 `LoginLimiterDelay` 会减慢机器人启动的速度，留出时间给已启用的实例抓取徽章页面，如果减少这个值，就会让机器人尽快启动，当机器人很多时，它们就会同时进行解析徽章等消耗资源的任务。 同时进行的任务越少——使用的内存就越少。

这些都是您在处理内存占用问题时可以考虑的一些事情。 然而，这些事情不是影响内存的关键问题，因为内存占用主要来自于 ASF 必须处理的事情，而不是来自于挂卡机制的内部结构。

最消耗资源的功能是：
- 徽章页面解析
- 库存解析

这意味着，当 ASF 读取徽章页面以及处理库存时（例如发送交易报价或者进行 STM 相关的操作），内存用量将会最大。 这是因为此时 ASF 必须处理大量的数据——您直接用浏览器访问这两个页面消耗的内存也不会比 ASF 更低。 很抱歉，但这就是它的工作原理——减少您的徽章页面数，并且只在库存内保留少量物品，都会对此有帮助。

---

## 运行时环境调优（高级）

以下技巧**会造成性能下降**，应谨慎使用。

应用这些设置的推荐方式是设置 `DOTNET_` 环境变量。 当然，您也可以使用其他方法，例如 `runtimeconfig.json`，但这种方法无法调整某些选项，并且 ASF 还会在每次更新时替换掉您的自定义 `runtimeconfig.json`，因此我们推荐使用环境变量，这样您就可以在运行程序之前轻松设置。

.NET 运行时环境允许您以多种方式&#8203;**[调整垃圾回收](https://docs.microsoft.com/zh-cn/dotnet/core/run-time-config/garbage-collector)**，根据需要高效地优化 GC 过程。 我们在下文记录了一些在我们看来非常重要的属性。

### [`GCHeapHardLimitPercent`](https://docs.microsoft.com/zh-cn/dotnet/core/run-time-config/garbage-collector#heap-limit-percent)

> 指定允许的 GC 堆使用量占总物理内存的百分比。

对 ASF 进程设置的硬性内存限制，此选项会调整 GC 仅使用一部分而不是全部内存。 这在各种服务器环境下可能非常有用，您可以为服务器上的 ASF 分配固定大小的内存，使 ASF 无法占用更多。 需要注意的是，限制 ASF 的可用内存不会神奇地减少它实际需要的内存，因此，如果将此选项设置得过低，就可能导致内存用尽，进而强制中止 ASF 进程。

另一方面，如果您希望 ASF 不会使用超出您可接受范围的内存，让您的设备在高负载的情况下依然有喘息的空间，但仍然允许程序尽可能高效率地完成它的任务，就可以合理调高这个选项。

### [`GCConserveMemory`](https://learn.microsoft.com/dotnet/core/runtime-config/garbage-collector#conserve-memory)

> 配置垃圾回收器来节省内存，但代价是垃圾回收更频繁，并且暂停时间可能更长。

可以使用 0-9 之间的值。 值越大，GC 越会优化内存而不是性能。

### [`GCHighMemPercent`](https://docs.microsoft.com/zh-cn/dotnet/core/run-time-config/garbage-collector#high-memory-percent)

> 指定在 GC 更积极后的内存使用量。

此选项设置您整个操作系统可供使用的内存上限，设置后，GC 将会更加积极，更频繁地运行 GC 进程，借此向操作系统释放更多空闲内存，以尝试帮助操作系统降低内存负载。 推荐将此属性设置为您认为将会严重影响操作系统性能的最大内存占用（百分比形式）。 默认值为 90%，通常您会希望保持其在 80-97% 范围内，因为过低的值会造成不必要的激进 GC 并降低性能，而过高的值可能会导致操作系统负担过重，应该让 ASF 释放一些内存以缓解。

### **[`GCLatencyLevel`](https://github.com/dotnet/runtime/blob/a1d48d6c00b5aecc063d1a58b0d9281c611ada91/src/coreclr/gc/gcpriv.h#L445-L468)**

> 指定您要优化的 GC 延迟级别。

这个属性未公开，但实际上非常有效，它会限制 GC 代数的大小，使 GC 发生得更频繁。 默认的（平衡）延迟级别为 `1`，但您可以使用 `0`，这将会调整内存用量。

### [`gcTrimCommitOnLowMemory`](https://docs.microsoft.com/zh-cn/dotnet/standard/garbage-collection/optimization-for-shared-web-hosting)

> 设置此选项时，我们会更积极地为暂时段减少提交的空间。 这可用于运行多个服务器进程的实例，这些实例需要尽可能地保持较小的内存提交。

这个属性带来的改进很小，但是当系统内存不足时，它可能会使 GC 更加激进，特别是针对 ASF 这种大量利用线程池任务的程序。

---

您可以通过环境变量启用指定的 GC 选项。 例如，在 Linux 上（Shell）：

```shell
# 如要使用此功能，不要忘记调整此数值
export DOTNET_GCHeapHardLimitPercent=0x4B # 75% 的十六进制表示
export DOTNET_GCHighMemPercent=0x50 # 80% 的十六进制表示

export DOTNET_GCConserveMemory=9
export DOTNET_GCLatencyLevel=0
export DOTNET_gcTrimCommitOnLowMemory=1

./ArchiSteamFarm # 针对操作系统包
./ArchiSteamFarm.sh # 针对 Generic 包
```

或者在 Windows 上（Powershell）：

```powershell
# 如要使用此功能，不要忘记调整此数值
$Env:DOTNET_GCHeapHardLimitPercent=0x4B # 75% 的十六进制表示
$Env:DOTNET_GCHighMemPercent=0x50 # 80% 的十六进制表示

$Env:DOTNET_GCConserveMemory=9
$Env:DOTNET_GCLatencyLevel=0
$Env:DOTNET_gcTrimCommitOnLowMemory=1

.\ArchiSteamFarm.exe # 针对操作系统包
.\ArchiSteamFarm.cmd # 针对 Generic 包
```

其中 `GCLatencyLevel` 将非常有用，因为我们可以验证运行时环境确实为内存优化了代码，因此即使采用服务器 GC 也会显著降低平均内存使用量。 如果您希望显著降低 ASF 的内存用量，但不希望 `OptimizationMode` 造成严重的性能下降，那么这是您可以选择的最佳技巧之一。

---

## ASF 调优（中级）

以下技巧**会造成严重的性能下降**，应谨慎使用。

- 作为最后的手段，您可以通过修改 `OptimizationMode` **[全局配置属性](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-zh-CN#全局配置)**&#8203;调整 `MinMemoryUsage`。 请仔细阅读这个选项的作用，因为它会严重损失性能并且几乎不会减少内存的消耗。 通常，只有在您按照&#8203;**[运行时环境调优](#运行时环境调优高级)**&#8203;作出的调整仍然不能满足需求的情况下，这才是**您应该最后尝试的方式**。 除非是不得已的情况，否则我们不建议使用 `MinMemoryUsage`，即使是在内存非常受限的环境也是如此。

---

## 建议的优化

- 从简单的 ASF 配置开始、使用 **[Generic 版本 ASF](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up-zh-CN#安装-generic-包)**、检查您是否以错误的方式使用了 ASF，例如为所有的机器人启动多个进程，或者在只需要自动启动一两个机器人的情况下启动了所有机器人。
- 如果仍然不理想，通过设置合适的 `DOTNET_` 环境变量启用所有上述的配置属性。 特别是 `GCLatencyLevel` 能够在轻微影响性能的情况下显著减少内存用量。
- 如果这样仍然没有效果，作为最后的手段，您可以启用 `OptimizationMode` 的 `MinMemoryUsage` 选项。 这会强制 ASF 同步执行几乎所有操作，使其运行速度明显变慢，但在并行执行时也不再依赖于线程池来平衡。

进一步减少内存用量是不可能的，此时您的 ASF 的性能已经严重降低，并且已经耗尽了代码方面与运行时方面所有的可能性。 您应该考虑为 ASF 增加一些内存设备，即使只增加 128 MB 也有明显的差别。