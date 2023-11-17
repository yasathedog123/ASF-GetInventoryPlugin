# Сторонние разработки

Этот раздел включает в себя различные дополнения сторонних разработчиков, разработанные специально (или в основном) для использования совместно с ASF. Они покрывают весь спектр начиная с плагинов для ASF, простых веб-приложений, включая простые веб-приложения и внутренние библиотеки для удобства дальнейшей интеграции, и заканчивая полнофункциональными ботами для других платформ. Если вы хотите добавить что-то в этот список - свяжитесь с нами на нашем сервере Discord или в нашей группе Steam.

Пожалуйста, обратите внимание, что программы ниже **не** поддерживаются разработчиками ASF и поэтому **мы не даём никаких гарантий относительно них**, особенно в части безопасности, надёжности и соответствия соглашению подписчика Steam. Этот список поддерживается только для справок. Вы всегда должны быть уверены, что сторонняя утилита, которую вы собираетесь использовать, является безопасной и достаточно легальной для вас, поскольку вы используете их на свой страх и риск.

---

## Плагины для ASF

### **[Rudokhvist](https://github.com/Rudokhvist)**

- **[ASF-Achievement-Manager](https://github.com/Rudokhvist/ASF-Achievement-Manager)**, плагин для ASF, дающий возможность управлять достижениями Steam.
- **[BirthdayPlugin](https://github.com/Rudokhvist/BirthdayPlugin)**, плагин для ASF для получения поздравлений с днем рождения.
- **[BoosterCreator](https://github.com/Rudokhvist/BoosterCreator)**, плагин для ASF, добавляющий функционал создания наборов карточек из самоцветов.
- **[Case-Insensitive-ASF](https://github.com/Rudokhvist/Case-Insensitive-ASF)**, плагин для ASF, который делает имена ботов регистронезависимыми.
- **[Commandless-Redeem](https://github.com/Rudokhvist/Commandless-Redeem)**, плагин, возвращающий в ASF возможность активации ключей без команды.
- **[ItemDispenser](https://github.com/Rudokhvist/ItemDispenser)**, плагин для ASF, позволяющий автоматически принимать предложения обмена, в которых у него запрашивают предметы заданного(ых) типа(ов).
- **[ Selective-Loot-and-Transfer-Plugin](https://github.com/Rudokhvist/Selective-Loot-and-Transfer-Plugin)**, плагин для ASF, предоставляющий расширение команды `transfer` для передачи предметов Steam.

### **[VITA](https://github.com/ezhevita)**

- **[FriendAccepter](https://github.com/ezhevita/FriendAccepter)**, плагин для ASF, позволяющий автоматически принимать все приглашения в друзья.
- **[GameRemover](https://github.com/ezhevita/GameRemover)**, плагин для ASF, реализующий команду удаления лицензий Steam для выбранных экземпляров ботов.
- **[GetEmail](https://github.com/ezhevita/GetEmail)**, плагин для ASF, реализующий команду для получения адресов электронной почты заданных экземпляров ботов непосредственно из Steam.
- **[ResetAPIKey](https://github.com/ezhevita/ResetAPIKey)**, плагин для ASF, реализующий команду сброса ключа API для выбранных экземпляров ботов.
- **[SteamKitProxyInjection](https://github.com/ezhevita/SteamKitProxyInjection)**, плагин для ASF, позволяющий направить соединения по WebSocket через прокси.

### Другое

- **[ASFEnhance](https://github.com/chr233/ASFEnhance)**, плагин для ASF, дополняющий его различными новыми функциями, особенно командами.

---

## Интеграции

- **[ASFBot](https://github.com/dmcallejo/ASFBot)**, бот для telegram, написанный на python и интегрированный с ASF.
- **[ASF STM](https://greasyfork.org/en/scripts/404754-asf-stm)** - userscript для тех, кто хочет отправлять автоматизированные торговые предложения ботам в нашем **[листинге ASF STM](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#publiclisting)** через веб-браузер без использования функции `MatchActively`, предоставляемой ASF.
- **[telegram-asf](https://github.com/deluxghost/telegram-asf)**, другой (минималистичный) бот для telegram, написанный на python и интегрированный с ASF.

---

## Библиотеки

- **[ASF-IPC](https://github.com/deluxghost/ASF_IPC)**, библиотека на языке python для удобной интеграции с интерфейсом ASF IPC.

---

## Пакетная установка

- **[репозиторий AUR #1](https://aur.archlinux.org/packages/asf)**, позволяющий легко установить ASF на Arch linux.
- **[репозиторий AUR #2](https://aur.archlinux.org/packages/archisteamfarm-bin)**, позволяющий легко установить ASF на Arch linux.
- **[репозиторий Homebrew](https://formulae.brew.sh/formula/archi-steam-farm)**, позволяющий легко установить ASF на macOS.
- **[репозиторий Nix](https://search.nixos.org/packages?channel=unstable&show=ArchiSteamFarm&from=0&size=50&sort=relevance&type=packages&query=ArchiSteamFarm)**, позволяющий легко установить ASF на дистрибутивы с Nix.
- **[репозиторий NixOS](https://search.nixos.org/options?channel=unstable&from=0&size=50&sort=relevance&type=packages&query=ArchiSteamFarm)**, позволяющий легко установить ASF на дистрибутивы с NixOS.

---

## Инструменты

- **[Keys extractor](https://ske.xpixv.com)**, позволяет вам копировать/вставлять ключи в различных форматах и формировать команду `redeem` для ASF. Вы найдёте подробности в **[репозитории на GitHub](https://github.com/PixvIO/SKE)**.
- **[ASF Mass Config Editor](https://github.com/genesix-eu/ASF_MCE)**, позволяет проще управлять большим количеством конфигурационных файлов ASF.

---

## Хотите найти больше?

Мы рекомендуем использовать на GitHub метку **[ArchiSteamFarm](https://github.com/topics/archisteamfarm)** для всех проектов, имеющих интеграцию с ASF.