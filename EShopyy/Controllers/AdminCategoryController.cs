using Business.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace EShopyy.Controllers
{
    public class AdminCategoryController : Controller
    {
        CategoryRepository categoryRepository = new CategoryRepository();
        public IActionResult Index()
        {
            return View(categoryRepository.GetAll());
        }
        public IActionResult Create()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                categoryRepository.Add(category);
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("","Bir Hata Oluştu");
            return View();

        }
        public IActionResult Delete(int id )
        {
            var delete = categoryRepository.GetById(id);
            categoryRepository.Delete(delete);
            return RedirectToAction("Index");
        }

     
        public IActionResult Update(int id)
        {
            var update = categoryRepository.GetById(id);
            return View(update);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Update(Category category)
        {
            if (ModelState.IsValid)
            {
                var update = categoryRepository.GetById(category.ID);
                update.Name = category.Name;
                update.Descripiton = category.Descripiton;
                categoryRepository.Update(update);
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Bir Hata Oluştu");
            return View();
           
        }

    }
}
