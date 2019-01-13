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
        private DTO_ChiTietPhieuNhap itemCTPN = new DTO_ChiTietPhieuNhap();

        public UI_LapPhieuDatHang()
        {
            InitializeComponent();
            generateID();
            dpNgayLap.SelectedDate = DateTime.Today.AddDays(0);
            dpNgayChinhSua.SelectedDate = DateTime.Today.AddDays(0);
            checkGroupCTPN(isNew = true, item);
        }

        public UI_LapPhieuDatHang(DTO_PhieuDatHang obj)
        {
            InitializeComponent();
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
                //cbbTenHangHoa.SelectedValue = "Tai nghe Apple EarPods Lightning";
                //cbbTenHangHoa.Text = "Tai nghe Apple EarPods Lightning";
                //dgvChiTietPhieuNhap.ItemsSource = BUS_ChiTietPhieuNhap.showDataByPhieuNhap(phieunhap.MaPhieuNhap);
            }
        }

        private void getDataFromEditUI(DTO_PhieuDatHang obj)
        {
            txtMaPhieuDatHang.Text = obj.MaPhieuDatHang;
            dpNgayLap.SelectedDate = obj.NgayDat;
            dpNgayChinhSua.SelectedDate = obj.NgayChinhSua;
            cbbNhaCungCap.Text = obj.TenNhaCungCap;
            txtTenNhanVien.Text = obj.TenNhanVien;
            txtGhiChu.Text = obj.GhiChu;

            txtTongTien.Text = obj.TongTien.ToString();

            isNew = false;
        }

        private void btnThemChiTiet_Click(object sender, RoutedEventArgs e)
        {

        }

        private void txtTongTien_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnLuu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnQuayLai_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = new UI_PhieuDatHang();
            UI_ManHinhChinh.gridMain.Children.Clear();
            UI_ManHinhChinh.gridMain.Children.Add(usc);
        }

        private void btnExportPDF_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
