<template>
  <div class="bgr__check">
    <h3 v-if="!noKeys" class="subtitle bgr__check-title">
      {{ title }}
    </h3>

    <div class="form-item">
      <BgrKeys :keys="keys"></BgrKeys>
    </div>

    <div class="form-item">
      <div class="form-item__buttons form-item__buttons--center">
        <button v-if="!noKeys" class="button button--confirm" @click="$emit('confirm')">
          <FontAwesomeIcon v-if="confirming" icon="spinner" spin></FontAwesomeIcon>
          <span v-else>{{ $t('confirm') }}</span>
        </button>

        <button :key="'cancel'" class="button button--cancel" @click="$emit('cancel')">
          {{ $t('cancel') }}
        </button>
      </div>
    </div>
  </div>
</template>

<script>
  import BgrKeys from './Keys.vue';

  export default {
    name: 'BgrCheck',
    components: { BgrKeys },
    props: {
      keys: Object,
      confirming: Boolean,
      title: String,
    },
    computed: {
      noKeys() {
        return !Object.keys(this.keys).length;
      },
    },
  };
</script>

<style lang="scss">
  .bgr__check-title {
    margin-bottom: 0.5em;
  }
</style>
