using CakeAppApi.Data;
using CakeAppApi.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CakeAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomCakeController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public CustomCakeController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UpdateCustomCakeDto>>> GetAllCustomCakess()
        {
            var allcustomCakes = dbContext.CustomCakes.ToList();
            var customCakeDtos = allcustomCakes.Select(p => MapCustomCakeToDto(p)).ToList();

            return customCakeDtos;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<IEnumerable<UpdateCustomCakeDto>>> GetCustomCakeById(Guid id)
        {
            var customCake = await dbContext.CustomCakes.FindAsync(id);
            if (customCake == null)
            {
                return NotFound();
            }

            var list = new List<UpdateCustomCakeDto> { MapCustomCakeToDto(customCake) };
            return list;
        }


        [HttpPost]
        public async Task<ActionResult<CustomCake>> PostCustomCake(AddCustomCakeDto customCake)
        {
            var customCakeEntity = new CustomCake()
            {
                OrderId = customCake.OrderId,
                CakeForm = customCake.CakeForm,
                CakeFilling = customCake.CakeFilling,
                HasSugarDecoration = customCake.HasSugarDecoration,
                AdditionalCakeLayer = customCake.AdditionalCakeLayer,
                NumberOfSlices = customCake.NumberOfSlices,
                NumberOfFloor = customCake.NumberOfFloor,
                Description = customCake.Description,
                ImageURL = customCake.ImageURL,
            };

            dbContext.CustomCakes.Add(customCakeEntity);
            dbContext.SaveChanges();
            return customCakeEntity;
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult PutCustomCake(Guid id, UpdateCustomCakeDto customCake)
        {
            var updatedCustomCake = dbContext.CustomCakes.Find(id);
            if (customCake is null)
            {
                return NotFound();
            }

            updatedCustomCake.OrderId = customCake.OrderId;
            updatedCustomCake.CakeForm = customCake.CakeForm;
            updatedCustomCake.CakeFilling = customCake.CakeFilling;
            updatedCustomCake.HasSugarDecoration = customCake.HasSugarDecoration;
            updatedCustomCake.AdditionalCakeLayer = customCake.AdditionalCakeLayer;
            updatedCustomCake.NumberOfSlices = customCake.NumberOfSlices;
            updatedCustomCake.NumberOfFloor = customCake.NumberOfFloor;
            updatedCustomCake.Description = customCake.Description;
            updatedCustomCake.ImageURL = customCake.ImageURL;

            dbContext.SaveChanges();
            return Ok(customCake);
        }

        [HttpDelete]
        public IActionResult DeleteCustomCake(Guid id)
        {
            var customCake = dbContext.CustomCakes.Find(id);
            if (customCake is null)
            {
                return NotFound();
            }

            dbContext.CustomCakes.Remove(customCake);
            dbContext.SaveChanges();
            return Ok(customCake);
        }

        private UpdateCustomCakeDto MapCustomCakeToDto(CustomCake customCake)
        {
            return new UpdateCustomCakeDto
            {
                OrderId = customCake.OrderId,
                CakeForm = customCake.CakeForm,
                CakeFilling = customCake.CakeFilling,
                HasSugarDecoration = customCake.HasSugarDecoration,
                AdditionalCakeLayer = customCake.AdditionalCakeLayer,
                NumberOfSlices = customCake.NumberOfSlices,
                NumberOfFloor = customCake.NumberOfFloor,
                Description = customCake.Description,
                ImageURL = customCake.ImageURL
            };
        }
    }
}

