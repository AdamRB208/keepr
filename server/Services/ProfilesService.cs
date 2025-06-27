public class ProfilesService
{
  private readonly ProfilesRepository _profilesRepository;

  public ProfilesService(ProfilesRepository profilesRepository)
  {
    _profilesRepository = profilesRepository;
  }
}