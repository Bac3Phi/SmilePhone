using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_PhieuChi
    {
        private static DTO_PhieuChi instance;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DTO_PhieuChi()
        {

        }
        public static DTO_PhieuChi Instance
        {
            get
            {
                if (instance == null)
                    instance = new DTO_PhieuChi();
                return instance;
            }
        }

        public string MaPhieuChi { get; set; }
        public Nullable<System.DateTime> NgayChi { get; set; }
        public string TenNhanVien { get; set; }
        public string MaPhieuNhap { get; set; }
        public Nullable<decimal> TongTienChi { get; set; }
        public string GhiChu { get; set; }
        public Nullable<System.DateTime> NgayChinhSua { get; set; }
    }
}
