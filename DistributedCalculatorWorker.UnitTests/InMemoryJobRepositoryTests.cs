using DistributedCalculatorWorker.Web;

namespace DistributedCalculatorWorker.Tests;

public class InMemoryJobRepositoryTests
{
  [Test]
  public void RoundTripTest()
  {
    var classUnderTest = new InMemoryJobRepsoitory();
    classUnderTest.Store("my job id", "the result");
    var retrievedResult = classUnderTest.RetrieveResult("my job id");
    Assert.That(retrievedResult, Is.EqualTo("the result"));
  }
}