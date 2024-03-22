# SteamTokenDumperPlugin

`SteamTokenDumperPlugin` is official ASF **[plugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)** developed by us, which allows you to contribute to **[SteamDB](https://steamdb.info)** project by sharing package tokens, app tokens and depot keys that your Steam account has access to. Le informazioni estese sui dati raccolti e perché SteamDB li necessita si possono trovare sulla pagina di SteamDB **[Token Dumper](https://steamdb.info/tokendumper)**. I dati inoltrati non includono alcuna informazione potenzialmente sensibile e non possiedono rischi di sicurezza/privacy, come dichiarato nella descrizione sopra.

---

## Abilitare il plugin

ASF viene rilasciato con il plugin `SteamTokenDumper` incluso nel rilascio, ma tale plugin è disabilitato per impostazione predefinita. È possibile abilitare il plugin impostando la proprietà `SteamTokenDumperPluginEnabled` nella configurazione globale di ASF a `true`, in sintassi JSON:

```json
{
  "SteamTokenDumperPluginEnabled": true
}
```

All'avvio dell'applicazione ASF, il plugin comunicherà se è stato abilitato con successo attraverso il meccanismo di logging standard. È inoltre possibile abilitare il plugin attraverso il generatore di configurazione web.

---

## Dettagli tecnici

All'abilitazione, il plugin userà i bot che esegui in ASF per la raccolta dei dati in forma di token del pacchetto, token dell'app e chiavi di depot cui i tuoi bot hanno accesso. Il modulo di raccolta dei dati include le routine passive e attive che dovrebbero minimizzare il sovraccarico aggiuntivo causato dalla raccolta di dati.

Per soddisfare il caso d'uso pianificato, oltre alla routine di raccolta dati sopra menzionata, la routine di invio è inizializzata come responsabile per la determinazione di quali dati vanno inviati a SteamDB su base periodica. Questa routine sarà eseguita fino a `1` ora dal tuo avvio di ASF, e si ripeterà ogni `24` ore. Il plugin farà del suo meglio per ridurre la quantità di dati che devono esser inviati, dunque è possibile che alcuni dati che il plugin raccoglie saranno determinati come inutili da inviare, e dunque saltati (per esempio l'aggiornamento dell'app che non cambia il token d'accesso).

Il plugin usa un database della cache persistente salvato nella posizione `config/SteamTokenDumper.cache`, che serve come scopo simile a `config/ASF.db` per ASF. Il file è usato per registrare i dati raccolti e inviati e minimizza la quantità di lavoro da eseguire per le diverse esecuzioni di ASF. Rimuovere il file causa il riavvio da zero del processo, cosa da evitare se possibile.

---

## Dati

ASF include il contributore `steamID` nella richiesta, determinato come `SteamOwnerID`, che imposti in ASF, o nel caso non lo avessi fatto, l'ID di Steam del bot che possiede gran parte delle licenze. Il contributore annunciato potrebbe ricevere vantaggi aggiuntivi da SteamDB per aiuto continuo (es. rango di donatore sul sito web), ma è totalmente a tua discrezione.

In ogni caso, lo staff di SteamDB vorrebbe ringraziarti in anticipo per il tuo aiuto. I dati inoltrati consentono a SteamDB di operare, in particolare per monitorare le informazioni sui pacchetti, le app e i depot, cosa che non sarà più possibile senza il tuo aiuto.

---

## Command

STD plugin comes with an extra ASF command, `std [Bots]`, which allows you to trigger refresh and submission for selected bots on demand. Using the command doesn't require enabled config, which allows you to skip automatic gathering and submission, and control the process yourself manually. Naturally it can also be executed with enabled config, which will simply trigger the usual gathering and submission procedures earlier than expected.

We recommend `!std ASF` in order to trigger refresh for all available bots. However, you can also trigger it for selected ones if you'd like to.

---

## Advanced config

Our plugin supports advanced config which might come useful for people that would like to tweak the internals to their preference.

The advanced config has the following structure located within `ASF.json`:

```json
{
  "SteamTokenDumperPlugin": {
    "Enabled": false,
    "SecretAppIDs": [],
    "SecretDepotIDs": [],
    "SecretPackageIDs": [],
    "SkipAutoGrantPackages": true
  }
}
```

Tutte le opzioni sono spiegate sotto:

### `Enabled`

