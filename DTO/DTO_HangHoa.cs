using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_HangHoa
    {
        private static DTO_HangHoa instance;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DTO_HangHoa()
        {

        }
        public static DTO_HangHoa Instance
        {
            get
            {
                if (instance == null)
                    instance = new DTO_HangHoa();
                return instance;
            }
        }

        public string MaHangHoa { get; set; }
        public string TenHangHoa { get; set; }
        public Nullable<decimal> GiaBan { get; set; }
        public Nullable<decimal> GiamGia { get; set; }
        public Nullable<int> SoLuongTon { get; set; }
        public string DonViTinh { get; set; }
        public string MoTa { get; set; }
        public string ThongSoKyThuat { get; set; }
        public string XuatXu { get; set; }
        public Nullable<int> ThoiGianBaoHang { get; set; }
        public string HinhAnh { get; set; }
        public string TenLoaiHangHoa { get; set; }
        public Nullable<bool> TrangThai { get; set; }
        public string TenModel { get; set; }
    }
}
