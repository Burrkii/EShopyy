using Business.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace EShopyy.Controllers
{
    public class HomeController : Controller
    {
        ProductRepository productRepository = new ProductRepository();
        public IActionResult Index()
        {
            return View(productRepository.GetAll()) ;
        }
    }
}
