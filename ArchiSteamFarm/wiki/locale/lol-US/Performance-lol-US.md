# PERFORMANCE

TEH PRIMARY OBJECTIV OV ASF IZ 2 FARM AS EFFECTIVELY AS POSIBLE, BASD ON 2 TYPEZ OV DATA IT CAN OPERATE ON - SMALL SET OV USR-PROVIDD DATA DAT IZ IMPOSIBLE 4 ASF 2 GUES/CHECK ON ITZ OWN, AN LARGR SET OV DATA WHICH CAN BE AUTOMATICALLY CHECKD BY ASF.

IN AUTOMATIC MODE, ASF DOEZ NOT ALLOW U 2 CHOOSE TEH GAMEZ DAT SHUD BE FARMD, NEITHR ALLOWS U 2 CHANGE CARDZ FARMIN ALGORITHM. **ASF KNOWS BETTR THAN U WUT IT SHUD DO AN WUT DECISHUNS IT SHUD MAK IN ORDR 2 FARM AS FAST AS POSIBLE**. UR OBJECTIV IZ 2 SET CONFIG PROPERTIEZ PROPERLY, AS ASF CANT GUES THEM ON ITZ OWN, EVRYTHIN ELSE IZ COVERD.

---

SUM TIEM AGO VALVE CHANGD TEH ALGORITHM 4 CARD DROPS. FRUM DAT POINT ONWARDZ, WE CAN KATEGORIZE STEAM ACCOUNTS BY 2 KATEGORIEZ: DOSE **WIF** CARD DROPS RESTRICTD, AN DOSE **WITHOUT**. TEH ONLY DIFFERENCE TWEEN DOSE 2 TYPEZ IZ TEH FACT DAT ACCOUNTS WIF RESTRICTD CARD DROPS CANT GIT ANY CARD FRUM GIVEN GAME TIL THEY PULAY GIVEN GAME 4 AT LEAST `X` HOURS. IT SEEMS DAT OLDR ACCOUNTS DAT NEVR ASKD 4 REFUND HAS **UNRESTRICTD CARD DROPS**, WHILE NEW ACCOUNTS AN DOSE HOO DID ASK 4 REFUND HAS **RESTRICTD CARD DROPS**. DIS AR TEH HOWEVR ONLY THEORY, AN SHUD NOT BE TAKEN AS RULE. THAZ Y THAR IZ **NO OBVIOUS ANZWR**, AN ASF RELIEZ ON **U** TELLIN IT WHICH CASE IZ APPROPRIATE 4 UR AKOWNT.

---

ASF CURRENTLY INCLUDEZ 2 FARMIN ALGORITHMS:

**`Simple`** ALGORITHM WERKZ BEST 4 ACCOUNTS DAT HAS UNRESTRICTD CARD DROPS. DIS AR TEH PRIMARY ALGORITHM USD BY ASF. BOT FINDZ GAMEZ 2 FARM, AN FARMS THEM WAN-BY-WAN TIL ALL CARDZ R DROPPD. DIS AR TEH CUZ CARD DROPS RATE WHEN FARMIN MOAR THAN WAN GAME IZ CLOSE 2 ZERO AN TOTALLY INEFFECTIV.

**`Complex`** IZ NEW ALGORITHM DAT HAS BEEN IMPLEMENTD 2 HALP RESTRICTD ACCOUNTS 2 MAXIMIZE THEIR PROFITS AS WELL. ASF WILL FIRSTLY USE STANDARD **`Simple`** ALGORITHM ON ALL GAMEZ DAT PASD `HoursUntilCardDrops` HOURS OV PLAYTIME, DEN, IF NO GAMEZ WIF >= `HoursUntilCardDrops` HOURS R LEFT, IT WILL FARM ALL GAMEZ (UP 2 `32` LIMIT) WIF < `HoursUntilCardDrops` HOURS LEFT SIMULTANEOUSLY, TIL ANY OV THEM HITS `HoursUntilCardDrops` HOURS MARK, DEN ASF WILL CONTINUE TEH LOOP FRUM BEGINNIN (USE **`Simple`** ON DAT GAME, RETURN 2 SIMULTANEOUS ON < `HoursUntilCardDrops` AN SO ON). WE CAN USE MULTIPLE GAMEZ FARMIN IN DIS CASE 4 BUMPIN HOURS OV TEH GAMEZ WE NED 2 FARM 2 APPROPRIATE VALUE FIRSTLY. KEEP IN MIND DAT DURIN FARMIN HOURS, ASF **DOEZ NOT** FARM CARDZ, SO IT ALSO WONT CHECK 4 ANY CARD DROPS DURIN DAT PERIOD (4 REASONS STATD ABOOV).

