<script setup>
import { AppState } from '@/AppState.js';
import KeepCard from '@/components/KeepCard.vue';
import KeepModal from '@/components/KeepModal.vue';
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
    <div class="row d-flex justify-content-center">
      <div class="col-md-10 masonry-container">
        <div v-for="keeps in keep" :key="keeps.id">
          <KeepCard :keeps="keeps" />
        </div>
      </div>
    </div>
  </section>
  <KeepModal />
</template>

<style scoped lang="scss">
// .masonry-container {
//   display: grid;
//   gap: 10px;
//   grid-template-columns: repeat(auto-fill, minmax(250px, 1fr));
//   grid-template-rows: max-content;
//   grid-template-rows: masonry;
// }

// .masonry-container>* {
//   display: inline-block;
//   break-inside: avoid;
// }

.masonry-container {
  columns: 200px;
}

.masonry-container>* {
  display: inline-block;
  break-inside: avoid;
}
</style>
