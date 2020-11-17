namespace Application.Users.Queries.GetUser
{
    using Common.Handlers;
    using Common.Interfaces;
    using Domain.Entities;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetUserQuery : IRequest<User>
    {
        public string UserId { get; set; }
    }

    public class GetUserQueryHandler : CommonHandler<GetUserQuery, User>
    {
        public GetUserQueryHandler(IApplicationDbContext dbContext) : base(dbContext) { }

        public override async Task<User> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await DbContext.LoadAsync<User>($"USER#{request.UserId}", $"#PROFILE#{request.UserId}", cancellationToken);
            return user;
        }
    }
}
