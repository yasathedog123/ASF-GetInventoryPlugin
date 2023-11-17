# Sammelprozess

Das Hauptziel von ASF ist es, so effektiv wie möglich zu sammeln, basierend auf zwei Arten von Daten, mit denen es arbeiten kann - einem kleinen Satz von benutzerdefinierten Daten, die für ASF unmöglich sind selbst zu erraten/kontrollieren, und einem größeren Satz von Daten, der von ASF automatisch überprüft werden kann.

Im Automatikmodus erlaubt ASF ihren nicht, die Spiele auszuwählen, die gesammelt werden sollen, noch erlaubt es dir, den Algorithmus für das Karten sammeln zu ändern. **ASF weiß besser als du, was es tun sollte und welche Entscheidungen es treffen sollte, um so schnell wie möglich zu sammeln**. Dein Ziel ist es, die Konfigurationseigenschaften richtig einzustellen, da ASF sie nicht alleine erraten kann, alles andere ist abgedeckt.

---

Vor einiger Zeit hat Valve den Algorithmus um Karten zu erhalten geändert. Von diesem Zeitpunkt an können wir Steam-Konten nach zwei Kategorien kategorisieren: die **mit eingeschränkten** Karten drops und die **ohne**. Der einzige Unterschied zwischen diesen beiden Typen ist die Tatsache, dass Konten mit eingeschränkten Karten drops keine Karten aus dem gegebenen Spiel erhalten können, bis sie das gegebene Spiel für mindestens `X` Stunden spielen. Es hat den Anschein, dass ältere Konten, die nie um Rückerstattung gebeten haben, **unbeschränkte Karten drops** haben, während neue Konten und diejenigen, die um Rückerstattung gebeten haben, **beschränkte Karten drops** haben. Dies ist jedoch nur eine Theorie und sollte nicht als Tatsache betrachtet werden. Deshalb gibt es **keine offensichtliche Antwort** und ASF verlässt sich darauf, dass **du** ihm sagst, welcher Fall für dein Konto geeignet ist.

---

ASF beinhaltet derzeit zwei Sammel-Algorithmen:

**Einfacher** Algorithmus funktioniert am besten bei Konten, die über unbegrenzte Karten drops verfügen. Dies ist der primäre Algorithmus, der von ASF verwendet wird. Der Bot findet Spiele für das Sammeln und sammelt sie einzeln, bis alle Karten gesammelt wurden. Dies liegt daran, dass die Karten-Sammel-Rate beim Sammeln von mehr als einem Spiel gegen Null tendiert und völlig ineffektiv ist.

**Komplex** ist ein neuer Algorithmus der implementiert wurde, um auch eingeschränkten Konten zu helfen, ihre Gewinne zu maximieren. ASF will firstly use standard **Simple** algorithm on all games that passed `HoursUntilCardDrops` hours of playtime, then, if no games with >= `HoursUntilCardDrops` hours are left, it will farm all games (up to `32` limit) with < `HoursUntilCardDrops` hours left simultaneously, until any of them hits `HoursUntilCardDrops` hours mark, then ASF will continue the loop from beginning (use **Simple** on that game, return to simultaneous on < `HoursUntilCardDrops` and so on). In diesem Fall können wir "Mehrere-Spiele-Sammeln" verwenden, um die Stunden der Spiele, die wir Sammeln müssen, auf einen angemessenen Wert zu bringen. Keep in mind that during farming hours, ASF **does not** farm cards, therefore it also won't check for any card drops during that period (for reasons stated above).

Currently, ASF chooses cards farming algorithm based purely on `HoursUntilCardDrops` config property (which is  set by **you**). If `HoursUntilCardDrops` is set to `0`, **Simple** algorithm will be used, otherwise, **Complex** algorithm will be used instead - configured to bump playtime in all games to given amount of hours before farming them for card drops.

---

### **There is no obvious answer which algorithm is better for you**.

Dies ist einer der Gründe, warum Du keinen Karten-Sammel-Algorithmus wählst, sondern ASF mitteilst, ob das Konto eingeschränkte Karten Drops hat oder nicht. If account has non-restricted drops, **Simple** algorithm will **work better** on that account, as we won't be wasting time on bringing all games to `X` hours - cards drop ratio is close to 0% when farming multiple games. On the other hand, if your account has card drops restricted, **Complex** algorithm will be better for you, as there's no point in farming solo if game didn't reach `HoursUntilCardDrops` hours yet - so we'll farm **playtime** first, **then** cards in solo mode.

`HoursUntilCardDrops` sollte nicht blindlings gesetzt werden, nur weil ihren jemand gesagt hat Du sollst es tun. Du solltest Tests durchführen, Ergebnisse vergleichen und basierend auf den Daten, die Du bekommst, entscheiden, welche Option für dich besser sein sollte. Wenn Du minimalen Aufwand dafür treibst, wirst Du sicherstellen, dass ASF mit größtmöglicher Effizienz für dein Konto arbeitet, was wahrscheinlich das ist, was Du willst, wenn man bedenkt, dass Du diese Wiki-Seite gerade liest. Wenn es eine Lösung gäbe, die für alle funktioniert, hättest Du keine Wahl - ASF würde selbst entscheiden.

