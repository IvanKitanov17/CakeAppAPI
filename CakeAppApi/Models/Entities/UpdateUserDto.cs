namespace CakeAppApi.Models.Entities
{
    public class UpdateUserDto
    {
        public Guid UserId { get; set; }
        public required string Name { get; set; }  
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
