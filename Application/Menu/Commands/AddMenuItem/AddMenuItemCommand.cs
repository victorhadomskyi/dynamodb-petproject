namespace Application.Menu.Commands.AddMenuItem
{
    using Common.Handlers;
    using Common.Interfaces;
    using Domain.Entities;
    using Domain.Enums;
    using MediatR;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class AddMenuItemCommand : IRequest
    {
        public string MenuGroup { get; set; }
        public string Name { get; set; }
        public List<string> Ingredients { get; set; }
        public string ImageUrl { get; set; }
        public float Price { get; set; }
        public int Amount { get; set; }
        public MenuItemUnit Unit { get; set; }
    }

    public class AddMenuItemCommandHandler : CommonHandler<AddMenuItemCommand, Unit>
    {
        public AddMenuItemCommandHandler(IApplicationDbContext dbContext) : base(dbContext) { }

        public override async Task<Unit> Handle(AddMenuItemCommand request, CancellationToken cancellationToken)
        {
            var menuGroups = await DbContext.GetMenuGroupsAsync();
            if (menuGroups.FirstOrDefault(g => g.Equals(request.MenuGroup)) is null)
            {
                //Error handling
                return Unit.Value;
            }

            var menuItem = new MenuItem
            {
                Amount = request.Amount,
                ImageUrl = request.ImageUrl,
                Ingredients = request.Ingredients,
                MenuGroup = $"MENU#GROUP#{request.MenuGroup}",
                MenuItemId = $"MENU#ITEM#{Guid.NewGuid()}",
                Name = request.Name,
                Price = request.Price,
                Unit = request.Unit
            };

            await DbContext.SaveAsync(menuItem, cancellationToken);

            return Unit.Value;
        }
    }
}
