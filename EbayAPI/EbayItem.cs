using eBay.Service.Core.Soap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbayAPI
{
    public class EbayItem
    {
        public static void VerifyAddItemRequest()
        {
            eBayAPIInterfaceService service = EbayCalls.EbayServiceCall("verifyAddItem");

            VerifyAddItemRequestType request = new VerifyAddItemRequestType();
            request.Version = "949";
            request.ErrorLanguage = "en_US";
            request.WarningLevel = WarningLevelCodeType.High;

            var item = new ItemType();

            item.Title = "My Title";
            item.Description = "My Description";
            item.PrimaryCategory = new CategoryType { CategoryID = "11704" };
            item.StartPrice = new AmountType { Value = 7.98, currencyID = CurrencyCodeType.GBP };
            item.ConditionID = 1000;
            item.Country = CountryCodeType.GB;
            item.Currency = CurrencyCodeType.GBP;
            item.DispatchTimeMax = 3;
            item.ListingDuration = "Days_7";
            item.ListingType = ListingTypeCodeType.FixedPriceItem;
            item.PaymentMethods = new BuyerPaymentMethodCodeTypeCollection { BuyerPaymentMethodCodeType.PayPal };
            item.PayPalEmailAddress = "testemail.gmail.com";
            item.PictureDetails = new PictureDetailsType { PictureURL = new StringCollection { "https://avatar-ssl.xboxlive.com/avatar/ii%20burg%20ii/avatar-body.png" } };
            item.PostalCode = "[Enter Your PostCode]";
            item.Quantity = 5;
            item.ReturnPolicy = new ReturnPolicyType
            {
                ReturnsAcceptedOption = "Returns Accepted",
                ReturnsWithinOption = "Days_30",
                RefundOption = "MoneyBack",
                Description = "Please feel free to return if you are not satisfied",
                ShippingCostPaidByOption = "Buyer"
            };
            item.ShippingDetails = new ShippingDetailsType
            {
                ShippingType = ShippingTypeCodeType.Flat,
                ShippingServiceOptions = new ShippingServiceOptionsTypeCollection
                {
                     new ShippingServiceOptionsType {
                         ShippingServicePriority = 1,
                         ShippingService = "UK_Parcelforce48",
                         ShippingServiceCost = new AmountType {
                             Value = 2.50,
                             currencyID = CurrencyCodeType.GBP
                         }
                     }
                }
            };
            item.Site = SiteCodeType.UK;

            request.Item = item;

            VerifyAddItemResponseType response = service.VerifyAddItem(request);
            Console.WriteLine("ItemID: {0}", response.ItemID);

            if (response.ItemID == "0")
            {
                Console.WriteLine("======================");
                Console.WriteLine("Add Item verified");
                Console.WriteLine("======================");
                AddItemRequest(item);
            }
        }

        public static void AddItemRequest(ItemType item)
        {
            eBayAPIInterfaceService service = EbayCalls.EbayServiceCall("AddItem");

            AddItemRequestType request = new AddItemRequestType();
            request.Version = "949";
            request.ErrorLanguage = "en_US";
            request.WarningLevel = WarningLevelCodeType.High;
            request.Item = item;

            AddItemResponseType response = service.AddItem(request);

            Console.WriteLine("Item Added");
            Console.WriteLine("ItemID: {0}", response.ItemID);
        }

        public static void GetItemRequest(string itemID)
        {
            eBayAPIInterfaceService service = EbayCalls.EbayServiceCall("GetItem");

            GetItemRequestType request = new GetItemRequestType();
            request.Version = "949";
            request.ItemID = itemID;
            GetItemResponseType response = service.GetItem(request);

            Console.WriteLine("=======================");
            Console.WriteLine("Item Title - {0}", response.Item.Title);
            Console.WriteLine("=======================");

            Console.WriteLine("ItemID: {0}", response.Item.ItemID);
            Console.WriteLine("Primary Category: {0}", response.Item.PrimaryCategory);
            Console.WriteLine("Listing Duration: {0}", response.Item.ListingDuration);
            Console.WriteLine("Start Price: {0}", response.Item.StartPrice);
            Console.WriteLine("Payment Type[0]: {0}", response.Item.PaymentMethods[0]);
            Console.WriteLine("PayPal Email Address: {0}", response.Item.PayPalEmailAddress);
            Console.WriteLine("Postal Code: {0}", response.Item.PostalCode);
        }
    }
}
