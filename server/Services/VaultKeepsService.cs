


public class VaultKeepsService
{

  private readonly VaultKeepsRepository _vaultKeepsRepository;
  private readonly VaultsService _vaultService;

  private readonly KeepsService _keepService;

  public VaultKeepsService(VaultKeepsRepository vaultKeepsRepository, VaultsService vaultService, KeepsService keepsService)
  {
    _vaultKeepsRepository = vaultKeepsRepository;
    _vaultService = vaultService;
    _keepService = keepsService;
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


  internal string DeleteVaultKeep(int vaultKeepId, Account userInfo)
  {
    Keep Keep = _keepService.GetKeepsById(vaultKeepId);
    if (Keep.CreatorId != userInfo.Id)
    {
      throw new Exception($"You cannot delete another users vault keep, {userInfo.Name.ToUpper()}!");
    }
    _vaultKeepsRepository.DeleteVaultKeep(vaultKeepId);
    return $"Deleted Vault Keep!";
  }

}