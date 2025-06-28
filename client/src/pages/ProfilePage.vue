<script setup>
import { AppState } from '@/AppState.js';
import { profilesService } from '@/services/ProfileService.js';
import { logger } from '@/utils/Logger.js';
import { Pop } from '@/utils/Pop.js';
import { computed, onMounted } from 'vue';
import { useRoute, useRouter } from 'vue-router';

const profile = computed(() => AppState.account)

const route = useRoute()
const router = useRouter()

onMounted(() => {
  getProfileById()
})
// HINT use the route.params

// TODO on mounted get the profile by its profileId
// TODO on mounted get the keeps by the profileId
// TODO on mounted get the vaults by the profileId

async function getProfileById() {
  try {
    await profilesService.getProfileById(route.params.profileId)
  }
  catch (error) {
    Pop.error(error, "COULD NOT GET PROFILE!");
    logger.error(error)
    router.push({ name: 'Profile' })
  }
}




</script>


<template>
  <section class="container div row">
    <div class="col-12">
      <div>{{ profile }}</div>
    </div>
  </section>
</template>


<style lang="scss" scoped></style>