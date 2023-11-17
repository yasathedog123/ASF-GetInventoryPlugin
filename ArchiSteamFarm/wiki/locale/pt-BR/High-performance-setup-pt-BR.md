# Configuração de alto desempenho

Isto é exatamente o oposto da **[configuração de pouca memória](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup-pt-BR)** e provavelmente você vai querer seguir essas dicas se você quer aumentar a performance do ASF (em termos de velocidade da CPU), ao custo de aumentar o uso de memória.

---

O ASF tenta preferir desempenho quando se trata equilíbrio, portanto não há muito que você possa fazer para aumentar sua performance, embora não estejamos totalmente sem opções. No entanto, tenha em mente que essas opções não são habilitadas por padrão, o que significa que elas não são boas o bastante para considerá-las equilibradas para a maioria das situações de uso, portanto você deve decidir por si mesmo se o aumento de memória que elas trazem valem a pena para você.

---

## Ajuste do tempo de execução (avançado)

Os truques abaixo **envolvem um aumento sério de memória e tempo de inicialização** e, portanto, devem ser usados ​​com cautela.

A maneira recomendada de aplicar estas configurações é por meio das propriedades de ambiente `DOTNET_`. Claro, você também pode usar outros métodos, p. ex.: `runtimeconfig.json`, mas é impossível definir algumas configurações desta maneira e, além disso, o ASF substituirá o seu arquivo personalizado `runtimeconfig.json` pelo arquivo próprio do ASF, portanto recomendamos propriedades de ambiente que você possa definir facilmente antes de iniciar o processo.

