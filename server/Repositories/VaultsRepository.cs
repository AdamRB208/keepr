


public class VaultsRepository
{
  private readonly IDbConnection _db;

  public VaultsRepository(IDbConnection db)
  {
    _db = db;
  }
  internal Vault GetVaultById(int vaultId)
  {
    string sql = @"
    SELECT vaults.*, accounts.* FROM vaults
    INNER JOIN accounts ON accounts.id = vaults.creator_id
    WHERE vaults.id = @vaultId;";

    Vault foundVault = _db.Query(sql, (Vault vault, Account account) =>
    {
      vault.Creator = account;
      return vault;
    }, new { vaultId }).SingleOrDefault();
    return foundVault;
  }

  internal Vault CreateVault(Vault vaultData)
  {
    string sql = @"INSERT INTO
    vaults (id, created_at, updated_at, name, description, img, is_private, creator_id)
    VALUES (@Id, @CreatedAt, @UpdatedAt, @Name, @Description, @Img, @IsPrivate, @CreatorId);
    
    SELECT vaults.*, accounts.* FROM vaults
    INNER JOIN accounts ON vaults.creator_id = accounts.id 
    WHERE vaults.id = LAST_INSERT_ID();";

    Vault createdVault = _db.Query(sql, (Vault vault, Account account) =>
    {
      vault.Creator = account;
      return vault;
    }, vaultData).SingleOrDefault();
    return createdVault;
  }

  internal void UpdateVault(Vault vault)
  {
    string sql = @" 
    UPDATE vaults SET name = @Name, description = @Description, img = @Img WHERE id = @Id LIMIT 1;";

    int rowsAffected = _db.Execute(sql, vault);

    if (rowsAffected == 0)
    {
      throw new Exception("No rows were updated!");
    }
    if (rowsAffected > 1)
    {
      throw new Exception(rowsAffected + "rows affected!");
    }
  }

  internal void DeleteVault(int vaultId)
  {
    string sql = @"
    DELETE FROM vaults WHERE vaults.id = @VaultId;";
    int rowsAffected = _db.Execute(sql, new { vaultId });
    if (rowsAffected == 0) throw new Exception("Delete was unsuccessful");
    if (rowsAffected > 1) throw new Exception("Delete was too successful");
  }

  internal List<Vault> GetVaultsByCreatorId(string creatorId)
  {
    string sql = @"
    SELECT vaults.*, accounts.*
FROM vaults
    INNER JOIN accounts on accounts.id = vaults.creator_id
WHERE
    vaults.creator_id = @CreatorId;
    ";

    List<Vault> vaults = _db.Query(sql, (Vault vault, Account account) =>
    {
      vault.CreatorId = account.Id;
      return vault;
    }, new { creatorId }).ToList();
    return vaults;
  }
}