# Desempenho

O principal objetivo do ASF é coletar cartas da forma mais eficiente possível, baseado em dois tipos de dados com os quais ele pode operar: um pequeno conjunto de dados fornecidos pelo usuário e que são impossíveis que o ASF saiba de outra forma, e uma grande quantidade de dados que podem ser analisados automaticamente pelo ASF.

No modo automático o ASF não permite que você escolha quais jogos que devem ser executados, nem permite que você altere o algoritmo de coleta de cartas. **O ASF sabe melhor do que você o que ele deve fazer e quais decisões ele deve tomar para tornar o processo de coleta o mais rápido possível**. Seu objetivo é definir as propriedades de configuração corretamente já que ASF não pode adivinhá-las por conta própria, todo o resto é oculto.

---

Há algum tempo a Valve mudou o algoritmo de recebimento de cartas. Desse ponto em diante, nós podemos dividir as contas do Steam em duas categorias: aquelas **com** recebimento de cartas restito e aquelas **sem**. A única diferença entre esses dois tipos é o fato de que as contas com restrição não recebem nenhuma carta de determinado jogo até que ele seja jogado por, no mínimo, `X` horas. Parece que contas mais antigas que nunca pediram reembolso têm **a coleta de cartas irrestrita**, enquanto novas contas e aqueles que pediram reembolso têm **a restrição**. No entanto isso é apenas uma teoria e não deve ser tomada como regra. É por isso que **não há uma resposta óbvia**, e o ASF depende de **você** dizer qual o caso da sua conta.

---

O ASF possui atualmente dois algorítimos de coleta:

O algorítimo **Simple** funciona melhor para contas que não tem restrição no recebimento de cartas. Este é o algoritmo padrão usado pelo ASF. O bot encontra jogos para coletar e os executa um por um até que todas as cartas sejam recebidas. Isso porque a taxa de obtenção de cartas quando se coleta de mais de um jogo ao mesmo tempo é próxima a zero e totalmente ineficaz.

O **Complex** é um algoritmo novo que foi implementado para ajudar contas restritas a maximizar seus lucros. O ASF usará primeiro o algoritmo padrão **simples** em todos os jogos que já tem mais horas de jogo do que a definida em `HoursUntilCardDrops`, então, se não houver mais jogos com o número de horas maior ou igual a `HoursUntilCardDrops` ele rodará todos os jogos (`32` no máximo) com o número de horas menor que `HoursUntilCardDrops` ao mesmo tempo, até que qualquer um deles atinja o valor de `HoursUntilCardDrops` em horas, aí o ASF vai continuar o loop do início (usar o algorítimo **Simple** naquele jogo, voltar a rodar simultaneamente até algum jogo ter mais horas que `HoursUntilCardDrops` e assim por diante). Podemos rodar vários jogos neste caso para aumentar as horas dos jogos que precisamos coletar até que eles atinjam o valor necessário. Tenha em mente que durante a "coleta de horas" o ASF **não** coleta cartas, portanto ele também não vai verificar por recebimento de cartas durante esse período (pelas razões citadas acima).

Atualmente, o ASF escolhe o algoritmo de coleta baseado puramente no parâmetro de configuração `HoursUntilCardDrops` (que é definida por **você**). Se `HoursUntilCardDrops` estiver definido como `0`, o algorítimo **Simple** será usado, caso contrário, **Complex** será escolhido. - configurado para aumentar o tempo de jogo em todos os jogos até que atinja a quantidade de horas necessárias antes de coletá-los para obter drop de cartas.

---

### **Não há resposta óbvia sobre qual algorítimo é melhor para você**.

Esta é uma das razões pela qual você não escolhe o algorítimo de coleta, em vez disso, você diz ao ASF se sua conta tem resrições no recebimento de cartas ou não. Se ela não tiver, o algorítimo **Simple** será o **melhor**, já que não perderemos tempo fazendo todos os jogos terem `X` horas jogadas - a taxa de recebimento de cartas quando se coleta de vários jogos ao mesmo tempo é tende a 0%. On the other hand, if your account has card drops restricted, **Complex** algorithm will be better for you, as there's no point in farming solo if game didn't reach `HoursUntilCardDrops` hours yet - so we'll farm **playtime** first, **then** cards in solo mode.

