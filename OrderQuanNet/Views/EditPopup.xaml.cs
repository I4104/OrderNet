using System.Windows;
using Microsoft.Win32;

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

        

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            string productName = txtProductName.Text;
            string Price = txtPrice.Text;
            string imagePath = txtImagePath.Text;

            if (string.IsNullOrWhiteSpace(productName) || string.IsNullOrWhiteSpace(Price) || string.IsNullOrWhiteSpace(imagePath))
            {
                MessageBox.Show("Please fill in all the required fields.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!decimal.TryParse(Price, out decimal PriceValue))
            {
                MessageBox.Show("Balance must be a valid number.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            MessageBox.Show($"Product Name: {productName}\nBalance: {PriceValue:C}\nImage Path: {imagePath}", "Product Information");

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
