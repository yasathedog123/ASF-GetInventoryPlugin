# Journalisation

ASF vous permet de configurer votre propre module de connexion personnalisé qui sera utilisé pendant l'exécution. Vous pouvez le faire en plaçant un fichier spécial nommé ` NLog.config` dans le répertoire de l’application. Vous pouvez lire la documentation complète de NLog sur **[ NLog wiki ](https://github.com/NLog/NLog/wiki/Configuration-file)**, mais vous y trouverez également des exemples utiles.

---

## Authentification par défaut

By default, ASF is logging to `ColoredConsole` (standard output) and `File`. `File` logging includes `log.txt` file in program's directory, and `logs` directory for archival purposes.

Using custom NLog config automatically disables default ASF config, your config overrides **completely** default ASF logging, which means that if you want to keep e.g. our `ColoredConsole` target, then you must define it **yourself**. Cela vous permet non seulement d'ajouter des ** extra** cibles d'authentification, mais également de désactiver ou de modifier **les cibles par défaut**.

Si vous souhaitez utiliser l'authentification ASF par défaut sans aucune modification, vous n'avez rien à faire: vous n'avez pas non plus besoin de la définir dans la personnalisation `NLog.config`. N'utilisez pas la personnalisation `NLog.config` si vous ne souhaitez pas modifier l'authentification ASF par défaut. Pour référence cependant, l’équivalent de l'authentification ASF codée en dur serait:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" layout="${date:format=yyyy-MM-dd HH\:mm\:ss}|${processname}-${processid}|${level:uppercase=true}|${logger}|${message}${onexception:inner= ${exception:format=toString,Data}}" />
    <target xsi:type="File" name="File" archiveFileName="${currentdir}/logs/log.{#}.txt" archiveNumbering="Rolling" archiveOldFileOnStartup="true" cleanupFileName="false" concurrentWrites="false" deleteOldFileOnStartup="true" fileName="${currentdir}/log.txt" layout="${date:format=yyyy-MM-dd HH\:mm\:ss}|${processname}-${processid}|${level:uppercase=true}|${logger}|${message}${onexception:inner= ${exception:format=toString,Data}}" maxArchiveFiles="10" />

    <!-- Below becomes active when ASF's IPC interface is started -->
    <target type="History" name="History" layout="${date:format=yyyy-MM-dd HH\:mm\:ss}|${processname}-${processid}|${level:uppercase=true}|${logger}|${message}${onexception:inner= ${exception:format=toString,Data}}" maxCount="20" />
  </targets>

  <rules>
    <!-- The following entries specify ASP.NET (IPC) logging, we declare those so our last Debug catch-all doesn't include ASP.NET logs by default -->
    <logger name="Microsoft.*" finalMinLevel="Warn" writeTo="ColoredConsole" />
    <logger name="Microsoft.Hosting.Lifetime" finalMinLevel="Info" writeTo="ColoredConsole" />
    <logger name="System.*" finalMinLevel="Warn" writeTo="ColoredConsole" />

    <logger name="*" minlevel="Debug" writeTo="ColoredConsole" />

    <!-- The following entries specify ASP.NET (IPC) logging, we declare those so our last Debug catch-all doesn't include ASP.NET logs by default -->
    <logger name="Microsoft.*" finalMinLevel="Warn" writeTo="File" />
    <logger name="Microsoft.Hosting.Lifetime" finalMinLevel="Info" writeTo="File" />
    <logger name="System.*" finalMinLevel="Warn" writeTo="File" />

    <logger name="*" minlevel="Debug" writeTo="File" />

    <!-- Below becomes active when ASF's IPC interface is enabled -->
    <!-- The following entries specify ASP.NET (IPC) logging, we declare those so our last Debug catch-all doesn't include ASP.NET logs by default -->
    <logger name="Microsoft.*" finalMinLevel="Warn" writeTo="History" />
    <logger name="Microsoft.Hosting.Lifetime" finalMinLevel="Info" writeTo="History" />
    <logger name="System.*" finalMinLevel="Warn" writeTo="History" />

    <logger name="*" minlevel="Debug" writeTo="History" />
  </rules>
