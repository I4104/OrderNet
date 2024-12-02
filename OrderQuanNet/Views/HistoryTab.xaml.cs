﻿using OrderQuanNet.DataManager;
using OrderQuanNet.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace OrderQuanNet.Views
{
    public class HistoryItem
    {
        public int id { get; set; }
        public string name { get; set; }
        public string image_path { get; set; }
        public decimal price { get; set; }
        public string status { get; set; }
        public int amount { get; set; }
    }

    public partial class HistoryTab : UserControl
    {
        public HistoryTab()
        {
            InitializeComponent();
            loadHistory();
        }

        private void loadHistory()
        {
            HistoryDataManager.LoadHistory();
            List<OrdersModel> history = HistoryDataManager.OrdersHistory;

            List<HistoryItem> items = new List<HistoryItem>();
            foreach (var item in history)
            {
                ProductsModel product = ProductDataManager.Products.Where(p => p.id == item.product_id).FirstOrDefault();
                items.Add(new HistoryItem
                {
                    id = item.id.Value,
                    amount = item.amount.Value,
                    status = item.status,
                    name = product.name,
                    image_path = product.image_path,
                    price = product.price.Value,
                });
            }

            HistoryItemsControl.ItemsSource = items;
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
            double itemHeight = 105;
            int rowCount = (int)((this.ActualHeight - 45) / itemHeight);
            UniformGrid uniformGrid = FindUniformGrid(HistoryItemsControl);
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
