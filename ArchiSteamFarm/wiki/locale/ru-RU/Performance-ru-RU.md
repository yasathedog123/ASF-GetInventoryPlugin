# Производительность

Главной целью ASF является фармить настолько эффективно, насколько это возможно, основываясь на двух типах данных - небольшом количестве информации, предоставленном пользователем, которую ASF не может проверить/угадать самостоятельно, и большой объём данных, которые ASF может автоматически проверить.

В автоматическом режиме ASF не позволяет вам выбирать, какие игры следует фармить, а также не позволяет вам изменить алгоритм фарма карточек. **ASF лучше вас знает что следует делать и какие решения принимать, чтобы получить все карточки как можно быстрее**. Ваша задача только установить правильные настройки в параметрах конфигурации, поскольку ASF не может догадаться о них самостоятельно, всё остальное уже сделано.

---

Некоторое время назад Valve изменили алгоритм выпадения карточек. С этого момента, мы можем разделить аккаунты Steam на две категории: те, у которых выпадение карточек **ограничено** и те, у кого оно **не ограничено**. Единственное отличие между этими двумя типами заключается в том, что при ограничении на выпадение карточек из любой заданной игры не будут выпадать карточки пока время в этой игре де достигнет как минимум `X` часов. Похоже что старые аккаунты, с которых никогда не запрашивали возврат средств имеют **не ограниченное выпадение карточек**, в то время как новые аккаунты, или те, с которых запрашивали возврат средств, меют **ограниченное выпадение крточек**. Но это только теория, и не стоит полагаться на это как на правило. Именно поэтому **нет очевидного критерия**, и ASF полагается на **вас** чтобы получить информацию, какой из этих вариантов применим к вашему аккаунту.

---

ASF на данный момент включает в себя два алгоритма фарма:

**Простой (Simple)** алгоритм лучше работает если на вашем аккаунте нет оганичения на выпадение карточек. Это основной используемый ASF алгоритм. Бот находит игры для фарма, и фармит их одну за другой, пока не выпадут все карточки. Это связано с тем, что скорость выпадения карточек при фарме более одной игры одновременно стремится к нулю и это совершенно неэффективно.

**Сложный (Complex)** алгоритм - это новый алгоритм, который был реализован чтобы помочь аккаунтам с ограниченным выпадением карточек максимизировать свою прибыль. ASF сначала использует стандартный **Простой** алгоритм для всех игр, у которых игровое время превысило `HoursUntilCardDrops` часов, а затем, когда не останется игр у которых время в игре >= `HoursUntilCardDrops`, он одновременно фармит все игры (до предела равного `32`) с временем в игре < `HoursUntilCardDrops`, до тех пор пока в одной из них не неберётся `HoursUntilCardDrops` игрового времени, а затем начинает с начала (использует **Простой** алгоритм для этой игры, возвращается к одновременному фарму игр с < `HoursUntilCardDrops`, и так далее). В этом случае мы можем используем фарм нескольких игр для накрутки часов в этих играх до нужного значения. Помните, что во время накрутки часов, ASF **не** фармит карточки, и поэтому не будет в это время проверять выпадение карточек (по причинам, описанным выше).

На данный момент ASF выбирает алгоритм фарма карточек исключительно основываясь на параметре конфигурации `HoursUntilCardDrops` (который устанавливаете **вы**). Если `HoursUntilCardDrops` установлен равным `0`, выбирается **Simple** (простой) алгоритм, иначе вместо него используется **Complex** (комплексный, продвинутый) алгоритм.

---

### **Нет очевидного ответа, какой алгоритм будет лучше для вас**.

Это одна из причин, почему вы не выбираете алгоритм фарма карточек, а вместо этого сообщаете ASF, есть ли на вашем аккаунте ограничения на выпадение карточек, или нет. Если на аккаунте нет ограничения на выпадение карточек, **Простой** алгоритм будет **работать лучше**, поскольку он не будет тратить время на накрутку `X` часов - шанс выпадения карточек близок к 0% при фарме нескольких игр одновременно. С другой стороны, если на вашем аккаунте есть ограничение на выпадение карточек, **Сложный** алгоритм будет лучше, поскольку нет смысла фармить игры по одному пока в игре не достигнут предел в `HoursUntilCardDrops` игрового времени - поэтому мы сначала фармим **время в игре**, и только **потом** карточки в режиме соло.

