using Business.Concrete;
using DataAccess.Context;
using Entities.Concrete;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PagedList.Mvc;
using PagedList;

namespace EShopyy.Controllers
{
    public class AdminProductController : Controller
    {
        ProductRepository productRepository = new ProductRepository();
        DataDbContext dataDbContext = new DataDbContext(string.Empty);
        public IActionResult Index(/*int sayfa*/)
        {
            return View(productRepository.GetAll());
        }

        public IActionResult Create()
        {
            List<SelectListItem> degeri = (from i in dataDbContext.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Name,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.ktgr = degeri;
            return View();
        }



        [HttpPost]
        public IActionResult Create(Product product, IFormFile File)
        {
            if (ModelState.IsValid)
            {
                if (File != null && File.Length > 0)
                {
                    // Define the directory where you want to save the file
                    string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "niceAdmin", "Image");

                    // Generate a unique filename to avoid naming conflicts
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + File.FileName;

                    // Combine the uploads directory and the unique filename to get the full file path
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        File.CopyTo(stream);
                    }

                    product.Image = uniqueFileName;
                   
                    productRepository.Add(product);

                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Lütfen bir dosya seçin.");
                }
            }

            return View(product);
        }
    }
}

