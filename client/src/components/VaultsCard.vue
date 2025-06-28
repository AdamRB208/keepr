<script setup>
import { Vault } from '@/models/Vault.js';



defineProps({
  vaults: { type: Vault, required: true }
})

// async function getVaultById(vaultId) {
//   try {
//     AppState.activeVault.id = vaultId
//     vaultId = route.params.vaultId
//     logger.log('vaultId', vaultId)
//     await vaultService.getVaultById(vaultId)
//   }
//   catch (error) {
//     Pop.error(error, 'COULD NOT GET VAULT BY ID!');
//     logger.log('Could not get vault by id!', error)
//   }
// }


</script>


<template>
  <div v-if="vaults" class="Vault-Card m-1 mb-3 col-md-3">
    <div class="Card-Img">
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
</style>