# COMMANDZ

ASF SUPPORTS VARIETY OV COMMANDZ, WHICH CAN BE USD 2 CONTROL BEHAVIOUR OV TEH PROCES AN BOT INSTANCEZ.

BELOW COMMANDZ CAN BE SENT 2 TEH BOT THRU VARIOUS DIFFERENT WAYS:
- THRU INTERACTIV ASF CONSOLE
- THRU STEAM PRIVATE/GROUP CHAT
- THRU R **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-lol-US)** INTERFACE

KEEP IN MIND DAT ASF INTERACSHUN REQUIREZ FRUM U 2 BE ELIGIBLE 4 DA COMMAND ACCORDIN 2 ASF PERMISHUNS. CHECK OUT `SteamUserPermissions` AN `SteamOwnerID` CONFIG PROPERTIEZ 4 MOAR DETAILS.

COMMANDZ EXECUTD THRU STEAM CHAT R AFFECTD BY `CommandPrefix` **[GLOBAL CONFIGURASHUN PROPERTY](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-lol-US#commandprefix)**, WHICH IZ `!` BY DEFAULT. DIS MEANZ DAT 4 EXECUTIN E.G. `status` COMMAND, U SHUD AKSHULLY RITE `!status` (OR CUSTOM `CommandPrefix` OV UR CHOICE DAT U SET INSTEAD). `CommandPrefix` IZ NOT MANDATORY WHEN USIN CONSOLE OR IPC AN CAN BE OMITTD.

---

### INTERACTIV CONSOLE

Starting with V4.0.0.9, ASF has support for interactive console, as long as you're not running ASF in [**`Headless`**](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#headless) mode. SIMPLY PRES `c` BUTN IN ORDR 2 ENABLE COMMAND MODE, TYPE UR COMMAND AN CONFIRM WIF ENTR.

![Screenshot](https://i.imgur.com/bH5Gtjq.png)

---

### STEAM CHAT

U CAN EXECUTE COMMAND 2 GIVEN ASF BOT ALSO THRU STEAM CHAT. OBVIOUSLY U CANT TALK 2 YOURSELF DIRECTLY, THEREFORE ULL NED AT LEAST WAN ANOTHR BOT AKOWNT IF U WANTS 2 EXECUTE COMMANDZ TARGETTIN UR MAIN.

![Screenshot](https://i.imgur.com/IvFRJ5S.png)

IN SIMILAR WAI U CAN ALSO USE GROUP CHAT OV GIVEN STEAM GROUP. KEEP IN MIND DAT DIS OPSHUN REQUIREZ PROPERLY SET `SteamMasterClanID` PROPERTY, IN WHICH CASE BOT WILL LISTEN 4 COMMANDZ ALSO ON GROUPS CHAT (AN JOIN IT IF NEEDD). DIS CAN ALSO BE USD 4 "TALKIN 2 YOURSELF" SINCE IT DOESNT REQUIRE DEDICATD BOT AKOWNT, AS OPPOSD 2 PRIVATE CHAT. U CAN SIMPLY SET `SteamMasterClanID` PROPERTY 2 UR NEWLY-CREATD GROUP, DEN GIV YOURSELF ACCES EITHR THRU `SteamOwnerID` OR `SteamUserPermissions` OV UR OWN BOT. DIS WAI ASF BOT (U) WILL JOIN GROUP AN CHAT OV UR SELECTD GROUP, AN LISTEN 2 COMMANDZ FRUM UR OWN AKOWNT. U CAN JOIN TEH SAME GROUP CHATROOM IN ORDR 2 ISSUE COMMANDZ 2 YOURSELF (AS ULL BE SENDIN COMMAND 2 CHATROOM, AN ASF INSTANCE SITTIN ON TEH SAME CHATROOM WILL RECEIV THEM, EVEN IF IT SHOWS ONLY AS UR AKOWNT BEAN THAR).

PLZ NOWT DAT SENDIN COMMAND 2 TEH GROUP CHAT ACTS LIEK RELAY. IF URE SAYIN `redeem X` 2 3 OV UR BOTS SITTIN TOGETHR WIF U ON TEH GROUP CHAT, ITLL RESULT IN DA SAME AS UD SAY `redeem X` 2 EVRY SINGLE WAN OV THEM PRIVATELY. IN MOST CASEZ **DIS AR TEH NOT WUT U WANTS**, AN INSTEAD U SHUD USE `given bot` COMMAND DAT IZ BEAN SENT 2 **A SINGLE BOT IN PRIVATE WINDOW**. ASF SUPPORTS GROUP CHAT, AS IN LOTZ DA CASEZ IT CAN BE USEFUL SOURCE 4 COMMUNICASHUN WIF UR ONLY BOT, BUT U SHUD ALMOST NEVR EXECUTE ANY COMMAND ON TEH GROUP CHAT IF THAR R 2 OR MOAR ASF BOTS SITTIN THAR, UNLES U FULLY UNDERSTAND ASF BEHAVIOUR WRITTEN HER AN U IN FACT WANTS 2 RELAY TEH SAME COMMAND 2 EVRY SINGLE BOT DAT IZ LISTENIN 2 U.

*AN EVEN IN DIS CASE U SHUD USE PRIVATE CHAT WIF `[Bots]` SYNTAX INSTEAD.*

---

### IPC

TEH MOST ADVANCD AN FLEXIBLE WAI OV EXECUTIN COMMANDZ, PERFIK 4 USR INTERACSHUN (ASF-UI) AS WELL AS THIRD-PARTY TOOLS OR SCRIPTIN (ASF API), REQUIREZ ASF 2 BE RUN IN `IPC` MODE, AN CLIENT EXECUTIN COMMAND THRU **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-lol-US)** INTERFACE.

![Screenshot](https://raw.githubusercontent.com/JustArchiNET/ASF-ui/main/.github/previews/commands.png)

---

## COMMANDZ

| COMMAND                                                              | ACCES           | DESCRIPSHUN                                                                                                                                                                                                                                                                                                   |
| -------------------------------------------------------------------- | --------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `2fa [Bots]`                                                         | `Master`        | GENERATEZ TEMPORARY **[2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication-lol-US)** TOKEN 4 GIVEN BOT INSTANCEZ.                                                                                                                                                              |
| `2fafinalize [Bots] <ActivationCode>`                          | `Master`        | Finalizes process of assigning new **[2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication#creation)** credentials for given bot instances, using SMS activation code.                                                                                                          |
| `2fafinalized [Bots] <ActivationCode>`                         | `Master`        | Imports already-finalized **[2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication#creation)** credentials for given bot instances, using 2FA token for verification.                                                                                                            |
| `2fafinalizedforce [Bots]`                                           | `Master`        | Imports already-finalized **[2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication#creation)** credentials for given bot instances, skipping 2FA token verification.                                                                                                             |
| `2fainit [Bots]`                                                     | `Master`        | STARTS PROCES OV ASSIGNIN NEW **[2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication-lol-US#creashun)** CREDENTIALS 4 GIVEN BOT INSTANCEZ.                                                                                                                                     |
| `2fano [Bots]`                                                       | `Master`        | DENIEZ ALL PENDIN **[2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication-lol-US)** CONFIRMASHUNS 4 GIVEN BOT INSTANCEZ.                                                                                                                                                        |
| `2faok [Bots]`                                                       | `Master`        | ACCEPTS ALL PENDIN **[2FA](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Two-factor-authentication-lol-US)** CONFIRMASHUNS 4 GIVEN BOT INSTANCEZ.                                                                                                                                                       |
| `addlicense [Bots] <Licenses>`                                 | `Operator`      | ACTIVATEZ GIVEN `licenses`, EXPLAIND **[BELOW](#addlicense-licensez)**, ON GIVEN BOT INSTANCEZ (FREE GAMEZ ONLY).                                                                                                                                                                                             |
| `balance [Bots]`                                                     | `Master`        | SHOWS WALLET BALANCE OV GIVEN BOT INSTANCEZ.                                                                                                                                                                                                                                                                  |
| `bgr [Bots]`                                                         | `Master`        | PRINTS INFORMASHUN BOUT **[BGR](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Background-games-redeemer-lol-US)** KEW OV GIVEN BOT INSTANCEZ.                                                                                                                                                           |
| `encrypt <encryptionMethod> <stringToEncrypt>`           | `Owner`         | ENCRYPTS TEH STRIN USIN PROVIDD CRYPTOGRAFIC METHOD - FURTHR EXPLAIND **[BELOW](#encrypt-command)**.                                                                                                                                                                                                          |
| `exit`                                                               | `Owner`         | STOPS WHOLE ASF PROCES.                                                                                                                                                                                                                                                                                       |
| `farm [Bots]`                                                        | `Master`        | RESTARTS CARDZ FARMIN MODULE 4 GIVEN BOT INSTANCEZ.                                                                                                                                                                                                                                                           |
| `fb [Bots]`                                                          | `Master`        | LISTS APPS BLACKLISTD FRUM AUTOMATIC FARMIN OV GIVEN BOT INSTANCEZ.                                                                                                                                                                                                                                           |
| `fbadd [Bots] <AppIDs>`                                        | `Master`        | ADDZ GIVEN `appIDs` 2 APPS BLACKLISTD FRUM AUTOMATIC FARMIN OV GIVEN BOT INSTANCEZ.                                                                                                                                                                                                                           |
| `fbrm [Bots] <AppIDs>`                                         | `Master`        | REMOVEZ GIVEN `appIDs` FRUM APPS BLACKLISTD FRUM AUTOMATIC FARMIN OV GIVEN BOT INSTANCEZ.                                                                                                                                                                                                                     |
| `fq [Bots]`                                                          | `Master`        | LISTS PRIORITY FARMIN KEW OV GIVEN BOT INSTANCEZ.                                                                                                                                                                                                                                                             |
| `fqadd [Bots] <AppIDs>`                                        | `Master`        | ADDZ GIVEN `appIDs` 2 PRIORITY FARMIN KEW OV GIVEN BOT INSTANCEZ.                                                                                                                                                                                                                                             |
| `fqrm [Bots] <AppIDs>`                                         | `Master`        | REMOVEZ GIVEN `appIDs` FRUM FARMIN KEW OV GIVEN BOT INSTANCEZ.                                                                                                                                                                                                                                                |
| `hash <hashingMethod> <stringToHash>`                    | `Owner`         | GENERATD HASH OV TEH STRIN USIN PROVIDD CRYPTOGRAFIC METHOD - FURTHR EXPLAIND **[BELOW](#hash-command)**.                                                                                                                                                                                                     |
| `help`                                                               | `FamilySharing` | SHOWS HALP (LINK 2 DIS PAEG).                                                                                                                                                                                                                                                                                 |
| `input [Bots] <Type> <Value>`                            | `Master`        | SETS GIVEN INPUT TYPE 2 GIVEN VALUE 4 GIVEN BOT INSTANCEZ, WERKZ ONLY IN `Headless` MODE - FURTHR EXPLAIND **[BELOW](#input-command)**.                                                                                                                                                                       |
| `level [Bots]`                                                       | `Master`        | SHOWS STEAM AKOWNT LEVEL OV GIVEN BOT INSTANCEZ.                                                                                                                                                                                                                                                              |
| `loot [Bots]`                                                        | `Master`        | SENDZ ALL `LootableTypes` STEAM COMMUNITY ITEMS OV GIVEN BOT INSTANCEZ 2 `Master` USR DEFIND IN THEIR `SteamUserPermissions` (WIF LOWEST STEAMID IF MOAR THAN WAN).                                                                                                                                           |
| `loot@ [Bots] <AppIDs>`                                        | `Master`        | SENDZ ALL `LootableTypes` STEAM COMMUNITY ITEMS MATCHIN GIVEN `AppIDs` OV GIVEN BOT INSTANCEZ 2 `Master` USR DEFIND IN THEIR `SteamUserPermissions` (WIF LOWEST STEAMID IF MOAR THAN WAN). DIS AR TEH TEH OPPOSIET OV `loot%`.                                                                                |
| `loot% [Bots] <AppIDs>`                                        | `Master`        | SENDZ ALL `LootableTypes` STEAM COMMUNITY ITEMS APART FRUM GIVEN `AppIDs` OV GIVEN BOT INSTANCEZ 2 `Master` USR DEFIND IN THEIR `SteamUserPermissions` (WIF LOWEST STEAMID IF MOAR THAN WAN). DIS AR TEH TEH OPPOSIET OV `loot@`.                                                                             |
| `loot^ [Bots] <AppID> <ContextID>`                       | `Master`        | SENDZ ALL STEAM ITEMS FRUM GIVEN `AppID` IN `ContextID` OV GIVEN BOT INSTANCEZ 2 `Master` USR DEFIND IN THEIR `SteamUserPermissions` (WIF LOWEST STEAMID IF MOAR THAN WAN).                                                                                                                                   |
| `mab [Bots]`                                                         | `Master`        | LISTS APPS BLACKLISTD FRUM AUTOMATIC TRADIN IN **[`MatchActively`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin-lol-US#matchactively)**.                                                                                                                                            |
| `mabadd [Bots] <AppIDs>`                                       | `Master`        | ADDZ GIVEN `appIDs` 2 APPS BLACKLISTD FRUM AUTOMATIC TRADIN IN **[`MatchActively`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin-lol-US#matchactively)**.                                                                                                                            |
| `mabrm [Bots] <AppIDs>`                                        | `Master`        | REMOVEZ GIVEN `appIDs` FRUM APPS BLACKLISTD FRUM AUTOMATIC TRADIN IN **[`MatchActively`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin-lol-US#matchactively)**.                                                                                                                      |
| `match [Bots]`                                                       | `Master`        | SPESHUL COMMAND 4 **[`ItemsMatcherPlugin`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin-lol-US#matchactively)** WHICH TRIGGERS `MatchActively` ROUTINE IMMEDIATELY.                                                                                                                 |
| `nickname [Bots] <Nickname>`                                   | `Master`        | CHANGEZ STEAM NICKNAME OV GIVEN BOT INSTANCEZ 2 GIVEN `nickname`.                                                                                                                                                                                                                                             |
| `owns [Bots] <Games>`                                          | `Operator`      | CHECKZ IF GIVEN BOT INSTANCEZ ALREADY OWN GIVEN `games`, EXPLAIND **[BELOW](#owns-games)**.                                                                                                                                                                                                                   |
| `pause [Bots]`                                                       | `Operator`      | PERMANENTLY PAUSEZ AUTOMATIC CARDZ FARMIN MODULE OV GIVEN BOT INSTANCEZ. ASF WILL NOT ATTEMPT 2 FARM CURRENT AKOWNT IN DIS SESHUN, UNLES U MANUALLY `resume` IT, OR RESTART TEH PROCES.                                                                                                                       |
| `pause~ [Bots]`                                                      | `FamilySharing` | TEMPORARILY PAUSEZ AUTOMATIC CARDZ FARMIN MODULE OV GIVEN BOT INSTANCEZ. FARMIN WILL BE AUTOMATICALLY RESUMD ON TEH NEXT PLAYIN EVENT, OR BOT DISCONNECT. U CAN `resume` FARMIN 2 UNPAUSE IT.                                                                                                                 |
| `pause& [Bots] <Seconds>`                                  | `Operator`      | TEMPORARILY PAUSEZ AUTOMATIC CARDZ FARMIN MODULE OV GIVEN BOT INSTANCEZ 4 GIVEN AMOUNT OV `seconds`. AFTR DELAY, CARDZ FARMIN MODULE IZ AUTOMATICALLY RESUMD.                                                                                                                                                 |
| `play [Bots] <AppIDs,GameName>`                                | `Master`        | SWITCHEZ 2 MANUAL FARMIN - LAUNCHEZ GIVEN `AppIDs` ON GIVEN BOT INSTANCEZ, OPSHUNALLY ALSO WIF CUSTOM `GameName`. IN ORDR 4 DIS FEACHUR 2 WERK PROPERLY, UR STEAM AKOWNT **MUST** OWN VALID LICENSE 2 ALL TEH `AppIDs` DAT U SPECIFY HER, DIS INCLUDEZ F2P GAMEZ AS WELL. USE `reset` OR `resume` 4 RETURNIN. |
| `points [Bots]`                                                      | `Master`        | Displays number of points in **[Steam points shop](https://store.steampowered.com/points/shop)**.                                                                                                                                                                                                             |
| `privacy [Bots] <Settings>`                                    | `Master`        | CHANGEZ **[STEAM PRIVACY SETTINGS](https://steamcommunity.com/my/edit/settings)** OV GIVEN BOT INSTANCEZ, 2 APPROPRIATELY SELECTD OPSHUNS EXPLAIND **[BELOW](#privacy-settings)**.                                                                                                                            |
| `redeem [Bots] <Keys>`                                         | `Operator`      | REDEEMS GIVEN CD-KEYS OR WALLET CODEZ ON GIVEN BOT INSTANCEZ.                                                                                                                                                                                                                                                 |
| `redeem^ [Bots] <Modes> <Keys>`                          | `Operator`      | REDEEMS GIVEN CD-KEYS OR WALLET CODEZ ON GIVEN BOT INSTANCEZ, USIN GIVEN `modes` EXPLAIND **[BELOW](#redeem-modez)**.                                                                                                                                                                                         |
| `reset [Bots]`                                                       | `Master`        | RESETS TEH PLAYIN STATUS BAK 2 ORIGINAL (PREVIOUS) STATE, TEH COMMAND IZ USD DURIN MANUAL FARMIN WIF `play` COMMAND.                                                                                                                                                                                          |
| `restart`                                                            | `Owner`         | RESTARTS ASF PROCES.                                                                                                                                                                                                                                                                                          |
| `resume [Bots]`                                                      | `FamilySharing` | RESUMEZ AUTOMATIC FARMIN OV GIVEN BOT INSTANCEZ.                                                                                                                                                                                                                                                              |
| `start [Bots]`                                                       | `Master`        | STARTS GIVEN BOT INSTANCEZ.                                                                                                                                                                                                                                                                                   |
| `stats`                                                              | `Owner`         | PRINTS PROCES STATISTICS, SUCH AS MANAGD MEMS USAGE.                                                                                                                                                                                                                                                          |
| `status [Bots]`                                                      | `FamilySharing` | PRINTS STATUS OV GIVEN BOT INSTANCEZ.                                                                                                                                                                                                                                                                         |
| `std`                                                                | `Owner`         | SPESHUL COMMAND 4 **[`SteamTokenDumperPlugin`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/SteamTokenDumperPlugin-lol-US)** WHICH TRIGGERS SUBMISHUN OV DATA IMMEDIATELY.                                                                                                                             |
| `stop [Bots]`                                                        | `Master`        | STOPS GIVEN BOT INSTANCEZ.                                                                                                                                                                                                                                                                                    |
| `tb [Bots]`                                                          | `Master`        | LISTS BLACKLISTD USERS FRUM TRADIN MODULE OV GIVEN BOT INSTANCEZ.                                                                                                                                                                                                                                             |
| `tbadd [Bots] <SteamIDs64>`                                    | `Master`        | BLACKLISTS GIVEN `steamIDs` FRUM TRADIN MODULE OV GIVEN BOT INSTANCEZ.                                                                                                                                                                                                                                        |
| `tbrm [Bots] <SteamIDs64>`                                     | `Master`        | REMOVEZ BLACKLIST OV GIVEN `steamIDs` FRUM TRADIN MODULE OV GIVEN BOT INSTANCEZ.                                                                                                                                                                                                                              |
| `transfer [Bots] <TargetBot>`                                  | `Master`        | SENDZ ALL `TransferableTypes` STEAM COMMUNITY ITEMS FRUM GIVEN BOT INSTANCEZ 2 TARGET BOT INSTANCE.                                                                                                                                                                                                           |
| `transfer@ [Bots] <AppIDs> <TargetBot>`                  | `Master`        | SENDZ ALL `TransferableTypes` STEAM COMMUNITY ITEMS MATCHIN GIVEN `AppIDs` FRUM GIVEN BOT INSTANCEZ 2 TARGET BOT INSTANCE. DIS AR TEH TEH OPPOSIET OV `transfer%`.                                                                                                                                            |
| `transfer% [Bots] <AppIDs> <TargetBot>`                  | `Master`        | SENDZ ALL `TransferableTypes` STEAM COMMUNITY ITEMS APART FRUM GIVEN `AppIDs` FRUM GIVEN BOT INSTANCEZ 2 TARGET BOT INSTANCE. DIS AR TEH TEH OPPOSIET OV `transfer@`.                                                                                                                                         |
| `transfer^ [Bots] <AppID> <ContextID> <TargetBot>` | `Master`        | SENDZ ALL STEAM ITEMS FRUM GIVEN `AppID` IN `ContextID` OV GIVEN BOT INSTANCEZ 2 TARGET BOT INSTANCE.                                                                                                                                                                                                         |
| `unpack [Bots]`                                                      | `Master`        | UNPACKZ ALL BOOSTR PACKZ STORD IN DA INVENTORY OV GIVEN BOT INSTANCEZ.                                                                                                                                                                                                                                        |
| `update [Channel]`                                                   | `Owner`         | CHECKZ GITHUB 4 NEW ASF RELEASE AN UPDATEZ 2 IT IF AVAILABLE. DIS AR TEH NORMALLY DUN AUTOMATICALLY EVRY `UpdatePeriod`. OPSHUNAL `Channel` ARGUMENT SPECIFIEZ TEH `UpdateChannel`, IF NOT PROVIDD DEFAULTS 2 TEH WAN SET IN GLOBAL CONFIG.                                                                   |
| `version`                                                            | `FamilySharing` | PRINTS VERSHUN OV ASF.                                                                                                                                                                                                                                                                                        |

---

### NOTEZ

ALL COMMANDZ R CASE-INSENSITIV, BUT THEIR ARGUMENTS (SUCH AS BOT NAMEZ) R USUALLY CASE-SENSITIV.

ARGUMENTS FOLLOW UNIX FILOSOFY, SQUARE BRACKETS `[Optional]` INDICATE DAT GIVEN ARGUMENT IZ OPSHUNAL, WHILE ANGLE BRACKETS `<Mandatory>` INDICATE DAT GIVEN ARGUMENT IZ MANDATORY. U SHUD REPLACE TEH ARGUMENTS DAT U WANTS 2 DECLARE, SUCH AS `[Bots]` OR `<Nickname>` WIF AKSHUL VALUEZ DAT U WANTS 2 ISSUE TEH COMMAND WIF, OMITTIN TEH BRACEZ.

`[Bots]` ARGUMENT, AS INDICATD BY TEH BRACKETS, IZ OPSHUNAL IN ALL COMMANDZ. WHEN SPECIFID, COMMAND IZ EXECUTD ON GIVEN BOTS. WHEN OMITTD, COMMAND IZ EXECUTD ON CURRENT BOT DAT RECEIVEZ TEH COMMAND. IN OTHR WERDZ, `status A` SENT 2 BOT `B` IZ TEH SAME AS SENDIN `status` 2 BOT `A`, BOT `B` IN DIS CASE ACTS ONLY AS PROXY. DIS CAN ALSO BE USD 4 SENDIN COMMANDZ 2 BOTS DAT R UNAVAILABLE OTHERWIZE, 4 EXAMPLE STARTIN STOPPD BOTS, OR EXECUTIN ACSHUNS ON UR MAIN AKOWNT (DAT URE USIN 4 EXECUTIN TEH COMMANDZ).

**ACCES** OV TEH COMMAND DEFINEZ **MINIMUM** `EPermission` OV `SteamUserPermissions` DAT IZ REQUIRD 2 USE TEH COMMAND, WIF AN EXCEPSHUN OV `Owner` WHICH IZ `SteamOwnerID` DEFIND IN GLOBAL CONFIGURASHUN FILE (AN HIGHEST PERMISHUN AVAILABLE).

PLURAL ARGUMENTS, SUCH AS `[Bots]`,`<Keys>` OR `<AppIDs>` MEEN DAT COMMAND SUPPORTS MULTIPLE ARGUMENTS OV GIVEN TYPE, SEPARATD BY COMMA. 4 EXAMPLE, `status [Bots]` CAN BE USD AS `status MyBot,MyOtherBot,Primary`. DIS WILL CAUSE GIVEN COMMAND 2 BE EXECUTD ON **ALL TARGET BOTS** IN DA SAME WAI AS UD SEND `status` 2 EACH BOT IN SEPARATE CHAT WINDOW. PLZ NOWT DAT THAR IZ NO SPACE AFTR `,`.

ASF USEZ ALL WHITESPACE CHARACTERS AS POSIBLE DELIMITERS 4 COMMAND, SUCH AS SPACE AN NEWLINE CHARACTERS. DIS MEANZ DAT U DOAN HAS 2 USE SPACE 4 DELIMITIN UR ARGUMENTS, U CAN AS WELL USE ANY OTHR WHITESPACE CHARACTR (SUCH AS TAB OR NEW LINE).

ASF WILL "JOIN" EXTRA OUT-OV-RANGE ARGUMENTS 2 PLURAL TYPE OV TEH LAST IN-RANGE ARGUMENT. DIS MEANZ DAT `redeem bot key1 key2 key3` 4 `redeem [Bots] <Keys>` WILL WERK EGSAKTLY TEH SAME AS `redeem bot key1,key2,key3`. TOGETHR WIF ACCEPTIN NEWLINE AS COMMAND DELIMITR, DIS MAKEZ IT POSIBLE 4 U 2 RITE `redeem bot` DEN PASTE LIST OV KEYS SEPARATD BY ANY ACCEPTABLE DELIMITR CHARACTR (SUCH AS NEWLINE), OR STANDARD `,` ASF DELIMITR. KEEP IN MIND DAT DIS TRICK CAN BE USD ONLY 4 COMMAND VARIANT DAT USEZ TEH MOST AMOUNT OV ARGUMENTS (SO SPECIFYIN `[Bots]` IZ MANDATORY IN DIS CASE).

AS UVE READ ABOOV, SPACE CHARACTR IZ BEAN USD AS DELIMITR 4 COMMAND, THEREFORE IT CANT BE USD IN ARGUMENTS. HOWEVR, ALSO AS STATD ABOOV, ASF CAN JOIN OUT-OV-RANGE ARGUMENTS, WHICH MEANZ DAT URE AKSHULLY ABLE 2 USE SPACE CHARACTR IN ARGUMENT DAT IZ DEFIND AS LAST WAN 4 GIVEN COMMAND. 4 EXAMPLE, `nickname bob Great Bob` WILL PROPERLY SET NICKNAME OV `bob` BOT 2 "Great Bob". IN DA SIMILAR WAI U CAN CHECK NAMEZ CONTAININ SPACEZ IN `owns` COMMAND.

---

SUM COMMANDZ R ALSO AVAILABLE WIF THEIR ALIASEZ, MOSTLY 2 SAVE U ON TYPIN OR AKOWNT 4 DIFFERENT DIALECTS:

| COMMAND      | ALIAS        |
| ------------ | ------------ |
| `addlicense` | `addlicence` |
| `owns ASF`   | `oa`         |
| `status ASF` | `sa`         |
| `redeem`     | `r`          |
| `redeem^`    | `r^`         |

---

### `[Bots]` ARGUMENT

`[Bots]` ARGUMENT IZ SPESHUL VARIANT OV PLURAL ARGUMENT, AS IN ADDISHUN 2 ACCEPTIN MULTIPLE VALUEZ IT ALSO OFFERS EXTRA FUNCSHUNALITY.

FURST AN FOREMOST, THAR IZ SPESHUL `ASF` KEYWORD WHICH ACTS AS "ALL BOTS IN DA PROCES", SO `status ASF` COMMAND IZ EQUAL 2 `status all,your,bots,listed,here`. DIS CAN ALSO BE USD 2 EASILY IDENTIFY TEH BOTS DAT U HAS ACCES 2, AS `ASF` KEYWORD, DESPITE OV TARGETIN ALL BOTS, WILL RESULT IN RESPONSE ONLY FRUM DOSE BOTS DAT U CAN AKSHULLY SEND TEH COMMAND 2.

`[Bots]` ARGUMENT SUPPORTS SPESHUL "RANGE" SYNTAX, WHICH ALLOWS U 2 CHOOSE RANGE OV BOTS MOAR EASILY. The general syntax for `[Bots]` in this case is `[FirstBot]..[LastBot]`. At least one of the arguments must be defined. When using `<FirstBot>..`, all bots starting from `FirstBot` are affected. When using `..<LastBot>`, all bots until `LastBot` are affected. When using `<FirstBot>..<LastBot>`, all bots within range from `FirstBot` until `LastBot` are affected. 4 EXAMPLE, IF U HAS BOTS NAMD `A, B, C, D, E, F`, U CAN EXECUTE `status B..E`, WHICH IZ EQUAL 2 `status B,C,D,E` IN DIS CASE. WHEN USIN DIS SYNTAX, ASF WILL USE ALFABETICAL SORTIN IN ORDR 2 DETERMINE WHICH BOTS R IN UR SPECIFID RANGE. Arguments must be valid bot names recognized by ASF, otherwise range syntax is entirely skipped.

IN ADDISHUN 2 RANGE SYNTAX ABOOV, `[Bots]` ARGUMENT ALSO SUPPORTS **[REGEX](https://en.wikipedia.org/wiki/Regular_expression)** MATCHIN. U CAN ACTIVATE REGEX PATTERN BY USIN `r!<Pattern>`AS BOT NAYM, WER `r!` IZ ASF ACTIVATOR 4 REGEX MATCHIN, AN `<Pattern>` IZ UR REGEX PATTERN. AN EXAMPLE OV REGEX-BASD BOT COMMAND WUD BE `status r!^\d{3}` WHICH WILL SEND `status` COMMAND 2 BOTS DAT HAS NAYM MADE OUT OV 3 DIGITS (E.G. `123` AN `981`). FEELZ FREE 2 TAEK LOOK AT TEH **[DOCS](https://docs.microsoft.com/dotnet/standard/base-types/regular-expression-language-quick-reference)** 4 FURTHR EXPLANASHUN AN MOAR EXAMPLEZ OV AVAILABLE REGEX PATTERNS.

---

## `privacy` SETTINGS

`<Settings>` ARGUMENT ACCEPTS **UP 2 7** DIFFERENT OPSHUNS, SEPARATD AS USUAL WIF STANDARD COMMA ASF DELIMITR. DOSE R, IN ORDR:

| ARGUMENT | NAYM           | CHILD OV   |
| -------- | -------------- | ---------- |
| 1        | Profile        |            |
| 2        | OwnedGames     | Profile    |
| 3        | Playtime       | OwnedGames |
| 4        | FriendsList    | Profile    |
| 5        | Inventory      | Profile    |
| 6        | InventoryGifts | Inventory  |
| 7        | Comments       | Profile    |

4 DESCRIPSHUN OV ABOOV FIELDZ, PLZ VISIT **[STEAM PRIVACY SETTINGS](https://steamcommunity.com/my/edit/settings)**.

WHILE VALID VALUEZ 4 ALL OV THEM R:

| VALUE | NAYM          |
| ----- | ------------- |
| 1     | `Private`     |
| 2     | `FriendsOnly` |
| 3     | `Public`      |

U CAN USE EITHR CASE-INSENSITIV NAYM, OR NUMERIC VALUE. ARGUMENTS DAT WUZ OMITTD WILL DEFAULT 2 BEAN SET 2 `Private`. IZ IMPORTANT 2 NOWT RELASHUN TWEEN CHILD AN PARENT OV ARGUMENTS SPECIFID ABOOV, AS CHILD CAN NEVR HAS MOAR OPEN PERMISHUN THAN ITZ PARENT. 4 EXAMPLE, U **CANT** HAS `Public` GAMEZ OWND WHILE HAVIN `Private` PROFILE.

### EXAMPLE

IF U WANTS 2 SET **ALL** PRIVACY SETTINGS OV UR BOT NAMD `Main` 2 `Private`, U CAN USE EITHR OV BELOW:

```text
privacy Main 1
privacy Main Private
```

DIS AR TEH CUZ ASF WILL AUTOMATICALLY ASSUME ALL OTHR SETTINGS 2 BE `Private`, SO THAR IZ NO NED 2 INPUT THEM. ON TEH OTHR HAND, IF UD LIEK 2 SET ALL PRIVACY SETTINGS 2 `Public`, DEN U SHUD USE ANY OV BELOW:

```text
privacy Main 3,3,3,3,3,3,3
privacy Main Public,Public,Public,Public,Public,Public,Public
```

DIS WAI U CAN ALSO SET INDEPENDENT OPSHUNS HOWEVR U LIEK:

```text
privacy Main Public,FriendsOnly,Private,Public,Public,Private,Public
```

TEH ABOOV WILL SET PROFILE 2 PUBLIC, OWND GAMEZ 2 FRENZ ONLY, PLAYTIME 2 PRIVATE, FRENZ LIST 2 PUBLIC, INVENTORY 2 PUBLIC, INVENTORY GIFTS 2 PRIVATE AN PROFILE COMMENTS 2 PUBLIC. U CAN ACHIEVE TEH SAME WIF NUMERIC VALUEZ IF U WANTS 2.

---

## `addlicense` LICENSEZ

`addlicense` COMMAND SUPPORTS 2 DIFFERENT LICENSE TYPEZ, DOSE R:

| TYPE  | ALIAS | EXAMPLE      | DESCRIPSHUN                                                           |
| ----- | ----- | ------------ | --------------------------------------------------------------------- |
| `app` | `a`   | `app/292030` | GAME DETERMIND BY ITZ UNIQUE `appID`.                                 |
| `sub` | `s`   | `sub/47807`  | PACKAGE CONTAININ WAN OR MOAR GAMEZ, DETERMIND BY ITZ UNIQUE `subID`. |

TEH DISTINCSHUN IZ IMPORTANT, AS ASF WILL USE STEAM NETWORK ACTIVASHUN 4 APPS, AN STEAM STORE ACTIVASHUN 4 PACKAGEZ. DOSE 2 R NOT COMPATIBLE WIF EACH OTHR, TYPICALLY ULL USE APPS 4 FREE WEEKENDZ AN PERMANENTLY F2P GAMEZ, AN PACKAGEZ OTHERWIZE.

WE RECOMMEND 2 EXPLICITLY DEFINE TEH TYPE OV EACH ENTRY IN ORDR 2 AVOID AMBIGUOUS RESULTS, BUT 4 DA BAKWARDZ COMPATIBILITY, IF U SUPPLY INVALID TYPE OR OMIT IT ENTIRELY, ASF WILL ASSUME DAT U ASK 4 `sub` IN DIS CASE. U CAN ALSO QUERY WAN OR MOAR OV TEH LICENSEZ AT TEH SAME TIEM, USIN STANDARD ASF `,` DELIMITR.

COMPLETE COMMAND EXAMPLE:

```text
addlicense ASF app/292030,sub/47807
```

---

## `owns` GAMEZ

`owns` COMMAND SUPPORTS SEVERAL DIFFERENT GAME TYPEZ 4 `<games>` ARGUMENT DAT CAN BE USD, DOSE R:

| TYPE    | ALIAS | EXAMPLE          | DESCRIPSHUN                                                                                                                                                                                                                                                    |
| ------- | ----- | ---------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `app`   | `a`   | `app/292030`     | GAME DETERMIND BY ITZ UNIQUE `appID`.                                                                                                                                                                                                                          |
| `sub`   | `s`   | `sub/47807`      | PACKAGE CONTAININ WAN OR MOAR GAMEZ, DETERMIND BY ITZ UNIQUE `subID`.                                                                                                                                                                                          |
| `regex` | `r`   | `regex/^\d{4}:` | **[REGEX](https://en.wikipedia.org/wiki/Regular_expression)** APPLYIN 2 TEH GAMEZ NAYM, CASE-SENSITIV. C TEH **[DOCS](https://docs.microsoft.com/dotnet/standard/base-types/regular-expression-language-quick-reference)** 4 COMPLETE SYNTAX AN MOAR EXAMPLEZ. |
| `name`  | `n`   | `name/Witcher`   | PART OV TEH GAMEZ NAYM, CASE-INSENSITIV.                                                                                                                                                                                                                       |

WE RECOMMEND 2 EXPLICITLY DEFINE TEH TYPE OV EACH ENTRY IN ORDR 2 AVOID AMBIGUOUS RESULTS, BUT 4 DA BAKWARDZ COMPATIBILITY, IF U SUPPLY INVALID TYPE OR OMIT IT ENTIRELY, ASF WILL ASSUME DAT U ASK 4 `app` IF UR INPUT IZ NUMBR, AN `name` OTHERWIZE. U CAN ALSO QUERY WAN OR MOAR OV TEH GAMEZ AT TEH SAME TIEM, USIN STANDARD ASF `,` DELIMITR.

COMPLETE COMMAND EXAMPLE:

```text
owns ASF app/292030,name/Witcher
```

---

## `redeem^` MODEZ

`redeem^` COMMAND ALLOWS U 2 FINE-TUNE MODEZ DAT WILL BE USD 4 WAN SINGLE REDEEM SCENARIO. DIS WERKZ AS TEMPORARY OVERRIDE OV `RedeemingPreferences` **[BOT CONFIG PROPERTY](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-lol-US#bot-config)**.

`<Modes>` ARGUMENT ACCEPTS MULTIPLE MODE VALUEZ, SEPARATD AS USUAL BY COMMA. AVAILABLE MODE VALUEZ R SPECIFID BELOW:

| VALUE | NAYM                  | DESCRIPSHUN                                                                  |
| ----- | --------------------- | ---------------------------------------------------------------------------- |
| FAWK  | ForceAssumeWalletKey  | FORCEZ `AssumeWalletKeyOnBadActivationCode` REDEEMIN PREFERENCE 2 BE ENABLD  |
| FD    | ForceDistributing     | FORCEZ `Distributing` REDEEMIN PREFERENCE 2 BE ENABLD                        |
| FF    | ForceForwarding       | FORCEZ `Forwarding` REDEEMIN PREFERENCE 2 BE ENABLD                          |
| FKMG  | ForceKeepMissingGames | FORCEZ `KeepMissingGames` REDEEMIN PREFERENCE 2 BE ENABLD                    |
| SAWK  | SkipAssumeWalletKey   | FORCEZ `AssumeWalletKeyOnBadActivationCode` REDEEMIN PREFERENCE 2 BE DISABLD |
| SD    | SkipDistributing      | FORCEZ `Distributing` REDEEMIN PREFERENCE 2 BE DISABLD                       |
| SF    | SkipForwarding        | FORCEZ `Forwarding` REDEEMIN PREFERENCE 2 BE DISABLD                         |
| SI    | SkipInitial           | SKIPS KEY REDEMPSHUN ON INITIAL BOT                                          |
| SKMG  | SkipKeepMissingGames  | FORCEZ `KeepMissingGames` REDEEMIN PREFERENCE 2 BE DISABLD                   |
| V     | Validate              | VALIDATEZ KEYS 4 PROPR FORMAT AN AUTOMATICALLY SKIPS INVALID ONEZ            |

4 EXAMPLE, WED LIEK 2 REDEEM 3 KEYS ON ANY OV R BOTS DAT DOAN OWN GAMEZ YET, BUT NOT R `primary` BOT. 4 ACHIEVIN DAT WE CAN USE:

`redeem^ primary FF,SI key1,key2,key3`

IZ IMPORTANT 2 NOWT DAT ADVANCD REDEEM OVERRIDEZ ONLY DOSE `RedeemingPreferences` DAT U **SPECIFY IN DA COMMAND**. 4 EXAMPLE, IF UVE ENABLD `Distributing` IN UR `RedeemingPreferences` DEN THAR WILL BE NO DIFFERENCE WHETHR U USE `FD` MODE OR NOT, CUZ DISTRIBUTIN WILL BE ALREADY ACTIV REGARDLES, DUE 2 `RedeemingPreferences` DAT U USE. DIS AR TEH Y EACH FORCIBLY ENABLD OVERRIDE ALSO HAS FORCIBLY DISABLD WAN, U CAN DECIDE YOURSELF IF U PREFR 2 OVERRIDE DISABLD WIF ENABLD, OR VICE VERSA.

---

## `encrypt` COMMAND

`encrypt` COMMAND ALLOWS U 2 ENCRYPT ARBITRARY STRINGS USIN ASFS ENCRYPSHUN METHODZ. `<encryptionMethod>` MUST BE WAN OV TEH ENCRYPSHUN METHODZ SPECIFID AN EXPLAIND IN **[SECURITY](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security-lol-US)** SECSHUN. WE RECOMMEND 2 USE DIS COMMAND THRU SECURE CHANNELS (ASF CONSOLE OR IPC INTERFACE, WHICH ALSO HAS DEDICATD API ENDPOINT 4 IT), AS OTHERWIZE SENSITIV DETAILS MITE GIT LOGGD BY VARIOUS THIRD-PARTIEZ (SUCH AS CHAT MESAGEZ BEAN LOGGD BY STEAM SERVERS).

---

## `hash` COMMAND

`hash` COMMAND ALLOWS U 2 GENERATE HASHEZ OV ARBITRARY STRINGS USIN ASFS HASHIN METHODZ. `<hashingMethod>` MUST BE WAN OV TEH HASHIN METHODZ SPECIFID AN EXPLAIND IN **[SECURITY](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Security-lol-US)** SECSHUN. WE RECOMMEND 2 USE DIS COMMAND THRU SECURE CHANNELS (ASF CONSOLE OR IPC INTERFACE, WHICH ALSO HAS DEDICATD API ENDPOINT 4 IT), AS OTHERWIZE SENSITIV DETAILS MITE GIT LOGGD BY VARIOUS THIRD-PARTIEZ (SUCH AS CHAT MESAGEZ BEAN LOGGD BY STEAM SERVERS).

---

## `input` COMMAND

`input` COMMAND CAN BE USD ONLY IN `Headless` MODE, 4 INPUTTIN GIVEN DATA VIA **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-lol-US)** OR STEAM CHAT WHEN ASF IZ RUNNIN WITHOUT SUPPORT 4 USR INTERACSHUN.

GENERAL SYNTAX IZ `input [Bots] <Type> <Value>`.

`<Type>` IZ CASE-INSENSITIV AN DEFINEZ INPUT TYPE RECOGNIZD BY ASF. CURRENTLY ASF RECOGNIZEZ FOLLOWIN TYPEZ:

| TYPE                    | DESCRIPSHUN                                                         |
| ----------------------- | ------------------------------------------------------------------- |
| Login                   | `SteamLogin` BOT CONFIG PROPERTY, IF MISIN FRUM CONFIG.             |
| Password                | `SteamPassword` BOT CONFIG PROPERTY, IF MISIN FRUM CONFIG.          |
| SteamGuard              | AUTH CODE SENT ON UR E-MAIL IF URE NOT USIN 2FA.                    |
| SteamParentalCode       | `SteamParentalCode` BOT CONFIG PROPERTY, IF MISIN FRUM CONFIG.      |
| TwoFactorAuthentication | 2FA TOKEN GENERATD FRUM UR MOBILE, IF URE USIN 2FA BUT NOT ASF 2FA. |
| DeviceConfirmation      | DETERMINEZ WHETHR CONFIRMASHUN POPUP 4 LOGIN WUZ ACCEPTD            |

`<Value>` IZ VALUE SET 4 GIVEN TYPE. CURRENTLY ALL VALUEZ R STRINGS.

### EXAMPLE

LETS SAY DAT WE HAS BOT DAT IZ PROTECTD BY STEAMGUARD IN NON-2FA MODE. WE WANTS 2 LAUNCH DAT BOT WIF `Headless` SET 2 `true`.

IN ORDR 2 DO DAT, WE NED 2 EXECUTE FOLLOWIN COMMANDZ:

`start MySteamGuardBot` -> BOT WILL ATTEMPT 2 LOG IN, FAIL DUE 2 AUTHCODE NEEDD, DEN STOP DUE 2 RUNNIN IN `Headless` MODE. WE NED DIS IN ORDR 2 MAK STEAM NETWORK SEND US AUTH CODE ON R E-MAIL - IF THAR WUZ NO NED 4 DAT, WED SKIP DIS STEP ENTIRELY.

`input MySteamGuardBot SteamGuard ABCDE` -> WE SET `SteamGuard` INPUT OV `MySteamGuardBot` BOT 2 `ABCDE`. OV COURSE, `ABCDE` IN DIS CASE IZ AUTH CODE DAT WE GOT ON R E-MAIL.

`start MySteamGuardBot` -> WE START R (STOPPD) BOT AGAIN, DIS TIEM IT AUTOMATICALLY USEZ AUTH CODE DAT WE SET IN PREVIOUS COMMAND, PROPERLY LOGGIN IN, DEN CLEARIN IT.

IN DA SAME WAI WE CAN ACCES 2FA-PROTECTD BOTS (IF THEYRE NOT USIN ASF 2FA), AS WELL AS SETTIN OTHR REQUIRD PROPERTIEZ DURIN RUNTIME.