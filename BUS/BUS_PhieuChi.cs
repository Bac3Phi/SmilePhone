using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BUS
{
    public class BUS_PhieuChi
    {
        private static BUS_PhieuChi instance;

        public BUS_PhieuChi() { }

        public static BUS_PhieuChi Instance
        {
            get
            {
                if (instance == null)
                    instance = new BUS_PhieuChi();
                return instance;
            }
        }

        public static List<DTO_PhieuChi> showData()
        {
            return PhieuChi.Instance.showPC();
        }

        public static void DeletePC(String id)
        {
            PhieuChi.Instance.DeletePC(id);
        }

        public void InsertPC(DTO_PhieuChi obj)
        {
            PhieuChi.Instance.InsertPC(obj);
        }

        public void UpdatePC(DTO_PhieuChi obj)
        {
            PhieuChi.Instance.UpdatePC(obj);
        }

        public String generateAutoID()
        {
            return Helper.generateAutoID("PhieuChi", "MaPhieuChi", "PC");
        }

        public List<DTO_PhieuChi> searchStrPC(String str)
        {
            return PhieuChi.Instance.searchStrPC(str);
        }

        public List<DTO_PhieuChi> searchDatePC(DateTime fromPC, DateTime toPC)
        {
            return PhieuChi.Instance.searchDatePC(fromPC, toPC);
        }

        public Decimal sumMoneyPC(String importID)
        {
            return PhieuChi.Instance.sumMoneyPC(importID);
        }

        public List<DTO_NhapChi> showPN()
        {
            return PhieuChi.Instance.showPN();
        }
    }
}
