using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for UI_NhanVien.xaml
    /// </summary>
    public partial class UI_NhanVien : UserControl
    {
        private Grid gridMain;
        private Regex regex;

        public UI_NhanVien(Grid gridMain)
        {
            InitializeComponent();
            this.gridMain = gridMain;            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgvEmployees.ItemsSource = BUS_NhanVien.showData();
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = new UI_ThemNhanVien(gridMain, dgvEmployees.SelectedItem as DTO_NhanVien);
            gridMain.Children.Clear();
            gridMain.Children.Add(usc);
        }
        private void btnTim_Click(object sender, RoutedEventArgs e)
        {
            string searchStr = txtSearch.Text;
            dgvEmployees.ItemsSource = BUS_NhanVien.Instance.searchData(searchStr);
            
        }

        #region Highlight search
        private void TxtSearchText_TextChanged(object sender, TextChangedEventArgs e)
        {
            FindListViewItem(dgvEmployees);
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
                if (dgvEmployees.SelectedItem != null)
                {
                    //object obj = dgvEmployees.SelectedItem;
                    DTO_NhanVien obj = dgvEmployees.SelectedItem as DTO_NhanVien;
                    String id = obj.MaNhanVien;

                    BUS_NhanVien.DeleteNV(id);
                    dgvEmployees.ItemsSource = BUS_NhanVien.showData();

                }
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = new UI_ThemNhanVien(gridMain, dgvEmployees.SelectedItem as DTO_NhanVien);
            gridMain.Children.Clear();
            gridMain.Children.Add(usc);
        }
        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            //dgvSuppliers.Rows.Clear();
            txtSearch.Clear();
            dgvEmployees.ItemsSource = BUS_NhanVien.showData();
        }
    }
}
