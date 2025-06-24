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
        <img :src="account.coverImg" :alt="`cover image for user ${account.name}`" class="w-25">
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
</style>