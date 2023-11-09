using DistributedCalculatorWorker.Web;

namespace DistributedCalculatorWorker.Tests;

public class CalculatorTests
{
  [TestCase("CALCULATE: 1 + 2", "3")]
  [TestCase("CALCULATE: 123 + 256", "379")]
  [TestCase("CALCULATE: 395 - 231", "164")]
  [TestCase("CALCULATE: 680 * 77", "52360")]
  public void CalculationTests(string calculation, string expected)
  {
    var classUnderTest = new Calculator();
    var result = classUnderTest.Calculate(calculation);
    Assert.That(result, Is.EqualTo(expected));
  }
}