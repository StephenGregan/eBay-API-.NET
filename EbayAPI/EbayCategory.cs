using eBay.Service.Core.Soap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbayAPI
{
    public class EbayCategory
    {
        public static void GetTopLevelCategories()
        {
            eBayAPIInterfaceService service = EbayCalls.EbayServiceCall("GetCategories");

            GetCategoriesRequestType request = new GetCategoriesRequestType();
            request.Version = "949";
            request.CategorySiteID = "3";
            request.LevelLimit = 1;
            request.DetailLevel = new DetailLevelCodeTypeCollection { DetailLevelCodeType.ReturnAll };
            GetCategoriesResponseType response = service.GetCategories(request);

            Console.WriteLine("====================");
            Console.WriteLine("Top-Level Categories");
            Console.WriteLine("====================");
            foreach (dynamic cat in response.CategoryArray)
            {
                Console.WriteLine("{0} - {1}", cat.CategoryID, cat.CategoryName);
            }

            Console.WriteLine("====================");
            Console.WriteLine("Please enter a Top-Level Category ID: ");
            Console.WriteLine("====================");
            var topLevel = Console.ReadLine();
            GetLevel2Categories(topLevel);
        }

        public static void GetLevel2Categories(string topLevel)
        {
            eBayAPIInterfaceService service = EbayCalls.EbayServiceCall("GetCategories");

            GetCategoriesRequestType request = new GetCategoriesRequestType();

            request.Version = "949";
            request.CategorySiteID = "3";
            request.LevelLimit = 2;
            request.CategoryParent = new StringCollection { topLevel };
            request.DetailLevel = new DetailLevelCodeTypeCollection { DetailLevelCodeType.ReturnAll };
            GetCategoriesResponseType response = service.GetCategories(request);

            Console.WriteLine("==================");
            Console.WriteLine("Level 2 Categories");
            Console.WriteLine("==================");

            foreach (dynamic cat in response.CategoryArray)
            {
                Console.WriteLine("{0} - {1}", cat.CategoryID, cat.CategoryName);
            }
        }

        public static void GetCategoryFeaturesRequest(string CategoryID)
        {
            eBayAPIInterfaceService service = EbayCalls.EbayServiceCall("GetCategoryFeatures");

            GetCategoryFeaturesRequestType request = new GetCategoryFeaturesRequestType();

            request.Version = "949";
            request.WarningLevel = WarningLevelCodeType.High;
            request.CategoryID = CategoryID;
            request.FeatureID = new FeatureIDCodeTypeCollection {
            FeatureIDCodeType.ConditionValues,
            FeatureIDCodeType.ListingDurations,
            FeatureIDCodeType.HandlingTimeEnabled,
            FeatureIDCodeType.MaxFlatShippingCost,
            FeatureIDCodeType.PayPalRequired,
            FeatureIDCodeType.BestOfferEnabled,
            FeatureIDCodeType.ReturnPolicyEnabled};

            request.DetailLevel = new DetailLevelCodeTypeCollection { DetailLevelCodeType.ReturnAll };
            GetCategoryFeaturesResponseType response = service.GetCategoryFeatures(request);

            Console.WriteLine("===============");
            Console.WriteLine("Category Features");
            Console.WriteLine("===============");

            Console.WriteLine("Ack: {0}", response.Ack);
            Console.WriteLine("Version: {0}", response.Version);
            Console.WriteLine("Build: {0}", response.Build);
            Console.WriteLine("Category Version: {0}", response.CategoryVersion);
            Console.WriteLine("Update Time: {0}", response.UpdateTime);
            Console.WriteLine("Return Policy Enabled: {0}", response.SiteDefaults.ReturnPolicyEnabled);
            Console.WriteLine("PayPal Required: {0}", response.SiteDefaults.PayPalRequired);
        }

        public static void GetEbayDetailsRequest()
        {
            eBayAPIInterfaceService service = EbayCalls.EbayServiceCall("GetEbayDetails");

            GeteBayDetailsRequestType request = new GeteBayDetailsRequestType();
            request.Version = "949";
            request.DetailName = new DetailNameCodeTypeCollection { DetailNameCodeType.ReturnPolicyDetails };

            GeteBayDetailsResponseType response = service.GeteBayDetails(request);

            Console.WriteLine("================");
            Console.WriteLine("Ebay request Details");
            Console.WriteLine("================");

            Console.WriteLine("Ack: {0}", response.Ack);
            Console.WriteLine("Version: {0}", response.Version);
            Console.WriteLine("Build: {0}", response.Build);
        }

        public static void GetAllCategoriesRequest()
        {
            eBayAPIInterfaceService service = EbayCalls.EbayServiceCall("GetCategories");

            GetCategoriesRequestType request = new GetCategoriesRequestType();
            request.Version = "949";
            request.CategorySiteID = "3";
            request.DetailLevel = new DetailLevelCodeTypeCollection { DetailLevelCodeType.ReturnAll};
            GetCategoriesResponseType response = service.GetCategories(request);

            Console.WriteLine("===============");
            Console.WriteLine("CategoryID - Name List");
            Console.WriteLine("===============");

            foreach (dynamic cat in response.CategoryArray)
            {
                Console.WriteLine("{0} - {1}", cat.CategotID, cat.CategoryName);
            }
        }
    }
}
