namespace keepr.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfilesController : ControllerBase
{

  private readonly ProfilesService _profilesService;

  private readonly Auth0Provider _auth0Provider;

  public ProfilesController(ProfilesService profilesService, Auth0Provider auth0Provider)
  {
    _profilesService = profilesService;
    _auth0Provider = auth0Provider;
  }



  // TODO get profile by id
  // TODO get profile keeps
  // TODO get profile vaults





}
