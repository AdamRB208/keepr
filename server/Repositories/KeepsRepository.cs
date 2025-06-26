

public class KeepsRepository
{
  private readonly IDbConnection _db;

  public KeepsRepository(IDbConnection db)
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

  internal List<Keep> GetKeeps()
  {
    string sql = @"
    SELECT keeps.*, accounts.* FROM keeps INNER JOIN accounts on accounts.id = keeps.creator_id;";

    List<Keep> keeps = _db.Query(sql, (Keep keep, Account account) =>
    {
      keep.Creator = account;
      return keep;
    }).ToList();
    return keeps;
  }

  internal Keep GetKeepsById(int keepId)
  {
    string sql = @"
    SELECT keeps.*, accounts.* FROM keeps INNER JOIN accounts ON accounts.id = keeps.creator_id WHERE keeps.id = @keepId;";

    Keep foundKeep = _db.Query(sql, (Keep keep, Account account) =>
    {
      keep.Creator = account;
      return keep;
    }, new { keepId }).SingleOrDefault();
    return foundKeep;
  }

  internal void UpdateKeep(Keep keep)
  {
    string sql = @"
    UPDATE keeps SET name = @Name, description = @Description, img = @Img, views=@Views WHERE id = @Id LIMIT 1;";

    int rowsAffected = _db.Execute(sql, keep);

    if (rowsAffected == 0)
    {
      throw new Exception("No rows were updated!");
    }
    if (rowsAffected > 1)
    {
      throw new Exception(rowsAffected + "rows affected!");
    }
  }

  internal void DeleteKeep(int keepId)
  {
    string sql = @"DELETE FROM keeps WHERE keeps.id = @KeepId;";
    int rowsAffected = _db.Execute(sql, new { keepId });
    if (rowsAffected == 0) throw new Exception("Delete was unsuccessful");
    if (rowsAffected > 1) throw new Exception("Delete was too successful");
  }


}