using Business.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace EShopyy.Controllers
{
    public class ProductController : Controller
    {
        ProductRepository productRepository = new ProductRepository();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProductDetails(int id)
        {
            var details =productRepository.GetById(id);
            return View(details);
        }
    }
}
