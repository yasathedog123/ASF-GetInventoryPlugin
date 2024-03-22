import Vue from 'vue';
import store from '../store';

const timeSpanRegex = /(?:(\d+).)?(\d{2}):(\d{2}):(\d{2})(?:.?(\d{7}))?/;

export const BotStatus = {
  DISABLED: 'disabled',
  OFFLINE: 'offline',
  ONLINE: 'online',
  FARMING: 'farming',
};

export class Bot {
  constructor(data) {
    this.name = data.BotName;
    this.nickname = data.Nickname;
    this.steamid = data.s_SteamID;
    this.avatarHash = data.AvatarHash;
    this.bgrCount = data.GamesToRedeemInBackgroundCount;
    this.walletBalance = data.WalletBalance;
    this.walletBalanceDelayed = data.WalletBalanceDelayed;
    this.walletCurrency = data.WalletCurrency;
    this.has2FA = data.HasMobileAuthenticator;
    this.requiredInput = data.RequiredInput;

    this.active = data.KeepRunning;
    this.config = data.BotConfig;
    this.isConnected = data.IsConnectedAndLoggedOn;

    this.paused = data.CardsFarmer.Paused;
    this.gamesToFarm = data.CardsFarmer.GamesToFarm;
    this.timeRemaining = data.CardsFarmer.TimeRemaining;
    this.currentGamesFarming = data.CardsFarmer.CurrentGamesFarming;
  }

  get status() {
    if (!this.active) return BotStatus.DISABLED;
    if (!this.isConnected) return BotStatus.OFFLINE;
    if (this.paused || this.timeRemaining === '00:00:00') return BotStatus.ONLINE;
    if (!this.currentGamesFarming.length) return BotStatus.ONLINE; // Farming module active, something is preventing the bot from farming though
    return BotStatus.FARMING;
  }

  get statusText() {
    const statusText = Vue.i18n.translate(`bot-status-${this.status}`);

    if (this.status === 'farming' && this.currentGamesFarming.length === 1) return `${statusText} - ${this.currentGamesFarming[0].GameName}`;
    if (this.status === 'farming' && this.currentGamesFarming.length > 1) return `${statusText} - ${Vue.i18n.translate('multiple-games')}`;
    if (this.status === 'disabled' && this.requiredInput !== 0) return Vue.i18n.translate('bot-status-input');

    return statusText;
  }

  get avatarURL() {
    if (!this.avatarHash) return (window.__BASE_PATH__) ? `${window.__BASE_PATH__}images/defaultAvatar.jpg` : '/images/defaultAvatar.jpg';
    return `https://avatars.akamai.steamstatic.com/${this.avatarHash}_full.jpg`;
  }

  get profileURL() {
    return `https://steamcommunity.com/profiles/${this.steamid}`;
  }

  get cardsRemaining() {
    return this.gamesToFarm.reduce((cardsRemaining, game) => cardsRemaining + game.CardsRemaining, 0);
  }

  get timeRemainingSeconds() {
    const [, days, hours, minutes, seconds] = timeSpanRegex.exec(this.timeRemaining);

    let time = 0;

    if (days) time += parseInt(days, 10) * 24 * 60 * 60;
    if (hours) time += parseInt(hours, 10) * 60 * 60;
    if (minutes) time += parseInt(minutes, 10) * 60;
    if (seconds) time += parseInt(seconds, 10);

    return time;
  }

  get games() {
    const currentlyFarming = this.currentGamesFarming.map(game => game.AppID);

    return this.gamesToFarm.map(game => ({
      ...game,
      farming: currentlyFarming.includes(game.AppID),
    })).sort((lhs, rhs) => rhs.farming - lhs.farming);
  }

  isVisible(selectedBots) {
    if (selectedBots.length === 0) return true;
    if (this.status === BotStatus.DISABLED && selectedBots.includes('disabled')) return true;
    if (this.status === BotStatus.OFFLINE && selectedBots.includes('offline')) return true;
    if (this.status === BotStatus.ONLINE && selectedBots.includes('online')) return true;
    if (this.status === BotStatus.FARMING && selectedBots.includes('farming')) return true;
    return false;
  }

  get walletInfo() {
    if (this.walletCurrency === 0) return null;

    const balance = this.walletBalance / 100;
    const currency = getCurrencyCode(this.walletCurrency);

    if (typeof currency === 'undefined') return null;

    const options = {
      style: 'currency',
      currency,
      maximumFractionDigits: 2,
    };

    const formattedBalance = balance.toLocaleString(Vue.i18n.locale, options);

    if (this.walletBalanceDelayed !== 0) {
      const balanceDelayed = this.walletBalanceDelayed / 100;
      const formattedBalanceDelayed = balanceDelayed.toLocaleString(Vue.i18n.locale, options);

      return `${formattedBalance} (${formattedBalanceDelayed})`;
    }

    return formattedBalance;
  }

  get viewableName() {
    if (store.getters['settings/nicknames'] && this.nickname) return this.nickname;
    return this.name;
  }
}

function getCurrencyCode(currency) {
  const codes = store.getters['asf/currencyCodes'];
  return Object.keys(codes).find(value => codes[value] === currency);
}
