using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BUS
{
    public class BUS_LoaiHangHoa
    {
        private static BUS_LoaiHangHoa instance;

        public BUS_LoaiHangHoa() { }

        public static BUS_LoaiHangHoa Instance
        {
            get
            {
                if (instance == null)
                    instance = new BUS_LoaiHangHoa();
                return instance;
            }
        }

        public String generateAutoID()
        {
            return Helper.generateAutoID("LoaiHangHoa", "MaLoaiHangHoa", "LHH");
        }

        public static List<DTO_LoaiHangHoa> showData()
        {
            return LoaiHangHoa.Instance.show();
        }

        public bool Insert(DTO_LoaiHangHoa obj)
        {
            return LoaiHangHoa.Instance.insert(obj);
        }

        public static bool Delete(String id)
        {
            return LoaiHangHoa.Instance.delete(id);
        }

        public List<DTO_LoaiHangHoa> searchData(String str)
        {
            return LoaiHangHoa.Instance.search(str);
        }

        public bool Update(DTO_LoaiHangHoa obj)
        {
            return LoaiHangHoa.Instance.update(obj);
        }
    }
}
