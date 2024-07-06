using HahnCargoSimBack.Interfaces;
using HahnCargoSimBack.Models;
using Microsoft.AspNetCore.Mvc;

namespace HahnCargoSimBack.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController: ControllerBase
{
    private readonly IUniteOfService _unitOfService;


    public UserController(IUniteOfService unitOfService)
    {
        _unitOfService = unitOfService;

    }
    [HttpGet("laughed")]
    public int HeLaughed()
    {
        return 0;
    }

    [HttpGet("getCoin")]
    public async Task<IActionResult> CoinAmount([FromHeader] string token)
    {
        if (string.IsNullOrEmpty(token))
        {
            return BadRequest(new { message = "Server Internal Error" });
        }

        try
        {
            var response = await _unitOfService.User.GetAmount(token);
            return Ok(response);
        }
        catch (HttpRequestException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            // Log the exception details here
            return StatusCode(500, new { message = "An unexpected error occurred", details = ex.Message });
        }
    }    
    [HttpPost("Auth")]
    public async Task<IActionResult> Auth([FromBody] UserAuthenticate userAuthenticate)
    {
        if (userAuthenticate == null || string.IsNullOrEmpty(userAuthenticate.Username) || string.IsNullOrEmpty(userAuthenticate.Password))
        {
            return BadRequest(new { message = "Username or password is empty" });
        }

        try
        {
            LoginResponse loginResponse = await _unitOfService.User.Auth(userAuthenticate);
            return Ok(loginResponse);
        }
        catch (HttpRequestException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            // Log the exception details here
            return StatusCode(500, new { message = "An unexpected error occurred", details = ex.Message });
        }

    }

 
}