using System;
using System.Collections.Generic;
using System.Composition;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using ArchiSteamFarm.Core;
using ArchiSteamFarm.Plugins.Interfaces;
using ArchiSteamFarm.Steam;
using ArchiSteamFarm.Steam.Data;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

using JetBrains.Annotations;

namespace GetInventoryPlugin;

#pragma warning disable CA1812 // ASF uses this class during runtime
[UsedImplicitly]
internal sealed class GetInventoryPlugin : IBotCommand2 {
	public string Name => nameof(GetInventoryPlugin);
	public string RepositoryName => "yasathedog123/ASF-GetInventoryPlugin";
	public Version Version => typeof(GetInventoryPlugin).Assembly.GetName().Version ?? throw new InvalidOperationException(nameof(Version));

	public Task OnLoaded() {
		ASF.ArchiLogger.LogGenericInfo($"Hello {Name}!");

		return Task.CompletedTask;
	}

	public async Task<string?> OnBotCommand(Bot bot, EAccess access, string message, string[] args, ulong steamID = 0) {
		long totalNormalCards = 0;
		long totalFoilCards = 0;
		long totalGems = 0;

		switch (args[0].ToUpperInvariant()) {
			case "GETINVENTORY" when access >= EAccess.FamilySharing:
				try {
					await foreach (Asset item in Bot.GetBot(args[1]).ArchiWebHandler.GetInventoryAsync().ConfigureAwait(false)) {
						if (item.Type == EAssetType.TradingCard) {
							totalNormalCards += 1;
						}

						if (item.Type == EAssetType.FoilTradingCard) {
							totalFoilCards += 1;
						}

						if (item.Type == EAssetType.SteamGems) {
							totalGems += item.Amount;
						}
					}
				} catch (Exception e) {
					totalNormalCards = 0;
					totalFoilCards = 0;
					totalGems = 0;

					try {
						await foreach (Asset item in bot.ArchiWebHandler.GetInventoryAsync().ConfigureAwait(false)) {
							if (item.Type == EAssetType.TradingCard) {
								totalNormalCards += 1;
							}

							if (item.Type == EAssetType.FoilTradingCard) {
								totalFoilCards += 1;
							}

							if (item.Type == EAssetType.SteamGems) {
								totalGems += item.Amount;
							}
						}
					} catch (Exception err) {
						ASF.ArchiLogger.LogGenericError($"A Error Has Occured:\n{err}");

						return "A Error has occured";
					}
				}

				return $"Found a total of {totalNormalCards} Normal Cards and a total of {totalFoilCards} Foil Cards and a total of {totalGems} Gems";
			default:
				return null;
		}
	}
}
#pragma warning restore CA1812 // ASF uses this class during runtime
