using DataAccess.Context;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;


namespace EShopyy.Controllers
{
    public class AccountController : Controller
    {
        DataDbContext dataDbContext = new DataDbContext(string.Empty);
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(User user)
        {
            var information = dataDbContext.Users.FirstOrDefault(x => x.EMail == user.EMail && x.Password==user.Password);
            if (information == null)
            {
             
            }
            return View();
        }
    }
}
