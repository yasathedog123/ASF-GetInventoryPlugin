# Steam 가족 공유

ASF supports Steam Family Sharing - in order to understand how ASF works with that, you should firstly read how **[Steam Family Sharing works](https://store.steampowered.com/promotion/familysharing)**, which is available on Steam store.

---

## ASF

ASF의 Steam 가족 공유 기능 지원은 투명합니다. 즉, 어떠한 새로운 bot/프로세스 설정 항목이 없으며 추가적인 붙박이 기능으로서 ASF의 외부에서 작동합니다.

ASF는 가족 공유 이용자가 라이브러리를 사용하고 있는지 판단하기 위한 적절한 로직을 포함하고 있으며, 게임 실행시 플레이 중인 세션에서 "쫓아내지" 않을 것입니다. ASF는 주 계정이 플레이중인것처럼 정확히 똑같이 동작하므로, Steam 클라이언트가 플레이중이거나 가족 공유 이용자가 플레이중이라면 ASF는 농사를 시도하지 않고 플레이가 끝날때까지 기다립니다.

In addition to above, after logging in, ASF will access your **[family sharing settings](https://store.steampowered.com/account/managedevices)**, from which it'll extract up to 5 `steamIDs` allowed to use your library. 이 이용자들은 `FamilySharing` 권한을 받아 **[명령어](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-ko-KR)**를 이용할 수 있으며, 공유가능한 게임을 실행하기 위하여 게임을 공유하는 봇 계정에 `pause~` 명령으로 자동 카드 농사 모듈을 일시 정지할 수 있습니다.

Connecting both functionalities described above allows your friends to `pause~` your cards farming process, start a game, play as long as they wish, and then after they're done playing, cards farming process will be automatically resumed by ASF. 물론 ASF가 농사중이 아니라면 `pause~`의 사용은 필요하지 않습니다. 당신의 친구들은 게임을 즉시 실행할 수 있고 위에서 설명한 로직은 그들을 쫓아내지 않을 것입니다.

---

## 한계

Steam 네트워크는 잘못된 상태 업데이트를 보내서 ASF가 오해하는 것을 좋아합니다. ASF는 농사를 재개해도 좋다고 믿을 것이고, 그 결과 당신의 친구를 너무 빨리 쫓아낼 것입니다. 이것은 **[이 자주묻는 질문 항목](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ-ko-KR#asf-is-kicking-my-steam-client-session-while-im-playing--this-account-is-logged-on-another-pc)** 에 설명된 것과 정확하게 동일한 이슈입니다. We recommend exactly the same solutions, mainly promoting your friends to `Operator` permission (or above) and telling them to make use of `pause` and `resume` commands.