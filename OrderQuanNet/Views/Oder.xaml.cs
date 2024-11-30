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

namespace OrderQuanNet.Views
{
    /// <summary>
    /// Interaction logic for Oder.xaml
    /// </summary>
    public partial class Oder : UserControl
    {
        public Oder()
        {
            InitializeComponent();
        }
        private void UserControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            UpdateRows();
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateRows();


        }
        private void UpdateRows()
        {
            double itemWidth = 160;
            int rowCount = (int)(this.ActualWidth / itemWidth);
            OderGrid.Columns = rowCount;
        }

        // Sự kiện click cho nút Order
        private void BtnOrder_Click(object sender, RoutedEventArgs e)
        {
            btnOrder.Visibility = Visibility.Collapsed; // Ẩn nút Order
            btnConfirm.Visibility = Visibility.Visible; // Hiển thị nút Xác Nhận
        }

        // Sự kiện click cho nút Xác Nhận
        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            btnConfirm.Visibility = Visibility.Collapsed; // Ẩn nút Xác Nhận
            btnComplete.Visibility = Visibility.Visible; // Hiển thị nút Hoàn Thành
        }

        // Sự kiện click cho nút Hoàn Thành
        private void BtnComplete_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hoàn thành!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            // Reset lại trạng thái nếu cần
            btnComplete.Visibility = Visibility.Collapsed; // Ẩn nút Hoàn Thành
            btnOrder.Visibility = Visibility.Visible;      // Hiển thị lại nút Order
        }
    }
}