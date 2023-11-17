# Erweiterte FAQ

In unserem erweiterten FAQ finden Sie Antworten auf die etwas weniger häufig gestellten Fragen die Sie eventuell haben. Für häufiger gestellte Fragen besuchen Sie bitte stattdessen unser **[FAQ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ-de-DE)**.

---

### Wer hat ASF erschaffen?

ASF wurde von **[Archi](https://github.com/JustArchi)** im Oktober 2015 erschaffen. Falls Sie sich wundern- ich bin ein **[Steam-Benutzer](https://steamcommunity.com/profiles/76561198006963719)** genau wie Sie. Neben dem Spielen stelle ich auch gerne meine Fähigkeiten und meine Entschlossenheit zur Verfügung, wie Sie in Kürze feststellen können. Hier ist weder eine große Firma, noch ein Team von Entwicklern noch ein Budget von einer Millionen-Dollar verfügbar um das alles abzudecken - Nur ich, der Dinge repariert, die noch nicht kaputt sind.

ASF ist jedoch ein Open-Source-Projekt, und ich kann nicht genug ausdrücken, dass ich nicht hinter allem stehe, was man hier sehen kann. Wir haben ein paar **[andere](https://github.com/JustArchiNET?q=ASF-)** ASF-Projekte, die fast ausschließlich von anderen Entwicklern entwickelt werden. Sogar das ASF-Kernprojekt hat eine Vielzahl von **[Mitwirkenden](https://github.com/JustArchiNET/ArchiSteamFarm/graphs/contributors)**, die mir geholfen haben, all dies zu erreichen. Darüber hinaus gibt es mehrere Drittanbieter-Dienste, welche die Entwicklung von ASF unterstützen; insbesondere **[GitHub](https://github.com)**, **[JetBrains](https://www.jetbrains.com)** und **[Crowdin](https://crowdin.com)**. Und natürlich darf man nicht all die fantastischen Bibliotheken und Programme vergessen die ASF überhaupt erst ermöglicht haben. Insbesondere **[Rider](https://www.jetbrains.com/rider)**, welches wir als IDE verwenden und wir lieben die **[ReSharper](https://www.jetbrains.com/resharper)**-Erweiterungen und besonders **[SteamKit2](https://github.com/SteamRE/SteamKit)** (ohne dessen ASF überhaupt nicht existieren würde). ASF also wouldn't be where it is today without my **[sponsors](https://github.com/sponsors/JustArchi)** and various donators, supporting me in everything that I'm doing here.

Vielen Dank an alle, die bei der ASF-Entwicklung geholfen haben! Ihr seid super :heart:.

---

### Warum wurde ASF in erster Linie erstellt?

ASF was created with primary purpose of being fully automated Steam farming tool for Linux, without a need of any external dependencies (such as Steam client). Tatsächlich bleibt dies immer noch der Hauptzweck und Fokus, denn mein Konzept von ASF hat sich seitdem nicht geändert und ich benutze es immer noch genauso, wie ich es bereits 2015 benutzt habe. Natürlich gab es seitdem wirklich **viele** Änderungen, und ich bin sehr froh zu sehen wie weit ASF gekommen ist, vor allem dank seiner Benutzer, denn ich würde nie auch nur die Hälfte der Features programmieren wenn es für mich selbst wäre.

It's nice to note that ASF was never made to compete with other, similar programs, especially **[Idle Master](https://www.steamidlemaster.com)**, because ASF was never designed to be a desktop/user app, and it still isn't today. Wenn Du den Hauptzweck von ASF, wie oben beschrieben, analysierst, dann wirst Du sehen wie Idle master **das genaue Gegenteil** von all dem ist. While you can most definitely find similar to ASF programs today, nothing was good enough for me back then (and still isn't today), so I created my own software, the way I wanted it. Benutzer sind im Laufe der Zeit hauptsächlich aufgrund von Robustheit, Stabilität und Sicherheit auf ASF umgestiegen aber auch alle Funktionen, die ich in all diesen Jahren entwickelt habe. Heute ist ASF besser als je zuvor.

---

### Okay, wo ist der Haken? Was nützt Ihnen das Teilen von ASF?

Es gibt keinen Haken. Ich habe ASF **für mich selbst** erstellt und es mit dem Rest der Community geteilt in der Hoffnung, dass es nützlich sein wird. Genau das Gleiche geschah 1991, als Linus Torvalds **[seinen ersten Linux-Kernel](https://groups.google.com/forum/#!msg/comp.os.Minix/dlNtH7RRrGA/SwRavCzVE7gJ)** mit dem Rest der Welt teilte. Es gibt keine versteckte Malware, Data-Mining, Crypto-Mining oder andere Aktivitäten, die mir einen finanziellen Nutzen bringen würden. ASF-Projekt wird vollständig durch nicht-obligatorische Spenden unterstützt, die von glücklichen Benutzern wie Ihnen gesendet werden. Sie können ASF genauso verwenden wie ich es benutze und wenn Sie es mögen, Sie können mir immer einen Kaffee kaufen, der ihre Dankbarkeit für das, was ich tue, zeigt.

Ich benutze auch ASF als perfektes Beispiel für ein modernes C# Projekt, das immer für Perfektion und das bestmögliche Verfahren sorgt, sei es mit Technologie, Projektmanagement oder dem Code selbst. Es ist meine Definition von "Sachen richtig angehen/erledigen". Wenn Sie durch irgendeinen Zufall etwas Nützliches aus meinem Projekt lernen, dann wird das mich nur glücklicher machen.

---

### Right after launching ASF I've lost all my accounts/items/friends/(...)!

Statistically speaking, regardless how sad it is, it's guaranteed that shortly after launching ASF there will be at least one guy who will die in a car accident. The difference is that nobody sane will blame ASF for causing it, but for some reason there are people who will accuse ASF of the same just because it happened to their Steam accounts instead. Of course we can understand the reasoning for that, after all ASF operates within Steam platform, so naturally people will accuse ASF of everything that happened to their Steam-related property regardless of lack of any evidence that the software they ran is even remotely connected with that whatsoever.

ASF, as stated in **[FAQ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#is-it-safe)** as well as **[question above](#ok-where-is-the-catch-what-do-you-gain-from-sharing-asf)**, is free of malware, spyware, data mining and any other potentially unwanted activity, **especially** submission of your sensitive Steam details or taking over your digital property. If something like this has happened to you, we can only say that we're sorry for your loss and recommend you to contact **[Steam support](https://help.steampowered.com)** which hopefully will assist you in the recovery process - because we're not responsible for what happened to you in any way and our conscience is clear. If you believe otherwise, that's your decision, it's pointless to elaborate further, if the above resources providing objective and verifiable ways to confirm our statement didn't convince you, then it's not like anything we write here will anyway.

However, the above doesn't mean that **your actions** done without a common sense with ASF can't contribute to a security issue. For example, you could disregard our security guidelines, expose ASF's **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)** interface to the whole internet, and then be surprised that somebody got in and robbed you out of all items. People do it all the time, they think that if there is no domain or any connection to their IP address then nobody will for sure find out their ASF instance. Right as you read it, there are **thousands** if not more fully-automated bots crawling through the web, including random IP addresses, searching for vulnerabilities to discover, and ASF as a quite popular program is also a target of those. We already had enough of people that got "hacked" through their own stupidity like that, so try to learn from their mistakes and be smarter instead of joining them.

Same goes for security of your PC. Yes, having malware on your PC ruins every single security aspect of ASF, as it can read sensitive details from ASF config files or process memory and even influence the program to do stuff that it wouldn't do otherwise. No, the last crack you've obtained from doubtful source was not a "false positive" as somebody has told you, it's one of the most effective ways to gain control over somebody's PC, the guy will infect himself and he'll even follow the instructions how to, fascinating.

Is using ASF completely safe and free of all risks then? No, we'd be bunch of hypocrites stating so, as **every** software has its security-oriented problems. Contrary to what a lot of companies are doing, we're trying to be as transparent as possible in our **[security advisories](https://github.com/JustArchiNET/ArchiSteamFarm/security/advisories)** and as soon as we find out even a *hypothetical* situation where ASF could contribute in any way to a potentially unwanted from security perspective situation, we announce it immediately. This is what happened with **[CVE-2021-32794](https://github.com/JustArchiNET/ArchiSteamFarm/security/advisories/GHSA-wxx4-66c2-vj2v)** for example, even though ASF didn't have any security flaw per-se, but rather a bug that could lead to user accidentally creating one.

As of today, there are no known, unpatched security flaws in ASF, and as the program is used by more and more people out of which both **[white hats](https://en.wikipedia.org/wiki/White_hat_(computer_security))** as well as **[black hats](https://en.wikipedia.org/wiki/Black_hat_(computer_security))** analyze its source code, the overall trust factor only increases with time, as the number of security flaws to find out is finite, and ASF as a program that focuses first and foremost on its security, definitely isn't making it easy for finding one. Regardless of our best intentions, we still recommend to stay cool-headed and always be wary of potential security threats, ones coming from ASF usage as well.

---

### Wie stelle ich sicher, dass die heruntergeladenen Dateien echt sind?

As part of our releases on GitHub, we utilize a very similar verification process as the one used by **[Debian](https://www.debian.org/CD/verify)**. In every official release starting with ASF V5.1.3.3, in addition to `zip` files you can find `SHA512SUMS` and `SHA512SUMS.sign` files. Laden Sie diese zu Überprüfungszwecken zusammen mit den `zip`-Dateien ihrer Wahl herunter.

Firstly, you should use `SHA512SUMS` file in order to verify that `SHA-512` checksum of the selected `zip` files matches the one we calculated ourselves. On Linux, you can use `sha512sum` utility for that purpose.


```
$ sha512sum -c --ignore-missing SHA512SUMS
ASF-linux-x64.zip: OK
```

On Windows, we can do that from powershell, although you have to manually verify with `SHA512SUMS`:

```
PS > Get-Content SHA512SUMS | Select-String -Pattern ASF-linux-x64.zip

f605e573cc5e044dd6fadbc44f6643829d11360a2c6e4915b0c0b8f5227bc2a257568a014d3a2c0612fa73907641d0cea455138d2e5a97186a0b417abad45ed9  ASF-linux-x64.zip


PS > Get-FileHash -Algorithm SHA512 -Path ASF-linux-x64.zip

Algorithm       Hash                                                                   Path
---------       ----                                                                   ----
SHA512          F605E573CC5E044DD6FADBC44F6643829D11360A2C6E4915B0C0B8F5227BC2A2575... ASF-linux-x64.zip
```

This way we ensured that whatever was written to `SHA512SUMS` matches the resulting files and they weren't tampered with. However, it doesn't prove yet that `SHA512SUMS` file you checked against really comes from us. For that, we'll use `SHA512SUMS.sign` file, which holds digital PGP signature proving the authenticity of `SHA512SUMS`. We can use `gpg` utility for that purpose, both on **[Linux](https://gnupg.org/download/index.html)** and **[Windows](https://gpg4win.org)** (change `gpg` command into `gpg.exe` on Windows).

```
$ gpg --verify SHA512SUMS.sign SHA512SUMS
gpg: Signature made Mon 02 Aug 2021 00:34:18 CEST
gpg:                using EDDSA key 224DA6DB47A3935BDCC3BE17A3D181DF2D554CCF
gpg: Can't check signature: No public key
```

As you can see, the file indeed holds a valid signature, but of unknown origin. You'll need to import ArchiBot's **[public key](https://raw.githubusercontent.com/JustArchi-ArchiBot/JustArchi-ArchiBot/main/ArchiBot_public.asc)** that we sign the `SHA-512` sums with for full validation.

```
$ curl https://raw.githubusercontent.com/JustArchi-ArchiBot/JustArchi-ArchiBot/main/ArchiBot_public.asc -o ArchiBot_public.asc
$ gpg --import ArchiBot_public.asc
gpg: /home/archi/.gnupg/trustdb.gpg: trustdb created
gpg: key A3D181DF2D554CCF: public key "ArchiBot <ArchiBot@JustArchi.net>" imported
gpg: Total number processed: 1
gpg:               imported: 1

```

Finally, you can verify the `SHA512SUMS` file again:

```
$ gpg --verify SHA512SUMS.sign SHA512SUMS
gpg: Signature made Mon 02 Aug 2021 00:34:18 CEST
gpg:                using EDDSA key 224DA6DB47A3935BDCC3BE17A3D181DF2D554CCF
gpg: Good signature from "ArchiBot <ArchiBot@JustArchi.net>" [unknown]
gpg: WARNING: This key is not certified with a trusted signature!
gpg:          There is no indication that the signature belongs to the owner.
Primary key fingerprint: 224D A6DB 47A3 935B DCC3  BE17 A3D1 81DF 2D55 4CCF
```

This has verified that the `SHA512SUMS.sign` holds a valid signature of our `224DA6DB47A3935BDCC3BE17A3D181DF2D554CCF` key for `SHA512SUMS` file that you've verified against.

You could be wondering where the last warning comes from. You've successfully imported our key, but didn't decide to trust it just yet. While this is not mandatory, we can cover it as well. Normally this includes verifying through different channel (e.g. phone call, SMS) that the key is valid, then signing the key with your own to trust it. For this example, you can consider this wiki entry as such (very weak) different channel, since the original key comes from **[ArchiBot's profile](https://github.com/JustArchi-ArchiBot)**. In any case we'll assume that you have enough of confidence as it is.

Firstly, **[generate private key for yourself](https://help.ubuntu.com/community/GnuPrivacyGuardHowto#Generating_an_OpenPGP_Key)**, if you don't have one just yet. We'll use `--quick-gen-key` as a quick example.

```
$ gpg --batch --passphrase '' --quick-gen-key "$(whoami)"
gpg: /home/archi/.gnupg/trustdb.gpg: trustdb created
gpg: key E4E763905FAD148B marked as ultimately trusted
gpg: directory '/home/archi/.gnupg/openpgp-revocs.d' created
gpg: revocation certificate stored as '/home/archi/.gnupg/openpgp-revocs.d/8E5D685F423A584569686675E4E763905FAD148B.rev'
```

Now you can sign our key with yours in order to trust it:

```
$ gpg --sign-key 224DA6DB47A3935BDCC3BE17A3D181DF2D554CCF

pub  ed25519/A3D181DF2D554CCF
     created: 2021-05-22  expires: never       usage: SC
     trust: unknown       validity: unknown
sub  cv25519/E527A892E05B2F38
     created: 2021-05-22  expires: never       usage: E
[ unknown] (1). ArchiBot <ArchiBot@JustArchi.net>


pub  ed25519/A3D181DF2D554CCF
     created: 2021-05-22  expires: never       usage: SC
     trust: unknown       validity: unknown
 Primary key fingerprint: 224D A6DB 47A3 935B DCC3  BE17 A3D1 81DF 2D55 4CCF

     ArchiBot <ArchiBot@JustArchi.net>

Are you sure that you want to sign this key with your
key "archi" (E4E763905FAD148B)

Really sign? (y/N) y
```

And done, after trusting our key, `gpg` should no longer display the warning when verifying:

```
$ gpg --verify SHA512SUMS.sign SHA512SUMS
gpg: Signature made Mon 02 Aug 2021 00:34:18 CEST
gpg:                using EDDSA key 224DA6DB47A3935BDCC3BE17A3D181DF2D554CCF
gpg: Good signature from "ArchiBot <ArchiBot@JustArchi.net>" [full]
```

Notice the `[unknown]` trust indicator changing into `[full]` once you signed our key with yours.

Congratulations, you've verified that nobody has tampered with the release you've downloaded! 👍

---

### Es ist der 1. April und die ASF-Sprache wechselt in etwas Seltsames. Was geht da vor?

CONGRATULASHUNS ZUR ENTDECKUNG UNSERES APRILSCHERZES! Sofern Sie die `CurrentCulture` Einstellung nicht definiert haben, verwendet ASF am 1. April anstelle der System-Sprache die Lokalisation **[LOLcat](https://de.wikipedia.org/wiki/Lolcat)**. Wenn Sie dieses Verhalten deaktivieren möchten, können Sie einfach `CurrentCulture` auf die Lokalisation setzen, das Sie stattdessen verwenden möchten. Schön ist auch, dass Sie unseren Aprilscherz bedingungslos aktivieren können, indem Sie ihren `CurrentCulture`-Wert auf `qps-Ploc` setzen.