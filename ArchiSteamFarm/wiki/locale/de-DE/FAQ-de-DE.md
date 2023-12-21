# FAQ

Unser FAQ umfasst Standardfragen und Antworten, die Sie vielleicht haben. Für weniger häufig gestellte Fragen besuchen Sie bitte stattdessen unser **[erweitertes FAQ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Extended-FAQ-de-DE)**.

# Inhaltsverzeichnis

* [Allgemein](#allgemein)
* [Vergleich mit ähnlichen Programmen](#vergleich-mit-%C3%A4hnlichen-programmen)
* [Sicherheit / Datenschutz / VAC / Sperren / Nutzungsbedingungen](#sicherheit--datenschutz--vac--sperren--nutzungsbedingungen)
* [Sonstiges](#sonstiges)
* [Probleme](#probleme)

---

## Allgemein

### Was ist ASF?
### Warum behauptet das Programm, dass es auf meinem Konto nichts zum Sammeln gibt?
### Warum erkennt ASF nicht alle meine Spiele?
### Warum ist mein Konto begrenzt?

Bevor Sie versuchen herauszufinden, was ASF ist, sollten Sie sicherstellen, dass Sie verstehen, was Steam Sammelkarten sind und wie man sie erhält, was in der offiziellen FAQ **[hier](https://steamcommunity.com/tradingcards/faq)** gut erläutert ist.

Kurz gesagt, Steam-Sammelkarten sind sammelbare Gegenstände, welche Sie erhalten können, wenn Sie ein bestimmtes Spiel besitzen, und können für die Herstellung von Abzeichen, den Verkauf auf dem Steam-Markt oder für jeden anderen Zweck Ihrer Wahl verwendet werden.

Hier werden noch einmal die Kernpunkte genannt, weil Leute im Allgemeinen nicht mit ihnen einverstanden sind und bevorzugt so tun, als würden diese nicht existieren:

- **Sie müssen das Spiel auf dem Steam-Account besitzen, um für die dazugehörigen Kartenfunde berechtigt zu sein. Spiele die über die Steam-Familienbibliothek geteilt werden zählen nicht.**
- **Sie können nicht unendlich lange sammeln; jedes Spiel hat eine feste Anzahl an Kartenfunde. Sobald Sie alle Karten gesammelt haben (ungefähr die Hälfte eines vollständigen Satzes), ist das Spiel kein Sammelkandidat mehr. Es ist unwichtig, ob Sie die Karten verkauft, gehandelt, Abzeichen hergestellt oder lediglich vergessen haben, was damit geschehen ist; sobald die maximale Anzahl erreicht wurde, wird für dieses Spiel nicht weiter gesammelt.**
- **Sie können keine Karten von F2P-Spielen erhalten, ohne dabei Geld auszugeben. Dies beinhaltet dauerhafte F2P Spiele (z. B. Team Fortress 2 oder Dota 2). Der Besitz von F2P-Spielen allein garantiert Ihnen keinen Kartenfund.**
- **Sie erhalten keine Karten auf [beschränkten Accounts](https://help.steampowered.com/de/faqs/view/71D3-35C2-AD96-AA3A), ungeachtet der registrierten Spiele. Es war in der Vergangenheit möglich, aber dies ist nicht mehr der Fall.**
- **Bezahlte Spiele, die Sie während einer Promotion kostenlos erhalten haben, können nicht für Kartendrops eingetauscht werden, unabhängig davon, was auf der Shop-Seite angezeigt wird. Es war in der Vergangenheit möglich, aber dies ist nicht mehr der Fall.**

Steam-Sammelkarten sind folglich eine Belohnung dafür, dass Sie gekaufte Spiele spielen oder Geld in F2P-Spiele investieren. Sobald Sie ein Spiel lange genug spielen, werden alle Karten für dieses Spiel irgendwann im Inventar freigeschaltet. Damit können Sie beispielsweise ein Abzeichen vervollständigen (nach dem Erhalt der restlichen erforderlichen Karten) oder handeln.

Nun, da wir die Grundlagen von Steam erklärt haben, können wir ASF aufklären. Das Programm selbst ist sehr komplex und dementsprechend relativ schwer zu verstehen. Anstatt hier alle technischen Details anzugeben, geben wir weiter unten lieber einen Überblick mit einfachen Erklärungen.

ASF meldet sich über unseren integrierten Mini-Steam-Client mit den von Ihnen angegebenen Anmeldeinformationen beim Steam-Konto an. Nach dem erfolgreichen Login durchsucht es Ihre **[Abzeichen](https://steamcommunity.com/my/badges)**, um herauszufinden welche Spiele noch gesammelt werden können (`X` Kartenfunde verbleibend). Nachdem alle Seiten analysiert und eine endgültige Liste der verfügbaren Spiele erstellt wurde, wählt ASF den effizientesten Sammel-Algorithmus aus und startet den Prozess. Der Prozess hängt von dem gewählten **[Karten-Sammel-Algorithmus](https://github. com/JustArchiNET/ArchiSteamFarm/wiki/Performance-de-DE#Leistung)** ab, aber normalerweise besteht er aus dem Spielen des geeigneten Spiels und der periodischen (plus bei jedem Kartendrop) Überprüfung, ob das Spiel bereits vollständig gesammelt wurde - wenn ja, kann ASF mit dem nächsten Spiel fortfahren, mit dem gleichen Verfahren, bis alle Spiele vollständig im gesammelt wurden.

Beachten Sie, dass die obige Erklärung vereinfacht ist und kein Dutzend zusätzlicher Features und Funktionen beschreibt, die ASF bietet. Mehr Informationen und Details erhalten Sie in **[unserem Wiki](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Home-de-DE)**. Ich habe versucht es einfach zu halten, damit es für alle verständlich ist, ohne technische Details einzubringen - fortgeschrittene Benutzer werden ermutigt, tiefer zu graben.

Als Programm bietet ASF einige Vorteile. Erstens, ASF muss keine Spieldateien herunterladen; es kann sofort Ihre Spiele sammeln. Zweitens ist es völlig unabhängig von Ihrem normalen Steam-Client. Sie müssen Steam-Client nicht ausführen, geschweige denn installiert haben. Drittens ist es eine automatisierte Lösung - das bedeutet, dass ASF automatisch alles hinter dem Rücken macht, ohne das Sie sagen müssen, was zu tun ist - das spart Ihnen Zeit und Mühe. Letztendlich muss es das Steam-Netzwerk nicht durch Prozessemulation (die z. B. Idle Master verwendet) austricksen, da es direkt mit ihm kommunizieren kann. Es ist auch superschnell und platzsparend; eine erstaunliche Lösung für alle, die Karten ohne großen Aufwand bekommen möchten - es ist besonders nützlich, wenn man es im Hintergrund laufen lässt, während man etwas anderes macht oder sogar im Offline-Modus spielt.

All das oben Gesagte ist ganz nett, aber ASF hat auch einige technische Einschränkungen, die von Steam erzwungen werden. Es können weder Karten über das Kartenlimit hinaus gesammelt werden; geschweige denn für Spiele, die Sie nicht besitzen. Das Sammeln ist auch eingeschränkt, während Sie selbst ein Spiel spielen. All das sollte "logisch" sein, wenn man bedenkt wie ASF funktioniert. Aber man sollte beachten, dass ASF keine Superkräfte hat und nichts tun wird, was physisch unmöglich ist. Denken Sie auch daran, dass dies im Grunde genommen dasselbe ist, als ob Sie jemandem gesagt hätten, dass er sich von einem anderen PC aus in Ihr Konto einloggen und diese Spiele für Sie sammeln soll.

Zusammenfassend lässt sich sagen: ASF ist ein Programm, das Ihnen hilft, die Karten, für die Sie berechtigt sind, ohne großen Aufwand sammeln zu lassen. Es bietet auch einige andere Funktionen, aber wir bleiben vorerst bei dieser.

---

### Muss ich meine Zugangsdaten angeben?

**Ja**. ASF benötigt die Konto-Anmeldeinformationen auf die gleiche Weise wie der offizielle Steam-Client, da er die gleiche Methode für die Steam-Netzwerkinteraktion verwendet. Dies bedeutet jedoch nicht, dass Sie die Zugangsdaten in ASF-Konfigurationen eingeben müssen. Stattdessen können Sie ASF weiterhin mit `null` (leerem `SteamLogin` und/oder `SteamPassword`) verwenden und bei Bedarf diese Daten für jede ASF-Ausführung eingeben (sowie mehrere andere Zugangsdaten, siehe Konfiguration). Auf diese Weise werden die Daten nirgendwo gespeichert, aber natürlich kann ASF ohne Ihre Hilfe nicht automatisch starten. ASF bietet auch viele andere Möglichkeiten die **[Sicherheit](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security-de-DE#Sicherheit)** zu erhöhen. Wenn Sie ein fortgeschrittener Benutzer sind, sollten Sie diesen Teil des Wikis lesen. Falls dem jedoch nicht so ist, und Sie die Konto-Anmeldeinformationen nicht in die ASF-Konfigurationen einfügen möchten, dann belassen Sie es einfach dabei und geben Sie diese stattdessen erst bei Bedarf ein, z. B. wenn ASF danach fragt.

Bedenken Sie, dass ASF für den persönlichen Gebrauch bestimmt ist und die Zugangsdaten werden Ihren Computer niemals verlassen werden. Sie teilen diese auch mit niemandem. Dies erfüllt die **[Steam-Nutzungsbedingungen (AGB)](https://store.steampowered.com/subscriber_agreement/german)** - eine sehr wichtige Sache, die viele Leute vergessen. Sie schicken Ihre Daten nicht an unsere Server oder einen Dritten, sondern nur direkt an Steam-Server, die von Valve betrieben werden. Wir kennen Ihre Zugangsdaten nicht und können sie auch nicht für Sie wiederherstellen, unabhängig davon, ob Sie diese in Ihren Konfigurationen eingefügt haben oder nicht.

---

### Wie lange muss ich warten bis ich Karten erhalte?

**So lange wie es eben dauert** - ernsthaft. Jedes Spiel hat unterschiedliche Sammel-Anforderungen, die vom Entwickler/Herausgeber festgelegt werden, und es liegt ganz an ihnen, wie schnell die Karten gesammelt werden. Die Mehrheit der Spiele folgt 1 Karte pro 30 Minuten Spielzeit, aber es gibt auch Spiele, welche sogar mehrere Stunden an Spielzeit verlangen, bevor Sie eine Karte bekommen. Darüber hinaus kann es sein, dass das Konto daran gehindert wird, Karten von Spielen zu erhalten, die Sie noch nicht lange genug gespielt haben, wie im Abschnitt **[Leistung](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance-de-DE)** erläutert. Versuchen Sie nicht zu erraten, wie lange ASF den gegebenen Titel sammeln soll - es liegt weder an Ihnen, noch an ASF dies zu entscheiden. Es gibt nichts was Sie tun können, um es zu beschleunigen und es gibt keinen "Bug", der damit zusammenhängt, dass Karten nicht pünktlich gesammelt werden. Sie kontrollieren den Karten-Sammel-Prozess nicht, ebenso wenig wie ASF. Im besten Fall erhalten Sie durchschnittlich 1 Karte pro 30 Minuten. Im schlimmsten Fall erhalten Sie innerhalb der ersten 4 Stunden nach dem Start von ASF keine einzige Karte. Beide dieser Situationen sind normal und werden in unserem Abschnitt **[Leistung](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance-de-DE#Leistung)** erläutert.

---

### Das Sammeln dauert so lange... Kann ich es irgendwie beschleunigen?

Das Einzige, was die Geschwindigkeit des Sammelns stark beeinflusst, ist der gewählte **[Sammel-Algorithmus](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance-de-DE)** für die jeweilige Bot-Instanz. Alles andere hat einen unwesentlichen Effekt und beschleunigt das Sammeln nicht; während manche Dinge, wie zum Beispiel das mehrfache Starten von ASF es sogar **schlechter** machen. Wenn Sie wirklich den Drang haben, jede einzelne Sekunde des Sammel-Prozesses zu nutzen, dann erlaubt ASF Ihnen einige grundlegende Sammelvariablen - wie `FarmingDelay` zu optimieren - alle von Ihnen sind in der **[Konfiguration](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-de-DE#Konfiguration)** erklärt. Nichtsdestotrotz ist dieser Effekt unwesentlich und den entsprechenden Sammel-Algorithmus für das jeweilige Konto zu wählen ist die einzige ausschlaggebende Wahl, die die Geschwindigkeit schwer beeinflussen kann, während alles andere rein kosmetisch ist. Anstatt sich um Sammelgeschwindigkeit zu kümmern, sollten Sie einfach ASF starten und es seinen Job machen lassen - Ich kann versichern, dass es das auf die effektivste Art macht, die wir uns vorstellen konnten. Je weniger Sie sich sorgen, desto zufriedener werden Sie sein.

---

### Aber ASF sagte, dass das Sammeln etwa X Zeit in Anspruch nehmen wird!

ASF gibt Ihnen eine grobe Schätzung basierend auf der Anzahl der Karten, die Sie sammeln müssen, und dem gewählten Algorithmus - dies ist bei weitem nicht annähernd die tatsächliche Zeit, die für das Sammeln benötigt wird, die in der Regel länger ist als diese, da ASF nur den besten Fall annimmt, und ignoriert alle Steam-Netzwerk-Eigenarten, Internetunterbrechungen, Überlastung der Steam-Server und ähnliches. Es ist nur als allgemeiner Indikator zu verstehen, wie lange man mit dem Sammeln von ASF rechnen kann, im besten Fall sehr oft, da die tatsächliche Zeit variiert, in einigen Fällen sogar deutlich. Wie oben erwähnt, versuchen Sie nicht zu erraten wie lange das Spiel gesammelt wird. Es liegt weder an Ihnen, noch an ASF dies zu entscheiden.

---

### Kann ASF auf meinem Android/Smartphone funktionieren?

ASF ist ein C#-Programm, das eine funktionierende Implementierung von .NET Core erfordert. Android wurde mit .NET 6.0 eine potenzielle Plattform, aber es gibt derzeit ein großes Hindernis bei der Umsetzung von ASF auf Android, da **[keine ASP.NET Runtime dafür verfügbar ist](https://github.com/dotnet/aspnetcore/issues/35077)**. Derzeit gibt es keinen nativen. NET Core Build für Android selbst, aber es gibt ordentliche und funktionierende Builds für Linux auf ARM-Architektur, sodass es durchaus möglich ist, so etwas wie **[Linux Deploy](https://play.google.com/store/apps/details?id=ru.meefik.linuxdeploy)** für die Installation von Linux zu verwenden, dann ASF in einem solchen Linux chroot wie gewohnt zu verwenden.

Sobald alle ASF-Anforderungen erfüllt sind, werden wir in Erwägung ziehen, eine offizielle Version für Android freizugeben.

---

### Kann ASF Gegenstände aus Steam-Spielen wie CS:GO oder Unturned sammeln?

**Nein**, dies verstößt gegen die **[Steam-Nutzungsbedingungen](https://store.steampowered.com/subscriber_agreement/german)** (AGB) und Valve stellte sich mit der letzten Welle von Community-Sperren entschieden gegen das Sammeln von TF2-Gegenständen. ASF ist ein Steam-Karten-Sammelprogramm - kein Spiele-Gegenstände-Sammelprogramm - es hat keine Möglichkeit Spielegegenstände zu sammeln und es ist nicht geplant ein solches Feature in der Zukunft hinzuzufügen; hauptsächlich, weil es die Steam-Nutzungsbedingungen verletzt. Bitte stellen Sie keine Fragen dazu. Sie bekommen höchstens Ärger, durch die Beschwerde eines genervten Benutzers. Das Gleiche gilt für alle anderen Arten des Sammelns, wie z. B. Drops von CS:GO-Übertragungen. ASF konzentriert sich ausschließlich auf Steam-Handelskarten.

---

### Kann ich mir aussuchen, welche Spiele gesammelt werden sollen?

**Ja**, auf unterschiedliche Weise. Wenn Sie die Standardreihenfolge der Sammel-Warteschlange ändern möchten, dann können Sie die **[Bot Konfigurationsvariable](https://github. com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-de-De#bot-konfiguration)** `FarmingOrders` dafür verwenden. Wenn Sie bestimmte Spiele manuell auf die schwarze Liste setzen möchten, damit sie nicht automatisch gesammelt werden, können Sie die schwarze Liste benutzen, die mit dem `ib` **[Befehl](https://github. com/JustArchiNET/ArchiSteamFarm/wiki/Commands-de-De)** verfügbar ist. Wenn Sie alles sammeln möchten, aber einigen Spielen Vorrang vor allem anderen geben möchten, dann können Sie dies mit der Sammel-Prioritäts-Warteschlange, die mit dem **[Befehl](https://github. com/JustArchiNET/ArchiSteamFarm/wiki/Commands-de-De)** `iq` verfügbar ist, erreichen. Schließlich (wenn Sie nur bestimmte Spiele Ihrer Wahl sammeln möchten) können Sie die **[Bot Konfigurations-Eigenschaft](https://github. com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-de-De#bot-konfiguration)** `FarmPriorityQueueOnly` (zusammen mit dem Hinzufügen ausgewählter Spiele zur Sammel-Prioritäts-Warteschlange) verwenden, um dies zu erreichen.

Zusätzlich zur Verwaltung des oben erläuterten Moduls für das automatische Karten-Sammeln können Sie ASF auch mit dem `play` **[-Befehl](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-de-DE#Befehl)** in den manuellen Sammel-Modus umschalten oder einige andere externe Einstellungen wie die `GamesPlayedWhileIdle` **[Bot Konfigurationseigenschaft](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-de-DE#bot-konfiguration)** verwenden.

---

### Ich bin nicht an Kartenfunde interessiert. Kann ich stattdessen Spielzeit Sammeln?

Ja, ASF erlaubt es Ihnen, dies auf mehrere Arten zu tun.

Der beste Weg, um dies zu erreichen, ist die Nutzung der **[`GamesPlayedWhileIdle`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-de-DE#gamesplayedwhileidle)** -Konfigurationseigenschaft, welche ASF dazu veranlasst, (zuvor von Ihnen definierte) appIDs zu "spielen", sobald keine Karten mehr sammelbar sind. Falls Sie stetig Ihre Spiele "spielen" möchten, dann können Sie dies entweder mit **[`FarmPriorityQueueOnly`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-de-DE#farmpriorityqueueonly)** kombinieren (selbst wenn noch weitere Kartenfunde aus anderen Spielen verfügbar sind), wodurch ASF lediglich die Spiele mit verfügbaren Kartenfunde sammelt, die Sie explizit vorher bestimmt haben; oder durch das Pausieren des Kartensammelmoduls mittels ** [`Paused`](https://github. com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-de-DE#paused)**, bis Sie es wieder starten.

Alternativ können Sie den Befehl **[`play`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-de-DE#kommandos-1)** anwenden, damit ASF Ihre ausgewählten Spiele spielt. Beachten Sie jedoch, dass `play` nur für Spiele verwendet werden sollte, die Sie vorübergehend sammeln möchten, da es kein persistenter Status ist, weshalb ASF in den Standardzustand (beispielsweise bei der Trennung vom Steam-Netzwerk) wechselt. Daher empfehlen wir Ihnen, `GamesPlayedWhileIdle`zu verwenden, es sei denn, Sie möchten Ihre ausgewählten Spiele tatsächlich nur für einen kurzen Zeitraum starten und dann zum allgemeinen Vorgehen zurückkehren.

---

### Ich verwende Linux / mac-OS. Kann ASF Spiele sammeln, die für mein Betriebssystem nicht verfügbar sind? Wird ASF 64-Bit-Spiele sammeln, wenn ich es auf einem 32-Bit-Betriebssystem ausführe?

Ja, ASF kümmert sich nicht einmal um das Herunterladen aktueller Spieldateien, sodass es mit allen Lizenzen funktioniert, die an Ihr Steam-Konto gebunden sind, unabhängig von Plattform oder technischen Anforderungen. Obwohl wir das nicht garantieren (es hat bei unserem letzten Versuch funktioniert), sollte es auch für regional gebundene (in bestimmten Regionen gesperrte) Spiele funktionieren, auch wenn Sie nicht in der passenden Region sind.

---

## Vergleich mit ähnlichen Programmen

---

### Ist ASF ähnlich zu Idle Master?

Die einzige Ähnlichkeit ist der allgemeine Zweck beider Programme, nämlich das Spielen von Steam-Spielen, um Karten zu erhalten. Alles andere (einschließlich der eigentlichen Sammel-Methode, Programmstruktur, Funktionalität, die Kompatibilität, und die verwendeten Algorithmen, insbesondere der Quellcode selbst) ist völlig unterschiedlich und diese beiden Programme haben nichts gemeinsam, auch nicht die Kerngrundlage (IM läuft auf .NET Framework, ASF auf .NET Core). ASF wurde geschaffen, um IM-Probleme zu lösen, die mit einer einfachen Programmcode-Editierung nicht zu lösen waren - deshalb wurde ASF von Grund auf neu geschrieben, ohne eine einzige Programmzeile oder gar eine allgemeine Idee des IM zu verwenden, weil dieser Code und diese Ideen von Anfang an völlig fehlerhaft waren. IM und ASF sind wie Windows und Linux - beide sind Betriebssysteme und beide können auf Ihrem PC installiert werden, aber sie haben fast nichts miteinander zu tun, abgesehen davon, dass sie einem ähnlichen Zweck dienen.

Aus diesem Grund sollten Sie ASF nicht mit IM vergleichen, basierend auf den Erwartungen an IM. Sie sollten ASF und IM als völlig unabhängige Programme mit eigenen exklusiven Funktionalitäten betrachten. Einige von Ihnen überschneiden sich tatsächlich und man kann in beiden ein bestimmtes Feature finden, aber sehr selten, da ASF seinen Zweck mit einem völlig anderen Ansatz als IM erfüllt.

---

### Lohnt es sich ASF zu verwenden, wenn ich gerade Idle Master verwende und es für mich gut funktioniert?

**Ja**. ASF ist viel zuverlässiger und beinhaltet viele eingebaute Funktionen, die **entscheidend** sind, unabhängig davon, wie Sie sammeln, die IM einfach nicht anbietet.

ASF hat die richtige Logik für **unveröffentlichte Spiele** - IM wird versuchen, Spiele zu sammeln, dessen Karten bereits hinzugefügt sind, auch wenn sie noch nicht veröffentlicht wurden. Natürlich ist es nicht möglich, diese Spiele vorm Veröffentlichungsdatum zu sammeln, sodass Ihr Sammel-Prozess sich aufhängt. Dazu müssten Sie es entweder zur Sperrliste hinzufügen, auf die Freigabe warten oder manuell überspringen. Keine dieser Lösungen ist gut, und alle erfordern Ihre Aufmerksamkeit - ASF überspringt automatisch das Sammeln unveröffentlichter Spiele (vorübergehend) und kehrt später zu ihnen zurück, sobald diese es sind, um das Problem vollständig zu vermeiden und effizient damit umzugehen.

ASF hat auch die richtige Logik für **Serien**/Videos. Es gibt viele Videos auf Steam, die Karten enthalten, aber mit falscher `appID` auf der Abzeichen-Seite angegeben sind, wie z.B. **[Double Fine Adventure](https://store.steampowered.com/app/402590)** - IM wird die falsche `appID` sammeln, was keine Karten ergibt und der Prozess deshalb stecken bleibt. Wieder einmal müssen Sie es entweder auf die schwarze Liste setzen oder manuell überspringen, wobei beide Ihre Aufmerksamkeit erfordern. ASF entdeckt automatisch die richtige `appID` für das Sammeln von Karten.

Darüber hinaus ist ASF **viel stabiler und zuverlässiger**, wenn es um Netzwerkprobleme und Steam-Macken geht - es funktioniert meistens und erfordert Ihre Aufmerksamkeit überhaupt nicht, wenn es einmal konfiguriert ist, während IM oft für viele Leute abbricht, zusätzliche Korrekturen erfordert oder trotzdem einfach nicht funktioniert. Es ist auch völlig abhängig vom Steam-Client, was bedeutet, dass es nicht funktionieren kann, wenn Ihr Steam-Client ernste Probleme hat. ASF funktioniert ordnungsgemäß, solange es mit dem Steam-Netzwerk verbunden werden kann, und erfordert nicht, dass der Steam-Client ausgeführt, geschweige denn installiert wird.

Dies sind drei **sehr wichtige** Punkte, warum Sie ASF verwenden sollten, da sie jeden der Steam-Karten sammelt direkt betreffen und es keine Möglichkeit gibt zu sagen "das betrifft mich nicht", da Steam-Wartungen/-Pannen jedem passieren. Es gibt Dutzende von zusätzlichen (unwichtigeren und wichtigeren) Gründen, die Sie im Rest der FAQs nachlesen können. Zusammengefasst - **ja**, Sie sollten ASF verwenden, auch wenn Sie keine zusätzliche ASF-Funktion brauchen, die im Vergleich zu IM verfügbar ist.

Darüber hinaus wird IM offiziell nicht weiterentwickelt und könnte in Zukunft komplett kaputtgehen, ohne dass sich jemand die Mühe macht, es zu reparieren, wenn man bedenkt, dass es viel leistungsfähigere Lösungen gibt (abgesehen von ASF). IM funktioniert bereits für viele Leute nicht mehr, und diese Zahl nimmt stetig zu, nicht ab. Sie sollten es vermeiden, veraltete Software zu verwenden. Dies gilt nicht nur für IM im Speziellen, sondern auch alle anderen veralteten Programme. Kein aktiver Verwalter bedeutet, dass sich niemand um die Instandhaltung sorgt und **niemand ist für dessen Funktionalität verantwortlich**. Diese wäre jedoch für Sicherheitsbelange zwingend erforderlich. Es reicht aus, dass ein kritischer Fehler auftritt, der tatsächlich Probleme mit der Steam-Infrastruktur verursacht - ohne dass jemand diesen behebt. Steam kann eine weitere Sperrwelle auslösen, in der Sie getroffen werden, ohne dass Ihnen bewusst ist, dass dies ein Problem ist, wie es bereits anderen Nutzern (mit veralteten ASF-Versionen) vor Ihnen erging.

---

### Welche interessanten Funktionen bietet ASF, die Idle Master nicht bietet?

Es hängt davon ab, was für Sie "interessant" ist. Wenn Sie vorhaben, mehr als ein Konto zu nutzen, dann ist die Antwort bereits offensichtlich; da ASF es Ihnen erlaubt, auf allen zu Sammeln mit einer übergeordneten Gesamtlösung, für das (er-) sparen von Ressourcen, Ärger und Kompatibilitätsproblemen. Wenn Sie allerdings diese Frage stellen, dann haben Sie höchstwahrscheinlich nicht diesen speziellen Bedarf, also lassen Sie uns andere Vorteile bewerten, die für ein einzelnes Konto gelten, das in ASF verwendet wird.

In erster Linie haben Sie einige eingebaute Funktionen, wie **[oben](#lohnt-es-sich-asf-zu-verwenden-wenn-ich-gerade-idle-master-verwende-und-es-für-mich-gut-funktioniert)** erwähnt, die der Kern für das Sammeln sind, unabhängig vom Endziel, und sehr oft reicht das allein schon aus, um ASF zu verwenden. Aber das wissen Sie bereits, also lassen Sie uns zu einigen weiteren interessanten Features kommen:

- **Sie können offline sammeln** (`OnlineStatus` der Einstellung `Offline`). Das Offline-Sammeln ermöglicht es Ihnen, den Steam-In-Game-Status komplett zu überspringen, was es erlaubt, mit ASF zu sammeln, während Sie gleichzeitig "Online" auf Steam sind, ohne dass Ihre Freunde überhaupt merken, dass ASF in Ihrem Namen ein Spiel spielt. Dies ist eine überlegene Funktion, da es Ihnen erlaubt, online im Steam-Client zu bleiben, ohne Ihre Freunde mit ständigen Spieländerungen zu belästigen oder sie in die Irre zu führen, dass Sie ein Spiel spielen, während Sie es in Wirklichkeit nicht sind. Allein dieser Punkt macht es sinnvoll, ASF zu verwenden, wenn man seine eigenen Freunde respektiert, aber es ist nur der Anfang. Es ist auch gut zu wissen, dass diese Funktion nichts mit den Privatsphäre-Einstellungen von Steam zu tun hat - wenn Sie das Spiel selbst starten, dann werden Sie den Freunden richtig als In-Game angezeigt, sodass nur der ASF-Teil unsichtbar wird und das Konto überhaupt nicht beeinträchtigt wird.

- **Sie konnen erstattungsfähige Spiele überspringen** (Funktion `SkipRefundableGames`). ASF hat eine eingebaute Logik für rückerstattungsfähige Spiele und Sie können ASF so konfigurieren, dass es keine rückerstattungsfähige Spiele automatisch sammelt. Auf diese Weise können Sie selbst beurteilen, ob ein neu gekauftes Spiel aus dem Steam-Shop Ihr Geld wert war, ohne dass ASF versucht, so schnellstmöglich Karten zu sammeln. Wenn Sie es für 2+ Stunden spielen, oder 2 Wochen seit Ihrem Kauf vergangen sind, dann wird ASF mit diesem Spiel fortfahren, da es nicht mehr rückerstattungsfähig ist. Bis dahin haben Sie die volle Kontrolle, ob Sie es mögen oder nicht, und können es bei Bedarf leicht zurückerstatten, ohne dass Sie dieses Spiel manuell auf die schwarze Liste setzen oder ASF für die gesamte Dauer nicht verwenden müssen.

- **Sie können neue Gegenstände automatisch als erhalten markieren** (`BotBehaviour` der Funktion `DismissInventoryNotifications`). Das Sammeln mit ASF führt dazu, dass Ihr Konto neue Karten erhält. Sie wissen bereits, dass dies geschehen wird, also lassen ASF diese unnötige Benachrichtigung für Sie lesen und sicherstellen, dass nur wichtige Dinge Ihre Aufmerksamkeit gewinnen. Natürlich nur, wenn Sie dies wünschen.

- **Sie können automatisch Karten von Steam Events** erhalten (Funktion `AutoSteamSaleEvent`). ASF ermöglicht es Ihnen, die Entdeckungsliste während des Steam-Sales zu automatisieren, aber natürlich nur, wenn Sie das auch möchten. Dies spart jeden Tag enorm viel Zeit, während der Steam-Sale stattfindet, und stellt sicher, dass Sie die täglichen Karten nie wieder verpassen werden.

- **Sie können die bevorzugte Sammel-Reihenfolge mit mehr verfügbaren Optionen anpassen** (Funktion `FarmingOrders`). Möglicherweise möchten Sie zuerst Ihre neu gekauften Spiele sammeln? Oder die ältesten? Nach der Anzahl der Karten? Abzeichen-Level, die Sie bereits hergestellt haben? Gespielte Stunden? Alphabetisch? Nach den AppIDs? Oder komplett zufällig? Das liegt ganz bei Ihnen.

- **ASF kann Ihnen helfen, Ihre Sets zu vervollständigen** (`TradingPreferences` mit der Einstellung `SteamTradeMatcher`). Mit etwas fortgeschrittenerem Tüfteln können Sie Ihrer ASF in einen vollwertigen Benutzer-Bot umwandeln, der automatisch **[STM](https://www.steamtradematcher.com)** Handelsangebote akzeptiert und Ihnen jeden Tag hilft, Ihre Sets ohne jegliche Benutzerinteraktion zu ergänzen. ASF enthält sogar ein eigenes ASF-2FA-Modul, mit dem Sie einen mobilen Steam-Authentifikator importieren und den gesamten Prozess vollständig automatisieren können, auch bei der Annahme von Bestätigungen. Oder möchten Sie vielleicht manuell akzeptieren und ASF nur diese Handelsangebote für Sie vorbereiten lassen? Auch das liegt wieder einmal ganz bei Ihnen.

- **ASF kann Produktschlüssel im Hintergrund für Sie einlösen** (Funktion **[Hintergrundproduktschlüsselaktivierer](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer-de-DE)**). Vielleicht haben Sie hundert Produktschlüssel aus verschiedenen Bundles, bei denen Sie zu faul sind alle manuell einzulösen, da Sie bei jedem durch ein paar Fenster gehen und den Steam-Bedingungen immer wieder zustimmen müssen. Warum nicht einfach die Liste der Produktschlüssel zu ASF kopieren und es seine Arbeit machen lassen? ASF löst automatisch alle diese Produktschlüssel im Hintergrund ein und stellt Ihnen entsprechende Ausgaben zur Verfügung, damit Sie wissen, wie sich jeder Einlösungsversuch ausgewirkt hat. Außerdem, wenn Sie hunderte von Produktschlüssel haben, werden Sie garantiert früher oder später von Steam rate-limited. ASF weiß auch davon; wird geduldig warten, bis dieses Anfragelimit verschwindet, und dort weitermachen, wo es aufgehört hat.

Wir könnten nun mit dem gesamten **[ASF-Wiki](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Home-de-DE)** fortfahren und auf jedes einzelne Feature des Programms hinweisen, aber wir müssen irgendwo eine Grenze ziehen. Das ist es, dies ist eine Liste von Features, die Sie als ASF-Benutzer genießen können, wo nur eine davon leicht als ein Hauptgrund angesehen werden könnte, um nie zurückzuschauen, und wir haben tatsächlich **eine Menge** von Ihnen aufgelistet, mit noch mehr, über die Sie auf dem Rest unseres Wikis mehr erfahren können. Wir sind nicht einmal ins Detail gegangen, mit Dingen wie der ASF's API, die es Ihnen etwa ermöglicht, eigene Befehle zu skripten, oder die ausgezeichnete Bot-Verwaltung, da wir es einfach halten wollten.

---

### Ist ASF schneller als Idle Master?

**Ja**, obwohl die Erklärung ziemlich kompliziert ist.

Bei jedem neuen Prozess, der in Ihrem System gestartet und beendet wird, sendet der Steam-Client automatisch eine Anfrage mit allen Spielen, die Sie gerade spielen - so kann das Steam-Netzwerk Stunden berechnen und Karten ausgeben. Das Steam-Netzwerk zählt jedoch die Spielzeit in Intervallen von 1 Sekunde, und das Senden einer neuen Anfrage setzt den aktuellen Status zurück. Mit anderen Worten: wenn Sie alle 0,5 Sekunden einen neuen Prozess starten/abbrechen würden, würden Sie nie eine Karte sammeln, weil jeder 0,5-Sekunden-Steam-Client eine neue Anfrage senden würde und das Steam-Netzwerk somit nie auch nur 1 Sekunde Spielzeit zählt. Außerdem ist es aufgrund der Funktionsweise des Betriebssystems durchaus üblich, neue Prozesse zu erkennen, die ohne Ihr zutun (also selbst wenn Sie nichts auf einem PC unternehmen) gestartet/gestoppt werden. Es gibt viele Prozesse, die immer noch im Hintergrund arbeiten und andere Prozesse die ganze Zeit über auslösen/beenden. Idle Master basiert auf dem Steam Client, sodass dieser Mechanismus Sie beeinflusst, wenn Sie ihn benutzen.

ASF basiert nicht auf dem Steam-Client, sondern hat eine eigene Steam-Client-Implementierung. Dank dessen ist das, was ASF tut, nicht das Auslösen eines Prozesses, sondern das Senden einer echten Anfrage an das Steam-Netzwerk, dass wir mit dem Spielen eines Spiels begonnen haben. Dies ist die gleiche Anfrage, die vom Steam-Client gesendet wird, aber da wir die tatsächliche Kontrolle über den ASF-Steam-Client haben, brauchen wir keine neuen Prozesse zu starten, und wir imitieren den Steam-Client nicht bezüglich der Sendeanforderung bei jeder Prozessänderung, sodass der oben erläuterte Mechanismus uns nicht betrifft. Dank dessen unterbrechen wir nie das 1-Sekunden-Intervall auf Steam, was unsere Sammel-Geschwindigkeit erhöht.

---

### Aber ist der Unterschied wirklich spürbar?

Nein. Die Unterbrechungen, die mit einem normalen Steam-Client und dem Idle Master auftreten, haben nur einen geringen Einfluss auf die Kartendrops, sodass es kein spürbarer Unterschied ist, der ASF überlegen machen würde.

Jedoch **gibt es** einen Unterschied, und Sie können deutlich feststellen, dass, je nachdem, wie beschäftigt Ihr Betriebssystem ist, Karten **werden** schneller gesammelt werden, von ein paar Sekunden auf sogar ein paar Minuten, wenn Sie extrem unglücklich sind. Obwohl ich nicht in Betracht ziehen würde, ASF nur zu verwenden, weil es Karten schneller sammelt, da sowohl ASF , als auch Idle Master von der Funktionsweise des Steam-Netzes beeinflusst werden, interagiert ASF einfach effektiver mit dem Steam-Netz, während Idle Master nicht kontrollieren kann, was der Steam-Client tatsächlich tut (also ist es nicht die Schuld von Idle Master, sondern die des Steam-Clients selbst).

---

### Kann ASF mehrere Spiele auf einmal sammeln?

**Ja**, obwohl ASF besser weiß, wann diese Funktion zu verwenden ist, basierend auf dem ausgewählten **[Karten-Sammel-Algorithmus](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance-de-DE)**. Die Kartendrop-Rate beim Sammeln mehrerer Spiele ist nahe null, deshalb verwendet ASF mehrere Spiele, die ausschließlich über Stunden sammeln, um `HoursUntilCardDrops` schneller zu überwinden, für bis zu `32` Spiele auf einmal. Deshalb sollten Sie sich auch auf den Teil der Konfiguration von ASF konzentrieren und den Algorithmus entscheiden lassen, was der optimale Weg ist, um das Ziel zu erreichen - was Sie für richtig halten, ist in Wirklichkeit nicht unbedingt richtig, denn das Sammeln mehrerer Spiele auf einmal wird Ihnen keine Kartendrops bescheren.

---

### Kann ASF schnell durch die Spiele springen?

**Nein**, ASF unterstützt nicht und fördert auch nicht die Verwendung von **[Steam-Fehlern](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance-de-DE#steam-pannen)**.

---

### Kann ASF jedes Spiel automatisch für X Stunden spielen, bevor Karten gesammelt werden?

**Nein**, der Sinn der Systemumstellung von Steam-Karten war es, mit falschen Statistiken und Geisterspielern zu kämpfen. ASF wird nicht mehr als nötig dazu beitragen, denn das Hinzufügen eines solchen Features ist nicht geplant und wird nicht geschehen. Wenn Ihr Spiel auf übliche Weise Kartendrops erhält, wird ASF diese so schnell wie möglich sammeln.

---

### Kann ich ein Spiel spielen während ASF sammelt?

**Nein**. ASF hat im Gegensatz zu IM einen unabhängigen Steam-Client integriert, und das Steam-Netzwerk erlaubt es nur **einem Steam-Client auf einmal**, ein Spiel zu spielen. Sie können die ASF-Verbindung jedoch jederzeit trennen, indem Sie ein Spiel starten (und auf "OK" klicken, wenn Sie gefragt werden, ob das Steam-Netzwerk einen anderen Client trennen soll) - ASF wird dann geduldig warten, bis Sie fertig sind, um den Prozess anschließend fortsetzen. Alternativ können Sie immer noch jederzeit im Offline-Modus spielen, wenn Ihnen das ausreicht.

Beachten Sie, dass die Drop-Rate der Karten, wenn Sie mehrere Spiele spielen, ohnehin nahe bei 0 liegt, daher gibt es keine direkten Vorteile, wenn Sie das mit IM machen, während es starke Vorteile gibt, wenn Sie sich nicht in andere Spiele einmischen, die mit ASF gestartet wurden, was z. B. für VAC entscheidend ist.

---

## Sicherheit / Datenschutz / VAC / Sperren / Nutzungsbedingungen

---

### Kann ich eine VAC-Sperre bekommen, wenn ich ASF nutze?

Nein, das ist nicht möglich, da ASF (im Gegensatz zu Idle Master oder SAM) in keiner Weise den Steam-Client oder seine Prozesse stört. Es ist physisch unmöglich, eine VAC-Sperre für die Verwendung von ASF zu erhalten, selbst wenn man auf gesicherten Servern spielt, während ASF läuft - das liegt daran, dass **ASF nicht einmal verlangt, dass der Steam-Client überhaupt installiert ist**, um ordnungsgemäß zu funktionieren. ASF ist das einzige Sammel-Programm, das derzeit die VAC-Freiheit garantieren kann.

---

### Kann die Verwendung von ASF verhindern, dass ich auf geschützten VAC-Servern spielen kann, wie **[hier](https://help.steampowered.com/de/faqs/view/22C0-03D0-AE4B-04E8)** angegeben?

ASF benötigt keinen Steam-Client, der ausgeführt, geschweige den installiert wird. Nach diesem Konzept sollte es **keine** VAC-bezogenen Probleme verursachen, da ASF garantiert, dass der Steam-Client und alle seine Prozesse nicht gestört werden - das ist der wichtigste Punkt, wenn es um die VAC-freie Garantie geht, die ASF bietet.

Nach Angaben von Benutzern und nach bestem Wissen und Gewissen ist dies im Moment der Fall, da niemand irgendwelche Probleme wie im obigen Link während der Verwendung von ASF gemeldet hat. Wir konnten das obige Problem nicht mit ASF reproduzieren, während wir es mit Idle Master klar reproduzieren konnten.

Bedenken Sie jedoch, dass Valve irgendwann immer noch ASF zur schwarzen Liste hinzufügen könnte, aber es ist ein kompletter Unsinn, denn selbst wenn sie das tun, könnten Sie dennoch VAC-gesicherte Spiele von Ihrem PC aus spielen und ASF gleichzeitig verwenden, z. B. auf einem Server; also bin ich ziemlich sicher, dass sie sehr gut wissen, dass ASF kein verdächtiger VAC-technischer Verdächtiger sein sollte, und sie werden uns das Leben nicht schwerer machen, indem ASF grundlos auf die schwarze Liste gesetzt wird. Im schlimmsten Fall werden Sie jedoch nicht spielen können, wie oben erwähnt, weil die VAC-freie Garantie von ASF immer noch da ist, unabhängig davon, ob Steam die ASF-Binärdatei auf die schwarze Liste setzt oder nicht (und Sie können ASF immer noch auf jeder anderen Maschine starten, ohne dass ein Steam-Client überhaupt installiert ist). Im Moment gibt es keinen Grund, irgendetwas davon zu tun, und wir hoffen, dass es so bleibt.

---

### Ist es sicher?

Wenn Sie fragen, ob ASF als Software sicher ist, was bedeutet, dass es Ihrem Computer keinen Schaden zufügt, Ihre privaten Daten nicht stiehlt, Viren oder ähnliches installiert - ist es sicher. ASF ist frei von Malware, Datendiebstahl, Kryptowährungsminern und jedem (und allen) anderen zweifelhaften Verhalten, das vom Benutzer als bösartig oder unerwünscht angesehen werden kann. Darüber hinaus haben wir einen speziellen Abschnitt **[Telekommunikation](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Remote-communication-de-DE)**, der unsere Datenschutzerklärung und das ASF-Verhalten behandelt, das über das hinausgeht, was Sie mit dem Programm selbst konfiguriert haben.

Unser Quelltext ist Open-Source, und verteilte Binärdateien werden immer aus **[öffentlich verfügbaren Quellen](https://de.wikipedia.org/wiki/Open-source_software)** von **[automatisierten und vertrauenswürdigen kontinuierlichen Integrationssystemen](https://de.wikipedia.org/wiki/Build_automation)** und nicht einmal von Entwicklern selbst erstellt. Jedes Build ist reproduzierbar, indem es unserem Build-Skript folgt, und wird genau dasselbe ergeben, **[deterministisch](https://de.wikipedia.org/wiki/Deterministic_system)** IL (binärer) Code. Wenn Sie aus irgendeinem Grund unseren Builds nicht vertrauen, können Sie ASF jederzeit aus dem Quelltext kompilieren und verwenden, einschließlich aller Bibliotheken, die ASF verwendet (wie SteamKit2), die ebenfalls Open-Source sind.

Am Ende ist es jedoch immer eine Frage des Vertrauens zu den Entwicklern einer Anwendung, also sollten Sie selbst entscheiden, ob Sie ASF für sicher halten oder nicht und Ihre Entscheidung möglicherweise mit den oben genannten technischen Argumenten unterstützen. Glauben Sie nicht blind meinen Worten - überprüfen Sie es selbst, denn das ist der einzige Weg, um sicher zu gehen.

---

### Kann ich dafür gesperrt werden?

Um diese Frage zu beantworten, sollten wir einen genaueren Blick auf die **[Steam-Nutzungsbedingungen](https://store.steampowered.com/subscriber_agreement)** werfen. Steam verbietet nicht die Verwendung mehrerer Konten, vielmehr **[erlauben sie es](https://help.steampowered.com/faqs/view/7EFD-3CAE-64D3-1C31#share)**, da Sie denselben mobilen Authentifikator für mehr als ein Konto verwenden können. Was es jedoch nicht erlaubt, ist die gemeinsame Nutzung von Konten mit anderen Personen, aber das machen wir hier sowieso nicht.

Der einzige wirkliche Punkt, der ASF betrifft, ist der folgende:
> Sie dürfen keine Mogelsoftware (Cheats), Automatisierungssoftware (Bots), Mods, Hacks oder andere nicht autorisierte Software von Drittanbietern verwenden, um einen Prozess innerhalb eines Abonnement-Marktplatzes [...].

Die Frage ist, was der "Abonnenten-Marktplatz-Prozess" eigentlich sei. Wie wir lesen können:

> Ein Beispiel eines Steam-Abonnement-Marktplatzes ist der Steam Community-Markt

Wir ändern oder automatisieren den Prozess des Abonnenten-Marktplatzes nicht, wenn wir unter Abonnenten-Marktplatz den Markt der Steam-Community oder den Steam-Shop verstehen. Jedoch...

> Valve ist berechtigt, Ihr Benutzerkonto oder ein bestimmtes Abonnement/bestimmte Abonnements in den folgenden Fällen jederzeit zu löschen: (a) Valve stellt generell die Bereitstellung von Abonnements für Abonnenten in einer vergleichbaren Situation ein, oder (b) Sie verstoßen gegen Bedingungen der vorliegenden Vereinbarung (einschließlich etwaiger Abonnementbedingungen oder Nutzungsrichtlinien).

Daher ist ASF, wie bei jeder Steam-Software, nicht von Valve autorisiert und wir können nicht garantieren, dass Sie nicht gesperrt werden, wenn Valve plötzlich entscheidet, dass sie Konten mit ASF jetzt sperren. Dies ist angesichts der Tatsache, dass ASF auf mehr als einer Million Steam-Konten verwendet wird, äußerst unwahrscheinlich, aber dennoch eine Möglichkeit, unabhängig von der tatsächlichen Wahrscheinlichkeit.

Besonders weil:
> Hinsichtlich jeglicher Abonnements sowie vertragsgegenständlichen Inhalte und Leistungen, die nicht der Urheberschaft von Valve entstammen, nimmt Valve keine Überwachung derartiger Inhalte von Drittanbietern, die auf der Steam-Plattform oder über sonstige Quellen verfügbar sind, vor. Valve übernimmt in Bezug auf derartige Inhalte von Drittanbietern keinerlei Verantwortung oder Haftung. Bestimmte Anwendungssoftware von Drittanbietern kann von Unternehmen für geschäftliche Zwecke verwendet werden – Sie dürfen derartige Software über die Steam-Plattform jedoch ausschließlich für Ihren privaten Gebrauch erwerben.

Allerdings erkennt Valve klar an, dass es "Steam-Sammler" gibt, wie **[hier](https://help.steampowered.com/faqs/view/22C0-03D0-AE4B-04E8)** angegeben, also wenn Sie mich fragen, bin ich mir ziemlich sicher, dass sie, wenn sie nicht einverstanden damit wären, bereits etwas tun würden, anstatt darauf hinzuweisen, dass sie VAC-technisch Probleme verursachen könnten. Das Schlüsselwort hier ist **Steam**-Sammler, zum Beispiel ASF, und nicht **Spiel** Sammler.

Bitte beachten Sie, dass das oben genannte lediglich unsere Interpretation der **[Steam-AGB](https://store.steampowered.com/subscriber_agreement/german)**, sowie diverser anderer Punkte ist. ASF ist durch die Apache 2.0 Lizenz geschützt, welche eindeutig vorschreibt:

```
Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
```

Sie verwenden diese Software auf eigene Gefahr. Es ist sehr unwahrscheinlich, dass man dafür gesperrt wird, aber falls dies geschieht, kann man nur sich selbst die Schuld dafür geben.

---

### Wurde jemand dafür gesperrt?

**Ja**, wir hatten bereits ein paar Vorfälle, die gewissermaßen zu einer Steam-Sperre führten. Ob ASF selbst die Ursache war oder nicht, ist eine ganz andere Geschichte, die wir wahrscheinlich nie erfahren werden.

Der erste Fall war von jemandem mit über 1000+ Bots, der vom Handel ausgeschlossen wurde (zusammen mit allen Bots); höchstwahrscheinlich aufgrund der übermäßigen Verwendung von `loot ASF`, das auf allen Bots gleichzeitig ausgeführt wurde, oder einer anderen verdächtigen einseitigen Menge von Handelsangeboten in sehr kurzer Zeit.

> Hallo XXX, Vielen Dank, dass Sie den Steam-Support kontaktiert haben. Es scheint, als ob dieses Konto verwendet wurde, um ein Netzwerk von Bot-Accounts zu verwalten. Botting ist eine Verletzung der Steam-Abonnentenvereinbarung.

Verwenden Sie bitte etwas gesunden Menschenverstand und gehen Sie nicht davon aus, dass solche verrückten Dinge nur tun können, weil ASF Ihnen dies erlaubt. Das Ausführen von `loot ASF` auf über 1k Bots kann leicht als **[DDoS](https://de.wikipedia.org/wiki/DDoS)** Angriff angesehen werden, und ich persönlich bin nicht schockiert, dass jemand für solch eine Sache gesperrt wurde. Seien Sie fair bei der Verwendung in Bezug auf den Steam Service, und ** höchstwahrscheinlich** wird es Ihnen gut gehen.

Der zweite Fall handelt von jemandem mit 170+ Bots, der während des Steam Winter Sales gesperrt wurde.

> Ihr Account wurde wegen Verletzung der Steam-Abonnementvereinbarung gesperrt. Nach den Handelsanfragen und anderen Faktoren zu urteilen, wurde dieser Benutzeraccount verwendet, um auf illegale Weise Steam-Sammelkarten zu horten und weitere damit verbundene nicht nur kommerzielle Aktivitäten durchzuführen. Der Account wurde dauerhaft gesperrt und der Steam-Support kann keinen zusätzlichen Support diesbezüglich anbieten.

Dieser Fall ist wieder einmal sehr schwer zu analysieren, da diese vage Reaktion des Steam-Supports kaum Details bietet. Basierend auf meinen persönlichen Ansichten hat dieser Benutzer wahrscheinlich Steam-Karten gegen irgendeine Art von Geld eingetauscht (Level-up-Bot?) oder auf andere Weise versucht, bei Steam Geld auszuzahlen. Im Falle, dass Sie sich dessen nicht bewusst sind, es ist ebenfalls in den **[Steam-Nutzungsbedingungen" untersagt](https://store.steampowered.com/subscriber_agreement/german)**.

Im dritten Fall, bei dem ein Benutzer mit 120+ Bots wegen Verletzung von **[Steam-Online-Verhalten](https://store.steampowered.com/online_conduct?l=english)** gesperrt wurde.

> Hallo XXX, Vielen Dank, dass Sie den Steam-Support kontaktiert haben. Dieser und andere Accounts wurden für das Fluten unserer Netzwerk-Infrastruktur verwendet, was gegen den Steam Verhaltenskodex verstößt. Der Benutzeraccount wurde permanent gesperrt und der Steam-Support kann keine zusätzliche Hilfe zu diesem Fall anbieten.

Dieser Fall ist Aufgrund der zusätzlichen Angaben des Benutzers etwas einfacher zu analysieren. Anscheinend verwendete der Benutzer **eine sehr veraltete ASF-Version**, die einen Fehler enthielt, der dazu führte, dass ASF eine übermäßige Anzahl von Anfragen an Steam-Server sendete. Der Fehler selbst existierte zunächst nicht, wurde aber wegen einer Änderung von Steam ausgelöst, die in einer späteren Version behoben wurde. **ASF wird nur in [der neuesten stabilen Version](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest) auf GitHub** unterstützt. Software wird von Menschen geschrieben, und Menschen neigen dazu, Fehler zu begehen. Wenn der Fehler einen globalen Umfang hat, wird er schnell behoben und als Bugfix für alle Benutzer veröffentlicht. Valve wird nicht plötzlich eine Million ASF-Benutzer aufgrund meines Fehlers sperren - aus offensichtlichen Gründen. Wenn Sie jedoch absichtlich auf die Verwendung einer aktuellen Version von ASF verzichten, dann sind Sie per Definition in einer sehr kleinen Minderheit von Benutzern, die **Vorfällen wie diesen** aufgrund von **keiner technischen Unterstützung** ausgesetzt sind, da niemand auf Ihre veraltete Version von ASF aufpasst, niemand sie repariert und niemand sicherstellt, dass Sie nicht einfach durch den Start von ASF völlig gesperrt werden. **Bitte verwenden Sie die aktuellste Version**, nicht nur ASF, sondern auch bei alle anderen Anwendungen.

Der jüngste Fall ereignete sich etwa Juni 2021, laut dem Benutzer:

> Mit Ihrem Programm habe ich seit 3 Jahren Booster-Pakete mit 28 Accounts und 128 Accounts in den letzten 6 Monaten erstellt. Ich war mit maximal 15 Konten gleichzeitig online, um Booster-Packs herzustellen und sie an das Hauptkonto zu schicken. Letzten Monat habe ich die Anzahl der gleichzeitigen Online-Konten auf 20 erhöht, und eine Woche danach wurden meine sämtlichen Konten gesperrt. Diese E-Mail soll Ihnen nicht die Schuld geben - im Gegenteil! Ich war mir immer der Folgen bewusst. Ich wollte, dass Sie wissen, welche Verhaltensweisen zu einem dauerhaften Verbot führen.

Es ist schwer zu sagen, ob die Erhöhung der gleichzeitigen Konten der direkte Grund für die Sperre war; darauf würde ich nicht zählen, sondern ich glaube, dass allein die Anzahl der Konten der Hauptschuldige war; die gleichzeitige Nutzung von Online-Konten hat wahrscheinlich gerad die Aufmerksamkeit auf den betreffenden Nutzer gelenkt, da er deutlich mehr Bots als unsere Empfehlung hatte.

---

Alle oben genannten Vorfälle haben eines gemeinsam - ASF ist nur ein Programm und es ist **Ihre** Entscheidung, wie Sie es nutzen möchten. Sie bekommen keine Sperre für die Verwendung von ASF allein, aber es kommt darauf an **wie** Sie ASF benutzen. Es kann ein Hilfsprogramm sein, das nur ein einziges Konto sammelt, oder ein riesiges Sammel-Netzwerk aus Tausenden von Bots. Ich biete in keinem Fall eine rechtliche Beratung an, und Sie sollten sich zunächst erst selbst über Ihre ASF-Nutzung entscheiden. Ich verheimliche keine Informationen, die Ihnen helfen könnten, z. B. die Tatsache, dass ASF einige Leute gesperrt hat, da ich keinen Grund dazu habe - es ist Ihre Entscheidung, was Sie mit diesen Informationen anstellen. Wenn Sie mich fragen - benutzen Sie Ihren gesunden Menschenverstand und vermeiden Sie es, ein massives Sammel-Netzwerk von Bots zu betreiben oder gar hunderte Handelsangebote gleichzeitig zu senden und verwenden Sie immer die aktuellste ASF-Version und alles _sollte_ gut sein. Jeder einzelne Vorfall dieser Art ist aus **irgendeinem Grund** immer Leuten passiert, die unsere Empfehlung missachtet und entschieden haben, dass sie es besser wissen, wie viele Bots sie betreiben können. Ob es nur ein Zufall oder ein tatsächlicher Faktor ist, das liegt bei Ihnen zu entscheiden. Ich biete keine rechtliche Beratung an, sondern gebe Ihnen nur meine Gedanken, die Sie nützlich finden können, oder ganz und gar ignorieren, und arbeite nur mit den oben genannten Fakten.

---

### Welche Datenschutzinformationen gibt ASF weiter?

Eine detaillierte Erläuterung zu diesem Thema finden Sie im Abschnitt **[Telekommunikation](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Remote-communication-de-DE)**. Sie sollten es lesen, wenn Sie sich um Ihre Privatsphäre kümmern, z. B. wenn Sie sich fragen, warum Konten, die in ASF verwendet werden, unserer Steam-Gruppe beitreten. ASF sammelt keine sensiblen Informationen und gibt sie nicht an Dritte weiter.

---

## Sonstiges

---

### Ich verwende ein nicht unterstütztes Betriebssystem z. B. 32-Bit-Windows, kann ich trotzdem die neueste ASF-Version verwenden?

Ja, und diese Version wird auch unterstützt, nur nicht offiziell erstellt. Schauen Sie sich hierfür die generische Variante im Abschnitt **[Kompatibilität](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility-de-DE)** an. ASF hat keine ausgeprägte Abhängigkeit vom Betriebssystem und es kann überall dort funktionieren, wo Sie eine funktionierende .NET Runtime finden, welches Windows 32-Bit mit einbezieht, auch wenn es kein OS-spezifisches Paket für `win-x86` von uns gibt.

---

### ASF ist großartig! Kann ich spenden?

Ja, und wir freuen uns sehr zu hören, dass Ihnen unser Projekt gefällt! Unter jeder **[Veröffentlichung](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** und auch **[auf der Hauptseite](https://github.com/JustArchiNET/ArchiSteamFarm)** finden Sie verschiedene Möglichkeiten eine Spende zu tätigen. Es ist gut zu wissen, dass wir neben allgemeinen Geldspenden auch Steam-Gegenstände akzeptieren, sodass Sie nichts davon abhält, Skins, Keys oder einen kleinen Teil der Karten, die mit ASF gesammelt wurden, zu spenden. Natürlich nur, wenn Sie möchten. Vielen Dank im Voraus für Ihre Großzügigkeit!

---

### Ich verwende den "Steam Parental PIN" (Familienansicht), um mein Konto zu schützen. Muss ich diesen irgendwo eingeben?

Ja, Sie müssen ihn in der `SteamParentalCode` Bot-Konfigurationseigenschaft setzen. Dies liegt hauptsächlich daran, dass ASF auf viele geschützte Teile Ihres Steam-Kontos zugreift und es für ASF unmöglich ist, ohne diesen zu arbeiten.

---

### Ich möchte nicht, dass ASF standardmäßig irgendwelche Spiele sammelt, aber ich möchte zusätzliche ASF-Funktionen verwenden. Ist das möglich?

Ja, wenn Sie ASF nur mit dem pausierten Karten-Sammel-Modul starten möchten, können Sie die Bot-Konfigurationseigenschaft `Paused` auf `true` setzen, um dies zu erreichen. Dies ermöglicht Ihnen die Fortsetzung (`resume`) während der Ausführung.

Wenn Sie das Karten-Sammelmodul vollständig deaktivieren und sicherstellen möchten, dass es nie ausgeführt wird, ohne dass Sie es explizit anders angeben, dann empfehlen wir, `FarmPriorityQueueOnly` auf `true` zu setzen, was den Leerlauf komplett deaktiviert, anstatt es nur anzuhalten, bis Sie die Spiele selbst in die Warteschlange für ungenutzte Prioritäten aufnehmen.

Wenn das Karten-Sammel-Modul angehalten/deaktiviert ist, können Sie zusätzliche ASF-Funktionen nutzen, wie z. B. `GamesPlayedWhileIdle`.

---

### Kann ich ASF in die Taskleiste minimieren?

ASF ist eine Konsolenanwendung. Es gibt kein zu minimierendes Fenster, da das Fenster von Ihrem Betriebssystem für Sie erstellt wird. Sie können jedoch ein beliebiges Drittanbieterprogramm verwenden wie z. B. **[RBTray](https://github.com/benbuck/rbtray)** für Windows oder **[screen](https://linux.die.net/man/1/screen)** für Linux/macOS. Dies sind nur Beispiele. Es gibt viele andere Apps mit ähnlicher Funktionalität.

---

### Stellt die Verwendung von ASF die Berechtigung zum Erhalt von Booster Packs sicher?

**Ja**. ASF verwendet die gleiche Methode wie der offizielle Client, um sich im Steam-Netzwerk anzumelden, daher enthält es auch die Möglichkeit, Booster Packs für die verwendeten Konten zu erhalten. Mehr noch: Um diese Fähigkeit zu bewahren, muss man sich nicht einmal in die Steam-Community einloggen. Damit können Sie, falls Sie es wünschen, den `OnlineStatus` `Offline` sicher verwenden.

---

### Gibt es eine Möglichkeit mit ASF zu kommunizieren?

Ja, auf unterschiedlicher Weise. Weitere Informationen finden Sie im Abschnitt **[Befehle](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-de-DE)**.

---

### Ich möchte bei der Übersetzung von ASF helfen, was muss ich tun?

Vielen Dank für Ihr Intresse! Alle Details hierzu können Sie in unserem Abschnitt **[Lokalisierung](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Localization-de-DE)** finden.

---

### Ich habe nur ein (Haupt-)Konto zu ASF hinzugefügt, kann ich trotzdem Befehle per Steam-Chat senden?

**Ja**, es wird im Abschnitt **[Befehle](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-de-DE#notes)** erklärt. Sie können dies über den Steam-Gruppen-Chat erreichen, obwohl die Verwendung von **[ASF-UI](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-de-DE#asf-ui)** für Sie einfacher sein könnte.

---

### ASF scheint zu funktionieren, aber ich erhalte keine Karten!

Die Sammelrate der Karten ist von Spiel zu Spiel unterschiedlich, wie Sie in **[Performance](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance-de-DE)** nachlesen können. Es dauert eine Weile, normalerweise **mehrere Stunden pro Spiel** und Sie sollten nicht erwarten, dass Karten in ein paar Minuten nach dem Start eines Programmes gesammelt werden. Wenn Sie sehen können, dass ASF den Kartenstatus aktiv überprüft und das Spiel wechselt, nachdem das aktuelle vollständig gesammelt wurde, dann funktioniert alles einwandfrei. Es ist möglich, dass Sie eine Option wie `DismissInventoryNotifications` von `BotBehaviour` aktiviert haben, die Inventarbenachrichtigungen automatisch ausblendet. Mehr Details unter **[Konfiguration](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-de-DE)**.

---

### Wie kann ich den ASF-Prozess für mein Konto vollständig stoppen?

Beenden Sie einfach den ASF-Prozess, z. B. durch Anklicken von [X] unter Windows. Wenn Sie stattdessen einen bestimmten Bot Ihrer Wahl stoppen, aber andere weiter ausführen möchten, dann schauen Sie sich die `Enabled` **[Bot-Konfigurationsvariable](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-de-DE#bot-konfiguration)** an, oder den **[Befehl](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-de-DE)** `stop`. Wenn Sie stattdessen den automatischen Sammelprozess stoppen, aber ASF für Ihr Konto weiter ausführen möchten, dann erreichen Sie dies bestenfalls mit der **[Bot-Konfigurationsvariable ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-de-DE#bot-konfiguration)** `Paused` und dem **[Befehl](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-de-DE)** `pause`.

---

### Wie viele Bots kann ich mit ASF verwenden?

ASF als Programm hat keine unmittelbare Obergrenze für Bot-Instanzen, sodass Sie so viele Bot-Instanzen ausführen können, wie Sie Speicher auf Ihrem Computer haben, aber Sie sind immer noch durch das Steam-Netzwerk und andere Steam-Dienste limitiert. Derzeit können Sie bis zu 100-200 Bots mit einer einzigen IP und einer einzelnen ASF-Instanz ausführen. Es ist möglich, mehr Bots mit mehr IPs und mehr ASF-Instanzen auszuführen, indem man die IP-Beschränkungen umgeht. Beachten Sie, dass, wenn Sie diese große Anzahl von Bots verwenden, deren Anzahl Sie selbst kontrollieren sollten (z. B. sicherstellen, dass sich alle tatsächlich anmelden und zur gleichen Zeit arbeiten). ASF wurde nicht für diese große Anzahl an Bots optimiert und die allgemeine Regel gilt, dass **je mehr Bots Sie haben, desto mehr Probleme werden Sie bekommen**. Außerdem ist zu beachten, dass das obige Limit im Allgemeinen von vielen internen Faktoren abhängt - es ist eher eine Annäherung als ein strenges Limit - Sie werden höchstwahrscheinlich in der Lage sein, mehr/weniger Bots als oben erläutert auszuführen.

Das ASF-Team empfiehlt, bis zu **10 Bots insgesamt** laufen zu lassen (und zu **besitzen**), alles darüber wird nicht unterstützt und auf eigenes Risiko durchgeführt, gegen unseren Vorschlag, der hier gemacht wurde. Diese Empfehlung basiert auf den internen Valve-Richtlinien, sowie unseren eigenen Empfehlungen. Ob Sie diese Regel einhalten oder nicht, ist Ihre Entscheidung, ASF als Werkzeug wird nicht gegen Ihren eigenen Willen handeln, auch wenn es dazu führen sollte, dass Ihre Steam-Konten dafür gesperrt werden. Daher wird ASF Ihnen eine Warnung anzeigen, wenn Sie über das hinausgehen, was wir empfehlen. Trotzdem erfolgt alles, auf Ihr eigenes Risiko und ohne unseren Support.

---

### Kann ich dann mehr ASF-Instanzen ausführen?

Sie können so viele ASF-Instanzen auf einem Computer ausführen, wie Sie möchten, vorausgesetzt, jede Instanz hat ein eigenes Verzeichnis und Ihre eigenen Konfigurationen, und das in einer Instanz verwendete Konto wird in einer Anderen nicht verwendet. Allerdings sollten Sie sich fragen, warum Sie das tun möchten. ASF ist dazu optimiert, mehrere hundert Accounts gleichzeitig zu verwalten. Das Starten vieler Bots in ihren eigenen ASF-Instazen senkt die (Gesamt-)Leistung, verbraucht mehr Betriebssystem-Ressourcen (beispielsweise CPU, Arbeitsspeicher), und verursacht potentiell Probleme beim synchronisieren zwischen den einzelnen ASF-Instanzen, da ASF gezwungen ist, seine Limitierung (Limiters) mit den anderen Instanzen zu teilen.

Deshalb ist es mein **Ratschlag**, immer maximal eine ASF-Instanz pro IP/Schnittstelle auszuführen. Wenn Sie mehr IPs/Schnittstelle haben, können Sie mit allen Mitteln mehr ASF-Instanzen ausführen, mit jeder Instanz über eine eigene IP/Schnittstelle oder eine eindeutige `WebProxy`-Einstellung. Wenn Sie dies nicht berücksichtigen, ist es völlig sinnlos, mehr ASF-Instanzen zu starten, da Sie sonst jede einzelne IP/Schnittstelle auf 1 Instanz begrenzt ist. Steam wird es Ihnen nicht auf magische Weise erlauben, mehr Bots auszuführen, nur weil Sie sie in einer anderen ASF-Instanz gestartet wurden, und ASF beschränkt Sie von Anfang an nicht.

Natürlich gibt es immer noch sinnvolle Anwendungsfälle für mehrere ASF-Instanzen auf derselben Netzwerkschnittstelle, wie z. B. das Hosten von ASF für Ihre Freunde, bei denen jeder Freund eine eigene ASF Instanz besitzt, um die Isolation zwischen Bots und sogar den ASF-Prozessen selbst zu gewährleisten. Dies hat aber nicht den Zweck, geschweige denn die Möglichkeit, um Steambeschränkungen zu umgehen.

---

### Was bedeutet Status beim Einlösen eines Produktschlüssels?

Der Status zeigt an, wie sich der gegebene Einlösungsversuch ausgewirkt hat. Es gibt viele verschiedene Status, darunter die gängigsten:

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

### Gehören Sie zu einem Karten-Sammel-Dienst?

**Nein**. ASF ist mit keinem Dienst verknüpft und alle diese Behauptungen sind falsch. Ihr Steam-Konto ist Ihr Eigentum und Sie können es Konto auf jede erdenkliche Weise nutzen, aber Valve hat es klar in den **[offiziellen Nutzungsbedingungen](https://store.steampowered.com/subscriber_agreement/german)** erklärt:

> Sie sind für die Vertraulichkeit Ihrer Anmeldedaten und Ihres Passworts sowie die Sicherheit Ihres Computersystems verantwortlich. Valve ist nicht verantwortlich für die Nutzung Ihres Passworts und Kontos oder für die gesamte Kommunikation und Aktivität auf Steam, die aus der Verwendung Ihres Anmeldenamens und Ihres Passworts durch Sie oder durch andere Personen resultiert, denen gegenüber Sie möglicherweise unter Verletzung dieser Geheimhaltungsklausel vorsätzlich oder fahrlässig Ihre Anmeldedaten und/oder Ihr Passwort offengelegt haben.

ASF ist unter der freien Apache 2.0 Lizenz geschützt, die es anderen Entwicklern ermöglicht, ASF weiter in ihre eigenen Projekte und Dienste zu integrieren. Es wird jedoch nicht garantiert, dass solche Drittprojekte, die ASF verwenden, sicher, überprüft, angemessen oder legal gemäß **[Steam-Nutzungsbedingungen](https://store.steampowered.com/subscriber_agreement/german)** (ToS/ AGB) sind. Wenn Sie unsere Meinung hören möchten, **wir empfehlen Ihnen dringend, KEINE Ihrer Kontoinformationen mit Drittanbietern zu teilen**. Wenn sich ein solcher Dienst als **typischer Betrug** herausstellt, werden Sie mit dem Problem allein gelassen, höchstwahrscheinlich ohne Ihr Steam-Konto; und ASF übernimmt keine Verantwortung für Dienstleistungen von Drittanbietern, die behaupten, sicher und geschützt zu sein, weil das ASF-Team weder genehmigt noch eine davon überprüft hat. Mit anderen Worten: **Sie benutzen sie auf eigene Gefahr, entgegen unseres oben genannten Vorschlags**.

Zusätzlich beschreibt die offizielle **[Steam-AGB](https://store.steampowered.com/subscriber_agreement/german)** eindeutig:

> Es ist Ihnen untersagt, Ihr Kennwort oder Benutzerkonto Dritten offenzulegen bzw. zugänglich zu machen oder Dritte sonst Ihr Kennwort oder Benutzerkonto nutzen zu lassen, es sei denn, Valve hat dem ausdrücklich zugestimmt.

Es ist Ihr Konto und Ihre Entscheidung. Sagen Sie nur nicht, dass Sie niemand gewarnt hat. ASF als Programm erfüllt alle oben genannten Bedingungen, da Sie Ihre Kontodaten an niemanden weitergeben und Sie das Programm für Ihren eigenen persönlichen Gebrauch verwenden, aber jeder andere "Karten-Sammel-Dienst" verlangt von Ihnen Ihre Zugangsdaten, sodass es auch gegen die oben genannte Regel verstößt (eigentlich mehrere von Ihnen). Wie bei der Auswertung der **[Steam-Nutzungsbedingungen](https://store.steampowered.com/subscriber_agreement/german)** (AGB), bieten wir keine Rechtsberatung an, und Sie sollten sich selbst entscheiden, ob Sie diese Dienste nutzen möchten oder nicht. Unserer Auffassung nach **verstößt es direkt gegen die [AGB](https://store.steampowered.com/subscriber_agreement/german)** und kann zu einer Suspendierung führen, wenn Valve dies herausfindet. Wie bereits erwähnt, **empfehlen wir dringend, KEINE dieser Dienste zu nutzen**.

---

## Probleme

---

### Eines meiner Spiele wird nun seit mehr als 10 Stunden gespielt, aber ich habe noch keine Karten erhalten!

Der Grund dafür könnte mit den bekannten Steam Problem zusammenhängen, das auftritt, wenn Sie zwei Lizenzen für ein und dasselbe Spiel haben, von denen eine Lizenz eine limitierte Kartenrate besitzt. Dies passiert üblicherweise, wenn Sie das Spiel kostenlos während eines Massengiveaway auf Steam aktiviert haben und anschließend einen Schlüssel für das gleiche Spiel (aber ohne Limitierungen) aktivieren. Wenn solch eine Situation eintritt, meldet Steam auf der Abzeichenseite, dass das Spiel noch Karten zu sammeln hat, aber egal, wie viel Sie spielen - die Karten werden aufgrund der kostenlosen Lizenz in Ihrem Konto nie gutgeschrieben. Da dies kein Fehler seitens ASF, sondern von Steam ist, können wir diesen auf ASF-Seite nicht umgehen und Sie müssen das Problem selbst lösen.

Es gibt zwei Möglichkeiten, das Problem zu lösen. Zum Einen können Sie das Spiel in ASF über den **[Befehl](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-de-DE)** `fbadd`, oder mit der entsprechenden `Blacklist` **[Konfigurationseigenschaft](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-de-DE)** vom automatischen Sammeln ausschließen. Dies verhindert zwar, dass ASF versucht Karten von dem Spiel zu sammeln, löst aber nicht das eigentliche Problem, welches verhindert, dass Sie Karten von dem betroffenen Spiel erhalten. Zum Anderen können Sie das Steam Support Self-Service-Tool verwenden, um die kostenlose Lizenz von Ihrem Konto zu entfernen, sodass nur noch die volle Lizenz, welche Karten beinhaltet, übrig bleibt. Um dies zu erreichen, besuchen Sie zuerst die Seite **["Lizenzen und Produktschlüsselaktivierungen"](https://store.steampowered.com/account/licenses)** und finden Sie sowohl die kostenlose , als auch kostenpflichtige Lizenz für das betroffene Spiel. Normalerweise ist es ziemlich einfach. Beide haben einen ähnlichen Namen, aber die kostenlose Lizenz enthält "Limited free promotional package " oder andere "promo" im Lizenztitel, sowie "complimentary" im Bereich "Kaufmethode". Manchmal könnte es schwieriger sein, zum Beispiel, wenn das freie Paket in einem Bundle war und einen anderen Namen hat. Falls Sie einige dieser Lizenzen gesehen haben - dann ist es tatsächlich das Problem, das hier erläutert wurde und Sie können die kostenlose Lizenz sicher entfernen, ohne das Spiel zu verlieren.

Um die kostenlose Lizenz von Ihrem Konto zu entfernen, gehen Sie auf die **[Steam-Support-Seite](https://help.steampowered.com/wizard/HelpWithGame)** und geben Sie den betroffenen Spielnamen im Suchfeld ein; das Spiel sollte im Bereich "Produkte" verfügbar sein; klicken Sie darauf. Alternativ können Sie einfach den Link `https://help.steampowered.com/wizard/HelpWithGame?appid=<AppID>` verwenden und `<AppID>` durch AppID des Spiels ersetzen, das Probleme verursacht. Danach klicken Sie auf "Ich möchte dieses Spiel dauerhaft von meinem Konto entfernen" und wählen die fehlerhafte kostenlose Lizenz, die Sie oben gefunden haben- in der Regel die mit "limited free promotional package " im Namen (oder ähnlichem). Nach dem Entfernen der freien Lizenz sollte ASF in der Lage sein, Karten aus dem betroffenen Spiel ohne Probleme zu sammeln. Sie sollten den Sammelprozess nach der Entfernung neu starten, nur um sicherzustellen, dass Steam diesmal die richtige Lizenz auswählt.

---

### ASF erkennt Spiel `X` nicht als zum Sammeln verfügbar, aber ich weiß, dass es Steam-Karten enthält!

Hierfür gibt es zwei Hauptgründe. Der erste und offensichtlichste Grund ist die Tatsache, dass Sie sich auf den **Steam-Shop** beziehen, wo ein gegebenes Spiel mit Karten angekündigt wird. Diese Annahme ist **falsch**, da es lediglich besagt, dass das Spiel Karten **enthält**, aber nicht unbedingt, ob diese Funktion für dieses Spiel auch sofort **aktiviert** ist. Mehr dazu können Sie in den **[offiziellen Ankündigungen](https://steamcommunity.com/games/593110/announcements/detail/1954971077935370845)** lesen.

Kurz gesagt, das Karten-Symbol im Steam-Shop bedeutet nichts, prüfen Sie ihre **[Abzeichen-Seiten](https://steamcommunity.com/my/badges)** zur Bestätigung, ob ein Spiel Karten aktiviert hat oder nicht - das ist auch das, was ASF tut. Wenn ein Spiel nicht auf der Liste als ein Spiel mit Karten erscheint, dann ist es **nicht** möglich dieses Spiel zu sammeln, unabhängig vom Grund.

Das zweite Problem ist weniger offensichtlich. Nämlich sobald Sie sehen, dass ein Spiel tatsächlich auf der Abzeichen-Seite Karten verfügbar sind, aber es dennoch nicht sofort von ASF gesammelt wird. Es sei denn, Sie treffen auf einen anderen Fehler, wie z. B. ASF, welches nicht in der Lage ist, Abzeichen-Seiten zu überprüfen (siehe unten). Es ist einfach ein Cache-Effekt und seitens ASF meldet Steam immer noch veraltete Abzeichen-Seiten. Dieses Problem sollte sich früher oder später lösen, wenn der Cache ungültig wird. Es gibt auch keine Möglichkeit, dies auf unserer Seite zu beheben.

Natürlich setzt das alles vorraus, dass Sie ASF mit standardmäßig unberührten Einstellungen verwenden, da Sie dieses Spiel auch zur schwarzen Liste des Sammelmoduls hinzufügen könnten; indem Sie `FarmPriorityQueueOnly`, `SkipRefundableGames` und so weiter... verwenden.

---

### Warum erhöht sich die Spielzeit von Spielen, die über ASF gespielt werden, nicht?

Das tut es, aber **nicht in Echtzeit**. Steam zeichnet Ihre Spielzeit in festen Intervallen auf und aktualisiert die Zeitpläne dafür, aber es ist nicht garantiert, dass sie sofort nach Beendigung der Sitzung aktualisiert wird, geschweige denn während dieser Zeit. Nur weil die Spielzeit nicht in Echtzeit aktualisiert wird, bedeutet das nicht, dass sie nicht aufgezeichnet wird. In der Regel wird diese alle 30 Minuten aktualisiert.

---

### Worin besteht der Unterschied zwischen einer Warnung und einem Fehler im Protokoll?

ASF schreibt eine Reihe von Informationen über verschiedene Logging-Ebenen in sein Protokoll. Unser Ziel ist es, **präzise** zu erklären, was ASF tut, einschließlich welcher Steam-Probleme es zu bewältigen hat, oder anderer zu überwindenden Probleme. Meistens ist nicht alles relevant, deshalb haben wir in ASF zwei große Stufen, die in Bezug auf Probleme verwendet werden - eine Warnstufe und eine Fehlerstufe.

Die allgemeine ASF-Regel ist, dass Warnungen **keine** Fehler sind, daher sollten sie **nicht** gemeldet werden. Eine Warnung ist ein Indikator für Sie, dass möglicherweise etwas Unerwünschtes passiert. Egal ob es Steam war das nicht reagierte, die API Fehler geworfen hat oder Ihre Netzwerkverbindung Probleme hatte - es ist eine Warnung und das bedeutet, dass wir erwarten das dies passiert, also belästige die ASF-Entwicklung nicht damit. Natürlich steht es Ihnen frei, nach Ihnen zu fragen oder Hilfe zu erhalten, indem Sie unsere technische Unterstützung in Anspruch nehmen, aber Sie sollten nicht davon ausgehen, dass es sich um meldenswerte ASF-Fehler handelt (sofern wir nichts anderes bestätigen).

Fehler hingegen deuten auf eine Situation hin, die nicht eintreten sollte, daher sind sie es wert, gemeldet zu werden, solange man sich vergewissert hat, dass diese nicht selbstverschuldet sind. Wenn es sich um eine allgemeine Situation handelt, die wir erwarten, dann wird sie stattdessen in eine Warnung umgewandelt. Andernfalls handelt es sich möglicherweise um einen Fehler, der korrigiert und nicht stillschweigend ignoriert werden sollte, vorausgesetzt, er ist nicht das Ergebnis Ihres eigenen technischen Problems. Wenn Sie zum Beispiel ungültigen Inhalt in die Datei `ASF.json` eintragen, wird ein Fehler auftreten, da ASF ihn nicht analysieren kann, aber Sie waren es, der ihn dort platziert hat, also sollten Sie diesen Fehler nicht an uns melden (es sei denn, Sie haben bestätigt, dass ASF falsch liegt und Ihre Struktur tatsächlich absolut korrekt ist).

In einem Satz: Fehler melden und Warnungen nicht melden. Sie können nach wie vor zu Warnungen Fragen stellen und in unseren Unterstützungsbereichen Hilfe erhalten.

---

### ASF startet nicht; das Programmfenster schließt sich sofort!

Unter normalen Bedingungen erzeugt jeder ASF-Absturz oder -Beendigung eine `log.txt` im Verzeichnis des Programms, die Sie sich ansehen können, um die Ursache dafür zu finden. Zusätzlich werden einige kürzliche Logdateien auch im `Logs`-Verzeichnis archiviert, da die Haupt-`log.txt`-Datei wird mit jedem ASF-Lauf überschrieben.

Wenn jedoch selbst die .NET Runtime nicht in der Lage ist, auf Ihrem Gerät zu booten, dann wird `log.txt` nicht erstellt. Wenn Ihnen das passiert, haben Sie höchstwahrscheinlich vergessen, die Voraussetzungen für die Installation von .NET zu installieren, wie in der Anleitung **[Einrichtung](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up-de-DE#os-specific-setup)** erläutert. Andere häufige Probleme können der Versuch sein, eine falsche ASF-Variante für Ihr Betriebssystem zu starten, oder auf andere Weise fehlende native .NET Laufzeitabhängigkeiten. Wenn sich das Konsolenfenster zu früh schließt, als dass Sie die Nachricht lesen können, dann öffnen Sie die unabhängige Konsole und starten von dort aus die ASF-Binärdatei. Öffnen Sie beispielsweise unter Windows das ASF-Verzeichnis, halten Sie `Shift` gedrückt, klicken Sie mit der rechten Maustaste in den Ordner und wählen Sie *"Befehlsfenster hier öffnen"* (oder *Powershell*), geben Sie dann in die Konsole `.\ArchiSteamFarm.exe` ein und bestätigen Sie mit Enter. Auf diese Weise erhalten Sie eine genaue Meldung, warum ASF nicht richtig startet.

---

### ASF wirft mich aus meiner Steam-Client-Sitzung während ich spiele! / *Dieser Account wird an einem anderen PC verwendet*

Dies wird als Meldung im Steam-Overlay angezeigt, dass das Konto während des Spiels woanders verwendet wird. Dieses Problem kann zwei verschiedene Gründe haben.

Ein Grund dafür sind defekte Pakete (Spiele), die speziell eine Spielsperre nicht richtig halten, aber erwarten, dass diese vom Client besessen wird. Ein Beispiel für ein solches Paket wäre Skyrim SE. Ihr Steam-Client startet das Spiel richtig, aber dieses Spiel registriert sich selbst nicht als in Benutzung. Aus diesem Grund sieht ASF, dass es frei ist den Prozess fortzusetzen, was es tut, und das wirft Sie aus dem Steam-Netzwerk, da Steam plötzlich erkennt, dass das Konto an einem anderen Ort verwendet wird.

Ein zweiter Grund kann auftreten, wenn Sie auf Ihrem PC spielen, während ASF wartet (besonders auf einem anderen Computer) und Sie Ihre Netzwerkverbindung verlieren. In diesem Fall markiert Sie das Steam-Netzwerk als offline und gibt die Spielsperre (wie oben) frei, was ASF (z. B. auf einer anderen Maschine) dazu veranlasst, das Sammeln wieder aufzunehmen. Wenn Ihr PC wieder online ist, kann Steam keine Spielsperre mehr erfassen (die jetzt von ASF gehalten wird, ebenfalls ähnlich wie oben) und zeigt die gleiche Meldung an.

Die beiden Ursachen auf der ASF-Seite sind eigentlich sehr schwer zu beheben, da ASF das Sammeln einfach wieder aufnimmt, sobald das Steam-Netzwerk es darüber informiert, dass das Konto wieder frei verwendet werden kann. Das ist es, was normalerweise passiert, wenn Sie das Spiel schließen, aber bei defekten Paketen kann dies sofort passieren, auch wenn Ihr Spiel noch läuft. ASF hat keine Möglichkeit zu wissen, ob Sie die Verbindung getrennt haben, aufgehörten ein Spiel zu spielen oder ob Sie immer noch ein Spiel spielen, das die Sperre nicht ordnungsgemäß hält.

Die einzig richtige Lösung für dieses Problem ist, Ihren Bot mit `pause` manuell zu pausieren und ihn mit `resume` wieder zu starten, sobald Sie fertig sind. Alternativ können Sie das Problem einfach ignorieren und sich genauso verhalten, als ob Sie mit dem Steam-Client offline spielen würden.

---

### `Von Steam getrennt!` - Ich kann keine Verbindung zu den Steam-Servern herstellen.

ASF kann nur **versuchen** eine Verbindung mit den Steam-Servern herzustellen, und es kann aus vielen Gründen fehlschlagen; einschließlich fehlender Internetverbindung, Steam ist ausgefallen, Ihre Firewall blockiert die Verbindung, Programme von Drittanbietern, falsch konfigurierte Routen oder temporäre Ausfälle. Sie können den `Debug`-Modus aktivieren, um ein ausführlicheres Protokoll mit genauen Fehlerursachen zu erhalten, obwohl es normalerweise einfach durch Ihre eigenen Aktionen verursacht wird, wie z. B. die Verwendung von "CS:GO MM Server Picker", das viele Steam-IPs auf eine schwarze Liste setzt, was es für Sie sehr schwierig macht, tatsächlich das Steam-Netzwerk zu erreichen.

ASF wird sein Bestes tun, um eine Verbindung herzustellen, was nicht nur die Abfrage nach der aktualisierten Liste der Server beinhaltet, sondern auch den Versuch einer anderen IP, wenn die letzte fehlschlägt. Wenn es also wirklich ein temporäres Problem mit einem bestimmten Server oder einer bestimmten Route ist, wird ASF früher oder später eine Verbindung herstellen. Wenn Sie sich jedoch hinter der Firewall befinden oder auf andere Weise nicht in der Lage sind, die Steam-Server zu erreichen, dann müssen Sie es natürlich selbst reparieren, mit Hilfe des `Debug`-Modus.

Es ist auch möglich, dass Ihre Maschine nicht in der Lage ist, eine Verbindung mit den Steam-Servern über das Standardprotokoll in ASF herzustellen. Sie können Protokolle, die ASF verwenden darf, ändern, indem Sie `SteamProtocols` globale Konfigurationseigenschaft ändern. Wenn Sie zum Beispiel Probleme haben, Steam mit dem `UDP` Protokoll zu erreichen (z. B. Aufgrund Firewalls), dann können Sie `TCP` oder `WebSocket` versuchen.

In einer sehr unwahrscheinlichen Situation, in der falsche Server zwischengespeichert werden, z. B. weil ASF `config` Ordner von einem Gerät auf eine andere Maschine in einem völlig anderen Land verschoben wurde, könnte das Löschen von `ASF.db` helfen, um die Steam-Server beim nächsten Start zu aktualisieren. Sehr oft ist es nicht notwendig und muss auch nicht getan werden, da diese Liste beim ersten Start und beim Verbindungsaufbau automatisch aktualisiert wird - wir erwähnen sie nur als eine Möglichkeit, um alles zu bereinigen, was mit der Liste der Steam-Server zusammenhängt, die von ASF im Zwischenspeicher gehalten werden.

---

### `Konnte Abzeicheninformation nicht abfragen, wir versuchen es später erneut!`

Normalerweise bedeutet dies, dass Sie die Steam-Familienansicht-PIN verwenden, um auf das Konto zuzugreifen, aber Sie haben trotzdem vergessen, es in der ASF-Konfiguration anzugeben. Sie müssen eine gültige PIN in die Bot-Konfigurationsvariable `SteamParentalCode` eingeben, sonst kann ASF nicht auf die meisten Webinhalte zugreifen und somit nicht richtig funktionieren. Schauen Sie unter **[Konfiguration](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-de-DE)** nach, um mehr über `SteamParentalCode` zu erfahren.

Andere Gründe können temporäre Steam-Probleme, Netzwerkprobleme oder ähnliches sein. Wenn sich das Problem nach mehreren Stunden nicht beheben lässt und Sie sicher sind, dass Sie ASF richtig konfiguriert haben, können Sie uns gerne darüber informieren.

---

### ASF schlägt mit dem Fehler `Request failed after 5 tries` fehl!

Normalerweise bedeutet dies, dass Sie die Steam-Familienansicht-PIN verwenden, um auf das Konto zuzugreifen, aber Sie haben trotzdem vergessen, es in der ASF-Konfiguration anzugeben. Sie müssen eine gültige PIN in die Bot-Konfigurationsvariable `SteamParentalCode` eingeben, sonst kann ASF nicht auf die meisten Webinhalte zugreifen und somit nicht richtig funktionieren. Schauen Sie unter **[Konfiguration](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-de-DE)** nach, um mehr über `SteamParentalCode` zu erfahren.

Wenn die Familienansicht-PIN nicht der Grund dafür ist, dann ist dies ein häufiger Fehler, und Sie sollten sich daran gewöhnen, bedeutet das einfach, dass ASF eine Anfrage an das Steam-Netzwerk gesendet hat und keine gültige Antwort erhalten hat, 5× in Folge. Normalerweise bedeutet es, dass Steam entweder außer Betrieb ist oder einige Schwierigkeiten oder Wartungsarbeiten hat - ASF ist sich solcher Probleme bewusst und Sie sollten sich keine Sorgen um sie machen, es sei denn, sie passieren ständig für mehr als mehrere Stunden, und andere Benutzer haben keine derartigen Probleme.

Wie kann man überprüfen, ob Steam außer Betrieb ist? **[Steam Status](https://steamstat.us)** ist eine ausgezeichnete Quelle, um zu überprüfen, **ob** Steam in Betrieb sein sollte. Wenn Sie Fehler (insbesondere im Zusammenhang mit der Community oder der Web-API) bemerken, dann hat Steam Schwierigkeiten. Sie können entweder ASF in Ruhe lassen, sodass es die Aufgaben nach einer kurzen Auszeit erledigt, oder Sie beenden ASF und warten einfach selbst.

Das ist jedoch nicht immer der Fall, da in einigen Situationen Steam-Probleme möglicherweise nicht durch Steam Status erkannt werden, z. B. passierte ein solcher Fall, als Valve die HTTPS-Unterstützung für Steam Community am 7. Juni 2016 unterbrach - der Zugriff auf **[SteamCommunity](https://steamcommunity.com)** durch HTTPS verursachte einen Fehler. Verlassen Sie sich daher auch nicht blind auf den Steam Status, am besten überprüfe selbst, ob alles so funktioniert, wie es sollte.

Darüber hinaus beinhaltet Steam verschiedene Maßnahmen zur Ratenbegrenzung, die Ihre IP vorübergehend sperren, wenn Sie übermäßig viele Anfragen auf einmal stellen. ASF ist sich dessen bewusst und bietet Ihnen in der Konfiguration mehrere verschiedene Beschränkungen an, die Sie nutzen sollten. Die Standardeinstellungen wurden auf Basis von **einer gesunden** Anzahl der Bots angepasst. Wenn Sie so viele verwenden, dass sogar Steam Ihnen sagt, Sie sollen weggehen, dann optimieren Sie sie entweder, bis diese Meldung nicht mehr erscheint, oder Sie tun, was man Ihnen sagt. Ich nehme an, dass der zweite Weg keine Option für Sie ist, also lese Sie bitte mehr zu diesem Thema und achten Sie besonders auf `WebLimiterDelay`, der eine allgemeine Beschränkung ist, der für alle Web-Anfragen gilt.

Es gibt keine "goldene Regel", die für jeden funktioniert, denn Sperren werden stark von Faktoren Dritter beeinflusst, deshalb muss man selbst experimentieren und einen Wert finden, der für einen funktioniert. Sie können das auch ignorieren und einen Wert wie `10000` verwenden, was garantiert korrekt funktioniert, aber dann beschweren Sie sich nicht, dass Ihr ASF auf alles innerhalb von 10 Sekunden reagiert und wie das Parsen von Abzeichen 5 Minuten dauert. Darüber hinaus ist es durchaus möglich, dass keine Beschränkung greift, weil Sie so viele Bots haben, dass Sie die **[Obergrenze](#wie-viele-bots-kann-ich-mit-asf-verwenden)** erreicht haben (wie oben erwähnt). Es ist sogar möglich, dass Sie sich ohne Probleme im Steam-Netzwerk (Client) anmelden können, aber Steam Web (Webseite) sich schlicht weigert Ihnen zuzuhören, sollten Sie mehr als 100 Sitzungen gleichzeitig etabliert haben. ASF verlangt, dass sowohl das Steam-Netzwerk,als auch das Steam-Web kooperativ sind. Wenn nur eines von beiden nicht funktioniert kann es zu Problemen kommen, von denen Sie sich nicht erholen werden.

Wenn nichts hilft und Sie keine Ahnung haben, was kaputt ist, können Sie immer den `Debug`-Modus aktivieren und Ihnen im ASF-Log selbst ansehen warum genau die Anfragen fehlschlagen. Zum Beispiel:

```text
InternalRequest() HEAD https://steamcommunity.com/my/edit/settings
InternalRequest() Forbidden <- HEAD https://steamcommunity.com/my/edit/settings
```

Sehen Sie das `Forbidden`? Das bedeutet, dass Sie vorübergehend für übermäßig viele Anfragen gesperrt wurden, weil Sie `WebLimiterDelay` noch nicht richtig angepasst haben (vorausgesetzt, Sie bekommen den gleichen Fehlercode auch für alle anderen Anfragen). Es kann noch weitere Gründe geben, wie z. B. `InternalServerError`, `ServiceUnavailable` und Timeouts, die auf Steam Wartungsarbeiten und Probleme hinweisen. Sie können immer versuchen, den von ASF erwähnten Link selbst zu besuchen und zu überprüfen, ob er funktioniert - wenn nicht, dann wissen Sie, warum ASF auch nicht darauf zugreifen kann. Wenn dies der Fall ist und der gleiche Fehler nach ein oder zwei Tagen nicht verschwindet, könnte es sich lohnen, ihn zu untersuchen und zu melden.

Bevor Sie das tun,**sollten Sie sich vergewissern, dass der Fehler überhaupt einen Bericht wert ist**. Wenn es in diesem FAQ erwähnt wird, wie z. B. handelsbedingte Probleme, dann ist das nicht der Fall. Wenn es sich um ein temporäres Problem handelt, das ein- oder zweimal auftrat, insbesondere wenn Ihr Netzwerk instabil war oder Steam ausgefallen ist - dann ist das nicht der Fall. Wenn Sie jedoch in der Lage waren, Ihr Problem mehrmals hintereinander, über 2 Tage, zu reproduzieren, ASF sowie Ihr Gerät im Prozess neu zu starten und sicherzustellen, dass es hier keinen FAQ-Eintrag gibt, der Ihnen hilft, es zu lösen, dann könnte es sich lohnen, nach ihm zu fragen.

---

### ASF scheint einzufrieren und gibt nichts auf der Konsole aus, bis ich eine Taste drücke!

Sie benutzen höchstwahrscheinlich Windows und Ihre Konsole hat den QuickEdit-Modus aktiviert. In **[dieser](https://stackoverflow.com/questions/30418886/how-and-why-does-quickedit-mode-in-command-prompt-freeze-applications)** Frage im StackOverflow gibt es dazu eine technische Erklärung. Sie sollten den QuickEdit-Modus deaktivieren, indem Sie mit der rechten Maustaste auf das ASF-Konsolenfenster klicken, die Eigenschaften öffnen und das entsprechende Kontrollkästchen deaktivieren.

---

### ASF kann keine Handelsangebote akzeptieren oder versenden!

Offensichtliche Sache zuerst - neue Konten beginnen eingeschränkt. Bis Sie das Konto freischalten, indem Sie dessen Guthaben aufladen oder 5€ im Shop ausgeben, kann ASF weder Handelsangebote akzeptieren noch über dieses Konto versenden. In diesem Fall gibt ASF an, dass das Inventar leer ist, da jede Karte, die sich darin befindet, nicht handelbar ist.

Als nächstes, wenn Sie **[ASF-2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication-de-DE)** nicht verwenden, ist es möglich, dass ASF tatsächlich das Handelsangebot akzeptiert/sendet, aber Sie müssen es per E-Mail bestätigen. Ebenso müssen Sie, wenn Sie die klassische 2FA verwenden, das Handelsangebot über Ihren Authentifikator bestätigen. Bestätigungen sind jetzt **obligatorisch**, also wenn Sie sie nicht selbst akzeptieren möchten, erwägen Sie Ihren Authentifikator in ASF-2FA zu importieren.

Beachten Sie auch, dass Sie nur mit Ihren Freunden und Personen mit bekanntem Handelslink handeln können. Sollten Sie versuchen, ein Handelsangebot *Bot ->Master* zu veranlassen (z. B. mit `loot`); dann müssen Sie entweder den Bot auf Ihrer Freundesliste haben oder Ihr `SteamTradeToken` in der Bot-Konfiguration angegeben. Stellen Sie sicher, dass der Code gültig ist - sonst ist das Senden von Handelsangebote nicht möglich. Vergewissern Sie sich, dass das Token gültig ist - andernfalls können Sie keinen Handel versenden.

Abschließend sollten Sie daran denken, dass neue Geräte eine 7-Tage-Handelssperre haben. Wenn Sie also gerade Ihr Konto zu ASF hinzugefügt haben, warten Sie mindestens 7 Tage - alles sollte nach diesem Zeitraum funktionieren. Diese Einschränkung beinhaltet **sowohl** die Annahme von Handelsangeboten, als **auch** das Versenden von Handelsangeboten. Es wird nicht immer ausgelöst, und es gibt Leute, die sofort Handelsangebote senden und annehmen können. Die Mehrheit der Personen sind jedoch betroffen, und die Verriegelung **wird** passieren, auch wenn Sie Handelsangebote über Ihren Steam-Client auf dem gleichen Gerät senden und annehmen können. Warten Sie einfach geduldig, es gibt nichts, was Sie tun können, um es zu beschleunigen. Ebenso kann es sein, dass Sie eine ähnliche Sperre für das Entfernen/Ändern verschiedener sicherheitsrelevanter Einstellungen von Steam erhalten, wie z. B. 2FA, SteamGuard, Passwort, E-Mail und ähnliches. Im Allgemeinen sollten Sie überprüfen, ob Sie ein Handelsangebot von diesem Konto aus selbst versenden können. Wenn ja, dann ist es sehr wahrscheinlich, dass es sich um eine klassische 7-Tage-Sperre von einem neuen Gerät handelt.

Und schließlich, bedenken Sie, dass ein Konto nur fünf ausstehende Handelsangebote zu einem anderen haben kann, sodass ASF keine Handelsangebote senden kann, wenn Sie bereits fünf (oder mehr) ausstehende Handelsangebote von diesem einen Bot haben. Dies ist selten ein Problem, aber es ist auch erwähnenswert, besonders wenn Sie ASF auf automatisches Senden von Handelsangeboten einstellen, aber Sie benutzen ASF-2FA nicht und haben vergessen, sie tatsächlich zu bestätigen.

Wenn nichts geholfen hat, können Sie jederzeit den `Debug` Modus aktivieren und selbst überprüfen, warum Anfragen fehlschlagen. Bitte bedenken Sie, dass Steam die meiste Zeit Unsinn redet, und vorausgesetzt, dass der Grund keinen logischen Sinn ergibt oder sogar völlig falsch ist - wenn Sie sich entscheidest, diesen Grund zu interpretieren, stellen Sie sicher, dass Sie ein angemessenes Wissen über Steam und seine Besonderheiten haben. Es ist auch durchaus üblich, dieses Problem ohne logischen Grund zu sehen, und die einzige vorgeschlagene Lösung in diesem Fall ist, das Konto erneut zu ASF hinzuzufügen (und wieder 7 Tage zu warten). Manchmal behebt sich dieses Problem auf *magische* Weise, genauso wie es auch kaputt geht. Allerdings ist es in der Regel nur entweder 7-Tage Handelssperre, temporäres Steam-Problem oder beides. Es ist am besten, ihm ein paar Tage vor der manuellen Überprüfung zu geben, was falsch ist, es sei denn, Sie haben den Drang, die wahre Ursache zu finden (und normalerweise werden Sie gezwungen sein, trotzdem zu warten, weil Fehlermeldungen keinen Sinn ergeben und Ihnen auch nicht im Geringsten helfen).

In jedem Fall kann ASF nur **versuchen**, eine ordnungsgemäße Anfrage an Steam zu senden, um das Handelsangebot anzunehmen/senden. Ob Steam diese Anfrage annimmt oder nicht, liegt außerhalb des Anwendungsbereichs von ASF, und ASF wird es nicht auf magische Weise zum Funktionieren bringen. Es gibt keinen Fehler im Zusammenhang mit dieser Funktion, und es gibt auch nichts zu verbessern, da die Logik außerhalb von ASF stattfindet. Deshalb, bitten Sie nicht um die Behebung von Dingen, die nicht kaputt sind, und fragen Sie auch nicht, warum ASF keine Handelsangebote annehmen oder senden kann - **Ich weiß es nicht, und ASF weiß es auch nicht**. Leben Sie damit, oder beheben Sie es selbst, wenn Sie es besser wissen.

---

### Warum muss ich bei der Anmeldung jedesmal den 2FA/SteamGuard-Code eingeben? / *Abgelaufener Anmeldeschlüssel entfernt*

ASF verwendet Anmeldeschlüssel (wenn Sie `UseLoginKeys` aktiviert haben), um die Anmeldeinformationen gültig zu halten, den gleichen Mechanismus, den Steam verwendet - 2FA/SteamGuard-Code ist nur einmal erforderlich. Aufgrund von Steam-Netzwerkproblemen und -Eigenarten ist es jedoch durchaus möglich, dass der Anmelde-Schlüssel nicht im Netzwerk gespeichert ist. Wir haben solche Probleme bereits nicht nur mit ASF, sondern auch mit dem normalen Steam-Client gesehen (eine Notwendigkeit, bei jedem Durchlauf Login + Passwort einzugeben, unabhängig von der Option "Angemeldet bleiben").

Sie könnten (falls vorhanden) `BotName.db` und `BotName.bin` des betroffenen Kontos entfernen und versuchen, ASF wieder mit Ihrem Konto zu verbinden, aber das ändert vermutlich nichts. Einige Benutzer haben berichtet, dass das Deautorisieren **[aller Geräte](https://store.steampowered.com/twofactor/manage)** auf Steam helfen sollte, da das Ändern des Passworts dasselbe tut. Wie auch immer - dies sind nur einige Problemumgehungsversuche, die jedoch keine Erfolgsgarantie mit sich bringen. Die eigentliche ASF-basierte Lösung besteht darin, den Authentifikator als **[ASF-2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication-de-DE)** zu importieren - so kann ASF Codes automatisch generieren, wenn sie benötigt werden, undSiemüssen sie nicht manuell eingeben. In der Regel löst sich das Problem nach einiger Zeit von selbst, sodass man es einfach abwarten kann. Natürlich können Sie auch Valve nach einer Lösung fragen, denn ich kann das Steam-Netzwerk nicht zwingen, unsere Login-Schlüssel zu akzeptieren.

Als Randbemerkung können Sie auch die Anmeldeschlüssel mit `UseLoginKeys` Konfigurationseigenschaft auf `false` deaktivieren, aber das wird das Problem nicht lösen, sondern nur den Fehler des ersten Anmeldeschlüssels überspringen. ASF ist sich des hier erläuterten Problems bereits bewusst und wird versuchen, keine Anmeldeschlüssel zu verwenden, wenn es sich selbst alle Anmeldeinformationen zuschicken kann, sodass es nicht notwendig ist, `UseLoginKeys` manuell zu optimieren, wenn Sie alle Zugangsdaten zusammen mit ASF-2FA angeben können.

---

### Ich erhalte den Fehler: *Die Anmeldung bei Steam ist nicht möglich: `InvalidPassword` oder `RateLimitExceeded`*

Dieser Fehler kann vieles bedeuten, unter anderem auch:

- Ungültige Login/Passwort-Kombination (offensichtlich)
- Abgelaufener Anmeldeschlüssel, der von ASF für die Anmeldung verwendet wird
- Zu viele fehlgeschlagene Anmeldeversuche in kurzer Zeit (Anti-Bruteforce)
- Zu viele Anmeldeversuche in kurzer Zeit (Rate-Limiting/ Anfragelimit)
- Erfordernis eines Captcha zum Anmelden (sehr wahrscheinlich durch die beiden obigen Gründe verursacht)
- Alle anderen Gründe, die das Steam-Netzwerk daran hindern könnten, sich anzumelden

Im Falle von Anti-Bruteforce und Rate-Limiting wird das Problem nach einiger Zeit verschwinden, also warten einfach und versuchen Sie sich in der Zwischenzeit nicht anzumelden. Wenn Sie dieses Problem häufiger haben, ist es vielleicht ratsam, `LoginLimiterDelay` Konfigurationseigenschaft von ASF zu erhöhen. Übermäßige Programmneustarts und andere absichtliche/nicht absichtliche Anmeldeanforderungen werden bei diesem Problem definitiv nicht helfen, also vermeiden Sie es, wenn möglich.

Im Falle eines abgelaufenen Anmeldeschlüssels wird ASF den alten entfernen und beim nächsten Anmelden nach einem neuen fragen (was erfordert, dass Sie einen 2FA-Code setzt, wenn Ihr Konto 2FA-geschützt ist). Wenn Ihr Konto ASF-2FA verwendet, wird ein Code generiert und automatisch verwendet. Dies kann natürlich mit der Zeit geschehen, aber wenn dieses Problem bei jedem Login auftritt, ist es möglich, dass Steam aus irgendeinem Grund beschlossen hat, unsere Login-Schlüssel zu ignorieren, wie im Punkt **[oben](#warum-muss-ich-bei-der-anmeldung-jedesmal-den-2fasteamguard-code-eingeben--abgelaufener-anmelde-schl%C3%BCssel-entfernt)** erwähnt. Sie können natürlich `UseLoginKeys` komplett deaktivieren, aber das löst das Problem nicht, sondern vermeidet nur, dass jedes mal abgelaufene Login Schlüssel entfernt werden müssen. Die wirkliche Lösung besteht darin, wie im Punkt oben erwähnt, ASF-2FA zu verwenden.

Und schlussendlich, wenn Sie eine falsche Kombination aus Login und Passwort verwendet haben, müssen Sie dies natürlich korrigieren oder den Bot deaktivieren, der versucht, sich mit diesen Zugangsdaten zu verbinden. ASF kann nicht von selbst erraten, ob `InvalidPassword` ungültige Anmeldeinformationen bedeutet, oder einen der oben genannten Gründe, daher wird es weiter versuchen, bis es erfolgreich ist.

Bedenken Sie, dass ASF über ein eigenes eingebautes System verfügt, um entsprechend auf Steam-Macken zu reagieren, irgendwann wird es sich verbinden und seine Arbeit wieder aufnehmen. Daher ist es nicht erforderlich, etwas zu tun, wenn das Problem vorübergehend ist. Ein Neustart von ASF, um Probleme magisch zu beheben, wird die Situation nur verschlimmern (da das neue ASF den vorherigen ASF-Zustand nicht kennt, dass es sich nicht anmelden kann, und versucht, eine Verbindung herzustellen, anstatt zu warten), also sollten Sie dies unterlassen, es sei denn, Sie wissen, was Sie tun.

Abschließend kann sich ASF, wie bei jeder Steam-Anfrage, nur **versuchen** mit den von Ihnen angegebenen Zugangsdaten anmelden. Ob diese Anforderung erfolgreich ist oder nicht, liegt außerhalb des Umfangs und der Logik von ASF - es gibt keinen Fehler, und in dieser Hinsicht kann nichts behoben oder verbessert werden.

---

### `System.IO.IOException: Input/output error`

Wenn dieser Fehler während der ASF-Eingabe aufgetreten ist (z. B. wenn Sie `Console.ReadLine()` im Stacktrace sehen können), dann wird er durch Ihre Umgebung verursacht, die es ASF verbietet, die Standardeingabe Ihrer Konsole zu lesen. Das kann aus vielen Gründen passieren, aber der häufigste ist, dass Sie ASF in der falschen Umgebung verwenden (z. B. in `nohup` oder `&` Hintergrund anstelle von `screen` unter Linux). Wenn ASF nicht auf die Standardeingabe zugreifen kann, wird dieser Fehler protokolliert und ASF kann Ihre Daten während der Ausführung nicht verwenden.

Wenn Sie **erwarten**, dass dies geschieht, dann **möchten** Sie ASF in einer eingabefreien Umgebung ausführen; daher sollten Sie ASF ausdrücklich sagen, dass dies der Fall ist, indem Sie den **[`Headless`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-de-DE#headless)**-Modus entsprechend einstellen. Um für Sie ein sicheres Ausführen in eingabefreien Umgebungen zu gewährleisten, wird ASF damit angehalten, niemals nach weiteren Benutzereingaben zu fragen.

---

### `System.Net.Http.WinHttpException: A security error occurred`

Dieser Fehler tritt auf, wenn ASF keine sichere Verbindung mit dem angegebenen Server herstellen kann, fast ausschließlich wegen des Misstrauens gegen ein SSL-Zertifikat.

In fast allen Fällen wird dieser Fehler durch ein **falsches Datum/Uhrzeit auf Ihrem Gerät** verursacht. Jedes SSL-Zertifikat hat ein Ausstellungsdatum und ein Verfallsdatum. Wenn Ihr Datum ungültig ist und sich außerhalb dieser beiden Grenzen befindet, kann dem Zertifikat nicht als potentieller **[MITM](https://de.m.wikipedia.org/wiki/Man-in-the-Middle-Angriff)**-Angriff vertraut werden, weshalb ASF sich weigert, eine Verbindung herzustellen.

Eine offensichtliche Lösung ist das Datum auf Ihrer Maschine entsprechend einzustellen. Es wird dringend empfohlen, eine automatische Datumssynchronisation zu verwenden, wie z. B. die unter Windows verfügbare native Synchronisation oder `ntpd` unter Linux.

Sobald Sie sich sicher sind, dass das Datum auf Ihrem Gerät korrekt ist und der Fehler nicht verschwinden will, dann könnten SSL-Zertifikate, denen Ihr System vertraut, veraltet oder ungültig sein. In diesem Fall sollten Sie sicherstellen, dass Ihr Gerät sichere Verbindungen herstellen kann, z. B. indem Sie über einen beliebigen Browser oder mit einem CLI-Tool wie `curl` überprüfen, ob Sie auf `https://github.com` zugreifen können. Wenn Sie bestätigt haben, dass dies ordnungsgemäß funktioniert, können Sie das Problem gerne in unserer Steam-Gruppe melden.

---

### `System.Threading.Tasks.TaskCanceledException: A task was canceled`

Diese Warnung bedeutet, dass Steam nicht innerhalb einer bestimmten Zeit auf die ASF-Anfrage geantwortet hat. Normalerweise wird dies durch Steam-Netzwerkproblemen verursacht und hat keine Auswirkung auf ASF. In manchen Fällen ist es das gleiche, als wenn die Anfrage nach fünf Versuchen fehlschlägt. Die Meldung dieses Problems ergibt meistens keinen Sinn, da wir Steam nicht zwingen können, auf unsere Anfragen zu reagieren.

---

### `The type initializer for 'System.Security.Cryptography.CngKeyLite' threw an exception`

Dieses Problem wird fast ausschließlich durch einem deaktivierten/gestoppten `CNG Key Isolation`-Windows-Dienst, die ASF Kernkryptografiie-Funktionalität bietet, ohne dessen das Programm nicht ausführbar ist. Sie können dieses Problem beheben, indem Sie `services.msc` starten und sicherstellen, dass Windows den Dienst `CNG Key Isolation` nicht deaktiviert hat und derzeit ausgeführt wird.

---

### ASF wird von meinem AntiVirus als Schadsoftware erkannt! Was ist hier los?

**Stellen Sie sicher, dass Sie ASF von einer vertrauenswürdigen Quelle heruntergeladen haben**. Die einzige offizielle und vertrauenswürdige Quelle ist die Seite **[ASF-Veröffentlichungen](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** auf GitHub (und das ist auch die Quelle für automatische ASF-Aktualisierungen) - **jede andere Quelle ist per Definition nicht vertrauenswürdig und könnte Schadsoftware enthalten, die von anderen Personen hinzugefügt wurde** - Sie sollten keiner anderen Quelle per Definition vertrauen und sicherstellen, dass Ihr ASF immer von uns stammt.

Wenn Sie überprüft haben, dass ASF von einer vertrauenswürdigen Quelle heruntergeladen wurde, dann ist es höchstwahrscheinlich nur ein Fehlalarm. Dies **passierte in der Vergangenheit**, **passiert gerade jetzt**, und **wird auch in der Zukunft passieren**. Wenn Sie sich um die tatsächliche Sicherheit bei der Verwendung von ASF Sorgen machen, dann schlage ich vor, ASF mit vielen verschiedenen AVs nach der tatsächlichen Erkennungsrate zu scannen, zum Beispiel durch **[VirusTotal](https://www.virustotal.com)** (oder einem anderen Webdienst Ihrer Wahl).

Wenn die von Ihnen verwendete AV-Software ASF fälschlicherweise als Schadsoftware erkennt, dann **ist es eine gute Idee, dieses Dateibeispiel an die Entwickler Ihrer AV-Software zu senden, damit sie es analysieren und Ihre Erkennungsmaschine verbessern können**, da sie offensichtlich nicht so gut funktioniert, wie Sie denken. Es gibt kein Sicherheitsproblem im ASF-Code, und es gibt auch nichts zu beheben, da wir keine Schadsoftware verteilen. Daher ergibt es auch keinen Sinn uns diese Fehlalarme zu melden. Wir empfehlen dringend, ASF-Beispiele für weitere Analysen wie oben erläutert zu versenden, aber wenn Sie sich nicht darum kümmern möchten, dann können Sie ASF immer zu den AV-Ausnahmen hinzufügen, Ihre AV-Software deaktivieren oder einfach eine andere verwenden. Leider sind wir es gewohnt, dass AV-Programme dumm sind, da ab und zu einige AV-Programme ASF als Virus erkennen, was normalerweise sehr kurz andauert und schnell von den Entwicklern ausgebessert wird, aber wie wir oben erwähnt haben - **es passierte**, **passiert** und **wird immer passieren**. ASF enthält keinen schädlichen Code, Sie können ASF-Code überprüfen und sogar den Quellcode selbst kompilieren. Wir sind keine Hacker die den ASF-Code verschleiern, um sich vor AV-Heuristiken und Fehlalarmen zu verstecken, also erwarten Sie nicht von uns, dass wir reparieren, was nicht kaputt ist - es gibt keinen "Virus", den wir beseitigen können.