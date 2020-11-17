namespace Application.Users.Queries.GetUsers
{
    using Common.Handlers;
    using Common.Interfaces;
    using Domain.Entities;
    using MediatR;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Amazon.DynamoDBv2.DataModel;
    using Amazon.DynamoDBv2.DocumentModel;
    using AutoMapper;
    using ViewModels.Users;

    public class GetUsersQuery : IRequest<List<UserInfoVm>>
    {

    }

    public class GetUsersQueryHandler : CommonHandler<GetUsersQuery, List<UserInfoVm>>
    {
        private readonly IMapper _mapper;

        public GetUsersQueryHandler(IApplicationDbContext dbContext, IMapper mapper) : base(dbContext)
        {
            _mapper = mapper;
        }

        public override async Task<List<UserInfoVm>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var search = DbContext.ScanAsync<User>(new [] {
                new ScanCondition("UserId", ScanOperator.BeginsWith,  "USER#" ),
                new ScanCondition("Profile", ScanOperator.BeginsWith, "#PROFILE#")
            });

            var users = await search.GetRemainingAsync(cancellationToken);
            return users.Select(user => _mapper.Map<UserInfoVm>(user)).ToList();
        }
    }
}
