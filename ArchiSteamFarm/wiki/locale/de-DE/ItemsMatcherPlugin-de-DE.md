# ItemsMatcherPlugin

`ItemsMatcherPlugin` ist eine offizielle ASF-**[Erweiterung](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins-de-DE)**, das ASF um ASF STM Funktionen ergänzt. Insbesondere beinhaltet dies `PublicListing` in **[`RemoteCommunication`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-de-DE#remotecommunication)**, sowie `MatchActively` für **[`TradingPreferences`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-de-DE#tradingpreferences)**. ASF wird gebündelt mit `ItemsMatcherPlugin` veröffentlicht und ist daher sofort einsatzbereit.

---

## `PublicListing`

Wie der Name schon verrät, werden in einer öffentlichen Liste die derzeit verfügbaren ASF STM-Bots aufgeführt. Diese befindet sich auf **[unserer Website](https://asf.justarchi.net/STM)**, wird automatisch verwaltet, und als öffentlicher Dienst sowohl für ASF-Benutzer (die `MatchActively` verwenden), als auch für ASF- und Nicht-ASF-Benutzer beim manuellen Abgleich verwendet.

Um aufgelistet zu werden, müssen Sie zunächst einige Anforderungen erfüllen. Sie müssen mindestens `PublicListing` in `RemoteCommunication` erlaubt (Standardeinstellung), `SteamTradeMatcher` in `TradingPreferences` aktiviert, ein **[öffentliches Inventar](https://steamcommunity.com/my/edit/settings)** in den Privatsphäre-Einstellungen, ein **[uneingeschränktes](https://help.steampowered.com/faqs/view/71D3-35C2-AD96-AA3A)** Konto, und **[ASF-2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication#asf-2fa)** aktiviert haben. Zusätzliche Anforderungen umfassen eine seit mindestens 15 Tage aktive 2FA; die letzte Passwortänderung vor mehr als 5 Tagen; sowie das Fehlen jeglicher Kontobeschränkungen wie Sperrungen, wirtschaftliche Verbote und Handelsverbote. Selbstverständlich müssen Sie auch mindestens einen Gegenstand von Ihren angegebenen `MatchableTypes` besitzen, z. B. Handelskarten. Zusätzlich werden Bots mit mehr als `500000` Artikeln aufgrund eines übermäßigen Überschusses nicht akzeptiert. Wir empfehlen, Ihr Inventar in diesem Fall auf mehrere Konten aufzuteilen.

Während `PublicListing` standardmäßig aktiviert ist, gilt zu beachten, dass Sie **nicht** auf der Website angezeigt werden, solange Sie nicht alle Anforderungen erfüllen – vor allem `SteamTradeMatcher` (was nicht standardmäßig aktiviert ist). Für Personen, die die Kriterien nicht erfüllen, kommuniziert ASF in keiner Weise mit dem Server, selbst wenn sie `PublicListing` aktiviert haben. Die öffentliche Auflistung ist nur mit der neuesten stabilen Version von ASF kompatibel und kann sich weigern, veraltete Bots anzuzeigen, insbesondere wenn diesen Kernfunktionen fehlen, die nur in neueren Versionen zu finden sind.

### Wie es genau funktioniert

ASF übermittelt nach der Anmeldung einmalig Daten, die alle Variablen enthalten, die für die öffentliche Auflistung verwendet werden. Dann sendet ASF alle 10 Minuten eine winzige „Heartbeat“-Anfrage, die unseren Server darüber informiert, dass der Bot noch aktiv ist. Wenn der „Heartbeat“ aus irgendeinem Grund nicht ankam, z. B. aufgrund von Netzwerkproblemen, wird ASF versuchen, ihn jede Minute erneut zu senden bis der Server ihn registriert. Unser Server kann auf diese Weise ermitteln, welche Bots noch in Betrieb und bereit sind, Handelsangebote anzunehmen. ASF wird auch erste Ankündigungen nach Bedarf übermitteln, wenn es beispielsweise feststellt, dass sich unser Inventar seit dem vorhergehenden geändert hat.

Alle ASF 2FA+STM Konten, die **in den vergangenen 15 Minuten** aktiv waren, werden von uns dargestellt. Benutzer werden nach ihrem relativen Nutzen sortiert – `MatchEverything`-Bots mit dem Banner `Any` (alle 1:1 Trades werden akzeptiert), danach zählen die einzigartigen Spiele und schließlich zählt die Anzahl Gegenstände.

### API

ASF STM Inserate akzeptieren derzeit nur ASF-Bots. Es gibt vorerst keine Möglichkeit Drittanbieter-Bots in unsere Auflistung einzutragen, da wir ihren Quellcode nicht einfach überprüfen können und sicherstellen müssen, dass sie unserer gesamten Handelslogik entsprechen. Die Teilnahme an der Auflistung erfordert daher die aktuellste stabile ASF-Version, obwohl sie mit eigenen **[Erweiterungen](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Erweiterungen-de-DE)** laufen kann.

Für Verbraucher der Auflistung haben wir einen sehr einfachen Endpunkt (**[`/Api/Listing/Bots`](https://asf.justarchi.net/Api/Listing/Bots)**), den Sie verwenden können. Dieser enthält alle Daten, die wir haben, außer Bestände von Benutzern, die Teil der Funktion `MatchActively` sind.

### Datenschutzrichtlinie

Wenn Sie damit einverstanden sind, an unserer Liste teilzunehmen, dann aktivieren Sie `SteamTradeMatcher` und lehnen Sie `PublicListing` nicht ab (siehe oben); dann speichern wir vorübergehend einige Ihrer Steam-Kontodaten auf unserem Server, um die erwartete Funktionalität bereitzustellen.

Öffentliche Informationen (durch Steam jeden ausgesetzt) beinhalten:
- Ihre Steam-ID (in 64-Bit-Form, zur Generierung von Links)
- Ihr Nickname (zu Anzeigezwecken)
- Ihr Avatar (hash, für Ansichtszwecke)

Bedingungsgemäß öffentliche Informationen beinhalten (von Steam an alle Interessenten ausgesetzt, sofern Sie die Anforderungen an die Auflistung erfüllen):
- Ihr **[Inventar](https://steamcommunity.com/my/inventory/#753_6)** (damit die Leute `MatchActively` mit Ihren Gegenständen verwenden können).

Private Informationen (ausgewählte Daten für die Bereitstellung der Funktionalität) beinhalten:
- Ihr **[Handelscode](https://steamcommunity.com/my/tradeoffers/privacy)** (damit Leute außerhalb Ihrer Freundesliste Ihnen Handelsangebote schicken können)
- Ihre Einstellung `MatchableTypes` (zum Anzeigen und Abgleichen)
- Ihre Einstellung `MatchEverything` (zum Anzeigen und Abgleichen)
- Ihre Einstellung `MaxTradeHoldDuration` (sodass andere Leute wissen, ob Sie bereit sind, deren Handel anzunehmen)

Ihre Daten werden für maximal zwei Wochen nach Ihrer letzten Auflistung (Nutzung/Bekanntgabe) gespeichert und nach Ablauf dieses Zeitraums automatisch gelöscht.

---

## `MatchActively`

Die Einstellung `MatchActively` ist eine aktive Version des **[`SteamTradeMatcher`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading#steamtradematcher)** (einschließlich interaktiver Übereinstimmung), mit welcher der Bot Handelsangebote an andere Personen senden wird. Diese kann eigenständig funktionieren, oder mit der Einstellung `SteamTradeMatcher`. Diese Funktion erfordert eine gültige `LicenseID`, da sie den Server von Drittanbietern und bezahlte Ressourcen nutzt.

Um von dieser Option Gebrauch zu machen, müssen Sie eine Reihe von Anforderungen erfüllen. Sie benötigen mindestens ein **[uneingeschränktes](https://help.steampowered.com/faqs/view/71D3-35C2-AD96-AA3A)** Konto, einen aktiven **[ASF-2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication#asf-2fa)** und mindestens ein gültiger Typ in `MatchableTypen`(z. B. Sammelkarten). Zusätzliche Anforderungen umfassen 2FA seit mindestens 15 Tage aktiv; die letzte Passwortänderung vor mehr als 5 Tagen; sowie das Fehlen jeglicher Kontobeschränkungen wie Sperrungen, wirtschaftliche Verbote und Handelsverbote.

Wenn Sie alle oben genannten Anforderungen erfüllen, wird ASF regelmäßig mit unserer **[öffentlichen ASF STM Liste](#publiclisting)** kommunizieren, um aktiv die aktuell verfügbaren Bots abzugleichen.

Während des Abgleichs wird der ASF-Bot sein eigenes Inventar abrufen, dann kommunizieren Sie, mithilfe unseres Servers, mit ihm, um alle möglichen `MatchableTypes`-Treffer von anderen, derzeit verfügbaren Bots zu finden. Dank der direkten Kommunikation mit unserem Server, erfordert dieser Prozess nur eine einzige Anfrage und wir haben sofort die Information, ob irgendein verfügbarer Bot etwas Interessantes für uns bietet – sobald ein Treffer gefunden wird, sendet und bestätigt ASF das Handelsangebot automatisch.

Dieses Modul soll transparent sein. Der Abgleich beginnt ungefähr `1` Stunde nach ASF-Start und wird sich selbstständig alle `6` Stunden wiederholen (falls erforderlich). Die Funktion `MatchActively` soll als langfristige, periodische Maßnahme verwendet werden, um sicherzustellen, dass wir aktiv auf die Fertigstellung der Sets zusteuern. Diejenigen, die ASF nicht 24/7 verwenden, können auch erwägen, den **[Befehl](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-de-DE)** `match` zu verwenden. Die Zielanwender dieses Moduls sind primäre Konten und „versteckte“ Alt-Konten, obwohl es von jedem Bot verwendet werden kann, der nicht auf `MatchEverything` eingestellt ist. Zusätzlich werden Bots mit mehr als `500000` Gegenständen werden bei der Treffersuche aufgrund eines übermäßigen Überschusses nicht berücksichtigt. Wir empfehlen, Ihr Inventar in diesem Fall auf mehrere Konten aufzuteilen.

ASF gibt sein Bestes, um die Anzahl der Anfragen und den Druck, die durch die Verwendung dieser Option erzeugt werden, zu minimieren und gleichzeitig die Effizienz des Abgleichens zu maximieren. Der exakte Algorithmus, um die Bots miteinander abzugleichen und sonst den gesamten Prozess zu organisieren, ist ein Implementierungsdetail von ASF und kann sich in Bezug auf Feedback, Situation und mögliche zukünftige Ideen ändern.

Die aktuelle Version des Algorithmus lässt ASF `Any`-Bots zuerst priorisieren, insbesondere die mit einer besseren Spieleauswahl, mit deren Gegenständen. Wenn unter den verfügbaren (`Any`) keine Bots mehr übrig sind, wird ASF auf die fairen (`Fair`) nach der gleichen Diversitätsregel umstellen. ASF wird versuchen, jeden verfügbaren Bot mindestens einmal abzugleichen, um sicherzustellen, dass wir bei einem möglichen Set-Fortschritt nicht fehlen.

`MatchActively` berücksichtigt Bots, die Sie vom Handel über den `tbadd` **[Befehl](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-de-DE)** auf die schwarze Liste gesetzt haben und wird nicht versuchen, sie aktiv zu vergleichen. Dies kann verwendet werden, um ASF mitzuteilen, welche Bots nie verglichen werden sollen, auch wenn sie potenzielle Duplikate haben, die wir verwenden können.

ASF wird sein Bestes tun, um sicherzustellen, dass die Handelsangebote erfolgreich sind. Beim nächsten Durchlauf, welcher normalerweise in 6 Stunden andauert, wird ASF ausstehende Handelsangebote annullieren, die bislang nicht angenommen wurden und steamIDs als nicht dringend markieren, die an ihnen teilnehmen, um hoffentlich zuerst aktivere Bots zu bevorzugen. Wenn dennoch die letzten (und einzigen) Bots die benötigten Treffer haben, werden wir trotzdem versuchen, ihnen (erneut) zu entsprechen.

---

### Warum benötige ich eine `LicenseID` um `MatchActively` zu verwenden? War es nicht vorher kostenlos?

ASF ist und bleibt frei und Open-Source; wie es bereits zu Beginn des Projekts im Oktober 2015 gegründet wurde. Der Quellcode der `ItemsMatcher`-Erweiterung und daher ist die Funktion `MatchActively` in unserem Repository verfügbar, während das ASF-Programm nicht kommerziell ist; wir verdienen nichts aus Beiträgen zu diesem, dem Erstellen oder der Veröffentlichung. In den vergangenen 7+Jahren hat ASF eine enorme Entwicklung erfahren und es wird noch verbessert und mit jedem monatlichen stabilen Release vor allem von einer einzigen Person erweitert, **[JustArchi](https://github.com/JustArchi)** – ohne Bedingungen. Die einzige Förderung, die wir erhalten, besteht aus freiwilligen Spenden, die von unseren Nutzern kommen.

Bis Oktober 2022 war die Funktion `MatchActively` sehr lange Zeit Teil des ASF-Kerns und stand allen zur Verfügung. Im Oktober 2022 hat Valve, das Unternehmen hinter Steam, sehr strenge Grenzwerte für das Abrufen von Inventare anderer Bots gesetzt – was die vorherige Funktionalität völlig ruiniert hat, ohne die Möglichkeit einer Lösung, um dieses Problems zu beheben. Daher ist das Feature aufgrund der Tatsache, dass es völlig überholt ist, ohne die Chance auf eine Fehlerbehebung, musste dieses als veraltet aus dem ASF-Kern entfernt werden.

`MatchActively` wurde als Teil der offiziellen Erweiterung `ItemsMatcher` wiederbelebt, das ASF um die Funktionalität der aktiven Kartensuche ergänzt. Das Wiederaufleben des `MatchActively` Features erforderte von uns eine **außerordentliche Menge an Arbeit**, um das ASF-Backend zu erstellen, und das Bereitstellen eines komplett neuen Dienstes auf einem Server, mit mehr als hundert bezahlten Proxys zur Auflösung von Inventaren; alles ausschließlich, um ASF Clients die Möglichkeit zu bieten, `MatchActively` wie zuvor zu verwenden. Aufgrund des Arbeitsumfangs sowie der kostenpflichtigen Ressourcen (Domain, Server, Proxys; die monatlich von uns bezahlt werden müssen), haben wir uns entschlossen, diese Funktionalität unseren Sponsoren anzubieten, also den Menschen, die das ASF-Projekt bereits monatlich unterstützen, dank derer wir diese bezahlten Mittel zur Verfügung stellen können.

Unser Ziel ist es nicht, davon zu profitieren, sondern vielmehr die Deckung der **monatlichen Kosten**, die ausschließlich mit dem Angebot dieser Option verbunden sind – deshalb bieten wir sie grundsätzlich ohne Kosten an. Aber wir müssen ein wenig dafür berechnen, da wir nicht jeden Monat hunderte Dollar aus unserer eigenen Tasche bezahlen können, nur um es Ihnen zur Verfügung zu stellen. Wir sind auch nicht in der Lage, über den Preis zu verhandeln. Valve hat uns diese Kosten aufgezwungen, und die Alternative ist, diese Funktion überhaupt nicht verfügbar zu haben. Dies gilt natürlich, wenn Sie aus einem beliebigen Grund beschließen, dass Sie die Verwendung unserer Erweiterung zu diesen Bedingungen nicht rechtfertigen können.

Es ist uns bewusst, dass die `MatchActively` nicht für alle gilt, dennoch sind wir zuversichtlich, dass Sie nachvollziehen können, weshalb wir es nicht kostenlos anbieten können.

---

### Wie erhalte ich Zugriff?

`ItemsMatcher` wird als Teil der monatlichen Sponsoren-Stufe (Tier) von $5+ auf **[JustArchi’s GitHub](https://github.com/sponsors/JustArchi)** angeboten. Es ist auch möglich, ein einmaliger Sponsor zu werden, obwohl in diesem Fall die Lizenz nur für einen Monat gültig ist (mit Möglichkeit der Erweiterung auf die gleiche Weise). Sobald Sie ein Sponsor von 5 (oder höher) wurden, lesen Sie im **[Abschnitt nach, um die Konfiguration](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-de-DE#licenseid)** und das Ausfüllen der `Lizenz-ID` zu überprüfen. Danach müssen Sie nur `MatchActively` in den `TradingPreferences` Ihres ausgewählten Bots aktivieren.

Die Lizenz erlaubt es Ihnen, eine begrenzte Anzahl von Anfragen an den Server zu senden. $5 Stufe erlaubt Ihnen die Verwendung von `MatchActively` für ein Bot-Konto (4 Anfragen täglich); jede zusätzliche $5 fügt zwei weitere Bot-Konten hinzu (8 Anfragen täglich). Wenn Sie dies beispielsweise auf drei Konten ausführen möchten, wird dies durch $10 und höher gedeckt.