CURRENTLY, ASF CHOOSEZ CARDZ FARMIN ALGORITHM BASD PURELY ON `HoursUntilCardDrops` CONFIG PROPERTY (WHICH IZ  SET BY **U**). IF `HoursUntilCardDrops` IZ SET 2 `0`, **`Simple`** ALGORITHM WILL BE USD, OTHERWIZE, **`Complex`** ALGORITHM WILL BE USD INSTEAD — CONFIGURD 2 BUMP PLAYTIME IN ALL GAMEZ 2 GIVEN AMOUNT OV HOURS BEFORE FARMIN THEM 4 CARD DROPS.

---

### **THAR IZ NO OBVIOUS ANZWR WHICH ALGORITHM IZ BETTR 4 U**.

DIS AR TEH WAN OV TEH REASONS Y U DO NOT CHOOSE CARDZ FARMIN ALGORITHM, INSTEAD, U TELL ASF IF AKOWNT HAS RESTRICTD DROPS OR NOT. IF AKOWNT HAS NON-RESTRICTD DROPS, **`Simple`** ALGORITHM WILL **WERK BETTR** ON DAT AKOWNT, AS WE WONT BE WASTIN TIEM ON BRINGIN ALL GAMEZ 2 `X` HOURS - CARDZ DROP RATIO IZ CLOSE 2 0% WHEN FARMIN MULTIPLE GAMEZ. ON TEH OTHR HAND, IF UR AKOWNT HAS CARD DROPS RESTRICTD, **`Complex`** ALGORITHM WILL BE BETTR 4 U, AS THARS NO POINT IN FARMIN SOLO IF GAME DIDNT REACH `HoursUntilCardDrops` HOURS YET - SO WELL FARM **PLAYTIME** FURST, **DEN** CARDZ IN SOLO MODE.

DOAN BLINDLY SET `HoursUntilCardDrops` ONLY CUZ SOMEBODY TOLD U 2 - DO TESTS, COMPARE RESULTS, AN BASD ON DATA U GIT, DECIDE WHICH OPSHUN SHUD BE BETTR 4 U. IF U PUT SUM MINIMAL EFFORT INTO DAT, ULL ENSURE DAT ASF IZ WERKIN WIF MAXIMUM POSIBLE EFFICIENCY 4 UR AKOWNT, WHICH IZ PROBABLY WUT U WANTS, CONSIDERIN DAT URE READIN DIS WIKI PAEG RITE NAO. IF THAR WUZ SOLUSHUN DAT WERKZ 4 EVRYBODY, UD NOT BE GIVEN CHOICE - ASF WUD DECIDE ITSELF.

---

### WUT IZ TEH BEST WAI 2 FIND OUT IF UR AKOWNT IZ RESTRICTD?

MAK SURE U HAS SUM GAMEZ WIF **NO PLAYTIME RECORDD** 2 FARM, PREFERABLY 5+, AN RUN ASF WIF `HoursUntilCardDrops` OV `0`. IT WUD BE GUD IDEA IF U DIDNT PULAY ANYTHIN DURIN FARMIN PERIOD 4 MOAR ACCURATE RESULTS (BEST 2 RUN ASF DURIN TEH NITE). LET ASF FARM DOSE 5 GAMEZ, AN AFTR DAT CHECK OUT TEH LOG 4 RESULTS.

