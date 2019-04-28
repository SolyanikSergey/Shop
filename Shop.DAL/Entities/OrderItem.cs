namespace Shop.DAL.Entities
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }

        public int OrderHeaderId { get; set; }
        public OrderHeader OrderHeader { get; set; }

        public int ItemId { get; set; }
        public Item Item { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
    }
}
