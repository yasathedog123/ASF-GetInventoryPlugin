# Riscatto giochi in background

Il riscatto giochi in background è una caratteristica speciale incorporata in ASF che ti permette di importare un dato numero di chiavi di Steam (insieme con i loro nomi) per essere riscattate in background. Questo è particolarmente utile se hai molte chiavi da riscattare e sei sicuro di raggiungere lo **[stato](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#what-is-the-meaning-of-status-when-redeeming-a-key)**  `RateLimited`  prima di aver terminato l'intero batch.

Il riscatto giochi in background è fatto per un singolo bot, questo significa che non utilizza `RedeemingPreferences`. Questa funzione può essere usata insieme a (o al posto di) `redeem` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**, se necessario.

---

## Importa

L'importazione può essere effettuata in due modi: usando un file o con IPC.

### File

ASF riconoscerà nella cartella `config` un file chiamato `BotName.keys` dove `BotName` è il nome del tuo bot. Questo file si aspetta una struttura ben precisa con il nome del gioco e la cd-key separati da un carattere tabulato e una nuova riga per indicare la prossima entrata. Se più tab vengono usati, allora la prima voce viene considerata il nome del gioco, l'ultima la cd-key e ciò che è nel mezzo viene ignorato. Per esempio:

```text
POSTAL 2    ABCDE-EFGHJ-IJKLM
Domino Craft VR    12345-67890-ZXCVB
A Week of Circus Terror    POIUY-KJHGD-QWERT
Terraria    QuestoVieneIgnorato    AncheQuestoVieneIgnorato    ZXCVB-ASDFG-QWERT
```

Alternativamente, puoi anche usare chiavi di solo formato (ancora con una nuova riga tra ogni voce). ASF in questo caso userà la risposta di Steam (se possibile) per compilare il giusto nome. Per ogni tipo di tag delle chiavi, raccomandiamo che tu stesso nomini le tue chiavi, come pacchetti riscattati su Steam, senza seguire la logica dei giochi che stai attivando, quindi in base a cosa ha messo lo sviluppatore, potresti vedere nomi dei giochi corretti, nomi dei pacchetti personalizzati (es. Humble Indie Bundle 18) o totalmente errati e potenzialmente anche maligni (es. Half-Life 4).

```text
ABCDE-EFGHJ-IJKLM
12345-67890-ZXCVB
POIUY-KJHGD-QWERT
ZXCVB-ASDFG-QWERT
```

Indipendentemente da quale formato hai deciso di mantenere, ASF importerà il tuo file `chiavi`, all'avvio del bot, o dopo durante l'esecuzione. Dopo aver analizzato con successo il tuo file ed eventualmente omissione di voci non valide, tutti i giochi propriamente rilevati saranno aggiunti alla coda in background, ed il file `BotName.keys` sarà rimosso dalla directory `config`.

### IPC

Oltre ad usare il file delle chiavi sopra menzionato, ASF espone anche **[l'endpoint API ASF](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-api)** `GamesToRedeemInBackground` che può essere eseguito da qualsiasi strumento IPC, inclusa la nostra ASF-ui. L'uso di IPC potrebbe essere più potente, come puoi fare tu stesso un'analisi appropriata, come usare un delimitatore personalizzato invece di essere forzato ad un carattere di scheda, o anche introdurre la tua struttura di chiavi personalizzate interamente tua.

---

## Coda

Una volta che i giochi sono importati con successo, sono aggiunti alla coda. ASF passa automaticamente per la sua coda in background finché il bot è connesso alla rete Steam, e la coda non è vuota. Una chiave che si è tentato di riscattare e non è risultata in `RateLimited` è rimossa dalla coda, con il suo stato scritto propriamente in un file nella directory `config` - o `BotName.keys.used` se la chiave era usata nel processo (es. `NoDetail`, `BadActivationCode`, `DuplicateActivationCode`), o altrimenti `BotName.keys.unused`. ASF usa intenzionalmente il nome del gioco fornito essendo la chiave non garantita affinché la rete di Steam restituisca un nome significativo - in questo modo puoi taggare le tue chiavi anche usando nomi personalizzati se necessario/desiderato.

Se durante il processo il nostro profilo colpisce lo stato `RateLimited`, la coda è temporaneamente sospesa per un'ora intera per attendere che il tempo di ricarica scompaia. Afterwards, the process continues where it left, until the entire queue is empty or another `RateLimited` occurs.

---

## Esempio

Supponiamo tu abbia un elenco di 100 chiavi. Prima di tutto dovresti creare un nuovo file `BotName.keys.new` nella directory ASD `config`. Abbiamo aggiunto l'estensione `.new` per far sapere ad ASF che non dovrebbe raccogliere questo file immediatamente non appena è creato (essendo vuoto, non ancora pronto per l'importazione).

Ora puoi aprire il nostro nuovo file e copiare-incollare la lista delle nostre 100 chiavi lì, fissando il formato se necessario. Dopo aver corretto il nostro file `BotName.keys.new` avrà esattamente 100 (o 101, con l'ultima linea) linee, ognuna avente una struttura di `GameName\tcd-key\n`, dove `\t` è il carattere della schedda e `\n` è la nuova riga.

Ora sei pronto a rinominare questo file da `BotName.keys.new` in `BotName.keys` per far sapere ad ASF che è pronto ad essere preso. Nel momento in cui lo fai, ASF importerà il file automaticamente (senza bisogno di riavvio) e lo eliminerà successivamente, confermando che tutti i nostri giochi sono stati analizzati ed aggiunti alla coda.

Invece di usare il file `BotName.keys`, potresti anche usare l'endpoint API IPC, o anche combinare entrambi se lo desideri.

Dopo un po' di tempo, i file `BotName.keys.used` e `BotName.keys.unused` saranno generati. Questi file contengono i risultati del nostro processo di riscatto. Per esempio, puoi rinominare il file `BotName.keys.unused` in `BotName2.keys` e quindi inviare le nostre chiavi inutilizzate per qualche altro bot, essendo che il bot precedente non aveva fatto uso lui stesso di queste chiavi. O potresti semplicemente copiare ed incollare le chiavi inutilizzate in qualche altro file e mantenerle per dopo, tua decisione. Tieni a mente che come ASF va per la coda, le nuove voci saranno aggiunte al nostro output di file `usati` e `inutilizzati`, quindi è raccomandato aspettare che la coda sia totalmente svuotata prima di usarle. Se devi assolutamente accedere a questi file prima che la coda sia totalmente svuotata, dovresti prima **spostare** il file di output a cui vuoi accedere verso qualche altra directory, **poi** analizzarlo. Questo perché ASF può aggiungere qualche nuovo risultato mentre fai le tue cose, e che potrebbe potenzialmente condurre alla perdita di alcune chiavi se leggi un file avente per esempio 3 chiavi all'interno, poi lo elimini, mancando totalmente il fatto che ASF ha aggiunto altre 4 chiavi al tuo file rimosso nel mentre. Se vuoi accedere a questi file, assicurati di spostarli via dalla directory `config` di ASF prima di leggerli, per esempio rinominandoli.

Puoi anche aggiungere giochi extra da importare mentre alcuni giochi sono già nella nostra coda, ripetendo tutti i passaggi sopra. ASF aggiungerà le nostre voci extra propriamente alla coda già in corso e lo affronterà alla fine.

---

## Note

Il riscattatore di chiavi in background usa `OrderedDictionary` sotto la bussola, che significa che le tue cd-chiavi avranno preservato l'ordine come era specificato nel file (o chiamata API IPC). Ciò significa che puoi (e dovresti) fornire una lista dove le cd-chiavi date possono avere solo dipendenze dirette sulle cd-chiavi elencate sopra, ma non sotto. Per esempio, ciò significa che se tu hai un DLC `D` che richiede il gioco `G` per essere attivato, allora la cd-chiave per il gioco `G` dovrebbe **sempre** essere inclusa prima della cd-chiave per il DLC `D`. Ugualmente, se il DLC `D` avesse dipendenze su `A`, `B` e `C`, allora tutti e tre dovrebbero essere inclusi prima (in ogni ordine, a meno che non abbiano dipendenze per conto loro).

Non seguendo lo schema di cui sopra risulterà nella mancata attivazione del vostro DLC con `DoesNotOwnRequiredApp`, anche se il vostro account sarebbe idoneo per attivarlo dopo esser passato per l'intera coda. Se vuoi evitare che dopo tu debba essere sicuro che il tuo DLC è sempre incluso dopo il gioco di base nella tua coda.