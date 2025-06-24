<script setup>
import { AppState } from '@/AppState.js';
import { computed } from 'vue';



const activeKeep = computed(() => AppState.activeKeep)


</script>


<template>
  <div v-if="activeKeep" class="modal" tabindex="-1" id="keepModal">
    <div class="modal-dialog modal-lg">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title">Modal title</h5>
          <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body">
          <div class="modal-body">
            <div class="container-fluid">
              <div class="row">
                <div class="col-md-6">
                  <img :src="activeKeep.img" alt="" class="Active-Img">
                </div>
                <div class="col-md-6 ms-auto">.col-md-6 .ms-auto</div>
              </div>
            </div>
          </div>
        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
          <button type="button" class="btn btn-primary">Save changes</button>
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
</style>