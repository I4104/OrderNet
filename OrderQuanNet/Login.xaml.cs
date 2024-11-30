using System.Windows;

namespace OrderQuanNet
{
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            // Validate username and password
            MessageBox.Show("Login successful!", "Login", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            // Close the window
            this.Close();
        }
    }
}
