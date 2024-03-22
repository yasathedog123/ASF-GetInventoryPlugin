# Gerenciamento

Esta seção abrange assuntos relacionados ao gerenciamento do processo do ASF de forma ideal. Embora não seja estritamente obrigatório para o uso, ele inclui várias dicas, truques e boas práticas que gostaríamos de compartilhar, especialmente para administradores de sistema, pessoas empacotando o ASF para uso em repositórios de terceiros, bem como usuários avançados e afins.

---

## Serviço `systemd` para Linux

Nas variantes `generic` e `linux`, o ASF vem com o arquivo `ArchiSteamFarm@.service` que é um arquivo de configuração do serviço para o **[`systemd`](https://systemd.io)**. Se você quiser executar o ASF como um serviço, por exemplo, para executá-lo automaticamente após a inicialização do seu computador, então um serviço `systemd` adequado é provavelmente a melhor maneira de fazer isso, por isso, recomendamos fortemente ele ao invés de fazer o gerenciamento sozinho através do `nohup`, `screen` ou similar.

Primeiramente, crie uma conta para o usuário que você deseja executar o ASF, (supondo que ela ainda não existe). Nós vamos usar o usuário `asf` neste exemplo, se você decidir usar um diferente, você precisará substituir o `asf` em todos os nossos exemplos abaixo com o seu nome de usuário selecionado. Nosso serviço não permite que você rode o ASF como o `root`, visto que é considerado uma **[má pratica](#nunca-execute-o-asf-como-administrador)**.

```sh
su # Ou sudo -i, para entrar no shell em root
useradd -m asf # Crie uma conta em que você pretende executar o ASF
```

Em seguida, descompacte o ASF na pasta `/home/asf/ArchiSteamFarm`. A estrutura de pastas é importante para a nossa unidade de serviço, ela deve ser a pasta `ArchiSteamFarm` no seu `$HOME`, então `/home/<user>`. Se você tiver feito tudo corretamente, existirá um arquivo `/home/asf/ArchiSteamFarm/ArchiSteamFarm@.service`. Se você estiver usando a variante `linux` e não descompactar o arquivo no Linux, mas, por exemplo, usar a transferência de arquivos do Windows, então você também precisará `chmod +x /home/asf/ArchiSteamFarm/ArchiSteamFarm`.

Nós faremos todas as ações abaixo como `root`, então vá ao shell com o comando `su` ou `sudo -i`.

Em primeiro lugar, é uma boa ideia garantir que nossa pasta ainda pertence ao nosso usuário `asf`, `chown -hR asf:asf /home/asf/ArchiSteamFarm` executado uma será suficiente. As permissões podem estar erradas, por exemplo, se você baixar e/ou descompactar o arquivo zip como `root`.

Em segundo lugar, se você estiver usando uma variante genérica do ASF, você precisa garantir que o comando `dotnet` é reconhecido e dentro de um dos locais padrão: `/usr/local/bin` ou `/usr/bin` ou `/bin`. Isto é necessário para o nosso serviço de sistema que executa o comando `dotnet /path/to/ArchiSteamFarm.dll`. Confira se `dotnet --info` funciona pra você, se sim, digite `command -v dotnet` para descobrir onde está localizado. Se você usou o instalador oficial, ele deve estar em `/usr/bin/dotnet` ou em um dos outros lugares, o que está certo. Se estiver em uma localização personalizada como `/usr/share/dotnet/dotnet`, crie um **[link simbólico](https://pt.wikipedia.org/wiki/Liga%C3%A7%C3%A3o_simb%C3%B3lica)** para ele usando `ln -s "$(command -v dotnet)" /usr/bin/dotnet`. Agora, o comando `-v dotnet` deve relatar `/usr/bin/dotnet`, o que também fará a nossa unidade systemd funcionar. Se você estiver usando uma variante de Sistema Operacional específico, você não precisa fazer nada a esse respeito.

Em seguida, execute `ln -s /home/asf/ArchiSteamFarm/ArchiSteamFarm\@.service /etc/systemd/system/ArchiSteamFarm\@.service`, isso irá criar um link simbólico para a nossa declaração de serviço e registrá-lo em `systemd`. O link simbólico permitirá que o ASF atualize sua unidade `systemd` automaticamente como parte da atualização do ASF — dependendo da sua situação, você pode querer usar essa abordagem, ou simplesmente usar o comando `cp` no arquivo e gerenciá-lo você mesmo como quiser.

Depois, certifique-se de que `systemd` reconhece nosso serviço:

```
systemctl status ArchiSteamFarm@asf

○ ArchiSteamFarm@asf.service - ArchiSteamFarm Service (on asf)
     Loaded: loaded (/etc/systemd/system/ArchiSteamFarm@.service; disabled; vendor preset: enabled)
     Active: inactive (dead)
       Docs: https://github.com/JustArchiNET/ArchiSteamFarm/wiki
```

Preste atenção especial ao usuário que declaramos após `@`, no nosso caso é o `asf`. Nossa unidade de serviço systemd espera que você declare o usuário, já que ele influencia o local exato do binário `/home/<user>/ArchiSteamFarm`, assim como o usuário real que o systemd usa para gerar o processo.

Se o systemd gerou uma saída semelhante à acima, tudo está em ordem, e estamos quase terminando. Agora só falta iniciar nosso serviço como nosso usuário escolhido: `systemctl start ArchiSteamFarm@asf`. Aguarde alguns segundos e você poderá verificar o status novamente:

```
systemctl status ArchiSteamFarm@asf

● ArchiSteamFarm@asf.service - ArchiSteamFarm Service (on asf)
     Loaded: loaded (/etc/systemd/system/ArchiSteamFarm@.service; disabled; vendor preset: enabled)
     Active: active (running) since (...)
       Docs: https://github.com/JustArchiNET/ArchiSteamFarm/wiki
   Main PID: (...)
(...)
```

Se o `systemd` estiver indicando `active (running)`, isso significa que tudo correu bem, e você pode verificar que o processo do ASF deve estar aberto e sendo executado, por exemplo, com o `journalctl -r`, dado que o ASF, por padrão, também direciona suas mensagens para o console, sendo estas registradas pelo `systemd`. Se estiver satisfeito com a configuração que tem agora, você pode dizer ao `systemd` para iniciar seu serviço automaticamente durante a inicialização, executando o comando `systemctl enable ArchiSteamFarm@asf`. Isso é tudo.

Se por acaso você quiser parar o processo, simplesmente execute o comando `systemctl stop ArchiSteamFarm@asf`. Da mesma forma, se você deseja desativar o ASF de ser iniciado automaticamente na inicialização, o comando `systemctl disable ArchiSteamFarm@asf` fará isso por você, é muito simples.

Por favor, note que, como não há nenhuma entrada padrão ativada para o serviço `systemd`, você não conseguirá inserir os detalhes através do console de maneira normal. Executar através do `systemd` é equivalente a especificar o ajuste **[`Headless: true`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-pt-BR#headless)** e vem com todas as suas implicações. Felizmente para você, é muito fácil gerenciar o ASF através do **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)**, o que recomendamos no caso de você precisar fornecer detalhes adicionais durante o login ou gerenciar ainda mais seu processo do ASF.

### Variáveis de ambiente

É possível fornecer variáveis de ambiente adicionais ao nosso serviço `systemd`, o que você estará interessado em fazer caso você queira, por exemplo, usar um **[argumento de linha de comando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments-pt-BR#argumentos)** `--cryptkey` personalizado, e portanto, especificando a variável de ambiente `ASF_CRYPTKEY`.

Para fornecer variáveis de ambiente personalizadas, crie a pasta `/etc/asf` (no caso dela não existir), `mkdir -p /etc/asf`. Recomendamos usar `chown -hR root:root /etc/asf && chmod 700 /etc/asf` para garantir que apenas o usuário `root` tenha acesso para ler esses arquivos, porque eles podem conter propriedades sensíveis como `ASF_CRYPTKEY`. Depois disso, você pode editar o arquivo `/etc/asf/<user>` onde `<user>`representa o usuário sob o qual você está executando o serviço, (nesse caso, `asf`, ou seja, edite `/etc/asf/asf`).

O arquivo deve conter todas as variáveis de ambiente que você deseja fornecer ao processo. Aquelas que não possuem uma variável de ambiente dedicada podem ser declaradas em `ASF_ARGS`:

```sh
# Declare apenas aqueles que você realmente precisa
ASF_ARGS="--no-config-migrate --no-config-watch"
ASF_CRYPTKEY="my_super_important_secret_cryptkey"
ASF_NETWORK_GROUP="my_network_group"

# E quaisquer outras que você esteja interessado
```

### Sobrescrevendo parte da unidade de serviço

Graças à flexibilidade do `systemd`, é possível substituir parte da unidade do ASF preservando o arquivo unitário original e permitindo que o ASF o atualize como parte das atualizações automáticas.

Neste exemplo, gostaríamos de modificar o comportamento unitário padrão do ASF `systemd` de reiniciando apenas no sucesso para reiniciando também em falhas fatais. Para fazer isso, Nós sobrescreveremos a propriedade `Restart` em `[Service]` do padrão `on-success` para `always`. Simplesmente execute `systemctl edit ArchiSteamFarm@asf`, substituindo `asf` pelo usuário de destino do seu serviço. Em seguida, adicione as alterações conforme indicado pelo `systemd` na seção adequada:

```sh
### Editando /etc/systemd/system/ArchiSteamFarm@asf.service.d/override.conf
### Tudo que estiver entre está linha e o comentário abaixo se tornará o novo conteúdo do arquivo

[Service]
Restart=always

### Linhas abaixo deste comentário serão descartadas

### /etc/systemd/system/ArchiSteamFarm@asf.service
# [Install]
# WantedBy=multi-user.target
# 
# [Service]
# EnvironmentFile=-/etc/asf/%i
# ExecStart=dotnet /home/%i/ArchiSteamFarm/ArchiSteamFarm.dll --no-restart --process-required --service --system-required
# Restart=on-success
# RestartSec=1s
# SyslogIdentifier=asf-%i
# User=%i
# (...)
```

E é isso. Agora sua unidade age da mesma forma que houvesse apenas `Restart=always` em `[Service]`.

Claro, a alternativa é usar o comando `cp` no arquivo e gerenciá-lo você mesmo, mas isso te permite mudanças flexíveis mesmo se você decidiu manter a unidade original do ASF, por exemplo, com um **[link simbólico](https://pt.wikipedia.org/wiki/Liga%C3%A7%C3%A3o_simb%C3%B3lica)**.

---

## Nunca execute o ASF como administrador!

O ASF inclui a sua própria validação, independente do processo estar sendo executado como administrador (`root`). Executar como `root`  **não é** necessário para qualquer tipo de operação feita pelo processo ASF. Partindo do pressuposto de que o ambiente esteja funcionando corretamente e, portanto deve ser considerado uma  **mau prática**. Isso significa que no Windows, o ASF **nunca** deve ser executado com a configuração "executar como administrador", e no Unix, o ASF deve ter uma **conta de usuário dedicada** para si mesmo, ou reutilizar a sua própria no caso de um sistema de escritório.

Para obter mais explicações sobre *por que* desencorajamos a execução do ASF como `root`, consulte **[superuser](https://superuser.com/questions/218379/why-is-it-bad-to-run-as-root)** e outras fontes. Se você ainda não estiver convencido, pergunte-se o que aconteceria com seu computador se o processo do ASF executasse o comando `rm -rf /*` logo após ser iniciado.

### Eu rodo como `root` porque o ASF não pode escrever em seus arquivos

Isso significa que você configurou incorretamente as permissões dos arquivos que o ASF está tentando acessar. Você deve fazer login como uma conta `root` (ou com `su` ou `sudo -i`) e **corrigir** as permissões enviando o comando `chown -hR asf:asf /path/to/ASF`, substituindo `asf:asf` pelo usuário em que você executará o ASF e `/path/to/ASF` de acordo. Se por alguma razão você estiver usando um `--path` personalizado dizendo ao usuário do ASF para usar um diretório diferente, você deve executar o mesmo comando novamente para esse caminho também.

Depois de fazer isso, você não deverá mais ter nenhum tipo de problema relacionado ao ASF não ser capaz de escrever nos seus próprios arquivos, já que você acabou de alterar o proprietário de tudo o que o ASF está interessado ao usuário com o qual o processo realmente será executado.

### Eu executo como `root` porque eu não sei fazer de outra forma

```sh
su # Ou sudo -i, para entrar no shell em root
useradd -m asf # Crie a conta em que você pretende executar o ASF
chown -hR asf:asf /path/to/ASF # Certifique-se de que seu novo usuário tenha acesso à pasta
su asf -c /path/to/ASF/ArchiSteamFarm # Ou sudo -u asf /path/to/ASF/ArchiSteamFarm, para iniciar o programa sob seu usuário
```

Isso seria feito manualmente, seria muito mais fácil usar nosso  **

 [serviço](#systemd-service-for-linux) `systemd`</strong> explicado acima.</p> 



### Eu já sei, mas ainda quero executar como `root`

O ASF não te impede diretamente de fazer isso, apenas exibe um aviso com um pequeno alerta. Só não fique chocado se um dia devido a um erro no programa, ele explodir todo o seu sistema operacional com perda completa de dados — você foi avisado.



---



## Múltiplas instâncias

O ASF permite a execução de múltiplas instâncias do processo no mesmo computador. Essas instâncias podem ser totalmente individuais ou derivadas do mesmo executável (nesse caso você deve rodá-las com o**[ argumento de linha de comando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments-pt-BR)** `--path` diferente para cada uma).

Quando estiver executando várias instâncias do mesmo executável certifique-se que você desativou as atualizações automáticas em todas as configurações, pois não existe nenhuma sincronização entre eles no que tange as atualizações automáticas. Se você quiser continuar com as atualizações automáticas habilitadas nós recomendamos rodar instâncias individuais, mas você ainda pode fazer as atualizações funcionarem, contanto que você possa garantir que todas as outras instâncias do ASF sejam fechadas.

O ASF fará o seu melhor para manter uma quantidade mínima de comunicação entre Sistema Operacional e multi-processos com outras instâncias do ASF. Isso inclui verificar sua pasta de configuração ao invés da pasta de outras instâncias, além de compartilhar limitadores de núcleo de processo configurados com a **[propriedade de configuração global](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-pt-BR#configura%C3%A7%C3%A3o-global)** `*LimiterDelay` garantindo que rodar várias instâncias do ASF não cause a possibilidade de ter problemas com limite de tráfego. No que diz respeito a aspectos técnicos, todas as plataformas usam nosso mecanismo dedicado de bloqueios baseado em arquivos personalizados do ASF criados em uma pasta temporária em `C:\Users\<SeuUsuário>\AppData\Local\Temp\ASF` no Windows e `/tmp/ASF` no Unix.

Não é necessário que instâncias do ASF compartilhem as mesmas propriedades `*LimiterDelay`, elas podem usar valores diferentes já que cada ASF adicionará seu próprio atraso configurado para o tempo de liberação após adquirir o bloqueio. Se a configuração `*LimiterDelay` estiver definida como `0`, a instância do ASF vai pular a espera pelo bloqueio de determinado recurso que for compartilhado com outras instâncias (isso poderia manter um bloqueio compartilhado uns com os outros). Quando definido como outro valor, o ASF irá sincronizar corretamente com outras instâncias e esperar pela sua vez e liberar o bloqueio após o atraso configurado, permitindo que outras instâncias continuem.

O ASF leva em conta a configuração `WebProxy` quando decide sobre o escopo compartilhado, o que significa que duas instâncias do ASF usando configurações `WebProxy` diferentes não compartilharão seus limitadores entre si. Isso foi implementado para permitir que as configurações de `WebProxy` operem sem atrasos excessivos, como esperado de diferentes interfaces de rede. Isso deve ser o suficiente para a maioria dos casos, no entanto, se você tiver uma configuração personalizada específica na qual você roteie os pedidos de forma diferente, por exemplo, você pode especificar manualmente o grupo de rede atráves do **[argumento de linha de comando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments-pt-BR)** `--network-group`, o que vai permitir que você declare o grupo do ASF que será sincronizado com essa instância. Tenha em mente que grupos de rede personalizados são exclusividades, o que significa que o ASF não vai mais usar o `WebProxy` para determinar o grupo certo, já que você é responsável pelo agrupamento nesse caso.

Se você gostaria de usar o nosso ** [serviço](#systemd-service-for-linux) `systemd`</strong> explicado acima para múltiplas instâncias do ASF, é muito simples, basta usar outro usuário para nossa declaração de serviço `ArchiSteamFarm@` e seguir com os passos restantes. Isso será o equivalente a rodar várias instâncias do ASF com binários distintos, então eles também poderão atualizar e operar automática e independentemente um do outro.</p>