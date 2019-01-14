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

        public static List<DTO_HangHoa> showDataDKD()
        {
            return HangHoa.Instance.showHHDKD();
        }

        public static bool Delete(DTO_HangHoa obj)
        {
            return HangHoa.Instance.DeleteHH(obj);
        }

        public bool Insert(DTO_HangHoa obj)
        {
            return HangHoa.Instance.InsertHH(obj);
        }

        public bool Update(DTO_HangHoa obj)
        {
            return HangHoa.Instance.update(obj);
        }

        public List<DTO_HangHoa> searchData(bool trangthai ,String str)
        {
            return HangHoa.Instance.search(trangthai ,str);
        }

        public decimal getGiaBan(string maHangHoa)
        {
            return HangHoa.Instance.getGiaBan(maHangHoa);
        }
        public bool UpdateSoLuong(DTO_HangHoa obj)
        {
            return HangHoa.Instance.updateSoLuong(obj);
        }

        public int getSoLuong(string tenHangHoa)
        {
            return HangHoa.Instance.getSoLuong(tenHangHoa);
        }
    }
}
