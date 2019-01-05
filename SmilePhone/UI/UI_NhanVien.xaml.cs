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
using System.Windows.Threading;
using BUS;
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
        private List<DTO_NhanVien> blockNV;

        public UI_NhanVien(Grid gridMain)
        {
            InitializeComponent();
            this.gridMain = gridMain;
            blockNV = new List<DTO_NhanVien>();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgvEmployees.ItemsSource = BUS_NhanVien.showData();
            if (dgvEmployees.ItemsSource != null)
            {
                foreach (DTO_NhanVien item in dgvEmployees.ItemsSource)
                {
                    if (item.TrangThai == false)
                    {
                        blockNV.Add(item);
                    }
                }                
            }

            dgvEmployees.Dispatcher.BeginInvoke(DispatcherPriority.Input,
                new Action(delegate () {
                    foreach (var itemNV in blockNV)
                    {
                        var row = dgvEmployees.ItemContainerGenerator.ContainerFromItem(itemNV) as DataGridRow;
                        row.FontStyle = FontStyles.Oblique;
                        row.FontWeight = FontWeights.DemiBold;
                    }
                }));            
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

            blockNV.Clear();
            if (dgvEmployees.ItemsSource != null)
            {
                foreach (DTO_NhanVien item in dgvEmployees.ItemsSource)
                {
                    if (item.TrangThai == false)
                    {
                        blockNV.Add(item);
                    }
                }
            }
            dgvEmployees.Dispatcher.BeginInvoke(DispatcherPriority.Input,
                new Action(delegate () {
                    foreach (var itemNV in blockNV)
                    {
                        var row = dgvEmployees.ItemContainerGenerator.ContainerFromItem(itemNV) as DataGridRow;
                        row.FontStyle = FontStyles.Oblique;
                        row.FontWeight = FontWeights.DemiBold;
                    }
                }));

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
            if (dgvEmployees.SelectedItem != null)
            {
                DTO_NhanVien obj = dgvEmployees.SelectedItem as DTO_NhanVien;
                if (obj.TrangThai == true)
                {
                    MessageBoxResult result = MessageBox.Show("Bạn có muốn khóa dòng này?", "Confirmation", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        obj.TrangThai = false;
                        BUS_NhanVien.Instance.UpdateNV(obj);
                        blockNV.Clear();
                        dgvEmployees.ItemsSource = BUS_NhanVien.showData();
                        if (dgvEmployees.ItemsSource != null)
                        {
                            foreach (DTO_NhanVien item in dgvEmployees.ItemsSource)
                            {
                                if (item.TrangThai == false)
                                {
                                    blockNV.Add(item);
                                }
                            }
                        }
                        dgvEmployees.Dispatcher.BeginInvoke(DispatcherPriority.Input,
                            new Action(delegate () {
                                foreach (var itemNV in blockNV)
                                {
                                    var row = dgvEmployees.ItemContainerGenerator.ContainerFromItem(itemNV) as DataGridRow;
                                    row.FontStyle = FontStyles.Oblique;
                                    row.FontWeight = FontWeights.DemiBold;
                                }
                            }));
                    }
                }
                else
                    MessageBox.Show("Bạn đã khóa nhân viên này !");
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
            blockNV.Clear();
            txtSearch.Clear();
            dgvEmployees.ItemsSource = BUS_NhanVien.showData();
            if (dgvEmployees.ItemsSource != null)
            {
                foreach (DTO_NhanVien item in dgvEmployees.ItemsSource)
                {
                    if (item.TrangThai == false)
                    {
                        blockNV.Add(item);
                    }
                }
            }

            dgvEmployees.Dispatcher.BeginInvoke(DispatcherPriority.Input,
                new Action(delegate ()
                {
                    foreach (var itemNV in blockNV)
                    {
                        var row = dgvEmployees.ItemContainerGenerator.ContainerFromItem(itemNV) as DataGridRow;
                        row.FontStyle = FontStyles.Oblique;
                        row.FontWeight = FontWeights.DemiBold;
                    }
                }));
        }
    }
}
