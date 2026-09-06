using SavanNah.Models.Models.ProductModel;

namespace SavanNah.Models.Models.OrderModel
{
    public class OrderProduct
    {
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Count { get; set; }
    }
}
