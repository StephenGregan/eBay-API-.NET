using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbayAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Displays Top Level Categories
                EbayCategory.GetTopLevelCategories();

                //View all categories and ID's
                EbayCategory.GetAllCategoriesRequest();

                //Verifies item then adds item to ebay
                EbayItem.VerifyAddItemRequest();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Console.ReadLine();
        }
    }
}
