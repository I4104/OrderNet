using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OrderQuanNet.Views
{
    /// <summary>
    /// Interaction logic for UserManagement.xaml
    /// </summary>
    public partial class User : UserControl
    {
        public User()
        {
            InitializeComponent();
        }

        private bool IsAdmin = true; // hoặc lấy giá trị này từ hệ thống đăng nhập của bạn
        private void UserControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            UpdateRows();
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateRows();
            // Kiểm tra quyền của người dùng và ẩn/hiện nút "Add"
            if (IsAdmin)
            {
                // Hiển thị nút "Add" nếu là admin
                AddButton.Visibility = Visibility.Visible;
                DownloadButton.Visibility = Visibility.Visible;

            }
            else
            {
                // Ẩn nút "Add" nếu là user
                AddButton.Visibility = Visibility.Collapsed;
                DownloadButton.Visibility = Visibility.Collapsed;


            }
        }

        private void UpdateRows()
        {
            double itemWidth = 160;
            int rowCount = (int)(this.ActualWidth / itemWidth);
            UserGrid.Columns = rowCount;
        }


        private void DynamicButtonClick(object sender, RoutedEventArgs e)
        {
            // Kiểm tra xem người dùng có phải là admin không
            if (IsAdmin)
            {
                // Nếu là admin, gọi cửa sổ EditPopup
                EditPopupUser(sender, e);
            }
            
        }
        
        private void EditPopupUser(object sender, RoutedEventArgs e)
        {
            // Tạo một cửa sổ mới của loại EditPopupWindow
            EditPopupUser editWindow = new EditPopupUser();

            // Hiển thị cửa sổ mới
            editWindow.ShowDialog();
        }
        private void AddUser(object sender, RoutedEventArgs e)
        {
            // Tạo một cửa sổ mới của loại Detail
            AddUser addWindow = new AddUser();

            // Hiển thị cửa sổ mới
            addWindow.ShowDialog();
        }
        private void Download(object sender, RoutedEventArgs e)
        {
            Download downloadWindow = new Download();

            // Hiển thị cửa sổ mới
            downloadWindow.ShowDialog();
        }
    }
}
