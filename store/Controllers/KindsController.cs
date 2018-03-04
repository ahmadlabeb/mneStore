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
    public class KindsController : ApiController
    {
        private storeContext db = new storeContext();

        // GET: api/Kinds
        public IQueryable<Kinds> GetKinds()
        {
            return db.Kinds;
        }

        // GET: api/Kinds/5
        [ResponseType(typeof(Kinds))]
        public IHttpActionResult GetKinds(int id)
        {
            Kinds kinds = db.Kinds.Find(id);
            if (kinds == null)
            {
                return NotFound();
            }

            return Ok(kinds);
        }

        // PUT: api/Kinds/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKinds(int id, Kinds kinds)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != kinds.id)
            {
                return BadRequest();
            }

            db.Entry(kinds).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KindsExists(id))
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

        // POST: api/Kinds
        [ResponseType(typeof(Kinds))]
        public IHttpActionResult PostKinds(Kinds kinds)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Kinds.Add(kinds);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = kinds.id }, kinds);
        }

        // DELETE: api/Kinds/5
        [ResponseType(typeof(Kinds))]
        public IHttpActionResult DeleteKinds(int id)
        {
            Kinds kinds = db.Kinds.Find(id);
            if (kinds == null)
            {
                return NotFound();
            }

            db.Kinds.Remove(kinds);
            db.SaveChanges();

            return Ok(kinds);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KindsExists(int id)
        {
            return db.Kinds.Count(e => e.id == id) > 0;
        }
    }
}