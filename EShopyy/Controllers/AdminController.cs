using Microsoft.AspNetCore.Mvc;

namespace EShopyy.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
