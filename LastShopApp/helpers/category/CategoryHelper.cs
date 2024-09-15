using LastShopApp.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LastShopApp.helpers.category
{
    internal static class CategoryHelper
    {
        public static void getAllCategories() {
            foreach (var category in Enum.GetValues(typeof(Category)))
            {
                Console.WriteLine($"{(int)category}. {category}");
            }
        }
    }
}
