import { AppState } from "@/AppState.js";
import { api } from "./AxiosService.js";
import { logger } from "@/utils/Logger.js";
import { Account, Profile } from "@/models/Account.js";

class ProfileService {
  async getProfileById(profileId) {
    AppState.activeProfile = null
    const response = await api.get(`api/profiles/${profileId}`)
    logger.log('Got Profile!', response.data)
    AppState.activeProfile = new Profile(response.data)
  }


}

export const profilesService = new ProfileService();