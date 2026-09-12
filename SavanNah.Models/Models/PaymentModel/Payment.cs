using SavanNah.Models.Models.OrderModel;
using SavanNah.Models.Models.UserModel;

namespace SavanNah.Models.Models.PaymentModel
{
    public class Payment
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
        public DateTime PaymentDate { get; set; } = DateTime.Now;
    }
}
