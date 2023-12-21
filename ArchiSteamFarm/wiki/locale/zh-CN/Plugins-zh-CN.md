# 插件

ASF 支持在运行时加载自定义插件。 插件允许您自定义 ASF 行为，例如添加自定义命令、自定义交易逻辑或者与其他第三方服务与 API 进行整体集成。

---

## 致用户

ASF 会从 ASF 目录内的 `plugins` 文件夹加载插件。 建议您根据插件名称，将每个您需要使用的插件放在专门的文件夹内，例如 `MyPlugin`。 这样最终的文件夹结构为 `plugins/MyPlugin`。 最后，这个插件的所有二进制文件都应该被放在这个专门的文件夹内，而 ASF 会在重启之后自动发现并启用您的插件。

通常，插件开发者会以 `zip` 文件形式发布插件，其中已有合适的文件结构，所以直接将 zip 压缩包解压到 `plugins` 文件夹就足够了，解压过程会自动创建合适的文件夹结构。

如果插件成功加载，您将会在日志内看到它的名称和版本。 在遇到与您使用的插件有关的问题、漏洞或者对其用法有疑问时，您应该咨询相应插件的开发人员。

我们在&#8203;**[第三方项目](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Third-party-zh-CN#asf-插件)**&#8203;章节列出了一些精选插件。

**请注意，ASF 插件可能是有害的**。 您应该始终确保您使用插件来自于您可以信任的开发人员。 如果您决定使用任何自定义插件，ASF 开发者将不再保证您的正常 ASF 权益（例如不保证没有恶意软件或者 VAC 安全）。 您应当理解，一旦被加载，插件就可以完全控制 ASF 进程，因此我们亦无法对使用自定义插件的 ASF 提供支持，因为您运行的不再是标准 ASF 代码。

---

## 致开发者

