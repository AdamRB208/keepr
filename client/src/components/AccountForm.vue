<script setup>
import { AppState } from '@/AppState.js';
import { accountService } from '@/services/AccountService.js';
import { logger } from '@/utils/Logger.js';
import { Pop } from '@/utils/Pop.js';
import { onMounted, ref } from 'vue';


const editableAccountData = ref({
  name: '',
  picture: '',
  coverImg: '',
  email: ''
})

onMounted(() => {
  const account = AppState.account
  editableAccountData.value = {...account}
})

async function updateAccount() {
  try {
    await accountService.updateAccount(editableAccountData.value)
  }
  catch (error){
    Pop.error(error, 'COULD NOT UPDATE ACCOUNT!');
    logger.log('Could not update Account!', error)
  }
}


</script>


<template>
<div class="p-3">
    <h2>Update your account!</h2>
    <form @submit.prevent="updateAccount()">
      <div class="mb-3">
        <label for="accountName">Account Name</label>
        <input v-model="editableAccountData.name" type="text" name="name" id="accountName" required maxlength="255">
      </div>
      <div class="mb-3">
        <label for="accountEmail">Account Email</label>
        <input v-model="editableAccountData.email" type="text" name="email" id="accountEmail" required maxlength="255">
      </div>
      <div class="mb-3">
        <label for="accountPicture">Account Picture</label>
        <input v-model="editableAccountData.picture" type="url" id="accountPicture" name="picture" maxlength="255">
      </div>
      <div class="mb-3">
        <label for="accountCoverImg">Account CoverImg</label>
        <input v-model="editableAccountData.coverImg" type="url" id="accountCoverImg" name="coverImg" maxlength="1000">
      </div>
      <div class="text-end">
        <button class="btn btn-dark" type="submit">Submit</button>
      </div>
    </form>
  </div>
</template>


<style lang="scss" scoped>

</style>