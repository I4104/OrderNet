namespace OrderQuanNet.Models
{
    public class OrdersModel
    {
        public int? id { get; set; }
        public int? users_id { get; set; }
        public int? product_id { get; set; }
        public int? amount { get; set; }
        public int? price { get; set; }
        public string? status { get; set; }
        public string? created_at { get; set; }
        public string? updated_at { get; set; }
    }
}
