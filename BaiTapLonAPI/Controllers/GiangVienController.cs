using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using BaiTapLonAPI.Models;
using System.Security.Cryptography.X509Certificates;
using System.Web.Mvc;

namespace BaiTapLonAPI.Controllers
{
    public class GiangVienController : ApiController
    {
        // GET: api/GiangVien
        [System.Web.Http.HttpGet]
        public List<GIANGVIEN> Get()
        {
            using(QLGVEntities db=new QLGVEntities())
			{
                return db.GIANGVIENs.ToList();
			}                

        }

        // GET: api/GiangVien/6
        [System.Web.Http.HttpGet]
        public IEnumerable<GIANGVIEN> Get(int id)
        {
            using (QLGVEntities db = new QLGVEntities())
			{
                var s = db.GIANGVIENs.Where(x => x.MaGV == id);
                if (s != null)
                {
                    return s.ToList();
                }
                else
                    return null;
            }                
        }
        // GET: api/GiangVien/name
        [System.Web.Http.HttpGet]
        public IEnumerable<GIANGVIEN> SearchName(string name)
        {
            using (QLGVEntities db = new QLGVEntities())
            {
                var s = db.GIANGVIENs.Where(x => x.TenGV.ToLower().IndexOf(name.ToLower()) >=0);
                if (s != null)
                {
                    return s.ToList();
                }
                else
                    return null;
            }
        }
        // GET: api/GiangVien/gioitinh
        [System.Web.Http.HttpGet]
        public List<GIANGVIEN> SearchGender(string gioitinh)
        {
            using (QLGVEntities db = new QLGVEntities())
            {
                var s = db.GIANGVIENs.Where(x => x.GioiTinh.ToLower().IndexOf(gioitinh.ToLower()) >= 0);
                if (s != null)
                {
                    return s.ToList();
                }
                else
                    return null;
            }
        }
        
        [System.Web.Http.HttpGet]
        public List<GIANGVIEN> SearchAddress(string address)
        {
            using (QLGVEntities db = new QLGVEntities())
            {
                var s = db.GIANGVIENs.Where(x => x.DiaChi.ToLower().IndexOf(address.ToLower()) >= 0);
                if (s != null)
                {
                    return s.ToList();
                }
                else
                    return null;
            }
        }
        [System.Web.Http.HttpGet]
        public HttpResponseMessage DemGV(int idBM)
		{
            using (QLGVEntities db = new QLGVEntities())
            {
                var gv = db.GIANGVIENs.Where(x => x.MaBM == idBM).Count();
                //var bm = db.BOMONTRUNGTAMs.Where(x => x.MaBm == idBM).Select(x => x.TenBM);
                //var bmm = from s in db.BOMONTRUNGTAMs
                //          where s.MaBm == idBM
                //          select new
                //          {
                //              s.TenBM
                //          };
             return Request.CreateResponse(HttpStatusCode.OK,"Bộ môn "+idBM +" có "+db.GIANGVIENs.Count()+" giảng viên");
                                  
            }
        }
        [System.Web.Http.HttpGet]
        public HttpResponseMessage groupby(int idBM)
		{
            using (QLGVEntities db = new QLGVEntities())
			{
                var groupedCustomerList = db.GIANGVIENs
                .GroupBy(u => u.MaBM)
                 .Select(grp => grp.ToList().Where(x=>x.MaBM == idBM))
                    .ToList();
                return Request.CreateResponse(HttpStatusCode.OK, groupedCustomerList);
            }
               

        }
        [System.Web.Http.HttpGet]
        public HttpResponseMessage joinTable()
		{
            using (QLGVEntities db = new QLGVEntities())
			{
                var rs = from gv in db.GIANGVIENs
                         join bm in db.BOMONTRUNGTAMs
                         on gv.MaBM equals bm.MaBm
                         select new
                         {
                             gv.TenGV,
                             gv.MaGV,
                             gv.ChucVu,
                             gv.DiaChi,
                             bm.MaBm,
                             bm.TenBM
                         };
                return Request.CreateResponse(HttpStatusCode.OK, rs.ToList());
            }

        }
        public HttpResponseMessage DemGVwhere(string address)
        {
            using (QLGVEntities db = new QLGVEntities())
            {
               var s = db.GIANGVIENs.Where(x => x.DiaChi.ToLower().IndexOf(address.ToLower()) >= 0).Count();

                return Request.CreateResponse(HttpStatusCode.OK, s);

            }
        }
        // POST: api/GiangVien
        [System.Web.Http.HttpPost]
        public async Task<HttpResponseMessage> Post([FromBody]GIANGVIEN GIANGVIEN)
        {
            try
			{
                using(QLGVEntities db=new QLGVEntities())
				{
                    db.GIANGVIENs.Add(GIANGVIEN);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.Created);
				}                    
			}
            catch(Exception ex)
			{
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }            
        }

        // PUT: api/GiangVien/5
        [System.Web.Http.HttpPut]
        public void Put(int id, [FromBody]GIANGVIEN GIANGVIEN)
        {
            using(QLGVEntities db=new QLGVEntities())
			{
                var s = db.GIANGVIENs.SingleOrDefault(x=> x.MaGV==id);
                if(s !=null)
				{
                    s.MaGV = GIANGVIEN.MaGV;
                    s.MaBM = GIANGVIEN.MaBM;
                    s.TenGV = GIANGVIEN.TenGV;
                    s.ChucVu = GIANGVIEN.ChucVu;
                    s.NgaySinh = GIANGVIEN.NgaySinh;
                    s.Email = GIANGVIEN.Email;
                    s.GioiTinh = GIANGVIEN.GioiTinh;
                    s.SDT = GIANGVIEN.SDT;
                    s.DiaChi = GIANGVIEN.DiaChi;
                    s.MonHocPhuTrach = GIANGVIEN.MonHocPhuTrach;
                    s.TrinhDoHocVan = GIANGVIEN.TrinhDoHocVan;
                    db.SaveChanges();
                }      
                else
				{
                   
				}                    
			}                
        }

        // DELETE: api/GiangVien/5
        [System.Web.Http.HttpDelete]
        public void Delete(int id)
        {
            using(QLGVEntities db=new QLGVEntities())
			{
                var s = db.GIANGVIENs.SingleOrDefault(x=> x.MaGV==id);
                db.GIANGVIENs.Remove(s);
                db.SaveChanges();
			}                
        }
    }
}
