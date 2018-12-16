using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_DangNhap
    {
        private CellphoneComponentEntities db;
        private static DAL_DangNhap instance;

        public DAL_DangNhap()
        {
            this.db = new CellphoneComponentEntities();
        }

        public static DAL_DangNhap Instance
        {
            get
            {
                if (instance == null)
                    instance = new DAL_DangNhap();
                return instance;
            }
        }

        public NhanVien CheckDangNhap(string userName, string password)
        {
            var result = from nv in db.NhanViens
                         where (nv.UserName == userName) && (nv.Password == password)
                         select nv;
            if (result.Count() > 0)
                return result.First();
            return null;
        }
    }
}
