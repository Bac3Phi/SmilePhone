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
    using DTO;
    using System.Linq;
    public partial class PhieuBaoHanh
    {
        private static PhieuBaoHanh instance;
        public PhieuBaoHanh()
        {
        }

        public void delete(String id)
        {
            using (CellphoneComponentEntities db = new CellphoneComponentEntities())
            {
                PhieuBaoHanh pbh = (from item in db.PhieuBaoHanhs
                                       where item.MaPhieuBaoHanh == id
                                       select item).SingleOrDefault();
                db.PhieuBaoHanhs.Remove(pbh);
                db.SaveChanges();
            }
        }

        public void insert(DTO_PhieuBaoHanh obj)
        {
            using (CellphoneComponentEntities db = new CellphoneComponentEntities())
            {
                var resultMaNhanVien = db.Database
                    .SqlQuery<String>("select MaNhanVien from dbo.NhanVien where TenNhanVien = N'" + obj.TenNhanVien + "'")
                    .FirstOrDefault();
                var resultMaHangHoa = db.Database
                    .SqlQuery<String>("select MaHangHoa from dbo.HangHoa where TenHangHoa = N'" + obj.TenHangHoa + "'")
                    .FirstOrDefault();
                PhieuBaoHanh item = new PhieuBaoHanh();
                item.MaPhieuBaoHanh = obj.MaPhieuBaoHanh;
                item.NgayLap = obj.NgayLap;
                item.NgayGiao = obj.NgayGiao;
                item.MaNhanVien = resultMaNhanVien;
                item.TenKhachHang = obj.TenKhachHang;
                item.SoDienThoai = obj.SoDienThoai;
                item.TongTien = obj.TongTien;
                item.GhiChu = obj.GhiChu;
                item.DaGiao = obj.DaGiao;
                item.NgayChinhSua = obj.NgayChinhSua;
                item.MaHangHoa = resultMaHangHoa;

                db.PhieuBaoHanhs.Add(item);
                db.SaveChanges();

            }
        }

        public void update(DTO_PhieuBaoHanh obj)
        {
            using (CellphoneComponentEntities db = new CellphoneComponentEntities())
            {
                var resultMaNhanVien = db.Database
                    .SqlQuery<String>("select MaNhanVien from dbo.NhanVien where TenNhanVien = N'" + obj.TenNhanVien + "'")
                    .FirstOrDefault();
                var resultMaHangHoa = db.Database
                    .SqlQuery<String>("select MaHangHoa from dbo.HangHoa where TenHangHoa = N'" + obj.TenHangHoa + "'")
                    .FirstOrDefault();
                PhieuBaoHanh item = new PhieuBaoHanh();
                item.MaPhieuBaoHanh = obj.MaPhieuBaoHanh;
                item.NgayLap = obj.NgayLap;
                item.NgayGiao = obj.NgayGiao;
                item.MaNhanVien = resultMaNhanVien;
                item.TenKhachHang = obj.TenKhachHang;
                item.SoDienThoai = obj.SoDienThoai;
                item.TongTien = obj.TongTien;
                item.GhiChu = obj.GhiChu;
                item.DaGiao = obj.DaGiao;
                item.NgayChinhSua = obj.NgayChinhSua;
                item.MaHangHoa = resultMaHangHoa;

                db.PhieuBaoHanhs.Attach(item);
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }


        public List<DTO_PhieuBaoHanh> show()
        {
            using (CellphoneComponentEntities db = new CellphoneComponentEntities())
            {
                var result = (from item in db.PhieuBaoHanhs
                              join nv in db.NhanViens on item.MaNhanVien equals nv.MaNhanVien
                              join hh in db.HangHoas on item.MaHangHoa equals hh.MaHangHoa
                              select new DTO_PhieuBaoHanh
                              {
                                  MaPhieuBaoHanh = item.MaPhieuBaoHanh,
                                  NgayLap = item.NgayLap,
                                  NgayGiao = item.NgayGiao,
                                  TenHangHoa = hh.TenHangHoa,
                                  TenNhanVien = nv.TenNhanVien,
                                  TenKhachHang = item.TenKhachHang,
                                  SoDienThoai = item.SoDienThoai,
                                  TongTien = item.TongTien,
                                  GhiChu = item.GhiChu,
                                  DaGiao = item.DaGiao,
                                  NgayChinhSua = item.NgayChinhSua
                              }).ToList<DTO_PhieuBaoHanh>();
                return result;
            }
        }
        public List<DTO_PhieuBaoHanh> search(String str, bool isMergeCondition, bool daGiao)
        {
            using (CellphoneComponentEntities db = new CellphoneComponentEntities())
            {
                var result = new List<DTO_PhieuBaoHanh>();
                if (!isMergeCondition)
                {
                    result = (from item in db.PhieuBaoHanhs
                                  join nv in db.NhanViens on item.MaNhanVien equals nv.MaNhanVien
                                  join hh in db.HangHoas on item.MaHangHoa equals hh.MaHangHoa
                                  where item.MaPhieuBaoHanh.Contains(str.ToUpper())
                                  || nv.TenNhanVien.Contains(str)
                                  || item.TongTien.ToString().Contains(str)
                                  || hh.TenHangHoa.Contains(str)
                                  || item.GhiChu.Contains(str)
                                  || item.TenKhachHang.Contains(str)
                                  || item.SoDienThoai.Contains(str)
                                  || item.MaPhieuBaoHanh.Contains(str)
                                  select new DTO_PhieuBaoHanh
                                  {
                                      MaPhieuBaoHanh = item.MaPhieuBaoHanh,
                                      NgayLap = item.NgayLap,
                                      NgayGiao = item.NgayGiao,
                                      TenHangHoa = hh.TenHangHoa,
                                      TenNhanVien = nv.TenNhanVien,
                                      TenKhachHang = item.TenKhachHang,
                                      SoDienThoai = item.SoDienThoai,
                                      TongTien = item.TongTien,
                                      GhiChu = item.GhiChu,
                                      DaGiao = item.DaGiao,
                                      NgayChinhSua = item.NgayChinhSua
                                  }).ToList<DTO_PhieuBaoHanh>();
                }
                else
                {
                     result = (from item in db.PhieuBaoHanhs
                                  join nv in db.NhanViens on item.MaNhanVien equals nv.MaNhanVien
                                  join hh in db.HangHoas on item.MaHangHoa equals hh.MaHangHoa
                                  where item.DaGiao.Value == daGiao
                                  select new DTO_PhieuBaoHanh
                                  {
                                      MaPhieuBaoHanh = item.MaPhieuBaoHanh,
                                      NgayLap = item.NgayLap,
                                      NgayGiao = item.NgayGiao,
                                      TenHangHoa = hh.TenHangHoa,
                                      TenNhanVien = nv.TenNhanVien,
                                      TenKhachHang = item.TenKhachHang,
                                      SoDienThoai = item.SoDienThoai,
                                      TongTien = item.TongTien,
                                      GhiChu = item.GhiChu,
                                      DaGiao = item.DaGiao,
                                      NgayChinhSua = item.NgayChinhSua
                                  }).ToList<DTO_PhieuBaoHanh>();
                }


                return result;
            }
        }
        public List<DTO_PhieuBaoHanh> searchDate(DateTime from, DateTime to)
        {
            using (CellphoneComponentEntities db = new CellphoneComponentEntities())
            {
                var result = (from item in db.PhieuBaoHanhs
                              join nv in db.NhanViens on item.MaNhanVien equals nv.MaNhanVien
                              join hh in db.HangHoas on item.MaHangHoa equals hh.MaHangHoa
                              select new DTO_PhieuBaoHanh
                              {
                                  MaPhieuBaoHanh = item.MaPhieuBaoHanh,
                                  NgayLap = item.NgayLap,
                                  NgayGiao = item.NgayGiao,
                                  TenHangHoa = hh.TenHangHoa,
                                  TenNhanVien = nv.TenNhanVien,
                                  TenKhachHang = item.TenKhachHang,
                                  SoDienThoai = item.SoDienThoai,
                                  TongTien = item.TongTien,
                                  GhiChu = item.GhiChu,
                                  DaGiao = item.DaGiao,
                                  NgayChinhSua = item.NgayChinhSua
                              })
                              .Where(res => (from <= res.NgayLap && res.NgayLap <= to)
                              || (from <= res.NgayChinhSua && res.NgayChinhSua <= to))
                              .ToList<DTO_PhieuBaoHanh>();
                return result;
            }
        }
        public static PhieuBaoHanh Instance
        {
            get
            {
                if (instance == null)
                    instance = new PhieuBaoHanh();
                return instance;
            }
        }

        public string MaPhieuBaoHanh { get; set; }
        public Nullable<System.DateTime> NgayLap { get; set; }
        public Nullable<System.DateTime> NgayGiao { get; set; }
        public string MaNhanVien { get; set; }
        public string TenKhachHang { get; set; }
        public string SoDienThoai { get; set; }
        public Nullable<decimal> TongTien { get; set; }
        public string GhiChu { get; set; }
        public Nullable<bool> DaGiao { get; set; }
        public Nullable<System.DateTime> NgayChinhSua { get; set; }
        public string MaHangHoa { get; set; }
    
        public virtual HangHoa HangHoa { get; set; }
        public virtual NhanVien NhanVien { get; set; }
    }
}
