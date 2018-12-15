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
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = new UI_ThemNhaCungCap(gridMain);
            gridMain.Children.Clear();
            gridMain.Children.Add(usc);
        }
        private void btnTim_Click(object sender, RoutedEventArgs e)
        {
            //UserControl usc = new UI_ThemNhaCungCap(gridMain);
            //gridMain.Children.Clear();
            //gridMain.Children.Add(usc);
        }
    }
}
