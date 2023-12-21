# Docker

ASF is available as **[docker container](https://www.docker.com/what-container)**. Nossos pacotes docker estão disponíveis atualmente no **[ghcr.io](https://github.com/orgs/JustArchiNET/packages/container/archisteamfarm/versions)** e no **[Docker Hub](https://hub.docker.com/r/justarchi/archisteamfarm)**.

É importante notar que executar o ASF em um contêiner Docker é considerado uma **configuração avançada**, o que **não é necessário** para a grande maioria dos usuários, e normalmente não dá **nenhuma vantagem** sobre a configuração sem contêiner. Se você está considerando o Docker como uma solução para executar o ASF como serviço, por exemplo, fazendo com que ele inicie automaticamente junto com seu sistema operacional, então você deve considerar ler a seção de **[gerenciamento](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management-pt-BR#systemd-service-for-linux)** e configurar um serviço `systemd` adequado, o que será **quase sempre** uma ideia melhor que rodar o ASF em um contêiner Docker.

Executar o ASF em um contêiner Docker geralmente envolve **vários novos problemas ** que você terá que enfrentar e resolver por sua conta. É por isso que nós recomendamos **fortemente** que você evite isso, a menos que você já tenha conhecimento Docker e não precise de ajuda para entender seu funcionamento, sobre o que não vamos descrever aqui na wiki do ASF. Essa seção é principalmente para casos válidos de uso em setups muito complexos, por exemplo, no que diz respeito a configuração de rede avançada ou segurança além do pacote padrão que o ASF traz no serviço `systemd` (que já garante o isolamento de processo básico através de mecânicas de segurança muito avançadas). Para essa meia dúzia de pessoas explicamos melhor agora os conceitos do ASF em relação à sua compatibilidade com o Docker, e só isso, presume-se que você tem conhecimento adequado do Docker se você decidir usá-lo juntamente com o ASF.

---

## Marcadores

O ASF está disponível 4 tipos **[marcadores](https://hub.docker.com/r/justarchi/archisteamfarm/tags)** principais:


### `main`

Esse marcador aponta para a compilação do ASF no "commit" mais recente do ramo `main`, que é o mesmo que baixar o arquivo mais recente diretamente da nossa pipeline **[CI](https://github.com/JustArchiNET/ArchiSteamFarm/actions/workflows/publish.yml?query=branch%3Amain)**. Normalmente você deve evitar essa versão, já que ela contém o nível mais elevado de software com erros, dedicado para desenvolvedores e usuários avançados para fins de desenvolvimento. A imagem é atualizada a cada commit no ramo `main` do GitHub, portanto você pode esperar por muitas atualizações (e coisas falhando). Esse marcador está aqui para anotarmos o estado atual do projeto ASF, que não tem necessariamente garantia de ser estável ou testado, como salientado no nosso ciclo de lançamento. Esse marcador não deve ser usado em nenhum ambiente de produção.


### `released`

Muito semelhante ao anterior, esse marcador sempre aponta para a **[versão](https://github.com/JustArchiNET/ArchiSteamFarm/releases)** mais recente do ASF, incluindo pré-lançamentos. Comparado ao marcador `main`, essa imagem é atualizada toda vez que um novo marcador é criado no GitHub. Dedicado a usuários avançados que gostam de viver no limite do que pode ser considerado estável e mais novo ao mesmo tempo. Esse é o marcador que recomendamos se você não quer usar o `latest`. Na prática, esta versão é equivalente àquela que aponta para a versão `A.B.C.D` mais recente no momento da solicitação. Observe que usar esse marcador é igual a usar o **[pre-lançamentos](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Release-cycle)**.


### `latest`

Esta tag é a única que inclui o recurso de atualizações automáticas e aponta para a última versão **[estável](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** do ASF. O objetivo dessa tag é fornecer um contêiner Docker padrão que é capaz de executar a atualização automática do ASF na versão específica de OS. Por conta disso, a imagem não precisa ser atualizada tão frequentemente, já que a versão inclusa do ASF será capaz de se atualizar automaticamente sempre que preciso. Claro, `UpdatePeriod` pode ser desabilitado sem problemas (definido para `0`), mas neste caso é melhor usar a versão congelada `A.B.C.D`. Da mesma forma, você pode modificar o `UpdateChannel` padrão para o canal de atualização automática `released`.

Devido ao fato de que a imagem `latest` vem com a capacidade de atualização automática, ela inclui um Sistema Operacional básico com a versão `linux` especifica do ASF, ao contrário das outras tags que incluem a SO com tempo de execução .NET Core principal e versão a `generic` do ASF. Isso acontece porque a versão mais recente do ASF (atualizada) também pode exigir um tempo de execução mais recente do que aquele com que a imagem possivelmente pode ter sido compilada, o que exigiria que a imagem fosse reconstruída do zero, anulando o tipo de uso planejado.

### `A.B.C.D`

Em comparação com os marcadores acima, esse marcador é completamente congelado, o que significa que a imagem não será atualizada uma vez que foi lançada. Ele funciona de forma semelhante as nossas versões do GitHub que nunca mais foram tocadas após o lançamento, o que te garante um ambiente estável e congelado. Normalmente você deverá usar esse marcador quando você quer usar uma versão específica do ASF e você não quer usar nenhum tipo de atualização automática (por exemplo, as oferecidas no marcador `latest`).

---

## Qual o melhor marcador para mim?

Isso depende do que você procura. Para a maioria dos usuários o marcador `latest` deve ser o melhor, uma vez que ele oferece exatamente a mesma coisa que o ASF da área de trabalho oferece, com a diferença do serviço especial do contêiner Docker. Pessoas que recompilam suas imagens com frequência e preferirem ter controle total com o ASF amarrada a determinada versão são bem vindas a usar o marcador `released`. Se, ao invés disso, você preferir usar uma versão congelada específica do ASF que nunca vai mudar sem a sua intenção, as versões `A.B.C.D.` estão disponíveis para você como marcas as quais você sempre pode voltar.

Nós geralmente desencorajamos o uso de compilações `main`, já que essas compilações estão aqui para marcarmos o estado atual do projeto ASF. Nada garante que tal versão vai funcionar corretamente, mas é claro, você é mais que bem vindo para fazer um teste se estiver interessado no desenvolvimento do ASF.

---

## Arquiteturas

A imagem docker do ASF é compilada atualmente na plataforma `linux`, disponível em 3 arquiteturas: `x64`, `arm` e `arm64`. Você pode ler mais sobre elas em **[estatísticas](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility-pt-BR)**.

Our tags are using multi-platform manifest, which means that Docker installed on your machine will automatically select the proper image for your platform when pulling the image. Se por acaso você quiser baixar a imagem de alguma plataforma específica que não corresponde à que você está executando atualmente, você pode usar o switch `--platform` nos comandos docker apropriados, tal como `docker run`. Veja a documentação docker em **[image manifest](https://docs.docker.com/registry/spec/manifest-v2-2)** para mais informações.

---

## Uso

Para uma referência completa você deve usar a **[documentação docker oficial](https://docs.docker.com/engine/reference/commandline/docker)**, nós cobriremos apenas o uso básico nesse guia, você é mais que bem vindo a pesquisar mais a fundo.

### Olá ASF!

Primeiro devemos verificar se nosso docker está funcionando corretamente, isso funcionará como uma versão do ASF do "olá mundo":

```shell
docker run -it --name asf --pull always --rm justarchi/archisteamfarm
```

`docker run` cria um novo contêiner docker do ASF para você e o executa em primeiro plano (`-it`). `--pull always` garante que a imagem atualizada seja tirada primeiro, e `--rm` garante que nosso contêiner seja excluído assim que parado, já que por enquanto estamos apenas testando se está tudo certo.

Se tudo correu bem, após receber todas as camadas e iniciar o contêiner, você deverá notar que o ASF foi iniciado e nos informou que não há bots definidos, o que é bom; nós acabamos de verificar que o ASF funcionou corretamente no docker. Aperte `CTRL+P` e então `CTRL+Q` para sair do contêiner docker em primeiro plano, então pare o contêiner ASF com o comando `docker stop asf`.

Se você olhar para o comando você vai notar que nós não declaramos nenhum marcador, que automaticamente usa o padrão `latest`. Se você quiser usar uma tag que não seja a `latest`, a tag `released` por exemplo, então você deve declarar explicitamente:

```shell
docker run -it --name asf --pull always --rm justarchi/archisteamfarm:released
```

---

## Usando um volume

Se você estiver usando o ASF em um contêiner docker, então obviamente você precisa configurar o programa. Você pode fazer isso de diversas formas diferentes, mas a forma recomendada é criar a pasta `config` do ASF no computador local, então carregá-la como um volume compartilhado no contêiner docker do ASF.

Por exemplo, assumiremos que sua pasta config do ASF está no diretório `/home/archi/ASF/config`. Essa pasta contém o arquivo principal `ASF.json` bem como os bots que queremos executar. Agora tudo o que temos que fazer é anexar essa pasta como um volume compartilhado no nosso contêiner docker, onde o ASF espera sua pasta config (`/app/config`).

```shell
docker run -it -v /home/archi/ASF/config:/app/config --name asf --pull always justarchi/archisteamfarm
```

É isso, agora nosso contêiner docker do ASF usará a pasta compartilhada com nosso computador local em modo de leitura e gravação, isso é tudo o que você precisa para configurar o ASF. In similar way you can mount other volumes that you'd like to share with ASF, such as `/app/logs` or `/app/plugins/MyCustomPluginDirectory` (you don't want to override `/app/plugins` itself, since this way you'll remove plugins that ship with ASF by default).

Claro, essa é apenas uma forma específica de alcançar o resultado que queremos, nada te impede de, por exemplo, criar seu próprio `Dockerfile` que copie seus arquivos de configuração para a pasta `/app/config` dentro do contêiner docker do ASF. Estamos cobrindo apenas o uso básico nesse guia.

### Permissões de volume

O conteiner do ASF por padrão é inicializado como usuário `root`, que te permite a lidar com as permissões internas e, eventualmente, trocar para o usuário `asf` (UID `1000`) para a parte restante do processo principal. Embora isso deva ser satisfatório para a grande maioria dos usuários, isso afeta o volume compartilhado, já que os arquivos recém-gerados normalmente pertencerão ao usuário `asf`, que pode não ser a situação desejada se você quiser outro usuário para seu volume compartilhado.

O Docker te permite adicionar uma **[flag](https://docs.docker.com/engine/reference/run/#user)** `--user` no comando `docker run` para definir sob qual usuário padrão o ASF deve ser executado. Você pode verificar, por exemplo, seu `uid` e `gid` com o comando `id` e, em seguida, passar ao resto do comando. Por exemplo, se seu usuário alvo tem o valor 1001 de `uid` e `gid`:

```shell
docker run -it -u 1001:1001 -v /home/archi/ASF/config:/app/config --name asf --pull always justarchi/archisteamfarm
```

Não se esqueça que, por padrão, o diretório `/app` usado pelo ASF ainda pertence ao `asf`. Se você executar ASF sob um usuário personalizado, então seu processo ASF não terá acesso de gravação aos seus próprios arquivos. Este acesso não é obrigatório para a operação, mas é crucial, por exemplo, para o recurso de atualizações automáticas. Para corrigir isso, basta alterar a posse de todos os arquivos do ASF do `asf` padrão para o seu novo usuário personalizado.

```shell
docker exec -u root asf chown -hR 1001:1001 /app
```

Isso só tem que ser feito uma vez depois que você criou seu contêiner com `docker run`, e somente se você decidiu usar um usuário personalizada para o processo do ASF. Também não se esqueça de alterar o argumento `1001:1001` em ambos os comandos acima para o `uid` e `gid` sob o qual você deseja executar o ASF.

### Volume com SELinux

Se você estiver usando o SELinux no seu sistema operacional, que é padrão, por exemplo, em distribuições baseadas em RHEL, então você deve montar o volume anexando a opção `:Z`, que definirá o contexto correto do SELinux para isso.

```
docker run -it -v /home/archi/ASF/config:/app/config:Z --name asf --pull always justarchi/archisteamfarm
```

Isso permitirá que o ASF crie arquivos para o volume enquanto estiver dentro do contêiner do docker.

---

## Sincronização de múltiplas instâncias

O ASF inclui suporte para sincronização de múltiplas instâncias, como indicado na seção de **[gerenciamento](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#multiple-instances)**. Ao executar o ASF no contêiner docker, você pode opcionalmente "ligá-lo" ao processo caso você esteja executando vários contêineres com o ASF e você gostaria que eles sincronizassem um com o outro.

Por padrão, cada ASF rodando dentro de um contêiner docker é independente, o que significa que não há sincronização. Para ativar a sincronização entre eles você deve vincular o caminho `/tmp/ASF` em cada contêiner ASF que você deseja sincronizar, para um caminho compartilhado no seu host docker, em modo de leitura-escrita. Isto é feito exatamente da mesma forma que vincular um volume, como foi descrito acima, apenas com caminhos diferentes:

```shell
mkdir -p /tmp/ASF-g1
docker run -v /tmp/ASF-g1:/tmp/ASF -v /home/archi/ASF/config:/app/config --name asf1 --pull always justarchi/archisteamfarm
docker run -v /tmp/ASF-g1:/tmp/ASF -v /home/john/ASF/config:/app/config --name asf2 --pull always justarchi/archisteamfarm
# E assim por diante, todos os conteiner ASF estarão sincronizados agora
```

Recomendamos vincular a pasta `/tmp/ASF` do ASF também à pasta `/tmp` temporária no seu computador, mas claro que você é pode escolher qualquer outra pasta a seu gosto. Cada contêiner do ASF que se espera ser sincronizado deve ter sua pasta `/tmp/ASF` compartilhada com outros contêineres que participam do mesmo processo de sincronização.

Como você provavelmente percebeu no exemplo acima, também é possível criar dois ou mais "grupos de sincronização", vinculando diferentes caminhos do host docker na pasta `/tmp/ASF` do ASF.

Montar a pasta `/tmp/ASF` é completamente opcional e na verdade não é recomendado, a menos que você queira sincronizar explicitamente dois ou mais contêineres do ASF. Não recomendamos montar a pasta `/tmp/ASF` para uso de apenas um contêiner, já que isso não traz absolutamente nenhum benefício se você espera executar apenas um contêiner do ASF, e na verdade poderia causar problemas que, de outra forma, poderiam ser evitados.

---

## Argumentos de linha de comando

O ASF te permite passar **[argumentos de linha de comando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments-pt-BR)** no contêiner docker através de variáveis de ambiente. Você deve usar variáveis de ambiente específicas para os switches suportados, e `ASF_ARGS` para o resto. Isso pode ser feito com o switch `-e` adicionado ao `docker run`, por exemplo:

```shell
docker run -it -e "ASF_CRYPTKEY=MinhaSenha" -e "ASF_ARGS=--no-config-migrate" --name asf --pull always justarchi/archisteamfarm
```

Esse comando passará seu argumento `--cryptkey` para o processo do ASF sendo executado dentro do contêiner docker, assim como outros argumentos. Of course, if you're advanced user, then you can also modify `ENTRYPOINT` or add `CMD` and pass your custom arguments yourself.

A menos que você deseje fornecer chaves de criptografia personalizadas ou outras opções avançadas, geralmente você não precisa incluir variáveis de ambiente especiais, pois nossos contêineres docker já estão configurados para serem executados usando as opções padrões `--no-restart` `--process-required` `--system-required`, portanto esses argumentos não precisam ser especificados explicitamente em `ASF_ARGS`.

---

## IPC

Caso você não tenha alterado o valor padrão da **[propriedade de configuração global](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#global-config)**, o `IPC` já estará habilitado. No entanto, você ainda deve fazer duas coisas adicionais para que o IPC possa funcionar em um contêiner Docker. Primeiramente, você deve usar `IPCPassword` ou modificar o valor padrão `KnownNetworks` em um customizado `IPC.config` para permitir que você se conecte de fora sem usar uma. Caso você realmente saiba o que está fazendo, use apenas `IPCPassword`. Em segundo lugar, você terá que modificar o endereço de escuta padrão de `localhost`, já que o docker não pode rotear o tráfego externo para a interface de loopback. Um exemplo de configuração que irá escutar em todas as interfaces é `http://*:1242`. Claro, você também pode usar ligações mais restritivas, tais como apenas rede local ou VPN, mas tem que ser uma rota acessível de fora; `localhost` não funciona, já que a rota está inteiramente dentro do computador de convidado.

Para obter o resultado descrito acima você deve usar uma **[configuração personalizada de IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-pt-BR#configuração-personalizada)**, como o exemplo abaixo:

```json
{
    "Kestrel": {
        "Endpoints": {
            "HTTP": {
                "Url": "http://*:1242"
            }
        }
    }
}
```

Depois de configurarmos o IPC em uma interface sem loopback, precisamos indicar ao docker para se conectar a porta `1242/tcp` do ASF com o argumento `-P` ou `-p`.

Por exemplo, este comando vai expor a interface do IPC do ASF para o computador host (somente):

```shell
docker run -it -p 127.0.0.1:1242:1242 -p [::1]:1242:1242 --name asf --pull always justarchi/archisteamfarm
```

Se você definiu tudo corretamente, o comando `docker run` acima fará com que a interface **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-pt-BR)** funcione em seu computador host, no caminho padrão `localhost:1242` que agora é redirecionada para seu computador convidado. Também é bom notar que nós não expomos esta rota além disso, então a conexão só pode ser feita dentro do host docker, e, portanto, o mantém seguro. Claro, você pode expor mais a rota e garantir medidas de segurança adequadas se você souber o que está fazendo.

---

### Exemplo completo

Combinando todo conhecimento acima, um exemplo de uma configuração completa ficaria assim:

```shell
docker run -p 127.0.0.1:1242:1242 -p [::1]:1242:1242 -v /home/archi/ASF/config:/app/config -v /home/archi/ASF/plugins:/app/plugins/custom --name asf --pull always justarchi/archisteamfarm
```

Isso pressupõe que você usará um único contêiner ASF, com todos os arquivos de configuração em `/home/archi/ASF/config`. Você deve modificar o caminho de configuração para aquele que corresponde à sua máquina. It's also possible to provide custom plugins for ASF, which you can put in `/home/archi/ASF/plugins`. Essa configuração também está pronta para o uso opcional do IPC se você decidiu incluir o arquivo `IPC.config` na sua pasta config com o conteúdo abaixo:

```json
{
    "Kestrel": {
        "Endpoints": {
            "HTTP": {
                "Url": "http://*:1242"
            }
        }
    }
}
```

---

## Dicas profissionais

Quando você já tem o contêiner docker do ASF pronto, você não precisa usar o comando `docker run` toda vez. Você pode parar/iniciar o contêiner docker do ASF facilmente com `docker stop asf` e `docker start asf`. Tenha em mente que se você não estiver usando o marcador `latest` então você precisará usar os comandos `docker stop`, `docker rm` e `docker run` novamente para atualizar o ASF. Isso porque você deve recompilar seu contêiner à partir de uma imagem nova do ASF toda vez que você quiser usar a versão do ASF inclusa naquela imagem. Na tag `latest` do ASF, foi incluída a capacidade de se auto-atualizar, portanto, não é necessário reconstruir a imagem para usar o ASF atualizado (mas ainda é uma boa ideia fazê-lo de tempos em tempos para utilizar as dependências .NET runtime mais recentes e o Sistema Operacional subjacente, o que pode ser necessário ao atualizar para as principais versões do ASF).

Como dito acima, em qualquer outra tag que não seja a `latest`, o ASF não vai se atualizar automaticamente, o que significa que **você** é o responsável por usar uma versão atualizada do repositório `justarchi/archisteamfarm`. Isso traz muitas vantagens já que normalmente o aplicativo não precisa mudar seu código durante a operação, mas nós entendemos a conveniência de não precisar se preocupar com a versão do ASF em seu contêiner docker. Se você se importa com boas práticas e o uso correto do contêiner docker, sugerimos o marcador `released` ao invés de `latest`, mas se você não quer se preocupar com isso e só quer fazer o ASF tanto funcionar quanto se atualizar automaticamente, então `latest` serve.

Você normalmente deve rodar o ASF no contêiner docker com a configuração global `Headless: true`. Isso indicará explicitamente ao ASF que você não poderá inserir os dados ausentes e que ele não deverá solicitá-los. Claro, para a configuração inicial você deve deixar essa opção como `false` então você poderá configurar tudo facilmente, mas no longo prazo você normalmente não estará ligado diretamente ao console do ASF, portanto faz sentido informar o ASF sobre isso e usar o **[comando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-pt-BR)** `input` caso seja necessário. Dessa forma o ASF não vai esperar infinitamente por um comando do usuário que não será inserido (e gastar recursos enquanto isso). Isso também permitirá que o ASF rode em modo não-interativo dentro do contêiner, o que é crucial, por exemplo, no que diz respeito a sinais de encaminhamento, tornando possível que o ASF feche com o comando `docker stop asf`.