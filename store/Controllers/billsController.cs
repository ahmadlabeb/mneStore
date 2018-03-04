using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using store.Models;

namespace store.Controllers
{
    public class billsController : ApiController
    {
        private storeContext db = new storeContext();

        // GET: api/bills
        public IQueryable<bills> Getbills()
        {
            return db.bills;
        }

        // GET: api/bills/5
        [ResponseType(typeof(bills))]
        public IHttpActionResult Getbills(int id)
        {
            bills bills = db.bills.Find(id);
            if (bills == null)
            {
                return NotFound();
            }

            return Ok(bills);
        }

        // PUT: api/bills/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putbills(int id, bills bills)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bills.id)
            {
                return BadRequest();
            }

            db.Entry(bills).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!billsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/bills
        [ResponseType(typeof(bills))]
        public IHttpActionResult Postbills(bills bills)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.bills.Add(bills);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = bills.id }, bills);
        }

        // DELETE: api/bills/5
        [ResponseType(typeof(bills))]
        public IHttpActionResult Deletebills(int id)
        {
            bills bills = db.bills.Find(id);
            if (bills == null)
            {
                return NotFound();
            }

            db.bills.Remove(bills);
            db.SaveChanges();

            return Ok(bills);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool billsExists(int id)
        {
            return db.bills.Count(e => e.id == id) > 0;
        }
    }
}