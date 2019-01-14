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

namespace SmilePhone.UI
{
    /// <summary>
    /// Interaction logic for UI_PhieuDatHang.xaml
    /// </summary>
    public partial class UI_PhieuDatHang : UserControl
    {
        public UI_PhieuDatHang()
        {
            InitializeComponent();
            dgvPhieuDatHang.ItemsSource = BUS_PhieuDatHang.Instance.showData();
            dpFrom.SelectedDate = DateTime.Today.AddDays(0);
            dpTo.SelectedDate = DateTime.Today.AddDays(0);
        }

        private void btnLapPhieu_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = new UI_LapPhieuDatHang();
            UI_ManHinhChinh.gridMain.Children.Clear();
            UI_ManHinhChinh.gridMain.Children.Add(usc);
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            txtSearch.Clear();
            dpFrom.SelectedDate = DateTime.Today.AddDays(0);
            dpTo.SelectedDate = DateTime.Today.AddDays(0);
            dgvPhieuDatHang.ItemsSource = BUS_PhieuDatHang.Instance.showData();
        }

        private void btnSearchDate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSearchStr_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Bạn có muốn xóa dòng này?", "Confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                if (dgvPhieuDatHang.SelectedItem != null)
                {
                    DTO_PhieuDatHang obj = new DTO_PhieuDatHang();
                    obj = dgvPhieuDatHang.SelectedItem as DTO_PhieuDatHang;
                    String id = obj.MaPhieuDatHang;

                    if (BUS_PhieuDatHang.Instance.Delete(id))
                    {
                        dgvPhieuDatHang.ItemsSource = BUS_PhieuNhap.showData();
                    }
                    else MessageBox.Show("Xóa không thành công!!");
                }
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = new UI_LapPhieuDatHang(dgvPhieuDatHang.SelectedItem as DTO_PhieuDatHang);
            UI_ManHinhChinh.gridMain.Children.Clear();
            UI_ManHinhChinh.gridMain.Children.Add(usc);
        }

        private void onFromDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void onToDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TxtSearchText_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
