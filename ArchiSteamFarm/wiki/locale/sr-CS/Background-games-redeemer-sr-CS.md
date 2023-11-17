# Pozadinsko unošenje ključeva za igrice

Pozadinsko unošenje ključeva je specijalna ASF mogućnost koja dozvoljava da unesete Steam cd-ključeve (zajedno sa njihovim imenima) da bi otključali njima igrice u pozadini. Ovo je veoma korisno ako imate dosta ključeva koje želite da unesete, a u tom slučaju vjerovatno ćete dostići `RateLimited`**[status](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#what-is-the-meaning-of-status-when-redeeming-a-key)** prije nego što završite sa cijeliom grupom.

Pozadnisko unošenje je napravljeno je da se odnosi na jednog bota, što znači da ne koristi `RedeemingPreferences`. Ova mogućnost se može koristiti zajedno sa (ili umjesto) `redeem` **[komande](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**, ako je potrebno.

---

## Unos

Unošenje se može obaviti na dva načina - pomoću fajla, ili IPC-a.

### Fajl

ASF prepoznaje u svojem `config` direktorijumu fajl pod nazivod `ImeBota.keys` gdje je `ImeBota` ime vašeg bota. Ovaj fajl ima određenu i fiksnu strukturu sa imenom igrice i ključem, koji su odbojeni tabom i zavšavaju se u novoj liniji kojom tako prikazuju novi unos. Ako je više tabova korišćeno, prvi strana se smatra imenom igrice, druga se smatra ključem, a sve između je ignorisano. Na primjer:

```text
POSTAL 2    ABCDE-EFGHJ-IJKLM
Domino Craft VR 12345-67890-ZXCVB
A Week of Circus Terror POIUY-KJHGD-QWERT
Terraria    OvoJeIgnorisano   OvoJeTakođeIgnorisano    ZXCVB-ASDFG-QWERT
```

Takođe možete unositi samo ključeve (po jedan u svakoj liniji). ASF će u tom slučaju koristiti odgovor sa Steam (ako je moguće) da prikaže odogvarajuće ime. Za bilo koju vrstu tagovanja ključeva, mi predlažemo da ispišete imena vi sami, zato što paketi koji otključavate na Steam-u ne moraju da prate logiku imena igrica koje aktivirate, pa u zavisnosti od toga što je developer napisa, možete vidjeti tačna imena, imena paketa (npr. Humble Indie Bundle 18) ili skroz pogrešna i zlobna imena (npr. Half-Life 4).

```text
ABCDE-EFGHJ-IJKLM
12345-67890-ZXCVB
POIUY-KJHGD-QWERT
ZXCVB-ASDFG-QWERT
```

Bez obzira koji format izaberete, ASF će unijeti vaš `keys` fajl, ili tokom pokretanja, ili kasnije dok bude radio. Nakon uspješnog pregledanja vašeg fajla i izostavljanja nepravilnih unosa, sve novopronađene igrice će biti dodate u red za farmanje, i `ImeBota.keys` fajl će biti uklonjen iz `config` direktorijuma.

### IPC

U dodatku sa fajlom za ključeve iznad, ASF takođe posjeduje `GamesToRedeemInBackground` **[ASF API tačku](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-api)** koja može biti korišćena u bilo kojoj IPC alatki, uključujući i ASF-ui. Korišćenje IPC-a može biti veoma korisno pošto možete da koristite vaš način odvajanja umjesto taba, ili da napravite neki vaš način za unošenje ključeva.

---

## Red

Kada su igrice uspješno upešene, biće dodate u red. ASF automatski ide kroz taj red sve doj je bot konektovan sa Steam mrežom, i dok red nije prazan. A key that was attempted to be redeemed and did not result in `RateLimited` is removed from the queue, with its status properly written to a file in `config` directory - either `BotName.keys.used` if the key was used in the process (e.g. `NoDetail`, `BadActivationCode`, `DuplicateActivationCode`), or `BotName.keys.unused` otherwise. ASF intentionally uses your provided game's name since key is not guaranteed to have a meaningful name returned by Steam network - this way you can tag your keys using even custom names if needed/wanted.

If during the process our account hits `RateLimited` status, the queue is temporarily suspended for a full hour in order to wait for cooldown to disappear. Afterwards, the process continues where it left, until the entire queue is empty or another `RateLimited` occurs.

---

## Primjer

Pretpostavimo da imate listu sa 100 ključeva. Prvo što trebate uraditi je da napravite novi `ImeBota.keys.new` fajl u ASF-ov `config` direktorijumu. We appended `.new` extension in order to let ASF know that it shouldn't pick up this file immediately the moment it's created (as it's new empty file, not ready for import yet).

Now you can open our new file and copy-paste list of our 100 keys there, fixing the format if needed. After fixes our `BotName.keys.new` file will have exactly 100 (or 101, with last newline) lines, each line having a structure of `GameName\tcd-key\n`, where `\t` is tab character and `\n` is newline.

You're now ready to rename this file from `BotName.keys.new` to `BotName.keys` in order to let ASF know that it's ready to be picked up. The moment you do this, ASF will automatically import the file (without a need of restart) and delete it afterwards, confirming that all our games were parsed and added to the queue.

Instead of using `BotName.keys` file, you could also use IPC API endpoint, or even combining both if you want to.

After some time, `BotName.keys.used` and `BotName.keys.unused` files will be generated. Those files contain results of our redeeming process. For example, you could rename `BotName.keys.unused` into `BotName2.keys` file and therefore submit our unused keys for some other bot, since previous bot didn't make use of those keys himself. Or you could simply copy-paste unused keys to some other file and keep it for later, your call. Keep in mind that as ASF goes through the queue, new entries will be added to our output `used` and `unused` files, therefore it's recommended to wait for the queue to be fully emptied before making use of them. If you absolutely must access those files before queue is fully emptied, you should firstly **move** output file you want to access to some other directory, **then** parse it. This is because ASF can append some new results while you're doing your thing, and that could potentially lead to loss of some keys if you read a file having e.g. 3 keys inside, then delete it, totally missing the fact that ASF added 4 other keys to your removed file in the meantime. If you want to access those files, ensure to move them away from ASF `config` directory before reading them, for example by rename.

It's also possible to add extra games to import while having some games already in our queue, by repeating all above steps. ASF will properly add our extra entries to already-ongoing queue and deal with it eventually.

---

## Primedbe

Background keys redeemer uses `OrderedDictionary` under the hood, which means that your cd-keys will have preserved order as they were specified in the file (or IPC API call). This means that you can (and should) provide a list where given cd-key can only have direct dependencies on cd-keys listed above, but not below. For example, this means that if you have DLC `D` that requires game `G` to be activated firstly, then cd-key for game `G` should **always** be included before cd-key for DLC `D`. Likewise, if DLC `D` would have dependencies on `A`, `B` and `C`, then all 3 should be included before (in any order, unless they have dependencies on their own).

Not following the scheme above will result in your DLC not being activated with `DoesNotOwnRequiredApp`, even if your account would be eligible for activating it after going through its entire queue. If you want to avoid that then you must make sure that your DLC is always included after the base game in your queue.