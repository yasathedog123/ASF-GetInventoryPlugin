# İki adımlı kimlik doğrulama

Steam, hesapla ilgili çeşitli işlemleri gerçekleştirirken ek onay gerektiren "Escrow" adı verilen iki faktörlü kimlik doğrulama doğrulama sistemini destekler. **[Buradan](https://help.steampowered.com/faqs/view/2E6E-A02C-5581-8904)** ve **[buradan](https://help.steampowered.com/faqs/view/34A1-EA3F-83ED-54AB)** daha fazlasını okuyabilirsiniz. Bu sayfa esas olarak iki adımlı doğrulama sisteminin kendisini ve bu sistem için entegrasyon çözümümüzü, yani ASF iki adımlı doğrulamayı (ASF 2AD) tanıtmaktadır.

---

# ASF Mantığı

ASF iki adımlı doğrulamayı kullanıp kullanmadığınızdan bağımsız olarak, ASF doğru mantığı içerir ve standart iki adımlı doğrulayıcılarla korunan hesapların nasıl ele alınacağını tam olarak anlar. Gerektiğinde sizden gerekli ayrıntıları isteyecektir (örneğin, giriş yaparken). Bununla birlikte, bu istekler, otomatik olarak gerekli belirteçleri oluşturacak, sizi zahmetten kurtaracak ve ekstra işlevsellik sağlayacak (aşağıda açıklanmıştır) ASF 2AD kullanılarak otomatikleştirilebilir.

---

# ASF 2AD

ASF 2AD, ASF sürecine 2AD işlevleri sağlamaktan sorumlu yerleşik bir modüldür, örneğin onayların oluşturulması ve onayların kabulü. Mevcut kimlik doğrulayıcı bilgilerinizi çoğaltarak çalışır, böylece mevcut kimlik doğrulayıcınızı ve ASF 2AD'yi aynı anda kullanabilirsiniz.

Bot hesabınızın ASF 2AD'yi zaten kullandığını `2ad` **[komutlarını](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** yürüterek doğrulayabilirsiniz. Doğrulayıcıyı ASF 2AD olarak içe aktarmadığınız sürece, tüm standart ` 2fa ` komutları geçersizdir; bu, hesabınızda ASF 2AD'nin etkin olmadığı anlamına gelir, bu nedenle bu modülü gerektiren bazı gelişmiş ASF özellikleri çalışmayacaktır.

---

# Öneriler

ASF 2AD'yi çalışır hale getirmenin birçok yolu vardır, burada mevcut durumunuza göre önerilerimizi ekliyoruz:

- SteamDesktopAuthenticator, WinAuth veya 2AD bilgilerinizi kolaylıkla almanızı sağlayan başka bir üçüncü parti uygulama kullanıyorsanız, bunları ASF'nin **[içine aktarmanız](#import)** yeterlidir.
- Resmi uygulamayı kullanıyorsanız ve 2AD kimlik bilgilerinizi sıfırlamaktan çekinmiyorsanız, en iyi yol 2AD'yi devre dışı bırakmak ve ardından **[ortak kimlik doğrulayıcı](#joint-authenticator)** kullanarak 2AD'yi yeniden **[oluşturmaktır.](#creation)** Böylece hem resmi uygulamayı ASF'nin 2AD özelliğini aynı anda kullanabilirsiniz. Bu yöntem herhangi bir root veya ileri düzey bir bilgi gerektirmez, sadece talimatları takip etmeniz yeterlidir.
- Resmi uygulamayı kullanıyorsanız ve 2FA kimlik bilgilerinizi yeniden oluşturmak istemiyorsanız, seçenekleriniz çok sınırlıdır, genellikle bu ayrıntıları **[ içe aktarmak ](#import) ** için root ve fazladan uğraşmanız gerekir ve bununla bile imkansız olabilir.
- Henüz 2FA kullanmıyorsanız ve umursamıyorsanız, ASF 2fa'yı **[standalone authenticator](#standalone-authenticator)**, asf'ye **[duplicating](#import)** üçüncü taraf uygulama (öneri # 1) veya resmi uygulama ile **[joint authenticator](#joint-authenticator)** (öneri # 2) ile kullanabilirsiniz.

Aşağıda tüm olası seçenekleri ve bilinen yöntemleri tartışacağız.

---

## Oluşturma

Genel olarak, ASF 2fa'nın asıl amacı bunun için tasarlandığından, mevcut kimlik doğrulayıcınızı **[çoğaltmanızı](#import)** şiddetle öneririz. Ancak ASF, ASF 2fa'yı daha da genişleten ve tamamen yeni bir kimlik doğrulayıcıyı da bağlamanıza olanak tanıyan resmi bir `Mobil Kimlik Doğrulayıcı` **[eklentisiyle](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)** birlikte gelir. This can be useful in case you're unable or unwilling to use other tools and do not mind ASF 2FA becoming your main (and maybe only) authenticator.

There are two possible scenarios for adding a two-factor authenticator with the `MobileAuthenticator` **[plugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins)**: standalone or joint with the official Steam mobile app. In the second scenario, you will end up with the same authenticator on both the ASF and mobile app; both will generate the same codes, and both will be able to confirm trade offers, Steam Community Market transactions, etc.

### Common steps for both scenarios

No matter if you plan to use ASF as the standalone authenticator or want the same authenticator on the official Steam mobile app, you need to do those initialization steps:

1. Create an ASF bot for the target account, start it, and log in, which you probably already did.
2. Optionally, assign a working and operational phone number to the account **[here](https://store.steampowered.com/phone/manage)** to be used by the bot. This will allow you to receive SMS code and allow recovery if needed, but it's not mandatory.
3. Ensure you're not using 2FA yet for your account, if you do, disable it first.
4. Execute the `2fainit [Bot]` command, replacing `[Bot]` with your bot's name.

Assuming you got a successful reply, the following two things have happened:

- A new `<Bot>.maFile.PENDING` file was generated by ASF in your `config` directory.
- SMS was sent from Steam to the phone number you have assigned for the account above. If you didn't set a phone number, then an email was sent instead to the account e-mail address.

The authenticator details are not operational yet, however, you can review the generated file if you'd like to. If you want to be double safe, you can, for example, already write down the revocation code. The next steps will depend on your selected scenario.

### Standalone authenticator

If you want to use ASF as your main (or even only) authenticator, now you need to do the finalization step:

5. Execute the `2fafinalize [Bot] <ActivationCode>` command, replacing `[Bot]` with your bot's name and `<ActivationCode>` with the code you've received through SMS or e-mail in the previous step.

### Joint authenticator

If you want to have the same authenticator in both ASF and the official Steam mobile app, now you need to do the next steps:

5. Ignore the SMS or e-mail code that you've received after the previous step.
6. Install the Steam mobile app if it's not installed yet, and open it. Navigate to the Steam Guard tab and add a new authenticator by following the app's instructions.
7. After your authenticator in the mobile app is added and working, return to ASF. You now need to tell ASF that finalization is done with the help of one of the two commands below:
 - Wait until the next 2fa code is shown in the Steam mobile app, and use the command `2fafinalized [Bot] <2fa_code_from_app>` replacing `[Bot]` with your bot's name and `<2fa_code_from_app>` with the code you currently see in the Steam mobile app. If the code generated by ASF and the code you provided are the same, ASF assumes that an authenticator was added correctly and proceeds with importing your newly created authenticator.
 - We strongly recommend to do the above in order to ensure that your credentials are valid. However, if you don't want to (or can't) check if codes are the same and you know what you're doing, you can instead use the command `2fafinalizedforce [Bot]`, replacing `[Bot]` with your bot's name. ASF will assume that the authenticator was added correctly and proceed with importing your newly created authenticator.

### After finalization

Assuming everything worked properly, the previously generated `<Bot>.maFile.PENDING` file was renamed to `<Bot>.maFile.NEW`. This indicates that your 2FA credentials are now valid and active. We recommend that you create a copy of that file and keep it in **a secure and safe location**. In addition to that, we recommend you open the file in your editor of choice and write down the `revocation_code`, which will allow you to, as the name implies, revoke the authenticator in case you lose it.

In regard to technical details, the generated `maFile` includes all details that we have received from the Steam server during linking the authenticator, and in addition to that, the `device_id` field, which may be needed for other authenticators. The file is fully compatible with **[SDA](#steamdesktopauthenticator)** for import.

ASF automatically imports your authenticator once the procedure is done, and therefore `2fa` and other related commands should now be operational for the bot account you linked the authenticator to.

---

## İçe Aktarma

Import process requires already linked and operational authenticator that is supported by ASF. ASF currently supports a few different official and unofficial sources of 2FA - Android, iOS, SteamDesktopAuthenticator and WinAuth, on top of manual method which allows you to provide required credentials yourself. If you don't have any authenticator yet, you need to choose one of available apps and set it up firstly. Hangisini seçeceğinizi iyi bilmiyorsanız, WinAuth'u öneririz, ancak talimatları uyguladığınızı varsayarsak yukarıdakilerden herhangi biri işinizi görecektir.

Aşağıdaki tüm rehberin, belirli bir araç/uygulama ile birlikte düzgün çalışan bir kimlik doğrulayıcısına ihtiyacı vardır. Geçersiz verileri içe aktarırsanız ASF 2AD düzgün çalışmaz, bu nedenle içe aktarmayı denemeden önce kimlik doğrulayıcınızın düzgün çalıştığından emin olun. Bu, aşağıdaki kimlik doğrulayıcı işlevlerinin düzgün çalışıp çalışmadığını test etmeyi ve doğrulamayı içerir:
- You can generate tokens and those tokens are accepted by Steam network
- You can fetch confirmations, and they are arriving on your mobile authenticator
- You can accept those confirmations, and they're properly recognized by Steam network as confirmed/rejected

Yukarıdaki eylemlerin işe yarayıp yaramadığını kontrol ederek kimlik doğrulayıcınızın çalıştığından emin olun - çalışmazlarsa, ASF'de de çalışmazlar, yalnızca zaman kaybedersiniz ve kendinize ek sorunlara neden olursunuz.

---

### Android telefon

**The below instructions apply to Steam app in version `2.X`, there are currently limited **[resources](https://github.com/JustArchiNET/ArchiSteamFarm/discussions/2786)** on extracting required details from version `3.0` onwards. We'll update this section once generally-available method is found. As of today, a workaround would be to intentionally install older version of Steam app, register 2FA and extract the required details first, after which it's possible to update the application to latest version - existing authenticator will continue to work.**

Genel olarak, Android telefonunuzdan kimlik doğrulayıcıyı içe aktarmak için **[root](https://en.wikipedia.org/wiki/Rooting_(Android_OS))** erişimine ihtiyacınız olacaktır. Root işlemi cihazdan cihaza değişir, bu yüzden size cihazınızı nasıl rootlayacağınızı söylemeyeceğim. Ancak root işleminin nasıl yapılacağına dair mükemmel bir rehber sayfası olan **[XDA](https://www.xda-developers.com/root)**'yı zirayet etmenizi önereceğim. Cihazınızı veya ihtiyacınız olan rehberi buradan bulamıyorsanız, o zaman google amcadan bulmaya çalışın.

En azından resmi olarak, korumalı Steam dosyalarına root olmadan erişmek mümkün değildir. Steam dosyalarını ayıklamak için tek resmi olmayan yöntem root yöntemidir. Şu veya bu şekilde şifrelenmemiş veri(`/data`) yedeklemesi oluşturmak ve uygun dosyaları buradan PC'nize manuel olarak getirmektir, ancak böyle bir şey büyük ölçüde telefon üreticinize bağlı olduğundan ve Android standardında **olmadığı** için, burada tartışmayacağız. Böyle bir işlevselliğe zaten sahip olduğunuz için şanslıysanız, bundan yararlanabilirsiniz, ancak kullanıcıların çoğunda bu işlevsellik yoktur.

Unofficially, it is possible to extract the needed files without root access, by installing or downgrading your Steam app to version `2.1` (or earlier), setting up mobile authenticator and then creating a snapshot of the app (together with the `data` files that we need) through `adb backup`. Ancak, ciddi bir güvenlik ihlali ve dosyaları çıkarmanın tamamen desteklenmeyen bir yolu olduğu için, bunun üzerinde daha fazla durmayacağız, Valve bu güvenlik açığını yeni sürümlerde bir nedenden dolayı devre dışı bıraktı ve bundan sadece bir olasılık olarak bahsediyoruz. Still, it might be possible to do a clean install of that version, link new authenticator, extract the required files, and then upgrade the app, which should be just enough, but you're on your own with this method anyway.

Telefonunuzu başarılı bir şekilde rootladığınızı varsayarsak, daha sonra **[bunun gibi](https://play.google.com/store/apps/details?id=com.jrummy.root.browserfree)** piyasada bulunan herhangi bir root gezginini (veya tercih ettiğiniz herhangi bir başkasını) indirmelisiniz. Ayrıca, korunan dosyalara ADB (Android Hata Ayıklama Köprüsü) veya kullanabileceğiniz diğer herhangi bir yöntemle erişebilirsiniz, kesinlikle en kullanıcı dostu yol olduğu için bunu gezgin aracılığıyla yapacağız.

Root gezgininizi açtıktan sonra `/data/data` klasörüne gidin. `/data/data` dizininin korunduğunu ve root erişimi olmadan ona erişemeyeceğinizi unutmayın. `com.valvesoftware.android.steam.community` klasörünü bulun ve yerleşik dahili depolama alanınızı gösteren `/sdcard`'ınıza kopyalayın. Daha sonra, telefonunuzu PC'nize bağlayabilmeli ve klasörü her zamanki gibi dahili depolama alanınızdan kopyalayabilmelisiniz. Doğru yere kopyaladığınızdan emin olmanıza rağmen klasör görünmüyorsa, önce telefonunuzu yeniden başlatmayı deneyin.

Şimdi, kimlik doğrulayıcınızı önce WinAuth'a, ardından ASF'ye veya hemen ASF'ye aktarmak isteyip istemediğinizi seçebilirsiniz. İlk seçenek daha kolay ve kimlik doğrulayıcınızı PC'nizde de çoğaltmanıza izin vererek, 3 farklı yerden - telefonunuz, PC'niz ve ASF - onaylar yapmanıza ve belirteçler oluşturmanıza olanak tanır. Bunu yapmak istiyorsanız, sadece WinAuth'u açın, yeni Steam kimlik doğrulayıcı ekleyin ve Android'den içe aktar seçeneğini seçin, ardından yukarıda edindiğiniz dosyalara erişerek talimatları izleyin. Bittiğinde, bu kimlik doğrulayıcıyı WinAuth'tan ASF'ye aktarabilirsiniz; bu, aşağıdaki özel WinAuth bölümünde açıklanmıştır.

If you don't want to or don't need to go through WinAuth, then simply copy `files/Steamguard-<SteamID>` file from our protected directory, where `SteamID` is your 64-bit Steam identificator of the account that you want to add (if more than one, because if you have only one account then this will be the only file). Bu dosyayı ASF'nin yapılandırma(`config`) dizinine yerleştirmeniz gerekiyor. Bunu yaptıktan sonra dosyayı `BotName.maFile` olarak yeniden adlandırın. Burada ki `BotName`, ASF 2AD'yı eklediğiniz botunuzun adıdır. Bu adımdan sonra, ASF'yi başlatın ve ASF `.maFile` dosyasını fark etmeli ve içe aktarmalıdır.

```text
[*] BİLGİ: İçeAktarılanKimlikDoğrulayıcı() <1> .maFile ASF formatına dönüştürülüyor...
[*] BİLGİ: İçeAktarılanKimlikDoğrulayıcı() <1> Mobil kimlik doğrulayıcıyı içe aktarma başarıyla tamamlandı!
```

Hepsi bu kadar, geçerli sırlarla doğru dosyayı içe aktardığınızı varsayarsak, `2ad` komutlarını kullanarak doğrulayabileceğiniz her şey düzgün çalışmalıdır. Bir hata yaptıysanız, her zaman `Bot.db` 'yi kaldırabilir ve gerekirse baştan başlayabilirsiniz.

---

### iOS

iOS için **[ios-steamguard-extractor](https://github.com/CaitSith2/ios-steamguard-extractor)** kullanabilirsiniz. Bu, şifresi çözülmüş yedekleme yapabilmeniz, PC'nize koyabilmeniz ve aksi takdirde elde edilmesi imkansız olan Steam verilerini (en azından iOS şifrelemesi nedeniyle jailbreak olmadan) çıkarmak için aracı kullanabilmeniz sayesinde mümkündür.

Programı indirmek için **[en son sürüme](https://github.com/CaitSith2/ios-steamguard-extractor/releases/latest)** gidin. Verileri çıkardıktan sonra, ör. WinAuth'da, ardından WinAuth'tan ASF'ye (yine de, `{` ile biten `}` ile başlayıp oluşturulan json'u `BotName.maFile` içine kopyalayabilir ve her zamanki gibi ilerleyebilirsiniz). Bana sorarsanız, önce WinAuth'a aktarmanızı, ardından hem token oluşturmanın hem de onayları kabul etmenin düzgün çalıştığından emin olmanızı şiddetle tavsiye ederim, böylece her şeyin yolunda olduğundan emin olabilirsiniz. Kimlik bilgileriniz geçersizse, ASF 2AD düzgün çalışmayacaktır, bu nedenle ASF içe aktarma adımını son adımınız yapmak çok daha iyidir.

Sorularınız/sorunlarınız için lütfen **[sorunları](https://github.com/CaitSith2/ios-steamguard-extractor/issues)** ziyaret edin.

*Yukarıdaki aracın gayri resmi olduğunu, riski size ait olmak üzere kullandığınızı unutmayın. Düzgün çalışmıyorsa teknik destek sağlamıyoruz. geçersiz 2FA kimlik bilgilerini dışa aktardığına dair birkaç sinyal aldık. bu verileri ASF'ye aktarmadan önce onayların WinAuth gibi bir kimlik doğrulayıcıda çalıştığını doğrulayın!*

---

### SteamDesktopAuthenticator

Kimlik doğrulayıcınız zaten SDA'da çalışıyorsa, `maFiles` klasörü içersinde `steamID.maFile` dosyası olduğunu göreceksiniz. Make sure that `maFile` is in unencrypted form, as ASF can't decrypt SDA files - unencrypted file content should start with `{` and end with `}` character. If needed, you can remove the encryption from SDA settings first, and enable it again when you're done. Once the file is in unencrypted form, copy it to `config` directory of ASF.

You can now rename `steamID.maFile` to `BotName.maFile` in ASF config directory, where `BotName` is the name of your bot you're adding ASF 2FA to. Alternatif bir adım olarak, olduğu gibi bırakabilirsiniz, ASF, oturum açtıktan sonra otomatik olarak seçecektir. Renaming the file helps ASF by making it possible to use ASF 2FA before logging in, if you don't do that, then the file can be picked only after ASF successfully logs in (as ASF doesn't know `steamID` of your account before in fact logging in).

Her şeyi doğru yaptıysanız, ASF'yi başlatın ve şunu fark etmelisiniz:

```text
[*] BİLGİ: İçeAktarılanKimlikDoğrulayıcı() <1> .maFile ASF formatına dönüştürülüyor...
[*] BİLGİ: İçeAktarılanKimlikDoğrulayıcı() <1> Mobil kimlik doğrulayıcıyı içe aktarma başarıyla tamamlandı!
```

Şu andan itibaren, ASF 2AD'nız bu hesap için çalışır durumda olmalıdır.

---

### WinAuth

Öncelikle ASF config dizininde yeni boş `BotName.maFile` oluşturun; burada ki `BotName`, ASF 2AD'yı eklediğiniz botunuzun adı olmalıdır. Bunun `BotName.maFile` olması gerektiğini ve bu yüzden `BotName.maFile.txt` OLMAMASI gerektiğini unutmayın, Windows varsayılan olarak bilinen uzantıları gizlemeyi sever. Yanlış ad verirseniz, ASF tarafından seçilmeyecektir.

Şimdi WinAuth'u her zamanki gibi başlatın. Steam simgesine sağ tıklayın ve "SteamGuard ve Kurtarma Kodunu Göster"i seçin. Ardından "Kopyalamaya izin ver" seçeneğini işaretleyin. Pencerenin alt kısmında `{` ile başlayan JSON yapısının size tanıdık geldiğini fark etmelisiniz. Burada ki tüm metni, önceki adımda oluşturduğunuz `BotName.maFile` dosyasına kopyalayın.

Her şeyi doğru yaptıysanız, ASF'yi başlatın ve şunu fark etmelisiniz:

```text
[*] BİLGİ: İçeAktarılanKimlikDoğrulayıcı() <1> .maFile ASF formatına dönüştürülüyor...
[*] BİLGİ: İçeAktarılanKimlikDoğrulayıcı() <1> Mobil kimlik doğrulayıcıyı içe aktarma başarıyla tamamlandı!
```

Şu andan itibaren, ASF 2AD'nız bu hesap için çalışır durumda olmalıdır.

---

## Bitti

Bu andan itibaren, tüm `2ad` komutları, klasik 2AD cihazınızda çağrıldıkları gibi çalışacaktır. Belirteç oluşturmak ve onayları kabul etmek için hem ASF 2AD'yı hem de seçtiğiniz kimlik doğrulayıcınızı (Android, iOS, SDA veya WinAuth) kullanabilirsiniz.

Telefonunuzda kimlik doğrulayıcı varsa, isteğe bağlı olarak SteamDesktopAuthenticator ve/veya WinAuth'u kaldırabilirsiniz, çünkü artık ihtiyacımız olmayacak. Ancak, her ihtimale karşı saklamanızı öneririm, normal Steam doğrulayıcıdan daha kullanışlı olduğundan bahsetmiyorum bile. Just keep in mind that ASF 2FA is **NOT** a general purpose authenticator, it doesn't include all data that authenticator should have, but limited subset of original `maFile`. It's not possible to convert ASF 2FA back to original authenticator, therefore always make sure that you have general-purpose authenticator or `maFile` in other place, such as in WinAuth/SDA, or on your phone.

---

## SSS

### ASF 2AD modülünü nasıl kullanıyor?

ASF 2AD mevcutsa, ASF tarafından gönderilen/kabul edilmesi gereken işlemlerin otomatik olarak onaylanması için ASF bunu kullanacaktır. Ayrıca, örneğin oturum açmak için gerektiğinde otomatik olarak 2AD belirteçleri oluşturabilecektir. Buna ek olarak, ASF 2AD'ya sahip olmak, 2ad komutlarını kullanmanıza olanak tanır. Şimdilik bu kadar, eğer hiçbir şeyi unutmadıysam. Temelde ASF, gerektiğinde 2AD modülünü kullanır.

---

### What if I need a 2FA token?

You will need 2FA token to access 2FA-protected account, that includes every account with ASF 2FA as well. You should generate tokens in authenticator that you used for import, but you can also generate temporary tokens through `2fa` command sent via the chat to given bot. You can also use `2fa <BotNames>` command to generate temporary token for given bot instances. This should be enough for you to access bot accounts through e.g. browser, but as noted above - you should use your friendly authenticator (Android, iOS, SDA or WinAuth) instead.

---

### Orijinal kimlik doğrulayıcımı ASF 2AD olarak içe aktardıktan sonra kullanabilir miyim?

Evet, orijinal kimlik doğrulayıcınız çalışır durumda kalır ve onu ASF 2AD ile birlikte kullanabilirsiniz. Sürecin bütün amacı budur. ASF'nin bunları kullanabilmesi ve sizin adınıza seçilen onayları kabul edebilmesi için kimlik doğrulayıcı kimlik bilgilerinizi ASF'ye aktarıyoruz.

---

### ASF mobil kimlik doğrulayıcı nereye kaydedilir?

ASF mobil kimlik doğrulayıcı, verilen hesapla ilgili diğer bazı önemli verilerle birlikte yapılandırma(config) dizininizdeki `BotName.db` dosyasına kaydeder. ASF 2AD'yı kaldırmak istiyorsanız, aşağıda nasıl yapılacağını okuyun.

---

### ASF 2AD nasıl kaldırılır?

ASF'yi durdurun ve kaldırmak istediğiniz ASF 2AD ile bağlantılı botun `BotName.db` dosyasını kaldırın. Bu seçenek, ASF ile ilişkili içe aktarılan 2FA'yı kaldıracak, ancak kimlik doğrulayıcınızın bağlantısını ÇIKARMAYACAKTIR. Bunun yerine, ASF'den (ilk olarak) kaldırmak dışında, kimlik doğrulayıcınızın bağlantısını kaldırmak istiyorsanız, seçtiğiniz kimlik doğrulayıcıda (Android, iOS, SDA veya WinAuth) bağlantısını kaldırmanız gerekir veya herhangi bir nedenle bunu yapamıyorsanız, şunu deneyin: Steam web sitesinde bu doğrulayıcıyı bağlarken aldığınız iptal kodu. ASF aracılığıyla kimlik doğrulayıcınızın bağlantısını kaldırmak mümkün değildir, zaten sahip olduğunuz genel amaçlı kimlik doğrulayıcı bunun için kullanılmalıdır.

---

### I linked authenticator in SDA/WinAuth, then imported to ASF. Can I now unlink it and link it again on my phone?

**Hayır**. ASF **imports** your authenticator data in order to use it. If you delink your authenticator then you'll also cause ASF 2FA to stop functioning, regardless if you remove it firstly like stated in above question or not. If you want to use your authenticator on both your phone and ASF (plus optionally in SDA/WinAuth), then you'll need to **import** your authenticator from your phone, and not create new one in SDA/WinAuth. You can have only **one** linked authenticator, that's why ASF **imports** that authenticator and its data in order to use it as ASF 2FA - it's **the same** authenticator, just existing in two places. If you decide to delink your mobile authenticator credentials - regardless in which way, ASF 2FA will stop working, as previously copied mobile authenticator credentials will no longer be valid. In order to use ASF 2FA together with authenticator on your phone, you must import it from Android/iOS, which is described above.

---

### Is using ASF 2FA better than WinAuth/SDA/Other authenticator set to accept all confirmations?

**Yes**, in several ways. First and most important one - using ASF 2FA **significantly** increases your security, as ASF 2FA module ensures that ASF will only accept automatically its own confirmations, so even if attacker does request a trade that is harmful, ASF 2FA will **not** accept such trade, as it was not generated by ASF. In addition to security part, using ASF 2FA also brings performance/optimization benefits, as ASF 2FA fetches and accepts confirmations immediately after they're generated, and only then, as opposed to inefficient polling for confirmations each X minutes done e.g. by SDA or WinAuth. In short, there is no reason to use third-party authenticator over ASF 2FA, if you plan on automating confirmations generated by ASF - that's exactly what ASF 2FA is for, and using it does not conflict with you confirming everything else in authenticator of your choice. We strongly recommend to use ASF 2FA for entire ASF activity - this is much more secure than any other solution.

---

## Gelişmiş

If you're advanced user, you can also generate maFile manually. This can be used in case you'd want to import authenticator from other sources than the ones we've described above. It should have a **[valid JSON structure](https://jsonlint.com)** of:

```json
{
  "shared_secret": "STRING",
  "identity_secret": "STRING"
}
```

Standard authenticator data has more fields - they're entirely ignored by ASF during import, as they're not needed. You don't have to remove them - ASF only requires valid JSON with 2 mandatory fields described above, and will ignore additional fields (if any). Of course, you need to replace `STRING` placeholder in the example above with valid values for your account. Each `STRING` should be base64-encoded representation of bytes the appropriate private key is made of.
