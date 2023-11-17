# Kommandoer

ASF understøtter forskellige kommandoer, som kan bruges til at kontrollere opførsel af processen og bot-forekomster.

Nedenstående kommandoer kan sendes til botten på forskellige måder:
- Igennem interaktiv ASF-konsol
- Igennem Steam privat/gruppechat
- Igennem vores **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)** interface

Husk, at ASF-interaktion kræver, at du er berettiget til kommandoen i henhold til ASF-tilladelser. Tjek `SteamUserPermissions` og `SteamOwnerID` konfigurationsegenskaber for flere detaljer.

Kommandoer, der udføres via Steam chat, påvirkes af `CommandPrefix` **[global configuration property](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#commandprefix)**, som er `!` som standard. Dette betyder, at til eksekvering af f.eks. `status` kommando, du skal faktisk skrive `!Status` (eller brugerdefineret `CommandoPrefix` efter eget valg, som du indstiller i stedet). `CommandoPrefix` er ikke obligatorisk, når du bruger konsol eller IPC og kan udelades.

---

### Interaktiv konsol

Starting with V4.0.0.9, ASF has support for interactive console, as long as you're not running ASF in [**`Headless`**](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#headless) mode. Simply press `c` button in order to enable command mode, type your command and confirm with enter.

![Screenshot](https://i.imgur.com/bH5Gtjq.png)

---

### Steam chat

You can execute command to given ASF bot also through Steam chat. Obviously you can't talk to yourself directly, therefore you'll need at least one another bot account if you want to execute commands targetting your main.

![Screenshot](https://i.imgur.com/IvFRJ5S.png)

In similar way you can also use group chat of given Steam group. Keep in mind that this option requires properly set `SteamMasterClanID` property, in which case bot will listen for commands also on group's chat (and join it if needed). This can also be used for "talking to yourself" since it doesn't require a dedicated bot account, as opposed to private chat. You can simply set `SteamMasterClanID` property to your newly-created group, then give yourself access either through `SteamOwnerID` or `SteamUserPermissions` of your own bot. This way ASF bot (you) will join group and chat of your selected group, and listen to commands from your own account. You can join the same group chatroom in order to issue commands to yourself (as you'll be sending command to chatroom, and ASF instance sitting on the same chatroom will receive them, even if it shows only as your account being there).

Please note that sending a command to the group chat acts like a relay. If you're saying `redeem X` to 3 of your bots sitting together with you on the group chat, it'll result in the same as you'd say `redeem X` to every single one of them privately. In most cases **this is not what you want**, and instead you should use `given bot` command that is being sent to **a single bot in private window**. ASF supports group chat, as in many cases it can be useful source for communication with your only bot, but you should almost never execute any command on the group chat if there are 2 or more ASF bots sitting there, unless you fully understand ASF behaviour written here and you in fact want to relay the same command to every single bot that is listening to you.

*And even in this case you should use private chat with `[Bots]` syntax instead.*

---

### IPC

The most advanced and flexible way of executing commands, perfect for user interaction (ASF-ui) as well as third-party tools or scripting (ASF API), requires ASF to be run in `IPC` mode, and a client executing command through **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)** interface.

![Screenshot](https://raw.githubusercontent.com/JustArchiNET/ASF-ui/main/.github/previews/commands.png)

---

## Kommandoer

| Kommando                                                             | Adgang          | Beskriveslse                                                                                                                                                                                                                                                                                                                        |
| -------------------------------------------------------------------- | --------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `2fa [Bots]`                                                         | `Master`        | Generates temporary **[2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)** token for given bot instances.                                                                                                                                                                                         |
| `2fafinalize [Bots] <ActivationCode>`                          | `Master`        | Finalizes process of assigning new **[2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication#creation)** credentials for given bot instances, using SMS activation code.                                                                                                                                |
| `2fafinalized [Bots] <ActivationCode>`                         | `Master`        | Imports already-finalized **[2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication#creation)** credentials for given bot instances, using 2FA token for verification.                                                                                                                                  |
| `2fafinalizedforce [Bots]`                                           | `Master`        | Imports already-finalized **[2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication#creation)** credentials for given bot instances, skipping 2FA token verification.                                                                                                                                   |
| `2fainit [Bots]`                                                     | `Master`        | Starts process of assigning new **[2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication#creation)** credentials for given bot instances.                                                                                                                                                              |
| `2fano [Bots]`                                                       | `Master`        | Denies all pending **[2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)** confirmations for given bot instances.                                                                                                                                                                                  |
| `2faok [Bots]`                                                       | `Master`        | Accepts all pending **[2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)** confirmations for given bot instances.                                                                                                                                                                                 |
| `addlicense [Bots] <Licenses>`                                 | `Operator`      | Activates given `licenses`, explained **[below](#addlicense-licenses)**, on given bot instances (free games only).                                                                                                                                                                                                                  |
| `balance [Bots]`                                                     | `Master`        | Shows wallet balance of given bot instances.                                                                                                                                                                                                                                                                                        |
| `bgr [Bots]`                                                         | `Master`        | Prints information about **[BGR](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer)** queue of given bot instances.                                                                                                                                                                                     |
| `encrypt <encryptionMethod> <stringToEncrypt>`           | `Owner`         | Encrypts the string using provided cryptographic method - further explained **[below](#encrypt-command)**.                                                                                                                                                                                                                          |
| `exit`                                                               | `Owner`         | Stops whole ASF process.                                                                                                                                                                                                                                                                                                            |
| `farm [Bots]`                                                        | `Master`        | Restarts cards farming module for given bot instances.                                                                                                                                                                                                                                                                              |
| `fb [Bots]`                                                          | `Master`        | Lists apps blacklisted from automatic farming of given bot instances.                                                                                                                                                                                                                                                               |
| `fbadd [Bots] <AppIDs>`                                        | `Master`        | Adds given `appIDs` to apps blacklisted from automatic farming of given bot instances.                                                                                                                                                                                                                                              |
| `fbrm [Bots] <AppIDs>`                                         | `Master`        | Removes given `appIDs` from apps blacklisted from automatic farming of given bot instances.                                                                                                                                                                                                                                         |
| `fq [Bots]`                                                          | `Master`        | Lists priority farming queue of given bot instances.                                                                                                                                                                                                                                                                                |
| `fqadd [Bots] <AppIDs>`                                        | `Master`        | Adds given `appIDs` to priority farming queue of given bot instances.                                                                                                                                                                                                                                                               |
| `fqrm [Bots] <AppIDs>`                                         | `Master`        | Removes given `appIDs` from farming queue of given bot instances.                                                                                                                                                                                                                                                                   |
| `hash <hashingMethod> <stringToHash>`                    | `Owner`         | Generated a hash of the string using provided cryptographic method - further explained **[below](#hash-command)**.                                                                                                                                                                                                                  |
| `help`                                                               | `FamilySharing` | Shows help (link to this page).                                                                                                                                                                                                                                                                                                     |
| `input [Bots] <Type> <Value>`                            | `Master`        | Sets given input type to given value for given bot instances, works only in `Headless` mode - further explained **[below](#input-command)**.                                                                                                                                                                                        |
| `level [Bots]`                                                       | `Master`        | Shows Steam account level of given bot instances.                                                                                                                                                                                                                                                                                   |
| `loot [Bots]`                                                        | `Master`        | Sends all `LootableTypes` Steam community items of given bot instances to `Master` user defined in their `SteamUserPermissions` (with lowest steamID if more than one).                                                                                                                                                             |
| `loot@ [Bots] <AppIDs>`                                        | `Master`        | Sends all `LootableTypes` Steam community items matching given `AppIDs` of given bot instances to `Master` user defined in their `SteamUserPermissions` (with lowest steamID if more than one). This is the opposite of `loot%`.                                                                                                    |
| `loot% [Bots] <AppIDs>`                                        | `Master`        | Sends all `LootableTypes` Steam community items apart from given `AppIDs` of given bot instances to `Master` user defined in their `SteamUserPermissions` (with lowest steamID if more than one). This is the opposite of `loot@`.                                                                                                  |
| `loot^ [Bots] <AppID> <ContextID>`                       | `Master`        | Sends all Steam items from given `AppID` in `ContextID` of given bot instances to `Master` user defined in their `SteamUserPermissions` (with lowest steamID if more than one).                                                                                                                                                     |
| `mab [Bots]`                                                         | `Master`        | Lists apps blacklisted from automatic trading in **[`MatchActively`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#matchactively)**.                                                                                                                                                                       |
| `mabadd [Bots] <AppIDs>`                                       | `Master`        | Adds given `appIDs` to apps blacklisted from automatic trading in **[`MatchActively`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#matchactively)**.                                                                                                                                                      |
| `mabrm [Bots] <AppIDs>`                                        | `Master`        | Removes given `appIDs` from apps blacklisted from automatic trading in **[`MatchActively`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#matchactively)**.                                                                                                                                                 |
| `match [Bots]`                                                       | `Master`        | Special command for **[`ItemsMatcherPlugin`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#matchactively)** which triggers `MatchActively` routine immediately.                                                                                                                                            |
| `nickname [Bots] <Nickname>`                                   | `Master`        | Changes Steam nickname of given bot instances to given `nickname`.                                                                                                                                                                                                                                                                  |
| `owns [Bots] <Games>`                                          | `Operator`      | Checks if given bot instances already own given `games`, explained **[below](#owns-games)**.                                                                                                                                                                                                                                        |
| `sæt [Bots] på pause`                                                | `Operator`      | Permanently pauses automatic cards farming module of given bot instances. ASF will not attempt to farm current account in this session, unless you manually `resume` it, or restart the process.                                                                                                                                    |
| `pause~ [Bots]`                                                      | `FamilySharing` | Temporarily pauses automatic cards farming module of given bot instances. Farming will be automatically resumed on the next playing event, or bot disconnect. You can `resume` farming to unpause it.                                                                                                                               |
| `pause& [Bots] <Seconds>`                                  | `Operator`      | Temporarily pauses automatic cards farming module of given bot instances for given amount of `seconds`. After delay, cards farming module is automatically resumed.                                                                                                                                                                 |
| `play [Bots] <AppIDs,GameName>`                                | `Master`        | Switches to manual farming - launches given `AppIDs` on given bot instances, optionally also with custom `GameName`. In order for this feature to work properly, your Steam account **must** own a valid license to all the `AppIDs` that you specify here, this includes F2P games as well. Use `reset` or `resume` for returning. |
| `points [Bots]`                                                      | `Master`        | Displays number of points in **[Steam points shop](https://store.steampowered.com/points/shop)**.                                                                                                                                                                                                                                   |
| `privacy [Bots] <Settings>`                                    | `Master`        | Changes **[Steam privacy settings](https://steamcommunity.com/my/edit/settings)** of given bot instances, to appropriately selected options explained **[below](#privacy-settings)**.                                                                                                                                               |
| `redeem [Bots] <Keys>`                                         | `Operator`      | Redeems given cd-keys or wallet codes on given bot instances.                                                                                                                                                                                                                                                                       |
| `redeem^ [Bots] <Modes> <Keys>`                          | `Operator`      | Redeems given cd-keys or wallet codes on given bot instances, using given `modes` explained **[below](#redeem-modes)**.                                                                                                                                                                                                             |
| `reset [Bots]`                                                       | `Master`        | Resets the playing status back to original (previous) state, the command is used during manual farming with `play` command.                                                                                                                                                                                                         |
| `restart`                                                            | `Owner`         | Restarts ASF process.                                                                                                                                                                                                                                                                                                               |
| `forsæt [Bots]`                                                      | `FamilySharing` | Resumes automatic farming of given bot instances.                                                                                                                                                                                                                                                                                   |
| `start [Bots]`                                                       | `Master`        | Starts given bot instances.                                                                                                                                                                                                                                                                                                         |
| `stats`                                                              | `Owner`         | Prints process statistics, such as managed memory usage.                                                                                                                                                                                                                                                                            |
| `status [Bots]`                                                      | `FamilySharing` | Prints status of given bot instances.                                                                                                                                                                                                                                                                                               |
| `std`                                                                | `Owner`         | Special command for **[`SteamTokenDumperPlugin`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/SteamTokenDumperPlugin)** which triggers submission of data immediately.                                                                                                                                                       |
| `stop [Bots]`                                                        | `Master`        | Stops given bot instances.                                                                                                                                                                                                                                                                                                          |
| `tb [Bots]`                                                          | `Master`        | Lists blacklisted users from trading module of given bot instances.                                                                                                                                                                                                                                                                 |
| `tbadd [Bots] <SteamIDs64>`                                    | `Master`        | Blacklists given `steamIDs` from trading module of given bot instances.                                                                                                                                                                                                                                                             |
| `tbrm [Bots] <SteamIDs64>`                                     | `Master`        | Removes blacklist of given `steamIDs` from trading module of given bot instances.                                                                                                                                                                                                                                                   |
| `transfer [Bots] <TargetBot>`                                  | `Master`        | Sends all `TransferableTypes` Steam community items from given bot instances to target bot instance.                                                                                                                                                                                                                                |
| `transfer@ [Bots] <AppIDs> <TargetBot>`                  | `Master`        | Sends all `TransferableTypes` Steam community items matching given `AppIDs` from given bot instances to target bot instance. This is the opposite of `transfer%`.                                                                                                                                                                   |
| `transfer% [Bots] <AppIDs> <TargetBot>`                  | `Master`        | Sends all `TransferableTypes` Steam community items apart from given `AppIDs` from given bot instances to target bot instance. This is the opposite of `transfer@`.                                                                                                                                                                 |
| `transfer^ [Bots] <AppID> <ContextID> <TargetBot>` | `Master`        | Sends all Steam items from given `AppID` in `ContextID` of given bot instances to target bot instance.                                                                                                                                                                                                                              |
| `unpack [Bots]`                                                      | `Master`        | Unpacks all booster packs stored in the inventory of given bot instances.                                                                                                                                                                                                                                                           |
| `update [Channel]`                                                   | `Owner`         | Checks GitHub for new ASF release and updates to it if available. This is normally done automatically every `UpdatePeriod`. Optional `Channel` argument specifies the `UpdateChannel`, if not provided defaults to the one set in global config.                                                                                    |
| `version`                                                            | `FamilySharing` | Prints version of ASF.                                                                                                                                                                                                                                                                                                              |

---

### Notes

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

| Kommando     | Alias        |
| ------------ | ------------ |
| `addlicense` | `addlicence` |
| `owns ASF`   | `oa`         |
| `status ASF` | `sa`         |
| `redeem`     | `r`          |
| `redeem^`    | `r^`         |

---

### `[Bots]` argument

`[Bots]` argument is a special variant of plural argument, as in addition to accepting multiple values it also offers extra functionality.

First and foremost, there is a special `ASF` keyword which acts as "all bots in the process", so `status ASF` command is equal to `status all,your,bots,listed,here`. This can also be used to easily identify the bots that you have access to, as `ASF` keyword, despite of targeting all bots, will result in response only from those bots that you can actually send the command to.

`[Bots]` argument supports special "range" syntax, which allows you to choose a range of bots more easily. The general syntax for `[Bots]` in this case is `[FirstBot]..[LastBot]`. At least one of the arguments must be defined. When using `<FirstBot>..`, all bots starting from `FirstBot` are affected. When using `..<LastBot>`, all bots until `LastBot` are affected. When using `<FirstBot>..<LastBot>`, all bots within range from `FirstBot` until `LastBot` are affected. For example, if you have bots named `A, B, C, D, E, F`, you can execute `status B..E`, which is equal to `status B,C,D,E` in this case. When using this syntax, ASF will use alphabetical sorting in order to determine which bots are in your specified range. Arguments must be valid bot names recognized by ASF, otherwise range syntax is entirely skipped.

In addition to range syntax above, `[Bots]` argument also supports **[regex](https://en.wikipedia.org/wiki/Regular_expression)** matching. You can activate regex pattern by using `r!<Pattern>` as a bot name, where `r!` is ASF activator for regex matching, and `<Pattern>` is your regex pattern. An example of a regex-based bot command would be `status r!^\d{3}` which will send `status` command to bots that have a name made out of 3 digits (e.g. `123` and `981`). Feel free to take a look at the **[docs](https://docs.microsoft.com/dotnet/standard/base-types/regular-expression-language-quick-reference)** for further explanation and more examples of available regex patterns.

---

## `privacy` settings

`<Settings>` argument accepts **up to 7** different options, separated as usual with standard comma ASF delimiter. Those are, in order:

| Argument | Navn           | Child of   |
| -------- | -------------- | ---------- |
| 1        | Profile        |            |
| 2        | OwnedGames     | Profile    |
| 3        | Playtime       | OwnedGames |
| 4        | FriendsList    | Profile    |
| 5        | Inventory      | Profile    |
| 6        | InventoryGifts | Inventory  |
| 7        | Comments       | Profile    |

For description of above fields, please visit **[Steam privacy settings](https://steamcommunity.com/my/edit/settings)**.

While valid values for all of them are:

| Værdi | Navn          |
| ----- | ------------- |
| 1     | `Private`     |
| 2     | `FriendsOnly` |
| 3     | `Public`      |

Du kan enten bruge et bogstavs følsomt navn eller en numerisk værdi. Argumenter, der blev udeladt, indstilles som standard til `Private`. Det er vigtigt at bemærke forholdet mellem child og parent til de argumenter, der er specificeret ovenfor, da child aldrig kan have mere åben tilladelse end parent. For example, you **can't** have `Public` games owned while having `Private` profile.

### Eksempel

Hvis du vil indstille **all** privatlivsindstillinger for din bot med navnet `Main` til `Private`, kan du bruge en af nedenstående:

```text
privacy Main 1
privacy Main Private
```

Dette skyldes, at ASF automatisk antager, at alle andre indstillinger er `Private`, så det er ikke nødvendigt at indtaste dem. På den anden side, hvis du gerne vil indstille alle privatlivsindstillinger til `Public`, skal du bruge en af nedenstående:

```text
privacy Main 3,3,3,3,3,3,3
privacy Main Public,Public,Public,Public,Public,Public,Public
```

På denne måde kan du også indstille uafhængige indstillinger, på lige den måde du vil:

```text
privacy Main Public,FriendsOnly,Private,Public,Public,Private,Public
```

Ovenstående indstiller profil til offentlige, ejede spil kun til venner, spilletid til privat, venneliste til offentlig, inventar til offentlig, inventar gaver til privat og profilkommentarer til offentlig. Du kan opnå det samme med numeriske værdier, hvis du vil.

---

## `addlicense` Licenser

`addlicense` kommandoen supporter to forskellige licens typer, disse er:

| Type          | Alias | Eksempel     | Beskrivelse                                                         |
| ------------- | ----- | ------------ | ------------------------------------------------------------------- |
| `applikation` | `a`   | `app/292030` | Spillet er kendt via sit unikke `appID`.                            |
| `sub`         | `s`   | `sub/47807`  | Pakken indholder et eller flere spil, kendt via sit unikke `subID`. |

Forskellen er vigtig, da ASF vil bruge Steam-netværks aktivering til apps og Steam Store-aktivering til pakker. Disse to er ikke kompatible med hinanden, typisk bruger du apps til gratis weekender og permanent F2P-spil og ellers pakker.

Vi anbefaler at kun definere typen af hver entry for at undgå tvetydige resultater, men for bagudkompatibiliteten, hvis du leverer ugyldig type eller udelader den helt, antager ASF, at du beder om `sub` i dette sag. Du kan også forespørge en eller flere af licenser på samme tid ved hjælp af standard ASF `,` afgrænsning.

Komplet kommandoeksempel:

```text
addlicense ASF app/292030,sub/47807
```

---

## `owns` spil

`owns` kommando understøtter flere forskellige spiltyper til `<games>` argument, der kan bruges, disse er:

| Type          | Alias | Eksempel         | Beskriveslse                                                                                                                                                                                                                                                            |
| ------------- | ----- | ---------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `applikation` | `a`   | `app/292030`     | Spillet er kendt via sit unikke `appID`.                                                                                                                                                                                                                                |
| `sub`         | `s`   | `sub/47807`      | Pakken indholder et eller flere spil, kendt via sit unikke `subID`.                                                                                                                                                                                                     |
| `regex`       | `r`   | `regex/^\d{4}:` | **[Regex](https://en.wikipedia.org/wiki/Regular_expression)** applying to the game's name, case-sensitive. See the **[docs](https://docs.microsoft.com/dotnet/standard/base-types/regular-expression-language-quick-reference)** for complete syntax and more examples. |
| `navn`        | `n`   | `name/Witcher`   | Part of the game's name, case-insensitive.                                                                                                                                                                                                                              |

We recommend to explicitly define the type of each entry in order to avoid ambiguous results, but for the backwards compatibility, if you supply invalid type or omit it entirely, ASF will assume that you ask for `app` if your input is a number, and `name` otherwise. You can also query one or more of the games at the same time, using standard ASF `,` delimiter.

Komplet kommandoeksempel:

```text
owns ASF app/292030,name/Witcher
```

---

## `redeem^` modes

`redeem^` command allows you to fine-tune modes that will be used for one single redeem scenario. This works as temporary override of `RedeemingPreferences` **[bot config property](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#bot-config)**.

`<Modes>` argument accepts multiple mode values, separated as usual by a comma. Available mode values are specified below:

| Værdi | Navn                  | Beskriveslse                                                                    |
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

## `input` command

`input` command can be used only in `Headless` mode, for inputting given data via **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)** or Steam chat when ASF is running without support for user interaction.

General syntax is `input [Bots] <Type> <Value>`.

`<Type>` is case-insensitive and defines input type recognized by ASF. Currently ASF recognizes following types:

| Type                    | Beskriveslse                                                               |
| ----------------------- | -------------------------------------------------------------------------- |
| Login                   | `SteamLogin` bot config property, if missing from config.                  |
| Password                | `SteamPassword` bot config property, if missing from config.               |
| SteamGuard              | Auth code sent on your e-mail if you're not using 2FA.                     |
| SteamParentalCode       | `SteamParentalCode` bot config property, if missing from config.           |
| TwoFactorAuthentication | 2FA token generated from your mobile, if you're using 2FA but not ASF 2FA. |
| DeviceConfirmation      | Determines whether confirmation popup for login was accepted               |

`<Value>` is value set for given type. Currently all values are strings.

### Eksempel

Let's say that we have a bot that is protected by SteamGuard in non-2FA mode. We want to launch that bot with `Headless` set to `true`.

In order to do that, we need to execute following commands:

`start MySteamGuardBot` -> Bot will attempt to log in, fail due to AuthCode needed, then stop due to running in `Headless` mode. We need this in order to make Steam network send us auth code on our e-mail - if there was no need for that, we'd skip this step entirely.

`input MySteamGuardBot SteamGuard ABCDE` -> We set `SteamGuard` input of `MySteamGuardBot` bot to `ABCDE`. Of course, `ABCDE` in this case is auth code that we got on our e-mail.

`start MySteamGuardBot` -> We start our (stopped) bot again, this time it automatically uses auth code that we set in previous command, properly logging in, then clearing it.

In the same way we can access 2FA-protected bots (if they're not using ASF 2FA), as well as setting other required properties during runtime.