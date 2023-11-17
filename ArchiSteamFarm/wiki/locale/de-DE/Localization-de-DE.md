# Lokalisierung

ASF wird von dem Dienst Crowdin unterstützt, wodurch es jedem ermöglicht wird ASF in alle weltweit gesprochenen Sprachen zu übersetzen. Für eine detailliertere Erklärung wie Crowdin funktioniert lies dir bitte die **[Einführung in Crowdin](https://support.crowdin.com/crowdin-intro)** durch.

Wenn Du daran interessiert bist, was zur Zeit vor sich geht, kannst Du die **[aktuellen ASF Crowdin Aktivitäten](https://crowdin.com/project/archisteamfarm/activity_stream)** ansehen.

---

## Umfang

Unsere Plattform unterstützt die Lokalisierung unseres ASF-Hauptprogramms sowie aller lokalisierbaren Inhalte, die wir zusammen mit diesem anbieten. Dies beinhaltet insbesondere unseren ASF-WebConfigGenerator, ASF-UI sowie auch das Wiki selbst. All das kann man bequem durch das Crowdin-Interface übersetzen.

---

## Anmeldung

Wenn Du bei der Arbeit an ASF helfen möchtest, entweder durch Übersetzen, Überprüfen oder Genehmigen von Übersetzungen, melde dich bitte auf unserer **[Crowdin-Projektseite](https://crowdin.com/project/archisteamfarm)** an. Die Registrierung ist einfach und absolut kostenlos! Nach dem Einloggen kannst Du Sprachen auswählen, denen Du gern zugewiesen werden möchtest und anschließend zu den ASF-Zeichenketten gehen und dem Rest der Community helfen, ASF in alle gängigen Sprachen zu übersetzen!

---

### Übersetzen

Wenn der Sprache ihrer Wahl noch einige Zeichenketten fehlen, kannst Du sie ihren schnappen und mit der Übersetzung beginnen. Wir haben versucht, unser Bestes in Bezug auf die Flexibilität der Übersetzungen zu geben, daher enthalten viele Zeichenketten zusätzliche Variablen, die ASF während der Laufzeit bereitstellen wird - diese sind in Klammern mit einer Zahl eingeschlossen, wie z. B. `{0}`. Dies ermöglicht es dir, das Standard-ASF-Format der Zeichenkette zu ändern, z. B. indem Du die von ASF bereitgestellte Variable an einen Ort verschiebst, der ihrer Sprache und ihrer Übersetzung entspricht, anstatt in einen strengen Zusammenhang und Format gezwungen zu werden. Das ist besonders wichtig in Sprachen wie Hebräisch, die von rechts nach links gelesen werden.

Zum Beispiel könntest Du folgende Zeichenkette haben:

> Wir haben {0} Spiele zu Sammeln.

Aber basierend auf ihrer Sprache könnte folgender Satz mehr Sinn machen:

> Die Anzahl der Spiele die zu sammeln sind ist equivalent zu {0}.

Oder:

> {0} ist die Anzahl der Spiele, die wir sammeln können.

Diese Flexibilität wird speziell für Sie bereitgestellt, sodass Sie den ASF-Satz leicht umformulieren können, um ihn besser an eine Sprache anzupassen und die von ASF bereitgestellte Nummer oder andere Informationen an einen Ort zu verschieben, der zu der Übersetzung passt (anstatt jeden Teil unabhängig zu übersetzen). Das Verbessert die allgemeine Übersetzungsqualität.

---

### Überprüfung

Wenn ihre Zeichenkette bereits von jemand anderem übersetzt wurde, kannst Du dafür stimmen. Stimmen macht es möglich die beste Variante einer Übersetzung auszusuchen, anstatt an einem ursprünglichen Vorschlag festzuhalten - Das Verbessert die Qualität der Übersetzungen weiter. Sie können für bereits verfügbare Vorschläge stimmen oder ihren eigenen Vorschlag der Übersetzung hinzufügen, der durch den selben Prozess gehen wird. Schlussendlich wird ein endgültiger Wert gewählt, basierend auf dem Vorschlag mit den meisten Stimmen oder als Wahl eines Korrekturlesers, der für diese Sprache ausgewählt wurde, der die gegebene Übersetzung persönlich genehmigt (unter Anderem basierend auf ihren Stimmen).

**Du brauchst keine Genehmigung um deine Übersetzungen in ASF zu sehen**. Genehmigung heißt einfach, dass jemand dem wir vertrauen ihren Beitrag angesehen und für gut befunden hat. Es ist in Ordnung, nicht genehmigte Übersetzungen, die von der Community gemacht wurden zu haben, wo Du für die Beste Version stimmst. So lange es übersetzt ist, ist es in Ordnung! Wenn Du denkst, dass die aktuelle Übersetzung schlecht ist, kannst Du gerne jederzeit für eine bessere stimmen oder selbst eine vorschlagen.

---

### Korrekturlesen

Es ist eine gute Idee eine konsistente Übersetzung zu haben, selbst, wenn es möglicherweise die Freiheiten der oben erklärten Community-Rezensierung oder des Stimmprozesses einschränken könnte. Das ist hauptsächlich weil falsche Übersetzungen, die nicht notwendigerweise schlecht sind, so viele Stimmen bekommen könnten, dass es nicht möglich ist eine bessere Übersetzung vorzuschlagen, selbst, wenn diese jemand hat.

Wenn Du bereits in der Vergangenheit Beiträge auf Crowdin oder einer anderen Übersetzungsplattform übersetzt hast, die wir verifizieren und vertrauensvoll nennen können, würden wir uns freuen, ihren Korrekturleser-Zugriff zu der Sprache zu geben, die Du übersetzt, damit es ihren möglich ist gegebene Übersetzungen zu genehmigen oder konsistenter zu gestalten. Korrekturlesen ist keine einfache Aufgabe, besonders, weil ASF von Zeit zu Zeit sehr "technisch" und schwer zu übersetzen sein kann, aber wir verstehen, dass es für eine perfekte Übersetzung oft nötig ist. Wenn Du uns helfen kannst eine Sprache Korrektur zu lesen, bitten wir dich: **[Gib uns Bescheid](https://crowdin.com/messages/create/13177432/240376)**, bedenke aber, dass Du ihre Anfrage mit vergangenen Beiträgen, die wir verifizieren können (etwa bei ASF oder anderen Projekten auf Crowdin zu helfen), stützen musst. Wir könnten auch fortgeschrittenen Benutzern das initiale Korrekturlesen erlauben, wenn wir sie persönlich kennen und sie mit dem Rest der Community kooperieren können um ASF in der gegebenen Sprache bestmöglich zu übersetzen.

Die generellen Regeln gelten auch für das Korrekturlesen - nimm ihren Zeit, hör auf die Benutzer, arbeite als Projektmanager, löse Probleme und stell sicher, dass Du die Dinge besser machst und nicht schlimmer.

---

### Probleme

Wenn Du ein Problem mit einer bestimmten Übersetzung hast, weil Du zum Beispiel nicht weißt, wie sie zu übersetzen ist, eine genehmigte Übersetzung falsch ist, Du mehr Kontext benötigst oder Ähnliches, dann Poste bitte einen Kommentar unter dem betroffenen String und markiere ihn mit [X] als ein Problem.

**Bitte vermeide das [x] wenn Du keine technische Erklärung oder Aktion eines Admins benötigst**. Es steht Ihnen frei, Kommentare für Diskussionen zu verwenden, die sich auf die Übersetzung der gegebenen Zeichenkette beziehen, aber "issue" sollte nur verwendet werden, wenn Sie weitere technische Erklärungen oder Korrekturen durch den Administrator benötigen, und es wird typischerweise jemanden betreffen, der nicht einmal die Sprache spricht, in die Sie übersetzen, also bleiben Sie bitte bei Englisch, wenn Sie mit "issue" kommentieren (damit wir verstehen können, worum es geht).

Es gibt 4 Typen von Problemen, die wir unterstützen:
- generelle Frage - Für alles, was keinen der anderen Typen betrifft. Dieser Typ **sollte vermieden** werden, weil es dann höchstwahrscheinlich **kein** Übersetzungsproblem ist. Trotzdem ist diese Möglichkeit für alle anderen Fälle offen.
- Die aktuelle Übersetzung ist falsch - Dies sollte **nur** verwendet werden, wenn die Übersetzung von einem Korrekturleser genehmigt wurde und Du glaubst, dass sie falsch ist, weil sie etwa einen Tippfehler beinhaltet oder Du einen guten Vorschlag hast sie zu verbessern. Dieser Typ sollte nie bei Übersetzungen verwendet werden, die durch Community-Stimmen gewählt wurden, in welchem Fall Du den Benutzer der die Übersetzung geschrieben hat kontaktieren und ihn um eine Korrektur bitten oder einfach für eine bessere Übersetzung stimmen solltest. Wir entfernen die Freigabe der Übersetzung und benachrichtigen den für die Sprache zuständigen Korrekturleser, um ihren Kommentar zu berücksichtigen und erneut zu überprüfen.
- Fehlender Kontext - Dies ist, was Du verwenden solltest, wenn Du nicht sicher bist, welchen Teil von ASF Du übersetzt und was der Kontext der gegebenen Zeichenkette oder sein Sinn ist. Dieser Typ sollte nur für die Entwicklung von ASF verwendet werden, da er bedeutet, dass Du technische Hilfe benötigst, weil Du nicht sicher bist, wie die Zeichenkette zu übersetzen ist.
- Fehler in der Quell-Zeichenkette - Dies sollte nur verwendet werden, wenn Du denkst, dass das Original (Englisch) falsch ist. Quite rare, but not all of us are speaking English natively either, so feel free to use it if you have a general idea how it could be improved. Da dies eng mit der Entwicklung verbunden ist, können Sie alternativ unsere **[GitHub Issues](https://github.com/JustArchiNET/ArchiSteamFarm/issues/new/choose)** für diesen Zweck verwenden, wenn Sie es wünschen.

---

### Übersetzungsfortschritt

Jede Sprache hat zwei Zustände des Fortschritts - Übersetzung und Korrekturlesen.

Eine Sprache gilt als **übersetzt** wenn ihr Übersetzungsfortschritt 100% erreicht. Zu diesem Zeitpunkt hat jede übersetzbare Zeichenkette die von ASF verwendet wird eine entsprechende Bedeutung, was wunderbar ist. Allerdings heißt das nicht, dass das kein Raum für Verbesserungen lässt - das weitere Stimmen ist durchgehend aktiviert und Du kannst immer noch Vorschläge für bessere Übersetzungen einbringen und für existierende Stimmen. Bitte bedenke, dass bereits fertig übersetzte Sprachen immer noch unter 100% fallen können, wenn wir während der Entwicklung existierende Zeichenketten ändern oder neue hinzufügen. Sie können entsprechende Crowdin-Benachrichtigungen aktivieren, wenn Du in einem solchen Fall eine E-Mail erhalten willst.

Gewählte Sprachen können entsprechende Korrekturleser haben, die Übersetzungen validieren und endgültige Versionen auswählen. Dies ist der letzte Schritt nach der Übersetzung und erlaubt weitere Verbesserungen.

ASF wird die Sprache **so bald wie möglich** beinhalten, was bedeutet, dass sie nicht genehmigt oder zu 100% übersetzt werden muss. Die tatsächlich verwendeten Zeichenketten sind immer die am beliebtesten im Bezug auf Stimmen, außer der gewählte Korrekturleser hat anders entschieden (sehr selten). Daher können Sie sehen, dass ihre Bemühungen bereits im nächsten ASF-Release enthalten sind - unsere automatisierten Systeme pflegen täglich die Übersetzungen von Crowdin im ASF-Verzeichnis ein.

---

## Fehlende Sprachen

Standardmäßig verfügt das ASF-Projekt nur Übersetzungen für die 30 meistgesprochenen Sprachen der Welt. Wenn Du eine weitere (oder einen lokalen Dialekt zu einer existierenden) hinzufügen willst, **[lass es uns bitte wissen](https://crowdin.com/messages/create/13177432/240376)** und wir werden sie schnellstmöglichst hinzufügen. Wir wollen nicht mehrere hundert verschiedene Sprachen, wenn sie keiner übersetzt. Deshalb haben wir sie auf diese Anzahl reduziert. Bitte zögere nicht uns zu kontaktieren, wenn Du eine nicht gelistete Sprache übersetzen willst. Für uns ist es sehr einfach eine weitere hinzuzufügen. Achte einfach darauf, dass Du den tatsächlichen Willen und die Entschlossenheit hast ASF in ihre Sprache zu übersetzen bevor Du dich entscheidest mit uns Kontakt aufzunehmen.

Für eine komplette Liste der verfügbaren Sprachen, in die ASF übersetzt werden kann, **[klicke hier](https://developer.crowdin.com/language-codes)**.

---

## Pluralisierung

Jede Sprache hat ihre eigenen Regeln in Bezug auf die Pluralisierung. Diese Regeln können Sie auf **[CLDR](https://unicode-org.github.io/cldr-staging/charts/latest/supplemental/language_plural_rules.html)** finden, welche ihre Anzahl und genauen Sprachbedingungen angibt.

Wir tun unser Bestes, um ihren eine flexible Lokalisierung anzubieten, und so lange wie möglich, wird dies auch Regeln für Pluralisierung beinhalten. Als Beispiel werden wir heute folgende Zeichenkette ins Polnische übersetzen:

> Released {PLURAL:n|{n} month|{n} months} ago

`PLURAL` Schlüsselwort wird hier besonders behandelt, da es ihren erlaubt, alle Pluralformen einzubeziehen, die ihre Sprache unterstützt. Wenn Du einen Blick auf CLDR wirfst, wirst Du sehen, dass es im Englischen nur 2 kardinale Formen gibt - "eine" und "andere". Und wie Du oben sehen kannst, haben wir beide definiert - `{n} month` und `{n} months`.

Unsere polnische Sprache umfasst jedoch 4 von Ihnen - "eine", "wenige", "viele" und "andere". Das bedeutet, dass wir alle für die vollständige Umsetzung definieren sollten. Unsere Übersetzungsprogramme sind bereits intelligent genug, um eine geeignete Pluralform basierend auf Sprachregeln auszuwählen, sodass Sie nur alle diese in der Übersetzung definieren müsssen:

> Wydany {PLURAL:n|{n} miesiąc|{n} miesiące|{n} miesięcy|{n} miesiąca} temu

Auf diese Weise haben wir alle 4 Pluralformen für unsere polnische Sprache definiert, und da unsere Lokalisierungsbibliothek bereits die genauen Regeln kennt, wird sie die richtige Form für die angegebene `{n}` Nummer korrekt verwenden.

Es ist nicht zwingend erforderlich alle von ihrer Sprache verwendeten Pluralformen zu definieren. Wenn sie fehlt, verwendet unsere Lokalisierungsbibliothek die zuletzt definierte Form an ihrer Stelle. Es ist eine gute Idee, alle von ihrer Sprache verwendeten Pluralformen zu definieren, aber in einigen Fällen können die verbleibenden Pluralformen die gleichen sein wie die letzten, in diesem Fall ist es nicht notwendig, sie zu wiederholen. In unserem obigen Beispiel war es zwingend erforderlich, da die "andere" Form im Polnischen für Monate "miesiąca" ist und nicht "miesięcy" wie in "vielen".

---

## Wiki

Unsere Crowdin-Plattform ermöglicht es ihren sogar selbst das Wiki zu lokalisieren. Dies ist ein sehr mächtiges Programm, da es ihren ermöglicht, eine komplette ASF-Dokumentation in ihrer Muttersprache zu erstellen und so das allerletzte Problem bei der ASF-Lokalisierung effektiv zu lösen. Zusammen mit der Übersetzung des Programms und alle seiner Teile macht dies die Lokalisierung komplett.

Das Wiki ist in dieser Hinsicht etwas Besonderes, da es eine Online-Hilfe ist, bei der man sich nicht zu sehr an den ursprünglichen Satz halten muss. Das bedeutet, dass Du mit ihrer Sprache so natürlich wie möglich umgehen und eine originelle Bedeutung und Hilfe liefern solltest - nicht unbedingt mit der ursprünglichen Zeichenkette, den verwendeten Wörtern und der tatsächlichen Interpunktion. Scheu dich nicht die Zeichenkette in etwas viel natürlicheres für ihre Sprache umzuschreiben, solange Du die allgemeine Richtung und die im Satz enthaltene Hilfe einhältst.

---

### Globale Links

Unsere Crowdin-Plattform ermöglicht es ihren auch, den Originaltext so anzupassen, dass er auf neue (lokalisierte) Standorte verweist.

ASF enthält Links auf fast jeder Seite zur leichteren Navigation sowie eine Seitenleiste auf der rechten Seite. Die fantastische Tatsache ist, dass Du all das bearbeiten kannst, indem Du Links "fixierst", um auf richtige lokalisierte Seiten für ihre Sprache zu verweisen. Es erfordert ein wenig Vorsicht, wenn Du das tust, aber es ist möglich.

Zum Beispiel enthält die **[Startseite](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Home-de-DE)** von ASF folgenden Text:

> Wenn Du ein neuer Benutzer bist, empfehlen wir ihren mit dem Leitfaden zur **[Installation](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up-de-DE)** anzufangen.

Der eigentlich so geschrieben wird:

```markdown
Wenn Sie ein neuer Benutzer sind, empfehlen wir Ihnen mit dem Leitfaden zur **[Installation](https://github.com/JustArchi/ArchiSteamFarm/wiki/Setting-up-de-DE)** anzufangen.
```

Auf Crowdin solltest Du zuerst zu ihren Editor-Einstellungen gehen und sicherstellen, dass HTML-Tags für dich auf "Show" gesetzt sind. Dies ist sehr wichtig, wenn Du dich dazu entscheidest das Wiki zu übersetzen.

---

![Crowdin](https://i.imgur.com/YqAxiZ4.png)

---

Nun, während der Übersetzung auf Crowdin, je nach Formatierung, siehst Du ASF-Links im Text entweder als:

* Zeichenkette, die zusammen mit HTML-Tags übersetzt werden soll (Überwiegend von Zeichenketten, bei denen nur ein Teil des Satzes ein Link ist)
* Alone string to translate, with link included in `Hidden texts` -> `Link addresses` (rare, where entire string is a link, most common in sidebar - those require proofreader access to translate, sadly)

In unserem obigen Beispiel ist dies der erste Fall (da nur "Installation" ein Link ist), sodass wir es in Crowdin folgendermaßen sehen werden:

---

![Crowdin 2](https://i.imgur.com/Li5RzS3.png)

---

Unabhängig vom Fall solltest Du zuerst den Quelltext kopieren und wie gewohnt übersetzen, wobei Du das gesamte HTML (falls vorhanden) intakt lässt. Dies wäre ein Beispiel für eine Übersetzung in die polnische Sprache:

---

![Crowdin 3](https://i.imgur.com/NpKwfka.png)

---

Wenn es sich bei dem Link um einen generischen Link handelt, der außerhalb des Wikis liegt (z. B. auf die neueste ASF-Version), kannst Du ihn so lassen wie er ist, da Du ihn in diesem Fall nicht bearbeiten solltest. Sie können ihn speichern und weitermachen.

Wenn der Link jedoch weiter **innerhalb** des Wikis zeigt, wie der oben genannte, kannst Du ihn tatsächlich korrigieren, um auf einen neuen (lokalisierten) Pfad zu verweisen. Du erreichst dies, indem Du `-locale` sorgfältig an die Ziel-URL im `<a>`-Tag anhängst, wie unten beschrieben:

---

![Crowdin 4](https://i.imgur.com/TL8uwmb.png)

---

Achte darauf, dass ihre URL tatsächlich existiert, denn wenn Du einen Fehler machst wird dieser Link nicht mehr funktionieren. Wenn Du erfolgreich warst, hast Du jetzt eine voll funktionsfähige Übersetzung mit einem Link, der auf die übersetzte (in unserem Fall `Setting-up-pl-PL`) Seite zeigt.

Wenn Du die obigen Schritte ausführst, wird unser HTML-Code korrekt zurück in Markdown übersetzt:

```markdown
Jeśli jesteś nowym użytkownikiem, zalecamy rozpoczęcie od korzystania z **[przewodnika po konfiguracji](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up-pl-PL)**.
```

Und schließlich in den Wiki-Text:

> Jeśli jesteś nowym użytkownikiem, zalecamy rozpoczęcie od korzystania z **[przewodnika po konfiguracji](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up-pl-PL)**.

When no HTML is present (second case), this is even easier since you can just go to `Hidden texts` -> `Link addresses`.

---

![Crowdin 5](https://i.imgur.com/ZmgavCM.png)

---

Von dort aus kannst Du den Link zum Verweis auf eine neue Position leicht korrigieren ohne dich überhaupt um HTML kümmern zu müssen:

---

![Crowdin 6](https://i.imgur.com/maG7kSm.png)

---

### Lokale Links

Im gesamten Wiki findest Du auch lokale Links die auf einen bestimmten Abschnitt des Dokuments verweisen. Diese Links beinhalten ein `#` Zeichen die dem Webbrowser anzeigen, dass er sich in Richtung dieses Abschnitts des Dokuments bewegen soll.

Dies sind nun Sonderfälle, da diese Links auf den Namen der Abschnitte des aktuellen Dokuments basieren. Während wir für URLs die allgemeine Konvention haben der URL die `-locale` hinzuzufügen (dies funktioniert überall), werden Abschnittsnamen von ihren und anderen Leuten übersetzt, also musst Du sicherstellen, dass sie auf den richtigen Ort zeigen.

Beispielsweise findest Du den Link `#introduction` in unserem Abschnitt **[configuration](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-de-DE#introduction)**:

---

![Crowdin 7](https://i.imgur.com/EEHSPtK.png)

---

Da wir das Wort "Introduction" in "Wprowadzenie" für unsere polnische Sprache übersetzen werden, müssen wir diesen Link korrigieren, da er sonst nicht mehr funktioniert.

---

![Crowdin 8](https://i.imgur.com/JMJegO7.png)

---

Auf diese Weise funktioniert unser lokaler Link weiterhin, da er nun auf den Namen des Bereichs zeigt den wir verwenden. Sie können Links innerhalb von HTML-Tags auf die gleiche Weise korrigieren.

---

### Codeblöcke

Sei äußerst sorgfältig, wenn Du Sätze mit `<code></code>` Blöcken übersetzt. Der Codeblock zeigt feste ASF-Codenamen oder Begriffe an die nicht übersetzt werden sollten. Zum Beispiel:

> Das ist besonders nützlich, wenn Du eine große Menge an Produktschlüsseln aktivieren möchtest und Du sicherlich den <code>RateLimited</code> Status erreichst, bevor Du mit ihrer gesamten Charge fertig bist.

Wie Du sehen kannst, befindet sich das Wort `RateLimited` hier in einem Codeblock und zeigt den internen ASF-Code-Status an, der nicht übersetzt werden sollte. Ebenso solltest Du keine anderen Codeblöcke übersetzen, wie z. B. Namen von Konfigurationseigenschaften (z. B. `TradingPreferences`), Enum-Mitglieder (z. B. `Stable` und `Experimental` Optionen von `UpdateChannel`) und ähnliches.

Nur weil diese Wörter nicht übersetzt werden sollten, bedeutet das nicht, dass Du Ihnen keine entsprechende Übersetzung hinzufügen kannst, zum Beispiel in Klammern.

> Das ist besonders nützlich, wenn Du eine große Menge an Produktschlüsseln aktivieren möchtest und Du sicherlich den <code>RateLimited</code> (zu häufiges Aktivieren) Status erreichst, bevor Du mit ihrer gesamten Charge fertig bist.

Wie Du oben sehen kannst, haben wir neben `RateLimited` "zu häufiges Aktivieren" hinzugefügt, um diesen Status benutzerfreundlich zu übersetzen, während gleichzeitig das ursprüngliche ASF-Wort beibehalten wird, dass der Benutzer während der Nutzung des Programms eventuell sieht. Auf die gleiche Weise kannst Du auch andere ähnliche Fälle von verschiedenen Wörtern und Sätzen übersetzen/erklären.

Wenn Du glaubst, dass etwas Unangemessenes in einem Codeblock enthalten ist oder es einen Text gibt der sich nicht in einem Codeblock befindet, sich aber in einem Codeblock befinden sollte, kannst Du gerne hier auf Crowdin fragen, indem Du ein entsprechendes **[Problem](#Probleme)** erstellst. Dies dient auch als praktisches Beispiel für die Nutzung eines lokalen Links.

---

## Ruhmeshalle

Wir möchten unseren ewigen Dank denjenigen Menschen zeigen, die sehr viel ihrer Zeit und Bereitschaft gegeben haben um die ASF Übersetzung zu verbessern. Ihr Aufwand ist unglaublich, und Sie können sich an kompletten Übersetzungen erfreuen, einschließlich des Wikis, hauptsächlich dank Ihnen. As a token of appreciation, all people listed here are offered free access to **[`MatchActively`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#matchactively)** feature upon a **[request](https://crowdin.com/messages/create/13177432/240376)**.

| Mitwirkender                                               | Sprachen             |
| ---------------------------------------------------------- | -------------------- |
| **[Astaroth](https://crowdin.com/profile/astaroth2012)**   | LOLCAT, Spanisch     |
| **[Dead_Sam](https://crowdin.com/profile/Dead_Sam)**       | Portugiesisch (BR)   |
| **[deluxghost](https://crowdin.com/profile/deluxghost)**   | Chinesisch (CN)      |
| **[DragonTaki](https://crowdin.com/profile/dragontaki)**   | Chinesisch (TW)      |
| **[LittleFreak](https://crowdin.com/profile/littlefreak)** | Deutsch              |
| **[Ryzhehvost](https://crowdin.com/profile/Ryzhehvost)**   | Russisch, Ukrainisch |
| **[MrBurrBurr](https://crowdin.com/profile/MrBurrBurr)**   | LOLCAT, Deutsch      |
| **[XinxingChen](https://crowdin.com/profile/XinxingChen)** | Chinesisch (HK)      |

Vielen Dank an euch alle für die Verbesserung unserer ASF-Übersetzungsqualität!