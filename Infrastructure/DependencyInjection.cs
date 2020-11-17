namespace Infrastructure
{
    using Amazon;
    using Amazon.DynamoDBv2;
    using Application.Common.Interfaces;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Persistence;

    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            //var clientConfig = new AmazonDynamoDBConfig
            //{
            //    ServiceURL = "http://localhost:8000",
            //    RegionEndpoint = RegionEndpoint.USEast1
            //};

            var clientConfig = new AmazonDynamoDBConfig
            {
                RegionEndpoint = RegionEndpoint.EUWest2
            };

            var client = new AmazonDynamoDBClient("AKIARFPXJDC3JBP5EE47", "h9rcF4kRyWbbSF6+gkpUdgy33BuHNGrbxocIaxpQ", clientConfig);
            services.AddScoped<IApplicationDbContext>(_ => new ApplicationDbContext(client));

            return services;
        }
    }
}
