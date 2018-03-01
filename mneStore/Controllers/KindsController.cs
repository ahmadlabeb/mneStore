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
    public class KindsController : Controller
    {
        private mneStoreContext db = new mneStoreContext();

        // GET: Kinds
        public ActionResult Index()
        {
            return View(db.kinds.ToList());
        }

        // GET: Kinds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kinds kinds = db.kinds.Find(id);
            if (kinds == null)
            {
                return HttpNotFound();
            }
            return View(kinds);
        }

        // GET: Kinds/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kinds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nameKind")] Kinds kinds)
        {
            if (ModelState.IsValid)
            {
                db.kinds.Add(kinds);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kinds);
        }

        // GET: Kinds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kinds kinds = db.kinds.Find(id);
            if (kinds == null)
            {
                return HttpNotFound();
            }
            return View(kinds);
        }

        // POST: Kinds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nameKind")] Kinds kinds)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kinds).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kinds);
        }

        // GET: Kinds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kinds kinds = db.kinds.Find(id);
            if (kinds == null)
            {
                return HttpNotFound();
            }
            return View(kinds);
        }

        // POST: Kinds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kinds kinds = db.kinds.Find(id);
            db.kinds.Remove(kinds);
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
