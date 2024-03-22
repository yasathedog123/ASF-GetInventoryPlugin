# Handel

ASF beinhaltet die Unterstützung für Steam nicht-interaktive (Offline-) Handelsangebote. Sowohl das Empfangen (Akzeptieren/Ablehnen), als auch das Senden von Handelsangeboten ist sofort verfügbar und erfordert keine spezielle Konfiguration, außer natürlich ein uneingeschränktes Steam-Konto (eins das bereits 5€ im Shop ausgegeben hat). Für eingeschränkte Konten steht nur eine begrenzte Handelsfunktionalität zur Verfügung.

---

## Logik

ASF akzeptiert immer alle Handelsangebote, unabhängig von Gegenständen, die vom Benutzer mit `Master` (oder höherem) Zugriff an den Bot gesendet werden. Dies erlaubt nicht nur das simple Transferieren von Steam-Sammelkarten, die vom Bot gesammelt wurden, sondern auch eine einfache Verwaltung von anderen Steam-Gegenständen, die sich im Inventar des Bots befinden – inklusive der Gegenstände aus anderen Spielen (beispielsweise CS:GO).

ASF lehnt Handelsangebote, unabhängig vom Inhalt, von jedem (Nicht-Master) Benutzer ab, der auf der Sperrliste des Handelsmoduls steht. Die schwarze Liste ist standardmäßig in der Datenbank `BotName.db` gespeichert und kann über die **[Befehle](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-de-DE)** `tb`, `tbadd` und `tbrm` verwaltet werden. Dies sollte als Alternative zu dem standardmäßig von Steam angebotenen Blocken eines Benutzers funktionieren – Verwendung mit Bedacht.

ASF wird alle, an Bots gesendete, `loot` ähnlichen Handelsangebote akzeptieren, es sei denn, `DontAcceptBotTrades` ist in `TradingPreferences` angegeben. Kurz gesagt, der Standardwert `None` in `TradingPreferences` bewirkt, dass ASF automatisch Handelsangebote von Benutzern mit `Master`-Zugriff auf den Bot (siehe oben) akzeptiert, sowie alle Spenden-Handelsangebote von anderen Bots, die am ASF-Prozess teilnehmen. Wenn Sie Spenden-Handelsangebote von anderen Bots deaktivieren möchten, dann sollten Sie `DontAcceptBotTrades` in Ihren `TradingPreferences` verwenden.

Wenn Sie `AcceptDonations` in Ihren `TradingPreferences` aktivieren, akzeptiert ASF auch jedes Spenden-Handelsangebot, bei dem das Bot-Konto keine Gegenstände verliert. Diese Variable betrifft nur Nicht-Bot-Konten, da Bot-Konten von `DontAcceptBotTrades` betroffen sind. `AcceptDonations` ermöglicht es Ihnen problemlos Spenden von anderen Personen anzunehmen, aber auch von Bots, die nicht am ASF-Prozess teilnehmen.

Es ist wichtig zu erwähnen, dass `AcceptDonations` kein **[ASF-2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication-de-DE)** erfordert, da es keine Bestätigung benötigt, wenn wir keine Gegenstände verlieren.

