



public class ProfilesRepository
{
  private readonly IDbConnection _db;

  public ProfilesRepository(IDbConnection db)
  {
    _db = db;
  }

  internal Profile GetProfileById(string profileId)
  {
    string sql = @"
    SELECT * FROM accounts WHERE id = @ProfileId;";

    return _db.QueryFirstOrDefault<Profile>(sql, new { profileId });
  }

  internal List<Keep> GetUsersKeeps(string profileId)
  {
    string sql = @"
    SELECT keeps.*, accounts.*
FROM keeps
    INNER JOIN accounts on accounts.id = keeps.creator_id
WHERE
    keeps.creator_id = @ProfileId;";

    List<Keep> keeps = _db.Query(sql, (Keep keep, Account account) =>
    {
      keep.CreatorId = account.Id;
      return keep;
    }, new { profileId }).ToList();
    return keeps;

  }

  internal List<Vault> GetUsersVaults(string profileId)
  {
    string sql = @"
    SELECT vaults.*, accounts.*
FROM vaults
    INNER JOIN accounts on accounts.id = vaults.creator_id
WHERE
    vaults.creator_id = @ProfileId;";

    List<Vault> vaults = _db.Query(sql, (Vault vault, Account account) =>
    {
      vault.CreatorId = account.Id;
      return vault;
    }, new { profileId }).ToList();
    return vaults;
  }
}