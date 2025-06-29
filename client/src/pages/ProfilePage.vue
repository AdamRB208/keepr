<script setup>
import { AppState } from '@/AppState.js';
import KeepCard from '@/components/KeepCard.vue';
import VaultsCard from '@/components/VaultsCard.vue';
import { keepService } from '@/services/KeepService.js';
import { profilesService } from '@/services/ProfileService.js';
import { vaultService } from '@/services/VaultService.js';
import { logger } from '@/utils/Logger.js';
import { Pop } from '@/utils/Pop.js';
import { computed, onMounted } from 'vue';
import { useRoute, useRouter } from 'vue-router';

const profile = computed(() => AppState.account)

const vaults = computed(() => AppState.accountVaults)

const keeps = computed(() => AppState.keeps)


const route = useRoute()
const router = useRouter()

onMounted(() => {
  getProfileById()
  getVaultsByProfileId()
  getKeepsByProfileId()
})
// HINT use the route.params

// TODO on mounted get the keeps by the profileId

async function getProfileById() {
  try {
    await profilesService.getProfileById(route.params.profileId)
  }
  catch (error) {
    Pop.error(error, "COULD NOT GET PROFILE!");
    logger.error('Could not get profile!', error)
    router.push({ name: 'Profile' })
  }

}
async function getVaultsByProfileId() {
  try {
    await vaultService.getVaultByProfileId(route.params.profileId)
  }
  catch (error) {
    Pop.error(error, 'COULD NOT GET VAULTS!');
    logger.error('Could not get vaults!', error)
  }
}

async function getKeepsByProfileId() {
  try {
    await keepService.getKeepsByProfileId(route.params.profileId)
  }
  catch (error) {
    Pop.error(error, 'COULD NOT GET KEEPS BY PROFILE ID');
    logger.log('Could not get keeps by profile Id')
  }
}



</script>


<template>
  <section class="container">
    <div class="row justify-content-center">
      <div class="col-md-10 d-flex w-100 flex-column">
        <div>
          <img :src="profile.coverImg" :alt="`cover image for ${profile.name}`" class="cover-img">
        </div>
        <div class="d-flex justify-content-center">
          <img :src="profile.picture" :alt="`profile picture for ${profile.name}`" class="profile-img">
        </div>
        <div class="d-flex justify-content-center">
          <h1>{{ profile.name }}</h1>
        </div>
        <div class="d-flex justify-content-center">
          <small class="me-1">Vaults</small>
          <small class="ms-1">Keeps</small>
        </div>
      </div>
    </div>
  </section>

  <!-- TODO fix overlap issue with cards -->

  <section class="container">
    <div class="row">
      <div class="col-md-10 w-100">
        <div class="row w-100">
          <h1 class="ms-5">Vaults</h1>
          <div class="col-md-3 mt-4 d-flex justify-content-center" v-for="vaults in vaults" :key="vaults.id">
            <VaultsCard :vaults="vaults" class="vault-cards" />
          </div>
        </div>
      </div>
    </div>
  </section>

  <!-- TODO create new card for keeps, still needs masonry!!! -->

  <section class="container">
    <div class="row">
      <div class="col-md-10 w-100">
        <div class="row w-100">
          <h2 class="ms-5">Keeps</h2>
          <div class="col-md-3 d-flex justify-content-center masonry-container" v-for="keeps in keeps" :key="keeps.id">
            <KeepCard :keeps="keeps" />
          </div>
        </div>
      </div>
    </div>
  </section>
</template>


<style lang="scss" scoped>
.cover-img {
  object-fit: cover;
  width: 100%;
  height: 400px;
}

.profile-img {
  justify-content: center;
  border-radius: 50%;
  text-shadow: 0 0 3px #242222;
  max-width: 7rem;
  margin-top: 1.5rem;
}
.vault-cards {
  width: 100%;
}

.masonry-container {
  columns: 200px;
}

.masonry-container>* {
  display: inline-block;
  break-inside: avoid;
}
</style>