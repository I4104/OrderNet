using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using OrderQuanNet.Views;
using OrderQuanNet.Views.components;

namespace OrderQuanNet
{
    public partial class Main : Window
    {
        private enum TabType { Food, Drink, Time }
        private enum RightBarType { Orders, History }

        private TabType currentTab = TabType.Food;
        private RightBarType currentRightBar = RightBarType.Orders;

        
        public Main()
        {
            InitializeComponent();
            SetInitialContent();
        }
        private void SetInitialContent()
        {

            ContentManager.Content = new Food();
            RightBarManager.Content = new OrdersTab();
            SwitchOrderOrHistory(OrderTab);
        }
        
        /**
          Xử lý logic
         */









        /**
            Xử lý sự kiện của APP
         */
        private void OrderToggle(object sender, EventArgs e) { SwitchRightBar(RightBarType.Orders); }

        private void HistoryToggle(object sender, EventArgs e) { SwitchRightBar(RightBarType.History); }

        private void FoodTab(object sender, EventArgs e) { SwitchTab(TabType.Food, new Food()); }

        private void DrinkTab(object sender, EventArgs e) { SwitchTab(TabType.Drink, new Drink()); }

        private void TimeTab(object sender, EventArgs e) { SwitchTab(TabType.Time, new Time()); }

        private void SwitchTab(TabType tabType, ContentControl content)
        {
            currentTab = tabType;
            ActiveTab(tabType);
            ContentManager.Content = content;
        }

        private void SwitchRightBar(RightBarType rightBarType)
        {
            currentRightBar = rightBarType;
            switch (currentRightBar)
            {
                case RightBarType.Orders:
                    RightBarManager.Content = new OrdersTab();
                    break;
                case RightBarType.History:
                    RightBarManager.Content = new HistoryTab();
                    break;
            }
            SwitchOrderOrHistory(currentRightBar == RightBarType.Orders ? OrderTab : HistoryTab);
        }

        private void ActiveTab(TabType tabType)
        {
            FoodTabItem.ItemActive = tabType == TabType.Food ? "true" : "false";
            DrinkTabItem.ItemActive = tabType == TabType.Drink ? "true" : "false";
            TimeTabItem.ItemActive = tabType == TabType.Time ? "true" : "false";
        }

        private void SwitchOrderOrHistory(TextBlock tab)
        {
            OrderTab.Foreground = HistoryTab.Foreground = new SolidColorBrush(Colors.Black);
            tab.Foreground = new SolidColorBrush(Colors.Red);
        }

        private void ReloadLayouts(object sender, EventArgs e)
        {
            Sidebar.Height = this.ActualHeight - 50;
            OrderAndHistory.Height = this.ActualHeight - 50;

            TabControl.Height = this.ActualHeight - 55;
            RightBarManager.Height = this.ActualHeight - 100;
            RightBarManager.Width = OrderAndHistory.ActualWidth - 20;

            Menu.Height = Sidebar.Height - 175;
            ContentManager.Height = this.ActualHeight - 55;
            ContentManager.Width = this.ActualWidth - 275 * 2;

            switch (currentRightBar)
            {
                case RightBarType.Orders:
                    RightBarManager.Content = new OrdersTab();
                    break;
                case RightBarType.History:
                    RightBarManager.Content = new HistoryTab();
                    break;
            }

            switch (currentTab)
            {
                case TabType.Food:
                    ContentManager.Content = new Food();
                    break;
                case TabType.Drink:
                    ContentManager.Content = new Drink();
                    break;
                case TabType.Time:
                    ContentManager.Content = new Time();
                    break;
            }
        }
    }
}
