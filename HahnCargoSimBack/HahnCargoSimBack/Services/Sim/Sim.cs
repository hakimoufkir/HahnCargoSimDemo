using System.Net.Http.Headers;
using System.Text;
using HahnCargoSimBack.Models;
using Newtonsoft.Json;

namespace HahnCargoSimBack.Services.Sim;

public class Sim:ISim
{
    private readonly IConfiguration _configuration;

    public Sim(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public async Task Start(string token)
    {
        token = System.Text.RegularExpressions.Regex.Replace(token, "^Bearer\\s+", string.Empty, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        using (var httpClient = new HttpClient())
        {           
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var content = new StringContent("{}", Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(_configuration.GetValue<string>("HahnCarGoSim:EndPoint") + "/Sim/Start", content);
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
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
            } 
        }
    }

    public async Task Stop(string token)
    {
        token = System.Text.RegularExpressions.Regex.Replace(token, "^Bearer\\s+", string.Empty, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        using (var httpClient = new HttpClient())
        {           
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var content = new StringContent("{}", Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(_configuration.GetValue<string>("HahnCarGoSim:EndPoint") + "/Sim/Stop", content);
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
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
            } 
        }
    }
}