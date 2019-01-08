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

namespace SmilePhone.UI
{
    /// <summary>
    /// Interaction logic for UI_HangHoa.xaml
    /// </summary>
    public partial class UI_HangHoa : UserControl
    {
        private bool isRefreshing = false;
        public UI_HangHoa()
        {
            InitializeComponent();
            dgvHangHoa.ItemsSource = BUS_HangHoa.showData();
        }

        private void btnThemHangHoa_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = new UI_ThemHangHoa();
            UI_ManHinhChinh.gridMain.Children.Clear();
            UI_ManHinhChinh.gridMain.Children.Add(usc);
        }

        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            isRefreshing = true;
            dgvHangHoa.ItemsSource = BUS_HangHoa.showData();
            isRefreshing = false;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = new UI_ThemHangHoa(dgvHangHoa.SelectedItem as DTO_HangHoa);
            UI_ManHinhChinh.gridMain.Children.Clear();
            UI_ManHinhChinh.gridMain.Children.Add(usc);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Bạn có muốn xóa dòng này?", "Confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                if (dgvHangHoa.SelectedItem != null)
                {
                    DTO_HangHoa obj = new DTO_HangHoa();
                    obj = dgvHangHoa.SelectedItem as DTO_HangHoa;
                    String id = obj.MaHangHoa;

                    BUS_HangHoa.Delete(id);
                    dgvHangHoa.ItemsSource = BUS_HangHoa.showData();

                }
            }
        }

        private void BtnLoaiHangHoa_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = new UI_LoaiHangHoa();
            UI_ManHinhChinh.gridMain.Children.Clear();
            UI_ManHinhChinh.gridMain.Children.Add(usc);
        }
    }
}
