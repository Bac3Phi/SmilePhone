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
using CrystalDecisions.CrystalReports.Engine;
using DTO;
using BUS;
using SmilePhone.UI;

namespace SmilePhone.CrystalReports
{
    /// <summary>
    /// Interaction logic for PrintForm_PhieuChi.xaml
    /// </summary>
    public partial class PrintForm_PhieuChi : UserControl
    {
        private DTO_PhieuChi phieuChi = new DTO_PhieuChi();
        private rptReceiptForm report = new rptReceiptForm();
        private Grid gridMain;

        public PrintForm_PhieuChi(Grid gridMain, DTO_PhieuChi obj)
        {
            InitializeComponent();
            this.gridMain = gridMain;
            this.phieuChi = obj;

            report.SetParameterValue("pID", phieuChi.MaPhieuChi);
            report.SetParameterValue("pDate", phieuChi.NgayChi);
            report.SetParameterValue("pEditDate", phieuChi.NgayChinhSua);
            report.SetParameterValue("pEmployeeName", phieuChi.TenNhanVien);
            report.SetParameterValue("pImportID", phieuChi.MaPhieuNhap);
            report.SetParameterValue("pNote", phieuChi.GhiChu);
            report.SetParameterValue("pSumMoney", phieuChi.TongTienChi);

            reportViewer.ViewerCore.ReportSource = report;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //report.Load(@"rptReceiptForm.rep");

            //report.SetDataSource(this.phieuChi);
            
        }

        private void btnQuayLai_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = new UI_ThemPhieuChi(gridMain, phieuChi);
            gridMain.Children.Clear();
            gridMain.Children.Add(usc);
        }
    }
}
