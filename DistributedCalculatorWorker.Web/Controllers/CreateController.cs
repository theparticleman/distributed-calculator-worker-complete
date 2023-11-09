using Microsoft.AspNetCore.Mvc;

namespace DistributedCalculatorWorker.Web;

public class CreateController : ControllerBase
{
    private readonly CreateJobWorkflow createJobWorkflow;

    public CreateController(CreateJobWorkflow createJobWorkflow)
    {
        this.createJobWorkflow = createJobWorkflow;
    }

    [HttpPost("/api/create")]
    public CreateResponse Create([FromBody] CreateRequest request)
    {
        Console.WriteLine(request);
        return createJobWorkflow.ProcessJob(request);
    }
}

public record CreateRequest
{
    public string JobId { get; set; }
    public string Calculation { get; set; }
}

public record CreateResponse
{
    public string JobId { get; set; }
    public string Result { get; set; }
}