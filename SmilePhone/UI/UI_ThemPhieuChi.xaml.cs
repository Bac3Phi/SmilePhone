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
using DAL;
using BUS;
using DTO;

namespace SmilePhone.UI
{
    /// <summary>
    /// Interaction logic for UI_ThemPhieuChi.xaml
    /// </summary>
    public partial class UI_ThemPhieuChi : UserControl
    {
        private Grid gridMain;
        private bool isNew = false;
        private PhieuChi item = new PhieuChi();

        public UI_ThemPhieuChi(Grid gridMain, DTO_PhieuChi obj)
        {
            InitializeComponent();
            this.gridMain = gridMain;
            if (obj == null)
            {
                AutoGenerateID();
                isNew = true;
            }
            else
            {
                txtReceiptID.Text = obj.MaPhieuChi;
                cbbEmployeeName.Text = obj.TenNhanVien;
                txtImportID.Text = obj.MaPhieuNhap;
                txtReceiptNote.Text = obj.GhiChu;
                txtSumMoney.Text = obj.TongTienChi.ToString();
                isNew = false;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cbbEmployeeName.ItemsSource = BUS_NhanVien.showData();
        }

        private void AutoGenerateID()
        {
            txtReceiptID.Text = BUS_PhieuChi.Instance.generateAutoID();
        }

        private void btnLuu_Click(object sender, RoutedEventArgs e)
        {
            //if (isNew == true)
            //{
            //    item.MaNhanVien = txtEmployeesID.Text.Trim();
            //    item.TenNhanVien = txtEmployeesName.Text.Trim();
            //    item.UserName = txtEmployeesUserName.Text.Trim();
            //    item.Password = txtEmployeesPass.Text.Trim();
            //    item.MaPhanQuyen = "";

            //    String pqName = cbbPermissionName.Text;
            //    if (txtEmployeesName.Text != "" && txtEmployeesPass.Text != ""
            //        && txtEmployeesUserName.Text != "" && pqName != "")
            //    {
            //        BUS_NhanVien.Instance.InsertNV(item, pqName);
            //        AutoGenerateID();
            //        txtEmployeesName.Clear();
            //        txtEmployeesPass.Clear();
            //        txtEmployeesUserName.Clear();
            //        cbbPermissionName.SelectedIndex = 0;
            //        MessageBox.Show("Thêm mới thành công!");
            //    }
            //    else
            //    {
            //        MessageBox.Show("Hãy điền tất cả các ô còn trống!!!");
            //    }
            //}
            //else
            //{
            //    item.MaNhanVien = txtEmployeesID.Text.Trim();
            //    item.TenNhanVien = txtEmployeesName.Text.Trim();
            //    item.UserName = txtEmployeesUserName.Text.Trim();
            //    item.Password = txtEmployeesPass.Text.Trim();
            //    item.MaPhanQuyen = "";

            //    String pqName = cbbPermissionName.Text;
            //    if (txtEmployeesName.Text != "" && txtEmployeesPass.Text != ""
            //        && txtEmployeesUserName.Text != "" && pqName != "")
            //    {
            //        BUS_NhanVien.Instance.UpdateNV(item, pqName);
            //        AutoGenerateID();
            //        txtEmployeesName.Clear();
            //        txtEmployeesPass.Clear();
            //        txtEmployeesUserName.Clear();
            //        cbbPermissionName.SelectedIndex = 0;
            //        MessageBox.Show("Cập nhật nhân viên thành công!");
            //    }
            //    else
            //    {
            //        MessageBox.Show("Hãy điền tất cả các ô còn trống!!!");
            //    }
            //}
        }

        private void btnQuayLai_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = new UI_PhieuChi(gridMain);
            gridMain.Children.Clear();
            gridMain.Children.Add(usc);
        }

        private void btnExportPDF_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = new UI_PhieuChi(gridMain);
            gridMain.Children.Clear();
            gridMain.Children.Add(usc);
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            txtReceiptID.Clear();
            cbbEmployeeName.Text = "";
            txtImportID.Clear();
            txtReceiptNote.Clear();
            txtSumMoney.Clear();
            dpReceiptDate.SelectedDate = null;
            dpReceiptEditDate.SelectedDate = null;
            isNew = true;
            AutoGenerateID();
        }
    }
}
