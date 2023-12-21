# 명령줄 인자

ASF는 프로그램 실행에 영향을 미칠 수 있는 여러 명령줄 인자에 대한 지원을 포함합니다. 이것은 프로그램이 어떻게 동작해야하는지 특정하기위한 고급사용자가 이용할 수 있습니다. `ASF.json` 설정 파일의 기본 방식과 비교하면, 명령줄 인자는 `--path` 등 주요 초기설정, `--system-required` 등 플랫폼 특화 설정, `--cryptkey` 등 민감한 데이터에 사용합니다.

---

## 사용법

사용중인 OS와 ASF 취향에 따라 사용법이 다릅니다.

일반:

```shell
dotnet ArchiSteamFarm.dll --인자1 --인자2
```

윈도우:

```powershell
.\ArchiSteamFarm.exe --인자1 --인자2
```

Linux/macOS:

```shell
./ArchiSteamFarm --인자1 --인자2
```

명령줄 인자는 `ArchiSteamFarm.cmd`나 `ArchiSteamFarm.sh` 같은 일반 도우미 스크립트에서도 지원합니다. In addition to that, you can also use `ASF_ARGS` environment property, like stated in our **[management](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#environment-variables)** and **[docker](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Docker#command-line-arguments)** sections.

인자에 공백이 들어간다면 따옴표로 표시하는 것을 잊지마십시오.  아래 두개는 잘못되었습니다:

```shell
./ArchiSteamFarm --path /home/archi/My Downloads/ASF # Bad!
./ArchiSteamFarm --path=/home/archi/My Downloads/ASF # Bad!
```

하지만, 다음 두개는 완전히 정상입니다.

```shell
./ArchiSteamFarm --path "/home/archi/My Downloads/ASF" # OK
./ArchiSteamFarm "--path=/home/archi/My Downloads/ASF" # OK
```

## 인자

`--cryptkey <key>` 혹은 `--cryptkey=<key>` - `<key>`값의 자체 암호화 키를 가지고 ASF를 시작합니다. 이 옵션은 **[보안](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security-ko-KR)**에 영향을 주고 ASF가 실행파일에 하드코딩된 기본 키 대신 제공된 자체 `<key>`키를 사용하도록 합니다. Since this property affects default encryption key (for encrypting purposes) as well as salt (for hashing purposes), keep in mind that everything encrypted/hashed with this key will require it to be passed on each ASF run.

There is no requirement on `<key>` length or characters, but for security reasons we recommend to pick long enough passphrase made out of e.g. random 32 characters, for example by using `tr -dc A-Za-z0-9 < /dev/urandom | head -c 32; echo` command on Linux.

It's nice to mention that there are also two other ways to provide this detail: `--cryptkey-file` and `--input-cryptkey`.

이 속성값의 특성때문에 `ASF_CRYPTKEY` 환경 변수를 선언하여 cryptkey를 설정하는 것도 가능합니다. 인자 처리 중 민감한 정보를 피하고 싶은 사람들에게 더 적절합니다.

---

`--cryptkey-file <path>` or `--cryptkey-file=<path>` - will start ASF with custom cryptographic key read from `<path>` file. This serves the same purpose as `--cryptkey <key>` explained above, only the mechanism differs, as this property will read `<key>` from provided `<path>` instead. If you're using this together with `--path`, consider declaring `--path` first so relative paths can work correctly.

Due to the nature of this property, it's also possible to set cryptkey file by declaring `ASF_CRYPTKEY_FILE` environment variable, which may be more appropriate for people that would want to avoid sensitive details in the process arguments.

---

`--ignore-unsupported-environment` - will cause ASF to ignore problems related to running in unsupported environment, which normally is signalized with an error and a forced exit. Unsupported environment includes for example running `win-x64` OS-specific build on `linux-x64`. While this flag will allow ASF to attempt running in such scenarios, be advised that we do not support those officially and you're forcing ASF to do it entirely **at your own risk**. As of today, **all** of the unsupported environment scenarios can be corrected. We strongly recommend to fix the outstanding problems instead of declaring this argument.

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

`--no-restart` - 이 스위치는 주로 **[도커](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Docker-ko-KR)** 컨테이너에서 사용하며 `AutoRestart` 값을 `false`로 강제합니다. Unless you have a particular need, you should instead configure `AutoRestart` property directly in your config. This switch is here so our docker script won't need to touch your global config in order to adapt it to its own environment. 물론 ASF를 스크립트 내부에서 실행하고 있다면 이 스위치를 활용할 수 있습니다. (그렇지 않다면 일반 환경설정 항목이 낫습니다)

---

`--no-steam-parental-generation` - by default ASF will automatically attempt to generate Steam parental PINs, as described in **[`SteamParentalCode`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#steamparentalcode)** configuration property. However, since that might require excessive amount of OS resources, this switch allows you to disable that behaviour, which will result in ASF skipping auto-generation and go straight to asking user for PIN instead, which is what would normally happen only if the auto-generation has failed. Usually we recommend to keep the generation enabled, but if you have a particular reason for disabling it and would instead prefer ASF to not do that, you can use this switch for achieving that purpose.

---

`--path <path>` 혹은 `--path=<path>` - ASF는 설치시에 자체 디렉토리를 탐색합니다. 이 인자를 지정하면 ASF는 설치 후에 주어진 디렉토리를 탐색하고, 바이너리를 동일한 장소에 복제할 필요 없이 `config`, `plugins` 및 `www` 디렉토리와 `NLog.config`파일을 포함하는 다양한 어플리케이션 부분의 사용자 지정경로로 사용할 수 있습니다. 리눅스형태의 패키징에서 그런 것 처럼 바이너리와 실제 환경설정을 분리하고자 할때 특히 유용합니다. 이 방식으로 여러 다른 설치본을 하나의 (최신) 바이너리만으로 사용할 수 있습니다. 경로는 ASF 바이너리의 현재 위치에서 상대경로 또는 절대경로로 지정할 수 있습니다. Keep in mind that this command points to new "ASF home" - the directory that has the same structure as original ASF, with `config` directory inside, see below example for explanation.

이 속성값의 특성때문에 `ASF_PATH` 환경 변수를 선언하여 예상 경로를 설정하는 것도 가능합니다. 프로세스 인자 중 민감한 정보를 피하고 싶은 사람들에게 더 적절합니다.

If you're considering using this command-line argument for running multiple instances of ASF, we recommend reading our **[management page](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#multiple-instances)** on this manner.

예제:

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

`--process-required` - 실행중인 봇이 없는 경우 ASF를 종료하는 기본 설정을 비활성합니다. 자동 종료 금지 설정은 대부분의 사용자가 활성화된 봇의 갯수와 상관없이 웹서비스가 돌아가기를 원하는 **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-ko-KR)**와의 조합에서 특히 유용합니다. IPC 옵션을 사용중이거나 ASF를 직접 종료할때까지 계속 실행되기를 원하는 경우 알맞는 옵션입니다.

IPC를 실행할 생각이 없다면 그다지 쓸모 없습니다. 필요할때마다 ASF를 시작하면 됩니다.(이와 반대로 ASF 웹서버는 당신이 보내는 명령을 위해 항상 대기하고 있습니다)

---

`--service` - this switch is mainly used by our `systemd` service and forces `Headless` of `true`. Unless you have a particular need, you should instead configure `Headless` property directly in your config. This switch is here so our `systemd` service won't need to touch your global config in order to adapt it to its own environment. Of course, if you have a similar need then you may also make use of this switch (otherwise you're better with global config property).

---

`--system-required` - ASF가 전체 생애주기동안 시스템이 살아있어야 한다는 신호를 운영체제에 보내도록 합니다. 현재 이 스위치는 윈도 기기에서만 유효하며 프로세스가 실행되는 한 대기모드로 들어가는 것을 방지합니다. This can be proven especially useful when farming on your PC or laptop during night, as ASF will be able to keep your system awake while it's farming, then, once ASF is done, it'll shutdown itself like usual, making your system allowed to enter into sleep mode again, therefore saving power immediately once farming is finished.

정확한 자동 종료를 위해 다른 ASF 설정도 필요함을 명심하십시오. 특히 `--process-required`를 피하고 모든 봇이 `ShutdownOnFarmingFinished` 설정을 따르는지를 확인하십시오. 물론 자동종료는 이 기능의 오직 한 가능성이고 필요조건은 아닙니다. 예를들어 이 옵션을 `--process-required`와 같이 사용한다면 ASF를 실행한 이후 시스템이 영원히 깨어있도록 할 수 있습니다.