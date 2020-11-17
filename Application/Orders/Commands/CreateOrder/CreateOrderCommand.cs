namespace Application.Orders.Commands.CreateOrder
{
    using Amazon.Util;
    using Common.Handlers;
    using Common.Interfaces;
    using Domain.Entities;
    using Domain.Enums;
    using MediatR;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateOrderCommand : IRequest<string>
    {
        public string UserId { get; set; }
    }

    public class CreateOrderCommandHandler : CommonHandler<CreateOrderCommand, string>
    {
        public CreateOrderCommandHandler(IApplicationDbContext dbContext) : base(dbContext) { }

        public override async Task<string> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var id = Guid.NewGuid();
            var order = new Order
            {
                UserId = $"USER#{request.UserId}",
                OrderId = $"ORDER#{id}",
                OrderState = OrderState.Pending,
                CreatedAt = DateTime.UtcNow.ToString(AWSSDKUtils.ISO8601DateFormat)
            };

            await DbContext.SaveAsync(order, cancellationToken);

            return id.ToString();
        }
    }
}
