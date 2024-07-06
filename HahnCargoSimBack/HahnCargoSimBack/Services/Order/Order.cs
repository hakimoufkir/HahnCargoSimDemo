using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using HahnCargoSimBack.Models;
using Newtonsoft.Json;

namespace HahnCargoSimBack.Services.Order;

public class Order : IOrder
{
    private readonly IConfiguration _configuration;

    public Order(IConfiguration configuration)
    {
        _configuration = configuration;
    }

   public async Task<List<Order>> GetAllAvailable(string token)
    {
        using (var httpClient = new HttpClient())
        {           
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await httpClient.GetAsync(_configuration.GetValue<string>("HahnCarGoSim:EndPoint") + "/Order/GetAllAvailable");
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var responseDeserialized = JsonConvert.DeserializeObject<List<Order>>(responseContent);
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
                return []; // This line will never be reached, but is necessary to satisfy the return type.
            } 
        }
    }

    public async Task<List<Order>> GetAllAccepted(string token)
    {
        using (var httpClient = new HttpClient())
        {           
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await httpClient.GetAsync(_configuration.GetValue<string>("HahnCarGoSim:EndPoint") + "/Order/GetAllAccepted");
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var responseDeserialized = JsonConvert.DeserializeObject<List<Order>>(responseContent);
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
                return []; // This line will never be reached, but is necessary to satisfy the return type.
            } 
        }
    }

    public async Task Accept(int orderId,string token)
    {
        using (var httpClient = new HttpClient())
        {           
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var content = new StringContent("{}", Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(_configuration.GetValue<string>("HahnCarGoSim:EndPoint") + "/Order/Accept?orderId=" + orderId, content);
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

    public async Task Create(string token)
    {
        using (var httpClient = new HttpClient())
        {           
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var content = new StringContent("{}", Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(_configuration.GetValue<string>("HahnCarGoSim:EndPoint") + "/Order/Create", content);
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

    public async Task GenerateFile(int maxTicks, string filename,string token)
    {
        using (var httpClient = new HttpClient())
        {           
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var content = new StringContent("{}", Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(_configuration.GetValue<string>("HahnCarGoSim:EndPoint") + "/Order/GenerateFile?maxTicks="+maxTicks+"&filename="+filename, content);
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