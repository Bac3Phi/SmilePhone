using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_ChiTietPhieuBanHang
    {
        private static DTO_ChiTietPhieuBanHang instance;
        public static DTO_ChiTietPhieuBanHang Instance
        {
            get
            {
                if (instance == null)
                    instance = new DTO_ChiTietPhieuBanHang();
                return instance;
            }
        }
        public DTO_ChiTietPhieuBanHang()
        {

        }

        public DTO_ChiTietPhieuBanHang(string maPhieuBanHang, string maHangHoa, string tenHangHoa ,int? soLuong, decimal? gia, decimal? thanhTien, string maChiTietPhieuBan)
        {
            MaPhieuBanHang = maPhieuBanHang;
            MaHangHoa = maHangHoa;
            TenHangHoa = tenHangHoa;
            SoLuong = soLuong;
            Gia = gia;
            ThanhTien = thanhTien;
            MaChiTietPhieuBan = maChiTietPhieuBan;
        }

        public string MaPhieuBanHang { get; set; }
        public string MaHangHoa { get; set; }
        public string TenHangHoa { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public Nullable<decimal> Gia { get; set; }
        public Nullable<decimal> ThanhTien { get; set; }
        public string MaChiTietPhieuBan { get; set; }
    }
}
