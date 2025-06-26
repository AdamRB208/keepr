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

  // TODO edit account
  // TODO get your vaults


}

export const accountService = new AccountService()
