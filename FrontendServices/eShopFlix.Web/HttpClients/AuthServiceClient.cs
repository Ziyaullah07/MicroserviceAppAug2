using System.Text.Json;
using System.Text;
using eShopFlix.Web.Models;

namespace eShopFlix.Web.HttpClients
{
    public class AuthServiceClient
    {
        HttpClient _client;
        public AuthServiceClient(HttpClient httpClient)
        {
            _client = httpClient;
        }

        public async Task<UserModel> LoginAsync(LoginModel model)
        {
            StringContent content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PostAsync("auth/login", content);
            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                if (responseContent != null)
                {
                    return JsonSerializer.Deserialize<UserModel>(responseContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                }
            }
            return null;
        }

        public async Task<bool> RegisterAsync(SignUpModel model)
        {
            StringContent content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PostAsync("auth/SignUp", content);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
