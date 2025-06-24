import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { Keep } from "@/models/Keep.js"
import { AppState } from "@/AppState.js"

class KeepService {

  async getKeeps() {
    const response = await api.get('api/keeps')
    logger.log('Got Keeps!', response.data)
    const keep = response.data.map(pojo => new Keep(pojo))
    AppState.keeps = keep
  }


}

export const keepService = new KeepService()