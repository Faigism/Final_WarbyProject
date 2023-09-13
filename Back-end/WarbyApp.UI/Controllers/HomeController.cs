using Microsoft.AspNetCore.Mvc;

namespace WarbyApp.UI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
