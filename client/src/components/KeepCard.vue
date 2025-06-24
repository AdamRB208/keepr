<script setup>
import { AppState } from '@/AppState.js';
import { Keep } from '@/models/Keep.js';
import { computed } from 'vue';

const account = computed(() => AppState.account)

defineProps({
  keeps: { type: Keep, required: true }
})
</script>


<template>
  <div class="Keep-Card m-1 mb-3">
    <div class="Card-Img">
      <img :src="keeps.img" :alt="`image of ${keeps.name}`" class="Keep-Img" type="button">
      <div class="Card-Text">
        <span class="m-2 w-75">{{ keeps.name }}</span>
        <img :src="keeps.creator.picture" :alt="`cover image for user ${keeps.creator.name}`"
          class="Creator-Img mb-1 me-1" :title="keeps.creator.name" type="button">
      </div>
    </div>
  </div>
</template>


<style lang="scss" scoped>
.Keep-Img {
  object-fit: cover;
  width: 100%;
  height: 300px;
  border-radius: 25px;
  background: #ffffff;
  background-position: bottom;
  border: 1px solid rgba(36, 36, 36, 0.474);
}

.Card-Img {
  position: relative;
  width: 100%;
}

.Card-Text {
  position: absolute;
  bottom: 0;
  color: white;
  font-weight: 500;
  display: flex;
  justify-content: space-between;
  width: 100%;
  text-shadow: 0 0 3px #242222;
  background: linear-gradient(0deg, #1716167b 20%, transparent);
  border-radius: 0 0 25px 25px;
  padding: 5px;
  height: 15%;
}

.Creator-Img {
  border-radius: 50%;
  text-shadow: 0 0 3px #242222;
  max-width: 25%;
}
</style>