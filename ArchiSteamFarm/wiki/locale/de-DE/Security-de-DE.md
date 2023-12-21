# Sicherheit

## Verschlüsselung

ASF unterstützt derzeit die folgenden Verschlüsselungsmethoden als Parameter für `ECryptoMethod`:

| Wert | Name                        |
| ---- | --------------------------- |
| 0    | PlainText                   |
| 1    | AES                         |
| 2    | ProtectedDataForCurrentUser |
| 3    | EnvironmentVariable         |
| 4    | Datei                       |

Die genaue Beschreibung und Unterschiede zwischen diesen sind nachfolgend verfügbar.

Um ein verschlüsseltes Password zu generieren, z. B. um es mit `SteamPassword` zu verwenden, müssen Sie den `encrypt` **[Befehl](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-de-DE)** mit der gewünschten Verschlüsselungsmethode und Ihrem ursprünglichen klartext Passwort ausführen. Danach setzen Sie die verschlüsselte Zeichenfolge, die Sie als `SteamPassword` Bot-Konfigurationseigenschaft haben, und ändern Sie schließlich `PasswordFormat` auf diejenige, die Ihrer gewählten Verschlüsselungsmethode entspricht. Some formats do not require `encrypt` command, for example `EnvironmentVariable` or `File`, just put appropriate path for them.

---

### `PlainText`

Dies ist die einfachste und zugleich unsicherste Methode das Passwort zu speichern, festgelegt durch `PasswordFormat` mit einem Wert von `0`. ASF erwartet, dass die Zeichenkette ein Klartext ist - ein Passwort in seiner direkten Form. Sie ist am einfachsten zu benutzen und zu 100% kompatibel mit allen Setups, daher ist sie eine Standardmethode zum Speichern von Geheimnissen, völlig unsicher für eine sichere Speicherung.

---

### `AES`

