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
    /// Interaction logic for UI_LapPhieuDatHang.xaml
    /// </summary>
    public partial class UI_LapPhieuDatHang : UserControl
    {
        private bool isNew = false;
        private DTO_PhieuDatHang item = new DTO_PhieuDatHang();
        private DTO_ChiTietPhieuDatHang itemCTPDH = new DTO_ChiTietPhieuDatHang();

        public UI_LapPhieuDatHang()
        {
            InitializeComponent();
            generateID();
            cbbNhaCungCap.ItemsSource = BUS_NhaCungCap.showData();
            txtTenNhanVien.Text = Properties.Settings.Default.TenNhanVien;
            dpNgayLap.SelectedDate = DateTime.Today.AddDays(0);
            dpNgayChinhSua.SelectedDate = DateTime.Today.AddDays(0);
            checkGroupCTPN(isNew = true, item);
        }

        public UI_LapPhieuDatHang(DTO_PhieuDatHang obj)
        {
            InitializeComponent();
            cbbNhaCungCap.ItemsSource = BUS_NhaCungCap.showData();
            getDataFromEditUI(obj);
            checkGroupCTPN(isNew = false, obj);
        }

        private void generateID()
        {
            txtMaPhieuDatHang.Text = BUS_PhieuDatHang.Instance.generateAutoID();
        }

        private void generateChiTietID()
        {
            txtMaChiTietPhieuDatHang.Text = BUS_ChiTietPhieuDatHang.Instance.generateAutoID();
        }

        private void checkGroupCTPN(bool isNew, DTO_PhieuDatHang phieuDatHang)
        {
            if (isNew)
                groupCTPN.IsEnabled = false;
            else
            {
                groupCTPN.IsEnabled = true;
                generateChiTietID();
                loadCombobox();
                dgvChiTietPhieuDat.ItemsSource = BUS_ChiTietPhieuDatHang.Instance.showByPhieuDatHang(item.MaPhieuDatHang);
            }
        }

        private void loadCombobox()
        {
            cbbTenHangHoa.ItemsSource = BUS_HangHoa.showDataDKD();
            cbbTenHangHoa.DisplayMemberPath = "TenHangHoa";
            cbbTenHangHoa.SelectedValuePath = "MaHangHoa";
        }

        private void getDataFromEditUI(DTO_PhieuDatHang obj)
        {
            txtMaPhieuDatHang.Text = obj.MaPhieuDatHang;
            dpNgayLap.SelectedDate = obj.NgayDat;
            dpNgayChinhSua.SelectedDate = obj.NgayChinhSua;
            cbbNhaCungCap.SelectedValue = obj.TenNhaCungCap;
            txtTenNhanVien.Text = obj.TenNhanVien;
            txtGhiChu.Text = obj.GhiChu;

            txtTongTien.Text = obj.TongTien.ToString();

            isNew = false;
        }

        private void btnThemChiTiet_Click(object sender, RoutedEventArgs e)
        {
            if (txtSoLuong.Text != "" && txtGiaNhap.Text != "" && cbbTenHangHoa.SelectedValue != null)
            {
                getDataFromCTPDH();

                if (BUS_ChiTietPhieuDatHang.Instance.Insert(itemCTPDH))
                {
                    MessageBox.Show("Thêm mới thành công!");
                    calTongTien();
                    clearCTPDH();
                    dgvChiTietPhieuDat.ItemsSource = BUS_ChiTietPhieuDatHang.Instance.showByPhieuDatHang(item.MaPhieuDatHang);
                }
                else MessageBox.Show("Thêm mới thất bại!");
            }
            else
            {
                MessageBox.Show("Hãy điền tất cả các ô còn trống!!!");
            }
        }

        private void getDataFromCTPDH()
        {
            itemCTPDH.MaChiTietPhieuDat = txtMaChiTietPhieuDatHang.Text;
            itemCTPDH.TenHangHoa = cbbTenHangHoa.Text;
            itemCTPDH.SoLuong = Int32.Parse(txtSoLuong.Text);
            itemCTPDH.Gia = decimal.Parse(txtGiaNhap.Text);
            itemCTPDH.MaPhieuDatHang = txtMaPhieuDatHang.Text;
            itemCTPDH.ThanhTien = itemCTPDH.SoLuong * itemCTPDH.Gia;
        }

        private void calTongTien(bool isDelete = false, decimal? thanhTienDelete = 0)
        {
            var tongTien = txtTongTien.Text;
            if (isDelete)
            {
                tongTien = (decimal.Parse(tongTien) - thanhTienDelete).ToString();
            }
            else if (tongTien != "")
            {
                tongTien = (decimal.Parse(tongTien) + itemCTPDH.ThanhTien).ToString();
            }
            else
            {
                tongTien = itemCTPDH.ThanhTien.ToString();
            }
            txtTongTien.Text = tongTien;
            item.TongTien = decimal.Parse(tongTien);
            BUS_PhieuDatHang.Instance.Update(item);
        }

        private void txtTongTien_TextChanged(object sender, TextChangedEventArgs e)
        {
            getDataFromUI();
        }

        private void btnLuu_Click(object sender, RoutedEventArgs e)
        {
            if (isNew == true)
            {
                if (dpNgayLap.SelectedDate != null
                     && cbbNhaCungCap.Text != "")
                {
                    getDataFromUI();

                    if (BUS_PhieuDatHang.Instance.Insert(item))
                    {
                        MessageBox.Show("Thêm mới thành công!");
                        checkGroupCTPN(isNew = false, item);
                    }
                    else MessageBox.Show("Thêm mới thất bại!");
                }
                else
                {
                    MessageBox.Show("Hãy điền tất cả các ô còn trống!!!");
                }
            }
            else
            {
                getDataFromUI();
                if (BUS_PhieuDatHang.Instance.Update(item))
                {
                    MessageBox.Show("Cập nhật thành công!");
                }
                else MessageBox.Show("Cập nhật thất bại!");
            }
        }

        private void getDataFromUI()
        {
            item.MaPhieuDatHang = txtMaPhieuDatHang.Text.Trim();
            item.NgayDat = dpNgayLap.SelectedDate.Value;
            item.NgayChinhSua = dpNgayChinhSua.SelectedDate.Value;
            item.TenNhaCungCap = cbbNhaCungCap.Text;
            item.TenNhanVien = txtTenNhanVien.Text.Trim();
            item.GhiChu = txtGhiChu.Text.Trim();
        }

        private void btnQuayLai_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = new UI_PhieuDatHang();
            UI_ManHinhChinh.gridMain.Children.Clear();
            UI_ManHinhChinh.gridMain.Children.Add(usc);
        }

        private void clearPDH()
        {
            generateID();
            cbbNhaCungCap.ItemsSource = BUS_NhaCungCap.showData();
            txtTenNhanVien.Text = Properties.Settings.Default.TenNhanVien;
            dpNgayLap.SelectedDate = DateTime.Today.AddDays(0);
            dpNgayChinhSua.SelectedDate = DateTime.Today.AddDays(0);
            cbbNhaCungCap.Text = "";
            txtGhiChu.Clear();
        }

        private void clearCTPDH()
        {
            generateChiTietID();
            cbbTenHangHoa.Text = "";
            txtSoLuong.Clear();
            txtGiaNhap.Clear();

            dgvChiTietPhieuDat.ItemsSource = null;
        }

        private void btnExportPDF_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            clearPDH();
            clearCTPDH();
            checkGroupCTPN(isNew = true, item);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Bạn có muốn xóa dòng này?", "Confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                if (dgvChiTietPhieuDat.SelectedItem != null)
                {
                    DTO_ChiTietPhieuDatHang obj = dgvChiTietPhieuDat.SelectedItem as DTO_ChiTietPhieuDatHang;
                    String id = obj.MaChiTietPhieuDat;

                    if (BUS_ChiTietPhieuDatHang.Instance.Delete(id))
                    {
                        dgvChiTietPhieuDat.ItemsSource = BUS_ChiTietPhieuDatHang.Instance.showByPhieuDatHang(item.MaPhieuDatHang);
                        calTongTien(true, obj.ThanhTien);
                    }              
                }
            }
        }
    }
}
