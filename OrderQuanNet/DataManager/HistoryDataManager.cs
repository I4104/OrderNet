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
        public static bool isUpdated = false;

        public static List<OrdersModel> OrdersHistory = new List<OrdersModel>();
        public static readonly Dictionary<string, string> StatusMappings = new Dictionary<string, string>
        {
            { "WAITING", "Đang chờ xác nhận" },
            { "PROCCESSING", "Đang xử lý" },
            { "DONE", "Đã hoàn thành" }
        };

        public static void LoadHistory()
        {
            OrdersHistory.Clear();

            OrdersService ordersService = new OrdersService();
            List<OrdersModel> orders = ordersService.GetAllOrders(new OrdersModel() { users_id = SessionManager.users.id });
            foreach (var item in orders)
            {
                item.status = StatusMappings[item.status];
                OrdersHistory.Add(item);
            }
        }

    }
}
