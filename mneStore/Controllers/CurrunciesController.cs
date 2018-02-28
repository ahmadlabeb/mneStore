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
    public class CurrunciesController : Controller
    {
        private mneStoreContext db = new mneStoreContext();

        // GET: Curruncies
        public ActionResult Index()
        {
            return View(db.curruncies.ToList());
        }

        // GET: Curruncies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curruncies curruncies = db.curruncies.Find(id);
            if (curruncies == null)
            {
                return HttpNotFound();
            }
            return View(curruncies);
        }

        // GET: Curruncies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Curruncies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nameUnit")] Curruncies curruncies)
        {
            if (ModelState.IsValid)
            {
                db.curruncies.Add(curruncies);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(curruncies);
        }

        // GET: Curruncies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curruncies curruncies = db.curruncies.Find(id);
            if (curruncies == null)
            {
                return HttpNotFound();
            }
            return View(curruncies);
        }

        // POST: Curruncies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nameUnit")] Curruncies curruncies)
        {
            if (ModelState.IsValid)
            {
                db.Entry(curruncies).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(curruncies);
        }

        // GET: Curruncies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curruncies curruncies = db.curruncies.Find(id);
            if (curruncies == null)
            {
                return HttpNotFound();
            }
            return View(curruncies);
        }

        // POST: Curruncies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Curruncies curruncies = db.curruncies.Find(id);
            db.curruncies.Remove(curruncies);
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
