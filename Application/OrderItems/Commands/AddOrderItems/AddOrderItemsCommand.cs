namespace Application.OrderItems.Commands.AddOrderItems
{
    using System;
    using Common.Handlers;
    using Common.Interfaces;
    using MediatR;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Entities;
    using Dto;

    public class AddOrderItemsCommand : IRequest
    {
        public string OrderId { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
    }

    public class AddOrderItemsCommandHandler : CommonHandler<AddOrderItemsCommand, Unit>
    {
        public AddOrderItemsCommandHandler(IApplicationDbContext dbContext) : base(dbContext) { }

        public override async Task<Unit> Handle(AddOrderItemsCommand request, CancellationToken cancellationToken)
        {
            var orderItems = request.OrderItems.Select(item =>
                new OrderItem
                {
                    OrderId = $"ORDER#{request.OrderId}",
                    OrderItemId = $"ITEM#{Guid.NewGuid()}",
                    Name = item.Name,
                    Price = item.Price,
                    Count = item.Count,
                    MenuGroup = item.MenuGroup,
                    MenuItemId = item.MenuItemId
                });
            var orderItemsBatchWrite = DbContext.CreateBatchWrite<OrderItem>();
            orderItemsBatchWrite.AddPutItems(orderItems);
            await orderItemsBatchWrite.ExecuteAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
