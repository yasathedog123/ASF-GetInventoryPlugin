# Журналирование

ASF позволяет вам настроить свой собственный модуль журналирования, который будет использоваться в процессе работы. Вы можете сделать это добавив специальный файл с именем `NLog.config` в папку приложения. Полную документацию по NLog вы можете прочесть в **[NLog wiki](https://github.com/NLog/NLog/wiki/Configuration-file)**, но в дополнение к этому вы можете найти некоторые полезные примеры в этой статье.

---

## Журналирование по умолчанию

По умолчанию ASF сохраняет журнал в `ColoredConsole` (снандартный поток вывода) и в `File`. Журналирование в `File` включает в себя файл `log.txt` в папке с программой, и подпапку `logs` для архивирования.

Использования пользовательской конфигурации NLog автоматически отключает конфигурацию, используемую ASF по умолчанию, ваша конфигурация **полностью** заменяет журналирование ASF по умолчанию, а это значит что если вы хотите сохранить, например, нашу цель журналирования `ColoredConsole`, вы должны задать её **самостоятельно**. Это позволяет не только доабавлять **дополнительные** цели журналирования, но и отключать или модифицировать **используемые по умолчанию**.

Если вы хотите использовать журналирования ASF по умолчанию, без каких-либо модификаций, вам не надо ничего делать - вам даже не надо задавать их в пользовательском `NLog.config`. Не используйте файл `NLog.config` если вы не собираетесь модифицировать журналирование ASF по умолчанию. Однако для справок, эквивалент заданных в коде умолчаний журналирования ASF будет таким:

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

## Интеграция ASF

ASF имеет некоторые уловки в коде, которые позволяют улучшить интеграцию с NLog, позволяя вам гораздо проще отлавливать нужные вам сообщения.

Специфичная для NLog переменная `${logger}` всегда позволяет определить источник сообщения - это будет либо `BotName` одного из ваших ботов, или `ASF` если это сообщение напрямую от процесса ASF. Таким образом вы можете легко отлавливать сообщения от отдельных ботов, или (только) от процесса ASF, вместо всех сразу, основываясь на имени в этой переменной.

ASF старается отмечать сообщения в соответствии с различными уровнями предупреждений NLog, что позволяет вам отлавливать сообщения только с заданным уровнем журналирования, а не все сразу. Разумеется, уровень журналирования для отдельных сообщений не может быть изменён, поскольку в коде ASF жестко задано, насколько это сообщение серьёзно, но вы можете заставить ASF выводить меньше или больше информации, на своё усмотрение.

ASF журналирует дополнительные данные, такие как сообщения в чате на уровне журналирования `Trace`. Журналирование по умолчанию в ASF записывает только сообщения с уровнем `Debug` или выше, что скрывает эту дополнительную информацию, поскольку это не нужно большинству пользователей, и в добавок засоряет выдачу в которой могут содержаться гораздо более важные сообщения. Вы, однако, можете использовать эту информацию, активировав уровень журналирования `Trace`, особенно в сочетании с журналированием только для выбранного бота, и только с событиями, которые вас интересуют.

В общем случае, ASF старается сделать вашу работу максимально простой и удобной, журналируя только сообщения которые вам нужны, вместо того чтобы заставлять вас вручную фильтровать журнал сторонними приложениями, такими как `grep` и тому подобное. Просто настройте NLog под свои потребности, как описано ниже, и вы сможете задать даже очень сложные правила журналирования, с пользовательскими целевыми журналами как например целые базы данных.

Относительно версии - мы всегда стараемся поставлять ASF с самой свежей версией NLog доступной в **[NuGet](https://www.nuget.org/packages/NLog)** на момент выпуска ASF. Не должно быть проблем с использованием любой функции, которую вы можете найти на NLog wiki в ASF - просто убедитесь, что вы также используете актуальный ASF.

Как часть интеграции ASF, ASF также включает в себя несколько дополнительных целей журналирования NLog, которые будут описаны ниже.

---

## Примеры

Начнем с чего-нибудь простого. Мы будем использовать в качестве цели только **[ColoredConsole](https://github.com/nlog/nlog/wiki/ColoredConsole-target)**. Наш исходный файл `NLog.config` будет выглядеть так:

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

Описание конфигурации выше очень простое - мы задали одну **цель журналирования** (тег `target`), которой будет `ColoredConsole`, затем мы перенаправили **все журналы** (`*`) уровня `Debug` и выше в цель `ColoredConsole`, которую мы задали выше. Вот и всё.

Если вы теперь запустите ASF с файлом `NLog.config`, описанным выше, будет активна только цель журналирования `ColoredConsole`, и ASF не будет ничего писать в файл (цель `File`), не смотря на записанную в коде ASF конфигурацию NLog.

Теперь допустим нам не нравится формат по умолчанию заданный `${longdate}|${level:uppercase=true}|${logger}|${message}` и мы хотим журналировать только сами сообщения. Мы можем это сделать изменив **[схему](https://github.com/nlog/nlog/wiki/Layouts)** (атрибут layout) для нашей цели журналирования.

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

Если вы теперь запустите ASF, вы заметите что дата, уровень предупреждения и источник сообщения исчезли - оставив вам только сообщения ASF в формате `Function() Message`.

Мы также можем изменить конфигурацию чтобы журналировать в больше чем одну цель. Let's log to `ColoredConsole` and **[`File`](https://github.com/nlog/nlog/wiki/File-target)** at the same time.

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

Готово, теперь журнал будет выводить всё в `ColoredConsole` и `File`. Вы заметили что можете указать собственное имя файла (`fileName`) и другие настройки?

И наконец, в ASF используются разные уровни журналирования, чтобы вам было легче понять что происходит. Мы можем использовать эту информацию чтобы изменить строгость журналирования. Например, мы хотим записывать всё (`Trace`) в `File`, но только сообщения **[уровня](https://github.com/NLog/NLog/wiki/Configuration-file#log-levels)** `Warning` и выше в `ColoredConsole`. Мы можем добиться этого изменив правила журналирования (тег `rules`):

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

Вот и всё, теперь наша `ColoredConsole` будет показывать только предупреждения и выше, но при этом все сообщения будут записаны в `File`. Вы можете настраивать это и дальше, например включить туда только сообщения уровня `Info` и ниже, и тому подобное.

И наконец, давайте сделаем что-то более продвинутое и будем журналировать все сообщения в файл, но только от бота с именем `LogBot`.

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

Вы можете увидеть, как мы использовали интеграцию с ASF выше, и легко определили источник сообщения на основе свойства `${logger}`.

---

## Продвинутое использование

Примеры выше достаточно простые, и сделаны чтобы показать как легко задать свои правила журналирования для использования в ASF. Вы можете использовать NLog для множества различных вещей, включая сложные цели (такие как сохранение журнала `Database`), ротации журналов (как например удаления старых логов в `File`), использование пользовательских схем (`Layout`), задания собственных фильтров `<when>` и многое другое. Я настоятельно рекомендую прочитать целиком **[документацию по NLog](https://github.com/nlog/nlog/wiki/Configuration-file)** чтобы узнать все доступные вам опции, что позволит настроить ASF так, как вы хотите. Это действительно мощный инструмент, и персонализация журналов ASF никогда не была проще.

---

## Ограничения

ASF временно отключит **все** правила, включающие в себя цели `ColoredConsole` или `Console` на время ожидания ввода от пользователя. Поэтому если вы хотите, чтобы журналирование в другие цели велось даже когда ASF ожидает ввода от пользователя, вам нужно задать для этих целей собственные правила, как показано в примерах выше, вместо того чтобы добавлять несколько целей в атрибут `writeTo` одного правила (если конечно это не то, чего вы хотите). Временное отключение целей с консолью сделано с целью оставить консоль чистой при ожидании ввода от пользователя.

---

## Журналироване чата

ASF включает в себя расширенную поддержку журналирования чатов, которая заключается в том, что записываются не только все полученные и отосланные сообщения на уровне журналирования `Trace`, но также выдаётся дополнительная информация, связанная с ними, в **[свойствах события](https://github.com/NLog/NLog/wiki/EventProperties-Layout-Renderer)**. Это вызвано тем, что нам в любом случае приходится обрабатывать сообщения для отслеживания команд, поэтому нам ничего не стоит добавить в журнал эти события чтобы дать возможность использовать дополнительную логику (как например, создание собственного архива сообщений чата с помощью ASF).

### Свойства события

| Имя         | Описание                                                                                                                                                                                                                                                       |
| ----------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Echo        | свойство типа `bool`. Имеет значение `true` когда сообщение отправляется от нас собеседники, и `false` в противном случае.                                                                                                                                     |
| Message     | свойство типа `string`. Содержит само отправленное/полученное сообщение.                                                                                                                                                                                       |
| ChatGroupID | свойство типа `ulong`. Содержит идентификатор группового чата в котором отправлено/получено сообщение. Будет равно `0` когда для передачи сообщения используется не групповой чат.                                                                             |
| ChatID      | свойство типа `ulong`. Содержит идентификатор канала в `ChatGroupID` в котором отправлено/получено сообщение. Будет равно `0` когда для передачи сообщения используется не групповой чат.                                                                      |
| SteamID     | свойство типа `ulong`. Это идентификатор пользователя Steam в чате с которым отправлено/получено сообщение. Может быть равно `0` когда ни один пользователь не задействован в передаче сообщения (например когда это мы отправляем сообщение в групповой чат). |

### Пример

Этот пример основан на нашем базовом примере с `ColoredConsole`, приведенном выше. Прежде чем пытаться разобраться в нём, я настоятельно рекомендую прочесть главу **[выше](#examples)**, чтобы сначала изучить основы журналирования с помощью NLog.

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

Мы начали с нашего базового примера с `ColoredConsole` и расширили его. Первое и самое главное - мы приготовили постоянный файл для журнала чатов в каждой группе и с каждым пользователем - это возможно благодаря дополнительным свойствам, которые выдаёт для нас ASF. Мы решили использовать пользовательскую схему, которая будет записывать только текущую дату, сообщение, информацию получено/отправлено это сообщение, и самого пользователя Steam. И наконец, мы включили наше правило журналирования чата только для уровня `Trace`, только для нашего бота `MainAccount`, и только для функция связанных с жураналированием чата (`OnIncoming*`, которая используется для получения сообщений и эхо-ответов, и `SendMessage*` которая отправляет сообщения ASF).

Пример выше создаст файл `0-0-76561198069026042.txt` если мы будем общаться с **[ArchiBot](https://steamcommunity.com/profiles/76561198069026042)**:

```text
2018-07-26 01:38:38 how are you doing? -> 76561198069026042
2018-07-26 01:38:38 I'm doing great, how about you? <- 76561198069026042
```

Разумеется это просто рабочий пример чтобы показать несколько способов использования схем. Вы можете расширить эту идею под свои нужды, как например добавить дополнительные фильтры, пользовательский порядок, личную схему, запись только полученных сообщений и т. д.

---

## Цели журналирования ASF

В дополнение к стандартным целям журналирования NLog (таким как `ColoredConsole` и `File`, описанные выше), вы можете также использовать дополнительные цели журналирования ASF.

Для единообразия, описания целей журналирования ASF будут следовать стандартам документации NLog.

---

### SteamTarget

Как вы могли догадаться, эта цель использует сообщения в чате Steam для журналирования сообщений ASF. Вы можете настроить её на использование либо группового, либо личного чата. В дополнение к указании цели Steam для ваших сообщений, вы можете также указать `botName` - имя бота который должен их отсылать.

Поддерживается во всех средах используемых ASF.

---

#### Синтаксис конфигурации
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

Прочтите больше о использовании [конфигурационного файла](https://github.com/NLog/NLog/wiki/Configuration-file).

---

#### Параметры

##### Общие параметры
_name_ - Имя цели журналирования.

---

##### Параметры схемы
_layout_ - Схема вывода сообщений. Требуется [Layout](https://github.com/NLog/NLog/wiki/Layouts). По умолчанию: `${level:uppercase=true}|${logger}|${message}`

---

##### Параметры SteamTarget

_chatGroupID_ - идентификатор группового чата в формате 64-битного беззнакового целого. Не обязательный параметр. По умолчанию имеет значение `0`, что отключает функционал группового чата и использует вместо этого личный чат. Когда этот параметр активирован (имеет отличное от нуля значение), параметр `steamID`, описанный ниже, выступает в роли `chatID` и указывает идентификатор канала в этом `chatGroupID`, куда бот должен отправлять сообщения.

_steamID_ - SteamID задаётся как 64-битное беззнаковое целое, и представляет из себя идентификатор пользователя Steam (подобно `SteamOwnerID`), или целевой `chatID` (если установлен `chatGroupID`). Обязательный параметр. По умолчанию имеет значение `0`, которое полностью отключает эту цель журналирования.

_botName_ - Имя бота (как оно распознается ASF, чувствительно к регистру), который будет отправлять сообщения на указанный выше `steamID`. Не обязательный параметр. По умолчанию имеет значение `null`, в этом случае автоматически выбирается **любой** из подключенных в данный момент ботов. Рекомендуется задавать значение параметра в явном виде, поскольку `SteamTarget` не учитывает многие ограничения Steam, как например тот факт, что целевой `steamID` должен быть у вас в списке друзей. Эта переменная имеет тип [layout](https://github.com/NLog/NLog/wiki/Layouts), поэтому вы можете использовать в ней особый синтаксис, как например `${logger}` чтобы задать бота, для которого сгенерировано сообщение.

---

#### Примеры SteamTarget

Чтобы отправлять все сообщения уровня `Debug` и выше, от бота с именем `MyBot` на steamID `76561198006963719`, мы должны использовать `NLog.config` подобный следующему:

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

**Примечание:** Наш `SteamTarget` это пользовательская цель, поэтому его нужно задавать как `type="Steam"`, а НЕ `xsi:type="Steam"`, поскольку xsi это зарезервированное слово для официальных целей журналирования, поддерживаемых NLog.

Когда вы запустите ASF с `NLog.config` подобным приведенному выше, `MyBot` будет отправлять сообщения пользователю Steam `76561198006963719` со всеми обычными сообщениями журнала ASF. Помните о том, что `MyBot` должен быть подключен чтобы отправлять сообщения, поэтому все начальные сообщения которые происходили до подключения нашего бота к сети Steam не будут перенаправлены.

Разумеется, `SteamTarget` имеет все стандартные функции которые ожидаются от базовой цели класса `TargetWithLayout`,поэтому вы можете его использовать например с пользовательскими схемами, именами или расширенными правилами журналирования. Пример выше это всего лишь самый простой вариант.

---

#### Скриншоты

![Скриншот](https://i.imgur.com/5juKHMt.png)

---

### HistoryTarget

Эта цель предназначена для внутреннего использования в ASF для вывода истории журналирования фиксированного размера для конечной точки `/Api/NLog` **[ASF API](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-ru-RU#asf-api)**, которая в дальнейшем используется в ASF-ui и других инструментах. В общем случае вам следует задавать эту цель только если вы используете собственную конфигурацию NLog и при этом хотите сохранить историю журнала в ASF API, например для ASF-ui. Также она может быть задана если вы хотите изменить схему по умолчанию или количество выводимых строк в параметре `maxCount`.

Поддерживается во всех средах используемых ASF.

---

#### Синтаксис конфигурации
```xml
<targets>
  <target type="History"
          name="String"
          layout="Layout"
          maxCount="Byte" />
</targets>
```

Прочтите больше о использовании [конфигурационного файла](https://github.com/NLog/NLog/wiki/Configuration-file).

---

#### Параметры

##### Общие параметры
_name_ - Имя цели журналирования.

---

##### Layout параметры
_layout_ - Схема вывода сообщений. Требуется [Layout](https://github.com/NLog/NLog/wiki/Layouts). По умолчанию: `${date:format=yyyy-MM-dd HH\:mm\:ss}|${processname}-${processid}|${level:uppercase=true}|${logger}|${message}${onexception:inner= ${exception:format=toString,Data}}`

---

##### Параметры HistoryTarget

_maxCount_ - Максимальное количество сохранённых сообщений для истории по запросу. Не обязательный параметр. Имеет по умолчанию значение `20`, что обеспечивает баланс между предоставлением истории и экономией памяти для хранения сообщений. Должно быть больше `0`.

---

## Предостережения

Будьте осторожны если решите комбинировать уровень журналирования `Debug` или ниже в вашей `SteamTarget` со `steamID` который используется в ASF. Это может привести к ошибке `StackOverflowException` из-за того что будет создана бесконечная петля когда ASF получает сообщение, отсылает его в журнал через Steam и в результате получает ещё одно сообщение которое тоже нужно записать в журнал. На данный момент единственная возможность столкнуться с этим это журналировать с уровнем `Trace` (когда ASF записывает в журнал собственные сообщения), или с уровнем `Debug` и одновременно включенным в ASF режимом `Debug` (когда ASF записывает в журнал все пакеты Steam).

Вкратце, если ваш `steamID` используется в ASF, то уровень журналирования `minlevel` в вашем `SteamTarget` должен быть `Info` (или `Debug` если вы не запускаете ASF в режиме `Debug`) или выше. В качестве альтернативы вы можете задать собственные фильтры журналирования `<when>` чтобы избежать бесконечной петли, если изменение уровня журналирования вам не подходит. Это предостережение касается также групповых чатов.