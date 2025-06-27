
public class ProfilesRepository
{
  private readonly IDbConnection _db;

  public ProfilesRepository(IDbConnection db)
  {
    _db = db;
  }

  internal Profile GetProfileById(int profileId)
  {
    string sql = @"
    SELECT * FROM accounts WHERE id = @ProfileId;";

    return _db.QueryFirstOrDefault<Profile>(sql, new { profileId });
  }

}