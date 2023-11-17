# 高效能設定

這與&#8203;**[低記憶體設定](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup-zh-TW)**&#8203;完全相反，若您想進一步提高ASF的效能（就CPU速度方面），請遵照下列指示。這可能會增加記憶體使用量。

---

ASF已經嘗試在一般的平衡性中考慮效能優先，因此您沒有很多提高效能的餘地，但您也不是完全沒有其他選擇。 但請注意，這些選項預設是未啟用，這代表它們不能在大多數情形下保證平衡性，因此，您應該自行決定是否能夠接受它們所造成的記憶體增加。

---

## 執行環境調整（進階）

下列技巧&#8203;**涉及嚴重的記憶體及啟動時間的增加**&#8203;，因此應謹慎使用。

套用這些設定的建議方法，是設定&#8203;`DOTNET_`&#8203;環境屬性。 當然，您也可以使用其他方法，例如&#8203;`runtimeconfig.json`&#8203;，但有些設定無法如此設定。除此之外，ASF會在每次更新時，將您的自訂&#8203;`runtimeconfig.json`&#8203;取代成自己的檔案，因此，我們建議使用環境屬性，這樣您在啟動程序前就可以輕鬆設定。

.NET執行環境使您能夠以多種方法&#8203;**[調整垃圾回收](https://learn.microsoft.com/zh-tw/dotnet/core/runtime-config/garbage-collector)**&#8203;，依據您的需求高效微調垃圾回收（GC）程序。 我們記錄了下列我們認為特別重要的屬性。

### [`gcServer`](https://docs.microsoft.com/zh-tw/dotnet/core/run-time-config/garbage-collector#flavors-of-garbage-collection)

> 設定應用程式使用工作站垃圾回收或伺服器垃圾回收。

您可以在&#8203;**[記憶體回收的基本概念](https://learn.microsoft.com/zh-tw/dotnet/standard/garbage-collection/fundamentals)**&#8203;中閱讀伺服器GC的詳細資訊。

ASF預設使用工作站垃圾回收。 這主要是因為記憶體的使用與效能間的平衡良好，這對於執行少數Bot來說綽綽有餘，因為通常單個並行的背景GC執行緒，足以快速處理所有由ASF分配的記憶體。

但是如至今日我們通常擁有很多CPU核心，使ASF也因此受益，因為在每個CPU vCore中都能有一個專用的GC執行緒。 這可以大大地提高ASF執行繁重工作時的效能，例如剖析徽章頁面或物品庫，因為每個CPU vCore都可以提供協助，而不只是2個（主執行緒及GC）。 對於具有3個或更多CPU vCore的設備，建議使用伺服器GC；若您的設備只有1個CPU vCore，則會自動強制使用工作站GC；若您正好有2個，您可以考慮嘗試使用兩者（結果可能會不同）。

伺服器GC本身不會因為只處於活動狀態而造成巨量的記憶體消耗，但它具有更大的生成大小，因此更不會把記憶體還給作業系統。 您可能會發現自己處於一個尷尬情形，伺服器GC能顯著提高效能，使您希望繼續使用它，但同時您又將無法承受使用它帶來的巨量記憶體消耗。 幸運的是，將&#8203;**[`GCLatencyLevel`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup-zh-TW#gclatencylevel)**&#8203;設定屬性設定成&#8203;`0`&#8203;，是個「兩全其美」的方法，它仍會啟用伺服器GC，但會限制生成大小並更在意記憶體的消耗。 或者，您也許可以嘗試另外一個屬性，&#8203;**[`GCHeapHardLimitPercent`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup-zh-TW#gcheaphardlimitpercent)**&#8203;，或同時啟用這兩個選項。

但是，如果記憶體對您來說不是問題（因為GC仍會依據您的可用記憶體來自行調整），那麼最好不要更改這些屬性，以達到最高效能。

### **[`DOTNET_TieredPGO`](https://docs.microsoft.com/zh-tw/dotnet/core/run-time-config/compilation#profile-guided-optimization)**

> 這項設定可讓您在.NET 6和更新版本中（PGO），啟用動態或階層式特性指引優化。

預設為停用。 簡而言之，這會使JIT使用更多時間來分析ASF的代碼及其模式，以便為您的典型使用方式來生成最佳化的上級程式碼。 若您想深入了解有關此設定的資訊，請造訪&#8203;**[Performance Improvements in .NET 6](https://devblogs.microsoft.com/dotnet/performance-improvements-in-net-6)**&#8203;。

### **[`DOTNET_ReadyToRun`](https://docs.microsoft.com/zh-tw/dotnet/core/run-time-config/compilation#readytorun)**

> 設定.NET Core執行時間是否針對具有可用ReadyToRun資料的映射使用預先編譯的程式碼。 停用此選項會強制執行時間以JIT編譯架構程式碼。

預設為啟用。 停用這個選項但同時啟用&#8203;`DOTNET_TieredPGO`&#8203;可以使您將特性指引最佳化套用至整個.NET平台，而不只於ASF程式碼中。

---

您可以透過設定適當的環境變數來啟用所選的屬性。 舉例來說，在Linux（Shell）上：

```shell
export DOTNET_gcServer=1

export DOTNET_TieredPGO=1
export DOTNET_ReadyToRun=0

./ArchiSteamFarm # 用於特定作業系統的組建版本
./ArchiSteamFarm.sh # 用於 Generic 組建版本
```

或在Windows（PowerShell）上：

```powershell
$Env:DOTNET_gcServer=1

$Env:DOTNET_TieredPGO=1
$Env:DOTNET_ReadyToRun=0

.\ArchiSteamFarm.exe # 用於特定作業系統的組建版本
.\ArchiSteamFarm.cmd # 用於 Generic 組建版本
```

---

## 最佳化建議

- 確保您使用的是&#8203;`OptimizationMode`&#8203;的預設值，為&#8203;`MaxPerformance`&#8203;。 這是到現在最重要的設定，因為使用&#8203;`MinMemoryUsage`&#8203;值會對效能產生重大影響。
- 啟用伺服器GC。 與工作站GC相比，透過明顯的記憶體增加，可以一眼看出伺服器GC為活動狀態。 這將為您設備上的每個CPU執行緒生成一個GC執行緒，以在最高速度下平行執行GC運算。
- 若您無法承擔伺服器GC所帶來的記憶體消耗，可以考慮調整&#8203;**[`GCLatencyLevel`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup-zh-TW#gclatencylevel)**&#8203;和／或&#8203;**[`GCHeapHardLimitPercent`](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Low-memory-setup-zh-TW#gcheaphardlimitpercent)**&#8203;來達成兩全。 但是，若您能承受這樣的記憶體消耗，那麼最好讓它維持預設狀態⸺伺服器GC在執行期間已自行調整且足夠智慧，在您的作業系統真正需要它時，能使用更少的記憶體。
- 您還可以考慮透過上述其他的&#8203;`DOTNET_`&#8203;屬性來進行額外調整，以增加最佳化來減少啟動時間。

套用上述建議，可以使您擁有卓越的ASF效能，在即使啟用了成百上千個Bot後，也能保有快如閃電的效能。 CPU不再成為瓶頸，因為ASF能夠在需要時發揮您CPU的全部能力，將所需時間減少到最低限度。 若要再更進一步就只能升級CPU及RAM了。