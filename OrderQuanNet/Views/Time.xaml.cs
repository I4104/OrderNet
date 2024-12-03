﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using OrderQuanNet.DataManager;

namespace OrderQuanNet.Views
{
    public partial class Time : UserControl
    {
        public Time()
        {
            InitializeComponent();
            LoadTimeProducts();
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

            components.popup.Detail detailWindow = new components.popup.Detail(int.Parse(button.Tag.ToString()));
            detailWindow.ShowDialog();
        }

        private void EditPopup(object sender, RoutedEventArgs e)
        {
            components.popup.EditPopup editWindow = new components.popup.EditPopup();
            editWindow.ShowDialog();
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            components.popup.Add addWindow = new components.popup.Add();
            addWindow.ShowDialog();
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
    }
}
