# Compatibilité

ASF is a C# application that is running on .NET platform. Cela signifie que ASF n’est pas compilé directement en **[code machine](https://en.wikipedia.org/wiki/Machine_code)** qui s’exécute sur votre CPU, mais en **[CIL](https://en.wikipedia.org/wiki/Common_Intermediate_Language)** qui nécessite un runtime compatible CIL pour l’exécuter.

This approach has gigantic amount of advantages, as CIL is platform-independent, which is why ASF can run natively on many available OSes, especially Windows, Linux and macOS. There is not only no emulation needed, but also support for all platform-related and hardware-related optimizations, such as CPU SSE instructions. Grâce à cela, ASF peut atteindre des performances et une optimisation supérieures, tout en offrant une compatibilité et une fiabilité parfaite.

Cela signifie également qu'ASF n'a ** aucune exigence spécifique du système d'exploitation </ 0>, car il nécessite de travailler sur ** runtime </ 0> sur ce système d'exploitation et non sur le système d'exploitation lui-même. As long as that runtime is executing ASF code properly, it does not matter whether underlying OS is Windows, Linux, macOS, BSD, Sony Playstation 4, Nintendo Wii or your toaster - as long as there is **[.NET for it](https://dotnet.microsoft.com/download/dotnet)**, there is **[ASF](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** for it (in `generic` variant).</p>

