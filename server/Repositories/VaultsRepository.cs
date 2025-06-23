public class VaultsRepository
{
  private readonly IDbConnection _db;

  public VaultsRepository(IDbConnection db)
  {
    _db = db;
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
}