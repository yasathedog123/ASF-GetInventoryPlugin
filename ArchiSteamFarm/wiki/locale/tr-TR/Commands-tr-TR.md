# Komutlar

ASF, bot örneklerinin ve sürecin davranışlarını kontrol etmek için kullanılabilecek çeşitli komutları destekler.

Aşağıdaki komutlar çeşitli yollarla bota gönderilebilir:
- Etkileşimli ASF konsolu aracılığıyla
- Steam özel/grup sohbeti aracılığıyla
- **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)** arayüzümüz aracılığıyla

ASF etkileşimlerinin komutlar için uygun yetkiye sahip olmanızı gerektirdiğini unutmayın. Daha fazla bilgi için `SteamUserPermissions` ve `SteamOwnerID` yapılandırma özelliklerini kontrol edin.

Steam sohbeti aracılığıyla yürütülen komutlar, varsayılan olarak `!` olan `KomutÖneki` **[genel yapılandırma özelliğinden](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#commandprefix)** etkilenir. Bu demek oluyor ki örnek olarak `status` komutunu ele alırsak, `!status` yazmanız gerektiği anlamına geliyor(veya kendiniz için belirlediğiniz özel `KomutÖneki`ni kullanarak). `KomutÖneki` konsol veya IPC kullanılırken zorunlu değildir ve atlanabilir.

---

### Etkileşimli konsol

ASF has support for interactive console, as long as you're not running ASF in [**`Headless`**](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#headless) mode. Komut modunu etkinleştirmek için `c` tuşuna basıp komutunuzu yazmanız ve enter ile onaylamanız yeterlidir.

![Ekran Görüntüsü](https://i.imgur.com/bH5Gtjq.png)

---

### Steam sohbeti

ASF Bot'una verilen komutları Steam sohbeti üzerinden yürütebilirsiniz. Açıkçası doğrudan kendinizle konuşamazsınız, bu nedenle ana hesabınızı hedefleyen komutları yürütmek istiyorsanız en az bir başka bot hesabına ihtiyacınız olacak.

![Ekran Görüntüsü](https://i.imgur.com/IvFRJ5S.png)

Benzer şekilde, belirli Steam grubunun grup sohbetini de kullanabilirsiniz. Bu seçeneğin `SteamMasterClanID` uygun şekilde ayarlanması gerektirdiğini unutmayın. Bu durumda bot o grubun sohbetini dinleyecek(ve gerekirse grup sohbetine katılacak). Bu, özel sohbetin aksine özel bir bot hesabı gerektirmediğinden "kendinizle konuşmak" için de kullanılabilir. `SteamMasterClanID` özelliğini yeni oluşturduğunuz gruba kolayca ayarlayıp daha sonra kendi botunuzun `SteamOwnerID` veya `SteamUserPermissions` aracılığıyla kendinize erişim sağlayabilirsiniz. Bu şekilde ASF botu (siz) seçtiğiniz grub sohbetine katılacak ve kendi hesabınızdan komutları dinleyecek. Kendinize komutlar vermek için aynı grup sohbet odasına katılabilirsiniz(sohbet odasına komut göndereceksiniz ve aynı sohbet odasında duran ASF örneği, yalnızca hesabınız oradayken görünse bile bunları alacaktır).

Lütfen grup sohbetine bir komut göndermenin bütün botlara etki edeceğini unutmayın. Grup sohbetinde sizinle birlikte duran botlarınızdan 3'üne `X anahtarını aktifleştirin` diyorsanız sonuç hepsine özel sohbet ile her birine `X anahtarını aktifleştirin` sonucuyla aynı olacaktır. Çoğu durumda **istediğiniz bu olmayacak** ve bunun yerine `verilen bot` komutunu **özel sohbet penceresinde tek bir bota** göndermelisiniz. ASF grup sohbetini destekler, birçok durumda olduğu gibi tek botunuzla iletişim için yararlı bir kaynak olabilir ancak orada duran 2 veya daha fazla ASF botu varsa grup sohbetinde neredeyse hiçbir zaman herhangi bir komut yürütmemelisiniz. Burada yazılı olan ASF davranışını tam olarak anlamadığınız sürece sizi dinleyen her bota aynı komutu iletmek istemezseniz.

*Ve bu durumda bile, bunun yerine `[Bots]` sözdizimi ile özel sohbeti kullanmalısınız.*

---

### IPC

Komutları çalıştırmanın en gelişmiş ve esnek yolu, kullanıcı etkileşimi için mükemmel (ASF-ui) yanı sıra üçüncü taraf araçlar veya komut dosyası oluşturmak için de mükemmel (ASF API), ASF'in `IPC` modunda çalışması ve **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)** arayüzü üzerinden komutu yürüten bir istemci gereklidir.

![Ekran Görüntüsü](https://raw.githubusercontent.com/JustArchiNET/ASF-ui/main/.github/previews/commands.png)

---

## Komutlar

| Komut                                                                | Erişim           | Açıklama                                                                                                                                                                                                                                                                                                                            |
| -------------------------------------------------------------------- | ---------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `2fa [Bots]`                                                         | `Master`         | Girilen botlar için geçici **[2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)** kodu oluşturur.                                                                                                                                                                                                 |
| `2fafinalize [Bots] <ActivationCode>`                          | `Master`         | Finalizes process of assigning new **[2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication#creation)** credentials for given bot instances, using SMS/e-mail activation code.                                                                                                                         |
| `2fafinalized [Bots] <ActivationCode>`                         | `Master`         | Imports already-finalized **[2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication#creation)** credentials for given bot instances, using 2FA token for verification.                                                                                                                                  |
| `2fafinalizedforce [Bots]`                                           | `Master`         | Imports already-finalized **[2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication#creation)** credentials for given bot instances, skipping 2FA token verification.                                                                                                                                   |
| `2fainit [Bots]`                                                     | `Master`         | Her iki örnek için de yeni **[2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication#creation)** kimlik bilgileri atama işlemini başlatır.                                                                                                                                                              |
| `2fano [Bots]`                                                       | `Master`         | Belirtilen botlar için **[2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)** doğrulama gerektiren bütün işlemleri reddeder.                                                                                                                                                                      |
| `2faok [Bots]`                                                       | `Master`         | Belirtilen botlar için **[2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)** doğrulama gerektiren bütün işlemleri kabul eder.                                                                                                                                                                    |
| `addlicense [Bots] <Licenses>`                                 | `Operatör`       | Verilen `lisansları` **[aşağıda](#addlicense-licenses)** açıklanan verilen bot örneklerinde etkinleştirir. (yalnızca ücretsiz oyunlar).                                                                                                                                                                                             |
| `balance [Bots]`                                                     | `Master`         | Verilen bot örneklerinin cüzdan bakiyesini gösterir.                                                                                                                                                                                                                                                                                |
| `bgr [Bots]`                                                         | `Master`         | Verilen bot örneklerinin **[BGR](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer)** kuyruğu hakkındaki bilgileri yazdırır.                                                                                                                                                                            |
| `encrypt <encryptionMethod> <stringToEncrypt>`           | `Sahip`          | Verilen dizeyi sağlanan kriptografik yöntem ile şifreler - daha fazla detay **[aşağıda](#encrypt-command)**.                                                                                                                                                                                                                        |
| `exit`                                                               | `Sahip`          | Tüm ASF işlemini durdurur.                                                                                                                                                                                                                                                                                                          |
| `farm [Bots]`                                                        | `Master`         | Kart işleme modülünü verilen bot örnekleri için yeniden başlatır.                                                                                                                                                                                                                                                                   |
| `fb [Bots]`                                                          | `Master`         | Her iki durumda da verilen otomatik tarımdan kara listeye alınan uygulamaları listeler.                                                                                                                                                                                                                                             |
| `fbadd [Bots] <AppIDs>`                                        | `Master`         | Verilen `appID`'leri, verilen her iki örneğin otomatik çiftçiliğinden kara listeye alınan uygulamalara ekler.                                                                                                                                                                                                                       |
| `fbrm [Bots] <AppIDs>`                                         | `Master`         | Verilen `appID`'lerini kara listeye alınan uygulamalardan, verilen her iki örneğin otomatik çiftçiliğinden kaldırır.                                                                                                                                                                                                                |
| `fq [Bots]`                                                          | `Master`         | Her iki durumda da verilen öncelikli çiftçilik kuyruğunu listeler.                                                                                                                                                                                                                                                                  |
| `fqadd [Bots] <AppIDs>`                                        | `Master`         | Adds given `appIDs` to priority farming queue of given bot instances.                                                                                                                                                                                                                                                               |
| `fqrm [Bots] <AppIDs>`                                         | `Master`         | Removes given `appIDs` from farming queue of given bot instances.                                                                                                                                                                                                                                                                   |
| `hash <hashingMethod> <stringToHash>`                    | `Sahip`          | Generated a hash of the string using provided cryptographic method - further explained **[below](#hash-command)**.                                                                                                                                                                                                                  |
| `help`                                                               | `Aile Paylaşımı` | Yardım gösterir (bu sayfanın bağlantısı).                                                                                                                                                                                                                                                                                           |
| `input [Bots] <Type> <Value>`                            | `Master`         | Sets given input type to given value for given bot instances, works only in `Headless` mode - further explained **[below](#input-command)**.                                                                                                                                                                                        |
| `level [Bots]`                                                       | `Master`         | Shows Steam account level of given bot instances.                                                                                                                                                                                                                                                                                   |
| `loot [Bots]`                                                        | `Master`         | Sends all `LootableTypes` Steam community items of given bot instances to `Master` user defined in their `SteamUserPermissions` (with lowest steamID if more than one).                                                                                                                                                             |
| `loot@ [Bots] <AppIDs>`                                        | `Master`         | Sends all `LootableTypes` Steam community items matching given `AppIDs` of given bot instances to `Master` user defined in their `SteamUserPermissions` (with lowest steamID if more than one). This is the opposite of `loot%`.                                                                                                    |
| `loot% [Bots] <AppIDs>`                                        | `Master`         | Sends all `LootableTypes` Steam community items apart from given `AppIDs` of given bot instances to `Master` user defined in their `SteamUserPermissions` (with lowest steamID if more than one). This is the opposite of `loot@`.                                                                                                  |
| `loot^ [Bots] <AppID> <ContextID>`                       | `Master`         | Sends all Steam items from given `AppID` in `ContextID` of given bot instances to `Master` user defined in their `SteamUserPermissions` (with lowest steamID if more than one).                                                                                                                                                     |
| `mab [Bots]`                                                         | `Master`         | Lists apps blacklisted from automatic trading in **[`MatchActively`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#matchactively)**.                                                                                                                                                                       |
| `mabadd [Bots] <AppIDs>`                                       | `Master`         | Adds given `appIDs` to apps blacklisted from automatic trading in **[`MatchActively`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#matchactively)**.                                                                                                                                                      |
| `mabrm [Bots] <AppIDs>`                                        | `Master`         | Removes given `appIDs` from apps blacklisted from automatic trading in **[`MatchActively`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#matchactively)**.                                                                                                                                                 |
| `match [Bots]`                                                       | `Master`         | Special command for **[`ItemsMatcherPlugin`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#matchactively)** which triggers `MatchActively` routine immediately.                                                                                                                                            |
| `nickname [Bots] <Nickname>`                                   | `Master`         | Verilen bot örneklerinin Steam takma adını verilen `nickname` olarak değiştirir.                                                                                                                                                                                                                                                    |
| `owns [Bots] <Games>`                                          | `Operatör`       | Checks if given bot instances already own given `games`, explained **[below](#owns-games)**.                                                                                                                                                                                                                                        |
| `pause [Bots]`                                                       | `Operator`       | Permanently pauses automatic cards farming module of given bot instances. ASF will not attempt to farm current account in this session, unless you manually `resume` it, or restart the process.                                                                                                                                    |
| `pause~ [Bots]`                                                      | `Aile Paylaşımı` | Temporarily pauses automatic cards farming module of given bot instances. Farming will be automatically resumed on the next playing event, or bot disconnect. You can `resume` farming to unpause it.                                                                                                                               |
| `pause& [Bots] <Seconds>`                                  | `Operatör`       | Temporarily pauses automatic cards farming module of given bot instances for given amount of `seconds`. After delay, cards farming module is automatically resumed.                                                                                                                                                                 |
| `play [Bots] <AppIDs,GameName>`                                | `Master`         | Switches to manual farming - launches given `AppIDs` on given bot instances, optionally also with custom `GameName`. In order for this feature to work properly, your Steam account **must** own a valid license to all the `AppIDs` that you specify here, this includes F2P games as well. Use `reset` or `resume` for returning. |
| `points [Bots]`                                                      | `Master`         | Displays number of points in **[Steam points shop](https://store.steampowered.com/points/shop)**.                                                                                                                                                                                                                                   |
| `privacy [Bots] <Settings>`                                    | `Master`         | Changes **[Steam privacy settings](https://steamcommunity.com/my/edit/settings)** of given bot instances, to appropriately selected options explained **[below](#privacy-settings)**.                                                                                                                                               |
| `redeem [Bots] <Keys>`                                         | `Operatör`       | Redeems given cd-keys or wallet codes on given bot instances.                                                                                                                                                                                                                                                                       |
| `redeem^ [Bots] <Modes> <Keys>`                          | `Operatör`       | Redeems given cd-keys or wallet codes on given bot instances, using given `modes` explained **[below](#redeem-modes)**.                                                                                                                                                                                                             |
| `reset [Bots]`                                                       | `Master`         | Resets the playing status back to original (previous) state, the command is used during manual farming with `play` command.                                                                                                                                                                                                         |
| `restart`                                                            | `Sahip`          | ASF'i yeniden başlatır.                                                                                                                                                                                                                                                                                                             |
| `resume [Bots]`                                                      | `Aile Paylaşımı` | Resumes automatic farming of given bot instances.                                                                                                                                                                                                                                                                                   |
| `start [Bots]`                                                       | `Master`         | Verilen bot örneklerini başlatır.                                                                                                                                                                                                                                                                                                   |
| `stats`                                                              | `Sahip`          | Yönetilen bellek kullanımı gibi işlem istatistiklerini yazdırır.                                                                                                                                                                                                                                                                    |
| `status [Bots]`                                                      | `Aile Paylaşımı` | Verilen bot örneklerinin durumunu yazdırır.                                                                                                                                                                                                                                                                                         |
| `std [Bots]`                                                         | `Master`         | Special command for **[`SteamTokenDumperPlugin`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/SteamTokenDumperPlugin)** which triggers refresh of selected bots and submission of data immediately.                                                                                                                          |
| `stop [Bots]`                                                        | `Master`         | Verilen bot örneklerini durdurur.                                                                                                                                                                                                                                                                                                   |
| `tb [Bots]`                                                          | `Master`         | Belirli bot örneklerinin ticaret modülünden kara listeye alınmış kullanıcıları listeler.                                                                                                                                                                                                                                            |
| `tbadd [Bots] <SteamIDs64>`                                    | `Master`         | Verilen `steamIDs` 'leri takas modülünden verilen bot örnekleri için kara listeye ekler.                                                                                                                                                                                                                                            |
| `tbrm [Bots] <SteamIDs64>`                                     | `Master`         | Verilen `steamIDs` 'leri takas modülünden verilen bot örnekleri için kara listeden çıkarır.                                                                                                                                                                                                                                         |
| `transfer [Bots] <TargetBot>`                                  | `Master`         | Sends all `TransferableTypes` Steam community items from given bot instances to target bot instance.                                                                                                                                                                                                                                |
| `transfer@ [Bots] <AppIDs> <TargetBot>`                  | `Master`         | Sends all `TransferableTypes` Steam community items matching given `AppIDs` from given bot instances to target bot instance. This is the opposite of `transfer%`.                                                                                                                                                                   |
| `transfer% [Bots] <AppIDs> <TargetBot>`                  | `Master`         | Sends all `TransferableTypes` Steam community items apart from given `AppIDs` from given bot instances to target bot instance. This is the opposite of `transfer@`.                                                                                                                                                                 |
| `transfer^ [Bots] <AppID> <ContextID> <TargetBot>` | `Master`         | Sends all Steam items from given `AppID` in `ContextID` of given bot instances to target bot instance.                                                                                                                                                                                                                              |
| `unpack [Bots]`                                                      | `Master`         | Unpacks all booster packs stored in the inventory of given bot instances.                                                                                                                                                                                                                                                           |
| `update [Channel]`                                                   | `Sahip`          | Checks GitHub for new ASF release and updates to it if available. This is normally done automatically every `UpdatePeriod`. Optional `Channel` argument specifies the `UpdateChannel`, if not provided defaults to the one set in global config.                                                                                    |
| `version`                                                            | `Aile Paylaşımı` | ASF sürümünü yazdırır.                                                                                                                                                                                                                                                                                                              |

---

### Notlar

All commands are case-insensitive, but their arguments (such as bot names) are usually case-sensitive.

Arguments follow UNIX philosophy, square brackets `[Optional]` indicate that given argument is optional, while angle brackets `<Mandatory>` indicate that given argument is mandatory. You should replace the arguments that you want to declare, such as `[Bots]` or `<Nickname>` with actual values that you want to issue the command with, omitting the braces.

`[Bots]` argument, as indicated by the brackets, is optional in all commands. When specified, command is executed on given bots. When omitted, command is executed on current bot that receives the command. In other words, `status A` sent to bot `B` is the same as sending `status` to bot `A`, bot `B` in this case acts only as a proxy. This can also be used for sending commands to bots that are unavailable otherwise, for example starting stopped bots, or executing actions on your main account (that you're using for executing the commands).

**Access** of the command defines **minimum** `EPermission` of `SteamUserPermissions` that is required to use the command, with an exception of `Owner` which is `SteamOwnerID` defined in global configuration file (and highest permission available).

Plural arguments, such as `[Bots]`, `<Keys>` or `<AppIDs>` mean that command supports multiple arguments of given type, separated by a comma. For example, `status [Bots]` can be used as `status MyBot,MyOtherBot,Primary`. This will cause given command to be executed on **all target bots** in the same way as you'd send `status` to each bot in a separate chat window. Please note that there is no space after `,`.

ASF uses all whitespace characters as possible delimiters for a command, such as space and newline characters. This means that you don't have to use space for delimiting your arguments, you can as well use any other whitespace character (such as tab or new line).

ASF will "join" extra out-of-range arguments to plural type of the last in-range argument. This means that `redeem bot key1 key2 key3` for `redeem [Bots] <Keys>` will work exactly the same as `redeem bot key1,key2,key3`. Together with accepting newline as command delimiter, this makes it possible for you to write `redeem bot` then paste a list of keys separated by any acceptable delimiter character (such as newline), or standard `,` ASF delimiter. Keep in mind that this trick can be used only for command variant that uses the most amount of arguments (so specifying `[Bots]` is mandatory in this case).

As you've read above, a space character is being used as a delimiter for a command, therefore it can't be used in arguments. However, also as stated above, ASF can join out-of-range arguments, which means that you're actually able to use a space character in argument that is defined as a last one for given command. For example, `nickname bob Great Bob` will properly set nickname of `bob` bot to "Great Bob". In the similar way you can check names containing spaces in `owns` command.

---

Some commands are also available with their aliases, mostly to save you on typing or account for different dialects:

| Komut            | Alias              |
| ---------------- | ------------------ |
| `addlicense`     | `al`, `addlicence` |
| `addlicense ASF` | `ala`              |
| `owns ASF`       | `oa`               |
| `status ASF`     | `sa`               |
| `redeem`         | `r`                |
| `redeem^`        | `r^`               |

---

### `[Bots]` argument

`[Bots]` argument is a special variant of plural argument, as in addition to accepting multiple values it also offers extra functionality.

First and foremost, there is a special `ASF` keyword which acts as "all bots in the process", so `status ASF` command is equal to `status all,your,bots,listed,here`. This can also be used to easily identify the bots that you have access to, as `ASF` keyword, despite of targeting all bots, will result in response only from those bots that you can actually send the command to.

`[Bots]` argument supports special "range" syntax, which allows you to choose a range of bots more easily. The general syntax for `[Bots]` in this case is `[FirstBot]..[LastBot]`. At least one of the arguments must be defined. When using `<FirstBot>..`, all bots starting from `FirstBot` are affected. When using `..<LastBot>`, all bots until `LastBot` are affected. When using `<FirstBot>..<LastBot>`, all bots within range from `FirstBot` until `LastBot` are affected. For example, if you have bots named `A, B, C, D, E, F`, you can execute `status B..E`, which is equal to `status B,C,D,E` in this case. When using this syntax, ASF will use alphabetical sorting in order to determine which bots are in your specified range. Arguments must be valid bot names recognized by ASF, otherwise range syntax is entirely skipped.

In addition to range syntax above, `[Bots]` argument also supports **[regex](https://en.wikipedia.org/wiki/Regular_expression)** matching. You can activate regex pattern by using `r!<Pattern>` as a bot name, where `r!` is ASF activator for regex matching, and `<Pattern>` is your regex pattern. An example of a regex-based bot command would be `status r!^\d{3}` which will send `status` command to bots that have a name made out of 3 digits (e.g. `123` and `981`). Feel free to take a look at the **[docs](https://docs.microsoft.com/dotnet/standard/base-types/regular-expression-language-quick-reference)** for further explanation and more examples of available regex patterns.

---

## `Gizlilik` ayarları

`<Settings>` argument accepts **up to 7** different options, separated as usual with standard comma ASF delimiter. Those are, in order:

| Argüman | İsim           | Child of   |
| ------- | -------------- | ---------- |
| 1       | Profile        |            |
| 2       | OwnedGames     | Profile    |
| 3       | Playtime       | OwnedGames |
| 4       | FriendsList    | Profile    |
| 5       | Inventory      | Profile    |
| 6       | InventoryGifts | Inventory  |
| 7       | Comments       | Profile    |

For description of above fields, please visit **[Steam privacy settings](https://steamcommunity.com/my/edit/settings)**.

While valid values for all of them are:

| Değer | İsim          |
| ----- | ------------- |
| 1     | `Private`     |
| 2     | `FriendsOnly` |
| 3     | `Public`      |

You can use either a case-insensitive name, or a numeric value. Arguments that were omitted will default to being set to `Private`. It's important to note relation between child and parent of arguments specified above, as child can never have more open permission than its parent. For example, you **can't** have `Public` games owned setting while having `Private` profile setting.

### Örnek

If you want to set **all** privacy settings of your bot named `Main` to `Private`, you can use either of below:

```text
privacy Main 1
privacy Main Private
```

This is because ASF will automatically assume all other settings to be `Private`, so there is no need to input them. On the other hand, if you'd like to set all privacy settings to `Public`, then you should use any of below:

```text
privacy Main 3,3,3,3,3,3,3
privacy Main Public,Public,Public,Public,Public,Public,Public
```

This way you can also set independent options however you like:

```text
privacy Main Public,FriendsOnly,Private,Public,Public,Private,Public
```

The above will set profile to public, owned games to friends only, playtime to private, friends list to public, inventory to public, inventory gifts to private and profile comments to public. You can achieve the same with numeric values if you want to.

---

## `addlicense` licenses

`addlicense` command supports two different license types, those are:

| Tip   | Alias | Örnek        | Açıklama                                                                |
| ----- | ----- | ------------ | ----------------------------------------------------------------------- |
| `app` | `a`   | `app/292030` | Game determined by its unique `appID`.                                  |
| `sub` | `s`   | `sub/47807`  | Package containing one or more games, determined by its unique `subID`. |

The distinction is important, as ASF will use Steam network activation for apps, and Steam store activation for packages. Those two are not compatible with each other, typically you'll use apps for free weekends and permanently F2P games, and packages otherwise.

We recommend to explicitly define the type of each entry in order to avoid ambiguous results, but for the backwards compatibility, if you supply invalid type or omit it entirely, ASF will assume that you ask for `sub` in this case. You can also query one or more of the licenses at the same time, using standard ASF `,` delimiter.

Complete command example:

```text
addlicense ASF app/292030,sub/47807
```

---

## `owns` games

`owns` command supports several different game types for `<games>` argument that can be used, those are:

| Tip     | Alias | Örnek            | Açıklama                                                                                                                                                                                                                                                                |
| ------- | ----- | ---------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `app`   | `a`   | `app/292030`     | Game determined by its unique `appID`.                                                                                                                                                                                                                                  |
| `sub`   | `s`   | `sub/47807`      | Package containing one or more games, determined by its unique `subID`.                                                                                                                                                                                                 |
| `regex` | `r`   | `regex/^\d{4}:` | **[Regex](https://en.wikipedia.org/wiki/Regular_expression)** applying to the game's name, case-sensitive. See the **[docs](https://docs.microsoft.com/dotnet/standard/base-types/regular-expression-language-quick-reference)** for complete syntax and more examples. |
| `name`  | `n`   | `name/Witcher`   | Part of the game's name, case-insensitive.                                                                                                                                                                                                                              |

We recommend to explicitly define the type of each entry in order to avoid ambiguous results, but for the backwards compatibility, if you supply invalid type or omit it entirely, ASF will assume that you ask for `app` if your input is a number, and `name` otherwise. You can also query one or more of the games at the same time, using standard ASF `,` delimiter.

Complete command example:

```text
owns ASF app/292030,name/Witcher
```

---

## `redeem^` modes

`redeem^` command allows you to fine-tune modes that will be used for one single redeem scenario. This works as temporary override of `RedeemingPreferences` **[bot config property](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#bot-config)**.

`<Modes>` argument accepts multiple mode values, separated as usual by a comma. Available mode values are specified below:

| Değer | İsim                  | Açıklama                                                                        |
| ----- | --------------------- | ------------------------------------------------------------------------------- |
| FAWK  | ForceAssumeWalletKey  | Forces `AssumeWalletKeyOnBadActivationCode` redeeming preference to be enabled  |
| FD    | ForceDistributing     | Forces `Distributing` redeeming preference to be enabled                        |
| FF    | ForceForwarding       | Forces `Forwarding` redeeming preference to be enabled                          |
| FKMG  | ForceKeepMissingGames | Forces `KeepMissingGames` redeeming preference to be enabled                    |
| SAWK  | SkipAssumeWalletKey   | Forces `AssumeWalletKeyOnBadActivationCode` redeeming preference to be disabled |
| SD    | SkipDistributing      | Forces `Distributing` redeeming preference to be disabled                       |
| SF    | SkipForwarding        | Forces `Forwarding` redeeming preference to be disabled                         |
| SI    | SkipInitial           | Skips key redemption on initial bot                                             |
| SKMG  | SkipKeepMissingGames  | Forces `KeepMissingGames` redeeming preference to be disabled                   |
| V     | Validate              | Validates keys for proper format and automatically skips invalid ones           |

For example, we'd like to redeem 3 keys on any of our bots that don't own games yet, but not our `primary` bot. For achieving that we can use:

`redeem^ primary FF,SI key1,key2,key3`

It's important to note that advanced redeem overrides only those `RedeemingPreferences` that you **specify in the command**. For example, if you've enabled `Distributing` in your `RedeemingPreferences` then there will be no difference whether you use `FD` mode or not, because distributing will be already active regardless, due to `RedeemingPreferences` that you use. This is why each forcibly enabled override also has a forcibly disabled one, you can decide yourself if you prefer to override disabled with enabled, or vice versa.

---

## `encrypt` command

`encrypt` command allows you to encrypt arbitrary strings using ASF's encryption methods. `<encryptionMethod>` must be one of the encryption methods specified and explained in **[security](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security)** section. We recommend to use this command through secure channels (ASF console or IPC interface, which also has a dedicated API endpoint for it), as otherwise sensitive details might get logged by various third-parties (such as chat messages being logged by Steam servers).

---

## `hash` command

`hash` command allows you to generate hashes of arbitrary strings using ASF's hashing methods. `<hashingMethod>` must be one of the hashing methods specified and explained in **[security](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security)** section. We recommend to use this command through secure channels (ASF console or IPC interface, which also has a dedicated API endpoint for it), as otherwise sensitive details might get logged by various third-parties (such as chat messages being logged by Steam servers).

---

## `Giriş` komutları

`input` command can be used only in `Headless` mode, for inputting given data via **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)** or Steam chat when ASF is running without support for user interaction.

General syntax is `input [Bots] <Type> <Value>`.

`<Type>` is case-insensitive and defines input type recognized by ASF. Currently ASF recognizes following types:

| Tip                     | Açıklama                                                                   |
| ----------------------- | -------------------------------------------------------------------------- |
| Login                   | `SteamLogin` bot config property, if missing from config.                  |
| Parola                  | `SteamPassword` bot config property, if missing from config.               |
| SteamGuard              | Auth code sent on your e-mail if you're not using 2FA.                     |
| SteamParentalCode       | `SteamParentalCode` bot config property, if missing from config.           |
| TwoFactorAuthentication | 2FA token generated from your mobile, if you're using 2FA but not ASF 2FA. |
| DeviceConfirmation      | Determines whether confirmation popup for login was accepted               |

`<Value>` is value set for given type. Currently all values are strings.

### Örnek

Let's say that we have a bot that is protected by SteamGuard in non-2FA mode. We want to launch that bot with `Headless` set to `true`.

In order to do that, we need to execute following commands:

`start MySteamGuardBot` -> Bot will attempt to log in, fail due to AuthCode needed, then stop due to running in `Headless` mode. We need this in order to make Steam network send us auth code on our e-mail - if there was no need for that, we'd skip this step entirely.

`input MySteamGuardBot SteamGuard ABCDE` -> We set `SteamGuard` input of `MySteamGuardBot` bot to `ABCDE`. Of course, `ABCDE` in this case is auth code that we got on our e-mail.

`start MySteamGuardBot` -> We start our (stopped) bot again, this time it automatically uses auth code that we set in previous command, properly logging in, then clearing it.

In the same way we can access 2FA-protected bots (if they're not using ASF 2FA), as well as setting other required properties during runtime.