using CakeAppApi.Data;
using CakeAppApi.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CakeAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public OrderController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UpdateOrderDto>>> GetAllOrders()
        {
            var alllOrders = dbContext.Orders.ToList();
            var orderDtos = alllOrders.Select(p => MapOrderToDto(p)).ToList();

            return orderDtos;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<IEnumerable<UpdateOrderDto>>> GetOrderById(Guid id)
        {
            var order = await dbContext.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            var list = new List<UpdateOrderDto> { MapOrderToDto(order) };
            return list;
        }


        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(AddOrderDto order)
        {
            var orderEntity = new Order()
            {
                UserId = order.UserId,
                UserName = order.UserName,
                DateCreated = order.DateCreated,
                DeliveryDate = order.DeliveryDate,
                CustomCakes = order.CustomCakes,
                TotalPrice = order.TotalPrice,
                IncludedProducts = order.IncludedProducts,
            };

            foreach (IncludedProduct includedProduct in orderEntity.IncludedProducts)
            {
                includedProduct.OrderId = orderEntity.OrderId;
            }

            foreach (CustomCake customCake in orderEntity.CustomCakes)
            {
                customCake.OrderId = orderEntity.OrderId;
            }

            dbContext.Orders.Add(orderEntity);
            dbContext.SaveChanges();
            return orderEntity;
        }       

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult PutOrder(Guid id, UpdateOrderDto order)
        {
            var updatedOrder = dbContext.Orders.Find(id);
            if (order is null)
            {
                return NotFound();
            }

            updatedOrder.UserId = order.UserId;
            updatedOrder.UserName = order.UserName;
            updatedOrder.DateCreated = order.DateCreated;
            updatedOrder.DeliveryDate = order.DeliveryDate;
            updatedOrder.CustomCakes = order.CustomCakes;
            updatedOrder.TotalPrice = order.TotalPrice;
            updatedOrder.IncludedProducts = order.IncludedProducts;

            dbContext.SaveChanges();
            return Ok(order);
        }

        [HttpDelete]
        public IActionResult DeleteOrder(Guid id)
        {
            var order = dbContext.Orders.Find(id);
            if (order is null)
            {
                return NotFound();
            }

            dbContext.Orders.Remove(order);
            dbContext.SaveChanges();
            return Ok(order);
        }

        private UpdateOrderDto MapOrderToDto(Order order)
        {
            return new UpdateOrderDto()
            {
                OrderId = order.OrderId,
                UserId = order.UserId,
                UserName = order.UserName,
                DateCreated = order.DateCreated,
                DeliveryDate = order.DeliveryDate,
                CustomCakes = order.CustomCakes,
                TotalPrice = order.TotalPrice,
                IncludedProducts = order.IncludedProducts,
            };
        }
    }
}
