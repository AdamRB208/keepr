

public class KeepRepository
{
  private readonly IDbConnection _db;

  public KeepRepository(IDbConnection db)
  {
    _db = db;
  }

  internal Keep CreateKeep(Keep keepData)
  {
    string sql = @"
    INSERT INTO
    keeps (id, created_at, updated_at, name, description, img, views, creator_id)
    VALUES (@Id, @CreatedAt, @UpdatedAt, @Name, @Description, @Img, @Views, @CreatorId);

    SELECT keeps.*, accounts.* FROM keeps INNER JOIN accounts ON keeps.creator_id = accounts.id WHERE keeps.id = LAST_INSERT_ID();
    ";

    Keep createdKeep = _db.Query(sql, (Keep keep, Account account) =>
    {
      keep.Creator = account;
      return keep;
    }, keepData).SingleOrDefault();
    return createdKeep;
  }

}