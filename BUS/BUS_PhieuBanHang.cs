using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BUS
{
    public class BUS_PhieuBanHang
    {
        private static BUS_PhieuBanHang instance;

        public BUS_PhieuBanHang() { }

        public static BUS_PhieuBanHang Instance
        {
            get
            {
                if (instance == null)
                    instance = new BUS_PhieuBanHang();
                return instance;
            }
        }

        public static List<DTO_PhieuBanHang> showData()
        {
            return PhieuBanHang.Instance.showPBH();
        }

        public bool InsertPBH(DTO_PhieuBanHang obj)
        {
            return PhieuBanHang.Instance.InsertPBH(obj);
        }

        public String generateAutoID()
        {
            return Helper.generateAutoID("PhieuBanHang", "MaPhieuBanHang", "PBH");
        }

        public static bool Delete(String id)
        {
            return PhieuBanHang.Instance.DeletePBH(id);
        }

        public List<DTO_PhieuBanHang> SearchData(String str)
        {
            return PhieuBanHang.Instance.SearchPBH(str);
        }
        public List<DTO_PhieuBanHang> SearchDate(DateTime formDate, DateTime toDate)
        {
            return PhieuBanHang.Instance.searchDate(formDate, toDate);
        }
    }
}
