using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LastShopApp.db;
using LastShopApp.enums;
using LastShopApp.helpers.category;
using LastShopApp.helpers.products;
using LastShopApp.models;
namespace LastShopApp.controllers
{
    internal class ProductsController
    {
        List<Product> products = ProductDb.products;
     
        public void showAllProducts() {
            ProductHelper.ShowAllProducts(products);
        }

        public void showAllProductsByCategory()
        {
          
            bool stop = true;

         
            while (stop)
            {
                CategoryHelper.getAllCategories();
                Console.WriteLine("İstədiyiniz kateqoriyanın nömrəsini seçin və ya çıxmaq üçün 'q' daxil edin:");
                string input = Console.ReadLine();
                if (input.ToLower() == "q")
                {
                    return;
                }
                if (int.TryParse(input, out int selectedCategory) && Enum.IsDefined(typeof(Category), selectedCategory))
                {
                    Category chosenCategory = (Category)selectedCategory;
                    List<Product> filteredProducts = ProductHelper.FindProductByCategory(chosenCategory, products);
                    ProductHelper.ShowAllProducts(filteredProducts);
                    stop = false;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Yanlış seçim etdiniz. Zəhmət olmasa düzgün nömrə daxil edin.");
                }
            }

        
        }

        public void seeAllPriceOfStock()
        {
            Console.WriteLine($"Stokun ümumi qiyməti: {products.Sum(product=>product.Price)} AZN");    
        }

        public void seeAllPriceOfStockByCategory()
        {
            bool stop = true;

            while (stop)
            {
                CategoryHelper.getAllCategories();
                Console.WriteLine("İstədiyiniz kateqoriyanın nömrəsini seçin və ya çıxmaq üçün 'q' daxil edin:");
                string input = Console.ReadLine();
                if (input.ToLower() == "q")
                {
                    return;
                }
                if (int.TryParse(input, out int selectedCategory) && Enum.IsDefined(typeof(Category), selectedCategory))
                {
                    Category chosenCategory = (Category)selectedCategory;
                    Console.WriteLine($"Stokun ümumi qiyməti: {products.Sum(product => product.Category == chosenCategory ? product.Price : 0)} AZN");
                    stop = false;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Yanlış seçim etdiniz. Zəhmət olmasa düzgün nömrə daxil edin.");
                }
            }
        }

        public void AddProduct()
        {
            int id = products.Count > 0 ? products[products.Count - 1].Id + 1 : 1;

            Console.WriteLine("Məhsul adını daxil edin:");
            string name = ProductHelper.NameValidation(Console.ReadLine());

            Console.WriteLine("Məhsul modelini daxil edin:");
            string model = ProductHelper.ModelValidation(Console.ReadLine());

            Console.WriteLine("Məhsul sayını daxil edin:");
            uint quantity = ProductHelper.QuantityValidation(Console.ReadLine());

            Console.WriteLine("Məhsul qiymətini daxil edin:");
            decimal price = ProductHelper.PriceValidation(Console.ReadLine());

            CategoryHelper.getAllCategories();
            Console.WriteLine("İstədiyiniz kateqoriyanın nömrəsini seçin və ya çıxmaq üçün 'q' daxil edin:");
            string input = Console.ReadLine();

            Category? category = ProductHelper.CategoryValidation(input);

            if (!category.HasValue) return;

            Product product = new Product(id, name, model, quantity, price, category.Value);
            products.Add(product);
        }

        public void RemoveProduct()
        {

            ProductHelper.ShowAllProducts(products);
            Console.WriteLine("Silmək istədiyiniz məhsulun id-sini daxil edin");
        Start:

            var selectedId = Console.ReadLine();

            if (int.TryParse(selectedId, out int id))
            {
                if (ProductHelper.CheckHasProduct(products, id))
                {
                    products.RemoveAll(product => product.Id == id);
                    Console.WriteLine($"Məhsul id-si {id} olan məhsul silindi.");
                }
                else
                {
                    Console.WriteLine("Bu id ilə məhsul tapılmadı. Yenidən cəhd edin:\n");
                    goto Start;
                }
            }
            else
            {
                Console.WriteLine("Daxil etdiyiniz id düzgün formatda deyil. Yenidən cəhd edin:\n");
                goto Start;
            }
        }

