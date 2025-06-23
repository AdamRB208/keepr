public class VaultsService
{
  private readonly VaultsRepository _vaultsRepository;

  public VaultsService(VaultsRepository vaultsRepository)
  {
    _vaultsRepository = vaultsRepository;
  }
}