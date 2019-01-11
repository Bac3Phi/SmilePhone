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
using System.ComponentModel;

namespace SmilePhone.UI
{
    /// <summary>
    /// Interaction logic for UI_LapPhieuBanHang.xaml
    /// </summary>
    public partial class UI_LapPhieuBanHang : UserControl
    {
        private bool isNew = false;
        private DTO_PhieuBanHang item = new DTO_PhieuBanHang();
        private List<DTO_ChiTietPhieuBanHang> listHangHoa = new List<DTO_ChiTietPhieuBanHang>();
        private List<DTO_ChiTietPhieuBanHang> deleteList = new List<DTO_ChiTietPhieuBanHang>();

        public UI_LapPhieuBanHang()
        {
            InitializeComponent();
            generatePhieuBanHangID();
            dpNgayLap.SelectedDate = DateTime.Today;
            dpNgayChinhSua.SelectedDate = DateTime.Today;
            txtTenNhanVien.Text = Properties.Settings.Default.TenNhanVien;
            isNew = true;
            loadCombobox();
            dgvChiTietPhieuBanHang.ItemsSource = listHangHoa;
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
            loadCombobox();
            loadChiTiet(obj.MaPhieuBanHang);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var dpd = DependencyPropertyDescriptor.FromProperty(ItemsControl.ItemsSourceProperty, typeof(DataGrid));
            if (dpd != null)
            {
                dpd.AddValueChanged(dgvChiTietPhieuBanHang, ThisIsCalledWhenPropertyIsChanged);
            }

        }

        private void ThisIsCalledWhenPropertyIsChanged(object sender, EventArgs e)
        {
            if (listHangHoa.Count > 0)
            {
                decimal tongTien = 0;
                foreach (DTO_ChiTietPhieuBanHang item in listHangHoa)
                {
                    tongTien += (decimal)item.ThanhTien;
                }
                txtTongTien.Text = tongTien.ToString();
            }
            else txtTongTien.Text = "";
        }

        private void loadCombobox()
        {
            cbSanPham.ItemsSource = BUS_HangHoa.showData();
            cbSanPham.DisplayMemberPath = "TenHangHoa";
            cbSanPham.SelectedValuePath = "MaHangHoa";
        }

        private void loadChiTiet(string maPhieuBan)
        {
            listHangHoa = BUS_ChiTietPhieuBanHang.showData(maPhieuBan);
            dgvChiTietPhieuBanHang.ItemsSource = listHangHoa;
        }

        private void generatePhieuBanHangID()
        {
            txtMaPhieuBanHang.Text = BUS_PhieuBanHang.Instance.generateAutoID();
        }