        public void UpdateProduct()
        {
            ProductHelper.ShowAllProducts(products);
            Console.WriteLine("Yeniləmək istədiyiniz məhsulun id-sini daxil edin");

        Start:

            var selectedId = Console.ReadLine();

            if (int.TryParse(selectedId, out int id))
            {
                Product existingProduct = products.FirstOrDefault(product => product.Id == id);

                if (existingProduct != null)
                {
                    Console.WriteLine($"Məhsulun cari adı: {existingProduct.Name}");
                    Console.WriteLine("Yeni adı daxil edin və ya dəyişmək istəmirsinizsə Enter basın:");
                    string newName = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newName))
                    {
                        existingProduct.Name = ProductHelper.NameValidation(newName);
                    }

                    Console.WriteLine($"Məhsulun cari modeli: {existingProduct.Model}");
                    Console.WriteLine("Yeni model daxil edin və ya dəyişmək istəmirsinizsə Enter basın:");
                    string newModel = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newModel))
                    {
                        existingProduct.Model = ProductHelper.ModelValidation(newModel);
                    }

                    Console.WriteLine($"Məhsulun cari sayı: {existingProduct.Quantity}");
                    Console.WriteLine("Yeni say daxil edin və ya dəyişmək istəmirsinizsə Enter basın:");
                    string newQuantityInput = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newQuantityInput))
                    {
                        uint newQuantity = ProductHelper.QuantityValidation(newQuantityInput);
                        existingProduct.Quantity = newQuantity;
                    }

                    Console.WriteLine($"Məhsulun cari qiyməti: {existingProduct.Price}");
                    Console.WriteLine("Yeni qiymət daxil edin və ya dəyişmək istəmirsinizsə Enter basın:");
                    string newPriceInput = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newPriceInput))
                    {
                        decimal newPrice = ProductHelper.PriceValidation(newPriceInput);
                        existingProduct.Price = newPrice;
                    }

                    Console.WriteLine($"Məhsulun cari kateqoriyası: {existingProduct.Category}");
                    Console.WriteLine("Yeni kateqoriyanı seçin və ya dəyişmək istəmirsinizsə Enter basın:");
                    CategoryHelper.getAllCategories();
                    string newCategoryInput = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newCategoryInput))
                    {
                        Category? newCategory = ProductHelper.CategoryValidation(newCategoryInput);
                        if (newCategory.HasValue)
                        {
                            existingProduct.Category = newCategory.Value;
                        }
                    }

                    Console.WriteLine("Məhsul uğurla yeniləndi.");
                }
                else
                {
                    Console.WriteLine("Bu id ilə məhsul tapılmadı. Yenidən cəhd edin:\n");
                    goto Start;
                }
            }
            else
            {
                Console.WriteLine("Daxil etdiyiniz id düzgün formatda deyil. Yenidən cəhd edin:\n");
                goto Start;
            }
        }

        public void SellProduct()
        {
            if (products.Count == 0)
            {
                Console.WriteLine("Hal-hazırda stokda heç bir məhsul yoxdur.");
                return;
            }

            ProductHelper.ShowAllProducts(products);

            string selectedId;
            int quantityToSell;

        Start:
            Console.WriteLine("Satmaq istədiyiniz məhsulun id-sini daxil edin:");
            selectedId = Console.ReadLine();

            if (!int.TryParse(selectedId, out int id))
            {
                Console.WriteLine("Daxil etdiyiniz id düzgün formatda deyil. Yenidən cəhd edin.");
                goto Start;
            }

            var product = products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                Console.WriteLine("Bu ID ilə uyğun məhsul tapılmadı. Yenidən cəhd edin.");
                goto Start;
            }

        SellQuantity:
            Console.WriteLine($"Məhsul {product.Name} üçün satılacaq miqdarı daxil edin (Mövcud miqdar: {product.Quantity})");

            string input = Console.ReadLine();
            if (!int.TryParse(input, out quantityToSell) || quantityToSell <= 0)
            {
                Console.WriteLine("Yanlış miqdar daxil etdiniz. Zəhmət olmasa müsbət ədəd daxil edin.");
                goto SellQuantity;
            }

            if (quantityToSell > product.Quantity)
            {
                Console.WriteLine($"Stokda kifayət qədər məhsul yoxdur. Mövcud miqdar: {product.Quantity}");
                goto SellQuantity;
            }

            if (quantityToSell == product.Quantity)
            {
                products.RemoveAll(p => p.Id == product.Id);
                Console.WriteLine($"ID-si {id} olan məhsul tamamilə satıldı və inventardan silindi.");
            }
            else
            {
                product.Quantity -= Convert.ToUInt32(quantityToSell);
                Console.WriteLine($"{quantityToSell} ədəd {product.Name} məhsulu satıldı. Qalan miqdar: {product.Quantity}");
            }
        }

    }
}
