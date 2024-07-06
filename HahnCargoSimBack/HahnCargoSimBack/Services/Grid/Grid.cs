using System.Net.Http.Headers;
using System.Text;
using HahnCargoSimBack.Models;
using Newtonsoft.Json;

namespace HahnCargoSimBack.Services.Grid;

public class Grid : IGrid
{
    private readonly IConfiguration _configuration;

    public Grid(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<string> Get(string token)
    {
        token = System.Text.RegularExpressions.Regex.Replace(token, "^Bearer\\s+", string.Empty,
            System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        using (var httpClient = new HttpClient())
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response =
                await httpClient.GetAsync(_configuration.GetValue<string>("HahnCarGoSim:EndPoint") + "/Grid/Get");
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                return responseContent;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                var error = JsonConvert.DeserializeObject<ErrorResponse>(errorContent);
                throw new HttpRequestException($"Bad Request: {error.Message}");
            }
            else
            {
                return response.EnsureSuccessStatusCode().ToString();
            }
        }
    }

    public async Task GenerateFile(int numberOfNodes, int numberOfEdges, int numberOfConnectionsPerNode,
        string filename, string token)
    {
        token = System.Text.RegularExpressions.Regex.Replace(token, "^Bearer\\s+", string.Empty,
            System.Text.RegularExpressions.RegexOptions.IgnoreCase);

        using (var httpClient = new HttpClient())
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            // Construct the URL based on parameters
            string apiUrl = $"{_configuration.GetValue<string>("HahnCarGoSim:EndPoint")}/Grid/GenerateFile?" +
                            $"numberOfNodes={numberOfNodes}&" +
                            $"numberOfEdges={numberOfEdges}&" +
                            $"numberOfConnectionsPerNode={numberOfConnectionsPerNode}&" +
                            $"filename={filename}";

            var response = await httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                // Assuming the API returns the file content as string
                var fileContent = await response.Content.ReadAsStringAsync();
                // Here you can save the file content to disk or process it further
                // For example, save to a file:
                // File.WriteAllText(filename, fileContent);
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                var error = JsonConvert.DeserializeObject<ErrorResponse>(errorContent);
                throw new HttpRequestException($"Bad Request: {error.Message}");
            }
            else
            {
                response.EnsureSuccessStatusCode(); // This will throw an exception if the status code is not success
            }
        }
    }
}
