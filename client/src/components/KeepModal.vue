<script setup>
import { AppState } from '@/AppState.js';
import { accountService } from '@/services/AccountService.js';
import { vaultKeepService } from '@/services/VaultKeepService.js';
import { vaultService } from '@/services/VaultService.js';
import { logger } from '@/utils/Logger.js';
import { Pop } from '@/utils/Pop.js';
import { computed } from 'vue';
import { useRoute } from 'vue-router';


const activeKeep = computed(() => AppState.activeKeep)
const vaults = computed(() => AppState.vaults)
const account = computed(() => AppState.account)

const route = useRoute()

async function getUsersVaults() {
  try {
    await accountService.getUsersVaults()
  }
  catch (error) {
    Pop.error(error, 'COULD NOT GET VAULTS!');
    logger.error('Could not get vaults!', error)
  }
}

async function createVaultKeep(vaultId, keepId) {
  try {
    await vaultKeepService.createVaultKeep(vaultId, keepId)
  }
  catch (error) {
    Pop.error(error, 'COULD NOT CREATE VAULT KEEP!');
    logger.log('Could not create Vault Keep!', error)
  }
}

</script>


<template>
  <div v-if="activeKeep" class="modal" tabindex="-1" id="keepModal">
    <div class="modal-dialog modal-lg">
      <div class="modal-content">
        <div class="modal-body">
          <div class="modal-body">
            <div class="container-fluid">
              <div class="row d-flex">
                <div class="col-md-6 justify-content-between">
                  <img :src="activeKeep.img" alt="" class="Active-Img">
                </div>
                <div class="col-md-6 d-flex justify-content-between flex-column">
                  <div class="d-flex justify-content-center mb-5">
                    <i class="mdi mdi-eye-outline me-5" title="Views"> {{ activeKeep.views }}</i>
                    <i class="mdi mdi-account-check ms-5" title="Vault Count"> {{ activeKeep.kept }}</i>
                  </div>
                  <div class="text-center">
                    <h2>{{ activeKeep.name }}</h2>
                    <p>{{ activeKeep.description }}</p>
                  </div>
                  <div>
                    <div v-if="account" class="footer d-flex justify-content-between">
                      <button @click="getUsersVaults()" class="btn btn-sm btn-outline-dark dropdown-toggle"
                        style="--bs-btn-padding-y: .25rem; --bs-btn-padding-x: .5rem; --bs-btn-font-size: .75rem;"
                        type="button" data-bs-toggle="dropdown" aria-expanded="false">
                        Vaults
                      </button>
                      <ul class="dropdown-menu dropdown-menu-end">
                        <li v-for="vault in vaults" :key="vault.id"><button
                            @click="createVaultKeep(vault.id, activeKeep.id)" class="dropdown-item btn btn-dark"
                            type="button">{{
                              vault.name }}</button></li>
                      </ul>
                    </div>
                    <img :src="activeKeep.creator.picture" :alt="`cover image for user ${activeKeep.creator.name}`"
                      class="Creator-Img mb-1 me-1" :title="activeKeep.creator.name" type="button">
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
  <!-- </div> -->
</template>


<style lang="scss" scoped>
.Active-Img {
  object-fit: cover;
  width: 100%;
  height: 500px;
}

.footer {
  max-height: 3rem;
}

.Creator-Img {
  border-radius: 50%;
  text-shadow: 0 0 3px #242222;
  max-width: 3rem;
  object-fit: cover;
  aspect-ratio: 1/1;
}
</style>