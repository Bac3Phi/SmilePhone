using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_PhieuBaoHanh
    {
        private static DTO_PhieuBaoHanh instance;
        public DTO_PhieuBaoHanh()
        {
        }

        public static DTO_PhieuBaoHanh Instance
        {
            get
            {
                if (instance == null)
                    instance = new DTO_PhieuBaoHanh();
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
        public string TenHangHoa { get; set; }
        public string TenNhanVien { get; set; }

    }
}
