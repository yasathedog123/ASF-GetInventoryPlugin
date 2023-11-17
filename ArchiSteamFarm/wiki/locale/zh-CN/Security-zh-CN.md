# 安全性

## 加密

ASF 目前支持的加密方式定义为如下 `ECryptoMethod`：

| Value | 名称                          |
| ----- | --------------------------- |
| 0     | PlainText                   |
| 1     | AES                         |
| 2     | ProtectedDataForCurrentUser |
| 3     | EnvironmentVariable         |
| 4     | File                        |

下文会详细解释与比较这些方式。

要生成加密过的密码，并在如 `SteamPassword` 等属性中使用，您可以执行 `encrypt` **[命令](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-zh-CN)**，并带上您选择的适当加密方式与您的密码原文。 然后，将您获得的加密字符串填入 `SteamPassword` 机器人配置属性，并且对应修改 `PasswordFormat` 为符合加密方式的选项。 一些格式不需要 `encrypt` 命令，例如 `EnvironmentVariable` 或 `File`，而只需要设置合适的路径。

---

### `PlainText`

这是最简单但也最不安全的密码存储方式，指定 `ECryptoMethod` 为 `0`。 此时 ASF 需要字符串为纯文本——即密码的原文形式。 它是最容易使用的，并且与所有部署方式 100% 兼容，因此它是存储私密数据的默认值，但完全不安全。

---

### `AES`

