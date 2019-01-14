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
using SmilePhone.Validations;

namespace SmilePhone.UI
{
    /// <summary>
    /// Interaction logic for UI_ThemHangHoa.xaml
    /// </summary>
    public partial class UI_ThemHangHoa : UserControl
    {
        private String strMaHangHoa;
        private bool isNew = false;
        private DTO_HangHoa item = new DTO_HangHoa();
        private int iSoLuongTon;
        private bool bTrangThai;

        public UI_ThemHangHoa()
        {
            InitializeComponent();
            DataContext = new TextFieldsViewModel();
            generateHangHoaID();
            isNew = true;
            loadCombobox();
        }

        public UI_ThemHangHoa(DTO_HangHoa obj)
        {
            InitializeComponent();
            strMaHangHoa = obj.MaHangHoa;
            txtTenHangHoa.Text = obj.TenHangHoa;
            txtTenModel.Text = obj.TenModel;
            txtGiaBan.Text = obj.GiaBan.ToString();
            txtGiamGia.Text = obj.GiamGia.ToString();
            txtDonViTinh.Text = obj.DonViTinh;
            txtMoTa.Text = obj.MoTa;
            txtXuatXu.Text = obj.XuatXu;
            txtThoiGianBaoHanh.Text = obj.ThoiGianBaoHang.ToString();
            txtThongSoKiThuat.Text = obj.ThongSoKyThuat;
            iSoLuongTon = (int) obj.SoLuongTon;
            bTrangThai = (bool) obj.TrangThai;
            isNew = false;
            loadCombobox();
            foreach (DTO_LoaiHangHoa item in BUS_LoaiHangHoa.showData())
            {
                if (item.TenLoaiHangHoa.Equals(obj.TenLoaiHangHoa))
                {
                    cbLoaiHangHoa.SelectedValue = item.MaLoaiHangHoa;
                    break;
                }                   
            }
        }

        private void loadCombobox()
        {
            cbLoaiHangHoa.ItemsSource = BUS_LoaiHangHoa.showData();
            cbLoaiHangHoa.DisplayMemberPath = "TenLoaiHangHoa";
            cbLoaiHangHoa.SelectedValuePath = "MaLoaiHangHoa";

            cbLoaiHangHoa.SelectedIndex = 0;
        }

        private void generateHangHoaID()
        {
            strMaHangHoa = BUS_HangHoa.Instance.generateAutoID();
        }

        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            refresh();
        }

        private void refresh()
        {
            txtTenHangHoa.Text = "";
            txtTenModel.Text = "";
            txtGiaBan.Text = "";
            txtGiamGia.Text = "";
            txtDonViTinh.Text = "";
            txtMoTa.Text = "";
            txtXuatXu.Text = "";
            txtThoiGianBaoHanh.Text = "";
            txtThongSoKiThuat.Text = "";
            loadCombobox();
            generateHangHoaID();
            isNew = true;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (isHasError())
            {
                MessageBox.Show("Vui lòng điền đầy đủ chính xác thông tin!");
                return;
            }
            if (isNew == true)
            {
                if (txtTenHangHoa.Text != "" && txtTenModel.Text != ""
                    && txtGiaBan.Text != "" && txtGiamGia.Text != ""
                    && txtDonViTinh.Text != "" && txtMoTa.Text != ""
                    && txtXuatXu.Text != "" && txtThoiGianBaoHanh.Text != ""
                    && txtThongSoKiThuat.Text != "")
                {
                    item.SoLuongTon = 0;
                    item.TrangThai = true;
                    getDataFromUI();

                    if (BUS_HangHoa.Instance.Insert(item))
                    {
                        MessageBox.Show("Thêm mới thành công!");
                        refresh();
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
                if (txtTenHangHoa.Text != "" && txtTenModel.Text != ""
                    && txtGiaBan.Text != "" && txtGiamGia.Text != ""
                    && txtDonViTinh.Text != "" && txtMoTa.Text != ""
                    && txtXuatXu.Text != "" && txtThoiGianBaoHanh.Text != ""
                    && txtThongSoKiThuat.Text != "")
                {
                    getDataFromUI();

                    if (BUS_HangHoa.Instance.Update(item))
                    {
                        MessageBox.Show("Lưu thành công!");
                        refresh();
                    }
                    else MessageBox.Show("Lưu thất bại!");
                }
                else
                {
                    MessageBox.Show("Hãy điền tất cả các ô còn trống!!!");
                }
            }
        }

        private void getDataFromUI()
        {
            item.MaHangHoa = strMaHangHoa;
            item.TenHangHoa = txtTenHangHoa.Text.Trim();
            item.GiaBan = decimal.Parse(txtGiaBan.Text.Trim());
            item.GiamGia = decimal.Parse(txtGiamGia.Text.Trim());
            item.DonViTinh = txtDonViTinh.Text.Trim();
            item.MoTa = txtMoTa.Text.Trim();
            item.XuatXu = txtXuatXu.Text.Trim();
            item.ThongSoKyThuat = txtThongSoKiThuat.Text.Trim();
            item.ThoiGianBaoHang = int.Parse(txtThoiGianBaoHanh.Text.Trim());
            //item.HinhAnh = txtXuatXu.Text.Trim();
            item.TenLoaiHangHoa = cbLoaiHangHoa.Text;
            item.TenModel = txtTenModel.Text.Trim();
            item.SoLuongTon = iSoLuongTon;
            item.TrangThai = bTrangThai;
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = new UI_HangHoa();
            UI_ManHinhChinh.gridMain.Children.Clear();
            UI_ManHinhChinh.gridMain.Children.Add(usc);
        }

        private void BtnChonHinhAnh_Click(object sender, RoutedEventArgs e)
        {

        }
        private Boolean isHasError()
        {
            if (Validation.GetHasError(txtTenHangHoa) == true
                || Validation.GetHasError(txtTenModel) == true
                || Validation.GetHasError(txtGiaBan) == true
                || Validation.GetHasError(txtGiamGia) == true
                || Validation.GetHasError(txtDonViTinh) == true
                || Validation.GetHasError(txtXuatXu) == true
                || Validation.GetHasError(txtThoiGianBaoHanh) == true)
                return true;
            else
                return false;
        }

    }
}