插件是继承 ASF 通用 `IPlugin` 接口的标准 .NET 库。 您可以完全独立于 ASF 主线开发插件，并在当前和未来 ASF 版本中复用它们，只要 API 仍保持兼容。 ASF 使用的插件系统基于 `System.Composition`，过去它被称为 **[Managed Extensibility Framework](https://docs.microsoft.com/dotnet/framework/mef)**，它可以使 ASF 在运行时动态检测并加载库文件。

---

### 入门指南

我们为您准备了 **[ASF 插件模板](https://github.com/JustArchiNET/ASF-PluginTemplate)**，您可以以此作为插件项目的基础。 使用模板并不是强制性的（因为您可以完全从零开始），但我们强烈建议您使用，因为它能够大大加速您的开发，节约各种配置的时间。 阅读模板的 **[README](https://github.com/JustArchiNET/ASF-PluginTemplate/blob/main/README.md)** 进一步了解详情。 无论如何，如果您打算从零开始或者希望更好地理解插件模板中的概念，我们接下来也会介绍相关基础。

您的项目应该是一个标准 .NET 库，其目标指向对应 ASF 版本所使用框架的版本，如[**编译**](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compilation-zh-CN)章节所述。

您的项目必须引用 `ArchiSteamFarm` 主程序集，或者您下载的 ASF 中包含的预编译 `ArchiSteamFarm.dll` 库，或者项目源代码（例如您决定将 ASF 代码树添加为子模块的情况）。 这样，您就可以访问与检查 ASF 的结构、方法和属性，特别是您接下来需要继承的核心 `IPlugin` 接口。 该项目还必须至少引用 `System.Composition.AttributedModel`，使您能够将插件的 `IPlugin` 实现 `[Export]`（导出）给 ASF 使用。 此外，您可能还需要引用其他公共库，以便解析某些接口提供给您的数据结构，但除非您明确需要它们，否则现在这样就足够了。

如果您正确执行了所有操作，则您的 `csproj` 文件结构应该类似：

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

    <!-- 如果要使用下载的 DLL 二进制文件构建，使用此设置代替上面的 <ProjectReference> 标签 -->
    <!-- <Reference Include="ArchiSteamFarm" HintPath="C:\\Path\To\Downloaded\ArchiSteamFarm.dll" /> -->
  </ItemGroup>
</Project>
```

而代码方面，您的插件类必须继承自 `IPlugin` 接口（可以是显式继承，或者通过 `IASF` 等更专门的接口进行隐式继承），并且 `[Export(typeof(IPlugin))]` 使 ASF 能够在运行时识别。 实现该目标的最简示例如下：

```csharp
using System;
using System.Composition;
using System.Threading.Tasks;
using ArchiSteamFarm;
using ArchiSteamFarm.Plugins;

namespace YourNamespace.YourPluginName;

[Export(typeof(IPlugin))]
public sealed class YourPluginName : IPlugin {
    public string Name => nameof(YourPluginName);
    public Version Version => typeof(YourPluginName).Assembly.GetName().Version;

    public Task OnLoaded() {
        ASF.ArchiLogger.LogGenericInfo("Meow");

        return Task.CompletedTask;
    }
}
```

要使用您的插件，就必须先进行编译。 您可以通过 IDE 进行此操作，也可以在您项目的根目录执行命令：

```shell
# 如果您的项目是独立的（不需要定义其名称，因为它是唯一的项目）
dotnet publish -c "Release" -o "out"

# 如果您的项目属于 ASF 代码树的一部分（防止编译不需要的部分）
dotnet publish YourPluginName -c "Release" -o "out"
```

然后，您的插件已经准备好进行部署。 如何分发和发布插件完全取决于您自己，但我们建议创建一个 zip 压缩包，其中只有一个以插件命名空间和插件名 `YourNamespace.YourPluginName` 为名的的目录，目录内部放置已编译好的插件及其&#8203;**[依赖项](#插件依赖项)**。 这样用户在安装时就只需要将 zip 压缩包解压到 `plugins` 目录而不需要其他操作。

这只是开发插件最基本的场景。 我们提供了 **[`ExamplePlugin`](https://github.com/JustArchiNET/ArchiSteamFarm/tree/main/ArchiSteamFarm.CustomPlugins.ExamplePlugin)** 项目，向您展示您可以在自己的插件内实现的接口和操作的示例，还有实用的注释。 如果您希望从现有的代码中学习，可以随意查看该项目，或者自行探索 `ArchiSteamFarm.Plugins` 命名空间，并且参考包含所有可用选项的文档。

如果您认为示例插件还不够，需要学习一些真实的项目，我们也开发了 **[`SteamTokenDumper`](https://github.com/JustArchiNET/ArchiSteamFarm/tree/main/ArchiSteamFarm.OfficialPlugins.SteamTokenDumper)** 插件，与 ASF 一同打包。 此外，还有一些由其他开发者编写的插件，我们已将其列在&#8203;**[第三方项目](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Third-party-zh-CN#asf-插件)**&#8203;章节。

---

### API 可用性

除了您有权在接口本身中访问的内容外，ASF 还向您公开了许多内部 API，您可以使用这些 API 来扩展功能。 例如，如果您想向 Steam Web 发送某种新请求，则无需从零开始实现一切，特别是无需自行处理我们已经处理过的问题。 只需要使用我们的 `Bot.ArchiWebHandler`，其中已经公开了许多 `UrlWithSession()` 方法供您使用，它们已经为您完成了一切底层工作，例如身份验证、会话刷新或者处理 Web 限制等。 同样，如果要向 Steam 平台以外发送 Web 请求，您可以使用标准的 .NET `HttpClient` 类，但更好的方法是使用我们提供的 `Bot.ArchiWebHandler.WebBrowser`，它已经帮您实现了很多细节，例如请求失败重试功能。

我们对于 API 可用性方面的政策非常开放，所以如果您需要利用 ASF 代码中已有的内容，请&#8203;**[开启一个 Issue](https://github.com/JustArchiNET/ArchiSteamFarm/issues)**，并在其中解释您需要使用的 ASF 内部 API 以及您计划使用的场景。 只要您的使用场景有意义，我们就很可能不会反对。 我们不可能立刻公开一切可以利用的内容，所以我们只会公开目前对我们来说最有意义的部分，然后等待您的需求，如果您需要访问的内容尚未标记为 `public`（公开）。 这也包括所有关于新 `IPlugin` 接口的建议，只要它们能够合理地扩展现有功能。

实际上，ASF 内部 API 是插件功能的唯一限制。 没有什么能够阻止您，因为您的插件也可以有自己的依赖项，例如，您的应用可以引用 `Discord.Net` 库，在您的 Discord 机器人与 ASF 命令之间架起桥梁。 可能性是无穷无尽的，我们会尽力为您的插件提供最大的自由与灵活性，所以没有任何人为的限制，只是我们不能完全确定哪些 ASF 组件是插件开发所需的（您可以告知我们详情来解决这一点，并且您也总是可以自己重新实现所需的功能）。

---

### API 兼容性

需要强调的是，ASF 是一个面向用户的应用程序，而不是一个您可以无条件依赖的、具有稳定 API 接口的库。 这意味着，您无法假定您的插件一经编译就可以在未来所有 ASF 版本中可用，在我们还想持续开发程序的情况下，这是不可能实现的，我们无法仅仅为了向后兼容就放弃不断适应 Steam 的变化。 这对您来说应该是符合逻辑的，但强调这个事实很重要。

我们会尽最大努力保持 ASF 的公开部分能够正常、稳定，但如果有足够的理由，我们不会惧怕破坏兼容性，而是遵守&#8203;**[弃用](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Deprecation)**&#8203;政策进行变更。 这对于作为 ASF 基础设施的一部分公开给您的内部 ASF 结构来说尤为重要，如上文所述（例如 `ArchiWebHandler`），它们可能会在未来的某个版本中作为 ASF 的增强而被改进（或者说被重写）。 我们会尽全力在更新日志中为您提供适当的说明，并且在运行时显示适当的与过时功能有关的警告。 我们不会故意为了重写而重写，因此您可以确信，下一个次要 ASF 版本不会仅仅因为版本号更高就让插件完全失效，但您最好时刻关注更新日志，并且偶尔实际验证是否一切都正常工作。

---

### 插件依赖项

默认情况下，您的插件需要至少两个依赖项，`ArchiSteamFarm` 用于引用内部 API，以及 `System.Composition.AttributedModel` 的 `PackageReference`，这是使项目被识别为 ASF 插件所必需的。 除此之外，根据您插件的功能，您可能还需要添加更多依赖项（例如，如果您的插件需要集成 Discord，就需要 `Discord.Net` 库）。

构建过程的输出包括您的核心 `YourPluginName.dll` 库和所有您引用的依赖项。 因为您正在为已经正常工作的程序开发插件，您不需要也**不应该**打包 ASF 已包含的依赖项，例如 `ArchiSteamFarm`、`SteamKit2` 或 `Newtonsoft.Json`。 在构建中削减与 ASF 共享的依赖项并不是使插件运行所强制要求的，但这样做将极大地减少内存占用和插件本身的大小，同时提高性能，因为 ASF 会与您的插件共享自己的依赖项，并且只会加载它未知的库。

通常，建议的做法是，只打包 ASF 不包含的或者与 ASF 包含版本不同/不兼容的库。 相应的例子显然有 `YourPluginName.dll`，但如果您决定集成 Discord，而 ASF 并未包含 `Discord.Net.dll`，则您也需要打包此项。 如果您希望确保 API 兼容性，打包与 ASF 共享的库仍然是有意义的（例如，确保您在插件中使用的 `Newtonsoft.Json` 始终锁死在版本 `X`，而不是 ASF 提供的版本），但显然这样做的成本是增大了内存开销和插件的大小，并且导致性能下降，因此需要仔细评估。

如果您确定您需要的依赖项已经包含在 ASF 中，就可以将它标记为 `IncludeAssets="compile"`，如上 `csproj` 示例所示。 这会告诉编译器不发布被引用的库，因为 ASF 已经包含该库。 同样地，注意我们使用 `ExcludeAssets="all" Private="false"` 来引用 ASF 项目，这与之前的做法很相似——告诉编译器不要生成任何 ASF 文件（因为用户已经有这些文件了）。 这仅仅适用于引用 ASF 项目的情况，如果您引用的是 `dll` 库，则您的插件不会生成 ASF 文件。

如果您对上述句子感到困惑并且难以理解，请查看 `ASF-generic.zip` 包内含有的所有 `dll` 库，并确保您的插件只包含没有出现在这里的库。 对于最简单的插件来说，唯一符合条件的就是 `YourPluginName.dll`。 如果您在运行时遇到某些库出现问题，也请一并打包受到影响的库。 如果一切尝试都失败，您仍然可以自行决定打包哪些内容。

---

### 本机依赖项

本机依赖项是作为特定操作系统构建的一部分生成的，因为此时宿主机上没有可用的 .NET 运行时环境，而 ASF 需要通过特定操作系统构建内自带的 .NET 运行时环境运行。 为了最大限度地减小构建大小，ASF 会削减其本机依赖项，使其仅包括程序中可能用到的代码，从而有效地减少运行时不会使用的部分。 这可能会给您的插件带来潜在的问题，您可能会突然发现自己的插件依赖于某些未在 ASF 中使用的 .NET 功能，从而使特定操作系统构建无法正确执行它，通常表现为进程抛出 `System.MissingMethodException` 异常或 `System.Reflection.ReflectionTypeLoadException` 异常。

这对于 generic 构建来说从来都不是问题，因为它们本来就不会自己处理本机依赖项（它们需要宿主机上的完整运行时环境来执行 ASF）。 这也是该问题的一个简单解决方案，**使您的插件只供 Generic 构建使用**，但其缺点也很明显，特定操作系统构建的 ASF 用户就无法使用您的插件。 如果您想知道您遇到的问题是否与本机依赖有关，也可以使用这种方法来验证，即在 ASF Generic 构建中加载您的插件，看看它是否正常工作。 如果能，则说明您的插件依赖项已完备，问题的根源在于本机依赖项。

不幸的是，我们必须做出一个难以抉择的决定，一是在特定操作系统构建中打包完整的运行时环境，二是删除其中未被使用的部分，使构建能比完整版本减少超过 50 MB。 我们选择了后者，因而，您无法在您的插件中使用运行时环境缺失的功能。 如果您的项目需要使用这些功能，就必须包含您依赖的完整的 .NET 运行时环境，这意味着您的插件需要与 ASF 的 `generic` 版本一起使用。 您无法在特定操作系统版本中使用此插件，因为那些版本缺少您所需的运行时环境功能，而 .NET 运行时环境目前无法支持“合并”您自己额外提供的本机依赖项。 也许在将来某天会支持，但现在不可能做到。

ASF 的特定操作系统构建已包含运行我们官方插件的最基本额外功能。 除此之外，这也稍微扩展为大多数基础插件可用的额外依赖项。 因此，不是所有插件都需要担心本机依赖项——只有超越 ASF 与其官方插件功能的插件才需要考虑。 这是额外提供的，因为如果我们需要为我们自己的需求添加额外的本机依赖项，就可以直接把它们与 ASF 一同打包，使您可以更容易地使用它们。 很遗憾，这并不总能满足要求，随着插件变得越来越大、越来越复杂，用到被修剪掉功能的可能性就会增加。 因此，我们通常建议您只为 ASF 的 `generic` 构建提供自定义插件。 您仍然可以手动验证 ASF 的特定操作系统构建是否包含您插件所需的所有功能——但因为您的插件和 ASF 本身都在不断变化，这样的维护过程可能会非常困难。