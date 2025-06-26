public class VaultKeep : RepoItem<int>
{
  public int KeepId { get; set; }
  public int VaultId { get; set; }
  public string CreatorId { get; set; }


  // could be populated but not always required 
  // public Keep Keep { get; set; }
  // public Vault Vault { get; set; }
  // public Account Account { get; set; }
}