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
        <div class="modal-header">
          <h5 class="modal-title" id="createKeepModalLabel">Add your keep</h5>
          <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body">
          <form @submit.prevent="createKeep()">
            <div class="mb-3">
              <label for="keepName" class="form-label">Name</label>
              <input v-model="editableKeepData.name" type="text" class="form-control" id="keepName"
                placeholder="Name..." minlength="1" maxlength="255" required>
            </div>
            <div class="mb-3">
              <label for="keepDescription" class="form-label">Description</label>
              <textarea v-model="editableKeepData.description" class="form-control" id="keepDescription" rows="3"
                type="text" placeholder="Keep Description..." maxlength="1000" required></textarea>
              <div class="mb-3">
                <label for="keepImg" class="form-label">Image URL</label>
                <input v-model="editableKeepData.img" type="url" class="form-control" id="keepImg"
                  placeholder="Image URL..." maxlength="1000" required>
              </div>
            </div>
            <div class="modal-footer">
              <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
              <button type="submit" class="btn btn-primary">Submit</button>
            </div>
          </form>
        </div>
      </div>
    </div>
  </div>
</template>


<style lang="scss" scoped></style>