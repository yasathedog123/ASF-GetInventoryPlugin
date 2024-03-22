# Trocas

O ASF possui suporte não interativo (off-line) para trocas Steam. Tanto receber (aceitar/rejeitar) quanto enviar trocas é uma função disponível de imediato e não requer uma configuração especial, mas obviamente requer uma conta Steam sem restrições (que já tenha gasto 5 dólares na loja). Contas restritas possuem funcionalidades de troca limitadas.

---

## Lógica

O ASF sempre aceitará todas as trocas, independente de quais são os itens, enviadas pelo usuário com acesso `Master` (ou superior) ao bot. Isso permite não apenas pegar facilmente as cartas obtidas pela conta bot como também ajuda a administrar de forma mais fácil os itens que o bot guarda no inventário - incluindo itens de outros jogos (CS:GO por exemplo).

O ASF rejeitará a oferta de troca, independente do conteúdo, de qualquer usuário (não Master) que esteja na lista negra do módulo de trocas. A lista negra é armazenada no banco de dados padrão `BotName.db` e pode ser gerenciada através dos **[comandos](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-pt-BR)** `tb`, `tbadd` e `tbrm`. Isso deve funcionar como um alternativa ao bloqueio de usuário padrão do Steam - use com cautela.

O ASF aceitará todos os `loots` enviados entre os bots, a menos que `TradingPreferences` esteja definido como `DontAcceptBotTrades`. Em resumo, a configuração padrão `None` de `TradingPreferences` fará com que o ASF aceite automaticamente trocas do usuário com acesso `Master` ao bot (como explicado anteriormente), assim como todas as trocas de doação de outros bots que façam parte do processo do ASF. Se você quer desativar trocas de doação de outros bots, então é para isso que `DontAcceptBotTrades` na configuração `TradingPreferences` serve.

Quando você ativa a configuração `AcceptDonations` em `TradingPreferences`, o ASF também aceitará qualquer troca de doação - uma troca na qual a conta bot não vá perder nenhum item. Esta propriedade afeta apenas contas não-bot, uma vez que contas de bot são afetadas por `DontAcceptBotTrades`. `AcceptDonations` permite que você aceite doações facilmente de outras pessoas e também de bots que não estejam conectados ao processo do ASF.

Vale notar que `AcceptDonations` não requer o **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)**, já que não há necessidade de confirmação se não estamos perdendo nenhum item.

Você também pode personalizar a capacidade de trocas do ASF modificando `TradingPreferences` de acordo com o desejado. Uma das principais características do `TradingPreferences` é a opção `SteamTradeMatcher` que faz o ASF usar uma lógica interna para aceitar trocas que te ajudarão a completar insígnias faltantes, o que é especialmente útil em conjunto com a listagem pública do **[ SteamTradeMatcher](https://www.steamtradematcher.com)**, mas também funciona sem ele. Isso é descrito logo abaixo.

---

## `SteamTradeMatcher`

Quando o `SteamTradeMatcher` estiver ativo, o ASF usará um algorítimo um tanto complexo para verificar se a troca passa pelas regras do STM e é pelo menos neutra. A lógica atual é a seguinte:

- Rejeitar a troca se formos perder algo além dos tipos de item especificados em nosso `MatchableTypes`.
- Rejeitar a troca se não vamos receber ao menos a mesma quantidade de itens por jogo, por tipo e por raridade.
- Rejeitar a troca se o usuário pedir por cartas especiais das promoções Steam de verão/inverno, e o mesmo tiver as trocas retidas.
- Rejeitar a troca se o tempo de retenção exceder a propriedade `MaxTradeHoldDuration` da configuração global.
- Rejeitar a troca se não tivermos configurado `MatchEverything`, e a mesma for pior que neutro para nós.
- Aceitar a troca se nós não a rejeitarmos através de qualquer um dos pontos acima.

É bom notar que o ASF também aceita contraproposta - a lógica funcionará corretamente quando o usuário estiver adicionando algo extra para a troca, desde que todas as condições acima forem atendidas.

Os 4 primeiros atributos devem ser óbvios para todos. A última inclui uma lógica para cartas duplicadas que analisa o estado atual do nosso inventário e decide qual é o status da troca.

- A troca é **boa** se aumentar nosso progresso em busca de completar o set. Exemplo: A A (antes) -> A B (depois)
- A troca é **neutra** se nosso progresso em busca de completar o set continuar o mesmo. Exemplo: A B (antes) -> A C (depois)
- A troca é **ruim** se diminuir nosso progresso em busca de completar o set. Exemplo: A C (antes) -> A A (depois)

O STM só opera em trocas boas, o que significa que o usuário que estiver usando o STM para juntar cartas duplicadas deve sempre nos sugerir apenas trocas boas. No entanto, o ASF é liberal, e também aceita trocas neutras, já que nessas trocas não perdemos nada, então não há nenhuma razão para rejeitá-las. Isso é especialmente útil para os seus amigos, uma vez que eles podem trocar suas cartas extras sem usar o STM, contanto que você não esteja perdendo o progresso para completar a insígnia.

Por padrão, o ASF rejeitará trocas ruins - isso é o que você quase sempre vai querer como usuário. No entanto, você tem a opção de permitir `MatchEverything` em sua configuração de `TradingPreferences` para permitir que o ASF aceite tudas as trocas de cartas duplicadas, incluindo as **ruins**. Isso é útil apenas se você deseja executar uma bot de troca 1:1 em sua conta, uma vez que você entenda que ** o ASF não vai mais te ajudar a progredir para conclusão de insígnia e vai te deixar propenso a substituir um set completo por N cartas duplicadas.**. Se você deseja executar intencionalmente um bot de troca que **jamais** deve concluir nenhum conjunto e deve oferecer todo o seu inventário a todos os usuários interessados, então você pode habilitar essa opção.

Independente do que você escolher em `TradingPreferences`, uma troca que está sendo rejeitada pelo ASF não significa que você não pode aceitá-la você mesmo. Se você manteve o valor padrão de `BotBehaviour`, que não inclui `RejectInvalidTrades`, o ASF vai simplesmente ignorar essas trocas, permitindo que você decida se está interessado nelas ou não. O mesmo vale para trocas de itens fora dos cobertos pelo `MatchableTypes`, bem como tudo o resto - o módulo é feito para ajudá-lo a automatizar trocas STM, e não decidir o que é um bom negócio e o que não é. A única exceção esta regra é quando falamos de usuários que você colocou na lista negra do módulo de trocas usando o comando `tbadd` - trocas propostas por esses usuários são imediatamente rejeitadas independentemente das configurações de `BotBehaviour`.

É altamente recomendado usar o **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)** quando você habilitar essa opção, uma vez que esta função perde todo o seu potencial, se você decidir confirmar manualmente cada troca. O `SteamTradeMatcher` funcionará corretamente mesmo sem a capacidade de confirmar as trocas, mas pode gerar atraso de confirmações se você não estiver aceitando-as a tempo.