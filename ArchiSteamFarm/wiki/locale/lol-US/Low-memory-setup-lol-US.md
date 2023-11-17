# LOW-MEMS SETUP

DIS AR TEH EGSAKT OPPOSIET OV **[HIGH-PERFORMANCE SETUP](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/High-performance-setup-lol-US)** AN TYPICALLY U WANTS 2 FOLLOW DOSE TIPS IF U WANTS 2 DECREASE ASFS MEMS USAGE, 4 COST OV LOWERIN OVERALL PERFORMANCE.

---

ASF IZ EXTREMELY LIGHTWEIGHT ON RESOURCEZ BY DEFINISHUN, DEPENDIN ON UR USAGE EVEN 128 MB VPS WIF LINUX IZ CAPABLE OV RUNNIN IT, ALTHOUGH GOIN DAT LOW IZ NOT RECOMMENDD AN CAN LEAD 2 VARIOUS ISSUEZ. WHILE BEAN LIGHT, ASF IZ NOT AFRAID OV ASKIN OS 4 MOAR MEMS, IF SUCH MEMS IZ NEEDD 4 ASF 2 OPERATE WIF OPTIMAL SPED.

ASF AS AN APPLICASHUN TRIEZ 2 BE AS MUTCH OPTIMIZD AN EFFICIENT AS POSIBLE, WHICH ALSO TAKEZ IN MIND RESOURCEZ BEAN USD DURIN EXECUSHUN. WHEN IT COMEZ 2 MEMS, ASF PREFERS PERFORMANCE OVAR MEMS CONSUMPSHUN, WHICH CAN RESULT IN TEMPORARY MEMS "SPIKEZ", DAT CAN BE NOTICD E.G. WIF ACCOUNTS HAVIN 3+ BADGE PAGEZ, AS ASF WILL FETCH AN PARSE FURST PAEG, READ FRUM IT TOTAL NUMBR OV PAGEZ, DEN LAUNCH FETCH TASK 4 EVRY EXTRA PAEG, WHICH RESULTS IN CONCURRENT FETCHIN AN PARSIN OV REMAININ PAGEZ. DAT "EXTRA" MEMS USAGE (COMPARD 2 BARE MINIMUM 4 OPERASHUN) CAN DRAMATICALLY SPED UP EXECUSHUN AN OVERALL PERFORMANCE, 4 DA COST OV INCREASD MEMS USAGE DAT IZ NEEDD 2 DO ALL OV DOSE THINGS IN PARALLEL. SIMILAR TING IZ HAPPENIN 2 ALL OTHR GENERAL ASF TASKZ DAT CAN BE RUN IN PARALLEL, E.G. WIF PARSIN ACTIV TRADE OFFERS, ASF CAN PARSE ALL OV THEM AT ONCE, AS THEYRE ALL INDEPENDENT OV EACH OTHR. ON TOP OV DAT, ASF (C# RUNTIME) WILL **NOT** RETURN UNUSD MEMS BAK 2 OS IMMEDIATELY AFTERWARDZ, WHICH U CAN QUICKLY NOTICE IN FORM OV ASF PROCES ONLY TAKIN MOAR AN MOAR MEMS, BUT (ALMOST) NEVR GIVIN DAT MEMS BAK 2 TEH OS. SUM PEEPS CUD ALREADY FIND IT QUESHUNABLE, MAYBE EVEN SUSPECT MEMS LEAK, BUT DOAN WORRY, ALL OV DIS AR TEH 2 BE EXPECTD.

ASF IZ EXTREMELY WELL OPTIMIZD, AN MAKEZ USE OV AVAILABLE RESOURCEZ AS MUTCH AS POSIBLE. HIGH MEMS USAGE OV ASF DOESNT MEEN DAT ASF ACTIVELY **USEZ** DAT MEMS AN **NEEDZ IT**. VRY OFTEN ASF WILL KEEP ALLOCATD MEMS AS "ROOM" 4 FUCHUR ACSHUNS, CUZ WE CAN DRASTICALLY IMPROOOV PERFORMANCE IF WE DOAN NED 2 ASK OS 4 EVRY MEMS CHUNK DAT WERE BOUT 2 USE. TEH RUNTIME SHUD AUTOMATICALLY RELEASE UNUSD ASF MEMS BAK 2 OS WHEN OS WILL **TRULY** NED IT. **[UNUSD MEMS IZ WASTD MEMS](https://www.howtogeek.com/128130/htg-explains-why-its-good-that-your-computers-ram-is-full)**. U RUN INTO ISSUEZ WHEN TEH MEMS U **NED** IZ HIGHR THAN TEH MEMS DAT IZ AVAILABLE 4 U, NOT WHEN ASF KEEPS SUM EXTRA ALLOCATD WIF PURPOSE OV SPEEDIN UP FUNCSHUNS DAT WILL EXECUTE IN MOMENT. U RUN INTO PROBLEMS WHEN UR LINUX KERNEL IZ KILLIN ASF PROCES DUE 2 OOM (OUT OV MEMS), NOT WHEN U C ASF PROCES AS TOP MEMS CONSUMR IN `htop`.

**[GARBAGE COLLECSHUN](https://en.wikipedia.org/wiki/Garbage_collection_(computer_science))** PROCES USD IN ASF IZ VRY COMPLEX MECHANISM, SMART ENOUGH 2 TAEK INTO AKOWNT NOT ONLY ASF ITSELF, BUT ALSO UR OS AN OTHR PROCESEZ. WHEN U HAS LOT OV FREE MEMS, ASF WILL ASK 4 WHATEVR IZ NEEDD 2 IMPROOOV TEH PERFORMANCE. ITSELF, BUT ALSO UR OS AN OTHR PROCESEZ. DIS CAN BE EVEN AS MUTCH AS 1 GB (WIF SERVR GC). WHEN UR OS MEMS IZ CLOSE 2 BEAN FULL, ASF WILL AUTOMATICALLY RELEASE SUM OV IT BAK 2 TEH OS 2 HALP THINGS SETTLE DOWN, WHICH CAN RESULT IN OVERALL ASF MEMS USAGE AS LOW AS 50 MB. TEH DIFFERENCE TWEEN 50 MB AN 1 GB IZ HUGE, BUT SO IZ TEH DIFFERENCE TWEEN SMALL 512 MB VPS AN HUGE DEDICATD SERVR WIF 32 GB. IF ASF CAN GUARANTEE DAT DIS MEMS WILL COME USEFUL, AN AT TEH SAME TIEM NOTHIN ELSE REQUIREZ IT RITE NAO, ITLL PREFR 2 KEEP IT AN AUTOMATICALLY OPTIMIZE ITSELF BASD ON ROUTINEZ DAT WUZ EXECUTD IN DA PAST. TEH GC USD IN ASF IZ SELF-TUNIN AN WILL ACHIEVE BETTR RESULTS TEH LONGR TEH PROCES IZ RUNNIN.

DIS AR TEH ALSO Y ASF PROCES MEMS VARIEZ FRUM SETUP 2 SETUP, AS ASF WILL DO ITZ BEST 2 USE AVAILABLE RESOURCEZ IN **AS EFFICIENT WAI AS POSIBLE**, AN NOT IN FIXD WAI LIEK IT WUZ DUN DURIN WINDOWS XP TIEMS. TEH AKSHUL (REAL) MEMS USAGE DAT ASF IZ USIN CAN BE VERIFID WIF `stats` **[COMMAND](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-lol-US)**, AN IZ USUALLY AROUND 4 MB 4 JUS FEW BOTS, UP 2 30 MB IF U USE STUFF LIEK **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-lol-US)** AN OTHR ADVANCD FEATUREZ. KEEP IN MIND DAT MEMS RETURND BY `stats` COMMAND ALSO INCLUDEZ FREE MEMS DAT HASNT BEEN RECLAIMD BY GARBAGE COLLECTOR YET. EVRYTHIN ELSE IZ SHARD RUNTIME MEMS (AROUND 40-50 MB) AN ROOM 4 EXECUSHUN (VARY). DIS AR TEH ALSO Y TEH SAME ASF CAN USE AS LIL AS 50 MB IN LOW-MEMS VPS ENVIRONMENT, WHILE USIN EVEN UP 2 1 GB ON UR DESKTOP. ASF IZ ACTIVELY ADAPTIN 2 UR ENVIRONMENT AN WILL TRY 2 FIND OPTIMAL BALANCE IN ORDR 2 NEITHR PUT UR OS UNDR PRESURE, NOR LIMIT ITZ OWN PERFORMANCE WHEN U HAS LOT OV UNUSD MEMS DAT CUD BE PUT IN USE.

---

OV COURSE, THAR R LOT OV WAYS HOW U CAN HALP POINT ASF AT TEH RITE DIRECSHUN IN TERMS OV TEH MEMS U EXPECT 2 USE. IN GENERAL IF U DOAN NED 2 DO IT, IZ BEST 2 LET GARBAGE COLLECTOR WERK IN PEACE AN DO WHATEVR IT CONSIDERS IZ BEST. BUT DIS AR TEH NOT ALWAYS POSIBLE, 4 EXAMPLE IF UR LINUX SERVR IZ ALSO HOSTIN SEVERAL WEBSIETS, MYSQL DATABASE AN FP WERKERS, DEN U CANT RLY AFFORD ASF SHRINKIN ITSELF WHEN U RUN CLOSE 2 OOM, AS IZ USUALLY 2 LATE AN PERFORMANCE DEGRADASHUN COMEZ SOONR. DIS AR TEH USUALLY WHEN U CUD BE INTERESTD IN FURTHR TUNIN, AN THEREFORE READIN DIS PAEG.

BELOW SUGGESHUNS R DIVIDD INTO FEW KATEGORIEZ, WIF VARID DIFFICULTY.

---

## ASF SETUP (EASY)

BELOW TRICKZ **DO NOT AFFECT PERFORMANCE NEGATIVELY** AN CAN BE SAFELY APPLID 2 ALL SETUPS.

- RUN **[GENERIC VERSHUN](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up-lol-US#generic-setup)** OV ASF IF POSIBLE. GENERIC VERSHUN OV ASF USEZ LES MEMS SINCE IT DOESNT INCLUDE RUNTIME INSIDE, DOESNT COME AS SINGLE FILE, DOESNT NED 2 UNPACK ITSELF ON RUN, AN IZ THEREFORE SMALLR AN HAS LES MEMS FOOTPRINT. OS-SPECIFIC PACKAGEZ R HANDY AN CONVENIENT, BUT THEYRE ALSO BUNDLD WIF EVRYTHIN NEEDD 2 LAUNCH ASF, WHICH IZ SOMETHIN U CAN TAEK CARE OV YOURSELF AN USE GENERIC ASF VARIANT INSTEAD.
- NEVR RUN MOAR THAN WAN ASF INSTANCE. ASF IZ MEANT 2 HANDLE UNLIMITD NUMBR OV BOTS ALL AT ONCE, AN UNLES URE BINDIN EVRY ASF INSTANCE 2 DIFFERENT INTERFACE/IP ADDRES, U SHUD HAS EGSAKTLY **WAN** ASF PROCES, WIF MULTIPLE BOTS (IF NEEDD).
- MAK USE OV `ShutdownOnFarmingFinished`. ACTIV BOT TAKEZ MOAR RESOURCEZ THAN DEACTIVATD WAN. IZ NOT SIGNIFICANT SAVE, AS TEH STATE OV BOT STILL NEEDZ 2 BE KEPT, BUT URE SAVIN SUM AMOUNT OV RESOURCEZ, ESPECIALLY ALL RESOURCEZ RELATD 2 NETWORKIN, SUCH AS TCP SOCKETS. U CAN ALWAYS BRIN UP OTHR BOTS IF NEEDD.
- KEEP UR BOTS NUMBR LOW. NOT `Enabled` BOT INSTANCE TAKEZ LES RESOURCEZ, AS ASF DOESNT BOTHR STARTIN IT. ALSO KEEP IN MIND DAT ASF HAS 2 CREATE BOT 4 EACH OV UR CONFIGS, THEREFORE IF U DOAN NED 2 `start` GIVEN BOT AN U WANTS 2 SAVE SUM EXTRA MEMS, U CAN TEMPORARILY RENAME `Bot.json` 2 E.G. `Bot.json.bak` IN ORDR 2 AVOID CREATIN STATE 4 UR DISABLD BOT INSTANCE IN ASF. DIS WAI U WONT BE ABLE 2 `start` IT WITHOUT RENAMIN IT BAK, BUT ASF ALSO WONT BOTHR KEEPIN STATE OV DIS BOT IN MEMS, LEAVIN ROOM 4 OTHR THINGS (VRY SMALL SAVE, IN 99.9% CASEZ U SHOULDNT BOTHR WIF IT, JUS KEEP UR BOTS WIF `Enabled` OV `false`).
- FINE-TUNE UR CONFIGS. ESPECIALLY GLOBAL ASF CONFIG HAS LOTZ DA VARIABLEZ 2 ADJUST, 4 EXAMPLE BY INCREASIN `LoginLimiterDelay` ULL BRIN UP UR BOTS SLOWR, WHICH WILL ALLOW ALREADY STARTD INSTANCE 2 FETCH BADGEZ IN DA MEANTIME, AS OPPOSD 2 BRINGIN UP UR BOTS FASTR, WHICH WILL TAEK MOAR RESOURCEZ AS MOAR BOTS WILL DO MAJOR WERK (SUCH AS PARSIN BADGEZ) AT TEH SAME TIEM. TEH LES WERK DAT HAS 2 BE DUN AT TEH SAME TIEM - TEH LES MEMS USD.

DOSE R FEW THINGS U CAN KEEP IN MIND WHEN DEALIN WIF MEMS USAGE. HOWEVR, DOSE THINGS DOAN HAS ANY "CRUSHUL" MATTR ON MEMS USAGE, CUZ MEMS USAGE COMEZ MOSTLY FRUM THINGS ASF HAS 2 DEAL WIF, AN NOT FRUM INTERNAL STRUCTUREZ USD 4 CARDZ FARMIN.

TEH MOST RESOURCEZ-HEAVY FUNCSHUNS R:
- BADGE PAEG PARSIN
- INVENTORY PARSIN

WHICH MEANZ DAT MEMS WILL SPIKE TEH MOST WHEN ASF IZ DEALIN WIF READIN BADGE PAGEZ, AN WHEN IZ DEALIN WIF ITZ INVENTORY (E.G. SENDIN TRADE OR WERKIN WIF STM). DIS AR TEH CUZ ASF HAS 2 DEAL WIF RLY HUGE AMOUNT OV DATA - TEH MEMS USAGE OV UR FAVOURITE BROWSR LAUNCHIN DOSE 2 PAGEZ WILL NOT BE ANY LOWR THAN DAT. SRY, THAZ HOW IT WERKZ - DECREASE NUMBR OV UR BADGE PAGEZ, AN KEEP NUMBR OV UR INVENTORY ITEMS LOW, DAT CAN 4 SURE HALP.

---

## RUNTIME TUNIN (ADVANCD)

BELOW TRICKZ **INVOLVE PERFORMANCE DEGRADASHUN** AN SHUD BE USD WIF CAUSHUN.

TEH RECOMMENDD WAI OV APPLYIN DOSE SETTINGS IZ THRU `DOTNET_` ENVIRONMENT PROPERTIEZ. OV COURSE, U CUD ALSO USE OTHR METHODZ, E.G. `runtimeconfig.json`, BUT SUM SETTINGS R IMPOSIBLE 2 BE SET DIS WAI, AN ON TOP OV DAT ASF WILL REPLACE UR CUSTOM `runtimeconfig.json` WIF ITZ OWN ON TEH NEXT UPDATE, THEREFORE WE RECOMMEND ENVIRONMENT PROPERTIEZ DAT U CAN SET EASILY PRIOR 2 LAUNCHIN TEH PROCES.

.NET RUNTIME ALLOWS U 2 **[TWEAK GARBAGE COLLECTOR](https://docs.microsoft.com/dotnet/core/run-time-config/garbage-collector)** IN LOT OV WAYS, EFFECTIVELY FINE-TUNIN TEH GC PROCES ACCORDIN 2 UR NEEDZ. WEVE DOCUMENTD BELOW PROPERTIEZ DAT R ESPECIALLY IMPORTANT IN R OPINION.

### [`GCHeapHardLimitPercent`](https://docs.microsoft.com/dotnet/core/run-time-config/garbage-collector#heap-limit-percent)

> SPECIFIEZ TEH ALLOWABLE GC HEAP USAGE AS PERSENTAGE OV TEH TOTAL FYSICAL MEMS.

TEH "HARD" MEMS LIMIT 4 ASF PROCES, DIS SETTIN TUNEZ GC 2 USE ONLY SUBSET OV TOTAL MEMS AN NOT ALL OV IT. IT CUD BECOME ESPECIALLY USEFUL IN VARIOUS SERVR-LIEK SITUASHUNS WER U CAN DEDICATE FIXD PERSENTAGE OV UR SERVERS MEMS 4 ASF, BUT NEVR MOAR THAN DAT. BE ADVISD DAT LIMITIN MEMS 4 ASF 2 USE WILL NOT MAGICALLY MAK ALL OV DOSE REQUIRD MEMS ALLOCASHUNS GO AWAY, THEREFORE SETTIN DIS VALUE 2 LOW MITE RESULT IN RUNNIN INTO OUT OV MEMS SCENARIOS, WER ASF PROCES WILL BE FORCD 2 TERMINATE.

ON TEH OTHR HAND, SETTIN DIS VALUE HIGH ENOUGH IZ PERFIK WAI 2 ENSURE DAT ASF WILL NEVR USE MOAR MEMS THAN U CAN REALISTICALLY AFFORD, GIVIN UR MACHINE SUM BREATHIN ROOM EVEN UNDR HEAVY LOAD, WHILE STILL ALLOWIN TEH PROGRAM 2 DO ITZ JOB AS EFFICIENTLY AS POSIBLE.

### [`GCHighMemPercent`](https://docs.microsoft.com/dotnet/core/run-time-config/garbage-collector#high-memory-percent)

> SPECIFIEZ TEH AMOUNT OV MEMS USD AFTR WHICH GC BECOMEZ MOAR AGGRESIV.

DIS SETTIN CONFIGUREZ TEH MEMS THRESHOLD OV UR WHOLE OS, WHICH ONCE PASD, CAUSEZ GC 2 BECOME MOAR AGGRESIV AN ATTEMPT 2 HALP TEH OS LOWR TEH MEMS LOAD BY RUNNIN MOAR INTENSIV GC PROCES AN IN RESULT RELEASIN MOAR FREE MEMS BAK 2 TEH OS. IT BE GUD IDEA 2 SET DIS PROPERTY 2 MAXIMUM AMOUNT OV MEMS (AS PERSENTAGE) WHICH U CONSIDR "CRITICAL" 4 UR WHOLE OS PERFORMANCE. DEFAULT IZ 90%, AN USUALLY U WANTS 2 KEEP IT IN 80-97% RANGE, AS 2 LOW VALUE WILL CAUSE UNNECESARY AGGRESHUN FRUM TEH GC AN PERFORMANCE DEGRADASHUN 4 NO REASON, WHILE 2 HIGH VALUE WILL PUT UNNECESARY LOAD ON UR OS, CONSIDERIN ASF CUD RELEASE SUM OV ITZ MEMS 2 HALP.

### **[`GCLatencyLevel`](https://github.com/dotnet/runtime/blob/4b90e803262cb5a045205d946d800f9b55f88571/src/coreclr/gc/gcpriv.h#L375-L398)**

> SPECIFIEZ TEH GC LATENCY LEVEL DAT U WANTS 2 OPTIMIZE 4.

DIS AR TEH UNDOCUMENTD PROPERTY DAT TURND OUT 2 WERK EXCEPSHUNALLY WELL 4 ASF, BY LIMITIN SIZE OV GC GENERASHUNS AN IN RESULT MAK GC PURGE THEM MOAR FREQUENTLY AN MOAR AGGRESIVELY. DEFAULT (BALANCD) LATENCY LEVEL IZ `1`, BUT U CAN USE `0`, WHICH WILL TUNE 4 MEMS USAGE.

### [`gcTrimCommitOnLowMemory`](https://docs.microsoft.com/dotnet/standard/garbage-collection/optimization-for-shared-web-hosting)

> WHEN SET WE TRIM TEH COMMITTD SPACE MOAR AGGRESIVELY 4 DA EFEMERAL SEG. DIS AR TEH USD 4 RUNNIN LOTZ DA INSTANCEZ OV SERVR PROCESEZ WER THEY WANTS 2 KEEP AS LIL MEMS COMMITTD AS POSIBLE.

DIS OFFERS LIL IMPROOVEMENT, BUT CUD MAK GC EVEN MOAR AGGRESIV WHEN SISTEM WILL BE LOW ON MEMS, ESPECIALLY 4 ASF WHICH MAKEZ USE OV THREADPOOL TASKZ HEAVILY.

---

U CAN ENABLE SELECTD PROPERTIEZ BY SETTIN APPROPRIATE ENVIRONMENT VARIABLEZ. 4 EXAMPLE, ON LINUX (SHELL):

```shell
# DOAN FORGET 2 TUNE DOSE IF URE PLANNIN 2 MAK USE OV THEM
export DOTNET_GCHeapHardLimitPercent=0x4B # 75% as hex
export DOTNET_GCHighMemPercent=0x50 # 80% as hex

export DOTNET_GCLatencyLevel=0
export DOTNET_gcTrimCommitOnLowMemory=1

./ArchiSteamFarm # 4 OS-SPECIFIC BUILD
./ArchiSteamFarm.sh # 4 GENERIC BUILD
```

OR ON WINDOWS (POWERSHELL):

```powershell
# DOAN FORGET 2 TUNE DOSE IF URE PLANNIN 2 MAK USE OV THEM
$Env:DOTNET_GCHeapHardLimitPercent=0x4B # 75% as hex
$Env:DOTNET_GCHighMemPercent=0x50 # 80% as hex

$Env:DOTNET_GCLatencyLevel=0
$Env:DOTNET_gcTrimCommitOnLowMemory=1

.\ArchiSteamFarm.exe # 4 OS-SPECIFIC BUILD
.\ArchiSteamFarm.cmd # 4 GENERIC BUILD
```

ESPECIALLY `GCLatencyLevel` WILL COME VRY USEFUL AS WE VERIFID DAT TEH RUNTIME INDED OPTIMIZEZ CODE 4 MEMS AN THEREFORE DROPS AVERAGE MEMS USAGE SIGNIFICANTLY, EVEN WIF SERVR GC. IZ WAN OV TEH BEST TRICKZ DAT U CAN APPLY IF U WANTS 2 SIGNIFICANTLY LOWR ASF MEMS USAGE WHILE NOT DEGRADIN PERFORMANCE 2 MUTCH WIF `OptimizationMode`.

---

## ASF TUNIN (INTERMEDIATE)

BELOW TRICKZ **INVOLVE SERIOUS PERFORMANCE DEGRADASHUN** AN SHUD BE USD WIF CAUSHUN.

- AS LAST RESORT, U CAN TUNE ASF 4 `MinMemoryUsage` THRU `OptimizationMode` **[GLOBAL CONFIG PROPERTY](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-lol-US#global-config)**. READ CAREFULLY ITZ PURPOSE, AS DIS AR TEH SERIOUS PERFORMANCE DEGRADASHUN 4 NEARLY NO MEMS BENEFITS. DIS AR TEH TYPICALLY **TEH LAST TING U WANTS 2 DO**, LONG AFTR U GO THRU **[RUNTIME TUNIN](#runtime-tunin-advancd)** 2 ENSURE DAT URE FORCD 2 DO DIS. UNLES ABSOLUTELY CRITICAL 4 UR SETUP, WE DISCOURAGE USIN `MinMemoryUsage`, EVEN IN MEMS-CONSTRAIND ENVIRONMENTS.

---

## RECOMMENDD OPTIMIZASHUN

- START FRUM SIMPLE ASF SETUP TRICKZ, USE **[GENERIC ASF VARIANT](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up-lol-US#generic-setup)** AN CHECK IF PERHAPS URE JUS USIN UR ASF IN WRONG WAI SUCH AS STARTIN TEH PROCES SEVERAL TIEMS 4 ALL OV UR BOTS, OR KEEPIN ALL OV THEM ACTIV IF U NED JUS WAN OR 2 2 AUTOSTART.
- IF IZ STILL NOT ENOUGH, ENABLE ALL CONFIGURASHUN PROPERTIEZ LISTD ABOOV BY SETTIN APPROPRIATE `DOTNET_` ENVIRONMENT VARIABLEZ. ESPECIALLY `GCLatencyLevel` OFFERS SIGNIFICANT RUNTIME IMPROOVEMENTS 4 LIL COST ON PERFORMANCE.
- IF EVEN DAT DIDNT HALP, AS LAST RESORT ENABLE `MinMemoryUsage` `OptimizationMode`. DIS FORCEZ ASF 2 EXECUTE ALMOST EVRYTHIN IN SYNCHRONOUS MATTR, MAKIN IT WERK MUTCH SLOWR BUT ALSO NOT RELYIN ON THREAD POOL 2 BALANCE THINGS OUT WHEN IT COMEZ 2 PARALLEL EXECUSHUN.

IZ FYSICALLY IMPOSIBLE 2 DECREASE MEMS EVEN FURTHR, UR ASF IZ ALREADY HEAVILY DEGRADD IN TERMS OV PERFORMANCE AN U DEPLETD ALL UR POSIBILITIEZ, BOTH CODE-WIZE AN RUNTIME-WIZE. CONSIDR ADDIN SUM EXTRA MEMS 4 ASF 2 USE, EVEN 128 MB WUD MAK GREAT DIFFERENCE.