ASF CLEARLY STATEZ WHEN CARD 4 GIVEN GAME WUZ DROPPD. URE INTERESTD IN FASTEST CARD DROP ACHIEVD BY ASF. 4 EXAMPLE, IF UR AKOWNT IZ UNRESTRICTD DEN FURST CARD DROP SHUD HAPPEN AFTR AROUND 30 MINUTEZ SINCE U STARTD FARMIN. IF U NOTICE **AT LEAST WAN** GAME DAT DID DROP CARD IN DOSE INITIAL 30 MINUTEZ, DEN DIS AR TEH AN INDICATOR DAT UR AKOWNT IZ **NOT** RESTRICTD AN SHUD USE `HoursUntilCardDrops` OV `0`.

ON TEH OTHR HAND, IF U NOTICE DAT **EVRY** GAME IZ TAKIN AT LEAST `X` AMOUNT OV HOURS BEFORE IT DROPS ITZ FURST CARD, DEN DIS AR TEH AN INDICATOR 2 U WUT U SHUD SET `HoursUntilCardDrops` 2. MAJORITY (IF NOT ALL) OV RESTRICTD USERS REQUIRE AT LEAST `3` HOURS OV PLAYTIME 4 CARDZ 2 DROP, AN DIS AR TEH ALSO TEH DEFAULT VALUE 4 `HoursUntilCardDrops` SETTIN.

REMEMBR DAT GAMEZ CAN HAS DIFFERENT DROP RATE, DIS AR TEH Y U SHUD TEST IF UR THEORY IZ RITE WIF **AT LEAST** 3 GAMEZ, PREFERABLY 5+ 2 ENSURE DAT URE NOT RUNNIN INTO FALSE RESULTS BY COINCIDENCE. A CARD DROP OV WAN GAME IN LES THAN AN HOUR IZ CONFIRMASHUN DAT UR AKOWNT **IZ NOT** RESTRICTD AN CAN USE `HoursUntilCardDrops` OV `0`, BUT 4 CONFIRMIN DAT UR AKOWNT **IZ** RESTRICTD, U NED AT LEAST SEVERAL GAMEZ DAT R NOT DROPPIN CARDZ TIL U HIT FIXD MARK.

IZ IMPORTANT 2 NOWT DAT IN DA PAST `HoursUntilCardDrops` WUZ ONLY `0` OR `2`, AN DIS AR TEH Y ASF HAD SINGLE `CardDropsRestricted` PROPERTY DAT ALLOWD 2 SWITCH TWEEN DOSE 2 VALUEZ. WIF RESENT CHANGEZ WE NOTICD DAT NOT ONLY MAJORITY OV USERS REQUIRE `3` HOURS IN PLACE OV PREVIOUS `2` NAO, BUT ALSO DAT `HoursUntilCardDrops` IZ NAO DYNAMIC AN CAN HIT ANY VALUE ON PER-AKOWNT BASIS.

IN DA END, OV COURSE, DECISHUN IZ UP 2 U.

AN 2 MAK IT EVEN WORSE - I EXPERIENCD CASEZ WHEN PEEPS SWITCHD FRUM RESTRICTD 2 UNRESTRICTD STATE AN VICE VERSA - EITHR CUZ OV STEAM BUG (OH YA, WE HAS LOTZ DA OV DOSE), OR CUZ OV SUM LOGIC ADJUSTMENTS BY VALVE. SO EVEN IF U CONFIRMD DAT UR AKOWNT IZ RESTRICTD (OR NOT), DO NOT BLEEV DAT ITLL STAY LIEK DAT - IN ORDR 2 SWITCH FRUM UNRESTRICTD 2 RESTRICTD IZ ENOUGH 2 ASK 4 REFUND. IF U FEELZ LIEK PREVIOUSLY SET VALUE IZ NO LONGR APPROPRIATE, U CAN ALWAYS DO RE-TEST AN UPDATE IT ACCORDINGLY.

---

BY DEFAULT, ASF ASSUMEZ DAT `HoursUntilCardDrops` IZ `3`, AS TEH NEGATIV EFFECT OV SETTIN DIS 2 `3` WHEN IT SHUD BE LES IZ SMALLR THAN DUN TEH OTHR WAI. DIS AR TEH CUZ, OV TEH FACT DAT IN DA WURST POSIBLE CASE, WELL WASTE `3` HOURS OV FARMIN PER `32` GAMEZ, COMPARD 2 WASTIN `3` HOURS OV FARMIN PER EVRY SINGLE GAME IF `HoursUntilCardDrops` WUZ SET 2 `0` BY DEFAULT. HOWEVR, U SHUD STILL TUNE DIS VARIABLE 2 MATCH UR AKOWNT 4 MAXIMUM EFFICIENCY, AS DIS AR TEH ONLY BLIND GUES BASD ON POTENTIAL DRAWBACKZ AN MAJORITY OV USERS (SO WERE TRYIN 2 CHOOSE "LESR EVIL" BY DEFAULT).

