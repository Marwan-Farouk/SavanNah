namespace SavanNah.Models.Models
{
    public class CategoryProduct
    {
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        public int ProductsId { get; set; }
        public Product? Products { get; set; }
    }
}
