using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_ChiTietPhieuNhap
    {
        public string MaPhieuNhap { get; set; }
        public string TenHangHoa { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public Nullable<decimal> GiaNhap { get; set; }
        public Nullable<decimal> ThanhTien { get; set; }
        public string MaChiTietPhieuNhap { get; set; }

        private static DTO_ChiTietPhieuNhap instance;
        public static DTO_ChiTietPhieuNhap Instance
        {
            get
            {
                if (instance == null)
                    instance = new DTO_ChiTietPhieuNhap();
                return instance;
            }
        }
        public DTO_ChiTietPhieuNhap()
        {

        }
    }
}
