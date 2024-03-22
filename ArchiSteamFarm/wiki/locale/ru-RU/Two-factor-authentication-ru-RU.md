# Двухфакторная аутентификация

Steam использует двухфакторную систему аутентификации, известную как "Escrow", которая требует дополнительных сведений для различных действий, связанных с аккаунтом. Вы можете прочесть об этом подробнее **[тут](https://help.steampowered.com/faqs/view/2E6E-A02C-5581-8904)** и **[тут](https://help.steampowered.com/faqs/view/34A1-EA3F-83ED-54AB)**. Далее в тексте будем называть 2ФА систему и наше решение, которое интегрируется с ней - ASF 2FA.

---

# Логика работы ASF

Независимо от того, используете ли вы ASF 2FA или нет, ASF включает в себя всю нужную логику и способен определять учетные записи, защищенные стандартом 2ФА. У вас будут запрашивать необходимые данные когда они нужны (как например при входе). Тем не менее эти запросы могут быть автоматизированы с помощью 2ФА ASF, которая будет автоматически генерировать необходимые токены, освобождая вас от лишних действий и добавляя дополнительную функциональность (описано ниже).

---

# ASF 2FA

ASF 2FA это встроенный модуль, отвечающий за реализацию функций 2ФА для ASF, таких, как генерация кодов и принятие подтверждений. Он работает путем дублирования ваших существующих данных аутентификации, так что вы можете использовать ваш текущий аутентификатор и ASF 2FA одновременно.

Вы можете проверить, используется ли на боте ASF 2FA путём исполнения **[команд](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-ru-RU)** `2fa`. Если вы ещё не импортировали ваш аутентификатор в ASF 2FA, команды `2fa` не будут работать, а это означает что ваш аккаунт не использует ASF 2FA, и, следовательно, не может использовать некоторые расширенные функций ASF, которым этот модуль требуется для работы.

---

# Рекомендации

Существует множество способов обеспечить работоспособность ASF 2FA, здесь мы приводим наши рекомендации, исходя из вашей текущей ситуации:

- Если вы уже используете SteamDesktopAuthenticator, WinAuth или любое другое стороннее приложение, позволяющее с легкостью извлекать данные 2FA, просто **[импортируйте](#import)** их в ASF.
- Если вы используете официальное приложение и не против сбросить учетные данные 2FA, то лучше всего отключить 2FA, затем **[создать](#creation)**новые учетные данные 2FA с помощью **[совместного аутентификатора](#joint-authenticator)**, что позволит вам использовать официальное приложение и ASF 2FA. Этот метод не требует root или продвинутых знаний, достаточно следовать инструкциям.
- Если вы используете официальное приложение и не хотите заново создавать свои учетные данные 2FA, то ваши возможности очень ограничены: обычно для **[импорта](#import)** этих данных требуется root и дополнительные действия, и даже это может оказаться невозможным.
- Если вы еще не используете 2FA, то можете использовать ASF 2FA с помощью **[отдельного аутентификатора](#standalone-authenticator)**, стороннего приложения **[дублирующего](#import)** в ASF (рекомендация №1) или **[совместного аутентификатора](#joint-authenticator)** с официальным приложением (рекомендация №2).

Ниже мы рассмотрим все возможные варианты и известные нам способы.

---

## Создание

В целом мы настоятельно рекомендуем **[дублировать](#import)** существующий аутентификатор, поскольку именно для этого в основном и создавалась ASF 2FA. However, ASF comes with an official `MobileAuthenticator` **[plugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)** that further extends ASF 2FA, allowing you to link a completely new authenticator as well. Это может быть полезно в том случае, если вы не можете или не хотите использовать другие инструменты и не против, чтобы ASF 2FA стал вашим основным (а может быть, и единственным) аутентификатором.

There are two possible scenarios for adding a two-factor authenticator with the `MobileAuthenticator` **[plugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)**: standalone or joint with the official Steam mobile app. Во втором случае один и тот же аутентификатор будет использоваться и в ASF, и в мобильном приложении; оба будут генерировать одни и те же коды, и оба смогут подтверждать торговые предложения, транзакции в Steam Community Market и т.д.

### Общие действия для обоих сценариев

Независимо от того, планируете ли вы использовать ASF в качестве автономного аутентификатора или хотите использовать тот же аутентификатор в мобильном приложении Steam, вам необходимо выполнить эти шаги инициализации:

1. Создайте бота ASF для нужного аккаунта, запустите его и войдите в систему, что вы, вероятно, уже сделали.
2. Optionally, assign a working and operational phone number to the account **[here](https://store.steampowered.com/phone/manage)** to be used by the bot. This will allow you to receive SMS code and allow recovery if needed, but it's not mandatory.
3. Убедитесь, что вы еще не используете 2FA для своей учетной записи, а если используете, то сначала отключите ее.
4. Выполните команду `2fainit [Bot]`, заменив `[Bot]` именем вашего бота.

Если вы получили успешный ответ, то произошли две следующие вещи:

- Новый файл `<Bot>.maFile.PENDING` был сгенерирован ASF в директории `config`.
- Из Steam было отправлено SMS на номер телефона, который вы указали выше. If you didn't set a phone number, then an email was sent instead to the account e-mail address.

Данные аутентификатора пока не используются, однако при желании можно просмотреть сгенерированный файл. Если вы хотите обезопасить себя вдвойне, то можете, например, уже сейчас записать код восстановления. Дальнейшие действия будут зависеть от выбранного сценария.

### Standalone authenticator

If you want to use ASF as your main (or even only) authenticator, now you need to do the finalization step:

5. Execute the `2fafinalize [Bot] <ActivationCode>` command, replacing `[Bot]` with your bot's name and `<ActivationCode>` with the code you've received through SMS or e-mail in the previous step.

### Joint authenticator

If you want to have the same authenticator in both ASF and the official Steam mobile app, now you need to do the next steps:

5. Ignore the SMS or e-mail code that you've received after the previous step.
6. Install the Steam mobile app if it's not installed yet, and open it. Navigate to the Steam Guard tab and add a new authenticator by following the app's instructions.
7. After your authenticator in the mobile app is added and working, return to ASF. You now need to tell ASF that finalization is done with the help of one of the two commands below:
 - Wait until the next 2fa code is shown in the Steam mobile app, and use the command `2fafinalized [Bot] <2fa_code_from_app>` replacing `[Bot]` with your bot's name and `<2fa_code_from_app>` with the code you currently see in the Steam mobile app. If the code generated by ASF and the code you provided are the same, ASF assumes that an authenticator was added correctly and proceeds with importing your newly created authenticator.
 - We strongly recommend to do the above in order to ensure that your credentials are valid. However, if you don't want to (or can't) check if codes are the same and you know what you're doing, you can instead use the command `2fafinalizedforce [Bot]`, replacing `[Bot]` with your bot's name. ASF will assume that the authenticator was added correctly and proceed with importing your newly created authenticator.

### After finalization

Assuming everything worked properly, the previously generated `<Bot>.maFile.PENDING` file was renamed to `<Bot>.maFile.NEW`. Это означает, что учетные данные 2ФА действительны и активны. We recommend that you create a copy of that file and keep it in **a secure and safe location**. In addition to that, we recommend you open the file in your editor of choice and write down the `revocation_code`, which will allow you to, as the name implies, revoke the authenticator in case you lose it.

In regard to technical details, the generated `maFile` includes all details that we have received from the Steam server during linking the authenticator, and in addition to that, the `device_id` field, which may be needed for other authenticators. The file is fully compatible with **[SDA](#steamdesktopauthenticator)** for import.

ASF automatically imports your authenticator once the procedure is done, and therefore `2fa` and other related commands should now be operational for the bot account you linked the authenticator to.

---

## Импорт

Процесс импорта требует привязанного и рабочего аутентификатора, который поддерживается ASF. ASF currently supports a few different official and unofficial sources of 2FA - Android, SteamDesktopAuthenticator and WinAuth, on top of manual method which allows you to provide required credentials yourself. Если у вас еще нет аутентификатора, вам необходимо выбрать одно из доступных приложений и настроить его. Если у вас нет предпочтений, какое из них использовать, мы рекомендуем WinAuth, но работать будет любое из них, если конечно вы будете следовать инструкциям.

Все последующие руководства требуют чтобы у вас уже был **настроенный и работающий** аутентификатор в одном из заданных приложений. 2ФА ASF не будет работать если вы импортируете неверные данные, поэтому убедитесь что аутентификатор правильно работает перед тем как его импортировать. Это включает в себя тестирование и проверку того, что следующие функции аутентифиатора работают правильно:
- Вы можете генерировать коды для входа и эти коды принимаются сетью Steam
- Вы можете получить список операций, требующих подтверждения, и они отображаются в вашем мобильном аутентификаторе
- Вы можете подтверждать эти операции, и они правильно отображаются сетью Steam как подтверждённые/отклонённые

Убедитесь что ваш аутентификатор работает проверив, работают ли функции описанные выше - если нет, то они не будут работать и в ASF, и вы просто зря потратите время и получите лишние проблемы.

---

### Android-смартфон

В общем случае для импорта аутентификатора с телефона Android вам потребуется **[root](https://en.wikipedia.org/wiki/Rooting_(Android_OS))**доступ. The below instructions require from you fairly decent knowledge in Android modding world, we're definitely not going to explain every step here, visit **[XDA](https://xdaforums.com)** and other resources for additional information/help with below.

Prerequisites:
- Install official **[Steam app](https://play.google.com/store/apps/details?id=com.valvesoftware.android.steam.community)** from store, if you haven't yet.
- Assign authenticator to your account and ensure it works - generates valid tokens and can accept confirmations.

Extraction (requires rooting your device):
- Install **[Magisk](https://topjohnwu.github.io/Magisk/install.html)** and enable Zygisk in the settings.
- Install **[LSPosed](https://github.com/LSPosed/LSPosed?tab=readme-ov-file#install)** (for Zygisk) and ensure it works.
- Install **[SteamGuardExtractor](https://github.com/hax0r31337/SteamGuardExtractor?tab=readme-ov-file#usage)** LSPosed module and enable it in LSPosed settings.
- Force kill Steam app, then open it, a **[window with extracted details](https://github.com/JustArchiNET/ArchiSteamFarm/assets/1069029/ab5ab71e-d664-4e49-9eb4-9f4d9ba32aa2)** should pop up, click copy.

Now that you've successfully extracted required details, disable the module to prevent the window from showing each time, then copy value of `shared_secret` and `identity_secret` of the account that you intend to add to ASF 2FA, into a new text file with below structure:

```json
{
  "shared_secret": "STRING",
  "identity_secret": "STRING"
}
```

Replace each `STRING` value with appropriate private key from extracted details. Once you do that, rename the file to `BotName.maFile`, where `BotName` is the name of your bot you're adding ASF 2FA to, and put it in ASF's `config` directory if you haven't yet. Afterwards, launch ASF - it should notice the `.maFile` and import it.

```text
[*] INFO: ImportAuthenticator() <1> Конвертация .maFile в формат ASF...
[*] INFO: ImportAuthenticator() <1> Мобильный аутентификатор успешно импортирован!
```

На этом всё, если вы импортировали правильный файл с корректными данными, всё должно работать правильно, вы можете это проверить использовав команды `2fa`. Если вы где-то ошиблись, вы всегда можете удалить `Bot.db` и начать всё с начала.

---

### SteamDesktopAuthenticator

Если у вас уже есть аутентифицатор, работающий в SDA, вы можете заметить что у вас уже есть файл `steamID.maFile` в папке `maFiles`. Убедитесь, что этот `.maFile` находится в незашифрованном виде, поскольку ASF не умеет расшифровывать файлы SDA: незашифрованный файл должен начинаться с символа `{` и заканчиваться на  `}`. При необходимости вы можете сначала удалить шифрование из настроек SDA и включить его снова, когда закончите. Как только файл будет в расшифрованном виде, скопируйте его в папку `config` ASF.

Теперь вы можете переименовать `steamID.maFile` в `BotName.maFile` в папке config ASF, где `BotName` - это имя вашего бота, в который вы добавляете ASF 2FA. Вы можете оставить всё как есть, ASF обнаружит этот файл автоматически после входа в Steam. Переименование файла помогает ASF, сделав возможным использование ASF 2FA перед входом, если вы этого не сделаете, затем файл может быть выбран только после успешного входа ASF (так как ASF не знает `steamID` вашей учетной записи до фактического входа).

Если вы всё сделали правильно, запустите ASF, вы должны увидеть:

```text
[*] INFO: ImportAuthenticator() <1> Конвертация .maFile в формат ASF...
[*] INFO: ImportAuthenticator() <1> Мобильный аутентификатор успешно импортирован!
```

С этого момента ваш 2ФА ASF должен быть работоспособен на этом аккаунте.

---

### WinAuth

Сначала создайте новый пустой файл `BotName.maFile` в папке `config` вашего ASF, где `BotName` это имя вашего бота, для которого вы хотите добавить 2ФА ASF. Помните, что имя должно быть `BotName.maFile` а НЕ `BotName.maFile.txt`, Windows по-умолчанию скрывает расширения для зарегистрированных типов файлов. Если имя файла будет неверным, ASF не обнаружит его.

Теперь запустите WinAuth как обычно. Кликните правой кнопкой мыши на иконке Steam и выберите "Show SteamGuard and Recovery Code". Поставьте отметку в поле "Allow copy". Вы должны увидеть уже знакомую вам JSON-структуру в нижней части окна, начинающуюся с `{`. Скопируйте весь текст в файл `BotName.maFile`, созданный на предыдущем этапе.

Если вы всё сделали правильно, запустите ASF, вы должны увидеть:

```text
[*] INFO: ImportAuthenticator() <1> Конвертация .maFile в формат ASF...
[*] INFO: ImportAuthenticator() <1> Мобильный аутентификатор успешно импортирован!
```

С этого момента ваш 2ФА ASF должен быть работоспособен на этом аккаунте.

---

## Готово

С этого момента все команды `2fa` будут работать как будто на вашем обычном устройстве 2ФА. You can use both ASF 2FA and your authenticator of choice (Android, SDA or WinAuth) to generate tokens and accept confirmations.

Если у вас есть аутентификатор на телефоне, вы можете по желанию удалить SteamDesktopAuthenticator и/или WinAuth, поскольку он вам больше не понадобится. Однако я советую оставить его просто на всякий случай, даже не говоря о том что пользоваться им гораздо удобнее чем обычным аутентификатором Steam. Имейте в виду, что ASF 2FA это **НЕ** аутентификатор общего назначения, он не включает в себя все данные, которые должен иметь аутентификатор, а только ограниченный набор из `maFile`. Невозможно конвертировать ASF 2FA назад в обычный аутентификатор, поэтому держите под рукой другой обычный аутентификатор, или же храните `maFile` в другом месте, например в WinAuth/SDA или на телефоне.

---

## ЧАВО

### Как ASF использует модуль 2ФА?

Если 2ФА ASF настроена, ASF будет автоматически подтверждать все обмены которые отправляет/получает ASF. Также будет возможно автоматически при необходимости создавать коды 2FA, например чтобы выполнить вход. В добавок к этому, наличие 2ФА ASF делает доступными команды `2fa` для вашего удобства. Это должно быть всё, если я ничего не забыл - проще говоря, ASF использует модуль 2ФА по мере необходимости.

---

### Что если мне нужен код 2ФА?

Вам нужен код 2ФА для любого аккаунта, защищённого 2ФА, это также включает в себя каждый аккаунт с 2ФА ASF. Вам стоит создавать коды в аутентификаторе, который вы использовали для импорта, но вы можете также создавать временные коды с помощью команды `2fa`, отправив её через чат выбранному боту. Вы также можете использовать команду `2fa <BotNames>` чтобы сгенерировать временные коды для указанных ботов. This should be enough for you to access bot accounts through e.g. browser, but as noted above - you should use your friendly authenticator (Android, SDA or WinAuth) instead.

---

### Могу ли я пользоваться своим обычным аутентификатором после импорта в 2ФА ASF?

Да, ваш аутентификатор останется полностью работоспособным и вы можете использовать его одновременно с 2ФА ASF. В этом смысл всего процесса - мы импортируем данные вашего аутентификатора в ASF, чтобы ASF мог использовать их и подтверждать операции обмена, нужные вам.

---

### Где в ASF хранится мобильный аутентификатор?

Мобильный аутентификатор в ASF хранится в файле `BotName.db`, в вашей папке `config`, вместе с другой важной информацией относящейся к аккаунту. Если вы хотите удалить 2ФА ASF, читайте инструкцию ниже.

---

### Как удалить ASF 2FA?

Просто остановите ASF и удалите файл `BotName.db` соответствующий боту 2ФА ASF которого вы хотите удалить. Это удалит импортированный 2ФА, привязанный к ASF, но НЕ отвяжет аутентификатор от аккаунта. If you instead want to delink your authenticator, apart from removing it from ASF (firstly), you should delink it in authenticator of your choice (Android, SDA or WinAuth), or - if you can't for some reason, use revocation code that you received during linking that authenticator, on the Steam website. Невозможно удалить аутентификатор с помощью ASF, для этого вам надо использовать аутентификатор общего назначения, который у вас уже есть.

---

### Я подключил аутентификатор через SDA/WinAuth, а затем импортировал его в ASF. Можно мне теперь отключить его и заново подключить к своему телефону?

**Нет**. ASF **импортирует** данные вашего аутентификатора чтобы им пользоваться. Если вы отключите аутентификатор, то 2ФА ASF перестанет работать, не зависимо от того, удалили вы его как сказано выше, или нет. Если вы хотите использовать аутентификатор одновременно на телефоне и в ASF (плюс возможно в SDA/WinAuth), то вам нужно **импортировать** аутентификатор с вашего телефона, а не создавать новый в SDA/WinAuth. У вас может быть подключен только **один** аутентификатор, поэтому ASF **импортирует** этот аутентификатор со всеми данными для использования в 2ФА ASF - это **тот же самый** аутентификатор, просто существующий в двух местах. Если вы решите отключить ваш мобильный аутентификатор - не важно каким способом - 2ФА ASF перестанет работать, поскольку скопированный ранее аутентификатор будет уже неверным. In order to use ASF 2FA together with authenticator on your phone, you must import it from Android, which is described above.

---

### Лучше ли использовать для подтверждения всех операций 2ФА ASF по сравнению с WinAuth/SDA/Другим аутентификатором?

**Да**, по ряду причин. Первое, и самое главное - использование 2ФА ASF **значительно** увеличивает безопасность, поскольку модуль 2ФА в ASF будет следить чтобы ASF подтверждал автоматически только собственные обмены, так что даже если атакующий попытается запросить обмен, который вреден для вас, 2ФА ASF **не** примет такой обмен, поскольку он не был создан с помощью ASF. В добавок к безопасности, использование 2ФА ASF также даёт преимущества в производительности и оптимальности, поскольку 2ФА ASF подтверждает обмены сразу после того как они созданы, и только тогда, в противоположность поиску неподтвержденных операций каждые X минут как сделано например в SDA или WinAuth. Короче говоря, нет причин использовать сторонний аутентификатор если вы хотите автоматически подтверждать обмены, созданные ASF - именно для этого создана 2ФА ASF, и её использование никак не мешает вам подтверждать всё остальное в своём любимом аутентификаторе. Мы настоятельно рекомендуем использовать 2ФА ASF для всех действий ASF - это гораздо безопаснее чем прочие решения.

---

## Дополнительные настройки

Если вы продвинутый пользователь, вы можете также создать maFile вручную. Это может быть использовано, если вы хотите импортировать аутентификатор из иных источников чем те, что описаны выше. Он должен иметь **[корректную JSON структуру](https://jsonlint.com)**, состоящую из:

```json
{
  "shared_secret": "STRING",
  "identity_secret": "STRING"
}
```

В стандартных аутентификаторах имеется больше параметров - они полностью игнорируются ASF в процессе импорта, поскольку нам они не нужны. Вам не нужно их удалять - ASF требуется только корректная структура JSON с 2 обязательными полями, указанными выше, а все остальные поля (если они есть) - игнорируются. Разумеется, вам нужно заменить `STRING` в этом примере на корректные для вашего аккаунта значения. Каждая `STRING` должна быть base64-кодированным представлением байт, из которой сделан соответствующий приватный ключ.
