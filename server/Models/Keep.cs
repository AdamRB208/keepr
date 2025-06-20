
public class Keep : RepoItem<int>
{
  public string Name { get; set; }
  public string Description { get; set; }
  public string Img { get; set; }
  public int Views { get; set; }
  public string CreatorId { get; set; }
  public Account Creator { get; set; }
  // public VaultKeep Kept { get; set; }
}