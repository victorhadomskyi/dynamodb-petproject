namespace Domain.Entities
{
    using Amazon.DynamoDBv2.DataModel;

    [DynamoDBTable("OrdersCatalog")]
    public class User
    {
        [DynamoDBHashKey("PK")]
        public string UserId { get; set; }
        [DynamoDBRangeKey("SK")]
        public string Profile { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Age { get; set; }
    }
}
