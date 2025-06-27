

public class ProfilesService
{
  private readonly ProfilesRepository _profilesRepository;

  private readonly KeepsService _keepsService;

  private readonly VaultsService _vaultsService;

  public ProfilesService(ProfilesRepository profilesRepository, KeepsService keepsService, VaultsService vaultsService)
  {
    _profilesRepository = profilesRepository;
    _keepsService = keepsService;
    _vaultsService = vaultsService;
  }

  internal Profile GetProfileById(string profileId)
  {
    Profile profile = _profilesRepository.GetProfileById(profileId);
    if (profile == null)
    {
      throw new Exception($"No profile found with the id of {profileId}!");
    }
    return profile;
  }

  internal List<Keep> GetUsersKeeps(string profileId, Account userInfo)
  {
    List<Keep> keeps = _keepsService.GetKeepsByCreatorId(userInfo.Id);

    List<Keep> foundKeeps = _profilesRepository.GetUsersKeeps(profileId);
    return foundKeeps;
  }

  internal List<Vault> GetUsersVaults(string profileId, Account userInfo)
  {
    List<Vault> vaults = _vaultsService.GetVaultsByCreatorId(userInfo.Id);

    List<Vault> foundVaults = _profilesRepository.GetUsersVaults(profileId);
    return foundVaults;
  }
}