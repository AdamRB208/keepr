public class VaultKeep : RepoItem<int>
{
  public Keep KeepId { get; set; }
  public Vault VaultId { get; set; }
  public Account CreatorId { get; set; }
}