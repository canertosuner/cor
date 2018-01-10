using System.Collections.Generic;

namespace COR
{
    public class Product
    {
        public decimal Price { get; private set; }
        public decimal DiscountedPrice { get; set; }
        public string Name { get; private set; }

        public Product(string name, decimal price)
        {
            Price = price;
            Name = name;
            DiscountedPrice = price;
        }
    }
}