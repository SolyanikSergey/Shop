namespace Shop.DAL.Entities
{
    public class Item
    {
        public int ItemId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
