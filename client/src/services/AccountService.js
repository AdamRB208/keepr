import { Vault } from '@/models/Vault.js'
import { AppState } from '../AppState.js'
import { Account } from '../models/Account.js'
import { logger } from '../utils/Logger.js'
import { api } from './AxiosService.js'

class AccountService {

  async getAccount() {
    try {
      const res = await api.get('/account')
      logger.log('response data', res.data)
      AppState.account = new Account(res.data)
      // TODO invoke get your vaults
    } catch (err) {
      logger.error('HAVE YOU STARTED YOUR SERVER YET???', err)
    }
  }

  async updateAccount(accountData) {
    const response = await api.put('/account', accountData)
    logger.log('Updated Account!', response.data)
    AppState.account = new Account(response.data)
  }

  async getUsersVaults() {
    const response = await api.get('/account/vaults')
    logger.log('Got vaults', response.data)
    const vault = response.data.map(pojo => new Vault(pojo))
    AppState.vaults = vault
    logger.log('account vaults', vault)
  }


  // TODO get your vaults

}

export const accountService = new AccountService()
