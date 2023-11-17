# Two-factor authentication

Steam includes two-factor authentication system known as "Escrow" that requires extra details for various account-related activity. You can read more about it **[here](https://help.steampowered.com/faqs/view/2E6E-A02C-5581-8904)** and **[here](https://help.steampowered.com/faqs/view/34A1-EA3F-83ED-54AB)**. This page considers that 2FA system as well as our solution that integrates with it, called ASF 2FA.

---

# ASF logic

Regardless if you use ASF 2FA or not, ASF includes proper logic and is fully aware of accounts protected by standard 2FA. It will ask you for required details when they're needed (such as during logging in). However, those requests can be automated by using ASF 2FA, which will automatically generate required tokens, saving you hassle and enabling extra functionality (described below).

---

# ASF 2FA

ASF 2FA is a built-in module responsible for providing 2FA features to the ASF process, such as generating tokens and accepting confirmations. It works by duplicating your existing authenticator details, so that you can use your current authenticator and ASF 2FA at the same time.

You can verify whether your bot account is using ASF 2FA already by executing `2fa` **[commands](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**. Unless you've already imported your authenticator as ASF 2FA, all standard `2fa` commands will be non-operative, which means that your account is not using ASF 2FA, therefore it's also unavailable for advanced ASF features that require the module to be operative.

---

# Recommendations

There are a lot of ways to make ASF 2FA operative, here we include our recommendations based on your current situation:

- If you're already using SteamDesktopAuthenticator, WinAuth or any other third-party app that allows you to extract 2FA details with ease, just **[import](#import)** those to ASF.
- If you're using official app and you don't mind resetting your 2FA credentials, the best way is to disable 2FA, then **[create](#creation)** new 2FA credentials by using **[joint authenticator](#joint-authenticator)**, which will allow you to use official app and ASF 2FA. This method doesn't require root or advanced knowledge, barely following instructions.
- If you're using official app and don't want to recreate your 2FA credentials, your options are very limited, typically you'll need root and extra fiddling around to **[import](#import)** those details, and even with that it might be impossible.
- If you're not using 2FA yet and don't care, you can use ASF 2FA with **[standalone authenticator](#standalone-authenticator)**, third-party app **[duplicating](#import)** to ASF (recommendation #1), or **[joint authenticator](#joint-authenticator)** with official app (recommendation #2).

Below we discuss all possible options and known to us methods.

---

## Creation

In general, we strongly recommend **[duplicating](#import)** your existing authenticator, since that's the main purpose ASF 2FA was designed for. However, ASF comes with an official `MobileAuthenticator` **[plugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)** that further extends ASF 2FA, allowing you to link a completely new authenticator as well. This can be useful in case you're unable or unwilling to use other tools and do not mind ASF 2FA becoming your main (and maybe only) authenticator.

There are two possible scenarios for adding a two-factor authenticator with the `MobileAuthenticator` **[plugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)**: standalone or joint with the official Steam mobile app. In the second scenario, you will end up with the same authenticator on both the ASF and mobile app; both will generate the same codes, and both will be able to confirm trade offers, Steam Community Market transactions, etc.

### Common steps for both scenarios

No matter if you plan to use ASF as the standalone authenticator or want the same authenticator on the official Steam mobile app, you need to do those initialization steps:

1. Create an ASF bot for the target account, start it, and log in, which you probably already did.
2. Assign a working and operational phone number to the account **[here](https://store.steampowered.com/phone/manage)** to be used by the bot. A phone number is absolutely required, as there is no way to add 2FA without it.
3. Ensure you're not using 2FA yet for your account, if you do, disable it first.
4. Execute the `2fainit [Bot]` command, replacing `[Bot]` with your bot's name.

Assuming you got a successful reply, the following two things have happened:

- A new `<Bot>.maFile.PENDING` file was generated by ASF in your `config` directory.
- SMS was sent from Steam to the phone number you have assigned for the account above.

The authenticator details are not operational yet, however, you can review the generated file if you'd like to. If you want to be double safe, you can, for example, already write down the revocation code. The next steps will depend on your selected scenario.

### Standalone authenticator

If you want to use ASF as your main (or even only) authenticator, now you need to do the finalization step:

5. Execute the `2fafinalize [Bot] <ActivationCode>` command, replacing `[Bot]` with your bot's name and `<ActivationCode>` with the code you've received through SMS in the previous step.

### Joint authenticator

If you want to have the same authenticator in both ASF and the official Steam mobile app, now you need to do the next steps:

5. Ignore the SMS that you received after the previous step.
6. Install the Steam mobile app if it's not installed yet, and open it. Navigate to the Steam Guard tab and add a new authenticator by following the app's instructions.
7. After your authenticator in the mobile app is added and working, return to ASF. You now need to tell ASF that finalization is done with the help of one of the two commands below:
 - Wait until the next 2fa code is shown in the Steam mobile app, and use the command `2fafinalized [Bot] <2fa_code_from_app>` replacing `[Bot]` with your bot's name and `<2fa_code_from_app>` with the code you currently see in the Steam mobile app. If the code generated by ASF and the code you provided are the same, ASF assumes that an authenticator was added correctly and proceeds with importing your newly created authenticator.
 - We strongly recommend to do the above in order to ensure that your credentials are valid. However, if you don't want to (or can't) check if codes are the same and you know what you're doing, you can instead use the command `2fafinalizedforce [Bot]`, replacing `[Bot]` with your bot's name. ASF will assume that the authenticator was added correctly and proceed with importing your newly created authenticator.

### After finalization

Assuming everything worked properly, the previously generated `<Bot>.maFile.PENDING` file was renamed to `<Bot>.maFile.NEW`. This indicates that your 2FA credentials are now valid and active. We recommend that you create a copy of that file and keep it in **a secure and safe location**. In addition to that, we recommend you open the file in your editor of choice and write down the `revocation_code`, which will allow you to, as the name implies, revoke the authenticator in case you lose it.

In regard to technical details, the generated `maFile` includes all details that we have received from the Steam server during linking the authenticator, and in addition to that, the `device_id` field, which may be needed for other authenticators. The file is fully compatible with **[SDA](#steamdesktopauthenticator)** for import.

ASF automatically imports your authenticator once the procedure is done, and therefore `2fa` and other related commands should now be operational for the bot account you linked the authenticator to.

---

## Import

Import process requires already linked and operational authenticator that is supported by ASF. ASF currently supports a few different official and unofficial sources of 2FA - Android, iOS, SteamDesktopAuthenticator and WinAuth, on top of manual method which allows you to provide required credentials yourself. If you don't have any authenticator yet, you need to choose one of available apps and set it up firstly. If you don't know better which one to pick, we recommend WinAuth, but any of the above will work fine assuming you follow the instructions.

All following guides require from you to already have **working and operational** authenticator being used with given tool/application. ASF 2FA will not operate properly if you import invalid data, therefore make sure that your authenticator works properly before attempting to import it. This does include testing and verifying that following authenticator functions work properly:
- You can generate tokens and those tokens are accepted by Steam network
- You can fetch confirmations, and they are arriving on your mobile authenticator
- You can accept those confirmations, and they're properly recognized by Steam network as confirmed/rejected

Ensure that your authenticator works by checking if above actions work - if they don't, then they won't work in ASF either, you'll only waste time and cause yourself additional trouble.

---

### Android phone

**The below instructions apply to Steam app in version `2.X`, there are currently limited **[resources](https://github.com/JustArchiNET/ArchiSteamFarm/discussions/2786)** on extracting required details from version `3.0` onwards. We'll update this section once generally-available method is found. As of today, a workaround would be to intentionally install older version of Steam app, register 2FA and extract the required details first, after which it's possible to update the application to latest version - existing authenticator will continue to work.**

In general for importing authenticator from your Android phone you will need **[root](https://en.wikipedia.org/wiki/Rooting_(Android_OS))** access. Rooting varies from device to device, so I won't tell you how to root your device. Visit **[XDA](https://www.xda-developers.com/root)** for excellent guides on how to do that, as well as general information on rooting in general. If you can't find your device or the guide that you need, try to find it on google second.

At least officially, it's not possible to access protected Steam files without root. The only official non-root method for extracting Steam files is creating unencrypted `/data` backup in one way or another and manually fetching appropriate files from it on your PC, however because such thing highly depends on your phone manufacturer and **is not** in Android standard, we won't discuss it here. If you're lucky to have such functionality, you can make use of it, but majority of users don't have anything like that.

Unofficially, it is possible to extract the needed files without root access, by installing or downgrading your Steam app to version `2.1` (or earlier), setting up mobile authenticator and then creating a snapshot of the app (together with the `data` files that we need) through `adb backup`. However, since it's a serious security breach and entirely unsupported way to extract the files, we won't elaborate further on this, Valve disabled this security hole in newer versions for a reason, and we only mention it as a possibility. Still, it might be possible to do a clean install of that version, link new authenticator, extract the required files, and then upgrade the app, which should be just enough, but you're on your own with this method anyway.

Assuming that you've successfully rooted your phone, you should afterwards download any root explorer available on the market, such as **[this one](https://play.google.com/store/apps/details?id=com.jrummy.root.browserfree)** (or any other one of your preference). You can also access the protected files through ADB (Android Debug Bridge) or any other available to you method, we'll do it through the explorer since it's definitely the most user-friendly way.

Once you opened your root explorer, navigate to `/data/data` folder. Keep in mind that `/data/data` directory is protected and you won't be able to access it without root access. Once there, find `com.valvesoftware.android.steam.community` folder and copy it to your `/sdcard`, which points to your built-in internal storage. Afterwards, you should be able to plug your phone to your PC and copy the folder from your internal storage like usual. If by any chance the folder won't be visible despite you being sure that you copied it to the right place, try restarting your phone first.

Now, you can choose if you want to import your authenticator to WinAuth first, then to ASF, or to ASF right away. First option is more friendly and allows you to duplicate your authenticator also on your PC, allowing you to make confirmations and generate tokens from 3 different places - your phone, your PC and ASF. If you want to do that, simply open WinAuth, add new Steam authenticator and choose importing from Android option, then follow instructions by accessing the files that you've obtained above. When done, you can then import this authenticator from WinAuth to ASF, which is explained in dedicated WinAuth section below.

If you don't want to or don't need to go through WinAuth, then simply copy `files/Steamguard-<SteamID>` file from our protected directory, where `SteamID` is your 64-bit Steam identificator of the account that you want to add (if more than one, because if you have only one account then this will be the only file). You need to place that file in ASF's `config` directory. Once you do that, rename the file to `BotName.maFile`, where `BotName` is the name of your bot you're adding ASF 2FA to. After this step, launch ASF - it should notice the `.maFile` and import it.

```text
[*] INFO: ImportAuthenticator() <1> Converting .maFile into ASF format...
[*] INFO: ImportAuthenticator() <1> Successfully finished importing mobile authenticator!
```

That's all, assuming that you've imported the correct file with valid secrets, everything should work properly, which you can verify by using `2fa` commands. If you made a mistake, you can always remove `Bot.db` and start over if needed.

---

### iOS

For iOS you can use **[ios-steamguard-extractor](https://github.com/CaitSith2/ios-steamguard-extractor)**. This is possible thanks to the fact that you can make decrypted backup, put in on your PC and use the tool in order to extract Steam data that is otherwise impossible to get (at least without jailbreak, due to iOS encryption).

Head over to **[latest release](https://github.com/CaitSith2/ios-steamguard-extractor/releases/latest)** in order to download the program. Once you extract the data you can put it e.g. in WinAuth, then from WinAuth to ASF (although you can also simply copy generated json starting from `{` ending on `}` into `BotName.maFile` and proceed like usual). If you ask me, I strongly recommend to import to WinAuth first, then making sure that both generating tokens as well as accepting confirmations work properly, so you can be sure that everything is alright. If your credentials are invalid, ASF 2FA will not work properly, so it's much better to make ASF import step your last one.

For questions/issues, please visit **[issues](https://github.com/CaitSith2/ios-steamguard-extractor/issues)**.

*Keep in mind that above tool is unofficial, you're using it at your own risk. We do not offer technical support if it doesn't work properly - we got a few signals that it's exporting invalid 2FA credentials - verify that confirmations work in authenticator like WinAuth prior to importing that data to ASF!*

---

### SteamDesktopAuthenticator

If you have your authenticator running in SDA already, you should notice that there is `steamID.maFile` file available in `maFiles` folder. Make sure that `maFile` is in unencrypted form, as ASF can't decrypt SDA files - unencrypted file content should start with `{` and end with `}` character. If needed, you can remove the encryption from SDA settings first, and enable it again when you're done. Once the file is in unencrypted form, copy it to `config` directory of ASF.

You can now rename `steamID.maFile` to `BotName.maFile` in ASF config directory, where `BotName` is the name of your bot you're adding ASF 2FA to. Alternatively you can leave it as it is, ASF will then pick it automatically after logging in. Renaming the file helps ASF by making it possible to use ASF 2FA before logging in, if you don't do that, then the file can be picked only after ASF successfully logs in (as ASF doesn't know `steamID` of your account before in fact logging in).

If you did everything correctly, launch ASF, and you should notice:

```text
[*] INFO: ImportAuthenticator() <1> Converting .maFile into ASF format...
[*] INFO: ImportAuthenticator() <1> Successfully finished importing mobile authenticator!
```

From now on, your ASF 2FA should be operational for this account.

---

### WinAuth

Firstly create new empty `BotName.maFile` in ASF config directory, where `BotName` is the name of your bot you're adding ASF 2FA to. Remember that it should be `BotName.maFile` and NOT `BotName.maFile.txt`, Windows likes to hide known extensions by default. If you provide incorrect name, it won't be picked by ASF.

Now launch WinAuth as usual. Right click on Steam icon and select "Show SteamGuard and Recovery Code". Then check "Allow copy". You should notice familiar to you JSON structure on the bottom of the window, starting with `{`. Copy whole text into a `BotName.maFile` file created by you in previous step.

If you did everything correctly, launch ASF, and you should notice:

```text
[*] INFO: ImportAuthenticator() <1> Converting .maFile into ASF format...
[*] INFO: ImportAuthenticator() <1> Successfully finished importing mobile authenticator!
```

From now on, your ASF 2FA should be operational for this account.

---

## Selesai

From this moment, all `2fa` commands will work as they'd be called on your classic 2FA device. You can use both ASF 2FA and your authenticator of choice (Android, iOS, SDA or WinAuth) to generate tokens and accept confirmations.

If you have authenticator on your phone, you can optionally remove SteamDesktopAuthenticator and/or WinAuth, as we won't need it anymore. However, I suggest to keep it just in case, not to mention that it's more handy than normal steam authenticator. Just keep in mind that ASF 2FA is **NOT** a general purpose authenticator, it doesn't include all data that authenticator should have, but limited subset of original `maFile`. It's not possible to convert ASF 2FA back to original authenticator, therefore always make sure that you have general-purpose authenticator or `maFile` in other place, such as in WinAuth/SDA, or on your phone.

---

## FAQ

### How is ASF making use of 2FA module?

If ASF 2FA is available, ASF will use it for automatic confirmation of trades that are being sent/accepted by ASF. It will also be capable of automatically generating 2FA tokens on as-needed basis, for example in order to log in. In addition to that, having ASF 2FA also enables `2fa` commands for you to use. That should be all for now, if I didn't forget about anything - basically ASF uses 2FA module on as-needed basis.

---

### What if I need a 2FA token?

You will need 2FA token to access 2FA-protected account, that includes every account with ASF 2FA as well. You should generate tokens in authenticator that you used for import, but you can also generate temporary tokens through `2fa` command sent via the chat to given bot. You can also use `2fa <BotNames>` command to generate temporary token for given bot instances. This should be enough for you to access bot accounts through e.g. browser, but as noted above - you should use your friendly authenticator (Android, iOS, SDA or WinAuth) instead.

---

### Can I use my original authenticator after importing it as ASF 2FA?

Yes, your original authenticator remains functional and you can use it together with using ASF 2FA. That's the whole point of the process - we're importing your authenticator credentials into ASF, so ASF can make use of them and accept selected confirmations on your behalf.

---

### Where is ASF mobile authenticator saved?

ASF mobile authenticator is saved in `BotName.db` file in your config directory, along with some other crucial data related to given account. If you want to remove ASF 2FA, read how below.

---

### How to remove ASF 2FA?

Simply stop ASF and remove associated `BotName.db` of the bot with linked ASF 2FA you want to remove. This option will remove associated imported 2FA with ASF, but will NOT delink your authenticator. If you instead want to delink your authenticator, apart from removing it from ASF (firstly), you should delink it in authenticator of your choice (Android, iOS, SDA or WinAuth), or - if you can't for some reason, use revocation code that you received during linking that authenticator, on the Steam website. It's not possible to unlink your authenticator through ASF, this is what general-purpose authenticator that you already have should be used for.

---

### I linked authenticator in SDA/WinAuth, then imported to ASF. Can I now unlink it and link it again on my phone?

**No**. ASF **imports** your authenticator data in order to use it. If you delink your authenticator then you'll also cause ASF 2FA to stop functioning, regardless if you remove it firstly like stated in above question or not. If you want to use your authenticator on both your phone and ASF (plus optionally in SDA/WinAuth), then you'll need to **import** your authenticator from your phone, and not create new one in SDA/WinAuth. You can have only **one** linked authenticator, that's why ASF **imports** that authenticator and its data in order to use it as ASF 2FA - it's **the same** authenticator, just existing in two places. If you decide to delink your mobile authenticator credentials - regardless in which way, ASF 2FA will stop working, as previously copied mobile authenticator credentials will no longer be valid. In order to use ASF 2FA together with authenticator on your phone, you must import it from Android/iOS, which is described above.

---

### Is using ASF 2FA better than WinAuth/SDA/Other authenticator set to accept all confirmations?

**Yes**, in several ways. First and most important one - using ASF 2FA **significantly** increases your security, as ASF 2FA module ensures that ASF will only accept automatically its own confirmations, so even if attacker does request a trade that is harmful, ASF 2FA will **not** accept such trade, as it was not generated by ASF. In addition to security part, using ASF 2FA also brings performance/optimization benefits, as ASF 2FA fetches and accepts confirmations immediately after they're generated, and only then, as opposed to inefficient polling for confirmations each X minutes done e.g. by SDA or WinAuth. In short, there is no reason to use third-party authenticator over ASF 2FA, if you plan on automating confirmations generated by ASF - that's exactly what ASF 2FA is for, and using it does not conflict with you confirming everything else in authenticator of your choice. We strongly recommend to use ASF 2FA for entire ASF activity - this is much more secure than any other solution.

---

## Tingkat lanjut

If you're advanced user, you can also generate maFile manually. This can be used in case you'd want to import authenticator from other sources than the ones we've described above. It should have a **[valid JSON structure](https://jsonlint.com)** of:

```json
{
  "shared_secret": "STRING",
  "identity_secret": "STRING"
}
```

Standard authenticator data has more fields - they're entirely ignored by ASF during import, as they're not needed. You don't have to remove them - ASF only requires valid JSON with 2 mandatory fields described above, and will ignore additional fields (if any). Of course, you need to replace `STRING` placeholder in the example above with valid values for your account. Each `STRING` should be base64-encoded representation of bytes the appropriate private key is made of.