按照当今的标准，**[AES](https://en.wikipedia.org/wiki/Advanced_Encryption_Standard)** 可以被视为安全的加密方式，指定 `ECryptoMethod` 为 `1` 即可启用这种方式。 ASF 需要相应字符串是一个由 AES 加密的字节数组转换成的 **[Base64 编码](https://en.wikipedia.org/wiki/Base64)**&#8203;的字符序列，此数据需要其包含的&#8203;**[初始向量](https://en.wikipedia.org/wiki/Initialization_vector)**&#8203;和 ASF 内置加密密钥来解密。

此方法保证了安全性，只要攻击者不知道用于加密和解密的 ASF 密钥。 ASF 允许您通过 `--cryptkey` **[命令行参数](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-Line-Arguments-zh-CN)**&#8203;指定自定义密钥增强 ASF 的安全性。 如果您决定省略它，ASF 将使用自己提供的密钥，这个密钥是**已知**的并已硬编码到应用程序中，这意味着任何人都可以撤消 ASF 的加密并获取解密后的密码。 虽然这种攻击仍然需要一定时间而且并不容易，但是这是可以做到的。所以您总应该同时使用 `AES` 加密并用 `--cryptkey` 指定自定义密钥。 ASF 使用的 AES 方法提供了相对令人满意的安全性，并且它在 `PlainText` 的简单和 `ProtectedDataForCurrentUser` 的复杂之间取得了平衡，但强烈建议您将它与自定义密钥 `--cryptkey` 一起使用。 如果使用得当，就能保证安全存储的适当安全性。

---

### `ProtectedDataForCurrentUser`

这是目前 ASF 加密密码最安全的方式，比上述 `AES` 加密安全得多，您需要将 ` ECryptoMethod` 指定为 `2`。 这种方法的主要优点同时也是它主要的缺点——它并不使用加密密钥（像 `AES` 那样），数据会使用当前计算机登录的用户凭据加密，这意味着数据**仅**能在这台机器上进行解密，事实上，**仅仅**触发加密的计算机用户才能解密。 如果您的 `Bot.json` 文件中的 `SteamPassword` 属性使用此方式加密，就可以保证即使您将整个文件发送给其他人，对方也无法在不直接接触您的计算机的情况下获得密码。 这是非常优秀的安全措施，但也有兼容性差的缺点，因为使用此方法加密的密码将不能兼容其他任何用户和计算机——假设您需要重新安装操作系统，这其中甚至包括**您自己的**计算机。 不过，这仍然是存储密码的最佳方法之一，如果您担心 `PlainText` 的安全性，也不想每次输入密码，那么只要您不会在其他机器上使用您的配置文件，这就是您最好的选择。

**请注意，此选项目前仅适用于运行 Windows 操作系统的计算机。**

---

### `EnvironmentVariable`

基于内存的存储，`ECryptoMethod` 定义为 `3`。 ASF 会从环境变量中读取密码，环境变量的名字需要在密码字段（例如 `SteamPassword`）中指定。 例如，将 `SteamPassword` 设置为 `ASF_PASSWORD_MYACCOUNT`，并将 `PasswordFormat` 设置为 `3`，ASF 就会读取环境变量 `${ASF_PASSWORD_MYACCOUNT}` 的内容作为帐户密码。

---

### `File`

基于文件的存储（可以在 ASF 配置文件夹之外），`ECryptoMethod` 定义为 `4`。 ASF 会从文件中读取密码，文件的路径需要在密码字段（例如 `SteamPassword`）中指定。 指定的路径既可以是绝对路径，也可以相对于 ASF 根目录（也就是含有 `config` 文件夹的目录，同时遵循您设置的 `--path` **[命令行参数](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments-zh-CN#参数)**）。 此方法可以配合 **[Docker secret](https://docs.docker.com/engine/swarm/secrets)** 使用，它会自动创建对应的文件，但如果您自己创建所需的文件，也可以在 Docker 外使用。 例如，将 `SteamPassword` 设置为 `/etc/secrets/MyAccount.pass`，并将 `PasswordFormat` 设置为 `4`，ASF 就会读取 `/etc/secrets/MyAccount.pass` 文件，并将其内容作为帐户密码。

注意，请确保包含密码的文件不会被未授权用户读取到，因为这样就完全破坏了使用这种方法的目的。

---

## 建议

如果兼容性对您来说不是问题，并且您可以接受 `ProtectedDataForCurrentUser` 方式，我们**推荐**您以这种方式存储密码，因为它有着最好的安全性。 对于还需要在其他计算机上使用配置文件的用户来说，`AES` 方法也是一个不错的选择。而 `PlainText` 是存储密码最简单的方法，只要您不介意其他人可能会查看您的 JSON 配置文件。

请注意，如果入侵者能够访问您的计算机，上述 3 种方法都**不安全**。 ASF 必须能够解密已加密的密码，如果在您的计算机上运行的某个程序能够做到这一点，那么在同一计算机上运行的其他程序也能做到这一点。 `ProtectedDataForCurrentUser` 是其中最安全的方法，**即使使用同一台计算机的其他用户也无法解密**，但如果有人窃取了您的登录凭据、计算机信息和 ASF 配置文件，他仍然有可能解密出您的密码。

对于复杂的安装方式，您可以利用 `EnvironmentVariable` 和 `File`。 它们的用途有限，如果您希望通过某种自定义方法获取密码并将其存储在内存中，则使用 `EnvironmentVariable` 较好，而使用 **[Docker secret](https://docs.docker.com/engine/swarm/secrets)** 的情况则更适合使用 `File`。 但两者都没有加密，所以基本上是将风险从 ASF 配置文件转移到了您选择的另一个存储位置。

除了使用上述加密方式以外，您也可以完全不填写密码，例如，将 `SteamPassword` 设置为空字符串或者 `null` 值。 ASF 将会在需要时向您询问密码，并且不会将其保存在任何地方，仅仅临时存放在当前进程分配的内存中，一旦您关闭 ASF 就会消失。 随着这是处理密码的最安全的方法（密码没有被存储在任何地方），但也是最麻烦的，因为您需要在每次 ASF 运行时手动输入密码（如果需要）。 如果这对您来说不是问题，这就是您在安全方面的最佳选择。

---

## 解密

ASF 不支持任何解密已加密密码的方法，因为解密方法仅在内部使用，用于访问进程内的数据。 如果您需要反转加密过程，例如，在使用 `ProtectedDataForCurrentUser` 加密的情况下，将 ASF 迁移到另一台机器，则在新环境中重新按上述流程操作即可。

---

## 哈希

ASF 目前支持的哈希方式定义为如下 `EHashingMethod`：

| 值 | 名称        |
| - | --------- |
| 0 | PlainText |
| 1 | SCrypt    |
| 2 | Pbkdf2    |

下文会详细解释与比较这些方式。

要生成哈希值，并在如 `IPCPassword` 等属性中使用，您可以执行 `hash` **[命令](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-zh-CN)**，并带上您选择的适当哈希方式与您的密码原文。 然后，将您获得的哈希字符串填入 `IPCPassword` 全局配置属性，并且对应修改 `IPCPasswordFormat` 为符合哈希方式的选项。

---

### `PlainText`

这是最简单但也最不安全的密码哈希方式，指定 `EHashingMethod` 为 `0`。 ASF 会生成与原文相同的哈希值。 它是最容易使用的，并且与所有部署方式 100% 兼容，因此它是存储私密数据的默认值，但完全不安全。

---

### `SCrypt`

按照当今的标准，**[SCrypt](https://en.wikipedia.org/wiki/Scrypt)** 可以被视为安全的哈希方式，指定 `EHashingMethod` 为 `1` 即可使用这种方式。 ASF 的 `SCrypt` 实现采用 `8` 个块、`8192` 次迭代、`32` 位哈希长度，并使用加密密钥作为盐以生成字节数组。 其结果字节将会以 **[Base64](https://en.wikipedia.org/wiki/Base64)** 编码为字符串。

ASF 允许您通过 `--cryptkey` **[命令行参数](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-Line-Arguments-zh-CN)**&#8203;指定盐增强 ASF 的安全性。 如果您决定省略它，ASF 将使用自己提供的密钥，这个密钥是**已知**的并已硬编码到应用程序中，这意味着哈希过程会更不安全。 如果使用得当，就能保证安全存储的适当安全性。

---

### `Pbkdf2`

按照当今的标准，**[Pbkdf2](https://en.wikipedia.org/wiki/PBKDF2)** 是一种安全性较弱的哈希方式，指定 `EHashingMethod` 为 `2` 即可使用这种方式。 ASF 的 `Pbkdf2` 实现采用 `10000` 次迭代、`32` 位哈希长度，并使用加密密钥作为盐，`SHA-256` 作为 HMAC 算法以生成字节数组。 其结果字节将会以 **[Base64](https://en.wikipedia.org/wiki/Base64)** 编码为字符串。

ASF 允许您通过 `--cryptkey` **[命令行参数](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-Line-Arguments-zh-CN)**&#8203;指定盐增强 ASF 的安全性。 如果您决定省略它，ASF 将使用自己提供的密钥，这个密钥是**已知**的并已硬编码到应用程序中，这意味着哈希过程会更不安全。

---

## 建议

如果您打算以哈希方式存储一些私密数据，例如 `IPCPassword`，我们建议您加盐使用 `SCrypt`，这可以提供足够的安全性对抗暴力破解尝试。 `Pbkdf2` 仅出于兼容性考虑才提供，主要是因为我们已有一种可用实现用于 Steam 平台相关用途（例如处理家庭监护代码）。 它仍然被认为是安全的，但与其替代品相比较弱（例如 `SCrypt`）。