</nlog>
```

---

## ASF intégration

ASF inclut quelques astuces de code qui améliorent son intégration à NLog, vous permettant de capturer plus facilement des messages spécifiques.

La variable `${logger}` spécifique à NLog distinguera toujours la source du message - ce sera soit ` BotName` de l'un de vos bots, ou ` ASF` si le message provient directement du processus ASF. De cette façon, vous pouvez facilement intercepter des messages tenant compte de bots spécifiques ou de processus ASF (uniquement), et non de tous, en fonction du nom de l'enregistreur.

ASF tries to mark messages appropriately based on NLog-provided logging levels, which makes it possible for you to catch only specific messages from specific log levels instead of all of them. Bien sûr, le niveau d'authentification pour un message spécifique ne peut pas être personnalisé, car ASF décide clairement à quel point un message est sérieux, mais vous pouvez certainement rendre ASF moins / plus silencieux, comme bon vous semble.

ASF enregistre des informations supplémentaires, telles que des messages de l’utilisateur/discussion sur le niveau dâuthentification de `suivi`. L'authentification ASF par défaut ne consigne que les niveaux ` Debug` et supérieurs, masquant ces informations supplémentaires car inutiles pour la majorité des utilisateurs, ainsi qu'une sortie encombrante contenant des messages potentiellement plus importants. Vous pouvez toutefois utiliser ces informations en réactivant le niveau d'authentification ` suivi`, en particulier en combinaison avec l'authentification d'un seul bot spécifique de votre choix, avec l'événement particulier qui vous intéresse.

En général, ASF essaie de vous rendre aussi facile et pratique que possible de consigner uniquement les messages souhaités au lieu de vous forcer à les filtrer manuellement au moyen d’outils tiers tels que `grep` et autres. Configurez simplement NLog correctement, comme indiqué ci-dessous, et vous devriez pouvoir spécifier des règles d'authentification même très complexes avec des cibles personnalisées telles que des bases de données complètes.

En ce qui concerne la gestion des versions - ASF essaie de toujours utiliser la version la plus récente de NLog disponible sur **[ NuGet](https://www.nuget.org/packages/NLog)** au moment de la publication d'ASF. It should not be a problem to use any feature you can find on NLog wiki in ASF - just make sure you're also using up-to-date ASF.

Dans le cadre de l'intégration ASF, ASF prend également en charge d'autres cibles d'authentification ASF NLog, qui seront expliquées ci-dessous.

---

## Exemples

Commençons par quelque chose de facile. Nous allons utiliser la cible **[ColoredConsole](https://github.com/nlog/nlog/wiki/ColoredConsole-target)** uniquement. uniquement. Notre `NLog.config` initial ressemblera à ceci:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" />
  </targets>

  <rules>
    <logger name="*" minlevel="Debug" writeTo="ColoredConsole" />
  </rules>
</nlog>
```

L’explication de la configuration ci-dessus est assez simple: nous définissons une **cible de journalisation**, qui est  `ColoredConsole`, puis nous redirigeons **tous les enregistreurs** (`*`) de niveau `Debug`  et supérieur à la `ColoredConsole` définie précédemment. C'est tout.

Si vous démarrez ASF avec `NLog.config` ci-dessus, seule la cible `ColoredConsole` sera active et ASF n'écrira pas dans le `Fichier`, indépendamment de configuration ASF NLog codée en dur.

Maintenant, disons que nous n'aimons pas le format par défaut de `${longdate}|${level:uppercase=true}|${logger}|${message}` et nous voulons enregistrer le message uniquement. Nous pouvons le faire en modifiant **[Layout](https://github.com/nlog/nlog/wiki/Layouts)** de notre cible.

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" layout="${message}" />
  </targets>

  <rules>
    <logger name="*" minlevel="Debug" writeTo="ColoredConsole" />
  </rules>
