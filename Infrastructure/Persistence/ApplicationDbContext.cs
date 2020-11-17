namespace Infrastructure.Persistence
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Amazon.DynamoDBv2;
    using Amazon.DynamoDBv2.DataModel;
    using Application.Common.Interfaces;
    using Domain.Entities;

    internal class ApplicationDbContext : DynamoDBContext, IApplicationDbContext
    {
        public ApplicationDbContext(IAmazonDynamoDB client) : base(client)
        {
        }

        public ApplicationDbContext(IAmazonDynamoDB client, DynamoDBContextConfig config) : base(client, config)
        {
        }

        public async Task<List<string>> GetMenuGroupsAsync()
        {
            var menu = await LoadAsync<Menu>("MENU", "MENU");
            return menu.MenuGroups;
        }
    }
}
