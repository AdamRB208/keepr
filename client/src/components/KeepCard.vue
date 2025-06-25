<script setup>
import { AppState } from '@/AppState.js';
import { Keep } from '@/models/Keep.js';
import { keepService } from '@/services/KeepService.js';
import { logger } from '@/utils/Logger.js';
import { Pop } from '@/utils/Pop.js';
import { useRoute } from 'vue-router';

const route = useRoute()

defineProps({
  keeps: { type: Keep, required: true }
})

async function setActiveKeep(keeps, keepsId) {
  try {
    AppState.activeKeep = keeps
    await keepService.setActiveKeep(keeps)
    logger.log('Setting active keep', keeps)
    keepsId = route.params.keepsId || keepsId
    logger.log('KeepsId', keepsId)
    keeps.views++
  }
  catch (error) {
    Pop.error(error, 'COULD NOT SET ACTIVE KEEP!');
    logger.log('Could not set active keep!', error)
  }
}
</script>


<template>
  <div class="Keep-Card m-1 mb-3">
    <div class="Card-Img">
      <img @click="setActiveKeep(keeps, keeps.id)" :src="keeps.img" :alt="`image of ${keeps.name}`" class="Keep-Img"
        type="button" data-bs-toggle="modal" data-bs-target="#keepModal">
      <div class="Card-Text">
        <span class="m-2 w-100">{{ keeps.name }}</span>
        <RouterLink :to="{ name: 'Profile' }" class="d-flex">
          <img :src="keeps.creator.picture" :alt="`cover image for user ${keeps.creator.name}`"
            class="Creator-Img mb-1 me-1" :title="keeps.creator.name" type="button">
        </RouterLink>
      </div>
    </div>
  </div>
</template>


<style lang="scss" scoped>
.Keep-Img {
  object-fit: cover;
  width: 100%;
  height: 100%;
  border-radius: 25px;
  background: #ffffff;
  background-position: bottom;
  border: 1px solid rgba(36, 36, 36, 0.474);
}

.Card-Img {
  position: relative;
  min-width: 100%;
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
}

.Creator-Img {
  border-radius: 50%;
  text-shadow: 0 0 3px #242222;
  min-width: 100%;
  min-block-size: 2.5rem;
  height: 44px;
}
</style>