namespace DistributedCalculatorWorker.Web;

public interface IJsonSerializer
{
    string Serialize(object obj);
}

public class JsonSerializer : IJsonSerializer
{
    public string Serialize(object obj)
    {
        return System.Text.Json.JsonSerializer.Serialize(obj);
    }
}