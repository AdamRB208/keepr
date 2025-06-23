

public class KeepService
{
  private readonly KeepRepository _keepRepository;

  public KeepService(KeepRepository keepRepository)
  {
    _keepRepository = keepRepository;
  }

  internal Keep CreateKeep(Keep keepData)
  {
    Keep keep = _keepRepository.CreateKeep(keepData);
    return keep;
  }
}