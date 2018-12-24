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

namespace SmilePhone.UI
{
    /// <summary>
    /// Interaction logic for UI_ThemNhanVien.xaml
    /// </summary>
    public partial class UI_ThemNhanVien : UserControl
    {
        private Grid gridMain;
        private bool isNew = false;
        private NhanVien item = new NhanVien();

        public UI_ThemNhanVien(Grid gridMain, dynamic obj)
        {
            InitializeComponent();
            this.gridMain = gridMain;
            cbbPermissionName.ItemsSource = BUS_PhanQuyen.showData();
            cbbPermissionName.SelectedIndex = 0;
            if (obj == null)
            {
                AutoGenerateID();
                isNew = true;
            }
            else
            {
                Type t = obj.GetType();
                txtEmployeesID.Text = t.GetProperty("MaNhanVien").GetValue(obj, null);
                txtEmployeesName.Text = t.GetProperty("TenNhanVien").GetValue(obj, null);
                txtEmployeesUserName.Text = t.GetProperty("UserName").GetValue(obj, null);
                txtEmployeesPass.Text = t.GetProperty("Password").GetValue(obj, null);
                cbbPermissionName.Text = t.GetProperty("TenPhanQuyen").GetValue(obj, null);
                isNew = false;
            }
        }

        private void AutoGenerateID()
        {
            txtEmployeesID.Text = BUS_NhanVien.Instance.generateAutoID();
        }

        private void btnLuu_Click(object sender, RoutedEventArgs e)
        {
            if (isNew == true)
            {
                item.MaNhanVien = txtEmployeesID.Text.Trim();
                item.TenNhanVien = txtEmployeesName.Text.Trim();
                item.UserName = txtEmployeesUserName.Text.Trim();
                item.Password = txtEmployeesPass.Text.Trim();
                item.MaPhanQuyen = "";

                String pqName = cbbPermissionName.Text;
                if (txtEmployeesName.Text != "" && txtEmployeesPass.Text != ""
                    && txtEmployeesUserName.Text != "" && pqName != "")
                {
                    BUS_NhanVien.Instance.InsertNV(item, pqName);
                    AutoGenerateID();
                    txtEmployeesName.Clear();
                    txtEmployeesPass.Clear();
                    txtEmployeesUserName.Clear();
                    cbbPermissionName.SelectedIndex = 0;
                    MessageBox.Show("Thêm mới thành công!");
                }
                else
                {
                    MessageBox.Show("Hãy điền tất cả các ô còn trống!!!");
                }
            }
            else
            {
                item.MaNhanVien = txtEmployeesID.Text.Trim();
                item.TenNhanVien = txtEmployeesName.Text.Trim();
                item.UserName = txtEmployeesUserName.Text.Trim();
                item.Password = txtEmployeesPass.Text.Trim();
                item.MaPhanQuyen = "";

                String pqName = cbbPermissionName.Text;
                if (txtEmployeesName.Text != "" && txtEmployeesPass.Text != ""
                    && txtEmployeesUserName.Text != "" && pqName != "")
                {
                    BUS_NhanVien.Instance.UpdateNV(item, pqName);
                    AutoGenerateID();
                    txtEmployeesName.Clear();
                    txtEmployeesPass.Clear();
                    txtEmployeesUserName.Clear();
                    cbbPermissionName.SelectedIndex = 0;
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
            UserControl usc = new UI_NhanVien(gridMain);
            gridMain.Children.Clear();
            gridMain.Children.Add(usc);
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            txtEmployeesID.Clear();
            txtEmployeesName.Clear();
            txtEmployeesUserName.Clear();
            txtEmployeesPass.Clear();
            cbbPermissionName.SelectedIndex = 0;
            AutoGenerateID();
        }
    }
}
