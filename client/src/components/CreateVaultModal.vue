<script setup>
import { AppState } from '@/AppState.js';
import { vaultService } from '@/services/VaultService.js';
import { logger } from '@/utils/Logger.js';
import { Pop } from '@/utils/Pop.js';
import { computed, ref } from 'vue';


const account = computed(() => AppState.account)

const editableVaultData = ref({
  name: '',
  description: '',
  img: ''
})

async function createVault() {
  try {
    const vaultData = editableVaultData.value
    await vaultService.createVault(vaultData)
    editableVaultData.value = {
      name: '',
      description: '',
      img: ''
    }
  }
  catch (error){
    Pop.error(error, 'COULD NOT CREATE VAULT');
    logger.log('Could not create Vault!', error)
  }
}
</script>


<template>
<div v-if="account" class="modal" tabindex="-1" id="createVaultModal" aria-labelledby="createVaultModalLabel">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-body">
          <h5 class="modal-title" id="createVaultModalLabel">Add your vault</h5>
          <form @submit.prevent="createVault()">
            <div class="mb-3">
              <label for="vaultName" class="form-label"></label>
              <input v-model="editableVaultData.name" type="text" class="form-control" id="vaultName"
                placeholder="Name..." minlength="1" maxlength="255" required>
            </div>
            <div class="mb-3">
              <label for="vaultDescription" class="form-label"></label>
              <textarea v-model="editableVaultData.description" class="form-control" id="vaultDescription" rows="3"
                type="text" placeholder="Vault Description..." maxlength="1000" required></textarea>
              <div class="mb-3">
                <label for="vaultImg" class="form-label"></label>
                <input v-model="editableVaultData.img" type="url" class="form-control" id="vaultImg"
                  placeholder="Image URL..." maxlength="1000" required>
              </div>
              <div class="d-flex justify-content-end">
                <button type="submit" class="btn btn-dark">Create</button>
              </div>
            </div>
          </form>
        </div>
      </div>
    </div>
  </div>
</template>


<style lang="scss" scoped>

</style>