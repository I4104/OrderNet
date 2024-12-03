using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace OrderQuanNet.Views
{
    public partial class EditPopup : Window
    {
        public EditPopup()
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

        private void txtImageURL_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            try
            {
                string imageUrl = txtImageURL.Text;
                if (!string.IsNullOrWhiteSpace(imageUrl))
                {
                    imgProduct.Source = new BitmapImage(new Uri(imageUrl, UriKind.Absolute));
                }
                else
                {
                    imgProduct.Source = null;  
                }
            }
            catch (Exception)
            {
                imgProduct.Source = null;  
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            string productName = txtProductName.Text;
            string price = txtPrice.Text;
            string imagePath = txtImageURL.Text;

            if (string.IsNullOrWhiteSpace(productName) || string.IsNullOrWhiteSpace(price) || string.IsNullOrWhiteSpace(imagePath))
            {
                MessageBox.Show("Please fill in all the required fields.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!decimal.TryParse(price, out decimal priceValue))
            {
                MessageBox.Show("Price must be a valid number.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            MessageBox.Show($"Product Name: {productName}\nPrice: {priceValue:C}\nImage Path: {imagePath}", "Product Information");
            this.Close();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Delete button clicked!");
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void CloseWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
