# 兼容性

ASF 是一个用 C# 语言编写并运行在 .NET 平台上的应用程序。 这意味着 ASF 并非直接被编译为可供 CPU 执行的&#8203;**[机器码](https://en.wikipedia.org/wiki/Machine_code)**，而是被编译为 **[CIL](https://en.wikipedia.org/wiki/Common_Intermediate_Language)**，一种需要相应的运行环境才能执行的语言。

这种方法能够带来巨大的方便。由于 CIL 是跨平台的，这使得 ASF 天然能够运行在许多可供使用的操作系统上，特别是 Windows、Linux 和 macOS 这三个系统。 ASF 不仅不需要通过模拟运行，同时所有对于系统及其相关硬件的优化也对其有效，例如 CPU SSE 指令。 基于此，ASF 在表现出卓越的性能以及优化的同时，仍然能提供完美的兼容性和可靠性。

这也意味着运行 ASF **没有特定的操作系统要求**，因为它需要的只是运行于操作系统上的**运行环境**而非操作系统本身。 只要运行环境能够正确地执行 ASF 的代码，底层系统是 Windows、Linux、macOS 还是 BSD，是运行在 Sony Playstation 4、Nintendo Wii 还是您的烤面包机上都无所谓。有供它运行的 **[.NET](https://dotnet.microsoft.com/download/dotnet)** 就有能正常运行的 **[ASF](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)**（`generic` 包）。

但是，无论您想要在哪个平台上运行 ASF，您必须确保该平台安装了 **[.NET 的依赖项](https://github.com/dotnet/core/blob/main/Documentation/prereqs.md)**。 这些都是确保运行环境功能正常的底层库，也是确保 ASF 能够第一时间工作的绝对核心。 通常情况下，部分库（甚至全部）很有可能已经安装在系统内。

---

## ASF 打包

ASF 有两种主要的打包方式——Generic 包以及 OS-specific 包（操作系统包）。 从功能上来讲，这两种包是完全一样的，都能够自动进行更新。 唯一的区别就是 **Generic** 包中不包含 **OS-specific** 包内所具有的能使 ASF 运行的环境。

---

### Generic

Generic 包是一个与平台无关的版本，所以它不包含特定于计算机的代码。 所以使用这个包需要您的操作系统中已经安装有**合适版本**的 .NET 运行时环境。 我们都知道保证依赖始终是最新的这件事是十分令人烦恼的，所以这个包主要面向那些**已经在使用** .NET，不想为了 ASF 对已有环境做单独复制的人。 Generic 包还允许您在**任何地方运行 ASF，只要您能够获得正常工作的 .NET 运行时环境**，不需要担心是否存在相应的 OS-specific 包。

对于一般用户甚至是高级用户，如果只是想要运行 ASF 而不想要深入了解 . NET 的技术细节，不推荐使用 Generic 包。 也就是说，如果您明白以上所讲的内容，那您就可以使用它，不然下面所介绍的 OS-specific 包才是最合适的。

---

### OS-specific（特定操作系统）

除了 Generic 包中包含的托管代码之外，OS-specific 包还包括指定平台的本机代码。 换句话说，OS-specific 包**内部已经包含了可用的 .NET 运行时环境**，使您可以跳过麻烦的安装过程，直接启动 ASF。 OS-specific 包，顾名思义，是针对不同操作系统的，每种操作系统都需要其特定的版本——例如 Windows 需要 PE32+ `ArchiSteamFarm.exe` 二进制文件，而 Linux 则需要 Unix ELF `ArchiSteamFarm` 二进制文件。 您可能知道，这两种类型之间是完全不兼容的。

ASF 目前提供以下几种 OS-specific 包：

- `linux-arm`，支持 32 位基于 ARM（ARMv7+）并包含 glibc 2.23 / musl 1.2.2 或更新版本的 GNU/Linux 操作系统。 此包涵盖了 Raspberry Pi 2（或者更新）这类平台，**不**支持更早的 ARM 架构，例如 Raspberry Pi 0 & 1 使用的 ARMv6，也不支持未实现所需 GNU/Linux 环境的操作系统（例如 Android）。
- `linux-arm64`，支持 64 位基于 ARM（ARMv8+）并包含 glibc 2.23 / musl 1.2.2 或更新版本的 GNU/Linux 操作系统。 此包涵盖了 Raspberry Pi 3（或者更新）这类平台，**不**支持 32 位操作系统（例如 32 位 Raspberry Pi OS），因为它们缺少所需的 64 位库，也不支持未实现所需 GNU/Linux 环境的操作系统（例如 Android）。
- `linux-x64` 支持 64 位并包含 glibc 2.23 / musl 1.2.2 或更新版本的 GNU/Linux 操作系统。
- `osx-arm64` 支持 64 位 ARM 架构（Apple silicon）的 macOS 11 或更新版本的操作系统。
- `osx-x64` 支持 64 位 macOS 10.15 或更新版本的操作系统。
- `win-arm64`，支持 64 位 ARM 架构（ARMv8+）的 Windows 10、11 或者更新版本的操作系统。
- `win-x64`，支持 64 位 Windows 10、11、Server 2012+ 或者更新版本的操作系统。

当然，即使没有适合您操作系统及架构的 OS-specific 包，您也可以手动安装适当的 .NET 运行时环境并运行 Generic ASF 包，这也是这个包存在的主要原因。 Generic ASF 包与平台无关，可在任何具有可用 .NET 运行时环境的平台上运行。 需要注意——ASF 需要的是 .NET 运行时环境，而不是特定的操作系统或架构。 例如，如果您使用的是 32 位 Windows，但 ASF 没有 `win-x86` 版本，您仍然可以安装 `win-x86` 版本的 .NET SDK，然后运行 Generic 版本的 ASF。 我们无法为所有操作系统和架构组合都生成一份可执行文件，所以我们为此画下一道分隔线。 x86 就是这条线之一，因为这种架构自 2004 年开始就过时了。

您可以访问[**发行说明**](https://github.com/dotnet/core/blob/main/release-notes/8.0/supported-os.md)查看完整的 .NET 8.0 支持的平台与操作系统列表。

---

## 运行时环境需求

如果您正在使用 OS-specific 包，那么您不必担心运行时需求，因为 ASF 总会将所需的最新运行时环境打包在一起，只要您已安装并更新 **[.NET 依赖项](https://github.com/dotnet/core/blob/main/Documentation/prereqs.md)**，就能够正常运行。 换句话说，**您不需要安装 .NET 运行时环境或 SDK**，因为 OS-specific 版本只需要本机已安装对应操作系统的依赖项，而不需要其他项目。

但如果您使用 **Generic** 包，则必须保证已安装 ASF 所需的对应平台的 .NET 运行时环境。

ASF 目前指向的构建目标是 **.NET 8.0**（`net8.0`），但在未来可能会指向更高版本。 `net8.0` 自 8.0.100 SDK（8.0.0 运行时环境）以来就受到支持，但 ASF 也许更偏向于**编译时最新版本的运行时环境**，所以您应该确保您的机器上有[**最新版 SDK**](https://dotnet.microsoft.com/download)（或至少有运行时环境）。 如果您的运行时环境版本低于编译时的最低支持版本，Generic ASF 包将会拒绝启动。

如有疑问，您可以访问我们用于编译并在 GitHub 上部署新版本的 **[CI](https://github.com/JustArchiNET/ArchiSteamFarm/actions/workflows/publish.yml?query=branch%3Amain)**。 您可以在每个构建中看到 `dotnet --info` 的输出，用于验证 .NET。