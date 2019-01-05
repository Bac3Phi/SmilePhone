using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BUS
{
    public class BUS_PhieuNhap
    {
        private static BUS_PhieuNhap instance;

        public BUS_PhieuNhap() { }

        public static BUS_PhieuNhap Instance
        {
            get
            {
                if (instance == null)
                    instance = new BUS_PhieuNhap();
                return instance;
            }
        }

        public static List<DTO_PhieuNhap> showData()
        {
            return PhieuNhap.Instance.show();
        }

        public static void Delete(String id)
        {
            PhieuNhap.Instance.delete(id);
        }

        public void Insert(DTO_PhieuNhap obj)
        {
            PhieuNhap.Instance.insert(obj);
        }

        public void Update(DTO_PhieuNhap obj)
        {
            PhieuNhap.Instance.update(obj);
        }

        public String generateAutoID()
        {
            String str = PhieuNhap.Instance.autoID();
            String res = "";
            if (str == null || str == "")
            {
                res = "PN001";
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
                        res = str.Substring(0, str.Length - 2) + secondLastChar.ToString() + lastChar.ToString();
                    }
                    else if (secondLastChar == 9)
                    {
                        res = str.Substring(0, str.Length - 3) + "100";
                    }
                }
            }
            return res;
        }

        public List<DTO_PhieuNhap> searchData(String str)
        {
            return PhieuNhap.Instance.search(str);
        }
        public List<DTO_PhieuNhap> searchDate(DateTime formDate, DateTime toDate)
        {
            return PhieuNhap.Instance.searchDate(formDate, toDate);
        }
    }
}
