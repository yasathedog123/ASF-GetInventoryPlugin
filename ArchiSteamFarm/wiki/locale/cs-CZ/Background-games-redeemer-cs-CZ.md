# Aktivace her na pozadí

Aktivace her na pozadí je speciální vestavěná funkce ASF, která umožňuje importovat danou sadu klíčů Steam cd-key (společně s jejich jmény) na pozadí. To je zvláště užitečné, pokud máte mnoho klíčů k uplatnění a máte jistotu, že dosáhnete `RateLimited` **[stav](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#what-is-the-meaning-of-status-when-redeeming-a-key)**, než budete mít hotovou aktivaci všech klíčů.

Aktivace her na pozadí je vytvořena tak, aby byl použit jeden bot, což znamená, že nepoužívá `RedeemingPreferences`. Tuto funkci lze v případě potřeby použít společně s (nebo namísto) `uplatnit` **[příkaz](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**.

---

## Import

Import lze provést dvěma způsoby - buď pomocí souboru, nebo IPC.

### Soubor

ASF rozezná ve svém `konfiguračním adresáři` soubor s názvem `BotName.keys`, kde `BotName` je název vašeho bota. Tento soubor očekával fixní strukturu se jmény her a klíčy, oddělené od sebe tabulátorem a zakončen novou řádkou pro označení dalšího záznamu. Pokud se používá více tabulátorů, pak je první položka považována za jméno hry, poslední položka je považována za klíče a vše mezi nimi je ignorováno. Například:

```text
POSTAL 2 ABCDE-EFGHJ-IJKLM
Domino Craft VR 12345-67890-ZXCVB
Týden cirkulu POIUY-KJHGD-QWERT
Terraria ThisIsIgnored ThisIsIgnoredToo ZXCVB-ASDFG-QWERT
```

Případně můžete použít pouze formát klíčů (stále s novým řádkem mezi každým záznamem). ASF v tomto případě použije odpověď ze Steamu dotazu (je-li to možné) k určení správného jména. Pro jakýkoli druh klíčů doporučujeme pojmenovat vaše klíče manuálně, protože balíčky jsou na Steamu vybírané, nemusí dodržovat logiku her, které se aktivují, takže v závislosti na tom, co napsal vývojář, můžete vidět správné názvy her a vlastní názvy balíčků (např.. Humble Indie Bundle 18) nebo přímo špatný a potenciálně dokonce jiný název balíčku (např. Half-Life 4).

```text
ABCDE-EFGHJ-IJKLM
12345-67890-ZXCVB
POIUY-KJHGD-QWERT
ZXCVB-ASDFG-QWERT
```

Bez ohledu na to, kterého formátu jste se rozhodli držet, ASF importuje váš soubor `klíče`, a to buď při startu bota, nebo později během spuštění. Po úspěšné analýze souboru a případném vynechání neplatných záznamů, všechny správně zjištěné hry budou přidány do fronty na pozadí a `BotName.keys` soubor bude odstraněn z `adresáře s konfigurací`.

### IPC

Kromě použití výše uvedeného souboru klíčů ASF také odhaluje `GamesToRedeemInBackground` **[ASF API endpoint](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-api)**, který může být spuštěné jakýmkoliv nástrojem IPC, včetně našeho ASF-ui. Použití IPC by mohlo být více užitečné, protože můžete sami dělat analýzy, jako například. používání vlastního oddělovače místo toho, abyste byli nuceni využívat tabulátor jako oddělovač, nebo dokonce můžete zavést zcela vlastní vlastní strukturu klíčů.

---

## Fronta

Jakmile jsou hry úspěšně importovány, přidávají se do fronty. ASF automaticky prochází frontou na pozadí, pokud je bot připojen k síti Steam a fronta není prázdná. Klíč, který byl použit k pokusu o vybrání a nevedl k `RateLimited`, je ze fronty odstraněn, a status je zapsán do souboru ve složce `config` - anebo `BotName.keys.used`, pokud byl klíč použit v procesu (např. `NoDetail`, `BadActivationCode`, `DuplicateActivationCode`) nebo `BotName.keys.unused`. ASF úmyslně používá zadaný název hry, protože klíč nezaručuje odpovídající jméno poskytnuté sítí Steam - tímto způsobem můžete své klíče označit i pomocí vlastních názvů, pokud je to nutné/chtěné.

Pokud během procesu náš účet zasáhne stav `RateLimited`, fronta je dočasně pozastavena na celou hodinu, aby bylo možné čekat na vypršení cooldownu. Afterwards, the process continues where it left, until the entire queue is empty or another `RateLimited` occurs.

---

## Příklad

Předpokládejme, že máte seznam 100 klíčů. Nejprve byste měli vytvořit nový soubor `BotName.keys.new` v adresáři `config`. Připojili jsme `.new` koncovku, aby ASF věděl, že by neměl tento soubor okamžitě použít v době jeho vytvoření (protože se jedná o nový prázdný soubor, který zatím není připraven k importu).

Nyní můžete otevřít náš nový soubor a vložit seznam našich 100 klíčů, případně opravit formát textu. Po opravě našeho `BotName.keys.new` soubor bude mít přesně 100 (nebo 101 s posledními novými řádky), každý řádek se strukturou `GameName\tcd-key\n`, kde `\t` je tabulátor a `\n` je nový řádek.

Nyní můžete přejmenovat tento soubor z `BotName.keys.new` na `BotName.keys` aby ASF věděl, že je připraven k použití. Jakmile to uděláte, ASF automaticky importuje soubor (bez nutnosti restartovat) a poté jej odstraní, s potvrzením, že všechny naše hry byly analyzovány a přidány do fronty.

Namísto použití souboru `BotName.keys` můžete také použít IPC API endpoint, nebo dokonce kombinovat obě varianty, pokud chcete.

Po nějaké době budou vygenerovány `BotName.keys.used` a `BotName.keys.unused` soubory. Tyto soubory obsahují výsledky našeho procesu vyzvedávání klíčů. Například můžete přejmenovat `BotName.keys.unused` na `BotName2.keys` soubor a tím se naše nepoužité klíče použijí pro jiného bota, protože předchozí bot tyto klíče nevyužil. Nebo můžete jednoduše kopírovat a vkládat nepoužité klíče do jiného souboru a ponechat je pro pozdější použití. Mějte na paměti, že ASF prochází frontu nových položek, nové položky budou přidány do našeho výstupu `used` a `unused` souborů, Proto je doporučeno počkat na úplné vyprázdnění fronty před jejich použitím. Pokud musíte k těmto souborům přistupovat před úplným vyprázdněním fronty, nejprve byste měli **přesunout** výstupní soubor, ke kterému chcete přistupovat do jiného adresáře, **pak** jej analyzovat. Je to proto, že ASF může připojit některé nové výsledky, zatímco vy provádíte tuto akci, a to by mohlo vést ke ztrátě některých klíčů, pokud máte otevřený soubor, kde jsou např. 3 klíče uvnitř, poté je odstraníte, v souboru zcela chybí další 4 klíče, které ASF mezitím přidal do souboru. Pokud chcete mít přístup k těmto souborům, ujistěte se, že je před jejich otevřením je přesunete z adresáře ASF `config`, například přejmenováním.

Také je možné přidat další hry k importu, zatímco některé hry jsou již ve frontě, opakováním všech výše uvedených kroků. ASF přidá další položky do již probíhající fronty a nakonec se s ní vypořádá.

---

## Poznámky

Klíče na pozadí používají implementaci `OrderedDictionary`, což znamená, že vaše klíče budou zachovány v pořadí tak, jak byly specifikovány v souboru (nebo IPC API volání). To znamená, že můžete (a měli byste) poskytnout seznam, kde může mít daný klíč pouze přímou závislost na klíč uvedených výše, ale ne níže. Například to znamená, že pokud máte DLC `D`, které vyžaduje aktivaci hry `G`, pak klíč pro hru `G` by **vždy** měl být před cd-key pro DLC `D`. Stejně tak pokud by DLC `D` mělo záviset na `A`, `B` a `C`před tím by měly být zahrnuty všechny 3 (v každém pořadí, pokud nejsou závislé na sobě).

Nedodržení tohoto schématu způsobí, že vaše DLC není aktivováno s `DoesNotOwnRequdApp`, i v případě, že by váš účet byl způsobilý k aktivaci po provedení celé fronty. Pokud se tomu chcete vyhnout, musíte se ujistit, že vaše DLC je vždy ve frontě zahrnuto až po základní hře.