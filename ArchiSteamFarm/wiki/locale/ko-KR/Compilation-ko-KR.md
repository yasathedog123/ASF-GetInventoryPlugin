# 컴파일

컴파일은 실행가능한 파일을 만드는 과정입니다. 만약 ASF에 자신이 만든 변경사항을 추가하고 싶거나 공식 **[릴리스](https://github.com/JustArchiNET/ArchiSteamFarm/releases-ko-KR)** 에서 제공하는 실행파일을 무슨 이유에서건 신뢰하지 않는 경우 하게 됩니다. 만약 당신이 개발자가 아니라 사용자라면 대부분 이미 컴파일된 바이너리를 사용하길 원할겁니다. 하지만 자신만의 바이너리를 사용하고 싶거나 뭔가 새로운 것을 배우고 싶다면 계속 읽으시기 바랍니다.

ASF는 필요로 하는 도구를 모두 가지고만 있다면 현재 지원되는 어떠한 플랫폼에서도 컴파일 될 수 있습니다.

---

## .NET SDK

Regardless of platform, you need full .NET SDK (not just runtime) in order to compile ASF. Installation instructions can be found on **[.NET download page](https://dotnet.microsoft.com/download)**. You need to install appropriate .NET SDK version for your OS. 성공적인 설치 후에 `dotnet` 명령이 작동하고 실행되어야 합니다. `dotnet --info` 로 작동 여부를 확인할 수 있습니다. Also ensure that your .NET SDK matches ASF **[runtime requirements](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility#runtime-requirements)**.

---

## 컴파일

Assuming you have .NET SDK operative and in appropriate version, simply navigate to source ASF directory (cloned or downloaded and unpacked ASF repo) and execute:

```shell
dotnet publish ArchiSteamFarm -c "Release" -f "net7.0" -o "out/generic"
```

If you're using Linux/macOS, you can instead use `cc.sh` script which will do the same, in a bit more complex manner.

컴파일이 성공적으로 끝나면 `out/generic` 디렉토리에 `소스` 맛으로 된 ASF가 있습니다. 이것은 공식 `일반` ASF 빌드도 동일하지만, 자체 빌드에 적합하도록 `UpdateChannel`과 `UpdatePeriod`이 `0` 값으로 되어있다는 점만 다릅니다.

### OS 특화

You can also generate OS-specific .NET package if you have a specific need. In general you shouldn't do that because you've just compiled `generic` flavour that you can run with your already-installed .NET runtime that you've used for the compilation in the first place, but just in case you want to:

```shell
dotnet publish ArchiSteamFarm -c "Release" -f "net7.0" -o "out/linux-x64" -r "linux-x64"
```

물론 대상으로 하는 OS 아키텍쳐에 따라 `linux-x64`를 `win-x64` 등으로 변경하십시오. 이 빌드도 업데이트가 비활성화됩니다.

### .NET Framework

In a very rare case when you'd want to build `generic-netf` package, you can change target framework from `net7.0` to `net481`. Keep in mind that you'll need appropriate **[.NET Framework](https://dotnet.microsoft.com/download/visual-studio-sdks)** developer pack for compiling `netf` variant, in addition to .NET SDK, so the below will work only on Windows:

```shell
dotnet publish ArchiSteamFarm -c "Release" -f "net481" -o "out/generic-netf"
```

In case of being unable to install .NET Framework or even .NET SDK itself (e.g. because of building on `linux-x86` with `mono`), you can call `msbuild` directly. You'll also need to specify `ASFNetFramework` manually, as ASF by default disables `netf` build on non-Windows platforms:

```shell
msbuild /m /r /t:Publish /p:Configuration=Release /p:TargetFramework=net481 /p:PublishDir=out/generic-netf /p:ASFNetFramework=true ArchiSteamFarm
```

### ASF-ui

While the above steps are everything that is required to have a fully working build of ASF, you may *also* be interested in building **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-ui)**, our graphical web interface. From ASF side, all you need to do is dropping ASF-ui build output in standard `ASF-ui/dist` location, then building ASF with it (again, if needed).

ASF-ui is part of ASF's source tree as a **[git submodule](https://git-scm.com/book/en/v2/Git-Tools-Submodules)**, ensure that you've cloned the repo with `git clone --recursive`, as otherwise you'll not have the required files. You'll also need a working NPM, **[Node.js](https://nodejs.org)** comes with it. If you're using Linux/macOS, we recommend our `cc.sh` script, which will automatically cover building and shipping ASF-ui (if possible, that is, if you're meeting the requirements we've just mentioned).

In addition to the `cc.sh` script, we also attach the simplified build instructions below, refer to **[ASF-ui repo](https://github.com/JustArchiNET/ASF-ui)** for additional documentation. From ASF's source tree location, so as above, execute the following commands:

```shell
rm -rf "ASF-ui/dist" # ASF-ui doesn't clean itself after old build

npm ci --prefix ASF-ui
npm run-script deploy --prefix ASF-ui

rm -rf "out/generic/www" # Ensure that our build output is clean of the old files
dotnet publish ArchiSteamFarm -c "Release" -f "net7.0" -o "out/generic" # Or accordingly to what you need as per the above
```

You should now be able to find the ASF-ui files in your `out/generic/www` folder. ASF will be able to serve those files to your browser.

Alternatively, you can simply build ASF-ui, whether manually or with the help of our repo, then copy the build output over to `${OUT}/www` folder manually, where `${OUT}` is the output folder of ASF that you've specified with `-o` parameter. This is exactly what ASF is doing as part of the build process, it copies `ASF-ui/dist` (if exists) over to `${OUT}/www`, nothing fancy.

---

## 개발

If you'd like to edit ASF code, you can use any .NET compatible IDE for that purpose, although even that is optional, since you can as well edit with a notepad and compile with `dotnet` command described above. 하지만 윈도우의 경우 **[최신버전의 Visual Studio](https://visualstudio.microsoft.com/downloads)**를 권장합니다. (무료 커뮤니티 버전이면 충분합니다)

If you'd like to work with ASF code on Linux/macOS instead, we recommend **[latest Visual Studio Code](https://code.visualstudio.com/download)**. 고전 Visual Studio만큼 풍족하진 않지만, 충분히 좋습니다.

물론 위의 모든 제안은 단지 권장사항일 뿐이고, 당신은 원하는 모든 것을 사용할 수 있지만, 결국 `dotnet build` 명령으로 귀결됩니다. We use **[JetBrains Rider](https://www.jetbrains.com/rider)** for ASF development, although it's not a free solution.

---

## 태그

`main` branch is not guaranteed to be in a state that allows successful compilation or flawless ASF execution in the first place, since it's development branch just like stated in our **[release cycle](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Release-cycle)**. ASF를 소스에서 컴파일하거나 참조하려면 목적에 맞는 적절한 **[태그](https://github.com/JustArchiNET/ArchiSteamFarm/tags)** 를 사용해야 합니다. 이는 최소한 성공적인 컴파일을 보장하고, 안정 릴리스로 표시된 빌드는 거의 흠없는 실행도 가능합니다. In order to check the current "health" of the tree, you can use our CI - **[GitHub](https://github.com/JustArchiNET/ArchiSteamFarm/actions/workflows/ci.yml?query=branch%3Amain)**.

---

## 공식 릴리스

Official ASF releases are compiled by **[GitHub](https://github.com/JustArchiNET/ArchiSteamFarm/actions)** on Windows, with latest .NET SDK that matches ASF **[runtime requirements](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility#runtime-requirements)**. After passing tests, all packages are deployed as the release, also on GitHub. This also guarantees transparency, since GitHub always uses official public source for all builds, and you can compare checksums of GitHub artifacts with GitHub release assets. ASF 개발자는 개인 개발과정과 디버깅을 제외하고는 스스로 컴파일하거나 빌드를 게시하지 않습니다.

Starting from ASF V5.2.0.5, in addition to the above, ASF maintainers manually validate and publish build checksums on independent from GitHub, remote server, as additional security measure. This step is mandatory for existing ASFs to consider the release as a valid candidate for auto-update functionality.