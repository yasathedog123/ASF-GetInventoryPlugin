# FAQ (Questions fréquemment posées)

La FAQ basique couvre les questions classiques et y répond. Pour une question plus spécifique, veuillez consulter notre **[FAQ avancée](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Extended-FAQ)** au lieu de celle ci.

# Tables des matières

* [Général](#general)
* [Comparaison avec d’autres outils similaires](#comparison-with-similar-tools)
* [Sécurité / Vie Privée / VAC / Bans / ToS](#security--privacy--vac--bans--tos)
* [Divers](#misc)
* [Problèmes](#issues)

---

## Général

### Qu'est-ce qu'ASF ?
### Pourquoi le programme affirme t-il qu'il n'y a rien à récolter sur mon compte?
### Why ASF doesn't detect all of my games?
### Pourquoi mon compte est-il bloqué ?

Avant d'essayer de comprendre ce qu'est ASF, vous devez vous assurer de bien comprendre ce que sont les cartes Steam et comment les obtenir, ce qui est décrit dans la FAQ officielle **[ici](https://steamcommunity.com/tradingcards/faq)**.

En bref, les cartes Steam sont des objets de collection auxquels vous êtes admissible lorsque vous possédez un jeu en particulier. Vous pouvez les utiliser pour confectionner des badges, vendre sur le marché Steam ou à toute autre chose de votre choix.

Core points are stated once again here, because people in general don't want to agree with them and prefer to pretend that those do not exist:

- **You need to own the game on your Steam account in order to be eligible for any card drops from it. Le partage familial ne compte pas.**
- **You can't farm the game infinitely, every game has fixed number of card drops. Once you drop all of them (around a half of the full set), the game is not a candidate for farming anymore. It doesn't matter whether you've sold, traded, crafted or forgot what happened to those cards you've obtained, once you run out of card drops, the game is finished.**
- **You can't drop cards from F2P games without spending any money in them. This means permanently F2P games like Team Fortress 2 or Dota 2. Owning F2P games does not grant you card drops.**
- **You can't drop cards on [limited accounts](https://help.steampowered.com/faqs/view/71D3-35C2-AD96-AA3A), regardless of owned games. C'était possible dans le passé, mais ce n'est plus le cas.**
- **Paid games that you've obtained for free during a promotion can't be farmed for card drops, regardless of what is displayed on the store page. C'était possible dans le passé, mais ce n'est plus le cas.**

So as you can see, Steam cards are awarded to you for playing a game that you bought, or F2P game that you've put money into. If you play such game long enough, all cards for that game will eventually drop to your inventory, making it possible for you to complete a badge (after obtaining the remaining half of the set), sell them, or do whatever else you want.

Now that we've explained the basics of Steam, we can explain ASF. The program itself is quite complex to understand fully, so instead of digging into all the technical details, we'll offer a very simplified explanation below.

ASF logs into your Steam account through our built-in, custom Steam client implementation using your provided credentials. After successfully logging in, it parses your **[badges](https://steamcommunity.com/my/badges)** in order to find games that are available for farming (`X` card drops remaining). Après avoir analysé toutes les pages et construit la liste finale des jeux disponibles, ASF choisit l'algorithme de farming le plus efficace et lance le processus. The process depends upon chosen **[cards farming algorithm](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)** but usually it consists of playing eligible game and periodically (plus on each item drop) checking if game is fully farmed already - if yes, ASF can proceed with the next title, using the same procedure, until all games are fully farmed.

Gardez à l'esprit que l'explication ci-dessus est simplifiée et ne décrit pas une douzaine de fonctionnalités supplémentaires offertes par ASF. Visitez le reste de **[notre wiki](https://github.com/JustArchiNET/ArchiSteamFarm/wiki)** si vous souhaitez connaître tous les détails de ASF. J'ai essayé de le rendre assez simple à comprendre pour tout le monde, sans apporter de détails techniques - les utilisateurs avancés sont encouragés à aller plus loin.

En tant que programme, ASF offre de la magie. Tout d'abord, il n'est pas nécessaire de télécharger l'un de vos fichiers de jeu, il peut jouer à des jeux immédiatement.    Deuxièmement, il est totalement indépendant de votre client Steam habituel - vous n'avez pas besoin d'avoir le client Steam en cours d'exécution ni même de l'avoir installé.   . Troisièmement, c'est une solution automatisée - ce qui signifie qu'ASF fait automatiquement tout ce qui est derrière votre dos, sans qu'il soit nécessaire de lui dire quoi faire - ce qui vous permet de gagner du temps. Enfin, il n’a pas à tromper le réseau Steam en émulant un processus (utilisé par exemple par Idle Master), car il peut communiquer directement avec lui. Super rapide et léger, il est également une solution étonnante pour tous ceux qui souhaitent obtenir des cartes facilement et sans tracas. Cela s'avère particulièrement utile si vous le laissez en arrière-plan tout en faisant autre chose, ou même en mode hors connexion.

All of the above is nice, but ASF also has some technical limitations that are enforced by Steam - we can't farm games that you don't own, we can't farm games forever in order to get extra drops past the enforced limit, and we can't farm games while you're playing. All of that should be "logical", considering the way how ASF works, but it's nice to note that ASF doesn't have super-powers and won't do something that is physically impossible, so keep that in mind - it's basically the same as if you told someone to log in on your account from another PC and farm those games for you.

Donc, pour résumer, ASF est un programme qui vous aide à retirer les cartes auxquelles vous êtes éligible, sans tracas. Il offre également plusieurs autres fonctions, mais ignorons pour le moment.

---

### Dois-je mettre les informations d'identification de mon compte?

**Oui**. ASF requiert les informations d'identification de votre compte de la même manière que le client officiel Steam, car il utilise la même méthode pour les interactions avec le réseau Steam. Cela ne signifie toutefois pas que vous devez entrer les informations d'identification de votre compte dans les configurations ASF, vous pouvez continuer à utiliser ASF avec `null` /empty `SteamLogin`  et/ou `SteamPassword`, et saisissez ces données sur chaque exécution ASF, si nécessaire (ainsi que plusieurs autres informations d'identification de connexion, reportez-vous à la configuration). De cette manière, vos données ne sont enregistrées nulle part, mais ASF ne peut bien entendu pas démarrer automatiquement sans votre aide. ASF propose également plusieurs autres moyens d’augmenter votre **[sécurité](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security)**, alors n'hésitez pas à lire cette partie du wiki si vous êtes un utilisateur expérimenté. If you're not, and you don't want to put your account credentials in ASF configs, then simply don't do that, and instead input them as-needed when ASF asks for them.

Gardez à l'esprit que l'outil ASF est pour votre usage personnel et que vos informations d'identification ne quittent jamais votre ordinateur. You're also not sharing them with anybody, which fulfills **[Steam ToS](https://store.steampowered.com/subscriber_agreement)** - a very important thing that many people forget about. Vous n'envoyez pas vos coordonnées à nos serveurs ou à des tiers, mais directement aux serveurs Steam de Valve. We don't know your credentials and we're also unable to recover them for you, regardless if you put them in your configs or not.

---

### Combien de temps dois-je attendre que les cartes tombent?

**Autant de temps que necéssaire</ 0> - sérieusement. Chaque développeur a ses propres difficultés de farming définies par les développeurs et les éditeurs, et c’est à eux de décider à quelle vitesse lâcher les cartes. La majorité des jeux donnent une car par phase de 30 minutes de jeu, mais il existe également des jeux qui vous obligent à jouer plusieurs heures avant d'obtenir une carte. In addition to that, your account could be restricted from receiving card drops from games you didn't play for enough time yet, as stated in **[performance](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)** section. N'essayez pas de deviner combien de temps ASF devrait prendre pour farmer un jeu - ce n'est pas à vous, ni à ASF de décider. Il n'y a rien que vous puissiez faire pour accélérer les choses, et il n'y a pas de "bug" lié au fait que les cartes ne sont pas fournis à temps - vous ne contrôlez pas le processus d'obtention des cartes, pas plus que ASF. Dans le meilleur des cas, vous recevrez en moyenne  une carte par phase de 30 minutes. Dans le pire des cas, vous ne recevrez aucune carte, même pendant 4 heures depuis le démarrage d'ASF. Ces deux situations sont normales et sont décrites dans notre section **[Performances](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)**.</p>

---

### Le farming prend trop de temps, puis-je l'accélérer?

La seule chose qui affecte la vitesse du farming est l’option **[Algorithme de farming des cartes](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)** sélectionnée pour votre instance de bot. Tout le reste a un effet négligeable et ne rendra pas le farming plus rapide, alors que certaines actions telles que le lancement du processus ASF à plusieurs reprises vont même **l’aggraver**. Si vous souhaitez réellement exploiter chaque seconde du processus d’agriculture, ASF vous permet d’affiner certaines variables  telles que `FarmingDelay` - elles sont toutes expliquées dans **[configuration](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)**. Cependant, comme je l'ai dit, l'effet est négligeable, et choisir l'algorithme de farming des cartes approprié pour un compte est l'un et le seul choix crucial qui puisse influer fortement sur la vitesse de farming. Tout le reste est purement cosmétique. Au lieu de vous préoccuper de la rapidité de votre exploitation, lancez simplement ASF et laissez-la faire son travail. Je peux vous assurer qu'il le fait de la manière le plus efficace possible. Moins vous vous en souciez, plus vous serez satisfait.

---

### Mais ASF a déclaré que le farming prendrait environ X temps!

ASF vous donne une idée approximative basée sur le nombre de cartes que vous devez obtenir, ainsi que sur l'algorithme choisi. Ce délai est très proche du temps que vous passerez réellement à farmer, ce qui est généralement plus long que cela, ASF ne prenant que le meilleur des cas, ignorant toutes les bizarreries du réseau Steam, les déconnexions Internet, la surcharge des serveurs Steam, etc. Cela devrait être considéré uniquement comme un indicateur général de la durée pendant laquelle vous pouvez vous attendre à ce que ASF farme, très souvent dans le meilleur des cas, car le temps réel diffère, même de manière significative dans certains cas. Comme indiqué ci-dessus, n'essayez pas de deviner combien de temps un jeu sera farmer, ce n'est pas à vous, ni à ASF de décider.

---

### ASF peut-il fonctionner sur mon Android / smartphone?

ASF is a C# program that requires working implementation of .NET. Android became a valid platform starting with .NET 6.0, however, there is currently a major blocker in making ASF happen on Android due to **[lack of ASP.NET runtime available on it](https://github.com/dotnet/aspnetcore/issues/35077)**. Even though there isn't a native option available, there are proper and working builds for GNU/Linux on ARM architecture, so it's totally possible to use something like **[Linux Deploy](https://play.google.com/store/apps/details?id=ru.meefik.linuxdeploy)** for installing Linux, then using ASF in such Linux chroot as usual.

When/If all ASF requirements are satisfied, we'll consider releasing an official Android build.

---

### Can ASF farm items from Steam games, such as CS:GO or Unturned?

**No**, this is against **[Steam ToS](https://store.steampowered.com/subscriber_agreement)** and Valve clearly stated that with last wave of community bans for farming TF2 items. ASF est un programme de farming de cartes Steam, et non un élément de jeu. Il ne dispose d'aucune fonctionnalité pour créer des éléments de jeu. Il n'est pas prévu d'ajouter une telle fonctionnalité à l'avenir, en raison notamment d'une violation des conditions d'utilisation de Steam. S'il vous plaît ne demandez pas à ce sujet - le mieux que vous puissiez obtenir est un rapport d'un utilisateur mauvais et vous aurez des problèmes. The same goes for all other types of farming, such as farming drops from CS:GO broadcasts. ASF se concentre exclusivement sur les cartes à échanger Steam.

---

### Can I choose which games should be farmed?

**Oui**, de différentes manières. If you want to alter the default order of farming queue, then that's what `FarmingOrders` **[bot configuration property](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#bot-config)** can be used for. If you want to manually blacklist given games from being farmed automatically, you can use idle blacklist which is available with `fb` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. If you'd like to farm everything but give some apps priority over everything else, that is what idle priority queue available with `fq` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** can be used for. And finally, if you want to farm specific games of your choice only, then you can use `FarmPriorityQueueOnly` **[bot configuration property](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#bot-config)** in order to achieve this, together with adding your selected apps to idle priority queue.

En plus de la gestion du module de farming automatique des cartes décrit ci-dessus, vous pouvez également basculer ASF en mode de farming manuelle à l’aide de la **[commande](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** `play </ 0> ou utiliser certains autres paramètres externes divers, tels que <code> GamesPlayedWhileIdle` **[dans le fichier de configuration du bot](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#bot-config)**.

---

### I'm not interested in card drops, I'd like to farm hours played instead, is that possible?

Yes, ASF allows you to do that through at least several ways.

The best way to achieve that is to make use of **[`GamesPlayedWhileIdle`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#gamesplayedwhileidle)** configuration property, which will play your chosen appIDs when ASF has no cards to farm. If you'd like to play your games all the time, even if you do have card drops from other games, then you can combine it with **[`FarmPriorityQueueOnly`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#farmpriorityqueueonly)**, so ASF will farm only those games for card drops that you explicitly set, or **[`Paused`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#paused)**, which will cause cards farming module to be paused until you unpause it yourself.

Alternatively, you can make use of the **[`play`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands#commands-1)** command, which will cause ASF to play your selected games. However, keep in mind that `play` should be used only for games you want to play temporarily, as it's not a persistent state, causing ASF to revert back to default state e.g. upon disconnection from Steam network. Therefore, we recommend you to use `GamesPlayedWhileIdle`, unless you indeed want to start your selected games just for a short time period, and then revert back to general flow.

---

### I'm Linux / macOS user, will ASF farm games that are not available for my OS? Will ASF farm 64-bit games when I'm running it on 32-bit OS?

Oui, ASF ne se soucie même pas de télécharger des fichiers de jeu réels. Il fonctionnera donc avec toutes vos licences liées à votre compte Steam, quelles que soient les exigences techniques de la plate-forme. It should also work for games tied to specific region (region-locked games) even when you're not in the matching region, although we don't guarantee that (it worked last time we tried).

---

## Comparaison avec des outils similaires

---

### ASF est-il similaire à Idle Master?

The only similarity is the general purpose of both programs, which is farming Steam games in order to receive card drops. Everything else, including the actual farming method, program structure, functionality, compatibility, used algorithms, especially the source code itself, is entirely different and those two programs have nothing common with each other, even the core foundation - IM is running on .NET Framework, ASF on .NET (Core). ASF a été créé pour résoudre des problèmes de IM qu'il n'était pas possible de résoudre avec une simple modification de code. C’est pourquoi ASF a été écrit à partir de rien, sans utiliser une seule ligne de code ni une idée générale de la part de IM, car ce code et ces idées étaient totalement erronés. pour commencer. IM et ASF sont comme Windows et Linux - les deux sont des systèmes d'exploitation et peuvent être installés sur votre PC, mais ils ne partagent presque rien les uns avec les autres, mis à part le même objectif.

C'est aussi pourquoi vous ne devriez pas comparer ASS à IM en fonction des attentes de IM. Vous devez traiter ASF et IM comme des programmes entièrement indépendants dotés de leurs propres ensembles exclusifs de fonctionnalités. Certaines d’entre elles se chevauchent en fait et vous pouvez trouver une caractéristique particulière dans les deux, mais très rarement, car ASF remplit son objectif avec une approche totalement différente de celle de IM.

---

### Est t-il nécessaire d’utiliser ASF, si j’utilise actuellement Idle Master et que cela fonctionne bien pour moi?

**Oui**. ASF is much more reliable and includes many built-in functions that are **crucial** regardless of the way how you farm, that IM simply doesn't offer.

ASF has proper logic for **unreleased games** - IM will attempt to farm games that have cards added already, even if they weren't released yet. Of course, it's not possible to farm those games until release date, so your farming process will be stuck. Cela nécessitera soit de l'ajouter à la liste noire, d'attendre sa publication ou de l'ignorer manuellement. Neither of those solutions is good, and all of them require your attention - ASF automatically skips farming of unreleased games (temporarily), and returns back to them later when they are, completely avoiding the problem and dealing with it efficiently.

ASF dispose également d’une logique appropriée pour les vidéos de la **série**. There are many videos on Steam that have cards, yet are announced with wrong `appID` on the badges page, such as **[Double Fine Adventure](https://store.steampowered.com/app/402590)** - IM will falsely farm wrong `appID`, which will yield no drops and process being stuck. Encore une fois, vous devrez le mettre sur liste noire ou l'ignorer manuellement, les deux nécessitant votre attention. ASF automatically discovers proper `appID` for farming which does result in card drops.

En outre, ASF est **beaucoup plus stable et fiable** en ce qui concerne les problèmes de réseau et les problèmes liés à Steam. Il fonctionne la plupart du temps et ne nécessite aucune attention de votre part une fois configuré, alors que IM  pour beaucoup de gens, nécessite des corrections supplémentaires ou ne fonctionne tout simplement pas malgré tout. Cela dépend également entièrement de votre client Steam, ce qui signifie que cela ne peut pas fonctionner lorsque votre client Steam rencontre des problèmes graves. ASF fonctionne correctement tant qu'il peut se connecter au réseau Steam et ne nécessite pas l'exécution du client Steam, ni même son installation.

Those are 3 **very important** points why you should consider using ASF, as they directly affect everybody farming Steam cards and there is no way to say "this doesn't consider me", since Steam maintenances and quirks are happening to everybody. There are dozen of extra less and more important reasons which you may learn about in the rest of the FAQ. En bref, **oui**, vous devez utiliser ASF même lorsque vous n’avez besoin d’aucune fonctionnalité ASF supplémentaire par rapport à IM.

In addition to that, IM is officially discontinued and can break completely in the future, without anybody bothering to fix it, considering existence of much more powerful solutions (not only ASF). IM ne fonctionne déjà pas pour beaucoup de gens, et ce nombre ne fait qu'augmenter, pas diminuer. Évitez d’abord d’utiliser des logiciels obsolètes, pas seulement IM, mais également tous les autres programmes obsolètes. No active maintainer means that nobody cares whether it works or not and **nobody is responsible for its functionality**, which is a crucial matter in terms of security. It's enough that there will be a critical bug causing actual problems to Steam infrastructure - with nobody fixing it, Steam can issue another ban wave in which you'll get hit without even being aware of this being an issue, as already happened to people using, guess what, obsolete version of ASF.

---

### Quelles sont les fonctionnalités intéressantes proposées par ASF et que Idle Master n’a pas?

Cela dépend de ce que vous considérez comme "intéressant" pour vous. If you plan to farm more accounts than one then the answer is already obvious since ASF allows you to farm all of them with one superior solution, saving resources, hassle, and compatibility issues. Toutefois, si vous vous posez cette question, il est fort probable que vous ne répondez pas à ce besoin particulier. Évaluons donc les autres avantages applicables à un seul compte utilisé dans ASF.

First and foremost, you have some built-in features mentioned **[above](#is-it-worth-it-to-use-asf-if-im-currently-using-idle-master-and-it-works-fine-for-me)** that are core for farming regardless of your end-goal, and very often that alone is already enough to consider using ASF. Mais vous le savez déjà, passons donc à des fonctionnalités plus intéressantes:

- **You can farm offline** (`OnlineStatus` in `Offline` setting). Farming offline makes it possible for you to skip your Steam in-game status entirely, which allows you to farm with ASF while showing "Online" on Steam at the same time, without your friends even noticing that ASF is playing a game on your behalf. Cette fonctionnalité est supérieure, car elle vous permet de rester en ligne sur votre client Steam, sans gêner vos amis avec des modifications constantes du jeu, ni les induire en erreur en leur faisant croire que vous jouez à un jeu alors qu'en réalité vous ne le faite pas. Ce seul point justifie l'utilisation d'ASF si vous respectez vos propres amis, mais ce n'est qu'un début. Il est également agréable de noter que cette fonctionnalité n'a rien à voir avec les paramètres de confidentialité de Steam. Si vous lancez le jeu vous-même, vous vous présenterez correctement dans le jeu à vos amis, rendant uniquement la partie ASF invisible et n'affectant en rien votre compte. .

- **You can skip refundable games** (`SkipRefundableGames` feature). ASF has proper built-in logic for refundable games and you can configure ASF to not farm refundable games automatically. Cela vous permet d’évaluer vous-même si votre jeu nouvellement acheté dans le magasin Steam valait votre argent, sans qu'ASF ne tente de lui retirer des cartes dès que possible. Si vous y jouez plus de 2 heures ou 2 semaines après votre achat, ASF procédera au farming ce jeu car il ne sera plus remboursable. Jusque-là, vous avez le plein contrôle, que vous en appréciez ou non, et vous pouvez facilement vous le faire rembourser si nécessaire, sans avoir à mettre manuellement ce jeu en liste noire ou à ne pas utiliser ASF pendant toute sa durée.

- **Vous pouvez automatiquement marquer les nouveaux éléments comme étant reçus** (`BotBehaviour` avec la fonctionnalité `DismissInventoryNotifications`). Farming with ASF will result in your account receiving new card drops. Vous savez déjà que cela va se produire. Informez donc ASF de cette notification inutile, en veillant à ce que seules les informations importantes attirent votre attention. Bien sûr, seulement si vous le souhaitez.

- **Vous pouvez recevoir automatiquement des cartes d’événements Steam** (fonctionnalité `AutoSteamSaleEvent`). ASF allows you to automate going through discovery queue during Steam sale, of course only if you'd like to make use of that. Cela économise énormément de temps chaque jour lorsque les soldes Steam sont activée et garantit que vous ne manquerez plus jamais de vos cartes quotidiennes.

- **Vous pouvez personnaliser l’ordre de farming préféré avec d'avantage d’options disponibles** (fonctionnalité `FarmingOrders`). Perhaps you want to farm your newly bought games first? Ou vos plus vieux? Selon le nombre de de cartes? Les niveaux de badge que vous avez déjà créés? Heures jouées? Ordre alphabétique? Selon AppID? Ou peut-être totalement aléatoire? C’est à vous de décider.

- **ASF peut vous aider à compléter vos ensemble** ( `TradingPreferences` avec la fonction `SteamTradeMatcher`). Avec un bricolage un peu plus avancé, vous pouvez convertir votre ASF en un bot utilisateur complet qui acceptera automatiquement les offres **[STM](https://www.steamtradematcher.com)**, vous aidant chaque jour à faire correspondre vos ensembles sans aucune interaction de l'utilisateur. ASF inclut même son propre module ASF 2FA vous permettant d’importer votre authentificateur mobile Steam et de vous permettre d’automatiser entièrement le processus en acceptant également les confirmations. Ou peut-être souhaitez-vous accepter manuellement et laisser ASF uniquement préparer ces transactions pour vous? C’est à vous de décider.

- **ASF peut activer des clés en arrière-plan pour vous** (fonction **[activation de jeux en arrière-plan](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer)**). Peut-être avez-vous une centaine de clés de divers ensembles que vous êtes trop paresseux pour vous racheter, en passant par plusieurs fenêtres et en acceptant les conditions d'utilisation de Steam encore et encore. Pourquoi ne pas copier-coller votre liste de clés dans ASF et le laisser faire son travail? ASF activera automatiquement toutes ces clés en arrière-plan, vous fournissant ainsi le résultat approprié pour vous informer du résultat de chaque tentative d'activation. De plus, si vous avez des centaines de clés, Steam sera tôt ou tard sûr de limiter les taux, et ASF le sait aussi. Il attend patiemment que la limite de taux disparaisse et reprenne sa position d'origine.

Nous pourrions maintenant continuer avec l'ensemble du **[wiki ASF](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Home)**, en soulignant chaque fonctionnalité du programme, mais nous devons tracer une ligne quelque part. Voilà une liste de fonctionnalités dont vous pouvez bénéficier en tant qu'utilisateur d'ASF. Une seule de celles-ci pourrait facilement être considérée comme une raison majeure pour ne jamais  reveniren arrière, et nous en avons même répertorié **beaucoup **, avec encore plus, vous pouvez en apprendre d'avantage sur le reste de notre wiki. Ah yes, and we didn't even go into detail with things like ASF's API allowing you to script your own commands, or awesome bots management, since we wanted to keep it simple.

---

### ASF est-il plus rapide que Idle Master?

**Oui**, bien que l'explication soit plutôt compliquée.

À chaque nouveau processus créé et terminé sur votre système, le client Steam envoie automatiquement une requête contenant tous les jeux auxquels vous êtes en train de jouer. Ainsi, le réseau Steam peut calculer le nombre d'heures et  fournir les cartes. Cependant, le réseau Steam compte votre temps joué par intervalles d'une seconde et l'envoi d'une nouvelle requête afin de réinitialiser le statut actuel. En d'autres termes, si vous créiez / supprimiez un nouveau processus toutes les 0,5 seconde, vous n'aurez jamais de carte, car chaque client Steam de 0,5 seconde envoyait une nouvelle requête et le réseau Steam ne comptera jamais même une seconde de temps de jeu. De plus, en raison du fonctionnement du système d’exploitation, il est assez courant de voir de nouveaux processus en train d’être créés / arrêtés sans même que vous ne fassiez rien. Même si vous ne faites rien sur votre PC, de nombreux processus fonctionnent toujours en arrière-plan, ce qui génère / mettre fin à d’autres processus tout le temps. IM est basé sur le client Steam, donc ce mécanisme vous concerne si vous l'utilisez.

ASF n'est pas basé sur le client Steam, il dispose de sa propre implantation. Grâce à cela, ce que ASF est en train de faire ne génère aucun processus, mais envoie en fait une demande réelle au réseau Steam pour que nous commencions à jouer à un jeu. C'est la même demande qui serait envoyée par le client steam, mais comme nous avons le contrôle effectif du client steam d'ASF, nous n'avons pas besoin de générer de nouveaux processus et nous ne sommes pas en train d'imiter le client steam concernant la demande d'envoi à chaque changement de processus. , donc le mécanisme expliqué ci-dessus ne nous affecte pas. Grâce à cela, nous n'interrompons jamais cet intervalle d'une seconde côté Steam, ce qui améliore notre vitesse de culture.

---

### Mais la différence est-elle vraiment perceptible?

Non. Les interruptions qui se produisent avec le client Steam normal et IM ont un effet négligeable sur les obtentions de carte. Ce n'est donc pas une différence notable qui améliorerait la qualité de ASF.

Cependant, **il y a** une différence, et vous pouvez clairement remarquer que, selon l'affluence de votre système d'exploitation, les cartes **tomberont** plus rapidement, de quelques secondes à quelques secondes. minutes, si vous êtes extrêmement malchanceux. Bien que je n’envisage pas d’utiliser ASF uniquement parce qu’il forunis les cartes plus rapidement, ASF et Idle Master étant tous deux affectés par le fonctionnement de Steam Web, ASF interagit plus efficacement avec Steam Web, tandis que Idle Master ne peut pas contrôler le client Steam. (de sorte que ce n’est pas la faute de Idle Master, mais bien du client Steam lui-même).

---

### Can ASF farm multiple games at once?

**Oui**, même si ASF sait mieux utiliser cette fonctionnalité, en fonction de l’algorithme de farming **[sélectionné](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)**. Card drops rate when farming multiple games is close to zero, this is why ASF is using multiple games farming exclusively for hours in order to overcome `HoursUntilCardDrops` faster, for up to `32` games at once. This is also why you should focus on configuration part of the ASF, and let algorithms decide what is the best way to achieve the goal - what you think is right, is not necessarily right in reality, farming multiple games at once will not provide you with any card drops.

---

### Est-ce que ASF peut parcourir les jeux rapidement?

**Non**, ASF ne prend pas en charge ni encourage l'utilisation de **[gliches Steam](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance#steam-glitches)**.

---

### Can ASF automatically play each game for X hours before cards are added?

**Non**, le changement de système de cartes de Steam visait essentiellement à lutter contre de fausses statistiques et des joueurs fantômes. ASF ne contribuera pas à cela plus que nécessaire, l'ajout d'une telle fonctionnalité n'est pas planifié et ne se produira pas. If your game receives card drops in usual way, ASF will farm them as soon as possible.

---

### Puis-je jouer à un jeu pendant qu'ASF est en train de farmer ?

**Non** Contrairement à IM, ASF inclut un client Steam indépendant et le réseau Steam ne permet à **qu'un client Steam à la fois ** de jouer à un jeu. Vous pouvez cependant déconnecter ASF à tout moment en démarrant une partie (et en cliquant sur "OK" lorsqu'on lui demande si le réseau Steam doit déconnecter un autre client). ASF attendra alors patiemment jusqu'à ce que vous ayez fini de jouer, puis reprendra le processus. Alternativement, vous pouvez toujours jouer en mode hors connexion à tout moment, si cela vous convient.

N'oubliez pas que le taux d'obtention des cartes lorsque vous jouez à plusieurs jeux est proche de 0; il n'y a donc aucun avantage direct à ce que vous puissiez le faire avec IM, alors qu'il existe de solides avantages de ne pas interférer avec d'autres jeux lancés avec ASF, ce qui est crucial. par exemple VAC-sage.

---

## Sécurité / Vie Privée / VAC / Bans / ToS

---

### Puis-je obtenir une interdiction VAC en utilsant ASF ?

Non, ce n'est pas possible car ASF (contrairement à Idle Master ou SAM) n'interfère en aucune manière avec le client Steam ni avec ses processus. Il est physiquement impossible d’obtenir une interdiction VAC pour utiliser ASF, même lorsque vous jouez sur des serveurs sécurisés lorsque ASF est en cours d’exécution, car **ASF ne nécessite même pas l’installation de Steam Client** pour fonctionner correctement. ASF est le seul programme de farming pouvant actuellement garantir l’absence de ban VAC.

---

### Est-ce que l’utilisation d’ASF peut m’empêcher de jouer sur des serveurs sécurisés par VAC, comme indiqué **[ici](https://help.steampowered.com/faqs/view/22C0-03D0-AE4B-04E8)**?

ASF ne nécessite pas l'exécution du client Steam, ni même son installation. Selon ce concept, **cela** ne devrait pas causer de problèmes liés à VAC, car ASF garantit l'absence d'interférences avec le client Steam et tous ses processus. C'est le point principal en parlant de la garantie sans ban VAC qu'ASF offre.

Selon les utilisateurs et autant que je sache, c'est le cas à l'heure actuelle, car personne n'a signalé de problème comme indiqué dans le lien ci-dessus lors de l'utilisation de ASF. Nous ne pouvions pas reproduire le problème ci-dessus avec ASF, tout en le reproduisant clairement avec Idle Master.

However, keep in mind that Valve could still add ASF to the blacklist at some point, but it's a complete nonsense as even if they do that, you could still play VAC-secured games from your PC, and use ASF at the same time e.g. on your server, so I'm pretty sure that they know very well that ASF should not be a suspect VAC-wise, and they won't make our lifes harder by blacklisting ASF for no reason. Néanmoins, dans le pire des cas, vous ne pourrez pas jouer, comme indiqué ci-dessus, car la garantie ASF sans ban VAC est toujours présente, que la liste noire  de ASF soit binaire ou non (et que vous puissiez toujours lancer ASF sur toute autre machine sans Steam client en cours d'installation). À l'heure actuelle, il n'est pas nécessaire de faire quoi que ce soit et espérons que cela reste comme ça.

---

### Est-ce sûr ?

Si vous vous demandez si ASF est un logiciel sûr, cela signifie qu'il ne causera aucun dommage à votre ordinateur, ne volera pas vos données personnelles, n'installera pas de virus ou autre chose du genre - c'est sûr. ASF is free of malware, data stealing, cryptocurrency miners and any (and all) other doubtful behaviour that can be considered malicious or unwanted by the user. In addition to that we have a dedicated **[remote communication](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Remote-communication)** section which covers our privacy policy and ASF behaviour that goes beyond what you configured the program to do yourself.

Le code est open-source et les fichiers binaires distribués sont toujours compilés à partir de **[sources accessibles au public](https://en.wikipedia.org/wiki/Open-source_software)** par **[systèmes d'intégration continue automatisés et sécurisés](https://en.wikipedia.org/wiki/Build_automation)**, et même par les développeurs eux-mêmes. Chaque génération est reproductible en suivant notre script de génération et donnera exactement le même code **[deterministic](https://en.wikipedia.org/wiki/Deterministic_system)** IL (binaire). Si, pour une raison quelconque, vous ne faites pas confiance à nos versions, vous pouvez toujours compiler et utiliser ASF depuis la source, y compris toutes les bibliothèques utilisées par ASF (telles que SteamKit2), qui sont également à code source ouvert.

In the end however, it's always a matter of trust to the developer(s) of your application, so you should decide yourself if you consider ASF safe or not, potentially supporting your decision with technical arguments specified above. Ne croyez pas stupidement quelque chose uniquement parce que je l'ai dit - vérifiez-vous, car c'est le seul moyen de vous en assurer.

---

### Puis-je être banni pour cela?

Pour répondre à cette question, examinons de plus près **[Steam ToS](https://store.steampowered.com/subscriber_agreement)**. Steam n’interdit pas l’utilisation de plusieurs comptes. En fait, **[elle le permet](https://help.steampowered.com/faqs/view/7EFD-3CAE-64D3-1C31#share)**, ce qui implique que vous pouvez utiliser le même authentificateur de mobile sur plusieurs comptes. Cependant, cela ne permet pas de partager des comptes avec d'autres personnes, mais nous ne le faisons pas ici.

Le seul véritable point qui tient compte d’ASF est le suivant :
> Vous n'êtes pas autorisé à utiliser des astuces, des logiciels d'automatisation (bots), des mods, des hacks ou tout autre logiciel tiers non autorisé pour modifier ou automatiser un processus du marché des abonnements.

La question est de savoir en quoi consiste le processus du marché des abonnements. Comme on peut le lire:

> Un exemple de marché d'abonnement est le marché communautaire Steam

Nous ne modifions ni n'automatisons pas le processus du marché des abonnements si, par marché des abonnements, nous comprenons le marché communautaire de Steam ou le magasin Steam. Toutefois...

> Valve peut annuler votre compte ou tout abonnement particulier à tout moment dans le cas où (a) Valve cesserait de fournir ces abonnements à des abonnés se trouvant dans la même situation, ou (b) vous enfreignez l'une des conditions du présent contrat (y compris les conditions d'abonnement ou les conditions d'utilisation et Règles d'utilisation).

Par conséquent, comme avec tous les logiciels Steam, ASF n’est pas autorisé par Valve et je ne peux pas garantir que vous ne serez pas suspendu si Valve décidait soudainement qu’ils interdisaient désormais les comptes utilisant ASF. This is exceptionally unlikely considering the fact that ASF is being used on more than a million of Steam accounts, but still a possibility, regardless of actual probability.

Spécialement parce que:
> In regard to all Subscriptions, Content and Services that are not authored by Valve, Valve does not screen such third-party content available on Steam or through other sources. Valve n'assume aucune responsabilité pour ce contenu tiers. Some third-party application software is capable of being used by businesses for business purposes - however, you may only acquire such software via Steam for private personal use.

However, Valve clearly acknowledges "Steam idlers" existing, as stated **[here](https://help.steampowered.com/faqs/view/22C0-03D0-AE4B-04E8)**, so if you asked me, I'm pretty sure that if they weren't fine with them, they'd already do something instead of pointing out that they could cause problems VAC-wise. Le mot clé ici est **utilisateurs de Steam**, par exemple  de ASF, et non **utilisateurs de jeu**.

Please note that above is only our interpretation of **[Steam ToS](https://store.steampowered.com/subscriber_agreement)** and various points - ASF is licensed under Apache 2.0 License, which clearly states:

```
Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
```

Vous utilisez ce logiciel à vos risques et périls. Il est très peu probable que vous puissiez être banni pour cela, mais si vous le faites, vous ne pouvez vous en prendre qu'à vous-même.

---

### Quelqu'un a-t-il été banni pour cela?

**Oui**, nous avons eu au moins quelques incidents jusqu'à présent qui ont entraîné une sorte de suspension Steam. Que ASF en soit ou non la cause fondamentale est une tout autre histoire que nous ne connaîtrons probablement jamais.

First case involved a guy with over 1000+ bots getting trade banned (together with all bots), most likely due to excessive usage of `loot ASF` executed on all bots at once, or other suspicious one-side amount of trades in a very short time.

> Bonjour XXX, Merci d'avoir contacté le support Steam. Il semble que ce compte ait été utilisé pour gérer un réseau de comptes bot. L'utilisation de bots est une violation du contrat Steam.

S'il vous plaît, faites preuve de bon sens et ne présumez pas que vous pouvez faire de telles choses folles uniquement parce qu'ASF vous permet de le faire. Faire `loot ASF` sur plus de 1 000 bots peut facilement être considéré comme une attaque **[DDoS](https://en.wikipedia.org/wiki/DDoS)**, et personnellement, je ne suis pas choqué que quelqu'un ait été banni pour une telle chose. Keep minimum of fair use in regards to Steam service, and **most likely** you'll be fine.

Second case involved a guy with 170+ bots getting banned during Steam's 2017 Winter Sale.

> Votre compte a été bloqué pour violation de l'accord de l'utilisateur Steam. À en juger par les échanges et d’autres facteurs, ce compte a été utilisé pour collecter illégalement des cartes à collectionner sur Steam, ainsi que des activités connexes et non seulement commerciales. Le compte a été bloqué de manière permanente et le support Steam ne peut pas fournir de support supplémentaire sur ce problème.

Cette affaire est encore une fois très difficile à analyser, en raison de la réponse du support de Steam qui offre à peine des détails. D'après mes réflexions personnelles, cet utilisateur a probablement échangé des cartes Steam contre une sorte d'argent (mise à niveau?) Ou d'une autre manière tenté de retirer de l'argent de Steam. In case you were unaware, this is also illegal according to **[Steam ToS](https://store.steampowered.com/subscriber_agreement)**.

Third case involved user with 120+ bots being banned for breach of **[Steam online conduct](https://store.steampowered.com/online_conduct?l=english)**.

> Bonjour XXX, Merci d'avoir contacté le support Steam. Ce compte et d'autres ont été utilisés pour flooder notre infrastructure réseau, ce qui constitue une violation de la conduite à tenir en ligne de Steam. Le compte a été bloqué de manière permanente et le support Steam ne peut pas fournir de support supplémentaire sur ce problème.

Cette affaire est un peu plus facile à analyser en raison des détails supplémentaires fournis par l'utilisateur. Apparemment, l’utilisateur utilisait **une version ASF très obsolète** qui incluait un bug obligeant ASF à envoyer un nombre excessif de demandes aux serveurs Steam. Le bug lui-même n’existait pas au début, mais a été activé en raison de la modification radicale de Steam qui a été corrigée dans une version ultérieure. **ASF is supported only in [latest stable version](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest) released on GitHub**. Les logiciels sont écrits par des humains et les humains ont tendance à faire des erreurs. Si l'erreur a une portée globale, elle est rapidement corrigée et diffusée à tous les utilisateurs sous forme de correctif. Valve won't suddenly ban over a million of ASF users due to my mistake, for obvious reasons. Toutefois, si vous renoncez délibérément à utiliser une version ASF à jour, vous êtes par définition une très petite minorité d'utilisateurs **exposés à des incidents comme ceux-ci** en raison de **pas de prise en charge**, personne ne surveille votre version obsolète d'ASF, personne ne la répare et personne ne s'assure que vous ne serez pas totalement banni du simple fait de le lancer. **Veuillez utiliser un logiciel à jour**, pas seulement ASF, mais également toutes les autres applications.

The most recent case happened around June of 2021, according to the user:

> Using your program, I have been making booster packages with 28 accounts for 3 years and with 128 accounts for the last 6 months. I was online with maximum 15 accounts simultaneously to make booster packs and send them to the main account. Last month, I increased the number of online accounts simultaneously to 20, and 1 week after that, all of my accounts were banned. This email is not to blame you, on the contrary, I was always aware of the consequences. I wanted you to know what types of behavior result in a permanent ban.

It's hard to say whether increase in concurrent accounts online was the direct reason for the ban, I wouldn't count on that, instead I believe that the number of accounts alone was the main culprit, increased concurrency of online accounts probably just drew attention to the user in question, as he clearly had far more bots than our recommendation.

---

Tous les incidents ci-dessus ont une chose en commun: ASF n’est qu’un outil et **votre décision** de décider de l’utilisation qui en est faite. Vous n'êtes pas banni pour utiliser ASF directement, mais pour **comment** vous l'utilisez. It can be a helper tool farming just one single account, or a massive farming network made from thousands of bots. In any case, I'm not offering legal advice, and you should decide yourself about your ASF usage in the first place. Je ne cache aucune information qui pourrait vous aider, par exemple. le fait qu'ASF ait banni certaines personnes, car je n'ai aucune raison de le faire - c'est à vous de choisir ce que vous voulez faire avec ces informations. If you ask me - use some common sense, avoid owning more bots than our recommendation, do not send hundreds of trades at the same time, always use up-to-date ASF version and you _should_ be fine. Every single incident of this nature for **some reason** always happened to people that have disregarded our recommendation and decided that they know better than us how many bots they can run. Que ce soit juste une coïncidence ou un facteur réel, c'est à vous de décider. Je ne vous offre aucun conseil juridique, je ne fais que vous donner mes pensées que vous pouvez trouver utiles, ou les ignorer entièrement et ne traiter que des faits liés ci-dessus.

---

### Quelles sont les informations de confidentialité divulguées par ASF?

You can find detailed explanation in **[remote communication](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Remote-communication)** section. Vous devriez l'examiner si vous tenez à votre vie privée, par exemple. si vous vous demandez pourquoi les comptes utilisés dans ASF rejoignent notre groupe Steam. ASF ne collecte aucune information sensible et ne le partage avec aucun tiers.

---

## Divers

---

### J'utilise un système d'exploitation non pris en charge tel que Windows 32 bits. Puis-je quand même utiliser la dernière version d'ASF ?

Oui, et cette version n’est en aucun cas prise en charge, mais n’est pas officiellement construite. Consultez la section **

 compatibilité </ 0> pour la variante générique. ASF doesn't have any strong dependency upon the OS, and it can work anywhere where you can get a working .NET runtime, which includes 32-bit Windows, even if there is no `win-x86` OS-specific package from us.</p> 



---



### C'est super ! Puis-je faire un don?

Oui, et nous sommes ravis d'apprendre que vous appréciez notre projet! Vous pouvez trouver différentes possibilités de dons sous chaque **[publication](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** et également **[sur la page principale](https://github.com/JustArchiNET/ArchiSteamFarm)**. It's nice to note that in addition to generic money donations we also accept Steam items, so nothing is stopping you from donating skins, keys or a small part of the cards that you've farmed with ASF if you'd like to. Je vous remercie pour votre générosité!



---



### J'utilise le code PIN parental de Steam pour protéger mon compte. Dois-je le saisir quelque part?

Oui, vous devez le définir dans la fonctionnalité de configuration du bot `SteamParentalCode`. En effet, ASF accède à de nombreuses parties protégées de votre compte Steam et il est impossible pour ASF de fonctionner sans ce dernier.



---



### Je ne veux pas qu'ASF  farm des jeux par défaut, mais je veux utiliser des fonctionnalités supplémentaires d'ASF. Est-ce possible?

Yes, if you just want to start ASF with paused cards farming module, you can set `Paused` bot config property to `true` in order to achieve that. This will allow you to `resume` it during runtime.

If you want to completely disable cards farming module and ensure that it'll never run without you explicitly telling it otherwise, then we recommend to set `FarmPriorityQueueOnly` to `true`, which instead of just pausing it, will disable the farming completely until you add the games to idle priority queue yourself.

With cards farming module paused/disabled, you can make use of extra ASF features, such as `GamesPlayedWhileIdle`.



---



### ASF peut-il se réduire au minimum?

ASF est une application console, il n'y a pas de fenêtre à minimiser, car celle-ci est créée pour vous par votre système d'exploitation. You can however use any third-party tool capable of doing so, such as **[RBTray](https://github.com/benbuck/rbtray)** for Windows, or **[screen](https://linux.die.net/man/1/screen)** for Linux/macOS. Those are only examples, there are many other apps with similar functionality.



---



### Est-ce que le fait d’utiliser ASF préserve l’éligibilité pour recevoir des boosters?

**Oui**. ASF is using the same method to log in to Steam network as the official client, therefore it also preserves ability to receive booster packs for accounts that are being used in ASF. Moreover, preserving that ability doesn't even require logging in into Steam community, so you can safely use `OnlineStatus` in `Offline` setting if you'd like to.



---



### Y a-t-il un moyen de communiquer avec ASF?

Yes, through several different ways. Consultez la section **[Commandes](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** pour plus d'informations.



---



### J'aimerais aider à la traduction d'ASF, que dois-je faire?

Merci de votre intérêt! Vous trouverez des explications détaillées dans la section **[localisation](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Localization)**.



---



### Un seul compte (principal) a été ajouté à ASF. Puis-je quand même émettre des commandes via le chat Steam?

**Oui**, cela est expliqué dans la section **[Commandes](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands#notes)**. You can do so through Steam group chat, although using **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)** could be easier for you.



---



### ASF semble fonctionner, mais je ne reçois aucune carte!

Le taux de farming des cartes diffère d’un jeu à l’autre, comme vous pouvez le lire dans **[performances](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)**. Cela prend un certain temps, généralement **plusieurs heures par jeux**, et vous ne devez pas vous attendre à ce que les cartes tombent quelques minutes après le lancement du programme. If you can see that ASF actively checks cards status, and switches the game after current one is fully farmed, then everything works fine. It's possible that you've enabled an option such as `DismissInventoryNotifications` of `BotBehaviour` which automatically dismisses inventory notifications. Consultez **[configuration](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** pour plus de détails.



---



### Comment arrêter complètement le processus ASF pour mon compte?

Arrêtez simplement le processus ASF, par exemple en cliquant sur [X] sur la fenêtre du programme. Si, au lieu de cela, vous souhaitez arrêter un bot particulier de votre choix mais en garder d'autres en cours d'exécution, consultez `Enabled` dans **[les fichiers de configuration du bot](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#bot-config)** ou la **[commande](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** `stop`. If you instead want to stop automatic farming process, yet keep ASF running for your account, then that's what `Paused` **[bot config property](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#bot-config)** and `pause` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** is for.



---



### Combien de bots puis-je utiliser avec ASF?

ASF as a program doesn't have any hard upper limit of bot instances, so you can run as much as you have memory on your machine, however, you're still being limited by the Steam network and other Steam services. Currently you can run up to 100-200 bots with a single IP and a single ASF instance. It's possible to run more bots with more IPs and more ASF instances, by working around IP limitations. Keep in mind that if you're using that big amount of bots, you should control their number yourself, such as making sure that all of them in fact are logging in and working at the same time. ASF was not tweaked for that huge number of bots, and the general rule applies that **the more bots you have, the more issues you'll encounter**. Also notice that the limit above in general depends on many internal factors, it's approximation rather than a strict limit - you will most likely be able to run more/less bots than specified above.

ASF team suggests running (and **owning**) up to **10 bots in total**, anything above is not supported and done at your own risk, against our suggestion made here. This recommendation is based on internal Valve guidelines, as well as our own suggestions. Whether you're going to comply with this rule or not is your choice, ASF as a tool will not go against your own will, even if it'll result in your Steam accounts being suspended for doing so. Therefore, ASF will display you a warning if you'll go above what we recommend, but still allow you to run anything you want at your own risk and lack of our support.



---



### Puis-je exécuter plus d'instances ASF alors?

Vous pouvez exécuter autant d'instances ASF que vous le souhaitez sur une machine, en supposant que chaque instance a son propre répertoire et ses propres configurations, et qu'un compte utilisé dans une instance n'est pas utilisé dans une autre. Cependant, demandez-vous pourquoi vous voulez faire cela. ASF is optimized to handle more than a hundred of accounts at the same time, and launching that hundred of bots in their own ASF instances degrades performance, takes more OS resources (such as CPU and memory), and causes a potential synchronization issues between standalone ASF instances, as ASF is forced to share its limiters with other instances.

Par conséquent, ma **suggestion forte** consiste à toujours exécuter au maximum une instance ASF par adresse IP / interface. If you have more IPs/interfaces, by all means you can run more ASF instances, with every instance using its own IP/interface or unique `WebProxy` setting. If you don't, launching more ASF instances is totally pointless, as you won't gain anything from launching more than 1 instance per a single IP/interface. Steam will not magically allow you to run more bots just because you've launched them in another ASF instance, and ASF doesn't limit you to begin with.

Of course, there are still valid use cases for multiple ASF instances on the same network interface, such as hosting ASF service for your friends with each friend having its own unique ASF instance in order to guarantee isolation between bots and even the ASF processes themselves, however, you're not circumventing any Steam limitations this way, that's entirely different purpose.



---



### Quel est la signification du statut lors de l'utilisation d'une clé?

Le statut indique comment la tentative d'activation a été effectué. Il existe de nombreux statuts différents. Les plus courants incluent:

| Statut                  | Description                                                                                                                                                                                                                               |
| ----------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| NoDetail                | Etat "OK" indiquant le succès - la clé a été utilisée avec succès.                                                                                                                                                                        |
| Timeout                 | Le réseau Steam n'a pas répondu dans le délai imparti, nous ne savons pas si la clé a été utilisée, ou pas (probablement, mais vous pouvez réessayer).                                                                                    |
| BadActivationCode       | La clé fournie n'est pas valide (n'est reconnue comme aucune clé valide par le réseau Steam).                                                                                                                                             |
| DuplicateActivationCode | La clé fournie a déjà été utilisée par un autre compte ou révoquée par le développeur/éditeur.                                                                                                                                            |
| AlreadyPurchased        | Votre compte possède déjà `packageID` connecté à cette clé. Gardez à l'esprit que cela n'indique pas si la clé est `DuplicateActivationCode ` ou pas - seulement qu'elle est valide et qu'elle n'a pas été utilisée dans cette tentative. |
| RestrictedCountry       | Cette clé est verrouillée par région et votre compte n'est pas dans la région valide qui est autorisée.                                                                                                                                   |
| DoesNotOwnRequiredApp   | Vous ne pouvez pas échanger cette clé car il vous manque une autre application, principalement un jeu de base, lorsque vous essayez d'utiliser un package DLC.                                                                            |
| RateLimited             | Vous avez effectué trop de tentatives et votre compte a été temporairement bloqué. Réessayez dans une heure.                                                                                                                              |




---



### Êtes-vous affilié à un service cards farming/idling service?

**Non** ASF n'est affiliée à aucun service et toutes ces réclamations sont fausses. Votre compte Steam est votre propriété et vous pouvez l'utiliser de la manière que vous souhaitez, mais Valve a clairement indiqué dans **[ToS officiel](https://store.steampowered.com/subscriber_agreement)** que:



> Vous êtes responsable de la confidentialité de votre identifiant et de votre mot de passe, ainsi que de la sécurité de votre système informatique. Valve is not responsible for the use of your password and Account or for all of the communication and activity on Steam that results from use of your login name and password by you, or by any person to whom you may have intentionally or by negligence disclosed your login and/or password in violation of this confidentiality provision.

ASF est sous licence Apache 2.0, une licence libérale qui permet aux autres développeurs d’intégrer  ASF dans leurs propres projets et services de manière légale. Cependant, ces projets de tiers utilisant ASF ne sont pas garantis pour être sûr, revus, approprié ou licite selon **[Vapeur ToS](https://store.steampowered.com/subscriber_agreement)**. Si vous souhaitez connaître notre opinion, **nous vous encourageons vivement à ne PAS partager les informations de votre compte avec des services tiers**. Si un tel service s'avère être une **arnaque typique**, le problème vous échappera, sans le compte Steam et le plus souvent, ASF n'assumera aucune responsabilité pour les services tiers prétendant être sûr et sécurisé, car l'équipe d'ASF n'a pas autorisé ni examiné aucun de ceux-ci. En d'autres termes, **vous les utilisez à vos risques et périls, contrairement à notre suggestion ci-dessus**.

In addition to that, official **[Steam ToS](https://store.steampowered.com/subscriber_agreement)** clearly states that:



> Vous n'êtes pas autorisé à révéler, partager ou autoriser des tiers à utiliser votre mot de passe ou votre compte, sauf autorisation exceptionnelle de Valve.

C'est votre compte et votre choix. Juste ne dites pas que personne ne vous a prévenu. ASF en tant que programme respecte toutes les règles mentionnées ci-dessus, car vous ne partagez pas les informations de votre compte avec qui que ce soit, et vous utilisez le programme pour votre usage personnel, mais tout autre "service de gestion de cartes" requiert vos identifiants de compte. , donc il viole également la règle ci-dessus (en fait plusieurs d'entre eux). Like with **[Steam ToS](https://store.steampowered.com/subscriber_agreement)** evaluation, we're not offering any legal advice, and you should decide yourself if you want to use those services, or not - according to us **it directly violates [Steam ToS](https://store.steampowered.com/subscriber_agreement)** and may result in suspension if Valve finds out. Comme indiqué ci-dessus, **nous vous recommandons vivement de NE PAS utiliser ces services**.



---



## Problèmes



---



### One of my games is being farmed for more than 10 hours now, but I still didn't get any cards from it!

The reason for that could be related to known issue of Steam, which happens when you have two licenses for the same game, one of which has card drops limited. This usually happens when you activate game for free during a mass giveaway on Steam, and then activate a key for the same game (but without limitations), e.g. from a paid bundle. If such situation happens, Steam reports on badge page that game still has cards to drop, but no matter how much you play the game - cards will never drop due to free license on your account. Since it's not an ASF issue, but a Steam one, we can't somehow circumvent it on ASF's side, and you need to solve it yourself.

There are two ways to solve the issue. Firstly, you can blacklist this game in ASF, either with `fbadd` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** or with `Blacklist` **[configuration property](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)**. This will prevent ASF from trying to farm cards from this game, but will not solve the underlying issue which prevents you from obtaining card drops from the affected game. Secondly, you can use Steam support self-service tool to remove free license from your account, leaving only full license that includes the card drops. In order to do so, firstly visit your **[licenses and product key activations](https://store.steampowered.com/account/licenses)** page and locate both free and paid license for the affected game. Usually it's fairly easy - both have similar name, but free one has "limited free promotional package" or other "promo" in the license name, plus "complimentary" in "acquisition method" field. Sometimes it might be more tricky, for example if free package was in some bundle and has a different name. If you have found two licenses like that - then it's indeed the issue described here, and you can safely remove free license without losing the game.

In order to remove the free license from your account, visit **[Steam support page](https://help.steampowered.com/wizard/HelpWithGame)** and put the affected game name into the search field, the game should be available in "products" section, click on it. Alternatively, you can just use `https://help.steampowered.com/wizard/HelpWithGame?appid=<appID>` link and replace `<appID>` with appID of the game that causes troubles. Afterwards, click on "I want to permanently remove this game from my account" and then select the faulty free license that you've found above, usually the one with "limited free promotional package" in the name (or similar). After removal of the free license, ASF should be able to drop cards from the affected game without issues, you should restart the farming operation after the removal just to be sure that Steam picks up the right license this time.



---



### ASF ne détecte pas le jeu `X` disponible pour le farming, mais je sais qu’il comprend des cartes à échanger Steam!

Il y a deux raisons principales ici. La première et la plus évidente raison est le fait que vous vous référez au **magasin Steam**, dans lequel un jeu donné est annoncé comme un jeu activé pour l'obtention de cartes. Cette hypothèse est **fausse**, car elle indique simplement que le jeu **contient des** des cartes inclus, mais que cette fonction n'est pas nécessairement **activée immédiatement** pour ce jeu.  Vous pouvez en savoir plus à ce sujet dans **[annonce officielle](https://steamcommunity.com/games/593110/announcements/detail/1954971077935370845)**.

En bref, l’icône de l'obtention de cartes dans le magasin Steam ne veut rien dire, vérifiez dans les **[pages de vos badges](https://steamcommunity.com/my/badges)** si un jeu est activé ou non - c'est ce que ASF fait. If your game doesn't appear on the list as a game with cards possible to drop, then this game is **not** possible to farm, regardless of reason.

Second issue is less obvious, and it's the situation when you can see that your game indeed is available with card drops on your badge page, yet it's not being farmed by ASF right away. À moins que vous ne rencontriez un autre bug, tel qu'ASF ne pouvant pas vérifier les pages de badge (décrit ci-dessous), il s'agit simplement d'un effet de cache et du côté ASF, Steam continue de signaler des page de badges obsolètes. Ce problème devrait se résoudre tôt ou tard, lorsque le cache sera invalidé. Il n'y a également aucun moyen de régler ce problème de notre côté.

Of course, all of that assumes that you're running ASF with default untouched settings, since you could also add this game to farming blacklist, use `FarmPriorityQueueOnly`, `SkipRefundableGames` and so on.



---



### Why playtime of games farmed through ASF doesn't increase?

Oui, mais **pas en temps réel**. Steam enregistre votre temps de lecture à intervalles fixes et planifie sa mise à jour, mais vous n'êtes pas sûr de l'avoir immédiatement mis à jour dès que vous quittez la session, et encore moins pendant une telle heure. Just because the playtime isn't updated in real-time doesn't mean that it's not recorded, it's usually updated every 30 minutes or so.



---



### Quelle est la différence entre un avertissement et une erreur dans le journal?

ASF écrit dans son journal une multitude d'informations sur différents niveaux de journalisation. Notre objectif est d'expliquer **précisément** ce que fait ASF, y compris les problèmes auxquels il doit faire face, ainsi que d'autres problèmes à résoudre. La plupart du temps, tout n’est pas pertinent, c’est la raison pour laquelle nous utilisons deux principaux niveaux dans ASF en termes de problèmes: un niveau d’avertissement et un niveau d’erreur.

La règle générale ASF est que les avertissements ne sont **pas**, ils doivent donc **pas** être signalés. Un avertissement vous indique que quelque chose de potentiellement indésirable se produit. Que ce soit Steam qui ne réagit pas, les erreurs de lancement d'API ou votre connexion réseau en panne - il s'agit d'un avertissement, et cela signifie que nous nous attendions à ce que cela se produise. Ne gênez donc pas le développement d'ASF. Bien sûr, vous êtes libre de poser des questions à leur sujet ou d'obtenir de l'aide en utilisant notre support, mais vous ne devez pas supposer qu'il s'agit d'erreurs ASF qui méritent d'être signalées (sauf confirmation contraire de notre part).

Les erreurs, par contre, indiquent une situation qui ne devrait pas se produire. Elles méritent donc d'être signalées si vous vous assurez que ce n'est pas vous qui les causez. Si nous nous attendons à ce qu'une situation courante se produise, elle sera convertie en un avertissement. Sinon, il s'agit probablement d'un bogue qui devrait être corrigé et non ignoré silencieusement, en supposant que cela ne soit pas le résultat de votre propre problème technique. Par exemple, la suppression du fichier principal `ASF.json` génère une erreur, car ASF ne peut fonctionner sans ce fichier. C’est vous qui l’avez supprimé. Vous ne devez donc pas nous signaler cette erreur (sauf si vous avez confirmé qu'ASF est erroné et que le fichier est là).

Dans une phrase TL;DR - signaler les erreurs, ne signalez pas les avertissements. Vous pouvez toujours poser des questions sur les avertissements et recevoir de l'aide dans nos sections d'assistance.



---



### ASF doesn't start, the program window closes immediately!

In normal conditions, any ASF crash or exit will generate a `log.txt` in the program's directory for you to view, which can be used for finding the cause of that. In addition to that, a few last log files are also archived in `logs` directory, since the main `log.txt` file is overwritten with each ASF run.

However, if even .NET runtime isn't able to boot on your machine, then `log.txt` will not be generated. If that happens to you then you most likely forgot to install .NET prerequisites, as stated in **[setting up](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up#os-specific-setup)** guide. Other common problems include trying to launch wrong ASF variant for your OS, or in other way missing native .NET runtime dependencies. Si la fenêtre de la console se ferme trop tôt pour que vous puissiez lire le message, ouvrez une console indépendante et lancez le fichier binaire ASF à partir de cet emplacement. For example on Windows, open ASF directory, hold `Shift`, right click inside the folder and choose "*open command window here*" (or *powershell*), then type into the console `.\ArchiSteamFarm.exe` and confirm with enter. De cette façon, vous obtiendrez un message précis indiquant pourquoi ASF ne démarre pas correctement.



---



### ASF lance ma session client Steam pendant que je joue! / *Ce compte est connecté sur un autre PC*

Cela s’affiche sous forme de message dans l’incrustation Steam indiquant que le compte est utilisé ailleurs pendant que vous jouez. Ce problème peut avoir deux raisons différentes.

Une des raisons est due à des paquets cassés (jeux) qui, en particulier, ne tiennent pas un verrou de jeu correctement, mais s'attendent à ce que ce verrou soit possédé par le client. Skyrim SE est un exemple de ce type de paquet. Votre client Steam lance le jeu correctement, mais ce jeu ne s’enregistre pas comme étant utilisé. A cause de cela, ASF voit qu'il est libre de reprendre le processus, ce qui est le cas, et cela vous éloigne du réseau Steam, car Steam détecte soudainement que le compte est utilisé à un autre endroit.

Second reason could come up if you're playing on your PC while ASF is waiting (especially on another machine) and you lose your network connection. Dans ce cas, le réseau Steam vous marque comme étant hors ligne et libère le verrou de lecture (comme ci-dessus), ce qui déclenche la reprise du farming par ASF (sur une autre machine, par exemple). Lorsque votre ordinateur revient en ligne, Steam ne peut plus acquérir le verrou de lecture (qui est maintenant détenu par ASF, similaire au précédent) et affiche le même message.

Les deux causes du côté d’ASF sont en réalité très difficiles à contourner, car ASF reprend simplement l’agriculture une fois que le réseau Steam l’a informé que le compte était libre d’être utilisé à nouveau. C’est ce qui se passe normalement lorsque vous fermez le jeu, mais avec les paquets cassés, cela peut se produire immédiatement, même si votre jeu est toujours en cours d’exécution. ASF n'a aucun moyen de savoir si vous êtes déconnecté, si vous avez arrêté de jouer ou si vous continuez de jouer à un jeu qui ne tient pas le jeu de manière appropriée.

La seule solution appropriée à ce problème consiste à suspendre manuellement votre bot avec `pause` avant de commencer à jouer et à le reprendre avec `resume` une fois que vous avez terminé. Sinon, vous pouvez simplement ignorer le problème et agir comme si vous jouiez avec un client Steam hors ligne.



---



### `Déconnecté de Steam!` - Je ne parviens pas à établir la connexion avec les serveurs Steam.

ASF peut uniquement **essayer** d’établir une connexion avec des serveurs Steam. Cette défaillance peut échouer pour de nombreuses raisons, notamment l’absence de connexion Internet, la désactivation de Steam, la connexion bloqué par votre pare-feu, des outils tiers et des fichiers configurés de manière incorrecte. ou des échecs temporaires. Vous pouvez activer le mode `Debug` pour extraire un journal plus détaillé exposant les raisons exactes des échecs, bien que cela soit généralement dû à vos propres actions, telles que l'utilisation de "CS: GO MM Server Picker" qui met beaucoup de listes noires dans Steam IP, rendant très difficile l’accès au réseau Steam.

ASF fera de son mieux pour établir la connexion, ce qui implique non seulement de demander une liste de mise à jour des serveurs, mais également d'essayer une autre adresse IP en cas d'échec de la dernière. Par conséquent, s'il s'agit vraiment d'un problème temporaire avec un serveur ou une route spécifique, ASF se connectera tôt ou tard. Cependant, si vous êtes derrière un pare-feu ou si, d’une autre manière, vous ne parvenez pas à atteindre les serveurs Steam, vous devez évidemment le réparer vous-même, avec l’aide éventuelle du mode `Debug`.

Il est également possible que votre machine ne puisse pas établir de connexion avec les serveurs Steam en utilisant le protocole par défaut dans ASF. Vous pouvez modifier les protocoles qu'ASF est autorisé à utiliser en modifiant le fichier de configuration globale `SteamProtocols`. For example, if you have problems reaching Steam with `UDP` protocol (e.g. due to firewalls), perhaps you'll have more luck with `TCP` or `WebSocket`.

In a very unlikely situation of having incorrect servers being cached, for example because of moving ASF `config` folder from one machine to another machine located in entirely different country, deleting `ASF.db` in order to refresh Steam servers on the next launch may help. Very often it's not needed and doesn't have to be done, as that list is automatically refreshed on first launch, as well as when the connection is established - we're just mentioning it as a way to purge anything related to list of Steam servers cached by ASF.



---



### `Impossible d'obtenir des informations sur les badges, j'essaierai plus tard!`

Usually it means that you're using Steam parental PIN to access your account, yet you forgot to put it in ASF config. You must put valid PIN in `SteamParentalCode` bot config property, otherwise ASF will not be able to access most of web content, therefore will not be able to work properly. Rendez-vous sur **[configuration](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** pour en savoir plus sur le `SteamParentalCode`.

Other reasons include temporary Steam problem, network issue or likewise. Si le problème ne se résout pas après plusieurs heures et que vous êtes certain d'avoir configuré ASF correctement, n'hésitez pas à nous le faire savoir.



---



### ASF is failing with `Request failed after 5 tries` errors!

Usually it means that you're using Steam parental PIN to access your account, yet you forgot to put it in ASF config. You must put valid PIN in `SteamParentalCode` bot config property, otherwise ASF will not be able to access most of web content, therefore will not be able to work properly. Rendez-vous sur **[configuration](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)** pour en savoir plus sur le `SteamParentalCode`.

If parental PIN is not the reason, then this is a most common error, and you should get used to that, it simply means that ASF sent a request to Steam Network, and didn't get a valid response, 5 times in a row. Cela signifie généralement que Steam est en panne, ou en maintenance. ASF en est conscient et vous ne devez pas vous en inquiéter, à moins que cela ne se produise plusieurs heures à la fois et que les autres utilisateurs ne rencontrent pas de tels problèmes. 

Comment vérifier si Steam est en panne? **[Steam Status](https://steamstat.us)** is an excellent source of checking if Steam **should be** up, if you notice errors, especially related to Community or Web API, then Steam is having difficulties. You may want to leave ASF alone and let it do its job after a short while of downtime, or quit it and wait yourself.

That's however not always the case, as in some situations Steam issues may not be detected by Steam Status, for example such case happened when Valve broke HTTPS support for Steam Community 7th June 2016 - accessing **[SteamCommunity](https://steamcommunity.com)** through HTTPS was throwing an error. Par conséquent, ne faites pas aveuglément confiance à Steam Status, il est préférable de vérifier vous-même si tout fonctionne comme prévu.

In addition to that, Steam includes various rate-limiting measures which will temporarily ban your IP if you make excessive number of requests at once. ASF is aware of that and offers you several different limiters in the config, which you should make use of. Default settings were tweaked based on **sane** amount of bots, if you're using so huge amount that even Steam is telling you to go away, then you either tweak them until it no longer tells you to, or you do as you're told. I assume second way is not an option to you, so go read on that topic and pay special attention to `WebLimiterDelay` which is a general limiter that applies to all web requests.

There is no "golden rule" that works for everybody, because blocks are heavily influenced by third-party factors, that's why you have to experiment yourself and find a value that works for you. You can also ignore what I say and use something like `10000` which is guaranteed to work correctly, but then don't complain how your ASF reacts to everything in 10 seconds and how badge parsing takes 5 minutes. In addition to that, it's entirely possible that no limiter will do anything because you have so huge amount of bots that you're hitting **[hard limit](#how-many-bots-can-i-run-with-asf)** that was mentioned above. Yes, it's entirely possible that you'll be able to log in without issues into Steam network (client), but Steam web (website) will refuse to listen to you if you have 100 sessions established at once. ASF requires both Steam network and Steam web to be cooperative, it takes just one down to make you issues you won't recover from.

If nothing helps and you have no clue what is broken, you can always enable `Debug` mode and see yourself in ASF log why exactly requests are failing. Par exemple :



```text
InternalRequest() HEAD https://steamcommunity.com/my/edit/settings
InternalRequest() Forbidden <- HEAD https://steamcommunity.com/my/edit/settings
```


See that `Forbidden` code? This means that you got temporarily banned for excessive amount of requests, because you didn't tweak `WebLimiterDelay` properly yet (assuming you get the same error code for all other requests as well). There could be other reasons listed there, such as `InternalServerError`, `ServiceUnavailable` and timeouts that indicate Steam maintenance/issues. Vous pouvez toujours essayer de visiter vous-même le lien mentionné par ASF et vérifier si cela fonctionne. Sinon, vous saurez pourquoi ASF ne peut pas y accéder. If it does, and the same error doesn't go away after a day or two, it may be worth investigating and reporting.

Avant de le faire, vous devez **vous assurer que l’erreur vaut la peine d’être signalée**. Si cela est mentionné dans cette FAQ, comme un problème lié au trading, alors c'est fini. S'il s'agit d'un problème temporaire qui s'est produit une ou deux fois, en particulier lorsque votre réseau était instable ou que Steam était en panne, le problème est résolu. Toutefois, si vous pouviez reproduire votre problème plusieurs fois de suite, pendant 2 jours, redémarrez ASF et votre machine au cours du processus et assurez-vous qu'il n'y a aucune entrée de FAQ dans cette section pour aider à le résoudre. Demander à propos de ce problème.



---



### ASF semble se figer et n'imprime rien sur la console tant que je n'ai pas appuyé sur une touche!

Vous utilisez probablement Windows et le mode QuickEdit de votre console est activé. Reportez-vous à **[cette](https://stackoverflow.com/questions/30418886/how-and-why-does-quickedit-mode-in-command-prompt-freeze-applications)** question sur StackOverflow pour obtenir des explications techniques. Vous devez désactiver le mode QuickEdit en cliquant avec le bouton droit de la souris sur la fenêtre de la console ASF, en ouvrant les propriétés et en décochant la case appropriée.



---



### ASF ne peut accepter ou envoyer de trades!

Ce qui est évident en premier - les nouveaux comptes commencent de manière limitée. Tant que vous n'avez pas déverrouillé le compte en chargeant son portefeuille ou en dépensant $5 dans le magasin, ASF ne peut accepter ni envoyer de transactions via ce compte. Dans ce cas, ASF indiquera que l'inventaire semble vide, car chaque carte qu'il contient est non échangeable.

Ensuite, si vous n'utilisez pas **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)**, il est possible qu'ASF ait effectivement accepté / envoyé un échange, mais vous devez le confirmer via votre adresse électronique. De même, si vous utilisez 2FA classique, vous devez confirmer le commerce via votre authentificateur. Les confirmations sont **obligatoires** maintenant. Si vous ne souhaitez pas les accepter par vous-même, envisagez d'importer votre authentificateur dans ASF 2FA.

Notez également que vous ne pouvez échanger qu'avec vos amis et les personnes ayant un lien commercial connu. If you're trying to initiate *Bot -> Master* trade, such as `loot`, then you need to either have your bot on your friendlist, or your `SteamTradeToken` declared in Bot's config. Make sure that the token is valid - otherwise, you won't be able to send a trade.

Enfin, rappelez-vous que les verrous commerciaux des nouveaux appareils sont verrouillés pendant 7 jours. Si vous venez d'ajouter votre compte à ASF, attendez au moins 7 jours. Tout devrait fonctionner après cette période. Cette limitation inclut ** les deux **accepter **et** envoyer les échanges. Cela ne déclenche pas toujours, et il y a des gens qui peuvent envoyer et accepter des transactions instantanément. La majorité des personnes sont toutefois affectées et le verrouillage ** se produira **, même si vous pouvez envoyer et accepter des transactions via votre client Steam sur le même ordinateur. Attendez patiemment, vous ne pouvez rien faire pour accélérer les choses. Likewise, you may get similar lock for removing/changing various Steam security-related settings, such as 2FA, SteamGuard, password, e-mail and likewise. In general, check if you can send a trade from that account yourself, if yes, very likely it's classic 7-days lock from new device.

Enfin, n'oubliez pas qu'un compte ne peut avoir que 5 transactions en attente sur un autre. ASF ne pourra donc pas envoyer de transactions si vous en avez déjà 5 (ou plus) en attente. C’est rarement un problème, mais il convient également de le mentionner, en particulier si vous définissez ASF pour l’envoi automatique d’opérations, alors que vous n’utilisez pas ASF 2FA et que vous avez oublié de les confirmer.

Si rien ne vous aide, vous pouvez toujours activer le mode `Débogage` et vérifier vous-même pourquoi les demandes échouent. Please note that Steam talks nonsense most of the time, and provided reason may not make any logical sense, or can be even entirely incorrect - if you decide to interpret that reason, make sure you have decent knowledge about Steam and its quirks. Il est également assez courant de voir ce problème sans raison logique, et la seule solution suggérée dans ce cas consiste à rajouter un compte à ASF (et à attendre 7 jours de plus). Parfois, ce problème se corrige également * comme par magie *, de la même manière qu'il se brise. Cependant, il s’agit généralement d’un blocage des échanges de 7 jours, d’un problème temporaire de steam ou des deux. Il est préférable de lui donner quelques jours avant de vérifier manuellement ce qui ne va pas, à moins que vous ne souhaitiez déboguer la cause réelle (et vous serez généralement obligé d'attendre de toute façon, car le message d'erreur n'aura aucun sens, ni ne vous aidera au moindre).

Dans tous les cas, ASF peut uniquement **essayer** d'envoyer une demande appropriée à Steam afin d'accepter / d'envoyer une transaction. Que Steam accepte ou non cette requête est hors de portée d'ASF, et ASF ne la fera pas fonctionner comme par magie. Il n'y a pas de bogue lié à cette fonctionnalité, et il n'y a rien à améliorer, car la logique se passe en dehors d'ASF. Par conséquent, ne demandez pas de matériel de réparation qui ne soit pas cassé, et ne demandez pas non plus pourquoi ASF ne peut accepter ou envoyer de transactions - ** je ne sais pas et ASF ne le sait pas non plus **. Either deal with it, or fix yourself, if you know better.



---



### Pourquoi dois-je mettre le code 2FA / Steam Guard à chaque connexion? / *Removed expired login key*

ASF utilise des clés de connexion (si vous maintenez `UseLoginKeys` activé) pour maintenir les informations d'identification valides, le même mécanisme que celui utilisé par Steam -  2FA / SteamGuard n'est requis qu'une seule fois. However, due to Steam network issues and quirks, it's entirely possible that login key is not saved in the network, we've already seen such issues not only with ASF, but with regular steam client as well (a need to input login + password on each run, regardless of "remember me" option).

You could remove `BotName.db` and `BotName.bin` (if available) of affected account and try to link ASF to your account once again, but that likely won't do anything. Some users have reported that **[deauthorizing all devices](https://store.steampowered.com/twofactor/manage)** on Steam side should help, changing password will do the same. However, those are only workarounds that are not even guaranteed to work, the real ASF-based solution is to import your authenticator as **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)** - this way ASF can generate tokens automatically when they're needed, and you don't have to input them manually. Habituellement, le problème se résout comme par magie après un certain temps, vous pouvez donc simplement attendre que cela se produise. Of course you can also ask Valve for solution, because I can't force Steam network to accept our login keys.

As a side note, you can also turn off login keys with `UseLoginKeys` config property set to `false`, but this will not solve the problem, only skip the initial login key failure. ASF is already aware of the issue explained here and will try its best to not use login keys if it can guarantee itself all login credentials, so there is no need to tweak `UseLoginKeys` manually if you can provide all login details together with using ASF 2FA.



---



### I'm getting error: *Unable to login to Steam: `InvalidPassword` or `RateLimitExceeded`*

Cette erreur peut signifier beaucoup de choses, parmi lesquelles:

- Combinaison login/mot de passe invalide (évidemment)
- Clé de connexion expirée utilisée par ASF pour se connecter
- Trop de tentatives de connexion infructueuses sur une courte période (anti-bruteforce)
- Trop de tentatives de connexion sur une courte période (limitation du débit)
- Obligation de captcha pour se connecter (très probablement pour deux raisons ci-dessus)
- Any other reason Steam Network may have preventing you from logging in

En cas d'anti-bruteforce et de limitation de débit, le problème disparaîtra au bout d'un certain temps, alors attendez et ne tentez pas de vous connecter entre-temps. Si vous rencontrez souvent ce problème, il est peut-être sage d'augmenter la propriété de configuration `LoginLimiterDelay` de ASF. Les redémarrages de programme excessifs et les autres demandes de connexion intentionnelles / non intentionnelles ne vous aideront certainement pas à résoudre ce problème, essayez donc de l'éviter si possible.

En cas d'expiration de la clé de connexion, ASF supprimera l'ancienne clé et en demandera une nouvelle lors de la prochaine connexion (ce qui vous demandera de mettre un jeton 2FA si votre compte est protégé par 2FA. Si votre compte utilise ASF 2FA, le jeton sera généré et utilisé automatiquement). This can naturally happen over time, but if you get this issue on each login, it's possible that Steam for some reason decided to ignore our login key save requests, as mentioned in the issue **[above](#why-do-i-have-to-put-2fasteamguard-code-on-each-login--removed-expired-login-key)**. You can of course disable `UseLoginKeys` entirely, but that won't solve the issue, only avoid a need of removing expired login keys each time. The real solution, as per the issue above, is to use ASF 2FA.

Et enfin, si vous avez utilisé une mauvaise combinaison login / mot de passe, vous devez évidemment le corriger ou désactiver le bot qui tente de se connecter à l'aide de ces informations d'identification. ASF ne peut pas déterminer par elle-même si `InvalidPassword` signifie des informations d'identification non valides ou l'une des raisons répertoriées ci-dessus. Par conséquent, il continuera d'essayer jusqu'à ce qu'il réussisse.

N'oubliez pas qu'ASF dispose de son propre système intégré pour réagir en conséquence aux aléas de steam. Elle finira par se connecter et reprendre son travail. Par conséquent, il n'est pas nécessaire de faire quoi que ce soit si le problème est temporaire. Redémarrer ASF afin de résoudre les problèmes comme par magie ne fera qu'aggraver les choses (comme les nouveaux ASF ne sauront pas l'état précédent d'ASF, à savoir ne pas pouvoir se connecter et essayer de se connecter au lieu d'attendre), évitez de le faire à moins que vous savez ce que vous faites.

Enfin, comme pour toute demande Steam - ASF ne peut que **essayer** de se connecter, en utilisant les informations d'identification fournies. Que cette demande aboutisse ou non est hors du champ d'application et de la logique d'ASF - il n'y a pas de bogue, et rien ne peut être corrigé ni amélioré à cet égard.



---



### `System.IO.IOException: Input/output error`

If this error happened during ASF input (e.g. you can see `Console.ReadLine()` in the stacktrace) then it's caused by your environment which prohibits ASF from reading standard input of your console. That can occur due to a lot of reasons, but the most common one is you running ASF in the wrong environment (e.g. in `nohup` or `&` background instead of `screen` on Linux). If ASF can't access its standard input, then you'll see this error logged and ASF's inability to use your details during runtime.

If you **expect** this to happen, so you **intend** to run ASF in input-less environment, then you should explicitly tell ASF that it's the case, by setting **[`Headless`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#headless)** mode appropriately. This will tell ASF to never ask for user input under any circumstance, allowing you to run ASF in input-less environments safely.



---



### `System.Net.Http.WinHttpException: A security error occurred`

Cette erreur se produit lorsque ASF ne peut pas établir de connexion sécurisée avec un serveur , presque exclusivement à cause de la méfiance du certificat SSL.

Dans presque tous les cas, cette erreur est provoquée par **une date/heure erronée sur votre ordinateur**. Chaque certificat SSL a une date d'émission et une date d'expiration. If your date is invalid and out of those two bounds then the certificate can't be trusted due to a potential **[MITM](https://en.wikipedia.org/wiki/Man-in-the-middle_attack)** attack and ASF refuses to make a connection.

La solution évidente consiste à régler correctement la date sur votre machine. Il est vivement recommandé d'utiliser la synchronisation automatique des dates, telle que la synchronisation native disponible sous Windows, ou `ntpd` sous Linux.

If you made sure that the date on your machine is appropriate and the error doesn't want to go away, SSL certificates that your system trusts could be out-of-date or invalid. Dans ce cas, vous devez vous assurer que votre ordinateur peut établir des connexions sécurisées, par exemple en vérifiant si vous pouvez accéder à `https://github.com` avec le navigateur de votre choix ou à un outil CLI tel que `curl`. Si vous avez confirmé que cela fonctionne correctement, n'hésitez pas à publier un numéro sur notre groupe Steam.



---



### `System.Threading.Tasks.TaskCanceledException: A task was canceled`

Cet avertissement signifie que Steam n'a pas répondu à la demande ASF dans le temps imparti. Généralement, cela est causé par le hoquet de réseau Steam et n'affecte en rien ASF. In other cases it's the same as request failing after 5 tries. Signaler ce problème n'a aucun sens la plupart du temps, car nous ne pouvons pas forcer Steam à répondre à nos demandes.



---



### `The type initializer for 'System.Security.Cryptography.CngKeyLite' threw an exception`

This problem is almost exclusively caused by disabled/stopped `CNG Key Isolation` Windows service, which provides core cryptography functionality for ASF, without which the program isn't able to run. You can fix this issue by launching `services.msc` and ensuring that `CNG Key Isolation` Windows service doesn't have disabled startup and is currently running.



---



### ASF est détecté comme un malware par mon antivirus! Que se passe-t-il ?

** Assurez-vous d'avoir téléchargé ASF à partir d'une source approuvée**. The only official and trusted source is **[ASF releases](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** page on GitHub (and this is also the source for ASF auto-updates) - **any other source is untrusted by definition and can contain malware added by other people** - you should not trust any other download location by definition, and ensure that your ASF always comes from us.

Si vous confirmez qu'ASF est téléchargé à partir d'une source approuvée, il s'agit très probablement d'un faux positif. Cela **s'est produit dans le passé**, **se produit actuellement** et **se produira dans le futur**. Si vous êtes préoccupé par la sécurité lors de l'utilisation d'ASF, je vous suggère d'analyser ce dernier avec différents outils de détection, par exemple via **[VirusTotal](https://www.virustotal.com)** (ou tout autre service Web de votre choix).

Si le AV que vous utilisez détecte faussement ASF en tant que programme malveillant, alors ** il est judicieux de renvoyer cet exemple de fichier aux développeurs de votre système audiovisuel afin qu'ils puissent l'analyser et améliorer leur moteur de détection **, aussi clairement que cela ne fonctionne pas aussi bien que vous le pensez. Il n’ya pas de problème dans le code ASF, et il n’y a rien non plus à résoudre pour nous, puisque nous ne distribuons pas de logiciels malveillants au départ, il n’a donc aucun sens de nous signaler ces faux positifs. Nous vous recommandons vivement d’envoyer un échantillon ASF pour une analyse plus approfondie, comme indiqué ci-dessus, mais si vous ne voulez pas vous en soucier, vous pouvez toujours ajouter ASF à une sorte d’exception AV, désactivez votre AV ou utilisez-en simplement un autre. Malheureusement, nous sommes habitués à ce que les antivirus soient stupides, car certains détectent de temps à autre ASF comme un virus, qui dure généralement très peu de temps et qui est rapidement corrigé par les développeurs, mais comme nous l’avons souligné plus haut - ** il est arrivé **, ** arrive ** et ** se produira ** tout le temps. ASF n'inclut pas de code malveillant, vous pouvez le réviser et même le compiler vous-même à la source. Nous ne sommes pas des hackers pour obscurcir le code ASF afin de cacher les heuristiques AV et les faux positifs, alors n'attendez pas de nous pour réparer ce qui n'est pas cassé - il n'y a pas de "virus" à réparer.