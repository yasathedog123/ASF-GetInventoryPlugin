# IPC

ASF beinhaltet eine eigene einzigartige IPC-Schnittstelle, die für die weitere Interaktion mit dem Prozess verwendet werden kann. IPC steht für **[inter-process communication](https://de.wikipedia.org/wiki/Interprozesskommunikation)** und in der einfachsten Definition ist es eine "ASF-Weboberfläche" basierend auf **[Kestrel HTTP Server](https://github.com/aspnet/KestrelHttpServer)**, welches für die weitere Integration mit dem Prozess, sowohl als Frontend für Endbenutzer (ASF-UI) als auch Backend für Drittanbieter-Integrationen (ASF-API) verwendet werden kann.

IPC kann für viele verschiedene Dinge verwendet werden, je nach ihren Fähigkeiten und Bedürfnissen. Sie können es beispielsweise dafür verwenden, um den Status von ASF und allen Bots abzurufen, ASF-Befehle zu senden, Globale- und Bot-Konfigurationen abzurufen und zu bearbeiten, neue Bots hinzuzufügen, bestehende Bots zu löschen, Produktschlüssel an den **[BGR](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer-de-DE)** zu senden oder auf das ASF-Protokoll zuzugreifen. Alle diese Aktionen werden durch unsere API offengelegt, was bedeutet, dass Du ihre eigenen Programme und Skripte schreiben kannst, die in der Lage sind, mit ASF zu kommunizieren und während der Laufzeit zu beeinflussen. Darüber hinaus sind ausgewählte Aktionen (z. B. das Senden von Befehlen) auch in unserem ASF-UI vorhanden, sodass Sie über eine benutzerfreundliche Weboberfläche einfach darauf zugreifen können.

---

# Nutzung

Unless you manually disabled IPC through `IPC` **[global configuration property](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#global-config)**, it's enabled by default. ASF gibt den IPC-Start in seinem Protokoll an, mit dem Du überprüfen kannst, ob die IPC-Schnittstelle ordnungsgemäß gestartet wurde:

```text
INFO|ASF|Start() Starte IPC-Server...
INFO|ASF|Start() IPC-Server bereit!
```

ASF's http-Server hört nun auf den ausgewählten Endpunkten. Falls Du keine benutzerdefinierte Konfigurationsdatei für IPC angegeben hast wird für IPv4 **[127.0.0.1](http://127.0.0.1:1242)** und für IPv6 **[[::1]](http://[::1]:1242)** auf Standard-Port `1242` verwendet. Du kannst auf unsere IPC-Schnittstelle über die obigen Links von dem selben Gerät aus zugreifen, auf der auch der ASF-Prozess läuft.

Die IPC-Schnittstelle von ASF bietet je nach der von ihren geplanten Nutzung drei verschiedene Möglichkeiten, darauf zuzugreifen.

Auf der untersten Ebene gibt es **[ASF-API](#asf-api)**, das ist der Kern unserer IPC-Schnittstelle und ermöglicht den Betrieb aller anderen. Dies ist es, was Du in ihren eigenen Programmen, Dienstprogrammen und Projekten verwenden solltest, um direkt mit ASF zu kommunizieren.

Auf der mittleren Ebene befindet sich unsere **[Swagger-Dokumentation](#swagger-dokumentation)**, die als Frontend für die ASF-API dient. Es bietet eine vollständige Dokumentation der ASF-API und ermöglicht einen einfacheren Zugriff darauf. Dies ist es, was Du nutzen solltest, wenn Du vorhast ein Programm, ein Dienstprogramm oder andere Projekte zu schreiben, die über die API mit ASF kommunizieren sollen.

Auf der obersten Ebene gibt es **[ASF-UI](#asf-ui)**, das auf unserer ASF-API basiert und eine benutzerfreundliche Möglichkeit bietet, verschiedene ASF-Aktionen auszuführen. Dies ist unsere Standard IPC-Schnittstelle für Endanwender und ein perfektes Beispiel dafür, was Du mit der ASF-API erstellen kannst. Wenn Du möchtest, kannst Du ihre eigene benutzerdefinierte Web-Benutzeroberfläche für die Verwendung mit ASF benutzen, indem Du `--path` **[Befehlszeilenargument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments-de-DE#argumente)** angibst und das benutzerdefinierten `www` Verzeichnis verwendest.

---

# ASF-UI

ASF-UI ist ein Gemeinschaftsprojekt, das darauf abzielt, eine benutzerfreundliche grafische Weboberfläche für Endbenutzer zu erstellen. Um dies zu erreichen, fungiert es als Frontend für unsere **[ASF-API](#asf-api)**, sodass Du verschiedene Aktionen mit Leichtigkeit durchführen kannst. Dies ist die Standardoberfläche mit der ASF ausgeliefert wird.

Wie bereits erwähnt, ist ASF-UI ein Community-Projekt, das nicht von kern ASF-Entwicklern betreut wird. Es folgt seinem eigenen Fluss in der **[ASF-UI Repository](https://github.com/JustArchiNET/ASF-UI)**, welches für alle damit verbundenen Fragen, Probleme, Fehlerberichte und Vorschläge verwendet werden sollte.

Sie können ASF-UI für die allgemeine Verwaltung des ASF-Prozesses verwenden. Es erlaubt zum Beispiel, Bots zu verwalten, Einstellungen zu ändern, Befehle zu senden und ausgewählte andere Funktionen zu erreichen, die normalerweise über ASF verfügbar sind.

![ASF-UI](https://raw.githubusercontent.com/JustArchiNET/ASF-ui/main/.github/previews/bots.png)

---

# ASF-API

Unsere ASF-API ist eine typische **[RESTful](https://en.wikipedia.org/wiki/Representational_state_transfer)** Web-API, die auf JSON als primärem Datenformat basiert. Wir tun unser Bestes, um die Antwort genau zu beschreiben, indem wir sowohl HTTP-Statuscodes (wo zutreffend) als auch eine Antwort verwenden, die Du selbst analysieren kannst, um zu wissen, ob die Anfrage erfolgreich war und wenn nicht, warum.

Auf unsere ASF-API kann zugegriffen werden, indem entsprechende Anfragen an entsprechende `/Api` Endpunkte gesendet werden. Sie können diese API-Endpunkte verwenden um ihre eigenen Hilfsskripte, Programme, Benutzeroberflächen und ähnliches zu erstellen. Das ist genau das, was unser ASF-UI unter der Haube leistet und jedes andere Programm kann das gleiche erreichen. ASF-API wird offiziell vom ASF-Kernteam unterstützt und gepflegt.

Für eine vollständige Dokumentation der verfügbaren Endpunkte, Beschreibungen, Anfragen, Antworten, http-Statuscodes und alles andere was die ASF-API berücksichtigt, ließ bitte unsere **[swagger-Dokumentation](#swagger-dokumentation)**.

![ASF-API](https://i.imgur.com/yggjf5v.png)

---

# Benutzerdefinierte Konfiguration

Unsere IPC-Schnittstelle unterstützt eine zusätzliche Konfigurationsdatei, `IPC.config`, die in das Standard ASF-Verzeichnis `config` gelegt werden sollte.

Wenn verfügbar, gibt diese Datei die erweiterte Konfiguration des ASF Kestrel http-Servers zusammen mit anderen IPC-bezogenen Einstellungen an. Wenn Du keinen besonderen Anlass hast gibt es keinen Grund für dich diese Datei zu verwenden, da ASF in diesem Fall bereits sinnvolle Standardwerte verwendet.

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

`Endpoints` - Dies ist eine Sammlung von Endpunkten, wobei jeder Endpunkt seinen eigenen eindeutigen Namen hat (wie z. B. `example-http4`) und eine `Url` Eigenschaft (Property), welche die `Protokoll://Host:Port` Abhöradresse angibt. Standardmäßig hört ASF auf IPv4- und IPv6-Http-Adressen, aber wir haben https-Beispiele hinzugefügt die Du bei Bedarf verwenden kannst. Du solltest nur die Endpunkte deklarieren die Du benötigst. Wir haben oben 4 Beispiele hinzugefügt damit Du sie leichter bearbeiten kannst.

`Host` accepts either `localhost`, a fixed IP address of the interface it should listen on (IPv4/IPv6), or `*` value that binds ASF's http server to all available interfaces. Using other values like `mydomain.com` or `192.168.0.*` acts the same as `*`, there is no IP filtering implemented, therefore be extremely careful when you use `Host` values that allow remote access. Dadurch wird der Zugriff auf die IPC-Schnittstelle von ASF von anderen Maschinen aus ermöglicht, was ein Sicherheitsrisiko darstellen kann. In diesem Fall empfehlen wir dringend die Nutzung von `IPCPassword` (und vorzugsweise auch einer eigenen Firewall) **at a minimum**.

`KnownNetworks` - This **optional** variable specifies network addresses which we consider trustworthy. By default, ASF is configured to trust loopback interface (`localhost`, same machine) **only**. Diese Eigenschaft (Property) wird auf zweierlei Weise genutzt. Firstly, if you omit `IPCPassword`, then we'll allow only machines from known networks to access ASF's API, and deny everybody else as a security measure. Secondly, this property is crucial in regards to reverse-proxies accessing ASF, as ASF will honor its headers only if the reverse-proxy server is from within known networks. Honoring the headers is crucial in regards to ASF's anti-bruteforce mechanism, as instead of banning the reverse-proxy in case of a problem, it'll ban the IP specified by the reverse-proxy as the source of the original message. Be extremely careful with the networks you specify here, as it allows a potential IP spoofing attack and unauthorized access in case the trusted machine is compromised or wrongly configured.

`PathBase` - This is **optional** base path that will be used by IPC interface. Defaults to `/` and shouldn't be required to modify for majority of use cases. Wenn Du diese Eigenschaft (Property) änderst, hostest Du die gesamte IPC-Schnittstelle auf einem benutzerdefinierten Präfix, zum Beispiel `http://localhost:1242/MeinPrefix` anstelle von `http://localhost:1242` allein. Die Verwendung von einem benutzerdefinierten `PathBase` könnte in Kombination mit der spezifischen Einrichtung eines Reverse-Proxy erwünscht sein, bei dem Du nur eine bestimmte URL proxyen möchtest, z. B. `meinedomain.com/ASF` statt der gesamten `meinedomain.com` Domain. Normally that would require from you to write a rewrite rule for your web server that would map `mydomain.com/ASF/Api/X` -> `localhost:1242/Api/X`, but instead you can define a custom `PathBase` of `/ASF` and achieve easier setup of `mydomain.com/ASF/Api/X` -> `localhost:1242/ASF/Api/X`.

Wenn Du nicht wirklich einen benutzerdefinierten Basispfad angeben musst, ist es am besten ihn bei der Standardeinstellung zu belassen.

## Beispielkonfigurationen

### Standardport ändern

Die folgende Konfiguration ändert einfach den ASF Listing-Port von `1242` auf `1337`. Sie können jeden beliebigen Port wählen, aber wir empfehlen `1024-32767` Bereich, da andere Ports normalerweise **[registriert sind](https://de.wikipedia.org/wiki/Liste_der_standardisierten_Ports)** **[(engl. Wikipedia)](https://en.wikipedia.org/wiki/Registered_port)**, und kann zum Beispiel `root` Zugriff unter Linux erfordern.

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

If you do not require access from all sources, but for example your LAN only, then it's much better idea to check local IP address of the machine hosting ASF, for example `192.168.0.10` and use it instead of `*` in example config above.

---

# Authentifizierung

Die ASF IPC-Schnittstelle erfordert standardmäßig keine Art von Authentifizierung, da `IPCPassword` auf `null` gesetzt ist. Wenn jedoch `IPCPassword` durch das Setzen eines beliebigen nicht leeren Wertes aktiviert wird, erfordert jeder Aufruf der ASF-API das Passwort, das mit dem eingestellten `IPCPassword` übereinstimmt. Wenn Du die Authentifizierung weglässt oder ein falsches Passwort eingibst, bekommst Du einen `401 - Unauthorized` Fehler. After 5 failed authentication attempts (wrong password), you'll get temporarily blocked with `403 - Forbidden` error.

Die Authentifizierung kann auf zwei verschiedene Arten erfolgen.

## `Authentication` Header

Im Allgemeinen solltest Du HTTP-Request-Header verwenden, indem Du das Feld `Authentication` mit ihrem Passwort als Wert setzt. Die Vorgehensweise hängt davon ab, mit welchem Programm Du auf die IPC-Schnittstelle von ASF zugreifst, z. B. wenn Du `curl` verwendest, dann solltest Du `-H 'Authentication: MeinPasswort'` als Parameter hinzufügen. Auf diese Weise wird die Authentifizierung in den Headern der Anfrage übergeben, wo sie tatsächlich stattfinden soll.

## `password` Parameter im Query-String

Alternativ kannst Du den Parameter `password` an das Ende der URL anhängen die Du aufrufen möchtest, z. B. indem Du `/Api/ASF?password=MeinPasswort` anstelle von `/Api/ASF` allein aufrufst. Dieser Ansatz ist gut genug, aber offensichtlich enthüllt er das Passwort, was nicht unbedingt immer angemessen ist. Darüber hinaus ist es ein zusätzliches Argument im Query-String, das das Aussehen der URL verkompliziert und das Gefühl gibt, dass sie URL-spezifisch ist, während das Passwort für die gesamte ASF-API-Kommunikation gilt.

---

Beide Wege werden unterstützt und es liegt ganz bei dir, welche Du wählen möchtest. Wir empfehlen HTTP-Header überall dort zu verwenden, wo es möglich ist, da es in der Verwendung sinnvoller ist als ein Query-String. Wir unterstützen jedoch auch Query-Strings, hauptsächlich wegen verschiedener Einschränkungen in Bezug auf Request-Header. Ein gutes Beispiel ist das Fehlen von benutzerdefinierten Headern beim Einleiten einer Websocket-Verbindung in JavaScript (obwohl sie nach RFC vollständig gültig ist). In dieser Situation ist ein Query-String die einzige Möglichkeit sich zu authentifizieren.

---

# Swagger Dokumentation

Unsere IPC-Schnittstelle, zusätzlich zu ASF-API und ASF-UI, beinhaltet auch die Swagger-Dokumentation, welche unter der `/swagger` **[URL](http://localhost:1242/swagger) ** verfügbar ist. Die Swagger-Dokumentation dient als Mittelsmann zwischen unserer API-Implementierung und anderen Programmen, die sie verwenden (z. B. ASF-UI). Es bietet eine vollständige Dokumentation und Verfügbarkeit aller API-Endpunkte in der Spezifikation **[OpenAPI](https://swagger.io/resources/open-api)**, die von anderen Projekten problemlos genutzt werden kann, sodass Du ASF-API mit Leichtigkeit schreiben und testen kannst.

Neben der Verwendung unserer Swagger-Dokumentation als komplette Spezifikation der ASF-API kannst Du sie auch als benutzerfreundliche Möglichkeit verwenden, verschiedene API-Endpunkte auszuführen, vor allem solche die nicht von ASF-UI implementiert werden. Da unsere Swagger-Dokumentation automatisch aus ASF-Quelltext generiert wird, hast Du die Garantie, dass die Dokumentation immer auf dem neuesten Stand der API-Endpunkte ist die ihre Version von ASF enthält.

![Swagger Dokumentation](https://i.imgur.com/mLpd5e4.png)

---

# FAQ (oft gestellte Fragen)

### Ist die IPC-Schnittstelle von ASF sicher und sicher in der Anwendung?

ASF hört standardmäßig nur auf `localhost` Adressen, was bedeutet, dass der Zugriff auf ASF IPC von jedem anderen Rechner als ihrem eigenen **nicht möglich ist**. Wenn Du keine Standard-Endpunkte änderst, bräuchte der Angreifer einen direkten Zugriff auf ihren eigenen Computer, um auf ASF IPC zugreifen zu können, daher ist er so sicher wie möglich und es besteht keine Möglichkeit, dass andere Personen auf ihn zugreifen, auch nicht aus ihrem eigenen LAN.

Wenn Du dich jedoch dazu entscheidest die standardmäßig eingestellten `localhost` Adressen an etwas anderes zu binden, dann solltest Du die richtigen Firewall-Regeln **selbst** festlegen, um nur autorisierten IPs den Zugriff auf die IPC-Schnittstelle von ASF zu ermöglichen. In addition to doing that, you will need to set up `IPCPassword`, as ASF will refuse to let other machines access ASF API without one, which adds another layer of extra security. Möglicherweise möchtest Du in diesem Fall auch die IPC-Schnittstelle von ASF hinter einem Reverse-Proxy ausführen, was im Folgenden näher erläutert wird.

### Kann ich mit eigenen Programmen oder Benutzerskripten auf die ASF-API zugreifen?

Ja, dafür wurde die ASF-API entwickelt und Du kannst alles verwenden was fähig ist eine HTTP-Anfrage zu senden um darauf zuzugreifen. Lokale Benutzerskripte folgen der **[CORS](https://en.wikipedia.org/wiki/Cross-origin_resource_sharing)** Logik, und wir erlauben den Zugriff von allen Ursprüngen für diese (`*`) solange `IPCPassword` gesetzt ist (als zusätzliche Sicherheitsmaßnahme). Auf diese Weise kannst Du verschiedene authentifizierte ASF-API-Anfragen ausführen, ohne dass potenziell bösartige Skripte dies automatisch tun können (da sie dazu dein `IPCPassword` kennen müssten).

### Kann ich aus der Ferne auf die IPC-Schnittstelle von ASF zugreifen, z. B. von einem anderen Gerätaus?

Yes, we recommend to use a reverse proxy for that. Auf diese Weise kannst Du wie gewohnt auf deinen Webserver zugreifen, der dann auf dem gleichen Gerät auf die IPC-Schnittstelle von ASF zugreift. Andernfalls, wenn Du nicht mit einem Reverse-Proxy arbeiten möchtest, kannst Du die **[benutzerdefinierte Konfiguration](#benutzerdefinierte-konfiguration)** mit entsprechender URL verwenden. For example, if your machine is in a VPN with `10.8.0.1` address, then you can set `http://10.8.0.1:1242` listening URL in IPC config, which would enable IPC access from within your private VPN, but not from anywhere else.

### Kann ich die IPC-Schnittstelle von ASF hinter einem Reverse-Proxy wie Apache oder Nginx verwenden?

**Ja**, unser IPC ist vollständig kompatibel mit einem solchen Setup, sodass Du ihn auch vor deinen eigenen Programmen hosten kannst, für zusätzliche Sicherheit und Kompatibilität, wenn Du möchtest. Im Allgemeinen ist der Kestrel http-Server von ASF sehr sicher und birgt kein Risiko, wenn er direkt mit dem Internet verbunden ist, aber wenn man ihn hinter einen Reverse-Proxy wie Apache oder Nginx stellt, kann er zusätzliche Funktionen bieten die sonst nicht möglich wären, wie z. B. die Sicherung der ASF-Schnittstelle mit einer **[Basic Authentication](https://en.wikipedia.org/wiki/Basic_access_authentication)**.

Beispielhafte Nginx-Konfiguration findest Du unten. Wir haben den vollen `server` Block eingefügt, obwohl Du dich hauptsächlich für `location` interessierst. Bitte lies die **[nginx-Dokumentation](https://nginx.org/en/docs)** falls Du weitere Erklärungen brauchst.

```nginx
server {
    listen *:443 ssl;
    server_name asf.mydomain.com;
    ssl_certificate /path/to/your/certificate.crt;
    ssl_certificate_key /path/to/your/certificate.key;

    location ~* /Api/NLog {
        proxy_pass http://127.0.0.1:1242;

        # Only if you need to override default host
#       proxy_set_header Host 127.0.0.1;

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
#       proxy_set_header Host 127.0.0.1;

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

Im Folgenden finden Sie ein Beispiel für die Apache Konfiguration. Please refer to **[apache documentation](https://httpd.apache.org/docs)** if you need further explanation.

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

**Yes**, you can achieve it through two different ways. A recommended way would be to use a reverse proxy for that, where you can access your web server through https like usual, and connect through it with ASF's IPC interface on the same machine. Auf diese Weise ist dein Datenverkehr vollständig verschlüsselt und Du musst IPC in keiner Weise ändern um ein solches Setup zu unterstützen.

Second way includes specifying a **[custom config](#custom-configuration)** for ASF's IPC interface where you can enable https endpoint and provide appropriate certificate directly to our Kestrel http server. Dieser Weg wird empfohlen, wenn Du keinen anderen Webserver betreibst und keinen ausschließlich für ASF betreiben möchtest. Andernfalls ist es viel einfacher ein befriedigendes Setup zu erreichen, indem man einen Reverse-Proxy-Mechanismus verwendet.

---

### During startup of IPC I'm getting an error: `System.IO.IOException: Failed to bind to address, An attempt was made to access a socket in a way forbidden by its access permissions`

This error indicates that something else on your machine is either already using that port, or reserved it for future use. This could be you if you're attempting to run second ASF instance on the same machine, but most often that's Windows excluding port `1242` from your usage, therefore you'll have to move ASF to another port. In order to do that, follow **[example config](#changing-default-port)** above, and simply try to pick another port, such as `12420`.

Of course you could also try to find out what is blocking port `1242` from ASF usage, and remove that, but that's usually far more troublesome than simply instructing ASF to use another port, so we'll skip elaborating further on that here.

---

### Why am I getting `403 Forbidden` error when not using `IPCPassword`?

Starting with ASF V5.1.2.1, we've added additional security measure that, by default, allows only loopback interface (`localhost`, your own machine) to access ASF API without `IPCPassword` set in the config. This is because using `IPCPassword` should be a **minimum** security measure set by everybody who decides to expose ASF interface further.

The change was dictated by the fact that massive amount of ASFs hosted globally by unaware users were being taken over for malicious intents, usually leaving people without accounts and without items on them. Now we could say "they could read this page before opening ASF to the entire world", but instead it makes more sense to disallow insecure ASF setups by default, and require from users an action if they explicitly want to allow it, which we elaborate about below.

In particular, you're able to override our decision by specifying the networks which you trust to reach ASF without `IPCPassword` specified, you can set those in `KnownNetworks` property in custom config. However, unless you **really** know what you're doing and fully understand the risks, you should instead use `IPCPassword` as declaring `KnownNetworks` will allow everybody from those networks to access ASF API unconditionally. We're serious, people were already shooting themselves in the foot believing their reverse proxies and iptables rules were secure, but they weren't, `IPCPassword` is the first and sometimes the last guardian, if you decide to opt out of this simple, yet very effective and secure mechanism, you'll have only yourself to blame.