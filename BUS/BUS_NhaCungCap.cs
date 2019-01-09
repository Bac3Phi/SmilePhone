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
            return Helper.generateAutoID("NhaCungCap", "MaNhaCungCap", "NCC");
        }

        public bool isValidEmail(String email)
        {
            return Helper.IsValidEmail(email);
        }

        public bool isValidPhoneNumber(String phone)
        {
            return Helper.IsPhoneNumber(phone);
        }

        public List<DTO_NhaCungCap> searchData(String str)
        {
            return NhaCungCap.Instance.searchNCC(str);
        }
    }
}