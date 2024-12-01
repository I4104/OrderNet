using System.Windows;
using Microsoft.Win32;

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
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                string selectedImagePath = openFileDialog.FileName;
                txtImagePath.Text = selectedImagePath;
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
                MessageBox.Show("Balance must be a valid number.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Confirmation message
            MessageBox.Show($"Product Name: {productName}\nBalance: {PriceValue:C}\nImage Path: {imagePath}", "Product Information");

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
