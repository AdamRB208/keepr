import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { Keep } from "@/models/Keep.js"
import { AppState } from "@/AppState.js"

class KeepService {

  async setActiveKeep(keepId) {
    const response = await api.get(`api/keeps/${keepId}`)
    logger.log('Got keep by keepId!', response.data)
    const activeKeep = new Keep(response.data)
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

  async getKeepsByProfileId(profileId) {
    const response = await api.get(`api/profiles/${profileId}/keeps`)
    logger.log('Got Keeps!', response.data)
    AppState.accountKeeps = response.data.map(pojo => new Keep(pojo))
  }

}

export const keepService = new KeepService()