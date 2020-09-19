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
using BaiTapLonAPI.Models;

namespace BaiTapLonAPI.Controllers
{
    public class GIANGVIENsController : ApiController
    {
        private QLGVEntities db = new QLGVEntities();

        // GET: api/GIANGVIENs
        public IQueryable<GIANGVIEN> GetGIANGVIENs()
        {
            return db.GIANGVIENs;
        }

        // GET: api/GIANGVIENs/5
        [ResponseType(typeof(GIANGVIEN))]
        public IHttpActionResult GetGIANGVIEN(int id)
        {
            GIANGVIEN gIANGVIEN = db.GIANGVIENs.Find(id);
            if (gIANGVIEN == null)
            {
                return NotFound();
            }

            return Ok(gIANGVIEN);
        }
      
        // PUT: api/GIANGVIENs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGIANGVIEN(int id, GIANGVIEN gIANGVIEN)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gIANGVIEN.MaGV)
            {
                return BadRequest();
            }

            db.Entry(gIANGVIEN).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GIANGVIENExists(id))
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

        // POST: api/GIANGVIENs
        [ResponseType(typeof(GIANGVIEN))]
        public IHttpActionResult PostGIANGVIEN(GIANGVIEN gIANGVIEN)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GIANGVIENs.Add(gIANGVIEN);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (GIANGVIENExists(gIANGVIEN.MaGV))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = gIANGVIEN.MaGV }, gIANGVIEN);
        }

        // DELETE: api/GIANGVIENs/5
        [ResponseType(typeof(GIANGVIEN))]
        public IHttpActionResult DeleteGIANGVIEN(int id)
        {
            GIANGVIEN gIANGVIEN = db.GIANGVIENs.Find(id);
            if (gIANGVIEN == null)
            {
                return NotFound();
            }

            db.GIANGVIENs.Remove(gIANGVIEN);
            db.SaveChanges();

            return Ok(gIANGVIEN);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GIANGVIENExists(int id)
        {
            return db.GIANGVIENs.Count(e => e.MaGV == id) > 0;
        }
    }
}