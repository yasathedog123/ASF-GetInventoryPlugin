<template>
  <div class="info-cards">
    <AsfFarmingInfoCard :title="$t('farming-info-games')" :value="gamesRemaining" icon="gamepad"></AsfFarmingInfoCard>
    <AsfFarmingInfoCard :title="$t('farming-info-time')" :value="timeRemaining" icon="clock"></AsfFarmingInfoCard>
    <AsfFarmingInfoCard :title="$t('farming-info-cards')" :value="cardsRemaining" icon="clone"></AsfFarmingInfoCard>
  </div>
</template>

<script>
  import { mapGetters } from 'vuex';
  import humanizeDuration from 'humanize-duration';
  import getLocaleForHD from '../../utils/getLocaleForHD';
  import AsfFarmingInfoCard from './FarmingInfoCard.vue';

  export default {
    name: 'AsfFarmingInfo',
    components: { AsfFarmingInfoCard },
    computed: {
      ...mapGetters({ botsFarmingCount: 'bots/botsFarmingCount' }),
      timeRemaining() {
        if (this.botsFarmingCount === 0) return '-';
        const language = getLocaleForHD();
        return humanizeDuration(this.$store.getters['bots/timeRemaining'] * 1000, { language });
      },
      gamesRemaining() {
        if (this.botsFarmingCount === 0) return '-';
        return this.$store.getters['bots/gamesRemaining'];
      },
      cardsRemaining() {
        if (this.botsFarmingCount === 0) return '-';
        return this.$store.getters['bots/cardsRemaining'];
      },
    },
  };
</script>

<style lang="scss">
  .info-cards {
    display: grid;
    grid-gap: 1em;
    grid-template-columns: repeat(3, 1fr);

    @media screen and (max-width: 600px) {
      grid-template-columns: 1fr;
    }
  }
</style>
