namespace CakeAppApi.Models.Entities
{
    public class UpdateProductDto
    {
        public Guid ProductId { get; set; }
        public required string ProductName { get; set; }
        public required decimal Price { get; set; }
        public required string ProductDescription { get; set; }
        public required string? ImageURL { get; set; }
    }
}
