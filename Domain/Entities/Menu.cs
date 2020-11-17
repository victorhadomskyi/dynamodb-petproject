namespace Domain.Entities
{
    using System.Collections.Generic;
    using Amazon.DynamoDBv2.DataModel;

    [DynamoDBTable("OrdersCatalog")]
    public class Menu
    {
        [DynamoDBHashKey("PK")]
        public string MenuPk { get; set; } = "MENU";
        [DynamoDBRangeKey("SK")]
        public string MenuSk { get; set; } = "MENU";
        public List<string> MenuGroups { get; set; }
    }
}