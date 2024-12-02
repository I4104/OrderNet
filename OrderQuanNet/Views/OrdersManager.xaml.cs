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

        private void BtnProcess_Click(object sender, RoutedEventArgs e)
        {
            StatusText.Text = "Đang xử lý";
            btnProcess.Content = "Hoàn thành";

            btnProcess.Click -= BtnProcess_Click;
            btnProcess.Click += BtnComplete_Click;
        }

        private void BtnComplete_Click(object sender, RoutedEventArgs e)
        {
            StatusText.Text = "Đã xong";
            btnProcess.Content = "Đã xong";

            btnProcess.Click -= BtnComplete_Click;
        }

        private void Bill_Click(object sender, RoutedEventArgs e)
        {
            var billWindow = new Bill();
            billWindow.ShowDialog();
        }

    }
}
