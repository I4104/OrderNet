using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace OrderQuanNet.Views.components.popup
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

        private void txtImagePath_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            try
            {
                string imageUrl = txtImagePath.Text;
                if (!string.IsNullOrWhiteSpace(imageUrl))
                {
                    imgProduct.Source = new BitmapImage(new Uri(imageUrl, UriKind.Absolute));
                }
                else
                {
                    imgProduct.Source = null; // Xóa ảnh nếu URL trống
                }
            }
            catch (Exception)
            {
                imgProduct.Source = null; // Trường hợp URL không hợp lệ
            }
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            string productName = txtProductName.Text;
            string Price = txtPrice.Text;
            string imagePath = txtImagePath.Text;

            // Validation for empty fields
            if (string.IsNullOrWhiteSpace(productName) || string.IsNullOrWhiteSpace(Price) || string.IsNullOrWhiteSpace(imagePath))
            {
                MessageBox.Show("Please fill in all the required fields.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Validate if balance is a valid number
            if (!decimal.TryParse(Price, out decimal PriceValue))
            {
                MessageBox.Show("Price must be a valid number.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Confirmation message
            MessageBox.Show($"Product Name: {productName}\nPrice: {PriceValue:C}\nImage Path: {imagePath}", "Product Information");

            // Close the window after saving
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            // Simply close the window without saving
            this.Close();
        }

        private void CloseWindow_Click(object sender, RoutedEventArgs e)
        {
            // Close the window
            this.Close();
        }
    }
}
