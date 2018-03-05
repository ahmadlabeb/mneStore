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
    public class DescriptionKindsController : Controller
    {
        private mneStoreContext db = new mneStoreContext();

        // GET: DescriptionKinds
        public ActionResult Index()
        {
            var descriptionKinds = db.DescriptionKinds.Include(d => d.items).Include(d => d.kinds);
            return View(descriptionKinds.ToList());
        }

        // GET: DescriptionKinds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DescriptionKinds descriptionKinds = db.DescriptionKinds.Find(id);
            if (descriptionKinds == null)
            {
                return HttpNotFound();
            }
            return View(descriptionKinds);
        }

        // GET: DescriptionKinds/Create
        public ActionResult Create()
        {
            ViewBag.itemsId = new SelectList(db.items, "id", "nameItem");
            ViewBag.KindsId = new SelectList(db.Kinds, "id", "nameKind");
            return View();
        }

        // POST: DescriptionKinds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,description,KindsId,itemsId")] DescriptionKinds descriptionKinds)
        {
            if (ModelState.IsValid)
            {
                db.DescriptionKinds.Add(descriptionKinds);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.itemsId = new SelectList(db.items, "id", "nameItem", descriptionKinds.itemsId);
            ViewBag.KindsId = new SelectList(db.Kinds, "id", "nameKind", descriptionKinds.KindsId);
            return View(descriptionKinds);
        }

        // GET: DescriptionKinds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DescriptionKinds descriptionKinds = db.DescriptionKinds.Find(id);
            if (descriptionKinds == null)
            {
                return HttpNotFound();
            }
            ViewBag.itemsId = new SelectList(db.items, "id", "nameItem", descriptionKinds.itemsId);
            ViewBag.KindsId = new SelectList(db.Kinds, "id", "nameKind", descriptionKinds.KindsId);
            return View(descriptionKinds);
        }

        // POST: DescriptionKinds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,description,KindsId,itemsId")] DescriptionKinds descriptionKinds)
        {
            if (ModelState.IsValid)
            {
                db.Entry(descriptionKinds).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.itemsId = new SelectList(db.items, "id", "nameItem", descriptionKinds.itemsId);
            ViewBag.KindsId = new SelectList(db.Kinds, "id", "nameKind", descriptionKinds.KindsId);
            return View(descriptionKinds);
        }

        // GET: DescriptionKinds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DescriptionKinds descriptionKinds = db.DescriptionKinds.Find(id);
            if (descriptionKinds == null)
            {
                return HttpNotFound();
            }
            return View(descriptionKinds);
        }

        // POST: DescriptionKinds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DescriptionKinds descriptionKinds = db.DescriptionKinds.Find(id);
            db.DescriptionKinds.Remove(descriptionKinds);
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
