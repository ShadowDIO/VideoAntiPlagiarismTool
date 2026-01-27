using Microsoft.AspNetCore.Mvc;

namespace Services.Controllers
{
    public class TestsController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Endpoint Accessible!");
        }
    }
}
