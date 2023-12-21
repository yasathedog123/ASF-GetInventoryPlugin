# Налаштування

Якщо ви тут вперше, ласкаво просимо! Ми дуже раді бачити ще одного мандрівника, який цікавиться нашим проектом, але не забувайте що з великою силою приходить велика відповідальність - ASF здатен зробити багато речей пов'язаних зі Steam, але лише за умови що **ви маєте бажання навчатися, як ним користуватися**. Крива навчання досить крута, тому ми очікуємо від вас, що ви прочитаєте цю вікі, яка детально описує як усе працює.

Якщо ви ще не кинули читати це означає що ви витримали текст вище, і це добре. Хіба що ви просто пройшли повз нього, у цьому разі для вас незабаром настануть **[погані часи](https://www.youtube.com/watch?v=WJgt6m6njVw)**... У будь-якому разі, ASF це консольна програма, тож вона не має дружного GUI до яких ви звикли, принаймні відразу після установки. ASF в першу чергу призначений для запуску на серверах, тому працює як сервіс (демон), а не як настільна програма.

Однак це не означає що ви не в змозі користуватися ним на вашому ПК, чи користуватися ним у якийсь більш складний спосіб ніж звичайно, нічого такого. ASF це автономна програма, яка не потребує установки, та працює відразу з коробки, але потребує конфігурації перш ніж бути корисною. Конфігурація це спосіб сказати ASF що вона має робити після запуску. Якщо ви запустите її без конфігурації, ASF просто нічого не буде робити.

---

## Налаштування для конкретної ОС

Взагалі, ось що нам з вами треба зробити за наступні кілька хвилин:
- Встановити **[передумови для .NET](#net-prerequisites)**.
- Скачати **[останній випуск ASf](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** у варіанті відповідному конкретній ОС.
- Розпакувати архів до нового розташування.
- **[Сконфігурувати ASF](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)**.
- Запустити ASF та подивитися на її магію.

Звучить досить просто, чи не так? Нумо зробимо це.

---

### Передумови для .NET

Перший крок це переконатися, що ваша ОС взагалі може коректно запустити ASF. ASF запрограмовано на C#, на основі платформи .NET, та може потребувати нативні бібліотеки, які ще недоступні для вашої платформи. Залежно від того, користуєтесь ви Windows, Linux чи macOS, у вас будуть різні вимоги, але усі вони приведені у документі **[.NET prerequisites](https://docs.microsoft.com/dotnet/core/install)**, тож користуйтеся ним. Це наш довідковий матеріал, яким слід користуватися, але щоб зробити це простішим для вас ми також наводимо усі необхідні пакети нижче, тому вам немає необхідності читати повний документ.

Цілком нормально, якщо деякі (або навіть усі) залежності вже існують у вашій системі через те, що були встановлені якимось програмним забезпеченням, яким ви вже користуєтесь. Однак, вам слід переконатися що це саме так запустивши відповідний інсталятор для вашої ОС - без цих залежностей ASF взагалі не запуститься.

Пам'ятайте, що вам не потрібно більше нічого для запуску пакетів ASF для конкретної ОС, особливо встановлювати .NET SDK чи навіть середовище виконання, оскільки пакет для конкретної ОС вже включає все це до свого складу. Вам потрібні лише передумови для .NET (залежності), щоб запустити середовище виконання включене до ASF.

#### **[Windows](https://docs.microsoft.com/dotnet/core/install/windows)**:
- **[Microsoft Visual C++ Redistributable Update](https://docs.microsoft.com/cpp/windows/latest-supported-vc-redist?view=msvc-170#visual-studio-2015-2017-2019-and-2022)** (**[x64](https://aka.ms/vs/17/release/vc_redist.x64.exe)** для 64-розрядної Windows, **[x86](https://aka.ms/vs/17/release/vc_redist.x86.exe)** для 32-розрядної Windows)
- Наполегливо рекомендуємо переконатися, що усі оновлення Windows вже встановлені. Якнайменше вам потрібні пакети **[KB2533623](https://support.microsoft.com/en-us/help/2533623/microsoft-security-advisory-insecure-library-loading-could-allow-remot)**, **[KB2999226](https://support.microsoft.com/en-us/help/2999226/update-for-universal-c-runtime-in-windows)**, але можуть бути потрібні й інші. Усі вони вже встановлені якщо ваша Windows цілком оновлена. Переконайтеся що виконали ці вимоги перш ніж встановлювати пакет Visual C++.

#### **[Linux](https://docs.microsoft.com/dotnet/core/install/linux)**:
Назви пакетів залежать від обраного дистрибутиву Linux, тож ми наводимо найпоширеніші з них. Ви можете отримати усі з них через стандартний менеджер пакетів у вашій ОС (такий як `apt` для Debian чи `yum` для CentOS).

- `ca-certificates` (standard trusted SSL certificates to make HTTPS connections)
- `libc6` (`libc`)
- `libgcc-s1` (`libgcc1`, `libgcc`)
- `libicu` (`icu-libs`, latest version for your distribution, for example `libicu72`)
- `libgssapi-krb5-2` (`libkrb5-3`, `krb5-libs`)
- `libssl1.1` (`libssl`, `openssl-libs`, latest version for your distribution, at least `1.1.X`)
- `libstdc++6` (`libstdc++`, in version `5.0` or higher)
- `zlib1g` (`zlib`)

At least a majority of those should be already natively available on your system. The minimal installation of Debian stable required only `libicu72`.

#### **[macOS](https://docs.microsoft.com/dotnet/core/install/macos)**:
- На даний час додаткових передумов немає, але у вас має бути встановлена остання версія macOS, якнайменше 10.15+

---

### Завантаження

Оскільки ми вже маємо всі необхідні передумови, наступний крок це завантаження **[останнього випуску ASF](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)**. ASF наявний у декількох варіантах, але вам потрібен пакет який відповідає вашій операційній системі та архітектури. Наприклад, якщо ви користуєтесь `64`-розрядною `Win`dows, то вам потрібен пакет `ASF-win-x64`. Для отримання додаткової інформації щодо існуючих варіантів, дивіться розділ **[сумісність](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility-uk-UA)**. ASF також може працювати на ОС, для яких ми не робимо пакет для конкретної ОС, як наприклад **32-розрядна Windows**, якщо вам це потрібно - переходьте до розділу **[універсальне налаштування](#user-content-Універсальне-налаштування)**.

![Файли](https://i.imgur.com/Ym2xPE5.png)

Після завантаження, почніть з того щоб розпакувати файл zip до окремої папки. If you require specific tool for that, **[7-zip](https://www.7-zip.org)** will do it, but all standard utilities like `unzip` from Linux/macOS should work without problems as well.

Радимо розпакувати ASF до **його власної директорії**, а не до якоїсь вже існуючої директорії яка має у собі щось інше - функція автоматичного оновлення ASF видаліть усі старі та непов'язані з ASF файли під час оновлення, що може призвести до втрати будь чого, що ви поклали до директорії ASF. Якщо ви маєте якісь додаткові скрипти чи інші файли, які бажаєте використовувати разом з ASF, покладіть їх на одну папку вище.

Приклад того, як може виглядати ця структура:

```text
C:\ASF (сюди складіть власні файли)
    ├── ASF - Ярлик.lnk (необов'язково)
    ├── Config - Ярлик.lnk (необов'язково)
    ├── Commands.txt (необов'язково)
    ├── MyExtraScript.bat (необов'язково)
    ├── (...) (будь які інші файли, які вам потрібні, необов'язково)
    └── Core (тільки для ASF, сюди ви розпакуєте архів)
         ├── ArchiSteamFarm(.exe)
         ├── config
         ├── logs
         ├── plugins
         └── (...)
```

---

### Конфігурація

Тепер ми готові зробити останній крок, конфігурацію. Це мабуть найскладніший крок, оскільки він включає в себе велику кількість нової інформації, тому ми спробуємо надати тут кілька простих для розуміння прикладів та спрощене пояснення.

Перше й найголовніше, у нас є сторінка присвячена **[конфігурації](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-uk-UA)**, яка описує **геть усе** зв'язане з конфігурацією, але це величезний обсяг нової інформації, більшість з якої вам не потрібна прямо зараз. Замість цього, ми навчимо вас, як отримати інформацію, яка вам зараз потрібна.

Конфігурацію ASF можна зробити щонайменше трьома шляхами - за допомогою нашого веб генератора конфігурацій, за допомогою ASF-ui, або вручну. Це докладно пояснюється у розділі **[конфігурації](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-uk-UA)**, тому зверніться до нього якщо вам потрібна детальна інформація. Для початку ми будемо використовувати веб генератор конфігурацій.

Перейдіть на сторінку нашого **[веб генератора конфігурацій](https://justarchinet.github.io/ASF-WebConfigGenerator)** за допомогою вашого улюбленого браузера, також вам потрібно щоб javascript було ввімкнено якщо ви раніше вимкнули його вручну. Ми рекомендуемо Chrome чи Firefox, але він має працювати в усіх найпопулярніших браузерах.

Після відкриття сторінки, перейдіть на вкладку "Бот". Ви маєте побачити сторінку схожу на приведену нижче:

![Вкладка Bot](https://i.imgur.com/aF3k8Rg.png)

Якщо за якихось обставин завантажена вами версія ASF більш стара, ніж генератор конфігурацій використовує за замовчуванням, просто оберіть потрібну версію ASF з випадного меню. Це може статися тому, що генератор конфігурацій використовується для генерації конфігурацій новішої (підготовчої) версії, яка ще не позначена як стабільна. Ви завантажили останню стабільну версію ASF, яка перевірена щодо надійної роботи.

Почніть з введення імені боту до поля, яке виділено червоним. Це може бути будь яке ім'я, яким ви б хотіли користатися, наприклад нікнейм, ім'я акаунта, номер, чи щось інше. Є лише одно слово, яке ви не можете обрати, `ASF`, бо це є ключове слово, зарезервоване для файлу глобальної конфігурації. На додаток до цього, ім'я вашого бота не може починатися з крапки (ASF навмисно ігнорує такі файли). Ми також рекомендуємо уникати використання пробілів, якщо потрібно ви можете користуватися символом `_` для розділення слів.

Після того, як ви обрали ім'я, ввімкніть перемикач `Enabled`, це визначає що ASF має автоматично запускати вашого бота після запуску (програми).

Тепер вам треба обрати один з варіантів:
- Ви можете додати ваш логін до поля `SteamLogin` та ваш пароль до поля `SteamPassword`
- Чи ви можете залишити їх порожніми

Перший варіант дасть змогу ASF автоматично використовувати ваші облікові дані під час запуску, щоб вам не довелося вводити їх вручну при кожному запуску ASF. Однак ви можете вирішити пропустити їх, у цьому разі вони не будуть збережені і ASF не зможе автоматично стартувати без вашої допомоги, а вам доведеться вводити їх протягом роботи.

ASF потребує ваші облікові дані бо він має вбудовану реалізацію клієнта Steam, і для входу потребує те ж саме, що й офіційних клієнт яким ви користуєтесь. Ваші облікові дані не зберігаються у жодному місці окрім каталогу `config` у ASF, наш веб генератор конфігурації цілком виконується на стороні клієнта, що означає що ви навіть можете запустити його без підключення до інтернет і зробити собі конфігураційні файли, і дані, які ви в ньому вводити ніколи не залишають ваш ПК, тому немає потреби турбуватися про будь-який витік конфіденційних даних. Однак, якщо за якихось причин ви не хочете вводити в нього свої облікові дані - ми це розуміємо, і надаємо можливість додати їх до файла конфігурації пізніше вручну, або цілком пропустити їх і вводити їх лише по запиту ASF. Більше інформації щодо безпеки ви можете знайти у розділі "**[конфігурація](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-uk-UA)**".

Також ми можете вирішити залишити пустим лише одне поле, наприклад `SteamPassword`, у цьому разі ASF буде автоматично використовувати логін, але буде запитувати пароль (схоже на те, що робить офіційний клієнт Steam). Якщо ви користуєтесь сімейним режимом Steam щоб розблокувати акаунт, вам потрібно ввести код у поле `SteamParentalCode`.

Після прийняття рішень та додаткових даних, ваша веб-сторінка буде виглядати схоже на те, що показано нижче:

![Вкладка Bot 2](https://i.imgur.com/yf54Ouc.png)

Тепер ви можете просто натиснути кнопку "Скачати" і наш веб генератор конфігурацій згенерує новий файл `json` на базі обраного імені. Збережіть цей файл у директорії `config`, що міститься у директорії куди ви розпакували zip-файл на попередньому кроці.

Ваш каталог `config` тепер виглядатиме наступним чином:

![Структура 2](https://i.imgur.com/crWdjcp.png)

Вітаємо! Ви тільки що завершили створення дуже простої конфігурації для бота ASF. Незабаром ми її розширимо, а поки що це все що вам потрібно.

---

### Запуск ASF

Тепер ви готові до першого запуску програми. Просто клацніть двічі по виконуваному файлу `ArchiSteamFarm` у каталозі ASF. Ви також можете запустити його з консолі.

Після цього, якщо ви встановили усі передумови на першому кроці, ASF має правильно стартувати, знайти вашого першого бота (якщо ви не забули покласти його конфігурацію до каталогу `config`), та спробувати увійти під його обліковим записом:

![ASF](https://i.imgur.com/u5hrSFz.png)

Якщо ви надали ASF для використання `SteamLogin` та `SteamPassword`, то у вас запитають лише код SteamGuard (з e-mail, 2ФА чи ніякого, в залежності від ваших налаштувань Steam). Якщо ж ні - у вас також спитають логін та пароль від Steam.

Now would be a good time to review our **[remote communication](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Remote-communication)** section if you're concerned about stuff ASF is programmed to do, including actions it'll take in your name, such as joining our Steam group.

After passing through initial login gate, assuming your details are correct, you'll successfully log in, and ASF will start farming using default settings that you didn't change as of now:

![ASF 2](https://i.imgur.com/Cb7DBl4.png)

Це доводить що ASF тепер успішно працює з вашим обліковим записом, тому ви можете згорнути програму і зайнятися чимось іншим. Після достатнього часу (він залежить від **[продуктивності](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance-uk-UA)**), ви побачите що повільно почали випадати колекційні картки Steam. Of course, for that to happen you must have valid games to farm, showing as "you can get X more card drops from playing this game" on your **[badges page](https://steamcommunity.com/my/badges)** - if there are no games to farm, then ASF will state that there is nothing to do, as stated in our **[FAQ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#what-is-asf)**.

На цьому ми завершуємо наш дуже простий посібник з налаштування. Ви можете вирішити чи бажаєте ви конфігурувати ASF далі, чи просто дозволити йому робити свою роботу з налаштуваннями за замовчуванням. Ми охопимо ще кілька простих деталей, а потім залишимо вам усю Wiki для вивчання.

---

### Додаткова конфігурація

#### Farming several accounts at once

ASF supports farming more than one account at a time, which is its primary function. Ви можете додати більше облікових записів до ASF просто згенерувавши більше конфігураційних файлів ботів, точно так само як ви згенерували перший кільки хвилин тому. Вам треба забезпечити лише дві речі:

- Унікальне ім'я боту, якщо у вас уже є бот з ім'ям "MainAccount", ви не зможете створити ще одного з тим же ім'ям.
- Вірні облікові дані, такі як `SteamLogin`, `SteamPassword` та `SteamParentalCode` (якщо ви користуєтесь налаштуваннями сімейного режиму)

Інакше кажучи, перейдіть знову до конфігурації і робіть те ж саме, тільки для другого або третього облікового запису. Не забувайте використовувати унікальні імена для всіх ваших ботів.

---

#### Зміна налаштувань

Щоб змінити налаштування ви робите те ж саме - генеруєте новий файл конфігурації. Якщо ви ще не закрили наш веб генератор конфігурацій, натисніть на "Відображення додаткових налаштувань" і подивіться, що ви там можете для себе знайти. For this tutorial we'll change `CustomGamePlayedWhileFarming` setting, which allows you to set custom name being displayed when ASF is farming, instead of showing actual game.

So let's do that, if you run ASF and start farming, in default settings you'll see that your Steam account is in-game now:

![Steam](https://i.imgur.com/1VCDrGC.png)

Змінимо це. Ввімкніть додаткові налаштування у веб генераторі конфігурацій та знайдіть там `CustomGamePlayedWhileFarming`. Як тільки знайдете - введіть туди свій обраний текст, який ви бажаєте відображувати, наприклад "Idling cards":

![Вкладка Bot 3](https://i.imgur.com/gHqdEqb.png)

Тепер скачайте новий файл конфігурації так само як і раніше, та **перезапишіть** ваш старий файл конфігурації на новий. Звичайно, ви можете також спершу видалити старий файл конфігурації та потім покласти новий на його місце.

Коли ви це зробите і запустите ASF знову, ви помітите що ASF тепер відображує обраний вами текст у попередньому місці:

![Steam 2](https://i.imgur.com/vZg0G8P.png)

This confirms that you've successfully edited your config. In exactly the same way you can change global ASF properties, by switching from bot tab to "ASF" tab, downloading generated `ASF.json` config file and putting it in your `config` directory.

Editing your ASF configs can be done much easier by using our ASF-ui frontend, which will be explained further below.

---

#### Використання ASF-ui

ASF це консольна програма, і не включає в себе графічний інтерфейс користувача. Однак ми активно парацюємо над інтерфейсом **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-uk-UA#asf-ui)** для нашого IPC, який може бути гідним та зручним способом скористатися різними можливостями ASF.

In order to use ASF-ui, you need to have `IPC` enabled, which is the default option. Once you launch ASF, you should be able to confirm that it properly started the IPC interface automatically:

![IPC](https://i.imgur.com/ZmkO8pk.png)

You can access ASF's IPC interface under **[this](http://localhost:1242)** link, as long as ASF is running, from the same machine. You can use ASF-ui for various purposes, e.g. editing the config files in-place or sending **[commands](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Ви вільні вивчати цей інтерфейс з метою дізнатися про усі можливості ASF-ui.

![ASF-ui](https://raw.githubusercontent.com/JustArchiNET/ASF-ui/main/.github/previews/bots.png)

---

### Підсумок

Ви успішно налаштували використання у ASF ваших облікових записів, і навіть трошки настроїли додаткові опції. If you followed our entire guide, then you also managed to tweak ASF through our ASF-ui interface and found out that ASF actually has a GUI of some sort. Now is a good time to read our entire **[configuration](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** section in order to learn what all those different settings you've seen actually do, and what ASF has to offer. If you've stumbled upon some issue or you have some generic question, read our **[FAQ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ)** instead which should cover all, or at least a vast majority of questions that you may have. Якщо ви бажаєте дізнатися геть усе про ASF, і про те як воно може зробити ваше життя легшим, ознайомтеся й з рештою **[нашої wiki](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Home-uk-UA)**. If you found out our program to be useful for you and you're feeling generous, you can also consider donating to our project. In any case, have fun!

---

## Універсальне налаштування

Цей варіант налаштування призначений для досвідчених користувачів, які бажають запустити ASF у **[універсальному (generic)](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility-uk-UA#generic)** варіанті. While being more troublesome in usage than **[OS-specific variants](#os-specific-setup)**, they also come with additional benefits.

Вам може знадобитися універсальний (`generic`) варіант налаштування у таких ситуаціях (хоча ви звичайно можете користуватися ним незважаючи на це):
- Коли ви користуєтесь ОС, для якої ми не робимо пакунок під конкретну ОС (наприклад 32-розрядна Windows)
- Коли у вас вже встановлено .NET Runtime/SDK, або ви плануєте його встановити й користуватися ним
- When you want to minimize ASF structure size and memory footprint by handling runtime requirements yourself
- Коли ви бажаєте використовувати якісь **[плаґіни](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins-uk-UA)**, що потребують універсальний варіант ASF для коректної роботи (через відсутність нативних залежностей)

Однак не забувайте, що у цьому разі ви відповідаєте за середовище виконання. Це означає, що якщо ваш .NET SDK (runtime) недоступний, застарілий чи зламаний - ASF не буде працювати. Саме тому ми не рекомендуємо це налаштування звичайним користувачам, оскільки вам потрібно буде забезпечити що ваш .NET SDK (runtime) відповідає потребам ASF й може запустити ASF, на відміну від ситуації коли **ми** забезпечуємо що .NET runtime у складі ASF може це зробити.

Для універсального пакунка, ви можете дотримуватися посібника для налаштувань для конкретної ОС, з двома невеличкими змінами. На додаток до встановлення передумов .NET, вам також треба встановити .NET SDK, та замість виконуваного файлу для конкретної ОС `ArchiSteamFarm(.exe)`, ви матимете лише двійковий файл `ArchiSteamFarm.dll`. Усе решта точно те ж саме.

Тож, разом з додатковими кроками, вам треба:
- Встановити **[передумови для .NET](#net-prerequisites)**.
- Встановити **[.NET SDK](https://www.microsoft.com/net/download)** (чи принаймні ASP.NET Core runtime), відповідний до вашої ОС. Найвірогідніше ви схочете скористуватися інсталятором. Зверніться до розділу "**[Вимоги середовища виконання](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility-uk-UA#Вимоги-середовища-виконання<)**", якщо не впевнені яку версію вам потрібно встановити.
- Скачати **[останній випуск ASf](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** в універсальному (`generic`) варіанті.
- Розпакувати архів до нового розташування.
- **[Сконфігурувати ASF](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)**.
- Запустити ASF або за використавши допоміжний скрипт, або виконавши команду `dotnet /path/to/ArchiSteamFarm.dll` вручну з вашої улюбленої консолі.

Helper scripts (such as `ArchiSteamFarm.cmd` for Windows and `ArchiSteamFarm.sh` for Linux/macOS) are located next to `ArchiSteamFarm.dll` binary - those are included in `generic` variant only. Ви можете скористуватися ними якщо не хочете виконувати команду `dotnet` вручну. Obviously helper scripts won't work if you didn't install .NET SDK and you don't have `dotnet` executable available in your `PATH`. Допоміжні скрипти необов'язкові до використання, ви завжди можете виконати `dotnet /path/to/ArchiSteamFarm.dll` вручну.