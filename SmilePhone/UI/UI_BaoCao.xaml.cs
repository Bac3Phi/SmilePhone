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
    /// Interaction logic for UI_BaoCao.xaml
    /// </summary>
    public partial class UI_BaoCao : UserControl
    {
        public static Grid gridReport;
        private UserControl usc;
        public UI_BaoCao()
        {
            InitializeComponent();            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            gridReport = GridReport;
            
        }

        private void rdbStock_Checked(object sender, RoutedEventArgs e)
        {
            usc = new UI_BaoCaoTonKho(GridReport);
            GridReport.Children.Clear();
            GridReport.Children.Add(usc);
        }

        private void rdbIncome_Checked(object sender, RoutedEventArgs e)
        {
            usc = new UI_BaoCaoThuChi(GridReport);
            GridReport.Children.Clear();
            GridReport.Children.Add(usc);
        }
    }
}
