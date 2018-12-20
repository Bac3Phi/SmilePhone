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
    /// Interaction logic for UI_NhaCungCap.xaml
    /// </summary>
    public partial class UI_NhaCungCap : UserControl
    {
        private Grid gridMain;

        public UI_NhaCungCap(Grid gridMain)
        {
            InitializeComponent();
            this.gridMain = gridMain;
            dgvSuppliers.ItemsSource = BUS_NhaCungCap.showData();
        }
        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = new UI_ThemNhaCungCap(gridMain, dgvSuppliers.SelectedItem as NhaCungCap);
            gridMain.Children.Clear();
            gridMain.Children.Add(usc);
        }
        private void btnTim_Click(object sender, RoutedEventArgs e)
        {
            //UserControl usc = new UI_ThemNhaCungCap(gridMain);
            //gridMain.Children.Clear();
            //gridMain.Children.Add(usc);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgvSuppliers.SelectedItem != null)
            {
                BUS_NhaCungCap.DeleteNCC(dgvSuppliers.SelectedItem as NhaCungCap);
                dgvSuppliers.ItemsSource = BUS_NhaCungCap.showData();
                //dgvSuppliers.Items.Remove(dgvSuppliers.SelectedItem);
            }
        }
        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            //dgvSuppliers.Rows.Clear();
            dgvSuppliers.ItemsSource = BUS_NhaCungCap.showData();
        }
    }
}

//Command="{StaticResource DeleteOrderCommand}"
