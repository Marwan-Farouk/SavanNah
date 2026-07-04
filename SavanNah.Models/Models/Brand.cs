using System.ComponentModel;

namespace SavanNah.Models.Models
{
    public class Brand
    {
        public int Id { get; set; }
        [DisplayName("Name")]

        public required string Name { get; set; }
        [DisplayName("Description")]
        public string? Description { get; set; }

        public ICollection<Product> Products { get; set; } = [];
    }
}
