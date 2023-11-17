# 日志

ASF 允许您自定义运行时使用的日志模块。 您可以将名为 `NLog.config` 的配置文件放到应用目录中来实现。 您可以阅读完整的 **[NLog 文档](https://github.com/NLog/NLog/wiki/Configuration-file)**，但我们也会在这里提供一些实用的示例。

---

## 默认日志

默认情况下，ASF 会向 `ColoredConsole`（彩色控制台标准输出）和 `File`（文件）两个目标记录日志。 `File` 目标指程序文件夹内的 `log.txt` 文件以及被归档的 `logs` 文件夹。

使用自定义 NLog 配置文件会导致 ASF 的默认日志配置被禁用，您的配置文件将会**完全**覆盖默认的 ASF 日志配置，这意味着如果您想要保留 `ColoredConsole` 目标，就必须**自己**重新定义一个。 您不仅能够添加**额外**的日志目标，还可以禁用或修改**默认的**目标。

如果您想要使用默认的 ASF 日志模块，不做任何修改，就什么也不需要做——也不需要在自定义的 `NLog.config` 中进行定义。 如果不希望修改 ASF 默认的日志模块，就不要使用自定义 `NLog.config`。 但作为参考，ASF 默认的日志设置等价于：

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" layout="${date:format=yyyy-MM-dd HH\:mm\:ss}|${processname}-${processid}|${level:uppercase=true}|${logger}|${message}${onexception:inner= ${exception:format=toString,Data}}" />
    <target xsi:type="File" name="File" archiveFileName="${currentdir}/logs/log.{#}.txt" archiveNumbering="Rolling" archiveOldFileOnStartup="true" cleanupFileName="false" concurrentWrites="false" deleteOldFileOnStartup="true" fileName="${currentdir}/log.txt" layout="${date:format=yyyy-MM-dd HH\:mm\:ss}|${processname}-${processid}|${level:uppercase=true}|${logger}|${message}${onexception:inner= ${exception:format=toString,Data}}" maxArchiveFiles="10" />

    <!-- 下列条目仅在 ASF 的 IPC 接口启用时激活 -->
    <target type="History" name="History" layout="${date:format=yyyy-MM-dd HH\:mm\:ss}|${processname}-${processid}|${level:uppercase=true}|${logger}|${message}${onexception:inner= ${exception:format=toString,Data}}" maxCount="20" />
  </targets>

  <rules>
    <!-- 下列条目指定了 ASP.NET（IPC）的日志，我们声明它们是为了使最顶层的调试捕获默认不包含 ASP.NET 部分 -->
    <logger name="Microsoft*" finalMinLevel="Warn" writeTo="ColoredConsole" />
    <logger name="Microsoft.Hosting.Lifetime*" finalMinLevel="Info" writeTo="ColoredConsole" />
    <logger name="System*" finalMinLevel="Warn" writeTo="ColoredConsole" />

    <logger name="*" minlevel="Debug" writeTo="ColoredConsole" />

    <!-- 下列条目指定了 ASP.NET（IPC）的日志，我们声明它们是为了使最顶层的调试捕获默认不包含 ASP.NET 部分 -->
    <logger name="Microsoft*" finalMinLevel="Warn" writeTo="File" />
    <logger name="Microsoft.Hosting.Lifetime*" finalMinLevel="Info" writeTo="File" />
    <logger name="System*" finalMinLevel="Warn" writeTo="File" />

    <logger name="*" minlevel="Debug" writeTo="File" />

    <!-- 下列条目仅在 ASF 的 IPC 接口启用时激活 -->
    <!-- 下列条目指定了 ASP.NET（IPC）的日志，我们声明它们是为了使最顶层的调试捕获默认不包含 ASP.NET 部分 -->
    <logger name="Microsoft*" finalMinLevel="Warn" writeTo="History" />
    <logger name="Microsoft.Hosting.Lifetime*" finalMinLevel="Info" writeTo="History" />
    <logger name="System*" finalMinLevel="Warn" writeTo="History" />

    <logger name="*" minlevel="Debug" writeTo="History" />
  </rules>
</nlog>
```

---

## ASF 集成

ASF 使用了一些不错的代码技巧增强了 NLog 的集成，使您能够轻松捕获特定的信息。

NLog 特定的 `${logger}` 变量始终用于标明消息的来源——可以是某个机器人的 `BotName`，或者是 `ASF` 表明消息直接来自于 ASF 进程。 这样，根据 Logger（日志记录器）的名字，您可以仅捕获特定机器人或者 ASF 进程的消息，而不是捕获全部。

ASF 会尝试以 NLog 提供的适当的日志级别标记消息，这样您可以只捕获特定日志级别的消息，而不是全部。 当然，特定消息的日志级别无法被自定义，因为这是 ASF 硬编码的决策，指示了给定消息的严重程度，但您可以定义 ASF 的沉默程度，使其符合您的需求。

ASF 也会记录额外的信息，例如 `Trace` 日志级别就包含用户的聊天消息。 默认的 ASF 最低日志级别是 `Debug`，也就是隐藏了这些额外的信息，因为对于大多数用户来说没有必要显示，并且这些杂项消息可能会掩盖掉重要的消息。 但您可以重新启用 `Trace` 日志级别来利用这些消息，特别是您需要仅仅记录某个特定机器人及其相关事件的时候。

一般情况下，ASF 会尽力为您提供方便，只记录您需要的消息，而不是让您通过 `grep` 等第三方工具来手动筛选。 只需要按照下文的说明正确配置 NLog，您就应该能够使用自定义目标（如整个数据库）指定非常复杂的日志规则。

关于版本——ASF 始终尝试在发布时提供当时 **[NuGet](https://www.nuget.org/packages/NLog)** 上最新版本的 NLog。 您应该能够使用所有 NLog 文档中的特性——只需要确保您的 ASF 是最新版。

作为 ASF 集成的一部分，ASF 也支持一些额外的 ASF NLog 日志目标，下文将对此进行说明。

---

## 示例

让我们从简单的情况开始。 我们将仅使用 **[ColoredConsole](https://github.com/nlog/nlog/wiki/ColoredConsole-target)** 目标。 我们的初始 `NLog.config` 看起来像这样：

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" />
  </targets>

  <rules>
    <logger name="*" minlevel="Debug" writeTo="ColoredConsole" />
  </rules>
</nlog>
```

上述配置的解释相当简单——我们定义了一个**日志目标** `ColoredConsole`，然后将 `Debug` 及更高级别的**所有 Logger**（`*`）重定向到之前定义的 `ColoredConsole` 目标。 这就完成了。

如果您以上述 `NLog.config` 启动 ASF，仅有 `ColoredConsole` 目标会启用，并且 ASF 将不会把日志写入文件（`File`），ASF 硬编码的 NLog 配置已经被忽略。

假设我们不喜欢默认的日志格式 `${longdate}|${level:uppercase=true}|${logger}|${message}`，我们只打算保留消息内容。 可以修改目标的&#8203;**[布局](https://github.com/nlog/nlog/wiki/Layouts)**&#8203;做到这一点。

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" layout="${message}" />
  </targets>

  <rules>
    <logger name="*" minlevel="Debug" writeTo="ColoredConsole" />
  </rules>
</nlog>
```

如果您现在启动 ASF，就会注意到日期、日志级别和 Logger 名称都已经消失了——只剩下 `Function() Message` 格式的消息内容。

我们还可以修改配置文件，使日志记录到多个目标。 现在我们将日志同时记录到 `ColoredConsole` 和 **[File](https://github.com/nlog/nlog/wiki/File-target)**。

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" />
    <target xsi:type="File" name="File" fileName="${currentdir}/NLog.txt" deleteOldFileOnStartup="true" />
  </targets>

  <rules>
    <logger name="*" minlevel="Debug" writeTo="ColoredConsole" />
    <logger name="*" minlevel="Debug" writeTo="File" />
  </rules>
</nlog>
```

现在，我们已经将一切都记录到 `ColoredConsole` 和 `File` 目标了。 您注意到您还可以指定自定义文件名 `fileName` 和其他额外选项了吗？

最后，ASF 使用各种日志级别使您能够轻松理解发生的事情。 我们可以使用此信息修改日志的严重性。 例如，我们希望将所有消息（`Trace`）记录到文件 `File`，但 `ColoredConsole` 只显示 `Warning` 及更高的&#8203;**[日志级别](https://github.com/NLog/NLog/wiki/Configuration-file#log-levels)**。 我们可以修改 `rules` 来做到这一点：

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" />
    <target xsi:type="File" name="File" fileName="${currentdir}/NLog.txt" deleteOldFileOnStartup="true" />
  </targets>

  <rules>
    <logger name="*" minlevel="Warn" writeTo="ColoredConsole" />
    <logger name="*" minlevel="Trace" writeTo="File" />
  </rules>
</nlog>
```

现在 `ColoredConsole` 将只会显示警告和更严重的消息，但仍然将所有日志发送到 `File`。 您还可以对其进行进一步调整，例如只记录 `Info` 及更低级别等等。

最后，我们可以做一些更高级的操作，将所有来自机器人 `LogBot` 的消息记录到文件。

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" />
    <target xsi:type="File" name="LogBotFile" fileName="${currentdir}/LogBot.txt" deleteOldFileOnStartup="true" />
  </targets>

  <rules>
    <logger name="*" minlevel="Debug" writeTo="ColoredConsole" />
    <logger name="LogBot" minlevel="Trace" writeTo="LogBotFile" />
  </rules>
</nlog>
```

您可以在上面看到我们是如何利用 ASF 集成，根据 `${logger}` 属性轻松辨明消息来源的。

---

## 高级用法

上面的示例非常简单，仅仅向您展示了定义与 ASF 集成的自定义日志记录规则是多么容易。 您可以使用 NLog 来处理各种不同的事情，包括记录到复杂目标（例如将日志保存到数据库 `Database` 中）、日志轮替（例如移除过期的 `File` 日志）、使用自定义 `Layout` 布局、声明您自己的 `<when>` 日志过滤器等等。 我建议您通读 **[NLog 文档](https://github.com/nlog/nlog/wiki/Configuration-file)**&#8203;全文，了解每一个可用的选项，使您能以所需的方式调整 ASF 日志模块。 这是一个非常强大的工具，自定义 ASF 日志从未如此简单。

---

## 限制

ASF 会在需要用户输入时暂时禁用包括 `ColoredConsole` 或 `Console` 目标的**所有**规则。 因此，如果您希望在 ASF 等待用户输入时能够继续记录到其他目标，就应该为这些目标编写独立的规则，如上例所示，而不是将很多目标都写在同一个规则的 `writeTo` 中（除非这就是您需要的行为）。 临时禁用控制台目标是为了在等待用户输入时保持控制台的清洁。

---

## 聊天日志

ASF 包括了对聊天记录的扩展支持，不仅在 `Trace` 日志级别中记录了所有收到/发出的消息，还在&#8203;**[事件属性](https://github.com/NLog/NLog/wiki/EventProperties-Layout-Renderer)**&#8203;中暴露了与它们相关的额外信息。 因为我们无论如何都需要将聊天消息作为命令来处理，因此记录这些事件并不会增加任何成本，但您可以因此添加额外的逻辑（例如将 ASF 作为您的个人 Steam 聊天记录存档）。

### 事件属性

| 名称          | 描述                                                                        |
| ----------- | ------------------------------------------------------------------------- |
| Echo        | `bool` 类型。 当消息是由我们发给接受者时为 `true`，否则为 `false`。                             |
| Message     | `string` 类型。 发送/接收的实际消息内容。                                                |
| ChatGroupID | `ulong` 类型。 发送/接收消息的群组 ID。 如果该消息并非通过群组聊天发送则为 `0`。                         |
| ChatID      | `ulong` 类型。 发送/接收消息的频道 `ChatGroupID`。 如果该消息并非通过群组聊天发送则为 `0`。              |
| SteamID     | `ulong` 类型。 发送/接收消息的 Steam 用户 ID。 当没有特定用户参与该消息的传输时（例如我们向群组聊天发消息），可以为 `0`。 |

### 示例

这个示例基于上述的 `ColoredConsole` 基本示例。 在理解它之前，我强烈建议您先阅读&#8203;**[上文](#示例)**，了解 NLog 日志的基础。

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" />
    <target xsi:type="File" name="ChatLogFile" fileName="${currentdir}/${event-properties:item=ChatGroupID}-${event-properties:item=ChatID}${when:when='${event-properties:item=ChatGroupID}' == 0:inner=-${event-properties:item=SteamID}}.txt" layout="${date:format=yyyy-MM-dd HH\:mm\:ss} ${event-properties:item=Message} ${when:when='${event-properties:item=Echo}' == true:inner=-&gt;:else=&lt;-} ${event-properties:item=SteamID}" />
  </targets>

  <rules>
    <logger name="*" minlevel="Debug" writeTo="ColoredConsole" />
    <logger name="MainAccount" level="Trace" writeTo="ChatLogFile">
      <filters defaultAction="Log">
        <when condition="not starts-with('${message}','OnIncoming') and not starts-with('${message}','SendMessage')" action="Ignore" />
      </filters>
    </logger>
  </rules>
</nlog>
```

我们以基本的 `ColoredConsole` 为例，并将在之后对其进行扩展。 首先，我们为每个群组频道和 Steam 用户准备了一个永久的聊天记录文件——这要得益于 ASF 向我们暴露的额外属性。 我们还决定采用一种自定义布局，只写入当前日期、消息内容、发送/接收信息和 Steam 用户本身。 最后，我们启用的聊天记录规则仅仅适用于 `Trace` 日志等级、`MainAccount` 机器人帐户、与聊天记录相关的函数（用于接收消息的 `OnIncoming*` 和用于发送消息的 `SendMessage*`）。

上述示例将会在与 **[ArchiBot](https://steamcommunity.com/profiles/76561198069026042)** 聊天时生成 `0-0-76561198069026042.txt` 文件：

```text
2018-07-26 01:38:38 how are you doing? -> 76561198069026042
2018-07-26 01:38:38 I'm doing great, how about you? <- 76561198069026042
```

当然，这只是一个能用的示例，以实践的方式展示了一些不错的布局技巧。 您可以根据自己的需要对其进一步扩展，例如额外过滤器、自定义顺序、自定义布局、仅记录接收的消息等等。

---

## ASF 目标

除了标准的 NLog 目标（例如上述的 `ColoredConsole` 和 `File`），您还可以使用自定义 ASF 日志目标。

为了最大程度的完整性，ASF 目标的定义将遵循 NLog 文档约定。

---

### SteamTarget

您可以猜到，此目标以 Steam 聊天消息来记录 ASF 日志。 您可以将其配置为使用群组或私人聊天。 除了为消息指定 Steam 目标以外，您也可以指定发送这些消息的机器人名称 `botName`。

支持所有 ASF 使用的环境。

---

#### 配置语法
```xml
<targets>
  <target type="Steam"
          name="String"
          layout="Layout"
          chatGroupID="Ulong"
          steamID="Ulong"
          botName="Layout" />
</targets>
```

详见&#8203;[配置文件](https://github.com/NLog/NLog/wiki/Configuration-file)。

---

#### 参数

##### 一般选项
_name_——目标的名称。

---

##### 布局选项
_layout_——要呈现的文本。 要求为 [Layout](https://github.com/NLog/NLog/wiki/Layouts)。 默认值：`${level:uppercase=true}|${logger}|${message}`

---

##### SteamTarget 选项

_chatGroupID_——以 64 位无符号长整型数字声明的群组聊天 ID。 可选。 默认为 `0`，这将禁用群组聊天功能，而是发送到私人聊天。 启用后（设置为非零值），下面的 `steamID` 将会表现为 `chatID`，并且机器人将会向指定的 `chatGroupID` 发送消息。

_steamID_——以 64 位无符号长整型数字声明的 SteamID，指定目标 Steam 用户（类似 `SteamOwnerID`），或者目标 `chatID`（如果设置了 `chatGroupID`）。 必填。 默认为 `0`，这将完全禁用该日志目标。

_botName_——机器人的名称（供 ASF 识别，区分大小写），该机器人将会向之前声明的 `steamID` 发送消息。 可选。 默认为 `null`，这将会使 ASF 自动选择当前已连接的**任意**机器人。 建议为此选项设置合适的值，因为 `SteamTarget` 没有考虑很多 Steam 帐户限制，例如实际上目标的 `steamID` 必须在您的好友列表中。 此变量为 [Layout](https://github.com/NLog/NLog/wiki/Layouts) 类型，因此您可以使用特殊的语法，例如使用 `${logger}` 来表示生成当前消息的机器人。

---

#### SteamTarget 示例

假设需要机器人 `MyBot` 将所有 `Debug` 及更高级别的消息发送到 SteamID 为 `76561198006963719` 的用户，您的 `NLog.config` 应该类似于：

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target type="Steam" name="Steam" steamID="76561198006963719" botName="MyBot" />
  </targets>

  <rules>
    <logger name="*" minlevel="Debug" writeTo="Steam" />
  </rules>
</nlog>
```

**注意：**&#8203;我们的 `SteamTarget` 是自定义目标，所以您应该使用 `type="Steam"` 而不是 `xsi:type="Steam"` 来声明，因为 xsi 是留给 NLog 官方支持的目标使用的。

当您以类似上述 `NLog.config` 启动 ASF 时，`MyBot` 将会开始向 Steam 用户 `76561198006963719` 发送所有平常的 ASF 日志。 请注意，`MyBot` 必须已连接才能发送消息，所以在机器人连接到 Steam 之前的 ASF 初始化消息将无法被转发。

当然，`SteamTarget` 支持所有通用 `TargetWithLayout` 支持的一般功能，所以您可以为它指定自定义布局和名称，或者配合高级日志规则使用。 上面的例子仅仅是基础。

---

#### 屏幕截图

![屏幕截图](https://i.imgur.com/5juKHMt.png)

---

### HistoryTarget

这个目标在 ASF 内部用于为 **[ASF API](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-zh-CN#asf-api)** 的 `/Api/NLog` 端点提供固定大小的日志历史。ASF-ui 和其他工具可能会在之后用到它。 通常，只有在您已经使用自定义 NLog 配置定义了其他日志规则，并且希望将日志暴露给 ASF API（如 ASF-ui）的情况下才需要定义此目标。 或者当您希望修改默认的布局或者历史消息数 `maxCount` 时也可以声明此目标。

支持所有 ASF 使用的环境。

---

#### 配置语法
```xml
<targets>
  <target type="History"
          name="String"
          layout="Layout"
          maxCount="Byte" />
</targets>
```

详见&#8203;[配置文件](https://github.com/NLog/NLog/wiki/Configuration-file)。

---

#### 参数

##### 一般选项
_name_——目标的名称。

---

##### 布局选项
_layout_——要呈现的文本。 要求为 [Layout](https://github.com/NLog/NLog/wiki/Layouts)。 默认值：`${date:format=yyyy-MM-dd HH\:mm\:ss}|${processname}-${processid}|${level:uppercase=true}|${logger}|${message}${onexception:inner= ${exception:format=toString,Data}}`

---

##### HistoryTarget 选项

_maxCount_——日志历史记录的最大存储量。 可选。 默认为 `20`，这是一个合适的初始历史记录条数，同时也考虑到了存储日志所需的内存用量。 必须大于 `0`。

---

## 警告

当您决定在 `SteamTarget` 中向与 ASF 进程有关的 `steamID` 发送 `Debug` 及更低级别的日志时，应该格外小心。 这可能会导致潜在的 `StackOverflowException` 异常，因为您将会创建一个使 ASF 无限接收给定消息的死循环，然后通过 Steam 将其发送出去，导致产生了另一条需要被记录的消息。 目前，只有在您记录 `Trace` 级别的日志（ASF 会在此记录自己的聊天消息），或者在 `Debug` 模式下运行 ASF 时记录 `Debug` 级别的日志（ASF 会在此时记录所有 Steam 数据包）时才会发生这种情况。

简而言之，如果您的 `steamID` 属于同一个 ASF 进程，则 `SteamTarget` 的 `minlevel` 应为 `Info`（如果 ASF 没有运行于 `Debug` 模式，则是 `Debug`）或更高。 或者，如果修改日志级别不符合您的需求，您也可以定义自己的 `<when>` 日志筛选器，以避免日志死循环。 这个警告也适用于群组聊天。