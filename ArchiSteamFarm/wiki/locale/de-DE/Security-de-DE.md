# Sicherheit

## Verschlüsselung

ASF unterstützt derzeit die folgenden Verschlüsselungsmethoden als Parameter für `ECryptoMethod`:

| Wert | Name                        |
| ---- | --------------------------- |
| 0    | PlainText                   |
| 1    | AES                         |
| 2    | ProtectedDataForCurrentUser |
| 3    | EnvironmentVariable         |
| 4    | File                        |

Die genaue Beschreibung und Unterschiede zwischen diesen sind nachfolgend verfügbar.

Um ein verschlüsseltes Password zu generieren, z. B. um es mit `SteamPassword` zu verwenden, müssen Sie den **[Befehl](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-de-DE)** `encrypt` mit der gewünschten Verschlüsselungsmethode und Ihrem ursprünglichen Klartext-Passwort ausführen. Danach setzen Sie die verschlüsselte Zeichenfolge als Bot-Konfigurationsvariable `SteamPassword` haben, und ändern Sie schließlich `PasswordFormat` auf diejenige, die Ihrer gewählten Verschlüsselungsmethode entspricht. Einige Formate benötigen keinen `encrypt` Befehl (z. B. `EnvironmentVariable` oder `File`). Fügen Sie einfach den entsprechenden Pfad an.

---

### `PlainText`

Dies ist die einfachste und zugleich unsicherste Sicherungsmethode fürs Passwort, festgelegt durch `PasswordFormat`, mit einem Wert von `0`. ASF erwartet, dass die Zeichenkette im Klartext vorliegt – ein Passwort in seiner direkten Form. Sie ist am einfachsten zu verwenden und zu 100 % kompatibel mit allen Setups, daher ist sie eine Standardmethode zum Speichern von Geheimnissen, für eine sichere Speicherung vollkommen ungeeignet.

---

### `AES`

