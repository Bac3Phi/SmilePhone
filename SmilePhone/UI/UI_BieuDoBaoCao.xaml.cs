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
using LiveCharts;
using LiveCharts.Wpf;
using Separator = LiveCharts.Wpf.Separator;

namespace SmilePhone.UI
{
    /// <summary>
    /// Interaction logic for UI_BieuDoBaoCao.xaml
    /// </summary>
    public partial class UI_BieuDoBaoCao : UserControl
    {
        private Grid gridReport;
        public UI_BieuDoBaoCao(Grid gridReport)
        {
            InitializeComponent();
            this.gridReport = gridReport;
            cbbTenHangHoa.ItemsSource = BUS_BaoCaoTonKho.showData();
        }

        private void rdbMonth_Checked(object sender, RoutedEventArgs e)
        {
            this.ShowChart("Thang");
        }

        private void rdbYear_Checked(object sender, RoutedEventArgs e)
        {
            this.ShowChart("Nam");
        }

        private void btnQuayLai_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = new UI_BaoCaoTonKho(gridReport);
            gridReport.Children.Clear();
            gridReport.Children.Add(usc);
        }

        private void ShowChart(String switchStr)
        {
            var data = BUS_BaoCaoTonKho.showChart(cbbTenHangHoa.Text);
            chartStock.Series.Clear();
            chartStock.AxisX.Clear();
            chartStock.AxisY.Clear();

            ColumnSeries colNhap = new ColumnSeries()
            {
                Title = "Số lượng nhập",
                DataLabels = true,
                Values = new ChartValues<int>(),
                LabelPoint = point => point.Y.ToString()
            };
            ColumnSeries colTonDau = new ColumnSeries()
            {
                Title = "Số lượng tồn đầu",
                DataLabels = true,
                Values = new ChartValues<int>(),
                LabelPoint = point => point.Y.ToString()
            };
            ColumnSeries colXuat = new ColumnSeries()
            {
                Title = "Số lượng xuất",
                DataLabels = true,
                Values = new ChartValues<int>(),
                LabelPoint = point => point.Y.ToString()
            };
            ColumnSeries colTonCuoi = new ColumnSeries()
            {
                Title = "Số lượng tồn cuối",
                DataLabels = true,
                Values = new ChartValues<int>(),
                LabelPoint = point => point.Y.ToString()
            };

            Axis ax = new Axis()
            {
                Separator = new Separator()
                {
                    Step = 1,
                    IsEnabled = false
                }
            };
            ax.Labels = new List<String>();
            foreach (var item in data)
            {
                colNhap.Values.Add(item.SoLuongNhap.Value);
                colXuat.Values.Add(item.SoLuongXuat.Value);
                colTonCuoi.Values.Add(item.SoLuongTonCuoi.Value);
                colTonDau.Values.Add(item.SoLuongTonDau.Value);
                if (switchStr.Contains("Nam"))
                    ax.Labels.Add(item.Nam.ToString());
                else if (switchStr.Contains("Thang"))
                    ax.Labels.Add(item.Thang.ToString());
            }
            chartStock.Series.Add(colNhap);
            chartStock.Series.Add(colXuat);
            chartStock.Series.Add(colTonDau);
            chartStock.Series.Add(colTonCuoi);
            chartStock.AxisX.Add(ax);
            chartStock.AxisY.Add(new Axis
            {
                LabelFormatter = value => value.ToString(),
                Separator = new Separator()
            });
        }
    }
}
