# SteamTokenDumperPlugin

`SteamTokenDumperPlugin` é o **[plug-in](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins-pt-BR)** oficial do ASF desenvolvido por nós, que permite que você contribua com o projeto **[SteamDB](https://steamdb.info)** compartilhando tokens de pacote, tokens de app e chaves de depósito que sua conta Steam tem acesso. As informações na integra sobre o porque o SteamDB precisa de tais dados podem ser encontrado na página de **[Depósito de Tokens](https://steamdb.info/tokendumper)** do SteamDB. Os dados enviados não incluem qualquer informação potencialmente sensível, e não possui qualquer risco à sua segurança ou privacidade, como especificado acima.

---

## Ativando o Plugin

O ASF vem com p `SteamTokenDumperPlugin` incluso no pacote de lançamento, mas tal plugin vem desativado por padrão. Você pode ativar o plugin setando `SteamTokenDumperPluginEnabled` nas configurações globais do ASF para `true`, na syntax JSON:

```json
{
  "SteamTokenDumperPluginEnabled": true
}
```

Ao abrir o programa do ASF, o plugin lhe dirá se ele foi ativado com sucesso por meio do mecanismo padrão de registro do ASF. Você também pode ativar o plugin através do nosso gerador de configuração baseado na web.

---

## Detalhes técnicos

Ao habilitar, o plugin usará os bots que você está executando no ASF para coletar dados sob a forma de pacotes de tokens, tokens de aplicativos e códigos de armazenamento aos quais seus bots tem acesso. O módulo de coleta de dados inclui rotinas ativas e passivas que devem minimizar a sobrecarga adicional causada pela coleta de dados.

Para atender ao caso de uso planejado, além de coleta de dados explicados acima, rotina de submissão é inicializada como responsável por determinar quais dados devem ser enviados ao SteamDB periodicamente. Essa rotina disparará em até `1` horas após o início do ASF, e se repetirá a cada `24` horas. O plugin fará o seu melhor para minimizar a quantidade de dados que precisam ser enviados, portanto é possível que alguns dados que o plugin colete sejam marcados como inúteis, e, portanto, ignorados (por exemplo, atualização do aplicativo que não altera o token de acesso).

O plugin usa um banco de dados de cache persistente salvo no local `config/SteamTokenDumper.cache`, que serve uma finalidade similar ao `config/ASF.db` para o ASF. O arquivo é usado para gravar os dados reunidos e enviados e minimizar a quantidade de trabalho que precisa ser feito através de diferentes execuções do ASF. Remoção do arquivo faz com que o processo seja reiniciado do zero, o que deve ser evitado se possível.

---

## Dados

O ASF inclui o colaborador `steamID` na solicitação, o que é determinado como `SteamOwnerID` que você definiu no ASF, ou caso não tenha, o Steam ID do bot, que possui a maioria das licenças. O contribuidor anunciado pode receber algumas vantagens adicionais do SteamDB para ajuda contínua (e. . rank do doador no site), mas isso fica inteiramente a critério do SteamDB.

De qualquer forma, a equipe do SteamDB gostaria de agradecer antecipadamente pela sua ajuda. Os dados enviados permitem que o SteamDB opere, em particular para rastrear informações sobre pacotes, aplicativos e depósitos, o que não seria mais possível sem a sua ajuda.

---

## Comando

O plug-in STD vem com um comando extra do ASF, `std [Bots]`, que permite a você acionar a atualização e a submissão dos bots selecionados sob demanda. Usar o comando não requer uma configuração ativada, o que permite que você pule a coleta automática e o envio, e controle o processo por você mesmo manualmente. Naturalmente, também pode ser executado por uma configuração habilitada, o que simplesmente acionará os procedimentos normais de coleta e envio antes do esperado.

Recomendamos `!std ASF` para acionar a atualização de todos os bots disponíveis. No entanto, você também pode acioná-lo para os selecionados, se você quiser.

---

## Configuração avançada

Nosso plug-in suporta configuração avançada, o que pode ser útil para pessoas que gostariam de ajustar os dados internos à sua preferência.

A configuração avançada tem a seguinte estrutura localizada dentro do `ASF.json`:

```json
{
  "SteamTokenDumperPlugin": {
    "Enabled": false,
    "SecretAppIDs": [],
    "SecretDepotIDs": [],
    "SecretPackageIDs": [],
    "SkipAutoGrantPackages": true
  }
}
```

Todas as opções são explicadas abaixo:

### `Enabled`

Tipo `bool` com valor padrão `false`. Essa propriedade atua como o `SteamTokenDumperPluginEnabled`, propriedade de raiz explicada acima, e pode ser usada em vez disso, dedicado a pessoas que prefeririam ter toda a configuração relacionada ao plugin em sua própria estrutura (então, provavelmente quem já usa outras propriedades avançadas explicadas abaixo).

---

### `SecretAppIDs`

Tipo `ImmutableHashSet<uint>` com valor padrão vazio. Esta propriedade específica os `appIDs` que o plug-in não resolverá e se já estiverem resolvidos, não enviará o token. Esta propriedade pode ser útil para pessoas com acesso a informações potencialmente sensíveis sobre itens não publicados, especialmente os desenvolvedores, editores ou testadores de betas fechados.

---

### `SecretDepotIDs`

Tipo `ImmutableHashSet<uint>` com valor padrão vazio. Esta propriedade específica os `depotIDs` que o plug-in não resolverá e se já estiverem resolvidos, não enviará a chave. This property can be useful for people with access to potentially-sensitive information about unpublished items, especially the developers, publishers or closed beta testers.

---

### `SecretPackageIDs`

Tipo `ImmutableHashSet<uint>` com valor padrão vazio. This property specifies `packageIDs` (also known as `subIDs`) that the plugin won't resolve, and if they're already resolved, won't submit the token for. This property can be useful for people with access to potentially-sensitive information about unpublished items, especially the developers, publishers or closed beta testers.

---

### `SkipAutoGrantPackages`

Tipo `bool` com valor padrão `true`. This property acts very similar to `SecretPackageIDs` and when enabled, will cause packages with `EPaymentMethod` of `AutoGrant` to be skipped during resolve routine explained below. `AutoGrant` payment method is used by **[Steamworks](https://partner.steamgames.com)** to automatically grant packages on developer accounts. While this is not as explicit as other `Secret` options, and therefore doesn't guarantee anything (since you might have other packages than `AutoGrant` that you still don't want to submit), it should be good enough for skipping majority, if not all, of the secret packages. This option is enabled by default, as people that actually have access to `AutoGrant` packages will almost never want to leak those to general public, and therefore using value of `false` is very situational.

---

## Explicações adicionais

At the root level, every Steam account owns a set of packages (licenses, subscriptions), which are classified by their `packageID` (also known as `subID`). Every package may contain several apps classified by their `appID`. Every app may then include several depots classified by their `depotID`.

```text
├── sub/124923
│     ├── app/292030
│     │     ├── depot/292031
│     │     ├── depot/378648
│     │     └── ...
│     ├── app/378649
│     └── ...
└── ...
```

Our plugin includes two routines which take into account skipped items - the resolve routine and submission routine.

The resolve routine is responsible for resolving the tree you can see above. By blacklisting the packages/apps/depots in advance, you'll effectively cut the tree in the place of blacklisted branch/leaf without additional need of specifying the remaining parts of it. In our example above, if `124923` package was ignored, whether by `SecretPackageIDs` or `SkipAutoGrantPackages`, and it was the only package you own which linked to the `292030` appID, then appID `292030` wouldn't get resolved either, and by definition, if there were no other resolved apps which linked to the `292031` and `378648` depots, then they wouldn't get resolved either. However, keep in mind that if the plugin has already resolved the tree, then effectively this will only stop given item from being updated (e.g. new apps added), it will not make the plugin "forget" about the existing items that were already resolved (e.g. apps found in that package before you decided to blacklist it). If you've just enabled some skipping options, and would like to ensure that ASF doesn't traverse the already-resolved tree, you may consider one-time removing `config/SteamTokenDumper.cache` file where the plugin keeps its cache.

The submission routine is responsible for submitting package tokens, app tokens and depot keys of already resolved items (by the resolve routine above). Here your blacklist has immediate effect, as even if the plugin has already resolved the info, the submission routine will not actually submit it over to SteamDB if you have it blacklisted, regardless if it has been resolved or not. No entanto, lembre-se de que não estamos mais falando sobre a árvore neste momento, a rotina de envio não sabe se as informações sobre o aplicativo vêm deste ou daquele pacote, portanto, apenas ignore informações sobre itens específicos da lista negra, independentemente da relação em que estão com os outros.

For majority of the developers and publishers, it should be enough to enable `SkipAutoGrantPackages`, potentially empowered with `SecretPackageIDs` only, as it effectively cuts the tree at the beginning branch and guarantees that the apps and depots included further will not get submitted as long as there is no other package linking to the same app. If you want to be double sure, in addition to that you can also use `SecretAppIDs`, which will skip the resolve of the app even if there are some other licenses you didn't blacklist linking to it. Using `SecretDepotIDs` should not be needed, unless you have a particular, specific need (such as skipping only a particular depot while still submitting info about packages and apps), or if you want to add yet another layer to be triple safe.