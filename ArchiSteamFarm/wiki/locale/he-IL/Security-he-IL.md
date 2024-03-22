# אבטחה

## Encryption

ASF currently supports the following encryption methods as a definition of `ECryptoMethod`:

| Value | שם                          |
| ----- | --------------------------- |
| 0     | PlainText                   |
| 1     | AES                         |
| 2     | ProtectedDataForCurrentUser |
| 3     | EnvironmentVariable         |
| 4     | File                        |

The exact description and comparison of them is available below.

In order to generate encrypted password, e.g. for `SteamPassword` usage, you should execute `encrypt` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** with the appropriate encryption that you chose and your original plain-text password. Afterwards, put the encrypted string that you've got as `SteamPassword` bot config property, and finally change `PasswordFormat` to the one that matches your chosen encryption method. Some formats do not require `encrypt` command, for example `EnvironmentVariable` or `File`, just put appropriate path for them.

---

### `PlainText`

This is the most simple and insecure way of storing a password, defined as `ECryptoMethod` of `0`. ASF expects the string to be a plain text - a password in its direct form. It's the easiest one to use, and 100% compatible with all the setups, therefore it's a default way of storing secrets, totally insecure for safe storage.

---

### `AES`

Considered secure by today standards, **[AES](https://en.wikipedia.org/wiki/Advanced_Encryption_Standard)** way of storing the password is defined as `ECryptoMethod` of `1`. ASF expects the string to be a **[base64-encoded](https://en.wikipedia.org/wiki/Base64)** sequence of characters resulting in AES-encrypted byte array after translation, which then should be decrypted using included **[initialization vector](https://en.wikipedia.org/wiki/Initialization_vector)** and ASF encryption key.

The method above guarantees security as long as attacker doesn't know ASF encryption key which is being used for decryption as well as encryption of passwords. ASF allows you to specify key via `--cryptkey` **[command-line argument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-Line-Arguments)**, which you should use for maximum security. If you decide to omit it, ASF will use its own key which is **known** and hardcoded into the application, meaning anybody can reverse the ASF encryption and get decrypted password. It still requires some effort and is not that easy to do, but possible, that's why you should almost always use `AES` encryption with your own `--cryptkey` which is kept in secret. AES method used in ASF provides security that should be satisfying and it's a balance between simplicity of `PlainText` and complexity of `ProtectedDataForCurrentUser`, but it's highly recommended to use it with custom `--cryptkey`. If used properly, guarantees decent security for safe storage.

---

### `ProtectedDataForCurrentUser`

Currently the most secure way of encrypting the password that ASF offers, and much safer than `AES` method explained above, is defined as `ECryptoMethod` of `2`. The major advantage of this method is at the same time the major disadvantage - instead of using encryption key (like in `AES`), data is encrypted using login credentials of currently logged in user, which means that it's possible to decrypt the data **only** on the machine it was encrypted on, and in addition to that, **only** by the user who issued the encryption. This ensures that even if you send your entire `Bot.json` with encrypted `SteamPassword` using this method to somebody else, he will not be able to decrypt the password without direct access to your PC. This is excellent security measure, but at the same time has a major disadvantage of being least compatible, as the password encrypted using this method will be incompatible with any other user as well as machine - including **your own** if you decide to e.g. reinstall your operating system. Still, it's one of the best methods of storing passwords, and if you're worried about security of `PlainText`, and don't want to put password each time, then this is your best bet as long as you don't have to access your configs from any other machine than your own.

**Please note that this option is available only for machines running Windows OS as of now.**

---

### `EnvironmentVariable`

Memory-based storage defined as `ECryptoMethod` of `3`. ASF will read the password from the environment variable with given name specified in the password field (e.g. `SteamPassword`). For example, setting `SteamPassword` to `ASF_PASSWORD_MYACCOUNT` and `PasswordFormat` to `3` will cause ASF to evaluate `${ASF_PASSWORD_MYACCOUNT}` environment variable and use whatever is assigned to it as the account password.

---

### `File`

File-based storage (possibly outside of the ASF config directory) defined as `ECryptoMethod` of `4`. ASF will read the password from the file path specified in the password field (e.g. `SteamPassword`). The specified path can be either absolute, or relative to ASF's "home" location (the folder with `config` directory inside, taking into account `--path` **[command-line argument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments#arguments)**). This method can be used for example with **[Docker secrets](https://docs.docker.com/engine/swarm/secrets)**, which create such files for usage, but can also be used outside of Docker if you create appropriate file yourself. For example, setting `SteamPassword` to `/etc/secrets/MyAccount.pass` and `PasswordFormat` to `4` will cause ASF to read `/etc/secrets/MyAccount.pass` and use whatever is written to that file as the account password.

Remember to ensure that file containing the password is not readable by unauthorized users, as that defeats the whole purpose of using this method.

---

## Encryption recommendations

If compatibility is not an issue for you, and you're fine with the way how `ProtectedDataForCurrentUser` method works, it is the **recommended** option of storing the password in ASF, as it provides the best security. `AES` method is a good choice for people who still want to make use of their configs on any machine they want, while `PlainText` is the most simple way of storing the password, if you don't mind that anybody can look into JSON configuration file for it.

Please keep in mind that all of those 3 methods are considered **insecure** if attacker has access to your PC. ASF must be able to decrypt the encrypted passwords, and if the program running on your machine is capable of doing that, then any other program running on the same machine will be capable of doing so, too. `ProtectedDataForCurrentUser` is the most secure variant as **even other user using the same PC will not be able to decrypt it**, but it's still possible to decrypt the data if somebody is able to steal your login credentials and machine info in addition to ASF config file.

For advanced setups, you can utilize `EnvironmentVariable` and `File`. They have limited usability, the `EnvironmentVariable` will be a good idea if you'd prefer to obtain password through some kind of custom solution and store it in memory exclusively, while `File` is good for example with **[Docker secrets](https://docs.docker.com/engine/swarm/secrets)**. Both of them are unencrypted however, so you basically move the risk from ASF config file to whatever you pick from those two.

In addition to encryption methods specified above, it's possible to also avoid specifying passwords entirely, for example as `SteamPassword` by using an empty string or `null` value. ASF will ask you for your password when it's required, and won't save it anywhere but keep in memory of currently running process, until you close it. While being the most secure method of dealing with passwords (they're not saved anywhere), it's also the most troublesome as you need to enter your password manually on each ASF run (when it's required). If that's not a problem for you, this is your best bet security-wise.

---

## Decryption

ASF doesn't support any way of decrypting already encrypted passwords, as decryption methods are used only internally for accessing the data inside the process. If you want to revert encryption procedure e.g. for moving ASF to other machine when using `ProtectedDataForCurrentUser`, then simply repeat the procedure from beginning in the new environment.

---

## Hashing

ASF currently supports the following hashing methods as a definition of `EHashingMethod`:

| Value | שם        |
| ----- | --------- |
| 0     | PlainText |
| 1     | SCrypt    |
| 2     | Pbkdf2    |

The exact description and comparison of them is available below.

In order to generate a hash, e.g. for `IPCPassword` usage, you should execute `hash` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** with the appropriate hashing method that you chose and your original plain-text password. Afterwards, put the hashed string that you've got as `IPCPassword` ASF config property, and finally change `IPCPasswordFormat` to the one that matches your chosen hashing method.

---

### `PlainText`

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