# LOGGIN

ASF ALLOWS U 2 CONFIGURE UR OWN CUSTOM LOGGIN MODULE DAT WILL BE USD DURIN RUNTIME. U CAN DO SO BY PUTTIN SPESHUL FILE NAMD `NLog.config` IN APPLICASHUN’S DIRECTORY. U CAN READ ENTIRE DOCUMENTASHUN OV NLOG ON **[NLOG WIKI](https://github.com/NLog/NLog/wiki/Configuration-file)**, BUT IN ADDISHUN 2 DAT ULL FIND SUM USEFUL EXAMPLEZ HER AS WELL.

---

## DEFAULT LOGGIN

BY DEFAULT, ASF IZ LOGGIN 2 `ColoredConsole` (STANDARD OUTPUT) AN `File`. `File` LOGGIN INCLUDEZ `log.txt` FILE IN PROGRAMS DIRECTORY, AN `logs` DIRECTORY 4 ARCHIVAL PURPOSEZ.

USIN CUSTOM NLOG CONFIG AUTOMATICALLY DISABLEZ DEFAULT ASF CONFIG, UR CONFIG OVERRIDEZ **COMPLETELY** DEFAULT ASF LOGGIN, WHICH MEANZ DAT IF U WANTS 2 KEEP E.G. R `ColoredConsole` TARGET, DEN U MUST DEFINE IT **YOURSELF**. DIS ALLOWS U 2 NOT ONLY ADD **EXTRA** LOGGIN TARGETS, BUT ALSO DISABLE OR MODIFY **DEFAULT** ONEZ.

IF U WANTS 2 USE DEFAULT ASF LOGGIN WITHOUT ANY MODIFICASHUNS, U DOAN NED 2 DO ANYTHIN - U ALSO DOAN NED 2 DEFINE IT IN CUSTOM `NLog.config`. DOAN USE CUSTOM `NLog.config` IF U DOAN WANTS 2 MODIFY DEFAULT ASF LOGGIN. 4 REFERENCE THOUGH, EQUIVALENT OV HARDCODD ASF DEFAULT LOGGIN WUD BE:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" layout="${date:format=yyyy-MM-dd HH\:mm\:ss}|${processname}-${processid}|${level:uppercase=true}|${logger}|${message}${onexception:inner= ${exception:format=toString,Data}}" />
    <target xsi:type="File" name="File" archiveFileName="${currentdir}/logs/log.{#}.txt" archiveNumbering="Rolling" archiveOldFileOnStartup="true" cleanupFileName="false" concurrentWrites="false" deleteOldFileOnStartup="true" fileName="${currentdir}/log.txt" layout="${date:format=yyyy-MM-dd HH\:mm\:ss}|${processname}-${processid}|${level:uppercase=true}|${logger}|${message}${onexception:inner= ${exception:format=toString,Data}}" maxArchiveFiles="10" />

    <!-- Below becomes active when ASF's IPC interface is started -->
    <target type="History" name="History" layout="${date:format=yyyy-MM-dd HH\:mm\:ss}|${processname}-${processid}|${level:uppercase=true}|${logger}|${message}${onexception:inner= ${exception:format=toString,Data}}" maxCount="20" />
  </targets>

  <rules>
    <!-- The following entries specify ASP.NET (IPC) logging, we declare those so our last Debug catch-all doesn't include ASP.NET logs by default -->
    <logger name="Microsoft.*" finalMinLevel="Warn" writeTo="ColoredConsole" />
    <logger name="Microsoft.Hosting.Lifetime" finalMinLevel="Info" writeTo="ColoredConsole" />
    <logger name="System.*" finalMinLevel="Warn" writeTo="ColoredConsole" />

    <logger name="*" minlevel="Debug" writeTo="ColoredConsole" />

    <!-- The following entries specify ASP.NET (IPC) logging, we declare those so our last Debug catch-all doesn't include ASP.NET logs by default -->
    <logger name="Microsoft.*" finalMinLevel="Warn" writeTo="File" />
    <logger name="Microsoft.Hosting.Lifetime" finalMinLevel="Info" writeTo="File" />
    <logger name="System.*" finalMinLevel="Warn" writeTo="File" />

    <logger name="*" minlevel="Debug" writeTo="File" />

    <!-- Below becomes active when ASF's IPC interface is enabled -->
    <!-- The following entries specify ASP.NET (IPC) logging, we declare those so our last Debug catch-all doesn't include ASP.NET logs by default -->
    <logger name="Microsoft.*" finalMinLevel="Warn" writeTo="History" />
    <logger name="Microsoft.Hosting.Lifetime" finalMinLevel="Info" writeTo="History" />
    <logger name="System.*" finalMinLevel="Warn" writeTo="History" />

    <logger name="*" minlevel="Debug" writeTo="History" />
  </rules>
</nlog>
```

---

## ASF INTEGRASHUN

ASF INCLUDEZ SUM NICE CODE TRICKZ DAT ENHANCE ITZ INTEGRASHUN WIF NLOG, ALLOWIN U 2 KATCH SPECIFIC MESAGEZ MOAR EASILY.

NLOG-SPECIFIC `${logger}` VARIABLE WILL ALWAYS DISTINGUISH TEH SOURCE OV TEH MESAGE - IT WILL BE EITHR `BotName` OV WAN OV UR BOTS, OR `ASF` IF MESAGE COMEZ FRUM ASF PROCES DIRECTLY. DIS WAI U CAN EASILY KATCH MESAGEZ CONSIDERIN SPECIFIC BOT(S), OR ASF PROCES (ONLY), INSTEAD OV ALL OV THEM, BASD ON TEH NAYM OV TEH LOGGR.

ASF TRIEZ 2 MARK MESAGEZ APPROPRIATELY BASD ON NLOG-PROVIDD LOGGIN LEVELS, WHICH MAKEZ IT POSIBLE 4 U 2 KATCH ONLY SPECIFIC MESAGEZ FRUM SPECIFIC LOG LEVELS INSTEAD OV ALL OV THEM. OV COURSE, LOGGIN LEVEL 4 SPECIFIC MESAGE CANT BE CUSTOMIZD, AS IZ ASF HARDCODD DECISHUN HOW SERIOUS GIVEN MESAGE IZ, BUT U DEFINITELY CAN MAK ASF LES/MOAR SILENT, AS U C FIT.

ASF LOGS EXTRA INFO, SUCH AS USR/CHAT MESAGEZ ON `Trace` LOGGIN LEVEL. DEFAULT ASF LOGGIN LOGS ONLY `Debug` LEVEL AN ABOOV, WHICH HIDEZ DAT EXTRA INFORMASHUN, AS IZ NOT NEEDD 4 MAJORITY OV USERS, PLUS CLUTTERS OUTPUT CONTAININ POTENTIALLY MOAR IMPORTANT MESAGEZ. U CAN HOWEVR MAK USE OV DAT INFORMASHUN BY RE-ENABLIN `Trace` LOGGIN LEVEL, ESPECIALLY IN COMBINASHUN WIF LOGGIN ONLY WAN SPECIFIC BOT OV UR CHOICE, WIF PARTICULAR EVENT URE INTERESTD IN.

IN GENERAL, ASF TRIEZ 2 MAK IT AS EASY AN CONVENIENT 4 U AS POSIBLE, 2 LOG ONLY MESAGEZ U WANTS INSTEAD OV FORCIN U 2 MANUALLY FILTR IT THRU THIRD-PARTY TOOLS SUCH AS `grep` AN ALIKE. SIMPLY CONFIGURE NLOG PROPERLY AS WRITTEN BELOW, AN U SHUD BE ABLE 2 SPECIFY EVEN VRY COMPLEX LOGGIN RULEZ WIF CUSTOM TARGETS SUCH AS ENTIRE DATABASEZ.

REGARDIN VERSHUNIN - ASF TRIEZ 2 ALWAYS SHIP WIF MOST UP-2-DATE VERSHUN OV NLOG DAT IZ AVAILABLE ON **[NUGET](https://www.nuget.org/packages/NLog)** AT TEH TIEM OV ASF RELEASE. IT SHUD NOT BE PROBLEM 2 USE ANY FEACHUR U CAN FIND ON NLOG WIKI IN ASF - JUS MAK SURE URE ALSO USIN UP-2-DATE ASF.

AS PART OV ASF INTEGRASHUN, ASF ALSO INCLUDEZ SUPPORT 4 ADDISHUNAL ASF NLOG LOGGIN TARGETS, WHICH WILL BE EXPLAIND BELOW.

---

## EXAMPLEZ

LETS START FRUM SOMETHIN EASY. WE WILL USE **[ColoredConsole](https://github.com/nlog/nlog/wiki/ColoredConsole-target)** TARGET ONLY. R INITIAL `NLog.config` WILL LOOK LIEK DIS:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" />
  </targets>

  <rules>
    <logger name="*" minlevel="Debug" writeTo="ColoredConsole" />
  </rules>
</nlog>
```

TEH EXPLANASHUN OV ABOOV CONFIG IZ RATHR SIMPLE - WE DEFINE WAN **LOGGIN TARGET**, WHICH IZ `ColoredConsole`, DEN WE REDIRECT **ALL LOGGERS** (`*`) OV LEVEL `Debug` AN HIGHR 2 `ColoredConsole`TARGET WE DEFIND EARLIR. THAZ IT.

IF U START ASF WIF ABOOV `NLog.config` NAO, ONLY `ColoredConsole` TARGET WILL BE ACTIV, AN ASF WONT RITE 2 `File`, REGARDLES OV HARDCODD ASF NLOG CONFIGURASHUN.

NAO LETS SAY DAT WE DOAN LIEK DEFAULT FORMAT OV `${longdate}|${level:uppercase=true}|${logger}|${message}` AN WE WANTS 2 LOG MESAGE ONLY. WE CAN DO SO BY MODIFYIN **[LAYOUT](https://github.com/nlog/nlog/wiki/Layouts)** OV R TARGET.

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" layout="${message}" />
  </targets>

  <rules>
    <logger name="*" minlevel="Debug" writeTo="ColoredConsole" />
  </rules>
</nlog>
```

IF U LAUNCH ASF NAO, ULL NOTICE DAT DATE, LEVEL AN LOGGR NAYM DISAPPEARD - LEAVIN U ONLY WIF ASF MESAGEZ IN FORMAT OV `Function() Message`.

WE CAN ALSO MODIFY TEH CONFIG 2 LOG 2 MOAR THAN WAN TARGET. LETS LOG 2 `ColoredConsole` AN **[`File`](https://github.com/nlog/nlog/wiki/File-target)** AT TEH SAME TIEM.

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" />
    <target xsi:type="File" name="File" fileName="${currentdir}/NLog.txt" deleteOldFileOnStartup="true" />
  </targets>

  <rules>
    <logger name="*" minlevel="Debug" writeTo="ColoredConsole" />
    <logger name="*" minlevel="Debug" writeTo="File" />
  </rules>
</nlog>
```

AN DUN, WELL NAO LOG EVRYTHIN 2 `ColoredConsole` AN `File`. DID U NOTICE DAT U CAN ALSO SPECIFY CUSTOM `fileName` AN EXTRA OPSHUNS?

FINALLY, ASF USEZ VARIOUS LOG LEVELS, 2 MAK IT EASIR 4 U 2 UNDERSTAND WUT IZ GOIN ON. WE CAN USE DAT INFORMASHUN 4 MODIFYIN SEVERITY LOGGIN. LETS SAY DAT WE WANTS 2 LOG EVRYTHIN (`Trace`) 2 `File`, BUT ONLY `Warning` AN ABOOV **[LOG LEVEL](https://github.com/NLog/NLog/wiki/Configuration-file#log-levels)** 2 TEH `ColoredConsole`. WE CAN ACHIEVE DAT BY MODIFYIN R `rules`:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" />
    <target xsi:type="File" name="File" fileName="${currentdir}/NLog.txt" deleteOldFileOnStartup="true" />
  </targets>

  <rules>
    <logger name="*" minlevel="Warn" writeTo="ColoredConsole" />
    <logger name="*" minlevel="Trace" writeTo="File" />
  </rules>
</nlog>
```

THAZ IT, NAO R `ColoredConsole` WILL SHOW ONLY WARNINGS AN ABOOV, WHILE STILL LOGGIN EVRYTHIN 2 `File`. U CAN FURTHR TWEAK IT 2 LOG E.G. ONLY `Info` AN BELOW, AN SO ON.

LASTLY, LETS DO SOMETHIN BIT MOAR ADVANCD AN LOG ALL MESAGEZ 2 FILE, BUT ONLY FRUM BOT NAMD `LogBot`.

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" />
    <target xsi:type="File" name="LogBotFile" fileName="${currentdir}/LogBot.txt" deleteOldFileOnStartup="true" />
  </targets>

  <rules>
    <logger name="*" minlevel="Debug" writeTo="ColoredConsole" />
    <logger name="LogBot" minlevel="Trace" writeTo="LogBotFile" />
  </rules>
</nlog>
```

U CAN C HOW WE USD ASF INTEGRASHUN ABOOV AN EASILY DISTINGUISHD SOURCE OV TEH MESAGE BASD ON `${logger}` PROPERTY.

---

## ADVANCD USAGE

TEH EXAMPLEZ ABOOV R RATHR SIMPLE AN MADE 2 SHOW U HOW EASY IT 2 DEFINE UR OWN LOGGIN RULEZ DAT CAN BE USD WIF ASF. U CAN USE NLOG 4 VARIOUS DIFFERENT THINGS, INCLUDIN COMPLEX TARGETS (SUCH AS KEEPIN LOGS IN `Database`), LOGS ROTASHUN (SUCH AS REMOVIN OLD `File` LOGS), USIN CUSTOM `Layout`S, DECLARIN UR OWN `<when>` LOGGIN FILTERS AN MUTCH MOAR. I ENCOURAGE U 2 READ THRU ENTIRE **[NLOG DOCUMENTASHUN](https://github.com/nlog/nlog/wiki/Configuration-file)** 2 LERN BOUT EVRY OPSHUN DAT IZ AVAILABLE 2 U, ALLOWIN U 2 FINE-TUNE ASF LOGGIN MODULE IN DA WAI U WANTS. IT BE RLY POWERFUL TOOL AN CUSTOMIZIN ASF LOGGIN WUZ NEVR EASIR.

---

## LIMITASHUNS

ASF WILL TEMPORARILY DISABLE **ALL** RULEZ DAT INCLUDE `ColoredConsole` OR `Console` TARGETS WHEN EXPECTIN USR INPUT. THEREFORE, IF U WANTS 2 KEEP LOGGIN 4 OTHR TARGETS EVEN WHEN ASF EXPEX USR INPUT, U SHUD DEFINE DOSE TARGETS WIF THEIR OWN RULEZ, AS SHOWN IN EXAMPLEZ ABOOV, INSTEAD OV PUTTIN LOTZ DA TARGETS IN `writeTo` OV TEH SAME RULE (UNLES DIS AR TEH UR WANTD BEHAVIOUR). TEMPORARY DISABLE OV CONSOLE TARGETS IZ DUN IN ORDR 2 KEEP CONSOLE CLEAN WHEN WAITIN 4 USR INPUT.

---

## CHAT LOGGIN

ASF INCLUDEZ EXTENDD SUPPORT 4 CHAT LOGGIN BY NOT ONLY RECORDIN ALL RECEIVD/SENT MESAGEZ ON `Trace` LOGGIN LEVEL, BUT ALSO EXPOSIN EXTRA INFO RELATD 2 THEM IN **[EVENT PROPERTIEZ](https://github.com/NLog/NLog/wiki/EventProperties-Layout-Renderer)**. DIS AR TEH CUZ WE NED 2 HANDLE CHAT MESAGEZ AS COMMANDZ ANYWAY, SO IT DOESNT COST US ANYTHIN 2 LOG DOSE EVENTS IN ORDR 2 MAK IT POSIBLE 4 U 2 ADD EXTRA LOGIC (SUCH AS MAKIN ASF UR PERSONAL STEAM CHATTIN ARCHIV).

### EVENT PROPERTIEZ

| NAYM        | DESCRIPSHUN                                                                                                                                                                                  |
| ----------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Echo        | `bool` TYPE. DIS AR TEH SET 2 `true` WHEN MESAGE IZ BEAN SENT FRUM US 2 TEH RECIPIENT, AN `false` OTHERWIZE.                                                                                 |
| Message     | `string` TYPE. DIS AR TEH TEH AKSHUL SENT/RECEIVD MESAGE.                                                                                                                                    |
| ChatGroupID | `ulong` TYPE. DIS AR TEH TEH ID OV TEH GROUP CHAT 4 SENT/RECEIVD MESAGEZ. WILL BE `0` WHEN NO GROUP CHAT IZ USD 4 TRANZMITTIN DIS MESAGE.                                                    |
| ChatID      | `ulong` TYPE. DIS AR TEH TEH ID OV TEH `ChatGroupID` CHANNEL 4 SENT/RECEIVD MESAGEZ. WILL BE `0` WHEN NO GROUP CHAT IZ USD 4 TRANZMITTIN DIS MESAGE.                                         |
| SteamID     | `ulong` TYPE. DIS AR TEH TEH ID OV TEH STEAM USR 4 SENT/RECEIVD MESAGEZ. CAN BE `0` WHEN NO PARTICULAR USR IZ INVOLVD IN DA MESAGE TRANZMISHUN (E.G. WHEN IZ US SENDIN MESAGE 2 GROUP CHAT). |

### EXAMPLE

DIS EXAMPLE IZ BASD ON R `ColoredConsole` BASIC EXAMPLE ABOOV. BEFORE TRYIN 2 UNDERSTAND IT, I STRONGLY RECOMMEND 2 TAEK LOOK **[ABOOV](#examplez)** IN ORDR 2 LERN BOUT BASICS OV NLOG LOGGIN FIRSTLY.

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target xsi:type="ColoredConsole" name="ColoredConsole" />
    <target xsi:type="File" name="ChatLogFile" fileName="${currentdir}/${event-properties:item=ChatGroupID}-${event-properties:item=ChatID}${when:when='${event-properties:item=ChatGroupID}' == 0:inner=-${event-properties:item=SteamID}}.txt" layout="${date:format=yyyy-MM-dd HH\:mm\:ss} ${event-properties:item=Message} ${when:when='${event-properties:item=Echo}' == true:inner=-&gt;:else=&lt;-} ${event-properties:item=SteamID}" />
  </targets>

  <rules>
    <logger name="*" minlevel="Debug" writeTo="ColoredConsole" />
    <logger name="MainAccount" level="Trace" writeTo="ChatLogFile">
      <filters defaultAction="Log">
        <when condition="not starts-with('${message}','OnIncoming') and not starts-with('${message}','SendMessage')" action="Ignore" />
      </filters>
    </logger>
  </rules>
</nlog>
```

WEVE STARTD FRUM R BASIC `ColoredConsole` EXAMPLE AN EXTENDD IT FURTHR. FURST AN FOREMOST, WEVE PREPARD PERMANENT CHAT LOG FILE PER EACH GROUP CHANNEL AN STEAM USR - DIS AR TEH POSIBLE THX 2 EXTRA PROPERTIEZ DAT ASF EXPOSEZ 2 US IN FANCY WAI. WEVE ALSO DECIDD 2 GO WIF CUSTOM LAYOUT DAT WRITEZ ONLY CURRENT DATE, TEH MESAGE, SENT/RECEIVD INFO AN STEAM USR ITSELF. LASTLY, WEVE ENABLD R CHAT LOGGIN RULE ONLY 4 `Trace` LEVEL, ONLY 4 R `MainAccount` BOT AN ONLY 4 FUNCSHUNS RELATD 2 CHAT LOGGIN (`OnIncoming*` WHICH IZ USD 4 RECEIVIN MESAGEZ AN ECHOS, AN `SendMessage*` 4 ASF MESAGEZ SENDIN).

TEH EXAMPLE ABOOV WILL GENERATE `0-0-76561198069026042.txt` FILE WHEN TALKIN WIF **[ArchiBot](https://steamcommunity.com/profiles/76561198069026042)**:

```text
2018-07-26 01:38:38 how are you doing? -> 76561198069026042
2018-07-26 01:38:38 I'm doing great, how about you? <- 76561198069026042
```

OV COURSE DIS AR TEH JUS WERKIN EXAMPLE WIF FEW NICE LAYOUT TRICKZ SHOWD IN PRACTICAL MANNR. U CAN FURTHR EXPAND DIS IDEA 2 UR OWN NEEDZ, SUCH AS EXTRA FILTERIN, CUSTOM ORDR, PERSONAL LAYOUT, RECORDIN ONLY RECEIVD MESAGEZ AN SO ON.

---

## ASF TARGETS

IN ADDISHUN 2 STANDARD NLOG LOGGIN TARGETS (SUCH AS `ColoredConsole` AN `File` EXPLAIND ABOOV), U CAN ALSO USE CUSTOM ASF LOGGIN TARGETS.

4 MAXIMUM COMPLETENES, DEFINISHUN OV ASF TARGETS WILL FOLLOW NLOG DOCUMENTASHUN CONVENSHUN.

---

### STEAMTARGET

AS U CAN GUES, DIS TARGET USEZ STEAM CHAT MESAGEZ 4 LOGGIN ASF MESAGEZ. U CAN CONFIGURE IT 2 USE EITHR GROUP CHAT, OR PRIVATE CHAT. IN ADDISHUN 2 SPECIFYIN STEAM TARGET 4 UR MESAGEZ, U CAN ALSO SPECIFY `botName` OV TEH BOT DAT IZ SUPPOSD 2 SEND DOSE.

SUPPORTD IN ALL ENVIRONMENTS USD BY ASF.

---

#### CONFIGURASHUN SYNTAX
```xml
<targets>
  <target type="Steam"
          name="String"
          layout="Layout"
          chatGroupID="Ulong"
          steamID="Ulong"
          botName="Layout" />
</targets>
```

READ MOAR BOUT USIN TEH [CONFIGURASHUN FILE](https://github.com/NLog/NLog/wiki/Configuration-file).

---

#### PARAMETERS

##### GENERAL OPSHUNS
_name_ - NAYM OV TEH TARGET.

---

##### LAYOUT OPSHUNS
_layout_ - TEXT 2 BE RENDERD. [LAYOUT](https://github.com/NLog/NLog/wiki/Layouts) REQUIRD. DEFAULT: `${level:uppercase=true}|${logger}|${message}`

---

##### STEAMTARGET OPSHUNS

_chatGroupID_ - ID OV TEH GROUP CHAT DECLARD AS 64-BIT LONG UNSIGND INTEGR. NOT REQUIRD. DEFAULTS 2 `0` WHICH WILL DISABLE GROUP CHAT FUNCSHUNALITY AN USE PRIVATE CHAT INSTEAD. WHEN ENABLD (SET 2 NON-ZERO VALUE), `steamID` PROPERTY BELOW ACTS AS `chatID` AN SPECIFIEZ ID OV TEH CHANNEL IN DIS `chatGroupID` DAT TEH BOT SHUD SEND MESAGEZ 2.

_steamID_ - SteamID DECLARD AS 64-BIT LONG UNSIGND INTEGR OV TARGET STEAM USR (LIEK `SteamOwnerID`), OR TARGET `chatID` (WHEN `chatGroupID` IZ SET). REQUIRD. DEFAULTS 2 `0` WHICH DISABLEZ LOGGIN TARGET ENTIRELY.

_botName_ - NAYM OV TEH BOT (AS IZ RECOGNIZD BY ASF, CASE-SENSITIV) DAT WILL BE SENDIN MESAGEZ 2 `steamID` DECLARD ABOOV. NOT REQUIRD. DEFAULTS 2 `null` WHICH WILL AUTOMATICALLY SELECT **ANY** CURRENTLY CONNECTD BOT. IZ RECOMMENDD 2 SET DIS VALUE APPROPRIATELY, AS `SteamTarget` DOEZ NOT TAEK INTO AKOWNT LOTZ DA STEAM LIMITASHUNS, SUCH AS TEH FACT DAT U MUST HAS `steamID` OV TEH TARGET ON UR FRIENDLIST. DIS VARIABLE IZ DEFIND AS [LAYOUT](https://github.com/NLog/NLog/wiki/Layouts) TYPE, THEREFORE U CAN USE SPESHUL SYNTAX IN IT, SUCH AS `${logger}` IN ORDR 2 USE TEH BOT DAT GENERATD TEH MESAGE.

---

#### STEAMTARGET EXAMPLEZ

IN ORDR 2 RITE ALL MESAGEZ OV `Debug` LEVEL AN ABOOV, FRUM BOT NAMD `MyBot` 2 STEAMID OV `76561198006963719`, U SHUD USE `NLog.config` SIMILAR 2 BELOW:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="https://nlog-project.org/schemas/NLog.xsd" xsi:schemaLocation="NLog NLog.xsd" xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance">
  <targets>
    <target type="Steam" name="Steam" steamID="76561198006963719" botName="MyBot" />
  </targets>

  <rules>
    <logger name="*" minlevel="Debug" writeTo="Steam" />
  </rules>
</nlog>
```

**NOTICE:** R `SteamTarget` IZ CUSTOM TARGET, SO U SHUD MAK SURE DAT URE DECLARIN IT AS `type="Steam"`, NOT `xsi:type="Steam"`, AS XSI IZ RESERVD 4 OFFISHUL TARGETS SUPPORTD BY NLOG.

WHEN U LAUNCH ASF WIF `NLog.config` SIMILAR 2 ABOOV, `MyBot` WILL START MESAGIN `76561198006963719` STEAM USR WIF ALL USUAL ASF LOG MESAGEZ. KEEP IN MIND DAT `MyBot` MUST BE CONNECTD IN ORDR 2 SEND MESAGEZ, SO ALL INITIAL ASF MESAGEZ DAT HAPPEND BEFORE R BOT CUD CONNECT 2 STEAM NETWORK, WONT BE FORWARDD.

OV COURSE, `SteamTarget` HAS ALL TYPICAL FUNCSHUNS DAT U CUD EXPECT FRUM GENERIC `TargetWithLayout`, SO U CAN USE IT IN CONJUNCSHUN WIF E.G. CUSTOM LAYOUTS, NAMEZ OR ADVANCD LOGGIN RULEZ. TEH EXAMPLE ABOOV IZ ONLY TEH MOST BASIC WAN.

---

#### SCREENSHOTS

![Screenshot](https://i.imgur.com/5juKHMt.png)

---

### HISTORYTARGET

DIS TARGET IZ USD INTERNALLY BY ASF 4 PROVIDIN FIXD-SIZE LOGGIN HISTORY IN `/Api/NLog` ENDPOINT OV **[ASF API](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-lol-US#asf-api)** DAT CAN BE AFTERWARDZ CONSUMD BY ASF-UI AN OTHR TOOLS. IN GENERAL U SHUD DEFINE DIS TARGET ONLY IF URE ALREADY USIN CUSTOM NLOG CONFIG 4 OTHR CUSTOMIZASHUNS AN U ALSO WANTS TEH LOG 2 BE EXPOSD IN ASF API, E.G. 4 ASF-UI. IT CAN ALSO BE DECLARD WHEN UD WANTS 2 MODIFY DEFAULT LAYOUT OR `maxCount` OV SAVD MESAGEZ.

SUPPORTD IN ALL ENVIRONMENTS USD BY ASF.

---

#### CONFIGURASHUN SYNTAX
```xml
<targets>
  <target type="History"
          name="String"
          layout="Layout"
          maxCount="Byte" />
</targets>
```

READ MOAR BOUT USIN TEH [CONFIGURASHUN FILE](https://github.com/NLog/NLog/wiki/Configuration-file).

---

#### PARAMETERS

##### GENERAL OPSHUNS
_name_ - NAYM OV TEH TARGET.

---

##### LAYOUT OPSHUNS
_layout_ - TEXT 2 BE RENDERD. [LAYOUT](https://github.com/NLog/NLog/wiki/Layouts) REQUIRD. DEFAULT: `${date:format=yyyy-MM-dd HH\:mm\:ss}|${processname}-${processid}|${level:uppercase=true}|${logger}|${message}${onexception:inner= ${exception:format=toString,Data}}`

---

##### HISTORYTARGET OPSHUNS

_maxCount_ - MAXIMUM AMOUNT OV STORD LOGS 4 ON-DEMAND HISTORY. NOT REQUIRD. DEFAULTS 2 `20` WHICH IZ GUD BALANCE 4 PROVIDIN INITIAL HISTORY, WHILE STILL KEEPIN IN MIND MEMS USAGE DAT COMEZ OUT OV STORAGE REQUIREMENTS. MUST BE GREATR THAN `0`.

---

## CAVEATS

BE CAREFUL WHEN U DECIDE 2 COMBINE `Debug` LOGGIN LEVEL OR BELOW IN UR `SteamTarget` WIF `steamID` DAT IZ TAKIN PART IN DA ASF PROCES. DIS CAN LEAD 2 POTENTIAL `StackOverflowException` CUZ ULL CREATE AN INFINITE LOOP OV ASF RECEIVIN GIVEN MESAGE, DEN LOGGIN IT THRU STEAM, RESULTIN IN ANOTHR MESAGE DAT NEEDZ 2 BE LOGGD. CURRENTLY TEH ONLY POSIBILITY 4 IT 2 HAPPEN IZ 2 LOG `Trace` LEVEL (WER ASF RECORDZ ITZ OWN CHAT MESAGEZ), OR `Debug` LEVEL WHILE ALSO RUNNIN ASF IN `Debug` MODE (WER ASF RECORDZ ALL STEAM PACKETS).

IN SHORT, IF UR `steamID` IZ TAKIN PART IN DA SAME ASF PROCES, DEN TEH `minlevel` LOGGIN LEVEL OV UR `SteamTarget` SHUD BE `Info` (OR `Debug` IF URE ALSO NOT RUNNIN ASF IN `Debug` MODE) AN ABOOV. ALTERNATIVELY U CAN DEFINE UR OWN `<when>` LOGGIN FILTERS IN ORDR 2 AVOID INFINITE LOGGIN LOOP, IF MODIFYIN LEVEL IZ NOT APPROPRIATE 4 UR CASE. DIS CAVEAT ALSO APPLIEZ 2 GROUP CHATS.