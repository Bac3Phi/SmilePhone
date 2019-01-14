using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_PhieuDatHang
    {
        private static DTO_PhieuDatHang instance;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DTO_PhieuDatHang()
        {
        }

        public static DTO_PhieuDatHang Instance
        {
            get
            {
                if (instance == null)
                    instance = new DTO_PhieuDatHang();
                return instance;
            }
        }

        public string MaPhieuDatHang { get; set; }
        public Nullable<System.DateTime> NgayDat { get; set; }
        public string TenNhanVien { get; set; }
        public string TenNhaCungCap { get; set; }
        public Nullable<decimal> TongTien { get; set; }
        public string GhiChu { get; set; }
        public Nullable<System.DateTime> NgayChinhSua { get; set; }
    }
}
