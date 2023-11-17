# Activateur de jeux en arrière-plan

L'activateur de jeux en arrière-plan est une fonction spéciale intégrée à ASF vous permettant d'importer un groupe donné de clés cd Steam (avec leurs noms) à activer en tâche de fond. C'est particulièrement pratique si vous disposez d'un grand nombre de clés à activer, et que vous êtes certain d'atteindre le `RateLimited` **[status](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#what-is-the-meaning-of-status-when-redeeming-a-key)** avant d'avoir fini de toutes les activer.

L'activateur de jeux en arrière-plan est conçu pour n'utiliser qu'une seule commande de bot, et donc n'utilise pas `RedeemingPreferences`. Cette fonction peut être utilisée en même temps que (ou à la place de) **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**`redeem`, si besoin est.

---

## Import

Le processus d'importation peut être effectué de deux façons - par fichier, ou par IPC.

### Fichier

ASF peut reconnaître dans son répertoire `config` un fichier nommé `BotName.keys`, où `BotName` est le nom de votre bot. Le formatage de ce fichier est important, et consiste du nom du jeu suivi de la clé Cd, séparés par une tabulation et se terminant par un retour à la ligne. Si plusieurs onglets sont utilisés, la première entrée est considérée comme étant le nom du jeu, la dernière entrée est considérée comme étant une clé cd, et tout ce qui est entre les deux est ignoré. Par exemple :

```text
POSTAL 2    ABCDE-EFGHJ-IJKLM
Domino Craft VR 12345-67890-ZXCVB
A Week of Circus Terror POIUY-KJHGD-QWERT
Terraria    Ceciestignoré   Ceciestaussiignoré    ZXCVB-ASDFG-QWERT
```

Alternativement, vous pouvez aussi utiliser le format clés seulement (toujours avec une nouvelle ligne entre chaque entrée). ASF dans ce cas utilisera la réponse de Steam (si possible) pour trouver le nom correct. Pour toute association de nom de jeu aux clés Steam, nous vous recommandons de nommer vos clés vous-même, puisque les paquets activés sur Steam ne contiennent pas cette information de façon certaine. Suivant l'information que le développeur a renseignée, vous pouvez voir les noms de jeu corrects, les noms de paquets personnalisés (par exemple Humble Indie Bundle 18) ou bien des noms faux et même potentiellement malveillants (par exemple Half-Life 4).

```text
ABCDE-EFGHJ-IJKLM
12345-67890-ZXCVB
POIUY-KJHGD-QWERT
ZXCVB-ASDFG-QWERT
```

Quel que soit le format que vous avez choisi, ASF importera votre fichier de `keys` soit au démarrage du bot, soit plus tard lors de l'exécution. Une fois le fichier analysé et les éventuelles entrées invalides omises, tous les jeux correctement détectés seront ajoutés à la file d'attente en arrière-plan, et le fichier `BotName.keys` sera retiré du répertoire `config`.

### IPC

En plus d'utiliser le fichier de clés mentionné ci dessus, ASF expose égalementle`GamesToRedeemInBackground` **[API ASF](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-api)** pouvant être exécuté par n'importe quel outil IPC, y compris notre ASF-ui. L'utilisation d'IPC est plus efficace car vous pouvez effectuer une meilleure analyse par vous-même, par exemple en utilisant un délimiteur personnalisé au lieu d'utiliser forcément une tabulation.

---

## File d'attente

Une fois les jeux importés, ils sont ajoutés à la file d'attente. ASF parcourt automatiquement sa file d'attente en arrière-plan tant que le bot est connecté au réseau Steam, et tant que la file d'attente n'est pas vide. Une clé qui tente d'être activée sans résulter en `RateLimited` est retirée de la file d'attente, avec son statut rédigé correctement dans un fichier dans le répertoire `config` - soit `BotName.keys.used` si la clé a été utilisée durant le processus (par exemple `NoDetail`, `BadActivationCode`, `DuplicateActivationCode`), sinon dans `BotName.keys.unused`. ASF utilise intentionnellement le nom du jeu que vous fournissez, car la clé n'a pas forcément de nom valable fourni par le réseau Steam - vous pouvez ainsi marquer vos clés avec des noms personnalisés si besoin est/si vous le désirez.

Si notre compte atteint le statut `RateLimited` durant le processus, la file d'attente est suspendue temporairement pendant une heure entière, jusqu'à la fin du délai d'attente. Afterwards, the process continues where it left, until the entire queue is empty or another `RateLimited` occurs.

