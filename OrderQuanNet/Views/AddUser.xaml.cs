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
            // Fade-in animation for the window
            var fadeIn = new System.Windows.Media.Animation.DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = new Duration(TimeSpan.FromSeconds(0.5))
            };
            this.BeginAnimation(OpacityProperty, fadeIn);
        }

        // Chức năng chọn ảnh
        private void ChooseImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                string selectedImagePath = openFileDialog.FileName;
                txtImagePath.Text = selectedImagePath;  // Hiển thị đường dẫn ảnh
            }
        }

        // Chức năng hủy bỏ
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // Đóng cửa sổ nếu người dùng nhấn Cancel
        }

        // Chức năng tạo người dùng
        private void Create_Click(object sender, RoutedEventArgs e)
        {
            // Lấy dữ liệu từ các trường nhập liệu
            string userName = txtUserName.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Password; // Dùng PasswordBox nên phải lấy bằng .Password
            string balance = txtBalance.Text;
            string imagePath = txtImagePath.Text;

            // Kiểm tra xem người dùng đã nhập đầy đủ thông tin chưa
            if (string.IsNullOrWhiteSpace(userName) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(balance) ||
                string.IsNullOrWhiteSpace(imagePath))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Hiển thị thông tin người dùng
            MessageBox.Show($"Tên người dùng: {userName}\nEmail: {email}\nMật khẩu: {password}\nSố dư: {balance}\nĐường dẫn hình ảnh: {imagePath}", "Thông tin người dùng");

            // Đóng cửa sổ sau khi tạo
            this.Close();
        }

        // Chức năng đóng cửa sổ
        private void CloseWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // Đóng cửa sổ khi nhấn nút "X"
        }
    }
}
