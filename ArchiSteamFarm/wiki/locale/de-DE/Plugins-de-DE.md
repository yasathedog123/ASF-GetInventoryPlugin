# Erweiterungen (Plugins)

ASF bietet Unterstützung für benutzerdefinierte Plugins, die während der Ausführung geladen werden können. Erweiterungen ermöglichen es Ihnen, das ASF-Verhalten anzupassen, z. B. durch Hinzufügen von benutzerdefinierten Befehlen, einer benutzerdefinierten Handelslogik oder der vollständigen Integration mit Diensten und APIs von Drittanbietern.

---

## Für Anwender

ASF lädt Erweiterungen aus dem Verzeichnis `plugins`, das sich in Ihrem ASF-Ordner befindet. Es wird empfohlen, für jede Erweiterung, die Sie verwenden möchten, ein eigenes Verzeichnis zu erstellen, das auf dessen Namen basieren kann, z. B. `MeinPlugin`. Dies führt zur finalen Verzeichnisstruktur `plugins/MeinPlugin`. Schließlich sollten alle Binärdateien der Erweiterungen in diesem speziellen Ordner abgelegt werden. ASF wird Ihre Erweiterung nach dem Neustart ordnungsgemäß erkennen und verwenden.

Normalerweise veröffentlichen Plugin-Entwickler ihre Erweiterungen in Form einer `zip`-Datei mit bereits vorbereiteter Struktur für Sie, sodass es genügt, das Zip-Archiv in das Verzeichnis `plugins` zu entpacken, welches automatisch den entsprechenden Ordner erstellt.

Wenn die Erweiterung erfolgreich geladen wurde, dann sehen Sie dessen Namen und Version in Ihrem Protokoll. Sie sollten den Plugin-Entwickler konsultieren, wenn es um Fragen, Probleme oder die Verwendung der Erweiterungen geht, die Sie verwenden.

