# Handel

ASF beinhaltet Unterstützung für Steam nicht-interaktive (Offline-) Handelsangebote. Sowohl das Empfangen (Akzeptieren/Ablehnen) als auch das Senden von Handelsangeboten ist sofort verfügbar und erfordert keine spezielle Konfiguration, außer natürlich ein uneingeschränktes Steam-Konto (eins das bereits 5€ im Shop ausgegeben hat). Das Handelsmodul ist für eingeschränkte Konten nicht verfügbar.

---

## Logik

ASF akzeptiert immer alle Handelsangebote, unabhängig von Gegenständen, die vom Benutzer mit `Master` (oder höherem) Zugriff an den Bot gesendet werden. Dies erlaubt nicht nur einfaches Transferieren von Steam-Sammelkarten, die vom Bot gesammelt wurden, sondern auch einfaches Management von anderen Steam-Gegenständen, die sich im Inventar des Bots befinden - inklusive der Gegenstände aus anderen Spielen (wie zum Beispiel CS:GO).

ASF lehnt Handelsangebote, unabhängig vom Inhalt, von jedem (Nicht-Master) Benutzer ab, der auf der schwarzen Liste des Handelsmoduls steht. Blacklist is stored in standard `BotName.db` database, and can be managed via `tb`, `tbadd` and `tbrm` **[commands](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Dies sollte als Alternative zu dem standardmäßig von Steam angebotenen Blocken eines Benutzers funktionieren - Verwendung mit Bedacht.

ASF wird alle, an Bots gesendete, `loot` ähnlichen Handelsangebote akzeptieren, es sei denn, `DontAcceptBotTrades` ist in `TradingPreferences` angegeben. Kurz gesagt, der Standardwert `None` in `TradingPreferences` bewirkt, dass ASF automatisch Handelsangebote von Benutzern mit `Master` Zugriff auf den Bot (siehe oben) akzeptiert, sowie alle Spenden-Handelsangebote von anderen Bots die am ASF-Prozess teilnehmen. Wenn Du Spenden-Handelsangebote von anderen Bots deaktivieren möchtest, dann solltest Du `DontAcceptBotTrades` in ihren `TradingPreferences` verwenden.

Wenn Du `AcceptDonations` in ihren `TradingPreferences` aktivierst, akzeptiert ASF auch jedes Spenden-Handelsangebot bei dem das Bot-Konto keine Gegenstände verliert. Diese Eigenschaft (Property) betrifft nur Nicht-Bot-Konten, da Bot-Konten von `DontAcceptBotTrades` betroffen sind. `AcceptDonations` ermöglicht es ihren problemlos Spenden von anderen Personen anzunehmen, aber auch von Bots die nicht am ASF-Prozess teilnehmen.

Es ist gut zu erwähnen, dass `AcceptDonations` kein **[ASF-2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication-de-DE)** erfordert, da es keine Bestätigung braucht, wenn wir keine Gegenstände verlieren.

Sie können die ASF-Handelsmöglichkeiten auch weiter anpassen, indem Du die `TradingPreferences` entsprechend anpasst. Eine der Hauptfunktionen von `TradingPreferences` ist die Option `SteamTradeMatcher`, die ASF veranlasst, eine eingebaute Logik für die Annahme von Handelsangeboten zu verwenden, die dir hilft, fehlende Abzeichen zu vervollständigen, was besonders nützlich in Zusammenarbeit mit dem öffentlichen Inserieren von **[SteamTradeMatcher](https://www.steamtradematcher.com)** ist, aber auch ohne diese arbeiten kann. Es wird im Folgenden näher beschrieben.

---

## `SteamTradeMatcher`

Wenn `SteamTradeMatcher` aktiv ist, wird ASF einen ziemlich komplexen Algorithmus verwenden, um zu überprüfen, ob das Handelsangebot die STM-Regeln erfüllt und zumindest neutral gegenüber steht. Die eigentliche Logik ist die folgende:

- Lehne das Handelsangebot ab, wenn wir etwas anderes verlieren als die in unseren `MatchableTypes` angegebenen Objekttypen.
- Lehne das Handelsangebot ab, wenn wir nicht mindestens die gleiche Anzahl an Gegenständen pro Spiel, Typ und Seltenheit erhalten.
- Lehne das Handelsangebot ab, wenn der Benutzer nach speziellen Steam Sommer/Winter-Verkaufskarten fragt und eine Handelssperre hat.
- Lehne das Handelsangebot ab, wenn die Dauer der Handelssperre die globale Konfigurationseigenschaft `MaxTradeHoldDuration` überschreitet.
- Lehne das Handelsangebot ab, wenn wir nicht `MatchEverything` gesetzt haben und es für uns schlimmer als neutral ist.
- Akzeptiere das Handelsangebot, wenn wir ihn nicht durch einen der oben genannten Punkte abgelehnt haben.

Es ist nett zu erwähnen, dass ASF auch Überzahlungen unterstützt - die Logik wird richtig funktionieren, wenn der Benutzer dem Handelsangebot etwas mehr hinzufügt, solange alle oben genannten Bedingungen erfüllt sind.

Die ersten 4 Ablehnungsprädikate sollten für jeden offensichtlich sein. Das letzte beinhaltet die Logik der tatsächlichen Duplikate, die den aktuellen Zustand unseres Inventars überprüft und entscheidet was der Status des Handelsangebotes ist.

- Das Handelsangebot ist **gut**, wenn unser Fortschritt in Richtung Fertigstellung voranschreitet. Beispiel: A A (vorher) -> A B (nachher)
- Das Handelsangebot ist **neutral**, wenn unser Fortschritt bei der Fertigstellung intakt bleibt. Beispiel: A B (vorher) -> A C (nachher)
- Das Handelsangebot ist **schlecht**, wenn unser Fortschritt in Richtung Fertigstellung zurückgeht. Beispiel: A C (vorher) -> A A (nachher)

STM arbeitet nur mit guten Handelsangeboten, was bedeutet, dass Benutzer die STM für den Duplikatabgleich verwenden uns immer nur gute Handelsangebote vorschlagen sollten. ASF ist jedoch liberal und akzeptiert auch neutrale Handelsangebote, denn in diesen Handelsangeboten verlieren wir nicht wirklich etwas, sodass es keinen wirklichen Grund gibt dies abzulehnen. Dies ist besonders nützlich für ihre Freunde, da sie ihre überschüssigen Karten ohne STM tauschen können solange Du keinen Set-Fortschritt verlierst.

Standardmäßig lehnt ASF schlechte Handelsangebote ab - das ist fast immer das, was Du als Benutzer willst. Du kannst jedoch optional `MatchEverything` in deinen `TradingPreferences` aktivieren, um ASF dazu zu bringen alle Duplikat-Handelsangebote zu akzeptieren, einschließlich **schlechter Handelsangebote**. Dies ist nur dann nützlich, wenn Du einen 1:1-Handelsbot unter deinem Account betreiben möchtest, da Du verstehst, dass **ASF dir nicht mehr helfen wird, Fortschritte bei der Vervollständigung von Abzeichen zu erzielen und dich anfällig für den Verlust des gesamten fertigen Sets für N Duplikate derselben Karte macht**. If you want to intentionally run a trade bot that is **never** supposed to finish any set, and should offer its whole inventory to every interested user, then you can enable that option.

Unabhängig von den von ihren gewählten `TradingPreferences` bedeutet ein von ASF abgelehntes Handelsangebot nicht, dass Du es nicht selbst akzeptieren kannst. Wenn Du den Standardwert `BotBehaviour` beibehalten hast, der `RejectInvalidTrades` nicht enthält, ignoriert ASF diese Handelsangebote einfach - so kannst Du selbst entscheiden, ob Du an Ihnen interessiert bist oder nicht. Gleiches gilt für Handelsangebote mit Gegenständen außerhalb von `MatchableTypes`, sowie für alles andere - das Modul soll ihren helfen STM-Handelsangebote zu automatisieren, nicht zu entscheiden, was ein gutes Handelsangebot ist und was nicht. Die einzige Ausnahme von dieser Regel ist, wenn es um Benutzer geht, welche Du mit dem Befehl `tbadd` auf die schwarze Liste vom Handelsmodul gesetzt hast - Handelsangebote von diesen Benutzern werden unabhängig von den Einstellungen in `BotBehaviour` sofort abgelehnt.

Es wird dringend empfohlen, **[ASF-2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication-de-DE)** zu verwenden, wenn Du diese Option aktivierst, da diese Funktion ihr ganzes Potenzial verliert, wenn Du dich dazu entscheidest jedes Handelsangebot manuell zu bestätigen. `SteamTradeMatcher` funktioniert auch ohne die Möglichkeit, Handelsangebote zu bestätigen, aber es könnte einen Rückstand an Bestätigungen erzeugen, wenn Du sie nicht rechtzeitig akzeptierst.