---

### Was ist der beste Weg, um herauszufinden, ob dein Konto eingeschränkt ist?

Make sure you have some games with **no playtime recorded** to farm, preferably 5+, and run ASF with `HoursUntilCardDrops` of `0`. Es wäre eine gute Idee, wenn Du während des Sammelns nichts spielen würdest, um genauere Ergebnisse zu erzielen (am besten ASF nachts laufen lassen). Lass ASF diese 5 Spiele sammeln und schaue ihren danach das Protokoll an, um die Ergebnisse zu sehen.

ASF zeigt deutlich an, wann eine Karte für ein bestimmtes Spiel gesammelt wurde. Du möchtest den schnellsten Karten Drop den ASF erreicht hat. Wenn dein Konto beispielsweise uneingeschränkt ist, sollte ein erster Karten Drop nach etwa 30 Minuten seit Beginn des Sammelns erfolgen. If you notice **at least one** game that did drop card in those initial 30 minutes, then this is an indicator that your account is **not** restricted and should use `HoursUntilCardDrops` of `0`.

On the other hand, if you notice that **every** game is taking at least `X` amount of hours before it drops its first card, then this is an indicator to you what you should set `HoursUntilCardDrops` to. Die Mehrheit (wenn nicht gar alle) der eingeschränkten Benutzer benötigen mindestens `3` Stunden Spielzeit, damit die Karten gesammelt werden und dies ist auch der Standardwert für die Einstellung `HoursUntilCardDrops`.

Remember that games can have different drop rate, this is why you should test if your theory is right with **at least** 3 games, preferably 5+ to ensure that you're not running into false results by a coincidence. A card drop of one game in less than an hour is a confirmation that your account **is not** restricted and can use `HoursUntilCardDrops` of `0`, but for confirming that your account **is** restricted, you need at least several games that are not dropping cards until you hit a fixed mark.

Es ist wichtig zu beachten, dass in der Vergangenheit `HoursUntilCardDrops` nur `0` oder `2` war und deshalb hatte ASF eine einzige `CardDropsRestricted` Eigenschaft (Property), die es erlaubte, zwischen diesen beiden Werten zu wechseln. Mit den jüngsten Änderungen stellten wir fest, dass jetzt nicht nur die Mehrheit der Benutzer `3` Stunden anstelle der vorherigen `2` benötigt, sondern auch, dass `HoursUntilCardDrops` jetzt dynamisch ist und jeden Wert pro Konto treffen kann.

Am Ende liegt die Entscheidung natürlich bei dir.

Und um es noch schlimmer zu machen - ich habe Fälle erlebt in denen Leute von einem eingeschränkten in einen uneingeschränkten Zustand und umgekehrt gewechselt haben - entweder wegen eines Steam-Bugs (oh ja, es gibt viele davon) oder wegen einiger Änderungen an der Logik seitens Valve. Selbst wenn Du also bestätigt hast, dass dein Konto eingeschränkt ist (oder nicht), glaube nicht, dass es so bleiben wird - um von uneingeschränkt zu eingeschränkt zu wechseln genügt es eine Rückerstattung zu verlangen. Wenn Du das Gefühl hast, dass ein zuvor eingestellter Wert nicht mehr angemessen ist, kannst Du jederzeit einen erneuten Test durchführen und ihn entsprechend aktualisieren.

---

Standardmäßig geht ASF davon aus, dass `HoursUntilCardDrops` `3` ist, da der negative Effekt der Einstellung auf `3`, wenn er kleiner sein sollte, kleiner ist als umgekehrt. This is because of the fact that in the worst possible case we'll waste `3` hours of farming per `32` games, compared to wasting `3` hours of farming per every single game if `HoursUntilCardDrops` was set to `0` by default. Du solltest diese Variable jedoch immer noch so einstellen, dass sie mit ihrem Konto übereinstimmt, um maximale Effizienz zu erreichen, da dies nur eine blinde Vermutung ist, die auf potenziellen Nachteilen und der Mehrheit der Benutzer basiert (daher versuchen wir, standardmäßig das "kleineres Übel" zu wählen).

Im Moment reichen zwei der oben genannten Algorithmen für alle derzeit möglichen Kontoszenarien aus, um so effektiv wie möglich zu wirtschaften, daher ist es nicht geplant, weitere hinzuzufügen.

E ist gut zu wissen, dass ASF ebenfalls einen manuellen Sammelmodus besitzt, welcher mittels den Befehls `play` aktiviert wird. Sie können mehr darüber lesen in **[Befehle](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-de-DE)**.

---

## Steam Pannen

Der Algorithmus zum Sammeln von Karten funktioniert nicht immer so, wie er sollte, und es ist durchaus möglich, dass verschiedene Steam-Pannen auftreten, wie z. B. Karten, die auf eingeschränkten Konten gesammelt werden, Karten, die beim Schließen/Schalten des Spiels gesammelt werden, Karten, die beim Spielen überhaupt nicht gesammelt werden, und ebenso.

