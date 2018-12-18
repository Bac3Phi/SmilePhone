using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

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

        public static List<NhaCungCap> showData()
        {
            return NhaCungCap.Instance.showNCC();
        }

        public static void DeleteNCC(NhaCungCap obj)
        {
            NhaCungCap.Instance.DeleteNCC(obj);
        }

        public NhaCungCap InsertNCC(NhaCungCap obj)
        {
            return NhaCungCap.Instance.InsertNCC(obj);
        }

        public void UpdateNCC(NhaCungCap obj)
        {
            NhaCungCap.Instance.UpdateNCC(obj);
        }
    }
}
