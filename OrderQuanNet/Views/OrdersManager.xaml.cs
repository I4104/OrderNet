using System.Windows;
using System.Windows.Controls;

namespace OrderQuanNet.Views
{
    public partial class OrdersManager : UserControl
    {
        public OrdersManager()
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
            OrderGrid.Columns = rowCount;
        }

        // Sự kiện click cho nút Xử lý
        private void BtnProcess_Click(object sender, RoutedEventArgs e)
        {
            // Thay đổi nội dung của TextBlock và nút
            StatusText.Text = "Đang xử lý"; // Cập nhật trạng thái trong TextBlock
            btnProcess.Content = "Hoàn thành"; // Thay đổi nút "Xử Lý" thành "Hoàn thành"

            // Thêm sự kiện click cho nút "Hoàn thành"
            btnProcess.Click -= BtnProcess_Click; // Gỡ bỏ sự kiện cũ
            btnProcess.Click += BtnComplete_Click; // Thêm sự kiện mới cho nút hoàn thành
        }

        private void BtnComplete_Click(object sender, RoutedEventArgs e)
        {
            // Thay đổi nội dung của TextBlock và nút
            StatusText.Text = "Đã xong"; // Cập nhật trạng thái trong TextBlock
            btnProcess.Content = "Đã xong"; // Nút chuyển thành "Đã hoàn thành"

            // Gỡ bỏ sự kiện click vì không cần thiết nữa
            btnProcess.Click -= BtnComplete_Click;
        }

        // Sự kiện click cho nút Download
        private void Download(object sender, RoutedEventArgs e)
        {
            Download downloadWindow = new Download();
            downloadWindow.ShowDialog();
        }
    }
}
