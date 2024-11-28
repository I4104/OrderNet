using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using Color = System.Windows.Media.Color;

namespace OrderQuanNet.Views.components
{
    public partial class ToolbarButton : UserControl
    {
        public static readonly DependencyProperty ButtonBackgroundProperty =
            DependencyProperty.Register("ButtonBackground", typeof(Brush), typeof(ToolbarButton), new PropertyMetadata(Brushes.White));

        public static readonly DependencyProperty ButtonTextProperty =
            DependencyProperty.Register("ButtonText", typeof(string), typeof(ToolbarButton), new PropertyMetadata("X"));

        public ToolbarButton()
        {
            InitializeComponent();
        }
        
        public Brush ButtonBackground
        {
            get { return (Brush)GetValue(ButtonBackgroundProperty); }
            set { SetValue(ButtonBackgroundProperty, value); }
        }

        public string ButtonText
        {
            get { return (string)GetValue(ButtonTextProperty); }
            set { SetValue(ButtonTextProperty, value); }
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OnClick();
        }

        public event RoutedEventHandler Click;

        protected virtual void OnClick()
        {
            Click?.Invoke(this, new RoutedEventArgs());
        }
    }
}