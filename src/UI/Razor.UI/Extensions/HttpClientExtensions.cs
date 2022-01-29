using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Text.Json;
namespace Razor.UI.Extensions
{
    public static class HttpClientExtensions
    {
        public static async Task<T> ReadContentAs<T>(this HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
                throw new ApplicationException($"Something went wrong calling the API: {response.ReasonPhrase}");

            var dataAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return JsonSerializer.Deserialize<T>(dataAsString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public static Task<HttpResponseMessage> PostAsJson<T>(this HttpClient httpClient, string url, T data)
        {
            var dataAsString = JsonSerializer.Serialize(data);
            var content = new StringContent(dataAsString);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return httpClient.PostAsync(url, content);
        }

        public static Task<HttpResponseMessage> PutAsJson<T>(this HttpClient httpClient, string url, T data)
        {
            var dataAsString = JsonSerializer.Serialize(data);
            var content = new StringContent(dataAsString);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return httpClient.PutAsync(url, content);
        }

        public static void SetBasicAuthentication(this HttpClient client, string userName, string password) =>
       client.DefaultRequestHeaders.Authorization = new BasicAuthenticationHeaderValue(userName, password);

        public static void SetToken(this HttpClient client, string scheme, string token) =>
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(scheme, token);

        public static void SetBearerToken(this HttpClient client, string token) =>
            client.SetToken(JwtConstants.TokenType, token);
    }

}
