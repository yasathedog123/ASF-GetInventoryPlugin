# Compilação

Compilação é o processo de criação de arquivo executável. É isso que você quer fazer se você quiser adicionar suas próprias mudanças ao ASF, ou se você, por alguma razão não confia em arquivos executáveis fornecidos em **[lançamentos](https://github.com/JustArchiNET/ArchiSteamFarm/releases)** oficiais. Se você é um usuário e não um desenvolvedor, é mais provável que você queira usar binários pré-compilados, mas se você quiser usar os seus próprios, ou aprender algo novo, continue a leitura.

O ASF pode ser compilado em qualquer plataforma suportada atualmente, desde que você tenha todas as ferramentas necessárias.

---

## SDK do .NET

Independentemente da plataforma, você precisa do SDK do .NET completo (e não apenas o runtime) para compilar o ASF. Instruções de instalação podem ser encontradas na **[página de download do .NET](https://dotnet.microsoft.com/download)**. Você precisa instalar a versão apropriada do SDK do .NET Core para seu sistema operacional. Após a instalação bem sucedida, o comando `dotnet` deverá estar funcional e operante. Você pode verificar se ele funciona com: `dotnet --info`. Certifique-se também de que o seu SDK do .NET corresponde aos **[requisitos de tempo de execução](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility-pt-BR#requisitos-do-tempo-de-execu%C3%A7%C3%A3o)** do ASF.

---

## Compilação

Assumindo que você tenha o SDK .NET na versão apropriada, simplesmente navegue para o diretório raiz do ASF (copiado ou baixado e descompactado do repositório do ASF) e execute:

```shell

```

Se você estiver usando Linux/macOS, você pode usar o código `cc.sh`, que fará o mesmo de uma maneira um pouco mais complexa.

Se a compilação obteve sucesso você poderá encontrar a `source` da sua versão do ASF na pasta `out/generic`. Essa compilação é a mesma que a `genérica` do ASF, mas ela força o valor de `UpdateChannel` e `UpdatePeriod` para `0`, o que é o correto para versões auto compiladas.

### SO específico

Você também pode gerar um pacote .NET específico para OS se você tiver uma necessidade particular. Em geral, você não deverá fazer isso, pois você já compilou o tipo `genérico` que você pode rodar em seu já instalado tempo de execução .NET, que você usou para a compilação, mas caso você queira:

```shell

```

Claro, troque `linux-x64` pela arquitetura de SO que você quer atender, tal como `win-x64`. Essa compilação também terá as atualizações desabilitadas.

### ASF-ui

Enquanto os passos acima são tudo o que é necessário para ter uma compilação totalmente funcional do ASF, você *também* pode estar interessado em compilar a **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)**, nossa interface gráfica web. Do lado do ASF, tudo o que você precisa fazer é colocar a saída da compilação ASF-ui no local padrão `ASF-ui/dist` e então compilar o ASF com ela (novamente, se necessário).

A ASF-ui é parte da árvore raíz do ASF como um **[submódulo git](https://git-scm.com/book/en/v2/Git-Tools-Submodules)**, certifique-se de ter clonado o repositório com `git clone --recursive`, caso contrário, você não terá os arquivos necessários. Você também precisará de um NPM funcional, o **[Node.js](https://nodejs.org)** vem com ele. Se você estiver usando Linux/macOS, recomendamos o nosso script `cc.sh`, que irá cobrir automaticamente a compilação e o envio da ASF-ui (se possível, isto é, se você estiver cumprindo os requisitos que acabamos de mencionar).

Além do script `cc.sh`, também anexamos as instruções de compilação simplificadas abaixo, consulte o **[repositório ASF-ui](https://github.com/JustArchiNET/ASF-ui)** para documentação adicional. Da árvore raíz do ASF, como antes, execute os seguintes comandos:

```shell

```

Agora você deve encontrar os arquivos da ASF-ui na pasta `out/generic/www`. O ASF será capaz de enviar esses arquivos para o seu navegador.

Como alternativa, você pode simplesmente compilar o ASF-ui, seja manualmente ou com a ajuda do nosso repositório, então copiar o resultado da compilação para a pasta `${OUT}/www` manualmente, onde `${OUT}` é a pasta de saída do ASF que você especificou com o parâmetro `-o`. É exatamente isso que o ASF faz como parte do processo de compilação, ela copia o `ASF-ui/dist` (se existir) para `${OUT}/www`, nada demais.

---

## Desenvolvimento

Se você quiser editar o código do ASF, você pode usar qualquer IDE compatível com o .NET, embora até mesmo isso seja opcional, uma vez que você pode editar em um bloco de notas e compilar com o comando `dotnet` descrito acima. Mesmo assim, para o Windows nós recomendamos **[o Visual Studio mais recente](https://visualstudio.microsoft.com/downloads)** (a versão comunidade é mais que o suficiente, e é gratuita).

Se, em vez disso, você quiser trabalhar com o código ASF no Linux/macOS, recomendamos o **[Visual Studio Code](https://code.visualstudio.com/download)** mais recente. Ele não é tão rico quanto o Visual Studio clássico, mas é bom o suficiente.

Claro que todas as sugestões acima são apenas recomendações, você pode usar o que quiser, tudo se resume ao comando `dotnet build` de qualquer maneira. Nós usamos o **[Rider da Jetbrains](https://www.jetbrains.com/rider)** para o desenvolvimento do ASF, embora não seja uma solução gratuita.

---

## Marcadores

Não é garantido que a ramificação `main` esteja em um estado que propicie uma compilação bem sucedida ou uma execução sem falhas do ASF, uma vez que é uma ramificação em desenvolvimento, confirme especificado em nosso **[ciclo de lançamentos](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Release-cycle)**. Se você deseja compilar ou referenciar o ASF desde a fonte, então você deve usar a **[tag](https://github.com/JustArchiNET/ArchiSteamFarm/tags)** apropriada para tal, o que garante ao menos uma compilação bem sucedida, e muito provavelmente uma execução sem erros (se a compilação foi marcada como versão estável). Para verificar a "saúde" atual da árvore, você pode usar nossa CI: **[GitHub](https://github.com/JustArchiNET/ArchiSteamFarm/actions/workflows/ci.yml?query=branch%3Amain)**.

---

## Versões oficiais

As versões oficiais do ASF são compiladas pelo **[GitHub](https://github.com/JustArchiNET/ArchiSteamFarm/actions)**, com a última versão do .NET SDK que corresponde aos **[requisitos de execução](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility-pt-BR#requisitos-do-tempo-de-execução)** do ASF. Depois de passar nos testes, todos os pacotes são implantados no lançamento, assim como no GitHub. Isto também garante transparência, pois o GitHub sempre usa uma fonte pública oficial para todas as compilações, e você pode comparar as somas de verificação (checksums) dos artefatos do GitHub com os ativos lançados no GitHub. Os desenvolvedores do ASF não compilam ou publicam as compilações por conta própria, exceto para o processo de desenvolvimento privado e depuração.

Além disso, os contribuidores do ASF mantém a validação manual e publica das "checksums" (somas de verificação de compilação) independentes do GitHub, um servidor remoto do ASF, como medida adicional de segurança. Esta etapa é obrigatória para que as versões do ASFs existentes sejam consideradas como um candidato válido para a funcionalidade de atualização automática.