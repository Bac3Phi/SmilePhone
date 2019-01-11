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
    /// Interaction logic for UI_LoaiHangHoa.xaml
    /// </summary>
    public partial class UI_LoaiHangHoa : UserControl
    {
        private bool isNew = true;
        private DTO_LoaiHangHoa item = new DTO_LoaiHangHoa();

        public UI_LoaiHangHoa()
        {
            InitializeComponent();
            generateID();
            dgvLoaiHangHoa.ItemsSource = BUS_LoaiHangHoa.showData();
        }

        private void generateID()
        {
            txtMaLoaiHangHoa.Text = BUS_LoaiHangHoa.Instance.generateAutoID();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Bạn có muốn xóa dòng này?", "Confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                if (dgvLoaiHangHoa.SelectedItem != null)
                {
                    DTO_LoaiHangHoa obj = new DTO_LoaiHangHoa();
                    obj = dgvLoaiHangHoa.SelectedItem as DTO_LoaiHangHoa;
                    String id = obj.MaLoaiHangHoa;

                    if (BUS_LoaiHangHoa.Delete(id))
                        refresh();
                    else MessageBox.Show("Xóa thất bại!");

                }
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (isNew)
            {
                if (txtTenLoaiHangHoa.Text != ""
                     && txtPhanTramLoiNhuan.Text != "")
                {
                    getDataFromUI();

                    if (BUS_LoaiHangHoa.Instance.Insert(item))
                    {
                        MessageBox.Show("Thêm mới thành công!");
                        refresh();
                    }
                    else MessageBox.Show("Thêm mới thất bại!");
                }
                else
                {
                    MessageBox.Show("Hãy điền tất cả các ô còn trống!!!");
                }
            }
            else
            {
                if (txtTenLoaiHangHoa.Text != ""
                     && txtPhanTramLoiNhuan.Text != "")
                {
                    getDataFromUI();

                    if (BUS_LoaiHangHoa.Instance.Update(item))
                    {
                        MessageBox.Show("Lưu thành công!");
                        refresh();
                    }
                    else MessageBox.Show("Lưu thất bại!");
                }
                else
                {
                    MessageBox.Show("Hãy điền tất cả các ô còn trống!!!");
                }
            }
        }

        private void refresh()
        {
            txtMaLoaiHangHoa.Text = BUS_LoaiHangHoa.Instance.generateAutoID();
            txtTenLoaiHangHoa.Text = "";
            txtPhanTramLoiNhuan.Text = "";
            txtSearch.Text = "";
            dgvLoaiHangHoa.ItemsSource = BUS_LoaiHangHoa.showData();
            isNew = true;
        }

        private void getDataFromUI()
        {
            item.MaLoaiHangHoa = txtMaLoaiHangHoa.Text.Trim();
            item.TenLoaiHangHoa = txtTenLoaiHangHoa.Text.Trim();
            item.PhanTramLoiNhuan = int.Parse(txtPhanTramLoiNhuan.Text.Trim());
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            refresh();
        }

        private void btnQuayLai_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = new UI_HangHoa();
            UI_ManHinhChinh.gridMain.Children.Clear();
            UI_ManHinhChinh.gridMain.Children.Add(usc);
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string searchStr = txtSearch.Text;
            dgvLoaiHangHoa.ItemsSource = BUS_LoaiHangHoa.Instance.searchData(searchStr);
        }

        private void DgvLoaiHangHoa_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DTO_LoaiHangHoa obj = new DTO_LoaiHangHoa();
            obj = dgvLoaiHangHoa.SelectedItem as DTO_LoaiHangHoa;

            if (obj != null)
            {
                txtMaLoaiHangHoa.Text = obj.MaLoaiHangHoa;
                txtTenLoaiHangHoa.Text = obj.TenLoaiHangHoa;
                txtPhanTramLoiNhuan.Text = obj.PhanTramLoiNhuan.ToString();

                isNew = false;
            }           
        }
    }
}
