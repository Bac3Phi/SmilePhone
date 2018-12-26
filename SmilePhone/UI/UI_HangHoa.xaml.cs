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
    /// Interaction logic for UI_HangHoa.xaml
    /// </summary>
    public partial class UI_HangHoa : UserControl
    {
        public UI_HangHoa()
        {
            InitializeComponent();
        }

        private void btnThemHangHoa_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = new UI_ThemHangHoa();
            UI_ManHinhChinh.gridMain.Children.Clear();
            UI_ManHinhChinh.gridMain.Children.Add(usc);
        }
    }
}
