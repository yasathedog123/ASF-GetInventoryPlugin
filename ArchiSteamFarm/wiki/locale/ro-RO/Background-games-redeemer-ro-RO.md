# Activatorul de coduri în plan secundar

Activatorul de coduri în plan secundar este o caracteristică ASF special încorporată care vă permite să importați un set de coduri Steam (împreună cu numele lor) pentru a fi răscumpărate în fundal. Acest lucru este util în special dacă ai o mulțime de chei pe care să le revendici și îți garantez că vei atinge statusul `RateLimited` **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#what-is-the-meaning-of-status-when-redeeming-a-key)** înainte de a termina cu întregul tău lot.

Activatorul de coduri în plan secundar este făcut să aibă un singur domeniu de aplicare al botului, ceea ce înseamnă că nu folosește `RedeemingPreferences`. Această caracteristică poate fi folosită împreună (sau în loc de) **[comanda](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** `redeem`, dacă este necesar.

---

## Importă

Procesul de import poate fi realizat prin două căi - fie prin utilizarea unui fișier sau a unui IPC.

### Fișier

ASF va recunoaște în directorul său `config` un fișier numit `BotName.keys` unde `BotName` este numele botului tău. Acel fișier are o structură fixă compusă din numelui jocului şi cd-key, separate unul de celălalt de un caracter tab şi se termină cu o nouă linie pentru a indica următoarea intrare. Dacă sunt folosite mai multe caractere tab, prima intrare este considerată numele jocului, ultima intrare este considerată o cheie cd-key, și totul în intervalul este ignorat. De exemplu:

```text
POSTAL 2    ABCDE-EFGHJ-IJKLM
Domino Craft VR 12345-67890-ZXCVB
A Week of Circus Terror POIUY-KJHGD-QWERT
Terraria    ThisIsIgnored   ThisIsIgnoredToo    ZXCVB-ASDFG-QWERT
```

Alternativ, poți folosi doar formatul cu valorile cheilor (cu o nouă linie între fiecare intrare). ASF în acest caz va utiliza răspunsul Steam (dacă este posibil) pentru a completa numele corect. Pentru orice fel de marcare a cheilor, vă recomandăm să vă denumiți singuri cheile, deoarece pachetele răscumpărate pe Steam nu trebuie să urmeze logica jocurilor pe care le activează, în funcție de ceea ce a pus dezvoltatorul, puteți vedea numele jocului corect, numele pachetelor personalizate (de ex. Humble Indie Bundle 18) sau complet greșite și chiar răuvoitoare (de ex. Half-Life 4).

```text
ABCDE-EFGHJ-IJKLM
12345-67890-ZXCVB
POIUY-KJHGD-QWERT
ZXCVB-ASDFG-QWERT
```

Indiferent de formatul cu care ați decis să rămâneți, ASF va importa fișierul `keys`, fie la pornirea botului, fie mai târziu în timpul execuției. După analiza cu succes a fişierului şi în cele din urmă omite intrările nevalide, toate jocurile corect detectate vor fi adăugate la coada de fundal şi fișierul `BotName.keys` în sine va fi șters din directorul `config`.

### IPC

În plus față de utilizarea cheilor menționate mai sus, ASF expune și `GamesToRedeemInBackground` **[ASF API endpoint](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-api)** care poate fi executat de orice instrument IPC, inclusiv ASF-ui. Folosirea IPC ar putea fi mai puternică, pentru că te poți ocupa de procesare singur, cum ar fi utilizarea unui delimitator personalizat în loc să fie forțat la un caracter tab, sau chiar introducerea propriei structuri a cheilor personalizate.

---

## Coadă

Odată ce jocurile au fost importate cu succes, acestea sunt adăugate la coadă. ASF trece automat prin coada sa de fundal atâta timp cât bot-ul este conectat la rețeaua Steam, iar coada nu este goală. O cheie care a încercat să fie răscumpărată și nu a rezultat în `RateLimited` a fost eliminată din coadă, cu starea sa scrisă corect într-un fișier în directorul `config` - fie `BotName.keys.used` dacă cheia a fost folosită în proces (de ex. `NoDetail`, `BadActivationCode`, `DuplicateActivationCode`), sau `BotName.keys.unused` în alt caz. ASF folosește în mod intenționat numele jocului furnizat, deoarece cheia nu este garantată pentru a avea un nume semnificativ returnat de rețeaua Steam - în acest fel puteți eticheta cheile folosind chiar nume personalizate, dacă este necesar/dorit.

Dacă în timpul procesului contul nostru lovește starea `RateLimited`, coada de așteptare este suspendată temporar pentru o oră întreagă pentru a aștepta ca procesul de cooldown să dispară. Afterwards, the process continues where it left, until the entire queue is empty or another `RateLimited` occurs.

---

## Exemplu

Să presupunem că ai o listă de 100 de chei. În primul rând ar trebui să creați un nou fișier `BotName.keys.new` în directorul ASF `config`. Am adăugat extensia `.new` pentru a anunța ASF că nu ar trebui să preia acest fișier imediat ce este creat (deoarece este un fișier nou gol, nu este gata pentru import încă).

Acum poți deschide noul fișier și copia lista celor 100 de chei aici, reparând formatul dacă este necesar. După remediere fișierul `BotName.keys.new` va avea exact 100 (sau 101, cu ultimele noduri) linii, fiecare linie cu o structură de `NumeJoc\tcd-key\n`, unde `\t` este caracterul tab și `\n` este un caracter de linie noua.

Acum ești gata să redenumești acest fișier din `BotName.keys.new` în `BotName.keys` pentru a informa ASF că este gata să fie preluat. În momentul în care faceți acest lucru, ASF va importa automat fișierul (fără a fi nevoie de repornire) și îl va șterge după, confirmând că toate jocurile noastre au fost procesate şi adăugate la coadă.

În loc să utilizați fișierul `BotName.keys`, ați putea folosi și IPC API sau chiar combinarea amândurora dacă doriți.

După ceva timp, fișierele `BotName.keys.used` și `BotName.keys.unused` vor fi generate. Aceste fișiere conțin rezultatele procesului nostru de rambursare. De exemplu, ai putea redenumi fișierul `BotName.keys.unused` în `BotName2.keys` și, prin urmare, trimiteți cheile neutilizate pentru un alt bot, deoarece bot-ul anterior nu a folosit el însuși aceste chei. Sau ai putea pur și simplu să copiezi cheile nefolosite într-un alt fișier și să le păstrezi pentru mai târziu, decizia ta. Rețineți că, pe măsură ce ASF trece prin coadă, intrările noi vor fi adăugate la fişierele `used` şi `unused`, de aceea este recomandat să aşteptaţi golirea completă a cozii înainte de a le folosi. Dacă trebuie neapărat să accesaţi aceste fişiere înainte ca coada să fie complet golită, ar trebui în primul rând să **mutați** fișierul de ieșire pe care doriți să îl accesați într-un alt director, **apoi** să îl procesați. Asta pentru că ASF poate adăuga unele rezultate noi în timp ce faci treaba, și acest lucru ar putea duce la pierderea unor chei dacă citiți de ex. un fișier cu 3 chei înăuntru, apoi îl stergeți, ignorând complet faptul că ASF a adăugat alte 4 chei la fișierul șters între timp. Dacă doriți să accesați aceste fișiere, asigurați-vă că le mutați departe de directorul `config` din ASF înainte de a le citi, de exemplu prin redenumire.

De asemenea, este posibil să adaugi jocuri suplimentare de importat în timp ce ai unele jocuri deja în coadă prin repetarea tuturor pașilor de mai sus. ASF va adăuga corect intrările suplimentare la coada de așteptare deja în curs de desfășurare și în cele din urmă le va procesa.

---

## Observații

Remiterea cheilor de fundal folosește `OrderedDictionary`, ceea ce înseamnă că tastele cd-key vor păstra ordinea specificată în fișier (sau apel IPC API). Aceasta înseamnă că puteţi (şi ar trebui) să furnizaţi o listă în care cd-key dat poate avea doar dependenţe directe de cd-keys enumerate mai sus, dar nu mai jos. De exemplu, asta înseamnă că dacă ai un DLC `D` care necesită activarea jocului `G` întâi, atunci cd-key pentru joc `G` ar trebui **întotdeauna** să fie inclus înainte de cd-key pentru DLC `D`. De asemenea, dacă DLC `D` ar avea dependenţe de `A`, `B` și `C`, toate cele 3 ar trebui incluse înainte (în orice ordine, cu excepția cazului în care acestea au singure dependențe).

Dacă nu se urmează schema de mai sus, DLC nu va fi activat cu eroarea `DoesNotOwnRequiredApp`, chiar dacă contul dumneavoastră ar fi eligibil pentru activare după ce a trecut prin coada de așteptare. Dacă doriți să evitați acest lucru, trebuie să vă asigurați că DLC este întotdeauna inclus după jocul de bază din coada de așteptare.