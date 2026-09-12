using SavanNah.Models.Models.PaymentModel;
using SavanNah.Models.Models.UserModel;

namespace SavanNah.Models.Models.OrderModel
{
    public class Order
    {
        public Guid Id { get; set; }
        public string Status { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public Guid UserId { get; set; }
        public User User { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; }
        public Payment Payment { get; set; }
    }
}
