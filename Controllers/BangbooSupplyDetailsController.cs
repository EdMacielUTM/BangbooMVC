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
    public class BangbooSupplyDetailsController : Controller
    {
        private BangbooNETEntities db = new BangbooNETEntities();

        // GET: BangbooSupplyDetails
        public ActionResult Index()
        {
            var bangbooSupplyDetails = db.BangbooSupplyDetails.Include(b => b.Bangboo).Include(b => b.BangbooSupplier);
            return View(bangbooSupplyDetails.ToList());
        }

        // GET: BangbooSupplyDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BangbooSupplyDetail bangbooSupplyDetail = db.BangbooSupplyDetails.Find(id);
            if (bangbooSupplyDetail == null)
            {
                return HttpNotFound();
            }
            return View(bangbooSupplyDetail);
        }

        // GET: BangbooSupplyDetails/Create
        public ActionResult Create()
        {
            ViewBag.ID_Bangboo = new SelectList(db.Bangboos, "ID_Bangboo", "Name");
            ViewBag.ID_Supplier = new SelectList(db.BangbooSuppliers, "ID_Supplier", "Name");
            return View();
        }

        // POST: BangbooSupplyDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Detail,ID_Bangboo,ID_Supplier,SupplyAmount,SupplyDate,UnitCost")] BangbooSupplyDetail bangbooSupplyDetail)
        {
            if (ModelState.IsValid)
            {
                db.BangbooSupplyDetails.Add(bangbooSupplyDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Bangboo = new SelectList(db.Bangboos, "ID_Bangboo", "Name", bangbooSupplyDetail.ID_Bangboo);
            ViewBag.ID_Supplier = new SelectList(db.BangbooSuppliers, "ID_Supplier", "Name", bangbooSupplyDetail.ID_Supplier);
            return View(bangbooSupplyDetail);
        }

        // GET: BangbooSupplyDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BangbooSupplyDetail bangbooSupplyDetail = db.BangbooSupplyDetails.Find(id);
            if (bangbooSupplyDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Bangboo = new SelectList(db.Bangboos, "ID_Bangboo", "Name", bangbooSupplyDetail.ID_Bangboo);
            ViewBag.ID_Supplier = new SelectList(db.BangbooSuppliers, "ID_Supplier", "Name", bangbooSupplyDetail.ID_Supplier);
            return View(bangbooSupplyDetail);
        }

        // POST: BangbooSupplyDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Detail,ID_Bangboo,ID_Supplier,SupplyAmount,SupplyDate,UnitCost")] BangbooSupplyDetail bangbooSupplyDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bangbooSupplyDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Bangboo = new SelectList(db.Bangboos, "ID_Bangboo", "Name", bangbooSupplyDetail.ID_Bangboo);
            ViewBag.ID_Supplier = new SelectList(db.BangbooSuppliers, "ID_Supplier", "Name", bangbooSupplyDetail.ID_Supplier);
            return View(bangbooSupplyDetail);
        }

        // GET: BangbooSupplyDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BangbooSupplyDetail bangbooSupplyDetail = db.BangbooSupplyDetails.Find(id);
            if (bangbooSupplyDetail == null)
            {
                return HttpNotFound();
            }
            return View(bangbooSupplyDetail);
        }

        // POST: BangbooSupplyDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BangbooSupplyDetail bangbooSupplyDetail = db.BangbooSupplyDetails.Find(id);
            db.BangbooSupplyDetails.Remove(bangbooSupplyDetail);
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
