<script setup>
import { AppState } from '@/AppState.js';
import KeepCard from '@/components/KeepCard.vue';
import { keepService } from '@/services/KeepService.js';

import { logger } from '@/utils/Logger.js';
import { Pop } from '@/utils/Pop.js';
import { computed, onMounted } from 'vue';


const keep = computed(() => AppState.keeps)

onMounted(() => {
  getKeeps()
})

async function getKeeps() {
  try {
    await keepService.getKeeps()
  }
  catch (error) {
    Pop.error(error, 'COULD NOT GET KEEPRS!')
    logger.log('Could not get keeprs!', error)
  }
}

</script>

<template>
  <section class="container">
    <div class="row">
      <div v-for="keeps in keep" :key="keeps.id" class="col-md-4">
        <KeepCard :keeps="keeps" />
      </div>
    </div>
  </section>
</template>

<style scoped lang="scss"></style>
