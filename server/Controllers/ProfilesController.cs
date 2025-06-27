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

  [HttpGet("{profileId}")]
  public ActionResult<Profile> GetProfileById(int profileId)
  {
    try
    {
      Profile profile = _profilesService.GetProfileById(profileId);
      return Ok(profile);
    }
    catch (Exception error)
    {
      return BadRequest(error.Message);
    }
  }
  // TODO get profile by id
  // TODO get profile keeps
  // TODO get profile vaults





}
