# Argumente din linie comandă

ASF include suport pentru mai multe argumente de linie de comandă care pot afecta rularea programului. Acestea pot fi folosite de utilizatorii avansați pentru a specifica cum ar trebui să ruleze programul. În comparație cu modul implicit al fișierului de configurare `ASF.json`, argumentele din linie de comanda sunt folosite pentru inițializarea de bază (de ex. `--path`), setări specifice platformei (ex. `--system-required`) sau date sensibile (ex. `--cryptkey`).

---

## Utilizare

Utilizarea depinde de sistemul de operare și versiune ASF.

Generic:

```shell
dotnet ArchiSteamFarm.dll --argument --altArgument
```

Windows:

```powershell
.\ArchiSteamFarm.exe --argument --altArgument
```

Linux/macOS:

```shell
./ArchiSteamFarm --argument --altArgument
```

Argumentele din linie de comandă sunt de asemenea acceptate în script-uri generice de ajutor cum ar fi `ArchiSteamFarm.cmd` sau `ArchiSteamFarm.sh`. In addition to that, you can also use `ASF_ARGS` environment property, like stated in our **[management](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#environment-variables)** and **[docker](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Docker#command-line-arguments)** sections.

Dacă argumentul tău include spații, nu uita să folosești ghilimele. Aceste două sunt greșite:

```shell
./ArchiSteamFarm --path /home/archi/My Downloads/ASF # Greșit!
./ArchiSteamFarm --path /home/archi/My Downloads/ASF # Greșit!
```

Cu toate acestea, următoarele sunt complet în regulă:

```shell
./ArchiSteamFarm --path "/home/archi/My Downloads/ASF" # OK
./ArchiSteamFarm "--path=/home/archi/My Downloads/ASF" # OK
```

## Argumente

`--cryptkey <key>` sau `--cryptkey=<key>` - va începe ASF cu cheia criptografică personalizată de `<key>`. Această opțiune afectează **[securitatea](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security)** și va face ca ASF să utilizeze cheia personalizată oferită `<key>` în loc de cea implicită codificată în executabil. Deoarece această proprietate afectează cheia de criptare implicită (în scopuri de criptare) şi valoarea salt (în scopuri de hashing), ține cont de faptul că totu ce este criptat/hashed cu această cheie necesită ca ea să fie transmisă la fiecare rulare ASF.

There is no requirement on `<key>` length or characters, but for security reasons we recommend to pick long enough passphrase made out of e.g. random 32 characters, for example by using `tr -dc A-Za-z0-9 < /dev/urandom | head -c 32; echo` command on Linux.

It's nice to mention that there are also two other ways to provide this detail: `--cryptkey-file` and `--input-cryptkey`.

Datorită naturii acestei proprietăți, este posibilă și setarea cheii de criptare prin declararea variabilei de mediu `ASF_CRYPTKEY`, care ar putea fi mai potrivită pentru persoanele care ar dori să evite detaliile sensibile în argumentele procesului.

---

`--cryptkey-file <path>` or `--cryptkey-file=<path>` - will start ASF with custom cryptographic key read from `<path>` file. This serves the same purpose as `--cryptkey <key>` explained above, only the mechanism differs, as this property will read `<key>` from provided `<path>` instead.

Due to the nature of this property, it's also possible to set cryptkey file by declaring `ASF_CRYPTKEY_FILE` environment variable, which may be more appropriate for people that would want to avoid sensitive details in the process arguments.

---

`--ignore-unsupported-environment` - will cause ASF to ignore problems related to running in unsupported environment, which normally is signalized with an error and a forced exit. Unsupported environment includes for example running .NET Framework build on platform that could be running .NET (Core) build instead. While this flag will allow ASF to attempt running in such scenarios, be advised that we do not support those officially and you're forcing ASF to do it entirely **at your own risk**. As of today, **all** of the unsupported environment scenarios can be corrected, such as running `generic` build instead of `generic-netf`. We strongly recommend to fix the outstanding problems instead of declaring this argument.

---

`--input-cryptkey` - will make ASF ask about the `--cryptkey` during startup. This option might be useful for you if instead of providing cryptkey, whether in environment variables or a file, you'd prefer to not have it saved anywhere and instead input it manually on each ASF run.

---

`--minimized` - will make ASF console window minimize shortly after start. Useful mainly in auto-start scenarios, but can also be used outside of those. Currently this switch has effect only on Windows machines.

---

`--network-group <group>` sau `--network-group=<group>` - va determina ASF să își inițializeze limitele cu un grup de rețea personalizat de `<group>`. Această opțiune afectează rularea ASF în **[mai multe instanțe](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#multiple-instances)** prin semnalizarea că o anumită instanță este dependentă doar de instanțele care partajează același grup de rețea, independent de restul. De obicei vrei să folosești această proprietate doar dacă direcționezi cereri ASF prin mecanisme personalizate (de ex. adrese IP diferite) și doriți să setați dvs. grupuri de rețea; fără a se baza pe ASF pentru a face acest lucru automat (care include în prezent doar luarea în considerare a `WebProxy`). Rețineți că atunci când utilizați un grup de rețea personalizat, acesta este un identificator unic în cadrul mașinii locale, iar ASF nu va lua în considerare alte detalii, cum ar fi valoarea `WebProxy`, care permite de ex. pornirea a două instanțe cu valori `WebProxy` diferite, care sunt încă dependente una de cealaltă.

Datorită naturii acestei proprietăți, este posibilă și setarea cheii de criptare prin declararea variabilei de mediu `ASF_NETWORK_GROUP`, care ar putea fi mai potrivită pentru persoanele care ar dori să evite detaliile sensibile în argumentele procesului.

---

`--no-config-migrate` - by default ASF will automatically migrate your config files to latest syntax. Migration includes conversion of deprecated properties into latest ones, removing properties with default values (as they have no effect), as well as cleaning up the file in general (correcting indentation and likewise). This is almost always a good idea, but you might have a particular situation where you'd prefer ASF to never overwrite the config files automatically. For example, you might want to `chmod 400` your config files (read permission for the owner only) or put `chattr +i` over them, in result denying write access for everyone, e.g. as a security measure. Usually we recommend to keep the config migration enabled, but if you have a particular reason for disabling it and would instead prefer ASF to not do that, you can use this switch for achieving that purpose.

---

`--no-config-watch` - by default ASF sets up a `FileSystemWatcher` over your `config` directory in order to listen for events related to file changes, so it can interactively adapt to them. For example, this includes stopping bots on config deletion, restarting bot on config being changed, or loading keys into **[BGR](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer)** once you drop them into the `config` directory. This switch allows you to disable such behaviour, which will cause ASF to completely ignore all the changes in `config` directory, requiring from you to do such actions manually, if deemed appropriate (which usually means restarting the process). We recommend to keep the config events enabled, but if you have a particular reason for disabling them and would instead prefer ASF to not do that, you can use this switch for achieving that purpose.

---

`--no-restart` - acest comutator este folosit în principal de containere **[docker](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Docker)** şi forţează `AutoRepornire` să fie `false`. Unless you have a particular need, you should instead configure `AutoRestart` property directly in your config. This switch is here so our docker script won't need to touch your global config in order to adapt it to its own environment. Desigur, dacă rulați ASF într-un script, puteți folosi acest comutator (altfel sunteți mai bine cu proprietatea configurării globale).

---

`--no-steam-parental-generation` - by default ASF will automatically attempt to generate Steam parental PINs, as described in **[`SteamParentalCode`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#steamparentalcode)** configuration property. However, since that might require excessive amount of OS resources, this switch allows you to disable that behaviour, which will result in ASF skipping auto-generation and go straight to asking user for PIN instead, which is what would normally happen only if the auto-generation has failed. Usually we recommend to keep the generation enabled, but if you have a particular reason for disabling it and would instead prefer ASF to not do that, you can use this switch for achieving that purpose.

---

`--path <path>` sau `--path<path>` - ASF navigează întotdeauna spre propriul său director la pornire. Prin specificarea acestui argument, ASF va naviga la un anumit director după inițializare, care vă permite să utilizaţi calea personalizată pentru diferite componente ale aplicaţiei (inclusiv directoarele`config`, `plugins` și `www`, precum și fișierul `NLog.config`), fără a fi nevoie de duplicarea binarului în același loc. Poate fi folositor mai ales dacă doriţi să separaţi binarul de configurarea reală, aşa cum este făcut în ambalajul din Linux - în acest fel puteţi folosi un binar (actualizat) cu mai multe configurări diferite. Calea poate fi relativă în funcție de locul curent al sistemului binar ASF, sau absolut. Keep in mind that this command points to new "ASF home" - the directory that has the same structure as original ASF, with `config` directory inside, see below example for explanation.

Datorită naturii acestei proprietăți, este posibil să setezi calea așteptată prin declararea variabilei `ASF_PATH`, care ar putea fi mai potrivite pentru persoanele care ar dori să evite detaliile sensibile în argumentele procesului.

If you're considering using this command-line argument for running multiple instances of ASF, we recommend reading our **[management page](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#multiple-instances)** on this manner.

Exemple:

```shell
dotnet /opt/ASF/ArchiSteamFarm.dll --path /opt/DirectorDorit # Calea absolută
dotnet /opt/ASF/ArchiSteamFarm.dll --path ../DirectorDorit # Calea relativă funcționează de asemenea
ASF_PATH=/opt/DirectorDorit dotnet /opt/ASF/ArchiSteamFarm.dll # La fel ca variabila env
```

```text
├── /opt
│     ├── ASF
│     │     ├── ArchiSteamFarm.dll
│     │     └── ...
│     └── DirectorDorit
│           ├── config
│           ├── logs (generat)
│           ├── plugins (optional)
│           ├── www (optional)
│           ├── log.txt (generat)
│           └── NLog.config (optional)
└── ...
```

---

`--process-required` - declarând că acest comutator va dezactiva comportamentul ASF implicit la închidere atunci când niciun bot nu rulează. Comportamentul de închidere automată dezactivată este util în special în combinație cu **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)** unde majoritatea utilizatorilor se așteaptă ca serviciul lor web să fie rulat, indiferent de numărul de boți care sunt activați. Dacă utilizați opțiunea IPC sau aveți nevoie de procesul ASF pentru a rula tot timpul până când îl închideți, aceasta este opţiunea corectă.

Dacă nu intenționezi să gestionezi IPC, această opțiune va fi mai degrabă inutilă pentru tine, pentru că poți mai simplu să pornești procesul din nou când este necesar (spre deosebire de serverul web al ASF, unde ai nevoie de el tot timpul pentru a trimite comenzi).

---

`--service` - this switch is mainly used by our `systemd` service and forces `Headless` of `true`. Unless you have a particular need, you should instead configure `Headless` property directly in your config. This switch is here so our `systemd` service won't need to touch your global config in order to adapt it to its own environment. Of course, if you have a similar need then you may also make use of this switch (otherwise you're better with global config property).

---

`--system-required` - declararea acestui întrerupător va determina ASF să încerce să semnalizeze sistemului de operare că procesul necesită ca sistemul să fie funcțional pe toată durata sa de viață. În prezent, acest comutator are efect numai pe mașinile Windows unde va interzice sistemului să intre în modul de suspendare atâta timp cât procesul rulează. This can be proven especially useful when farming on your PC or laptop during night, as ASF will be able to keep your system awake while it's farming, then, once ASF is done, it'll shutdown itself like usual, making your system allowed to enter into sleep mode again, therefore saving power immediately once farming is finished.

Rețineți că pentru închiderea automată corectă a ASF aveți nevoie de alte setări - în special evitând `--process-required` și asigurându-vă că toți roboții vor urma `ShutdownOnFarmingFinished`. Bineînțeles, închiderea automată este doar o posibilitate pentru această caracteristică, nu o cerință, deoarece se poate folosi și acest steag împreună cu `--process-required`, făcând ca sistemul să rămână pornit la infinit după pornirea ASF.