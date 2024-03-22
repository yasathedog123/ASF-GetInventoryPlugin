# 보안

## Encryption

ASF currently supports the following encryption methods as a definition of `ECryptoMethod`:

| 값 | 이름                          |
| - | --------------------------- |
| 0 | 평문(PlainText)               |
| 1 | 고급 암호화 표준(AES)              |
| 2 | ProtectedDataForCurrentUser |
| 3 | EnvironmentVariable         |
| 4 | 파일                          |

The exact description and comparison of them is available below.

In order to generate encrypted password, e.g. for `SteamPassword` usage, you should execute `encrypt` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** with the appropriate encryption that you chose and your original plain-text password. Afterwards, put the encrypted string that you've got as `SteamPassword` bot config property, and finally change `PasswordFormat` to the one that matches your chosen encryption method. Some formats do not require `encrypt` command, for example `EnvironmentVariable` or `File`, just put appropriate path for them.

---

### `평문(PlainText)`

This is the most simple and insecure way of storing a password, defined as `ECryptoMethod` of `0`. ASF expects the string to be a plain text - a password in its direct form. It's the easiest one to use, and 100% compatible with all the setups, therefore it's a default way of storing secrets, totally insecure for safe storage.

---

### `고급 암호화 표준(AES)`

Considered secure by today standards, **[AES](https://en.wikipedia.org/wiki/Advanced_Encryption_Standard)** way of storing the password is defined as `ECryptoMethod` of `1`. ASF expects the string to be a **[base64-encoded](https://en.wikipedia.org/wiki/Base64)** sequence of characters resulting in AES-encrypted byte array after translation, which then should be decrypted using included **[initialization vector](https://en.wikipedia.org/wiki/Initialization_vector)** and ASF encryption key.

The method above guarantees security as long as attacker doesn't know ASF encryption key which is being used for decryption as well as encryption of passwords. ASF는 `--cryptkey` **[명령줄 인자](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-Line-Arguments-ko-KR)** 를 통해 최대한의 보안을 위해서 특정 키의 사용을 허락합니다. 이를 생략하기로 했다면 ASF는 **알려져있고** 어플리케이션에 하드코딩된 자체 키를 사용할 것입니다. 이는 누구나 ASF 암호화를 뒤집어서 복호화된 암호를 얻을 수 있다는 뜻힙니다. 여전히 약간 노력이 필요하고 하기 쉽지는 않지만, 가능한 일입니다. 이것이 `AES` 암호화는 비밀리에 보관하고 있는 자신만의 `--cryptkey`를 사용해야 하는 이유입니다. ASF에서 사용하는 AES 방법은 만족스러운 보안성을 제공하고 평문(`PlainText`)의 단순함과 `ProtectedDataForCurrentUser`의 복잡성 간의 균형점입니다. 하지만 사용자의 `--cryptkey`와 함께 사용하는 것을 강력하게 권장합니다. If used properly, guarantees decent security for safe storage.

---

### `ProtectedDataForCurrentUser`

Currently the most secure way of encrypting the password that ASF offers, and much safer than `AES` method explained above, is defined as `ECryptoMethod` of `2`. 이 방법의 주된 장점은 동시에 주된 단점입니다. `AES` 등 암호화 키를 사용하는 대신 현재 로그인 된 사용자의 로그인 자격을 이용하여 데이터를 암호화합니다. 즉, **오직** 암호화된 기기에서만, 또한 **오직** 암호화한 사용자만 데이터를 복호화할 수 있습니다. This ensures that even if you send your entire `Bot.json` with encrypted `SteamPassword` using this method to somebody else, he will not be able to decrypt the password without direct access to your PC. This is excellent security measure, but at the same time has a major disadvantage of being least compatible, as the password encrypted using this method will be incompatible with any other user as well as machine - including **your own** if you decide to e.g. reinstall your operating system. Still, it's one of the best methods of storing passwords, and if you're worried about security of `PlainText`, and don't want to put password each time, then this is your best bet as long as you don't have to access your configs from any other machine than your own.

**Please note that this option is available only for machines running Windows OS as of now.**

---

### `EnvironmentVariable`

Memory-based storage defined as `ECryptoMethod` of `3`. ASF will read the password from the environment variable with given name specified in the password field (e.g. `SteamPassword`). For example, setting `SteamPassword` to `ASF_PASSWORD_MYACCOUNT` and `PasswordFormat` to `3` will cause ASF to evaluate `${ASF_PASSWORD_MYACCOUNT}` environment variable and use whatever is assigned to it as the account password.

---

### `파일`

File-based storage (possibly outside of the ASF config directory) defined as `ECryptoMethod` of `4`. ASF will read the password from the file path specified in the password field (e.g. `SteamPassword`). The specified path can be either absolute, or relative to ASF's "home" location (the folder with `config` directory inside, taking into account `--path` **[command-line argument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments#arguments)**). This method can be used for example with **[Docker secrets](https://docs.docker.com/engine/swarm/secrets)**, which create such files for usage, but can also be used outside of Docker if you create appropriate file yourself. For example, setting `SteamPassword` to `/etc/secrets/MyAccount.pass` and `PasswordFormat` to `4` will cause ASF to read `/etc/secrets/MyAccount.pass` and use whatever is written to that file as the account password.

Remember to ensure that file containing the password is not readable by unauthorized users, as that defeats the whole purpose of using this method.

---

## Encryption recommendations

호환성이 문제되지 않고, `ProtectedDataForCurrentUser` 방법의 동작 방법이 괜찮다면 ASF에서 암호를 저장하는 **권장** 옵션입니다. 이는 최고의 보안을 제공합니다. `AES` 방법은 원하는 어느 기기에서나 환경설정을 사용하길 원하는 사람들에게 좋은 선택입니다. 그리고 `평문`은 누구나 JSON 환경설정 파일을 들여다 볼 수 있다는 것을 개의치 않는다면 가장 단순한 암호 저장방식입니다.

공격자가 PC에 접근권한을 가진다면 이 세가지 방법은 모두 **보안에 취약**함을 명심하십시오. ASF must be able to decrypt the encrypted passwords, and if the program running on your machine is capable of doing that, then any other program running on the same machine will be capable of doing so, too. `ProtectedDataForCurrentUser`는 **심지어 같은 PC를 이용하는 다른 사용자도 복호화를 할 수 없을만큼** 가장 안전하지만, 누군가가 로그인 자격과 기기정보, ASF 환경설정 파일을 숨친다면 여전히 복호화는 가능합니다.

For advanced setups, you can utilize `EnvironmentVariable` and `File`. They have limited usability, the `EnvironmentVariable` will be a good idea if you'd prefer to obtain password through some kind of custom solution and store it in memory exclusively, while `File` is good for example with **[Docker secrets](https://docs.docker.com/engine/swarm/secrets)**. Both of them are unencrypted however, so you basically move the risk from ASF config file to whatever you pick from those two.

In addition to encryption methods specified above, it's possible to also avoid specifying passwords entirely, for example as `SteamPassword` by using an empty string or `null` value. ASF will ask you for your password when it's required, and won't save it anywhere but keep in memory of currently running process, until you close it. While being the most secure method of dealing with passwords (they're not saved anywhere), it's also the most troublesome as you need to enter your password manually on each ASF run (when it's required). 문제가 안된다면 가장 보안측면에서 최선의 방법입니다.

