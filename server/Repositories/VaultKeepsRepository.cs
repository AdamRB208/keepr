

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


  internal List<Keep> GetKeepsInPublicVault(int vaultId)
  {
    string sql = @"
      SELECT  *,
      vault_keeps.id as VaultKeepId
FROM
    vault_keeps
    INNER JOIN keeps ON keeps.id = vault_keeps.keep_id
    INNER JOIN accounts ON accounts.id = vault_keeps.creator_id
WHERE
    vault_id = @VaultId;";

    List<Keep> keeps = _db.Query(sql, (VaultKeep vaultKeep, Keep keeps, Account account) =>
    {
      keeps.Id = vaultKeep.KeepId;
      account.Id = vaultKeep.CreatorId;
      keeps.Creator = account;
      keeps.VaultKeepId = vaultKeep.Id;
      return keeps;
    }, new { vaultId }).ToList();
    return keeps;
  }

  // TODO add the delete 
  internal void DeleteVaultKeep(int vaultKeepId)
  {
    string sql = @" 
    DELETE FROM vault_keeps WHERE vault_keeps.id = @VaultKeepId;";

    int rowsAffected = _db.Execute(sql, new { vaultKeepId });
    if (rowsAffected == 0) throw new Exception("Delete was unsuccessful!");
    if (rowsAffected > 1) throw new Exception("Delete was too successful!");
  }
}