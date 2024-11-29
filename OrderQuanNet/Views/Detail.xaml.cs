using System;
using System.Windows;

namespace OrderQuanNet.Views
{
    public partial class Detail : Window
    {
        public Detail()
        {
            InitializeComponent();
        }


        private void AddToCart(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Đã thêm vào giỏ hàng!");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var fadeIn = new System.Windows.Media.Animation.DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = new Duration(TimeSpan.FromSeconds(0.5))
            };
            this.BeginAnimation(UIElement.OpacityProperty, fadeIn);
        }
        private void Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
