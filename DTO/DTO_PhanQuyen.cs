using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class DTO_PhanQuyen
    {
        private static DTO_PhanQuyen instance;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DTO_PhanQuyen()
        {
        }
        public static DTO_PhanQuyen Instance
        {
            get
            {
                if (instance == null)
                    instance = new DTO_PhanQuyen();
                return instance;
            }
        }

        public string MaPhanQuyen { get; set; }
        public string TenPhanQuyen { get; set; }
    }
}
