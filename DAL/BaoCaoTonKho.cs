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
    
    public partial class BaoCaoTonKho
    {
        private static BaoCaoTonKho instance;
        public string MaBaoCao { get; set; }
        public Nullable<int> Thang { get; set; }
        public Nullable<int> Nam { get; set; }
        public string MaHangHoa { get; set; }
        public Nullable<int> SoLuongTonDau { get; set; }
        public Nullable<int> SoLuongNhap { get; set; }
        
        public Nullable<int> SoLuongXuat { get; set; }
        public Nullable<int> SoLuongTonCuoi { get; set; }
    
        public virtual HangHoa HangHoa { get; set; }

        public static BaoCaoTonKho Instance
        {
            get
            {
                if (instance == null)
                    instance = new BaoCaoTonKho();
                return instance;
            }
        }


        public List<DTO_BaoCaoTonKho> showBC()
        {
            using (CellphoneComponentEntities db = new CellphoneComponentEntities())
            {
                //var tondau = (from item in db.BaoCaoTonKhoes
                //              join goods in db.HangHoas on item.MaHangHoa equals goods.MaHangHoa
                //              select goods.SoLuongTon).ToList();

                //var nhap = (from id in db.PhieuNhaps
                //            join details in db.ChiTietPhieuNhaps on id.MaPhieuNhap equals details.MaPhieuNhap
                //            where details.MaHangHoa == this.MaHangHoa
                //            select )

                var result = (from item in db.BaoCaoTonKhoes
                              join goods in db.HangHoas on item.MaHangHoa equals goods.MaHangHoa
                              select new DTO_BaoCaoTonKho
                              {
                                  MaBaoCao = item.MaBaoCao,
                                  Thang = item.Thang,
                                  Nam = item.Nam,
                                  TenHangHoa = goods.TenHangHoa,
                                  SoLuongTonDau = item.SoLuongTonDau,
                                  SoLuongNhap = item.SoLuongNhap,
                                  SoLuongXuat = item.SoLuongXuat,
                                  SoLuongTonCuoi = item.SoLuongTonCuoi
                              }).ToList();
                return result;
            }
        }

        public List<DTO_BaoCaoTonKho> showChart(String name)
        {
            using (CellphoneComponentEntities db = new CellphoneComponentEntities())
            {
                var result = (from item in db.BaoCaoTonKhoes
                              join goods in db.HangHoas on item.MaHangHoa equals goods.MaHangHoa
                              where goods.TenHangHoa == name
                              select new DTO_BaoCaoTonKho
                              {
                                  MaBaoCao = item.MaBaoCao,
                                  Thang = item.Thang,
                                  Nam = item.Nam,
                                  TenHangHoa = goods.TenHangHoa,
                                  SoLuongTonDau = item.SoLuongTonDau,
                                  SoLuongNhap = item.SoLuongNhap,
                                  SoLuongXuat = item.SoLuongXuat,
                                  SoLuongTonCuoi = item.SoLuongTonCuoi
                              }).ToList();
                return result;
            }
        }

        
        public List<DTO_HangHoa> showGoods()
        {
            using (CellphoneComponentEntities db = new CellphoneComponentEntities())
            {
                var result = (from item in db.HangHoas
                              select new DTO_HangHoa
                              {
                                  MaHangHoa = item.MaHangHoa,
                                  TenHangHoa = item.TenHangHoa
                              }).ToList();
                return result;
            }
        }

        public int getImport(String id, int month, int year)
        {
            using (CellphoneComponentEntities db = new CellphoneComponentEntities())
            {
                String query = "select sum(CTPN.soluong) as soluongnhap from dbo.PhieuNhap PN " +
                    "join dbo.ChiTietPhieuNhap CTPN on PN.MaPhieuNhap = CTPN.MaPhieuNhap where CTPN.MaHangHoa = '" + id + "' " +
                    "AND month(PN.NgayNhap) = " + month + " AND year(PN.NgayNhap) = " + year;
                var result = db.Database
                    .SqlQuery<int>(query)
                    .FirstOrDefault();
                if (result != 0)
                    return result;
                else
                    return 0;
            }
        }

        public int getExport(String id, int month, int year)
        {
            using (CellphoneComponentEntities db = new CellphoneComponentEntities())
            {
                String query = "select sum(CTPBH.SoLuong) as soluongxuat from dbo.phieubanhang PBH " +
                    "join dbo.chitietphieubanhang CTPBH on PBH.MaPhieuBanHang = CTPBH.MaPhieuBanHang " +
                    "where CTPBH.MaHangHoa = '" + id + "' AND month(PBH.Ngayban) = " + month + " AND year(PBH.Ngayban) = " + year;
                var result = db.Database
                    .SqlQuery<int>(query)
                    .FirstOrDefault();
                if (result != 0)
                    return result;
                else
                    return 0;
            }
        }

        public int getFirstMount(String id)
        {
            using (CellphoneComponentEntities db = new CellphoneComponentEntities())
            {
                String query = "select HH.soluongton from dbo.HangHoa HH where HH.MaHangHoa = '" + id + "'";
                var result = db.Database
                    .SqlQuery<int>(query)
                    .FirstOrDefault();
                if (result != 0)
                    return result;
                else
                    return 0;
            }
        }

        public int getLastMount(String id, int month, int year)
        {
            int export = getExport(id, month, year);
            int first = getFirstMount(id);

            return first - export;
        }

        public void InsertBC(DTO_BaoCaoTonKho obj)
        {
            using (CellphoneComponentEntities db = new CellphoneComponentEntities())
            {
                var result = db.Database
                    .SqlQuery<String>("select MaHangHoa from dbo.HangHoa where TenHangHoa = N'" + obj.TenHangHoa + "'")
                    .FirstOrDefault();
                BaoCaoTonKho bc = new BaoCaoTonKho();
                bc.MaBaoCao = obj.MaBaoCao;
                bc.MaHangHoa = result;
                bc.Nam = obj.Nam;
                bc.Thang = obj.Thang;
                bc.SoLuongNhap = obj.SoLuongNhap;
                bc.SoLuongXuat = obj.SoLuongXuat;
                bc.SoLuongTonDau = obj.SoLuongTonDau;
                bc.SoLuongTonCuoi = obj.SoLuongTonCuoi;

                db.BaoCaoTonKhoes.Add(bc);
                db.SaveChanges();
            }
        }

        public void DeleteBC(DTO_BaoCaoTonKho obj)
        {
            using (CellphoneComponentEntities db = new CellphoneComponentEntities())
            {
                BaoCaoTonKho bc = (from item in db.BaoCaoTonKhoes
                                  where item.MaBaoCao == obj.MaBaoCao
                                  select item).SingleOrDefault();
                db.BaoCaoTonKhoes.Remove(bc);
                db.SaveChanges();
            }
        }
    }
}