Considered secure by today standards, **[AES](https://en.wikipedia.org/wiki/Advanced_Encryption_Standard)** way of storing the password is defined as `ECryptoMethod` of `1`. ASF expects the string to be a **[base64-encoded](https://en.wikipedia.org/wiki/Base64)** sequence of characters resulting in AES-encrypted byte array after translation, which then should be decrypted using included **[initialization vector](https://en.wikipedia.org/wiki/Initialization_vector)** and ASF encryption key.

The method above guarantees security as long as attacker doesn't know ASF encryption key which is being used for decryption as well as encryption of passwords. ASF erlaubt es dir, den Schlüssel mit dem **[Befehlszeilenargument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-Line-Arguments-de-DE)** `--cryptkey` anzugeben, den Du für maximale Sicherheit verwenden solltest. Wenn Du dich dazu entscheidest es wegzulassen, verwendet ASF seinen eigenen Schlüssel, der **bekannt** und fest in der Anwendung programmiert ist, was bedeutet, dass jeder die ASF-Verschlüsselung umkehren und ein entschlüsseltes Passwort erhalten kann. Es erfordert immer noch etwas Aufwand und ist nicht so einfach zu bewerkstelligen, aber möglich, deshalb solltest Du fast immer `AES` Verschlüsselung mit Ihrem eigenen `--cryptkey` verwenden, den Du geheim halten solltest. Die in ASF verwendete AES-Methode bietet eine zufriedenstellende Sicherheit und es ist ein Kompromiss zwischen der Einfachheit von `PlainText` und der Komplexität von `ProtectedDataForCurrentUser`, aber es wird dringend empfohlen, sie mit benutzerdefinierten `--cryptkey` zu verwenden. Bei ordnungsgemäßer Verwendung garantiert eine angemessene Sicherheit für eine sichere Lagerung.

---

### `ProtectedDataForCurrentUser`

Currently the most secure way of encrypting the password that ASF offers, and much safer than `AES` method explained above, is defined as `ECryptoMethod` of `2`. Der Hauptvorteil dieser Methode ist gleichzeitig der größte Nachteil - anstelle der Verwendung eines Verschlüsselungsschlüssels (wie in `AES`) werden die Daten mit den Anmeldeinformationen des aktuell angemeldeten Benutzers verschlüsselt, was bedeutet, dass es möglich ist die Daten **nur** auf dem Computer zu entschlüsseln, auf dem sie verschlüsselt wurden, und darüber hinaus **nur** durch den Benutzer der die Verschlüsselung ausgestellt hat. This ensures that even if you send your entire `Bot.json` with encrypted `SteamPassword` using this method to somebody else, he will not be able to decrypt the password without direct access to your PC. This is excellent security measure, but at the same time has a major disadvantage of being least compatible, as the password encrypted using this method will be incompatible with any other user as well as machine - including **your own** if you decide to e.g. reinstall your operating system. Still, it's one of the best methods of storing passwords, and if you're worried about security of `PlainText`, and don't want to put password each time, then this is your best bet as long as you don't have to access your configs from any other machine than your own.

**Please note that this option is available only for machines running Windows OS as of now.**

---

### `EnvironmentVariable`

Memory-based storage defined as `ECryptoMethod` of `3`. ASF will read the password from the environment variable with given name specified in the password field (e.g. `SteamPassword`). For example, setting `SteamPassword` to `ASF_PASSWORD_MYACCOUNT` and `PasswordFormat` to `3` will cause ASF to evaluate `${ASF_PASSWORD_MYACCOUNT}` environment variable and use whatever is assigned to it as the account password.

---

### `Datei`

File-based storage (possibly outside of the ASF config directory) defined as `ECryptoMethod` of `4`. ASF will read the password from the file path specified in the password field (e.g. `SteamPassword`). The specified path can be either absolute, or relative to ASF's "home" location (the folder with `config` directory inside, taking into account `--path` **[command-line argument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments#arguments)**). This method can be used for example with **[Docker secrets](https://docs.docker.com/engine/swarm/secrets)**, which create such files for usage, but can also be used outside of Docker if you create appropriate file yourself. For example, setting `SteamPassword` to `/etc/secrets/MyAccount.pass` and `PasswordFormat` to `4` will cause ASF to read `/etc/secrets/MyAccount.pass` and use whatever is written to that file as the account password.

Remember to ensure that file containing the password is not readable by unauthorized users, as that defeats the whole purpose of using this method.

---

## Empfehlung

Wenn die Kompatibilität für dich kein Problem ist und Du mit der Funktionsweise der `ProtectedDataForCurrentUser` Methode einverstanden bist, ist diese Option **empfohlen** um das Passwort in ASF zu speichern, da sie die beste Sicherheit bietet. Die Methode `AES` ist eine gute Wahl für Leute, die Ihre Konfigurationen immer noch auf jedem beliebigen Computer verwenden möchten, während `PlainText` die einfachste Art ist das Passwort zu speichern, wenn es Ihren nichts ausmacht, dass jeder danach in der JSON-Konfigurationsdatei suchen kann.

Bitte bedenke, dass diese 3 Methoden als **unsicher** betrachtet werden, wenn ein Angreifer Zugriff auf Ihren PC hat. ASF muss in der Lage sein das verschlüsselte Passwort zu entschlüsseln und wenn das auf deiner Maschine laufende Programm dazu in der Lage ist, dann kann auch jedes andere auf dem selben Gerätlaufende Programm dies tun. `ProtectedDataForCurrentUser` ist die sicherste Variante, da **auch andere Benutzer, die den gleichen PC verwenden, ihn nicht entschlüsseln können**, aber es ist trotzdem möglich die Daten zu entschlüsseln, wenn jemand in der Lage ist Ihre Login-Informationen und Maschineninformationen zusätzlich zur ASF-Konfigurationsdatei zu stehlen.

For advanced setups, you can utilize `EnvironmentVariable` and `File`. They have limited usability, the `EnvironmentVariable` will be a good idea if you'd prefer to obtain password through some kind of custom solution and store it in memory exclusively, while `File` is good for example with **[Docker secrets](https://docs.docker.com/engine/swarm/secrets)**. Both of them are unencrypted however, so you basically move the risk from ASF config file to whatever you pick from those two.

In addition to encryption methods specified above, it's possible to also avoid specifying passwords entirely, for example as `SteamPassword` by using an empty string or `null` value. ASF will ask you for your password when it's required, and won't save it anywhere but keep in memory of currently running process, until you close it. While being the most secure method of dealing with passwords (they're not saved anywhere), it's also the most troublesome as you need to enter your password manually on each ASF run (when it's required). Wenn das kein Problem für dich ist ist dies die beste Wahl in Bezug auf Sicherheit.

