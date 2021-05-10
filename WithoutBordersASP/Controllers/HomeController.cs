using Microsoft.AspNetCore.Mvc;

namespace WithoutBordersASP.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("home")]
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpGet("mentors")]
        public IActionResult Mentors()
        {
            return View();
        }
    }
}