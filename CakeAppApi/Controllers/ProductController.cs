using CakeAppApi.Data;
using CakeAppApi.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CakeAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public ProductController(ApplicationDbContext dbContext) 
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UpdateProductDto>>> GetAllProducts()
        {
            var products = await dbContext.Products.ToListAsync();
            var productDtos = products.Select(p => MapProductToDto(p)).ToList();

            return productDtos;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<IEnumerable<UpdateProductDto>>> GetProductById(Guid id)
        {
            var product = await dbContext.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            var list = new List<UpdateProductDto> { MapProductToDto(product) };
            return list;
        }

        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(AddProductDto product)
        {
            var productEntity = new Product()
            {
                ProductName = product.ProductName,
                Price = product.Price,
                ProductDescription = product.ProductDescription,
                ImageURL = product.ImageURL,
            };

            dbContext.Products.Add(productEntity);
            dbContext.SaveChanges();
            return productEntity;
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> PutProduct(Guid id, UpdateProductDto productDto)
        {
            var productEntity = await dbContext.Products.FindAsync(id);
            if (productEntity == null)
            {
                return NotFound();
            }

            
            productEntity.ProductName = productDto.ProductName;
            productEntity.Price = productDto.Price;
            productEntity.ProductDescription = productDto.ProductDescription;
            productEntity.ImageURL = productDto.ImageURL;

            await dbContext.SaveChangesAsync();
            return (IActionResult)MapProductToDto(productEntity);
        }


        [HttpDelete]
        public IActionResult DeleteProduct(Guid id)
        {
            var product = dbContext.Products.Find(id);
            if (product is null)
            {
                return NotFound();
            }

            dbContext.Products.Remove(product);
            dbContext.SaveChanges();
            return Ok(product);
        }
               
        private UpdateProductDto MapProductToDto(Product product)
        {
            return new UpdateProductDto
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                Price = product.Price,
                ProductDescription = product.ProductDescription,
                ImageURL = product.ImageURL
            };
        }
    }
}