Não defina cegamente `HoursUntilCardDrops` só porque alguém te disse para fazer - faça testes, compare resultados e, com base nos dados, decida qual opção deve ser melhor para você. Se você colocar um mínimo de esforço nisso, você vai garantir que ASF esteja trabalhando com a máxima eficiência possível na sua conta, que é provavelmente o que você quer já que você está lendo esta página da wiki agora. Se houvesse uma solução que funcione para todos, você não teria uma escolha, o ASF decidiria por conta própria.

---

### Qual é a melhor maneira de descobrir se sua conta é restrita?

Certifique-se que você tenha alguns jogos com **nenhum tempo de jogo registrado** para coletar, preferencialmente 5+, e que execute o ASF com `HoursUntilCardDrops` em `0`. Seria uma boa ideia não jogar nada durante o período de coleta para obter resultados mais precisos (melhor rodar o ASF durante a noite). Deixe o ASF fazer o processo de coleta desses 5 jogos e, depois, confira o log para ver os resultados.

O ASF diz claramente quando uma carta para determinado jogo foi recebida. Você está interessado no recebimento mais rápido alcançado pelo ASF. Por exemplo, se sua conta não tiver restrição, então a primeira carta deve aparecer após cerca de 30 minutos de coleta. If you notice **at least one** game that did drop card in those initial 30 minutes, then this is an indicator that your account is **not** restricted and should use `HoursUntilCardDrops` of `0`.

On the other hand, if you notice that **every** game is taking at least `X` amount of hours before it drops its first card, then this is an indicator to you what you should set `HoursUntilCardDrops` to. A maioria (se não todos) dos usuários com restrições precisam de pelo menos `3` horas de tempo de jogo até que as cartas apareçam e esse é o valor padrão da configuração `HoursUntilCardDrops`.

Remember that games can have different drop rate, this is why you should test if your theory is right with **at least** 3 games, preferably 5+ to ensure that you're not running into false results by a coincidence. A card drop of one game in less than an hour is a confirmation that your account **is not** restricted and can use `HoursUntilCardDrops` of `0`, but for confirming that your account **is** restricted, you need at least several games that are not dropping cards until you hit a fixed mark.

É importante notar que no passado `HoursUntilCardDrops` tinha apenas o valor `0` ou `2` e é por isso que o ASF tinha uma propriedade única `CardDropsRestricted` que permitia alternar entre esses dois valores. Com as mudanças recentes constatamos que não só a maioria dos usuários necessitam de `3` horas ao invés de `2`, mas também que `HoursUntilCardDrops` agora é dinâmico e pode atingir qualquer valor baseado na conta.

No fim, claro, a decisão é sua.

E para deixar tudo ainda pior - eu presenciei casos onde as pessoas mudaram de restrito para irrestrito e vice versa - tanto por causa de uma falha no Steam (sim, temos muitas) quanto por alguns ajustes de lógica feitos pela Valve. Então, mesmo que você tenha confirmado se sua conta é restrita (ou não), não acredite que ela permanecerá assim - uma vez que para mudar de irrestrita para restrita basta pedir um reembolso. Se você sentir que o valor definido anteriormente não é mais apropriado, você pode sempre refazer o teste e ajustar de acordo.

---

Por padrão, o ASF assume que `HoursUntilCardDrops` com o valor `3`, já que o efeito negativo de configurar para `3` quando deveria ser menos é menor do que o contrário. This is because of the fact that in the worst possible case we'll waste `3` hours of farming per `32` games, compared to wasting `3` hours of farming per every single game if `HoursUntilCardDrops` was set to `0` by default. No entanto, você ainda deve configurar essa variável de acordo com a sua conta para obter a máxima eficiência, uma vez que o valor padrão é apenas uma hipótese baseado em potenciais inconvenientes e na maioria dos usuários (estamos tentando escolher o "mau menor" por padrão).

No momento os dois algorítimos acima são suficientes para coletar automaticamente da forma mais efetiva em todos os cenários atuais possíveis, portanto não há planejamento de adicionar novos.

É legal notar que o ASF também inclui o modo de coleta manual que pode ser ativado pelo comando `play`. Você pode ler mais sobre isso na seção **[comandos](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-pt-BR)**.

---

## Falhas no Steam

