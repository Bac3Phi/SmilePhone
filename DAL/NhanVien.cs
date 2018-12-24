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
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Diagnostics;

    public partial class NhanVien
    {
        private static NhanVien instance;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhanVien()
        {
            this.PhieuBanHangs = new HashSet<PhieuBanHang>();
            this.PhieuBaoHangs = new HashSet<PhieuBaoHang>();
            this.PhieuChis = new HashSet<PhieuChi>();
            this.PhieuDatHangs = new HashSet<PhieuDatHang>();
            this.PhieuNhaps = new HashSet<PhieuNhap>();
        }

        public static NhanVien Instance
        {
            get
            {
                if (instance == null)
                    instance = new NhanVien();
                return instance;
            }
        }

        public string MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string MaPhanQuyen { get; set; }

        public virtual PhanQuyen PhanQuyen { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuBanHang> PhieuBanHangs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuBaoHang> PhieuBaoHangs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuChi> PhieuChis { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuDatHang> PhieuDatHangs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuNhap> PhieuNhaps { get; set; }

        public void DeleteNV(String id)
        {
            using (CellphoneComponentEntities db = new CellphoneComponentEntities())
            {
                NhanVien nv = (from item in db.NhanViens
                                where item.MaNhanVien == id
                                select item).SingleOrDefault();
                db.NhanViens.Remove(nv);
                db.SaveChanges();
            }
        }

        public void InsertNV(NhanVien obj, String str)
        {
            using (CellphoneComponentEntities db = new CellphoneComponentEntities())
            {
                var result = db.Database
                    .SqlQuery<String>("select MaPhanQuyen from dbo.PhanQuyen where TenPhanQuyen = N'" + str + "'")
                    .FirstOrDefault();
                obj.MaPhanQuyen = result;

                db.NhanViens.Add(obj);
                db.SaveChanges();
            }
        }

        public void UpdateNV(NhanVien obj, String str)
        {
            using (CellphoneComponentEntities db = new CellphoneComponentEntities())
            {
                var result = db.Database
                    .SqlQuery<String>("select MaPhanQuyen from dbo.PhanQuyen where TenPhanQuyen = N'" + str + "'")
                    .FirstOrDefault();
                obj.MaPhanQuyen = result;

                db.NhanViens.Attach(obj);
                db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public List<dynamic> showNV()
        {
            using (CellphoneComponentEntities db = new CellphoneComponentEntities())
            {
                var result = (from item in db.NhanViens
                                join perm in db.PhanQuyens on item.MaPhanQuyen equals perm.MaPhanQuyen
                                select new
                                {
                                    MaNhanVien = item.MaNhanVien,
                                    TenNhanVien = item.TenNhanVien,
                                    UserName = item.UserName,
                                    Password = item.Password,
                                    TenPhanQuyen = perm.TenPhanQuyen
                                }).ToList<dynamic>();
                return result;
            }
        }

        public String autoID()
        {
            using (CellphoneComponentEntities db = new CellphoneComponentEntities())
            {
                var maxID = db.Database
                    .SqlQuery<String>("select MaNhanVien from dbo.NhanVien where MaNhanVien = (Select Max(MaNhanVien) from dbo.NhanVien)")
                    .FirstOrDefault();

                return maxID;
            }
        }

        public List<dynamic> searchNV(string str)
        {
            using (CellphoneComponentEntities db = new CellphoneComponentEntities())
            {
                var result = (from item in db.NhanViens
                              join perm in db.PhanQuyens
                              on item.MaPhanQuyen equals perm.MaPhanQuyen
                              where item.MaNhanVien.Contains(str.ToUpper())
                              || item.TenNhanVien.Contains(str)
                              || item.UserName.Contains(str)
                              || item.Password.Contains(str)
                              || perm.TenPhanQuyen.Contains(str)
                              select new
                              {
                                  MaNhanVien = item.MaNhanVien,
                                  TenNhanVien = item.TenNhanVien,
                                  UserName = item.UserName,
                                  Password = item.Password,
                                  TenPhanQuyen = perm.TenPhanQuyen
                              }).ToList<dynamic>();
                return result;
            }
        }
    }
}
