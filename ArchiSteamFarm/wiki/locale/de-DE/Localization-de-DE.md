# Lokalisierung

ASF wird von dem Dienst Crowdin unterstützt, wodurch es jedem ermöglicht wird ASF in alle weltweit gesprochenen Sprachen zu übersetzen. Für eine detailliertere Erklärung, wie Crowdin funktioniert, lesen Sie sich bitte die **[Einführung in Crowdin](https://support.crowdin.com/crowdin-intro)** durch.

Falls Sie daran interessiert sind, was zurzeit passiert, können Sie sich die **[aktuellen ASF Crowdin Aktivitäten](https://crowdin.com/project/archisteamfarm/activity_stream)** ansehen.

---

## Umfang

Unsere Plattform unterstützt die Lokalisierung unseres ASF-Hauptprogramms sowie aller lokalisierbaren Inhalte, die wir zusammen mit diesem anbieten. Dies beinhaltet insbesondere unseren ASF-WebConfigGenerator, ASF-UI sowie auch das Wiki selbst. All das kann man bequem durch das Crowdin-Interface übersetzen.

---

## Anmeldung

Wenn Sie bei der Arbeit an ASF helfen möchten – entweder durch Übersetzen, Überprüfen oder Genehmigen von Übersetzungen – melden Sie sich bitte auf unserer **[Crowdin-Projektseite](https://crowdin.com/project/archisteamfarm)** an. Die Registrierung ist einfach und absolut kostenlos! Nach dem Einloggen können Sie Sprachen auswählen, denen Sie gern zugewiesen werden möchten und anschließend zu den ASF-Zeichenketten gehen und dem Rest der Community helfen, ASF in alle gängigen Sprachen zu übersetzen!

---

### Übersetzen

Wenn der Sprache Ihrer Wahl noch einige Zeichenketten fehlen, können Sie sie Ihren schnappen und mit der Übersetzung beginnen. Wir haben versucht, unser Bestes in Bezug auf die Flexibilität der Übersetzungen zu geben, daher enthalten viele Zeichenketten zusätzliche Variablen, die ASF während der Laufzeit bereitstellen wird – diese sind in Klammern mit einer Zahl eingeschlossen, z. B. `{0}`. Dies ermöglicht es Ihnen, das Standard-ASF-Format der Zeichenkette zu ändern, z. B. indem Sie die von ASF bereitgestellte Variable an einen Ort verschieben, der Ihrer Sprache und Ihrer Übersetzung entspricht, anstatt in einen strengen Zusammenhang und Format gezwungen zu werden. Das ist besonders wichtig in Sprachen wie Hebräisch, die von rechts nach links gelesen werden.

Es könnten etwa folgende Zeichenketten vorkommen:

> Wir haben {0} Spiele zum Sammeln.

Aber basierend auf Ihrer Sprache könnte folgender Satz mehr Sinn machen:

> Die Anzahl der Spiele, die zu sammeln sind, ist equivalent zu {0}.

Oder:

> {0} ist die Anzahl der Spiele, die wir sammeln können.

Diese Flexibilität wird speziell für Sie bereitgestellt, sodass Sie den ASF-Satz leicht umformulieren können, um ihn besser an eine Sprache anzupassen, und die von ASF bereitgestellte Nummer oder andere Informationen an einen Ort zu verschieben, der zu der Übersetzung passt (anstatt jeden Teil unabhängig zu übersetzen). Das Verbessert die allgemeine Übersetzungsqualität.

---

### Überprüfung

Wenn Ihre Zeichenkette bereits von jemand anderem übersetzt wurde, können Sie dafür stimmen. Eine Abstimmung ermöglicht die beste Variante einer Übersetzung auszusuchen, anstatt an einem ursprünglichen Vorschlag festzuhalten – Das verbessert die Qualität der Übersetzungen weiter. Sie können für bereits verfügbare Vorschläge stimmen oder Ihren eigenen Vorschlag der Übersetzung hinzufügen, der durch denselben Prozess gehen wird. Schlussendlich wird ein endgültiger Wert gewählt, basierend auf dem Vorschlag mit den meisten Stimmen oder als Wahl eines Korrekturlesers, der für diese Sprache ausgewählt wurde, der die gegebene Übersetzung persönlich genehmigt (unter anderem basierend auf Ihren Stimmen).

**Sie brauchen keine Genehmigung um Ihre Übersetzungen in ASF zu sehen**. Genehmigung heißt einfach, dass jemand, dem wir vertrauen, Ihren Beitrag angesehen und für gut befunden hat. Es genügt, unter den nicht genehmigte Übersetzungen, die von der Community erstellt wurden, dass Sie für die beste Version abstimmen. Solange es sinnvoll übersetzt wurde, ist es in Ordnung! Wenn Sie denken, dass die aktuelle Übersetzung schlecht ist, können Sie gerne jederzeit für eine bessere stimmen oder selbst eine vorschlagen.

---

### Korrekturlesen

Es ist eine gute Idee eine konsistente Übersetzung zu haben, selbst, wenn es möglicherweise die Freiheiten der oben erklärten Community-Rezensierung oder des Stimmprozesses einschränken könnte. Dies ist hauptsächlich darauf zurückzuführen, dass falsche Übersetzungen so viele Stimmen erhalten könnten, dass es nicht möglich ist, eine bessere Übersetzung vorzuschlagen, selbst wenn diese jemand hat.

Wenn Sie bereits in der Vergangenheit Beiträge auf Crowdin oder einer anderen Übersetzungsplattform übersetzt haben, die wir verifizieren und vertrauensvoll nennen können, würden wir uns freuen, Ihren Korrekturleser-Zugriff zu der Sprache zu geben, die Sie übersetzten, damit es Ihren möglich ist, gegebene Übersetzungen zu genehmigen oder konsistenter zu gestalten. Korrekturlesen ist keine einfache Aufgabe, besonders, weil ASF vereinzelt sehr „technisch“ und schwer zu übersetzen sein kann, aber wir verstehen, dass es für eine perfekte Übersetzung oft nötig ist. Wenn Sie uns helfen können eine Sprache Korrektur zu lesen, bitten wir Sie: **[uns zu informieren](https://crowdin.com/messages/create/13177432/240376)**, bedenken Sie aber, dass Sie Ihre Anfrage mit vergangenen Beiträgen, die wir verifizieren können (z. B. bei ASF oder anderen Projekten auf Crowdin zu helfen), stützen müssen. Wir könnten auch fortgeschrittenen Benutzern das initiale Korrekturlesen erlauben, wenn wir sie persönlich kennen und sie mit dem Rest der Community kooperieren können, um ASF in der gegebenen Sprache bestmöglich zu übersetzen.

Generellen Regeln gelten auch für das Korrekturlesen – nehmen Sie sich Zeit, auf andere Benutzer zu hören, Sie müssen als Projektmanager arbeiten, Probleme lösen und sicherstellen, dass Sie die Dinge besser machen – nicht schlimmer.

---

### Probleme

Wenn Sie ein Problem mit einer bestimmten Übersetzung haben, weil Sie zum Beispiel nicht wissen, wie sie zu übersetzen ist, dann ist eine genehmigte Übersetzung falsch. Falls Sie mehr Kontext benötigen oder Ähnliches, dann schreiben Sie bitte einen Kommentar unter dem betroffenen String und markiere ihn mit [X] als ein Problem besteht.

**Bitte vermeiden Sie das [x], wenn Sie keine technische Erklärung oder Aktion eines Admins benötigen**. Es steht Ihnen frei, Kommentare für Diskussionen zu verwenden, die sich auf die Übersetzung der gegebenen Zeichenkette beziehen, aber „issue“ sollte nur verwendet werden, wenn Sie weitere technische Erklärungen oder Korrekturen durch den Administrator benötigen, und es wird typischerweise jemanden betreffen, der nicht einmal die Sprache spricht, in die Sie übersetzen, also bleiben Sie bitte bei Englisch, wenn Sie mit „issue“ kommentieren (damit wir verstehen können, worum es geht).

Wir unterstützen vier verschiedene Arten von Problemen:
- generelle Frage – Für alles, was keinen der anderen Typen betrifft. Dieser Typ **sollte vermieden** werden, weil es dann höchstwahrscheinlich **kein** Übersetzungsproblem ist. Trotzdem ist diese Möglichkeit für alle anderen Fälle offen.
- Die aktuelle Übersetzung ist falsch – Dies sollte **nur** verwendet werden, wenn die Übersetzung von einem Korrekturleser genehmigt wurde und Sie glauben, dass sie falsch ist, weil sie etwa einen Tippfehler beinhaltet oder Sie einen guten Verbesserungsvorschlag haben. Dieser Typ sollte nie bei Übersetzungen verwendet werden, die durch Community-Stimmen gewählt wurden, in welchem Fall Sie den Benutzer der die Übersetzung geschrieben hat kontaktieren und ihn um eine Korrektur bitten oder einfach für eine bessere Übersetzung stimmen sollten. Wir entfernen die Freigabe der Übersetzung und benachrichtigen den für die Sprache zuständigen Korrekturleser, um Ihren Kommentar zu berücksichtigen und erneut zu überprüfen.
- Fehlender Kontext – Dies ist, was Sie verwenden sollten, wenn Sie nicht sicher sind, welchen Teil von ASF Sie übersetzt und was der Kontext der gegebenen Zeichenkette oder dessen Sinn ist. Dieser Typ sollte nur für die Entwicklung von ASF verwendet werden, da er bedeutet, dass Sie technische Hilfe benötigen, weil Sie nicht sicher sind, wie die Zeichenkette zu übersetzen ist.
- Fehler in der Quell-Zeichenkette – Dies sollte nur verwendet werden, wenn Sie denken, dass das Original (Englisch) falsch ist. Sehr selten, aber nicht bei jedem ist Englisch unsere Muttersprache, von daher zögern Sie nicht diesen zu verwenden, wenn Sie eine generelle Idee haben, wie man es verbessern könnte. Da dies eng mit der Entwicklung verbunden ist, können Sie alternativ unsere **[GitHub Issues](https://github.com/JustArchiNET/ArchiSteamFarm/issues/new/choose)** für diesen Zweck verwenden, wenn Sie es wünschen.

---

### Übersetzungsfortschritt

Jede Sprache hat zwei Fortschrittszustände – Übersetzung und Korrekturlesen.

Eine Sprache gilt als **übersetzt⁣, sobald der Übersetzungsfortschritt 100 % erreicht. Zu diesem Zeitpunkt hat jede übersetzbare Zeichenkette, die von ASF verwendet wird, eine entsprechende Bedeutung, was wunderbar ist. Allerdings heißt das nicht, dass kein Raum für Verbesserungen bleibt– das Abstimmen ist durchgehend aktiviert und Sie können immer noch Vorschläge für bessere Übersetzungen einbringen und für existierende Stimmen. Bitte bedenken Sie, dass bereits fertig übersetzte Sprachen immer noch unter 100 % fallen können, wenn wir während der Entwicklung existierende Zeichenketten ändern oder neue hinzufügen. Sie können entsprechende Crowdin-Benachrichtigungen aktivieren, wenn Sie in einem solchen Fall eine E-Mail erhalten wollen.</p>

Gewählte Sprachen können entsprechende Korrekturleser haben, die Übersetzungen validieren und endgültige Versionen auswählen. Dies ist der letzte Schritt nach der Übersetzung und erlaubt weitere Verbesserungen.

ASF wird die Sprache **so bald wie möglich** übernehmen, was bedeutet, dass sie nicht genehmigt oder zu 100 % übersetzt werden muss. Die tatsächlich verwendeten Zeichenketten sind immer die am beliebtesten In Bezug auf Stimmen, außer der gewählte Korrekturleser hat anders entschieden (sehr selten). Daher können Sie sehen, dass Ihre Bemühungen bereits im nächsten ASF-Release enthalten sind – unsere automatisierten Systeme pflegen täglich die Übersetzungen von Crowdin im ASF-Verzeichnis ein.

---

## Fehlende Sprachen

Standardmäßig verfügt das ASF-Projekt nur Übersetzungen für die 30 meistgesprochenen Sprachen der Welt. Wenn Sie eine weitere (oder einen lokalen Dialekt zu einer existierenden) hinzufügen wollen, **[lassen Sie es uns bitte wissen](https://crowdin.com/messages/create/13177432/240376)** und wir kümmern uns schnellstmöglich darum. Wir möchten nicht mehrere hundert verschiedene Sprachen, wenn sie keiner übersetzt. Deshalb haben wir sie auf diese Anzahl reduziert. Bitte zögern Sie nicht uns zu kontaktieren, wenn Sie eine nicht gelistete Sprache übersetzen wollen. Für uns ist es sehr einfach eine weitere hinzuzufügen. Achten Sie einfach darauf, dass Sie den tatsächlichen Willen und die Entschlossenheit haben, ASF in Ihre Sprache zu übersetzen, bevor Sie sich entscheiden, mit uns Kontakt aufzunehmen.

Für eine komplette Liste der verfügbaren Sprachen, in die ASF übersetzt werden kann, **[klicken Sie hier](https://developer.crowdin.com/language-codes)**.

---

## Pluralisierung

Jede Sprache hat Ihre eigenen Regeln in Bezug auf die Pluralisierung. Diese Regeln können Sie auf **[CLDR](https://unicode-org.github.io/cldr-staging/charts/laten/supplemental/language_plural_rules.html)** finden, welche Ihre Anzahl und genauen Sprachbedingungen angibt.

Wir tun unser Bestes, um Ihren eine flexible Lokalisierung anzubieten, und so lange wie möglich, wird dies auch Regeln für Pluralisierung beinhalten. Als Beispiel werden wir heute folgende Zeichenkette ins Polnische übersetzen:

> Released {PLURAL:n|{n} month|{n} months} ago

`PLURAL` Schlüsselwort wird hier besonders behandelt, da es Ihnen erlaubt, alle Pluralformen einzubeziehen, die Ihre Sprache unterstützt. Wenn Sie einen Blick auf CLDR werfen, werden Sie sehen, dass es im Englischen nur 2 kardinale Formen gibt – „eine“ und „andere“. Und wie Sie oben sehen können, haben wir beide definiert – `{n} month` und `{n} months`.

Unsere polnische Sprache umfasst jedoch 4 von ihnen – „eine“, „wenige“, „viele“ und „andere“. Das bedeutet, dass wir alle für die vollständige Umsetzung definieren sollten. Unsere Übersetzungsprogramme sind bereits intelligent genug, um eine geeignete Pluralform basierend auf Sprachregeln auszuwählen, sodass Sie nur alle diese in der Übersetzung definieren müsssen:

> Wydany {PLURAL:n|{n} miesiąc|{n} miesiące|{n} miesięcy|{n} miesiąca} temu

Auf diese Weise haben wir alle 4 Pluralformen für unsere polnische Sprache definiert, und da unsere Lokalisierungsbibliothek bereits die genauen Regeln kennt, wird sie die richtige Form für die angegebene `{n}` Nummer korrekt verwenden.

Es ist nicht zwingend erforderlich, alle von Ihrer Sprache verwendeten Pluralformen zu definieren. Wenn sie fehlt, verwendet unsere Lokalisierungsbibliothek die zuletzt definierte Form an Ihrer Stelle. Es ist eine gute Idee, alle von Ihrer Sprache verwendeten Pluralformen zu definieren, aber in einigen Fällen können die verbleibenden Pluralformen die gleichen sein wie die letzten, in diesem Fall ist es nicht notwendig, sie zu wiederholen. In unserem obigen Beispiel war es zwingend erforderlich, da die „andere“ Form im Polnischen für Monate „miesiąca“ ist und nicht „miesięcy“ wie in „vielen“.

---

## Wiki

Unsere Crowdin-Plattform ermöglicht es Ihnen sogar selbst das Wiki zu lokalisieren. Dies ist ein sehr mächtiges Programm, da es Ihnen ermöglicht, eine komplette ASF-Dokumentation in Ihrer Muttersprache zu erstellen und so das allerletzte Problem bei der ASF-Lokalisierung effektiv zu lösen. Zusammen mit der Übersetzung des Programms und seiner Abschnitte macht dies die Lokalisierung komplett.

Das Wiki ist in dieser Hinsicht etwas Besonderes, da es eine Online-Hilfe ist, die dem ursprünglichen Satz nicht zu sehr entsprechen muss. Das bedeutet, dass Sie mit Ihrer Sprache so natürlich wie möglich umgehen und eine originelle Bedeutung und Hilfe liefern sollten – nicht unbedingt mit der ursprünglichen Zeichenkette, den verwendeten Wörtern und der tatsächlichen Interpunktion. Scheuen Sie sich nicht, die Zeichenkette in etwas viel Natürlicheres für Ihre Sprache umzuschreiben, solange Sie die allgemeine Richtung und die im Satz enthaltene Hilfe einhalten.

---

### Globale Links

Unsere Crowdin-Plattform ermöglicht es Ihnen auch, den Originaltext so anzupassen, dass er auf neue (lokalisierte) Standorte verweist.

ASF enthält Links auf fast jeder Seite zur leichteren Navigation sowie eine Seitenleiste auf der rechten Seite. Die fantastische Tatsache ist, dass Sie all das bearbeiten können, indem Sie Links „fixieren“, um auf richtige lokalisierte Seiten für Ihre Sprache zu verweisen. Es erfordert ihrerseits ein wenig Vorsicht bei der Umsetzung, aber es ist möglich.

Zum Beispiel enthält die **[Startseite](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Home-de-DE)** von ASF folgenden Text:

> Wenn Sie ein neuer Benutzer sind, empfehlen wir Ihnen, mit dem Leitfaden zur **[Installation](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up-de-DE)** anzufangen.

Welcher eigentlich so geschrieben wird:

```markdown
Wenn Sie ein neuer Benutzer sind, empfehlen wir Ihnen, mit dem Leitfaden zur **[Installation](https://github.com/JustArchi/ArchiSteamFarm/wiki/Setting-up-de-DE)** anzufangen.
```

Auf Crowdin sollten Sie zuerst zu Ihren Editor-Einstellungen gehen und sicherstellen, dass HTML-Tags für Sie auf „Show“ gesetzt sind. Dies ist sehr wichtig, wenn Sie sich dazu entscheiden das Wiki zu übersetzen.

---

![Crowdin](https://i.imgur.com/YqAxiZ4.png)

---

Nun, während der Übersetzung auf Crowdin, je nach Formatierung, sehen Sie ASF-Links im Text entweder als:

* Zeichenkette, die zusammen mit HTML-Tags übersetzt werden soll (Überwiegend von Zeichenketten, bei denen nur ein Teil des Satzes ein Link ist)
* Einzelne zu übersetzende Zeichenkette, mit Link in `Hidden texts` (versteckter Text) -> `Link addresses` (selten, wo die gesamte Zeichenkette ein Link ist, am häufigsten in der Seitenleiste. Leider haben nur Korrekturleser die Möglichkeit diese zu übersetzen)

In unserem obigen Beispiel ist dies der erste Fall (da nur „Installation“ ein Link ist), sodass wir es in Crowdin folgendermaßen sehen werden:

---

![Crowdin 2](https://i.imgur.com/Li5RzS3.png)

---

Unabhängig vom Fall sollten Sie zuerst den Quelltext kopieren und wie gewohnt übersetzen, wobei Sie das gesamte HTML (falls vorhanden) intakt lässt. Dies wäre ein Beispiel für eine Übersetzung in die polnische Sprache:

---

![Crowdin 3](https://i.imgur.com/NpKwfka.png)

---

Wenn es sich bei dem Link um einen generischen Link handelt, der außerhalb des Wikis liegt (z. B. auf die neueste ASF-Version), können Sie ihn so lassen wie er ist, da Sie ihn in diesem Fall nicht bearbeiten sollten. Sie können ihn speichern und weitermachen.

Wenn der Link jedoch weiter **innerhalb** (wie der oben genannte) des Wikis zeigt, können Sie ihn tatsächlich korrigieren, um auf einen neuen (lokalisierten) Pfad zu verweisen. Sie erreichen dies, indem Sie `-locale` sorgfältig an die Ziel-URL im `<a>`-Tag anhängen, wie im Folgenden erläutert:

---

![Crowdin 4](https://i.imgur.com/TL8uwmb.png)

---

Achten Sie darauf, dass Ihre URL tatsächlich existiert, denn wenn Sie einen Fehler machen, wird dieser Link nicht mehr funktionieren. Wenn Sie erfolgreich waren, haben Sie jetzt eine voll funktionsfähige Übersetzung mit einem Link, der auf die übersetzte (in unserem Fall `Setting-up-pl-PL`) Seite zeigt.

Nachdem Sie die obigen Schritte ausgeführt haben, wird unser HTML-Code korrekt zurück in Markdown übersetzt … :

```markdown
Jeśli jesteś nowym użytkownikiem, zalecamy rozpoczęcie od korzystania z **[przewodnika po konfiguracji](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up-pl-PL)**.
```

… und schließlich in den Wiki-Text:

> Jeśli jesteś nowym użytkownikiem, zalecamy rozpoczęcie od korzystania z **[przewodnika po konfiguracji](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up-pl-PL)**.

Wenn kein HTML vorhanden ist (zweiter Fall), ist das noch einfacher, da Sie einfach zu `Hidden texts` -> `Link addresses` gehen können.

---

![Crowdin 5](https://i.imgur.com/ZmgavCM.png)

---

Von dort aus können Sie den Link zum Verweis auf eine neue Position leicht korrigieren, ohne sich überhaupt um HTML kümmern zu müssen:

---

![Crowdin 6](https://i.imgur.com/maG7kSm.png)

---

### Lokale Links

Im gesamten Wiki finden Sie auch lokale Links die auf einen bestimmten Abschnitt des Dokuments verweisen. Diese Links beinhalten ein `#` Zeichen, die dem Webbrowser anzeigen, dass er sich in Richtung dieses Abschnitts des Dokuments bewegen soll.

Dies sind nun Sonderfälle, da diese Links auf den Namen der Abschnitte des aktuellen Dokuments basieren. Während wir für URLs die allgemeine Konvention für das Hinzufügen der `-locale` (dies funktioniert überall) an die URL haben, werden Abschnittsnamen von Ihnen und Anderen übersetz; also müssen Sie sicherstellen, dass sie auf den richtigen Ort zeigen.

Beispielsweise finden Sie den Link `#einleitung` in unserem Abschnitt **[Konfiguration](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-de-DE#einleitung)**:

---

![Crowdin 7](https://i.imgur.com/EEHSPtK.png)

---

Da wir das Wort „Introduction“ in „Wprowadzenie“ für unsere polnische Sprache übersetzen, müssen wir diesen Link korrigieren, da er sonst nicht mehr funktioniert.

---

![Crowdin 8](https://i.imgur.com/JMJegO7.png)

---

Auf diese Weise funktioniert unser lokaler Link weiterhin, da er nun auf den Namen des Bereichs zeigt, den wir verwenden. Sie können Links innerhalb von HTML-Tags auf die gleiche Weise korrigieren.

---

### Codeblöcke

Seien Sie äußerst sorgfältig, wenn Sie Sätze mit `<code></code>` Blöcken übersetzen. Der Codeblock zeigt feste ASF-Codenamen oder Begriffe an, die nicht übersetzt werden sollten. Zum Beispiel:

> Das ist besonders nützlich, wenn Sie eine große Menge an Produktschlüsseln aktivieren möchten und Sie sicherlich den <code>RateLimited</code> Status erreichen, bevor Sie mit Ihrer gesamten Charge fertig sind.

Wie Sie sehen können, befindet sich das Wort `RateLimited` hier in einem Codeblock und zeigt den internen ASF-Code-Status an, der nicht übersetzt werden sollte. Ebenso sollten Sie keine anderen Codeblöcke übersetzen, z. B. Namen von Konfigurationseigenschaften (z. B. `TradingPreferences`), Enum-Mitglieder (z. B. `Stable` und `Experimental` Optionen von `UpdateChannel`) und ähnliches.

Nur weil diese Wörter nicht übersetzt werden sollten, bedeutet das nicht, dass Sie ihnen keine entsprechende Übersetzung hinzufügen können, zum Beispiel in Klammern.

> Das ist besonders nützlich, wenn Sie eine große Menge an Produktschlüsseln aktivieren möchten und Sie sicherlich den <code>RateLimited</code> (zu häufiges Aktivieren) Status erreichen, bevor Sie mit Ihrer gesamten Charge fertig sind.

Wie Sie oben sehen können, haben wir neben `RateLimited` „zu häufiges Aktivieren“ hinzugefügt, um diesen Status benutzerfreundlich zu übersetzen, während gleichzeitig das ursprüngliche ASF-Wort beibehalten wurde, dass der Benutzer während der Nutzung des Programms eventuell sieht. So können Sie auch andere ähnliche Fälle von verschiedenen Wörtern und Sätzen übersetzen/erklären.

Wenn Sie glauben, dass etwas Unangemessenes in einem Codeblock enthalten ist oder es einen Text gibt der sich nicht in einem Codeblock befindet, sich aber in einem Codeblock befinden sollte, können Sie gerne hier auf Crowdin fragen, indem Sie ein entsprechendes **[Problem](#Probleme)** erstellen. (Dies dient ebenfalls als praktisches Beispiel für die Nutzung eines lokalen Links.)

---

## Ruhmeshalle

Wir möchten unseren ewigen Dank denjenigen Menschen zeigen, die sehr viel Ihrer Zeit und Bereitschaft gegeben haben, um die ASF Übersetzung zu verbessern. Ihr Aufwand ist unglaublich, und Sie können sich an kompletten Übersetzungen erfreuen, einschließlich des Wikis, hauptsächlich dank Ihnen. Als Zeichen der Wertschätzung, erhalten alle hier aufgeführten Personen freien Zugang zu **[`MatchActively`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin-de-DE#matchactively)** Funktion auf **[Anfrage](https://crowdin.com/messages/create/13177432/240376)**.

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