using Microsoft.AspNetCore.Mvc;

namespace HahnCargoSimBack.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TestController: ControllerBase
{
    
    public string HeLaughed()
    {
        return "HHHHHHHh";
    }
    
}