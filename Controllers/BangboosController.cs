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
    public class BangboosController : Controller
    {
        private BangbooNETEntities db = new BangbooNETEntities();

        // GET: Bangboos
        public ActionResult Index()
        {
            return View(db.Bangboos.ToList());
        }

        // GET: Bangboos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bangboo bangboo = db.Bangboos.Find(id);
            if (bangboo == null)
            {
                return HttpNotFound();
            }
            return View(bangboo);
        }

        // GET: Bangboos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bangboos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Bangboo,Name,Element,Rank,Model,PictureURL,Price")] Bangboo bangboo)
        {
            if (ModelState.IsValid)
            {
                db.Bangboos.Add(bangboo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bangboo);
        }

        // GET: Bangboos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bangboo bangboo = db.Bangboos.Find(id);
            if (bangboo == null)
            {
                return HttpNotFound();
            }
            return View(bangboo);
        }

        // POST: Bangboos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Bangboo,Name,Element,Rank,Model,PictureURL,Price")] Bangboo bangboo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bangboo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bangboo);
        }

        // GET: Bangboos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bangboo bangboo = db.Bangboos.Find(id);
            if (bangboo == null)
            {
                return HttpNotFound();
            }
            return View(bangboo);
        }

        // POST: Bangboos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bangboo bangboo = db.Bangboos.Find(id);
            db.Bangboos.Remove(bangboo);
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
