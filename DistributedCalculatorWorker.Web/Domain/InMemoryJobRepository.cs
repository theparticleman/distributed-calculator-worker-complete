
namespace DistributedCalculatorWorker.Web;

public class InMemoryJobRepsoitory : IJobRepository
{
  readonly Dictionary<string, string> resultLookup = new();

  public string RetrieveResult(string jobId)
  {
    return resultLookup[jobId];
  }

  public void Store(string jobId, string result)
  {
    resultLookup[jobId] = result;
  }
}