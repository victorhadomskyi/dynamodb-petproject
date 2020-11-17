namespace Application.Users.Commands.CreateUser
{
    using Common.Interfaces;
    using Domain.Entities;
    using MediatR;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Common.Handlers;

    public class CreateUserCommand : IRequest<string>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Age { get; set; }
    }

    public class CreateUserCommandHandler : CommonHandler<CreateUserCommand, string>
    {
        public CreateUserCommandHandler(IApplicationDbContext dbContext) : base(dbContext) { }

        public override async Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var id = Guid.NewGuid();
            var user = new User
            {
                UserId = $"USER#{id}",
                Age = request.Age,
                Name = request.Name,
                Surname = request.Surname,
                Profile = $"#PROFILE#{id}"
            };

            await DbContext.SaveAsync(user, cancellationToken);

            return id.ToString();
        }
    }
}
