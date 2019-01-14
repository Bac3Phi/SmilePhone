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
    /// Interaction logic for UI_ThemNhaCungCap.xaml
    /// </summary>
    public partial class UI_ThemNhaCungCap : UserControl
    {
        private Grid gridMain;
        private bool isNew = false;
        private DTO_NhaCungCap item = new DTO_NhaCungCap();

        public UI_ThemNhaCungCap(Grid gridMain, DTO_NhaCungCap obj)
        {
            InitializeComponent();
            DataContext = new TextFieldsViewModel();
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
            if (isHasError())
            {
                MessageBox.Show("Vui lòng điền đầy đủ chính xác thông tin!");
                return;
            }

            if (isNew == true)
            {
                BUS_NhaCungCap.Instance.InsertNCC(item);
                MessageBox.Show("Thêm mới thành công!");
                AutoGenerateID();
                txtSupplierName.Clear();
                txtSupplierPhone.Clear();
                txtSupplierAddress.Clear();
                txtSupplierEmail.Clear();
            }
            else
            {
                BUS_NhaCungCap.Instance.UpdateNCC(item);
                MessageBox.Show("Cập nhật thành công!");
                AutoGenerateID();
                txtSupplierName.Clear();
                txtSupplierPhone.Clear();
                txtSupplierAddress.Clear();
                txtSupplierEmail.Clear();
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
            isNew = true;
            AutoGenerateID();
        }
        private Boolean isHasError()
        {
            if (Validation.GetHasError(txtSupplierName) == true
                || Validation.GetHasError(txtSupplierAddress) == true
                || Validation.GetHasError(txtSupplierPhone) == true
                || Validation.GetHasError(txtSupplierEmail) == true)
                return true;
            else
                return false;
        }
    }
}