---

## Entschlüsselung

ASF unterstützt keine Möglichkeit, bereits verschlüsselte Passwörter zu entschlüsseln, da Entschlüsselungsmethoden nur intern für den Zugriff auf die Daten innerhalb des Prozesses verwendet werden. If you want to revert encryption procedure e.g. for moving ASF to other machine when using `ProtectedDataForCurrentUser`, then simply repeat the procedure from beginning in the new environment.

---

## Hashing

ASF unterstützt derzeit die folgenden Hashmethoden als Parameter für `EHashingMethod`:

| Wert | Name      |
| ---- | --------- |
| 0    | PlainText |
| 1    | SCrypt    |
| 2    | Pbkdf2    |

Die genaue Beschreibung und Unterschiede zwischen diesen sind nachfolgend verfügbar.

In order to generate a hash, e.g. for `IPCPassword` usage, you should execute `hash` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** with the appropriate hashing method that you chose and your original plain-text password. Afterwards, put the hashed string that you've got as `IPCPassword` ASF config property, and finally change `IPCPasswordFormat` to the one that matches your chosen hashing method.

---

### `PlainText`

This is the most simple and insecure way of hashing a password, defined as `EHashingMethod` of `0`. ASF will generate hash matching the original input. Sie ist am einfachsten zu benutzen und zu 100% kompatibel mit allen Setups, daher ist sie eine Standardmethode zum Speichern von Geheimnissen, völlig unsicher für eine sichere Speicherung.

---

### `SCrypt`

Considered secure by today standards, **[SCrypt](https://en.wikipedia.org/wiki/Scrypt)** way of hashing the password is defined as `EHashingMethod` of `1`. ASF will use the `SCrypt` implementation using `8` blocks, `8192` iterations, `32` hash length and encryption key as a salt to generate the array of bytes. The resulting bytes will then be encoded as **[base64](https://en.wikipedia.org/wiki/Base64)** string.

ASF allows you to specify salt for this method via `--cryptkey` **[command-line argument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-Line-Arguments)**, which you should use for maximum security. If you decide to omit it, ASF will use its own key which is **known** and hardcoded into the application, meaning hashing will be less secure. If used properly, guarantees decent security for safe storage.

---

### `Pbkdf2`

Considered weak by today standards, **[Pbkdf2](https://en.wikipedia.org/wiki/PBKDF2)** way of hashing the password is defined as `EHashingMethod` of `2`. ASF will use the `Pbkdf2` implementation using `10000` iterations, `32` hash length and encryption key as a salt, with `SHA-256` as a hmac algorithm to generate the array of bytes. The resulting bytes will then be encoded as **[base64](https://en.wikipedia.org/wiki/Base64)** string.

ASF allows you to specify salt for this method via `--cryptkey` **[command-line argument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-Line-Arguments)**, which you should use for maximum security. If you decide to omit it, ASF will use its own key which is **known** and hardcoded into the application, meaning hashing will be less secure.

---

## Empfehlung

If you'd like to use a hashing method for storing some secrets, such as `IPCPassword`, we recommend to use `SCrypt` with custom salt, as it provides a very decent security against brute-forcing attempts. `Pbkdf2` is offered only for compatibility reasons, mainly because we already have a working (and needed) implementation of it for other use cases across Steam platform (e.g. parental pins). It's still considered secure, but weak compared to alternatives (e.g. `SCrypt`).