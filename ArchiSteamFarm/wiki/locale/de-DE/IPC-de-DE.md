# IPC

ASF beinhaltet eine eigene einzigartige IPC-Schnittstelle, die für die weitere Interaktion mit dem Prozess verwendet werden kann. IPC steht für **[inter-process communication](https://de.wikipedia.org/wiki/Interprozesskommunikation)** und in der einfachsten Definition ist es eine "ASF-Weboberfläche" basierend auf **[Kestrel HTTP Server](https://github.com/aspnet/KestrelHttpServer)**, welches für die weitere Integration mit dem Prozess, sowohl als Frontend für Endbenutzer (ASF-UI), als auch Backend für Drittanbieter-Integrationen (ASF-API) verwendet werden kann.

IPC kann für viele verschiedene Dinge verwendet werden, je nach Ihren Fähigkeiten und Bedürfnissen. Sie können es beispielsweise dafür verwenden, um den Status von ASF und allen Bots abzurufen, ASF-Befehle zu senden, Globale- und Bot-Konfigurationen abzurufen und zu bearbeiten, neue Bots hinzuzufügen, bestehende Bots zu löschen, Produktschlüssel an den **[BGR](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer-de-DE)** zu senden oder auf das ASF-Protokoll zuzugreifen. Alle diese Aktionen werden durch unsere API offengelegt, was bedeutet, dass Sie Ihre eigenen Programme und Skripte schreiben können, die in der Lage sind, mit ASF zu kommunizieren und während der Ausführung dessen Prozess zu beeinflussen. Darüber hinaus sind ausgewählte Aktionen (z. B. das Senden von Befehlen) auch in unserem ASF-UI vorhanden, sodass Sie über eine benutzerfreundliche Weboberfläche einfach darauf zugreifen können.

---

# Nutzung

Sofern Sie den IPC nicht manuell anhand der **[globale Konfigurationseigenschaft](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-de-DE#globale-konfiguration)** `IPC` deaktiviert haben, ist er standardmäßig aktiviert. ASF kündigt den Start des IPC-Servers in seinem Protokoll an, in welchem Sie überprüfen können, ob die IPC-Schnittstelle ordnungsgemäß gestartet wurde:

```text
INFO|ASF|Start() Starte IPC-Server...
INFO|ASF|Start() IPC-Server bereit!
```

ASF's http-Server hört nun auf den ausgewählten Endpunkten. Falls Sie keine benutzerdefinierte Konfigurationsdatei für IPC angegeben haben, wird für IPv4 **[127.0.0.1](http://127.0.0.1:1242)** und für IPv6 **[[::1]](http://[::1]:1242)** auf dem Standard-Port `1242` verwendet. Sie können auf unsere IPC-Schnittstelle über die obigen Links von demselben Gerät aus zugreifen, auf der auch der ASF-Prozess läuft.

Die IPC-Schnittstelle von ASF bietet - je nach der von Ihnen geplanten Nutzung - drei verschiedene Möglichkeiten, darauf zuzugreifen.

Auf der untersten Ebene gibt es die **[ASF-API](#asf-api)**, das ist der Kern unserer IPC-Schnittstelle und ermöglicht den Betrieb aller anderen. Diese sollten Sie in Ihren eigenen Programmen, Dienstprogrammen und Projekten verwenden, um direkt mit ASF zu kommunizieren.

Auf der mittleren Ebene befindet sich unsere **[Swagger-Dokumentation](#swagger-dokumentation)**, die als Frontend für die ASF-API dient. Es bietet eine vollständige Dokumentation der ASF-API und ermöglicht einen einfacheren Zugriff darauf. Dies sollten Sie nutzen, wenn Sie vorhaben ein Programm, ein Dienstprogramm oder andere Projekte zu schreiben, die über die API mit ASF kommunizieren sollen.

Auf der obersten Ebene gibt es **[ASF-UI](#asf-ui)**, das auf unserer ASF-API basiert und eine benutzerfreundliche Möglichkeit bietet, verschiedene ASF-Aktionen auszuführen. Dies ist unsere Standard-IPC-Schnittstelle für Endanwender und ein perfektes Beispiel dafür, was Sie mit der ASF-API erstellen können. Wenn Sie möchten, können Sie Ihre eigene benutzerdefinierte Web-Benutzeroberfläche für die Verwendung mit ASF benutzen, indem Sie `--path` **[Befehlszeilenargument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments-de-DE#argumente)** angeben und das benutzerdefinierten `www` Verzeichnis verwenden.

---

# ASF-UI

ASF-UI ist ein Gemeinschaftsprojekt, das darauf abzielt, eine benutzerfreundliche grafische Weboberfläche für Endbenutzer zu erstellen. Um dies zu erreichen, fungiert es als Frontend für unsere **[ASF-API](#asf-api)**, sodass Sie verschiedene Aktionen mit Leichtigkeit durchführen können . Dies ist die Standardoberfläche mit der ASF ausgeliefert wird.

Wie bereits erwähnt, ist ASF-UI ein Community-Projekt, das nicht von den Kern-ASF-Entwicklern betreut wird. Es folgt seinem eigenen Fluss in der **[ASF-UI Repository](https://github.com/JustArchiNET/ASF-UI)**, welches für alle damit verbundenen Fragen, Probleme, Fehlerberichte und Vorschläge verwendet werden sollte.

Sie können ASF-UI für die allgemeine Verwaltung des ASF-Prozesses verwenden. Es erlaubt beispielsweise Bots zu verwalten, Einstellungen zu ändern, Befehle zu senden und ausgewählte andere Funktionen zu erreichen, die normalerweise über ASF verfügbar sind.

![ASF-UI](https://raw.githubusercontent.com/JustArchiNET/ASF-ui/main/.github/previews/bots.png)

---

# ASF-API

Unsere ASF-API ist eine typische **[RESTful](https://de.wikipedia.org/wiki/Representational_state_transfer)** Web-API, die auf JSON als primärem Datenformat basiert. Wir tun unser Bestes, um die Antwort genau zu beschreiben, indem wir sowohl HTTP-Statuscodes (falls zutreffend), als auch eine Antwort verwenden, die Sie selbst analysieren können, um zu wissen, ob die Anfrage erfolgreich war und wenn nicht, warum.

Auf unsere ASF-API kann zugegriffen werden, indem entsprechende Anfragen an entsprechende `/Api` Endpunkte gesendet werden. Sie können diese API-Endpunkte verwenden, um eigene Hilfsskripte, Programme, Benutzeroberflächen und ähnliches zu erstellen. Das ist genau das, was unser ASF-UI unter der Haube leistet und jedes andere Programm kann das gleiche erreichen. ASF-API wird offiziell vom ASF-Kernteam unterstützt und gepflegt.

Für eine vollständige Dokumentation der verfügbaren Endpunkte, Beschreibungen, Anfragen, Antworten, http-Statuscodes und alles andere was die ASF-API berücksichtigt, ließ bitte unsere **[swagger-Dokumentation](#swagger-dokumentation)**.

![ASF-API](https://i.imgur.com/yggjf5v.png)

---

# Benutzerdefinierte Konfiguration

Unsere IPC-Schnittstelle unterstützt eine zusätzliche Konfigurationsdatei, `IPC.config`, die in das Standard-ASF-Verzeichnis `config` gelegt werden sollte.

Falls verfügbar, gibt diese Datei die erweiterte Konfiguration des ASF Kestrel http-Servers zusammen mit anderen IPC-bezogenen Einstellungen an. Wenn Sie keinen besonderen Anlass haben gibt es keinen Grund für Sie diese Datei zu verwenden, da ASF in diesem Fall bereits sinnvolle Standardwerte verwendet.

Die Konfigurationsdatei basiert auf folgender JSON-Struktur:

```json
{
 "Kestrel": {
  "Endpoints": {
   "example-http4": {
    "Url": "http://127.0.0.1:1242"
   },
   "example-http6": {
    "Url": "http://[::1]:1242"
   },
   "example-https4": {
    "Url": "https://127.0.0.1:1242",
    "Certificate": {
     "Path": "/path/to/certificate.pfx",
     "Password": "passwordToPfxFileAbove"
    }
   },
   "example-https6": {
    "Url": "https://[::1]:1242",
    "Certificate": {
     "Path": "/path/to/certificate.pfx",
     "Password": "passwordToPfxFileAbove"
    }
   }
  },
  "KnownNetworks": [
   "10.0.0.0/8",
   "172.16.0.0/12",
   "192.168.0.0/16"
  ],
  "PathBase": "/"
 }
}
```

`Endpoints` ist eine Sammlung von Endpunkten, wobei jeder Endpunkt seinen eigenen eindeutigen Namen hat (wie z. B. `example-http4`) und eine `Url` Variable, welche die `Protokoll://Host:Port` Abhöradresse angibt. Standardmäßig hört ASF auf IPv4- und IPv6-Http-Adressen, aber wir haben https-Beispiele hinzugefügt, die Sie bei Bedarf verwenden können. Sie sollten nur die Endpunkte deklarieren, die Sie benötigen. Wir haben oben vier Beispiele hinzugefügt damit Sie diese leichter bearbeiten können.

Ein `Host` akzeptiert entweder `localhost` (eine feste IP-Adresse der Schnittstelle), auf der er lauschen soll (IPv4/IPv6), oder den Wert `*`, der den HTTP-Server von ASF an alle verfügbaren Schnittstellen bindet. Die Verwendung anderer Werte (wie `mydomain.com` oder `192.168.0.`) agiert wie `*`; die IP-Filterung ist damit deaktiviert. Seien Sie daher äußerst vorsichtig, wenn Sie `Host` Werte verwenden, die einen entfernten Zugriff ermöglichen. Dadurch wird der Zugriff auf die IPC-Schnittstelle von ASF von anderen Geräten aus ermöglicht, was ein Sicherheitsrisiko darstellen kann. In diesem Fall empfehlen wir dringend **mindestens** die Nutzung von `IPCPassword` (und vorzugsweise auch einer eigenen Firewall).

`KnownNetworks` - Diese **optionale** Variable gibt Netzwerkadressen an, die wir für vertrauenswürdig halten. Standardmäßig vertraut ASF **nur** der Loopback-Schnittstelle (`localhost`, gleiches Gerät). Diese Variable wird auf zweierlei Weise genutzt. Erstens, wenn Sie `IPCPassword` weglassen, dann erlauben wir den Zugriff nur von Geräte aus bekannten Netzwerken auf die API von ASF, und verweigern allen anderen als Sicherheitsmaßnahme. Zweitens ist diese Variable von entscheidender Bedeutung für den Zugang zu ASF durch umgekehrte Proxys, da ASF seine Header nur dann ehrt, wenn der Reverse-Proxy-Server aus bekannten Netzwerken stammt. Die Anerkennung der Kopfzeilen (Header) ist für ASFs Anti-Bruteforce-Mechanismus von entscheidender Bedeutung, da statt der Sperre des umgekehrten Proxys im Falle eines Problems die vom Reverse-Proxy angegebene IP als Quelle der ursprünglichen Nachricht blockiert wird. Seien Sie sehr vorsichtig mit den Netzwerken, die Sie hier angeben; da es einen potentiellen IP-Spoofing-Angriff und einen unautorisierten Zugriff ermöglicht, falls das vertrauenswürdige Gerät kompromittiert oder falsch konfiguriert ist.

`PathBase` - Dies ist ein **optionaler** Basispfad, der von der IPC Schnittstelle verwendet wird. Der Standardwert ist auf `/` voreingestellt und muss für die meisten Anwendungsfälle nicht zwingend geändert werden. Wenn Sie diese Variable ändern, hosten Sie die gesamte IPC-Schnittstelle auf einem benutzerdefinierten Präfix, zum Beispiel `http://localhost:1242/MeinPrefix` anstelle von `http://localhost:1242` allein. Die Verwendung von einem benutzerdefinierten `PathBase` könnte in Kombination mit der spezifischen Einrichtung eines Reverse-Proxy erwünscht sein, bei dem Sie nur eine bestimmte URL umleiten möchten, z. B. `meinedomain.com/ASF`, anstatt der gesamten Domain `meinedomain.com`. Normalerweise würde das erfordern, dass Sie eine Umschreibungsregel für Ihren Webserver festlegen, die `meinedomain.com/ASF/Api/X` -> `localhost:1242/Api/X` widerspiegeln würde. Aber stattdessen können Sie einen benutzerdefinierten `PathBase` von `/ASF` definieren und eine einfachere Einrichtung von `meinedomain.com/ASF/Api/X` -> `localhost:1242/ASF/Api/X` erreichen.

Wenn Sie nicht wirklich einen benutzerdefinierten Basispfad angeben müssen, ist es am besten ihn bei der Standardeinstellung zu belassen.

## Beispielkonfigurationen

### Standardport ändern

Die folgende Konfiguration ändert einfach den ASF Listing-Port von `1242` auf `1337`. Sie können jeden beliebigen Port wählen, aber wir empfehlen den Bereich `1024-32767`, da andere Ports normalerweise **[registriert sind](https://de.wikipedia.org/wiki/Liste_der_standardisierten_Ports)** **[(engl. Wikipedia)](https://en.wikipedia.org/wiki/Registered_port)**, und kann zum Beispiel `root` Zugriff unter Linux erfordern.

```json
{
 "Kestrel": {
  "Endpoints": {
   "HTTP4": {
    "Url": "http://127. .0. :1337"
   },
   "HTTP6": {
    "Url": "http://[::1]:1337"
   }
  }
 }
}
```

---

### Aktiviere Zugriff von allen IPs

Die folgende Konfiguration ermöglicht den Fernzugriff von allen Quellen. **Daher sollten Sie sicherstellen, dass Sie unsere Sicherheitshinweise gelesen und verstanden haben** (siehe oben).

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

Wenn Sie nicht von allen Quellen aus Zugriff benötigen, sondern zum Beispiel von nur Ihrem LAN, dann ist es viel besser, die lokale IP-Adresse des ASF-Rechners zu überprüfen (z. B. `192. 68.0.10`); Verwenden Sie dies anstelle von `*` im obigen Beispiel.

---

# Authentifizierung

Die ASF-IPC-Schnittstelle erfordert standardmäßig keine Art von Authentifizierung, da `IPCPassword` auf `null` gesetzt ist. Wenn jedoch `IPCPassword` durch das Setzen eines beliebigen nicht leeren Wertes aktiviert wird, erfordert jeder Aufruf der ASF-API das Passwort, das mit dem eingestellten `IPCPassword` übereinstimmt. Wenn Sie die Authentifizierung weglassen oder ein falsches Passwort eingeben, erhalten Sie den Fehler `401 - Unauthorized`. Nach 5 fehlgeschlagenen Authentifizierungsversuchen (falsches Passwort) werden Sie vorübergehend mit dem Fehler `403 - Forbidden` blockiert.

Die Authentifizierung kann auf zwei verschiedene Arten erfolgen.

## `Authentication` Header

Im Allgemeinen sollten Sie **[HTTP request header](https://en.wikipedia.org/wiki/List_of_HTTP_header_fields)** verwenden, indem Sie `Authentication` mit Ihrem Passwort als Wert einstellen. Die Vorgehensweise hängt davon ab, mit welchem Programm Sie auf die IPC-Schnittstelle von ASF zugreifen, z. B. wenn Sie `curl` verwenden, dann sollten Sie `-H 'Authentication: MeinPasswort'` als Parameter hinzufügen. Auf diese Weise wird die Authentifizierung in den Headern der Anfrage übergeben, wo sie tatsächlich stattfinden soll.

## `password` Parameter im Query-String

Alternativ können Sie den Parameter `password` an das Ende der URL anhängen, die Sie aufrufen möchten, z. B. indem Sie `/Api/ASF?password=MeinPasswort` anstelle von `/Api/ASF` allein aufrufen. Dieser Ansatz ist gut genug, aber offensichtlich enthüllt er das Passwort, was nicht unbedingt immer angemessen ist. Darüber hinaus ist es ein zusätzliches Argument im Query-String (Abfrage-Zeichenkette), das das Aussehen der URL verkompliziert und das Gefühl gibt, dass es URL-spezifisch ist, während das Passwort für die gesamte ASF-API-Kommunikation gilt.

---

Beide Möglichkeiten werden unterstützt und es liegt ganz bei Ihnen, welchen Sie wählen möchten. Wir empfehlen einen HTTP-Header überall dort zu verwenden, wo es Ihnen möglich ist, da es in der Verwendung sinnvoller ist als ein Query-String. Wir unterstützen jedoch auch Query-Strings, hauptsächlich wegen verschiedener Einschränkungen in Bezug auf Request-Header. Ein gutes Beispiel ist das Fehlen von benutzerdefinierten Headern beim Einleiten einer Websocket-Verbindung in JavaScript (obwohl sie nach RFC vollständig gültig ist). In dieser Situation ist ein Query-String die einzige Möglichkeit sich zu authentifizieren.

---

# Swagger Dokumentation

Unsere IPC-Schnittstelle, zusätzlich zu ASF-API und ASF-UI, beinhaltet auch die Swagger-Dokumentation, welche unter der `/swagger` **[URL](http://localhost:1242/swagger) ** verfügbar ist. Die Swagger-Dokumentation dient als Mittelsmann zwischen unserer API-Implementierung und anderen Programmen, die sie verwenden (z. B. ASF-UI). Es bietet eine vollständige Dokumentation und Verfügbarkeit aller API-Endpunkte in der Spezifikation **[OpenAPI](https://swagger.io/resources/open-api)**, die von anderen Projekten problemlos genutzt werden kann, sodass Sie ASF-API mit Leichtigkeit schreiben und testen können .

Neben der Verwendung unserer Swagger-Dokumentation als komplette Spezifikation der ASF-API können Sie sie auch als benutzerfreundliche Möglichkeit verwenden, verschiedene API-Endpunkte auszuführen, vor allem solche die nicht von ASF-UI implementiert werden. Da unsere Swagger-Dokumentation automatisch aus ASF-Quelltext generiert wird, haben Sie die Garantie, dass die Dokumentation immer auf dem neuesten Stand der API-Endpunkte ist die Ihre Version von ASF enthält.

![Swagger Dokumentation](https://i.imgur.com/mLpd5e4.png)

---

# FAQ (häufig gestellte Fragen)

### Ist die IPC-Schnittstelle von ASF geschützt und sicher in der Anwendung?

ASF hört standardmäßig nur auf `localhost` Adressen, was bedeutet, dass der Zugriff auf ASF-IPC von jedem anderen Rechner als Ihrem eigenen **nicht möglich ist**. Wenn Sie keine Standard-Endpunkte ändern, bräuchte der Angreifer einen direkten Zugriff auf Ihren eigenen Computer, um auf ASF-IPC zugreifen zu können, daher ist er so sicher wie möglich und es besteht keine Möglichkeit, dass andere Personen auf ihn zugreifen, auch nicht aus Ihrem eigenen LAN.

Wenn Sie sich jedoch dazu entscheiden, die standardmäßig eingestellten `localhost` Adressen an etwas anderes zu binden, dann sollten Sie die richtigen Firewall-Regeln **selbst** festlegen, um nur autorisierten IPs den Zugriff auf die IPC-Schnittstelle von ASF zu ermöglichen. Zusätzlich müssen Sie `IPCPassword` einrichten, da ASF sich weigern wird, andere Geräte den Zugriff auf die ASF-API ohne jenes zu verweigern. Dies dient als weitere Sicherheitsmaßnahme. Möglicherweise möchten Sie in diesem Fall auch die IPC-Schnittstelle von ASF hinter einem Reverse-Proxy ausführen, was im Folgenden näher erläutert wird.

### Kann ich mit meinen eigenen Programmen oder Benutzerskripten auf die ASF-API zugreifen?

Ja, dafür wurde die ASF-API entwickelt und Sie können alles verwenden, was fähig ist eine HTTP-Anfrage zu senden, um darauf zuzugreifen. Lokale Benutzerskripte folgen der **[CORS](https://de.wikipedia.org/wiki/Cross-Origin_Resource_Sharing)** Logik, und wir erlauben den Zugriff von allen Ursprüngen für diese (`*`), solange `IPCPassword` gesetzt ist (als zusätzliche Sicherheitsmaßnahme). Auf diese Weise können Sie verschiedene authentifizierte ASF-API-Anfragen ausführen, ohne dass potenziell bösartige Skripte dies automatisch tun können (da sie dazu Ihr `IPCPassword` kennen müssenen).

### Kann ich aus der Ferne auf die IPC-Schnittstelle von ASF zugreifen, z. B. von einem anderen Gerät aus?

Ja, wir empfehlen dafür einen Reverse-Proxy zu verwenden. Auf diese Weise können Sie wie gewohnt auf Ihren Webserver zugreifen, der dann auf dem gleichen Gerät auf die IPC-Schnittstelle von ASF zugreift. Andernfalls, wenn Sie nicht mit einem Reverse-Proxy arbeiten möchten, können Sie die **[benutzerdefinierte Konfiguration](#benutzerdefinierte-konfiguration)** mit einer entsprechenden URL verwenden. Wenn sich Ihr Gerät beispielsweise in einem VPN mit der Adresse `10.8.0.1` befindet, dann können Sie als Abhör-URL `http://10.8.0.1:1242` in der IPC-Konfiguration einstellen, was den IPC-Zugriff von Ihrem privaten VPN aus ermöglichen würde, aber nicht von irgendwo anders.

### Kann ich die IPC-Schnittstelle von ASF hinter einem Reverse-Proxy wie Apache oder Nginx verwenden?

**Ja**, unser IPC ist vollständig kompatibel mit einem solchen Setup, sodass Sie ihn auch für zusätzliche Sicherheit und Kompatibilität vor Ihren eigenen Programmen hosten können, wenn Sie möchten. Im Allgemeinen ist der Kestrel http-Server von ASF sehr sicher und birgt kein Risiko, wenn er direkt mit dem Internet verbunden ist, aber wenn man ihn hinter einen Reverse-Proxy wie Apache oder Nginx stellt, kann er zusätzliche Funktionen bieten die sonst nicht möglich wären (z. B. die Sicherung der ASF-Schnittstelle mit einer **[Basic Authentication](https://https://de.wikipedia.org/wiki/HTTP-Authentifizierung#Basic_Authentication)**).

Eine beispielhafte Nginx-Konfiguration finden Sie unten. Wir haben den vollen `server` Block eingefügt, obwohl Sie sich hauptsächlich für `location` interessieren. Bitte lesen Sie die **[nginx-Dokumentation](https://nginx.org/en/docs)**, falls Sie weitere Erklärungen brauchen.

```nginx
server {
 listen *:443 ssl;
 server_name asf.mydomain.com;
 ssl_certificate /path/to/your/certificate.crt;
 ssl_certificate_key /path/to/your/certificate.key;

 location ~* /Api/NLog {
  proxy_pass http://127.0.0.1:1242;

  # Only if you need to override default host
#  proxy_set_header Host 127.0.0.1;

  # X-headers should always be specified when proxying requests to ASF
  # They're crucial for proper identification of original IP, allowing ASF to e.g. ban the actual offenders instead of your nginx server
  # Specifying them allows ASF to properly resolve IP addresses of users making requests - making nginx work as a reverse proxy
  # Not specifying them will cause ASF to treat your nginx as the client - nginx will act as a traditional proxy in this case
  # If you're unable to host nginx service on the same machine as ASF, you most likely want to set KnownNetworks appropriately in addition to those
  proxy_set_header X-Forwarded-For $proxy_add_x_forwarded_for;
  proxy_set_header X-Forwarded-Host $host:$server_port;
  proxy_set_header X-Forwarded-Proto $scheme;
  proxy_set_header X-Forwarded-Server $host;
  proxy_set_header X-Real-IP $remote_addr;

  # We add those 3 extra options for websockets proxying, see https://nginx.org/en/docs/http/websocket.html
  proxy_http_version 1.1;
  proxy_set_header Connection "Upgrade";
  proxy_set_header Upgrade $http_upgrade;
 }

 location / {
  proxy_pass http://127.0.0.1:1242;

  # Only if you need to override default host
#  proxy_set_header Host 127.0.0.1;

  # X-headers should always be specified when proxying requests to ASF
  # They're crucial for proper identification of original IP, allowing ASF to e.g. ban the actual offenders instead of your nginx server
  # Specifying them allows ASF to properly resolve IP addresses of users making requests - making nginx work as a reverse proxy
  # Not specifying them will cause ASF to treat your nginx as the client - nginx will act as a traditional proxy in this case
  # If you're unable to host nginx service on the same machine as ASF, you most likely want to set KnownNetworks appropriately in addition to those
  proxy_set_header X-Forwarded-For $proxy_add_x_forwarded_for;
  proxy_set_header X-Forwarded-Host $host:$server_port;
  proxy_set_header X-Forwarded-Proto $scheme;
  proxy_set_header X-Forwarded-Server $host;
  proxy_set_header X-Real-IP $remote_addr;
 }
}
```

Im Folgenden finden Sie ein Beispiel für die Apache-Konfiguration. Bitte lesen Sie die **[Apache-Dokumentation](https://httpd.apache.org/docs)**, falls Sie weitere Erklärungen brauchen.

```apache
<IfModule mod_ssl.c>
 <VirtualHost *:443>
  ServerName asf.mydomain.com

  SSLEngine On
  SSLCertificateFile /path/to/your/fullchain.pem
  SSLCertificateKeyFile /path/to/your/privkey.pem

  # TODO: Apache can't do case-insensitive matching properly, so we hardcode two most commonly used cases
  ProxyPass "/api/nlog" "ws://127.0.0.1:1242/api/nlog"
  ProxyPass "/Api/NLog" "ws://127.0.0.1:1242/Api/NLog"

  ProxyPass "/" "http://127.0.0.1:1242/"
 </VirtualHost>
</IfModule>
```

### Kann ich über das HTTPS-Protokoll auf die IPC-Schnittstelle zugreifen?

**Ja**, Sie können dies auf zweierlei Weise erreichen. Eine empfohlene Methode wäre die Verwendung eines Reverse-Proxy, bei dem Sie sich wie üblich über https auf Ihren Webserver zugreifen und über ihn mit der IPC-Schnittstelle von ASF auf demselben Gerät verbinden können. Auf diese Weise ist Ihr Datenverkehr vollständig verschlüsselt und Sie müssen IPC keineswegs ändern, um ein solches Setup zu unterstützen.

Die zweite Möglichkeit besteht darin eine **[benutzerdefinierte Konfiguration](#benutzerdefinierte-konfiguration)** für die IPC-Schnittstelle von ASF zu spezifizieren, wo Sie http-Endpunkt aktivieren und das entsprechende Zertifikat direkt an unseren Kestrel http-Server senden können. Dieser Weg wird empfohlen, wenn Sie keinen anderen Webserver betreiben und auch keinen ausschließlich für ASF betreiben möchten. Andernfalls ist es viel einfacher ein befriedigendes Setup zu erreichen, indem man einen Reverse-Proxy-Mechanismus verwendet.

---

### Beim Starten des IPC erhalte ich den Fehler: `System.IO.IOException: Failed to bind to address, An attempt was made to access a socket in a way forbidden by its access permissions`

Dieser Fehler deutet darauf hin, dass etwas anderes auf Ihrem Gerät diesen Port bereits verwendet oder für zukünftige Nutzung reserviert hat. Dies könnte passieren, wenn Sie versuchen, eine zweite ASF-Instanz auf demselben Gerät auszuführen; aber am häufigsten schließt Windows den Port `1242` von Ihrer Nutzung aus, daher müssen Sie ASF auf einen anderen Port einstellen. Um dies zu erreichen, folgen Sie die **[Beispiel-Konfiguration](#changing-default-port)** oben, und versuchen Sie einfach einen anderen Port auszuwählen (etwa `12420`).

Natürlich können Sie auch versuchen herauszufinden, was den Port `1242` von der ASF-Nutzung blockiert und dies beheben, aber das ist in der Regel viel schwieriger, als ASF einfach anzuweisen, einen anderen Port zu verwenden; also verzichten wir hier auf weitere Erklärungen zu diesen Punkt.

---

### Warum erhalte ich den Fehler `403 Forbidden`, wenn ich kein `IPCPassword` verwende?

ASF enthält zusätzliche Sicherheitsmaßstäbe, die standardmäßig nur die Loopback-Schnittstelle (`localhost`, Ihr eigenes Gerät) zum Zugriff auf die ASF-API erlaubt; ohne `IPCPassword` in der Konfiguration gesetzt. Dies liegt daran, dass die Verwendung von `IPCPassword` der **minimale** Sicherheitsmaßstab sein sollte, der von allen festgelegt wird, die sich entscheiden, die ASF Schnittstelle weiter zu enthüllen.

Die Änderung wurde durch die Tatsache diktiert, dass weltweit eine massive Anzahl an ASF-Sitzungen, die von unbekannten Benutzern gehostet werden, für böswillige Absichten übernommen wurden. In der Regel werden diejenigen ihrer Konten und Gegenstände beraubt. Jetzt könnten wir sagen: "Sie könnten diese Seite lesen, bevor Sie ASF der ganzen Welt öffnen", aber stattdessen ergibt es mehr Sinn, unsichere ASF-Setups standardmäßig zu verbieten, und fordern von den Benutzern eine Aktion, falls sie dies explizit zulassen wollen. Mehr dazu erläutern wir weiter unten.

Sie können insbesondere unsere Entscheidung überschreiben, indem Sie die Netzwerke festlegen, von deren Verbindungen Sie zu ASF ohne `IPCPassword` vertrauen. Sie können diese in der benutzerdefinierten Konfiguration mit der Variable `KnownNetworks` einstellen. Wenn Sie jedoch nicht **wirklich** wissen, was Sie tun und die Risiken vollständig verstehen, sollten Sie stattdessen `IPCPassword` verwenden, da die Definition von `KnownNetworks` jeden aus diesem Netzwerken bedingungslos auf die ASF-API zugreifen können. Es ist uns ernst! Die Leute haben sich bereits in den Fuß geschossen, weil sie glaubten, dass ihre umgekehrten Proxies und iptable-Regeln sicher waren, aber sie waren es nicht. `IPCPassword` ist der erste und manchmal der letzte Wächter; sobald Sie sich von diesem einfachen, aber sehr effektiven und sicheren Mechanismus abmelden, haben Sie nur selbst die Schuld.