---

## Exemple

Considérons que vous avez une liste de 100 clés. Tout d'abord, vous devez créer un fichier `BotName.keys.new` dans le répertoire `config` d'ASF. Nous ajoutons l'extension `.new` pour qu'ASF sache qu'il ne doit pas récupérer ce fichier dès sa création (car c'est un fichier vide, pas encore prêt à l'importation).

Maintenant, nous pouvons ouvrir notre nouveau fichier et copier-coller notre liste de 100 clés dedans, en réglant le format si besoin est. Après nos réglages, le fichier `BotName.keys.new` aura exactement 100 (ou 101, avec le dernier retour à la ligne) lignes, chaque ligne ayant une structure de `GameName\tcd-key\n`, où `\t` correspond à une tabulation et `\n` à un retour à la ligne.

Vous êtes maintenant prêt à renommer ce fichier de `BotName.keys.new` à `BotName.keys` afin d'indiquer à ASF qu'il est prêt à être récupéré. Dès que vous le ferez, ASF importera automatiquement le fichier (sans qu'il soit nécessaire de le redémarrer) et le supprimera par la suite, confirmant que tous nos jeux ont été analysés et ajoutés à la file d'attente.

Au lieu d'utiliser le fichier `BotName.keys`, vous pouvez également utiliser le point de terminaison de l'API IPC, ou même combiner les deux si vous le souhaitez.

Après un certain temps, les fichiers `BotName.keys.used` et `BotName.keys.unused` seront créés. Ces fichiers contiennent les résultats de notre processus. Par exemple, vous pouvez renommer `BotName.keys.unused` en `fichier BotName2.keys` et donc soumettre nos clés inutilisées à un autre bot, car le bot précédent ne l'utilisait pas ces clés lui-même. Ou vous pouvez simplement copier-coller les clés inutilisées dans un autre fichier et le conserver pour plus tard. Gardez à l'esprit qu'au fur et à mesure que ASF traverse la file d'attente, de nouvelles entrées seront ajoutées à nos fichiers de sortie `used` et `unused`. Il est donc recommandé d'attendre que la file d'attente soit entièrement vidée. avant de les utiliser. Si vous devez absolument accéder à ces fichiers avant que la file d’attente ne soit complètement vidée, vous devez d’abord **déplacer** le fichier de sortie auquel vous souhaitez accéder dans un autre répertoire, **puis** l’analyser. En effet, ASF peut ajouter de nouveaux résultats pendant que vous faites votre travail, ce qui pourrait éventuellement entraîner la perte de certaines clés si vous lisiez un fichier contenant, par exemple, des fichiers. 3 clés à l’intérieur, puis supprimez-le, en omettant totalement le fait que ASF a ajouté 4 autres clés à votre fichier supprimé entre-temps. Si vous souhaitez accéder à ces fichiers, veillez à les éloigner du répertoire ASF `config` avant de les lire, par exemple en les renommant.

Il est également possible d'ajouter des jeux supplémentaires à importer tout en ayant certains jeux déjà dans notre file d'attente, en répétant toutes les étapes ci-dessus. ASF ajoutera correctement nos entrées supplémentaires à la file d'attente déjà en cours et en traitera éventuellement.

---

## Remarques

L'activateur de clés en arrière-plan utilise `OrderedDictionary`, ce qui signifie que vos clés cd auront conservé leur ordre telles qu'elles ont été spécifiées dans le fichier (ou l'appel de l'API IPC). Cela signifie que vous pouvez (et devriez) fournir une liste où les clés cd ne peuvent avoir que des dépendances directes sur les clés cd listées au-dessus, mais pas au-dessous. Par exemple, cela signifie que si le DLC `D` requiert que le jeu `G` soit d'abord activé, la clé pour le jeu `G` doit ** toujours ** être inclus avant la clé cd pour le DLC `D`. De même, si DLC `D` aurait des dépendances sur `A`, `B` et `C`, toutes les 3 devraient être incluses avant (dans n'importe quel ordre, à moins qu'ils n'aient des dépendances).

Si vous ne suivez pas le schéma ci-dessus, votre DLC ne sera pas activé avec `DoesNotOwnRequiredApp`, même si votre compte aurait le droit de l'activer après avoir parcouru toute sa file d'attente. Si vous voulez éviter cela, vous devez vous assurer que votre DLC est toujours inclus après le jeu de base dans votre file d'attente.