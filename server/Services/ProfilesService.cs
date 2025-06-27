

public class ProfilesService
{
  private readonly ProfilesRepository _profilesRepository;

  private readonly KeepsService _keepsService;

  public ProfilesService(ProfilesRepository profilesRepository, KeepsService keepsService)
  {
    _profilesRepository = profilesRepository;
    _keepsService = keepsService;
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
}