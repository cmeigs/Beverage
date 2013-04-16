using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BeverageSandbox.Models;

namespace BeverageSandbox.Controllers
{
    public class BeerController : Controller
    {
        private BeverageContext db = new BeverageContext();

        // GET: /Beer/
        public ActionResult Index()
        {
            return View(db.Beers.ToList());
        }


        // GET: /Beer/PartialBeerList/5
        public ActionResult PartialBeerList(int id)
        {
            Brand brand = db.Brands.Find(id);
            return PartialView(brand.Beers);
        }


        // GET: /Beer/Details/5
        public ActionResult Details(int id = 0)
        {
            Beer beer = db.Beers.Find(id);
            if (beer == null)
            {
                return HttpNotFound();
            }
            return View(beer);
        }


        // GET: /Beer/Create
        public ActionResult Create()
        {
            ViewBag.BrandList = new SelectList(db.Brands, "BrandID", "Name");        
            return View();
        }


        // POST: /Beer/Create
        [HttpPost]
        public ActionResult Create(Beer beer)
        {
            beer.Brand = db.Brands.Find(beer.Brand.BrandID);
            //if (ModelState.IsValid)
            //{
                db.Beers.Add(beer);
                db.SaveChanges();
                return RedirectToAction("Index");
            //}
            //return View(beer);
        }


        // GET: /Beer/Edit/5
        public ActionResult Edit(int id = 0)
        {
            Beer beer = db.Beers.Find(id);
            if (beer == null)
            {
                return HttpNotFound();
            }
            return View(beer);
        }


        // POST: /Beer/Edit/5
        [HttpPost]
        public ActionResult Edit(Beer beer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(beer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(beer);
        }


        // GET: /Beer/Delete/5
        public ActionResult Delete(int id = 0)
        {
            Beer beer = db.Beers.Find(id);
            if (beer == null)
            {
                return HttpNotFound();
            }
            return View(beer);
        }


        // POST: /Beer/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Beer beer = db.Beers.Find(id);
            db.Beers.Remove(beer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}