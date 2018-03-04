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
    public class CurrunciesController : ApiController
    {
        private storeContext db = new storeContext();

        // GET: api/Curruncies
        public IQueryable<Curruncies> GetCurruncies()
        {
            return db.Curruncies;
        }

        // GET: api/Curruncies/5
        [ResponseType(typeof(Curruncies))]
        public IHttpActionResult GetCurruncies(int id)
        {
            Curruncies curruncies = db.Curruncies.Find(id);
            if (curruncies == null)
            {
                return NotFound();
            }

            return Ok(curruncies);
        }

        // PUT: api/Curruncies/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCurruncies(int id, Curruncies curruncies)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != curruncies.id)
            {
                return BadRequest();
            }

            db.Entry(curruncies).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CurrunciesExists(id))
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

        // POST: api/Curruncies
        [ResponseType(typeof(Curruncies))]
        public IHttpActionResult PostCurruncies(Curruncies curruncies)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Curruncies.Add(curruncies);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = curruncies.id }, curruncies);
        }

        // DELETE: api/Curruncies/5
        [ResponseType(typeof(Curruncies))]
        public IHttpActionResult DeleteCurruncies(int id)
        {
            Curruncies curruncies = db.Curruncies.Find(id);
            if (curruncies == null)
            {
                return NotFound();
            }

            db.Curruncies.Remove(curruncies);
            db.SaveChanges();

            return Ok(curruncies);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CurrunciesExists(int id)
        {
            return db.Curruncies.Count(e => e.id == id) > 0;
        }
    }
}