# 编译

编译是生成可执行文件的过程。 如果您希望对 ASF 作出自己的修改，或者出于某种原因不信任官方&#8203;**[发布](https://github.com/JustArchiNET/ArchiSteamFarm/releases)**&#8203;的可执行文件，编译就是您需要做的事。 如果您是用户而不是开发者，则很可能您希望使用已预编译的二进制文件，但如果您想使用自己的二进制文件或学习新内容，请继续阅读。

只要您拥有所有需要的工具，ASF 就可以在任何当前支持的平台上进行编译。

---

## .NET SDK

无论使用什么平台，您都需要完整的 .NET SDK（不仅仅是运行时环境）才能编译 ASF。 您可以在 **[.NET 下载页面](https://dotnet.microsoft.com/download)**&#8203;找到安装指南。 您需要安装适合您操作系统的 .NET SDK 版本。 安装成功后，`dotnet` 命令应该已经可以使用并且正常运行。 您可以执行 `dotnet --info` 命令进行验证。 同样需要确认您的 .NET SDK 匹配 ASF 的&#8203;**[运行时环境需求](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility-zh-CN#运行时环境需求)**。

---

## 编译

假设您已安装适当版本的 .NET SDK，现在只需要前往 ASF 源代码目录（Clone 或者下载并解压的 ASF 仓库）并执行：

```shell
dotnet publish ArchiSteamFarm -c "Release" -o "out/generic"
```

如果您在使用 Linux/macOS，您也可以使用 `cc.sh` 脚本，以稍复杂的方式实现同样的效果。

如果编译成功完成，您可以在 `out/generic` 目录中找到您的 ASF `source` 包。 这与官方的 `generic` 构建相同，但因为这是您自己的构建，所以它强制 `UpdateChannel` 和 `UpdatePeriod` 为 `0`。

### OS-specific（特定操作系统）

如果您需要，也可以生成特定操作系统的 .NET 包。 一般情况下，您不需要这样做，因为您刚刚编译了 `generic` 包，您可以使用已安装的用于编译的 .NET 运行时环境运行此包，但如果您确实需要操作系统包：

```shell
dotnet publish ArchiSteamFarm -c "Release" -o "out/linux-x64" -r "linux-x64"
```

当然，您需要将 `linux-x64` 替换成您需要的目标操作系统架构，例如 `win-x64`。 这一构建也将禁用自动更新。

### ASF-ui

上文是构建可用 ASF 的所有必须步骤，您可能*也*有兴趣了解如何构建我们的图形化 Web 界面 **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-zh-CN#asf-ui)**。 从 ASF 的角度看，您只需要将 ASF 的构建输出放入标准的 `ASF-ui/dist` 路径，然后（如果需要），带上它构建 ASF。

ASF-ui 以 **[Git Submodule](https://git-scm.com/book/en/v2/Git-Tools-Submodules)** 形式作为 ASF 源码树的一部分，您需要确保在克隆仓库时使用 `git clone --recursive`，否则您会缺少必须的文件。 您还必须拥有可用的 NPM，**[Node.js](https://nodejs.org)** 默认已经包含它了。 如果您使用的是 Linux/macOS，我们建议您使用 `cc.sh` 脚本，如果可能（也就是说如果您已经满足上述的所有要求），它将自动处理 ASF-ui 的构建和装载。

除了 `cc.sh` 脚本，我们也在下文附上了简要的构建说明，您可以查阅 [**ASF-ui 仓库**](https://github.com/JustArchiNET/ASF-ui)获得更详细的文档。 同上，在 ASF 源码树根目录下，执行下列命令：

```shell
rm -rf "ASF-ui/dist" # ASF-ui 不会自动清理旧版构建

npm ci --prefix ASF-ui
npm run-script deploy --prefix ASF-ui

rm -rf "out/generic/www" # 确保我们的构建输出不包含旧文件
dotnet publish ArchiSteamFarm -c "Release" -o "out/generic" # 或者根据上文选择您需要的命令
```

您现在应该可以在 `out/generic/www` 目录下看到 ASF-ui 的文件了。 ASF 将能够向浏览器展示这些文件。

或者，您可以直接构建 ASF-ui，无论是手动还是通过我们仓库的帮助来实现，然后手动复制构建输出到 `${OUT}/www` 目录，其中 `${OUT}` 是您通过 `-o` 参数指定的 ASF 输出目录。 这正是 ASF 在构建过程中做的事，如果 `ASF-ui/dist` 存在，它就将其复制到 `${OUT}/www`，没有任何花式操作。

---

## 开发

如果您想要编辑 ASF 代码，您可以使用任何兼容 .NET 的 IDE，但这也是可选的，因为您甚至可以用记事本编辑代码并用上述 `dotnet` 命令编译。 不过，对于 Windows 系统，我们推荐使用[**最新版本的 Visual Studio**](https://visualstudio.microsoft.com/downloads)（免费的社区版即可）。

如果您要在 Linux/macOS 上开发 ASF 代码，我们推荐使用[**最新版的 Visual Studio Code**](https://code.visualstudio.com/download)。 它没有经典的 Visual Studio 那么丰富的功能，但是应该足够了。

当然，以上的所有建议都仅仅是建议，您可以使用您想用的任何工具，最后您都要使用 `dotnet build` 命令进行构建。 我们使用 **[JetBrains Rider](https://www.jetbrains.com/rider)** 进行 ASF 的开发，尽管这个解决方案并不是免费的。

---

## 标签

`main` 分支并不保证能够成功编译或者正常运行 ASF，正如我们在[**发布周期**](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Release-cycle-zh-CN)中所述，这是一个开发分支。 如果您希望从源代码编译或引用 ASF，就应该为此选择适当的[**标签**](https://github.com/JustArchiNET/ArchiSteamFarm/tags)，这样能够保证编译成功，甚至可以正常运行（如果您选择稳定版）。 要检查代码库的“健康状态”，您可以检查我们的 CI——**[GitHub](https://github.com/JustArchiNET/ArchiSteamFarm/actions/workflows/ci.yml?query=branch%3Amain)**。

---

## 官方发布版本

官方 ASF 发布版本由带有满足 ASF **[运行时环境需求](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility-zh-CN#运行时环境需求)**&#8203;的最新版 .NET SDK 的 **[GitHub](https://github.com/JustArchiNET/ArchiSteamFarm/actions)** 编译。 经过测试后，所有的包都会作为 Release 被部署在 GitHub 上。 这也保证了透明度，因为 GitHub 总是为所有构建使用官方公共源，并且您可以检查 GitHub 的 Artifacts 与 GitHub Release 附件的 Checksum（校验和）。 除了私人的开发和调试过程外，ASF 开发人员不会自行编译或发布构建版本。

除此之外，ASF 维护者还会在独立于 GitHub 的远程 ASF 服务器手动验证并发布构建校验和，作为一项额外安全措施。 这个步骤是强制性的，ASF 在自动更新时必须检查通过才认为对应发布版本是有效的。