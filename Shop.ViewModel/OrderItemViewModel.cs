namespace Shop.ViewModel
{
    public class OrderItemViewModel
    {
        public int OrderItemId { get; set; }

        public int OrderHeaderId { get; set; }
        public OrderHeaderViewModel OrderHeader { get; set; }

        public int ItemId { get; set; }
        public ItemViewModel Item { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
    }
}
