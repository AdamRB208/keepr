import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { Vault } from "@/models/Vault.js"
import { AppState } from "@/AppState.js"

class VaultService {

  async getVaultById(vaultId) {
    const response = await api.get(`api/vaults/${vaultId}`)
    logger.log('Got Vault by Id!', response.data)
    const vault = new Vault(response.data)
    AppState.activeVault = vault
  }

  async getVaultByProfileId(profileId) {
    const response = await api.get(`api/profiles/${profileId}/vaults`)
    logger.log('Got Vaults!', response.data)
    AppState.accountVaults = response.data.map(pojo => new Vault(pojo))
  }

  async createVault(vaultData) {
    const response = await api.post('api/vaults', vaultData)
    logger.log('Created Vault!', response.data)
    const vault = new Vault(response.data)
    return vault
  }
}

export const vaultService = new VaultService()