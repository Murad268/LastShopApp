using LastShopApp.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LastShopApp.models
{
    internal class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public uint Quantity { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }
        public Product(int id, string name, string model, uint quantity, decimal price, Category category)
        {
            Id = id;
            Name = name;
            Model = model;
            Quantity = quantity;
            Price = price;
            Category = category;
        }
    }
}
