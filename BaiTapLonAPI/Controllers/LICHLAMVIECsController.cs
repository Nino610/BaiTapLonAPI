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
    public class LICHLAMVIECsController : ApiController
    {
        private QLGVEntities db = new QLGVEntities();

        // GET: api/LICHLAMVIECs
        public IQueryable<LICHLAMVIEC> GetLICHLAMVIECs()
        {
            return db.LICHLAMVIECs;
        }

        // GET: api/LICHLAMVIECs/5
        [ResponseType(typeof(LICHLAMVIEC))]
        public IHttpActionResult GetLICHLAMVIEC(int id)
        {
            LICHLAMVIEC lICHLAMVIEC = db.LICHLAMVIECs.Find(id);
            if (lICHLAMVIEC == null)
            {
                return NotFound();
            }

            return Ok(lICHLAMVIEC);
        }

        // PUT: api/LICHLAMVIECs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLICHLAMVIEC(int id, LICHLAMVIEC lICHLAMVIEC)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lICHLAMVIEC.STT)
            {
                return BadRequest();
            }

            db.Entry(lICHLAMVIEC).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LICHLAMVIECExists(id))
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

        // POST: api/LICHLAMVIECs
        [ResponseType(typeof(LICHLAMVIEC))]
        public IHttpActionResult PostLICHLAMVIEC(LICHLAMVIEC lICHLAMVIEC)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LICHLAMVIECs.Add(lICHLAMVIEC);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (LICHLAMVIECExists(lICHLAMVIEC.STT))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = lICHLAMVIEC.STT }, lICHLAMVIEC);
        }

        // DELETE: api/LICHLAMVIECs/5
        [ResponseType(typeof(LICHLAMVIEC))]
        public IHttpActionResult DeleteLICHLAMVIEC(int id)
        {
            LICHLAMVIEC lICHLAMVIEC = db.LICHLAMVIECs.Find(id);
            if (lICHLAMVIEC == null)
            {
                return NotFound();
            }

            db.LICHLAMVIECs.Remove(lICHLAMVIEC);
            db.SaveChanges();

            return Ok(lICHLAMVIEC);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LICHLAMVIECExists(int id)
        {
            return db.LICHLAMVIECs.Count(e => e.STT == id) > 0;
        }
    }
}