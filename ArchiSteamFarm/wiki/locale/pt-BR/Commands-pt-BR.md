# Comandos

O ASF suporta uma variedade de comandos, que podem ser usados para controlar o comportamento do processo e dos bots.

Os comandos abaixo podem ser enviados para o bot várias maneiras:
- Através do console interativo do ASF
- Através da conversa privada/em grupo do Steam
- Através da nossa interface **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-pt-BR)**

Tenha em mente que a interação com o ASF requer que você tenha permissão para utilizar os comandos de acordo com as configurações do ASF. Confira os parâmetros de configuração `SteamUserPermissions` e `SteamOwnerID` para obter mais detalhes.

Os comandos executados através do chat Steam são afetados pela **[propriedade de configuração global](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-pt-BR#commandprefix)** `CommandPrefix`, que é `!` por padrão. Isto significa que para executar, por exemplo, o comando `status`, você deve escrever `!status` (ou o `CommandPrefix` configurado de sua escolha). O `CommandPrefix` não é obrigatório ao usar o console ou o IPC e pode ser omitido.

---

### Console interativo

A partir da versão 4.0.0.9, o ASF oferece suporte para o console interativo, desde que você não esteja executando o ASF no modo [**`Headless`**](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#headless). Simplesmente pressione o botão `c` para ativar o modo de comando, digite seu comando e confirme com enter.

![Captura da tela](https://i.imgur.com/bH5Gtjq.png)

---

### Conversa Steam

Você também pode executar o comando para o bot ASF através do chat Steam. Obviamente que você não pode falar diretamente consigo mesmo, então você precisará de pelo menos outra conta bot se você quiser executar comandos para a sua conta principal.

![Captura da tela](https://i.imgur.com/IvFRJ5S.png)

Da mesma forma, você também pode usar o chat em grupo de um determinado Grupo Steam. Tenha em mente que esta opção requer que a propriedade `SteamMasterClanID` esteja definida corretamente, pois nesse caso o bot ouvirá os comandos também no bate-papo em grupo (e até entrará no mesmo, se necessário). Ele também pode ser usado para "falar sozinho" já que não exige uma conta bot dedicada, ao contrário do chat privado. Você pode simplesmente configurar a propriedade `SteamMasterClanID` com o id do seu grupo recém-criado e então se dar acesso através do `SteamOwnerID` ou ` SteamUserPermissions` do seu próprio bot. Desta forma, o bot ASF (você) vai se juntar ao grupo e ao chat do grupo selecionado e atender aos comandos da sua própria conta. Você pode se juntar a esta sala de chat a fim enviar comandos para si mesmo (já que você estará enviando comandos para a sala de bate-papo e o ASF, estando na mesma sala, os receberá, mesmo parecendo que apenas sua conta esteja lá).

Note que enviar um comando para o chat do grupo atua como uma retransmissão. Se você enviar `redeem X` para 3 de seus bots que estejam no chat junto com você, você terá o mesmo resultado que enviar `redeem X` para cada um deles em particular. Na maioria casos, **não é isso que você quer** e, em vez disso, você deve usar um comando que `indica um bot` para **um único bot em uma janela particular**. O ASF suporta chat em grupo, já que em muitos casos isso pode ser uma fonte útil de comunicação com seu único bot, mas você quase nunca deve executar qualquer comando no chat em grupo se tiverem 2 ou mais bots nele, a não ser que você entenda completamente o comportamento do ASF descrito aqui e você, de fato, queira repetir o mesmo comando para todo bot que esteja na mesma conversa.

*E mesmo nesse caso você deve usar o chat privado com a sintaxe `[Bots]`.*

---

### IPC

A forma mais avançada e flexível de executar comandos, perfeito para interação do usuário (ASF-ui), bem como para ferramentas de terceiros ou scripts (API do ASF), requer que o ASF seja executado em modo `IPC` e que um cliente execute os comandos através da interface **[IPC](https://github.com/JustArchi/ArchiSteamFarm/wiki/IPC-pt-BR)**.

![Captura da tela](https://raw.githubusercontent.com/JustArchiNET/ASF-ui/main/.github/previews/commands.png)

---

## Comandos

| Comando                                                              | Permissão de acesso | Descrição                                                                                                                                                                                                                                                                                                                                                                |
| -------------------------------------------------------------------- | ------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| `2fa [Bots]`                                                         | `Master`            | Gera um código **[2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication-pt-BR)** temporário para os bot indicados.                                                                                                                                                                                                                          |
| `2fafinalize [Bots] <ActivationCode>`                          | `Master`            | Finaliza o processo de atribuição de novas credenciais **[2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication-pt-BR#creation)** para as instâncias de bot específicas, usando um código de ativação por SMS.                                                                                                                              |
| `2fafinalized [Bots] <ActivationCode>`                         | `Master`            | Importa credenciais **[2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication-pt-BR#creation)** já finalizadas para as instâncias de bot específicas, usando um token 2FA para verificação.                                                                                                                                                  |
| `2fafinalizedforce [Bots]`                                           | `Master`            | Importa as credenciais **[2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication-pt-BR#creation)** já finalizadas para as instâncias de bot específicas, ignorando a verificação do token 2FA.                                                                                                                                               |
| `2fainit [Bots]`                                                     | `Master`            | Inicia o processo de atribuição de novas credenciais **[ 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication-pt-BR#creation)** para os bots indicados.                                                                                                                                                                                    |
| `2fano [Bots]`                                                       | `Master`            | Nega todas as confirmações **[2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication-pt-BR)** pendentes para os bots indicados.                                                                                                                                                                                                              |
| `2faok [Bots]`                                                       | `Master`            | Aceita todas as confirmações **[2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication-pt-BR)** pendentes para os bots indicados.                                                                                                                                                                                                            |
| `addlicense [Bots] <Licenses>`                                 | `Operator`          | Ativa as licenças indicadas em `licenses`, conforme explicado **[abaixo](#addlicense-adicionar-licenças)**, nos bots indicados (apenas jogos gratuitos).                                                                                                                                                                                                                 |
| `balance [Bots]`                                                     | `Master`            | Mostra o saldo da carteira do bot indicado.                                                                                                                                                                                                                                                                                                                              |
| `bgr [Bots]`                                                         | `Master`            | Mostra a lista do **[BGR](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer)** (ativador de jogos em segundo plano) do bot indicado.                                                                                                                                                                                                         |
| `encrypt <encryptionMethod> <stringToEncrypt>`           | `Owner`             | Criptografa a string usando o método de criptografia padrão - melhor explicado **[abaixo](#comando-encrypt)**.                                                                                                                                                                                                                                                           |
| `exit`                                                               | `Owner`             | Interrompe todo o processo ASF.                                                                                                                                                                                                                                                                                                                                          |
| `farm [Bots]`                                                        | `Master`            | Reinicia o modulo de coleta de cartas para os bots indicados.                                                                                                                                                                                                                                                                                                            |
| `fb [Bots]`                                                          | `Master`            | Lista os apps bloqueados para coleta nos bots indicados.                                                                                                                                                                                                                                                                                                                 |
| `fbadd [Bots] <AppIDs>`                                        | `Master`            | Adiciona os `appIDs` indicados à lista de apps bloqueados para coleta nos bots indicados.                                                                                                                                                                                                                                                                                |
| `fbrm [Bots] <AppIDs>`                                         | `Master`            | Remove os `appIDs` indicados da lista de apps bloqueados para coleta nos bots indicados.                                                                                                                                                                                                                                                                                 |
| `fq [Bots]`                                                          | `Master`            | Mostra a lista de prioridade de coleta dos bots indicados.                                                                                                                                                                                                                                                                                                               |
| `fqadd [Bots] <AppIDs>`                                        | `Master`            | Adiciona os `appIDs` na lista prioritária de coleta nos bots indicados.                                                                                                                                                                                                                                                                                                  |
| `fqrm [Bots] <AppIDs>`                                         | `Master`            | Remove os `appIDs` da lista prioritária de coleta nos bots indicados.                                                                                                                                                                                                                                                                                                    |
| `hash <hashingMethod> <stringToHash>`                    | `Owner`             | Gera uma hash da string usando o método de criptografia padrão - melhor explicado **[abaixo](#comando-hash)**.                                                                                                                                                                                                                                                           |
| `help`                                                               | `FamilySharing`     | Mostra a ajuda (link para esta página).                                                                                                                                                                                                                                                                                                                                  |
| `input [Bots] <Type> <Value>`                            | `Master`            | Define o tipo de entrada indicado com o valor dado nos bots indicados, funciona apenas no modo `Headless` (não-interativo) melhor explicado **[abaixo](#comando-input)**.                                                                                                                                                                                                |
| `level [Bots]`                                                       | `Master`            | Mostra o nível da conta Steam dos bots indicados.                                                                                                                                                                                                                                                                                                                        |
| `loot [Bots]`                                                        | `Master`            | Envia todos itens da comunidade Steam que se enquadram como `LootableTypes` dos bots indicados para o usuário definido como `Master` em `SteamUserPermissions` (com o steamID mais baixo caso haja mais de um).                                                                                                                                                          |
| `loot@ [Bots] <AppIDs>`                                        | `Master`            | Envia todos itens da Comunidade Steam que se enquadram como `LootableTypes`, e cujo `AppIDs` corresponda ao indicado, dos bots indicados para o usuário definido como `Master` em `SteamUserPermissions` (para o de steamID mais baixo caso haja mais de um). Funciona como o oposto de `loot%`.                                                                         |
| `loot% [Bots] <AppIDs>`                                        | `Master`            | Envia todos itens da Comunidade Steam que se enquadram como `LootableTypes`, independentemente de os `AppIDs` corresponderem ou não ao informado, dos bots indicados para o usuário definido como `Master` em `SteamUserPermissions` (para o de steamID mais baixo caso haja mais de um). Funciona como o oposto de `loot@`.                                             |
| `loot^ [Bots] <AppID> <ContextID>`                       | `Master`            | Envia todos itens Steam do `AppID` de `ContextID` indicados dos bots indicados para o usuário definido como `Master` em `SteamUserPermissions` (para o de steamID mais baixo caso haja mais de um).                                                                                                                                                                      |
| `mab [Bots]`                                                         | `Master`            | Lista os aplicativos bloqueados para troca automática em **[`MatchActively`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#matchactively)**.                                                                                                                                                                                                    |
| `mabadd [Bots] <AppIDs>`                                       | `Master`            | Adiciona os `appIDs` à lista de aplicativos bloqueados para troca automática em **[`MatchActively`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#matchactively)**.                                                                                                                                                                             |
| `mabrm [Bots] <AppIDs>`                                        | `Master`            | Remove os `appIDs` à lista de aplicativos bloqueados para troca automática em **[`MatchActively`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#matchactively)**.                                                                                                                                                                               |
| `match [Bots]`                                                       | `Master`            | Comando especial para o **[`ItemsMatcherPlugine`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#matchactively)** que aciona a rotina `MatchActively`.                                                                                                                                                                                           |
| `nickname [Bots] <Nickname>`                                   | `Master`            | Muda o apelido Steam dos bots indicados para o informado em `nickname`.                                                                                                                                                                                                                                                                                                  |
| `owns [Bots] <Games>`                                          | `Operator`          | Verifica se os bots definidos já possuem os jogos (`games`) indicados, conforme explicado **[abaixo](#owns-jogos)**.                                                                                                                                                                                                                                                     |
| `pause [Bots]`                                                       | `Operator`          | Para permanentemente o módulo de coleta automática de cartas dos bots indicados. O ASF não tentará coletar nessa conta durante essa sessão, a menos que você retome manualmente por meio do comando `resume` ou reinicie o processo.                                                                                                                                     |
| `pause~ [Bots]`                                                      | `FamilySharing`     | Para temporariamente o módulo de coleta automática de cartas dos bots indicados. A coleta será retomada automaticamente na próxima vez que você jogar algum jogo ou quando o bot desconectar. Você pode usar o comando `resume` para voltar a coletar.                                                                                                                   |
| `pause& [Bots] <Seconds>`                                  | `Operator`          | Para temporariamente o módulo de coleta automática de cartas dos bots indicados pela quantidade de segundos indicada em `seconds`. Após esse tempo, a coleta automática de carta é retomada automaticamente.                                                                                                                                                             |
| `play [Bots] <AppIDs,GameName>`                                | `Master`            | Muda para o modo de coleta manual: abre o jogo indicado pela `AppIds` no bot indicado, opcionalmente pode-se usar um nome customizado `GameName`. Para que este recurso funcione corretamente, sua conta Steam **deve** possuir uma licença válida para todos os `AppIDs` que você especificar aqui, Isso também inclui jogos F2P. Use `reset` ou `resume` para retomar. |
| `points [Bots]`                                                      | `Master`            | Exibe o número de pontos na **[loja de pontos do Steam](https://store.steampowered.com/points/shop)**.                                                                                                                                                                                                                                                                   |
| `privacy [Bots] <Settings>`                                    | `Master`            | Muda as **[configurações de privacidade do Steam](https://steamcommunity.com/my/edit/settings)** dos bots indicados para as opções selecionadas adequadamente conforme explicado **[abaixo](#configura%C3%A7%C3%B5es-de-privacidade)**.                                                                                                                                  |
| `redeem [Bots] <Keys>`                                         | `Operator`          | Resgata os códigos de produto ou códigos para a Carteira Steam informados na conta dos bots determinados.                                                                                                                                                                                                                                                                |
| `redeem^ [Bots] <Modes> <Keys>`                          | `Operator`          | Resgata os códigos de produto ou códigos para a carteira Steam informados na conta dos bots determinados, utilizando os `modes` (métodos) explicados **[abaixo](#métodos-redeem)**.                                                                                                                                                                                      |
| `reset [Bots]`                                                       | `Master`            | Redefine o status "em jogo" de volta ao estado original (anterior), esse comando é usado durante a coleta manual com o comando `play`.                                                                                                                                                                                                                                   |
| `restart`                                                            | `Owner`             | Reinicia o processo do ASF.                                                                                                                                                                                                                                                                                                                                              |
| `resume [Bots]`                                                      | `FamilySharing`     | Retoma a coleta automática nos bots indicados.                                                                                                                                                                                                                                                                                                                           |
| `start [Bots]`                                                       | `Master`            | Inicia os bots indicados.                                                                                                                                                                                                                                                                                                                                                |
| `stats`                                                              | `Owner`             | Mostra estatísticas do processo, tais como o uso de memória gerenciada.                                                                                                                                                                                                                                                                                                  |
| `status [Bots]`                                                      | `FamilySharing`     | Mostra o estado dos bots indicados.                                                                                                                                                                                                                                                                                                                                      |
| `std`                                                                | `Owner`             | Comando especial para o **[`SteamTokenDumperPlugin`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/SteamTokenDumperPlugin)** que aciona o envio de dados imediatamente.                                                                                                                                                                                            |
| `stop [Bots]`                                                        | `Master`            | Para os bots indicados.                                                                                                                                                                                                                                                                                                                                                  |
| `tb [Bots]`                                                          | `Master`            | Lista os usuários bloqueados no módulo de trocas dos bots indicados.                                                                                                                                                                                                                                                                                                     |
| `tbadd [Bots] <SteamIDs64>`                                    | `Master`            | Bloqueia as `steamIDs` indicadas no módulo de trocas dos bots indicados.                                                                                                                                                                                                                                                                                                 |
| `tbrm [Bots] <SteamIDs64>`                                     | `Master`            | Remove o bloqueio das `steamIDs` indicadas no módulo de trocas dos bots indicados.                                                                                                                                                                                                                                                                                       |
| `transfer [Bots] <TargetBot>`                                  | `Master`            | Envia todos os itens da Comunidade Steam indicados como `TransferableTypes` (tipos transferíveis) do bot indicado para o bot de destino.                                                                                                                                                                                                                                 |
| `transfer@ [Bots] <AppIDs> <TargetBot>`                  | `Master`            | Envia todos os itens da Comunidade Steam indicados como `TransferableTypes` (tipos transferíveis) cujos `AppIDs` coincidam com o indicado, do bot indicado para o bot de destino. Funciona como o oposto de `transfer%`.                                                                                                                                                 |
| `transfer% [Bots] <AppIDs> <TargetBot>`                  | `Master`            | Envia todos os itens da Comunidade Steam indicados como `TransferableTypes` (tipos transferíveis) independentemente de os `AppIDs` coincidirem com o indicado, do bot indicado para o bot de destino. Funciona como o oposto de `transfer@`.                                                                                                                             |
| `transfer^ [Bots] <AppID> <ContextID> <TargetBot>` | `Master`            | Envia todos itens Steam do `AppID` determinado com `ContextID` dos bots indicados para o bot de destino.                                                                                                                                                                                                                                                                 |
| `unpack [Bots]`                                                      | `Master`            | Abre todos os pacotes de cartas armazenados no inventario dos bots indicados.                                                                                                                                                                                                                                                                                            |
| `update [Channel]`                                                   | `Owner`             | Verifica no GitHub novas versões e atualizações do ASF se disponíveis. Isso é feito automaticamente em todo `UpdatePeriod` (período de atualização). O argumento opcional `Channel` especifica o `UpdateChannel`, se não for fornecido, o padrão é aquele definido na configuração global.                                                                               |
| `version`                                                            | `FamilySharing`     | Mostra a versão do ASF.                                                                                                                                                                                                                                                                                                                                                  |

---

### Notas

Todos os comandos não diferenciam maiúsculas de minúsculas, mas seus argumentos (tais como nomes dos bots) geralmente sim.

Os argumentos seguem a filosofia UNIX, colchetes `[Optional]` indicam que o argumento é opcional, enquanto chevrons `<Mandatory>` indicam que o argumento é obrigatório. Você deve substituir os argumentos que deseja declarar, como `[Bots]` ou `<Nickname>` com valores reais com os quais você quer emitir o comando, omitindo os sinais.

O argumento `[Bots]`, conforme indicado pelos colchetes, é opcional em todos os comandos. Quando especificado, o comando é executado no bot indicado. Quando omitido, o comando é executado no bot que recebe o comando. Em outras palavras, `status A` enviado para o bot `B` é o mesmo que enviar `status` para o bot `A`, nesse caso o bot `B` funciona apenas como um proxy. Isso também pode ser usado para enviar comandos para bots que estejam indisponíveis de outra forma, por exempo, para iniciar bots parados, ou executar ações na sua conta principal (que você está utilizando para executar os comandos).

O **acesso** aos comandos se define com, no **mínimo**, `EPermission` em `SteamUserPermissions`, com exceção do `Owner` que tem a `SteamOwnerID` definida no arquivo de configuração global (e é a maior permissão possível).

Múltiplos argumentos, tais como `[Bots]`, `<Keys>` ou `<AppIDs>` significam que o comando suporta diversos argumentos do tipo indicado, separados por vírgula. Por exemplo, `status [Bots]` pode ser usado da seguinte forma: `status MyBot,MyOtherBot,Primary`. Isso fará com que o comando seja executado em **todos os bots de destino** da mesma forma que seria caso você mandasse o comando `status` para cada bot em uma janela separada. Note que não há espaço após a `,` (vírgula).

O ASF usa todos os caracteres em branco, como espaço e quebras de linha, como possíveis delimitadores para um comando. Isto significa que você não precisa usar o espaço para delimitar seus argumentos, você pode usar qualquer outro caractere de espaço em branco (tal como tab ou quebra de linha).

O ASF "combina" os argumentos extras como sendo do tipo múltiplo do último argumento válido. Isso significa que `redeem bot key1 key2 key3` para `redeem [Bots] <Keys>` funcionará exatamente da mesma forma que `redeem bot key1,key2,key3`. Junto com o fato de aceitar a quebra de linha como comando delimitador, isso torna possível que você escreva `redeem bot` e então cole uma lista de códigos de protudos separados por qualquer caractere delimitador aceitável (tal qual a quebra de linha), ou o delimitador padrão do ASF `,`. Tenha em mente que esse truque só pode ser usado nas variantes de comando que usam um grande número de argumentos (então especificar os `[Bots]` é obrigatório nesse caso).

Como você leu acima, um caractere de espaço está sendo usado como um delimitador para um comando, portanto não pode ser usado nos argumentos. No entanto, também como mencionado acima, o ASF pode combinar parâmetros redundantes, o que significa que você pode usar um espaço nos últimos parâmetros definidos para esse comando. Por exemplo, `nickname bob Great Bob` irá definir corretamente o apelido do bot `bob` como "Great Bob". De forma semelhante, você pode verificar nomes que contenham espaços no comando `owns`.

---

Alguns comandos também estão disponíveis com pseudônimos, tanto para economizar na digitação ou para diferentes dialetos:

| Comando      | Pseudônimo   |
| ------------ | ------------ |
| `addlicense` | `addlicence` |
| `owns ASF`   | `oa`         |
| `status ASF` | `sa`         |
| `redeem`     | `r`          |
| `redeem^`    | `r^`         |

---

### Argumento `[Bots]`

O argumento `[Bots]` é uma variante especial de múltiplos argumentos, além de aceitar diversos valores ele também oferece funcionalidades extras.

Em primeiro lugar e mais importante, há uma palavra-chave especial do `ASF` que atua como "todos os bots no processo", então o comando `status ASF` é igual a `status de todos,os,seus,bots,listados,aqui`. Isso também pode ser usado para identificar facilmente os bots que você tem acesso, já que a palavra-chave `ASF`, apesar de se dirigir a todos os bots, resultará em resposta apenas daqueles bots para os quais você pode, de fato, enviar comandos.

O argumento `[Bots]` suporta uma sintaxe de "classe" especial, o que te permite escolher uma série de bots mais facilmente. A sintaxe geral para `[Bots]` nesse caso é `[PrimeiroBot]..[ÚltimoBot]`. Pelo menos um dos argumentos deve ser definido. Ao usar `PrimeiroBot..`, todos os bots a partir de `PrimeiroBot` são afetados. Ao usar `..[ÚltimoBot]`, todos os bots até o `ÚltimoBot` são afetados. Ao usar `[PrimeiroBot]..[ÚltimoBot]`, todos os bots dentro do intervalo do `PrimeiroBot` até o `ÚltimoBot` são afetados. Por exemplo, se você tem bots chamados `A, B, C, D, E, F`, você pode executar `status B..E`, que é igual a `status B, C, D, E`, neste caso. Ao usar essa sintaxe, o ASF usará a ordem alfabética a fim de determinar quais bots estão na classe especificada. Os argumentos devem ser nomes de bots válidos reconhecidos pelo ASF, caso contrário, a sintaxe de intervalo é completamente ignorada.

Além de sintaxe de classe descrita acima, o argumento `[Bots]` também suporta correspondência de **[expressão regular](https://pt.wikipedia.org/wiki/Express%C3%A3o_regular)**. Você pode ativar o padrão de expressão regular usando `r!<Pattern>` como um nome de bot, onde `r!` é o ativador ASF para correspondência de expressão regular e `<Pattern>` é o seu padrão de expressão regular. Um exemplo de comando de bot baseado em expressão regular seria `status r! \d{3}` que enviará o comando `status` para bots que tenham o nome composto por 3 dígitos (por exemplo: `123` e `981`). Sinta-se a vontade para dar uma olhada nos **[documentos](https://docs.microsoft.com/dotnet/standard/base-types/regular-expression-language-quick-reference)** para mais explicações e mais exemplos de padrões de expressão regular disponíveis.

---

## Configurações de `privacidade`

`<Settings>` aceita argumentos com **até 7** opções diferentes, separadas, como de costume, por vírgula, que é o delimitador padrão do ASF. Esses argumentos são, em ordem:

| Argumento | Nome           | Filho de   |
| --------- | -------------- | ---------- |
| 1         | Profile        |            |
| 2         | OwnedGames     | Profile    |
| 3         | Playtime       | OwnedGames |
| 4         | FriendsList    | Profile    |
| 5         | Inventory      | Profile    |
| 6         | InventoryGifts | Inventory  |
| 7         | Comments       | Profile    |

Para a descrição dos campos acima, visite as **[configurações de privacidade do Steam](https://steamcommunity.com/my/edit/settings)**.

Enquanto os valores válidos para todas elas são:

| Valor | Nome          |
| ----- | ------------- |
| 1     | `Private`     |
| 2     | `FriendsOnly` |
| 3     | `Public`      |

Você pode tanto usar um nome que não distingue maiúsculas de minúsculas, quanto um valor numérico. Argumentos que foram omitidos serão definidos por padrão como `Privado`. É importante notar a relação entre argumentos filhos e pais especificados acima, uma vez que um filho nunca pode ter permissão mais ampla que o seu pai. Por exemplo, você **não pode** ter jogos `Públicos` se o seu perfil for `privado`.

### Exemplo

Se você deseja definir **todas as** configurações de privacidade do seu bot chamado `Main` para `Privado`, você pode usar qualquer um comandos abaixo:

```text
privacy Main 1
privacy Main Private
```

Isso acontece porque o ASF assumirá automaticamente todas as outras configurações como sendo `Privada`, então não há nenhuma necessidade de defini-las. Por outro lado, se você gostaria de definir todas as configurações de privacidade para `Público`, então você deve usar qualquer um dos comandos abaixo:

```text
privacy Main 3,3,3,3,3,3,3
privacy Main Public,Public,Public,Public,Public,Public,Public
```

Desta forma você também pode definir opções independentes da forma que preferir:

```text
privacy Main Public,FriendsOnly,Private,Public,Public,Private,Public
```

O comando acima vai definir o perfil como público, jogos na biblioteca como apenas amigos, tempo de jogo como privado, lista de amigos como pública, inventário como público, presentes no inventário como privado e os comentários no perfil como público. Você pode ter o mesmo resultado com valores numéricos, se você quiser.

---

## `addlicense` Adicionar licenças

O comando `addlicense` suporte dois tipos diferentes de licenças:

| Tipo  | Apelido | Exemplo      | Descrição                                                      |
| ----- | ------- | ------------ | -------------------------------------------------------------- |
| `app` | `a`     | `app/292030` | `appID` do jogo desejado.                                      |
| `sub` | `s`     | `sub/47807`  | Pacote contendo um ou mais jogos, determinado por sua `subID`. |

A diferenciação é importante pois o ASF vai usar a Rede Steam para ativar apps, e a Loja Steam para ativar pacotes. Esses dois tipos são incompatíveis, normalmente você usará apps para jogos que ficam gratuitos durante o fim de semana e/ou permanentemente, e pacotes de outra forma.

Recomendamos definir explicitamente o tipo de cada entrada para evitar resultados ambíguos, mas por conta da retrocompatibilidade, se você fornecer um tipo inválido ou omiti-lo completamente, o ASF irá supor que você solicitou pelo `sub`. Você também pode consultar uma ou mais licenças ao mesmo tempo, usando o delimitador padrão do ASF `,`.

Exemplo de comando completo:

```text
addlicense ASF app/292030,sub/47807
```

---

## `owns` jogos

O comando `owns` suporta diversos tipos de argumentos para definir os jogos em `<games>`, tais como:

| Tipo    | Apelido | Exemplo          | Descrição                                                                                                                                                                                                                                                                                                                  |
| ------- | ------- | ---------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `app`   | `a`     | `app/292030`     | `appID` do jogo desejado.                                                                                                                                                                                                                                                                                                  |
| `sub`   | `s`     | `sub/47807`      | Pacote contendo um ou mais jogos, determinado por sua `subID`.                                                                                                                                                                                                                                                             |
| `regex` | `r`     | `regex/^\d{4}:` | **[Regex](https://pt.wikipedia.org/wiki/Express%C3%A3o_regular)** aplicada ao nome do jogo, diferenciando maíusculas de minúsculas. Veja essa **[documentação](https://docs.microsoft.com/pt-br/dotnet/standard/base-types/regular-expression-language-quick-reference)** para entender a sintaxe completa e ver exemplos. |
| `name`  | `n`     | `name/Witcher`   | Parte do nome do jogo, sem diferenciação entre maiúsculas e minúsculas.                                                                                                                                                                                                                                                    |

Recomendamos definir explicitamente o tipo de cada entrada para evitar resultados ambíguos, mas por conta da retrocompatibilidade, se você fornecer um tipo inválido ou omiti-lo completamente, o ASF irá supor que você solicitou o `app` caso sua entrada seja um número ou `name` caso contrário. Você também pode consultar um ou mais dos jogos ao mesmo tempo, usando o delimitador padrão do ASF `,`.

Exemplo de comando completo:

```text
owns ASF app/292030,name/Witcher
```

---

## Métodos `redeem^`

O comando `redeem^`permite que você ajuste os métodos que serão usados em um cenário individual de resgate. Ele funciona como uma substituição temporária do **[parâmetro de configuração do bot](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-pt-BR#configura%C3%A7%C3%A3o-do-bot)** `RedeemingPreferences`.

O argumento `<Modes>` aceita vários valores de métodos, como de costume separados por uma vírgula. Valores disponíveis de métodos são especificados abaixo:

| Valor | Nome                  | Descrição                                                                                |
| ----- | --------------------- | ---------------------------------------------------------------------------------------- |
| FAWK  | ForceAssumeWalletKey  | Força a ativação da preferência de resgate `AssumeWalletKeyOnBadActivationCode`          |
| FD    | ForceDistributing     | Força a ativação da preferência de resgate `Distributing`                                |
| FF    | ForceForwarding       | Força a ativação da preferência de resgate `Forwarding`                                  |
| FKMG  | ForceKeepMissingGames | Força a ativação da preferência de resgate `KeepMissingGames`                            |
| SAWK  | SkipAssumeWalletKey   | Força a desativação da preferência de resgate `AssumeWalletKeyOnBadActivationCode`       |
| SD    | SkipDistributing      | Força a desativação da preferência de resgate `Distributing`                             |
| SF    | SkipForwarding        | Força a desativação da preferência de resgate `Forwarding`                               |
| SI    | SkipInitial           | Pula o resgate de códigos de produto no primeiro bot                                     |
| SKMG  | SkipKeepMissingGames  | Força a desativação da preferência de resgate `KeepMissingGames`                         |
| V     | Validate              | Valida a formatação correta dos códigos de produto e ignora automaticamente os inválidos |

Por exemplo, gostaríamos de resgatar 3 chaves em qualquer um dos nossos bots que ainda não possuem os jogos, mas não nosso bot `primário`. Para isso nós podemos usar:

`redeem^ primary FF,SI key1,key2,key3`

É importante notar que a ativação avançada substitui apenas as `RedeemingPreferences` que você **especificou no comando**. Por exemplo, se você habilitou `Distributing` em `RedeemingPreferences` então não vai ter diferença se você usar o modo `FD` ou não, porque a distribuição já estará ativa de qualquer maneira, devido a `RedeemingPreferences` que você usa. É por esse motivo que cada substituição ativada forçadamente também tem uma desativada, você pode decidir se você quer substituir uma desativada por uma ativada ou vice versa.

---

## Comando `encrypt`

O comando `encrypt` permite que você criptografe sequências arbitrárias osando os métodos	 de criptografia do ASF. O `<encryptionMethod>` deve ser um dos métodos de criptografia especificados e explicados na seção **[segurança](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security-pt-BR)**. Recomendamos usar esse comando através de canais seguros (como o console do ASF ou a interface IPC, que também tem uma API endpoint dedicada a isso), uma vez que detalhes sensíveis podem, de outra forma, serem registrados por vários terceiros (como as mensagens de conversa registradas pelos servidores Steam).

---

## comando `hash`

o comando `hash` permite que você gere hashes de sequências arbitrárias usando os métodos de hashing do ASF. O `<hashingMethod>` deve ser um dos métodos de hash especificados e explicados na seção **[segurança](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security-pt-BR)**. Recomendamos usar esse comando através de canais seguros (como o console do ASF ou a interface IPC, que também tem uma API endpoint dedicada a isso), uma vez que detalhes sensíveis podem, de outra forma, serem registrados por vários terceiros (como as mensagens de conversa registradas pelos servidores Steam).

---

## Comando `input`

O comando `input` só pode ser usado no modo `Headless` (não-interativo) para enviar os dados indicados via **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-pt-BR)** ou chat Steam quando o ASF estiver rodando sem suporte para interação do usuário.

A sintaxe geral é `input [Bots] <Type> <Value>`.

`<Type>` diferencia maiúsculas de minúsculas e define o tipo de entrada reconhecida pelo ASF. Atualmente, o ASF reconhece os seguintes tipos:

| Tipo                    | Descrição                                                                                    |
| ----------------------- | -------------------------------------------------------------------------------------------- |
| Login                   | Propriedade de configuração do bot `SteamLogin`, caso esteja faltando na config.             |
| Password                | Propriedade de configuração do bot `SteamPassword`, caso esteja faltando na config.          |
| SteamGuard              | Código de autenticação enviado para o seu-email se você não estiver usando o 2FA.            |
| SteamParentalCode       | Propriedade de configuração do bot `SteamParentalCode`, caso esteja faltando na config.      |
| TwoFactorAuthentication | Token de 2FA gerado a partir de seu celular, se você estiver usando o 2FA mas não o ASF 2FA. |
| DeviceConfirmation      | Determina se a janela de confirmação para o login foi aceita                                 |

`<Value>` é o valor definido para o tipo indicado. Atualmente, todos os valores são strings.

### Exemplo

Digamos que temos um bot que é protegido pelo SteamGuard no modo não-2FA. Nós vamos querer iniciar esse bot com `Headless` definido como `true`.

Para fazer isso, precisamos executar o seguintes comandos:

`start MySteamGuardBot`-> O bot irá tentar logar, falhar devido a necessidade do AuthCode, e, em seguida, parar devido à execução em modo `Headless`. Precisamos disso para fazer a Rede Steam nos enviar o código de autenticação no e-mail - se não houvesse necessidade disso, pularíamos essa etapa inteiramente.

`input MySteamGuardBot SteamGuard ABCDE` -> Definimos a entrada `SteamGuard` do bot `MySteamGuardBot` para `ABCDE`. Claro, `ABCDE` neste caso é o código de autenticação que recebemos no nosso e-mail.

`start MySteamGuardBot`-> Nós iniciamos nosso bot (parado) novamente, desta vez, ele usa automaticamente o código de autenticação que definimos no comando anterior, ele loga devidamente, limpando-o em seguida.

Da mesma forma, podemos acessar bots protegidos por 2FA (se eles não estiverem usando o ASF 2FA), bem como definir outras propriedades durante tempo de execução.