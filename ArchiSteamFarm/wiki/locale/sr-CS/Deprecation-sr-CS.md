# Zastarenje

Od ASF V3.1.2.2, pratićemo konstantnu politiku zastarenja da bi usavršili razvijanje i da bi napravili korišćenje više konzistentnim.

---

## Šta je zastarenje?

Zastarenje je proces dodavanja manjih ili većih promjena koji pravi prethodno korišćene opcije, komande, funkcionalnosti ili načine korišćenja zastarelim. Zastarenje najčešće znači da je postojeća opcija prebačena u drugu (sličnu) formu, i da se treba omogućiti odrešeno vrijeme da napravite prelaz ka toj formi. U tom slučaju, to je premještanje date funkcionalnosti u prikladnijem mjestu.

ASF se brzo mijenja i uvijek cilja da postane bolji. Ovo nažalost znači da ćemo možda promijeniti ili pomjeriti postojeće funkcionalnosti u drugi segmenat programa da bi koristio od novih mogućnosti, kompatabilnosti ili stabilnosti. Zahvaljujući tome ne moramo da se zadržavamo na zastarelim ili pogrešnim odlukama developovanja koje smo davno napravili. Uvijek pokušavamo da damo razumne zamjene koje su prikladne očekivanim već postojećim funkcionalnostima, zbog čega je zastarenje najčešće bezopasno i zahtijeva male popravke prethodnog korišćenja.

---

## Faze zastarenja

ASF će pratiti 2 faze zastarenja, praveći tranziciju mnogo lakšom i jednostavnijom.

### Faza 1

Faza 1 dešava se kada data mogućnost zastari, sa trenutnom dostupnošću za drugu mogućnost (ili kompletnog uklanjanja iste ako ne postoje planovi da se ponovo doda).

Tokom ove faze, ASF će prikazivati prikladne upozorenja da je zastarela funkcija u vašoj upotrebi. Koliko god je to moguće, ASF će pokušati da oponaša staro ponašanje i da bude kompatabilna sa njim. ASF će ostati u fazi 1 bez obzira na tu funkcionalnost barem do sledećeg stabilnog izdanja. Ovo je vrijeme kad, nadamo se bez ikakvih kvarova kompatabilnosti, vi možete da napravite odgovarajući prelaz na svim vašim alatima ili načinimak korišćenja koje bi mogle da zadovolje vašu upotrebu. Možete potvrditi da li ste uradili sve potrebne promjene ako više ne vidite poruke o zastarenju.

### Faza 2

Faza 2 je zakazana nakon faze 1 objašnjene iznad i dešava se dok se ne objavi u stabilnoj verziji. Ova faza dodaje kompletno uklanjanje zastarele mogućnosti, što zači da ASF neće pokušati da prepozna da li je koristite, ili da je koristi, pošto ona više ne postoji u trenutnom kodu. ASF neće više prikazivati upozorenja, pošto više ne prepoznaje šta pokušavate da uradite.

---

## Zaključak

Imaćete oko **mjesec dana** da napravite odgovarajući prelaz, što je više nego potrebno bilo da ste obični ASF korisnik ili niste. Nakon tog perioda, ASF više ne garantuje da će stara podešavanja imati ikakvog efekta (faza 2), što znači da će ta funkcija skroz prestati da radi bez vašeg zapažanja. Ako niste pokretali ASF duže od jednog mjeseca, predlažemo da **[počnete ponovo](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up)**, ili pročitate listu promjena koju ste propusli i ručno podesite vaša podešavanja sa novim.

U najviše slučajeva, zanemarivanje opomena zastarenja neće napraviti ASF nefunkcionalnim, ali će ga vratiti nazad na opšta podešavanja (što možda neće odgovarati vašim ličnim potrebama i podešavanjima).

---

## Primer

Pomjerili smo pre-V3.1.2.2 `--server` **[komande](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments)** u `IPC` **[globalnu konfiguraciju](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#global-config)**.

### Faza 1

Faza 1 je dodata u verziji V3.1.2.2 gdje smo dodali prikladna upozorenja za korišćenje `--server` komande. Sada zastarela `--server` komanda je automatski promijenjena u `IPC: true` u globalnoj konfiguraciji, koja se trenutno ponaša isto kao stara `--server` komanda. Ovo omogućava svima da naprave zamjenu prije nego ASF prestane da prihvata staru komandu.

### Faza 2

Faza 2 je dodata u verziji V3.1.3.0, odmah nakon V3.1.2.9 stabilne verzije sa fazom 1 objašnjenom iznad. Faza 2 napravila je to da ASF skroz prestane da prepoznaje `--server` komandu, i ponašajući se prema njoj kao prema svakoj drugom nepravilnoj komandi, koja više nema nikakvog efekta na program. Za korisnike koji nisu promijenili njihovu `--server` komandu u `IPC: true`, desilo se to da je IPC prestao da funkcioniše, zato što ASF nije imao prikladna podešavanja.