import { logger } from "@/utils/Logger.js";
import { api } from "./AxiosService.js";
import { AppState } from "@/AppState.js";
import { VaultKeep } from "@/models/VaultKeep.js";

class VaultKeepService {
  async createVaultKeep(vaultId, keepId) {
    const response = await api.post('api/vaultkeeps', { vaultId, keepId })
    logger.log('Created VaultKeep!', response.data)
    const vaultKeep = new VaultKeep(response.data)
    return vaultKeep
  }
  async getPublicVaultKeeps(vaultId) {
    const response = await api.get(`api/vaults/${vaultId}/keeps`)
    logger.log('Got Public Vault Keeps!', response.data)
    AppState.vaultKeeps = response.data.map(pojo => new VaultKeep(pojo))
  }

  async deleteVaultKeep(vaultKeepId) {
    const response = await api.delete(`api/vaultkeeps/${vaultKeepId}`)
    logger.log('Deleted VaultKeep!', response.data)
    logger.log('vaultKeepId', vaultKeepId)
    const vaultKeep = AppState.vaultKeeps
    const index = vaultKeep.findIndex(vaultKeep => vaultKeep.id == vaultKeepId)
    vaultKeep.splice(index, 1)
  }

}

export const vaultKeepService = new VaultKeepService();