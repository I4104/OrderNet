using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using OrderQuanNet.DataManager;
using OrderQuanNet.Views.components.popup;

namespace OrderQuanNet.Views
{
    public partial class Time : UserControl
    {
        private Action _updateCart;
        public Time()
        {
            InitializeComponent();
            LoadTimeProducts();
            _updateCart = ((Main)Application.Current.MainWindow).UpdateCartAction;
        }

        private void LoadTimeProducts()
        {
            if (ProductDataManager.Products.Count == 0) ProductDataManager.LoadProducts();
            var allProducts = ProductDataManager.Products;
            var timeProducts = allProducts.Where(p => p.type == "time");
            TimeItemsControl.ItemsSource = timeProducts.ToList();
        }

        private void ToggleAddButtonVisibility()
        {
            if (SessionManager.users.type == "admin")
                AddButton.Visibility = Visibility.Visible;
            else
                AddButton.Visibility = Visibility.Hidden;
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            Add addWindow = new Add("time");
            addWindow.ShowDialog();
        }
        private void Reset(object sender, RoutedEventArgs e)
        {
            ProductDataManager.LoadProducts();
            _updateCart?.Invoke();
        }
        private void UserControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            UpdateRows();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateRows();
            ToggleAddButtonVisibility();
        }

        private void UpdateRows()
        {
            double itemWidth = 160;
            int rowCount = (int)(this.ActualWidth / itemWidth);

            UniformGrid uniformGrid = FindUniformGrid(TimeItemsControl);
            if (uniformGrid != null)
            {
                uniformGrid.Columns = rowCount;
                uniformGrid.InvalidateMeasure();
            }
        }

        private UniformGrid FindUniformGrid(DependencyObject parent)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                if (child is UniformGrid uniformGrid) return uniformGrid;

                var foundChild = FindUniformGrid(child);
                if (foundChild != null) return foundChild;
            }
            return null;
        }
        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {

            MessageBox.Show("reset");

        }
    }
}
