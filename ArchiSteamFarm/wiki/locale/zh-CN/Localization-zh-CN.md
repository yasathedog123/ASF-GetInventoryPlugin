# 本地化

借助 Crowdin 服务的支持，任何人都可以提供帮助，将 ASF 翻译成世界各地的语言。 关于 Crowdin 的运作细节，请访问 **[Crowdin 简介](https://support.crowdin.com/crowdin-intro)**。

如果您对目前的情况感兴趣，可以访问 **[ASF Crowdin 活动](https://crowdin.com/project/archisteamfarm/activity_stream)**。

---

## 范围

我们的平台支持 ASF 主程序，以及我们一并提供的所有可翻译内容的本地化工作。 这包括 ASF-WebConfigGenerator（配置生成器）、ASF-ui 以及我们的 Wiki。 所有这些项目都可以通过方便的 Crowdin 接口进行翻译。

---

## 注册

如果您愿意帮助 ASF，无论是翻译、评估或者批准翻译，请在我们的 **[Crowdin 项目主页](https://crowdin.com/project/archisteamfarm)**&#8203;注册。 注册过程非常容易并且完全免费！ 在登录之后，您可以选择要参与翻译的语言，然后选择一份 ASF 文本，并且帮助社区的其他人将 ASF 翻译成各种语言！

---

### 翻译

如果您选择的语言仍然有未翻译的文本，您可以立刻开始翻译它们。 我们尝试尽全力保证翻译的灵活性，因此很多文本包含由 ASF 在运行时动态提供的额外变量——这些变量是由花括号扩住的数字，例如 `{0}`。 这一特性使您可以调整 ASF 文本的格式，例如，将 ASF 提供的变量移动到适合您的语言翻译的地方，而不再受限于严格的上下文与格式。 这对于希伯来语等 RTL（从右向左书写）语言来说尤为重要。

例如，您可能遇到这样的文本：

> We have {0} games to idle.

但根据您的语言，也许这样的句式更加合理：

> The number of games to idle is equal to {0}.

或者：

> {0} is the number of games to idle.

这样的灵活性特别为翻译者设计，所以您可以稍微改写 ASF 的句子，使其更适合您的语言，并且将 ASF 提供的数字等信息安排在适合您的翻译的位置（而不是分别翻译各个部分）。 整体的翻译质量因此而得到提升。

---

### 评估

如果一条文本已经有其他人提供翻译，您可以为其投票。 投票的目的是选择最佳的翻译形式，而不是始终保留最早的建议——这进一步提高了整体翻译质量。 您可以为已有的建议投票，或者提交您自己的翻译建议，您提供的建议同样会经过投票这一过程。 最终，翻译结果将会在得票最多的建议，或者该语言的审核员个人选择的翻译中产生（同样也基于您投票的结果）。

**您的翻译文本无需得到批准也可以出现在 ASF 中**。 批准仅仅表示有受我们信任者审核了此内容，即选择最终的翻译版本。 无人审核的、由社区主导的翻译是完全可行的，这种情况下您只需为最佳翻译投票。 只要文本被翻译，就是好事！ 并且，如果您认为目前的翻译很差，您可以随时为更好的翻译投票，或者提交您自己的建议。

---

### 审核

保持翻译的一致性是个好主意，即使这可能会削弱上述的社区评估/投票机制的自由。 这主要是因为一些不算特别糟糕的错误翻译可能会获得很多赞成票，导致即使译者有更好的翻译建议也无法提交。

如果您在 Crowdin 上，或者其他我们可信赖的本地化平台/服务上有参与贡献的经验，我们很高兴为您提供您所贡献语言的审核权限，使您可以审核批准翻译，保持翻译的一致性。 审核并非简单的工作，特别是因为 ASF 经常会涉及技术内容并且很难翻译，但是我们知道它通常需要一份完美的翻译。 因此，如果您可以帮助审核某门语言，**[请联系我们](https://crowdin.com/messages/create/13177432/240376)**，但请注意，您需要在请求中说明您过去的本地化经验，使我们可以验证（例如在 Crowdin 上为 ASF 或者其他任何项目贡献过翻译）。 如果我们私下了解他们，并且他们能够与社区的其他成员合作，最好地以该语言本地化 ASF，我们也可以允许更多高级用户参与初步审核过程。

审校的通用规则：不要急躁、倾听他人、掌控项目、解决问题，确保自己做到更好而不是更差。

---

### 问题

如果您在特定的翻译下遇到了问题，例如，您不知道如何翻译、已批准的翻译不正确、您需要更详细的上下文信息，请在对应的文本下发表留言，并且勾选为 [X] 问题。

**如果您不需要技术/开发方面的说明或者管理员操作，请避免使用问题**。 您可以随意在文本下发表留言讨论翻译相关的内容，但问题仅应该在您需要进一步技术解释或者需要管理员提供帮助时使用，并且它通常会涉及一些甚至不会您所翻译的语言的人员，所以在撰写问题时请始终使用英语（使我们可以理解问题的含义）。

目前有这 4 类问题受到支持：
- 一般问题——所有不符合下述其他类型的问题。 通常，应**尽量避免**这类问题，如果遇到的问题不符合其他情况，很可能它并**不是**一个翻译问题。 但这一选项仍然为所有其他情况保留。
- 当前翻译错误——这类问题**仅**应在当前翻译已被审核员批准的情况下使用，并且您确认它有错误，例如它有拼写错误或者您有一条更好的建议来改进它。 这类问题不能用于社区驱动（投票）的翻译，在这种情况下您应该联系翻译的提供者，让他更正翻译，或者如“评估”一节所述，直接为更好的翻译投票。 我们会删除对翻译的批准，并通知负责相应语言的审核员查看与验证您的评论。
- 缺少上下文信息——如果您不确定您正在翻译 ASF 的哪一部分、文本的上下文是什么、它的作用是什么，那就应该使用这类问题。 这一类型仅应被用于 ASF 开发，表示您不确定应该如何翻译这条文本，需要技术支持。
- 源文本错误——这一问题仅应用于您确定源文本（英语）有错误的情况。 尽管很罕见，但我们并非都是英语母语者，所以如果您对源文本有改进意见，可以随意使用它。 或者，因为这种情况与开发过程直接相关，您也可以使用我们的 **[GitHub Issues](https://github.com/JustArchiNET/ArchiSteamFarm/issues/new/choose)** 来讨论。

---

### 翻译进度

每种语言都有两阶段的完成状态——翻译与审核。

当翻译进度达到 100% 时，这门语言将被视为**翻译完成**。 此时每一条 ASF 使用的字符串都有一条很好的翻译。 然而，这并不意味着没有改进的空间——社区投票随时可用，您仍然可以提供更好的翻译建议，或者为已有翻译投票。 请注意，当我们在开发过程中更改文本或者添加文本时，完整翻译的语言的进度也会降到 100% 以下。 如果您希望在这种情况下收到电子邮件，可以设置相关的 Crowdin 通知。

您选择的语言可能有合适的审核员进行验证翻译并批准最终版本的工作。 这是一条翻译诞生后面对的最后一关，可以进一步改进本地化。

ASF 将会**尽快**应用这门语言，而不需要完整审核批准甚至 100% 翻译。 实际选择的文本通常是当时得票数最多的一个，除非有审核员选择了另一个（罕见）。 因而，您可以在下一个 ASF 版本中看到您的工作成果——我们的自动系统会每天将翻译从 Crowdin 合并回 ASF 仓库。

---

## 缺少语言

默认情况下，ASF 将会启用世界范围内最热门的 30 种语言的翻译工作。 如果您希望增加另一门语言（或者一门已有语言的方言），请&#8203;**[联系我们](https://crowdin.com/messages/create/13177432/240376)**，我们会尽快添加。 我们不希望启用几百种无人翻译的各种语言，这就是我们限制其数量的原因。 如果您想翻译一些未列出的语言，请随时与我们联系，添加另一种语言对我们来说很容易。 只需要在您决定联系我们之前，确保您有真正的意愿与决心将 ASF 翻译成您的语言。

要查看目前完整的 ASF 可翻译语言列表，**[点击这里](https://developer.crowdin.com/language-codes)**。

---

## 复数形式

每种语言都有自己独有的复数规则。 这些规则可以在 **[CLDR](https://unicode-org.github.io/cldr-staging/charts/latest/supplemental/language_plural_rules.html)** 上找到，针对不同的数字和确切的语言条件。

我们尽力为您提供本地化的灵活性，这也尽可能包括了复数规则。 例如，假设我们需要将这条文本翻译为波兰语：

> Released {PLURAL:n|{n} month|{n} months} ago

这里的 `PLURAL` 关键字以特殊方式处理，使您可以提供您语言所支持的全部复数形式。 如果您阅读了 CLDR，您会发现英语仅有两种基数形式——“一个”和“多个”。 正如您在上面所看到的，我们在此定义了两种形式——`{n} month` 与 `{n} months`。

然而，波兰语实际上有四种复数形式——“一个”、“很少”、“很多”和“其他”。 这意味着我们需要定义所有这四种形式才算完成。 我们的本地化工具已经足够智能，可以根据语言规则选择适当的复数形式，因此您只需要在翻译中定义所有可用的形式：

> Wydany {PLURAL:n|{n} miesiąc|{n} miesiące|{n} miesięcy|{n} miesiąca} temu

通过这种方式，我们定义了波兰语中的 4 种复数形式，并且因为我们的本地化库已经知道了确切的规则，现在它可以针对不同的 `{n}` 数字选择正确的复数形式。

定义您的语言中所有复数形式并非总是必要的。 如果有缺少，我们的本地化库将会使用这里最后定义的形式。 定义您的语言中所有复数形式的确很好，但有时剩余的复数形式可能与最后一个相同，在这种情况下没有必要重复它。 在上面的示例中，这种定义是必要的，因为波兰语中“其他”形式的“月”是“miesiąca”，而不是“很多”形式的“miesięcy”。

---

## Wiki

我们的 Crowdin 平台甚至可以让您本地化 Wiki 本身。 这是一个非常强大的工具，因为它使您可以用母语编写整个 ASF 文档，有效地解决了 ASF 本地化进程的最后一个问题。 加上程序和组件部分的翻译，就是完整的本地化。

Wiki 在这方面有些特别，因为它是在线帮助，您无需过于拘泥于原始的句子。 这意味着您希望尽可能自然地用您的语言来传达原始的含义和帮助——无需坚持使用源文本的句式、词汇或标点符号。 只要您仍然保持大致的方向，保留原始文本的帮助信息，您尽可以将整个句子重写为您的语言中更自然的表达方式。

---

### 全局链接

我们的 Crowdin 平台同样允许您调整原始文本以指向新的（本地化的）位置。

ASF 的几乎每个页面上都包含链接与右边栏以便于导航。 最赞的是，您可以编辑所有这些链接，使其指向正确的本地化页面。 您在做这项工作的时候需要更小心，但这是可以做到的。

例如，ASF 的 **[Home](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Home)** 页面包含一条这样的文本：

> If you're a new user, we recommend starting with **[setting up](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up)** guide.

这条文本的原始形式为：

```markdown
If you're a new user, we recommend starting with **[setting up](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up)** guide.
```

在 Crowdin 上，您需要做的第一件事情，是打开编辑器设置，并确保 HTML 标签被设置为“显示”。 如果您决定本地化 Wiki，那么这个选项非常重要。

---

![Crowdin](https://i.imgur.com/YqAxiZ4.png)

---

现在，在翻译过程中，取决于格式，您将会在文本中看到下列形式的 ASF 链接：

* 要与 HTML 标签一起翻译的文本（大部分是文本，句子的一部分是链接）
* 单独翻译文本，而链接包含在 `Hidden texts` -> `Link addresses` 中（罕见，整个文本都是链接，在边栏中最常见——只有审核员可以翻译这部分）

上面的示例是第一种形式（因为其中只有“setting up”是链接），所以在 Crowdin 中会显示成：

---

![Crowdin 2](https://i.imgur.com/Li5RzS3.png)

---

无论是哪种情况，首先您都应该复制源字符串并像往常一样翻译，但要保留完整的 HTML（如果有的话）。 这是一个将其翻译到波兰语的示例：

---

![Crowdin 3](https://i.imgur.com/NpKwfka.png)

---

现在，如果这个链接是一个指向 Wiki 外部的普通链接（例如指向 ASF 的最新版本），您可以保持它不变。 您可以直接保存并前往下一条文本。

然而，如果这个链接**确实**指向 Wiki 内部，如上所述，您可以将其指向新的（本地化的）位置。 您需要小心地将 `-locale` 语言代码添加到 `<a>` 标签的目标 URL 中，例如：

---

![Crowdin 4](https://i.imgur.com/TL8uwmb.png)

---

您需要非常小心，并确保这个 URL 确实存在，因为如果您犯了错误，该链接将会失效。 如果没有问题，现在您就有了一条功能齐全的翻译，所有链接都指向翻译过的（在我们的例子中是 `Setting-up-pl-PL`）页面。

按照上述步骤操作将会正确地把我们的 HTML 转换回 Markdown：

```markdown
Jeśli jesteś nowym użytkownikiem, zalecamy rozpoczęcie od korzystania z **[przewodnika po konfiguracji](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up-pl-PL)**.
```

最终变成实际的 Wiki 文本：

> Jeśli jesteś nowym użytkownikiem, zalecamy rozpoczęcie od korzystania z **[przewodnika po konfiguracji](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up-pl-PL)**.

如果是第二种情况，没有出现 HTML，您可以直接前往 `Hidden texts` -> `Link addresses` 部分。

---

![Crowdin 5](https://i.imgur.com/ZmgavCM.png)

---

在这里，您可以直接将链接修改为新地址，完全不需要考虑 HTML：

---

![Crowdin 6](https://i.imgur.com/maG7kSm.png)

---

### 页内链接

在 Wiki 中，您还能看到指向文档中某一小节的页内链接。 这些链接包含 `#` 字符，表明浏览器应该跳转到该文档的此章节。

现在这种情况较为特殊，因为这些链接基于当前文档中各小节的标题。 对于 URL，我们通常可以将 `-locale` 添加到 URL，并且在任何情况下都可用，但小节标题将因为您或其他人的翻译而产生变化，因此您需要确保它们指向正确的位置。

例如，您会在我们的 **[Configuration](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#introduction)** 章节中找到 `#introduction` 链接：

---

![Crowdin 7](https://i.imgur.com/EEHSPtK.png)

---

因为我们将要把“Introduction”翻译成波兰语的“Wprowadzenie”，我们需要修正这个链接，否则在翻译之后，这个链接就会失效。

---

![Crowdin 8](https://i.imgur.com/JMJegO7.png)

---

这样，我们的页内链接仍然可用，因为它现在指向了我们翻译后的新标题。 您可以采用完全相同的方式修正 HTML 标签中的链接。

---

### 代码块

翻译包含 `<code>` 代码块的句子需要非常小心。 代码块表示不应被翻译的 ASF 代码或者术语。 例如：

> This is especially useful if you have a lot of keys to redeem and you're guaranteed to hit <code>RateLimited</code> status before you're done with your entire batch.

如您所见，`RateLimited` 一词被包含在一个代码块中，表示一个 ASF 内部使用的状态代码，不应该被翻译。 同样地，您不应该翻译其他代码块，例如配置文件的属性名称（例如 `TradingPreferences`）、枚举成员（例如 `UpdateChannel` 中的 `Stable` 和 `Experimental`）等。

然而，这仅仅意味着这些单词本身不能被翻译，您仍然可以在它们旁边添加合适的翻译，例如写在括号中。

> Ta funkcja jest wyjątkowo użyteczna w przypadku aktywacji dużej ilości kluczy i gwarancji napotkania statusu <code>RateLimited</code> (zbyt częstej aktywacji) przed ukończeniem całej partii.

如上所述，我们在 `RateLimited` 旁边添加了“zbyt częstej aktywacji”（意为激活次数过多），以更友好的方式翻译这个状态代码，但同时保留了用户可能在程序其他地方看到的代码本身。 针对类似的情况，您也可以用同样的方式翻译/解释。

如果您认为代码块中有不合适的内容，或者一段普通文本应该被包含在代码块中，请在 Crowdin 上创建适当的&#8203;**[问题](#问题)**&#8203;告知我们。 这句话同时也是一个页内链接的实际例子。

---

## 名人堂

我们向花费大量时间与精力参与 ASF 本地化工作的人致以衷心的感谢。 他们的努力是惊人的，您能够获得完整的本地化体验，包括此 Wiki，主要归功于这些人。 作为答谢，此处列出的所有人都可以提出[**要求**](https://crowdin.com/messages/create/13177432/240376)，获取 **[`MatchActively`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin-zh-CN#matchactively主动匹配)** 功能的免费访问权限。

| 贡献者                                                        | 语言          |
| ---------------------------------------------------------- | ----------- |
| **[Astaroth](https://crowdin.com/profile/astaroth2012)**   | LOLCAT、西班牙语 |
| **[Dead_Sam](https://crowdin.com/profile/Dead_Sam)**       | 葡萄牙语（巴西）    |
| **[deluxghost](https://crowdin.com/profile/deluxghost)**   | 汉语（中国）      |
| **[DragonTaki](https://crowdin.com/profile/dragontaki)**   | 汉语（台湾地区）    |
| **[LittleFreak](https://crowdin.com/profile/littlefreak)** | 德语          |
| **[Ryzhehvost](https://crowdin.com/profile/Ryzhehvost)**   | 俄语、乌克兰语     |
| **[MrBurrBurr](https://crowdin.com/profile/MrBurrBurr)**   | LOLCAT、德语   |
| **[XinxingChen](https://crowdin.com/profile/XinxingChen)** | 汉语（香港特别行政区） |

感谢你们帮助提高 ASF 的本地化质量！