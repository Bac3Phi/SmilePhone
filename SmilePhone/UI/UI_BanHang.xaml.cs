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
    /// Interaction logic for UI_BanHang.xaml
    /// </summary>
    public partial class UI_BanHang : UserControl
    {
        private bool isRefreshing = false;

        public UI_BanHang()
        {
            InitializeComponent();
        }

        private void btnLapPhieu_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = new UI_LapPhieuBanHang();
            UI_ManHinhChinh.gridMain.Children.Clear();
            UI_ManHinhChinh.gridMain.Children.Add(usc);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgvPhieuBanHang.ItemsSource = BUS_PhieuBanHang.showData();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Bạn có muốn xóa dòng này?", "Confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                if (dgvPhieuBanHang.SelectedItem != null)
                {
                    DTO_PhieuBanHang obj = dgvPhieuBanHang.SelectedItem as DTO_PhieuBanHang;
                    String id = obj.MaPhieuBanHang;

                    if (BUS_PhieuBanHang.Delete(id))
                    {
                        dgvPhieuBanHang.ItemsSource = BUS_PhieuBanHang.showData();
                    }
                    else MessageBox.Show("Xóa thất bại!");

                }
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = new UI_LapPhieuBanHang(dgvPhieuBanHang.SelectedItem as DTO_PhieuBanHang);
            UI_ManHinhChinh.gridMain.Children.Clear();
            UI_ManHinhChinh.gridMain.Children.Add(usc);
        }

        private void BtnSearchDate_Click(object sender, RoutedEventArgs e)
        {
            DateTime fromPC = dpFrom.SelectedDate.Value;
            DateTime toPC = dpTo.SelectedDate.Value;
            dgvPhieuBanHang.ItemsSource = BUS_PhieuBanHang.Instance.SearchDate(fromPC, toPC);
        }

        private void SearchStr_Click(object sender, RoutedEventArgs e)
        {
            string searchStr = tbSearchStr.Text;
            dgvPhieuBanHang.ItemsSource = BUS_PhieuBanHang.Instance.SearchData(searchStr);
        }

        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            isRefreshing = true;
            tbSearchStr.Clear();
            dpFrom.SelectedDate = DateTime.Today.AddDays(0);
            dpTo.SelectedDate = DateTime.Today.AddDays(0);
            dgvPhieuBanHang.ItemsSource = BUS_PhieuBanHang.showData();
            isRefreshing = false;
        }

        private void DpFrom_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (isRefreshing == false)
            {
                if (dpTo.SelectedDate != null)
                {
                    if (dpTo.SelectedDate.Value < dpFrom.SelectedDate.Value)
                    {
                        MessageBoxResult result = MessageBox.Show("Ngày trong ô 'Đến ngày' phải lớn hơn hoặc bằng ngày trong ô 'Từ ngày'", "Error", MessageBoxButton.OK);
                        if (result == MessageBoxResult.OK)
                        {
                            dpFrom.SelectedDate = dpTo.SelectedDate.Value;
                        }
                    }
                }
            }
            else
            {
                dpFrom.SelectedDate = null;
                dpTo.SelectedDate = null;
            }
        }

        private void DpTo_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (isRefreshing == false)
            {
                if (dpFrom.SelectedDate != null)
                {
                    if (dpTo.SelectedDate.Value < dpFrom.SelectedDate.Value)
                    {
                        MessageBoxResult result = MessageBox.Show("Ngày trong ô 'Đến ngày' phải lớn hơn hoặc bằng ngày trong ô 'Từ ngày'", "Error", MessageBoxButton.OK);
                        if (result == MessageBoxResult.OK)
                        {
                            dpTo.SelectedDate = dpFrom.SelectedDate.Value;
                        }
                    }
                }
            }
            else
            {
                dpTo.SelectedDate = null;
                dpFrom.SelectedDate = null;
            }
        }
    }
}
