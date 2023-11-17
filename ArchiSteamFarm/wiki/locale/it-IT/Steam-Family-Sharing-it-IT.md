# Condivisione familiare di Steam

ASF supporta Steam Family Sharing dalla versione 2.1.5.5+. Per comprendere come ASF opera con ciò, dovresti prima leggere come **[funziona Steam Family Sharing](https://store.steampowered.com/promotion/familysharing)**, disponibile su Steam.

---

## ASF

Il supporto per Steam Family Sharing presente in ASF è trasparente, il che significa che non introduce alcuna nuova proprietà di configurazione dei bot/processi; funziona fuori dalle righe come una funzionalità integrata extra.

ASF include una logica appropriata per esser consapevoli del fatto che la libreria viene bloccata dagli utenti della condivisione familiare, dunque non li "caccerà" dalla sessione di gioco per il lancio di un gioco. ASF agirà esattamente come con il profilo primario che tiene il blocco, dunque se questo blocco è tenuto insieme dal tuo client di Steam, o da uno dei tuoi utenti della condivisione familiare, ASF non proverà a fermare, invece, attenderà il rilascio del blocco.

Oltre a quanto sopra, dopo l'accesso, ASF accederà alle tue **[impostazioni di condivisione dei giochi](https://store.steampowered.com/account/managedevices)**, da cui estrarrà fino a 5 `steamID` autorizzati all'uso della tua libreria. Questi utenti ricevono il permesso di `FamilySharing` per usare i **[comandi](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**, in particolare permettendogli di usare il comando `pause~` sul profilo del bot che condivide con loro i giochi, consentendo di interrompere il modulo di farming di carte automatiche per lanciare un gioco condivisibile.

Connettere entrambe le funzionalità suddette consente ai tuoi amici di `pause~` il tuo processo di farming delle carte, avviare un gioco, giocare quanto vogliono, poi, una volta finito di giocare, il processo di farming sarà automaticamente ripreso da ASF. Certo, l'emissione di `pause~` non è necessaria se ASF correntemente non sta farmando nulla in modo attivo, perché i tuoi amici possono lanciare il gioco direttamente e la logica descritta sopra assicura che non saranno cacciati dalla sessione.

---

## Limitazioni

La rete di Steam adora fuorviare ASF trasmettendo aggiornamenti di stato falsi, che potrebbero condurre ASF a credere che vada bene riprendere il processo, cacciando troppo presto i tuoi amici. Questo è esattamente lo stesso problema di quello già spiegato da noi in **[questa voce della FAQ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#asf-is-kicking-my-steam-client-session-while-im-playing--this-account-is-logged-on-another-pc)**. Consigliamo esattamente le stesse soluzioni, promuovendo principalmente i tuoi amici al permesso `Operatore` (o superiore) e dicendo loro di fare uso dei comandi `pause` e `resume`.