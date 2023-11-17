# Deprecazione

A partire da ASF V3.1.2.2, seguiremo la politica di deprecazione consistente seguente per rendere molto più coerenti sia lo sviluppo che l'utilizzo.

---

## Cos'è la deprecazione?

La deprecazione è il processo di apportare modifiche di rottura più piccole o più grandi che rendano obsoleti opzioni, argomenti, funzionalità o casi d'uso precedentemente usati. La deprecazione di solito significa che la cosa data è semplicemente stata riscritta in un'altra forma (simile) e dovresti assicurarti in modo tempestivo di eseguire il passaggio appropriato a esso. In questo caso, è semplicemente spostare la funzionalità in un luogo più appropriato.

ASF cambia rapidamente e colpisce sempre per diventare migliore. Questo purtroppo significa che potremmo modificare o spostare alcune funzionalità esistenti in un altro segmento del programma perché benefici da nuove funzionalità, per compatibilità o stabilità. Grazie a questo non dobbiamo attenerci a decisioni di sviluppo obsolete o semplicemente dolorosamente sbagliate fatte anni fa. Proviamo sempre a fornire sostituzioni ragionevoli adeguate all'uso previsto della funzionalità precedentemente disponibile, poiché la deprecazione è principalmente innocua e richiede piccole correzioni dall'uso precedente.

---

## Fasi di deprecazione

ASF seguirà 2 fasi di deprecazione, rendendo la transizione molto più facile e meno fastidiosa.

### Fase 1

La fase 1 si verifica solo quando la data funzione diviene deprecata, con disponibilità immediata di un'altra soluzione (o nessuna se non si pianifica di reintrodurla).

Durante questa fase, ASF produrrà avvisi appropriati quando la funzione deprecata è in uso. Finché è possibile, ASF proverà a imitare il vecchio comportamento e continuerà ad esservi compatibile. ASF continuerà ad essere nella fase 1 con riguardo a tale funzionalità almeno fino alla versione stabile successiva. Questo è il momento in cui, si spera senza rompere la compatibilità, potete fare il passaggio appropriato in tutti gli strumenti e schermi che soddisfino il nuovo comportamento. Potete confermare se avete eseguito tutte le modifiche appropriate non vedendo più l'avviso di deprecazione.

### Fase 2

La fase 2 è pianificata dopo che si svolge la fase 1 spiegata sopra ed è rilasciata nella versione stabile. Questa fase introduce la rimozione completa dell'esistenza della funzionalità deprecata, a significare che ASF non riconoscerà nemmeno che stai tentando di usarne una, figuriamoci rispettarla, poiché semplicemente non esiste nel codice corrente. ASF non produrrà più alcun avviso, poiché non riconoscerà più cosa stai tentando di fare.

---

## Summary

Hai più o meno un **mese intero** per fare il passaggio appropriato, che dovrebbe essere più che abbastanza anche se sei un utente casuale di ASF. Dopo quel periodo, ASF non garantisce più che le vecchie impostazioni avranno alcun effetto (fase 2), rendendo effettivamente non più funzionali certe funzionalità senza che tu lo noti. Se stai lanciando ASF dopo più di un mese di inattività, si consiglia di **[ricominciare da zero](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up)**, o di leggere tutti i changelog mancati e di aggiornare manualmente il tuo uso a quello corrente.

In gran parte dei casi, ignorare l'avviso di deprecazione non renderà inutilizzabile la funzionalità generale di ASF, ma farà tornare al comportamento predefinito (che potrebbe o meno corrispondere alle tue preferenze personali).

---

## Example

Abbiamo spostato l'**[argomento della riga di comando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments)** `--server` della pre-V3.1.2 nella **[proprietà di configurazione globale](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#global-config)** di `IPC`.

### Fase 1

La fase 1 si è verificata alla versione V3.1.2.2 dove abbiamo aggiunto l'avviso appropriato all'uso di `--server`. Ora l'argomento obsoleto `--server` è stato mappato automaticamente nella proprietà di configurazione globale `IPC: true`, agendo efficientemente esattamente come il vecchio `--server` da tempo. Questo ha consentito a tutti di eseguire il passaggio appropriato prima dell'interruzione dell'accettazione da ASF del vecchio argomento.

### Fase 2

La fase 2 si è verificata nella versione V3.1.3.0, subito dopo la V3.1.2.9 stabile con la fase 1 spiegata sopra. La Fase 2 ha causato l'interruzione da ASF del riconoscimento dell'argomento `--server` in generale, trattandolo come ogni altro argomento non valido passato, che non ha più alcun effetto sul programma. Per le persone che non avevano cambiato ancora il loro uso di `--server` in `IPC: true` ha causato l'interruzione del funzionamento di IPC, poiché ASF non eseguiva più la mappatura appropriata.