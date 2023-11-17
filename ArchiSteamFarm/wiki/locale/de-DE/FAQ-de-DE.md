# FAQ

Unser FAQ umfasst Standardfragen und Antworten, die Sie vielleicht haben. Für weniger häufig gestellte Fragen besuchen Sie bitte stattdessen unser **[erweitertes FAQ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Extended-FAQ-de-DE)**.

# Inhaltsverzeichnis

* [Allgemein](#general)
* [Vergleich mit ähnlichen Programmen](#comparison-with-similar-tools)
* [Sicherheit / Datenschutz / VAC / Sperren / Nutzungsbedingungen](#security--privacy--vac--bans--tos)
* [Sonstiges](#misc)
* [Probleme](#issues)

---

## Allgemein

### Was ist ASF?
### Warum behauptet das Programm, dass es auf meinem Konto nichts zum Sammeln gibt?
### Warum erkennt ASF nicht alle meine Spiele?
### Warum ist mein Konto begrenzt?

Bevor Sie versuchen herauszufinden, was ASF ist, sollten Sie sicherstellen, dass Sie verstehen, was Steam Sammelkarten sind und wie man sie erhält, was in der offiziellen FAQ **[hier](https://steamcommunity.com/tradingcards/faq)** gut beschrieben ist.

Kurz gesagt, Steam-Sammelkarten sind sammelbare Gegenstände, welche Sie sammeln können, wenn Sie ein bestimmtes Spiel besitzen, und können für die Herstellung von Abzeichen, den Verkauf auf dem Steam-Markt oder für jeden anderen Zweck ihrer Wahl verwendet werden.

Core points are stated once again here, because people in general don't want to agree with them and prefer to pretend that those do not exist:

- **Sie müssen das Spiel auf dem Steam-Account besitzen, um für die dazu gehörigen Kartenfunde berechtigt zu sein. Spiele die über die Steam-Familienbibliothek geteilt werden zählen nicht.**
- **Sie können nicht unendlich lange sammeln; jedes Spiel hat eine feste Anzahl an Kartenfunde. Once you drop all of them (around a half of the full set), the game is not a candidate for farming anymore. Es ist unwichtig, ob Sie die Karten verkauft, gehandelt, Abzeichen hergestellt oder lediglich vergessen haben, was damit geschehen ist; sobald die maximale Anzahl erreicht wurde, wird für dieses Spiel nicht weiter gesammelt.**
- **Sie können keine Karten von F2P-Spielen erhalten, ohne dabei Geld auszugeben. This means permanently F2P games like Team Fortress 2 or Dota 2. Der Besitz von F2P-Spielen allein garantiert Ihnen keinen Kartenfund.**
- **Sie erhalten keine Karten auf [beschränkten Accounts](https://support.steampowered.com/kb_article.php?ref=3330-iagk-7663&l=german), ungeachtet der registrierten Spiele. Es war in der Vergangenheit möglich, aber dies ist nicht mehr der Fall.**
- **Paid games that you've obtained for free during a promotion can't be farmed for card drops, regardless of what is displayed on the store page. Es war in der Vergangenheit möglich, aber dies ist nicht mehr der Fall.**

Steam-Sammelkarten sind folglich eine Belohnung dafür, dass Sie gekaufte Spiele spielen oder Geld in F2P-Spiele investieren. Sobald Sie ein Spiel lange genug spielen, werden alle Karten für dieses Spiel irgendwann im Inventar freigeschaltet. Damit können Sie beispielsweise ein Abzeichen vervollständigen (nach dem Erhalt der restlichen erforderlichen Karten) oder handeln.

Nun, da wir die Grundlagen von Steam erklärt haben, können wir ASF erklären. Das Programm selbst ist sehr komplex und dementsprechend relativ schwer zu verstehen. Anstatt hier alle technischen Details anzugeben, geben wir weiter unten lieber einen Überblick mit einfachen Erklärungen.

ASF meldet sich über unseren integrierten Mini-Steam-Client mit den von Ihnen angegebenen Anmeldeinformationen beim Steam-Konto an. After successfully logging in, it parses your **[badges](https://steamcommunity.com/my/badges)** in order to find games that are available for farming (`X` card drops remaining). Nachdem alle Seiten analysiert und eine endgültige Liste der verfügbaren Spiele erstellt wurde, wählt ASF den effizientesten Sammel-Algorithmus aus und startet den Prozess. The process depends upon chosen **[cards farming algorithm](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)** but usually it consists of playing eligible game and periodically (plus on each item drop) checking if game is fully farmed already - if yes, ASF can proceed with the next title, using the same procedure, until all games are fully farmed.

Beachten Sie, dass die obige Erklärung vereinfacht ist und nicht Dutzende von zusätzlichen Features und Funktionen beschreibt die ASF anbietet. Mehr Informationen  und Details finden Sie in **[unserem Wiki](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Home-de-DE)**. Ich habe versucht es einfach zu halten, damit es für alle verständlich ist, ohne technische Details einzubringen - fortgeschrittene Benutzer werden ermutigt, tiefer zu graben.

Als Programm bietet ASF einige Vorteile. Erstens, ASF muss keine Spieldateien herunterladen; es kann sofort ihre Spiele sammeln. Zweitens ist es völlig unabhängig von ihrem normalen Steam-Client. Sie müssen Steam-Client nicht laufen lassen oder gar installiert haben. Drittens ist es eine automatisierte Lösung - was bedeutet, dass ASF automatisch alles ohne weiteres Zutun erledigt, ohne dass Sie ihm sagen müssen, was er tun soll. Dies erspart Ihnen Ärger und Zeit. Letztendlich muss es das Steam-Netzwerk nicht durch Prozessemulation (die z. B. Idle Master verwendet) austricksen, da es direkt mit ihm kommunizieren kann. Es ist auch superschnell und leicht und ist eine erstaunliche Lösung für alle, die Karten ohne großen Aufwand bekommen wollen - es ist besonders nützlich, wenn man es im Hintergrund laufen lässt, während man etwas anderes macht oder sogar im Offline-Modus spielt.

All of the above is nice, but ASF also has some technical limitations that are enforced by Steam - we can't farm games that you don't own, we can't farm games forever in order to get extra drops past the enforced limit, and we can't farm games while you're playing. All of that should be "logical", considering the way how ASF works, but it's nice to note that ASF doesn't have super-powers and won't do something that is physically impossible, so keep that in mind - it's basically the same as if you told someone to log in on your account from another PC and farm those games for you.

Zusammenfassend lässt sich sagen: ASF ist ein Programm, das Ihnen hilft, die Karten, für die Sie berechtigt sind, ohne großen Aufwand sammeln zu lassen. Es bietet auch einige andere Funktionen, aber wir bleiben vorerst bei dieser.

---

### Muss ich meine Zugangsdaten angeben?

**Ja**. ASF benötigt die Konto-Anmeldeinformationen auf die gleiche Weise wie der offizielle Steam-Client, da er die gleiche Methode für die Steam-Netzwerkinteraktion verwendet. Dies bedeutet jedoch nicht, dass Sie die Zugangsdaten in ASF-Konfigurationen eingeben müssen. Stattdessen können Sie ASF weiterhin mit `null` (leerem `SteamLogin` und/oder `SteamPassword`) verwenden und bei Bedarf diese Daten für jeden ASF-Ausführung eingeben (sowie mehrere andere Zugangsdaten, siehe Konfiguration). Auf diese Weise werden die Daten nirgendwo gespeichert, aber natürlich kann ASF ohne ihre Hilfe nicht automatisch starten. ASF bietet auch viele andere Möglichkeiten die **[Sicherheit](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security-de-DE#Sicherheit)** zu erhöhen. Wenn Sie ein fortgeschrittener Benutzer sind, sollten Sie diesen Teil des Wikis lesen. Falls dem jedoch nicht so ist, und Sie die Konto-Anmeldeinformationen nicht in die ASF-Konfigurationen einfügen möchten, dann belassen Sie es einfach dabei und geben Sie diese stattdessen erst bei Bedarf ein, z. B. wenn ASF danach fragt.

Bedenken Sie, dass ASF für den persönlichen Gebrauch bestimmt ist und die Zugangsdaten werden ihren Computer niemals verlassen werden. Sie teilen diese auch mit niemandem. Dies erfüllt die **[Steam-Nutzungsbedingungen (AGB)](https://store.steampowered.com/subscriber_agreement/german)** - eine sehr wichtige Sache, die viele Leute vergessen. Sie schicken ihre Daten nicht an unsere Server oder einen Dritten, sondern nur direkt an Steam-Server, die von Valve betrieben werden. Wir kennen ihre Zugangsdaten nicht und können sie auch nicht für Sie wiederherstellen, unabhängig davon, ob Sie diese in ihren Konfigurationen eingefügt haben oder nicht.

---

### Wie lange muss ich warten bis ich Karten erhalte?

**So lange wie es eben dauert** - ernsthaft. Jedes Spiel hat unterschiedliche Sammel-Schwierigkeiten, die vom Entwickler/Herausgeber festgelegt werden, und es liegt ganz an Ihnen, wie schnell die Karten gesammelt werden. Die Mehrheit der Spiele folgt 1 Karte pro 30 Minuten Spielzeit, aber es gibt auch Spiele, welche sogar mehrere Stunden zu Spielzeit verlangen, bevor Sie eine Karte bekommen. Darüber hinaus kann es sein, dass das Konto daran gehindert wird, Karten von Spielen zu erhalten, die Sie noch nicht lange genug gespielt haben, wie im Abschnitt **[Leistung](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance-de-DE)** beschrieben. Versuchen Sie nicht zu erraten, wie lange ASF den gegebenen Titel sammeln soll - es liegt weder an Ihnen, noch an ASF dies zu entscheiden. Es gibt nichts was Sie tun können um es zu beschleunigen und es gibt keinen "Bug", der damit zusammenhängt, dass Karten nicht pünktlich gesammelt werden. Sie kontrollieren den Karten-Sammel-Prozess nicht, ebenso wenig wie ASF. Im besten Fall erhalten Sie durchschnittlich 1 Karte pro 30 Minuten. Im schlimmsten Fall erhalten Sie innerhalb der ersten 4 Stunden nach dem Start von ASF keine einzige Karte. Beide dieser Situationen sind normal und werden in unserem Abschnitt **[Leistung](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance-de-DE#Leistung)** beschrieben.

---

### Das Sammeln dauert so lange - Kann ich es irgendwie beschleunigen?

Das Einzige, was die Geschwindigkeit des Sammelns stark beeinflusst ist der gewählte **[Sammel-Algorithmus](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance-de-DE)** für die jeweilige Bot-Instanz. Alles andere hat einen unwesentlichen Effekt und beschleunigt das Sammeln nicht, wobei manche Dinge, wie zum Beispiel das mehrfache Starten von ASF es sogar **schlechter** machen. Wenn Sie wirklich den Drang haben, jede einzelne Sekunde des Sammel-Prozesses zu nutzen, dann erlaubt ASF Ihnen einige grundlegende Sammel-Variablen wie `FarmingDelay` zu optimieren - alle von Ihnen sind in der **[Konfiguration](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-de-DE#Konfiguration)** erklärt. Nichtsdestotrotz ist dieser Effekt unwesentlich und den entsprechenden Sammel-Algorithmus für das jeweilige Konto zu wählen ist die einzige ausschlaggebende Wahl, die die Geschwindigkeit schwer beeinflussen kann, während alles andere rein kosmetisch ist. Anstatt sich um Geschwindigkeit zu sorgen, sollten Sie einfach ASF starten und es seinen Job machen lassen - Ich kann versichern, dass es das auf die effektivste Art macht, die wir uns ausdenken konnten. Je weniger Sie sich sorgen, desto zufriedener werden Sie sein.

---

### Aber ASF sagte, dass das Sammeln etwa X Zeit in Anspruch nehmen wird!

ASF gibt Ihnen eine grobe Schätzung basierend auf der Anzahl der Karten, die Sie sammeln müssen, und dem gewählten Algorithmus - dies ist bei weitem nicht annähernd die tatsächliche Zeit, die für das Sammeln benötigt wird, die in der Regel länger ist als diese, da ASF nur den besten Fall annimmt, und ignoriert alle Steam-Netzwerk-Eigenarten, Internet-Trennungen, Überlastung der Steam-Server und ähnliches. Es ist nur als allgemeiner Indikator zu verstehen, wie lange man mit dem Sammeln von ASF rechnen kann, im besten Fall sehr oft, da die tatsächliche Zeit variiert, in einigen Fällen sogar deutlich. Wie oben erwähnt, versuchen Sie nicht zu erraten wie lange das Spiel gesammelt wird. Es liegt weder an Ihnen, noch an ASF dies zu entscheiden.

---

### Kann ASF auf meinem Android/Smartphone funktionieren?

ASF is a C# program that requires working implementation of .NET. Android became a valid platform starting with .NET 6.0, however, there is currently a major blocker in making ASF happen on Android due to **[lack of ASP.NET runtime available on it](https://github.com/dotnet/aspnetcore/issues/35077)**. Even though there isn't a native option available, there are proper and working builds for GNU/Linux on ARM architecture, so it's totally possible to use something like **[Linux Deploy](https://play.google.com/store/apps/details?id=ru.meefik.linuxdeploy)** for installing Linux, then using ASF in such Linux chroot as usual.

When/If all ASF requirements are satisfied, we'll consider releasing official Android build.

---

### Can ASF farm items from Steam games, such as CS:GO or Unturned?

**Nein**, dies verstößt gegen die **[Steam-Nutzungsbedingungen](https://store.steampowered.com/subscriber_agreement/german)** (AGB) und Valve stellte sich mit der letzten Welle von Community-Sperren entschieden gegen das Sammeln von TF2-Gegenständen. ASF ist ein Steam-Karten-Sammelprogramm, kein Spiele-Gegenstände-Sammelprogramm - es hat keine Möglichkeit Spielegegenstände zu sammeln und es ist nicht geplant ein solches Feature in der Zukunft hinzuzufügen, hauptsächlich wegen der Verletzung der Steam-Nutzungsbedingungen. Bitte stellen Sie keine Fragen dazu. Das Allerbeste was Sie davon haben ist ein Report von einem genervten Benutzer Ihnen Probleme beschert. The same goes for all other types of farming, such as farming drops from CS:GO broadcasts. ASF konzentriert sich ausschließlich auf Steam-Handelskarten.

---

### Can I choose which games should be farmed?

**Ja**, auf verschiedene Arten. If you want to alter the default order of farming queue, then that's what `FarmingOrders` **[bot configuration property](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#bot-config)** can be used for. If you want to manually blacklist given games from being farmed automatically, you can use idle blacklist which is available with `fb` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. If you'd like to farm everything but give some apps priority over everything else, that is what idle priority queue available with `fq` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** can be used for. And finally, if you want to farm specific games of your choice only, then you can use `FarmPriorityQueueOnly` **[bot configuration property](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#bot-config)** in order to achieve this, together with adding your selected apps to idle priority queue.

Zusätzlich zur Verwaltung des oben beschriebenen Moduls für das automatische Karten-Sammeln können Sie ASF auch mit dem `play` **[-Befehl](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-de-DE#Befehl)** in den manuellen Sammel-Modus umschalten oder einige andere externe Einstellungen wie `GamesPlayedWhileIdle` **[Bot Konfigurationseigenschaft](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-de-DE#bot-konfiguration)** verwenden.

---

### I'm not interested in card drops, I'd like to farm hours played instead, is that possible?

Ja, ASF erlaubt es Ihnen, dies auf mehrere Arten zu tun.

The best way to achieve that is to make use of **[`GamesPlayedWhileIdle`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#gamesplayedwhileidle)** configuration property, which will play your chosen appIDs when ASF has no cards to farm. If you'd like to play your games all the time, even if you do have card drops from other games, then you can combine it with **[`FarmPriorityQueueOnly`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#farmpriorityqueueonly)**, so ASF will farm only those games for card drops that you explicitly set, or **[`Paused`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#paused)**, which will cause cards farming module to be paused until you unpause it yourself.

Alternativ können Sie den Befehl **[`play`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-de-DE#Befehle-1)** anwenden, damit ASF ihre ausgewählten Spiele spielt. However, keep in mind that `play` should be used only for games you want to play temporarily, as it's not a persistent state, causing ASF to revert back to default state e.g. upon disconnection from Steam network. Daher empfehlen wir Ihnen, `GamesPlayedWhileIdle`zu verwenden, es sei denn, Sie möchten ihre ausgewählten Spiele tatsächlich nur für einen kurzen Zeitraum starten und dann zum allgemeinen Vorgehen zurückkehren.

---

### Ich verwende Linux / mac-OS. Kann ASF Spiele sammeln, die für mein Betriebssystem nicht verfügbar sind? Will ASF farm 64-bit games when I'm running it on 32-bit OS?

Ja, ASF kümmert sich nicht einmal um das Herunterladen aktueller Spieldateien, sodass es mit allen Lizenzen funktioniert, die an ihr Steam-Konto gebunden sind, unabhängig von Plattform oder technischen Anforderungen. Obwohl wir das nicht garantieren (es hat bei unserem letzten Versuch funktioniert), sollte es auch für regional gebundene (in bestimmten Regionen gesperrte) Spiele funktionieren, auch wenn Sie nicht in der passenden Region sind.

---

## Vergleich mit ähnlichen Programmen

---

### Ist ASF ähnlich wie Idle Master?

The only similarity is the general purpose of both programs, which is farming Steam games in order to receive card drops. Everything else, including the actual farming method, used algorithms, program structure, functionality, compatibility, ending with the source code itself, is entirely different and those two programs have nothing common with each other, even the core foundation - IM is running on .NET Framework, ASF on .NET (Core). ASF wurde geschaffen, um IM-Probleme zu lösen, die mit einer einfachen Programmcode-Editierung nicht zu lösen waren - deshalb wurde ASF von Grund auf neu geschrieben, ohne eine einzige Programmzeile oder gar eine allgemeine Idee des IM zu verwenden, weil dieser Code und diese Ideen von Anfang an völlig fehlerhaft waren. IM und ASF sind wie Windows und Linux - beide sind Betriebssysteme und beide können auf ihrem PC installiert werden, aber sie haben fast nichts miteinander zu tun, abgesehen davon, dass sie einem ähnlichen Zweck dienen.

Aus diesem Grund sollten Sie ASF nicht mit IM vergleichen, basierend auf den Erwartungen an IM. Sie sollten ASF und IM als völlig unabhängige Programme mit eigenen exklusiven Funktionalitäten betrachten. Einige von Ihnen überschneiden sich tatsächlich und man kann in beiden ein bestimmtes Feature finden, aber sehr selten, da ASF seinen Zweck mit einem völlig anderen Ansatz als IM erfüllt.

---

### Lohnt es sich ASF zu verwenden, wenn ich gerade Idle Master verwende und es für mich gut funktioniert?

**Ja**. ASF is much more reliable and includes many built-in functions that are **crucial** regardless of the way how you farm, that IM simply doesn't offer.

ASF has proper logic for **unreleased games** - IM will attempt to farm games that have cards added already, even if they weren't released yet. Of course, it's not possible to farm those games until release date, so your farming process will be stuck. Dazu müssen Sie es entweder zur Blacklist hinzufügen, auf die Freigabe warten oder manuell überspringen. Neither of those solutions is good, and all of them require your attention - ASF automatically skips farming of unreleased games (temporarily), and returns back to them later when they are, completely avoiding the problem and dealing with it efficiently.

ASF hat auch die richtige Logik für **Serien** Videos. There are many videos on Steam that have cards, yet are announced with wrong `appID` on the badges page, such as **[Double Fine Adventure](https://store.steampowered.com/app/402590)** - IM will falsely farm wrong `appID`, which will yield no drops and process being stuck. Wieder einmal müssen Sie es entweder auf die schwarze Liste setzen oder manuell überspringen, wobei beide ihre Aufmerksamkeit erfordern. ASF automatically discovers proper `appID` for farming which does result in card drops.

Darüber hinaus ist ASF **viel stabiler und zuverlässiger**, wenn es um Netzwerkprobleme und Steam-Macken geht - es funktioniert meistens und erfordert deine Aufmerksamkeit überhaupt nicht, wenn es einmal konfiguriert ist, während IM oft für viele Leute abbricht, zusätzliche Korrekturen erfordert oder trotzdem einfach nicht funktioniert. Es ist auch völlig abhängig vom Steam-Client, was bedeutet, dass es nicht funktionieren kann, wenn ihr Steam-Client ernste Probleme hat. ASF funktioniert ordnungsgemäß, solange es mit dem Steam-Netzwerk verbunden werden kann, und erfordert nicht, dass der Steam-Client ausgeführt oder sogar installiert wird.

Those are 3 **very important** points why you should consider using ASF, as they directly affect everybody farming Steam cards and there is no way to say "this doesn't consider me", since Steam maintenances and quirks are happening to everybody. Es gibt Dutzende von zusätzlichen, unwichtigeren und wichtigeren Gründen, die Sie im Rest des FAQs erfahren können. Also kurz gesagt, **ja**, Du solltest ASF verwenden, auch wenn Du keine zusätzliche ASF-Funktion brauchst, die im Vergleich zu IM verfügbar ist.

Darüber hinaus wird IM offiziell nicht weiterentwickelt und könnte in Zukunft komplett kaputt gehen, ohne dass sich jemand die Mühe macht, es zu reparieren, wenn man bedenkt, dass es viel leistungsfähigere Lösungen gibt (abgesehen von ASF). IM funktioniert bereits für viele Leute nicht mehr, und diese Zahl nimmt nur zu, nicht ab. Du solltest es vermeiden, veraltete Software zu verwenden, nicht nur IM, sondern auch alle anderen veralteten Programme. Kein aktiver Verwalter bedeutet, dass sich niemand darum kümmert, ob es funktioniert oder nicht, niemand verifiziert, ob es funktioniert, und **niemand ist für seine Funktionalität** verantwortlich, was für die Sicherheit entscheidend ist. Es reicht aus, dass ein kritischer Fehler auftritt, der tatsächlich Probleme mit der Steam-Infrastruktur verursacht - ohne dass jemand sie behebt. Steam kann eine weitere Sperrwelle auslösen, in der Sie betroffen werden, ohne dass Ihnen bewusst ist, dass dies ein Problem ist wie es bereits anderen Nutzern (mit veralteten ASF-Versionen) vor Ihnen erging.

---

### Welche interessanten Features bietet ASF, die Idle Master nicht bietet?

Es hängt davon ab, was für Sie "interessant" ist. If you plan to farm more accounts than one then the answer is already obvious since ASF allows you to farm all of them with one superior solution, saving resources, hassle, and compatibility issues. Wenn Sie allerdings diese Frage stellen, dann haben Sie höchstwahrscheinlich nicht diesen speziellen Bedarf, also lass uns andere Vorteile bewerten, die für ein einzelnes Konto gelten, das in ASF verwendet wird.

First and foremost, you have some built-in features mentioned **[above](#is-it-worth-it-to-use-asf-if-im-currently-using-idle-master-and-it-works-fine-for-me)** that are core for farming regardless of your end-goal, and very often that alone is already enough to consider using ASF. Aber das wissen Sie bereits, also lassen Sie uns zu einigen weiteren interessanten Features kommen:

- **You can farm offline** (`OnlineStatus` of `Offline` feature). Farming offline makes it possible for you to skip your Steam in-game status entirely, which allows you to farm with ASF while showing "Online" on Steam at the same time, without your friends even noticing that ASF is playing a game on your behalf. Dies ist eine überlegene Funktion, da es Ihnen erlaubt, online im Steam-Client zu bleiben, ohne ihre Freunde mit ständigen Spieländerungen zu belästigen oder sie in die Irre zu führen, dass Sie ein Spiel spielen, während Sie es in Wirklichkeit nicht sind. Allein dieser Punkt macht es sinnvoll, ASF zu verwenden, wenn man seine eigenen Freunde respektiert, aber es ist nur der Anfang. Es ist auch gut zu wissen, dass diese Funktion nichts mit den Privatsphäre-Einstellungen von Steam zu tun hat - wenn Sie das Spiel selbst starten, dann werden Sie den Freunden richtig als In-Game angezeigt, sodass nur der ASF-Teil unsichtbar wird und das Konto überhaupt nicht beeinträchtigt werden.

- **You can skip refundable games** (`SkipRefundableGames` feature). ASF has proper built-in logic for refundable games and you can configure ASF to not farm refundable games automatically. Auf diese Weise können Sie selbst beurteilen, ob ein neu gekauftes Spiel aus dem Steam-Shop ihr Geld wert war, ohne dass ASF versucht, so schnell wie möglich Karten zu sammeln. Wenn Sie es für 2+ Stunden spielen, oder 2 Wochen seit ihrem Kauf vergangen sind, dann wird ASF mit diesem Spiel fortfahren, da es nicht mehr rückerstattungsfähig ist. Bis dahin haben Sie die volle Kontrolle, ob Sie es mögen oder nicht, und können es bei Bedarf leicht zurückerstatten, ohne dass Sie dieses Spiel manuell auf die schwarze Liste setzen oder ASF für die gesamte Dauer nicht verwenden müssen.

- **Sie können neue Gegenstände automatisch als erhalten markieren** (`BotBehaviour` von `DismissInventoryNotifications` Feature). Farming with ASF will result in your account receiving new card drops. Sie wissen bereits, dass dies geschehen wird, also lassen ASF diese unnötige Benachrichtigung für Sie lesen und sicherstellen, dass nur wichtige Dinge ihre Aufmerksamkeit gewinnen. Natürlich nur wenn Sie dies wünschen.

- **Sie können automatisch Karten von Steam Events** erhalten (`AutoSteamSaleEvent` Feature). ASF ermöglicht es Ihnen, die Entdeckungsliste während des Steam-Sales zu automatisieren, aber natürlich nur, wenn Sie das auch möchten. Dies spart jeden Tag enorm viel Zeit, während der Steam-Sale stattfindet, und stellt sicher, dass Sie die täglichen Karten nie wieder verpassen werden.

- **Sie können die bevorzugte Sammel-Reihenfolge mit mehr verfügbaren Optionen anpassen** (`FarmingOrders` Feature). Perhaps you want to farm your newly bought games first? Oder die ältesten? Nach der Anzahl der Karten? Abzeichen-Level, die Sie bereits hergestellt haben? Gespielte Stunden? Alphabetisch? Nach den AppIDs? Oder komplett zufällig? Das liegt ganz bei Ihnen.

- **ASF kann Ihnen helfen, ihre Sets zu vervollständigen** (`TradingPreferences` mit `SteamTradeMatcher` Feature). Mit etwas fortgeschrittenerem Tüfteln können Sie ihrer ASF in einen vollwertigen Benutzer-Bot umwandeln, der automatisch **[STM](https://www.steamtradematcher.com)** Handelsangebote akzeptiert und Ihnen jeden Tag hilft, ihre Sets ohne jegliche Benutzerinteraktion zu ergänzen. ASF enthält sogar ein eigenes ASF-2FA-Modul, mit dem Sie einen mobilen Steam-Authentifikator importieren und den gesamten Prozess vollständig automatisieren können, auch bei der Annahme von Bestätigungen. Oder möchten Sie vielleicht manuell akzeptieren und ASF nur diese Handelsangebote für Sie vorbereiten lassen? Auch das liegt wieder einmal ganz bei Ihnen.

- **ASF kann Produktschlüssel im Hintergrund für Sie einlösen** (**[Hintergrundproduktschlüsselaktivierer](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer-de-DE)** Feature). Vielleicht haben Sie hundert Produktschlüssel aus verschiedenen Bundles wo Sie zu faul sind alle einzulösen, da Sie bei jedem durch ein paar Fenster gehen und den Steam-Bedingungen immer wieder zustimmen müssen. Warum nicht einfach die Liste der Produktschlüssel zu ASF kopieren und es seine Arbeit machen lassen? ASF löst automatisch alle diese Produktschlüssel im Hintergrund ein und stellt Ihnen entsprechende Ausgaben zur Verfügung, damit Sie wissen, wie sich jeder Einlösungsversuch ausgewirkt hat. Außerdem, wenn Sie hunderte von Produktschlüssel haben, werden Sie garantiert früher oder später von Steam rate-limited. ASF weiß auch davon; wird geduldig warten, bis dieses Anfragelimit verschwindet, und dort weitermachen, wo es aufgehört hat.

Wir könnten nun mit dem gesamten **[ASF-Wiki](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Home-de-DE)** fortfahren und auf jedes einzelne Feature des Programms hinweisen, aber wir müssen irgendwo eine Grenze ziehen. Das ist es, dies ist eine Liste von Features, die Du als ASF-Benutzer genießen kannst, wo nur eine davon leicht als ein Hauptgrund angesehen werden könnte, nie zurückzuschauen, und wir haben tatsächlich **eine Menge** von Ihnen aufgelistet, mit noch mehr, über die Du auf dem Rest unseres Wikis mehr erfahren kannst. Wir sind nicht einmal ins Detail gegangen, mit Dingen wie ASF's API, die es Ihnen etwa ermöglicht, einen eigene Befehle zu skripten, oder das ausgezeichnete Bot-Management, da wir es einfach halten wollten.

---

### Ist ASF schneller als Idle Master?

**Ja**, obwohl die Erklärung ziemlich kompliziert ist.

Bei jedem neuen Prozess, der in ihrem System gestartet und beendet wird, sendet der Steam-Client automatisch eine Anfrage mit allen Spielen, die Sie gerade spielen - so kann das Steam-Netzwerk Stunden berechnen und Karten ausgeben. Das Steam-Netzwerk zählt jedoch die Spielzeit in Intervallen von 1 Sekunde, und das Senden einer neuen Anfrage setzt den aktuellen Status zurück. Mit anderen Worten: wenn Sie alle 0,5 Sekunden einen neuen Prozess starten/abbrechen würden, würden Sie nie eine Karte sammeln, weil jeder 0,5-Sekunden-Steam-Client eine neue Anfrage senden würde und das Steam-Netzwerk nie auch nur 1 Sekunde Spielzeit zählen würde. Außerdem ist es aufgrund der Funktionsweise des Betriebssystems durchaus üblich, neue Prozesse zu erkennen, die ohne dass Sie überhaupt etwas tun (also selbst wenn Sie nichts auf einem PC unternehmen). Es gibt viele Prozesse, die immer noch im Hintergrund arbeiten und andere Prozesse die ganze Zeit über auslösen/beenden. Idle Master basiert auf dem Steam Client, sodass dieser Mechanismus Sie beeinflusst, wenn Sie ihn benutzen.

ASF basiert nicht auf dem Steam-Client, sondern hat eine eigene Steam-Client-Implementierung. Dank dessen ist das, was ASF tut, nicht das Auslösen eines Prozesses, sondern das Senden einer echten Anfrage an das Steam-Netzwerk, dass wir mit dem Spielen eines Spiels begonnen haben. Dies ist die gleiche Anfrage, die vom Steam-Client gesendet wird, aber da wir die tatsächliche Kontrolle über den ASF-Steam-Client haben, brauchen wir keine neuen Prozesse zu starten, und wir imitieren den Steam-Client nicht bezüglich der Sendeanforderung bei jeder Prozessänderung, sodass der oben beschriebene Mechanismus uns nicht betrifft. Dank dessen unterbrechen wir nie das 1-Sekunden-Intervall auf Steam, was unsere Sammel-Geschwindigkeit erhöht.

---

### Aber ist der Unterschied wirklich spürbar?

Nein. Die Unterbrechungen, die mit einem normalen Steam-Client und dem Idle Master auftreten, haben nur einen geringen Einfluss auf die Kartendrops, sodass es kein spürbarer Unterschied ist, der ASF überlegen machen würde.

Jedoch **gibt es** einen Unterschied, und Du kannst deutlich feststellen, dass, je nachdem, wie beschäftigt dein Betriebssystem ist, Karten **werden** schneller gesammelt, von ein paar Sekunden auf sogar ein paar Minuten, wenn Du extrem unglücklich bist. Obwohl ich nicht in Betracht ziehen würde, ASF nur zu verwenden, weil es Karten schneller sammelt, da sowohl ASF als auch Idle Master von der Funktionsweise des Steam-Netzes beeinflusst werden, interagiert ASF einfach effektiver mit dem Steam-Netz, während Idle Master nicht kontrollieren kann, was der Steam-Client tatsächlich tut (also ist es nicht die Schuld von Idle Master, sondern die des Steam-Clients selbst).

---

### Can ASF farm multiple games at once?

**Ja**, obwohl ASF besser weiß, wann dieses Feature zu verwenden ist, basierend auf dem ausgewählten **[Karten-Sammel-Algorithmus](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance-de-DE)**. Card drops rate when farming multiple games is close to zero, this is why ASF is using multiple games farming exclusively for hours in order to overcome `HoursUntilCardDrops` faster, for up to `32` games at once. This is also why you should focus on configuration part of the ASF, and let algorithms decide what is the best way to achieve the goal - what you think is right, is not necessarily right in reality, farming multiple games at once will not provide you with any card drops.

---

### Kann ASF schnell durch die Spiele springen?

**Nein**, ASF unterstützt nicht und fördert auch nicht die Verwendung von **[Steam-Pannen](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance-de-DE#steam-pannen)**.

---

### Can ASF automatically play each game for X hours before cards are added?

**Nein**, der Sinn der Systemumstellung von Steam-Karten war es, mit falschen Statistiken und Geisterspielern zu kämpfen. ASF wird nicht mehr als nötig dazu beitragen, denn das Hinzufügen eines solchen Features ist nicht geplant und wird nicht geschehen. If your game receives card drops in usual way, ASF will farm them as soon as possible.

---

### Kann ich ein Spiel spielen während ASF am Sammeln ist?

**Nein**. ASF hat im Gegensatz zu IM einen unabhängigen Steam-Client integriert, und das Steam-Netzwerk erlaubt es nur **einem Steam-Client auf einmal**, ein Spiel zu spielen. Sie können die ASF-Verbindung jedoch jederzeit trennen, indem Sie ein Spiel starten (und auf "OK" klicken, wenn Sie gefragt werden, ob das Steam-Netzwerk einen anderen Client trennen soll) - ASF wird dann geduldig warten, bis Sie fertig sind, um den Prozess danach fortsetzen. Alternativ können Sie immer noch (wann immer Sie wollen) im Offline-Modus spielen, wenn das für Sie befriedigend ist.

Beachten Sie, dass die Drop-Rate der Karten, wenn Sie mehrere Spiele spielen, ohnehin nahe bei 0 liegt, daher gibt es keine direkten Vorteile, wenn Sie das mit IM machen können, während es starke Vorteile gibt, wenn Sie sich nicht in andere Spiele einmischen, die mit ASF gestartet wurden, was z. B. für VAC entscheidend ist.

---

## Sicherheit / Datenschutz / VAC / Sperren / Nutzungsbedingungen

---

### Kann ich eine VAC-Sperre bekommen, wenn ich ASF nutze?

Nein, das ist nicht möglich, da ASF (im Gegensatz zu Idle Master oder SAM) in keiner Weise den Steam-Client oder seine Prozesse stört. Es ist physisch unmöglich, eine VAC-Sperre für die Verwendung von ASF zu erhalten, selbst wenn man auf gesicherten Servern spielt, während ASF läuft - das liegt daran, dass **ASF nicht einmal verlangt, dass der Steam-Client überhaupt installiert ist**, um ordnungsgemäß zu funktionieren. ASF ist das einzige Sammel-Programm, das derzeit die VAC-Freiheit garantieren kann.

---

### Kann die Verwendung von ASF verhindern, dass ich auf VAC-geschützten Servern spiele kann, wie **[hier](https://support.steampowered.com/kb_article.php?ref=2117-ilzv-2837)** angegeben?

ASF benötigt keinen Steam-Client, der ausgeführt oder gar installiert wird. Nach diesem Konzept sollte es **keine** VAC-bezogenen Probleme verursachen, da ASF garantiert, dass der Steam-Client und alle seine Prozesse nicht gestört werden - das ist der wichtigste Punkt, wenn es um die VAC-freie Garantie geht, die ASF bietet.

Nach Angaben von Benutzern und nach bestem Wissen und Gewissen ist dies im Moment der Fall, da niemand irgendwelche Probleme wie im obigen Link während der Verwendung von ASF gemeldet hat. Wir konnten das obige Problem nicht mit ASF reproduzieren, während wir es mit Idle Master klar reproduzieren konnten.

Bedenken Sie jedoch, dass Valve irgendwann immer noch ASF zur schwarzen Liste hinzufügen könnte, aber es ist ein kompletter Unsinn, denn selbst wenn sie das tun, könnten Sie dennoch VAC-gesicherte Spiele von ihrem PC aus spielen und ASF gleichzeitig verwenden, z. B. auf einem Server, also bin ich ziemlich sicher, dass sie sehr gut wissen, dass ASF kein verdächtiger VAC-technischer Verdächtiger sein sollte, und sie werden uns das Leben nicht schwerer machen, indem ASF grundlos auf die schwarze Liste gesetzt wird. Im schlimmsten Fall werden Sie jedoch nicht spielen können, wie oben erwähnt, weil die VAC-freie Garantie von ASF immer noch da ist, unabhängig davon, ob Steam die ASF-Binärdatei auf die schwarze Liste setzt oder nicht (und Sie können ASF immer noch auf jeder anderen Maschine starten, ohne dass ein Steam-Client überhaupt installiert ist). Im Moment gibt es keinen Grund, irgendetwas davon zu tun, und wir hoffen, dass es so bleibt.

---

### Ist es sicher?

Wenn Du fragst, ob ASF als Software sicher ist, was bedeutet, dass es ihrem Computer keinen Schaden zufügt, ihre privaten Daten nicht stiehlt, Viren oder ähnliches installiert - ist es sicher. ASF ist frei von Malware, Datendiebstahl, Kryptowährungsminern und jedem (und allen) anderen zweifelhaften Verhalten, das vom Benutzer als bösartig oder unerwünscht angesehen werden kann. In addition to that we have a dedicated **[remote communication](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Remote-communication)** section which covers our privacy policy and ASF behaviour that goes beyond what you configured the program to do yourself.

Unser Quelltext ist Open-Source, und verteilte Binärdateien werden immer aus **[öffentlich verfügbaren Quellen](https://en.wikipedia.org/wiki/Open-source_software)** von **[automatisierten und vertrauenswürdigen kontinuierlichen Integrationssystemen](https://en.wikipedia.org/wiki/Build_automation)** und nicht einmal von Entwicklern selbst erstellt. Jeder Build ist reproduzierbar, indem er unserem Build-Skript folgt, und wird genau dasselbe ergeben, **[deterministisch](https://en.wikipedia.org/wiki/Deterministic_system)** IL (binärer) Code. Wenn Sie aus irgendeinem Grund unseren Builds nicht vertrauen, können Sie ASF jederzeit aus dem Quelltext kompilieren und verwenden, einschließlich aller Bibliotheken, die ASF verwendet (wie SteamKit2), die ebenfalls Open-Source sind.

Am Ende ist es jedoch immer eine Frage des Vertrauens zu den Entwicklern einer Anwendung, also sollten Sie selbst entscheiden, ob Sie ASF für sicher halten oder nicht und ihre Entscheidung möglicherweise mit den oben genannten technischen Argumenten unterstützen. Glauben Sie nicht blind meinen Worten - überprüfen Sie es selbst, denn das ist der einzige Weg, um sicher zu gehen.

---

### Kann ich dafür gesperrt werden?

Um diese Frage zu beantworten, sollten wir einen genaueren Blick auf die **[Steam-Nutzungsbedingungen](https://store.steampowered.com/subscriber_agreement)** werfen. Steam verbietet nicht die Verwendung mehrerer Konten, vielmehr **[erlauben sie es](https://support.steampowered.com/kb_article.php?ref=8625-WRAH-9030#share)**, da Du denselben mobilen Authentifikator für mehr als ein Konto verwenden kannst. Was es jedoch nicht erlaubt, ist die gemeinsame Nutzung von Konten mit anderen Personen, aber das tun wir hier nicht.

Der einzige wirkliche Punkt, der ASF betrifft, ist der folgende:
> Sie dürfen keine Cheats, Automationssoftware (Bots), Modifikationen, Hacks oder andere nicht autorisierte Software von Drittanbietern verwenden, um den Prozess des Abonnements Marketplace zu ändern oder zu automatisieren.

Die Frage ist, was ist eigentlich der "Subscription Marketplace-Prozess". Wie wir lesen können:

> Ein Beispiel eines Steam-Abonnement-Marktplatzes ist der Steam Community Markt

Wir ändern oder automatisieren den Prozess des Abonnenten-Marktplatzes nicht, wenn wir unter Abonnenten-Marktplatz den Markt der Steam-Community oder den Steam-Shop verstehen. Jedoch...

> Valve ist berechtigt, ihr Benutzerkonto oder ein bestimmtes Abonnement/bestimmte Abonnements in den folgenden Fällen jederzeit zu löschen: (a) Valve stellt generell die Bereitstellung von Abonnements für Abonnenten in einer vergleichbaren Situation ein, oder (b) Sie verstoßen gegen Bedingungen der vorliegenden Vereinbarung (einschließlich etwaiger Abonnementbedingungen oder Nutzungsrichtlinien).

Daher ist ASF, wie bei jeder Steam-Software, nicht von Valve autorisiert und wir können nicht garantieren, dass Du nicht gesperrt wirst, wenn Valve plötzlich entscheidet, dass sie Konten mit ASF jetzt sperren. This is exceptionally unlikely considering the fact that ASF is being used on more than a million of Steam accounts, but still a possibility, regardless of actual probability.

Besonders weil:
> Hinsichtlich jeglicher Abonnements sowie vertragsgegenständlichen Inhalte und Leistungen, die nicht der Urheberschaft von Valve entstammen, nimmt Valve keine Überwachung derartiger Inhalte von Drittanbietern, die auf der Steam-Plattform oder über sonstige Quellen verfügbar sind, vor. Valve übernimmt in Bezug auf derartige Inhalte von Drittanbietern keinerlei Verantwortung oder Haftung. Bestimmte Anwendungssoftware von Drittanbietern kann von Unternehmen für geschäftliche Zwecke verwendet werden – Sie dürfen derartige Software über die Steam-Plattform jedoch ausschließlich für ihren privaten Gebrauch erwerben.

Allerdings erkennt Valve klar an, dass es "Steam-Sammler" gibt, wie **[hier](https://support.steampowered.com/kb_article.php?ref=2117-ilzv-2837)** angegeben, also wenn Du mich fragst, bin ich mir ziemlich sicher, dass sie, wenn sie nicht einverstanden mit Ihnen wären, bereits etwas tun würden, anstatt darauf hinzuweisen, dass sie VAC-technisch Probleme verursachen könnten. Das Schlüsselwort hier ist **Steam** Sammler, zum Beispiel ASF, und nicht **Spiel** Sammler.

Bitte beachten Sie, dass das oben genannte lediglich unsere Interpretation der **[Steam-AGB](https://store.steampowered.com/subscriber_agreement/german)**, sowie diverser anderer Punkte ist. ASF ist durch die Apache 2.0 Lizenz lizenziert, die welche eindeutig vorschreibt:

> Unless required by applicable law or agreed to in writing, ASF is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.

Sie verwenden diese Software auf eigene Gefahr. Es ist sehr unwahrscheinlich, dass man dafür gesperrt wird, aber dies geschehen, kann man nur sich selbst die Schuld dafür geben.

---

### Wurde jemand dafür gesperrt?

**Ja**, wir hatten bereits ein paar Vorfälle, die zu einer Art Steam-Sperre führten. Ob ASF selbst die Ursache war oder nicht, ist eine ganz andere Geschichte, die wir wahrscheinlich nie erfahren werden.

First case involved a guy with over 1000+ bots getting trade banned (together with all bots), most likely due to excessive usage of `loot ASF` executed on all bots at once, or other suspicious one-side amount of trades in a very short time.

> Hallo XXX, Vielen Dank, dass Sie den Steam-Support kontaktiert haben. Es scheint, als ob dieses Konto verwendet wurde, um ein Netzwerk von Bot-Accounts zu verwalten. Botting ist eine Verletzung der Steam-Abonnentenvereinbarung.

Verwenden Sie bitte etwas gesunden Menschenverstand und gehen Sie nicht davon aus, dass solche verrückten Dinge nur tun können, weil ASF Ihnen dies erlaubt. Das Ausführen von `loot ASF` auf über 1k Bots kann leicht als **[DDoS](https://en.wikipedia.org/wiki/DDoS)** Angriff angesehen werden, und ich persönlich bin nicht schockiert, dass jemand für so eine Sache gesperrt wurde. Bedenken und benutzen Sie etwas gesunden Menschenverstand und sein Sie fair bei der Verwendung in Bezug auf den Steam Service, und ** höchstwahrscheinlich** wird es Ihnen gut gehen.

Second case involved a guy with 170+ bots getting banned during Steam's 2017 Winter Sale.

> Dein Account wurde wegen Verletzung der Steam-Abonnementvereinbarung gesperrt. Nach den Handelsanfragen und anderen Faktoren zu urteilen, wurde dieser Benutzeraccount verwendet um auf illegale Weise Steam-Sammelkarten zu sammeln und weitere damit verbundene nicht nur komerzielle Aktivitäten durchzuführen. Der Benutzeraccount wurde permanent gesperrt und der Steam-Support kann keine zusätzliche Hilfe zu diesem Fall anbieten.

Dieser Fall ist wieder einmal sehr schwer zu analysieren, da die Reaktion des Steam-Supports, der kaum Details bietet, vage ist. Basierend auf meinen persönlichen Ansichten hat dieser Benutzer wahrscheinlich Steam-Karten gegen irgendeine Art von Geld eingetauscht (Level-up-Bot?) oder auf andere Weise versucht, bei Steam Geld auszuzahlen. Im Falle, dass Sie sich dessen nicht bewusst sind es ist ebenfalls in den **[Steam-Nutzungsbedingungen" untersagt](https://store.steampowered.com/subscriber_agreement/german)**.

Third case involved user with 120+ bots being banned for breach of **[Steam online conduct](https://store.steampowered.com/online_conduct?l=english)**.

> Hallo XXX, Vielen Dank, dass Sie den Steam-Support kontaktiert haben. Dieser und andere Accounts wurden für das Fluten unserer Netzwerk-Infrastruktur verwendet, was gegen den Steam Verhaltenskodex verstößt. Der Account wurde dauerhaft gesperrt und der Steam-Support kann keinen zusätzlichen Support diesbezüglich anbieten.

Dieser Fall ist Aufgrund der zusätzlichen Angaben des Benutzers etwas einfacher zu analysieren. Anscheinend verwendete der Benutzer **eine sehr veraltete ASF-Version**, die einen Fehler enthielt, der dazu führte, dass ASF eine übermäßige Anzahl von Anfragen an Steam-Server sendete. Der Fehler selbst existierte zunächst nicht, wurde aber wegen einer Änderung von Steam ausgelöst, die in einer späteren Version behoben wurde. **ASF is supported only in [latest stable version](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest) released on GitHub**. Software wird von Menschen geschrieben, und Menschen neigen dazu, Fehler zu begehen. Wenn der Fehler einen globalen Umfang hat, wird er schnell behoben und als Bugfix für alle Benutzer veröffentlicht. Valve won't suddenly ban over a million of ASF users due to my mistake, for obvious reasons. Wenn Du jedoch absichtlich auf die Verwendung einer aktuellen Version von ASF verzichtest, dann bist Du per Definition in einer sehr kleinen Minderheit von Benutzern, die **Vorfällen wie diesen** aufgrund von **keiner technischen Unterstützung** ausgesetzt sind, da niemand auf deine veraltete Version von ASF aufpasst, niemand sie repariert und niemand sicherstellt, dass Du nicht einfach durch den Start von ASF völlig gesperrt wirst. **Bitte verwende die aktuellste Version**, nicht nur ASF, sondern auch alle anderen Anwendungen.

The most recent case happened around June of 2021, according to the user:

> Using your program, I have been making booster packages with 28 accounts for 3 years and with 128 accounts for the last 6 months. I was online with maximum 15 accounts simultaneously to make booster packs and send them to the main account. Last month, I increased the number of online accounts simultaneously to 20, and 1 week after that, all of my accounts were banned. This email is not to blame you, on the contrary, I was always aware of the consequences. I wanted you to know what types of behavior result in a permanent ban.

It's hard to say whether increase in concurrent accounts online was the direct reason for the ban, I wouldn't count on that, instead I believe that the number of accounts alone was the main culprit, increased concurrency of online accounts probably just drew attention to the user in question, as he clearly had far more bots than our recommendation.

---

Alle oben genannten Vorfälle haben eines gemeinsam - ASF ist nur ein Programm und es ist **deine** Entscheidung, wie Du es nutzen willst. Du bekommst keine Sperre für die direkte Verwendung von ASF, aber es kommt darauf an **wie** Du ASF benutzt. It can be a helper tool farming just one single account, or a massive farming network made from thousands of bots. In jedem dieser Fälle biete ich keine rechtliche Beratung an, und Du solltest dich überhaupt erst selbst über deine ASF-Nutzung entscheiden. Ich verheimliche keine Informationen, die dir helfen könnten, z. B. die Tatsache, dass ASF einige Leute gesperrt hat, da ich keinen Grund dazu habe - es ist deine Entscheidung, was Du mit diesen Informationen machen willst. Wenn Sie mich fragen - benutzen Sie ihren gesunden Menschenverstand und vermeiden Sie es, ein massives Sammel-Netzwerk von Bots zu betreiben oder gar hunderte Handelsangebote gleichzeitig zu senden und verwenden Sie immer die aktuellste ASF-Version und alles _sollte_ gut sein. Jeder einzelne Vorfall dieser Art ist aus **irgendeinem Grund** immer Leuten passiert, die unsere Empfehlung missachtet und entschieden haben, dass sie es besser wissen, wie viele Bots sie betreiben können. Ob es nur ein Zufall oder ein tatsächlicher Faktor ist, das liegt bei dir zu entscheiden. Ich biete keine rechtliche Beratung an, sondern gebe dir nur meine Gedanken, die Du nützlich finden kannst, oder ignoriere sie ganz und gar und arbeite nur mit den oben genannten Fakten.

---

### Welche Datenschutzinformationen gibt ASF weiter?

You can find detailed explanation in **[remote communication](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Remote-communication)** section. Du solltest es lesen, wenn Du dich um deine Privatsphäre sorgst, z. B. wenn Du dich fragst, warum Konten, die in ASF verwendet werden, unserer Steam-Gruppe beitreten. ASF sammelt keine sensiblen Informationen und gibt sie nicht an Dritte weiter.

---

## Sonstiges

---

### Ich verwende ein nicht unterstütztes Betriebssystem z. B. 32-Bit-Windows, kann ich trotzdem die neueste ASF-Version verwenden?

Ja, und diese Version wird auch unterstützt, nur nicht offiziell erstellt. Schaue dir hierfür die generische Varianten im Abschnitt **[Kompatibilität](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility-de-DE)** an. ASF doesn't have any strong dependency upon the OS, and it can work anywhere where you can get a working .NET runtime, which includes 32-bit Windows, even if there is no `win-x86` OS-specific package from us.

---

### ASF ist großartig! Kann ich spenden?

Ja, und wir freuen uns sehr zu hören, dass dir unser Projekt gefällt! Unter jeder **[Veröffentlichung](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** und auch **[auf der Hauptseite](https://github.com/JustArchiNET/ArchiSteamFarm)** findest Du verschiedene Möglichkeiten eine Spende zu tätigen. It's nice to note that in addition to generic money donations we also accept Steam items, so nothing is stopping you from donating skins, keys or a small part of the cards that you've farmed with ASF if you'd like to. Vielen Dank im Voraus für deine Großzügigkeit!

---

### Ich verwende den Steam Parental Code um mein Konto zu schützen, muss ich diesen irgendwo eingeben?

Ja, Du musst ihn in der `SteamParentalCode` Bot-Konfigurationseigenschaft setzen. Dies liegt hauptsächlich daran, dass ASF auf viele geschützte Teile deines Steam-Kontos zugreift und es für ASF unmöglich ist ohne ihn zu arbeiten.

---

### Ich möchte nicht, dass ASF standardmäßig irgendwelche Spiele sammelt, aber ich möchte zusätzliche ASF-Funktionen verwenden. Ist das möglich?

Ja, wenn Sie ASF nur mit dem pausierten Karten-Farming-Modul starten wollen, können Sie die Bot-Konfigurationseigenschaft `Paused` auf `true` setzen, um dies zu erreichen. Dies ermöglicht es Ihnen, es während der Laufzeit `fortzusetzen`.

If you want to completely disable cards farming module and ensure that it'll never run without you explicitly telling it otherwise, then we recommend to set `FarmPriorityQueueOnly` to `true`, which instead of just pausing it, will disable the farming completely until you add the games to idle priority queue yourself.

Wenn das Karten-Farming-Modul angehalten/deaktiviert ist, können Sie zusätzliche ASF-Funktionen nutzen, wie z. B. `GamesPlayedWhileIdle`.

---

### Kann ich ASF in die Taskleiste minimieren?

ASF ist eine Konsolenanwendung, es gibt kein zu minimierendes Fenster, da das Fenster von deinem Betriebssystem für dich erstellt wird. Sie können jedoch ein beliebiges Drittanbieterprogramm verwenden wie z. B. **[RBTray](https://github.com/benbuck/rbtray)** für Windows oder **[screen](https://linux.die.net/man/1/screen)** für Linux/macOS. Dies sind nur Beispiele. Es gibt viele andere Apps mit ähnlicher Funktionalität.

---

### Stellt die Verwendung von ASF die Berechtigung zum Erhalt von Booster Packs sicher?

**Ja**. ASF verwendet die gleiche Methode wie der offizielle Client, um sich im Steam-Netzwerk anzumelden, daher enthält es auch die Möglichkeit, Booster Packs für die verwendeten Konten zu erhalten. Mehr noch: Um diese Fähigkeit zu bewahren, muss man sich nicht einmal in die Steam-Community einloggen. Damit können Sie, falls Sie es wünschen, den `OnlineStatus` `Offline` sicher verwenden.

---

### Gibt es eine Möglichkeit mit ASF zu kommunizieren?

Ja, auf verschiedene Arten. Weitere Informationen findest Du im Abschnitt **[Befehle](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-de-DE)**.

---

### Ich möchte bei der Übersetzung von ASF helfen, was muss ich tun?

Vielen Dank für dein Intresse! Alle Details hierzu kannst Du in unserem Abschnitt **[Lokalisierung](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Localization-de-DE)** finden.

---

### Ich habe nur ein (Haupt-)Konto zu ASF hinzugefügt, kann ich trotzdem Befehle per Steam-Chat senden?

**Ja**, es wird im Abschnitt **[Befehle](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-de-DE#notes)** erklärt. Du kannst dies über den Steam-Gruppen-Chat tun, obwohl die Verwendung von **[ASF-UI](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-de-DE#asf-ui)** für dich einfacher sein könnte.

---

### ASF scheint zu funktionieren, aber ich bekomme keine Karten!

Die Sammelrate der Karten ist von Spiel zu Spiel unterschiedlich, wie Du in **[Performance](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance-de-DE)** nachlesen kannst. Es dauert eine Weile, normalerweise **mehrere Stunden pro Spiel** und Du solltest nicht erwarten, dass Karten in ein paar Minuten nach dem Start eines Programmes gesammelt werden. If you can see that ASF actively checks cards status, and switches the game after current one is fully farmed, then everything works fine. Es ist möglich, dass Du eine Option wie `DismissInventoryNotifications` von `BotBehaviour` aktiviert hast, die Inventarbenachrichtigungen automatisch ausblendet. Siehe **[Konfiguration](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-de-DE)** für Details.

---

### Wie kann ich den ASF-Prozess für mein Konto vollständig stoppen?

Beende einfach den ASF-Prozess, z. B. durch Anklicken von [X] unter Windows. Wenn Du stattdessen einen bestimmten Bot deiner Wahl stoppen, aber andere am Laufen halten möchtest, dann schaue dir die `Enabled` **[Bot-Konfigurationseigenschaft](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-de-DE#bot-konfiguration)** an, oder den `stop` **[Befehl](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-de-DE)**. If you instead want to stop automatic farming process, yet keep ASF running for your account, then that's what `Paused` **[bot config property](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#bot-config)** and `pause` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** is for.

---

### Wie viele Bots kann ich mit ASF verwenden?

ASF als Programm hat keine unmittelbare Obergrenze für Bot-Instanzen, sodass Du so viele Bot-Instanzen ausführen kannst, wie Du Speicher auf deinem Computer hast, aber Du bist immer noch durch das Steam-Netzwerk und andere Steam-Dienste limitiert. Derzeit kannst Du bis zu 100-200 Bots mit einer einzigen IP und einer einzelnen ASF-Instanz laufen lassen. Es ist möglich, mehr Bots mit mehr IPs und mehr ASF-Instanzen auszuführen, indem man die IP-Beschränkungen umgeht. Bedenke, dass du, wenn Du diese große Anzahl von Bots verwendest, deren Anzahl Du selbst kontrollieren solltest, z. B. sicherstellen, dass sich alle tatsächlich anmelden und zur gleichen Zeit arbeiten. ASF wurde nicht für diese große Anzahl von Bots optimiert und die allgemeine Regel gilt, dass **je mehr Bots Du hast, desto mehr Probleme wirst Du bekommen**. Außerdem ist zu beachten, dass das obige Limit im Allgemeinen von vielen internen Faktoren abhängt - es ist eher eine Annäherung als ein strenges Limit - Du wirst höchstwahrscheinlich in der Lage sein, mehr/weniger Bots als oben beschrieben auszuführen.

Das ASF-Team empfiehlt, bis zu **10 Bots insgesamt** laufen zu lassen (und zu **besitzen**), alles darüber wird nicht unterstützt und auf eigenes Risiko durchgeführt, gegen unseren Vorschlag, der hier gemacht wurde. Diese Empfehlung basiert auf internen Valve-Richtlinien sowie unseren eigenen Empfehlungen. Ob Du diese Regel einhältst oder nicht, ist deine Entscheidung, ASF als Werkzeug wird nicht gegen deinen eigenen Willen handeln, auch wenn es dazu führen sollte, dass deine Steam-Konten dafür gesperrt werden. Daher wird ASF dir eine Warnung anzeigen, wenn Du über das hinausgehst, was wir empfehlen, aber trotzdem alles, was Du willst, auf eigenes Risiko und ohne unseren Support ausführen kannst.

---

### Kann ich dann mehr ASF-Instanzen ausführen?

Du kannst so viele ASF-Instanzen auf einem Computer ausführen, wie Du willst, vorausgesetzt, jede Instanz hat ihr eigenes Verzeichnis und ihre eigenen Konfigurationen, und das in einer Instanz verwendete Konto wird in einer anderen nicht verwendet. Allerdings solltest Du dich fragen, warum Du das tun willst. ASF ist dazu optimiert, mehrere hundert Accounts gleichzeitig zu verwalten. Das Starten vieler Bots in ihren eigenen ASF-Instazen senkt die (Gesamt-)Leistung, verbraucht mehr Betriebssystem-Ressourcen (beispielsweise CPU, Arbeitsspeicher), und verursacht potentiell Probleme beim synchronisieren zwischen den einzelnen ASF-Instanzen, da ASF gezwungen ist, seine Limitierung (Limiters) mit den anderen Instanzen zu teilen.

Deshalb ist es mein **Ratschlag**, immer maximal eine ASF-Instanz pro IP/Schnittstelle auszuführen. Wenn Sie mehr IPs/Schnittstelle haben, können Sie mit allen Mitteln mehr ASF-Instanzen ausführen, mit jeder Instanz über eine eigene IP/Schnittstelle oder eine eindeutige `WebProxy`-Einstellung. Wenn Sie dies nicht machen, ist es völlig sinnlos, mehr ASF-Instanzen zu starten, da Sie sonst jede einzelne IP/Schnittstelle auf 1 Instanz begrenzt ist. Steam wird es dir auf magische Weise nicht erlauben, mehr Bots auszuführen, nur weil Du sie in einer anderen ASF-Instanz gestartet hast, und ASF beschränkt dich von Anfang an nicht.

Natürlich gibt es immer noch sinnvolle Anwendungsfälle für mehrere ASF-Instanzen auf derselben Netzwerkschnittstelle, wie z. B. das Hosten von ASF für ihre Freunde, bei denen jeder Freund eine eigene ASF Instanz besitzt, um die Isolation zwischen Bots und sogar den ASF-Prozessen selbst zu gewährleisten. Dies hat aber nicht den Zweck, geschweige denn die Möglichkeit, um Steambeschränkungen zu umgehen.

---

### Was bedeutet Status beim Einlösen eines Produktschlüssels?

Der Status zeigt an, wie sich der gegebene Einlösungsversuch ausgewirkt hat. Es gibt viele verschiedene Stati, darunter die gängigsten:

| Status                  | Beschreibung                                                                                                                                                                                                                                                         |
| ----------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| NoDetail                | Der Status "OK" zeigt Erfolg an - der Produktschlüssel wurde erfolgreich eingelöst.                                                                                                                                                                                  |
| Timeout                 | Das Steam-Netzwerk hat nicht in einer bestimmten Zeit reagiert, wir wissen nicht, ob der Produktschlüssel eingelöst wurde oder nicht (höchstwahrscheinlich wurde er das, aber Sie könen es noch einmal versuchen).                                                   |
| BadActivationCode       | Der angegebene Produktschlüssel ist ungültig (nicht als gültiger Produktschlüssel im Steam-Netzwerk erkannt).                                                                                                                                                        |
| DuplicateActivationCode | Der angegebene Produktschlüssel wurde bereits von einem anderen Konto eingelöst oder vom Entwickler/Herrausgeber widerrufen.                                                                                                                                         |
| AlreadyPurchased        | Ihr Konto besitzt bereits `packageID`, das mit diesem Produktschlüssel verbunden ist. Bedenken Sie, dass dies nicht anzeigt, ob der Produktschlüssel `DuplicateActivationCode` ist oder nicht - nur dass er gültig ist und bei diesem Versuch nicht verwendet wurde. |
| RestrictedCountry       | Dies ist ein Produktschlüssel mit Regionssperre und das Konto befindet sich in einer ungültigen Region, in der Sie ihn nicht einlösen dürfen.                                                                                                                        |
| DoesNotOwnRequiredApp   | Sie können diesen Produktschlüssel nicht einlösen, da Ihnen ein anderes Spiel fehlt - hauptsächlich das Basisspiel, wenn Sie versuchen, das DLC-Paket einzulösen.                                                                                                    |
| RateLimited             | Sie haben zu viele Einlösungsversuche durchgeführt und das Konto wurde vorübergehend gesperrt. Versuchen Sie es in einer Stunde erneut.                                                                                                                              |

---

### Gehörst Du zu einem Karten-Sammel-Dienst?

**Nein**. ASF ist mit keinem Dienst verknüpft und alle diese Behauptungen sind falsch. Dein Steam-Konto ist dein Eigentum und Du kannst dein Konto auf jede erdenkliche Weise nutzen, aber Valve hat es klar in den **[offiziellen Nutzungsbedingungen](https://store.steampowered.com/subscriber_agreement/german)** erklärt:

> Sie sind für die Sicherheit ihres Computersystems und die Geheimhaltung ihrer Anmeldedaten und ihres Kennworts verantwortlich. Valve ist in keiner Weise für die Verwendung ihres Kennworts und die Nutzung ihres Benutzerkontos sowie auch nicht für jegliche Kommunikation und Aktivität auf Steam verantwortlich, die durch die Verwendung ihres Kennworts durch Sie oder durch jegliche andere Personen, denen Sie absichtlich oder unabsichtlich ihr Kennwort mitgeteilt haben, zustande kommt.

ASF ist unter der freien Apache 2.0 Lizenz lizenziert, die es anderen Entwicklern ermöglicht, ASF weiter in ihre eigenen Projekte und Dienste zu integrieren. Es wird jedoch nicht garantiert, dass solche Drittprojekte, die ASF verwenden, sicher, überprüft, angemessen oder legal gemäß **[Steam-Nutzungsbedingungen](https://store.steampowered.com/subscriber_agreement/german)** (ToS/ AGB) sind. Wenn Du unsere Meinung hören möchtest, **wir empfehlen dir dringend, KEINE deiner Kontoinformationen mit Drittanbietern zu teilen**. Wenn sich ein solcher Dienst als **typischer Betrug** herausstellt, wirst Du mit dem Problem allein gelassen, höchstwahrscheinlich ohne dein Steam-Konto und ASF übernimmt keine Verantwortung für Dienstleistungen von Drittanbietern, die behaupten, sicher und geschützt zu sein, weil das ASF-Team weder genehmigt noch eine davon überprüft hat. Mit anderen Worten: **Du benutzt sie auf eigene Gefahr, entgegen unseres oben genannten Vorschlags**.

Zusätzlich beschreibt die offizielle **[Steam-AGB](https://store.steampowered.com/subscriber_agreement/german)** eindeutig:

> Es ist Ihnen untersagt, ihr Kennwort oder Benutzerkonto Dritten offenzulegen bzw. zugänglich zu machen oder Dritte sonst ihr Kennwort oder Benutzerkonto nutzen zu lassen, es sei denn, Valve hat dem ausdrücklich zugestimmt.

Es ist dein Konto und deine Entscheidung. Sag nur nicht, dass dich niemand gewarnt hat. ASF als Programm erfüllt alle oben genannten Bedingungen, da Du deine Kontodaten an niemanden weitergibst und Du das Programm für deinen eigenen persönlichen Gebrauch verwendest, aber jeder andere "Karten-Sammel-Dienst" verlangt von dir deine Zugangsdaten, sodass es auch gegen die oben genannte Regel verstößt (eigentlich mehrere von Ihnen). Wie bei der **[Steam-Nutzungsbedingungen](https://store.steampowered.com/subscriber_agreement/german)** (AGB)-Auswertung, bieten wir keine Rechtsberatung an, und Sie sollten sich selbst entscheiden, ob Sie diese Dienste nutzen möchten oder nicht. Unserer Auffassung nach **verstößt es direkt gegen die [Steam-AGB](https://store.steampowered.com/subscriber_agreement/german)** und kann zu einer Suspendierung führen, wenn Valve dies herausfindet. Wie bereits erwähnt, **wir empfehlen dringend, KEINE dieser Dienste zu nutzen**.

---

## Probleme

---

### Eines meiner Spiele wird nun seit mehr als 10 Stunden gefarmt, aber ich habe noch keine Karten bekommen!

Der Grund dafür könnte mit dem bekannten Steam Problem zusammenhängen, das auftritt, wenn Sie zwei Lizenzen für ein und dasselbe Spiel haben, von denen eine eine limiterte Kartenrate besitzt. Dies passiert üblicherweise, wenn Sie das Spiel kostenlos während eines Massengiveaway auf Steam aktiviert haben und anschließend einen Schlüssel für das gleiche Spiel (aber ohne Limitierungen) aktivieren. Wenn solch eine Situation eintritt, meldet Steam auf der Abzeichenseite, dass das Spiel noch Karten zum sammeln hat, aber egal, wie viel Sie spielen - die Karten werden aufgrund der kostenlosen Lizenz in ihrem Konto nie gutgeschrieben. Da dies kein Fehler seitens ASF, sondern von Steam ist, können wir diesen auf ASF-Seite nicht umgehen und Sie müssen das Problem selbst lösen.

Es gibt zwei Möglichkeiten, das Problem zu lösen. Firstly, you can blacklist this game in ASF, either with `fbadd` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** or with `Blacklist` **[configuration property](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration)**. Dies verhindert zwar, dass ASF versucht Karten von dem Spiel zu sammeln, löst aber nicht das eigentliche Problem, welches verhindert, dass Sie Karten von dem betroffenen Spiel erhalten. Zum Zweiten können Sie das Steam-Support Self-Service Tool verwenden um die kostenlose Lizenz von ihrem Konto zu entfernen, sodass nur noch die volle Lizenz, welche Karten beinhaltet, übrig bleibt. Um dies zu erreichen, besuchen Sie zuerst ihre **["Lizenzen und Produktschlüssel-Aktivierungen"](https://store.steampowered.com/account/licenses)**-Seite und finden Sie sowohl die kostenlose als auch kostenpflichtige Lizenz für das betroffene Spiel. Normalerweise ist es ziemlich einfach. Beide haben einen ähnlichen Namen, aber die kostenlose Lizenz enthält "Limited free promotional package " oder andere "promo" im Lizenznamen, sowie "complimentary" im Bereich "Akquisitionsmethode". Manchmal könnte es schwieriger sein, zum Beispiel, wenn das freie Paket in einem Bundle war und einen anderen Namen hat. Falls Sie einige dieser Lizenzen gesehen haben - dann ist es tatsächlich das Problem, das hier beschrieben wurde und Sie können die kostenlose Lizenz sicher entfernen, ohne das Spiel zu verlieren.

Um die kostenlose Lizenz von ihrem Konto zu entfernen, gehen Sie auf **[Steam-Support-Seite](https://help.steampowered.com/wizard/HelpWithGame)** und legen Sie den betroffenen Spielnamen in das Suchfeld das Spiel sollte im Bereich "Produkte" verfügbar sein; klicken Sie darauf. Alternativ können Sie einfach den `https://help.steampowered.com/wizard/HelpWithGame?appid=<AppID>` Link verwenden und `<AppID>` durch AppID des Spiels ersetzen, das Probleme verursacht. Danach klicken Sie auf "Ich möchte dieses Spiel dauerhaft von meinem Konto entfernen" und wählen die fehlerhafte kostenlose Lizenz, die Sie oben gefunden haben- in der Regel die mit "limited free promotional package " im Namen (oder ähnlichem). After removal of the free license, ASF should be able to drop cards from the affected game without issues, you should restart the farming operation after the removal just to be sure that Steam picks up the right license this time.

---

### ASF erkennt Spiel `X` nicht als zum Sammeln verfügbar, aber ich weiß, dass es Steam-Karten enthält!

Hierfür gibt es zwei Hauptgründe. Der erste und offensichtlichste Grund ist die Tatsache, dass Du dich auf den **Steam-Shop** beziehst, wo ein gegebenes Spiel mit Karten angekündigt wird. Diese Annahme ist **falsch**, da es lediglich besagt, dass das Spiel Karten **enthält**, aber nicht unbedingt ob diese Funktion für dieses Spiel auch sofort **aktiviert** ist. Mehr dazu kannst Du in den **[offiziellen Ankündigungen](https://steamcommunity.com/games/593110/announcements/detail/1954971077935370845)** lesen.

Kurz gesagt, das Karten-Symbol im Steam-Shop bedeutet nichts, prüfe deine **[Abzeichen-Seiten](https://steamcommunity.com/my/badges)** zur Bestätigung, ob ein Spiel Karten aktiviert hat oder nicht - das ist auch das, was ASF tut. If your game doesn't appear on the list as a game with cards possible to drop, then this game is **not** possible to farm, regardless of reason.

Second issue is less obvious, and it's the situation when you can see that your game indeed is available with card drops on your badge page, yet it's not being farmed by ASF right away. Es sei denn, Du triffst einen anderen Fehler, wie z. B. ASF, das nicht in der Lage ist, Abzeichen-Seiten zu überprüfen (siehe unten), es ist einfach ein Cache-Effekt und auf der ASF-Seite berichtet Steam immer noch über veraltete Abzeichen-Seiten. Dieses Problem sollte sich früher oder später lösen, wenn der Cache entwertet wird. Es gibt auch keine Möglichkeit, dies auf unserer Seite zu beheben.

Of course, all of that assumes that you're running ASF with default untouched settings, since you could also add this game to farming blacklist, use `FarmPriorityQueueOnly`, `SkipRefundableGames` and so on.

---

### Why playtime of games farmed through ASF doesn't increase?

Das tut es, aber **nicht in Echtzeit**. Steam zeichnet deine Spielzeit in festen Intervallen auf und aktualisiert die Zeitpläne dafür, aber es ist nicht garantiert, dass sie sofort nach Beendigung der Sitzung aktualisiert wird, geschweige denn während dieser Zeit. Just because the playtime isn't updated in real-time doesn't mean that it's not recorded, it's usually updated every 30 minutes or so.

---

### Worin besteht der Unterschied zwischen einer Warnung und einem Fehler im Protokoll?

ASF schreibt eine Reihe von Informationen über verschiedene Logging-Ebenen in sein Protokoll. Unser Ziel ist es, **präzise** zu erklären, was ASF tut, einschließlich welcher Steam-Probleme es zu bewältigen hat, oder anderer zu überwindender Probleme. Meistens ist nicht alles relevant, deshalb haben wir in ASF zwei große Stufen, die in Bezug auf Probleme verwendet werden - eine Warnstufe und eine Fehlerstufe.

Die allgemeine ASF-Regel ist, dass Warnungen **keine** Fehler sind, daher sollten sie **nicht** gemeldet werden. Eine Warnung ist ein Indikator für dich, dass etwas möglicherweise Unerwünschtes passiert. Egal ob es Steam war das nicht reagierte, die API Fehler geworfen hat oder deine Netzwerkverbindung Probleme hatte - es ist eine Warnung und das bedeutet, dass wir erwarten das dies passiert, also belästige die ASF-Entwicklung nicht damit. Natürlich steht es dir frei, nach Ihnen zu fragen oder Hilfe zu erhalten, indem Du unsere technische Unterstützung in Anspruch nimmst, aber Du solltest nicht davon ausgehen, dass es sich um meldenswerte ASF-Fehler handelt (sofern wir nichts anderes bestätigen).

Fehler hingegen deuten auf eine Situation hin, die nicht eintreten sollte, daher sind sie es wert, gemeldet zu werden, solange man sich vergewissert hat, dass man es nicht selbst ist, der sie verursacht. Wenn es sich um eine allgemeine Situation handelt, die wir erwarten, dann wird sie stattdessen in eine Warnung umgewandelt. Andernfalls handelt es sich möglicherweise um einen Fehler, der korrigiert werden sollte, nicht stillschweigend ignoriert werden sollte, vorausgesetzt, er ist nicht das Ergebnis deines eigenen technischen Problems. Wenn Du zum Beispiel ungültigen Inhalt in die Datei `ASF.json` einträgst, wird ein Fehler auftreten, da ASF ihn nicht analysieren kann, aber Du warst es, der ihn dort platziert hat, also solltest Du diesen Fehler nicht an uns melden (es sei denn, Du hast bestätigt, dass ASF falsch ist und deine Struktur tatsächlich absolut korrekt ist).

In einem Satz: Fehler melden und Warnungen nicht melden. Du kannst nach wie vor zu Warnungen Fragen stellen und in unseren Unterstützungsbereichen Hilfe erhalten.

---

### ASF startet nicht, das Programmfenster schließt sich sofort!

Unter normalen Bedingungen erzeugt jeder ASF-Crash oder -Ausgang eine `log.txt` im Verzeichnis des Programms, die Sie sich ansehen können, um die Ursache dafür zu finden. Zusätzlich werden einige kürzliche Logdateien auch im `Logs`-Verzeichnis archiviert, da die Haupt-`log.txt`-Datei wird mit jedem ASF-Lauf überschrieben.

However, if even .NET runtime isn't able to boot on your machine, then `log.txt` will not be generated. If that happens to you then you most likely forgot to install .NET prerequisites, as stated in **[setting up](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up#os-specific-setup)** guide. Other common problems include trying to launch wrong ASF variant for your OS, or in other way missing native .NET runtime dependencies. Wenn sich das Konsolenfenster zu früh schließt, als dass Du die Nachricht lesen könntest, dann öffne die unabhängige Konsole und starte von dort aus die ASF-Binärdatei. Öffnen Sie beispielsweise unter Windows das ASF-Verzeichnis, halten Sie `Shift` gedrückt, klicken Sie mit der rechten Maustaste in den Ordner und wählen Sie *"Befehlsfenster hier öffnen"* (oder *Powershell*), geben Sie dann in die Konsole `.\ArchiSteamFarm.exe` ein und bestätigen Sie mit Enter. Auf diese Weise erhältst Du eine genaue Meldung, warum ASF nicht richtig startet.

---

### ASF wirft mich aus meiner Steam-Client-Sitzung während ich spiele! / *Dieser Account wird an einem anderen PC verwendet*

Dies wird als Meldung im Steam-Overlay angezeigt, dass das Konto während des Spiels woanders verwendet wird. Dieses Problem kann zwei verschiedene Gründe haben.

Ein Grund dafür sind defekte Pakete (Spiele), die speziell eine Spielsperre nicht richtig halten, aber erwarten, dass diese vom Client besessen wird. Ein Beispiel für ein solches Paket wäre Skyrim SE. Dein Steam-Client startet das Spiel richtig, aber dieses Spiel registriert sich selbst nicht als in Benutzung. Aus diesem Grund sieht ASF, dass es frei ist den Prozess fortzusetzen, was es tut, und das wirft dich aus dem Steam-Netzwerk, da Steam plötzlich erkennt, dass das Konto an einem anderen Ort verwendet wird.

Ein zweiter Grund kann auftreten, wenn Du auf deinem PC spielst, während ASF wartet (besonders auf einem anderen Computer) und Du deine Netzwerkverbindung verlierst. In diesem Fall markiert dich das Steam-Netzwerk als offline und gibt die Spielsperre (wie oben) frei, was ASF (z. B. auf einer anderen Maschine) dazu veranlasst, das Sammeln wieder aufzunehmen. Wenn dein PC wieder online ist, kann Steam keine Spielsperre mehr erfassen (die jetzt von ASF gehalten wird, ebenfalls ähnlich wie oben) und zeigt die gleiche Meldung an.

Die beiden Ursachen auf der ASF-Seite sind eigentlich sehr schwer zu beheben, da ASF das Sammeln einfach wieder aufnimmt, sobald das Steam-Netzwerk es darüber informiert, dass das Konto wieder frei ist verwendet werden kann. Das ist es, was normalerweise passiert, wenn Du das Spiel schließt, aber bei defekten Paketen kann dies sofort passieren, auch wenn dein Spiel noch läuft. ASF hat keine Möglichkeit zu wissen, ob Du die Verbindung getrennt hast, aufgehört hast ein Spiel zu spielen oder ob Du immer noch ein Spiel spielst, das die Sperre nicht ordnungsgemäß hält.

Die einzig richtige Lösung für dieses Problem ist, deinen Bot mit `pause` manuell zu pausieren und ihn mit `resume` wieder zu starten, sobald Du fertig bist. Alternativ kannst Du das Problem einfach ignorieren und dich genauso verhalten, als ob Du mit dem Offline-Steam-Client spielen würdest.

---

### `Von Steam getrennt!` - Ich kann keine Verbindung zu den Steam-Servern herstellen.

ASF kann nur **versuchen** eine Verbindung mit den Steam-Servern herzustellen, und es kann aus vielen Gründen fehlschlagen, einschließlich fehlender Internetverbindung, Steam ist ausgefallen, deine Firewall blockiert die Verbindung, Programme von Drittanbietern, falsch konfigurierte Routen oder temporäre Ausfälle. Du kannst den `Debug`-Modus aktivieren, um ein ausführlicheres Protokoll mit genauen Fehlerursachen zu erhalten, obwohl es normalerweise einfach durch deine eigenen Aktionen verursacht wird, wie z. B. die Verwendung von "CS:GO MM Server Picker", das viele Steam-IPs auf eine schwarze Liste setzt, was es für dich sehr schwierig macht, tatsächlich das Steam-Netzwerk zu erreichen.

ASF wird sein Bestes tun, um eine Verbindung herzustellen, was nicht nur die Abfrage nach der aktualisierten Liste der Server beinhaltet, sondern auch den Versuch einer anderen IP, wenn die letzte fehlschlägt. Wenn es also wirklich ein temporäres Problem mit einem bestimmten Server oder einer bestimmten Route ist, wird ASF früher oder später eine Verbindung herstellen. Wenn Du dich jedoch hinter der Firewall befindest oder auf andere Weise nicht in der Lage bist, die Steam-Server zu erreichen, dann musst Du es natürlich selbst reparieren, mit Hilfe des `Debug`-Modus.

Es ist auch möglich, dass deine Maschine nicht in der Lage ist, eine Verbindung mit den Steam-Servern über das Standardprotokoll in ASF herzustellen. Du kannst Protokolle, die ASF verwenden darf, ändern, indem Du `SteamProtocols` globale Konfigurationseigenschaft änderst. Wenn Du zum Beispiel Probleme hast, Steam mit dem `UDP` Protokoll zu erreichen (z. B. Aufgrund Firewalls), dann kannst Du `TCP` oder `WebSocket` versuchen.

In einer sehr unwahrscheinlichen Situation, in der falsche Server zwischengespeichert werden, z. B. weil ASF `config` Ordner von einer Maschine auf eine andere Maschine in einem völlig anderen Land verschoben wurde, könnte das Löschen von `ASF.db` helfen, um die Steam-Server beim nächsten Start zu aktualisieren. Sehr oft ist es nicht notwendig und muss auch nicht getan werden, da diese Liste beim ersten Start und beim Verbindungsaufbau automatisch aktualisiert wird - wir erwähnen sie nur als eine Möglichkeit, um alles zu bereinigen, was mit der Liste der Steam-Server zusammenhängt, die von ASF im Zwischenspeicher gehalten werden.

---

### `Konnte Abzeicheninformation nicht abfragen, wir versuchen es später erneut!`

Usually it means that you're using Steam parental PIN to access your account, yet you forgot to put it in ASF config. You must put valid PIN in `SteamParentalCode` bot config property, otherwise ASF will not be able to access most of web content, therefore will not be able to work properly. Schaue unter **[Konfiguration](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-de-DE)** vorbei, um mehr über `SteamParentalCode` zu erfahren.

Andere Gründe können temporäre Steam-Probleme, Netzwerkprobleme oder ähnliches sein. Wenn sich das Problem nach mehreren Stunden nicht beheben lässt und Du sicher bist, dass Du ASF richtig konfiguriert hast, kannst Du uns gerne darüber informieren.

---

### ASF schlägt mit dem Fehler `Request failed after 5 tries` fehl!

Usually it means that you're using Steam parental PIN to access your account, yet you forgot to put it in ASF config. You must put valid PIN in `SteamParentalCode` bot config property, otherwise ASF will not be able to access most of web content, therefore will not be able to work properly. Schaue unter **[Konfiguration](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-de-DE)** vorbei, um mehr über `SteamParentalCode` zu erfahren.

Wenn die Eltern-PIN nicht der Grund dafür ist, dann ist dies ein häufiger Fehler, und Du solltest dich daran gewöhnen, bedeutet das einfach, dass ASF eine Anfrage an das Steam-Netzwerk gesendet hat und keine gültige Antwort erhalten hat, 5 mal in Folge. Normalerweise bedeutet es, dass Steam entweder außer Betrieb ist oder einige Schwierigkeiten oder Wartungsarbeiten hat - ASF ist sich solcher Probleme bewusst und Du solltest dir keine Sorgen um sie machen, es sei denn, sie passieren ständig für mehr als mehrere Stunden, und andere Benutzer haben keine derartigen Probleme.

Wie kann man überprüfen, ob Steam außer Betrieb ist? **[Steam Status](https://steamstat.us)** ist eine ausgezeichnete Quelle, um zu überprüfen, **ob** Steam in Betrieb sein sollte. Wenn Sie Fehler (insbesondere im Zusammenhang mit der Community oder der Web-API) bemerken, dann hat Steam Schwierigkeiten. Sie können entweder ASF in Ruhe lassen, sodass es die Aufgaben nach einer kurzen Auszeit erledigt, oder Sie beenden ASF und warten einfach selbst.

Das ist jedoch nicht immer der Fall, da in einigen Situationen Steam-Probleme möglicherweise nicht durch Steam Status erkannt werden, z. B. passierte ein solcher Fall, als Valve die HTTPS-Unterstützung für Steam Community am 7. Juni 2016 unterbrach - der Zugriff auf **[SteamCommunity](https://steamcommunity.com)** durch HTTPS warf einen Fehler. Verlasse dich daher auch nicht blind auf den Steam Status, am besten überprüfe selbst, ob alles so funktioniert, wie es sollte.

Darüber hinaus beinhaltet Steam verschiedene Maßnahmen zur Ratenbegrenzung, die deine IP vorübergehend sperren, wenn Du übermäßig viele Anfragen auf einmal stellst. ASF ist sich dessen bewusst und bietet dir in der Konfiguration mehrere verschiedene Begrenzer an, die Du nutzen solltest. Die Standardeinstellungen wurden auf Basis von **einer gesunden** Anzahl der Bots angepasst. Wenn Du so viele verwendest, dass sogar Steam dir sagt, Du sollst weggehen, dann optimierst Du sie entweder, bis sie es dir nicht mehr sagen, oder Du tust, was man dir sagt. Ich nehme an, dass der zweite Weg keine Option für dich ist, also lies weiter zu diesem Thema und achte besonders auf `WebLimiterDelay`, der ein allgemeiner Begrenzer ist, der für alle Web-Anfragen gilt.

Es gibt keine "goldene Regel", die für jeden funktioniert, denn Sperren werden stark von Faktoren Dritter beeinflusst, deshalb muss man selbst experimentieren und einen Wert finden, der für einen funktioniert. Du kannst das auch ignorieren und einen Wert wie `10000` verwenden, was garantiert korrekt funktioniert, aber dann beschwere dich nicht, dass dein ASF auf alles innerhalb von 10 Sekunden reagiert und wie das Parsen von Abzeichen 5 Minuten dauert. Darüber hinaus ist es durchaus möglich, dass kein Begrenzer etwas bewirkt, weil Du so viele Bots hast, dass Du die **[Obergrenze](#wie-viele-bots-kann-ich-mit-asf-verwenden)** ereicht hast, wie oben erwähnt. Es ist sogar möglich, dass Sie sich ohne Probleme ins Steam-Netzwerk (Client) anmelden können, aber Steam Web (Webseite) sich schlicht weigert Ihnen zuzuhören, sollten Sie mehr als 100 Sitzungen gleichzeitig etabliert haben. ASF verlangt, dass sowohl das Steam-Netzwerk als auch das Steam-Web kooperativ sind. Wenn nur eines von beiden nicht funktioniert kann es zu Problemen kommen von denen Du dich nicht erholen wirst.

Wenn nichts hilft und Du keine Ahnung hast was kaputt ist, kannst Du immer den `Debug`-Modus aktivieren und dir im ASF-Log selbst ansehen warum genau die Anfragen fehlschlagen. Zum Beispiel:

```text
InternalRequest() HEAD https://steamcommunity.com/my/edit/settings
InternalRequest() Forbidden <- HEAD https://steamcommunity.com/my/edit/settings
```

Siehst Du das `Forbidden`? Das bedeutet, dass Du vorübergehend für übermäßig viele Anfragen gesperrt wurdest, weil Du `WebLimiterDelay` noch nicht richtig angepasst hast (vorausgesetzt, Du bekommst den gleichen Fehlercode auch für alle anderen Anfragen). Es kann noch weitere Gründe geben, wie z. B. `InternalServerError`, `ServiceUnavailable` und Timeouts, die auf Steam Wartungsarbeiten und Probleme hinweisen. Du kannst immer versuchen, den von ASF erwähnten Link selbst zu besuchen und zu überprüfen, ob er funktioniert - wenn nicht, dann weißt du, warum ASF auch nicht darauf zugreifen kann. Wenn dies der Fall ist und der gleiche Fehler nach ein oder zwei Tagen nicht verschwindet, könnte es sich lohnen, ihn zu untersuchen und zu melden.

Bevor Du das tust, **solltest Du dich vergewissern, dass der Fehler überhaupt einen Bericht wert ist**. Wenn es in diesem FAQ erwähnt wird, wie z. B. handelsbedingte Probleme, dann ist das nicht der Fall. Wenn es sich um ein temporäres Problem handelt, das ein- oder zweimal auftrat, insbesondere wenn dein Netzwerk instabil war oder Steam ausgefallen ist - dann ist das nicht der Fall. Wenn Du jedoch in der Lage warst, dein Problem mehrmals hintereinander, über 2 Tage, zu reproduzieren, ASF sowie deine Maschine im Prozess neu zu starten und sicherzustellen, dass es hier keinen FAQ-Eintrag gibt, der dir hilft, es zu lösen, dann könnte es sich lohnen, nach ihm zu fragen.

---

### ASF scheint einzufrieren und gibt nichts auf der Konsole aus, bis ich eine Taste drücke!

Du benutzt höchstwahrscheinlich Windows und deine Konsole hat den QuickEdit-Modus aktiviert. Siehe **[diese](https://stackoverflow.com/questions/30418886/how-and-why-does-quickedit-mode-in-command-prompt-freeze-applications)** Frage zu StackOverflow für eine technische Erklärung. Du solltest den QuickEdit-Modus deaktivieren, indem Du mit der rechten Maustaste auf das ASF-Konsolenfenster klickst, die Eigenschaften öffnest und das entsprechende Kontrollkästchen deaktivierst.

---

### ASF kann keine Handelsangebote akzeptieren oder versenden!

Offensichtliche Sache zuerst - neue Konten beginnen als begrenzt. Bis Du das Konto freischaltest, indem Du sein Guthaben lädst oder 5€ im Shop ausgibst, kann ASF weder Handelsangebote akzeptieren noch über dieses Konto versenden. In diesem Fall gibt ASF an, dass das Inventar leer ist, da jede Karte, die sich darin befindet, nicht handelbar ist. Es wird auch nicht möglich sein, ein Handelsangebot zu erhalten, da dieser Teil erfordert, dass ASF in der Lage ist, den API-Schlüssel zu holen, und die API-Schlüsselfunktionalität für begrenzte Konten deaktiviert ist. Kurz gesagt - der Handel ist für alle begrenzten Konten deaktiviert, keine Ausnahmen.

Als nächstes, wenn Du **[ASF-2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication-de-DE)** nicht verwendest, ist es möglich, dass ASF tatsächlich das Handelsangebot akzeptiert/sendet, aber Du musst es per E-Mail bestätigen. Ebenso musst du, wenn Du die klassische 2FA verwendest, das Handelsangebot über deinen Authentifikator bestätigen. Bestätigungen sind jetzt **obligatorisch**, also wenn Du sie nicht selbst akzeptieren willst, erwäge deinen Authentifikator in ASF-2FA zu importieren.

Beachte auch, dass Du nur mit deinen Freunden und Personen mit bekanntem Handelslink handeln kannst. If you're trying to initiate *Bot -> Master* trade, such as `loot`, then you need to either have your bot on your friendlist, or your `SteamTradeToken` declared in Bot's config. Make sure that the token is valid - otherwise, you won't be able to send a trade.

Abschließend solltest Du daran denken, dass neue Geräte eine 7-Tage-Handelssperre haben. Wenn Du also gerade dein Konto zu ASF hinzugefügt hast, warte mindestens 7 Tage - alles sollte nach diesem Zeitraum funktionieren. Diese Einschränkung beinhaltet **sowohl** die Annahme von Handelsangeboten als **auch** das Versenden von Handelsangeboten. Es wird nicht immer ausgelöst, und es gibt Leute, die sofort Handelsangebote senden und annehmen können. Die Mehrheit der Personen sind jedoch betroffen, und die Verriegelung **wird** passieren, auch wenn Du Handelsangebote über deinen Steam-Client auf der gleichen Maschine senden und annehmen kannst. Warte einfach geduldig, es gibt nichts, was Du tun kannst, um es zu beschleunigen. Ebenso kann es sein, dass Du eine ähnliche Sperre für das Entfernen/Ändern verschiedener sicherheitsrelevanter Einstellungen von Steam erhältst, wie z. B. 2FA, SteamGuard, Passwort, E-Mail und ähnliches. Im Allgemeinen solltest Du überprüfen, ob Du ein Handelsangebot von diesem Konto aus selbst versenden kannst. Wenn ja, dann ist es sehr wahrscheinlich, dass es sich um eine klassische 7-Tage-Sperre von einem neuen Gerät handelt.

Und schließlich, bedenke, dass ein Konto nur 5 ausstehende Handelsangebote zu einem anderen haben kann, sodass ASF keine Handelsangebote senden kann, wenn Du bereits 5 (oder mehr) ausstehende Handelsangebote von diesem einen Bot hast. Dies ist selten ein Problem, aber es ist auch erwähnenswert, besonders wenn Du ASF auf automatisches Senden von Handelsangeboten einstellst, aber Du benutzt ASF-2FA nicht und hast vergessen, sie tatsächlich zu bestätigen.

Wenn nichts geholfen hat, kannst Du jederzeit den `Debug` Modus aktivieren und selbst überprüfen, warum Anfragen fehlschlagen. Bitte bedenke, dass Steam die meiste Zeit Unsinn redet, und vorausgesetzt, dass der Grund keinen logischen Sinn ergibt oder sogar völlig falsch ist - wenn Du dich entscheidest, diesen Grund zu interpretieren, stelle sicher, dass Du ein angemessenes Wissen über Steam und seine Besonderheiten hast. Es ist auch durchaus üblich, dieses Problem ohne logischen Grund zu sehen, und die einzige vorgeschlagene Lösung in diesem Fall ist, das Konto erneut zu ASF hinzuzufügen (und wieder 7 Tage zu warten). Manchmal behebt sich dieses Problem auf *magische* Weise, genauso wie es auch kaputt geht. Allerdings ist es in der Regel nur entweder 7-Tage Handelssperre, temporäres Steam-Problem oder beides. Es ist am besten, ihm ein paar Tage vor der manuellen Überprüfung zu geben, was falsch ist, es sei denn, Du hast den Drang, die wahre Ursache zu finden (und normalerweise wirst Du gezwungen sein, trotzdem zu warten, weil Fehlermeldungen keinen Sinn ergeben und dir auch nicht im Geringsten helfen).

In jedem Fall kann ASF nur **versuchen**, eine ordnungsgemäße Anfrage an Steam zu senden, um das Handelsangebot anzunehmen/senden. Ob Steam diese Anfrage annimmt oder nicht, liegt außerhalb des Anwendungsbereichs von ASF, und ASF wird es nicht auf magische Weise zum Funktionieren bringen. Es gibt keinen Fehler im Zusammenhang mit dieser Funktion, und es gibt auch nichts zu verbessern, da die Logik außerhalb von ASF stattfindet. Deshalb, bitte nicht um die Behebung von Dingen, die nicht kaputt sind, und frage auch nicht, warum ASF keine Handelsangebote annehmen oder senden kann - **Ich weiß es nicht, und ASF weiß es auch nicht**. Leben Sie damit, oder beheben Sie es selbst, wenn Sie es besser wissen.

---

### Warum muss ich bei der Anmeldung jedesmal den 2FA/SteamGuard-Code eingeben? / *Abgelaufener Anmelde-Schlüssel entfernt*

ASF verwendet Anmelde-Schlüssel (wenn Du `UseLoginKeys` aktiviert hast), um die Anmeldeinformationen gültig zu halten, den gleichen Mechanismus, den Steam verwendet - 2FA/SteamGuard-Code ist nur einmal erforderlich. However, due to Steam network issues and quirks, it's entirely possible that login key is not saved in the network, we've already seen such issues not only with ASF, but with regular steam client as well (a need to input login + password on each run, regardless of "remember me" option).

You could remove `BotName.db` and `BotName.bin` (if available) of affected account and try to link ASF to your account once again, but that likely won't do anything. Some users have reported that **[deauthorizing all devices](https://store.steampowered.com/twofactor/manage)** on Steam side should help, changing password will do the same. However, those are only workarounds that are not even guaranteed to work, the real ASF-based solution is to import your authenticator as **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)** - this way ASF can generate tokens automatically when they're needed, and you don't have to input them manually. In der Regel löst sich das Problem nach einiger Zeit von selbst, sodass man es einfach abwarten kann. Natürlich können Sie auch Valve nach einer Lösung fragen, denn ich kann das Steam-Netzwerk nicht zwingen, unsere Login-Schlüssel zu akzeptieren.

Als Randbemerkung kannst Du auch die Anmelde-Schlüssel mit `UseLoginKeys` Konfigurationseigenschaft auf `false` deaktivieren, aber das wird das Problem nicht lösen, sondern nur den Fehler des ersten Anmelde-Schlüssels überspringen. ASF ist sich des hier beschriebenen Problems bereits bewusst und wird versuchen, keine Anmelde-Schlüssel zu verwenden, wenn es sich selbst alle Anmeldeinformationen zuschicken kann, sodass es nicht notwendig ist, `UseLoginKeys` manuell zu optimieren, wenn Du alle Zugangsdaten zusammen mit ASF-2FA angeben kannst.

---

### Ich erhalte den Fehler: *Die Anmeldung bei Steam ist nicht möglich: `InvalidPassword` or `RateLimitExceeded`*

Dieser Fehler kann vieles bedeuten, unter anderem auch:

- Ungültige Login/Passwort-Kombination (offensichtlich)
- Abgelaufener Anmelde-Schlüssel, der von ASF für die Anmeldung verwendet wird
- Zu viele fehlgeschlagene Anmeldeversuche in kurzer Zeit (Anti-Bruteforce)
- Zu viele Anmeldeversuche in kurzer Zeit (Rate-Limiting/ Anfragelimit)
- Erfordernis eines Captcha zum Anmelden (sehr wahrscheinlich durch die beiden obigen Gründe verursacht)
- Alle anderen Gründe, die das Steam-Netzwerk daran hindern könnten, sich anzumelden

Im Falle von Anti-Bruteforce und Rate-Limiting wird das Problem nach einiger Zeit verschwinden, also warte einfach und versuche dich in der Zwischenzeit nicht anzumelden. Wenn Du dieses Problem häufiger hast, ist es vielleicht ratsam, `LoginLimiterDelay` Konfigurationseigenschaft von ASF zu erhöhen. Übermäßige Programmneustarts und andere absichtliche/nicht absichtliche Anmeldeanforderungen werden bei diesem Problem definitiv nicht helfen, also vermeide es, wenn möglich.

Im Falle eines abgelaufenen Anmelde-Schlüssels wird ASF den alten entfernen und beim nächsten Anmelden nach einem neuen fragen (was erfordert, dass Du einen 2FA-Code setzt, wenn dein Konto 2FA-geschützt ist). Wenn dein Konto ASF-2FA verwendet, wird ein Code generiert und automatisch verwendet. Dies kann natürlich mit der Zeit geschehen, aber wenn dieses Problem bei jedem Login auftritt, ist es möglich, dass Steam aus irgendeinem Grund beschlossen hat, unsere Login-Schlüssel zu ignorieren, wie im Punkt **[oben](#warum-muss-ich-bei-der-anmeldung-jedesmal-den-2fasteamguard-code-eingeben--abgelaufener-anmelde-schl%C3%BCssel-entfernt)** erwähnt. Sie können natürlich `UseLoginKeys` komplett deaktivieren, aber das löst das Problem nicht, sondern vermeidet nur, dass jedes mal abgelaufene Login Schlüssel entfernt werden müssen. Die wirkliche Lösung besteht darin, wie im Punkt oben erwähnt, ASF-2FA zu verwenden.

Und schlussendlich, wenn Du eine falsche Kombination aus Login und Passwort verwendet hast, musst Du dies natürlich korrigieren oder den Bot deaktivieren, der versucht, sich mit diesen Zugangsdaten zu verbinden. ASF kann nicht von selbst erraten, ob `InvalidPassword` ungültige Anmeldeinformationen bedeutet, oder einen der oben genannten Gründe, daher wird es weiter versuchen, bis es erfolgreich ist.

Bedenke, dass ASF über ein eigenes eingebautes System verfügt, um entsprechend auf Steam-Schrullen zu reagieren, irgendwann wird es sich verbinden und seine Arbeit wieder aufnehmen, daher ist es nicht erforderlich, etwas zu tun, wenn das Problem vorübergehend ist. Ein Neustart von ASF, um Probleme magisch zu beheben, wird die Situation nur verschlimmern (da der neue ASF den vorherigen ASF-Zustand nicht kennt, dass er sich nicht anmelden kann, und versucht, eine Verbindung herzustellen, anstatt zu warten), also solltest Du das nicht tun, es sei denn, Du weißt, was Du tust.

Abschließend kann sich ASF, wie bei jeder Steam-Anfrage, nur **versuchen** mit den von dir angegebenen Zugangsdaten anmelden. Ob diese Anforderung erfolgreich ist oder nicht, liegt außerhalb des Umfangs und der Logik von ASF - es gibt keinen Fehler, und in dieser Hinsicht kann nichts behoben oder verbessert werden.

---

### `System.IO.IOException: Input/output error`

Wenn dieser Fehler während der ASF-Eingabe aufgetreten ist (z. B. wenn Du `Console.ReadLine()` im Stacktrace sehen kannst), dann wird er durch deine Umgebung verursacht, die es ASF verbietet, die Standardeingabe deiner Konsole zu lesen. Das kann aus vielen Gründen passieren, aber der häufigste ist, dass Du ASF in der falschen Umgebung verwendest (z. B. in `nohup` oder `&` Hintergrund anstelle von `screen` unter Linux). Wenn ASF nicht auf die Standardeingabe zugreifen kann, wird dieser Fehler protokolliert und ASF kann deine Daten während der Ausführung nicht verwenden.

Wenn Du **erwartest**, dass dies geschieht, also Du **willst** ASF in einer eingabefreien Umgebung laufen lassen, dann solltest Du ASF ausdrücklich sagen, dass es der Fall ist, indem Du den **[`Headless`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-de-DE#headless)** Modus entsprechend einstellst. Um für Sie ein sicheres Ausführen in eingabefreien Umgebungen zu gewährleisten, wird ASF damit angehalten, nach weiteren Benutzereingaben fragen.

---

### `System.Net.Http.WinHttpException: A security error occurred`

Dieser Fehler tritt auf, wenn ASF keine sichere Verbindung mit dem angegebenen Server herstellen kann, fast ausschließlich wegen des Misstrauens gegen ein SSL-Zertifikat.

In fast allen Fällen wird dieser Fehler durch ein **falsches Datum/Uhrzeit auf deiner Maschine** verursacht. Jedes SSL-Zertifikat hat ein Ausstellungsdatum und ein Verfallsdatum. Wenn ihr Datum ungültig ist und sich außerhalb dieser beiden Grenzen befindet, kann dem Zertifikat nicht als potentieller **[MITM](https://de.m.wikipedia.org/wiki/Man-in-the-Middle-Angriff)**-Angriff vertraut werden, weshalb ASF sich weigert, eine Verbindung herzustellen.

Eine offensichtliche Lösung ist das Datum auf deiner Maschine entsprechend einzustellen. Es wird dringend empfohlen, eine automatische Datumssynchronisation zu verwenden, wie z. B. die unter Windows verfügbare native Synchronisation oder `ntpd` unter Linux.

Sobald Sie sich sicher sind, dass das Datum auf ihrem Gerät korrekt ist und der Fehler nicht verschwinden will, dann könnten SSL-Zertifikate, denen ihr System vertraut, veraltet oder ungültig sein. In diesem Fall solltest Du sicherstellen, dass deine Maschine sichere Verbindungen herstellen kann, z. B. indem Du über einen beliebigen Browser oder mit einem CLI-Tool wie `curl` überprüfst, ob Du auf `https://github.com` zugreifen kannst. Wenn Du bestätigt hast, dass dies ordnungsgemäß funktioniert, kannst Du das Problem gerne in unserer Steam-Gruppe melden.

---

### `System.Threading.Tasks.TaskCanceledException: A task was canceled`

Diese Warnung bedeutet, dass Steam nicht innerhalb einer bestimmten Zeit auf die ASF-Anfrage geantwortet hat. Normalerweise wird dies durch Steam-Netzwerkproblemen verursacht und hat keine Auswirkung auf ASF. In manchen Fällen ist es das gleiche wie wenn die Anfrage nach 5 Versuchen fehlschlägt. Die Meldung dieses Problems macht meistens keinen Sinn, da wir Steam nicht zwingen können, auf unsere Anfragen zu reagieren.

---

### `The type initializer for 'System.Security.Cryptography.CngKeyLite' threw an exception`

Dieses Problem wird fast ausschließlich durch einem deaktivierten/gestoppten `CNG Key Isolation`-Windows-Dienst, die ASF Kernkryptografiie-Funktionalität bietet, ohne dessen das Programm nicht ausführbar ist. Sie können dieses Problem beheben, indem Sie `services.msc` und sicherstellen, dass Windows den `CNG Key Isolation`-Dienst nicht deaktiviert hat und derzeit läuft.

---

### ASF wird von meinem AntiVirus als Schadsoftware erkannt! Was ist hier los?

**Stelle sicher, dass Du ASF von einer vertrauenswürdigen Quelle heruntergeladen hast**. Die einzige offizielle und vertrauenswürdige Quelle ist **[ASF-Veröffentlichungen](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** Seite auf GitHub (und das ist auch die Quelle für automatische ASF-Aktualisierungen) - **jede andere Quelle ist per Definition nicht vertrauenswürdig und könnte Schadsoftware enthalten, die von anderen Personen hinzugefügt wurde** - Du solltest keiner anderen Quelle per Definition vertrauen und sicherstellen, dass dein ASF immer von uns kommt.

Wenn Du überprüft hast, dass ASF von einer vertrauenswürdigen Quelle heruntergeladen wurde, dann ist es höchstwahrscheinlich nur ein Fehlalarm. Dies **passierte in der Vergangenheit**, **passiert gerade jetzt**, und **wird in der Zukunft passieren**. Wenn Du dir um die tatsächliche Sicherheit bei der Verwendung von ASF Sorgen machst, dann schlage ich vor, ASF mit vielen verschiedenen AVs nach der tatsächlichen Erkennungsrate zu scannen, zum Beispiel durch **[VirusTotal](https://www.virustotal.com)** (oder einem anderen Webdienst deiner Wahl).

Wenn die von dir verwendete AV-Software ASF fälschlicherweise als Schadsoftware erkennt, dann **ist es eine gute Idee, dieses Dateibeispiel an die Entwickler deiner AV-Software zu senden, damit sie es analysieren und ihre Erkennungsmaschine verbessern können**, da sie offensichtlich nicht so gut funktioniert, wie Du denkst. Es gibt kein Sicherheitsproblem im ASF-Code, und es gibt auch nichts zu beheben, da wir keine Schadsoftware verteilen, daher macht es auch keinen Sinn uns diese Fehlalarme zu melden. Wir empfehlen dringend, ASF-Beispiele für weitere Analysen wie oben beschrieben zu versenden, aber wenn Du dich nicht darum kümmern möchtest, dann kannst Du ASF immer zu den AV-Ausnahmen hinzufügen, deine AV-Software deaktivieren oder einfach ein andere verwenden. Leider sind wir es gewohnt, dass AV-Softwares dumm sind, da ab und zu einige AV-Softwares ASF als Virus erkennen, was normalerweise sehr kurz andauert und schnell von den Entwicklern ausgebessert wird, aber wie wir oben erwähnt haben - **es passierte**, **passiert** und **wird immer passieren**. ASF enthält keinen schädlichen Code, Du kannst ASF-Code überprüfen und sogar selbst den Quellcode kompilieren. Wir sind keine Hacker die den ASF-Code verschleiern, um sich vor AV-Heuristiken und Fehlalarmen zu verstecken, also erwarte nicht von uns, dass wir reparieren, was nicht kaputt ist - es gibt keinen "Virus", den wir beseitigen können.