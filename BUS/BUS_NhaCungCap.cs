using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    class BUS_NhaCungCap
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

        //public bool DangNhap(string userName, string password)
        //{
        //    return NhaCungCap.Instance.CheckDangNhap(userName, password);
        //}
    }
}
