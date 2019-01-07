using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DTO;
using BUS;

namespace SmilePhone.UI
{
    /// <summary>
    /// Interaction logic for UI_LapPhieuBanHang.xaml
    /// </summary>
    public partial class UI_LapPhieuBanHang : UserControl
    {
        private bool isNew = false;
        private DTO_PhieuBanHang item = new DTO_PhieuBanHang();

        public UI_LapPhieuBanHang()
        {
            InitializeComponent();
            generatePhieuBanHangID();
            dpNgayLap.SelectedDate = DateTime.Today;
            dpNgayChinhSua.SelectedDate = DateTime.Today;
            txtTenNhanVien.Text = Properties.Settings.Default.TenNhanVien;
            isNew = true;
        }

        public UI_LapPhieuBanHang(DTO_PhieuBanHang obj)
        {
            InitializeComponent();
            txtMaPhieuBanHang.Text = obj.MaPhieuBanHang;
            dpNgayLap.SelectedDate = obj.NgayBan;
            dpNgayChinhSua.SelectedDate = obj.NgayChinhSua;
            txtTenNhanVien.Text = obj.TenNhanVien;
            txtTenKhachHang.Text = obj.TenKhachHang;
            txtSoDienThoai.Text = obj.SoDienThoai;
            txtGhiChu.Text = obj.GhiChu;
            txtTongTien.Text = obj.TongTien.ToString();
            isNew = false;
        }

        private void generatePhieuBanHangID()
        {
            txtMaPhieuBanHang.Text = BUS_PhieuBanHang.Instance.generateAutoID();
        }

        private void btnQuayLai_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = new UI_BanHang();
            UI_ManHinhChinh.gridMain.Children.Clear();
            UI_ManHinhChinh.gridMain.Children.Add(usc);
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (isNew == true)
            {
                if (dpNgayLap.SelectedDate != null && txtTenKhachHang.Text != ""
                    && txtSoDienThoai.Text != "")
                {
                    getDataFromUI();

                    if (BUS_PhieuBanHang.Instance.InsertPBH(item))
                    {
                        MessageBox.Show("Thêm mới thành công!");
                    }
                    else MessageBox.Show("Thêm mới thất bại!");
                }
                else
                {
                    MessageBox.Show("Hãy điền tất cả các ô còn trống!!!");
                }
            }
        }

        private void getDataFromUI()
        {
            item.MaPhieuBanHang = txtMaPhieuBanHang.Text.Trim();
            item.NgayBan = dpNgayLap.SelectedDate.Value;
            item.NgayChinhSua = dpNgayChinhSua.SelectedDate.Value;
            item.TenKhachHang = txtTenKhachHang.Text.Trim();
            item.TenNhanVien = txtTenNhanVien.Text.Trim();
            item.SoDienThoai = txtSoDienThoai.Text.Trim();
            item.GhiChu = txtGhiChu.Text.Trim();
            item.TongTien = decimal.Parse(txtTongTien.Text.Trim());
        }

        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
