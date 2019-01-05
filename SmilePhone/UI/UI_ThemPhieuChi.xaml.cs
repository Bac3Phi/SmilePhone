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
using SmilePhone.CrystalReports;

namespace SmilePhone.UI
{
    /// <summary>
    /// Interaction logic for UI_ThemPhieuChi.xaml
    /// </summary>
    public partial class UI_ThemPhieuChi : UserControl
    {
        private Grid gridMain;
        private bool isNew = false;
        private DTO_PhieuChi item = new DTO_PhieuChi();

        public UI_ThemPhieuChi(Grid gridMain, DTO_PhieuChi obj)
        {
            InitializeComponent();
            this.gridMain = gridMain;
            if (obj == null)
            {
                AutoGenerateID();
                dpReceiptEditDate.SelectedDate = DateTime.Today;
                dpReceiptDate.SelectedDate = DateTime.Today;
                txtEmployeeName.Text = Properties.Settings.Default.TenNhanVien;
                isNew = true;
            }
            else
            {
                txtReceiptID.Text = obj.MaPhieuChi;
                txtEmployeeName.Text = obj.TenNhanVien;
                cbbImportID.Text = obj.MaPhieuNhap;
                txtReceiptNote.Text = obj.GhiChu;
                txtSumMoney.Text = BUS_PhieuChi.Instance.sumMoneyPC(obj.MaPhieuNhap).ToString();
                dpReceiptDate.SelectedDate = obj.NgayChi;
                dpReceiptEditDate.SelectedDate = obj.NgayChinhSua;
                isNew = false;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cbbImportID.ItemsSource = BUS_PhieuChi.Instance.showPN();
        }

        private void AutoGenerateID()
        {
            txtReceiptID.Text = BUS_PhieuChi.Instance.generateAutoID();
        }

        private void btnLuu_Click(object sender, RoutedEventArgs e)
        {
            if (isNew == true)
            {                
                if (txtSumMoney.Text != "" && dpReceiptDate.SelectedDate != null
                    && txtReceiptID.Text != "" && cbbImportID.Text != "" && txtEmployeeName.Text != "")
                {
                    item.MaPhieuChi = txtReceiptID.Text.Trim();
                    item.NgayChi = dpReceiptDate.SelectedDate.Value;
                    item.NgayChinhSua = dpReceiptEditDate.SelectedDate.Value;
                    item.TongTienChi = decimal.Parse(txtSumMoney.Text);
                    item.MaPhieuNhap = cbbImportID.Text;
                    item.TenNhanVien = txtEmployeeName.Text;
                    item.GhiChu = txtReceiptNote.Text.Trim();

                    BUS_PhieuChi.Instance.InsertPC(item);
                    AutoGenerateID();
                    txtEmployeeName.Text = "";
                    cbbImportID.Text = "";
                    txtReceiptNote.Clear();
                    txtSumMoney.Clear();
                    dpReceiptDate.SelectedDate = null;
                    dpReceiptEditDate.SelectedDate = null;
                    MessageBox.Show("Thêm mới thành công!");
                }
                else
                {
                    MessageBox.Show("Hãy điền tất cả các ô còn trống!!!");
                }
            }
            else
            {                
                if (txtSumMoney.Text != "" && dpReceiptDate.SelectedDate.Value != null
                    && txtReceiptID.Text != "" && cbbImportID.Text != "" && txtEmployeeName.Text != "")
                {
                    item.MaPhieuChi = txtReceiptID.Text.Trim();
                    item.NgayChi = dpReceiptDate.SelectedDate.Value;
                    item.NgayChinhSua = dpReceiptEditDate.SelectedDate.Value;
                    item.TongTienChi = decimal.Parse(txtSumMoney.Text);
                    item.MaPhieuNhap = cbbImportID.Text;
                    item.TenNhanVien = txtEmployeeName.Text;
                    item.GhiChu = txtReceiptNote.Text.Trim();

                    BUS_PhieuChi.Instance.UpdatePC(item);
                    AutoGenerateID();
                    txtEmployeeName.Text = "";
                    cbbImportID.Text = "";
                    txtReceiptNote.Clear();
                    txtSumMoney.Clear();
                    dpReceiptDate.SelectedDate = null;
                    dpReceiptEditDate.SelectedDate = null;
                    MessageBox.Show("Cập nhật nhân viên thành công!");
                }
                else
                {
                    MessageBox.Show("Hãy điền tất cả các ô còn trống!!!");
                }
            }
        }

        private void btnQuayLai_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = new UI_PhieuChi(gridMain);
            gridMain.Children.Clear();
            gridMain.Children.Add(usc);
        }

        private void btnExportPDF_Click(object sender, RoutedEventArgs e)
        {
            if (txtSumMoney.Text != "" && dpReceiptDate.SelectedDate.Value != null
                    && txtReceiptID.Text != "" && cbbImportID.Text != "" && txtEmployeeName.Text != "")
            {
                item.MaPhieuChi = txtReceiptID.Text.Trim();
                item.NgayChi = dpReceiptDate.SelectedDate.Value;
                item.NgayChinhSua = dpReceiptEditDate.SelectedDate.Value;
                item.TongTienChi = decimal.Parse(txtSumMoney.Text);
                item.MaPhieuNhap = cbbImportID.Text;
                item.TenNhanVien = txtEmployeeName.Text;
                item.GhiChu = txtReceiptNote.Text.Trim();

                UserControl usc = new PrintForm_PhieuChi(gridMain, item);
                gridMain.Children.Clear();
                gridMain.Children.Add(usc);
            }
            else
            {
                MessageBox.Show("Hãy điền tất cả các ô còn trống!!!");
            }
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            txtReceiptID.Clear();
            txtEmployeeName.Text = Properties.Settings.Default.TenNhanVien;
            cbbImportID.Text = "";
            txtReceiptNote.Clear();
            txtSumMoney.Clear();
            dpReceiptDate.SelectedDate = DateTime.Today;
            dpReceiptEditDate.SelectedDate = DateTime.Today;
            isNew = true;
            AutoGenerateID();
        }

        private void onChangeMoney(object sender, SelectionChangedEventArgs e)
        {
            DTO_NhapChi phieuNhap = cbbImportID.SelectedItem as DTO_NhapChi;
            if (phieuNhap != null)
                txtSumMoney.Text = BUS_PhieuChi.Instance.sumMoneyPC(phieuNhap.MaPhieuNhap).ToString();
        }
    }
}
