using Microsoft.AspNetCore.Mvc;

namespace projectDemo.Controllers
{
    public class DashboardController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
           
            return View();
        }
    }
}
