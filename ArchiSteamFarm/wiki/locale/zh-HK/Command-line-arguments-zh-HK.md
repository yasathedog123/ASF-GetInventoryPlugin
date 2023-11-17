# 命令列參數

ASF 支援一些能夠影響程式運行時的命令列參數。 高級用戶可使用這些參數以定義程式運行方式。 與`ASF.json `配置文件的預設方式相比，命令列參數可用於核心初始化（例如`--path`）、平台特定設置（例如`--system-required`）或敏感性資料（例如`--cryptkey`）。

---

## 使用方法

使用方法取決於您的操作系統和ASF版本。

Generic（通用）:

```shell
dotnet ArchiSteamFarm.dll --參數 -- 另一個參數
```

Windows:

```powershell
.\ArchiSteamFarm.exe --參數--另一個參數
```

Linux/macOS:

```shell
./ArchiSteamFarm --參數--另一個參數
```

命令列參數也可用於通用助手腳本中，例如`ArchiSteamFarm.cmd`或`ArchiSteamFarm.sh`。 In addition to that, you can also use `ASF_ARGS` environment property, like stated in our **[management](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#environment-variables)** and **[docker](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Docker#command-line-arguments)** sections.

若您的參數包含空格，請務必使用引號將其括住。 兩個錯誤示例：

```shell
./ArchiSteamFarm --path /home/archi/My Downloads/ASF # Bad!
./ArchiSteamFarm --path=/home/archi/My Downloads/ASF # Bad!
```

兩個正確示例：

```shell
./ArchiSteamFarm --path "/home/archi/My Downloads/ASF" # OK
./ArchiSteamFarm "--path=/home/archi/My Downloads/ASF" # OK
```

## 參數

`--cryptkey<key>`或`--cryptkey=<key>`──將使用值為`<key>`的自訂密鑰啟動 ASF。 此選項會影響**[安全性](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security)**，並將導致ASF使用您的自訂密鑰 `<key>`，而不是硬編碼在程式中的預設值。 Since this property affects default encryption key (for encrypting purposes) as well as salt (for hashing purposes), keep in mind that everything encrypted/hashed with this key will require it to be passed on each ASF run.

There is no requirement on `<key>` length or characters, but for security reasons we recommend to pick long enough passphrase made out of e.g. random 32 characters, for example by using `tr -dc A-Za-z0-9 < /dev/urandom | head -c 32; echo` command on Linux.

It's nice to mention that there are also two other ways to provide this detail: `--cryptkey-file` and `--input-cryptkey`.

Due to the nature of this property, it's also possible to set cryptkey by declaring `ASF_CRYPTKEY` environment variable, which may be more appropriate for people that would want to avoid sensitive details in the process arguments.

---

`--cryptkey-file <path>` or `--cryptkey-file=<path>` - will start ASF with custom cryptographic key read from `<path>` file. This serves the same purpose as `--cryptkey <key>` explained above, only the mechanism differs, as this property will read `<key>` from provided `<path>` instead.

Due to the nature of this property, it's also possible to set cryptkey file by declaring `ASF_CRYPTKEY_FILE` environment variable, which may be more appropriate for people that would want to avoid sensitive details in the process arguments.

---

`--ignore-unsupported-environment` - will cause ASF to ignore problems related to running in unsupported environment, which normally is signalized with an error and a forced exit. Unsupported environment includes for example running .NET Framework build on platform that could be running .NET (Core) build instead. While this flag will allow ASF to attempt running in such scenarios, be advised that we do not support those officially and you're forcing ASF to do it entirely **at your own risk**. As of today, **all** of the unsupported environment scenarios can be corrected, such as running `generic` build instead of `generic-netf`. We strongly recommend to fix the outstanding problems instead of declaring this argument.

---

`--input-cryptkey` - will make ASF ask about the `--cryptkey` during startup. This option might be useful for you if instead of providing cryptkey, whether in environment variables or a file, you'd prefer to not have it saved anywhere and instead input it manually on each ASF run.

---

`--minimized` - will make ASF console window minimize shortly after start. Useful mainly in auto-start scenarios, but can also be used outside of those. Currently this switch has effect only on Windows machines.

---

`--network-group <group>` or `--network-group=<group>` - will cause ASF to init its limiters with a custom network group of `<group>` value. This option affects running ASF in **[multiple instances](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#multiple-instances)** by signalizing that given instance is dependent only on instances sharing the same network group, and independent of the rest. Typically you want to use this property only if you're routing ASF requests through custom mechanism (e.g. different IP addresses) and you want to set networking groups yourself, without relying on ASF to do it automatically (which currently includes taking into account `WebProxy` only). Keep in mind that when using a custom network group, this is unique identifier within the local machine, and ASF will not take into account any other details, such as `WebProxy` value, allowing you to e.g. start two instances with different `WebProxy` values which are still dependent on each other.

Due to the nature of this property, it's also possible to set the value by declaring `ASF_NETWORK_GROUP` environment variable, which may be more appropriate for people that would want to avoid sensitive details in the process arguments.

---

`--no-config-migrate` - by default ASF will automatically migrate your config files to latest syntax. Migration includes conversion of deprecated properties into latest ones, removing properties with default values (as they have no effect), as well as cleaning up the file in general (correcting indentation and likewise). This is almost always a good idea, but you might have a particular situation where you'd prefer ASF to never overwrite the config files automatically. For example, you might want to `chmod 400` your config files (read permission for the owner only) or put `chattr +i` over them, in result denying write access for everyone, e.g. as a security measure. Usually we recommend to keep the config migration enabled, but if you have a particular reason for disabling it and would instead prefer ASF to not do that, you can use this switch for achieving that purpose.

---

`--no-config-watch` - by default ASF sets up a `FileSystemWatcher` over your `config` directory in order to listen for events related to file changes, so it can interactively adapt to them. For example, this includes stopping bots on config deletion, restarting bot on config being changed, or loading keys into **[BGR](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer)** once you drop them into the `config` directory. This switch allows you to disable such behaviour, which will cause ASF to completely ignore all the changes in `config` directory, requiring from you to do such actions manually, if deemed appropriate (which usually means restarting the process). We recommend to keep the config events enabled, but if you have a particular reason for disabling them and would instead prefer ASF to not do that, you can use this switch for achieving that purpose.

---

`--no-restart`──此開關主要用於**[Docker](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Docker)**&#8203;容器並將 `AutoRestart` 強制設置為 `false`。 Unless you have a particular need, you should instead configure `AutoRestart` property directly in your config. This switch is here so our docker script won't need to touch your global config in order to adapt it to its own environment. 當然，如果您在腳本中運行 ASF，也可以使用此開關（否則您最好使用全域配置屬性）。

---

`--no-steam-parental-generation` - by default ASF will automatically attempt to generate Steam parental PINs, as described in **[`SteamParentalCode`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#steamparentalcode)** configuration property. However, since that might require excessive amount of OS resources, this switch allows you to disable that behaviour, which will result in ASF skipping auto-generation and go straight to asking user for PIN instead, which is what would normally happen only if the auto-generation has failed. Usually we recommend to keep the generation enabled, but if you have a particular reason for disabling it and would instead prefer ASF to not do that, you can use this switch for achieving that purpose.

---

`--path <path>`或`--path=<path>`──ASF在啟動時始終會導航至自身所在的目錄。 By specifying this argument, ASF will navigate to given directory after initialization, which allows you to use custom path for various application parts (including `config`, `plugins` and `www` directories, as well as `NLog.config` file), without a need of duplicating binary in the same place. 如果您想將二進位檔案和實際配置檔案分開，這可能會非常有用，類似Linux 打包機制——這樣您就可以在多個設置中共用一個（最新的）二進位檔案。 此路徑既可以是基於當前 ASF 二進位檔案所在位置的相對路徑，也可以是絕對路徑。 Keep in mind that this command points to new "ASF home" - the directory that has the same structure as original ASF, with `config` directory inside, see below example for explanation.

Due to the nature of this property, it's also possible to set expected path by declaring `ASF_PATH` environment variable, which may be more appropriate for people that would want to avoid sensitive details in the process arguments.

If you're considering using this command-line argument for running multiple instances of ASF, we recommend reading our **[management page](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#multiple-instances)** on this manner.

範例:

```shell
dotnet /opt/ASF/ArchiSteamFarm.dll --path /opt/TargetDirectory # Absolute path
dotnet /opt/ASF/ArchiSteamFarm.dll --path ../TargetDirectory # Relative path works as well
ASF_PATH=/opt/TargetDirectory dotnet /opt/ASF/ArchiSteamFarm.dll # Same as env variable
```

```text
├── /opt
│     ├── ASF
│     │     ├── ArchiSteamFarm.dll
│     │     └── ...
│     └── TargetDirectory
│           ├── config
│           ├── logs (generated)
│           ├── plugins (optional)
│           ├── www (optional)
│           ├── log.txt (generated)
│           └── NLog.config (optional)
└── ...
```

---

`--process-required`──預設情況下，ASF 將會在無機械人運行的情況下關閉，聲明此開關將禁用這一行為。 阻止自動關機功能在和**[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)**配合下特別有用，大多數用戶都希望他們的 Web 服務正常運行，無論啟用了多少個機械人。 如果您在使用 IPC 或者需要 ASF 進程持續運行直至手動關閉它，這就是正確的選項。

如果您不打算運行 IPC，此選項對您來說將相當無用， 因為您可以在需要時再次啟動該過程 (而不是 ASF 的 web 伺服器，在那裏您需要它一直偵聽以發送命令)。

---

`--service` - this switch is mainly used by our `systemd` service and forces `Headless` of `true`. Unless you have a particular need, you should instead configure `Headless` property directly in your config. This switch is here so our `systemd` service won't need to touch your global config in order to adapt it to its own environment. Of course, if you have a similar need then you may also make use of this switch (otherwise you're better with global config property).

---

`--system-required`──聲明此開關將導致 ASF 嘗試通知操作系統「此進程要求系統在其存留期內處於啟動狀態並正常運行」。 當前，此開關僅對 Windows 電腦有效，只要ASF進程正在運行，它就會阻止您的系統進入睡眠模式。 This can be proven especially useful when farming on your PC or laptop during night, as ASF will be able to keep your system awake while it's farming, then, once ASF is done, it'll shutdown itself like usual, making your system allowed to enter into sleep mode again, therefore saving power immediately once farming is finished.

請注意，要让 ASF正確地自動關閉，您還需要其他設置──特別是避免 `--process-required`，且確保所有機械人都已啟用 `ShutdownOnFarmingFinished`。 當然，自動關機只是這個參數的用法之一，而非必需，因為您還可以將此參數配合 `--process-required` 使用，從而有效地使您的系統在 ASF 啟動之後無限運行下去。