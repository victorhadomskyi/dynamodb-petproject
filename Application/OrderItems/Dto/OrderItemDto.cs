namespace Application.OrderItems.Dto
{
    public class OrderItemDto
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public int Count { get; set; }
        public string MenuGroup { get; set; }
        public string MenuItemId { get; set; }
    }
}
