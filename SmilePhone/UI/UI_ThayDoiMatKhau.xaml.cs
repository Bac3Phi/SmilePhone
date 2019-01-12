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
using System.Windows.Shapes;
using BUS;

namespace SmilePhone.UI
{
    /// <summary>
    /// Interaction logic for UI_ThayDoiMatKhau.xaml
    /// </summary>
    public partial class UI_ThayDoiMatKhau : Window
    {
        public UI_ThayDoiMatKhau()
        {
            InitializeComponent();
        }

        private void btnThayDoi_Click(object sender, RoutedEventArgs e)
        {
            if(pwdMoi.Password != pwdXacNhan.Password)
            {
                MessageBox.Show("Xác nhận mật khẩu không đúng", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if(BUS_NhanVien.Instance.checkExist(tbUserName.Text, pwdCu.Password, pwdMoi.Password))
            {
                MessageBox.Show("Mật khẩu cập nhật thành công", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Vui lòng kiểm tra lại thông tin đăng nhập", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
