namespace Application.Orders.Queries.GetOrdersPerUser
{
    using Amazon.DynamoDBv2.DocumentModel;
    using Common.Handlers;
    using Common.Interfaces;
    using Domain.Entities;
    using MediatR;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetOrdersPerUserQuery : IRequest<List<Order>>
    {
        public string UserId { get; set; }
    }

    public class GetOrderQueryHandler : CommonHandler<GetOrdersPerUserQuery, List<Order>>
    {
        public GetOrderQueryHandler(IApplicationDbContext dbContext) : base(dbContext) { }

        public override async Task<List<Order>> Handle(GetOrdersPerUserQuery request, CancellationToken cancellationToken)
        {
            var search = DbContext.QueryAsync<Order>($"USER#{request.UserId}", QueryOperator.BeginsWith, new[] { "ORDER#" });
            var orders = await search.GetRemainingAsync(cancellationToken);
            return orders;
        }
    }
}
