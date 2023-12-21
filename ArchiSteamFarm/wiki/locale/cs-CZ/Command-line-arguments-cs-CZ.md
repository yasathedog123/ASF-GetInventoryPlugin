# Argumenty příkazového řádku

ASF obsahuje podporu pro několik argumentů příkazové řádky, které mohou ovlivnit běh programu. Ty mohou být použity pokročilými uživateli pro upřesnění způsobu běhu programu. Ve srovnání s výchozím způsobem konfigurace `ASF.json` se argumenty příkazové řádky používají pro inicializaci jádra (např. `--path`), nastavení specifické na platformě (např. `--system-required`) nebo citlivá data (např. `--cryptkey`).

---

## Použití

Použití závisí na vaší preferenci OS a ASF.

Obecné:

```shell
dotnet ArchiSteamFarm.dll --argument --otherOne
```

Windows:

```powershell
.\ArchiSteamFarm.exe --argument --otherOne
```

Linux/macOS:

```shell
./ArchiSteamFarm --argument --otherOne
```

Argumenty příkazového řádku jsou také podporovány v generických pomocných skriptech, jako je `ArchiSteamFarm.cmd` nebo `ArchiSteamFarm.sh`. Kromě toho můžete, při použití pomocných skriptů, také použít `ASF_ARGS` vlastnost prostředí, jak je uvedeno v našich **[management](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#environment-variables)** a **[docker](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Docker#command-line-arguments)** sekcích.

Pokud váš argument obsahuje mezery, nezapomeňte jej ocitovat. Tyto dvě věci jsou špatně:

```shell
./ArchiSteamFarm --path /home/archi/My Downloads/ASF # Špatně!
./ArchiSteamFarm --path=/home/archi/My Downloads/ASF # Špatně!
```

Nicméně, dvě jsou zcela v pořádku:

```shell
./ArchiSteamFarm --path "/home/archi/My Downloads/ASF" # OK
./ArchiSteamFarm "--path=/home/archi/My Downloads/ASF" # OK
```

## Parametry

`--cryptkey <key>` nebo `--cryptkey=<key>` - spustí ASF s vlastním kryptografickým klíčem s hodnotou `<key>`. Tato volba ovlivní **[bezpečnost](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security)** a způsobí, že ASF bude používat vlastní zadaný klíč `<key>`, namísto výchozího klíče, který je pevně nakódováný v programu. Protože tato vlastnost ovlivňuje výchozí šifrovací klíč (pro účely šifrování) i "sůl" (pro účely hashování), mějte na paměti, že vše, co je šifrováno/hashováno tímto klíčem, bude vyžadovat jeho předání při každém spuštění ASF.

There is no requirement on `<key>` length or characters, but for security reasons we recommend to pick long enough passphrase made out of e.g. random 32 characters, for example by using `tr -dc A-Za-z0-9 < /dev/urandom | head -c 32; echo` command on Linux.

Je dobré zmínit, že existují také dva další způsoby, jak tento detail poskytnout: `--cryptkey-file` a `--input-cryptkey`.

Vzhledem k povaze této vlastnosti je také možné nastavit cryptkey deklarací proměnné prostředí `ASF_CRYPTKEY`, což může být vhodnější pro ty, kteří se chtějí vyhnout citlivým údajům v argumentech procesu.

---

`--cryptkey-file <path>` nebo `--cryptkey-file=<path>` - spustí ASF s vlastním kryptografickým klíčem načteným ze souboru `<path>`. Slouží ke stejnému účelu jako `--cryptkey <key>` vysvětlený výše, liší se pouze mechanismem, protože tato vlastnost bude místo toho číst `<key>` z poskytnutého `<path>`. If you're using this together with `--path`, consider declaring `--path` first so relative paths can work correctly.

Vzhledem k povaze této vlastnosti je také možné nastavit soubor šifrovacího klíče deklarací proměnné prostředí `ASF_CRYPTKEY_FILE`, což může být vhodnější pro ty, kteří se chtějí vyhnout citlivým údajům v argumentech procesu.

---

`--ignore-unsupported-environment` - způsobí, že ASF bude ignorovat problémy spojené se spuštěním v nepodporovaném prostředí, což je obvykle signalizováno chybou a vynuceným ukončením. Unsupported environment includes for example running `win-x64` OS-specific build on `linux-x64`. While this flag will allow ASF to attempt running in such scenarios, be advised that we do not support those officially and you're forcing ASF to do it entirely **at your own risk**. As of today, **all** of the unsupported environment scenarios can be corrected. Rozhodně doporučujeme raději opravit nevyřešené problémy namísto nastavování tohoto argumentu.

---

`--input-cryptkey` - způsobí, že se ASF při spuštění zeptá na `--cryptkey`. Tato možnost by pro vás mohla být užitečná, pokud byste místo zadávání šifrovacího klíče, ať už v proměnných prostředí nebo v souboru, raději neměli šifrovací klíč nikde uložený a místo toho jej zadávali ručně při každém spuštění ASF.

---

`--minimized` - will make ASF console window minimize shortly after start. Useful mainly in auto-start scenarios, but can also be used outside of those. Currently this switch has effect only on Windows machines.

---

`--network-group <group>` nebo `--network-group=<group>` - způsobí, že ASF inicializuje své omezovače s vlastní síťovou skupinou o hodnotě `<group>`. Tato možnost ovlivňuje běh ASF ve **[více instancích](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#multiple-instances)** tím, že signalizuje, že daná instance je závislá pouze na sdílené síťové skupině, a nezávislá na ostatních. Obvykle chcete tuto vlastnost použít pouze v případě, že směrujete požadavky ASF prostřednictvím vlastního mechanismu (např. různé IP adresy) a chcete sami nastavit síťové skupiny, aniž byste se spoléhali na to, že to ASF udělá automaticky (což v současné době zahrnuje pouze zohlednění `WebProxy`). Keep in mind that when using a custom network group, this is unique identifier within the local machine, and ASF will not take into account any other details, such as `WebProxy` value, allowing you to e.g. start two instances with different `WebProxy` values which are still dependent on each other.

Due to the nature of this property, it's also possible to set the value by declaring `ASF_NETWORK_GROUP` environment variable, which may be more appropriate for people that would want to avoid sensitive details in the process arguments.

---

`--no-config-migrate` - by default ASF will automatically migrate your config files to latest syntax. Migration includes conversion of deprecated properties into latest ones, removing properties with default values (as they have no effect), as well as cleaning up the file in general (correcting indentation and likewise). This is almost always a good idea, but you might have a particular situation where you'd prefer ASF to never overwrite the config files automatically. For example, you might want to `chmod 400` your config files (read permission for the owner only) or put `chattr +i` over them, in result denying write access for everyone, e.g. as a security measure. Usually we recommend to keep the config migration enabled, but if you have a particular reason for disabling it and would instead prefer ASF to not do that, you can use this switch for achieving that purpose.

---

`--no-config-watch` - by default ASF sets up a `FileSystemWatcher` over your `config` directory in order to listen for events related to file changes, so it can interactively adapt to them. For example, this includes stopping bots on config deletion, restarting bot on config being changed, or loading keys into **[BGR](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer)** once you drop them into the `config` directory. This switch allows you to disable such behaviour, which will cause ASF to completely ignore all the changes in `config` directory, requiring from you to do such actions manually, if deemed appropriate (which usually means restarting the process). We recommend to keep the config events enabled, but if you have a particular reason for disabling them and would instead prefer ASF to not do that, you can use this switch for achieving that purpose.

---

`--no-restart` - this switch is mainly used by our **[docker](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Docker)** containers and forces `AutoRestart` of `false`. Unless you have a particular need, you should instead configure `AutoRestart` property directly in your config. This switch is here so our docker script won't need to touch your global config in order to adapt it to its own environment. Of course, if you're running ASF inside a script, you may also make use of this switch (otherwise you're better with global config property).

---

`--no-steam-parental-generation` - by default ASF will automatically attempt to generate Steam parental PINs, as described in **[`SteamParentalCode`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#steamparentalcode)** configuration property. However, since that might require excessive amount of OS resources, this switch allows you to disable that behaviour, which will result in ASF skipping auto-generation and go straight to asking user for PIN instead, which is what would normally happen only if the auto-generation has failed. Usually we recommend to keep the generation enabled, but if you have a particular reason for disabling it and would instead prefer ASF to not do that, you can use this switch for achieving that purpose.

---

`--path <path>` or `--path=<path>` - ASF always navigates to its own directory on startup. By specifying this argument, ASF will navigate to given directory after initialization, which allows you to use custom path for various application parts (including `config`, `plugins` and `www` directories, as well as `NLog.config` file), without a need of duplicating binary in the same place. It may come especially useful if you'd like to separate binary from actual config, as it's done in Linux-like packaging - this way you can use one (up-to-date) binary with several different setups. The path can be either relative according to current place of ASF binary, or absolute. Keep in mind that this command points to new "ASF home" - the directory that has the same structure as original ASF, with `config` directory inside, see below example for explanation.

Due to the nature of this property, it's also possible to set expected path by declaring `ASF_PATH` environment variable, which may be more appropriate for people that would want to avoid sensitive details in the process arguments.

If you're considering using this command-line argument for running multiple instances of ASF, we recommend reading our **[management page](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#multiple-instances)** on this manner.

Příklady:

```shell
dotnet /opt/ASF/ArchiSteamFarm.dll --path /opt/TargetDirectory # Absolute path
dotnet /opt/ASF/ArchiSteamFarm.dll --path ../TargetDirectory # Relative path works as well
ASF_PATH=/opt/TargetDirectory dotnet /opt/ASF/ArchiSteamFarm.dll # Same as env variable
```

```text
├── /opt
│     ├── ASF
│     │     ├── ArchiSteamFarm.dll
│     │     └── ...
│     └── TargetDirectory
│           ├── config
│           ├── logs (generated)
│           ├── plugins (optional)
│           ├── www (optional)
│           ├── log.txt (generated)
│           └── NLog.config (optional)
└── ...
```

---

`--process-required` - declaring this switch will disable default ASF behaviour of shutting down when no bots are running. No auto-shutdown behaviour is especially useful in combination with **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)** where majority of users would expect their web service to be running regardless of the amount of bots that are enabled. Pokud používáte IPC funkci nebo potřebujete ASF proces, aby běžel neustále, dokud ho sami neukončíte, je toto správná volba.

If you do not intend to run IPC, this option will be rather useless for you, as you can just start the process again when needed (as opposed to ASF's web server where you require it listening all the time in order to send commands).

---

`--service` - this switch is mainly used by our `systemd` service and forces `Headless` of `true`. Unless you have a particular need, you should instead configure `Headless` property directly in your config. This switch is here so our `systemd` service won't need to touch your global config in order to adapt it to its own environment. Of course, if you have a similar need then you may also make use of this switch (otherwise you're better with global config property).

---

`--system-required` - declaring this switch will cause ASF to try signalizing the OS that the process requires system to be up and running for its entire lifetime. Currently this switch has effect only on Windows machines where it'll forbid your system from going into sleep mode as long as the process is running. This can be proven especially useful when farming on your PC or laptop during night, as ASF will be able to keep your system awake while it's farming, then, once ASF is done, it'll shutdown itself like usual, making your system allowed to enter into sleep mode again, therefore saving power immediately once farming is finished.

Keep in mind that for proper auto-shutdown of ASF you need other settings - especially avoiding `--process-required` and ensuring that all your bots are following `ShutdownOnFarmingFinished`. Of course, auto-shutdown is only a possibility for this feature, not a requirement, since you can also use this flag together with e.g. `--process-required`, effectively making your system awake infinitely after starting ASF.