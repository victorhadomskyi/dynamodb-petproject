namespace Application.Menu.Queries.GetMenuGroups
{
    using MediatR;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Common.Handlers;
    using Common.Interfaces;
    using Domain.Entities;

    public class GetMenuGroupsQuery : IRequest<List<string>>
    {

    }

    public class GetMenuGroupsQueryHandler : CommonHandler<GetMenuGroupsQuery, List<string>>
    {
        public GetMenuGroupsQueryHandler(IApplicationDbContext dbContext) : base(dbContext) { }

        public override Task<List<string>> Handle(GetMenuGroupsQuery request, CancellationToken cancellationToken)
        {
            return DbContext.GetMenuGroupsAsync();
        }
    }
}
