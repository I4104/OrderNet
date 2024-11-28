using System.Text;
using System.Windows;
using System.Windows.Input;
using OrderQuanNet.Views;

namespace OrderQuanNet;

public partial class Main : Window
{
    public Main()
    {
        InitializeComponent();
        ContentManager.Content = new Food();
    }
    
    private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
    {
        resizeLayouts();
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        resizeLayouts();
    }

    private void Window_StateChanged(object sender, EventArgs e)
    {
        resizeLayouts();
    }

    private void resizeLayouts()
    {
        Sidebar.Height = this.ActualHeight - 50;
        TabControl.Height = this.ActualHeight - 55;

        Menu.Height = Sidebar.Height - 175;
        ContentManager.Height = this.ActualHeight - 55;
        ContentManager.Width = this.ActualWidth - 275 * 2;
        ContentManager.Content = new Food();
    }

}
