using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class BUS_PhanQuyen
    {
        private static BUS_PhanQuyen instance;

        public BUS_PhanQuyen() { }

        public static BUS_PhanQuyen Instance
        {
            get
            {
                if (instance == null)
                    instance = new BUS_PhanQuyen();
                return instance;
            }
        }

        public static List<PhanQuyen> showData()
        {
            return PhanQuyen.Instance.showPQ();
        }
    }
}
