using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using OnlineShopping.Models;
using Newtonsoft.Json;
namespace OnlineShopping.Controllers
{
    public class OrderPlacementController : Controller
    {
        private readonly OnlineShoppingDBContext context;
        public OrderPlacementController(OnlineShoppingDBContext _context)
        {
            context = _context;
        }
        //public ActionResult PlaceOrder(int id)
        //{
        //    Laptops model = new Laptops();

        //    var laptop = context.laptop.Where(s => s.serialNo == id).ToList();
        //    if (laptop.Count > 0)
        //        model = laptop[0];

        //    List<Laptops> lstOlddata = SessionHelper.GetObjectFromJson<List<Laptops>>(HttpContext.Session, "OrderPlacement");

        //    if (lstOlddata == null)
        //        lstOlddata = new List<Laptops>();

        //    if (laptop.Count > 0)
        //        lstOlddata.Add(model);

        //    SessionHelper.SetObjectAsJson(HttpContext.Session, "OrderPlacement", lstOlddata);
        //    return View(lstOlddata);

        //}
        public ActionResult PlaceOrder(int id, string val)
        {
            List<Laptops> lstOlddata = null;
            if (val == "Add")
            {
                Laptops model = new Laptops();

                var laptop = context.laptop.Where(s => s.serialNo == id).ToList();
                if (laptop.Count > 0)
                    model = laptop[0];

                lstOlddata = SessionHelper.GetObjectFromJson<List<Laptops>>(HttpContext.Session, "OrderPlacement");

                if (lstOlddata == null)
                    lstOlddata = new List<Laptops>();

                if (laptop.Count > 0)
                    lstOlddata.Add(model);

                SessionHelper.SetObjectAsJson(HttpContext.Session, "OrderPlacement", lstOlddata);
                // return View(lstOlddata);
            }
            else if (val == "Remove")
            {
               Laptops model = new Laptops();
                lstOlddata = SessionHelper.GetObjectFromJson<List<Laptops>>(HttpContext.Session, "OrderPlacement");

                if (lstOlddata.Count > 0)
                {
                    var lapmodellst = lstOlddata.Where(item => item.serialNo == id).ToList();
                    if (lapmodellst.Count > 0)
                    {
                        Laptops lapmodel = lapmodellst[0];
                        lstOlddata.Remove(lapmodel);
                    }
                }

                SessionHelper.SetObjectAsJson(HttpContext.Session, "OrderPlacement", lstOlddata);


            }
            else
            {
                lstOlddata = SessionHelper.GetObjectFromJson<List<Laptops>>(HttpContext.Session, "OrderPlacement");

                if (lstOlddata == null)
                {
                    lstOlddata = new List<Laptops>();
                }

            }
            return View(lstOlddata);
        }
        public ActionResult ProceedToBuy(int id)
        {
            string user = HttpContext.Session.GetString("LoginUser");
            if (string.IsNullOrEmpty(user))
            {
                TempData["ItemID"] = id;
                return RedirectToAction("Login", "AddToCart");
            }
            else
            {
                Laptops model = new Laptops();

                var laptop = context.laptop.Where(s => s.serialNo == id).ToList();
                if (laptop.Count > 0)
                    model = laptop[0];

                List<Laptops> lstOlddata = SessionHelper.GetObjectFromJson<List<Laptops>>(HttpContext.Session, "OrderPlacement");

                if (lstOlddata == null)
                    lstOlddata = new List<Laptops>();

                if (laptop.Count > 0)
                    lstOlddata.Add(model);

                SessionHelper.SetObjectAsJson(HttpContext.Session, "OrderPlacement", lstOlddata);


                return RedirectToAction("Index", "Checkout");
            }
        }
    }



    public static class SessionHelper
    {
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}