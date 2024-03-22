# Arguments de ligne de commande

ASF prend en charge plusieurs arguments de ligne de commande qui peuvent affecter l’exécution du programme. Ils peuvent être utilisés par des utilisateurs avancés pour spécifier au programme son mode de fonctionnement. Par rapport au fichier de configuration `ASF.json` par défaut, les arguments de ligne de commande sont utilisés pour l'initialisation principale (e.g. `--path`). paramètres spécifiques à la plate-forme (e.g. `--system-required`) ou données sensibles (e.g. `--cryptkey`).

---

## Utilisation

Son utilisation dépend de votre OS et ASF.

Générique :

```shell
dotnet ArchiSteamFarm.dll --argument --otherOne
```

Windows :

```powershell
.\ArchiSteamFarm.exe --argument --otherOne
```

Linux/macOS:

```shell
./ArchiSteamFarm --argument --otherOne
```

Les arguments de ligne de commande sont également pris en charge dans les scripts d'assistance génériques tels que ` ArchiSteamFarm.cmd </ 0> ou <code> ArchiSteamFarm.sh </ 0>. In addition to that, you can also use <code>ASF_ARGS` environment property, like stated in our **[management](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#environment-variables)** and **[docker](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Docker#command-line-arguments)** sections.

Si votre argument comprend des espaces, n'oubliez pas de le citer. Ces deux exemples sont faux:

```shell
./ArchiSteamFarm --path /home/archi/My Downloads/ASF # Bad
./ArchiSteamFarm --path=/home/archi/My Downloads/ASF # Bad!
```

Cependant, ces deux la sont complètement valides:

```shell
./ArchiSteamFarm --path "/home/archi/My Downloads/ASF" # OK
./ArchiSteamFarm "--path=/home/archi/My Downloads/ASF" # OK
```

## Arguments

`--cryptkey <key>` ou `--cryptkey=<key>` - démarrera ASF avec une clé cryptographique personnalisée de la valeur `<key>`. Cette option affecte la **

 sécurité </ 0> et obligera ASF à utiliser votre clé `<key>` fournie à la place de la clé par défaut codée dans l'exécutable. Puisque cette propriété affecte la clé de chiffrement par défaut (pour le chiffrement) ainsi que son salt (pour le hachage), Gardez à l'esprit que tout ce qui est chiffré/haché avec cette clé nécessitera qu'elle soit transmise à chaque exécution d'ASF.</p> 

There is no requirement on `<key>` length or characters, but for security reasons we recommend to pick long enough passphrase made out of e.g. random 32 characters, for example by using `tr -dc A-Za-z0-9 < /dev/urandom | head -c 32; echo` command on Linux.

It's nice to mention that there are also two other ways to provide this detail: `--cryptkey-file` and `--input-cryptkey`.

En raison de la nature de cette propriété, il est également possible de définir la clé de chiffrement en déclarant la variable d'environnement `ASF_CRYPTKEY`, qui peut être plus appropriée pour les personnes qui voudraient éviter de divulguer des informations privées dans les arguments du processus.



---

`--cryptkey-file <path>` or `--cryptkey-file=<path>` - will start ASF with custom cryptographic key read from `<path>` file. This serves the same purpose as `--cryptkey <key>` explained above, only the mechanism differs, as this property will read `<key>` from provided `<path>` instead. If you're using this together with `--path`, consider declaring `--path` first so relative paths can work correctly.

Due to the nature of this property, it's also possible to set cryptkey file by declaring `ASF_CRYPTKEY_FILE` environment variable, which may be more appropriate for people that would want to avoid sensitive details in the process arguments.



---

`--ignore-unsupported-environment` - fera ignorer à ASF les problèmes liés à l'exécution dans un environnement non pris en charge, ce qui est normalement signalisé avec une erreur et une sortie forcée. Unsupported environment includes for example running `win-x64` OS-specific build on `linux-x64`. Même si ce flag laissera ASF s'exécuter dans de tels scénarios, soyez avertis; Nous ne prenons pas en charge ces éléments officiellement et vous forcez ASF à le faire entièrement **à vos risques et périls**. It's important to point out that **all** of the unsupported environment scenarios **can be corrected**. Nous recommandons fortement de résoudre les problèmes précédents plutôt que d'utiliser cet argument.



