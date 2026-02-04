using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Services.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestsController : Controller
    {
        [HttpGet]
        //[Authorize]
        public IActionResult Index()
        {
            return Ok("Endpoint Accessible!");
        }
    }
}
