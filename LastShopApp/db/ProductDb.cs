using LastShopApp.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LastShopApp.enums;
namespace LastShopApp.db
{
    internal class ProductDb
    {
        public static List<Product> products = new List<Product>
        {
            new Product(1, "Laptop", "Dell XPS 13", 10, 1200.00m, Category.Electronics),
            new Product(2, "Smartphone", "iPhone 13", 15, 999.00m, Category.Electronics),
            new Product(3, "Headphones", "Sony WH-1000XM4", 20, 349.99m, Category.Electronics),
            new Product(4, "T-shirt", "Nike Sportswear", 30, 25.00m, Category.Clothing),
            new Product(5, "Jeans", "Levi's 501", 40, 50.00m, Category.Clothing),
            new Product(6, "Jacket", "North Face", 25, 120.00m, Category.Clothing),
            new Product(7, "Vacuum Cleaner", "Dyson V11", 5, 599.99m, Category.HomeAppliances),
            new Product(8, "Microwave", "Panasonic NN-SN936B", 12, 150.00m, Category.HomeAppliances),
            new Product(9, "Refrigerator", "Samsung RF28R7351SG", 8, 1800.00m, Category.HomeAppliances),
            new Product(10, "Book", "The Pragmatic Programmer", 50, 45.00m, Category.Books),
            new Product(11, "Book", "Clean Code", 60, 40.00m, Category.Books),
            new Product(12, "Book", "Design Patterns", 30, 55.00m, Category.Books),
            new Product(13, "Lipstick", "MAC Ruby Woo", 20, 20.00m, Category.Beauty),
            new Product(14, "Foundation", "Fenty Beauty Pro Filt'r", 25, 35.00m, Category.Beauty),
            new Product(15, "Perfume", "Chanel No. 5", 15, 120.00m, Category.Beauty),
            new Product(16, "Action Figure", "Marvel Iron Man", 18, 50.00m, Category.Toys),
            new Product(17, "Lego Set", "Star Wars Millennium Falcon", 10, 150.00m, Category.Toys),
            new Product(18, "Board Game", "Catan", 30, 40.00m, Category.Toys),
            new Product(19, "Tennis Racket", "Wilson Pro Staff", 7, 200.00m, Category.Sports),
            new Product(20, "Basketball", "Spalding NBA", 20, 30.00m, Category.Sports),
            new Product(21, "Running Shoes", "Adidas Ultraboost", 25, 180.00m, Category.Sports),
            new Product(22, "Car Battery", "Optima RedTop", 10, 250.00m, Category.Automotive),
            new Product(23, "Tire", "Michelin Pilot Sport", 15, 150.00m, Category.Automotive),
            new Product(24, "Car Oil", "Mobil 1 Synthetic", 30, 40.00m, Category.Automotive),
            new Product(25, "Rice", "Uncle Ben's", 50, 20.00m, Category.Groceries),
            new Product(26, "Milk", "Organic Valley", 60, 5.00m, Category.Groceries),
            new Product(27, "Bread", "Wonder Bread", 70, 3.00m, Category.Groceries),
            new Product(28, "Sofa", "IKEA Kivik", 10, 500.00m, Category.Furniture),
            new Product(29, "Coffee Table", "IKEA Lack", 20, 50.00m, Category.Furniture),
            new Product(30, "Jewelry Box", "Pandora", 15, 70.00m, Category.Jewelry)
        };
    }
}
