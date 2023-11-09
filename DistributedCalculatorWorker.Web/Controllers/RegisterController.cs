using DistributedCalculatorWorker.Web.Domain;
using Microsoft.AspNetCore.Mvc;

namespace DistributedCalculatorWorker.Web;

public class RegisterController: ControllerBase
{
    private readonly RegisterWorkflow registerWorkflow;

    public RegisterController(RegisterWorkflow registerWorkflow)
    {
        this.registerWorkflow = registerWorkflow;
    }

    [HttpPost("api/register")]
    public async Task<IActionResult> RegisterAsync([FromBody] RegistrationRequest request)
    {
        await registerWorkflow.RegisterWorkerAsync(request.RegistrationUrl, request.WorkerId, request.TeamName, request.CreateJobEndpoint, request.ErrorCheckEndpoint);
        return Ok();
    }
}

public record RegistrationRequest
{
    public string RegistrationUrl { get; set; }
    public string WorkerId { get; set; }
    public string TeamName { get; set; }
    public string CreateJobEndpoint { get; set; }
    public string ErrorCheckEndpoint { get; set; }
}