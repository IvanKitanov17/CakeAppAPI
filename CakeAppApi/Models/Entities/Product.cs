namespace CakeAppApi.Models.Entities
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public required string ProductName { get; set; }
        public required decimal Price { get; set; }        
        public required string ProductDescription { get; set; }
        public required string? ImageURL { get; set; }
    }
}
