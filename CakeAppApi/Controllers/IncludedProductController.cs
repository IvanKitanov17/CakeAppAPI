using CakeAppApi.Data;
using CakeAppApi.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CakeAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncludedProductController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public IncludedProductController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UpdateIncludedProductDto>>> GetAllIncludedProducts()
        {
            var allIncludedProducts = dbContext.IncludedProducts.ToList();
            var includedProductDtos = allIncludedProducts.Select(p => MapIncludedProductToDto(p)).ToList();

            return includedProductDtos;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<IEnumerable<UpdateIncludedProductDto>>> GetIncludedProductById(Guid id)
        {
            var includedProduct = await dbContext.IncludedProducts.FindAsync(id);
            if (includedProduct == null)
            {
                return NotFound();
            }

            var list = new List<UpdateIncludedProductDto> { MapIncludedProductToDto(includedProduct) };
            return list;
        }


        [HttpPost]
        public async Task<ActionResult<IncludedProduct>> PostIncludedProduct(AddIncludedProductDto includedProduct)
        {
            var includedProductEntity = new IncludedProduct()            {
                
                ProductId = includedProduct.ProductId,
                Price = includedProduct.Price,
                Quantity = includedProduct.Quantity,
                OrderId = includedProduct.OrderId
            };

            dbContext.IncludedProducts.Add(includedProductEntity);
            dbContext.SaveChanges();
            return includedProductEntity;
        }
                

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult PutIncludedProduct(Guid id, UpdateIncludedProductDto includedProduct)
        {
            var updatedIncludedProduct = dbContext.IncludedProducts.Find(id);
            if (includedProduct is null)
            {
                return NotFound();
            }

            updatedIncludedProduct.Price = includedProduct.Price;
            updatedIncludedProduct.Quantity = includedProduct.Quantity;
            updatedIncludedProduct.OrderId = includedProduct.OrderId;

            dbContext.SaveChanges();
            return Ok(includedProduct);
        }

        [HttpDelete]
        public IActionResult DeleteIncludedProduct(Guid id)
        {
            var includedProduct = dbContext.IncludedProducts.Find(id);
            if (includedProduct is null)
            {
                return NotFound();
            }

            dbContext.IncludedProducts.Remove(includedProduct);
            dbContext.SaveChanges();
            return Ok(includedProduct);
        }

        private UpdateIncludedProductDto MapIncludedProductToDto(IncludedProduct includedProduct)
        {
            return new UpdateIncludedProductDto
            {
                IncludedProductId = includedProduct.IncludedProductId,
                ProductId = includedProduct.ProductId,                
                Price = includedProduct.Price,
                Quantity = includedProduct.Quantity,
                OrderId = includedProduct.OrderId
            };
        }
    }
}
