
public class VaultKeepsRepository
{
  private readonly IDbConnection _db;

  public VaultKeepsRepository(IDbConnection db)
  {
    _db = db;
  }

  internal VaultKeep CreateVaultKeep(VaultKeep vaultKeepData)
  {
    string sql = @"
    INSERT INTO
    vault_keeps (keep_id, vault_id, creator_id) 
    VALUES (@KeepId, @VaultId, @CreatorId);

    SELECT * FROM vault_keeps
    WHERE id = LAST_INSERT_ID();";

    VaultKeep vaultKeep = _db.Query<VaultKeep>(sql, vaultKeepData).SingleOrDefault();

    return vaultKeep;
  }
}