# Argomenti della riga di comando

ASF include supporto per differenti argomenti della linea di comando che può influire sui tempi di esecuzione del programma. Questi possono essere usati da utenti avanzati per poter specificare come dovrebbe essere eseguito il programma. In confronto al modo predefinito del file di configurazione `ASF.json`, gli argomenti della linea di comando sono usati per l'inizializzazione del core (es. `--path`), le impostazioni specifiche della piattaforma (es.: `--systemrequired`) o i dati sensibili (es.: `--cryptkey`).

---

## Uso

L'uso dipende dal tuo sistema operativo e dal flavour di ASF.

Generico:

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

Gli argomenti della linea di comando sono anche supportati negli script di aiuto generici come `ArchiSteamFarm.cmd` o `ArchiSteamFarm.sh`. Inoltre, è anche possibile utilizzare la proprietà d'ambiente `ASF_ARGS`, come indicato nelle nostre sezioni **[management](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#environment-variables)** e **[docker](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Docker#command-line-arguments)**.

Se il tuo argomento include spazi, non dimenticarti di citarlo. Questi due sono sbagliati:

```shell
./ArchiSteamFarm --path /home/archi/My Downloads/ASF # Bad!
./ArchiSteamFarm --path=/home/archi/My Downloads/ASF # Bad!
```

Tuttavia, queste due vanno completamente bene:

```shell
./ArchiSteamFarm --path "/home/archi/My Downloads/ASF" # OK
./ArchiSteamFarm "--path=/home/archi/My Downloads/ASF" # OK
```

## Argomenti

`--cryptkey <key>` o `--cryptkey=<key>`, avvieranno ASF con la chiave crittografica personalizzata di valore `<key>`. Quest'opzione influenza la **[sicurezza](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security)** e causerà ad ASF di usare la tua chiave personalizzata `<key>` fornita invece di quella predefinita codificata nell'eseguibile. Poiché questa proprietà influisce sulla chiave di crittografia predefinita (per scopi di crittografia) e sul salt (per scopi di hash), si tenga a mente che tutto quello che viene cifrato/hashato con questa chiave richiederà che sia trasmessa ad ogni esecuzione di ASF.

There is no requirement on `<key>` length or characters, but for security reasons we recommend to pick long enough passphrase made out of e.g. random 32 characters, for example by using `tr -dc A-Za-z0-9 < /dev/urandom | head -c 32; echo` command on Linux.

It's nice to mention that there are also two other ways to provide this detail: `--cryptkey-file` and `--input-cryptkey`.

A causa della natura di questa proprietà, è anche possibile impostare la chiave crittografica dichiarando la variabile ambientale `ASF_CRYPTKEY`, che potrebbe esser più appropriata per le persone che vorrebbero evitare i dettagli sensibili negli argomenti del processo.

---

`--cryptkey-file <path>` or `--cryptkey-file=<path>` - will start ASF with custom cryptographic key read from `<path>` file. This serves the same purpose as `--cryptkey <key>` explained above, only the mechanism differs, as this property will read `<key>` from provided `<path>` instead. If you're using this together with `--path`, consider declaring `--path` first so relative paths can work correctly.

Due to the nature of this property, it's also possible to set cryptkey file by declaring `ASF_CRYPTKEY_FILE` environment variable, which may be more appropriate for people that would want to avoid sensitive details in the process arguments.

---

`--ignore-unsupported-environment`, causerà l'ignoramento del rilevamento degli ambienti non supportati di ASF, che normalmente è segnalato con un errore e l'uscita forzata. Unsupported environment includes for example running `win-x64` OS-specific build on `linux-x64`. Mentre questo parametro permetterà a ASF di provare a essere eseguito in tali scenari, avvisiamo che non lo supportiamo ufficialmente e stai costringendo ASF a eseguito interamente **a tuo rischio e pericolo**. It's important to point out that **all** of the unsupported environment scenarios **can be corrected**. Raccomandiamo vivamente di risolvere i problemi in sospeso invece di usare questo parametro.

---

`--input-cryptkey` - will make ASF ask about the `--cryptkey` during startup. This option might be useful for you if instead of providing cryptkey, whether in environment variables or a file, you'd prefer to not have it saved anywhere and instead input it manually on each ASF run.

---

`--minimized` - will make ASF console window minimize shortly after start. Useful mainly in auto-start scenarios, but can also be used outside of those. Currently this switch has effect only on Windows machines.

---

