# Steam Aile Paylaşımı

ASF, 2.1.5.5+ sürümünden bu yana Steam Aile Paylaşımını destekler. Asf'nin bununla nasıl çalıştığını anlamak için öncelikle Steam Store'da bulunan **[Steam Aile Paylaşımı](https://store.steampowered.com/promotion/familysharing)**'nın nasıl çalıştığını okumalısınız.

---

## ASF

Asf'deki Steam Aile Paylaşımı özelliği için destek şeffaftır, yani yeni Bot / işlem yapılandırma özellikleri tanıtılmaz - hemen ek bir yerleşik işlevsellik olarak çalışır.

ASF, kütüphanenin aile paylaşımı kullanıcıları tarafından kilitlendiğinin farkında olmak için uygun mantığı içerir, bu nedenle bir oyun başlatması nedeniyle onları oyun oturumundan "atmaz". ASF, kilidi tutan birincil hesapla tamamen aynı şekilde hareket edecektir, bu nedenle bu kilit steam istemciniz veya aile paylaşımı kullanıcılarınızdan biri tarafından tutuluyorsa, ASF çiftçilik yapmaya çalışmaz, bunun yerine kilidin serbest bırakılmasını bekler.

Yukarıdaki ayarlara ek olarak, ASF oturum açtıktan sonra **[oyun paylaşım ayarları](https://store.steampowered.com/account/managedevices)**nda, kütüphanenizi kullanmasına izin verilen 5 `steamIDs`'ye kadar çıkarır. Bu kullanıcılara **[komutları](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)</a>** kullanmaları için `aile paylaşımı` izni verilir, özellikle de oyunları onlarla paylaşan bot hesabında `pause~` komutunu kullanmalarına izin verilir, bu da paylaşılabilecek bir oyunu başlatmak için otomatik kart çiftçilik modülünü duraklatmaya izin verir.

Yukarıda açıklanan her iki fonksiyonun bağlantısı, arkadaşlarınızın kart toplama işleminiz için `pause~` komutunu başlatmasına, bir oyun başlatmasına, istediğiniz kadar oynamasına izin verir, daha sonra oyunu bitirdikten sonra Kart toplama işlemi ASF tarafından otomatik olarak devam eder. Tabii ki, ASF şu anda aktif bir toplama işlemi yapmıyorsa, `pause~` göndermek gerekli değildir, çünkü arkadaşlarınız oyunu hemen başlatabilir ve yukarıda açıklanan mantık oturumdan atılmamanızı sağlar.

---

## Kısıtlamalar

Steam ağı, yanlış durum güncellemeleri yayınlayarak ASF'yi yanıltmayı sever, bu da ASF'nin sürece devam etmenin iyi olduğuna inanmasına ve sonuç olarak arkadaşınızı çok erken tekmelemesine neden olabilir. Bu, **[SSS girişinde](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#asf-is-kicking-my-steam-client-session-while-im-playing--this-account-is-logged-on-another-pc)** tarafımızdan daha önce açıklananla tamamen aynı konudur. Tamamen aynı çözümleri öneriyoruz, esas olarak arkadaşlarınızı `Operatör` iznine (veya üstüne) tanıtmak ve `pause` ve `resume` komutlarından yararlanmalarını söylemek.