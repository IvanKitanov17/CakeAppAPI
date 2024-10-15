namespace CakeAppApi.Models.Entities
{
    public class UpdateOrderDto
    {
        public Guid OrderId { get; set; }
        public Guid UserId { get; set; }
        public required string UserName { get; set; }
        public required DateTime DateCreated { get; set; }
        public required DateTime DeliveryDate { get; set; }

        public List<CustomCake> CustomCakes { get; set; } = new List<CustomCake>();
        public required List<IncludedProduct> IncludedProducts { get; set; } = new List<IncludedProduct>();
        public required decimal TotalPrice { get; set; }
    }
}
