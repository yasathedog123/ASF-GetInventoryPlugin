# Compatibilidade

O ASF é um aplicativo C# que roda na plataforma .NET. Isso significa que o ASF não é compilado diretamente em **[código de máquina](https://pt.wikipedia.org/wiki/C%C3%B3digo_de_m%C3%A1quina)** que roda no seu CPU, mas em **[CIL](https://pt.wikipedia.org/wiki/Common_Intermediate_Language)**, que requer um tempo de execução compatível para a execução.

Esta abordagem tem uma quantidade gigantesca de vantagens pois a CIL não depende de plataforma, é por isso que o ASF pode funcionar nativamente em muitos sistemas operacionais disponíveis, especialmente no Windows, Linux e macOS. Além de não haver necessidade de emulação há ainda o suporte para todas as otimizações relacionadas à plataforma e hardware, tal como instruções CPU SSE. Graças a isso, o ASF pode alcançar desempenho e otimização superiores, enquanto continua a oferecer compatibilidade e confiabilidade perfeitos.

Isto também significa que o ASF **não tem nenhum requisito específico quanto ao Sistema Operacional**, porque ele exige um **tempo de execução** funcional no Sistema Operacional e não o Sistema Operacional em si. Desde que essa runtime esteja executando o código do ASF corretamente, não importa se o Sistema Operacional subjacente é Windows, Linux, macOS, BSD, Sony Playstation 4, Nintendo Wii ou sua torradeira - contanto que haja **[.NET para isso](https://dotnet.microsoft.com/download/dotnet)**, haverá um **[ASF](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** para isso (na variante `genérica`).

No entanto, independente de onde você executar o ASF, você deve garantir que sua plataforma de destino tenha os requisitos para o **[.NET](https://github.com/dotnet/core/blob/main/Documentation/prereqs.md)** instalados. Essas são bibliotecas de baixo nível necessárias para a funcionalidade adequada do tempo de execução e são primordiais para o funcionamento do ASF. É bem possível que você já tenha algumas delas (ou mesmo todas) já instaladas.

---

## Empacotamento do ASF

O ASF está disponível em 2 formas diferentes: pacote genérico e pacote específico para Sistema Operacional. Funcionalmente ambos os pacotes são exatamente o mesmo e ambos são capazes de se atualizarem automaticamente. A única diferença entre eles é se o pacote **genérico** do ASF acompanha ou não o tempo de execução **específico do Sistema Operacional** para rodar o mesmo.

---

### Genérico

O pacote genérico não depende de plataforma de compilação e não inclui nenhum código de máquina específico. Esta instalação requer que você tenha o tempo de execução .NET, **na versão apropriada**, já instalada no seu Sistema Operacional. Nós todos sabemos como é complicado manter dependências atualizadas, portanto este pacote existe principalmente para pessoas que **já usam o** .NET e não querem duplicar seu tempo de execução unicamente para o ASF, já que podem fazer uso do que eles já tem instalado. O pacote genérico também permite que você rode o ASF **em qualquer lugar em que você possa obter uma implementação funcional do tempo de execução .NET**, independente de existir ou não uma compilação do ASF específica para o Sistema Operacional.

Não se recomenda usar o tipo genérico se você quer apenas fazer o ASF funcionar, sendo um usuário casual ou avançado, e não quer entrar em detalhes técnicos do .NET. Em outras palavras: se você sabe o que ele é, você pode usá-lo, caso contrário é muito melhor usar o pacote específico para o seu Sistema Operacional, que será explicado abaixo.

#### Pacote do .NET Framework

Além do pacote genérico mencionado acima, há também um pacote `netf-genérico` que é construído em cima do .NET Framework e não do .NET (Core). Esse pacote é uma variante herdada que fornece compatibilidades que faltavam nos tempos do ASF V2, e pode rodar, por exemplo, com o **[Mono](https://www.mono-project.com)**, enquanto o pacote `genérico` .NET já não pode.

Em geral, você deve **evitar este pacote o quanto for possível**, já que a maioria dos sistemas operacionais e configurações são perfeitamente (e muito mais) compatíveis com o pacote `genérico` mencionado acima. Na verdade, só faz sentido usar esse pacote em plataformas que não tenham o tempo de execução .NET, e tenham uma implementação funcional do Mono. Exemplos de tais plataformas incluem `linux-x86` (linux i386/i686 32-bit), bem como `linux-armel` (placas ARMv6 encontradas, p. ex., no Raspberry Pi 0 & 1), todas que não tem um tempo de execução oficial .NET até hoje.

Conforme o tempo passa, com mais plataformas sendo suportadas pelo .NET, e com compatibilidade entre o .NET Framework e o .NET diminuindo, o pacote `genérico-netf` será inteiramente substituído pelo `genérico`. Por favor, evite usá-lo se você poder usar qualquer outro pacote .NET, já que hã um monte de funcionalidades e compatibilidades faltantes no pacote `genérico-netf` em comparação com as versões .NET, e ele será cada vez menos funcional com o passar do tempo. Oferecemos suporte para este pacote **apenas** em máquinas que não podem usar a variante `genérica` acima (por exemplo, o `linux-x86`) e somente com o tempo de execução atualizado (por exemplo, o Mono mais recente).

---

### Sistema Operacional específico

O pacote para Sistema Operacional específico, além do código gerenciado incluso no pacote genérico, também inclui código nativo para a plataforma em questão. Em outras palavras, o pacote para Sistema Operacional específico **já inclui o tempo de execução .NET apropriado**, que permite que você ignore inteiramente a bagunça toda da instalação e abra o ASF diretamente. O pacote para Sistema Operacional específico, como você pode adivinhar pelo nome, é específico para cada sistema operacional e cada um requer sua própria versão; por exemplo, o Windows requer o binário PE32 + `ArchiSteamFarm.exe`, enquanto o Linux trabalha com o binário Unix ELF `ArchiSteamFarm`. Como você deve saber, esses dois tipos não são compatíveis um com o outro.

ASF está atualmente disponível nas seguintes variantes específicas de Sistema Operacional:

- `linux-arm` compatível com sistemas operacionais GNU/Linux 32-bit baseados em ARM (ARMv7 +) com glibc 2.27 e posteriores. Esta variante cobre plataformas como o Raspberry Pi 2 (e mais novos), ela **não** funcionará com arquiteturas ARM antigas, como ARMv6 do Raspberry Pi 0 & 1, e também é incompatível com sistemas que não implementem o ambiente GNU/Linux exigido (como o sistema Android).
- `linux-arm64` compatível com sistemas operacionais GNU/Linux 64-bit baseados em ARM (ARMv8 +) com glibc 2.23/musl 1.2.2 e posteriores. Esta variante cobre plataformas como o Raspberry Pi 3 (e mais novos), ela **não** funcionará com sistemas de 32 bits que não tenham as bibliotecas de 64 bits exigidas (como o Raspberry Pi OS 32-bit), e não funcionará com sistemas que não implementem o ambiente GNU/Linux exigido (como o sistema Android).
- `linux-x64` compatível com Sistemas Operacionais GNU/Linux 64-bit com glibc 2.17/musl 1.2.2 e posteriores.
- `osx-arm64` compatível com o OS X de 64 bits baseados em ARM (Apple silicon) na versão 11 e posteriores.
- `osx-x64` compatível com o OS X 64-bit na versão 10.15 e posteriores.
- `win-arm64` compatível com o OS X de 64 bits baseados em ARM (ARMv8+) nas versões 10, 11 e posteriores.
- `osx-x64` compatível sistemas operacionais Windows de 64-bit nas versões 10, 11, Server 2012+ e posteriores.

Claro, mesmo que não haja um pacote de Sistema Operacional específico para a sua combinação de arquitetura de Sistema, você sempre pode instalar o tempo de execução .NET por sua conta e rodar o pacote genérico do ASF, que também é uma das principais razões para ele existir em primeiro lugar. O pacote genérico do ASF não depende de plataforma e será executado em qualquer plataforma que tenha o tempo de execução .NET funcional. Há algo importante de se notar: o ASF requer o tempo de execução .NET, não um Sistema Operacional ou arquitetura específicos. Por exemplo, se você estiver rodando o Windows de 32 bits, apesar de não haver versão do ASF dedicado `win-x86`, você pode instalar o .NET SDK na versão `win-x86` e rodar o ASF genérico tranquilamente. Nós simplesmente não podemos atender a todas as combinações de arquitetura de Sistemas Operacionais que existam e são usadas por alguém, então temos que traçar um limite em algum lugar. O x86 é um bom exemplo desse limite, já que é uma arquitetura obsoleta desde pelo menos 2004.

Para uma lista completa de todas as plataformas e Sistemas Operacionais suportados pelo .NET 7.0, visite as **[notas de lançamento](https://github.com/dotnet/core/blob/main/release-notes/7.0/supported-os.md)**.

---

## Requisitos do tempo de execução

Se você estiver usando um pacote para Sistema Operacional específico você não precisa se preocupar com requisitos de tempo de execução porque o ASF sempre acompanha o tempo de execução necessário e atualizado que funcionará corretamente, enquanto você tiver os **[pré-requisitos do.NET](https://github.com/dotnet/core/blob/main/Documentation/prereqs.md)** instalados e atualizados. Em outras palavras, **você não precisa instalar o tempo de execução ou o SDK .NET **, já que as compilações específicas de Sistema Operacional exigem apenas as dependências nativas (pré-requisitos) do sistema e nada mais.

No entanto, se você está tentando executar o pacote **genérico** do ASF, você deve garantir o que o seu tempo de execução .NET ofereça suporte a plataforma requerida pelo ASF.

O ASF, como programa, utiliza o **.NET 7.0** (`net7.0`), mas ele deve utilizar plataformas mais novas no futuro. O `net7.0` é suportado desde o SDK 7.0.100 (tempo de execução 7.0.0), porém o ASF deverã buscar o **tempo de execução mais recente na hora da compilação**, então você deve garantir que você tem a **[SDK mais recente](https://dotnet.microsoft.com/download)** (ou ao menos o tempo de execução) disponível para o seu computador. A variante genéria do ASF pode se recusar a iniciar se o seu tempo de execução for mais antigo que o mínimo especificado durante a compilação.

Em caso de dúvida, verifique o que nossa **[integração contínua usa](https://github.com/JustArchiNET/ArchiSteamFarm/actions/workflows/publish.yml?query=branch%3Amain)** para compilar e implantar as versões do ASF liberadas no GitHub. Você pode encontrar a saída `dotnet --info` em cada compilação como parte do passo de verificação do .NET.