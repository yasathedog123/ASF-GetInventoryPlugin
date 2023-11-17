# 當地語系化:

ASF 由 Crowdin 服務提供支援，這使得每個人都可以幫助將 ASF 翻譯成世界各地的語言。 有關 Crowdin 工作原理的詳細說明，請查看 **[Crowdin 介紹](https://support.crowdin.com/crowdin-intro)**。

如果您想了解當前本土化工作的進程，可以關注 **[ASF Crowdin 動態](https://crowdin.com/project/archisteamfarm/activity_stream)**。

---

## 範圍

我們的平臺支援我們的主要 ASF項目的當地語系化，以及我們與之一起提供的完整的可當地語系化內容。 這主要包括我們的ASF網頁設置檔生成器、ASF-ui 以及我們的wiki。 所有這些都可以輕鬆地通過Crowdin介面進行轉換。

---

## 註冊

如果您想幫助對ASF的翻譯、審閱或批准翻譯，請註冊我們的 **[Crowdin 項目](https://crowdin.com/project/archisteamfarm)**。 註冊是簡單和完全免費的！ 登錄後，您可以選擇您想參與翻譯的語言，然後開始翻譯 ASF 字串，並協助其他社區成員將 ASF 翻譯成所有當下最流行的語言！

---

### 翻譯

如果您選擇的語言仍然缺少一些字串，您可以選取它們並開始翻譯。 We tried to do our best in terms of flexibility of the translations, therefore many strings include extra variables that ASF will provide during runtime - those are enclosed in brackets with a number, such as `{0}`. 這樣，您就可以更改ASF中字串的預設格式，例如將ASF提供的變數移動到更符合您的語法和翻譯習慣的位置，而不是被迫嚴格di w沿用原文格式。 這在 RTL 語言（如希伯來文）中尤其重要。

例如，您可以有一個這樣的字串：

> We have {0} games to farm.

但在你的語言習慣中，下面的句子可能更恰當：

> The number of games to farm is equal to {0}.

或：

> {0} is the number of games to farm.

The flexibility is provided specially for you, so you can slightly reword ASF sentence to fit your language better and move ASF-provided number or other information in a place that fits your translation (instead of translating each part independently). 這提高了整體翻譯品質。

---

### 審查

如果您選取的字串已由其他人翻譯，您可以投票以贊成或反對。 投票可以選擇最佳的翻譯，而不是堅持最初的建議──這進一步提高了整體翻譯品質。 你可以為已經可以提交的翻譯建議投票，也可以提交自己的翻譯建議，這將經歷同樣的過程。 Eventually, final string will be chosen either based on most voted suggestion, or as a choice of proofreader selected for that language who personally approves given translation (based on your votes as well).

**您已翻譯的字串不需批准即可在ASF中查看**。 批准只是意味著有值得我們信任的人士審查了翻譯內容，並選擇了翻譯的最終版本。 It's totally fine to have not-approved community-driven translations, where you vote for the best one. 只要翻譯完成，萬事大吉！ 如果您認為現在的翻譯不好，您總是可以為您更欣賞的翻譯投票，或者自己提交一個。

---

### 校對

It's a good idea to have a consistent translation, even if it could potentially take freedom from community review/voting process explained above. This is mainly because incorrect translations that are not necessarily bad may get so many upvotes that it's no longer possible to suggest any better translation, even if somebody has such.

If you have past history of contributions on Crowdin or any other localization platform/service that we can verify and assume trustworthy, we're happy to give you a proof-reader access to given language you're contributing to, so you'll be able to approve given translation and make it consistent. 校對不是一件容易的事情，特別是因為ASF有時會非常「技術性」且難以翻譯，但我們明白，它通常是完美翻譯所必需的。 Therefore if you can help by proof-reading given language, **[let us know](https://crowdin.com/messages/create/13177432/240376)**, but keep in mind that you'll need to back up your request with past localization contributions that we can verify (e.g. working with ASF localization on Crowdin, or with any other project). We may also allow more advanced users to pick up initial proof-reading, if we know them personally and they're capable of cooperating with the rest of the community in order to localize ASF in that language best.

適用于校對的一般規則──不要心急，傾聽用戶的聲音，統籌項目，解決問題，確保把事情做得更好，而不是更糟。

---

### 問題

If you have a problem with particular translation, e.g. you do not know how to translate it, approved translation is incorrect, you need more specific context, or likewise, please post a comment under specific string, and mark it with [X] Issue.

**Please avoid using issue mark if you do not need technical/development explanation or admin action**. You're free to use comments for discussion related to translation of given string, but issue should be used only when you need further technical explanation or admin correction, and it will typically involve somebody who does not even speak the language you're translating to, so please stick with English when writing issue comment (so we can understand what the issue is).

當前我們對以下4類問題提供支援：
- 一般問題──任何不符合下面任何標準的問題。 In general this type **should be avoided**, as if your problem does not fit, then it's very likely **not** a translation issue. Still, this option is available here for all other cases.
- Current translation is wrong - this should be used **only** if translation was pre-approved by proof-reader already, and you believe that it's wrong, for example it has a typo or you have a valid suggestion how to improve it. This type should never be used in translations that are powered by the community (voting), as in this case you should contact with user of given translation and ask him for correction, or simply vote for better translation, as stated in reviewing section. We'll remove the approval of the translation and notify the appropriate proof-reader in charge of the language to take into account your comment and verify again.
- Lack of contextual information  - this is what you should use if you're not sure what part of ASF you're translating, what is the context of given string, or its purpose. This type should be used for ASF development only, it means you need technical assistance as you're not sure how you should translate given string.
- Mistake in the source string - this should be used only if you believe that original (English) string is incorrect. Quite rare, but not all of us are speaking English natively either, so feel free to use it if you have a general idea how it could be improved. Alternatively, since this is strictly related to the development, you may use our **[GitHub issues](https://github.com/JustArchiNET/ArchiSteamFarm/issues/new/choose)** for that purpose, if you'd like to.

---

### 翻譯進度

每種語言都有兩種完成狀態——翻譯和校對。

Language is considered **translated** when its translation progress reaches 100%. At this point every localizable string used by ASF has proper meaning, which is great. However, that doesn't mean that there is no room for improvement - community voting is enabled all the time and you can still suggest better translation for already-translated parts, as well as vote for existing ones. Please note that fully-translated languages can still drop below 100% when we change existing strings or add new ones during development. You can set up appropriate crowdin notifications if you'd like to receive e-mail when this happens.

Selected languages may have appropriate proof-readers that validate translations and approve final versions. This is final pass after translation takes place and allows to further improve localization.

ASF will include given language **as soon as possible**, which means that it doesn't need to be approved, or even 100% translated. The actual strings that will be used are always the most popular ones in terms of the votes, unless chosen proofreader decided otherwise (rarely). Therefore, you can see your efforts being included in the very next ASF release - our automation systems merge translations from Crowdin back to ASF repo on daily basis.

---

## Missing languages

By default ASF project has open translation only for top 30 languages that are spoken worldwide. If you'd like to add another one (or a local dialect to already available one), please **[let us know](https://crowdin.com/messages/create/13177432/240376)** and we'll add it ASAP. We don't want to open several hundred different languages if nobody is going to translate them, that's why we limited it to some fair number. Please don't hesitate to contact us if you'd like to translate some not-listed language, it's very easy for us to add another one. Just make sure that you have actual willings and determination to translate ASF into your language, before you decide to contact with us.

For a complete list of all available languages that ASF can be translated to, **[click here](https://developer.crowdin.com/language-codes)**.

---

## Pluralization

Every language has its own rules in regards to pluralization. Those rules can be found on **[CLDR](https://unicode-org.github.io/cldr-staging/charts/latest/supplemental/language_plural_rules.html)** which specifies their number and exact language conditions.

We're doing our best to offer you flexible localization, and as long as possible, this will also include plural rules. For example, we'll translate following string into Polish today:

> Released {PLURAL:n|{n} month|{n} months} ago

`PLURAL` keyword here is treated in a special way as it allows you to include all plural forms that your language supports. If you take a look at CLDR, you'll see that in English there are only 2 cardinal forms - "one", and "other". And as you can see above, we have both of those defined - `{n} month` and `{n} months`.

However, our Polish language actually includes 4 of them - "one", "few", "many" and "other". This means that we should define all of them for completion. Our localization tools are already smart enough to pick appropriate plural form based on language rules, therefore you only have to define all of them in the translation:

> Wydany {PLURAL:n|{n} miesiąc|{n} miesiące|{n} miesięcy|{n} miesiąca} temu

This way we've defined all 4 plural forms for our Polish language, and since our localization library already knows the exact rules, it'll properly use the correct form for provided `{n}` number.

It's not mandatory to define all plural forms used by your language. If missing, our localization library will use last defined form in its place. It's a good idea to define all plural forms used by your language, but in some cases remaining plural forms could be the same as last one, in which case it's not needed to repeat them. In our example above it was mandatory, as "other" form in Polish for months is "miesiąca", and not "miesięcy" as in "many".

---

## Wiki

Our crowdin platform also allows you to localize even the wiki itself. This is a very powerful tool, since it allows you to create a whole ASF documentation in your native language, effectively solving the very last issue when it comes to ASF localization. Together with translation of the program and all its parts, this makes localization complete.

Wiki is a bit special in this regard, since it's online help where you don't need to stick with original sentence too much. This means that you want to be as natural with your language as possible, and deliver original meaning and help - not necessarily stick with original string, used words and actual punctuation. Don't be afraid of rewriting the string into something far more natural for your language, as long as you keep the general direction and help included in the sentence.

---

### Global links

Our crowdin platform also allows you to adapt the original text in order to make it point to new (localized) locations.

ASF includes links on almost every page for easier navigation, as well as sidebar on the right. The awesome fact is that you can edit all of that, "fixing" links to point to proper localized pages for your language. It requires to be a bit careful doing that, but it's possible.

For example, ASF **[home page](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Home)** includes a text such as:

> 如果您是新用戶，我們建議您從**[設置指南](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up)**開始。

Which is originally written as:

```markdown
If you're a new user, we recommend starting with **[setting up](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up)** guide.
```

On the crowdin, first thing you should do is going to your editor settings and ensuring that HTML tags are set to "Show" for you. This is very important if you decide to localize the wiki.

---

![Crowdin](https://i.imgur.com/YqAxiZ4.png)

---

Now, during translating on the crowdin, depending on formatting, you'll see ASF links in the text either as:

* String to translate together with HTML tags (majority of strings, where only a part of the sentence is a link)
* Alone string to translate, with link included in `Hidden texts` -> `Link addresses` (rare, where entire string is a link, most common in sidebar - those require proofreader access to translate, sadly)

In our example above, it's the first case (since only "setting up" is a link), so in crowdin we'll see it as:

---

![Crowdin 2](https://i.imgur.com/Li5RzS3.png)

---

Regardless of case, firstly you should copy the source string and translate it as usual, leaving entire HTML (if present) intact. This would be example of translation for Polish language:

---

![Crowdin 3](https://i.imgur.com/NpKwfka.png)

---

Now, if the link is a generic link that points outside of the wiki (e.g. to latest ASF release), you can leave it as it is since you don't want to edit it. You can save it and move forward.

However, if the link **does** point further inside the wiki, like the one above, you can actually correct it to point to new (localized) location. You do this by carefully appending `-locale` to target URL in `<a>` tag, like below:

---

![Crowdin 4](https://i.imgur.com/TL8uwmb.png)

---

Be extremely careful about this, and ensure that your URL indeed exists, since if you make a mistake, that link will stop functioning. If you succeeded, you now have a fully functional translation with link pointing to translated (in our case `Setting-up-pl-PL`) page.

Doing the steps above will properly translate our HTML back to markdown:

```markdown
Jeśli jesteś nowym użytkownikiem, zalecamy rozpoczęcie od korzystania z **[przewodnika po konfiguracji](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up-pl-PL)**.
```

And finally into wiki text:

> Jeśli jesteś nowym użytkownikiem, zalecamy rozpoczęcie od korzystania z **[przewodnika po konfiguracji](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up-pl-PL)**.

When no HTML is present (second case), this is even easier since you can just go to `Hidden texts` -> `Link addresses`.

---

![Crowdin 5](https://i.imgur.com/ZmgavCM.png)

---

From there you can easily correct the link to point to new location, without even bothering with HTML at all:

---

![Crowdin 6](https://i.imgur.com/maG7kSm.png)

---

### Local links

Across the wiki you will also find local links that point to particular section of the document. Those links include `#` character, indicating the web browser that it should move towards that section of the document.

Now those are special cases, since those links are based on names of the sections of current document. While for URLs we have general convention of adding `-locale` to the URL, and it works everywhere, section names will be translated by you and other people, so you need to ensure that they point to proper location.

For example you can find `#introduction` link in our **[configuration](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#introduction)** section:

---

![Crowdin 7](https://i.imgur.com/EEHSPtK.png)

---

Since we're going to translate "Introduction" word into "Wprowadzenie" for our Polish language, we'll need to correct this link since it'll stop functioning the moment we do this.

---

![Crowdin 8](https://i.imgur.com/JMJegO7.png)

---

This way our local link will keep working, since it'll now point to name of the section that we're using. You can correct links inside HTML tags in exactly the same way.

---

### Code blocks

Be extremely careful when you translate sentences with `<code></code>` blocks inside. Code block indicates fixed ASF code names or terms that should not be translated. 範例：

> This is especially useful if you have a lot of keys to redeem and you're guaranteed to hit <code>RateLimited</code> status before you're done with your entire batch.

As you can see, `RateLimited` word here is inside a code block and indicates internal ASF code status that should not be translated. Likewise, you shouldn't translate other code blocks, such as names of config properties (e.g. `TradingPreferences`), enum members (e.g. `Stable` and `Experimental` options of `UpdateChannel`) and likewise.

However, just because those words should not be translated, doesn't mean that you can't add appropriate translation next to them, for example in brackets.

> Ta funkcja jest wyjątkowo użyteczna w przypadku aktywacji dużej ilości kluczy i gwarancji napotkania statusu <code>RateLimited</code> (zbyt częstej aktywacji) przed ukończeniem całej partii.

As you can see above, we've added "zbyt częstej aktywacji", literally "too often activation" next to `RateLimited` in order to translate that status in a friendly way, while at the same time keeping original ASF meaning that the user may see during usage of the program. In the same way you can translate/explain other, similar cases of various words and sentences.

If you believe that something inappropriate is included in a code block, or that there is a text that is not in a code block but should be inside it, feel free to ask on our crowdin by creating appropriate **[issue](#issues)**. This also serves as a practical example of using a local link.

---

## Hall of fame

We'd like to show our eternal gratitude to people that have spent a significant amount of their time and willings to make ASF localization better. Their effort is incredible, and you can enjoy complete translations, including the wiki, mostly thanks to them. As a token of appreciation, all people listed here are offered free access to **[`MatchActively`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#matchactively)** feature upon a **[request](https://crowdin.com/messages/create/13177432/240376)**.

| Contributor                                                | Languages          |
| ---------------------------------------------------------- | ------------------ |
| **[Astaroth](https://crowdin.com/profile/astaroth2012)**   | LOLCAT, Spanish    |
| **[Dead_Sam](https://crowdin.com/profile/Dead_Sam)**       | Portuguese (BR)    |
| **[deluxghost](https://crowdin.com/profile/deluxghost)**   | Chinese (CN)       |
| **[DragonTaki](https://crowdin.com/profile/dragontaki)**   | Chinese (TW)       |
| **[LittleFreak](https://crowdin.com/profile/littlefreak)** | German             |
| **[Ryzhehvost](https://crowdin.com/profile/Ryzhehvost)**   | Russian, Ukrainian |
| **[MrBurrBurr](https://crowdin.com/profile/MrBurrBurr)**   | LOLCAT, German     |
| **[XinxingChen](https://crowdin.com/profile/XinxingChen)** | Chinese (HK)       |

Thank you all for improving our ASF localization quality!