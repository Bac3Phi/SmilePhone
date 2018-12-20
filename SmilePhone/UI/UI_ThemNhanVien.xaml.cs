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
    /// Interaction logic for UI_ThemNhanVien.xaml
    /// </summary>
    public partial class UI_ThemNhanVien : UserControl
    {
        private Grid gridMain;
        public UI_ThemNhanVien(Grid gridMain)
        {
            InitializeComponent();
            this.gridMain = gridMain;
        }

        private void btnLuu_Click(object sender, RoutedEventArgs e)
        {
            //UserControl usc = new UI_ThemNhaCungCap(gridMain);
            //gridMain.Children.Clear();
            //gridMain.Children.Add(usc);
        }
        private void btnQuayLai_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = new UI_NhanVien(gridMain);
            gridMain.Children.Clear();
            gridMain.Children.Add(usc);
        }
    }
}
