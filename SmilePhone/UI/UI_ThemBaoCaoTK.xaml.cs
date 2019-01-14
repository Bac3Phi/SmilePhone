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
using BUS;
using DTO;

namespace SmilePhone.UI
{
    /// <summary>
    /// Interaction logic for UI_ThemBaoCaoTK.xaml
    /// </summary>
    public partial class UI_ThemBaoCaoTK : UserControl
    {
        public Grid gridReport;
        private DTO_BaoCaoTonKho item = new DTO_BaoCaoTonKho();
        private bool isNew = false;
        public UI_ThemBaoCaoTK(Grid gridReport, DTO_BaoCaoTonKho obj)
        {
            InitializeComponent();
            this.gridReport = gridReport;

            List<int> month = new List<int>();
            for (int i = 1; i <= 12; i++)
                month.Add(i);

            List<int> year = new List<int>() { 2015, 2016, 2017, 2018, 2019, 2020 };

            cbbReportMonth.ItemsSource = month;
            cbbReportYear.ItemsSource = year;
            cbbGoodsName.ItemsSource = BUS_BaoCaoTonKho.showGoods();
            if (obj == null)
            {
                AutoGenerateID();
                isNew = true;
            }
            else
            {
                txtReportID.Text = obj.MaBaoCao;
                txtLastMount.Text = obj.SoLuongTonCuoi.ToString();
                cbbGoodsName.Text = obj.TenHangHoa;
                txtFirstMount.Text = obj.SoLuongTonDau.ToString();
                txtImportMount.Text = obj.SoLuongNhap.ToString();
                txtExportMount.Text = obj.SoLuongXuat.ToString();
                cbbReportMonth.Text = obj.Thang.ToString();
                cbbReportYear.Text = obj.Nam.ToString();
                isNew = false;
            }
        }

        private void btnQuayLai_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = new UI_BaoCaoTonKho(gridReport);
            gridReport.Children.Clear();
            gridReport.Children.Add(usc);
        }

        private void btnLuu_Click(object sender, RoutedEventArgs e)
        {
            if (txtReportID.Text != "")
            {
                item.MaBaoCao = txtReportID.Text.Trim();
                item.TenHangHoa = cbbGoodsName.Text;
                item.Thang = Int32.Parse(cbbReportMonth.Text);
                item.Nam = Int32.Parse(cbbReportYear.Text);
                item.SoLuongNhap = Int32.Parse(txtImportMount.Text);
                item.SoLuongXuat = Int32.Parse(txtExportMount.Text);
                item.SoLuongTonDau = Int32.Parse(txtFirstMount.Text);
                item.SoLuongTonCuoi = Int32.Parse(txtLastMount.Text);
            }

            if (isNew == true)
            {
                BUS_BaoCaoTonKho.Instance.Insert(item);
                AutoGenerateID();
                txtLastMount.Text = "";
                txtImportMount.Text = "";
                txtFirstMount.Text = "";
                txtLastMount.Text = "";
                cbbGoodsName.Text = "";
                cbbReportMonth.Text = "";
                cbbReportYear.Text = "";
                MessageBox.Show("Lập báo cáo thành công !");
            }
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            AutoGenerateID();
            txtLastMount.Text = "";
            txtFirstMount.Text = "";
            txtImportMount.Text = "";
            txtLastMount.Text = "";
            cbbGoodsName.Text = "";
            cbbReportMonth.Text = "";
            cbbReportYear.Text = "";
            isNew = true;
        }

        private void AutoGenerateID()
        {
            txtReportID.Text = BUS_BaoCaoTonKho.Instance.generateAutoID();
        }

        private void onChangeMount(object sender, SelectionChangedEventArgs e)
        {
            DTO_HangHoa goods = cbbGoodsName.SelectedItem as DTO_HangHoa;
            if (goods != null && cbbReportYear.Text != "" && cbbReportMonth.Text != "")
            {
                txtImportMount.Text = BUS_BaoCaoTonKho.getImport(goods.MaHangHoa, Int32.Parse(cbbReportMonth.Text), Int32.Parse(cbbReportYear.Text)).ToString();
                txtFirstMount.Text = BUS_BaoCaoTonKho.getFirstMount(goods.MaHangHoa).ToString();
                txtExportMount.Text = BUS_BaoCaoTonKho.getExport(goods.MaHangHoa, Int32.Parse(cbbReportMonth.Text), Int32.Parse(cbbReportYear.Text)).ToString();
                txtLastMount.Text = BUS_BaoCaoTonKho.getLastMount(goods.MaHangHoa, Int32.Parse(cbbReportMonth.Text), Int32.Parse(cbbReportYear.Text)).ToString();
            }
                //txtSumMoney.Text = BUS_PhieuChi.Instance.sumMoneyPC(phieuNhap.MaPhieuNhap).ToString();
        }
    }
}
