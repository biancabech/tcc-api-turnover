using Microsoft.AspNetCore.Mvc;

namespace API_Usuario.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
