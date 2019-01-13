using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_ChiTietPhieuDatHang
    {
        private static DTO_ChiTietPhieuDatHang instance;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DTO_ChiTietPhieuDatHang()
        {
        }

        public static DTO_ChiTietPhieuDatHang Instance
        {
            get
            {
                if (instance == null)
                    instance = new DTO_ChiTietPhieuDatHang();
                return instance;
            }
        }

        public string MaPhieuDatHang { get; set; }
        public string TenHangHoa { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public Nullable<decimal> Gia { get; set; }
        public Nullable<decimal> ThanhTien { get; set; }
        public string MaChiTietPhieuDat { get; set; }
    }
}