O algoritmo de coleta de cartas nem sempre funciona da maneira que deveria, e é inteiramente possível que várias falhas no Steam aconteçam, tais como cartas recebidas em contas restritas, cartas recebidas quando se fecha/muda o jogo, cartas não recebidas quando se joga um jogo, entre outros.

This section is mainly for people that are wondering why ASF doesn't do **X**, such as rapidly switching games to farm cards faster.

O que é uma **falha no Steam**: uma ação específica que desencadeia um **comportamento indefinido**, que **não é intencional, não é documentado e é considerado uma falha de lógica**. Ele **não confiável por definição**, o que significa que ele não pode ser reproduzido confiantemente em um ambiente de teste limpo e, portanto, codificado sem recorrer a hacks que supõem adivinhar quando a falha está acontecendo e como lutar com/abusar dela. Normalmente essas falhas são temporárias até que os desenvolvedores as corrijam, embora algumas possam passar despercebidas por um longo período de tempo.

Um bom exemplo do que é considerado uma **falha no Steam** é a situação não tão incomum de receber uma carta quando um jogo é fechado, que pode ser usado até certo ponto com a função de trocar jogos do Idle Master.

- **Comportamento indefinido** - não dá para dizer se alguma carta será recebida ou não quando você ativa a falha.
- **Não intencional** - com base em experiências anteriores e no comportamento da Rede Steam que não tem o mesmo comportamento ao enviar uma única solicitação.
- **Não-documentado** - é claramente documentado no site Steam como as cartas são obtidas, e **em todos os lugares** afirma-se claramente que são obtidas **jogando**, e não fechando jogos, conseguindo conquistas, mudando de jogo ou abrindo 32 jogos de uma vez.
- **Considerado uma falha de lógica** - fechar jogos ou trocar entre os jogos abertos não deveria ter relação com o recebimento de cartas, já que a descrição define claramente que elas devem ser recebidas por **tempo gasto no jogo**.
- **Não confiável por definição, não pode ser reproduzido confiantemente** - não funciona para todos, e mesmo que tenha funcionado uma vez para você, pode não funcionar pela segunda vez.

Uma vez que percebemos o que é um erro do Steam e que o fato de recebermos cartas quando um jogo é fechado **é** um deles, nós podemos partir para o segundo ponto: **o ASF não abusa da Rede Steam de forma alguma e faz o possível para se enquadrar no Acordo de Assinatura do Steam, seus protocolos e o que é geralmente aceito**. Sobrecarregar a Rede Steam com constantes pedidos de abertura/fechamento de jogos pode ser considerado um **[Ataque DoS](https://pt.wikipedia.org/wiki/Ataque_de_nega%C3%A7%C3%A3o_de_servi%C3%A7o)** e **viola diretamente [o Código de Conduta On-line do Steam](https://store.steampowered.com/online_conduct/?l=brazilian)**.

> Como um assinante do Steam, você aceita seguir o código de conduta abaixo.
> 
> Você não irá:
> 
> Organizar ataques contra um servidor do Steam ou contra o próprio Steam.

Não importa se você é capaz de provocar uma falha do Steam com outros programas (como o IM), e também não importa se você concorda conosco e considera tal comportamento como um ataque DoS ou não - cabe a Valve julgar isso, mas se considerarmos isso como um comportamento não-intencional de exploração/abuso através de solicitações excessivas para a Rede Steam, então você pode ter certeza de que a Valve terá uma visão semelhante quanto a isso.

O ASF **nunca** vai tirar proveito de falhas no Steam, abusos, hacks ou qualquer outra atividade que nós vemos como **ilegais ou indesejáveis** de acordo com o Acordo de Assinatura do Steam, o Código de Conduta On-line do Steam, ou qualquer outra fonte confiável que poderia indicar que a atividade do ASF é indesejada pela Rede Steam, como descrito na seção **[contribuindo](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/.github/CONTRIBUTING.md)**.

If you want at all cost to risk your Steam account for farming a few cent cards faster than usual, then sadly ASF will never offer something like this in automatic mode, although you still have `play` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** that can be used as a tool for doing whatever you want in terms of Steam network interaction. Não recomendamos aproveitar falhas no Steam e explorá-las para seu ganho próprio - não só com o ASF, mas com qualquer outra ferramenta também. Pois no fim, a conta é sua e é você que escolhe o que quer fazer com ela - só tenha em mente que nós avisamos você.