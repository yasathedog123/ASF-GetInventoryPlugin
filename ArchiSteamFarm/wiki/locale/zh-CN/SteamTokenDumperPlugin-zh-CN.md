# Steam Token 转存插件

`SteamTokenDumperPlugin` 是由我们开发的 ASF 官方&#8203;**[插件](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins-zh-CN)**，自 ASF V4.2.2.2 版本开始可用，您可以通过此插件为 **[SteamDB](https://steamdb.info)** 项目作出贡献，分享您的 Steam 帐户有权访问的 Package Token、App Token 以及 Depot Key。 关于所收集信息的进一步说明，以及为什么 SteamDB 需要这些信息，可以在 SteamDB 的 **[Token Dumper](https://steamdb.info/tokendumper)** 页面查看。 如上所述，所提交的数据不包含任何敏感信息，也不会有安全或隐私风险。

---

## 启用插件

ASF 在发布时会一并打包 `SteamTokenDumperPlugin`，但插件本身默认是禁用的。 您可以按照 JSON 格式在 ASF 全局配置内设置 `SteamTokenDumperPluginEnabled` 为 `true`：

```json
{
  "SteamTokenDumperPluginEnabled": true
}
```

在 ASF 程序启动时，此插件会通过标准的 ASF 日志机制通知您插件是否已成功启用。 您也可以通过我们的在线配置文件生成器启用此插件。

---

## 技术细节

启用后，此插件将会收集 ASF 内正在运行的机器人有权访问的 Package Token、App Token 和 Depot Key。 数据收集模块包括被动与主动例程，以尽量减少数据收集造成的额外开销。

为了符合预期的使用场景，除了上述的数据收集例程以外，还有提交例程负责确定哪些数据需要定期被提交到 SteamDB。 自 ASF 启动最多 `1` 小时后，此例程将会启动，之后则每 `24` 小时重复一次。 此插件将尽全力减少需要发送的数据量，因此，某些收集到的数据会被认为无需提交而跳过（例如 Token 未发生变化的 App 更新）。

此插件使用一个持久化缓存数据库，位于 `config/SteamTokenDumper.cache`，其用途类似 `config/ASF.db` 之于 ASF。 此文件用于记录收集到和被提交的数据，以尽可能减少下次 ASF 启动时的工作量。 删除此文件会导致此过程完全从零开始，这种情况尽可能避免。

---

## 数据

ASF 会在请求中包含贡献者的 `SteamID`，即您已在 ASF 内设置好的 `SteamOwnerID` 属性，但如果您没设置过此属性，我们就会选择拥有许可数最多的机器人的 Steam ID 来发送。 通告的贡献者可能会因为持续贡献在 SteamDB 获得一些额外的增益（例如网站上的捐赠者排名），但这完全由 SteamDB 来决定。

无论如何，SteamDB 工作人员愿意提前感谢您的帮助。 这些提交的数据使 SteamDB 能够继续运营，特别是跟踪 Package、App 与 Depot 信息，如果没有您的帮助，这些功能将不复存在。

---

## 进阶配置

从 ASF V5.1.0.0 开始，我们的插件支持进阶配置，一些希望调整插件内部设置的用户可能会需要它们。

进阶配置在 `ASF.json` 文件中有如下结构：

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

下面是对所有选项的解释：

### `Enabled`

这是一个默认值为 `false` 的 `bool` 类型属性。 该属性与上文所述的顶层配置 `SteamTokenDumperPluginEnabled` 作用相同，可以互相替代，一些用户可能希望将所有与插件有关的配置维护在独立的结构中（这些用户很可能已经设置了下文将提到的一些属性），因此我们提供此属性。

---

### `SecretAppIDs`

这是一个默认值为空的 `ImmutableHashSet<uint>` 类型属性。 该属性使插件不解析指定的 `AppID`，并且如果它们已被解析，则不提交 Token。 一些用户，特别是开发者、发行商或者测试玩家可能会访问到潜在的敏感信息，例如未发布的物品，他们可能需要这种设置项。

---

### `SecretDepotIDs`

