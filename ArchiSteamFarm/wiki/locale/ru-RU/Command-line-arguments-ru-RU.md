# Аргументы командной строки

ASF поддерживает несколько аргументов командной строки, которые влияют на работу программы. Они могут использоваться опытными пользователями для изменения поведения программы. По сравнению с обычной настройкой через файл конфигурации `ASF.json`, аргументы командной строки используются для инициализации ядра (например, `--path`), специфичных для данной платформы настроек (например, `--system-required`) или конфиденциальных данных (например, `--cryptkey`).

---

## Использование

Способ использования аргументов зависит от вашей операционной системы и варианта ASF.

Общий:

```shell
dotnet ArchiSteamFarm.dll --argument --otherOne
```

Windows:

```powershell
.\ArchiSteamFarm.exe --argument --otherOne
```

Linux/macOS:

```shell
./ArchiSteamFarm --argument --otherOne
```

Аргументы командной строки также поддерживаются во вспомогательных скриптах, таких как `ArchiSteamFarm.cmd` или `ArchiSteamFarm.sh`. Кроме того, можно использовать переменную окружения `ASF_ARGS`, так как это показано в секциях **[Управление](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#environment-variables)** и **[Docker](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Docker#command-line-arguments)**.

Если ваш аргумент содержит пробелы, не забудьте заключить его в кавычки. Эти два примера неправильные:

```shell
./ArchiSteamFarm --path /home/archi/My Downloads/ASF # Плохо!
./ArchiSteamFarm --path=/home/archi/My Downloads/ASF # Тоже плохо!
```

Однако, эти два абсолютно корректны:

```shell
./ArchiSteamFarm --path "/home/archi/My Downloads/ASF" # Нормально
./ArchiSteamFarm "--path=/home/archi/My Downloads/ASF" # Тоже нормально
```

## Аргументы

`--cryptkey <key>` или `--cryptkey=<key>` - запустит ASF с пользовательским значением ключа шифрования `<key>`. Эта настройка влияет на **[безопасность](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security-ru-RU)** и ASF будет использовать данный ключ шифрования `<key>` вместо внедрённого в исполняемый файл. Поскольку эта настройка влияет на ключ шифрования по умолчанию (для шифрования), а также на соль (для хеширования), не забывайте, что для любого шифрования/хеширования этот ключ должен передаваться ASF при каждом запуске.

Требований к длине `<key>` или количеству символов нет, но в целях безопасности мы рекомендуем выбирать достаточно длинную пароль-фразу, состоящую, например, из произвольных 32 символов, например, с помощью команды `tr -dc A-Za-z0-9 < /dev/urandom | head -c 32; echo` в Linux.

Ещё хотелось бы упомянуть, что есть ещё два аргумента для предоставления ключа шифрования: `--cryptkey-file` и `--input-cryptkey`.

Из-за природы этого параметра также есть возможность задавать ключ шифрования путём задания переменной среды `ASF_CRYPTKEY`, это может оказаться более подходящим для людей, которые хотели бы избежать наличия конфиденциальной информации в аргументах процесса.

---

`--cryptkey-file <path>` или `--cryptkey-file=<path>` - запустит ASF с помощью пользовательского криптографического ключа из файла `<path>`. Это служит той же цели, что и объяснённый выше `--cryptkey<key>`, только механизм отличается так как это свойство прочитает `<key>` из предоставленного `<path>` файла. Если вы используете этот флаг вместе с `--path`, лучше сначала определить `--path`, для корректной работы относительных путей.

Из-за природы этого параметра также есть возможность задавать ключ шифрования путём задания переменной среды `ASF_CRYPTKEY`, это может оказаться более подходящим для людей, которые хотели бы избежать наличия конфиденциальной информации в аргументах процесса.

---

`--ignore-unsupported-environment` - указывает ASF игнорировать запуск в неподдерживаемой среде, что обычно приводит к выводу ошибки и остановке программы. Неподдерживаемой средой будет, например, запущенная на `linux-x64` сборка под `win-x64`. Хотя этот флаг позволит ASF попытаться запуститься в таких сценариях, имейте в виду, что мы не поддерживаем их официально, и вы вынуждаете ASF делать это полностью **на свой страх и риск**. It's important to point out that **all** of the unsupported environment scenarios **can be corrected**. Мы настоятельно рекомендуем исправить нерешенные проблемы вместо использования этого аргумента.

---

`--input-cryptkey` - заставит ASF спросить о `--cryptkey` при запуске. Эта опция может оказаться полезной, если вместо предоставления криптоключа, будь то переменная среда или файл, вы предпочитаете, чтобы он нигде не сохранялся, а вводился вручную при каждом запуске ASF.

---

`--minimized` - заставит окно консоли ASF свернуться сразу после запуска. Применимо, в основном, в сценариях с авто запуском, но может использоваться и вне таковых. В настоящее время эта опция работает только на компьютерах под управлением Windows.

---

`--network-group <group>` либо `--network-group=<group>` - указывает ASF использовать ограничители запросов для пользовательской сетевой группы с именем `<group>`. Этот аргумент влияет на работу ASF при **[multiple instances](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#multiple-instances)** , указывая что этот экземпляр зависит только от других экземпляров в той же сетевой группе, и не зависит от остальных. Обычно вам стоит указывать этот аргумент если вы перенаправляете запросы от ASF с помощью внешних механизмов (например, различных IP-адресов), и хотите сами задавать сетевую группу, не полагаясь на автоматическое определение ASF (которое на данный момент учитывает только значение `WebProxy`). Имейте в виду, что используемая сетевая группа является уникальным идентификатором в пределах данной машины, и ASF не будет учитывать прочие детали, такие как значение `WebProxy`, позволяя вам, например, запустить два экземпляра программы с разными значениями `WebProxy` и тем не менее зависящие друг от друга.

Из-за природы этого параметра также есть возможность задавать его значение путём задания переменной среды `ASF_NETWORK_GROUP`, это может оказаться более подходящим для людей, которые хотели бы избежать наличия конфиденциальной информации в аргументах процесса.

---

`--no-config-migrate` - по умолчанию ASF автоматически перенесет ваши файлы конфигурации на последнюю версию синтаксиса. Перенос включает преобразование устаревших свойств в новые, удаление свойств со значениями по умолчанию (поскольку они не действуют), а также очистку файла в целом (исправление отступов и тому подобное). Это почти всегда хорошая идея, но у вас может быть особая ситуация, когда вы предпочитаете, чтобы ASF никогда не перезаписывал файлы конфигурации автоматически. Например, вы можете сделать `chmod 400` свои файлы конфигурации (права на чтение только для владельца) или поместить поверх них `chattr + i`, в результате запретив доступ на запись для всех, например в качестве меры безопасности. Обычно мы рекомендуем оставить перенос конфигурации включенным, но если у вас есть особая причина для его отключения и вы предпочитаете, чтобы ASF этого не делал, вы можете использовать этот переключатель для достижения этой цели. Keep in mind however, that providing correct settings to ASF will become from now on your new responsibility, especially in regards to deprecations and refactors of properties in future ASF versions.

---

`--no-config-watch` - по умолчанию ASF устанавливает `FileSystemWatcher` в вашем каталоге `config`, чтобы отслеживать события, связанные с изменениями файлов, поэтому он может интерактивно адаптироваться к ним. Например, это включает в себя остановку ботов при удалении конфигурации, перезапуск бота при изменении конфигурации или загрузку ключей в **[BGR](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer-ru-RU)** после того, как вы поместите их в каталог `config`. Этот переключатель позволяет вам отключить такое поведение, которое заставит ASF полностью игнорировать все изменения в каталоге `config`, требуя от вас выполнения таких действий вручную, если вы сочтете нужным (что обычно означает перезапуск процесса). Мы рекомендуем оставить config events включенными, но если у вас есть особая причина для их отключения и вместо этого вы предпочитаете, чтобы ASF не делал этого, вы можете использовать этот переключатель для достижения этой цели.

---

`--no-restart` - данный параметр используется для контейнеров **[Docker](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Docker-ru-RU)** и принудительно задаёт параметру `AutoRestart` значение `false`. Если у вас нет особой необходимости в этой команде, вам следует вместо этого настроить свойство `AutoRestart` прямо в вашей конфигурации. Этот переключатель находится здесь, поэтому нашему docker-скрипту не нужно будет трогать вашу глобальную конфигурацию, чтобы адаптировать ее к своей собственной среде. Разумеется, если вы запускаете ASF из скрипта, возможно вы захотите тоже воспользоваться этим аргументом (в противном случае лучше использовать параметр глобальной конфигурации).

---

`--no-steam-parental-generation` - по умолчанию ASF будет автоматически пытаться сгенерировать родительский PIN-код Steam, как описано в в свойстве конфигурации **[`Параметры SteamParentalCode`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#steamparentalcode)**. Однако, поскольку для этого может потребоваться чрезмерное количество ресурсов ОС, этот переключатель позволяет вам отключить такое поведение, что приведет к тому, что ASF пропустит автоматическую генерацию и вместо этого сразу запросит у пользователя PIN-код, что обычно происходит, только если автоматическая генирация не удалась. Обычно мы рекомендуем оставить генерацию включенной, но если у вас есть особая причина для отключения и вместо этого предпочитаете чтобы ASF этого не делал, вы можете использовать этот переключатель для достижения этой цели.

---

`--path <path>` или `--path=<path>` - ASF всегда использует папку из которой был запущен. By specifying this argument, ASF will navigate to given directory after initialization, which allows you to use custom path for various application parts (including `config`, `logs`, `plugins` and `www` directories, as well as `NLog.config` file), without a need of duplicating binary in the same place. Это может оказаться особенно полезно если вы хотите разделить исполняемые файлы от собственно файлов конфигурации, как это делается в пакетах Linux - таким образом вы можете использовать один (обновляемый) исполняемый файл с несколькими разными наборами конфигураций. Путь может быть как относительный, по отношению к текущему расположению исполняемого файла ASF, так и абсолютный. Имейте в виду, что эта команда указывает на новую «домашнюю ASF» — каталог, имеющий ту же структуру, что и исходный ASF, с каталогом `config` внутри. Подробности в примере ниже.

Из-за природы этого параметра также есть возможность задавать необходимый путь с помощью задания переменной среды `ASF_PATH`, это может оказаться более подходящим для людей, которые хотели бы избежать наличия конфиденциальной информации в аргументах процесса.

Если вы планируете использовать этот аргумент командной строки для запуска нескольких копий ASF, мы рекомендуем вам также раздел, посвященный этому, на странице, посвященной **[совместимости](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility-ru-RU#user-content-Запуск-нескольких-экземпляров)**.

Примеры:

```shell
dotnet /opt/ASF/ArchiSteamFarm.dll --path /opt/TargetDirectory # Абсолютный путь
dotnet /opt/ASF/ArchiSteamFarm.dll --path ../TargetDirectory # Относительный путь тоже работает
ASF_PATH=/opt/TargetDirectory dotnet /opt/ASF/ArchiSteamFarm.dll # Как и переменная окружения
```

```text
├── /opt
│     ├── ASF
│     │     ├── ArchiSteamFarm.dll
│     │     └── ...
│     └── TargetDirectory
│           ├── config
│           ├── logs (generated)
│           ├── plugins (optional)
│           ├── www (optional)
│           ├── log.txt (generated)
│           └── NLog.config (optional)
└── ...
```

---

`--process-required` - использование этого аргумента запретит выключение ASF в ситуации когда нет запущенных ботов. Отсутствие автоматического выключения особенно полезно в сочетании с **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-ru-RU)**, поскольку большинство пользователей будут ожидать что веб-интерфейс будет работать независимо от количества запущенных ботов. Если вы пользуетесь IPC или вам по другой причине нужно чтобы ASF продолжал работу пока вы не выключите его сами, это как раз то, что вам надо.

Если вы не планируете использовать IPC, этот аргумент выглядит довольно бесполезным для вас, поскольку вы всегда можете заново запустить процесс ASF когда он вам нужен (в отличии от серверного использования, когда вы ожидаете что ASF продолжит всё время ожидать от вас новых команд).

---

` --service ` - этот переключатель в основном используется нашей службой ` systemd ` и устанавливает для ` Headless ` значение ` true `. Если у вас нет особой необходимости в этой команде, вам следует вместо этого настроить свойство `Headless` прямо в вашей конфигурации. Этот переключатель находится здесь, поэтому нашей службе ` systemd ` не нужно будет трогать вашу глобальную конфигурацию, чтобы адаптировать ее к своей собственной среде. Конечно, если у вас есть потребность в этой команде, вы также можете использовать этот переключатель (в противном случае вам лучше использовать глобальное свойство конфигурации).

---

`--system-required` - указание этого аргумента заставит ASF попытаться сообщить ОС что этому процессу требуется чтобы система была запущена в течение всей его работы. На данный момент этот параметр имеет эффект только на машинах использующих Windows, где он запретит системе переходить в режим сна пока запущен процесс. Это может оказаться особенно полезно если вы фармите на вашем ПК или ноутбуке ночью, поскольку ASF сможет оставить вашу систему запущенной пока он фармит, а после окончания работы ASF завершится, и позволит вашей системе снова перейти в режим сна, позволяя сэкономить электроэнергию когда фарм завершен.

Keep in mind that for proper auto-shutdown of ASF you need other settings - especially avoiding `--process-required` and ensuring that all your bots are following `ShutdownOnFarmingFinished` in their `FarmingPreferences`. Конечно же, автоматическое завершение это только одно из возможных применений этой функции и не является обязательным, поскольку вы можете использовать этот аргумент совместно с например `--process-required`, фактически оставив вашу систему постоянно включенной после запуска ASF.