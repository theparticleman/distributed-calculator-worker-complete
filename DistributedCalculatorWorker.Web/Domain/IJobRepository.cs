namespace DistributedCalculatorWorker.Web;

public interface IJobRepository
{
    void Store(string jobId, string result);
}