This section is mainly for people that are wondering why ASF doesn't do **X**, such as rapidly switching games to farm cards faster.

Was ist eine **Steam-Panne** - eine spezifische Aktion, die **undefiniertes** Verhalten auslöst, das **nicht beabsichtigt, undokumentiert und als logischer Fehler betrachtet wird**. Es ist **unzuverlässig per Definition**, was bedeutet, dass es nicht zuverlässig mit einer sauberen Testumgebung reproduziert werden kann, und daher ohne den Einsatz von Hacks programmiert ist, die erraten sollen, wann eine Störung auftritt und wie man damit kämpfen / sie missbrauchen kann. Normalerweise ist es temporär, bis die Entwickler den Logikfehler beheben, obwohl einige Fehlfunktionen für einen sehr langen Zeitraum unbemerkt bleiben können.

Ein gutes Beispiel für das, was als **Steam-Panne** gilt, ist nicht die ungewöhnliche Situation, eine Karte zu sammeln, wenn das Spiel geschlossen wird, was bis zu einem gewissen Grad mit der Spiel-Sprung-Funktion des untätigen Meisters missbraucht werden kann.

- **Undefiniertes Verhalten** - Sie können nicht sagen, ob 0 oder 1 Karten gesammelt werden, wenn Du die Panne auslöst.
- **Nicht beabsichtigt** - basierend auf früheren Erfahrungen und Verhaltensweisen des Steam-Netzwerkes, die nicht zu demselben Verhalten beim Senden einer einzelnen Anfrage führen.
- **Undokumentiert** - es ist klar dokumentiert auf der Steam-Website, wie Karten erhalten werden, und **an jedem einzelnen Ort** es wird klar gesagt, dass es durch **Spielen** erhalten wird, NICHT durch das Schließen von Spielen, das Erhalten von Erfolgen, das Wechseln oder das gleichzeitige Starten von 32 Spielen.
- **Betrachtet als logischer Fehler** - das Schließen von Spielen oder das Vertauschen von Spielen sollte kein Ergebnis haben, wenn Karten fallen gelassen werden, die eindeutig als durch **gewonnene Spielzeit** erhalten werden.
- **Unzuverlässig per Definition, kann nicht zuverlässig reproduziert werden** - es funktioniert nicht für alle, und selbst wenn es einmal für dich funktioniert hat, funktioniert es vielleicht nicht mehr zum zweiten Mal.

Jetzt, nachdem wir erkannt haben, was eine Steam-Panne ist, und die Tatsache, dass Karten, die fallen gelassen werden, wenn das Spiel geschlossen wird eine **ist**, können wir zum zweiten Punkt übergehen - **ASF missbraucht das Steam-Netzwerk in keiner Weise per Definition, und es tut sein Bestes, um Steam-AGB, seine Protokolle und das, was allgemein akzeptiert wird** zu erfüllen. Das Spamming des Steam-Netzwerkes mit ständigen Anfragen zum Öffnen/Schließen des Spiels kann als **[DoS-Angriff](https://en.wikipedia.org/wiki/Denial-of-service_attack)** betrachtet werden und **verletzt direkt [Steam-Online-Verhalten](https://store.steampowered.com/online_conduct/?l=english)**.

> As a Steam subscriber you agree to abide by the following conduct rules.
> 
> You will not:
> 
> Institute attacks upon a Steam server or otherwise disrupt Steam.

Es spielt keine Rolle, ob Du in der Lage bist, Steam-Pannen mit anderen Programmen (wie IM) auszulösen, und es spielt auch keine Rolle, ob Du mit uns einverstanden bist und ein solches Verhalten als DoS-Angriff betrachtest oder nicht - es liegt an Valve, dies zu beurteilen, aber wenn wir es als Ausnutzen/Missbrauch nicht beabsichtigten Verhaltens durch übermäßige Steam-Netzwerkanfragen betrachten, dann kannst Du ziemlich sicher sein, dass Valve eine ähnliche Ansicht dazu hat.

ASF wird **nie** Steam-Exploits, Missbräuche, Hacks oder jede mögliche andere Aktivität ausnutzen, die wir als **illegal oder unerwünscht** entsprechend Steam-ToS, Steam-Online-Verhalten oder irgendeiner anderen vertrauenswürdigen Quelle sehen, die anzeigen könnte, dass ASF-Aktivität durch Steam-Netzwerk unerwünscht ist, wie im Abschnitt **[Beitragen](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/.github/CONTRIBUTING.md)** angegeben.

If you want at all cost to risk your Steam account for farming a few cent cards faster than usual, then sadly ASF will never offer something like this in automatic mode, although you still have `play` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** that can be used as a tool for doing whatever you want in terms of Steam network interaction. Wir empfehlen nicht, die Vorteile von Steam-Pannen zu nutzen und sie für den eigenen Gewinn zu nutzen - nicht nur mit ASF, sondern auch mit jedem anderen Programm. Am Ende ist es jedoch dein Konto und ihre Wahl, was Du damit machen willst - denk einfach daran, dass wir dich gewarnt haben.