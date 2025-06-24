

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

  internal Vault UpdateVault(int vaultId, Vault vaultUpdateData, Account userInfo)
  {
    Vault vault = GetVaultById(vaultId);
    if (vault.CreatorId != userInfo.Id)
    {
      throw new Exception($"YOU ARE NOT ALLOWED TO UPDATE SOMEONE ELSES VAULT, {userInfo.Name.ToUpper()}!");
    }

    vault.Name = vaultUpdateData.Name ?? vault.Name;
    vault.Description = vaultUpdateData.Description ?? vault.Description;
    vault.Img = vaultUpdateData.Img ?? vault.Img;

    _vaultsRepository.UpdateVault(vault);
    return vault;
  }
  internal string DeleteVault(int vaultId, Account userInfo)
  {
    Vault vault = GetVaultById(vaultId);
    if (vault.CreatorId != userInfo.Id)
    {
      throw new Exception($"You cannot delete another users vault, {userInfo.Name.ToUpper()}!");
    }
    _vaultsRepository.DeleteVault(vaultId);
    return $"Deleted vault {vault.Name}!";
  }
}