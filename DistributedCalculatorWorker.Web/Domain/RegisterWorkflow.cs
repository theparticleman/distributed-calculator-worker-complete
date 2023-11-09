
using TestableHttp;
using HttpMethod = TestableHttp.HttpMethod;
using HttpRequest = TestableHttp.HttpRequest;

namespace DistributedCalculatorWorker.Web.Domain;

public class RegisterWorkflow
{
    private readonly IHttpClient httpClient;
    private readonly IJsonSerializer jsonSerializer;

    public RegisterWorkflow(IHttpClient httpClient, IJsonSerializer jsonSerializer)
    {
        this.httpClient = httpClient;
        this.jsonSerializer = jsonSerializer;
    }

    public async Task RegisterWorkerAsync(string registrationUrl, string workerId, string teamName, string createEndpoint, string errorCheckEndpoint)
    {
        var request = new HttpRequest
        {
            Url = registrationUrl,
            Method = HttpMethod.POST,
            Body = jsonSerializer.Serialize(new RegistrationRequestBody
            {
                WorkerId = workerId,
                TeamName = teamName,
                CreateJobEndpoint = createEndpoint,
                ErrorCheckEndpoint = errorCheckEndpoint,
            })
        };
        request.Headers.Add("Content-Type", "application/json");
        var response = await httpClient.ExecuteAsync(request);
    }
}

public record RegistrationRequestBody
{
    public string WorkerId { get; set; }
    public string TeamName { get; set; }
    public string CreateJobEndpoint { get; set; }
    public string ErrorCheckEndpoint { get; set; }
}