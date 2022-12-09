using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class Stock2Controller : Controller
    {
        private ApplicationDbContext _db;
        private IHostingEnvironment _he;

        public Stock2Controller(ApplicationDbContext db, IHostingEnvironment he)
        {
            _db = db;
            _he = he;
        }
        public IActionResult Index()
        {
            return View(_db.Stock2.Include(c => c.Produit).ToList());
        }

        public IActionResult Create()
        {
            ViewData["produitId"] = new SelectList(_db.Produit2.ToList(), "Id", "Nom");
            return View();
        }
        //Post Create method
        [HttpPost]
        public async Task<IActionResult> Create(Stock2 product)
        {
            if (ModelState.IsValid)
            {
                var searchProduct = _db.Produit2.FirstOrDefault(c => c.Id == product.ProduitId);
                if (searchProduct != null)
                {
                    ViewData["productId"] = new SelectList(_db.Produit2.ToList(), "Id", "Nom");

                }
                _db.Stock2.Add(product);
                await _db.SaveChangesAsync();
                TempData["save"] = "Le stock type has been save succesfully";
                return RedirectToAction(nameof(Index));
            }

            return View(product);
        }

        //GET Edit Action Method

        public ActionResult Edit(int? id)
        {
            ViewData["produitId"] = new SelectList(_db.Produit2.ToList(), "Id", "Nom");
            if (id == null)
            {
                return NotFound();
            }

            var product = _db.Stock2.Include(c => c.Produit).FirstOrDefault(c => c.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        //POST Edit Action Method
        [HttpPost]
        public async Task<IActionResult> Edit(Stock2 products)
        {
            if (ModelState.IsValid)
            {
                _db.Stock2.Update(products);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(products);
        }
        //GET Details Action Method
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var product = _db.Stock2.Include(c => c.Produit).FirstOrDefault(c => c.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        //GET Delete Action Method

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _db.Stock2.Include(c => c.Produit).Where(c => c.Id == id).FirstOrDefault();
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        //POST Delete Action Method

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _db.Stock2.FirstOrDefault(c => c.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            _db.Stock2.Remove(product);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
