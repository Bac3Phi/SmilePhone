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
    /// Interaction logic for UI_ThemNhaCungCap.xaml
    /// </summary>
    public partial class UI_ThemNhaCungCap : UserControl
    {
        private Grid gridMain;
        private bool isNew = false;
        private NhaCungCap item = new NhaCungCap();

        public UI_ThemNhaCungCap(Grid gridMain, NhaCungCap obj)
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
                txtSupplierID.Text = obj.MaNhaCungCap;
                txtSupplierName.Text = obj.TenNhaCungCap;
                txtSupplierAddress.Text = obj.DiaChi;
                txtSupplierPhone.Text = obj.SoDienThoai;
                txtSupplierEmail.Text = obj.Email;
                isNew = false;
            }
        }

        private void AutoGenerateID()
        {
            txtSupplierID.Text = BUS_NhaCungCap.Instance.generateAutoID();
        }

        private void btnLuu_Click(object sender, RoutedEventArgs e)
        {
            if (isNew == true)
            {
                item.MaNhaCungCap = txtSupplierID.Text.Trim();
                item.TenNhaCungCap = txtSupplierName.Text.Trim();
                item.DiaChi = txtSupplierAddress.Text.Trim();
                item.SoDienThoai = txtSupplierPhone.Text.Trim();
                item.Email = txtSupplierEmail.Text.Trim();
                if (txtSupplierEmail.Text != "" || txtSupplierPhone.Text != ""
                    || txtSupplierAddress.Text != "" || txtSupplierName.Text != "")
                {
                    BUS_NhaCungCap.Instance.InsertNCC(item);
                    AutoGenerateID();
                    txtSupplierID.Clear();
                    txtSupplierName.Clear();
                    txtSupplierPhone.Clear();
                    txtSupplierAddress.Clear();
                    txtSupplierEmail.Clear();
                    MessageBox.Show("Thêm mới thành công!");
                }
                else
                {
                    MessageBox.Show("Hãy điền tất cả các ô còn trống!!!");
                }
            }
            else
            {
                item.MaNhaCungCap = txtSupplierID.Text.Trim();
                item.TenNhaCungCap = txtSupplierName.Text.Trim();
                item.DiaChi = txtSupplierAddress.Text.Trim();
                item.SoDienThoai = txtSupplierPhone.Text.Trim();
                item.Email = txtSupplierEmail.Text.Trim();
                if (txtSupplierEmail.Text != "" || txtSupplierPhone.Text != ""
                    || txtSupplierAddress.Text != "" || txtSupplierName.Text != "")
                {
                    BUS_NhaCungCap.Instance.UpdateNCC(item);
                    AutoGenerateID();
                    txtSupplierID.Clear();
                    txtSupplierName.Clear();
                    txtSupplierPhone.Clear();
                    txtSupplierAddress.Clear();
                    txtSupplierEmail.Clear();
                    MessageBox.Show("Cập nhật thành công!");
                }
                else
                {
                    MessageBox.Show("Hãy điền tất cả các ô còn trống!!!");
                }
            }
        }

        private void btnQuayLai_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = new UI_NhaCungCap(gridMain);
            gridMain.Children.Clear();
            gridMain.Children.Add(usc);
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            txtSupplierID.Clear();
            txtSupplierName.Clear();
            txtSupplierPhone.Clear();
            txtSupplierAddress.Clear();
            txtSupplierEmail.Clear();
            AutoGenerateID();
        }
    }
}
