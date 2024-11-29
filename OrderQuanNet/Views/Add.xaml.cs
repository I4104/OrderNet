using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace OrderQuanNet.Views
{
    public partial class Add : Window
    {
        public Add()
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

        private void ChooseImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                string selectedImagePath = openFileDialog.FileName;
                txtImagePath.Text = selectedImagePath;

                imgPreview.Source = new BitmapImage(new Uri(selectedImagePath, UriKind.Absolute));
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            string productName = txtProductName.Text;
            string price = txtPrice.Text;
            string imagePath = txtImagePath.Text;

            if (string.IsNullOrWhiteSpace(productName) || string.IsNullOrWhiteSpace(price) || string.IsNullOrWhiteSpace(imagePath))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Show the information without the date
            MessageBox.Show($"Tên sản phẩm: {productName}\nGiá: {price}\nĐường dẫn hình: {imagePath}", "Thông tin sản phẩm");
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
