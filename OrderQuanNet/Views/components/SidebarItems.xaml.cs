using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace OrderQuanNet.Views.components
{
    public partial class SidebarItems : UserControl
    {
        public static readonly DependencyProperty ItemIconProperty = DependencyProperty.Register(
            "ItemIcon", typeof(string), typeof(SidebarItems), new PropertyMetadata(string.Empty, OnItemIconChanged));

        public static readonly DependencyProperty ItemNameProperty = DependencyProperty.Register(
            "ItemName", typeof(string), typeof(SidebarItems), new PropertyMetadata(string.Empty));

        public string ItemIcon
        {
            get { return (string)GetValue(ItemIconProperty); }
            set { SetValue(ItemIconProperty, value); }
        }

        public string ItemName
        {
            get { return (string)GetValue(ItemNameProperty); }
            set { SetValue(ItemNameProperty, value); }
        }

        public SidebarItems()
        {
            InitializeComponent();
        }

        private static void OnItemIconChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (SidebarItems)d;
            var newIcon = e.NewValue as string;

            if (!string.IsNullOrEmpty(newIcon))
            {
                control.Icon.Source = new BitmapImage(new Uri(newIcon, UriKind.RelativeOrAbsolute));
            }
        }
    }
}
