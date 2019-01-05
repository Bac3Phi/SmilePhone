using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BUS
{
    public class BUS_NhaCungCap
    {
        private static BUS_NhaCungCap instance;

        public BUS_NhaCungCap() { }

        public static BUS_NhaCungCap Instance
        {
            get
            {
                if (instance == null)
                    instance = new BUS_NhaCungCap();
                return instance;
            }
        }

        public static List<DTO_NhaCungCap> showData()
        {
            return NhaCungCap.Instance.showNCC();
        }

        public static void DeleteNCC(DTO_NhaCungCap obj)
        {
            NhaCungCap.Instance.DeleteNCC(obj);
        }

        public void InsertNCC(DTO_NhaCungCap obj)
        {
            NhaCungCap.Instance.InsertNCC(obj);
        }

        public void UpdateNCC(DTO_NhaCungCap obj)
        {
            NhaCungCap.Instance.UpdateNCC(obj);
        }

        public String generateAutoID()
        {
            String str = NhaCungCap.Instance.autoID();
            String res = "";
            if (str == null || str == "")
            {
                res = "NCC001";
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

        public List<DTO_NhaCungCap> searchData(String str)
        {
            return NhaCungCap.Instance.searchNCC(str);
        }
    }
}