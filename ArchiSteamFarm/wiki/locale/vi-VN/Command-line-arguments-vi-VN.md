# Lệnh khởi chạy

ASF bao gồm hỗ trợ cho một số đối số dòng lệnh có thể ảnh hưởng đến runtime của chương trình. Những người dùng nâng cao có thể sử dụng chúng để chỉ định cách chạy chương trình. So với cách mặc định dùng tệp cấu hình `ASF.json`, các đối số dòng lệnh được sử dụng để khởi tạo phần chính (ví dụ: `--path`), cài đặt dành riêng cho nền tảng (ví dụ: <0 >--system-required</code>) hoặc dữ liệu nhạy cảm (ví dụ: `--cryptkey`).

---

## Mức sử dụng

Cách sử dụng tuỳ thuộc vào hệ điều hành và thị hiếu ASF của bạn.

Chung:

```shell
dotnet ArchiSteamFarm.dll --argument --otherOne
```

Windows:

```powershell
.\ArchiSteamFarm.exe --argument --otherOne
```

Linux/macOS:

```shell
./ArchiSteamFarm --argument --otherOne
```

Đối số dòng lệnh cũng được hỗ trợ trong tập lệnh trợ giúp thông thường chẳng hạn như `ArchiSteamFarm.cmd` hoặc `ArchiSteamFarm.sh`. Ngoài ra, bạn cũng có thể sử dụng thuộc tính môi trường `ASF_ARGS`, như đã nêu trong các phần **[quản lý](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#environment-variables)** và **[docker](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Docker#command-line-arguments)** của chúng tôi.

Nếu đối số của bạn bao gồm khoảng trắng, đừng quên đặt nó trong ngoặc kép. Hai cái đó sai:

```shell
./ArchiSteamFarm --path /home/archi/Tải xuống của Tôi/ASF # Tồi!
./ArchiSteamFarm --path=/home/archi/Tải xuống của Tôi/ASF # Tồi!
```

Tuy nhiên, hai cái đó hoàn toàn ổn:

```shell
./ArchiSteamFarm --path "/home/archi/Tải xuống của Tôi/ASF" # OK
./ArchiSteamFarm "--path=/home/archi/Tải xuống của Tôi/ASF" # OK
```

## Đối số

`--cryptkey <key>` hoặc `--cryptkey=<key>` - sẽ khởi động ASF bằng khoá mật mã tuỳ chỉnh có giá trị `<key>`. Tuỳ chọn này ảnh hưởng đến **[bảo mật](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security)** và sẽ khiến ASF sử dụng khoá `<key>` tùy chỉnh do bạn cung cấp thay vì khoả mặc định được code cứng trong tệp thực thi. Vì thuộc tính này ảnh hưởng đến khoá mã hoá mặc định (cho mục đích mã hoá) cũng như salt (cho mục đích băm), hãy nhớ rằng mọi thứ được mã hoá/băm bằng khoá này sẽ yêu cầu nó được truyền qua mỗi lần chạy ASF.

There is no requirement on `<key>` length or characters, but for security reasons we recommend to pick long enough passphrase made out of e.g. random 32 characters, for example by using `tr -dc A-Za-z0-9 < /dev/urandom | head -c 32; echo` command on Linux.

Thật tuyệt khi đề cập rằng cũng có hai cách khác để cung cấp thông tin chi tiết này: `--cryptkey-file` và `--input-cryptkey`.

Do tính chất của thuộc tính này, bạn cũng có thể đặt khoá mã hoá bằng cách khai báo biến môi trường `ASF_CRYPTKEY`, điều này có thể phù hợp hơn cho những người muốn tránh các khía cạnh nhạy cảm trong các đối số của tiến trình.

---

`--cryptkey-file <path>` hoặc `--cryptkey-file=<path>` - sẽ khởi động ASF bằng khoá mật mã tuỳ chỉnh được đọc từ tập tin `<path>`. Điều này phục vụ cùng một mục đích như `--cryptkey <key>` đã giải thích ở trên, chỉ có cơ chế là khác, vì thuộc tính này sẽ đọc `<key>` từ `<path>` được cung cấp để thay thế. If you're using this together with `--path`, consider declaring `--path` first so relative paths can work correctly.

Do tính chất của thuộc tính này, bạn cũng có thể đặt tệp khoá mã hoá bằng cách khai báo biến môi trường `ASF_CRYPTKEY_FILE`, điều này có thể phù hợp hơn cho những người muốn tránh các khía cạnh nhạy cảm trong các đối số của tiến trình.

---

`--ignore-unsupported-environment` - sẽ khiến ASF bỏ qua các sự cố liên quan đến việc chạy trong môi trường không được hỗ trợ, thường được báo hiệu bằng lỗi và buộc phải thoát. Unsupported environment includes for example running `win-x64` OS-specific build on `linux-x64`. Mặc dù cờ này sẽ cho phép ASF thử chạy trong các tình huống như vậy, nhưng xin lưu ý rằng chúng tôi không hỗ trợ chính thức những trường hợp đó và bạn đang buộc ASF thực hiện điều đó hoàn toàn **tự chịu rủi ro**. It's important to point out that **all** of the unsupported environment scenarios **can be corrected**. Chúng tôi thực sự khuyên bạn nên khắc phục các sự cố còn tồn tại thay vì sử dụng đối số này.

---

`--input-cryptkey` - sẽ khiến ASF hỏi về `--cryptkey` trong khi khởi động. Tuỳ chọn này có thể hữu ích cho bạn nếu thay vì cung cấp khoá mật mã, dù cho trong biến môi trường hay tệp, bạn lại không muốn lưu nó ở bất kỳ đâu và thay vào đó nhập nó theo cách thủ công trong mỗi lần chạy ASF.

---

`--minimized` - sẽ cực tiểu hoá cửa sổ giao diện dòng lệnh của ASF ngay sau khi khởi động. Hữu ích chủ yếu trong các tình huống tự khởi động, nhưng cũng có thể được sử dụng bên ngoài các tình huống đó. Hiện tại, tuỳ chọn dòng lệnh này chỉ có hiệu lực trên các máy Windows.

---

`--network-group <group>` or `--network-group=<group>` - will cause ASF to init its limiters with a custom network group of `<group>` value. This option affects running ASF in **[multiple instances](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#multiple-instances)** by signalizing that given instance is dependent only on instances sharing the same network group, and independent of the rest. Typically you want to use this property only if you're routing ASF requests through custom mechanism (e.g. different IP addresses) and you want to set networking groups yourself, without relying on ASF to do it automatically (which currently includes taking into account `WebProxy` only). Keep in mind that when using a custom network group, this is unique identifier within the local machine, and ASF will not take into account any other details, such as `WebProxy` value, allowing you to e.g. start two instances with different `WebProxy` values which are still dependent on each other.

Due to the nature of this property, it's also possible to set the value by declaring `ASF_NETWORK_GROUP` environment variable, which may be more appropriate for people that would want to avoid sensitive details in the process arguments.

---

`--no-config-migrate` - by default ASF will automatically migrate your config files to latest syntax. Migration includes conversion of deprecated properties into latest ones, removing properties with default values (as they have no effect), as well as cleaning up the file in general (correcting indentation and likewise). This is almost always a good idea, but you might have a particular situation where you'd prefer ASF to never overwrite the config files automatically. For example, you might want to `chmod 400` your config files (read permission for the owner only) or put `chattr +i` over them, in result denying write access for everyone, e.g. as a security measure. Usually we recommend to keep the config migration enabled, but if you have a particular reason for disabling it and would instead prefer ASF to not do that, you can use this switch for achieving that purpose. Keep in mind however, that providing correct settings to ASF will become from now on your new responsibility, especially in regards to deprecations and refactors of properties in future ASF versions.

---

`--no-config-watch` - by default ASF sets up a `FileSystemWatcher` over your `config` directory in order to listen for events related to file changes, so it can interactively adapt to them. For example, this includes stopping bots on config deletion, restarting bot on config being changed, or loading keys into **[BGR](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer)** once you drop them into the `config` directory. This switch allows you to disable such behaviour, which will cause ASF to completely ignore all the changes in `config` directory, requiring from you to do such actions manually, if deemed appropriate (which usually means restarting the process). We recommend to keep the config events enabled, but if you have a particular reason for disabling them and would instead prefer ASF to not do that, you can use this switch for achieving that purpose.

---

`--no-restart` - this switch is mainly used by our **[docker](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Docker)** containers and forces `AutoRestart` of `false`. Unless you have a particular need, you should instead configure `AutoRestart` property directly in your config. This switch is here so our docker script won't need to touch your global config in order to adapt it to its own environment. Of course, if you're running ASF inside a script, you may also make use of this switch (otherwise you're better with global config property).

---

`--no-steam-parental-generation` - by default ASF will automatically attempt to generate Steam parental PINs, as described in **[`SteamParentalCode`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#steamparentalcode)** configuration property. However, since that might require excessive amount of OS resources, this switch allows you to disable that behaviour, which will result in ASF skipping auto-generation and go straight to asking user for PIN instead, which is what would normally happen only if the auto-generation has failed. Usually we recommend to keep the generation enabled, but if you have a particular reason for disabling it and would instead prefer ASF to not do that, you can use this switch for achieving that purpose.

---

`--path <path>` or `--path=<path>` - ASF always navigates to its own directory on startup. By specifying this argument, ASF will navigate to given directory after initialization, which allows you to use custom path for various application parts (including `config`, `logs`, `plugins` and `www` directories, as well as `NLog.config` file), without a need of duplicating binary in the same place. It may come especially useful if you'd like to separate binary from actual config, as it's done in Linux-like packaging - this way you can use one (up-to-date) binary with several different setups. The path can be either relative according to current place of ASF binary, or absolute. Keep in mind that this command points to new "ASF home" - the directory that has the same structure as original ASF, with `config` directory inside, see below example for explanation.

Due to the nature of this property, it's also possible to set expected path by declaring `ASF_PATH` environment variable, which may be more appropriate for people that would want to avoid sensitive details in the process arguments.

If you're considering using this command-line argument for running multiple instances of ASF, we recommend reading our **[management page](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#multiple-instances)** on this manner.

Ví dụ:

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

`--process-required` - declaring this switch will disable default ASF behaviour of shutting down when no bots are running. No auto-shutdown behaviour is especially useful in combination with **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)** where majority of users would expect their web service to be running regardless of the amount of bots that are enabled. If you're using IPC option or otherwise need ASF process to be running all the time until you close it yourself, this is the right option.

If you do not intend to run IPC, this option will be rather useless for you, as you can just start the process again when needed (as opposed to ASF's web server where you require it listening all the time in order to send commands).

---

`--service` - this switch is mainly used by our `systemd` service and forces `Headless` of `true`. Unless you have a particular need, you should instead configure `Headless` property directly in your config. This switch is here so our `systemd` service won't need to touch your global config in order to adapt it to its own environment. Of course, if you have a similar need then you may also make use of this switch (otherwise you're better with global config property).

---

`--system-required` - declaring this switch will cause ASF to try signalizing the OS that the process requires system to be up and running for its entire lifetime. Currently this switch has effect only on Windows machines where it'll forbid your system from going into sleep mode as long as the process is running. This can be proven especially useful when farming on your PC or laptop during night, as ASF will be able to keep your system awake while it's farming, then, once ASF is done, it'll shutdown itself like usual, making your system allowed to enter into sleep mode again, therefore saving power immediately once farming is finished.

Keep in mind that for proper auto-shutdown of ASF you need other settings - especially avoiding `--process-required` and ensuring that all your bots are following `ShutdownOnFarmingFinished` in their `FarmingPreferences`. Of course, auto-shutdown is only a possibility for this feature, not a requirement, since you can also use this flag together with e.g. `--process-required`, effectively making your system awake infinitely after starting ASF.