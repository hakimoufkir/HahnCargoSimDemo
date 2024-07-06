using HahnCargoSimBack.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HahnCargoSimBack.Controllers;
[Route("api/[controller]")]
[ApiController]
public class MainController: ControllerBase
{
    private readonly IUniteOfService _unitOfService;

    public MainController(IUniteOfService unitOfService)
    {
        _unitOfService = unitOfService;

    }
    [HttpPost("start")]
    public async Task<IActionResult> Start([FromHeader] string token)
    {
        if (string.IsNullOrEmpty(token))
        {
            return BadRequest(new { message = "Token is required" });
        }

        try
        {
            await _unitOfService.Sim.Start(token);
            return Ok(new { message = "Simulation started successfully" });
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
    
    [HttpPost("stop")]
    public async Task<IActionResult> Stop([FromHeader] string token)
    {
        if (string.IsNullOrEmpty(token))
        {
            return BadRequest(new { message = "Token is required" });
        }

        try
        {
            await _unitOfService.Sim.Stop(token);
            return Ok(new { message = "Simulation stopped successfully" });
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