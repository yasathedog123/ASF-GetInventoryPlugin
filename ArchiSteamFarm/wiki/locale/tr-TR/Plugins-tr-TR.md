# Eklentiler

ASF V4 ile başlarken, programın kendisi runtime sırasında özel eklentiler için destek vermeyi içermektedir. Eklentiler ASF'in davranışlarını özelleştirmeye yarar, örnek olarak özel komutlar ekleyerek, özel takas mantığı ekleyerek veya üçüncü parti servisleri ve uygulama programlama arayüzü ile entegrasyon ekleyerek.

---

## Kullanıcılar için

ASF eklentileri ASF klasöründe bulunan `plugins` dizininden yükler. Kullanmak istediğiniz her eklenti için, adına bağlı olabilen özel bir dizin tutmanız tavsiye edilen bir uygulamadır.`MyPlugin` gibi. Bunu yapmak, bu dizin yapısıyla sonuçlanacaktır `plugins/MyPlugin`. Son olarak, eklentinin tüm ikili dosyalarını bu belirtilen klasöre koymalısınız, ve ASF yeniden başlatıldıktan sonra eklentinizi doğru bir şekilde keşfedecek ve kullanacaktır.

Genellikle eklenti geliştiricileri, eklentilerini sizin için önceden hazırlanmış bir yapıya sahip olan `zip` dosyası biçiminde yayınlar, bu yüzden bu zip arşivini `plugins` dizinine çıkarmak yeterlidir, bu da uygun klasörü otomatik olarak oluşturur.

Eğer eklenti başarılı bir şekilde yüklendi ise, çıktıda ismini ve versiyonunu göreceksiniz. Kullanmaya karar verdiğiniz eklentilerle ilgili sorularınızı, sorunlarınızı veya kullanıma yönelik şeyleri eklenti geliştiricilerinize danışmalısınız.

