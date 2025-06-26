import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { Keep } from "@/models/Keep.js"
import { AppState } from "@/AppState.js"

class KeepService {

  setActiveKeep(activeKeep) {
    // TODO fire off request to get keep by id

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

  async deleteKeep(keepId) {
    const response = await api.delete(`api/keeps/${keepId}`)
    logger.log('Deleted Keep!', response.data)
    const keep = AppState.keeps
    const index = keep.findIndex(keep => keep.id == keepId)
    keep.splice(index, 1)
  }

}

export const keepService = new KeepService()