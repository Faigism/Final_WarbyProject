using Microsoft.AspNetCore.Mvc;

namespace WarbyApp.UI.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
