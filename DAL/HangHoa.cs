﻿//------------------------------------------------------------------------------
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
    
    public partial class HangHoa
    {
        private static HangHoa instance;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HangHoa()
        {
            this.BaoCaoTonKhoes = new HashSet<BaoCaoTonKho>();
            this.ChiTietPhieuBanHangs = new HashSet<ChiTietPhieuBanHang>();
            this.ChiTietPhieuDatHangs = new HashSet<ChiTietPhieuDatHang>();
            this.ChiTietPhieuNhaps = new HashSet<ChiTietPhieuNhap>();
            this.PhieuBaoHanhs = new HashSet<PhieuBaoHanh>();
        }

        public static HangHoa Instance
        {
            get
            {
                if (instance == null)
                    instance = new HangHoa();
                return instance;
            }
        }

        public string MaHangHoa { get; set; }
        public string TenHangHoa { get; set; }
        public Nullable<decimal> GiaBan { get; set; }
        public Nullable<decimal> GiamGia { get; set; }
        public Nullable<int> SoLuongTon { get; set; }
        public string DonViTinh { get; set; }

        public bool updateSoLuong(DTO_HangHoa obj)
        {
            using (CellphoneComponentEntities db = new CellphoneComponentEntities())
            {
                var resultMaHangHoa = db.Database
                    .SqlQuery<String>("select MaHangHoa from dbo.HangHoa where TenHangHoa = N'" + obj.TenHangHoa + "'")
                    .FirstOrDefault();
                HangHoa hanghoa = new HangHoa();
                hanghoa.MaHangHoa = obj.MaHangHoa;
                hanghoa.TenHangHoa = obj.TenHangHoa;
                hanghoa.SoLuongTon = obj.SoLuongTon;

                db.HangHoas.Attach(hanghoa);
                db.Entry(hanghoa).State = System.Data.Entity.EntityState.Modified;
                if (db.SaveChanges() > 0)
                    return true;
                return false;
            }
        }

        public string MoTa { get; set; }
        public string ThongSoKyThuat { get; set; }
        public string XuatXu { get; set; }
        public Nullable<int> ThoiGianBaoHang { get; set; }
        public string HinhAnh { get; set; }
        public string MaLoaiHangHoa { get; set; }
        public Nullable<bool> TrangThai { get; set; }
        public string TenModel { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaoCaoTonKho> BaoCaoTonKhoes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietPhieuBanHang> ChiTietPhieuBanHangs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietPhieuDatHang> ChiTietPhieuDatHangs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; }
        public virtual LoaiHangHoa LoaiHangHoa { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuBaoHanh> PhieuBaoHanhs { get; set; }

        public List<DTO_HangHoa> showHH()
        {
            using (CellphoneComponentEntities db = new CellphoneComponentEntities())
            {
                var result = (from item in db.HangHoas
                              join lh in db.LoaiHangHoas on item.MaLoaiHangHoa equals lh.MaLoaiHangHoa
                              select new DTO_HangHoa
                              {
                                  MaHangHoa = item.MaHangHoa,
                                  TenHangHoa = item.TenHangHoa,
                                  GiaBan = item.GiaBan,
                                  GiamGia = item.GiamGia,
                                  SoLuongTon = item.SoLuongTon,
                                  DonViTinh = item.DonViTinh,
                                  MoTa = item.MoTa,
                                  ThongSoKyThuat = item.ThongSoKyThuat,
                                  XuatXu = item.XuatXu,
                                  ThoiGianBaoHang = item.ThoiGianBaoHang,
                                  HinhAnh = item.HinhAnh,
                                  TenLoaiHangHoa = lh.TenLoaiHangHoa,
                                  TrangThai = item.TrangThai,
                                  strTrangThai = item.TrangThai == true? "Đang kinh doanh" : "Ngừng kinh doanh",
                                  TenModel = item.TenModel
                              }).ToList<DTO_HangHoa>();
                return result;
            }
        }

        public List<DTO_HangHoa> showHHDKD()
        {
            using (CellphoneComponentEntities db = new CellphoneComponentEntities())
            {
                var result = (from item in db.HangHoas
                              join lh in db.LoaiHangHoas on item.MaLoaiHangHoa equals lh.MaLoaiHangHoa
                              where item.TrangThai == true
                              select new DTO_HangHoa
                              {
                                  MaHangHoa = item.MaHangHoa,
                                  TenHangHoa = item.TenHangHoa,
                                  GiaBan = item.GiaBan,
                                  GiamGia = item.GiamGia,
                                  SoLuongTon = item.SoLuongTon,
                                  DonViTinh = item.DonViTinh,
                                  MoTa = item.MoTa,
                                  ThongSoKyThuat = item.ThongSoKyThuat,
                                  XuatXu = item.XuatXu,
                                  ThoiGianBaoHang = item.ThoiGianBaoHang,
                                  HinhAnh = item.HinhAnh,
                                  TenLoaiHangHoa = lh.TenLoaiHangHoa,
                                  TrangThai = item.TrangThai,
                                  strTrangThai = item.TrangThai == true ? "Đang kinh doanh" : "Ngừng kinh doanh",
                                  TenModel = item.TenModel
                              }).ToList<DTO_HangHoa>();
                return result;
            }
        }

        public decimal getGiaBan(string maHangHoa)
        {
            using (CellphoneComponentEntities db = new CellphoneComponentEntities())
            {
                var result = (from item in db.HangHoas
                              join lh in db.LoaiHangHoas on item.MaLoaiHangHoa equals lh.MaLoaiHangHoa
                              where item.MaHangHoa.Equals(maHangHoa) 
                              select new DTO_HangHoa
                              {
                                  MaHangHoa = item.MaHangHoa,
                                  TenHangHoa = item.TenHangHoa,
                                  GiaBan = item.GiaBan,
                                  GiamGia = item.GiamGia,
                                  SoLuongTon = item.SoLuongTon,
                                  DonViTinh = item.DonViTinh,
                                  MoTa = item.MoTa,
                                  ThongSoKyThuat = item.ThongSoKyThuat,
                                  XuatXu = item.XuatXu,
                                  ThoiGianBaoHang = item.ThoiGianBaoHang,
                                  HinhAnh = item.HinhAnh,
                                  TenLoaiHangHoa = lh.TenLoaiHangHoa,
                                  TrangThai = item.TrangThai,
                                  TenModel = item.TenModel
                              }).ToList<DTO_HangHoa>();
                if (result.Count > 0)
                    return (decimal)result.First().GiaBan;
                else return 0;
            }
        }

        public int getSoLuong(string tenHangHoa)
        {
            using (CellphoneComponentEntities db = new CellphoneComponentEntities())
            {
                var maHangHoa = db.Database
                    .SqlQuery<String>("select MaLoaiHangHoa from dbo.LoaiHangHoa where TenLoaiHangHoa = N'" + tenHangHoa + "'")
                    .FirstOrDefault();
                var result = (from item in db.HangHoas
                              where item.MaHangHoa.Equals(maHangHoa)
                              select new DTO_HangHoa
                              {
                                  MaHangHoa = item.MaHangHoa,
                                  TenHangHoa = item.TenHangHoa,
                                  GiaBan = item.GiaBan,
                                  GiamGia = item.GiamGia,
                                  SoLuongTon = item.SoLuongTon,
                                  DonViTinh = item.DonViTinh,
                                  MoTa = item.MoTa,
                                  ThongSoKyThuat = item.ThongSoKyThuat,
                                  XuatXu = item.XuatXu,
                                  ThoiGianBaoHang = item.ThoiGianBaoHang,
                                  HinhAnh = item.HinhAnh,
                                  TrangThai = item.TrangThai,
                                  TenModel = item.TenModel
                              }).ToList<DTO_HangHoa>();
                if (result.Count > 0)
                    return (int)result.First().SoLuongTon;
                else return 0;
            }
        }
        public bool DeleteHH(DTO_HangHoa obj)
        {
            using (CellphoneComponentEntities db = new CellphoneComponentEntities())
            {
                var resultMaLoaiHangHoa = db.Database
                    .SqlQuery<String>("select MaLoaiHangHoa from dbo.LoaiHangHoa where TenLoaiHangHoa = N'" + obj.TenLoaiHangHoa + "'")
                    .FirstOrDefault();
                HangHoa hanghoa = new HangHoa();
                hanghoa.MaHangHoa = obj.MaHangHoa;
                hanghoa.TenHangHoa = obj.TenHangHoa;
                hanghoa.GiaBan = obj.GiaBan;
                hanghoa.GiamGia = obj.GiamGia;
                hanghoa.SoLuongTon = obj.SoLuongTon;
                hanghoa.DonViTinh = obj.DonViTinh;
                hanghoa.MoTa = obj.MoTa;
                hanghoa.ThongSoKyThuat = obj.ThongSoKyThuat;
                hanghoa.XuatXu = obj.XuatXu;
                hanghoa.ThoiGianBaoHang = obj.ThoiGianBaoHang;
                hanghoa.HinhAnh = obj.HinhAnh;
                hanghoa.MaLoaiHangHoa = resultMaLoaiHangHoa;
                hanghoa.TrangThai = !obj.TrangThai;
                hanghoa.TenModel = obj.TenModel;

                db.HangHoas.Attach(hanghoa);
                db.Entry(hanghoa).State = System.Data.Entity.EntityState.Modified;
                if (db.SaveChanges() > 0)
                    return true;
                return false;
            }
        }

        public bool InsertHH(DTO_HangHoa obj)
        {
            using (CellphoneComponentEntities db = new CellphoneComponentEntities())
            {
                var resultMaLoaiHangHoa = db.Database
                    .SqlQuery<String>("select MaLoaiHangHoa from dbo.LoaiHangHoa where TenLoaiHangHoa = N'" + obj.TenLoaiHangHoa + "'")
                    .FirstOrDefault();
                HangHoa hanghoa = new HangHoa();
                hanghoa.MaHangHoa = obj.MaHangHoa;
                hanghoa.TenHangHoa = obj.TenHangHoa;
                hanghoa.GiaBan = obj.GiaBan;
                hanghoa.GiamGia = obj.GiamGia;
                hanghoa.SoLuongTon = obj.SoLuongTon;
                hanghoa.DonViTinh = obj.DonViTinh;
                hanghoa.MoTa = obj.MoTa;
                hanghoa.ThongSoKyThuat = obj.ThongSoKyThuat;
                hanghoa.XuatXu = obj.XuatXu;
                hanghoa.ThoiGianBaoHang = obj.ThoiGianBaoHang;
                hanghoa.HinhAnh = obj.HinhAnh;
                hanghoa.MaLoaiHangHoa = resultMaLoaiHangHoa;
                hanghoa.TrangThai = obj.TrangThai;
                hanghoa.TenModel = obj.TenModel;

                db.HangHoas.Add(hanghoa);
                if (db.SaveChanges() > 0)
                    return true;
                return false;
            }
        }

        public bool update(DTO_HangHoa obj)
        {
            using (CellphoneComponentEntities db = new CellphoneComponentEntities())
            {
                var resultMaLoaiHangHoa = db.Database
                    .SqlQuery<String>("select MaLoaiHangHoa from dbo.LoaiHangHoa where TenLoaiHangHoa = N'" + obj.TenLoaiHangHoa + "'")
                    .FirstOrDefault();
                HangHoa hanghoa = new HangHoa();
                hanghoa.MaHangHoa = obj.MaHangHoa;
                hanghoa.TenHangHoa = obj.TenHangHoa;
                hanghoa.GiaBan = obj.GiaBan;
                hanghoa.GiamGia = obj.GiamGia;
                hanghoa.SoLuongTon = obj.SoLuongTon;
                hanghoa.DonViTinh = obj.DonViTinh;
                hanghoa.MoTa = obj.MoTa;
                hanghoa.ThongSoKyThuat = obj.ThongSoKyThuat;
                hanghoa.XuatXu = obj.XuatXu;
                hanghoa.ThoiGianBaoHang = obj.ThoiGianBaoHang;
                hanghoa.HinhAnh = obj.HinhAnh;
                hanghoa.MaLoaiHangHoa = resultMaLoaiHangHoa;
                hanghoa.TrangThai = obj.TrangThai;
                hanghoa.TenModel = obj.TenModel;

                db.HangHoas.Attach(hanghoa);
                db.Entry(hanghoa).State = System.Data.Entity.EntityState.Modified;
                if (db.SaveChanges() > 0)
                    return true;
                return false;
            }
        }

        public List<DTO_HangHoa> search(bool trangthai ,string str)
        {
            List<DTO_HangHoa> result;
            using (CellphoneComponentEntities db = new CellphoneComponentEntities())
            {
                if (str != "")
                {
                    result = (from item in db.HangHoas
                                  join lhh in db.LoaiHangHoas
                                  on item.MaLoaiHangHoa equals lhh.MaLoaiHangHoa
                                  where (item.MaHangHoa.Contains(str.ToUpper())
                                  || item.TenHangHoa.Contains(str)
                                  || item.GiaBan.ToString().Equals(str)
                                  || item.GiamGia.ToString().Equals(str)
                                  || item.SoLuongTon.ToString().Equals(str)
                                  || item.DonViTinh.Contains(str)
                                  || item.MoTa.Contains(str)
                                  || item.ThongSoKyThuat.Contains(str)
                                  || item.XuatXu.Contains(str)
                                  || item.ThoiGianBaoHang.ToString().Equals(str)
                                  || lhh.TenLoaiHangHoa.Contains(str)
                                  || item.TenModel.Contains(str))
                                  && item.TrangThai == trangthai
                                  select new DTO_HangHoa
                                  {
                                      MaHangHoa = item.MaHangHoa,
                                      TenHangHoa = item.TenHangHoa,
                                      GiaBan = item.GiaBan,
                                      GiamGia = item.GiamGia,
                                      SoLuongTon = item.SoLuongTon,
                                      DonViTinh = item.DonViTinh,
                                      MoTa = item.MoTa,
                                      ThongSoKyThuat = item.ThongSoKyThuat,
                                      XuatXu = item.XuatXu,
                                      ThoiGianBaoHang = item.ThoiGianBaoHang,
                                      HinhAnh = item.HinhAnh,
                                      TenLoaiHangHoa = lhh.TenLoaiHangHoa,
                                      TrangThai = item.TrangThai,
                                      strTrangThai = item.TrangThai == true ? "Đang kinh doanh" : "Ngừng kinh doanh",
                                      TenModel = item.TenModel
                                  }).ToList<DTO_HangHoa>();
                }
                else
                {
                    result = (from item in db.HangHoas
                                  join lhh in db.LoaiHangHoas
                                  on item.MaLoaiHangHoa equals lhh.MaLoaiHangHoa
                                  where item.TrangThai == trangthai
                                  select new DTO_HangHoa
                                  {
                                      MaHangHoa = item.MaHangHoa,
                                      TenHangHoa = item.TenHangHoa,
                                      GiaBan = item.GiaBan,
                                      GiamGia = item.GiamGia,
                                      SoLuongTon = item.SoLuongTon,
                                      DonViTinh = item.DonViTinh,
                                      MoTa = item.MoTa,
                                      ThongSoKyThuat = item.ThongSoKyThuat,
                                      XuatXu = item.XuatXu,
                                      ThoiGianBaoHang = item.ThoiGianBaoHang,
                                      HinhAnh = item.HinhAnh,
                                      TenLoaiHangHoa = lhh.TenLoaiHangHoa,
                                      TrangThai = item.TrangThai,
                                      strTrangThai = item.TrangThai == true ? "Đang kinh doanh" : "Ngừng kinh doanh",
                                      TenModel = item.TenModel
                                  }).ToList<DTO_HangHoa>();
                }
                return result;
            }
        }
    }
}
