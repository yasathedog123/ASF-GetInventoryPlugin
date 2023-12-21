# IPC

ASF含有自己獨特的IPC介面，可以用來與程序進一步交互。 IPC全名為&#8203;**[行程間通訊](https://zh.wikipedia.org/zh-tw/行程間通訊)**&#8203;，在最簡單的定義中，這是基於&#8203;**[Kestrel HTTP伺服器](https://github.com/aspnet/KestrelHttpServer)**&#8203;的「ASF Web介面」，可用於與程序間的進一步整合，既作為終端使用者的前端（ASF-ui）， 也做為第三方整合的後端（ASF API）。

IPC可以用來做很多不同的事情，這取決於您的需求與能力。 舉例來說，您可以使用它來提取ASF與所有Bot的狀態、傳送ASF指令、提取或編輯全域／特定Bot設定、新增新的Bot、刪除現存的Bot、提交&#8203;**[背景序號啟動器](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer-zh-TW)**&#8203;序號，或存取ASF的紀錄檔。 所有這些操作都由我們的API公開，這代表您可以編寫自己的工具及腳本與ASF通訊，並在執行期間產生影響。 除此之外，我們的ASF-ui也實現了特定的操作（例如傳送指令），使您可以透過友善的Web介面輕鬆使用它們。

---

# 使用方法

除非您透過&#8203;`IPC`&#8203;**[全域設定屬性](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-zh-TW#全域設定檔)**&#8203;手動停用IPC，否則預設情形下，它是啟用的。 ASF會在紀錄中說明IPC的啟動，您可以以此來驗證IPC介面是否已正常啟動：

```text
INFO|ASF|Start() 正在啟動 IPC 伺服器…
INFO|ASF|Start() IPC 伺服器已就緒！
```

ASF的HTTP伺服器現在已在監聽指定的端點。 若您沒有為IPC提供自訂設定檔，預設是使用基於IPv4的&#8203;**[127.0.0.1](http://127.0.0.1:1242)**&#8203;及基於IPv6的&#8203;**[[::1]](http://[::1]:1242)**&#8203; &#8203;`1242`&#8203;連接埠。 在執行ASF程序的同一台設備上，您可以透過上述連結存取我們的IPC介面。

依據您的需求，ASF的IPC介面提供了三種不同的存取方法。

最低階的方式是&#8203;**[ASF API](#asf-api)**&#8203;，這是我們IPC介面的核心，允許其他所有操作。 這能在您自己的工具、實用程式及專案中使用，可以與ASF直接進行通訊。

中階的方式是使用我們的&#8203;**[Swagger文件](#swagger-文件)**&#8203;&#8203;作為ASF API的前端。 它具有完整的ASF API文件，並使您能夠更輕鬆地存取它。 若您計畫開發使用API與ASF通訊的工具、實用程式或專案，就需要查閱它。

在最高階，&#8203;**[ASF-ui](#asf-ui)**&#8203;基於我們的ASF API，並提供使用者友善的方式來執行各種ASF操作。 這是我們為最終使用者設計的預設IPC介面，也是您可以使用ASF API組建的完美範例。 若您願意，您可以與您自己的自訂Web UI一起使用，方法是指定&#8203;`--path`&#8203;**[命令列引數](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments-zh-TW#引數)**&#8203;，使用該處的自訂&#8203;`www`&#8203;資料夾。

---

# ASF-ui

ASF-ui是一個社群專案，旨在為最終使用者建立使用者友善的圖形Web介面。 為了實現這一點，它被作為我們&#8203;**[ASF API](#asf-api)**&#8203;的前端，使您能夠輕鬆執行各種操作。 這是ASF自帶的預設UI。

如上所述，ASF-ui是一個社群專案，並非由ASF核心開發人員所維護。 它在&#8203;**[ASF-ui儲存庫](https://github.com/JustArchiNET/ASF-ui)**&#8203;中遵循自身的流程，適用於所有的相關問題、討論、錯誤回報及建議。

您可以使用ASF-ui對ASF程序進行一般管理。 舉例來說，它使您能夠管理Bot、修改設定、傳送指令，及使用ASF提供的其他各種功能。

