# Docker

ASF ist als **[Docker Container](https://www.docker.com/what-container)** verfügbar. Unsere DockerPakete sind derzeit auf **[ghcr.io](https://github.com/JustArchiNET/ArchiSteamFarm/pkgs/container/archisteamfarm)** sowie im **[Docker Hub](https://hub.docker.com/r/justarchi/archisteamfarm)** verfügbar.

Es ist wichtig zu beachten, dass ASF im Docker Container als **erweitertes Setup** angesehen wird, was für die überwiegende Mehrheit der Benutzer **nicht benötigt wird** und gibt in der Regel **keine Vorteile** gegenüber einer containerlosen Einrichtung. Wenn Sie Docker als eine Lösung für den Betrieb von ASF als Dienst betrachten, zum Beispiel indem Sie ihn automatisch mit Ihrem Betriebssystem starten, dann sollten Sie möglicherweise stattdessen den Abschnitt **[Verwaltung](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management-de-DE#systemd-service-f%C3%BCr-linux)** lesen, und einen korrekten `systemd` Dienst einrichten, der **fast immer** eine bessere Lösung ist, als ASF in einem Docker Container auszuführen.

Die Ausführung von ASF im Docker-Container beinhaltet in der Regel **mehrere neue Probleme und Probleme**, die Sie selbst bewältigen und lösen müssen. Aus diesem Grund empfehlen wir Ihnen **sehr** dies zu vermeiden; es sei denn, Sie haben bereits Docker-Kenntnisse und benötigen keine Hilfe beim Verständnis seiner internen Daten, über die wir hier im ASF Wiki nicht eingehen. Dieser Abschnitt ist hauptsächlich für gültige Anwendungsfälle sehr komplexer Setups. Zum Beispiel in Bezug auf erweiterte Vernetzung oder Sicherheit über Standard-Sandboxing hinaus, die ASF im `systemd` Dienst beinhaltet (der bereits eine überlegene Prozessisolierung durch sehr fortgeschrittene Sicherheitsmechanismen sicherstellt). Für diese wenigen Nutzer erklären wir hier bessere ASF-Konzepte in bezüglich der Docker-Kompatibilität und nur das. Voraussetzung ist, dass Sie selbst über adäquate Docker Kenntnisse verfügen, wenn Sie sich dafür entscheiden, es zusammen mit ASF zu verwenden.

---

## *Tags*

ASF ist über vier Haupttypen von ***[Tags](https://hub.docker.com/r/justarchi/archisteamfarm/tags)*** verfügbar:


### `main`

Dieser *Tag* verweist immer auf den ASF, der vom letzten Commit (Änderung) im `main` erstellt wurde; was genauso funktioniert, wie das Erfassen neuester Artefakte direkt aus unserer **[CI](https://github.com/JustArchiNET/ArchiSteamFarm/actions/workflows/publish.yml?query=branch%3Amain)** Pipeline. Normalerweise sollten Sie dieses *Tag* vermeiden, da es die höchste Stufe von fehlerhafter Software ist, die für Entwickler und fortgeschrittene Benutzer zu Entwicklungszwecken bestimmt ist. Das Image (Abbild) wird mit jedem Commit im `main`-GitHub-Zweig aktualisiert, daher können Sie hier sehr oft mit Updates (und Problemen) rechnen. Es liegt an uns, den aktuellen Stand des ASF-Projekts zu markieren, der nicht unbedingt garantiert stabil oder getestet ist, wie in unserem Veröffentlichungszyklus dargelegt. Dieses *Tag* sollte nicht in einer Produktionsumgebung verwendet werden.


### `released`

Sehr ähnlich wie oben, zeigt dieser *Tag* immer auf die neueste **[veröffentlichte](https://github.com/JustArchiNET/ArchiSteamFarm/releases)** ASF-Version (einschließlich Vorabversionen). Im Vergleich zum `main`-*Tag* wird dieses Image (Abbild) jedes Mal aktualisiert, wenn ein neuer GitHub-*Tag* gepusht (verfügbar) wird. Geeignet für Fortgeschrittene und Power-User, die es lieben, am Rande dessen zu leben, was als stabil und zugleich frisch angesehen werden kann. Dies würden wir empfehlen, wenn Sie nicht den `latest` *Tag* verwenden möchten. In der Praxis funktioniert es genauso wie ein fortlaufender *Tag* mit dem Hinweis auf die neueste `A.B.C.D` Version zum Zeitpunkt des Downloads (`pull`). Bitte bedenken Sie, dass die Verwendung dieses *Tags* gleichbedeutend mit der Verwendung unserer **[Vorveröffentlichungen](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Release-cycle-de-DE)** ist.


### `latest`

Unter den verfügbaren **Tags** ist dieses das Einzige, welches automatische Updates enthält und auf die **[stabile](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** ASF-Version verweist. Der Zweck dieses **Tags** ist es, einen funktionierenden (Standard)-Docker-Container zur Verfügung zu stellen, der selbstständig in der Lage ist, eine aktualisierte, OS-spezifische ASF-Instanz auszuführen. Dadurch muss das Image (Abbild) nicht so oft auf den neuesten Stand gebracht werden, da die enthaltene ASF-Version immer in der Lage ist, sich bei Bedarf selbst zu aktualisieren. Natürlich kann `UpdatePeriod` problemlos ausgeschaltet werden (eingestellt auf `0`), aber in diesem Fall sollten Sie wahrscheinlich stattdessen die eingefrorene Version `A.B.C.D` verwenden. Ebenso können Sie den Standard `UpdateChannel` ändern, um stattdessen ein automatisches Aktualisieren des `released` *Tags* durchzuführen.

Aufgrund der Tatsache, dass die Version `latest` automatisch aktualisiert werden kann, enthält es ein spärliches Betriebssystem, inklusive einer OS-spezifischen `Linux` ASF Version; im Gegensatz zu allen anderen *Tags*, die OS mit .NET Runtime und `generic` ASF Version beinhalten. Dies liegt daran, dass eine neuere (aktualisierte) ASF-Version möglicherweise auch eine neuere Laufzeitumgebung erfordert als die, mit der das Build kompiliert werden könnte. Ansonsten würde dies einen Neuaufbau des Images von Grund auf erfordern, wodurch der geplante Anwendungsfall hinfällig wäre.

### `A.B.C.D`

Im Vergleich zu den oben genannten *Tags* ist dieser *Tag* vollständig eingefroren, was bedeutet, dass das Image (Abbild) nach der Veröffentlichung nicht mehr aktualisiert wird. Dies funktioniert ähnlich wie bei unseren GitHub-Versionen, die nach der ersten Version nie wieder berührt werden, was Ihnen eine stabile und gefrorene Umgebung garantiert. Normalerweise sollten Sie dieses *Tag* verwenden, wenn Sie eine bestimmte ASF-Version verwenden und auf automatische Aktualisierungen verzichten möchten (die beispielsweise im *Tag* `latest` angeboten werden).

---

## Welcher *Tag* ist für mich der Beste?

Das hängt davon ab, wonach Sie suchen. Für die Mehrheit der Benutzer sollte das `latest` *Tag* das Beste sein, da es genau das bietet, was Desktop-ASF bietet, nur eben als Dienst in einem speziellen Docker-Container. Nutzer, die Ihre Images oft neu erstellen und stattdessen lieber die volle Kontrolle über die ASF-Version haben, die an diese Veröffentlichung gebunden ist, können das `released` *Tag* verwenden. Wenn Sie stattdessen eine bestimmte eingefrorene ASF-Version verwenden möchten, die sich ohne Ihre eindeutige Absicht nie ändern wird, stehen Ihnen `A.B.C.D` Versionen als feste ASF-Meilensteine zur Verfügung, auf die Sie immer zurückgreifen können.

Wir raten generell davon ab, `main` Builds auszuprobieren, da diese für uns hier sind, um den aktuellen Stand des ASF-Projekts zu kennzeichnen. Nichts garantiert, dass ein solcher Zustand ordnungsgemäß funktioniert, aber natürlich können Sie ihn gerne ausprobieren, wenn Sie an der ASF-Entwicklung interessiert sind.

---

## Architekturen

ASF Docker Image (Abbild) ist derzeit auf `Linux` Plattform für 3 Architekturen verfügbar – `x64`, `arm` und `arm64`. Sie können im Abschnitt **[Kompatibilität](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility-de-DE)** mehr darüber lesen.

Unsere *Tag(s)* verwenden das Multi-Plattform-Manifest, was bedeutet, dass Docker auf Ihrem Gerät automatisch das passende Image (Abbild) für Ihre Plattform auswählt, wenn Sie dieses herunterladen. Wenn Sie ein bestimmtes Plattform-Image (Abbild) beziehen möchten, welches nicht dem entspricht, das Sie gerade verwenden, können Sie dies mittels `--platform` in den geeigneten Docker-Befehlen erreichen, wie zum Beispiel `Docker run`. Mehr Informationen hierzu finden Sie in der Docker Dokumentation unter **[image manifest](https://docs.docker.com/registry/spec/manifest-v2-2)**.

---

## Nutzung

Für eine vollständige Referenz sollten Sie die **[offizielle Docker-Dokumentation](https://docs.docker.com/engine/reference/commandline/docker)** verwenden. Wir werden in diesem Leitfaden nur die grundlegende Anwendung behandeln. Sie sind herzlich dazu eingeladen, Ihr Wissen zu vertiefen.

### Hallo ASF!

Zuallererst sollten wir überprüfen, ob unser Docker momentan überhaupt funktioniert. Das wird als unser ASF „Hallo Welt“ dienen:

```shell
docker run -it --name asf --pull always --rm justarchi/archisteamfarm
```

`docker run` erstellt einen neuen ASF Docker-Container für Sie und führt ihn im Vordergrund aus (`-it`). `--pull always` sorgt dafür, dass das aktuelle Image (Abbild) zuerst bezogen und `--rm` stellt sicher, dass unser Container nach dem Stoppen gereinigt wird, da wir gerade testen, ob alles im Moment gut funktioniert.

Wenn alles erfolgreich geendet hat, nachdem Sie alle Schichten und den Start-Container geholt haben, sollten Sie feststellen, dass ASF richtig gestartet wurde und uns mitgeteilt hat, dass es keine definierten Bots gibt; was gut ist – wir haben verifiziert, dass ASF im Docker richtig funktioniert. Drücken Sie `STRG + C` um den ASF-Prozess und damit auch den Container zu beenden.

Wenn Sie sich den Befehl genauer ansehen, werden Sie feststellen, dass wir kein *Tag* deklariert haben, da es automatisch auf `latest` voreingestellt ist. Sofern Sie ein anderes Schlagwort als `latest` verwenden möchten, zum Beispiel `released`, dann sollten Sie es explizit erklären:

```shell
docker run -it --name asf --pull always --rm justarchi/archisteamfarm:released
```

---

## Verwendung eines Volumes (Laufwerk)

Wenn Sie ASF im Docker-Container verwenden, dann müssen Sie natürlich das Programm selbst konfigurieren. Sie können es auf verschiedene Weise erreichen, aber die empfohlene wäre, das ASF `config` Verzeichnis auf dem lokalen Geräte zu erstellen und es dann als gemeinsames Volume (Laufwerk) im ASF-Docker-Container zu mounten.

Zum Beispiel gehen wir davon aus, dass sich Ihr ASF-Konfigurationsordner im Verzeichnis `/home/archi/ASF/config` befindet. Dieses Verzeichnis enthält den Kern `ASF.json` sowie Bots, die wir ausführen möchten. Jetzt müssen wir nur noch dieses Verzeichnis als Shared Volume (gemeinsames Laufwerk) in unserem Docker-Container anhängen, wo ASF sein Konfigurationsverzeichnis erwartet (`/app/config`).

```shell
docker run -it -v /home/archi/ASF/config:/app/config --name asf --pull always justarchi/archisteamfarm
```

Und das war’s! Jetzt verwendet Ihr ASF-Docker-Container das freigegebene Verzeichnis mit Ihrem lokalen Geräte im Lese-/Schreibmodus, was alles ist, was Sie für die Konfiguration von ASF brauchen. Auf ähnliche Weise können Sie andere Volumes einhängen, die Sie mit ASF teilen möchten (wie `/app/logs` oder `/app/plugins`).

Natürlich ist dies nur ein konkreter Weg, um das zu erreichen, was wir möchten. Nichts hält Sie davon ab, z. B. eine eigene `Dockerfile` zu erstellen, die Ihre Konfigurationsdateien in das Verzeichnis `/app/config` im ASF Docker-Container kopiert. Wir behandeln in diesem Leitfaden nur die grundlegende Anwendung.

### Zugriffsrechte für Volumes

ASF Container wird standardmäßig mit dem Standardbenutzer `root` initialisiert, die es ihm erlaubt, die interne Berechtigung zu handhaben und schließlich für den verbleibenden Teil des Hauptprozesses zu `asf` (UID `1000`) wechseln. Während dies für die große Mehrheit der Benutzer zufriedenstellend sein sollte; es wirkt sich auf das geteilte Volume (Laufwerk) aus, da neu generierte Dateien normalerweise im Besitz von `asf` sind. Dies könnte unerwünscht sein, wenn Sie einen anderen Benutzer für Ihr geteiltes Volume (Laufwerk) möchten.

Es gibt zwei Wege, um den Benutzer ASF zu ändern. Die Erste – empfohlene – ist die Umgebungsvariable `ASF_USER` mit Ziel-UID zu deklarieren, unter der sie ausgeführt werden soll. Zweitens – Alternative – die Übergabe des `--user`-**[Flag](https://docs.docker.com/engine/reference/run/#user)**, was direkt von Docker unterstützt wird.

Sie können Ihre `uid` zum Beispiel mit dem Befehl `id -u` überprüfen und es dann wie oben angegeben deklarieren. Zum Beispiel, wenn Ihr Ziel-Benutzer die `uid` von 1001 hat:

```shell
docker run -it -e ASF_USER=1001 -v /home/archi/ASF/config:/app/config --name asf --pull always justarchi/archisteamfarm

# Alternativ, falls Sie die Beschränkungen kennen
docker run -it -u 1001 -v /home/archi/ASF/config:/app/config --name asf --pull always justarchi/archisteamfarm
```

Der Unterschied zwischen `ASF_USER` und `--user` ist subtil, aber wichtig. `ASF_USER` ist ein benutzerdefinierter Mechanismus, der von ASF unterstützt wird. In diesem Szenario startet der Docker-Container immer noch als `root`, und dann startet das Start-Skript ASF als `ASF_USER`. Wenn Sie `--user` verwenden, starten Sie den gesamten Prozess, einschließlich des ASF-Startskripts als gegebener Benutzer. Die erste Option erlaubt es dem ASF-Start-Skript, Berechtigungen und andere Dinge automatisch für Sie zu handeln und löst einige häufige Probleme, die Sie möglicherweise verursacht haben, es stellt beispielsweise stellt es sicher, dass Ihre Verzeichnisse `/app` und `/asf` tatsächlich `ASF_USER` gehören. Im zweiten Szenario, da wir nicht als `root` ausführen, können wir das nicht gewährleisten, und es wird von Ihnen erwartet, dass Sie das alles selbst im Voraus erledigen.

Wenn Sie sich dazu entschieden haben, das Flag `--user` zu verwenden, dann müssen selbst Sie den Besitz aller ASF-Dateien von Standard `asf` auf Ihren neuen benutzerdefinierten Anwender ändern. Sie können dies erreichen, indem Sie den folgenden Befehl ausführen:

```shell
# Nur ausführen, wenn Sie nicht ASF_USER verwenden
Docker exec -u root asf chown -hR 1001 /app /asf
```

Dies muss nur einmal durchgeführt werden, nachdem Sie Ihren Container mit `docker run` erstellt haben, und nur dann, wenn Sie sich dazu entschieden haben, einen benutzerdefinierten Anwender für die Docker-Flag `-user` zu verwenden. Vergessen Sie auch nicht, das Argument `1001` im Befehl oben auf die `UID` zu ändern, unter der Sie ASF ausführen möchten.

### Volume (Laufwerk) mit SELinux

Wenn Sie SELinux im erzwungenen Zustand auf Ihrem Betriebssystem verwenden, ist dies die StandarIhrstellung zum Beispiel für RHEL-basierte Distributionen, dann sollten Sie das Volume (Laufwerk) zusammen mit der Flag `:Z` einhängen, die den korrekten SELinux Kontext dafür setzt.

```
docker run -it -v /home/archi/ASF/config:/app/config:Z --name asf --pull always justarchi/archisteamfarm
```

Dies erlaubt ASF Dateien zu erstellen, die das Volume (Laufwerk) im Docker-Containers anvisieren.

---

## Synchronisation mehrerer Instanzen

ASF unterstützt die Synchronisation mehrerer Instanzen, wie im Abschnitt **[Verwaltung](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#mehrere-instanzen)** erläutert. Beim Ausführen von ASF im Docker-Container, können Sie optional „opt-in“ in den Prozess einschalten für den Fall, dass Sie mehrere Container mit ASF (synchronisiert) verwenden möchten.

Standardmäßig ist jede ASF in einem eigenständigen Docker-Container und das bedeutet, dass keine Synchronisation stattfindet. Um die Synchronisation zwischen Ihnen zu aktivieren, müssen Sie den Pfad `/tmp/ASF` in jedem ASF Container, den Sie synchronisieren möchten, zu einem gemeinsamen Pfad (im Lese-Schreib-Modus) des Docker-Hosts einbinden. Dies wird genauso wie bei der Bindung eines Volumes (Laufwerk) erreicht (wie oben erläutert), nur mit verschiedenen Pfaden:

```shell
mkdir -p /tmp/ASF-g1
docker run -v /tmp/ASF-g1:/tmp/ASF -v /home/archi/ASF/config:/app/config --name asf1 --pull always justarchi/archisteamfarm
docker run -v /tmp/ASF-g1:/tmp/ASF -v /home/john/ASF/config:/app/config --name asf2 --pull always justarchi/archisteamfarm
# Und so weiter, alle ASF Container sind jetzt miteinander synchronisiert
```

Wir empfehlen das ASF-Verzeichnis `/tmp/ASF` auch an ein temporäres `/tmp` Verzeichnis auf Ihrem Rechner zu binden, aber Sie können natürlich jedes andere wählen, die Ihren Zweck erfüllt. Jeder ASF-Container, der synchronisiert werden soll, sollte sein `/tmp/ASF` Verzeichnis mit anderen Containern teilen, die am gleichen Synchronisierungsprozess teilnehmen.

Wie Sie vermutlich am Beispiel oben erraten haben, ist es auch möglich, zwei oder mehr „Synchronisierungsgruppen“ zu erstellen, indem Sie verschiedene Docker Host-Pfade in ASFs `/tmp/ASF` einbinden.

Das Einbinden von `/tmp/ASF` ist komplett optional und aktuell nicht empfehlenswert, es sei denn, Sie möchten explizit zwei oder mehr ASF-Container synchronisieren. Wir raten davon ab, `/tmp/ASF` für den Einsatz mit einem Container einzubinden, da es absolut keine Vorteile bringt, wenn Sie nur einen ASF-Container laufen lassen möchten, und es könnte tatsächlich zu Problemen führen, die sonst Vermeidbar wären.

---

## Befehlszeilenargumente

ASF erlaubt es Ihnen **[Befehlszeilenargumente](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments-de-DE)** in Docker-Containern durch Umgebungsvariablen weiterzugeben. Sie sollten spezifische Umgebungsvariablen für die unterstützten Schalter verwenden und für den Rest `ASF_ARGS`. Dies kann mit dem Schalter `-e` erreicht werden, der zum `Docker Run` hinzugefügt wurde; zum Beispiel:

```shell
docker run -it -e "ASF_CRYPTKEY=MyPassword" -e "ASF_ARGS=--no-config-migrate" --name asf --pull always justarchi/archisteamfarm
```

Dies wird sowohl das Argument `--cryptkey` korrekt an den ASF-Prozess übergeben, der im Docker-Container ausgeführt wird, als auch andere Argumente. Falls Sie ein fortgeschrittener Benutzer sind, können Sie natürlich auch den `ENTRYPOINT` bearbeiten oder eine `CMD` hinzufügen und Ihre Argumente selbst übergeben.

Sofern Sie keinen benutzerdefinierten Verschlüsselungsschlüssel oder andere erweiterte Optionen bereitstellen möchten, müssen Sie in der Regel keine speziellen Umgebungsvariablen einfügen, da unsere Docker-Container bereits so konfiguriert sind, dass sie mit einer vernünftig erwarteten Standardoption ausgeführt `--no-restart` `--process-required` und `--system-required`; sodass diese Flags nicht explizit in `ASF_ARGS` angegeben werden müssen.

---

## IPC

Angenommen, Sie haben den Standardwert für `IPC` **[globale Konfigurationseigenschaft](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-de-DE#globale-konfiguration)** nicht geändert, ist diese bereits aktiviert. Allerdings müssen Sie zuvor zwei zusätzliche Dinge erledigen, damit IPC im Docker Container funktioniert. Zuerst müssen Sie `IPCPassword` verwenden oder das standardmäßige `KnownNetworks` in der benutzerdefinierten `IPC.config` bearbeiten, um eine Verbindung von außen ohne Verwendung zu ermöglichen. Wenn Sie nicht wirklich wissen, was Sie tun, verwenden Sie einfach `IPCPassword`. Darüber hinaus **müssen** Sie die Standard-Abhöradresse von `localhost` ändern, da Docker keinen externen Traffic (Verkehr) an die Loopback-Schnittstelle umleiten kann. Ein Beispiel für eine Einstellung, die auf allen Schnittstellen lauscht, wäre `http://*:1242`. Natürlich können Sie auch restriktivere Bindungen verwenden, etwa nur lokales LAN oder VPN-Netzwerk, aber es muss eine von außen zugängliche Route sein; `localhost` reicht nicht aus, da die Route vollständig innerhalb des Gastcomputers liegt.

Um das oben Gesagte zu erreichen, sollten Sie eine **[benutzerspezifische IPC-Konfiguration](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-de-DE#benutzerdefinierte-konfiguration)** verwenden, wie die untenstehende:

```json
{
 "Kestrel": {
  "Endpoints": {
   "HTTP": {
    "Url": "http://*:1242"
   }
  }
 }
}
```

Sobald wir IPC auf einer Nicht-Loopback-Schnittstelle eingerichtet haben, ist es notwendig Docker mitzuteilen, dass er den ASF-Port `1242/tcp` (entweder mit dem Schalter `-P` oder `-p`) zuordnen soll.

Dieser Befehl würde die ASF-IPC-Schnittstelle beispielsweise (nur) zum Host-Computer freigeben:

```shell
docker run -it -p 127.0.0.1:1242:1242 -p [::1]:1242:1242 --name asf --pull always justarchi/archisteamfarm
```

Wenn Sie alles richtig eingestellt haben, wird der oben gezeigte `docker run` Befehl das **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-de-DE)** Interface von Ihrem Host-Computer aus auf der Standardroute `localhost:1242` laufen lassen, die nun korrekt auf Ihre Gast-Maschine umgeleitet wird. Es ist auch gut zu wissen, dass wir diese Route nicht weiter offenlegen, sodass die Verbindung nur innerhalb des Docker-Hosts erfolgen kann und somit sicher bleibt. Natürlich können Sie die Route tiefer freigeben, sofern Sie wissen, was Sie tun, und für entsprechende Sicherheitsmaßnahmen sorgen.

---

### Vollständiges Beispiel

Wenn man das gesamte obige Wissen kombiniert, würde ein Beispiel für ein komplettes Setup so aussehen:

```shell
docker run -p 127.0.0.1:1242:1242 -p [::1]:1242:1242 -v /home/archi/ASF/config:/app/config -v /home/archi/ASF/plugins:/app/plugins --name asf --pull always justarchi/archisteamfarm
```

Dies setzt voraus, dass Sie einen einzigen ASF-Container mit allen ASF-Konfigurationsdateien in `/home/archi/ASF/config` verwenden. Sie sollten den Konfigurationspfad zu dem ändern, der zu Ihrem Rechner passt. Es ist auch möglich, eigene Erweiterungen für ASF bereitzustellen, indem Sie diese in `/home/archi/ASF/plugins` Einfügen. Dieses Setup ist auch für die optionale IPC-Nutzung bereit, wenn Sie sich entschieden haben, `IPC.config` in Ihr Konfigurationsverzeichnis mit einem Inhalt wie unten erläutert aufzunehmen:

```json
{
 "Kestrel": {
  "Endpoints": {
   "HTTP": {
    "Url": "http://*:1242"
   }
  }
 }
}
```

---

## Profi-Tipps

Wenn Sie Ihren ASF-Docker-Container bereits startklar haben, müssen Sie nicht jedes Mal `docker run` verwenden. Sie können den ASF-Docker-Container einfach mit `docker stop asf` und `docker start asf` stoppen/starten. Beachten Sie, dass, wenn Sie nicht den `latest` *Tag* verwenden, die Verwendung des aktuellen ASF von Ihnen immer noch `docker stop` und `docker rm` benötigt wird. Schließlich starten Sie mit `docker start` erneut. Dies liegt daran, dass Sie Ihren Container jedes Mal aus einem frischen ASF-Docker-Image neu erstellen müssen, wenn Sie die in diesem Image (Abbild) enthaltene ASF-Version verwenden möchten. Beim *Tag* `neuestem` hat ASF die Fähigkeit eingebaut, sich selbst zu aktualisieren, sodass der Wiederaufbau des Bildes nicht notwendig ist, um die aktuelle ASF zu verwenden (aber es ist immer noch eine gute Idee, es von Zeit zu Zeit zu tun, um .NET Laufzeitabhängigkeiten und das zugrundeliegende Betriebssystem aktuell zu halten, das benötigt werden könnte, wenn Sie wichtige ASF-Versionsupdates überspringen).

Wie oben angedeutet, wird sich ASF in einem anderen *Tag* als `latest` nicht automatisch aktualisieren, was bedeutet, dass **Sie** dafür verantwortlich sind, ein aktuelles `justarchi/archisteamfarm` Repository zu verwenden. Dies hat viele Vorteile, da die Anwendung typischerweise nicht Ihren eigenen Quellcode berühren sollte, wenn sie ausgeführt wird, aber wir verstehen auch Komfort, der dadurch entsteht, dass Sie sich nicht um die ASF-Version in Ihrem Docker-Container kümmern müssen. Wenn Sie sich um gute Praktiken und die korrekte Verwendung von Dockern kümmern, dann schlagen wir Ihnen den `released` *Tag* – anstelle von `latest` vor; aber wenn Sie sich für ASF lediglich automatische Updates und Funktionalität wünschen, dann reicht `latest` aus.

Sie sollten ASF typischerweise im Docker-Container mit der globalen Konfiguration `Headless: true` ausführen. Dies wird ASF klar signalisieren, dass Sie nicht hier sind, um fehlende Details zu liefern und es sollte nicht nach diesen fragen. Natürlich sollten Sie für die Erstkonfiguration in Betracht ziehen, diese Option bei `false` zu belassen, damit Sie Dinge einfach einrichten können, aber auf lange Sicht sind Sie typischerweise nicht an die ASF-Konsole gebunden, deshalb wäre es sinnvoll, ASF darüber zu informieren und `input` **[Befehl](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-de-DE#input-befehl)** zu verwenden, wenn Bedarf entsteht. Auf diese Weise muss ASF nicht ewig auf Benutzereingaben warten, die nicht erfolgen (und dabei Ressourcen verschwenden). Dies ermöglicht es, dass ASF im nicht-interaktiven Modus innerhalb eines Containers ausgeführt werden kann, was entscheidend ist, z. B. in Bezug auf die Weiterleitungssignale, die es ASF ermöglichen, auf Anfrage von `docker stop asf` angemessen zu schließen.