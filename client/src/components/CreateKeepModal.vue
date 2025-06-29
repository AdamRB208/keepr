<script setup>
import { AppState } from '@/AppState.js';
import { keepService } from '@/services/KeepService.js';
import { logger } from '@/utils/Logger.js';
import { Pop } from '@/utils/Pop.js';
import { computed, ref } from 'vue';


const account = computed(() => AppState.account)

const editableKeepData = ref({
  name: '',
  description: '',
  img: ''
})

async function createKeep() {
  try {
    const keepData = editableKeepData.value
    await keepService.createKeep(keepData)
    editableKeepData.value = {
      name: '',
      description: '',
      img: ''
    }
  }
  catch (error) {
    Pop.error(error, 'COULD NOT CREATE KEEP!');
    logger.error('Could not create Keep!', error)
  }
}

</script>
<template>
  <div v-if="account" class="modal" tabindex="-1" id="createKeepModal" aria-labelledby="createKeepModalLabel">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-body">
          <h5 class="modal-title" id="createKeepModalLabel">Add your keep</h5>
          <form @submit.prevent="createKeep()">
            <div class="mb-3">
              <label for="keepName" class="form-label"></label>
              <input v-model="editableKeepData.name" type="text" class="form-control" id="keepName"
                placeholder="Name..." minlength="1" maxlength="255" required>
            </div>
            <div class="mb-3">
              <label for="keepDescription" class="form-label"></label>
              <textarea v-model="editableKeepData.description" class="form-control" id="keepDescription" rows="3"
                type="text" placeholder="Keep Description..." maxlength="1000" required></textarea>
              <div class="mb-3">
                <label for="keepImg" class="form-label"></label>
                <input v-model="editableKeepData.img" type="url" class="form-control" id="keepImg"
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


<style lang="scss" scoped></style>