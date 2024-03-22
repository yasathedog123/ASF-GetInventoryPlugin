# Steam Familienbibliothek

ASF unterstützt die Steam Familienbibliothek – um zu verstehen, wie ASF damit umgeht, sollten Sie zunächst lesen wie die **[Steam-Familienbibliothek funktioniert](https://store.steampowered.com/promotion/familysharing)**, welche im Steam-Shop verfügbar ist.

---

## ASF

Die Unterstützung für das Steam-Familienbibliothek-Feature in ASF ist transparent, d.h. es werden keine neuen Bot/Prozesskonfigurationseigenschaften eingeführt – es funktioniert sofort als zusätzliche integrierte Funktionalität.

ASF beinhaltet eine entsprechende Logik, um zu erkennen, dass die Bibliothek von Familienmitgliedern gesperrt ist, sodass Sie nicht durch den Start eines Spiels aus der Spielsitzung geworfen werden. ASF verhält sich genau so, wie mit dem primären Konto, das die Sperre hält. Daher wird ASF, wenn diese Sperre entweder von Ihrem Steam-Client oder von einem der Benutzer Ihrer Familie gehalten wird nicht versuchen, einen Sammelprozess zu starten, sondern darauf warten, dass die Sperre freigegeben wird.

Zusätzlich zu den oben genannten Einstellungen greift ASF nach der Anmeldung auf Ihre **[Einstellungen zur Familienbibliothek](https://store.steampowered.com/account/managedevices)** zu, aus denen es bis zu 5 `steamIDs` extrahiert, die Ihre Bibliothek verwenden dürfen. Diese Benutzer erhalten die Berechtigung `FamilySharing` zur Verwendung von **[Befehlen](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-de-DE)**, insbesondere zur Verwendung des `pause~` Befehls auf einem Bot-Account, der Spiele mit diesen teilt. Dies ermöglicht es dem automatischen Karten-Sammel-Modul anzuhalten, um ein Spiel zu starten, das gemeinsam genutzt werden kann.

Die Verbindung beider oben erläuterten Funktionalitäten ermöglicht es Ihren Freunden, den `pause~` Befehl für Ihren Karten-Sammelprozess zu beginnen, ein Spiel zu starten, so lange zu spielen wie sie möchten; und schließlich, nachdem sie fertig gespielt haben, wird der Karten-Sammelprozess automatisch von ASF wieder aufgenommen. Natürlich ist das Senden von `pause~` nicht erforderlich, wenn ASF derzeit keinen aktiven Sammelprozess betreibt, da Ihre Freunde das Spiel sofort starten können und die oben erläuterte Logik stellt sicher, dass sie nicht aus der Sitzung geworfen werden.

---

## Einschränkungen

Das Steam-Netzwerk neigt dazu ASF falsche Statusupdates zu übermitteln. Dies lässt ASF unter Umständen glauben, der Account sei nicht in Nutzung. Die Folge: Der Freund wird frühzeitig aus seiner Spielsitzung geworfen. Dies ist das gleiche Problem, welches von uns bereits in **[diesem FAQ Artikel](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ-de-DE#asf-wirft-mich-aus-meiner-steam-client-sitzung-w%C3%A4hrend-ich-spiele--dieser-account-wird-an-einem-anderen-pc-verwendet)** erläutert wurde. Wir empfehlen die gleiche Lösung. Statten Sie Ihren Freund mit `Operator`-Rechten (oder höher) aus und informieren Sie diesen über die Nutzung der `pause` und `resume` Befehle.