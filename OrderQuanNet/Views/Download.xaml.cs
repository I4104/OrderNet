﻿using System;
using System.Windows;
using System.Windows.Controls;

namespace OrderQuanNet.Views
{
    public partial class Download : Window
    {
        public Download()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Fade-in animation for the window
            var fadeIn = new System.Windows.Media.Animation.DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = new Duration(TimeSpan.FromSeconds(0.5))
            };
            this.BeginAnimation(UIElement.OpacityProperty, fadeIn);
        }

        // Xuất dữ liệu
        private void ExportData()
        {
            // Use pattern matching to safely check for null and cast
            if (ExportFormatComboBox.SelectedItem is ComboBoxItem selectedItem && selectedItem.Content is string selectedFormat)
            {
                switch (selectedFormat)
                {
                    case "CSV":
                        ExportToCSV();
                        break;
                    case "Excel":
                        ExportToExcel();
                        break;
                    case "PDF":
                        ExportToPDF();
                        break;
                    default:
                        MessageBox.Show("Vui lòng chọn định dạng xuất!");
                        break;
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn định dạng xuất!");
            }
        }

        private static void ExportToCSV()
        {
            MessageBox.Show("Đã xuất dữ liệu ra CSV!");
        }

        private static void ExportToExcel()
        {
            MessageBox.Show("Đã xuất dữ liệu ra Excel!");
        }

        private static void ExportToPDF()
        {
            MessageBox.Show("Đã xuất dữ liệu ra PDF!");
        }

        // Sự kiện đóng cửa sổ
        private void CloseWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        // Sự kiện hủy bỏ
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        // Sự kiện tạo (xuất dữ liệu)
        private void Create_Click(object sender, RoutedEventArgs e)
        {
            ExportData();
        }
    }
}
