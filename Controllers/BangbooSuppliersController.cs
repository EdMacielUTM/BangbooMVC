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
    public class BangbooSuppliersController : Controller
    {
        private BangbooNETEntities db = new BangbooNETEntities();

        // GET: BangbooSuppliers
        public ActionResult Index()
        {
            var bangbooSuppliers = db.BangbooSuppliers.Include(b => b.Address);
            return View(bangbooSuppliers.ToList());
        }

        // GET: BangbooSuppliers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BangbooSupplier bangbooSupplier = db.BangbooSuppliers.Find(id);
            if (bangbooSupplier == null)
            {
                return HttpNotFound();
            }
            return View(bangbooSupplier);
        }

        // GET: BangbooSuppliers/Create
        public ActionResult Create()
        {
            ViewBag.Address_ID = new SelectList(db.Addresses, "ID_Address", "Street_Number");
            return View();
        }

        // POST: BangbooSuppliers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Supplier,Name,Email,Phone,Address_ID")] BangbooSupplier bangbooSupplier)
        {
            if (ModelState.IsValid)
            {
                db.BangbooSuppliers.Add(bangbooSupplier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Address_ID = new SelectList(db.Addresses, "ID_Address", "Street_Number", bangbooSupplier.Address_ID);
            return View(bangbooSupplier);
        }

        // GET: BangbooSuppliers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BangbooSupplier bangbooSupplier = db.BangbooSuppliers.Find(id);
            if (bangbooSupplier == null)
            {
                return HttpNotFound();
            }
            ViewBag.Address_ID = new SelectList(db.Addresses, "ID_Address", "Street_Number", bangbooSupplier.Address_ID);
            return View(bangbooSupplier);
        }

        // POST: BangbooSuppliers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Supplier,Name,Email,Phone,Address_ID")] BangbooSupplier bangbooSupplier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bangbooSupplier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Address_ID = new SelectList(db.Addresses, "ID_Address", "Street_Number", bangbooSupplier.Address_ID);
            return View(bangbooSupplier);
        }

        // GET: BangbooSuppliers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BangbooSupplier bangbooSupplier = db.BangbooSuppliers.Find(id);
            if (bangbooSupplier == null)
            {
                return HttpNotFound();
            }
            return View(bangbooSupplier);
        }

        // POST: BangbooSuppliers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BangbooSupplier bangbooSupplier = db.BangbooSuppliers.Find(id);
            db.BangbooSuppliers.Remove(bangbooSupplier);
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
