# Registros

O ASF permite que você configure seu próprio módulo de registro que será usado durante o tempo de execução. Você pode fazer isso colocando um arquivo especial chamado `NLog.config` na pasta do aplicativo. Você pode ler toda a documentação do NLog na **[wiki do NLog](https://github.com/NLog/NLog/wiki/Configuration-file)**, mas além disso você encontrará alguns exemplos disso aqui também.

---

## Registro padrão

Por padrão o ASF salva os logs no `ColoredConsole` (saída padrão) e em `File` (arquivo). O registro em `file` inclui o arquivo `log.txt` na pasta do programa, e a pasta `logs` para fins de arquivamento.

Uasr uma configuração NLog substitui a configuração padrão do ASF, nesse caso sua configuração substitui **completamente** os registros padrões do ASF, o que significa que se você quiser manter, por exemplo, o destino `ColoredConsole`, você deve defini-lo **você mesmo**. Isso te permite não só adicionar destinos de registro **extras**, mas também a desabilitar ou modificar os **padrões**.

Se você quiser usar o registro padrão do ASF sem quaisquer modificações, você não precisa fazer nada; você também não precisa defini-lo em um `NLog.config` personalizado. Não use um `NLog.config` personalizado se você não quiser modificar o registro padrão do ASF. Para referência, o equivalente ao registro padrão do ASF codificado seria:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" layout="${date:format=yyyy-MM-dd HH\:mm\:ss}|${processname}-${processid}|${level:uppercase=true}|${logger}|${message}${onexception:inner= ${exception:format=toString,Data}}" />
    <target xsi:type="File" name="File" archiveFileName="${currentdir}/logs/log.{#}.txt" archiveNumbering="Rolling" archiveOldFileOnStartup="true" cleanupFileName="false" concurrentWrites="false" deleteOldFileOnStartup="true" fileName="${currentdir}/log.txt" layout="${date:format=yyyy-MM-dd HH\:mm\:ss}|${processname}-${processid}|${level:uppercase=true}|${logger}|${message}${onexception:inner= ${exception:format=toString,Data}}" maxArchiveFiles="10" />

    <!-- A seguir se torna ativo quando a interface IPC do ASF é iniciada -->
    <target type="History" name="History" layout="${date:format=yyyy-MM-dd HH\:mm\:ss}|${processname}-${processid}|${level:uppercase=true}|${logger}|${message}${onexception:inner= ${exception:format=toString,Data}}" maxCount="20" />
  </targets>

  <rules>
    <!-- As entradas a seguir especificam o registro ASP.NET (IPC), as declaramos para que nosso último ponto de verificação (catch-all) de Debug não inclua logs ASP.NET por padrão -->
    <logger name="Microsoft*" finalMinLevel="Warn" writeTo="ColoredConsole" />
    <logger name="Microsoft.Hosting.Lifetime*" finalMinLevel="Info" writeTo="ColoredConsole" />
    <logger name="System*" finalMinLevel="Warn" writeTo="ColoredConsole" />

    <logger name="*" minlevel="Debug" writeTo="ColoredConsole" />

    <!-- As entradas a seguir especificam o registro ASP.NET (IPC), as declaramos para que nosso último ponto de verificação (catch-all) de Debug não inclua logs ASP.NET por padrão -->
    <logger name="Microsoft*" finalMinLevel="Warn" writeTo="File" />
    <logger name="Microsoft.Hosting.Lifetime*" finalMinLevel="Info" writeTo="File" />
    <logger name="System*" finalMinLevel="Warn" writeTo="File" />

    <logger name="*" minlevel="Debug" writeTo="File" />

    <!-- A seguir se torna ativo quando a interface IPC do ASF é habilitada -->
    <!-- As entradas a seguir especificam o registro ASP.NET (IPC), as declaramos para que nosso último ponto de verificação (catch-all) de Debug não inclua logs ASP.NET por padrão -->
    <logger name="Microsoft*" finalMinLevel="Warn" writeTo="History" />
    <logger name="Microsoft.Hosting.Lifetime*" finalMinLevel="Info" writeTo="History" />
    <logger name="System*" finalMinLevel="Warn" writeTo="History" />

    <logger name="*" minlevel="Debug" writeTo="History" />
  </rules>
</nlog>
```

---

## Integração do ASF

O ASF inclui alguns truques legais de código que melhoram sua integração com o NLog, permitindo que você capture mensagens específicas mais facilmente.

A variável `${logger}` específica do NLog vai sempre distinguir a fonte da mensagem - será sempre o `BotName` de um dos seus bots, ou `ASF` se a mensagem vier diretamente do processo do ASF. Assim você pode capturar facilmente mensagens de bots individuais ou (apenas) do processo do ASF, em vez de todas de uma vez, com base no nome dessa variável.

O ASF tenta marcar as mensagens adequadamente com base nos níveis de registro fornecidos pelo NLog, o que torna possível capturar apenas mensagens específicas de níveis de log específicos, em vez de todas elas. Claro, o nível de registro de uma mensagem específica não pode ser personalizado, uma vez que é uma decisão codificada no ASF a seriedade de determinada mensagem, mas você pode tornar o ASF menos/mais silencioso conforme achar necessário.

O ASF registra informações extras, tais como mensagens de usuário/conversa no nível de log `Trace`. O registro padrão do ASF registra apenas o nível `Debug` e acima, que esconde essa informação extra, já que ela não é necessária para a maioria dos usuários, além de atravancar a saída contendo potencialmente mensagens mais importantes. Você pode no entanto fazer uso dessa informação reabilitando o nível de log `Trace`, especialmente em combinação com registrar apenas um bot específico, com o evento que você está interessado.

Em geral, o ASF tenta torná-lo tão fácil e conveniente para você quanto possível, registrando apenas as mensagens que você quer ao invés de forçá-lo a filtrá-las manualmente com alguma ferramenta de terceiros, tal como `grep` e semelhantes. Basta configurar o NLog corretamente conforme descrito abaixo, e você deverá ser capaz de especificar até mesmo regras complexas de registro com destinos personalizados como bancos de dados inteiros.

Em relação a versão o ASF tenta sempre ser fornecido com a versão mais atualizada do NLog disponível na **[NuGet](https://www.nuget.org/packages/NLog)** na data do lançamento do ASF. Não deve ser um problema usar qualquer recurso que você possa encontrar na Wiki do NLog no ASF - apenas certifique-se de que está usando o ASF atualizado.

Como parte da integração, o ASF também inclui suporte para destinos de registros NLog adicionais, que serão explicados abaixo.

---

## Exemplos

Vamos começar com algo fácil. Nós usaremos apenas o alvo **[ColoredConsole](https://github.com/nlog/nlog/wiki/ColoredConsole-target)**. Nosso arquivo `NLog.config` inicial ficará assim:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" />
  </targets>

  <rules>
    <logger name="*" minlevel="Debug" writeTo="ColoredConsole" />
  </rules>
</nlog>
```

A explicação da configuração acima é bastante simples - definimos um **alvo de registro** (na tag `target`) que é `ColoredConsole`, então nós redirecionamos **todos os registros** (`*`) de nível `Debug` e superior ao alvo `ColoredConsole` que havíamos definido anteriormente. É isso.

Se você iniciar o ASF com o arquivo `NLog.config` acima, apenas o alvo `ColoredConsole` estará ativo e o ASF não vai gravar nada no arquivo (`File`), independentemente da configuração de NLog copificada no ASF.

Agora vamos dizer que não gostamos do formato padrão `${longdate}|${level:uppercase=true}|${logger}|${message}` e queremos registrar apenas as mensagens. Podemos fazê-lo, modificando o **[Layout](https://github.com/nlog/nlog/wiki/Layouts)** do nosso alvo.

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" layout="${message}" />
  </targets>

  <rules>
    <logger name="*" minlevel="Debug" writeTo="ColoredConsole" />
  </rules>
</nlog>
```

Se você abrir o ASF agora, você perceberá que a data, o nível e o nome do agente de registro desapareceram, deixando apenas as mensagens do ASF no formato: `Function() Message`.

Também podemos modificar a configuração de log para mais de um alvo. Vamos registrar no `ColoredConsole` e no **[arquivo](https://github.com/nlog/nlog/wiki/File-target)** ao mesmo tempo:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" />
    <target xsi:type="File" name="File" fileName="${currentdir}/NLog.txt" deleteOldFileOnStartup="true" />
  </targets>

  <rules>
    <logger name="*" minlevel="Debug" writeTo="ColoredConsole" />
    <logger name="*" minlevel="Debug" writeTo="File" />
  </rules>
</nlog>
```

Agora nós registraremos tudo no `ColoredConsole` e `File` (arquivo). Você notou que você também pode especificar o nome do arquivo `fileName` e opções extras?

O ASF usa vários níveis de registro para deixar mais fácil para você entender o que está acontecendo. Podemos usar essas informações para modificar a severidade do registro. Digamos que desejamos registrar tudo (`Trace`) para `Arquivo`, mas apenas mensagens de aviso (`Warning`) e acima do **[nível de log](https://github.com/NLog/NLog/wiki/Configuration-file#log-levels)** no console colorido (`ColoredConsole`). Podemos fazer isso modificando nossas `rules` (regras):

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" />
    <target xsi:type="File" name="File" fileName="${currentdir}/NLog.txt" deleteOldFileOnStartup="true" />
  </targets>

  <rules>
    <logger name="*" minlevel="Warn" writeTo="ColoredConsole" />
    <logger name="*" minlevel="Trace" writeTo="File" />
  </rules>
</nlog>
```

É isso, agora o `ColoredConsole` só vai mostrar os avisos e superiores, enquanto ainda registra tudo no arquivo (`File`). Você pode configurar, por exemplo, para registrar apenas `Info` e acima, e assim por diante.

Por último, vamos fazer algo um pouco mais avançado e registrar todas as mensagens no arquivo, mas apenas do bot chamado `LogBot`.

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" />
    <target xsi:type="File" name="LogBotFile" fileName="${currentdir}/LogBot.txt" deleteOldFileOnStartup="true" />
  </targets>

  <rules>
    <logger name="*" minlevel="Debug" writeTo="ColoredConsole" />
    <logger name="LogBot" minlevel="Trace" writeTo="LogBotFile" />
  </rules>
</nlog>
```

Você pode ver como nós usamos a integração do ASF acima e facilmente distinguimos a fonte da mensagem com base na propriedade `${logger}`.

---

## Uso avançado

Os exemplos acima são um tanto simples e feitos para te mostrar como é fácil de definir suas próprias regras de registro que podem ser usadas com o ASF. Você pode usar o NLog para várias coisas diferentes, incluindo alvos complexos (como manter os registros no Banco de dados (`Database`)), efetuar rotação (como a remoção de arquivos (`File`) de registro antigos), usar `Layout`s personalizados, definir seus próprios filtros `<when>` e muito mais. Eu te encorajo a ler toda a **[documentação do NLog](https://github.com/nlog/nlog/wiki/Configuration-file)** para saber mais sobre cada opção disponível, permitindo que você ajuste o módulo de registro do ASF da forma que quiser. É uma ferramenta muito poderosa e personalizar o registro do ASF nunca foi tão fácil.

---

## Limitações

O ASF desativará temporariamente **todas** as regras que incluem os alvos `ColoredConsole` ou `Console` quando estiver esperando uma entrada do usuário. Portanto, se você quiser manter o registro para outros alvos mesmo quando o ASF esperar por uma entrada do usuário, você deve definir esses alvos com suas próprias regras, como mostrado nos exemplos acima, ao invés de colocar vários alvos com `writeTo` e a mesma regra (a menos que esse seja o comportamento que você espera). A desativação temporária dos alvos do console é feita a fim de manter o console limpo quando estiver esperando por uma entrada do usuário.

---

## Registro do chat

O ASF inclui suporte estendido para o registro do chat, não só gravando todas as mensagens recebidas/enviadas no nível `Trace`, mas também expondo informações adicionais relacionadas a eles nas **[propriedades de evento](https://github.com/NLog/NLog/wiki/EventProperties-Layout-Renderer)**. Isso porque nós precisamos lidar com mensagens do chat como possíveis comandos, então não nos custa nada registrar esses eventos para que seja possível que você adicione alguma lógica extra (como tornar o ASF seu arquivo pessoal de conversas no Steam).

### Propriedades de evento

| Nome        | Descrição                                                                                                                                                                                                                                               |
| ----------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Echo        | Tipo `bool`. Definido como `true` quando a mensagem está sendo enviada de nós para o destinatário e `false` caso contrário.                                                                                                                             |
| Message     | Tipo `string`. Esta é a mensagem enviada/recebida.                                                                                                                                                                                                      |
| ChatGroupID | Tipo `ulong`. Este é o ID do chat de grupo para mensagens enviadas/recebidas. Será `0` quando não for usado nenhum chat de grupo para transmitir esta mensagem.                                                                                         |
| ChatID      | Tipo `ulong`. Este é o ID do canal do `ChatGroupID` para mensagens enviadas/recebidas. Será `0` quando não for usado nenhum chat de grupo para transmitir esta mensagem.                                                                                |
| SteamID     | Tipo `ulong`. Este é o ID do usuário Steam para mensagens enviadas/recebidas. Pode ser `0` quando nenhum usuário em particular está envolvido na transmissão da mensagem (por exemplo, quando nós estamos enviando uma mensagem para um chat em grupo). |

### Exemplo

Este exemplo é baseado em nosso exemplo básico de `ColoredConsole` acima. Antes de tentar compreendê-lo, eu recomendo fortemente dar uma olhada nos **[acima](#exemplos)** para aprender sobre as noções básicas do registro NLog em primeiro lugar.

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" />
    <target xsi:type="File" name="ChatLogFile" fileName="${currentdir}/${event-properties:item=ChatGroupID}-${event-properties:item=ChatID}${when:when='${event-properties:item=ChatGroupID}' == 0:inner=-${event-properties:item=SteamID}}.txt" layout="${date:format=yyyy-MM-dd HH\:mm\:ss} ${event-properties:item=Message} ${when:when='${event-properties:item=Echo}' == true:inner=-&gt;:else=&lt;-} ${event-properties:item=SteamID}" />
  </targets>

  <rules>
    <logger name="*" minlevel="Debug" writeTo="ColoredConsole" />
    <logger name="MainAccount" level="Trace" writeTo="ChatLogFile">
      <filters defaultAction="Log">
        <when condition="not starts-with('${message}','OnIncoming') and not starts-with('${message}','SendMessage')" action="Ignore" />
      </filters>
    </logger>
  </rules>
</nlog>
```

Nós começamos com o nosso exemplo básico de `ColoredConsole` e o estendemos. Primeiro e mais importante, nós preparamos um arquivo de registro de chat permanente para cada canal de grupo e usuário do Steam; isto é possível graças às propriedades extras que o ASF nos mostra de uma maneira elegante. Também decidimos por um layout personalizado que grava apenas a data atual, a mensagem, informação enviada/recebida e o usuário Steam. Por último, habilitamos a nosso regra de registro do chat apenas para o nível `Trace`, somente para o bot `MainAccount` (conta principal) e apenas para funções relacionadas ao registro do chat (`OnIncoming*` que é usado para mensagens recebidas e ecos e `SendMessage*` para mensagens enviadas pelo ASF).

O exemplo acima irá gerar o arquivo `0-0-76561198069026042.txt` ao se comunicar com o **[ArchiBoT](https://steamcommunity.com/profiles/76561198069026042)**:

```text
2018-07-26 01:38:38 how are you doing? -> 76561198069026042
2018-07-26 01:38:38 I'm doing great, how about you? <- 76561198069026042
```

Claro que isto é apenas um exemplo de trabalho com alguns truques agradáveis de layout mostrado de uma maneira prática. Você pode ampliar ainda mais esta ideia para suas próprias necessidades, tais como filtragem extra, ordem personalizada, layout pessoal, gravação apenas de mensagens recebidas e assim por diante.

---

## Alvos do ASF

Além dos alvos padrão de registro do NLog (como `ColoredConsole` e `File`, explicados acima), você também pode usar alvos de registro personalizados do ASF.

Para máxima consistência, a definição de alvos do ASF seguirá a convenção da documentação do NLog.

---

### SteamTarget

Como você pode imaginar, este destino usa as mensagens do chat Steam para registrar mensagens do ASF. Você pode configurá-lo para usar um chat em grupo ou o chat privado. Além de especificar um alvo Steam para suas mensagens, você também pode especificar o `botName` (nome) do bot que deve enviar as mensagens.

Suportado em todos os ambientes utilizados pelo ASF.

---

#### Sintaxe de configuração
```xml
<targets>
  <target type="Steam"
          name="String"
          layout="Layout"
          chatGroupID="Ulong"
          steamID="Ulong"
          botName="Layout" />
</targets>
```

Leia mais sobre como usar o [arquivo de configuração](https://github.com/NLog/NLog/wiki/Configuration-file).

---

#### Parâmetros

##### Opções gerais
_name_ - Nome do alvo.

---

##### Opções de Layout
_layout_ - Texto a ser processado. [Layout](https://github.com/NLog/NLog/wiki/Layouts) requerido. Padrão: `${level:uppercase=true}|${logger}|${message}`

---

##### Opções do SteamTarget

_chatGroupID_ - ID do chat em grupo declarado como um inteiro longo não assinado de 64-bit. Opcional. Padronizado como `0` que vai desabilitar a funcionalidade de chat em grupo e usar o chat privado em seu lugar. Quando habilitado (configurado com valor diferente de 0), a propriedade `steamID` acima age como `chatID` e especifica a ID do canal nesse `chatGroupID` para o qual o bot deve enviar as mensagens.

_steamID_ - SteamID declarado como um inteiro longo não assinado de 64-bit do usuário Steam alvo (como `SteamOwnerID`), ou alvo `chatID` (quando `chatGroupID` estiver definido). Obrigatório. O valor padrão é `0<0>, que desativa inteiramente o registro do alvo.</p>

<p spaces-before="0"><em x-id="4">botName</em> - Nome do bot (como é reconhecido pelo ASF, diferenciando maiúsculas de minúsculas) alvo que estará enviando mensagens para o <code>steamID` declarado acima. Não é obrigatório. O padrão é `null` que selecionará automaticamente **qualquer** bot conectado no momento. É recomendado definir esse valor apropriadamente, já que o `SteamTarget` não leva em conta muitas das limitações do Steam, como o fato de que você deve ter o `steamID` do alvo na sua lista de amigos. Essa variável é definida como tipo [layout](https://github.com/NLog/NLog/wiki/Layouts), portanto você pode usar uma sintaxe especial nela, como `${logger}` para usar o bot que gerou a mensagem.

---

#### Exemplos de StamTarget

Para escrever todas as mensagens do nível `Debug` para cima, do bot chamado `MyBot` para o steamID `76561198006963719`, você deve usar o `NLog.config` semelhante ao exemplo abaixo:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target type="Steam" name="Steam" steamID="76561198006963719" botName="MyBot" />
  </targets>

  <rules>
    <logger name="*" minlevel="Debug" writeTo="Steam" />
  </rules>
</nlog>
```

**Observação:** Nosso `SteamTarget` é um alvo personalizado, então você deve ter certeza de que você o está declarando como `type="Steam"`, e NÃO `xsi:type="Steam"`, já que xsi é reservado para alvos oficiais suportados pelo NLog.

Quando você abrir o ASF com o arquivo `NLog.config` similar ao exemplo acima, o `MyBot` vai começar a enviar mensagens para o usuário Steam `76561198006963719` com todas as mensagens do registro do ASF. Tenha em mente que `MyBot` deve estar conectado para enviar mensagens, então todas as mensagens que ocorrerem antes que nosso bot se conectasse à Rede Steam não serão enviadas.

Claro, `SteamTarget` tem todas as funções típicas que você poderia esperar do `TargetWithLayout` genérico, então você pode usá-lo em conjunto, por exemplo, com layouts personalizados, nomes ou regras personalizadas de registro. O exemplo acima é apenas o mais básico.

---

#### Capturas de tela

![Captura da tela](https://i.imgur.com/5juKHMt.png)

---

### HistoryTarget

Este alvo é usado internamente pelo ASF para fornecer um histórico de registro de tamanho fixo no endpoint `/Api/NLog` do **[ASF API](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-pt-BR#asf-api)** que depois pode ser usado pela ASF-ui e outras ferramentas. Em geral você deve definir esse alvo somente se você já estiver usando uma configuração personalizada do NLog para outras personalizações e também quer que ele seja exposto na API do ASF, como a ASF-ui, por exemplo. Ele também pode ser declarado quando você quiser modificar o layout padrão ou a `maxCount` (contagem máxima) de mensagens salvas.

Suportado em todos os ambientes utilizados pelo ASF.

---

#### Sintaxe de configuração
```xml
<targets>
  <target type="History"
          name="String"
          layout="Layout"
          maxCount="Byte" />
</targets>
```

Leia mais sobre como usar o [arquivo de configuração](https://github.com/NLog/NLog/wiki/Configuration-file).

---

#### Parâmetros

##### Opções gerais
_name_ - Nome do alvo.

---

##### Opções de Layout
_layout_ - Texto a ser processado. [Layout](https://github.com/NLog/NLog/wiki/Layouts) requerido. Padrão: `${date:format=yyyy-MM-dd HH\:mm\:ss}|${processname}-${processid}|${level:uppercase=true}|${logger}|${message}${onexception:inner= ${exception:format=toString,Data}}`

---

##### Opções do HistoryTarget

_maxCount_ - Montante máximo de registros armazenados pela histórico sob demanda. Opcional. O padrão é `20` que é um bom equilíbrio para fornecer um histórico inicial, enquanto leva em conta o uso de memória quanto a requisitos de armazenamento. Deve ser maior que `0`.

---

## Ressalvas

Tenha cuidado quando você decidir combinar o nível de registro `Debug` ou abaixo em seu `SteamTarget` com um `steamID` que participa no processo do ASF. Isso pode levar a uma potencial `StackOverflowException`, pois você vai criar um loop infinito: o ASF receberá a mensagem e a enviará ao registro através do Steam, resultando em outra mensagem recebida que necessita ser registrada. Atualmente a única forma disso ocorrer é registrar no nível `Trace` (onde o ASF grava suas próprias mensagens no chat), ou no nível `Debug` enquanto roda o ASF no modo `Debug` (onde o ASF grava todos os pacotes Steam).

Em suma, se o seu `steamID` participa do mesmo processo do ASF, então o nível de registro `minlevel` do seu `SteamTarget` deve ser `Info` (ou `Debug` se você não estiver rodando o ASF também em modo `Debug`) e acima. Como alternativa você pode definir seus próprios filtros de registro `<when>` para evitar um loop infinito se modificar o nível não é apropriado ao seu caso. Essa ressalva também se aplica a chats em grupo.