

public class VaultKeepsService
{

  private readonly VaultKeepsRepository _vaultKeepsRepository;
  private readonly VaultsService _vaultService;

  public VaultKeepsService(VaultKeepsRepository vaultKeepsRepository, VaultsService vaultService)
  {
    _vaultKeepsRepository = vaultKeepsRepository;
    _vaultService = vaultService;
  }

  internal VaultKeep CreateVaultKeep(VaultKeep vaultKeepData)
  {
    VaultKeep vaultkeep = _vaultKeepsRepository.CreateVaultKeep(vaultKeepData);
    return vaultkeep;
  }

  internal List<Keep> GetKeepsInVault(int vaultId, string userId)
  {
    Vault vault = _vaultService.GetVaultById(vaultId);

    // TODO check if the vault is private and who the current user is?




    List<Keep> keeps = _vaultKeepsRepository.GetKeepsInPublicVault(vaultId);
    return keeps;
  }

}