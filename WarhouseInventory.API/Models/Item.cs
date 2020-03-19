namespace WarehouseInventory.API.Models
{
    public class Item
    {
        public Item(int id, string name, string description, int amount, string supplier, int sellingPrice)
        {
            Id = id;
            Name = name;
            Description = description;
            Amount = amount;
            Supplier = supplier;
            SellingPrice = sellingPrice;
        }
        public Item()
        {

        }
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Amount { get; set; }

        public string Supplier { get; set; }

        public double SellingPrice { get; set; }

    }
}
