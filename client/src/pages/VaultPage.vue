<script setup>
import { AppState } from '@/AppState.js';
import { vaultService } from '@/services/VaultService.js';
import { logger } from '@/utils/Logger.js';
import { Pop } from '@/utils/Pop.js';
import { computed, onMounted } from 'vue';
import { useRoute } from 'vue-router';

const route = useRoute()

const vault = computed(() => AppState.activeVault)

onMounted(() => {
  getVaultById()
})



async function getVaultById() {
  try {
    const vaultId = route.params.vaultId
    await vaultService.getVaultById(vaultId)
  }
  catch (error) {
    Pop.error(error, 'COULD NOT GET VAULT BY ID!');
    logger.log('Could not get vault by id!', error)
  }
}
</script>


<template>
  <section class="container">
    <div class="row">
      <div class="col-md-10 masonry-container">
        {{ vault }}
      </div>
    </div>
  </section>
</template>


<style lang="scss" scoped></style>