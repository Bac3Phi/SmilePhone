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
    /// Interaction logic for UI_ThemNhaCungCap.xaml
    /// </summary>
    public partial class UI_ThemNhaCungCap : UserControl
    {
        private Grid gridMain;

        public UI_ThemNhaCungCap(Grid gridMain)
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
            UserControl usc = new UI_NhaCungCap(gridMain);
            gridMain.Children.Clear();
            gridMain.Children.Add(usc);
        }
    }
}