However, regardless of where you run ASF, you must ensure that your target platform has **[.NET prerequisites](https://github.com/dotnet/core/blob/main/Documentation/prereqs.md)** installed. Ce sont des bibliothèques de bas niveau requises pour une fonctionnalité d’exécution correcte et absolument essentielles au bon fonctionnement d’ASF. Très probablement, vous pouvez en avoir certains (ou même tous) déjà installés.

---

## ASF packaging

ASF est disponible en 2 versions principales: package générique et système d'exploitation spécifique. En termes de fonctionnalité, les deux packages sont exactement les mêmes, ils sont également capables de se mettre à jour automatiquement. La seule différence entre eux est de savoir si le package ASF **generic** est également fourni avec un environnement d’exécution **spécifique au système d’exploitation**.

---

### Générique 

Le paquet générique est une construction indépendante de la plate-forme qui n'inclut aucun code spécifique à la machine. This setup requires from you to have .NET runtime already installed on your OS **in appropriate version**. We all know how troublesome it is to keep dependencies up-to-date, therefore this package is here mainly for people that **already use** .NET and don't want to duplicate their runtime solely for ASF if they can make use of what they have installed already. Generic package also allows you to run ASF **anywhere, as long as you can obtain working implementation of .NET runtime**, regardless if there exists OS-specific ASF build for it, or not.

It's not recommended to use generic flavour if you're casual or even advanced user that just wants to make ASF work and not dig into .NET technical details. En d'autres termes - si vous savez ce que c'est, vous pouvez l'utiliser, sinon il est préférable d'utiliser le paquet spécifique au système d'exploitation comme expliqué ci-dessous.

#### .NET Framework package

In addition to generic package mentioned above, there is also `generic-netf` package which is built on top of .NET Framework and not .NET (Core). This package is a legacy variant that provides missing compatibility known from ASF V2 times, and can be run e.g. with **[Mono](https://www.mono-project.com)**, while .NET `generic` package can't as of today.

En général, **évitez autant que possible ce package**, car la plupart des systèmes d'exploitation et des configurations sont parfaitement (et bien mieux) pris en charge avec le package `générique` mentionné ci-dessus. In fact, this package makes sense to be used only on platforms that lack working .NET runtime, while having working Mono implementation. Examples of such platforms include `linux-x86` (32-bit i386/i686 linux), as well as `linux-armel` (ARMv6 boards found e.g. in Raspberry Pi 0 & 1), all of which do not have official working .NET runtime as of today.

As the time goes on with more platforms being supported by .NET and less compatibility between .NET Framework and .NET, `generic-netf` package will be entirely replaced with `generic` one in the future. Please refrain from using it if you can use any .NET package instead, as `generic-netf` is missing a lot of functionality and compatibility compared to .NET versions, and it'll be only less functional as the time goes on. We offer support for this package **only** on machines that can't use `generic` variant above (e.g. `linux-x86`), and only with up-to-date runtime (e.g. latest Mono).

---

### OS-spécifique

Le package spécifique au système d'exploitation, outre le code géré inclus dans le package générique, inclut également du code natif pour une plate-forme donnée. In other words, OS-specific package **already includes proper .NET runtime inside**, which allows you to entirely skip the whole installation mess and just launch ASF directly. Comme vous pouvez le deviner, le paquet spécifique à un système d’exploitation est spécifique à chaque système d’exploitation. Par exemple, Windows requiert PE32 + pour `ArchiSteamFarm.exe` alors que Linux fonctionne avec Unix ELF</code> binaire pour `ArchiSteamFarm</0>. Comme vous le savez peut-être, ces deux types ne sont pas compatibles.</p>

<p spaces-before="0">ASF est actuellement disponible dans les variantes suivantes spécifiques au système d'exploitation:</p>

<ul>
<li><code>linux-arm` works on 32-bit ARM-based (ARMv7+) GNU/Linux OSes with glibc 2.27 and newer. This variant covers platforms such as Raspberry Pi 2 (and newer), it will **not** work with older ARM architectures, such as ARMv6 found in Raspberry Pi 0 & 1, it will also not work with OSes that do not implement required GNU/Linux environment (such as Android).</li>
- `linux-arm64` works on 64-bit ARM-based (ARMv8+) GNU/Linux OSes with glibc 2.23/musl 1.2.2 and newer. This variant covers platforms such as Raspberry Pi 3 (and newer), it will **not** work with 32-bit OSes that do not have required 64-bit libraries available (such as 32-bit Raspberry Pi OS), it will also not work with OSes that do not implement required GNU/Linux environment (such as Android).
- `linux-x64` works on 64-bit GNU/Linux OSes with glibc 2.17/musl 1.2.2 and newer.
- `osx-arm64` works on 64-bit ARM-based (Apple silicon) macOS OSes in version 11 and newer.
- `osx-x64` works on 64-bit macOS OSes in version 10.15 and newer.
- `win-arm64` works on 64-bit ARM-based (ARMv8+) Windows OSes in version 10, 11 and newer.
- `win-x64` works on 64-bit Windows OSes in version 10, 11, Server 2012+ and newer.</ul>

Of course, even if you don't have OS-specific package available for your OS-architecture combination, you can always install appropriate .NET runtime yourself and run generic ASF flavour, which is also the main reason why it exists in the first place. Generic ASF build is platform-agnostic and will run on any platform that has a working .NET runtime. This is important to note - ASF requires .NET runtime, not some specific OS or architecture. For example, if you're running 32-bit Windows then despite of no dedicated `win-x86` ASF version, you can still install .NET SDK in `win-x86` version and run generic ASF just fine. Nous ne pouvons simplement pas cibler toutes les combinaisons architecture-système existantes qui sont utilisées par quelqu'un, nous devons donc tracer une ligne quelque part. x86 est un bon exemple de cette ligne car son architecture est obsolète depuis au moins 2004.

For a complete list of all supported platforms and OSes by .NET 7.0, visit **[release notes](https://github.com/dotnet/core/blob/main/release-notes/7.0/supported-os.md)**.

---

## Exigences Runtime

If you're using OS-specific package then you don't need to worry about runtime requirements, because ASF always ships with required and up-to-date runtime that will work properly as long as you have **[.NET prerequisites](https://github.com/dotnet/core/blob/main/Documentation/prereqs.md)** installed and up-to-date. In other words, **you don't need to install .NET runtime or SDK**, as OS-specific builds require only native OS dependencies (prerequisites) and nothing else.

However, if you're trying to run **generic** ASF package then you must ensure that your .NET runtime supports platform required by ASF.

ASF as a program is targeting **.NET 7.0** (`net7.0`) right now, but it may target newer platform in the future. `net7.0` is supported since 7.0.100 SDK (7.0.0 runtime), although ASF might prefer **latest runtime at the moment of compilation**, so you should ensure that you have **[latest SDK](https://dotnet.microsoft.com/download)** (or at least runtime) available for your machine. Generic ASF variant may refuse to launch if your runtime is older than the specified minimum supported one during compilation.

En cas de doute, vérifiez  ce que notre **[intégration continue utilise](https://github.com/JustArchiNET/ArchiSteamFarm/actions/workflows/publish.yml?query=branch%3Amain)** pour compiler et déployer les versions ASF sur GitHub. You can find `dotnet --info` output in every build as part of .NET verification step.