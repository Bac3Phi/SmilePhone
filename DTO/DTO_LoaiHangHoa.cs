using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_LoaiHangHoa
    {
        private static DTO_LoaiHangHoa instance;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DTO_LoaiHangHoa()
        {
        }

        public static DTO_LoaiHangHoa Instance
        {
            get
            {
                if (instance == null)
                    instance = new DTO_LoaiHangHoa();
                return instance;
            }
        }

        public string MaLoaiHangHoa { get; set; }
        public string TenLoaiHangHoa { get; set; }
        public Nullable<int> PhanTramLoiNhuan { get; set; }
    }
}
