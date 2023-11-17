# Plugins

À partir do ASF V4, o programa inclui suporte para plugins customizados que podem ser carregados durante a execução. Plugins permitem que você personalize o comportamento do ASF, adicionando comandos e lógicas de troca personalizados ou mesmo uma completa integração com serviços de terceiros e APIs.

---

## Para usuários

O ASF carrega os plugins localizados na pasta `plugins`, dentro da pasta do ASF. Uma prática recomendada é criar uma pasta para cada plugin que você queira usar, que pode ser baseada no nome do plugin, tal como `MyPlugin`. A estrutura então será `plugins/MyPlugin`. Todos os arquivos binários do plugin devem ser colocados dentro dessa pasta, o ASF vai carregar e usar seu plugin corretamente após reiniciar.

Geralmente os desenvolvedores publicarão seus plugins em um arquivo `zip` com uma estrutura determinada, então basta descompactar o arquivo zip na pasta `plugins`, que criará a pasta apropriada automaticamente.

Se o plugin foi carregado com êxito, você verá seu nome e versão no log. Você deve consultar os desenvolvedores dos plugins em caso de dúvidas, problemas ou forma de uso relacionado com os plugins que você decidiu usar.

Você pode encontrar alguns plugins em destaque na seção **[terceiros](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Third-party-pt-br#plugins-para-o-asf)**.

**Por favor, note que alguns plugins podem ser mal intencionados**. Você deve sempre usar apenas plugins de desenvolvedores confiáveis. Os desenvolvedores do ASF não podem garantir os benefícios padrões do ASF (tal como a não presença de malwares ou ser livre de VAC ban) caso você decida usar qualquer plugin personalizado. Você precisa entender que os plugins têm controle total sobre o processo do ASF uma vez carregados, e devido a isso, não podemos oferecer suporte a configurações que utilizam plugins personalizados, uma vez que você não está mais executando o código original do ASF.

---

## Para desenvolvedores

Plugins são bibliotecas padrão .NET que herdam a interface `IPlugin` em comum com o ASF. Você pode desenvolver plugins inteiramente independentes da linha principal do ASF e reutilizá-los nas suas versões atuais e futuras, contando que a API permaneça compatível. O sistema de plugins usado no ASF é baseado em `System.Composition`, conhecido anteriormente como **[Managed Extensibility Framework](https://docs.microsoft.com/dotnet/framework/mef)** que permite que o ASF descubra e carregue suas bibliotecas durante o tempo de execução.

---

### Como começar

Nós preparamos o **[ASF-PluginTemplate](https://github.com/JustArchiNET/ASF-PluginTemplate)** para você, que você poderá usar como base para o seu projeto de plugin. Usar o template não é obrigatório (já que você pode fazer tudo do zero), mas nós recomendamos usá-lo pois ele pode facilitar drasticamente o seu desenvolvimento e economizar bastante tempo para acertar todas as coisas. Simplesmente confira o **[README](https://github.com/JustArchiNET/ASF-PluginTemplate/blob/main/README.md)** do template e ele vai guiá-lo ao caminho certo. Independentemente disso, nós abordaremos o básico abaixo caso você queira começar do zero ou entender melhor os conceitos usados no template de plugin.

Seu projeto deve ser uma biblioteca padrão .NET que vise o framework da sua versão alvo do ASF, como especificado em **[compilação](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compilation-pt-BR)**. Nós recomendamos que você use .NET (Core), mas plugins .NET Framework também são aceitos.

O projeto deve fazer referência a arquitetura principal `ArchiSteamFarm`, a biblioteca pré-compilada `ArchiSteamFarm.dll` que você baixou como parte do lançamento, ou o projeto fonte (por exemplo, se você decidiu adicionar a árvore do ASF como submódulo). Isso permitirá que você acesse e descubra as estruturas do ASF, seus métodos e propriedades, especialmente a interface núcleo do `IPlugin` que você precisará herdar para o próximo passo. O projeto deve também fazer referência, no mínimo, ao `System.Composition.AttributedModel`, que permite que você use o `[Export]` para exportar seu `IPlugin` para ser usado no ASF. Além disso, você pode querer/precisar fazer referência a outras bibliotecas comuns a fim de interpretar as estruturas de dados que são dadas a você em algumas interfaces, mas a menos que você realmente precise delas, isso é suficiente por enquanto.

Se você fez tudo certo, seu `csproj` será semelhante ao exemplo abaixo:

```csproj
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net7.0</TargetFramework>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="System.Composition.AttributedModel" IncludeAssets="compile" Version="7.0.0" />
  </ItemGroup>

  <ItemGroup>
    <Reference Include="ArchiSteamFarm" HintPath="C:\\Path\To\Downloaded\ArchiSteamFarm.dll" />

    <!-- Se estiver construindo como parte da árvore de origem do ASF, use isto em vez de <Reference> acima -->
    <!-- <ProjectReference Include="C:\\Caminho\Para\ArchiSteamFarm\ArchiSteamFarm.csproj" ExcludeAssets="all" Private="false" /> -->
  </ItemGroup>
</Project>
```

Da parte do código, sua classe de plugin deve herdar da interface `IPlugin` (seja explicitamente ou implicitamente herdando de uma interface mais especializada, tal como `IASF`) e `[Export(typeof(IPlugin))]` para que seja reconhecido pelo ASF durante o tempo de execução. E exemplo mais puro disso seria:

```csharp
using System;
using System.Composition;
using System.Threading.Tasks;
using ArchiSteamFarm;
using ArchiSteamFarm.Plugins;

namespace SeuNamespace.NomeDoSeuPlugin;

[Export(typeof(IPlugin))]
public sealed class NomeDoSeuPlugin : IPlugin {
    public string Name => nameof(NomeDoSeuPlugin);
    public Version Version => typeof(NomeDoSeuPlugin).Assembly.GetName().Version;

    public Task OnLoaded() {
        ASF.ArchiLogger.LogGenericInfo("Meow");

        return Task.CompletedTask;
    }
}
```

Para utilizar seu plugin você deve primeiro compila-lo. Você pode fazer isso pela sua IDE, ou de dentro da pasta raiz do seu projeto através do comando:

```shell
# Se o seu projeto for independente (não é preciso definir um nome já que ele será único)
dotnet publish -c "Release" -o "out"


# Se o seu projeto fizer parte da árvore de código do ASF (para evitar a compilação de partes desnecessárias)
dotnet publish YourPluginName -c "Release" -o "out"
```

Após isso seu plugin estará pronto. Como exatamente você quer distribuir e publicar seu plugin é por sua conta, mas recomendamos criar um arquivo zip com uma pasta apenas, chamada `YourNamespace.YourPluginName`, dentro da qual você colocará seu plugin compilado juntamente com suas **[dependências](#dependências -do-plugin)**. Dessa forma o usuário precisará apenas descompactar o arquivo zip dentro da pasta `plugins` e nada mais.

Esse é o cenário mais básico, apenas para começar. Temos o projeto **[`ExamplePlugin`](https://github.com/JustArchiNET/ArchiSteamFarm/tree/main/ArchiSteamFarm.CustomPlugins.ExamplePlugin)** que mostra interfaces e ações que você pode fazer dentro do seu próprio plugin, incluindo comentários úteis. Sinta-se livre para dar uma olhada se você quiser aprender com um código funcional, ou explore o namespace `ArquiSteamFarm.Plugins` por sua conta e consulte a documentação incluída para todas as opções disponíveis.

Se em vez do plug-in de exemplo, você quiser aprender com projetos reais, há o plug-in **[`SteamTokenDumper`](https://github.com/JustArchiNET/ArchiSteamFarm/tree/main/ArchiSteamFarm.OfficialPlugins.SteamTokenDumper)** desenvolvido por nós, que vem acompanhado junto ao ASF. Além disso há outros plugins desenvolvidos por outros, na nossa seção **[aplicativos de terceiros](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Third-party-pt-BR#plugins-para-o-asf)**.

---

### Disponibilidade de API

O ASF, além do que você tem acesso pela interface, expõe muito de suas APIs internas, as quais você pode usar para estender sua funcionalidade. Por exemplo, se você quiser enviar algum tipo de novo pedido para o Steam web você não precisa implementar tudo a partir do zero, tratando todos os problemas com os quais tivemos de lidar antes de você. Simplesmente use nosso `Bot.ArchiWebHandler` que já expõe muitos métodos `UrlWithSession()` para você usar, cuidando de todas as coisas de baixo nível como autenticação, atualização da sessão ou limitação de tráfego para você. Da mesma forma, para enviar pedidos web fora da plataforma Steam, você pode usar a classe padrão .NET `HttpClient`, mas é melhor usar `Bot.ArchiWebHandler.WebBrowser` que está disponível, o que mais uma vez lhe oferece uma ajuda, por exemplo, no que diz respeito a tentar novamente pedidos falhos.

Temos uma política muito aberta em questão da disponibilidade da nossa API, então se você quiser usar algo já incluso no código do ASF basta **[abrir um chamado](https://github.com/JustArchiNET/ArchiSteamFarm/issues)** e explicar nele o uso planejado da API interna do ASF. É muito provável que não tenhamos nada contra, desde que o seu uso preterido faça sentido. É simplesmente impossível abrirmos tudo o que alguém gostaria de usar, então abrimos o que mais faz sentido para nós e esperamos por pedidos caso haja necessidade de acesso a algo que não é `público` ainda. Isso inclui as sugestões a respeito nas novas interfaces `IPlugin` que podem fazer sentido de serem adicionadas para estender funcionalidades existentes.

Na verdade, a API interna do ASF é a única limitação real quanto ao que seu plugin pode fazer. Nada te impede de, por exemplo, incluir a biblioteca `Discord.Net` no seu aplicativo e criar uma ponte entre seu bot do Discord e os comandos do ASF, pois seu plugin também pode ter dependências próprias. As possibilidades são infinitas, e nós fizemos o possível para dar o máximo de liberdade e flexibilidade possível para seu plugin, então não há limites artificiais em nada, apenas não temos completamente certeza de quais partes do ASF são cruciais para o desenvolvimento do seu plugin (que você pode resolver ao nos informar, e mesmo sem isso você pode sempre reimplementar a parte que você necessita).

---

### Compatibilidade de API

É importante salientar que o ASF é um aplicativo de consumo e não uma biblioteca típica com superfície de API fixa da qual você pode depender incondicionalmente. Isso significa que você não pode assumir que seu plugin, uma vez compilado, continuará funcionando com todas as futuras versões do ASF, independentemente. Isso é simplesmente impossível se quisermos continuar desenvolvendo o programa, e não ser capaz de se adaptar às constantes mudanças no Steam em nome da compatibilidade com versões anteriores não é apropriado para o nosso caso. Isto deve ser lógico para você, mas é importante salientar esse fato.

Faremos o nosso melhor para manter partes públicas do ASF funcionais e estáveis, mas não teremos medo de quebrar a compatibilidade se surgirem boas razões suficientes, seguindo nossa política de **[depreciação](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Deprecation-pt-BR)** nesse processo. Isto é especialmente importante no que diz respeito às estruturas internas da ASF que são expostas a você como parte da infra-estrutura do ASF, explicadas acima (por exemplo, `ArchiWebHandler`) que podem ser melhoradas (e, portanto, reescritas) como parte de aprimoramentos do ASF em versões futuras. Faremos o possível para informá-lo adequadamente nos logs de alterações e incluir avisos apropriados durante o tempo de execução sobre recursos obsoletos. Não temos intenção de reescrever tudo sem que haja uma necessidade realmente grande, então você pode ter certeza de que a próxima versão menor do ASF não vai simplesmente destruir seu plugin completamente apenas porque ela tem um número de versão maior, mas ficar de olho nos logs de atualização e verificar ocasionalmente se tudo está funcionando bem é uma boa ideia.

---

### Dependências de plugin

Seu plugin incluirá pelo menos duas dependências por padrão, referência para a API interna `ArchiSteamFarm` e `PackageReference` de `System.Composition.AttributedMode` que é necessário para ser reconhecido como um plugin do ASF. Além disso, mais dependências podem ser inclusas dependendo do que você decidiu fazer no seu plugin (por exemplo, a biblioteca `Discord.Net` caso você decidir integrar com o Discord).

A saída da sua compilação incluirá a biblioteca princilpal `YourPluginName.dll`, bem como todas as dependências que você referenciou. Como você estará desenvolvendo um plugin para um programa já em funcionamento, você não precisa e **não deve** incluir dependências que o ASF já inclui, como por exemplo, `ArchiSteamFarm`, `SteamKit2` ou `Newtonsoft. Json`. Retirar as dependências compiladas que são compartilhadas com o ASF não é um requisito absoluto para que seu plugin funcione, mas fazer isso irá reduzir drasticamente a quantidade de memória utilizada e o tamanho do seu plugin, além de melhorar o desempenho, devido ao fato de que o ASF compartilhará suas dependências e só carregará as bibliotecas que ele não conhece.

No geral, é recomendado incluir apenas as bibliotecas que o ASF não inclui ou inclui em uma versão errada/incompatível. Um exemplo óbvio é `YourPluginName.dll`, mas também pode incluir, por exempo, `Discord.Net.dll`, caso você decida ter dependencias dele que o ASF não inclui. Compilar bibliotecas que são compartilhadas com o ASF ainda pode fazer sentido se você quiser garantir uma compatibilidade de API (por exemplo, ter certeza que a biblioteca `Newtonsoft.Json` da qual você depende sempre estará na versão `X` ao invés da versão embutida no ASF), mas isso custa o preço de um maior uso/tamanho de memória e queda na performance e, portanto, deve ser avaliado com cautela.

Se você sabe que a dependência que você precisa está inclusa no ASF, você pode marcá-la com `IncludeAssets="compile"` conforme mostramos no exemplo `csproj` acima. Isto dirá ao compilador para evitar a publicação da biblioteca referenciada em si, pois o ASF já a inclui. Da mesma forma, note que referimos o projeto ASF com `ExcludeAssets="all" Private="false"` que funciona de forma muito semelhante - dizer ao compilador para não produzir arquivos do ASF (já que o usuário os possui). Isso se aplica somente quando faz referência ao projeto do ASF, uma vez que se você faz referência a uma biblioteca `dll`, então você não estará produzindo arquivos do ASF como parte do seu plugin.

Se você tiver dúvidas em relação ao que foi dito acima e você não tem idéias melhores, verifique quais bibliotecas `dll` estão inclusas no pacote `ASF-generic.zip` e certifique-se que seu plugin inclua apenas as que não fazem parte desse pacote. Para a maioria dos plugins mais simples isso incluirá apenas `NomeDoSeuPlugin.dll`. Se você tiver algum problema durante o tempo de execução em relação a algumas bibliotecas, inclua também as bibliotecas afetadas. Se todo o resto falhar, você pode sempre decidir agrupar tudo.

---

### Dependências nativas

As dependências nativas são geradas como parte de compilações específicas do Sistema Operacional, pois não há tempo de execução .NET disponível no host e o ASF está sendo executado por meio de seu próprio tempo de execução .NET que é agrupado como parte da compilação específica do Sistema Operacional. Para minimizar o tamanho da compilação, o ASF corta suas dependências nativas para incluir apenas o código que pode ser alcançado dentro do programa, o que efetivamente reduz as partes não utilizadas do tempo de execução. Isso pode criar um grande problema para você em relação ao seu plugin, se por acaso você achar que está em uma situação onde o seu plugin dependa de algum recurso .NET que não esteja sendo usado no ASF, nesse caso as compilações específicas para Sistema Operacional não poderão executá-lo corretamente, geralmente retornando `System.MissingMethodException` ou `System.Reflection.ReflectionTypeLoadException` no processo.

Isto nunca será um problema com as compilações genéricas, pois elas nunca lidam com dependências nativas (pois elas têm um tempo de execução completo no host, executando o ASF). Essa também é uma solução automática para o problema: **use seu plugin exclusivamente em compilações genéricas**, mas obviamente isso tem seu lado ruim, o de privar usuários que rodem compilações específicas para SO de usarem seu plugin no ASF. Se você estiver se perguntando se seu problema está relacionado a dependências nativas, você pode usar este método para verificação, carregue seu plugin em uma compilação genérica do ASF e veja se ele funciona. Caso positivo, tudo estará certo com as dependencias do pugin e os problemas estão sendo causados pelas dependencias nativas.

Infelizmente, tivemos que fazer uma escolha difícil entre publicar todo o tempo de execução como parte de nossas compilações específicas para SO, ou cortar os recursos não utilizados deixanto a compilação final com cerca de 50 MB a menos em comparação a versão completa. Nós escolhemos a segunda opção, e infelizmente é impossível para você incluir os recursos que faltam no tempo de execução juntamente com seu plugin. Se seu projeto requer acesso aos recursos de tempo de execução que não foram utilizados, você terá que incluir o tempo de execução .NET que você precisa completo, e isso significa executar seu plugin junto com a versão `generic` do ASF. Você não pode executar seu plugin em compilações específicas para SO, já que essas compilações simplesmente não possuem um recurso do tempo de execução que você precisa, e o tempo de execução do .NET runtime é incapaz de "mesclar" a dependência nativa que você poderia ter fornecido à nossa. Talvez isso melhore um dia no futuro, mas no momento simplesmente não é possível.

As compilações específicas de SO do ASF incluem o mínimo de funcionalidades adicionais que são necessárias para executar nossos plugins oficiais. Ele também expande ligeiramente a quantidade de dependências adicionais que podem ser necessárias para os plug-ins mais básicos. Portanto, nem todos os plugins vão precisar se preocupar com dependências nativas - apenas aqueles que vão além do que o ASF e nossos plugins oficiais precisam diretamente. Isso é feito como em extra, porque se nós precisarmos incluir dependências adicionais para nossos propósitos, podemos simplesmente fornecê-las diretamente ao ASF, tornando-as disponíveis para você também. Infelizmente, isso nem sempre é suficiente, e conforme o seu plugin fica maior e mais complexo, a probabilidade de se deparar com funcionalidades problemáticas aumenta. Portanto, geralmente recomendamos que você execute seus plugins personalizados exclusivamente no tipo do ASF `generic`. Você ainda pode verificar manualmente que a compilação específica do Sistema Operacional do ASF tem tudo o que o seu plugin necessita para funcionar - mas como isso muda tanto para suas atualizações como para as nossas, poderá ser um desafio mantê-lo.