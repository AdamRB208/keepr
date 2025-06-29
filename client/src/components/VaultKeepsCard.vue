<script setup>
import { Keep } from '@/models/Keep.js';
import { VaultKeep } from '@/models/VaultKeep.js';


defineProps({
  vaultKeeps: {type: VaultKeep, required: true},
  keeps: {type: Keep, required: true}
})
</script>


<template>
  <div v-if="vaultKeeps" class="VaultKeep-Card m-1 mb-3 col-md-3">
    <div class="Card-Img">
        <img :src="vaultKeeps.img" :alt="`image of ${vaultKeeps.name}`" class="VaultKeep-Img" type="button">
      <div class="Card-Text">
        <span class="m-2 w-100">{{ vaultKeeps.name }}</span>
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
.VaultKeep-Img {
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

.VaultKeep-Card {
  max-width: 33%;
}
</style>