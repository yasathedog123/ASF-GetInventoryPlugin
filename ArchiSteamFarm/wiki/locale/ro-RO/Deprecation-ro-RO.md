# Versiuni vechi

We're doing our best to follow consistent deprecation policy in order to make both development as well as usage far more consistent.

---

## Ce este deprecierea?

Deprecation is the process of smaller or bigger breaking changes that render previously used options, arguments, functionalities or usage cases obsolete. De obicei, deprecierea înseamnă că acel lucru a fost pur și simplu rescris într-o altă formă (similară), și ar trebui să vă asigurați în timp util că veți comuta în mod corespunzător. În acest caz, se mută pur și simplu funcționalitatea dată într-un loc mai potrivit.

ASF se schimbă rapid și întotdeauna încearcă să devină mai bun. Din păcate, acest lucru înseamnă că putem schimba sau muta unele funcționalități existente într-un alt segment al programului pentru a beneficia de noi caracteristici, compatibilitate sau stabilitate. Datorită acestui lucru nu trebuie să rămânem cu decizii de dezvoltare învechite sau pur și simplu greșite pe care le-am luat cu ani în urmă. Încercăm întotdeauna să oferim un înlocuitor rezonabil care să corespundă utilizării așteptate a funcționalității disponibile anterior, Din acest motiv, deprecierea este în mare parte inofensivă și necesită mici reparații în raport cu utilizarea anterioară.

---

## Stadii de depreciere

ASF va urma două etape de depreciere, făcând tranziţia mult mai uşoară şi mai puţin problematică.

### Etapa 1

Etapa 1 are loc odată ce funcția dată devine învechită, cu disponibilitatea imediată a unei alte soluții (sau eliminarea dacă nu există planuri de reintroducere a acesteia).

În această etapă, ASF va afișa un avertisment corespunzător atunci când este folosită funcția învechită. Cât timp este posibil, ASF va încerca să imite vechiul comportament și să rămână compatibil cu acesta. ASF va continua să fie în etapa 1 cu privire la această funcționalitate cel puțin până la următoarea versiune stabilă. Acesta este momentul în care, sperăm fără a rupe compatibilitatea, puteți comuta corespunzător în toate instrumentele și uneltele pentru a folosi noul comportament. Puteţi confirma dacă aţi făcut toate modificările adecvate prin faptul că nu aţi mai văzut avertismentul de depreciere.

### Etapa 2

Etapa 2 este programată după etapa 1 explicată mai sus şi se lansează într-o versiune stabilă. Această etapă introduce eliminarea completă a caracteristicilor învechite, ceea ce înseamnă că ASF nici măcar nu va recunoaște că încercați să folosiți o funcție învechită. ca să nu mai vorbim de respectare, pentru că pur şi simplu nu există în codul actual. ASF nu va mai tipări niciun avertisment, deoarece nu mai recunoaște ceea ce încercați să faceți.

---

## Rezumat

Ai mai mult sau mai puțin o **lună întreagă** pentru a face schimbarea, care ar trebui să fie mai mult decât suficient, chiar dacă sunteți un utilizator ocazional ASF. După această perioadă, ASF nu mai garantează că vechile setări vor avea vreun efect (etapa 2), ceea ce va duce ca anumite caracteristici să nu mai funcţioneze fără a le mai observa. Dacă lansați ASF după mai mult de o lună de inactivitate, vă este recomandat să **[începeți de la zero](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up)** din nou, sau să citiți toate modificările pe care le-ai ratat și să adaptați manual utilizarea la cea curentă.

În cele mai multe cazuri, ignorarea avertismentului de depreciere nu va face funcționalitatea generală a ASF inutilizabilă, dar mai degrabă revenirea la comportamentul implicit (care poate sau nu corespunde preferinţelor dumneavoastră personale).

---

## Exemplu

Am mutat **[argumentul de linie de comanda](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments)** pre-V3.1.2.2 `--server` în **[proprietatea globală de configurare](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#global-config)** `IPC`.

### Etapa 1

Etapa 1 s-a întâmplat în versiunea V3.1.2.2 unde am adăugat un avertisment corespunzător utilizării `--server`. Argumentul depreciat `--server` a fost mapat automat în proprietatea globală de configurare `IPC: true`, care a acţionat efectiv exact la fel ca vechiul comutator `--server` la momentul respectiv. Acest lucru a permis tuturor să comute corect înainte ca ASF să nu mai accepte vechiul argument.

### Etapa 2

Etapa 2 a avut loc în versiunea V3.1.3.0, imediat după versiunea stabilă V3.1.2.9 cu etapa 1 explicată mai sus. Etapa 2 a determinat ASF să înceteze recunoașterea argumentului `--server` si tratarea lui ca orice alt argument nevalid care este trimis, care nu mai are niciun efect asupra programului. Pentru persoanele care încă nu au schimbat utilizarea `--server` în `IPC: true`, a făcut ca IPC să înceteze complet funcțional, deoarece ASF nu a mai făcut maparea adecvată.