
public class ProfilesService
{
  private readonly ProfilesRepository _profilesRepository;

  public ProfilesService(ProfilesRepository profilesRepository)
  {
    _profilesRepository = profilesRepository;
  }

  internal Profile GetProfileById(int profileId)
  {
    Profile profile = _profilesRepository.GetProfileById(profileId);
    if (profile == null)
    {
      throw new Exception($"No profile found with the id of {profileId}!");
    }
    return profile;
  }
}