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
    /// Interaction logic for Food.xaml
    /// </summary>
    public partial class Drink : UserControl
    {
        public Drink()
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
            }
            else
            {
                // Ẩn nút "Add" nếu là user
                AddButton.Visibility = Visibility.Collapsed;
            }
        }

        private void UpdateRows()
        {
            double itemWidth = 160;
            int rowCount = (int)(this.ActualWidth / itemWidth);
            DrinkGrid.Columns = rowCount;
        }
       

        private void DynamicButtonClick(object sender, RoutedEventArgs e)
        {
            // Kiểm tra xem người dùng có phải là admin không
            if (IsAdmin)
            {
                // Nếu là admin, gọi cửa sổ EditPopup
                EditPopup(sender, e);
            }
            else
            {
                // Nếu là user, gọi cửa sổ PopupTab
                PopupTab(sender, e);
            }
        }

        private void PopupTab(object sender, RoutedEventArgs e)
        {
            // Tạo một cửa sổ mới của loại Detail
            Detail detailWindow = new Detail();

            // Hiển thị cửa sổ mới
            detailWindow.ShowDialog();
        }

        private void EditPopup(object sender, RoutedEventArgs e)
        {
            // Tạo một cửa sổ mới của loại EditPopupWindow
            EditPopup editWindow = new EditPopup();

            // Hiển thị cửa sổ mới
            editWindow.ShowDialog();
        }
        private void Add(object sender, RoutedEventArgs e)
        {
            // Tạo một cửa sổ mới của loại Detail
            Add addWindow = new Add();

            // Hiển thị cửa sổ mới
            addWindow.ShowDialog();
        }


    }
}
