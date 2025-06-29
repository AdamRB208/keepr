import { logger } from "@/utils/Logger.js";
import { api } from "./AxiosService.js";
import { AppState } from "@/AppState.js";
import { VaultKeep } from "@/models/VaultKeep.js";

class VaultKeepService {
  async getPublicVaultKeeps(vaultId) {
    const response = await api.get(`api/vaults/${vaultId}/keeps`)
    logger.log('Got Public Vault Keeps!', response.data)
    AppState.vaultKeeps = response.data.map(pojo => new VaultKeep(pojo))
  }

}

export const vaultKeepService = new VaultKeepService();