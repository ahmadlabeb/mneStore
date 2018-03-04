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
    public class itemsController : ApiController
    {
        private storeContext db = new storeContext();

        // GET: api/items
        public IQueryable<items> Getitems()
        {
            return db.items;
        }

        // GET: api/items/5
        [ResponseType(typeof(items))]
        public IHttpActionResult Getitems(int id)
        {
            items items = db.items.Find(id);
            if (items == null)
            {
                return NotFound();
            }

            return Ok(items);
        }

        // PUT: api/items/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putitems(int id, items items)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != items.id)
            {
                return BadRequest();
            }

            db.Entry(items).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!itemsExists(id))
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

        // POST: api/items
        [ResponseType(typeof(items))]
        public IHttpActionResult Postitems(items items)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.items.Add(items);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = items.id }, items);
        }

        // DELETE: api/items/5
        [ResponseType(typeof(items))]
        public IHttpActionResult Deleteitems(int id)
        {
            items items = db.items.Find(id);
            if (items == null)
            {
                return NotFound();
            }

            db.items.Remove(items);
            db.SaveChanges();

            return Ok(items);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool itemsExists(int id)
        {
            return db.items.Count(e => e.id == id) > 0;
        }
    }
}