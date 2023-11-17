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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;



#pragma warning disable CA1812 // ASF uses this class during runtime

namespace GetInventoryPlugin {
	// In order for your plugin to work, it must export generic ASF's IPlugin interface
	[Export(typeof(IPlugin))]

	[SuppressMessage("ReSharper", "MemberCanBeFileLocal")]
	internal sealed class GetInventoryPlugin : IASF, IBotCommand2, IBotModules {
		public string Name => nameof(GetInventoryPlugin);
		public Version Version => typeof(GetInventoryPlugin).Assembly.GetName().Version ?? throw new InvalidOperationException(nameof(Version));

		// Plugins can expose custom properties for our GET /Api/Plugins API call, simply annotate them with [JsonProperty] (or keep public)
		[JsonProperty]
		public bool CustomIsEnabledField { get; private set; } = true;
		public ConfiguredCancelableAsyncEnumerable<Asset> GetInventory { get; private set; }

		// This method, apart from being called before any bot initialization takes place, allows you to read custom global config properties that are not recognized by ASF
		// Thanks to that, you can extend default ASF config with your own stuff, then parse it here in order to customize your plugin during runtime
		// Keep in mind that, as noted in the interface, additionalConfigProperties can be null if no custom, unrecognized properties are found by ASF, you should handle that case appropriately
		// In addition to that, this method also guarantees that all plugins were already OnLoaded(), which allows cross-plugins-communication to be possible
		public Task OnASFInit(IReadOnlyDictionary<string, JToken>? additionalConfigProperties = null) {
			if (additionalConfigProperties == null) {
				return Task.CompletedTask;
			}

			foreach ((string configProperty, JToken configValue) in additionalConfigProperties) {
				// It's a good idea to prefix your custom properties with the name of your plugin, so there will be no possible conflict of ASF or other plugins using the same name, neither now or in the future
				switch (configProperty) {
					case $"{nameof(GetInventoryPlugin)}TestProperty" when configValue.Type == JTokenType.Boolean:
						bool exampleBooleanValue = configValue.Value<bool>();
						ASF.ArchiLogger.LogGenericInfo($"{nameof(GetInventoryPlugin)}TestProperty boolean property has been found with a value of: {exampleBooleanValue}");
						break;
				}
			}
			return Task.CompletedTask;
		}
		public async Task<string?> OnBotCommand(Bot bot, EAccess access, string message, string[] args, ulong steamID = 0) {
			long totalNormalCards = 0;
			long totalFoilCards = 0;
			long totalGems = 0;
			switch (args[0].ToUpperInvariant()) {
				case "GETINVENTORY" when access >= EAccess.FamilySharing:
					try {
#pragma warning disable IDE0049 // Simplify Names
						await foreach (Asset item in bot.ArchiWebHandler.GetInventoryAsync().ConfigureAwait(false)) {
							if (item.Type == Asset.EType.TradingCard) {
								totalNormalCards += 1;
							}

							if (item.Type == Asset.EType.FoilTradingCard) {
								totalFoilCards += 1;
							}

							if (item.Type == Asset.EType.SteamGems) {
								totalGems += item.Amount;
							}

#pragma warning restore IDE0049 // Simplify Names


							//return randomCatURL != null ? randomCatURL.ToString() : "God damn it, we're out of cats, care to notify my master? Thanks!";
						}
					} catch (Exception e) {
						ASF.ArchiLogger.LogGenericError("A Error Has Occured");
						return "A Error has occured";
					}
					return $"Found a total of {totalNormalCards} Normal Cards and a total of {totalFoilCards} Foil Cards and a total of {totalGems} Gems";
				default:
					return null;
			}
		}

		// This method is called when bot is destroyed, e.g. on config removal
		// You should ensure that all of your references to this bot instance are cleared - most of the time this is anything you created in OnBotInit(), including deep roots in your custom modules
		// This doesn't have to be done immediately (e.g. no need to cancel existing work), but it should be done in timely manner when everything is finished
		// Doing so will allow the garbage collector to dispose the bot afterwards, refraining from doing so will create a "memory leak" by keeping the reference alive
		// public Task OnBotDestroy(Bot bot) => Task.CompletedTask;

		// This method is called when bot is disconnected from Steam network, you may want to use this info in some kind of way, or not
		// ASF tries its best to provide logical reason why the disconnection has happened, and will use EResult.OK if the disconnection was initiated by us (e.g. as part of a command)
		// Still, you should take anything other than EResult.OK with a grain of salt, unless you want to assume that Steam knows why it disconnected us (hehe, you bet)
		// public Task OnBotDisconnected(Bot bot, EResult reason) => Task.CompletedTask;

		// This method is called when bot receives a friend request or group invite that ASF isn't willing to accept
		// It allows you to generate a response whether ASF should accept it (true) or proceed like usual (false)
		// If you wanted to do extra filtering (e.g. friend requests only), you can interpret the steamID as SteamID (SteamKit2 type) and then operate on AccountType
		// As an example, we'll run a trade bot that is open to all friend/group invites, therefore we'll accept all of them here
		// public Task<bool> OnBotFriendRequest(Bot bot, ulong steamID) => Task.FromResult(true);

