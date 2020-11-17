namespace Domain.Entities
{
    using Amazon.DynamoDBv2.DataModel;

    [DynamoDBTable("OrdersCatalog")]
    public class OrderItem
    {
        [DynamoDBHashKey("PK")]
        public string OrderId { get; set; }
        [DynamoDBRangeKey("SK")]
        public string OrderItemId { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int Count { get; set; }
        public string MenuGroup { get; set; }
        public string MenuItemId { get; set; }
    }
}
