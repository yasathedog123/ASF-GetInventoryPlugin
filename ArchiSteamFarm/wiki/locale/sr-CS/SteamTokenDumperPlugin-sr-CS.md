# SteamTokenDumperPlugin

`SteamTokenDumperPlugin` je oficijalni ASF **[dodatak](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)** koji je dostupan u ASF-u od V4.2.2.2, napravljen od strane naših developera, a koji vam omogućava da doprinesete **[SteamDB](https://steamdb.info)** projektu tako što ćete dijeliti tokene, tokene aplikacija i depot ključeve kojima vaš Steam nalog ima pristup. Više informacija o prikupljenim podacima i o tome zašto SteamDB ima potrebu za njim možete pronaći na SteamDB **[TokenDumper](https://steamdb.info/tokendumper)** stranici. Poslati podaci ne sadrže potencijalno osjetljive informacije, i nema sigurnosnih i rizika privatnosti, kao što je navedeno u opisu iznad.

---

## Omogućavanje dodatka

ASF ima ugrađen `SteamTokenDumperPlugin` sa izdanjima, ali je dodatak onemogućen sve dok ga vi ne uključite. Možete ga uključiti podešavanjem `SteamTokenDumperPluginEnabled` ASF kofiguracije na `true`, u JSON sintaksi:

```json
{
  "SteamTokenDumperPluginEnabled": true
}
```

Tokom pokretanja vašeg ASF programa, dodatak će vam kazati da li je pravilno omogućen tokom standardnig ASF izvještaja. Takođe možete omogućiti ovaj dodatak preko web-baziranog generatora.

---

## Tehnički detalji

Nakon omogućavanja, dodatak će koristiti botove koje su pokrenuti u ASF-u za prikupljanje podataka u formi paket tokena, aplikacionih tokena i depot ključeva kojima vaš bot ima pristup. Modul za prikupljanje podataka sadrži pasivnu i aktivnu rutinu koja bi trebala da smanji dodatne smetnje izazvane prikupljanjem podataka.

Da bi se ispunila planirana funkcionalnost, u sklopu sa prikupljanjem podataka objašnjenih iznad, rutina slanja određuje koji podaci nedostaju na SteamDB-u i šalje ih periodično. Ova rutina će se upaliti najkasnije `1` sat nakoš što upalite ASF, i ponavljaće se svakih `24` sata. Ovaj dodatak radi što najbolje može da bi odredio količinu podataka koju treba poslati, pa je zbog toga moguće da neke prikupljene podatke, koje dodatak prikupi, označi nepotrebnim, i zbog toga ih ne pošalje (kao što je ažuriranje aplikacija koje ne mijenja pristupni token).

Dodatak koristi trajnu keš bazu podataka koja se nalazi u `config/SteamTokenDumper.cache` lokaciji, koja služi sličnu funkciju kao `config/ASF.db` ASF-u. Fajl se koristi radi bilježenja prikupljenih podataka i poslatih podataka da bi smanjila količinu posla koji treba da uradi tokom raznim ASF pokretanja. Brisanje ovog fajla daje posledicu da se od ponovo napravi u sledećem pokretanju, a to treba izbjegavati, ako je moguće.

---

## Podaci

ASF uključuje `steamID` doprinosioca tokom slanja, koji je određen kao `SteamOwnerID` koji ste postavili u ASF, a ako niste koristiće se Steam ID bota koji sadrži najviše licenci. Navedeni dopinosioc će možda dobiti neke dodatne koristi od strane SteamDB-a za kontinuiranu pomoć (npr. donator rank na njihovom sajtu), ali to zavisi od strane SteamDB kompletno.

U svakom slučaju, SteamDB osoblje vam se unaprijed zahvaljuje na vašoj pomoći. Poslati podaci omogućavaju SteamDB-u da radi, posebno da prati promjene oko paketa, aplikacija i depotova, što nebi milo moguće bez vaše pomoći.

---

## Advanced config

Starting with ASF V5.1.0.0, our plugin supports advanced config which might come useful for people that would like to tweak the internals to their preference.

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

Sve opcije su objašnjene ispod:

### `Enabled`

`bool` type with default value of `false`. This property acts the same as `SteamTokenDumperPluginEnabled` root-level property explained above, and can be used instead, dedicated to people that would prefer to have entire plugin-related config in its own structure (so most likely those already using other advanced properties explained below).

---

### `SecretAppIDs`

`ImmutableHashSet<uint>` type with default value of being empty. This property specifies `appIDs` that the plugin won't resolve, and if they're already resolved, won't submit the token for. This property can be useful for people with access to potentially-sensitive information about unpublished items, especially the developers, publishers or closed beta testers.

---

### `SecretDepotIDs`

`ImmutableHashSet<uint>` type with default value of being empty. This property specifies `depotIDs` that the plugin won't resolve, and if they're already resolved, won't submit the key for. This property can be useful for people with access to potentially-sensitive information about unpublished items, especially the developers, publishers or closed beta testers.

---

### `SecretPackageIDs`

`ImmutableHashSet<uint>` type with default value of being empty. This property specifies `packageIDs` (also known as `subIDs`) that the plugin won't resolve, and if they're already resolved, won't submit the token for. This property can be useful for people with access to potentially-sensitive information about unpublished items, especially the developers, publishers or closed beta testers.

---

### `SkipAutoGrantPackages`

`bool` type with default value of `true`. This property acts very similar to `SecretPackageIDs` and when enabled, will cause packages with `EPaymentMethod` of `AutoGrant` to be skipped during resolve routine explained below. `AutoGrant` payment method is used by **[Steamworks](https://partner.steamgames.com)** to automatically grant packages on developer accounts. While this is not as explicit as other `Secret` options, and therefore doesn't guarantee anything (since you might have other packages than `AutoGrant` that you still don't want to submit), it should be good enough for skipping majority, if not all, of the secret packages. This option is enabled by default, as people that actually have access to `AutoGrant` packages will almost never want to leak those to general public, and therefore using value of `false` is very situational.

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