//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SmilePhone
{
    using System;
    using System.Collections.Generic;
    
    public partial class PhieuBaoHang
    {
        public string MaPhieuBaoHanh { get; set; }
        public Nullable<System.DateTime> NgayLap { get; set; }
        public Nullable<System.DateTime> NgayGiao { get; set; }
        public string MaNhanVien { get; set; }
        public string TenKhachHang { get; set; }
        public string SoDienThoai { get; set; }
        public Nullable<decimal> TongTien { get; set; }
        public string GhiChu { get; set; }
        public Nullable<bool> DaGiao { get; set; }
        public Nullable<System.DateTime> NgayChinhSua { get; set; }
        public string TenModel { get; set; }
    
        public virtual NhanVien NhanVien { get; set; }
    }
}