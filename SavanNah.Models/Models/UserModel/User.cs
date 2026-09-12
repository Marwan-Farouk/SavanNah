using Microsoft.AspNetCore.Identity;
using SavanNah.Models.Models.OrderModel;
using SavanNah.Models.Models.PaymentModel;

namespace SavanNah.Models.Models.UserModel
{
    public class User : IdentityUser<Guid>
    {
        public ICollection<Order> Orders { get; set; }
        public ICollection<Payment> Payments { get; set; }
    }
}
