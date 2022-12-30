namespace DataAccess.Models
{
    public class ProductModel: CommonModel
    {
        public decimal Price { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public int Quantity { get; set; }
    }
}
