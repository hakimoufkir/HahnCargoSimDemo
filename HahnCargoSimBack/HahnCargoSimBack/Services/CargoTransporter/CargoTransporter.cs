using System.Net;
using System.Net.Http.Headers;
using System.Text;
using HahnCargoSimBack.Models;
using Newtonsoft.Json;

namespace HahnCargoSimBack.Services.CargoTransporter;

public class CargoTransporter : ICargoTransporter
{
    private readonly IConfiguration _configuration;

    public CargoTransporter(IConfiguration configuration)
    {
        _configuration = configuration;
    }

public async Task<int> Buy(int positionNodeId, string token)
    {
        token = System.Text.RegularExpressions.Regex.Replace(token, "^Bearer\\s+", string.Empty,
            System.Text.RegularExpressions.RegexOptions.IgnoreCase);

        try
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Assuming the endpoint URL and any necessary parameters
                string apiUrl = $"{_configuration.GetValue<string>("HahnCarGoSim:EndPoint")}/CargoTransporter/Buy?positionNodeId={positionNodeId}";

                // Send the POST request (although it's a POST request, we're using it for illustrative purposes)
                var response = await httpClient.PostAsync(apiUrl, null);

                if (response.IsSuccessStatusCode)
                {
                    // Read the response content if necessary
                    var responseContent = await response.Content.ReadAsStringAsync();
                    // Parse the response content to int if needed
                    return JsonConvert.DeserializeObject<int>(responseContent);
                }
                else if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new UnauthorizedAccessException("Unauthorized access to the API.");
                }
                else
                {
                    // Handle other error cases
                    response.EnsureSuccessStatusCode();
                    return 0; // or throw an appropriate exception
                }
            }
        }
        catch (HttpRequestException ex)
        {
            // Handle network errors
            throw new ApplicationException("Error communicating with the server.", ex);
        }
        catch (JsonReaderException ex)
        {
            // Handle JSON parsing errors
            throw new ApplicationException("Error parsing server response.", ex);
        }
    }
public async Task<CargoTransporterModel> Get(int transporterId,string token)
    {
       token = System.Text.RegularExpressions.Regex.Replace(token, "^Bearer\\s+", string.Empty,
            System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        try
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Construct the API URL with query parameter
                string apiUrl = $"{_configuration.GetValue<string>("HahnCarGoSim:EndPoint")}/CargoTransporter/Get?transporterId={transporterId}";

                // Send the GET request
                var response = await httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    // Read the response content
                    var responseContent = await response.Content.ReadAsStringAsync();
                    
                    // Deserialize JSON response to CargoTransporterModel
                    var cargoTransporter = JsonConvert.DeserializeObject<CargoTransporterModel>(responseContent);
                    
                    return cargoTransporter;
                }
                else if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new UnauthorizedAccessException("Unauthorized access to the API.");
                }
                else
                {
                    // Handle other error cases
                    response.EnsureSuccessStatusCode();
                    return null; // or throw an appropriate exception
                }
            }
        }
        catch (HttpRequestException ex)
        {
            // Handle network errors
            throw new ApplicationException("Error communicating with the server.", ex);
        }
        catch (JsonReaderException ex)
        {
            // Handle JSON parsing errors
            throw new ApplicationException("Error parsing server response.", ex);
        }
    }
public async Task Move(int transporterId, int targetNodeId,string token)
    {
        token = System.Text.RegularExpressions.Regex.Replace(token, "^Bearer\\s+", string.Empty,
            System.Text.RegularExpressions.RegexOptions.IgnoreCase);

        try
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Construct the API URL
                string apiUrl = $"{_configuration.GetValue<string>("HahnCarGoSim:EndPoint")}/CargoTransporter/Move?transporterId={transporterId}&targetNodeId={targetNodeId}";

                // Send the PUT request (HttpMethod.Put)
                var response = await httpClient.PutAsync(apiUrl, null);

                if (response.IsSuccessStatusCode)
                {
                    // Optional: Handle success scenario if needed
                }
                else if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    throw new HttpRequestException($"Bad Request: {errorContent}");
                }
                else if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new UnauthorizedAccessException("Unauthorized access to the API.");
                }
                else
                {
                    // Handle other error cases
                    response.EnsureSuccessStatusCode();
                    // Optional: Throw an appropriate exception or handle the error
                }
            }
        }
        catch (HttpRequestException ex)
        {
            // Handle network errors
            throw new ApplicationException("Error communicating with the server.", ex);
        }
    }
}