using System.Windows;

namespace OrderQuanNet.Views
{
    public partial class Bill : Window
    {
        public Bill()
        {
            InitializeComponent();
        }

        private void SaveInvoiceButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Invoice Saved Successfully!");
        }

        private void PrintInvoiceButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Printing Invoice...");
        }
    }
}