---

`--input-cryptkey` - will make ASF ask about the `--cryptkey` during startup. This option might be useful for you if instead of providing cryptkey, whether in environment variables or a file, you'd prefer to not have it saved anywhere and instead input it manually on each ASF run.



---

`--minimized` - will make ASF console window minimize shortly after start. Useful mainly in auto-start scenarios, but can also be used outside of those. Currently this switch has effect only on Windows machines.



---

`--network-group <group>` or `--network-group=<group>` - will cause ASF to init its limiters with a custom network group of `<group>` value. This option affects running ASF in **[multiple instances](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#multiple-instances)** by signalizing that given instance is dependent only on instances sharing the same network group, and independent of the rest. Typically you want to use this property only if you're routing ASF requests through custom mechanism (e.g. different IP addresses) and you want to set networking groups yourself, without relying on ASF to do it automatically (which currently includes taking into account `WebProxy` only). Keep in mind that when using a custom network group, this is unique identifier within the local machine, and ASF will not take into account any other details, such as `WebProxy` value, allowing you to e.g. start two instances with different `WebProxy` values which are still dependent on each other.

Due to the nature of this property, it's also possible to set the value by declaring `ASF_NETWORK_GROUP` environment variable, which may be more appropriate for people that would want to avoid sensitive details in the process arguments.



---

`--no-config-migrate` - by default ASF will automatically migrate your config files to latest syntax. Migration includes conversion of deprecated properties into latest ones, removing properties with default values (as they have no effect), as well as cleaning up the file in general (correcting indentation and likewise). This is almost always a good idea, but you might have a particular situation where you'd prefer ASF to never overwrite the config files automatically. For example, you might want to `chmod 400` your config files (read permission for the owner only) or put `chattr +i` over them, in result denying write access for everyone, e.g. as a security measure. Usually we recommend to keep the config migration enabled, but if you have a particular reason for disabling it and would instead prefer ASF to not do that, you can use this switch for achieving that purpose. Keep in mind however, that providing correct settings to ASF will become from now on your new responsibility, especially in regards to deprecations and refactors of properties in future ASF versions.



---

`--no-config-watch` - by default ASF sets up a `FileSystemWatcher` over your `config` directory in order to listen for events related to file changes, so it can interactively adapt to them. For example, this includes stopping bots on config deletion, restarting bot on config being changed, or loading keys into **[BGR](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer)** once you drop them into the `config` directory. This switch allows you to disable such behaviour, which will cause ASF to completely ignore all the changes in `config` directory, requiring from you to do such actions manually, if deemed appropriate (which usually means restarting the process). We recommend to keep the config events enabled, but if you have a particular reason for disabling them and would instead prefer ASF to not do that, you can use this switch for achieving that purpose.



---

`--no-restart` - cette fonctionnalité est principalement utilisé par nos **[docker](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Docker)** ` et force  <code>AutoRestart` de <0> false</ 0>. À moins que vous n'ayez un besoin particulier, il vaut mieux configurer la propriété `AutoRestart` directement dans votre configuration. Ce commutateur est là pour que notre script docker n'ait pas besoin de toucher à votre configuration globale pour l'adapter à son propre environnement. Bien sûr, si vous exécutez ASF dans un script, vous pouvez également utiliser cette fonctionnalité (sinon, la configuration globale est préférable).



---

`--no-steam-parental-generation` - by default ASF will automatically attempt to generate Steam parental PINs, as described in **[`SteamParentalCode`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#steamparentalcode)** configuration property. However, since that might require excessive amount of OS resources, this switch allows you to disable that behaviour, which will result in ASF skipping auto-generation and go straight to asking user for PIN instead, which is what would normally happen only if the auto-generation has failed. Usually we recommend to keep the generation enabled, but if you have a particular reason for disabling it and would instead prefer ASF to not do that, you can use this switch for achieving that purpose.



---

`--path <path>` ou `--path=<path>` - ASF navigue toujours vers son propre répertoire au démarrage. By specifying this argument, ASF will navigate to given directory after initialization, which allows you to use custom path for various application parts (including `config`, `logs`, `plugins` and `www` directories, as well as `NLog.config` file), without a need of duplicating binary in the same place. Cela peut s'avérer particulièrement utile si vous souhaitez séparer le binaire de la configuration réelle, comme cela est fait dans un paquet de type Linux - de cette façon, vous pouvez utiliser un binaire (à jour) avec plusieurs configurations différentes. Le chemin peut être relatif en fonction de l'emplacement actuel du binaire ASF ou en absolu. Keep in mind that this command points to new "ASF home" - the directory that has the same structure as original ASF, with `config` directory inside, see below example for explanation.

En raison de la nature de cet propriété, il est aussi possible de définir le chemin attendu en déclarant la variable d'environnement `ASF_PATH`, ce qui peut être plus approprié pour les personnes voulant éviter des données sensibles dans les arguments du processus.

If you're considering using this command-line argument for running multiple instances of ASF, we recommend reading our **[management page](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#multiple-instances)** on this manner.

Exemples:



```shell
dotnet /opt/ASF/ArchiSteamFarm.dll --path /opt/DossierVoulu # Chemin absolu
dotnet /opt/ASF/ArchiSteamFarm.dll --path ../DossierVoulu # Les chemins relatifs fonctionnent aussi
ASF_PATH=/opt/DossierVoulu dotnet /opt/ASF/ArchiSteamFarm.dll # Pareil qu'avec les variables environnementales
```




```text
├── /opt
│     ├── ASF
│     │     ├── ArchiSteamFarm.dll
│     │     └── ...
│     └── TargetDirectory
│           ├── config
│           ├── logs (généré)
│           ├── plugins (optionnel)
│           ├── www (optionnel)
│           ├── log.txt (généré)
│           └── NLog.config (optionnel)
└── ...
```




---

`--process-required` la  fonctionnalité de ce commutateur désactivera le la méthode ASF par défaut d'arrêt lorsque aucun bot ne s'exécute. Aucun comportement d’arrêt automatique n’est particulièrement utile en combinaison avec **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)**, où la majorité des utilisateurs s’attendraient à ce que leur service Web s’exécute, quel que soit le nombre de bots activés. Si vous utilisez l'option IPC ou si vous avez besoin que le processus ASF soit actif jusqu'à ce que vous le fermiez vous-même, c'est la bonne option.

Si vous n'avez pas l'intention de faire fonctionner IPC, cette option sera plutôt inutile pour vous, car vous pouvez simplement relancer le processus si nécessaire (contrairement au serveur Web d'ASF où vous avez besoin de l'écouter tout le temps pour pouvoir envoyer des commandes).



---

`--service` - this switch is mainly used by our `systemd` service and forces `Headless` of `true`. Unless you have a particular need, you should instead configure `Headless` property directly in your config. This switch is here so our `systemd` service won't need to touch your global config in order to adapt it to its own environment. Of course, if you have a similar need then you may also make use of this switch (otherwise you're better with global config property).



---

`--system-required</ 0> - la déclaration de ce commutateur incitera ASF à signaler au système d'exploitation que le processus nécessite que le système soit opérationnel pendant toute sa durée de vie. Actuellement, ce commutateur n'a d'effet que sur les machines Windows où il sera interdit à votre système de passer en mode veille tant que le processus est en cours d'exécution. Cela peut être particulièrement utile si vous comptez farmer avec votre ordinateur ou votre PC durant la nuit, car ASF pourra maintenur le système en veille. Une fois l'opération terminée, votre machine s'éteindra comme d'ordinaire. Cela vous permettra d'économiser de l'énergie.</p>

<p spaces-before="0">Keep in mind that for proper auto-shutdown of ASF you need other settings - especially avoiding <code>--process-required` and ensuring that all your bots are following `ShutdownOnFarmingFinished` in their `FarmingPreferences`. Bien sûr, l’arrêt automatique n’est qu’une possibilité pour cette fonction, et non une obligation, car vous pouvez également utiliser cet fonction avec, par exemple, `--process-required`, ce qui rend votre système éveillé à l'infini après le démarrage d'ASF.