# 兼容性

ASF is a C# application that is running on .NET platform. 這意味著 ASF 並非直接被編譯為可供 CPU 執行的​**[機器碼](https://en.wikipedia.org/wiki/Machine_code)**，而是被編譯為 **[通用中間語言](https://en.wikipedia.org/wiki/Common_Intermediate_Language)**，一種需要相應的運行環境才能執行的語言。

This approach has gigantic amount of advantages, as CIL is platform-independent, which is why ASF can run natively on many available OSes, especially Windows, Linux and macOS. There is not only no emulation needed, but also support for all platform-related and hardware-related optimizations, such as CPU SSE instructions. 因此，ASF可以實現卓越的性能和優化，同時仍然提供完美的兼容性和可靠性。

這也意味著運行 ASF **沒有特定的操作系統要求**，因為它需要的只是系統上的**運行環境**而非系統本身。 As long as that runtime is executing ASF code properly, it does not matter whether underlying OS is Windows, Linux, macOS, BSD, Sony Playstation 4, Nintendo Wii or your toaster - as long as there is **[.NET for it](https://dotnet.microsoft.com/download/dotnet)**, there is **[ASF](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** for it (in `generic` variant).

However, regardless of where you run ASF, you must ensure that your target platform has **[.NET prerequisites](https://github.com/dotnet/core/blob/main/Documentation/prereqs.md)** installed. 這些都是確保運行環境功能正常的底層庫，也是確保 ASF 能夠第一時間工作的絕對核心。 很有可能您已經安裝了其中的一些 (甚至全部)。

---

## ASF 包

ASF 有兩種主要的打包方式──Generic包以及 OS-specific 包（針對特定操作系統的包）。 從功能上來講，這兩種包是完全一樣的，都能夠自動進行更新。 唯一的區別就是 **Generic包**中不包含** OS-specific **包內附帶的能使 ASF 運行的環境。

---

### Generic

Generic 包獨立于平台，所以它不包含任何特定於電腦的代碼。 This setup requires from you to have .NET runtime already installed on your OS **in appropriate version**. We all know how troublesome it is to keep dependencies up-to-date, therefore this package is here mainly for people that **already use** .NET and don't want to duplicate their runtime solely for ASF if they can make use of what they have installed already. Generic package also allows you to run ASF **anywhere, as long as you can obtain working implementation of .NET runtime**, regardless if there exists OS-specific ASF build for it, or not.

It's not recommended to use generic flavour if you're casual or even advanced user that just wants to make ASF work and not dig into .NET technical details. 也就是說，如果你瞭解Generic包，那你可以使用它，不然下麵所介紹的 OS-specific 包才是更合適的。

---

### OS-specific

除了 Generic 包中包含的託管代碼之外，OS-specific 包還包括指定平台的本機代碼。 In other words, OS-specific package **already includes proper .NET runtime inside**, which allows you to entirely skip the whole installation mess and just launch ASF directly. OS-specific 包，顧名思義，是針對不同操作系統的，每種操作系統都需要其特定的版本——例如 Windows 需要 PE32+ `ArchiSteamFarm.exe`二進位檔案，而 Linux 則需要 Unix ELF `ArchiSteamFarm`二進位檔案。 您可能已經知道，這兩種類型之間是完全不相容的。

ASF當前可用於以下操作系統 ：

- `linux-arm` works on 32-bit ARM-based (ARMv7+) GNU/Linux OSes with glibc 2.23/musl 1.2.2 and newer. This variant covers platforms such as Raspberry Pi 2 (and newer), it will **not** work with older ARM architectures, such as ARMv6 found in Raspberry Pi 0 & 1, it will also not work with OSes that do not implement required GNU/Linux environment (such as Android).
- `linux-arm64` works on 64-bit ARM-based (ARMv8+) GNU/Linux OSes with glibc 2.23/musl 1.2.2 and newer. This variant covers platforms such as Raspberry Pi 3 (and newer), it will **not** work with 32-bit OSes that do not have required 64-bit libraries available (such as 32-bit Raspberry Pi OS), it will also not work with OSes that do not implement required GNU/Linux environment (such as Android).
- `linux-x64` works on 64-bit GNU/Linux OSes with glibc 2.23/musl 1.2.2 and newer.
- `osx-arm64` works on 64-bit ARM-based (Apple silicon) macOS OSes in version 11 and newer.
- `osx-x64` works on 64-bit macOS OSes in version 10.15 and newer.
- `win-arm64` works on 64-bit ARM-based (ARMv8+) Windows OSes in version 10, 11 and newer.
- `win-x64` works on 64-bit Windows OSes in version 10, 11, Server 2012+ and newer.

Of course, even if you don't have OS-specific package available for your OS-architecture combination, you can always install appropriate .NET runtime yourself and run generic ASF flavour, which is also the main reason why it exists in the first place. Generic ASF build is platform-agnostic and will run on any platform that has a working .NET runtime. This is important to note - ASF requires .NET runtime, not some specific OS or architecture. For example, if you're running 32-bit Windows then despite of no dedicated `win-x86` ASF version, you can still install .NET SDK in `win-x86` version and run generic ASF just fine. 我們無法為所有操作系統和架構組合都提供一份可執行档案，為此我們要在某處劃清界限。 x86 就是這條線的範例之一，因為它的體系結構至少自 2004 年開始就已過時了。

For a complete list of all supported platforms and OSes by .NET 8.0, visit **[release notes](https://github.com/dotnet/core/blob/main/release-notes/8.0/supported-os.md)**.

---

## 運行時環境需求

If you're using OS-specific package then you don't need to worry about runtime requirements, because ASF always ships with required and up-to-date runtime that will work properly as long as you have **[.NET prerequisites](https://github.com/dotnet/core/blob/main/Documentation/prereqs.md)** installed and up-to-date. In other words, **you don't need to install .NET runtime or SDK**, as OS-specific builds require only native OS dependencies (prerequisites) and nothing else.

However, if you're trying to run **generic** ASF package then you must ensure that your .NET runtime supports platform required by ASF.

ASF as a program is targeting **.NET 8.0** (`net8.0`) right now, but it may target newer platform in the future. `net8.0` is supported since 8.0.100 SDK (8.0.0 runtime), although ASF might prefer **latest runtime at the moment of compilation**, so you should ensure that you have **[latest SDK](https://dotnet.microsoft.com/download)** (or at least runtime) available for your machine. Generic ASF variant may refuse to launch if your runtime is older than the specified minimum supported one during compilation.

如有疑問，您可以訪問我們用於編譯並在 GitHub 上部署ASF版本的 **[CI](https://github.com/JustArchiNET/ArchiSteamFarm/actions/workflows/publish.yml?query=branch%3Amain)**。 You can find `dotnet --info` output in every build as part of .NET verification step.