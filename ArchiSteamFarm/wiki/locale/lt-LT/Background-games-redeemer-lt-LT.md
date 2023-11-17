# Pasyvusis žaidimų aktyvatorius

Pasyvusis žaidimų aktyvatorius (angl. Background games redeemer) yra speciali ASF funkcija, kuri leidžia importuoti cd-raktus (kartu su jų vardais), kad jie būtų aktyvuoti fone. Tai ypač patogu, jei jūs turite daug raktų ir esate garantuoti gauti `RateLimited` **[statusą](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#what-is-the-meaning-of-status-when-redeeming-a-key)** prieš baigiant įvesti visą paketą.

Pasyvusis žaidimų aktyvatorius yra skirtas naudoti vienam botui, todėl jis nėra suderinamas kartu su `RedeemingPreferences`. Ši funkcija gali būti naudojama kartu su (arba vietoj) `redeem` **[komandos](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**, jei reikia.

---

## Įkėlimas

Įkėlimo procesas galima dvejais būdais - IPC arba naudojantis failu.

### Failas

ASF pats atpažins savo `konfiguracija` direktorijoje failą, pavadintą `BotName.keys` kur `RobotoVardas` jūsų boto pavadinimas. That file has expected and fixed structure of name of the game with cd-key, separated from each other by a tab character and ending with a newline to indicate the next entry. Jei keli TAB yra panaudoti, tuomet pirmasis yra laikomas žaidimo pavadiniu, o paskutinis įvestu raktu ir viskas tarp jų yra ignoruojama. Pavyzdys:

```text
POSTAL 2    ABCDE-EFGHJ-IJKLM
Domino Craft VR 12345-67890-ZXCVB
A Week of Circus Terror POIUY-KJHGD-QWERT
Terraria    TaiIgnoruojama  TaIgnoruojamaTaipPat   ZXCVB-ASDFG-QWERT
```

Alternatively, you're also able to use keys only format (still with a newline between each entry). ASF in this case will use Steam's response (if possible) to fill the right name. For any kind of keys tagging, we recommend that you name your keys yourself, as packages being redeemed on Steam do not have to follow logic of games that they're activating, so depending on what the developer has put, you may see correct game names, custom package names (e.g. Humble Indie Bundle 18) or outright wrong and potentially even malicious ones (e.g. Half-Life 4).

```text
ABCDE-EFGHJ-IJKLM
12345-67890-ZXCVB
POIUY-KJHGD-QWERT
ZXCVB-ASDFG-QWERT
```

Regardless which format you've decided to stick with, ASF will import your `keys` file, either on bot startup, or later during execution. Po sėkmingo jūsų failo analizavimo ir neteisingų įrašų ištrynimo, visi sėkmingai atpažinti žaidimai bus pridėti į aktyvatoriaus eilę ir `BotName.keys` failas pats bus ištrintas iš `config` direktorijos.

### IPC

In addition to using keys file mentioned above, ASF also exposes `GamesToRedeemInBackground` **[ASF API endpoint](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-api)** which can be executed by any IPC tool, including our ASF-ui. Using IPC could be more powerful, as you can do appropriate parsing yourself, such as using a custom delimiter instead of being forced to a tab character, or even introducing your entirely own customized keys structure.

---

## Eilė

Kai žaidimai yra sėkmingai importuoti, jie yra pridedami į eilę. ASF automatiškai patikrina eilę fone tol, kol botas yra prisijungęs prie Steam tinklo ir eilė nėra tuščia. Raktas, kuris buvo bandytas panaudoti ir negavo rezultato `RateLimited` yra ištrinamas iš eilės su teisingu statusus, įrašytu į failą `config` direktorijoje - arba `BotName.keys.used`, jei buvo panaudoti procese (pvz., `NoDetail`, `BadActivationCode`, `DuplicateActivationCode`) arba `BotName.keys.unused` jei nebuvo. ASF specialiai naudoja vartotoja pateiktą vardą, nes nėra garantijos, jog Steam tinklas atsakys tinkamu ir suprantamu žaidimo vardu - tokiu būdu jūs galit žymėti raktus savo pasirinktais vardais.

Jei proceso metu gaunamas `RateLimited` statusas, eilė yra laikinai sustabdoma vienai valandai, tam jog atsipirkimo laikas sumažėtų. Afterwards, the process continues where it left, until the entire queue is empty or another `RateLimited` occurs.

---

## Pavyzdys

Tarkime jūs turime 100 raktų sąrašą. Pirmiausiau reikėtų sukurti naują `BotName.keys.new` failą ASF `config` direktorijoje. Mes pridedame `.new` išplėtimą (BotName.keys --> BotName.keys.new), kad ASF suprastų jog šio failo nereikėtų skaityti iškarto, kai tik jis yra sukuriamas (nes tai yra naujas failas, neparengtas importuoti).

Dabar jūs galit atidaryti failą ir kopijuoti-įklijuoti 100 raktų, pataisant formatą, jei reikia. Po pataisymų `BotName.keys.new` failas turės lygiai 100 (arba 101 su paskutine eilute) eilučių; kiekviena eilutė turi `GameName\tcd-key\n`, kur `\t` TAB ir `\n` yra nauja eilutė, struktūrą.

Dabar jau galima pervadinti šį failą iš `BotName.keys.new` į `BotName.keys` tam, kad ASF suprastų, jog jį jau galima atidaryti. Iškarto tai padarius, ASF automatiškai importuos failą (ASF paleisti iš naujo nereikia) ir ištrins, patvirtindamas, jog žaidimai buvo pridėti į eilutę ir patikrinti.

Vietoj `BotName.keys` failo galima naudoti IPC API arba netgi sujungti abu procesus kartu.

After some time, `BotName.keys.used` and `BotName.keys.unused` files will be generated. Šia failai - mūsų žaidimų panaudojimo rezultatas. Pavyzdžiui, galima pervadinti `BotName.keys.unused` į `BotName2.keys` ir tuomet nepanaudoti raktai bus naudojami kitų botų. Arba nepanaudotus raktus tiesiog galima perkelti į kitą failą ir panaudoti kažkam kitam. Tiesa, geriausia palaukti, kol eilė bus baigta ir `used` ir `unused` failai bus sugeneruoti, taip žinosite, jog visi raktai buvo patikrinti. Jeigu jum labai reikia patikrinti šiuos failus prieš eilės užbaigimą, pirmiausiai reikėtų **perkelti** rezultato failus į kitą direktoriją, tik **tada** juos tikrinti. Taip yra todėl, jog ASF gali pridėti naujų rezultatų kol jūs juos peržiūrite ir taip keli raktai gali būti prarasti, pvz., galite faile pamatyti 3 raktus, failą ištrinti, kai ASF tuo metu pridės ketvirtą raktą - taip jis bus prarastas. Jei nori pasiekti šiuos failus, tuomet perkelkite juos iš ASF `config` direktorijos prieš juos peržiūrint, ar pvz., pervadinant.

Taip pat įmanoma pridėti papildomų žaidimų pakartojant visus žingsnius viršuje, kol yra kitų žaidimų eilėje. ASF tinkamai pridės papildomų įrašų į jau veikiančią eilę ir galiausiai ją panaudos.

---

## Pastabos

Pasyvusis žaidimų aktyvatorius naudoja `OrderedDictionary`, todėl kodai bus naudojama failo eilės surąšymo tvarka (arba IPC API). Tai reiškia, jog jūs galite (ir tūrėtumėte) pateikti sąrašą, kuriame raktai yra surašyti pagal priklausomybę nuo viršaus, bet ne nuo apačios. Pavyzdžiui, jūs turite DLC `D` kuriam reikia žaidimo `G`, kuris turi būti aktyvuotas pirmiau, tuomet žaidimo raktas `G` tūrėtų **visada** būti pirmiau prieš DLC `D` raktą. Taip pat jei DLC `D` turi priklausomybę nuo `A`, `B` ir`C`, tuomet visi 3 tūrėtų būti surašyti pirmiau (betkokia tvarka, jei jie neturi priklausomybių).

Nenaudojant šios schemos, DLC nebus aktyvuotas su rezultatu `DoesNotOwnRequiredApp` net patikrinus visą eilę. Jei norite šito išvengti, tuomet visada privalote DLC aktyvuoti po žaidimo, nuo kurio DLC priklauso.