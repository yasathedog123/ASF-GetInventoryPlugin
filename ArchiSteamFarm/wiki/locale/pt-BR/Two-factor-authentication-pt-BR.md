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
2. Opcionalmente, adicione um número de telefone que seja válido para a conta **[aqui](https://store.steampowered.com/phone/manage)** para ser usada pelo bot. Isso permitirá que você receba códigos SMS e recupere a sua conta se necessário, mas não é obrigatório.
3. Certifique-se de que você ainda não está usando o 2FA para sua conta, se caso estiver, desative-o primeiro.
4. Execute o comando `2fainit [Bot]`, substituindo `[Bot]` pelo nome do seu bot.

Pressupondo que você tenha recebido uma resposta bem-sucedida, as duas seguintes coisas aconteceram:

- Um novo arquivo `<Bot>.maFile.PENDING` foi gerado pelo ASF no seu diretório `config`.
- Um SMS foi enviado do Steam para o número de telefone que você atribuiu à conta acima. Se você não definiu um número de telefone, então um e-mail será enviado em vez disso para o endereço de e-mail da conta.

Os detalhes do autenticador ainda não estão operacionais, no entanto, você pode revisar o arquivo gerado, se desejar. Se você deseja ter uma camada extra de segurança, você pode, por exemplo, já anotar o código de recuperação. Os próximos passos dependerão do cenário que você selecionou.

### Autenticador independente

Se você deseja usar o ASF como seu autenticador principal (ou até mesmo único), agora você precisa seguir a etapa de finalização:

5. Execute o comando `2fafinalize [Bot] <ActivationCode>`, substituindo `[Bot]` com o seu nome do bot e `<ActivationCode>` com o código que você recebeu através do SMS ou e-mail na etapa anterior.

### Autenticador conjunto

Se você deseja ter o mesmo autenticador tanto no ASF quanto no aplicativo oficial Steam para dispositivos móveis, agora você precisa seguir os próximos passos:

5. Ignore o SMS ou código de e-mail que você recebeu na etapa anterior.
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

O processo de importação requer um autenticador já vinculado e operacional que seja suportado pelo ASF. O ASF atualmente suporta algumas fontes diferentes oficiais e não oficiais de 2FA - Android, SteamDesktopAuthenticator e WinAuth, além do método manual que permite que você forneça as credenciais necessárias por conta própria. Se você ainda não possui um autenticador, precisa escolher um dos aplicativos disponíveis e configurá-lo primeiro. Se você não sabe qual escolher, nós recomendamos o WinAuth, mas qualquer um dos demais vai funcionar corretamente se você seguir as instruções.

Todos os guias a seguir exigem que você já tenha um autenticador **funcionando e operacional** sendo usado com dada ferramenta/aplicativo. ASF 2FA não funcionará corretamente se você importar dados inválidos, portanto, tenha certeza de que seu autenticador funciona corretamente antes de tentar importá-lo. Isso inclui testar e verificar que as seguintes funções de autenticador funcionam corretamente:
- Você consegue gerar tokens e esses tokens são aceitos pelo Steam
- Você pode solicitar confirmações e elas estão chegando no seu autenticador móvel
- Você pode aceitar essas confirmações e elas são devidamente reconhecidas pelo Steam como confirmadas/rejeitadas

Certifique-se de que seu autenticador funciona verificando se as ações acima funcionam - se não funcionarem, então elas também não funcionarão no ASF, você só vai perder tempo e te causar problemas.

---

### Dispositivo Android

Em geral, para importar o autenticador do seu Android você vai precisar de acesso **[root](https://pt.wikipedia.org/wiki/Root_no_Android)**. As instruções abaixo exigem de você um conhecimento razoável no mundo da modificação do Android. Certamente, não vamos explicar cada passo aqui. Visite o **[XDA](https://xdaforums.com)** e outros recursos para informações/ajuda adicionais com o que está descrito abaixo.

Pré-requisitos:
- Instale o **[aplicativo oficial do Steam](https://play.google.com/store/apps/details?id=com.valvesoftware.android.steam.community)** da loja, caso você ainda não tenha.
- Atribua o autenticador à sua conta e certifique-se de que ele funcione - gere tokens válidos e possa aceitar confirmações.

Extração (requer root no seu dispositivo):
- Instale o **[Magisk](https://topjohnwu.github.io/Magisk/install.html)** e ative o Zygisk nas configurações.
- Instale o **[LSPosed](https://github.com/LSPosed/LSPosed?tab=readme-ov-file#install)** (para o Zygisk) e certifique-se que funciona.
- Instale o módulo do LSPosed **[SteamGuardExtractor](https://github.com/hax0r31337/SteamGuardExtractor?tab=readme-ov-file#usage)** e ative-o nas configurações do LSPosed.
- Force o encerramento do aplicativo Steam, em seguida, abra-o novamente; uma **[janela com os detalhes extraídos](https://github.com/JustArchiNET/ArchiSteamFarm/assets/1069029/ab5ab71e-d664-4e49-9eb4-9f4d9ba32aa2)** deve aparecer, clique em copiar.

Agora que você extraiu com sucesso os detalhes necessários, desative o módulo para evitar que a janela apareça toda vez. Em seguida, copie os valores de `shared_secret` e `identity_secret` da conta que você pretende adicionar ao ASF 2FA para um novo arquivo de texto com a seguinte estrutura:

```json
{
  "shared_secret": "STRING",
  "identity_secret": "STRING"
}
```

Substitua cada valor `STRING` com a chave privada apropriada dos detalhes extraídos. Após fazer isso, renomeie o arquivo para `BotName.maFile`, onde `BotName` é o nome do seu bot ao qual está adicionando o ASF 2FA, e coloque-o no diretório `config` do ASF se ainda não o fez. Posteriormente, inicie o ASF - ele deverá detectar o `.maFile` e importá-lo.

```text
[*] INFO: ImportAuthenticator() <1> Convertendo o arquivo .maFile para o formato ASF...
[*] INFO: ImportAuthenticator() <1> Verificação do autenticador móvel concluída com sucesso!
```

Isso é tudo, assumindo que você importou o arquivo correto com os segredos válidos, tudo deve funcionar corretamente, o que você pode verificar usando os comandos `2fa`. Se você cometeu algum erro você pode remover o arquivo `Bot.db` e recomeçar.

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

A partir de agora, todos os comandos `2fa` funcionarão como se fossem chamados pelo seu dispositivo 2FA padrão. Você pode usar tanto o ASF 2FA quanto o autenticador de sua escolha (Android, SDA ou WinAuth) para gerar tokens e aceitar confirmações.

Se você tem um autenticador em seu telefone, você pode, opcionalmente, remover o SteamDesktopAuthenticator e/ou o WinAuth, já que não precisaremos mais deles. No entanto, eu sugiro que você os mantenha para o caso de precisar, para não falar que eles são mais acessíveis que o autenticador normal da steam. Apenas tenha em mente que o ASF 2FA **NÃO** é um autenticador de propósito geral, ele não inclui todos os dados que um autenticador deveria ter, mas um subconjunto limitado do `maFile` original. Não é possível converter o ASF 2FA de volta para o autenticador original; portanto, sempre certifique-se de que você tenha um autenticador de propósito geral ou o `maFile` em outro local, como no WinAuth/SDA ou no seu telefone.

---

## Perguntas frequentes (FAQ)

### Como o ASF faz uso do módulo 2FA?

Se o ASF 2FA estiver disponível, o ASF o usará para confirmação automática de transações que estão sendo enviadas/aceitas pelo ASF. Ele também será capaz de gerar automaticamente tokens 2FA conforme a necessidade, por exemplo para logar. Além disso, o ASF 2FA permite comandos `2fa` para você usar. Isso deve ser tudo por enquanto, se eu não esqueci de nada - basicamente o ASF usa o módulo 2FA conforme necessário.

---

### E se eu precisar de um token 2FA?

Você vai precisar de um token 2FA para acessar uma conta protegida pelo 2FA, que também inclui todas as contas com ASF 2FA. Você deve gerar tokens no autenticador que você usou para a importação, mas você também pode gerar tokens temporários através do comando `2fa` enviado via chat pelo bot escolhido. Você também pode usar o comando `2fa <BotNames>` para gerar um token temporário para a conta bot mencionada. Isso deve ser suficiente para você acessar as contas bot, por exemplo, através do navegador, mas como mencionado acima, é recomendável usar o seu autenticador preferido (Android, SDA ou WinAuth) em vez disso.

---

### Posso usar meu autenticador original depois de importá-lo como ASF 2FA?

Sim, seu autenticador original continua funcional e você pode usá-lo juntamente com o ASF 2FA. Essa é a questão toda do processo - nós estamos importando suas credenciais do autenticador para dentro do ASF, então o ASF pode usá-las e aceitar confirmações selecionadas em seu interesse.

---

### Onde fica salvo o autenticador móvel do ASF?

O autenticador móvel do ASF é salvo no arquivo `NomeDoBot.db` na sua pasta config, juntamente com outros dados cruciais relacionados a conta em questão. Se você deseja remover o ASF 2FA, leia como abaixo.

---

### Como remover o ASF 2FA?

Simplesmente pare o ASF e remova o arquivo `NomeDoBot.db` do bot com o ASF 2FA vinculado que deseja remover. Esta opção irá remover o 2FA associado importado para o ASF, mas NÃO desvinculará seu autenticador. Caso, em vez disso, você queira desvincular o seu autenticador, além de removê-lo do ASF (primeiramente), você deve desvinculá-lo no autenticador de sua escolha (Android, SDA ou WinAuth). Se não for possível por algum motivo, utilize o código de revogação que você recebeu durante a vinculação desse autenticador no site do Steam. Não é possível desvincular seu autenticador através do ASF, para isso você deve usar o próprio autenticador.

---

### Eu vinculei o autenticador ao SDA/WinAuth, em seguida, importei para o ASF. Eu posso desvinculá-lo e vincular novamente ao meu telefone?

**Não**. O ASF **importa** os dados do autenticador para usá-lo. Se você desvincular seu autenticador então você também fará com que o ASF 2FA pare de funcionar, independentemente de você tê-lo removido primeiro como referido na pergunta acima ou não. Se você quiser usar seu autenticador tanto em seu telefone quanto no ASF (e mais, opcionalmente, no SDA/WinAuth), então você precisa **importar** seu autenticador do seu telefone e não criar um novo no SDA/WinAuth. Você só pode ter **um** autenticador vinculado, é por isso que ASF **importa** esse autenticador e seus dados para usá-lo como ASF 2FA - é **o mesmo** autenticador, apenas existindo em dois lugares. Se você decidir desvincular suas credenciais no autenticador móvel - independentemente de qual modo, o ASF 2FA irá parar de funcionar, uma vez que as credenciais do autenticador móvel copiadas anteriormente deixarão de ser válidas. Para usar o ASF 2FA junto com o autenticador no seu telefone, você deve importá-lo do Android, conforme descrito acima.

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
