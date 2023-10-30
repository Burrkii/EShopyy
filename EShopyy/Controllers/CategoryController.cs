using Business.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace EShopyy.Controllers
{
    public class CategoryController : Controller
    {
        CategoryRepository categoryRepository= new CategoryRepository();
        public PartialViewResult CategoryList()
        {
            return PartialView(categoryRepository.GetAll());
        }
    }
}
