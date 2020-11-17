namespace Application.Menu.Commands.UpdateMenuGroups
{
    using Common.Handlers;
    using Common.Interfaces;
    using MediatR;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Entities;

    public class UpdateMenuGroupsCommand : IRequest
    {
        public List<string> MenuGroups { get; set; }
    }

    public class UpdateMenuGroupsCommandHandler : CommonHandler<UpdateMenuGroupsCommand, Unit>
    {
        public UpdateMenuGroupsCommandHandler(IApplicationDbContext dbContext) : base(dbContext) { }

        public override async Task<Unit> Handle(UpdateMenuGroupsCommand request, CancellationToken cancellationToken)
        {
            var menu = new Menu
            {
                MenuGroups = request.MenuGroups
            };

            await DbContext.SaveAsync(menu, cancellationToken);

            return Unit.Value;
        }
    }
}
