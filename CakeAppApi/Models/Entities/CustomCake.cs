namespace CakeAppApi.Models.Entities
{
    public class CustomCake
    {
        public Guid CustomCakeId { get; set; }
        public Guid OrderId { get; set; }
        public required string CakeForm { get; set; }
        public required bool HasSugarDecoration { get; set; }
        public required string CakeFilling { get; set; }
        public required string AdditionalCakeLayer { get; set; }
        public required int NumberOfSlices { get; set; }
        public required int NumberOfFloor { get; set; }
        public required string Description { get; set; }

        public string? ImageURL { get; set; }
    }
}