这是一个默认值为空的 `ImmutableHashSet<uint>` 类型属性。 该属性使插件不解析指定的 `DepotID`，并且如果它们已被解析，则不提交 Key。 一些用户，特别是开发者、发行商或者测试玩家可能会访问到潜在的敏感信息，例如未发布的物品，他们可能需要这种设置项。

---

### `SecretPackageIDs`

这是一个默认值为空的 `ImmutableHashSet<uint>` 类型属性。 该属性使插件不解析指定的 `PackageID`（也称作 `SubID`），并且如果它们已被解析，则不提交 Token。 一些用户，特别是开发者、发行商或者测试玩家可能会访问到潜在的敏感信息，例如未发布的物品，他们可能需要这种设置项。

---

### `SkipAutoGrantPackages`

这是一个默认值为 `true` 的 `bool` 类型属性。 该属性非常类似 `SecretPackageIDs`，启用时，下文所述的解析过程将会跳过 `EPaymentMethod` 值为 `AutoGrant` 的 Package。 **[Steamworks](https://partner.steamgames.com)** 会使用 `AutoGrant` 付款方式自动为开发者帐户激活 Package。 这个选项不像其他 `Secret` 选项那样明确指定 ID，因此无法保证行为符合预期（您可能拥有一些非 `AutoGrant` 但仍然不想提交的 Package），但应该已经足以跳过大多数（可能并非全部）的私密 Package。 该选项默认启用，因为实际上对 `AutoGrant` Package 有访问权限的人几乎永远不希望公开这些信息，因此使用 `false` 才属于特殊情况。

---

## 进一步解释

最基本的概念是，每个 Steam 帐户拥有一系列 Package（许可或订阅），对应一个个 `PackageID`（也叫 `SubID`）。 每个 Package 可能包含一些 App，对应一个个 `AppID`。 每个 App 可能包含一些 Depot，对应一个个 `DepotID`。

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

我们的插件包括两个过程——解析过程和提交过程，二者都会参与决定是否跳过物品，

解析过程负责解析上文所述的树形结构。 通过预先设置 Package/App/Depot 的黑名单，您可以有效地在这样的树结构中切断指定的分支和叶子，而无需单独指定剩余的部分。 在上述示例中，如果 Package `124923` 已被忽略（无论是通过 `SecretPackageIDs` 还是 `SkipAutoGrantPackages` 选项），并且在您拥有的所有 Package 中，只有这个可以链接到 `292030` AppID，那么 AppID `292030` 也不会被解析，根据定义，如果没有其他可被解析的 App 可以链接到 `292031` 和 `378648` 两个 Depot，则它们也不会被解析。 然而，请注意如果插件已经解析过这棵树，那么此过程仅仅会停止更新相应的物品（例如新添加的 App），而不会“忘记”已经被解析过的物品（例如，您在插件解析后才添加到黑名单中的 Package）。 如果您刚刚启用一些忽略选项，并且希望确保 ASF 不会遍历已经解析过的树，您可以考虑删除一次插件的缓存文件 `config/SteamTokenDumper.cache`。

上述解析过程会提供已解析物品，由提交过程负责提交这些物品的 Package Token、App Token 和 Depot Key。 此处，您的黑名单会立刻生效，即使插件已经解析了对应的信息，提交过程也不会真的向 SteamDB 提交黑名单中的物品。 请注意，此时我们不再提及上面提到的树形结构，提交过程不知道 App 信息来自哪个 Package，所以这个过程只能跳过特定的、已加黑名单的物品，而不考虑节点之间的关系。

对于大多数开发者和发行商来说，启用 `SkipAutoGrantPackages` 已经可以满足要求，如果还是不能，可以进而设置 `SecretPackageIDs` 选项来增强，因为这已经能有效地从父分支修剪树形结构，保证里面包含的所有 App 和 Depot 都不会被提交，只要没有其他 Package 链接到相同的 App 上。 如果您需要双保险，您还可以额外设置 `SecretAppIDs`，这样即使有其他未加入黑名单的 Package 链接到这些 App，它们也不会被解析。 一般无需设置 `SecretDepotIDs`，除非您有特殊需要（例如，仅仅跳过一个特定的 Depot，但仍然提交相应 Package 和 App 的信息），或者您真的需要额外的三重保险。