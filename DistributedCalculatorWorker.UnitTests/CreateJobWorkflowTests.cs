using DistributedCalculatorWorker.Web;
using NSubstitute;

namespace DistributedCalculatorWorker.Tests;

public class CreateJobWorkflowTests
{
  [Test]
  public void CanSuccessfullyProcessCalculationJob()
  {
    // Arrange
    var request = new CreateRequest
    {
      JobId = "the correct job id",
      Calculation = "the calculation that got passed in",
    };
    var calculator = Substitute.For<ICalculator>();
    calculator.Calculate("the calculation that got passed in").Returns("whatever the calculator returns");
    var jobRepository = Substitute.For<IJobRepository>();
    var classUnderTest = new CreateJobWorkflow(calculator, jobRepository);

    // Act
    var result = classUnderTest.ProcessJob(request);

    // Assert
    Assert.That(result, Is.Not.Null);
    Assert.That(result.JobId, Is.EqualTo("the correct job id"));
    Assert.That(result.Result, Is.EqualTo("whatever the calculator returns"));
    jobRepository.Received().Store("the correct job id", "whatever the calculator returns");
  }
}