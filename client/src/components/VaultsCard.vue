<script setup>
import { AppState } from '@/AppState.js';
import { Vault } from '@/models/Vault.js';
import { vaultService } from '@/services/VaultService.js';
import { logger } from '@/utils/Logger.js';
import { Pop } from '@/utils/Pop.js';
import { computed } from 'vue';

const account = computed(() => AppState.account)

defineProps({
  vaults: { type: Vault, required: true }
})


async function deleteVault(vaultId) {
  try {
    const confirmed = await Pop.confirm("Are you sure you want to delete this Vault?")
    if (!confirmed) {
      return
    }
    await vaultService.deleteVault(vaultId)
  }
  catch (error) {
    Pop.error(error, 'COULD NOT DELETE VAULT!');
    logger.log('Could not delete vault!', error)
  }
}

</script>

<!-- TODO fix issue with card display -->
<template>
  <div v-if="vaults" class="Vault-Card m-1 mb-3">
    <div class="Card-Img">
      <i v-if="account && vaults.creatorId == account.id" @click="deleteVault(vaults.id)"
        class="mdi mdi-alpha-x-circle text-danger text-end ms-2" role="button"></i>
      <RouterLink :to="{ name: 'Vault', params: { vaultId: vaults.id } }">
        <img :src="vaults.img" :alt="`image of ${vaults.name}`" class="Vault-Img" type="button">
      </RouterLink>
      <div class="Card-Text">
        <span class="m-2 w-100">{{ vaults.name }}</span>
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
  justify-content: space-between;
  width: 100%;
  text-shadow: 0 0 3px #242222;
  background: linear-gradient(0deg, #1716167b 20%, transparent);
  border-radius: 0 0 25px 25px;
  padding: 5px;
  max-height: 100%;
}
.Vault-Img {
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

.Vault-Card {
  max-width: 33%;
}
i {
  position: absolute;
  background-position: top;
  font-size: 1em;
  width: 100%;
  margin-bottom: 2rem;
}
</style>