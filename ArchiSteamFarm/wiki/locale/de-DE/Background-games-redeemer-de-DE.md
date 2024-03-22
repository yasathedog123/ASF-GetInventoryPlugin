# Hintergrundproduktschlüsselaktivierer (BGR)

Der Hintergrundproduktschlüsselaktivierer ist ein speziell eingebautes ASF-Feature, mit dem Sie einen bestimmten Satz von Steam-Produktschlüsseln (zusammen mit Ihren Namen) importieren können, damit diese dann im Hintergrund aktiviert werden. Das ist besonders nützlich, wenn Sie eine große Menge an Produktschlüsseln aktivieren möchten und so sicherlich den `RateLimited` **[Status](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ-de-DE#was-bedeutet-status-beim-einlösen-eines-produktschlüssels?)** erreichen, bevor Sie mit Ihrer gesamten Charge fertig sind.

Der Hintergrundproduktschlüsselaktivierer bezieht sich nur auf eine einzelne Bot-Instanz, was bedeutet, dass `RedeemingPreferences` nicht berücksichtigt wird. Dieses Feature kann bei Bedarf zusammen mit dem (oder anstelle vom) `redeem` **[Befehl](https://github.com/JustArchi/ArchiSteamFarm/wiki/Commands-de-DE)** benutzt werden.

---

## Importieren

Der Importvorgang kann auf zwei Arten durchgeführt werden – entweder mittels einer Datei oder über IPC.

### Datei

ASF erkennt in seinem `config`-Verzeichnis eine Datei mit dem Namen `BotName.keys`, wobei `BotName` der Name Ihres Bots ist. Diese Datei hat eine erwartete und feste Struktur, bestehend aus dem Namen des Spiels und dessen Produktschlüssel, getrennt von einander durch ein Tab-Zeichen und endend mit einem Zeilenumbruch zur Kennzeichnung des nächsten Eintrags. Wenn mehrere Tabulatoren verwendet werden, dann gilt der erste Eintrag als Spielname, der letzte Eintrag als Produktschlüssel und alles dazwischen wird ignoriert. Zum Beispiel:

```text
POSTAL 2  ABCDE-EFGHJ-IJKLM
Domino Craft VR 12345-67890-ZXCVB
A Week of Circus Terror POIUY-KJHGD-QWERT
Terraria  DasWirdIgnoriert  DasWirdAuchIgnoriert  ZXCVB-ASDFG-QWERT
```

Alternativ können Sie auch nur Produktschlüssel als Format verwenden (immer noch mit einem Zeilenumbruch zwischen jedem Eintrag). Um den richtigen Namen zu finden, versucht ASF in diesem Fall, die Antwort von Steam (falls möglich) zu erhalten. Für jede Art von Produktschlüsselkennzeichnung empfehlen wir Ihnen, Ihre Produktschlüssel selbst zu benennen, da Pakete, die bei Steam eingelöst werden, nicht der Logik der Spiele folgen müssen, die sie aktivieren, sodass Sie je nachdem, was der Entwickler angegeben hat, korrekte Spielnamen, benutzerdefinierte Paketnamen (z. B. Humble Indie Bundle 18) oder völlig falsche und möglicherweise sogar gefährliche (z. B. Half-Life 4) sehen könnten.

```text
ABCDE-EFGHJ-IJKLM
12345-67890-ZXCVB
POIUY-KJHGD-QWERT
ZXCVB-ASDFG-QWERT
```

Egal für welches Format Sie sich entschieden, ASF importiert Ihre `keys`-Datei entweder beim Start des Bots oder später während der Ausführung. Nach dem erfolgreichen Analysieren Ihrer Datei und dem eventuellen Weglassen ungültiger Einträge werden alle ordnungsgemäß erkannten Spiele der Hintergrundwarteschlange hinzugefügt und die Datei `BotName.keys` selbst wird aus dem Verzeichnis `config` entfernt.

### IPC

Zusätzlich zur Verwendung der oben genannten Produktschlüsseldateien stellt ASF den `GamesToRedeemInBackground` **[ASF-API-Endpunkt](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-de-DE#asf-api)** bereit, welcher von jedem IPC-Programm, einschließlich unserem ASF-UI, verwendet werden kann. Die Verwendung von IPC könnte mächtiger sein, da Sie selbst eine geeignete Syntaxanalyse durchführen könnten. Zum Beispiel können Sie ein benutzerdefiniertes Trennzeichen verwenden, um nicht an das Tabulatorzeichen gebunden zu sein oder Sie könnten sogar komplett individuelle Produktschlüssel-Strukturen verwenden.

---

## Warteschlange

Sobald die Spiele erfolgreich importiert wurden, werden sie der Warteschlange hinzugefügt. ASF arbeitet sich automatisch durch seine Hintergrundwarteschlange, solange der Bot mit dem Steam-Netzwerk verbunden und die Warteschlange nicht leer ist. Ein bei dem Aktivierungsvorgang verwendeter Produktschlüssel, welcher nicht zu einem `RateLimited` führte, wird aus der Warteschlange entfernt und mit seinem Ergebnis ordnungsgemäß in eine Datei im `config` Ordner geschrieben; entweder in `BotName.keys.used`, wenn der Produktschlüssel im Prozess benutzt wurde (z. B. `NoDetail`, `BadActivationCode`, `DuplicateActivationCode`), oder andernfalls `BotName.keys.unused`. ASF verwendet absichtlich den von Ihnen angegebenen Spielenamen, da der Produktschlüssel nicht zwingend einen aussagekräftigen Namen vom Steam-Netzwerk erhäl; auf diese Weise können Sie die Produktschlüssel sogar mit benutzerdefinierten Namen versehen, falls erforderlich/gewünscht.

Wenn während dieses Prozesses unser Konto den Status `RateLimited` erhält, wird die Warteschlange vorübergehend für eine volle Stunde unterbrochen, um die Abklingzeit abzuwarten. Danach wird der Prozess dort fortgesetzt, wo er angehalten wurde, bis die gesamte Warteschlange leer ist oder `RateLimited` erneut auftritt.

---

## Beispiel

Nehmen wir an, Sie haben eine Liste mit 100 Produktschlüsseln. Zuerst sollten Sie eine neue `BotName.keys.new`-Datei im ASF-Verzeichnis `config` erstellen. Wir fügen die Erweiterung `.new` hinzu, um ASF wissen zu lassen, dass es diese Datei nicht sofort beim Erstellen einlesen soll (da es sich um eine neue leere Datei handelt, die bislang nicht für den Import bereit ist).

Nun können wir unsere neue Datei öffnen und dort unsere Liste der 100 Produktschlüssel entsprechend der oben erläuterten Struktur einfügen und bei Bedarf das Format korrigieren. Nach etwaig nötigen Korrekturen umfasst unsere Datei `BotName.keys.new` genau 100 Zeilen (oder 101, wenn man die letzte Zeile hinzuzählt), wobei jede Zeile als `Spielname\tProduktschlüssel\n` strukturiert ist (wobei `\t` ein Tabulatorzeichen und `\n` ein Zeilenumbruch darstellt).

Jetzt können Sie diese Datei von `BotName.keys.new` in `BotName.keys` umbenennen, um ASF mitzuteilen, dass sie bereit ist, eingelesen zu werden. In diesem Augenblick importiert ASF die Datei automatisch (ohne Neustart) und löscht sie anschließend, um zu bestätigen, dass alle unsere Spiele eingelesen und der Warteschlange hinzugefügt wurden.

Anstatt die Datei `BotName.keys` zu verwenden, können Sie auch den IPC API-Endpunkt verwenden, oder sogar beides kombinieren.

Mit der Zeit werden die Dateien `BotName.keys.used` und `BotName.keys.unused` generiert. Diese Dateien enthalten die Ergebnisse unseres Einlöseprozesses. Zum Beispiel können Sie die Datei `BotName.keys.unused` in `BotName2.keys` umbenennen und somit unsere unbenutzten Produktschlüssel an einen anderen Bot weiterreichen, da der vorherige Bot diese Produktschlüssel nicht selbst verwendet hat. Oder Sie können einfach unbenutzte Produktschlüssel in eine andere Datei kopieren, und für eine spätere Verwendung aufbewahren. Beachten Sie bitte, dass ASF beim Abarbeiten der Warteschlange neue Einträge in die Dateien `used` und `unused` hinzufügt, wodurch es empfehlenswert ist zu warten, bis die Warteschlange vollständig geleert ist, bevor Sie diese Dateien verwenden. Falls Sie doch mal unbedingt auf diese Dateien zugreifen müssen, bevor die Warteschlange vollständig geleert ist, sollten Sie zunächst die Ausgabedatei, auf welche Sie zugreifen möchten, in einen anderen Dateiordner **verschieben**, und **dann** parsen. Das liegt daran, dass ASF einige neue Einträge anhängen kann, während Sie darauf zugreifen. Dies könnte zum Verlust einiger Produktschlüssel führen. Hier ein Beispiel: Sie sehen sich eine Datei an, die aktuell 3 Produktschlüssel enthält und löschen diese dann ohne zu merken, dass ASF zwischenzeitlich 4 weitere Produktschlüssel in die Datei geschrieben hat. Wenn Sie auf diese Dateien zugreifen möchten, stellen Sie bitte sicher, dass Sie jene aus dem ASF-Verzeichnis `config` entfernen, bevor diese verändert werden (zum Beispiel durch Umbenennen).

Es ist auch möglich, zusätzliche Spiele zu importieren, während sich einige Spiele bereits in der Warteschlange befinden, indem Sie alle oben genannten Schritte wiederholen. ASF wird zusätzliche Einträge ordnungsgemäß in die bereits laufende Warteschlange aufnehmen und sich um diese kümmern.

---

## Anmerkungen

Der BGR verwendet intern `OrderedDictionary`, was bedeutet, dass Ihre Produktschlüssel die Reihenfolge beibehalten werden, wie sie in der Datei (oder dem IPC-API-Aufruf) angegeben wurden. Daher können (und sollten) Sie eine Liste erstellen, in der der angegebene Produktschlüssel nur direkte Abhängigkeiten von den weiter oben aufgeführten Produktschlüsseln haben kann, aber nicht von denen weiter unten. Ein Beispiel: wenn Sie DLC `D` aktivieren möchten, welches erfordert, dass das Spiel `G` zuerst aktiviert wird, dann sollte der Produktschlüssel für das Spiel `G` **immer** vor dem Produktschlüssel für DLC `D` enthalten sein. Dies gilt ebenfalls, wenn das DLC `D` abhängig ist von `A`, `B` und `C`; dann sollten alle 3 vorher enthalten sein (in beliebiger Reihenfolge, es sei denn, es gäbe wiederum Abhängigkeiten untereinander).

Wenn Sie dem obigen Schema nicht folgen, wird Ihr DLC nicht aktiviert und Sie erhalten `DoesNotOwnRequiredApp` als Rückmeldung, selbst wenn Ihr Konto nach dem Durchlaufen der gesamten Warteschlange für die Aktivierung berechtigt wäre. Um dies zu vermeiden, sollten Sie sicherstellen, dass das DLC immer nach dem Basisspiel in Ihrer Warteschlange steht.