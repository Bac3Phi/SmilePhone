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

namespace SmilePhone.UI
{
    /// <summary>
    /// Interaction logic for UI_ManHinhChinh.xaml
    /// </summary>
    public partial class UI_ManHinhChinh : Window
    {
        public static Grid gridMain;
        public UI_ManHinhChinh()
        {
            InitializeComponent();
            gridMain = GridMain;
            txtTenNhanVien.Text = Properties.Settings.Default.TenNhanVien;
        }
        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserControl usc = null;
            GridMain.Children.Clear();

            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "ItemHome":
                    usc = new UI_QuanTri();
                    GridMain.Children.Add(usc);
                    break;
                case "ItemCreate":
                    usc = new UI_BanHang();
                    GridMain.Children.Add(usc);
                    break;
                case "ItemSuppliers":
                    usc = new UI_NhaCungCap(GridMain);
                    GridMain.Children.Add(usc);
                    break;
                case "ItemEmployees":
                    usc = new UI_NhanVien(GridMain);
                    GridMain.Children.Add(usc);
                    break;
                case "ItemReceipt":
                    usc = new UI_PhieuChi(GridMain);
		    GridMain.Children.Add(usc);
                    break;
                case "ItemHangHoa":
                    usc = new UI_HangHoa();
                    GridMain.Children.Add(usc);
                    break;
                default:
                    break;
            }
        }

        private void btn_Logout_Click(object sender, RoutedEventArgs e)
        {
            UI_DangNhap UI_DangNhap = new UI_DangNhap();
            UI_DangNhap.Show();
            this.Close();
        }
    }
}
