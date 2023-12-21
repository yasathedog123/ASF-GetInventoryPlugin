# Configuração

Esta página é dedicada a configuração do ASF. Ela serve como uma documentação completa da pasta `config`, permitindo que você modifique o ASF conforme suas necessidades.

* **[Introdução](#introdução)**
* **[Gerador de configuração web](#gerador-de-configuração-web)**
* **[Configuração da Interface do ASF](#configuração-da-interface-do-asf)**
* **[Configuração manual](#configuração-manual)**
* **[Configuração global](#configuração-global)**
* **[Configuração do Bot](#configuração-do-bot)**
* **[Estrutura de arquivos](#estrutura-de-arquivos)**
* **[Mapeamento JSON](#mapeamento-json)**
* **[Mapeamento de compatibilidade](#mapeamento-de-compatibilidade)**
* **[Configuração de compatibilidade](#configuração-de-compatibilidade)**
* **[Recarregamento automático](#recarregamento-automático)**

---

## Introdução

A configuração do ASF é dividida em duas partes principais: configuração global (do processo) e configuração individual dos bots. Cada bot tem seu próprio arquivo de configuração chamado `BotName.json` (onde `BotName` é o nome dado ao bot), enquanto as configurações globais (do processo) do ASF estão em um único arquivo chamado `ASF.json`.

Chamamos de bot qualquer conta do Steam usada no processo do ASF. Para trabalhar corretamente, o ASF precisa de pelo menos **uma** conta bot definida. Não há limite imposto pelo processo quanto a quantidade, então você pode usar quantos bots (contas Steam) quiser.

O ASF usa o formato **[JSON](https://pt.wikipedia.org/wiki/JSON)** para armazenar seus arquivos de configuração. Ele é um formato amigável, legível e universal, no qual você pode configurar o programa. Porém não se preocupe, você não precisa saber JSON para configurar o ASF. Apenas mencionei isso para o caso de você desejar criar configurações em massa do ASF com algum tipo de script.

A configuração pode ser feita de várias formas. Você pode usar nosso **[Gerador de configuração web](https://justarchinet.github.io/ASF-WebConfigGenerator)**, que é um aplicativo local independente do ASF. Você pode usar nosso front-end IPC **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-pt-BR#asf-ui)** para configurar diretamente no ASF. Ou você sempre pode gerar arquivos de configuração manualmente, já que eles seguem uma estrutura JSON fixa como mostrado abaixo. Explicaremos brevemente as opções disponíveis.

---

## Gerador de configuração web

A função do **[Gerenciador de Configuração web](https://justarchinet.github.io/ASF-WebConfigGenerator)** é proporcionar uma interface amigável a ser utilizada na geração de configurações para o ASF. O gerador de configuração Web funciona 100% no lado do cliente, o que significa que os detalhes que você está inserindo não são enviados para nenhum lugar, mas processados apenas no seu computador. Isto garante segurança e confiabilidade, pois ele pode até mesmo trabalhar **[off-line](https://github.com/JustArchiNET/ASF-WebConfigGenerator/tree/main/docs)**, basta baixar todos os arquivos e executar o `index.html` no seu navegador favorito.

O Gerador de configuração Web foi testado e roda perfeitamente no Chrome e no Firefox, e deve funcionar corretamente em todos os navegadores mais populares com javascript habilitado.

O uso é muito simples: selecione se você deseja gerar uma configuração `ASF` ou `Bot` alternando para a guia adequada, certifique-se de que a versão do arquivo de configuração corresponde a sua versão do ASF, então insira todos os dados e clique no botão "download". Mova este arquivo para a pasta `config` do ASF, substituindo os arquivos existentes, caso necessário. Repita esses passos para todas as eventuais modificações e recorra ao resto desta seção para uma explicação de todas as opções disponíveis de configuração.

---

## Configuração da Interface do ASF

Nossa interface IPC **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-pt-BR#asf-ui)** também permite que você configure o ASF, e é a melhor forma de reconfigurar o ASF depois de gerar as configurações iniciais devido ao fato de você poder editar as configurações in-loco, diferente do Gerador de Configuração web que as gera estaticamente.

Para usar a ASF-ui você deve habilitar nossa interface **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-pt-BR)**. `IPC` is enabled by default, therefore you can access it right away, as long as you didn't disable it yourself.

Depois de iniciar o programa simplesmente navegue para o endereço **[IPC](http://localhost:1242)** do ASF. Se tudo funcionou corretamente, você poderá alterar a configuração do ASF por lá também.

---

## Configuração manual

Em geral, recomendamos fortemente o uso do nosso Gerador de Configuração ou da ASF-ui, pois é muito mais fácil e garante que você não cometa nem um erro na estrutura JSON, mas se por algum motivo você não quiser, então você também pode criar as configurações adequadas manualmente. Confira os exemplos JSON abaixo para ter uma boa ideia da estrutura correta, você pode copiar o conteúdo em um arquivo e usá-lo como base para suas configurações. Já que que você não estará usando nenhuma das nossas interfaces, certifique-se que sua configuração é **[válida](https://jsonlint.com)**, pois o ASF não vai carregá-la se ela não puder ser analisada. Mesmo se for um JSON válido, você ainda precisa garantir que todas as propriedades tenham o tipo adequado, conforme exigido pelo ASF. Para conhecer a estrutura JSON correta de todos os campos disponíveis consulte a seção **[mapeamento JSON](#mapeamento-json)** abaixo na nossa documentação.

---

## Configuração global

A configuração global esta localizada no arquivo `ASF.json` e tem a seguinte estrutura:

```json
{
    "AutoRestart": true,
    "Blacklist": [],
    "CommandPrefix": "!",
    "ConfirmationsLimiterDelay": 10,
    "ConnectionTimeout": 90,
    "CurrentCulture": null,
    "Debug": false,
    "DefaultBot": null,
    "FarmingDelay": 15,
    "FilterBadBots": true,
    "GiftsLimiterDelay": 1,
    "Headless": false,
    "IdleFarmingPeriod": 8,
    "InventoryLimiterDelay": 4,
    "IPC": true,
    "IPCPassword": null,
    "IPCPasswordFormat": 0,
    "LicenseID": null,
    "LoginLimiterDelay": 10,
    "MaxFarmingTime": 10,
    "MaxTradeHoldDuration": 15,
    "MinFarmingDelayAfterBlock": 60,
    "OptimizationMode": 0,
    "SteamMessagePrefix": "/me ",
    "SteamOwnerID": 0,
    "SteamProtocols": 7,
    "UpdateChannel": 1,
    "UpdatePeriod": 24,
    "WebLimiterDelay": 300,
    "WebProxy": null,
    "WebProxyPassword": null,
    "WebProxyUsername": null
}
```

---

Todas as opções são explicadas abaixo:

### `AutoRestart`

Tipo `bool` com o valor padrão `true`. Esta propriedade define se o ASF pode auto-reiniciar caso seja necessário. Existem alguns eventos que requerem a reinicialização do ASF, tal como a atualização (feita com o comando `UpdatePeriod` ou `update`), edições na configuração do `ASF.json`, e o comando `restart`. A reinicialização geralmente envolve duas partes: criar um novo processo e encerrar o atual. O valor padrão `true` deve ser bom para a maioria dos usuários, no entanto se você estiver executando o ASF através de seu próprio código e/ou com o `dotnet`, você pode querer ter controle total sobre o início do processo, e evitar a possibilidade de ter um novo processo (reiniciado) do ASF sendo executado em segundo plano em algum lugar e não no código em primeiro plano, que foi encerrado junto com o antigo processo do ASF. Isto é especialmente importante considerando o fato de que o novo processo deixaria de ser descendente direto do seu script, o que te impossibilitaria de usar as suas entradas de console para ele.

Se for esse o caso, essa propriedade existe especialmente para você e você pode definí-la como `false`. Contudo, tenha em mente que, assim, **você** é o responsável por reiniciar o processo. É importante citar isso pois o ASF vai apenas fechar ao invés de criar um novo processo (por exemplo, após uma atualização), então se você não adicionou uma lógica para esse caso, ele vai simplesmente parar de funcionar até que você o inicie novamente. O ASF sempre fecha com um código de erro apropriado indicando sucesso (zero) ou falha (diferente de zero), assim você pode adicionar a lógica correta em seu código, que deve evitar o reinício automático do ASF em caso de falha ou ao menos fazer uma cópia local do `log.txt` para análise posterior. Também tenha em mente que o comando `restart` sempre vai reiniciar o ASF, independente de como essa propriedade está configurada, pois ela define o comportamento padrão, enquanto o comando `restart ` sempre reinicia o processo. A menos que você tenha um motivo para desativar esse recurso, você deve mantê-lo ativado.

---

### `Blacklist`

Tipo `ImmutableHashSet<uint>` com o valor padrão vazio. Como o nome sugere, esta propriedade de configuração global define appIDs (jogos) que serão totalmente ignorados pelo processo de coleta automático. Infelizmente, o Steam adora marcar as insígnias das promoções de verão/inverno como "disponíveis para recebimento de cartas", o que confunde o processo do ASF, fazendo-o acreditar que é um jogo válido que deve ser coletado. Se não houvesse nenhum tipo de lista negra, o ASF acabaria por "travar" na coleta de um jogo que na verdade não é um jogo, e esperaria infinitamente pelo recebimento de cartas que nunca viriam. A lista negra do ASF serve para marcar essas insígnias como não disponíveis para a coleta, de modo que podemos silenciosamente ignorá-las e assim não cair na armadilha.

O ASF inclui duas listas negras padrão: a `SalesBlacklist`, que está codificada dentro do código do ASF e não pode ser editada, e a `Blacklist` normal, que é definida aqui. A `SalesBlacklist` é atualizada juntamente com o ASF e normalmente inclui todos os appIDs "ruins" no momento do lançamento, então se você estiver usando a última versão você não precisa manter a sua `Blacklist` própria, descrita aqui. O principal objetivo desta propriedade é permitir que você adicione novos appIDs, ainda não conhecidos no momento do lançamento de uma nova versão do ASF, que não devam ser coletados. A `SalesBlacklist` é atualizada o mais rápido possível, portanto não há necessidade de atualizar a sua `Blacklist` caso você esteja usando a versão mais recente do ASF, mas sem a `Blacklist` você será forçado a atualizar o ASF para que ele "continue rodando" sempre que a Valve liberar novas insígnias de promoções - não quero forçá-lo a usar o código mais recente do ASF, portanto ela existe para que você "conserte" o ASF por sua conta se por algum motivo você não quer ou não pode atualizar a `SalesBlacklist` disponível em uma nova versão do ASF, mais ainda quer manter seu velho ASF funcionando. A menos que você tenha uma razão muito **forte** para editar essa propriedade, você deve mantê-la padrão.

Se você está procurando uma lista negra personalizada para cada bot, dê uma olhada nos **[comandos](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** `fb`, `fbadd` e `fbrm`.

---

### `CommandPrefix`

Tipo `string` com o valor padrão `!`. Esta propriedade define o prefixo, ** diferenciando maiúsculas de minúsculas**, usado para os **[comandos](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-pt-BR)** do ASF. Em outras palavras, é isso que você precisa digitar antes de cada comando do ASF para fazer com que ele te ouça. Esse parâmetro pode receber o valor `null` ou uma string vazia para forçar o ASF a não usar o prefixo, neste caso os comandos são inseridos simplesmente por seus identificadores. No entanto, fazer isso provavelmente vai diminuir o desempenho do ASF já que ele é otimizado para não analisar mensagens que não forem iniciadas com o `CommandPrefix` - se você decidir não usar prefixos, o ASF será forçado a ler todas as mensagens e respondê-las, mesmo se elas não forem comandos. Portanto, é recomendável usar algum `CommandPrefix`, como `/` se você não gostar do valor padrão `!`. Para obter consistência, `CommandPrefix` afeta todo o processo do ASF. A menos que você tenha uma razão para editar essa propriedade, você deve mantê-la padrão.

---

### `ConfirmationsLimiterDelay`

Tipo `byte` com o valor padrão `10`. O ASF vai garantir que haverá pelo menos o número de segundos de atraso definido em `ConfirmationsLimiterDelay` entre duas solicitações consecutivas de confirmações 2FA para evitar ativar o limitador de tráfego - aquelas que são usadas pelo **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication-pt-BR)** durante, por exemplo, o comando `2faok`, bem como em várias operações relacionadas a troca. O valor padrão foi definido com base em nossos testes e não deve ser diminuído se você não quiser ter problemas. A menos que você tenha uma razão muito **forte** para editar essa propriedade, você deve mantê-la padrão.

---

### `ConnectionTimeout`

Tipo `byte` com o valor padrão `90`. Essa propriedade define o tempo limite em segundos para várias ações de rede feitas pelo ASF. Em particular, `ConnectionTimeout` define o tempo limite em segundos para solicitações HTTP e IPC, `ConnectionTimeout / 10` define o número máximo de pulsos perdidos, enquanto `ConnectionTimeout / 30` define o número de minutos que permitimos para a solicitação inicial de conexão da Rede Steam. O valor padrão de `90` deve ser adequado para a maioria dos usuários, no entanto, se você tem uma conexão de rede ou PC muito lento, convém aumentar esse número um pouco (uns `120`, por exemplo). Tenha em mente que valores maiores não vão magicamente resolver lentidões ou mesmo alcançar servidores Steam inacessíveis, então nós não devemos esperar infinitamente por algo que não vai acontecer, devemos simplesmente tentar novamente mais tarde. Definir um valor muito alto vai resultar em um atraso excessivo na captura de problemas de rede, bem como na diminuição do desempenho global. Definir um valor muito baixo vai diminuir a estabilidade total e o desempenho, uma vez que o ASF abortará solicitações válidas que ainda estejam sendo analisadas. Portanto, definir esse valor abaixo do padrão não traz nenhuma vantagem, uma vez que os servidores Steam tendem a ser muito lentos de vez em quando e podem exigir mais tempo para analisar pedidos do ASF. O valor padrão é um equilíbrio entre acreditar que nossa conexão de rede é estável e duvidar que a Rede Steam vai manipular nosso pedido em determinado limite de tempo. Se você deseja detectar problemas de rede o quanto antes e fazer o ASF reconectar/responder mais rápido, então o valor padrão deve bastar (você pode diminuir um pouco, `60` por exemplo, para que o ASF se torne menos paciente). Se você notar que o ASF está tendo problemas de rede, tais como falhas em solicitações, pulsos perdidos ou conexões com a Rede Steam interrompidas, possivelmente vale a pena aumentar esse valor se tiver certeza que o problema **não** é causado pela sua rede, mas pela própria Steam, uma vez que aumentar o tempo de espera torna o ASF mais "paciente" e não decidido a se reconectar imediatamente.

Um exemplo de situação que pode necessitar do aumento desse valor é permitir que o ASF lide com uma quantidade muito grande de ofertas de troca que podem demorar cerca de 2 minutos ou mais para serem completamente aceitas e manipuladas pelo Steam. Aumentando o tempo padrão, o ASF será mais paciente e esperará mais tempo antes de decidir cancelar a troca e abandonar o pedido inicial.

Uma outra situação poderia ser causada por conta de um computador ou conexão com a internet muito lentos que requerem mais tempo para manipular os dados transmitidos. Essa é uma situação muito rara, uma vez que o CPU/Largura de banda quase nunca são um gargalo, mas ainda é uma situação que vale ser mencionada.

Em resumo, o valor padrão é suficiente para a maioria dos casos, mas você pode querer aumentá-lo se necessário. Ainda, indo muito acima do valor padrão não faz muito sentido, uma vez que limites de tempo maiores não consertam magicamente servidores Steam inacessíveis. A menos que você tenha uma razão para editar essa propriedade, você deve mantê-la padrão.

---

### `CurrentCulture`

Tipo `string` com o valor padrão `null`. Por padrão o ASF tenta usar o idioma do seu sistema operacional e vai preferir usar linhas traduzidas para esse idioma se disponível. Isto é possível graças à nossa comunidade que tenta **[traduzir](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Localization-pt-BR)** o ASF para quase todos os idiomas mais populares. Se por algum motivo você não quiser usar o idioma nativo do seu SO, você pode usar esta propriedade de configuração para escolher qualquer outro idioma válido. Para obter uma lista de todas os idiomas disponíveis, visite o **[MSDN](https://msdn.microsoft.com/en-us/library/cc233982.aspx)** e procure por `Language tag`. É bom notar que o ASF aceita tanto instruções de idioma por região, como `"en-GB"`, quanto neutros, como `"en"`. Especificar o idioma atual também pode afetar outros comportamentos regionais específicos, como formato de moeda/data e outros. Por favor, note que você pode precisar de pacotes de idioma/fontes adicionais para exibir caracteres específicos do idioma corretamente, caso você tenha escolhido um idioma não-nativo que faça uso deles. Normalmente você fará uso desta propriedade se preferir o ASF em inglês ao invés da sua língua nativa.

---

### `Debug`

Tipo `bool` com o valor padrão `false`. Esta propriedade define se o processo deve ser executado em modo de depuração. Quando em modo de depuração, o ASF cria uma pasta especial chamada `debug` ao lado da pasta `config`, que mantém o controle de toda a comunicação entre o ASF e os servidores Steam. Informações de depuração podem ajudar a encontrar comportamentos estranhos na rede e no ASF em geral. Além disso, algumas rotinas gerarão muito mais informações, por exemplo, o `WebBrowser` indicará um motivo específico pela falha nas solicitações- essas informações são gravadas no log usual do ASF. **Você não deve executar o ASF no modo de depuração, a menos que seja solicitado pelo desenvolvedor**. Executar o ASF nesse modo **diminui o desempenho**, **afeta negativamente a estabilidade** e **gera muito mais informações em alguns lugares**, portanto ele deve ser usado **apenas** intencionalmente em um espaço curto de tempo para depurar uma questão particular reproduzindo o problema ou obter mais informações sobre uma falha de solicitação, e assim por diante, mas **não** para execução normal do programa. Você verá **um monte** de erros novos, problemas, e exceções - certifique-se de que você tenha um conhecimento razoável sobre o ASF, o Steam e suas peculiaridades caso você decida analisar tudo isso por conta própria, uma vez que nem tudo é relevante.

**AVISO:** esse modo registra informações **potencialmente confidenciais** como logins e senhas que você usa para acessar o Steam (para se registrar na rede). Os dados são gravados tanto na pasta `depuração` quanto no `log.txt` padrão (que agora contém muito mais detalhes para registrar esta informação). Você não deve postar o conteúdo de depuração gerado pelo ASF em um local público, o desenvolvedor do ASF deverá sempre pedir para que você o envie por e-mail, ou outro local seguro. Não armazenamos nem fazemos uso desses detalhes confidenciais, eles são escritos como parte das rotinas de depuração, já que sua presença pode ser relevante para o problema que está te afetando. Nós preferimos que se você não altere a forma com que o ASF faz os registros, mas se você estiver preocupado você pode editar da forma correta esses detalhes confidenciais.

> Essa edição significa substituir detalhes confidenciais por asteriscos, por exemplo. Você não deve remover inteiramente as linhas confidenciais, já que sua existência pode ser relevante e deve ser preservada.

---

### `DefaultBot`

Tipo `string` com o valor padrão `null`. Em alguns cenários, o ASF opera com um conceito de um bot padrão responsável por lidar com determinadas funções, como comandos de IPC ou console interativo, quando você não especifica o bot de destino. Essa propriedade permite que você escolha o bot padrão responsável por lidar com tais cenários, especificando o nome do bot com `NomeDoBot` aqui. Caso o bot especificado não exista, ou você utilize um valor padrão de `null`, o ASF escolherá o primeiro bot registrado em ordem alfabética. Tipicamente, você utilizará essa propriedade de configuração se deseja omitir o argumento `[Bots]` em comandos de IPC e console interativo, escolhendo sempre o mesmo bot como padrão para essas chamadas.

---

### `FarmingDelay`

Tipo `byte` com o valor padrão `15`. Para que o ASF funcione, é necessário verificar periodicamente num intervalo de minutos informado em `FarmingDelay`, para ver se todas as cartas já foram obtidas. Um valor muito baixo vai fazer com que uma quantidade excessiva de solicitações sejam enviadas para o Steam, enquanto um valor muito alto fará com que o ASF continue rodando o jogo até terminar o tempo do `FarmingDelay`, mesmo que ele já tenha sido totalmente explorado. O valor padrão deve ser excelente para a maioria dos usuários, mas se você tem muitos bots em execução, você pode considerar aumentá-lo para algo em torno de `30` minutos, a fim de limitar a quantidade de pedidos enviados para o Steam. Felizmente o ASF usa um manipulador de eventos e verifica a página de insígnia do jogo sempre que há notificação de item recebido, então em geral **não precisamos verificar isso em intervalos regulares**, mas como não confiamos plenamente na Rede Steam - ainda checamos a página de insígnia do jogo caso não tenhamos verificado através das notificações de recebimento no intervalo de tempo do `FarmingDelay` (para o caso da Rede Steam não nos informar sobre o item recebido ou coisas assim). Assumindo que a Rede Steam esteja funcionando corretamente, diminuir este valor **não vai melhorar a eficiência da coleta**, mas **aumentará significativamente a sobrecarga de rede** - é recomendado aumentá-lo apenas (se necessário) em padrões de `15` minutos. A menos que você tenha uma razão muito **forte** para editar essa propriedade, você deve mantê-la padrão.

---

### `FilterBadBots`

Tipo `bool` com o valor padrão `true`. Esta propriedade define se o ASF rejeitará automaticamente ofertas de troca que são recebidas de agentes de má atividade conhecidos e marcados como tal. Para fazer isso, o ASF se comunicará com nosso servidor conforme a necessidade para obter uma lista de identificadores Steam na lista negra. Os bots listados são operados por pessoas que são classificadas por nós como prejudiciais para a iniciativa do ASF, tais como aqueles que violam nosso **[código de conduta](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/.github/CODE_OF_CONDUCT.md)**, usam as funcionalidades e recursos por nós fornecidos, como a **[`Listagem Pública`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin-pt-BR#publiclisting)** para abusar e explorar outras pessoas. ou estão realizando uma atividade totalmente criminosa, como lançar ataques DDoS no servidor. Uma vez que o ASF tem uma posição forte sobre equidade geral, honestidade e cooperação entre seus usuários, a fim de fazer com que toda a comunidade prospere, esta propriedade é habilitada por padrão e, portanto, o ASF filtra bots que classificamos como prejudiciais a serviços oferecidos. A menos que você tenha uma razão **forte** para editar essa propriedade, tal como discordar da nossa declaração e intencionalmente permitir que esses bots funcionem (incluindo explorar suas contas), você deve mantê-la por padrão.

---

### `GiftsLimiterDelay`

Tipo `byte` com o valor padrão `1`. O ASF vai garantir que haverá um atraso em segundos, definido em `ConfirmationsLimiterDelay`, entre duas solicitações consecutivas de processamento (resgate) de presentes/chaves/licenças para evitar ativar o limitador de tráfego. Além disso, o ASF também será utilizado como limitador global para solicitações de lista de jogos, como aquelas emitidas pelo comando `owns` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-pt-BR)**. A menos que você tenha uma razão muito **forte** para editar essa propriedade, você deve mantê-la padrão.

---

### `Headless`

Tipo `bool` com o valor padrão `false`. Esta propriedade define se o processo deve ser executado em modo não-interativo. Quando em modo headless, o ASF assume que está rodando em um servidor ou em outro ambiente não interativo, portanto ele não tentará ler qualquer informação através da entrada do console. Isto inclui detalhes sob demanda (credenciais de conta como o código 2FA, o código SteamGuard, a senha ou qualquer outra variável necessária para que o ASF opere) bem como todas as outras entradas de console (como o console de comando interativo). Em outras palavras, o modo `Headless` é igual a tornar o console do ASF somente leitura. Essa configuração é útil principalmente para usuários que executam o ASF em servidores, já que em vez de pedir, por exemplo, um código de autenticação, o ASF simplesmente abortará a operação parando a conta em questão. A menos que você esteja executando o ASF em um servidor e tenha confirmado anteriormente que o ASF é capaz de operar em modo não-interativo, você deve manter essa propriedade desabilitada. Qualquer interação do usuário será negada quando o Asf estiver no modo sem interface gráfica (headless), e suas contas não serão executadas se necessitarem de **qualquer** entrada no console durante a inicialização. Ele é útil para servidores, já que o ASF vai abortar ao tentar se conectar a conta quando forem necessárias credenciais, em vez de esperar (infinitamente) para que o usuário os forneça. Habilitar esse modo também permitirá o uso do comando `input` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-pt-BR)**, que atua como um substituto para a entrada padrão do console. Se você não tem certeza de como definir essa propriedade, deixe-a com o valor padrão `false`.

Se você estiver executando o ASF no servidor, provavelmente desejará usar essa opção em conjunto com o **[argumento de linha de comando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments-pt-BR)** `--process-required`.

---

### `IdleFarmingPeriod`

Tipo `byte` com o valor padrão `8`. Quanto o ASF não tem o que coletar, ele vai checar periodicamente a cada hora informada em `FarmingDelay`, para ver se todas as cartas já foram obtidas. Esse recurso não é necessário se tratando de jogos novos, já que neste caso o ASF verifica automaticamente a página de insígnias. O `IdleFarmingPeriod` existe, principalmente, para situações onde jogos antigos que já possuímos passem a ter cartas. Neste caso não há evento algum, por isso o ASF deve verificar periodicamente a página de insígnias para mantermos tudo sob controle. O valor `0` desativa este recurso. Veja também: `ShutdownOnFarmingFinished`.

---

### `InventoryLimiterDelay`

Tipo `byte` com o valor padrão `4`. O ASF vai garantir que haverá um atraso em segundos, definido em `InventoryLimiterDelay`, entre duas solicitações consecutivas ao inventário para evitar ativar o limitador de tráfego; essas solicitações são usadas para obter uma lista dos itens em seu inventário, especialmente durante comandos como `loot` ou `transfer`. O valor padrão de `4` foi definido com base na coleta de inventários de mais de 100 instâncias de bot consecutivas e deve atender à maioria (se não a todos) dos usuários. No entanto você pode querer reduzi-lo, ou até mesmo mudar para `0` se você tiver uma quantidade muito pequena de bots, então o ASF irá ignorar o atraso e listar os inventários Steam muito mais rápido. Porém fique ciente que definir um valor muito baixo **vai** fazer o Steam bloquear temporariamente seu IP, o que vai te impedir de acessar seu inventário. Você talvez precise aumentar esse valor se estiver executando muitos bots com muitos pedidos de acesso ao inventário, embora neste caso você deva provavelmente tentar limitar o número dessas solicitações em vez disso. A menos que você tenha uma razão muito **forte** para editar essa propriedade, você deve mantê-la padrão.

---

### `IPC`

Tipo `bool` com o valor padrão `true`. Esta propriedade define se o servidor **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-pt-BR)** do ASF deve iniciar juntamente com o processo. IPC permite a comunicação entre processos, incluindo o uso de **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-pt-BR#asf-ui)**, inicializando um servidor HTTP local. Se você não pretende usar nenhuma integração de terceiros com o ASF, incluindo nosso ASF-ui, você pode desativar essa opção com segurança. Caso contrário, é uma boa ideia mantê-lo ativado (opção padrão).

---

### `IPCPassword`

Tipo `string` com o valor padrão `null`. Esta propriedade define a senha obrigatória para cada chamada de API feita através do IPC e serve como uma medida de segurança extra. Quando definido como valor não vazio, todas solicitações através do IPC exigirão uma propriedade adicional `password` com o valor definido aqui. O valor padrão `null` elimina necessidade de senha, fazendo com que o ASF processe todas as consultas. Além disso, habilitar essa opção também habilita o mecanismo interno de prevenção de força bruta IPC, que bloqueia temporariamente o `IPAddress` que enviar muitas solicitações não autorizadas em um curto espaço de tempo. A menos que você tenha uma razão para editar essa propriedade, você deve mantê-la padrão.

---

### `IPCPasswordFormat`

Tipo `byte` com o valor padrão `0`. Esta propriedade define o formato da propriedade `IPCPassword` e usa `EHashingMethod` como tipo subjacente. Consulte a seção de **[segurança](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security-pt-BR)** se quiser mais informações, pois você precisará garantir que a propriedade `IPCPassword` de fato inclua uma senha que corresponda a `IPCPasswordFormat`. Em outras palavras, quando você alterar o `IPCPasswordFormat` então seu `IPCPassword` **já** deve estar nesse formato, não apenas esperando ser mudado posteriormente. A menos que você saiba o que está fazendo, você deve mantê-lo com o valor `0` padrão.

---

### `LicenseID`

Tipo `Guid?` com o valor padrão `null`. Essa propriedade permite que nossos **[patrocinadores](https://github.com/sponsors/JustArchi)** melhorem o ASF com recursos opcionais pagos. Por enquanto, isso permite que você use o **[`MatchActively`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#matchactively)** do plugin `ItemsMatcher`.

Apesar de recomendarmos que você utilize o GitHubuma vez que ele oferece tanto opções mensais quanto únicas, bem como permite uma automação completa e acesso imediato nós **também** aceitamos todas as outras **[opções de doação](https://github.com/JustArchiNET/ArchiSteamFarm#archisteamfarm)** atualmente disponíveis. Veja **[esta postagem](https://github.com/JustArchiNET/ArchiSteamFarm/discussions/2780#discussioncomment-4486091)** para instruções de como doar usando outros métodos e conseguir uma licença manual válida por um determinado período.

Independente do método escolhido, se você é um patrocinador do ASF, você pode obter sua licença **[aqui](https://asf.justarchi.net/User/Status)**. Você precisará entrar com o GitHub para confirmar sua identidade, pedimos apenas informações públicas que são somente leitura, que é o seu nome de usuário. `A licença` é composta por 32 caracteres hexadecimais, como `f6a0529813f74d119982eb4fe43a9a24`.

**Certifique-se de não compartilhar sua `LicenseID` com outras pessoas**. Como ela é emitida individualmente ela pode ser revogada se for compartilhada. Se por acaso isto aconteceu com você acidentalmente, você pode gerar uma nova no mesmo lugar.

A menos que você deseje habilitar funções extras do ASF não há necessidade de você indicar essa licença.

---

### `LoginLimiterDelay`

Tipo `byte` com o valor padrão `10`. O ASF vai garantir que haverá um atraso em segundos, definido em `LoginLimiterDelay`, entre duas solicitações consecutivas de conexão para evitar ativar o limitador de tráfego. O valor padrão de `10` foi definido com base na conexão de mais de 100 contas bot, e deve satisfazer a maioria dos usuários (se não todos). No entanto você pode querer reduzir/aumentar o valor, ou até mesmo mudar para `0` se você tiver uma quantidade muito pequena de bots, então o ASF irá ignorar o atraso e conectar com a Steam muito mais rápido. Esteja avisado, porém, que definir um valor muito baixo tendo muitos bots **irá** resultar no Steam banir temporariamente seu IP, e isso irá te impedir de logar **de qualquer jeito**, com o erro `InvalidPassword/RateLimitExceeded` - e isso também inclui seu cliente Steam normal, não apenas o ASF. Da mesma forma, se você estiver rodando um numero excessivo de bots, especialmente junto com outros clientes/ferramentas Steam usando o mesmo endereço IP, provavelmente você precisará aumentar esse valor para espalhar os logins em um período longo de tempo.

Como nota, esse valor também é utilizado como amortecedor de balanceamento de carga em todas as ações regulares do ASF, tais como trocas em `SendTradePeriod`. A menos que você tenha uma razão muito **forte** para editar essa propriedade, você deve mantê-la padrão.

---

### `MaxFarmingTime`

Tipo `byte` com o valor padrão `10`. Como você deve saber, a Steam nem sempre funciona corretamente, às vezes situações estranhas podem acontecer como o Steam não gravar o tempo de jogo apesar de estarmos jogando. O ASF permitirá a coleta um único jogo no modo solo pelo tempo máximo, em horas, determinado em `MaxFarmingTime`, e vai considerá-lo totalmente explorado após esse período. Isso é necessário para que o processo de coleta não congele em caso de situações estranhas, mas também, se por algum motivo a Steam lançar uma nova insignia que poderia parar o progresso do ASF (veja: `Blacklist`). O valor padrão de `10` horas deve ser suficiente para adquirir todas as cartas Steam de um jogo. Definir um valor muito baixo para essa propriedade pode resultar em jogos válidos sendo ignorados (e sim, há jogos válidos que levam até 9 horas para coleta), enquanto definir um valor muito alto pode resultar no congelamento do processo de coleta. Por favor, note que esta propriedade afeta somente um único jogo em uma sessão de coleta simples (por isso, após passar por toda a fila, o ASF retornará a esse título), ela também não é baseada no total de tempo jogado, mas no tempo de coleta interno do ASF, portanto o ASF também retornará à esse título após ser reiniciado. A menos que você tenha uma razão muito **forte** para editar essa propriedade, você deve mantê-la padrão.

---

### `MaxTradeHoldDuration`

Tipo `byte` com o valor padrão `15`. Essa propriedade define a duração máxima de retenção de trocas, em dias, que você está disposto a aceitar - o ASF vai rejeitar trocas que fiquem retidas por mais tempo que o valor de `MaxTradeHoldDuration`, como definido na seção de **[trocas](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading-pt-BR)**. Esta opção só faz sentido para bots com `TradingPreferences` do `SteamTradeMatcher`, já que isso não afeta as trocas entre `Master`/`SteamOwnerID`, nem doações. Trocas retidas são irritantes para todos, e ninguém quer lidar com elas. É suposto que o ASF funcione com regras liberais e ajude a todos, independentemente de trocas retidas ou não - é por isso que essa opção é definida como `15` por padrão. No entanto, se você preferir rejeitar todas as transações afetadas pela retenção de trocas, você pode definir `0` aqui. Por favor, considere o fato de que cartas com vida curta não são afetadas por essa opção e são automaticamente rejeitadas para pessoas com retenção de trocas, conforme descrito na seção **[trocas](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading-pt-BR)**, então não há nenhuma necessidade de rejeitar globalmente todo mundo só por causa disso. A menos que você tenha uma razão para editar essa propriedade, você deve mantê-la padrão.


---

### `MinFarmingDelayAfterBlock`

Tipo `byte` com o valor padrão `60`. Esta propriedade define a quantidade mínima de tempo, em segundos, que o ASF esperará antes de retomar a coleta de cartas caso tenha sido desconectado anteriormente com `LoggedInElsewhere`, o que acontece quando você decide desconectar o ASF ao iniciar um jogo. Este atraso existe principalmente por razões de conveniência e de excesso de desempenho, por exemplo, ele permite que você reinicie o jogo sem precisar lutar contra o ASF que estará ocupando sua conta novamente porque o bloqueio de jogo estava disponível por um segundo. Devido ao fato de que recuperar a sessão causa uma desconecção `LoggedInElsewhere`, o ASF tem que passar por todo o procedimento de reconexão, o que coloca uma pressão adicional na sua máquina e na Rede Steam, portanto evitar desconexões adicionais, se possível, é preferível. Por padrão, essa configuração é de `60` segundos, o que deve ser suficiente para permitir que você reinicie o jogo sem muita complicação. No entanto, há cenários em que você pode estar interessado em aumentar esse tempo, por exemplo, se a sua rede desconectar com frequência e o ASF tomar a conta muito cedo, o que faz com que seja obrigado a passar pelo processo de reconexão. Nós permitimos um valor máximo de `255` para essa propriedade, que deve ser suficiente para todos os cenários comuns. Além do mencionado acima, também é possível diminuir o atraso, ou até mesmo removê-lo inteiramente usando o valor `0`, embora isso não seja recomendado por razões acima mencionadas. A menos que você tenha uma razão para editar essa propriedade, você deve mantê-la padrão.

---

### `OptimizationMode`

Tipo `byte` com o valor padrão `0`. Esta propriedade define o modo de otimização que o ASF dará preferência durante o tempo de execução. Atualmente, o ASF suporta dois modos - `0`, que é chamado de `MaxPerformance` e `1`, que é chamado `MinMemoryUsage`. Por padrão, o ASF prefere executar tantas coisas em paralelo (simultaneamente) quanto possível, melhorando o desempenho pelo balanceamento de carga de trabalho entre todos os núcleos de CPU, vários threads de CPU, soquetes múltiplos e várias tarefas de pool de threads. Por exemplo, o ASF pedirá por sua primeira página de insígnias quando procurar jogos para coletar, e então uma vez que o pedido chegar, o ASF lerá quantas páginas de insígnias você tem, e em seguida, solicitará todas as outras simultaneamente. Isto é o que você deve querer **quase sempre**, já que a sobrecarga, na maioria dos casos, é mínima e os benefícios do código assíncrono do ASF pode ser visto até mesmo em hardwares mais antigos com um único núcleo de CPU e potência fortemente limitada. No entanto, com muitas tarefas sendo processadas em paralelo, o tempo de execução do ASF é responsável pela manutenção, p. ex., mantendo soquetes abertos, threads ativos e tarefas sendo processadas, que pode resultar no aumento do uso de memória de vez em quando, e se você é extremamente limitado pela memória disponível, você pode querer mudar esta propriedade para `1` (`MinMemoryUsage`) a fim de forçar o ASF a usar o mínimo de tarefas possível e normalmente executar possíveis códigos assíncronos paralelos de forma síncrona. Você deve considerar mudanças nessa propriedade apenas se você leu a seção **[configuração para baixo consumo de memória](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup-pt-BR)** e quer sacrificar intencionalmente um aumento enorme de desempenho por uma diminuição de sobrecarga de memória muito pequena. Normalmente, esta opção é **muito pior** do que o que se pode conseguir com outras possibilidades, tais como limitar o uso do ASF ou ajustar o coletor de lixo do tempo de execução, conforme explicado na **[configuração de pouca memória](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup)**. Portanto, você deve usar `MinMemoryUsage` como **último recurso**, direitamente antes de recompilação do tempo de execução, caso você não tenha conseguido atingir resultados satisfatórios com outras opções (muito melhores). A menos que você tenha uma razão muito **forte** para editar essa propriedade, você deve mantê-la padrão.

---

### `SteamMessagePrefix`

Tipo `string` com o valor padrão `"/me"`. Esta propriedade define um prefixo que será anexado a todas as mensagens da Steam sendo enviadas pelo ASF. Por padrão o ASF usa o prefixo `"/ me"` para distinguir as mensagens do bot mais facilmente, mostrando-os em cores diferentes no chat da Steam. Outro prefixo digno de menção é `"/ pre"` que alcança resultados semelhantes, mas usa uma formatação diferente. Você também pode definir essa propriedade como vazia ou `null` para desativar inteiramente o uso do prefixo e deixar todas as mensagens do ASF de forma tradicional. É bom notar que esta propriedade afeta apenas mensagens da Steam - as respostas retornadas através de outros canais (como IPC) não são afetadas. A menos que você deseja personalizar o comportamento padrão do ASF, é uma boa ideia deixá-lo assim.

---

### `SteamOwnerID`

Tipo `ulong` com o valor padrão `0`. Esta propriedade define o ID Steam em formato de 64-bit do proprietário do processo ASF, e é muito semelhante a permissão `Master` de determinada conta bot (mas global mas em vez disso). Você vai querer definir quase sempre essa propriedade com o ID da sua própria conta principal do Steam. A permissão `Master` inclui controle total sobre sua conta bot, mas comandos globais como `exit`, `restart` ou `update` são reservados apenas para o `SteamOwnerID`. Isto é conveniente caso você queria executar bots para seus amigos, mas não permitir que eles tenham controle do processo do ASF, como sair dele através do comando `exit`, por exemplo. O valor padrão de `0` especifica que não há proprietário do processo do ASF, o que significa que ninguém será capaz de emitir comandos globais do ASF. Tenha em mente que esta propriedade se aplica exclusivamente ao chat Steam. O **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-pt-BR)** e o console interativo ainda permitirão que você execute comandos de `Proprietário` mesmo se esta propriedade não estiver definida.

---

### `SteamProtocols`

Tipo `byte flags` com o valor padrão `7`. Esta propriedade define os protocolos Steam que o ASF irá usar ao se conectar aos servidores Steam, que são definidos como abaixo:

| Valor | Nome      | Descrição                                                                                                    |
| ----- | --------- | ------------------------------------------------------------------------------------------------------------ |
| 0     | None      | Sem protocolo                                                                                                |
| 1     | TCP       | **[Transmission Control Protocol](https://pt.wikipedia.org/wiki/Protocolo_de_controle_de_transmiss%C3%A3o)** |
| 2     | UDP       | **[User Datagram Protocol](https://pt.wikipedia.org/wiki/Protocolo_de_datagrama_do_usu%C3%A1rio)**           |
| 4     | WebSocket | **[WebSocket](https://pt.wikipedia.org/wiki/WebSocket)**                                                     |

Por favor note que esta propriedade é um campo do tipo `flags`, portanto é possível escolher qualquer combinação de valores disponíveis. Check out **[json mapping](#json-mapping)** if you'd like to learn more. Não habilitar nenhum flag resulta na opção `None`, e essa opção é inválida, por si só.

Por padrão o ASF vai usar todos os protocolos Steam disponíveis como medida para lutar contra tempos de inatividade e outras questões semelhantes do Steam. Normalmente, você vai querer alterar esta propriedade se quiser limitar o ASF a usar apenas um ou dois protocolos específicos. Tal medida poderia ser necessário se você está habilitando, por exemplo, apenas tráfego TCP em seu firewall e você não quer que o ASF tente conectar via UDP. No entanto, a menos que você está depurando determinado problema ou questão, você quase sempre vai desejar garantir que o ASF esteja livre para usar qualquer protocolo que é atualmente suportado e não apenas um ou dois. A menos que você tenha uma razão muito **forte** para editar essa propriedade, você deve mantê-la padrão.

---

### `UpdateChannel`

Tipo `byte` com o valor padrão `1`. Essa propriedade define o canal de atualização que está sendo usado, tanto para atualizações automáticas (se `UpdatePeriod` for maior que `0`), ou (caso contrário) para atualizar notificações. Atualmente, o ASF suporta três canais de atualização - `0`, que é chamado de `Nenhum`, `1`, que é chamado de `Estável` e `2`, que é chamado de `Experimental`. O canal `Estável` é o canal de lançamento padrão, que deve ser usado pela maioria dos usuários. O canal `Experimental`, além das versões `Stable`, também inclui versões de **pré-lançamento** dedicado a usuários avançados e outros desenvolvedores para teste de novas funcionalidades, confirmação de correções de bugs ou dar feedback sobre melhorias planejadas. **Versões experimentais frequentemente contém erros sem correção, trabalhos em andamento ou implementações reescritas**. Se você não se considera um usuário avançado, por favor, mantenha o canal de atualização padrão `1` (`Estável`). O canal `Experimental` dedica-se aos usuários que sabem como relatar bugs, lidar com questões e dar feedback - nenhum suporte técnico será dado. Confira o **[ciclo de lançamento](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Release-cycle-pt-BR)** do ASF se você quiser aprender mais. Você também pode definir `UpdateChannel` como `0` (`Nenhum`), se você quiser remover completamente todas as verificações de versão. Definir `UpdateChannel` como `0` desativará inteiramente toda funcionalidade relacionada às atualizações, incluindo o comando `update`. Usando o canal `Nenhum` é **fortemente desencorajado** devido ao fato de te expor a todo tipo de problemas (mencionados na descrição de `UpdatePeriod` abaixo).

**A não ser que você saiba o que está fazendo**, nós recomendamos **fortemente** que você mantenha o valor padrão.

---

### `UpdatePeriod`

Tipo `byte` com o valor padrão `24`. Esta propriedade define quantas vezes o ASF deve buscar por atualizações automáticas. As atualizações são cruciais não só para receber novos recursos e correções de segurança críticas, mas também para receber correções de bugs, melhorias de desempenho, melhorias de estabilidade e muito mais. Quando um valor maior que `0` é definido, o ASF irá automaticamente baixar, substituir e se reiniciar (se a configuração `AutoRestart` permitir) quando uma nova atualização estiver disponível. Para isso, o ASF verificará a cada intervalo de horas indicado em `UpdatePeriod` se uma nova atualização está disponível no nosso repositório GitHub. Um valor de `0` desativa atualizações automáticas, mas ainda permite que você execute o comando `update` manualmente. Você também pode estar interessado em configurar adequadamente o `UpdateChannel` que o `UpdatePeriod` deve seguir.

O processo de atualização do ASF envolve atualização da estrutura inteira da pasta que o ASF está usando, mas sem mexer em suas configurações ou bancos de dados localizados na pasta `config` - isso significa que qualquer arquivos extras não relacionados com o ASF em sua pasta podem ser perdidos durante a atualização. O valor padrão de `24` é um bom equilíbrio entre verificações desnecessárias e uma versão do ASF suficientemente atual.

A menos que você tenha um motivo muito **forte** para desabilitar esse recurso, você deve manter as atualizações automáticas habilitadas dentro de um período de tempo razoável definido em `UpdatePeriod` **para o seu próprio bem**. Não só porque não damos suporte a outra versão do ASF senão a última estável, mas também porque **nós damos a nossa garantia de segurança somente para a versão mais recente**. Se você estiver usando uma versão desatualizada do ASF então está intencionalmente se expondo a todo o tipo de problemas, desde pequenos bugs, funcionalidades quebradas, até possíveis **[suspensões permanentes de conta Steam](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ-pt-BR#alguém-já-foi-banido-por-isso)**, então nós **recomendamos fortemente**, para seu próprio bem, que você se certifique sempre de que a sua versão do ASF esteja atualizada. Atualizações automáticas nos permitem reagir rapidamente a todo o tipo de questões, desativando ou remendando códigos problemáticos antes que ele possa se agravar - se você optar por ficar fora disso, você perde todas nossas garantias de segurança e corre o risco das consequências de executar um código que pode ser potencialmente prejudicial, não somente a rede Steam, mas também (por definição) para sua própria conta Steam.

---

### `WebLimiterDelay`

Tipo `ushort` com o valor padrão `300`. Esta propriedade define, em milissegundos, a quantidade mínima de atraso entre o envio de dois pedidos consecutivos para o mesmo serviço web do Steam. Tal atraso é necessário pois o serviço **[AkamaiGhost](https://www.akamai.com)**, que a Steam usa internamente, inclui um limitador com base no número global de solicitações enviadas em dado período de tempo. Em circunstâncias normais o bloqueio da akamai é um pouco difícil de atingir, mas sob cargas de trabalho muito pesadas com uma enorme fila de pedidos em andamento, é possível acioná-lo, se continuarmos enviando muitas solicitações por um período muito curto de tempo.

O valor padrão foi definido com base no pressuposto de que o ASF é a única ferramenta acessando os serviços web do Steam, em particular `steamcommunity.com`, `api.steampowered.com` e `store.steampowered.com`. Se você estiver usando outras ferramentas que também enviem solicitações para os mesmos serviços web então certifique-se de que sua ferramenta inclui alguma funcionalidade semelhante ao `WebLimiterDelay` e defina ambos com o dobro do valor padrão, ou seja `600`. Isso garante que, sob nenhuma circunstância, você vai exceder o envio de mais de 1 pedido a cada `300` ms.

Em geral, reduzir o `WebLimiterDelay` para um valor abaixo do padrão é **fortemente desencorajado**, pois poderia levar a vários bloqueios relacionados ao IP, alguns passíveis de serem permanentes. O valor padrão é bom o suficiente para rodar uma instância única do ASF no servidor, bem como usar o ASF em um cenário normal juntamente com o cliente Steam original. Isso deve ser correto para a maioria dos usos, e você só deve aumentá-lo (nunca diminuí-lo). Em suma, o número global de todas as solicitações enviadas a partir de um único IP para um único domínio da Steam nunca deve exceder mais de 1 pedido a cada `300` ms.

A menos que você tenha uma razão para editar essa propriedade, você deve mantê-la padrão.

---

### `WebProxy`

Tipo `string` com o valor padrão `null`. Esta propriedade define um endereço proxy da web que será usado para todas as solicitações internas, http e https, enviadas pelo `HttpClient` do ASF, especialmente para serviços como `github.com`, `steamcommunity.com` e `store.steampowered.com`. Solicitações de proxy para o ASF em geral não tem vantagens, mas é extremamente útil para contornar vários tipos de firewalls, especialmente o grande firewall da China.

Essa propriedade é definida como uma sequência de caracteres uri:

> Uma string URI é composta por um esquema (suportado: http/https/socks4/socks4a/socks5), um host e uma porta opcional. Um exemplo de uri completa é `http://www.contoso.com:8080`.

Se seu proxy requer autenticação de usuário, você também precisará configurar `WebProxyUsername` e/ou `WebProxyPassword`. Se não há tal necessidade, configurar apenas esta propriedade é suficiente.

No momento o ASF usa o web proxy somente para solicitações `http` e `https`, que **não** incluem comunicação de rede interna da Steam feita dentro cliente Steam interno do ASF. Atualmente não existem planos para oferecer suporte a isso, principalmente devido à falta de funcionalidade do **[SK2](https://github.com/SteamRE/SteamKit/issues/587#issuecomment-413271550)**. Se você precisa/quer que isso aconteça, eu sugiro que comece por lá.

A menos que você tenha uma razão para editar essa propriedade, você deve mantê-la padrão.

---

### `WebProxyPassword`

Tipo `string` com o valor padrão `null`. Esta propriedade define a senha usada em autenticações basic, digest, NTLM e Kerberos que sejam suportadas pela máquina de `WebProxy` alvo, fornecendo a funcionalidade proxy. Se o seu proxy não requer credenciais de usuário, não há nenhuma necessidade de você colocar qualquer coisa. Usar esta opção só faz sentido se `WebProxy` também for definido, já que ela não tem efeito caso contrário.

A menos que você tenha uma razão para editar essa propriedade, você deve mantê-la padrão.

---

### `WebProxyUsername`

Tipo `string` com o valor padrão `null`. Esta propriedade define o usuário usado em autenticações basic, digest, NTLM e Kerberos que sejam suportadas pela máquina de `WebProxy` alvo, fornecendo a funcionalidade proxy. Se o seu proxy não requer credenciais de usuário, não há nenhuma necessidade de você colocar qualquer coisa. Usar esta opção só faz sentido se `WebProxy` também for definido, já que ela não tem efeito caso contrário.

A menos que você tenha uma razão para editar essa propriedade, você deve mantê-la padrão.

---

## Configuração do Bot

Como você já deve saber, cada bot deve ter sua própria configuração baseada no exemplo de estrutura JSON abaixo. Comece decidindo como você deseja nomear seu bot (por exemplo: `1.json`, `main.json`, `primary.json` ou `QualquerCoisa.json`) e vá para configuração.

**Observação:** O bot não pode ser nomeado como `ASF` (esse nome é reservado para configuração global), o ASF também vai ignorar qualquer arquivo de configuração cujo nome comece com um ponto.

A configuração do bot tem a seguinte estrutura:

```json
{
    "AcceptGifts": false,
    "AutoSteamSaleEvent": false,
    "BotBehaviour": 0,
    "CompleteTypesToSend": [],
    "CustomGamePlayedWhileFarming": null,
    "CustomGamePlayedWhileIdle": null,
    "Enabled": false,
    "EnableRiskyCardsDiscovery": false,
    "FarmingOrders": [],
    "FarmPriorityQueueOnly": false,
    "GamesPlayedWhileIdle": [],
    "HoursUntilCardDrops": 3,
    "LootableTypes": [1, 3, 5],
    "MatchableTypes": [5],
    "OnlineFlags": 0,
    "OnlineStatus": 1,
    "PasswordFormat": 0,
    "Paused": false,
    "RedeemingPreferences": 0,
    "RemoteCommunication": 3,
    "SendOnFarmingFinished": false,
    "SendTradePeriod": 0,
    "ShutdownOnFarmingFinished": false,
    "SkipRefundableGames": false,
    "SteamLogin": null,
    "SteamMasterClanID": 0,
    "SteamParentalCode": null,
    "SteamPassword": null,
    "SteamTradeToken": null,
    "SteamUserPermissions": {},
    "TradeCheckPeriod": 60,
    "TradingPreferences": 0,
    "TransferableTypes": [1, 3, 5],
    "UseLoginKeys": true,
    "UserInterfaceMode": 0
}
```

---

Todas as opções são explicadas abaixo:

### `AcceptGifts`

Tipo `bool` com o valor padrão `false`. Quando habilitado, o ASF vai aceitar e resgatar automaticamente todos os presentes Steam (incluindo vales-presente da carteira) enviados para o bot. Isso também inclui presentes enviadas de usuários que não estejam os definidos em `SteamUserPermissions`. Tenha em mente que presentes enviados para o endereço de e-mail não são encaminhados diretamente para o cliente, então o ASF não aceitará esses sem a sua ajuda.

Esta opção é recomendada apenas para contas alternativas, já que é muito provável que você não queira resgatar automaticamente todos os presentes enviados para sua conta principal. Se você não tiver certeza se quer esse recurso habilitado ou não, mantenha-o com o valor `false` padrão.

---

### `AutoSteamSaleEvent`

Tipo `bool` com o valor padrão `false`. Durante as promoções de verão/Inverno é comum que o Steam conceda cartas extras pela exploração diária da lista de descobrimento, bem como por outras atividades específicas do evento. Quando esta opção é habilitada, o ASF verifica automaticamente a lista de descobrimento a cada `8` horas (iniciando uma hora após o programa ser aberto) e executa essa tarefa, se necessário. Esta opção não é recomendada se você quer ver sua lista de descobrimento manualmente, e normalmente ela deve fazer sentido apenas nas contas bot. Além disso, você precisa garantir que sua conta tenha pelo menos nível `8` se você espera receber essas cartas, o que é um requerimento do Steam. Se você não tiver certeza se quer esse recurso habilitado ou não, mantenha-o com o valor `false` padrão.

Por favor, note que devido a constantes problemas e mudanças no Steam, **nós não damos nenhuma garantia de que esta função vai funcionar corretamente**, portanto, é inteiramente possível que ela **não funcione de modo algum**. Não aceitamos **nenhum** relatório de bugs, nem pedidos de suporte para essa opção. Ela é oferecida com absolutamente nenhuma garantia, você estará usando por seu próprio risco.

---

### `BotBehaviour`

Tipo `byte flags` com o valor padrão `0`. Esta propriedade define o comportamento do bot do ASF durante vários eventos e é definida conforme indicado abaixo:

| Valor | Nome                          | Descrição                                                                                                                     |
| ----- | ----------------------------- | ----------------------------------------------------------------------------------------------------------------------------- |
| 0     | None                          | Nenhum comportamento especial do bot, o modo menos invasivo, padrão                                                           |
| 1     | RejectInvalidFriendInvites    | Fará com que o ASF rejeite (ao invés de ignorar) convites de amizade inválidos                                                |
| 2     | RejectInvalidTrades           | Fará com que o ASF rejeite (ao invés de ignorar) ofertas de troca inválidas                                                   |
| 4     | RejectInvalidGroupInvites     | Fará com que o ASF rejeite (ao invés de ignorar) convites inválidos para grupos                                               |
| 8     | DismissInventoryNotifications | Fará com que o ASF dispense automaticamente todas as notificações de inventário                                               |
| 16    | MarkReceivedMessagesAsRead    | Fará com que o ASF marque automaticamente todas as mensagens recebidas como lidas                                             |
| 32    | MarkBotMessagesAsRead         | Fará com que o ASF marque automaticamente todas as mensagens dos outros bots (ativos na mesma instância) recebidas como lidas |

Por favor note que esta propriedade é um campo do tipo `flags`, portanto é possível escolher qualquer combinação de valores disponíveis. Check out **[json mapping](#json-mapping)** if you'd like to learn more. Não habilitar nem um flag resultará na opção `None`.

Em geral você vai desejar modificar esta propriedade se você espera que o ASF faça certa quantidade de automação relacionados à sua atividade, como seria de esperar de uma conta bot, mas não uma conta primária usada no ASF. Portanto, alterar esta propriedade faz sentido principalmente para contas alternativas, embora você seja livre para usar as opções selecionadas para contas principais também.

Normal (`None`) ASF behaviour is to only automate things that user wants (e.g. cards farming or `SteamTradeMatcher` offers processing, if set in `TradingPreferences`). Este é o modo menos invasivo, e é benéfico para a maioria dos usuários já que você permanece com controle completo sobre sua conta e pode decidir se deseja permitir certas interações fora do escopo ou não.

Convite de amizade inválido é um convite que não vem de um usuário com permissão `FamilySharing` ou superior (definida na opção `SteamUserPermissions`). No modo normal o ASF ignora esses convites, como seria de esperar, dando-lhe liberdade de escolha se deseja aceitá-los ou não. `RejectInvalidFriendInvites` fará com que esses convites sejam rejeitados automaticamente, que praticamente impedirá que outra pessoas te adicionem a lista de amigos delas (uma vez que o ASF negará todos os pedidos, exceto das pessoas definidas em ` SteamUserPermissions`). A menos que você queira negar completamente todos os convites de amizade, você não deve habilitar esta opção.

Oferta de troca inválida é uma oferta que não é aceita pelo módulo interno do ASF. Mais sobre este assunto pode ser encontrado na seção **[trocas](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading-pt-BR)**, que define todos os tipos de trocas que o ASF está disposto a aceitar automaticamente. Trocas válidas também são definidas por outras configurações, especialmente `TradingPreferences`. `RejectInvalidTrades` fará com que todas as ofertas de trocas inválidas sejam rejeitadas, em vez de serem ignoradas. A menos que você queira negar completamente todas as ofertas de troca que não são automaticamente aceitas pelo ASF, você não deve habilitar esta opção.

Convite inválidos para grupos são convites que não vem do grupo definido em `SteamMasterClanID`. No modo normal o ASF ignora esses convites, como seria de esperar, dando-lhe liberdade de escolha se deseja entrar em determinado Grupo Steam ou não. `RejectInvalidGroupInvites` fará com que todos os convites para grupos sejam rejeitados automaticamente, tornando impossível convidá-lo para qualquer outro grupo que não seja o `SteamMasterClanID`. A menos que você queira negar completamente todos os convites de grupo, você não deve habilitar esta opção.

`DismissInventoryNotifications` é extremamente útil quando você estiver ficando irritado com a quantidade de notificações de novos items pelo Steam. O ASF não pode se livrar da notificação em si pois ela é embutida no seu cliente Steam, mas ele pode limpar a notificação após recebê-la, o que vai apagar a mensagem "novos itens no inventário". Se você preferir avaliar manualmente todos os itens recebidos (principalmente as cartas coletadas pelo ASF) então você deve desabilitar essa opção. Quando você começar a enlouquecer, lembre-se dessa opção.

`MarkReceivedMessagesAsRead` vai marcar automaticamente **todas** as mensagens recebidas pela conta em que o ASF está sendo executado, tanto as privadas quanto em grupo. Essa opção deve ser usada normalmente em contas alternativas para limpar as notificações de "nova mensagem" provenientes, por exemplo, de comandos do ASF. Não recomendamos ativar essa opção em contas principais, a menos que você queira desativar qualquer tipo de notificações de novas mensagens, **incluindo** aquelas que chegaram quando você estava off-line, assumindo que o ASF estivesse aberto durante esse período.

`MarkBotMessagesAsRead` funciona de forma semelhante marcando apenas as mensagens do(s) bot(s) como lidas. No entanto, tenha em mente que ao usar essa opção em chats em grupo com seus bots e outras pessoas, a implementação do Steam que reconhece as mensagens de chat **também** reconhece todas as mensagens **anteriores** a que você decidiu marcar, então se você não quiser perder uma mensagem não relacionada que foi recebida entre as marcadas, você vai preferir não usar essa funcionalidade. Obviamente, também é arriscado quando você tem várias contas primárias (por exemplo, de usuários diferentes) executando na mesma instância do ASF, já que você também pode perder as mensagens normais fora do ASF.

Se você está inseguro de como configurar esta opção, é melhor deixá-la padrão.

---

### `CompleteTypesToSend`

Tipo `ImmutableHashSet<byte>` com o valor padrão vazio. Quando o ASF completar o set do tipo de item especificado aqui ele pode enviar uma proposta de troca com todos os sets para o usuário com permissão `Master`, o que é conveniente se você quiser usar uma determinada conta bot para, por exemplo, fazer trocas no STM, enquanto transfere os sets completos para outra conta. Esta opção funciona da mesma forma que o comando `loot`, portanto, tenha em mente que ele requer um usuário com o conjunto de permissões `Master`, você também pode precisar de um `SteamTradeToken` válido, tanto quanto o uso de uma conta que seja, em primeiro lugar, elegível para trocas.

O seguintes tipos de itens são suportados nesta configuração:

| Valor | Nome            | Descrição                                                                         |
| ----- | --------------- | --------------------------------------------------------------------------------- |
| 3     | FoilTradingCard | Versão brilhante da `Carta Colecionável`                                          |
| 5     | TradingCard     | Cartas colecionáveis Steam, sendo usadas para fabricar insígnias (não brilhantes) |

Please note that regardless of the settings above, ASF will only ask for **[Steam community items](https://steamcommunity.com/my/inventory/#753_6)** (`appID` of 753, `contextID` of 6), so all game items, gifts and likewise, are excluded from the trade offer by definition.

Devido a sobrecarga adicional causada por essa opção, recomendamos usá-la apenas em contas bot que tenhoam alguma chance real de terminar os sets por conta própria - por exemplo, não faz sentido ativar essa opção caso você use os comandos `SendOnFarmingFinished`, `SendTradePeriod` ou `loot` de forma regular.

Se você está inseguro de como configurar esta opção, é melhor deixá-la padrão.

---

### `CustomGamePlayedWhileFarming`

Tipo `string` com o valor padrão `null`. Quando ASF está em processo de coleta, ele pode se mostrar como "Jogando jogo não Steam: `CustomGamePlayedWhileFarming`" ao invés do jogo que realmente esteja sendo executado. Isso é útil para o caso de você querer que seus amigos saibam que você está coletando, mas você não usar a opção `Off-line` em `OnlineStatus`. Por favor, note que o ASF não pode garantir a ordem de exibição atual da rede Steam, portanto isso é apenas uma sugestão que pode, ou não, ser exibida corretamente. Em particular, o nome personalizado não será exibido no algorítimo de coleta `Complex` se o ASF preencher todos os `32` slots com jogos que requerem horas para coleta. O valor `null` padrão desativa este recurso.

O ASF fornece algumas variáveis especiais que você pode usar em seu texto. O ASF vai substituir o `{0}` pelo `AppID` do(s) jogo(s) atualmente em andamento(s), enquanto `{1}` será substituído pelo ASF por `GameName` do(s) jogo(s) atualmente em execução.

---

### `CustomGamePlayedWhileIdle`

Tipo `string` com o valor padrão `null`. Similar a `CustomGamePlayedWhileFarming`, mas para a situação onde o ASF não tem nada para fazer (com todas as coletas da conta feitas). Por favor, note que o ASF não pode garantir a ordem de exibição atual da rede Steam, portanto isso é apenas uma sugestão que pode, ou não, ser exibida corretamente. Se você estiver usando `GamesPlayedWhileIdle` junto com esta opção, tenha em mente que `GamesPlayedWhileIdle` tem prioridade, pois você não pode declarar mais do que `31` jogos, já que `CustomGamePlayedWhiledle` não será capaz de ocupar o slot com o nome personalizado. O valor `null` padrão desativa este recurso.

---

### `Enabled`

Tipo `bool` com o valor padrão `false`. Essa propriedade define se o bot está habilitado. Uma conta bot habilitada (`true`) vai ser iniciada automaticamente quado o ASF for iniciado, enquanto uma conta bot desabilitada (`false`) terá que ser iniciada manualmente. Por padrão, todo bot é desabilitado, então provavelmente você vai querer mudar essa propriedade para `true` para todos os bots que devem ser iniciados automaticamente.

---

### `EnableRiskyCardsDiscovery`

Tipo `bool` com o valor padrão `false`. Essa propriedade habilita uma alternativa adicional que entra em ação quando o ASF não consegue carregar uma ou mais páginas de insignias e, portanto, não consegue encontrar jogos disponíveis para coleta. Em particular, algumas contas com uma grande quantidade de drops de cartas podem causar uma situação em que o carregamento das páginas de insignias não seja mais possível (devido à sobrecarga), e essas contas se tornam impossíveis de serem coletadas simplesmente porque não conseguimos carregar as informações com base nas quais podemos iniciar o processo. For those handful cases, this option allows alternative algorithm to be used, which uses a combination of boosters possible to craft and booster packs the account is eligible for, in order to find potentially available games to idle, then spends excessive amount of resources for verifying and fetching required information, and attempts to start the process of farming on limited amount of data and information in order to eventually reach a situation when badge page loads and we'll be able to use normal approach. Por favor, observe que ao usar esse recurso alternativo, o ASF opera apenas com dados limitados, portanto, é completamente normal que o ASF encontre muito menos drops do que na realidade - outros drops serão encontrados em uma etapa posterior do processo de coleta.

Essa opção é chamada de "arriscada" por uma boa razão - ela é extremamente lenta e requer uma quantidade significativa de recursos (incluindo solicitações de rede) para funcionar, portanto, **não é recomendado** ativá-la, especialmente a longo prazo. Você deve usar essa opção apenas se você determinou previamente que sua conta está enfrentando problemas para carregar as páginas de insignias e o ASF não pode operar nela, sempre falhando ao carregar as informações necessárias para iniciar o processo. Mesmo que tenhamos feito o nosso melhor para otimizar o processo o máximo possível, ainda é possível que essa opção tenha resultados indesejados e possa resultar em suspensões temporárias, e talvez até permanentes, por parte do Steam, devido ao envio de um grande volume de solicitações e à sobrecarga causada nos servidores do Steam. Portanto, alertamos você com antecedência e oferecemos essa opção sem absolutamente nenhuma garantia. Você a está utilizando por sua conta e risco.

A menos que você saiba o que está fazendo, você deve mantê-la com o valor `false` padrão.

---

### `FarmingOrders`

Tipo `ImmutableList<byte>` com o valor padrão vazio. Essa propriedade define a ordem de coleta **preferida** usada pelo ASF para a conta do bot específica. Atualmente existem as seguintes ordens disponíveis:

| Valor | Nome                      | Descrição                                                                                                |
| ----- | ------------------------- | -------------------------------------------------------------------------------------------------------- |
| 0     | Unordered                 | Sem ordem, aumentando levemente a porformance da CPU                                                     |
| 1     | AppIDsAscending           | Tenta coletar dos jogos com os `appIDs` em ordem crescente                                               |
| 2     | AppIDsDescending          | Tenta coletar dos jogos com o `appIDs` em ordem decrescente                                              |
| 3     | CardDropsAscending        | Tenta coletar dos jogos com o menor número de cartas disponíveis primeiro                                |
| 4     | CardDropsDescending       | Tenta coletar dos jogos com o maior número de cartas disponíveis primeiro                                |
| 5     | HoursAscending            | Tenta coletar dos jogos com o menor número de horas jogadas primeiro                                     |
| 6     | HoursDescending           | Tenta coletar dos jogos com o maior número de horas jogadas primeiro                                     |
| 7     | NamesAscending            | Tenta coletar dos jogos em ordem alfabética, começando do A                                              |
| 8     | NamesDescending           | Tenta coletar dos jogos em ordem alfabética reversa, começando do Z                                      |
| 9     | Random                    | Tenta coletar dos jogos em ordem completamente aleatória (diferente cada vez que o programa é executado) |
| 10    | BadgeLevelsAscending      | Tenta coletar dos jogos com o nível de insígnia mais baixo primeiro                                      |
| 11    | BadgeLevelsDescending     | Tenta coletar dos jogos com o nível de insígnia mais alto primeiro                                       |
| 12    | RedeemDateTimesAscending  | Tenta coletar dos jogos mais antigos em sua conta primeiro                                               |
| 13    | RedeemDateTimesDescending | Tenta coletar dos jogos mais novos em sua conta primeiro                                                 |
| 14    | MarketableAscending       | Tenta coletar dos jogos com cartas não comercializáveis primeiro                                         |
| 15    | MarketableDescending      | Tenta coletar dos jogos com cartas comercializáveis primeiro                                             |

Como essa essa propriedade é uma matriz, ela permite que você use várias configurações diferentes em sua ordem fixa. Por exemplo, você pode incluir os valores `15`, `11` e `7` a fim de classificar primeiro por jogos comercializáveis, em seguida, por aqueles com a insígnia de nível mais alto e, finalmente, em ordem alfabética. Como você pode imaginar, a ordem realmente importa, já que a reversa (`7`, `11` e `15`) faz algo completamente diferente (classifica jogos em ordem alfabética primeiro, e devido aos nomes dos jogos serem únicos, as outras duas são efetivamente inúteis). A maioria das pessoas provavelmente usará apenas uma dessas ordens, mas caso você queira, você pode também classificar por parâmetros extras.

Note também a palavra "tentar" em todas as descrições acima - a ordem atual do ASF é fortemente afetada pelo **[algorítimo de coleta de cartas](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance-pt-BR)** e a classificação afetará apenas os resultados que o ASF considera ser o mesmo com relação a performance. Por exemplo, no algoritmo `Simple`, a ordem de coleta selecionada em `FarmingOrders` deve ser inteiramente respeitada na sessão atual de coleta (uma vez que cada jogo tem o mesmo valor de desempenho), enquanto no `Complex` a ordem atual do algoritmo é afetada primeiro pelas horas, e depois classificada de acordo com escolhido em `FarmingOrders`. Isto trará resultados diferentes, já que jogos com tempo de jogo existente terão prioridade sobre os outros, então o ASF vai rodar os jogos que já passaram do tempo configurado em `HoursUntilCardDrops` primeiro e só então classificar os demais de acordo com sua escolha em `FarmingOrders`. Da mesma forma, assim que o ASF terminar os jogos que já tem horas de jogo ele vai classificar a lista restante colocando os com mais horas em primeiro lugar (já que isso vai diminuir o tempo necessário de execução dos demais títulos que necessitem alcançar o `HoursUntilCardDrops`). Portanto, esta propriedade de configuração é apenas uma **sugestão** que o ASF tentará respeitar enquanto ela não afetar negativamente o desempenho (neste caso, o ASF sempre preferirá o melhor desempenho na coleta em vez da `FarmingOrders`).

Há também uma lista de prioridade de coleta acessível através de **[comandos](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-pt-BR)** `fq`. Se ele é usado, a ordem de coleta é classificada em primeiro lugar por desempenho, em seguida pela lista de coleta e, finalmente por sua indicação em `FarmingOrders`.

---

### `FarmPriorityQueueOnly`

Tipo `bool` com valor padrão `false`. Esta propriedade define se o ASF deve considerar para coleta automática apenas os apps que você adicionou a fila de prioridade disponível com o **[comando](https://github.com/JustArchi/ArchiSteamFarm/wiki/Commands-pt-BR)** `fq`. Quando esta opção estiver habilitada, o ASF ignorará todos `appIDs` que não estejam na lista, permitindo que você escolha efetivamente os jogos que deseja que o ASF colete. Tenha em mente que se você não adicionar nenhum jogo na lista o ASF atuará como se não houvesse nada para coletar na sua conta. Se você não tiver certeza se quer esse recurso habilitado ou não, mantenha-o com o valor `false` padrão.

---

### `GamesPlayedWhileIdle`

Tipo `ImmutableHashSet<uint>` com valor padrão vazio. Se o ASF não tem nada para coletar ele pode jogar seus jogos Steam (`appIDs`). Jogar os jogos de tal forma aumenta suas horas "jogadas" nesses jogos, mas nada mais além disso. Para que esse recurso funcione corretamente, sua conta Steam **deve** possuir uma licença válida para todos os `appIDs` que você especificar aqui, incluindo jogos gratuitos. Esse recurso pode ser habilitado juntamente com `CustomGamePlayedWhileIdle` para poder jogar seus jogos selecionados e, ao mesmo tempo, mostrar um status personalizado na rede Steam, mas neste caso, como no caso de `CustomGamePlayedWhileFarming`, a ordem de exibição real não é garantida. Note que o Steam só permite que o ASF rode até `32` `appIDs` no total, portanto esse é o máximo de AppIDs que você pode inserir nesta propriedade.

---

### `HoursUntilCardDrops`

Tipo `byte` com o valor padrão `3`. Esta propriedade define se a conta tem restrição na coleta de cartas, e caso sim, por quantas horas. Restrição de coleta de cartas significa que a conta não receberá cartas de determinados jogos até que os mesmos sejam jogados por pelo menos a quantidade de horas indicada em `HoursUntilCardDrops`. Infelizmente não existe uma fórmula mágica para detectar isso, então o ASF depende de você. Esta propriedade afeta o **[algorítimo de coleta de cartas](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance-pt-BR)** que será usado. Configurar essa propriedade corretamente vai maximizar os lucros e minimizar o tempo necessário para que as cartas sejam coletadas. Lembre-se que não há nenhuma resposta óbvia se você deve usar um ou outro valor, desde que depende totalmente da sua conta. Parece que as contas mais antigas que nunca pediram reembolso têm o recebimento de cartas sem restrição, então elas devem usar o valor `0`, enquanto novas contas e aqueles que pediram reembolso tem essa restrição e devem manter o valor em `3`. No entanto isso é apenas uma teoria e não deve ser tomada como regra. O valor padrão para essa propriedade foi definido com base no "mal menor" e a maioria dos casos de uso.

---

### `LootableTypes`

Tipo `ImmutableHashSet <byte>` com valor padrão de tipos de itens Steam `1, 3, 5`. Essa propriedade define o comportamento do ASF quando estiver coletando tanto manualmente quanto através de algum **[comando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-pt-BR)**, ou mesmo automaticamente, atrávés de uma ou mais propriedades de configuração. O ASF garantirá que apenas itens definidos em `LootableTypes` serão incluídos na oferta de troca, portanto, essa propriedade permite que você escolha o que você deseja receber na uma oferta de troca que está sendo enviada a você.

| Valor | Nome                  | Descrição                                                                   |
| ----- | --------------------- | --------------------------------------------------------------------------- |
| 0     | Unknown               | Qualquer tipo que não se encaixa em nenhuma das opções abaixo               |
| 1     | BoosterPack           | Pacote de cartas contendo 3 cartas aleatórias de um jogo                    |
| 2     | Emoticon              | Emoticons para uso na Conversa Steam                                        |
| 3     | FoilTradingCard       | Versão brilhante da `Carta Colecionável`                                    |
| 4     | ProfileBackground     | Fundo de perfil para usar em seu Perfil Steam                               |
| 5     | TradingCard           | Cartas colecionáveis Steam, usadas para fabricar insígnias (não brilhantes) |
| 6     | SteamGems             | Gemas Steam usadas para criar pacotes de cartas, incluindo as empacotadas   |
| 7     | SaleItem              | Itens especiais ganhos durante as promoções Steam                           |
| 8     | Consumable            | Consumíveis especiais que desaparecem após serem usados                     |
| 9     | ProfileModifier       | Itens especiais que podem modificar a aparência do Perfil Steam             |
| 10    | Adesivo               | Itens especiais que podem ser usados na Conversa Steam                      |
| 11    | ChatEffect            | Itens especiais que podem ser usados na Conversa Steam                      |
| 12    | MiniProfileBackground | Plano de fundo especial para o Perfil Steam                                 |
| 13    | AvatarProfileFrame    | Moldura do avatar especial para o Perfil Steam                              |
| 14    | AnimatedAvatar        | Avatar animado especial para o Perfil Steam                                 |
| 15    | KeyboardSkin          | Skin especial de teclado para Steam deck                                    |
| 16    | StartupVideo          | Vídeo de inicialização especial para o Steam deck                           |

Please note that regardless of the settings above, ASF will only ask for **[Steam community items](https://steamcommunity.com/my/inventory/#753_6)** (`appID` of 753, `contextID` of 6), so all game items, gifts and likewise, are excluded from the trade offer by definition.

A configuração padrão do ASF baseia-se no uso mais comum do bot, coletando apenas pacotes de cartas e cartas colecionáveis (incluindo as brilhantes). A propriedade definida aqui permite que você mude esse comportamento da forma que te satisfaça. Por favor, tenha em mente que todos os tipos não definidos acima serão classificados como `Unknown`, o que é especialmente importante quando a Valve libera um novo item da Steam, que será marcado como `Unknown` pelo ASF também, até que seja adicionado aqui (em uma versão futura). É por isso que, em geral, não é recomendado incluir o tipo `Unknown` em seu `LootableTypes`, a menos que você saiba o que está fazendo, e compreende também que o ASF enviará seu inventário inteiro em uma oferta de troca se a rede Steam der algum problema novamente e reportar todos os seus itens como `Unknown`. Minha sugestão é não incluir o tipo `Unknown` em `LootableTypes`, mesmo que você espere transferir tudo.

---

### `MatchableTypes`

Tipo `ImmutableHashSet <byte>` com valor padrão de tipos de itens Steam `5`. Esta propriedade define quais tipos de itens Steam tem permissão de serem combinados se a opção `SteamTradeMatcher` estiver habilitada em `TradingPreferences`. Os tipos são definidos abaixo:

| Valor | Nome                  | Descrição                                                                         |
| ----- | --------------------- | --------------------------------------------------------------------------------- |
| 0     | Unknown               | Qualquer item que não se encaixa em nenhuma das opções abaixo                     |
| 1     | BoosterPack           | Pacote de cartas contendo 3 cartas aleatórias de um jogo                          |
| 2     | Emoticon              | Emoticons para uso na Conversa Steam                                              |
| 3     | FoilTradingCard       | Versão brilhante da `Carta Colecionável`                                          |
| 4     | ProfileBackground     | Fundo de perfil para usar em seu Perfil Steam                                     |
| 5     | TradingCard           | Cartas colecionáveis Steam, sendo usadas para fabricar insígnias (não brilhantes) |
| 6     | SteamGems             | Gemas Steam usadas para criar pacotes de cartas, incluindo as empacotadas         |
| 7     | SaleItem              | Itens especiais ganhos durante as promoções Steam                                 |
| 8     | Consumable            | Consumíveis especiais que desaparecem após serem usados                           |
| 9     | ProfileModifier       | Itens especiais que podem modificar a aparência do Perfil Steam                   |
| 10    | Adesivo               | Itens especiais que podem ser usados na Conversa Steam                            |
| 11    | ChatEffect            | Itens especiais que podem ser usados na Conversa Steam                            |
| 12    | MiniProfileBackground | Plano de fundo especial para o Perfil Steam                                       |
| 13    | AvatarProfileFrame    | Moldura do avatar especial para o Perfil Steam                                    |
| 14    | AnimatedAvatar        | Avatar animado especial para o Perfil Steam                                       |
| 15    | KeyboardSkin          | Skin especial de teclado para Steam deck                                          |
| 16    | StartupVideo          | Vídeo de inicialização especial para o Steam deck                                 |

É claro, os tipos de itens que você deve usar para essa propriedade normalmente incluem apenas `2`, `3`, `4` e `5`, já que apenas esses tipos são suportados pelo STM. O ASF inclui uma lógica própria para descobrir a raridade dos itens, portanto também é seguro combinar emoticons ou planos de fundo, uma vez que o ASF vai considerar justo apenas os itens do mesmo jogo e tipo, que também compartilhem a mesma raridade.

Por favor, note que o **ASF não é um bot de troca** e **não vai levar em conta os valores do mercado**. Se você não considerar itens da mesma raridade e do mesmo conjunto como equivalentes no preço, então esta opção NÃO é para você. Por favor, avalie bem se você entendeu e concorda com esta declaração antes de decidir alterar esta configuração.

A menos que você saiba o que está fazendo, você deve mantê-lo com o valor `5` padrão.

---

### `OnlineFlags`

Tipo `ushort flags` com o valor padrão `0`. Esta propriedade funciona como um complemento para **[`OnlineStatus`](#onlinestatus)** e especifica recursos adicionais de presença on-line anunciados à Rede Steam. Requer **[`OnlineStatus`](#onlinestatus)** diferente de `Off-line`, e é definido como abaixo:

| Valor | Nome              | Descrição                             |
| ----- | ----------------- | ------------------------------------- |
| 0     | None              | Nenhuma flag on-line especial, padrão |
| 256   | ClientTypeWeb     | Cliente está usando interface web     |
| 512   | ClientTypeMobile  | Cliente está usando dispositivo móvel |
| 1024  | ClientTypeTenfoot | Cliente está usando big picture       |
| 2048  | ClientTypeVR      | Cliente está usando headset VR        |

Por favor note que esta propriedade é um campo do tipo `flags`, portanto é possível escolher qualquer combinação de valores disponíveis. Check out **[json mapping](#json-mapping)** if you'd like to learn more. Não habilitar nem um flag resultará na opção `None`.

O tipo subjacente `EPersonaStateFlag` no qual essa propriedade se baseia inclui mais flags disponíveis, no entanto, até onde sabemos, eles não têm absolutamente nenhum efeito a partir de hoje, portanto, foram deixados de lado.

Se você não tem certeza de como definir essa propriedade, deixe-a com o valor padrão `0`.

---

### `OnlineStatus`

Tipo `byte` com o valor padrão `1`. Esta propriedade especifica o status na comunidade Steam no qual o bot será anunciado após efetuar login na rede Steam. Atualmente você pode escolher um dos status abaixo:

| Valor | Nome            |
| ----- | --------------- |
| 0     | Offline         |
| 1     | Disponível      |
| 2     | Ocupado         |
| 3     | Ausente         |
| 4     | Dormindo        |
| 5     | Querendo trocar |
| 6     | Querendo jogar  |
| 7     | Invisível       |

O status `offline` é extremamente útil para contas primárias. Como você deve saber, coletar de um jogo mostra seu status na Steam como "Em jogo: XXX", que pode enganar seus amigos fazendo-os acreditar que você está jogando, enquanto na verdade você está apenas coletando. Usar o status `Offline` resolve esse problema - sua conta nunca aparecerá como "em jogo" quando você estiver coletando cartas Steam com o ASF. Isto é possível graças ao fato de que o ASF não precisa se conectar à comunidade Steam para funcionar corretamente, então na verdade estamos jogando esses jogos, conectados à rede Steam, mas sem anunciar nossa presença on-line. Tenha em mente que jogos jogados usando o status offline ainda contam para seu tempo de jogo e são mostrados como "jogado recentemente" no seu perfil.

Além disso, esse recurso também é importante caso você deseje receber notificações e mensagens não lidas quando o ASF estiver rodando, sem manter o cliente Steam aberto ao mesmo tempo. Isto acontece porque o ASF atua como um cliente Steam em si, e quer ASF goste ou não, a Steam transmite todas essas mensagens e outros eventos para ele. Isto não é um problema se você tiver tanto o ASF quanto seu próprio cliente Steam rodando, já que ambos os clientes recebem exatamente os mesmos eventos. No entanto, se apenas o ASF estiver rodando, a rede Steam poderia marcar certos eventos e mensagens como "entregue", apesar do seu cliente Steam tradicional não recebê-los por não estar aberto. O status off-line também resolve esse problema, já que o ASF nunca será considerado para quaisquer eventos da Comunidade neste caso, então todas as mensagens não lidas e outros eventos estarão devidamente marcados quando você voltar.

É importante notar que o ASF rodando em modo `Off-line` **não** estará apto a receber os comandos no chat Steam, já que o chat, assim como toda a comunidade está, na verdade, inteiramente off-line. Uma solução para esse problema é usar o modo `Invisível`, que trabalha de forma similar (não expondo o status), mas mantém a habilidade de receber e responder mensagens (podendo potencialmente dispensar notificações e mensagens não lidas como citado acima). O modo `Invisível` faz mais sentido em contas alternativas, as quais você não quer expor (ao status automático), mas ainda quer ser apto a enviar comandos.

No entanto, há uma questão com o modo `Invisível` - ele não se sai bem com contas primárias. Isso porque **qualquer** sessão Steam que esteja on-line **expõe** o status, mesmo que o ASF não o faça. Isso é causado por uma limitação/bug atual da Rede Steam que é impossível de ser corrigida pelo lado do ASF, então se você quer usar o modo `Invisível` você precisa se certificar que **todas** as outras sessões da mesma conta também usem o modo `Invisível`. Esse será o caso em contas alternativas onde o ASF seja, esperançosamente, a única sessão ativa, mas em contas primárias você quase sempre preferirá aparecer `Online` para seus amigos, escondendo apenas a atividade do ASF, e neste caso o modo `Invisível` será inteiramente inútil pra você (nós recomendamos usar o modo `Offline` nesse caso). Esperamos que essa limitação/bug seja eventualmente resolvida no futuro pela Valve, mas eu não espero que isso aconteça tão cedo...

Se você não tem certeza de como configurar essa propriedade, é recomendado usar o valor `0` (`Offline`) para contas primárias e o padrão `1` (`Disponível`) para as outras.

---

### `PasswordFormat`

Tipo `byte` com o valor padrão `0` (`PlainText`). Essa propriadade define o formato da propriedade `SteamPassword`, e atualmente suporta os valores especificados na seção **[segurança](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security-pt-BR)**. Você deve seguir as instruções especificadas aqui, já que você precisará garantir que a propriedade `SteamPassword` de fato inclua a senha em `PasswordFormat`. Em outras palavras, quando você alterar o `PasswordFormat` então seu `SteamPassword` **já** deve estar nesse formato, não apenas esperando ser mudado posteriormente. A menos que você saiba o que está fazendo, você deve mantê-lo com o valor `0` padrão.

---

### `Paused`

Tipo `bool` com valor padrão `false`. Esta propriedade define o estado inicial do módulo `CardsFarmer`. Com o valor padrão `false`, o bot começará a coletar automaticamente quando for iniciado com o parâmetro `Enabled` ou o comando `start`. Mudar essa propriedade para `true` só deve ser feito se você quiser `retomar` manualmente o processo de coleta automática, por exemplo, se você quiser usar sempre o comando `play` e nunca usar o módulo automático `CardsFarmer` - isso funciona exatamente igual ao **[comando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-pt-BR)** `pause`. Se você não tiver certeza se quer esse recurso habilitado ou não, mantenha-o com o valor `false` padrão.

---

### `RedeemingPreferences`

Tipo `byte flags` com o valor padrão `0`. Essa propriedade define o comportamento do ASF quando estiver resgatando cd-keys, e é definida abaixo:

| Valor | Nome                               | Descrição                                                                                                                   |
| ----- | ---------------------------------- | --------------------------------------------------------------------------------------------------------------------------- |
| 0     | None                               | Sem preferências especiais de resgate, padrão                                                                               |
| 1     | Forwarding                         | Encaminha keys indisponíveis para serem resgatadas por outros bots                                                          |
| 2     | Distributing                       | Distribui todas as keys entre si e os outros bots                                                                           |
| 4     | KeepMissingGames                   | Guarda as keys de jogos que (possivelmente) não estejam em sua conta, deixando-as sem uso                                   |
| 8     | AssumeWalletKeyOnBadActivationCode | Assume que `BadActivationCode` são iguais à `CannotRedeemCodeFromClient` e, portanto, tenta resgatá-los como vales presente |

Por favor note que esta propriedade é um campo do tipo `flags`, portanto é possível escolher qualquer combinação de valores disponíveis. Check out **[json mapping](#json-mapping)** if you'd like to learn more. Não habilitar nem um flag resultará na opção `None`.

`Forwarding` fará com que o bot encaminhe uma key que não pode ser ativadar, para outro bot conectado e rodando que não tenha aquele jogo em particular (se for possível verificar). A situação mais comum é encaminhar um jogo `AlreadyPurchased` (já comprado) para outro bot que não tenha aquele jogo, mas esta opção também abrange outros cenários, tal como `DoesNotOwnRequiredApp` (não possui o jogo base), `RateLimited` (limite de tentativas excedido) ou `RestrictedCountry` (restrição regional).

`Distributing` fará com que o bot distribua todas as keys recebidas entre si e os outros bots. Isto significa que cada bot receberá uma key do lote. Normalmente isto é usado somente quando você está resgatando muitas keys de um mesmo jogo, e você quer distribuí-las igualmente entre seus bots, diferente de resgatar keys para vários jogos diferentes. Este recurso não faz sentido se você for resgatar apenas uma key em um único comando `redeem` (pois não há nenhuma key extra para ser distribuída).

`KeepMissingGames` fará com que o bot ignore o `Forwarding` quando ele não conseguir determinar se nosso bot já possui o jogo relacionado àquela key, ou não. Isso significa basicamente que `Forwarding` será aplicado **somente** para keys de jogos `AlreadyPurchased` (já comprados), em vez de cobrir também outros casos como `DoesNotOwnRequiredApp` (não possui o jogo base), `RateLimited` (limite de tentativas excedido) ou `RestrictedCountry` (restrição regional). Normalmente você vai querer usar esta opção na conta principal, para garantir que as keys a serem resgatadas nela não sejam passadas adiante caso sua conta atinja o `RateLimited`. Como você pode imaginar pela descrição, este campo não tem absolutamente nenhum efeito se `Forwarding` não estiver habilitado.

`AssumeWalletKeyOnBadActivationCode` fará com que keys tratadas como `BadActivationCode` sejam tratadas como `CannotRedeemCodeFromClient` e, portanto, fará com que o ASF tente resgatá-las como códigos de vale presente. Isso é necessário pois o Steam pode marcar códigos de vale presente como `BadActivationCode` (e não como `CannotRedeemCodeFromClient` como de costume), o que fará com que o ASF nunca tente resgatá-los. No entanto, recomendamos fortemente **não** usar essa preferência, pois isso fará com que o ASF tente resgatar todos os códigos inválidos como sendo vale presentes, resultando em uma quantidade excessiva (e potencialmente inválidas) de pedidos enviados para o serviço Steam, com todas as potenciais consequências. Ao invés disso, recomendamos usar o comando `ForceAssumeWalletKey` **[`redeem^`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-pt-BR#m%C3%A9todos-redeem)** quando for ativar códigos de vale presente, que vai habilitar essa função apenas quando necessário.

Habilitar `Forwarding` e `Distributing` adicionará a característica de distribuição acima da encaminhamento, fazendo com que o ASF tente resgatar uma chave em todos os bots primeiro (encaminhamento) antes de passar para a próxima (distribuição). Normalmente, você vai querer usar essa opção somente quando você quer encaminhar (`Forwarding`), mas com o comportamento alterado para pular o bot quando a key tiver sido usada, em vez de sempre seguir em ordem com todas as keys (que seria o `Forwarding` sozinho). Este comportamento pode ser benéfico se você sabe que a maioria, ou mesmo todas, as keys são do mesmo jogo, pois nesta situação o `Forwarding` sozinho tenta resgatar tudo em um bot primeiro (que faz sentido se as keys são para jogos diferentes), e `Forwarding` + `Distributing` troca de bot para tentar ativar a próxima key, "distribuindo" a tarefa de resgatar uma nova key para outro bot diferente do inicial (que faz sentido se as keys são para o mesmo jogo, pulando uma tentativa inútil de resgate por cada key).

A ordem real para todos os cenários de ativação de keys é alfabética, excluindo os bots que não estão disponíveis (desconectados, parados ou afins). Por favor, tenha em mente que há um limite de tentativas de ativação por IP e por conta a cada hora, e mesmo ativações que estejam `OK` somam para tentativas falhas. O ASF fará o seu melhor para minimizar o número de falhas `AlreadyPurchased`, por exemplo, ao tentar evitar o encaminhamento de uma key para um bot que já possui esse jogo em particular, mas não há garantia de que isso sempre funcione devido a forma com que o Steam lida com licenças. Usar flags de ativação como `Forwarding` ou `Distributing` sempre aumentará a probabilidade de atingir `RateLimited`.

Também tenha em mente que você não pode encaminhar ou distribuir keys para bots aos quais você não tem acesso. Isso deveria ser óbvio, mas certifique-se que você tem ao menos o acesso `Operator` para todos os bots que você quer incluir no processo de ativação, com o **[comando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-pt-BR)** `status ASF`, por exemplo.

---

### `RemoteCommunication`

Tipo `byte flags` com o valor padrão `3`. Essa propriedade define o comportamento individual por bot do ASF quando se trata de comunicação com serviços de terceiros ou remotos, e é definida abaixo:

| Valor | Nome          | Descrição                                                                                                                                                                                                                                                        |
| ----- | ------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| 0     | Nenhum        | Não permitida nenhuma comunicação com terceiros, tornando os recursos ASF selecionados inutilizáveis                                                                                                                                                             |
| 1     | SteamGroup    | Permite comunicação com o **[Grupo Steam do ASF](https://steamcommunity.com/groups/archiasf)**                                                                                                                                                                   |
| 2     | PublicListing | Permite a comunicação com a **[lista STM do ASF](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#publiclisting)** para ser listado, se o usuário também habilitou `SteamTradeMatcher` em **[`TradingPreferences `](#tradingpreferences)** |

Por favor note que esta propriedade é um campo do tipo `flags`, portanto é possível escolher qualquer combinação de valores disponíveis. Check out **[json mapping](#json-mapping)** if you'd like to learn more. Não habilitar nem um flag resultará na opção `None`.

Esta opção não incluí todas as comunicações de terceiros oferecidos pelo ASF, somente aquelas que não são implícitas pelas outras configurações. Por exemplo, se você habilitou as atualizações automáticas do ASF, o ASF irá se comunicar com o GitHub (para downloads), e com o nosso servidor (para a verificação do checksum), de acordo com sua configuração. Do mesmo modo que habilitar `MatchActively` em **[`TradingPreferences`](#tradingpreferences)**, faz com que a comunicação seja feita com o nosso servidor para buscar bots listados, que é necessário para essa funcionalidade.

Mais informações a respeito deste assunto está disponível na seção **[Comunicação Remota](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Remote-communication)**. A menos que você tenha uma razão para editar essa propriedade, você deve mantê-la padrão.

---

### `SendOnFarmingFinished`

Tipo `bool` com valor padrão `false`. Quando o ASF termina a coleta em determinada conta, ele pode automaticamente enviar uma proposta de troca contendo tudo o que foi coletado até o momento para o usuário com permissão `Master`, o que é muito conveniente se você não quiser ficar se preocupando com trocas. Esta opção funciona da mesma forma que o comando `loot`, portanto, tenha em mente que ele requer um usuário com o conjunto de permissões `Master`, você também pode precisar de um `SteamTradeToken` válido, tanto quanto o uso de uma conta que seja, em primeiro lugar, elegível para trocas. Quando essa opção está ativada, além de iniciar o `loot` após terminar a coleta, o ASF também inicia o `loot` a cada notificação de novos itens (quando não estiver coletando) e depois de completar trocas que resultem em novos itens (sempre). Isso é especialmente útil para "encaminhar" itens recebidos de outras pessoas para a nossa conta.

Typically you'll want to use **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)** together with this feature, although it's not a requirement if you intend to handle 2FA confirmations manually in timely fashion. Se você não tem certeza de como definir essa propriedade, deixe-a com o valor padrão `false`.

---

### `SendTradePeriod`

Tipo `byte` com o valor padrão `0`. Essa propriedade funciona de forma muito semelhante à propriedade `SendOnFarmingFinished`, com uma diferença - em vez de enviar a troca quando a coleta terminar, podemos envia-la no intervalo de tempo, em horas, determinado em `SendTradePeriod`, independente de quanto ainda temos para coletar. Isto é útil se você quiser receber os itens de suas contas adicionais regularmente ao invés de esperar que a coleta termine. O valor padrão `0` desativa este recurso e se você quer que o seu bot envie a proposta de troca, por exemplo, todos os dias, você deve colocar o valor `24` aqui.

Typically you'll want to use **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)** together with this feature, although it's not a requirement if you intend to handle 2FA confirmations manually in timely fashion. Se você não tem certeza de como definir essa propriedade, deixe-a com o valor padrão `0`.

---

### `ShutdownOnFarmingFinished`

Tipo `bool` com valor padrão `false`. O ASF "ocupa" uma conta durante todo o tempo em que o processo esteja ativo. Quando ele termina a coleta nessa conta, o ASF verifica periodicamente (a cada hora configurada em `IdleFarmingPeriod`), se algum novo jogo com cartas Steam foi adicionado, então ele pode retomar a coleta naquela conta sem a necessidade de reiniciar o processo. Isso é útil para a maioria das pessoas, já que o ASF pode retomar automaticamente a coleta quando necessário. No entanto, você pode realmente querer parar o processo quando determinada conta for totalmente explorada, e você faz isso definindo essa propriedade como `true`. Quando habilitado, o ASF vai desconectar quando a conta for totalmente explorada, o que significa que ela não será periodicamente verificada ou ocupada. Você deve decidir se você prefere que o ASF trabalhe em determinada conta bot o tempo todo, ou se o ASF deve interrompê-la quando o processo de coleta for terminado. Quando todas as contas estiverem paradas e o processo não estiver rodando no **[modo](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-Line-Arguments-pt-BR)** `--process-required`, o ASF também se desligará, colocando seu computador em espera e permitindo que você programe outras ações, tais como suspender ou desligar assim que a última carta for recebida.

Se você não tem certeza de como definir essa propriedade, deixe-a com o valor padrão `false`.

---

### `SkipRefundableGames`

Tipo `bool` com valor padrão `false`. Esta propriedade define se o ASF tem permissão para coletar de jogos que ainda são reembolsáveis. Um jogo reembolsável é um jogo que você comprou na Loja Steam nas últimas duas semanas e que ainda não foi jogado por mais de 2 horas, como indicado na página **[Reembolsos no Steam](https://store.steampowered.com/steam_refunds)**. Por padrão, quando esta opção estiver definida como `false`, o ASF ignora a política de reembolso inteiramente e coleta tudo, como a maioria das pessoas deve esperar. No entanto, você pode alterar esta opção para `true` se você deseja garantir que o ASF não coloete de qualquer um dos seus jogos reembolsáveis cedo demais, permitindo que você os avalie peça reembolso caso necessário, sem se preocupar com o ASF afetando negativamente seu tempo de jogo. Observe que se você habilitar essa opção os jogos que você comprar da loja do Steam não serão executados pelo ASF antes de 14 dias da data de ativação e será mostrado que não há jogos a serem coletados caso sua conta não tenha mais jogos a serem coletados. Se você não tiver certeza se quer esse recurso habilitado ou não, mantenha-o com o valor `false` padrão.

---

### `SteamLogin`

Tipo `string` com o valor padrão `null`. Essa propriedade define seu login Steam - aquele que você usa para entrar no Steam. Além de definir o login Steam aqui, você também pode manter valor padrão `null` se desejar digitar seu login Steam em cada inicialização do ASF em vez de colocá-lo na configuração. Isso pode ser útil para você se você não quiser salvar dados confidenciais no arquivo de configuração.

---

### `SteamMasterClanID`

Tipo `ulong` com o valor padrão `0`. Esta propriedade define a steamID do grupo Steam que bot deve entrar automaticamente, incluindo seu chat em grupo. Você pode verificar o SteamID de seu grupo navegando até a **[página](https://steamcommunity.com/groups/archiasf)** dele e, em seguida, adicionando `/memberslistxml?xml=1` no final do link que ficará semelhante a **[este](https://steamcommunity.com/groups/archiasf/memberslistxml?xml=1)**. Então você pode pegar o steamID do seu grupo no resultado, ele estará entre as tags `<groupID64>`. No exemplo acima ele seria `103582791440160998`. Além de tentar entrar no grupo quando iniciado, o bot também aceitará automaticamente convites para esse grupo, o que te permite convidar o bot manualmente caso o grupo seja privado. Se você não tem nenhum grupo dedicado aos seus bots, você deve manter essa propriedade com o valor padrão `0`.

---

### `SteamParentalCode`

Tipo `string` com o valor padrão `null`. Essa propriedade define o seu PIN de acesso ao Modo Família. O ASF requer acesso a recursos protegidos pelo modo família, portanto se você usa esse recurso, você precisa fornecer ao ASF o PIN de desbloqueio, assim ele poderá operar normalmente. O valor padrão `null` significa que não há um PIN necessário para desbloquear esta conta, e isso é o que você precisa se você não usa o modo família.

Em circunstâncias limitadas, o ASF também estará apto a gerar um código por conta própria, embora isso requira uma quantidade considerável de recursos do Sistema Operacional e tempo adicional, e ainda não é garantido que funcione, portanto nós recomendamos não contar com esse recurso e ao invés disso colocar um `SteamParentalCode` válido no arquivo de configuração para que o ASF o utilize. Se o ASF determinar que o PIN é necessário e que não será possível gerar um por conta própria, ele pedirá que você digite um.

---

### `SteamPassword`

Tipo `string` com o valor padrão `null`. Essa propriedade define sua senha Steam - aquela que você usa para entrar no Steam. Além de definir a senha do Steam aqui, você também pode manter valor padrão `null` se desejar digitar sua senha do Steam em cada inicialização do ASF em vez de colocá-lo na configuração. Isso pode ser útil para você se você não quiser salvar dados confidenciais no arquivo de configuração.

---

### `SteamTradeToken`

Tipo `string` com o valor padrão `null`. Quando você tem seu bot sua lista de amigos ele pode enviar propostas de troca para você diretamente, sem se preocupar com o token de troca, portanto você pode deixar essa propriedade com o valor padrão `null`. Se por acaso você decidir não ter seu bot na sua lista de amigos, então você precisará gerar e preencher um token de troca como o usuário para o qual esse bot está esperando para enviar trocas. Em outras palavras, essa propriedade deve ser preenchida com o token de trocas da conta do que é definida com a permissão `Master` em `SteamUserPermissions` **dessa** conta bot.

Para encontrar seu token, estando conectado como o usuário com a permissão `Master`, navegue até **[aqui](https://steamcommunity.com/my/tradeoffers/privacy)** e dê uma olhada em sua URL de troca. O token que procuramos é são os 8 caracteres após `&token=` em sua URL de troca. Você deve copiar e colocar esses 8 caracteres aqui, como `SteamTradeToken`. Não inclua toda a URL de troca, nem a parte `&token=`, apenas o próprio token (8 caracteres).

---

### `SteamUserPermissions`

Tipo `ImmutableDictionary<ulong, byte>` com o valor padrão vazio. Esta propriedade é um array associativo que atribui uma correspondência entre determinado usuário Steam identificado pelo steamID de 64-bit e o número em `byte` que especifica quis os seus direitos sobre esse bot do ASF. Atualmente as permissões disponíveis para os bots no ASF são definidas como:

| Valor | Nome          | Descrição                                                                                                                                                                                                               |
| ----- | ------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| 0     | None          | Sem permissões especiais, esse é apenas um valor de referência que é atribuído quando não há IDs Steam nesse parâmetro - não há necessidade de definir alguém com esta permissão                                        |
| 1     | FamilySharing | Fornece acesso mínimo para usuários do modo família. Novamente, esse é apenas um valor de referência, uma vez que o ASF é capaz de descobrir automaticamente os IDs Steam que estão autorizados a usar nossa biblioteca |
| 2     | Operator      | Fornece acesso básico a determinadas contas bot, principalmente adicionar licenças e resgatar keys                                                                                                                      |
| 3     | Master        | Fornece acesso completo a determinada conta bot                                                                                                                                                                         |

Em resumo, esta propriedade permite que você manipule permissões para determinados usuários. As permissões são importantes principalmente para acessar os **[comandos](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-pt-BR)** do ASF, mas também para habilitar muitos recursos, tais como aceitar trocas. Por exemplo, você pode querer definir sua própria conta como `Master` e dar acesso de `Operator` para 2 ou 3 dos seus amigos, assim eles podem facilmente resgatar keys para seu bot com o ASF, enquanto **não** são elegíveis, por exemplo, para parar o processo. Graças a isso você pode facilmente atribuir permissões para determinados usuários e deixá-los usarem seu bot para determinadas tarefas especificadas pelo seu nível.

Recomendamos que defina exatamente um usuário como `Master` e quantos você quiser como `Operators` e abaixo. É tecnicamente possível definir vários `Masters` e o ASF funcionará corretamente com eles, por exemplo, ao aceitar todas as trocas enviadas para o bot, o ASF usará apenas um deles (com o ID Steam mais baixo) para cada ação que requer um único alvo, por exemplo, uma solicitação de `loot`, assim como as propriedades `SendOnFarmingFinished` ou `SendTradePeriod`. Se você entende perfeitamente essas limitações, especialmente o fato de que a solicitação de `loot` sempre enviará os itens para o `Master` com ID Steam mais baixo, independente do `Master` que tenha executado o comando, então você pode definir vários usuários com a permissão `Master` aqui, mas ainda assim recomendamos um único master.

É bom notar que há mais uma permissão extra `Owner` (proprietário), que é declarada com a propriedade de configuração global `SteamOwnerID`. Você não pode atribuir a permissão `Owner` para ninguém aqui, já que a propriedade `SteamUserPermissions` define apenas as permissões que estão relacionadas com a conta bot e não o ASF como um todo. Para tarefas relacionadas aos bots, `SteamOwnerID` é tratado da mesma forma que `Master`, então definir o seu `SteamOwnerID` aqui não é necessário.

---

### `TradeCheckPeriod`

Tipo `byte` com o valor padrão `60`. Normalmente o ASF lida com ofertas de troca assim que recebe a notificação, mas às vezes, por conta de alguma falha no Steam, não é possível tratá-la no exato momento, e tais ofertas de troca permanecem ignoradas até a próxima notificação de troca ou o reinício do bot, que pode fazer com que as negociações sejam canceladas ou os itens não estejam disponíveis no momento posterior. Se esse parâmetro estiver definido como um valor diferente de zero, o ASF verificará se há trocas pendentes a cada `TradeCheckPeriod` minutos. O valor padrão levando em consideração o melhor balanço entre pedidos adicionais aos servidores Steam e a possível perda de trocas. No entanto, se você está usando o ASF apenas para coletar cartas e não planeja processar automaticamente quaisquer trocas recebidas, você pode definí-lo como `0` para desativar este recurso completamente. Por outro lado, caso seu bot participe da [listagem STM do ASF](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#publiclisting) ou forneça outros serviços automatizados como um bot de comércio, você pode querer diminuir este parâmetro para `15` minutos, para processar todas as negociações em tempo oportuno.

---

### `TradingPreferences`

Tipo `byte flags` com o valor padrão `0`. Essa propriedade define o comportamento do ASF quando estiver trocando, e é definida abaixo:

| Valor | Nome                | Descrição                                                                                                                                                                                                                                      |
| ----- | ------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| 0     | None                | Sem preferências especiais de troca, padrão                                                                                                                                                                                                    |
| 1     | AcceptDonations     | Aceita trocas em que não estamos perdendo nada                                                                                                                                                                                                 |
| 2     | SteamTradeMatcher   | Participa passivamente de trocas do tipo **[STM](https://www.steamtradematcher.com)**. Visite a seção **[trocas](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading-pt-BR#steamtradematcher)** para mais informações                  |
| 4     | MatchEverything     | Requer que `SteamTradeMatcher` seja definido, e em combinação com ele - também aceita trocas ruins além de boas e neutras                                                                                                                      |
| 8     | DontAcceptBotTrades | Não aceita automaticamente as trocas `loot` de outras contas bot                                                                                                                                                                               |
| 16    | MatchActively       | Participa ativamente de trocas do tipo **[STM](https://www.steamtradematcher.com)**. Visite a seção **[ItemsMatcherPlugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#matchactively)** para obter mais informações |

Por favor note que esta propriedade é um campo do tipo `flags`, portanto é possível escolher qualquer combinação de valores disponíveis. Check out **[json mapping](#json-mapping)** if you'd like to learn more. Não habilitar nem um flag resultará na opção `None`.

Para obter mais explicações sobre a lógica de trocas do ASF e uma descrição de cada flag disponível, visite a seção **[trocas](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Trading-pt-BR)**.

---

### `TransferableTypes`

Tipo `ImmutableHashSet <byte>` com valor padrão de tipos de itens Steam `1, 3, 5`. Essa propriedade define que tipos de itens do Steam serão considerados para transferência entre bots durante o **[comando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-pt-Br)** `transfer`. O ASF garantirá que apenas itens definidos em `TransferableTypes` serão incluídos na oferta de troca, portanto, essa propriedade permite que você escolha o que você deseja receber em uma oferta de troca que está sendo enviada para um de seus bots.

| Valor | Nome                  | Descrição                                                                         |
| ----- | --------------------- | --------------------------------------------------------------------------------- |
| 0     | Unknown               | Qualquer item que não se encaixa em nenhuma das opções abaixo                     |
| 1     | BoosterPack           | Pacote de cartas contendo 3 cartas aleatórias de um jogo                          |
| 2     | Emoticon              | Emoticons para uso na Conversa Steam                                              |
| 3     | FoilTradingCard       | Versão brilhante da `Carta Colecionável`                                          |
| 4     | ProfileBackground     | Fundo de perfil para usar em seu Perfil Steam                                     |
| 5     | TradingCard           | Cartas colecionáveis Steam, sendo usadas para fabricar insígnias (não brilhantes) |
| 6     | SteamGems             | Gemas Steam usadas para criar pacotes de cartas, incluindo as empacotadas         |
| 7     | SaleItem              | Itens especiais ganhos durante as promoções Steam                                 |
| 8     | Consumable            | Consumíveis especiais que desaparecem após serem usados                           |
| 9     | ProfileModifier       | Itens especiais que podem modificar a aparência do Perfil Steam                   |
| 10    | Adesivo               | Itens especiais que podem ser usados na Conversa Steam                            |
| 11    | ChatEffect            | Itens especiais que podem ser usados na Conversa Steam                            |
| 12    | MiniProfileBackground | Plano de fundo especial para o Perfil Steam                                       |
| 13    | AvatarProfileFrame    | Moldura do avatar especial para o Perfil Steam                                    |
| 14    | AnimatedAvatar        | Avatar animado especial para o Perfil Steam                                       |
| 15    | KeyboardSkin          | Skin especial de teclado para Steam deck                                          |
| 16    | StartupVideo          | Vídeo de inicialização especial para o Steam deck                                 |

Please note that regardless of the settings above, ASF will only ask for **[Steam community items](https://steamcommunity.com/my/inventory/#753_6)** (`appID` of 753, `contextID` of 6), so all game items, gifts and likewise, are excluded from the trade offer by definition.

A configuração padrão do ASF baseia-se no uso mais comum do bot, transferindo apenas pacotes de cartas e cartas colecionáveis (incluindo as brilhantes). A propriedade definida aqui permite que você mude esse comportamento da forma que te satisfaça. Por favor, tenha em mente que todos os tipos não definidos acima serão classificados como `Unknown`, o que é especialmente importante quando a Valve libera um novo item da Steam, que será marcado como `Unknown` pelo ASF também, até que seja adicionado aqui (em uma versão futura). É por isso que, em geral, não é recomendado incluir o tipo `Unknown` em seu `TransferableTypes`, a menos que você saiba o que está fazendo, e compreende também que o ASF enviará seu inventário inteiro em uma oferta de troca se a rede Steam der algum problema novamente e reportar todos os seus itens como `Unknown`. Minha sugestão é não incluir tipo `Unknown` em `TransferableTypes`, mesmo que você espere transferir tudo.

---

### `UseLoginKeys`

Tipo `bool` com valor padrão `true`. Esta propriedade define se o ASF deve usar o mecanismo de chaves de login para essa conta Steam. O mecanismo de chaves de login funciona de forma muito semelhante a opção "lembrar-me neste computador" do cliente oficial do Steam, que permite que o ASF armazene e use a chave de login temporária para a próxima tentativa de conexão, ignorando a necessidade de fornecer a senha, Steam Guard ou código 2FA, enquanto nossa chave de login for válida. A chave de login é armazenada no arquivo `BotName.db` e atualizada automaticamente. É por isso que você não precisa fornecer senha/SteamGuard/código 2FA após se conectar com o ASF uma vez.

Chaves de login são usadas por padrão para sua conveniência, portanto você não precisa inserir o `SteamPassword`, SteamGuard ou o código 2FA (quando não usar o **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication-pt-BR)**) em cada login. Também é uma excelente alternativa, já que a chave de login pode ser usada apenas uma única vez e não revela sua senha original de forma alguma. Exatamente o mesmo método é usado pelo seu cliente Steam original, que salva seu nome de usuário e chave de login para a sua próxima tentativa de conexão, sendo efetivamente o mesmo que usar `SteamLogin` com `UseLoginKeys` e `SteamPassword` vazio no ASF.

No entanto, algumas pessoas podem ficar preocupadas até mesmo com esse pequeno detalhe, portanto esta opção está disponível aqui para o caso de você querer garantir que o ASF não armazene nenhum tipo de token que permitiria retomar a sessão anterior após ela ser fechada, o que resultará na autenticação sendo totalmente obrigatória em cada tentativa de logon. Desabilitar essa opção vai funcionar exatamente da mesma forma que não marcar a opção "Lembrar-me neste computador" no cliente Steam oficial. A menos que você saiba o que está fazendo, você deve mantê-la com o valor `true` padrão.

---

### `UserInterfaceMode`

Tipo `byte` com o valor padrão `0`. Esta propriedade especifica o modo de interface de usuário com o qual o bot será anunciado após acessar a Rede Steam. Atualmente você pode escolher um dos modos abaixo:

| Valor | Nome       |
| ----- | ---------- |
| `0`   | Default    |
| `1`   | BigPicture |
| `2`   | Mobile     |

Se você não tem certeza de como definir essa propriedade, deixe-a com o valor padrão `0`.

---

## Estrutura de arquivos

O ASF usa uma estrutura de arquivos bem simples.

```text
├── config
│     ├── ASF.json
│     ├── ASF.db
│     ├── Bot1.json
│     ├── Bot1.db
│     ├── Bot2.json
│     ├── Bot2.db
│     └── ...
├── ArchiSteamFarm.dll
├── log.txt
└── ...
```

Para mover o ASF para um novo local, por exemplo, outro PC, basta mover/copiar a pasta `config`, e essa é a forma recomendada de se fazer qualquer "backup do ASF", já que você sempre pode baixar as partes (programa) restantes do GitHub, sem arriscar comprometer arquivos internos do ASF, por um backup falho, por exemplo.

O arquivo `log.txt` contém o registro gerado pela última execução do ASF. Esse arquivo não contem nenhuma informação confidencial, e é extremamente útil quando acontecem problemas, travamentos ou simplesmente como informação sobre o que aconteceu na última vez que o ASF foi executado. Muitas vezes nós pediremos por esse arquivo se você se deparar com problemas. O ASF administra automaticamente esse arquivo para você, mas você pode fazer ajustes no módulo **[logging](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Logging-pt-BR)** do ASF se você for um usuário avançado.

A pasta `config` é onde fica a configuração do ASF, incluindo todos os seus bots.

`ASF.json` é o arquivo de configuração global do ASF. Esta configuração é usada para especificar como o ASF se comporta como um processo, o que afeta todos os bots e o próprio programa. Você pode encontrar propriedades globais aqui, tal como a do proprietário do processo ASF, atualizações automáticas ou depuração.

`BotName.json` é um arquivo de configuração de determinada conta bot. Esta configuração é usada para especificar como determinado bot se comporta, portanto, essas configurações são específicas para esse bot e não é compartilhada com os outros. Isso permite que você configure bots com várias configurações diferentes e não necessariamente todos eles trabalhando exatamente da mesma forma. Cada bot é nomeado com um identificador único, escolhido por você no `BotName`.

Além dos arquivos de configuração, o ASF também usa a pasta `config` para armazenar bancos de dados.

`ASF.db` é o arquivo de banco de dados global do ASF. Ele atua como um armazenamento global persistente e é usado para salvar várias informações relacionadas ao processo ASF, tais como IPs de servidores locais Steam. **Não edite este arquivo**.

`BotName.db` é um arquivo de banco de dados de determinada conta bot. Este arquivo é usado para armazenar dados cruciais sobre determinada conta bot em uma armazenamento persistente, como chaves de login ou ASF 2FA. **Não edite este arquivo**.

`BotName.keys` é um arquivo especial que pode ser usado para importar keys para o **[ativador de jogos em segundo plano](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer-pt-BR)**. Ele não é obrigatório e nem gerado pelo ASF, mas reconhecido por ele. Esse arquivo é apagado automaticamente quando as keys são importadas com sucesso.

`BotName.maFile` é um arquivo especial que pode ser usado para importar o **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication-pt-BR)**. Ele não é obrigatório e nem gerado pelo ASF, mas reconhecido por ele se o seu `BotName` ainda não usa o ASF 2FA. Esse arquivo é apagado automaticamente quando o ASF 2FA for importado com sucesso.

---

## Mapeamento JSON

Cada propriedade de configuração tem seu tipo. O tipo da propriedade define os valores que são válidos para ela. Você só pode usar valores que são válidos para cada campo - se você usar um valor inválido o ASF não será capaz de analisar sua configuração.

**É altamente recomendado usar o ConfigGenerator (Gerador de Configuração) para gerar as configurações** - ele lida com a maioria das coisas de baixo nível (tais como validação de tipos) para você, então você só precisa definir valores adequados e você também não precisa entender de tipos de variáveis especificados abaixo. Esta seção é dedicada principalmente para as pessoas que querem gerar/editar as configurações manualmente, para que elas saibam quais valores podem usar.

Os tipos usados pelo ASF são nativos do C#, e são especificados abaixo:

---

`bool` - Tipo booleano que aceita apenas os valores `true` (verdadeiro) e `false` (falso).

Exemplo: `"Enabled": true`

---

`byte` - Tipo byte sem sinal, aceita apenas números inteiros de `0` a `255` (inclusive).

Exemplo: `"ConnectionTimeout": 90`

---

`ushort` - Tipo short sem sinal, aceita apenas números inteiros de `0` a `65535` (inclusive).

Exemplo: `"WebLimiterDelay": 300`

---

`uint` - Tipo integral sem sinal, aceita apenas números inteiros de `0` a `4294967295` (inclusive).

---

`ulong` - Tipo integral longo sem sinal, aceita apenas números inteiros de `0` a `18446744073709551615` (inclusive).

Exemplo: `"SteamMasterClanID": 103582791440160998`

---

`string` - Cadeia de caracteres, aceita qualquer sequência de caracteres, incluindo sequência vazia `""` e `null`. Sequências vazias e valores `null` são tratados da mesma forma pelo ASF, então você decide qual quer usar (nós preferimos `null`).

Exemplos: `"SteamLogin": null`, `"SteamLogin": ""`, `"SteamLogin": "MeuNomeDeUsuário"`

---

`Guid?` - Tipo UUID anulável, codificado como string em JSON. O UUID é composto de 32 caracteres hexadecimais, no intervalo de `0` a `9` e `a` até `f`. O ASF aceita uma variedade de formatos válidos - minúsculas, maiúsculas, com e sem traços. Além de um UUID válido, uma vez que essa propriedade é anulável, o valor especial `null` é aceito para indicar a falta de UUID a fornecer.

Exemplos: `"LicenseID": null`, `"LicenseID": "f6a0529813f74d119982eb4fe43a9a24"`

---

`ImmutableList<valueType>` - Coleção (lista) imutável de valores de determinado `valueType`. Em JSON, é definido como uma matriz de elementos de determinado `valueType`. O ASF usa a `List` para indicar que determinada propriedade suporta vários valores e que sua ordem pode ser relevante.

Exemplo de `ImmutableList<byte>`: `"FarmingOrders": [15, 11, 7]`

---

`ImmutableHashSet<valueType>` - Coleção (conjunto) imutável de valores únicos de determinado `valueType`. Em JSON, é definido como uma matriz de elementos de determinado `valueType`. O ASF usa o `HashSet` para indicar que dada propriedade faz sentido apenas para valores únicos e que sua ordem não importa, portanto ele vai ignorar qualquer potencial duplicata durante a análise (se aconteceu de você colocar alguma).

Exemplo de `ImmutableHashSet <uint>`: `"Blacklist": [267420, 303700, 335590]`

---

`ImmutableDictionary<keyType, valueType>` - Dicionário (mapa) imutável que mapeia uma chave única especificada em `keyType`, para o valor especificado em `valueType`. Em JSON, é definida como um objeto com pares de valor chave. Tenha em mente que o `keyType` deve estar sempre entre aspas, mesmo se for um valor do tipo `ulong`. Há também uma exigência rigorosa de a chave ser exclusiva através do mapeamento, desta vez imposta também pelo JSON.

Exemplo de `ImmutableDictionary<ulong, byte>`:`"SteamUserPermissions": { "76561198174813138": 3, "76561198174813137": 1 }`

---

`flags` - Atributos flag combinam diversas propriedades diferentes em um valor final aplicando operações bit a bit. Isso permite que você escolha qualquer combinação possível de vários valores diferentes ao mesmo tempo. O valor final é construído pela soma dos valores de todas as opções habilitadas.

Por exemplo, dados os valores seguintes:

| Valor | Nome |
| ----- | ---- |
| 0     | None |
| 1     | A    |
| 2     | B    |
| 4     | C    |

Usar `B + C` resultaria no valor `6`, usar `A + C` resultaria no valor `5`, usar `C` resultaria no valor `4` e assim por diante. Isso permite que você crie qualquer combinação possível de valores permitidos - se você decidir habilitar todos eles, fazendo `None + A + B + C`, você teria o valor `7`. Note também que um flag com o valor `0` é ativado por definição em todas as outras combinações possíveis, embora muitas vezes seja um flag que não habilite nada específico (tal como `None`).

Então como você pode ver, n oexemplo acima temos 3 flags disponíveis para ligar/desligar (`A`, `B`, `C`) e total de `8` valores possíveis:
- `None -> 0`
- `A -> 1`
- `B -> 2`
- `A + B -> 3`
- `C -> 4`
- `A + C -> 5`
- `B + C -> 6`
- `A + B + C -> 7`

Exemplo: `"SteamProtocols": 7`

---

## Mapeamento de compatibilidade

Devido a limitações do JavaScript não ser capaz de serializar corretamente simples campos `ulong` em JSON ao usar o Gerador de configuração baseado na web, campos `ulong` serão renderizados como strings com o prefixo `s_` na configuração resultante. Isso inclui, por exemplo, `"SteamOwnerID": 76561198006963719` que será escrito pelo ConfigGenerator como `"s_SteamOwnerID": "76561198006963719"`. O ASF inclui uma lógica adequada para lidar automaticamente com o mapeamento dessas strings, então as entradas `s_` no seu arquivo de configuração são válidas e corretamente geradas. Se você estiver gerando o arquivo de configuração por sua conta, recomendamos manter os campos `ulong` iguais ao original, porém, caso você não possa fazer isso, você também pode seguir este esquema e codificá-las como strings com o prefixo `s_` adicionado aos seus nomes. Esperamos resolver essa limitação do JavaScript um dia.

---

## Configuração de compatibilidade

É prioridade máxima do ASF se manter compatível com configurações antigas. Como você já deve saber, propriedades de configuração vazias são tratadas como se estivesse com seus **valores padrão**. Portanto, se novas propriedades de configuração forem introduzidas em novas versões do ASF, todas as suas configurações se manterão **compatíveis** com a nova versão, e o ASF tratará a nova propriedade de configuração como se definida com o **valor padrão**. Você sempre pode adicionar, remover ou editar as propriedades de configuração conforme sua necessidade.

Recomendamos limitar a definição de propriedades de configuração para apenas aquelas que você quer mudar, já que dessa forma você automaticamente herda os valores padrão de todas as demais, não apenas mantendo sua configuração limpa mas também aumentando a compatibilidade caso a gente decida mudar o valor padrão de uma propriedade que você não quer mudar por conta própria (por exemplo o `WebLimiterDelay`).

Devido ao citado acima, o ASF migrará/otimizará automaticamente suas configurações, reformatando-as e removendo os campos que possuem valor padrão. Você pode desabilitar esse comportamento com o **[argumento de linha de comando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments-pt-BR#argumentos)** `--no-config-migrate` se você tiver um motivo específico para tal, por exemplo, caso você esteja fornecendo arquivos de configuração somente leitura e você não quer que o ASF os modifique.

---

## Recarregamento automático

ASF is aware of configs being modified "on-the-fly" - thanks to that, ASF will automatically:
- Criar (e iniciar, se necessário) um novo bot, quando você criar a configuração do mesmo
- Parar (se necessário) e remover o bot antigo, quando você excluir a sua configuração
- Parar (e iniciar, se necessário) qualquer bot, quando você editar a configuração do mesmo
- Reiniciar (se necessário) o bot com novo nome, quando você renomear sua configuração

Todas as ações acima serão feitas automaticamente, sem a necessidade de reiniciar o programa, ou matar os o processo de outros bots (não afetados pelas mudanças).

Além disso, o ASF também se reiniciará (se o `AutoRestart` permitir) caso você modifique a configuração global do ASF `ASF.json`. Da mesma forma, o programa será encerrado se você excluir ou renomeá-lo.

Você pode desabilitar esse comportamento com o **[argumento de linha de comando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments-pt-BR#argumentos)** `--no-config-watch` se você tiver um motivo específico para tal, por exemplo, caso você não queira que o ASF reaja a mudanças de nomes de arquivos na pasta `config`.