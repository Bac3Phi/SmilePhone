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
using System.Text.RegularExpressions;

namespace SmilePhone.UI
{
    /// <summary>
    /// Interaction logic for UI_PhieuChi.xaml
    /// </summary>
    public partial class UI_PhieuChi : UserControl
    {
        private Grid gridMain;
        private Regex regex;
        private bool isRefreshing = false;

        public UI_PhieuChi(Grid gridMain)
        {
            InitializeComponent();
            this.gridMain = gridMain;            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgvReceipt.ItemsSource = BUS_PhieuChi.showData();
        }
        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = new UI_ThemPhieuChi(gridMain, dgvReceipt.SelectedItem as DTO_PhieuChi);
            gridMain.Children.Clear();
            gridMain.Children.Add(usc);
        }

        #region Highlight search
        private void TxtSearchText_TextChanged(object sender, TextChangedEventArgs e)
        {
            FindListViewItem(dgvReceipt);
        }

        public void FindListViewItem(DependencyObject obj)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DataGrid lv = obj as DataGrid;
                if (lv != null)
                {
                    HighlightText(lv);
                }
                FindListViewItem(VisualTreeHelper.GetChild(obj as DependencyObject, i));
            }
        }

        private void HighlightText(Object itx)
        {
            if (itx != null)
            {
                if (itx is TextBlock)
                {
                    regex = new Regex("(" + txtSearch.Text + ")", RegexOptions.IgnoreCase);
                    TextBlock tb = itx as TextBlock;
                    if (txtSearch.Text.Length == 0)
                    {
                        string str = tb.Text;
                        tb.Inlines.Clear();
                        tb.Inlines.Add(str);
                        return;
                    }
                    string[] substrings = regex.Split(tb.Text);
                    tb.Inlines.Clear();
                    foreach (var item in substrings)
                    {
                        if (regex.Match(item).Success)
                        {
                            Run runx = new Run(item);
                            runx.Background = Brushes.Yellow;
                            tb.Inlines.Add(runx);
                        }
                        else
                        {
                            tb.Inlines.Add(item);
                        }
                    }
                    return;
                }
                else
                {
                    for (int i = 0; i < VisualTreeHelper.GetChildrenCount(itx as DependencyObject); i++)
                    {
                        HighlightText(VisualTreeHelper.GetChild(itx as DependencyObject, i));
                    }
                }
            }
        }
        #endregion
        private void btnSearchStr_Click(object sender, RoutedEventArgs e)
        {
            string searchStr = txtSearch.Text;
            dgvReceipt.ItemsSource = BUS_PhieuChi.Instance.searchStrPC(searchStr);
        }

        private void btnSearchDate_Click(object sender, RoutedEventArgs e)
        {
            DateTime fromPC = dpFromPC.SelectedDate.Value;
            DateTime toPC = dpToPC.SelectedDate.Value;
            dgvReceipt.ItemsSource = BUS_PhieuChi.Instance.searchDatePC(fromPC, toPC);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Bạn có muốn xóa dòng này?", "Confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                if (dgvReceipt.SelectedItem != null)
                {
                    DTO_PhieuChi obj = dgvReceipt.SelectedItem as DTO_PhieuChi;
                    String id = obj.MaPhieuChi;

                    BUS_PhieuChi.DeletePC(id);
                    dgvReceipt.ItemsSource = BUS_PhieuChi.showData();

                }
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = new UI_ThemPhieuChi(gridMain, dgvReceipt.SelectedItem as DTO_PhieuChi);
            gridMain.Children.Clear();
            gridMain.Children.Add(usc);
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            isRefreshing = true;
            txtSearch.Clear();
            dpToPC.SelectedDate = null;
            dpFromPC.SelectedDate = null;
            dgvReceipt.ItemsSource = BUS_PhieuChi.showData();
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
    }
}
