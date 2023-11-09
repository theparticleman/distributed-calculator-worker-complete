

namespace DistributedCalculatorWorker.Web;

public class CreateJobWorkflow
{
    private ICalculator calculator;
    private readonly IJobRepository jobRepository;

    public CreateJobWorkflow(ICalculator calculator, IJobRepository jobRepository)
    {
        this.calculator = calculator;
        this.jobRepository = jobRepository;
    }

    public CreateResponse ProcessJob(CreateRequest request)
    {
        var result = calculator.Calculate(request.Calculation);
        jobRepository.Store(request.JobId, result);
        return new CreateResponse
        {
          JobId = request.JobId,
          Result = result,
        };
    }
}