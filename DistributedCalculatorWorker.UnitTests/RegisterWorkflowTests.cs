using DistributedCalculatorWorker.Web;
using DistributedCalculatorWorker.Web.Domain;
using NSubstitute;
using TestableHttp;
using HttpMethod = TestableHttp.HttpMethod;

namespace DistributedCalculatorWorker.Tests;

public class RegisterWorkflowTests
{
    [Test]
    public async Task RegistrationIsSuccessfulAsync()
    {
        var mockHttpClient = Substitute.For<IHttpClient>();
        var mockJsonSerializer = Substitute.For<IJsonSerializer>();
        var classUnderTest = new RegisterWorkflow(mockHttpClient, mockJsonSerializer);
        var registrationUrl = "registration url";
        var workerId = "worker id";
        var teamName = "team name";
        var createEndpoint = "create endpoint";
        var errorCheckEndpoint = "error check endpoint";
        HttpRequest request = null;
        RegistrationRequestBody body = null;

        mockHttpClient
            .When(x => x.ExecuteAsync(Arg.Any<IHttpRequest>()))
            .Do(x => request = x.Arg<HttpRequest>());
        mockJsonSerializer.Serialize(default).ReturnsForAnyArgs("serialized json body");
        mockJsonSerializer
            .When(x => x.Serialize(Arg.Any<object>()))
            .Do(x => body = x.Arg<RegistrationRequestBody>());
            

        await classUnderTest.RegisterWorkerAsync(registrationUrl, workerId, teamName, createEndpoint, errorCheckEndpoint);

        Assert.That(request, Is.Not.Null);
        Assert.That(request.Url, Is.EqualTo(registrationUrl));
        Assert.That(request.Method, Is.EqualTo(HttpMethod.POST));
        Assert.That(request.Headers.Exists("Content-Type"));
        Assert.That(request.Headers.GetValue("Content-Type"), Is.EqualTo("application/json"));
        Assert.That(request.Body, Is.EqualTo("serialized json body"));
        Assert.That(body, Is.Not.Null);
        Assert.That(body.WorkerId, Is.EqualTo(workerId));
        Assert.That(body.TeamName, Is.EqualTo(teamName));
        Assert.That(body.CreateJobEndpoint, Is.EqualTo(createEndpoint));
        Assert.That(body.ErrorCheckEndpoint, Is.EqualTo(errorCheckEndpoint));
    }
}