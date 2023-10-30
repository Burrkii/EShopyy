using DataAccess.Context;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace EShopyy.Controllers
{
    public class CartController : Controller
    {
        DataDbContext dataDbContext = new DataDbContext(string.Empty);
        public IActionResult Index(decimal? Tutar)
        {
            var model = dataDbContext.Carts.ToList();
            if (model != null)
            {
                Tutar = dataDbContext.Carts.Sum(x => x.Product.Price * x.Quantity);
                ViewBag.Tutar = "Toplam Tutar =" + Tutar + "TL";
            }
            else
            {
                ViewBag.Tutar = "Sepetinizde bir ürün bulunmamakta";
            }
            return View(model);
        }
        public IActionResult AddCart(int id)
        {
            var u = dataDbContext.Products.Find(id);
            var sepet = dataDbContext.Carts.FirstOrDefault(x => x.ProductID == id);
            if (sepet != null)
            {
                sepet.Quantity++;
                sepet.Price = u.Price * sepet.Quantity;
                dataDbContext.SaveChanges();
                return RedirectToAction("Index", "Cart");
            }
            var s = new Cart
            {
                ProductID = u.ID,
                Quantity = 1,
                Price = u.Price,
                Date = DateTime.Now
            };
            dataDbContext.Carts.Add(s);
            dataDbContext.SaveChanges();
            return RedirectToAction("Index", "Cart");
        }
        public IActionResult TotalCount(int? count
            )
        {
            return View();
        }
        public void DinamikMiktar(int id, int miktar)
        {
            var model = dataDbContext.Carts.Find(id);
            model.Quantity = miktar;
            model.Price = model.Price * model.Quantity;
            dataDbContext.SaveChanges();
        }
        public IActionResult Azalt(int id)
        {
            var model = dataDbContext.Carts.Find(id);
            if (model.Quantity == 1)
            {
                dataDbContext.Carts.Remove(model);
                dataDbContext.SaveChanges();
            }
            model.Quantity--;
            model.Price = model.Price * model.Quantity;
            dataDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Arttır(int id)
        {
            var model = dataDbContext.Carts.Find(id);
            model.Quantity++;
            model.Price = model.Price * model.Quantity;
            dataDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var sil = dataDbContext.Carts.Find(id);
            dataDbContext.Carts.Remove(sil);
            dataDbContext.SaveChanges();
            return RedirectToAction("Index");
        }



    }


}
