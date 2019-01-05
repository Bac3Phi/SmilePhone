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
            String str = ChiTietPhieuNhap.Instance.autoID();
            String res = "";
            if (str == null || str == "")
            {
                res = "CTPN001";
            }
            else
            {
                int lastChar = Int32.Parse(str.Substring(str.Length - 1));
                int secondLastChar = Int32.Parse(str.Substring(str.Length - 2, 1));
                if (lastChar < 9)
                {
                    lastChar++;
                    res = str.Substring(0, str.Length - 1) + lastChar.ToString();
                }
                else if (lastChar == 9)
                {
                    if (secondLastChar < 9)
                    {
                        lastChar = 0;
                        secondLastChar++;
                        res = str.Substring(0, str.Length - 2) + lastChar.ToString();
                    }
                    else if (secondLastChar == 9)
                    {
                        res = str.Substring(0, str.Length - 3) + "100";
                    }
                }
            }
            return res;
        }
    }
}
