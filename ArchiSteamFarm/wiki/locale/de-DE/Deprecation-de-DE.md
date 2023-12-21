# Veraltete Funktionen

Wir tun unser Bestes, um die konsequente Verfallspolitik zu verfolgen, um sowohl die Entwicklung , als auch die Nutzung wesentlich konsistenter zu gestalten.

---

## Was ist Verfall (engl. Deprecation)?

Verfall (engl. Deprecation) beschreibt den Prozess kleinerer oder größerer Änderungen, die zuvor verwendete Optionen, Argumente, Funktionalitäten oder Anwendungsfälle obsolet machen. Verfall bedeutet in der Regel, dass eine bestimmte Sache einfach in eine andere (ähnliche) Form umgeschrieben wurde und Sie sollten rechtzeitig dafür sorgen, dass Sie sie entsprechend umstellen. In diesem Fall geht es einfach darum, die gegebene Funktionalität an einen geeigneteren Ort zu verlagern.

ASF verändert sich schnell und strebt immer danach besser zu werden. Dies bedeutet leider, dass wir eventuell einige bestehende Funktionen ändern oder in ein anderes Teilstück des Programms verschieben müssen, damit es von neuen Funktionen, Kompatibilität oder Stabilität profitieren kann. Dank dessen müssen wir nicht an veralteten oder einfach schmerzhaft falschen Entscheidungen festhalten, die wir vor Jahren getroffen haben. Wir versuchen immer einen vernünftigen Ersatz anzubieten, der der erwarteten Nutzung der zuvor verfügbaren Funktionalität entspricht, weshalb der Verfall (engl. Deprecation) meist harmlos ist und kleine Korrekturen für die vorherige Benutzung erfordert.

---

## Verfallsstufen

ASF wird zwei Phasen des Verfalls (engl. Deprecation) folgen, die den Übergang viel einfacher und weniger lästig machen.

### Stufe 1

Stufe 1 tritt ein, wenn ein bestimmtes Feature veraltet ist, mit sofortiger Verfügbarkeit einer anderen Lösung (oder keiner, wenn es keine Pläne zur Wiedereinführung gibt).

Während dieser Phase gibt ASF eine entsprechende Warnung aus, wenn die veraltete Funktion verwendet wird. Solange es möglich ist, wird ASF versuchen das alte Verhalten nachzuahmen und damit kompatibel zu bleiben. ASF wird in Bezug auf diese Funktionalität mindestens bis zur nächsten stabilen Version in Stufe 1 bleiben. Dies ist der Moment, in dem Sie, hoffentlich ohne die Kompatibilität zu beeinträchtigen, in all Ihren Programmen und Strukturen den richtigen Wechsel vornehmen können, um dem neuen Verhalten zu entsprechen. Sie können bestätigen, ob Sie alle entsprechenden Änderungen vorgenommen haben, indem Sie die Verfallswarnung nicht mehr angezeigt bekommen.

### Stufe 2

Stufe 2 ist geplant, nachdem die oben erläuterte Stufe 1 stattgefunden hat und wird in einer stabilen Version freigegeben. In diesem Abschnitt wird die vollständige Entfernung der veralteten Feature-Existenz eingeführt. Das bedeutet, dass ASF nicht einmal bestätigt, dass Sie veraltete Features verwenden, geschweige denn sie anerkennen, da sie im aktuellen Code einfach nicht existieren. ASF gibt keine Warnung mehr aus, da es nicht mehr erkennt was Sie beabsichtigen.

---

## Zusammenfassung

Sie haben mehr oder weniger einen **ganzen Monat** um einen entsprechenden Wechsel vorzunehmen, was mehr als genug sein sollte, selbst wenn Sie ein gelegentlicher ASF-Benutzer sind. Nach Ablauf dieses Zeitraums garantiert ASF nicht mehr, dass alte Einstellungen funktionieren (Stufe 2), wodurch bestimmte Funktionen wirkungsvoll abgeschaltet werden, ohne dass Sie es bemerken. Wenn Sie ASF nach mehr als einem Monat Inaktivität starten, wird empfohlen, **[von Grund auf neu zu beginnen](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up-de-DE)**, oder alle verpassten Änderungsprotokolle zu lesen und Ihre Nutzung manuell an die aktuelle anzupassen.

In den meisten Fällen wird die Missachtung der Verfallswarnung die allgemeine ASF-Funktionalität nicht beeinträchtigen, sondern auf das Standardverhalten zurückgreifen (welches möglicherweise nicht mit Ihren persönlichen Präferenzen übereinstimmt).

---

## Beispiel

Wir haben das in V3.1.2.2 enthaltenen **[Befehlszeilenargument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments-de-DE)** `--server` in die **[globale Konfigurationseigenschaft](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-de-DE#globale-konfiguration)** verschoben.

### Stufe 1

Stufe 1 fand in der Version V3.1.2.2 statt, wo wir der Verwendung von `--server` eine entsprechende Warnung hinzugefügt haben. Das jetzt veraltete Argument `--server` wurde automatisch als die globale Konfigurationseigenschaft `IPC: true` übernommen, die vorerst genau so funktioniert wie der alte Schalter `--server`. Dies ermöglichte es jedem einen entsprechenden Wechsel vorzunehmen, bevor ASF die Verwendung des alten Arguments einstellt.

### Stufe 2

Stufe 2 fand in der Version V3.1.3.0 statt, direkt nach der stabilen V3.1.2.9 mit Stufe 1, wie oben erläutert. Stufe 2 hatte zur Folge, dass ASF das Argument `--server` überhaupt nicht mehr anerkannte und es wie jedes andere ungültig übergebene Argument, welches keine Auswirkungen auf das Programm mehr hat, behandelte. Für diejenige, die immer noch nicht `--server` in `IPC: true` geändert haben, führte dies dazu, dass IPC ganz und gar nicht mehr funktionierte, da ASF keine entsprechende Zuordnung mehr durchführte.