`--network-group <group>` o `--network-group=<group>` - causerà ASF l'inizializzazione dei suoi limitatori con un gruppo di rete personalizzato con valore `<group>`. Questa opzione influisce sull'esecuzione di ASF in **[istanze multiple](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#multiple-instances)** segnalando che la data istanza dipende solo dalle istanze che condividono lo stesso gruppo di rete, e indipendente dal resto. In genere vuoi usare questa proprietà solo se stai instradando le richieste di ASF attraverso un meccanismo personalizzato (ad es. indirizzi IP diversi) e si desidera impostare gruppi di rete da soli, senza fare affidamento su ASF per farlo automaticamente (che attualmente include prendendo in considerazione `WebProxy` soltanto). Tieni presente che quando si utilizza un gruppo di rete personalizzato, si tratta di un identificatore univoco all'interno della macchina locale, e ASF non terrà conto di altri dettagli, come ad esempio il valore `WebProxy`, che consente di per esempio avviare due istanze con diversi valori `WebProxy` che sono ancora dipendenti l'uno dall'altro.

A causa della natura di questa proprietà, è anche possibile impostare il valore dichiarando `ASF_NETWORK_GROUP` variabile d'ambiente, che può essere più appropriato per le persone che vorrebbero evitare dettagli sensibili nelle discussioni di processo.

---

`--no-config-migrate` - di default ASF migrerà automaticamente i file di configurazione all'ultima sintassi. La migrazione include la conversione di proprietà deprecate in quelle più recenti, rimuovendo proprietà con valori predefiniti (poiché non hanno effetto), così come la pulizia del file in generale (correzione indentazione e allo stesso modo). Questa è quasi sempre una buona idea, ma si potrebbe avere una situazione particolare in cui preferiresti che ASF non sovrascriva mai automaticamente i file di configurazione. Ad esempio, potresti voler `chmod 400` i tuoi file di configurazione (i permessi di lettura solo per il proprietario) o mettere `chattr +i` su di loro, in conseguenza negare l'accesso in scrittura per tutti, per esempio come misura di sicurezza. Di solito si consiglia di mantenere attiva la migrazione di configurazione, ma se hai un motivo particolare per disabilitarlo e preferiresti invece che ASF non lo faccia, è possibile utilizzare questo interruttore per raggiungere questo scopo. Keep in mind however, that providing correct settings to ASF will become from now on your new responsibility, especially in regards to deprecations and refactors of properties in future ASF versions.

---

`--no-config-watch` - di default ASF imposta un `FileSystemWatcher` sulla tua `cartella di configurazione` per ascoltare gli eventi relativi alle modifiche dei file, in modo che possa adattarsi interattivamente a loro. Ad esempio, questo include l'arresto dei bot durante l'eliminazione della configurazione, il riavvio del bot sulla configurazione in corso di modifica, o caricando i tasti in **[BGR](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer)** una volta che li rilasci nella cartella `config`. This switch allows you to disable such behaviour, which will cause ASF to completely ignore all the changes in `config` directory, requiring from you to do such actions manually, if deemed appropriate (which usually means restarting the process). We recommend to keep the config events enabled, but if you have a particular reason for disabling them and would instead prefer ASF to not do that, you can use this switch for achieving that purpose.

---

`--no-restart` - questo interruttore è utilizzato principalmente dal nostro **[docker](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Docker)** contenitori e forze `AutoRestart` di `falso`. A meno che non si abbia una particolare necessità, è necessario configurare la proprietà `Riavvio automatico` direttamente nella configurazione. Questo interruttore è qui quindi il nostro script docker non avrà bisogno di toccare la tua configurazione globale per adattarla al proprio ambiente. Naturalmente, se si esegue ASF all'interno di uno script, si può anche fare uso di questo interruttore (altrimenti è meglio con la proprietà di configurazione globale).

---

`--no-steam-parental-generation` - by default ASF will automatically attempt to generate Steam parental PINs, as described in **[`SteamParentalCode`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#steamparentalcode)** configuration property. However, since that might require excessive amount of OS resources, this switch allows you to disable that behaviour, which will result in ASF skipping auto-generation and go straight to asking user for PIN instead, which is what would normally happen only if the auto-generation has failed. Usually we recommend to keep the generation enabled, but if you have a particular reason for disabling it and would instead prefer ASF to not do that, you can use this switch for achieving that purpose.

---

`--path <path>` or `--path=<path>` - ASF always navigates to its own directory on startup. By specifying this argument, ASF will navigate to given directory after initialization, which allows you to use custom path for various application parts (including `config`, `logs`, `plugins` and `www` directories, as well as `NLog.config` file), without a need of duplicating binary in the same place. It may come especially useful if you'd like to separate binary from actual config, as it's done in Linux-like packaging - this way you can use one (up-to-date) binary with several different setups. The path can be either relative according to current place of ASF binary, or absolute. Keep in mind that this command points to new "ASF home" - the directory that has the same structure as original ASF, with `config` directory inside, see below example for explanation.

Due to the nature of this property, it's also possible to set expected path by declaring `ASF_PATH` environment variable, which may be more appropriate for people that would want to avoid sensitive details in the process arguments.

If you're considering using this command-line argument for running multiple instances of ASF, we recommend reading our **[management page](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#multiple-instances)** on this manner.

Esempi:

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

`--process-required` - declaring this switch will disable default ASF behaviour of shutting down when no bots are running. No auto-shutdown behaviour is especially useful in combination with **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)** where majority of users would expect their web service to be running regardless of the amount of bots that are enabled. If you're using IPC option or otherwise need ASF process to be running all the time until you close it yourself, this is the right option.

If you do not intend to run IPC, this option will be rather useless for you, as you can just start the process again when needed (as opposed to ASF's web server where you require it listening all the time in order to send commands).

---

`--service` - this switch is mainly used by our `systemd` service and forces `Headless` of `true`. Unless you have a particular need, you should instead configure `Headless` property directly in your config. This switch is here so our `systemd` service won't need to touch your global config in order to adapt it to its own environment. Of course, if you have a similar need then you may also make use of this switch (otherwise you're better with global config property).

---

`--system-required` - declaring this switch will cause ASF to try signalizing the OS that the process requires system to be up and running for its entire lifetime. Currently this switch has effect only on Windows machines where it'll forbid your system from going into sleep mode as long as the process is running. This can be proven especially useful when farming on your PC or laptop during night, as ASF will be able to keep your system awake while it's farming, then, once ASF is done, it'll shutdown itself like usual, making your system allowed to enter into sleep mode again, therefore saving power immediately once farming is finished.

Keep in mind that for proper auto-shutdown of ASF you need other settings - especially avoiding `--process-required` and ensuring that all your bots are following `ShutdownOnFarmingFinished` in their `FarmingPreferences`. Of course, auto-shutdown is only a possibility for this feature, not a requirement, since you can also use this flag together with e.g. `--process-required`, effectively making your system awake infinitely after starting ASF.