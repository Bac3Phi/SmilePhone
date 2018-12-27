using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BUS
{
    public class BUS_PhieuChi
    {
        private static BUS_PhieuChi instance;

        public BUS_PhieuChi() { }

        public static BUS_PhieuChi Instance
        {
            get
            {
                if (instance == null)
                    instance = new BUS_PhieuChi();
                return instance;
            }
        }

        public static List<DTO_PhieuChi> showData()
        {
            return PhieuChi.Instance.showPC();
        }

        public static void DeletePC(String id)
        {
            PhieuChi.Instance.DeletePC(id);
        }

        public void InsertPC(DTO_PhieuChi obj)
        {
            PhieuChi.Instance.InsertPC(obj);
        }

        public void UpdatePC(DTO_PhieuChi obj)
        {
            PhieuChi.Instance.UpdatePC(obj);
        }

        public String generateAutoID()
        {
            String str = PhieuChi.Instance.autoID();
            String res = "";
            if (str == null || str == "")
            {
                res = "PC001";
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
                        lastChar++;
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

        public List<DTO_PhieuChi> searchStrPC(String str)
        {
            return PhieuChi.Instance.searchStrPC(str);
        }

        public List<DTO_PhieuChi> searchDatePC(DateTime fromPC, DateTime toPC)
        {
            return PhieuChi.Instance.searchDatePC(fromPC, toPC);
        }

        public Decimal sumMoneyPC(String importID)
        {
            return PhieuChi.Instance.sumMoneyPC(importID);
        }

        public List<PhieuNhap> showPN()
        {
            return PhieuChi.Instance.showPN();
        }
    }
}
