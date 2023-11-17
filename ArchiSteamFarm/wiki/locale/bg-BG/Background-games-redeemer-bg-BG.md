# Активатор на игри на заден фон

Активатора на игри на заден фон е специална вградена функция на ASF, която позволява комплекти на ключове за игри (заедно с техните имена), да бъдат активиране на заден фон. Това е особено полезно, когато имате голям набор от ключове и е сигурно, че ще стигнете `RateLimited` **[status](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#what-is-the-meaning-of-status-when-redeeming-a-key)** преди да преключите с всички.

Активатора на игри на заден фон е създаден да има само едно ползване на бот, което означава, че не ползва `RedeemingPreferences`. Тази функция може да бъде ползвана заедно (или вместо) `redeem` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**, ако е нужно.

---

## Импортиране

Процесът на импортиране може да се извърши по два начина - чрез използване на файл или IPC.

### Файл

ASF ще разпознае в своята `config` директория файл наречен `BotName.keys` където `BotName` е името на вашия бот. That file has expected and fixed structure of name of the game with cd-key, separated from each other by a tab character and ending with a newline to indicate the next entry. If multiple tabs are used, then first entry is considered game's name, last entry is considered a cd-key, and everything in-between is ignored. Например:

```text
POSTAL 2    ABCDE-EFGHJ-IJKLM
Domino Craft VR 12345-67890-ZXCVB
A Week of Circus Terror POIUY-KJHGD-QWERT
Terraria    ThisIsIgnored   ThisIsIgnoredToo    ZXCVB-ASDFG-QWERT
```

Alternatively, you're also able to use keys only format (still with a newline between each entry). В този случай, ASF ще ползва резултата на Steam (ако е възможно), за да запълни правилното име. For any kind of keys tagging, we recommend that you name your keys yourself, as packages being redeemed on Steam do not have to follow logic of games that they're activating, so depending on what the developer has put, you may see correct game names, custom package names (e.g. Humble Indie Bundle 18) or outright wrong and potentially even malicious ones (e.g. Half-Life 4).

```text
ABCDE-EFGHJ-IJKLM
12345-67890-ZXCVB
POIUY-KJHGD-QWERT
ZXCVB-ASDFG-QWERT
```

Независимо кой формат сте решили да ползвате, ASF ще внедри вашия `keys` файл или при стартиране на бота, или по време на работа. After successful parse of your file and eventual omit of invalid entries, all properly detected games will be added to the background queue, and the `BotName.keys` file itself will be removed from `config` directory.

### Процеси на вътрешна комуникация

In addition to using keys file mentioned above, ASF also exposes `GamesToRedeemInBackground` **[ASF API endpoint](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-api)** which can be executed by any IPC tool, including our ASF-ui. Using IPC could be more powerful, as you can do appropriate parsing yourself, such as using a custom delimiter instead of being forced to a tab character, or even introducing your entirely own customized keys structure.

---

## Опашка

Once games are successfully imported, they're added to the queue. ASF automatically goes through its background queue as long as bot is connected to Steam network, and the queue is not empty. A key that was attempted to be redeemed and did not result in `RateLimited` is removed from the queue, with its status properly written to a file in `config` directory - either `BotName.keys.used` if the key was used in the process (e.g. `NoDetail`, `BadActivationCode`, `DuplicateActivationCode`), or `BotName.keys.unused` otherwise. ASF intentionally uses your provided game's name since key is not guaranteed to have a meaningful name returned by Steam network - this way you can tag your keys using even custom names if needed/wanted.

If during the process our account hits `RateLimited` status, the queue is temporarily suspended for a full hour in order to wait for cooldown to disappear. Afterwards, the process continues where it left, until the entire queue is empty or another `RateLimited` occurs.

---

## Пример

Да предположим, че имате списък със 100 ключа. Firstly you should create a new `BotName.keys.new` file in ASF `config` directory. We appended `.new` extension in order to let ASF know that it shouldn't pick up this file immediately the moment it's created (as it's new empty file, not ready for import yet).

Now you can open our new file and copy-paste list of our 100 keys there, fixing the format if needed. After fixes our `BotName.keys.new` file will have exactly 100 (or 101, with last newline) lines, each line having a structure of `GameName\tcd-key\n`, where `\t` is tab character and `\n` is newline.

You're now ready to rename this file from `BotName.keys.new` to `BotName.keys` in order to let ASF know that it's ready to be picked up. The moment you do this, ASF will automatically import the file (without a need of restart) and delete it afterwards, confirming that all our games were parsed and added to the queue.

Instead of using `BotName.keys` file, you could also use IPC API endpoint, or even combining both if you want to.

After some time, `BotName.keys.used` and `BotName.keys.unused` files will be generated. Тези файлове съдържат резултатите от нашите процеси за активиране. For example, you could rename `BotName.keys.unused` into `BotName2.keys` file and therefore submit our unused keys for some other bot, since previous bot didn't make use of those keys himself. Or you could simply copy-paste unused keys to some other file and keep it for later, your call. Keep in mind that as ASF goes through the queue, new entries will be added to our output `used` and `unused` files, therefore it's recommended to wait for the queue to be fully emptied before making use of them. If you absolutely must access those files before queue is fully emptied, you should firstly **move** output file you want to access to some other directory, **then** parse it. This is because ASF can append some new results while you're doing your thing, and that could potentially lead to loss of some keys if you read a file having e.g. 3 keys inside, then delete it, totally missing the fact that ASF added 4 other keys to your removed file in the meantime. If you want to access those files, ensure to move them away from ASF `config` directory before reading them, for example by rename.

It's also possible to add extra games to import while having some games already in our queue, by repeating all above steps. ASF will properly add our extra entries to already-ongoing queue and deal with it eventually.

---

## Бележки

Background keys redeemer uses `OrderedDictionary` under the hood, which means that your cd-keys will have preserved order as they were specified in the file (or IPC API call). This means that you can (and should) provide a list where given cd-key can only have direct dependencies on cd-keys listed above, but not below. For example, this means that if you have DLC `D` that requires game `G` to be activated firstly, then cd-key for game `G` should **always** be included before cd-key for DLC `D`. Likewise, if DLC `D` would have dependencies on `A`, `B` and `C`, then all 3 should be included before (in any order, unless they have dependencies on their own).

Not following the scheme above will result in your DLC not being activated with `DoesNotOwnRequiredApp`, even if your account would be eligible for activating it after going through its entire queue. If you want to avoid that then you must make sure that your DLC is always included after the base game in your queue.