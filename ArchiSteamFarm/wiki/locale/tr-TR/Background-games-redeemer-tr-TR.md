# Arka plan oyunları etkinleştirici

Arka plan oyunları etkinleştiricisi, arka planda kullanılmak üzere verilen Steam cd-anahtarlarının (isimleri ile birlikte) içe aktarılabilmesini sağlayan özel bir ASF özelliğidir. Bu özellikle, çok sayıda anahtarınız varsa ve tüm toplu işleminiz tamamlanmadan önce `RateLimited` **[durumunu](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#what-is-the-meaning-of-status-when-redeeming-a-key)** ulaşmayı garantilediyseniz kullanışlıdır.

Arkaplan oyunları kurtarıcısı, tek bir bot alanına sahip olacak şekilde yapılır, bu da `RedeemingPreferences`'dan yararlanmadığı anlamına gelir. Bu özellik, gerekirse, `redeem` **[komutu](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** ile birlikte (veya bunun yerine) kullanılabilir.

---

## İçe Aktarma

İçe aktarma işlemi iki yolla yapılabilir - bir dosya kullanarak veya IPC kullanarak.

### Dosya

ASF, kendi `yapılandırma` dizininde `BotName.keys` adlı bir dosyayı, `BotName` botunuzun adı olduğunu görecektir. Bu dosya, birbirinden bir sekme (tab) karakteriyle ayrılmış şekilde oyun adı ve cd anahtarlarını girmenizi, farklı oyun anahtarlarını ise yeni satırlara girmenizi bekler. Birden çok sekme (tab) kullanılıyorsa, o halde ilk girdi oyunun adı, son girdi ise bir cd anahtarı olarak kabul edilir ve aradaki her şey göz ardı edilir. Örneğin:

```text
POSTAL 2    ABCDE-EFGHJ-IJKLM
Domino Craft VR 12345-67890-ZXCVB
A Week of Circus Terror POIUY-KJHGD-QWERT
Terraria    ThisIsIgnored   ThisIsIgnoredToo    ZXCVB-ASDFG-QWERT
```

Alternatif olarak, yalnızca cd anahtarı da girebilirsiniz (yine her girdi arasında yeni bir satırla). Bu durumda ASF, doğru ismi doldurmak için Steam'in yanıtını (mümkünse) kullanacaktır. Steam'de kullanılan paketlerin etkinleştirdikleri oyunların mantığını takip etmesi gerekmediğinden, her türlü anahtar girerken kendi belirlediğiniz bir isim girmeniz önerilir, çünkü geliştiricinin ne koyduğuna bağlı olarak, doğru oyun veya paket isimlerini de görebilirsiniz (örn. Humble Indie Bundle 18) veya tamamen yanlış ve potansiyel olarak kötü niyetli isimler de görebilirsiniz (örn. Half-Life 4).

```text
ABCDE-EFGHJ-IJKLM
12345-67890-ZXCVB
POIUY-KJHGD-QWERT
ZXCVB-ASDFG-QWERT
```

Hangi biçime bağlı kalmaya karar vermiş olursanız olun, ASF, bot başlangıcında veya daha sonra yürütme sırasında `keys` dosyanızı içe aktarır. Dosyanızın başarılı bir şekilde okunmasından ve geçersiz girişlerin atlanmasından sonra, düzgün bir şekilde algılanan tüm oyunlar arka plan sırasına eklenecek ve `BotunuzunAdı.keys` dosyasının kendisi `yapılandırma` dizininden kaldırılacaktır.

### IPC

ASF, yukarıda bahsi geçen anahtar dosyasına ek olarak, herhangi bir IPC aracı tarafından yürütülebilir, `GamesToRedeemInBackground` **[ASF API uç noktasını](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-api)**, ASF-ui'da da dahil olmak üzere dışarı sunar. Tab karakterine bağlı kalmak yerine kendi istediğinizi ayırma karakterini kullanma, veya hatta kendi özel anahtar yapısını ASF'ye sunmak gibi, gerekli ayrıştırma işlemini kendiniz yapacağınız için IPC kullanmak daha etkili olabilir.

---

## Kuyruk

Oyunlar başarıyla içe aktarıldığında, sıraya eklenirler. Bot, Steam ağına bağlı olduğu sürece ve kuyruk boş değilse ASF otomatik olarak arka plan kuyruğundan geçer. Etkinleştirilmeye çalışılan ve `RateLimited`'den başka bir yanıt alınan tüm anahtarlar sıradan çıkarılır ve durumu, eğer anahtar kullanıldıysa (örn. `NoDetail`, `BadActivationCode`, `DuplicateActivationCode` yanıtları alındıysa) `Botunuzunİsmi.keys.used` dosyasına veya kullanılmadıysa `Botunuzunİsmi.keys.unused` dosyasına yazılır. ASF bilerek sizin sunduğunuz ismi kullanır, çünkü Steam ağından gelecek isim doğru veya mantıklı olmayabilir - böylelikle gerektiğinde/istediğinizde anahtarlarınızı özel isimlerle hatırlayabilirsiniz.

Eğer bu süreçte hesabımız `RateLimited` durumuna gelirse, bekleme süresinin geçmesi için sıra bir saatliğine geçici olarak durdurulur. Sonrasında, süreç kaldığı yerden devam eder, tüm sıra boş olana kadar veya başka bir `RateLimited` durumu meydana gelene kadar.

---

## Örnek

100 anahtarlık bir listeniz olduğunu varsayalım. Öncelikle ASF `config` dizininde yeni bir `BotunuzunAdı.keys.new` dosyası oluşturmalısınız. ASF'ye bu dosyayı oluşturulduğu anda almaması gerektiğini bildirmek için `.new` uzantısını ekledik (çünkü yeni boş dosya olduğundan, içe aktarmaya henüz hazır değil).

Artık yeni dosyamızı açabilir ve 100 anahtarımızı bu listeye kopyala yapıştır yapabilir, gerekirse formatı düzeltebilirsiniz. Düzeltmelerden sonra `BotunuzunAdı.keys.new` dosyamız tam olarak 100 (veya son satır sonu ile birlikte 101) satıra sahip olacak ve her satır `OyunAdı\tcd-key\n` yapısına sahip olacak. Burada `\t` sekme (tab) karakteri ve `\n` yeni satırdır.

ASF'nin dosyanın alınmaya hazır olduğunu bilmesini sağlamak için artık bu dosyayı `BotunuzunAdı.keys.new` dosyasının adını `BotunuzunAdı.keys` olarak değiştirmeye hazırsınız. Bunu yaptığınız anda ASF (yeniden başlatmaya gerek kalmadan) dosyayı otomatik olarak içe aktarır, tüm oyunlarımızın ayrıştırıldığını ve sıraya eklendiğini onayladıktan sonra sonra siler.

`BotunuzunAdı.keys` dosyasını kullanmak yerine, IPC API uç noktasını da kullanabilir, hatta isterseniz ikisini birleştirebilirsiniz.

Bir süre sonra, `BotunuzunAdı.keys.used` ve `BotunuzunAdı.keys.unused` dosyaları oluşturulur. Bu dosyalar aktivasyon sürecinin sonuçlarını içerir. Örneğin, `BotunuzunAdı.keys.unused` dosyasındaki anahtarlar kullanılmamış olduğu için, ismini `DiğerBotunuzunAdı.keys` olarak değiştirerek kullanılmayan anahtarları diğer botun kullanmasını sağlayabilirsiniz. Veya kullanılmayan anahtarları başka bir dosyaya kopyala yapıştır yapıp daha sonra kullanabilirsiniz, tercih sizin. Unutmayın ki ASF sıradaki anahtarları aktifleştirmeyi denedikçe `used` ve `unused` dosyalarına yazılmaya devam edecek, o yüzden bu dosyaları kullanmadan önce sıradaki anahtarların bitmesini beklemeniz tavsiye edilir. Eğer bu dosyalara sıra bitmeden erişmek zorundaysanız, önce o dosyası başka bir klasöre **taşıyıp**, **sonra** kullanmalısınız. Çünkü siz işinizi yaparken ASF yeni sonuçları dosyalara yazabilir ve bu da bazı anahtarların kaybına neden olabilir. Örneğin, dosyada 3 anahtar varken silmeye kalkışırsanız, siz dosyayı silene kadar ASF o dosyaya 4 yeni anahtar daha ekleyebilir. Bu dosyalara erişmek istiyorsanız, öncesinde ASF `yapılandırma` klasöründen başka bir yere taşıdığınıza emin olun, ismini değiştirseniz de yeter.

Yukarıdaki adımları takip ederek de sıra doluyken de sıraya yeni oyunlar eklemeniz mümkün. ASF yeni eklenen anahtarları doğru şekilde sıraya koyar ve eninde sonunda gerekeni yapar.

---

## Notlar

Arkaplan oyun etkinleştiricisi arka planda `OrderedDictionary` kullanır, yani anahtarlarınız dosyadaki (veya IPC API çağrısında) sırasında etkinleştirilmeye çalışılır. Yani listedeki anahtarları üstünde kalan anahtarlara muhtaç olacak, ama altındaki anahtarlara muhtaç olmayacak şekilde sıralayabilirsiniz (ve sıralamalısınız). Örneğin, eğer `G` oyununa ait `D` isminde bir DLC anahtarınız varsa, `G` oyununun anahtarı **her zaman** `D` DLC'sinin üstünde olmalıdır. Aynı şekilde, eğer `D` DLC'si `A`, `B` ve `C`'ye muhtaçsa, o zaman bu üçünün hepsi ondan önce listeye eklenmelidir (kendi gereksinimleri olmadığı sürece sıraları fark etmez).

Eğer yukarıdaki şekilde sıralama yapmazsanız, sıranın sonunda DLC'ye sahip olma hakkınız olsa bile DLC'niz `DoesNotOwnRequiredApp` cevabı alır ve etkinleştirilemez. Eğer bundan kaçınmak istiyorsanız DLC'lerinizin her zaman sırada oyunlardan sonra geldiğinden emin olun.