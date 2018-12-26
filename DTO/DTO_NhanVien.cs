using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_NhanVien
    {
        private static DTO_NhanVien instance;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DTO_NhanVien()
        {
            
        }
        public static DTO_NhanVien Instance
        {
            get
            {
                if (instance == null)
                    instance = new DTO_NhanVien();
                return instance;
            }
        }

        public string MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string TenPhanQuyen { get; set; }
    }
}
