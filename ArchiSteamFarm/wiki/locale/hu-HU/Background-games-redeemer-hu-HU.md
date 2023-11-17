# Beváltó

A háttérbeli játék beváltó egy speciális ASF funkció, amivel megadott Steam cd kulcsokat (a nevükkel együtt) tudsz beváltani a háttérben. Ez akkor lehet különösen hasznos, ha nagyon sok kulcsot szeretnél beváltani egyszerre és garantáltan elérnéd a `RateLimited` **[státuszt](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#what-is-the-meaning-of-status-when-redeeming-a-key)** mielőtt végeznél az összessel.

A háttérbeli játék beváltónak csak egyetlen bot hatásköre lehet, ez azt jelenti, hogy nem használhatja a `RedeemingPreferences`-t. Ezt a funkciót használhatod a `redeem` **[paranccsal](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** együtt (vagy ahelyett), ha szükséged lenne rá.

---

## Importálás

Az importálási folyamatot kétféleképpen lehet véghez vinni: fájllal, vagy IPC-vel.

### Fájl

Az ASF magától fel fogja ismerni a `config` könyvtárában a `BotNeve.keys` nevű fájlt, ahol `BotNeve` a botod neve. Attól a fájltól elvárjuk, hogy fix struktúrája legyen, vagyis soronként megtalálható benne a játék neve és a cd kulcs egymástól egy tabulátorral elválasztva, valamint minden sorban csak egy játék lehet. Ha egy sorban több tabulátor is van, akkor akkor az első tabulátor előtti szavak lesznek a játék neve, az utolsó pedig a cd kulcs, minden más ignorálva lesz. Például:

```text
POSTAL 2    ABCDE-EFGHJ-IJKLM
Domino Craft VR 12345-67890-ZXCVB
A Week of Circus Terror POIUY-KJHGD-QWERT
Terraria    EztIgnorálom   EztIsIgnorálom    ZXCVB-ASDFG-QWERT
```

Nem szükséges a játéknevek megadása, használhatsz csak kulcsokat is (de még mindig csak egy kulcs kerülhet egy sorba). Az ASF ebben az esetben a Steam válaszából fogja kinyerni a játék nevét (ha lehetséges). A kulcsok megjelöléséhez azt javasoljuk, hogy saját magad csináld, mivel csomagok beváltása esetén a Steam nem köteles értelmes nevet adni az aktiválandó játékoknak, az csakis a fejlesztőtől függ, így lehetséges, hogy rendes játékneveket fogsz látni, vagy csomag neveket (pl.: Humble Indie Bundle 18) vagy akár teljesen hibásakat és félrevezetőket (pl: Half-Life 4).

```text
ABCDE-EFGHJ-IJKLM
12345-67890-ZXCVB
POIUY-KJHGD-QWERT
ZXCVB-ASDFG-QWERT
```

Bármelyik formátumot is használnád az ASF importálni fogja a `keys` fájlodat, vagy a bot indulásakor, vagy a futtatás során. A fájl sikeres feldolgozása után (a hibás sorok kivételével) a detektált játékok hozzá lesznek adva egy háttérbeli várakozó listába, majd a `BotName.keys` fájl törölve lesz a `config` könyvtárból.

### IPC

A fentebb említett kulcs fájlok mellett az ASF biztosít egy `GamesToRedeemInBackground` nevű **[ASF API endpoint-ot](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-api)** is, amit egy IPC programmal lehet futtatni, ide értve a saját ASF-ui-unkat is. Az IPC használata akkor jöhet jól, ha te magad akarod elvégezni a kulcsok feldolgozását, mint például egyedi elválasztó karaktereket akarsz használni, mivel a tabulátorok neked nem megfelelőek, vagy akár teljesen más kulcs struktúrát akarsz használni.

---

## Várólista

Miután a játékok sikeresen importálva lettek, hozzá lesznek adva a várakozólistához. Az ASF automatikusan végigmegy a háttérbeli várakozólistáján abban az esetben, ha legalább egy bot csatlakozva van a Steam hálózatához és a várakozólista nem üres. Ha a beváltandó kulcs eredménye nem `RateLimited` lett, akkor a várakozólistából törölve lesz, majd az állapota bele lesz írva egy fájlba a `config` könyvtárban - a `BotNeve.keys.used` fájlba ha a kulcs fel lett használva (pl.: `NoDetail`, `BadActivationCode`, `DuplicateActivationCode`), vagy a `BotNeve.keys.unused` fájlba. Az ASF tudatosan az általad megadott játék nevet fogja használni, mivel nem garantált, hogy a Steam hálózat értelmes nevet fog visszaadni - így saját magadnak megjelölheted a kulcsaidat, akár egyedi nevekkel, ha szükséged van rá.

Ha a folyamat során az account `RateLimited` státuszt kapna, a várakozólista egy teljesen órán keresztül szüneteltetve lesz, hogy megvárja, míg lejár a státusz. Afterwards, the process continues where it left, until the entire queue is empty or another `RateLimited` occurs.

---

## Példa

Tegyük fel, hogy van egy listád 100 kulccsal. Először is létre kell hoznod egy új `BotNeve.keys.new` fájlt az ASF `config` könyvtárában. Azért tesszük a `.new` kiterjesztést a végére, hogy az ASF tudja, hogy nem kell ezt a fájlt azonnal feldolgoznia, amint létrejött (mivel egy újonnan létrehozott fájl üres lesz, tehát nincs mit rajta feldolgozni).

Most nyisd meg a fájlt és másold bele a 100 kulcsos listádat, majd javítsd ki a formátumot, ha szükséges. Miután kijavítottad a `BotNeve.keys.new` fájlban pontosan 100 sornak kell lennie (vagy 101, ha új sort kezdtél az utolsó kulcs után), ahol minden sor úgy néz ki hogy `JátékNeve\tcd kulcs\n`, ahol `\t` a tabulátor és `\n` az új sor.

Most már átnevezheted a fájlt `BotNeve.keys.new`-ról `BotNeve.keys`-re, hogy az ASF tudja, hogy már feldolgozhatja. Abban a pillanatban, hogy ez megtörténik, az ASF újraindítás nélkül, automatikusan betölti a fájlt, majd később törli azt, ami biztosíthat minket arról, hogy az összes játék fel lett dolgozva és hozzá lettek adva a várólistához.

A `BotNeve.keys` fájl helyett az IPC API végpontot is használhatod, vagy akár kombinálhatod is a kettőt.

Egy idő után két fájl lesz legenerálva: `BotNeve.keys.used` és `BotNeve.keys.unused`. Azok a fájlok tartalmazzák a beváltások eredményeit. Ilyenkor átnevezheted a `BotNeve.keys.unused` fájlt `MásodikBotNeve.keys`-re, így a fel nem használt fájlokat átadhatod egy másik bot számára, mivel az előző bot nem használta fel őket. Vagy szimplán másold be a fel nem használt kulcsokat egy másik fájlba, hogy majd később foglalkozol velük, ahogy szeretnéd. Tartsd észben, hogy ahogy az ASF végigmegy a várólistán, úgy lesznek új sorok hozzáadva a `used` és `unused` fájlokhoz, szóval érdemes megvárni, hogy a várólista kiürüljön, mielőtt használni szeretnéd ezeket a a fájlokat. Ha mindenképpen szükséged lenne azokra a fájlokra, még mielőtt a várólista kiürülne, akkor először is **mozgasd át** a kimeneti fájlt valamelyik másik könyvtárba, és **csak akkor** kezdd el feldolgozni. Ez azért fontos, mert az ASF lehet, hogy újabb sorokat fog a fájlok végére írni, miközben te teszed a saját dolgod és ez akár a kulcsok elvesztéséhez is vezethet, például amikor te megnyitottad a fájlt még csak 3 kulcs volt benne, utána törlöd a fájlt, de közben az ASF még 4 új kulcsot hozzáadott és ezt a 4 új kulcsot is letörölted. Ha meg akarod nyitni azokat a fájlokat, akkor légy biztos benne, hogy előtte elmozgatod őket az ASF `config` könyvtárából, vagy egyszerűen nevezd át őket.

A fentebb írtakat arra is fel lehet használni, hogy újabb játékokat adj hozzá a listához, miközben néhány játék már a várólistában van. Az ASF hozzá fogja adni az újabb sorokat a már futó várólistához és egyszer majd azok is sorra fognak kerülni.

---

## Megjegyzések

A háttérbeli játék beváltó `OrderedDictionary`-t használ a forráskódban, ami azt jelenti, hogy a cd kulcsaid abban a sorrendben lesznek feldolgozva, ahogy a fájlba (vagy az IPC API hívásba) lettek beírva. Ez azt jelenti, hogy úgy kell megadnod a cd kulcsokat, hogy egy kulcs függhet egy ő felette lévő sortól, de nem függhet egy alatta lévő sortól. Például, ha van egy `D` nevű DLC-d, aminek szüksége van a `J` nevű játékra, ahhoz, hogy aktiválni lehessen, akkor a `J` játéknak **minden esetben** a `D` nevű DLC előtt kell szerepelnie a listában. Ugyanígy ha a `D` DLC függene `A`-tól, `B`-től és `C`-től, akkor mindhármat előbbre kell venni (a sorrendjük mindegy, kivéve ha nekik is vannak függőségeik).

Ha nem követed a fentebb leírtakat, akkor a DLC-d nem lesz aktiválva `DoesNotOwnRequiredApp` eredménnyel, még akkor is, ha egyébként sikerülne a művelet egy második nekifutásra. Ha ezt el szeretnéd kerülni, akkor tegyél róla, hogy a DLC-d minden esetben az alapjáték után kerüljön be a várólistába.