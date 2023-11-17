# Конфігурація

Ця страниця присвячена налаштуванням ASF. Вона являє собою вичерпну документацію директорії `config`, цу допоможе вам налаштувати ASF під свої потреби.

* **[Вступ](#introduction)**
* **[Генератор конфігурацій на базі веб](#web-based-configgenerator)**
* **[ASF-ui configuration](#asf-ui-configuration)**
* **[Налаштування вручну](#manual-configuration)**
* **[Глобальна конфігурація](#global-config)**
* **[Конфігурація боту](#bot-config)**
* **[Файлова структура](#file-structure)**
* **[Типи параметрів JSON](#json-mapping)**
* **[Сумісність типів](#compatibility-mapping)**
* **[Сумісність конфігурацій](#configs-compatibility)**
* **[Автоматичне перезавантаження](#auto-reload)**

---

## Вступ

Конфігурація ASF поділена на дві основні частини - глобальн конфігурацію (для процессу вцілому), та конфігурація для окремих ботів. Кожен бот має власний файл конфігурації, названий `BotName.json` (де `BotName` це ім'я боту), а глобальна конфігурація ASF (процессу) - це єдиний файл з ім'ям `ASF.json`.

Бот це один акаунт steam, який використовується процесом ASF. ASF потребує для роботи якнайменше **один** налаштований екземпляр бота. Ніякого технічного обмеження на кількість екземплярів ботів немає, тож ви можете використовувати стільки ботів (акаунтів steam), скільки забажаєте.

ASF використовує формат **[JSON](https://uk.wikipedia.org/wiki/JSON)** для зберігання конфігураційних файлів. Це зручний для людини, легкий для читання та дуже універсальний формат, за допомогою якого ви можете конфігурувати програму. Однак не хвилюйтеся, вам немає потреби знати JSON щоб налаштувати ASF. Я лише зазначив це на випадок якщо ви забажаєте створити велику кількість конфігурацій ASF за допомогою якогось скрипта.

Configuration can be done in several ways. You can use our **[Web-based ConfigGenerator](https://justarchinet.github.io/ASF-WebConfigGenerator)**, which is a local app independent of ASF. You can use our **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)** IPC frontend for configuration done directly in ASF. Lastly, you can always generate config files manually, as they follow fixed JSON structure specified below. We'll explain shortly the available options.

---

## Генератор конфігурацій на базі веб

The purpose of our **[Web-based ConfigGenerator](https://justarchinet.github.io/ASF-WebConfigGenerator)** is to provide you with a friendly frontend that is used for generating ASF configuration files. Генератор конфігурацій на базі веб на 100% виконується на стороні клієнта, тобто ніякі дані, що ви вводите, нікуди не надсилаються, й оброблюються локально. Це гарантує безпеку і надійність, бо генератор може працювати навіть **[офлайн](https://github.com/JustArchiNET/ASF-WebConfigGenerator/tree/main/docs)**, якщо ви завантажите усі файли та відкриєте `index.html` у вашому улюбленому браузері.

Генератор конфігурацій на базі веб перевірено на належну роботу у Chrome та Firefox, але він має працювати у більшості популярних браузерів з підтримкою javascript.

Користуватися ним дуже просто - оберіть, що ви хочете згенерувати - конфігурацію `ASF`, чи конфігурацію бота просто перейшовши на потрібну вкладку, перевірте що версія файла конфігурації відповідає версії вашого ASF, введіть усі потрібні дані та натисніть кнопку "Скачати". Перемістіть цей файл до каталогу `config` вашого ASF, замінюючи існуючі фали, якщо це необхідно. Повторіть ці кроки для усіх подальших змін, та скористуйтеся рештою цього розділу для пояснень щодо усіх існуючих параметрів конфігурації.

---

## ASF-ui configuration

Our **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)** IPC interface allows you to configure ASF as well, and is superior solution for reconfiguring ASF after generating the initial configs due to the fact that it can edit the configs in-place, as opposed to Web-based ConfigGenerator which generates them statically.

In order to use ASF-ui, you must have our **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)** interface enabled itself. `IPC` is enabled by default starting with ASF V5.1.0.0, therefore you can access it right away, as long as you didn't disable it yourself.

After launching the program, simply navigate to ASF's **[IPC address](http://localhost:1242)**. If everything worked properly, you can change ASF configuration from there as well.

---

## Налаштування вручну

In general we strongly recommend using either our ConfigGenerator or ASF-ui, as it's much easier and ensures you won't make a mistake in the JSON structure, but if for some reason you don't want to, then you can also create proper configs manually. Check JSON examples below for a good start in proper structure, you can copy the content into a file and use it as a base for your config. Since you're not using any of our frontends, ensure that your config is **[valid](https://jsonlint.com)**, as ASF will refuse to load it if it can't be parsed. Even if it's a valid JSON, you also have to ensure that all the properties have the proper type, as required by ASF. For proper JSON structure of all available fields, refer to **[JSON mapping](#json-mapping)** section and our documentation below.

---

## Глобальна конфігурація

Глобальна конфігурація зберігається у файлі `ASF.json` та має наступну структуру:

```json
{
    "AutoRestart": true,
    "Blacklist": [],
    "CommandPrefix": "!",
    "ConfirmationsLimiterDelay": 10,
    "ConnectionTimeout": 90,
    "CurrentCulture": null,
    "Debug": false,
    "DefaultBot": null,
    "FarmingDelay": 15,
    "FilterBadBots": true,
    "GiftsLimiterDelay": 1,
    "Headless": false,
    "IdleFarmingPeriod": 8,
    "InventoryLimiterDelay": 4,
    "IPC": true,
    "IPCPassword": null,
    "IPCPasswordFormat": 0,
    "LicenseID": null,
    "LoginLimiterDelay": 10,
    "MaxFarmingTime": 10,
    "MaxTradeHoldDuration": 15,
    "MinFarmingDelayAfterBlock": 60,
    "OptimizationMode": 0,
    "SteamMessagePrefix": "/me ",
    "SteamOwnerID": 0,
    "SteamProtocols": 7,
    "UpdateChannel": 1,
    "UpdatePeriod": 24,
    "WebLimiterDelay": 300,
    "WebProxy": null,
    "WebProxyPassword": null,
    "WebProxyUsername": null
}
```

---

Усі параметри описані нижче:

### `AutoRestart`

параметр типу `bool` зі значенням за замовчуванням `true`. Цей параметр визначає, чи дозволено ASF перезапускатися в разі потреби. Є кілька випадків, які потребують перезапуск ASF, як наприклад оновлення ASF (яке сталося згідно `UpdatePeriod` чи за допомогою команди `update`), а також зміни у конфігураційному файлі `ASF.json`, команда `restart` і таке інше. Зазвичай, перезапуск складається з двох частин - створення нового процесу, та завершення поточного. Це має задовольнити більшість користувачів, вони можуть залишити цьому параметру значення за замовчуванням `true`, однак, якщо ви запускаєте ASF за допомогою власного скрипта та/чи за допомогою `dotnet`, можливо ви захочете мати повний контроль над запуском процесу, та запобігти ситуацію у якій (перезапущений) процес ASF буде мовчки виконуватися у фоновому режими, замість потоку скрипта, який завершиться разом зі старим процесом ASF. Це особливо важливо, враховуючи той факт що новий процес не буде вашим прямим нащадком, через що ви не зможете, наприклад, користуватися в ньому стандартним вводом з консолі.

У такому випадку - цей параметр саме для вас, і ви можете встановити йому значення `false`. Однак, майте на увазі, що у цьому разі саме **ви** відповідаєте за перезапуск процесу. Це дещо важливо тому що ASF просто завершить роботу замість запуску нового процесу (наприклад, після оновлення), тому якщо ви не додасте якусь логіку обробки цього, він просто припинить працювати доки ви знов не запустите його. ASF завжди завершується з належним кодом помилки, який зазначає успішність (нуль) чи не-успішність(не нуль), тому ви в змозі додати належну логіку у вашому скрипті, який не буде перезапускати ASF у разі помилки, або принаймні створить копію `log.txt` для подальшого аналізу. Також пам'ятайте, що команда `restart` завжди перезапустить ASF, незважаючи на значення цього параметру, тому що параметр визначає поведінку за замовчуванням, а команда `restart` завжди перезапускає процес. Якщо у вас немає підстав, щоб вимкнути цю функцію, вам варто залишити її ввімкненою.

---

### `Blacklist`

параметр типу `ImmutableHashSet<uint>` з пустим значенням за замовчуванням. As the name suggests, this global config property defines appIDs (games) that will be entirely ignored by automatic ASF farming process. Нажаль, Steam полюбляє відмітити значки літнього/зимового розпродажу як "Ще може випасти карток: X", що заважає процесу ASF, змушуючи його вважати що це дійсно гра, яку треба фармити. Якби не було ніякого чорного списку, ASF би "зависав" намагаючись фармити гру, що насправді не є грою, і чекав би довіку поки з неї випадуть картки, а цього б ніколи не сталося. Чорний список ASF має на меті маркування таких значків як недоступних для фарму, щоб їх можна було тихо ігнорувати при виявленні ігор для фарму, і не потрапляти до цієї пастки.

ASF includes two blacklists by default - `SalesBlacklist`, which is hardcoded into the ASF code and not possible to edit, and normal `Blacklist`, which is defined here. `SalesBlacklist` is updated together with ASF version and typically includes all "bad" appIDs at the time of release, so if you're using up-to-date ASF then you do not need to maintain your own `Blacklist` defined here. Основною метою цього параметру є надати можливість додавати до чорного списку нові, невідомі на час випуску ASF appID, які не треба фармити. Hardcoded `SalesBlacklist` is being updated as fast as possible, therefore you're not required to update your own `Blacklist` if you're using latest ASF version, but without `Blacklist` you'd be forced to update ASF in order to "keep running" when Valve releases new sale badge - I don't want to force you to use latest ASF code, therefore this property is here to allow you "fixing" ASF yourself if you for some reason don't want to, or can't, update to new hardcoded `SalesBlacklist` in new ASF release, yet you want to keep your old ASF running. Якщо у вас немає **вагомих** підстав змінювати цей параметр, вам варто залишити йому значення за замовчуванням.

If you're looking for bot-based blacklist instead, take a look at `fb`, `fbadd` and `fbrm` **[commands](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**.

---

### `CommandPrefix`

параметр типу `string` зі значенням за замовчуванням `!`. Цей параметр задає **чутливий до регістру** префікс, який використовується для **[команд](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-uk-UA)** ASF. Інакше кажучи, це те, що вам потрібно додавати перед кожною командою ASF для того, щоб ASF вас послухався. Цей параметр можна поставити рівним `null`, чи порожньому рядку, для того щоб ASF не використовував префікси команд, тоді ви зможете вводити команди просто за їх ідентифікатором. Однак, якщо ви це зробите - це може знизити продуктивність роботи ASF, тому що ASF оптимізовано не обробляти повідомлення, які не починаються з `CommandPrefix` - якщо ви навмисно вирішите не користуватися ним, ASF буде змушеним читати усі повідомлення і відповідати на них, навіть якщо вони не є командами ASF. Тому ми радимо користуватися якимось `CommandPrefix`, наприклад `/`, якщо вам не подобається префікс `!`, заданий за замовчуванням. Для однаковості, `CommandPrefix` впливає на увесь процес ASF. Якщо у вас немає підстав змінювати цей параметр, вам варто залишити йому значення за замовчуванням.

---

### `ConfirmationsLimiterDelay`

параметр типу `byte` зі значенням за замовчуванням `10`. ASF буде забезпечувати щоб між двома послідовними запитами на підтвердження за допомогою ASF пройшло щонайменше `ConfirmationsLimiterDelay` секунд, щоб уникнути активації обмеження на частоту запитів - такі запроси використовуються **[2ФА ASF](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication-uk-UA)** під час, наприклад, команди `2faok`, а також по мірі необхідності під час виконання різноманітних операцій, пов'язаних з обмінами. Значення за замовчуванням встановлено на основі наших випробувань, і не повинно бути зменшено якщо ви бажаєте уникнати проблем. Якщо у вас немає **вагомих** підстав змінювати цей параметр, вам варто залишити йому значення за замовчуванням.

---

### `ConnectionTimeout`

параметр типу `byte` зі значенням за замовчуванням `90`. Цей параметр визначає тайм-аути в секундах для різноманітних мережевих операцій, які виконує ASF. Зокрема, `ConnectionTimeout` визначає тайм-аут в секундах для запитів по HTTP та IPC, `ConnectionTimeout/10` визначає найбільше число невдалих запитів heartbeat, а `ConnectionTimeout / 30` визначає число хвилин, яке відведене на початковий запит з'єднання з мережею Steam. Значення за замовчуванням `90` має бути добрим для більшості людей, однак, якщо ви маєте дуже повільне з'єднання з мережею чи ПК, ви можете збільшити його на щось більше (наприклад, на `120`). Пам'ятайте, що більші значення не вирішать магічним способом повільність чи недоступність серверів Steam, немає сенсу довіку чекати на щось, що ніколи не трапиться, краще спробувати ще раз пізніше. Якщо ви встановите завелике значення цьому параметру, це призведе до надмірних затримок у виявленні проблем з мережею, а також зменшить загальну продуктивність. Якщо ж ви встановите замале значення, це зменшить загальну стабільність та продуктивність також, бо ASF буде переривати вірні запити, які ще обробляються. Саме тому, зменшувати це значення нижче значення за замовчуванням не має загальних переваг, бо сервера Steam, час від часу бувають дуже повільні, і можуть вимагати більше часу на обробку запитів ASF. Значення за замовчуванням - це баланс між вірою, що наше з'єднання з мережею стабільне, і сумнівами, що мережа Steam обробить наш запит за визначений тайм-аут. Якщо ви бажаєте виявляти проблеми скоріше, і примусити ASF підключатися повторно/реагувати швидше, значення за замовчуванням вам підійде (або трішечки нижче, наприклад `60`, щоб зробити ASF менш терплячим). Якщо замість цього ви помічаєте, що ASF має проблеми з мережею, такі як невдалі запити, втрата heartbeat чи переривання з'єднання зі Steam, тоді ймовірно має сенс збільшити це значення, якщо ви певні що це пов'язане **не** з вашою мережею, а з самим Steam, бо збільшення тайм-аутів робить ASF більш "терплячим" замість того щоб відразу підключатися повторно.

Приклад ситуації, яка потребує збільшення цього параметру - коли ASF змушений працювати з дуже великою пропозицією обміну, яка може потребувати 2+ хвилини щоб бути цілком обробленою й прийнятою Steam. Якщо ви збільшите тайм-аут за замовчуванням, ASF буде більш терплячим, і буде чекати довше перш ніж вирішити що обмін не проходить і відмовитися від початкового запиту.

Інша ситуація - коли ви маєте дуже повільну машину чи інтернет-з'єднання, які потребують більше часу на обробку даних, які передаються. Це досить рідкісна ситуація, бо ЦП/мережа майже ніколи не бувають вузьким місцем, але це все ж таки можливість, яку варто згадати.

Коротше кажучи, значення за замовчуванням має бути задовільним для більшості випадків, але ви можете збільшити його в разі потреби. Однак, надмірно збільшувати значення за замовчуванням також не має сенсу, оскільки більші тайм-аути не вирішать магічним способом недоступність серверів Steam. Якщо у вас немає підстав змінювати цей параметр, вам варто залишити йому значення за замовчуванням.

---

### `CurrentCulture`

параметр типу `string` зі значенням за замовчуванням `null`. За замовчанням ASF намагається використовувати мову операційної системи, й буде намагатися використовувати перекладені цією мовою рядки, якщо вони наявні. Це можливо завдяки нашій спільноті, яка намагається **[локалізувати](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Localization-uk-UA)** ASF на усі найбільш популярні мови. Якщо з якихось причин ви не бажаєте використовувати мову вашої ОС, ви можете змінити цей параметр щоб обрати замість цього один з наявних перекладів. For a list of all available cultures, please visit **[MSDN](https://msdn.microsoft.com/en-us/library/cc233982.aspx)** and look for `Language tag`. It's nice to note that ASF accepts both specific cultures, such as `"en-GB"`, but also neutral ones, such as `"en"`. Вказана поточна культура буде також впливати на інші культурні особливості, такі як формат валюти/дати і таке інше. Будь ласка, зверніть увагу, що вам можуть знадобитися додаткові шрифти/мовні пакети для вірного відображення символів обраної мови, якщо ви обрали мову, яка відрізняється від системної та використовує такі символи. Зазвичай цей параметр вам знадобиться якщо ви бажаєте користуватися ASF англійською мовою, замість вашої рідної мови.

---

### `Debug`

параметр типу `bool` зі значенням за замовчуванням `false`. Цей параметр визначає, чи повинен процес працювати у режимі налагодження. ASF у режимі налагодження створює спеціальний каталог `debug` поруч з каталогом `config`, у якому повністю відстежую усі обміни між ASF та серверами Steam. Інформація, зібрана у режимі налагодження, може допомогти знайти неприємні помилки, пов'язані з мережею та загальною роботою ASF. На додаток, деякі частини програми будуть виводити більш докладну інформацію, наприклад `WebBrowser` буде виводити конкретні причини помилок - така інформація потрапляє до звичайного журналу ASF. **Не варто запускати ASF у режимі налагодження, окрім випадків коли про це вас попрохав розробник**. Робота ASF у режимі налагодження **знижує продуктивність**, **негативно впливає на стабільність** і **виводить значно більш докладну інформацію у багатьох місцях**, тому використовувати цей режим є сенс **тільки** з якоюсь метою, короткочасно, для вирішення конкретних питань, відтворення якоїсь проблеми чи для збору інформації про якійсь помилковий запит, і таке інше, але **не** для нормальної роботи програми. Ви побачите **багато** нових помилок, проблем та винятків - переконайтеся, що ви маєте глибокі знання щодо ASF, Steam та його глюків, якщо ви вирішили аналізувати все це самостійно, тому що не все це актуально.

**ПОПЕРЕДЖЕННЯ:** при ввімкненні цього режиму відбувається журналювання **потенційно конфіденційної** інформації, як то логіни та паролі які ви використовуєте для входу у Steam (через журналювання мережевих запитів). Ці дані записуються як у каталог `debug`, так і у звичайний `log.txt` (який у цьому режимі навмисно більш детальний для включення цієї інформації). Ви не повинні викладати інформацію, створену ASF у цьому режимі, у будь які загальнодоступні місця, розробник ASF завжди нагадає вам надіслати її йому на e-mail, або іншим безпечним шляхом. Ми не зберігаємо і ніяк не користуємося цією конфіденційною інформацією, вона записується як частина процесу отладки, оскільки її наявність може мати відношення до проблеми, з якою ви зіткнулися. Ми воліли б щоб ви не змінювали журнали ASF у будь-який спосіб, але якщо ви стурбовані, ви можете відповідно відредагувати ці конфіденційні дані.

> Редагування включає в себе заміну конфіденційних даних, наприклад на зірочки. Ви повинні утримуватися від повного видалення рядків з конфіденційною інформацією, тому що навіть їх наявність може бути важливою, і тому їх варто зберігти.

---

### `DefaultBot`

параметр типу `string` зі значенням за замовчуванням `null`. In some scenarios ASF functions with a concept of a default bot responsible for handling something - for example IPC commands or interactive console when you don't specify target bot. This property allows you to choose default bot responsible for handling such scenarios, by putting its `BotName` here. If given bot doesn't exist, or you use a default value of `null`, ASF will pick first registered bot sorted alphabetically instead. Typically you want to make use of this config property if you want to omit `[Bots]` argument in IPC and interactive console commands, and always pick the same bot as the default one for such calls.

---

### `FarmingDelay`

параметр типу `byte` зі значенням за замовчуванням `15`. Для забезпечення роботи ASF буде кожні `FarmingDelay` хвилин перевіряти чи не випали вже усі картки з поточної гри. Якщо ви встановите замале значення для цього параметру - це призведе до відправки надмірної кількості запитів до steam, а якщо завелике - це може призвести до того що ASF "фармитиме" якусь гру аж до `FarmingDelay` зайвих хвилин після того, як усі картки отримано. Значення за замовчуванням має бути чудовим для більшості користувачів, але якщо ви запускаєте дуже багато ботів, ви можете розглянути потребу збільшити його до чогось подібного `30` хвилинам, щоб обмежити кількість відправлених запитів до steam. Ми раді відзначити, що ASF використовує механізм обробки подій, і перевіряє сторінку значка кожен раз, як випадає якійсь предмет Steam, тож в загалі **не потрібно перевіряти його через постійний інтервал часу**, але оскільки ми не довіряємо цілком мережі Steam - ми все одно перевірятимемо сторінку значка, навіть якщо ми не отримали події випадення картки протягом останніх `FarmingDelay` хвилин (на випадок якщо Steam не повідомить нас про випадення предмету, або щось подібне). Якщо мережа Steam працює коректно, зменшення значення цього параметру **жодним чином не покращить швидкість фарму**, і у той самий час **значно підвищить навантаження на мережу** - тому ми рекомендуємо лише збільшувати його (при необхідності) більше `15` хвилин, встановлених за замовчуванням. Якщо у вас немає **вагомих** підстав змінювати цей параметр, вам варто залишити йому значення за замовчуванням.

---

### `FilterBadBots`

параметр типу `bool` зі значенням за замовчуванням `true`. This property defines whether ASF will automatically decline trade offers that are received from known and marked bad actors. In order to do that, ASF will communicate with our server on as-needed basis to fetch a list of blacklisted Steam identificators. The bots listed are operated by people that are classified as harmful towards ASF initiative by us, such as those that violate our **[code of conduct](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/.github/CODE_OF_CONDUCT.md)**, use provided functionality and resources by us such as **[`PublicListing`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#publiclisting)** in order to abuse and exploit other people, or are doing outright criminal activity such as launching DDoS attacks on the server. Since ASF has strong stance on overall fairness, honesty and cooperation between its users in order to make the whole community thrive, this property is enabled by default, and therefore ASF filters bots that we've classified as harmful from services offered. Unless you have a **strong** reason to edit this property, such as disagreeing with our statement and intentionally allowing those bots to operate (including exploiting your accounts), you should keep it at default.

---

### `GiftsLimiterDelay`

параметр типу `byte` зі значенням за замовчуванням `1`. ASF буде забезпечувати щоб між послідовними запитами на обробку(активацію) ключів/подарунків/ліцензій пройшло щонайменше `GiftsLimiterDelay` секунд, для того щоб уникнути активації обмеження на частоту запитів. In addition to that it'll also be used as global limiter for game list requests, such as the one issued by `owns` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Unless you have a **strong** reason to edit this property, you should keep it at default.

---

### `Headless`

параметр типу `bool` зі значенням за замовчуванням `false`. Цей параметр визначає, чи повинен процес працювати у безинтерфейсному режимі. У безинтерфейсному режимі ASF вважає, що його запущено на сервері, або у іншому не-інтерактивному середовищі, і тому не намагатиметься отримати якусь інформацію через вхідну консоль. До такої інформації відносяться дані за запитом (дані облікових записів, такі як код 2ФА, код SteamGuard, пароль, чи інші значення, потрібні для роботи ASF) а також інший консольний ввід (такий як інтерактивна консоль команд). Інакше кажучи, режим `Headless` рівнозначний до переводу консолі ASF у режим тільки для читання. Це налаштування головним чином корисне для користувачів, які запускають ASF на своїх серверах, оскільки замість запитів для, наприклад, коду 2ФА, ASF мовчки буде переривати операцію і зупиняти бота. За випадком ситуації, коли ви запускаете ASF на сервері, і спочатку перевірили що ASF в змозі працювати у звичайному режимі, вам варто залишити цей параметр вимкненим. Any user interaction will be denied when in headless mode, and your accounts will not run if they require **any** console input during starting. Це корисно для серверів, бо ASF може припинити намагатися увійти до облікового запису якщо потрібен запит облікових даних, замість очікування (довіку) що користувач їх введе. Enabling this mode will also allow you to use `input` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** which acts as a replacement for standard console input. Якщо ви не впевнені, яке значення встановити цьому параметру, залиште йому значення за замовчуванням `false`.

If you're running ASF on the server, you probably want to use this option together with `--process-required` **[command-line argument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments)**.

---

### `IdleFarmingPeriod`

параметр типу `byte` зі значенням за замовчуванням `8`. Коли ASF нема чого робити, воно перевірятиме кожні `IdleFarmingPeriod` годин, чи не з'явилися на обліковому записі нові ігри з яких можна отримати картки. Це не потрібно якщо ми маємо на увазі нові ігри, які ми отримали, бо ASF досить розумне щоб автоматично перевіряти сторінку зі значками у такому разі. `IdleFarmingPeriod` головним чином для ситуацій, коли до старих ігор, які ми вже маємо, було додано колекційні картки. У такому разі не утворюється подія, тому ASF має періодично перевіряти сторінку зі значками, якщо ми бажаємо обробити цю ситуацію. Значення `0` вимкне цей функціонал. Також дивіться: `ShutdownOnFarmingFinished`.

---

### `InventoryLimiterDelay`

`byte` type with default value of `4`. ASF will ensure that there will be at least `InventoryLimiterDelay` seconds in between of two consecutive inventory requests to avoid triggering rate-limit - those are being used for fetching Steam inventories, especially during your own commands such as `loot` or `transfer`. Default value of `4` was set based on fetching inventories of over 100 consecutive bot instances, and should satisfy most (if not all) of the users. Однак ви можете захотіти зменшити це значення, або навіть змінити його на `0` якщо в вас дуже мала кількість ботів, для того щоб ASF не зважало на затримки і обробляло інвентарі steam значно швидше. Однак майте на увазі, що занадто низке значення **обов'язково** призведе до тимчасового бану вашого IP з боку Steam, і ви взагалі не матимете доступу до інвентарів. Також вам може бути потрібно збільшити це значення якщо ви використовуєте багато ботів у яких багато запитів до інвентарю, хоча у цьому випадку вам мабуть варто замість цього зменшити кількість таких запитів. Якщо у вас немає **вагомих** підстав змінювати цей параметр, вам варто залишити йому значення за замовчуванням.

---

### `IPC`

параметр типу `bool` зі значенням за замовчуванням `true`. Цей параметр визначає, чи буде **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-uk-UA)** сервер ASF запускатися при старті процесу. IPC allows for inter-process communication, including usage of **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)**, by booting a local HTTP server. If you do not intend to use any third-party IPC integration with ASF, including our ASF-ui, you can safely disable this option. Otherwise, it's a good idea to keep it enabled (default option).

---

### `IPCPassword`

параметр типу `string` зі значенням за замовчуванням `null`. Цей параметр визначає обов'язковий пароль для кожного запита API крізь IPC й виступає додатковим заходом безпеки. Якщо йому встановлено не пусте значення, усі запити крізь IPC вимагатимуть додаткового параметру `password` з паролем, вказаним тут. Значення за замовчуванням `null` відміняє необхідність пароля, і тому ASF обробляє усі запити. На додаток до цього, завдання цього параметру також вмикає вбудований в IPC механізм захисту від перебору, який буде тимчасово банити окремий `IPAddress` якщо він надіслав забагато неавторизованих запитів за дуже короткий час. Якщо у вас немає підстав змінювати цей параметр, вам варто залишити йому значення за замовчуванням.

---

### `IPCPasswordFormat`

параметр типу `byte` зі значенням за замовчуванням `0`. This property defines the format of `IPCPassword` property and uses `EHashingMethod` as underlying type. Please refer to **[Security](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security)** section if you want to learn more, as you'll need to ensure that `IPCPassword` property indeed includes password in matching `IPCPasswordFormat`. In other words, when you change `IPCPasswordFormat` then your `IPCPassword` should be **already** in that format, not just aiming to be. Unless you know what you're doing, you should keep it with default value of `0`.

---

### `LicenseID`

`Guid?` type with default value of `null`. This property allows our **[sponsors](https://github.com/sponsors/JustArchi)** to enhance ASF with optional features that require paid resources to work. For now, this allows you to make use of **[`MatchActively`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#matchactively)** feature in `ItemsMatcher` plugin.

While we recommend you to utilize GitHub since it offers monthly and one-time tiers, as well as allows full automation and gives you immediate access, we **also** support all other currently-available **[donation options](https://github.com/JustArchiNET/ArchiSteamFarm#archisteamfarm)**. See **[this post](https://github.com/JustArchiNET/ArchiSteamFarm/discussions/2780#discussioncomment-4486091)** for instructions on how to donate using other methods in order to get a manual license valid for given period.

Regardless of the method used, if you're ASF sponsor, you can obtain your license **[here](https://asf.justarchi.net/User/Status)**. You'll need to sign in with GitHub for confirming your identity, we ask only for read-only public information, which is your username. `LicenseID` is made out of 32 hexadecimal characters, such as `f6a0529813f74d119982eb4fe43a9a24`.

**Ensure that you do not share your `LicenseID` with other people**. Since it's issued on personal basis, it might get revoked if it's leaked. If by any chance this happened to you accidentally, you can generate a new one from the same place.

Unless you want to enable extra ASF functionalities, there is no need for you to provide the license.

---

### `LoginLimiterDelay`

параметр типу `byte` зі значенням за замовчуванням `10`. ASF буде забезпечувати щоб між послідовними спробами підключитися пройшло щонайменше `LoginLimiterDelay` секунд, для того щоб уникнути активації обмеження на частоту запитів. Значення за замовчуванням `10` було обрано на базі підключення більш ніж 100 ботів, і має задовольнити більшість (якщо не усіх) користувачів. Однак ви можете захотіти збільшити/зменшити це значення, або навіть змінити його на `0` якщо в вас дуже мала кількість ботів, для того щоб ASF не зважало на затримки і підключалося до Steam значно швидше. Однак маємо вас попередити, що занадто низькі значення при великій кількості ботів **призведе** до тимчасового блокування вашого IP, і ви не зможете увійти до Steam **взагалі**, й отримаєте помилку `InvalidPassword/RateLimitExceeded` - і це також включає ваш звичайний клієнт Steam, а не тільки ASF. Так само, якщо у вас забагато ботів, особливо у поєднанні з іншими клієнтами/інструментами для Steam, які працюють з тієї ж IP-адреси, швидше за все вам знадобиться збільшити це значення, щоб рознести логіни на більший період часу.

Додатково, це значення також використовується для буфер балансування навантаження в усіх запланованих діях ASF, наприклад таких як пропозиції обміну через `SendTradePeriod`. Якщо у вас немає **вагомих** підстав змінювати цей параметр, вам варто залишити йому значення за замовчуванням.

---

### `MaxFarmingTime`

параметр типу `byte` зі значенням за замовчуванням `10`. As you should know, Steam is not always working properly, sometimes weird situations can happen such as our playtime not being recorded, despite of, in fact, playing a game. ASF буде фармити одну гру у соло-режимі максимум `MaxFarmingTime` годин, а після цього періоду вважатиме, що фарм для неї завершений. Це необхідно щоб процес фарма не застряг у разі якихось дивних ситуацій, а також на випадок, коли Steam випустив значок, який заважає ASF працювати далі (дивись також: `Blacklist`). Значення за замовчуванням у `10` годин має бути достатньо для отримання усіх карток з однієї гри. Занадто низьке значення може призвести до пропуску дійсних ігор (так, бувають ігри у яких фарм займає до 9 годин), а занадто високе значення призведе до застрягання фарму на довгий час. Зверніть увагу, що цей параметр впливає лише на поодиноку гру у одній сесії фарму (тож після обробки всієї черги ASF повернеться до цієї гри), а також він базується не на загальному часу у грі, а на внутрішньому часі фарму в ASF, тому ASF також повернеться до цієї гри після перезапуску. Якщо у вас немає **вагомих** підстав змінювати цей параметр, вам варто залишити йому значення за замовчуванням.

---

### `MaxTradeHoldDuration`

параметр типу `byte` зі значенням за замовчуванням `15`. Цей параметр визначає максимальну тривалість затримки обміну, при якій ми згодні його приймати - ASF буде відхиляти обміни, для яких затримка складає більше ніж `MaxTradeHoldDuration` діб, як описано у розділі **[Обміни](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading-uk-UA)**. Ця опція має сенс лише для ботів, у яких параметр `TradingPreferences` включає значення `SteamTradeMatcher`, оскільки він не впливає ані на обміни від `Master`/`SteamOwnerID`, ані на обміни у дарунок. Затримки обміну дратують усіх, тож ніхто не бажає мати з ними справу. ASF планувався для роботи по ліберальним правилам й допомоги усім, незалежно від затримок обміну, саме тому за замовчуванням цей параметр має значення `15`. Однак, якщо ви замість цього бажаєте відхилити всі обміни з затримками, ви можете вказати тут `0`. Будь ласка, зважте той факт що що цей параметр не впливає на картки з коротким строком дії, і такі обміни автоматично відхиляються для людей з затримками обміну, як це описано у розділі **[Обміни](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading-uk-UK)**, тож немає сенсу глобально відхиляти усіх лише через це. Якщо у вас немає підстав змінювати цей параметр, вам варто залишити йому значення за замовчуванням.


---

### `MinFarmingDelayAfterBlock`

параметр типу `byte` зі значенням за замовчуванням `60`. This property defines minimum amount of time, in seconds, which ASF will wait before resuming cards farming if it got previously disconnected with `LoggedInElsewhere`, which happens when you decide to forcefully disconnect currently-farming ASF by launching a game. This delay exists mainly for convenience and overhead reasons, for example it allows you to restart the game without having to fight with ASF occupying your account again only because playing lock was available for a split second. Due to the fact that reclaiming the session causes `LoggedInElsewhere` disconnect, ASF has to go through whole reconnect procedure, which puts additional pressure on the machine and Steam network, therefore avoiding additional disconnects, if possible, is preferable. By default, this is configured at `60` seconds, which should be enough to allow you restart the game without much hassle. However, there are scenarios when you could be interested in increasing it, for example if your network disconnects often and ASF is taking over too soon, which causes being forced to go through the reconnect process yourself. We allow a maximum value of `255` for this property, which should be enough for all common scenarios. In addition to the above, it's also possible to decrease the delay, or even remove it entirely with a value of `0`, although that is usually not recommended due to reasons stated above. Якщо у вас немає підстав змінювати цей параметр, вам варто залишити йому значення за замовчуванням.

---

### `OptimizationMode`

параметр типу `byte` зі значенням за замовчуванням `0`. Цей параметр визначає режим оптимізації, якого дотримується ASF протягом роботи. Наразі ASF підтримує два режими - `0` під назвою `MaxPerformance` (максимальна продуктивність), та `1` під назвою `MinMemoryUsage` (мінімальне вживання пам'яті). За замовчуванням ASF намагається робити якнайбільше задач паралельно (одночасно), що підвищує продуктивність через балансування навантаження на усіх ядрах ЦП, декількох потоках ЦП, декількох сокетах та декількох задачах пула потоків. For example, ASF will ask for your first badge page when checking for games to farm, and then once request arrived, ASF will read from it how many badge pages you actually have, then request each other one concurrently. Це саме те що вам потрібно **у більшості випадків**, тому що накладні витрати мінімальні а переваги від асинхронного коду ASF помітні навіть на дуже старому обладнанні з єдиним ядром ЦП та обмеженою потужністю. Однак, при роботі багатьох процесів паралельно, ASF має займатися їх підтримкою, тобто, підтримувати відкриті сокети, живі потоки та задачі, що іноді може призвести до збільшення вживання пам'яті, тож якщо ви надзвичайно обмежені обсягом пам'яті у наявності, ви можете змінити значення цього параметра на `1` (`MinMemoryUsage`), щоб змусити ASF використовувати якнайменше задач, і виконувати асинхронний код, який зазвичай виконується паралельно, у синхронний манір. You should consider switching this property only if you previously read **[low-memory setup](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup)** and you intentionally want to sacrifice gigantic performance boost, for a very small memory overhead decrease. Usually this option is **much worse** than what you can achieve with other possible ways, such as by limiting your ASF usage or tuning runtime's garbage collector, as explained in **[low-memory setup](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup)**. Therefore, you should use `MinMemoryUsage` as a **last resort**, right before runtime recompilation, if you couldn't achieve satisfying results with other (much better) options. Unless you have a **strong** reason to edit this property, you should keep it at default.

---

### `SteamMessagePrefix`

параметр типу `string` зі значенням за замовчуванням `"/me"`. Цей параметр визначає префікс, який додаватиметься до усіх повідомлень Steam, які відправляє ASF. За замовчуванням ASF використовує префікс `"/me "`, щоб повідомлення від ботів було легше відрізнити у чаті Steam за іншим кольором. Інша гарна можливість - це префікс `"/pre "`, який дає подібний результат, але використовує інше форматування. Ви також можете встановити цьому параметру значення `null` або порожній рядок, щоб цілком вимкнути будь-які префікси та відображати повідомлення від ASF як звичайні. Варто додати, що цей параметр впливає лише на повідомлення у Steam - відповіді, отримані у інший спосіб (наприклад крізь IPC) не змінюються. Якщо ви не хочете змінювати стандартну поведінку ASF - варто залишити його значення за замовчуванням.

---

### `SteamOwnerID`

`ulong` type with default value of `0`. This property defines Steam ID in 64-bit form of ASF process owner, and is very similar to `Master` permission of given bot instance (but global instead). You almost always want to set this property to ID of your own main Steam account. `Master` permission includes full control over his bot instance, but global commands such as `exit`, `restart` or `update` are reserved for `SteamOwnerID` only. This is convenient, as you may want to run bots for your friends, while not allowing them to control ASF process, such as exiting it via `exit` command. Default value of `0` specifies that there is no owner of ASF process, which means that nobody will be able to issue global ASF commands. Keep in mind that this property applies to Steam chat exclusively. **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)**, as well as interactive console, will still allow you to execute `Owner` commands even if this property is not set.

---

### `SteamProtocols`

`byte flags` type with default value of `7`. This property defines Steam protocols that ASF will use when connecting to Steam servers, which are defined as below:

| Value | Ім'я      | Description                                                                                      |
| ----- | --------- | ------------------------------------------------------------------------------------------------ |
| 0     | Не обрано | No protocol                                                                                      |
| 1     | TCP       | **[Transmission Control Protocol](https://en.wikipedia.org/wiki/Transmission_Control_Protocol)** |
| 2     | UDP       | **[User Datagram Protocol](https://en.wikipedia.org/wiki/User_Datagram_Protocol)**               |
| 4     | WebSocket | **[WebSocket](https://en.wikipedia.org/wiki/WebSocket)**                                         |

Please notice that this property is `flags` field, therefore it's possible to choose any combination of available values. Check out **[json mapping](#json-mapping)** if you'd like to learn more. Not enabling any of flags results in `None` option, and that option is invalid by itself.

By default ASF will use all available Steam protocols as a measure for fighting with downtimes and other similar Steam issues. Typically you want to change this property if you want to limit ASF into using only one or two specific protocols. Such measure could be needed if you're e.g. enabling only TCP traffic on your firewall and you do not want ASF to try connecting via UDP. However, unless you're debugging particular problem or issue, you almost always want to ensure that ASF is free to use any protocol that is currently supported and not just one or two. Якщо у вас немає **вагомих** підстав змінювати цей параметр, вам варто залишити йому значення за замовчуванням.

---

### `UpdateChannel`

параметр типу `byte` зі значенням за замовчуванням `1`. This property defines update channel which is being used, either for auto-updates (if `UpdatePeriod` is greater than `0`), or update notifications (otherwise). Currently ASF supports three update channels - `0` which is called `None`, `1`, which is called `Stable`, and `2`, which is called `Experimental`. `Stable` channel is the default release channel, which should be used by majority of users. `Experimental` channel in addition to `Stable` releases, also includes **pre-releases** dedicated for advanced users and other developers in order to test new features, confirm bugfixes or give feedback about planned enhancements. **Experimental versions often contain unpatched bugs, work-in-progress features or rewritten implementations**. If you don't consider yourself advanced user, please stay with default `1` (`Stable`) update channel. `Experimental` channel is dedicated to users who know how to report bugs, deal with issues and give feedback - no technical support will be given. Check out ASF **[release cycle](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Release-cycle)** if you'd like to learn more. You can also set `UpdateChannel` to `0` (`None`), if you want to completely remove all version checks. Setting `UpdateChannel` to `0` will entirely disable entire functionality related to updates, including `update` command. Using `None` channel is **strongly discouraged** due to exposing yourself to all sort of problems (mentioned in `UpdatePeriod` description below).

**Unless you know what you're doing**, we **strongly** recommend to keep it at default.

---

### `UpdatePeriod`

параметр типу `byte` зі значенням за замовчуванням `24`. This property defines how often ASF should check for auto-updates. Updates are crucial not only to receive new features and critical security patches, but also to receive bugfixes, performance enhancements, stability improvements and more. When a value greater than `0` is set, ASF will automatically download, replace, and restart itself (if `AutoRestart` permits) when new update is available. In order to achieve this, ASF will check every `UpdatePeriod` hours if new update is available on our GitHub repo. A value of `0` disables auto-updates, but still allows you to execute `update` command manually. You may also be interested in setting appropriate `UpdateChannel` that `UpdatePeriod` should follow.

Update process of ASF involves update of entire folder structure that ASF is using, but without touching your own configs or databases located in `config` directory - this means that any extra files unrelated to ASF in its directory can be lost during update. Default value of `24` is a good balance between unnecessary checks, and ASF that is fresh enough.

Unless you have a **strong** reason to disable this feature, you should keep auto-updates enabled within reasonable `UpdatePeriod` **for your own good**. This is not only because we don't support anything but latest stable ASF release, but also because **we give our security guarantee only for latest version**. If you're using outdated ASF version then you're intentionally exposing yourself to all kind of issues, from small bugs, through broken functionality, ending with **[permanent Steam account suspensions](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#did-somebody-get-banned-for-it)**, so we **strongly recommend**, for your own good, to always ensure that your ASF version is up to date. Auto-updates allow us to react quickly to all kind of issues by disabling or patching problematic code before it can escalate - if you opt out of it, you lose all of our security guarantees and risk consequences from running code that could be potentially harmful, not only to Steam network, but also (by definition) to your own Steam account.

---

### `WebLimiterDelay`

`ushort` type with default value of `300`. This property defines, in miliseconds, the minimum amount of delay between sending two consecutive requests to the same Steam web-service. Such delay is required as **[AkamaiGhost](https://www.akamai.com)** service that Steam uses internally includes rate-limiting based on global number of requests sent across given time period. In normal circumstances akamai block is rather hard to achieve, but under very heavy workloads with a huge ongoing queue of requests, it's possible to trigger it if we keep sending too many requests across too short time period.

Default value was set based on assumption that ASF is the only tool accessing Steam web-services, in particular `steamcommunity.com`, `api.steampowered.com` and `store.steampowered.com`. If you're using other tools sending requests to the same web-services then you should make sure that your tool includes similar functionality of `WebLimiterDelay` and set both to double of default value, which would be `600`. This guarantees that under no circumstance you'll exceed sending more than 1 request per `300` ms.

In general, lowering `WebLimiterDelay` under default value is **strongly discouraged** as it could lead to various IP-related blocks, some of which are possible to be permanent. Default value is good enough for running a single ASF instance on the server, as well as using ASF in normal scenario along with original Steam client. It should be correct for majority of usages, and you should only increase it (never lower it). In short, global number of all requests sent from a single IP to a single Steam domain should never exceed more than 1 request per `300` ms.

Якщо у вас немає підстав змінювати цей параметр, вам варто залишити йому значення за замовчуванням.

---

### `WebProxy`

параметр типу `string` зі значенням за замовчуванням `null`. This property defines a web proxy address that will be used for all internal http and https requests sent by ASF's `HttpClient`, especially to services such as `github.com`, `steamcommunity.com` and `store.steampowered.com`. Proxying ASF requests in general has no advantages, but it's exceptionally useful for bypassing various kinds of firewalls, especially the great firewall in China.

This property is defined as uri string:

> A URI string is composed of a scheme (supported: http/https/socks4/socks4a/socks5), a host, and an optional port. An example of a complete uri string is `"http://contoso.com:8080"`.

If your proxy requires user authentication, you will also need to set up `WebProxyUsername` and/or `WebProxyPassword`. If there is no such need, setting up this property alone is sufficient.

Right now ASF uses web proxy only for `http` and `https` requests, which **do not** include internal Steam network communication done within ASF's internal Steam client. There are currently no plans for supporting that, mainly due to missing **[SK2](https://github.com/SteamRE/SteamKit/issues/587#issuecomment-413271550)** functionality. If you need/want it to happen, I'd suggest starting from there.

Якщо у вас немає підстав змінювати цей параметр, вам варто залишити йому значення за замовчуванням.

---

### `WebProxyPassword`

параметр типу `string` зі значенням за замовчуванням `null`. This property defines password field used in basic, digest, NTLM, and Kerberos authentication that is supported by a target `WebProxy` machine providing proxy functionality. If your proxy doesn't require user credentials, there is no need for you to input anything here. Using this option makes sense only if `WebProxy` is used as well, as it has no effect otherwise.

Якщо у вас немає підстав змінювати цей параметр, вам варто залишити йому значення за замовчуванням.

---

### `WebProxyUsername`

параметр типу `string` зі значенням за замовчуванням `null`. This property defines username field used in basic, digest, NTLM, and Kerberos authentication that is supported by a target `WebProxy` machine providing proxy functionality. If your proxy doesn't require user credentials, there is no need for you to input anything here. Using this option makes sense only if `WebProxy` is used as well, as it has no effect otherwise.

Якщо у вас немає підстав змінювати цей параметр, вам варто залишити йому значення за замовчуванням.

---

## Конфігурація боту

As you should know already, every bot should have its own config based on example JSON structure below. Start from deciding how you want to name your bot (e.g. `1.json`, `main.json`, `primary.json` or `AnythingElse.json`) and head over to configuration.

**Notice:** Bot can't be named `ASF` (as that keyword is reserved for global config), ASF will also ignore all configuration files starting with a dot.

The bot config has following structure:

```json
{
    "AcceptGifts": false,
    "AutoSteamSaleEvent": false,
    "BotBehaviour": 0,
    "CompleteTypesToSend": [],
    "CustomGamePlayedWhileFarming": null,
    "CustomGamePlayedWhileIdle": null,
    "Enabled": false,
    "EnableRiskyCardsDiscovery": false,
    "FarmingOrders": [],
    "FarmPriorityQueueOnly": false,
    "GamesPlayedWhileIdle": [],
    "HoursUntilCardDrops": 3,
    "LootableTypes": [1, 3, 5],
    "MatchableTypes": [5],
    "OnlineFlags": 0,
    "OnlineStatus": 1,
    "PasswordFormat": 0,
    "Paused": false,
    "RedeemingPreferences": 0,
    "RemoteCommunication": 3,
    "SendOnFarmingFinished": false,
    "SendTradePeriod": 0,
    "ShutdownOnFarmingFinished": false,
    "SkipRefundableGames": false,
    "SteamLogin": null,
    "SteamMasterClanID": 0,
    "SteamParentalCode": null,
    "SteamPassword": null,
    "SteamTradeToken": null,
    "SteamUserPermissions": {},
    "TradeCheckPeriod": 60,
    "TradingPreferences": 0,
    "TransferableTypes": [1, 3, 5],
    "UseLoginKeys": true,
    "UserInterfaceMode": 0
}
```

---

Усі параметри описані нижче:

### `AcceptGifts`

параметр типу `bool` зі значенням за замовчуванням `false`. When enabled, ASF will automatically accept and redeem all steam gifts (including wallet gift cards) sent to the bot. This includes also gifts sent from users other than those defined in `SteamUserPermissions`. Keep in mind that gifts sent to e-mail address are not directly forwarded to the client, so ASF won't accept those without your help.

This option is recommended only for alt accounts, as it's very likely that you don't want to automatically redeem all gifts sent to your primary account. If you're unsure whether you want this feature enabled or not, keep it with default value of `false`.

---

### `AutoSteamSaleEvent`

параметр типу `bool` зі значенням за замовчуванням `false`. During Steam summer/winter sale events Steam is known for providing you extra cards for browsing discovery queue each day, as well as through other event-specific activities. When this option is enabled, ASF will automatically check Steam discovery queue each `8` hours (starting in one hour since program start), and clear it if needed. This option is not recommended if you want to do that action yourself, and typically it should make sense only on bot accounts. Moreover, you need to ensure that your account is at least of level `8` if you expect to receive those cards in the first place, which comes directly as Steam requirement. If you're unsure whether you want this feature enabled or not, keep it with default value of `false`.

Please note that due to constant Valve issues, changes and problems, **we give no guarantee whether this function will work properly**, therefore it's entirely possible that this option **will not work at all**. We do not accept **any** bug reports, neither support requests for this option. It's offered with absolutely no guarantees, you're using it at your own risk.

---

### `BotBehaviour`

`byte flags` type with default value of `0`. This property defines ASF bot-like behaviour during various events, and is defined as below:

| Value | Ім'я                          | Description                                                                                              |
| ----- | ----------------------------- | -------------------------------------------------------------------------------------------------------- |
| 0     | Не обрано                     | No special bot behaviour, the least invasive mode, default                                               |
| 1     | RejectInvalidFriendInvites    | Will cause ASF to reject (instead of ignoring) invalid friend invites                                    |
| 2     | RejectInvalidTrades           | Will cause ASF to reject (instead of ignoring) invalid trade offers                                      |
| 4     | RejectInvalidGroupInvites     | Will cause ASF to reject (instead of ignoring) invalid group invites                                     |
| 8     | DismissInventoryNotifications | Will cause ASF to automatically dismiss all inventory notifications                                      |
| 16    | MarkReceivedMessagesAsRead    | Will cause ASF to automatically mark all received messages as read                                       |
| 32    | MarkBotMessagesAsRead         | Will cause ASF to automatically mark messages from other ASF bots (running in the same instance) as read |

Please notice that this property is `flags` field, therefore it's possible to choose any combination of available values. Check out **[json mapping](#json-mapping)** if you'd like to learn more. Not enabling any of flags results in `None` option.

In general you want to modify this property if you expect from ASF to do certain amount of automation related to its activity, as it'd be expected from a bot account, but not a primary account used in ASF. Therefore, changing this property makes sense mainly for alt accounts, although you're free to use selected options for main accounts as well.

Normal (`None`) ASF behaviour is to only automate things that user wants (e.g. cards farming or `SteamTradeMatcher` offers processing, if set in `TradingPreferences`). This is the least invasive mode, and it's beneficial to majority of users since you remain in full control over your account and you can decide yourself whether to allow certain out-of-scope interactions, or not.

Invalid friend invite is an invite that doesn't come from user with `FamilySharing` permission (defined in `SteamUserPermissions`) or above. ASF in normal mode ignores those invites, as you'd expect, giving you free choice whether to accept them, or not. `RejectInvalidFriendInvites` will cause those invites to be automatically rejected, which will practically disable option for other people to add you to their friend list (as ASF will deny all such requests, apart from people defined in `SteamUserPermissions`). Unless you want to outright deny all friend invites, you shouldn't enable this option.

Invalid trade offer is an offer that isn't accepted through built-in ASF module. More on this matter can be found in **[trading](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading)** section which explicitly defines what types of trade ASF is willing to accept automatically. Valid trades are also defined by other settings, especially `TradingPreferences`. `RejectInvalidTrades` will cause all invalid trade offers to be rejected, instead of being ignored. Unless you want to outright deny all trade offers that aren't automatically accepted by ASF, you shouldn't enable this option.

Invalid group invite is an invite that doesn't come from `SteamMasterClanID` group. ASF in normal mode ignores those group invites, as you'd expect, allowing you to decide yourself if you want to join particular Steam group or not. `RejectInvalidGroupInvites` will cause all those group invites to be automatically rejected, effectively making it impossible to invite you to any other group than `SteamMasterClanID`. Unless you want to outright deny all group invites, you shouldn't enable this option.

`DismissInventoryNotifications` is extremely useful when you start getting annoyed by constant Steam notification about receiving new items. ASF can't get rid of the notification itself, as that's built-in into your Steam client, but it's able to automatically clear the notification after receiving it, which will no longer leave "new items in inventory" notification hanging around. If you expect to evaluate yourself all received items (especially cards farmed with ASF), then naturally you shouldn't enable this option. When you start going crazy, remember this is offered as an option.

`MarkReceivedMessagesAsRead` will automatically mark **all** messages being received by the account on which ASF is running, both private and group, as read. This typically should be used by alt accounts only in order to clear "new message" notification coming e.g. from you during executing ASF commands. We do not recommend this option for primary accounts, unless you want to cut yourself from any kind of new messages notifications, **including** those that happened while you were offline, assuming that ASF was still left open dismissing it.

`MarkBotMessagesAsRead` works in a similar manner by marking only bot messages as read. However, keep in mind that when using that option on group chats with your bots and other people, Steam implementation of acknowledging chat message **also** acknowledges all messages that happened **before** the one you decided to mark, so if by any chance you don't want to miss unrelated message that happened in-between, you typically want to avoid using this feature. Obviously, it's also risky when you have multiple primary accounts (e.g. from different users) running in the same ASF instance, as you can also miss their normal out-of-ASF messages.

If you're unsure how to configure this option, it's best to leave it at default.

---

### `CompleteTypesToSend`

параметр типу `ImmutableHashSet<byte>` з пустим значенням за замовчуванням. When ASF is done with completing a given set of item types specified here, it can automatically send steam trade with all finished sets to the user with `Master` permission, which is very convenient if you'd like to utilize given bot account for e.g. STM matching, while moving finished sets to some other account. This option works the same as `loot` command, therefore keep in mind that it requires user with `Master` permission set, you may also need a valid `SteamTradeToken`, as well as using an account that is eligible for trading in the first place.

As of today, the following item types are supported in this setting:

| Value | Ім'я            | Description                                                   |
| ----- | --------------- | ------------------------------------------------------------- |
| 3     | FoilTradingCard | Foil variant of `TradingCard`                                 |
| 5     | TradingCard     | Steam trading card, being used for crafting badges (non-foil) |

Please note that regardless of the settings above, ASF will only ask for Steam (`appID` of 753) community (`contextID` of 6) items, so all game items, gifts and likewise, are excluded from the trade offer by definition.

Due to additional overhead of using this option, it's recommended to use it only on bot accounts that have a realistic chance of finishing sets on their own - for example, it makes no sense to activate if you're already using `SendOnFarmingFinished`, `SendTradePeriod` or `loot` command on usual basis.

If you're unsure how to configure this option, it's best to leave it at default.

---

### `CustomGamePlayedWhileFarming`

параметр типу `string` зі значенням за замовчуванням `null`. When ASF is farming, it can display itself as "Playing non-steam game: `CustomGamePlayedWhileFarming`" instead of currently farmed game. This can be useful if you would like to let your friends know that you're farming, yet you don't want to use `OnlineStatus` of `Offline`. Please note that ASF cannot guarantee the actual display order of Steam network, therefore this is only a suggestion that may, or may not, display properly. In particular, custom name will not display in `Complex` farming algorithm if ASF fills all `32` slots with games requiring hours to be bumped. Default value of `null` disables this feature.

ASF provides a few special variables that you can optionally use in your text. `{0}` will be replaced by ASF with `AppID` of currently farmed game(s), while `{1}` will be replaced by ASF with `GameName` of currently farmed game(s).

---

### `CustomGamePlayedWhileIdle`

параметр типу `string` зі значенням за замовчуванням `null`. Similar to `CustomGamePlayedWhileFarming`, but for the situation when ASF has nothing to do (as account is fully farmed). Please note that ASF cannot guarantee the actual display order of Steam network, therefore this is only a suggestion that may, or may not, display properly. If you're using `GamesPlayedWhileIdle` together with this option, then keep in mind that `GamesPlayedWhileIdle` get priority, therefore you can't declare more than `31` of them, as otherwise `CustomGamePlayedWhileIdle` will not be able to occupy the slot for custom name. Default value of `null` disables this feature.

---

### `Enabled`

параметр типу `bool` зі значенням за замовчуванням `false`. This property defines if bot is enabled. Enabled bot instance (`true`) will automatically start on ASF run, while disabled bot instance (`false`) will need to be started manually. By default every bot is disabled, so you probably want to switch this property to `true` for all of your bots that should be started automatically.

---

### `EnableRiskyCardsDiscovery`

параметр типу `bool` зі значенням за замовчуванням `false`. This property enables additional fallback which triggers when ASF is unable to load one or more of badge pages and is therefore unable to find games available for farming. In particular, some accounts with massive amount of card drops might cause a situation where loading badge pages is no longer possible (due to overhead), and those accounts are impossible for farming purely because we can't load the information based on which we can start the process. For those handful cases, this option allows alternative algorithm to be used, which uses a combination of boosters possible to craft and booster packs the account is eligible for, in order to find potentially available games to idle, then spends excessive amount of resources for verifying and fetching required information, and attempts to start the process of farming on limited amount of data and information in order to eventually reach a situation when badge page loads and we'll be able to use normal approach. Please note that when this fallback is used, ASF operates only with limited data, therefore it's completely normal for ASF to find much less drops than in reality - other drops will be found at later stage of farming process.

This option is called "risky" for a very good reason - it's extremely slow and requires significant amount of resources (including network requests) for operation, therefore it's **not recommended** to be enabled, and especially in long-term. You should use this option only if you previously determined that your account suffers from being unable to load badge pages and ASF can't operate on it, always failing to load necessary information to start the process. Even if we made our best to optimize the process as much as possible, it's still possible for this option to backfire, and it might cause unwanted outcomes, such as temporary and maybe even permanent bans from Steam side for sending too many requests and otherwise causing overhead on Steam servers. Therefore, we warn you in advance and we're offering this option with absolutely no guarantees, you're using it at your own risk.

Unless you know what you're doing, you should keep it with default value of `false`.

---

### `FarmingOrders`

`ImmutableList<byte>` type with default value of being empty. This property defines the **preferred** farming order used by ASF for given bot account. Currently there are following farming orders available:

| Value | Ім'я                      | Description                                                                      |
| ----- | ------------------------- | -------------------------------------------------------------------------------- |
| 0     | Unordered                 | No sorting, slightly improving CPU performance                                   |
| 1     | AppIDsAscending           | Try to farm games with lowest `appIDs` first                                     |
| 2     | AppIDsDescending          | Try to farm games with highest `appIDs` first                                    |
| 3     | CardDropsAscending        | Try to farm games with lowest number of card drops remaining first               |
| 4     | CardDropsDescending       | Try to farm games with highest number of card drops remaining first              |
| 5     | HoursAscending            | Try to farm games with lowest number of hours played first                       |
| 6     | HoursDescending           | Try to farm games with highest number of hours played first                      |
| 7     | NamesAscending            | Try to farm games in alphabetical order, starting from A                         |
| 8     | NamesDescending           | Try to farm games in reverse alphabetical order, starting from Z                 |
| 9     | Random                    | Try to farm games in totally random order (different on each run of the program) |
| 10    | BadgeLevelsAscending      | Try to farm games with lowest badge levels first                                 |
| 11    | BadgeLevelsDescending     | Try to farm games with highest badge levels first                                |
| 12    | RedeemDateTimesAscending  | Try to farm oldest games on our account first                                    |
| 13    | RedeemDateTimesDescending | Try to farm newest games on our account first                                    |
| 14    | MarketableAscending       | Try to farm games with unmarketable card drops first                             |
| 15    | MarketableDescending      | Try to farm games with marketable card drops first                               |

Since this property is an array, it allows you to use several different settings in your fixed order. For example, you can include values of `15`, `11` and `7` in order to sort by marketable games first, then by those with highest badge level, and finally alphabetically. As you can guess, the order actually matters, as reverse one (`7`, `11` and `15`) achieves something entirely different (sorts games alphabetically first, and due to game names being unique, the other two are effectively useless). Majority of people will probably use just one order out of all of them, but in case you want to, you can also sort further by extra parameters.

Also notice the word "try" in all above descriptions - the actual ASF order is heavily affected by selected **[cards farming algorithm](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)** and sorting will affect only results that ASF considers same performance-wise. For example, in `Simple` algorithm, selected `FarmingOrders` should be entirely respected in current farming session (as every game has the same performance value), while in `Complex` algorithm actual order is affected by hours first, and then sorted according to chosen `FarmingOrders`. This will lead to different results, as games with existing playtime will have a priority over others, so effectively ASF will prefer games that already passed required `HoursUntilCardDrops` firstly, and only then sorting those games further by your chosen `FarmingOrders`. Likewise, once ASF runs out of already-bumped games, it'll sort remaining queue by hours first (as that will decrease time required for bumping any of remaining titles to `HoursUntilCardDrops`). Therefore, this config property is only a **suggestion** that ASF will try to respect, as long as it doesn't affect performance negatively (in this case, ASF will always prefer farming performance over `FarmingOrders`).

There is also farming priority queue that is accessible through `fq` **[commands](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. If it's used, actual farming order is sorted firstly by performance, then by farming queue, and finally by your `FarmingOrders`.

---

### `FarmPriorityQueueOnly`

параметр типу `bool` зі значенням за замовчуванням `false`. This property defines if ASF should consider for automatic farming only apps that you added yourself to priority farming queue available with `fq` **[commands](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. When this option is enabled, ASF will skip all `appIDs` that are missing on the list, effectively allowing you to cherry-pick games for automatic ASF farming. Keep in mind that if you didn't add any games to the queue then ASF will act as if there is nothing to farm on your account. If you're unsure whether you want this feature enabled or not, keep it with default value of `false`.

---

### `GamesPlayedWhileIdle`

параметр типу `ImmutableHashSet<uint>` з пустим значенням за замовчуванням. If ASF has nothing to farm it can play your specified steam games (`appIDs`) instead. Playing games in such manner increases your "hours played" of those games, but nothing else apart of it. In order for this feature to work properly, your Steam account **must** own a valid license to all the `appIDs` that you specify here, this includes F2P games as well. This feature can be enabled at the same time with `CustomGamePlayedWhileIdle` in order to play your selected games while showing custom status in Steam network, but in this case, like in `CustomGamePlayedWhileFarming` case, the actual display order is not guaranteed. Please note that Steam allows ASF to play only up to `32` `appIDs` total, therefore you can put only as many games in this property.

---

### `HoursUntilCardDrops`

параметр типу `byte` зі значенням за замовчуванням `3`. This property defines if account has card drops restricted, and if yes, for how many initial hours. Restricted card drops means that account is not receiving any card drops from given game until the game is played for at least `HoursUntilCardDrops` hours. Unfortunately there is no magical way to detect that, so ASF relies on you. This property affects **[cards farming algorithm](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)** that will be used. Setting this property properly will maximize profits and minimize time required for cards to be farmed. Remember that there is no obvious answer whether you should use one or another value, since it fully depends on your account. It seems that older accounts which never asked for refund have unrestricted card drops, so they should use a value of `0`, while new accounts and those who did ask for refund have restricted card drops with a value of `3`. This is however only theory, and should not be taken as a rule. The default value for this property was set based on "lesser evil" and majority of use cases.

---

### `LootableTypes`

`ImmutableHashSet<byte>` type with default value of `1, 3, 5` steam item types. This property defines ASF behaviour when looting - both manual, using a **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**, as well as automatic one, through one or more configuration properties. ASF will ensure that only items from `LootableTypes` will be included in a trade offer, therefore this property allows you to choose what you want to receive in a trade offer that is being sent to you.

| Value | Ім'я                  | Description                                                   |
| ----- | --------------------- | ------------------------------------------------------------- |
| 0     | Unknown               | Every type that doesn't fit in any of the below               |
| 1     | BoosterPack           | Booster pack containing 3 random cards from a game            |
| 2     | Emoticon              | Emoticon to use in Steam Chat                                 |
| 3     | FoilTradingCard       | Foil variant of `TradingCard`                                 |
| 4     | ProfileBackground     | Profile background to use on your Steam profile               |
| 5     | TradingCard           | Steam trading card, being used for crafting badges (non-foil) |
| 6     | SteamGems             | Steam gems being used for crafting boosters, sacks included   |
| 7     | SaleItem              | Special items awarded during Steam sales                      |
| 8     | Consumable            | Special consumable items that disappear after being used      |
| 9     | ProfileModifier       | Special items that can modify Steam profile appearance        |
| 10    | Sticker               | Special items that can be used on Steam chat                  |
| 11    | ChatEffect            | Special items that can be used on Steam chat                  |
| 12    | MiniProfileBackground | Special background for Steam profile                          |
| 13    | AvatarProfileFrame    | Special avatar frame for Steam profile                        |
| 14    | AnimatedAvatar        | Special animated avatar for Steam profile                     |
| 15    | KeyboardSkin          | Special keyboard skin for Steam deck                          |
| 16    | StartupVideo          | Special startup video for Steam deck                          |

Please note that regardless of the settings above, ASF will only ask for Steam (`appID` of 753) community (`contextID` of 6) items, so all game items, gifts and likewise, are excluded from the trade offer by definition.

Default ASF setting is based on the most common usage of the bot, with looting only booster packs, and trading cards (including foils). The property defined here allows you to alter that behaviour in whatever way that satisfies you. Please keep in mind that all types not defined above will show as `Unknown` type, which is especially important when Valve releases some new Steam item, that will be marked as `Unknown` by ASF as well, until it's added here (in the future release). That's why in general it's not recommended to include `Unknown` type in your `LootableTypes`, unless you know what you're doing, and you also understand that ASF will send your entire inventory in a trade offer if Steam Network gets broken again and reports all your items as `Unknown`. My strong suggestion is to not include `Unknown` type in the `LootableTypes`, even if you expect to loot everything (else).

---

### `MatchableTypes`

`ImmutableHashSet<byte>` type with default value of `5` Steam item types. This property defines which Steam item types are permitted to be matched when `SteamTradeMatcher` option in `TradingPreferences` is enabled. Types are defined as below:

| Value | Ім'я                  | Description                                                   |
| ----- | --------------------- | ------------------------------------------------------------- |
| 0     | Unknown               | Every type that doesn't fit in any of the below               |
| 1     | BoosterPack           | Booster pack containing 3 random cards from a game            |
| 2     | Emoticon              | Emoticon to use in Steam Chat                                 |
| 3     | FoilTradingCard       | Foil variant of `TradingCard`                                 |
| 4     | ProfileBackground     | Profile background to use on your Steam profile               |
| 5     | TradingCard           | Steam trading card, being used for crafting badges (non-foil) |
| 6     | SteamGems             | Steam gems being used for crafting boosters, sacks included   |
| 7     | SaleItem              | Special items awarded during Steam sales                      |
| 8     | Consumable            | Special consumable items that disappear after being used      |
| 9     | ProfileModifier       | Special items that can modify Steam profile appearance        |
| 10    | Sticker               | Special items that can be used on Steam chat                  |
| 11    | ChatEffect            | Special items that can be used on Steam chat                  |
| 12    | MiniProfileBackground | Special background for Steam profile                          |
| 13    | AvatarProfileFrame    | Special avatar frame for Steam profile                        |
| 14    | AnimatedAvatar        | Special animated avatar for Steam profile                     |
| 15    | KeyboardSkin          | Special keyboard skin for Steam deck                          |
| 16    | StartupVideo          | Special startup video for Steam deck                          |

Of course, types that you should use for this property typically include only `2`, `3`, `4` and `5`, as only those types are supported by STM. ASF includes proper logic for discovering rarity of the items, therefore it's also safe to match emoticons or backgrounds, as ASF will properly consider fair only those items from the same game and type, that also share the same rarity.

Please note that **ASF is not a trading bot** and **will NOT care about the market price**. If you don't consider items of the same rarity from the same set to be the same price-wise, then this option is NOT for you. Please evaluate twice if you understand and agree with this statement before you decide to change this setting.

Unless you know what you're doing, you should keep it with default value of `5`.

---

### `OnlineFlags`

`ushort flags` type with default value of `0`. This property works as supplement to **[`OnlineStatus`](#onlinestatus)** and specifies additional online presence features announced to Steam network. Requires **[`OnlineStatus`](#onlinestatus)** other than `Offline`, and is defined as below:

| Value | Ім'я              | Description                               |
| ----- | ----------------- | ----------------------------------------- |
| 0     | Не обрано         | No special online presence flags, default |
| 256   | ClientTypeWeb     | Client is using web interface             |
| 512   | ClientTypeMobile  | Client is using mobile app                |
| 1024  | ClientTypeTenfoot | Client is using big picture               |
| 2048  | ClientTypeVR      | Client is using VR headset                |

Please notice that this property is `flags` field, therefore it's possible to choose any combination of available values. Check out **[json mapping](#json-mapping)** if you'd like to learn more. Not enabling any of flags results in `None` option.

The underlying `EPersonaStateFlag` type that this property is based on includes more available flags, however, to the best of our knowledge they have absolutely no effect as of today, therefore they were cut for visibility.

If you're not sure how to set this property, leave it with default value of `0`.

---

### `OnlineStatus`

параметр типу `byte` зі значенням за замовчуванням `1`. This property specifies Steam community status that the bot will be announced with after logging in to Steam network. Currently you can choose one of below statuses:

| Value | Ім'я           |
| ----- | -------------- |
| 0     | Офлайн         |
| 1     | Онлайн         |
| 2     | Busy           |
| 3     | Away           |
| 4     | Snooze         |
| 5     | LookingToTrade |
| 6     | LookingToPlay  |
| 7     | Invisible      |

`Offline` status is extremely useful for primary accounts. As you should know, farming a game actually shows your steam status as "Playing game: XXX", which can be misleading to your friends, confusing them that you're playing a game while actually you're only farming it. Using `Offline` status solves that issue - your account will never be shown as "in-game" when you're farming steam cards with ASF. This is possible thanks to the fact that ASF does not have to sign in into Steam Community in order to work properly, so we're in fact playing those games, connected to Steam network, but without announcing our online presence at all. Keep in mind that played games using offline status will still count towards your playtime, and show as "recently played" on your profile.

In addition to that, this feature is also important if you want to receive notifications and unread messages when ASF is running, while not keeping Steam client open at the same time. This is because ASF acts as a Steam client itself, and whether ASF would like it or not, Steam broadcasts all those messages and other events to it. This is not a problem if you have both ASF and your own Steam client running, as both clients receive exactly the same events. However, if just ASF is running, Steam network could mark certain events and messages as "delivered", despite of your traditional Steam client not receiving it due to not being present. Offline status also solves this problem, as ASF is never considered for any community events in this case, so all unread messages and other events will be properly marked as unread when you come back.

It's important to note that ASF running on `Offline` mode will **not** be able to receive commands in usual Steam chat way, as the chat, as well as entire community presence is in fact, entirely offline. A solution to this issue is using `Invisible` mode instead which works in a similar way (not exposing status), but keeps the ability to receive and respond to messages (so also a potential to dismiss notifications and unread messages as stated above). `Invisible` mode makes the most sense on alt accounts that you don't want to expose (status-wise), but still be able to send commands to.

However, there is one catch with `Invisible` mode - it doesn't go well with primary accounts. This is because **any** Steam session that is currently online **exposes** the status, even if ASF itself does not. This is caused by the current limitation/bug of the Steam network that isn't possible to be fixed on ASF side, so if you want to use `Invisible` mode you will also need to ensure that **all** other sessions to the same account use `Invisible` mode as well. This will be the case on alt accounts where ASF is hopefully the only active session, but on primary accounts you'll almost always prefer to show as `Online` to your friends, hiding only ASF activity, and in this case `Invisible` mode will be entirely useless for you (we recommend to use `Offline` mode instead). Hopefully this limitation/bug will be eventually solved in the future by Valve, but I wouldn't expect that to happen anytime soon...

If you're unsure how to set up this property, it's recommended to use a value of `0` (`Offline`) for primary accounts, and default `1` (`Online`) otherwise.

---

### `PasswordFormat`

`byte` type with default value of `0` (`PlainText`). This property defines the format of `SteamPassword` property, and currently supports values specified in the **[security](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security)** section. You should follow the instructions specified there, as you'll need to ensure that `SteamPassword` property indeed includes password in matching `PasswordFormat`. In other words, when you change `PasswordFormat` then your `SteamPassword` should be **already** in that format, not just aiming to be. Unless you know what you're doing, you should keep it with default value of `0`.

---

### `Paused`

параметр типу `bool` зі значенням за замовчуванням `false`. This property defines initial state of `CardsFarmer` module. With default value of `false`, bot will automatically start farming when it's started, either because of `Enabled` or `start` command. Switching this property to `true` should be done only if you want to manually `resume` automatic farming process, for example because you want to use `play` all the time and never use automatic `CardsFarmer` module - this works exactly the same as `pause` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. If you're unsure whether you want this feature enabled or not, keep it with default value of `false`.

---

### `RedeemingPreferences`

`byte flags` type with default value of `0`. This property defines ASF behaviour when redeeming cd-keys, and is defined as below:

| Value | Ім'я                               | Description                                                                                                                     |
| ----- | ---------------------------------- | ------------------------------------------------------------------------------------------------------------------------------- |
| 0     | Не обрано                          | No special redeeming preferences, default                                                                                       |
| 1     | Forwarding                         | Forward keys unavailable to redeem to other bots                                                                                |
| 2     | Distributing                       | Distribute all keys among itself and other bots                                                                                 |
| 4     | KeepMissingGames                   | Keep keys for (potentially) missing games when forwarding, leaving them unused                                                  |
| 8     | AssumeWalletKeyOnBadActivationCode | Assume that `BadActivationCode` keys are equal to `CannotRedeemCodeFromClient`, and therefore try to redeem them as wallet keys |

Please notice that this property is `flags` field, therefore it's possible to choose any combination of available values. Check out **[json mapping](#json-mapping)** if you'd like to learn more. Not enabling any of flags results in `None` option.

`Forwarding` will cause bot to forward a key that is not possible to redeem, to another connected and logged on bot that is missing that particular game (if possible to check). The most common situation is forwarding `AlreadyPurchased` game to another bot that is missing that particular game, but this option also covers other scenarios, such as `DoesNotOwnRequiredApp`, `RateLimited` or `RestrictedCountry`.

`Distributing` will cause bot to distribute all received keys among itself and other bots. This means that every bot will get a single key from the batch. Typically this is used only when you're redeeming many keys for the same game, and you want to evenly distribute them among your bots, as opposed to redeeming keys for various different games. This feature makes no sense if you're redeeming only one key in a single `redeem` action (as there are no extra keys to be distributed).

`KeepMissingGames` will cause bot to skip `Forwarding` when we can't be sure if key being redeemed is in fact owned by our bot, or not. This basically means that `Forwarding` will apply **only** to `AlreadyPurchased` keys, instead of covering also other cases such as `DoesNotOwnRequiredApp`, `RateLimited` or `RestrictedCountry`. Typically you want to use this option on primary account, to ensure that keys being redeemed on it won't be forwarded further if your bot for example becomes temporarily `RateLimited`. As you can guess from the description, this field has absolutely no effect if `Forwarding` is not enabled.

`AssumeWalletKeyOnBadActivationCode` will cause `BadActivationCode` keys to be treated as `CannotRedeemCodeFromClient`, and therefore result in ASF trying to redeem them as wallet keys. This is needed because Steam might announce wallet keys as `BadActivationCode` (and not `CannotRedeemCodeFromClient` as it used to), resulting in ASF never attempting to redeem them. However, we recommend **against** using this preference, as it'll result in ASF trying to redeem every invalid key as a wallet code, resulting in excessive amount of (potentially invalid) requests sent to the Steam service, with all the potential consequences. Instead, we recommend to use `ForceAssumeWalletKey` **[`redeem^`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands#redeem-modes)** mode while knowingly redeeming wallet keys, which will enable the needed workaround only when it's required, on as-needed basis.

Enabling both `Forwarding` and `Distributing` will add distributing feature on top of forwarding one, which makes ASF trying to redeem one key on all bots firstly (forwarding) before moving to the next one (distributing). Typically you want to use this option only when you want `Forwarding`, but with altered behaviour of switching the bot on key being used, instead of always going in-order with every key (which would be `Forwarding` alone). This behaviour can be beneficial if you know that majority or even all of your keys are tied to the same game, because in this situation `Forwarding` alone would try to redeem everything on one bot firstly (which makes sense if your keys are for unique games), and `Forwarding` + `Distributing` will switch the bot on the next key, "distributing" the task of redeeming new key onto another bot than the initial one (which makes sense if keys are for the same game, skipping one pointless attempt per key).

The actual bots order for all of the redeeming scenarios is alphabetical, excluding bots that are unavailable (not connected, stopped or likewise). Please keep in mind that there is per-IP and per-account hourly limit of redeeming tries, and every redeem try that didn't end with `OK` contributes to failed tries. ASF will do its best to minimize number of `AlreadyPurchased` failures, e.g. by trying to avoid forwarding a key to another bot that already owns that particular game, but it's not always guaranteed to work due to how Steam is handling licenses. Using redeeming flags such as `Forwarding` or `Distributing` will always increase your likelyhood to hit `RateLimited`.

Also keep in mind that you can't forward or distribute keys to bots that you do not have access to. This should be obvious, but ensure that you're at least `Operator` of all the bots you want to include in your redeeming process, for example with `status ASF` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**.

---

### `RemoteCommunication`

`byte flags` type with default value of `3`. This property defines per-bot ASF behaviour when it comes to communication with remote, third-party services, and is defined as below:

| Value | Ім'я          | Description                                                                                                                                                                                                                                                       |
| ----- | ------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| 0     | Не обрано     | No allowed third-party communication, rendering selected ASF features unusable                                                                                                                                                                                    |
| 1     | SteamGroup    | Allows communication with **[ASF's Steam group](https://steamcommunity.com/groups/archiasf)**                                                                                                                                                                     |
| 2     | PublicListing | Allows communication with **[ASF's STM listing](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#publiclisting)** in order to being listed, if user has also enabled `SteamTradeMatcher` in **[`TradingPreferences`](#tradingpreferences)** |

Please notice that this property is `flags` field, therefore it's possible to choose any combination of available values. Check out **[json mapping](#json-mapping)** if you'd like to learn more. Not enabling any of flags results in `None` option.

This option doesn't include every third-party communication offered by ASF, only those that are not implied by other settings. For example, if you've enabled ASF's auto-updates, ASF will communicate with both GitHub (for downloads) and our server (for checksum verification), as per your configuration. Likewise, enabling `MatchActively` in **[`TradingPreferences`](#tradingpreferences)** implies communication with our server to fetch listed bots, which is required for that functionality.

Further explanation on this subject is available in **[remote communication](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Remote-communication)** section. Якщо у вас немає підстав змінювати цей параметр, вам варто залишити йому значення за замовчуванням.

---

### `SendOnFarmingFinished`

параметр типу `bool` зі значенням за замовчуванням `false`. When ASF is done with farming given account, it can automatically send steam trade containing everything farmed up to this point to user with `Master` permission, which is very convenient if you don't want to bother with trades yourself. This option works the same as `loot` command, therefore keep in mind that it requires user with `Master` permission set, you may also need a valid `SteamTradeToken`, as well as using an account that is eligible for trading in the first place. In addition to initiating `loot` after finishing farming, ASF will also initiate `loot` on each new items notification (when not farming), and after completing each trade that results in new items (always) when this option is active. This is especially useful for "forwarding" items received from other people to our account.

Typically you'll want to use **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)** together with this feature, although it's not a requirement if you intend to confirm manually in timely fashion. Якщо ви не впевнені, яке значення встановити цьому параметру, залиште йому значення за замовчуванням `false`.

---

### `SendTradePeriod`

параметр типу `byte` зі значенням за замовчуванням `0`. This property works very similar to `SendOnFarmingFinished` property, with one difference - instead of sending trade when farming is done, we can also send it every `SendTradePeriod` hours, regardless of how much we have to farm left. This is useful if you want to `loot` your alt accounts on usual basis instead of waiting for it to finish farming. Default value of `0` disables this feature, if you want your bot to send you trade e.g. every day, you should put `24` here.

Typically you'll want to use **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)** together with this feature, although it's not a requirement if you intend to confirm manually in timely fashion. If you're not sure how to set this property, leave it with default value of `0`.

---

### `ShutdownOnFarmingFinished`

параметр типу `bool` зі значенням за замовчуванням `false`. ASF is "occupying" an account for the whole time of process being active. When given account is done with farming, ASF periodically checks it (every `IdleFarmingPeriod` hours), if perhaps some new games with steam cards were added in the meantime, so it can resume farming of that account without a need to restart the process. This is useful for majority of people, as ASF can automatically resume farming when needed. However, you may actually want to stop the process when given account is fully farmed, you can achieve that by setting this property to `true`. When enabled, ASF will proceed with logging off when account is fully farmed, which means that it won't be periodically checked or occupied anymore. You should decide yourself if you prefer ASF to work on given bot instance for the whole time, or if perhaps ASF should stop it when farming process is done. When all accounts are stopped and process is not running in `--process-required` **[mode](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-Line-Arguments)**, ASF will shutdown as well, putting your machine at rest and allowing you to schedule other actions, such as sleep or shutdown at the same moment of last card dropping.

Якщо ви не впевнені, яке значення встановити цьому параметру, залиште йому значення за замовчуванням `false`.

---

### `SkipRefundableGames`

параметр типу `bool` зі значенням за замовчуванням `false`. This property defines if ASF is permitted to farm games that are still refundable. A refundable game is a game that you bought in last 2 weeks through Steam Store and didn't play for longer than 2 hours yet, as stated on **[Steam refunds](https://store.steampowered.com/steam_refunds)** page. By default when this option is set to `false`, ASF ignores Steam refunds policy entirely and farms everything, as most people would expect. However, you can change this option to `true` if you want to ensure that ASF won't farm any of your refundable games too soon, allowing you to evaluate those games yourself and refund if needed without worrying about ASF affecting playtime negatively. Please note that if you enable this option then games you purchased from Steam Store won't be farmed by ASF for up to 14 days since redeem date, which will show as nothing to farm if your account doesn't own anything else. If you're unsure whether you want this feature enabled or not, keep it with default value of `false`.

---

### `SteamLogin`

параметр типу `string` зі значенням за замовчуванням `null`. This property defines your steam login - the one you use for logging in to steam. In addition to defining steam login here, you may also keep default value of `null` if you want to enter your steam login on each ASF startup instead of putting it in the config. This may be useful for you if you don't want to save sensitive data in config file.

---

### `SteamMasterClanID`

`ulong` type with default value of `0`. This property defines the steamID of the steam group that bot should automatically join, including its group chat. You can check steamID of your group by navigating to its **[page](https://steamcommunity.com/groups/archiasf)**, then adding `/memberslistxml?xml=1` to the end of the link, so the link will look like **[this](https://steamcommunity.com/groups/archiasf/memberslistxml?xml=1)**. Then you can get steamID of your group from the result, it's in `<groupID64>` tag. In above example it would be `103582791440160998`. In addition to trying to join given group at startup, the bot will also automatically accept group invites to this group, which makes it possible for you to invite your bot manually if your group has private membership. If you don't have any group dedicated for your bots, you should keep this property with default value of `0`.

---

### `SteamParentalCode`

параметр типу `string` зі значенням за замовчуванням `null`. This property defines your steam parental PIN. ASF requires an access to resources protected by steam parental, therefore if you use that feature, you should provide ASF with parental unlock PIN, so it can operate normally. Default value of `null` means that there is no steam parental PIN required to unlock this account, and this is probably what you want if you don't use steam parental functionality.

In limited circumstances, ASF is also able to generate a valid Steam parental code itself, although that requires excessive amount of OS resources and additional time to complete, not to mention that it's not guaranteed to succeed, therefore we recommend to not rely on that feature and instead put valid `SteamParentalCode` in the config for ASF to use. If ASF determines that PIN is required, and it'll be unable to generate one on its own, it'll ask you for input.

---

### `SteamPassword`

параметр типу `string` зі значенням за замовчуванням `null`. This property defines your steam password - the one you use for logging in to steam. In addition to defining steam password here, you may also keep default value of `null` if you want to enter your steam password on each ASF startup instead of putting it in the config. This may be useful for you if you don't want to save sensitive data in config file.

---

### `SteamTradeToken`

параметр типу `string` зі значенням за замовчуванням `null`. When you have your bot on your friend list, then bot can send a trade to you right away without worrying about trade token, therefore you can leave this property at default value of `null`. If you however decide to NOT have your bot on your friend list, then you will need to generate and fill a trade token as the user that this bot is expecting to send trades to. In other words, this property should be filled with trade token of the account that is defined with `Master` permission in `SteamUserPermissions` of **this** bot instance.

In order to find your token, as logged in user with `Master` permission, navigate **[here](https://steamcommunity.com/my/tradeoffers/privacy)** and take a look at your trade URL. The token we're looking for is made out of 8 characters after `&token=` part in your trade URL. You should copy and put those 8 characters here, as `SteamTradeToken`. Do not include whole trading URL, neither `&token=` part, only the token itself (8 characters).

---

### `SteamUserPermissions`

`ImmutableDictionary<ulong, byte>` type with default value of being empty. This property is a dictionary property which maps given Steam user identified by his 64-bit steam ID, to `byte` number that specifies his permission in ASF instance. Currently available bot permissions in ASF are defined as:

| Value | Ім'я          | Description                                                                                                                                                                                        |
| ----- | ------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| 0     | Не обрано     | No special permission, this is mainly a reference value that is assigned to steam IDs missing in this dictionary - there is no need to define anybody with this permission                         |
| 1     | FamilySharing | Provides minimum access for family sharing users. Once again, this is mainly a reference value since ASF is capable of automatically discovering steam IDs that we permitted for using our library |
| 2     | Operator      | Provides basic access to given bot instances, mainly adding licenses and redeeming keys                                                                                                            |
| 3     | Master        | Provides full access to given bot instance                                                                                                                                                         |

In short, this property allows you to handle permissions for given users. Permissions are important mainly for access to ASF **[commands](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**, but also for enabling many ASF features, such as accepting trades. For example you may want to set your own account as `Master`, and give `Operator` access to 2-3 of your friends so they can easily redeem keys for your bot with ASF, while **not** being eligible e.g. for stopping it. Thanks to that you can easily assign permissions to given users and let them use your bot to some specified by you degree.

We recommend to set exactly one user as `Master`, and any amount you wish as `Operators` and below. While it's technically possible to set multiple `Masters` and ASF will work correctly with them, for example by accepting all of their trades sent to the bot, ASF will use only one of them (with lowest steam ID) for every action that requires a single target, for example a `loot` request, so also properties like `SendOnFarmingFinished` or `SendTradePeriod`. If you perfectly understand those limitations, especially the fact that `loot` request will always send items to the `Master` with lowest steam ID, regardless of the `Master` that actually executed the command, then you can define multiple users with `Master` permission here, but we still recommend a single master scheme.

It's nice to note that there is one more extra `Owner` permission, which is declared as `SteamOwnerID` global config property. You can't assign `Owner` permission to anybody here, as `SteamUserPermissions` property defines only permissions that are related to the bot instance, and not ASF as a process. For bot-related tasks, `SteamOwnerID` is treated the same as `Master`, so defining your `SteamOwnerID` here is not necessary.

---

### `TradeCheckPeriod`

параметр типу `byte` зі значенням за замовчуванням `60`. Normally ASF handles incoming trade offers right after receiving notification about one, but sometimes because of Steam glitches it can't do it at that time, and such trade offers remain ignored until next trade notification or bot restart occurs, which may lead to trades being cancelled or items not available at that later time. If this parameter is set to a non-zero value, ASF will additionally check for such outstanding trades every `TradeCheckPeriod` minutes. Default value is selected with balance between additional requests to steam servers and losing incoming trades in mind. However, if you are just using ASF to farm cards, and don't plan to automatically process any incoming trades, you may set it to `0` to disable this feature completely. On the other hand, if your bot participates in public [ASF's STM listing](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#publiclisting) or provides other automated services as a trade bot, you may want to decrease this parameter to `15` minutes or so, to process all trades in a timely manner.

---

### `TradingPreferences`

`byte flags` type with default value of `0`. This property defines ASF behaviour when in trading, and is defined as below:

| Value | Ім'я                | Description                                                                                                                                                                                                           |
| ----- | ------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| 0     | Не обрано           | No special trading preferences, default                                                                                                                                                                               |
| 1     | AcceptDonations     | Accepts trades in which we're not losing anything                                                                                                                                                                     |
| 2     | SteamTradeMatcher   | Passively participates in **[STM](https://www.steamtradematcher.com)**-like trades. Visit **[trading](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading#steamtradematcher)** for more info                  |
| 4     | MatchEverything     | Requires `SteamTradeMatcher` to be set, and in combination with it - also accepts bad trades in addition to good and neutral ones                                                                                     |
| 8     | DontAcceptBotTrades | Doesn't automatically accept `loot` trades from other bot instances                                                                                                                                                   |
| 16    | MatchActively       | Actively participates in **[STM](https://www.steamtradematcher.com)**-like trades. Visit **[ItemsMatcherPlugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#matchactively)** for more info |

Please notice that this property is `flags` field, therefore it's possible to choose any combination of available values. Check out **[json mapping](#json-mapping)** if you'd like to learn more. Not enabling any of flags results in `None` option.

For further explanation of ASF trading logic, and description of every available flag, please visit **[trading](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading)** section.

---

### `TransferableTypes`

`ImmutableHashSet<byte>` type with default value of `1, 3, 5` steam item types. This property defines which Steam item types will be considered for transfering between bots, during `transfer` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. ASF will ensure that only items from `TransferableTypes` will be included in a trade offer, therefore this property allows you to choose what you want to receive in a trade offer that is being sent to one of your bots.

| Value | Ім'я                  | Description                                                   |
| ----- | --------------------- | ------------------------------------------------------------- |
| 0     | Unknown               | Every type that doesn't fit in any of the below               |
| 1     | BoosterPack           | Booster pack containing 3 random cards from a game            |
| 2     | Emoticon              | Emoticon to use in Steam Chat                                 |
| 3     | FoilTradingCard       | Foil variant of `TradingCard`                                 |
| 4     | ProfileBackground     | Profile background to use on your Steam profile               |
| 5     | TradingCard           | Steam trading card, being used for crafting badges (non-foil) |
| 6     | SteamGems             | Steam gems being used for crafting boosters, sacks included   |
| 7     | SaleItem              | Special items awarded during Steam sales                      |
| 8     | Consumable            | Special consumable items that disappear after being used      |
| 9     | ProfileModifier       | Special items that can modify Steam profile appearance        |
| 10    | Sticker               | Special items that can be used on Steam chat                  |
| 11    | ChatEffect            | Special items that can be used on Steam chat                  |
| 12    | MiniProfileBackground | Special background for Steam profile                          |
| 13    | AvatarProfileFrame    | Special avatar frame for Steam profile                        |
| 14    | AnimatedAvatar        | Special animated avatar for Steam profile                     |
| 15    | KeyboardSkin          | Special keyboard skin for Steam deck                          |
| 16    | StartupVideo          | Special startup video for Steam deck                          |

Please note that regardless of the settings above, ASF will only ask for Steam (`appID` of 753) community (`contextID` of 6) items, so all game items, gifts and likewise, are excluded from the trade offer by definition.

Default ASF setting is based on the most common usage of the bot, with transfering only booster packs, and trading cards (including foils). The property defined here allows you to alter that behaviour in whatever way that satisfies you. Please keep in mind that all types not defined above will show as `Unknown` type, which is especially important when Valve releases some new Steam item, that will be marked as `Unknown` by ASF as well, until it's added here (in the future release). That's why in general it's not recommended to include `Unknown` type in your `TransferableTypes`, unless you know what you're doing, and you also understand that ASF will send your entire inventory in a trade offer if Steam Network gets broken again and reports all your items as `Unknown`. My strong suggestion is to not include `Unknown` type in the `TransferableTypes`, even if you expect to transfer everything.

---

### `UseLoginKeys`

параметр типу `bool` зі значенням за замовчуванням `true`. This property defines if ASF should use login keys mechanism for this Steam account. Login keys mechanism works very similar to official Steam client's "remember me" option, which makes it possible for ASF to store and use temporary one-time use login key for next logon attempt, effectively skipping a need of providing password, Steam Guard or 2FA code as long as our login key is valid. Login key is stored in `BotName.db` file and updated automatically. This is why you don't need to provide password/SteamGuard/2FA code after logging in successfully with ASF just once.

Login keys are used by default for your convenience, so you don't need to input `SteamPassword`, SteamGuard or 2FA code (when not using **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)**) on each login. It's also superior alternative since login key can be used only for a single time and does not reveal your original password in any way. Exactly the same method is being used by your original Steam client, which saves your account name and login key for your next logon attempt, effectively being the same as using `SteamLogin` with `UseLoginKeys` and empty `SteamPassword` in ASF.

However, some people could be concerned even about this little detail, therefore this option is available here for you if you'd like to ensure that ASF won't store any kind of token that would allow resuming previous session after being closed, which will result in full authentication being mandatory on each login attempt. Disabling this option will work exactly the same as not checking "remember me" in official Steam client. Unless you know what you're doing, you should keep it with default value of `true`.

---

### `UserInterfaceMode`

параметр типу `byte` зі значенням за замовчуванням `0`. This property specifies user interface mode that the bot will be announced with after logging in to Steam network. Currently you can choose one of below modes:

| Value | Ім'я       |
| ----- | ---------- |
| `0`   | Default    |
| `1`   | BigPicture |
| `2`   | Mobile     |

If you're not sure how to set this property, leave it with default value of `0`.

---

## Файлова структура

ASF is using quite simple file structure.

```text
├── config
│     ├── ASF.json
│     ├── ASF.db
│     ├── Bot1.json
│     ├── Bot1.db
│     ├── Bot1.bin
│     ├── Bot2.json
│     ├── Bot2.db
│     ├── Bot2.bin
│     └── ...
├── ArchiSteamFarm.dll
├── log.txt
└── ...
```

In order to move ASF to new location, for example another PC, it's enough to move/copy `config` directory alone, and that's the recommended way of doing any form of "ASF backups", since you can always download the remaining (program) part from the GitHub, while not risking corrupting internal ASF files, e.g. through a faulty backup.

`log.txt` file holds the log generated by your last ASF run. This file doesn't contain any sensitive information, and is extremely useful when it comes to issues, crashes or simply as an information to you what happened in last ASF run. We will very often ask about this file if you run into issues or bugs. ASF automatically manages this file for you, but you can further tweak ASF **[logging](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Logging)** module if you're advanced user.

`config` directory is the place that holds configuration for ASF, including all of its bots.

`ASF.json` is a global ASF configuration file. This config is used for specifying how ASF behaves as a process, which affects all of the bots and program itself. You can find global properties there, such as ASF process owner, auto-updates or debugging.

`BotName.json` is a config of given bot instance. This config is used for specifying how given bot instance behaves, therefore those settings are specific to that bot only and not shared across other ones. This allows you to configure bots with various different settings and not necessarily all of them working in exactly the same way. Every bot is named using unique identifier, chosen by you in place of `BotName`.

Apart from config files, ASF also uses `config` directory for storing databases.

`ASF.db` is a global ASF database file. It acts as a global persistent storage and is used for saving various information related to ASF process, such as IPs of local Steam servers. **You should not edit this file**.

`BotName.db` is a database of given bot instance. This file is used for storing crucial data about given bot instance in persistent storage, such as login keys or ASF 2FA. **You should not edit this file**.

`BotName.bin` is a special file of given bot instance, which holds information about Steam sentry hash. Sentry hash is used for authenticating using `SteamGuard` mechanism, very similar to Steam `ssfn` file. **You should not edit this file**.

`BotName.keys` is a special file that can be used for importing keys into **[background games redeemer](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer)**. It's not mandatory and not generated, but recognized by ASF. This file is automatically deleted after keys are successfully imported.

`BotName.maFile` is a special file that can be used for importing **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)**. It's not mandatory and not generated, but recognized by ASF if your `BotName` does not use ASF 2FA yet. This file is automatically deleted after ASF 2FA is successfully imported.

---

## Типи параметрів JSON

Every configuration property has its type. Type of the property defines values that are valid for it. You can only use values that are valid for given type - if you use invalid value, then ASF won't be able to parse your config.

**We strongly recommend to use ConfigGenerator for generating configs** - it handles most of the low-level stuff (such as types validation) for you, so you only need to input proper values, and you also don't need to understand variable types specified below. This section is mainly for people generating/editing configs manually, so they know what values they can use.

Types used by ASF are native C# types, which are specified below:

---

`bool` - Boolean type accepting only `true` and `false` values.

Example: `"Enabled": true`

---

`byte` - Unsigned byte type, accepting only integers from `0` to `255` (inclusive).

Example: `"ConnectionTimeout": 90`

---

`ushort` - Unsigned short type, accepting only integers from `0` to `65535` (inclusive).

Example: `"WebLimiterDelay": 300`

---

`uint` - Unsigned integer type, accepting only integers from `0` to `4294967295` (inclusive).

---

`ulong` - Unsigned long integer type, accepting only integers from `0` to `18446744073709551615` (inclusive).

Example: `"SteamMasterClanID": 103582791440160998`

---

`string` - String type, accepting any sequence of characters, including empty sequence `""` and `null`. Empty sequence and `null` value are treated the same by ASF, so it's up to your preference which one you want to use (we stick with `null`).

Examples: `"SteamLogin": null`, `"SteamLogin": ""`, `"SteamLogin": "MyAccountName"`

---

`Guid?` - Nullable UUID type, in JSON encoded as string. UUID is made out of 32 hexadecimal characters, in range from `0` to `9` and `a` to `f`. ASF accepts variety of valid formats - lowercase, uppercase, with and without dashes. In addition to valid UUID, since this property is nullable, a special value of `null` is accepted to indicate lack of UUID to provide.

Examples: `"LicenseID": null`, `"LicenseID": "f6a0529813f74d119982eb4fe43a9a24"`

---

`ImmutableList<valueType>` - Immutable collection (list) of values in given `valueType`. In JSON, it's defined as array of elements in given `valueType`. ASF uses `List` to indicate that given property supports multiple values and that their order might be relevant.

Example for `ImmutableList<byte>`: `"FarmingOrders": [15, 11, 7]`

---

`ImmutableHashSet<valueType>` - Immutable collection (set) of unique values in given `valueType`. In JSON, it's defined as array of elements in given `valueType`. ASF uses `HashSet` to indicate that given property makes sense only for unique values and that their order doesn't matter, therefore it'll intentionally ignore any potential duplicates during parsing (if you happened to supply them anyway).

Example for `ImmutableHashSet<uint>`: `"Blacklist": [267420, 303700, 335590]`

---

`ImmutableDictionary<keyType, valueType>` - Immutable dictionary (map) that maps a unique key specified in its `keyType`, to value specified in its `valueType`. In JSON, it's defined as an object with key-value pairs. Keep in mind that `keyType` is always quoted in this case, even if it's value type such as `ulong`. There is also a strict requirement of the key being unique across the map, this time enforced by JSON as well.

Example for `ImmutableDictionary<ulong, byte>`: `"SteamUserPermissions": { "76561198174813138": 3, "76561198174813137": 1 }`

---

`flags` - Flags attribute combines several different properties into one final value by applying bitwise operations. This allows you to choose any possible combination of various different allowed values at the same time. The final value is constructed as a sum of values of all enabled options.

For example, given following values:

| Value | Ім'я      |
| ----- | --------- |
| 0     | Не обрано |
| 1     | A         |
| 2     | B         |
| 4     | C         |

Using `B + C` would result in value of `6`, using `A + C` would result in value of `5`, using `C` would result in value of `4` and so on. This allows you to create any possible combination of enabled values - if you decided to enable all of them, making `None + A + B + C`, you'd get value of `7`. Also notice that flag with value of `0` is enabled by definition in all other available combinations, therefore very often it's a flag that doesn't enable anything specifically (such as `None`).

So as you can see, in above example we have 3 available flags to switch on/off (`A`, `B`, `C`), and `8` possible values overall:
- `None -> 0`
- `A -> 1`
- `B -> 2`
- `A + B -> 3`
- `C -> 4`
- `A + C -> 5`
- `B + C -> 6`
- `A + B + C -> 7`

Example: `"SteamProtocols": 7`

---

## Сумісність типів

Due to JavaScript limitations of being unable to properly serialize simple `ulong` fields in JSON when using web-based ConfigGenerator, `ulong` fields will be rendered as strings with `s_` prefix in the resulting config. This includes for example `"SteamOwnerID": 76561198006963719` that will be written by our ConfigGenerator as `"s_SteamOwnerID": "76561198006963719"`. ASF includes proper logic for handling this string mapping automatically, so `s_` entries in your configs are actually valid and correctly generated. If you're generating configs yourself, we recommend to stick with original `ulong` fields if possible, but if you're unable to do so, you can also follow this scheme and encode them as strings with `s_` prefix added to their names. We hope to resolve this JavaScript limitation eventually.

---

## Сумісність конфігурацій

It's top priority for ASF to remain compatible with older configs. As you should already know, missing config properties are treated the same as they would be defined with their **default values**. Therefore, if new config property gets introduced in new version of ASF, all your configs will remain **compatible** with new version, and ASF will treat that new config property as it'd be defined with its **default value**. You can always add, remove or edit config properties according to your needs.

We recommend to limit defined config properties only to those that you want to change, since this way you automatically inherit default values for all other ones, not only keeping your config clean but also increasing compatibility in case we decide to change a default value for property that you don't want to explicitly set yourself (e.g. `WebLimiterDelay`).

Due to above, ASF will automatically migrate/optimize your configs by reformatting them and removing fields that hold default value. You can disable this behaviour with `--no-config-migrate` **[command-line argument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments#arguments)** if you have a specific reason, for example you're providing read-only config files and you don't want ASF to modify them.

---

## Автоматичне перезавантаження

Starting with ASF V2.1.6.2+, the program is now aware of configs being modified "on-the-fly" - thanks to that, ASF will automatically:
- Create (and start, if needed) new bot instance, when you create its config
- Stop (if needed) and remove old bot instance, when you delete its config
- Stop (and start, if needed) any bot instance, when you edit its config
- Restart (if needed) the bot under new name, when you rename its config

All of the above is transparent and will be done automatically without a need of restarting the program, or killing other (unaffected) bot instances.

In addition to that, ASF will also restart itself (if `AutoRestart` permits) if you modify core ASF `ASF.json` config. Likewise, program will quit if you delete or rename it.

You can disable this behaviour with `--no-config-watch` **[command-line argument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments#arguments)** if you have a specific reason, for example you don't want from ASF to react to file changes in `config` folder.