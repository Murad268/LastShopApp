using LastShopApp.enums;
using LastShopApp.helpers.category;
using LastShopApp.models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LastShopApp.helpers.products
{
    internal class ProductHelper
    {
        public static void ShowAllProducts(List<Product> products)
        {
            foreach (Product product in products)
            {
                Console.WriteLine($"Məhsulun id-si: {product.Id}");
                Console.WriteLine($"Məhsulun adı: {product.Name}");
                Console.WriteLine($"Məhsulun modeli: {product.Model}");
                Console.WriteLine($"Məhsulun sayı;: {product.Quantity}");
                Console.WriteLine($"Məhsulun qiyməti: {product.Price}");
                Console.WriteLine($"Məhsulun kateqoriyası: {product.Category}");
                Console.WriteLine("==========================");
            }
        }

        public static List<Product> FindProductByCategory(Category category, List<Product> products) {
            return products.Where(product => product.Category == category).ToList();
        }


        public static string NameValidation(string name)
        {
            while (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Ad düzgün formatda deyil. Zəhmət olmasa formatı düzgün daxil edin. Ad sahəsi boş ola bilməz.\nYenidən daxil edin:\n");
                name = Console.ReadLine(); 
            }

            return name;
        }


        public static string ModelValidation(string model)
        {
            while (string.IsNullOrEmpty(model)) 
            {
                Console.WriteLine("Model düzgün formatda deyil. Zəhmət olmasa formatı düzgün daxil edin. Model sahəsi boş ola bilməz.\nYenidən daxil edin:\n");
                model = Console.ReadLine(); 
            }

            return model;
        }



        public static uint QuantityValidation(string quantity)
        {
            while (!int.TryParse(quantity, out int number) || number < 1)
            {
                Console.WriteLine("Məhsul sayı düzgün formatda deyil. Zəhmət olmasa formatı düzgün daxil edin. Məhsul sahəsi sahəsi boş ola bilməz, qeyri rəqəmdən ibarət ola bilməz və ya 1-dən kiçik ola bilməz\nYenidən daxil edin:\n");
                quantity = Console.ReadLine();
            }
  ;
            return Convert.ToUInt32(quantity);
        }


        public static decimal PriceValidation(string price)
        {
            while (!decimal.TryParse(price, out decimal number) || number < 1)
            {
                Console.WriteLine("Məhsulun qiyməti düzgün formatda deyil. Zəhmət olmasa formatı düzgün daxil edin. Qiymət sahəsi sahəsi boş ola bilməz, qeyri rəqəmdən ibarət ola bilməz və ya 1-dən kiçik ola bilməz\nYenidən daxil edin:\n");
                price = Console.ReadLine();
            }


            return Convert.ToDecimal(price);
        }


        public static Category? CategoryValidation(string input)
        {
            bool stop = true;
            Category? chosenCategory = null;

            while (stop)
            {
                if (int.TryParse(input, out int selectedCategory) && Enum.IsDefined(typeof(Category), selectedCategory))
                {
                    chosenCategory = (Category)selectedCategory;
                    stop = false;
                }
                else
                {
                    Console.WriteLine("Yanlış seçim etdiniz. Zəhmət olmasa düzgün nömrə daxil edin:");
                    input = Console.ReadLine();
                }
            }

            return chosenCategory;
        }

        public static bool CheckHasProduct(List<Product> products, int id)
        {
            foreach (var product in products)
            {
                if (product.Id == id)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
