# IPC

ASF includes its own unique IPC interface that can be used for further interaction with the process. IPC stands for **[inter-process communication](https://en.wikipedia.org/wiki/Inter-process_communication)** and in the most simple definition this is "ASF web interface" based on **[Kestrel HTTP server](https://github.com/aspnet/KestrelHttpServer)** that can be used for further integration with the process, both as a frontend for end-user (ASF-ui), and backend for third-party integrations (ASF API).

IPC can be used for a lot of different things, depending on your needs and skills. For example, you can use it for fetching status of ASF and all bots, sending ASF commands, fetching and editing global/bot configs, adding new bots, deleting existing bots, submitting keys for **[BGR](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer)** or accessing ASF's log file. All of those actions are exposed by our API, which means that you can code your own tools and scripts that will be able to communicate with ASF and influence it during runtime. In addition to that, selected actions (such as sending commands) are also implemented by our ASF-ui which allows you to easily access them through a friendly web interface.

---

# Gebruik

Unless you manually disabled IPC through `IPC` **[global configuration property](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#global-config)**, it's enabled by default. ASF will state IPC launch in its log, which you can use for verifying if IPC interface has started properly:

```text
INFO|ASF|Start() Starting IPC server...
INFO|ASF|Start() IPC server ready!
```

ASF's http server is now listening on selected endpoints. If you didn't provide a custom configuration file for IPC, those will be IPv4-based **[127.0.0.1](http://127.0.0.1:1242)** and IPv6-based **[[::1]](http://[::1]:1242)** on default `1242` port. You can access our IPC interface by above links, from the same machine as the one running ASF process.

ASF's IPC interface exposes three different ways to access it, depending on your planned usage.

On the lowest level there is **[ASF API](#asf-api)** that is the core of our IPC interface and allows everything else to operate. This is what you want to use in your own tools, utilities and projects in order to communicate with ASF directly.

On the medium ground there is our **[Swagger documentation](#swagger-documentation)** which acts as a frontend to ASF API. It features a complete documentation of ASF API and also allows you to access it more easily. This is what you want to check if you're planning on writing a tool, utility or other projects that are supposed to communicate with ASF through its API.

On the highest level there is **[ASF-ui](#asf-ui)** which is based on our ASF API and provides user-friendly way to execute various ASF actions. This is our default IPC interface designed for end-users, and a perfect example of what you can build with ASF API. If you'd like, you can use your own custom web UI to use with ASF, by specifying `--path` **[command-line argument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments#arguments)** and using custom `www` directory located there.

---

# ASF-ui

ASF-ui is a community project that aims to create user-friendly graphical web interface for end-users. In order to achieve that, it acts as a frontend to our **[ASF API](#asf-api)**, allowing you to do various actions with ease. This is the default UI that ASF comes with.

As stated above, ASF-ui is a community project that isn't maintained by core ASF developers. It follows its own flow in **[ASF-ui repo](https://github.com/JustArchiNET/ASF-ui)** which should be used for all related questions, issues, bug reports and suggestions.

You can use ASF-ui for general management of ASF process. It allows for example to manage bots, modify settings, send commands, and achieve selected other functionality normally available through ASF.

![ASF-ui](https://raw.githubusercontent.com/JustArchiNET/ASF-ui/main/.github/previews/bots.png)

---

# ASF API

Our ASF API is typical **[RESTful](https://en.wikipedia.org/wiki/Representational_state_transfer)** web API that is based on JSON as its primary data format. We're doing our best to precisely describe response, using both HTTP status codes (where appropriate), as well as a response you can parse yourself in order to know whether the request succeeded, and if not, then why.

Our ASF API can be accessed by sending appropriate requests to appropriate `/Api` endpoints. You can use those API endpoints to make your own helper scripts, tools, GUIs and alike. This is exactly what our ASF-ui achieves under the hood, and every other tool can achieve the same. ASF API is officially supported and maintained by core ASF team.

For complete documentation of available endpoints, descriptions, requests, responses, http status codes and everything else considering ASF API, please refer to our **[swagger documentation](#swagger-documentation)**.

![ASF API](https://i.imgur.com/yggjf5v.png)

---

# Custom configuration

Our IPC interface supports extra config file, `IPC.config` that should be put in standard ASF's `config` directory.

When available, this file specifies advanced configuration of ASF's Kestrel http server, together with other IPC-related tuning. Unless you have a particular need, there is no reason for you to use this file, as ASF is already using sensible defaults in this case.

The configuration file is based on following JSON structure:

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

`Endpoints` - This is a collection of endpoints, each endpoint having its own unique name (like `example-http4`) and `Url` property that specifies `Protocol://Host:Port` listening address. By default, ASF listens on IPv4 and IPv6 http addresses, but we've added https examples for you to use, if needed. You should declare only those endpoints that you need, we've included 4 example ones above so you can edit them easier.

`Host` accepts either `localhost`, a fixed IP address of the interface it should listen on (IPv4/IPv6), or `*` value that binds ASF's http server to all available interfaces. Using other values like `mydomain.com` or `192.168.0.*` acts the same as `*`, there is no IP filtering implemented, therefore be extremely careful when you use `Host` values that allow remote access. Doing so will enable access to ASF's IPC interface from other machines, which may pose a security risk. We strongly recommend to use `IPCPassword` (and preferably your own firewall too) **at a minimum** in this case.

`KnownNetworks` - This **optional** variable specifies network addresses which we consider trustworthy. By default, ASF is configured to trust loopback interface (`localhost`, same machine) **only**. This property is used in two ways. Firstly, if you omit `IPCPassword`, then we'll allow only machines from known networks to access ASF's API, and deny everybody else as a security measure. Secondly, this property is crucial in regards to reverse-proxies accessing ASF, as ASF will honor its headers only if the reverse-proxy server is from within known networks. Honoring the headers is crucial in regards to ASF's anti-bruteforce mechanism, as instead of banning the reverse-proxy in case of a problem, it'll ban the IP specified by the reverse-proxy as the source of the original message. Be extremely careful with the networks you specify here, as it allows a potential IP spoofing attack and unauthorized access in case the trusted machine is compromised or wrongly configured.

`PathBase` - This is **optional** base path that will be used by IPC interface. Defaults to `/` and shouldn't be required to modify for majority of use cases. By changing this property you'll host entire IPC interface on a custom prefix, for example `http://localhost:1242/MyPrefix` instead of `http://localhost:1242` alone. Using custom `PathBase` may be wanted in combination with specific setup of a reverse proxy where you'd like to proxy a specific URL only, for example `mydomain.com/ASF` instead of entire `mydomain.com` domain. Normally that would require from you to write a rewrite rule for your web server that would map `mydomain.com/ASF/Api/X` -> `localhost:1242/Api/X`, but instead you can define a custom `PathBase` of `/ASF` and achieve easier setup of `mydomain.com/ASF/Api/X` -> `localhost:1242/ASF/Api/X`.

Unless you truly need to specify a custom base path, it's best to leave it at default.

## Example configs

### Changing default port

The following config simply changes default ASF listening port from `1242` to `1337`. You can pick any port you like, but we recommend `1024-32767` range, as other ports are typically **[registered](https://en.wikipedia.org/wiki/Registered_port)**, and may for example require `root` access on Linux.

```json
{
    "Kestrel": {
        "Endpoints": {
            "HTTP4": {
                "Url": "http://127.0.0.1:1337"
            },
            "HTTP6": {
                "Url": "http://[::1]:1337"
            }
        }
    }
}
```

---

### Enabling access from all IPs

The following config will allow remote access from all sources, therefore you should **ensure that you read and understood our security notice about that**, available above.

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

# Authenticatie

ASF IPC interface by default does not require any sort of authentication, as `IPCPassword` is set to `null`. However, if `IPCPassword` is enabled by being set to any non-empty value, every call to ASF's API requires the password that matches set `IPCPassword`. If you omit authentication or input wrong password, you'll get `401 - Unauthorized` error. After 5 failed authentication attempts (wrong password), you'll get temporarily blocked with `403 - Forbidden` error.

Authentication can be done through two separate ways.

## `Authentication` header

In general you should use HTTP request headers, by setting `Authentication` field with your password as a value. The way of doing that depends on the actual tool you're using for accessing ASF's IPC interface, for example if you're using `curl` then you should add `-H 'Authentication: MyPassword'` as a parameter. This way authentication is passed in the headers of the request, where it in fact should take place.

## `password` parameter in query string

Alternatively you can append `password` parameter to the end of the URL you're about to call, for example by calling `/Api/ASF?password=MyPassword` instead of `/Api/ASF` alone. This approach is good enough, but obviously it exposes password in the open, which is not necessarily always appropriate. In addition to that it's extra argument in the query string, which complicates the look of the URL and makes it feel like it's URL-specific, while password applies to entire ASF API communication.

---

Both ways are supported and it's totally up to you which one you want to choose. We recommend to use HTTP headers everywhere where you can, as usage-wise it's more appropriate than query string. However, we support query string as well, mainly because of various limitations related to request headers. A good example includes lack of custom headers while initiating a websocket connection in javascript (even though it's completely valid according to the RFC). In this situation query string is the only way to authenticate.

---

# Swagger documentation

Our IPC interface, in additon to ASF API and ASF-ui also includes swagger documentation, which is available under `/swagger` **[URL](http://localhost:1242/swagger)**. Swagger documentation serves as a middle-man between our API implementation and other tools using it (e.g. ASF-ui). It provides a complete documentation and availability of all API endpoints in **[OpenAPI](https://swagger.io/resources/open-api)** specification that can be easily consumed by other projects, allowing you to write and test ASF API with ease.

Apart from using our swagger documentation as a complete specification of ASF API, you can also use it as user-friendly way to execute various API endpoints, mainly those that are not implemented by ASF-ui. Since our swagger documentation is generated automatically from ASF code, you have a guarantee that the documentation will always be up-to-date with the API endpoints that your version of ASF includes.

![Swagger documentation](https://i.imgur.com/mLpd5e4.png)

---

# FAQ (veelgestelde vragen)

### Is ASF's IPC interface secure and safe to use?

ASF by default listens only on `localhost` addresses, which means that accessing ASF IPC from any other machine but your own **is impossible**. Unless you modify default endpoints, attacker would need a direct access to your own machine in order to access ASF's IPC, therefore it's as secure as it can be and there is no possibility of anybody else accessing it, even from your own LAN.

However, if you decide to change default `localhost` bind addresses to something else, then you're supposed to set proper firewall rules **yourself** in order to allow only authorized IPs to access ASF's IPC interface. In addition to doing that, you will need to set up `IPCPassword`, as ASF will refuse to let other machines access ASF API without one, which adds another layer of extra security. You may also want to run ASF's IPC interface behind a reverse proxy in this case, which is further explained below.

### Can I access ASF API through my own tools or userscripts?

Yes, this is what ASF API was designed for and you can use anything capable of sending a HTTP request to access it. Local userscripts follow **[CORS](https://en.wikipedia.org/wiki/Cross-origin_resource_sharing)** logic, and we allow access from all origins for them (`*`), as long as `IPCPassword` is set, as an extra security measure. This allows you to execute various authenticated ASF API requests, without allowing potentially malicious scripts to do that automatically (as they'd need to know your `IPCPassword` to do that).

### Can I access ASF's IPC remotely, e.g. from another machine?

Yes, we recommend to use a reverse proxy for that. This way you can access your web server in typical way, which will then access ASF's IPC on the same machine. Alternatively, if you don't want to run with a reverse proxy, you can use **[custom configuration](#custom-configuration)** with appropriate URL for that. For example, if your machine is in a VPN with `10.8.0.1` address, then you can set `http://10.8.0.1:1242` listening URL in IPC config, which would enable IPC access from within your private VPN, but not from anywhere else.

### Can I use ASF's IPC behind a reverse proxy such as Apache or Nginx?

**Yes**, our IPC is fully compatible with such setup, so you're free to host it also in front of your own tools for extra security and compatibility, if you'd like to. In general ASF's Kestrel http server is very secure and possesses no risk when being connected directly to the internet, but putting it behind a reverse-proxy such as Apache or Nginx could provide extra functionality that wouldn't be possible to achieve otherwise, such as securing ASF's interface with a **[basic auth](https://en.wikipedia.org/wiki/Basic_access_authentication)**.

Example Nginx configuration can be found below. We've included full `server` block, although you're interested mainly in `location` ones. Please refer to **[nginx documentation](https://nginx.org/en/docs)** if you need further explanation.

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

Example Apache configuration can be found below. Please refer to **[apache documentation](https://httpd.apache.org/docs)** if you need further explanation.

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

### Can I access IPC interface through HTTPS protocol?

**Yes**, you can achieve it through two different ways. A recommended way would be to use a reverse proxy for that, where you can access your web server through https like usual, and connect through it with ASF's IPC interface on the same machine. This way your traffic is fully encrypted and you don't need to modify IPC in any way to support such setup.

Second way includes specifying a **[custom config](#custom-configuration)** for ASF's IPC interface where you can enable https endpoint and provide appropriate certificate directly to our Kestrel http server. This way is recommended if you're not running any other web server and don't want to run one exclusively for ASF. Otherwise, it's much easier to achieve a satisfying setup by using a reverse proxy mechanism.

---

### During startup of IPC I'm getting an error: `System.IO.IOException: Failed to bind to address, An attempt was made to access a socket in a way forbidden by its access permissions`

This error indicates that something else on your machine is either already using that port, or reserved it for future use. This could be you if you're attempting to run second ASF instance on the same machine, but most often that's Windows excluding port `1242` from your usage, therefore you'll have to move ASF to another port. In order to do that, follow **[example config](#changing-default-port)** above, and simply try to pick another port, such as `12420`.

Of course you could also try to find out what is blocking port `1242` from ASF usage, and remove that, but that's usually far more troublesome than simply instructing ASF to use another port, so we'll skip elaborating further on that here.

---

### Why am I getting `403 Forbidden` error when not using `IPCPassword`?

Starting with ASF V5.1.2.1, we've added additional security measure that, by default, allows only loopback interface (`localhost`, your own machine) to access ASF API without `IPCPassword` set in the config. This is because using `IPCPassword` should be a **minimum** security measure set by everybody who decides to expose ASF interface further.

The change was dictated by the fact that massive amount of ASFs hosted globally by unaware users were being taken over for malicious intents, usually leaving people without accounts and without items on them. Now we could say "they could read this page before opening ASF to the entire world", but instead it makes more sense to disallow insecure ASF setups by default, and require from users an action if they explicitly want to allow it, which we elaborate about below.

In particular, you're able to override our decision by specifying the networks which you trust to reach ASF without `IPCPassword` specified, you can set those in `KnownNetworks` property in custom config. However, unless you **really** know what you're doing and fully understand the risks, you should instead use `IPCPassword` as declaring `KnownNetworks` will allow everybody from those networks to access ASF API unconditionally. We're serious, people were already shooting themselves in the foot believing their reverse proxies and iptables rules were secure, but they weren't, `IPCPassword` is the first and sometimes the last guardian, if you decide to opt out of this simple, yet very effective and secure mechanism, you'll have only yourself to blame.