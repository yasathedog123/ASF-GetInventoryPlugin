# 日誌

ASF允許您自訂將在運行時使用的自定義日誌記錄模組。 您可以通過在應用程序的目錄中放入名為` NLog.config `的特殊檔案來完成此操作。 您可以在** [ NLog wiki ](https://github.com/NLog/NLog/wiki/Configuration-file) **上閱讀NLog的完整文檔，除此之外，您也可以在這裡找到一些有用的例子。

---

## 預設日誌

By default, ASF is logging to `ColoredConsole` (standard output) and `File`. `File` logging includes `log.txt` file in program's directory, and `logs` directory for archival purposes.

Using custom NLog config automatically disables default ASF config, your config overrides **completely** default ASF logging, which means that if you want to keep e.g. our `ColoredConsole` target, then you must define it **yourself**. 這不僅允許您添加**額外**日誌記錄對象，而且還可以禁用或修改**預設值**。

如果您要在不進行任何修改的情況下使用預設 ASF 日誌記錄，則無需執行任何操——您也不需要在自訂 `NLog.config`中定義它。 如果不想修改預設 ASF 日誌記錄，請不要使用自訂 `NLog.config`。 但是，作為參考，相當於硬編碼的ASF默認日誌記錄將是：

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" layout="${date:format=yyyy-MM-dd HH\:mm\:ss}|${processname}-${processid}|${level:uppercase=true}|${logger}|${message}${onexception:inner= ${exception:format=toString,Data}}" />
    <target xsi:type="File" name="File" archiveFileName="${currentdir}/logs/log.{#}.txt" archiveNumbering="Rolling" archiveOldFileOnStartup="true" cleanupFileName="false" concurrentWrites="false" deleteOldFileOnStartup="true" fileName="${currentdir}/log.txt" layout="${date:format=yyyy-MM-dd HH\:mm\:ss}|${processname}-${processid}|${level:uppercase=true}|${logger}|${message}${onexception:inner= ${exception:format=toString,Data}}" maxArchiveFiles="10" />

    <!-- Below becomes active when ASF's IPC interface is started -->
    <target type="History" name="History" layout="${date:format=yyyy-MM-dd HH\:mm\:ss}|${processname}-${processid}|${level:uppercase=true}|${logger}|${message}${onexception:inner= ${exception:format=toString,Data}}" maxCount="20" />
  </targets>

  <rules>
    <!-- The following entries specify ASP.NET (IPC) logging, we declare those so our last Debug catch-all doesn't include ASP.NET logs by default -->
    <logger name="Microsoft.*" finalMinLevel="Warn" writeTo="ColoredConsole" />
    <logger name="Microsoft.Hosting.Lifetime" finalMinLevel="Info" writeTo="ColoredConsole" />
    <logger name="System.*" finalMinLevel="Warn" writeTo="ColoredConsole" />

    <logger name="*" minlevel="Debug" writeTo="ColoredConsole" />

    <!-- The following entries specify ASP.NET (IPC) logging, we declare those so our last Debug catch-all doesn't include ASP.NET logs by default -->
    <logger name="Microsoft.*" finalMinLevel="Warn" writeTo="File" />
    <logger name="Microsoft.Hosting.Lifetime" finalMinLevel="Info" writeTo="File" />
    <logger name="System.*" finalMinLevel="Warn" writeTo="File" />

    <logger name="*" minlevel="Debug" writeTo="File" />

    <!-- Below becomes active when ASF's IPC interface is enabled -->
    <!-- The following entries specify ASP.NET (IPC) logging, we declare those so our last Debug catch-all doesn't include ASP.NET logs by default -->
    <logger name="Microsoft.*" finalMinLevel="Warn" writeTo="History" />
    <logger name="Microsoft.Hosting.Lifetime" finalMinLevel="Info" writeTo="History" />
    <logger name="System.*" finalMinLevel="Warn" writeTo="History" />

    <logger name="*" minlevel="Debug" writeTo="History" />
  </rules>
</nlog>
```

---

## ASF集成

ASF包含一些很好的代碼技巧，可以增強與NLog的集成，使您可以更輕鬆地捕獲特定的消息。

NLog-specific `${logger}` variable will always distinguish the source of the message - it will be either `BotName` of one of your bots, or `ASF` if message comes from ASF process directly. This way you can easily catch messages considering specific bot(s), or ASF process (only), instead of all of them, based on the name of the logger.

ASF tries to mark messages appropriately based on NLog-provided logging levels, which makes it possible for you to catch only specific messages from specific log levels instead of all of them. 當然，特定消息的日誌記錄級別無法自訂，因為它是ASF硬編碼決定給定消息的嚴重程度，但您確實可以出於個人喜好使ASF捕獲更少/更多消息。

ASF在` Trace `日誌級別上記錄額外信息，例如用戶/聊天消息。 ASF日誌預設僅記錄` Debug `級別及以上信息，它隱藏了額外信息，因為大多數用戶不需要這些信息，以及包含可能更重要的消息的雜亂輸出。 但是，您可以通過重新啟用` Trace `日誌記錄級別來使用該信息，特別是結合僅記錄您選擇的一個特定機械人，以及您感興趣的特定事件。

通常，ASF會盡可能簡單方便地記錄您想要的消息，而不是強迫您通過第三方工具（如` grep `等）手動過濾它。 只需按照下面的說明正確配置NLog，您就可以使用自訂目標（如整個數據庫）指定非常複雜的日誌記錄規則。

關於版本控制——在ASF發佈時，ASF嘗試始終附帶最新版本的NLog，可在** [ NuGet ](https://www.nuget.org/packages/NLog)**上找到 。 It should not be a problem to use any feature you can find on NLog wiki in ASF - just make sure you're also using up-to-date ASF.

作為ASF集成的一部分，ASF還包括對其他ASF NLog日誌記錄目標的支援，這將在下面解釋。

---

## 範例

千里之行始於足下。 舉個簡單的例子，僅使用** [ ColoredConsole ](https://github.com/nlog/nlog/wiki/ColoredConsole-target) **目標。 我們的初始` NLog.config `將如下所示：

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

The explanation of above config is rather simple - we define one **logging target**, which is `ColoredConsole`, then we redirect **all loggers** (`*`) of level `Debug` and higher to `ColoredConsole` target we defined earlier. That's it.

If you start ASF with above `NLog.config` now, only `ColoredConsole` target will be active, and ASF won't write to `File`, regardless of hardcoded ASF NLog configuration.

Now let's say that we don't like default format of `${longdate}|${level:uppercase=true}|${logger}|${message}` and we want to log message only. We can do so by modifying **[Layout](https://github.com/nlog/nlog/wiki/Layouts)** of our target.

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

If you launch ASF now, you'll notice that date, level and logger name disappeared - leaving you only with ASF messages in format of `Function() Message`.

We can also modify the config to log to more than one target. Let's log to `ColoredConsole` and **[`File`](https://github.com/nlog/nlog/wiki/File-target)** at the same time.

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

And done, we'll now log everything to `ColoredConsole` and `File`. Did you notice that you can also specify custom `fileName` and extra options?

Finally, ASF uses various log levels, to make it easier for you to understand what is going on. We can use that information for modifying severity logging. Let's say that we want to log everything (`Trace`) to `File`, but only `Warning` and above **[log level](https://github.com/NLog/NLog/wiki/Configuration-file#log-levels)** to the `ColoredConsole`. We can achieve that by modifying our `rules`:

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

That's it, now our `ColoredConsole` will show only warnings and above, while still logging everything to `File`. You can further tweak it to log e.g. only `Info` and below, and so on.

Lastly, let's do something a bit more advanced and log all messages to file, but only from bot named `LogBot`.

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

You can see how we used ASF integration above and easily distinguished source of the message based on `${logger}` property.

---

## 進階功能

上面的簡單示例向您展示了自訂自己的ASF日誌記錄規則是多麼容易。 You can use NLog for various different things, including complex targets (such as keeping logs in `Database`), logs rotation (such as removing old `File` logs), using custom `Layout`s, declaring your own `<when>` logging filters and much more. I encourage you to read through entire **[NLog documentation](https://github.com/nlog/nlog/wiki/Configuration-file)** to learn about every option that is available to you, allowing you to fine-tune ASF logging module in the way you want. It's a really powerful tool and customizing ASF logging was never easier.

---

## 限制

ASF will temporarily disable **all** rules that include `ColoredConsole` or `Console` targets when expecting user input. Therefore, if you want to keep logging for other targets even when ASF expects user input, you should define those targets with their own rules, as shown in examples above, instead of putting many targets in `writeTo` of the same rule (unless this is your wanted behaviour). Temporary disable of console targets is done in order to keep console clean when waiting for user input.

---

## Chat logging

ASF includes extended support for chat logging by not only recording all received/sent messages on `Trace` logging level, but also exposing extra info related to them in **[event properties](https://github.com/NLog/NLog/wiki/EventProperties-Layout-Renderer)**. This is because we need to handle chat messages as commands anyway, so it doesn't cost us anything to log those events in order to make it possible for you to add extra logic (such as making ASF your personal Steam chatting archive).

### Event properties

| 名稱          | 描述                                                                                                                                                                                                           |
| ----------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| Echo        | `bool` type. This is set to `true` when message is being sent from us to the recipient, and `false` otherwise.                                                                                               |
| Message     | `string` type. This is the actual sent/received message.                                                                                                                                                     |
| ChatGroupID | `ulong` type. This is the ID of the group chat for sent/received messages. Will be `0` when no group chat is used for transmitting this message.                                                             |
| ChatID      | `ulong` type. This is the ID of the `ChatGroupID` channel for sent/received messages. Will be `0` when no group chat is used for transmitting this message.                                                  |
| SteamID     | `ulong` type. This is the ID of the Steam user for sent/received messages. Can be `0` when no particular user is involved in the message transmission (e.g. when it's us sending a message to a group chat). |

### 範例

This example is based on our `ColoredConsole` basic example above. Before trying to understand it, I strongly recommend to take a look **[above](#examples)** in order to learn about basics of NLog logging firstly.

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

We've started from our basic `ColoredConsole` example and extended it further. First and foremost, we've prepared a permanent chat log file per each group channel and Steam user - this is possible thanks to extra properties that ASF exposes to us in a fancy way. We've also decided to go with a custom layout that writes only current date, the message, sent/received info and Steam user itself. Lastly, we've enabled our chat logging rule only for `Trace` level, only for our `MainAccount` bot and only for functions related to chat logging (`OnIncoming*` which is used for receiving messages and echos, and `SendMessage*` for ASF messages sending).

The example above will generate `0-0-76561198069026042.txt` file when talking with **[ArchiBot](https://steamcommunity.com/profiles/76561198069026042)**:

```text
2018-07-26 01:38:38 how are you doing? -> 76561198069026042
2018-07-26 01:38:38 I'm doing great, how about you? <- 76561198069026042
```

Of course this is just a working example with a few nice layout tricks showed in practical manner. You can further expand this idea to your own needs, such as extra filtering, custom order, personal layout, recording only received messages and so on.

---

## ASF targets

In addition to standard NLog logging targets (such as `ColoredConsole` and `File` explained above), you can also use custom ASF logging targets.

For maximum completeness, definition of ASF targets will follow NLog documentation convention.

---

### SteamTarget

As you can guess, this target uses Steam chat messages for logging ASF messages. You can configure it to use either a group chat, or private chat. In addition to specifying a Steam target for your messages, you can also specify `botName` of the bot that is supposed to send those.

Supported in all environments used by ASF.

---

#### Configuration Syntax
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

Read more about using the [Configuration File](https://github.com/NLog/NLog/wiki/Configuration-file).

---

#### Parameters

##### General Options
_name_ - Name of the target.

---

##### 佈局選項
_layout_ - Text to be rendered. [Layout](https://github.com/NLog/NLog/wiki/Layouts) Required. Default: `${level:uppercase=true}|${logger}|${message}`

---

##### SteamTarget Options

_chatGroupID_ - ID of the group chat declared as 64-bit long unsigned integer. Not required. Defaults to `0` which will disable group chat functionality and use private chat instead. When enabled (set to non-zero value), `steamID` property below acts as `chatID` and specifies ID of the channel in this `chatGroupID` that the bot should send messages to.

_steamID_ - SteamID declared as 64-bit long unsigned integer of target Steam user (like `SteamOwnerID`), or target `chatID` (when `chatGroupID` is set). Required. Defaults to `0` which disables logging target entirely.

_botName_ - Name of the bot (as it's recognized by ASF, case-sensitive) that will be sending messages to `steamID` declared above. Not required. Defaults to `null` which will automatically select **any** currently connected bot. It's recommended to set this value appropriately, as `SteamTarget` does not take into account many Steam limitations, such as the fact that you must have `steamID` of the target on your friendlist. This variable is defined as [layout](https://github.com/NLog/NLog/wiki/Layouts) type, therefore you can use special syntax in it, such as `${logger}` in order to use the bot that generated the message.

---

#### SteamTarget Examples

In order to write all messages of `Debug` level and above, from bot named `MyBot` to steamID of `76561198006963719`, you should use `NLog.config` similar to below:

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

**Notice:** Our `SteamTarget` is custom target, so you should make sure that you're declaring it as `type="Steam"`, NOT `xsi:type="Steam"`, as xsi is reserved for official targets supported by NLog.

When you launch ASF with `NLog.config` similar to above, `MyBot` will start messaging `76561198006963719` Steam user with all usual ASF log messages. Keep in mind that `MyBot` must be connected in order to send messages, so all initial ASF messages that happened before our bot could connect to Steam network, won't be forwarded.

Of course, `SteamTarget` has all typical functions that you could expect from generic `TargetWithLayout`, so you can use it in conjunction with e.g. custom layouts, names or advanced logging rules. The example above is only the most basic one.

---

#### Screenshots

![截圖](https://i.imgur.com/5juKHMt.png)

---

### HistoryTarget

This target is used internally by ASF for providing fixed-size logging history in `/Api/NLog` endpoint of **[ASF API](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-api)** that can be afterwards consumed by ASF-ui and other tools. In general you should define this target only if you're already using custom NLog config for other customizations and you also want the log to be exposed in ASF API, e.g. for ASF-ui. It can also be declared when you'd want to modify default layout or `maxCount` of saved messages.

Supported in all environments used by ASF.

---

#### Configuration Syntax
```xml
<targets>
  <target type="History"
          name="String"
          layout="Layout"
          maxCount="Byte" />
</targets>
```

Read more about using the [Configuration File](https://github.com/NLog/NLog/wiki/Configuration-file).

---

#### Parameters

##### General Options
_name_ - Name of the target.

---

##### 佈局選項
_layout_ - Text to be rendered. [Layout](https://github.com/NLog/NLog/wiki/Layouts) Required. Default: `${date:format=yyyy-MM-dd HH\:mm\:ss}|${processname}-${processid}|${level:uppercase=true}|${logger}|${message}${onexception:inner= ${exception:format=toString,Data}}`

---

##### 歷史目標選項

_maxCount_ - Maximum amount of stored logs for on-demand history. Not required. Defaults to `20` which is a good balance for providing initial history, while still keeping in mind memory usage that comes out of storage requirements. Must be greater than `0`.

---

## 注意事項

Be careful when you decide to combine `Debug` logging level or below in your `SteamTarget` with `steamID` that is taking part in the ASF process. This can lead to potential `StackOverflowException` because you'll create an infinite loop of ASF receiving given message, then logging it through Steam, resulting in another message that needs to be logged. Currently the only possibility for it to happen is to log `Trace` level (where ASF records its own chat messages), or `Debug` level while also running ASF in `Debug` mode (where ASF records all Steam packets).

In short, if your `steamID` is taking part in the same ASF process, then the `minlevel` logging level of your `SteamTarget` should be `Info` (or `Debug` if you're also not running ASF in `Debug` mode) and above. Alternatively you can define your own `<when>` logging filters in order to avoid infinite logging loop, if modifying level is not appropriate for your case. This caveat also applies to group chats.