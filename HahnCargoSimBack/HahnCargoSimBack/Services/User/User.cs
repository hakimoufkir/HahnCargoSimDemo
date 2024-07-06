using System.Net.Http.Headers;
using System.Text;
using HahnCargoSimBack.Models;
using Newtonsoft.Json;

namespace HahnCargoSimBack.Services.User;

public class User : IUser
{
    private readonly IConfiguration _configuration;

    public User(IConfiguration configuration)
    {
        _configuration = configuration;

    }
    public async  Task<LoginResponse> Auth(UserAuthenticate userAuthenticate)
    {
        using (var httpClient = new HttpClient())
        {
            var json = JsonConvert.SerializeObject(userAuthenticate);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(_configuration.GetValue<string>("HahnCarGoSim:EndPoint")+"/User/Login", content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var loginResponse = JsonConvert.DeserializeObject<LoginResponse>(responseContent);
                return loginResponse;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                var error = JsonConvert.DeserializeObject<ErrorResponse>(errorContent);
                throw new HttpRequestException($"Bad Request: {error.Message}");
            }
            else
            {
                response.EnsureSuccessStatusCode();
                return null; // This line will never be reached, but is necessary to satisfy the return type.
            }
        }
    }

    public async Task<int> GetAmount(string token)
    {
        using (var httpClient = new HttpClient())
        {
            token = System.Text.RegularExpressions.Regex.Replace(token, "^Bearer\\s+", string.Empty, System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            // Set up the request headers
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        
            // Make the GET request
            var response = await httpClient.GetAsync(_configuration.GetValue<string>("HahnCarGoSim:EndPoint") + "/User/CoinAmount");

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var responseDeserialized = JsonConvert.DeserializeObject<int>(responseContent);
                return responseDeserialized;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                var error = JsonConvert.DeserializeObject<ErrorResponse>(errorContent);
                throw new HttpRequestException($"Bad Request: {error.Message}");
            }
            else
            {
                response.EnsureSuccessStatusCode();
                return 0; // Default return value if the request is not successful
            }
        }
    }
}