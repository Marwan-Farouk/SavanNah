using Microsoft.AspNetCore.Identity;
using SavanNah.Models.Models.OrderModel;

namespace SavanNah.Models.Models.UserModel
{
    public class User : IdentityUser<Guid>
    {
        public ICollection<Order> Orders { get; set; }
    }
}
