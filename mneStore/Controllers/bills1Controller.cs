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
using mneStore.Models;

namespace mneStore.Controllers
{
    public class bills1Controller : ApiController
    {
        private mneStoreContext db = new mneStoreContext();

        // GET: api/bills1
        public IQueryable<bills> Get()
        {
            return db.bills;
        }

        // GET: api/bills1/5
        [ResponseType(typeof(bills))]
        public IHttpActionResult Get(int id)
        {
            bills bills = db.bills.Find(id);
            if (bills == null)
            {
                return NotFound();
            }

            return Ok(bills);
        }

        // PUT: api/bills1/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(int id, bills bills)
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

        // POST: api/bills1
        [ResponseType(typeof(bills))]
        public IHttpActionResult Post(bills bills)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.bills.Add(bills);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = bills.id }, bills);
        }

        // DELETE: api/bills1/5
        [ResponseType(typeof(bills))]
        public IHttpActionResult Delete(int id)
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