Не ставьте вслепую какое-то значение в `HoursUntilCardDrops` только потому что кто-то вам так сказал - проведите тесты, сравните результаты, и основываясь на этом примите решение, какой вариант работает для вас лучше. Если вы приложите к этому минимальные усилия, вы сможете добиться максимальной эффективности работы ASF на вашем аккаунте, а это скорее всего именно то, чего вы хотите, раз вы читаете эту статью. Если бы было решение, подходящее для всех - вам бы не предоставляли выбор, ASF всё решил бы самостоятельно.

---

### Как выяснить, есть ли на аккаунте огреничение на выпадение карточек?

Убедитесь что у вас есть подходящие для фарма игры, желательно от 5 и более, и запустите ASF с `HoursUntilCardDrops` равным `0`. Лучше всего если вы не будете ни во что играть во время фарма, чтобы получить более точные результаты (лучше всего оставить ASF запущенным на ночь). Позвольте ASF получить карточки из этих 5 игр, и затем проверьте результаты в журнале.

ASF явно указывает когда выпала карточка из конкретной игры. Вас интересует самое быстрое выпадение карточек, достигнутое в ASF. Например, если на аккаунте нет ограничений, то первая карточка должна выпасть через примерно 30 минут от начала фарма. Если вы заметите, что **хотя бы в одной** игре карточка выпала в первые 30 минут, то это показатель что на этом аккаунте **нет** ограничений и для `HoursUntilCardDrops` следует указывать значение `0`.

С другой стороны, если вы заметите что во **всех** играх требуется как минимум `X` часов до выпадения первой карточки, это показатель что это значение следует задать в параметре `HoursUntilCardDrops`. Большинство (если не все) аккаунтов с ограниченим на выпадение карточек требуют как минимум `3` часа игрового времени до выпадения карточек, и поэтому это значение установлено по умолчанию в параметре `HoursUntilCardDrops`.

Помните что игры могут иметь разную скорость выпадения карточек, именно поэтому вам стоит проверить свою теорию на **как минимум** 3 играх, а лучше 5+, чтобы убедиться что вы не получили неверный результат из-за совпадения. Выпадение карточки в одной игре менее чем за час достаточно для подтверждения что ваш аккаунт **не** имеет ограничения, и вы можете поставить `HoursUntilCardDrops` значение `0`, однако чтобы подтвердить что ваш аккаунт **имеет** ограничение, вам нужно хотя бы несколько игр, в которых карточки не выпадают до достижения фиксированного предела.

Важно отметить, что в прошлом `HoursUntilCardDrops` могло иметь только значения `0` или `2`, и поэтому в ASF был один параметр `CardDropsRestricted`, позволяющий переключаться между этими значениями. Однако после недавних изменений мы заметили что большинству пользователей нужно уже `3` часа вместо прежних `2`, а также то, что `HoursUntilCardDrops` теперь динамический и может иметь разное значение для разных аккаунтов.

В конце концов, конечно, решать вам.

И чтобы ещё всё усложнить - я встречал случаи когда у людей менялся статус аккаунта с ограниченного на неограниченный и наоборот - либо из-за глюков Steam (о да, мы видели их много), или из-за изменений логики со стороны Valve. Поэтому даже если вы проверили что ваш аккаунт имеет ограничения (или нет), не думайте что это так и останется - чтобы получить ограничения достаточно запросить возврат средств. Если вы чувствуете, что ранее установленное значение больше не подходит, вы всегда можете протестировать заново и поменять значение на правильное.

---

По умолчанию, ASF считает что `HoursUntilCardDrops` равно `3`, поскольку отрицательный эффект от неверной установки этого параметра равным `3` должен быть меньше, чем в обратном случае. Такое решение принято потому, что в худшем случае мы потратим лишние `3` на каждые `32` игры, по сравнению с затраченными `3` часами на фарм каждой игры если бы `HoursUntilCardDrops` был по умолчанию равен `0`. Однако, вам следует настроить этот параметр в соответствии с вашим аккаунтом, чтобы достичь максимальной эффективности, поскольку значение по умолчанию - просто догадка вслепую на основе возможных отрицательных последствий для большинства пользователей (мы по умолчанию стараемся выбрать "меньшее зло").

На данный момент двух описанных выше алгоритмов достаточно для максимально эффективного фарма во всех известных сценариях, поэтому добавление других алгоритмов не планируется.

Рады отметить, что в ASF также присутствует ручной(Manual) режим фарма, который активируется командой `play`. Вы можете прочесть об этом больше в разделе "**[команды](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-ru-RU)**".

---

## Глюки Steam

