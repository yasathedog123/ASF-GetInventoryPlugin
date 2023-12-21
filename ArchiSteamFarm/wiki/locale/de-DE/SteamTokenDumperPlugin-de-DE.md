# SteamTokenDumperPlugin

`SteamTokenDumperPlugin` is official ASF **[plugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)** developed by us, which allows you to contribute to **[SteamDB](https://steamdb.info)** project by sharing package tokens, app tokens and depot keys that your Steam account has access to. Informationen zu den gesammelten Daten und warum SteamDB diese benötigt, findest Du auf der **[Token Dumper](https://steamdb.info/tokendumper)** Website von SteamDB. Die übermittelten Daten enthalten demnach keine potentiell sensiblen Informationen und bergen kein Sicherheits-/Datenschutzrisiko.

---

## Aktivierung des Plugins

Das `SteamTokenDumperPlugin` ist in der Releaseversion von ASF enthalten, jedoch ist das Plugin standardmäßig deaktiviert. Sie können das Plugin aktivieren, indem Sie die globale ASF Konfigurationseigenschaft `SteamTokenDumperPluginEnabled` auf `true` setzen. Im JSON-Syntax:

```json
{
 "SteamTokenDumperPluginEnabled": true
}
```

Beim Start von ASF teilt das Plugin über den Standard-Protokollierungsmechanismus mit, ob es erfolgreich aktiviert wurde. Sie können das Plugin auch über unseren webbasierten Konfigurationsgenerator aktivieren.

---

## Technische Details

Nach der Aktivierung verwendet das Plugin die Bots, die Sie in ASF betreiben, zur Datenerfassung in Form von Paket- und App-Tokens sowie Depot-Schlüsseln, auf die Ihre Bots Zugriff haben. Das Datenerfassungsmodul umfasst passive und aktive Routinen, die den durch die Datenerfassung verursachten zusätzlichen Aufwand minimieren sollen.

Um den geplanten Anwendungsfall zu erfüllen, wird zusätzlich zu der oben erläuterten Datenerfassungsroutine die Einreichungsroutine initialisiert, die dafür verantwortlich ist, zu bestimmen, welche Daten auf periodischer Basis an SteamDB übermittelt werden müssen. Diese Routine wird innerhalb von `1` Stunde nach dem Start von ASF ausgelöst und wiederholt sich alle `24` Stunden. Das Plugin wird sein Bestes tun, um die Menge der zu sendenden Daten zu minimieren. Daher ist es möglich, dass einige Daten, die das Plugin sammelt, als unbrauchbar zur Übermittlung eingestuft und daher übersprungen werden (z. B. ein App-Update, das das Zugriffstoken nicht ändert).

Das Plugin verwendet eine dauerhafte Cache-Datenbank, die in `config/SteamTokenDumper.cache` gespeichert ist, die einen ähnlichen Zweck wie `config/ASF.db` für ASF erfüllt. Die Datei wird verwendet, um die gesammelten und übermittelten Daten aufzuzeichnen und den Arbeitsaufwand, der bei verschiedenen ASF-Ausführungen anfällt, zu minimieren. Das Entfernen der Datei führt dazu, dass der Prozess von Grund auf neu gestartet wird, was nach Möglichkeit vermieden werden sollte.

---

## Daten

ASF schließt die `steamID` des Mitwirkenden in die Anfrage ein, die als `SteamOwnerID` bestimmt wird, die Sie in ASF festgelegt haben oder, falls Sie das nicht getan haben, die Steam-ID des Bots, der die meisten Lizenzen besitzt. Der angegebene Mitwirkende könnte einige zusätzliche Vorteile von SteamDB für kontinuierliche Hilfe erhalten (z. B. Spenderrang auf der Website), aber das liegt ganz im Ermessen von SteamDB.

In jedem Fall möchten sich die SteamDB-Mitarbeiter im Voraus für Ihre Hilfe bedanken. Die übermittelten Daten ermöglichen den Betrieb von SteamDB, insbesondere die Verfolgung von Informationen über Pakete, Anwendungen und Depots, was ohne Ihre Hilfe nicht mehr möglich wäre.

---

## Befehl

STD plugin comes with extra ASF command, `!std [Bots]`, which allows you to trigger refresh and submission for selected bots on demand. Using the command doesn't require enabled config, which allows you to skip automatic gathering and submission, and control the process yourself manually. Naturally it can also be executed with enabled config, which will simply trigger the usual gathering and submission procedures earlier than expected.

We recommend `!std ASF` in order to trigger refresh for all available bots. However, you can also trigger it for selected ones if you'd like to.

---

## Erweiterte Einstellungen

Our plugin supports advanced config which might come useful for people that would like to tweak the internals to their preference.

Die erweiterte Konfiguration hat folgende Struktur innerhalb von `ASF.json`:

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

Alle Optionen werden nachfolgend erklärt:

### `Enabled`

Typ `bool` mit dem Standardwert `false`. This property acts the same as `SteamTokenDumperPluginEnabled` root-level property explained above, and can be used instead, dedicated to people that would prefer to have entire plugin-related config in its own structure (so most likely those already using other advanced properties explained below).

---

### `SecretAppIDs`

Typ `ImmutableHashSet<uint>` mit einem leeren Standardwert. This property specifies `appIDs` that the plugin won't resolve, and if they're already resolved, won't submit the token for. This property can be useful for people with access to potentially-sensitive information about unpublished items, especially the developers, publishers or closed beta testers.

---

### `SecretDepotIDs`

Typ `ImmutableHashSet<uint>` mit einem leeren Standardwert. This property specifies `depotIDs` that the plugin won't resolve, and if they're already resolved, won't submit the key for. This property can be useful for people with access to potentially-sensitive information about unpublished items, especially the developers, publishers or closed beta testers.

---

### `SecretPackageIDs`

Typ `ImmutableHashSet<uint>` mit einem leeren Standardwert. This property specifies `packageIDs` (also known as `subIDs`) that the plugin won't resolve, and if they're already resolved, won't submit the token for. This property can be useful for people with access to potentially-sensitive information about unpublished items, especially the developers, publishers or closed beta testers.

---

### `SkipAutoGrantPackages`

Typ `bool` mit dem Standardwert `true`. This property acts very similar to `SecretPackageIDs` and when enabled, will cause packages with `EPaymentMethod` of `AutoGrant` to be skipped during resolve routine explained below. `AutoGrant` payment method is used by **[Steamworks](https://partner.steamgames.com)** to automatically grant packages on developer accounts. While this is not as explicit as other `Secret` options, and therefore doesn't guarantee anything (since you might have other packages than `AutoGrant` that you still don't want to submit), it should be good enough for skipping majority, if not all, of the secret packages. This option is enabled by default, as people that actually have access to `AutoGrant` packages will almost never want to leak those to general public, and therefore using value of `false` is very situational.

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