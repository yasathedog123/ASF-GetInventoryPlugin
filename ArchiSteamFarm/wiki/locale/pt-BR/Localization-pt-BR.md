# Localização

O ASF é traduzido pelo serviço Crowdin, que torna possível que qualquer um possa ajudar a traduzi-lo em todas as línguas faladas pelo mundo. Para uma explicação mais detalhada de como o Crowdin funciona, confira **[introdução ao Crowdin](https://support.crowdin.com/crowdin-intro)**.

Se você estiver interessado no que está acontecendo atualmente, você pode verificar a **[atividade do ASF no Crowdin](https://crowdin.com/project/archisteamfarm/activity_stream)**.

---

## Escopo

Nossa plataforma oferece suporte a localização do programa principal do ASF, bem como todo o conteúdo localizável que oferecemos junto com ele. Isso inclui especialmente nosso Gerador de Configuração Web (ASF-WebConfigGenerator), ASF-ui, e nossa wiki. Tudo isso é possível traduzir através da interface amigável do Crowdin.

---

## Cadastrando-se

Se você gostaria de ajudar com o ASF, seja traduzindo, revisando ou aprovando as traduções, por favor cadastre-se na **[página do nosso projeto no Crowdin](https://crowdin.com/project/archisteamfarm)**. O cadastro é fácil e totalmente gratuito! Após o login você pode escolher os idiomas para os quais você quer ser designado e, em seguida, prosseguir para o projeto do ASF e ajudar o resto da comunidade traduzindo ele para todos os idiomas mais populares!

---

### Traduzindo

Se o idioma de sua escolha conter linhas sem tradução, você pode pegá-las e começar a trabalhar. Nós tentamos fazer o nosso melhor em termos de flexibilidade das traduções, portanto muitas linhas incluem variáveis extras que o ASF fornecerá durante o tempo de execução - essas são colocadas entre colchetes com um número, tal como `{0}`. Isso permite que você altere o formato padrão da linha do ASF, movendo, por exemplo, a variável que ele fornece para um lugar que satisfaça o padrão do seu idioma ao invés de ser forçado a um contexto e formato fixo. Isto é especialmente importante em idiomas como o Hebraico, em que se escreve da direita para a esquerda.

Por exemplo, você poderia ter uma linha assim:

> Temos {0} jogos para farmar.

Mas em seu idioma, a seguinte frase poderia fazer mais sentido:

> O número de jogos para farmar é igual à {0}.

Ou:

> {0} é o número de jogos para coletar.

A flexibilidade é fornecida especialmente para você, então você pode reformular ligeiramente a sentença do ASF para ficar melhor em seu idioma e mover o número fornecido pelo ASF ou outras informações para o lugar que se encaixe em sua tradução (em vez de traduzir cada parte independentemente). Isso melhora a qualidade geral da tradução.

---

### Revisando

Se a frase já foi traduzida por alguém, você pode votar nela. O voto torna possível escolher a melhor variante da tradução ao invés de se prender a sugestão inicial - isso melhora ainda mais a qualidade da tradução. Você pode votar nas sugestões já disponíveis ou sugerir a sua própria tradução, que passará pelo mesmo processo. Eventualmente, a frase final será escolhida pela sugestão mais votada ou pelo revisor escolhido para aquele idioma, que aprova manualmente determinada tradução (baseada em seus votos também).

**Não é preciso aprovação para ver suas linhas traduzidas no ASF**. Aprovação significa simplesmente que alguém em quem confiamos revisou o conteúdo, e escolheu a versão final da tradução. É perfeitamente normal ter traduções criadas pela comunidade não aprovadas, onde você vota pela melhor. Contanto que esteja traduzido, tudo bem! E se você acha que a tradução atual está ruim, você sempre pode votar pela melhor, ou sugerir uma você mesmo.

---

### Prova de leitura

É uma boa ideia ter uma tradução consistente, mesmo que potencialmente possa tomar a liberdade do processo de revisão/votação da comunidade explicado acima. Isto ocorre principalmente porque traduções incorretas que não são necessariamente ruins podem ter tantos votos favoráveis que já não é possível sugerir qualquer tradução melhor, mesmo se alguém a tem.

Se você tem histórico de contribuições no Crowdin ou qualquer outra plataforma/serviço de localização que podemos verificar e assumir confiável, estaremos felizes em dar-lhe o acesso de revisor para o idioma que você está contribuindo, então você será capaz de aprovar determinada tradução e torná-lo coerente. A prova de leitura não é uma tarefa fácil, especialmente porque o ASF pode ser muito "técnico" as vezes e muito difícil de traduzir, mas entendemos que muitas vezes é necessário para uma perfeita tradução. Portanto, se você pode ajudar revisando determinado idioma, **[diga-nos](https://crowdin.com/messages/create/13177432/240376)**, mas tenha em mente que você precisará suportar seu pedido com contribuições de localização anteriores que podessamos verificar (por exemplo, trabalhando com a localização do ASF no Crowdin, ou com qualquer outro projeto). Nós também podemos permitir que usuários mais avançados realizem uma revisão inicial se nós os conhecemos pessoalmente e eles são capazes de cooperar com o resto da comunidade a fim de melhor localizar o ASF nesse determinado idioma.

Regras gerais se aplicam para a prova de leitura - não tenha pressa, ouça seus usuários, trabalhe como um gerente de projetos, resolva problemas, certifique-se de que você está fazendo as coisas melhor e não pior.

---

### Problemas

Se você tiver um problema com uma tradução em particular, por exemplo, você não sabe como traduzir, a tradução aprovada é incorreta, você precisa de um contexto mais específico, ou outra coisa, por favor poste um comentário na frase específica e marque [X] a caixa Issue.

**Por favor, evite marcar a caixa "Issue" se você não precisa de explicação técnica/de desenvolvimento ou uma ação do administrador**. Você é livre para usar comentários para discussões relacionadas a tradução de determinada frase, mas você só deve marcar a frase como problema ("Issue") quando precisar de uma explicação mais técnica ou de correção de um administrador, e isso normalmente envolve alguém que não fala o idioma para o qual você está traduzindo, então, por favor, opte pelo inglês ao escrever um comentário descrevendo um problema (para que possamos entender qual é o problema).

Existem 4 tipos de problemas suportados no momento:
- Questões gerais: tudo o que não se encaixa em nenhuma das opções abaixo. Em geral este tipo **deve ser evitado**, uma vez que se o seu problema não se encaixa em nenhuma opção abaixo é muito provável que **não** seja uma questão de tradução. Ainda assim, esta opção está disponível para todos os outros casos.
- A tradução atual está errada - deve ser usado **apenas** se a tradução já foi pré-aprovada pelo revisor, e você acredita que está errada, um erro de digitação, por exemplo, ou você tem uma sugestão válida de como melhorá-la. Ele nunca deve ser usado em traduções que foram aprovadas pela comunidade (votação), já que nesse caso você deve entrar em contato com o usuário de determinada tradução e pedir a correção, ou simplesmente votar para a melhor tradução como indicado na seção de revisão. Vamos remover a aprovação da tradução e notificar o revisor responsável pelo idioma para levar em conta seu comentário e verificar novamente.
- Falta de informações contextuais - é isso que você deve usar se não tem certeza de que parte do ASF está traduzindo, qual é o contexto ou o propósito da frase. Este tipo deve ser usado apenas para o desenvolvimento do ASF, isso significa que você precisa de assistência técnica já que você não tem certeza de como deve traduzir determinada frase.
- Erro na frase de origem - deve ser usado somente se você acredita que a frase original (inglês) está incorreta. É raro, mas nenhum de nós também é um falante nativo do inglês, então se sinta a vontade para usá-lo se você tiver uma ideia de como ela pode ser melhorada. Alternativamente, já que isso está estritamente relacionado com o desenvolvimento, se quiser, você pode usar os nosso **[GitHub issues](https://github.com/JustArchiNET/ArchiSteamFarm/issues/new/choose)** para esse propósito.

---

### Progresso da tradução

Todo idioma tem dois estágios de conclusão: tradução e revisão.

Um idioma é considerado **traduzido** quando o processo de tradução atinge 100%. Nesse ponto, cada linha localizável (traduzível) no ASF tem o significado correto, o que é ótimo. No entanto, isso não significa que não há espaço para melhorias: a votação da comunidade é habilitada o tempo todo e você ainda pode sugerir uma tradução melhor para partes já traduzidas, bem como votar para os já existentes. Por favor, note que línguas totalmente traduzidas ainda podem cair abaixo de 100% quando mudarmos linhas existentes ou adicionarmos novas durante o desenvolvimento. Você pode configurar as notificações do Crowdin se quiser receber um e-mail quando isso acontecer.

Os idiomas selecionados podem ter revisores apropriados que validam as traduções e aprovam as versões finais. Esse é o último passo da tradução e permite melhorar ainda mais a localização.

O ASF incluirá idioma traduzido **logo que possível**, o que significa que ele não precisa ser aprovado, e nem mesmo 100% traduzido. As frases que serão usadas são sempre as mais populares em termos de votos, a não ser que o revisor escolhido decida outra coisa (raramente). Portanto, você pode ver seus esforços inclusos na próxima versão do ASF - nossos sistemas de automação mesclam as traduções do Crowdin para o repositório do ASF diariamente.

---

## Idiomas ausentes

Por padrão o projeto do ASF tem tradução aberta apenas para os 30 idiomas mais falados no mundo. Se você gostaria de acrescentar outro (ou um dialeto local para um idioma já disponível), por favor **[avise-nos](https://crowdin.com/messages/create/13177432/240376),** e vamos adicioná-lo o mais rápido possível. Não queremos abrir várias centenas de idiomas diferentes se ninguém vai traduzi-los, é por isso que limitamos para um número justo. Por favor, não hesite em nos contatar se você gostaria de traduzir para um idioma não listado, é muito fácil adicionar outro. Apenas certifique-se de que você tem vontade e determinação reais para traduzir o ASF em seu idioma antes de decidir entrar em contato conosco.

Para obter uma lista completa de todos os idiomas disponíveis para os quais o ASF pode ser traduzido **[clique aqui](https://developer.crowdin.com/language-codes)**.

---

## Pluralização

Cada idioma tem suas próprias regras em relação à pluralização. Essas regras podem ser encontradas no **[CLDR](https://unicode-org.github.io/cldr-staging/charts/latest/supplemental/language_plural_rules.html)** que especifica o número e as condições exatas de linguagem.

Estamos fazendo o melhor para lhe oferecer uma tradução flexível, e tanto quanto possível isto também irá incluir regras de plural. Por exemplo, vamos traduzir a seguinte sentença para o Polonês:

> Released {PLURAL:n|{n} month|{n} months} ago

A palavra chave `PLURAL` aqui é tratada de forma especial já que ela permite que você inclua todas as formas de plural que seu idioma aceite. Se você der uma olhada no CLDR, você verá que na sentença em inglês existem apenas 2 formas de cardinais - "one" e "other". E como você pode ver acima, temos ambas definidas: `{n} month` e `{n} months`.

No entanto, nosso idioma polonês inclui 4: "um", "alguns", "muitos" e "outro". Isto significa que nós devemos definir todos eles. Nossas ferramentas de tradução são inteligentes o bastante para escolher a forma plural correta com base nas regras de linguagem, portanto, você só tem que defini-los na tradução:

> Wydany {PLURAL:n|{n} miesiąc|{n} miesiące|{n} miesięcy|{n} miesiąca} temu

Desta forma definimos todas as 4 formas de plural para o idioma polonês, e já que a nossa biblioteca de localização já sabe as regras exatas, ela devidamente usará o formulário correto para o número `{n}` definido.

Não é obrigatório definir todas as formas de plural usadas pela sua linguagem. Se faltar alguma, nossa biblioteca de localização usará a última forma definida em seu lugar. É uma boa ideia definir todas as formas de plural usadas pelo seu idioma, mas em alguns casos as formas plurais subsequentes podem ser igual a última e, nesse caso, não é necessário repeti-las. No nosso exemplo acima isso era obrigatório, já que a "outra" forma em polonês para meses é "miesiąca" e não "miesięcy" como em "muitos".

---

## Wiki

Nossa plataforma no Crowdin permite que você localize até mesmo a própria wiki. Esta é uma ferramenta muito poderosa, pois permite-lhe criar uma documentação completa do ASF em sua língua nativa, efetivamente resolvendo o último problema quando se trata da localização do ASF. Juntamente com a tradução do programa e todas as suas partes, isto torna a localização completa.

A Wiki é um pouco especial nesse respeito, uma vez que é uma ajuda on-line onde você não precisa se fixar demais na sentença original. Isso significa que você quer ser o mais natural com sua língua quanto possível enquanto entrega o significado e ajuda originais - não necessariamente ficando preso a linha original, nem suas palavras e pontuações. Não tenha medo de reescrever a linha da forma mais natural para o seu idioma, desde que mantenha o significado geral da ajuda inclusa na sentença.

---

### Links globais

Nossa plataforma no Crowdin também permite que você adapte o texto original de forma que ele aponte para os idiomas traduzidos.

O ASF inclui links em praticamente todas as páginas para facilitar a navegação, bem como uma barra lateral na direita. O fato interessante é que você pode editar tudo isso, "arrumando" os links para apontarem para as páginas já traduzidas para o seu idioma. É preciso de um pouco de atenção ao fazer isso, mas é possível.

Por exemplo, a **[página inicial](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Home)** do ASF (em inglês) inclui o texto:

> Se você é um novo usuário, recomendamos começar com o guia de **[instalação](https://github.com/JustArchi/ArchiSteamFarm/wiki/Setting-up-pt-BR)**.

Que é originalmente escrita:

```markdown
If you're a new user, we recommend starting with **[setting up](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up)** guide.
```

No Crowdin, a primeira coisa que você deve fazer é ir até as configurações do editor e certificar-se de que as tags HTML estão marcadas como "Show". Isso é muito importante se você decidir traduzir a wiki.

---

![Crowdin](https://i.imgur.com/YqAxiZ4.png)

---

Agora, durante a tradução no Crowdin, dependendo da formatação, você verá links do ASF no texto nas formas abaixo:

* Linhas para traduzir com tags HTML (a maior parte delas, onde apenas uma parte da frase é um link)
* Uma linha sozinha para traduzir, com link incluído em `Hidden texts` -> `Link addresses` (raro, onde a linha inteira é um link, mais comum na barra lateral - eles exigem acesso de revisor para traduzir, Infelizmente)

No exemplo acima vemos o primeiro caso (já que apenas "setting up" é um link), então você terá:

---

![Crowdin 2](https://i.imgur.com/Li5RzS3.png)

---

Independente do caso, você deve copiar a frase a ser traduzida e traduzi-la normalmente, deixando todo o HTML (se houver) intacto. Segue um exemplo da tradução para o polonês:

---

![Crowdin 3](https://i.imgur.com/NpKwfka.png)

---

Agora, se o link apontar para fora da wiki (por exemplo, para versão mais recente do ASF), você deve deixá-lo como está. Você deve salvá-lo e seguir adiante.

No entanto, se o link **aponta** para a própria wiki, como no caso acima, você deve corrigi-lo para apontar para o novo local (traduzido). Para fazer isso acrescente `-locale` no fim da URL de destino na tag `<a>`, como no exemplo abaixo:

---

![Crowdin 4](https://i.imgur.com/TL8uwmb.png)

---

Tenha muito cuidado com isso e certifique-se de que a sua URL de fato existe, pois se você cometer um erro, o link vai parar de funcionar. Se você fizer corretamente você terá uma tradução totalmente funcional com o link apontando para a página traduzida (no nosso caso `Setting-up-pl-PL`).

Fazer os passos acima corretamente irá traduzir nosso HTML:

```markdown
Jeśli jesteś nowym użytkownikiem, zalecamy rozpoczęcie od korzystania z **[przewodnika po konfiguracji](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up-pl-PL)**.
```

E no texto da wiki:

> Jeśli jesteś nowym użytkownikiem, zalecamy rozpoczęcie od korzystania z **[przewodnika po konfiguracji](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up-pl-PL)**.

Quando não há nenhum HTML (segundo caso), isso fica ainda mais fácil já que você só precisa ir até `Hidden texts` -> `Link addresses`.

---

![Crowdin 5](https://i.imgur.com/ZmgavCM.png)

---

A partir de lá você pode corrigir facilmente os links para apontarem para a nova localização, sem se preocupar com o HTML:

---

![Crowdin 6](https://i.imgur.com/maG7kSm.png)

---

### Links locais

Na wiki você também encontrará links locais que apontam para determinadas seções do documento. Esses links incluem o caracter `#`, indicando ao navegador que ele deve ir até essa seção do documento.

Esses são casos especiais, já que são baseados nos nomes das seções do documento atual. Enquanto para as URLs adicionamos `-locale` que funciona para todos os casos, os nomes de seção serão traduzidos e então você precisa garantir que eles apontem para local apropriado.

Por exemplo, você vai encontrar o link `#introduction` na nossa seção de **[configuração](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#introduction)**:

---

![Crowdin 7](https://i.imgur.com/EEHSPtK.png)

---

Já que vamos para traduzir a palavra "Introduction" para o polonês "Wprowadzenie", precisamos corrigir este link pois ele vai parar de funcionar no momento em que o traduzirmos.

---

![Crowdin 8](https://i.imgur.com/JMJegO7.png)

---

Desta forma nosso link local continua funcionando, já que ele agora vai apontar para o nome da seção que estamos usando. Você pode corrigir links dentro de tags HTML exatamente da mesma forma.

---

### Blocos de código

Tenha muito cuidado quando você traduzir frases que contenham blocos `<code></code>`. Blocos de código indicam nomes ou termos do ASF que não devem ser traduzidos. Por exemplo:

> This is especially useful if you have a lot of keys to redeem and you're guaranteed to hit <code>RateLimited</code> status before you're done with your entire batch.

Como você pode ver, a palavra `RateLimited` está entre blocos de código e indicam um código de estado interno do ASF que não deve ser traduzido. Da mesma forma, você não deve traduzir outros códigos de blocos, tais como nomes de parâmetros de configuração (por exemplo: `TradingPreferences`) campos enum (por exemplo: as opções `Stable` e `Experimental` do parâmetro `UpdateChannel`) e demais.

No entanto, não é porque essas palavras não devem ser traduzidas que você não pode adicionar uma tradução ao lado delas, entre parênteses por exemplo.

> Isso é muito útil se você tem um monte de keys para resgatar e é certo que você atingirá o estado <code>RateLimited</code> (muitas tentativas de ativação) antes de terminar.

Como você pode ver acima, nós adicionamos "muitas tentativas de ativação" ao lado de `RateLimited` para traduzir o significado desse status de forma amigável, enquanto mantemos ao mesmo tempo o original do ASF, aquele que o usuário pode ver durante o uso do programa. Da mesma forma você pode traduzir/explicar outros casos semelhantes de várias palavras e frases.

Se você acredita que algo inapropriado foi incluso em um bloco de código, ou que há um texto que não está em um mas deveria, sinta-se livre para nos perguntar em um comentário do Crowdin marcado como **[issue](#issues)**. Isso também serve como um exemplo prático de uso de um link local.

---

## Hall da Fama

Gostaríamos de mostrar nossa eterna gratidão a pessoas que gastaram uma grande parte de seu tempo e esforço para melhorar a localização do ASF. Seus esforços foram incríveis e por isso você pode aproveitar traduções completas, incluindo a wiki, na maior parte graças a eles. Como um sinal de agradecimento, todas as pessoas listadas aqui têm acesso gratuito ao recurso **[`MatchActively`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin-pt-BR#matchactively)**, bastando **[solicitá-la](https://crowdin.com/messages/create/13177432/240376)**.

| Colaborador                                                | Idiomas          |
| ---------------------------------------------------------- | ---------------- |
| **[Astaroth](https://crowdin.com/profile/astaroth2012)**   | LOLCAT, Espanhol |
| **[Dead_Sam](https://crowdin.com/profile/Dead_Sam)**       | Português (BR)   |
| **[deluxghost](https://crowdin.com/profile/deluxghost)**   | Chinês (CN)      |
| **[DragonTaki](https://crowdin.com/profile/dragontaki)**   | Chinês (TW)      |
| **[LittleFreak](https://crowdin.com/profile/littlefreak)** | Alemão           |
| **[Ryzhehvost](https://crowdin.com/profile/Ryzhehvost)**   | Russo, Ucraniano |
| **[MrBurrBurr](https://crowdin.com/profile/MrBurrBurr)**   | LOLCAT, Alemão   |
| **[XinxingChen](https://crowdin.com/profile/XinxingChen)** | Chinês (HK)      |

Obrigado a todos por melhorar a qualidade de tradução do ASF!