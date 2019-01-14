using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_BaoCaoTonKho
    {
        private static DTO_BaoCaoTonKho instance;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DTO_BaoCaoTonKho()
        {

        }
        public static DTO_BaoCaoTonKho Instance
        {
            get
            {
                if (instance == null)
                    instance = new DTO_BaoCaoTonKho();
                return instance;
            }
        }
        public string MaBaoCao { get; set; }
        public Nullable<int> Thang { get; set; }
        public Nullable<int> Nam { get; set; }
        public string TenHangHoa { get; set; }
        public Nullable<int> SoLuongTonDau { get; set; }
        public Nullable<int> SoLuongNhap { get; set; }
        public Nullable<int> SoLuongXuat { get; set; }
        public Nullable<int> SoLuongTonCuoi { get; set; }
    }
}
