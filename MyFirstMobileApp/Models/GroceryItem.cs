using System;
namespace MyFirstMobileApp
{
    public class GroceryItem
    {
        public Guid Id { get; set; }

        public int Quantity { get; set; }

        public string Unit { get; set; }

        public string ItemName { get; set; }

        public double Price { get; set; }
    }
}
