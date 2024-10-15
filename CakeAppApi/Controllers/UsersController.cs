using CakeAppApi.Data;
using CakeAppApi.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CakeAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public UsersController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UpdateUserDto>>> GetAllUsers() 
        {
            var allUsers = dbContext.Users.ToList();
            var userDtos = allUsers.Select(p => MapUserToDto(p)).ToList();

            return userDtos;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<IEnumerable<UpdateUserDto>>> GetUserById(Guid id)
        {
            var user = await dbContext.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var list = new List<UpdateUserDto> { MapUserToDto(user) };
            return list;
        }
        

        [HttpPost]
        public async Task<ActionResult<User>> PostUser(AddUserDto user)
        {
            var userEntity = new User()
            {
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
            };

            dbContext.Users.Add(userEntity);
            dbContext.SaveChanges();
            return userEntity;
        }
                

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult PutUser(Guid id, UpdateUserDto user) 
        {
            var updatedUser = dbContext.Users.Find(id);
            if (user is null)
            {
                return NotFound();
            }
           
            updatedUser.Name = user.Name;
            updatedUser.Email = user.Email;
            updatedUser.Password = user.Password;

            dbContext.SaveChanges();
            return Ok(user);
        }

        [HttpDelete]
        public IActionResult DeleteUser(Guid id) 
        {
            var user = dbContext.Users.Find(id);
            if (user is null)
            {
                return NotFound();
            }

            dbContext.Users.Remove(user);
            dbContext.SaveChanges();
            return Ok(user);
        }
        private UpdateUserDto MapUserToDto(User user)
        {
            return new UpdateUserDto
            {
                UserId = user.UserId,
                Name = user.Name,
                Email = user.Email,
                Password = user.Password
            };
        }
    }
}
