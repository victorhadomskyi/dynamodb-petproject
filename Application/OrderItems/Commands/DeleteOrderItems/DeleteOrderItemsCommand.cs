namespace Application.OrderItems.Commands.DeleteOrderItems
{
    using Common.Handlers;
    using Common.Interfaces;
    using MediatR;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Entities;

    public class DeleteOrderItemsCommand : IRequest
    {
        public string OrderId { get; set; }
        public List<string> OrderItemsIds { get; set; }
    }

    public class DeleteOrderItemsCommandHandler : CommonHandler<DeleteOrderItemsCommand, Unit>
    {
        public DeleteOrderItemsCommandHandler(IApplicationDbContext dbContext) : base(dbContext) { }

        public override async Task<Unit> Handle(DeleteOrderItemsCommand request, CancellationToken cancellationToken)
        {
            var orderItemsBatchWrite = DbContext.CreateBatchWrite<OrderItem>();
            foreach (var orderItemId in request.OrderItemsIds)
            {
                orderItemsBatchWrite.AddDeleteKey($"ORDER#{request.OrderId}", $"ITEM#{orderItemId}");
            }
            await orderItemsBatchWrite.ExecuteAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
