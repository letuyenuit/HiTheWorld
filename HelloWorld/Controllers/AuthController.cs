using Microsoft.AspNetCore.Mvc;

namespace HelloWorld.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
