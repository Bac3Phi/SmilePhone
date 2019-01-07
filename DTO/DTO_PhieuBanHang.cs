using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_PhieuBanHang
    {
        private static DTO_PhieuBanHang instance;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DTO_PhieuBanHang()
        {

        }
        
        public static DTO_PhieuBanHang Instance
        {
            get
            {
                if (instance == null)
                    instance = new DTO_PhieuBanHang();
                return instance;
            }
        }

        public string MaPhieuBanHang { get; set; }
        public Nullable<System.DateTime> NgayBan { get; set; }
        public string TenNhanVien { get; set; }
        public string TenKhachHang { get; set; }
        public string SoDienThoai { get; set; }
        public Nullable<decimal> TongTien { get; set; }
        public string GhiChu { get; set; }
        public Nullable<System.DateTime> NgayChinhSua { get; set; }
    }
}
