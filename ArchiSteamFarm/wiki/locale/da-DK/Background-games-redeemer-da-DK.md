# Produktaktivering i baggrunden

Produktaktivering i baggrunden er en specialindbygget ASF funktion som tillader dig at importere et givent sæt Steam cd-keys (med deres navne) som aktiveres i baggrunden. Dette er især nyttigt hvis du har mange nøgler der skal indløses og hvor du er sikker på at ramme `RateLimited` **[status](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#what-is-the-meaning-of-status-when-redeeming-a-key)** før du er færdig med hele partiet.

Produktaktivering i baggrunden er lavet til et enkelt bot-område, hvilket betyder at den ikke bruger `RedeemingPreferences`. Denne funktion kan bruges med (eller i stedet for) `reedem` **[kommando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**, om nødvendigt.

---

## Importer

Importering's processen kan gøres på to måder - enten ved brug af en fil eller via IPC.

### Fil

ASF vil i dens `config`-mappe genkende en fil med navnet `BotName.keys` hvor `BotName` er din bots navn. Denne fil har forventet og fast struktur af navnet på spillet med cd-nøglen, adskilt et tab tegn og slutning med en ny linje for at angive starten på den næste indtastning. Hvis der bruges flere tab tegn, ses den første indtastning som spillets navn, sidste indtastning en cd-nøgle og alt imellem disse ignoreres. For eksempel:

```text
POSTAL 2    ABCDE-EFGHJ-IJKLM
Domino Craft VR 12345-67890-ZXCVB
A Week of Circus Terror POIUY-KJHGD-QWERT
Terraria    DetteErIgnoreret   DetteErOgsåIgnoreret    ZXCVB-ASDFG-QWERT
```

Som et alternativ kan du også bruge "keys only format" (stadig med en ny linje mellem hver indtastning). ASF vil i dette tilfælde bruge Steam's svar (hvis muligt) til at udfylde det rigtige navn. For alle typer af nøgletagging anbefaler vi at du navngiver nøglerne selv, fordi pakker der indløses på Steam ikke skal følge den samme logik som det spil de aktiverer, så afhængigt af hvad udvikleren har indtastet kan du risikere at se det rigtige spilnavn, "Bundle"-navn (f.eks. Humble Indie Bundle 18) eller direkte forkert og potentielt skadelige navne (f.eks. Half-Life 4).

```text
ABCDE-EFGHJ-IJKLM
12345-67890-ZXCVB
POIUY-KJHGD-QWERT
ZXCVB-ASDFG-QWERT
```

Uanset hvilket format du vælger at bruge vil ASF importere din `nøgle` fil, enten ved bot start eller senere ved udførsel. Efter en vellykket analyse af din fil og eventuel fjernelse af ugyldige indtastninger, vil alle opdagede spil blive tilføjet til baggrundskøen og selve `BotName.keys`-filen vil blive fjernet fra `config`-mappen.

### IPC

Udover brugen af nøglefiler som nævnt ovenfor, kan ASF også bruge `GamesToRedeemInBackground` **[API endpoint](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-api)** som kan køres af alle IPC værktøjer, inklusiv vores ASF-ui. Brug af IPC kan være lettere da du selv kan analysere det nødvendige, som brugen af en brugerdefineret delimiter i stedet for at blive tvunget til at bruge tab-karakter eller endda at introducere din helt egen brugerdefinerede nøglestruktur.

---

## Kø

Når spil er succesfuldt importeret, er de tilføjet til køen. ASF går automatisk igennem dens baggrunds kø så længe at botten er tilsluttet til Steam netværket, og køen ikke er tom. En nøgle, der blev forsøgt at blive indløst og ikke resulterede i `RateLimited` fjernes fra køen, med dens status bliver skrevet ordentligt til en fil i `config` biblioteket - eller `BotName.keys.used` hvis nøglen blev brugt i processen (f.eks. `NoDetail`, `BadActivationCode`, `DuplicateActivationCode`) eller <0 >BotName.keys.unused</code> ellers. ASF bruger med vilje det angivne spillets navn, da nøglen ikke garanteres at få et meningsfuldt navn returneret af Steam-netværket - på denne måde kan du tagge dine nøgler ved hjælp af endda tilpassede navne, hvis det er nødvendigt / ønsket.

Hvis vores konto rammer `RateLimited` -status under processen, standses køen midlertidigt i en hel time for at vente på, at cooldown forsvinder. Afterwards, the process continues where it left, until the entire queue is empty or another `RateLimited` occurs.

---

## Eksempel

Lad os antage, at du har en liste med 100 nøgler. Først skal du oprette en ny `BotName.keys.new` fil i ASF `config` biblioteket. Vi tilføjede udvidelsen `.new` for at lade ASF vide, at den ikke skulle hente denne fil med det samme, når den er oprettet (da den er en ny tom fil, ikke klar til import endnu).

Nu kan du åbne vores nye fil og copy-paste listen over vores 100 nøgler der, hvorefter formatet kan rettes om nødvendigt. Efter rettelser vil vores `BotName.keys.new` fil have nøjagtigt 100 (eller 101 med den sidste nye linje), hver linje har en struktur på `GameName\tcd-nøgle\n`, hvor `\t` er fanebetegn og `\n` er nylinje.

Du er nu klar til at omdøbe denne fil fra `BotName.keys.new` til `BotName.keys` for at lade ASF vide, at den er klar til at blive hentet. I det øjeblik du gør dette, vil ASF automatisk importere filen (uden behov for genstart) og slette den bagefter og bekræfte, at alle vores spil blev analyseret og føjet til køen.

I stedet for at bruge `BotName.keys` -fil, kan du også bruge IPC API-endpoint eller endda kombinere begge, hvis du vil.

Efter nogen tid genereres `BotName.keys.used` og `BotName.keys.unused` filer. Disse filer indholder resultater af vores indløsnings process. For eksempel kunne du omdøbe `BotName.keys.unused` til `BotName2.keys` fil og derfor indsende vores ubrugte nøgler til en anden bot, da tidligere bot ikke benyttede sig af disse nøgler selv. Eller du kan blot copy-paste ubrugte nøgler til en anden fil og opbevare den til senere, dit valg. Husk, at når ASF går gennem køen, tilføjes nye entries til vores output `used` og `unused` filer, derfor anbefales det at vente på, at køen tømmes fuldstændigt før du bruger dem. Hvis du absolut skal havde adgang til disse filer, før køen er tømt fuldt, skal du først **move** output filen, du vil have adgang til et andet bibliotek, **then** analysere det. Dette skyldes, at ASF kan tilføje nogle nye resultater, mens du gør dine ting, og det kan potentielt føre til tab af nogle nøgler, hvis du læser en fil med f.eks. 3 nøgler i, og sletter det derefter, og glemmer helt det faktum, at ASF føjede 4 andre nøgler til din fjernede fil i mellemtiden. Hvis du vil havde adgang til disse filer, skal du sikrere dig at rykke dem væk fra ASF `config` mappen før du læser dem, ved for eksempelvis at gennavne dem.

Det er også muligt at tilføje ekstra spil til importering imens der allerede er nogle spil i vores kø, ved at gentage de øvrige trin igen. ASF vil sandsynligvis også tilføje vores ekstra enheder til allerede udegående kø og ordne det på et tidspunkt.

---

## Bemærkninger

Baggrunds produktaktivering bruger `OrderedDictionary` under hjelmen, hvilket betyder at dine cd-nøgler vil have bevaret ordre som de var specificeret i filen (eller IPC API kaldet). Dette betyder at du kan (og skulle helst) give en list hvor givet cd-nøgle kan kun havde direkte afhængigheder på cd-nøgler listet oven over, men ikke nedenunder. For eksempelvis, dette betyder at hvis du har DLC `D` som kræver spillet `G` at blive aktiveret som the første, så cd-nøgle for spillet `G` skulle **always** være inkluderet før cd-nøgle for DLC `D`. Ligeledes, hvis DLC `D` ville have afhængigheder af `A`, `B` og `C`, så skulle alle 3 blive inkluderet før (i hvilken som helst ordre, medmindre de har afhængigheder selv).

Hvis du ikke følger skemaet ovenfor, vil din DLC ikke blive aktiveret med `DoesNotOwnRequiredApp`, selvom din konto er berettiget til at aktivere den efter at have gennemgået hele køen. Hvis du vil undgå det så skal du helst sikre at din DLC altid er inkluderet efter basisspillet i din kø.