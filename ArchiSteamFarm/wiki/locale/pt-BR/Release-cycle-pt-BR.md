# Ciclo de lançamento

O ASF usa uma versão comum do C# com 4 números, escritos como `A.B.C.D`. Cada versão é sempre "congelada" e aponta para um código fonte fixo do qual foi compilada (que vem com o lançamento). Não pretendemos remover nenhuma versão lançada anteriormente, contando que nosso provedor de host (GitHub) continue mantendo elas por um tempo indefinido, portanto você sempre pode baixar uma das versões antigas sem precisar manter cópias por conta própria.

Quanto à versão do ASF, estamos fazendo o melhor para seguir o padrão `MAJOR.MINOR.PATCH` do **[semver](https://semver.org)** nos 3 últimos números - `B.C.D`. Esses três números estão diretamente relacionados ao código do ASF. O número mais significativo `A` indica mudanças com um escopo que vai além de apenas o código do ASF em si, geralmente afetando diretamente a base do programa.

O ASF, como projeto, tem como objetivo de **lançar aproximadamente uma nova função por mês **, indicado pelao incremento do número `C`. Para tornar essa versão possível temos **pré-lançamentos** menores dedicados a usuários avançados, que servem como marcos menores para as mudanças que são lançadas conforme necessário, quando houver mudanças suficientes desde o último pré-lançamento para se concentrar. Eventualmente, quando um pré-lançamento final for determinado como estável e maduro o suficiente, sem regressões críticas conhecidas que devam ser corrigidas em comparação com o lançamento estável anterior, ele será promovido para o novo lançamento estável, ao mesmo tempo em que abre um novo ciclo mensal para o próximo.

While we're doing our best to ensure that even our pre-releases are relatively stable, it should be noted that **pre-releases should be carefully evaluated when running in any production environment**. Pré-lançamentos podem ter **erros críticos** e funcionalidades problemáticas, e é exatamente por isso que as liberamos nesse estado - para que possamos evitar qualquer tipo de problemas em nossas compilações estáveis e oferecer um software confiável. Se você estiver relutante em aceitar o alto risco de usar um software potencialmente instável, **por favor, evite usar nossas compilações de pré-lançamento** e fique com a versão **[mais recente e estável](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)**, que é mais adequado para a maioria dos usuários.

Depending on amount of changes in the cycle, usually there will be a single `C` version bump (from previous stable), and `D` bumps for every pre-release on as-needed basis. No entanto, quando são introduzidas mudanças com um âmbito muito maior, especialmente mudanças importantes, o ciclo pode começar (ou mudar no meio) com o incremento `B` ou mesmo `A` - tal mudança indica que o ciclo de lançamento atual tem potencial para ser mais instável do que o normal, e deve ser testado com cuidado. Keep in mind that semver changes we're making relate only to previously released stable version, we do not track versioning across pre-releases in a cycle themselves, which means that version `1.0.1.2` might have a new feature that `1.0.1.1` didn't have, as long as the previously marked stable release is from `1.0.0.X` family. Desse jeito, pode haver grandes mudanças mesmo em dois pré-lançamentos do mesmo ciclo, o que acontece geralmente quando ainda estamos decidindo sobre a forma final de funcionalidades recém-introduzidas ou similares.

| Incremento de versão | Semver | Exemplo de alterações                                                                                                                                                                                                         |
| -------------------- | ------ | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| A                    |        | Major .NET runtime changes, foundation changes, breaking changes that are beyond ASF's codebase, stuff that might eat your cat                                                                                                |
| B                    | Maior  | Mudançãs menores no tempo de execução .NET, mudanças grandes no código base do ASF, mudanças no código que não se classificam como menores                                                                                    |
| C                    | Menor  | Novos ciclos mensais, geralmente introduzindo novas funcionalidades, comandos, propriedades de configuração ou outras alterações que não modifiquem as configurações existentes                                               |
| D                    | Patch  | Pré-lançamentos que fazem parte do ciclo existente (indicado por um número mais significativo), correções críticas de bugs para lançamentos estáveis já existentes que não introduzem alterações de código além do necessário |

Note que funcionalidades e mudanças recém implementadas podem demorar a ter documentação (por exemplo, na wiki), já que a documentação geralmente é escrita quando o código final de determinada funcionalidade está pronto (para nos poupar o tempo de reescrever a documentação toda vez que decidirmos mudar a funcionalidade na qual estamos trabalhando). Devido ao fato de que pré-lançamentos podem conter trabalho em progresso no código que ainda não tem uma forma final, a documentação deverá ser escrita no último estágio do desenvolvimento. O mesmo se aplica ao relatório de mudanças que pode ser indisponível para determinado pré-lançamento até um tempo depois. Portanto, se você decidir usar versões de pré-lançamento, esteja preparado para olhar as **[commits](https://github.com/JustArchiNET/ArchiSteamFarm/commits/main)** do ASF de vez em quando. Claro, a falta de documentação se aplica **apenas** aos pré-lançamentos; toda versão estável deve sempre ter um relatório completo de mudanças e documentação no wiki no momento em que está sendo lançado.

O relatório de mudanças preciso que compara uma versão a outra está sempre disponível no GitHub através de commits e alterações de código. No lançamento, nós tendemos a documentar apenas as alterações que consideramos importantes entre a última versão estável e o lançamento atual. Such brief changelog is never a complete one, so if you'd like to see every change that happened between one version and another (such as our dependencies upgrades) - please use **[GitHub comparison](https://github.com/JustArchiNET/ArchiSteamFarm/compare)** for that.

O projeto ASF é distribuído pelo nosso **[processo de integração contínuo](https://github.com/JustArchiNET/ArchiSteamFarm/actions)**. Toda compilação deve ser reproduzível, portanto, não deve ser um problema pegar a fonte (incluída no lançamento) de determinada versão e compilar por sua conta tendo o mesmo resultado que o disponível através de nossos binários pré-compilados. We typically avoid compiling releases ourselves, as long as the systems are operative, the released binaries come directly from our CI process.