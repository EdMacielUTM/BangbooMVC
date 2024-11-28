using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BangbooMVC.Models;

namespace BangbooMVC.Controllers
{
    public class BangbooSalesController : Controller
    {
        private BangbooNETEntities db = new BangbooNETEntities();

        // GET: BangbooSales
        public ActionResult Index()
        {
            var bangbooSales = db.BangbooSales.Include(b => b.Bangboo).Include(b => b.SalesReceipt);
            return View(bangbooSales.ToList());
        }

        // GET: BangbooSales/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BangbooSale bangbooSale = db.BangbooSales.Find(id);
            if (bangbooSale == null)
            {
                return HttpNotFound();
            }
            return View(bangbooSale);
        }

        // GET: BangbooSales/Create
        public ActionResult Create()
        {
            ViewBag.Bangboo_ID = new SelectList(db.Bangboos, "ID_Bangboo", "Name");
            ViewBag.SalesReceipt_ID = new SelectList(db.SalesReceipts, "ID_Sale", "ID_Sale");
            return View();
        }

        // POST: BangbooSales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Bangboo_ID,SalesReceipt_ID,Quantity,ID_BangbooSales")] BangbooSale bangbooSale)
        {
            if (ModelState.IsValid)
            {
                db.BangbooSales.Add(bangbooSale);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Bangboo_ID = new SelectList(db.Bangboos, "ID_Bangboo", "Name", bangbooSale.Bangboo_ID);
            ViewBag.SalesReceipt_ID = new SelectList(db.SalesReceipts, "ID_Sale", "ID_Sale", bangbooSale.SalesReceipt_ID);
            return View(bangbooSale);
        }

        // GET: BangbooSales/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BangbooSale bangbooSale = db.BangbooSales.Find(id);
            if (bangbooSale == null)
            {
                return HttpNotFound();
            }
            ViewBag.Bangboo_ID = new SelectList(db.Bangboos, "ID_Bangboo", "Name", bangbooSale.Bangboo_ID);
            ViewBag.SalesReceipt_ID = new SelectList(db.SalesReceipts, "ID_Sale", "ID_Sale", bangbooSale.SalesReceipt_ID);
            return View(bangbooSale);
        }

        // POST: BangbooSales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Bangboo_ID,SalesReceipt_ID,Quantity,ID_BangbooSales")] BangbooSale bangbooSale)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bangbooSale).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Bangboo_ID = new SelectList(db.Bangboos, "ID_Bangboo", "Name", bangbooSale.Bangboo_ID);
            ViewBag.SalesReceipt_ID = new SelectList(db.SalesReceipts, "ID_Sale", "ID_Sale", bangbooSale.SalesReceipt_ID);
            return View(bangbooSale);
        }

        // GET: BangbooSales/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BangbooSale bangbooSale = db.BangbooSales.Find(id);
            if (bangbooSale == null)
            {
                return HttpNotFound();
            }
            return View(bangbooSale);
        }

        // POST: BangbooSales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BangbooSale bangbooSale = db.BangbooSales.Find(id);
            db.BangbooSales.Remove(bangbooSale);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
