using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace OrderQuanNet.Views
{
    /// <summary>
    /// Interaction logic for EditPopup.xaml
    /// </summary>
    public partial class EditPopup : Window
    {
        public EditPopup()
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

        private void ChooseImage_Click(object sender, RoutedEventArgs e)
        {
            // Open file dialog for image selection
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

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            // Logic for editing the product
            string productName = txtProductName.Text;
            string price = txtPrice.Text;
            string imagePath = txtImagePath.Text;

            if (string.IsNullOrWhiteSpace(productName) || string.IsNullOrWhiteSpace(price) || string.IsNullOrWhiteSpace(imagePath))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Show the updated information without the date
            MessageBox.Show($"Tên sản phẩm: {productName}\nGiá: {price}\nĐường dẫn hình: {imagePath}", "Thông tin sản phẩm");
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            // Logic for deleting the product (confirmation dialog)
            MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này?", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                // Proceed with deletion
                MessageBox.Show("Sản phẩm đã được xóa.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            // Close the window
            this.Close();
        }
    }
}
