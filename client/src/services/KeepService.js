import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { Keep } from "@/models/Keep.js"
import { AppState } from "@/AppState.js"

class KeepService {

  setActiveKeep(activeKeep) {
    AppState.activeKeep = activeKeep
    logger.log('activeKeep', activeKeep)

  }

  async getKeeps() {
    const response = await api.get('api/keeps')
    logger.log('Got Keeps!', response.data)
    const keep = response.data.map(pojo => new Keep(pojo))
    AppState.keeps = keep
  }

  async createKeep(keepData) {
    const response = await api.post('api/keeps', keepData)
    logger.log('Created Keep!', response.data)
    const keep = new Keep(response.data)
    return keep
  }

}

export const keepService = new KeepService()