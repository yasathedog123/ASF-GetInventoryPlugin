# Pelien lunastaminen taustalla

Pelien lunastaminen taustalla on erityinen sisäänrakennettu ominaisuus ASF: ään, joka mahdollistaa lisätä kerralla useita Steam-pelikoodeja (niiden nimien kanssa) lunastettavaksi taustalla. Tämä on erityisen hyödyllistä, jos sinulla on paljon lunastavia avaimia ja olet varma `RateLimited` **[tila](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#what-is-the-meaning-of-status-when-redeeming-a-key)** ennen kuin olet tehnyt koko erän.

Taustalla pelien lunastaja on tehty sille, että on yksi botti skooppi, mikä tarkoitta että se ei ota hyötyä `RedeemingPreferences: tä.`. Tätä ominaisuutta voidaan käyttää tarvittaessa yhdessä `lunastaa` **[komennon](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**kanssa.

---

## Tuonti

Tuontiprosessi voidaan tehdä kahdella tavalla - joko tiedoston avulla tai IPC: n avulla.

### Tiedosto

ASF tunnistaa `config` -hakemistossa tiedoston nimeltä `BotName.keys` jossa `BotName` on botin nimi. Tämä tiedosto on odottanut ja kiinteä rakenne nimi pelin cd-avain, erotettu toisistaan välilehdessä ja päättyen uudempaan linjaan, joka ilmaisee seuraavan merkinnän. Jos käytetään useita välilehtejä, ensimmäinen merkintä katsotaan pelin nimi, viimeinen merkintä pidetään cd-avain, ja kaikki välissä jätetään huomiotta. Esimerkiksi:

```text
POSTAL 2 ABCDE-EFGHJ-IJKLM
Domino Craft VR 12345-67890-ZXCVB
A Week of Circus Terror POIUY-KJHGD-QWERT
Terraria ThisIgnored ThisIgnoredToo ZXCVB-ASDFG-QWERT
```

Vaihtoehtoisesti voit myös käyttää näppäimiä vain muodossa (vielä uusi viiva jokaisen sisäänkäynnin välillä). ASF käyttää tässä tapauksessa Steamin vastausta (jos mahdollista) oikean nimen täyttämiseen. Minkä tahansa avaimet ovat, suosittelemme, että voit nimetä avaimet itse, koska pakettien lunastetaan Steamissa, ei tarvitse noudattaa niiden aktivoituvien pelien logiikkaa, joten riippuen siitä, mitä kehittäjä on tehnyt, voit nähdä oikeat pelien nimet, mukautettuja pakettien nimet (e.. Humble Indie Bundle 18) tai suoranainen väärä ja mahdollisesti jopa pahansuopia (esim. Half-Life 4).

```text
ABCDE-EFGHJ-IJKLM
12345-67890-ZXCVB
POIUY-KJHGD-QWERT
ZXCVB-ASDFG-QWERT
```

Riippumatta siitä, missä muodossa olet päättänyt pitää kiinni, ASF tuo `avaimesi` tiedoston joko botin käynnistyessä tai myöhemmin suorituksen aikana. Onnistuneen jäsentämisen jälkeen tiedosto ja lopulta pois virheellisiä merkintöjä, kaikki asianmukaisesti havaitut pelit lisätään taustajonoon ja `BotName. eys` tiedosto itsessään poistetaan `config` -hakemistosta.

### IPC

Edellä mainitun avaimen käytön lisäksi ASF paljastaa myös `PelitToRedeemInBackground` **[ASF API päätepiste](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-api)** jotka voidaan suorittaa millä tahansa IPC-työkalulla, mukaan lukien ASF-ui. IPC: n käyttö voisi olla tehokkaampaa, koska voit tehdä sopivan jäsennyksen itse, kuten käyttämällä mukautetun erottimen sen sijaan on pakko välilehti merkki, tai jopa ottamalla käyttöön täysin omia räätälöityjä avaimia rakenne.

---

## Jono

Kun pelit on tuotu onnistuneesti, ne lisätään jonoon. ASF käy automaattisesti taustajonon läpi niin kauan kuin botti on kytketty Steam-verkkoon, ja jono ei ole tyhjä. Avain, joka pyrittiin lunastamaan ja joka ei johtanut `RateLimited`, poistetaan jonosta, jonka tila on asianmukaisesti kirjoitettu tiedostoon `config` -hakemistossa - joko `BotName. uu. sed` jos avain on käytetty prosessissa (esim. `NoDetail`, `BadActivationCode`, `DuplicateActivationCode`) tai `BotName.keys.unused` otherwise. ASF käyttää tarkoituksellisesti tarjotun pelin nimeä, koska avain ei ole taattu, että Steam-verkko palauttaa mielekkään nimen - tällä tavoin voit merkitä avaimia jopa mukautettujen nimien avulla, jos tarvitaan/halutaan.

Jos prosessin aikana tilisi osumia `RateLimited` tila, jono keskeytetään väliaikaisesti koko tunnin ajaksi, jotta jäähtymistä voidaan odottaa häviävän. Afterwards, the process continues where it left, until the entire queue is empty or another `RateLimited` occurs.

---

## Esimerkki

Oletetaan, että sinulla on luettelo jossa on 100 avainta. Ensinnäkin sinun pitäisi luoda uusi `BotName.keys.new` tiedosto ASF `config` hakemistoon. Lisäsimme `. ew` laajennus jotta ASF tietää, että sen ei pitäisi noutaa tätä tiedostoa heti kun se on luotu (koska se on uusi tyhjä tiedosto, ei ole vielä valmis tuotavaksi).

Nyt voit avata uuden tiedoston ja kopioida liitä luettelo meidän 100 avaimet siellä, vahvistamalla muoto tarvittaessa. Korjausten jälkeen meidän `BotName.keys. ew` tiedostossa on täsmälleen 100 (tai 101, viimeisellä uudella rivillä) jokainen rivi, jolla on rakenne `GameName\tcd-näppäin\n`, jossa `\t` on välilehden merkki ja `\n` on uudempi.

Olet nyt valmis nimeämään tämän tiedoston `BotName.keys.new` osoitteesta `BotName. eys` jotta ASF voi tietää, että se on valmis poimittavaksi. Kun teet tämän, ASF tuo tiedoston automaattisesti (ilman uudelleenkäynnistystä) ja poistaa sen myöhemmin, vahvistaa, että kaikki pelimme oli jäsennetty ja lisätty jonoon.

Sen sijaan, että käytät `BotName.keys` tiedostoa, voit myös käyttää IPC API päätepistettä tai jopa yhdistää molemmat haluat.

Jonkin ajan kuluttua luodaan `BotName.keys.used` ja `BotName.keys.unused` -tiedostoja. Nämä tiedostot sisältävät tulokset lunastamisprosessista. Voit esimerkiksi nimetä `BotName.keys.unused` `BotName2. eys` tiedosto ja siksi lähetä käyttämättömät avaimemme jollekin muulle bot, koska edellinen botti ei käyttänyt näitä avaimia itse. Tai voit yksinkertaisesti kopioida käyttämättömiä avaimia johonkin muuhun tiedostoon ja pitää sen myöhemmin, puhelusi. Muista, että ASF menee läpi jonon, uudet merkinnät lisätään tulosteeseemme `käytettyihin` ja `käyttämättömiin` tiedostoihin, siksi on suositeltavaa odottaa, että jono tyhjennetään kokonaan ennen kuin niitä käytetään. Jos ehdottomasti sinun täytyy käyttää näitä tiedostoja ennen kuin jono on täysin tyhjennetty, ensin **siirrä** tiedostoa, jonka haluat käyttää jotain muuta hakemistoa, **sitten** jäsentää sen. Tämä johtuu siitä, että ASF voi lisätä joitakin uusia tuloksia, kun teet mitään, ja se voi mahdollisesti johtaa joidenkin avainten menetykseen, jos luet tiedoston ottaa e.. 3 avaimet sisällä, sitten poistaa se, täysin puuttuu se, että ASF lisäsi 4 muita avaimia poistaa tiedoston sillä välin. Jos haluat käyttää näitä tiedostoja, varmista, että siirrä ne pois ASF `config` -hakemistosta ennen niiden lukemista esimerkiksi nimeämällä ne uudelleen.

On myös mahdollista lisätä ylimääräisiä pelejä tuoda vaikka ottaa joitakin pelejä jo meidän jonossa, toistamalla kaikki edellä vaiheet. ASF lisää asianmukaisesti ylimääräisiä merkintöjä jo käynnissä jonoon ja käsitellä sitä lopulta.

---

## Huomautukset

Taustaavaimet lunastaja käyttää `Tilaussanakirja` hupun alla, mikä tarkoittaa, että cd-avaimesi on säilynyt järjestyksessä, kuten ne on määritelty tiedostossa (tai IPC API call). Tämä tarkoittaa, että voit (ja pitäisi) antaa listan, jossa annettu cd-näppäin voi olla vain suoraa riippuvuutta cd-näppäimistä, mutta ei alla. Esimerkiksi Tämä tarkoittaa, että jos sinulla on DLC `D`, joka vaatii pelin `G` aktivoitumisen ensinnäkin, sitten cd-näppäin pelin `G` pitäisi **aina** sisällytetään ennen cd-näppäintä DLC `D`. Vastaavasti, jos DLC `D` olisi riippuvuuksia `A`, `B` ja `C`, sitten kaikki 3 olisi sisällytettävä ennen (missään järjestyksessä, ellei heillä ole riippuvuutta omasta).

Jos et seuraa yllä olevaa järjestelmää, ei DLC-toimintoa aktivoida `DoesNotOwnRequiredApp`, vaikka tilisi olisi oikeutettu aktivoimaan sen koko jonon läpikäymisen jälkeen. Jos haluat välttää, että sinun on varmistettava, että DLC on aina mukana peruspelin jälkeen jonossa.