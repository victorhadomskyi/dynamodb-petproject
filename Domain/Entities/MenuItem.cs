namespace Domain.Entities
{
    using Amazon.DynamoDBv2.DataModel;
    using Enums;
    using System.Collections.Generic;

    [DynamoDBTable("OrdersCatalog")]
    public class MenuItem
    {
        [DynamoDBHashKey("PK")]
        public string MenuGroup { get; set; }
        [DynamoDBRangeKey("SK")]
        public string MenuItemId { get; set; }
        public string Name { get; set; }
        public List<string> Ingredients { get; set; }
        public string ImageUrl { get; set; }
        public float Price { get; set; }
        public int Amount { get; set; }
        public MenuItemUnit Unit { get; set; }
    }
}