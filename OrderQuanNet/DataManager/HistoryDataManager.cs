using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderQuanNet.Models;
using OrderQuanNet.Services;

namespace OrderQuanNet.DataManager
{
    public static class HistoryDataManager
    {
        public static List<OrdersModel> OrdersHistory = new List<OrdersModel>();

        public static void LoadHistory()
        {
            OrdersService ordersService = new OrdersService();
        }

    }
}