Nach heutigen Standards als sicher angesehen, wird die Methode **[AES](https://de.wikipedia.org/wiki/Advanced_Encryption_Standard)** zum Speichern des Passworts in Form von `ECryptoMethod` mit einem Wert von `1` definiert. ASF erwartet, dass die Zeichenkette aus einer **[base64 kodierten](https://de.wikipedia.org/wiki/Base64)** Zeichenfolge besteht, die nach der Übersetzung zu einem AES-verschlüsselten Byte-Array führt, das dann mit dem enthaltenen **[Initialisierungsvektor](https://de.wikipedia.org/wiki/Initialisierungsvektor)** und dem ASF-Verschlüsselungsschlüssel dechiffriert werden sollte.

Die oben genannte Methode gewährleistet die Sicherheit, solange der Angreifer den ASF-Verschlüsselungsgeheinis (Schlüssel) nicht kennt, der sowohl zur Entschlüsselung als auch zur Verschlüsselung von Passwörtern verwendet wird. ASF erlaubt es Ihnen, den Schlüssel mit dem **[Befehlszeilenargument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-Line-Arguments-de-DE)** `--cryptkey` anzugeben, den Sie für maximale Sicherheit verwenden sollten. Wenn Sie sich dazu entscheiden es wegzulassen, verwendet ASF seinen eigenen Schlüssel, der **bekannt** und fest in der Anwendung programmiert ist, was bedeutet, dass jeder die ASF-Verschlüsselung umkehren und ein entschlüsseltes Passwort erhalten kann. Es erfordert immer noch etwas Aufwand und ist nicht so einfach zu bewerkstelligen, aber möglich, deshalb sollten Sie fast immer die `AES`-Verschlüsselung mit Ihrem eigenen `--cryptkey` verwenden, den Sie geheim halten sollten. Die in ASF verwendete AES-Methode bietet eine zufriedenstellende Sicherheit und es ist ein Kompromiss zwischen der Einfachheit von `PlainText` und der Komplexität von `ProtectedDataForCurrentUser`, aber es wird dringend empfohlen, sie mit einem benutzerdefinierten `--cryptkey` verwenden. Bei ordnungsgemäßer Verwendung garantiert dies eine angemessene Sicherheit für eine sichere Lagerung.

---

### `ProtectedDataForCurrentUser`

Die derzeit sicherste Art, die von ASF angeboten wird, das Passwort zu verschlüsseln und viel sicherer als die oben beschriebene Methode `AES` ist; definiert als `ECryptoMethod`, mit einem Wert von `2`. Der Hauptvorteil dieser Methode ist gleichzeitig der größte Nachteil; anstelle der Verwendung eines Verschlüsselungsschlüssels (wie in `AES`) werden die Daten mit den Anmeldeinformationen des aktuell angemeldeten Benutzers verschlüsselt. Dies bedeutet, dass es möglich ist, die Daten **ausschließlich** auf dem Gerät zu entschlüsseln, auf dem sie verschlüsselt wurden, und darüber hinaus **nur** durch den Benutzer, der die Verschlüsselung ausgestellt hat. Dadurch wird sichergestellt, dass, wenngleich Sie Ihre komplette `Bot.json` mit verschlüsseltem `SteamPassword` an jemand anderen schicken, er das Passwort nicht ohne direkten Zugriff auf Ihren PC entschlüsseln kann. Dies ist eine ausgezeichnete Sicherheitsmaßnahme, hat aber gleichzeitig den großen Nachteil, am wenigsten kompatibel zu sein, da das mit dieser Methode verschlüsselte Passwort mit jedem anderen Benutzer und Geräte – einschließlich **Ihrem eigenen** – inkompatibel sein wird, wenn Sie sich z. B. für eine Neuinstallation des Betriebssystems entscheiden. Dennoch ist es eine der besten Methoden Passwörter zu speichern und wenn Sie sich um die Sicherheit über `PlainText` sorgen, ohne jedes Mal ein Passwort einzugeben; dann ist dies Ihre beste Wahl, solange Sie nicht von einem anderen Gerät als Ihrem eigenen auf Ihre Konfiguration zugreifen müssen.

**Bitte beachten Sie, dass diese Option derzeit nur auf Windows Betriebssystemen zur Verfügung steht.**

---

### `EnvironmentVariable`

RAM-basierter Speicher definiert als `ECryptoMethod` von `3`. ASF liest das Passwort aus der Umgebungsvariable mit dem angegebenen Namen im Passwortfeld (z. B. `SteamPassword`). Wenn Sie beispielsweise `SteamPassword` auf `ASF_PASSWORD_MYACCOUNT` und `PasswordFormat` auf `3` einstellen, wird ASF die Umgebungsvariable `${ASF_PASSWORD_MYACCOUNT}` auswerten und alles verwenden, was ihm als Kontopasswort zugewiesen wurde.

---

### `Datei`

Datei-basierter Speicher (möglicherweise außerhalb des ASF-Konfigurationsordners) definiert als `ECryptoMethod` von `4`. ASF liest das Passwort aus dem Dateipfad – spezifiziert im Passwortfeld (z. B. `SteamPassword`). Der angegebene Pfad kann entweder absolut oder relativ zum ASF-Quellverzeichnis sein (der Ordner mit enthaltenem `config` Verzeichnis, unter Berücksichtigung vom **[Kommandozeilenargument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments-de-DE#arguments)** `--path`). Diese Methode kann zum Beispiel mit **[Docker-Geheimnissen](https://docs.docker.com/engine/swarm/secrets)** genutzt werden, die solche Dateien zur Verwendung erstellen; aber auch außerhalb von Docker verwendet werden können, sofern Sie selbst eine entsprechende Datei erstellen. Wenn Sie beispielsweise `SteamPassword` auf `/etc/secrets/MyAccount.pass` und `PasswordFormat` auf `4` einstellen, wird ASF `/etc/secrets/MyAccount.pass` auslesen und alles verwenden, was in diese Datei geschrieben wurde.

Stellen Sie sicher, dass die Datei mit dem Passwort nicht von unbefugten Benutzern gelesen werden kann, da dies den gesamten Zweck der Verwendung dieser Methode zunichtemacht.

---

## Verschlüsselungsempfehlungen

Wenn die Kompatibilität für Sie kein Problem darstellt und Sie mit der Funktionsweise der Methode `ProtectedDataForCurrentUser` einverstanden sind, ist diese Option **empfohlen**, um das Passwort in ASF zu speichern, da sie die beste Sicherheit bietet. Die Methode `AES` ist eine gute Wahl für jene, die Ihre Konfigurationen immer noch auf jedem beliebigen Gerät verwenden möchten, während `PlainText` die einfachste Art ist, das Passwort zu speichern; sofern es Ihren nichts ausmacht, dass jeder danach in der JSON-Konfigurationsdatei suchen kann.

Bitte bedenken Sie, dass diese drei Methoden als **unsicher** betrachtet werden, wenn ein Angreifer Zugriff auf Ihren PC hat. ASF muss in der Lage sein, das verschlüsselte Passwort zu entschlüsseln; und wenn das auf Ihrer Maschine laufende Programm dazu in der Lage ist, dann kann auch jede andere auf demselben Gerät ausgeführte Anwendung dies bewältigen. `ProtectedDataForCurrentUser` ist die sicherste Variante, da **auch andere Benutzer, die den gleichen PC verwenden, ihn nicht entschlüsseln können**, aber es ist trotzdem möglich, die Daten zu entschlüsseln, wenn jemand in der Lage ist, Ihre Anmeldedaten und Geräteinformationen zusätzlich zur ASF-Konfigurationsdatei zu stehlen.

Für erweiterte Einrichtungen können Sie `EnvironmentVariable` und `File` verwenden. Diese bieten eine begrenzte Benutzerfreundlichkeit; die `EnvironmentVariable` ist eine gute Idee sein, wenn Sie lieber ein Passwort durch eine benutzerdefinierte Lösung erhalten und es exklusiv im RAM speichern möchten, während `File` beispielsweise für **[Docker Geheimnisse](https://docs.docker.com/engine/swarm/secrets)** gut geeignet ist. Allerdings sind beide unverschlüsselt, sodass Sie das Risiko aus der ASF-Konfigurationsdatei grundsätzlich auf alles umstellen, was Sie aus diesen beiden auswählen.

Zusätzlich zu den oben angegebenen Verschlüsselungsmethoden ist es auch möglich, Passwörter vollständig wegzulassen, zum Beispiel als `SteamPassword` durch Verwendung eines leeren Strings oder `null` Wert. ASF fragt Sie nach Ihrem Passwort, wenn es benötigt wird, und speichert es nirgendwo, außer im Speicher des aktuell laufenden Prozesses, bis Sie diesen schließen. Es ist zwar die sicherste Methode im Umgang mit Passwörtern (diese werden nirgendwo gespeichert), aber auch die lästigste, da Sie Ihr Passwort bei jeder ASF-Ausführung manuell eingeben müssen (sobald es erforderlich ist). Wenn das kein Problem für Sie ist, ist dies vom Sicherheitsaspekt die beste Wahl.

---

## Entschlüsselung

ASF ist nicht in der Lage, verschlüsselte Passwörter zu entschlüsseln, da sie nur intern für den Zugriff auf die Daten innerhalb des Prozesses verwendet werden können. Falls Sie die Verschlüsselung rückgängig machen möchten (z. B. zum Verschieben von ASF auf andere Geräte), wenn `ProtectedDataForCurrentUser` verwendet wird, dann wiederholen Sie einfach die Prozedur in der neuen Umgebung von Anfang an.

---

## Hashing

ASF unterstützt derzeit die folgenden Hashmethoden als Parameter für `EHashingMethod`:

| Wert | Name      |
| ---- | --------- |
| 0    | PlainText |
| 1    | SCrypt    |
| 2    | Pbkdf2    |

Die genaue Beschreibung und Unterschiede zwischen diesen sind nachfolgend aufgelistet.

Um ein Hash zu generieren, z. B. um es mit `IPCPassword` zu verwenden, müssen Sie den `hash` **[Befehl](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-de-DE)** mit der gewünschten Hash-Methode und Ihrem ursprünglichen Klartext-Passwort ausführen. Danach setzen Sie die gehashte Zeichenfolge, die Ihnen als `IPCPassword` ASF-Konfigurationsvariable vorliegt, und schließlich ändern Sie `PasswordFormat` auf dasjenige, das Ihrer gewählten Hash-Methode entspricht.

---

### `PlainText`

Dies ist die einfachste und zugleich unsicherste Methode das Passwort zu speichern, festgelegt durch `EHashingMethod`, mit dem Wert `0`. ASF wird eine Hash generieren, die mit der ursprünglichen Eingabe übereinstimmt. Sie ist am einfachsten zu verwenden und zu 100 % kompatibel mit allen Setups, daher ist sie eine Standardmethode zum Speichern von Geheimnissen, vollkommen unzuverlässig für eine sichere Speicherung.

---

### `SCrypt`

Nach heutigen Standards als sicher angesehen, wird die Methode **[SCrypt](https://de.wikipedia.org/wiki/Scrypt)** zur Hash-Generierung des Passworts in Form von `EHashingMethod` mit dem Wert `1` definiert. ASF verwendet die Implementierung `SCrypt` mit `8` Blöcken, `8192` Iterationen, `32` Hashlänge und Verschlüsselungsschlüssel als **[Salt](https://www.security-insider.de/was-ist-ein-salt-a-1052450/), um das Array von Bytes zu erzeugen. Die resultierenden Bytes werden dann als **[base64](https://de.wikipedia.org/wiki/Base64)** Zeichenkette kodiert.</p>

ASF erlaubt es Ihnen, den Schlüssel (**[Salt](https://www.security-insider.de/was-ist-ein-salt-a-1052450/)) mit dem **[Befehlszeilenargument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-Line-Arguments-de-DE)** `--cryptkey` anzugeben, den Sie für maximale Sicherheit verwenden sollten. Falls Sie sich dazu entscheiden es wegzulassen, verwendet ASF seinen eigenen Schlüssel, der **bekannt** und fest in der Anwendung programmiert ist, was bedeutet, dass die Hash-Generierung unsicherer ist. Bei ordnungsgemäßer Verwendung garantiert eine angemessene Sicherheit für eine sichere Speicherung.</p>

---

### `Pbkdf2`

Nach heutigen Standards als schwach angesehen, wird die Methode **[Pbkdf2](https://de.wikipedia.org/wiki/PBKDF2)** zur Hash-Generierung des Passworts in Form von `EHashingMethod` mit dem Wert `2` definiert. ASF wird die `Pbkdf2` Implementierung mit `10000` Iterationen verwenden `32` Hashlänge und Verschlüsselungsschlüssel als **[Salt](https://www.security-insider.de/was-ist-ein-salt-a-1052450/), mit `SHA-256` als hmac Algorithmus, um das Array von Bytes zu erzeugen. Die resultierenden Bytes werden dann als **[base64](https://de.wikipedia.org/wiki/Base64)** Zeichenkette kodiert.</p>

ASF erlaubt es Ihnen, den Schlüssel (**[Salt](https://www.security-insider.de/was-ist-ein-salt-a-1052450/)) mit dem **[Befehlszeilenargument](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-Line-Arguments-de-DE)** `--cryptkey` anzugeben, den Sie für maximale Sicherheit verwenden sollten. Falls Sie sich dazu entscheiden es wegzulassen, verwendet ASF seinen eigenen Schlüssel, der **bekannt** und fest in der Anwendung programmiert ist, was bedeutet, dass die Hash-Generierung unsicherer ist.</p>

---

## „Hashing“-Empfehlungen

Wenn Sie eine Hashing-Methode verwenden möchten, um einige Geheimnisse zu speichern, wie `IPCPassword`, empfehlen wir, `SCrypt` mit benutzerdefinierten **[Salt](https://www.security-insider.de/was-ist-ein-salt-a-1052450/) zu verwenden, da es eine ausgezeichnete Sicherheit gegen brute force Attacken bietet. `Pbkdf2` wird nur aus Kompatibilitätsgründen angeboten, vor allem weil wir bereits eine funktionierende (und erforderliche) Implementierung für andere Anwendungsfälle auf der Steam Plattform haben (z. B. Familienansicht-Pin). Es wird zwar immer noch als sicher angesehen, aber im Vergleich zu anderen Möglichkeiten (z. B. `SCrypt`) ist diese schwach.</p>