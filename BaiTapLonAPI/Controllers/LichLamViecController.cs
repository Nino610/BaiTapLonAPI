using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BaiTapLonAPI.Models;
namespace BaiTapLonAPI.Controllers
{
    public class LichLamViecController : ApiController
    {
        // GET: api/LichLamViec
        public IEnumerable<LICHLAMVIEC> Get()
        {
            QLGVEntities db = new QLGVEntities();
            return db.LICHLAMVIECs;
        }

        // GET: api/LichLamViec/5
        public IEnumerable<LICHLAMVIEC> Get(int id)
        {
            using (QLGVEntities db = new QLGVEntities())
			{
                var s = db.LICHLAMVIECs.Where(x => x.MaGV == id);
                if (s != null)
                {
                    return s.ToList();
                }
                else
                    return null;
            }                
        }

        // POST: api/LichLamViec
        public void Post([FromBody]LICHLAMVIEC lICHLAMVIEC)
        {
            using (QLGVEntities db = new QLGVEntities())
			{
                db.LICHLAMVIECs.Add(lICHLAMVIEC);
                db.SaveChanges();
			}                
        }

        // PUT: api/LichLamViec/5
        public void Put(int id, [FromBody] LICHLAMVIEC lICHLAMVIEC)
        {
            
        }

        // DELETE: api/LichLamViec/5
        public void Delete(int id)
        {
        }
    }
}
