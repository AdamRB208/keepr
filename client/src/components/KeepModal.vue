<script setup>
import { AppState } from '@/AppState.js';
import { computed, ref } from 'vue';


const activeKeep = computed(() => AppState.activeKeep)
const vault = computed(() => AppState.vaults)
const account = computed(() => AppState.account)

const fromData = ref({
  vaultId: ''
})

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
                      <button class="btn btn-sm btn-outline-dark dropdown-toggle"
                        style="--bs-btn-padding-y: .25rem; --bs-btn-padding-x: .5rem; --bs-btn-font-size: .75rem;"
                        type="button" data-bs-toggle="dropdown" aria-expanded="false">
                        Vaults
                      </button>
                      <!-- <div v-if="account" class="dropdown-menu">
                        <form>
                          <select v-model="fromData.vaultId" title="Choose a vault to save this to" required>
                            <option v-for="vault in vault" :key="vault.id" :value="vault.id">{{ vault.name }}</option>
                          </select>
                          <button data-bs-dismiss="modal" type="submit" class="btn btn-keeper text-dark mx-2">Save to
                            Vault</button>
                        </form>
                      </div> -->
                      <div v-if="vault" class="dropdown-menu">
                        <form>
                          <select v-model="fromData.vaultId">
                            <option v-for="vault in vault" :key="vault.id" :value="vault.id" class="dropdown-item"
                              type="button">asdgf</option>
                          </select>
                        </form>
                        <li><a class="dropdown-item" href="#"></a>Vault 2</li>
                        <li><a class="dropdown-item" href="#"></a>vault 3</li>
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
  </div>
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