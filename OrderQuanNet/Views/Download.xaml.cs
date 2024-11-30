using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Globalization;
using System.Windows.Xps.Packaging;
using System.Windows.Documents;
using System.Xml;
using System.Text;

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

        // Sự kiện xuất dữ liệu
        private void Export_Click(object sender, RoutedEventArgs e)
        {
            
        }

        // Xuất dữ liệu ra CSV
        private static void ExportToCSV()
        {
           
        }

        // Xuất dữ liệu ra Excel
        private static void ExportToExcel()
        {
           

            MessageBox.Show("Đã xuất dữ liệu ra Excel!");
        }

        // Xuất dữ liệu ra PDF (chưa triển khai hoàn chỉnh, chỉ là ví dụ)
        private static void ExportToPDF()
        {
            
            MessageBox.Show("Đã xuất dữ liệu ra PDF!");
        }

        // Sự kiện đóng cửa sổ
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // Đóng cửa sổ hiện tại
        }
    }

    // Lớp dữ liệu mẫu cho sản phẩm
    
}
