using SavanNah.Models.Models.ProductModel;

namespace SavanNah.Models.DTOs.Order
{
    public class CreateOrderDTO
    {
        public string Status { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public Guid UserId { get; set; }
        public List<Product> Products { get; set; }
    }
}
