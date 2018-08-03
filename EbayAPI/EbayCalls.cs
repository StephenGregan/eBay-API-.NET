using eBay.Service.Core.Soap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbayAPI
{
    public class EbayCalls
    {
        public static eBayAPIInterfaceService EbayServiceCall(string callName)
        {
            string endpoint = "https://api.sandbox.ebay.com/wsapi";
            string siteId = "3";
            string appId = AppSettingsHelper.AppID;
            string devId = AppSettingsHelper.DevID;
            string certId = AppSettingsHelper.CertID;
            string version = "965";
            string requestURL = endpoint
                + "?callname" + callName
                + "&siteid" + siteId
                + "&appId" + appId
                + "&version=" + version
                + "&routing=default";

            eBayAPIInterfaceService service = new eBayAPIInterfaceService();
            service.Url = requestURL;

            service.RequesterCredentials = new CustomSecurityHeaderType();
            service.RequesterCredentials.eBayAuthToken = AppSettingsHelper.Token;
            service.RequesterCredentials.Credentials = new UserIdPasswordType();
            service.RequesterCredentials.Credentials.AppId = appId;
            service.RequesterCredentials.Credentials.DevId = devId;
            service.RequesterCredentials.Credentials.AuthCert = certId;
            return service;
        }
    }
}
