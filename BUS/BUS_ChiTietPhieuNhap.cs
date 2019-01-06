using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BUS
{
    public class BUS_ChiTietPhieuNhap
    {
        private static BUS_ChiTietPhieuNhap instance;

        public BUS_ChiTietPhieuNhap() { }

        public static BUS_ChiTietPhieuNhap Instance
        {
            get
            {
                if (instance == null)
                    instance = new BUS_ChiTietPhieuNhap();
                return instance;
            }
        }

        public static List<DTO_ChiTietPhieuNhap> showData()
        {
            return ChiTietPhieuNhap.Instance.show();
        }

        public static List<DTO_ChiTietPhieuNhap> showDataByPhieuNhap(String phieuNhapID)
        {
            return ChiTietPhieuNhap.Instance.showByPhieuNhap(phieuNhapID);
        }
        public static void Delete(String id)
        {
            ChiTietPhieuNhap.Instance.delete(id);
        }

        public void Insert(DTO_ChiTietPhieuNhap obj)
        {
            ChiTietPhieuNhap.Instance.insert(obj);
        }

        public void Update(DTO_ChiTietPhieuNhap obj)
        {
            ChiTietPhieuNhap.Instance.update(obj);
        }

        public String generateAutoID()
        {
            return Helper.generateAutoID("ChiTietPhieuNhap","MaChiTietPhieuNhap","CTPN");
        }
    }
}
