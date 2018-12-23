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

        public UI_ThemNhanVien(Grid gridMain, NhanVien obj)
        {
            InitializeComponent();
            this.gridMain = gridMain;
            if (obj == null)
            {
                //AutoGenerateID();
                isNew = true;
            }
            else
            {
                txtEmployeesID.Text = obj.MaNhanVien;
                txtEmployeesName.Text = obj.TenNhanVien;
                txtEmployeesUserName.Text = obj.UserName;
                txtEmployeesPass.Text = obj.Password;
                //cbbPermissionName.SelectedValue = obj.TenPhanQuyen;
                isNew = false;
            }
        }

        private void AutoGenerateID()
        {
            //txtSupplierID.Text = BUS_NhanVien.Instance.generateAutoID();
        }

        private void btnLuu_Click(object sender, RoutedEventArgs e)
        {
            //if (isNew == true)
            //{
            //    item.MaNhanVien = txtSupplierID.Text.Trim();
            //    item.TenNhanVien = txtSupplierName.Text.Trim();
            //    item.UserName = txtSupplierAddress.Text.Trim();
            //    item.Password = txtSupplierPhone.Text.Trim();
            //    item.TenPhanQuyen = txtSupplierEmail.Text.Trim();
            //    if (txtSupplierEmail.Text != "" || txtSupplierPhone.Text != ""
            //        || txtSupplierAddress.Text != "" || txtSupplierName.Text != "")
            //    {
            //        BUS_NhaCungCap.Instance.InsertNCC(item);
            //        txtSupplierID.Clear();
            //        txtSupplierName.Clear();
            //        txtSupplierPhone.Clear();
            //        txtSupplierAddress.Clear();
            //        txtSupplierEmail.Clear();
            //        MessageBox.Show("Thêm mới thành công!");
            //    }
            //    else
            //    {
            //        MessageBox.Show("Hãy điền tất cả các ô còn trống!!!");
            //    }
            //}
            //else
            //{
            //    item.MaNhanVien = txtSupplierID.Text.Trim();
            //    item.TenNhanVien = txtSupplierName.Text.Trim();
            //    item.UserName = txtSupplierAddress.Text.Trim();
            //    item.Password = txtSupplierPhone.Text.Trim();
            //    item.TenPhanQuyen = txtSupplierEmail.Text.Trim();
            //    if (txtSupplierEmail.Text != "" || txtSupplierPhone.Text != ""
            //        || txtSupplierAddress.Text != "" || txtSupplierName.Text != "")
            //    {
            //        BUS_NhaCungCap.Instance.UpdateNCC(item);
            //        txtSupplierID.Clear();
            //        txtSupplierName.Clear();
            //        txtSupplierPhone.Clear();
            //        txtSupplierAddress.Clear();
            //        txtSupplierEmail.Clear();
            //        MessageBox.Show("Cập nhật thành công!");
            //    }
            //    else
            //    {
            //        MessageBox.Show("Hãy điền tất cả các ô còn trống!!!");
            //    }
            //}
        }

        private void btnQuayLai_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = new UI_NhaCungCap(gridMain);
            gridMain.Children.Clear();
            gridMain.Children.Add(usc);
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            //txtSupplierID.Clear();
            //txtSupplierName.Clear();
            //txtSupplierPhone.Clear();
            //txtSupplierAddress.Clear();
            //txtSupplierEmail.Clear();
            AutoGenerateID();
        }
    }
}
