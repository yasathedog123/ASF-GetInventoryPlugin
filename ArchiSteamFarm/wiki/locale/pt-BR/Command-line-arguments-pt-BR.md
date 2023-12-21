# Argumentos de linha de comando

O ASF inclui suporte para vários argumentos de linha de comando que podem afetar o tempo de execução do programa. Eles podem ser usados por usuários avançados para especificar como o programa deve ser executado. Em comparação com a forma padrão do arquivo de configuração `ASF.json`, argumentos de linha de comando são usados para a inicialização do núcleo (por exemplo, `--path`), configurações específicas de plataforma (por exemplo, `--system-required`) ou dados confidenciais (por exemplo, `--cryptkey`).

---

## Uso

O uso depende do seu sistema operacional e da versão do ASF.

Genérico:

```shell
dotnet ArchiSteamFarm.dll --argumento --segundoArgumento
```

Windows:

```powershell
.\ArchiSteamFarm.exe --argumento --segundoArgumento
```

Linux/macOS:

```shell
./ArchiSteamFarm --argumento --segundoArgumento
```

Argumentos de linha de comando também são suportados em códigos auxiliares genéricos como `ArchiSteamFarm.cmd` ou `ArchiSteamFarm.sh`. Além disso, você também pode usar a propriedade de ambiente `ASF_ARGS`, como descrito em nossas seções **[gerenciamento](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#environment-variables)** e **[docker](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Docker-pt-BR#argumentos-de-linha-de-comando)**.

Se seu argumento inclui espaços, não se esqueça de colocar entre aspas. Esses dois estão errados:

```shell
./ArchiSteamFarm --path /home/archi/My Downloads/ASF # Não funciona!
./ArchiSteamFarm --path=/home/archi/My Downloads/ASF # Não funciona!
```

No entanto, esses dois estão completamente corretos:

```shell
./ArchiSteamFarm --path "/home/archi/My Downloads/ASF" # OK
./ArchiSteamFarm "--path=/home/archi/My Downloads/ASF" # OK
```

## Argumentos

`--cryptkey <key>` ou `--cryptkey=<key>` - inicializará o ASF com um valor de chave de criptografia `<key>` personalizado. Essa opção afeta a **[segurança](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security-pt-BR)** e fará com que o ASF use a chave personalizada `<key>` que você fornecer ao invés da que está codificada no executável. Uma vez que essa propriedade afeta a chave de criptografia padrão (para fins de criptografia), bem como o sal (para fins de hashing), tenha em mente que tudo o que for criptografado/"hasheado" com essa chave exigirá que ela seja ativada toda vez que o ASF for executado.

Não há requisitos quanto ao comprimento ou caracteres de `<key>`, mas por motivos de segurança, recomendamos escolher uma frase secreta longa o suficiente, por exemplo, com 32 caracteres aleatórios, como o comando `tr -dc A-Za-z0-9 < /dev/urandom | head -c 32; echo` no Linux.

É bom mencionar que também existem duas outras formas de fornecer esse detalhe: `--cryptkey-file` e `--input-cryptkey`.

Devido à natureza desta propriedade, também é possível definir a cryptkey declarando a variável de ambiente `ASF_CRYPTKEY`, que pode ser mais apropriada para pessoas que gostariam de evitar dados confidenciais nos argumentos do processo.

---

`--cryptkey-file <path>` ou `--cryptkey-file=<path>` - inicializará o ASF com uma chave de criptografia personalizado lida à partir do arquivo `<path>`. Isso tem a mesma função que `--cryptkey <key>` explicado acima, apenas o mecanismo difere, já que esta propriedade vai ler a `<key>` dà partir do `<path>` indicado. If you're using this together with `--path`, consider declaring `--path` first so relative paths can work correctly.

Devido à natureza desta propriedade, também é possível definir ao arquivo cryptkey' declarando a variável de ambiente `ASF_CRYPTKEY_FILE`, que pode ser mais apropriada para pessoas que gostariam de evitar dados confidenciais nos argumentos do processo.

---

`--ignore-unsupported-environment` - fará com que o ASF ignore problemas decorrentes de rodar em um ambiente não suportado, o que geralmente é sinalizado com um erro e uma saída forçada. Unsupported environment includes for example running `win-x64` OS-specific build on `linux-x64`. Esse sinalizador permitirá que o ASF tente rodar em tais cenários, esteja ciente de que não damos suporte a isso e que você está forçando o ASF a fazer isso **por sua conta e risco**. As of today, **all** of the unsupported environment scenarios can be corrected. Recomendamos intensamente resolver os problemas pendentes em vez de declarar este argumento.

---

`--input-cryptkey` - fará com que ASF pergunte sobre a `--cryptkey` durante a inicialização. Essa opção pode ser útil para você se ao invés de fornecer a 'criptkey', seja em variáveis de ambiente ou em um arquivo, você prefira não tê-la salva em nenhum lugar e, em vez disso, colocá-la manualmente cada vez que o ASF for executado.

---

`--minimized` - fará a janela de console do ASF minimizar logo após a inicialização. Útil principalmente quando o programa iniciar automaticamente, mas também pode ser usado em outras situações. Atualmente essa opção só tem efeito no Windows.

---

`--network-group <group>` ou `--network-group=<group>` - fará com que o ASF inicie seus limitadores com um grupo personalizado adicional com o valor `<group>`. Esta opção afeta a execução do ASF em **[múltiplas instâncias](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management-pt-BR#multiplas-instancias)**, sinalizando que determinada instância depende apenas do compartilhamento do mesmo grupo de rede, e não do resto. Normalmente você vai querer usar essa propriedade somente se você estiver roteando pedidos do ASF através de um mecanismo personalizado (por exemplo, endereços IP diferentes) e você deseja definir grupos de rede você mesmo, sem depender do ASF para fazer isso automaticamente (o que atualmente leva em conta apenas o `WebProxy`). Tenha em mente que ao usar um grupo de rede personalizada este identificador é exclusivo dentro da máquina local, e o ASF não levará em conta nenhum outro detalhe, como o valor do `WebProxy`, permitindo que você, por exemplo, inicie duas instâncias com diferentes valores de `WebProxy` que ainda são dependentes um do outro.

Devido à natureza desta propriedade, também é possível definir o valor declarando a variável de ambiente `ASF_NETWORK_GROUP`, que pode ser mais apropriada para pessoas que gostariam de evitar dados confidenciais nos argumentos do processo.

---

`--no-config-migrate` - por padrão o ASF vai migrar automaticamente sua configuração para sintaxe mais recente. A migração inclui a conversão de propriedades obsoletas para as mais recentes, exeto as propriedades com valores padrão (já que elas não têm efeito), além de limpar o arquivo de uma forma geral (corrigindo indentação e coisas do tipo). Essa é quase sempre uma boa ideia, mas você pode ter uma situação em particular onde você prefira que o ASF não substitua os arquivos de configuração automaticamente. Por exemplo, você pode querer usar `chmod 400` eu seus arquivos de configuração (permissão de leitura apenas para o proprietário) ou colocar `chattr +i` sobre ele, negando acesso de escrita para todos como uma medidad e segurança. Recomendamos manter a migração de configuração ativa, mas se você tem algum motivo para desativá-la, você pode usar esta configuração.

---

`--no-config-watch` - por padrão o ASF seta um `FileSystemWatcher` na pasta `config` para monitorar qualquer alteração nos arquivos, podento então se adaptar e essas mudanças. Por exemplo, isso inclui parar os bots caso alguma configuração seja apagada, reiniciar o bot quando a configuração for alterada, ou carregar os códigos de produto para o **[BGR](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer)** se você salvá-las na pasta `config`. Essa opção permite que você desative esse comportamento fazendo com que o ASF ignore completamente todas as mudanças na pasta `config`, exigindo que você faça tais ações manualmente se considerar necessário (o que normalmente significa reiniciar o processo). Recomendamos manter os eventos de configuração ativos, mas se você tem algum motivo para desativá-los, você pode usar esta configuração para esse fim.

---

`--no-restart` - Esta opção é usada principalmente por nossos contêineres do **[docker](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Docker-pt-BR)** e forçam o `AutoRestart` para `false`. A menos que você tenha uma necessidade específica, você deve configurar a propriedade `AutoRestart` diretamente na sua configuração. Essa opção está aqui para que nosso script docker não precise tocar na sua configuração global para adaptá-la ao seu próprio ambiente. Claro, se você estiver executando o ASF dentro de um código, você também pode fazer uso desta opção (caso contrário é melhor usar a propriedade de configuração global).

---

`--no-steam-parental-generation` - por padrão o ASF tentará gerar automaticamente os códigos de acesso do Modo Família, conforme descrito na propriedade de configuração **<a href="https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-pt-BR#steamparentalcode>`SteamParentalCode`</a>**. No entanto, uma vez que isso pode exigir uma quantidade excessiva de recursos do Sistema Operacional, esta opção permite que você desative esse comportamento, o que fará com que o ASF pule a geração automática e peça o código de acesso diretamente ao usuário, o que normalmente só aconteceria se a geração automática falhasse. Recomendamos manter a geração ativa, mas se você tem algum motivo para desativá-la, você pode usar esta configuração.

---

`--path <path>` or `--path=<path>` - o ASF sempre navega até a sua própria pasta na inicialização. Ao especificar esse argumento, o ASF navegará até a pasta selecionada ao inicializar, o que permite que você use caminhos personalizados para várias partes do aplicativo (incluindo as pastas `config`, `plugins` e `www`, assim como o arquivo `NLog.config`) sem a necessidade de duplicar o executável no mesmo lugar. Isso pode ser especialmente útil se você quiser separar os arquivos executáveis dos arquivos de configuração, como nos pacotes do Linux; desta forma, você pode usar um arquivo executável (atualizado) com várias configurações diferentes. O caminho pode tanto ser relativo de acordo com o local atual do executável do ASF, ou absoluto. Tenha em mente que esse comando aponta para o novo "diretório base do ASF" - o diretório que possui a mesma estrutura do ASF original, com o diretório `config` em seu interior, veja o exemplo abaixo para explicação.

Devido à natureza desta propriedade, também é possível definir o caminho esperado declarando a variável de ambiente `ASF_PATH`, que pode ser mais apropriada para pessoas que gostariam de evitar dados confidenciais nos argumentos do processo.

Se você está pensando em usar esse argumento de linha de comando para executar várias instâncias do ASF, recomendamos ler nossa **[página de compatibilidade](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management-pt-BR#multiplas-instancias)**.

Exemplos:

```shell
dotnet /opt/ASF/ArchiSteamFarm.dll --path /opt/TargetDirectory # Caminho absoluto
dotnet /opt/ASF/ArchiSteamFarm.dll --path ../TargetDirectory # O caminho relativo também funciona
ASF_PATH=/opt/TargetDirectory dotnet /opt/ASF/ArchiSteamFarm.dll # O mesmo que as variáveis de ambiente
```

```text
├── /opt
│     ├── ASF
│     │     ├── ArchiSteamFarm.dll
│     │     └── ...
│     └── TargetDirectory
│           ├── config
│           ├── logs (gerado)
│           ├── plugins (opicional)
│           ├── www (opicional)
│           ├── log.txt (gerado)
│           └── NLog.config (opicional)
└── ...
```

---

`--process-required` - declarar este opção desabilitará o comportamento padrão do ASF de desligar quando nenhum bot estiver em execução. O fato dele não se desligar é especialmente útil em combinação com o **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-pt-BR)**, onde a maioria dos usuários vai querer que os serviços web continuem sendo executados independente da quantidade de bots que estejam habilitados. Se você estiver usando a opção IPC ou precisa que o processo ASF seja executado o tempo todo até que você mesmo o feche, esta é a opção certa.

Se você não pretende usar o IPC, esta opção será um tanto inútil já que você pode simplesmente iniciar o processo novamente quando necessário (ao contrário do servidor web do ASF, onde você precisa que ele esteja sempre preparado para receber comandos).

---

`--service` - esta opção é usada principalmente pelo nosso serviço `systemd` e força o `Headless` para `true`. A menos que você tenha uma necessidade específica, você deve marcar a propriedade `Headless` diretamente na sua configuração. Essa opção está aqui para que nosso serviço `systemd` não precise tocar na sua configuração global para adaptá-la ao seu próprio ambiente. Claro, se você tem uma necessidade semelhante, então você também pode fazer uso desta opção (caso contrário é melhor usar a propriedade de configuração global).

---

`--system-required` - declarar esse opção fará com que o ASF tente sinalizar para o sistema operacional que o processo precisa que o sistema continue rodando o tempo todo. Atualmente essa opção tem efeito apenas no Windows e ele previne que seu sistema entre no modo de suspensão enquanto o processo está sendo executado. Isso pode ser especialmente útil quando você deixar seu PC ou notebook coletando cartas durante a noite, pois o ASF será capaz de manter seu sistema ativo enquanto estiver coletando e, quando o ASF terminar, ele vai se desligar como de costume e permitir que seu sistema entre modo de suspensão novamente, economizando energia imediatamente após o termino da coleta.

Tenha em mente que para o ASF se desligar sozinho você precisa de outras configurações - especialmente evitar `--process-required` e garantir que todos os seus bots estão com `ShutdownOnFarmingFinished` habilitado. Claro, o desligamento automático é apenas uma possibilidade para este recurso e não uma exigência, já que você também pode usar esta opção juntamente com `--process-required` fazendo seu sistema ficar ativo infinitamente após iniciar o ASF.