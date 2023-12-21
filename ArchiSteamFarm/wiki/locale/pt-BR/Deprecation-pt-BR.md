# Depreciação

We're doing our best to follow consistent deprecation policy in order to make both development as well as usage far more consistent.

---

## O que é depreciação?

Deprecation is the process of smaller or bigger breaking changes that render previously used options, arguments, functionalities or usage cases obsolete. Depreciação costuma significar que determinada coisa simplesmente foi reescrita de outra forma (semelhante), e você deve garantir em tempo hábil que você fará a mudança apropriada. Neste caso, é simplesmente mover determinada funcionalidade para o local mais apropriado.

O ASF muda rápido e sempre em busca de se tornar melhor. Infelizmente, isto significa que podemos mudar ou mover algumas funcionalidades existentes para outro segmento do programa a fim de que elas possam se beneficiar de novos recursos, compatibilidade ou estabilidade. Graças a isso, não precisamos nos atar a decisões de desenvolvimento obsoletas ou dolorosamente erradas que fizemos anos atrás. Sempre buscamos trazer substituições sensatas que se encaixam ao uso esperado de funções anteriormente disponíveis, esse é motivo pelo qual a depreciação é geralmente inofensiva e requer pequenas correções no uso anterior.

---

## Etapas da depreciação

O ASF seguirá 2 fases de depreciação, fazendo a transição mais fácil e menos problemática.

### Primeira etapa

A primeira etapa acontece assim que determinada funcionalidade se torna depreciada, com a disponibilidade imediata de outra solução (ou nenhuma, caso não haja planos de reintroduzi-la).

Durante esse estágio o ASF vai mostrar um aviso quando a função depreciada estiver sendo usado. Enquanto for possível, o ASF vai tentar imitar o comportamento antigo e continuar a ser compatível com ele. O ASF vai continuar no primeiro estágio em relação a essa funcionalidade pelo menos até a próxima versão estável. Esse é o momento quando, esperançosamente sem quebra de compatibilidade, você pode fazer as mudanças necessárias em todas as suas ferramente e padrões para se enquadrarem ao novo comportamento. Você pode confirmar que fez todas as mudanças necessárias quando não ver mais o aviso de depreciação.

### Segunda etapa

A segunda etapa ocorre quando uma nova versão estável é lançada. Essa etapa introduz a remoção completa do recurso depreciado, o que significa que o ASF não vai reconhecer que você está tentando usar um recurso depreciado, muito menos respeitá-lo, uma vez que ele simplesmente não existe no código atual. O ASF não vai mais mostrar qualquer aviso, já que ele não reconhece o que você está tentando fazer.

---

## Resumo

Você tem mais ou menos **um mês inteiro** para fazer as mudanças necessárias, o que deve ser mais do que suficiente mesmo se você é um usuário casual do ASF. Após esse período, o ASF já não garante que as configurações antigas terão qualquer efeito (segunda etapa), fazendo com que certas funcionalidades parem de funcionar sem que você perceba. Se você ficar mais de um mês sem abrir o ASF, é aconselhável que você **[comece do zero](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up-pt-BR)** novamente, ou leia todos os registros de mudança que possa ter perdido e se adapte manualmente ao uso atual.

Na maioria dos casos, ignorar o aviso de depreciação não deixara a funcionalidade geral do ASF inutilizada, mas fará com que ela volte ao comportamento padrão (que pode ou não coincidir com suas preferências pessoais).

---

## Exemplo

Nós movemos o **[argumento de linha de comando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments-pt-BR)** `--server` das versões anteriores à V3.1.2.2 para o **[parâmetro de configuração global](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#configurações-globais)** `IPC`.

### Primeira etapa

A primeira etapa aconteceu na versão V3.1.2.2, onde adicionamos o aviso adequado quanto ao uso de `--server`. O argumento `--server`, agora obsoleto, foi mapeado automaticamente para a propriedade de configuração global `IPC: true`, agindo exatamente da mesma forma que o argumento `--server` durante esse tempo. Isso permitiu que todo mundo fizesse a mudança apropriada antes do ASF deixar de aceitar o argumento antigo.

### Segunda etapa

A segunda etapa ocorreu na versão seguinte, V3.1.3.0. Ela fez com que o ASF parasse totalmente de reconhecer o argumento `--server`, tratando-o como qualquer outro argumento inválido, o que não tem qualquer efeito sobre o programa. Para as pessoas que ainda não haviam mudado o uso de `--servidor` para `IPC: true`, isso fez com que o IPC parasse totalmente de funcionar, uma vez que o ASF já não mapeava corretamente.