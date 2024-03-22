# Üçüncü Parti

Bu bölüm, özel (veya esas) olarak ASF ile birlikte kullanım için yazılmış çeşitli üçüncü taraf eklentilerini içerir. ASF eklentilerini, basit web uygulamalarını, entegrasyon için gerekli dahili kütüphaneleri ve diğer platformlar için tam özellikli botları kapsar. Listeye eklemek istediğiniz bir şey varsa, Discord veya Steam grubumuzdan bize ulaşın.

Lütfen aşağıdaki programların ASF geliştiricileri tarafından **sağlanmadığını** ve bu nedenle **hiçbiri hakkında garanti vermediğimizi** unutmayın, özellikle güvenlik, emniyet veya Steam Kullanım Şartları uyumluluğu açısından. Bu liste yalnızca referans amacıyla tutulur. Her zaman, kullanmak üzere olduğunuz üçüncü parti araçların sizin için yeterince güvenli ve yasal olduğundan emin olmalısınız, çünkü bunlardan herhangi birini kullanmak tamamen sizin sorumluluğunuz altındadır.

---

## ASF eklentileri

### **[Citrinate](https://github.com/Citrinate)**

- **[BoosterManager](https://github.com/Citrinate/BoosterManager)**, ASF için bir eklenti olarak, mücevherleri booster paketlere dönüştürmek için kullanıcı dostu bir arayüz sunmanın yanı sıra envanterleri yönetme ve piyasa listelerini yönetme konusunda çeşitli özellikler sağlar.
- **[CS2Interface](https://github.com/Citrinate/CS2Interface)**, ASF için bir eklenti olup Counter-Strike 2 ile **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)** kullanarak etkileşimde bulunmanıza olanak tanır.
- **[FreePackages](https://github.com/Citrinate/FreePackages)**, ASF için bir eklenti olarak Steam'deki ücretsiz paketleri bulur ve bunları hesabınıza ekler.

### **[Rudokhvist](https://github.com/Rudokhvist)**

- **[ASF Başarım Yöneticisi](https://github.com/Rudokhvist/ASF-Achievement-Manager)**, Steam başarımlarını yönetmenize izin veren ASF eklentisidir.
- **[BirthdayPlugin](https://github.com/Rudokhvist/BirthdayPlugin)**, doğum gününüzü kutlaması için bir ASF eklentisidir.
- **[BoosterCreator](https://github.com/Rudokhvist/BoosterCreator)**, güçlendirici paketler oluşturma işlevini sağlayan ASF eklentisidir.
- **[Case-Inresponsive-ASF](https://github.com/Rudokhvist/Case-Insensitive-ASF)**, bot adlarını büyük/küçük harfe duyarlı hale getiren ASF eklentisidir.
- **[Commandless-Redeem](https://github.com/Rudokhvist/Commandless-Redeem)**, ürün kodunu komut girmeden uygulamanızı sağlayan ASF eklentisidir.
- **[ItemDispenser](https://github.com/Rudokhvist/ItemDispenser)**, belirli tür(ler) için takas talebini otomatik olarak kabul etmesini sağlayan ASF eklentisidir.
- **[Selective-Loot-and-Transfer-Plugin](https://github.com/Rudokhvist/Selective-Loot-and-Transfer-Plugin)**, gelişmiş `transfer` komutları sağlaması için bir ASF eklentisidir.

### **[Vita](https://github.com/ezhevita)**

- **[FriendAccepter](https://github.com/ezhevita/FriendAccepter)**, Gelen tüm arkadaşlık isteklerini otomatik kabul eden ASF eklentisidir.
- **[GameRemover](https://github.com/ezhevita/GameRemover)**, ASF için seçilen bot örnekleri için Steam lisanslarını kaldırmak için bir komut uygulayan eklenti.
- **[GetEmail](https://github.com/ezhevita/GetEmail)**, verilen bot örneklerinin e-posta adresini doğrudan Steam'den almak için bir komut uygulayan ASF eklentisi.
- **[ResetAPIKey](https://github.com/ezhevita/ResetAPIKey)**, ASF için seçilen bot örnekleri için API anahtarını sıfırlamak için bir komut uygulayan eklenti.
- **[SteamKitProxyInjection](https://github.com/ezhevita/SteamKitProxyInjection)**, WebSocket bağlantılarının proxy ile sağlanmasına izin veren ASF eklentisidir.

### Diğer

- **[ASFEnhance](https://github.com/chr233/ASFEnhance)**, ASF için özellikle komutlar olmak üzere çeşitli yeni özelliklerle geliştiren eklenti.
- **[ASFFreeGames](https://github.com/maxisoft/ASFFreeGames)**, Reddit üzerinde paylaşılan ücretsiz Steam oyunlarını otomatik olarak toplayan ASF için bir eklentidir.

---

## Entegrasyonlar

- **[ASFBot](https://github.com/dmcallejo/ASFBot)**, ASF entegrasyonu için Python programlama dili ile yazılmış Telegram botudur.
- **[ASF STM userscript](https://greasyfork.org/en/scripts/404754-asf-stm)**, ASF tarafından sağlanan ` MatchActively` özelliğini kullanmadan **[ASF STM listing](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#publiclisting)** listesindeki botlara web tarayıcısı üzerinden otomatik takas teklifleri göndermek isteyenler için hazırlanmış userscript.
- **[telegram-asf](https://github.com/deluxghost/telegram-asf)**, ASF entegrasyonuna sahip, Python programlama dili ile yazılmış başka bir (asgari özelliğe sahip) Telegram botudur.

---

## Kütüphaneler

- **[ASF-IPC](https://github.com/deluxghost/ASF_IPC)**, ASF'nin IPC arayüzüyle daha fazla entegrasyonunu sağlayan, Python programlama diliyle yazılmış kütüphane.

---

## Paketleme

- **[AUR repo #1](https://aur.archlinux.org/packages/asf)**, Arch Linux üzerinde ASF'yi kolayca yüklemenizi sağlar.
- **[AUR repo #2](https://aur.archlinux.org/packages/archisteamfarm-bin)**, Arch Linux üzerinde ASF'yi kolayca yüklemenizi sağlar.
- **[Homebrew](https://formulae.brew.sh/formula/archi-steam-farm)**, ASF'yi macOS'a kolayca yüklemenizi sağlar.
- **[Nix](https://search.nixos.org/packages?channel=unstable&show=ArchiSteamFarm&from=0&size=50&sort=relevance&type=packages&query=ArchiSteamFarm)**, ASF'yi Nix içeren dağıtımlara kolayca yüklemenizi sağlar.
- **[NixOS](https://search.nixos.org/options?channel=unstable&from=0&size=50&sort=relevance&type=packages&query=ArchiSteamFarm)**, ASF'yi NixOS ile yapılandırmanıza ve yüklemenize olanak tanır.

---

## Araçlar

- **[Keys extractor](https://umaim.github.io/SKE)**, anahtarları çeşitli biçimlerde kopyalayıp yapıştırmanızı sağlayan ve `ürün kodunu aktifleştir` komutunu oluşturan ASF aracı. Daha fazla bilgi için **[GitHub repo](https://github.com/PixvIO/SKE)**'sunu ziyaret edin.
- **[ASF Mass Config Editor](https://github.com/genesix-eu/ASF_MCE)**, birden çok ASF yapılandırmasını daha kolay yönetmenizi sağlayan ASF aracı.

---

## Daha Fazlasını Öğrenmek İster misiniz?

ASF ile entegre olan tüm projeler için GitHub'da **[ArchiSteamFarm](https://github.com/topics/archisteamfarm)** konusunu ziyaret etmenizi öneriyoruz.