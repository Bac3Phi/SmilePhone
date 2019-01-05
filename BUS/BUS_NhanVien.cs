﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BUS
{
    public class BUS_NhanVien
    {
        private static BUS_NhanVien instance;

        public BUS_NhanVien() { }

        public static BUS_NhanVien Instance
        {
            get
            {
                if (instance == null)
                    instance = new BUS_NhanVien();
                return instance;
            }
        }

        public static List<DTO_NhanVien> showData()
        {
            return NhanVien.Instance.showNV();
        }
        
        public void InsertNV(DTO_NhanVien obj)
        {
            NhanVien.Instance.InsertNV(obj);
        }

        public void UpdateNV(DTO_NhanVien obj)
        {
            NhanVien.Instance.UpdateNV(obj);
        }

        public String generateAutoID()
        {
            String str = NhanVien.Instance.autoID();
            String res = "";
            if (str == null || str == "")
            {
                res = "NV001";
            }
            else
            {
                int lastChar = Int32.Parse(str.Substring(str.Length - 1));
                int secondLastChar = Int32.Parse(str.Substring(str.Length - 2, 1));
                if (lastChar < 9)
                {
                    lastChar++;
                    res = str.Substring(0, str.Length - 1) + lastChar.ToString();
                }
                else if (lastChar == 9)
                {
                    if (secondLastChar < 9)
                    {
                        lastChar = 0;
                        secondLastChar++;
                        res = str.Substring(0, str.Length - 2) + secondLastChar.ToString() + lastChar.ToString();
                    }
                    else if (secondLastChar == 9)
                    {
                        res = str.Substring(0, str.Length - 3) + "100";
                    }
                }
            }
            return res;
        }

        public List<DTO_NhanVien> searchData(String str)
        {
            return NhanVien.Instance.searchNV(str);
        }
    }
}
