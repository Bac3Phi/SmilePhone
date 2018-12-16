using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class BUS_DangNhap
    {
        private static BUS_DangNhap instance;

        public BUS_DangNhap() {}

        public static BUS_DangNhap Instance
        {
            get
            {
                if (instance == null)
                    instance = new BUS_DangNhap();
                return instance;
            }
        }

        public NhanVien DangNhap(string userName, string password)
        {
            return DAL_DangNhap.Instance.CheckDangNhap(userName, password);
        }
    }
}
