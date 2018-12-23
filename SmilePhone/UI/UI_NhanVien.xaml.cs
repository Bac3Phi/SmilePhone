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
using DAL;

namespace SmilePhone.UI
{
    /// <summary>
    /// Interaction logic for UI_NhanVien.xaml
    /// </summary>
    public partial class UI_NhanVien : UserControl
    {
        private Grid gridMain;

        public UI_NhanVien(Grid gridMain)
        {
            InitializeComponent();
            this.gridMain = gridMain;
            dgvEmployees.ItemsSource = BUS_NhanVien.showData();
        }
        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = new UI_ThemNhanVien(gridMain, dgvEmployees.SelectedItem as NhanVien);
            gridMain.Children.Clear();
            gridMain.Children.Add(usc);
        }
        private void btnTim_Click(object sender, RoutedEventArgs e)
        {
            string searchStr = txtSearch.Text;
            dgvEmployees.ItemsSource = BUS_NhanVien.Instance.searchData(searchStr);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgvEmployees.SelectedItem != null)
            {
                BUS_NhanVien.DeleteNV(dgvEmployees.SelectedItem as NhanVien);
                //dgvEmployees.ItemsSource = BUS_NhanVien.showData();
                //dgvSuppliers.Items.Remove(dgvSuppliers.SelectedItem);
            }
        }
        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            //dgvSuppliers.Rows.Clear();
            //dgvEmployees.ItemsSource = BUS_NhanVien.showData();
        }
    }
}
