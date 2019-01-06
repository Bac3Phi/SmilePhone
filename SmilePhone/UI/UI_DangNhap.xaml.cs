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
    /// Interaction logic for UI_DangNhap.xaml
    /// </summary>
    public partial class UI_DangNhap : Window
    {
        public UI_DangNhap()
        {
            InitializeComponent();
            tbUserName.Text = Properties.Settings.Default.Username;
            tbPassword.Password = Properties.Settings.Default.Password;
        }

        private void btnDangNhap_Click(object sender, RoutedEventArgs e)
        {
            if (BUS_DangNhap.Instance.DangNhap(tbUserName.Text, tbPassword.Password) != null)
            {
                dynamic nhanVien = BUS_DangNhap.Instance.DangNhap(tbUserName.Text, tbPassword.Password);
                Properties.Settings.Default.MaNV = nhanVien.MaNhanVien;
                Properties.Settings.Default.TenNhanVien = nhanVien.TenNhanVien;
                Properties.Settings.Default.Username = nhanVien.UserName;
                Properties.Settings.Default.Password = nhanVien.Password;

                Properties.Settings.Default.Save();

                UI_ManHinhChinh UI_ManHinhChinh = new UI_ManHinhChinh();
                UI_ManHinhChinh.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu",
                                          "Đăng Nhập Thất Bại",
                                          MessageBoxButton.OK);
            }
        }
    }
}
