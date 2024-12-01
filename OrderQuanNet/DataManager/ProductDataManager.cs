﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderQuanNet.Models;
using OrderQuanNet.Services;

namespace OrderQuanNet.DataManager
{
    public static class ProductDataManager
    {
        private static List<ProductsModel> _products = new List<ProductsModel>();

        public static List<ProductsModel> Products
        {
            get { return _products; }
            set { _products = value; }
        }

        public static void UpdateProduct(ProductsModel product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product), "Product cannot be null.");
            var id = _products.FindIndex(p => p.id == product.id);
            if (id != -1) _products[id] = product;
        }

        public static void LoadProducts()
        {
            ProductsService productsService = new ProductsService();
            ProductDataManager.Products = productsService.GetAll();
        }
    }
}
