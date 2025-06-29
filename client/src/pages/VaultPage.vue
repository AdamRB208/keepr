<script setup>
logger.log('Vault Page Mounted')
import { AppState } from '@/AppState.js';
import VaultKeepsCard from '@/components/VaultKeepsCard.vue';
import { vaultKeepService } from '@/services/VaultKeepService.js';
import { vaultService } from '@/services/VaultService.js';
import { logger } from '@/utils/Logger.js';
import { Pop } from '@/utils/Pop.js';
import { computed, onMounted } from 'vue';
import { useRoute, useRouter } from 'vue-router';

const route = useRoute()
const router = useRouter()

const account = computed(() => AppState.account)
const vault = computed(() => AppState.activeVault)
const vaultKeeps = computed(() => AppState.vaultKeeps)
const keeps = computed(() => AppState.keeps)


onMounted(() => {
  getVaultById()
  getPublicVaultKeeps()
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

async function getPublicVaultKeeps() {
  try {
    await vaultKeepService.getPublicVaultKeeps(route.params.vaultId)
  }
  catch (error) {
    Pop.error(error, 'COULD NOT GET VAULTKEEPS!');
    logger.log('Could not get VaultKeeps!', error)
    router.push({ name: 'Vault' })
  }
}

</script>


<template>
  <section v-if="account" class="container-fluid">
    <div class="row justify-content-center">
      <div class="col-md-6 d-flex justify-content-center">
        <div v-if="vault && vault.id" class="Card-Img">
          <img :src="vault.img" :alt="`image of ${vault.name}`" class="Vault-Img">
          <div class="Card-Text">
            <p class="fs-1 w-100 text-center">{{ vault.name }}</p>
            <p class="w-100 text-center">By {{ vault.creator.name }}</p>
            <div></div>
          </div>
        </div>
      </div>
    </div>
  </section>
  <section class="container">
    <div class="row justify-content-center">
      <div class="col-md-10 mt-3">
        <div v-if="vaultKeeps">
          <div class="d-flex justify-content-center mb-2">
            <span class="badge text-bg-secondary rounded text-center p-1">{{ vaultKeeps.length }} Keeps</span>
          </div>
        </div>
        <div>
          <div class="col-md-3 masonry-container">
            <div v-for="vaultKeeps in vaultKeeps" :key="vaultKeeps.id">
              <VaultKeepsCard :vaultKeeps="vaultKeeps" />
            </div>
          </div>
        </div>
      </div>
    </div>
  </section>
</template>


<style lang="scss" scoped>
.Card-Img {
  position: relative;
  min-width: 100%;
  max-height: 300px;
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
  display: column;
  justify-content: space-between;
  width: 100%;
  text-shadow: 0 0 3px #242222;
  background: linear-gradient(0deg, #1716167b 20%, transparent);
  border-radius: 0 0 25px 25px;
  padding: 5px;
  justify-content: center;
}
</style>