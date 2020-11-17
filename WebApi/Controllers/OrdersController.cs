namespace WebApi.Controllers
{
    using Application.OrderItems.Commands.AddOrderItems;
    using Application.OrderItems.Commands.DeleteOrderItems;
    using Application.OrderItems.Dto;
    using Application.Orders.Commands.CreateOrder;
    using Application.Orders.Queries.GetOrdersPerUser;
    using Domain.Entities;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class OrdersController : ApiController
    {
        [HttpPost]
        public async Task<ActionResult<string>> Create(CreateOrderCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet]
        public async Task<ActionResult<List<Order>>> Get([FromQuery] string userId)
        {
            return await Mediator.Send(new GetOrdersPerUserQuery { UserId = userId });
        }

        [HttpPost("{orderId}/items")]
        public async Task<ActionResult> AddItems([FromRoute] string orderId, [FromBody] List<OrderItemDto> orderItems)
        {
            await Mediator.Send(new AddOrderItemsCommand {OrderId = orderId, OrderItems = orderItems});
            return Ok();
        }

        [HttpDelete("{orderId}/items")]
        public async Task<ActionResult> DeleteItems([FromRoute] string orderId, [FromBody] List<string> orderItemsIds)
        {
            await Mediator.Send(new DeleteOrderItemsCommand {OrderId = orderId, OrderItemsIds = orderItemsIds});
            return Ok();
        }
    }
}