Алгоритм выпадения карточек не всегда работает так, как должен, и вполне возможны случаи различных глюков стим, таких как выпадение карточек на ограниченных аккаунтах (на которых не потрачено 5$), выпадение карточек при закрытии/открытии игры, не выпадение карточек хотя игра запущена, отсутствие выпадения карточек в целом, и тому подобное.

Этот параграф в основном адресуется людям, которые спрашивают, почему ASF не делает **чего-нибудь**, например не переключается быстро между играми чтобы карточки падали быстрее.

Что такое **глюк Steam** - это особое действие, вызывающее **неопределённое** поведение, которое **не предусмотрено, не документировано и является ошибкой в логике работы**. Это **ненадёжно по определению**, а значит не может быть надёжно воспроизведено в чистой тестовой среде, и следовательно, не может быть запрограммировано без использования "хаков" которые должны предугадывать, какой глюк случиться и как с ним бороться / злоупотреблять им. Обычно это временное явление до момента пока разработчики не исправят ошибку в логике, хотя некоторые глюки могут существовать незамеченными очень долгий интервал времени.

Хорошим примером того, что считается **глюком Steam** является распространённая ситуация, когда карточка выпадает при зкарытии игры, этим можно злоупотреблять в какой-то степени с помощью функции пропуска игр в Idle Master.

- **Неопределённое поведение** - вы не можете сказать, выпадет 1 или 0 карточек когда вы используете этот глюк.
- **Не предусмотрено** - основываясь на прошлом опыте и поведении сети Steam это не даёт в один и тот же результат при посылке одного пакета.
- **Недокументировано** - на сайте Steam есть подробная документация по получению карточек Steam, и **везде** ясно написано, что их получают за **игру**, а не за закрытие игр, получение достижений, переключение между играми или запуск 32 игр одновременно.
- **Является ошибкой в логике** - закрытие игр(ы) или переключение между играми не должно приводить к выпадению карточек, поскольку в описании сказано, что их получают за **время проведенное в игре**.
- **Ненадёжное по определению, не может быть надёжно воспроизведено** - работает не у всех, и даже если один раз сработало у вас - может не сработать во второй раз.

Теперь, когда мы разобрались что такое глюк Steam, и в том что выпадение карточек при закрытии игр **это глюк**, мы можем перейти к следующему пункту -**ASF не злоупотребляет глюками сети Steam никаким образом, и старается соответствовать Соглашению подписчика Steam, его протоколам и общепринятым нормам**. Спам сети Steam постоянными запросами открытия/закрытия игры может быть сочтён **[DoS-атакой](https://ru.wikipedia.org/wiki/DoS-%D0%B0%D1%82%D0%B0%D0%BA%D0%B0)** и **напрямую нарушает [Правила поведения в Steam](https://store.steampowered.com/online_conduct/?l=russian)**.

> Как подписчик службы Steam вы должны придерживаться следующих правил поведения.
> 
> Запрещается:
> 
> Осуществлять атаки на серверы сервиса Steam или иным способом нарушать его работу.

Не имеет значения, можете ли вы использовать глюки Steam другими программами (такими как IM), и не важно, согласны ли вы с нами и считаете такое поведение DoS-атакой, или нет - это решать Valve, но если мы считаем это злоупотреблением непредусмотренными возможностями путём избыточных запросов к сети Steam, то вы можете быть вполне уверены что Valve будет придерживаться тех же взглядов.

ASF **никогда** не будет использовать преимущества злоупотреблений, хаков, эксплоитов Steam и прочей активности, которую мы считаем **незаконной или нежелательной** согласно Соглашению подписчика Steam, Правил поведения в Steam, или любому другому надёжному источнику, который будет указывать что кативность ASF является нежелательной для сети Steam, как это указано в разделе **[Правила участия в разработке](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/.github/CONTRIBUTING.md)**.

Если вы хотите любой ценой рискнуть своим аккаунтом Steam ради получения нескольких копеек за карточки Steam быстрее, чем обычно, то увы, ASF никогда не сможет вам предложить нечто подобное в автоматическом режиме, хотя у вас остаётся **[команда](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-ru-RU)** `play`, с помощью которой вы можете делать что угодно в плане взаимодействия с сетью Steam. Ме не рекомендуем злоупотреблять глюками Steam и использовать их для собственной выгоды - не только с помощью ASF, но и с помощью других утилит. Однако, в конце концов, это ваш аккаунт, и ваш выбор что делать с ним - просто помните, что мы вас предупредили.