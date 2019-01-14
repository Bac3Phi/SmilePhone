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

        public static List<DTO_HangHoa> showGoods()
        {
            return BaoCaoTonKho.Instance.showGoods();
        }

        public static int getImport(String id, int month, int year)
        {
            return BaoCaoTonKho.Instance.getImport(id, month, year);
        }

        public static int getExport(String id, int month, int year)
        {
            return BaoCaoTonKho.Instance.getExport(id, month, year);
        }

        public static int getLastMount(String id, int month, int year)
        {
            return BaoCaoTonKho.Instance.getLastMount(id, month, year);
        }

        public static int getFirstMount(String id)
        {
            return BaoCaoTonKho.Instance.getFirstMount(id);
        }

        public void Insert(DTO_BaoCaoTonKho obj)
        {
            BaoCaoTonKho.Instance.InsertBC(obj);
        }

        public String generateAutoID()
        {
            return Helper.generateAutoID("BaoCaoTonKho", "MaBaoCao", "BCTK");
        }
    }
}