AT TEH MOMENT 2 ABOOV ALGORITHMS R ENOUGH 4 ALL CURRENTLY POSIBLE AKOWNT SCENARIOS, IN ORDR 2 FARM AS EFFECTIVELY AS POSIBLE, THEREFORE IZ NOT PLANND 2 ADD ANY OTHR ONEZ.

IZ NICE 2 NOWT DAT ASF ALSO INCLUDEZ MANUAL FARMIN MODE DAT CAN BE ACTIVATD BY `play` COMMAND. U CAN READ MOAR BOUT IT IN **[COMMANDZ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-lol-US)**.

---

## STEAM GLITCHEZ

CARDZ DROP ALGORITHM DOEZ NOT ALWAYS WERK TEH WAI IT SHUD, AN IZ ENTIRELY POSIBLE 4 VARIOUS STEAM GLITCHEZ 2 HAPPEN, SUCH AS CARDZ BEAN DROPPD ON RESTRICTD ACCOUNTS, CARDZ BEAN DROPPD ON CLOSIN/SWITCHIN TEH GAME, CARDZ NOT DROPPIN AT ALL WHEN GAME IZ BEAN PLAYD, AN LIKEWIZE.

DIS SECSHUN IZ MAINLY 4 PEEPS DAT R WONDERIN Y ASF DOESNT DO **X**, SUCH AS RAPIDLY SWITCHIN GAMEZ 2 FARM CARDZ FASTR.

WUT IZ **STEAM GLITCH** - SPECIFIC ACSHUN TRIGGERIN **UNDEFIND** BEHAVIOUR, WHICH IZ **NOT INTENDD, UNDOCUMENTD, AN CONSIDERD AS LOGIC FLAW**. IZ **UNRELIABLE BY DEFINISHUN**, WHICH MEANZ DAT IT CANT BE REPRODUCD RELIABLY WIF CLEAN TESTIN ENVIRONMENT, AN THEREFORE, CODD WITHOUT RESORTIN 2 HACKZ DAT R SUPPOSD 2 GUES WHEN GLITCH IZ HAPPENIN AN HOW 2 FIGHT WIF IT / ABUSE IT. TYPICALLY IZ TEMPORARY TIL DEVELOPERS FIX TEH LOGIC FLAW, ALTHOUGH SUM MISC GLITCHEZ CAN GO UNNOTICD 4 VRY LONG PERIOD OV TIEM.

A GUD EXAMPLE OV WUT IZ CONSIDERD AS **STEAM GLITCH** IZ NOT DAT UNCOMMON SITUASHUN OV DROPPIN CARD WHEN GAME IZ BEAN CLOSD, WHICH CAN BE ABUSD 2 SUM DEGREE WIF IDLE MASTAHS GAME SKIP FUNCSHUN.

- **UNDEFIND BEHAVIOUR** - U CANT SAY IF THAR WILL BE 0 OR 1 CARDZ BEAN DROPPD WHEN U TRIGGR TEH GLITCH.
- **NOT INTENDD** - BASD ON PAST EXPERIENCE AN BEHAVIOUR OV STEAM NETWORK DAT DOESNT RESULT IN SAME BEHAVIOUR WHEN SENDIN SINGLE REQUEST.
- **UNDOCUMENTD** - IZ CLEARLY DOCUMENTD ON STEAM WEBSIET HOW CARDZ R BEAN OBTAIND, AN **IN EVRY SINGLE PLACE** IZ CLEARLY STATD DAT IZ OBTAIND THRU **PLAYIN**, NOT CLOSIN GAMEZ, GETTIN ACHIEVEMENTS, GAMEZ SWITCHIN OR LAUNCHIN 32 GAMEZ CONCURRENTLY.
- **CONSIDERD AS LOGIC FLAW** - CLOSIN GAME(S) OR SWITCHIN THEM SHUD HAS NO OUTCOME ON CARDZ BEAN DROPPD WHICH R CLEARLY STATD 2 BE OBTAIND THRU **GAININ PLAYTIME**.
- **UNRELIABLE BY DEFINISHUN, CANT BE REPRODUCD RELIABLY** - IT DOESNT WERK 4 EVRYBODY, AN EVEN IF IT DID WERK 4 U ONCE, IT CUD NO LONGR WERK 4 DA SECOND TIEM.

