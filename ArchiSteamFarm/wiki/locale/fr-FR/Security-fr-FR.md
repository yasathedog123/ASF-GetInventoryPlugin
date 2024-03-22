# Sécurité

## Encryption

ASF currently supports the following encryption methods as a definition of `ECryptoMethod`:

| Valeur  | Nom                         |
| ------- | --------------------------- |
| 0       | PlainText                   |
| 1       | AES                         |
| 2       | ProtectedDataForCurrentUser |
| 3       | EnvironmentVariable         |
| 4       | Fichier                     |

The exact description and comparison of them is available below.

In order to generate encrypted password, e.g. for `SteamPassword` usage, you should execute `encrypt` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** with the appropriate encryption that you chose and your original plain-text password. Afterwards, put the encrypted string that you've got as `SteamPassword` bot config property, and finally change `PasswordFormat` to the one that matches your chosen encryption method. Some formats do not require `encrypt` command, for example `EnvironmentVariable` or `File`, just put appropriate path for them.

---

### `PlainText`

This is the most simple and insecure way of storing a password, defined as `ECryptoMethod` of `0`. ASF expects the string to be a plain text - a password in its direct form. It's the easiest one to use, and 100% compatible with all the setups, therefore it's a default way of storing secrets, totally insecure for safe storage.

---

### `AES`

