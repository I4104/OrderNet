using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;

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
            // Fade-in animation for the window
            var fadeIn = new DoubleAnimation
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
                imgPreview.Source = new BitmapImage(new Uri(selectedImagePath, UriKind.Absolute));
            }
        }



        private void Save_Click(object sender, RoutedEventArgs e)
        {
            string userName = txtProductName.Text;
            string password = txtPassword.Text;
            string balance = txtPrice.Text;
            string imagePath = txtImagePath.Text;

            if (string.IsNullOrWhiteSpace(userName) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(balance) ||
                string.IsNullOrWhiteSpace(imagePath))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            MessageBox.Show($"Tên người dùng: {userName}\nMật khẩu: {password}\nSố dư: {balance}\nĐường dẫn hình ảnh: {imagePath}", "Thông tin người dùng");
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
