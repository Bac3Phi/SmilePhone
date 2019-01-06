//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using DTO;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Core.Objects;
    using System.Globalization;
    using System.Linq;

    public partial class PhieuNhap
    {
        private static PhieuNhap instance;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhieuNhap()
        {
            this.ChiTietPhieuNhaps = new HashSet<ChiTietPhieuNhap>();
            this.PhieuChis = new HashSet<PhieuChi>();
            this.ChiTietChis = new HashSet<ChiTietChi>();
        }

        public void delete(String id)
        {
            using (CellphoneComponentEntities db = new CellphoneComponentEntities())
            {
                PhieuNhap phieunhap = (from item in db.PhieuNhaps
                                       where item.MaPhieuNhap == id
                                       select item).SingleOrDefault();
                db.PhieuNhaps.Remove(phieunhap);
                db.SaveChanges();
            }
        }

        public void insert(DTO_PhieuNhap obj)
        {
            using (CellphoneComponentEntities db = new CellphoneComponentEntities())
            {
                var resultMaNhanVien = db.Database
                    .SqlQuery<String>("select MaNhanVien from dbo.NhanVien where TenNhanVien = N'" + obj.TenNhanVien + "'")
                    .FirstOrDefault();
                var resultMaNhaCungCap = db.Database
                    .SqlQuery<String>("select MaNhaCungCap from dbo.NhaCungCap where TenNhaCungCap = N'" + obj.TenNhaCungCap + "'")
                    .FirstOrDefault();
                PhieuNhap phieuNhap = new PhieuNhap();
                phieuNhap.MaPhieuNhap = obj.MaPhieuNhap;
                phieuNhap.MaNhaCungCap = resultMaNhaCungCap;
                phieuNhap.MaNhanVien = resultMaNhanVien;
                phieuNhap.NgayChinhSua = obj.NgayChinhSua;
                phieuNhap.NgayNhap = obj.NgayNhap;
                phieuNhap.TongTien = obj.TongTien;
                phieuNhap.GhiChu = obj.GhiChu;

                db.PhieuNhaps.Add(phieuNhap);
                db.SaveChanges();

            }
        }

        public void update(DTO_PhieuNhap obj)
        {
            using (CellphoneComponentEntities db = new CellphoneComponentEntities())
            {
                var resultMaNhanVien = db.Database
                    .SqlQuery<String>("select MaNhanVien from dbo.NhanVien where TenNhanVien = N'" + obj.TenNhanVien + "'")
                    .FirstOrDefault();
                var resultMaNhaCungCap = db.Database
                    .SqlQuery<String>("select MaNhaCungCap from dbo.NhaCungCap where TenNhaCungCap = N'" + obj.TenNhaCungCap + "'")
                    .FirstOrDefault();
                PhieuNhap phieuNhap = new PhieuNhap();
                phieuNhap.MaPhieuNhap = obj.MaPhieuNhap;
                phieuNhap.MaNhaCungCap = resultMaNhaCungCap;
                phieuNhap.MaNhanVien = resultMaNhanVien;
                phieuNhap.NgayChinhSua = obj.NgayChinhSua;
                phieuNhap.NgayNhap = obj.NgayNhap;
                phieuNhap.TongTien = obj.TongTien;
                phieuNhap.GhiChu = obj.GhiChu;

                db.PhieuNhaps.Attach(phieuNhap);
                db.Entry(phieuNhap).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }


        public List<DTO_PhieuNhap> show()
        {
            using (CellphoneComponentEntities db = new CellphoneComponentEntities())
            {
                var result = (from pn in db.PhieuNhaps
                              join nv in db.NhanViens on pn.MaNhanVien equals nv.MaNhanVien
                              join ncc in db.NhaCungCaps on pn.MaNhaCungCap equals ncc.MaNhaCungCap
                              select new DTO_PhieuNhap
                              {
                                  MaPhieuNhap = pn.MaPhieuNhap,
                                  NgayNhap = pn.NgayNhap,
                                  NgayChinhSua = pn.NgayChinhSua,
                                  TenNhanVien = nv.TenNhanVien,
                                  TenNhaCungCap = ncc.TenNhaCungCap,
                                  TongTien = pn.TongTien,
                                  GhiChu = pn.GhiChu
                              }).ToList<DTO_PhieuNhap>();
                return result;
            }
        }
        public List<DTO_PhieuNhap> search(string str)
        {
            using (CellphoneComponentEntities db = new CellphoneComponentEntities())
            {
                var result = (from item in db.PhieuNhaps
                              join nv in db.NhanViens
                              on item.MaNhanVien equals nv.MaNhanVien
                              join ncc in db.NhaCungCaps
                              on item.MaNhaCungCap equals ncc.MaNhaCungCap
                              where item.MaPhieuNhap.Contains(str.ToUpper())
                              || nv.TenNhanVien.Contains(str)
                              || item.TongTien.ToString().Contains(str)
                              || ncc.TenNhaCungCap.Contains(str)
                              || item.GhiChu.Contains(str)
                              || item.MaPhieuNhap.Contains(str)
                              select new DTO_PhieuNhap
                              {
                                  MaPhieuNhap = item.MaPhieuNhap,
                                  NgayNhap = item.NgayNhap,
                                  NgayChinhSua = item.NgayChinhSua,
                                  TenNhanVien = nv.TenNhanVien,
                                  TenNhaCungCap = ncc.TenNhaCungCap,
                                  TongTien = item.TongTien,
                                  GhiChu = item.GhiChu
                              }).ToList<DTO_PhieuNhap>();
                return result;
            }
        }
        public List<DTO_PhieuNhap> searchDate(DateTime from, DateTime to)
        {
            using (CellphoneComponentEntities db = new CellphoneComponentEntities())
            {
                var result = (from item in db.PhieuNhaps
                              join nv in db.NhanViens
                              on item.MaNhanVien equals nv.MaNhanVien
                              join ncc in db.NhaCungCaps
                              on item.MaNhaCungCap equals ncc.MaNhaCungCap
                              select new DTO_PhieuNhap
                              {
                                  MaPhieuNhap = item.MaPhieuNhap,
                                  NgayNhap = item.NgayNhap,
                                  NgayChinhSua = item.NgayChinhSua,
                                  TenNhanVien = nv.UserName,
                                  TenNhaCungCap = ncc.TenNhaCungCap,
                                  TongTien = item.TongTien,
                                  GhiChu = item.GhiChu
                              })
                              .Where(res => (from <= res.NgayNhap && res.NgayNhap <= to)
                              || (from <= res.NgayChinhSua && res.NgayChinhSua <= to))
                              .ToList<DTO_PhieuNhap>();
                return result;
            }
        }
        public static PhieuNhap Instance
        {
            get
            {
                if (instance == null)
                    instance = new PhieuNhap();
                return instance;
            }
        }
        public string MaPhieuNhap { get; set; }
        public Nullable<System.DateTime> NgayNhap { get; set; }
        public string MaNhanVien { get; set; }
        public string MaNhaCungCap { get; set; }
        public Nullable<decimal> TongTien { get; set; }
        public string GhiChu { get; set; }
        public Nullable<System.DateTime> NgayChinhSua { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; }
        public virtual NhaCungCap NhaCungCap { get; set; }
        public virtual NhanVien NhanVien { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuChi> PhieuChis { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietChi> ChiTietChis { get; set; }
    }
}
