

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

    if (keep == null)
    {
      throw new Exception($"No Keep found with the id of {keepId}");
    }
    return keep;
  }


}