		// This method is called at the end of Bot's constructor
		// You can initialize all your per-bot structures here
		// In general you should do that only when you have a particular need of custom modules or alike, since ASF's plugin system will always provide bot to you as a function argument
		public Task OnBotInit(Bot bot) {
			// Apart of those two that are already provided by ASF, you can also initialize your own logger with your plugin's name, if needed
			bot.ArchiLogger.LogGenericInfo($"Our bot named {bot.BotName} has been initialized, and we're letting you know about it from our {nameof(GetInventoryPlugin)}!");
			ASF.ArchiLogger.LogGenericWarning("In case we won't have a bot reference or have something process-wide to log, we can also use ASF's logger!");

			return Task.CompletedTask;
		}

		// This method, apart from being called during bot modules initialization, allows you to read custom bot config properties that are not recognized by ASF
		// Thanks to that, you can extend default bot config with your own stuff, then parse it here in order to customize your plugin during runtime
		// Keep in mind that, as noted in the interface, additionalConfigProperties can be null if no custom, unrecognized properties are found by ASF, you should handle that case appropriately
		// Also keep in mind that this function can be called multiple times, e.g. when user edits their bot configs during runtime
		// Take a look at OnASFInit() for example parsing code
		public async Task OnBotInitModules(Bot bot, IReadOnlyDictionary<string, JToken>? additionalConfigProperties = null) {
			// For example, we'll ensure that every bot starts paused regardless of Paused property, in order to do this, we'll just call Pause here in InitModules()
			// Thanks to the fact that this method is called with each bot config reload, we'll ensure that our bot stays paused even if it'd get unpaused otherwise
			bot.ArchiLogger.LogGenericInfo("Pausing this bot as asked from the plugin");
			await bot.Actions.Pause(true).ConfigureAwait(false);
		}

		// This method is called when the bot is successfully connected to Steam network and it's a good place to schedule any on-connected tasks, as AWH is also expected to be available shortly
		//public Task OnBotLoggedOn(Bot bot) => Task.CompletedTask;

		// This method is called when bot receives a message that is NOT a command (in other words, a message that doesn't start with CommandPrefix)
		// Normally ASF entirely ignores such messages as the program should not respond to something that isn't recognized
		// Therefore this function allows you to catch all such messages and handle them yourself
		// Keep in mind that there is no guarantee what is the actual access of steamID, so you should do the appropriate access checking yourself
		// You can use either ASF's default functions for that, or implement your own logic as you please
		// If you do not intend to return any response to user, just return null/empty and ASF will proceed with the silence as usual
		/*
		 * public Task<string?> OnBotMessage(Bot bot, ulong steamID, string message) {
			// Normally ASF will expect from you async-capable responses, such as Task<string>. This allows you to make your code fully asynchronous which is a core foundation on which ASF is built upon
			// Since in this method we're not doing any async stuff, instead of defining this method as async (pointless), we just need to wrap our responses in Task.FromResult<>()
			if (Bot.BotsReadOnly == null) {
				throw new InvalidOperationException(nameof(Bot.BotsReadOnly));
			}

			// As a starter, we can for example ignore messages sent from our own bots, since otherwise they can run into a possible infinite loop of answering themselves
			if (Bot.BotsReadOnly.Values.Any(existingBot => existingBot.SteamID == steamID)) {
				return Task.FromResult<string?>(null);
			}

			// If this message doesn't come from one of our bots, we can reply to the user in some pre-defined way
			bot.ArchiLogger.LogGenericTrace("Hey boss, we got some unknown message here!");

			return Task.FromResult((string?) "I didn't get that, did you mean to use a command?");
		}
		*/
		// This method is called when bot receives a trade offer that ASF isn't willing to accept (ignored and rejected trades)
		// It allows you not only to analyze such trades, but generate a response whether ASF should accept it (true), or proceed like usual (false)
		// Thanks to that, you can implement custom rules for all trades that aren't handled by ASF, for example cross-set trading on your own custom rules
		// You'd implement your own logic here, as an example we'll allow all trades to be accepted if the bot's name starts from "TrashBot"
		// public Task<bool> OnBotTradeOffer(Bot bot, TradeOffer tradeOffer) => Task.FromResult(bot.BotName.StartsWith("TrashBot", StringComparison.OrdinalIgnoreCase));

		// This is the earliest method that will be called, right after loading the plugin, long before any bot initialization takes place
		// It's a good place to initialize all potential (non-bot-specific) structures that you will need across lifetime of your plugin, such as global timers, concurrent dictionaries and alike
		// If you do not have any global structures to initialize, you can leave this function empty
		// At this point you can access core ASF's functionality, such as logging, but more advanced structures (like ASF's WebBrowser) will be available in OnASFInit(), which itself takes place after every plugin gets OnLoaded()
		// Typically you should use this function only for preparing core structures of your plugin, and optionally also sending a message to the user (e.g. support link, welcome message or similar), ASF-specific things should usually happen in OnASFInit()
		public Task OnLoaded() {
			ASF.ArchiLogger.LogGenericInfo($"Hey! Thanks for checking if our example plugin works fine, this is a confirmation that indeed {nameof(OnLoaded)}() method was called!");
			ASF.ArchiLogger.LogGenericInfo("Good luck in whatever you're doing!");

			return Task.CompletedTask;
		}
	}
}
