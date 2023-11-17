# 현지화

ASF는 모든 사람들이 ASF를 전세계의 모든 언어로 번역할 수 있도록 하는 Crowdin 서비스를 이용하고 있습니다. Crowdin이 어떻게 동작하는지 더 자세한 설명을 원하시면, **[Crowdin 소개](https://support.crowdin.com/crowdin-intro)** 를 확인하시기 바랍니다.

현재 상황이 궁금하다면 **[ASF Crowdin 활동](https://crowdin.com/project/archisteamfarm/activity_stream)** 에서 확인할 수 있습니다.

---

## 범위

우리 플랫폼은 메인 프로그램인 ASF와, 같이 제공하는 현지화 가능한 전체 콘텐츠의 현지화를 지원합니다. 즉, ASF-웹 환경설정 생성기, ASF-ui 및 위키도 현지화에 포함됩니다. 모든 것이 편리한 Crowdin 인터페이스를 통해 번역가능합니다.

---

## 회원 가입

번역, 번역의 리뷰나 승인하는데 있어 ASF를 돕고 싶으시면 **[Crowdin 프로젝트 페이지](https://crowdin.com/project/archisteamfarm)** 에서 회원으로 가입하시기 바랍니다. 회원등록은 쉽고 무료입니다. 로그인 후 할당받고 싶은 언어를 선택하고, ASF의 문자열로 와서 다른 커뮤니티 회원들이 ASF를 모든 유명한 언어로 번역하는 것을 도와주세요!

---

### 번역하기

선택한 언어의 문자열이 누락되어 있다면 번역을 시작하면 됩니다. 우리는 번역의 유연함을 위해 최선을 다하고 있습니다. 많은 문자열은 ASF가 실행되는 동안 제공하는 외부 변수를 포함하고 있으며, `{0}` 과 같이 괄호로 둘러쌓인 숫자로 표시됩니다. 이렇게 함으로써 엄격한 컨텍스트와 형식에 강제되지 않고, ASF가 제공하는 변수를 다른 언어와 번역에 맞게 위치를 옮기는 등 기본 ASF 문자열 형식을 변경할 수 있습니다. 이것은 히브리어 등 오른쪽에서 왼쪽으로 쓰는 언어에서 특히 중요합니다.

예를 들어, 아래와 같은 문자열이 있습니다.

> We have {0} games to farm.

하지만 당신의 언어로는 다음 문장이 더 말이 될 수도 있습니다.

> The number of games to farm is equal to {0}.

또는,

> {0} is the number of games to farm.

이 유연성은 당신을 위해 특별히 제공되므로, 각 부분을 잘라서 번역하는 대신 ASF 문장을 당신의 언어에 더 알맞게 약간 말을 바꾸고 ASF에서 제공하는 숫자나 다른 정보를 당신이 한 번역에 맞는 장소로 옮길 수 있습니다. 이렇게 해서 전체적인 번역 품질이 개선됩니다.

---

### 리뷰하기

다른 사람이 이미 번역한 문자열을 선택했다면 투표를 할 수 있습니다. 투표를 통해 제일 처음 제안된 내용에 붙잡혀있지 않고 다양한 번역중 제일 좋은 것을 선택할 수 있습니다. 이렇게 해서 전체적인 번역의 품질이 훨씬 더 개선됩니다. 기 번역된 제안에 투표할 수도 있고, 동일한 절차를 따라 새로 번역을 하여 제안할 수도 있습니다. 결국 최종적인 문자열은 가장 많은 투표를 받은 제안이나 혹은 해당 언어에 대해 개인적으로 번역 승인을 받은 교정자의 선택으로 결정됩니다. (이경우에도 투표에 기초합니다)

**ASF에서 당신이 번역한 문자열을 보는데는 승인이 필요하지 않습니다.** 승인이란 간단히 말해 우리가 믿는 누군가가 번역의 최종버전을 선택하듯이 내용을 리뷰했다는 뜻입니다. 승인되지 않은, 커뮤니티에서 만든 번역이어도 최고라고 투표한다면 아무 문제 없습니다. 번역이 되어있기만 하면 모든게 문제 없습니다! 그리고 현재의 번역이 안좋다고 생각한다면 더 나은 번역에 투표하던지 직접 번역하여 제안할 수 있습니다.

---

### 교정하기

위에서 설명한 커뮤니티의 리뷰/투표 절차의 자유를 잠재적으로 없앤다하더라도, 일관되게 번역하는 것은 좋은 생각입니다. 이것은, 그렇게 나쁘지는 않은 부정확한 번역이 많은 반대투표를 받고, 더 나은 번역을 더이상 제안할 수 없는 경우가 있기 때문입니다.

Crowdin 혹은 우리가 신뢰하고 확인가능한 다른 현지화 플랫폼/서비스에서 기여한 내역이 있다면, 기여하고 계신 해당 언어의 교정접근권한을 드리고자합니다. 이를 통해 번역내용을 승인하고 일관되게 관리할 수 있습니다. 교정은 쉬운 작업이 아닙니다. 특히 ASF는 때때로 매우 "기술적"일 수 있으며 번역하기 매우 어려울 수 이있습니다. 하지만 완벽한 번역을 위해서 교정은 필요합니다. 따라서 해당 언어로 교정을 도와주실 수 있다면 **[우리에게 알려주십시오](https://crowdin.com/messages/create/13177432/240376)**. 하지만 Crowdin의 ASF 현지화나 다른 프로젝트 등 검증할 수 있는 당신의 현지화 기여내역을 같이 보내주셔야 한다는 것을 명심하십시오. 우리가 개인적으로 알고 있으며 ASF를 해당언어로 가장 잘 현지화하기 위해 커뮤니티의 다른 사용자들과 협업할 수 있는 더 많은 고급사용자들에게 초벌 교정을 선택권한을 줄 수 있습니다.

일반 규칙은 교정에도 적용됩니다. 서두르지 말고, 이용자들의 의견을 듣고, 프로젝트 매니저로써 작업하고, 이슈를 해결하고, 상황을 나쁘게 만들지 말고 개선하여야 합니다.

---

### 이슈

어떻게 번역할지 모르거나, 승인된 번역이 틀렸거나, 더욱 정확한 문맥이 필요하는 등 특정 번역에 문제가 있는 경우, [X] 이슈로 표시하여 해당 문자열에 댓글로 달아주시기 바랍니다.

**기술적/개발 설명이나 관리자 작업이 필요하지 않은 경우 이슈마크를 사용하지 마십시오.** You're free to use comments for discussion related to translation of given string, but issue should be used only when you need further technical explanation or admin correction, and it will typically involve somebody who does not even speak the language you're translating to, so please stick with English when writing issue comment (so we can understand what the issue is).

현재 4가지 종류의 이슈를 지원합니다:
- 일반 질문 - 아래 이슈에 해당하지 않는 모든 경우를 말합니다. 일반적으로 이 종류는 **피해주시기 바랍니다**. 만약 문제가 아래 종류에 해당사항이 없다면 번역 이슈가 **아닐 가능성이 높습니다**. 모든 경우의 수를 대비해서 만들어 둔 상태입니다.
- 현재 번역이 잘못됨 - 이미 교정자에 의해 승인된 번역이지만 오타가 있거나 번역을 개선할 유효한 제안이 있는 경우 등 **틀렸다고** 판단될때에만 사용하시기 바랍니다. 또한, 커뮤니티나 투표로 정해진 번역에는 절대 사용하지 마십시오. 이 경우 해당 번역자와 연락하여 수정을 요청하거나, 혹은 리뷰하기 항목에서 설명한 것 처럼 더 나은 번역에 투표하십시오. We'll remove the approval of the translation and notify the appropriate proof-reader in charge of the language to take into account your comment and verify again.
- 문맥 정보 부족 - 현재 번역중인 내용이 ASF의 어느 부분인지, 해당 문자열의 문맥 혹은 의도가 무엇인지 확실하지 않을때 사용하시기 바랍니다. 이 종류는 ASF 개발쪽에서만 사용하여야 합니다. 즉 해당 문자열을 어떻게 번역할지 확실치 않아서 기술적 지원이 필요하다는 뜻입니다.
- 원본 문자열 오류 - 영어 원본 문자열이 틀렸다고 생각하는 경우에만 사용하십시오. Quite rare, but not all of us are speaking English natively either, so feel free to use it if you have a general idea how it could be improved. Alternatively, since this is strictly related to the development, you may use our **[GitHub issues](https://github.com/JustArchiNET/ArchiSteamFarm/issues/new/choose)** for that purpose, if you'd like to.

---

### 번역 진행도

모든 언어는 번역과 교정, 두 개의 완료단계가 있습니다.

번역 진행도가 100%에 도달하면 해당 언어로 **번역되었다**고 판단됩니다. 이 시점에서 ASF에서 사용된 모든 현지화 가능한 문자열은 아주 적절한 의미를 갖게됩니다. 그러나, 개선의 여지가 없다는 뜻은 아닙니다. 커뮤니티의 투표는 항상 가능하고, 당신은 기 번역된 부분에 대해 투표하거나 더 나은 번역을 제안할 수 있습니다. 개발과정에서 기존의 문자열을 변경하거나 새롭게 추가하게되면 완전히 번역된 언어도 100% 아래로 떨어질 수 있다는 점을 양지하시기 바랍니다. 이런 일이 일어났을때 전자우편을 받고 싶다면 적절한 Crowdin 알림을 설정할 수 있있습니다.

선택된 언어에는 적절한 교정자가 있을 수 있으며, 이들은 번역을 검증하고 최종 버전을 승인합니다. 이는 번역이 이루어진 후 최종 단계이며, 현지화를 더욱 개선할 수 있게 해줍니다.

ASF는 해당 언어를 **가능한 한 빨리** 추가할 것입니다. 즉, 승인을 받거나 심지어 100% 번역되지 않아도 된다는 뜻입니다. 드문 일이지만 선택된 교정자가 다르게 결정하지 않는한, 항상 투표에서 가장 인기있는 문자열이 실제 문자열로 사용될 것입니다. Therefore, you can see your efforts being included in the very next ASF release - our automation systems merge translations from Crowdin back to ASF repo on daily basis.

---

## 언어가 없는 경우

ASF 프로젝트는 세계적으로 사용되는 상위 30개의 언어에 대해서만 번역이 가능합니다. 만약 다른 언어, 혹은 이미 있는 언어의 지역 방언을 추가하고 싶다면 **[우리에게 알려주시기 바랍니다](https://crowdin.com/messages/create/13177432/240376)**. 가능한 한 빨리 추가하겠습니다. 아무도 번역하는 사람이 없는 몇백개의 서로 다른 언어를 번역가능 상태로만 두고 싶지 않기 때문에 일정 숫자로 제한하였습니다. 목록에 없는 언어로 번역하고 싶다면 바로 알려주십시오. 사실 언어를 추가하는 것은 매우 쉽습니다. 우리에게 연락하기 전에, 단지 ASF를 당신의 언어로 번역할 실제 의지와 결심을 가지십시오.

ASF 프로젝트의 번역 가능한 전체 언어 목록은 **[여기를 참고하십시오](https://developer.crowdin.com/language-codes)**.

---

## 복수화

모든 언어는 복수화에 관한 각각의 규칙이 있습니다. 이 규칙은 숫자와 언어 상태를 특정하는 **[CLDR](https://unicode-org.github.io/cldr-staging/charts/latest/supplemental/language_plural_rules.html)** 에서 찾을 수 있습니다.

유연한 지역화를 위해 최선을 다하고 있습니다. 그리고 가능한한 복수 규칙을 포함할 것입니다. 예를 들어, 오늘은 다음의 문자열을 폴란드어로 번역할것입니다.

> Released {PLURAL:n|{n} month|{n} months} ago

여기에 있는 `PLURAL` 키워드는 당신의 언어가 지원하는 모든 복수 형태를 포함할수 있게 해주도록 특별한 방식으로 다루어집니다. CLDR을 보면, 영어는 "one"과 "other"의 오직 두가지 기수 형태만 있습니다. 위에서 보는 것처럼 이 두가지를 `{n} month` 와 `{n} months`로 정의하였습니다.

그러나 폴란드 언어는 실제로 "one", "few", "many", 그리고 "other"의 4가지가 있습니다. 이는 모두 직접 정의해야 함을 뜻합니다. 우리의 현지화 도구는 매우 똑독해서 언어 규칙에 따라 적절한 복수형태를 선택해줍니다. 따라서 번역에서는 그 모두를 아래와 같이 정의하여야 합니다.

> Wydany {PLURAL:n|{n} miesiąc|{n} miesiące|{n} miesięcy|{n} miesiąca} temu

이 방식으로 폴란드어의 4개 복수형태를 정의하였습니다. 현지화 라이브러리가 정확한 규칙을 이미 알고 있으므로, 제공된 `{n}` 숫자에 따라서 정확한 형태를 사용할 것입니다.

당신의 언어로 모든 복수 형태를 정의하는 것이 의무사항은 아닙니다. 만약 정의가 없다면 현지화 라이브러리는 그 자리에 있는 제일 마지막 형태를 사용할 것입니다. 당신의 언어에서 사용되는 모든 복수형을 정의하는 것은 좋은 생각이지만, 어떤 경우에서는 나머지 복수형태가 마지막 것과 같을수도 있습니다. 그런 경우 이를 반복할 필요가 없습니다. 위의 예제에서는 모두 정의하는 것이 필수였습니다. 폴란드어의 월(months)의 "other"형태는 "miesiąca"이고, "many"형태의 "miesięcy"가 아닙니다.

---

## 위키

Crowdin 플랫폼에서는 심지어 위키 자체를 현지화 할 수 있습니다. Crowdin은 매우 강력한 도구로, 전체 ASF 설명서를 당신의 언어로 만들수 있으며 ASF 현지화의 가장 최근 이슈를 효과적으로 해결하였습니다. ASF 프로그램과 각 부분의 번역을 통해 완전히 현지화됩니다.

위키는 원래 문장에 너무 얽매일 필요가 없는 온라인 도움말이므로 이점에서 약간 특별합니다. 즉, 원본 문자열과 사용된 단어, 실제 문장부호에 집착할 필요 없이 가능한한 자연스러운 언어로 원래의 뜻과 도움말을 전달하기 원한다는 것입니다. 문장에 포함된 전체적 방향성과 도움말을 유지하고 있다면, 문자열을 훨씬 더 자연스러운 당신의 언어로 새로 쓰는 것을 두려워하지 마십시오.

---

### 외부 링크

Crowdin 플랫폼에서는 원본 텍스트를 지역화된 새로운 위치를 가리키도록 변경할 수 있습니다.

ASF는 오른쪽에 있는 사이드바 뿐만아니라 거의 모든 페이지에 대한 링크를 포함하고 있어 쉽게 이동할 수 있습니다. 놀라운 사실은 단지 이 모든 것을 변경만 할 수 있는 것이 아니라, 당신의 언어로 현지화된 정확한 페이지를 가리킬 수 있도록 링크도 "수정"할 수 있다는 것입니다. 실제 하는데는 조금 조심스러워야 하지만 가능한 일입니다.

예를 들어, ASF **[홈 페이지](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Home-ko-KR)**에는 다음과 같은 문구가 있습니다:

> 처음 오셨다면 **[설치하기](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up-ko-KR)** 가이드부터 시작하는 것을 추천합니다.

원본은 다음과 같습니다:

```markdown
처음 오셨다면 **[설치하기](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up)** 가이드부터 시작하는 것을 추천합니다.
```

Crowdin에서 처음 할 일은 편집기 설정으로 가서 HTML 태그가 "Show"로 되어있는지를 확인하는 것입니다. 이것은 위키를 현지화하기로 했다면 매우 중요합니다.

---

![Crowdin](https://i.imgur.com/YqAxiZ4.png)

---

이제 Crowdin에서 형식에 맞추어 번역을 하는 동안 다음과 같이 텍스트에 포함된 ASF 링크를 보게될 것입니다:

* String to translate together with HTML tags (majority of strings, where only a part of the sentence is a link)
* Alone string to translate, with link included in `Hidden texts` -> `Link addresses` (rare, where entire string is a link, most common in sidebar - those require proofreader access to translate, sadly)

위의의 예제는 첫번째 경우입니다. "설치하기"만 링크이므로 Crowdin에서는 다음과 같이 표시됩니다:

---

![Crowdin 2](https://i.imgur.com/Li5RzS3.png)

---

어떤 경우건 상관없이 먼저 원본 문자열을 복사하고, 평소처럼 번역을 하거나 HTML이 있다면 전체 HTML을 그대로 둡니다. 다음은 폴란드어의 번역 예제입니다:

---

![Crowdin 3](https://i.imgur.com/NpKwfka.png)

---

링크가 최신 ASF 릴리즈 등 위키 외부로 나가는 범용 링크라면 수정할 필요가 없으므로 그대로 둡니다. 저장을 누르면 다음으로 넘어갑니다.

만약 링크가 위의 예시처럼 **위키 내부를 가리킨다면**, 실제로 지역화된 새로운 위치를 가리키도록 수정할 수 있습니다. 아래와 같이 `<a>` 태그 안에 있는 대상 URL의 끝에 `-locale`을 추가하면 됩니다:

---

![Crowdin 4](https://i.imgur.com/TL8uwmb.png)

---

매우 조심하시기 바랍니다. 그리고 URL이 실제로 존재하는지 확인하여야 합니다. 만약 실수하면 그 링크는 동작하지 않을 것입니다. 성공했다면, 이제 번역된 페이지를 가리키는 링크를 가진 완전히 작동하는 번역이 되었습니다. 이 경우에는 `Setting-up-pl-PL` 페이지입니다.

이렇게 하고나면 HTML이 다시 마크다운으로 적절하게 번역됩니다:

```markdown
Jeśli jesteś nowym użytkownikiem, zalecamy rozpoczęcie od korzystania z **[przewodnika po konfiguracji](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up-pl-PL)**.
```

위키에는 다음과 같이 보입니다:

> Jeśli jesteś nowym użytkownikiem, zalecamy rozpoczęcie od korzystania z **[przewodnika po konfiguracji](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up-pl-PL)**.

When no HTML is present (second case), this is even easier since you can just go to `Hidden texts` -> `Link addresses`.

---

![Crowdin 5](https://i.imgur.com/ZmgavCM.png)

---

여기에서 HTML 태그 없이 링크를 새로운 위치를 가리키도록 수정합니다.

---

![Crowdin 6](https://i.imgur.com/maG7kSm.png)

---

### 내부 링크

위키에서 문서의 특정 항목을 가리키는 내부 링크를 찾을 수 있습니다. 이러한 링크는 `#` 문자를 포함하는데, 이는 문서의 그 항목으로 이동하라고 웹브라우저에게 알려줍니다.

이것은 특별한 경우로, 이 링크들은 현재 문서 중 해당 항목의 이름을 기반으로 합니다. URL에 `-locale`을 추가하는 일반적 관례를 가진 URL들은 어디에서나 동작하지만, 해당 항목의 이름은 당신과 다른 사람들이 번역을 하므로 링크가 정확한 위치를 가리키도록 할 필요가 있습니다.

예를 들어 **[설정](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-ko-KR#소개)** 페이지에는 `#introduction` 링크가 있습니다:

---

![Crowdin 7](https://i.imgur.com/EEHSPtK.png)

---

우리는 "introduction"이라는 단어를 폴란드어 "Wprowadzenie"로 번역할 것이므로, 단어가 변경되면 링크가 작동을 멈추지 않도록 수정할 필요가 있습니다.

---

![Crowdin 8](https://i.imgur.com/JMJegO7.png)

---

이렇게 함으로써 내부 링크는 정상 작동하여 우리가 사용하는 항목의 이름을 가리킬 것입니다. HTML 태그 안에 있는 링크도 정확하게 동일한 방법으로 수정할 수 있습니다.

---

### 코드 블록

`<code></code>` 블록안에 있는 문장을 번역할 때는 매우 조심하십시오. 코드 블록은 번역하면 안되는 ASF의 고정된 코드 이름이나 용어를 가리킵니다. 예를 들면 다음과 같습니다:

> 이는 특히 등록할 키가 많고 전체를 다 등록하기 전에 <code>RateLimited</code>에 도달할 것이 확실한 경우에 유용합니다.

보다시피 위의 `RateLimited` 단어는 코드 블록 안에 있으며 ASF 내부 코드 상태를 가리키므로 번역되어서는 안됩니다. 마찬가지로 `TradingPreferences` 등 설정 항목의 이름, `UpdateChannel` 항목의 옵션값인 `Stable`과 `Experimental`과 같은 열거형 항목 등 다른 코드 블록도 번역해서는 안됩니다.

하지만, 이 단어들이 번역되어서는 안된다고해서 괄호등을 사용해서 적절한 번역을 그 옆에 넣어서는 안된다는 것은 아닙니다.

> Ta funkcja jest wyjątkowo użyteczna w przypadku aktywacji dużej ilości kluczy i gwarancji napotkania statusu <code>RateLimited</code> (zbyt częstej aktywacji) przed ukończeniem całej partii.

위에서 볼수 있듯이, 상태를 친절한 방법으로 번역하기 위해서 "너무 많은 등록"이라는 뜻의 "zbyt częstej aktywacji"를 `RateLimited` 옆에 추가했습니다. 동시에 프로그램을 사용하면서 사용자가 볼 수 있는 원본 ASF의 의미를 유지했습니다. 같은 방식으로 다른 비슷한 여러 단어와 문장을 번역하거나 설명할 수 있습니다.

만약 뭔가 부적절한 것이 코드 블록에 포함되었거나, 코드 블록 안에 있어야 하는 텍스트가 밖에 있다면 적절한 **[이슈](#이슈)**를 생성해서 Crowdin으로 문의해주시기 바랍니다. 위의 문장도 로컬 링크 사용의 실용적 예제입니다.

---

## 명예의 전당

더 나은 ASF 현지화를 위해 자신의 소중한 시간을 할애해준 사람들에게 영원한 감사를 전하고 싶습니다. 그들의 노력은 믿을 수 없는 것이고, 당신은 그들 덕에 위키를 포함한 완벽한 번역을 즐길 수 있습니다. As a token of appreciation, all people listed here are offered free access to **[`MatchActively`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin#matchactively)** feature upon a **[request](https://crowdin.com/messages/create/13177432/240376)**.

| 기여자                                                        | 언어              |
| ---------------------------------------------------------- | --------------- |
| **[Astaroth](https://crowdin.com/profile/astaroth2012)**   | LOLCAT, Spanish |
| **[Dead_Sam](https://crowdin.com/profile/Dead_Sam)**       | 포르투칼어(BR)       |
| **[deluxghost](https://crowdin.com/profile/deluxghost)**   | 중국어(CN)         |
| **[DragonTaki](https://crowdin.com/profile/dragontaki)**   | Chinese (TW)    |
| **[LittleFreak](https://crowdin.com/profile/littlefreak)** | 독일어             |
| **[Ryzhehvost](https://crowdin.com/profile/Ryzhehvost)**   | 러시아어와 우크라이나어    |
| **[MrBurrBurr](https://crowdin.com/profile/MrBurrBurr)**   | LOLCAT, German  |
| **[XinxingChen](https://crowdin.com/profile/XinxingChen)** | 중국어(HK)         |

ASF 현지화의 품질을 개선해주셔서 감사합니다!