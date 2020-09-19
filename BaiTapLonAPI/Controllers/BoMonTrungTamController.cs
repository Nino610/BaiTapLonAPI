using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using System.Web.Http;
using BaiTapLonAPI.Models;
using System.Security.Cryptography.X509Certificates;

namespace BaiTapLonAPI.Controllers
{
    public class BoMonTrungTamController : ApiController
    {
        // GET: api/BoMonTrungTam
        public IEnumerable<BOMONTRUNGTAM> Get()
        {
            QLGVEntities db = new QLGVEntities();
            return db.BOMONTRUNGTAMs;
        }

        // GET: api/BoMonTrungTam/5
        public IEnumerable<BOMONTRUNGTAM> Get(int id)
        {
            using (QLGVEntities db = new QLGVEntities())
			{
                var s = db.BOMONTRUNGTAMs.Where(x => x.MaBm == id);
                if (s != null)
                {
                    return s.ToList();
                }
                else
                    return null;
            }                
                
        }

        // POST: api/BoMonTrungTam
        public void Post([FromBody]BOMONTRUNGTAM bOMONTRUNGTAM)
        {
            using(QLGVEntities db=new QLGVEntities())
			{
                db.BOMONTRUNGTAMs.Add(bOMONTRUNGTAM);
                db.SaveChanges();
			}                
        }

        // PUT: api/BoMonTrungTam/5
        public void Put(int id, [FromBody]BOMONTRUNGTAM bOMONTRUNGTAM)
        {
            using(QLGVEntities db=new QLGVEntities())
			{
                var s = db.BOMONTRUNGTAMs.SingleOrDefault(x => x.MaBm == id);
                if (s!=null)
				{
                    s.MaBm = bOMONTRUNGTAM.MaBm;
                    s.TenBM = bOMONTRUNGTAM.TenBM;
                    s.DiaChi = bOMONTRUNGTAM.DiaChi;
                    s.Fax = bOMONTRUNGTAM.Fax;
                    s.SDT = bOMONTRUNGTAM.SDT;
                    s.Email = bOMONTRUNGTAM.Email;
                    db.SaveChanges();
				}        
                else
				{
                    
				}                    
			}                
        }

        // DELETE: api/BoMonTrungTam/5
        public void Delete(int id)
        {
            using (QLGVEntities db=new QLGVEntities())
			{
                var s = db.BOMONTRUNGTAMs.SingleOrDefault(x => x.MaBm==id);
                if(s!=null)
				{
                    db.BOMONTRUNGTAMs.Remove(s);
                    db.SaveChanges();
				}                    
			}                
        }
    }
}
