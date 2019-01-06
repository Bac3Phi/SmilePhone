using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BUS
{
    public class BUS_NhanVien
    {
        private static BUS_NhanVien instance;

        public BUS_NhanVien() { }

        public static BUS_NhanVien Instance
        {
            get
            {
                if (instance == null)
                    instance = new BUS_NhanVien();
                return instance;
            }
        }

        public static List<DTO_NhanVien> showData()
        {
            return NhanVien.Instance.showNV();
        }
        
        public void InsertNV(DTO_NhanVien obj)
        {
            NhanVien.Instance.InsertNV(obj);
        }

        public void UpdateNV(DTO_NhanVien obj)
        {
            NhanVien.Instance.UpdateNV(obj);
        }

        public String generateAutoID()
        {
            return Helper.generateAutoID("NhanVien", "MaNhanVien", "NV");
        }

        public List<DTO_NhanVien> searchData(String str)
        {
            return NhanVien.Instance.searchNV(str);
        }
    }
}
