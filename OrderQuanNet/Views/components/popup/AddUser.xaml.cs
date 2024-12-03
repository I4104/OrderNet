using System;
using System.Windows;
using System.Windows.Media.Animation;

namespace OrderQuanNet.Views.components.popup
{
    public partial class AddUser : Window
    {
        public AddUser(string v)
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Animation for window fade-in
            var fadeIn = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = new Duration(TimeSpan.FromSeconds(0.5))
            };
            this.BeginAnimation(OpacityProperty, fadeIn);
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            // Close the window when cancel button is clicked
            this.Close();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            // Collect user inputs
            string userName = txtUserName.Text;
            string Name = txtName.Text;
            string email = txtEmail.Text;
            string balance = txtBalance.Text;
            string imagePath = txtImagePath.Text;
            string role = cmbRoles.Text;

            // Validation
            if (string.IsNullOrWhiteSpace(userName) ||
                string.IsNullOrWhiteSpace(Name) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(balance) ||
                string.IsNullOrWhiteSpace(imagePath) ||
                string.IsNullOrWhiteSpace(role))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Display collected information
            MessageBox.Show(
                $"Tên người dùng: {userName}\nTên:  {Name} \nEmail: {email}\nVai trò: {role}\nSố dư: {balance}\nĐường dẫn hình ảnh: {imagePath}",
                "Thông tin người dùng");

            // Close the window after creation
            this.Close();
        }
        private void ResetPassword_Click(object sender, RoutedEventArgs e)
        {
           
        }

    }
}
