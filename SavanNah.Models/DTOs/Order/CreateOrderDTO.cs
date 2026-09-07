using SavanNah.Models.Models.ProductModel;

namespace SavanNah.Models.DTOs.Order
{
    public class CreateOrderDTO
    {
        public decimal TotalAmount { get; set; }
        public Guid UserId { get; set; }
        public List<Product> Products { get; set; }
        public List<CreateOrderProductDTO> OrderProducts { get; set; }
    }
}
