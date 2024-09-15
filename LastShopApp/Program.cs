using LastShopApp.controllers;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;
Console.InputEncoding = Encoding.UTF8;
ProductsController productController = new ProductsController();
Start:
Console.WriteLine("" +
    "1: Bütün məhsullara baxmaq üçün; " +
    "2: Kateqoriyaya görə məhsullara baxmaq; " +
    "3: Bütün stokun ümumi məbləğinə baxmaq;" +
    "4: Stokun kateqoriyaya görə ümumi məbləğinə baxmaq;" +
    "5: Məhsul əlavə etmək;" +
    "6: Məhsul silmək üçün" +
    "7: Hər hansısa məhsulu yeniləmək üçün" +
    "8: Hər hansısa məhsulu silmək üçün"
    );
var selectedVariant = Console.ReadLine();   
if (selectedVariant == "1")
{
    Console.Clear();
    productController.showAllProducts();
    goto Start;
} else if (selectedVariant == "2")
{
    Console.Clear();
    Console.WriteLine("İstədiyiniz kateqoriyanın nömrəsini seçin");
    productController.showAllProductsByCategory();
    goto Start;
}
else if (selectedVariant == "3")
{
    Console.Clear();
    productController.seeAllPriceOfStock();
    goto Start;
}
else if (selectedVariant == "4")
{
    Console.Clear();
    productController.seeAllPriceOfStockByCategory();
    goto Start;
}
else if (selectedVariant == "5")
{
    Console.Clear();
    productController.AddProduct();
    goto Start;
}
else if (selectedVariant == "6")
{
    Console.Clear();
    productController.RemoveProduct();
    goto Start;
}
else if (selectedVariant == "7")
{
    Console.Clear();
    productController.UpdateProduct();
    goto Start;
}
else if (selectedVariant == "8")
{
    Console.Clear();
    productController.SellProduct();
    goto Start;
}
else
{
    Console.Clear();
    Console.WriteLine("Yanlış seçim etdiniz");
    goto Start;
}