Öne çıkan bazı eklentileri **[üçüncü-taraf](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Third-party#asf-plugins)** bölümümüzde bulabilirsiniz.

**Lütfen ASF eklentilerinin kötü amaçlı olabileceğini unutmayın.**. Her zaman güvenebileceğiniz geliştiriciler tarafından yapılan eklentileri kullandığınızdan emin olmalısınız. Herhangi bir özel eklenti kullanmaya karar verirseniz, ASF geliştiricileri artık size normal ASF avantajlarını (kötü amaçlı yazılımın olmaması veya VAC'siz olmama gibi şeyleri) garanti edemez. You need to understand that plugins have full control over ASF process once loaded, due to that we're also unable to support setups that utilize custom plugins, since you're no longer running vanilla ASF code.

---

## Geliştiriciler için

Eklentiler, ASF ile ortak `IPlugin` arayüzünü devralan standart .NET kütüphaneleridir. Eklentileri ana hatları ASF'den tamamen bağımsız olarak geliştirebilir ve API(Uygulama Programlama Arayüzü) uyumlu kaldığı sürece bunları mevcut ve gelecekteki ASF sürümlerinde yeniden kullanabilirsiniz. ASF'de kullanılan eklenti sistemi, daha önce **[Yönetilen Genişletilebilirlik Çerçevesi](https://docs.microsoft.com/dotnet/framework/mef)** olarak bilinen ve ASF'in runtime sırasında kitaplıklarınızı keşfetmesine ve yüklemesine olanak tanıyan `System.Composition` 'a dayanır.

---

### Başlarken

We've prepared **[ASF-PluginTemplate](https://github.com/JustArchiNET/ASF-PluginTemplate)** for you, which you can use as a base for your plugin project. Using the template is not a requirement (as you can do everything from scratch), but we heavily recommend to pick it up as it can drastically kickstart your development and cut on time required to get all things right. Simply check out the **[README](https://github.com/JustArchiNET/ASF-PluginTemplate/blob/main/README.md)** of the template and it'll guide you further. Regardless, we'll cover the basics below in case you wanted to start from scratch, or get to understand better the concepts used in the plugin template.

**[Derlemede](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compilation)** belirtildiği gibi, projeniz hedef ASF sürümünüzün uygun çerçevesini hedefleyen standart bir .NET kitaplığı olmalıdır. We recommend you to target .NET (Core), but .NET Framework plugins are also available.

Proje esas `ArchiSteamFarm` birleştirmesine veya sürümün bir parçası olarak indirdiğiniz önceden oluşturulmuş `ArchiSteamFarm.dl ` kitaplığına başvurmalıdır, ya da projenin kaynağına (örneğin. ASF dizin ağacını alt modül olarak eklemeye karar verdiyseniz). Bu, ASF yapılarına, metodlarına ve özelliklerine, özellikle bir sonraki adımda devralmanız gereken çekirdek `IPlugin` arayüzüne erişmenize ve keşfetmenize olanak tanır. Proje aynı zamanda minimum olarak `System.Composition.AttributedModel`i referans almalıdır; bu, ASF'in kullanılması için `[Export]` `IPlugin`' i sağlar. Ek olarak, bazı arayüzlerde size verilen veri yapılarını yorumlamak için diğer ortak kütüphanelere başvurmak isteyebilir/ihtiyaç duyabilirsiniz, ancak bunlara açıkça ihtiyaç duymadığınız sürece şimdilik yeterli olacaktır.

Eğer her şeyi doğru bir şekilde yaptıysanız, `csproj` dosyanız aşağıdakine benzer olacaktır:

```csproj
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net7.0</TargetFramework>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="System.Composition.AttributedModel" IncludeAssets="compile" Version="7.0.0" />
  </ItemGroup>

  <ItemGroup>
    <Reference Include="ArchiSteamFarm" HintPath="C:\\Path\To\Downloaded\ArchiSteamFarm.dll" />

    <!-- If building as part of ASF source tree, use this instead of <Reference> above -->
    <!-- <ProjectReference Include="C:\\Path\To\ArchiSteamFarm\ArchiSteamFarm.csproj" ExcludeAssets="all" Private="false" /> -->
  </ItemGroup>
</Project>
```

Kod açısından, eklenti sınıfınız `IPlugin` arayüzünden (açık veya dolaylı olarak `IASF` gibi daha özel bir arabirimden devralarak) ve `[Export (typeof (IPlugin))]`, runtime sırasında ASF tarafından tanınmak için. Bunu başaran en açık örnek şudur:

```csharp
using System;
using System.Composition;
using System.Threading.Tasks;
using ArchiSteamFarm;
using ArchiSteamFarm.Plugins;

namespace YourNamespace.YourPluginName;

[Export(typeof(IPlugin))]
public sealed class YourPluginName : IPlugin {
    public string Name => nameof(YourPluginName);
    public Version Version => typeof(YourPluginName).Assembly.GetName().Version;

    public Task OnLoaded() {
        ASF.ArchiLogger.LogGenericInfo("Meow");

        return Task.CompletedTask;
    }
}
```

Eklentinizi kullanmak için öncelikle onu derlemelisiniz. Bunu IDE'nizden veya projenizin kök dizininden bir komutla yapabilirsiniz:

```shell
# Projeniz tek başına çalışan bileşen ise (tek proje olduğu için adını tanımlamanıza gerek yoktur.)
dotnet publish -c "Release" -o "out"
# Projeniz ASF kaynak ağacının parçasıysa (gereksiz parçaları derlemekten kaçınmak için)
dotnet publish YourPluginName -c "Release" -o "out"
```

Daha sonra eklentiniz dağıtım için hazırdır. Eklentinizi tam olarak nasıl dağıtmak ve yayınlamak istediğiniz size kalmış, ancak `Calisma AlaniIsmi.EklentiIsminiz` adlı tek bir klasörle bir zip arşivi oluşturmanızı öneririz.**[Gereksinimler](#plugin-dependencies)**. Bu şekilde kullanıcının zip arşivinizi `plugins` dizinine açması yeterli olacaktır.

Bu, başlamanıza yardımcı olacak en basit senaryodur. Yardımcı yorumlar da dahil olmak üzere kendi eklentiniz içinde yapabileceğiniz örnek arayüzleri ve eylemleri gösteren **[`ExamplePlugin`](https://github.com/JustArchiNET/ArchiSteamFarm/tree/main/ArchiSteamFarm.CustomPlugins.ExamplePlugin)** projemiz var. Çalışan bir koddan öğrenmek isterseniz göz atmaya çekinmeyin, veya `ArchiSteamFarm.Plugins` ad alanını kendiniz keşfedin ve mevcut tüm seçenekler için birlikte verilen belgelere bakın.

If instead of example plugin you'd want to learn from real projects, there is **[`SteamTokenDumper`](https://github.com/JustArchiNET/ArchiSteamFarm/tree/main/ArchiSteamFarm.OfficialPlugins.SteamTokenDumper)** plugin developed by us, the one that is bundled together with ASF. Buna ek olarak, **[üçüncü-taraf](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Third-party#asf-plugins)** bölümümüzde diğer geliştiriciler tarafından geliştirilen eklentiler de var.

---

### API kullanılabilirliği

ASF, arabirimlerde eriştiğiniz şeylerin yanı sıra, işlevselliği genişletmek için kullanabileceğiniz birçok dahili API'yi size sunar. Örneğin, Steam web'e bir tür yeni istek göndermek istiyorsanız, her şeyi en baştan uygulamanıza gerek yoktur, özellikle de sizden uğraşmak zorunda olduğumuz tüm sorunlarla. Sizin için kimlik doğrulama, oturum yenileme veya web sınırlama gibi daha düşük seviyeli şeyleri idare ederek, kullanmanız için halihazırda birçok `UrlWithSession()` yöntemini açığa çıkaran `Bot.ArchiWebHandler` kullanın. Benzer şekilde, Steam platformu dışında web istekleri göndermek için standart .NET `HttpClient` sınıfını kullanabilirsiniz, ancak sizin için mevcut olan `Bot.ArchiWebHandler.WebBrowser`'i kullanmak çok daha iyi bir fikirdir, bu da size bir kez daha yardımcı bir el sunar, örneğin gönderdiğiniz başarısız istekleri yeniden denemesi gibi.

API kullanılabilirliğimiz açısından çok açık bir politikamız var, bu nedenle ASF kodunun zaten içerdiği bir şeyden yararlanmak istiyorsanız, **[bir sorun açın](https://github.com/JustArchiNET/ArchiSteamFarm/issues)** ve planlanan kullanım durumunuzu açıklayın. ASF'in dahili API'si dahilinde. Kullanım durumunuz mantıklı olduğu sürece, büyük olasılıkla buna karşı bir şeyimiz olmayacak. Birinin kullanmak istediği her şeyi açmamız imkansız, bu yüzden bizim için en mantıklı olanı açtık ve henüz `herkese açık olmayan` bir şeye erişmek istemeniz durumunda isteklerinizi bekliyoruz. Bu aynı zamanda, mevcut işlevselliği genişletmek için eklenmesi anlamlı olabilecek yeni `IPlugin` arabirimleriyle ilgili tüm önerileri de içerir.

Aslında, dahili ASF'in API'si, eklentinizin yapabilecekleri açısından tek gerçek sınırlamadır. Örnek olarak sizi hiçbir şey uygulamanıza `Discord.Net` kitaplığı dahil etmek ve Discord botunuz ile ASF komutları arasında bir köprü oluşturmaktan alı koyamaz, çünkü eklentinizin kendi başına gereksinimleri olabilir. İmkanlar sonsuzdur, ve eklentiniz dahilinde size olabildiğince fazla özgürlük ve esneklik sağlamak için elimizden gelenin en iyisini yaptık. yani hiçbir şeyde yapay bir sınır yok, sadece eklenti geliştirmeniz için hangi ASF parçalarının çok önemli olduğundan tam olarak emin değiliz (bunu bize bildirerek çözebilirsiniz ve bu olmadan bile ihtiyacınız olan işlevselliği her zaman yeniden uygulayabilirsiniz).

---

### API uyumluluğu

ASF'in bir tüketici uygulaması olduğunu ve koşulsuz olarak güvenebileceğiniz sabit API yüzeyine sahip tipik bir kitaplık olmadığını vurgulamak önemlidir. This means that you can't assume that your plugin once compiled will keep working with all future ASF releases regardless, it's just impossible if we want to keep developing the program further, and being unable to adapt to ever-ongoing Steam changes for the sake of backwards compatibility is just not appropriate for our case. Bu sizin için mantıklı olmalı, ama bu gerçeği vurgulamak önemli.

ASF'in herkese açık kısımlarını çalışır durumda ve istikrarlı tutmak için elimizden gelenin en iyisini yapacağız, ancak süreçte **[kullanımdan kaldırma](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Deprecation)** politikamızı izleyerek yeterince iyi nedenler ortaya çıkarsa uyumluluğu bozmaktan korkmayacağız. Bu, ASF altyapısının bir parçası olarak size maruz kalan ve yukarıda açıklanan(örneğin `ArchiWebHandler`) ve ASF geliştirmelerinin bir parçası olarak iyileştirilebilen (ve dolayısıyla yeniden yazılan) dahili ASF yapıları açısından özellikle önemlidir gelecek sürümlerin bir parçası olarak. Değişiklik kayıtlarında sizi uygun şekilde bilgilendirmek için elimizden gelenin en iyisini yapacağız ve eski özellikler hakkında çalışma süresi boyunca uygun uyarıları dahil edeceğiz. Yeniden yazma uğruna her şeyi yeniden yazma niyetinde değiliz, bu nedenle bir sonraki küçük ASF sürümünün yalnızca daha yüksek bir sürüm numarasına sahip olduğu için eklentinizi tamamen yok etmeyeceğinden emin olabilirsiniz, ancak değişiklik kayıtlarına göz atıp her şeyin yolunda olup olmadığını kontrol etmek iyi bir fikirdir.

---

### Eklenti gereksinimleri

Eklentiniz varsayılan olarak en az iki gereksinim içerecekdir, dahili API için `ArchiSteamFarm` referansı ve `System.Composition.AttributedModel` için gerekli olan `PackageReference` içerecektir. Bu, ASF eklentisi olarak tanınmak için gereklidir. Buna ek olarak, eklentinizde yapmaya karar verdiğiniz şeyle ilgili daha fazla gereksinim içerebilir (örneğin Discord ile entegre etmeye karar verdiyseniz `Discord.Net` kitaplığı).

Yapınızın çıktısı çekirdek `YourPluginName.dll` kitaplığınızın yanı sıra başvurduğunuz tüm gereksinimleri de içerecektir. Zaten çalışan bir program için bir eklenti geliştirdiğiniz için, ASF'in zaten içerdiği gereksinimleri eklemeniz gerekmez ve **içermemelidir**,örnek olarak `ArchiSteamFarm`, `SteamKit2` veya `Newtonsoft.Json`. ASF ile paylaşılan derleme gereksinimlerinizi ortadan kaldırmak, eklentinizin çalışması için mutlak bir zorunluluk değildir, ama bunu yapmak, ASF'in sizinle kendi gereksinimlerini paylaşacağı ve yalnızca kendisi hakkında bilmediği kitaplıkları yükleyeceği için, performansı artırmanın yanı sıra bellek ayak izini ve eklentinizin boyutunu önemli ölçüde azaltacaktır.

Genel olarak, yalnızca ASF'in içermediği veya yanlış/uyumsuz sürüme sahip olan kitaplıkların dahil edilmesi önerilen bir uygulamadır. Örnekler bariz olarak `EklentiIsminiz.dll`, ama örneğin buna gereksinim atamaya karar verirseniz `Discord.Net.dll` olabilir, çünkü ASF kendisini içermediğinden dolayı. API uyumluluğunu sağlamak istiyorsanız, ASF ile paylaşılan kitaplıkları paketlemek yine de mantıklı olabilir (örneğin `Newtonsoft.Json` gereksiniminin eklentinizle uyumlu olan `X` versiyonunda olması ve ASF'deki eski versiyon olmaması gibi), ama açıkça bunu yapmak bellek/boyut artışı ve daha kötü performans için bir bedeldir ve bu nedenle dikkatlice değerlendirilmelidir.

İhtiyacınız olan gereksinimin ASF'e dahil edildiğini biliyorsanız, yukarıdaki `csproj` örneğinde gösterdiğimiz gibi `IncludeAssets = "compile"` ile işaretleyebilirsiniz. Bu, derleyiciye başvurulan kitaplığı yayınlamaktan kaçınmasını söyleyecektir, eğer ASF içerisinde o kitaplığı içeriyor ise. Aynı şekilde, ASF projesine çok benzer şekilde çalışan `ExcludeAssets = "all" Private = "false"` ile başvurduğumuza dikkat edin - derleyiciye herhangi bir ASF dosyası oluşturmaktan kaçınmasını sağlamak için(kullanıcının bunların hepsine sahip olduğu göz önünde bulundurularak). Bu yalnızca ASF projesine referans verirken geçerlidir, çünkü bir `dll` kitaplığına başvurursanız, eklentinizin bir parçası olarak ASF dosyaları üretmiyorsunuzdur.

Yukarıdaki ifade konusunda kafanız karıştıysa ve daha iyisini bilmiyorsanız, `ASF-generic.zip` paketine hangi `dll` kitaplıklarının dahil edildiğini kontrol edin ve eklentinize zip dosyasının içinde dahil olmayan kitaplıkları ekleyin. Bu en basit eklentiler için yalnızca `YourPluginName.dl` olacaktır. Runtime sırasında bazı kitaplıklarla ilgili herhangi bir sorunla karşılaşırsanız, etkilenen kitaplıkları da dahil edin. Bunlarda başarısız olursa, her şeyi bir araya getirmeye karar verebilirsiniz.

---

### Yerel gereksinimler

Native dependencies are generated as part of OS-specific builds, as there is no .NET runtime available on the host and ASF is running through its own .NET runtime that is bundled as part of OS-specific build. Derleme boyutunu en aza indirmek için ASF, yerel gereksinimlerini yalnızca program içinde erişilebilecek kodu içerecek şekilde kırpar ve bu da runtime'ın kullanılmayan kısımlarını etkin bir şekilde keser. This can create a potential problem for you in regards to your plugin, if suddenly you find out yourself in a situation where your plugin depends on some .NET feature that isn't being used in ASF, and therefore OS-specific builds can't execute it properly, usually throwing `System.MissingMethodException` or `System.Reflection.ReflectionTypeLoadException` in the process.

Bu, genel derlemelerde bir sorun değildir, çünkü bunlar asla ilk etapta yerel gereksinimler ile uğraşmazlar(ana bilgisayarda ASF'yi çalıştıracak tam bir runtime'a sahip oldukları için). Ayrıca bu bir soruna otomatik olarak bir çözümdür, **eklentilerinizi genel derlemelere özel olarak hazırlamak**, ama tabiki bunun da getirdiği bir dezavantaj var o da kullanıcıların işletim sistemine bağlı ASF yapılarında eklentinin çalışmasını kesmek. Sorununuzun yerel gereksinimler ile ilgili olup olmadığını merak ediyorsanız, bu yöntemi doğrulama için de kullanabilir, eklentinizi ASF genel yapısına yükleyebilir ve çalışıp çalışmadığını görebilirsiniz. Eğer çalışıyorsa eklenti gereksinimlerinin hepsini sağlamışsınızdır ve problem yalnızca yerel gereksinimlerdedir.

Ne yazık ki, runtime'ı bütünüyle işletim sistemine bağlı yapılarda kullanmak ve runtime'ın gereksiz özelliklerinin kesilmiş haliyle işletim sistemine bağlı yapılarda kullanmak arasında bir seçim yapmamız gerekiyordu, bunu yapmak yapıyı FULL runtime'a göre 50 MB lik küçülmeye sonuçlandı. İkinci seçeneği seçtik ve ne yazık ki eksik çalışma zamanı özelliklerini eklentinizle birlikte eklemeniz imkansız. Projeniz dışarıda bırakılan runtime özelliklerine erişim gerektiriyorsa, bağlı olduğunuz bütün .NET runtime'ı eklemeniz gerekir ve bu, eklentinizi `genel` ASF yapısıyla ile birlikte çalıştırmak anlamına gelir. You can't run your plugin in OS-specific builds, as those builds are simply missing a runtime feature that you need, and .NET runtime as of now is unable to "merge" native dependency that you could've provided with our own. Belki gelecekte bir gün gelişebilir, ama şu an itibariyle bu mümkün değil.

ASF'in işletim sistemine özgü yapıları, resmi eklentilerimizi çalıştırmak için gerekli olan minimum ek işlevselliği içerir. Bunun mümkün olmasının yanı sıra, bu aynı zamanda yüzeyi en temel eklentiler için gereken ekstra gereksinimlerle biraz genişletir. Bu nedenle, tüm eklentilerin başlangıçta yerel gereksinimler hakkında endişelenmesine gerek yoktur - yalnızca ASF ve resmi eklentilerimizin doğrudan ihtiyaç duyduklarının ötesine geçen eklentilerin ihtiyacı vardır. Buradan itibaren anlatacağım şey ekstra olarak yapılır, zaten kendi kullanım durumlarımız için ek yerel gereksinimler eklememiz gerekirse bunları doğrudan ASF ile de gönderebiliriz, bu da onları kullanılabilir hale getirir ve böylece sizin için de daha kolay olur. Unfortunately, this is not always enough, and as your plugin gets bigger and more complex, the likelihood of running into trimmed functionality increases. Therefore, we usually recommend you to run your custom plugins in `generic` ASF flavour exclusively. You can still manually verify that OS-specific build of ASF has everything that your plugin requires for its functionality - but since that changes on your updates as well as ours, it might be tricky to maintain.