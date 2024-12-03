using System.Windows;
using System.Windows.Controls;

namespace OrderQuanNet.Views.components
{
    public partial class SearchForm : UserControl
    {
        public SearchForm()
        {
            InitializeComponent();
        }

        private void SearchBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (SearchBox.Text == "Search here...")
            {
                SearchBox.Text = string.Empty;  
                SearchBox.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Black);  
            }
        }

        private void SearchBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SearchBox.Text))
            {
                SearchBox.Text = "Search here..."; 
                SearchBox.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Gray);  
            }
        }
    }
}
