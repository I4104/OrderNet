using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using OrderQuanNet.DataManager;
using OrderQuanNet.Models;
using OrderQuanNet.Services;

namespace OrderQuanNet.Views
{
    public class OrderItem
    {
        public int id { get; set; }
        public string name { get; set; }
        public string image_path { get; set; }
        public decimal price { get; set; }
        public int amount { get; set; }
    }

    public partial class OrdersTab : UserControl
    {
        private Action _updateCart;

        public OrdersTab()
        {
            InitializeComponent();
            UpdateRows();
            loadData();
            _updateCart = ((Main) Application.Current.MainWindow).UpdateCartAction;
        }

        public static readonly DependencyProperty CartItemsProperty = DependencyProperty.Register("CartItems", typeof(Dictionary<int, int>), typeof(OrdersTab), new PropertyMetadata(new Dictionary<int, int>()));

        public Dictionary<int, int> CartItems
        {
            get { return (Dictionary<int, int>)GetValue(CartItemsProperty); }
            set { SetValue(CartItemsProperty, value); }
        }

        private void loadData()
        {
            var data = CartDataManager.cartItems;

            List<OrderItem> cart = new List<OrderItem>();
            foreach (var item in data)
            {
                ProductsModel product = ProductDataManager.Products.Where(p => p.id == item.Key).FirstOrDefault();
                cart.Add(new OrderItem
                {
                    id = product.id.Value,
                    name = product.name,
                    image_path = product.image_path,
                    price = product.price.Value,
                    amount = item.Value
                });
            }

            CartItemsControl.ItemsSource = cart;
            total.Text = CartDataManager.getTotalPrice().ToString();
        }

        private void ThanhToan(object sender, RoutedEventArgs e)
        {
            var data = CartDataManager.cartItems;
            foreach (var item in data)
            {
                OrdersService ordersService = new OrdersService();
                OrdersModel order = new OrdersModel();

                order.users_id = SessionManager.users.id;
                order.product_id = item.Key;
                order.amount = item.Value;
                order.price = ProductDataManager.Products.Where(p => p.id == item.Key).FirstOrDefault().price.Value;
                order.amount = item.Value;
                order.status = "WAITING";

                ordersService.Insert(order);
                CartDataManager.removeItem(item.Key);
                _updateCart?.Invoke();
            }
            MessageBox.Show("Đơn hàng đã được đặt, chúng tôi sẽ tới thu tiền trong ít phút!");
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateRows();
        }

        private void UserControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            UpdateRows();
        }
        private void UpdateRows()
        {
            double itemHeight = 85;
            int rowCount = (int)((this.ActualHeight - 45) / itemHeight);
            UniformGrid uniformGrid = FindUniformGrid(CartItemsControl);
            if (uniformGrid != null)
            {
                uniformGrid.Rows = rowCount;
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
    }
}
