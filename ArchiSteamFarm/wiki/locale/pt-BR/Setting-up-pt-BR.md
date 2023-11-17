# Primeiros passos

Se você está aqui pela primeira vez, bem-vindo! Estamos felizes em saber que outro viajante está interessado em nosso projeto, no entanto tenha em mente que grandes poderes trazem grandes responsabilidades; o ASF é capaz de fazer muitas coisas relacionadas ao Steam, mas somente enquanto você se **preocupar em aprender como usá-lo**. Há uma curva de aprendizagem aqui e esperamos que você leia a wiki a este respeito, que explica detalhadamente como tudo funciona.

Se você ainda está aqui significa que você suportou o texto acima, o que é bom. A não ser que você tenha pulado ele, então você vai ter alguns **[problemas](https://www.youtube.com/watch?v=WJgt6m6njVw)** logo mais... De qualquer forma, o ASF é um aplicativo de console, o que significa que o programa não tem uma interface amigável que você geralmente está acostumado, ao menos não a princípio. O ASF foi projetado principalmente para ser executado em servidores e, portanto, funciona como um serviço (daemon) e não como um aplicativo da área de trabalho.

Isso não significa que você não possa usá-lo no seu computador ou que o uso é mais complicado que o normal, não é nada disso. O ASF é um programa autônomo que funciona imediatamente e não necessita de instalação, mas necessita de uma configuração para se tornar útil. É a configuração que vai dizer ao ASF o que ele deve fazer depois que você executá-lo. Se você o iniciar sem configurar antes ele simplesmente não fará nada.

---

## Instalador para sistemas operacionais específicos

Em geral, é isso que vamos fazer nos próximos minutos:
- Instalar os **[pré-requisitos do .NET](#net-prerequisites)**.
- Baixar a **[última versão do ASF](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** na versão correta para o seu SO.
- Extrair o arquivo para um novo local.
- **[Configurar o ASF](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-pt-BR)**.
- Executar o ASF e ver a mágica.

Parece simples o bastante, certo? Então, vamos ver.

---

### Pré-requisitos do .NET

O primeiro passo é garantir que seu sistema operacional pode mesmo executar o ASF corretamente. O ASF é escrito em C#, baseado na plataforma .NET e pode requerer bibliotecas nativas que ainda não estão disponíveis na sua plataforma. Depending on whether you use Windows, Linux or macOS, you will have different requirements, although all of them are listed in **[.NET prerequisites](https://docs.microsoft.com/dotnet/core/install)** document that you should follow. Esse é nosso material de referência e ele deve ser usado, mas para simplificar nós detalhamos todos os pacotes necessários abaixo para que você não precise ler todo o documento.

É perfeitamente normal que algumas dependências (ou mesmo todas) já tenham sido instaladas no seu sistema por algum outro software que você use. Ainda assim, você deve garantir executando o instalador apropriado para seu sistema operacional - sem essas dependências o ASF não vai nem iniciar.

Keep in mind that you don't need to do anything else for OS-specific builds, especially installing .NET SDK or even runtime, since OS-specific package includes all of that already. You need only .NET prerequisites (dependencies) to run .NET runtime included in ASF.

#### **[Windows](https://docs.microsoft.com/dotnet/core/install/windows)**:
- **[Microsoft Visual C++ Redistributable Update](https://docs.microsoft.com/cpp/windows/latest-supported-vc-redist?view=msvc-170#visual-studio-2015-2017-2019-and-2022)** (**[x64](https://aka.ms/vs/17/release/vc_redist.x64.exe)** para Windows 64-bit, **[x86](https://aka.ms/vs/17/release/vc_redist.x86.exe)** para Windows 32-bit)
- É altamente recomendado garantir que todas as atualizações do Windows estejam instaladas. Você precisa pelo menos das atualizações **[KB2533623](https://support.microsoft.com/pt-br/help/2533623/microsoft-security-advisory-insecure-library-loading-could-allow-remot)** e **[KB2999226](https://support.microsoft.com/pt-br/help/2999226/update-for-universal-c-runtime-in-windows)**, mas outras atualizações podem ser necessárias. Todas elas já estarão instaladas se o seu Windows estiver atualizado. Certifique-se de que você atende a esses requisitos antes de instalar o pacote do Visual C++.

#### **[Linux](https://docs.microsoft.com/dotnet/core/install/linux)**:
Os nomes dos pacotes dependem da distribuição do Linux que você esteja usando, nós listamos as mais comuns. Você pode obter todas elas com o gerenciador de pacotes nativo do seu SO (como `apt` para Debian ou `yum` por CentOS).

- `ca-certificates` (certificados SSL padrão confiáveis para fazer conexões HTTPS)
- `libc6` (`libc`)
- `libgcc1` (`libgcc`)
- `libicu` (`icu-libs`, versão mais recente para a sua distribuição, por exemplo `libicu67`)
- `libgssapi-krb5-2` (`libkrb5-3`, `krb5-libs`)
- `libssl1.1` (`libssl`, `openssl-libs`, versão mais recente para a sua distribuição, pelo menos `1.1.X`, já que a `1.0.X` pode não funcionar mais)
- `libstdc++6` (`libstdc++`, na versão `5.0` ou superior)
- `zlib1g` (`zlib`)

Pelo menos a maioria deles já deve estar disponível nativamente no seu sistema. A instalação mínima do Debian estável requer apenas `libicu67`.

#### **[macOS](https://docs.microsoft.com/dotnet/core/install/macos)**:
- None for now, but you should have latest version of macOS installed, at least 10.15+

---

### Baixando

Uma vez que já tenhamos todas as dependências, o próximo passo é baixar a **[última versão do ASF](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)**. ASF está disponível em diversas variantes, mas você está interessado no pacote que corresponde ao seu sistema operacional e a arquitetura dele. Por exemplo, se você estiver usando o `Win`dows `64`-bit, então você vai baixar o pacote `ASF-win-x64`. Para obter mais informações sobre as variantes disponíveis, visite a seção</strong> **[compatibilidade](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility-pt-BR). O ASF é também capaz de rodar em SOs para os quais ele não tem um pacote específico, tal como o **Windows 32-bit**, vá até **[configuração genérica](#configuração-genérica)** para saber mais. </p>

![Arquivos](https://i.imgur.com/Ym2xPE5.png)

Após o download, comece extraindo o arquivo zip para sua própria pasta. If you require specific tool for that, **[7-zip](https://www.7-zip.org)** will do it, but all standard utilities like `unzip` from Linux/macOS should work without problems as well.

Certifique-se de descompactar o ASF para a **sua própria pasta** e não para outra existente que você esteja usando para outra coisa - as atualizações automáticas do ASF vão excluir todos os arquivos velhos e não relacionados, o que vao fazer você perder qualquer coisa não relacionada que esteja na mesma pasta. Se você tiver qualquer scripts ou arquivos extras que você quer usar com o ASF, coloque-os uma pasta acima.

Uma exemplo de extrutura seria assim:

```text
C:\ASF (onde você coloca suas coisas)
    ├── ASF shortcut.lnk (opcional)
    ├── Config shortcut.lnk (opcional)
    ├── Commands.txt (opcional)
    ├── MyExtraScript.bat (opcional)
    ├── (...) (quaisquer outros arquivos que quiser, opcional)
    └── Core (dedicado apenas ao ASF, onde você extrai os arquivos)
         ├── ArchiSteamFarm(.exe)
         ├── config
         ├── logs
         ├── plugins
         └── (...)
```

---

### Configuração

Agora estamos prontos para a última etapa, a configuração. Este é de longe o passo mais complicado, uma vez que envolve um monte de informações com as quais você ainda não está familiarizado, então vamos tentar fornecer alguns exemplos fáceis de entender e uma explicação simplificada.

Primeiro e mais importante, há uma página dedicada a **[configuração](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-pt-BR)** que explica **tudo** relacionado a isso, mas ela contém uma enorme quantidade de informações e a maioria não precisamos saber de imediato. Em vez disso, nós ensinaremos a você como obter as informações que você está procurando.

A configuração de ASF pode ser feita de três formas - usando nosso gerador de configuração web, o ASF-ui ou manualmente. Isto é explicado profundamente na seção **[configuração](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-pt-BR)**, consulte-a se você quer informações mais detalhadas. Nós vamos começar com o gerador de configuração web.

Navegue até a página do nosso **[gerador de configuração web](https://justarchinet.github.io/ASF-WebConfigGenerator)** com o seu navegador favorito, você precisará ter o javascript habilitado no caso de você tê-lo desativado manualmente. Recomendamos o Chrome ou o Firefox, mas ele deve funcionar em todos os navegadores mais populares.

Depois de abrir a página, vá até a guia "Bot". Você verá uma página semelhante a mostrada abaixo:

![Aba bot](https://i.imgur.com/aF3k8Rg.png)

Se por acaso a versão do ASF que você acabou de baixar é mais velha que a versão que o gerador de configuração está definido para usar por padrão, escolha a sua versão ASF no menu suspenso. Isso acontece porque ele pode gerar configurações para as versões mais novas (pré-lançamentos) do ASF que ainda não foram marcadas como estáveis. Você certamente baixou a última versão estável do ASF, que é verificada para trabalhar de forma confiável.

Comece colocando o nome que você quer dar ao bot no campo marcado em vermelho. Pode ser qualquer nome que você quiser, tais como seu apelido, nome da conta, um número ou qualquer outra coisa. Há apenas uma palavra que você não pode usar: `ASF`, pois esse nome é reservado para o arquivo de configuração global. Além disso, o nome não pode começar com um ponto (o ASF ignora esses arquivos). Também recomendamos que você evite usar espaços, você pode usar `_` como espaçamento, se necessário.

Depois que você escolheu um nome, ative o botão `Enabled`, ele define se o ASF deve iniciar seu bot automaticamente quando ele (o programa) for aberto.

Agora você pode decidir sobre duas coisas:
- Você pode por seu login no campo `SteamLogin` e sua senha no campo `SteamPassword`
- Ou pode deixá-los em branco

A primeira vai permitir que o ASF use suas credenciais de conta automaticamente durante a inicialização, então você não precisará colocá-las manualmente cada vez que ASF necessite. Você pode, no entanto, decidir omiti-las e nesse caso elas não serão salvas, mas assim o ASF não será capaz de iniciar automaticamente sem a sua ajuda e você precisará entrar com esses durante o tempo de execução.

O ASF precisa de suas credenciais porque inclui a sua própria implementação do cliente Steam e precisa dos mesmos dados que você usa para se conectar. Suas credenciais de login não são salvas em nenhum lugar além da pasta `config` do ASF no seu próprio PC, nosso gerador de configuração web é baseado no cliente, o que significa que seu código roda localmente no seu navegador para gerar as configurações válidas, sem que os dados que você entra deixem seu PC de forma alguma, então não precisa se preocupar com qualquer possibilidade de vazamento de dados. Ainda assim, se por qualquer motivo você não quer colocar seus dados lá, nós entendemos, você pode colocá-los manualmente mais tarde nos arquivos gerados ou omiti-los totalmente e colocá-los somente no prompt de comando do ASF. Mais informações sobre segurança podem ser encontradas na seção **[configuração](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-pt-BR)**.

Você também pode optar por deixar apenas um campo vazio, como `SteamPassword` por exemplo, o ASF então será capaz de usar seu login automaticamente, mas ainda vai pedir a senha (semelhante ao cliente Steam). Se você usa o PIN do modo família para desbloquear a conta você precisará ira para as configurações avançadas e colocá-lo no campo `SteamParentalCode`.

Depois que você fizer suas decisões sobre dados opcionais, sua página estará semelhante a abaixo:

![Aba bot 2](https://i.imgur.com/yf54Ouc.png)

Agora você pode clicar em "baixar" e o gerador de configuração web vai gerar um arquivo `json` com o nome que você escolheu. Salve o arquivo na pasta `config` que está localizado na pasta onde você extraiu nosso arquivo zip na etapa anterior.

Sua pasta `config` ficará assim:

![Estrutura 2](https://i.imgur.com/crWdjcp.png)

Parabéns! Você acabou de terminar a configuração básica de um bot ASF. Nós vamos ampliar isso em breve, mas por enquanto isso é tudo o que você precisa saber.

---

### Executando o ASF

Agora você está pronto para abrir o programa pela primeira vez. Simplesmente clique duas vezes no executável `ArchiSteamFarm` na pasta ASF. You can also start it from the console.

Depois disso, supondo que você instalou todas as dependências listadas na primeira etapa, o ASF deve iniciar corretamente, detectar seu primeiro bot (se você não se esqueceu de colocar o arquivo de configuração gerado na pasta `config`) e tentar se conectar:

![ASF](https://i.imgur.com/u5hrSFz.png)

Se você definiu o `SteamLogin` e o `SteamPassword` no arquivo de configuração, será solicitado apenas o seu token do SteamGuard (e-mail, 2FA ou nenhum, dependendo das configurações do Steam). Caso contrário o ASF também pedirá seu login e senha do Steam.

Now would be a good time to review our **[remote communication](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Remote-communication)** section if you're concerned about stuff ASF is programmed to do, including actions it'll take in your name, such as joining our Steam group.

After passing through initial login gate, assuming your details are correct, you'll successfully log in, and ASF will start farming using default settings that you didn't change as of now:

![ASF 2](https://i.imgur.com/Cb7DBl4.png)

Isso prova que o ASF está fazendo seu trabalho na sua conta, então você pode minimizá-lo e fazer outra coisa. Depois de decorrido algum tempo (dependendo do **[desempenho](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance)**) você verá as cartas aparecerem no seu inventário. Of course, for that to happen you must have valid games to farm, showing as "you can get X more card drops from playing this game" on your **[badges page](https://steamcommunity.com/my/badges)** - if there are no games to farm, then ASF will state that there is nothing to do, as stated in our **[FAQ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#what-is-asf)**.

Isso conclui nosso guia de configuração básica. Agora você pode decidir se deseja configurar o ASF ainda mais ou deixá-lo fazer seu trabalho com as configurações padrão. Vamos cobrir mais alguns detalhes básicos e, em seguida, deixar toda a wiki para você descobrir.

---

### Configuração estendida

#### Farming several accounts at once

ASF supports farming more than one account at a time, which is its primary function. Você pode adicionar mais contas ao ASF gerando mais arquivos de configuração de bot, exatamente da mesma forma que o primeiro foi gerado a poucos minutos atrás. Você precisa garantir apenas duas coisas:

- Um nome exclusivo para cada bot, se o seu primeiro bot se chama "ContaPrincipal", você não pode ter outro com o mesmo nome.
- Dados de login válidos, como `SteamLogin`, `SteamPassword,` e `SteamParentalCode` (se estiver usando o modo família do Steam)

Em outras palavras, simplesmente volte a configuração e faça exatamente a mesma coisa, só que dessa vez para a segunda ou terceira conta. Lembre-se de usar nomes exclusivos para todos os teus bots.

---

#### Alterando configurações

Você pode alterar as configurações existentes exatamente da mesma forma: gerando um novo arquivo de configuração. Se você não fechou o nosso gerador de configuração web ainda, clique em "Alternar configurações avançadas" e veja o que há para descobrir. For this tutorial we'll change `CustomGamePlayedWhileFarming` setting, which allows you to set custom name being displayed when ASF is farming, instead of showing actual game.

So let's do that, if you run ASF and start farming, in default settings you'll see that your Steam account is in-game now:

![Steam](https://i.imgur.com/1VCDrGC.png)

Vamos mudar isso. Vá para as configurações avançada do gerador de configuração web e encontre `CustomGamePlayedWhileFarming`. Coloque no campo o texto que você quer mostrar, por exemplo: "Idling Cards":

![Aba bot 3](https://i.imgur.com/gHqdEqb.png)

Agora baixe o arquivo de configuração da mesma forma que antes e **substitua** o arquivo antigo por esse. Você também pode apagar o antigo e colocar esse novo no lugar.

Assim que fizer isso e abrir o ASF novamente você vai perceber que o Steam agora mostra seu texto:

![Steam 2](https://i.imgur.com/vZg0G8P.png)

This confirms that you've successfully edited your config. In exactly the same way you can change global ASF properties, by switching from bot tab to "ASF" tab, downloading generated `ASF.json` config file and putting it in your `config` directory.

A edição das configurações do ASF pode ser feita de uma forma muito fácil usando nosso front-end ASF-ui, que será explicado abaixo.

---

#### Usando a ASF-ui

O ASF é um aplicativo de console e não inclui uma interface gráfica de usuário (GUI). No entanto, estamos trabalhando ativamente em nossa interface IPC, o **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-pt-BR#asf-ui)** que pode ser uma forma muito boa e amigável de acessar vários recursos do ASF.

In order to use ASF-ui, you need to have `IPC` enabled, which is the default option starting with ASF V5.1.0.0. Once you launch ASF, you should be able to confirm that it properly started the IPC interface automatically:

![IPC](https://i.imgur.com/ZmkO8pk.png)

Você pode acessar a interface IPC do ASF por **[esse](http://localhost:1242)** link, desde que o ASF esteja rodando no mesmo computador. Você pode usar a ASF-ui para muitas coisas como, por exemplo, editar os arquivos de configuração ou enviar **[comandos](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-pt-BR)**. Sinta-se a vontade para dar uma olhada e descobrir todas as funcionalidade da ASF-ui.

![ASF-ui](https://raw.githubusercontent.com/JustArchiNET/ASF-ui/main/.github/previews/bots.png)

---

### Resumo

Você já configurou com sucesso o ASF para que ele use suas contas Steam e você já o customizou um pouco a seu gosto. Se você seguiu o guia inteiro, então você também conseguiu ajustar o ASF através da nossa interface ASF-ui e descobriu que o ASF, na verdade, tem um tipo de interface gráfica. Agora é uma boa hora para ler a seção completa de **[configuração](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-pt-BR)** para aprender sobre todos os outros parâmetros que você viu na guia de configuração avançada e ver o que o ASF pode oferecer. Se você de deparou com algum problema ou você tem alguma pergunta genérica, leia a seção de **[perguntas frequentes (FAQ)](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ-pt-BR)** que deve cobrir tudo, ou pelo pelo menos a grande maioria das perguntas que você possa ter. Se você quer aprender tudo sobre o ASF e como le pode tornar sua vida mais fácil, visite o resto da nossa **[wiki](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Home-pt-BR)**. Se você achou que nosso programa é útil para você e está se sentindo generoso, você pode também considerar fazer uma doação para o nosso projeto. De qualquer forma, divirta-se!

---

## Configuração genérica

Esta configuração é para usuários avançados que desejam configurar a versão **[genérica](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility#generic)** do ASF. While being more troublesome in usage than **[OS-specific variants](#os-specific-setup)**, they also come with additional benefits.

Você deve preferir usar a variante `generic` (genérica) nessas situações (mas é claro você pode usá-la independentemente disso):
- Quando você estiver usando um sistema operacional para o qual não temos um pacote específico (como o Windows 32-bit, por exemplo)
- When you already have .NET Runtime/SDK, or want to install and use one
- When you want to minimize ASF structure size and memory footprint by handling runtime requirements yourself
- Quando você deseja usar um **[plugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)** personalizado que requer uma configuração `generic` do ASF para ser executado corretamente (devido à falta de dependências nativas)

However, keep in mind that you're in charge of .NET runtime in this case. This means that if your .NET SDK (runtime) is unavailable, outdated or broken, ASF won't work. This is why we don't recommend this setup for casual users, since you now need to ensure that your .NET SDK (runtime) matches ASF requirements and can run ASF, as opposed to **us** ensuring that our .NET runtime bundled with ASF can do so.

Para o pacote `generic` você pode acompanhar o guia de instalação para sistemas operacionais inteiro acima, com duas pequenas alterações. In addition to installing .NET prerequisites, you also want to install .NET SDK, and instead of having OS-specific `ArchiSteamFarm(.exe)` executable file, you now have a generic `ArchiSteamFarm.dll` binary only. Todo o resto permanece igual.

Com etapas extras:
- Instalar os **[pré-requisitos do .NET](#net-prerequisites)**.
- Instalar o **[.NET SDK](https://www.microsoft.com/net/download)** (ou pelo menos o ASP.NET Core runtime) apropriado para seu SO. Você provavelmente vai desejar usar um instalador. Confira os **[requisitos de tempo de execução](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility#runtime-requirements)** se você não tiver certeza de qual versão instalar.
- Baixar a **[última versão do ASF](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** na versão `generic`.
- Extrair o arquivo para um novo local.
- **[Configurar o ASF](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-pt-BR)**.
- Abra o ASF usando um script auxiliar ou executando `dotnet /path/to/ArchiSteamFarm.dll` manualmente pelo seu shell favorito.

Helper scripts (such as `ArchiSteamFarm.cmd` for Windows and `ArchiSteamFarm.sh` for Linux/macOS) are located next to `ArchiSteamFarm.dll` binary - those are included in `generic` variant only. Você pode usá-los se você não quer executar o comando `dotnet` manualmente. Obviamente os scripts de ajuda não funcionarão se você não instalar o .NET SDK e não tenha o executável `dotnet` disponível em seu `PATH`. Os scripts de ajuda são inteiramente opcionais, você pode sempre usar o método manual `dotnet /path/to/ArchiSteamFarm.dll`.