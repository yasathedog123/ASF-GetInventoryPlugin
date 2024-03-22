# Аргументи командного рядка

ASF включає підтримку декількох аргументів командного рядка, які можуть вплинути на виконання програми. Вони можуть бути використані досвідченими користувачами для того, щоб вказати, як повинна працювати програма. На відміну від конфігураційного файлу за замовчуванням `ASF.json`, аргументи командного рядка використовуються для ініціалізації ядра (наприклад, `--path`), специфічних для платформи налаштувань (наприклад, `--system-required`) або конфіденційних даних (наприклад, `--cryptkey`).

---

## Використання

Використання залежить від вашої операційної системи та смаку ASF.

Загальні:

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

Аргументи командного рядка також підтримуються у загальних допоміжних скриптах, таких як `ArchiSteamFarm.cmd` або `ArchiSteamFarm.sh`. Крім того, ви також можете використовувати властивість середовища `ASF_ARGS`, як описано у розділах **[management](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#environment-variables)** та **[docker](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Docker#command-line-arguments)**.

Якщо ваш аргумент містить пробіли, не забудьте взяти його в лапки. Обидва помиляються:

```shell
./ArchiSteamFarm --path /home/archi/My Downloads/ASF # Bad!
./ArchiSteamFarm --path=/home/archi/My Downloads/ASF # Bad!
```

Втім, з цими двома все гаразд:

```shell
./ArchiSteamFarm --path "/home/archi/My Downloads/ASF" # OK
./ArchiSteamFarm "--path=/home/archi/My Downloads/ASF" # OK
```

## Аргументи

`--cryptkey <key>` або `--cryptkey=<key>` - запустить ASF з власним криптографічним ключем зі значенням `<key>`. Цей параметр впливає на **[безпеку](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security)** і призведе до того, що ASF використовуватиме наданий вами ключ `<key>` замість стандартного, жорстко закодованого у виконуваному файлі. Оскільки ця властивість впливає на ключ шифрування за замовчуванням (для шифрування), а також на сіль (для хешування), майте на увазі, що все зашифроване/хешоване за допомогою цього ключа вимагатиме його передачі під час кожного запуску ASF.

Немає вимог до довжини або символів `<key>`, але з міркувань безпеки ми рекомендуємо вибирати достатньо довгу парольну фразу, що складається, наприклад, з випадкових 32 символів, наприклад, за допомогою команди `tr -dc A-Za-z0-9 < /dev/urandom | head -c 32; echo` у Linux.

Приємно відзначити, що є також два інших способи надання цієї інформації: `--cryptkey-file` та `--input-cryptkey`.

Через природу цієї властивості також можна встановити криптографічний ключ, оголосивши змінну оточення `ASF_CRYPTKEY`, що може бути більш доречним для людей, які бажають уникнути чутливих деталей у аргументах процесу.

---

`--cryptkey-file <path>` або `--cryptkey-file=<path>` - запустить ASF з власним криптографічним ключем, прочитаним з файлу `<path>`. Ця властивість слугує тій самій меті, що і `--криптоключ <key>`, описаний вище, тільки механізм відрізняється, оскільки ця властивість буде зчитувати `<key>` з наданого `<path>` замість цього. Якщо ви використовуєте цей параметр разом з `--path`, подумайте про те, щоб спочатку оголосити `--path`, щоб відносні шляхи працювали коректно.

Через природу цієї властивості також можна встановити файл криптографічного ключа, оголосивши змінну оточення `ASF_CRYPTKEY_FILE`, що може бути більш доречним для людей, які хочуть уникнути чутливих деталей в аргументах процесу.

---

`--ignore-unsupported-environment` - змусить ASF ігнорувати проблеми, пов'язані з роботою у непідтримуваному середовищі, що зазвичай сигналізується помилкою і примусовим виходом. Непідтримувані середовища включають, наприклад, запуск збірки для `win-x64` ОС на `linux-x64`. Хоча цей прапорець дозволить ASF спробувати запустити такі сценарії, зауважте, що ми не підтримуємо їх офіційно, і ви змушуєте ASF робити це повністю **на свій страх і ризик**. Важливо зазначити, що **усі** сценарії непідтримуваного середовища **можна виправити**. Ми наполегливо рекомендуємо виправити невирішені проблеми замість того, щоб декларувати цей аргумент.

---

`--input-cryptkey` - змусить ASF запитати про `--cryptkey` під час запуску. Ця опція може бути корисною для вас, якщо замість того, щоб надавати криптографічний ключ у змінних оточення або файлі, ви бажаєте не зберігати його ніде, а вводити вручну під час кожного запуску ASF.

---

`--minimized` - змусить вікно консолі ASF згорнутися одразу після запуску. Корисний переважно у сценаріях автоматичного запуску, але може використовуватися і поза ними. Наразі цей перемикач діє лише на комп'ютерах з Windows.

---

`--мережева група <group>` або `--мережева група=<group>` - змусить ASF ініціювати свої обмежувачі з користувацькою мережевою групою зі значенням `<group>`. Цей параметр впливає на запуск ASF у **[кількох екземплярах](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#multiple-instances)**, сигналізуючи, що даний екземпляр є залежним лише від екземплярів, що належать до тієї самої мережевої групи, і незалежним від решти екземплярів. Зазвичай ви хочете використовувати цю властивість лише тоді, коли ви маршрутизуєте запити ASF за допомогою спеціального механізму (наприклад, через різні IP-адреси) і хочете встановити мережеві групи самостійно, не покладаючись на те, що ASF зробить це автоматично (що наразі передбачає врахування лише `WebProxy`). Keep in mind that when using a custom network group, this is unique identifier within the local machine, and ASF will not take into account any other details, such as `WebProxy` value, allowing you to e.g. start two instances with different `WebProxy` values which are still dependent on each other.

Due to the nature of this property, it's also possible to set the value by declaring `ASF_NETWORK_GROUP` environment variable, which may be more appropriate for people that would want to avoid sensitive details in the process arguments.

---

`--no-config-migrate` - by default ASF will automatically migrate your config files to latest syntax. Migration includes conversion of deprecated properties into latest ones, removing properties with default values (as they have no effect), as well as cleaning up the file in general (correcting indentation and likewise). This is almost always a good idea, but you might have a particular situation where you'd prefer ASF to never overwrite the config files automatically. For example, you might want to `chmod 400` your config files (read permission for the owner only) or put `chattr +i` over them, in result denying write access for everyone, e.g. as a security measure. Usually we recommend to keep the config migration enabled, but if you have a particular reason for disabling it and would instead prefer ASF to not do that, you can use this switch for achieving that purpose. Keep in mind however, that providing correct settings to ASF will become from now on your new responsibility, especially in regards to deprecations and refactors of properties in future ASF versions.

---

`--no-config-watch` - by default ASF sets up a `FileSystemWatcher` over your `config` directory in order to listen for events related to file changes, so it can interactively adapt to them. For example, this includes stopping bots on config deletion, restarting bot on config being changed, or loading keys into **[BGR](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer)** once you drop them into the `config` directory. This switch allows you to disable such behaviour, which will cause ASF to completely ignore all the changes in `config` directory, requiring from you to do such actions manually, if deemed appropriate (which usually means restarting the process). We recommend to keep the config events enabled, but if you have a particular reason for disabling them and would instead prefer ASF to not do that, you can use this switch for achieving that purpose.

---

`--no-restart` - this switch is mainly used by our **[docker](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Docker)** containers and forces `AutoRestart` of `false`. Unless you have a particular need, you should instead configure `AutoRestart` property directly in your config. This switch is here so our docker script won't need to touch your global config in order to adapt it to its own environment. Of course, if you're running ASF inside a script, you may also make use of this switch (otherwise you're better with global config property).

---

`--no-steam-parental-generation` - by default ASF will automatically attempt to generate Steam parental PINs, as described in **[`SteamParentalCode`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#steamparentalcode)** configuration property. However, since that might require excessive amount of OS resources, this switch allows you to disable that behaviour, which will result in ASF skipping auto-generation and go straight to asking user for PIN instead, which is what would normally happen only if the auto-generation has failed. Usually we recommend to keep the generation enabled, but if you have a particular reason for disabling it and would instead prefer ASF to not do that, you can use this switch for achieving that purpose.

---

`--path <path>` or `--path=<path>` - ASF always navigates to its own directory on startup. By specifying this argument, ASF will navigate to given directory after initialization, which allows you to use custom path for various application parts (including `config`, `logs`, `plugins` and `www` directories, as well as `NLog.config` file), without a need of duplicating binary in the same place. It may come especially useful if you'd like to separate binary from actual config, as it's done in Linux-like packaging - this way you can use one (up-to-date) binary with several different setups. The path can be either relative according to current place of ASF binary, or absolute. Keep in mind that this command points to new "ASF home" - the directory that has the same structure as original ASF, with `config` directory inside, see below example for explanation.

Due to the nature of this property, it's also possible to set expected path by declaring `ASF_PATH` environment variable, which may be more appropriate for people that would want to avoid sensitive details in the process arguments.

If you're considering using this command-line argument for running multiple instances of ASF, we recommend reading our **[management page](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#multiple-instances)** on this manner.

Приклади:

```shell
dotnet /opt/ASF/ArchiSteamFarm.dll --path /opt/TargetDirectory # Absolute path
dotnet /opt/ASF/ArchiSteamFarm.dll --path ../TargetDirectory # Relative path works as well
ASF_PATH=/opt/TargetDirectory dotnet /opt/ASF/ArchiSteamFarm.dll # Same as env variable
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

`--process-required` - оголошення цього перемикача вимкне стандартну поведінку ASF щодо завершення роботи, коли не запущено жодного бота. Відсутність автоматичного вимкнення особливо корисна у поєднанні з **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)**, де більшість користувачів очікують, що їхній веб-сервіс працюватиме незалежно від кількості увімкнених ботів. Якщо ви використовуєте опцію IPC або вам потрібно, щоб процес ASF виконувався весь час, поки ви його не закриєте, це правильний варіант.

Якщо ви не маєте наміру запускати IPC, ця опція не буде для вас корисною, оскільки ви можете просто запустити процес знову, коли це буде потрібно (на відміну від веб-сервера ASF, який потребує постійного прослуховування для того, щоб надсилати команди).

---

`--service` - цей перемикач переважно використовується нашою службою `systemd` і змушує `Headless` з `true`. Якщо у вас немає особливої потреби, ви можете налаштувати властивість `Headless` безпосередньо у вашому конфігураторі. Цей перемикач тут для того, щоб нашій службі `systemd` не потрібно було торкатися вашого глобального конфігуратора, щоб адаптувати його до свого оточення. Звісно, якщо у вас є подібна потреба, ви також можете скористатися цим перемикачем (якщо ні, то краще скористайтеся властивістю global config).

---

`--system-required` - оголошення цього перемикача призведе до того, що ASF спробує повідомити ОС про те, що процес вимагає, щоб система працювала протягом усього часу його існування. Наразі цей перемикач діє лише на комп'ютерах з Windows, де він забороняє системі переходити у сплячий режим доти, доки виконується процес. Це може виявитися особливо корисним, коли ви працюєте на комп'ютері або ноутбуці вночі, оскільки ASF зможе тримати вашу систему в сплячому режимі під час роботи, а після завершення роботи ASF вимкнеться, як зазвичай, що дозволить вашій системі знову перейти в сплячий режим, тим самим заощаджуючи енергію відразу після завершення ферми.

Майте на увазі, що для правильного автоматичного вимкнення ASF вам знадобляться інші налаштування, зокрема уникнення `--process-required` і забезпечення того, щоб усі ваші боти дотримувалися `ShutdownOnFarmingFinished` у своїх `FarmingPreferences`. Звісно, автоматичне вимкнення є лише можливістю для цієї можливості, а не вимогою, оскільки ви також можете використовувати цей прапорець разом із, наприклад, `--process-required`, фактично змушуючи вашу систему не спати нескінченно після запуску ASF.