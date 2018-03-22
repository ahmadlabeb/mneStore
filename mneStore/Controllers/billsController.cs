using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mneStore.Models;
using Newtonsoft.Json;

namespace mneStore.Controllers
{
    public class billsController : Controller
    {
        private mneStoreContext db = new mneStoreContext();

        // GET: bills
     
        public ActionResult Index()
        {
            return View(db.bills.ToList());
            //var listData = db.bills.ToList();
            //List<bills> bill = db.bills.ToList<bills>();
            //return Json(new { data = bill }, JsonRequestBehavior.AllowGet);
        }

        // GET: bills/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bills bills = db.bills.Find(id);
            //var bills = from a in db.bills
            //            join b in db.items
            //            on a.id equals b.billsId
            //            where a.id==id
            //            select a;
            if (bills == null)
            {
                return HttpNotFound();
            }
           
            return View(bills);
        }

        // GET: bills/Create
        public ActionResult Create()
        {
            //var listCurruncy = db.curruncies.ToList();
            ViewBag.currunciesId = new SelectList(db.curruncies, "id", "nameUnit");
            return View();
        }
       

        
        // POST: bills/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(bills bills)
        {
            if (ModelState.IsValid)
            {
                
                db.bills.Add(bills);
                db.SaveChanges();
                Session["idBill"] = bills.id;
                return RedirectToAction("Create","items");
            }
            ViewBag.currunciesId = new SelectList(db.curruncies, "id", "nameUnit",bills.currunciesId);
            return View(bills);
        }

        // GET: bills/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bills bills = db.bills.Find(id);
            if (bills == null)
            {
                return HttpNotFound();
            }
            ViewBag.currunciesId = new SelectList(db.curruncies, "id", "nameUnit", bills.currunciesId);
            return View(bills);
        }
        public JsonResult sendCurruncy(Curruncies curruncies)
        {
            if (ModelState.IsValid)
            {
                db.curruncies.Add(curruncies);
                db.SaveChanges();
            }
            return Json(curruncies);
        }
        public JsonResult getCurruncy()
        {
            var result = from crr in db.curruncies select crr.nameUnit;
            return Json(result.ToList(),JsonRequestBehavior.AllowGet);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(bills bills)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bills).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.currunciesId = new SelectList(db.curruncies, "id", "nameUnit", bills.currunciesId);
            return View(bills);
        }

        // GET: bills/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bills bills = db.bills.Find(id);
            if (bills == null)
            {
                return HttpNotFound();
            }
            return View(bills);
        }

        // POST: bills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            bills bills = db.bills.Find(id);
            db.bills.Remove(bills);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetData()
        {
            List<bills> list = db.bills.ToList<bills>();
            var jsonlist = JsonConvert.SerializeObject(list, Formatting.None, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });

            return Json(new { data = jsonlist }, JsonRequestBehavior.AllowGet);
            //return Content(jsonlist, "application/json");
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
