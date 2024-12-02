using System.Windows;
using Microsoft.Win32;

namespace OrderQuanNet.Views
{
    public partial class AddUser : Window
    {
        public AddUser()
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
            this.BeginAnimation(OpacityProperty, fadeIn);
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

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); 
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            string userName = txtUserName.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Password; 
            string balance = txtBalance.Text;
            string imagePath = txtImagePath.Text;

            if (string.IsNullOrWhiteSpace(userName) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(balance) ||
                string.IsNullOrWhiteSpace(imagePath))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            MessageBox.Show($"Tên người dùng: {userName}\nEmail: {email}\nMật khẩu: {password}\nSố dư: {balance}\nĐường dẫn hình ảnh: {imagePath}", "Thông tin người dùng");

            this.Close();
        }

        private void CloseWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); 
        }
    }
}
