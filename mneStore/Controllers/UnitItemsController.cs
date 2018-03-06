using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mneStore.Models;

namespace mneStore.Controllers
{
    public class UnitItemsController : Controller
    {
        private mneStoreContext db = new mneStoreContext();

        // GET: UnitItems
        public ActionResult Index()
        {
            return View(db.UnitItems.ToList());
        }

        // GET: UnitItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UnitItems unitItems = db.UnitItems.Find(id);
            if (unitItems == null)
            {
                return HttpNotFound();
            }
            return View(unitItems);
        }

        // GET: UnitItems/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UnitItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,NameUnit")] UnitItems unitItems)
        {
            if (ModelState.IsValid)
            {
                db.UnitItems.Add(unitItems);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(unitItems);
        }

        // GET: UnitItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UnitItems unitItems = db.UnitItems.Find(id);
            if (unitItems == null)
            {
                return HttpNotFound();
            }
            return View(unitItems);
        }

        // POST: UnitItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,NameUnit")] UnitItems unitItems)
        {
            if (ModelState.IsValid)
            {
                db.Entry(unitItems).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(unitItems);
        }

        // GET: UnitItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UnitItems unitItems = db.UnitItems.Find(id);
            if (unitItems == null)
            {
                return HttpNotFound();
            }
            return View(unitItems);
        }

        // POST: UnitItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UnitItems unitItems = db.UnitItems.Find(id);
            db.UnitItems.Remove(unitItems);
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
