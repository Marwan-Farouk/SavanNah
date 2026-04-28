using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SavanNah.Models.Models
{
    public class Category
    {
        public int Id { get; set; }
        [DisplayName("Name")]
        [MaxLength(30)]
        public required string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(0, 200)]
        public int DisplayOrder { get; set; }
    }
}