Sie können die ASF-Handelsmöglichkeiten auch mit den `TradingPreferences` entsprechend anpassen. Eine der Hauptfunktionen von `TradingPreferences` ist die Option `SteamTradeMatcher`, die ASF veranlasst, eine eingebaute Logik für die Annahme von Handelsangeboten zu verwenden, die Ihnen hilft, fehlende Abzeichen zu vervollständigen. Dies ist besonders nützlich in Zusammenarbeit mit dem öffentlichen Inserieren von **[SteamTradeMatcher](https://www.steamtradematcher.com)** ist, aber auch ohne diese arbeiten kann. Es wird im Folgenden näher erläutert.

---

## `SteamTradeMatcher`

Wenn `SteamTradeMatcher` aktiv ist, wird ASF einen ziemlich komplexen Algorithmus verwenden, um zu überprüfen, ob das Handelsangebot die STM-Regeln erfüllt und zumindest neutral gegenübersteht. Die eigentliche Logik ist folgende:

- Das Handelsangebot ablehnen, wenn wir etwas anderes verlieren als die in unseren `MatchableTypes` angegebenen Objekttypen.
- Das Handelsangebot ablehnen, wenn wir nicht mindestens die gleiche Anzahl an Gegenständen pro Spiel, Typ und Seltenheit erhalten.
- Das Handelsangebot ablehnen, wenn der Benutzer nach speziellen Steam Sommer/Winter-Verkaufskarten fragt und eine Handelssperre hat.
- Das Handelsangebot ablehnen, wenn die Dauer der Handelssperre die globale Konfigurationseigenschaft `MaxTradeHoldDuration` überschreitet.
- Das Handelsangebot ablehnen, wenn wir nicht `MatchEverything` gesetzt haben und es für uns schlimmer als neutral ist.
- Akzeptiere das Handelsangebot, wenn wir ihn nicht durch einen der oben genannten Punkte abgelehnt haben.

Es ist wichtig zu erwähnen, dass ASF auch „Überzahlungen“ unterstützt – die Logik wird richtig funktionieren, wenn der Benutzer dem Handelsangebot etwas mehr hinzufügt, solange alle oben genannten Bedingungen erfüllt sind.

Die ersten 4 Ablehnungsprädikate sollten für jeden offensichtlich sein. Das letzte beinhaltet die Logik der tatsächlichen Duplikate, die den aktuellen Zustand unseres Inventars überprüft und entscheidet, was der Status des Handelsangebotes ist.

- Das Handelsangebot ist **gut**, wenn unser Fortschritt in Richtung Fertigstellung voranschreitet. Beispiel: A A (vorher) -> A B (nachher)
- Das Handelsangebot ist **neutral**, wenn unser Fortschritt bei der Fertigstellung intakt bleibt. Beispiel: A B (vorher) -> A C (nachher)
- Das Handelsangebot ist **schlecht**, wenn unser Fortschritt in Richtung Fertigstellung zurückgeht. Beispiel: A C (vorher) -> A A (nachher)

STM arbeitet nur mit guten Handelsangeboten, was bedeutet, dass Benutzer die STM für den Duplikatabgleich verwenden uns immer nur gute Handelsangebote vorschlagen sollten. ASF ist jedoch liberal und akzeptiert auch neutrale Handelsangebote, denn in diesen Handelsangeboten verlieren wir nicht wirklich etwas, sodass es keinen wirklichen Grund gibt dies abzulehnen. Dies ist besonders nützlich für Ihre Freunde, da sie Ihre überschüssigen Karten ohne STM tauschen können solange Sie keinen Set-Fortschritt verlieren.

Standardmäßig lehnt ASF schlechte Handelsangebote ab – das ist fast immer das, was Sie als Benutzer möchten. Sie könen jedoch optional `MatchEverything` in Ihren `TradingPreferences` aktivieren, um ASF dazu zu bringen alle Duplikat-Handelsangebote zu akzeptieren, einschließlich **schlechter Handelsangebote**. Dies ist nur dann nützlich, wenn Sie einen 1:1-Handelsbot unter Ihrem Account betreiben möchten, da Sie verstehen, dass **ASF Ihnen nicht mehr helfen wird, Fortschritte bei der Vervollständigung von Abzeichen zu erzielen und Sie anfällig für den Verlust des gesamten fertigen Sets für N Duplikate derselben Karte macht**. Wenn Sie absichtlich einen Handelsbot betreiben möchten, der **nie** ein Set beendet und seinen gesamten Bestand jedem interessierten Benutzer anbieten soll, dann können Sie diese Option aktivieren.

Unabhängig von den von Ihnen gewählten `TradingPreferences`, bedeutet ein von ASF abgelehntes Handelsangebot nicht, dass Sie es nicht. Wenn Sie den Standardwert `BotBehaviour` beibehalten haben, der `RejectInvalidTrades` nicht enthält, ignoriert ASF diese Handelsangebote einfach – so könen Sie selbst entscheiden, ob Sie an ihnen interessiert sind oder nicht. Gleiches gilt für Handelsangebote mit Gegenständen außerhalb von `MatchableTypes`, sowie für alles andere – das Modul soll Ihnen helfen STM-Handelsangebote zu automatisieren, nicht zu entscheiden, was ein gutes Handelsangebot ist und was nicht. Die einzige Ausnahme von dieser Regel ist, wenn es um Benutzer geht, welche Sie mit dem Befehl `tbadd` auf die schwarze Liste vom Handelsmodul gesetzt haben – Handelsangebote von diesen Benutzern werden unabhängig von den Einstellungen in `BotBehaviour` sofort abgelehnt.

Es wird dringend empfohlen, **[ASF-2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication-de-DE)** zu verwenden, wenn Sie diese Option aktivieren, da diese Funktion Ihr ganzes Potenzial verliert, wenn Sie sich dazu entscheiden jedes Handelsangebot manuell zu bestätigen. `SteamTradeMatcher` funktioniert auch ohne die Möglichkeit, Handelsangebote zu bestätigen, aber es könnte einen Rückstand an Bestätigungen erzeugen, wenn Sie sie nicht rechtzeitig akzeptieren.