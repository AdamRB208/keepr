<script setup>
import { AppState } from '@/AppState.js';
import { VaultKeep } from '@/models/VaultKeep.js';
import { vaultKeepService } from '@/services/VaultKeepService.js';
import { logger } from '@/utils/Logger.js';
import { Pop } from '@/utils/Pop.js';
import { computed } from 'vue';

const account = computed(() => AppState.account)
defineProps({
  vaultKeeps: { type: VaultKeep, required: true },
})

async function deleteVaultKeep(vaultKeepId) {
  try {
    const confirmed = await Pop.confirm("Are you sure you want to delete this VaultKeep?")
    if (!confirmed) {
      return
    }
    await vaultKeepService.deleteVaultKeep(vaultKeepId)
  }
  catch (error) {
    Pop.error(error, 'COULD NOT DELETE VAULT KEEP!');
    logger.log('Could not delete vault keep!', error)
  }
}

</script>

<!-- TODO fix issue with card display -->
<template>
  <div v-if="vaultKeeps" class="VaultKeep-Card m-1 mb-3">
    <div class="Card-Img">
      <i v-if="account && vaultKeeps.creatorId == account.id" @click="deleteVaultKeep(vaultKeeps.id)"
        class="mdi mdi-alpha-x-circle text-danger text-end ms-2" role="button"></i>
      <img :src="vaultKeeps.img" :alt="`image of ${vaultKeeps.name}`" class="VaultKeep-Img" type="button">
      <div class="Card-Text">
        <p class="m-2 w-100">{{ vaultKeeps.name }}</p>
      </div>
    </div>
  </div>
</template>


<style lang="scss" scoped>
.Card-Text {
  position: absolute;
  bottom: 0;
  color: white;
  font-weight: 500;
  display: flex;
  justify-content: center;
    width: 200px;
  text-shadow: 0 0 3px #242222;
  background: linear-gradient(0deg, #1716167b 20%, transparent);
  border-radius: 0 0 25px 25px;
  padding: 5px;
}
.VaultKeep-Img {
  object-fit: cover;
  width: 200px;
  height: 200px;
  border-radius: 25px;
  background: #ffffff;
  background-position: bottom;
  border: 1px solid rgba(36, 36, 36, 0.474);
}

.Card-Img {
  position: relative;
  min-width: 100%;
}

.VaultKeep-Card {
  max-width: 33%;
}
</style>