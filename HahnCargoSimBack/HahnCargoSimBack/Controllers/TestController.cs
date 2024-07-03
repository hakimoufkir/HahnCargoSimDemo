using HahnCargoSimBack.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HahnCargoSimBack.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TestController: ControllerBase
{
    private readonly IUniteOfService _unitOfService;

    public TestController(IUniteOfService unitOfService)
    {
        _unitOfService = unitOfService;
    }
    [HttpGet]
    public int HeLaughed()
    {
        return _unitOfService.CargoTransporter.Buy(1);
        
    }
    
}