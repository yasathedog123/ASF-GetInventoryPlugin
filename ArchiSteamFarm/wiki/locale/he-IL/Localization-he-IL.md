# מקום

ASF is powered by Crowdin service, which makes it possible for everybody to help translating ASF into all languages spoken worldwide. For more detailed explanation how Crowdin works, please check out **[Crowdin introduction](https://support.crowdin.com/crowdin-intro)**.

If you're interested in what is currently going on, you can check **[ASF Crowdin activity](https://crowdin.com/project/archisteamfarm/activity_stream)**.

---

## Scope

Our platform supports localization of our main ASF program, as well as whole localizable content that we offer together with it. This includes especially our ASF-WebConfigGenerator, ASF-ui, as well as our wiki. All of that is possible to translate through convenient crowdin interface.

---

## Signing up

If you'd like to help with ASF, either by translating, reviewing or approving translations, please sign up on our **[Crowdin project page](https://crowdin.com/project/archisteamfarm)**. Registration is easy and absolutely free! After logging in you can pick languages that you'd like to get assigned to, then proceed to ASF strings and help the rest of the community with translating ASF into all most popular languages!

---

### Translating

If the language of your choice is still missing some strings, you can grab them and start working on the translation. We tried to do our best in terms of flexibility of the translations, therefore many strings include extra variables that ASF will provide during runtime - those are enclosed in brackets with a number, such as `{0}`. This allows you to alter default ASF format of the string, e.g. by moving ASF-provided variable in a place that satisfies your language and your translation, instead of being forced to strict context and format. This is especially important in RTL languages, such as Hebrew.

For example, you could have a string like:

> We have {0} games to farm.

But based on your language, following sentence could make more sense:

> The number of games to farm is equal to {0}.

Or:

> {0} is the number of games to farm.

The flexibility is provided specially for you, so you can slightly reword ASF sentence to fit your language better and move ASF-provided number or other information in a place that fits your translation (instead of translating each part independently). This improves overall translation quality.

---

### Reviewing

If your string was already translated by somebody else, you can vote for it. Voting makes it possible to choose the best variant of the translation, instead of sticking with initial suggestion - this enhances overall translation quality even further. You can vote on already available suggestions, or suggest your own translation, which will go through the same process. Eventually, final string will be chosen either based on most voted suggestion, or as a choice of proofreader selected for that language who personally approves given translation (based on your votes as well).

**You do not need approval to see your translated strings in ASF**. Approval simply means that somebody trusted from us has reviewed the content, as in - picked the final version of the translation. It's totally fine to have not-approved community-driven translations, where you vote for the best one. As long as it's translated, everything is fine! And if you think that current translation is bad, you can always vote for the better one, or suggest one yourself.

---

### Proof-reading

It's a good idea to have a consistent translation, even if it could potentially take freedom from community review/voting process explained above. This is mainly because incorrect translations that are not necessarily bad may get so many upvotes that it's no longer possible to suggest any better translation, even if somebody has such.

If you have past history of contributions on Crowdin or any other localization platform/service that we can verify and assume trustworthy, we're happy to give you a proof-reader access to given language you're contributing to, so you'll be able to approve given translation and make it consistent. Proof-reading is not an easy task, especially because ASF can be very "technical" from time to time and really difficult to translate, but we understand that it's often needed for a perfect translation. Therefore if you can help by proof-reading given language, **[let us know](https://crowdin.com/messages/create/13177432/240376)**, but keep in mind that you'll need to back up your request with past localization contributions that we can verify (e.g. working with ASF localization on Crowdin, or with any other project). We may also allow more advanced users to pick up initial proof-reading, if we know them personally and they're capable of cooperating with the rest of the community in order to localize ASF in that language best.

General rules apply for proof-reading - do not rush, listen to your users, work as a project manager, resolve issues, ensure that you're making things better and not worse.

---

### Issues

If you have a problem with particular translation, e.g. you do not know how to translate it, approved translation is incorrect, you need more specific context, or likewise, please post a comment under specific string, and mark it with [X] Issue.

**Please avoid using issue mark if you do not need technical/development explanation or admin action**. You're free to use comments for discussion related to translation of given string, but issue should be used only when you need further technical explanation or admin correction, and it will typically involve somebody who does not even speak the language you're translating to, so please stick with English when writing issue comment (so we can understand what the issue is).

There are currently 4 supported type of issues:
- General question - for everything else that doesn't fit any issue below. In general this type **should be avoided**, as if your problem does not fit, then it's very likely **not** a translation issue. Still, this option is available here for all other cases.
- Current translation is wrong - this should be used **only** if translation was pre-approved by proof-reader already, and you believe that it's wrong, for example it has a typo or you have a valid suggestion how to improve it. This type should never be used in translations that are powered by the community (voting), as in this case you should contact with user of given translation and ask him for correction, or simply vote for better translation, as stated in reviewing section. We'll remove the approval of the translation and notify the appropriate proof-reader in charge of the language to take into account your comment and verify again.
- Lack of contextual information  - this is what you should use if you're not sure what part of ASF you're translating, what is the context of given string, or its purpose. This type should be used for ASF development only, it means you need technical assistance as you're not sure how you should translate given string.
- Mistake in the source string - this should be used only if you believe that original (English) string is incorrect. Quite rare, but not all of us are speaking English natively either, so feel free to use it if you have a general idea how it could be improved. Alternatively, since this is strictly related to the development, you may use our **[GitHub issues](https://github.com/JustArchiNET/ArchiSteamFarm/issues/new/choose)** for that purpose, if you'd like to.

---

### Translation progress

Every language has two states of completion - translation, and proof-reading.

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

> If you're a new user, we recommend starting with **[setting up](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up)** guide.

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

Be extremely careful when you translate sentences with `<code></code>` blocks inside. Code block indicates fixed ASF code names or terms that should not be translated. For example:

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