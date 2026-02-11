using DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Services.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestsController : Controller
    {
        private readonly IVideoInformationDAL VideoInformationDAL;

        public TestsController(IVideoInformationDAL videoInformationDAL)
        {
            VideoInformationDAL = videoInformationDAL;
        }

        [HttpGet]
        //[Authorize]
        public IActionResult Index()
        {
            return Ok("Endpoint Accessible!");
        }

        [HttpGet("[action]")]
        public IActionResult DBAccess()
        {
            var results = VideoInformationDAL.Get().Where(p => p.Id == 1).ToList();

            return Ok(results);
        }
    }
}
