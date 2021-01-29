using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Calculator.IntegrationTests.Helpers
{
  public static class ClientHelper
  {
    public static string AddHttpGetParams<T>(this string url, T @params)
    {
      var properties = typeof(T).GetProperties();
      if (!properties.Any())
      {
        return url;
      }

      var builder = new StringBuilder();

      foreach (var property in properties)
      {
        builder.Append($"{property.Name}={property.GetValue(@params)}");

        if (property != properties.Last())
        {
          builder.Append("&&");
        }
      }

      return $"{url}?{builder}";
    }

    public static async Task<T> ReadAs<T>(this HttpResponseMessage message)
    {
      string json = await message.Content.ReadAsStringAsync();
      T value = JsonConvert.DeserializeObject<T>(json);
      return value;
    }
  }
}