</nlog>
```

Si vous lancez ASF maintenant, vous remarquerez que la date, le niveau et le nom de l'enregistreur ont disparu - vous laissant uniquement des messages ASF au format `Function() Message`.

Nous pouvons également modifier la configuration pour vous connecter à plusieurs cibles. Let's log to `ColoredConsole` and **[`File`](https://github.com/nlog/nlog/wiki/File-target)** at the same time.

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" />
    <target xsi:type="File" name="File" fileName="${currentdir}/NLog.txt" deleteOldFileOnStartup="true" />
  </targets>

  <rules>
    <logger name="*" minlevel="Debug" writeTo="ColoredConsole" />
    <logger name="*" minlevel="Debug" writeTo="File" />
  </rules>
</nlog>
```

Une fois fait, nous allons maintenant tout enregistrer dans  `ColoredConsole` et `File`. Avez-vous remarqué que vous pouvez également spécifier des options personnalisées `fileName` et des options supplémentaires ?

Enfin, ASF utilise différents niveaux de journalisation pour vous aider à comprendre ce qui se passe. Nous pouvons utiliser ces informations pour modifier la sévérité de la journalisation. Let's say that we want to log everything (`Trace`) to `File`, but only `Warning` and above **[log level](https://github.com/NLog/NLog/wiki/Configuration-file#log-levels)** to the `ColoredConsole`. Nous pouvons y parvenir en modifiant nos `règles`:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" />
    <target xsi:type="File" name="File" fileName="${currentdir}/NLog.txt" deleteOldFileOnStartup="true" />
  </targets>

  <rules>
    <logger name="*" minlevel="Warn" writeTo="ColoredConsole" />
    <logger name="*" minlevel="Trace" writeTo="File" />
  </rules>
</nlog>
```

Voilà, notre `ColoredConsole` n’affiche plus que les avertissements et plus, tout en enregistrant tout dans `File`. Vous pouvez le modifier davantage pour vous connecter, par exemple. uniquement `Info` et inférieur, etc.

Enfin, faites quelque chose d'un peu plus avancé et enregistrons tous les messages dans un fichier, mais seulement à partir du bot `LogBot`.

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" />
    <target xsi:type="File" name="LogBotFile" fileName="${currentdir}/LogBot.txt" deleteOldFileOnStartup="true" />
  </targets>

  <rules>
    <logger name="*" minlevel="Debug" writeTo="ColoredConsole" />
    <logger name="LogBot" minlevel="Trace" writeTo="LogBotFile" />
  </rules>
</nlog>
```

Vous pouvez voir comment nous avons utilisé l'intégration ASF ci-dessus et distinguer facilement la source du message en fonction de la propriété `${logger}`.

---

## Utilisation avancée

Les exemples ci-dessus sont plutôt simples et conçus pour vous montrer à quel point il est facile de définir vos propres règles de journalisation pouvant être utilisées avec ASF. Vous pouvez utiliser NLog pour différentes choses, y compris des cibles complexes (telles que la conservation des journaux dans `DataBase`), la rotation des journaux (telle que la suppression des anciens journaux `File`), à l'aide de la personnalisation `Layout `, déclarant vos propres filtres `<when>` de journalisation et bien plus encore. Je vous encourage à lire toute la **[documentation  NLog](https://github.com/nlog/nlog/wiki/Configuration-file)** pour connaître toutes les options disponibles, ce qui vous permettra d'ajuster avec précision la fonctionnalité de journalisation ASF. C'est un outil vraiment puissant et la personnalisation de la journalisation ASF n'a jamais été aussi simple.

---

## Limites

ASF désactivera temporairement **all** règles incluant des cibles ` <code>ColoredConsole` ou <1>Console</code> lors de l'attente de la saisie de l'utilisateur. Par conséquent, si vous souhaitez conserver la journalisation pour d'autres cibles même lorsque ASF attend une entrée de l'utilisateur, vous devez définir ces cibles avec leurs propres règles, comme indiqué dans les exemples ci-dessus, au lieu de mettre plusieurs cibles dans `writeTo` de la même règle (à moins qu'il ne s'agisse de votre comportement souhaité). La désactivation temporaire des cibles de la console est effectuée afin de garder la console propre pendant l'attente de la saisie de l'utilisateur.

