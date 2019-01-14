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
    /// Interaction logic for UI_ThemBaoCaoTK.xaml
    /// </summary>
    public partial class UI_ThemBaoCaoTK : UserControl
    {
        public Grid gridReport;
        public UI_ThemBaoCaoTK(Grid gridReport, DTO_BaoCaoTonKho obj)
        {
            InitializeComponent();
            this.gridReport = gridReport;
        }

        private void btnQuayLai_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = new UI_BaoCaoTonKho(gridReport);
            gridReport.Children.Clear();
            gridReport.Children.Add(usc);
        }

        private void btnLuu_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
