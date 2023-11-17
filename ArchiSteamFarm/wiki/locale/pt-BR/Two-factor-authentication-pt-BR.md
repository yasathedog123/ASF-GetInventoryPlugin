# Autenticação em duas etapas

O Steam inclui um sistema de autenticação em duas etapas conhecido como "Escrow" que exige detalhes adicionais para várias atividades relacionadas à conta. Você pode ler mais sobre isso **[aqui](https://help.steampowered.com/faqs/view/2E6E-A02C-5581-8904)** e **[aqui](https://help.steampowered.com/faqs/view/34A1-EA3F-83ED-54AB)**. Esta página considera o sistema de autenticação em duas etapas (2FA), assim como nossa solução que se integra a ele, chamada ASF 2FA.

---

# Lógica do ASF

Independentemente de você usar o ASF 2FA ou não, o ASF inclui uma lógica adequada e está plenamente ciente das contas protegidas pelo 2FA padrão. Ele vai te pedir pelos dados necessários quando for preciso (durante o login, por exemplo). No entanto, essas solicitações podem ser automatizadas usando o ASF 2FA, que gerará automaticamente os tokens necessários, poupando o incômodo e permitindo funcionalidades extras (descritas abaixo).

---

# ASF 2FA

O ASF 2FA é um módulo integrado responsável por fornecer recursos de autenticação em duas etapas (2FA) ao processo do ASF, como a geração de tokens e aceitando confirmações. Ele funciona duplicando os detalhes do seu autenticador existente, para que você possa usar seu autenticador atual e o ASF 2FA ao mesmo tempo.

Você pode verificar se sua conta bot já usa o ASF 2FA executando o **[comando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-pt-BR) **`2fa`. A menos que você já tenha importado seu autenticador para o ASF 2FA, todos os comandos padrão de `2fa` não serão executados, o que significa que sua conta não está usando ASF 2FA e, portanto, também não está disponível para recursos avançados do ASF que exigem que o módulo esteja operativo.

---

# Recomendações

Existem muitas maneiras de tornar o ASF 2FA operativo, aqui incluímos nossas recomendações com base na sua situação atual:

- Se você já está usando o SteamDesktopAuthenticator, WinAuth ou qualquer outro aplicativo de terceiros que permite extrair detalhes do 2FA com facilidade, simplesmente **[importe](#importar)** esses detalhes para o ASF.
- Se você está usando o aplicativo oficial e não se importa em redefinir suas credenciais de 2FA, a melhor maneira é desativar o 2FA e, em seguida, **[criar](#criação)** novas credenciais de 2FA usando o **[autenticador conjunto](#Autenticador-conjunto)**, o que permitirá que você use o aplicativo oficial e o ASF 2FA. Este método não requer acesso root nem conhecimentos avançados, basta seguir as instruções.
- Se você está usando o aplicativo oficial e não deseja recriar suas credenciais de 2FA, suas opções são muito limitadas. Geralmente, você precisará de acesso root e realizar procedimentos adicionais para **[importar](#importar)** esses detalhes, e mesmo assim, pode ser impossível.
- Se você ainda não está usando 2FA e não se importa, você pode usar o ASF 2FA com um **[autenticador independente](#autenticador-independente)**, um aplicativo de terceiros que possa **[duplicar](#importar)** para o ASF (recomendação #1), ou um **[autenticador conjunto](#autenticador-conjunto)** com o aplicativo oficial (recomendação #2).

Abaixo, discutimos todas as opções possíveis e os métodos que conhecemos.

---

## Criação

Em geral, recomendamos fortemente **[duplicar](#importar)** seu autenticador existente, pois esse é o principal propósito para o qual o ASF 2FA foi projetado. No entanto, o ASF vem com um **[plugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins-pt-BR)** oficial `MobileAuthenticator` que estende ainda mais o ASF 2FA, permitindo que você vincule um autenticador completamente novo também. Isso pode ser útil no caso de você não conseguir ou não desejar usar outras ferramentas e não se importar de que o ASF 2FA se torne o seu autenticador principal (e talvez único).

Existem dois cenários possíveis para adicionar um autenticador em duas etapas com o **[plugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins-pt-BR)** `MobileAuthenticator`: independente ou em conjunto com o aplicativo oficial Steam para dispositivos móveis. No segundo cenário, você terá o mesmo autenticador tanto no ASF quanto no aplicativo móvel; ambos gerarão os mesmos códigos e ambos serão capazes de confirmar propostas de troca, transações no Mercado da Comunidade Steam, etc.

### Etapas em comum para ambos os cenários

Independentemente de você planejar usar o ASF como seu único autenticador ou desejar o mesmo autenticador no aplicativo oficial Steam para dispositivos móveis, você precisa seguir estas etapas de inicialização:

1. Crie um bot ASF para a conta desejada, inicie-o e faça login, o que provavelmente você já fez.
2. Adicione um número de telefone funcional e operacional à conta **[aqui](https://store.steampowered.com/phone/manage)** para ser usado pelo bot. Um número de telefone é absolutamente necessário, pois não há como adicionar o 2FA sem ele.
3. Certifique-se de que você ainda não está usando o 2FA para sua conta, se caso estiver, desative-o primeiro.
4. Execute o comando `2fainit [Bot]`, substituindo `[Bot]` pelo nome do seu bot.

Pressupondo que você tenha recebido uma resposta bem-sucedida, as duas seguintes coisas aconteceram:

- Um novo arquivo `<Bot>.maFile.PENDING` foi gerado pelo ASF no seu diretório `config`.
- Um SMS foi enviado do Steam para o número de telefone que você atribuiu à conta acima.

Os detalhes do autenticador ainda não estão operacionais, no entanto, você pode revisar o arquivo gerado, se desejar. Se você deseja ter uma camada extra de segurança, você pode, por exemplo, já anotar o código de recuperação. Os próximos passos dependerão do cenário que você selecionou.

### Autenticador independente

Se você deseja usar o ASF como seu autenticador principal (ou até mesmo único), agora você precisa seguir a etapa de finalização:

5. Execute o comando `2fafinalize [Bot] <ActivationCode>`, substituindo `[Bot]` pelo nome do seu bot e `<ActivationCode>` pelo código que você recebeu via SMS na etapa anterior.

### Autenticador conjunto

Se você deseja ter o mesmo autenticador tanto no ASF quanto no aplicativo oficial Steam para dispositivos móveis, agora você precisa seguir os próximos passos:

5. Ignore o SMS que você recebeu após a etapa anterior.
6. Instale o aplicativo móvel do Steam caso você ainda não o tenha instalado e inicie-o. Vá até a aba do Steam Guard e adicione um novo autenticador seguindo as etapas do próprio aplicativo.
7. Após seu autenticador no aplicativo móvel ser adicionado e estiver funcionando, retorne ao ASF. Agora você precisa informar ao ASF que a finalização foi concluída com a ajuda de um dos dois comandos abaixo:
 - Aguarde até que o próximo código 2FA seja exibido no aplicativo móvel Steam e use o comando `2fafinalized [Bot] <2fa_code_from_app>`, substituindo `[Bot]` pelo nome do seu bot e `<2fa_code_from_app>` pelo código que você está vendo atualmente no aplicativo móvel Steam. Se o código gerado pelo ASF e o código que você forneceu forem os mesmos, o ASF assume que um autenticador foi adicionado corretamente e prossegue com a importação do autenticador recém-criado.
 - Recomendamos fortemente que faça a etapa acima para garantir que suas credenciais sejam válidas. No entanto, se você não deseja (ou não pode) verificar se os códigos são os mesmos e sabe o que está fazendo, você pode usar em vez disso o comando `2fafinalizedforce [Bot]`, substituindo `[Bot]` pelo nome do seu bot. O ASF assumirá que o autenticador foi adicionado corretamente e prosseguirá com a importação do seu autenticador recém-criado.

### Após a finalização

Assumindo que tudo funcionou corretamente, o arquivo `<Bot>.maFile.PENDING` gerado anteriormente foi renomeado para `<Bot>.maFile.NEW`. Isso indica que suas credenciais de 2FA agora estão válidas e ativas. Recomendamos que você crie uma cópia desse arquivo e o mantenha em **um local seguro**. Além disso, recomendamos que você abra o arquivo em seu editor de escolha e anote o `revocation_code`, o que permitirá, como o nome sugere, remover o autenticador caso você o perca.

Em relação aos detalhes técnicos, o arquivo `maFile` gerado inclui todos os detalhes que recebemos do servidor do Steam durante a vinculação do autenticador, e além disso, o campo `device_id`, que pode ser necessário para outros autenticadores. O arquivo é totalmente compatível com o **[SDA](#steamdesktopauthenticator)** para importação.

O ASF importa automaticamente o seu autenticador assim que o procedimento estiver concluído, e, portanto, os comandos `2fa` e outros relacionados agora devem estar operacionais para a conta do bot à qual você vinculou o autenticador.

---

## Importar

O processo de importação requer um autenticador já vinculado e operacional que seja suportado pelo ASF. Atualmente, o ASF oferece suporte a algumas fontes oficiais e não oficiais de 2FA - Android, iOS, SteamDesktopAuthenticator e WinAuth, além do método manual que permite que você forneça as credenciais necessárias. Se você ainda não possui um autenticador, precisa escolher um dos aplicativos disponíveis e configurá-lo primeiro. Se você não sabe qual escolher, nós recomendamos o WinAuth, mas qualquer um dos demais vai funcionar corretamente se você seguir as instruções.

Todos os guias a seguir exigem que você já tenha um autenticador **funcionando e operacional** sendo usado com dada ferramenta/aplicativo. ASF 2FA não funcionará corretamente se você importar dados inválidos, portanto, tenha certeza de que seu autenticador funciona corretamente antes de tentar importá-lo. Isso inclui testar e verificar que as seguintes funções de autenticador funcionam corretamente:
- Você consegue gerar tokens e esses tokens são aceitos pelo Steam
- Você pode solicitar confirmações e elas estão chegando no seu autenticador móvel
- Você pode aceitar essas confirmações e elas são devidamente reconhecidas pelo Steam como confirmadas/rejeitadas

Certifique-se de que seu autenticador funciona verificando se as ações acima funcionam - se não funcionarem, então elas também não funcionarão no ASF, você só vai perder tempo e te causar problemas.

---

### Dispositivo Android

**As instruções a seguir se aplicam ao aplicativo Steam na versão `2.X`, atualmente, existem **[recursos](https://github.com/JustArchiNET/ArchiSteamFarm/discussions/2786)** limitados para extrair os detalhes necessários a partir da versão `3.0` em diante. Vamos atualizar esta seção assim que um método mais acessível for encontrado. Até o presente, uma solução alternativa seria instalar intencionalmente uma versão mais antiga do aplicativo Steam, adicionar o 2FA e extrair os detalhes necessários primeiro, e então, atualizar o aplicativo para a versão mais recente — o autenticador existente continuará funcionando.**

Em geral, para importar o autenticador do seu Android você vai precisar de acesso ao **[root](https://en.wikipedia.org/wiki/Rooting_(Android_OS))**. Fazer o root varia de um dispositivo pra outro, então eu não vou te dizer como fazer no seu aparelho. Visite o **[XDA](https://www.xda-developers.com/root)** para ver excelentes tutoriais sobre como fazer isso, assim como informações gerais sobre como fazer o root. Se você não conseguir encontrar seu dispositivo ou o guia que precisa, tente procurar no google.

Pelo menos oficialmente, não é possível acessar arquivos protegidos do Steam sem root. O único método oficial sem root para extrair arquivos Steam é criando backups não encriptados da pasta `/data` de uma maneira ou outra e buscar manualmente os arquivos certos pelo seu PC, no entanto, como isso depende muito do fabricante do seu telefone e **não é** um padrão do Android, não vamos discuti-lo aqui. Se você tem sorte de ter essa funcionalidade, você pode fazer uso dela, mas a maioria dos usuários não tem algo assim.

De forma não oficial, é possível extrair os arquivos necessários sem acesso root, instalando ou rebaixando seu aplicativo Steam para a versão `2.1` (ou anterior), configurando o autenticador móvel e criando uma imagem do aplicativo (juntamente com os arquivos `data` de que precisamos) por meio do `adb backup`. No entanto, uma vez que é uma grave violação da segurança e uma maneira totalmente não suportada de extrair os arquivos, não vamos falar nada mais sobre isto, a Valve desativou esta falha na segurança em versões mais recentes por uma razão, e apenas a mencionamos como uma possibilidade. Ainda assim, pode ser possível fazer uma instalação limpa dessa versão, vincular um novo autenticador, extrair os arquivos necessários e, em seguida, atualizar o aplicativo, o que deve ser suficiente, mas de qualquer forma, você estará por conta própria com esse método.

Assumindo que você fez o root com sucesso em seu telefone, você deve baixar qualquer explorador de root disponível no mercado, tal como **[esse](https://play.google.com/store/apps/details?id=com.jrummy.root.browserfree)** (ou qualquer outro de sua preferência). Você também pode acessar os arquivos protegidos através do ADB (Android Debug Bridge) ou qualquer outro modo que você prefira, nós vamos fazer isso através do explorador de arquivos, pois é definitivamente o caminho mais fácil de utilizar.

Assim que você abrir seu explorador, navegue até a pasta `/data/data`. Tenha em mente que o diretório `/data/data` é protegido e você não será capaz de acessá-lo sem acesso ao root. Uma vez lá, encontre a pasta `com.valvesoftware.android.steam.community` e copie-a para seu `/sdcard` que aponta para o seu armazenamento interno. Após isso você deverá ser capaz de plugar seu telefone ao seu PC e copiar a pasta do seu armazenamento interno facilmente. Se por qualquer motivo a pasta não estiver visível apesar de ter certeza que você a copiou no local certo, tente reiniciar o seu telefone.

Agora, você deve escolher se quer importar seu autenticador para o WinAuth primeiro e então para o ASF ou diretamente para o ASF. A primeira opção é mais amigável e permite duplicar seu autenticador para o seu PC, permitindo que você faça confirmações e gere tokens de 3 lugares diferentes - seu celular, seu PC e o ASF. Se você quiser fazer isso, simplesmente abra o WinAuth, adicione um novo autenticador steam e escolha a opção importar do Android, aí siga as instruções acessando os arquivos que você obteve acima. Quando terminar, você pode importar este autenticador do WinAuth para o ASF, como é explicado na seção dedicada ao Winauth logo abaixo.

Se você não deseja ou não precisa usar o WinAuth, basta copiar o arquivo `files/Steamguard-<SteamID>` de nosso diretório protegido, onde `SteamID` é o identificador Steam de 64 bits da conta que deseja adicionar (se for mais de uma, porque se você tiver apenas uma conta, esse será o único arquivo). Você precisa colocar esse arquivo na pasta `config` do ASF. Depois renomeie o arquivo como `NomeDoBot.maFile`, onde `NomeDoBot` é no nome do bot para o qual você está adicionando o ASF 2FA. Após esta etapa, abra o ASF - ele vai reconhecer o `.maFile` e vai importá-lo.

```text
[*] INFO: ImportAuthenticator() <1> Convertendo o arquivo .maFile para o formato ASF...
[*] INFO: ImportAuthenticator() <1> Verificação do autenticador móvel concluída com sucesso!
```

Isso é tudo, assumindo que você importou o arquivo correto com os segredos válidos, tudo deve funcionar corretamente, o que você pode verificar usando os comandos `2fa`. Se você cometeu algum erro você pode remover o arquivo `Bot.db` e recomeçar.

---

### iOS

Para iOS você pode usar o **[ios-steamguard-extractor](https://github.com/CaitSith2/ios-steamguard-extractor)**. Isso é possível graças ao fato de que você pode fazer backups descodificados, colocá-los em seu PC e usar a ferramenta para extrair dados da Steam que seriam impossíveis de se obter de outra forma (ao menos sem desbloqueio, dado a codificação do iOS).

Vá até o **[último lançamento](https://github.com/CaitSith2/ios-steamguard-extractor/releases/latest)** para baixar o programa. Depois que você extrair os dados você pode colocá-los, por exemplo, no WinAuth, em seguida, do WinAuth para o ASF (embora você também possa simplesmente copiar o código json gerado, começando no `{` até o `}` em um arquivo `NomeDoBot.maFile` e prosseguir como de costume). Se você me perguntar, eu recomendo fortemente importar para o WinAuth primeiro, depois certificar-se que tanto gerar tokens como aceitar confirmações estão funcionando corretamente, assim você pode ter certeza que está tudo bem. Se suas credenciais forem inválidas, ASF 2FA não vai funcionar direito, então é muito melhor deixar o passo de importar para o ASF por último.

Para perguntas/problemas, por favor visite **[problemas](https://github.com/CaitSith2/ios-steamguard-extractor/issues)**.

*Tenha em mente que a ferramenta acima não é oficial, você está usando por sua conta e risco. Nós não oferecemos suporte técnico se ela não funcionar corretamente - temos alguns indícios de que ela esteja exportando credenciais 2FA inválidas - verifique se as confirmações funcionam no autenticador, tal qual o WinAuth, antes de importar esses dados para o ASF!*

---

### SteamDesktopAuthenticator

Se você estiver usando seu autenticador no SDA, você deve ter notado que há um arquivo chamado `steamID.maFile` na pasta `maFiles`. Certifique-se de que o `maFile` esteja em formato não criptografado, pois o ASF não pode descriptografar os arquivos SDA - o conteúdo do arquivo não criptografado deve começar com o caractere `{` e terminar com o caractere `}`. Se necessário, você pode remover a criptografia nas configurações do SDA primeiro, e então, ativar novamente quando você terminar. Assim que o arquivo estiver em formato não criptografado, copie-o para o diretório `config` do ASF.

Agora você pode renomear `steamID.maFile` para `BotName.maFile` no diretório de configuração do ASF, onde `BotName` é o nome do seu bot ao qual você está adicionando o ASF 2FA. Como alternativa, você pode deixá-lo como está, o ASF vai selecioná-lo automaticamente após o login. Renomear o arquivo ajuda o ASF, tornando possível usar o ASF 2FA antes de fazer login. Se você não fizer isso, o arquivo só poderá ser reconhecido após o ASF fazer login com sucesso (pois o ASF não sabe o `steamID` de sua conta antes de efetuar o login).

Se você fez tudo corretamente, abra o ASF e você deverá notar:

```text
[*] INFO: ImportAuthenticator() <1> Convertendo o arquivo .maFile para o formato ASF...
[*] INFO: ImportAuthenticator() <1> Verificação do autenticador móvel concluída com sucesso!
```

De agora em diante, seu ASF 2FA deverá estar operacional para esta conta.

---

### WinAuth

Em primeiro lugar, crie um arquivo novo com o nome `NomeDoBot.maFile` na pasta config do ASF, onde `NomeDoBot` é o nome do bot para o qual você está adicionando o ASF 2FA. Lembre-se que ele deve ser `NomeDoBot.maFile` e não `NomeDoBot.maFile.txt`, o Windows gosta de ocultar extensões conhecidas de arquivos por padrão. Se você colocar o nome errado, o arquivo não será selecionado pelo ASF.

Agora inicie o Winauth como de costume. Clique com o botão direito no ícone da steam e selecione "Show SteamGuard and Recovery Code". Então marque "Allow copy". Você vai observar uma estrutura JSON familiar para você na parte inferior da janela, começando com `{`. Copie todo o texto para o arquivo `NomeDoBot.maFile` que você criou na etapa anterior.

Se você fez tudo corretamente, abra o ASF e você deverá notar:

```text
[*] INFO: ImportAuthenticator() <1> Convertendo o arquivo .maFile para o formato ASF...
[*] INFO: ImportAuthenticator() <1> Verificação do autenticador móvel concluída com sucesso!
```

De agora em diante, seu ASF 2FA deverá estar operacional para esta conta.

---

## Pronto

A partir de agora, todos os comandos `2fa` funcionarão como se fossem chamados pelo seu dispositivo 2FA padrão. Você pode usar tanto o ASF 2FA quanto o seu autenticador de escolha (Android, iOS, SDA ou WinAuth) para gerar tokens e aceitar as confirmações.

Se você tem um autenticador em seu telefone, você pode, opcionalmente, remover o SteamDesktopAuthenticator e/ou o WinAuth, já que não precisaremos mais deles. No entanto, eu sugiro que você os mantenha para o caso de precisar, para não falar que eles são mais acessíveis que o autenticador normal da steam. Apenas tenha em mente que o ASF 2FA **NÃO** é um autenticador de propósito geral, ele não inclui todos os dados que um autenticador deveria ter, mas um subconjunto limitado do `maFile` original. Não é possível converter o ASF 2FA de volta para o autenticador original; portanto, sempre certifique-se de que você tenha um autenticador de propósito geral ou o `maFile` em outro local, como no WinAuth/SDA ou no seu telefone.

---

## Perguntas frequentes (FAQ)

### Como o ASF faz uso do módulo 2FA?

Se o ASF 2FA estiver disponível, o ASF o usará para confirmação automática de transações que estão sendo enviadas/aceitas pelo ASF. Ele também será capaz de gerar automaticamente tokens 2FA conforme a necessidade, por exemplo para logar. Além disso, o ASF 2FA permite comandos `2fa` para você usar. Isso deve ser tudo por enquanto, se eu não esqueci de nada - basicamente o ASF usa o módulo 2FA conforme necessário.

---

### E se eu precisar de um token 2FA?

Você vai precisar de um token 2FA para acessar uma conta protegida pelo 2FA, que também inclui todas as contas com ASF 2FA. Você deve gerar tokens no autenticador que você usou para a importação, mas você também pode gerar tokens temporários através do comando `2fa` enviado via chat pelo bot escolhido. Você também pode usar o comando `2fa <BotNames>` para gerar um token temporário para a conta bot mencionada. Isto deve ser suficiente para você acessar contas bot através, por exemplo, do navegador, mas como mencionado acima - você deve usar seu autenticador de costume (Android, iOS, SDA ou WinAuth) em vez disso.

---

### Posso usar meu autenticador original depois de importá-lo como ASF 2FA?

Sim, seu autenticador original continua funcional e você pode usá-lo juntamente com o ASF 2FA. Essa é a questão toda do processo - nós estamos importando suas credenciais do autenticador para dentro do ASF, então o ASF pode usá-las e aceitar confirmações selecionadas em seu interesse.

---

### Onde fica salvo o autenticador móvel do ASF?

O autenticador móvel do ASF é salvo no arquivo `NomeDoBot.db` na sua pasta config, juntamente com outros dados cruciais relacionados a conta em questão. Se você deseja remover o ASF 2FA, leia como abaixo.

---

### Como remover o ASF 2FA?

Simplesmente pare o ASF e remova o arquivo `NomeDoBot.db` do bot com o ASF 2FA vinculado que deseja remover. Esta opção irá remover o 2FA associado importado para o ASF, mas NÃO desvinculará seu autenticador. Se ao invés disso você quiser desvincular seu autenticador, além de removê-lo do ASF (em primeiro lugar), você deve desvinculá-lo no autenticador de sua escolha (Android, iOS, SDA ou WinAuth), ou - se por alguma razão você não puder, use o código de revogação que recebeu durante a vinculação com o autenticador, no site da Steam. Não é possível desvincular seu autenticador através do ASF, para isso você deve usar o próprio autenticador.

---

### Eu vinculei o autenticador ao SDA/WinAuth, em seguida, importei para o ASF. Eu posso desvinculá-lo e vincular novamente ao meu telefone?

**Não**. O ASF **importa** os dados do autenticador para usá-lo. Se você desvincular seu autenticador então você também fará com que o ASF 2FA pare de funcionar, independentemente de você tê-lo removido primeiro como referido na pergunta acima ou não. Se você quiser usar seu autenticador tanto em seu telefone quanto no ASF (e mais, opcionalmente, no SDA/WinAuth), então você precisa **importar** seu autenticador do seu telefone e não criar um novo no SDA/WinAuth. Você só pode ter **um** autenticador vinculado, é por isso que ASF **importa** esse autenticador e seus dados para usá-lo como ASF 2FA - é **o mesmo** autenticador, apenas existindo em dois lugares. Se você decidir desvincular suas credenciais no autenticador móvel - independentemente de qual modo, o ASF 2FA irá parar de funcionar, uma vez que as credenciais do autenticador móvel copiadas anteriormente deixarão de ser válidas. Para utilizar o ASF 2FA juntamente com o autenticador em seu telefone, você deve importá-lo do Android/iOS, como é descrito acima.

---

### Usar o ASF 2FA é melhor que o WinAuth/SDA/Outros configurados para aceitar todas as confirmações?

**Sim**, por vários motivos. Primeiro e mais importante - usar o ASF 2FA **significantemente** aumenta sua segurança, uma vez que o módulo 2FA do ASF assegura que o ASF só aceitará automaticamente suas próprias confirmações, então mesmo que um atacante solicite uma troca prejudicial, o ASF 2FA **não** aceitará tal troca, já que ela não foi gerada pelo ASF. Complementando sobre a questão de segurança, usar o ASF 2FA também traz benefícios de desempenho/otimização, uma vez que ele busca e aceita confirmações imediatamente após serem geradas, e só nessa hora, em vez do método ineficiente de verificações para confirmações a cada X minutos feitos, por exemplo, pelo SDA ou WinAuth. Resumindo, não há necessidade de se usar outros autenticadores além do ASF 2FA, se você planeja usar confirmações automatizadas geradas pelo ASF - isso é exatamente o que o ASF 2FA faz, e usá-lo não entra em conflito com você confirmando tudo o mais no autenticador de sua escolha. Recomendamos fortemente a utilização do ASF 2FA para toda atividade do ASF - isto é muito mais seguro do que qualquer outra solução.

---

## Avançado

Se você for um usuário avançado, você pode gerar o arquivo maFile manualmente. Isso pode ser usado caso você queira importar o autenticador de outras fontes que não as descritas acima. Ele deve ter uma **[estrutura JSON válida](https://jsonlint.com)** de:

```json
{
  "shared_secret": "STRING",
  "identity_secret": "STRING"
}
```

Dados padrão do autenticador tem mais campos - eles são completamente ignorados pelo ASF durante a importação, já que não são necessários. Você não precisa removê-los - o ASF só requer um arquivo JSON válido com os 2 campos obrigatórios descritos anteriormente, e vai ignorar qualquer campo adicional (se existirem). Claro, você precisa substituir o campo `STRING` no exemplo acima com valores válidos para sua conta. Cada `STRING` deve ser uma representação codificada em base64 dos bytes dos quais a chave privada apropriada é composta.
