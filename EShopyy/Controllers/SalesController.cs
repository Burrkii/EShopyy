using DataAccess.Context;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace EShopyy.Controllers
{
    public class SalesController : Controller
    {
        DataDbContext dataDbContext = new DataDbContext(string.Empty);
        public IActionResult Index()
        {
            var model = dataDbContext.Sales.ToList();
            return View(model);
        }
        public IActionResult Buy(int id)
        {
            var model = dataDbContext.Carts.FirstOrDefault(x => x.ID == id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Buy2(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var model = dataDbContext.Carts.FirstOrDefault(x => x.ID == id);
                    var satis = new Sales
                    {
                        UserId = model.UserId,
                        ProductID = model.ProductID,
                        Quantity = model.Quantity,
                        Image = model.Image,
                        Price = model.Price,
                        Date = model.Date
                    };
                    dataDbContext.Carts.Remove(model);
                    dataDbContext.Sales.Add(satis);
                    dataDbContext.SaveChanges();
                    ViewBag.islem = "Satın alma işlemi Gerçekleşmiştir";
                }

            }
            catch (Exception)
            {

                ViewBag.islem = "Satın alma işlemi Başarısız";
            }
            return View("islem");
        }
    }
}