Sie finden einige der vorgestellten Erweiterungen in unserem Abschnitt **[Drittanbieter](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Third-party-de-DE#asf-plugins)**.

**Bitte beachten Sie, dass ASF-Erweiterungen möglicherweise bösartig sein können**. Sie sollten immer sicherstellen, dass Sie Erweiterungen von Entwicklern verwenden, denen Sie vertrauen können. Es ist den ASF-Entwicklern nicht mehr möglich, Ihnen die üblichen ASF-Vorteile (z. B. Schutz vor Schadsoftware oder VAC-Freiheit) zu gewähren, sobald Sie sich dafür entscheiden, individuelle Erweiterungen einzusetzen. Sie müssen verstehen, dass Erweiterungen die volle Kontrolle über den ASF-Prozess haben, sobald diese geladen wurden. Wir können keine Installationen mit benutzerdefinierten Erweiterungen unterstützen, da Sie keinen »Vanilla« ASF Code mehr verwenden.

---

## Für Entwickler

Erweiterungen sind Standard .NET-Bibliotheken, die die übliche `IPlugin`-Schnittstelle von ASF erben. Sie können Erweiterungen völlig unabhängig von der Haupt-ASF-Version entwickeln und in aktuellen und zukünftigen ASF-Versionen wiederverwenden, solange die API kompatibel bleibt. Das in ASF verwendete Plugin-System basiert auf `System.Composition`, früher bekannt als **[Managed Extensibility Framework](https://learn.microsoft.com/de-de/dotnet/framework/mef/)**, welches es ASF ermöglicht, Ihre Bibliotheken während der Laufzeit zu entdecken und zu laden.

---

### Erste Schritte

Wir haben eine **[ASF-Erweiterungsvorlage](https://github.com/JustArchiNET/ASF-PluginTemplate)</a>** für Sie vorbereitet, welche als Basis für Ihr Plugin-Projekt verwendet werden kann. Die Verwendung der Vorlage ist nicht erforderlich (wenn Sie alles von Grund auf erledigen können), aber wir empfehlen diese dringend, da es Ihre Entwicklung beschleunigen und die Zeit verkürzen kann, die benötigt wird, um alles richtigzumachen. Die Datei **[README](https://github.com/JustArchiNET/ASF-PluginTemplate/blob/main/README.md)** der Vorlage wird Ihnen weiterhelfen. Unabhängig davon decken wir die Grundlagen unten ab, falls Sie bei null anfangen – oder die Konzepte in der Plugin-Vorlage besser verstehen möchten.

Ihr Projekt sollte eine Standard .NET-Bibliothek sein, die auf das geeignete Framework Ihrer Ziel-ASF-Version abzielt, wie in der **[Kompilierung](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compilation-de-DE)** angegeben.

Das Projekt muss auf die Haupt-Assembly `ArchiSteamFarm` verweisen, entweder auf die vorgefertigte `ArchiSteamFarm.dll`-Bibliothek, die Sie als Teil der Veröffentlichung heruntergeladen haben, oder auf das Quellprojekt (z. B. falls Sie sich entscheiden, den ASF-Baum als Submodul hinzuzufügen). Dies ermöglicht Ihnen Zugriff auf ASF-Strukturen, -Methoden und -Variablen (property) und diese zu entdecken, insbesondere auf die Kern-Schnittstelle `IPlugin`, von dem Sie im nächsten Schritt erben müssen. Das Projekt muss auch mindestens `System.Composition.AttributedModel` referenzieren, womit Sie Ihr `IPlugin` mittels `[Export]` für ASF bereitzustellen. Überdies kann/muss man auf andere gemeinsame Bibliotheken verweisen, um die Datenstrukturen zu interpretieren, die man in manchen Schnittstellen erhält, aber wenn man sie nicht explizit benötigt, reicht das fürs Erste.

Wenn Sie alles richtig gemacht haben wird Ihre `csproj`-Datei ähnlich wie unten aussehen:

```csproj
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="System.Composition.AttributedModel" IncludeAssets="compile" Version="8.0.0" />
  </ItemGroup>

  <ItemGroup>
    <ProjectReference Include="C:\\Path\To\ArchiSteamFarm\ArchiSteamFarm.csproj" ExcludeAssets="all" Private="false" />

    <!-- Verwenden Sie dies anstelle der <ProjectReference> oben, beim Erstellen mit einer heruntergeladenen DLL Bibliothek -->
<!-- <Reference Include="ArchiSteamFarm" HintPath="C:\\Path\To\Downloaded\ArchiSteamFarm.dll" /> -->
  </ItemGroup>
</Project>
```

Seitens des Quellcodes muss Ihre Plugin-Klasse von der Schnittstelle `IPlugin` erben (entweder explizit oder implizit von einer spezialisierteren Schnittstelle, wie `IASF`) und `[Export(typeof(IPlugin))]`, um von ASF während der Ausführung erkannt zu werden. Das einfachste Beispiel, das dies ermöglicht, ist das folgende:

```csharp
using System;
using System.Composition;
using System.Threading.Tasks;
using ArchiSteamFarm;
using ArchiSteamFarm.Plugins;

namespace IhrNamespace.IhrPluginName;

[Export(typeof(IPlugin))]
public sealed class IhrPluginName : IPlugin {
    public string Name => nameof(IhrPluginName);
    public Version Version => typeof(IhrPluginName).Assembly.GetName().Version;

    public Task OnLoaded() {
        ASF.ArchiLogger.LogGenericInfo("Meow");

        return Task.CompletedTask;
    }
}
```

Um Ihre Erweiterung verwenden zu können, müssen Sie diese zunächst kompilieren. Sie können das entweder von Ihrer Entwicklungsumgebung aus oder aus dem Stammverzeichnis Ihres Projekts mittels eines Befehls bewältigen:

```shell
# Wenn Ihr Projekt eigenständig ist (es ist nicht notwendig, seinen Namen zu definieren, da es das Einzige ist)
dotnet publish -c "Release" -o "out"

# Falls Ihr Projekt Teil des ASF-Quellbaums ist (um das Kompilieren unnötiger Teile zu vermeiden)
dotnet publish DeinPluginName -c "Release" -o "out"
```

Danach ist Ihre Erweiterung einsatzbereit. Es liegt an Ihnen, wie Sie Ihre Erweiterung verteilen und veröffentlichen möchten, aber wir empfehlen, ein Zip-Archiv mit einem einzigen Ordner namens `IhrNamespace.IhrPluginName` zu erstellen, in dem Sie Ihre kompiliere Erweiterung mit seinen **[Abhängigkeiten](#plugin-abhängigkeiten)** kopieren. Auf diese Weise muss der Benutzer einfach sein Zip-Archiv in sein `plugins` Verzeichnis entpacken und nichts weiter tun.

Dies ist nur das grundlegendste Szenario, um zu beginnen. Wir haben das Projekt **[`BeispielPlugin`](https://github.com/JustArchiNET/ArchiSteamFarm/tree/main/ArchiSteamFarm.CustomPlugins.ExamplePlugin)**, das Ihnen Beispielschnittstellen und Aktionen zeigt, die Sie innerhalb Ihrer eigenen Erweiterung ausnutzen können, einschließlich hilfreicher Kommentare. Zögern Sie nicht, einen Blick darauf zu werfen, wenn Sie von einem funktionierenden Quellcode lernen möchten, oder entdecken Sie den `ArchiSteamFarm.Plugins` Namespace selbst und schauen Sie in die mitgelieferte Dokumentation für alle verfügbaren Optionen.

Falls Sie anstatt der Beispiel-Erweiterung von richtigen Projekten erfahren möchten, gibt es die Erweiterung **[`SteamTokenDumper`](https://github.com/JustArchiNET/ArchiSteamFarm/tree/main/ArchiSteamFarm.OfficialPlugins.SteamTokenDumper)**, welche von uns entwickelt und mit ASF gebündelt wird. Weitere Erweiterungen von anderen Entwicklern werden in unserem **[Drittanbieter](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Third-party#asf-plugins-de-DE)**-Abschnitt vorgestellt.

---

### API Verfügbarkeit

ASF stellt Ihnen neben dem, worauf Sie in den Schnittstellen selbst Zugriff haben, viele seiner internen APIs zur Verfügung, die Sie verwenden können, um die Funktionalität zu erweitern. Wenn Sie etwa eine neue Art einer Steam-Web-Anfrage senden möchten, dann müssen Sie nicht alles von Grund auf neu implementieren; insbesondere nicht all den Problemen, mit denen wir uns vor Ihnen beschäftigt haben. Nutzen Sie einfach unseren `Bot.ArchiWebHandler`, der bereits viele `UrlWithSession()`-Methoden für Sie freilegt und alle untergeordneten Dinge wie Authentifizierung, Sitzungsaktualisierung oder Weblimitierung dementsprechend handhabt. Ebenso können Sie zum Senden von Web-Anfragen außerhalb der Steam-Plattform die standardmäßige .NET `HttpClient` Klasse verwenden, `Bot.ArchiWebHandler.WebBrowser` ist allerdings die bessere Wahl, da es Sie hilfreich unterstützt, etwa im Hinblick auf das erneute Ausprobieren fehlgeschlagener Anfragen.

Wir haben eine sehr offene Richtlinie in Bezug auf unsere API-Verfügbarkeit; wenn Sie also etwas verwenden möchten, das der ASF-Code bereits enthält, öffnen Sie einfach **[ein Issue](https://github.com/JustArchiNET/ArchiSteamFarm/issues)** und erklären Sie darin Ihren geplanten Anwendungsfall der internen ASF-API. Wir werden höchstwahrscheinlich nichts dagegen haben, solange Ihr Anwendungsfall Sinn ergibt. Wir können alles öffnen, was jemand verwenden möchte; daher haben wir das geöffnet, was für uns am sinnvollsten ist, und warten auf Ihre Wünsche – falls Sie Zugang zu etwas haben möchten, das bislang nicht `public` ist. Dazu gehören auch alle Vorschläge zu neuen `IPlugin`-Schnittstellen, die sinnvoll sein könnten, um die bestehende Funktionalität zu erweitern.

Tatsächlich ist die interne ASF-API die einzige wirkliche Einschränkung in Bezug auf das, was Ihre Erweiterung tun kann. Nichts hält Sie davon ab, z. B. die `Discord.Net` Bibliothek in Ihre Anwendung aufzunehmen und eine Brücke zwischen Ihrem Discord-Bot und ASF-Befehlen zu schlagen, da Ihre Erweiterung auch eigenständige Abhängigkeiten haben kann. Die Möglichkeiten sind endlos und wir haben unser Bestes getan, um Ihnen so viel Freiheit und Flexibilität wie möglich innerhalb Ihrer Erweiterung zu bieten; also gibt es keinerlei künstlichen Grenzen – nur sind wir uns nicht ganz sicher, welche ASF-Teile für Ihre Erweiterungsentwicklung entscheidend sind (was Sie lösen können, indem Sie uns das Mitteilen), und Sie können auch ohne dem die benötigte Funktionalität jederzeit erneut implementieren.

---

### API Kompatibilität

Es ist wichtig zu betonen, dass ASF eine Verbraucher-Anwendung ist und nicht eine typische Bibliothek mit fester API-Oberfläche, auf die Sie sich bedingungslos verlassen können. Es ist somit unmöglich zu erwarten, dass die von Ihnen erstellte Erweiterung auch in den kommenden ASF-Versionen weiterhin funktioniert. Wenn wir das Programm weiterentwickeln wollen, um sich an ständig auftretende Steam-Änderungen anzupassen, dann sind Abstriche bei der Rückwärtskompatibilität früher oder später erforderlich. Es für Ihren Fall schlichtweg nicht angemessen, ausschließlich auf die Rückwärtskompatibilität zu achten. Das sollte für Sie logisch sein, aber es ist wichtig, diese Tatsache hervorzuheben.

Wir werden unser Bestes tun um die öffentlichen Teile von ASF funktionsfähig und stabil zu halten, aber wir haben keine Angst davor, die Kompatibilität zu brechen, wenn gute Gründe dafür vorliegen, da wir währenddessen unserer Politik für **[veraltete Funktionen](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Deprecation-de-DE)** folgen. Dies ist besonders wichtig für interne ASF-Strukturen, die Ihnen als Teil der ASF-Infrastruktur zur Verfügung stehen, wie oben erläutert (z. B. `ArchiWebHandler`), die im Rahmen von ASF-Erweiterungen in einer der zukünftigen Versionen verbessert (und damit neu geschrieben) werden können. Wir werden unser Bestes tun, um dich in den Änderungsprotokollen angemessen zu informieren und während der Laufzeit entsprechende Warnungen über veraltete Funktionen zu geben. Wir beabsichtigen nicht alles neu zu schreiben, um es neu zu schreiben, also können Sie ziemlich sicher sein, dass die nächste kleinere ASF-Version Ihre Erweiterung nicht einfach nur deshalb komplett zerstört, weil es eine höhere Versionsnummer hat. Aber es ist eine gute Idee ein Auge auf Änderungsprotokolle zu werfen und gelegentlich zu überprüfen, ob alles einwandfrei funktioniert.

---

### Plugin-Abhängigkeiten

Ihre Erweiterung enthält standardmäßig mindestens zwei Abhängigkeiten, die Referenz `ArchiSteamFarm` für die interne API und `PackageReference` von `System.Composition.AttributedModel`, die erforderlich ist, um als ASF-Erweiterung erkannt zu werden. Überdies könnte es mehr Abhängigkeiten in Bezug auf das, was Sie in Ihrer Erweiterung getan haben, enthalten (z. B. `Discord.Net` Bibliothek, wenn Sie sich für die Integration mit Discord entschieden haben).

Die Ausgabe Ihres Builds wird Ihre Kernbibliothek `IhrPluginName.dll`, sowie alle Abhängigkeiten enthalten, auf die Sie verwiesen haben. Da Sie eine Erweiterung zu einem bereits funktionierendem Programm entwickeln, müssen und **sollten Sie** die Abhängigkeiten von ASF (z. B. `ArchiSteamFarm`, `SteamKit2` oder `AngleSharp`) ** nicht inkludieren**. Das Entfernen von geteilten ASF-Abhängigkeiten in Ihrem Build ist nicht unbedingt erforderlich für die Funktionsfähigkeit einer Erweiterung, aber dies wird den Speicherbedarf, die Größe dieser drastisch reduzieren, und gleichzeitig die Leistung erhöhen; da ASF seine eigenen Abhängigkeiten mit Ihnen teilt und nur die Bibliotheken lädt, die es nicht über sich selbst kennt.

Generell wird empfohlen, nur Bibliotheken einzubinden, die ASF entweder gar nicht oder nur in einer falschen/inkompatiblen Version enthält. Beispiele dafür wären natürlich `IhrPluginName.dll`, aber zum Beispiel auch `Discord.Net.dll`, falls Sie sich entschieden haben sollten, darauf zurückzugreifen, da ASF diese nicht selbst mitbringt. Das Bündeln von Bibliotheken, die gemeinsam mit ASF genutzt werden, kann dennoch sinnvoll sein, wenn Sie die API-Kompatibilität sicherstellen möchten (etwa `AngleSharp`, von dem Sie in Ihrer Erweiterung abhängig sind, immer in der Version `X` und nicht in der Version ist, in der ASF sie bereitstellt); allerdings kommt offensichtlich dies auf Kosten von mehr Speicher/Größe und schlechterer Leistung.

Wenn Sie wissen, dass die benötigte Abhängigkeit in ASF enthalten ist, können Sie es mit `IncludeAssets="compile"` markieren, wie wir Ihnen im Beispiel `csproj` (oben) gezeigt haben. Dies wird dem Compiler mitteilen, die Veröffentlichung der referenzierter Bibliothek selbst zu vermeiden, da ASF diese bereits beinhaltet. Beachten Sie auch, dass wir das ASF-Projekt mit `ExcludeAssets="all" Private="false"` referenzieren, welches ähnlich funktioniert – es teilt dem Gerät mit, keine ASF-Dateien zu produzieren (da der Benutzer sie bereits hat). Dies gilt nur, wenn das ASF-Projekt referenziert wird, da Sie auf eine `dll` Bibliothek verweisen, dann produzieren Sie keine ASF-Dateien als Teil Ihrer Erweiterung.

Wenn Sie über die obige Erklärung verwirrt und unschlüssig sind, welche `dll`-Bibliotheken im Paket `ASF-generic.zip` enthalten sind und stellen Sie sicher, dass Ihre Erweiterung nur die enthält, die bislang nicht Teil davon sind. Für die einfachsten Erweiterungen wird dies nur `IhrPluginName.dll` sein. Fügen Sie auch die betroffenen Bibliotheken hinzu, wenn Sie während der Laufzeit Probleme in Bezug auf einige Bibliotheken. Wenn alles andere fehlschlägt, können Sie sich jederzeit entscheiden, alles zu bündeln.

---

### Native Abhängigkeiten

Native Abhängigkeiten werden als Teil von betriebssystemspezifischen Builds generiert, da auf dem Host keine .NET Runtime verfügbar ist und ASF seine eigene .NET Runtime nutzt, die als Teil des betriebssystemspezifischen Builds gebündelt wird. Um die Größe des Builds zu minimieren, reduziert ASF seine nativen Abhängigkeiten so, dass nur der Programmcode berücksichtigt wird, der innerhalb des Programms erreichbar ist, was die ungenutzten Teile der Laufzeit effektiv reduziert. Es könnte sich um ein potenzielles Hindernis für Ihre Erweiterung handeln, falls Sie unerwartet eine Situation erleben, in der das Plugin eine .NET-Funktion aufweist, die nicht in ASF integriert ist; deshalb können OS-spezifische Builds nicht richtig funktionieren und resultiert bei dem Versuch für gewöhnlich in die Fehler `System.MissingMethodException` oder `System.Reflection.ReflectionTypeLoadException`.

Dies ist bei generischen Builds nie ein Problem, da es sich hierbei nie um native Abhängigkeiten handelt (da sie die gesamte lauffähige Runtime auf dem Host haben und ASF ausführen). Es ist auch automatisch eine Lösung des Problems, indem **Sie Ihre Erweiterung ausschließlich in generischen Builds verwenden**; jedoch hat das offensichtlich seinen eigenen Nachteil, wenn es darum geht, Ihre Erweiterung von Benutzern zu trennen, die OS-spezifische ASF-Variante ausführen. Falls Sie sich fragen, ob Ihr Problem im Zusammenhang mit nativen Abhängigkeiten steht, können Sie diese Methode auch zur Überprüfung verwenden. Lade Ihre Erweiterung in der generischen ASF Variante und schauen Sie, ob es funktioniert. Wenn dies der Fall ist, sind die Plugin-Abhängigkeiten abgedeckt, sodass native Abhängigkeiten Probleme verursachen.

Wir mussten entscheiden, ob wir die gesamte Laufzeit als Teil unserer OS-spezifischen Builds veröffentlichen oder es von nicht genutzten Funktionen trennen. Das würde die Builds um über 50 MB im Vergleich zu einer vollständigen Version reduzieren. Wir haben die letzte Option ausgewählt, und es ist leider unmöglich für Sie, die fehlenden Laufzeitfunktionen zusammen mit Ihrer Erweiterung hinzuzufügen. Wenn Ihr Projekt Zugriff auf verworfene Laufzeitfunktionen benötigt, müssen Sie die .NET Laufzeit vollständig einbinden, auf die Sie angewiesen sind; das bedeutet, Ihre Erweiterung zusammen mit der ASF-Variante `generic` auszuführen. Sie können Ihre Erweiterung nicht in OS-spezifischen Builds ausführen, da diese einfach die benötigte Laufzeit-Funktion vermisst, und .NET Runtime ist derzeit nicht in der Lage native Abhängigkeiten „zusammenzuführen“ (unsere zur Verfügung gestellten mit Ihrer). Vielleicht wird es sich eines Tages bessern, aber zum jetzigen Zeitpunkt ist es einfach nicht möglich.

OS-spezifische -Builds von ASF enthalten das Minimum an zusätzlicher Funktionalität, die für unsere offiziellen Erweiterungen erforderlich ist. Abgesehen von dieser Möglichkeit, ergänzt dies auch die Oberfläche leicht um zusätzliche Abhängigkeiten für die grundlegendsten Erweiterungen. Als Konsequenz müssen sich nicht alle Erweiterungen um native Abhängigkeiten kümmern – nur jene, die über das hinausgehen, was ASF (bzw. unsere offiziellen Erweiterungen) direkt benötigen. Dies geschieht als Extra; da wir selbst bereits zusätzliche native Abhängigkeiten für unsere eigenen Anwendungsfälle einbeziehen müssen, können wir diese auch direkt mit ASF bündeln, sodass sie leichter abdeckbar bleiben, auch für Sie. Leider reicht das nicht immer aus; und da Ihre Erweiterung größer und komplexer wird, erhöht sich die Wahrscheinlichkeit, dass sie mit eingeschränkter Funktionalität ausführbar ist. Demzufolge empfehlen wir Ihnen normalerweise Ihre benutzerdefinierten Erweiterungen ausschließlich mit der ASF-Variante `generic` zu betreiben. Sie können immer noch manuell überprüfen, ob OS-spezifische ASF-Versionen alles haben, was die Erweiterung für seine Funktionalität benötigt – aber da sich dies sowohl bei Ihren, als auch bei unserem Update ändert, könnte es schwierig sein dieses zu pflegen.