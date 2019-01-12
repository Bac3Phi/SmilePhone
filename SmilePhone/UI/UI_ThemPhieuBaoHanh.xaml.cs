using BUS;
using DTO;
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

namespace SmilePhone.UI
{
    /// <summary>
    /// Interaction logic for UI_ThemPhieuBaoHanh.xaml
    /// </summary>
    public partial class UI_ThemPhieuBaoHanh : UserControl
    {
        private Grid gridMain;
        private bool isNew = false;
        private DTO_PhieuBaoHanh item = new DTO_PhieuBaoHanh();                                                                                                                                                                                              
        public UI_ThemPhieuBaoHanh(Grid gridMain, DTO_PhieuBaoHanh obj)
        {
            InitializeComponent();
            this.gridMain = gridMain;
            if (obj == null)
            {
                clearData();
                isNew = true;
            }
            else
            {
                getDataFromEditUI(obj);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cbbTenHangHoa.ItemsSource = BUS_HangHoa.showData();

        }

        private void generatePhieuBaoHanhID()
        {
            txtMaPhieuBaoHanh.Text = BUS_PhieuBaoHanh.Instance.generateAutoID();
        }

        private void btnLuu_Click(object sender, RoutedEventArgs e)
        {
            if (isNew == true)
            {
                getData();
                BUS_PhieuBaoHanh.Instance.Insert(item);
                MessageBox.Show("Thêm mới thành công!");
                clearData();
            }
            else
            {
                getData();
                BUS_PhieuBaoHanh.Instance.Update(item);
                MessageBox.Show("Cập nhật thành công!");
            }
        }

        private void btnQuayLai_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = new UI_PhieuBaoHanh(gridMain);
            gridMain.Children.Clear();
            gridMain.Children.Add(usc);
        }

        private void btnExportPDF_Click(object sender, RoutedEventArgs e)
        {
            //if (txtSumMoney.Text != "" && dpReceiptDate.SelectedDate.Value != null
            //        && txtReceiptID.Text != "" && cbbImportID.Text != "" && txtEmployeeName.Text != "")
            //{
            //    item.MaPhieuBaoHanh = txtReceiptID.Text.Trim();
            //    item.NgayChi = dpReceiptDate.SelectedDate.Value;
            //    item.NgayChinhSua = dpReceiptEditDate.SelectedDate.Value;
            //    item.TongTienChi = decimal.Parse(txtSumMoney.Text);
            //    item.MaPhieuNhap = cbbImportID.Text;
            //    item.TenNhanVien = txtEmployeeName.Text;
            //    item.GhiChu = txtReceiptNote.Text.Trim();

            //    UserControl usc = new PrintForm_PhieuBaoHanh(gridMain, item);
            //    gridMain.Children.Clear();
            //    gridMain.Children.Add(usc);
            //}
            //else
            //{
            //    MessageBox.Show("Hãy điền tất cả các ô còn trống!!!");
            //}
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            clearData();
        }

        private void getData()
        {
            item.MaPhieuBaoHanh = txtMaPhieuBaoHanh.Text;
            item.TenHangHoa = cbbTenHangHoa.Text;
            item.NgayLap = dpNgayLap.SelectedDate;
            item.NgayGiao = dpNgayGiao.SelectedDate;
            item.TenNhanVien = txtTenNhanVien.Text;
            item.TenKhachHang = txtTenKhachHang.Text;
            item.SoDienThoai = txtSoDienThoai.Text;
            item.DaGiao = cbDaGiao.IsChecked.Value;
            item.GhiChu = txtGhiChu.Text;

            item.TongTien = decimal.Parse(txtTongTien.Text);
        }

        private void getDataFromEditUI(DTO_PhieuBaoHanh obj)
        {
            txtMaPhieuBaoHanh.Text = obj.MaPhieuBaoHanh;
            dpNgayLap.SelectedDate = obj.NgayLap;
            dpNgayGiao.SelectedDate = obj.NgayGiao;
            cbbTenHangHoa.Text = obj.TenHangHoa;
            txtTenNhanVien.Text = obj.TenNhanVien;
            txtTenKhachHang.Text = obj.TenKhachHang;
            txtSoDienThoai.Text = obj.SoDienThoai;
            cbDaGiao.IsChecked = obj.DaGiao;
            txtGhiChu.Text = obj.GhiChu;
            txtTongTien.Text = obj.TongTien.ToString();

            isNew = false;
        }
        private void clearData()
        {
            generatePhieuBaoHanhID();
            dpNgayLap.SelectedDate = DateTime.Today.AddDays(0);
            dpNgayGiao.SelectedDate = null;
            cbbTenHangHoa.ItemsSource = BUS_HangHoa.showData();
            txtTenNhanVien.Text = Properties.Settings.Default.TenNhanVien;
            txtTenKhachHang.Clear();
            txtSoDienThoai.Clear();
            cbDaGiao.IsChecked = false;
            txtGhiChu.Clear();
            txtTongTien.Clear();
        }
    }
}
