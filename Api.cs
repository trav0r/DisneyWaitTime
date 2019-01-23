using System;
using System.Xml;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace DisneyWaitTime
{
    public static class Api
    {
        #region AccessInfo
        private const string AccessTokenURL = "https://authorization.go.com/token";
        private const string AccessTokenURLBody = "grant_type=assertion&assertion_type=public&client_id=WDPRO-MOBILE.MDX.WDW.ANDROID-PROD";
        private const string AccessTokenURLMethod = "POST";
        private const string AppID = "WDW-MDX-ANDROID-3.4.1";
        private const string BaseURL = "https://api.wdpro.disney.go.com/facility-service/theme-parks/";
        private const string UserAgent = "Mozilla/5.0 (Linux; Android 6.0; HTC One M9 Build/MRA58K) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/52.0.2743.98 Mobile Safari/537.36";
        
        #endregion

        #region IDs

        //Magic Kingdom
        private const string WDW_MK_PARK_ID = "80007944";
        private const string WDW_MK_RESORT_ID = "80007798";

        //Epcot
        private const string WDW_EC_PARK_ID = "80007838";
        private const string WDW_EC_RESORT_ID = "80007798";

        //Hollywood Studios
        private const string WDW_HS_PARK_ID = "80007998";
        private const string WDW_HS_RESORT_ID = "80007798";

        //Animal Kingdom
        private const string WDW_AK_PARK_ID = "80007823";
        private const string WDW_AK_RESORT_ID = "80007798";

        #endregion
       
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static AccessToken GetAccessToken()
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(AccessTokenURL);
            webRequest.Method = WebRequestMethods.Http.Post;
            webRequest.UserAgent = UserAgent;

            using (StreamWriter streamWriter = new StreamWriter(webRequest.GetRequestStream()))
            {
               streamWriter.Write(AccessTokenURLBody);
               streamWriter.Flush();
               streamWriter.Close();

               HttpWebResponse httpResponse = (HttpWebResponse)webRequest.GetResponse();
               using (StreamReader streamReader = new StreamReader(httpResponse.GetResponseStream()))
               {
                   string accessJson = streamReader.ReadToEnd();
                   //return new AccessToken();
                   return JsonConvert.DeserializeObject<AccessToken>(accessJson);
               }
           }
        }

        public static string GetWaitTimes()
        {
            string currentUrl = GetURL(WDW_MK_PARK_ID, WDW_MK_RESORT_ID);

            AccessToken currentToken = GetAccessToken();
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(currentUrl);

            webRequest.Headers["Authorization"]  = currentToken.token_type + " " + currentToken.access_token;
            webRequest.Accept = "application/json;apiversion=1";
            webRequest.Headers["X-Conversation-Id"] = "WDPRO-MOBILE.MDX.CLIENT-PROD";
            webRequest.Headers["X-App-Id"] = AppID;
            webRequest.Headers["X-Correlation-ID"] = GetMillisecondsSinceEpoch();

            HttpWebResponse httpResponse = (HttpWebResponse)webRequest.GetResponse();
            using (StreamReader streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                return streamReader.ReadToEnd();
            }
        }

        public static string GetMillisecondsSinceEpoch()
        {
            DateTime epoch = new DateTime(1970, 1, 1);
             return ((long)((DateTime.Now.ToUniversalTime() - epoch).TotalMilliseconds + 0.5)).ToString();


             //DateTime.Now.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds
        }

        private static string GetURL(string parkID, string resortID)
        {
            return BaseURL + parkID + ";destination=" + resortID + "/wait-times";
        }

        public static string GetURL()
        {
            return GetAccessToken().access_token;
        }
    }
}
