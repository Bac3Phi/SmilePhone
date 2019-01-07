using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BUS
{
    public class BUS_HangHoa
    {
        private static BUS_HangHoa instance;

        public BUS_HangHoa() { }

        public static BUS_HangHoa Instance
        {
            get
            {
                if (instance == null)
                    instance = new BUS_HangHoa();
                return instance;
            }
        }

        public String generateAutoID()
        {
            return Helper.generateAutoID("HangHoa", "MaHangHoa", "HH");
        }

        public static List<DTO_HangHoa> showData()
        {
            return HangHoa.Instance.showHH();
        }

        public static bool Delete(String id)
        {
            return HangHoa.Instance.DeleteHH(id);
        }

        public bool Insert(DTO_HangHoa obj)
        {
            return HangHoa.Instance.InsertHH(obj);
        }
    }
}
