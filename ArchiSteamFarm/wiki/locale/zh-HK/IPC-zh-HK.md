# IPC

ASF 包含自己獨特的 IPC 接口，可用於與流程進一步交互。 IPC意為** [進程間通信](https://en.wikipedia.org/wiki/Inter-process_communication) **，最簡單的定義是基於** [ Kestrel HTTP伺服器](https://github.com/aspnet/KestrelHttpServer) **的“ASF網頁界面“，可用於與流程進一步集成，是最終用戶的前端（ASF-ui），亦是第三方工具集成的後端（ASF API）。

根據您的需求和技能，IPC 可用於諸多不同的事情。 例如，您可以使用它來獲取 ASF 和所有機械人的狀態，發送 ASF 命令，獲取和編輯全域/機械人配置，添加新機械人，刪除現有機械人，提交** <a href =“https：/ /github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer">BGR </a> **或訪問 ASF 的日誌檔案。 所有這些操作都由我們的 API 公開，這意味著您可以編輯自己的工具和腳本，以其與 ASF 通信並在運行時對其產生影響。 除此之外，我們的 ASF-ui 還實現了選定的操作（例如發送命令），您可以通過友好的 Web 界面輕鬆訪問它們。

---

# 使用方法

Unless you manually disabled IPC through `IPC` **[global configuration property](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#global-config)**, it's enabled by default. ASF 將在其日誌中聲明 IPC 啟動, 您可以使用該日誌驗證 IPC 介面是否已正常啟動：

```text
INFO|ASF|Start() Starting IPC server...
INFO|ASF|Start() IPC server ready!
```

ASF 的 http 伺服器現在正在偵聽選定的端點。 如果您沒有為 IPC 提供自訂配置檔，預設端點將為基於IPv4 ** [ 127.0.0.1 ](http://127.0.0.1:1242) **和基於IPv6的** [ [:: 1] ](http://[::1]:1242) **的` 1242 `端點。 您可以從與運行 ASF 進程同一台電腦通過以上連結訪問我們的 IPC 接口。

ASF 的 IPC 接口提供了三種不同的訪問方式，具體取決於您的計劃用法。

在最低級別，** [ ASF API ](#asf-api) **是我們 IP C接口的核心，並允許其他所有操作。 這是您希望在自己的工具，實用程序和項目中使用的，以便直接與 ASF 進行通信。

在中等級別，我們的** [Swagger 文件編製 ](#swagger-documentation) **充當了 ASF API 的前端。 它具有 ASF API 的完整文件編製，還允許您更輕鬆地訪問它。 如果您計劃編寫通過其 API 與 ASF 通信的工具、實用程序或其他項目，那麼您可以檢查這一點。

在最高級別，** [ ASF-ui ](#asf-ui) **基於我們的 ASF API，並提供對用戶友好的方式來執行各種 ASF 操作。 這是我們為最終用戶設計的默認 IPC 接口，也是您使用 ASF API 構建的完美示例。 如果您願意，可以使用自訂 Web UI 與 ASF 一起使用，方法是指定 `--path ` **[命令列參數](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments#arguments)**，並使用位於那裡的自定義` www `目錄。

---

# ASF-ui

ASF-ui 是一個社區項目，旨在創建用戶友好的圖形 Web 界面。 為了實現這一目標，它作為我們** [ ASF API ](#asf-api) **的前端，讓您輕鬆地執行各種操作。 這是 ASF 附帶的默認 UI。

如上所述，ASF-ui 是一個社區項目，不由 ASF 核心開發人員維護。 它的所有相關問題、錯誤，漏洞報告和建議應遵循自己的流程** [ ASF-ui repo ](https://github.com/JustArchiNET/ASF-ui) **。

You can use ASF-ui for general management of ASF process. It allows for example to manage bots, modify settings, send commands, and achieve selected other functionality normally available through ASF.

![ASF-ui](https://raw.githubusercontent.com/JustArchiNET/ASF-ui/main/.github/previews/bots.png)

---

# ASF API

我們的ASF API是典型的** [ RESTful ](https://en.wikipedia.org/wiki/Representational_state_transfer) ** Web API，它的主要數據格式基於JSON。 我們正在盡力使用HTTP狀態代碼（在適當的情況下）精確描述響應，以及您可以自己解析的響應，以便了解請求是否成功，以及可能的失敗原因。

可以通過向` /Api `端點發送請求來訪問我們的 ASF API。 您可以使用這些 API 端點來創建自己的幫助程序腳本、工具、GUI 等。 This is exactly what our ASF-ui achieves under the hood, and every other tool can achieve the same. ASF API is officially supported and maintained by core ASF team.

有關可用端點、描述、請求、響應、http 狀態代碼以及相關 ASF API 所有其他內容的完整文件編製 ，請參閱我們的** [ swagger文件編製 ](#swagger-documentation) **。

![ASF API](https://i.imgur.com/yggjf5v.png)

---

# 自訂配置

Our IPC interface supports extra config file, `IPC.config` that should be put in standard ASF's `config` directory.

When available, this file specifies advanced configuration of ASF's Kestrel http server, together with other IPC-related tuning. Unless you have a particular need, there is no reason for you to use this file, as ASF is already using sensible defaults in this case.

設定檔基於以下 JSON 結構：

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

除非您確實需要指定自訂基本路徑，否則最好將其保留為預設路徑。

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

# 身份驗證

ASF IPC 接口不需要任何類型的身份驗證，因為預設情況下` IPCPassword `為` null `。 但是，如果通過設置為任何非空值來啟用` IPCPassword `，則每次調用 ASF 的 API 都需要與` IPCPassword `匹配的密碼。 如果省略身份驗證或輸入錯誤的密碼，您將收到`401 - Unauthorized`錯誤。 After 5 failed authentication attempts (wrong password), you'll get temporarily blocked with `403 - Forbidden` error.

身份驗證可以通過兩種不同的方式完成。

## `Authentication` header

通常，您應該通過設置` Authentication `字段發送對於標頭的 HTTP 請求。 The way of doing that depends on the actual tool you're using for accessing ASF's IPC interface, for example if you're using `curl` then you should add `-H 'Authentication: MyPassword'` as a parameter. This way authentication is passed in the headers of the request, where it in fact should take place.

## `password` parameter in query string

Alternatively you can append `password` parameter to the end of the URL you're about to call, for example by calling `/Api/ASF?password=MyPassword` instead of `/Api/ASF` alone. This approach is good enough, but obviously it exposes password in the open, which is not necessarily always appropriate. In addition to that it's extra argument in the query string, which complicates the look of the URL and makes it feel like it's URL-specific, while password applies to entire ASF API communication.

---

Both ways are supported and it's totally up to you which one you want to choose. We recommend to use HTTP headers everywhere where you can, as usage-wise it's more appropriate than query string. However, we support query string as well, mainly because of various limitations related to request headers. A good example includes lack of custom headers while initiating a websocket connection in javascript (even though it's completely valid according to the RFC). In this situation query string is the only way to authenticate.

---

# Swagger 文件編製

Our IPC interface, in additon to ASF API and ASF-ui also includes swagger documentation, which is available under `/swagger` **[URL](http://localhost:1242/swagger)**. Swagger documentation serves as a middle-man between our API implementation and other tools using it (e.g. ASF-ui). It provides a complete documentation and availability of all API endpoints in **[OpenAPI](https://swagger.io/resources/open-api)** specification that can be easily consumed by other projects, allowing you to write and test ASF API with ease.

Apart from using our swagger documentation as a complete specification of ASF API, you can also use it as user-friendly way to execute various API endpoints, mainly those that are not implemented by ASF-ui. 由於我們的 swagger 文檔是從 ASF 代碼自動生成的，因此您可以保證文檔始終與您的 ASF 版本中包含的API端點中的最新文檔保持同步。

![Swagger 文件編製](https://i.imgur.com/mLpd5e4.png)

---

# 如何使用

### Is ASF's IPC interface secure and safe to use?

ASF by default listens only on `localhost` addresses, which means that accessing ASF IPC from any other machine but your own **is impossible**. Unless you modify default endpoints, attacker would need a direct access to your own machine in order to access ASF's IPC, therefore it's as secure as it can be and there is no possibility of anybody else accessing it, even from your own LAN.

However, if you decide to change default `localhost` bind addresses to something else, then you're supposed to set proper firewall rules **yourself** in order to allow only authorized IPs to access ASF's IPC interface. In addition to doing that, you will need to set up `IPCPassword`, as ASF will refuse to let other machines access ASF API without one, which adds another layer of extra security. You may also want to run ASF's IPC interface behind a reverse proxy in this case, which is further explained below.

### 我可以通過自己的工具或用戶腳本訪問 ASF API 嗎？

是的，這就是ASF API的設計目的，您可以使用任何能夠發送HTTP請求的工具來訪問它。 Local userscripts follow **[CORS](https://en.wikipedia.org/wiki/Cross-origin_resource_sharing)** logic, and we allow access from all origins for them (`*`), as long as `IPCPassword` is set, as an extra security measure. This allows you to execute various authenticated ASF API requests, without allowing potentially malicious scripts to do that automatically (as they'd need to know your `IPCPassword` to do that).

### 我可以從另一台機器遠程訪問 ASF IPC 嗎？

Yes, we recommend to use a reverse proxy for that. This way you can access your web server in typical way, which will then access ASF's IPC on the same machine. Alternatively, if you don't want to run with a reverse proxy, you can use **[custom configuration](#custom-configuration)** with appropriate URL for that. For example, if your machine is in a VPN with `10.8.0.1` address, then you can set `http://10.8.0.1:1242` listening URL in IPC config, which would enable IPC access from within your private VPN, but not from anywhere else.

### 我可以在反向代理（例如 Apache 或 Nginx）後使用 ASF IPC 嗎？

**是的**，我們的 IPC 與此類設置完全兼容，因此如果您願意的話，您可以在使用自己的工具前自由託管它，以獲得額外的安全性和兼容性。 In general ASF's Kestrel http server is very secure and possesses no risk when being connected directly to the internet, but putting it behind a reverse-proxy such as Apache or Nginx could provide extra functionality that wouldn't be possible to achieve otherwise, such as securing ASF's interface with a **[basic auth](https://en.wikipedia.org/wiki/Basic_access_authentication)**.

示例 Nginx 配置可以在下面找到。 We've included full `server` block, although you're interested mainly in `location` ones. Please refer to **[nginx documentation](https://nginx.org/en/docs)** if you need further explanation.

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

### 我可以通過 HTTPS 協議訪問 IPC 接口嗎？

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