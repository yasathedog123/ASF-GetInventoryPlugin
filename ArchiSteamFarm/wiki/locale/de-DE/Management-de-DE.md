# Verwaltung

Dieser Abschnitt beschäftigt sich mit dem Thema, den ASF-Prozess optimal zu verwalten. Obwohl es für die Nutzung nicht zwingend vorgeschrieben ist, enthält es eine Reihe von Tipps, Tricks und bewährten Praktiken, die wir teilen möchten, speziell für Systemadministratoren, Menschen, die ASF sowohl für den Einsatz in externen Repositories, als auch für fortgeschrittene Benutzer verpacken.

---

## `systemd` Dienst für Linux

In den `generic` und `Linux` Varianten kommt ASF mit der Datei `ArchiSteamFarm@.service`, welche eine Konfigurationsdatei des Dienstes für **[`systemd`](https://systemd.io)** ist. Wenn Sie ASF als Dienst ausführen möchten, zum Beispiel um ihn nach dem Start Ihres Gerätes automatisch auszuführen, dann ist ein richtiger `systemd` Dienst wohl der beste Weg, dies zu erreichen. Daher empfehlen wir dies dringend, anstatt sie durch `nohup`, `screen` oder ähnlichem selbst zu verwalten.

Zuerst erstellen Sie das Konto für den Benutzer, unter dem Sie ASF betreiben möchten (sofern es bislang nicht existiert). Wir verwenden für dieses Beispiel den Benutzer `asf`. Wenn Sie sich für einen anderen entschieden haben, müssen Sie `asf` in all unseren Beispielen durch Ihren ausgewählten Benutzer ersetzen. Unser Dienst erlaubt es Ihnen niemals, ASF mit `root` auszuführen, da es als **[schlechte Praxis](#f%C3%BChren-sie-asf-niemals-als-administrator-aus)** gilt.

```sh
su # ODER sudo -i, um in die Root-Shell zu gelangen
useradd -m asf # Erstellen Sie ein Konto unter dem Sie ASF ausführen wollen
```

Als nächstes entpacken Sie ASF in den Ordner `/home/asf/ArchiSteamFarm`. Die Ordnerstruktur ist wichtig für unsere Dienst-Einheit; es sollte der Ordner `ArchiSteamFarm` in Ihrem Startverzeichnis `$HOME` sein; also `/home/<user>`. Wenn Sie alles richtig gemacht haben, gibt es die Datei `/home/asf/ArchiSteamFarm/ArchiSteamFarm@.service`. Wenn Sie die Variante `linux` verwenden und die Datei nicht unter Linux entpackt haben (sondern zum Beispiel die Dateiübertragung von Windows nutzten), dann müssen Sie auch `chmod +x /home/asf/ArchiSteamFarm/ArchiSteamFarm` verwenden.

Wir werden alle folgenden Aktionen als `root` ausführen. Bitte wechseln Sie in der Shell mit` su` oder `sudo -i`.

Zunächst ist es eine gute Idee, sicherzustellen, dass unser Ordner noch zu unserem Benutzer `asf` gehört; dazu führen wir einmalig den Befehl `chown -hR asf:asf /home/asf/ArchiSteamFarm` aus. Die Berechtigungen könnten falsch sein, z. B. wenn Sie die Zip-Datei als `root` heruntergeladen und/oder entpackt haben.

Außerdem, falls Sie eine generische ASF-Variante verwenden, müssen Sie sicherstellen, dass der Befehl `dotnet` erkannt wird und innerhalb eines der Standardorte: `/usr/local/bin`, `/usr/bin` oder `/bin` ist. Dies ist für unseren systemd-Dienst erforderlich, welcher den Befehl `dotnet /pfad/zur/ArchiSteamFarm.dll` ausführt. Überprüfen Sie, ob `dotnet --info` für Sie funktioniert; falls ja, geben Sie `command -v dotnet` ein, um herauszufinden, wo es sich befindet. Falls Sie den offiziellen Installationsassistenten verwendet haben, sollte es sich wie gewünscht entweder unter `usr/bin/dotnet` oder einem der beiden anderen Verzeichnisse vorhanden sein. Bei Verwendung eines benutzerdefinierten Ortes (z. B. `/usr/share/dotnet/dotnet/`) erstellen wir dafür einen **[Symlink](https://de.wikipedia.org/wiki/Symbolische_Verkn%C3%BCpfung)** mit `ln -s "$(command -v dotnet)" /usr/bin/dotnet`. Nun sollte `command -v dotnet` `/usr/bin/dotnet` anzeigen, womit auch unsere systemd-Einheit funktioniert. Wenn Sie eine OS-spezifische Version verwenden, müssen Sie sich keine Gedanken darüber machen.

Als Nächstes führen Sie `ln -s /home/asf/ArchiSteamFarm/ArchiSteamFarm\@.service /etc/systemd/system/ArchiSteamFarm\@.service` aus. Dies erstellt einen symbolischen Link zu unserer Dienst-Deklaration und registriert ihn in `systemd`. Der symbolische Link wird es ASF erlauben, Ihre `systemd` Einheit automatisch als Teil des ASF Updates zu aktualisieren – je nach Situation. Sie können diesen Ansatz verwenden oder einfach `cp` die Datei verwenden und sie selbst verwalten, sofern Sie möchten.

Stellen Sie anschließend sicher, dass `systemd` unseren Dienst erkennt:

```
systemctl status ArchiSteamFarm@asf

○ ArchiSteamFarm@asf.service – ArchiSteamFarm Service (on asf)
   Loaded: loaded (/etc/systemd/system/ArchiSteamFarm@.service; disabled; vendor preset: enabled)
   Active: inactive (dead)
    Docs: https://github.com/JustArchiNET/ArchiSteamFarm/wiki
```

Achten Sie besonders auf den Benutzer, den wir nach `@` deklarieren, es ist in unserem Fall `asf`. Unsere System-Service-Einheit bittet Sie, den Benutzer anzugeben. Dies wird sowohl den genauen Ort der Binärdatei `/home/<user>/ArchiSteamFarm`, als auch den eigentlichen systemd-Startprozess des Benutzers beeinflussen.

Wenn systemd die Ausgabe ähnlich wie oben zurückgibt, ist alles in Ordnung, und wir sind fast fertig. Jetzt bleibt uns nur noch, unseren Dienst mit unserem gewählten Benutzer zu starten: `systemctl start ArchiSteamFarm@asf`. Warten Sie ein oder zwei Sekunden, um den Status erneut zu überprüfen:

```
systemctl status ArchiSteamFarm@asf

● ArchiSteamFarm@asf.service – ArchiSteamFarm Service (on asf)
   Loaded: loaded (/etc/systemd/system/ArchiSteamFarm@.service; disabled; vendor preset: enabled)
   Active: active (running) since (...)
       Docs: https://github.com/JustArchiNET/ArchiSteamFarm/wiki
  Main PID: (...)
(...)
```

Wenn `systemd` `active (running)` angibt, bedeutet es, dass alles gut gelaufen ist und Sie überprüfen können, ob der ASF-Prozess gestartet werden sollte, zum Beispiel mit `Journalctl -r`, da ASF standardmäßig auch auf seine Konsolenausgabe schreibt, die von `systemd` aufgezeichnet wird. Sollten Sie mit der aktuellen Einrichtung zufrieden sein, können Sie `systemd` mitteilen, den Dienst automatisch beim Booten zu starten, indem Sie den Befehl `systemctl enable ArchiSteamFarm@asf` ausführen. Das war’s!

Den Prozess können Sie bedarfsweise mit `systemctl stop ArchiSteamFarm@asf` anhalten. Genauso, wenn Sie ASF beim Booten deaktivieren wollen – `systemctl disable ArchiSteamFarm@asf` wird das für Sie erledigen, es ist sehr einfach.

Da jedoch keine Standardeingabe für unseren `systemd` Dienst aktiviert ist, gilt es zu beachten, dass Sie Ihre Daten nicht in gewohnter Weise über die Konsole eingeben können. Die Ausführung über `systemd` ist gleichbedeutend mit der Angabe der Einstellung **[`Headless: true`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-de-DE#headless)** und kommt mit all seinen Implikationen. Zum Glück für Sie ist es sehr einfach, ASF über die **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-de-DE#asf-ui)** zu verwalten, welche wir empfehlen, falls Sie weitere Details beim Anmeldevorgang angeben oder Ihren ASF-Prozess anderweitig weiter verwalten müssen.

### Umgebungsvariablen

Es ist möglich, zusätzliche Umgebungsvariablen für unseren `systemd`-Dienst bereitzustellen. Das ist für Sie interessant, wenn Sie etwa ein benutzerdefiniertes `--cryptkey` **[Befehlszeilenargument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments-de-DE#argumente)** verwenden möchten – spezifizieren Sie daher `ASF_CRYPTKEY` Umgebungsvariable.

Um benutzerdefinierte Umgebungsvariablen bereitzustellen, muss der Ordner `/etc/asf` (falls er nicht existiert), mit `mkdir -p /etc/asf` erstellt werden. Wir empfehlen `chown -hR root:root /etc/asf && chmod 700 /etc/asf`, um sicherzustellen, dass nur der Benutzer `root` Zugang zum Lesen dieser Dateien hat; da diese empfindliche Eigenschaften (z. B. `ASF_CRYPTKEY`) enthalten könnten. Anschließend schreiben Sie in die Datei `/etc/asf/<user>`, in welcher `<user>` der Anwender ist, unter dem Ihr Dienst ausgeführt wird (in unserem Beispiel `asf`, folglich `/etc/asf/asf`).

Die Datei sollte alle Umgebungsvariablen enthalten, die Sie dem Prozess zur Verfügung stellen möchten. Diejenigen, die keine eigene Umgebungsvariable haben, können in `ASF_ARGS` deklariert werden:

```sh
# Definieren Sie jene die Sie tatsächlich benötigen
ASF_ARGS="--no-config-migrate --no-config-watch"
ASF_CRYPTKEY="my_super_important_secret_cryptkey"
ASF_NETWORK_GROUP="my_network_group"

# Und alle anderen in die Sie interessiert sind
```

### Überschreibung eines Teils der "Service unit" (Dienstverwaltung)

Dank der Flexibilität von `systemd` ist es möglich, einen Teil der ASF-Einheit zu überschreiben, während dabei die Originaldatei zu bewahrt wird und ASF zum Beispiel als Teil von Auto-Updates sich zu aktualisieren.

In diesem Beispiel möchten wir das Standardverhalten (nur bei Erfolg neu starten) von ASF in `systemd` ändern, um den Neustart auch bei fatalen Abstürzen zu ermöglichen. Wir überschreiben dazu die Funktion `Restart` des `[Service]` vom Standard (`on-success`) und verwenden stattdessen `always`. Führen Sie einfach `systemctl edit ArchiSteamFarm@asf` aus; natürlich muss `asf` durch den Zielbenutzer Ihres Dienstes ersetzt werden. Fügen Sie dann Ihre Änderungen, wie sie von `systemd` angegeben wurden, in den richtigen Abschnitt ein:

```sh
### Bearbeite /etc/systemd/system/ArchiSteamFarm@asf.service.d/override.conf
### Alles zwischen diesem Kommentar und unten wird zur neuen Datei

[Service]
Restart=always

### Zeilen werden verworfen

### /etc/systemd/system/ArchiSteamFarm@asf.service
# [Install]
# WantedBy=multi-user.target
# 
# [Service]
# EnvironmentFile=-/etc/asf/%i
# ExecStart=dotnet /home/%i/ArchiSteamFarm/ArchiSteamFarm.dll --no-restart --process-required --service --system-required
# Restart=on-success
# RestartSec=1s
# SyslogIdentifier=asf-%i
# User=%i
# (...)
```

Und das war es. Jetzt agiert Ihre Einheit so, als hätte sie nur `Restart=always` unter `[Service]`.

Natürlich können Sie alternativ die Datei `cp` (kopieren) und selbst verwalten; allerdings ermöglicht die ursprüngliche ASF-Einheit (z. B. mit einem **[Symlink](https://de.wikipedia.org/wiki/Symbolische_Verkn%C3%BCpfung)**) Ihnen flexible Änderungen vorzunehmen, wenn Sie sich entschieden haben, dieses Original zu behalten.

---

## Führen Sie ASF niemals als Administrator aus!

ASF enthält eine eigene Validierung, ob der Prozess als Administrator ausgeführt wird (`root`) oder nicht. Die Ausführung als `root` ist für **keine** Operation des ASF-Prozesses erforderlich; vorausgesetzt, die Umgebung ist richtig konfiguriert, in der sie aktiv ist, sollte die Ausführung unter `root` daher als eine **schlechte Praxis** angesehen werden. Es ist wichtig, dass ASF unter Windows** niemals** mit der Einstellung „als Administrator ausführen“ gestartet wird und unter Unix ASF sollte ein **eigenes Benutzerkonto für sich selbst** existieren, oder wiederverwenden Sie Ihr eigenes im Falle eines Desktop-Systems.

Für weitere Erläuterungen dazu, *warum* wir die Ausführung von ASF als `root` nicht empfehlen, können Sie **[Superuser](https://stackovercoder.com.de/superuser/218379/why-is-it-bad-to-run-as-root)** und andere Ressourcen nachschlagen. Falls Sie weiterhin nicht überzeugt sind, fragen Sie sich, was mit Ihrem Gerät passieren würde, wenn der ASF-Prozess direkt nach dem Start den Befehl `rm -rf /*` ausführt.

### Ich nutze `root`, weil ASF nicht in seine Dateien schreiben kann

Das bedeutet, dass Sie falsch konfigurierte Datei-Berechtigungen haben, auf die ASF zugreifen möchte. Sie sollten sich als Anwender `root` anmelden (entweder mit `su` oder `sudo - i`) und dann die Berechtigung über den Befehl `chown -hR asf:asf /path/to/ASF` **korrigieren ** – ersetzen Sie `asf:asf` mit dem Benutzer, unter dem Sie ASF ausführen und `/path/to/ASF` entsprechend. Wenn Sie zufällig einen benutzerdefinierten `--path` verwenden und ASF Benutzer auffordern, das andere Verzeichnis zu verwenden, sollten Sie den gleichen Befehl auch für diesen Pfad erneut ausführen.

Danach sollten Sie keine Schwierigkeiten mehr haben, die damit zusammenhängen, dass ASF nicht in der Lage ist, über seine eigenen Dateien zu schreiben; weil Sie soeben den Besitzer von allem, was ASF interessiert, für den Benutzer geändert haben.

### Ich verwende `root`, weil ich nicht weiß, wie ich es sonst tun soll

```sh
su # oder sudo -i, um in die Root-Shell zu gelangen
useradd -m asf # Erstelle einen Account den Sie unter
chown -hR asf:asf /path/zu/ASF ausführen möchten # Stellen Sie sicher dass Ihr neuer Benutzer Zugriff auf das ASF-Verzeichnis hat
su asf -c /path/zu/ASF/ArchiSteamFarm hat # Oder sudo -u asf /path/zu/ASF/ArchiSteamFarm um das Programm tatsächlich unter Ihrem Benutzer zu starten
```

Dies würde manuell erfolgen, es ist viel einfacher, unseren **[`systemd`-Dienst](#systemd-Dienst-f%C3%BCr-linux)** (Erläuterung oben) zu nutzen.

### Ich weiß es besser und möchte trotzdem `root` nutzen

ASF hält Sie nicht zwingend davon ab, dies zu tun, und zeigt nur kurzfristig eine Warnung an. Seien Sie einfach nicht schockiert, wenn es eines Tages aufgrund eines Fehlers im Programm Ihr gesamtes Betriebssystem mit dem vollständigen Datenverlust sprengt – Sie wurden gewarnt!

---

## Mehrere Instanzen

ASF unterstützt das Ausführen mehrerer Instanzen des Prozesses auf demselben Gerät. Die Instanzen können komplett eigenständig oder von demselben binären Speicherort abgeleitet werden. In diesem Fall sollten Sie sie mit einem anderen **[Kommandozeilenargument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments-de-DE)** `--path` ausführen.

Wenn Sie mehrere Instanzen von derselben Binärdatei ausführen, ist zu beachten, dass das normalerweise automatische Updates deaktiviert werden sollte, da es keine Synchronisation zwischen diese in Bezug auf Auto-Updates gibt. Wenn Sie automatische Updates aktivieren möchten, empfehlen wir eigenständige Instanzen; aber Sie können trotzdem dafür sorgen, dass Updates funktionieren, solange Sie sicherstellen, dass alle anderen ASF-Instanzen geschlossen sind.

ASF wird sein Bestes geben, um eine minimale Menge an OS-übergreifender Kommunikation mit anderen ASF-Instanzen zu pflegen. Dazu gehört die Überprüfung des Konfigurationsverzeichnisses mit denen anderer Instanzen, sowie die Freigabe prozessweiter Begrenzungen mit der **[globaler Konfigurationsvariable](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-de-DE#globale-konfiguration)** `*LimiterDelay`, um sicherzustellen, dass das Ausführen mehrerer ASF-Instanzen kein Anfragelimit auslöst. In Bezug auf technische Aspekte verwenden alle Plattformen unseren dedizierten Mechanismus von benutzerdefinierten ASF-Dateisperren, die im temporären Verzeichnis erstellt wurden, `C:\Users\<YourUser>\AppData\Local\Temp\ASF` unter Windows, und `/tmp/ASF` unter Unix.

Es ist nicht erforderlich die gleiche `*LimiterDelay` Eigenschaft zu teilen, um ASF Instanzen auszuführen; sie können verschiedene Werte verwenden, da jede ASF nach dem Erwerb der Sperre seine eigene konfigurierte Verzögerung zur Release-Zeit hinzufügt. Wenn `*LimiterDelay` auf `0` gesetzt ist, wird die ASF-Instanz das Warten auf die Sperre der angegebenen Ressource, die mit anderen Instanzen geteilt wird, überspringen (was möglicherweise immer noch eine gemeinsame Sperre untereinander aufrechterhalten könnte). Sofern auf einen beliebigen anderen Wert gesetzt, wird ASF sich korrekt mit anderen ASF-Instanzen synchronisieren, und wartet bis es an der Reihe ist, bevor es dann nach konfigurierter Verzögerung die Sperre aufhebt, wodurch andere Instanzen fortfahren können.

ASF berücksichtigt die `WebProxy` Einstellung bei der Entscheidung über den gemeinsamen Anwendungsbereich, was bedeutet, dass zwei ASF-Instanzen, die verschiedene `WebProxy` Konfigurationen verwenden, Ihre Begrenzungen nicht untereinander teilen werden. Dies wird implementiert, um `WebProxy`-Einrichtungen eine möglichst latenzarme Arbeitsumgebung zu bieten – wie von verschiedenen Netzwerkschnittstellen erwartet. Dies sollte für die Mehrzahl der Anwendungsfälle gut genug sein. Wenn Sie jedoch eine spezifische Benutzerkonfiguration haben, in der Sie z. B. Anfragen über eine bestimmte Netzwerkgruppe weiterleiten, können Sie das **[Kommandozeilenargument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments-de-DE)**`--network-group` angeben, welches Ihnen erlaubt, eine ASF-Gruppe zu deklarieren, die mit dieser Instanz synchronisiert wird. Beachten Sie, dass ausschließlich benutzerdefinierte Netzwerkgruppen verwendet werden. Das bedeutet, dass ASF `WebProxy` nicht mehr zur Bestimmung der richtigen Gruppe verwenden wird, da Sie für die Gruppierung in diesem Fall verantwortlich sind.

Wenn Sie unseren **[`systemd`-Dienst](#systemd-Dienst-f%C3%BCr-linux)** wie oben erläutert für mehrere ASF-Instanzen verwenden möchten, ist dies sehr einfach. Verwenden Sie einfach einen anderen Benutzer für unsere `ArchiSteamFarm@` Dienst-Deklaration und folgen Sie mit den verbleibenden Schritten. Dies entspricht dem Ausführen mehrerer ASF-Instanzen mit unterschiedlichen Binärdateien, sodass diese auch unabhängig voneinander funktionieren und sich aktualisieren können.