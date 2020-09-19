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
    public class BOMONTRUNGTAMsController : ApiController
    {
        private QLGVEntities db = new QLGVEntities();

        // GET: api/BOMONTRUNGTAMs
        public IQueryable<BOMONTRUNGTAM> GetBOMONTRUNGTAMs()
        {
            return db.BOMONTRUNGTAMs;
        }

        // GET: api/BOMONTRUNGTAMs/5
        [ResponseType(typeof(BOMONTRUNGTAM))]
        public IHttpActionResult GetBOMONTRUNGTAM(int id)
        {
            BOMONTRUNGTAM bOMONTRUNGTAM = db.BOMONTRUNGTAMs.Find(id);
            if (bOMONTRUNGTAM == null)
            {
                return NotFound();
            }

            return Ok(bOMONTRUNGTAM);
        }

        // PUT: api/BOMONTRUNGTAMs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBOMONTRUNGTAM(int id, BOMONTRUNGTAM bOMONTRUNGTAM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bOMONTRUNGTAM.MaBm)
            {
                return BadRequest();
            }

            db.Entry(bOMONTRUNGTAM).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BOMONTRUNGTAMExists(id))
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

        // POST: api/BOMONTRUNGTAMs
        [ResponseType(typeof(BOMONTRUNGTAM))]
        public IHttpActionResult PostBOMONTRUNGTAM(BOMONTRUNGTAM bOMONTRUNGTAM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BOMONTRUNGTAMs.Add(bOMONTRUNGTAM);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (BOMONTRUNGTAMExists(bOMONTRUNGTAM.MaBm))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = bOMONTRUNGTAM.MaBm }, bOMONTRUNGTAM);
        }

        // DELETE: api/BOMONTRUNGTAMs/5
        [ResponseType(typeof(BOMONTRUNGTAM))]
        public IHttpActionResult DeleteBOMONTRUNGTAM(int id)
        {
            BOMONTRUNGTAM bOMONTRUNGTAM = db.BOMONTRUNGTAMs.Find(id);
            if (bOMONTRUNGTAM == null)
            {
                return NotFound();
            }

            db.BOMONTRUNGTAMs.Remove(bOMONTRUNGTAM);
            db.SaveChanges();

            return Ok(bOMONTRUNGTAM);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BOMONTRUNGTAMExists(int id)
        {
            return db.BOMONTRUNGTAMs.Count(e => e.MaBm == id) > 0;
        }
    }
}