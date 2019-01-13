using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BUS
{
    public class BUS_PhieuDatHang
    {
        private static BUS_PhieuDatHang instance;

        public BUS_PhieuDatHang() { }

        public static BUS_PhieuDatHang Instance
        {
            get
            {
                if (instance == null)
                    instance = new BUS_PhieuDatHang();
                return instance;
            }
        }

        public String generateAutoID()
        {
            return Helper.generateAutoID("PhieuDatHang", "MaPhieuDatHang", "PDH");
        }

        public List<DTO_PhieuDatHang> showData()
        {
            return PhieuDatHang.Instance.show();
        }

        public bool Delete(String id)
        {
            return PhieuDatHang.Instance.delete(id);
        }
    }
}