---

## Connexion au tchat

ASF inclut une prise en charge étendue de la journalisation du tchat en enregistrant non seulement tous les messages reçus / envoyés sur le niveau de journalisation `Trace`, mais également en exposant des informations supplémentaires les concernant dans les **[propriétés d'événement](https://github.com/NLog/NLog/wiki/EventProperties-Layout-Renderer)**. Ceci est dû au fait que nous devons tout de même gérer les messages de discussion en tant que commandes. Par conséquent, nous ne devons rien payer pour consigner ces événements afin de vous permettre d'ajouter une logique supplémentaire (par exemple, faire d'ASF votre archive personnelle de discussion Steam).

### Propriétés

| Nom         | Description                                                                                                                                                                                                                                                        |
| ----------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| Écho        | `bool` type. Ce paramètre est défini sur `true` lorsque nous envoyons un message au destinataire et sur `false` dans le cas contraire.                                                                                                                             |
| Message     | `string` type. C'est le message actuellement envoyé/reçu.                                                                                                                                                                                                          |
| ChatGroupID | `ulong` type. C'est l'ID du groupe de discussion pour les messages envoyés/reçus. La valeur sera `0` lorsque aucune discussion de groupe n'est utilisée pour transmettre ce message.                                                                               |
| ChatID      | `ulong` type. Il s’agit de l’ID du channel `ChatGroupID` pour les messages envoyés /reçus. La valeur sera `0` lorsque aucune discussion de groupe n'est utilisée pour transmettre ce message.                                                                      |
| SteamID     | `ulong` type. Ceci est l'ID de l'utilisateur Steam pour les messages envoyés/reçus. Peut être `0` lorsque aucun utilisateur particulier n'est impliqué dans la transmission du message (par exemple, lorsque nous envoyons un message à une discussion de groupe). |

### Exemple

Cet exemple est basé sur notre exemple de base `ColoredConsole` ci-dessus. Avant d'essayer de le comprendre, je vous recommande vivement de jeter un coup d'oeil **[ci-dessus](#examples)** afin de vous familiariser d'abord avec les bases de la journalisation NLog.

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" />
    <target xsi:type="File" name="ChatLogFile" fileName="${currentdir}/${event-properties:item=ChatGroupID}-${event-properties:item=ChatID}${when:when='${event-properties:item=ChatGroupID}' == 0:inner=-${event-properties:item=SteamID}}.txt" layout="${date:format=yyyy-MM-dd HH\:mm\:ss} ${event-properties:item=Message} ${when:when='${event-properties:item=Echo}' == true:inner=-&gt;:else=&lt;-} ${event-properties:item=SteamID}" />
  </targets>

  <rules>
    <logger name="*" minlevel="Debug" writeTo="ColoredConsole" />
    <logger name="MainAccount" level="Trace" writeTo="ChatLogFile">
      <filters defaultAction="Log">
        <when condition="not starts-with('${message}','OnIncoming') and not starts-with('${message}','SendMessage')" action="Ignore" />
      </filters>
    </logger>
  </rules>
</nlog>
```

Nous avons commencé notre exemple de base `ColoredConsole` et l'avons étendu. Tout d’abord, nous avons préparé un fichier journal de discussion pour chaque canal de groupe et chaque utilisateur de Steam. C’est possible grâce aux propriétés supplémentaires que ASF nous expose de manière élégante. Nous avons également décidé d’utiliser une disposition personnalisée qui n’écrit que la date du jour, le message, les informations envoyées / reçues et l’utilisateur Steam lui-même. Enfin, nous avons activé notre règle de journalisation de discussion uniquement pour le niveau `Trace`, uniquement pour notre bot `MaiinAccount` et uniquement pour les fonctions liées à la journalisation de discussion (`OnIncoming*` utilisé pour recevoir des messages et des échos et `SendMessage*` pour l’envoi de messages ASF).

The example above will generate `0-0-76561198069026042.txt` file when talking with **[ArchiBot](https://steamcommunity.com/profiles/76561198069026042)**:

```text
2018-07-26 01:38:38 2018-07-26 01:38:38 comment allez-vous? -> 76561198069026042
2018-07-26 01:38:38 I'm doing great, how about you? <- 76561198069026042

```

Bien sûr, ce n’est qu’un exemple avec quelques astuces de mise en page bien présentées de manière pratique. Vous pouvez étendre cette idée à vos propres besoins, tels que filtrage supplémentaire, ordre personnalisé, mise en page personnelle, enregistrement uniquement des messages reçus, etc.

---

## ASF targets

En plus des cibles de journalisation NLog standard (telles que ` ColoredConsole` et `Fichier` expliquées ci-dessus), vous pouvez également utiliser des cibles de journalisation ASF personnalisées.

Pour une complétude maximale, la définition des cibles ASF suivra la convention de documentation NLog.

---

### SteamTarget

Comme vous pouvez le deviner, cette cible utilise des messages de discussion Steam pour la journalisation des messages ASF. Vous pouvez le configurer pour utiliser une discussion de groupe ou une discussion privée. En plus de spécifier une cible Steam pour vos messages, vous pouvez également spécifier `botName` correspondant au bot qui est censé les envoyer.

Pris en charge dans tous les environnements utilisés par ASF.

---

#### Syntaxe de configuration
```xml
<targets>
  <target type="Steam"
          name="String"
          layout="Layout"
          chatGroupID="Ulong"
          steamID="Ulong"
          botName="Layout" />
</targets>
```

En savoir plus sur l’utilisation du [fichier de configuration](https://github.com/NLog/NLog/wiki/Configuration-file).

---

#### Paramètres

##### Options Générales
_Nom_ - Nom de la cible.

---

##### Options de mise en page
_layout_ - Texte à restituer. [Mise en page](https://github.com/NLog/NLog/wiki/Layouts) Obligatoire. Par défaut : `${level:uppercase=true}|${logger}|${message}`

---

##### Options SteamTarget

_chatGroupID_ - ID du groupe de discussion déclaré en tant qu'entier non signé en 64 bits. Non requis. La valeur par défaut est `0`, ce qui désactivera la fonctionnalité de discussion en groupe et utilisera la discussion privée. Lorsqu'elle est activée (définie sur une valeur autre que zéro), la fonctionnalité `steamID` ci-dessous agit en tant que `chatID` et spécifie l'ID du canal dans ce `chatGroupID</ 0> ou le bot devrait envoyer des messages.</p>

<p spaces-before="0"><em x-id="4">steamID</em> - SteamID déclaré comme non signé en 64 bits par l'utilisateur Steam cible (comme <code>SteamOwnerID`) ou la cible `chatID</ > (lorsque <code>chatGroupID` est défini). Obligatoire. Defaults to `0` which disables logging target entirely.

_botName_ - Name of the bot (as it's recognized by ASF, case-sensitive) that will be sending messages to `steamID` declared above. Non requis. La valeur par défaut est `null`, ce qui sélectionne automatiquement **n'importe quel** bot actuellement connecté. Il est recommandé de définir cette valeur correctement, car `SteamTarget` ne prend pas en compte de nombreuses limitations de Steam, telles que le fait que vous devez avoir `steamID` de la cible dans votre liste d'amis. This variable is defined as [layout](https://github.com/NLog/NLog/wiki/Layouts) type, therefore you can use special syntax in it, such as `${logger}` in order to use the bot that generated the message.

---

#### Exemples SteamTarget

Pour écrire tous les messages de niveau `Debug` et supérieur, du bot `MyBot` au steamID de `76561198006963719`, vous devez utiliser `NLog.config` similaire à ci-dessous:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target type="Steam" name="Steam" steamID="76561198006963719" botName="MyBot" />
  </targets>

  <rules>
    <logger name="*" minlevel="Debug" writeTo="Steam" />
  </rules>
</nlog>
```

**Remarque:** Notre `SteamTarget` est une cible personnalisée. Par conséquent, assurez-vous de le déclarer comme `type="Steam"`, PAS `xsi:type="Steam"`, car xsi est réservé aux cibles officielles supportées par NLog.

Lorsque vous lancez ASF avec `NLog.config` comme ci-dessus, `MyBot` lance la messagerie `76561198006963719` avec tous les messages du journal ASF habituels. N'oubliez pas que `MyBot` doit être connecté pour que vous puissiez envoyer des messages. Ainsi, tous les messages ASF initiaux qui se sont produits avant que notre bot puisse se connecter au réseau Steam ne seront pas transférés.

Bien entendu, `SteamTarget` contient toutes les fonctions habituelles d’un générique `TargetWithLayout`. Vous pouvez donc l’utiliser conjointement avec par exemple des dispositions personnalisées, noms ou règles de journalisation avancées. L'exemple ci-dessus n'est que le plus fondamental.

---

#### Captures d'écran

![Capture d"écran](https://i.imgur.com/5juKHMt.png)

---

### HistoryTarget

ASF utilise cette cible en interne pour fournir un historique de journalisation de taille fixe dans le point de terminaison `/Api/NLog` de **[API ASF](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-api)**, qui peut ensuite être utilisé par ASF-ui et d'autres outils. En général, vous ne devez définir cette cible que si vous utilisez déjà la configuration personnalisée NLog pour d’autres personnalisations et si vous souhaitez également que le journal soit exposé dans l’API ASF, par exemple. pour ASF-ui. Il peut également être déclaré lorsque vous souhaitez modifier la présentation par défaut ou `maxCount` des messages enregistrés.

Pris en charge dans tous les environnements utilisés par ASF.

---

#### Syntaxe de configuration
```xml
<targets>
  <target type="History"
          name="String"
          layout="Layout"
          maxCount="Byte" />
</targets>
```

En savoir plus sur l’utilisation du [fichier de configuration](https://github.com/NLog/NLog/wiki/Configuration-file).

---

#### Paramètres

##### Options Générales
_Nom_ - Nom de la cible.

---

##### Options de mise en page
_layout_ - Texte à restituer. [Mise en page](https://github.com/NLog/NLog/wiki/Layouts) Obligatoire. Default: `${date:format=yyyy-MM-dd HH\:mm\:ss}|${processname}-${processid}|${level:uppercase=true}|${logger}|${message}${onexception:inner= ${exception:format=toString,Data}}`

---

##### Options HistoryTarget

_maxCount_ - Nombre maximal de journaux stockés pour l'historique à la demande. Non requis. La valeur par défaut est `20`, ce qui constitue un bon équilibre pour fournir l'historique initial, tout en gardant à l'esprit l'utilisation de la mémoire qui  correspond aux exigences de stockage. Doit être supérieur à `0`.

---

## Mises en garde

Soyez prudent lorsque vous décidez d'associer le niveau de journalisation `Debug` ou inférieur dans votre `SteamTarget` avec `steamID` qui participe au processus ASF. Cela peut entraîner une `StackOverflowException` potentielle, car vous créerez une boucle infinie d'ASF recevant un message , que vous enregistrerez ensuite via Steam, ce qui créera un autre message qui doit être connecté. Actuellement, la seule possibilité est que vous enregistriez le niveau de traçage `Trace` (ASF enregistre ses propres messages de discussion à cette endroit) ou le niveau `Debug` tout en exécutant ASF dans le mode `Debug`  (ASF enregistre tous les paquets Steamà cette endroit).

En bref, si votre `steamID` participe au même processus ASF, le niveau de journalisation `minlevel` de votre `SteamTarget` doit être `Info` (ou `Debug` si vous n'exécutez pas non plus ASF en mode `Debug`) et supérieur. Vous pouvez également définir vos propres filtres de journalisation `<when>` afin d'éviter une boucle de journalisation infinie, si la modification actuelle n'est pas appropriée pour votre cas. Cette mise en garde s'applique également aux discussions de groupe.