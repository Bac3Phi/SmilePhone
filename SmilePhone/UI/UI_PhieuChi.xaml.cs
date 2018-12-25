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
using DAL;
using BUS;

namespace SmilePhone.UI
{
    /// <summary>
    /// Interaction logic for UI_PhieuChi.xaml
    /// </summary>
    public partial class UI_PhieuChi : UserControl
    {
        private Grid gridMain;

        public UI_PhieuChi(Grid gridMain)
        {
            InitializeComponent();
            this.gridMain = gridMain;
            //dgvRe.ItemsSource = BUS_PhieuChi.showData();
        }
        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = new UI_ThemPhieuChi(gridMain, dgvReceipt.SelectedItem as PhieuChi);
            gridMain.Children.Clear();
            gridMain.Children.Add(usc);
        }
        private void btnTim_Click(object sender, RoutedEventArgs e)
        {
            //string searchStr = txtSearch.Text;
            //dgvSuppliers.ItemsSource = BUS_NhaCungCap.Instance.searchData(searchStr);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            //if (dgvSuppliers.SelectedItem != null)
            //{
            //    BUS_NhaCungCap.DeleteNCC(dgvSuppliers.SelectedItem as NhaCungCap);
            //    dgvSuppliers.ItemsSource = BUS_NhaCungCap.showData();
            //    //dgvSuppliers.Items.Remove(dgvSuppliers.SelectedItem);
            //}
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = new UI_ThemPhieuChi(gridMain, dgvReceipt.SelectedItem as PhieuChi);
            gridMain.Children.Clear();
            gridMain.Children.Add(usc);
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            //dgvSuppliers.Rows.Clear();
            //txtSearch.Clear();
            //dgvSuppliers.ItemsSource = BUS_NhaCungCap.showData();
        }

        private void btnSearchDate_Click(object sender, RoutedEventArgs e)
        {
            //dgvSuppliers.Rows.Clear();
            //txtSearch.Clear();
            //dgvSuppliers.ItemsSource = BUS_NhaCungCap.showData();
        }
    }
}
