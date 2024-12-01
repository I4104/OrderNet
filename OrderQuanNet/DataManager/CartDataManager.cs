using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderQuanNet.Models;
using OrderQuanNet.Services;

namespace OrderQuanNet.DataManager
{
    public static class CartDataManager
    {
        public static Dictionary<int, int> cartItems = new Dictionary<int, int>();

        public static void addItem(int item)
        {
            if (cartItems.ContainsKey(item))
            {
                cartItems[item]++;
            }
            else
            {
                cartItems.Add(item, 1);
            }
        }
        public static void removeItem(int item)
        {
            if (cartItems.ContainsKey(item)) cartItems.Remove(item);
        }

        public static int getTotalItems()
        {
            return cartItems.Values.Sum();
        }

        public static decimal getTotalPrice()
        {
            ProductsService productsService = new ProductsService();
            return (decimal)cartItems.Sum(item => productsService.GetById(item.Key).price * item.Value);
        }
    }
}
