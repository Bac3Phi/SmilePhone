using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_PhieuNhap
    {
        private static DTO_PhieuNhap instance;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DTO_PhieuNhap()
        {
        }

        public static DTO_PhieuNhap Instance
        {
            get
            {
                if (instance == null)
                    instance = new DTO_PhieuNhap();
                return instance;
            }
        }
        public string MaPhieuNhap { get; set; }
        public Nullable<System.DateTime> NgayNhap { get; set; }
        public string TenNhanVien { get; set; }
        public string TenNhaCungCap { get; set; }
        public Nullable<decimal> TongTien { get; set; }
        public string GhiChu { get; set; }
        public Nullable<System.DateTime> NgayChinhSua { get; set; }
    }
}