![ASF-ui](https://raw.githubusercontent.com/JustArchiNET/ASF-ui/main/.github/previews/bots.png)

---

# ASF API

我們的ASF API是典型的&#8203;**[RESTful](https://zh.wikipedia.org/zh-tw/表现层状态转换)**&#8203; Web API，基於JSON作為其主要的資料格式。 我們盡最大努力準確描述回應，不只透過（在適當的情形下）使用HTTP狀態碼，您也可以自行剖析回應來了解請求是否成功，以及如果不成功的原因。

您可以透過向適當的&#8203;`/Api`&#8203;端點傳送適當的請求來存取我們的ASF API。 您可以使用這些API端點來製作您自己的輔助腳本、工具、GUI等。 這正是我們的ASF-ui在幕後所實現的目標，而其他所有工具都可以實現相同目標。 ASF API由ASF核心開發團隊所支援與維護。

有關可用端點、描述、請求、回應、HTTP狀態碼及所有關於ASF API的完整文件，請參閱我們的&#8203;**[Swagger文件](#swagger-文件)**&#8203;。

![ASF API](https://i.imgur.com/yggjf5v.png)

---

# 自訂組態

我們的IPC介面支援額外的設定檔&#8203;`IPC.config`&#8203;，應該放置於ASF的&#8203;`config`&#8203;資料夾中。

如果可用，本檔案將指定ASF的Kestrel HTTP伺服器的進階設定，以及其他與IPC相關的調整。 除非您有特殊需求，否則沒有理由使用此檔案，因為ASF在這個情形下已經使用了合理的預設值。

設定檔基於以下JSON結構：

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
                    "Path": "/路徑/至/certificate.pfx",
                    "Password": "passwordToPfxFileAbove"
                }
            },
            "example-https6": {
                "Url": "https://[::1]:1242",
                "Certificate": {
                    "Path": "/路徑/至/certificate.pfx",
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

`Endpoints`&#8203;：這是端點的集合，每個端點都有自己的唯一名稱（像是&#8203;`example-http4`&#8203;）與&#8203;`Protocol://Host:Port`&#8203;指定監聽地址的&#8203;`Url`&#8203;屬性。 預設情形下，ASF監聽IPv4與IPv6的HTTP位址，但如果需要，我們加入了HTTP範例以供您使用。 您應只宣告您所需的端點，我們在上面包含了4個範例端點，讓您能夠輕鬆地編輯它們。

`Host`&#8203;接受&#8203;`localhost`&#8203;、監聽介面的固定IP位址（IPv4/IPv6），或將ASF的HTTP伺服器綁定至所有可用介面的&#8203;`*`&#8203;值。 使用其他值，像是&#8203;`mydomain.com`&#8203;或&#8203;`192.168.0.*`&#8203;的作用與&#8203;`*`&#8203;相同，沒有實現IP篩選，因此當您使用允許遠端存取的&#8203;`Host`&#8203;值時應格外小心。 這樣將會允許其他設備存取ASF的IPC介面，並可能會帶來安全風險。 在這種情形下，我們強烈建議您&#8203;**至少**&#8203;使用&#8203;`IPCPassword`&#8203;（最好也使用您自己的防火牆）。

`KnownNetworks`&#8203;：本&#8203;**選擇性**&#8203;變數指定我們能夠信任的網路位址。 預設情形下，ASF被設定成&#8203;**只**&#8203;信任回送介面（&#8203;`localhost`&#8203;，同一台設備上）。 這個屬性有兩種用途。 第一，若您省略了&#8203;`IPCPassword`&#8203;，那麼我們將只允許來自已知網路的設備存取ASF的API，並拒絕其他所有設備，以作為一項安全措施。 第二，此屬性對於存取ASF的反向代理至關重要，因為只有當反向代理伺服器來自已知網路時，ASF才會遵守其表頭資料。 遵守表頭資料對於ASF的反暴力破解機制至關重要，因為它不會在出現問題時封鎖反向代理，而是封鎖反向代理原始訊息來源指定的IP。 需格外小心您在此處指定的網路，因為一旦受信任的設備被破解或被錯誤設定，就可能導致欺騙攻擊或未授權的存取。

`PathBase`&#8203;：本&#8203;**選擇性**&#8203;基底路徑將在IPC介面中使用。 預設是&#8203;`/`&#8203;，且在大多數情形下不需修改。 透過修改此屬性，您可以使用自訂前綴代管整個IPC介面，例如使用&#8203;`http://localhost:1242/MyPrefix`&#8203;代替&#8203;`http://localhost:1242`&#8203;。 若您只想代理特定的URL，使用自訂&#8203;`PathBase`&#8203;可能還需要結合特定設定的反向代理，例如代理&#8203;`mydomain.com/ASF`&#8203;而不是整個&#8203;`mydomain.com`&#8203;網域。 通常您需要為您的Web伺服器編寫一個重寫規則，映射&#8203;`mydomain.com/ASF/Api/X`&#8203; -> &#8203;`localhost:1242/Api/X`&#8203;；但您可以定義&#8203;`/ASF`&#8203;的自訂&#8203;`PathBase`&#8203;，來更輕鬆地設定&#8203;`mydomain.com/ASF/Api/X`&#8203; -> &#8203;`localhost:1242/ASF/Api/X`&#8203;。

除非您確實需要指定自訂基底路徑，否則最好保留預設值。

## 設定範例

### 更改預設連接埠

以下設定只是將ASF預設的監聽通訊埠從&#8203;`1242`&#8203;改成&#8203;`1337`&#8203;。 您可以使用任何想要的埠號，但我們的建議範圍是&#8203;`1024-32767`&#8203;，因為其他埠號通常是&#8203;**[註冊的](https://en.wikipedia.org/wiki/Registered_port)**&#8203;，且例如在Linux上可能會需要&#8203;`root`&#8203;權限。

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

### 允許所有 IP 存取

以下設定將允許任何來源的遠端存取，因此您應&#8203;**確保您已閱讀並理解我們關於這些的安全須知**&#8203;，見上文。

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

若您不需從所有來源存取，例如只需您的LAN，那麼最好是檢查代管ASF設備的本機IP位址，例如使用&#8203;`192.168.0.10`&#8203;來代替上述範例設定的&#8203;`*`&#8203;。

---

# 身分驗證

預設情形下，ASF IPC介面不需要任何形式的身分驗證，因為&#8203;`IPCPassword`&#8203;設定成&#8203;`null`&#8203;。 但是，如果&#8203;`IPCPassword`&#8203;被設定成任意非空值來啟用，每個ASF的API呼叫都需要符合&#8203;`IPCPassword`&#8203;的密碼。 若您省略了認證資訊或輸入了錯誤的密碼，您將會收到&#8203;`401 - Unauthorized`&#8203;錯誤。 在5次身分驗證的嘗試失敗後（密碼錯誤），您將收到&#8203;`403 - Forbidden`&#8203;錯誤並會被暫時封鎖。

可以經由兩種方式進行身分驗證。

## `Authentication` 表頭資料

在一般情形下，您應使用&#8203;**[HTTP請求頭欄位](https://zh.wikipedia.org/zh-tw/HTTP%E5%A4%B4%E5%AD%97%E6%AE%B5)**&#8203;，將您的密碼設定成&#8203;`Authentication`&#8203;欄位的值。 具體方式取決於您用於存取ASF的IPC介面的實際工具，例如假設您使用&#8203;`curl`&#8203;，那麼您應加入&#8203;`-H 'Authentication: MyPassword'`&#8203;作為參數。 這種方式的驗證資訊會在請求的頭欄位中傳遞，這也是它應該在的地方。

## Query 字串中的 `password` 參數

另一種方式，您可以將&#8203;`password`&#8203;參數附加到您要呼叫的URL的尾端，例如呼叫&#8203;`/Api/ASF?password=MyPassword`&#8203;來取代&#8203;`/Api/ASF`&#8203;。 這種方式夠好用，但顯然它會公開密碼，這在一些情形下並不適合。 除此之外，它是Query字串中的額外引數，這使URL看起來更加複雜，並讓人感覺它是特定的URL，但實際上這個密碼適用於整個ASF API通訊。

---

兩種方式都受到支援，您可以選擇使用其中一種。 我們建議盡可能使用HTTP頭欄位，因為從使用方面它比Query字串更適合。 但是，我們也支援Query字串，主要的原因是請求頭欄位有各種相關限制。 一個很好的範例是在Javascript中初始化Websocket連線時，缺少自訂的表頭資料（即使這完全符合RFC）。 在這種情形下，Query字串是進行身分驗證的唯一方式。

---

# Swagger 文件

除了ASF API及ASF-ui以外，我們的IPC介面還包含了Swagger文件，可以在&#8203;`/swagger`&#8203; &#8203;**[URL](http://localhost:1242/swagger)**&#8203;下找到。 Swagger文件充當我們的API實施及使用它的其他工具（例如ASF-ui）之間的中間人。 它提供了&#8203;**[OpenAPI](https://swagger.io/resources/open-api)**&#8203;規範中所有API端點的完整文件與功能，其他專案可以輕鬆使用這些端點，使您能夠輕鬆編寫及測試ASF API。

除了將我們的Swagger文件作為ASF API的完整規範以外，您還可以將它當作使用者友善的方式來執行各種API端點，特別主要是那些ASF-ui未實作的端點。 由於我們的Swagger文件是由ASF程式碼自動產生的，因此可以保證文件總是會與您ASF版本中包含的API端點同步至最新。

![Swagger 文件](https://i.imgur.com/mLpd5e4.png)

---

# 常見問題

### ASF 的 IPC 介面安全嗎？

預設情形下，ASF只會在&#8203;`localhost`&#8203;位址上監聽，這代表您自己之外的設備是&#8203;**不可能**&#8203;存取ASF IPC的。 除非您修改了預設的端點，否則攻擊者需要能直接存取您的設備才能存取ASF的IPC，因此這足夠安全，且其他人皆無法存取它，即便是從您的LAN中。

但是，如果您決定將預設的&#8203;`localhost`&#8203;連結位址更改成其他位址，那麼您就應&#8203;**自行**&#8203;設定適合的防火牆規則，來讓只有被授權的IP能存取ASF的IPC介面。 除此之外，您還需要設定&#8203;`IPCPassword`&#8203;，因為在沒有密碼的情形下，ASF會拒絕其他設備存取ASF API，這多增加了一層額外的安全性。 在這種情形下，您可能還想在反向代理後面執行ASF的IPC介面，這會在下面進一步說明。

### 我可以使用自己的工具或腳本存取 ASF API 嗎？

可以，這就是ASF API的設計目的，您可以使用任何能夠傳送HTTP請求的工具來存取它。 本機使用者腳本遵循著&#8203;**[CORS](https://zh.wikipedia.org/zh-tw/跨來源資源共享)**&#8203;邏輯，只要設定了&#8203;`IPCPassword`&#8203;作為額外的安全措施，我們就允許任意來源（&#8203;`*`&#8203;）的存取。 這允許您執行各種經身分驗證的ASF API請求，而不允許可能存在的惡意腳本自動執行此操作（因為它們需要知道您的&#8203;`IPCPassword`&#8203;才能執行操作）。

### 我可以遠端存取 ASF 的 IPC 嗎？例如從另一台設備上？

可以，我們建議您為此使用反向代理。 這樣您就可以使用標準的方式存取您的Web伺服器，然後存取同一台設備上ASF的IPC。 或者，假如您不想使用反向代理來執行，您也可以使用&#8203;**[自訂組態](#自訂組態)**&#8203;中適合的URL。 舉例來說，若您的設備使用VPN且位址為&#8203;`10.8.0.1`&#8203;，那麼您可以在IPC設定中設定監聽URL為&#8203;`http://10.8.0.1:1242`&#8203;，這將會允許您從您的私人VPN啟用IPC存取，且無法從其他地方存取。

### 我可以在 Apache 或 Nginx 等反向代理後使用 ASF 的 IPC 嗎？

**可以**&#8203;，我們的IPC與這類方法完全相容，因此如果您願意，您也可以在自己的工具前自由代管它，以獲得額外的安全性與相容性。 在一般情形下，ASF的Kestrel HTTP伺服器非常安全，即使直接連線至網際網路也沒有什麼風險，但將其部署在例如Apache或Nginx的反向代理後面，能夠提供一些其他方式無法達成的功能，例如使用&#8203;**[HTTP基本認證](https://zh.wikipedia.org/zh-tw/HTTP基本认证)**&#8203;來保護ASF的介面。

下列是Nginx的設定範例。 我們包含了完整的&#8203;`server`&#8203;區塊，但您可能對&#8203;`location`&#8203;區塊更感興趣。 若您需要進一步說明，請參閱&#8203;**[Nginx文件](https://nginx.org/en/docs)**&#8203;。

```nginx
server {
    listen *:443 ssl;
    server_name asf.mydomain.com;
    ssl_certificate /路徑/至/您的/certificate.crt;
    ssl_certificate_key /路徑/至/您的/certificate.key;

    location ~* /Api/NLog {
        proxy_pass http://127.0.0.1:1242;

        # 只有當您需要複寫預設的 Host 時
#       proxy_set_header Host 127.0.0.1;

        # 將請求代理到 ASF 時，應始終指定 X- 頭欄位
        # 這對於正確識別原始 IP 特別重要，使 ASF 能夠封鎖真正的攻擊者而不是你的 Nginx 伺服器
        # 指定它們使 ASF 能夠正確解析發出請求的使用者 IP 位址⸺使 Nginx 成為反向代理
        # 不指定它們會使 ASF 將您的 Nginx 視為用戶端⸺在這種情形下 Nginx 將作為普通代理
        # 若您無法在與 ASF 相同的設備上代管 Nginx 服務，除了上述之外，您很可能還想適當地設定 KnownNetworks
        proxy_set_header X-Forwarded-For $proxy_add_x_forwarded_for;
        proxy_set_header X-Forwarded-Host $host:$server_port;
        proxy_set_header X-Forwarded-Proto $scheme;
        proxy_set_header X-Forwarded-Server $host;
        proxy_set_header X-Real-IP $remote_addr;

        # 我們加入了下列 3 個額外選項用於 Websocket 代理，詳見 https://nginx.org/en/docs/http/websocket.html
        proxy_http_version 1.1;
        proxy_set_header Connection "Upgrade";
        proxy_set_header Upgrade $http_upgrade;
    }

    location / {
        proxy_pass http://127.0.0.1:1242;

        # 只有當您需要複寫預設的 Host 時
#       proxy_set_header Host 127.0.0.1;

        # 將請求代理到 ASF 時，應始終指定 X- 頭欄位
        # 這對於正確識別原始 IP 特別重要，使 ASF 能夠封鎖真正的攻擊者而不是你的 Nginx 伺服器
        # 指定它們使 ASF 能夠正確解析發出請求的使用者 IP 位址⸺使 Nginx 成為反向代理
        # 不指定它們會使 ASF 將您的 Nginx 視為用戶端⸺在這種情形下 Nginx 將作為普通代理
        # 若您無法在與 ASF 相同的設備上代管 Nginx 服務，除了上述之外，您很可能還想適當地設定 KnownNetworks
        proxy_set_header X-Forwarded-For $proxy_add_x_forwarded_for;
        proxy_set_header X-Forwarded-Host $host:$server_port;
        proxy_set_header X-Forwarded-Proto $scheme;
        proxy_set_header X-Forwarded-Server $host;
        proxy_set_header X-Real-IP $remote_addr;
    }
}
```

下列是Apache的設定範例。 若您需要進一步說明，請參閱&#8203;**[Apache文件](https://httpd.apache.org/docs)**&#8203;。

```apache
<IfModule mod_ssl.c>
    <VirtualHost *:443>
        ServerName asf.mydomain.com

        SSLEngine On
        SSLCertificateFile /路徑/至/您的/fullchain.pem
        SSLCertificateKeyFile /路徑/至/您的/privkey.pem

        # TODO: Apache 無法正確進行不區分大小寫的匹配，因此我們硬編碼了兩種最常使用的情形
        ProxyPass "/api/nlog" "ws://127.0.0.1:1242/api/nlog"
        ProxyPass "/Api/NLog" "ws://127.0.0.1:1242/Api/NLog"

        ProxyPass "/" "http://127.0.0.1:1242/"
    </VirtualHost>
</IfModule>
```

### 我可以透過 HTTPS 協定存取 IPC 介面嗎？

**可以**&#8203;，您可以透過兩種不同的方式來達成。 建議的方式是為此使用反向代理，您可以像平常一樣透過HTTPS來存取您的Web伺服器，且透過它來連接同一台設備上的ASF IPC介面。 這樣您的流量將完全被加密，且您無需修改IPC來支援這樣的設定。

第二種方式是為ASF的IPC介面指定&#8203;**[自訂組態](#自訂組態)**&#8203;，您可以在裡面啟用HTTPS端點，並直接向我們的Kestrel HTTP伺服器提供適合的憑證。 若您沒有執行任何其他Web伺服器，且也不想專門為ASF執行Web伺服器，則建議使用這種方法。 否則，透過反向代理機制來達成想要的設定會容易得多。

---

### 在 IPC 的啟動期間，我遇到了錯誤：`System.IO.IOException: Failed to bind to address, An attempt was made to access a socket in a way forbidden by its access permissions`

這個錯誤代表您設備上的其他程式正在使用該連接埠，或者保留於將來使用。 這也可能是您嘗試在同一台設備上執行第二個ASF實例所導致的，但大多數情形下，這是Windows將&#8203;`1242`&#8203;連接埠從您能使用的範圍排除，因此您需要將ASF移至另一個連接埠上。 為此，請依上述&#8203;**[設定範例](#更改預設連接埠)**&#8203;操作，嘗試選擇另一個連接埠，例如&#8203;`12420`&#8203;。

當然，您也可以嘗試找出是什麼阻止ASF使用&#8203;`1242`&#8203;連接埠，並移除它，但這通常比直接讓ASF使用另一個連接埠來的麻煩得多，因此我們在這裡將跳過進一步的詳細說明。

---

### 為什麼我在不使用 `IPCPassword` 時，收到 `403 Forbidden` 錯誤？

ASF包含了了額外的安全措施。在預設情形下，只允許回送介面（&#8203;`localhost`&#8203;，您自己的設備）在不設定&#8203;`IPCPassword`&#8203;的情形下存取ASF API。 這是因為使用&#8203;`IPCPassword`&#8203;應該是每個決定進一步公開ASF介面的人所需的&#8203;**最低限度**&#8203;安全措施。

之所以做出這個改動，是因為大量不知情的使用者代管的ASF被惡意接管，通常會導致他們失去自己的帳號及物品。 雖然我們可以說「他們應當在向全世界公開ASF之前閱讀本頁面」，但預設成不允許不安全的ASF設定則更為合理，且使用者確切想要允許它時，就需要使用者執行操作，我們在下列有詳細的說明。

特別是您可以透過指定您信任的網路來複寫我們的決定，在未指定&#8203;`IPCPassword`&#8203;的情形下存取ASF，您可以在自訂設定中的&#8203;`KnownNetworks`&#8203;屬性中設定它們。 但是，除非您&#8203;**確實**&#8203;知道您在做什麼，且完全了解風險，否則您應該使用&#8203;`IPCPassword`&#8203;，因為宣告&#8203;`KnownNetworks`&#8203;會允許這些網路中的每個人無條件能存取ASF API。 我們非常認真地說，人們已在自作自受，相信他們的反向代理及iptable規則是安全的，但實際上並非如此，&#8203;`IPCPassword`&#8203;是第一道防線，有時也是最後一道，如果您決定退出這種簡單但非常有效的安全機制，那只能自行負責。