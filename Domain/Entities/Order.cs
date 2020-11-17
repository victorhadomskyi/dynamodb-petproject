namespace Domain.Entities
{
    using System.Collections.Generic;
    using Amazon.DynamoDBv2.DataModel;
    using Enums;

    [DynamoDBTable("OrdersCatalog")]
    public class Order
    {
        [DynamoDBHashKey("PK")]
        public string UserId { get; set; }
        [DynamoDBRangeKey("SK")]
        public string OrderId { get; set; }
        public OrderState OrderState { get; set; }
        public string CreatedAt { get; set; }
        public int TableIndex { get; set; }
    }
}
