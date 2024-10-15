namespace CakeAppApi.Models.Entities
{
    public class AddIncludedProductDto
    {
        public Guid ProductId { get; set; }
        public required decimal Price { get; set; }
        public required int Quantity { get; set; }
        public Guid? OrderId { get; set; }
    }
}
