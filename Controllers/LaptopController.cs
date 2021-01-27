using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.Models;
using Microsoft.EntityFrameworkCore;

namespace OnlineShopping.Controllers
{
    public class LaptopController : Controller
    {
        private readonly OnlineShoppingDBContext _context;
        public LaptopController(OnlineShoppingDBContext context)
        {
            _context = context;
        }
        // GET: LaptopController
        public async Task<ActionResult> Index()
        {
            return View(await _context.laptop. ToListAsync());
        }
        // GET: LaptopController
        // GET: LaptopController/Details/5
        public async Task<ActionResult> Details(int? sno)
        {
            if (sno == null)
            {
                return NotFound();
            }
            var laptop = await _context.laptop. FirstOrDefaultAsync(x => x.serialNo == sno);
            if (laptop == null)
            {
                return NotFound();
            }
            return View(laptop);
        }

        // GET: LaptopController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LaptopController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LaptopController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LaptopController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LaptopController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LaptopController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
