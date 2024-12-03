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
            var fadeIn = new System.Windows.Media.Animation.DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = new Duration(TimeSpan.FromSeconds(0.5))
            };
            this.BeginAnimation(UIElement.OpacityProperty, fadeIn);
        }

        private void ExportData()
        {
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

        private void CloseWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Export_Click(object sender, RoutedEventArgs e)
        {
            ExportData();
        }
    }
}