Considered secure by today standards, **[AES](https://en.wikipedia.org/wiki/Advanced_Encryption_Standard)** way of storing the password is defined as `ECryptoMethod` of `1`. ASF expects the string to be a **[base64-encoded](https://en.wikipedia.org/wiki/Base64)** sequence of characters resulting in AES-encrypted byte array after translation, which then should be decrypted using included **[initialization vector](https://en.wikipedia.org/wiki/Initialization_vector)** and ASF encryption key.

The method above guarantees security as long as attacker doesn't know ASF encryption key which is being used for decryption as well as encryption of passwords. ASF vous permet de spécifier la clé via `--cryptkey` **[command-line argument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-Line-Arguments)**, que vous devez utiliser pour une sécurité maximale. Si vous décidez de l'omettre, ASF utilisera sa propre clé **connue** et codée en dur dans l'application, ce qui signifie que tout le monde peut inverser le cryptage ASF et obtenir un mot de passe déchiffré. Cela demande toujours quelques efforts et n’est pas si facile à faire, mais c’est possible, c’est pourquoi vous devriez presque toujours utiliser le cryptage `AES` avec votre propre `--cryptkey` qui est gardé secret. La méthode AES utilisée dans ASF fournit une sécurité qui devrait être satisfaisante. C'est un équilibre entre la simplicité de `PlainText`` et la complexité de <code>ProtectedDataForCurrentUser`, mais il est vivement recommandé de l’utiliser avec la <0>--cryptkey</code> personnalisée. If used properly, guarantees decent security for safe storage.

---

### `ProtectedDataForCurrentUser`

Currently the most secure way of encrypting the password that ASF offers, and much safer than `AES` method explained above, is defined as `ECryptoMethod` of `2`. Le principal avantage de cette méthode est en même temps le principal inconvénient: au lieu d'utiliser une clé de cryptage (comme dans `AES`), les données sont cryptées à l'aide des informations de connexion de l'utilisateur actuellement connecté, ce qui signifie qu'il est possible pour déchiffrer les données **uniquement** sur la machine sur laquelle elles ont été cryptées, et en plus de cela, **uniquement** par l'utilisateur qui a émis le cryptage. This ensures that even if you send your entire `Bot.json` with encrypted `SteamPassword` using this method to somebody else, he will not be able to decrypt the password without direct access to your PC. This is excellent security measure, but at the same time has a major disadvantage of being least compatible, as the password encrypted using this method will be incompatible with any other user as well as machine - including **your own** if you decide to e.g. reinstall your operating system. Still, it's one of the best methods of storing passwords, and if you're worried about security of `PlainText`, and don't want to put password each time, then this is your best bet as long as you don't have to access your configs from any other machine than your own.

**Please note that this option is available only for machines running Windows OS as of now.**

---

### `EnvironmentVariable`

Memory-based storage defined as `ECryptoMethod` of `3`. ASF will read the password from the environment variable with given name specified in the password field (e.g. `SteamPassword`). For example, setting `SteamPassword` to `ASF_PASSWORD_MYACCOUNT` and `PasswordFormat` to `3` will cause ASF to evaluate `${ASF_PASSWORD_MYACCOUNT}` environment variable and use whatever is assigned to it as the account password.

---

### `Fichier`

File-based storage (possibly outside of the ASF config directory) defined as `ECryptoMethod` of `4`. ASF will read the password from the file path specified in the password field (e.g. `SteamPassword`). The specified path can be either absolute, or relative to ASF's "home" location (the folder with `config` directory inside, taking into account `--path` **[command-line argument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments#arguments)**). This method can be used for example with **[Docker secrets](https://docs.docker.com/engine/swarm/secrets)**, which create such files for usage, but can also be used outside of Docker if you create appropriate file yourself. For example, setting `SteamPassword` to `/etc/secrets/MyAccount.pass` and `PasswordFormat` to `4` will cause ASF to read `/etc/secrets/MyAccount.pass` and use whatever is written to that file as the account password.

Remember to ensure that file containing the password is not readable by unauthorized users, as that defeats the whole purpose of using this method.

---

## Encryption recommendations

Si la compatibilité ne vous pose pas problème et que la méthode ` ProtectedDataForCurrentUser </ 0> vous convient, c’est l’option <strong x-id="1"> recommandée </ 1> de stockage du mot de passe dans ASF, car celle-ci fournit la meilleure sécurité. La méthode <code> AES </ 0> est un bon choix pour les personnes qui souhaitent continuer à utiliser leurs configurations sur la machine de leur choix, tandis que <code> PlainText </ 0> est le moyen le plus simple de stocker le mot de passe, si cela ne vous dérange pas que quelqu'un puisse voir le fichier de configuration JSON.</p>

<p spaces-before="0">Veuillez garder à l'esprit que toutes ces 3 méthodes sont considérées comme <strong x-id="1"> non sécurisées </ 0> si l'attaquant a accès à votre PC. ASF must be able to decrypt the encrypted passwords, and if the program running on your machine is capable of doing that, then any other program running on the same machine will be capable of doing so, too. <code> ProtectedDataForCurrentUser </ 0> est la variante la plus sécurisée car <strong x-id="1"> même un autre utilisateur utilisant le même PC ne pourra pas le déchiffrer </ 1>, mais il est toujours possible de déchiffrer les données si quelqu'un est capable de voler. vos identifiants de connexion et vos informations de machine en plus du fichier de configuration ASF.</p>

<p spaces-before="0">For advanced setups, you can utilize <code>EnvironmentVariable` and `File`. They have limited usability, the `EnvironmentVariable` will be a good idea if you'd prefer to obtain password through some kind of custom solution and store it in memory exclusively, while `File` is good for example with **[Docker secrets](https://docs.docker.com/engine/swarm/secrets)**. Both of them are unencrypted however, so you basically move the risk from ASF config file to whatever you pick from those two.

In addition to encryption methods specified above, it's possible to also avoid specifying passwords entirely, for example as `SteamPassword` by using an empty string or `null` value. ASF will ask you for your password when it's required, and won't save it anywhere but keep in memory of currently running process, until you close it. While being the most secure method of dealing with passwords (they're not saved anywhere), it's also the most troublesome as you need to enter your password manually on each ASF run (when it's required). Si cela ne vous pose pas de problème, c’est votre meilleur choix en matière de sécurité.

---

## Déchiffrement

ASF ne prend en charge aucun moyen de déchiffrer des mots de passe déjà chiffrés, car les méthodes de déchiffrement ne sont utilisées qu'en interne pour accéder aux données dans le processus. If you want to revert encryption procedure e.g. for moving ASF to other machine when using `ProtectedDataForCurrentUser`, then simply repeat the procedure from beginning in the new environment.

---

## Hashing

ASF currently supports the following hashing methods as a definition of `EHashingMethod`:

| Valeur  | Nom       |
| ------- | --------- |
| 0       | PlainText |
| 1       | SCrypt    |
| 2       | Pbkdf2    |

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