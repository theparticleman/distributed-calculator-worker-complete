namespace DistributedCalculatorWorker.Web;

public class Calculator : ICalculator
{
  public string Calculate(string calculation)
  {
    calculation = calculation.Replace("CALCULATE: ", "");
    var parts = calculation.Split(" ");
    var operand1 = int.Parse(parts[0]);
    var @operator = parts[1];
    var operand2 = int.Parse(parts[2]);
    var result = @operator switch {
      "+" => operand1 + operand2,
      "-" => operand1 - operand2,
      _ => operand1 * operand2,
    };
    return result.ToString();
  }
}