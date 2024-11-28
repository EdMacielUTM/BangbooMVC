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
    public class SalesReceiptsController : Controller
    {
        private BangbooNETEntities db = new BangbooNETEntities();

        // GET: SalesReceipts
        public ActionResult Index()
        {
            var salesReceipts = db.SalesReceipts.Include(s => s.Customer).Include(s => s.Employee);
            return View(salesReceipts.ToList());
        }

        // GET: SalesReceipts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesReceipt salesReceipt = db.SalesReceipts.Find(id);
            if (salesReceipt == null)
            {
                return HttpNotFound();
            }
            return View(salesReceipt);
        }

        // GET: SalesReceipts/Create
        public ActionResult Create()
        {
            ViewBag.Customer_ID = new SelectList(db.Customers, "ID_Customer", "FirstName");
            ViewBag.Employee_ID = new SelectList(db.Employees, "ID_Employee", "FirstName");
            return View();
        }

        // POST: SalesReceipts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Sale,SaleDate,Employee_ID,Customer_ID,TotalAmount")] SalesReceipt salesReceipt)
        {
            if (ModelState.IsValid)
            {
                db.SalesReceipts.Add(salesReceipt);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Customer_ID = new SelectList(db.Customers, "ID_Customer", "FirstName", salesReceipt.Customer_ID);
            ViewBag.Employee_ID = new SelectList(db.Employees, "ID_Employee", "FirstName", salesReceipt.Employee_ID);
            return View(salesReceipt);
        }

        // GET: SalesReceipts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesReceipt salesReceipt = db.SalesReceipts.Find(id);
            if (salesReceipt == null)
            {
                return HttpNotFound();
            }
            ViewBag.Customer_ID = new SelectList(db.Customers, "ID_Customer", "FirstName", salesReceipt.Customer_ID);
            ViewBag.Employee_ID = new SelectList(db.Employees, "ID_Employee", "FirstName", salesReceipt.Employee_ID);
            return View(salesReceipt);
        }

        // POST: SalesReceipts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Sale,SaleDate,Employee_ID,Customer_ID,TotalAmount")] SalesReceipt salesReceipt)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salesReceipt).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Customer_ID = new SelectList(db.Customers, "ID_Customer", "FirstName", salesReceipt.Customer_ID);
            ViewBag.Employee_ID = new SelectList(db.Employees, "ID_Employee", "FirstName", salesReceipt.Employee_ID);
            return View(salesReceipt);
        }

        // GET: SalesReceipts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesReceipt salesReceipt = db.SalesReceipts.Find(id);
            if (salesReceipt == null)
            {
                return HttpNotFound();
            }
            return View(salesReceipt);
        }

        // POST: SalesReceipts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SalesReceipt salesReceipt = db.SalesReceipts.Find(id);
            db.SalesReceipts.Remove(salesReceipt);
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
