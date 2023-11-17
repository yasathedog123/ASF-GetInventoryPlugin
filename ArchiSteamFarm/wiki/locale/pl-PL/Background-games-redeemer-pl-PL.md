# Aktywacja gier w tle

Aktywacja kluczy w tle jest specjalną, wbudowaną funkcją ASF która pozwala na importowanie dużej ilości kluczy (wraz z ich nazwami) które zostaną aktywowane na danym koncie. To jest szczególnie przydatne gdy masz dużą kluczy do aktywowania na raz i wiesz że osiągniesz **[stan](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#what-is-the-meaning-of-status-when-redeeming-a-key)** `RateLimited` zanim aktywują się wszystkie.

Funkcja aktywacji kluczy w tle została napisana żeby się wykonała w jednej pętli, co powoduje, że nie korzysta z `RedeemingPreferences`. Można używać razem (lub zamians) **[polecenia](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** `redeem`.

---

## Importowanie

Proces importowania może odbyć się na dwa sposoby - poprzez plik, lub IPC.

### Plik

ASF rozpozna w katalogu `config` plik o nazwie `BotName.keys`, gdzie `BotName` jest nazwą bot. Ten plik ma oczekuje i stałej struktury nazwa gry z cd-key, oddzielone od siebie znakiem tabulacji i kończy znakiem nowej linii, aby wskazać następnego wpisu. Jeśli wiele kart są używane, a następnie pierwszy wpis jest uważana za nazwę gry, ostatni wpis jest uważany za cd-key i wszystko pomiędzy nimi jest ignorowana. Na przykład:

```text
POCZTOWY 2 ABCDE-EFGHJ-IJKLM
Domino Craft VR 12345-67890-ZXCVB
A tydzień cyrk grozy POIUY-KJHGD-QWERT
Terraria ThisIsIgnored ThisIsIgnoredToo    ZXCVB-ASDFG-QWERT
```

Alternatywnie również jesteśmy w stanie użyć klawiszy tylko format (nadal z nowej linii między każdego wpisu). ASF w tym przypadku użyje odpowiedzi Steam (jeśli to możliwe), aby wypełnić właściwą nazwę. W przypadku wszelkiego rodzaju tagowania kluczy zalecamy, abyś sam nadawał nazwy kluczom, ponieważ pakiety aktywowane na Steam nie muszą być zgodne z logiką gier, które aktywują. Więc w zależności od tego, co ustawił wydawca, możesz zobaczyć poprawną grę nazwy, niestandardowe nazwy pakietów (np. Humble Indie Bundle 18) lub wręcz błędne i potencjalnie nawet złośliwe (np. Half-Life 4).

```text
ABCDE-EFGHJ-IJKLM
12345-67890-ZXCVB
POIUY-KJHGD-QWERT
ZXCVB-ASDFG-QWERT
```

Bez względu na to, w jakim formacie zdecydowałeś się trzymać, ASF zaimportuje twoje klucze ` </ 0>, zarówno podczas uruchamiania bota, jak i później w trakcie jego wykonywania. Po pomyślnym przeanalizowaniu pliku i ewentualnym pominięciu nieprawidłowych wpisów, wszystkie poprawnie wykryte gry zostaną dodane do kolejki tła, a sam plik <code> BotName.keys </ 0> zostanie usunięty z <code> config </ 0 > katalog.</p>

<h3 spaces-before="0">IPC</h3>

<p spaces-before="0">Oprócz użycia wspomnianego wcześniej pliku kluczy, ASF udostępnia również <GamesToRedeemInBackground </ 0> <strong x-id="1"><a href="https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#asf-api"> punkt końcowy API ASF </ 1>, który może być wykonywany przez dowolne narzędzie IPC, w tym nasz ASF-ui. Używanie IPC może być znacznie potężniejsze, ponieważ możesz sam dokonać właściwego analizowania, na przykład użyć niestandardowego ogranicznika zamiast być zmuszonym do wstawiania znaków tabulacji, lub nawet wprowadzać całkowicie własną niestandardową strukturę klawiszy.</p>

<hr />

<h2 spaces-before="0">Kolejka</h2>

<p spaces-before="0">Pomyślnie zaimportowane gry są dodawane do kolejki. ASF automatycznie przechodzi przez kolejkę tła, dopóki bot jest podłączony do sieci Steam, a kolejka nie jest pusta. Klucz, który próbował zostać wykorzystany i nie spowodował ograniczenia <code> RateLimited </ 0>, został usunięty z kolejki, a jego status został poprawnie zapisany w pliku w katalogu <code> config </ 0> - <code> BotName.keys.used </ 0> jeśli klucz został użyty w procesie (np. <code> BrakDetaila </ 0>, <code> Kod BadActivation </ 0>, <code> DuplicateActivationCode </ 0>) lub <0 > BotName.keys.unused </ 0> inaczej. ASF celowo używa podanej nazwy gry, ponieważ nie ma gwarancji, że kluczowa nazwa zostanie zwrócona przez sieć Steam - w ten sposób możesz oznaczyć klucze używając nawet niestandardowych nazw, jeśli są potrzebne / poszukiwane.</p>

<p spaces-before="0">Jeśli podczas procesu nasze konto osiągnie status <code> RateLimited </ 0>, kolejka zostanie tymczasowo zawieszona na pełną godzinę, aby czekać na zakończenie czasu odnowienia. Afterwards, the process continues where it left, until the entire queue is empty or another <code>RateLimited` occurs.

---

## Przykład

Załóżmy, że masz listę 100 kluczy. Po pierwsze należy utworzyć nowy plik `BotName.keys.new` w katalogu `config` ASF. Możemy dołączane `nowe` rozszerzenie w celu niech ASF, wiem, że to nie powinien odebrać ten plik natychmiast w chwili, gdy jest tworzony (jak to jest nowy pusty plik, nie jest gotowy do importu, jeszcze).

Teraz można otworzyć nasz nowy plik i Kopiuj Wklej listę naszych 100 kluczy, ustalające format, w razie potrzeby. Po poprawki nasz plik `BotName.keys.new` będzie miał dokładnie 100 (lub 101, z ostatni znak nowego wiersza) wierszy, każdy wiersz o strukturze `GameName\tcd-key\n`, gdzie `\t` jest znak tabulacji i `\n` jest znak nowego wiersza.

Teraz jesteś gotowy, aby zmienić nazwę tego pliku od `BotName.keys.new` do `BotName.keys` w celu niech ASF, wiem, że jest on gotowy do odbioru. W chwili, gdy to zrobisz, ASF automatycznie importować plik (bez konieczności ponownego uruchomienia komputera) i usunąć go później, potwierdzając, że wszystkie nasze gry były analizowane i dodane do kolejki.

Zamiast przy użyciu pliku `BotName.keys`, można również użyć IPC API punktu końcowego, lub nawet połączenie obu Jeśli chcesz.

Po pewnym czasie pliki `BotName.keys.used` i `BotName.keys.nieużywane` zostaną wygenerowane. Te pliki zawierają wyniki naszego procesu wymiany. Na przykład, możesz zmienić nazwę pliku ` BotName.keys.unused </ 0> na plik <code> BotName2.keys </ 0>, a następnie przesłać nasze nieużywane klucze do innego bota, ponieważ poprzedni bot nie użył te klucze sam. Lub możesz po prostu skopiować i wkleić nieużywane klucze do jakiegoś innego pliku i zachować go na później, twój telefon. Należy pamiętać, że gdy ASF przechodzi przez kolejkę, nowe wpisy zostaną dodane do naszych wyjściowych <code> używanych </ 0> i <code> nieużywanych </ 0> plików, dlatego zaleca się, aby poczekać na pełne opróżnienie kolejki zanim skorzystasz z nich. Jeśli bezwzględnie musisz uzyskać dostęp do tych plików przed całkowitym opróżnieniem kolejki, powinieneś najpierw <strong x-id="1"> przenieść </ 0> plik wyjściowy, do którego chcesz uzyskać dostęp do innego katalogu, <strong x-id="1"> następnie </ 0> go przeanalizować. Dzieje się tak dlatego, że ASF może dodawać nowe wyniki, gdy robisz coś, co może prowadzić do utraty niektórych kluczy, jeśli czytasz plik zawierający np. 3 klucze wewnątrz, a następnie usuń je, całkowicie pomijając fakt, że ASF dodał 4 inne klucze do usuniętego pliku w międzyczasie. Jeśli chcesz uzyskać dostęp do tych plików, upewnij się, że zostały przeniesione z katalogu ASF <code> config </ 0> przed ich odczytaniem, na przykład przez zmianę nazwy.</p>

<p spaces-before="0">Możliwe jest również dodanie dodatkowych gier do zaimportowania, podczas gdy niektóre gry są już w naszej kolejce, powtarzając wszystkie powyższe kroki. ASF poprawnie doda nasze dodatkowe wpisy do już trwającej kolejki i ostatecznie sobie z tym poradzi.</p>

<hr />

<h2 spaces-before="0">Uwagi</h2>

<p spaces-before="0">Aktywator kluczy w tle używa <code>OrderedDictionary` co oznacza, że twoje klucze zachowają porządek, tak jak zostały określone w pliku (lub wywołane API / IPC). Oznacza to, że możesz (i powinieneś) podać listę, gdzie dany klucz może mieć tylko bezpośrednie zależności od wymienionych powyżej kluczy, ale nie poniżej. Na przykład oznacza to, że jeśli masz DLC `D`, który wymaga aktywacji gry `G`, to klucz dla gry `G` powinien być **zawsze** dołączony przed kluczem dla DLC `D`. Podobnie, jeśli DLC `D` miałoby zależności od `A`, `B` oraz `C`, wtedy wszystkie 3 powinny być uwzględnione wcześniej (w dowolnej kolejności, chyba że mają własne zależności).

Nieprzestrzeganie powyższego schematu spowoduje, że twoje DLC nie zostanie aktywowane za pomocą `DoesNotOwnRequiredApp`, nawet jeśli twoje konto będzie kwalifikowało się do aktywacji po przejściu przez całą kolejkę. Jeśli chcesz tego uniknąć, musisz upewnić się, że twoje DLC jest zawsze w kolejce po grze której wymaga.