        private string generateChiTietPhieuBanHangID()
        {
            return BUS_ChiTietPhieuBanHang.Instance.generateAutoID();
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
                        foreach (DTO_ChiTietPhieuBanHang item in listHangHoa)
                        {
                            item.MaChiTietPhieuBan = generateChiTietPhieuBanHangID();
                            if (!BUS_ChiTietPhieuBanHang.Instance.InsertCTPBH(item))
                            {
                                MessageBox.Show("Thêm mới thất bại!");
                                return;
                            }
                        }
                        MessageBox.Show("Thêm mới thành công!");
                        Refresh();
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
                if (dpNgayLap.SelectedDate != null && txtTenKhachHang.Text != ""
                    && txtSoDienThoai.Text != "")
                {
                    getDataFromUI();

                    if (BUS_PhieuBanHang.Instance.Update(item))
                    {
                        foreach (DTO_ChiTietPhieuBanHang item in listHangHoa)
                        {
                            if (item.MaChiTietPhieuBan == "")
                                item.MaChiTietPhieuBan = generateChiTietPhieuBanHangID();
                            if (!BUS_ChiTietPhieuBanHang.Instance.SaveOrUpdateCTPBH(item))
                            {
                                MessageBox.Show("Sửa thất bại!");
                                return;
                            }
                        }
                        foreach (DTO_ChiTietPhieuBanHang item in deleteList)
                        {
                            if (!BUS_ChiTietPhieuBanHang.Instance.Delete(item.MaChiTietPhieuBan))
                            {
                                MessageBox.Show("Sửa thất bại!");
                                return;
                            }
                        }
                        MessageBox.Show("Sửa thành công!");
                    }
                    else MessageBox.Show("Sửa thất bại!");
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
            Refresh();
        }

        private void Refresh()
        {
            generatePhieuBanHangID();
            dpNgayLap.SelectedDate = DateTime.Today;
            dpNgayChinhSua.SelectedDate = DateTime.Today;
            txtTenNhanVien.Text = Properties.Settings.Default.TenNhanVien;
            txtTenKhachHang.Text = "";
            txtSoDienThoai.Text = "";
            txtGhiChu.Text = "";
            txtTongTien.Text = "";
            isNew = true;
            cbSanPham.SelectedIndex = -1;
            txtSoLuong.Text = "";
            txtGiaNhap.Text = "";
            txtThanhTien.Text = "";
            listHangHoa.Clear();
            dgvChiTietPhieuBanHang.ItemsSource = null;
            btnUpdate.IsEnabled = false;
        }

        private void RefreshChiTiet()
        {
            cbSanPham.SelectedIndex = -1;
            txtSoLuong.Text = "";
            txtGiaNhap.Text = "";
            txtThanhTien.Text = "";
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Bạn có muốn xóa dòng này?", "Confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                if (dgvChiTietPhieuBanHang.SelectedItem != null)
                {
                    DTO_ChiTietPhieuBanHang obj = dgvChiTietPhieuBanHang.SelectedItem as DTO_ChiTietPhieuBanHang;
                    listHangHoa.Remove(obj);
                    deleteList.Add(obj);
                    dgvChiTietPhieuBanHang.ItemsSource = null;
                    dgvChiTietPhieuBanHang.ItemsSource = listHangHoa;
                }
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (checkContain(cbSanPham.SelectedValue.ToString()))
            {
                var obj = listHangHoa.Find(item => item.MaHangHoa == cbSanPham.SelectedValue.ToString());
                obj.SoLuong += int.Parse(txtSoLuong.Text);
                obj.ThanhTien += decimal.Parse(txtThanhTien.Text);
            }
            else
            {
                listHangHoa.Add(new DTO_ChiTietPhieuBanHang(
                                txtMaPhieuBanHang.Text,
                                cbSanPham.SelectedValue.ToString(),
                                cbSanPham.Text,
                                int.Parse(txtSoLuong.Text),
                                decimal.Parse(txtGiaNhap.Text),
                                decimal.Parse(txtThanhTien.Text),
                                ""));
            }           
            dgvChiTietPhieuBanHang.ItemsSource = null;
            dgvChiTietPhieuBanHang.ItemsSource = listHangHoa;
            RefreshChiTiet();
        }

        private bool checkContain(string maHangHoa)
        {
            foreach (DTO_ChiTietPhieuBanHang item in listHangHoa)
            {
                if (item.MaHangHoa.Equals(maHangHoa))
                    return true;      
            }
            return false;
        }

        private void CbSanPham_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnUpdate.IsEnabled = false;
            if (cbSanPham.SelectedValue != null)
            {
                txtGiaNhap.Text = BUS_HangHoa.Instance.getGiaBan(cbSanPham.SelectedValue.ToString()).ToString();
                TinhTongTien();
            }          
        }

        private void TinhTongTien()
        {
            if (txtSoLuong.Text != "" && txtGiaNhap.Text != "")
            {
                var tongTien = decimal.Parse(txtGiaNhap.Text) * decimal.Parse(txtSoLuong.Text);
                txtThanhTien.Text = tongTien.ToString();
            }          
        }

        private void TxtSoLuong_TextChanged(object sender, TextChangedEventArgs e)
        {
            TinhTongTien();
        }

        private void DgvChiTietPhieuBanHang_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DTO_ChiTietPhieuBanHang chiTietPhieuBanHang = dgvChiTietPhieuBanHang.SelectedItem as DTO_ChiTietPhieuBanHang;
            if (chiTietPhieuBanHang != null)
            {
                cbSanPham.SelectedValue = chiTietPhieuBanHang.MaHangHoa;

                txtSoLuong.Text = chiTietPhieuBanHang.SoLuong.ToString();
                txtGiaNhap.Text = chiTietPhieuBanHang.Gia.ToString();
                txtThanhTien.Text = chiTietPhieuBanHang.ThanhTien.ToString();

                btnUpdate.IsEnabled = true;
            }
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            DTO_ChiTietPhieuBanHang obj = listHangHoa.FirstOrDefault(x => x.MaHangHoa == cbSanPham.SelectedValue.ToString());
            if (obj != null)
            {
                obj.SoLuong = int.Parse(txtSoLuong.Text);
                obj.ThanhTien = decimal.Parse(txtThanhTien.Text);
            }
            dgvChiTietPhieuBanHang.ItemsSource = null;
            dgvChiTietPhieuBanHang.ItemsSource = listHangHoa;
            RefreshChiTiet();
        }
    }
}
