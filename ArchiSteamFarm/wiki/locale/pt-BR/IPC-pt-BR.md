# IPC

O ASF inclui sua própria interface IPC que pode ser usada para maior interação com o processo. IPC é a sigla em inglês para **[Comunicação entre processos](https://pt.wikipedia.org/wiki/Comunica%C3%A7%C3%A3o_entre_processos)** (Inter Process Comunication) e na definição mais simples é a "Interface web do ASF" baseado no **[servidor HTTP Kestrel](https://github.com/aspnet/KestrelHttpServer)** que pode ser usado para uma maior integração com o processo, tanto como um frontend para o usuário final (ASF-ui) quanto um backend para integrações de terceiros (ASF API).

O IPC pode ser usado para muitas coisas diferentes, dependendo de suas necessidades e habilidades. Por exemplo, você pode usá-lo para ver o status do ASF e de todos os bots, enviar comandos ASF, buscar e editar a configuração global ou dos bots, adicionar novos bots, excluir bots existentes, adicionar keys para o **[BGR](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer-pt-BR)** ou acessar o arquivo de log do ASF. Todas essas ações são expostas pela nossa API, o que significa que você pode codificar suas próprias ferramentas e scripts que serão capazes de se comunicar com o ASF e influenciá-lo durante o tempo de execução. Além disso, ações selecionadas (como o envio de comandos) também são implementadas em nosso ASF-ui que permite que você tenha acesso fácil através de uma interface web amigável.

---

# Uso

A menos que você tenha desabilitado manualmente o IPC através da **[propriedade de configuração global](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#global-config)** do `IPC`, ele estará habilitado por padrão. O ASF indicará a execução do IPC em seu log que você pode usar para verificar se a interface IPC foi iniciada corretamente:

```text
INFO|ASF|Start() Iniciando o servidor IPC...
INFO|ASF|Start() Servidor IPC pronto!
```

O servidor http do ASF agora vai escutar nos endpoints selecionados. Se você não forneceu um arquivo de configuração personalizado para o IPC eles serão baseados em IPv4 **[127.0.0.1](http://127.0.0.1:1242)** e baseado em IPv6 **[[:: 1]](http://[::1]:1242)** na porta do padrão `1242`. Você pode acessar nossa interface IPC pelos links acima no mesmo computador que o processo em execução do ASF.

A interface IPC do ASF pode ser acessada de três maneiras diferentes dependendo de como você planeja usá-lo.

No nível mais baixo há o **[ASF API](#asf-api)** que é o núcleo da nossa interface IPC e permite que todo o resto opere. Isso é o que você quer usar em suas próprias ferramentas, utilitários e projetos a fim de comunicar-se diretamente com o ASF.

No nível médio há a nossa **[documentação Swagger](#documentação-Swagger)** que atua como uma interface para o API do ASF. Ela apresenta uma documentação completa para a API do ASF que também permite que você o acesse mais facilmente. Isso é o que você quer checar se você está planejando escrever uma ferramenta, utilitário ou outros projetos supostos a se comunicarem com o ASF por meio da API.

No nível mais alto há a **[ASF-ui](#asf-ui)** que é baseada no nosso API do ASF e fornece uma forma amigável de executar várias ações do ASF. Essa é nossa interface IPC padrão desenvolvida para usuários finais, e um exemplo perfeito do que você pode criar com a API do ASF. Se você quiser, você pode usar sua própria interface web com o ASF, especificando o caminho com o **[](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments-pt-BR#argumentos)** `--path` e utilizando a pasta `www` localizada lá.

---

# ASF-ui

A ASF-ui é um projeto da comunidade que busca criar uma interface gráfica web amigável para usuários finais. Para alcançar isso, ela age como um frontend para o nosso **[ASF API](#asf-api)**, permitindo que você faça várias ações com facilidade. Essa é a interface padrão do usuário que acompanha o ASF.

Como mencionado acima, a ASF-ui é um projeto da comunidade que não é mantido pelos principais desenvolvedores do ASF. Ela segue seu próprio fluxo de desenvolvimento no **[ASF-ui](https://github.com/JustArchiNET/ASF-ui)** que deve ser usado para todas as questões relacionadas a ela, tais como problemas, relatórios de bugs e sugestões.

Você pode usar o ASF-ui para o gerenciamento em geral do processo do ASF. Ele permite por exemplo gerenciar bots, editar configurações, enviar comandos, entre outras funcionalidades normalmente disponíveis através do ASF.

![ASF-ui](https://raw.githubusercontent.com/JustArchiNET/ASF-ui/main/.github/previews/bots.png)

---

# ASF API

Nossa API do ASF é uma típica API web **[RESTful](https://en.wikipedia.org/wiki/Representational_state_transfer)** que é baseada em JSON como formato principal de dados. Estamos fazendo nosso melhor para descrever precisamente a resposta, usando tanto códigos de status HTTP (se for o caso), bem como uma resposta que você pode analisar por sua conta a fim de saber se a solicitação foi bem-sucedida e, se não, por que.

Nossa API do ASF pode ser acessada enviando solicitações apropriadas para determinados `/Api` endpoints. Você pode usar esses API endpoints para criar seus próprios scripts auxiliares, ferramentas, interfaces gráficas e afins. Isso é exatamente o que a nossa ASF-ui faz, e qualquer outra ferramentas podem conseguir o mesmo. O API do ASF é oficialmente suportado e mantido pela equipe principal do ASF.

Para uma documentação completa de endpoints disponíveis, descrições, solicitações, respostas, códigos de status http e tudo o mais em relação a ASF do API, consulte a **[documentação swagger](#documentação-swagger)**.

![ASF API](https://i.imgur.com/yggjf5v.png)

---

# Configuração personalizada

Nossa interface IPC oferece suporte a arquivo de configuração extra, ele deve ser colocado na pasta `config` com o nome `IPC.config`.

Quando disponível, este arquivo especifica configurações avançadas do servidor http Kestrel do ASF, juntamente com outros ajustes relacionados ao IPC. A menos que você tenha uma necessidade específica, não há nenhuma razão para você usar esse arquivo, já que o ASF já está usando padrões razoáveis.

O arquivo de configuração baseia-se na seguinte estrutura JSON:

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

`Endpoints` - Esta é uma coleção de endpoints, cada endpoint tendo seu próprio nome exclusivo (como `exemplo-http4`) e a propriedade `Url` que especifica o endereço de escuta `Protocol://Host:Port`. Por padrão, o ASF ouve nos endereços http IPv4 e IPv6, mas nós adicionamos exemplos http para você usar caso necessário. Você deve declarar apenas os endpoints que você precisa, nós incluímos os 4 exemplos acima para que você possa editá-los.

`Host` aceita tanto`localhost`, um endereço IP fixo da interface que deve ouvir em (IPv4/IPv6), ou o valor `*` que liga o servidor http do ASF a todas as interfaces disponíveis. Usar outros valores como `mydomain.com` ou `192.168.0.*` tem o mesmo valor que usar o `*`, não há filtro de IP implementado, portanto, seja extremamente cuidadoso quando usar valores de `Host` que permitem acesso remoto. Fazer isso vai permitir o acesso a interface IPC do ASF de outros computadores, que pode causar um risco na segurança. Nós recomendamos fortemente usar **ao menos **`IPCPassword` (e de preferência seu firewall também) nesse caso.

`KnownNetworks` - Esta variável **opcional** especifica os endereços de rede que consideramos confiáveis. Por padrão, o ASF está configurado para confiar na interface de loopback (`localhost`, mesma máquina) **apenas**. Esta propriedade é usada de duas maneiras. Primeiramente, se você omitir `IPCPassword`, então permitiremos que apenas máquinas de redes conhecidas tenham acesso a API do ASF, e negaremos todas as outras como medida de segurança. Em segundo lugar, essa propriedade é crucial em relação aos proxies reversos que acessam o ASF, já que o ASF honrará seus cabeçalhos somente se o servidor de proxy reverso for de redes conhecidas. Honrar os cabeçalhos é crucial em relação ao mecanismo anti-bruteforce do ASF, pois ao invés de banir o proxy reverso em caso de um problema, ele irá banir o IP especificado pelo proxy reverso como fonte da mensagem original. Tenha muito cuidado com as redes que você especifica aqui, pois isso permite um potencial ataque de falsificação de IP e acesso não autorizado caso a máquina confiável esteja comprometida ou incorretamente configurada.

`PathBase` - Esse é o diretório base **opcional** que será usado pela interface IPC. O padrão é `/` e não deve ser necessário modificar para a maioria dos casos de uso. Mudar essa propriedade fará com que a interface IPC seja hospedada em um prefixo personalizado, por exemplo `http://localhost:1242/MeuPrefixo` ao invés de apenas `http://localhost:1242`. Usar um `PathBase` personalizado pode ser desejável em combinação com uma configuração específica de proxy reverso, onde você quer que o proxy funcione apenas em uma URL específica, por exemplo `meudomínio.com/ASF` ao invés de todo o domínio `meudomínio.com`. Normalmente isso exigiria que você escrevesse uma regra de reescrita para seu servidor web que poderia mapear `meudomínio.com/ASF/Api/X` -> `localhost:1242/Api/X`, mas em vez disso você pode definir um `PathBase` personalizado como `/ASF` e obter uma configuração mais fácil como `meudomínio.com/ASF/Api/X` -> `localhost:1242/ASF/Api/X`.

A menos que você realmente precise especificar um caminho base personalizado, é melhor deixá-lo padrão.

## Configurações de exemplo

### Alterando a porta padrão

A configuração a seguir muda a porta padrão de escuta do ASF de `1242` para `1337`. Você pode escolher qualquer porta que você quiser, mas nós recomendamos o intervalo entre `1024-32767`, pois as outras portas normalmente já são **[registradas](https://en.wikipedia.org/wiki/Registered_port)**, e podem por exemplo, exigir acesso `root` no Linux.

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

### Habilitando acesso de todos os IPs

A configuração à seguir permite acesso remoto de todas as fontes, portanto você **deve se certificar que leu e entendeu nosso aviso de segurança sobre isso**, disponível acima.

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

Se você não precisa de acesso vindo de todos os locais, mas apenas de sua LAN, por exemplo, é uma ideia muito melhor verificar o endereço IP local da máquina que hospeda o ASF, por exemplo `192.168.0.10` e usá-lo em vez de `*` no exemplo de configuração acima.

---

# Autenticação

A interface ASF do IPC não requer qualquer tipo de autenticação por padrão, já que `IPCPassword` é definido como `null`. No entanto, se `IPCPassword` for definido com qualquer valor não-vazio, todas as chamadas à API do ASF vão requerer a senha correspondente definida em `IPCPassword`. Se você omitir a autenticação ou entrar com uma senha errada, você terá o erro `401 - Unauthorized` erro. Após 5 tentativas de autenticação não sucedidas (senha incorreta), você será temporariamente bloqueado com o erro `403 - Forbidden`.

A autenticação pode ser feita de duas formas diferentes.

## `Authentication` (autenticação) de cabeçalho

Em geral, você deve usar cabeçalhos de solicitação HTTP, configurando o campo `Authentication` com sua senha como um valor. A maneira de fazer isso depende da ferramenta que você está usando para acessar a interface IPC do ASF, por exemplo, se você estiver usando `curl`, então você deve adicionar `-H 'Authentication: MyPassword'` como um parâmetro. Dessa forma a autenticação será passada nos cabeçalhos da solicitação, onde ele de fato deve ocorrer.

## Parâmetro `password` na string de consulta

Como alternativa você pode acrescentar o parâmetro `password` ao final da URL você está prestes a chamar, por exemplo, chamando `/Api/ASF?password=MyPassword` em vez de apenas `/Api/ASF`. Essa abordagem é boa o suficiente, mas obviamente ele expõe sua senha, o que não é necessariamente adequado. Além disso, é um argumento extra na sequência de consulta, o que desorganiza a aparência da URL e da impressão que se aplica somente a essa URL, enquanto a senha se aplica a toda comunicação do API do ASF.

---

Há suporte para ambas as formas e a escolha é totalmente sua em qual usar. Recomendamos usar cabeçalhos HTTP sempre que possível, já que esse tipo de uso é mais apropriado que uma string de consulta. No entanto, apoiamos a sequência de caracteres de consulta, principalmente por causa de várias limitações relacionadas com solicitações de cabeçalhos. Um bom exemplo inclui falta de cabeçalhos personalizados ao iniciar uma conexão de WebSockets em javascript (mesmo que seja completamente válido de acordo com a RFC). Nesta situação uma string de consulta é a única forma de autenticar.

---

# Documentação Swagger

Nossa interface IPC, da API do ASF e do ASF-ui também inclui documentação Swagger, que está disponível em `/swagger` **[URL](http://localhost:1242/swagger)**. A documentação Swagger serve como um intermediário entre a nossa implementação de API e outras ferramentas que a usam (por exemplo, ASF-ui). Ele fornece uma documentação completa e disponibilidade de todos os API endpoints nas especificações do **[OpenAPI](https://swagger.io/resources/open-api)** que pode ser facilmente usada por outros projetos, permitindo que você escreva e teste a API do ASF com facilidade.

Além de usar nossa documentação Swagger como uma especificação completa do API do ASF, você pode também usá-lo como uma maneira amigável de executar vários API endpoints, principalmente aqueles que não são implementados pelo ASF-ui. Como nossa documentação Swagger é gerada automaticamente a partir código ASF, você tem a garantia de que a documentação estará sempre atualizada com os endpoints de API inclusos na sua versão do ASF.

![Documentação Swagger](https://i.imgur.com/mLpd5e4.png)

---

# Perguntas frequentes (FAQ)

### A interface IPC do ASF é segura?

Por padrão o ASF escuta apenas nos endereços `localhost`, o que significa que acessar o IPC do ASF de qualquer outro computador **é impossível**. A menos que você modifique os endpoints padrão, um invasor precisaria de um acesso direto ao seu computador acessar o IPC do ASF, portanto ele é tão seguro quanto possível e não há possibilidade de outra pessoa acessá-lo, até mesmo de sua própria rede doméstica.

No entanto, se você decidir mudar os endereços padrão do `localhost`, então você deve configurar regras de firewall adequadas **por sua conta** para permitir apenas IPs autorizados a acessar a interface de IPC do ASF. Além de fazer isso, você precisará configurar `IPCPassword`, já que o ASF recusará outras máquinas de acessarem ASF API sem esta configuração, cujo adiciona outra camada de segurança extra. Você também pode querer rodar a interface IPC do ASF sob um proxy reverso nesse caso, que será melhor explicado abaixo.

### Posso acessar o API do ASF pelas minhas próprias ferramentas ou userscripts?

Sim, é para isso que a API do ASF foi desenvolvida e você pode usar qualquer coisa capaz de enviar uma solicitação HTTP para acessá-lo. Userscripts locais seguem a lógica **[CORS](https://pt.wikipedia.org/wiki/Cross-origin_resource_sharing)**, e permitimos o acesso a eles de todas as origens (`*`), contanto que uma `IPCPassword` (senha IPC) seja definida, como uma medida de segurança extra. Isso permite que você execute várias solicitações autenticadas da API do ASF, sem permitir que scripts potencialmente mal-intencionados façam isso automaticamente (já que eles precisariam saber sua `IPCPassword` (senha) para fazer isso).

### Posso acessar o IPC do ASF remotamente, de outro computador por exemplo?

Sim, recomendamos usar um proxy reverso para isso. Dessa forma você pode acessar seu servidor web como de costume, o qual então acessará o IPC do ASF no mesmo computador. Como alternativa, se você não quiser executar um proxy reverso, você pode usar uma **[configuração personalizada](#configuração-personalizada)** com uma URL personalizada. Por exemplo, se seu computador estiver em uma VPN com o endereço `10.8.0.1`, então você pode configurar `http://10.8.0.1:1242` como URL de escuta na configuração do IPC, o que habilitaria o acesso IPC de dentro da sua VPN privada, mas não de outro lugar.

### Posso usar o IPC do ASF atrás de um proxy reverso como Apache ou Nginx?

**Sim**, nosso IPC é totalmente compatível com tal configuração, então você também pode usá-lo com suas próprias ferramentas para maior segurança e compatibilidade, se quiser. Em geral, o servidor http Kestrel do ASF é muito seguro e não possui nenhum risco ao ser conectado diretamente à internet, mas colocá-lo atrás de um proxy reverso como Apache ou Nginx pode fornecer funcionalidades extras que não seria possível conseguir de outra forma, como garantir a interface do ASF com uma **[autenticação básica](https://en.wikipedia.org/wiki/Basic_access_authentication)**.

Segue abaixo um exemplo de configuração Nginx. Incluímos um bloco `server` completo, embora você esteja interessado principalmente nos blocos `location`. Consulte a **[documentação nginx](https://nginx.org/en/docs)** se você precisar de mais explicações.

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

Segue abaixo um exemplo de configuração Apache. Consulte a **[documentação](https://httpd.apache.org/docs)** do Apache se você precisar de mais informações.

```apache
<IfModule mod_ssl.c>
    <VirtualHost *:443>
        ServerName asf.mydomain.com

        SSLEngine On
        SSLCertificateFile /path/to/your/fullchain.pem
        SSLCertificateKeyFile /path/to/your/privkey.pem

        # TODO: O Apache não consegue diferenciar maiúsculas de minúsculas corretamente, portanto codificamos os casos mais comuns de uso
        ProxyPass "/api/nlog" "ws://127.0.0.1:1242/api/nlog"
        ProxyPass "/Api/NLog" "ws://127.0.0.1:1242/Api/NLog"

        ProxyPass "/" "http://127.0.0.1:1242/"
    </VirtualHost>
</IfModule>
```

### Posso acessar a interface IPC através do protocolo HTTPS?

**Sim**, isso pode ser feito de duas formas. O recomendado seria o uso de um proxy reverso, onde você pode acessar seu servidor web através de https como de costume, e se conectar através dele com a interface IPC do ASF no mesmo computador. Desta forma o seu tráfego será totalmente criptografado e você não precisa modificar o IPC para que ele ofereça suporte.

A segunda forma inclui especificar uma **[configuração personalizada](#configuração-personalizada)** para a interface IPC do ASF, onde você pode habilitar o endpoint https e fornecer um certificado apropriado diretamente para o nosso servidor http Kestrel. Este modo é recomendado se você não estiver executando nenhum outro servidor web e não quer executar um exclusivamente para o ASF. Caso contrário, é muito mais fácil efetuar uma configuração satisfatória por meio de um mecanismo de proxy reverso.

---

### Durante a inicialização do IPC, estou recebendo um erro: `System.IO.IOException: Falha ao vincular ao endereço, uma tentativa foi feita para acessar um soquete de uma forma proibida por suas permissões de acesso`

Este erro indica que outra coisa em sua máquina já está usando essa porta ou reservou-a para uso futuro. Isso pode ocorrer se você estiver tentando rodar uma segunda instância do ASF na mesma máquina, mas provavelmente seja o Windows bloqueando a porta `1242` para uso, portanto você precisará mover o ASF para outra porta. Para fazer isso, siga o **[exemplo de configuração](#alterando-a-porta-padrão)** acima, e simplesmente tente escolher outra porta, como `12420`.

É claro que você também pode tentar descobrir o que está bloqueando a porta `1242` e remover o bloqueio, mas isso geralmente é muito mais difícil do que simplesmente instruir o ASF a usar outra porta e não entraremos em detalhes sobre isso.

---

### Por que estou recebendo o erro `403 Forbidden` quando não estou usando `IPCPassword`?

Desde o ASF V5.1.2.1, adicionamos uma medida de segurança adicional que, por padrão, permite apenas uma interface de loopback (`localhost`, seu próprio computador) a acessar a API do ASF sem um `IPCPassword` definido na configuração. Isso porque usar um `IPCPassword` deve ser a **medida mínima** de segurança definida por todos os que decidem expor mais a interface do ASF.

A mudança foi criada pelo fato de que uma enorme quantidade de ASFs hospedados globalmente por usuários desavisados estavam sendo roubados com intenções maliciosas, geralmente deixando as pessoas sem suas contas e sem os itens delas. Nós poderíamos dizer: "eles poderiam ler essa página antes de abrir o ASF para o mundo inteiro", mas faz mais sentido não permitir configurações inseguras do ASF por padrão e exigir dos usuários uma ação se eles explicitamente querem permiti-la, sobre a qual falaremos abaixo.

Em particular, você pode ignorar nossa decisão especificando as redes em que você confia para acessar o ASF sem o `IPCPassword` configurado, você pode definir quais são essas redes na propriedade `KnownNetworks` em sua configuração personalizada. No entanto, a menos que você **realmente** saiba o que está fazendo e entenda completamente os riscos, você deve usar um `IPCPassword` pois declarar `KnownNetworks` permitirá que todos os usuários nessas redes acessem incondicionalmente a API do ASF. Nós estamos falando sério, as pessoas já estavam dando um tiro no pé acreditando que seus proxies reversos e suas regras de ip estavam seguras, mas não estavam, o `IPCPassword` é o primeiro e às vezes o último guardião, se decidir optar por não usar esse mecanismo simples, porém muito eficaz e seguro, você só poderá culpar a si mesmo.