NAO ONCE WE REALIZD WUT STEAM GLITCH IZ, AN TEH FACT DAT CARDZ BEAN DROPPD WHEN GAME GETS CLOSD **IZ** WAN, WE CAN MOOV ON 2 TEH SECOND POINT - **ASF IZ NOT ABUSIN STEAM NETWORK IN ANY WAI BY DEFINISHUN, AN IZ DOIN ITZ BEST 2 COMPLY WIF STEAM TOS, ITZ PROTOCOLS AN WUT IZ GENERALLY ACCEPTD**. SPAMMIN STEAM NETWORK WIF CONSTANT GAME OPENIN/CLOSIN REQUESTS CAN BE CONSIDERD **[DOS ATTACK](https://en.wikipedia.org/wiki/Denial-of-service_attack)** AN **DIRECTLY VIOLATEZ [STEAM ONLINE CONDUCT](https://store.steampowered.com/online_conduct/?l=english)**.

> AS STEAM SUBSCRIBR U AGREE 2 ABIDE BY TEH FOLLOWIN CONDUCT RULEZ.
> 
> U WILL NOT:
> 
> INSTITUTE ATTACKZ UPON STEAM SERVR OR OTHERWIZE DISRUPT STEAM.

IT DOESNT MATTR WHETHR URE ABLE 2 TRIGGR STEAM GLITCH WIF OTHR PROGRAMS (SUCH AS IM), AN IT ALSO DOESNT MATTR IF U AGREE WIF US AN CONSIDR SUCH BEHAVIOUR AS DOS ATTACK, OR NOT - IZ UP 2 VALVE 2 JUDGE DIS, BUT IF WE CONSIDR IT AS EXPLOITIN/ABUSIN NON-INTENDD BEHAVIOUR THRU EXCESIV STEAM NETWORK REQUESTS, DEN U CAN BE PRITEE SURE DAT VALVE WILL HAS SIMILAR VIEW ON DIS.

ASF IZ **NEVR** GOIN 2 TAEK ADVANTAGE OV STEAM EXPLOITS, ABUSEZ, HACKZ OR ANY OTHR ACTIVITY DAT WE C AS **ILLEGAL OR UNWANTD** ACCORDIN 2 STEAM TOS, STEAM ONLINE CONDUCT OR ANY OTHR TRUSTD SOURCE DAT CUD INDICATE DAT ASF ACTIVITY IZ UNWANTD BY STEAM NETWORK, AS STATD IN **[CONTRIBUTIN](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/.github/CONTRIBUTING.md)** SECSHUN.

IF U WANTS AT ALL COST 2 RISK UR STEAM AKOWNT 4 FARMIN FEW SENT CARDZ FASTR THAN USUAL, DEN SADLY ASF WILL NEVR OFFR SOMETHIN LIEK DIS IN AUTOMATIC MODE, ALTHOUGH U STILL HAS `play` **[COMMAND](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-lol-US)** DAT CAN BE USD AS TOOL 4 DOIN WHATEVR U WANTS IN TERMS OV STEAM NETWORK INTERACSHUN. WE DO NOT RECOMMEND TAKIN ADVANTAGE OV STEAM GLITCHEZ AN EXPLOITIN THEM 4 UR OWN GAIN - NOT ONLY WIF ASF, BUT WIF ANY OTHR TOOL AS WELL. IN DA END HOWEVR, IZ UR AKOWNT, AN UR CHOICE WUT U WANTS 2 DO WIF IT - JUS KEEP IN MIND DAT WE WARND U.