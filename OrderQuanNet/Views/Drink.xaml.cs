using OrderQuanNet.DataManager;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace OrderQuanNet.Views
{
    public partial class Drink : UserControl
    {
        public Drink()
        {
            InitializeComponent();
            LoadDrinkProducts();
        }

        private void LoadDrinkProducts()
        {
            if (ProductDataManager.Products.Count == 0) ProductDataManager.LoadProducts();
            var allProducts = ProductDataManager.Products;
            var drinkProducts = allProducts.Where(p => p.type == "drink");
            DrinkItemsControl.ItemsSource = drinkProducts.ToList();

            DrinkTitle.Text = "QUẦY NƯỚC: " + drinkProducts.Count();
        }


        private void UserControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            UpdateRows();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateRows();
            if (SessionManager.users.type == "admin")
                AddButton.Visibility = Visibility.Visible;
            else
                AddButton.Visibility = Visibility.Hidden;
        }

        private void UpdateRows()
        {
            double itemWidth = 160;
            int rowCount = (int)(this.ActualWidth / itemWidth);

            UniformGrid uniformGrid = FindUniformGrid(DrinkItemsControl);
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

        private void DynamicButtonClick(object sender, RoutedEventArgs e)
        {
            if (SessionManager.users.type == "admin")
                EditPopup(sender, e);
            else
                PopupTab(sender, e);
        }

        private void PopupTab(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            Detail detailWindow = new Detail(int.Parse(button.Tag.ToString()));
            detailWindow.ShowDialog();
        }

        private void EditPopup(object sender, RoutedEventArgs e)
        {
            EditPopup editWindow = new EditPopup();
            editWindow.ShowDialog();
        }
        private void Add(object sender, RoutedEventArgs e)
        {
            Add addWindow = new Add();
            addWindow.ShowDialog();
        }
    }
}
