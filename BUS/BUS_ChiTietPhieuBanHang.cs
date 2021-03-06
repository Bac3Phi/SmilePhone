﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BUS
{
    public class BUS_ChiTietPhieuBanHang
    {
        private static BUS_ChiTietPhieuBanHang instance;

        public BUS_ChiTietPhieuBanHang() { }

        public static BUS_ChiTietPhieuBanHang Instance
        {
            get
            {
                if (instance == null)
                    instance = new BUS_ChiTietPhieuBanHang();
                return instance;
            }
        }

        public static List<DTO_ChiTietPhieuBanHang> showData(string maPhieuBan)
        {
            return ChiTietPhieuBanHang.Instance.showCTPBH(maPhieuBan);
        }

        public bool InsertCTPBH(DTO_ChiTietPhieuBanHang obj)
        {
            return ChiTietPhieuBanHang.Instance.InsertCTPBH(obj);
        }

        public bool SaveOrUpdateCTPBH(DTO_ChiTietPhieuBanHang obj)
        {
            return ChiTietPhieuBanHang.Instance.SaveOrUpdate(obj);
        }

        public bool Delete(String id)
        {
            return ChiTietPhieuBanHang.Instance.DeleteCTPBH(id);
        }

        public String generateAutoID()
        {
            return Helper.generateAutoID("ChiTietPhieuBanHang", "MaChiTietPhieuBan", "CTPBH");
        }
    }
}
