

public class VaultKeepsService
{

  private readonly VaultKeepsRepository _vaultKeepsRepository;

  public VaultKeepsService(VaultKeepsRepository vaultKeepsRepository)
  {
    _vaultKeepsRepository = vaultKeepsRepository;
  }

  internal VaultKeep CreateVaultKeep(VaultKeep vaultKeepData)
  {
    VaultKeep vaultkeep = _vaultKeepsRepository.CreateVaultKeep(vaultKeepData);
    return vaultkeep;
  }
}