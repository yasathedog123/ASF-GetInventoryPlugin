# 백그라운드 게임 등록기

백그라운드 게임 등록기는 ASF의 특별한 내장기능으로, 주어진 Steam 키(와 이름)의 집합을 불러오고 백그라운드에서 등록할 수 있게 합니다. 이 기능은 특히 등록할 키가 많아서 전체 키 등록완료 전에 `RateLimited` **[상태](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ-ko-KR#키를-등록할때-나오는-상태의-의미가-뭔가요)** 가 될 것이 확실한 경우 유용합니다.

백그라운드 게임 등록기는 한개의 봇 범위를 갖도록 만들어졌으며, `RedeemingPreferences`를 이용하지 않습니다. 이 기능은 필요하다면 `redeem` **[명령어](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** 와 함께 혹은 대신해서 사용할 수 있습니다.

---

## 불러오기

불러오기는 파일과 IPC의 두가지 방법이 있습니다.

### 파일

ASF는 `config` 디렉토리의 `BotName.keys`라는 파일을 인식합니다. 이때 `BotName`은 사용하는 봇의 이름입니다. 이 파일은 게임의 이름과 키가 탭 문자로 서로 구분되고 줄바꿈으로 끝나는 고정된 구조를 가지고 있어야 합니다. 탭이 여러개 있다면 첫번째 항목은 게임의 이름으로, 마지막 항목은 키로 간주되며, 중간의 모든 것은 무시됩니다. 예를 들면 다음과 같습니다:

```text
POSTAL 2    ABCDE-EFGHJ-IJKLM
Domino Craft VR 12345-67890-ZXCVB
A Week of Circus Terror POIUY-KJHGD-QWERT
Terraria    무시됩니다   이것도무시됩니다    ZXCVB-ASDFG-QWERT
```

대신, 키만 있는 형식을 사용할 수도 있습니다. 각 항목은 줄바꿈으로 구분됩니다. 이 경우 ASF는 정확한 이름을 채워넣기 위해 가능하다면 Steam의 응답을 사용합니다. Steam에 등록되는 패키지는 활성화 되는 게임의 논리를 따를 필요가 없기 때문에 어떤 종류의 키 태그던지 키에 이름을 직접 붙여주는 것을 권장합니다. 개발자가 넣어주는 것에 따라 정확한 게임이름을 볼 수도 있고 Humble Indie Bundle 18 같은 지정된 패키지 이름, 또는 Half-Life 4같은 완전히 잘못되었거나 잠재적으로 악의적인 이름이 나타날 수도 있습니다.

```text
ABCDE-EFGHJ-IJKLM
12345-67890-ZXCVB
POIUY-KJHGD-QWERT
ZXCVB-ASDFG-QWERT
```

사용하기로 한 형식과 상관없이 ASF는 봇 시작시나 이후의 실행동안 `키` 파일을 불러올 것입니다. 파일의 구문분석과 잘못된 항목의 생략이 끝나면 정상적으로 감지된 게임이 백그라운드 대기열에 추가되며, `BotName.keys` 파일은 `config` 디렉토리에서 삭제됩니다.

### IPC

위에서 언급한 키 파일을 이용하는 방법과 함께, ASF는 ASF-ui를 포함한 어떠한 IPC 도구에서도 실행가능한 `GamesToRedeemInBackground` **[ASF API 끝점](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-ko-KR#asf-api)**을 제공합니다. IPC를 사용하면 탭 문자 대신 사용자 지정 구분기호를 사용하여 적절한 구문분석을 직접 할 수 있거나, 완전히 사용자화된 자신만의 키 구조를 사용할 수 있는 등 더 강력합니다.

---

## 대기열

게임을 성공적으로 불러오면 대기열에 추가됩니다. ASF는 봇이 Steam 네트워크에 연결되어있고 대기열이 비어있지 않는 한 계속 백그라운드 대기열을 검토합니다. 등록을 시도하고 `RateLimited` 결과가 나오지 않은 키는 대기열에서 삭제됩니다. 결과는 `config` 디렉토리에 파일로 저장됩니다. `NoDetail`, `BadActivationCode`, `DuplicateActivationCode` 등 키를 사용한 경우`BotName.keys.used` 파일에, 그 외의 경우 `BotName.keys.unused` 에 저장됩니다. Steam 네트워크는 키에 대해 의미있는 게임이름의 회신을 보장하지 않기 때문에 ASF는 사용자가 입력한 게임 이름을 사용합니다. 이렇게 해서 필요하거나 원하는 경우 사용자 지정이름을 사용해서 키를 태그지정할 수 있습니다.

이 과정에서 계정이 `RateLimited` 상태가 되면 쿨다운이 사라지기를 기다리기 위해서 대기열이 임시로 한시간동안 정지됩니다. Afterwards, the process continues where it left, until the entire queue is empty or another `RateLimited` occurs.

---

## 예시

100개의 키 목록이 있다고 가정합시다. 첫번째로 ASF `config` 디렉토리에 `BotName.keys.new` 파일을 새로 만들어야 합니다. 빈 파일이어서 불러오기를 하면 안되므로, ASF가 파일이 생성되자마자 가져가면 안된다는 것을 알려주기 위해서 파일에 `.new` 확장자를 붙였습니다.

이제 파일을 열어서 100개의 키를 여기에 복사-붙여넣기 합니다. 필요하다면 형식도 수정합니다. 수정을 하고 나면 `BotName.keys.new` 파일은 정확하게 100줄(혹은 마지막 줄바꿈으로 101줄)이고, 모든 줄은 `게임이름\t키\n`의 구조로 되어있을 것입니다. 여기에서 `\t`는 탭 문자를, `\n`는 줄바꿈을 의미합니다.

이제 ASF가 가져가도 된다는 것을 알려주기 위해서 `BotName.keys.new` 파일을 `BotName.keys` 으로 이름을 바꿀 준비가 됐습니다. 이름을 바꾸는 순간, ASF는 재시작 없이 자동으로 파일을 불러오고 모든 게임이 구문분석되어 대기열에 추가되면 파일을 삭제합니다.

`BotName.keys` 파일을 사용하는 대신 IPC API 끝점을 사용하거나, 원한다면 두 경우를 조합할 수도 있습니다.

시간이 좀 지나면 `BotName.keys.used`와 `BotName.keys.unused` 파일이 생성될 것입니다. 이 파일들은 등록 결과를 담고 있습니다. 예를 들어, `BotName.keys.unused`를 `BotName2.keys` 파일로 이름을 바꿀 수 있습니다. 그렇게 되면 첫번째 봇이 사용하지 않은 키를 다른 봇에 제공하게 됩니다. 혹은 미사용 키를 다른 파일에 복사-붙여넣기 해서 보관해 둘 수도 있습니다. 하기 나름입니다. ASF는 대기열을 계속 검토하며, 새 항목이 `used`와 `unused` 파일에 추가됩니다. 따라서 이 파일들을 사용하기 전에 대기열에 완전히 빌때까지 기다리는 것을 추천합니다. 만약 대기열이 완전히 비기 전에 저 파일에 접근해야만 한다면, 먼저 결과물 파일을 다른 디렉토리 등으로 **이동**하고, **그다음에** 구문 분석하십시오. ASF는 당신이 작업을 하는 동안에도 새로운 결과를 파일에 추가하기 때문에 키 일부의 손실이 생길 수 있습니다. 예를 들면 당신이 키가 3개 들어있는 파일을 읽은 후 삭제 했습니다. 하지만 그동안 ASF는 당신이 삭제한 파일에 4개의 다른 키를 추가하였다는 사실을 놓쳐버렸습니다. 저 파일들에 접근하고 싶다면 파일을 읽기 전에 ASF `config` 디렉토리에서 다른 곳으로 옮기십시오. 혹은 이름을 바꿔도 됩니다.

대기열에 게임이 있을 때에도 위에서 설명한 단계를 반복하면 게임을 추가하는 것이 가능합니다. ASF는 이미 진행중인 대기열에 정상적으로 게임을 추가하여 처리할 것입니다.

---

## 비고

백그라운드 키 등록기는 `OrderedDictionary`를 사용합니다. 즉, 파일이나 IPC API 호출에 명시된 순서대로 키의 순서도 유지됩니다. 이것은, 한 키는 목록에서 그보다 위에 있는 키에 직접 종속성을 가진다는 것을 의미합니다. 하지만 목록의 아래에 있는 키에는 해당하지 않습니다. 예를 들어 게임 `G`를 먼저 활성화 해야하는 DLC `D`가 있다고 가정할 때, 게임 `G`가 **항상** DLC `D`보다 앞쪽에 있어야 한다는 뜻입니다. 마찬가지로, DLC `D`가 `A`, `B`, `C`에 종속되어 있다면, 3개 모두가 앞쪽에 있어야 합니다.(3개가 서로 종속성이 없다면 순서는 상관없음)

위 내용을 따르지 않는다면 전체 대기열을 검토한 뒤에는 활성화가 가능함에도 불구하고 DLC가 `DoesNotOwnRequiredApp` 상태가 되어 활성화되지 않는 결과를 초래합니다. 이런 상황을 피하고 싶다면 DLC는 항상 기본게임의 뒤에 있도록 하여야 합니다.