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
using DTO;

namespace SmilePhone.UI
{
    /// <summary>
    /// Interaction logic for UI_NhaCungCap.xaml
    /// </summary>
    public partial class UI_NhaCungCap : UserControl
    {
        private Grid gridMain;
        private Regex regex;

        public UI_NhaCungCap(Grid gridMain)
        {
            InitializeComponent();
            this.gridMain = gridMain;
            dgvSuppliers.ItemsSource = BUS_NhaCungCap.showData();
        }
        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = new UI_ThemNhaCungCap(gridMain, dgvSuppliers.SelectedItem as DTO_NhaCungCap);
            gridMain.Children.Clear();
            gridMain.Children.Add(usc);
        }
        private void btnTim_Click(object sender, RoutedEventArgs e)
        {
            string searchStr = txtSearch.Text;
            dgvSuppliers.ItemsSource = BUS_NhaCungCap.Instance.searchData(searchStr);
        }

        #region Highlight Search
        private void TxtSearchText_TextChanged(object sender, TextChangedEventArgs e)
        {
            FindListViewItem(dgvSuppliers);
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
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Bạn có muốn xóa dòng này?", "Confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                if (dgvSuppliers.SelectedItem != null)
                {
                    DTO_NhaCungCap obj = dgvSuppliers.SelectedItem as DTO_NhaCungCap;
                    BUS_NhaCungCap.DeleteNCC(obj);
                    dgvSuppliers.ItemsSource = BUS_NhaCungCap.showData();
                }
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = new UI_ThemNhaCungCap(gridMain, dgvSuppliers.SelectedItem as DTO_NhaCungCap);
            gridMain.Children.Clear();
            gridMain.Children.Add(usc);
        }
        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            //dgvSuppliers.Rows.Clear();
            txtSearch.Clear();
            dgvSuppliers.ItemsSource = BUS_NhaCungCap.showData();
        }
    }
}

//Command="{StaticResource DeleteOrderCommand}"
