using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Users.L0Tests.Extensions
{
    internal static class HttpResponseMessageExtensions
    {
        internal static async Task<T> Deserialize<T>(this HttpResponseMessage message) => 
            JsonSerializer.Deserialize<T>(await message.Content.ReadAsStringAsync(), new JsonSerializerOptions {PropertyNameCaseInsensitive = true});
    }
}