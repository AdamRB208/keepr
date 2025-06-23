
public class VaultsService
{
  private readonly VaultsRepository _vaultsRepository;

  public VaultsService(VaultsRepository vaultsRepository)
  {
    _vaultsRepository = vaultsRepository;
  }

  internal Vault CreateVault(Vault vaultData)
  {
    Vault vault = _vaultsRepository.CreateVault(vaultData);
    return vault;
  }

  internal Vault GetVaultById(int vaultId)
  {
    Vault vault = _vaultsRepository.GetVaultById(vaultId);
    if (vault == null)
    {
      throw new Exception($"No Vault found with the id of {vaultId}!");
    }
    return vault;
  }
}