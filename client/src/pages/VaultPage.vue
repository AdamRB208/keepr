<script setup>
logger.log('Vault Page Mounted')
import { AppState } from '@/AppState.js';
import { vaultService } from '@/services/VaultService.js';
import { logger } from '@/utils/Logger.js';
import { Pop } from '@/utils/Pop.js';
import { computed, onMounted } from 'vue';
import { useRoute, useRouter } from 'vue-router';

const route = useRoute()
const router = useRouter()

const account = computed(() => AppState.account)
const vault = computed(() => AppState.activeVault)


onMounted(() => {
  getVaultById()
  logger.log('running get vault by id')
})


async function getVaultById() {
  try {
    const vaultId = route.params.vaultId
    logger.log('vaultId', vaultId)
    await vaultService.getVaultById(vaultId)
  }
  catch (error) {
    Pop.error(error, 'COULD NOT GET VAULT BY ID!');
    logger.log('Could not get vault by id!', error)
  }
}
</script>


<template>
  <section v-if="account" class="container-fluid">
    <div class="row justify-content-center">
      <div class="col-md-10 d-flex justify-content-center">
        <div v-if="vault && vault.id" class="Card-Img">
          <img :src="vault.img" :alt="`image of ${vault.name}`" class="Vault-Img">
        </div>
        <div class="Card-Text">
          <span>{{ vault.name }}</span>
        </div>
      </div>
      <div class="col-md-10 masonry-container">
        <div>
          <h2>Vaults</h2>
        </div>
      </div>
    </div>
  </section>
</template>


<style lang="scss" scoped>
.Card-Img {
  position: relative;
  min-width: 100%;
}

.Vault-Img {
  object-fit: cover;
  width: 100%;
  height: 100%;
  border-radius: 25px;
  background: #ffffff;
  background-position: bottom;
  border: 1px solid rgba(36, 36, 36, 0.474);
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
</style>