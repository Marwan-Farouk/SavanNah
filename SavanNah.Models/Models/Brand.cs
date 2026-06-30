using System.ComponentModel;

namespace SavanNah.Models.Models
{
    public class Brand
    {
        public int Id { get; set; }
        [DisplayName("Name")]

        public required string Name { get; set; }
        [DisplayName("Description")]
        public required string Description { get; set; }
    }
}
