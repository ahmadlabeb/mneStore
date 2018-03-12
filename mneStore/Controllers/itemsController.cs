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
    public class itemsController : Controller
    {
        private mneStoreContext db = new mneStoreContext();

        // GET: items
        public ActionResult Index(string index, string searchString)
        {
          
                ViewBag.NameSortParm = String.IsNullOrEmpty(index) ? "nameItem" : "";
                ViewBag.DateSortParm = index == "description" ? "barcode" : "description";
                var iteme = from s in db.items
                               select s;
                if (!String.IsNullOrEmpty(searchString))
                {
                    iteme = iteme.Where(s => s.nameItem.Contains(searchString)
                                           || s.barcode.Contains(searchString));
                }
                switch (index)
                {
                    case "nameItem":
                        iteme = iteme.OrderByDescending(s => s.nameItem);
                        break;
                    case "description":
                        iteme = iteme.OrderByDescending(s => s.description);
                        break;
                    case "barcode":
                        iteme = iteme.OrderByDescending(s => s.barcode);
                        break;
                    default:
                        iteme = iteme.OrderBy(s => s.nameItem);
                        break;
                }
            
            //var items = db.items.Include(i => i.bills);
            return View(iteme.ToList());
        }

        // GET: items/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            items items = db.items.Find(id);
            if (items == null)
            {
                return HttpNotFound();
            }
            return View(items);
        }

        // GET: items/Create
        public ActionResult Create()
        {
            ViewBag.KindsId = new SelectList(db.kinds, "id", "nameKind");
            ViewBag.UnitItemsId = new SelectList(db.UnitItems, "id", "NameUnit");
            ViewBag.brandId = new SelectList(db.brands, "id", "nameBrand");
            return View();
        }

        // POST: items/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(items items)
        {
            if (ModelState.IsValid)
            {
                db.items.Add(items);
                items.billsId= (int)Session["idBill"];
                db.SaveChanges();
                return RedirectToAction("Create","items");
            }
            ViewBag.KindsId = new SelectList(db.kinds, "id", "nameKind",items.KindsId);
            ViewBag.UnitItemsId = new SelectList(db.UnitItems, "id", "NameUnit", items.UnitItemsId);
            ViewBag.brandId = new SelectList(db.brands, "id", "nameBrand",items.brandId);
            return View(items);
        }

        // GET: items/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            items items = db.items.Find(id);
            if (items == null)
            {
                return HttpNotFound();
            }
            ViewBag.KindsId = new SelectList(db.kinds, "id", "nameKind", items.KindsId);
            ViewBag.UnitItemsId = new SelectList(db.UnitItems, "id", "NameUnit", items.UnitItemsId);
            ViewBag.brandId = new SelectList(db.brands, "id", "nameBrand", items.brandId);


            return View(items);
        }

        // POST: items/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( items items)
        {
            if (ModelState.IsValid)
            {
                db.Entry(items).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KindsId = new SelectList(db.kinds, "id", "nameKind", items.KindsId);
            ViewBag.UnitItemsId = new SelectList(db.UnitItems, "id", "NameUnit", items.UnitItemsId);
            ViewBag.brandId = new SelectList(db.brands, "id", "nameBrand", items.brandId);


            return View(items);
        }

        // GET: items/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            items items = db.items.Find(id);
            if (items == null)
            {
                return HttpNotFound();
            }
            return View(items);
        }

        // POST: items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            items items = db.items.Find(id);
            db.items.Remove(items);
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