O tempo de execução do .NET permite que você **[ajuste o coletor de lixo](https://docs.microsoft.com/dotnet/core/run-time-config/garbage-collector)** de várias formas, melhorando-o efetivamente conforme as suas necessidades. Nós documentamos abaixo propriedades que são especialmente importantes em nossa opinião.

### [`gcServer`](https://docs.microsoft.com/dotnet/core/run-time-config/garbage-collector#flavors-of-garbage-collection)

> Configura se o aplicativo usa a coleta de lixo da estação de trabalho ou do servidor.

Você pode ler as especificações exatas do coletor de lixo de servidor em **[noções básicas da coleta de lixo](https://docs.microsoft.com/pt-br/dotnet/standard/garbage-collection/fundamentals)**.

O ASF usa a coleta de lixo de estação de trabalho por padrão. Principalmente por causa do balanço entre uso de memória e desempenho, o que é mais que suficiente para alguns bots, já que um único coletor de lixo simultaneamente em segundo plano é rápido o bastante para cuidar de toda a memória alocada pelo ASF.

No entanto, hoje nós temos um monte de núcleos de CPU dos quais o ASF pode se beneficiar por ter um thread de coleta de lixo dedicado para cada núcleo de CPU virtual disponível. Isto poderá melhorar muito o desempenho durante tarefas pesadas do ASF tais como análise de páginas de insígnias ou inventário, já que cada núcleo virtual de CPU pode ajudar, ao invés de apenas 2 (o principal e o de coleta de lixo). A coleta de lixo do servidor é recomendado para computadores com 3 núcleos virtuais de CPU ou mais e a coleta de lixo de estação de trabalho é forçada automaticamente se seu computador tem apenas um núcleo virtual de CPU, e se você tem exatamente 2, considere tentar ambos (os resultados podem variar).

A coleta de lixo de servidor em si não resulta em um aumento de memória muito grande apenas por estar ativo, mas tem muito mais capacidade de geração e portanto é muito mais lento quando se trata de retorno de memória ao sistema operacional. Você pode achar que encontrou um bom ponto quando o coletor de lixo de servidor aumenta significativamente o desempenho e você deseja usa-lo, mas ao mesmo tempo você não pode permitir um aumento significativo do uso de memória que acompanha o uso dele. Felizmente há uma configuração que proporciona o "melhor dos dois mundos": usar o coletor de lixo do servidor com a propriedade de configuração **[`GCLatencyLevel`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup-pt-BR#gclatencylevel)** definida como `0`, que vai permitir o coletor de lixo do servidor, mas limitar os tamanhos de geração e focar mais na memória. Como alternativa, você pode experimentar a propriedade **[`GCHeapHardLimitPercent`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup-pt-BR#gcheaphardlimitpercent)**, ou até mesmo ambos ao mesmo tempo.

No entanto, se memória não é um problema para você (como o coletor de lixo leva em conta sua memória disponível e se auto-ajusta) é melhor não alterar essas opções, alcançando um desempenho superior como resultado.

### **[`DOTNET_TieredPGO`](https://docs.microsoft.com/dotnet/core/run-time-config/compilation#profile-guided-optimization)**

> Essa configuração habilita a otimização guiada por perfil (PGO) dinâmica ou escalonada no .NET 6 e versões posteriores.

Desativado por padrão. Resumidamente, isso fará com que o JIT passe mais tempo analisando o código do ASF e seus padrões de modo a gerar um código superior otimizado para seu uso do dia a dia. Se você quiser aprender mais sobre essa configuração, visite **[melhorias de desempenho no .NET 6](https://devblogs.microsoft.com/dotnet/performance-improvements-in-net-6)**.

### **[`DOTNET_ReadyToRun`](https://docs.microsoft.com/dotnet/core/run-time-config/compilation#readytorun)**

> Configura se o .NET Core runtime usa código pré-compilado para imagens com dados ReadyToRun disponíveis. Desabilitar esta opção força o runtime a compilar o código do framework usando Just-In-Time.

Ativado por padrão. Desativando isso junto com a ativação de `DOTNET_TieredPGO` permite que você extenda a otimização guiada por perfil em camadas para toda a plataforma .NET, e não apenas para o código ASF.

---

Você pode habilitar propriedades selecionadas ao definir variáveis de ambiente apropriadas. Por exemplo, no Linux (shell):

```shell
export DOTNET_gcServer=1

export DOTNET_TieredPGO=1
export DOTNET_ReadyToRun=0

./ArchiSteamFarm # For OS-specific build
./ArchiSteamFarm.sh # For generic build
```

Ou no Windows (powershell):

```powershell
$Env:DOTNET_gcServer=1

$Env:DOTNET_TieredPGO=1
$Env:DOTNET_ReadyToRun=0

.\ArchiSteamFarm.exe # For OS-specific build
.\ArchiSteamFarm.cmd # For generic build
```

---

## Otimização recomendada

- Certifique-se de estar usando o valor padrão em `OptimizationMode` (modo de otimização) que é `MaxPerformance` (máximo desempenho). Esse é de longe a configuração mais importante uma vez que usar o valor `MinMemoryUsage` (uso mínimo de memória) traz sérios efeitos ao desempenho.
- Habilitar coletor de lixo no servidor. A ativação da coleta de lixo do servidor pode ser percebida imediatamente por um aumento significativo de memória em comparação com o coletor de lixo de estação de trabalho. Isso gerará uma thread de coleta de lixo para cada thread de CPU que sua máquina possui para conseguir executar operações de coleta de lixo em paralelo com velocidade máxima.
- Se você não puder arcar com o aumento de memória devido a coleta de lixo do servidor, considere ajustar **[`GCLatencyLevel`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup-pt-BR#gclatencylevel)** e/ou **[`GCHeapHardLimitPercent`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup-pt-BR#gcheaphardlimitpercent)** para aproveitar "o melhor dos dois mundos". No entanto, se sua memória não aguenta é melhor manter tudo nos valores padrão; o coletor de lixo de servidor se auto-ajusta durante o tempo de execução e é inteligente o bastante para usar menos memória quando seu sistema operacional necessita dela.
- Você também pode considerar uma maior otimização para um tempo de inicialização mais longo com ajustes adicionais através das outras propriedades `DOTNET_` explicadas acima.

Usando as recomendações acima permite que você tenha um desempenho superior para o ASF que deverá ficar muito mais rápido mesmo com centenas ou milhares de bots habilitados. O CPU não deverá mais ser um gargalo, já que o ASF pode usar todo o desempenho do seu CPU caso necessário, reduzindo o tempo necessário ao mínimo possível. O próximo passo seria um upgrade em sua CPU e memória RAM.