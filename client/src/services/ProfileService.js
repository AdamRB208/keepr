import { AppState } from "@/AppState.js";
import { api } from "./AxiosService.js";
import { logger } from "@/utils/Logger.js";
import { Account } from "@/models/Account.js";

class ProfileService {
  async getProfileById(profileId) {
    AppState.account = null
    const response = await api.get(`api/profiles/${profileId}`)
    logger.log('Got Profile!', response.data)
    AppState.account = new Account(response.data)
  }


}

export const profilesService = new ProfileService();