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
    /// Interaction logic for UI_BaoCaoTonKho.xaml
    /// </summary>
    public partial class UI_BaoCaoTonKho : UserControl
    {
        public Grid gridReport;
        public UI_BaoCaoTonKho(Grid gridReport)
        {
            InitializeComponent();
            this.gridReport = gridReport;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgvStockReport.ItemsSource = BUS_BaoCaoTonKho.showData();            
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = new UI_ThemBaoCaoTK(gridReport, dgvStockReport.SelectedItem as DTO_BaoCaoTonKho);
            gridReport.Children.Clear();
            gridReport.Children.Add(usc);
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            //UserControl usc = new UI_ThemNhanVien(gridMain, dgvEmployees.SelectedItem as DTO_NhanVien);
            //gridMain.Children.Clear();
            //gridMain.Children.Add(usc);
        }

        private void btnTim_Click(object sender, RoutedEventArgs e)
        {
            //UserControl usc = new UI_ThemNhanVien(gridMain, dgvEmployees.SelectedItem as DTO_NhanVien);
            //gridMain.Children.Clear();
            //gridMain.Children.Add(usc);
        }
        
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            //UserControl usc = new UI_ThemNhanVien(gridMain, dgvEmployees.SelectedItem as DTO_NhanVien);
            //gridMain.Children.Clear();
            //gridMain.Children.Add(usc);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            //UserControl usc = new UI_ThemNhanVien(gridMain, dgvEmployees.SelectedItem as DTO_NhanVien);
            //gridMain.Children.Clear();
            //gridMain.Children.Add(usc);
        }

        private void TxtSearchText_TextChanged(object sender, TextChangedEventArgs e)
        {
            //FindListViewItem(dgvEmployees);
        }
        
        private void btnChart_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = new UI_BieuDoBaoCao(gridReport);
            gridReport.Children.Clear();
            gridReport.Children.Add(usc);
        }
    }
}
