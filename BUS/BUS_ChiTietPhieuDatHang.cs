using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BUS
{
    public class BUS_ChiTietPhieuDatHang
    {
        private static BUS_ChiTietPhieuDatHang instance;

        public BUS_ChiTietPhieuDatHang() { }

        public static BUS_ChiTietPhieuDatHang Instance
        {
            get
            {
                if (instance == null)
                    instance = new BUS_ChiTietPhieuDatHang();
                return instance;
            }
        }

        public String generateAutoID()
        {
            return Helper.generateAutoID("ChiTietPhieuDatHang", "MaChiTietPhieuDat", "CTPDH");
        }
    }
}
