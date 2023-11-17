# Takas

ASF, Steam'in etkileşimli olmayan (çevrimdışı) takaslarına destek sağlar. Hem alım (kabul/reddetme) hem de takas gönderme hemen yapılabilir ve özel yapılandırma gerektirmez, ancak şüphesiz bir şekilde sınırlandırılmamış (mağazada 5$ harcamış olan) Steam hesabı gerektirir. Sınırlandırılmış hesaplarda takas modülüne erişilemez.

---

## Mantık

ASF, bota `Ana Kullanıcı` (veya daha yüksek) erişimi olan kullanıcıdan, ögelerden bağımsız olarak gönderilen tüm takasları her zaman kabul edecektir. Bu, yalnızca bot istemcisi tarafından farmlanan Steam kartlarının kolayca lootlanmasına izin vermekle kalmaz, aynı zamanda, envanterde saklanan Steam ögelerini -(CS:GO gibi olan) diğer oyunlar da dahil olmak üzere- kolayca yönetebilmeyi sağlar.

ASF, takas modülünden kara listeye alınmış herhangi bir (ana kullanıcı olmayan) kullanıcıdan gelen alım satım teklifini içerikten bağımsız olarak reddedecektir. Kara liste standart olarak `BotName.db` veritabanında depolanır ve `tb`, `tbadd`,`tbrm` **[komutları](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** aracılığıyla yönetilebilir. Bu, Steam'in sunduğu standart kullanıcı engellemesine bir alternatif olarak hizmet etmelidir - dikkatli kullanılmalıdır.

ASF, `TradingPreferences` içinde `DontAcceptBotTrades` belirtilmedikçe, botlar arasında gönderilen tüm `loot` gibi işlemleri kabul eder. Kısaca, `TradingPreferences`'in varsayılan değeri olan `None`, ASF'nin bota `Ana Kullanıcı` erişimi olan (yukarıda açıklanmıştır) kullanıcıdan gelen işlemleri (ASF içerisinde yer alan diğer botlardan yapılan tüm bağış işlemleri gibi) otomatik olarak kabul etmesine neden olur. Diğer botlardan yapılan bağış takaslarını devre dışı bırakmak istiyorsanız, `TradingPreferences`'ın `DontAcceptBotTrades` ayarı bunun için bulunmakta.

`TradingPreferences`'ın `Donations` ayarını etkinleştirdiğinizde, ASF, bot hesaplarından herhangi birinin öge kaybetmediği herhangi bir takası kabul eder. Bot hesapları `DontAcceptBotTrades` tarafından etkilendiğinden, bu özellik yalnızca bot olmayan hesapları etkiler. `AcceptDonations`, diğer insanlardan ve ayrıca ASF içerisinde yer almayan botlardan kolayca bağış kabul etmenizi sağlar.

`AcceptDonations`'un **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)** gerektirmediğini belirtmek güzel, çünkü herhangi bir öge kaybetmezsek onay gerekmez.

Ayrıca, `TradingPreferences`'ı buna göre değiştirerek ASF takas modülünü daha da özelleştirebilirsiniz. Ana `TradingPreferences` özelliklerinden biri olan `SteamTradeMatcher` seçeneği, ASF'nin eksik rozetleri tamamlamanıza yardımcı olan alım satımları kabul etmek için yerleşik mantığı kullanmasına neden olur. Bu özellik, **[SteamTradeMatcher](https://www.steamtradematcher.com)**'ın herkese açık listelemesiyle işbirliği için özellikle yararlıdır ancak onsuz da çalışabilir. Aşağıda ayrıca açıklanmıştır.

---

## `SteamTradeMatcher`

`SteamTradeMatcher` etkin olduğunda, ASF, takasın STM kurallarını geçip geçmediğini ve en azından bize karşı tarafsız olup olmadığını kontrol etmek için oldukça karmaşık bir algoritma kullanır. Asıl mantık aşağıdaki gibidir:

- `MatchableTypes`'da belirtilen öge türleri dışında bir şey kaybedersek takası reddet.
- Oyun başına, tür başına ve nadirlik bazında en az aynı sayıda öge almıyorsak takası reddet.
- Kullanıcı özel Steam yaz/kış indirim kartları isterse ve takas beklemeye alınırsa takası reddet.
- Beklemede tutma süresi `MaxTradeHoldDuration` global yapılandırma özelliğini aşarsa takası reddet.
- Eğer `MatchEverything` ayarlı değilse, takası reddet. Bu bizim için nötrden daha kötü.
- Yukarıdakilerden herhangi biri sebebiyle reddetmediysek, takası kabul et.

ASF'nin fazla ödemeyi de desteklediğini belirtmek güzel - yukarıdaki tüm koşullar karşılandığı sürece, kullanıcı ticarete fazladan bir şey eklediğinde mantık düzgün çalışacaktır.

İlk 4 red beyanı herkes için anlaşılır olmalı. Sonuncusu, envanterinizin mevcut durumunu kontrol eden ve ticaretin durumunun ne olduğuna karar veren gerçek kopyalar mantığını içerir.

- Belirlenen tamamlama yönünde ilerlememiz varsa, ticaret **iyidir**. Örnek: A A (önce) - > A B (sonra)
- Set tamamlama yolundaki ilerlemeniz değişmeden kalırsa, ticaret **nötr** olur. Örnek: A B (önce) - > A C (sonra)
- Set tamamlama yönünde ilerlemeniz azalırsa, ticaret **kötü** olur. Örnek: A C (önce) - > A A (sonra)

STM yalnızca iyi takaslarda çalışır, bu da kopyaların eşleştirmesi için STM kullanan kullanıcının bizim için her zaman yalnızca iyi takaslar önermesi gerektiği anlamına gelir. Ancak, ASF liberaldir ve aynı zamanda nötr takasları da kabul eder, çünkü bu takaslarda aslında hiçbir şey kaybetmiyoruz, dolayısıyla onları reddetmek için geçerli bir sebep yok. Bu, özellikle arkadaşlarınız için yararlıdır, çünkü herhangi bir ilerleme kaydetmediğiniz sürece, STM kullanmadan fazla kartlarınızı takaslayabilirler.

Varsayılan olarak ASF kötü takasları reddeder - bu neredeyse her zaman bir kullanıcı olarak istediğiniz şeydir. Ancak, ASF'nin **kötü** olanlar da dahil olmak üzere tüm kopya takaslarını kabul etmesini sağlamak için `TradingPreferences`'ı `MatchEverything` olarak ayarlayabilirsiniz. Bu yalnızca, hesabınız altında 1:1 ticaret botu çalıştırmak istiyorsanız ve eğer **ASF'nin artık rozet tamamlama yolunda ilerlemenize yardımcı olmayacağını ve aynı kartın N kopyası için bitmiş setin tamamını kaybetme eğiliminde olmanıza neden olacağını** anladığınızda kullanışlıdır. **Hiçbir zaman** tam rozet toplamak niyetinde olmayan bir ticaret robotu çalıştırmakla ilgileniyorsanız ve ilgilenen herhangi bir alıcıyla herhangi bir öğeyi takas etmeye istekliyseniz, bu seçeneği etkinleştirebilirsiniz.

Seçtiğiniz `TradingPreferences` ne olursa olsun, bir işlemin ASF tarafından reddedilmiş olması, onu kendiniz kabul edemeyeceğiniz anlamına gelmez. `BotBehaviour`'un varsayılan değerini koruduysanız ki bu değer `RejectInvalidTrades`'e eşit değil, ASF bu işlemleri yok sayar - bu işlemlerle ilgilenip ilgilenmediğinize kendiniz karar vermenize olanak tanır. Aynı şey, `MatchableTypes` dışındaki ögelerle yapılan takaslar ve diğer her şey için de geçerlidir - modülün, neyin iyi olup neyin olmadığına karar vermek yerine STM işlemlerini otomatikleştirmenize yardımcı olması beklenir. Bu kuralın tek istisnası, `tbadd` komutunu kullanarak işlem modülünden kara listeye aldığınız kullanıcılardan bahsederken - bu kullanıcılardan gelen işlemler, `Bot Davranışı` ayarlarından bağımsız olarak hemen reddedilir.

Bu seçeneği etkinleştirdiğinizde, **[ASF 2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication)**'nın kullanılması önemle tavsiye edilir. Eğer her işlemi manuel olarak onaylamaya karar verirseniz, bu işlev tüm potansiyelini kaybeder. `SteamTradeMatcher`, alım satımları onaylama yeteneği olmadan bile düzgün şekilde çalışacaktır, ancak bunları zamanında kabul etmezseniz, birikmiş onaylar oluşturabilir.