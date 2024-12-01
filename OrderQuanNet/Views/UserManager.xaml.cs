using System.Windows;
using System.Windows.Controls;

namespace OrderQuanNet.Views
{
    public partial class UserManager : UserControl
    {
        public UserManager()
        {
            InitializeComponent();
        }

        private bool IsAdmin = true;

        private void UserManagerControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            UpdateRows();
        }
        private void UserManagerControl_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateRows();
            if (IsAdmin)
            {
                AddButton.Visibility = Visibility.Visible;
                DownloadButton.Visibility = Visibility.Visible;

            }
            else
            {
                AddButton.Visibility = Visibility.Collapsed;
                DownloadButton.Visibility = Visibility.Collapsed;


            }
        }

        private void UpdateRows()
        {
            double itemWidth = 160;
            int rowCount = (int)(this.ActualWidth / itemWidth);
            UserManagerGrid.Columns = rowCount;
        }


        private void DynamicButtonClick(object sender, RoutedEventArgs e)
        {
            if (IsAdmin)
            {
                EditPopupUserManager(sender, e);
            }

        }

        private void EditPopupUserManager(object sender, RoutedEventArgs e)
        {
            EditPopup editWindow = new EditPopup();
            editWindow.ShowDialog();
        }
        private void AddUserManager(object sender, RoutedEventArgs e)
        {
            Add addWindow = new Add();
            addWindow.ShowDialog();
        }
        private void Download(object sender, RoutedEventArgs e)
        {
            Download downloadWindow = new Download();
            downloadWindow.ShowDialog();
        }
    }
}
