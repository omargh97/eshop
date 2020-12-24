using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PayPal.Api;

namespace eshop
{
    public class PaypalConfiguration
    {
        public readonly static string clientId;
        public readonly static string clientSecret;


        static PaypalConfiguration()
        {
            var config = GetConfig();
            clientId = "AQNz_hzryR7gCa0l5Q3ti3XKhU7b7l5WPiNAZmOiQq8Ku1AJR6XlftGY-Q8bqYY49LM2mTWcI6C15z6Y";
            clientSecret = "EACOqhs3mq5LuueKEm5itB-_ZpepIOWFaThAWNF-Obf-UPVxkmfGt8QcpXEJLmdQWThVi26n7ko3qBtg";
        }

        public static Dictionary<string, string> GetConfig()
        {
            return PayPal.Api.ConfigManager.Instance.GetProperties();
        }
        private static string GetAccessToken()
        {
            
            string accessToken = new OAuthTokenCredential(clientId, clientSecret, GetConfig()).GetAccessToken();
            return accessToken;
        }
        public static APIContext GetAPIContext()
        {
            // return apicontext object by invoking it with the accesstoken  
            APIContext apiContext = new APIContext(GetAccessToken());
            apiContext.Config = GetConfig();
            return apiContext;
        }
    }
}