`bool` type with default value of `false`. This property acts the same as `SteamTokenDumperPluginEnabled` root-level property explained above, and can be used instead, dedicated to people that would prefer to have entire plugin-related config in its own structure (so most likely those already using other advanced properties explained below).

---

### `SecretAppIDs`

Tipo `ImmutableHashSet<uint>` con valore predefinito vuoto. This property specifies `appIDs` that the plugin won't resolve, and if they're already resolved, won't submit the token for. This property can be useful for people with access to potentially-sensitive information about unpublished items, especially the developers, publishers or closed beta testers.

---

### `SecretDepotIDs`

Tipo `ImmutableHashSet<uint>` con valore predefinito vuoto. This property specifies `depotIDs` that the plugin won't resolve, and if they're already resolved, won't submit the key for. This property can be useful for people with access to potentially-sensitive information about unpublished items, especially the developers, publishers or closed beta testers.

---

### `SecretPackageIDs`

Tipo `ImmutableHashSet<uint>` con valore predefinito vuoto. This property specifies `packageIDs` (also known as `subIDs`) that the plugin won't resolve, and if they're already resolved, won't submit the token for. This property can be useful for people with access to potentially-sensitive information about unpublished items, especially the developers, publishers or closed beta testers.

---

### `SkipAutoGrantPackages`

`bool` tipo con valore predefinito `true`. This property acts very similar to `SecretPackageIDs` and when enabled, will cause packages with `EPaymentMethod` of `AutoGrant` to be skipped during resolve routine explained below. `AutoGrant` payment method is used by **[Steamworks](https://partner.steamgames.com)** to automatically grant packages on developer accounts. While this is not as explicit as other `Secret` options, and therefore doesn't guarantee anything (since you might have other packages than `AutoGrant` that you still don't want to submit), it should be good enough for skipping majority, if not all, of the secret packages. This option is enabled by default, as people that actually have access to `AutoGrant` packages will almost never want to leak those to general public, and therefore using value of `false` is very situational.

---

## Further explanation

At the root level, every Steam account owns a set of packages (licenses, subscriptions), which are classified by their `packageID` (also known as `subID`). Every package may contain several apps classified by their `appID`. Every app may then include several depots classified by their `depotID`.

```text
├── sub/124923
│     ├── app/292030
│     │     ├── depot/292031
│     │     ├── depot/378648
│     │     └── ...
│     ├── app/378649
│     └── ...
└── ...
```

Our plugin includes two routines which take into account skipped items - the resolve routine and submission routine.

The resolve routine is responsible for resolving the tree you can see above. By blacklisting the packages/apps/depots in advance, you'll effectively cut the tree in the place of blacklisted branch/leaf without additional need of specifying the remaining parts of it. In our example above, if `124923` package was ignored, whether by `SecretPackageIDs` or `SkipAutoGrantPackages`, and it was the only package you own which linked to the `292030` appID, then appID `292030` wouldn't get resolved either, and by definition, if there were no other resolved apps which linked to the `292031` and `378648` depots, then they wouldn't get resolved either. However, keep in mind that if the plugin has already resolved the tree, then effectively this will only stop given item from being updated (e.g. new apps added), it will not make the plugin "forget" about the existing items that were already resolved (e.g. apps found in that package before you decided to blacklist it). If you've just enabled some skipping options, and would like to ensure that ASF doesn't traverse the already-resolved tree, you may consider one-time removing `config/SteamTokenDumper.cache` file where the plugin keeps its cache.

The submission routine is responsible for submitting package tokens, app tokens and depot keys of already resolved items (by the resolve routine above). Here your blacklist has immediate effect, as even if the plugin has already resolved the info, the submission routine will not actually submit it over to SteamDB if you have it blacklisted, regardless if it has been resolved or not. Keep in mind however that we're not talking about the tree anymore at this point, the submission routine does not know whether the information about the app comes from this or that package, so it only skips information about particular, blacklisted items, regardless of the relation they're in with other.

For majority of the developers and publishers, it should be enough to enable `SkipAutoGrantPackages`, potentially empowered with `SecretPackageIDs` only, as it effectively cuts the tree at the beginning branch and guarantees that the apps and depots included further will not get submitted as long as there is no other package linking to the same app. If you want to be double sure, in addition to that you can also use `SecretAppIDs`, which will skip the resolve of the app even if there are some other licenses you didn't blacklist linking to it. Using `SecretDepotIDs` should not be needed, unless you have a particular, specific need (such as skipping only a particular depot while still submitting info about packages and apps), or if you want to add yet another layer to be triple safe.