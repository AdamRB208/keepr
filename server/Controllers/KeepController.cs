
[ApiController]
[Route("api/[controller]")]
public class KeepController : ControllerBase
{
  private readonly KeepService _keepService;
  private readonly Auth0Provider _auth0Provider;

  public KeepController(KeepService keepService, Auth0Provider auth0Provider)
  {
    _keepService = keepService;
    _auth0Provider = auth0Provider;
  }

  [Authorize]
  [HttpPost]
  public async Task<ActionResult<Keep>> CreateKeep([FromBody] Keep keepData)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      keepData.CreatorId = userInfo.Id;
      Keep keep = _keepService.CreateKeep(keepData);
      return Ok(keep);
    }
    catch (Exception error)
    {
      return BadRequest(error.Message);
    }
  }
}