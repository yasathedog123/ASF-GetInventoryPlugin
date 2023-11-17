# Commandes

ASF prend en charge diverses commandes pouvant être utilisées pour contrôler le comportement du processus et des instances de bot.

Les commandes ci-dessous peuvent être envoyées au bot de plusieurs manières différentes :
- Via la console ASF interactive
- Via le chat Steam (privé/groupe)
- Via notre interface **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)**

N'oubliez pas que l'interaction ASF nécessite que vous soyez éligible pour la commande conformément aux autorisations ASF. Consultez les propriétés de configuration `SteamUserPermissions` et `SteamOwnerID` pour plus de détails.

Toutes les commandes ci-dessous sont affectées par `CommandPrefix` **[propriété de configuration globale](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#commandprefix)**, qui est `!` par défaut. Cela signifie que pour exécuter par exemple `status`, vous devez écrire `!Status` (ou un ` préfixe de commande personnalisé` de votre choix que vous avez défini à la place). `CommandPrefix` n'est pas obligatoire lorsque vous utilisez la console ou l'IPC, et peut être omis.

---

### Console interactive

Starting with V4.0.0.9, ASF has support for interactive console, as long as you're not running ASF in [**`Headless`**](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#headless) mode. Simply press `c` button in order to enable command mode, type your command and confirm with enter.

![Capture d"écran](https://i.imgur.com/bH5Gtjq.png)

---

### Steam chat

Vous pouvez aussi faire exécuter la commande par le bot ASF via le chat Steam. Évidemment, vous ne pouvez pas vous parler directement, donc vous aurez besoin d'au moins un autre compte bot si vous voulez exécuter des commandes ciblant votre compte principal.

![Capture d"écran](https://i.imgur.com/IvFRJ5S.png)

De même, vous pouvez également utiliser le chat de groupe d'un groupe Steam. N'oubliez pas que cette option nécessite de définir correctement la propriété `SteamMasterClanID`, auquel cas le bot écoutera les commandes également sur le chat du groupe (et le rejoindra si nécessaire). Cela peut également être utilisé pour "parler à vous-même" puisqu'il ne nécessite pas de compte bot dédié, contrairement au chat privé. Vous pouvez associer `SteamMasterClanID` à un groupe nouvellement créé, puis vous donner vous-même l'accès soit par `SteamOwnerID` ou par ` SteamUserPermissions ` de votre propre bot. De cette façon, ASF bot (vous) rejoindra le groupe et le chat de votre groupe sélectionné, et écoutera les commandes de votre propre compte. Vous pouvez rejoindre le même groupe de discussion afin de vous envoyer des commandes (car vous enverrez des commandes à la salle de discussion, et l'instance ASF siégeant dans la même salle de discussion les recevra, même si cela ne s'affiche que lorsque votre compte est présent).

Veuillez noter que l'envoi d'une commande au chat de groupe agit comme un relais. Notez que l'envoi d'une commande à la discussion de groupe agit comme un relais: si vous dites `redeem X` à 3 de vos robots assis avec vous sur la discussion de groupe, le résultat sera le même. comme vous le dites `redeem X` à chacun d’entre eux en privé. Dans la plupart des cas, ** ce n’est pas ce que vous souhaitez**. Vous devez plutôt utiliser` la commande de bot donnée` qui est envoyée à ** un seul bot dans une fenêtre privée**. . ASF prend en charge les discussions de groupe, car dans de nombreux cas, cela peut être une source de communication utile avec un unique bot, mais vous ne devriez presque jamais exécuter d’aucune commande sur la discussion de groupe s’il y a au moins 2 robots ASF assis, sauf si vous comprenez parfaitement le comportement d’ASF écrit ici. et vous voulez en fait relayer la même commande à tous les robots qui vous écoutent.

*Et même dans ce cas, vous devriez plutôt utiliser le chat privé avec la syntaxe `[Bots]`.*

---

### IPC

La manière la plus avancée et la plus souple d’exécution de commandes, idéale pour les interactions utilisateur (ASF-ui) ainsi que pour les outils tiers ou les scripts (API ASF), requiert que ASF soit exécuté en mode ` IPC `. une commande d'exécution client via l'interface **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)**.

![Capture d"écran](https://raw.githubusercontent.com/JustArchiNET/ASF-ui/main/.github/previews/commands.png)

---

## Commandes

| Commande                                                             | Accès             | Description                                                                                                                                                                                                                                                                                                                                               |
| -------------------------------------------------------------------- | ----------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `2fa [Bots]`                                                         | `Maître`          | Génère un jeton temporaire **[2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)** pour des instances de bot donnés.                                                                                                                                                                                                     |
| `2fafinalize [Bots] <ActivationCode>`                          | `Maître`          | Finalizes process of assigning new **[2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication#creation)** credentials for given bot instances, using SMS activation code.                                                                                                                                                      |
| `2fafinalized [Bots] <ActivationCode>`                         | `Maître`          | Imports already-finalized **[2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication#creation)** credentials for given bot instances, using 2FA token for verification.                                                                                                                                                        |
| `2fafinalizedforce [Bots]`                                           | `Maître`          | Imports already-finalized **[2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication#creation)** credentials for given bot instances, skipping 2FA token verification.                                                                                                                                                         |
| `2fainit [Bots]`                                                     | `Maître`          | Starts process of assigning new **[2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication#creation)** credentials for given bot instances.                                                                                                                                                                                    |
| `2fano [Bots]`                                                       | `Maître`          | Refuse toutes les confirmations en attente **[2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)** pour des instances de bot donnés.                                                                                                                                                                                     |
| `2faok [Bots]`                                                       | `Maître`          | Accepte toutes les confirmations en attente **[2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)** pour des instances de bot donnés.                                                                                                                                                                                    |
| `addlicense [Bots] <Licenses>`                                 | `Opérateur`       | Active les `licenses` données, expliqué **[ci-dessous](#addlicense-licenses)**, sur les instances de robots indiqués (les jeux gratuits uniquement).                                                                                                                                                                                                      |
| `balance [Bots]`                                                     | `Maître`          | Affiche le portefeuille Steam des instances choisies.                                                                                                                                                                                                                                                                                                     |
| `bgr [Bots]`                                                         | `Maître`          | Imprime les informations sur **[BGR](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer)** file d'attente des instances de bot données.                                                                                                                                                                                        |
| `encrypt <encryptionMethod> <stringToEncrypt>`           | `Propriétaire`    | Encrypts the string using provided cryptographic method - further explained **[below](#encrypt-command)**.                                                                                                                                                                                                                                                |
| `exit`                                                               | `Propriétaire`    | Arrête tout le processus ASF.                                                                                                                                                                                                                                                                                                                             |
| `farm [Bots]`                                                        | `Maître`          | Redémarre le module farm de cartes pour des instances de bot données.                                                                                                                                                                                                                                                                                     |
| `fb [Bots]`                                                          | `Maître`          | Lists apps blacklisted from automatic farming of given bot instances.                                                                                                                                                                                                                                                                                     |
| `fbadd [Bots] <AppIDs>`                                        | `Maître`          | Adds given `appIDs` to apps blacklisted from automatic farming of given bot instances.                                                                                                                                                                                                                                                                    |
| `fbrm [Bots] <AppIDs>`                                         | `Maître`          | Removes given `appIDs` from apps blacklisted from automatic farming of given bot instances.                                                                                                                                                                                                                                                               |
| `fq [Bots]`                                                          | `Maître`          | Lists priority farming queue of given bot instances.                                                                                                                                                                                                                                                                                                      |
| `fqadd [Bots] <AppIDs>`                                        | `Maître`          | Adds given `appIDs` to priority farming queue of given bot instances.                                                                                                                                                                                                                                                                                     |
| `fqrm [Bots] <AppIDs>`                                         | `Maître`          | Removes given `appIDs` from farming queue of given bot instances.                                                                                                                                                                                                                                                                                         |
| `hash <hashingMethod> <stringToHash>`                    | `Propriétaire`    | Generated a hash of the string using provided cryptographic method - further explained **[below](#hash-command)**.                                                                                                                                                                                                                                        |
| `help`                                                               | `PartageFamilial` | Affiche l'aide (lien vers cette page).                                                                                                                                                                                                                                                                                                                    |
| `input [Bots] <Type> <Value>`                            | `Maître`          | Définit le type d'entrée donné sur la valeur donnée pour des instances de bot données, fonctionne uniquement en mode `Headless` - pour plus d'explications **[ci-dessous](#input-command)**.                                                                                                                                                              |
| `level [Bots]`                                                       | `Maître`          | Affiche le niveau de compte Steam des instances de bot données.                                                                                                                                                                                                                                                                                           |
| `loot [Bots]`                                                        | `Maître`          | Envoie tous les ` LootableTypes` éléments de communauté Steam d'instances de bot données à l'utilisateur `Maître` défini dans leur ` SteamUserPermissions` (avec le plus bas steamID, s'il y en a plusieurs).                                                                                                                                             |
| `loot@ [Bots] <AppIDs>`                                        | `Maître`          | Sends all `LootableTypes` Steam community items matching given `AppIDs` of given bot instances to `Master` user defined in their `SteamUserPermissions` (with lowest steamID if more than one). This is the opposite of `loot%`.                                                                                                                          |
| `loot% [Bots] <AppIDs>`                                        | `Maître`          | Sends all `LootableTypes` Steam community items apart from given `AppIDs` of given bot instances to `Master` user defined in their `SteamUserPermissions` (with lowest steamID if more than one). This is the opposite of `loot@`.                                                                                                                        |
| `loot^ [Bots] <AppID> <ContextID>`                       | `Maître`          | Envoie tous les éléments Steam de ` AppID` donné dans ` ContextID` des instances de bot données à l'utilisateur ` Maître` défini dans leur ` SteamUserPermissions` (avec steamID le plus bas s'il y en a plus d'un).                                                                                                                                      |
| `mab [Bots]`                                                         | `Maître`          | Lists apps blacklisted from automatic trading in **[`MatchActively`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#matchactively)**.                                                                                                                                                                                             |
| `mabadd [Bots] <AppIDs>`                                       | `Maître`          | Adds given `appIDs` to apps blacklisted from automatic trading in **[`MatchActively`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#matchactively)**.                                                                                                                                                                            |
| `mabrm [Bots] <AppIDs>`                                        | `Maître`          | Removes given `appIDs` from apps blacklisted from automatic trading in **[`MatchActively`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#matchactively)**.                                                                                                                                                                       |
| `match [Bots]`                                                       | `Maître`          | Special command for **[`ItemsMatcherPlugin`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#matchactively)** which triggers `MatchActively` routine immediately.                                                                                                                                                                  |
| `nickname [Bots] <Nickname>`                                   | `Maître`          | Remplace le surnom Steam d’instances de bot données par `nickname`.                                                                                                                                                                                                                                                                                       |
| `owns [Bots] <Games>`                                          | `Opérateur`       | Vérifie si les instances de robots indiqués possède déjà les `jeux` donnés, expliqué **[ci-dessous](#owns-games)**.                                                                                                                                                                                                                                       |
| `pause [Bots]`                                                       | `Opérateur`       | Met définitivement en pause le module de gestion automatique de cartes de certaines instances de bot. ASF ne tentera pas de mettre à jour le compte courant dans cette session, sauf si vous `resume` manuellement ou si vous redémarrez le processus.                                                                                                    |
| `pause~ [Bots]`                                                      | `PartageFamilial` | Suspend temporairement le module de gestion automatique de cartes de certaines instances de bot. Le farming sera automatiquement reprise au prochain événement en cours de lecture ou à la déconnexion du bot. Vous pouvez `reprendre</ 0> le farming pour le suspendre.</td>
</tr>
<tr>
  <td><code>pause& [Bots] <Seconds>` | `Opérateur` | Passe temporairement en pause le module de gestion automatique des cartes des instances de bot  pour une de ` secondes </ 0> indiquée. Après un délai, le module de farming des cartes est automatiquement repris.</td>
</tr>
<tr>
  <td><code>play [Bots] <AppIDs,GameName>` | `Maître` | Bsculement vers le farming manuell - lancez `AppIDs`  sur des instances de bot, éventuellement avec ` GameName </ 0> de façcon personnalisé. In order for this feature to work properly, your Steam account <strong x-id="1">must</strong> own a valid license to all the <code>AppIDs` that you specify here, this includes F2P games as well. Utilisez `reset` ou `resume` pour retourner. |
| `points [Bots]`                                                      | `Maître`          | Displays number of points in **[Steam points shop](https://store.steampowered.com/points/shop)**.                                                                                                                                                                                                                                                         |
| `privacy [Bots] <Settings>`                                    | `Maître`          | Remplace **[Steam privacy settings](https://steamcommunity.com/my/edit/settings)** d’instances de bot données par des options correctement sélectionnées, expliquées **[ci-dessous](#privacy-settings)**.                                                                                                                                                 |
| `redeem [Bots] <Keys>`                                         | `Opérateur`       | Réclame les clés cd ou les codes de portefeuille Steam dans les instances de bots données.                                                                                                                                                                                                                                                                |
| `redeem^ [Bots] <Modes> <Keys>`                          | `Opérateur`       | Utilise des clés cd ou des codes de portefeuille Steam sur des instances de bots données, en utilisant les `modes` expliqué **[ci-dessous](#redeem-modes)**.                                                                                                                                                                                              |
| `reset [Bots]`                                                       | `Maître`          | Resets the playing status back to original (previous) state, the command is used during manual farming with `play` command.                                                                                                                                                                                                                               |
| `restart`                                                            | `Propriétaire`    | Redémarre le processus ASF.                                                                                                                                                                                                                                                                                                                               |
| `resume [Bots]`                                                      | `PartageFamilial` | Reprend le farm automatique d'instances de bot données.                                                                                                                                                                                                                                                                                                   |
| `start [Bots]`                                                       | `Maître`          | Démarre les instances de bot données.                                                                                                                                                                                                                                                                                                                     |
| `stats`                                                              | `Propriétaire`    | Indique les statistiques de processus, telles que l'utilisation de la mémoire utilisée                                                                                                                                                                                                                                                                    |
| `status [Bots]`                                                      | `PartageFamilial` | Imprime le statut d'instances de bot données.                                                                                                                                                                                                                                                                                                             |
| `std`                                                                | `Propriétaire`    | Special command for **[`SteamTokenDumperPlugin`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/SteamTokenDumperPlugin)** which triggers submission of data immediately.                                                                                                                                                                             |
| `stop [Bots]`                                                        | `Maître`          | Arrête les instances de bot données.                                                                                                                                                                                                                                                                                                                      |
| `tb [Bots]`                                                          | `Maître`          | Liste les utilisateurs en liste noire du module de négociation d'instances de bot données.                                                                                                                                                                                                                                                                |
| `tbadd [Bots] <SteamIDs64>`                                    | `Maître`          | La liste noire de `steamIDs` à partir du module de négociation d'instances de bot données.                                                                                                                                                                                                                                                                |
| `tbrm [Bots] <SteamIDs64>`                                     | `Maître`          | Supprimer de la liste noire des` steamIDs ` donnés au module de négociation des instances de bot données.                                                                                                                                                                                                                                                 |
| `transfer [Bots] <TargetBot>`                                  | `Maître`          | Sends all `TransferableTypes` Steam community items from given bot instances to target bot instance.                                                                                                                                                                                                                                                      |
| `transfer@ [Bots] <AppIDs> <TargetBot>`                  | `Maître`          | Sends all `TransferableTypes` Steam community items matching given `AppIDs` from given bot instances to target bot instance. This is the opposite of `transfer%`.                                                                                                                                                                                         |
| `transfer% [Bots] <AppIDs> <TargetBot>`                  | `Maître`          | Sends all `TransferableTypes` Steam community items apart from given `AppIDs` from given bot instances to target bot instance. This is the opposite of `transfer@`.                                                                                                                                                                                       |
| `transfer^ [Bots] <AppID> <ContextID> <TargetBot>` | `Maître`          | Sends all Steam items from given `AppID` in `ContextID` of given bot instances to target bot instance.                                                                                                                                                                                                                                                    |
| `unpack [Bots]`                                                      | `Maître`          | Déballé tous les boosters packs stockés dans l'inventaire d'instances de bot données.                                                                                                                                                                                                                                                                     |
| `update [Channel]`                                                   | `Propriétaire`    | Checks GitHub for new ASF release and updates to it if available. This is normally done automatically every `UpdatePeriod`. Optional `Channel` argument specifies the `UpdateChannel`, if not provided defaults to the one set in global config.                                                                                                          |
| `version`                                                            | `PartageFamilial` | Imprimer la version d'ASF.                                                                                                                                                                                                                                                                                                                                |

---

### Remarques

Toutes les commandes sont sensibles à la case, mais leurs arguments (tels que les noms de bot) sont généralement sensibles à la case.

Arguments follow UNIX philosophy, square brackets `[Optional]` indicate that given argument is optional, while angle brackets `<Mandatory>` indicate that given argument is mandatory. You should replace the arguments that you want to declare, such as `[Bots]` or `<Nickname>` with actual values that you want to issue the command with, omitting the braces.

`[Bots]` argument, as indicated by the brackets, is optional in all commands. Lorsque spécifié, la commande est exécutée sur des bots. Lorsqu'elle est omise, la commande est exécutée sur le bot actuel qui reçoit la commande. En d'autres termes, ` statut A ` envoyé au bot ` B ` correspond à l'envoi de ` statut ` au bot ` A `, le bot ` B ` agit ici comme un proxy. This can also be used for sending commands to bots that are unavailable otherwise, for example starting stopped bots, or executing actions on your main account (that you're using for executing the commands).

**Access** de la commande définit ** minimum** ` EPermission` sur `SteamUserPermissions` requis pour utiliser la commande, à l'exception de `Owner` qui est `SteamOwnerID` défini dans le fichier de configuration global (et la permission la plus élevée disponible).

Plural arguments, such as `[Bots]`, `<Keys>` or `<AppIDs>` mean that command supports multiple arguments of given type, separated by a comma. For example, `status [Bots]` can be used as `status MyBot,MyOtherBot,Primary`. Ainsi, la commande donnée sera exécutée sur ** tous les bots cibles </ 0> de la même manière que si vous envoyiez ` status </ 1> à chaque bot dans une fenêtre de discussion distincte. Veuillez noter qu'il n'y a pas d'espace après <code>, </ 0>.</p>

<p spaces-before="0">ASF utilise tous les caractères de ponctuation comme délimiteurs possibles pour une commande, tels que les caractères de ponctuation et de nouvelle ligne. Cela signifie que vous ne devez pas utiliser d'espace pour délimiter vos arguments, vous pouvez également utiliser n'importe quel autre caractère de ponctuation (tel que tabulation ou nouvelle ligne).</p>

<p spaces-before="0">ASF "joindra" des arguments supplémentaires hors de la plage au type pluriel du dernier argument de la gamme. This means that <code>redeem bot key1 key2 key3` for `redeem [Bots] <Keys>` will work exactly the same as `redeem bot key1,key2,key3`. En même temps que l’acceptation de newline en tant que délimiteur de commande, cela vous permet d’écrire `redeem bot`, puis de coller une liste de clés séparées par tout caractère séparateur acceptable (tel que newline) ou standard `,` délimiteur ASF. Keep in mind that this trick can be used only for command variant that uses the most amount of arguments (so specifying `[Bots]` is mandatory in this case).</p>

Comme vous l'avez lu plus haut, un caractère d'espacement est utilisé comme délimiteur pour une commande. Par conséquent, il ne peut pas être utilisé dans les arguments. Toutefois, comme indiqué ci-dessus, ASF peut également joindre des arguments hors de portée, ce qui signifie que vous pouvez réellement utiliser un caractère d'espacement dans un argument défini comme dernier pour une commande donnée. Par exemple, `nickname bob Great Bob` définit correctement le surnom de ` bob` à "Great Bob". De la même manière, vous pouvez vérifier les noms contenant des espaces dans `owns`.

---

Some commands are also available with their aliases, mostly to save you on typing or account for different dialects:

| Commande     | Alias        |
| ------------ | ------------ |
| `addlicense` | `addlicence` |
| `owns ASF`   | `oa`         |
| `status ASF` | `sa`         |
| `redeem`     | `r`          |
| `redeem^`    | `r^`         |

---

### `[Bots]` argument

`[Bots]` argument is a special variant of plural argument, as in addition to accepting multiple values it also offers extra functionality.

Tout d’abord, il y a le mot-clé `ASF` spécial qui sert pour « tous les bots dans le processus », donc la commande `status ASF` est égal à `État de tous vos bots répertoriés ici`. Cela peut également être utilisé pour identifier facilement les bots auxquels vous avez accès. En tant que mot clé ` ASF `, malgré le ciblage de tous les bots, seuls les bots auxquels vous pouvez envoyer la commande ne répondent.

`[Bots]` argument supports special "range" syntax, which allows you to choose a range of bots more easily. The general syntax for `[Bots]` in this case is `[FirstBot]..[LastBot]`. At least one of the arguments must be defined. When using `<FirstBot>..`, all bots starting from `FirstBot` are affected. When using `..<LastBot>`, all bots until `LastBot` are affected. When using `<FirstBot>..<LastBot>`, all bots within range from `FirstBot` until `LastBot` are affected. Par exemple, si vous avez des robots nommés ` A, B, C, D, E, F `, vous pouvez exécuter ` le statut B..E`, ce qui correspond à `. statut B, C, D, E ` dans ce cas. En utilisant cette syntaxe, ASF utilisera un tri alphabétique afin de déterminer les bots qui se trouvent dans la plage spécifiée. Arguments must be valid bot names recognized by ASF, otherwise range syntax is entirely skipped.

In addition to range syntax above, `[Bots]` argument also supports **[regex](https://en.wikipedia.org/wiki/Regular_expression)** matching. Vous pouvez activer le motif de regex en utilisant `r!<Pattern>` comme nom de bot, où `r!` est un activateur ASF pour la correspondance de regex et `<Pattern>` votre motif de regex. An example of a regex-based bot command would be `status r!^\d{3}` which will send `status` command to bots that have a name made out of 3 digits (e.g. `123` and `981`). N’hésitez pas à jeter un oeil à la **[documentation](https://docs.microsoft.com/dotnet/standard/base-types/regular-expression-language-quick-reference)** pour plus d’explications et plus d’exemples de modèles regex disponibles.

---

## ` Paramètres de confidentialité </ 0></h2>

<p spaces-before="0"><code><Settings>`argument accepté **jusqu'à 7**différentes options, séparées comme d'habitude avec le séparateur ASF standard par virgule. Ce sont, dans l'ordre:</p>

| Argument | Nom            | Verrouillage |
| -------- | -------------- | ------------ |
| 1        | Profile        |              |
| 2        | OwnedGames     | Profile      |
| 3        | Playtime       | OwnedGames   |
| 4        | FriendsList    | Profile      |
| 5        | Inventory      | Profile      |
| 6        | InventoryGifts | Inventory    |
| 7        | Comments       | Profile      |

Pour obtenir une description des champs ci-dessus, veuillez consulter les **[ Paramètres de confidentialité de Steam ](https://steamcommunity.com/my/edit/settings)**.

Tandis que les valeurs valides pour tous sont:

| Valeur  | Nom             |
| ------- | --------------- |
| 1       | `Privé`         |
| 2       | `AmisSeulement` |
| 3       | `Publique`      |

Vous pouvez utiliser un nom ne tenant pas compte de la casse ou une valeur numérique. Les arguments qui ont été omis seront par défaut définis sur ` Privé </ 0>. Il est important de noter la relation entre l'enfant et le parent des arguments spécifiés ci-dessus, car l'enfant ne peut jamais avoir plus de permission ouverte que ses parent. Par exemple, vous <strong x-id="1"> ne pouvez pas </strong> posséder des jeux <code> publics ` avec un profil ` privé `.

### Exemple

Si vous souhaitez définir ** tous ** les paramètres de confidentialité de votre bot nommé ` Principal ` sur ` Privé `, vous pouvez utiliser l'un des éléments ci-dessous:

```text
privacy Main 1
privacy Main Privat
```

En effet, ASF supposera automatiquement que tous les autres paramètres sont ` Privés `. Il n'est donc pas nécessaire de les saisir. Par contre, si vous souhaitez définir tous les paramètres de confidentialité sur ` Public `, vous devez utiliser l'un des éléments ci-dessous:

```text
privacy Main 3,3,3,3,3,3,3
privacy Main Public,Public,Public,Public,Public,Public,Public
```

De cette façon, vous pouvez également définir des options indépendantes comme bon vous semble:

```text
privacy Main Public,FriendsOnly,Private,Public,Public,Private,Public
```

Ce qui précède définira le profil comme public, les jeux appartenant à seulement des amis, le temps de jeu privé, la liste d'amis public, l'inventaire public, les cadeaux d'inventaire privé et les commentaires de profil public. Vous pouvez obtenir la même chose avec des valeurs numériques si vous le souhaitez.

---

## `addlicense` licenses

`addlicense` command supports two different license types, those are:

| Type  | Alias | Exemple      | Description                                                             |
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

| Type    | Alias | Exemple          | Description                                                                                                                                                                                                                                                             |
| ------- | ----- | ---------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `app`   | `a`   | `app/292030`     | Game determined by its unique `appID`.                                                                                                                                                                                                                                  |
| `sub`   | `s`   | `sub/47807`      | Package containing one or more games, determined by its unique `subID`.                                                                                                                                                                                                 |
| `regex` | `r`   | `regex/^\d{4}:` | **[Regex](https://en.wikipedia.org/wiki/Regular_expression)** applying to the game's name, case-sensitive. See the **[docs](https://docs.microsoft.com/dotnet/standard/base-types/regular-expression-language-quick-reference)** for complete syntax and more examples. |
| `nom`   | `n`   | `name/Witcher`   | Part of the game's name, case-insensitive.                                                                                                                                                                                                                              |

We recommend to explicitly define the type of each entry in order to avoid ambiguous results, but for the backwards compatibility, if you supply invalid type or omit it entirely, ASF will assume that you ask for `app` if your input is a number, and `name` otherwise. You can also query one or more of the games at the same time, using standard ASF `,` delimiter.

Complete command example:

```text
owns ASF app/292030,name/Witcher
```

---

## Modes `redeem^`

La commande `redeem^</ 0> vous permet d’affiner les modes qui seront utilisés pour un scénario d’échange unique. Cela fonctionne comme une substitution temporaire de <code> RedeemingPreferences </ 0> <strong x-id="1"><a href="https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#bot-config"> une propriété de configuration du bot </ 1>.</p>

<p spaces-before="0">L'argument <code><Modes>` accepte plusieurs valeurs de mode, séparées comme d'habitude par une virgule. Les valeurs de mode disponibles sont spécifiées ci-dessous:

| Valeur  | Nom                   | Description                                                                             |
| ------- | --------------------- | --------------------------------------------------------------------------------------- |
| FAWK    | ForceAssumeWalletKey  | Forces `AssumeWalletKeyOnBadActivationCode` redeeming preference to be enabled          |
| FD      | ForceDistributing     | Force l'activation de la distribution `Distributing`                                    |
| FF      | ForceForwarding       | Force l'activation du transfert `Forwarding`                                            |
| FKMG    | ForceKeepMissingGames | Force l'activation de `KeepMissingGames`                                                |
| SAWK    | SkipAssumeWalletKey   | Forces `AssumeWalletKeyOnBadActivationCode` redeeming preference to be disabled         |
| SD      | SkipDistributing      | Force la désactivation de la préférence ` Distributing `                                |
| SF      | SkipForwarding        | Force la désactivation de la préférence ` Forwarding`                                   |
| SI      | SkipInitial           | Ignore l'utilisation des clés sur le bot initial                                        |
| SKMG    | SkipKeepMissingGames  | Force le blocage de la préférence `KeepMissingGames`                                    |
| V       | Validate              | Valide les clés pour le format approprié et ignore automatiquement les clés non valides |

Par exemple, nous aimerions échanger 3 clés sur n’importe quel de nos bots ne possédant pas encore de jeux, mais pas sur notre bot ` principal `. Pour y parvenir, nous pouvons utiliser:

`redeem^ primary FF,SI key1,key2,key3`

Il est important de noter que le mode de récupération avancée va passer outre les `RedeemingPreferences` que vous avez **spécifiées dans la commande**. Par exemple, si vous avez activé `Distributing` dans vos `RedeemingPreferences`, il n'y aura pas de différence si vous utilisez le mode `FD` ou non, car le Distributing sera déja activé, du aux `RedeemingPreferences` que vous utilisez. C'est pourquoi chaque fois qu'un paramètre peut être forcé, il y a aussi la possibilité de forcer son arrêt.

---

## `encrypt` command

`encrypt` command allows you to encrypt arbitrary strings using ASF's encryption methods. `<encryptionMethod>` must be one of the encryption methods specified and explained in **[security](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security)** section. We recommend to use this command through secure channels (ASF console or IPC interface, which also has a dedicated API endpoint for it), as otherwise sensitive details might get logged by various third-parties (such as chat messages being logged by Steam servers).

---

## `hash` command

`hash` command allows you to generate hashes of arbitrary strings using ASF's hashing methods. `<hashingMethod>` must be one of the hashing methods specified and explained in **[security](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security)** section. We recommend to use this command through secure channels (ASF console or IPC interface, which also has a dedicated API endpoint for it), as otherwise sensitive details might get logged by various third-parties (such as chat messages being logged by Steam servers).

---

## Commande `input`

`input` command can be used only in `Headless` mode, for inputting given data via **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)** or Steam chat when ASF is running without support for user interaction.

General syntax is `input [Bots] <Type> <Value>`.

`<Type>` est insensible à la casse et définit le type d'entrée reconnu par ASF. Actuellement, ASF reconnaît les types suivants:

| Type                    | Description                                                                                |
| ----------------------- | ------------------------------------------------------------------------------------------ |
| Login                   | `SteamLogin` propriété de config bot, si absente de config.                                |
| Password                | `SteamPassword` propriété de config bot, si absente de config.                             |
| SteamGuard              | Code d'authentification envoyé sur votre courrier électronique si vous n'utilisez pas 2FA. |
| SteamParentalCode       | `SteamParentalCode` propriété de config bot, si absente de config.                         |
| TwoFactorAuthentication | Jeton 2FA généré à partir de votre mobile, si vous utilisez 2FA mais pas ASF 2FA.          |
| DeviceConfirmation      | Determines whether confirmation popup for login was accepted                               |

`<Value>` est la valeur définie pour le type donné. Actuellement, toutes les valeurs sont des chaînes.

### Exemple

Disons que nous avons un bot protégé par SteamGuard en mode non-2FA. We want to launch that bot with `Headless` set to `true`.

Pour ce faire, nous devons exécuter les commandes suivantes:

`start MySteamGuardBot` -> Bot will attempt to log in, fail due to AuthCode needed, then stop due to running in `Headless` mode. Nous en avons besoin pour que le réseau Steam nous envoie le code d'autorisation sur notre adresse électronique. Si cela n'était pas nécessaire, nous ignorerions cette étape.

`input MySteamGuardBot SteamGuard ABCDE` -> We set `SteamGuard` input of `MySteamGuardBot` bot to `ABCDE`. Bien entendu, ` ABCDE </ 0> est dans ce cas le code d'autorisation que nous avons reçu par courrier électronique.</p>

<p spaces-before="0"><code>start MySteamGuardBot` -> We start our (stopped) bot again, this time it automatically uses auth code that we set in previous command, properly logging in, then clearing it.

De la même manière, nous pouvons accéder à des bots protégés par 2FA (s'ils n'utilisent pas ASF 2FA), ainsi que définir d'autres propriétés requises lors de l'exécution.