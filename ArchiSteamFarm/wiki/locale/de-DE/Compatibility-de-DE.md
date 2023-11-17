# Kompatibilität

ASF ist eine C#-Anwendung, welche mit der .NET-Plattform ausgeführt wird. Das bedeutet, dass ASF nicht direkt in **[Maschinencode](https://en.wikipedia.org/wiki/Machine_code)** kompiliert wird, der auf der CPU läuft, sondern in **[CIL](https://de.wikipedia.org/wiki/Common_Intermediate_Language)**, welche eine CIL-kompatible Runtime für dessen Ausführung benötigt.

Dieser Ansatz hat enorme Vorteile, da CIL plattformunabhängig ist. Aus diesem Grund kann ASF nativ auf vielen verfügbaren Betriebssystemen, insbesondere Windows, Linux und macOS, ausgeführt werden. Es wird nicht nur keine Emulation benötigt, sondern auch Unterstützung für alle plattformbezogenen und hardwarebezogenen Optimierungen, wie z. B. CPU-SSE-Anweisungen. Dank dessen kann ASF eine überlegene Leistung und Optimierung erreichen, während es gleichzeitig eine perfekte Kompatibilität und Zuverlässigkeit bietet.

Das bedeutet auch, dass ASF **keine spezifische Betriebssystem-Anforderung** hat, weil es die funktionierende **Runtime** auf diesem Betriebssystem benötigt und nicht das Betriebssystem selbst. Solange die Laufzeitumgebung den ASF-Code korrekt ausführt, spielt es keine Rolle, ob das Betriebssystem Windows, Linux ist macOS, BSD, Sony Playstation 4, Nintendo Wii oder ein Toaster ist - solange es **[.NET](https://dotnet.microsoft.com/download/dotnet)** dafür gibt, existiert **[ASF](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** dafür (als `generic` Variante).

Unabhängig davon, wo Sie ASF ausführen, müssen Sie jedoch sicherstellen, dass auf ihrer Zielplattform **[.NET-Voraussetzungen](https://github.com/dotnet/core/blob/main/Documentation/prereqs.md)** installiert sind. Diese sind Low-Level-Bibliotheken, welche für eine einwandfreie Laufzeitfunktionalität benötigt werden und unerlässlich für die bloße Funktion von ASF sind. Sehr wahrscheinlich haben Sie bereits einige (oder sogar alle) davon installiert.

---

## ASF-Pakete

ASF gibt es in 2 Hauptformen - generisches Paket und betriebssystemspezifisch. Aus funktionaler Sicht sind beide Pakete genau gleich. Beide sind auch in der Lage, sich selbst automatisch zu aktualisieren. Der einzige Unterschied zwischen Ihnen ist, ob zusätzlich zum **generischen** Paket von ASF auch eine **betriebssystemspezifische** Runtime enthalten ist oder nicht.

---

### Generisch

Das generische Paket ist ein plattformunabhängiger Build, der keinen maschinenspezifischen Code enthält. Dieses Setup erfordert, dass Sie die .NET Core Runtime bereits **in der entsprechenden Version** auf dem Betriebssystem installiert haben. Wir alle wissen, wie lästig es ist, Abhängigkeiten auf dem neuesten Stand zu halten, deshalb ist dieses Paket hauptsächlich für Leute gedacht, die .NET **bereits** verwenden und diese Runtime nicht explizit für ASF zusätzlich pflegen wollen; wenn sie das nutzen können, was sie bereits installiert haben. Das generische Paket ermöglicht es Ihnen auch, ASF ** überall dort auszuführen, solange eine funktionierende Implementierung der .NET Runtime zur Verfügung steht**, unabhängig davon, ob es einen betriebssystemspezifischen ASF Build dafür gibt oder nicht.

Es wird nicht empfohlen, den generischen Build zu verwenden, wenn Sie ein Gelegenheits- oder sogar fortgeschrittener Benutzer sind, der ASF lediglich ausführen will, ohne sich mit den technischen Details (von .NET) befassen zu müssen. Mit anderen Worten - wenn Sie wissen, worauf Sie sich damit einlassen, dann können Sie es benutzen; sonst ist es viel besser, ein betriebssystemspezifisches Paket zu verwenden, das unten erklärt wird.

#### .NET Framework Paket

Zusätzlich zu dem oben genannten generischen Paket gibt es auch `generic-netf` Paket, das grundlegend auf .NET Framework und nicht .NET (Core). Bei diesem Paket handelt es sich um eine veraltete Variante, die eine, bereits aus ASF V2 bekannte, fehlende Kompatibilität bietet und z.B. mit **[Mono](https://www.mono-project.com)** ausgeführt werden kann, während das mit dem `generic` .NET-Paket derzeit nicht möglich ist.

Im Allgemeinen sollten Sie **dieses Paket so weit wie möglich vermeiden**, da die meisten Betriebssysteme und Setups perfekt (und viel besser) mit dem oben erwähnten ` generic ` Paket unterstützt werden. Tatsächlich ist es sinnvoll, dieses Paket nur auf Plattformen zu verwenden, auf denen es keine funktionierende .NET Runtime gibt, aber zuindest eine Mono-Implementierung bieten. Beispiele für solche Plattformen sind `linux-x86` (32-bit i386/i686 linux), sowie `linux-armel` (ARMv6-Boards wie z.b. der Raspberry Pi 0 & 1), die alle bislang kein offiziell funktionierendes .NET Runtime haben.

Im Laufe der Zeit werden mehr Plattformen von .NET unterstützt und die Kompatibilität zwischen .NET Framework und .NET wird sich verringern. In der Zukunft wird das `generic-netf` Paket vollständig durch das `generic` Paket ersetzt werden. Bitte verzichten Sie auf die Verwendung dieser Variante, wenn Sie stattdessen ein .NET Paket verwenden können; da `generic-netf` im Vergleich zu .NET Versionen viel Funktionalität und Kompatibilität einbüßt und es in Zukunft immer weniger funktional sein wird. Wir bieten **nur** Unterstützung für dieses Paket auf Rechnern, die die obrige `generic` Variante nicht verwenden können (z. B. `linux-x86`), und nur mit aktueller Runtime (z. B. neuestes Mono).

---

### Betriebssystemspezifisch

Das betriebssystemspezifische Paket beinhaltet neben dem verwalteten Code, der im generischen Paket enthalten ist, auch nativen Code für die jeweilige Plattform. Mit anderen Worten: das betriebssystemspezifische Paket **beinhaltet bereits die richtige .NET Runtime**, was es Ihnen ermöglicht, den gesamten Installationsprozess komplett zu überspringen und ASF einfach direkt zu starten. Das betriebssystemspezifische Paket, wie man dem Namen entnehmen kann, ist betriebssystemspezifisch und jedes Betriebssystem benötigt eine eigene Version - zum Beispiel Windows benötigt PE32+ `ArchiSteamFarm.exe` Binärdatei während Linux mit Unix ELF `ArchiSteamFarm` Binärdatei arbeitet. Wie Sie vielleicht wissen, sind diese beiden Typen nicht miteinander kompatibel.

ASF ist derzeit in folgenden betriebsystemspezifischen Varianten verfügbar:

- `linux-arm` arbeitet unter 32-bit ARM-basierten (ARMv7+) GNU/Linux-Betriebssystemen mit glibc 2.27 und neuer. Diese Variante deckt Plattformen wie Raspberry Pi 2 (und neuer) ab, sie funktioniert **nicht** mit älteren ARM-Architekturen (wie ARMv6 in Raspberry Pi 0 & 1 vorhanden); es funktioniert auch nicht mit Betriebssystemen, die nicht die erforderliche GNU/Linux-Umgebung implementieren (etwa Android).
- `linux-arm64` arbeitet unter 64-Bit-ARM-basierten (ARMv8+) GNU/Linux-Betriebssystemen mit glibc 2.23/musl 1.2.2 und neuer. Diese Variante umfasst Plattformen wie Raspberry Pi 3 (und neuer), es wird **nicht** mit 32-Bit Betriebssystemen arbeiten, die nicht über erforderliche 64-Bit Bibliotheken verfügen (z. B. 32-Bit Raspberry Pi OS), es funktioniert auch nicht mit Betriebssystemen, die nicht die erforderliche GNU/Linux-Umgebung implementieren (wie Android).
- `linux-x64` arbeitet unter 64-Bit-GNU/Linux-Betriebssystemen mit glibc 2.17/musl 1.2.2 und neuer.
- `osx-arm64` arbeitet unter 64-Bit-ARM-basierten (Apple silicon) macOS Betriebssystemen in Version 11 und neuer.
- `osx-x64` funktioniert auf 64-Bit-MacOS-Betriebssystemen in Version 10.15 und neuer.
- `win-arm64` funktioniert unter 64-Bit-ARM-basierten (ARMv8+) Windows-Betriebssystemen in Version 10, 11 und neuer.
- `win-x64` funktioniert unter 64-Bit-Windows-Betriebssystemen in Version 10, 11, Server 2012+ und neuer.

Selbst wenn Sie kein betriebssystemspezifisches Paket für Ihre Betriebssystem-Architektur-Kombination zur Auswahl haben, können Sie natürlich jederzeit selbst die entsprechende .NET Runtime installieren und die generische ASF-Version ausführen, was auch der Hauptgrund dafür ist, dass diese überhaupt existiert. Der generische ASF-Build ist plattformunabhängig und läuft auf jeder Plattform, die eine funktionierende .NET Runtime hat. Wichtig ist: ASF benötigt die .NET Runtime und nicht ein bestimmtes Betriebssystem oder eine bestimmte Architektur. Wenn Sie zum Beispiel ein 32-Bit-Windows benutzen, dann können Sie trotz der fehlenden dedizierten `win-x86` ASF-Version immer noch das .NET SDK in der `win-x86`-Version installieren und die generische ASF-Version problemlos ausführen. Wir können nicht jede Kombination aus Betriebssystem und Architektur ansprechen, die existiert und von jemandem verwendet wird, also müssen wir irgendwo eine Grenze ziehen. Ein gutes Beispiel für diese Grenze ist x86, da es sich um eine veraltete Architektur seit mindestens 2004 handelt.

Für eine vollständige Liste aller unterstützten Plattformen und Betriebssystemen von .NET 7.0 besuchen Sie bitte die **[Versionshinweise](https://github.com/dotnet/core/blob/main/release-notes/7.0/supported-os.md)**.

---

## Runtime-Anforderungen

Wenn Sie ein betriebssystemspezifisches Paket verwenden, müssen Sie sich keine Sorgen um die Runtime-Anforderungen machen. ASF wird immer mit der erforderlichen und aktuellen Runtime ausgeliefert, die einwandfrei funktioniert, solange Sie die **[.NET Prerequisites](https://github.com/dotnet/core/blob/main/Documentation/prereqs.md)** installiert und auf dem neuesten Stand haben. Mit anderen Worten: **muss die .NET Runtime oder SDK** nicht installiert werden, da betriebssystemspezifische Builds nur native Betriebssystemabhängigkeiten (Prerequisites) und nichts anderes erfordern.

Falls Sie dennoch das **generische** ASF-Paket ausprobieren möchten, dann müssen Sie unbedingt sicherstellen, dass die installierte .NET Runtime die von ASF benötigte Plattform unterstützt.

ASF als Programm ist derzeit auf **.NET Core 7.0** (`.NET 7.0`) ausgerichtet, könnte aber in Zukunft eine neuere Plattform erfordern. `net7.0` wird seit 7.0.100 SDK (7.0.0 Runtime) unterstützt, wobei ASF ** die letzte Runtime zum Zeitpunkt der Kompilierung** bevorzugt; also sollten Sie sicherstellen, dass Ihnen**[die neueste SDK](https://dotnet.microsoft.com/download)** (oder zumindest die Runtime) für ihre Maschine zur Verfügung steht. Die generische ASF-Variante kann den Start verweigern, wenn die installierte Laufzeitumgebung älter ist als die minimale Runtime, die während der Kompilierung bekannt ist.

Im Zweifelsfall sollten Sie überprüfen, was unsere **[kontinuierliche Integration](https://github.com/JustArchiNET/ArchiSteamFarm/actions/workflows/publish.yml?query=branch%3Amain)** für die Kompilierung und Bereitstellung von ASF-Versionen auf GitHub verwendet. Sie können `dotnet --info` in jedem Build als Teil des .NET Verifizierungsschritts finden.