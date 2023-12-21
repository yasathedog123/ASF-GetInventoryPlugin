# Steam Family Sharing

ASF supports Steam Family Sharing - in order to understand how ASF works with that, you should firstly read how **[Steam Family Sharing works](https://store.steampowered.com/promotion/familysharing)**, which is available on Steam store.

---

## ASF

Поддержка Steam Family Sharing в ASF достаточно прозрачна, в том смысле что она не требует никаких дополнительных параметров конфигурации бота/процесса - она просто работает "из коробки" как дополнительный встроенный функционал.

ASF включает в себя соответствующую логику для того, чтобы отслеживать использование библиотеки пользователями Steam Family Sharing, и поэтому не будет "выбрасывать" их из игровой сессии из-за запуска игры. ASF будет работать так же, как в случае когда библиотека заблокирована основным аккаунтом, поэтому если библиотека используется либо с вашего клиента steam, либо одним из пользователей Steam Family Sharing, ASF не будет пытаться фармить, и будет вместо этого ожидать пока библиотека освободится.

In addition to above, after logging in, ASF will access your **[family sharing settings](https://store.steampowered.com/account/managedevices)**, from which it'll extract up to 5 `steamIDs` allowed to use your library. Этим пользователям будут присвоены права доступа `FamilySharing`, позволяющие использовать некоторые **[команды](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-ru-RU)**, в частности позволяя им использовать команду `pause~` на аккаунте, который разрешил им доступ к библиотеке, что позволяет поставить модуль фарма на паузу, чтобы запустить игру доступную через Steam Family Sharing.

Connecting both functionalities described above allows your friends to `pause~` your cards farming process, start a game, play as long as they wish, and then after they're done playing, cards farming process will be automatically resumed by ASF. Разумеется, команда `pause~` не нужна если ASF в данный момент ничего не фармит, поскольку ваши друзья могут просто запустить игру, и логика, описанная выше, проследит чтобы они не были "выброшены" из игровой сессии.

---

## Ограничения

Сеть Steam любит дурачить ASF пересылая неверные обновления состояния, что может привести к ситуации, когда ASF считает что можно продолжать процесс фарма, и в результате "выбросит" вашего друга раньше времени. Это та же проблема, что и описанная нами в **[этом пункте ЧаВо](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ-ru-RU#user-content-asf-%D0%BE%D1%82%D0%BA%D0%BB%D1%8E%D1%87%D0%B0%D0%B5%D1%82-%D0%BC%D0%BE%D1%8E-%D1%81%D0%B5%D1%81%D1%81%D0%B8%D1%8E-%D0%BA%D0%BB%D0%B8%D0%B5%D0%BD%D1%82%D0%B0-steam-%D0%BA%D0%BE%D0%B3%D0%B4%D0%B0-%D1%8F-%D0%B8%D0%B3%D1%80%D0%B0%D1%8E--%D0%AD%D1%82%D0%BE%D1%82-%D0%B0%D0%BA%D0%BA%D0%B0%D1%83%D0%BD%D1%82-%D1%83%D0%B6%D0%B5-%D0%B3%D0%B4%D0%B5-%D1%82%D0%BE-%D0%B8%D1%81%D0%BF%D0%BE%D0%BB%D1%8C%D0%B7%D1%83%D0%B5%D1%82%D1%81%D1%8F)**. Мы рекомендуем те же методы её решения, в основном - предоставить вашим друзьям права доступа `Operator` (или выше) и научить их использовать команды `pause` и `resume`.