# Komut satırı argümanları

ASF, program çalışma zamanını etkileyebilecek çeşitli komut satırı bağımsız değişkenleri için destek içerir. Bunlar, programın nasıl çalışması gerektiğini belirtmek için ileri düzey kullanıcılar tarafından kullanılabilir. `ASF.json` yapılandırma dosyasının varsayılan yöntemiyle karşılaştırıldığında, komut satırı bağımsız değişkenleri çekirdek başlatma (ör. --`path`), platforma özgü ayarlar (ör. --`system-required`) veya hassas veriler (ör. `--cryptkey`) için kullanılır.

---

## Kullanım

Kullanım işletim sisteminize ve ASF zevkinize göre değişir.

Genel:

```shell
dotnet ArchiSteamFarm.dll --argüman --başkaArgüman
```

Windows:

```powershell
.\ArchiSteamFarm.exe --argüman --başkaArgüman
```

Linux/macOS:

```shell
./ArchiSteamFarm --argüman --başkaArgüman
```

Komut satırı argümanları `ArchiSteamFarm.cmd` veya `ArchiSteamFarm.sh` gibi genel yardımcı betik dosyalarında da kullanılır. Buna ek olarak, **[yönetim](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#environment-variables)** ve **[docker ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Docker#command-line-arguments)** bölümlerimizde belirtildiği gibi `ASF_ARGS` ortam özelliğini de kullanabilirsiniz.

Eğer argümanınızda boşluklar varsa tırnak içinde kullanmayı unutmayın. Şu ikisi hatalıdır:

```shell
./ArchiSteamFarm --path /home/archi/My Downloads/ASF # Kötü!
./ArchiSteamFarm --path=/home/archi/My Downloads/ASF # Kötü!
```

Ancak şu ikisi tamamen hatasızdır:

```shell
./ArchiSteamFarm --path "/home/archi/My Downloads/ASF" # Doğru
./ArchiSteamFarm "--path=/home/archi/My Downloads/ASF" # Doğru
```

## Argümanlar

`--cryptkey <key>` veya `--cryptkey=<key>` - ASF'yi `<key>` değerinde verilen özel kriptografik anahtar ile başlatır. Bu seçenek **[güvenliği](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security)** etkiler ve ASF'nin içine gömülü kriptografik anahtar yerine sizin verdiğiniz özel `<key>` anahtarı kullanılır. Bu değişken varsayılan şifreleme anahtarını (şifreleme için) ve salt değerini (hashing için) değiştirdiği için, sizin sunduğunuz anahtarla şifrelenen/hashlenen her şeyi kullanabilmek için her defasında ASF'ye bu anahtarı vermek zorunda olacağınızı unutmayın.

There is no requirement on `<key>` length or characters, but for security reasons we recommend to pick long enough passphrase made out of e.g. random 32 characters, for example by using `tr -dc A-Za-z0-9 < /dev/urandom | head -c 32; echo` command on Linux.

Bu ayrıntıyı sağlamanın iki yolu daha olduğunu belirtmek güzel:`--cryptkey-file` and `--input-cryptkey`.

Bu değişkenin doğası gereği, cryptkey'i `ASF_CRYPTKEY` ortam değişkeni ile de değiştirebilirsiniz, işlem argümanlarında hassas bilgilerin bulunmamasını isteyen kişiler için daha ideal olur.

---

`--cryptkey-file <path>` ve `--cryptkey-file=<path>` - ASF'yi `<path>` dosyasından okunan özel şifreleme anahtarı ile başlatır. Bu, yukarıda açıklanan `--cryptkey <key>` ile aynı amaca hizmet eder, yalnızca mekanizma farklıdır, çünkü bu özellik bunun yerine `<key>` sağlanandan `<path>` okuyacaktır.

Bu özelliğin doğası gereği, işlem bağımsız değişkenlerinde hassas ayrıntılardan kaçınmak isteyen kişiler için daha uygun olabilecek `ASF_CRYPTKEY_FILE` ortam değişkeni bildirerek cryptkey dosyasını ayarlamak da mümkündür.

---

`--ignore-unsupported-environment` - ASF'nin normalde bir hata ve zorunlu çıkışla işaretlenen desteklenmeyen ortamda çalışmayla ilgili sorunları görmezden gelmesine neden olur. Desteklenmeyen ortam, örneğin, bunun yerine .NET (Core) derlemesini çalıştırıyor olabilecek platformda .NET Framework derlemesi çalıştırmayı içerir. Bu bayrak ASF'nin bu tür senaryolarda koşmaya çalışmasına izin verecek olsa da, bunları resmi olarak desteklemediğimizi ve ASF'yi tamamen **kendi sorumluluğunuzda** yapmaya zorladığınızı unutmayın. Bugün itibariyle, `generic-netf` yerine `generic` yapı çalıştırma gibi desteklenmeyen **tüm** ortam senaryoları düzeltilebilir. Bu argümanı beyan etmek yerine öne çıkan sorunları düzeltmenizi şiddetle tavsiye ederiz.

---

`--input-cryptkey` - ASF'nin başlatma sırasında `--cryptkey` hakkında soru sormasını sağlar. Bu seçenek, ister ortam değişkenlerinde ister bir dosyada olsun, şifreleme anahtarı sağlamak yerine, herhangi bir yere kaydedilmemesini ve bunun yerine her ASF çalıştırılmasında el ile girilmesini tercih ediyorsanız sizin için yararlı olabilir.

---

`--minimized` - ASF konsol penceresinin başlatıldıktan kısa bir süre sonra simge durumuna küçültülmesini sağlar. Esas olarak otomatik başlatma senaryolarında kullanışlıdır, ancak bunların dışında da kullanılabilir. Şu anda bu anahtarın yalnızca Windows makinelerinde etkisi vardır.

---

`--network-group <group>` or `--network-group=<group>` - will cause ASF to init its limiters with a custom network group of `<group>` value. This option affects running ASF in **[multiple instances](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#multiple-instances)** by signalizing that given instance is dependent only on instances sharing the same network group, and independent of the rest. Typically you want to use this property only if you're routing ASF requests through custom mechanism (e.g. different IP addresses) and you want to set networking groups yourself, without relying on ASF to do it automatically (which currently includes taking into account `WebProxy` only). Keep in mind that when using a custom network group, this is unique identifier within the local machine, and ASF will not take into account any other details, such as `WebProxy` value, allowing you to e.g. start two instances with different `WebProxy` values which are still dependent on each other.

Due to the nature of this property, it's also possible to set the value by declaring `ASF_NETWORK_GROUP` environment variable, which may be more appropriate for people that would want to avoid sensitive details in the process arguments.

---

`--no-config-migrate` - by default ASF will automatically migrate your config files to latest syntax. Migration includes conversion of deprecated properties into latest ones, removing properties with default values (as they have no effect), as well as cleaning up the file in general (correcting indentation and likewise). This is almost always a good idea, but you might have a particular situation where you'd prefer ASF to never overwrite the config files automatically. For example, you might want to `chmod 400` your config files (read permission for the owner only) or put `chattr +i` over them, in result denying write access for everyone, e.g. as a security measure. Usually we recommend to keep the config migration enabled, but if you have a particular reason for disabling it and would instead prefer ASF to not do that, you can use this switch for achieving that purpose.

---

`--no-config-watch` - by default ASF sets up a `FileSystemWatcher` over your `config` directory in order to listen for events related to file changes, so it can interactively adapt to them. For example, this includes stopping bots on config deletion, restarting bot on config being changed, or loading keys into **[BGR](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer)** once you drop them into the `config` directory. This switch allows you to disable such behaviour, which will cause ASF to completely ignore all the changes in `config` directory, requiring from you to do such actions manually, if deemed appropriate (which usually means restarting the process). Yapılandırma olaylarını etkin tutmanızı tavsiye ederiz, ancak bunları devre dışı bırakmak için belirli bir nedeniniz varsa ve bunun yerine asf'nin bunu yapmamasını tercih ediyorsanız, bu anahtarı bu amaca ulaşmak için kullanabilirsiniz.

---

`--no-restart` - this switch is mainly used by our **[docker](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Docker)** containers and forces `AutoRestart` of `false`. Unless you have a particular need, you should instead configure `AutoRestart` property directly in your config. This switch is here so our docker script won't need to touch your global config in order to adapt it to its own environment. Of course, if you're running ASF inside a script, you may also make use of this switch (otherwise you're better with global config property).

---

`--no-steam-parental-generation` - by default ASF will automatically attempt to generate Steam parental PINs, as described in **[`SteamParentalCode`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#steamparentalcode)** configuration property. However, since that might require excessive amount of OS resources, this switch allows you to disable that behaviour, which will result in ASF skipping auto-generation and go straight to asking user for PIN instead, which is what would normally happen only if the auto-generation has failed. Usually we recommend to keep the generation enabled, but if you have a particular reason for disabling it and would instead prefer ASF to not do that, you can use this switch for achieving that purpose.

---

`--path <path>` or `--path=<path>` - ASF always navigates to its own directory on startup. By specifying this argument, ASF will navigate to given directory after initialization, which allows you to use custom path for various application parts (including `config`, `plugins` and `www` directories, as well as `NLog.config` file), without a need of duplicating binary in the same place. It may come especially useful if you'd like to separate binary from actual config, as it's done in Linux-like packaging - this way you can use one (up-to-date) binary with several different setups. The path can be either relative according to current place of ASF binary, or absolute. Keep in mind that this command points to new "ASF home" - the directory that has the same structure as original ASF, with `config` directory inside, see below example for explanation.

Due to the nature of this property, it's also possible to set expected path by declaring `ASF_PATH` environment variable, which may be more appropriate for people that would want to avoid sensitive details in the process arguments.

If you're considering using this command-line argument for running multiple instances of ASF, we recommend reading our **[management page](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#multiple-instances)** on this manner.

Örnekler:

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

Keep in mind that for proper auto-shutdown of ASF you need other settings - especially avoiding `--process-required` and ensuring that all your bots are following `ShutdownOnFarmingFinished`. Of course, auto-shutdown is only a possibility for this feature, not a requirement, since you can also use this flag together with e.g. `--process-required`, effectively making your system awake infinitely after starting ASF.