---

## 복호화

ASF는 이미 암호화된 암호를 복호화하는 어떠한 방법도 지원하지 않습니다. 복호화 방법은 프로세스 안에서 데이터에 접근하기 위해 내부적으로만 사용됩니다. If you want to revert encryption procedure e.g. for moving ASF to other machine when using `ProtectedDataForCurrentUser`, then simply repeat the procedure from beginning in the new environment.

---

## Hashing

ASF currently supports the following hashing methods as a definition of `EHashingMethod`:

| 값 | 이름            |
| - | ------------- |
| 0 | 평문(PlainText) |
| 1 | SCrypt        |
| 2 | Pbkdf2        |

The exact description and comparison of them is available below.

In order to generate a hash, e.g. for `IPCPassword` usage, you should execute `hash` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** with the appropriate hashing method that you chose and your original plain-text password. Afterwards, put the hashed string that you've got as `IPCPassword` ASF config property, and finally change `IPCPasswordFormat` to the one that matches your chosen hashing method.

---

### `평문(PlainText)`

This is the most simple and insecure way of hashing a password, defined as `EHashingMethod` of `0`. ASF will generate hash matching the original input. It's the easiest one to use, and 100% compatible with all the setups, therefore it's a default way of storing secrets, totally insecure for safe storage.

---

### `SCrypt`

Considered secure by today standards, **[SCrypt](https://en.wikipedia.org/wiki/Scrypt)** way of hashing the password is defined as `EHashingMethod` of `1`. ASF will use the `SCrypt` implementation using `8` blocks, `8192` iterations, `32` hash length and encryption key as a salt to generate the array of bytes. The resulting bytes will then be encoded as **[base64](https://en.wikipedia.org/wiki/Base64)** string.

ASF allows you to specify salt for this method via `--cryptkey` **[command-line argument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-Line-Arguments)**, which you should use for maximum security. If you decide to omit it, ASF will use its own key which is **known** and hardcoded into the application, meaning hashing will be less secure. If used properly, guarantees decent security for safe storage.

---

### `Pbkdf2`

Considered weak by today standards, **[Pbkdf2](https://en.wikipedia.org/wiki/PBKDF2)** way of hashing the password is defined as `EHashingMethod` of `2`. ASF will use the `Pbkdf2` implementation using `10000` iterations, `32` hash length and encryption key as a salt, with `SHA-256` as a hmac algorithm to generate the array of bytes. The resulting bytes will then be encoded as **[base64](https://en.wikipedia.org/wiki/Base64)** string.

ASF allows you to specify salt for this method via `--cryptkey` **[command-line argument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-Line-Arguments)**, which you should use for maximum security. If you decide to omit it, ASF will use its own key which is **known** and hardcoded into the application, meaning hashing will be less secure.

---

## Hashing recommendations

If you'd like to use a hashing method for storing some secrets, such as `IPCPassword`, we recommend to use `SCrypt` with custom salt, as it provides a very decent security against brute-forcing attempts. `Pbkdf2` is offered only for compatibility reasons, mainly because we already have a working (and needed) implementation of it for other use cases across Steam platform (e.g. parental pins). It's still considered secure, but weak compared to alternatives (e.g. `SCrypt`).