# IPC

ASF 包含一个独特的 IPC 接口，可以用来与进程进行进一步交互。 IPC 指的是&#8203;**[进程间通信](https://en.wikipedia.org/wiki/Inter-process_communication)**（Inter-Process Communication），或者简单来说是基于 **[Kestrel HTTP 服务端](https://github.com/aspnet/KestrelHttpServer)**&#8203;的“ASF Web 接口”，它可以作为最终用户使用的前端（ASF-ui）或者第三方集成工具使用的后端（ASF API），与 ASF 进程进行交互。

IPC 可以用来做很多不同的事情，这取决于您的需求和技能。 例如，您可以用它获取 ASF 和所有机器人的状态、向 ASF 发送命令、获取和修改全局/机器人配置、添加新机器人、删除机器人、向 **[BGR](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer-zh-CN)**（后台游戏激活器）导入游戏序列号或者访问 ASF 的日志文件。 所有操作都由我们的 API 提供，这意味着您可以开发工具或者脚本与 ASF 通信，并且在运行时影响 ASF 的行为。 除此之外，我们的 ASF-ui 还实现了特定的操作（例如发送命令），使您可以通过友好的 Web 界面进行这些操作。

---

# 用法

**[全局配置属性](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-zh-CN#全局配置)** `IPC` 的默认值为 `true`，除非您手动禁用。 ASF 将在日志中提示 IPC 的启动，您可以借此检查 IPC 接口是否正确运行：

```text
INFO|ASF|Start() 正在启动 IPC 服务……
INFO|ASF|Start() IPC 服务已就绪！
```

此时，ASF 的 HTTP 服务器将会监听指定的端点。 如果你没有为 IPC 提供自定义配置文件，则 IPC 将会运行于 IPv4 地址 **[127.0.0.1](http://127.0.0.1:1242)** 和 IPv6 地址 **[[::1]](http://[::1]:1242)** 上的 `1242` 默认端口。 如果是在同一台机器上运行 ASF，您可以通过上面的两个链接访问我们的 IPC 接口。

根据您的不同需求，ASF IPC 提供了三种不同的访问方式。

最底层的方式是 **[ASF API](#asf-api)**，这是我们 IPC 接口的核心功能，允许被其他任何方式调用。 如果您需要您自己的工具、软件和项目直接与 ASF 通信，就应该采用这种方式。

中层的使用方式是 **[Swagger 文档](#swagger-文档)**，它是 ASF API 的直接前端。 它是 ASF API 的完整文档，使您可以轻松访问相应的端点。 如果您计划开发利用 API 与 ASF 通信的工具、软件或项目，就需要查阅这份文档。

**[ASF-ui](#asf-ui)** 是最高层的使用方式，它基于 ASF API，为用户提供了一种简单的方式进行各种 ASF 的操作。 这是我们为最终用户设计的使用 IPC 接口的默认方式，并且它还完美演示了您可以用 ASF API 开发什么。 如果您愿意，可以使用您的自定义 WebUI，即指定 `--path` **[命令行参数](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments-zh-CN#参数)**&#8203;选择从指定位置的 `www` 目录启用 Web 服务。

---

# ASF-ui

ASF-ui 是一个社区项目，主要为最终用户提供了一个用户友好的图形界面 Web 接口。 为了达成这一目的，它被设计为 **[ASF API](#asf-api)** 的前端，使您可以轻松操作 ASF。 这是 ASF 自带的默认 UI。

如上所述，ASF-ui 是一个社区项目，并非由 ASF 核心开发者维护。 它遵循自己的开发流程，所有相关的问题、讨论、漏洞报告和建议都应该发表于 **[ASF-ui 仓库](https://github.com/JustArchiNET/ASF-ui)**。

您可以使用 ASF-ui 对 ASF 进行常规管理。 例如管理机器人、修改设置、发送命令，以及 ASF 提供的各种其他功能。

![ASF-ui](https://raw.githubusercontent.com/JustArchiNET/ASF-ui/main/.github/previews/bots.png)

---

# ASF API

我们的 ASF API 是典型的以 JSON 为数据格式的 **[RESTful](https://en.wikipedia.org/wiki/Representational_state_transfer)** Web API。 我们会尽全力准确地描述响应，不仅通过适当的 HTTP 状态代码，您也可以解析响应体以了解请求是否成功，如果不成功，其原因是什么。

您可以向特定的 `/Api` 端点发送合适的请求以访问 ASF API。 您可以利用这些 API 制作您自己的助手脚本、工具、GUI 前端等。 这正是我们的 ASF-ui 要实现的目标，而任何其他工具也可以做到这一点。 ASF API 由 ASF 核心团队官方支持并维护。

请阅读我们的 **[Swagger 文档](#swagger-文档)**，获取关于 ASF API 端点、描述、请求、响应、HTTP 状态代码等内容的完整文档。

![ASF API](https://i.imgur.com/yggjf5v.png)

---

# 自定义配置

我们的 IPC 接口支持额外的配置文件 `IPC.config`，这个文件应该被放在 ASF 的 `config` 文件夹中。

当该文件存在时，它将为 ASF 的 Kestrel HTTP 服务端指定高级设置和 IPC 相关的调整。 除非您有特殊需要，否则没有理由使用此文件，因为通常 ASF 已经使用了合理的默认值。

配置文件 JSON 结构如下：

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

`Endpoints`——这是端点的集合，每个端点都有自己的唯一名称（例如 `example-http4`） 和 `Url` 属性指定监听地址，其格式为 `Protocol://Host:Port`。 默认情况下，ASF 会监听 IPv4 和 IPv6 的 HTTP 地址，但如果您需要，也可以参考我们的示例设置 HTTPS。 您应该只声​​明您需要的端点，我们在上面包含了 4 个示例端点，以便您可以更轻松地编辑它们。

`Host` 接受 `localhost`、监听接口的固定 IP 地址（IPv4/IPv6）或者表示将 ASF HTTP 服务端绑定到所有可用的网络接口 `*` 值。 使用其他值，例如 `mydomain.com` 或 `192.168.0.*`，效果与 `*` 相同，此处没有实现 IP 过滤，因此如果您设置的 `Host` 值允许远程访问，就必须万分小心。 这样做将会允许其他机器访问 ASF 的 IPC 接口，这可能会带来安全风险。 在这种情况下，我们强烈建议您**至少**设置 `IPCPassword`（并且启用防火墙）。

`KnownNetworks`——此**可选**变量指定我们信任的网段。 默认情况下，ASF 被配置为**仅仅**信任环回接口（`localhost`，或者叫本机）。 此属性有两种用途。 第一，如果您省略 `IPCPassword`，则我们仅允许来自已知网段的机器访问 ASF 的 API，拒绝其他所有人，以此作为一种安全措施。 第二，这一属性对于反向代理访问 ASF 的场景非常关键，因为只有当反向代理服务器来自已知网络时，ASF 才会接受其头部信息。 在 ASF 的反暴力破解机制中，接受头部信息是非常重要的一环，这样在出现问题的情况下，它就不会直接封禁反向代理，而只会封禁反向代理指定的请求源 IP。 您需要对这里指定的网段极为小心，因为一旦可信机器被破坏，或该属性配置错误，就可能导致潜在的 IP 欺骗攻击或未授权访问。

`PathBase`——这个**可选项**指定 IPC 接口使用的根路径。 默认是 `/`，并且在大多数情况下没有必要修改。 通过修改这个属性，您可以为整个 IPC 接口设置自定义前缀，例如以 `http://localhost:1242/MyPrefix` 代替 `http://localhost:1242`。 如果您希望仅代理特定的 URL，使用自定义 `PathBase` 还需要结合特定的反向代理设置，例如代理 `mydomain.com/ASF` 而不是整个 `mydomain.com` 域名。 原本，您需要为您的 Web 服务器编写一个重写规则，将 `mydomain.com/ASF/Api/X` 映射到 `localhost:1242/Api/X`，但通过设置 `PathBase` 为 `/ASF`，您可以更简单地实现从 `mydomain.com/ASF/Api/X` 到 `localhost:1242/ASF/Api/X` 的映射。

除非您确实需要指定自定义根路径，否则最好将其保留为默认值。

## 示例配置

### 更改默认端口

以下配置仅仅将 ASF 默认监听的端口从 `1242` 改为 `1337`。 您可以使用任何端口，但我们推荐在 `1024-32767` 范围内选择，因为其他端口属于典型的[**注册端口**](https://en.wikipedia.org/wiki/Registered_port)，并且在 Linux 上可能需要 `root` 权限。

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

### 允许任何 IP 访问

以下配置允许任何来源的远程访问，因此您应该**确认您已阅读并理解上文的安全警告**。

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

如果您不需要允许所有来源的访问，例如仅允许局域网，那么更好的办法是检查部署 ASF 的设备本地 IP 地址，例如使用 `192.168.0.10` 而非示例中的 `*`。

---

# 身份认证

默认情况下，ASF IPC 接口不需要任何形式的身份验证，因为 `IPCPassword` 被设置为 `null`。 然而，如果 `IPCPassword` 被设置为任意非空值，每个向 ASF API 发送的请求都需要包含匹配 `IPCPassword` 的密码。 如果您省略验证信息或者输入错误的密码，您将会收到 `401 - Unauthorized` 错误。 在认证失败（密码错误）5 次后，您将会被临时封禁，并收到 `403 - Forbidden` 错误。

您可以通过两种方案之一进行身份验证。

## `Authentication` 请求头

通常您应该使用 HTTP 请求头方法，将 `Authentication` 头的值设置为您的密码。 具体的方法取决于您访问 ASF IPC 接口的具体工具，例如，假如您使用 `curl`，就应该添加 `-H 'Authentication: MyPassword'` 命令行参数。 在这种方法中，验证信息被放在请求头部中传送，这也正是这类信息应该在的地方。

## `password` 请求参数

此外，您也可以在调用 URL 的末尾添加 `password` 参数，例如调用 `/Api/ASF?password=MyPassword` 取代 `/Api/ASF`。 这种方法也不错，但显然这会在公开的情况下直接暴露密码，在一些情况下并不合适。 此外，这种方法向请求字符串中添加了额外的参数，使 URL 更复杂，而且看起来像是针对特定 URL 的参数，但实际上密码对整个 ASF API 都适用。

---

这两种方法都受到支持，您可以选择要使用哪一种。 我们建议在任何可能的情况下使用 HTTP 头，从使用的角度来说，它比请求字符串更合适。 但是，我们也支持请求字符串方法，主要的原因是请求头的各种限制。 一个例子是在 Javascript 中启动 WebSocket 时缺少自定义头部支持（尽管这是符合 RFC 标准的操作）。 在这种情况下，请求字符串是进行身份验证的唯一方法。

---

# Swagger 文档

我们的 IPC 接口，除了 ASF API 和 ASF-ui，还包括 Swagger 文档，您可以访问 `/swagger` **[URL](http://localhost:1242/swagger)** 来查看。 Swagger 文档的角色是我们的 API 实现与使用 API 的工具之间的一个中间人。 它在 **[OpenAPI](https://swagger.io/resources/open-api)** 部分包含了所有 API 端点的完整文档与功能说明，您可以在此为其他项目轻松编写与测试 ASF API。

除了查阅 Swagger 文档获取 ASF API 的完整格式以外，您还可以将其作为一种执行各种 API 端点的友好方式，尤其是那些尚未由 ASF-ui 实现的端点。 由于 Swagger 文档是由 ASF 代码自动生成的，因此文档会始终与您所使用的 ASF 版本提供的 API 端点保持一致。

![Swagger 文档](https://i.imgur.com/mLpd5e4.png)

---

# 常见问题

### ASF 的 IPC 接口安全吗？

ASF 默认只会监听 `localhost` 地址，这意味着从本机以外的设备访 ASF IPC 是**不可能的**。 除非您修改了默认的端点，否则攻击者必须能够直接访问您的计算机才能访问 ASF IPC，因此这是足够安全的，其他人无法访问 IPC，即使两者在同一局域网。

然而，如果您决定修改默认的 `localhost` 监听地址，那么您就应该**自行**设置合适的防火墙规则，使其只允许可信的 IP 访问 ASF IPC 接口。 此外，您还需要设置 `IPCPassword`，因为如果不设置，ASF 就会拒绝其他机器访问 ASF API，作为一层额外的安全保护。 您可能还需要将 ASF IPC 部署在一个反向代理背后，我们将会在下文详细说明。

### 我可以在我的工具或者用户脚本中访问 ASF API 吗？

是的，这就是 ASF API 被设计的目的，您可以通过任何能发送 HTTP 请求的工具来使用它。 本地用户脚本遵循 **[CORS](https://en.wikipedia.org/wiki/Cross-origin_resource_sharing)** 逻辑，并且只要启用 `IPCPassword` 作为额外安全措施，我们就允许其中来自任意来源（`*`）的请求。 这允许您执行各种经过验证的 ASF API 请求，而不允许潜在的恶意脚本自动执行此操作（因为它们不知道您设置的 `IPCPassword`）。

### 我可以远程访问 ASF 的 IPC 吗，例如从另一台电脑访问？

是的，我们建议您为此设置反向代理。 通过反向代理，您访问的是 Web 服务器，然后借此作为跳板访问服务器上的 ASF IPC。 或者，如果您不打算运行反向代理，您可以将&#8203;**[自定义配置](#自定义配置)**&#8203;中的 URL 修改为合适的地址。 例如，如果您的设备处于一个 VPN 网络中，地址为 `10.8.0.1`，您就可以在 IPC 配置中设置监听地址为 `http://10.8.0.1:1242`，这将会且仅会在您的这个私有 VPN 网络中启用 IPC。

### 我可以将 ASF 的 IPC 部署在 Apache 或者 Nginx 的反向代理后吗？

**是的**，我们的 IPC 与这种部署方式完全兼容，所以如果您愿意，您也可以在自己的工具前面部署反向代理以增强一层安全性与兼容性。 一般来说，ASF 的 Kestrel HTTP 服务端非常安全，即使直接暴露于互联网也没有什么风险，但将其部署在 Apache 或 Nginx 反向代理后面会提供一些其他方式无法实现的功能，例如添加 **[Basic Auth](https://en.wikipedia.org/wiki/Basic_access_authentication)** 支持以保护 ASF 接口。

下面是一份 Nginx 示例配置文件。 我们在其中包含了完整的 `server` 块，但您可能更关注其中的 `location`。 如果您需要进一步的说明，请参考 **[Nginx 文档](https://nginx.org/en/docs)**。

```nginx
server {
    listen *:443 ssl;
    server_name asf.mydomain.com;
    ssl_certificate /path/to/your/certificate.crt;
    ssl_certificate_key /path/to/your/certificate.key;

    location ~* /Api/NLog {
        proxy_pass http://127.0.0.1:1242;

        # 只需在您需要覆盖默认 Host 时启用
#       proxy_set_header Host 127.0.0.1;

        # 代理 ASF 请求时，应该始终指定 X- 前缀的 HTTP 头
        # 这对正确鉴别源 IP 至关重要，使 ASF 能够封禁真正的攻击者而非您的 Nginx 服务器
        # 指定这些头后，ASF 能正确解析发送请求用户的 IP 地址 - 使 Nginx 真正成为反向代理
        # 如果不这样设置，ASF 会认为您的 Nginx 是客户端 - 此时 Nginx 只是一个普通的代理程序
        # 如果您无法在同一台机器上同时运行 Nginx 与 ASF，则应该额外设置正确的 KnownNetworks
        proxy_set_header X-Forwarded-For $proxy_add_x_forwarded_for;
        proxy_set_header X-Forwarded-Host $host:$server_port;
        proxy_set_header X-Forwarded-Proto $scheme;
        proxy_set_header X-Forwarded-Server $host;
        proxy_set_header X-Real-IP $remote_addr;

        # 我们添加了这 3 个额外的选项用于 WebSockets 代理，详见 https://nginx.org/en/docs/http/websocket.html
        proxy_http_version 1.1;
        proxy_set_header Connection "Upgrade";
        proxy_set_header Upgrade $http_upgrade;
    }

    location / {
        proxy_pass http://127.0.0.1:1242;

        # 只需在您需要覆盖默认 Host 时启用
#       proxy_set_header Host 127.0.0.1;

        # 代理 ASF 请求时，应该始终指定 X- 前缀的 HTTP 头
        # 这对正确鉴别源 IP 至关重要，使 ASF 能够封禁真正的攻击者而非您的 Nginx 服务器
        # 指定这些头后，ASF 能正确解析发送请求用户的 IP 地址 - 使 Nginx 真正成为反向代理
        # 如果不这样设置，ASF 会认为您的 Nginx 是客户端 - 此时 Nginx 只是一个普通的代理程序
        # 如果您无法在同一台机器上同时运行 Nginx 与 ASF，则应该额外设置正确的 KnownNetworks
        proxy_set_header X-Forwarded-For $proxy_add_x_forwarded_for;
        proxy_set_header X-Forwarded-Host $host:$server_port;
        proxy_set_header X-Forwarded-Proto $scheme;
        proxy_set_header X-Forwarded-Server $host;
        proxy_set_header X-Real-IP $remote_addr;
    }
}
```

下面是一份 Apache 示例配置文件。 如果您需要进一步的说明，请参考 **[Apache 文档](https://httpd.apache.org/docs)**。

```apache
<IfModule mod_ssl.c>
    <VirtualHost *:443>
        ServerName asf.mydomain.com

        SSLEngine On
        SSLCertificateFile /path/to/your/fullchain.pem
        SSLCertificateKeyFile /path/to/your/privkey.pem

        # TODO: Apache 不支持大小写不敏感的匹配，因此我们在此写入了两种最常见的情况
        ProxyPass "/api/nlog" "ws://127.0.0.1:1242/api/nlog"
        ProxyPass "/Api/NLog" "ws://127.0.0.1:1242/Api/NLog"

        ProxyPass "/" "http://127.0.0.1:1242/"
    </VirtualHost>
</IfModule>
```

### 我可以通过 HTTPS 协议访问 IPC 吗？

**是的**，有两种方法来实现。 推荐的方法是使用反向代理，您可以像平常一样通过 HTTPS 访问您的 Web 服务器，并且通过它来访问在同一台机器上的 ASF IPC 接口。 这样，您的流量将完全加密，并且您不需要修改 IPC 的设置。

另一种方法是为 ASF IPC 指定&#8203;**[自定义配置](#自定义配置)**，直接为我们使用的 Kestrel HTTP 服务器启用 HTTPS 端点，并且提供合适的 SSL 证书。 如果您没有运行任何其他 Web 服务器，并且也不打算单独为了 ASF 运行，我们更推荐这种方式。 否则，通过反向代理机制来达成目标要容易得多。

---

### 在 IPC 启动过程中，我遇到错误：`System.IO.IOException: Failed to bind to address, An attempt was made to access a socket in a way forbidden by its access permissions`

这个错误表示您机器上的其他程序正在使用此端口，或者已保留用于以后使用。 一种可能是您正在尝试在同一台机器上运行第二个 ASF 实例，但大多数情况下，是 Windows 阻止了您使用 `1242` 端口，因此您必须让 ASF 使用其他端口。 要做到这一点，请按照上述[**示例配置**](#更改默认端口)操作，并修改为其他端口，例如 `12420`。

当然，您也可以尝试找到是什么阻止了 ASF 使用 `1242` 端口，并删除它，但通常这比直接更改 ASF 端口更麻烦，所以我们不会在这里做进一步的说明。

---

### 为什么我如果不使用 `IPCPassword`，就会出现 `403 Forbidden` 错误？

从 ASF V5.1.2.1 版本开始，我们添加了额外的安全措施，默认只允许环回接口（`localhost`，即本机）在不设置 `IPCPassword` 的情况下访问 ASF API。 这是因为，如果任何人决定进一步暴露 ASF 接口，那么设置 `IPCPassword` 就是一项必须的**最低**限度安全措施。

造成这一变化的原因是，很多不知情用户部署的大量公开 ASF 实例被恶意入侵，通常这会导致他们失去自己的帐户和物品。 尽管我们可以说“他们应该在向全世界暴露 ASF 之前阅读此页面”，但默认不允许 ASF 的危险部署方式则更为合理，并且如果用户仍然明确希望允许，则需要用户手动操作，如下文所述。

实际上，您可以强行阻止我们的决定，只需要修改自定义配置文件中的 `KnownNetworks` 属性，指定在不设置 `IPCPassword` 的情况下，ASF 需要信任哪些网段。 但是，除非您**的确**需要这样做，并且完全了解其风险，否则就应该转而使用 `IPCPassword`，因为设置 `KnownNetworks` 将允许网段内的任何人无条件地访问 ASF API。 我们没有在开玩笑，人们已经试过相信他们的反向代理和 iptables 规则是安全的，但实际并非如此，`IPCPassword` 是第一道防线，有时甚至是最后防线，如果您决定放弃这个简单、有效且安全的机制，您就必须为自己的行为负责。