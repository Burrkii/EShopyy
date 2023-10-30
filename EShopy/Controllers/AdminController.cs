using Microsoft.AspNetCore.Mvc;

namespace EShopy.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
