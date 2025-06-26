
using System.ComponentModel.DataAnnotations;

public class Keep
{
  public int VaultKeepId { get; set; }
  public int Id { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
  [MinLength(1), MaxLength(255)] public string Name { get; set; }
  [MaxLength(1000)] public string Description { get; set; }
  [MaxLength(1000)] public string Img { get; set; }
  public int Views { get; set; }
  public int Kept { get; set; }
  public string CreatorId { get; set; }
  public Account Creator { get; set; }
}

public class SavedKeep : Keep
{
  public int VaultKeepId { get; set; }

}