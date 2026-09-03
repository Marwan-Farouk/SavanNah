using SavanNah.Models.Models.ProductModel;
using SavanNah.Models.Models.UserModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SavanNah.Models.Models.CartModel
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public int Count { get; set; }
        public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

    }
}
