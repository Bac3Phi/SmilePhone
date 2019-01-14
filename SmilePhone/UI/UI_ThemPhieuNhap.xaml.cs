using BUS;
using DTO;
using SmilePhone.Validations;
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
    /// Interaction logic for UI_ThemPhieuNhap.xaml
    /// </summary>
    public partial class UI_ThemPhieuNhap : UserControl
    {
        private Grid gridMain;
        private bool isNew = false;
        private DTO_PhieuNhap item = new DTO_PhieuNhap();
        private DTO_ChiTietPhieuNhap itemCTPN = new DTO_ChiTietPhieuNhap();
        public UI_ThemPhieuNhap(Grid gridMain, DTO_PhieuNhap obj)
        {
            InitializeComponent();
            DataContext = new TextFieldsViewModel();
            this.gridMain = gridMain;
            if (obj == null)
            {
                generatePhieuNhapID();
                checkGroupCTPN(isNew = true, item);
            }
            else
            {
                getDataFromEditUI(obj);
                checkGroupCTPN(isNew = false, obj);
            }
        }

        private void generatePhieuNhapID()
        {
            txtMaPhieuNhap.Text = BUS_PhieuNhap.Instance.generateAutoID();
        }
        private void generateChiTietPhieuNhapID()
        {
            txtMaChiTietPhieuNhap.Text = BUS_ChiTietPhieuNhap.Instance.generateAutoID();
        }
        private void checkGroupCTPN(bool isNew, DTO_PhieuNhap phieunhap)
        {
            if (isNew)
                groupCTPN.IsEnabled = false;
            else
            {
                groupCTPN.IsEnabled = true;
                generateChiTietPhieuNhapID();
                loadCombobox();
                dgvChiTietPhieuNhap.ItemsSource = BUS_ChiTietPhieuNhap.showDataByPhieuNhap(phieunhap.MaPhieuNhap);
            }
        }

        private void loadCombobox()
        {
            cbbTenHangHoa.ItemsSource = BUS_HangHoa.showDataDKD();
            cbbTenHangHoa.DisplayMemberPath = "TenHangHoa";
            cbbTenHangHoa.SelectedValuePath = "MaHangHoa";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cbbNhaCungCap.ItemsSource = BUS_NhaCungCap.showData();
            txtTenNhanVien.Text = Properties.Settings.Default.TenNhanVien;
            dpNgayLap.SelectedDate = DateTime.Today.AddDays(0);
            dpNgayChinhSua.SelectedDate = DateTime.Today.AddDays(0);

        }

        private void btnQuayLai_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = new UI_PhieuNhap(gridMain);
            gridMain.Children.Clear();
            gridMain.Children.Add(usc);
        }

        private void btnExportPDF_Click(object sender, RoutedEventArgs e)
        {
            //if (txtSumMoney.Text != "" && dpReceiptDate.SelectedDate.Value != null
            //        && txtReceiptID.Text != "" && cbbImportID.Text != "" && cbbEmployeeName.Text != "")
            //{
            //    item.MaPhieuChi = txtReceiptID.Text.Trim();
            //    item.NgayChi = dpReceiptDate.SelectedDate.Value;
            //    item.NgayChinhSua = dpReceiptEditDate.SelectedDate.Value;
            //    item.TongTienChi = decimal.Parse(txtSumMoney.Text);
            //    item.MaPhieuNhap = cbbImportID.Text;
            //    item.TenNhanVien = cbbEmployeeName.Text;
            //    item.GhiChu = txtReceiptNote.Text.Trim();

            //    UserControl usc = new PrintForm_PhieuChi(gridMain, item);
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
            clearPN();
            clearCTPN();
            checkGroupCTPN(isNew = true, item);
        }
        private void btnLuu_Click(object sender, RoutedEventArgs e)
        {
            if (isHasError())
            {
                MessageBox.Show("Vui lòng điền đầy đủ chính xác thông tin!");
                return;
            }
            if (isNew == true)
            {
                getDataFromUI();

                BUS_PhieuNhap.Instance.Insert(item);
                MessageBox.Show("Thêm mới thành công!");
                checkGroupCTPN(isNew = false, item);
            }
            else
            {
                getDataFromUI();
                BUS_PhieuNhap.Instance.Update(item);
                MessageBox.Show("Cập nhật thành công!");
            }
        }

        private void getDataFromUI()
        {
            item.MaPhieuNhap = txtMaPhieuNhap.Text.Trim();
            item.NgayNhap = dpNgayLap.SelectedDate.Value;
            item.NgayChinhSua = dpNgayChinhSua.SelectedDate.Value;
            item.TenNhaCungCap = cbbNhaCungCap.Text;
            item.TenNhanVien = txtTenNhanVien.Text.Trim();
            item.GhiChu = txtGhiChu.Text.Trim();
        }

        private void getDataFromEditUI(DTO_PhieuNhap obj)
        {
            txtMaPhieuNhap.Text = obj.MaPhieuNhap;
            dpNgayLap.SelectedDate = obj.NgayNhap;
            dpNgayChinhSua.SelectedDate = obj.NgayChinhSua;
            cbbNhaCungCap.Text = obj.TenNhaCungCap;
            txtTenNhanVien.Text = obj.TenNhanVien;
            txtGhiChu.Text = obj.GhiChu;

            txtTongTien.Text = obj.TongTien.ToString();
            
            isNew = false;
        }

        private void getDataFromCTPN()
        {
            itemCTPN.MaChiTietPhieuNhap = txtMaChiTietPhieuNhap.Text;
            itemCTPN.TenHangHoa = cbbTenHangHoa.Text;
            itemCTPN.SoLuong = Int32.Parse(txtSoLuong.Text);
            itemCTPN.GiaNhap = decimal.Parse(txtGiaNhap.Text);
            itemCTPN.MaPhieuNhap = txtMaPhieuNhap.Text;
            itemCTPN.ThanhTien = itemCTPN.SoLuong * itemCTPN.GiaNhap;
        }

        private void calTongTien(bool isDelete = false, decimal? thanhTienDelete = 0 )
        {
            var tongTien = txtTongTien.Text;
            if (isDelete)
            {
                tongTien = (decimal.Parse(tongTien) - thanhTienDelete).ToString();
            }
            else if (tongTien != "")
            {
                tongTien = (decimal.Parse(tongTien) + itemCTPN.ThanhTien).ToString();
            }
            else
            {
                tongTien = itemCTPN.ThanhTien.ToString();
            }
            txtTongTien.Text = tongTien;
            item.TongTien = decimal.Parse(tongTien);
            BUS_PhieuNhap.Instance.Update(item);
        }

        private void calSoLuongNhap(bool isDelete = false)
        {
            var soLuong = BUS_HangHoa.Instance.getSoLuong(itemCTPN.TenHangHoa);
            if (isDelete)
            {
                soLuong = soLuong - (int)itemCTPN.SoLuong;
            }
            else
            {
                soLuong = soLuong + (int)itemCTPN.SoLuong;
            }

            var hangHoa = new DTO_HangHoa();
            hangHoa.TenHangHoa = itemCTPN.TenHangHoa;
            hangHoa.SoLuongTon = soLuong;
            BUS_HangHoa.Instance.UpdateSoLuong(hangHoa);

        }
        private void clearPN()
        {
            generatePhieuNhapID();
            cbbNhaCungCap.ItemsSource = BUS_NhaCungCap.showData();
            txtTenNhanVien.Text = Properties.Settings.Default.TenNhanVien;
            dpNgayLap.SelectedDate = DateTime.Today.AddDays(0);
            dpNgayChinhSua.SelectedDate = DateTime.Today.AddDays(0);
            cbbNhaCungCap.Text = "";
            txtGhiChu.Clear();
        }

        private void clearCTPN()
        {
            generateChiTietPhieuNhapID();
            cbbTenHangHoa.Text = "";
            txtSoLuong.Clear();
            txtGiaNhap.Clear();

            dgvChiTietPhieuNhap.ItemsSource = BUS_ChiTietPhieuNhap.showDataByPhieuNhap(item.MaPhieuNhap);
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Bạn có muốn xóa dòng này?", "Confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                if (dgvChiTietPhieuNhap.SelectedItem != null)
                {
                    DTO_ChiTietPhieuNhap obj = dgvChiTietPhieuNhap.SelectedItem as DTO_ChiTietPhieuNhap;
                    String id = obj.MaChiTietPhieuNhap;

                    BUS_ChiTietPhieuNhap.Delete(id);
                    dgvChiTietPhieuNhap.ItemsSource = BUS_ChiTietPhieuNhap.showDataByPhieuNhap(item.MaPhieuNhap);
                    calTongTien(true, obj.ThanhTien);
                    calSoLuongNhap(true);
                }
            }
        }
        private void btnThemChiTiet_Click(object sender, RoutedEventArgs e)
        {
            if(cbbTenHangHoa.SelectedValue != null)
            {
                getDataFromCTPN();

                BUS_ChiTietPhieuNhap.Instance.Insert(itemCTPN);
                MessageBox.Show("Thêm mới thành công!");
                calTongTien();
                calSoLuongNhap();
                clearCTPN();
            }
            else
            {
                MessageBox.Show("Hãy điền tất cả các ô còn trống!!!");
            }
        }

        private void txtTongTien_TextChanged(object sender, TextChangedEventArgs e)
        {
            getDataFromUI();
        }
        private Boolean isHasError()
        {
            if (Validation.GetHasError(txtSoLuong) == true
                || Validation.GetHasError(txtGiaNhap) == true)
                return true;
            else
                return false;
        }
    }
}
