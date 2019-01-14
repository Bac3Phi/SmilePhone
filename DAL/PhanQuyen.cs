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
    using System.Collections.Generic;
    using System.Linq;
    using DTO;
    public partial class PhanQuyen
    {
        private static PhanQuyen instance;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhanQuyen()
        {
            this.NhanViens = new HashSet<NhanVien>();
        }

        public string getTenPhanQuyenByID(string manv)
        {
            using (CellphoneComponentEntities db = new CellphoneComponentEntities())
            {
                var result = (from item in db.PhanQuyens
                              join nv in db.NhanViens on item.MaPhanQuyen equals nv.MaPhanQuyen
                              where nv.MaNhanVien.Equals(manv)
                              select new DTO_PhanQuyen
                              {
                                  TenPhanQuyen = item.TenPhanQuyen
                              }).ToList<DTO_PhanQuyen>();

                if (result.Count > 0)
                    return result.First().TenPhanQuyen;
                else return "";
            }
        }

        public static PhanQuyen Instance
        {
            get
            {
                if (instance == null)
                    instance = new PhanQuyen();
                return instance;
            }
        }

        public string MaPhanQuyen { get; set; }
        public string TenPhanQuyen { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NhanVien> NhanViens { get; set; }

        public List<PhanQuyen> showPQ()
        {
            using (CellphoneComponentEntities db = new CellphoneComponentEntities())
            {
                return db.PhanQuyens.ToList();
            }
        }
    }
}
