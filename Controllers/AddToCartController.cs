using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineShopping.Models;
using System.Web;
using Microsoft.AspNetCore.Session;

namespace OnlineShopping.Controllers
{
    public class AddToCartController : Controller
    {

        private readonly OnlineShoppingDBContext _context;
        public AddToCartController(OnlineShoppingDBContext context)
        {
            _context = context;
        }
        public ActionResult Index(int id)
        {
            string user = HttpContext.Session.GetString("LoginUser");
            if (string.IsNullOrEmpty(user))
            {
                TempData["ItemID"] = id;
                return RedirectToAction("Login");
            }
            else
            {
                Laptops model = _context.laptop.First(s => s.serialNo == id);
                return View(model);
            }
        }

        public ActionResult Login()
        {
            ViewBag.ItemID = Convert.ToInt32(TempData["ItemID"]);

            return View();
        }

        [HttpPost]
        public ActionResult Login(string MailID, string ItemID)
        {
            HttpContext.Session.SetString("LoginUser", MailID);

            return RedirectToAction("PlaceOrder","OrderPlacement");
        }


    }
}
