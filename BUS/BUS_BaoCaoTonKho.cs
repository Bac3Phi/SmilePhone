using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BUS
{
    public class BUS_BaoCaoTonKho
    {
        private static BUS_BaoCaoTonKho instance;

        public BUS_BaoCaoTonKho() { }

        public static BUS_BaoCaoTonKho Instance
        {
            get
            {
                if (instance == null)
                    instance = new BUS_BaoCaoTonKho();
                return instance;
            }
        }

        public static List<DTO_BaoCaoTonKho> showData()
        {
            return BaoCaoTonKho.Instance.showBC();
        }

        public static List<DTO_BaoCaoTonKho> showChart(String name)
        {
            return BaoCaoTonKho.Instance.showChart(name);
        }
    }
}
