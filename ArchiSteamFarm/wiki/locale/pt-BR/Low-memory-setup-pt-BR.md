# Configuração para baixo consumo de memória

Isso é exatamente o oposto da **[configuração de alta performance](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/High-performance-setup-pt-BR)** e provavelmente você vai querer seguir essas dicas se você quer diminuir o uso de memória pelo ASF, ao custo de diminuir o desempenho.

---

O ASF é extremamente leve em recursos, dependendo do uso até um VPS de 128MB com Linux é capaz de executá-lo, embora não seja recomendado usar uma configuração tão fraca que pode causar vários problemas. Mesmo sendo leve, o ASF pode pedir mais memória para o sistema operacional se ela for necessária para que o ASF opere com velocidade otimizada.

Como programa, o ASF tenta ser o mais otimizado e eficiente possível, o que também leva em conta os recursos usados durante a execução. Quando se trata de memória, o ASF prefere desempenho em vez de consumo de memória, o que pode acarretar "picos" temporários de memória que podem ser notados, por exemplo, em contas com mais de 3 páginas de insígnias, já que o ASF vai buscar e analisar a primeira página, ler dela o número total de páginas e então lançar uma tarefa de pedido para cada página extra, resultando na busca e análise simultânea das páginas restantes. O uso de memória "extra" (em comparação com o mínimo necessário para a operação) pode acelerar drasticamente a execução e o desempenho global ao custo de um aumento no uso da memória necessária para fazer todas essas coisas em paralelo. Algo semelhante acontece com todas as outras tarefas gerais do ASF que podem ser executadas em paralelo, por exemplo: a analise de ofertas de troca ativas, o ASF pode analisar todas elas ao mesmo tempo pois elas são independentes umas das outras. Além disso, o ASF (tempo de execução C#) **não** vai retornar a memória não utilizada de volta para o sistema operacional imediatamente, o que você pode notar rapidamente percebendo que o processo do ASF vai usando mais e mais memória sem (quase) nunca devolvê-la para o sistema operacional. Algumas pessoas podem achar isso questionável, até mesmo suspeitar de alguma falha na memória, mas não se preocupe, isso é esperado.

O ASF é muito bem otimizado e faz uso dos recursos disponíveis tanto quanto possível. Um alto consumo de memória pelo ASF não significa que ele ativamente **usa** essa memória e **precisa dela**. Muitas vezes o ASF vai manter memória alocada como "espaço" para ações futuras, pois nós podemos aumentar drasticamente o desempenho se não precisarmos pedir ao Sistema Operacional cada pedacinho de memória que venhamos a precisar. O tempo de execução deve liberar automaticamente a memória não utilizada pelo ASF de volta ao sistema operacional quando ele **realmente** precisar. **[Memória não utilizada é memória desperdiçada](https://www.howtogeek.com/128130/htg-explains-why-its-good-that-your-computers-ram-is-full)**. Você terá problemas quando a memória **necessária** for maior que a memória disponível, e não quando o ASF mantiver alguma memória extra alocada com a intenção de acelerar funções que serão executadas em determinado momento. Você tem problemas quando seu kernel do Linux está matando o processo do ASF devido a OOM (falta de memória), não quando você vê o processo do ASF como o usuário principal da memória em `htop`.

O processo de **[coleta de lixo](https://pt.wikipedia.org/wiki/Coletor_de_lixo_(inform%C3%A1tica))** usado no ASF é um mecanismo muito complexo, inteligente o suficiente para levar em consideração não apenas o próprio ASF, mas também seu Sistema Operacional e outros processos. Quando você tem um monte de memória livre, o ASF vai pedir o quanto for necessário para melhorar o desempenho. Isso pode chegar até a 1 GB (com o coletor de lixo de servidor). Quando a memória do sistema operacional estiver quase cheia o ASF automaticamente liberará uma quantidade de volta ao sistema operacional para ajudar a resolver isso, o que pode resultar na diminuição no uso geral de memória pelo ASF para até 50 MB. A diferença entre 50 MB e 1 GB é imensa, mas a diferença também é grande entre um VPS pequeno de 512 MB e um imenso servidor dedicado de 32 GB. Se o ASF puder garantir que essa memória será útil e nada mais precisa dela ao mesmo tempo, ele vai preferir mantê-la e se otimizar automaticamente baseado nas rotinas executadas anteriormente. O coletor de lixo usado no ASF se ajusta automaticamente e obterá melhores resultados quanto mais o processo for executado.

Também é por esse motivo que a memória utilizada no processo do ASF varia de um computador para outro, já que o ASF fará o seu melhor para utilizar os recursos disponíveis **da melhor forma possível** e não de uma forma fixa como era feito na época do Windows XP. A quantidade atual (real) de memória que o ASF está usando pode ser verificado com o **[comando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-pt-BR)** `status`, e geralmente gira em torno de 4 MB para alguns bots ou até 30 MB se você usa coisas como o **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-pt-BR)** e outros recursos avançados. Tenha em mente que memória retornada pelo comando `stats` inclui a memória livre que ainda não foi recuperada pelo coletor de lixo. O resto é memória compartilhada pelo tempo de execução (cerca de 40~50 MB) e o espaço para execução (podem variar). Também é por esse motivo que o mesmo ASF pode usar tão pouca memória quanto 50 MB em um ambiente VPS, enquanto usa até 1 GB em seu desktop. O ASF está ativamente se adaptando ao seu ambiente e tentará encontrar o equilíbrio ideal para não pressionar o seu sistema operacional nem limitar seu desempenho quando você tem um monte de memória não utilizada que pode ser colocado em uso.

---

Claro, existem muitas formas de apontar o ASF na direção certa em termos de quantidade de memória que pretende usar. No geral, se você não precisa disso, é melhor deixar o coletor de lixo trabalhar em paz e fazer o que ele achar melhor. Mas nem sempre isso é possível, por exemplo, se seu servidor Linux também está hospedando vários sites, bancos de dados MySQL e manipuladores PHP, então você realmente não pode permitir que o ASF diminua o uso de memória apenas quando você estiver perto de ficar sem ela, pois geralmente é tarde demais e leva a queda de desempenho. É normalmente nesse caso que você pode estar interessado em uma configuração mais detalhada e, portanto, em ler essa página.

As sugestões abaixo estão divididas em algumas categorias, com dificuldade variada.

---

## Ajuste do ASF (fácil)

As dicas abaixo **não afetam negativamente o desempenho** e podem ser aplicados com segurança a todas as configurações.

- Execute a **[versão genérica](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up-pt-BR#configuração-genérica)** do ASF, se possível. A versão genérica do ASF utiliza menos memória, pois não inclui um tempo de execução interno, não vem como um único arquivo, não precisa se descompactar durante a execução e, portanto, é menor e tem uma pegada de memória menor. Os pacotes de um sistema operacional específicos são práticos e convenientes, mas também estão incluídos com tudo o que é necessário para iniciar o ASF, algo que você pode lidar por conta própria e usar a variante genérica do ASF.
- Nunca execute mais de uma cópia do ASF. O ASF destina-se a lidar com um número ilimitado de bots de uma vez e a menos que você esteja vinculando cada cópia do ASF para diferentes interfaces/endereços de IP, você deve ter exatamente **um** processo do ASF, com vários bots (se necessário).
- Faça o uso de `ShutdownOnFarmingFinished` em `FarmingPreferences`. Um bot ativo ocupa mais recursos que um desativado. Não é um ganho significativo, já que o estado do bot ainda precisa ser mantido, mas você está salvando uma certa quantidade de recursos, especialmente de todos os recursos relacionados à rede, tais como soquetes TCP. Você sempre pode utilizar outros bots, se necessário.
- Mantenha uma quantidade baixa de bots. Um bot sem o parâmetro `Enabled` toma menos recursos, já que o ASF não se preocupa em iniciá-lo. Também tenha em mente que o ASF tem que criar um bot para cada uma das suas configurações, portanto se você não precisa iniciar um bot com o comando `start` e quer salvar alguma memória extra, você pode renomear temporariamente `Bot.json` para, por exemplo, `Bot.json.bak`, para que o ASF não crie um bot inativo no processo. Desta forma você não será capaz de iniciá-lo pelo comando `start` sem renomeá-lo de volta, mas o ASF também não se preocupa em manter o estado deste bot na memória deixando espaço para outras coisas (é um ganho muito pequeno, em 99,9% casos você não deveria se preocupar com isso, só mantér seus bot com o parâmetro `Enabled` com o valor `false`).
- Ajuste suas configurações. Especialmente a configuração global do ASF possui muitas variáveis para ajustar. Por exemplo, ao aumentar `LoginLimiterDelay`, você fará com que seus bots iniciem mais lentamente, permitindo que as instâncias já em execução coletem insígnias enquanto isso, em vez de iniciar os bots mais rapidamente, o que exigiria mais recursos, já que mais bots executarão trabalhos significativos (como análise de insígnias) ao mesmo tempo. Quanto menos trabalho a ser feito ao mesmo tempo - menos memória é usada.

Essas são algumas coisas que você deve ter em mente ao lidar com o uso de memória. No entanto, essas coisas não têm qualquer papel "crucial" no uso de memória, porque o uso de memória vem principalmente de coisas com as quais o ASF tem de lidar e não de estruturas internas, utilizadas para a coleta.

As funções de recursos mais pesadas são:
- Análise da página de insígnias
- Análise do inventário

O que significa que a memória terá os maiores picos quando o ASF fizer a leitura das páginas de insignias, e quando ele está lidando com seu inventário (por exemplo, enviando trocas ou trabalhando com o STM). Isso acontece porque a ASF tem de lidar com uma enorme quantidade de dados - o uso de memória pelo seu navegador quando acessa essas duas páginas não será menor que isso. Desculpe, mas é assim que funciona - diminuir o número de páginas de insígnias e manter um número baixo de itens no seu inventário com certeza pode ajudar.

---

## Ajuste do tempo de execução (avançado)

As dicas abaixo **envolvem diminuição de performance** e devem ser usados com cautela.

A maneira recomendada de aplicar estas configurações é por meio das propriedades de ambiente `DOTNET_`. Claro, você também pode usar outros métodos, p. ex.: `runtimeconfig.json`, mas é impossível definir algumas configurações desta maneira e, além disso, o ASF substituirá o seu arquivo personalizado `runtimeconfig.json` pelo arquivo próprio do ASF, portanto recomendamos propriedades de ambiente que você possa definir facilmente antes de iniciar o processo.

O tempo de execução do .NET permite que você **[ajuste o coletor de lixo](https://docs.microsoft.com/dotnet/core/run-time-config/garbage-collector)** de várias formas, melhorando-o efetivamente conforme as suas necessidades. Nós documentamos abaixo propriedades que são especialmente importantes em nossa opinião.

### [`GCHeapHardLimitPercent`](https://docs.microsoft.com/dotnet/core/run-time-config/garbage-collector#heap-limit-percent)

> Especifica o uso permitido do heap da coleta de lixo (GC) como uma porcentagem da memória física total.

O limite de memória "difícil" para o processo do ASF, essa propriedade liga o Coletor de Lixo para usar apenas um subconjunto de memória total e não tudo. Isso pode se tornar especialmente útil em várias situações semelhantes a servidores, onde você pode dedicar uma porcentagem fixa da memória do seu servidor para o ASF, mas nunca mais do que isso. Esteja ciente que limitar a memória para uso do ASF não fará com que todas as atribuições de memória necessárias desapareçam magicamente, portanto, fixar este valor muito baixo pode resultar em situações de falta de memória, forçando a finalização do processo do ASF.

Por outro lado, definir esse valor alto o suficiente é uma maneira perfeita para garantir que o ASF nunca usará mais memória do que você pode realmente dispor, dando algum espaço para sua máquina respirar mesmo sob carga pesada, enquanto ainda permite que o programa faça seu trabalho eficientemente quando possível.

### [`GCConserveMemory`](https://learn.microsoft.com/dotnet/core/runtime-config/garbage-collector#conserve-memory)

> Configura o coletor de lixo para conservar memória à custa de coletas de lixo mais frequentes e possivelmente tempos de pausa mais longos.

Um valor entre 0-9 pode ser usado. Quanto maior o valor, mais o coletor de lixo otimizará a memória em detrimento do desempenho.

### [`GCHighMemPercent`](https://docs.microsoft.com/dotnet/core/run-time-config/garbage-collector#high-memory-percent)

> Especifica a quantidade de memória usada após a qual a coleta de lixo (GC) se torna mais agressivo.

Essa configuração ajusta o limiar de memória de todo o seu sistema operacional, o qual, quando ultrapassado, faz com que a coleta de lixo (GC) se torne mais agressivo e tente ajudar o sistema operacional a reduzir a carga de memória, executando processos de GC mais intensivos e, como resultado, liberando mais memória livre de volta para o sistema operacional. É uma boa ideia definir essa propriedade para a quantidade máxima de memória (em porcentagem) que você considere "crítica" para o desempenho do SO. O padrão é 90% e vovê vai querer manter entre um intervalo de 80-97%, já que um valor muito baixo causará um agressão desnecessária do Coletor de Lixo e uma queda desnecessária de desempenho, enquanto um valor muito alto colocará uma carga desnecessária no seu SO, considerando que o ASF poderia liberar parte da memória para ajudar.

### **[`GCLatencyLevel`](https://github.com/dotnet/runtime/blob/a1d48d6c00b5aecc063d1a58b0d9281c611ada91/src/coreclr/gc/gcpriv.h#L445-L468)**

> Especifica o nível de latência do coletor de lixo que você deseja otimizar.

Essa é uma propriedade não documentada que funciona excepcionalmente bem, limitando o tamanho das gerações de coleta de lixo e como resultado fazendo o coletor de lixo expurgá-los mais frequentemente e de forma mais agressiva. O nível de latência padrão (equilibrado) é `1`, mas você pode usar `0`, o que otimizará o uso de memória.

### [`gcTrimCommitOnLowMemory`](https://docs.microsoft.com/dotnet/standard/garbage-collection/optimization-for-shared-web-hosting)

> Quando ativo, nós ajustamos a memória alocada de forma mais agressiva para os segmentos de curta duração. Isso é usado para rodar vários processos no servidor, onde há a necessidade do menor uso de memória possível.

Isso oferece pouca melhoria, mas pode tornar o coletor de lixo ainda mais agressivo quando o sistema ficar com pouca memória, especialmente para o ASF que faz bastante uso de tarefas no pool de threads.

---

Você pode habilitar propriedades selecionadas ao definir variáveis de ambiente apropriadas. Por exemplo, no linux (shell):

```shell
# Não se esqueça de ajustar esses valores se você planeja usá-los.
export DOTNET_GCHeapHardLimitPercent=0x4B # 75% como hex
export DOTNET_GCHighMemPercent=0x50 # 80% como hex

export DOTNET_GCConserveMemory=9
export DOTNET_GCLatencyLevel=0
export DOTNET_gcTrimCommitOnLowMemory=1

./ArchiSteamFarm # Para uma build de SO específica
./ArchiSteamFarm.sh # Para uma build genérica
```

Ou no Windows (powershell):

```powershell
# Não se esqueça de ajustar esses valores se você planeja usá-los.
$Env:DOTNET_GCHeapHardLimitPercent=0x4B # 75% como hex
$Env:DOTNET_GCHighMemPercent=0x50 # 80% como hex

$Env:DOTNET_GCConserveMemory=9
$Env:DOTNET_GCLatencyLevel=0
$Env:DOTNET_gcTrimCommitOnLowMemory=1

.\ArchiSteamFarm.exe # Para uma build de SO específica
.\ArchiSteamFarm.cmd # Para uma build genérica
```

`GCLatencyLevel` será especialmente útil, pois verificamos que o tempo de execução de fato otimiza o código para a memória e portanto diminui significativamente o uso de memória, mesmo com o coletor de lixo do servidor. Esse é uma das melhores dicas que você pode aplicar se você deseja diminuir significativamente o uso de memória pelo ASF sem degradar demais o desempenho com `OptimizationMode`.

---

## Ajuste do ASF (intermediário)

As dicas abaixo **envolvem séria diminuição de performance** e devem ser usados com cautela.

- Como um último recurso você pode ajustar o ASF para `MinMemoryUsage` (uso mínimo de memória) através do **[parâmetro de configuração global](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-pt-BR#configura%C3%A7%C3%A3o-global)** `OptimizationMode`. Leia atentamente a sua finalidade, pois se trata de uma queda muito grande de desempenho e resulta em pouquíssimos benefícios de memória. Normalmente essa é **a última coisa que você quer fazer**, depois de ter feitos os **[ajustes do tempo de execução](#ajuste do-tempo-de-execução)** para garantir que você está sendo forçado a fazer isso. A menos que seja absolutamente crítico para a sua configuração, desencorajamos o uso de `MinMemoryUsage`, mesmo em ambientes com restrições de memória.

---

## Otimização recomendada

- Comece com dicas simples de configuração do ASF, use a **[variante genérica do ASF](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up-pt-BR#configuração-genérica)** e verifique se talvez você esteja usando o ASF de maneira inadequada, como iniciando o processo várias vezes para todos os seus bots ou mantendo todos eles ativos se você precisar apenas de um ou dois para iniciar automaticamente.
- Se ainda não for suficiente, ative todas as propriedades de configuração listadas acima, definindo as variáveis de ambiente apropriadas com prefixo `DOTNET_`. Especialmente `GCLatencyLevel`, que oferece melhorias significativas de tempo de execução com pouca queda de desempenho.
- Se mesmo isso não ajudar, como um último recurso defina `MinMemoryUsage` em `OptimizationMode`. Isso força o ASF a executar quase tudo de forma síncrona, fazendo-o trabalhar muito mais devagar, mas também sem depender do pool de threads para equilibrar as coisas quando se trata de execução paralela.

É fisicamente impossível diminuir ainda mais o uso de memória, o ASF já estará com o desempenho seriamente afetado e você sem mais opções, tanto em termos de código quanto em termos de tempo de execução. Considere adicionar mais memória para o ASF usar, até 128MB faria uma grande diferença.