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
    public partial class Food : UserControl
    {
        public Food()
        {
            InitializeComponent();
        }

        private void UserControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            UpdateRows();
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateRows();
        }

        private void UpdateRows()
        {
            double itemWidth = 160;
            int rowCount = (int)(this.ActualWidth / itemWidth);
            FoodGrid.Columns = rowCount;
        }
        private void PopupTab(object sender, EventArgs e)
        {
            // Tạo một cửa sổ mới của loại Detail
            Detail detailWindow = new Detail();

            // Hiển thị cửa sổ mới
            detailWindow.ShowDialog();
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
