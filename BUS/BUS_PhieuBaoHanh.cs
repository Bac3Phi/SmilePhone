using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_PhieuBaoHanh
    {
        private static BUS_PhieuBaoHanh instance;

        public BUS_PhieuBaoHanh() { }

        public static BUS_PhieuBaoHanh Instance
        {
            get
            {
                if (instance == null)
                    instance = new BUS_PhieuBaoHanh();
                return instance;
            }
        }

        public static List<DTO_PhieuBaoHanh> showData()
        {
            return PhieuBaoHanh.Instance.show();
        }

        public static void Delete(String id)
        {
            PhieuBaoHanh.Instance.delete(id);
        }

        public void Insert(DTO_PhieuBaoHanh obj)
        {
            PhieuBaoHanh.Instance.insert(obj);
        }

        public void Update(DTO_PhieuBaoHanh obj)
        {
            PhieuBaoHanh.Instance.update(obj);
        }

        public String generateAutoID()
        {
            return Helper.generateAutoID("PhieuBaoHanh", "MaPhieuBaoHanh", "PBH");
        }

        public List<DTO_PhieuBaoHanh> searchData(String str, bool isMergeCondition, bool daGiao)
        {
            return PhieuBaoHanh.Instance.search(str, isMergeCondition, daGiao);
        }
        public List<DTO_PhieuBaoHanh> searchDate(DateTime formDate, DateTime toDate)
        {
            return PhieuBaoHanh.Instance.searchDate(formDate, toDate);
        }
    }
}
