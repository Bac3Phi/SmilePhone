using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using DAL;
using DTO;

namespace SmilePhone.UI
{
    /// <summary>
    /// Interaction logic for UI_PhieuBaoHanh.xaml
    /// </summary>
    public partial class UI_PhieuBaoHanh : UserControl
    {
        private Grid gridMain;
        private bool isRefreshing = false;
        private bool isMergeCondition = false;
        private bool daGiao;
        public UI_PhieuBaoHanh(Grid gridMain)
        {
            InitializeComponent();
            this.gridMain = gridMain;
            dgvPhieuBaoHanh.ItemsSource = BUS_PhieuBaoHanh.showData();
            dpFromPC.SelectedDate = DateTime.Today.AddDays(0);
            dpToPC.SelectedDate = DateTime.Today.AddDays(0);
        }


        private void TxtSearchText_TextChanged(object sender, TextChangedEventArgs e)
        {
            Helper.FindListViewItem(dgvPhieuBaoHanh, txtSearch.Text);
        }

        private void btnSearchStr_Click(object sender, RoutedEventArgs e)
        {
            String searchStr = txtSearch.Text;
            dgvPhieuBaoHanh.ItemsSource = BUS_PhieuBaoHanh.Instance.searchData(searchStr, isMergeCondition, daGiao);
        }

        private void btnSearchDate_Click(object sender, RoutedEventArgs e)
        {
            DateTime fromPC = dpFromPC.SelectedDate.Value;
            DateTime toPC = dpToPC.SelectedDate.Value;
            dgvPhieuBaoHanh.ItemsSource = BUS_PhieuBaoHanh.Instance.searchDate(fromPC, toPC);
        }

        private void btnLapPhieu_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = new UI_ThemPhieuBaoHanh(gridMain, dgvPhieuBaoHanh.SelectedItem as DTO_PhieuBaoHanh);
            gridMain.Children.Clear();
            gridMain.Children.Add(usc);
        }


        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Bạn có muốn xóa dòng này?", "Confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                if (dgvPhieuBaoHanh.SelectedItem != null)
                {
                    DTO_PhieuBaoHanh obj = new DTO_PhieuBaoHanh();
                    obj = dgvPhieuBaoHanh.SelectedItem as DTO_PhieuBaoHanh;
                    String id = obj.MaPhieuBaoHanh;

                    BUS_PhieuBaoHanh.Delete(id);
                    dgvPhieuBaoHanh.ItemsSource = BUS_PhieuBaoHanh.showData();

                }
            }
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = new UI_ThemPhieuBaoHanh(gridMain, dgvPhieuBaoHanh.SelectedItem as DTO_PhieuBaoHanh);
            gridMain.Children.Clear();
            gridMain.Children.Add(usc);
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            isRefreshing = true;
            txtSearch.Clear();
            dpFromPC.SelectedDate = DateTime.Today.AddDays(0);
            dpToPC.SelectedDate = DateTime.Today.AddDays(0);
            dgvPhieuBaoHanh.ItemsSource = BUS_PhieuBaoHanh.showData();
            isRefreshing = false;
        }

        private void onFromDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (isRefreshing == false)
            {
                if (dpToPC.SelectedDate != null)
                {
                    if (dpToPC.SelectedDate.Value < dpFromPC.SelectedDate.Value)
                    {
                        MessageBoxResult result = MessageBox.Show("Ngày trong ô 'Đến ngày' phải lớn hơn hoặc bằng ngày trong ô 'Từ ngày'", "Error", MessageBoxButton.OK);
                        if (result == MessageBoxResult.OK)
                        {
                            dpFromPC.SelectedDate = dpToPC.SelectedDate.Value;
                        }
                    }
                }
            }
            else
            {
                dpFromPC.SelectedDate = null;
                dpToPC.SelectedDate = null;
            }
        }

        private void onToDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (isRefreshing == false)
            {
                if (dpFromPC.SelectedDate != null)
                {
                    if (dpToPC.SelectedDate.Value < dpFromPC.SelectedDate.Value)
                    {
                        MessageBoxResult result = MessageBox.Show("Ngày trong ô 'Đến ngày' phải lớn hơn hoặc bằng ngày trong ô 'Từ ngày'", "Error", MessageBoxButton.OK);
                        if (result == MessageBoxResult.OK)
                        {
                            dpToPC.SelectedDate = dpFromPC.SelectedDate.Value;
                        }
                    }
                }
            }
            else
            {
                dpToPC.SelectedDate = null;
                dpFromPC.SelectedDate = null;
            }
        }

        private void cbbTrangThai_DropDownClosed(object sender, EventArgs e)
        {
            var trangThai = Int32.Parse(cbbTrangThai.SelectedValue.ToString());
            switch (trangThai)
            {
                case 0:
                    isMergeCondition = true;
                    daGiao = false;
                    break;
                case 1:
                    isMergeCondition = true;
                    daGiao = true;
                    break;
                default:
                    isMergeCondition = false;
                    break;

            }
        }
    }
}
