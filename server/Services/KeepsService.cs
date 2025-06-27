

public class KeepsService
{
  private readonly KeepsRepository _keepsRepository;

  public KeepsService(KeepsRepository keepsRepository)
  {
    _keepsRepository = keepsRepository;
  }

  internal Keep CreateKeep(Keep keepData)
  {
    Keep keep = _keepsRepository.CreateKeep(keepData);
    return keep;
  }

  internal List<Keep> GetKeeps()
  {
    List<Keep> keeps = _keepsRepository.GetKeeps();
    return keeps;
  }

  internal Keep GetKeepsById(int keepId)
  {
    Keep keep = _keepsRepository.GetKeepsById(keepId);
    keep.Views++;
    _keepsRepository.UpdateKeep(keep);

    if (keep == null)
    {
      throw new Exception($"No Keep found with the id of {keepId}");
    }
    return keep;
  }

  internal Keep UpdateKeep(int keepId, Keep keepUpdateData, Account userInfo)
  {
    Keep keep = GetKeepsById(keepId);
    if (keep.CreatorId != userInfo.Id)
    {
      throw new Exception($"YOU ARE NOT ALLOWED TO UPDATE SOMEONE ELSE'S KEEP, {userInfo.Name.ToUpper()}!");
    }

    keep.Name = keepUpdateData.Name ?? keep.Name;
    keep.Description = keepUpdateData.Description ?? keep.Description;
    keep.Img = keepUpdateData.Img ?? keep.Img;

    _keepsRepository.UpdateKeep(keep);

    return keep;
  }

  internal string DeleteKeep(int keepId, Account userInfo)
  {
    Keep keep = GetKeepsById(keepId);
    if (keep.CreatorId != userInfo.Id)
    {
      throw new Exception($"You cannot delete another user's recipe, {userInfo.Name.ToUpper()}!");
    }
    _keepsRepository.DeleteKeep(keepId);
    return $"Deleted keep {keep.Name}!";
  }

  internal List<Keep> GetKeepsByCreatorId(string CreatorId)
  {
    List<Keep> keeps = _keepsRepository.GetKeepsByCreatorId(CreatorId);
    return keeps;
  }
}