﻿using System;
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
using DTO;

namespace SmilePhone.UI
{
    /// <summary>
    /// Interaction logic for UI_ThemNhanVien.xaml
    /// </summary>
    public partial class UI_ThemNhanVien : UserControl
    {
        private Grid gridMain;
        private bool isNew;
        private DTO_NhanVien item = new DTO_NhanVien();

        public UI_ThemNhanVien(Grid gridMain, DTO_NhanVien obj)
        {
            InitializeComponent();
            this.gridMain = gridMain;
            cbbPermissionName.ItemsSource = BUS_PhanQuyen.showData();
            cbbPermissionName.SelectedIndex = 0;
            if (obj == null)
            {
                AutoGenerateID();
                isNew = true;
            }
            else
            {
                txtEmployeesID.Text = obj.MaNhanVien;
                txtEmployeesName.Text = obj.TenNhanVien;
                txtEmployeesUserName.Text = obj.UserName;
                txtEmployeesPass.Password = obj.Password;
                cbbPermissionName.Text = obj.TenPhanQuyen;
                isNew = false;
            }
        }

        private void AutoGenerateID()
        {
            txtEmployeesID.Text = BUS_NhanVien.Instance.generateAutoID();
        }

        private void btnLuu_Click(object sender, RoutedEventArgs e)
        {
            if (isNew == true)
            {
                item.MaNhanVien = txtEmployeesID.Text.Trim();
                item.TenNhanVien = txtEmployeesName.Text.Trim();
                item.UserName = txtEmployeesUserName.Text.Trim();
                item.Password = txtEmployeesPass.Password.Trim();
                item.TenPhanQuyen = cbbPermissionName.Text;
                if (txtEmployeesName.Text != "" && txtEmployeesPass.Password != ""
                    && txtEmployeesUserName.Text != "" && cbbPermissionName.Text != "")
                {
                    BUS_NhanVien.Instance.InsertNV(item);
                    AutoGenerateID();
                    txtEmployeesName.Clear();
                    txtEmployeesPass.Clear();
                    txtEmployeesUserName.Clear();
                    cbbPermissionName.SelectedIndex = 0;
                    MessageBox.Show("Thêm mới thành công!");
                }
                else
                {
                    MessageBox.Show("Hãy điền tất cả các ô còn trống!!!");
                }
            }
            else
            {
                item.MaNhanVien = txtEmployeesID.Text.Trim();
                item.TenNhanVien = txtEmployeesName.Text.Trim();
                item.UserName = txtEmployeesUserName.Text.Trim();
                item.Password = txtEmployeesPass.Password.Trim();
                item.TenPhanQuyen = cbbPermissionName.Text;
                if (txtEmployeesName.Text != "" && txtEmployeesPass.Password != ""
                    && txtEmployeesUserName.Text != "" && cbbPermissionName.Text != "")
                {
                    BUS_NhanVien.Instance.UpdateNV(item);
                    AutoGenerateID();
                    txtEmployeesName.Clear();
                    txtEmployeesPass.Clear();
                    txtEmployeesUserName.Clear();
                    cbbPermissionName.SelectedIndex = 0;
                    MessageBox.Show("Cập nhật nhân viên thành công!");
                }
                else
                {
                    MessageBox.Show("Hãy điền tất cả các ô còn trống!!!");
                }
            }
        }

        private void btnQuayLai_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = new UI_NhanVien(gridMain);
            gridMain.Children.Clear();
            gridMain.Children.Add(usc);
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            txtEmployeesID.Clear();
            txtEmployeesName.Clear();
            txtEmployeesUserName.Clear();
            txtEmployeesPass.Clear();
            cbbPermissionName.SelectedIndex = 0;
            isNew = true;
            AutoGenerateID();
        }
    }
}