<script setup>
import CreateKeepModal from './CreateKeepModal.vue';
import CreateVaultModal from './CreateVaultModal.vue';


</script>


<template>
  <div class="dropdown">
    <button class="btn border-black dropdown-toggle" type="button" data-bs-toggle="dropdown" aria-expanded="false">
      Create
    </button>
    <ul class="dropdown-menu">
      <li><button class="dropdown-item" type="button" data-bs-toggle="modal" data-bs-target="#createKeepModal">Create
          Keepr</button></li>
      <li><button class="dropdown-item" type="button" data-bs-toggle="modal" data-bs-target="#createVaultModal">Create
          Vault</button></li>
    </ul>
    <CreateKeepModal />
    <CreateVaultModal />

    <!-- TODO createVault -->
  </div>
</template>


<style lang="scss" scoped>
.dropdown-toggle {
  background-color: #35343430;
}
</style>